using chat_server;
using System.Text.Json;

namespace chat_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Request(new Request
            {
                Data = JsonSerializer.Serialize(new User
                {
                    email = textBox1.Text,
                    password = textBox2.Text,
                    isLoggedIn = true,
                }),
                Method = "Login",
            });

            Program.Request(new Request
            {
                Method = "GetUsers",
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Request(new Request
            {
                Data = JsonSerializer.Serialize(new Poruka
                {
                    poruka = textBox3.Text,
                }),
                Method = "Poruka",
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Request(new Request
            {
                Data = JsonSerializer.Serialize(new Poruka
                {
                    Za = (string)comboBox1.SelectedValue,
                    poruka = textBox4.Text,
                }),
                Method = "Poruka",
            });
        }

        public void SetUsers(List<User> users)
        {
            comboBox1.Invoke(() =>
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = users.ToList();
                comboBox1.DisplayMember = "email";
                comboBox1.ValueMember = "email";
                comboBox1.SelectedIndex = -1;
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new List<User>();
            comboBox1.DisplayMember = "email";
            comboBox1.ValueMember = "email";
            comboBox1.SelectedIndex = -1;

            Program.Request(new Request
            {
                Method = "GetUsers"
            });
        }
    }
}
