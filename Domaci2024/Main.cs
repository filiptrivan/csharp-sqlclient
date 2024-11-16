using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domaci2024
{
    public partial class Main : Form
    {
        Broker broker = new Broker();
        Radnik cr = null;

        public Main(Radnik currentRadnik)
        {
            InitializeComponent();

            cr = currentRadnik;

            label1.Text = $"{currentRadnik.ime} {currentRadnik.prezime}";

            txt_email_kreatora.Text = currentRadnik.email;
            txt_email_kreatora.ReadOnly = true;

            combx_zvanje.DataSource = Enum.GetNames<Zvanje>().ToList();
            combx_zvanje.SelectedIndex = -1;

            listBox1.DataSource = broker.GetpredmetList();
            listBox1.ValueMember = "id";
            listBox1.DisplayMember = "naziv";
            listBox1.SelectedIndex = -1;

            checkedListBox1.DataSource = broker.GetpredmetList();
            checkedListBox1.ValueMember = "id";
            checkedListBox1.DisplayMember = "naziv";
            checkedListBox1.SelectedIndex = -1;

            checkBox1.Checked = true;
            radioButton1.Checked = true;
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            profesor profesor = new profesor
            {
                ime = txt_ime.Text,
                prezime = txt_prezime.Text,
                zvanje = Enum.Parse<Zvanje>((string)combx_zvanje.SelectedValue),
                email_kreatora = cr.email,
            };

            long newprofesorid = broker.Insertprofesor(profesor);

            List<long> selectedpredmetids = new List<long>();
            List<long> allpredmetids = broker.GetpredmetList().Select(x => x.id).ToList();

            //foreach (predmet predmet in listBox1.SelectedItems)
            //{
            //    selectedpredmetids.Add(predmet.id);
            //}

            foreach (predmet predmet in checkedListBox1.CheckedItems)
            {
                selectedpredmetids.Add(predmet.id);
            }

            foreach (long id in allpredmetids)
            {
                broker.Deleteangazovanje(newprofesorid, id);
            }

            foreach (long id in selectedpredmetids)
            {
                broker.Insertangazovanje(newprofesorid, id);
            }
        }
    }
}
