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
    public partial class studentattendance : Form
    {
        public studentattendance()
        {
            InitializeComponent();
        }
        public string staffid = "";

         OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
          OleDbCommand cmd1 = new OleDbCommand();
         
          OleDbDataReader dr1;
          string studentid,querry;
          int month = System.DateTime.Now.Month;
          int year = System.DateTime.Now.Year;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        public void bind(string querry)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(querry, con1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt; 
        
        
        }
        private void studentattendance_Load(object sender, EventArgs e)
        
           {
               label12.Text = "Current Login :" + Global.staffname;
               label13.Text = "Login Time :" + Global.utime;
            con1.Open();
            cmd1.Connection = con1;                       
            querry = "select * from attendance where staffid='"+Global.staffid+"'";
            bind(querry);

            
            
        }
        public void findyear(int y)
        {
            
            comEname.Items.Clear();
   
            cmd1.CommandText = "SELECT batchno,studentname from addbatch where staffid='" +Global.staffid  + "'";
            dr1 = cmd1.ExecuteReader();           
            while (dr1.Read()) 
            {
               
                
                    if ((month > 5 && month < 13))
                    {
                        if ((year -Convert.ToInt32(dr1.GetString(0)) == y-1))
                        {
                            comEname.Items.Add(dr1.GetString(1));
                            querry = "select * from attendance where staffid='" + Global.staffid + "' and studentyear='"+Convert.ToString (year-(y-1))+"'";
                            bind(querry);

                        }
                        else if (month > 0 && month < 6)
                        {
                            if (year - dr1.GetInt32(0) == y)
                            {
                                comEname.Items.Add(dr1.GetString(1));
                                querry = "select * from attendance where staffid='" + Global.staffid + "' and studentyear='" + Convert.ToString(year-y) + "'";
                                bind(querry);

                            }
                        }
                    

                }
            }

            dr1.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            findyear(1);

        }

 


        
        private void groupBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            findyear(2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            findyear(3);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            cmd1.CommandText = "insert into attendance values('" + studentid + "', '"+staffid+"', '" + comboBox1.SelectedItem + "','" + year + "',  '" + txtperc.Text  + "','" + txtRemarks.Text  + "')";
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Data Saved Suceesfully", "Mentor Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            bind(querry);
        
        }

        private void comEname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd1.CommandText = "SELECT studentid from addbatch where studentname='" + comEname.SelectedItem  + "'";
            dr1 = cmd1.ExecuteReader();
            dr1.Read();
            studentid = dr1.GetString(0);
            dr1.Close();
          

            
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            bind(querry);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtperc.Text  = "";
            txtRemarks.Text  = "";


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
