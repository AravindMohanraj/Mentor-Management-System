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
    public partial class startf : Form
    {
        public startf()
        {
            InitializeComponent();
        }
        int z;
        login_frm frm_login = new login_frm();
        private void startf_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            z += 2;

            if (z > 100)
            {
                this.Hide();


                this.timer1.Enabled = false;

                //  this.Close();
                 frm_login.Show();
                return;

            }
            this.progressBar1.Value = z;
        }
    }
}
