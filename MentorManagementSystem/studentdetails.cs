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
    public partial class studentdetails : Form
    {
        public studentdetails()
        {
            InitializeComponent();
        }
        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        OleDbDataReader dr1,dr2;
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        public void spilvisible(bool value)
        {
            splitContainer1.Enabled  = value;
            splitContainer2.Enabled  = value;
            splitContainer3.Enabled = value;

        
        }
        private void studentdetails_Load(object sender, EventArgs e)
        {
            label39.Text = "Current Login :" + Global.staffname;
            label40.Text = "Login Time :" + Global.utime;
         
            lbl_Mode.Text = Global.umode;
            spilvisible(false);
            con1.Open();
            cmd1.Connection = con1;
            cmd2.Connection = con1;

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        
        public void controlsenable(bool value)
        {
           
            label1.Enabled = value;
            label4.Enabled = value;
        
            label6.Enabled = value;
            label7.Enabled = value;
            label8.Enabled = value;
            label9.Enabled = value;
           
            label12.Enabled = value;
            label13.Enabled = value;
            label14.Enabled = value;
            label15.Enabled = value;
            label16.Enabled = value;
            label17.Enabled = value;

            txtstdname.Enabled = value;
            txtregno.Enabled = value;
            txtdeg.Enabled = value;
            txtdob.Enabled = value;
            txtgender.Enabled = value;
            txtaddress.Enabled = value;
            txtfathername.Enabled = value;
            txtmname.Enabled = value;
            txtfocc.Enabled = value;
            txtmocc.Enabled = value;
            txtfmno.Enabled = value;
            txtsibinfo.Enabled = value;
        
        }

        private void txt_Find_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == 13)
            {
                cmd1.CommandText = "SELECT studentid from addbatch where staffid='" + Global.staffid + "' and batchno='" + txt_Find.Text + "'";
                dr1 = cmd1.ExecuteReader();
                comboBox1.Items.Clear();
                try
                {
                    //dr1.Read();
                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            comboBox1.Items.Add(dr1.GetString(0));
                        }
                        panel3.Hide();
                        splitContainer1.Enabled = true;

                        controlsenable(false);

                    }
                    else
                    {
                        MessageBox.Show("Enter Correct Batch number");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);

                }
                dr1.Close();
            } 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd1.CommandText = "SELECT fillflag,studentname from addbatch where staffid='" + Global.staffid + "' and batchno='" + txt_Find.Text + "' and studentid='"+comboBox1.Text +"'";
            dr1 = cmd1.ExecuteReader();
            dr1.Read();
            if (Global.umode == "ADD")
            {
                if (dr1.GetString(0) == "true")
                {
                   
                    MessageBox.Show("Stuendent's Details already Enterd");
                    panel3.Show();
                    spilvisible(false);
                }
                else
                {
                    txtstdname.Text = dr1.GetString(1);
                    controlsenable(true);
                    spilvisible(true);
                    txtstdname.Enabled = false;
                }
                
            }
            else
            {
                if (dr1.GetString(0) == "false")
                {
                    MessageBox.Show("No Record Found ! Add Details in ADDMODE");
                    ClearTextBoxes();
                    comboBox1.Items.Clear();
                    panel3.Show();
                    spilvisible(false);

                }
                else
                {
                    cmd2.CommandText = "SELECT * from addstudent where studentid='" + comboBox1.Text + "'";
                    dr2 = cmd2.ExecuteReader();
                    dr2.Read();
                    toolStrip1.Items[0].Text = "Modify";
                    controlsenable(true);
                    spilvisible(true);
                 
                    txtregno.Text = dr2.GetString(0);
                    txtdeg.Text  = dr2.GetString(3);
                   
                    dr2.Close();
                   
                }
               
            }
            dr1.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            comboBox1.Items.Clear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            cmd1.CommandText = "insert into addstudent values('" + txtregno.Text + "', '" + txtstdname.Text + "', '" + comboBox1.Text  + "','" + txtdeg.Text + "',  '" + txtdob.Text + "','" + txtgender.Text + "','" + txtaddress.Text + "','" + txtfathername.Text + "','" + txtmname.Text + "','" + txtfocc.Text + "','" + txtmocc.Text + "','" + txtfmno.Text + "','" + txtsibinfo.Text + "','" + txtpadd.Text + "','" + txtds.Text + "','" + txt10thins.Text + "','" + txt10thper.Text + "','" + txt10thyear.Text + "','" + txt12thins.Text + "','" + txt12thper.Text + "','" + txt12thyear.Text + "','" + txtugdegree.Text + "','" + txtuginst.Text + "','" + txtugper.Text + "','" + txtugyear.Text + "','" + txtreligion.Text + "','" + txtaccayear.Text + "','" + txtaddmimode.Text + "','" + txtlangknow.Text + "','" + txtmobileno.Text + "','" + txtmailid.Text + "','" + txtamailid.Text + "','" + txtpassportno.Text + "','" + txtbankno.Text + "','" + txtbankname.Text + "','" + txtaadhaor.Text + "','" + txtbloodgroup.Text + "','" + txthobbies.Text + "','" + txtextracurricular.Text + "')";
            cmd1.ExecuteNonQuery();
            cmd1.CommandText = "update addbatch set fillflag='true' where studentid='" + comboBox1.Text + "'";
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Data Saved Suceesfully", "Mentor Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearTextBoxes();
            comboBox1.Text = "";
            comboBox1.Items.Clear();
        }
    }
}
