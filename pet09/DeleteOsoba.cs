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
        Broker broker = new Broker();
        long ci = 0;

        public DeleteOsoba(long instrumentid)
        {
            InitializeComponent();

            ci = instrumentid;

            LoadTable();
        }

        private void LoadTable()
        {
            List<string> jmbgList = broker.GetosobainstrumentForinstrument(ci).Select(x => x.jmbg).ToList();

            dataGridView1.DataSource = broker.GetosobaList(jmbgList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedList = dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in selectedList)
            {
                osoba o = (osoba)row.DataBoundItem;
                broker.Deleteosoba(o.jmbg);
            }

            LoadTable();
        }
    }
}
