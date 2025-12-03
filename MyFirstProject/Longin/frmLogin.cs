using MyFirstProject.Global_Classes;
using ProjectBusinessLayer;
using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstProject
{
    public partial class frmLogin : Form
    {
        private bool btnClicked = false;
        public frmLogin()
        {
            InitializeComponent();
           
        }

        

 
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;

            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }
 
       

       

        private void btnClose_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              string Password = clsDataHelper.ComputeHash(txtPassword.Text.Trim());
                clsUser User = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), Password);
                if (User != null)
                {
                    if (chkRememberMe.Checked)
                    {
                        clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    }
                    else
                    {
                        clsGlobal.RememberUsernameAndPassword("", "");

                    }
                    if (!User.IsActive)
                    {
                        txtUserName.Focus();
                        MessageBox.Show("Your account is not active, Contact Admin.", "In active account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    clsGlobal.CurrentUser = User;
                    this.Hide();
                    frmMain frm = new frmMain(this);
                    frm.ShowDialog();
                }
                else
                {
                    txtUserName.Focus();
                    MessageBox.Show("Invalid Username/Password.", "Wrong credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
           
        }
    }
}