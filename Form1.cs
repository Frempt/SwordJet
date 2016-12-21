using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.Configuration;
using System.IO;

namespace TournamentGenerator
{
    public partial class Form1 : Form
    {
        public List<Fighter> fighters = new List<Fighter>();
        private Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ensure a name has been entered
            if (txtName.Text != "")
            {
                //add the new fighter to the list with the next ID, and refresh the listbox
                Fighter fighter = new Fighter(fighters.Last().id + 1, txtName.Text);
                fighters.Add(fighter);

                lstFighters.DataSource = null;
                lstFighters.DataSource = fighters;

                txtName.Text = "";

                //recalculate the pool length message
                CalculateMessage();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //calculate number of fighters per pool
            int numFighters = fighters.Count;
            int fightersPerPool = (numFighters / (int)txtPools.Value);

            //only generate pools if there are more fighters in each pool than rounds - otherwise fights will be repeated
            if (numFighters > 2 && fightersPerPool > Math.Max(3, txtRounds.Value))
            {
                //keep trying to generate pools until we succeed, or have tried too many times - randomness means it may not always work
                //something, something, halting problem
                List<Pool> pools = null;
                int tries = 0;
                int retryLimit = 50;
                int.TryParse(ConfigurationManager.AppSettings["fightGenerationRetryLimit"], out retryLimit);

                do
                {
                    pools = GenerateTournament(fightersPerPool);
                    tries++;
                }
                while (pools == null && tries < retryLimit);

                //ensure pools have generated successfully
                if (pools != null)
                {
                    //put the results into a spreadsheet for the user
                    GenerateSpreadsheet(pools);
                }
                else
                {
                    MessageBox.Show("Too many fuck-ups, try again or modify parameters.");
                }
            }
            else
            {
                MessageBox.Show("Insufficient fighters for number of pools/rounds.");
            }
        }

        //build the time message
        private void CalculateMessage()
        {
            int numFighters = fighters.Count;
            int numPools = (int)txtPools.Value;
            int numRounds = (int)txtRounds.Value;
            int fightersPerPool = (numFighters / numPools);

            //only valid if there are more fighters in each pool than rounds - otherwise fights will be repeated
            if (numFighters > 2 && fightersPerPool > Math.Max(3, numRounds))
            {
                //caclulate the number of fights there will be in total
                int numFights = numFighters * numRounds;
                int fightLength = (int)txtFightTime.Value;

                StringBuilder message = new StringBuilder();
                message.Append(numFights);
                message.Append(" total fights at ");
                message.Append(fightLength);
                message.Append(" minutes maximum time means a total of ");

                //calculate total maximum length of fighting time
                double totalTime = (fightLength * numFights)/numPools;
                string unit = (totalTime == 1.0) ? "minute" : "minutes";

                //if more than 60 minutes, show hours instead
                if(totalTime > 60)
                {
                    totalTime /= 60;
                    unit = (totalTime == 1.0) ? "hour" : "hours";
                }

                message.Append(totalTime);
                message.Append(" ");
                message.Append(unit);

                message.Append(" maximum fighting time per pool.");

                lblLengthMessage.Text = message.ToString();
            }
            else
            {
                lblLengthMessage.Text = "Insufficient fighters for number of pools/rounds.";
            }
        }

