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
    public partial class CRM : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if(!IsPostBack)
            {
                divState.Visible = false;
            }

            #region Chart 2

            //Chart3.Series["Ser1"].ChartType = SeriesChartType.Column;
            ////Chart1.Series["Series1"]["DrawingStyle"] = "Emboss";
            ////Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            //Chart3.Series["Ser1"].IsValueShownAsLabel = true;

            //DataSet dsFinal1 = new DataSet();

            //dsFinal1 = objbs.GenerateMonthWiseChart_Month();

            //DataTable dt1 = new DataTable();
            //DataColumn dc1;

            //dc1 = new DataColumn();
            //dc1.ColumnName = "DepartmentName";
            //dt1.Columns.Add(dc1);
            //dc1 = new DataColumn();
            //dc1.ColumnName = "Amount";
            //dt1.Columns.Add(dc1);

            //if (dsFinal1 != null)
            //{
            //    if (dsFinal1.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dsFinal1.Tables[0].Rows.Count; i++)
            //        {
            //            DataRow dr;
            //            dr = dt1.NewRow();

            //            if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Industry Department")
            //            {
            //                dr["DepartmentName"] = "Industry Department";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Restaurant Department")
            //            {
            //                dr["DepartmentName"] = "Restaurant Department";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Training Department")
            //            {
            //                dr["DepartmentName"] = "Training Department";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Marketing Department")
            //            {
            //                dr["DepartmentName"] = "Marketing Department";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Accounts Department")
            //            {
            //                dr["DepartmentName"] = "Accounts Department";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Auditing Department")
            //            {
            //                dr["DepartmentName"] = "Auditing Department";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Administration")
            //            {
            //                dr["DepartmentName"] = "Administration";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "HFMT")
            //            {
            //                dr["DepartmentName"] = "HFMT";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "R & D")
            //            {
            //                dr["DepartmentName"] = "R & D";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Shariah")
            //            {
            //                dr["DepartmentName"] = "Shariah";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Management")
            //            {
            //                dr["DepartmentName"] = "Management";
            //            }
            //            else if (dsFinal.Tables[0].Rows[i]["dept"].ToString() == "Fianance Department")
            //            {
            //                dr["DepartmentName"] = "Fianance Department";
            //            }

            //            dr["Amount"] = dsFinal1.Tables[0].Rows[i]["Amount"].ToString();
            //            dt1.Rows.Add(dr);
            //        }
            //    }
            //}

            //Chart3.DataSource = dt1;
            //Chart3.Series["Ser1"].XValueMember = "DepartmentName";
            //Chart3.Series["Ser1"].YValueMembers = "Amount";
            //Chart3.DataBind();

            #endregion
        }

        protected void ddlState_Change(object sender, EventArgs e)
        {
            #region Chart 1
            Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
            Chart1.Series["Series1"].IsValueShownAsLabel = true;

            DataSet dsFinal = new DataSet();
            dsFinal = objbs.GenerateChart_CRM(ddlState.SelectedValue, sTableName);

            DataTable dt = new DataTable();
            DataColumn dc;

            dc = new DataColumn();
            dc.ColumnName = "State";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "CO";
            dt.Columns.Add(dc);

            if (dsFinal != null)
            {
                if (dsFinal.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr;
                        dr = dt.NewRow();

                        if (dsFinal.Tables[0].Rows[i]["State"].ToString() == dsFinal.Tables[0].Rows[i]["State"].ToString())
                        {
                            dr["State"] = dsFinal.Tables[0].Rows[i]["State"].ToString();
                        }
                        dr["CO"] = dsFinal.Tables[0].Rows[i]["CO"].ToString();
                        dt.Rows.Add(dr);
                    }
                }

                Chart1.DataSource = dt;
                Chart1.Series["Series1"].XValueMember = "State";
                Chart1.Series["Series1"].YValueMembers = "CO";
                Chart1.DataBind();
            }

            #endregion
        }

        protected void ddlType_Change(object sender, EventArgs e)
        {

            if (ddlType.SelectedValue == "TopCategoryWise" || ddlType.SelectedValue == "LastCategoryWise")
            {


                DataSet drpdpown = objbs.CategoryUsergetval1();
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlSubType.DataSource = drpdpown;
                    ddlSubType.DataTextField = "Category";
                    ddlSubType.DataValueField = "CategoryID";
                    ddlSubType.DataBind();
                    ddlSubType.Items.Insert(0, "--Select Category--");
                }
                idsstype.Visible = true;

            }
            else
            {
                ddlSubType.Items.Clear();
                idsstype.Visible = false;

            }
            //if (ddlType.SelectedValue == "StateWise")
            //{
            //    divState.Visible = true;
            //    //////DataSet drpdpown = objbs.getStatedropdownLatest();
            //    //////if (drpdpown.Tables[0].Rows.Count > 0)
            //    //////{
            //    //////    ddlState.DataSource = drpdpown;
            //    //////    ddlState.DataTextField = "States";
            //    //////    ddlState.DataValueField = "StateIDs";
            //    //////    ddlState.DataBind();
            //    //////    ddlState.Items.Insert(0, "--Select State Name--");
            //    //////}
            //}
            //else
            //{
            //    divState.Visible = false;
            //}

            if (ddlType.SelectedValue == "TopCategoryWise")
            {
                #region Chart 1
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_CRM("TopcatWise", sTableName);

                DataTable dt = new DataTable();
                DataColumn dc;

                dc = new DataColumn();
                dc.ColumnName = "Category";
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

                            if (dsFinal.Tables[0].Rows[i]["Category"].ToString() == dsFinal.Tables[0].Rows[i]["Category"].ToString())
                            {
                                dr["Category"] = dsFinal.Tables[0].Rows[i]["Category"].ToString();
                            }
                            dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }

                    Chart1.DataSource = dt;
                    Chart1.Series["Series1"].XValueMember = "Category";
                    Chart1.Series["Series1"].YValueMembers = "Amount";
                    Chart1.DataBind();
                }

                #endregion


                #region Chart 2
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinalqty = new DataSet();
                dsFinalqty = objbs.GenerateChart_CRMQuantity("TopcatWise", sTableName);

                DataTable dt1 = new DataTable();
                DataColumn dc1;

                dc1 = new DataColumn();
                dc1.ColumnName = "Category";
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

                            if (dsFinalqty.Tables[0].Rows[i]["Category"].ToString() == dsFinalqty.Tables[0].Rows[i]["Category"].ToString())
                            {
                                dr["Category"] = dsFinalqty.Tables[0].Rows[i]["Category"].ToString();
                            }
                            dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                            dt1.Rows.Add(dr);
                        }
                    }

                    Chart2.DataSource = dt1;
                    Chart2.Series["Series1"].XValueMember = "Category";
                    Chart2.Series["Series1"].YValueMembers = "Quantity";
                    Chart2.DataBind();
                }

                #endregion

            }
            else if (ddlType.SelectedValue == "LastCategoryWise")
            {
                #region Chart 1
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_CRM("LastcatWise", sTableName);

                DataTable dt = new DataTable();
                DataColumn dc;

                dc = new DataColumn();
                dc.ColumnName = "Category";
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

                            if (dsFinal.Tables[0].Rows[i]["Category"].ToString() == dsFinal.Tables[0].Rows[i]["Category"].ToString())
                            {
                                dr["Category"] = dsFinal.Tables[0].Rows[i]["Category"].ToString();
                            }
                            dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }

                    Chart1.DataSource = dt;
                    Chart1.Series["Series1"].XValueMember = "Category";
                    Chart1.Series["Series1"].YValueMembers = "Amount";
                    Chart1.DataBind();
                }

                #endregion

                #region Chart 2
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinalqty = new DataSet();
                dsFinalqty = objbs.GenerateChart_CRMQuantity("LastcatWise", sTableName);

                DataTable dt1 = new DataTable();
                DataColumn dc1;

                dc1 = new DataColumn();
                dc1.ColumnName = "Category";
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

                            if (dsFinalqty.Tables[0].Rows[i]["Category"].ToString() == dsFinalqty.Tables[0].Rows[i]["Category"].ToString())
                            {
                                dr["Category"] = dsFinalqty.Tables[0].Rows[i]["Category"].ToString();
                            }
                            dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                            dt1.Rows.Add(dr);
                        }
                    }

                    Chart2.DataSource = dt1;
                    Chart2.Series["Series1"].XValueMember = "Category";
                    Chart2.Series["Series1"].YValueMembers = "Quantity";
                    Chart2.DataBind();
                }

                #endregion
            }
            else if (ddlType.SelectedValue == "TopProductWise")
            {
                #region Chart 1
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_CRM("TopitemWise", sTableName);

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
                dsFinalqty = objbs.GenerateChart_CRMQuantity("TopitemWise", sTableName);

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
            else if (ddlType.SelectedValue == "LastProductWise")
            {
                #region Chart 1
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_CRM("LastitemWise", sTableName);

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
                dsFinalqty = objbs.GenerateChart_CRMQuantity("LastitemWise", sTableName);

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


        protected void ddlSubType_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlSubType.SelectedValue != "--Select Category--")
            {
                #region Chart 4
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinal = new DataSet();
                dsFinal = objbs.GenerateChart_CRMsubnew(ddlSubType.SelectedValue, sTableName);

                DataTable dt = new DataTable();
                DataColumn dc;

                dc = new DataColumn();
                dc.ColumnName = "Definition";
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

                            if (dsFinal.Tables[0].Rows[i]["Definition"].ToString() == dsFinal.Tables[0].Rows[i]["Definition"].ToString())
                            {
                                dr["Definition"] = dsFinal.Tables[0].Rows[i]["Definition"].ToString();
                            }
                            dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }

                    Chart1.DataSource = dt;
                    Chart1.Series["Series1"].XValueMember = "Definition";
                    Chart1.Series["Series1"].YValueMembers = "Amount";
                    Chart1.DataBind();
                }

                #endregion


                #region Chart 5
                Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart2.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsFinalqty = new DataSet();
                dsFinalqty = objbs.GenerateChart_CRMQuantitysubnew(ddlSubType.SelectedValue, sTableName);

                DataTable dt1 = new DataTable();
                DataColumn dc1;

                dc1 = new DataColumn();
                dc1.ColumnName = "Definition";
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

                            if (dsFinalqty.Tables[0].Rows[i]["Definition"].ToString() == dsFinalqty.Tables[0].Rows[i]["Definition"].ToString())
                            {
                                dr["Definition"] = dsFinalqty.Tables[0].Rows[i]["Definition"].ToString();
                            }
                            dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                            dt1.Rows.Add(dr);
                        }
                    }

                    Chart2.DataSource = dt1;
                    Chart2.Series["Series1"].XValueMember = "Definition";
                    Chart2.Series["Series1"].YValueMembers = "Quantity";
                    Chart2.DataBind();
                }

                #endregion

            }
            else if (ddlSubType.SelectedValue == "LastCategoryWise")
            {
                #region 
                //Chart 4
                //Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                //Chart1.Series["Series1"].IsValueShownAsLabel = true;

                //DataSet dsFinal = new DataSet();
                //dsFinal = objbs.GenerateChart_CRMsub("LastcatWise", sTableName);

                //DataTable dt = new DataTable();
                //DataColumn dc;

                //dc = new DataColumn();
                //dc.ColumnName = "Definition";
                //dt.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "Amount";
                //dt.Columns.Add(dc);

                //if (dsFinal != null)
                //{
                //    if (dsFinal.Tables[0].Rows.Count > 0)
                //    {
                //        for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
                //        {
                //            DataRow dr;
                //            dr = dt.NewRow();

                //            if (dsFinal.Tables[0].Rows[i]["Definition"].ToString() == dsFinal.Tables[0].Rows[i]["Definition"].ToString())
                //            {
                //                dr["Definition"] = dsFinal.Tables[0].Rows[i]["Definition"].ToString();
                //            }
                //            dr["Amount"] = dsFinal.Tables[0].Rows[i]["Amount"].ToString();
                //            dt.Rows.Add(dr);
                //        }
                //    }

                //    Chart1.DataSource = dt;
                //    Chart1.Series["Series1"].XValueMember = "Definition";
                //    Chart1.Series["Series1"].YValueMembers = "Amount";
                //    Chart1.DataBind();
                //}

                //#endregion

                //#region Chart 5
                //Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
                //Chart2.Series["Series1"].IsValueShownAsLabel = true;

                //DataSet dsFinalqty = new DataSet();
                //dsFinalqty = objbs.GenerateChart_CRMQuantitysub("LastcatWise", sTableName);

                //DataTable dt1 = new DataTable();
                //DataColumn dc1;

                //dc1 = new DataColumn();
                //dc1.ColumnName = "Definition";
                //dt1.Columns.Add(dc1);
                //dc1 = new DataColumn();
                //dc1.ColumnName = "Quantity";
                //dt1.Columns.Add(dc1);

                //if (dsFinalqty != null)
                //{
                //    if (dsFinalqty.Tables[0].Rows.Count > 0)
                //    {
                //        for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                //        {
                //            DataRow dr;
                //            dr = dt1.NewRow();

                //            if (dsFinalqty.Tables[0].Rows[i]["Definition"].ToString() == dsFinalqty.Tables[0].Rows[i]["Definition"].ToString())
                //            {
                //                dr["Definition"] = dsFinalqty.Tables[0].Rows[i]["Definition"].ToString();
                //            }
                //            dr["Quantity"] = dsFinalqty.Tables[0].Rows[i]["Quantity"].ToString();
                //            dt1.Rows.Add(dr);
                //        }
                //    }

                //    Chart2.DataSource = dt1;
                //    Chart2.Series["Series1"].XValueMember = "Definition";
                //    Chart2.Series["Series1"].YValueMembers = "Quantity";
                //    Chart2.DataBind();
                //}

                #endregion
            }
           
        }
    }
}