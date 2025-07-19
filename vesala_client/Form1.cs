
using System.Windows.Forms;

namespace vesala_server
{
    public partial class Form1 : Form
    {
        public List<string> Reci { get; set; } = new List<string>
        {
            "petao",
            "krava",
            "ptica",
            "pseto",
            "kokos",
        };

        public List<Pokusaj> Pokusaji { get; set; } = new();

        public Form1()
        {
            InitializeComponent();

            Random random = new Random();

            label1.Text = Reci[random.Next(Reci.Count - 1)];
        }

        public string Pokusaj(string slovo, string clientId)
        {
            bool hasAlreadyTried = Pokusaji.Any(x => x.Id == clientId);

            if (string.IsNullOrEmpty(slovo))
            {
                return "Unesite slovo";
            }
            if (slovo.Length > 1)
            {
                return "Unesite samo jedno slovo";
            }
            else
            {
                Pokusaj pokusaj;
                if (hasAlreadyTried)
                {
                    pokusaj = Pokusaji.FirstOrDefault(x => x.Id == clientId);
                    pokusaj.BrojPokusaja++;
                }
                else
                {
                    pokusaj = new Pokusaj
                    {
                        Id = clientId,
                        BrojPokusaja = 1,
                        BrojPogodjenih = 0
                    };
                    Pokusaji.Add(pokusaj);
                }

                if (label1.Text.Contains(slovo))
                {
                    pokusaj.BrojPogodjenih++;
                    dataGridView1.Invoke(() =>
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = Pokusaji;
                    });
                    return "Uspesno ste pogodili slovo!";
                }
                else
                {
                    dataGridView1.Invoke(() =>
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = Pokusaji;
                    });
                    return "Niste pogodili slovo!";
                }
            }
        }


    }
}
