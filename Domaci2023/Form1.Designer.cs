namespace Domaci2023
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            zadatak1ToolStripMenuItem = new ToolStripMenuItem();
            zadatak2ToolStripMenuItem = new ToolStripMenuItem();
            pnl_Main = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { zadatak1ToolStripMenuItem, zadatak2ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // zadatak1ToolStripMenuItem
            // 
            zadatak1ToolStripMenuItem.Name = "zadatak1ToolStripMenuItem";
            zadatak1ToolStripMenuItem.Size = new Size(70, 20);
            zadatak1ToolStripMenuItem.Text = "Zadatak 1";
            zadatak1ToolStripMenuItem.Click += zadatak1ToolStripMenuItem_Click;
            // 
            // zadatak2ToolStripMenuItem
            // 
            zadatak2ToolStripMenuItem.Name = "zadatak2ToolStripMenuItem";
            zadatak2ToolStripMenuItem.Size = new Size(70, 20);
            zadatak2ToolStripMenuItem.Text = "Zadatak 2";
            zadatak2ToolStripMenuItem.Click += zadatak2ToolStripMenuItem_Click;
            // 
            // pnl_Main
            // 
            pnl_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_Main.BackColor = SystemColors.ActiveCaption;
            pnl_Main.Location = new Point(12, 27);
            pnl_Main.Name = "pnl_Main";
            pnl_Main.Size = new Size(776, 411);
            pnl_Main.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnl_Main);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem zadatak1ToolStripMenuItem;
        private ToolStripMenuItem zadatak2ToolStripMenuItem;
        private Panel pnl_Main;
    }
}
