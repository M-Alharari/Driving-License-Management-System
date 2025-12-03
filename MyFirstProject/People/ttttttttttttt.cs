using ProjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstProject.People
{
    public partial class ttttttttttttt : Form
    {
        public ttttttttttttt()
        {
            InitializeComponent();
        }

        private void ttttttttttttt_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPerson.GetAllPeople();
        }
    }
}
