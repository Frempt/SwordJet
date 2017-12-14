namespace SwordJet
{
    partial class ManageFight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblRemainingTime = new System.Windows.Forms.Label();
            this.btnStopStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFighterAName = new System.Windows.Forms.Label();
            this.lblFighterBName = new System.Windows.Forms.Label();
            this.txtFighterAScore = new System.Windows.Forms.NumericUpDown();
            this.txtFighterBScore = new System.Windows.Forms.NumericUpDown();
            this.chkDouble = new System.Windows.Forms.CheckBox();
            this.btnAddExchange = new System.Windows.Forms.Button();
            this.pnlNewExchange = new System.Windows.Forms.Panel();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.btnEndFight = new System.Windows.Forms.Button();
            this.pnlExchangeList = new System.Windows.Forms.Panel();
            this.lblCurrentResult = new System.Windows.Forms.Label();
            this.btnDeleteExchange = new System.Windows.Forms.Button();
            this.lbExchanges = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtFighterAScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFighterBScore)).BeginInit();
            this.pnlNewExchange.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            this.pnlExchangeList.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblRemainingTime
            // 
            this.lblRemainingTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainingTime.AutoSize = true;
            this.lblRemainingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTime.Location = new System.Drawing.Point(146, 3);
            this.lblRemainingTime.Name = "lblRemainingTime";
            this.lblRemainingTime.Size = new System.Drawing.Size(0, 29);
            this.lblRemainingTime.TabIndex = 0;
            this.lblRemainingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStopStart
            // 
            this.btnStopStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopStart.Location = new System.Drawing.Point(40, 58);
            this.btnStopStart.Name = "btnStopStart";
            this.btnStopStart.Size = new System.Drawing.Size(108, 39);
            this.btnStopStart.TabIndex = 1;
            this.btnStopStart.Text = "Begin Time";
            this.btnStopStart.UseVisualStyleBackColor = true;
            this.btnStopStart.Click += new System.EventHandler(this.btnStopStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fighter A";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fighter B";
            // 
            // lblFighterAName
            // 
            this.lblFighterAName.AutoSize = true;
            this.lblFighterAName.Location = new System.Drawing.Point(12, 56);
            this.lblFighterAName.Name = "lblFighterAName";
            this.lblFighterAName.Size = new System.Drawing.Size(0, 17);
            this.lblFighterAName.TabIndex = 4;
            // 
            // lblFighterBName
            // 
            this.lblFighterBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFighterBName.AutoSize = true;
            this.lblFighterBName.Location = new System.Drawing.Point(230, 56);
            this.lblFighterBName.Name = "lblFighterBName";
            this.lblFighterBName.Size = new System.Drawing.Size(0, 17);
            this.lblFighterBName.TabIndex = 5;
            // 
            // txtFighterAScore
            // 
            this.txtFighterAScore.Location = new System.Drawing.Point(15, 94);
            this.txtFighterAScore.Name = "txtFighterAScore";
            this.txtFighterAScore.Size = new System.Drawing.Size(87, 22);
            this.txtFighterAScore.TabIndex = 6;
            // 
            // txtFighterBScore
            // 
            this.txtFighterBScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFighterBScore.Location = new System.Drawing.Point(247, 93);
            this.txtFighterBScore.Name = "txtFighterBScore";
            this.txtFighterBScore.Size = new System.Drawing.Size(87, 22);
            this.txtFighterBScore.TabIndex = 7;
            // 
            // chkDouble
            // 
            this.chkDouble.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDouble.AutoSize = true;
            this.chkDouble.Location = new System.Drawing.Point(136, 94);
            this.chkDouble.Name = "chkDouble";
            this.chkDouble.Size = new System.Drawing.Size(83, 21);
            this.chkDouble.TabIndex = 8;
            this.chkDouble.Text = "Double?";
            this.chkDouble.UseVisualStyleBackColor = true;
            // 
            // btnAddExchange
            // 
            this.btnAddExchange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExchange.Location = new System.Drawing.Point(118, 151);
            this.btnAddExchange.Name = "btnAddExchange";
            this.btnAddExchange.Size = new System.Drawing.Size(112, 37);
            this.btnAddExchange.TabIndex = 9;
            this.btnAddExchange.Text = "Add Exchange";
            this.btnAddExchange.UseVisualStyleBackColor = true;
            this.btnAddExchange.Click += new System.EventHandler(this.btnAddExchange_Click);
            // 
            // pnlNewExchange
            // 
            this.pnlNewExchange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNewExchange.Controls.Add(this.label1);
            this.pnlNewExchange.Controls.Add(this.lblFighterBName);
            this.pnlNewExchange.Controls.Add(this.chkDouble);
            this.pnlNewExchange.Controls.Add(this.lblFighterAName);
            this.pnlNewExchange.Controls.Add(this.btnAddExchange);
            this.pnlNewExchange.Controls.Add(this.txtFighterBScore);
            this.pnlNewExchange.Controls.Add(this.txtFighterAScore);
            this.pnlNewExchange.Controls.Add(this.label2);
            this.pnlNewExchange.Location = new System.Drawing.Point(12, 120);
            this.pnlNewExchange.Name = "pnlNewExchange";
            this.pnlNewExchange.Size = new System.Drawing.Size(345, 206);
            this.pnlNewExchange.TabIndex = 10;
            // 
            // pnlTimer
            // 
            this.pnlTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimer.Controls.Add(this.btnEndFight);
            this.pnlTimer.Controls.Add(this.lblRemainingTime);
            this.pnlTimer.Controls.Add(this.btnStopStart);
            this.pnlTimer.Location = new System.Drawing.Point(12, 9);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(345, 100);
            this.pnlTimer.TabIndex = 11;
            // 
            // btnEndFight
            // 
            this.btnEndFight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndFight.Location = new System.Drawing.Point(219, 58);
            this.btnEndFight.Name = "btnEndFight";
            this.btnEndFight.Size = new System.Drawing.Size(115, 39);
            this.btnEndFight.TabIndex = 2;
            this.btnEndFight.Text = "End Fight";
            this.btnEndFight.UseVisualStyleBackColor = true;
            this.btnEndFight.Click += new System.EventHandler(this.btnEndFight_Click);
            // 
            // pnlExchangeList
            // 
            this.pnlExchangeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExchangeList.Controls.Add(this.lblCurrentResult);
            this.pnlExchangeList.Controls.Add(this.btnDeleteExchange);
            this.pnlExchangeList.Controls.Add(this.lbExchanges);
            this.pnlExchangeList.Location = new System.Drawing.Point(363, 12);
            this.pnlExchangeList.Name = "pnlExchangeList";
            this.pnlExchangeList.Size = new System.Drawing.Size(346, 314);
            this.pnlExchangeList.TabIndex = 12;
            // 
            // lblCurrentResult
            // 
            this.lblCurrentResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentResult.AutoSize = true;
            this.lblCurrentResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentResult.Location = new System.Drawing.Point(3, 10);
            this.lblCurrentResult.Name = "lblCurrentResult";
            this.lblCurrentResult.Size = new System.Drawing.Size(0, 17);
            this.lblCurrentResult.TabIndex = 2;
            // 
            // btnDeleteExchange
            // 
            this.btnDeleteExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteExchange.Location = new System.Drawing.Point(112, 268);
            this.btnDeleteExchange.Name = "btnDeleteExchange";
            this.btnDeleteExchange.Size = new System.Drawing.Size(231, 35);
            this.btnDeleteExchange.TabIndex = 1;
            this.btnDeleteExchange.Text = "Delete Selected";
            this.btnDeleteExchange.UseVisualStyleBackColor = true;
            this.btnDeleteExchange.Click += new System.EventHandler(this.btnDeleteExchange_Click);
            // 
            // lbExchanges
            // 
            this.lbExchanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExchanges.FormattingEnabled = true;
            this.lbExchanges.ItemHeight = 16;
            this.lbExchanges.Location = new System.Drawing.Point(3, 45);
            this.lbExchanges.Name = "lbExchanges";
            this.lbExchanges.Size = new System.Drawing.Size(340, 212);
            this.lbExchanges.TabIndex = 0;
            // 
            // ManageFight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 338);
            this.Controls.Add(this.pnlExchangeList);
            this.Controls.Add(this.pnlNewExchange);
            this.Controls.Add(this.pnlTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ManageFight";
            this.Text = "Manage Fight";
            ((System.ComponentModel.ISupportInitialize)(this.txtFighterAScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFighterBScore)).EndInit();
            this.pnlNewExchange.ResumeLayout(false);
            this.pnlNewExchange.PerformLayout();
            this.pnlTimer.ResumeLayout(false);
            this.pnlTimer.PerformLayout();
            this.pnlExchangeList.ResumeLayout(false);
            this.pnlExchangeList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblRemainingTime;
        private System.Windows.Forms.Button btnStopStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFighterAName;
        private System.Windows.Forms.Label lblFighterBName;
        private System.Windows.Forms.NumericUpDown txtFighterAScore;
        private System.Windows.Forms.NumericUpDown txtFighterBScore;
        private System.Windows.Forms.CheckBox chkDouble;
        private System.Windows.Forms.Button btnAddExchange;
        private System.Windows.Forms.Panel pnlNewExchange;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.Panel pnlExchangeList;
        private System.Windows.Forms.ListBox lbExchanges;
        private System.Windows.Forms.Button btnDeleteExchange;
        private System.Windows.Forms.Button btnEndFight;
        private System.Windows.Forms.Label lblCurrentResult;
    }
}