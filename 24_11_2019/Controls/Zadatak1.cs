using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_11_2019.Controls
{
    public partial class Zadatak1 : UserControl
    {
        Proizvod currentProizvod;

        List<Proizvod> proizvodi = new List<Proizvod>
        {
            new Proizvod
            {
                Sifra="1",
                Naziv="Bosch Hilti",
                Cena=20.20M,
                PoreskaStopa=new PoreskaStopa{Sifra="1", Iznos=5, SkraceniNaziv="PS1"},
                Proizvodjac=new Proizvodjac{Naziv="Bosch", Sifra="ABC" }
            },
            new Proizvod
            {
                Sifra="2",
                Naziv="Makita Hilti",
                Cena=30,
                PoreskaStopa=new PoreskaStopa{Sifra="2"},
                Proizvodjac=new Proizvodjac{Naziv="Makita", Sifra="BCA" }
            },
        };

        List<PoreskaStopa> poreskeStope = new List<PoreskaStopa>
        {
            new PoreskaStopa { Sifra="1", Iznos =10, SkraceniNaziv="10"},
            new PoreskaStopa { Sifra="2", Iznos =20, SkraceniNaziv="20"},
            new PoreskaStopa { Sifra="3", Iznos =30, SkraceniNaziv="30"},
            new PoreskaStopa { Sifra="4", Iznos =40, SkraceniNaziv="40"},
        };

        public Zadatak1()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "Naziv";
            comboBox1.ValueMember = "Sifra";
            comboBox1.DataSource = proizvodi;

            comboBox2.DisplayMember = "SkraceniNaziv";
            comboBox2.ValueMember = "Sifra";
            comboBox2.DataSource = poreskeStope;
        }

        public class Proizvod
        {
            public string Sifra { get; set; }
            public string Naziv { get; set; }
            public decimal Cena { get; set; }
            public PoreskaStopa PoreskaStopa { get; set; }
            public Proizvodjac Proizvodjac { get; set; }
        }

        public class Proizvodjac
        {
            public string Sifra { get; set; }
            public string Naziv { get; set; }
        }

        public class PoreskaStopa
        {
            public string Sifra { get; set; }
            public string SkraceniNaziv { get; set; }
            public decimal Iznos { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sifra = comboBox1.SelectedValue as string;
            Proizvod proizvod = comboBox1.SelectedItem as Proizvod;
            currentProizvod = proizvod;

            if (sifra != null)
            {
                textBox1.Text = proizvod.Sifra;
                textBox2.Text = proizvod.Naziv;
                textBox3.Text = proizvod.Cena.ToString();
                comboBox2.SelectedValue = proizvod.PoreskaStopa.Sifra;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currentProizvod.Sifra = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            currentProizvod.Naziv = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            currentProizvod.Cena = decimal.Parse(textBox3.Text);
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            currentProizvod.PoreskaStopa.Sifra = comboBox2.SelectedValue as string;
        }
    }
}
