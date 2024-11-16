namespace Domaci2024
{
    partial class Main
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
            txt_ime = new TextBox();
            txt_prezime = new TextBox();
            txt_email_kreatora = new TextBox();
            button1 = new Button();
            combx_zvanje = new ComboBox();
            listBox1 = new ListBox();
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // txt_ime
            // 
            txt_ime.Location = new Point(12, 50);
            txt_ime.Name = "txt_ime";
            txt_ime.PlaceholderText = "ime";
            txt_ime.Size = new Size(100, 23);
            txt_ime.TabIndex = 0;
            // 
            // txt_prezime
            // 
            txt_prezime.Location = new Point(12, 90);
            txt_prezime.Name = "txt_prezime";
            txt_prezime.PlaceholderText = "prezime";
            txt_prezime.Size = new Size(100, 23);
            txt_prezime.TabIndex = 1;
            // 
            // txt_email_kreatora
            // 
            txt_email_kreatora.Location = new Point(12, 176);
            txt_email_kreatora.Name = "txt_email_kreatora";
            txt_email_kreatora.PlaceholderText = "email kreatora";
            txt_email_kreatora.Size = new Size(100, 23);
            txt_email_kreatora.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(12, 328);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // combx_zvanje
            // 
            combx_zvanje.FormattingEnabled = true;
            combx_zvanje.Location = new Point(12, 134);
            combx_zvanje.Name = "combx_zvanje";
            combx_zvanje.Size = new Size(121, 23);
            combx_zvanje.TabIndex = 5;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 218);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(171, 218);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(120, 94);
            checkedListBox1.TabIndex = 9;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(181, 339);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 19);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(181, 364);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 19);
            radioButton2.TabIndex = 11;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(320, 340);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 492);
            Controls.Add(checkBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(checkedListBox1);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(combx_zvanje);
            Controls.Add(button1);
            Controls.Add(txt_email_kreatora);
            Controls.Add(txt_prezime);
            Controls.Add(txt_ime);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_ime;
        private TextBox txt_prezime;
        private TextBox txt_email_kreatora;
        private Button button1;
        private ComboBox combx_zvanje;
        private ListBox listBox1;
        private Label label1;
        private CheckedListBox checkedListBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private CheckBox checkBox1;
    }
}