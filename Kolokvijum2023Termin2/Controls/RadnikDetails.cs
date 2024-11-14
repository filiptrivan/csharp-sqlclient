using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kolokvijum2023Termin2.Controls
{
    public partial class RadnikDetails : UserControl
    {
        Broker broker = new Broker();
        Radnik cradnik = null;

        public RadnikDetails(long radnikId = 0)
        {
            InitializeComponent();

            comboBox1.DataSource = broker.GetOrganizaciona_JedinicaList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "naziv";
            comboBox1.SelectedIndex = -1;

            if (radnikId == 0)
            {
            }
            else if (radnikId != 0)
            {
                Radnik radnik = broker.GetRadnik(radnikId);
                cradnik = radnik;

                textBox1.Text = radnik.radna_knjizica;
                textBox2.Text = radnik.jmbg;
                textBox3.Text = radnik.ime;
                textBox4.Text = radnik.prezime;
                comboBox1.SelectedValue = radnik.oj;

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                comboBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private bool HasOtherCharacters(string input)
        {
            return input.Any(x => char.IsLetter(x) == false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.Text == null ||
                textBox2.Text == null ||
                textBox3.Text == null ||
                textBox4.Text == null ||
                comboBox1.SelectedIndex == -1 ||
                textBox2.Text.Length != 13 ||
                HasOtherCharacters(textBox3.Text) ||
                HasOtherCharacters(textBox4.Text) ||
                textBox3.Text.Length < 2 ||
                textBox4.Text.Length < 2
                )
            {
                MessageBox.Show("Validacija.");
                return;
            }

            if (cradnik == null)
            {
                long newId = broker.InsertRadnik(new Radnik
                {
                    radna_knjizica = textBox1.Text,
                    jmbg = textBox2.Text,
                    ime = textBox3.Text,
                    prezime = textBox4.Text,
                    oj = (long)comboBox1.SelectedValue
                });

                var r = MessageBox.Show($"Uspesno - {newId}", "Nastaviti?", MessageBoxButtons.YesNo);

                if (r != DialogResult.Yes)
                {
                    Controls.Clear();
                }
                else
                {
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    comboBox1.SelectedIndex = -1;
                    comboBox1.SelectedValue = 0;

                }
            }
            else
            {
                broker.UpdateRadnik(new Radnik
                {
                    id = cradnik.id,
                    radna_knjizica = textBox1.Text,
                    jmbg = textBox2.Text,
                    ime = textBox3.Text,
                    prezime = textBox4.Text,
                    oj = (long)comboBox1.SelectedValue
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            comboBox1.Enabled = true;
            button1.Enabled = true;
        }
    }
}
