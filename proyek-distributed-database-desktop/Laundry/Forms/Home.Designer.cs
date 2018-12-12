namespace proyek_distributed_database_desktop.Laundry
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterLaundryServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLaundryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLaundryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLaundryToolStripMenuItem,
            this.editLaundryToolStripMenuItem,
            this.masterLaundryServiceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterLaundryServiceToolStripMenuItem
            // 
            this.masterLaundryServiceToolStripMenuItem.Name = "masterLaundryServiceToolStripMenuItem";
            this.masterLaundryServiceToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.masterLaundryServiceToolStripMenuItem.Text = "Master Laundry Service";
            this.masterLaundryServiceToolStripMenuItem.Click += new System.EventHandler(this.masterLaundryServiceToolStripMenuItem_Click);
            // 
            // newLaundryToolStripMenuItem
            // 
            this.newLaundryToolStripMenuItem.Name = "newLaundryToolStripMenuItem";
            this.newLaundryToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.newLaundryToolStripMenuItem.Text = "New Laundry";
            this.newLaundryToolStripMenuItem.Click += new System.EventHandler(this.newLaundryToolStripMenuItem_Click);
            // 
            // editLaundryToolStripMenuItem
            // 
            this.editLaundryToolStripMenuItem.Name = "editLaundryToolStripMenuItem";
            this.editLaundryToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.editLaundryToolStripMenuItem.Text = "Edit Laundry";
            this.editLaundryToolStripMenuItem.Click += new System.EventHandler(this.editLaundryToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 372);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laundry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newLaundryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLaundryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterLaundryServiceToolStripMenuItem;
    }
}