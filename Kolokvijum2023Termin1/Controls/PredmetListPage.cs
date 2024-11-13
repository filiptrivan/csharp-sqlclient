using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolokvijum2023Termin1.Controls
{
    public partial class PredmetListPage : UserControl
    {
        Controller _controller = new Controller();

        public PredmetListPage()
        {
            InitializeComponent();

            List<Predmet> predmeti = _controller.GetPredmetList()
                .OrderByDescending(x => x.ESPB)
                .Select(x => new Predmet
                {
                    Id = x.Id,
                    ESPB = x.ESPB,
                    KatedraId = x.KatedraId,
                    KatedraNaziv = _controller.GetKatedra(x.KatedraId).Naziv,
                    Naziv = x.Naziv,
                })
                .ToList();

            dataGridView1.DataSource = predmeti;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            long id = (long)dataGridView1.Rows[e.RowIndex].Cells[1].Value;

            if (e.ColumnIndex == 0)
            {
                Controls.Clear();
                PredmetInsertPage predmetInsertPage = new PredmetInsertPage(id);
                Controls.Add(predmetInsertPage);
            }
        }
    }
}
