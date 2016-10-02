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
    public partial class addbatch : Form
    {
        public addbatch()
        {
            InitializeComponent();
        }

        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbDataReader dr1;
        string studentid, querry;
        private void btn_Link_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            cmd1.CommandText = "insert into addbatch values('" + txtbno.Text + "', '" + txtsname.Text + "', '" + txtrno.Text + "','" + 1 + "')";
            cmd1.ExecuteNonQuery();
            txtrno.Text="";
            txtsname.Text = "";
            bind(querry);
            MessageBox.Show("Data Saved Suceesfully", "Mentor Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        public void bind(string querry)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(querry, con1);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void addbatch_Load(object sender, EventArgs e)
        {
            label12.Text = "Current Login :" + Global.staffname;
            label13.Text = "Login Time :" + Global.utime;
            con1.Open();
            cmd1.Connection = con1;

            querry = "select batchno,studentid,studentname from addbatch where staffid='"+Global.staffid+"'";
            bind(querry);
        }

        private void txtbno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbno_Leave(object sender, EventArgs e)
        {
            if (txtbno.Text == "")
            {
                querry = "select batchno,studentid,studentname from addbatch where staffid='" + Global.staffid + "'";

            }
            else
            {

                querry = "select batchno,studentid,studentname from addbatch where staffid='" + Global.staffid + "' and batchno='" + txtbno.Text + "'";
            }
                bind(querry);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            bind(querry);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtbno.Text = "";
                txtrno.Text="";
                txtsname.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
