using _02_07_2025_server;
using System.Text.Json;

namespace _02_07_2025_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User loginUser = new User
            {
                Email = textBox1.Text,
                Password = textBox2.Text
            };

            string response = Helper.Request(new Request
            {
                Data = JsonSerializer.Serialize(loginUser),
                MethodName = "Login",
            });

            if (response == "true")
            {
                MessageBox.Show(Text = "Uspesno ste se prijavili!", "Prijava", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Text = "Pogresni kredencijali.", "Prijava", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
