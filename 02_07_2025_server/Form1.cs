
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace _02_07_2025_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadSrpskaRecTable();
            LoadUserTable();
        }

        public void LoadUserTable()
        {
            dataGridView2.DataSource = Program.GetUsers();
        }

        public void LoadSrpskaRecTable()
        {
            dataGridView1.DataSource = Program.GetSrpskeReci();
        }
    }
}
