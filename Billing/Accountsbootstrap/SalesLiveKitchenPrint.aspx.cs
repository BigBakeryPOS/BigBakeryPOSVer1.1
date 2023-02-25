using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using DataLayer;
using System.Xml.Linq;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;

namespace Billing.Accountsbootstrap
{
    public partial class SalesLiveKitchenPrint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string StoreNo = "";
        double damt = 0;
        string type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUserID.Text = Session["UserID"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            //sTableName = Session["User"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sStore = Request.QueryString.Get("Store");
            type = Request.QueryString.Get("type");
            //sAddress = Session["Address"].ToString();
            sAddress = Request.Cookies["userInfo"]["Address"].ToString();
            //StoreNo = Session["StoreNo"].ToString();
            StoreNo = Request.Cookies["userInfo"]["StoreNo"].ToString();

           // lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            
           // biller = Request.Cookies["userInfo"]["Biller"].ToString(); ;
            
            //sStore = Request.Cookies["userInfo"]["Store"].ToString();
            //
            //sTin = Request.Cookies["userInfo"]["TIN"].ToString();
          //  Rate = Request.Cookies["userInfo"]["Rate"].ToString();
          //  BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();

           // sTin = Session["TIN"].ToString();

            if (sTableName.ToLower() == "co6" || sTableName.ToLower() == "co7")
            {
                //tax.Visible = true;
                //total.Visible = true;

                tax.Visible = false;
                total.Visible = false;
            }

            else
            {
                tax.Visible = false;
                total.Visible = false;
            }

            if (sTableName.ToLower() == "co8")
            {
                lblpvtltd.Visible = true;
            }
            else
            {
                lblpvtltd.Visible = false;
            }



            if (sTableName.ToLower() == "co8")
            {

                lblstore.Text = "(" + sStore + ")";
                idimglog.Visible = false;
                lblstore.Visible = true;
            }
            else
            {
                idimglog.Visible = true;
                lblstore.Text = sStore;
                lblstore.Visible = true;
            }

            if (sTableName.ToLower() == "co11")
            {
              //  home.Visible = true;
                home.Visible = false;
            }
            else
            {
                home.Visible = false;
            }

            if (sTableName.ToLower() == "co10")
            {

                lblstore.Text = sStore;
                // idimglog.Visible = false;
                lblstore.Visible = true;

                idFranchisee.Visible = true;
            }
            else
            {
                // idimglog.Visible = true;
                lblstore.Text = sStore;
                lblstore.Visible = true;

                idFranchisee.Visible = false;
            }


            int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
            int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string sMode = Request.QueryString.Get("Mode");

            if (iD > 0)
            {
                DataSet ds = new DataSet();

                //ds = objBs.PrintingSalesLiveKitchen(iD, sTableName, sMode, type);
                ds = objBs.PrintingSalesLiveKitchen1(iD, sTableName, type);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ipaymode"].ToString() != "1" || ds.Tables[0].Rows[0]["ipaymode"].ToString() != "4")
                    {
                        lblcustname.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    }
                    lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                    lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");

                    billedby.Text = ds.Tables[0].Rows[0]["Biller"].ToString();
                    atender.Text = ds.Tables[0].Rows[0]["Attender"].ToString();
                    decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lblAmount.Text = dAmt.ToString("f2");
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
                        tradv.Visible = true;
                        lbladvance.Text = dAvance.ToString("f2");
                        trCash.Visible = false;
                        trPaid.Visible = false;
                    }

                    //    lblstorenew.Text = sStore;
                    //  lblstore.Text = sStore;
                    lblstoreno.Text = "Store NO : " + StoreNo;

                    lblAddres.Text = sAddress;
                    lbltin.Text = sTin;
                    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lbltotal.Text = dTotal.ToString("f2");
                    lblTax.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Tax"]).ToString("f2");
                    lblsubttl.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"]).ToString("f2");

                    if (ds.Tables[0].Rows[0]["Discount"].ToString() != "0.0000")
                    {
                        iddiscamt.Visible = true;
                        decimal amt = (Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString()) / 100);
                        lbldiscountamt.Text = amt.ToString("f2");

                        lblsubttl.Text = (Convert.ToDecimal(lblsubttl.Text) - amt).ToString("f2");
                    }
                    else
                    {
                        iddiscamt.Visible = false;
                    }

                    lblGrand.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]).ToString("f2");

                    double n = 0;
                    double roundoff = Convert.ToDouble(lblGrand.Text) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                    if (roundoff >= 0.5)
                    {
                        n = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        n = Math.Floor(Convert.ToDouble(lblGrand.Text));
                    }

                    lblGrand.Text = string.Format("{0:N2}", n);

                    lblcgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]).ToString("f2");
                    lblsgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]).ToString("f2");



                    if (ds.Tables[0].Rows[0]["CashPaid"].ToString() != "")
                    {
                        decimal dRev = Convert.ToDecimal(ds.Tables[0].Rows[0]["CashPaid"].ToString());

                        lblReceived.Text = dRev.ToString("f2");
                    }
                    if (ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                    {
                        decimal dBal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());

                        lblBal.Text = dBal.ToString("f2");
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
                if (sTableName.ToLower() == "co6" || sTableName.ToLower() == "co7")
                {
                    tax.Visible = false;
                    total.Visible = false;
                }
                DataSet ds = new DataSet();

                ds = objBs.PrintingOrderSales(NewiD, sTableName, sMode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ipaymode"].ToString() != "1" || ds.Tables[0].Rows[0]["ipaymode"].ToString() != "4")
                    {
                        lblcustname.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    }
                    lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderdate"].ToString());
                    lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
                    //     billedby.Text = ds.Tables[0].Rows[0]["Biller"].ToString();
                    //atender.Text = ds.Tables[0].Rows[0]["Attender"].ToString();
                    decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lblAmount.Text = dAmt.ToString("f2");
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
                        tradv.Visible = true;
                        lbladvance.Text = dAvance.ToString("f2");
                        trCash.Visible = false;
                        trPaid.Visible = false;
                    }
                    //     lblstorenew.Text = sStore;
                    //  lblstore.Text = sStore;
                    lblstoreno.Text = "Store NO : " + StoreNo;

                    lblAddres.Text = sAddress;
                    lbltin.Text = sTin;
                    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"].ToString());
                    lblGrand.Text = dTotal.ToString("f2");


                    double n = 0;
                    double roundoff = Convert.ToDouble(lblGrand.Text) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                    if (roundoff >= 0.5)
                    {
                        n = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        n = Math.Floor(Convert.ToDouble(lblGrand.Text));
                    }

                    lblGrand.Text = string.Format("{0:N2}", n);

                    lblcgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]).ToString("f2");
                    lblsgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]).ToString("f2");
                    lblsubttl.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["STotal"]).ToString("f2");
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
        }



        protected void gvPrint_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            double qty = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                damt = damt + qty;


            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Qty: ";
                e.Row.Cells[1].Text = damt.ToString();
                Label1.Text = damt.ToString();

            }
        }


    }
}