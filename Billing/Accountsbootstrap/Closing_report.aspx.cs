using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using Microsoft.Office.Core;
using System.Drawing;


namespace Billing.Accountsbootstrap
{
    public partial class Closing_report : System.Web.UI.Page
    {
        decimal total, tmp = 0, cash = 0, credit = 0, card = 0, compli = 0, sales, gross, cash_handover = 0, Closing_cash = 0, net_sales = 0, tot_grosssales = 0, OP_cash = 0, gross_main = 0;
        decimal SD_Total = 0, datebar_SD = 0, missing_SD = 0, compli_SD = 0, waste_SD = 0,
            NP_SD = 0, Damage_SD = 0, Change_SD = 0, BNP_SD = 0, bbkulam = 0, excess = 0;
        decimal total_denomination = 0;
        string sTableName = "";
        string op = "";
        string sUserChk = "";
        BSClass objbs = new BSClass();
        string branchcode = string.Empty;

        double GTax = 0;
        double GNetAmount = 0;
        double GoNetAmount = 0;

        double FtotalExp = 0, FtotalSale = 0, FtotalOrder = 0, FtotalCancelOrder = 0, FtotalOnlineSales = 0, FtotalReturn = 0, FtotCreditsales = 0;

        double GQtys = 0; double GRates = 0; double GTrates = 0; double GMargins = 0; double GBasicValues = 0; double GGSTAmts = 0; double GNetAmounts = 0; double SalesExempteds = 0; double TaxableSaless = 0;
        double GQtyo = 0; double GRateo = 0; double GTrateo = 0; double GMargino = 0; double GBasicValueo = 0; double GGSTAmto = 0; double GNetAmounto = 0; double SalesExemptedo = 0; double TaxableSaleso = 0;
        double GOCOSTo = 0; double GOGSTo = 0; double GOAmounto = 0;

        double GOCOST = 0;
        double GOGST = 0;
        double GOAmount = 0;

      


        double GMargin = 0;
        double GoMargin = 0;
        double GBasicValue = 0;
        double GoBasicValue = 0;
        double GGSTAmt = 0;
        double GoGSTAmt = 0;
        double GQty = 0;
        double GRate = 0;
        double GTrate = 0;

        double SalesExempted = 0; double TaxableSales = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            branchcode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            op = Request.Cookies["userInfo"]["OP"].ToString();

            sUserChk = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            string time = DateTime.Now.ToString();

            DateTime dat = DateTime.Parse(time);
            var hour = dat.ToString("HH");
            var min = dat.ToString("mm");
            var current = hour + "." + min;



            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Send Mail.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion

            if (Request.Cookies["userInfo"]["Biller"].ToString().ToLower() == "nona")
            {

            }
            else
            {

            }
            if (!IsPostBack)
            {

                DataSet dsreason = new DataSet();
                dsreason = objbs.getsessionmode();
                drpsessiontype.DataTextField = "sessionname";
                drpsessiontype.DataValueField = "sessionmode";
                drpsessiontype.DataSource = dsreason.Tables[0];
                drpsessiontype.DataBind();
                drpsessiontype.Items.Insert(0, "Select Type");
                drpsessiontype.SelectedValue = "2";
                drpsessiontype.Enabled = false;

                drpsessiontype1.DataTextField = "sessionname";
                drpsessiontype1.DataValueField = "sessionmode";
                drpsessiontype1.DataSource = dsreason.Tables[0];
                drpsessiontype1.DataBind();
                drpsessiontype1.Items.Insert(0, "Select Type");
                drpsessiontype1.SelectedValue = "4";
                drpsessiontype1.Enabled = false;


                DataSet getdenominationclose = objbs.getdenominationmaster();
                if (getdenominationclose.Tables[0].Rows.Count > 0)
                {
                    gvdenominationcloseing.DataSource = getdenominationclose.Tables[0];
                    gvdenominationcloseing.DataBind();

                    gvdenominationoffice.DataSource = getdenominationclose.Tables[0];
                    gvdenominationoffice.DataBind();
                }


                DataSet userchk = objbs.Lastsess(sTableName);

                if (userchk.Tables[0].Rows.Count > 0)
                {
                    lblvil.InnerText = "Session Last closed by " + userchk.Tables[0].Rows[0]["Name"].ToString() + " on " + userchk.Tables[0].Rows[0]["Datetime"].ToString();
                }

                if (sUserChk == "0")
                {

                    DataSet dsCustomer = objbs.getbranchforhomepage();
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        DDlbranch.DataSource = dsCustomer.Tables[0];
                        DDlbranch.DataTextField = "brancharea";
                        DDlbranch.DataValueField = "branchname";
                        DDlbranch.DataBind();
                        DDlbranch.Items.Insert(0, "Select Branch");

                        DDlbranch.SelectedItem.Text = sTableName;
                        DDlbranch.Enabled = false;
                    }
                }
                else
                {
                    DDlbranch.Enabled = true;

                    DataSet dsCustomer = objbs.getbranchforhomepage();
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        DDlbranch.DataSource = dsCustomer.Tables[0];
                        DDlbranch.DataTextField = "brancharea";
                        DDlbranch.DataValueField = "branchname";
                        DDlbranch.DataBind();
                        DDlbranch.Items.Insert(0, "Select Branch");


                    }
                }
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                // sTableName = Session["User"].ToString();
                string dt = "";
                DataSet dsclose = objbs.Get_PreviousdayClosingdetails(sTableName);

                if (dsclose.Tables[0].Rows.Count > 0)
                {
                    dt = DateTime.Today.ToString("yyyy-MM-dd");
                }
                else
                {
                    dt = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                }


                if (Request.Cookies["userInfo"]["IsSuperAdmin"].ToString() == "1")
                {
                    DDlbranch.Enabled = true;
                    date.Enabled = true;

                }
                date.Text = dt;



                #region Sales
                DateTime sFrom = Convert.ToDateTime(date.Text);

                DateTime sTo = Convert.ToDateTime(date.Text);

