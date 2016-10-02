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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }
       

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            label6.Text = "Current Login :" + Global.staffname;
            label7.Text = "Login Time :" + Global.utime;
            School._class.cLsImageList.SetListView(lvShortcuts, "Enter Marks", 0, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Enter Attendance", 1, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Add Batch", 2, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Student Details", 3, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Add Staff", 4, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Enter Elective details", 5, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Search", 6, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Mentor wise Search", 7, i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts, "Student Attendence Setup", 11, i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts, "Examination Setup", 8, i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts, "Exam Detail", 9, i64x64);
            School._class.cLsImageList.SetListView(lvShortcuts, "Exit", 10, i64x64);
            //Contents For Report List
            School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);
            //School._class.cLsImageList.SetListView(lvShortcuts2, "Report1", 12, this.i64x64);

        }
    

        private void lvShortcuts_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Forms_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

   

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void lvShortcuts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lvShortcuts_DoubleClick_1(object sender, EventArgs e)
        {
            switch (lvShortcuts.Items[lvShortcuts.FocusedItem.Index].SubItems[0].Text)
            {
                case "Enter Attendance":

                    studentattendance stud_atten = new studentattendance();
                    stud_atten.Show();
                    break;
                case "Search":

                    studentsearch stu_search = new studentsearch();
                    stu_search.Show();
                    break;

                case "Mentor wise Search":

                    search men_search = new search();
                    men_search.Show();
                    break; 
                   

                case "Student Details":
                    subform sub_form = new subform();
                    sub_form.Show();

                    //studentdetails stud_det = new studentdetails();
                    //stud_det.Show();
                    break;

                case "Add Batch":
                    addbatch add_batch = new addbatch();
                    add_batch.Show();
                    break;

                case "Enter Marks":
                    Entermarks enter_marks = new Entermarks();
                    enter_marks.Show();
                    break;


                case "Enter Elective details":
                    electivedetails e_details = new electivedetails();
                    e_details.Show();
                    break;



                case "Add Staff":
                    addstaff add_staff = new addstaff();
                    add_staff.Show();
                    break;

                case "Exit":
                    DialogResult ret;
                    ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (ret == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        private void lvShortcuts2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}