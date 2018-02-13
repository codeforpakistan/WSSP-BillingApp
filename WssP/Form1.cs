using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadFromExce01
{
    public partial class Form1 : Form
    {

        MngExcel obj = new MngExcel();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbFileName.Text = "C:\\Files\\m3.xlsx";
            //this.reportViewer2.RefreshReport();

        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {

            openExcelFileDialog1.ShowDialog();
            //DialogResult dg = MessageBox.Show("Are you Sure You Want to Load Data from Excel", "Information", MessageBoxButtons.YesNo);
            //if (dg.Equals(DialogResult.Yes))
            //{               
                
            //}
        }

        private void openExcelFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            tbFileName.Text = openExcelFileDialog1.FileName;
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                MdlBill bobj = new MdlBill();


                //dgvExcel.DataSource = obj.GetBillDataFromFile(tbFileName.Text);
                //  reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1",obj.GetBillDataFromFile(tbFileName.Text)) );
                // reportViewer1.LocalReport.DataSources = obj.GetBillDataFromFile(tbFileName.Text); 
                // MdlBillBindingSource.DataSource = obj.GetBillDataFromFile(tbFileName.Text);

                DataTable dt1 = new DataTable();
                dt1 = obj.GetBillDataFromFile(tbFileName.Text);

                MdlBillBindingSource.DataSource = bobj.ConvertDtToList(dt1);
                //dgvExcel.DataSource = MdlBillBindingSource;

                //reportViewer2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt1));
                reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occoured: Check data otherwise contact admin:\n" + ex.Message);
                
            }

           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            obj.UpdateArrivalofPerson(tbFileName.Text, 1, "yes");
            dgvExcel.DataSource = obj.GetAllData(tbFileName.Text); 
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                obj.UpdateArrivalofPerson(tbFileName.Text, 1, "yes");
                dgvExcel.DataSource = obj.GetAllData(tbFileName.Text); 
            }
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }




    }
}
