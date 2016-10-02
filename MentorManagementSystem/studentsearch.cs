using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;

namespace MentorManagementSystem
{
    public partial class studentsearch : Form
    {
        public studentsearch()
        {
            InitializeComponent();
        }
        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();
        string querry;
        
        public void bind(string querry)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(querry, con1);
            OleDbDataAdapter ad1 = new OleDbDataAdapter(querry, con1);
            DataTable dt = new DataTable();                  
            ad.Fill(dt);
             dataGridView1.DataSource = dt;
                 }
        private void studentsearch_Load(object sender, EventArgs e)
        {
            label1.Text = "Current Login :" + Global.staffname;
            label2.Text = "Login Time :" + Global.utime;
         
            con1.Open();
            cmd1.Connection = con1;
            
            
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {         

            if (rdoName.Checked == true)
            {
                querry = "select studentid,studentyear,studentmonth,percentage,remarks from attendance where staffid='" + Global.staffid + "'and studentid='" + txt_Find.Text + "'";
                bind(querry);
            }
            else
            {
                querry = "select studentid,studentyear,studentmonth,percentage,remarks from attendance where staffid='" + Global.staffid + "'and studentyear='" + txt_Find.Text + "'";
                bind(querry);
            
            }
        }

        private void txt_Find_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void rdoName_CheckedChanged(object sender, EventArgs e)
        {
            label18.Text = "Enter Name";
        }

        private void rdoID_CheckedChanged(object sender, EventArgs e)
        {
            label18.Text = "Enter Year";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
