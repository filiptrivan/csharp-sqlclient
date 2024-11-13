using Domaci2023.Controls;

namespace Domaci2023
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
                NastavnikListPage nastavnikListPage = new NastavnikListPage();
                pnl_Main.Controls.Add(nastavnikListPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
                throw;
            }
        }

        private void zadatak2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_Main.Controls.Clear();
                NastavnikListComplexPage nastavnikListPage = new NastavnikListComplexPage();
                pnl_Main.Controls.Add(nastavnikListPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
                throw;
            }
        }
    }
}
