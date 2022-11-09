using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class DayBook : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        decimal totalDebit = 0;
        decimal totalCredit = 0;
        int totalItems = 0;
        string sAdmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sAdmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            if (!IsPostBack)
            {
                

                if (sAdmin == "1")
                {
                    leg.Visible = true;
                }
                   
                else
                {
                    leg.Visible = false;
                    DataSet dTotal = objBs.DaydookTotal(sTableName);
                    if (dTotal.Tables[0].Rows.Count > 0)
                     
                    {
                        if (dTotal.Tables[0].Rows[0]["Credit"].ToString() != "")
                        {
                            decimal dCredit = Convert.ToDecimal(dTotal.Tables[0].Rows[0]["Credit"].ToString());
                        }
                        // lblcredit.InnerText =decimal.Round(dCredit,2).ToString("f2") ;
                        if (dTotal.Tables[0].Rows[0]["Debit"].ToString() != "")
                        {
                            decimal dDebit = Convert.ToDecimal(dTotal.Tables[0].Rows[0]["Debit"].ToString());
                        }
                        // lbldebit.InnerText =decimal.Round(dDebit,2).ToString("f2") ;
                    }
                    else 
                    {
                        Response.Write("No Day Book Transactions");
                    }
                }
            if (sAdmin == "1")
            {
                DataSet dadmin = objBs.AdminDaydookReport();
                if (dadmin.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dadmin.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                    {
                        dDebitClosing = dCreditTotal - dDebitTotal;
                       
                    }
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound =Convert.ToDecimal( dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);
                    // objBs.GetDescription(Convert.ToInt32( dDaybook.Tables[0].Rows[0]["Description"].ToString()));
                    gvdaybook.DataSource = dadmin;
                    gvdaybook.DataBind();
                }
            }
            else
            {
                DataSet dDaybook = objBs.DaydookReport(sTableName);
                if (dDaybook.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dDaybook.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dDaybook.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dDaybook.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                    {
                        dDebitClosing = dCreditTotal - dDebitTotal;
                        
                    }
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound = Convert.ToDecimal(dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);
                    // objBs.GetDescription(Convert.ToInt32( dDaybook.Tables[0].Rows[0]["Description"].ToString()));
                    gvdaybook.DataSource = dDaybook;
                    gvdaybook.DataBind();
                }
            }
           

              
            }
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {

            if (sAdmin == "1")
            {
                DataSet dOutlet = objBs.GetOutletDaybook(Convert.ToString(ddloutlet.SelectedItem));
                if (dOutlet.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dOutlet.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dOutlet.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dOutlet.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                        dDebitClosing = dCreditTotal - dDebitTotal;
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound = Convert.ToDecimal(dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);

                    gvdaybook.DataSource = dOutlet;
                    gvdaybook.DataBind();
                }
            }
        }

        protected void btngen_Click(object sender, EventArgs e)
        {
            if (sAdmin == "1")
            {
                DataSet dadmin = objBs.AdminLedgerExpense(txtfromdate.Text, txttodate.Text);
                if (dadmin.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dadmin.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                        dDebitClosing = dCreditTotal - dDebitTotal;
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound = Convert.ToDecimal(dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);
                    gvdaybook.DataSource = dadmin;
                    gvdaybook.DataBind();
                }
            }
            else
            {

                DataSet dGen = objBs.GenLedgerExpense(txtfromdate.Text, txttodate.Text, sTableName, Convert.ToInt32(lblUserID.Text));
                if (dGen.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dGen.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dGen.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dGen.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                        dDebitClosing = dCreditTotal - dDebitTotal;
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound = Convert.ToDecimal(dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);
                    gvdaybook.DataSource = dGen;
                    gvdaybook.DataBind();
                }
            }
            
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            if (sAdmin == "1")
            {
                DataSet dadmin = objBs.AdminDaydookReport();
                if (dadmin.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dadmin.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                        dDebitClosing = dCreditTotal - dDebitTotal;
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound = Convert.ToDecimal(dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);
                    // objBs.GetDescription(Convert.ToInt32( dDaybook.Tables[0].Rows[0]["Description"].ToString()));
                    gvdaybook.DataSource = dadmin;
                    gvdaybook.DataBind();
                }
            }
            else
            {
                DataSet dDaybook = objBs.DaydookReport(sTableName);
                if (dDaybook.Tables[0].Rows.Count > 0)
                {
                    // objBs.GetDescription(Convert.ToInt32( dDaybook.Tables[0].Rows[0]["Description"].ToString()));
                    gvdaybook.DataSource = dDaybook;
                    gvdaybook.DataBind();
                }

            }
        }

        protected void gvdaybook_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDebitPrice = (Label)e.Row.FindControl("lblDebitPrice");
                Label lblCreditPrice = (Label)e.Row.FindControl("lblCreditPrice");
                if (lblDebitPrice.Text == "")
                    lblDebitPrice.Text = "0";
                else
                {
                    decimal dDebit = Decimal.Parse(lblDebitPrice.Text);
                    totalDebit += dDebit;
                }
                if (lblCreditPrice.Text == "")
                    lblCreditPrice.Text = "0";
                else
                {
                    decimal dCredit = Decimal.Parse(lblCreditPrice.Text);
                    totalCredit += dCredit;
                }
                //totalDebit += dDebit;
               // totalCredit += dCredit;

                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbldebit = (Label)e.Row.FindControl("lbldebit");
                Label lblcredit = (Label)e.Row.FindControl("lblcredit");
                //Label lbldebit1 = (Label)e.Row.FindControl("lbldebit1");
                //Label lblcredit1 = (Label)e.Row.FindControl("lblcredit1");

                lbldebit.Text = totalDebit.ToString();
                lblcredit.Text = totalCredit.ToString();

                //lbldebit1.Text = totalDebit.ToString();
                //lblcredit1.Text = totalCredit.ToString();

                //lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            } 
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            if (sAdmin == "1")
            {
                DataSet dadmin = objBs.AdminDaydookReport();
                if (dadmin.Tables[0].Rows.Count > 0)
                {
                    double dDebitTotal = 0, dCreditTotal = 0, dDebitClosing = 0, dCreditClosing = 0;
                    for (int i = 0; i < dadmin.Tables[0].Rows.Count; i++)
                    {
                        dDebitTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Debit"].ToString());
                        dCreditTotal += Convert.ToDouble(dadmin.Tables[0].Rows[i]["Credit"].ToString());


                    }
                    if (dDebitTotal < dCreditTotal)
                        dDebitClosing = dCreditTotal - dDebitTotal;
                    else
                        dCreditClosing = dDebitTotal - dCreditTotal;

                    lblDebitTotal.Text = Convert.ToString(dDebitTotal);
                    lblCreditTotal.Text = Convert.ToString(dCreditTotal);
                    lblCreditClosingTotal.Text = Convert.ToString(dCreditClosing);
                    decimal dRound = Convert.ToDecimal(dDebitClosing);
                    lblDebitClosingTotal.Text = decimal.Round(dRound, 2).ToString("f2");
                    double dNetCreditCalc = dCreditTotal + dCreditClosing;
                    double dNetDebitCalc = dDebitTotal + dDebitClosing;
                    lblNetCredit.Text = Convert.ToString(dNetCreditCalc);
                    lblNetDebit.Text = Convert.ToString(dNetDebitCalc);
                    // objBs.GetDescription(Convert.ToInt32( dDaybook.Tables[0].Rows[0]["Description"].ToString()));
                    gvdaybook.DataSource = dadmin;
                    gvdaybook.DataBind();
                }
            }
        }

        protected void BindGridview()
        {
            DataSet dadmin = objBs.AdminDaydookReport();
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            GridView gvdaybook = new GridView();
            gvdaybook.DataSource = objBs.AdminDaydookReport(); ;
            gvdaybook.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=DayBookReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gvdaybook.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
          
        }
    }
}