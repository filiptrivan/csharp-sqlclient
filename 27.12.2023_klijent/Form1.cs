using _27._12._2023_server;
using System.Text.Json;
using static _27._12._2023_server.BrokerBazePodataka;

namespace _27._12._2023_klijent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User curus = new User { username = textBox1.Text, password = textBox2.Text };
            string res = Program.Request(JsonSerializer.Serialize(new Request
            {
                Data = JsonSerializer.Serialize(curus),
                Method = "Login",
            }));

            if (res == "null")
            {
                MessageBox.Show("Pogr kredenc");
            }
            else if (res == "Vec si se ulogovao sa drugog klijenta.")
            {
                MessageBox.Show("Vec si se ulogovao sa drugog klijenta.");
            }
            else
            {
                var f2 = new Form2();
                f2.currentUser = curus;
                f2.ShowDialog();
            }
        }
    }
}
