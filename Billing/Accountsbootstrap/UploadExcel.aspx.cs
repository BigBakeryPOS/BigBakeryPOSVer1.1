using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using BusinessLayer;

namespace Billing.Accountsbootstrap
{
    public partial class UploadExcel : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadExcelFile("Product", "F:/BFProduct.xls");
            sTableName = Session["User"].ToString();
            
        }

        private void ReadExcelFile(string sheetName, string path)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataSet ds=new DataSet();
                string Import_FileName = path;
                //string fileExtension = Path.GetExtension(Import_FileName);
                //if (fileExtension == ".xls")
                   conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                ////if (fileExtension == ".xlsx")
                //    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$]";

                    comm.Connection = conn;





                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(ds);
                        int iSuccess = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["Quantity"].ToString()!="")
                            {
                                iSuccess = objBs.InsertStock(sTableName,Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(ds.Tables[0].Rows[i]["GroupID"].ToString()), Convert.ToInt32(ds.Tables[0].Rows[i]["ItemID"].ToString()), Convert.ToDouble(ds.Tables[0].Rows[i]["Quantity"].ToString()), Convert.ToDouble(ds.Tables[0].Rows[i]["Quantity"].ToString()), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")),0);
                            }
                        }
                    }

                }
            }
        }
    }
}