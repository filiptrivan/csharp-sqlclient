using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pet09
{
    public partial class DeleteOsoba : Form
    {
        Broker _broker = new Broker();
        long currentInstrumentId = 0;

        public DeleteOsoba(long instrumentid)
        {
            InitializeComponent();

            currentInstrumentId = instrumentid;

            LoadTable();
        }

        private void LoadTable()
        {
            List<string> jmbgList = _broker.GetOsobaInstrumentForinstrument(currentInstrumentId).Select(x => x.JMBG).ToList();

            dataGridView1.DataSource = _broker.GetOsobaList(jmbgList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedList = dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in selectedList)
            {
                Osoba osoba = (Osoba)row.DataBoundItem;
                _broker.DeleteOsoba(osoba.JMBG);
            }

            LoadTable();
        }
    }
}
