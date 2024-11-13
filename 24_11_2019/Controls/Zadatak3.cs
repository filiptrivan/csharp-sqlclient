using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_11_2019.Controls
{
    public partial class Zadatak3 : UserControl
    {
        Controller _controller;

        public Zadatak3()
        {
            InitializeComponent();
            _controller = new Controller();

            //List<>
            listBox1.DataSource = _controller.GetProfesor2List();
            listBox1.DisplayMember = "Ime";
            listBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Profesor2> profesor2s = listBox1.SelectedItems.Cast<Profesor2>().ToList();

            dataGridView1.DataSource = _controller.GetSubjectsForProfesorIds(profesor2s.Select(x => x.Id).ToList());
        }
    }
}
