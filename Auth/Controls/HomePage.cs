using Auth.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth.Controlls
{
    public partial class HomePage : UserControl
    {
        private Controller _controller;
        private User currentUser = null;

        public HomePage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _controller = new Controller();

            comboBox1.DataSource = _controller.GetLevels();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            lb_Angazovanja.DataSource = _controller.GetSubjects();
            lb_Angazovanja.DisplayMember = "Name";
            lb_Angazovanja.ValueMember = "Id";

            dgv_Profesori.DataSource = _controller.GetProfesors();
        }


        public void SetCurrentUser(User user)
        {
            currentUser = user;
            label1.Text = $"{user.Name} {user.Surname}";
        }

        private void btn_AddProfesor_Click(object sender, EventArgs e)
        {
            Profesor profesor = new Profesor
            {
                Name = txt_Name.Text,
                Surname = txt_Surname.Text,
                LevelId = (long)comboBox1.SelectedValue,
                UserEmail = currentUser.Email,
            };

            List<Subject> selectedSubjects = lb_Angazovanja.SelectedItems.Cast<Subject>().ToList();

            _controller.InsertProfesor(profesor, selectedSubjects);

            List<ProfesorSubject> profesorSubjects = _controller.GetProfesorSubjects(profesor.Id);

            List<Subject> subjects = _controller.GetSubjects(profesorSubjects.Select(x => x.SubjectId).ToList());

            dataGridView1.DataSource = new BindingList<Subject>(subjects);

            MessageBox.Show("Uspesno ste dodali profesora.");
        }

        private void dgv_Profesori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long id = Convert.ToInt64(dgv_Profesori.Rows[dgv_Profesori.CurrentRow.Index].Cells["Id"].Value);

            if (e.ColumnIndex == 0)
            {
                ProfesorDetailsPage profesorDetailsPage = new ProfesorDetailsPage(id);
                Controls.Clear();
                Controls.Add(profesorDetailsPage);
                profesorDetailsPage.Dock = DockStyle.Fill;
            }
            else if (e.ColumnIndex == 1)
            {
                //_controller.DeleteProfesor(id);
            }
        }
    }
}
