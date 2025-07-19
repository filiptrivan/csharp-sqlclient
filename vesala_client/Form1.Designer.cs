namespace vesala_server
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brojPokusajaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brojPogodjenihDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            zadnjeSlovoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pokusajBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pokusajBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 17);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, brojPokusajaDataGridViewTextBoxColumn, brojPogodjenihDataGridViewTextBoxColumn, zadnjeSlovoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = pokusajBindingSource;
            dataGridView1.Location = new Point(23, 118);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(750, 150);
            dataGridView1.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // brojPokusajaDataGridViewTextBoxColumn
            // 
            brojPokusajaDataGridViewTextBoxColumn.DataPropertyName = "BrojPokusaja";
            brojPokusajaDataGridViewTextBoxColumn.HeaderText = "BrojPokusaja";
            brojPokusajaDataGridViewTextBoxColumn.Name = "brojPokusajaDataGridViewTextBoxColumn";
            brojPokusajaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // brojPogodjenihDataGridViewTextBoxColumn
            // 
            brojPogodjenihDataGridViewTextBoxColumn.DataPropertyName = "BrojPogodjenih";
            brojPogodjenihDataGridViewTextBoxColumn.HeaderText = "BrojPogodjenih";
            brojPogodjenihDataGridViewTextBoxColumn.Name = "brojPogodjenihDataGridViewTextBoxColumn";
            brojPogodjenihDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zadnjeSlovoDataGridViewTextBoxColumn
            // 
            zadnjeSlovoDataGridViewTextBoxColumn.DataPropertyName = "ZadnjeSlovo";
            zadnjeSlovoDataGridViewTextBoxColumn.HeaderText = "ZadnjeSlovo";
            zadnjeSlovoDataGridViewTextBoxColumn.Name = "zadnjeSlovoDataGridViewTextBoxColumn";
            zadnjeSlovoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pokusajBindingSource
            // 
            pokusajBindingSource.DataSource = typeof(Pokusaj);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pokusajBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brojPokusajaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brojPogodjenihDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn zadnjeSlovoDataGridViewTextBoxColumn;
        private BindingSource pokusajBindingSource;
    }
}
