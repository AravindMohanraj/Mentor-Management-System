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
    public partial class login_frm : Form
    {
        public login_frm()
        {
            InitializeComponent();
        }
     
        private void btn_Login_Click(object sender, EventArgs e)
        {
            
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=mmsdb.mdb");
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = con1;           
              cmd1.CommandText = "select password,staffid,staffname from login where username='"+ textBox1.Text +"'";
            OleDbDataReader dr1;
            con1.Open();
                
            dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
               
                if (txtPass.Text.Equals(dr1.GetString(0)))
                {

                    Global.ltime= Convert.ToString(System.DateTime.Now.ToString("HH:mm:ss tt"));
                    Global.staffid = dr1.GetString(1);
                   // this.Dispose(true);
                    Global.staffname = dr1.GetString(2);
                   
                    MDIParent1 mdi_parent = new MDIParent1();                   
                    mdi_parent.Show();
                  
                                        
                }
                else
                    MessageBox.Show("Invalid Password");
            }
            else
                MessageBox.Show("Invalid Username");            
            
           dr1.Close();
          con1.Close();
         
        }

        private void login_frm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mmsdbDataSet.attendance' table. You can move, or remove it, as needed.
           
        }

        private void btn_Login_MouseEnter(object sender, EventArgs e)
        {
         

        }

        private void btn_Login_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void btn_Login_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
