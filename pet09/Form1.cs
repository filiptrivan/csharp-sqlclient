namespace pet09
{
    public partial class Form1 : Form
    {
        Broker broker = new Broker();

        private int first = 0;
        public Form1()
        {
            InitializeComponent();

            comboBox1.DataSource = broker.GetosobaList();
            comboBox1.DisplayMember = "ime";
            comboBox1.ValueMember = "jmbg";
            comboBox1.SelectedIndex = -1;

            comboBox2.DataSource = broker.GetinstrumentList();
            comboBox2.DisplayMember = "naziv";
            comboBox2.ValueMember = "id";
            comboBox2.SelectedIndex = -1;

            label1.Text = "0";

            first = 1;
        }

        public void LoadTable()
        {
            if (first == 1)
            {
                List<long> instrumentids = broker.GetosobainstrumentIdsForosoba((string)comboBox1.SelectedValue).Select(x => x.instrumentid).ToList();
                dataGridView1.DataSource = broker.GetinstrumentList(instrumentids);
                label1.Text = instrumentids.Count.ToString();
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (first == 1)
            {
                List<long> instrumentids = broker.GetosobainstrumentIdsForosoba((string)comboBox1.SelectedValue).Select(x => x.instrumentid).ToList();
                if (instrumentids.Contains((long)comboBox2.SelectedValue))
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                DeleteOsoba f = new DeleteOsoba((long)comboBox2.SelectedValue);
                f.ShowDialog();
            }
        }
    }
}
