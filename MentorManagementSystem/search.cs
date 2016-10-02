using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MentorManagementSystem
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }
        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbDataReader dr1;
        string querry, sem=null,exam=null,staffid;
       
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sem = "sem2";
            panel6.Enabled = true;
            rdobutt(false);
           
            bindquerry();
        }
        public void bind(string querry)
        {
             OleDbDataAdapter ad = new OleDbDataAdapter(querry, con1);
            OleDbDataAdapter ad1 = new OleDbDataAdapter(querry, con1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void rdobutt(bool value)
        { 
          radioButton6.Checked=value;
          radioButton7.Checked=value;
          radioButton8.Checked=value;
          radioButton9.Checked=value;
          radioButton10.Checked=value;
        }
        private void search_Load(object sender, EventArgs e)
        {
            con1.Open();
            cmd1.Connection = con1;
            cmd1.CommandText = "SELECT staffname from login";
            dr1 = cmd1.ExecuteReader();   
            while(dr1.Read())
            {
              comboBox1.Items.Add(dr1.GetString(0));
            }
           
            dr1.Close();


        }
        public void bindquerry()
        { 
            
            querry = "select studentid,studentname,exam,subjectfailed,faildetails from "+sem+" where staffid='" + staffid + "'";
            bind(querry);
        }
        public void bindquerryexam()
        {
           
            querry = "select studentid,studentname,subjectfailed,faildetails from " + sem + " where staffid='" + staffid + "' and exam='" + exam + "'";
            bind(querry);
        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            sem="sem1";
            panel6.Enabled = true;
            rdobutt(false);
            bindquerry();
           
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sem = "sem3";
            panel6.Enabled = true;
            rdobutt(false);
           
            bindquerry();
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sem = "sem4";
            panel6.Enabled = true;
            rdobutt(false);
           
            bindquerry();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

            sem = "sem5";
            panel6.Enabled = true;
            rdobutt(false);
           
            bindquerry();

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            exam = "UnitTest1";
            bindquerryexam();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

            exam = "UnitTest2";
            bindquerryexam();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            exam = "UnitTest3";
            bindquerryexam();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

            exam = "Model";
            bindquerryexam();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

            exam = "semester";
            bindquerryexam();
        }
        public void p5rdo(bool value)
        {
            radioButton1.Checked = value;

            radioButton2.Checked = value;

            radioButton3.Checked = value;

            radioButton4.Checked = value;
            radioButton5.Checked = value;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                cmd1.CommandText = "SELECT staffid from login where staffname='" + comboBox1.Text + "'";
                dr1 = cmd1.ExecuteReader();
                dr1.Read();
                staffid = dr1.GetString(0);
                dr1.Close();
           
            p5rdo(false);
            rdobutt(false);
            panel6.Enabled = false;
            panel5.Enabled = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
