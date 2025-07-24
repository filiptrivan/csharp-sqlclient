using _13._07._2025_server;
using System.Text.Json;
using System.Windows.Forms;

namespace _13._07._2025_klijent
{
    public partial class Form1 : Form
    {
        public Nastavnik lastTry;

        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
        }

        internal void SetCurrentUser()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastTry = new Nastavnik
            {
                Name = textBox1.Text,
                Password = textBox2.Text
            };
            Program.Request(new Request
            {
                Data = JsonSerializer.Serialize(lastTry),
                Method = "Login",
            });
        }

        public void SetLoginInvisible()
        {
            panel1.Invoke(() =>
            {
                panel1.Visible = false;
            });

            panel2.Invoke(() =>
            {
                panel2.Visible = true;
            });
        }

        public void SetPredmetsTable(List<Predmet> predmets)
        {
            dataGridView1.Invoke(() =>
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = predmets;
            });
        }

        public void SetNastavniksTable(List<Nastavnik> nastavniks)
        {
            dataGridView2.Invoke(() =>
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = nastavniks;
            });
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            long predmetId = (long)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            Program.Request(new Request
            {
                Data = predmetId.ToString(),
                Method = "GetNastavniksForPredmet"
            });
        }

        private void SetNastavniksCombobox(List<Nastavnik> nastavniks)
        {
            //comboBox1.Invoke(() =>
            //{
            //    comboBox1.DataSource = 
            //});
        }
        private void SetPredmetsCombobox(List<Predmet> predmets)
        {

        }
        private void SetAngazovanjasCombobox(List<TipAngazovanja> tipAngazovanjas)
        {

        }
    }
}
