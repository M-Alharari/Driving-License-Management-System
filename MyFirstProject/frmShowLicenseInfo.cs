using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstProject
{
    public partial class frmShowLicenseInfo : Form
    {
        private int _LinceseID;
        public frmShowLicenseInfo(int linceseID)
        {
            InitializeComponent();
            _LinceseID = linceseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_LinceseID);
            
        }
    }
}
