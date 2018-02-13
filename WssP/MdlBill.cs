using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ReadFromExce01
{
    public class MdlBill
    {
        public string consumerid { get; set; }
        public string oldid { get; set; }
        public string consumername { get; set; }
        public string consumertype { get; set; }
        public string cnicno { get; set; }
        public string contactno { get; set; }
        public string zone { get; set; }

        public string uc { get; set; }
        public string plothouse { get; set; }
        public string houseentrtance { get; set; }

        public string plotsize { get; set; }
        public string streetno { get; set; }
        public string sectormohalla { get; set; }
        public string phase { get; set; }
        public string area { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string issuedate { get; set; }
        public string duedate { get; set; }

        public double watercg { get; set; } 
        public double conservancycg { get; set; }  
        public double seweragecg { get; set; }
        
        public double newconncg { get; set; }    
        public double totalcrntdue { get; set; }
        public double arears { get; set; }
        public double amountpaybyduedate { get; set; }
       public double surcharge { get; set; }    

        public double amountpayafterduedate { get; set; }
        public string account { get; set; }



        public List<MdlBill> ConvertDtToList(DataTable dt)
        {
            //MngExcel cexl = new MngExcel();
            //dt = cexl.GetBillDataFromFile(filepath);

            List<MdlBill> lst = new List<MdlBill>();
            MdlBill obj;
            foreach(DataRow dr in dt.Rows)
            {
                obj = new MdlBill();
                obj.consumerid = dr["ConsumerID"].ToString();
                obj.oldid = dr["OldID"].ToString();
                obj.consumername = dr["ConsumerName"].ToString();
                obj.consumertype = dr["ConsumerType"].ToString();
                obj.cnicno = dr["CNICNo"].ToString();
                obj.contactno = dr["ContactNo"].ToString();
                obj.zone = dr["Zone"].ToString();
                obj.uc = dr["UC"].ToString();
                obj.plothouse = dr["PlotHouseNo"].ToString();
                obj.houseentrtance = dr["Houseentrance"].ToString();
                obj.plotsize = dr["PlotSize"].ToString();
                obj.streetno = dr["Street#"].ToString();
                obj.sectormohalla = dr["SectorMohallah"].ToString();
                obj.phase = dr["Phase"].ToString();
                obj.area = dr["Area"].ToString();
                obj.from = dr["BillingPeriodFrom"].ToString();
                obj.to = dr["BillingPeriodTo"].ToString();
                obj.issuedate = dr["Issueddate"].ToString();
                obj.duedate = dr["DueDate"].ToString();
                obj.watercg = dr["WaterCharges"] == System.DBNull.Value ? 0: Convert.ToDouble(dr["WaterCharges"]);
                obj.conservancycg = dr["ConservancyCharges"]== System.DBNull.Value? 0: Convert.ToDouble(dr["ConservancyCharges"]);
                obj.seweragecg = dr["SewerageCharges"] == System.DBNull.Value? 0: Convert.ToDouble(dr["SewerageCharges"]);
                obj.newconncg = dr["NewConnectionCharges"] == System.DBNull.Value?0:  Convert.ToDouble(dr["NewConnectionCharges"]);

                obj.totalcrntdue = dr["TotalCurrentdues"] == System.DBNull.Value? 0: Convert.ToDouble(dr["TotalCurrentdues"]);
                obj.arears = dr["Arears"] == System.DBNull.Value ? 0: Convert.ToDouble(dr["Arears"]);
                obj.amountpaybyduedate = dr["AmountPayablebyDuedate"] == System.DBNull.Value? 0: Convert.ToDouble(dr["AmountPayablebyDuedate"]);
                obj.surcharge = dr["Surcharge@10%afterduedate"] == System.DBNull.Value ? 0: Convert.ToDouble(dr["Surcharge@10%afterduedate"]);
                obj.amountpayafterduedate = dr["AmountPayableafterDuedate"] == System.DBNull.Value ? 0 : Convert.ToDouble(dr["AmountPayableafterDuedate"]);

                if (obj.consumername.Length > 18)
                    obj.consumername = obj.consumername.Substring(0, 18);
                if (obj.sectormohalla.Length > 12)
                    obj.sectormohalla = obj.sectormohalla.Substring(0, 12);
                if (obj.area.Length > 16)
                    obj.area = obj.area.Substring(0, 16);
                if (obj.plotsize.Length > 12)
                    obj.plotsize = obj.plotsize.Substring(0, 12);

                //obj.account = dr["Account"].ToString();
                lst.Add(obj);
            }
            return lst;
        }
    }
}

/*Consumer ID	OldID	ConsmerName		CNICNo.	Contact No.	Zone	UC	Plot / House No.	House entrance	Plot Size	Street #	Sector / Mohallah	
Phase 	Area	Billing Period From	Billing Period To	Issued date	Due Date	
Water Charges  	Conservancy Charges  	Sewerage Charges  	New Connection Charges	Total Current dues	Arears	Amount Payable by Due date	
Surcharge @10% after due date	Amount Payable by Due date	Account*/
