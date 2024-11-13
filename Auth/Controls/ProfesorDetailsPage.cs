using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth.Controls
{
    public partial class ProfesorDetailsPage : UserControl
    {
        private Controller _controller;
        private Profesor currentProfesor;

        public ProfesorDetailsPage(long profesorId)
        {
            InitializeComponent();

            _controller = new Controller();

            currentProfesor = _controller.GetProfesors().Where(x => x.Id == profesorId).SingleOrDefault();
            txt_Name.Text = currentProfesor.Name;
            txt_Surname.Text = currentProfesor.Surname;

            comboBox1.DataSource = _controller.GetLevels();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedValue = currentProfesor.LevelId;

            List<Subject> subjects = _controller.GetSubjects();
            listBox1.DataSource = subjects;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";

            List<long> selectedItemIds = _controller.GetProfesorSubjects(profesorId).Select(x => x.SubjectId).ToList();
            for (int i = 0; i < subjects.Count; i++)
            {
                if (selectedItemIds.Contains(subjects[i].Id))
                {                
                    listBox1.SetSelected(i, true);
                }
                else
                {
                    listBox1.SetSelected(i, false);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profesor profesor = new Profesor
            {
                Id = currentProfesor.Id,
                Name = txt_Name.Text,
                Surname = txt_Surname.Text,
                LevelId = (long)comboBox1.SelectedValue,
            };

            _controller.UpdateProfesor(profesor, listBox1.SelectedItems.Cast<Subject>().ToList());
        }
    }
}
