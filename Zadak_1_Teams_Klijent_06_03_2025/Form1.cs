namespace Zadak_1_Teams_Klijent_06_03_2025
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
            if (textBox6.Text == null)
            {
                MessageBox.Show("Unesite slovo");
                return;
            }
            else if (textBox6.Text.Length > 1)
            {
                MessageBox.Show("Unesite samo jedno slovo");
                return;
            }

            textBox6.Text = textBox6.Text.ToUpper();

            Program.Request<string>(textBox6.Text);
        }
    }
}
