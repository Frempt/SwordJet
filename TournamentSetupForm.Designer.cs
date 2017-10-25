namespace TournamentGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPools = new System.Windows.Forms.NumericUpDown();
            this.txtRounds = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstFighters = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblLengthMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFightTime = new System.Windows.Forms.NumericUpDown();
            this.lblFighterCount = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWinPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(334, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(17, 395);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 41);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtName.Location = new System.Drawing.Point(59, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 22);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Pools";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rounds per Pool";
            // 
            // txtPools
            // 
            this.txtPools.Location = new System.Drawing.Point(165, 49);
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
            this.txtRounds.Location = new System.Drawing.Point(165, 88);
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
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(335, 118);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 28);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "Generate Pools";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstFighters
            // 
            this.lstFighters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFighters.FormattingEnabled = true;
            this.lstFighters.ItemHeight = 16;
            this.lstFighters.Location = new System.Drawing.Point(17, 443);
            this.lstFighters.Margin = new System.Windows.Forms.Padding(4);
            this.lstFighters.Name = "lstFighters";
            this.lstFighters.Size = new System.Drawing.Size(437, 276);
            this.lstFighters.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(351, 727);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblLengthMessage
            // 
            this.lblLengthMessage.AutoEllipsis = true;
            this.lblLengthMessage.Location = new System.Drawing.Point(21, 180);
            this.lblLengthMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLengthMessage.Name = "lblLengthMessage";
            this.lblLengthMessage.Size = new System.Drawing.Size(437, 82);
            this.lblLengthMessage.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fight time (minutes)";
            // 
            // txtFightTime
            // 
            this.txtFightTime.Location = new System.Drawing.Point(169, 154);
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
            this.txtFightTime.Size = new System.Drawing.Size(288, 22);
            this.txtFightTime.TabIndex = 13;
            this.txtFightTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtFightTime.ValueChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // lblFighterCount
            // 
            this.lblFighterCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFighterCount.AutoSize = true;
            this.lblFighterCount.Location = new System.Drawing.Point(21, 733);
            this.lblFighterCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFighterCount.Name = "lblFighterCount";
            this.lblFighterCount.Size = new System.Drawing.Size(145, 17);
            this.lblFighterCount.TabIndex = 14;
            this.lblFighterCount.Text = "Number of Fighters: 0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tournament Name";
            // 
            // txtTournamentName
            // 
            this.txtTournamentName.Location = new System.Drawing.Point(165, 20);
            this.txtTournamentName.Name = "txtTournamentName";
            this.txtTournamentName.Size = new System.Drawing.Size(292, 22);
            this.txtTournamentName.TabIndex = 16;
            this.txtTournamentName.TextChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Win Points";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Draw Points";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Loss Points";
            // 
            // txtLossPoints
            // 
            this.txtLossPoints.Location = new System.Drawing.Point(162, 326);
            this.txtLossPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtLossPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLossPoints.Name = "txtLossPoints";
            this.txtLossPoints.Size = new System.Drawing.Size(291, 22);
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
            this.txtDrawPoints.Location = new System.Drawing.Point(162, 298);
            this.txtDrawPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtDrawPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDrawPoints.Name = "txtDrawPoints";
            this.txtDrawPoints.Size = new System.Drawing.Size(291, 22);
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
            this.txtWinPoints.Location = new System.Drawing.Point(162, 269);
            this.txtWinPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtWinPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtWinPoints.Name = "txtWinPoints";
            this.txtWinPoints.Size = new System.Drawing.Size(291, 22);
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
            this.txtDoubleLimit.Location = new System.Drawing.Point(315, 356);
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
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Double Threshold";
            // 
            // chkDoubleOut
            // 
            this.chkDoubleOut.AutoSize = true;
            this.chkDoubleOut.Location = new System.Drawing.Point(24, 357);
            this.chkDoubleOut.Name = "chkDoubleOut";
            this.chkDoubleOut.Size = new System.Drawing.Size(138, 21);
            this.chkDoubleOut.TabIndex = 27;
            this.chkDoubleOut.Text = "DQ On Doubles?";
            this.chkDoubleOut.UseVisualStyleBackColor = true;
            this.chkDoubleOut.CheckedChanged += new System.EventHandler(this.upDown_ValueChanged);
            // 
            // btnManage
            // 
            this.btnManage.Location = new System.Drawing.Point(24, 118);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(153, 28);
            this.btnManage.TabIndex = 28;
            this.btnManage.Text = "Manage Tournament";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // TournamentSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 757);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.chkDoubleOut);
            this.Controls.Add(this.txtDoubleLimit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtWinPoints);
            this.Controls.Add(this.txtDrawPoints);
            this.Controls.Add(this.txtLossPoints);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTournamentName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFighterCount);
            this.Controls.Add(this.txtFightTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLengthMessage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstFighters);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtRounds);
            this.Controls.Add(this.txtPools);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "TournamentSetupForm";
            this.Text = "Tournament Setup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLossPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWinPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnGenerate;
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
    }
}

