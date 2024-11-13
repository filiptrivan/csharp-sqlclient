namespace Auth.Controls
{
    partial class ProfesorDetailsPage
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
            txt_Name = new TextBox();
            txt_Surname = new TextBox();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(16, 15);
            txt_Name.Name = "txt_Name";
            txt_Name.PlaceholderText = "Ime";
            txt_Name.Size = new Size(144, 23);
            txt_Name.TabIndex = 0;
            // 
            // txt_Surname
            // 
            txt_Surname.Location = new Point(16, 63);
            txt_Surname.Name = "txt_Surname";
            txt_Surname.PlaceholderText = "Prezime";
            txt_Surname.Size = new Size(144, 23);
            txt_Surname.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(16, 116);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 23);
            comboBox1.TabIndex = 2;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(16, 166);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.Size = new Size(144, 94);
            listBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(16, 287);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ProfesorDetailsPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(txt_Surname);
            Controls.Add(txt_Name);
            Name = "ProfesorDetailsPage";
            Size = new Size(745, 359);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Name;
        private TextBox txt_Surname;
        private ComboBox comboBox1;
        private ListBox listBox1;
        private Button button1;
    }
}
