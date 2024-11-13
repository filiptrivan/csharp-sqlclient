namespace Domaci2023.Controls
{
    partial class NastavnikListComplexPage
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            zvanjeBindingSource1 = new BindingSource(components);
            nastavnikBindingSource = new BindingSource(components);
            zvanjeBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewButtonColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zvanjeBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nastavnikBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zvanjeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, idDataGridViewTextBoxColumn, imeDataGridViewTextBoxColumn, prezimeDataGridViewTextBoxColumn });
            dataGridView1.DataSource = nastavnikBindingSource;
            dataGridView1.Location = new Point(16, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(672, 150);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // zvanjeBindingSource1
            // 
            zvanjeBindingSource1.DataSource = typeof(Zvanje);
            // 
            // nastavnikBindingSource
            // 
            nastavnikBindingSource.DataSource = typeof(Nastavnik);
            // 
            // zvanjeBindingSource
            // 
            zvanjeBindingSource.DataSource = typeof(Zvanje);
            // 
            // button1
            // 
            button1.Location = new Point(16, 10);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Dodaj red";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(97, 10);
            button2.Name = "button2";
            button2.Size = new Size(96, 23);
            button2.TabIndex = 11;
            button2.Text = "Sinhronizuj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Obrisi";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Text = "Obrisi";
            dataGridViewTextBoxColumn1.ToolTipText = "Obrisi";
            dataGridViewTextBoxColumn1.UseColumnTextForButtonValue = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // imeDataGridViewTextBoxColumn
            // 
            imeDataGridViewTextBoxColumn.DataPropertyName = "Ime";
            imeDataGridViewTextBoxColumn.HeaderText = "Ime";
            imeDataGridViewTextBoxColumn.Name = "imeDataGridViewTextBoxColumn";
            // 
            // prezimeDataGridViewTextBoxColumn
            // 
            prezimeDataGridViewTextBoxColumn.DataPropertyName = "Prezime";
            prezimeDataGridViewTextBoxColumn.HeaderText = "Prezime";
            prezimeDataGridViewTextBoxColumn.Name = "prezimeDataGridViewTextBoxColumn";
            // 
            // NastavnikListComplexPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "NastavnikListComplexPage";
            Size = new Size(800, 231);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)zvanjeBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nastavnikBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)zvanjeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private BindingSource nastavnikBindingSource;
        private BindingSource zvanjeBindingSource;
        private BindingSource zvanjeBindingSource1;
        private DataGridViewButtonColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
    }
}
