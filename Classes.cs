using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using Microsoft.VisualBasic.FileIO;

namespace SwordJet
{
    public static class ConfigValues
    {
        public static int fightGenerationRetryLimit;
        public static List<string> poolNames;
        public static List<int> eliminationSizes;
        public static List<string> qualificationSortOrder;
    }

    public static class Helpers
    {
        public static Random rng = new Random();

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

        /// <summary>
        /// Split a list into smaller lists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list to split</param>
        /// <param name="size">The maximum size of each sub-list</param>
        /// <returns></returns>
        public static List<List<T>> Split<T> (this IList<T> list, int size)
        {
            if (size <= 0) return null;

            List<List<T>> splitList = new List<List<T>>();

            List<T> clone = new List<T>();
            clone.AddRange(list);

            while (clone.Count > 0)
            {
                List<T> batch = new List<T>();
                for (int i = 0; i < size; i++)
                {
                    batch.Add(clone[0]);
                    clone.RemoveAt(0);
                    if (clone.Count == 0) break;
                }

                splitList.Add(batch);
            }

            return splitList;
        }

        /// <summary>
        /// Return a list of every possible distinct value pairing from a given list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T[]> GetDistinctPairs<T>(this IList<T> list)
        {
            List<T[]> pairs = new List<T[]>();

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = (i + 1); j < list.Count; j++)
                {
                    pairs.Add(new T[] { list[i], list[j] });
                }
            }

