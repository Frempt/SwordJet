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
            this.btnMerge = new System.Windows.Forms.Button();
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
            this.tbcFights.Location = new System.Drawing.Point(3, 2);
            this.tbcFights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbcFights.Name = "tbcFights";
            this.tbcFights.SelectedIndex = 0;
            this.tbcFights.Size = new System.Drawing.Size(1073, 264);
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
            this.dgvFighters.Location = new System.Drawing.Point(3, 0);
            this.dgvFighters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFighters.Name = "dgvFighters";
            this.dgvFighters.ReadOnly = true;
            this.dgvFighters.RowTemplate.Height = 24;
            this.dgvFighters.Size = new System.Drawing.Size(879, 230);
            this.dgvFighters.TabIndex = 1;
            // 
            // btnExtendPools
            // 
            this.btnExtendPools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtendPools.Location = new System.Drawing.Point(888, 157);
            this.btnExtendPools.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExtendPools.Name = "btnExtendPools";
            this.btnExtendPools.Size = new System.Drawing.Size(185, 34);
            this.btnExtendPools.TabIndex = 2;
            this.btnExtendPools.Text = "Extend Pools";
            this.btnExtendPools.UseVisualStyleBackColor = true;
            this.btnExtendPools.Click += new System.EventHandler(this.btnExtendPools_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(0, 0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 7;
            // 
            // btnAdvance
            // 
            this.btnAdvance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvance.Location = new System.Drawing.Point(888, 198);
            this.btnAdvance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(185, 33);
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
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnMerge);
            this.splitContainer1.Panel1.Controls.Add(this.btnRatingsExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnExcel);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdvance);
            this.splitContainer1.Panel1.Controls.Add(this.btnExtendPools);
            this.splitContainer1.Panel1.Controls.Add(this.dgvFighters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbcFights);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 503);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMerge.Location = new System.Drawing.Point(888, 121);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(182, 31);
            this.btnMerge.TabIndex = 6;
            this.btnMerge.Text = "Merge Results";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnRatingsExport
            // 
            this.btnRatingsExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRatingsExport.Location = new System.Drawing.Point(885, 2);
            this.btnRatingsExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRatingsExport.Name = "btnRatingsExport";
            this.btnRatingsExport.Size = new System.Drawing.Size(185, 34);
            this.btnRatingsExport.TabIndex = 5;
            this.btnRatingsExport.Text = "HEMA Ratings Export";
            this.btnRatingsExport.UseVisualStyleBackColor = true;
            this.btnRatingsExport.Click += new System.EventHandler(this.btnRatingsExport_Click);
            // 
            // ManageTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 527);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button btnMerge;
    }
}