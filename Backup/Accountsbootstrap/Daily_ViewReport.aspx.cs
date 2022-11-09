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

namespace Billing.Accountsbootstrap
{
    public partial class Daily_ViewReport : System.Web.UI.Page
    {
        decimal total, tmp = 0,cash=0,credit=0,card=0,compli=0,sales,gross,cash_handover=0,Closing_cash=0,net_sales=0,tot_grosssales=0,OP_cash=0,gross_main=0;
        decimal SD_Total=0, datebar_SD=0, missing_SD=0, compli_SD=0, waste_SD=0,
            NP_SD=0, Damage_SD=0, Change_SD=0, BNP_SD=0,bbkulam=0 ,excess=0;
        decimal total_denomination = 0;
        string sTableName = "";
        string op = "";
        string sUserChk = "";
        BSClass objbs = new BSClass();
        string branchcode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            branchcode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                 op = Request.Cookies["userInfo"]["OP"].ToString() ;

                 sUserChk = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
                 string time = DateTime.Now.ToString() ;

                 DateTime dat = DateTime.Parse(time);
             var hour =    dat.ToString("HH");
             var min = dat.ToString("mm");
             var current = hour + "." + min;

             //if (double.Parse(current) >= 22.00)
             //{
             //    btnsession.Enabled = true;
             //}
             //else
             //{
             //    btnsession.Enabled = false;
             //}

