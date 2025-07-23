namespace _27._12._2023_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { 
                new DataGridViewTextBoxColumn {HeaderText="First"},
                new DataGridViewTextBoxColumn {HeaderText="Second"},
                new DataGridViewTextBoxColumn {HeaderText="Third"},
            });

            dataGridView1.Rows.AddRange(new DataGridViewRow[] {
                new DataGridViewRow{},
                new DataGridViewRow{},
                new DataGridViewRow{},
            });

            var r = new Random();
            int f = r.Next(0, 3);

            int s = r.Next(0, 3);
            while (f == s)
            {
                s = r.Next(0, 3);
            }

            int t = r.Next(0, 3);
            while (t == f || t == s)
            {
                t = r.Next(0, 3);
            }

            int fCol = r.Next(0, 3);
            int sCol = r.Next(0, 3);
            int tCol = r.Next(0, 3);

            dataGridView1.Rows[0].Cells[fCol].Value = f;
            dataGridView1.Rows[1].Cells[sCol].Value = s;
            dataGridView1.Rows[2].Cells[tCol].Value = t;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            Program.Cells.AddRange(new List<Cell>
            {
                new Cell{Row=0, Column=fCol, Value=f},
                new Cell{Row=1, Column=sCol, Value=s},
                new Cell{Row=2, Column=tCol, Value=t},
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Moras da popunis broj klijenata.");
                return;
            }

            new Thread(() =>
            {
                Program.StartServer(int.Parse(textBox1.Text));
            }).Start();
        }
    }
}
