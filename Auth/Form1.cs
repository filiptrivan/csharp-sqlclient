using Auth.Controlls;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace Auth
{
    public partial class Form1 : Form
    {
        User currentUser;

        public Form1()
        {
            InitializeComponent();

            
        }

        private int wrongLoginCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Controller controller = new Controller();

                User user = controller.Login(textBox1.Text, textBox2.Text);
                currentUser = user;

                pnl_Main.Controls.Clear();

                HomePage homePage = new HomePage();

                homePage.SetCurrentUser(user);

                wrongLoginCount = 0;

                pnl_Main.Controls.Add(homePage);
            }
            catch (Exception ex)
            {
                if (ex is BusinessException && wrongLoginCount < 3)
                {
                    MessageBox.Show(ex.Message);
                    wrongLoginCount++;
                }
                else
                {
                    MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
                }
            }
        }

        private void profesorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnl_Main.Controls.Clear();
                HomePage homePage = new HomePage();

                homePage.SetCurrentUser(currentUser);

                pnl_Main.Controls.Add(homePage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
            }
        }
    }
}