        private void GenerateSpreadsheet(List<Pool> pools)
        {
            HSSFWorkbook book = new HSSFWorkbook();

            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "RMAS";
            book.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "Generated Tournament";
            book.SummaryInformation = si;
            
            IFont plainFont = book.CreateFont();
            plainFont.Boldweight = (short)FontBoldWeight.Normal;

            //create the basic left-aligned style
            ICellStyle plainStyle = book.CreateCellStyle();
            plainStyle.SetFont(plainFont);
            plainStyle.WrapText = true;
            plainStyle.VerticalAlignment = VerticalAlignment.Top;
            plainStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

            //create the basic center-aligned style
            ICellStyle plainCenterStyle = book.CreateCellStyle();
            plainCenterStyle.SetFont(plainFont);
            plainCenterStyle.WrapText = true;
            plainCenterStyle.VerticalAlignment = VerticalAlignment.Top;
            plainCenterStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

            IFont boldFont = book.CreateFont();
            boldFont.Boldweight = (short)FontBoldWeight.Bold;

            //create the header style
            ICellStyle headerStyle = book.CreateCellStyle();
            headerStyle.SetFont(boldFont);
            headerStyle.WrapText = false;
            headerStyle.VerticalAlignment = VerticalAlignment.Center;
            headerStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

            //add each pool to a seperate sheet
            foreach (Pool pool in pools)
            {
                int rowIndex = 0;

                //create new sheet for this pool
                ISheet sheet = book.CreateSheet("Pool - " + pool.name);
                sheet.PrintSetup.Landscape = true;
                sheet.PrintSetup.FitHeight = 0;

                //create a merged title cell with the pool name
                IRow topRow = sheet.CreateRow(rowIndex);
                ICell topCell = topRow.CreateCell(topRow.Cells.Count);
                topCell.SetCellValue("POOL - " + pool.name);
                topCell.CellStyle = headerStyle;
                NPOI.SS.Util.CellRangeAddress cra = new NPOI.SS.Util.CellRangeAddress(rowIndex, rowIndex, 0, 1);
                sheet.AddMergedRegion(cra);

                rowIndex += 2;

                //create the fighters header row
                IRow headerRow = sheet.CreateRow(rowIndex);

                ICell headerCellID = headerRow.CreateCell(headerRow.Cells.Count);
                headerCellID.SetCellValue("ID");
                headerCellID.CellStyle = headerStyle;

                ICell headerCellName = headerRow.CreateCell(headerRow.Cells.Count);
                headerCellName.SetCellValue("Name");
                headerCellName.CellStyle = headerStyle;

                ICell headerCellScore = headerRow.CreateCell(headerRow.Cells.Count);
                headerCellScore.SetCellValue("Score");
                headerCellScore.CellStyle = headerStyle;

                ICell headerCellDoubles = headerRow.CreateCell(headerRow.Cells.Count);
                headerCellDoubles.SetCellValue("Doubles");
                headerCellDoubles.CellStyle = headerStyle;

                rowIndex += 2;

                //add each fighter in the pool to the pool sheet
                foreach (Fighter fighter in pool.fighters)
                {
                    IRow row = sheet.CreateRow(rowIndex);

                    ICell cellID = row.CreateCell(row.Cells.Count);
                    cellID.SetCellValue(fighter.id);
                    cellID.CellStyle = plainStyle;

                    ICell cellName = row.CreateCell(row.Cells.Count);
                    cellName.SetCellValue(fighter.name);
                    cellName.CellStyle = plainStyle;

                    ICell cellScore = row.CreateCell(row.Cells.Count);
                    cellScore.CellStyle = plainStyle;
                    fighter.scoreCellRef = new int[] { rowIndex, 2 };

                    ICell cellDoubles = row.CreateCell(row.Cells.Count);
                    cellDoubles.CellStyle = plainStyle;
                    fighter.doubleCellRef = new int[] { rowIndex, 3 };

                    fighter.scoreFormula = "";
                    fighter.doubleFormula = "";

                    rowIndex++;
                }

                rowIndex += 3;

                //add each round of fights to the pool sheet
                foreach(List<Fight> round in pool.rounds)
                {
                    //add merged title cell
                    IRow roundTitleRow = sheet.CreateRow(rowIndex);
                    ICell roundTitleCell = roundTitleRow.CreateCell(roundTitleRow.Cells.Count);
                    roundTitleCell.SetCellValue("ROUND - " + (pool.rounds.IndexOf(round) + 1));
                    roundTitleCell.CellStyle = headerStyle;
                    NPOI.SS.Util.CellRangeAddress cra2 = new NPOI.SS.Util.CellRangeAddress(rowIndex, rowIndex, 0, 6);
                    sheet.AddMergedRegion(cra2);

                    rowIndex++;

                    //create the round headers row
                    IRow headerRowFights = sheet.CreateRow(rowIndex);

                    ICell headerCellDoublesFigherA = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellDoublesFigherA.SetCellValue("Doubles");
                    headerCellDoublesFigherA.CellStyle = headerStyle;

                    ICell headerCellScoreFighterA = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellScoreFighterA.SetCellValue("Score");
                    headerCellScoreFighterA.CellStyle = headerStyle;

                    ICell headerCellNameFighterA = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellNameFighterA.SetCellValue("Name");
                    headerCellNameFighterA.CellStyle = headerStyle;

                    ICell headerCellV = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellV.SetCellValue("v");
                    headerCellV.CellStyle = headerStyle;

                    ICell headerCellNameFighterB = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellNameFighterB.SetCellValue("Name");
                    headerCellNameFighterB.CellStyle = headerStyle;

                    ICell headerCellScoreFighterB = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellScoreFighterB.SetCellValue("Score");
                    headerCellScoreFighterB.CellStyle = headerStyle;

                    ICell headerCellDoublesFigherB = headerRowFights.CreateCell(headerRowFights.Cells.Count);
                    headerCellDoublesFigherB.SetCellValue("Doubles");
                    headerCellDoublesFigherB.CellStyle = headerStyle;

                    rowIndex += 2;

                    //add each fight to the round
                    foreach(Fight fight in round)
                    {
                        IRow row = sheet.CreateRow(rowIndex);

                        ICell cellNameFighterADoubles = row.CreateCell(row.Cells.Count);
                        cellNameFighterADoubles.CellStyle = plainStyle;
                        //update the fighter's doubles formula
                        if (fight.fighterA.doubleFormula != "") fight.fighterA.doubleFormula += ("+A" + (rowIndex + 1));
                        else fight.fighterA.doubleFormula += ("A" + (rowIndex + 1));

                        ICell cellNameFighterAScore = row.CreateCell(row.Cells.Count);
                        cellNameFighterAScore.CellStyle = plainStyle;
                        //update the fighter's score formula
                        if (fight.fighterA.scoreFormula != "") fight.fighterA.scoreFormula += ("+B" + (rowIndex + 1));
                        else fight.fighterA.scoreFormula += ("B" + (rowIndex + 1));

                        ICell cellNameFighterA = row.CreateCell(row.Cells.Count);
                        cellNameFighterA.SetCellValue(fight.fighterA.name);
                        cellNameFighterA.CellStyle = plainStyle;

                        ICell cellV = row.CreateCell(row.Cells.Count);
                        cellV.SetCellValue("v");
                        cellV.CellStyle = plainCenterStyle;

                        ICell cellNameFighterB = row.CreateCell(row.Cells.Count);
                        cellNameFighterB.SetCellValue(fight.fighterB.name);
                        cellNameFighterB.CellStyle = plainStyle;

                        ICell cellNameFighterBScore = row.CreateCell(row.Cells.Count);
                        cellNameFighterBScore.CellStyle = plainStyle;
                        if (fight.oddFight)
                        {
                            cellNameFighterBScore.SetCellValue("X");
                        }
                        else
                        {
                            //update the fighter's score formula
                            if (fight.fighterB.scoreFormula != "") fight.fighterB.scoreFormula += ("+F" + (rowIndex + 1));
                            else fight.fighterB.scoreFormula += ("F" + (rowIndex + 1));
                        }

                        ICell cellNameFighterBDoubles = row.CreateCell(row.Cells.Count);
                        cellNameFighterBDoubles.CellStyle = plainStyle;
                        if (fight.oddFight)
                        {
                            cellNameFighterBDoubles.SetCellValue("X");
                        }
                        else
                        {
                            //update the fighter's doubles formula
                            if (fight.fighterB.doubleFormula != "") fight.fighterB.doubleFormula += ("+G" + (rowIndex + 1));
                            else fight.fighterB.doubleFormula += ("G" + (rowIndex + 1));
                        }
                        

                        rowIndex++;
                    }

                    rowIndex += 3;
                }

                //update each pool fighter score and doubles forumlae
                foreach(Fighter fighter in pool.fighters)
                {
                    if (fighter.scoreCellRef != null)
                    {
                        IRow scoreRow = sheet.GetRow(fighter.scoreCellRef[0]);
                        ICell scoreCell = scoreRow.GetCell(fighter.scoreCellRef[1]);
                        scoreCell.SetCellFormula(fighter.scoreFormula);
                    }

                    if (fighter.doubleCellRef != null)
                    {
                        IRow doubleRow = sheet.GetRow(fighter.doubleCellRef[0]);
                        ICell doubleCell = doubleRow.GetCell(fighter.doubleCellRef[1]);
                        doubleCell.SetCellFormula(fighter.doubleFormula);
                    }

                    //reset the fighter excel variables
                    fighter.scoreFormula = "";
                    fighter.doubleFormula = "";
                    fighter.doubleCellRef = null;
                    fighter.scoreCellRef = null;
                }
            }

            //create the file save dialog
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel |*.xls";
            dialog.FileName = "Tournament" + Guid.NewGuid() + ".xls";
            dialog.CheckFileExists = false;

            //call the ShowDialog method to show the save dialog box.
            DialogResult userClickedOK = dialog.ShowDialog();

            //process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                FileStream stream = new FileStream(dialog.FileName, FileMode.Create);
                book.Write(stream);
                stream.Close();
            }

