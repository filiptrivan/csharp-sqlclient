using System.Linq;

namespace Domaci2024
{
    public partial class Form1 : Form
    {
        List<Radnik> radniks = new List<Radnik>
        {
            new Radnik{ime = "f", prezime = "t", email="f", lozinka = "t"},
        };

        public Form1()
        {
            InitializeComponent();
        }

        int wrongUserCount = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Radnik radnik = radniks.Where(x => x.email == textBox1.Text && x.lozinka == textBox2.Text).SingleOrDefault();

            if (radnik == null)
            {
                wrongUserCount++;

                if (wrongUserCount == 3)
                {
                    Application.Exit();
                }
            }
            else
            {
                Main main = new Main(radnik);
                Hide();
                main.ShowDialog();
                Application.Exit();
            }
        }
    }

    public class Radnik
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string lozinka { get; set; }
    }
}
