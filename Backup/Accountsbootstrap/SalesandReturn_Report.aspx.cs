using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace Billing.Accountsbootstrap
{
    public partial class SalesandReturn_Report : System.Web.UI.Page
    {

        BSClass objbs = new BSClass();
        string sTableName = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {

            }
        }


        protected void rbsales_CheckedChanged(object sender, EventArgs e)
        {
            rbstockreturn.Checked = false;
        }
        protected void rbstockreturn_CheckedChanged(object sender, EventArgs e)
        {
            rbsales.Checked = false;
        }

        protected void ddlType_Change(object sender, EventArgs e)
        {

            if (rbsales.Checked == true)
            {

                if (ddlType.SelectedValue == "Daywise")
                {


                    divfrm.Visible = false;
                    divto.Visible = false;
                    divbtn.Visible = false;

                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_Sales_Amount("Daywise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "Day";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "Amount";
                    dt.Columns.Add(dc);

                    if (dsFinal != null)
                    {
                        if (dsFinal.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();

                                if (dsFinal.Tables[0].Rows[i]["Day"].ToString() == dsFinal.Tables[0].Rows[i]["Day"].ToString())
                                {
                                    dr["Day"] = dsFinal.Tables[0].Rows[i]["Day"].ToString();
                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "Day";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_Sales_Quantity("Daywise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "Day";
                    dt1.Columns.Add(dc1);
                    dc1 = new DataColumn();
                    dc1.ColumnName = "Quantity";
                    dt1.Columns.Add(dc1);

                    if (dsFinalqty != null)
                    {
                        if (dsFinalqty.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt1.NewRow();

                                if (dsFinalqty.Tables[0].Rows[i]["Day"].ToString() == dsFinalqty.Tables[0].Rows[i]["Day"].ToString())
                                {
                                    dr["Day"] = dsFinalqty.Tables[0].Rows[i]["Day"].ToString();
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "Day";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion

                }

                else if (ddlType.SelectedValue == "Datewise")
                {
                    divfrm.Visible = true;
                    divto.Visible = true;
                    divbtn.Visible = true;

                }
                else if (ddlType.SelectedValue == "Weekwise")
                {

                    divfrm.Visible = false;
                    divto.Visible = false;
                    divbtn.Visible = false;

                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_Sales_Amount("Weekwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "RWeek";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "Amount";
                    dt.Columns.Add(dc);

                    if (dsFinal != null)
                    {
                        if (dsFinal.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();

                                if (dsFinal.Tables[0].Rows[i]["RWeek"].ToString() == dsFinal.Tables[0].Rows[i]["RWeek"].ToString())
                                {
                                    //dr["RWeek"] = dsFinal.Tables[0].Rows[i]["RWeek"].ToString();

                                    dr["RWeek"] = "Week" + (i + 1);

                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "RWeek";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_Sales_Quantity("Weekwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "RWeek";
                    dt1.Columns.Add(dc1);
                    dc1 = new DataColumn();
                    dc1.ColumnName = "Quantity";
                    dt1.Columns.Add(dc1);

                    if (dsFinalqty != null)
                    {
                        if (dsFinalqty.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt1.NewRow();

                                if (dsFinalqty.Tables[0].Rows[i]["RWeek"].ToString() == dsFinalqty.Tables[0].Rows[i]["RWeek"].ToString())
                                {
                                   // dr["RWeek"] = dsFinalqty.Tables[0].Rows[i]["RWeek"].ToString();
                                    dr["RWeek"] = "Week" + (i + 1);
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "RWeek";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion
                }

                else if (ddlType.SelectedValue == "Monthwise")
                {

                    divfrm.Visible = false;
                    divto.Visible = false;
                    divbtn.Visible = false;

                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_Sales_Amount("Monthwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "RMonth";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "Amount";
                    dt.Columns.Add(dc);

                    if (dsFinal != null)
                    {
                        if (dsFinal.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();

                                if (dsFinal.Tables[0].Rows[i]["RMonth"].ToString() == dsFinal.Tables[0].Rows[i]["RMonth"].ToString())
                                {
                                    int month=Convert.ToInt32(dsFinal.Tables[0].Rows[i]["RMonth"].ToString());
                                    if (month == 1)
                                        dr["RMonth"] = "January";
                                    else if (month==2)
                                        dr["RMonth"] = "February";
                                    else if (month == 3)
                                        dr["RMonth"] = "March";
                                    else if (month == 4)
                                        dr["RMonth"] = "April";
                                    else if (month == 5)
                                        dr["RMonth"] = "May";
                                    else if (month == 6)
                                        dr["RMonth"] = "June";
                                    else if (month == 7)
                                        dr["RMonth"] = "July";
                                    else if (month == 8)
                                        dr["RMonth"] = "August";
                                    else if (month == 9)
                                        dr["RMonth"] = "September";
                                    else if (month == 10)
                                        dr["RMonth"] = "October";
                                    else if (month == 11)
                                        dr["RMonth"] = "November";
                                    else if (month == 12)
                                        dr["RMonth"] = "December";

                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "RMonth";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion



                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_Sales_Quantity("Monthwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "RMonth";
                    dt1.Columns.Add(dc1);
                    dc1 = new DataColumn();
                    dc1.ColumnName = "Quantity";
                    dt1.Columns.Add(dc1);

                    if (dsFinalqty != null)
                    {
                        if (dsFinalqty.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt1.NewRow();

                                if (dsFinalqty.Tables[0].Rows[i]["RMonth"].ToString() == dsFinalqty.Tables[0].Rows[i]["RMonth"].ToString())
                                {
                                    int month = Convert.ToInt32(dsFinalqty.Tables[0].Rows[i]["RMonth"].ToString());

                                    if (month == 1)
                                        dr["RMonth"] = "January";
                                    else if (month == 2)
                                        dr["RMonth"] = "February";
                                    else if (month == 3)
                                        dr["RMonth"] = "March";
                                    else if (month == 4)
                                        dr["RMonth"] = "April";
                                    else if (month == 5)
                                        dr["RMonth"] = "May";
                                    else if (month == 6)
                                        dr["RMonth"] = "June";
                                    else if (month == 7)
                                        dr["RMonth"] = "July";
                                    else if (month == 8)
                                        dr["RMonth"] = "August";
                                    else if (month == 9)
                                        dr["RMonth"] = "September";
                                    else if (month == 10)
                                        dr["RMonth"] = "October";
                                    else if (month == 11)
                                        dr["RMonth"] = "November";
                                    else if (month == 12)
                                        dr["RMonth"] = "December";


                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "RMonth";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion

                }

            }

            else if (rbstockreturn.Checked == true)
            {


                if (ddlType.SelectedValue == "Daywise")
                {


                    divfrm.Visible = false;
                    divto.Visible = false;
                    divbtn.Visible = false;

                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_SalesReturn_Amount("Daywise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "Day";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "Amount";
                    dt.Columns.Add(dc);

                    if (dsFinal != null)
                    {
                        if (dsFinal.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();

                                if (dsFinal.Tables[0].Rows[i]["Day"].ToString() == dsFinal.Tables[0].Rows[i]["Day"].ToString())
                                {
                                    dr["Day"] = dsFinal.Tables[0].Rows[i]["Day"].ToString();
                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "Day";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_SalesReturn_Quantity("Daywise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "Day";
                    dt1.Columns.Add(dc1);
                    dc1 = new DataColumn();
                    dc1.ColumnName = "Quantity";
                    dt1.Columns.Add(dc1);

                    if (dsFinalqty != null)
                    {
                        if (dsFinalqty.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt1.NewRow();

                                if (dsFinalqty.Tables[0].Rows[i]["Day"].ToString() == dsFinalqty.Tables[0].Rows[i]["Day"].ToString())
                                {
                                    dr["Day"] = dsFinalqty.Tables[0].Rows[i]["Day"].ToString();
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "Day";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion

                }

                else if (ddlType.SelectedValue == "Datewise")
                {
                    divfrm.Visible = true;
                    divto.Visible = true;
                    divbtn.Visible = true;

                }
                else if (ddlType.SelectedValue == "Weekwise")
                {

                    divfrm.Visible = false;
                    divto.Visible = false;
                    divbtn.Visible = false;

                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_SalesReturn_Amount("Weekwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "RWeek";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "Amount";
                    dt.Columns.Add(dc);

                    if (dsFinal != null)
                    {
                        if (dsFinal.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();

                                if (dsFinal.Tables[0].Rows[i]["RWeek"].ToString() == dsFinal.Tables[0].Rows[i]["RWeek"].ToString())
                                {
                                    //dr["RWeek"] = dsFinal.Tables[0].Rows[i]["RWeek"].ToString();

                                    dr["RWeek"] = "Week" + (i + 1);

                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "RWeek";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_SalesReturn_Quantity("Weekwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "RWeek";
                    dt1.Columns.Add(dc1);
                    dc1 = new DataColumn();
                    dc1.ColumnName = "Quantity";
                    dt1.Columns.Add(dc1);

                    if (dsFinalqty != null)
                    {
                        if (dsFinalqty.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt1.NewRow();

                                if (dsFinalqty.Tables[0].Rows[i]["RWeek"].ToString() == dsFinalqty.Tables[0].Rows[i]["RWeek"].ToString())
                                {
                                    //dr["RWeek"] = dsFinalqty.Tables[0].Rows[i]["RWeek"].ToString();

                                    dr["RWeek"] = "Week" + (i + 1);
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "RWeek";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion
                }

                else if (ddlType.SelectedValue == "Monthwise")
                {

                    divfrm.Visible = false;
                    divto.Visible = false;
                    divbtn.Visible = false;

                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_SalesReturn_Amount("Monthwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "RMonth";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "Amount";
                    dt.Columns.Add(dc);

                    if (dsFinal != null)
                    {
                        if (dsFinal.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();

                                if (dsFinal.Tables[0].Rows[i]["RMonth"].ToString() == dsFinal.Tables[0].Rows[i]["RMonth"].ToString())
                                {

                                   int month = Convert.ToInt32(dsFinal.Tables[0].Rows[i]["RMonth"].ToString());


                                   if (month == 1)
                                       dr["RMonth"] = "January";
                                   else if (month == 2)
                                       dr["RMonth"] = "February";
                                   else if (month == 3)
                                       dr["RMonth"] = "March";
                                   else if (month == 4)
                                       dr["RMonth"] = "April";
                                   else if (month == 5)
                                       dr["RMonth"] = "May";
                                   else if (month == 6)
                                       dr["RMonth"] = "June";
                                   else if (month == 7)
                                       dr["RMonth"] = "July";
                                   else if (month == 8)
                                       dr["RMonth"] = "August";
                                   else if (month == 9)
                                       dr["RMonth"] = "September";
                                   else if (month == 10)
                                       dr["RMonth"] = "October";
                                   else if (month == 11)
                                       dr["RMonth"] = "November";
                                   else if (month == 12)
                                       dr["RMonth"] = "December";



                                    
                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "RMonth";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion



                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_SalesReturn_Quantity("Monthwise", sTableName, System.DateTime.Now, System.DateTime.Now);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "RMonth";
                    dt1.Columns.Add(dc1);
                    dc1 = new DataColumn();
                    dc1.ColumnName = "Quantity";
                    dt1.Columns.Add(dc1);

                    if (dsFinalqty != null)
                    {
                        if (dsFinalqty.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt1.NewRow();

                                if (dsFinalqty.Tables[0].Rows[i]["RMonth"].ToString() == dsFinalqty.Tables[0].Rows[i]["RMonth"].ToString())
                                {
                                    int month = Convert.ToInt32(dsFinalqty.Tables[0].Rows[i]["RMonth"].ToString());



                                    if (month == 1)
                                        dr["RMonth"] = "January";
                                    else if (month == 2)
                                        dr["RMonth"] = "February";
                                    else if (month == 3)
                                        dr["RMonth"] = "March";
                                    else if (month == 4)
                                        dr["RMonth"] = "April";
                                    else if (month == 5)
                                        dr["RMonth"] = "May";
                                    else if (month == 6)
                                        dr["RMonth"] = "June";
                                    else if (month == 7)
                                        dr["RMonth"] = "July";
                                    else if (month == 8)
                                        dr["RMonth"] = "August";
                                    else if (month == 9)
                                        dr["RMonth"] = "September";
                                    else if (month == 10)
                                        dr["RMonth"] = "October";
                                    else if (month == 11)
                                        dr["RMonth"] = "November";
                                    else if (month == 12)
                                        dr["RMonth"] = "December";
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "RMonth";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion

                }

            }

        }


        protected void btnReport_Click(object sender, EventArgs e)
        {
            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            DateTime sTo = Convert.ToDateTime(txttodate.Text);

            int d = sTo.Day - sFrom.Day;

            int days = Convert.ToInt32(d);
            if (days > 20)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Date with in 20 Days!!');", true);
                return;
            }


            if (rbsales.Checked == true)
            {
                #region Chart 1
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_Sales_Amount("Datewise", sTableName, sFrom, sTo);




                DataTable dt = new DataTable();
                DataColumn dc;

                dc = new DataColumn();
                dc.ColumnName = "BillDate";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Amount";
                dt.Columns.Add(dc);

                if (dsFinal != null)
                {
                    if (dsFinal.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr;
                            dr = dt.NewRow();

                            if (dsFinal.Tables[0].Rows[i]["BillDate"].ToString() == dsFinal.Tables[0].Rows[i]["BillDate"].ToString())
                            {
                                dr["BillDate"] = dsFinal.Tables[0].Rows[i]["BillDate"].ToString();
                            }
                            dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }

                    Chart1.DataSource = dt;
                    Chart1.Series["Series1"].XValueMember = "BillDate";
                    Chart1.Series["Series1"].YValueMembers = "Amount";
                    Chart1.DataBind();
                }

                #endregion


                #region Chart 2
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinalqty = new DataSet();
                dsFinalqty = objbs.GenerateChart_Sales_Quantity("Datewise", sTableName, sFrom, sTo);

                DataTable dt1 = new DataTable();
                DataColumn dc1;

                dc1 = new DataColumn();
                dc1.ColumnName = "BillDate";
                dt1.Columns.Add(dc1);
                dc1 = new DataColumn();
                dc1.ColumnName = "Quantity";
                dt1.Columns.Add(dc1);

                if (dsFinalqty != null)
                {
                    if (dsFinalqty.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr;
                            dr = dt1.NewRow();

                            if (dsFinalqty.Tables[0].Rows[i]["BillDate"].ToString() == dsFinalqty.Tables[0].Rows[i]["BillDate"].ToString())
                            {
                                dr["BillDate"] = dsFinalqty.Tables[0].Rows[i]["BillDate"].ToString();
                            }
                            dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                            dt1.Rows.Add(dr);
                        }
                    }

                    Chart2.DataSource = dt1;
                    Chart2.Series["Series1"].XValueMember = "BillDate";
                    Chart2.Series["Series1"].YValueMembers = "Quantity";
                    Chart2.DataBind();
                }

                #endregion
            }


            else if (rbstockreturn.Checked == true)
            {

                #region Chart 1
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_SalesReturn_Amount("Datewise", sTableName, sFrom, sTo);




                DataTable dt = new DataTable();
                DataColumn dc;

                dc = new DataColumn();
                dc.ColumnName = "RetDate";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Amount";
                dt.Columns.Add(dc);

                if (dsFinal != null)
                {
                    if (dsFinal.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr;
                            dr = dt.NewRow();

                            if (dsFinal.Tables[0].Rows[i]["RetDate"].ToString() == dsFinal.Tables[0].Rows[i]["RetDate"].ToString())
                            {
                                dr["RetDate"] = dsFinal.Tables[0].Rows[i]["RetDate"].ToString();
                            }
                            dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }

                    Chart1.DataSource = dt;
                    Chart1.Series["Series1"].XValueMember = "RetDate";
                    Chart1.Series["Series1"].YValueMembers = "Amount";
                    Chart1.DataBind();
                }

                #endregion


                #region Chart 2
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinalqty = new DataSet();
                dsFinalqty = objbs.GenerateChart_SalesReturn_Quantity("Datewise", sTableName, sFrom, sTo);

                DataTable dt1 = new DataTable();
                DataColumn dc1;

                dc1 = new DataColumn();
                dc1.ColumnName = "RetDate";
                dt1.Columns.Add(dc1);
                dc1 = new DataColumn();
                dc1.ColumnName = "Quantity";
                dt1.Columns.Add(dc1);

                if (dsFinalqty != null)
                {
                    if (dsFinalqty.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr;
                            dr = dt1.NewRow();

                            if (dsFinalqty.Tables[0].Rows[i]["RetDate"].ToString() == dsFinalqty.Tables[0].Rows[i]["RetDate"].ToString())
                            {
                                dr["RetDate"] = dsFinalqty.Tables[0].Rows[i]["RetDate"].ToString();
                            }
                            dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                            dt1.Rows.Add(dr);
                        }
                    }

                    Chart2.DataSource = dt1;
                    Chart2.Series["Series1"].XValueMember = "RetDate";
                    Chart2.Series["Series1"].YValueMembers = "Quantity";
                    Chart2.DataBind();
                }

                #endregion

            }
        }


    }
}