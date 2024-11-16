using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cet16.Controls
{
    public partial class Details : Form
    {
        Broker broker = new Broker();

        long rid = 0;
        long jid = 0;

        public Details(long recid, long jezikid)
        {
            InitializeComponent();

            rid = recid;
            jid = jezikid;

            srb_rec r = broker.Getsrb_rec(recid);

            jezik j = broker.Getjezik(jezikid);

            textBox1.Text = r.naziv;
            textBox2.Text = j.naziv;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            LoadGrid();
        }

        public void LoadGrid()
        {
            dataGridView1.DataSource = broker.GetprevodList(rid, jid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Siguran?", "", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                List<prevod> prevods = new List<prevod>();
                DataGridViewSelectedRowCollection rowList = dataGridView1.SelectedRows;
                
                foreach (DataGridViewRow row in rowList)
                    prevods.Add((prevod)row.DataBoundItem);

                foreach (prevod row in prevods)
                {
                    broker.Deleteprevod(row.id);
                }

                LoadGrid();
            }
        }
    }
}
