using System.Text.Json;
using vesala2_server;

namespace vesala2_client
{
    public partial class Form1 : Form
    {
        public int brPok = 0;
        public List<string> koriscSlova = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = Program.Request(new Request
            {
                Data = JsonSerializer.Serialize(new Pokusaj
                {
                    Slovo = textBox6.Text,
                }),
                Method = "Pogodi"
            });

            if (res != "null")
            {
                Pokusaj rezultat = JsonSerializer.Deserialize<Pokusaj>(res);

                if (rezultat.IndexSlova == 0)
                {
                    textBox1.Text = rezultat.Slovo;
                }
                if (rezultat.IndexSlova == 1)
                {
                    textBox2.Text = rezultat.Slovo;
                }
                if (rezultat.IndexSlova == 2)
                {
                    textBox3.Text = rezultat.Slovo;
                }
                if (rezultat.IndexSlova == 3)
                {
                    textBox4.Text = rezultat.Slovo;
                }
                if (rezultat.IndexSlova == 4)
                {
                    textBox5.Text = rezultat.Slovo;
                }
            }

            brPok++;
            koriscSlova.Add(textBox6.Text);

            label1.Text = $"Koriscena slova: {string.Join(", ", koriscSlova)}";
            label2.Text = $"Preost br pok: {brPok}";
        }
    }
}
