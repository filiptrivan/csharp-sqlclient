namespace Domaci2023.Controls
{
    partial class NastavnikDetailsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(143, 157);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 13;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(16, 104);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(130, 23);
            comboBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(16, 58);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Prezime";
            textBox2.Size = new Size(130, 23);
            textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 14);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Ime";
            textBox1.Size = new Size(130, 23);
            textBox1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(16, 157);
            button2.Name = "button2";
            button2.Size = new Size(121, 23);
            button2.TabIndex = 14;
            button2.Text = "Omoguci izmenu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(279, 157);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 15;
            button3.Text = "Obrisi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // NastavnikDetailsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "NastavnikDetailsPage";
            Size = new Size(560, 264);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
    }
}
