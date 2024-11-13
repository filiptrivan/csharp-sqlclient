namespace Kolokvijum2023Termin1.Controls
{
    partial class PredmetListPage
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
            predmetBindingSource = new BindingSource(components);
            Detalji = new DataGridViewButtonColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nazivDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eSPBDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            katedraIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            KatedraNaziv = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)predmetBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Detalji, idDataGridViewTextBoxColumn, nazivDataGridViewTextBoxColumn, eSPBDataGridViewTextBoxColumn, katedraIdDataGridViewTextBoxColumn, KatedraNaziv });
            dataGridView1.DataSource = predmetBindingSource;
            dataGridView1.Location = new Point(21, 18);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(609, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // predmetBindingSource
            // 
            predmetBindingSource.DataSource = typeof(Predmet);
            // 
            // Detalji
            // 
            Detalji.HeaderText = "Detalji";
            Detalji.Name = "Detalji";
            Detalji.ReadOnly = true;
            Detalji.Text = "Detalji";
            Detalji.UseColumnTextForButtonValue = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nazivDataGridViewTextBoxColumn
            // 
            nazivDataGridViewTextBoxColumn.DataPropertyName = "Naziv";
            nazivDataGridViewTextBoxColumn.HeaderText = "Naziv";
            nazivDataGridViewTextBoxColumn.Name = "nazivDataGridViewTextBoxColumn";
            nazivDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eSPBDataGridViewTextBoxColumn
            // 
            eSPBDataGridViewTextBoxColumn.DataPropertyName = "ESPB";
            eSPBDataGridViewTextBoxColumn.HeaderText = "ESPB";
            eSPBDataGridViewTextBoxColumn.Name = "eSPBDataGridViewTextBoxColumn";
            eSPBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // katedraIdDataGridViewTextBoxColumn
            // 
            katedraIdDataGridViewTextBoxColumn.DataPropertyName = "KatedraId";
            katedraIdDataGridViewTextBoxColumn.HeaderText = "KatedraId";
            katedraIdDataGridViewTextBoxColumn.Name = "katedraIdDataGridViewTextBoxColumn";
            katedraIdDataGridViewTextBoxColumn.ReadOnly = true;
            katedraIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // KatedraNaziv
            // 
            KatedraNaziv.DataPropertyName = "KatedraNaziv";
            KatedraNaziv.HeaderText = "KatedraNaziv";
            KatedraNaziv.Name = "KatedraNaziv";
            KatedraNaziv.ReadOnly = true;
            // 
            // PredmetListPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Name = "PredmetListPage";
            Size = new Size(679, 245);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)predmetBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource predmetBindingSource;
        private DataGridViewButtonColumn Detalji;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nazivDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eSPBDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn katedraIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn KatedraNaziv;
    }
}