            //cleanup
            dialog.Dispose();
            book.Close();
        }

        private List<Pool> GenerateTournament(int fightersPerPool)
        {
            List<Pool> pools = new List<Pool>();

            int retryLimit = 50;
            int.TryParse(ConfigurationManager.AppSettings["fightGenerationRetryLimit"], out retryLimit);

            List<string> poolNames = new List<string>();
            poolNames.AddRange(ConfigurationManager.AppSettings["poolNames"].Split(','));

            //clone the list of fighters so we don't remove from the master list
            List<Fighter> fightersClone = new List<Fighter>();
            fightersClone.AddRange(fighters);

            for (int i = 0; i < txtPools.Value; i++)
            {
                Pool pool = new Pool();

                int nameIndex = rng.Next(0, poolNames.Count);
                pool.name = poolNames[nameIndex];
                poolNames.RemoveAt(nameIndex);

                //add random fighters to the pool until we have the correct size
                for (int j = 0; j < fightersPerPool; j++)
                {
                    int randIndex = rng.Next(0, fightersClone.Count);
                    pool.fighters.Add(fightersClone[randIndex]);
                    fightersClone.RemoveAt(randIndex);
                }

                //if there are any odd fighters, add them to the last pool
                if (i == txtPools.Value - 1 && fightersClone.Count > 0)
                {
                    pool.fighters.Add(fightersClone[0]);
                }

                for (int k = 0; k < txtRounds.Value; k++)
                {
                    List<Fight> fights = new List<Fight>();

                    //clone the pool fighter list so we don't remove from the master list
                    List<Fighter> roundFighters = new List<Fighter>();
                    roundFighters.AddRange(pool.fighters);
                    Helpers.Shuffle(roundFighters);

                    //don't increment l because we will be removing from the list while iterating anyway
                    for (int l = 0; l < roundFighters.Count;)
                    {
                        int opponent = 0;

                        //if there is more than one fighter in this round, generate a normal fight
                        if (roundFighters.Count > 1)
                        {
                            int tries = 0;
                            do
                            {
                                opponent = rng.Next(l + 1, roundFighters.Count);
                                tries++;

                                //start again if we fuck up too much
                                if (tries > retryLimit) return null;
                            }
                            //ensure the fight hasn't happened already, and the fighter isn't fighting themselves (that would be pretty dumb)
                            while (pool.HasFightHappenedAlready(new Fight(roundFighters[l], roundFighters[opponent])) || opponent == l);

                            Fight fight = new Fight(roundFighters[l], roundFighters[opponent]);
                            fights.Add(fight);
                            roundFighters.Remove(fight.fighterA);
                            roundFighters.Remove(fight.fighterB);
                        }
                        //odd fight if only one fighter left - find a fight from the pool which has not happened yet
                        else
                        {
                            int tries = 0;
                            do
                            {
                                opponent = rng.Next(l + 1, pool.fighters.Count);
                                tries++;

                                //start again if we fuck up too much
                                if (tries > retryLimit) return null;
                            }
                            //ensure the fight hasn't happened already, and the fighter isn't fighting themselves, and the opponent was not in the last fight
                            while (pool.HasFightHappenedAlready(new Fight(roundFighters[l], pool.fighters[opponent])) || roundFighters[l] == pool.fighters[opponent] || fights.Last().fighterA.id == pool.fighters[opponent].id || fights.Last().fighterB.id == pool.fighters[opponent].id);

                            Fight fight = new Fight(roundFighters[l], pool.fighters[opponent]);
                            fight.oddFight = true;
                            fights.Add(fight);
                            roundFighters.Remove(fight.fighterA);
                        }
                    }

                    pool.rounds.Add(fights);
                }

                pools.Add(pool);
            }

            return pools;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //remove selected fighter
            if(lstFighters.SelectedItem != null)
            {
                fighters.RemoveAt(lstFighters.SelectedIndex);
                lstFighters.DataSource = null;
                lstFighters.DataSource = fighters;
            }
        }

