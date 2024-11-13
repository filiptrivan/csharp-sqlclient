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
    public partial class NastavnikDetailsPage : UserControl
    {
        Controller _controller;
        Nastavnik currentNastavnik;

        public NastavnikDetailsPage(long nastavnikId)
        {
            InitializeComponent();
            _controller = new Controller();

            Nastavnik nastavnik = _controller.GetNastavnik(nastavnikId);
            currentNastavnik = nastavnik;

            textBox1.Text = nastavnik.Ime;
            textBox2.Text = nastavnik.Prezime;

            comboBox1.DataSource = _controller.GetZvanjeList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Naziv";

            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                Zvanje z = (Zvanje)comboBox1.Items[i];

                if (z.Id == nastavnik.Zvanje_Id)
                {
                    comboBox1.SelectedIndex = i;
                }
            }

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            comboBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nastavnik nastavnik = new Nastavnik
            {
                Id = currentNastavnik.Id,
                Ime = textBox1.Text,
                Prezime = textBox2.Text,
                Zvanje_Id = (long)comboBox1.SelectedValue
            };

            _controller.UpdateNastavnik(nastavnik);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            comboBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Sigurno?");

            if(r == DialogResult.OK)
            {
                _controller.DeleteNastavnik(currentNastavnik.Id);
            }
        }
    }
}
