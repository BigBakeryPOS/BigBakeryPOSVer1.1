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
    public partial class SalesandReturn_DayReport : System.Web.UI.Page
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

                if (ddlType.SelectedValue == "Highest")
                {


                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_Sales_Amount_TodaysReport("Highest", sTableName);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "Product";
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

                                if (dsFinal.Tables[0].Rows[i]["Product"].ToString() == dsFinal.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinal.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "Product";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_Sales_Quantity_TodaysReport("Highest", sTableName);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "Product";
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

                                if (dsFinalqty.Tables[0].Rows[i]["Product"].ToString() == dsFinalqty.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinalqty.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "Product";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion

                }

                else if (ddlType.SelectedValue == "Lowest")
                {


                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_Sales_Amount_TodaysReport("Lowest", sTableName);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "Product";
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

                                if (dsFinal.Tables[0].Rows[i]["Product"].ToString() == dsFinal.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinal.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "Product";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_Sales_Quantity_TodaysReport("Lowest", sTableName);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "Product";
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

                                if (dsFinalqty.Tables[0].Rows[i]["Product"].ToString() == dsFinalqty.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinalqty.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "Product";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion
                }

            }

            else if (rbstockreturn.Checked == true)
            {


                if (ddlType.SelectedValue == "Highest")
                {


                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_SalesReturn_Amount_TodaysReport("Highest", sTableName);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "Product";
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

                                if (dsFinal.Tables[0].Rows[i]["Product"].ToString() == dsFinal.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinal.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "Product";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_SalesReturn_Quantity_TodaysReport("Highest", sTableName);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "Product";
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

                                if (dsFinalqty.Tables[0].Rows[i]["Product"].ToString() == dsFinalqty.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinalqty.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "Product";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion

                }


                else if (ddlType.SelectedValue == "Lowest")
                {


                    #region Chart 1
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinal = new DataSet();
                    dsFinal = objbs.GenerateChart_SalesReturn_Amount_TodaysReport("Lowest", sTableName);

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "Product";
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

                                if (dsFinal.Tables[0].Rows[i]["Product"].ToString() == dsFinal.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinal.Tables[0].Rows[i]["Product"].ToString();

                                }
                                dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                                dt.Rows.Add(dr);
                            }
                        }

                        Chart1.DataSource = dt;
                        Chart1.Series["Series1"].XValueMember = "Product";
                        Chart1.Series["Series1"].YValueMembers = "Amount";
                        Chart1.DataBind();
                    }

                    #endregion


                    #region Chart 2
                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart2.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsFinalqty = new DataSet();
                    dsFinalqty = objbs.GenerateChart_SalesReturn_Quantity_TodaysReport("Lowest", sTableName);

                    DataTable dt1 = new DataTable();
                    DataColumn dc1;

                    dc1 = new DataColumn();
                    dc1.ColumnName = "Product";
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

                                if (dsFinalqty.Tables[0].Rows[i]["Product"].ToString() == dsFinalqty.Tables[0].Rows[i]["Product"].ToString())
                                {
                                    dr["Product"] = dsFinalqty.Tables[0].Rows[i]["Product"].ToString();
                                }
                                dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                                dt1.Rows.Add(dr);
                            }
                        }

                        Chart2.DataSource = dt1;
                        Chart2.Series["Series1"].XValueMember = "Product";
                        Chart2.Series["Series1"].YValueMembers = "Quantity";
                        Chart2.DataBind();
                    }

                    #endregion
                }

            }

        }


    }
}