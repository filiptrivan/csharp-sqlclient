using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_11_2019.Controls
{
    public partial class Zadatak2 : UserControl
    {
        Controller _controller;

        public Zadatak2()
        {
            InitializeComponent();
            _controller = new Controller();

            dataGridView1.DataSource = _controller.GetProfesor2List();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Status"].ReadOnly = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                string zvanje = dataGridView1.Rows[e.RowIndex].Cells["Zvanje"].Value as string;

                if (zvanje != "Docent" && zvanje != "Vanredni" && zvanje != "Redovni")
                {
                    MessageBox.Show("Dozvoljene vrednosti za zvanje su Docent, Vanredni, Redovni.");
                }

                Profesor2 p = new Profesor2
                {
                    Id = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value),
                    Ime = dataGridView1.Rows[e.RowIndex].Cells["Ime"].Value as string,
                    Prezime = dataGridView1.Rows[e.RowIndex].Cells["Prezime"].Value as string,
                    Zvanje = dataGridView1.Rows[e.RowIndex].Cells["Zvanje"].Value as string,
                };

                _controller.UpdateProfesor2(p);
            }
        }
    }
}
