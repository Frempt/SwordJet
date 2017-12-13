namespace SwordJet
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
            this.lstFighters = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPools = new System.Windows.Forms.NumericUpDown();
            this.txtRounds = new System.Windows.Forms.NumericUpDown();
            this.lblLengthMessage = new System.Windows.Forms.Label();
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
            this.ddlPoolType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWinPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleLimit)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(222, 115);
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
            this.panel1.Controls.Add(this.btnClubEdit);
            this.panel1.Controls.Add(this.ddlNationality);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lblFighterCount);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ddlClub);
            this.panel1.Controls.Add(this.lstFighters);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(466, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 515);
            this.panel1.TabIndex = 2;
            // 
            // btnClubEdit
            // 
            this.btnClubEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClubEdit.Location = new System.Drawing.Point(379, 39);
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
            this.ddlNationality.Location = new System.Drawing.Point(81, 72);
            this.ddlNationality.Name = "ddlNationality";
            this.ddlNationality.Size = new System.Drawing.Size(328, 24);
            this.ddlNationality.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(218, 483);
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
            this.lblFighterCount.Location = new System.Drawing.Point(4, 489);
            this.lblFighterCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFighterCount.Name = "lblFighterCount";
            this.lblFighterCount.Size = new System.Drawing.Size(145, 17);
            this.lblFighterCount.TabIndex = 14;
            this.lblFighterCount.Text = "Number of Fighters: 0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 17);
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
            this.ddlClub.Name = "ddlClub";
            this.ddlClub.Size = new System.Drawing.Size(292, 24);
            this.ddlClub.TabIndex = 5;
            // 
            // lstFighters
            // 
            this.lstFighters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFighters.FormattingEnabled = true;
            this.lstFighters.ItemHeight = 16;
            this.lstFighters.Location = new System.Drawing.Point(4, 151);
            this.lstFighters.Margin = new System.Windows.Forms.Padding(4);
            this.lstFighters.Name = "lstFighters";
            this.lstFighters.Size = new System.Drawing.Size(405, 324);
            this.lstFighters.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Club";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
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
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Pools";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
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
            // lblLengthMessage
            // 
            this.lblLengthMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLengthMessage.AutoEllipsis = true;
            this.lblLengthMessage.Location = new System.Drawing.Point(6, 163);
            this.lblLengthMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLengthMessage.Name = "lblLengthMessage";
            this.lblLengthMessage.Size = new System.Drawing.Size(437, 64);
            this.lblLengthMessage.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fight time (minutes)";
            // 
            // txtFightTime
            // 
            this.txtFightTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFightTime.Location = new System.Drawing.Point(153, 129);
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
            this.txtFightTime.Size = new System.Drawing.Size(291, 22);
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
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tournament Name";
            // 
            // txtTournamentName
            // 
            this.txtTournamentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTournamentName.Location = new System.Drawing.Point(153, 11);
            this.txtTournamentName.Name = "txtTournamentName";
            this.txtTournamentName.Size = new System.Drawing.Size(292, 22);
            this.txtTournamentName.TabIndex = 16;
            this.txtTournamentName.TextChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Win Points";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Draw Points";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Loss Points";
            // 
            // txtLossPoints
            // 
            this.txtLossPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLossPoints.Location = new System.Drawing.Point(153, 360);
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
            this.txtDrawPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDrawPoints.Location = new System.Drawing.Point(153, 330);
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
            this.txtWinPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWinPoints.Location = new System.Drawing.Point(153, 300);
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
            this.txtDoubleLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoubleLimit.Location = new System.Drawing.Point(303, 390);
            this.txtDoubleLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txtDoubleLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDoubleLimit.Name = "txtDoubleLimit";
            this.txtDoubleLimit.Size = new System.Drawing.Size(138, 22);
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
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Double Threshold";
            // 
            // chkDoubleOut
            // 
            this.chkDoubleOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDoubleOut.AutoSize = true;
            this.chkDoubleOut.Location = new System.Drawing.Point(12, 390);
            this.chkDoubleOut.Name = "chkDoubleOut";
            this.chkDoubleOut.Size = new System.Drawing.Size(138, 21);
            this.chkDoubleOut.TabIndex = 27;
            this.chkDoubleOut.Text = "DQ On Doubles?";
            this.chkDoubleOut.UseVisualStyleBackColor = true;
            this.chkDoubleOut.CheckedChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // btnManage
            // 
            this.btnManage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManage.Location = new System.Drawing.Point(11, 433);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(430, 76);
            this.btnManage.TabIndex = 28;
            this.btnManage.Text = "Manage Tournament";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Eliminations Type";
            // 
            // ddlElimType
            // 
            this.ddlElimType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlElimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlElimType.FormattingEnabled = true;
            this.ddlElimType.Location = new System.Drawing.Point(153, 264);
            this.ddlElimType.Name = "ddlElimType";
            this.ddlElimType.Size = new System.Drawing.Size(288, 24);
            this.ddlElimType.TabIndex = 30;
            this.ddlElimType.SelectedIndexChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // ddlElimSize
            // 
            this.ddlElimSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlElimSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlElimSize.FormattingEnabled = true;
            this.ddlElimSize.Location = new System.Drawing.Point(153, 230);
            this.ddlElimSize.Name = "ddlElimSize";
            this.ddlElimSize.Size = new System.Drawing.Size(288, 24);
            this.ddlElimSize.TabIndex = 32;
            this.ddlElimSize.SelectedIndexChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "Eliminations Size";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.panel2.Controls.Add(this.lblLengthMessage);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 515);
            this.panel2.TabIndex = 33;
            // 
            // ddlPoolType
            // 
            this.ddlPoolType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlPoolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPoolType.FormattingEnabled = true;
            this.ddlPoolType.Location = new System.Drawing.Point(153, 42);
            this.ddlPoolType.Name = "ddlPoolType";
            this.ddlPoolType.Size = new System.Drawing.Size(288, 24);
            this.ddlPoolType.TabIndex = 34;
            this.ddlPoolType.SelectedIndexChanged += new System.EventHandler(this.ddlPoolType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 45);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "Pool Type";
            // 
            // TournamentSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 539);
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
        private System.Windows.Forms.ListBox lstFighters;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblLengthMessage;
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
    }
}

