using Kolokvijum2023Termin1.Controls;

namespace Kolokvijum2023Termin1
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
                panel1.Controls.Clear();
                PredmetInsertPage predmetInsertPage = new PredmetInsertPage();
                panel1.Controls.Add(predmetInsertPage);
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
                panel1.Controls.Clear();
                PredmetListPage predmetInsertPage = new PredmetListPage();
                panel1.Controls.Add(predmetInsertPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
            }
        }
    }
}
