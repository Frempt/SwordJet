namespace TournamentGenerator
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFighters)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcFights
            // 
            this.tbcFights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcFights.Location = new System.Drawing.Point(12, 250);
            this.tbcFights.Name = "tbcFights";
            this.tbcFights.SelectedIndex = 0;
            this.tbcFights.Size = new System.Drawing.Size(1044, 284);
            this.tbcFights.TabIndex = 0;
            // 
            // dgvFighters
            // 
            this.dgvFighters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFighters.Location = new System.Drawing.Point(12, 12);
            this.dgvFighters.Name = "dgvFighters";
            this.dgvFighters.RowTemplate.Height = 24;
            this.dgvFighters.Size = new System.Drawing.Size(514, 232);
            this.dgvFighters.TabIndex = 1;
            // 
            // ManageTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 546);
            this.Controls.Add(this.dgvFighters);
            this.Controls.Add(this.tbcFights);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageTournament";
            this.Text = "Manage Tournament";
            this.Load += new System.EventHandler(this.ManageTournament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFighters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcFights;
        private System.Windows.Forms.DataGridView dgvFighters;
    }
}