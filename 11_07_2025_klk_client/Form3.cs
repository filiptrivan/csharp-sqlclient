using _11_07_2025_klk_server;
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

namespace _11_07_2025_klk_client
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            Request angazovanjaRequest = new Request
            {
                Method = "GetAngazovanja",
                Data = ""
            };
            Request nastavniciRequest = new Request
            {
                Method = "GetNastavnici",
            };
            Request predmetiRequest = new Request
            {
                Method = "GetPredmeti",
            };

            comboBox1.DataSource = JsonSerializer.Deserialize<List<Angazovanje>>(Helper.Request(JsonSerializer.Serialize(angazovanjaRequest)));
            comboBox2.DataSource = JsonSerializer.Deserialize<List<User>>(Helper.Request(JsonSerializer.Serialize(nastavniciRequest)));
            comboBox3.DataSource = JsonSerializer.Deserialize<List<Predmet>>(Helper.Request(JsonSerializer.Serialize(predmetiRequest)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request request = new Request
            {
                Method = "SaveNastavnikPredmet",
                Data = JsonSerializer.Serialize(new NastavnikPredmet
                {
                    TipAngazovanja = comboBox1.SelectedValue as Angazovanje,
                    Nastavnik = comboBox2.SelectedValue as User,
                    Predmet = comboBox3.SelectedValue as Predmet,
                })
            };

            Helper.Request(JsonSerializer.Serialize(request));

            Form2 form2 = Owner as Form2;
            form2.FormInit();
        }
    }
}
