namespace TournamentGenerator
{
    partial class Form1
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(252, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
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
            this.panel1.Location = new System.Drawing.Point(13, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 33);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtName.Location = new System.Drawing.Point(44, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Pools";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rounds per Pool";
            // 
            // txtPools
            // 
            this.txtPools.Location = new System.Drawing.Point(124, 23);
            this.txtPools.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPools.Name = "txtPools";
            this.txtPools.Size = new System.Drawing.Size(216, 20);
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
            this.txtRounds.Location = new System.Drawing.Point(124, 67);
            this.txtRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRounds.Name = "txtRounds";
            this.txtRounds.Size = new System.Drawing.Size(219, 20);
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
            this.btnGenerate.Location = new System.Drawing.Point(252, 102);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 23);
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
            this.lstFighters.Location = new System.Drawing.Point(13, 272);
            this.lstFighters.Name = "lstFighters";
            this.lstFighters.Size = new System.Drawing.Size(330, 225);
            this.lstFighters.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(265, 503);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblLengthMessage
            // 
            this.lblLengthMessage.AutoEllipsis = true;
            this.lblLengthMessage.Location = new System.Drawing.Point(12, 163);
            this.lblLengthMessage.Name = "lblLengthMessage";
            this.lblLengthMessage.Size = new System.Drawing.Size(328, 67);
            this.lblLengthMessage.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fight time (minutes)";
            // 
            // txtFightTime
            // 
            this.txtFightTime.Location = new System.Drawing.Point(124, 142);
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
            this.txtFightTime.Size = new System.Drawing.Size(216, 20);
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
            this.lblFighterCount.AutoSize = true;
            this.lblFighterCount.Location = new System.Drawing.Point(16, 508);
            this.lblFighterCount.Name = "lblFighterCount";
            this.lblFighterCount.Size = new System.Drawing.Size(108, 13);
            this.lblFighterCount.TabIndex = 14;
            this.lblFighterCount.Text = "Number of Fighters: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 527);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RMAS Tournament Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFightTime)).EndInit();
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
    }
}

