using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MentorManagementSystem
{
    public partial class subform : Form
    {
        public subform()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Global.umode = "ADD";
            studentdetails stud_det = new studentdetails();
            stud_det.Show();
         }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            Global.umode = "MODIFY";
            studentdetails stud_det = new studentdetails();
            stud_det.Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
