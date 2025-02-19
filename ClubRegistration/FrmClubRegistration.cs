using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubRegistration
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int Age;
        private long studID;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void btn_Register_Click(object sender, EventArgs e)
        {
            Age = Convert.ToInt32(txtAge.Text);
            studID = Convert.ToInt64(txtStudentId.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Gender = txtGender.Text;
            Program = txtProgram.Text;
            clubRegistrationQuery.RegisterStudent(studID, FirstName, MiddleName, LastName, Age, Gender, Program);
            RefreshListOfClubMembers();
            ClearTextFields();

        }


        public void ClearTextFields()
        {
            txtStudentId.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtProgram.Clear();
            txtAge.Clear();
            txtGender.Clear();

        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView.DataSource = clubRegistrationQuery.bindingSource;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
