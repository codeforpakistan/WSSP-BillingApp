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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private const int inc_dec = 5;  

        private void pbItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            if (!MngFormOps.check_open_forms(frm.Name))
            {
                //this.Hide();
                frm.Show();
            }
        }
        private void pbItem_MouseEnter(object sender, EventArgs e)
        {
            pbItem.Width += inc_dec;
            pbItem.Height += inc_dec;
        }

        private void pbItem_MouseLeave(object sender, EventArgs e)
        {
            pbItem.Width -= inc_dec;
            pbItem.Height -= inc_dec;
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

     
    }
}