            return pairs;
        }
    }

    public static class Logging
    {
        public static void WriteToLog(string logName, string textToLog)
        {
            //write the specified text to a log file
            //todo clean up old log files?
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            folderPath = Path.Combine(folderPath, "SwordJet");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            folderPath = Path.Combine(folderPath, "Logs");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, logName + DateTime.Today.ToString("yyyyMMdd") + ".txt");

            using (StreamWriter stream = File.AppendText(filePath))
            {
                stream.WriteLine("");
                stream.WriteLine(DateTime.Now.ToString() + ": ");
                stream.WriteLine(textToLog);

                stream.Close();
            }
        }
    }

    public static class FileAccessHelper
    {
        public static void SaveTournament(Tournament tournament, string filePath)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Tournament));

            using (TextWriter w = new StreamWriter(filePath))
            {
                xml.Serialize(w, tournament);
                w.Close();
            }
        }

        public static Tournament LoadTournament(string filePath)
        {
            Tournament tournament = null;

            XmlSerializer xml = new XmlSerializer(typeof(Tournament));

            using (Stream s = new FileStream(filePath, FileMode.Open))
            {
                tournament = (Tournament)xml.Deserialize(s);

                s.Close();
            }

            return tournament;
        }

        public static void HEMARatingsExport(Tournament tournament, string folderPath)
        {
            StringBuilder clubCsv = new StringBuilder();

            clubCsv.AppendLine(string.Join(",", new string[] { "Name", "Country", "City", "State" }));

            foreach (Club club in tournament.clubs)
            {
                clubCsv.AppendLine(string.Join(",", new string[] { "\"" + club.name + "\"", "\"" + club.country + "\"", "\"" + club.city + "\"", "" }));
            }

            StringBuilder fighterCsv = new StringBuilder();

            fighterCsv.AppendLine(string.Join(",", new string[]{ "Name", "Club", "Nationality", "Gender", "HEMA Ratings ID" }));

            foreach(Fighter f in tournament.fighters)
            {
                fighterCsv.AppendLine(string.Join(",", new string[] { "\"" + f.name + "\"", "\"" + f.club + "\"", f.country, "Unknown", "" }));
            }

            StringBuilder fightCsv = new StringBuilder();

            fightCsv.AppendLine(string.Join(",", new string[] { "Fighter 1", "Fighter 2", "Fighter 1 Result", "Fighter 2 Result", "Round" }));

            foreach(Pool p in tournament.pools)
            {
                foreach(List<Fight> r in p.rounds)
                {
                    foreach(Fight f in r)
                    {
                        Fighter fighterA = tournament.GetFighterByID(f.fighterA);
                        Fighter fighterB = tournament.GetFighterByID(f.fighterB);
                        if(fighterB != null) fightCsv.AppendLine(string.Join(",", new string[] { "\"" + fighterA.name + "\"", "\"" + fighterB.name + "\"", (f.fighterAResult == Fight.FightResult.DQ ? "LOSS" : f.fighterAResult.ToString()), (f.fighterBResult == Fight.FightResult.DQ ? "LOSS" : f.fighterBResult.ToString()), "\"POOL - " + p.name + "\"" }));
                    }
                }
            }

            if (tournament.tieBreakers != null)
            {
                foreach (Fight f in tournament.tieBreakers.rounds[0])
                {
                    Fighter fighterA = tournament.GetFighterByID(f.fighterA);
                    Fighter fighterB = tournament.GetFighterByID(f.fighterB);
                    fightCsv.AppendLine(string.Join(",", new string[] { "\"" + fighterA.name + "\"", "\"" + fighterB.name + "\"", f.fighterAResult.ToString(), f.fighterBResult.ToString(), "Tie Breaker" }));
                }
            }

            foreach(Pool p in tournament.eliminations)
            {
                foreach (List<Fight> r in p.rounds)
                {
                    foreach (Fight f in r)
                    {
                        Fighter fighterA = tournament.GetFighterByID(f.fighterA);
                        Fighter fighterB = tournament.GetFighterByID(f.fighterB);
                        fightCsv.AppendLine(string.Join(",", new string[] { "\"" + fighterA.name + "\"", "\"" + fighterB.name + "\"", f.fighterAResult.ToString(), f.fighterBResult.ToString(), "ELIM - " + p.name }));
                    }
                }
            }

            for(int i = 0; i < 2; i++)
            {
                Fight f = tournament.finals[i];
                Fighter fighterA = tournament.GetFighterByID(f.fighterA);
                Fighter fighterB = tournament.GetFighterByID(f.fighterB);
                fightCsv.AppendLine(string.Join(",", new string[] { "\"" + fighterA.name + "\"", "\"" + fighterB.name + "\"", f.fighterAResult.ToString(), f.fighterBResult.ToString(), "FINAL - " + (i == 0 ? "BRONZE" : "GOLD") }));
            }

            string exportFolder = tournament.name + " - HEMA Ratings Export";

            Directory.CreateDirectory(Path.Combine(folderPath, exportFolder));

            File.WriteAllText(Path.Combine(folderPath, exportFolder, "clubs.csv"), clubCsv.ToString());
            File.WriteAllText(Path.Combine(folderPath, exportFolder, "fighters.csv"), fighterCsv.ToString());
            File.WriteAllText(Path.Combine(folderPath, exportFolder, "fights.csv"), fightCsv.ToString());
        }

        public static void GenerateSpreadsheet(Tournament tournament, string filePath)
        {
            List<Pool> pools = tournament.pools;

            //TODO refactor generation - outdated
            HSSFWorkbook book = new HSSFWorkbook();

            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "SwordJet";
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
                foreach (int fighterId in pool.fighters)
                {
                    Fighter fighter = tournament.fighters.Where(f => f.id == fighterId).First();
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
                foreach (List<Fight> round in pool.rounds)
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
                    foreach (Fight fight in round)
                    {
                        IRow row = sheet.CreateRow(rowIndex);

                        Fighter fighterA = tournament.fighters.Where(f => f.id == fight.fighterA).First();
                        Fighter fighterB = tournament.fighters.Where(f => f.id == fight.fighterB).First();

                        ICell cellNameFighterADoubles = row.CreateCell(row.Cells.Count);
                        cellNameFighterADoubles.CellStyle = plainStyle;
                        //update the fighter's doubles formula
                        if (fighterA.doubleFormula != "") fighterA.doubleFormula += ("+A" + (rowIndex + 1));
                        else fighterA.doubleFormula += ("A" + (rowIndex + 1));

                        ICell cellNameFighterAScore = row.CreateCell(row.Cells.Count);
                        cellNameFighterAScore.CellStyle = plainStyle;
                        //update the fighter's score formula
                        if (fighterA.scoreFormula != "") fighterA.scoreFormula += ("+B" + (rowIndex + 1));
                        else fighterA.scoreFormula += ("B" + (rowIndex + 1));

                        ICell cellNameFighterA = row.CreateCell(row.Cells.Count);
                        cellNameFighterA.SetCellValue(fighterA.name);
                        cellNameFighterA.CellStyle = plainStyle;

                        ICell cellV = row.CreateCell(row.Cells.Count);
                        cellV.SetCellValue("v");
                        cellV.CellStyle = plainCenterStyle;

                        ICell cellNameFighterB = row.CreateCell(row.Cells.Count);
                        cellNameFighterB.SetCellValue(fighterB.name);
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
                            if (fighterB.scoreFormula != "") fighterB.scoreFormula += ("+F" + (rowIndex + 1));
                            else fighterB.scoreFormula += ("F" + (rowIndex + 1));
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
                            if (fighterB.doubleFormula != "") fighterB.doubleFormula += ("+G" + (rowIndex + 1));
                            else fighterB.doubleFormula += ("G" + (rowIndex + 1));
                        }

                        rowIndex++;
                    }

                    rowIndex += 3;
                }

                //update each pool fighter score and doubles forumlae
                foreach (int fighterId in pool.fighters)
                {
                    Fighter fighter = tournament.fighters.Where(f => f.id == fighterId).First();

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

                FileStream stream = new FileStream(filePath, FileMode.Create);
                book.Write(stream);
                stream.Close();

                book.Close();
            }
        }
    }

    [Serializable]
    public class Fight
    {
        public enum FightResult { PENDING = 0, WIN = 1, DRAW = 2, LOSS = 3, DQ = 4 };

        public Guid fightID;
        public int fighterA;
        public int fighterB;
        public int doubleCount;
        public FightResult fighterAResult;
        public FightResult fighterBResult;
        public bool oddFight = false;
        public bool allowDraw = true;

        public List<Exchange> exchanges = new List<Exchange>();

        public Fight()
        {
            fighterAResult = FightResult.PENDING;
            fighterBResult = FightResult.PENDING;
            fightID = Guid.NewGuid();
        }

        public Fight(int a, int b)
        {
            fighterA = a;
            fighterB = b;
            fighterAResult = FightResult.PENDING;
            fighterBResult = FightResult.PENDING;
            fightID = Guid.NewGuid();
        }

        public bool Equals(Fight obj)
        {
            //if the two fighters are the same, the fight is equal regardless of order
            if (fighterA == obj.fighterA || fighterA == obj.fighterB)
            {
                if (fighterB == obj.fighterA || fighterB == obj.fighterB)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetResults(Tournament tournament)
        {
            int aScore = 0;
            int bScore = 0;
            int aPenalties = 0;
            int bPenalties = 0;
            doubleCount = 0;

            foreach(Exchange ex in exchanges)
            {
                aScore += ex.fighterAScore;
                aPenalties += (ex.penaltyA ? 1 : 0);
                bScore += ex.fighterBScore;
                bPenalties += (ex.penaltyB ? 1 : 0);
                if (ex.dbl) doubleCount++;
            }

            //subtract accrued penalties
            if (tournament.penaltyThreshold > 0)
            {
                aScore = Math.Max(0, (aScore - (aPenalties / tournament.penaltyThreshold)));
                bScore = Math.Max(0, (bScore - (bPenalties / tournament.penaltyThreshold)));
            }

            if (tournament.doubleThreshold != null && allowDraw && doubleCount >= tournament.doubleThreshold)
            {
                fighterAResult = FightResult.DQ;
                fighterBResult = FightResult.DQ;
            }
            else if(aScore > bScore)
            {
                fighterAResult = FightResult.WIN;
                fighterBResult = FightResult.LOSS;
            }
            else if(bScore > aScore)
            {
                fighterBResult = FightResult.WIN;
                fighterAResult = FightResult.LOSS;
            }
            else
            {
                fighterAResult = FightResult.DRAW;
                fighterBResult = FightResult.DRAW;
            }
        }

        public bool IsComplete()
        {
            return (fighterAResult != FightResult.PENDING && fighterBResult != FightResult.PENDING);
        }
    }

    [Serializable]
    public class Exchange
    {
        public int fighterAScore = 0;
        public int fighterBScore = 0;
        public bool penaltyA = false;
        public bool penaltyB = false;
        public bool dbl = false;

        public Exchange() { }

        public Exchange(int aScore, int bScore, bool dblHit, bool penA, bool penB)
        {
            fighterAScore = aScore;
            fighterBScore = bScore;
            dbl = dblHit;
            penaltyA = penA;
            penaltyB = penB;
        }

        public override string ToString()
        {
            string display = "A Score: " + fighterAScore + (penaltyA ? " (PENALTY)" : "");
            display += ", B Score: " + fighterBScore + (penaltyB ? " (PENALTY)" : "");
            if (dbl) display += " - DOUBLE";
            return display;
        }
    }

    [Serializable]
    public class Fighter
    {
        public int id;
        public string name;

        //supplemental information, may or may not be used
        public string club;
        public string country;

        //excel values
        public int[] scoreCellRef;
        public string scoreFormula = "";
        public int[] doubleCellRef;
        public string doubleFormula = "";

        public Fighter() { }

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

    [Serializable]
    public class Club
    {
        public string name;
        public string country;
        public string state;
        public string city;

        public Club()
        {

        }

        public override string ToString()
        {
            return name;
        }
    }

    public class Country
    {
        public static List<Country> Countries = new List<Country>();

        public string name;
        public string code;

        public static void LoadCountries(string csvFile)
        {
            Countries.Clear();

            using (TextFieldParser parser = new TextFieldParser(csvFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    Country c = new Country();
                    c.name = fields[0];
                    c.code = fields[1];

                    Countries.Add(c);
                }
            }
        }

        public override string ToString()
        {
            return name;
        }
    }

}
