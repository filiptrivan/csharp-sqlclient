using _24_11_2019.Controls;

namespace _24_11_2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zadatak1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_Main.Controls.Clear();
                Zadatak1 zadatak1 = new Zadatak1();
                pnl_Main.Controls.Add(zadatak1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
            }
        }

        private void zadatak2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_Main.Controls.Clear();
                Zadatak2 zadatak2 = new Zadatak2();
                pnl_Main.Controls.Add(zadatak2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
            }
        }

        private void zadatak3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_Main.Controls.Clear();
                Zadatak3 zadatak3 = new Zadatak3();
                pnl_Main.Controls.Add(zadatak3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
            }
        }
    }
}
