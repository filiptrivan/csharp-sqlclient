namespace Kolokvijum2023Termin2.Controls
{
    partial class RadnikList
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
            Detalji = new DataGridViewButtonColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            radnaknjizicaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jmbgDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ojDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ojNaziv = new DataGridViewTextBoxColumn();
            radnikBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radnikBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Detalji, idDataGridViewTextBoxColumn, radnaknjizicaDataGridViewTextBoxColumn, jmbgDataGridViewTextBoxColumn, imeDataGridViewTextBoxColumn, prezimeDataGridViewTextBoxColumn, ojDataGridViewTextBoxColumn, ojNaziv });
            dataGridView1.DataSource = radnikBindingSource;
            dataGridView1.Location = new Point(19, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(680, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Detalji
            // 
            Detalji.HeaderText = "Detalji";
            Detalji.Name = "Detalji";
            Detalji.ReadOnly = true;
            Detalji.Text = "Detalji";
            Detalji.ToolTipText = "Detalji";
            Detalji.UseColumnTextForButtonValue = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // radnaknjizicaDataGridViewTextBoxColumn
            // 
            radnaknjizicaDataGridViewTextBoxColumn.DataPropertyName = "radna_knjizica";
            radnaknjizicaDataGridViewTextBoxColumn.HeaderText = "radna_knjizica";
            radnaknjizicaDataGridViewTextBoxColumn.Name = "radnaknjizicaDataGridViewTextBoxColumn";
            radnaknjizicaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jmbgDataGridViewTextBoxColumn
            // 
            jmbgDataGridViewTextBoxColumn.DataPropertyName = "jmbg";
            jmbgDataGridViewTextBoxColumn.HeaderText = "jmbg";
            jmbgDataGridViewTextBoxColumn.Name = "jmbgDataGridViewTextBoxColumn";
            jmbgDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imeDataGridViewTextBoxColumn
            // 
            imeDataGridViewTextBoxColumn.DataPropertyName = "ime";
            imeDataGridViewTextBoxColumn.HeaderText = "ime";
            imeDataGridViewTextBoxColumn.Name = "imeDataGridViewTextBoxColumn";
            imeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prezimeDataGridViewTextBoxColumn
            // 
            prezimeDataGridViewTextBoxColumn.DataPropertyName = "prezime";
            prezimeDataGridViewTextBoxColumn.HeaderText = "prezime";
            prezimeDataGridViewTextBoxColumn.Name = "prezimeDataGridViewTextBoxColumn";
            prezimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ojDataGridViewTextBoxColumn
            // 
            ojDataGridViewTextBoxColumn.DataPropertyName = "oj";
            ojDataGridViewTextBoxColumn.HeaderText = "oj";
            ojDataGridViewTextBoxColumn.Name = "ojDataGridViewTextBoxColumn";
            ojDataGridViewTextBoxColumn.ReadOnly = true;
            ojDataGridViewTextBoxColumn.Visible = false;
            // 
            // ojNaziv
            // 
            ojNaziv.DataPropertyName = "ojNaziv";
            ojNaziv.HeaderText = "ojNaziv";
            ojNaziv.Name = "ojNaziv";
            ojNaziv.ReadOnly = true;
            // 
            // radnikBindingSource
            // 
            radnikBindingSource.DataSource = typeof(Radnik);
            // 
            // RadnikList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "RadnikList";
            Size = new Size(974, 542);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)radnikBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource radnikBindingSource;
        private DataGridViewButtonColumn Detalji;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn radnaknjizicaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jmbgDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ojDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ojNaziv;
    }
}
