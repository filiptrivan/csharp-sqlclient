using _27._12._2023_server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _27._12._2023_server.BrokerBazePodataka;

namespace _27._12._2023_klijent
{
    public partial class Form2 : Form
    {
        public User currentUser;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Request(JsonSerializer.Serialize(new Request
            {
                Data = JsonSerializer.Serialize(currentUser),
                Method = "Odjava",
            }));

            Close();
        }
    }
}
