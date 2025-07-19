using _11_07_2025_klk_server;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _11_07_2025_klk_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            User body = new User
            {
                Username = username,
                Password = password
            };
            Request request = new Request
            {
                Data = JsonSerializer.Serialize(body),
                Method = "Login"
            };
            string result = Helper.Request(JsonSerializer.Serialize(request));

            if (result == "True")
            {
                var form2 = new Form2();
                form2.CurrentUserEmail = username;
                form2.FormInit();
                form2.ShowDialog();
            }
        }
    }
}
