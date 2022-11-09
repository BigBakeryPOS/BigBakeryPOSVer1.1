using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class KOT : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();
            sStore = Session["Store"].ToString();
            sAddress = Session["Address"].ToString();
            sTin = Session["TIN"].ToString();


            int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
            int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string sMode = Request.QueryString.Get("Mode");
            string Type = Request.QueryString.Get("Type");
            if (Type == "Order")
            {

                DataSet ds = objBs.PrintCakeOrder(sTableName, iD);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    mode.InnerText = Type;
                    lblbillno.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"].ToString());
                    lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                    gvPrint.DataSource = ds;
                    gvPrint.DataBind();
                }
            }
            else
            {
                if (iD > 0)
                {
                    DataSet ds = new DataSet();

                    ds = objBs.PrintingSales(iD, sTableName, sMode, "1");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mode.InnerText = Type;
                        lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                        DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                        lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                        decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                       // decimal dService = Convert.ToDecimal(ds.Tables[0].Rows[0]["ServiceCharge_Amt"].ToString());
                        decimal dRound = Convert.ToDecimal(ds.Tables[0].Rows[0]["Roundoff"].ToString());
                        decimal discc = Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString());
                        decimal dDisc = ((discc * dAmt) / 100);

                        decimal dAvance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Advance"].ToString());
                        //string pay = ds.Tables[0].Rows[0]["ipaymode"].ToString();
                        //if (pay == "4")
                        //{
                        //    paymode1.Text = "Card";
                        //}
                        //else
                        //{
                        //    paymode1.Text = "Cash";
                        //}
                        if (sMode == "Order")
                        {

                        }
                        
                        decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"].ToString());

                        if (ds.Tables[0].Rows[0]["CashPaid"].ToString() != "")
                        {
                            decimal dRev = Convert.ToDecimal(ds.Tables[0].Rows[0]["CashPaid"].ToString());


                        }
                        if (ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                        {
                            decimal dBal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());


                        }
                        gvPrint.DataSource = ds;
                        gvPrint.DataBind();


                        //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                        //PrintDocument doc = new PrintDocument();
                        ////doc.PrintPage += this.Doc_PrintPage;
                        //doc.Print();
                        //try
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "PrintPanel", "PrintPanel();", true);
                        //}
                        //catch
                        //{

                        //}
                    }

                    //Session["ctrl"] = pnlContents;
                    //Control ctrl = (Control)Session["ctrl"];
                    //PrintWebControl(ctrl);

                }

                else
                {
                    DataSet ds = new DataSet();

                    ds = objBs.PrintingOrderSales(NewiD, sTableName, sMode);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                        DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderdate"].ToString());
                        lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
                        decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                      //  decimal dService = Convert.ToDecimal(ds.Tables[0].Rows[0]["ServiceCharge_Amt"].ToString());
                        decimal dRound = Convert.ToDecimal(ds.Tables[0].Rows[0]["Roundoff"].ToString());
                        decimal discc = Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString());

                        decimal dAvance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Advance"].ToString());
                        //string pay = ds.Tables[0].Rows[0]["ipaymode"].ToString();
                        //if (pay == "4")
                        //{
                        //    paymode1.Text = "Card";
                        //}
                        //else
                        //{
                        //    paymode1.Text = "Cash";
                        //}
                        if (sMode == "Order")
                        {

                        }
                        
                        decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"].ToString());

                        //if (ds.Tables[0].Rows[0]["CashPaid"].ToString() != "")
                        //{
                        //    decimal dRev = Convert.ToDecimal(ds.Tables[0].Rows[0]["CashPaid"].ToString());

                        //    lblReceived.Text = dRev.ToString("f2");
                        //}
                        //if (ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                        //{
                        //    decimal dBal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());

                        //    lblBal.Text = dBal.ToString("f2");
                        //}
                        gvPrint.DataSource = ds;
                        gvPrint.DataBind();


                        //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                        //PrintDocument doc = new PrintDocument();
                        ////doc.PrintPage += this.Doc_PrintPage;
                        //doc.Print();
                        //try
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "PrintPanel", "PrintPanel();", true);
                        //}
                        //catch
                        //{

                        //}
                    }

                }
              //  ClientScript.RegisterStartupScript(typeof(Page), "closePage", "self.close();", true);
            }//end mode
          //  ClientScript.RegisterStartupScript(typeof(Page), "closePage", "self.close();", true);

        }
    }
}