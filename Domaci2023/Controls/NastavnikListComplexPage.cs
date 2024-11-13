using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domaci2023.Controls
{
    public partial class NastavnikListComplexPage : UserControl
    {
        Controller _controller;
        public NastavnikListComplexPage()
        {
            InitializeComponent();
            _controller = new Controller();

            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = _controller.GetZvanjeList();
            col.DisplayMember = "Naziv";
            col.ValueMember = "Id";
            col.DataPropertyName = "Zvanje_Id";

            dataGridView1.Columns.Add(col);
            Init();
        }

        public void Init()
        {
            List<Nastavnik> nastavnici = _controller.GetNastavnikList()
                .Select(x => new Nastavnik
                {
                    Id = x.Id,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Zvanje = _controller.GetZvanje(x.Zvanje_Id),
                    Zvanje_Id = x.Zvanje_Id,
                })
                .OrderBy(x => x.Zvanje_Id)
                .ToList();

            dataGridView1.DataSource = new BindingList<Nastavnik>(nastavnici);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                long id = (long)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

                _controller.DeleteNastavnik(id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindingList<Nastavnik> nastavnici = dataGridView1.DataSource as BindingList<Nastavnik>;

            foreach (Nastavnik nastavnik in nastavnici)
            {
                if (string.IsNullOrEmpty(nastavnik.Ime) || string.IsNullOrEmpty(nastavnik.Prezime))
                {
                    MessageBox.Show("Greska.");
                    return;
                }

                if (nastavnik.Id == 0)
                {
                    _controller.InsertNastavnik(nastavnik);
                }
                else
                {
                    _controller.UpdateNastavnik(nastavnik);
                }
            }

            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<Nastavnik> nastavnici = dataGridView1.DataSource as BindingList<Nastavnik>;

            nastavnici.Add(new Nastavnik());

            dataGridView1.DataSource = nastavnici;
        }
    }
}
