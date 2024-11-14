using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolokvijum2023Termin2.Controls
{
    public partial class RadnikList : UserControl
    {
        Broker broker = new Broker();

        public RadnikList()
        {
            InitializeComponent();

            dataGridView1.DataSource = broker.GetRadnikList().OrderByDescending(x => x.prezime).Select(x => new Radnik
            {
                id = x.id,
                ime = x.ime,
                jmbg = x.jmbg,
                oj = x.oj,
                ojNaziv = broker.GetOrganizaciona_Jedinica(x.oj)?.naziv,
                prezime = x.prezime,
                radna_knjizica = x.radna_knjizica
            }).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                long id = (long)dataGridView1.Rows[e.RowIndex].Cells[1].Value;

                Controls.Clear();
                RadnikDetails radnikDetails = new RadnikDetails(id);
                Controls.Add(radnikDetails);
            }
        }
    }
}
