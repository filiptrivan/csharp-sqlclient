namespace chat_server
{
    public partial class Form1 : Form
    {
        public static List<AdminUser> AdminUsers = new List<AdminUser>
        {
            new AdminUser{email="pera@gmail.com", password="123456", name="Pera", surname="Peric"},
            new AdminUser{email="mara@gmail.com", password="654321", name="Mara", surname="Maric"},
            new AdminUser{email="ft", password="ft", name="Mara", surname="Maric"},
        };

        public Form1()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            dataGridView1.DataSource = Program.Users.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminUser user = AdminUsers.FirstOrDefault(x => x.email == textBox1.Text && x.password == x.password);

            if (user != null)
            {
                var f2 = new Form2();
                f2.SetCurrentUser(user);
                f2.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Program.StartServer();
            }).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.CloseServer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Any(x => char.IsLetter(x) == false))
            {
                MessageBox.Show("Samo slova za email");
                return;
            }
            if (textBox4.Text.Any(x => char.IsLetter(x)) == false)
            {
                MessageBox.Show("Mora slovo");
                return;
            }
            if (textBox4.Text.Any(x => char.IsDigit(x)) == false)
            {
                MessageBox.Show("Mora cifra");
                return;
            }

            if (Program.Users.Any(x => x.email == textBox3.Text))
            {
                MessageBox.Show("Vec postoji");
                return;
            }

            Program.Users.Add(new User
            {
                email = textBox3.Text,
                password = textBox4.Text,
            });
            LoadUsers();
        }
    }
}
