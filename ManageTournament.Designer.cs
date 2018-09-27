namespace SwordJet
{
    partial class ManageTournament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTournament));
            this.tbcFights = new System.Windows.Forms.TabControl();
            this.dgvFighters = new System.Windows.Forms.DataGridView();
            this.btnExtendPools = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRatingsExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFighters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcFights
            // 
            this.tbcFights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcFights.Location = new System.Drawing.Point(2, 2);
            this.tbcFights.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbcFights.Name = "tbcFights";
            this.tbcFights.SelectedIndex = 0;
            this.tbcFights.Size = new System.Drawing.Size(805, 317);
            this.tbcFights.TabIndex = 0;
            // 
            // dgvFighters
            // 
            this.dgvFighters.AllowUserToAddRows = false;
            this.dgvFighters.AllowUserToDeleteRows = false;
            this.dgvFighters.AllowUserToOrderColumns = true;
            this.dgvFighters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFighters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFighters.Location = new System.Drawing.Point(2, 0);
            this.dgvFighters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFighters.Name = "dgvFighters";
            this.dgvFighters.ReadOnly = true;
            this.dgvFighters.RowTemplate.Height = 24;
            this.dgvFighters.Size = new System.Drawing.Size(659, 188);
            this.dgvFighters.TabIndex = 1;
            // 
            // btnExtendPools
            // 
            this.btnExtendPools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtendPools.Location = new System.Drawing.Point(666, 128);
            this.btnExtendPools.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExtendPools.Name = "btnExtendPools";
            this.btnExtendPools.Size = new System.Drawing.Size(139, 28);
            this.btnExtendPools.TabIndex = 2;
            this.btnExtendPools.Text = "Extend Pools";
            this.btnExtendPools.UseVisualStyleBackColor = true;
            this.btnExtendPools.Click += new System.EventHandler(this.btnExtendPools_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Location = new System.Drawing.Point(666, 0);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(139, 28);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "Export to Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnAdvance
            // 
            this.btnAdvance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvance.Location = new System.Drawing.Point(666, 162);
            this.btnAdvance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(139, 27);
            this.btnAdvance.TabIndex = 4;
            this.btnAdvance.Text = "Advance";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 10);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRatingsExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnExcel);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdvance);
            this.splitContainer1.Panel1.Controls.Add(this.btnExtendPools);
            this.splitContainer1.Panel1.Controls.Add(this.dgvFighters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbcFights);
            this.splitContainer1.Size = new System.Drawing.Size(805, 409);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnRatingsExport
            // 
            this.btnRatingsExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRatingsExport.Location = new System.Drawing.Point(666, 33);
            this.btnRatingsExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRatingsExport.Name = "btnRatingsExport";
            this.btnRatingsExport.Size = new System.Drawing.Size(139, 28);
            this.btnRatingsExport.TabIndex = 5;
            this.btnRatingsExport.Text = "HEMA Ratings Export";
            this.btnRatingsExport.UseVisualStyleBackColor = true;
            this.btnRatingsExport.Click += new System.EventHandler(this.btnRatingsExport_Click);
            // 
            // ManageTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 428);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageTournament";
            this.Text = "Manage Tournament";
            this.Load += new System.EventHandler(this.ManageTournament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFighters)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcFights;
        private System.Windows.Forms.DataGridView dgvFighters;
        private System.Windows.Forms.Button btnExtendPools;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRatingsExport;
    }
}