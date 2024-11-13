namespace Auth.Controlls
{
    partial class HomePage
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
            label1 = new Label();
            txt_Name = new TextBox();
            txt_Surname = new TextBox();
            comboBox1 = new ComboBox();
            btn_AddProfesor = new Button();
            dataGridView1 = new DataGridView();
            lb_Angazovanja = new ListBox();
            label2 = new Label();
            dgv_Profesori = new DataGridView();
            Edit = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Profesori).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 8);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(9, 47);
            txt_Name.Name = "txt_Name";
            txt_Name.PlaceholderText = "Ime";
            txt_Name.Size = new Size(121, 23);
            txt_Name.TabIndex = 1;
            // 
            // txt_Surname
            // 
            txt_Surname.Location = new Point(9, 89);
            txt_Surname.Name = "txt_Surname";
            txt_Surname.PlaceholderText = "Prezime";
            txt_Surname.Size = new Size(121, 23);
            txt_Surname.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(9, 132);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            // 
            // btn_AddProfesor
            // 
            btn_AddProfesor.Location = new Point(8, 292);
            btn_AddProfesor.Name = "btn_AddProfesor";
            btn_AddProfesor.Size = new Size(121, 23);
            btn_AddProfesor.TabIndex = 4;
            btn_AddProfesor.Text = "Dodaj profesora";
            btn_AddProfesor.UseVisualStyleBackColor = true;
            btn_AddProfesor.Click += btn_AddProfesor_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 361);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(665, 150);
            dataGridView1.TabIndex = 5;
            // 
            // lb_Angazovanja
            // 
            lb_Angazovanja.FormattingEnabled = true;
            lb_Angazovanja.ItemHeight = 15;
            lb_Angazovanja.Location = new Point(9, 175);
            lb_Angazovanja.Name = "lb_Angazovanja";
            lb_Angazovanja.SelectionMode = SelectionMode.MultiExtended;
            lb_Angazovanja.Size = new Size(120, 94);
            lb_Angazovanja.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 343);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 7;
            label2.Text = "Profesorovi predmeti";
            // 
            // dgv_Profesori
            // 
            dgv_Profesori.AllowUserToAddRows = false;
            dgv_Profesori.AllowUserToDeleteRows = false;
            dgv_Profesori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Profesori.Columns.AddRange(new DataGridViewColumn[] { Edit, Delete });
            dgv_Profesori.Location = new Point(11, 571);
            dgv_Profesori.Name = "dgv_Profesori";
            dgv_Profesori.ReadOnly = true;
            dgv_Profesori.RowTemplate.Height = 25;
            dgv_Profesori.Size = new Size(663, 150);
            dgv_Profesori.TabIndex = 8;
            dgv_Profesori.CellClick += dgv_Profesori_CellClick;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            Edit.Text = "Edit";
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.Name = "Delete";
            Delete.ReadOnly = true;
            Delete.Text = "Delete";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 553);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 9;
            label3.Text = "Svi profesori";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(label3);
            Controls.Add(dgv_Profesori);
            Controls.Add(label2);
            Controls.Add(lb_Angazovanja);
            Controls.Add(dataGridView1);
            Controls.Add(btn_AddProfesor);
            Controls.Add(comboBox1);
            Controls.Add(txt_Surname);
            Controls.Add(txt_Name);
            Controls.Add(label1);
            Name = "HomePage";
            Size = new Size(1336, 968);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Profesori).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_Name;
        private TextBox txt_Surname;
        private ComboBox comboBox1;
        private Button btn_AddProfesor;
        private DataGridView dataGridView1;
        private ListBox lb_Angazovanja;
        private Label label2;
        private DataGridView dgv_Profesori;
        private Label label3;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
    }
}
