namespace _27._12._2023_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
