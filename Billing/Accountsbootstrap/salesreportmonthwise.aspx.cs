using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class salesreportmonthwise : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

           

            if (!IsPostBack)
            {

                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString();
                txtfromdate.Text = DateTime.Today.ToShortDateString();

                //DataSet dsbranch = objbs.selectbranchmaster();
                //if (dsbranch.Tables[0].Rows.Count > 0)
                //{
                //    ddlBranch.DataSource = dsbranch.Tables[0];
                //    ddlBranch.DataTextField = "BranchCode";
                //    ddlBranch.DataValueField = "UserID";
                //    ddlBranch.DataBind();
                //   // ddlBranch.Items.Insert(0, "Select Branch");
                //    //ddlcategory.Items.Insert(0, "Select Category");

                //}
                if (sadmin == "1")
                {
                    ddlBranch.Enabled = true;
                    DataSet dsbranchto = objbs.Branchto();
                    ddlBranch.DataSource = dsbranchto.Tables[0];
                    ddlBranch.DataTextField = "branchcode";
                    ddlBranch.DataValueField = "Userid";
                    ddlBranch.DataBind();
                    //  ddlBranch.Items.Insert(0, "All");
                }
                else
                {
                    DataSet dsbranch = new DataSet();
                    string stable = "tblSales_" + sTableName + "";
                    dsbranch = objbs.Branchfrom(lblUserID.Text);
                    ddlBranch.DataSource = dsbranch.Tables[0];
                    ddlBranch.DataTextField = "branchcode";
                    ddlBranch.DataValueField = "Userid";
                    ddlBranch.DataBind();
                    ddlBranch.Enabled = false;
                }

            
                
                    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];
                        if (brach == "CO1")
                        {
                            Label123.Text = "Blaack Forest Bakery Services";
                        }
                        else if (brach == "CO2")
                        {
                            Label123.Text = "Blaack Forest Bakery Services";
                        }
                        else if (brach == "CO3")
                        {
                            Label123.Text = "Shiva Delights";
                        }
                        else if (brach == "CO4")
                        {
                            Label123.Text = "Fig and honey";
                        }
                        else if (brach == "CO5")
                        {
                            Label123.Text = "Blaack Forest Bakery Services";
                        }

                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(sTableName, txtfromdate.Text, txttodate.Text);
                        //      DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        //     DateTime sTo = Convert.ToDateTime(txttodate.Text);

                        //     DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                        //if (dcustbranch.Tables[0].Rows.Count > 0)
                        //{
                        //    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                        //}

                        //  gvCustsales.DataSource = dcustbranch.Tables[0];

                        //  gvCustsales.DataBind();
                        //decimal dtotal = 0;
                        //for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        //{
                        //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
                        //}
                        //decimal Total = dtotal;
                        //lblTotal.InnerText = Total.ToString();
                        //  btnall_Click( sender, Even e)
                    }



                }
            }
        


        protected void drptype_selectedindex(object sender, EventArgs e)
        {
            if (drptype.SelectedItem.Value == "1")
            {
                DateTime dayy = Convert.ToDateTime(txtfromdate.Text);
                DayOfWeek day = dayy.DayOfWeek;
                int days = day - DayOfWeek.Monday;
              
                // DateTime start = DateTime.Now.AddDays(-days);
                DateTime start = dayy.AddDays(-days); //DateTime.Now.AddDays(-days);
                DateTime end = start.AddDays(6);

                  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                //if (txtfromdate.Text > txttodate.Text)
                //{

                //}

                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }

                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, start, end);


                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();


                }
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[1].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();


            }
            else if (drptype.SelectedItem.Value == "2")
            {
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                //if (txtfromdate.Text > txttodate.Text)
                //{

                //}

                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }

                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);


                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();
                }
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[1].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
            }
            else if (drptype.SelectedItem.Value == "3")
            {
                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                DataSet dcustbranch = new DataSet();
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                    DataSet ds = new DataSet();
                    string month = string.Empty;

                    DataSet dparent = new DataSet();

                    DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                    DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //  month = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);







                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    //    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);





                    gvCustsales.DataSource = dparent.Tables[0];
                    gvCustsales.DataBind();




                }
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[1].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
            }
            else if (drptype.SelectedItem.Value == "4")
            {
                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                DataSet dcustbranch = new DataSet();
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                    DataSet ds = new DataSet();
                    string month = string.Empty;

                    DataSet dparent = new DataSet();

                    DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                    DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //  month = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);







                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    //    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);





                    gvCustsales.DataSource = dparent.Tables[0];
                    gvCustsales.DataBind();
                }
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[1].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
            }
            else
            {
                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                DataSet dcustbranch = new DataSet();
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                    DataSet ds = new DataSet();
                    string month = string.Empty;

                    DataSet dparent = new DataSet();

                    DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                    DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //  month = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);


                    gvCustsales.DataSource = dparent.Tables[0];
                    gvCustsales.DataBind();
                }
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[1].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            //if (txtfromdate.Text > txttodate.Text)
            //{

            //}

            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];
                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = DateTime.Now;

                DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                }

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();
                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                // tot = Convert.ToDouble(Total);
            }
            //decimal dtotal = 0;
            //for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //{
            //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
            //}
            //decimal Total = dtotal;
            //lblTotal.InnerText = Total.ToString();
            //tot = Convert.ToDouble(Total);

            //DataSet dcustbranch = objbs.CustomerSalesBranch(ddlBranch.SelectedValue);
            //gvCustsales.DataSource = dcustbranch.Tables[0];
            //gvCustsales.DataBind();
        }



        protected void btnall_Click(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);






            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];
                string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                //DataSet dcustbranch = objbs.CustomerSaleshourreport(brach, sFrom, dstime, detime);
                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{
                //    gvCustsales.DataSource = dcustbranch.Tables[0];
                //    gvCustsales.DataBind();
                //}



                //decimal dtotal = 0;
                //for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //{
                //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
                //}
                //decimal Total = dtotal;
                //lblTotal.InnerText = Total.ToString();
                //tot = Convert.ToDouble(Total);



            }
        }


        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            DataSet dCustReport = objbs.CustomerSalesAdmin();
            gvCustsales.DataSource = dCustReport.Tables[0];
            gvCustsales.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (drptype.SelectedItem.Value == "1")
            {
                DateTime dayy = Convert.ToDateTime(txtfromdate.Text);
                DayOfWeek day = dayy.DayOfWeek;
                int days = day - DayOfWeek.Monday;

                // DateTime start = DateTime.Now.AddDays(-days);
                DateTime start = dayy.AddDays(-days); //DateTime.Now.AddDays(-days);
                DateTime end = start.AddDays(6);

                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                //if (txtfromdate.Text > txttodate.Text)
                //{

                //}

                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }

                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, start, end);


                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();

                    string filename = "salesreport.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dcustbranch.Tables[0];
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    dgGrid.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

                }
               


            }
            else if (drptype.SelectedItem.Value == "2")
            {
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                //if (txtfromdate.Text > txttodate.Text)
                //{

                //}

                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);


                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();

                    string filename = "salesreport.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dcustbranch.Tables[0];
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    dgGrid.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
                
            }
            else if (drptype.SelectedItem.Value == "3")
            {
                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                DataSet dcustbranch = new DataSet();
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                    DataSet ds = new DataSet();
                    string month = string.Empty;

                    DataSet dparent = new DataSet();

                    DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                    DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //  month = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);







                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    //    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);





                    gvCustsales.DataSource = dparent.Tables[0];
                    gvCustsales.DataBind();

                    string filename = "salesreport.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dparent.Tables[0];
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    dgGrid.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();


                }
                
            }
            else if (drptype.SelectedItem.Value == "4")
            {
                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                DataSet dcustbranch = new DataSet();
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                    DataSet ds = new DataSet();
                    string month = string.Empty;

                    DataSet dparent = new DataSet();

                    DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                    DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //  month = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);







                    //     DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    //    DateTime sTo = DateTime.Now;

                    //    DataSet dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);





                    gvCustsales.DataSource = dparent.Tables[0];
                    gvCustsales.DataBind();

                    string filename = "salesreport.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dparent.Tables[0];
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    dgGrid.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
               
            }
            else
            {
                int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                DataSet dcustbranch = new DataSet();
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    if (brach == "CO1")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO2")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    else if (brach == "CO3")
                    {
                        Label123.Text = "Shiva Delights";
                    }
                    else if (brach == "CO4")
                    {
                        Label123.Text = "Fig and honey";
                    }
                    else if (brach == "CO5")
                    {
                        Label123.Text = "Blaack Forest Bakery Services";
                    }
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                    DataSet ds = new DataSet();
                    string month = string.Empty;

                    DataSet dparent = new DataSet();

                    DateTime firstDayOfTheMonth = new DateTime(sFrom.Year, sFrom.Month, 1);
                    DateTime endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //  month = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);

                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);
                    firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(1);
                    firstDayOfTheMonth = new DateTime(firstDayOfTheMonth.Year, firstDayOfTheMonth.Month, 1);
                    endDate = firstDayOfTheMonth.AddMonths(1).AddDays(-1);

                    //    string  month1 = firstDayOfTheMonth.ToString("MMMM");

                    dcustbranch = objbs.CustomerSalesmonthreport(brach, firstDayOfTheMonth, endDate);
                    dparent.Merge(dcustbranch);


                    gvCustsales.DataSource = dparent.Tables[0];
                    gvCustsales.DataBind();

                    string filename = "salesreport.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dparent.Tables[0];
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    dgGrid.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
                
            }
           
        }

        protected void gvcust_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            //if (SortOrder[0] == e.SortExpression)
            //{
            //    if (SortOrder[1] == "ASC")
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            //    }
            //    else
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //    }
            //}
            //else
            //{
            //    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //}
            //DataSet ds = objBs.CustomerReport(Convert.ToInt32(1));
            //DataView dvEmp = ds.Tables[0].DefaultView;
            //dvEmp.Sort = ViewState["SortExpr"].ToString();
            //gvcust.DataSource = dvEmp;
            //gvcust.DataBind();
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("customerupdate.aspx?iCusID=" + e.CommandArgument.ToString());

            //    }
            //}
        }
        //public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        //{


        //    //if (e.Row.RowType == DataControlRowType.DataRow)
        //    //{

        //    //}
        //    if (sadmin == "1")
        //    {

        //    }
        //    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
        //    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
        //    string name = string.Empty;



        //    if (dsbranch1.Tables[0].Rows.Count > 0)
        //    {
        //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
        //        string[] wordArray = sales.Split('_');

        //        brach = wordArray[1];


        //        if (brach == "CO1")
        //        {
        //            Label123.Text = "KKNagar";
        //            name = "KKNAGAR";

        //        }
        //        else if (brach == "CO2")
        //        {
        //            Label123.Text = "BYEPASS";
        //            name = "BYEPASS";
        //        }
        //        else if (brach == "CO3")
        //        {
        //            Label123.Text = "BBKULAM";
        //            name = "BBKULAM";
        //        }
        //        else if (brach == "CO4")
        //        {
        //            Label123.Text = "NARANAYAPURAM";
        //            name = "NARANAYAPURAM";
        //        }
        //    }


        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
        //        GridView gvGroup = (GridView)sender;
        //        if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
        //        {
        //            int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
        //            DataSet ds = objbs.CustomerSalesdetailedreport(groupID, brach);
        //            //if (ds.Tables[0].Rows.Count > 0)
        //            //{
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                gv.DataSource = ds;
        //                double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
        //                amount1 = amount1 + amount;
        //                gv.DataBind();
        //            }
        //            //}
        //        }

        //    }

        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        //        e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //        e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

        //        //e.Row.Cells[0].Text = "Total";
        //        //e.Row.Cells[1].Text = HorizontalAlign.Right;
        //        // e.Row.Cells[7].Text = tot.ToString("N2");
        //        //  e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

        //    }

        //}
    }
}