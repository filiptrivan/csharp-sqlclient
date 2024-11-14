using cet16.Controls;

namespace cet16
{
    public partial class Form1 : Form
    {
        Broker broker = new Broker();

        int first = 0;

        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = broker.Getsrb_recList();
            comboBox1.DisplayMember = "naziv";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedIndex = -1;

            comboBox2.DataSource = broker.GetjezikList();
            comboBox2.DisplayMember = "naziv";
            comboBox2.ValueMember = "id";
            comboBox2.SelectedIndex = -1;

            comboBox3.DataSource = Enum.GetNames<Skracenica>();
            comboBox3.SelectedIndex = -1;

            first = 1;
        }

        private void LoadTable()
        {
            if (first >= 1)
            {
                dataGridView1.DataSource = broker.GetprevodList((long?)comboBox1.SelectedValue, (long?)comboBox2.SelectedValue);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                Details details = new Details((long)comboBox1.SelectedValue, (long)comboBox2.SelectedValue);
                details.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            broker.Insertsrb_rec(new srb_rec
            {
                naziv = "test2", 
                napravljen = dateTimePicker1.Value,
                skracenica = Enum.Parse<Skracenica>((string)comboBox3.SelectedValue)
            });
        }
    }
}
