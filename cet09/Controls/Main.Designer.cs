namespace cet09.Controls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(25, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.ValueMemberChanged += comboBox1_ValueMemberChanged;
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(539, 150);
            dataGridView1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(163, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 2;
            comboBox2.ValueMemberChanged += comboBox2_ValueMemberChanged;
            comboBox2.SelectedValueChanged += comboBox2_SelectedValueChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(302, 22);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Prevod #";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(25, 222);
            button1.Name = "button1";
            button1.Size = new Size(185, 23);
            button1.TabIndex = 4;
            button1.Text = "Dodaj prevode";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(comboBox2);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Name = "Main";
            Size = new Size(852, 465);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private Button button1;
    }
}
