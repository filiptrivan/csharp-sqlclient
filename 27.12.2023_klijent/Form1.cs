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

            dataGridView1.Rows.AddRange(new DataGridViewRow[]
            {
                new DataGridViewRow(),
                new DataGridViewRow(),
                new DataGridViewRow(),
            });
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            string res = Program.Request(JsonSerializer.Serialize(new Request
            {
                Data = JsonSerializer.Serialize(new Cell
                {
                    Row = row,
                    Column = col,
                }),
                Method = "Pogodi"
            }));

            if (res == "null")
            {
                MessageBox.Show("Promasaj");
                dataGridView1.Rows[row].Cells[col].Value = -1;
            }
            else
            {
                MessageBox.Show("Pogodak");
                Cell guessedCell = JsonSerializer.Deserialize<Cell>(res);
                dataGridView1.Rows[row].Cells[col].Value = guessedCell.Value;
            }
        }
    }
}
