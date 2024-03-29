﻿namespace SwordJet
{
    partial class TournamentSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentSetupForm));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClubEdit = new System.Windows.Forms.Button();
            this.ddlNationality = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblFighterCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ddlClub = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPools = new System.Windows.Forms.NumericUpDown();
            this.txtRounds = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFightTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTournamentName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLossPoints = new System.Windows.Forms.NumericUpDown();
            this.txtDrawPoints = new System.Windows.Forms.NumericUpDown();
            this.txtWinPoints = new System.Windows.Forms.NumericUpDown();
            this.txtDoubleLimit = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.chkDoubleOut = new System.Windows.Forms.CheckBox();
            this.btnManage = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlElimType = new System.Windows.Forms.ComboBox();
            this.ddlElimSize = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ddlAfterblowBehaviour = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ddlPenaltyBehaviour = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chkFinalScoreCap = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFinalScoreCap = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFinalFightTime = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPenaltyThreshold = new System.Windows.Forms.NumericUpDown();
            this.chkScoreCap = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtScoreCap = new System.Windows.Forms.NumericUpDown();
            this.ddlPoolType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lstFighters = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWinPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleLimit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalScoreCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalFightTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScoreCap)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(221, 114);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Fighter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstFighters);
            this.panel1.Controls.Add(this.btnClubEdit);
            this.panel1.Controls.Add(this.ddlNationality);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lblFighterCount);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ddlClub);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(467, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 662);
            this.panel1.TabIndex = 2;
            // 
            // btnClubEdit
            // 
            this.btnClubEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClubEdit.Location = new System.Drawing.Point(379, 39);
            this.btnClubEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClubEdit.Name = "btnClubEdit";
            this.btnClubEdit.Size = new System.Drawing.Size(31, 23);
            this.btnClubEdit.TabIndex = 15;
            this.btnClubEdit.Text = "...";
            this.btnClubEdit.UseVisualStyleBackColor = true;
            this.btnClubEdit.Click += new System.EventHandler(this.btnClubEdit_Click);
            // 
            // ddlNationality
            // 
            this.ddlNationality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlNationality.FormattingEnabled = true;
            this.ddlNationality.Location = new System.Drawing.Point(81, 71);
            this.ddlNationality.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlNationality.Name = "ddlNationality";
            this.ddlNationality.Size = new System.Drawing.Size(328, 24);
            this.ddlNationality.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(219, 630);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete Selected Fighter";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblFighterCount
            // 
            this.lblFighterCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFighterCount.AutoSize = true;
            this.lblFighterCount.Location = new System.Drawing.Point(4, 636);
            this.lblFighterCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFighterCount.Name = "lblFighterCount";
            this.lblFighterCount.Size = new System.Drawing.Size(133, 16);
            this.lblFighterCount.TabIndex = 14;
            this.lblFighterCount.Text = "Number of Fighters: 0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "Nationality";
            // 
            // ddlClub
            // 
            this.ddlClub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClub.FormattingEnabled = true;
            this.ddlClub.Location = new System.Drawing.Point(81, 39);
            this.ddlClub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlClub.Name = "ddlClub";
            this.ddlClub.Size = new System.Drawing.Size(292, 24);
            this.ddlClub.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Club";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name*";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(81, 6);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(328, 22);
            this.txtName.TabIndex = 2;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Pools";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rounds per Pool";
            // 
            // txtPools
            // 
            this.txtPools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPools.Location = new System.Drawing.Point(153, 73);
            this.txtPools.Margin = new System.Windows.Forms.Padding(4);
            this.txtPools.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPools.Name = "txtPools";
            this.txtPools.Size = new System.Drawing.Size(291, 22);
            this.txtPools.TabIndex = 5;
            this.txtPools.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPools.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // txtRounds
            // 
            this.txtRounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRounds.Location = new System.Drawing.Point(153, 103);
            this.txtRounds.Margin = new System.Windows.Forms.Padding(4);
            this.txtRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRounds.Name = "txtRounds";
            this.txtRounds.Size = new System.Drawing.Size(292, 22);
            this.txtRounds.TabIndex = 6;
            this.txtRounds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRounds.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 350);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fight time (minutes)";
            // 
            // txtFightTime
            // 
            this.txtFightTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFightTime.Location = new System.Drawing.Point(156, 345);
            this.txtFightTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtFightTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtFightTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFightTime.Name = "txtFightTime";
            this.txtFightTime.Size = new System.Drawing.Size(48, 22);
            this.txtFightTime.TabIndex = 13;
            this.txtFightTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFightTime.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tournament Name";
            // 
            // txtTournamentName
            // 
            this.txtTournamentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTournamentName.Location = new System.Drawing.Point(153, 11);
            this.txtTournamentName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTournamentName.Name = "txtTournamentName";
            this.txtTournamentName.Size = new System.Drawing.Size(292, 22);
            this.txtTournamentName.TabIndex = 16;
            this.txtTournamentName.TextChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Win Points";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Draw Points";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Loss Points";
            // 
            // txtLossPoints
            // 
            this.txtLossPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLossPoints.Location = new System.Drawing.Point(153, 256);
            this.txtLossPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtLossPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLossPoints.Name = "txtLossPoints";
            this.txtLossPoints.Size = new System.Drawing.Size(288, 22);
            this.txtLossPoints.TabIndex = 22;
            this.txtLossPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLossPoints.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // txtDrawPoints
            // 
            this.txtDrawPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDrawPoints.Location = new System.Drawing.Point(153, 225);
            this.txtDrawPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtDrawPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDrawPoints.Name = "txtDrawPoints";
            this.txtDrawPoints.Size = new System.Drawing.Size(288, 22);
            this.txtDrawPoints.TabIndex = 23;
            this.txtDrawPoints.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.txtDrawPoints.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // txtWinPoints
            // 
            this.txtWinPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWinPoints.Location = new System.Drawing.Point(153, 196);
            this.txtWinPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtWinPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtWinPoints.Name = "txtWinPoints";
            this.txtWinPoints.Size = new System.Drawing.Size(288, 22);
            this.txtWinPoints.TabIndex = 24;
            this.txtWinPoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtWinPoints.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // txtDoubleLimit
            // 
            this.txtDoubleLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDoubleLimit.Location = new System.Drawing.Point(158, 434);
            this.txtDoubleLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoubleLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDoubleLimit.Name = "txtDoubleLimit";
            this.txtDoubleLimit.Size = new System.Drawing.Size(48, 22);
            this.txtDoubleLimit.TabIndex = 26;
            this.txtDoubleLimit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtDoubleLimit.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 436);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Double DQ Threshold";
            // 
            // chkDoubleOut
            // 
            this.chkDoubleOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDoubleOut.AutoSize = true;
            this.chkDoubleOut.Location = new System.Drawing.Point(12, 406);
            this.chkDoubleOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkDoubleOut.Name = "chkDoubleOut";
            this.chkDoubleOut.Size = new System.Drawing.Size(293, 20);
            this.chkDoubleOut.TabIndex = 27;
            this.chkDoubleOut.Text = "DQ On Doubles? (only applies to Pool fights)";
            this.chkDoubleOut.UseVisualStyleBackColor = true;
            this.chkDoubleOut.CheckedChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // btnManage
            // 
            this.btnManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManage.Location = new System.Drawing.Point(11, 580);
            this.btnManage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(429, 76);
            this.btnManage.TabIndex = 28;
            this.btnManage.Text = "Manage Tournament";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "Eliminations Type";
            // 
            // ddlElimType
            // 
            this.ddlElimType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlElimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlElimType.FormattingEnabled = true;
            this.ddlElimType.Location = new System.Drawing.Point(153, 165);
            this.ddlElimType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlElimType.Name = "ddlElimType";
            this.ddlElimType.Size = new System.Drawing.Size(288, 24);
            this.ddlElimType.TabIndex = 30;
            this.ddlElimType.SelectedIndexChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // ddlElimSize
            // 
            this.ddlElimSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlElimSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlElimSize.FormattingEnabled = true;
            this.ddlElimSize.Location = new System.Drawing.Point(153, 131);
            this.ddlElimSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlElimSize.Name = "ddlElimSize";
            this.ddlElimSize.Size = new System.Drawing.Size(288, 24);
            this.ddlElimSize.TabIndex = 32;
            this.ddlElimSize.SelectedIndexChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Eliminations Size";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.ddlAfterblowBehaviour);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.ddlPenaltyBehaviour);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.chkFinalScoreCap);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtFinalScoreCap);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.txtFinalFightTime);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtPenaltyThreshold);
            this.panel2.Controls.Add(this.chkScoreCap);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtScoreCap);
            this.panel2.Controls.Add(this.txtTournamentName);
            this.panel2.Controls.Add(this.ddlPoolType);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnManage);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.chkDoubleOut);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtRounds);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtPools);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtDoubleLimit);
            this.panel2.Controls.Add(this.ddlElimSize);
            this.panel2.Controls.Add(this.ddlElimType);
            this.panel2.Controls.Add(this.txtLossPoints);
            this.panel2.Controls.Add(this.txtDrawPoints);
            this.panel2.Controls.Add(this.txtWinPoints);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtFightTime);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 662);
            this.panel2.TabIndex = 33;
            // 
            // ddlAfterblowBehaviour
            // 
            this.ddlAfterblowBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlAfterblowBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAfterblowBehaviour.FormattingEnabled = true;
            this.ddlAfterblowBehaviour.Location = new System.Drawing.Point(153, 487);
            this.ddlAfterblowBehaviour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlAfterblowBehaviour.Name = "ddlAfterblowBehaviour";
            this.ddlAfterblowBehaviour.Size = new System.Drawing.Size(284, 24);
            this.ddlAfterblowBehaviour.TabIndex = 55;
            this.ddlAfterblowBehaviour.SelectedIndexChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 490);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 16);
            this.label20.TabIndex = 54;
            this.label20.Text = "Afterblow Behaviour";
            // 
            // ddlPenaltyBehaviour
            // 
            this.ddlPenaltyBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlPenaltyBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPenaltyBehaviour.FormattingEnabled = true;
            this.ddlPenaltyBehaviour.Location = new System.Drawing.Point(153, 546);
            this.ddlPenaltyBehaviour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlPenaltyBehaviour.Name = "ddlPenaltyBehaviour";
            this.ddlPenaltyBehaviour.Size = new System.Drawing.Size(284, 24);
            this.ddlPenaltyBehaviour.TabIndex = 53;
            this.ddlPenaltyBehaviour.SelectedIndexChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 549);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 16);
            this.label18.TabIndex = 52;
            this.label18.Text = "Penalty Behaviour";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(254, 292);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 16);
            this.label22.TabIndex = 51;
            this.label22.Text = "Final Fight Config";
            // 
            // chkFinalScoreCap
            // 
            this.chkFinalScoreCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFinalScoreCap.AutoSize = true;
            this.chkFinalScoreCap.Location = new System.Drawing.Point(228, 324);
            this.chkFinalScoreCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkFinalScoreCap.Name = "chkFinalScoreCap";
            this.chkFinalScoreCap.Size = new System.Drawing.Size(138, 20);
            this.chkFinalScoreCap.TabIndex = 48;
            this.chkFinalScoreCap.Text = "Apply Score Cap?";
            this.chkFinalScoreCap.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(220, 377);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 16);
            this.label19.TabIndex = 46;
            this.label19.Text = "Score Threshold";
            // 
            // txtFinalScoreCap
            // 
            this.txtFinalScoreCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinalScoreCap.Location = new System.Drawing.Point(363, 375);
            this.txtFinalScoreCap.Margin = new System.Windows.Forms.Padding(4);
            this.txtFinalScoreCap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFinalScoreCap.Name = "txtFinalScoreCap";
            this.txtFinalScoreCap.Size = new System.Drawing.Size(81, 22);
            this.txtFinalScoreCap.TabIndex = 47;
            this.txtFinalScoreCap.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtFinalScoreCap.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(220, 350);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(121, 16);
            this.label21.TabIndex = 41;
            this.label21.Text = "Fight time (minutes)";
            // 
            // txtFinalFightTime
            // 
            this.txtFinalFightTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinalFightTime.Location = new System.Drawing.Point(364, 348);
            this.txtFinalFightTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtFinalFightTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtFinalFightTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFinalFightTime.Name = "txtFinalFightTime";
            this.txtFinalFightTime.Size = new System.Drawing.Size(81, 22);
            this.txtFinalFightTime.TabIndex = 42;
            this.txtFinalFightTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFinalFightTime.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(47, 292);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 16);
            this.label17.TabIndex = 40;
            this.label17.Text = "General Fight Config";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 519);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 16);
            this.label16.TabIndex = 38;
            this.label16.Text = "Penalty Threshold";
            // 
            // txtPenaltyThreshold
            // 
            this.txtPenaltyThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPenaltyThreshold.Location = new System.Drawing.Point(153, 517);
            this.txtPenaltyThreshold.Margin = new System.Windows.Forms.Padding(4);
            this.txtPenaltyThreshold.Name = "txtPenaltyThreshold";
            this.txtPenaltyThreshold.Size = new System.Drawing.Size(284, 22);
            this.txtPenaltyThreshold.TabIndex = 39;
            this.txtPenaltyThreshold.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // chkScoreCap
            // 
            this.chkScoreCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkScoreCap.AutoSize = true;
            this.chkScoreCap.Location = new System.Drawing.Point(14, 325);
            this.chkScoreCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkScoreCap.Name = "chkScoreCap";
            this.chkScoreCap.Size = new System.Drawing.Size(138, 20);
            this.chkScoreCap.TabIndex = 37;
            this.chkScoreCap.Text = "Apply Score Cap?";
            this.chkScoreCap.UseVisualStyleBackColor = true;
            this.chkScoreCap.CheckedChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 377);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 16);
            this.label15.TabIndex = 35;
            this.label15.Text = "Score Threshold";
            // 
            // txtScoreCap
            // 
            this.txtScoreCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtScoreCap.Location = new System.Drawing.Point(156, 374);
            this.txtScoreCap.Margin = new System.Windows.Forms.Padding(4);
            this.txtScoreCap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtScoreCap.Name = "txtScoreCap";
            this.txtScoreCap.Size = new System.Drawing.Size(48, 22);
            this.txtScoreCap.TabIndex = 36;
            this.txtScoreCap.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtScoreCap.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // ddlPoolType
            // 
            this.ddlPoolType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlPoolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPoolType.FormattingEnabled = true;
            this.ddlPoolType.Location = new System.Drawing.Point(153, 42);
            this.ddlPoolType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlPoolType.Name = "ddlPoolType";
            this.ddlPoolType.Size = new System.Drawing.Size(288, 24);
            this.ddlPoolType.TabIndex = 34;
            this.ddlPoolType.SelectedIndexChanged += new System.EventHandler(this.ddlPoolType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 46);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 33;
            this.label12.Text = "Pool Type";
            // 
            // lstFighters
            // 
            this.lstFighters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFighters.FormattingEnabled = true;
            this.lstFighters.Location = new System.Drawing.Point(7, 151);
            this.lstFighters.Name = "lstFighters";
            this.lstFighters.Size = new System.Drawing.Size(402, 463);
            this.lstFighters.TabIndex = 8;
            this.lstFighters.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFighters_onCheck);
            // 
            // TournamentSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 686);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TournamentSetupForm";
            this.Text = "Tournament Setup";
            this.Activated += new System.EventHandler(this.TournamentSetupForm_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWinPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleLimit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalScoreCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalFightTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScoreCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtPools;
        private System.Windows.Forms.NumericUpDown txtRounds;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtFightTime;
        private System.Windows.Forms.Label lblFighterCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTournamentName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtLossPoints;
        private System.Windows.Forms.NumericUpDown txtDrawPoints;
        private System.Windows.Forms.NumericUpDown txtWinPoints;
        private System.Windows.Forms.NumericUpDown txtDoubleLimit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDoubleOut;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlElimType;
        private System.Windows.Forms.ComboBox ddlElimSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ddlPoolType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddlNationality;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ddlClub;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClubEdit;
        private System.Windows.Forms.CheckBox chkScoreCap;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown txtScoreCap;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown txtPenaltyThreshold;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkFinalScoreCap;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown txtFinalScoreCap;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown txtFinalFightTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox ddlPenaltyBehaviour;
        private System.Windows.Forms.ComboBox ddlAfterblowBehaviour;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckedListBox lstFighters;
    }
}