                DataSet dcustbranch = objbs.CustomerSalesBranch(DDlbranch.SelectedValue, sFrom, sTo);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    lblCaption.Text = "Store :  " + DDlbranch.SelectedItem.Text + " Customer Sales Report On " + Convert.ToDateTime(sFrom).ToString("dd/MM/yyyy");

                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();
                }
                #endregion


                #region SECOND COLUMN DATAS (CUSTOMER SALES/ORDER,ONLIN SALES,SALES RETURN)

                #region NORMAL CUSTOMER SALES

                DataSet elosales = objbs.sales_distribution(date.Text, sTableName, "'1'");
                gvnormalsales.DataSource = elosales.Tables[0];
                gvnormalsales.DataBind();

                DataSet elosorder = objbs.Order_distribution(date.Text, sTableName, "'15'", "'adv','Bal','Full','Partial Amount'");
                gvOrder.DataSource = elosorder.Tables[0];
                gvOrder.DataBind();


                DataSet elosordercancel = objbs.Order_distribution(date.Text, sTableName, "'15'", "'Refund','Refund/Cancel'");
                gvcancelorder.DataSource = elosordercancel.Tables[0];
                gvcancelorder.DataBind();

                double totalsalesamount = 0;
                double totalrefundamount = 0;

                for (int i = 0; i < elosales.Tables[0].Rows.Count; i++)
                {

                    double Stot = Convert.ToDouble(elosales.Tables[0].Rows[i]["Total"]);

                    totalsalesamount += Stot;
                }

                for (int ii = 0; ii < elosorder.Tables[0].Rows.Count; ii++)
                {
                    double Otot = Convert.ToDouble(elosorder.Tables[0].Rows[ii]["Total"]);
                    totalsalesamount += Otot;
                }

                lbl_Total_Sales_Amt.Text = totalsalesamount.ToString("0.00");

                for (int ii = 0; ii < elosordercancel.Tables[0].Rows.Count; ii++)
                {
                    string paymode = elosordercancel.Tables[0].Rows[ii]["paymode"].ToString();
                    if (paymode == "Cash")
                    {
                        double Otot = Convert.ToDouble(elosordercancel.Tables[0].Rows[ii]["Total"]);
                        totalrefundamount += Otot;
                    }
                }

                lbltotcshrefund.Text = totalrefundamount.ToString("0.00");
                #endregion

                #region Getting Online Sales

                double totonlinesales = 0;

                DataSet onlinesales = objbs.Onlinesales_distribution(date.Text, sTableName, "'1','9'");
                gvonlinesales.DataSource = onlinesales.Tables[0];
                gvonlinesales.DataBind();

                for (int ii = 0; ii < onlinesales.Tables[0].Rows.Count; ii++)
                {
                    double ONtot = Convert.ToDouble(onlinesales.Tables[0].Rows[ii]["Total"]);
                    totonlinesales += ONtot;
                }

                lblonlinesales.Text = totonlinesales.ToString("0.00");


                #endregion

                #region Getting Credit Sales

                double totcreditsales = 0;

                DataSet creditsales = objbs.sales_distribution(date.Text, sTableName, "'18'");
                gvcredit.DataSource = creditsales.Tables[0];
                gvcredit.DataBind();

                for (int ii = 0; ii < creditsales.Tables[0].Rows.Count; ii++)
                {
                    double ONtot = Convert.ToDouble(creditsales.Tables[0].Rows[ii]["Total"]);
                    totcreditsales += ONtot;
                }

                lblcreditsales.Text = totcreditsales.ToString("0.00");


                #endregion

                #region SALES RETURN/DEDUCTION
                double totsalesreturn = 0;

                DataSet salesreturn = objbs.Salesreturn_distribution(date.Text, sTableName);
                gvsalesreturn.DataSource = salesreturn.Tables[0];
                gvsalesreturn.DataBind();

                for (int ii = 0; ii < salesreturn.Tables[0].Rows.Count; ii++)
                {
                    double SRtot = Convert.ToDouble(salesreturn.Tables[0].Rows[ii]["Total"]);
                    totsalesreturn += SRtot;
                }
                lblSales_deductions_amt.Text = totsalesreturn.ToString("0.00");

                #endregion

                #endregion

                #region THIRD COLUMN DATAS (Denomination)

                DataSet getdenomination = objbs.griddenominationdetails(sTableName, date.Text);
                if (getdenomination.Tables[0].Rows.Count > 0)
                {
                    lbloverallcard.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverAllCard"]).ToString("0.00");
                    lbloverallpaytm.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverAllPaytm"]).ToString("0.00");
                    lbloverallphonepe.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverallPhonepe"]).ToString("0.00");
                    lblcreditamount.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverallCreditsales"]).ToString("0.00");
                    griddenomination.DataSource = getdenomination.Tables[0];
                    griddenomination.DataBind();

                    lblDenototal.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["Total"]).ToString("0.00");
                }
                else
                {
                    lbloverallcard.Text = "0";
                    lbloverallpaytm.Text = "0";
                    lbloverallphonepe.Text = "0";
                    lblcreditamount.Text = "0";
                    lblDenototal.Text = "0";
                    griddenomination.DataSource = null;
                    griddenomination.DataBind();
                }

                // GET CAHS OT OFFICE AND CLOSING REPORT

                DataSet getcashtoffice = objbs.gridcashsessionFordatewise(sTableName, "4", date.Text);
                if (getcashtoffice.Tables[0].Rows.Count > 0)
                {
                    double tott = 0;
                    for (int j = 0; j < getcashtoffice.Tables[0].Rows.Count; j++)
                    {

                        string nos = getcashtoffice.Tables[0].Rows[j]["Nos"].ToString();
                        string nameid = getcashtoffice.Tables[0].Rows[j]["nameid"].ToString();

                        for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
                        {
                            Label lblDenominationid = (Label)gvdenominationoffice.Rows[i].FindControl("lblDenominationid");
                            Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                            TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                            Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                            if (lblDenominationid.Text == nameid)
                            {
                                lblnos.Text = nos;

                                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                                tott += total;
                                lbltotal.Text = total.ToString("0.00");
                            }

                        }
                    }

                    Label10.Text = tott.ToString("0.00");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To Make Process.Thank You!!!');", true);
                    return;
                }

                DataSet getcashtclose = objbs.gridcashsessionFordatewise(sTableName, "2", date.Text);
                if (getcashtclose.Tables[0].Rows.Count > 0)
                {
                    double tottt = 0;
                    for (int j = 0; j < getcashtclose.Tables[0].Rows.Count; j++)
                    {

                        string nos = getcashtclose.Tables[0].Rows[j]["Nos"].ToString();
                        string nameid = getcashtclose.Tables[0].Rows[j]["nameid"].ToString();

                        for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
                        {
                            Label lblDenominationid = (Label)gvdenominationcloseing.Rows[i].FindControl("lblDenominationid");
                            Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                            TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                            Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

                            if (lblDenominationid.Text == nameid)
                            {
                                lblnos.Text = nos;

                                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                                tottt += total;
                                lbltotal.Text = total.ToString("0.00");
                            }

                        }
                    }

                    lblgrandtotalDenomin.Text = tottt.ToString("0.00");
                    txtopcash.Text = tottt.ToString("0.00");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                    return;
                }


                #endregion


                #region FIRST COLUMN
                DataTable dtt = new DataTable();
                DataRow dr = null;
                dtt.Columns.Add(new DataColumn("Nametype", typeof(string)));
                dtt.Columns.Add(new DataColumn("Total", typeof(string)));

                #region // GET CASH TO OFFICE FLOW
                double tot = 0;

                DataSet getcashtoofficeflow = objbs.getcashopcashtoofficedetails(sTableName, date.Text, "'1','4'");
                if (getcashtoofficeflow.Tables[0].Rows.Count > 0)
                {
                    for (int co = 0; co < getcashtoofficeflow.Tables[0].Rows.Count; co++)
                    {
                        string modename = getcashtoofficeflow.Tables[0].Rows[co]["sessionname"].ToString();
                        string Total = Convert.ToDouble(getcashtoofficeflow.Tables[0].Rows[co]["TotalCash"]).ToString("0.00");

                        dr = dtt.NewRow();
                        dr["Nametype"] = modename;
                        dr["Total"] = Total;
                        tot += Convert.ToDouble(Total);
                        dtt.Rows.Add(dr);
                    }


                }
                else
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "Cash To Office";
                    dr["Total"] = "0";
                    dtt.Rows.Add(dr);
                }

                lbltotoverallcash.Text = tot.ToString("0.00");

                #endregion

                #region // GET CARD AND PAYTM DETAILS

                DataSet getcardetailss = objbs.getcarddetails(sTableName, date.Text, "4");
                if (getcardetailss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double cardordertot = 0;
                    for (int co = 0; co < getcardetailss.Tables[0].Rows.Count; co++)
                    {
                        modename = getcardetailss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getcardetailss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        cardordertot += Convert.ToDouble(Total);
                    }

                    dr = dtt.NewRow();
                    dr["Nametype"] = modename;
                    dr["Total"] = cardordertot.ToString("0.00");
                    dtt.Rows.Add(dr);

                }
                else
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "Card";
                    dr["Total"] = "0";
                    dtt.Rows.Add(dr);
                }



                // GET PAYTM DETAILS
                DataSet getcardetailsss = objbs.getcarddetails(sTableName, date.Text, "10");
                if (getcardetailsss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double paytmordertot = 0;
                    for (int co = 0; co < getcardetailsss.Tables[0].Rows.Count; co++)
                    {
                        modename = getcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        paytmordertot += Convert.ToDouble(Total);
                    }

                    dr = dtt.NewRow();
                    dr["Nametype"] = modename;
                    dr["Total"] = paytmordertot;
                    dtt.Rows.Add(dr);
                }
                else
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "Paytm";
                    dr["Total"] = "0";
                    dtt.Rows.Add(dr);
                }

                // GET PhonePe DETAILS
                DataSet getcardetailssss = objbs.getcarddetails(sTableName, date.Text, "17");
                if (getcardetailssss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double paytmordertot = 0;
                    for (int co = 0; co < getcardetailssss.Tables[0].Rows.Count; co++)
                    {
                        modename = getcardetailssss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getcardetailssss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        paytmordertot += Convert.ToDouble(Total);
                    }

                    dr = dtt.NewRow();
                    dr["Nametype"] = modename;
                    dr["Total"] = paytmordertot;
                    dtt.Rows.Add(dr);
                }
                else
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "PhonePe";
                    dr["Total"] = "0";
                    dtt.Rows.Add(dr);
                }

                #endregion

                #region // GET TOTAL EXPENSE DETAILS
                DataSet gettotalexpense = objbs.gettotalexpense(sTableName, date.Text);
                if (gettotalexpense.Tables[0].Rows.Count > 0)
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "Total Expense";
                    dr["Total"] = Convert.ToDouble(gettotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                    lbltotexpense.Text = Convert.ToDouble(gettotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                    dtt.Rows.Add(dr);
                }
                else
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "Total Expense";
                    dr["Total"] = "0";
                    lbltotexpense.Text = "0";
                    dtt.Rows.Add(dr);
                }



                #endregion

                #region   // GET OP CASH

                double OPCASH = 0;

                DataSet getopcashflow = objbs.getcashopcashtoofficedetails(sTableName, date.Text, "'3'");
                if (getopcashflow.Tables[0].Rows.Count > 0)
                {
                    for (int co = 0; co < getopcashflow.Tables[0].Rows.Count; co++)
                    {
                        string modename = getopcashflow.Tables[0].Rows[co]["sessionname"].ToString();
                        string Total = Convert.ToDouble(getopcashflow.Tables[0].Rows[co]["TotalCash"]).ToString("0.00");

                        dr = dtt.NewRow();
                        dr["Nametype"] = "Opening Petty Cash";
                        dr["Total"] = Total;
                        OPCASH += Convert.ToDouble(Total);
                        dtt.Rows.Add(dr);
                    }

                }
                else
                {
                    dr = dtt.NewRow();
                    dr["Nametype"] = "Opening Petty Cash";
                    dr["Total"] = "0";
                    dtt.Rows.Add(dr);
                }
                lblopcashsales.Text = OPCASH.ToString("0.00");

                #endregion

                gridcashflowdetails.DataSource = dtt;
                gridcashflowdetails.DataBind();



                #region TOTAL EXPENSE DETAILS

                DataSet gettotaldetailsexpense = objbs.gettotaldetailsexpense(sTableName, date.Text);
                if (gettotaldetailsexpense.Tables[0].Rows.Count > 0)
                {
                    gridexpense.DataSource = gettotaldetailsexpense.Tables[0];
                    gridexpense.DataBind();
                }
                else
                {
                    gridexpense.DataSource = null;
                    gridexpense.DataBind();
                }
                #endregion


                #region GET OVERALL SALES
                double ovrtoto = 0;
                DataSet getoverallsales = objbs.getcashsalesandorderdetails(date.Text, sTableName, "1", "'adv','Bal','Full','Partial Amount'");
                if (getoverallsales.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < getoverallsales.Tables[0].Rows.Count; i++)
                    {

                        ovrtoto += Convert.ToDouble(getoverallsales.Tables[0].Rows[i]["Total"]);
                    }
                }

                lblcashsalescolumn1.Text = ovrtoto.ToString("0.00");
                lbltotalcashsales.Text = ovrtoto.ToString("0.00");
                // double balance = Convert.ToDouble(lbltotoverallcash.Text) + Convert.ToDouble(lbltotexpense.Text) - Convert.ToDouble(lblcashsalescolumn1.Text);
                // double balance = (Convert.ToDouble(lblcashsalescolumn1.Text) + Convert.ToDouble(lblopcashsales.Text)) - (Convert.ToDouble(lbltotexpense.Text) + Convert.ToDouble(lbltotoverallcash.Text));
                double balance = (Convert.ToDouble(lblcashsalescolumn1.Text) + Convert.ToDouble(lblopcashsales.Text)) - ((Convert.ToDouble(lbltotexpense.Text) + Convert.ToDouble(lbltotcshrefund.Text)) + Convert.ToDouble(lbltotoverallcash.Text));

                bool negative = balance < 0;

                if (negative == true)
                {

                    lblcurrentcash.Text = (-(balance)).ToString();
                }
                else
                {

                    lblcurrentcash.Text = balance.ToString();
                }

                lblcurrentcash.Text = Convert.ToDouble(balance).ToString("0.00");

                double difference = Convert.ToDouble(lblgrandtotalDenomin.Text) - Convert.ToDouble(lblcurrentcash.Text);

                lbldifferencevaluecolumn1.Text = difference.ToString("0.00");

                #endregion


                #endregion


                #region GET CLOSE

                // GETDAYCLOSE CASH
                DataSet checkdayclose = objbs.checkdayclose(sTableName, date.Text);
                if (checkdayclose.Tables[0].Rows.Count > 0)
                {
                    txtopcash.Text = Convert.ToDouble(checkdayclose.Tables[0].Rows[0]["ClosingPettyCash"]).ToString("0.00");
                    opcash(sender, e);
                }
                else
                {
                    // txtopcash.Text = "0";
                    opcash(sender, e);
                }

                #endregion


                //#region Cash flow
                //decimal dCreditCardSale = Convert.ToDecimal(lblCreditcard_Sales.Text);
                //OP_cash = Convert.ToDecimal(lblOP_Cash_Amt.Text);
                //OP_cash = Math.Round(OP_cash, 2);
                //total_denomination = Convert.ToDecimal(lblTotal_Denominations.Text);
                //total_denomination = Math.Round(total_denomination, 2);
                //cash_handover = Convert.ToDecimal(lblCash_handover_amt.Text);
                //cash_handover = Math.Round(cash_handover, 2);
                //lblCash_Closing_Amt.Text = Convert.ToString(total_denomination - cash_handover);
                //Closing_cash = Convert.ToDecimal(lblCash_Closing_Amt.Text);
                //Closing_cash = Math.Round(Closing_cash, 2);
                //tot_grosssales = cash_handover + Closing_cash + total + dCreditCardSale;
                //tot_grosssales = Math.Round(tot_grosssales, 2);
                //lblSales_Gross_amt.Text = tot_grosssales.ToString();
                //net_sales = (tot_grosssales - OP_cash);
                //net_sales = Math.Round(net_sales, 2);
                //lblNet_Sales_Amt.Text = net_sales.ToString();
                //lblSales_Result_amt.Text = (gross - net_sales).ToString();
                //#endregion


                #region SUMMARY VIEW
                DataTable dsumview = new DataTable();
                DataRow drsum = dsumview.NewRow();

                dsumview.Columns.Add("Name");
                dsumview.Columns.Add("Value");


                // DATE

                drsum["Name"] = "Date";
                drsum["Value"] = Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy");
                dsumview.Rows.Add(drsum);


                // Counter Sales


                DataSet getcountersales = objbs.getcountersales(date.Text, sTableName, "1", "'adv','Bal','Full','Partial Amount'");

                for (int i = 0; i < getcountersales.Tables[0].Rows.Count; i++)
                {

                    string name = getcountersales.Tables[0].Rows[i]["name"].ToString();

                    if (name == "Sales")
                    {
                        if (getcountersales.Tables[0].Rows.Count > 0)
                        {
                            drsum = dsumview.NewRow();
                            drsum["Name"] = "Counter Sales (CASH)";
                            drsum["Value"] = Convert.ToDouble(getcountersales.Tables[0].Rows[i]["Total"]).ToString("0.00");
                            dsumview.Rows.Add(drsum);
                        }
                        else
                        {
                            drsum = dsumview.NewRow();
                            drsum["Name"] = "Counter Sales (CASH)";
                            drsum["Value"] = "0";
                            dsumview.Rows.Add(drsum);
                        }

                    }
                    else if (name == "Order")
                    {
                        if (getcountersales.Tables[0].Rows.Count > 0)
                        {
                            drsum = dsumview.NewRow();
                            drsum["Name"] = "Order Form Sales (CASH)";
                            drsum["Value"] = Convert.ToDouble(getcountersales.Tables[0].Rows[i]["Total"]).ToString("0.00");
                            dsumview.Rows.Add(drsum);
                        }
                        else
                        {
                            drsum = dsumview.NewRow();
                            drsum["Name"] = "Order Form Sales (CASH)";
                            drsum["Value"] = "0";
                            dsumview.Rows.Add(drsum);
                        }

                    }
                }

                // get opnline  sales
                double summaryonlie = 0;
                DataSet summaryonlinesales = objbs.Onlinesales_distribution(date.Text, sTableName, "'1','9'");
                if (summaryonlinesales.Tables[0].Rows.Count > 0)
                {
                    for (int ii = 0; ii < summaryonlinesales.Tables[0].Rows.Count; ii++)
                    {
                        double ONtot = Convert.ToDouble(summaryonlinesales.Tables[0].Rows[ii]["Total"]);
                        summaryonlie += ONtot;
                    }
                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Online Sales";
                    drsum["Value"] = Convert.ToDouble(summaryonlie).ToString("0.00");
                    dsumview.Rows.Add(drsum);
                }
                else
                {
                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Online Sales";
                    drsum["Value"] = "0";
                    dsumview.Rows.Add(drsum);
                }


                // GET ALL CARD
                DataSet getsummarycardetailss = objbs.getcarddetails(sTableName, date.Text, "4");
                if (getsummarycardetailss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double cardordertot = 0;
                    for (int co = 0; co < getsummarycardetailss.Tables[0].Rows.Count; co++)
                    {
                        modename = getsummarycardetailss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getsummarycardetailss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        cardordertot += Convert.ToDouble(Total);
                    }

                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Card Sales";
                    drsum["Value"] = cardordertot.ToString("0.00");
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Actual Card Amount";
                    drsum["Value"] = Convert.ToDouble(lbloverallcard.Text).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Difference in Card Amount +/-";
                    drsum["Value"] = (Convert.ToDouble(lbloverallcard.Text) - Convert.ToDouble(cardordertot)).ToString("0.00");
                    dsumview.Rows.Add(drsum);

                }
                else
                {
                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Card Sales";
                    drsum["Value"] = "0";
                    dsumview.Rows.Add(drsum);
                }

                // GET PAYTM
                DataSet getsumcardetailsss = objbs.getcarddetails(sTableName, date.Text, "10");
                if (getsumcardetailsss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double paytmordertot = 0;
                    for (int co = 0; co < getsumcardetailsss.Tables[0].Rows.Count; co++)
                    {
                        modename = getsumcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getsumcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        paytmordertot += Convert.ToDouble(Total);
                    }

                    drsum = dsumview.NewRow();
                    drsum["Name"] = modename;
                    drsum["Value"] = paytmordertot;
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = lblbactpaytm.Text;
                    drsum["Value"] = Convert.ToDouble(lbloverallpaytm.Text).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = lblbdiffactpaytm.Text;
                    drsum["Value"] = (Convert.ToDouble(lbloverallpaytm.Text) - Convert.ToDouble(paytmordertot)).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                }
                else
                {
                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Paytm";
                    drsum["Value"] = "0";
                    dsumview.Rows.Add(drsum);
                }

                // GET PhonePe
                DataSet getsumcardetailssss = objbs.getcarddetails(sTableName, date.Text, "17");
                if (getsumcardetailssss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double phonepeordertot = 0;
                    for (int co = 0; co < getsumcardetailssss.Tables[0].Rows.Count; co++)
                    {
                        modename = getsumcardetailssss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getsumcardetailssss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        phonepeordertot += Convert.ToDouble(Total);
                    }

                    drsum = dsumview.NewRow();
                    drsum["Name"] = modename;
                    drsum["Value"] = phonepeordertot;
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Actual PhonePe Amount";
                    drsum["Value"] = Convert.ToDouble(lbloverallphonepe.Text).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Difference in PhonePe Amount +/-";
                    drsum["Value"] = (Convert.ToDouble(lbloverallphonepe.Text) - Convert.ToDouble(phonepeordertot)).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                }
                else
                {
                    drsum = dsumview.NewRow();
                    drsum["Name"] = "PhonePe";
                    drsum["Value"] = "0";
                    dsumview.Rows.Add(drsum);
                }
                //DataSet getsumcardetailsss = objbs.getcarddetails(sTableName, date.Text, "10");
                //if (getsumcardetailsss.Tables[0].Rows.Count > 0)
                //{
                //    for (int co = 0; co < getsumcardetailsss.Tables[0].Rows.Count; co++)
                //    {
                //        string modename = getsumcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
                //        string Total = Convert.ToDouble(getsumcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                //        drsum = dsumview.NewRow();
                //        drsum["name"] = "PayTM";
                //        drsum["Value"] = Total;
                //        dsumview.Rows.Add(drsum);
                //    }

                //}
                //else
                //{
                //    drsum = dsumview.NewRow();
                //    drsum["name"] = "PayTM";
                //    drsum["Value"] = "0";
                //    dsumview.Rows.Add(drsum);
                //}

                // GET ALL EXPENSE
                DataSet getsumtotalexpense = objbs.gettotalexpense(sTableName, date.Text);
                if (getsumtotalexpense.Tables[0].Rows.Count > 0)
                {
                    drsum = dsumview.NewRow();
                    drsum["name"] = "Total Expense";
                    drsum["Value"] = Convert.ToDouble(getsumtotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                    dsumview.Rows.Add(drsum);
                }
                else
                {
                    drsum = dsumview.NewRow();
                    drsum["name"] = "Total Expense";
                    drsum["Value"] = "0";
                    dsumview.Rows.Add(drsum);
                }

                // GET CREDIT SALES
               

                //DataSet sumcreditsales = objbs.sales_distribution(date.Text, sTableName, "'9'");
                //if (sumcreditsales.Tables[0].Rows.Count > 0)
                //{
                //    for (int ii = 0; ii < creditsales.Tables[0].Rows.Count; ii++)
                //    {
                //        double ONtot = Convert.ToDouble(creditsales.Tables[0].Rows[ii]["Total"]);
                //        totsumcreditsales += ONtot;
                //        drsum = dsumview.NewRow();
                //        drsum["Name"] = "Credit Sales ";
                //        drsum["Value"] = Convert.ToDouble(totsumcreditsales).ToString("0.00");
                //        dsumview.Rows.Add(drsum);





                //    }
                //}
                //else
                //{
                //    drsum = dsumview.NewRow();
                //    drsum["Name"] = "Credit Sales ";
                //    drsum["Value"] = "0";
                //    dsumview.Rows.Add(drsum);
                //}

                // GET Credit Sales
                DataSet getsumcreditetailsss = objbs.getcarddetails(sTableName, date.Text, "5");
                if (getsumcreditetailsss.Tables[0].Rows.Count > 0)
                {
                    string modename = string.Empty;
                    double totsumcreditsales = 0;
                    for (int co = 0; co < getsumcreditetailsss.Tables[0].Rows.Count; co++)
                    {
                        modename = getsumcreditetailsss.Tables[0].Rows[co]["paymode"].ToString();
                        string Total = Convert.ToDouble(getsumcreditetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                        totsumcreditsales += Convert.ToDouble(Total);
                    }

                    drsum = dsumview.NewRow();
                    drsum["Name"] = modename;
                    drsum["Value"] = totsumcreditsales;
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Actual Credit Amount";
                    drsum["Value"] = Convert.ToDouble(lblcreditamount.Text).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Difference in Credit Amount +/-";
                    drsum["Value"] = (Convert.ToDouble(lblcreditamount.Text) - Convert.ToDouble(totsumcreditsales)).ToString("0.00");
                    dsumview.Rows.Add(drsum);


                }
                else
                {
                    drsum = dsumview.NewRow();
                    drsum["Name"] = "Credit Amount";
                    drsum["Value"] = "0";
                    dsumview.Rows.Add(drsum);
                }


                // Discount sales

                DataSet getdiscountsalesandorder = objbs.getcountersalesandorderdiscount(date.Text, sTableName);
                if (getdiscountsalesandorder.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < getdiscountsalesandorder.Tables[0].Rows.Count; i++)
                    {
                        string name = getdiscountsalesandorder.Tables[0].Rows[i]["name"].ToString();
                        string money = getdiscountsalesandorder.Tables[0].Rows[i]["Total"].ToString();
                        if (money != "0.0000")
                        {

                            drsum = dsumview.NewRow();
                            drsum["Name"] = name;
                            drsum["Value"] = Convert.ToDouble(money).ToString("0.00");
                            dsumview.Rows.Add(drsum);
                        }
                    }
                }



                // + OR -
                drsum = dsumview.NewRow();
                drsum["name"] = "Difference in Cash Amount +/-";
                drsum["Value"] = lbldifferencevaluecolumn1.Text;
                dsumview.Rows.Add(drsum);

                GridsummaryView.DataSource = dsumview;
                GridsummaryView.DataBind();

                #endregion



                #region Order Form Sales
                DataSet ds = objbs.getbranchordersummaryMail(sTableName, Convert.ToInt32(lbldays.Text));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BankGrid.DataSource = ds;
                        BankGrid.DataBind();

                        
                    }
                    else
                    {
                        BankGrid.DataSource = null;
                        BankGrid.DataBind();
                    }
                }
                else
                {
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
                #endregion

                #region Sales and Order Details

                DataSet dstd = new DataSet();

                #region Sales


                DataSet FullValues = objbs.GetFullValuesForSalesinvoice(sTableName, date.Text, date.Text, lblpaymode.Text);

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Bcode");
                dtraw.Columns.Add("Date");
                dtraw.Columns.Add("grnsource");
                dtraw.Columns.Add("Category");
                dtraw.Columns.Add("Itemname");
                dtraw.Columns.Add("GST");
                dtraw.Columns.Add("Qty");
                dtraw.Columns.Add("rate");
                dtraw.Columns.Add("TotalRate");
                dtraw.Columns.Add("Margin");
                dtraw.Columns.Add("Marginvalue");
                dtraw.Columns.Add("BasicCostAfterMargin");
                dtraw.Columns.Add("GSTvalue");
                dtraw.Columns.Add("NetAmount");
                dsraw.Tables.Add(dtraw);

                if (FullValues.Tables[0].Rows.Count > 0)
                {
                    DataTable dtrawss = new DataTable();

                    dtrawss = FullValues.Tables[0];

                    var result1 = from r in dtrawss.AsEnumerable()
                                  group r by new { Bcode = r["Bcode"], Date = r["Date"], grnsource = r["grnsource"], Category = r["Category"], Itemname = r["Itemname"], GST = r["GST"], Rate = r["Rate"], margin = r["margin"] } into raw
                                  select new
                                  {
                                      Bcode = raw.Key.Bcode,
                                      Date = raw.Key.Date,
                                      grnsource = raw.Key.grnsource,
                                      Category = raw.Key.Category,
                                      Itemname = raw.Key.Itemname,
                                      GST = raw.Key.GST,
                                      Rate = raw.Key.Rate,
                                      margin = raw.Key.margin,
                                      Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                      TotalRate = raw.Sum(x => Convert.ToDouble(x["TotalRate"])),
                                      Marginvalue = raw.Sum(x => Convert.ToDouble(x["Marginvalue"])),
                                      BasicCostAfterMargin = raw.Sum(x => Convert.ToDouble(x["BasicCostAfterMargin"])),
                                      GSTvalue = raw.Sum(x => Convert.ToDouble(x["GSTvalue"])),
                                      NetAmount = raw.Sum(x => Convert.ToDouble(x["NetAmount"])),
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();


                        drraw["Bcode"] = g.Bcode;
                        drraw["Date"] = Convert.ToDateTime(g.Date).ToString("dd/MM/yyyy");
                        drraw["grnsource"] = g.grnsource;
                        drraw["Category"] = g.Category;
                        drraw["Itemname"] = g.Itemname;
                        drraw["GST"] = g.GST;
                        drraw["Qty"] = g.Qty;
                        drraw["rate"] = Convert.ToDouble(g.Rate).ToString("0.00");
                        drraw["TotalRate"] = Convert.ToDouble(g.TotalRate).ToString("0.00"); ;
                        drraw["Margin"] = g.margin;
                        drraw["Marginvalue"] = Convert.ToDouble(g.Marginvalue).ToString("0.00");
                        drraw["BasicCostAfterMargin"] = Convert.ToDouble(g.BasicCostAfterMargin).ToString("0.00");
                        drraw["GSTvalue"] = Convert.ToDouble(g.GSTvalue).ToString("0.00");
                        drraw["NetAmount"] = Convert.ToDouble(g.NetAmount).ToString("0.00");
                        dsraw.Tables[0].Rows.Add(drraw);
                    }

                }
                gvSalesValue.Caption = "SALES";
                DataView view = dsraw.Tables[0].DefaultView;
                view.Sort = " Date,Category ASC";

          //      gvSalesValue.DataSource = view;
            //    gvSalesValue.DataBind();

                #endregion

                #region Order

                DataSet FullValuesorder = objbs.GetFullValuesFororderinvoice(sTableName, date.Text, date.Text);
                gvorder1.Caption = "Order Form";
                DataView view1 = FullValuesorder.Tables[0].DefaultView;
                view1.Sort = "Billdate ASC";
                gvorder1.DataSource = view1;
                gvorder1.DataBind();

                #endregion

                #endregion


                #region ORDER DELIVERY REPORT
                {
                    if (date.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Select Date.Thank you!!!.');", true);
                        return;
                    }


                    DataTable dtord = new DataTable();
                    dtord.Columns.Add("Book No");
                    dtord.Columns.Add("Order No");
                    dtord.Columns.Add("Order Date");
                    dtord.Columns.Add("Delivery Date");
                    dtord.Columns.Add("Customer Name");
                    dtord.Columns.Add("Mobilno");
                    dtord.Columns.Add("NetTotal");
                    dtord.Columns.Add("Total");
                    dtord.Columns.Add("Advance");
                    dtord.Columns.Add("Item");
                    dtord.Columns.Add("Dstatus");

                    DateTime sDate = Convert.ToDateTime(date.Text);

                    DataSet getorderinfo = objbs.GetCakerOrderINFO("tblorder_" + sTableName + "", sDate);
                    if (getorderinfo.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
                        {

                            DataRow drord = dtord.NewRow();
                            string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
                            drord["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
                            drord["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
                            drord["Order Date"] = getorderinfo.Tables[0].Rows[i]["orderdate"].ToString();
                            drord["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MM/yyyy");
                            drord["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
                            drord["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
                            drord["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
                            drord["Total"] = Convert.ToDouble(getorderinfo.Tables[0].Rows[i]["Total"]).ToString("0.00");
                            drord["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();
                            drord["Dstatus"] = getorderinfo.Tables[0].Rows[i]["DeliveryStatus"].ToString();


                            DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + sTableName + "", billno);
                            if (getorderitem.Tables[0].Rows.Count > 0)
                            {
                                string itemqty = string.Empty;

                                for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
                                {
                                    itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
                                }
                                itemqty = itemqty.TrimEnd(',');
                                drord["Item"] = itemqty;
                            }
                            dtord.Rows.Add(drord);
                        }
                        gvorderinfo.Caption = "Cake Order Remainder Report";
                        gvorderinfo.DataSource = dtord;
                        gvorderinfo.DataBind();


                    }
                    gvorderinfo.Visible = true;

                }


                #endregion

                //SendHTMLMail1();
                //SendMailforTodayOrderandSales();


            }


        }



        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            sTableName = Request.Cookies["userInfo"]["User"].ToString();



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("GridView11") as GridView;
                GridView gvGroup = (GridView)sender;

                string id = (gvGroup.DataKeys[e.Row.RowIndex].Values[0]).ToString();
                string branchcode = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();

                if (gvGroup.DataKeys[e.Row.RowIndex].Values[0].ToString() != "")
                {

                    DataSet dst = objbs.getbranchordersummaryitemmail(id, branchcode);

                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = dst;
                        gv.DataBind();
                    }
                    else
                    {
                        gv.DataSource = null;
                        gv.DataBind();
                    }

                }
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {

            SendHTMLMail();

            SendHTMLMail2();

        }


        // This Method is used to render gridview control
        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        public string GetGridviewData1(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        public string GetGridviewData2(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        public void SendHTMLMail1()
        {

            MailMessage Msg = new MailMessage();
            // MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            Msg.From = new MailAddress("jothics0792@gmail.com", "Blaack Forest - Ceremony Report "+sTableName+"");
            // Sender e-mail address.
            //  Msg.From = fromMail;

            // Subject of e-mail
            Msg.Subject = "Order Ceremony Report For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "<br/> Summary Flow Details <br/>";
            Msg.Body += GetGridviewData1(BankGrid);
            //Msg.Body += "<br/> Summary  Details <br/>";
            //Msg.Body += GetGridviewData(gridsummarydetails);
            //Msg.Body += "<br/> Expense Details <br/>";
            //Msg.Body += GetGridviewData(gridexpense);
            //Msg.Body += "<br/> Normal Sales Details <br/>";
            //Msg.Body += GetGridviewData(gvnormalsales);
            //Msg.Body += "<br/> Order Details <br/>";
            //Msg.Body += GetGridviewData(gvOrder);
            //Msg.Body += "<br/> Cancel Order Details <br/>";
            //Msg.Body += GetGridviewData(gvcancelorder);
            //Msg.Body += "<br/> Online Sales/Order Details <br/>";
            //Msg.Body += GetGridviewData(gvonlinesales);
            //Msg.Body += "<br/> Sales Return Details <br/>";
            //Msg.Body += GetGridviewData(gvsalesreturn);
            //Msg.Body += "<br/> Over All Denomination Details <br/>";
            //Msg.Body += GetGridviewData(griddenomination);
            //Msg.Body += "<br/> Last Cash To Office Denomination Details <br/>";
            //Msg.Body += GetGridviewData(gvdenominationoffice);
            //Msg.Body += "<br/> Closing Cash Denomination Details <br/>";
            //Msg.Body += GetGridviewData(gvdenominationcloseing);

            Msg.IsBodyHtml = true;

            string mutltiemail = lblordermail.Text;

            string[] Multi = mutltiemail.Split(',');
            foreach (string Multiemailid in Multi)
            {
                Msg.To.Add(new MailAddress(Multiemailid));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }

        public void SendHTMLMail2()
        {

            MailMessage Msg = new MailMessage();
            // MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            Msg.From = new MailAddress("jothics0792@gmail.com", "Blaack Forest - Order Form Delivery Status Report " + sTableName + "");
            // Sender e-mail address.
            //  Msg.From = fromMail;

            // Subject of e-mail
            Msg.Subject = "Order Form Delivery Status Report For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "<br/> Order Form Details <br/>";
            Msg.Body += GetGridviewData2(gvorderinfo);
            

            Msg.IsBodyHtml = true;

            string mutltiemail = txtdelorderemail.Text;

            string[] Multi = mutltiemail.Split(',');
            foreach (string Multiemailid in Multi)
            {
                Msg.To.Add(new MailAddress(Multiemailid));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }



        public void SendHTMLMail()
        {

            MailMessage Msg = new MailMessage();
            //MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            Msg.From = new MailAddress("jothics0792@gmail.com", "Blaack Forest Day Closing Report For "+sTableName+"");
            // Sender e-mail address.
            //Msg.From = fromMail;

            // Subject of e-mail
            Msg.Subject = "Day Closing Details For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "<br/> Summary Flow Details <br/>";
            Msg.Body += GetGridviewData(GridsummaryView);

            //Msg.Body += "<br/><br/>";
            //Msg.Body += lblCaption.Text;
            //Msg.Body += GetGridviewDatasales(gvCustsales);
            //Msg.Body += "<br/> Total Net amount:" + lblTotal.InnerText + " <br/>";
            //Msg.Body += "<br/> Total Disc amount:" + disc.InnerText + " <br/>";
            //Msg.Body += "<br/> Total amount:" + gndtotal.InnerText + " <br/>";

            //Msg.Body += "<br/> Summary  Details <br/>";
            //Msg.Body += GetGridviewData(gridsummarydetails);
            //Msg.Body += "<br/> Expense Details <br/>";
            //Msg.Body += GetGridviewData(gridexpense);
            //Msg.Body += "<br/> Normal Sales Details <br/>";
            //Msg.Body += GetGridviewData(gvnormalsales);
            //Msg.Body += "<br/> Order Details <br/>";
            //Msg.Body += GetGridviewData(gvOrder);
            //Msg.Body += "<br/> Cancel Order Details <br/>";
            //Msg.Body += GetGridviewData(gvcancelorder);
            //Msg.Body += "<br/> Online Sales/Order Details <br/>";
            //Msg.Body += GetGridviewData(gvonlinesales);
            //Msg.Body += "<br/> Sales Return Details <br/>";
            //Msg.Body += GetGridviewData(gvsalesreturn);
            //Msg.Body += "<br/> Over All Denomination Details <br/>";
            //Msg.Body += GetGridviewData(griddenomination);
            //Msg.Body += "<br/> Last Cash To Office Denomination Details <br/>";
            //Msg.Body += GetGridviewData(gvdenominationoffice);
            //Msg.Body += "<br/> Closing Cash Denomination Details <br/>";
            //Msg.Body += GetGridviewData(gvdenominationcloseing);

            Msg.IsBodyHtml = true;

            string mutltiemail = txtemail.Text;

            string[] Multi = mutltiemail.Split(',');
            foreach (string Multiemailid in Multi)
            {
                Msg.To.Add(new MailAddress(Multiemailid));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }



        protected void btncalc_Click(object sender, EventArgs e)
        {
            if (drpsessiontype.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                return;
            }

            double tot = 0;
            for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            {

                Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

                if (lblnos.Text == "")
                    lblnos.Text = "0";

                double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                tot += total;
                lbltotal.Text = total.ToString("0.00");

            }

            lblgrandtotalDenomin.Text = tot.ToString("0.00");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (drpsessiontype.SelectedValue == "Select Type")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
            //    return;
            //}

            //double tot = 0;
            //for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            //{

            //    Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
            //    TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
            //    Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

            //    if (lblnos.Text == "")
            //        lblnos.Text = "0";

            //    double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
            //    tot += total;
            //    lbltotal.Text = total.ToString("0.00");

            //}

            //lblgrandtotalDenomin.Text = tot.ToString("0.00");

            //if (lblgrandtotalDenomin.Text == "0.00" || lblgrandtotalDenomin.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Fill Session Entry Amount.Thank You!!!');", true);
            //    return;
            //}


            //int iss = objbs.cashsessionEntry(drpsessiontype.SelectedValue, lblgrandtotalDenomin.Text, sTableName, "Closing Petty Cash");
            //for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
            //{
            //    Label lblDenominationid = (Label)gvdenominationcloseing.Rows[i].FindControl("lblDenominationid");
            //    Label lblname = (Label)gvdenominationcloseing.Rows[i].FindControl("lblname");
            //    Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
            //    TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
            //    Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");


            //    int isss = objbs.TranscashsessionEntry(lblname.Text, lblDenominationid.Text, lblvalue.Text, lbltotal.Text, sTableName, lblnos.Text);

            //}

            //Button4.Enabled = false;
        }


        protected void opcash(object sender, EventArgs e)
        {
            if (txtopcash.Text == "")
                txtopcash.Text = "0";


            double currentcash = Convert.ToDouble(lblcurrentcash.Text);

            double opcashtaken = Convert.ToDouble(txtopcash.Text);

            lblcashtaken.Text = (Convert.ToDouble(currentcash) - Convert.ToDouble(opcashtaken)).ToString("0.00");

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            #region SECOND COLUMN DATAS (CUSTOMER SALES/ORDER,ONLIN SALES,SALES RETURN)

            #region NORMAL CUSTOMER SALES

            DataSet elosales = objbs.sales_distribution(date.Text, sTableName, "'1'");
            gvnormalsales.DataSource = elosales.Tables[0];
            gvnormalsales.DataBind();

            DataSet elosorder = objbs.Order_distribution(date.Text, sTableName, "'15'", "'adv','Bal','Full','Partial Amount'");
            gvOrder.DataSource = elosorder.Tables[0];
            gvOrder.DataBind();


            DataSet elosordercancel = objbs.Order_distribution(date.Text, sTableName, "'15'", "'Refund','Refund/Cancel'");
            gvcancelorder.DataSource = elosordercancel.Tables[0];
            gvcancelorder.DataBind();

            double totalsalesamount = 0;
            double totalrefundamount = 0;

            for (int i = 0; i < elosales.Tables[0].Rows.Count; i++)
            {

                double Stot = Convert.ToDouble(elosales.Tables[0].Rows[i]["Total"]);

                totalsalesamount += Stot;
            }

            for (int ii = 0; ii < elosorder.Tables[0].Rows.Count; ii++)
            {
                double Otot = Convert.ToDouble(elosorder.Tables[0].Rows[ii]["Total"]);
                totalsalesamount += Otot;
            }

            lbl_Total_Sales_Amt.Text = totalsalesamount.ToString("0.00");

            for (int ii = 0; ii < elosordercancel.Tables[0].Rows.Count; ii++)
            {
                string paymode = elosordercancel.Tables[0].Rows[ii]["paymode"].ToString();
                if (paymode == "Cash")
                {
                    double Otot = Convert.ToDouble(elosordercancel.Tables[0].Rows[ii]["Total"]);
                    totalrefundamount += Otot;
                }
            }

            lbltotcshrefund.Text = totalrefundamount.ToString("0.00");



            #endregion

            #region Getting Online Sales

            DataTable dtt1 = new DataTable();
            DataRow dr1 = null;
            dtt1.Columns.Add(new DataColumn("SalesType", typeof(string)));
            dtt1.Columns.Add(new DataColumn("paymenttype", typeof(string)));
            dtt1.Columns.Add(new DataColumn("Total", typeof(string)));


            double totonlinesales = 0;

            DataSet onlinesales = objbs.Onlinesales_distribution(date.Text, sTableName, "'1','9'");


            for (int ii = 0; ii < onlinesales.Tables[0].Rows.Count; ii++)
            {
                string SalesType = onlinesales.Tables[0].Rows[ii]["SalesType"].ToString();
                string paymenttype = onlinesales.Tables[0].Rows[ii]["paymenttype"].ToString();
                double ONtot = Convert.ToDouble(onlinesales.Tables[0].Rows[ii]["Total"]);
                // totonlinesales += ONtot;

                dr1 = dtt1.NewRow();
                dr1["SalesType"] = SalesType;
                dr1["paymenttype"] = paymenttype;
                dr1["Total"] = ONtot;
                totonlinesales += Convert.ToDouble(ONtot);
                dtt1.Rows.Add(dr1);
            }

            DataSet onlinecake = objbs.Order_distributionforonline(date.Text, sTableName, "'15'");
            for (int ii = 0; ii < onlinecake.Tables[0].Rows.Count; ii++)
            {
                string SalesType = onlinecake.Tables[0].Rows[ii]["paytype"].ToString();
                string paymenttype = onlinecake.Tables[0].Rows[ii]["paymode"].ToString();
                double ONtot = Convert.ToDouble(onlinecake.Tables[0].Rows[ii]["Total"]);
                // totonlinesales += ONtot;

                dr1 = dtt1.NewRow();
                dr1["SalesType"] = paymenttype;
                dr1["paymenttype"] = SalesType;
                dr1["Total"] = ONtot;
                totonlinesales += Convert.ToDouble(ONtot);
                dtt1.Rows.Add(dr1);
            }

            gvonlinesales.DataSource = dtt1;
            gvonlinesales.DataBind();

            lblonlinesales.Text = totonlinesales.ToString("0.00");


            #endregion

            #region Getting Credit Sales

            double totcreditsales = 0;

            DataSet creditsales = objbs.sales_distribution(date.Text, sTableName, "'18'");
            gvcredit.DataSource = creditsales.Tables[0];
            gvcredit.DataBind();

            for (int ii = 0; ii < creditsales.Tables[0].Rows.Count; ii++)
            {
                double ONtot = Convert.ToDouble(creditsales.Tables[0].Rows[ii]["Total"]);
                totcreditsales += ONtot;
            }

            lblcreditsales.Text = totcreditsales.ToString("0.00");


            #endregion

            #region SALES RETURN/DEDUCTION
            double totsalesreturn = 0;

            DataSet salesreturn = objbs.Salesreturn_distribution(date.Text, sTableName);
            gvsalesreturn.DataSource = salesreturn.Tables[0];
            gvsalesreturn.DataBind();

            for (int ii = 0; ii < salesreturn.Tables[0].Rows.Count; ii++)
            {
                double SRtot = Convert.ToDouble(salesreturn.Tables[0].Rows[ii]["Total"]);
                totsalesreturn += SRtot;
            }
            lblSales_deductions_amt.Text = totsalesreturn.ToString("0.00");

            #endregion

            #endregion

            #region THIRD COLUMN DATAS (Denomination)

            DataSet getdenomination = objbs.griddenominationdetails(sTableName, date.Text);
            if (getdenomination.Tables[0].Rows.Count > 0)
            {
                lbloverallcard.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverAllCard"]).ToString("0.00");
                lbloverallpaytm.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverAllPaytm"]).ToString("0.00");
                lbloverallphonepe.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverallPhonepe"]).ToString("0.00");
                lblcreditamount.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["OverallCreditsales"]).ToString("0.00");
                griddenomination.DataSource = getdenomination.Tables[0];
                griddenomination.DataBind();


                lblDenototal.Text = Convert.ToDouble(getdenomination.Tables[0].Rows[0]["Total"]).ToString("0.00");
            }
            else
            {
                lbloverallcard.Text = "0";
                lbloverallpaytm.Text = "0";
                lbloverallphonepe.Text = "0";
                lblcreditamount.Text = "0";
                lblDenototal.Text = "0";
                griddenomination.DataSource = null;
                griddenomination.DataBind();
            }

            // GET CASH OT OFFICE AND CLOSING REPORT

            DataSet getcashtoffice = objbs.gridcashsessionFordatewise(sTableName, drpsessiontype1.SelectedValue, date.Text);
            if (getcashtoffice.Tables[0].Rows.Count > 0)
            {
                double tott = 0;
                for (int j = 0; j < getcashtoffice.Tables[0].Rows.Count; j++)
                {

                    string nos = getcashtoffice.Tables[0].Rows[j]["Nos"].ToString();
                    string nameid = getcashtoffice.Tables[0].Rows[j]["nameid"].ToString();

                    for (int i = 0; i < gvdenominationoffice.Rows.Count; i++)
                    {

                        Label lblvalue = (Label)gvdenominationoffice.Rows[i].FindControl("lblvalue");
                        Label lblDenominationid = (Label)gvdenominationoffice.Rows[i].FindControl("lblDenominationid");

                        TextBox lblnos = (TextBox)gvdenominationoffice.Rows[i].FindControl("lblnos");
                        Label lbltotal = (Label)gvdenominationoffice.Rows[i].FindControl("lbltotal");

                        if (lblDenominationid.Text == nameid)
                        {
                            lblnos.Text = nos;

                            double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                            tott += total;
                            lbltotal.Text = total.ToString("0.00");
                        }

                    }
                }

                Label10.Text = tott.ToString("0.00");
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To Make Process.Thank You!!!');", true);
                //return;
            }

            DataSet getcashtclose = objbs.gridcashsessionFordatewise(sTableName, drpsessiontype.SelectedValue, date.Text);
            double tottt = 0;
            if (getcashtclose.Tables[0].Rows.Count > 0)
            {

                for (int j = 0; j < getcashtclose.Tables[0].Rows.Count; j++)
                {

                    string nos = getcashtclose.Tables[0].Rows[j]["Nos"].ToString();
                    string nameid = getcashtclose.Tables[0].Rows[j]["nameid"].ToString();

                    for (int i = 0; i < gvdenominationcloseing.Rows.Count; i++)
                    {
                        Label lblDenominationid = (Label)gvdenominationcloseing.Rows[i].FindControl("lblDenominationid");
                        Label lblvalue = (Label)gvdenominationcloseing.Rows[i].FindControl("lblvalue");
                        TextBox lblnos = (TextBox)gvdenominationcloseing.Rows[i].FindControl("lblnos");
                        Label lbltotal = (Label)gvdenominationcloseing.Rows[i].FindControl("lbltotal");

                        if (lblDenominationid.Text == nameid)
                        {
                            lblnos.Text = nos;

                            double total = (Convert.ToDouble(lblvalue.Text) * Convert.ToDouble(lblnos.Text));
                            tottt += total;
                            lbltotal.Text = total.ToString("0.00");
                        }

                    }
                }


            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Session Mode Type.Thank You!!!');", true);
                // return;
            }
            lblgrandtotalDenomin.Text = tottt.ToString("0.00");
            txtopcash.Text = tottt.ToString("0.00");

            #endregion


            #region FIRST COLUMN
            DataTable dtt = new DataTable();
            DataRow dr = null;
            dtt.Columns.Add(new DataColumn("Nametype", typeof(string)));
            dtt.Columns.Add(new DataColumn("Total", typeof(string)));

            #region // GET CASH TO OFFICE FLOW
            double tot = 0;

            DataSet getcashtoofficeflow = objbs.getcashopcashtoofficedetails(sTableName, date.Text, "'1','4'");
            if (getcashtoofficeflow.Tables[0].Rows.Count > 0)
            {
                for (int co = 0; co < getcashtoofficeflow.Tables[0].Rows.Count; co++)
                {
                    string modename = getcashtoofficeflow.Tables[0].Rows[co]["sessionname"].ToString();
                    string Total = Convert.ToDouble(getcashtoofficeflow.Tables[0].Rows[co]["TotalCash"]).ToString("0.00");

                    dr = dtt.NewRow();
                    dr["Nametype"] = modename;
                    dr["Total"] = Total;
                    tot += Convert.ToDouble(Total);
                    dtt.Rows.Add(dr);
                }


            }
            else
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "Cash To Office";
                dr["Total"] = "0";
                dtt.Rows.Add(dr);
            }

            lbltotoverallcash.Text = tot.ToString("0.00");

            #endregion

            #region // GET CARD AND PAYTM DETAILS

            DataSet getcardetailss = objbs.getcarddetails(sTableName, date.Text, "4");
            if (getcardetailss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double cardordertot = 0;
                for (int co = 0; co < getcardetailss.Tables[0].Rows.Count; co++)
                {
                    modename = getcardetailss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getcardetailss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    cardordertot += Convert.ToDouble(Total);
                }

                dr = dtt.NewRow();
                dr["Nametype"] = modename;
                dr["Total"] = cardordertot.ToString("0.00");
                dtt.Rows.Add(dr);

            }
            else
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "Card";
                dr["Total"] = "0";
                dtt.Rows.Add(dr);
            }



            // GET PAYTM DETAILS
            DataSet getcardetailsss = objbs.getcarddetails(sTableName, date.Text, "10");
            if (getcardetailsss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double paytmordertot = 0;
                for (int co = 0; co < getcardetailsss.Tables[0].Rows.Count; co++)
                {
                    modename = getcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    paytmordertot += Convert.ToDouble(Total);
                }

                dr = dtt.NewRow();
                dr["Nametype"] = modename;
                dr["Total"] = paytmordertot;
                dtt.Rows.Add(dr);
            }
            else
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "Paytm";
                dr["Total"] = "0";
                dtt.Rows.Add(dr);
            }

            // GET PhonePe DETAILS
            DataSet getcardetailssss = objbs.getcarddetails(sTableName, date.Text, "17");
            if (getcardetailssss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double paytmordertot = 0;
                for (int co = 0; co < getcardetailssss.Tables[0].Rows.Count; co++)
                {
                    modename = getcardetailssss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getcardetailssss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    paytmordertot += Convert.ToDouble(Total);
                }

                dr = dtt.NewRow();
                dr["Nametype"] = modename;
                dr["Total"] = paytmordertot;
                dtt.Rows.Add(dr);
            }
            else
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "PhonePe";
                dr["Total"] = "0";
                dtt.Rows.Add(dr);
            }

            #endregion

            #region // GET TOTAL EXPENSE DETAILS
            DataSet gettotalexpense = objbs.gettotalexpense(sTableName, date.Text);
            if (gettotalexpense.Tables[0].Rows.Count > 0)
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "Total Expense";
                dr["Total"] = Convert.ToDouble(gettotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                lbltotexpense.Text = Convert.ToDouble(gettotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                dtt.Rows.Add(dr);
            }
            else
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "Total Expense";
                dr["Total"] = "0";
                lbltotexpense.Text = "0";
                dtt.Rows.Add(dr);
            }

            #endregion

            #region   // GET OP CASH

            double OPCASH = 0;

            DataSet getopcashflow = objbs.getcashopcashtoofficedetails(sTableName, date.Text, "'3'");
            if (getopcashflow.Tables[0].Rows.Count > 0)
            {
                for (int co = 0; co < getopcashflow.Tables[0].Rows.Count; co++)
                {
                    string modename = getopcashflow.Tables[0].Rows[co]["sessionname"].ToString();
                    string Total = Convert.ToDouble(getopcashflow.Tables[0].Rows[co]["TotalCash"]).ToString("0.00");

                    dr = dtt.NewRow();
                    dr["Nametype"] = "Opening Petty Cash";
                    dr["Total"] = Total;
                    OPCASH += Convert.ToDouble(Total);
                    dtt.Rows.Add(dr);
                }

            }
            else
            {
                dr = dtt.NewRow();
                dr["Nametype"] = "Opening Petty Cash";
                dr["Total"] = "0";
                dtt.Rows.Add(dr);
            }
            lblopcashsales.Text = OPCASH.ToString("0.00");

            #endregion

            gridcashflowdetails.DataSource = dtt;
            gridcashflowdetails.DataBind();



            #region TOTAL EXPENSE DETAILS

            DataSet gettotaldetailsexpense = objbs.gettotaldetailsexpense(sTableName, date.Text);
            if (gettotaldetailsexpense.Tables[0].Rows.Count > 0)
            {
                gridexpense.DataSource = gettotaldetailsexpense.Tables[0];
                gridexpense.DataBind();
            }
            else
            {
                gridexpense.DataSource = null;
                gridexpense.DataBind();
            }
            #endregion


            #region GET OVERALL SALES
            double ovrtoto = 0;
            DataSet getoverallsales = objbs.getcashsalesandorderdetails(date.Text, sTableName, "1", "'adv','Bal','Full','Partial Amount'");
            if (getoverallsales.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < getoverallsales.Tables[0].Rows.Count; i++)
                {

                    ovrtoto += Convert.ToDouble(getoverallsales.Tables[0].Rows[i]["Total"]);
                }
            }

            lblcashsalescolumn1.Text = ovrtoto.ToString("0.00");
            lbltotalcashsales.Text = ovrtoto.ToString("0.00");
            //  double balance = Convert.ToDouble(lbltotoverallcash.Text) + Convert.ToDouble(lbltotexpense.Text) - Convert.ToDouble(lblcashsalescolumn1.Text);
            double balance = (Convert.ToDouble(lblcashsalescolumn1.Text) + Convert.ToDouble(lblopcashsales.Text)) - ((Convert.ToDouble(lbltotexpense.Text) + Convert.ToDouble(lbltotcshrefund.Text)) + Convert.ToDouble(lbltotoverallcash.Text));

            bool negative = balance < 0;

            if (negative == true)
            {

                lblcurrentcash.Text = (-(balance)).ToString();
            }
            else
            {

                lblcurrentcash.Text = balance.ToString();
            }


            lblcurrentcash.Text = Convert.ToDouble(balance).ToString("0.00");


            double difference = Convert.ToDouble(lblgrandtotalDenomin.Text) - Convert.ToDouble(lblcurrentcash.Text);

            lbldifferencevaluecolumn1.Text = difference.ToString("0.00");

            #endregion


            #endregion

            #region GET CLOSE

            // GETDAYCLOSE CASH
            DataSet checkdayclose = objbs.checkdayclose(sTableName, date.Text);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {
                txtopcash.Text = Convert.ToDouble(checkdayclose.Tables[0].Rows[0]["ClosingPettyCash"]).ToString("0.00");
                opcash(sender, e);
            }
            else
            {
                // txtopcash.Text = "0";
                opcash(sender, e);
            }

            #endregion


            #region SUMMARY VIEW
            DataTable dsumview = new DataTable();
            DataRow drsum = dsumview.NewRow();

            dsumview.Columns.Add("Name");
            dsumview.Columns.Add("Value");


            // DATE

            drsum["Name"] = "Date ";
            drsum["Value"] = Convert.ToDateTime(date.Text).ToString("dd/MM/yyyy");
            dsumview.Rows.Add(drsum);




            // Counter Sales


            DataSet getcountersales = objbs.getcountersales(date.Text, sTableName, "1", "'adv','Bal','Full','Partial Amount'");

            for (int i = 0; i < getcountersales.Tables[0].Rows.Count; i++)
            {

                string name = getcountersales.Tables[0].Rows[i]["name"].ToString();

                if (name == "Sales")
                {
                    if (getcountersales.Tables[0].Rows.Count > 0)
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Counter Sales (CASH)";
                        drsum["Value"] = Convert.ToDouble(getcountersales.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dsumview.Rows.Add(drsum);
                    }
                    else
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Counter Sales (CASH)";
                        drsum["Value"] = "0";
                        dsumview.Rows.Add(drsum);
                    }

                }
                else if (name == "Order")
                {
                    if (getcountersales.Tables[0].Rows.Count > 0)
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Order Form Sales (CASH) ";
                        drsum["Value"] = Convert.ToDouble(getcountersales.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dsumview.Rows.Add(drsum);
                    }
                    else
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Order Form Sales (CASH) ";
                        drsum["Value"] = "0";
                        dsumview.Rows.Add(drsum);
                    }

                }
            }

            // get opnline  sales
            double summaryonlie = 0;
            DataSet summaryonlinesales = objbs.Onlinesales_distribution(date.Text, sTableName, "'1','9'");
            if (summaryonlinesales.Tables[0].Rows.Count > 0)
            {
                for (int ii = 0; ii < summaryonlinesales.Tables[0].Rows.Count; ii++)
                {
                    double ONtot = Convert.ToDouble(summaryonlinesales.Tables[0].Rows[ii]["Total"]);
                    summaryonlie += ONtot;
                }
                drsum = dsumview.NewRow();
                drsum["Name"] = "Online Sales ";
                drsum["Value"] = Convert.ToDouble(summaryonlie).ToString("0.00");
                dsumview.Rows.Add(drsum);
            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Online Sales ";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }


            // GET ALL CARD
            DataSet getsummarycardetailss = objbs.getcarddetails(sTableName, date.Text, "4");
            if (getsummarycardetailss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double cardordertot = 0;
                for (int co = 0; co < getsummarycardetailss.Tables[0].Rows.Count; co++)
                {
                    modename = getsummarycardetailss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsummarycardetailss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    cardordertot += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = "Card Sales";
                drsum["Value"] = cardordertot.ToString("0.00");
                dsumview.Rows.Add(drsum);

                drsum = dsumview.NewRow();
                drsum["Name"] = "Actual Card Amount";
                drsum["Value"] = Convert.ToDouble(lbloverallcard.Text).ToString("0.00");
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = "Difference in Card Amount  +/-";
                drsum["Value"] = (Convert.ToDouble(lbloverallcard.Text) - Convert.ToDouble(cardordertot)).ToString("0.00");
                dsumview.Rows.Add(drsum);

            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Card Sales";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }

            // GET PAYTM
            DataSet getsumcardetailsss = objbs.getcarddetails(sTableName, date.Text, "10");
            if (getsumcardetailsss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double paytmordertot = 0;
                for (int co = 0; co < getsumcardetailsss.Tables[0].Rows.Count; co++)
                {
                    modename = getsumcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsumcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    paytmordertot += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = modename;
                drsum["Value"] = paytmordertot;
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = lblbactpaytm.Text;
                drsum["Value"] = Convert.ToDouble(lbloverallpaytm.Text).ToString("0.00");
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = lblbdiffactpaytm.Text;
                drsum["Value"] = (Convert.ToDouble(lbloverallpaytm.Text) - Convert.ToDouble(paytmordertot)).ToString("0.00");
                dsumview.Rows.Add(drsum);
            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Paytm";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }

            // GET PhonePe
            DataSet getsumcardetailssss = objbs.getcarddetails(sTableName, date.Text, "17");
            if (getsumcardetailssss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double phonepeordertot = 0;
                for (int co = 0; co < getsumcardetailssss.Tables[0].Rows.Count; co++)
                {
                    modename = getsumcardetailssss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsumcardetailssss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    phonepeordertot += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = modename;
                drsum["Value"] = phonepeordertot;
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = "Actual PhonePe Amount";
                drsum["Value"] = Convert.ToDouble(lbloverallphonepe.Text).ToString("0.00");
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = "Difference in PhonePe Amount +/-";
                drsum["Value"] = (Convert.ToDouble(lbloverallphonepe.Text) - Convert.ToDouble(phonepeordertot)).ToString("0.00");
                dsumview.Rows.Add(drsum);


            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "PhonePe";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }
            //DataSet getsumcardetailsss = objbs.getcarddetails(sTableName, date.Text, "10");
            //if (getsumcardetailsss.Tables[0].Rows.Count > 0)
            //{
            //    for (int co = 0; co < getsumcardetailsss.Tables[0].Rows.Count; co++)
            //    {
            //        string modename = getsumcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
            //        string Total = Convert.ToDouble(getsumcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

            //        drsum = dsumview.NewRow();
            //        drsum["name"] = "PayTM";
            //        drsum["Value"] = Total;
            //        dsumview.Rows.Add(drsum);
            //    }

            //}
            //else
            //{
            //    drsum = dsumview.NewRow();
            //    drsum["name"] = "PayTM";
            //    drsum["Value"] = "0";
            //    dsumview.Rows.Add(drsum);
            //}

            // GET ALL EXPENSE
            DataSet getsumtotalexpense = objbs.gettotalexpense(sTableName, date.Text);
            if (getsumtotalexpense.Tables[0].Rows.Count > 0)
            {
                drsum = dsumview.NewRow();
                drsum["name"] = "Total Expense";
                drsum["Value"] = Convert.ToDouble(getsumtotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                dsumview.Rows.Add(drsum);
            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["name"] = "Total Expense";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }

            // GET CREDIT SALES
            //double totsumcreditsales = 0;

            //DataSet sumcreditsales = objbs.sales_distribution(date.Text, sTableName, "'9'");
            //if (sumcreditsales.Tables[0].Rows.Count > 0)
            //{
            //    for (int ii = 0; ii < sumcreditsales.Tables[0].Rows.Count; ii++)
            //    {
            //        double ONtot = Convert.ToDouble(sumcreditsales.Tables[0].Rows[ii]["Total"]);
            //        totsumcreditsales += ONtot;
            //        drsum = dsumview.NewRow();
            //        drsum["Name"] = "Credit Sales";
            //        drsum["Value"] = Convert.ToDouble(totsumcreditsales).ToString("0.00");
            //        dsumview.Rows.Add(drsum);
            //    }
            //}
            //else
            //{
            //    drsum = dsumview.NewRow();
            //    drsum["Name"] = "Credit Sales";
            //    drsum["Value"] = "0";
            //    dsumview.Rows.Add(drsum);
            //}

            // GET Credit Sales
            DataSet getsumcreditetailsss = objbs.getcarddetails(sTableName, date.Text, "5");
            if (getsumcreditetailsss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double totsumcreditsales = 0;
                for (int co = 0; co < getsumcreditetailsss.Tables[0].Rows.Count; co++)
                {
                    modename = getsumcreditetailsss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsumcreditetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    totsumcreditsales += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = modename;
                drsum["Value"] = totsumcreditsales;
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = "Actual Credit Amount";
                drsum["Value"] = Convert.ToDouble(lblcreditamount.Text).ToString("0.00");
                dsumview.Rows.Add(drsum);


                drsum = dsumview.NewRow();
                drsum["Name"] = "Difference in Credit Amount +/-";
                drsum["Value"] = (Convert.ToDouble(lblcreditamount.Text) - Convert.ToDouble(totsumcreditsales)).ToString("0.00");
                dsumview.Rows.Add(drsum);


            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Credit Amount";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }


            // Discount sales

            DataSet getdiscountsalesandorder = objbs.getcountersalesandorderdiscount(date.Text, sTableName);
            if (getdiscountsalesandorder.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < getdiscountsalesandorder.Tables[0].Rows.Count; i++)
                {
                    string name = getdiscountsalesandorder.Tables[0].Rows[i]["name"].ToString();
                    string money = getdiscountsalesandorder.Tables[0].Rows[i]["Total"].ToString();
                    if (money != "0.0000")
                    {

                        drsum = dsumview.NewRow();
                        drsum["Name"] = name;
                        drsum["Value"] = Convert.ToDouble(money).ToString("0.00");
                        dsumview.Rows.Add(drsum);
                    }
                }
            }



            // + OR -
            drsum = dsumview.NewRow();
            drsum["name"] = "Difference in Cash Amount +/-";
            drsum["Value"] = lbldifferencevaluecolumn1.Text;
            dsumview.Rows.Add(drsum);

            GridsummaryView.DataSource = dsumview;
            GridsummaryView.DataBind();

            #endregion

            #region Sales
            DateTime sFrom = Convert.ToDateTime(date.Text);

            DateTime sTo = Convert.ToDateTime(date.Text);

            DataSet dcustbranch = objbs.CustomerSalesBranch(DDlbranch.SelectedValue, sFrom, sTo);
            if (dcustbranch.Tables[0].Rows.Count > 0)
            {
                lblCaption.Text = "Store :  " + DDlbranch.SelectedItem.Text + " Customer Sales Report On " + Convert.ToDateTime(sFrom).ToString("dd/MM/yyyy");

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();
            }
            #endregion


            #region Sales and Order Details

            DataSet dstd = new DataSet();

            #region Sales


            DataSet FullValues = objbs.GetFullValuesForSalesinvoice(sTableName, date.Text, date.Text, lblpaymode.Text);

            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;

            dtraw.Columns.Add("Bcode");
            dtraw.Columns.Add("Date");
            dtraw.Columns.Add("grnsource");
            dtraw.Columns.Add("Category");
            dtraw.Columns.Add("Itemname");
            dtraw.Columns.Add("GST");
            dtraw.Columns.Add("Qty");
            dtraw.Columns.Add("rate");
            dtraw.Columns.Add("TotalRate");
            dtraw.Columns.Add("Margin");
            dtraw.Columns.Add("Marginvalue");
            dtraw.Columns.Add("BasicCostAfterMargin");
            dtraw.Columns.Add("GSTvalue");
            dtraw.Columns.Add("NetAmount");
            dsraw.Tables.Add(dtraw);

            if (FullValues.Tables[0].Rows.Count > 0)
            {
                DataTable dtrawss = new DataTable();

                dtrawss = FullValues.Tables[0];

                var result1 = from r in dtrawss.AsEnumerable()
                              group r by new { Bcode = r["Bcode"], Date = r["Date"], grnsource = r["grnsource"], Category = r["Category"], Itemname = r["Itemname"], GST = r["GST"], Rate = r["Rate"], margin = r["margin"] } into raw
                              select new
                              {
                                  Bcode = raw.Key.Bcode,
                                  Date = raw.Key.Date,
                                  grnsource = raw.Key.grnsource,
                                  Category = raw.Key.Category,
                                  Itemname = raw.Key.Itemname,
                                  GST = raw.Key.GST,
                                  Rate = raw.Key.Rate,
                                  margin = raw.Key.margin,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  TotalRate = raw.Sum(x => Convert.ToDouble(x["TotalRate"])),
                                  Marginvalue = raw.Sum(x => Convert.ToDouble(x["Marginvalue"])),
                                  BasicCostAfterMargin = raw.Sum(x => Convert.ToDouble(x["BasicCostAfterMargin"])),
                                  GSTvalue = raw.Sum(x => Convert.ToDouble(x["GSTvalue"])),
                                  NetAmount = raw.Sum(x => Convert.ToDouble(x["NetAmount"])),
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();


                    drraw["Bcode"] = g.Bcode;
                    drraw["Date"] = Convert.ToDateTime(g.Date).ToString("dd/MM/yyyy");
                    drraw["grnsource"] = g.grnsource;
                    drraw["Category"] = g.Category;
                    drraw["Itemname"] = g.Itemname;
                    drraw["GST"] = g.GST;
                    drraw["Qty"] = g.Qty;
                    drraw["rate"] = Convert.ToDouble(g.Rate).ToString("0.00");
                    drraw["TotalRate"] = Convert.ToDouble(g.TotalRate).ToString("0.00"); ;
                    drraw["Margin"] = g.margin;
                    drraw["Marginvalue"] = Convert.ToDouble(g.Marginvalue).ToString("0.00");
                    drraw["BasicCostAfterMargin"] = Convert.ToDouble(g.BasicCostAfterMargin).ToString("0.00");
                    drraw["GSTvalue"] = Convert.ToDouble(g.GSTvalue).ToString("0.00");
                    drraw["NetAmount"] = Convert.ToDouble(g.NetAmount).ToString("0.00");
                    dsraw.Tables[0].Rows.Add(drraw);
                }

            }
            gvSalesValue.Caption = "SALES";
            DataView view = dsraw.Tables[0].DefaultView;
            view.Sort = " Date,Category ASC";

        //    gvSalesValue.DataSource = view;
          //  gvSalesValue.DataBind();

            #endregion

            #region Order

            DataSet FullValuesorder = objbs.GetFullValuesFororderinvoice(sTableName, date.Text, date.Text);
            gvorder1.Caption = "Order Form";
            DataView view1 = FullValuesorder.Tables[0].DefaultView;
            view1.Sort = "Billdate ASC";
            gvorder1.DataSource = view1;
            gvorder1.DataBind();

            #endregion

            #endregion


            #region ORDER DELIVERY REPORT
            {
                if (date.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Select Date.Thank you!!!.');", true);
                    return;
                }


                DataTable dtord = new DataTable();
                dtord.Columns.Add("Book No");
                dtord.Columns.Add("Order No");
                dtord.Columns.Add("Order Date");
                dtord.Columns.Add("Delivery Date");
                dtord.Columns.Add("Customer Name");
                dtord.Columns.Add("Mobilno");
                dtord.Columns.Add("NetTotal");
                dtord.Columns.Add("Total");
                dtord.Columns.Add("Advance");
                dtord.Columns.Add("Item");
                dtord.Columns.Add("Dstatus");

                DateTime sDate = Convert.ToDateTime(date.Text);

                DataSet getorderinfo = objbs.GetCakerOrderINFO("tblorder_" + sTableName + "", sDate);
                if (getorderinfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
                    {

                        DataRow drord = dtord.NewRow();
                        string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
                        drord["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
                        drord["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
                        drord["Order Date"] = getorderinfo.Tables[0].Rows[i]["orderdate"].ToString();
                        drord["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MM/yyyy");
                        drord["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
                        drord["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
                        drord["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
                        drord["Total"] = Convert.ToDouble(getorderinfo.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        drord["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();
                        drord["Dstatus"] = getorderinfo.Tables[0].Rows[i]["DeliveryStatus"].ToString();


                        DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + sTableName + "", billno);
                        if (getorderitem.Tables[0].Rows.Count > 0)
                        {
                            string itemqty = string.Empty;

                            for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
                            {
                                itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
                            }
                            itemqty = itemqty.TrimEnd(',');
                            drord["Item"] = itemqty;
                        }
                        dtord.Rows.Add(drord);
                    }
                    gvorderinfo.Caption = "Cake Order Remainder Report";
                    gvorderinfo.DataSource = dtord;
                    gvorderinfo.DataBind();


                }
                gvorderinfo.Visible = true;

            }


            #endregion
            // btnSendMail_Click(sender, e);
            Search_Click(sender,e);
      //      UpdateMailStatus(date.Text,"test");

        }

        protected void lblCash_handover_amt_TextChanged(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

        }

        protected void lblOP_Cash_Amt_TextChanged(object sender, EventArgs e)
        {


        }

        protected void DDlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gridexpense_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[1].Text);

                FtotalExp += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = FtotalExp.ToString("0.00");
            }
        }

        protected void gvnormalsales_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[1].Text);

                FtotalSale += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = FtotalSale.ToString("0.00");
            }
        }

        protected void gvOrder_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[1].Text);

                FtotalOrder += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = FtotalOrder.ToString("0.00");
            }
        }

        protected void gvcancelorder_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[1].Text);

                FtotalCancelOrder += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = FtotalCancelOrder.ToString("0.00");
            }
        }

        protected void gvonlinesales_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[2].Text);

                FtotalOnlineSales += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[2].Text = FtotalOnlineSales.ToString("0.00");
            }
        }

        protected void gvcredit_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[1].Text);

                FtotCreditsales += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = FtotCreditsales.ToString("0.00");
            }
        }
        protected void gridsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string name = (e.Row.Cells[0].Text);

                if (name == "Difference in Card Amount  +/-")
                {
                    double amount = Convert.ToDouble(e.Row.Cells[1].Text);
                    bool negative = amount < 0;
                    if (negative == true)
                    {
                        e.Row.Cells[0].BackColor = Color.Red;
                        e.Row.Cells[1].BackColor = Color.Red;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }
                    else
                    {
                        e.Row.Cells[0].BackColor = Color.Green;
                        e.Row.Cells[1].BackColor = Color.Green;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }

                }
                else if (name == lblbdiffactpaytm.Text)
                {
                    double amount = Convert.ToDouble(e.Row.Cells[1].Text);
                    bool negative = amount < 0;
                    if (negative == true)
                    {
                        e.Row.Cells[0].BackColor = Color.Red;
                        e.Row.Cells[1].BackColor = Color.Red;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }
                    else
                    {
                        e.Row.Cells[0].BackColor = Color.Green;
                        e.Row.Cells[1].BackColor = Color.Green;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }

                }
                else if (name == "Difference in PhonePe Amount +/-")
                {
                    double amount = Convert.ToDouble(e.Row.Cells[1].Text);
                    bool negative = amount < 0;
                    if (negative == true)
                    {
                        e.Row.Cells[0].BackColor = Color.Red;
                        e.Row.Cells[1].BackColor = Color.Red;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }
                    else
                    {
                        e.Row.Cells[0].BackColor = Color.Green;
                        e.Row.Cells[1].BackColor = Color.Green;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }

                }

                else if (name == "Difference in Cash Amount +/-")
                {
                    double amount = Convert.ToDouble(e.Row.Cells[1].Text);
                    bool negative = amount < 0;
                    if (negative == true)
                    {
                        e.Row.Cells[0].BackColor = Color.Red;
                        e.Row.Cells[1].BackColor = Color.Red;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }
                    else
                    {
                        e.Row.Cells[0].BackColor = Color.Green;
                        e.Row.Cells[1].BackColor = Color.Green;
                        e.Row.Cells[1].ForeColor = Color.White;
                        e.Row.Cells[1].Font.Size = 20;
                    }

                }

            }

        }

        protected void gvsalesreturn_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double amount = Convert.ToDouble(e.Row.Cells[1].Text);

                FtotalReturn += amount;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = FtotalReturn.ToString("0.00");
            }
        }


        protected void btnMail_Click(object sender, EventArgs e)
        {
            ////string emailsubject = "Daily_ViewReport";
            ////string toAddress = "senthilkumar@bigdbiz.com";

            //////string emailcontent = string.Empty;


            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Cash Flow Table    " + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Cash HandOver      " + lblCash_handover_amt.Text + "\n";
            //////emailcontent = emailcontent + " Closing Cash       " + lblCash_Closing_Amt.Text + "\n";
            //////emailcontent = emailcontent + " Total Expenses     " + lblTotal_Exp_Amt.Text + "\n";
            //////emailcontent = emailcontent + " Credit Sales       " + lblCredit_Sales_Amt.Text + "\n";
            //////emailcontent = emailcontent + " Gross Total        " + lblSales_Gross_amt.Text + "\n";
            //////emailcontent = emailcontent + " OP Cash            " + lblOP_Cash_Amt.Text + "\n";
            //////emailcontent = emailcontent + " Net Sales          " + lblNet_Sales_Amt.Text + "\n";
            //////emailcontent = emailcontent + " +/-                " + lblSales_Result_amt.Text + "\n";


            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Sales Flow Table   " + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Cash Sales         " + lblCash_sales_Amt.Text + "\n";
            //////emailcontent = emailcontent + " Credit Sales       " + lblCredit_sales_amt1.Text + "\n";
            //////emailcontent = emailcontent + " Order Form Sales   " + lblOrder_sales_amt.Text + "\n";
            //////emailcontent = emailcontent + " Total Sales        " + lbl_Total_Sales_Amt.Text + "\n";
            //////emailcontent = emailcontent + " Card Sales         " + lblCard_sales_amt.Text + "\n";
            //////emailcontent = emailcontent + " Sales Deductions   " + lblSales_deductions_amt.Text + "\n";
            //////emailcontent = emailcontent + " Gross Sales        " + lblGross_sales_amt.Text + "\n";


            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Denomination Table " + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " 1000               " + lbl1000_no.Text + "        " + lbl1000s.Text +"\n";
            //////emailcontent = emailcontent + " 500                " + lbl500s_no.Text  + "        " + lbl500s.Text +"\n";
            //////emailcontent = emailcontent + " 100                " + lbl100s_no.Text + "        " + lbl100s.Text +"\n";
            //////emailcontent = emailcontent + " 50                 " + lbl50s_no.Text + "        " + lbl50s.Text +"\n";
            //////emailcontent = emailcontent + " 20                 " + lbl20s_no.Text + "        " + lbl20s.Text +"\n";
            //////emailcontent = emailcontent + " 10                 " + lbl10s_no.Text + "        " + lbl10s.Text +"\n";
            //////emailcontent = emailcontent + " 5                  " + lbl5s_no.Text  + "        " + lbl5s.Text +"\n";
            //////emailcontent = emailcontent + " 2                  " + lbl2s_no.Text + "        " + lbl2s.Text +"\n";
            //////emailcontent = emailcontent + " 1                  " + lbl1s_no.Text + "        " + lbl1s.Text +"\n";
            //////emailcontent = emailcontent + " Coins              " + lblcoinss_no.Text + "        " + lblcoinss.Text +"\n";
            //////emailcontent = emailcontent + " Total              " + "        " + lblTotal_Denominations.Text + "\n";


            //////if (DDlbranch.SelectedValue == "1")
            //////{
            //////    sTableName = "CO1";
            ////// }
            //////else if (DDlbranch.SelectedValue == "2")
            //////{
            //////    sTableName = "CO2";
            //////}
            //////else if (DDlbranch.SelectedValue == "3")
            //////{
            //////    sTableName = "CO3";
            //////}
            //////else
            //////{
            //////    sTableName = "CO4";
            //////}
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Expenses Table     " + "\n";
            //////emailcontent = emailcontent + "\n";

            ////////string dt = DateTime.Today.ToString("yyyy-dd-MM");
            ////////date.Text = dt;
            //////DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            //////int count = ds.Tables[0].Rows.Count;
            //////if (ds.Tables[0].Rows.Count > 0)
            //////{
            //////    for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
            //////    {
            //////        emailcontent = emailcontent + ds.Tables[0].Rows[a]["LedgerName"].ToString() + "  " + Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString()) +"\n";
            //////    }
            //////}

            //////emailcontent = emailcontent + " Total                            " + lblTotal_Exp_Amt1.Text + "\n";

            ////////</th>
            ////////                          </tr>
            ////////                          <tr><td style="background-color:#81d8d0" ><asp:Panel ID="pnlTextBoxes"
            ////////                                  runat="server" Width="186px"></asp:Panel></td>
            ////////                          <td  style="background-color:#81d8d0"><asp:Panel ID="pnlTextBoxes1" Width="186px"  runat="server"></asp:Panel></td>
            ////////                          </tr>
            ////////                           <tr>
            ////////                        <td style="background-color:#fa8072"> <asp:Label ID="lblTotal_Exp1" runat="server">Total</asp:Label></td>

            ////////                        <td style="background-color:#fa8072"><asp:Label ID="lblTotal_Exp_Amt1" runat="server">0.00</asp:Label></td>
            ////////                       </tr>

            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Sales Deduction Table " + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " Date Bar              " + lblDate_Bar_amt.Text  + "\n";
            //////emailcontent = emailcontent + " Missing               " + lblMissing_amt.Text  + "\n";
            //////emailcontent = emailcontent + " Compliment            " + lblCompliment_salesdeduction_amt.Text  + "\n";
            //////emailcontent = emailcontent + " Wastage               " + lblWastage_amt.Text  + "\n";
            //////emailcontent = emailcontent + " NP to Byepass         " + lblNP_Byepass_amt.Text + "\n";
            //////emailcontent = emailcontent + " Damage                " + lblDamage_amt.Text  + "\n";
            //////emailcontent = emailcontent + " Product Change        " + lblProduct_change_amt.Text  + "\n";
            //////emailcontent = emailcontent + " BNP to Byepass        " + lblBNP_Byepass_amt.Text + "\n";
            //////emailcontent = emailcontent + " NP to BB KULAM        " + bbkulamamount.Text  + "\n";
            //////emailcontent = emailcontent + " Total                 " + lblSales_Deduction_amt1.Text + "\n";



            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + "\n";
            //////emailcontent = emailcontent + " MSG Table " + "\n";
            //////emailcontent = emailcontent + "\n";




            //////string smtphostname = ConfigurationManager.AppSettings["SmtpHostName"].ToString();
            //////int smtpport = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            //////var fromAddress = ConfigurationManager.AppSettings["FromAddress"].ToString();

            //////string fromPassword = ConfigurationManager.AppSettings["FromPassword"].ToString();

            //////var smtp = new System.Net.Mail.SmtpClient();
            //////{
            //////    smtp.Host = smtphostname;
            //////    smtp.Port = smtpport;
            //////    //smtp.UseDefaultCredentials = false;
            //////    smtp.EnableSsl = true;
            //////    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //////    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //////    smtp.Timeout = 20000;
            //////}

            //////smtp.Send(fromAddress, toAddress, emailsubject, emailcontent);

            SendEmail(sender, e);

            //int update = objbs.updateopcash(Convert.ToInt32(lblUserID.Text), Convert.ToDecimal(lblCash_Closing_Amt.Text));


        }

        private string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/HTMLPage1.htm")))
            {
                body = reader.ReadToEnd();
            }
            //body = body.Replace("{lblCash_handover_amt}", lblCash_handover_amt.Text);
            //body = body.Replace("{lblCash_Closing_Amt}", lblCash_Closing_Amt.Text);
            //body = body.Replace("{lblTotal_Exp_Amt}", lblTotal_Exp_Amt.Text);
            //body = body.Replace("{lblCredit_Sales_Amt}", lblCredit_Sales_Amt.Text);
            //body = body.Replace("{lblSales_Gross_amt}", lblSales_Gross_amt.Text);
            //body = body.Replace("{lblOP_Cash_Amt}", lblOP_Cash_Amt.Text);
            //body = body.Replace("{lblNet_Sales_Amt}", lblNet_Sales_Amt.Text);
            //body = body.Replace("{lblSales_Result_amt}", lblSales_Result_amt.Text);
            //body = body.Replace("{lblCreditcard_Sales}", lblCreditcard_Sales.Text);

            //body = body.Replace("{lblCash_sales_Amt}", lblCash_sales_Amt.Text);

            //body = body.Replace("{lblOrder_sales_amt}", lblOrder_sales_amt.Text);
            //body = body.Replace("{lbl_Total_Sales_Amt}", lbl_Total_Sales_Amt.Text);
            //body = body.Replace("{lblExcess}", lblExcess.Text);

            //body = body.Replace("{lblSales_deductions_amt}", lblSales_deductions_amt.Text);
            ////  body = body.Replace("{lblGross_sales_amt}", lblGross_sales_amt.Text);
            //body = body.Replace("{lblErr}", lblErr.Text);

            //body = body.Replace("{lbl1000_no}", lbl1000_no.Text);
            //body = body.Replace("{lbl1000s}", lbl1000s.Text);
            //body = body.Replace("{lbl500s_no}", lbl500s_no.Text);
            //body = body.Replace("{lbl500s}", lbl500s.Text);
            //body = body.Replace("{lbl100s_no}", lbl100s_no.Text);
            //body = body.Replace("{lbl100s}", lbl100s.Text);
            //body = body.Replace("{lbl50s_no}", lbl50s_no.Text);
            //body = body.Replace("{lbl50s}", lbl50s.Text);
            //body = body.Replace("{lbl20s_no}", lbl20s_no.Text);
            //body = body.Replace("{lbl20s}", lbl20s.Text);
            //body = body.Replace("{lbl10s_no}", lbl10s_no.Text);
            //body = body.Replace("{lbl10s}", lbl10s.Text);
            //body = body.Replace("{lbl5s_no}", lbl5s_no.Text);
            //body = body.Replace("{lbl5s}", lbl5s.Text);
            //body = body.Replace("{lbl2s_no}", lbl2s_no.Text);
            //body = body.Replace("{lbl2s}", lbl2s.Text);
            //body = body.Replace("{lbl1s_no}", lbl1s_no.Text);
            //body = body.Replace("{lbl1s}", lbl1s.Text);
            //body = body.Replace("{lblcoinss_no}", lblcoinss_no.Text);
            //body = body.Replace("{lblcoinss}", lblcoinss.Text);
            //body = body.Replace("{lblTotal_Denominations}", lblTotal_Denominations.Text);



            string content = string.Empty;

            DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    content = content + "<tr><td> " + ds.Tables[0].Rows[a]["LedgerName"].ToString() + "</td><td>" + Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString()) + "</td></tr>";
                }
            }

            body = body.Replace("{lblTotal_Exp}", content);
            //  body = body.Replace("{lblTotal_Exp_Amt1}", lblTotal_Exp_Amt1.Text);


            //body = body.Replace("{lblDate_Bar_amt}", lblDate_Bar_amt.Text);
            //body = body.Replace("{lblMissing_amt}", lblMissing_amt.Text);
            //body = body.Replace("{lblCompliment_salesdeduction_amt}", lblCompliment_salesdeduction_amt.Text);
            //body = body.Replace("{lblWastage_amt}", lblWastage_amt.Text);
            ////body = body.Replace("{lblNP_Byepass_amt}", lblNP_Byepass_amt.Text);
            //body = body.Replace("{lblDamage_amt}", lblDamage_amt.Text);
            //body = body.Replace("{lblExcess}", lblExcess.Text);
            //body = body.Replace("{lblProduct_change_amt}", lblProduct_change_amt.Text);
            ////body = body.Replace("{lblBNP_Byepass_amt}", lblBNP_Byepass_amt.Text);
            //body = body.Replace("{bbkulamamount}", bbkulamamount.Text);
            //body = body.Replace("{lblSales_Deduction_amt1}", lblSales_Deduction_amt1.Text);




            return body;
        }

        private string Expenses(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            //using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/Expenses.htm")))
            //{
            //    body = reader.ReadToEnd();
            //}
            //string content = string.Empty;

            //DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            //int count = ds.Tables[0].Rows.Count;
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
            //    {
            //        content = content + "<tr><td> " + ds.Tables[0].Rows[a]["LedgerName"].ToString() + "</td><td>" + Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"]).ToString("f2") + "</td></tr>";
            //    }
            //}

            //body = body.Replace("{lblTotal_Exp}", content);
            //body = body.Replace("{lblTotal_Exp_Amt1}", lblTotal_Exp_Amt1.Text);







            return body;
        }


        private string BreadList(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/breadlist.htm")))
            {
                body = reader.ReadToEnd();
            }




            //string content = string.Empty;

            //DataSet ds = objbs.BreadList(branchcode);
            //int count = ds.Tables[0].Rows.Count;
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
            //    {
            //        content = content + "<tr><td> " + ds.Tables[0].Rows[a]["Category"].ToString() + "</td><td> " + ds.Tables[0].Rows[a]["Definition"].ToString() + "</td><td> " + ds.Tables[0].Rows[a]["Order_Qty"].ToString() + "</td></tr>";
            //    }
            //}

            //body = body.Replace("{lblTotal_Exp}", content);








            return body;
        }


        protected void SendEmail(object sender, EventArgs e)
        {
            string body = this.PopulateBody(" ",
        "  ",
        "",
        " ");

            string Exp = this.Expenses(" ",
        "  ",
        "",
        " ");


            string Bread = this.BreadList(" ",
       "  ",
       "",
       " ");


            //   if (branchcode != "NE")
            //   {
            this.SendHtmlFormattedEmail("nknavaneethan4u@gmail.com ", "nknavaneethan4u@gmail.com ", "Daily Report (" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", body, "bfkknagr@gmail.com", "bfnpuram@gmail.com", "bfbypass@gmail.com", "bfbbkulam@gmail.com", "bfpalayankottai@gmail.com");




            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);
        }


        private void SendHtmlFormattedEmail(string recepientEmail, string cc, string subject, string body, string a, string b, string c, string d, string e)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));

                //mailMessage.CC.Add(new MailAddress(cc));
                //mailMessage.CC.Add(new MailAddress(a));
                //mailMessage.CC.Add(new MailAddress(b));
                //mailMessage.CC.Add(new MailAddress(c));
                //mailMessage.CC.Add(new MailAddress(d));
                //mailMessage.CC.Add(new MailAddress(e));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
                NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
                smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
                smtp.Send(mailMessage);
            }
        }

        private void SendBreadList(string recepientEmail, string cc, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.CC.Add(new MailAddress(cc));
                mailMessage.To.Add(new MailAddress(recepientEmail));
                //mailMessage.CC.Add(new MailAddress(a));
                //mailMessage.CC.Add(new MailAddress(b));
                //mailMessage.CC.Add(new MailAddress(c));
                //mailMessage.CC.Add(new MailAddress(d));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
                NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
                smtp.UseDefaultCredentials =  Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
                smtp.Send(mailMessage);
            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            Header.Visible = false;
        }

        protected void linkprint_Click(object sender, EventArgs e)
        {
            datetime.InnerText = DateTime.Now.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Denomination();", true);
        }

        protected void btnsession_Click(object sender, EventArgs e)
        {


            string time = DateTime.Now.ToString();

            DateTime dat = DateTime.Parse(time);
            var hour = dat.ToString("HH");
            var min = dat.ToString("mm");
            var current = hour + "." + min;

            //if (double.Parse(current) >= 22.00)
            //{
            if (txtnam.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "shw();", true);
            }


            if (date.Text != DateTime.Today.ToString("yyyy-MM-dd"))
            {


                objbs.dayclosername_Previousday(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                DataSet ch = objbs.checkinser_Previousday(sTableName);
                if (ch.Tables[0].Rows.Count > 0)
                {
                    objbs.delOpening_Previousday(sTableName);
                    int transfer = objbs.insertselect_Previousday(sTableName);
                }
                else
                {
                    int transfer = objbs.insertselect_Previousday(sTableName);
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);

                Response.Redirect("../Accountsbootstrap/newbutton.aspx");
            }

            else
            {

                objbs.dayclosername(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                DataSet ch = objbs.checkinser(sTableName);
                if (ch.Tables[0].Rows.Count > 0)
                {
                    objbs.delOpening(sTableName);
                    int transfer = objbs.insertselect(sTableName);
                }
                else
                {
                    int transfer = objbs.insertselect(sTableName);
                }
                // int closr = objbs.updatedayclose(Convert.ToInt32(lblUserID.Text), DateTime.Now.ToShortDateString());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);

            }
            // }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('sorry its not a valid Time')", true);
            //}



        }



        protected void btnclost_Click1(object sender, EventArgs e)
        {

        }

        protected void date_TextChanged(object sender, EventArgs e)
        {
            //if (sTableName != "admin")
            //{
            //    DateTime dat = Convert.ToDateTime(date.Text);
            //    DateTime Toady = DateTime.Now.Date; ;

            //    var days = dat.Day;
            //    var toda = Toady.Day;

            //    if ((toda - days) <= 2)
            //    {

            //    }

            //    else
            //    {
            //        date.Text = "";
            //    }
            //}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Send Mail.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion

            if (chkdatetime.Checked == false)
            {
                int hours = Convert.ToInt32(chkhour.Text);
                int minu = Convert.ToInt32(chkminu.Text);

                TimeSpan start = new TimeSpan(hours, minu, 0); //10 o'clock
                TimeSpan now = DateTime.Now.TimeOfDay;

                if ((now < start))
                {
                    //match found
                    date.Text = "";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To close.Please Close After 09.30 PM.Thank You!!!');", true);
                    return;
                }
                else
                {

                }

            }

            if (chkdatetime.Checked == false)
            {

                DateTime dat1 = Convert.ToDateTime(date.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var days = dat1.Day;
                var toda = Toady.Day;

                if ((toda - days) == 0)
                {

                }

                else
                {
                    date.Text = "";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To close.Thank You!!!');", true);
                    return;
                }
            }

            // DataSet ch = objbs.SessionClose(sTableName, DateTime.Now.ToString("yyyy-MM-dd"), txtName.Text);

            //Response.Redirect("Login_Branch.aspx");

            if (txtopcash.Text == "" || txtopcash.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Opening Cash.Thank You!!!');", true);
                return;
            }


            string time = DateTime.Now.ToString();

            DateTime dat = DateTime.Parse(time);
            var hour = dat.ToString("HH");
            var min = dat.ToString("mm");
            var current = hour + "." + min;

            //if (double.Parse(current) >= 22.00)
            //{
            if (txtnam.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "shw();", true);
            }
            if (chkdatetime.Checked == false)
            {
                DataSet checkdayclose = objbs.checkdayclose(sTableName, date.Text);
                if (checkdayclose.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Not Allow To close YesterDay Session.Thank You!!!');", true);
                    return;
                }
                else
                {

                }
            }
            if (chkdatetime.Checked == true)
            {
                DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
                if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Uncheck Daily View Report Checkbox.Thank You!!!');", true);
                    chkdatetime.Focus();
                    return;
                }
                else
                {
                    btnSendMail_Click(sender, e);
                    if (BankGrid.Rows.Count > 0)
                    {
                        SendHTMLMail1();
                    }
                   // SendMailforTodayOrderandSales();

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);

                    Response.Redirect("../Accountsbootstrap/login1.aspx");
                }


            }
            if (chkdatetime.Checked == false)
            {

                if (date.Text != DateTime.Today.ToString("yyyy-MM-dd"))
                {


                    objbs.dayclosername_Previousday(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                    DataSet ch = objbs.checkinser_Previousday(sTableName);
                    if (ch.Tables[0].Rows.Count > 0)
                    {
                        objbs.delOpening_Previousday(sTableName);
                        int transfer = objbs.insertselect_Previousday(sTableName);
                    }
                    else
                    {
                        int transfer = objbs.insertselect_Previousday(sTableName);
                    }
                    btnSendMail_Click(sender, e);
                    if (BankGrid.Rows.Count > 0)
                    {
                        SendHTMLMail1();
                    }
                   // SendMailforTodayOrderandSales();

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);

                    Response.Redirect("../Accountsbootstrap/login1.aspx");
                }
                else
                {

                    objbs.dayclosername(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                    DataSet ch = objbs.checkinser(sTableName);
                    if (ch.Tables[0].Rows.Count > 0)
                    {
                        objbs.delOpening(sTableName);
                        int transfer = objbs.insertselect(sTableName);
                    }
                    else
                    {
                        int transfer = objbs.insertselect(sTableName);
                    }

                    int dayclose = objbs.insertdayclosing(sTableName, date.Text, txtopcash.Text, txtName.Text, lbldifferencevaluecolumn1.Text);

                    int closr = objbs.updatedayclose(Convert.ToInt32(lblUserID.Text), DateTime.Now.ToString("yyyy-MM-dd"));

                    btnSendMail_Click(sender, e);
                    if (BankGrid.Rows.Count > 0)
                    {
                        SendHTMLMail1();
                    }
                    SendMailforTodayOrderandSales();

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);
                    Response.Redirect("../Accountsbootstrap/login1.aspx");

                }
            }
        }



        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string name = string.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double Tax = 0;
                double NetAmount = 0;

                Tax = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GTax = GTax + Tax;
                GNetAmount = GNetAmount + NetAmount;

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                decimal dtotal = 0;
                decimal ddiscamnt = 0;
                decimal dtotalamt = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
                    dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                decimal dtotalamntt = ddiscamnt;
                disc.InnerText = dtotalamntt.ToString();
                decimal gndtot = dtotalamt;

                gndtotal.InnerText = ((Convert.ToDouble(gndtot)) - Convert.ToDouble(dtotalamntt)).ToString("f2");

                double finaltot = 0;
                double roundoff1 = Convert.ToDouble(gndtotal.InnerText) - Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                if (roundoff1 >= 0.5)
                {
                    finaltot = Math.Round(Convert.ToDouble(gndtotal.InnerText), MidpointRounding.AwayFromZero);
                }
                else
                {
                    finaltot = Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                }

                gndtotal.InnerText = string.Format("{0:N2}", finaltot);
            }

        }


        protected void btnSendMailReport_Click(object sender, EventArgs e)
        {
            SendHTMLMailSales();
        }
        public void SendHTMLMailSales()
        {
            MailMessage Msg = new MailMessage();
            // MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
            MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress("rajar@bigdbiz.in"));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            // Subject of e-mail
            Msg.Subject = "Send Gridivew in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += GetGridviewDatasales(gvCustsales);
            Msg.Body += "Please check below data <br/><br/>";
            Msg.IsBodyHtml = true;
            //////string sSmtpServer = "";
            //////sSmtpServer = "587";
            //////SmtpClient a = new SmtpClient();
            //////a.Host = sSmtpServer;
            //////a.EnableSsl = true;
            //////a.Send(Msg);


            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }
        // This Method is used to render gridview control
        public string GetGridviewDatasales(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }


        protected void gvSalesValue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double Qty = 0;
            double rate = 0;
            double totalrate = 0;
            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                rate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "rate"));
                totalrate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalRate"));



                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Marginvalue"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BasicCostAfterMargin"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTvalue"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GQty = GQty + Qty;
                GRate = GRate + rate;
                GTrate = GTrate + totalrate;
                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;
                GGSTAmt = GGSTAmt + GSTAmt;
                GNetAmounts = GNetAmounts + NetAmount;


                double GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                if (GST == 0)
                {
                    SalesExempted += NetAmount;
                }
                else
                {
                    TaxableSales += NetAmount;
                }

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {


                e.Row.Cells[5].Text = "Total";

                e.Row.Cells[6].Text = GQty.ToString("f2");
                e.Row.Cells[7].Text = GRate.ToString("f2");
                e.Row.Cells[8].Text = GTrate.ToString("f2");



                e.Row.Cells[10].Text = GMargin.ToString("f2");
                e.Row.Cells[11].Text = GBasicValue.ToString("f2");

                e.Row.Cells[12].Text = GGSTAmt.ToString("f2");
                e.Row.Cells[13].Text = GNetAmounts.ToString("f2");

                // e.Row.Cells[14].Text = GNetAmount.ToString("f2");


                lblsalesexempted.Text = SalesExempted.ToString("f2");
                lbltaxablesales.Text = TaxableSales.ToString("f2");
                lblcgst.Text = GGSTAmt.ToString("f2");
                //lblsgst.Text = GGSTAmt.ToString("f2");
                lblnetamount.Text = (GNetAmounts + GGSTAmt).ToString("f2");





                double n = 0;

                double roundoff = Convert.ToDouble(lblnetamount.Text) - Math.Floor(Convert.ToDouble(lblnetamount.Text));
                if (roundoff >= 0.5)
                {
                    n = Math.Round(Convert.ToDouble(lblnetamount.Text), MidpointRounding.AwayFromZero);

                }
                else
                {
                    n = Math.Floor(Convert.ToDouble(lblnetamount.Text));

                }

                lblfinalamount.Text = string.Format("{0:N2}", n);

                double rndoff = Convert.ToDouble(lblfinalamount.Text) - Convert.ToDouble(lblnetamount.Text);

                lblroundoff.Text = string.Format("{0:N2}", Convert.ToDouble(rndoff));


            }
        }
        protected void gvorder_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;


            double COST = 0;
            double GST = 0;
            double Amount = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {


                COST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "COST"));
                GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                Amount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));

                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Margin"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "castbeforemargin"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTV"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetamountV"));

                GOCOSTo = GOCOSTo + COST;
                GOGSTo = GOGST + GST;
                GOAmounto = GOAmounto + Amount;

                GoMargin = GoMargin + Margin;
                GoBasicValue = GoBasicValue + BasicValue;
                GoGSTAmt = GoGSTAmt + GSTAmt;
                GoNetAmount = GoNetAmount + NetAmount;


                //double GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                //if (GST == 0)
                //{
                //    SalesExempted += NetAmount;
                //}
                //else
                //{
                TaxableSales += NetAmount;
                //}

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {


                e.Row.Cells[6].Text = "Total";
                e.Row.Cells[7].Text = GOCOSTo.ToString("f2");
                e.Row.Cells[8].Text = GOGSTo.ToString("f2");
                e.Row.Cells[10].Text = GOAmounto.ToString("f2");


                e.Row.Cells[12].Text = GoMargin.ToString("f2");
                e.Row.Cells[13].Text = GoBasicValue.ToString("f2");

                e.Row.Cells[14].Text = GoGSTAmt.ToString("f2");
                e.Row.Cells[15].Text = GoNetAmount.ToString("f2");

                // e.Row.Cells[14].Text = GNetAmount.ToString("f2");


                //lblsalesexempted.Text = SalesExempted.ToString("f2");
                lbltaxablesalesorder.Text = TaxableSales.ToString("f2");
                lblcgstorder.Text = GoGSTAmt.ToString("f2");
                //lblsgst.Text = GGSTAmt.ToString("f2");
                lblnetamountorder.Text = (GoNetAmount).ToString("f2");





                double n = 0;

                double roundoff = Convert.ToDouble(lblnetamountorder.Text) - Math.Floor(Convert.ToDouble(lblnetamountorder.Text));
                if (roundoff >= 0.5)
                {
                    n = Math.Round(Convert.ToDouble(lblnetamountorder.Text), MidpointRounding.AwayFromZero);

                }
                else
                {
                    n = Math.Floor(Convert.ToDouble(lblnetamountorder.Text));

                }

                lblfinalamountorder.Text = string.Format("{0:N2}", n);

                double rndoff = Convert.ToDouble(lblfinalamountorder.Text) - Convert.ToDouble(lblnetamountorder.Text);

                lblroundofforder.Text = string.Format("{0:N2}", Convert.ToDouble(rndoff));


            }
        }


        public void SendMailforTodayOrderandSales()
        {

            MailMessage Msg = new MailMessage();
            //MailAddress fromMail = new MailAddress("jothikumar@bigdbiz.in");
            //// Sender e-mail address.
            //Msg.From = fromMail;
            Msg.From = new MailAddress("jothics0792@gmail.com", "Blaack Forest - Sales And Order Invoice Report For " + sTableName + "");

            // Subject of e-mail
            Msg.Subject = "Sales and Order Details For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "<br/> Sales Flow Details <br/>";
            Msg.Body += GetsalesData(gvSalesValue);
            Msg.Body += "<br/> Sales Exempted :" + lblsalesexempted.Text + " <br/>";
            Msg.Body += "<br/> Taxable Sales :" + lbltaxablesales.Text + " <br/>";
            Msg.Body += "<br/> GST :" + lblcgst.Text + " <br/>";
            Msg.Body += "<br/> NET AMOUNT :" + lblnetamount.Text + " <br/>";
            Msg.Body += "<br/> Round Off :" + lblroundoff.Text + " <br/>";
            Msg.Body += "<br/> FINAL AMOUNT :" + lblfinalamount.Text + " <br/>";

            Msg.Body += "<br/><br/>";

            Msg.Body += "<br/> Order Flow Details <br/>";
            Msg.Body += GetOrdersData(gvorder1);
            Msg.Body += "<br/> Taxable Sales :" + lbltaxablesalesorder.Text + " <br/>";
            Msg.Body += "<br/> GST :" + lblcgstorder.Text + " <br/>";
            Msg.Body += "<br/> NET AMOUNT :" + lblnetamountorder.Text + " <br/>";
            Msg.Body += "<br/> Round Off :" + lblroundofforder.Text + " <br/>";
            Msg.Body += "<br/> FINAL AMOUNT :" + lblfinalamountorder.Text + " <br/>";


            Msg.IsBodyHtml = true;

            string mutltiemail = lblinvmail.Text;

            string[] Multi = mutltiemail.Split(',');
            foreach (string Multiemailid in Multi)
            {
                Msg.To.Add(new MailAddress(Multiemailid));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);

            UpdateMailStatus(date.Text, txtName.Text);

        }
        public void UpdateMailStatus(string dt,string emp)
        {
            objbs.updatemailstatus(dt, emp);
        }
        public string GetsalesData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gvSalesValue.RenderControl(htw);
            return strBuilder.ToString();
        }
        public string GetOrdersData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gvorder1.RenderControl(htw);
            return strBuilder.ToString();
        }




        protected void Search_Click(object sender, EventArgs e)
        {
            //if (txtfrmdate.Text == "--Select Date--" || txtfrmdate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Date!!!.');", true);
            //    return;
            //}
            //Label123 = Place;
            DataSet dstd = new DataSet();


            if ("1" == "1")
            {
              //  div1.Visible = true;
                //div4.Visible = false;
                DataSet FullValues = objbs.GetFullValuesForSalesinvoice(DDlbranch.SelectedValue, date.Text, date.Text, lblpaymode.Text);
                //gvSalesValue.Caption = "SALES";
                //DataView view = FullValues.Tables[0].DefaultView;
                //view.Sort = " Date,Category ASC";

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Bcode");
                dtraw.Columns.Add("Date");
                dtraw.Columns.Add("grnsource");
                dtraw.Columns.Add("Category");
                dtraw.Columns.Add("Itemname");
                dtraw.Columns.Add("GST");
                dtraw.Columns.Add("Qty");
                dtraw.Columns.Add("rate");
                dtraw.Columns.Add("TotalRate");
                dtraw.Columns.Add("Margin");
                dtraw.Columns.Add("Marginvalue");
                dtraw.Columns.Add("BasicCostAfterMargin");
                dtraw.Columns.Add("GSTvalue");
                dtraw.Columns.Add("NetAmount");
                dsraw.Tables.Add(dtraw);

                if (FullValues.Tables[0].Rows.Count > 0)
                {
                    DataTable dtrawss = new DataTable();

                    dtrawss = FullValues.Tables[0];

                    var result1 = from r in dtrawss.AsEnumerable()
                                  group r by new { Bcode = r["Bcode"], Date = r["Date"], grnsource = r["grnsource"], Category = r["Category"], Itemname = r["Itemname"], GST = r["GST"], Rate = r["Rate"], margin = r["margin"] } into raw
                                  select new
                                  {
                                      Bcode = raw.Key.Bcode,
                                      Date = raw.Key.Date,
                                      grnsource = raw.Key.grnsource,
                                      Category = raw.Key.Category,
                                      Itemname = raw.Key.Itemname,
                                      GST = raw.Key.GST,
                                      Rate = raw.Key.Rate,
                                      margin = raw.Key.margin,
                                      Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                      TotalRate = raw.Sum(x => Convert.ToDouble(x["TotalRate"])),
                                      Marginvalue = raw.Sum(x => Convert.ToDouble(x["Marginvalue"])),
                                      BasicCostAfterMargin = raw.Sum(x => Convert.ToDouble(x["BasicCostAfterMargin"])),
                                      GSTvalue = raw.Sum(x => Convert.ToDouble(x["GSTvalue"])),
                                      NetAmount = raw.Sum(x => Convert.ToDouble(x["NetAmount"])),
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();


                        drraw["Bcode"] = g.Bcode;
                        //
                        drraw["Date"] = Convert.ToDateTime(g.Date).ToString("dd/MMM/yyyy");
                        drraw["grnsource"] = g.grnsource;
                        drraw["Category"] = g.Category;
                        drraw["Itemname"] = g.Itemname;
                        drraw["GST"] = g.GST;
                        drraw["Qty"] = g.Qty;
                        drraw["rate"] = Convert.ToDouble(g.Rate).ToString("0.00");
                        drraw["TotalRate"] = Convert.ToDouble(g.TotalRate).ToString("0.00"); ;
                        drraw["Margin"] = g.margin;
                        drraw["Marginvalue"] = Convert.ToDouble(g.Marginvalue).ToString("0.00");
                        drraw["BasicCostAfterMargin"] = Convert.ToDouble(g.BasicCostAfterMargin).ToString("0.00");
                        drraw["GSTvalue"] = Convert.ToDouble(g.GSTvalue).ToString("0.00");
                        drraw["NetAmount"] = Convert.ToDouble(g.NetAmount).ToString("0.00");
                        dsraw.Tables[0].Rows.Add(drraw);
                    }

                }
                gvSalesValue.Caption = "SALES";
                DataView view = dsraw.Tables[0].DefaultView;
                view.Sort = " Date,Category ASC";

                gvSalesValue.DataSource = view;
                gvSalesValue.DataBind();
            }
            if("2"=="2")
            {
                //div1.Visible = false;
                //div4.Visible = true;
                DataSet FullValuesorder = objbs.GetFullValuesFororderinvoice(DDlbranch.SelectedValue, date.Text, date.Text);
                gvorder_rpt.Caption = "Order Form";
                DataView view = FullValuesorder.Tables[0].DefaultView;
                view.Sort = "Billdate ASC";
                gvorder_rpt.DataSource = view;
                gvorder_rpt.DataBind();

            }


        }


    }
}