             if (Session["Biller"].ToString().ToLower() == "nona")
             {
                 part1.Visible = true;
                 part2.Visible = true;
                 salespart.Visible = true;
                 petty.Visible = true;
                 exp.Visible = true;
                 cardsales.Visible = true;
                 grosstot.Visible = true;
                 crSale.Visible = true;
                 nsales.Visible = true;
                 hens.Visible = true;
             }
             else
             {
                 //  date.Enabled = false;
                 //part1.Visible = false;
                 //part2.Visible = false;
                 //salespart.Visible = false;
                 //petty.Visible = false;
                 //exp.Visible = false;
                 //cardsales.Visible = false;
                 //grosstot.Visible = false;
                 //crSale.Visible = false;
                 //nsales.Visible = false;
                 //hens.Visible = false;
                 part1.Visible = true;
                 part2.Visible = true;
                 salespart.Visible = true;
                 petty.Visible = true;
                 exp.Visible = true;
                 cardsales.Visible = true;
                 grosstot.Visible = true;
                 crSale.Visible = true;
                 nsales.Visible = true;
                 hens.Visible = true;
             }
                 if (!IsPostBack)
                 {

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
                    
                     //if (branchcode != "NE")
                     //{
                     //    bbkulamm.Text = branchcode + " To BB Kulam";
                     //}
                     //else
                     //{
                     //    bbkulamm.Text = branchcode + " To Production";
                     //}
                     //if (branchcode == "KK")
                     //{
                     //    DDlbranch.SelectedValue = "1";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "BY")
                     //{
                     //    DDlbranch.SelectedValue = "2";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "BB")
                     //{
                     //    DDlbranch.SelectedValue = "3";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "NP")
                     //{
                     //    DDlbranch.SelectedValue = "4";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "NE")
                     //{
                     //    DDlbranch.SelectedValue = "5";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "NE")
                     //{
                     //    DDlbranch.SelectedValue = "5";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                    
                     //else if (branchcode == "MD")
                     //{
                     //    DDlbranch.SelectedValue = "6";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}

                     //else if (branchcode == "PU")
                     //{
                     //    DDlbranch.SelectedValue = "7";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "CH")
                     //{
                     //    DDlbranch.SelectedValue = "8";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}

                     //else if (branchcode == "TH")
                     //{
                     //    DDlbranch.SelectedValue = "9";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}

                     //else if (branchcode == "PER")
                     //{
                     //    DDlbranch.SelectedValue = "10";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else if (branchcode == "PAL1")
                     //{
                     //    DDlbranch.SelectedValue = "11";
                     //    DDlbranch.Enabled = false;
                     //    date.Enabled = true;
                     //}
                     //else
                     //{
                        

                     //}
                     //sadmin = Session["IsSuperAdmin"].ToString();
                     //if (sadmin == "1")
                     //{
                     //    DDlbranch.Enabled = true;
                     //    DataSet dsbranchto = objbs.Branchto();
                     //    DDlbranch.DataSource = dsbranchto.Tables[0];
                     //    DDlbranch.DataTextField = "branchcode";
                     //    DDlbranch.DataValueField = "Userid";
                     //    DDlbranch.DataBind();
                     //    //  ddlBranch.Items.Insert(0, "All");
                     //}
                     //else
                     //{
                     //    DataSet dsbranch = new DataSet();
                     //    string stable = "tblSales_" + sTableName + "";
                     //    dsbranch = objbs.Branchfrom(lblUserID.Text);
                     //    DDlbranch.DataSource = dsbranch.Tables[0];
                     //    DDlbranch.DataTextField = "branchcode";
                     //    DDlbranch.DataValueField = "Userid";
                     //    DDlbranch.DataBind();
                     //    DDlbranch.Enabled = false;
                     //}

                     lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                     lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                    // sTableName = Session["User"].ToString();
                     string dt="";
                     DataSet dsclose = objbs.Get_PreviousdayClosingdetails(sTableName);

                     if (dsclose.Tables[0].Rows.Count > 0)
                     {
                         dt = DateTime.Today.ToString("yyyy-MM-dd");
                     }
                     else
                     {
                         dt = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                     }
                     
                     if (branchcode == "NE")
                     {
                         lblOP_Cash_Amt.Text = "3000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }
                     if (branchcode == "KK")
                     {
                         lblOP_Cash_Amt.Text = "7000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }
                     if (branchcode == "BY")
                     {
                         lblOP_Cash_Amt.Text = "3000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }
                     if (branchcode == "NP")
                     {
                         lblOP_Cash_Amt.Text = "3000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }
                     if (branchcode == "BB")
                     {
                         lblOP_Cash_Amt.Text = "2000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }

                     if (branchcode == "MD")
                     {
                         lblOP_Cash_Amt.Text = "1000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }

                     if (branchcode == "PU")
                     {
                         lblOP_Cash_Amt.Text = "1000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }
                     if (branchcode == "CH")
                     {
                         lblOP_Cash_Amt.Text = "1000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }

                     if (branchcode == "TH")
                     {
                         lblOP_Cash_Amt.Text = "1000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }

                     if (branchcode == "PER")
                     {
                         lblOP_Cash_Amt.Text = "1000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }

                     if (branchcode == "PAL1")
                     {
                         lblOP_Cash_Amt.Text = "1000";
                         lblOP_Cash_Amt_TextChanged(sender, e);
                     }
                     //if (op.ToString().Trim() != "")
                     //{
                     //    lblOP_Cash_Amt.Text = op;
                     //    lblOP_Cash_Amt_TextChanged(sender, e);
                     //}

                     if (Session["IsSuperAdmin"].ToString() == "1")
                     {
                         DDlbranch.Enabled = true;
                         date.Enabled = true;

                     }
                         date.Text = dt;

                         DataSet elosales = objbs.sales_distribution(date.Text, sTableName,"1");
                         gvnormalsales.DataSource = elosales.Tables[0];
                         gvnormalsales.DataBind();

                         DataSet elosorder = objbs.Order_distribution(date.Text, sTableName, "'15'", "'adv','Bal','Full','Partial Amount'");
                         gvOrder.DataSource = elosorder.Tables[0];
                         gvOrder.DataBind();


                     #region SalesDeduction
                        DataSet ds_compliment = objbs.GetCompliment_sales(date.Text, sTableName);
                            if (ds_compliment.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblCompliment_salesdeduction_amt.Text = "0.00";

                     }
                     else
                     {
                         lblCompliment_salesdeduction_amt.Text = ds_compliment.Tables[0].Rows[0]["Sum"].ToString();
                         compli_SD = Math.Round(compli_SD, 2);
                         compli_SD = Convert.ToDecimal(lblCompliment_salesdeduction_amt.Text);
                         
                     }
                     
                     #endregion
                    
                     #region Sales Flow
                     //  string dt = DateTime.Today.ToString("dd/MM/yyyy");

                     DataSet ds_cash = objbs.GetCash_sales(date.Text, sTableName);

                     if (ds_cash.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblCash_sales_Amt.Text = "0.00";
                     }
                     else
                     {
                         cash = Convert.ToDecimal(ds_cash.Tables[0].Rows[0]["Sum"].ToString());
                         cash = Math.Round(cash, 2);
                         lblCash_sales_Amt.Text = cash.ToString();

                     }
                     DataSet ds_Excess = objbs.GetExcess(date.Text, sTableName);
                     if (ds_Excess.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblExcess.Text = "0.00";

                     }
                     else
                     {
                         excess = Convert.ToDecimal(ds_Excess.Tables[0].Rows[0]["Sum"].ToString());
                         excess = Math.Round(excess, 2);
                         lblExcess.Text = excess.ToString();

                     }
                     DataSet dAddless = objbs.Addless(sTableName, date.Text);
                     if (dAddless.Tables[0].Rows.Count > 0)
                     {
                         lblAdd.Text = dAddless.Tables[0].Rows[0]["Add"].ToString();
                         lblLess.Text = dAddless.Tables[0].Rows[0]["Less"].ToString();
                     }
                     DataSet ds_credit = objbs.GetCredit_sales(date.Text, sTableName);
                     if (ds_credit.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                        
                         lblCredit_Sales_Amt.Text = "0.00";

                     }
                     else
                     {
                         credit = Convert.ToDecimal(ds_credit.Tables[0].Rows[0]["Sum"].ToString());
                         credit = Math.Round(credit, 2);
                         
                         lblCredit_Sales_Amt.Text = credit.ToString();

                     }

                     DataSet ds_order = objbs.GetOrder_sales(date.Text, sTableName);
                     DataSet dordercard = objbs.orderCard(date.Text, sTableName);
                     if (dordercard.Tables[0].Rows[0]["Total"].ToString() == "")
                     {
                     }
                     else
                     {
                         decimal amt = Convert.ToDecimal(dordercard.Tables[0].Rows[0]["Total"].ToString());
                         lblordercard.Text = amt.ToString("f2");
                     }
                     if (ds_order.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblOrder_sales_amt.Text = "0.00";

                     }
                     else
                     {
                         compli = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["Sum"].ToString());
                         compli = Math.Round(compli, 2);
                         lblOrder_sales_amt.Text = compli.ToString();

                     }
                     DataSet ds_waste = objbs.GetWastage(date.Text, sTableName);
                     if (ds_waste.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblWastage_amt.Text = "0.00";

                     }
                     else
                     {
                         waste_SD = Convert.ToDecimal(ds_waste.Tables[0].Rows[0]["Sum"].ToString());
                         waste_SD = Math.Round(waste_SD, 2);
                         lblWastage_amt.Text = waste_SD.ToString();

                     }
                     DataSet ds_datebar= objbs.GetDateBar(date.Text, sTableName);
                     if (ds_datebar.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblDate_Bar_amt.Text = "0.00";

                     }
                     else
                     {
                        datebar_SD = Convert.ToDecimal(ds_datebar.Tables[0].Rows[0]["Sum"].ToString());
                        datebar_SD = Math.Round(datebar_SD, 2);
                        lblDate_Bar_amt.Text = datebar_SD.ToString();

                     }

                     DataSet ds_bbkulam = objbs.getbbkulam(date.Text, sTableName);
                     if (ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         bbkulamamount.Text = "0.00";

                     }
                     else
                     {
                         bbkulam = Convert.ToDecimal(ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString());
                         bbkulam = Math.Round(bbkulam, 2);
                         bbkulamamount.Text = bbkulam.ToString();

                     }



                     DataSet ds_card = objbs.GetCard_sales(date.Text, sTableName);
                     if (ds_card.Tables[0].Rows[0]["Sum"].ToString() == "")
                     {
                         lblCreditcard_Sales.Text = "0.00";

                     }
                     else
                     {
                         card = Convert.ToDecimal(ds_card.Tables[0].Rows[0]["Sum"].ToString());
                         //card = Math.Round(card, 2);

                         lblCreditcard_Sales.Text = card.ToString("f2");
                         

                     }
                   //  sales = cash + credit + card + compli;
                     //commented by prathep - 23 oct
                     sales = cash +  compli;
                     sales = Math.Round(sales, 2);
                     lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
                     gross = sales - card - SD_Total;
                     gross = Math.Round(gross, 2);
                  //   lblGross_sales_amt.Text = Convert.ToString(gross);
                     #endregion
                     #region Expense Table


                     DataSet ds= objbs.paymentgrid_Report(sTableName,dt);
                     int count = ds.Tables[0].Rows.Count;
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                         {
                             Label[] scoresLabelArr = new Label[count];
                             int location = 98;
                             Label currentLabel = new Label();
                             scoresLabelArr[a] = (Label)currentLabel;
                             scoresLabelArr[a].ID = "Expense_ledger" + a;
                             scoresLabelArr[a].Text = ds.Tables[0].Rows[a]["LedgerName"].ToString();
                             if (scoresLabelArr[a].Text == "Date barred")
                             {
                                 //lblDate_Bar_amt.Text = ds.Tables[0].Rows[a]["Amount"].ToString();
                             }
                             scoresLabelArr[a].Height = 28;

                             pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
                             pnlTextBoxes.Controls.Add(currentLabel);
                             location += 100;

                         }
                         for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                         {
                             Label[] scoresLabelArr = new Label[count];
                             int location = 98;
                             Label currentLabel = new Label();
                             scoresLabelArr[a] = (Label)currentLabel;
                             scoresLabelArr[a].ID = "Expense_Amt" + a;
                             tmp=Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString());
                             tmp = Math.Round(tmp, 2);
                             scoresLabelArr[a].Text = Convert.ToString(tmp);
                            
                             scoresLabelArr[a].Height = 28;
                             pnlTextBoxes1.Controls.Add(new LiteralControl("<br />"));
                             pnlTextBoxes1.Controls.Add(currentLabel);
                             location += 100;
                             total += tmp;
                         }

                     }
                     total = Math.Round(total, 2);
                     lblTotal_Exp_Amt1.Text = Convert.ToString(total);
                     lblTotal_Exp_Amt.Text = Convert.ToString(total);
                     #endregion
                     #region Denomination
                     int thou = 0, Fivehun = 0, hund = 0, fiftys = 0, twenty = 0, tens = 0, Fives = 0, twos = 0, ones = 0, coins = 0,twothou=0,twohund=0;
                     decimal thou_t = 0, Fivehun_t = 0, hund_t = 0, fiftys_t = 0, twenty_t = 0, tens_t = 0, Fives_t = 0, twos_t = 0, ones_t = 0,twothou_t=0,towhund_t=0;
                     double coins_t = 0;
                     DataSet ds_denomination = objbs.check_denomination(sTableName,dt);
                     if (ds_denomination.Tables[0].Rows.Count > 0)
                     {
                         lbl2000_no.Text = ds_denomination.Tables[0].Rows[0]["TwoThousand"].ToString();
                         twothou = Convert.ToInt32(lbl2000_no.Text);
                         twothou_t = 2000 * twothou;
                         twothou_t = Math.Round(twothou_t, 2);
                         lbl2000s.Text = Convert.ToString(twothou_t);

                         lbl500s_no.Text = ds_denomination.Tables[0].Rows[0]["FiveHundreds"].ToString();
                         Fivehun = Convert.ToInt32(lbl500s_no.Text);
                         Fivehun_t = 500 * Fivehun;
                         Fivehun_t = Math.Round(Fivehun_t, 2);
                         lbl500s.Text = Convert.ToString(Fivehun_t);

                         lbl200s_no.Text = ds_denomination.Tables[0].Rows[0]["Twohundred"].ToString();
                         twohund = Convert.ToInt32(lbl200s_no.Text);
                         towhund_t = 200 * twohund;
                         towhund_t = Math.Round(towhund_t, 2);
                         lbl200s.Text = Convert.ToString(towhund_t);

                         lbl100s_no.Text = ds_denomination.Tables[0].Rows[0]["Hundreds"].ToString();
                         hund = Convert.ToInt32(lbl100s_no.Text);
                         hund_t = 100 * hund;
                         hund_t = Math.Round(hund_t, 2);
                         lbl100s.Text = Convert.ToString(hund_t);

                         lbl50s_no.Text = ds_denomination.Tables[0].Rows[0]["Fiftys"].ToString();
                         fiftys = Convert.ToInt32(lbl50s_no.Text);
                         fiftys_t = 50 * fiftys;
                         fiftys_t = Math.Round(fiftys_t, 2);
                         lbl50s.Text = Convert.ToString(fiftys_t);

                         lbl20s_no.Text = ds_denomination.Tables[0].Rows[0]["Twentys"].ToString();
                         twenty = Convert.ToInt32(lbl20s_no.Text);
                         twenty_t = 20 * twenty;
                         twenty_t = Math.Round(twenty_t, 2);
                         lbl20s.Text = Convert.ToString(twenty_t);

                         lbl10s_no.Text = ds_denomination.Tables[0].Rows[0]["Tens"].ToString();
                         tens = Convert.ToInt32(lbl10s_no.Text);
                         tens_t = 10 * tens;
                         tens_t = Math.Round(tens_t, 2);
                         lbl10s.Text = Convert.ToString(tens_t);

                         lbl5s_no.Text = ds_denomination.Tables[0].Rows[0]["Fives"].ToString();
                         Fives = Convert.ToInt32(lbl5s_no.Text);
                         Fives_t = 5 * Fives;
                         Fives_t = Math.Round(Fives_t, 2);
                         lbl5s.Text = Convert.ToString(Fives_t);

                         lbl2s_no.Text = ds_denomination.Tables[0].Rows[0]["Twos"].ToString();
                         twos = Convert.ToInt32(lbl2s_no.Text);
                         twos_t = 2 * twos;
                         twos_t = Math.Round(twos_t, 2);
                         lbl2s.Text = Convert.ToString(twos_t);

                         lbl1s_no.Text = ds_denomination.Tables[0].Rows[0]["ones"].ToString();
                         ones = Convert.ToInt32(lbl1s_no.Text);
                         ones_t = 1 * ones;
                         ones_t = Math.Round(ones_t, 2);
                         lbl1s.Text = Convert.ToString(ones_t);

                         lblcoinss_no.Text = ds_denomination.Tables[0].Rows[0]["Coins"].ToString();
                         coins = Convert.ToInt32(lblcoinss_no.Text);
                         double coin_d = Convert.ToDouble(coins);
                         coins_t = (1) * coin_d;
                         coins_t = Math.Round(coins_t, 2);
                         lblcoinss.Text = Convert.ToString(coins_t);

                         total_denomination = Convert.ToDecimal(ds_denomination.Tables[0].Rows[0]["Total"].ToString());
                         total_denomination = Math.Round(total_denomination, 2);
                         lblTotal_Denominations.Text = Convert.ToString(total_denomination);

                     }
                     else
                     {

                         lbl2000_no.Text = "0";

                         lbl2000s.Text = "0.00";

                         lbl200s_no.Text = "0";

                         lbl200s.Text = "0.00";

                         lbl500s_no.Text = "0";

                         lbl500s.Text = "0.00";

                         lbl100s_no.Text = "0";

                         lbl100s.Text = "0.00";

                         lbl50s_no.Text = "0";

                         lbl50s.Text = "0.00";

                         lbl20s_no.Text = "0";

                         lbl20s.Text = "0.00";

                         lbl10s_no.Text = "0";

                         lbl10s.Text = "0.00";

                         lbl5s_no.Text = "0";
                         lbl5s.Text = "0.00";

                         lbl2s_no.Text = "0";
                         lbl2s.Text = "0.00";

                         lbl1s_no.Text = "0";
                         lbl1s.Text = "0.00";

                         lblcoinss_no.Text = "0";
                         lblcoinss.Text = "0.00";

                         lblTotal_Denominations.Text = "0";
                         lblErr.Text = "No Denominations Updated Today!!";
                     }
                     #endregion
                     #region Cash flow
                     decimal dCreditCardSale = Convert.ToDecimal(lblCreditcard_Sales.Text);
                     OP_cash = Convert.ToDecimal(lblOP_Cash_Amt.Text);
                     OP_cash = Math.Round(OP_cash, 2);                     
                     total_denomination=Convert.ToDecimal(lblTotal_Denominations.Text);
                     total_denomination = Math.Round(total_denomination, 2);
                     cash_handover=Convert.ToDecimal(lblCash_handover_amt.Text);
                     cash_handover = Math.Round(cash_handover, 2);
                     lblCash_Closing_Amt.Text =Convert.ToString(total_denomination - cash_handover);
                     Closing_cash=Convert.ToDecimal(lblCash_Closing_Amt.Text);
                     Closing_cash = Math.Round(Closing_cash, 2);
                     tot_grosssales = cash_handover + Closing_cash + total  + dCreditCardSale;
                     tot_grosssales = Math.Round(tot_grosssales, 2);
                     lblSales_Gross_amt.Text = tot_grosssales.ToString();
                     net_sales = (tot_grosssales - OP_cash);
                     net_sales = Math.Round(net_sales, 2);
                     lblNet_Sales_Amt.Text = net_sales.ToString();
                     lblSales_Result_amt.Text = (gross - net_sales).ToString();
                     #endregion
                     #region SD
                     datebar_SD = Math.Round(datebar_SD, 2);
                     lblDate_Bar_amt.Text = Convert.ToString(datebar_SD);
                     missing_SD = Math.Round(missing_SD, 2);
                     lblMissing_amt.Text = Convert.ToString(missing_SD);
                     //lblCompliment_salesdeduction_amt.Text = Convert.ToString(compli_SD);
                     waste_SD = Math.Round(waste_SD, 2);
                     lblWastage_amt.Text = Convert.ToString(waste_SD);
                     NP_SD = Math.Round(NP_SD, 2);
                     lblNP_Byepass_amt.Text = Convert.ToString(NP_SD);
                     Damage_SD = Math.Round(Damage_SD, 2);
                     lblDamage_amt.Text = Convert.ToString(Damage_SD);
                     lblExcess.Text = Convert.ToString(excess);
                     Change_SD = Math.Round(Change_SD, 2);
                     lblProduct_change_amt.Text = Convert.ToString(Change_SD);
                     BNP_SD = Math.Round(BNP_SD, 2);
                     lblBNP_Byepass_amt.Text = Convert.ToString(BNP_SD);
                     bbkulam = Math.Round(bbkulam,2);
                     bbkulamamount.Text = Convert.ToString(bbkulam);
                     SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD  + excess;
                     SD_Total = Math.Round(SD_Total, 2);
                     lblSales_deductions_amt.Text = Convert.ToString(SD_Total);
                     lblSales_Deduction_amt1.Text = Convert.ToString(SD_Total);
                     
                     #endregion
                     #region SF
                    // sales = cash + credit + card + compli;
                     //commented by prathep - 23 oct
                     sales = cash + compli;
                     sales = Math.Round(sales, 2);
                     lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
                     gross = sales - card - SD_Total;
                     gross = Math.Round(gross, 2);
                    // lblGross_sales_amt.Text = Convert.ToString(gross);
                     lblSales_Result_amt.Text = ( net_sales-sales).ToString();
                     #endregion
                 }
                

             }
      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblOP_Cash_Amt.Text = "0";
            #region Sales Deduction
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
        //    sTableName = Session["User"].ToString();
            DataSet ds_compliment = objbs.GetCompliment_sales(date.Text, sTableName);
            if (ds_compliment.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCompliment_salesdeduction_amt.Text = "0.00";

            }
            else
            {
                lblCompliment_salesdeduction_amt.Text = ds_compliment.Tables[0].Rows[0]["Sum"].ToString();
                compli_SD = Math.Round(compli_SD, 2);
                compli_SD = Convert.ToDecimal(lblCompliment_salesdeduction_amt.Text);
            }
          
            #endregion
            #region Sales Flow
            //  string dt = DateTime.Today.ToString("dd/MM/yyyy");

            DataSet ds_cash = objbs.GetCash_sales(date.Text, sTableName);

            if (ds_cash.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCash_sales_Amt.Text = "0.00";
            }
            else
            {
                cash = Convert.ToDecimal(ds_cash.Tables[0].Rows[0]["Sum"].ToString());
                cash = Math.Round(cash, 2);
                lblCash_sales_Amt.Text = cash.ToString();

            }
            DataSet ds_credit = objbs.GetCredit_sales(date.Text, sTableName);
            if (ds_credit.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
               
                lblCredit_Sales_Amt.Text = "0.00";

            }
            else
            {
                credit = Convert.ToDecimal(ds_credit.Tables[0].Rows[0]["Sum"].ToString());
                credit = Math.Round(credit, 2);
                
                lblCredit_Sales_Amt.Text = credit.ToString();

            }
            DataSet ds_waste = objbs.GetWastage(date.Text, sTableName);
            if (ds_waste.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblWastage_amt.Text = "0.00";

            }
            else
            {
                waste_SD = Convert.ToDecimal(ds_waste.Tables[0].Rows[0]["Sum"].ToString());
                waste_SD = Math.Round(waste_SD, 2);
                lblWastage_amt.Text = waste_SD.ToString();

            }

            DataSet ds_Excess = objbs.GetExcess(date.Text, sTableName);
            if (ds_Excess.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblExcess.Text = "0.00";

            }
            else
            {
                excess = Convert.ToDecimal(ds_Excess.Tables[0].Rows[0]["Sum"].ToString());
                excess = Math.Round(excess, 2);
                lblExcess.Text = excess.ToString();

            }
            DataSet ds_datebar = objbs.GetDateBar(date.Text, sTableName);
            if (ds_datebar.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblDate_Bar_amt.Text = "0.00";

            }
            else
            {
                datebar_SD = Convert.ToDecimal(ds_datebar.Tables[0].Rows[0]["Sum"].ToString());
                datebar_SD = Math.Round(datebar_SD, 2);
                lblDate_Bar_amt.Text = datebar_SD.ToString();

            }
            DataSet ds_order = objbs.GetOrder_sales(date.Text, sTableName);
            DataSet dordercard = objbs.orderCard(date.Text, sTableName);
            if (dordercard.Tables[0].Rows[0]["Total"].ToString() == "")
            {
            }
            else
            {
                decimal amt = Convert.ToDecimal(dordercard.Tables[0].Rows[0]["Total"].ToString());
                lblordercard.Text = amt.ToString("f2");
            }
            if (ds_order.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblOrder_sales_amt.Text = "0.00";

            }
            else
            {
                compli = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["Sum"].ToString());
                compli = Math.Round(compli, 2);
                lblOrder_sales_amt.Text = compli.ToString();

            }
            DataSet ds_bbkulam = objbs.getbbkulam(date.Text, sTableName);
            if (ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                bbkulamamount.Text = "0.00";

            }
            else
            {
                bbkulam = Convert.ToDecimal(ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString());
                bbkulam = Math.Round(bbkulam, 2);
                bbkulamamount.Text = bbkulam.ToString();

            }
            DataSet ds_card = objbs.GetCard_sales(date.Text, sTableName);
            if (ds_card.Tables[0].Rows[0]["Sum"].ToString() == "")
            {

                lblCreditcard_Sales.Text = "0.00";
            }
            else
            {
                card = Convert.ToDecimal(ds_card.Tables[0].Rows[0]["Sum"].ToString());
                //card = Math.Round(card, 2);
                lblCreditcard_Sales.Text = card.ToString("f2");
                

            }
           // sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash + compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
           // lblGross_sales_amt.Text = Convert.ToString(gross);
            #endregion
            #region Expense Table

            DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_ledger" + a;
                    scoresLabelArr[a].Text = ds.Tables[0].Rows[a]["LedgerName"].ToString();
                    if (scoresLabelArr[a].Text == "Date barred")
                    {
                        //lblDate_Bar_amt.Text = ds.Tables[0].Rows[a]["Amount"].ToString();
                    }
                    scoresLabelArr[a].Height = 28;

                    pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes.Controls.Add(currentLabel);
                    location += 100;

                }
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_Amt" + a;
                    tmp = Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString());
                    tmp = Math.Round(tmp, 2);
                    scoresLabelArr[a].Text = Convert.ToString(tmp);
                    scoresLabelArr[a].Height = 28;
                    pnlTextBoxes1.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes1.Controls.Add(currentLabel);
                    location += 100;
                    total += tmp;
                }

            }
            total = Math.Round(total, 2);
            lblTotal_Exp_Amt1.Text = Convert.ToString(total);
            lblTotal_Exp_Amt.Text = Convert.ToString(total);
            #endregion
            #region Denomination
            int thou = 0, Fivehun = 0, hund = 0, fiftys = 0, twenty = 0, tens = 0, Fives = 0, twos = 0, ones = 0, coins = 0;
            decimal thou_t = 0, Fivehun_t = 0, hund_t = 0, fiftys_t = 0, twenty_t = 0, tens_t = 0, Fives_t = 0, twos_t = 0, ones_t = 0;
            double coins_t = 0;
            DataSet ds_denomination = objbs.check_denomination(sTableName,date.Text);
            if (ds_denomination.Tables[0].Rows.Count > 0)
            {
                lbl2000_no.Text = ds_denomination.Tables[0].Rows[0]["Thousands"].ToString();
                thou = Convert.ToInt32(lbl2000_no.Text);
                thou_t = 2000 * thou;
                thou_t = Math.Round(thou_t, 2);
                lbl2000s.Text = Convert.ToString(thou_t);

                lbl500s_no.Text = ds_denomination.Tables[0].Rows[0]["FiveHundreds"].ToString();
                Fivehun = Convert.ToInt32(lbl500s_no.Text);
                Fivehun_t = 500 * Fivehun;
                Fivehun_t = Math.Round(Fivehun_t, 2);
                lbl500s.Text = Convert.ToString(Fivehun_t);

                lbl100s_no.Text = ds_denomination.Tables[0].Rows[0]["Hundreds"].ToString();
                hund = Convert.ToInt32(lbl100s_no.Text);
                hund_t = 100 * hund;
                hund_t = Math.Round(hund_t, 2);
                lbl100s.Text = Convert.ToString(hund_t);

                lbl50s_no.Text = ds_denomination.Tables[0].Rows[0]["Fiftys"].ToString();
                fiftys = Convert.ToInt32(lbl50s_no.Text);
                fiftys_t = 50 * fiftys;
                fiftys_t = Math.Round(fiftys_t, 2);
                lbl50s.Text = Convert.ToString(fiftys_t);

                lbl20s_no.Text = ds_denomination.Tables[0].Rows[0]["Twentys"].ToString();
                twenty = Convert.ToInt32(lbl20s_no.Text);
                twenty_t = 20 * twenty;
                twenty_t = Math.Round(twenty_t, 2);
                lbl20s.Text = Convert.ToString(twenty_t);

                lbl10s_no.Text = ds_denomination.Tables[0].Rows[0]["Tens"].ToString();
                tens = Convert.ToInt32(lbl10s_no.Text);
                tens_t = 10 * tens;
                tens_t = Math.Round(tens_t, 2);
                lbl10s.Text = Convert.ToString(tens_t);

                lbl5s_no.Text = ds_denomination.Tables[0].Rows[0]["Fives"].ToString();
                Fives = Convert.ToInt32(lbl5s_no.Text);
                Fives_t = 5 * Fives;
                Fives_t = Math.Round(Fives_t, 2);
                lbl5s.Text = Convert.ToString(Fives_t);

                lbl2s_no.Text = ds_denomination.Tables[0].Rows[0]["Twos"].ToString();
                twos = Convert.ToInt32(lbl2s_no.Text);
                twos_t = 2 * twos;
                twos_t = Math.Round(twos_t, 2);
                lbl2s.Text = Convert.ToString(twos_t);

                lbl1s_no.Text = ds_denomination.Tables[0].Rows[0]["ones"].ToString();
                ones = Convert.ToInt32(lbl1s_no.Text);
                ones_t = 1 * ones;
                ones_t = Math.Round(ones_t, 2);
                lbl1s.Text = Convert.ToString(ones_t);

                lblcoinss_no.Text = ds_denomination.Tables[0].Rows[0]["Coins"].ToString();
                coins = Convert.ToInt32(lblcoinss_no.Text);
                double coin_d = Convert.ToDouble(coins);
                coins_t = (1) * coin_d;
                coins_t = Math.Round(coins_t, 2);
                lblcoinss.Text = Convert.ToString(coins_t);

                total_denomination = Convert.ToDecimal(ds_denomination.Tables[0].Rows[0]["Total"].ToString());
                total_denomination = Math.Round(total_denomination, 2);
                lblTotal_Denominations.Text = Convert.ToString(total_denomination);

            }
            else
            {
                lbl2000_no.Text = "0";

                lbl2000s.Text = "0.00";

                lbl500s_no.Text = "0";

                lbl500s.Text = "0.00";

                lbl100s_no.Text = "0";

                lbl100s.Text = "0.00";

                lbl50s_no.Text = "0";

                lbl50s.Text = "0.00";

                lbl20s_no.Text = "0";

                lbl20s.Text = "0.00";

                lbl10s_no.Text = "0";

                lbl10s.Text = "0.00";

                lbl5s_no.Text = "0";
                lbl5s.Text = "0.00";

                lbl2s_no.Text = "0";
                lbl2s.Text = "0.00";

                lbl1s_no.Text = "0";
                lbl1s.Text = "0.00";

                lblcoinss_no.Text = "0";
                lblcoinss.Text = "0.00";

                lblTotal_Denominations.Text = "0";
                lblErr.Text = "No Denominations Updated On this day!!";
            }
            #endregion
            #region Cash flow
            decimal dCreditCardSale = Convert.ToDecimal(lblCreditcard_Sales.Text);
            OP_cash = Convert.ToDecimal(lblOP_Cash_Amt.Text);
            OP_cash = Math.Round(OP_cash, 2);
            total_denomination = Convert.ToDecimal(lblTotal_Denominations.Text);
            total_denomination = Math.Round(total_denomination, 2);
            cash_handover = Convert.ToDecimal(lblCash_handover_amt.Text);
            cash_handover = Math.Round(cash_handover, 2);
            lblCash_Closing_Amt.Text = Convert.ToString(total_denomination - cash_handover);
            Closing_cash = Convert.ToDecimal(lblCash_Closing_Amt.Text);
            Closing_cash = Math.Round(Closing_cash, 2);
            tot_grosssales = cash_handover + Closing_cash + total  + dCreditCardSale;
            tot_grosssales = Math.Round(tot_grosssales, 2);

            lblSales_Gross_amt.Text = tot_grosssales.ToString();
            net_sales = (tot_grosssales - OP_cash);
            net_sales = Math.Round(net_sales, 2);
            lblNet_Sales_Amt.Text = net_sales.ToString();
            lblSales_Result_amt.Text = (gross - net_sales).ToString();
            #endregion
            #region SD
            datebar_SD = Math.Round(datebar_SD, 2);
            lblDate_Bar_amt.Text = Convert.ToString(datebar_SD);
            missing_SD = Math.Round(missing_SD, 2);
            lblMissing_amt.Text = Convert.ToString(missing_SD);
            waste_SD = Math.Round(waste_SD, 2);
            //lblCompliment_salesdeduction_amt.Text = Convert.ToString(compli_SD);
            lblWastage_amt.Text = Convert.ToString(waste_SD);
            NP_SD = Math.Round(NP_SD, 2);
            lblNP_Byepass_amt.Text = Convert.ToString(NP_SD);
            Damage_SD = Math.Round(Damage_SD, 2);
            lblDamage_amt.Text = Convert.ToString(Damage_SD);
            Change_SD = Math.Round(Change_SD, 2);
            lblProduct_change_amt.Text = Convert.ToString(Change_SD);
            lblExcess.Text = Convert.ToString(excess);
            BNP_SD = Math.Round(BNP_SD, 2);
            lblBNP_Byepass_amt.Text = Convert.ToString(BNP_SD);
            bbkulam = Math.Round(bbkulam, 2);
            bbkulamamount.Text = Convert.ToString(bbkulam);
           // SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD + bbkulam+excess;
            //commented by pratheep
            SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD +  excess;
            SD_Total = Math.Round(SD_Total, 2);
            lblSales_deductions_amt.Text = Convert.ToString(SD_Total);
            lblSales_Deduction_amt1.Text = Convert.ToString(SD_Total);
            #endregion
            #region SF
            //sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash + compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
          //  lblGross_sales_amt.Text = Convert.ToString(gross);
            lblSales_Result_amt.Text = ( net_sales-sales).ToString();
            #endregion
            DataSet elosales = objbs.sales_distribution(date.Text, sTableName,"");
            gvnormalsales.DataSource = elosales.Tables[0];
            gvnormalsales.DataBind();

            DataSet elosorder = objbs.Order_distribution(date.Text, sTableName, "'15'", "'adv','Bal','Full','Partial Amount'");
            gvOrder.DataSource = elosorder.Tables[0];
            gvOrder.DataBind();
        }

