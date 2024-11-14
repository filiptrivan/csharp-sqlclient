using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cet09.Controls
{
    public partial class Main : UserControl
    {
        Controller _c = new Controller();

        public Main()
        {
            InitializeComponent();

            comboBox1.DataSource = _c.GetRecList();
            comboBox1.SelectedIndex = -1;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Naziv";

            comboBox2.DataSource = _c.GetJezikList();
            comboBox2.SelectedIndex = -1;
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Naziv";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void LoadDgv()
        {
            if (comboBox1.SelectedValue is Rec || comboBox2.SelectedValue is Jezik)
            {
                return;
            }

            long? recid = (long?)comboBox1.SelectedValue;
            long? prevodid = (long?)comboBox2.SelectedValue;

            if (recid != null || prevodid != null)
                dataGridView1.DataSource = _c.GetPrevodList((long?)comboBox1.SelectedValue, (long?)comboBox2.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _c.InsertPrevodi((long)comboBox1.SelectedValue, (long)comboBox2.SelectedValue, textBox1.Text);

            LoadDgv();
        }

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_ValueMemberChanged(object sender, EventArgs e)
        {
        }
    }
}
