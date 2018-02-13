using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ReadFromExce01
{
    public class MngExcel
    {
        
        public DataTable GetAllData(string filepath)
        {
              string constg = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=Yes'";
              OleDbConnection connExcel = new OleDbConnection(constg);
              OleDbCommand cmdExcel = new OleDbCommand();
              OleDbDataAdapter da = new OleDbDataAdapter();

            try
            {
                
                cmdExcel.Connection = connExcel;
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                DataSet ds = new DataSet();
               

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "SELECT ID, Name, CNIC,	Mobile,	Arrived From [" + SheetName + "]";
                da.SelectCommand = cmdExcel;
                da.Fill(ds);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
            finally
            {
                 connExcel.Close();
                 connExcel.Dispose();
                 cmdExcel.Dispose();
            }

        
        
        }


        public DataTable GetBillDataFromFile(string filepath)
        {
            string constg = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=Yes'";
            OleDbConnection connExcel = new OleDbConnection(constg);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();

            try
            {

                cmdExcel.Connection = connExcel;
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                DataSet ds = new DataSet();


                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                //string sname = "Sheet1";
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                da.SelectCommand = cmdExcel;
                da.Fill(ds);

                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                connExcel.Close();
                connExcel.Dispose();
                cmdExcel.Dispose();
            }



        }

        public int UpdateArrivalofPerson(string filepath, int rid, string yn)
        {
            string constg = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=Yes'";
            OleDbConnection connExcel = new OleDbConnection(constg);
            OleDbCommand cmdExcel = new OleDbCommand();            

            try
            {
                cmdExcel.Connection = connExcel;
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null); 

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                cmdExcel.CommandText = "UPDATE [" + SheetName + "]"+" SET Arrived ='"+yn+"' where ID = "+rid+";";

                int rowaffct =  cmdExcel.ExecuteNonQuery();
                return rowaffct > 0 ? 1 : 0;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                connExcel.Close();
                connExcel.Dispose();
                cmdExcel.Dispose();
            }
        }
    }
}
