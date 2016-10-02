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
    public partial class electivedetails : Form
    {
        public electivedetails()
        {
            InitializeComponent();
        }
        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        int semno;
        OleDbDataReader dr1, dr2;
        string exam, querry, sem, studentid;
        int month = System.DateTime.Now.Month;
        int year = System.DateTime.Now.Year;
        private void label10_Click(object sender, EventArgs e)
        {

        }
        public void findyear(int y)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            querry = "select studentid,electivename from electivetable where semno='" + semno + "'";
            bind(querry);
            cmd1.CommandText = "SELECT batchno,studentname,studentid from addbatch where staffid='" + Global.staffid + "'";
            dr1 = cmd1.ExecuteReader();
            cmd2.CommandText = "SELECT electivename from electivedetails where semno='" + semno + "'";
            dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
              listBox2.Items.Add(dr2.GetString(0));
            }
            dr2.Close();
            while (dr1.Read())
            {
                if ((month > 5 && month < 13))
                {
                    if ((year - Convert.ToInt32(dr1.GetString(0)) == y - 1))
                    {
                       
                       
                        listBox1.Items.Add(dr1.GetString(2));
                   
                    }
                    else if (month > 0 && month < 6)
                    {
                        if (year - dr1.GetInt32(0) == y)
                        {                        
                            listBox1.Items.Add(dr1.GetString(2) );
                         }
                    }

                }
            }

            dr1.Close();

        }
        public void bind(string querry)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(querry, con1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void electivedetails_Load(object sender, EventArgs e)
        {
            label2.Text = "Current Login :" + Global.staffname;
            label6.Text = "Login Time :" + Global.utime;
            con1.Open();
            cmd1.Connection = con1;
            cmd2.Connection = con1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            semno = 4;
            findyear(2);
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            semno = 5;
            findyear(3);
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            cmd1.CommandText = "insert into electivetable values('" + listBox1.Text  + "', '" + listBox2.Text  + "', '"+semno+"')";
            cmd1.ExecuteNonQuery();
            bind(querry);
            MessageBox.Show("Data Saved Suceesfully", "Mentor Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {   
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            listBox2.Items.Clear();
            listBox1.Items.Clear();
        
           

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
