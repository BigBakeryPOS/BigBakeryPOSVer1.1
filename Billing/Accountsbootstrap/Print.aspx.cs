using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class Print : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string branchcode = "";
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string cancelno1 = "";
        int cancelno = 0;
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            branchcode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sStore = Request.Cookies["userInfo"]["Store"].ToString();
            sAddress = Request.Cookies["userInfo"]["Address"].ToString();
            sTin = Request.Cookies["userInfo"]["TIN"].ToString();
            if (!IsPostBack)
            {
                int OrderNo = Convert.ToInt32(Request.QueryString.Get("OrderNo"));


                cancelno1 = Convert.ToString(Request.QueryString.Get("cancelno"));
                if (cancelno1 == "Select order no.")
                {
                }
                else
                {
                    cancelno = Convert.ToInt32(Request.QueryString.Get("cancelno"));
                }
                idFranchisee.Visible = false;
                DataSet getfranchisee = objbs.getfarnchiseename(sTableName);
                if (getfranchisee.Tables[0].Rows.Count > 0)
                {
                    idFranchisee.Visible = true;
                    lblfranchise.Text = getfranchisee.Tables[0].Rows[0]["FranchiseeName"].ToString();
                }
                else
                {
                    idFranchisee.Visible = false;
                }

                //if (sTableName.ToLower() == "co8")
                //{
                //    lblpvtltd.Visible = true;
                //    lblstore.Text = "(" + sStore + ")";
                //}
                //else
                //{
                //    lblpvtltd.Visible = false;
                //    lblstore.Text = sStore;
                //}

                DataSet ds2 = objbs.getbranchdetails1(branchcode);
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    lblbranch.Text = ds2.Tables[0].Rows[0]["branchname"].ToString();
                    //lblbranch1.Text = ds1.Tables[0].Rows[0]["branchname"].ToString();
                    lblbranchaddress.Text = ds2.Tables[0].Rows[0]["address"].ToString();
                    lblcountry.Text = ds2.Tables[0].Rows[0]["Country"].ToString();
                    lblstate1.Text = ds2.Tables[0].Rows[0]["State"].ToString();
                    lblcity1.Text = ds2.Tables[0].Rows[0]["City"].ToString();
                    lblMobileno.Text = ds2.Tables[0].Rows[0]["MobileNo"].ToString();
                    lblgstin.Text = ds2.Tables[0].Rows[0]["GSTIN"].ToString();
                    lblemail.Text = ds2.Tables[0].Rows[0]["Email"].ToString();


                }

                ds = objbs.PrintCakeOrder(sTableName, OrderNo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblBookno.Text = ds.Tables[0].Rows[0]["fullBookNo"].ToString();
                    lblOrderNo.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"]);
                    lblDate.Text = dt.ToString("dd/MM/yyyy hh:mm tt");
                    lblname.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                    //  lblAddress.Text = ds.Tables[0].Rows[0]["CustomerAddress"].ToString();
                    lblPhoneNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    //string pay1 = ds.Tables[0].Rows[0]["ipaymode"].ToString();
                    //if (pay1 == "4")
                    //{
                    //    paymode1.Text = "Card";
                    //}
                    //else
                    //{
                    //    paymode1.Text = "Cash";
                    //}
                    //   lblstore.Text = sStore;
                    //lblAddres.Text = sAddress;
                   // lbltin.Text = sTin;
                    lblcg.Text = String.Format("{0:f2}", ds.Tables[0].Rows[0]["CGST"].ToString());
                    lblsg.Text = String.Format("{0:f2}", ds.Tables[0].Rows[0]["SGST"].ToString());
                    lblsubtotal.Text = String.Format("{0:f2}", ds.Tables[0].Rows[0]["STotal"].ToString());
                    if (ds.Tables[0].Rows[0]["DiscountAmount"].ToString() != "0.0000" )
                    {
                        discc.Visible = true;
                        lbldisc.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["DiscountAmount"]).ToString("0.00");
                    }
                    else
                    {
                        discc.Visible = false;
                    }

                    decimal totalamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"].ToString());
                    lblTotalAmount.Text = String.Format("{0:f2}", totalamt);

                    double n = 0;

                    DataSet getpaiddetails = objbs.getpaidorderdetails(Convert.ToInt32(OrderNo), sTableName);
                    if (getpaiddetails.Tables[0].Rows.Count > 0)
                    {
                        Gridpaymentdetails.DataSource = getpaiddetails;
                        Gridpaymentdetails.DataBind();
                    }
                    else
                    {
                        Gridpaymentdetails.DataSource = null;
                        Gridpaymentdetails.DataBind();
                    }


                    double roundoff = Convert.ToDouble(lblTotalAmount.Text) - Math.Floor(Convert.ToDouble(lblTotalAmount.Text));
                    if (roundoff >= 0.5)
                    {
                        n = Math.Round(Convert.ToDouble(lblTotalAmount.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        n = Math.Floor(Convert.ToDouble(lblTotalAmount.Text));
                    }

                    lblTotalAmount.Text = string.Format("{0:N2}", n);




                    decimal advance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Advance"].ToString());
                    lblAdvance.Text = String.Format("{0:f2}", advance);

                    double p = 0;


                    double roundoff1 = Convert.ToDouble(lblAdvance.Text) - Math.Floor(Convert.ToDouble(lblAdvance.Text));
                    if (roundoff1 >= 0.5)
                    {
                        p = Math.Round(Convert.ToDouble(lblAdvance.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        p = Math.Floor(Convert.ToDouble(lblAdvance.Text));
                    }

                    lblAdvance.Text = string.Format("{0:N2}", p);

                    decimal balance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balancepaid"].ToString());
                    //lblBalanceAmt.Text = String.Format("{0:f2}", totalamt - advance);
                    lblBalanceAmt.Text = String.Format("{0:f2}", balance);

                    double pp = 0;


                    double roundoff2 = Convert.ToDouble(lblBalanceAmt.Text) - Math.Floor(Convert.ToDouble(lblBalanceAmt.Text));
                    if (roundoff2 >= 0.5)
                    {
                        pp = Math.Round(Convert.ToDouble(lblBalanceAmt.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        pp = Math.Floor(Convert.ToDouble(lblBalanceAmt.Text));
                    }

                    lblBalanceAmt.Text = string.Format("{0:N2}", pp);


                    DateTime deltime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DeliveryDate"]);
                    lblDeliveryDate.Text = deltime.ToShortDateString();
                    lblTime.Text = ds.Tables[0].Rows[0]["DeliveryTime"].ToString();
                    lblOrderTakenBy.Text = ds.Tables[0].Rows[0]["OrderTakenBy"].ToString();
                    lblMessage.Text = ds.Tables[0].Rows[0]["Messege"].ToString();
                    lblPlace.Text = ds.Tables[0].Rows[0]["place"].ToString();
                    gvPrint.DataSource = ds;
                    gvPrint.DataBind();

                    string modelstatus ="N" ;
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {

                        string modelimg = ds.Tables[0].Rows[j]["modelno"].ToString();

                        if (modelimg != "0")
                        {
                            modelstatus = "Y";
                        }
                    }

                    if(modelstatus == "Y")
                    {
                        string yourUrl = "KitPrint.aspx?OrderNo=" + OrderNo.ToString();
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
                    }

                }
                if (cancelno != 0)
                {
                    order.Visible = true;
                    cust.Visible = true;
                    grid.Visible = true;
                    toal.Visible = true;
                    Tr1.Visible = true;
                    Tr2.Visible = true;
                    Tr3.Visible = true;
                    advance.Visible = true;
                    balance.Visible = true;
                    deliverydate.Visible = true;
                    ordertakenby.Visible = true;
                    neworder.Visible = true;
                    Oldorder.Visible = true;
                    // oldpaymode1.Visible = true;
                    dss = objbs.printcancelorderBlaack(sTableName, cancelno);
                    if (dss.Tables[0].Rows.Count > 0)
                    {

                        lblcancelno.Text = dss.Tables[0].Rows[0]["OrderNo"].ToString();
                        DateTime dt = Convert.ToDateTime(dss.Tables[0].Rows[0]["OrderDate"]);
                        lblcanDate.Text = dt.ToString("dd/MM/yyyy hh:mm tt");
                        lblcanname.Text = dss.Tables[0].Rows[0]["CustomerName"].ToString();
                        //  lblAddress.Text = ds.Tables[0].Rows[0]["CustomerAddress"].ToString();
                        lblcanPhoneNo.Text = dss.Tables[0].Rows[0]["MobileNo"].ToString();
                        // string pay = dss.Tables[0].Rows[0]["ipaymode"].ToString();
                        //if (pay == "4")
                        //{
                        //    oldpaymode.Text = "Card";
                        //}
                        //else
                        //{
                        //    oldpaymode.Text = "Cash";
                        //}
                        lblcgg.Text = String.Format("{0:f2}", dss.Tables[0].Rows[0]["CGST"].ToString());
                        lblsgg.Text = String.Format("{0:f2}", dss.Tables[0].Rows[0]["SGST"].ToString());

                        lblsubtotalls.Text = String.Format("{0:f2}", dss.Tables[0].Rows[0]["STotal"].ToString());

                        decimal totalamt = Convert.ToDecimal(dss.Tables[0].Rows[0]["Total"].ToString());
                        lblcanTotalAmount.Text = String.Format("{0:f2}", totalamt);
                        decimal advance1 = Convert.ToDecimal(dss.Tables[0].Rows[0]["Advance"].ToString());
                        lblcanAdvance.Text = String.Format("{0:f2}", advance1);
                        decimal balance1 = Convert.ToDecimal(dss.Tables[0].Rows[0]["Total"].ToString());
                        lblcanBalanceAmt.Text = String.Format("{0:f2}", totalamt - advance1);
                        DateTime deltime = Convert.ToDateTime(dss.Tables[0].Rows[0]["DeliveryDate"]);
                        lblcanDeliveryDate.Text = deltime.ToShortDateString();
                        lblcanTime.Text = dss.Tables[0].Rows[0]["DeliveryTime"].ToString();
                        lblcanOrderTakenBy.Text = dss.Tables[0].Rows[0]["OrderTakenBy"].ToString();
                        lblMessage.Text = dss.Tables[0].Rows[0]["Messege"].ToString();

                        lblPlace.Text = dss.Tables[0].Rows[0]["place"].ToString();
                        gvPrintcan.DataSource = dss;
                        gvPrintcan.DataBind();
                    }
                }

            }
        }
    }
}