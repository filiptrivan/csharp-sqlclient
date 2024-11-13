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
    public partial class NastavnikListPage : UserControl
    {
        Controller _controller;

        public NastavnikListPage()
        {
            InitializeComponent();

            _controller = new Controller();

            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = null;
            comboBox1.DataSource = _controller.GetZvanjeList();
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = null;

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Naziv";

            dataGridView1.DataSource = _controller.GetNastavnikList().OrderBy(x => x.Zvanje_Id).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 100 || textBox2.Text.Length > 100)
            {
                MessageBox.Show("Greska.");
                return;
            }

            Nastavnik nastavnik = new Nastavnik
            {
                Ime = textBox1.Text,
                Prezime = textBox2.Text,
                Zvanje_Id = (long)comboBox1.SelectedValue
            };

            _controller.InsertNastavnik(nastavnik);
            dataGridView1.DataSource = _controller.GetNastavnikList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                long id = (long)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

                NastavnikDetailsPage nastavnikDetailsPage = new NastavnikDetailsPage(id);
                Controls.Clear();
                Controls.Add(nastavnikDetailsPage);
            }
        }
    }
}
