using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwordJet
{
    public partial class ManageFight : Form
    {
        public Fight fight = null;
        public int timeRemainingSeconds = 0;
        public Tournament tournament = null;
        public bool allowDraw = true;
        public bool isFinal = false;

        public bool ended = false;

        private bool suddenDeath = false;
        private int aScore = 0;
        private int bScore = 0;
        private int doubleCount = 0;

        public ManageFight(Fight fightToManage, Tournament tournamentToManage, bool draw = true, bool final = false)
        {
            InitializeComponent();

            fight = fightToManage;
            tournament = tournamentToManage;
            allowDraw = draw;
            isFinal = final;

            lblFighterAName.Text = tournament.GetFighterByID(fight.fighterA).name;
            lblFighterBName.Text = tournament.GetFighterByID(fight.fighterB).name;

            //ensure the fight isn't already complete
            if (fight.fighterAResult == Fight.FightResult.PENDING || fight.fighterBResult == Fight.FightResult.PENDING)
            {
                timeRemainingSeconds = (isFinal ? tournament.fightTimeMinutesFinal : tournament.fightTimeMinutes) * 60;

                UpdateTimeDisplay();

                LoadExchanges();
            }
            else
            {
                Close();
            }
        }

        private void UpdateTimeDisplay()
        {
            string display = "";

            if(timeRemainingSeconds < 60)
            {
                display = "0:" + ((timeRemainingSeconds < 10) ? "0" : "") + timeRemainingSeconds.ToString();
            }
            else
            {
                display = (timeRemainingSeconds / 60).ToString();
                display += ":";
                display += ((timeRemainingSeconds % 60 < 10) ? "0" : "") + (timeRemainingSeconds % 60).ToString();
            }

            lblRemainingTime.Text = display;
        }

        private void LoadExchanges()
        {
            lbExchanges.DataSource = null;
            lbExchanges.DataSource = fight.exchanges;

            UpdateCurrentResultText();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeRemainingSeconds -= (timer.Interval / 1000);

            if(timeRemainingSeconds < 10)
            {
                lblRemainingTime.ForeColor = Color.Red;
            }

            if(timeRemainingSeconds <= 0)
            {
                timer.Stop();
                btnStopStart.Enabled = false;
                timeRemainingSeconds = 0;
            }

            UpdateTimeDisplay();
        }

        private void UpdateCurrentResultText()
        {
            aScore = 0;
            bScore = 0;
            int aPenalties = 0;
            int bPenalties = 0;
            doubleCount = 0;

            foreach (Exchange ex in fight.exchanges)
            {
                aScore += ex.fighterAScore;
                aPenalties += (ex.penaltyA ? 1 : 0);
                bScore += ex.fighterBScore;
                bPenalties += (ex.penaltyB ? 1 : 0);
                if (ex.dbl) doubleCount++;
            }

            //subtract accrued penalties
            if (tournament.penaltyThreshold > 0 && tournament.penaltyBehaviour == Tournament.PenaltyBehaviour.SUBTRACTSCORE)
            {
                aScore = Math.Max(0, (aScore - (aPenalties / tournament.penaltyThreshold)));
                bScore = Math.Max(0, (bScore - (bPenalties / tournament.penaltyThreshold)));
            }

            string resultText = "A Score: " + aScore;
            resultText += ", B Score: " + bScore;
            resultText += ", Doubles: " + doubleCount;

            lblCurrentResult.Text = resultText;

            if(tournament.doubleThreshold != null && doubleCount >= tournament.doubleThreshold && allowDraw)
            {
                lblCurrentResult.Text = "Double Threshold reached - fighters disqualified";
                ShowConclusionMessage();
            }

            if(aScore >= (isFinal ? tournament.scoreThresholdFinal : tournament.scoreThreshold) 
                || bScore >= (isFinal ? tournament.scoreThresholdFinal : tournament.scoreThreshold)
                || (suddenDeath && aScore != bScore))
            {
                ShowConclusionMessage();
            }
        }

        private void btnStopStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                btnStopStart.Text = "Start time";
            }
            else
            {
                timer.Start();
                btnStopStart.Text = "Stop time";
            }
        }

        private void btnAddExchange_Click(object sender, EventArgs e)
        {
            int fighterAScore = (int)txtFighterAScore.Value;
            int fighterBScore = (int)txtFighterBScore.Value;

            if (fighterAScore > 0 && fighterBScore > 0)
            {
                if(tournament.afterblowBehaviour == Tournament.AfterblowBehaviour.NOSCORE)
                {
                    fighterAScore = 0;
                    fighterBScore = 0;
                }
                else if(tournament.afterblowBehaviour == Tournament.AfterblowBehaviour.WEIGHTSCORE)
                {
                    fighterAScore = Math.Max(0, (int)(txtFighterAScore.Value - txtFighterBScore.Value));
                    fighterBScore = Math.Max(0, (int)(txtFighterBScore.Value - txtFighterAScore.Value));
                }
            }

            Exchange exchange = new Exchange(fighterAScore, fighterBScore, chkDouble.Checked, chkPenaltyA.Checked, chkPenaltyB.Checked);
            fight.exchanges.Add(exchange);

            txtFighterAScore.Value = 0;
            txtFighterBScore.Value = 0;
            chkDouble.Checked = false;
            chkPenaltyA.Checked = false;
            chkPenaltyB.Checked = false;

            LoadExchanges();
        }

        private void btnDeleteExchange_Click(object sender, EventArgs e)
        {
            if(lbExchanges.SelectedIndex >= 0)
            {
                fight.exchanges.RemoveAt(lbExchanges.SelectedIndex);
                LoadExchanges();
            }
        }

        private void ShowConclusionMessage()
        {
            MessageBox.Show(lblCurrentResult.Text, (aScore > bScore ? "Winner: " + lblFighterAName.Text : (bScore > aScore) ? "Winner: " + lblFighterBName.Text : "Draw"));
            ended = true;
            Close();
        }

        private void btnEndFight_Click(object sender, EventArgs e)
        {
            if(aScore > bScore || bScore > aScore || allowDraw)
            {
                ShowConclusionMessage();
            }
            else
            {
                MessageBox.Show("SUDDEN DEATH!");
                suddenDeath = true;
            }
        }
    }
}
