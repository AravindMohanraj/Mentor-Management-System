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
    public partial class addstaff : Form
    {
        public addstaff()
        {
            InitializeComponent();
        }
        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
           if (txtPass.Text == txtrepas.Text)
            {
               cmd1.CommandText = "insert into login values('" + txtuname.Text   + "', '" + txtPass.Text  + "', '" + txtsname.Text  + "','" +txtsid.Text+ "','f')";
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Data Saved Suceesfully", "Mentor Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsid.Text = "";
                  txtsname.Text="";
                      txtrepas.Text="";
                      txtuname.Text  = "";
                      txtPass.Text = "";


           }
           else
           
                MessageBox.Show("password Mismatch");
          
    }
        private void addstaff_Load(object sender, EventArgs e)
        {
            label11.Text = "Current Login :" + Global.staffname;
            label7.Text = "Login Time :" + Global.utime;
            con1.Open();
            cmd1.Connection = con1;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtsid.Text = "";
            txtsname.Text = "";
            txtrepas.Text = "";
            txtuname.Text = "";
            txtPass.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
