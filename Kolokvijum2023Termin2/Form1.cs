using Kolokvijum2023Termin2.Controls;

namespace Kolokvijum2023Termin2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadnikList radnikList = new RadnikList();
            panel1.Controls.Clear();
            panel1.Controls.Add(radnikList);
        }

        private void detaljiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadnikDetails radnikDetails = new RadnikDetails();
            panel1.Controls.Clear();
            panel1.Controls.Add(radnikDetails);
        }
    }
}
