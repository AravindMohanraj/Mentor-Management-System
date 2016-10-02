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
    public partial class Entermarks : Form
    {
        public Entermarks()
        {
            InitializeComponent();
            subjectdetails = new Label[] { label12 , label13 , label14 , label15 , label16  };
        }
        string sflag="undone";
        int semno;
        public Label[] subjectdetails;

        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
      
        OleDbDataReader dr1,dr2;
        string exam, querry,sem,studentid;
        int month = System.DateTime.Now.Month;
        int year = System.DateTime.Now.Year;
        private void Entermarks_Load(object sender, EventArgs e)
        {
            label18.Text = "Current Login :" + Global.staffname;
            label19.Text = "Login Time :" + Global.utime;
            con1.Open();
            cmd1.Connection = con1;
            cmd2.Connection = con1;
                       querry = "select studentid,studentname from addbatch where staffid='" + Global.staffid + "'";
          
            bind(querry);
            radioButton3.Checked = true; 

        }
        public void bind(string querry)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(querry, con1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        public void findyear(int y)
        {

            comEname.Items.Clear();
            cmd1.CommandText = "SELECT batchno,studentname,studentid from addbatch where staffid='" + Global.staffid + "'";
            dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {


                if ((month > 5 && month < 13))
                {
                    if ((year - Convert.ToInt32(dr1.GetString(0)) == y - 1))
                    {
                        comEname.Items.Add(dr1.GetString(2));
                       
                        querry = "select studentname,studentid from addbatch where staffid='" + Global.staffid + "' and batchno='" + Convert.ToString(year - (y - 1)) + "'";
                        bind(querry);

                    }
                    else if (month > 0 && month < 6)
                    {
                        if (year - dr1.GetInt32(0) == y)
                        {
                            comEname.Items.Add(dr1.GetString(1));
                            querry = "select  studentname,studentid from addbatch where staffid='" + Global.staffid + "' and batchnor='" + Convert.ToString(year - y) + "'";
                            bind(querry);
                        }
                    }

                }
            }

            dr1.Close();
          
        }
        public void filllabel(string querry,int semno)
        {
            cmd1.CommandText = querry;
            dr1 = cmd1.ExecuteReader();          
            int f,i=0;
            if (semno == 5)         
                f = 2;       
           else if (semno == 4)
            f = 3;   
            else
                f = 4;
                       
           try
            {
                while (dr1.Read())
                {
                   if(i<=f)
                    subjectdetails[i++].Text = dr1.GetString(0);
                   else
                       subjectdetails[i++].Text = "Elective";
                 }
            }
            catch (Exception exp)
            {
               MessageBox.Show(exp.Message);
            }
            dr1.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            findyear(1);
            semno=1;
            filllabel("select firstsem from subjectdetails", semno );
            sem = "sem1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            findyear(1);
            semno=2;
            filllabel("select secondsem from subjectdetails",semno );
            sem = "sem2";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            findyear(2);
            semno=3;
            filllabel("select thirdsem from subjectdetails",semno);
            sem = "sem3";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            findyear(2);
             semno=4;
            filllabel("select fourthsem from subjectdetails",semno );
            sem = "sem4";
           
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            findyear(3);
            semno=5;
            filllabel("select fifthsem from subjectdetails",semno );
            sem = "sem5";
        }

        private void comEname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd1.CommandText = "SELECT studentname from addbatch where studentid='" + comEname.Text  + "'";
            dr1 = cmd1.ExecuteReader();
            try
            {
                dr1.Read();
                studentid = dr1.GetString(0);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            
            }
                
                dr1.Close();

            cmd2.CommandText = "select electivename from electivetable where studentid='"+comEname.Text+"'and semno='"+Convert.ToString(semno)+"'";
                dr2 = cmd2.ExecuteReader();
        
        
            if (semno == 5)
            {
               
                int j = 3;
                
                while (dr2.Read())
                {
                    if(j<5)
                    subjectdetails[j++].Text = dr2.GetString(0);
                }
                    dr2.Close(); 
        
            }
             else if (semno == 4)
            {
               
                int j = 4;
             
                while (dr2.Read())
                {
                    if(j<5)
                    subjectdetails[j++].Text = dr2.GetString(0);
                }
                    dr2.Close();
             }

        
        
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int faildedsub=0;
            string subfail="NILL";
            if (Convert.ToInt16(textBox1.Text) < 50)
            {
                faildedsub++;
                if(subfail=="NILL")
                    subfail = subjectdetails[0].Text;
                else
                    subfail = subfail + "," + subjectdetails[0].Text;
               
            }
                if (Convert.ToInt16(textBox2.Text) < 50)
                {
                    faildedsub++;
                    if (subfail == "NILL")
                        subfail = subjectdetails[1].Text;
                    else
                        subfail = subfail + "," + subjectdetails[1].Text;
                }
                if (Convert.ToInt16(textBox3.Text) < 50)
                {
                    faildedsub++;
                    if (subfail == "NILL")
                        subfail = subjectdetails[2].Text;
                    else
                        subfail = subfail + "," + subjectdetails[2].Text;
                }
                if (Convert.ToInt16(textBox4.Text) < 50)
                {
                    faildedsub++;
                    if (subfail == "NILL")
                        subfail = subjectdetails[3].Text;
                    else
                        subfail = subfail + "," + subjectdetails[3].Text;
                }
                if (Convert.ToInt16(textBox5.Text) < 50)
                {
                    faildedsub++;
                    if (subfail == "NILL")
                        subfail = subjectdetails[4].Text;
                    else
                        subfail = subfail + "," + subjectdetails[4].Text;
                }
                cmd1.CommandText = "insert into " + sem + " values('" + studentid + "', '" + comEname.Text + "', '" + Global.staffid + "','" + textBox1.Text + "',  '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + exam + "','" + faildedsub + "','"+subfail+"','" + textBox6.Text + "','" + textBox7.Text + "','" + sflag + "')";
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Data Saved Suceesfully", "Mentor Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
           
        }

        
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            exam = "UnitTest1";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

            exam = "UnitTest2";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            exam = "UnitTest3";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

            exam = "Model";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

            exam = "semester";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            sflag = "done";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";



        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            bind(querry);
        }
    }
}