        protected void lblCash_handover_amt_TextChanged(object sender, EventArgs e)
        {
            //if (DDlbranch.SelectedValue == "1")
            //{
            //    sTableName = "CO1";
            //}
            //else if (DDlbranch.SelectedValue == "2")
            //{
            //    sTableName = "CO2";
            //}
            //else if (DDlbranch.SelectedValue == "3")
            //{
            //    sTableName = "CO3";
            //}
            //else if (DDlbranch.SelectedValue == "4")
            //{
            //    sTableName = "CO4";
            //}
            //else if (DDlbranch.SelectedValue == "6")
            //{
            //    sTableName = "CO6";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "7")
            //{
            //    sTableName = "CO7";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "5")
            //{
            //    sTableName = "CO5";
            //}
            //else if (DDlbranch.SelectedValue == "8")
            //{
            //    sTableName = "CO8";
            //}
            //else if (DDlbranch.SelectedValue == "9")
            //{
            //    sTableName = "CO9";
            //}

            //else if (DDlbranch.SelectedValue == "10")
            //{
            //    sTableName = "CO10";
            //}
            //else if (DDlbranch.SelectedValue == "11")
            //{
            //    sTableName = "CO11";
            //}
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
           // sTableName = Session["User"].ToString();
            #region Sales Flow
            //  string dt = DateTime.Today.ToString("dd/MM/yyyy");

            DataSet ds_cash = objbs.GetCash_sales(date.Text, sTableName);

            if (ds_cash.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCash_sales_Amt.Text = "0.00";
            }
            else
            {
                cash = Convert.ToDecimal(ds_cash.Tables[0].Rows[0]["Sum"].ToString());
                cash = Math.Round(cash, 2);
                lblCash_sales_Amt.Text = cash.ToString();

            }
            DataSet ds_credit = objbs.GetCredit_sales(date.Text, sTableName);
            if (ds_credit.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                
                lblCredit_Sales_Amt.Text = "0.00";

            }
            else
            {
                credit = Convert.ToDecimal(ds_credit.Tables[0].Rows[0]["Sum"].ToString());
                credit = Math.Round(credit, 2);
               
                lblCredit_Sales_Amt.Text = credit.ToString();

            }
            DataSet ds_waste = objbs.GetWastage(date.Text, sTableName);
            if (ds_waste.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblWastage_amt.Text = "0.00";

            }
            else
            {
                waste_SD = Convert.ToDecimal(ds_waste.Tables[0].Rows[0]["Sum"].ToString());
                waste_SD = Math.Round(waste_SD, 2);
                lblWastage_amt.Text = waste_SD.ToString();

            }
            DataSet ds_bbkulam = objbs.getbbkulam(date.Text, sTableName);
            if (ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                bbkulamamount.Text = "0.00";

            }
            else
            {
                bbkulam = Convert.ToDecimal(ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString());
                bbkulam = Math.Round(bbkulam, 2);
                bbkulamamount.Text = bbkulam.ToString();

            }
            DataSet ds_Excess = objbs.GetExcess(date.Text, sTableName);
            if (ds_Excess.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblExcess.Text = "0.00";

            }
          
            else
            {
                excess = Convert.ToDecimal(ds_Excess.Tables[0].Rows[0]["Sum"].ToString());
                excess = Math.Round(excess, 2);
                lblExcess.Text = excess.ToString();


               

            }
            DataSet ds_datebar = objbs.GetDateBar(date.Text, sTableName);
            if (ds_datebar.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblDate_Bar_amt.Text = "0.00";

            }
            else
            {
                datebar_SD = Convert.ToDecimal(ds_datebar.Tables[0].Rows[0]["Sum"].ToString());
                datebar_SD = Math.Round(datebar_SD, 2);
                lblDate_Bar_amt.Text = datebar_SD.ToString();

            }
            DataSet ds_order = objbs.GetOrder_sales(date.Text, sTableName);
            DataSet dordercard = objbs.orderCard(date.Text, sTableName);
            if (dordercard.Tables[0].Rows[0]["Total"].ToString() == "")
            {
            }
            else
            {
                decimal amt = Convert.ToDecimal(dordercard.Tables[0].Rows[0]["Total"].ToString());
                lblordercard.Text = amt.ToString("f2");
            }
            if (ds_order.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblOrder_sales_amt.Text = "0.00";

            }
            else
            {
                compli = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["Sum"].ToString());
                compli = Math.Round(compli, 2);
                lblOrder_sales_amt.Text = compli.ToString();

            }
            DataSet ds_card = objbs.GetCard_sales(date.Text, sTableName);
            if (ds_card.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCreditcard_Sales.Text = "0.00";

            }
            else
            {
                card = Convert.ToDecimal(ds_card.Tables[0].Rows[0]["Sum"].ToString());
                //card = Math.Round(card, 2);

                lblCreditcard_Sales.Text = card.ToString("f2");
                

            }
            DataSet dAddless = objbs.Addless(sTableName, date.Text);
            if (dAddless.Tables[0].Rows.Count > 0)
            {
                lblAdd.Text = dAddless.Tables[0].Rows[0]["Add"].ToString();
                lblLess.Text = dAddless.Tables[0].Rows[0]["Less"].ToString();
            }
           // sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash +  compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
          //  lblGross_sales_amt.Text = Convert.ToString(gross);
            #endregion
            #region Expense Table

            DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_ledger" + a;
                    scoresLabelArr[a].Text = ds.Tables[0].Rows[a]["LedgerName"].ToString();
                    if (scoresLabelArr[a].Text == "Date barred")
                    {
                        //lblDate_Bar_amt.Text = ds.Tables[0].Rows[a]["Amount"].ToString();
                    }
                    scoresLabelArr[a].Height = 28;

                    pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes.Controls.Add(currentLabel);
                    location += 100;

                }
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_Amt" + a;
                    tmp = Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString());
                    tmp = Math.Round(tmp, 2);
                    scoresLabelArr[a].Text = Convert.ToString(tmp);
                    scoresLabelArr[a].Height = 28;
                    pnlTextBoxes1.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes1.Controls.Add(currentLabel);
                    location += 100;
                    total += tmp;
                }

            }
            total = Math.Round(total, 2);
            lblTotal_Exp_Amt1.Text = Convert.ToString(total);
            lblTotal_Exp_Amt.Text = Convert.ToString(total);
            #endregion
            #region Cash flow
            decimal dCreditCardSale = Convert.ToDecimal(lblCreditcard_Sales.Text);
            OP_cash = Convert.ToDecimal(lblOP_Cash_Amt.Text);
            OP_cash = Math.Round(OP_cash, 2);
            total_denomination = Convert.ToDecimal(lblTotal_Denominations.Text);
            total_denomination = Math.Round(total_denomination, 2);
            cash_handover = Convert.ToDecimal(lblCash_handover_amt.Text);
            cash_handover = Math.Round(cash_handover, 2);
            lblCash_Closing_Amt.Text = Convert.ToString(total_denomination - cash_handover);
            Closing_cash = Convert.ToDecimal(lblCash_Closing_Amt.Text);
            Closing_cash = Math.Round(Closing_cash, 2);
            tot_grosssales = cash_handover + Closing_cash + total  + dCreditCardSale;
            tot_grosssales = Math.Round(tot_grosssales, 2);
            lblSales_Gross_amt.Text = tot_grosssales.ToString();
            net_sales = (tot_grosssales - OP_cash);
            net_sales = Math.Round(net_sales, 2);
            lblNet_Sales_Amt.Text = net_sales.ToString();
            lblSales_Result_amt.Text = (gross - net_sales).ToString();
            #endregion
            #region SD
            datebar_SD = Math.Round(datebar_SD, 2);
            lblDate_Bar_amt.Text = Convert.ToString(datebar_SD);
            missing_SD = Math.Round(missing_SD, 2);
            lblMissing_amt.Text = Convert.ToString(missing_SD);
            waste_SD = Math.Round(waste_SD, 2);
            //lblCompliment_salesdeduction_amt.Text = Convert.ToString(compli_SD);
            lblWastage_amt.Text = Convert.ToString(waste_SD);
            NP_SD = Math.Round(NP_SD, 2);
            lblNP_Byepass_amt.Text = Convert.ToString(NP_SD);
             lblExcess.Text = Convert.ToString(excess);
            Damage_SD = Math.Round(Damage_SD, 2);
            lblDamage_amt.Text = Convert.ToString(Damage_SD);
            bbkulam = Math.Round(bbkulam, 2);
            bbkulamamount.Text = Convert.ToString(bbkulam);
            Change_SD = Math.Round(Change_SD, 2);
            lblProduct_change_amt.Text = Convert.ToString(Change_SD);
            BNP_SD = Math.Round(BNP_SD, 2);
            lblBNP_Byepass_amt.Text = Convert.ToString(BNP_SD);
            //SD_Total = SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD + bbkulam + excess;
            //commnted by pratheep - 10/24/2015
            SD_Total = SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD +  excess;
            SD_Total = Math.Round(SD_Total, 2);
            lblSales_deductions_amt.Text = Convert.ToString(SD_Total);
            lblSales_Deduction_amt1.Text = Convert.ToString(SD_Total);
            #endregion
            #region SF
            //sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash +  compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
           // lblGross_sales_amt.Text = Convert.ToString(gross);
            lblSales_Result_amt.Text = (net_sales-sales).ToString();
            #endregion
        }

        protected void lblOP_Cash_Amt_TextChanged(object sender, EventArgs e)
        {
            //if (DDlbranch.SelectedValue == "1")
            //{
            //    sTableName = "CO1";
            //}
            //else if (DDlbranch.SelectedValue == "2")
            //{
            //    sTableName = "CO2";
            //}
            //else if (DDlbranch.SelectedValue == "3")
            //{
            //    sTableName = "CO3";
            //}
            //else if (DDlbranch.SelectedValue == "4")
            //{
            //    sTableName = "CO4";
            //}
            //else if (DDlbranch.SelectedValue == "6")
            //{
            //    sTableName = "CO6";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "7")
            //{
            //    sTableName = "CO7";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "5")
            //{
            //    sTableName = "CO5";
            //}
            //else if (DDlbranch.SelectedValue == "8")
            //{
            //    sTableName = "CO8";
            //}
            //else if (DDlbranch.SelectedValue == "9")
            //{
            //    sTableName = "CO9";
            //}

            //else if (DDlbranch.SelectedValue == "10")
            //{
            //    sTableName = "CO10";
            //}
            //else if (DDlbranch.SelectedValue == "11")
            //{
            //    sTableName = "CO11";
            //}
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
          //  sTableName = Session["User"].ToString();
            #region Sales Flow
            //  string dt = DateTime.Today.ToString("dd/MM/yyyy");

            DataSet ds_cash = objbs.GetCash_sales(date.Text, sTableName);

            if (ds_cash.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCash_sales_Amt.Text = "0.00";
            }
            else
            {
                 cash = Convert.ToDecimal(ds_cash.Tables[0].Rows[0]["Sum"].ToString());
                cash = Math.Round(cash, 2);
                lblCash_sales_Amt.Text = cash.ToString();
               
            }
            DataSet ds_credit = objbs.GetCredit_sales(date.Text, sTableName);
            if (ds_credit.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
               
                lblCredit_Sales_Amt.Text = "0.00";

            }
            else
            {
                 credit = Convert.ToDecimal(ds_credit.Tables[0].Rows[0]["Sum"].ToString());
                credit = Math.Round(credit, 2);
              
                lblCredit_Sales_Amt.Text = credit.ToString();
             
            }
            DataSet ds_waste = objbs.GetWastage(date.Text, sTableName);
            if (ds_waste.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblWastage_amt.Text = "0.00";

            }
            else
            {
                waste_SD = Convert.ToDecimal(ds_waste.Tables[0].Rows[0]["Sum"].ToString());
                waste_SD = Math.Round(waste_SD, 2);
                lblWastage_amt.Text = waste_SD.ToString();

            }
            DataSet ds_datebar = objbs.GetDateBar(date.Text, sTableName);
            if (ds_datebar.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblDate_Bar_amt.Text = "0.00";

            }
            else
            {
                datebar_SD = Convert.ToDecimal(ds_datebar.Tables[0].Rows[0]["Sum"].ToString());
                datebar_SD = Math.Round(datebar_SD, 2);
                lblDate_Bar_amt.Text = datebar_SD.ToString();

            }
            DataSet ds_bbkulam = objbs.getbbkulam(date.Text, sTableName);
            if (ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                bbkulamamount.Text = "0.00";

            }
            else
            {
                bbkulam = Convert.ToDecimal(ds_bbkulam.Tables[0].Rows[0]["Sum"].ToString());
                bbkulam = Math.Round(bbkulam, 2);
                bbkulamamount.Text = bbkulam.ToString();

            }
            DataSet ds_Excess = objbs.GetExcess(date.Text, sTableName);
            if (ds_Excess.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblExcess.Text = "0.00";

            }
            else
            {
                excess = Convert.ToDecimal(ds_Excess.Tables[0].Rows[0]["Sum"].ToString());
                excess = Math.Round(excess, 2);
                lblExcess.Text = excess.ToString();

            }
            DataSet ds_order = objbs.GetOrder_sales(date.Text, sTableName);
            DataSet dordercard = objbs.orderCard(date.Text, sTableName);
            if (dordercard.Tables[0].Rows[0]["Total"].ToString() == "")
            {
            }
            else
            {
                decimal amt = Convert.ToDecimal(dordercard.Tables[0].Rows[0]["Total"].ToString());
                lblordercard.Text = amt.ToString("f2");
            }
            if (ds_order.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblOrder_sales_amt.Text = "0.00";

            }
            else
            {
                 compli = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["Sum"].ToString());
                 compli = Math.Round(compli, 2);
                 lblOrder_sales_amt.Text = compli.ToString();
             
            }
            DataSet ds_card = objbs.GetCard_sales(date.Text, sTableName);
            if (ds_card.Tables[0].Rows[0]["Sum"].ToString() == "")
            {

                lblCreditcard_Sales.Text = "0.00";
            }
            else
            {
                card = Convert.ToDecimal(ds_card.Tables[0].Rows[0]["Sum"].ToString());
                lblCreditcard_Sales.Text = card.ToString("f2");
                 
               
            }
           // sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash + compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
           // lblGross_sales_amt.Text = Convert.ToString(gross);
            #endregion
            #region Expense Table

            DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_ledger" + a;
                    scoresLabelArr[a].Text = ds.Tables[0].Rows[a]["LedgerName"].ToString();
                    if (scoresLabelArr[a].Text == "Date barred")
                    {
                        //lblDate_Bar_amt.Text = ds.Tables[0].Rows[a]["Amount"].ToString();
                    }
                    scoresLabelArr[a].Height = 28;

                    pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes.Controls.Add(currentLabel);
                    location += 100;

                }
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_Amt" + a;
                    tmp = Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString());
                    tmp = Math.Round(tmp, 2);
                    scoresLabelArr[a].Text = Convert.ToString(tmp);
                    scoresLabelArr[a].Height = 28;
                    pnlTextBoxes1.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes1.Controls.Add(currentLabel);
                    location += 100;
                    total += tmp;
                }

            }
            total = Math.Round(total, 2);
            lblTotal_Exp_Amt1.Text = Convert.ToString(total);
            lblTotal_Exp_Amt.Text = Convert.ToString(total);
            #endregion
            #region Cash flow
            decimal dCreditCardSale = Convert.ToDecimal(lblCreditcard_Sales.Text);
            OP_cash = Convert.ToDecimal(lblOP_Cash_Amt.Text);
            OP_cash = Math.Round(OP_cash, 2);
            total_denomination = Convert.ToDecimal(lblTotal_Denominations.Text);
            total_denomination = Math.Round(total_denomination, 2);
            cash_handover = Convert.ToDecimal(lblCash_handover_amt.Text);
            cash_handover = Math.Round(cash_handover, 2);
            lblCash_Closing_Amt.Text = Convert.ToString(total_denomination - cash_handover);
            Closing_cash = Convert.ToDecimal(lblCash_Closing_Amt.Text);
            Closing_cash = Math.Round(Closing_cash, 2);
            tot_grosssales = cash_handover + Closing_cash + total  + dCreditCardSale;
            tot_grosssales = Math.Round(tot_grosssales, 2);
            lblSales_Gross_amt.Text = tot_grosssales.ToString();
            net_sales = (tot_grosssales - OP_cash);
            net_sales = Math.Round(net_sales, 2);
            lblNet_Sales_Amt.Text = net_sales.ToString();
            lblSales_Result_amt.Text = (gross - net_sales).ToString();
            #endregion
            #region SD
            datebar_SD = Math.Round(datebar_SD, 2);
            lblDate_Bar_amt.Text = Convert.ToString(datebar_SD);
            missing_SD = Math.Round(missing_SD, 2);
            lblMissing_amt.Text = Convert.ToString(missing_SD);
            waste_SD = Math.Round(waste_SD, 2);
            //lblCompliment_salesdeduction_amt.Text = Convert.ToString(compli_SD);
            lblWastage_amt.Text = Convert.ToString(waste_SD);
            NP_SD = Math.Round(NP_SD, 2);
            lblNP_Byepass_amt.Text = Convert.ToString(NP_SD);
            Damage_SD = Math.Round(Damage_SD, 2);
            lblDamage_amt.Text = Convert.ToString(Damage_SD);
            Change_SD = Math.Round(Change_SD, 2);
            lblProduct_change_amt.Text = Convert.ToString(Change_SD);
            BNP_SD = Math.Round(BNP_SD, 2);
            lblBNP_Byepass_amt.Text = Convert.ToString(BNP_SD);
            bbkulam = Math.Round(bbkulam, 2);
            bbkulamamount.Text = Convert.ToString(bbkulam);
            //SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD + bbkulam + excess; 
            //commented by pratheep
            SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD +  excess; 
            SD_Total = Math.Round(SD_Total, 2);
            lblSales_deductions_amt.Text = Convert.ToString(SD_Total);
            lblSales_Deduction_amt1.Text = Convert.ToString(SD_Total);
            #endregion
            #region SF
            //sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash +  compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
          //  lblGross_sales_amt.Text = Convert.ToString(gross);
            lblSales_Result_amt.Text = (net_sales-sales).ToString();
            #endregion
        }

        protected void DDlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dt = DateTime.Today.ToString("yyyy-MM-dd");
            date.Text = dt;
            //if (DDlbranch.SelectedValue == "1")
            //{
            //    sTableName = "CO1";
            //}
            //else if (DDlbranch.SelectedValue == "2")
            //{
            //    sTableName = "CO2";
            //}
            //else if (DDlbranch.SelectedValue == "3")
            //{
            //    sTableName = "CO3";
            //}
            //else if (DDlbranch.SelectedValue == "4")
            //{
            //    sTableName = "CO4";

            //}

            //else if (DDlbranch.SelectedValue == "6")
            //{
            //    sTableName = "CO6";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "7")
            //{
            //    sTableName = "CO7";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "5")
            //{
            //    sTableName = "CO5";
            //}

            //else if (DDlbranch.SelectedValue == "8")
            //{
            //    sTableName = "CO8";
            //}
            //else if (DDlbranch.SelectedValue == "9")
            //{
            //    sTableName = "CO9";
            //}

            //else if (DDlbranch.SelectedValue == "10")
            //{
            //    sTableName = "CO10";
            //}
            //else if (DDlbranch.SelectedValue == "11")
            //{
            //    sTableName = "CO11";
            //}
            #region SalesDeduction
            DataSet ds_compliment = objbs.GetCompliment_sales(date.Text, sTableName);
            if (ds_compliment.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCompliment_salesdeduction_amt.Text = "0.00";

            }
            else
            {
                lblCompliment_salesdeduction_amt.Text = ds_compliment.Tables[0].Rows[0]["Sum"].ToString();
                compli_SD = Math.Round(compli_SD, 2);
                compli_SD = Convert.ToDecimal(lblCompliment_salesdeduction_amt.Text);

            }

            #endregion

            #region Sales Flow
            //  string dt = DateTime.Today.ToString("dd/MM/yyyy");

            DataSet ds_cash = objbs.GetCash_sales(date.Text, sTableName);

            if (ds_cash.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblCash_sales_Amt.Text = "0.00";
            }
            else
            {
                cash = Convert.ToDecimal(ds_cash.Tables[0].Rows[0]["Sum"].ToString());
                cash = Math.Round(cash, 2);
                lblCash_sales_Amt.Text = cash.ToString();

            }
            DataSet ds_credit = objbs.GetCredit_sales(date.Text, sTableName);
            if (ds_credit.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
               
                lblCredit_Sales_Amt.Text = "0.00";

            }
            else
            {
                credit = Convert.ToDecimal(ds_credit.Tables[0].Rows[0]["Sum"].ToString());
                credit = Math.Round(credit, 2);
                
                lblCredit_Sales_Amt.Text = credit.ToString();

            }

            DataSet ds_order = objbs.GetOrder_sales(date.Text, sTableName);
            DataSet dordercard = objbs.orderCard(date.Text, sTableName);
            if (dordercard.Tables[0].Rows[0]["Total"].ToString()== "")
            {
            }
            else
            {
                decimal amt = Convert.ToDecimal(dordercard.Tables[0].Rows[0]["Total"].ToString());
                lblordercard.Text=amt.ToString("f2");
            }
            if (ds_order.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblOrder_sales_amt.Text = "0.00";

            }
            else
            {
                compli = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["Sum"].ToString());
                compli = Math.Round(compli, 2);
                lblOrder_sales_amt.Text = compli.ToString();

            }
            DataSet ds_waste = objbs.GetWastage(date.Text, sTableName);
            if (ds_waste.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblWastage_amt.Text = "0.00";

            }
            else
            {
                waste_SD = Convert.ToDecimal(ds_waste.Tables[0].Rows[0]["Sum"].ToString());
                waste_SD = Math.Round(waste_SD, 2);
                lblWastage_amt.Text = waste_SD.ToString();

            }
            DataSet ds_Excess = objbs.GetExcess(date.Text, sTableName);
            if (ds_Excess.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblExcess.Text = "0.00";

            }
            else
            {
                excess = Convert.ToDecimal(ds_Excess.Tables[0].Rows[0]["Sum"].ToString());
                excess = Math.Round(excess, 2);
                lblExcess.Text = excess.ToString();

            }
            DataSet ds_datebar = objbs.GetDateBar(date.Text, sTableName);
            if (ds_datebar.Tables[0].Rows[0]["Sum"].ToString() == "")
            {
                lblDate_Bar_amt.Text = "0.00";

            }
            else
            {
                datebar_SD = Convert.ToDecimal(ds_datebar.Tables[0].Rows[0]["Sum"].ToString());
                datebar_SD = Math.Round(datebar_SD, 2);
                lblDate_Bar_amt.Text = datebar_SD.ToString();

            }
            DataSet ds_card = objbs.GetCard_sales(date.Text, sTableName);
            if (ds_card.Tables[0].Rows[0]["Sum"].ToString() == "")
            {

                lblCreditcard_Sales.Text = "0.00";
            }
            else
            {
                card = Convert.ToDecimal(ds_card.Tables[0].Rows[0]["Sum"].ToString());
                //card = Math.Round(card, 2);

                lblCreditcard_Sales.Text = card.ToString("f2");
               

            }
           // sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash + compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
          //  lblGross_sales_amt.Text = Convert.ToString(gross);
            #endregion
            #region Expense Table


            DataSet ds = objbs.paymentgrid_Report(sTableName, dt);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_ledger" + a;
                    scoresLabelArr[a].Text = ds.Tables[0].Rows[a]["LedgerName"].ToString();
                    if (scoresLabelArr[a].Text == "Date barred")
                    {
                        //lblDate_Bar_amt.Text = ds.Tables[0].Rows[a]["Amount"].ToString();
                    }
                    scoresLabelArr[a].Height = 28;

                    pnlTextBoxes.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes.Controls.Add(currentLabel);
                    location += 100;

                }
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    Label[] scoresLabelArr = new Label[count];
                    int location = 98;
                    Label currentLabel = new Label();
                    scoresLabelArr[a] = (Label)currentLabel;
                    scoresLabelArr[a].ID = "Expense_Amt" + a;
                    tmp = Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"].ToString());
                    tmp = Math.Round(tmp, 2);
                    scoresLabelArr[a].Text = Convert.ToString(tmp);

                    scoresLabelArr[a].Height = 28;
                    pnlTextBoxes1.Controls.Add(new LiteralControl("<br />"));
                    pnlTextBoxes1.Controls.Add(currentLabel);
                    location += 100;
                    total += tmp;
                }

            }
            total = Math.Round(total, 2);
            lblTotal_Exp_Amt1.Text = Convert.ToString(total);
            lblTotal_Exp_Amt.Text = Convert.ToString(total);
            #endregion
            #region Denomination
            int thou = 0, Fivehun = 0, hund = 0, fiftys = 0, twenty = 0, tens = 0, Fives = 0, twos = 0, ones = 0, coins = 0;
            decimal thou_t = 0, Fivehun_t = 0, hund_t = 0, fiftys_t = 0, twenty_t = 0, tens_t = 0, Fives_t = 0, twos_t = 0, ones_t = 0;
            double coins_t = 0;
            DataSet ds_denomination = objbs.check_denomination(sTableName, dt);
            if (ds_denomination.Tables[0].Rows.Count > 0)
            {
                lbl2000_no.Text = ds_denomination.Tables[0].Rows[0]["Thousands"].ToString();
                thou = Convert.ToInt32(lbl2000_no.Text);
                thou_t = 2000 * thou;
                thou_t = Math.Round(thou_t, 2);
                lbl2000s.Text = Convert.ToString(thou_t);

                lbl500s_no.Text = ds_denomination.Tables[0].Rows[0]["FiveHundreds"].ToString();
                Fivehun = Convert.ToInt32(lbl500s_no.Text);
                Fivehun_t = 500 * Fivehun;
                Fivehun_t = Math.Round(Fivehun_t, 2);
                lbl500s.Text = Convert.ToString(Fivehun_t);

                lbl100s_no.Text = ds_denomination.Tables[0].Rows[0]["Hundreds"].ToString();
                hund = Convert.ToInt32(lbl100s_no.Text);
                hund_t = 100 * hund;
                hund_t = Math.Round(hund_t, 2);
                lbl100s.Text = Convert.ToString(hund_t);

                lbl50s_no.Text = ds_denomination.Tables[0].Rows[0]["Fiftys"].ToString();
                fiftys = Convert.ToInt32(lbl50s_no.Text);
                fiftys_t = 50 * fiftys;
                fiftys_t = Math.Round(fiftys_t, 2);
                lbl50s.Text = Convert.ToString(fiftys_t);

                lbl20s_no.Text = ds_denomination.Tables[0].Rows[0]["Twentys"].ToString();
                twenty = Convert.ToInt32(lbl20s_no.Text);
                twenty_t = 20 * twenty;
                twenty_t = Math.Round(twenty_t, 2);
                lbl20s.Text = Convert.ToString(twenty_t);

                lbl10s_no.Text = ds_denomination.Tables[0].Rows[0]["Tens"].ToString();
                tens = Convert.ToInt32(lbl10s_no.Text);
                tens_t = 10 * tens;
                tens_t = Math.Round(tens_t, 2);
                lbl10s.Text = Convert.ToString(tens_t);

                lbl5s_no.Text = ds_denomination.Tables[0].Rows[0]["Fives"].ToString();
                Fives = Convert.ToInt32(lbl5s_no.Text);
                Fives_t = 5 * Fives;
                Fives_t = Math.Round(Fives_t, 2);
                lbl5s.Text = Convert.ToString(Fives_t);

                lbl2s_no.Text = ds_denomination.Tables[0].Rows[0]["Twos"].ToString();
                twos = Convert.ToInt32(lbl2s_no.Text);
                twos_t = 2 * twos;
                twos_t = Math.Round(twos_t, 2);
                lbl2s.Text = Convert.ToString(twos_t);

                lbl1s_no.Text = ds_denomination.Tables[0].Rows[0]["ones"].ToString();
                ones = Convert.ToInt32(lbl1s_no.Text);
                ones_t = 1 * ones;
                ones_t = Math.Round(ones_t, 2);
                lbl1s.Text = Convert.ToString(ones_t);

                lblcoinss_no.Text = ds_denomination.Tables[0].Rows[0]["Coins"].ToString();
                coins = Convert.ToInt32(lblcoinss_no.Text);
                double coin_d = Convert.ToDouble(coins);
                coins_t = (1) * coin_d;
                coins_t = Math.Round(coins_t, 2);
                lblcoinss.Text = Convert.ToString(coins_t);

                total_denomination = Convert.ToDecimal(ds_denomination.Tables[0].Rows[0]["Total"].ToString());
                total_denomination = Math.Round(total_denomination, 2);
                lblTotal_Denominations.Text = Convert.ToString(total_denomination);

            }
            else
            {

                lbl2000_no.Text = "0";

                lbl2000s.Text = "0.00";

                lbl500s_no.Text = "0";

                lbl500s.Text = "0.00";

                lbl100s_no.Text = "0";

                lbl100s.Text = "0.00";

                lbl50s_no.Text = "0";

                lbl50s.Text = "0.00";

                lbl20s_no.Text = "0";

                lbl20s.Text = "0.00";

                lbl10s_no.Text = "0";

                lbl10s.Text = "0.00";

                lbl5s_no.Text = "0";
                lbl5s.Text = "0.00";

                lbl2s_no.Text = "0";
                lbl2s.Text = "0.00";

                lbl1s_no.Text = "0";
                lbl1s.Text = "0.00";

                lblcoinss_no.Text = "0";
                lblcoinss.Text = "0.00";

                lblTotal_Denominations.Text = "0";
                lblErr.Text = "No Denominations Updated Today!!";
            }
            #endregion
            #region Cash flow
            decimal dCreditCardSale = Convert.ToDecimal(lblCreditcard_Sales.Text);
            OP_cash = Convert.ToDecimal(lblOP_Cash_Amt.Text);
            OP_cash = Math.Round(OP_cash, 2);
            total_denomination = Convert.ToDecimal(lblTotal_Denominations.Text);
            total_denomination = Math.Round(total_denomination, 2);
            cash_handover = Convert.ToDecimal(lblCash_handover_amt.Text);
            cash_handover = Math.Round(cash_handover, 2);
            lblCash_Closing_Amt.Text = Convert.ToString(total_denomination - cash_handover);
            Closing_cash = Convert.ToDecimal(lblCash_Closing_Amt.Text);
            Closing_cash = Math.Round(Closing_cash, 2);
            tot_grosssales = cash_handover + Closing_cash + total  + dCreditCardSale;
            tot_grosssales = Math.Round(tot_grosssales, 2);
            lblSales_Gross_amt.Text = tot_grosssales.ToString();
            net_sales = (tot_grosssales - OP_cash);
            net_sales = Math.Round(net_sales, 2);
            lblNet_Sales_Amt.Text = net_sales.ToString();
            lblSales_Result_amt.Text = (gross - net_sales).ToString();
            #endregion
            #region SD
            datebar_SD = Math.Round(datebar_SD, 2);
            lblDate_Bar_amt.Text = Convert.ToString(datebar_SD);
            missing_SD = Math.Round(missing_SD, 2);
            lblMissing_amt.Text = Convert.ToString(missing_SD);
            //lblCompliment_salesdeduction_amt.Text = Convert.ToString(compli_SD);
            waste_SD = Math.Round(waste_SD, 2);
            lblWastage_amt.Text = Convert.ToString(waste_SD);
            NP_SD = Math.Round(NP_SD, 2);
            lblNP_Byepass_amt.Text = Convert.ToString(NP_SD);
            Damage_SD = Math.Round(Damage_SD, 2);
            lblDamage_amt.Text = Convert.ToString(Damage_SD);
            Change_SD = Math.Round(Change_SD, 2);
            lblProduct_change_amt.Text = Convert.ToString(Change_SD);
            BNP_SD = Math.Round(BNP_SD, 2);
            lblBNP_Byepass_amt.Text = Convert.ToString(BNP_SD);
            bbkulam = Math.Round(bbkulam, 2);
            bbkulamamount.Text = Convert.ToString(bbkulam);
            //SD_Total = SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD + bbkulam + excess; ;
            //commented by pratheep
            SD_Total = SD_Total = datebar_SD + missing_SD + compli_SD + waste_SD + NP_SD + Damage_SD + Change_SD + BNP_SD + excess; 
            SD_Total = Math.Round(SD_Total, 2);
            lblSales_deductions_amt.Text = Convert.ToString(SD_Total);
            lblSales_Deduction_amt1.Text = Convert.ToString(SD_Total);
            #endregion
            #region SF
            //sales = cash + credit + card + compli;
            //commented by prathep - 23 oct
            sales = cash + compli;
            sales = Math.Round(sales, 2);
            lbl_Total_Sales_Amt.Text = Convert.ToString(sales);
            gross = sales - card - SD_Total;
            gross = Math.Round(gross, 2);
           // lblGross_sales_amt.Text = Convert.ToString(gross);
            lblSales_Result_amt.Text = ( net_sales-sales).ToString();
            #endregion
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
            body = body.Replace("{lblCash_handover_amt}", lblCash_handover_amt.Text);
            body = body.Replace("{lblCash_Closing_Amt}", lblCash_Closing_Amt.Text);
            body = body.Replace("{lblTotal_Exp_Amt}", lblTotal_Exp_Amt.Text);
            body = body.Replace("{lblCredit_Sales_Amt}", lblCredit_Sales_Amt.Text);
            body = body.Replace("{lblSales_Gross_amt}", lblSales_Gross_amt.Text);
            body = body.Replace("{lblOP_Cash_Amt}", lblOP_Cash_Amt.Text);
            body = body.Replace("{lblNet_Sales_Amt}", lblNet_Sales_Amt.Text);
            body = body.Replace("{lblSales_Result_amt}", lblSales_Result_amt.Text);
            body=body.Replace("{lblCreditcard_Sales}",lblCreditcard_Sales.Text);

            body = body.Replace("{lblCash_sales_Amt}", lblCash_sales_Amt.Text);
           
            body = body.Replace("{lblOrder_sales_amt}", lblOrder_sales_amt.Text);
            body = body.Replace("{lbl_Total_Sales_Amt}", lbl_Total_Sales_Amt.Text);
            body = body.Replace("{lblExcess}", lblExcess.Text);
            
            body = body.Replace("{lblSales_deductions_amt}", lblSales_deductions_amt.Text);
          //  body = body.Replace("{lblGross_sales_amt}", lblGross_sales_amt.Text);
            body = body.Replace("{lblErr}", lblErr.Text);

            body = body.Replace("{lbl1000_no}", lbl2000_no.Text);
            body = body.Replace("{lbl1000s}", lbl2000s.Text);
            body = body.Replace("{lbl500s_no}", lbl500s_no.Text);
            body = body.Replace("{lbl500s}", lbl500s.Text);
            body = body.Replace("{lbl100s_no}", lbl100s_no.Text);
            body = body.Replace("{lbl100s}", lbl100s.Text);
            body = body.Replace("{lbl50s_no}", lbl50s_no.Text);
            body = body.Replace("{lbl50s}", lbl50s.Text);
            body = body.Replace("{lbl20s_no}", lbl20s_no.Text);
            body = body.Replace("{lbl20s}", lbl20s.Text);
            body = body.Replace("{lbl10s_no}", lbl10s_no.Text);
            body = body.Replace("{lbl10s}", lbl10s.Text);
            body = body.Replace("{lbl5s_no}", lbl5s_no.Text);
            body = body.Replace("{lbl5s}", lbl5s.Text);
            body = body.Replace("{lbl2s_no}", lbl2s_no.Text);
            body = body.Replace("{lbl2s}", lbl2s.Text);
            body = body.Replace("{lbl1s_no}", lbl1s_no.Text);
            body = body.Replace("{lbl1s}", lbl1s.Text);
            body = body.Replace("{lblcoinss_no}", lblcoinss_no.Text);
            body = body.Replace("{lblcoinss}", lblcoinss.Text);
            body = body.Replace("{lblTotal_Denominations}", lblTotal_Denominations.Text);


            //if (DDlbranch.SelectedValue == "1")
            //{
            //    sTableName = "CO1";
            //}
            //else if (DDlbranch.SelectedValue == "2")
            //{
            //    sTableName = "CO2";
            //}
            //else if (DDlbranch.SelectedValue == "3")
            //{
            //    sTableName = "CO3";
            //}
            //else if (DDlbranch.SelectedValue == "4")
            //{
            //    sTableName = "CO4";
            //}
            //else if (DDlbranch.SelectedValue == "6")
            //{
            //    sTableName = "CO6";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "7")
            //{
            //    sTableName = "CO7";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "5")
            //{
            //    sTableName = "CO5";
            //}

            //else if (DDlbranch.SelectedValue == "8")
            //{
            //    sTableName = "CO8";
            //}
            //else if (DDlbranch.SelectedValue == "9")
            //{
            //    sTableName = "CO9";
            //}


            //else if (DDlbranch.SelectedValue == "10")
            //{
            //    sTableName = "CO10";
            //}
            //else if (DDlbranch.SelectedValue == "11")
            //{
            //    sTableName = "CO11";
            //}
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
            body = body.Replace("{lblTotal_Exp_Amt1}", lblTotal_Exp_Amt1.Text);


            body = body.Replace("{lblDate_Bar_amt}", lblDate_Bar_amt.Text);
            body = body.Replace("{lblMissing_amt}", lblMissing_amt.Text);
            body = body.Replace("{lblCompliment_salesdeduction_amt}", lblCompliment_salesdeduction_amt.Text);
            body = body.Replace("{lblWastage_amt}", lblWastage_amt.Text);
            //body = body.Replace("{lblNP_Byepass_amt}", lblNP_Byepass_amt.Text);
            body = body.Replace("{lblDamage_amt}", lblDamage_amt.Text);
            body = body.Replace("{lblExcess}", lblExcess.Text);
            body = body.Replace("{lblProduct_change_amt}", lblProduct_change_amt.Text);
            //body = body.Replace("{lblBNP_Byepass_amt}", lblBNP_Byepass_amt.Text);
            body = body.Replace("{bbkulamamount}", bbkulamamount.Text);
            body = body.Replace("{lblSales_Deduction_amt1}", lblSales_Deduction_amt1.Text);




            return body;
        }

        private string Expenses(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/Expenses.htm")))
            {
                body = reader.ReadToEnd();
            }
            


            //if (DDlbranch.SelectedValue == "1")
            //{
            //    sTableName = "CO1";
            //}
            //else if (DDlbranch.SelectedValue == "2")
            //{
            //    sTableName = "CO2";
            //}
            //else if (DDlbranch.SelectedValue == "3")
            //{
            //    sTableName = "CO3";
            //}
            //else if (DDlbranch.SelectedValue == "4")
            //{
            //    sTableName = "CO4";
            //}
            //else if (DDlbranch.SelectedValue == "6")
            //{
            //    sTableName = "CO6";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "7")
            //{
            //    sTableName = "CO7";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "5")
            //{
            //    sTableName = "CO5";
            //}
            //else if (DDlbranch.SelectedValue == "8")
            //{
            //    sTableName = "CO8";
            //}
            //else if (DDlbranch.SelectedValue == "9")
            //{
            //    sTableName = "CO9";
            //}

            //else if (DDlbranch.SelectedValue == "10")
            //{
            //    sTableName = "CO10";
            //}
            //else if (DDlbranch.SelectedValue == "11")
            //{
            //    sTableName = "CO11";
            //}
            string content = string.Empty;

            DataSet ds = objbs.paymentgrid_Report(sTableName, date.Text);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    content = content + "<tr><td> " + ds.Tables[0].Rows[a]["LedgerName"].ToString() + "</td><td>" + Convert.ToDecimal(ds.Tables[0].Rows[a]["Amount"]).ToString("f2") + "</td></tr>";
                }
            }

            body = body.Replace("{lblTotal_Exp}", content);
            body = body.Replace("{lblTotal_Exp_Amt1}", lblTotal_Exp_Amt1.Text);


          




            return body;
        }


        private string BreadList(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/breadlist.htm")))
            {
                body = reader.ReadToEnd();
            }



            //if (DDlbranch.SelectedValue == "1")
            //{
            //    sTableName = "CO1";
            //}
            //else if (DDlbranch.SelectedValue == "2")
            //{
            //    sTableName = "CO2";
            //}
            //else if (DDlbranch.SelectedValue == "3")
            //{
            //    sTableName = "CO3";
            //}
            //else if (DDlbranch.SelectedValue == "4")
            //{
            //    sTableName = "CO4";
            //}
            //else if (DDlbranch.SelectedValue == "6")
            //{
            //    sTableName = "CO6";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "7")
            //{
            //    sTableName = "CO7";
            //    // DDlbranch.Enabled = false;
            //}
            //else if (DDlbranch.SelectedValue == "5")
            //{
            //    sTableName = "CO5";
            //}
            //else if (DDlbranch.SelectedValue == "8")
            //{
            //    sTableName = "CO8";
            //}
            //else if (DDlbranch.SelectedValue == "9")
            //{
            //    sTableName = "CO9";
            //}

            //else if (DDlbranch.SelectedValue == "10")
            //{
            //    sTableName = "CO10";
            //}
            //else if (DDlbranch.SelectedValue == "11")
            //{
            //    sTableName = "CO11";
            //}
            string content = string.Empty;

            DataSet ds = objbs.BreadList(branchcode);
            int count = ds.Tables[0].Rows.Count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                {
                    content = content + "<tr><td> " + ds.Tables[0].Rows[a]["Category"].ToString() + "</td><td> " + ds.Tables[0].Rows[a]["Definition"].ToString() + "</td><td> " + ds.Tables[0].Rows[a]["Order_Qty"].ToString() + "</td></tr>";
                }
            }

            body = body.Replace("{lblTotal_Exp}", content);
          







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
                //this.SendHtmlFormattedEmail("blaackforestreports@gmail.com", "nknavaneethan4u@gmail.com ", "Daily Expenses (" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Exp, "bfkknagr@gmail.com", "bfnpuram@gmail.com", "bfbypass@gmail.com", "bfbbkulam@gmail.com", "bfpalayankottai@gmail.com");
         //   }
                 
         //   else 
         //   {
             //   this.SendHtmlFormattedEmail("nknavaneethan4u@gmail.com ", "nknavaneethan4u@gmail.com ", "Daily Report (" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", body, "bfkknagr@gmail.com", "bfnpuram@gmail.com", "bfbypass@gmail.com", "bfbbkulam@gmail.com", "bfpalayankottai@gmail.com");
               // this.SendHtmlFormattedEmail("blaackforestreports@gmail.com", "nknavaneethan4u@gmail.com ", "Daily Expenses (" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Exp, "bfkknagr@gmail.com", "bfnpuram@gmail.com", "bfbypass@gmail.com", "bfbbkulam@gmail.com", "bfpalayankottai@gmail.com");
                //this.SendBreadList("harishbabu.jg@gmail.com", "", "Daily Stock Request(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread, "bfkknagr@gmail.com", "bfnpuram@gmail.com", "bfbypass@gmail.com", "bfbbkulam@gmail.com");
          //  }


            //if (branchcode == "NE")
            //{
            //    this.SendBreadList("bfpalayankottai@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //}
            //if (branchcode == "KK")
            //{
            //    this.SendBreadList("bfkknagar@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //}
            //if (branchcode == "NP")
            //{
            //    this.SendBreadList("bfnpuram@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //}
            //if (branchcode == "BY")
            //{
            //    this.SendBreadList("bfbypass@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //}
            //            if (branchcode == "BB")
            //            {
            //                this.SendBreadList("bfbbkulam@gmail.com", "bfmduproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //            }

            //            if (branchcode == "MD")
            //            {
            //                this.SendBreadList("bfmaduravayol@gmail.com", "bfchennaiproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //            }

            //            if (branchcode == "PU")
            //            {
            //                this.SendBreadList("bfmaduravayol@gmail.com", "bfchennaiproduction@gmail.com", "Daily Stock Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", Bread);
            //            }

            //this.SendHtmlFormattedEmail("pratheep.kumar@gmail.com", "harishbabu.jg@gmail.com", "Daily Report(" + Convert.ToDateTime(date.Text).ToString("dd-MM-yyyy") + ") - Store: " + DDlbranch.SelectedItem.Text + " ", body);

                        

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);
        }


        private void SendHtmlFormattedEmail(string recepientEmail,string cc, string subject, string body,string a,string b,string c,string d,string e)
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
                smtp.UseDefaultCredentials = true;
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
                smtp.UseDefaultCredentials = true;
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
           // string time = DateTime.Now.ToString();

           // DateTime dat = DateTime.Parse(time);
           // var hour = dat.ToString("HH");
           // var min = dat.ToString("mm");
           // var current = hour + "." + min;

           // //if (double.Parse(current) >= 22.00)
           // //{
           //     if (txtnam.Text == "")
           //     {
           //         ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "shw();", true);
           //     }
           //     else
           //     {

           //         objbs.dayclosername(txtnam.Text, Convert.ToInt32(lblUserID.Text));
           //         DataSet ch = objbs.checkinser(sTableName);
           //         if (ch.Tables[0].Rows.Count > 0)
           //         {
           //             objbs.delOpening(sTableName);
           //             int transfer = objbs.insertselect(sTableName);
           //         }
           //         else
           //         {
           //             int transfer = objbs.insertselect(sTableName);
           //         }
           //         // int closr = objbs.updatedayclose(Convert.ToInt32(lblUserID.Text), DateTime.Now.ToShortDateString());
           //         ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);

           //         if (date.Text != DateTime.Today.ToString("yyyy-MM-dd"))
           //         {
           //             Response.Redirect("../Accountsbootstrap/newbutton.aspx");
           //         }

                   
           //     }
           //// }
           // //else
           // //{
           // //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('sorry its not a valid Time')", true);
           // //}


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
            if (sTableName != "admin")
            {
                DateTime dat = Convert.ToDateTime(date.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var days = dat.Day;
                var toda = Toady.Day;

                if ((toda - days) <= 2)
                {

                }

                else
                {
                    date.Text = "";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet ch = objbs.SessionClose(sTableName, DateTime.Now.ToString("yyyy-MM-dd"), txtName.Text);

            Response.Redirect("Login_Branch.aspx"); 
        }

    

       

    }
}