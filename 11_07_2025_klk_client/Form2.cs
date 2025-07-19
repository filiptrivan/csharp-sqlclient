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
    public partial class Form2 : Form
    {
        public string CurrentUserEmail { get; set; } = "admin";
        public List<NastavnikPredmet> NastavnikPredmets { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        public void FormInit()
        {
            Request request = new Request
            {
                Method = "GetPredmetiZaNastavnika",
                Data = $"{CurrentUserEmail}"
            };

            var reqString = JsonSerializer.Serialize(request);
            var response = Helper.Request(reqString);
            NastavnikPredmets = JsonSerializer.Deserialize<List<NastavnikPredmet>>(response);
            dataGridView1.DataSource = NastavnikPredmets;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            NastavnikPredmet nastavnikPredmet = NastavnikPredmets[rowIndex];

            Request request = new Request
            {
                Method = "GetNastavniciZaPredmet",
                Data = $"{nastavnikPredmet.Predmet.Id}"
            };
            var reqString = JsonSerializer.Serialize(request);
            var response = Helper.Request(reqString);
            dataGridView2.DataSource = JsonSerializer.Deserialize<List<User>>(response);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog(this);
        }
    }
}