        private void upDown_ValueChanged(object sender, EventArgs e)
        {
            //recalulate pool length message
            CalculateMessage();
        }
    }

    public static class Helpers
    {
        static Random rng = new Random();

        /// <summary>
        /// Randomise the order of items in a generic list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to shuffle</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int size = list.Count;
            while (size > 1)
            {
                size--;
                int index = rng.Next(size + 1);
                T value = list[index];
                list[index] = list[size];
                list[size] = value;
            }
        }
    }

    public class Pool
    {
        public List<Fighter> fighters = new List<Fighter>();
        public List<List<Fight>> rounds = new List<List<Fight>>();
        public string name;

        public Pool()
        {

        }

        public bool HasFightHappenedAlready(Fight newFight)
        {
            foreach (List<Fight> round in rounds)
            {
                foreach (Fight fight in round)
                {
                    if (fight.Equals(newFight)) return true;
                }
            }
            return false;
        }
    }

    public class Fight
    {
        public Fighter fighterA;
        public Fighter fighterB;
        public bool oddFight = false;

        public Fight(Fighter a, Fighter b)
        {
            fighterA = a;
            fighterB = b;
        }

        public bool Equals(Fight obj)
        {
            //if the two fighters are the same, the fight is equal regardless of order
            if (fighterA.id == obj.fighterA.id || fighterA.id == obj.fighterB.id)
            {
                if (fighterB.id == obj.fighterA.id || fighterB.id == obj.fighterB.id)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Fighter
    {
        public int id;
        public string name;

        //excel values
        public int[] scoreCellRef;
        public string scoreFormula = "";
        public int[] doubleCellRef;
        public string doubleFormula = "";

        public Fighter(int fighterId, string fighterName)
        {
            id = fighterId;
            name = fighterName;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
