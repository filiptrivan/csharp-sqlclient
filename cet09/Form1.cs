using cet09.Controls;

namespace cet09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zadatakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Controls.Clear();
                Main main = new Main();
                Controls.Add(main);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
