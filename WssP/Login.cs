using ReadFromExcel01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromExce01
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbUser.Text == "wssp1" && tbPwd.Text == "wssp1")
            {
                frmMain frm = new frmMain();
                if (!MngFormOps.check_open_forms(frm.Name))
                {
                    this.Hide();
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Type Correct Username and Password");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



    }
}
