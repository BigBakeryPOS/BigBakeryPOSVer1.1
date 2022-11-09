using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using BusinessLayer;
namespace Billing.Accountsbootstrap
{
    public partial class TransferBills : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        DataSet ds = new DataSet();
        DataSet dsTrans = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Session["User"].ToString();
           
            if (!IsPostBack)
            {
                DateTime date = DateTime.Today;
                txtDate.Text = date.ToString("yyyy-MM-dd");
               

                
            }

            Datas();
            DataSet dGrid = objbs.BingGridView(sTableName, txtDate.Text);
            gvBills.DataSource = dGrid.Tables[0];
            gvBills.DataBind();
          
           
            
        }
        public void Datas()
        {
            DateTime date = Convert.ToDateTime(txtDate.Text);
            string sDate = date.ToString("yyyy-MM-dd");
             ds = objbs.selectLocalSales(sTableName, sDate);
             dsTrans = objbs.selectLocalTransSales(sTableName, sDate);
           
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            string script = "$(document).ready(function () { $('[id*=btnTransfer]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
            System.Threading.Thread.Sleep(5000);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int icount = ds.Tables[0].Rows.Count;

                for (int i = 0; i < icount; i++)
                {
                    int UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"].ToString());
                    string sBillNo = ds.Tables[0].Rows[i]["BillNo"].ToString();
                    DateTime BillDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["BillDate"].ToString());
                    string bDate = BillDate.ToString("yyyy-MM-dd HH:mm:ss ");
                    int CustID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerId"].ToString());
                    Double Total = Convert.ToDouble(ds.Tables[0].Rows[i]["Total"].ToString());
                    Double NetAmount = Convert.ToDouble(ds.Tables[0].Rows[i]["NetAmount"].ToString());

                    Double Discount = Convert.ToDouble(ds.Tables[0].Rows[i]["Discount"].ToString());
                    int ContactType = 1;
                    Double Advance = Convert.ToDouble(ds.Tables[0].Rows[i]["Advance"].ToString());
                    int OrderNo = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderNo"].ToString());
                    string Msg = ds.Tables[0].Rows[i]["Messege"].ToString();
                    string sTaken = ds.Tables[0].Rows[i]["OrderTakenBy"].ToString();
                    DateTime DelDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["DeliveryDate"].ToString());
                    string dDate = DelDate.ToString("yyyy-MM-dd HH:mm:ss ");
                    string DelTime = ds.Tables[0].Rows[i]["DeilveryTime"].ToString();
                    string Notes = ds.Tables[0].Rows[i]["Notes"].ToString();
                    int PayMode = Convert.ToInt32(ds.Tables[0].Rows[i]["iPayMode"].ToString());
                    string sStatue = ds.Tables[0].Rows[i]["cancelstatus"].ToString();

                    int iSales = objbs.insertToServeSales(sTableName, UserId, sBillNo, bDate, CustID, Total, NetAmount, Discount, ContactType, Advance, OrderNo, Msg, sTaken, DelDate, dDate, DelTime, Notes, PayMode, sStatue);



                }
            }

            if (dsTrans.Tables[0].Rows.Count > 0)
            {
                int TransCount = dsTrans.Tables[0].Rows.Count;

                for (int i = 0; i < TransCount; i++)
                {


                    int SalesID = Convert.ToInt32(dsTrans.Tables[0].Rows[i]["SalesID"].ToString());
                    int CaTid = Convert.ToInt32(dsTrans.Tables[0].Rows[i]["CategoryID"].ToString());
                    Double Price = Convert.ToDouble(dsTrans.Tables[0].Rows[i]["UnitPrice"].ToString());
                    Double Amount = Convert.ToDouble(dsTrans.Tables[0].Rows[i]["Amount"].ToString());
                    int SubCatID = Convert.ToInt32(dsTrans.Tables[0].Rows[i]["SubCategoryID"].ToString());
                    Double Disc = Convert.ToDouble(dsTrans.Tables[0].Rows[i]["Disc"].ToString());
                    Double Qty = Convert.ToDouble(dsTrans.Tables[0].Rows[i]["Quantity"].ToString());
                    int StockID = Convert.ToInt32(dsTrans.Tables[0].Rows[i]["StockId"].ToString());

                    int iTrans = objbs.insertToServeTransSales(sTableName, SalesID, CaTid, Price, Amount, SubCatID, Disc, Qty, StockID);
                }
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);
            Response.Redirect("Home_Page.aspx");
           
        }
    }
}