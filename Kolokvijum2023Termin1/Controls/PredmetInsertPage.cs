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
    public partial class PredmetInsertPage : UserControl
    {
        Controller _controller = new Controller();
        Predmet p = null;

        public PredmetInsertPage(long predmetId = 0)
        {
            InitializeComponent();

            comboBox1.DataSource = _controller.GetKatedraList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Naziv";
            comboBox1.SelectedIndex = -1;

            if (predmetId != 0)
            {
                Predmet predmet = _controller.GetPredmet(predmetId);
                p = predmet;
                textBox1.Text = predmet.Naziv;
                textBox2.Text = predmet.ESPB.ToString();
                comboBox1.SelectedValue = predmet.KatedraId;

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                comboBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int espb = int.Parse(textBox2.Text);

            if (textBox1.Text.Length > 100 || espb < 2 || espb >= 10)
            {
                MessageBox.Show("Greska.");
                return;
            }

            if (p.Id != 0)
            {
                var mbForExistingUser = MessageBox.Show("Siguran?", "", MessageBoxButtons.YesNo);

                if (mbForExistingUser != DialogResult.Yes)
                {
                    return;
                }

                _controller.UpdatePredmet(new Predmet
                {
                    Id = p.Id,
                    Naziv = textBox1.Text,
                    ESPB = espb,
                    KatedraId = (long)comboBox1.SelectedValue
                });
            }
            else
            {
                _controller.InsertPredmet(new Predmet
                {
                    Naziv = textBox1.Text,
                    ESPB = espb,
                    KatedraId = (long)comboBox1.SelectedValue
                });

                var mb = MessageBox.Show("Nastavite?", "", MessageBoxButtons.YesNo);
                if (mb != DialogResult.Yes)
                {
                    Hide();
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            comboBox1.Enabled = true;
            button1.Enabled = true;
        }
    }
}
