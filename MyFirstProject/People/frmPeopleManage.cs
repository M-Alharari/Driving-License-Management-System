using MyFirstProject.Global_Classes;
using ProjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyFirstProject
{
    public partial class frmPeopleManage : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

      

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GendorCaption", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");

        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgPeople.DataSource = _dtPeople;
            lblRecord.Text = dgPeople.Rows.Count.ToString();
        }


        public frmPeopleManage()
        {
            InitializeComponent();
        }

       

  

        private void frmPeopleManage_Load(object sender, EventArgs e)
        {
            _RefreshPeoplList();

            dgPeople.DataSource = _dtPeople;
            cbPeopleFilter.SelectedIndex = 0;
            lblRecord.Text = dgPeople.Rows.Count.ToString();
            if (dgPeople.Rows.Count > 0)
            {
                dgPeople.Columns[0].HeaderText = "Person ID";
                dgPeople.Columns[0].Width = 110;


                dgPeople.Columns[1].HeaderText = "National No.";
                dgPeople.Columns[1].Width = 120;


                dgPeople.Columns[2].HeaderText = "First Name";
                dgPeople.Columns[2].Width = 120;

                dgPeople.Columns[3].HeaderText = "Second Name";
                dgPeople.Columns[3].Width = 140;


                dgPeople.Columns[4].HeaderText = "Third Name";
                dgPeople.Columns[4].Width = 120;

                dgPeople.Columns[5].HeaderText = "Last Name";
                dgPeople.Columns[5].Width = 120;

                dgPeople.Columns[6].HeaderText = "Gendor";
                dgPeople.Columns[6].Width = 120;

                dgPeople.Columns[7].HeaderText = "Date Of Birth";
                dgPeople.Columns[7].Width = 140;

                dgPeople.Columns[8].HeaderText = "Nationality";
                dgPeople.Columns[8].Width = 120;


                dgPeople.Columns[9].HeaderText = "Phone";
                dgPeople.Columns[9].Width = 120;


                dgPeople.Columns[10].HeaderText = "Email";
                dgPeople.Columns[10].Width = 170;


            }

        }

        private void cbPeopleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbPeopleFilter.Text != "None");

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //DataBack?.Invoke();
            Form frmAddNewPerson = new frmAddNewPerson();
            frmAddNewPerson.ShowDialog();
            _RefreshPeoplList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewPerson frmAddNewPerson = new frmAddNewPerson((int)dgPeople.CurrentRow.Cells[0].Value);
            frmAddNewPerson.ShowDialog();
            _RefreshPeoplList();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbPeopleFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lblRecord.Text = dgPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecord.Text = dgPeople.Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void showDeatilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgPeople.CurrentRow.Cells[0].Value;
            Form frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewPerson((int)dgPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgPeople_DoubleClick(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails((int)dgPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        { 
        }

        private void dgPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form frm = new frmListDrivers();
            frm.ShowDialog();


        }
    }
}
