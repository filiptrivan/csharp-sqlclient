using _11_07_2025_klk_server;

namespace _11_07_2025_klk_client
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            nastavnikDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            predmetDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipAngazovanjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nastavnikPredmetBindingSource = new BindingSource(components);
            userBindingSource = new BindingSource(components);
            dataGridView2 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usernameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            passwordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nastavnikPredmetBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nastavnikDataGridViewTextBoxColumn, predmetDataGridViewTextBoxColumn, tipAngazovanjaDataGridViewTextBoxColumn });
            dataGridView1.DataSource = nastavnikPredmetBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // nastavnikDataGridViewTextBoxColumn
            // 
            nastavnikDataGridViewTextBoxColumn.DataPropertyName = "Nastavnik";
            nastavnikDataGridViewTextBoxColumn.HeaderText = "Nastavnik";
            nastavnikDataGridViewTextBoxColumn.Name = "nastavnikDataGridViewTextBoxColumn";
            // 
            // predmetDataGridViewTextBoxColumn
            // 
            predmetDataGridViewTextBoxColumn.DataPropertyName = "Predmet";
            predmetDataGridViewTextBoxColumn.HeaderText = "Predmet";
            predmetDataGridViewTextBoxColumn.Name = "predmetDataGridViewTextBoxColumn";
            // 
            // tipAngazovanjaDataGridViewTextBoxColumn
            // 
            tipAngazovanjaDataGridViewTextBoxColumn.DataPropertyName = "TipAngazovanja";
            tipAngazovanjaDataGridViewTextBoxColumn.HeaderText = "TipAngazovanja";
            tipAngazovanjaDataGridViewTextBoxColumn.Name = "tipAngazovanjaDataGridViewTextBoxColumn";
            // 
            // nastavnikPredmetBindingSource
            // 
            nastavnikPredmetBindingSource.DataSource = typeof(NastavnikPredmet);
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(User);
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, usernameDataGridViewTextBoxColumn, passwordDataGridViewTextBoxColumn });
            dataGridView2.DataSource = userBindingSource;
            dataGridView2.Location = new Point(12, 178);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(776, 150);
            dataGridView2.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            button1.Location = new Point(12, 370);
            button1.Name = "button1";
            button1.Size = new Size(158, 23);
            button1.TabIndex = 2;
            button1.Text = "Dodaj Angazovanje";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nastavnikPredmetBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource userBindingSource;
        private DataGridViewTextBoxColumn nastavnikDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn predmetDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipAngazovanjaDataGridViewTextBoxColumn;
        private BindingSource nastavnikPredmetBindingSource;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private Button button1;
    }
}