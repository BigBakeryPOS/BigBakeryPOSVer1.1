﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLayer;
using CommonLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.IO;
using System.Globalization;
using System.Drawing;
namespace Billing.Accountsbootstrap
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        DataSet ds = new DataSet();
        string sTableName = "";
        string Label123 = "";
        string strPreviousRowID = string.Empty;
        // To keep track the Index of Group Total    
        int intSubTotalIndex = 1;
        double dblSubTotalUnitPrice = 0;
        double dblSubTotalQuantity = 0;
        double dblSubTotalDiscount = 0;
        double dblSubTotalAmount = 0;
        // To temporarily store Grand Total    
        double dblGrandTotalUnitPrice = 0;
        double dblGrandTotalQuantity = 0;
        double dblGrandTotalDiscount = 0;
        double dblGrandTotalAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();


                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
                //txtFromDate.Text = new DateTime(today.Year, today.Month, 1).ToString("MM/dd/yyyy");
                txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txtFromDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                if (sTableName != "admin")
                {
                    Admin.Visible = false;
                }
                else
                {
                    txtToDate.Enabled = false;
                    txtFromDate.Enabled = false;
                }

                //DateTime utc = DateTime.UtcNow;
                //// DateTimeOffset localServerTime = DateTimeOffset.Now;

                //var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                //DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(utc, easternZone);


                //TimeZone zone = TimeZone.CurrentTimeZone;
                //DaylightTime time = zone.GetDaylightChanges(DateTime.Today.Year);
                ////// DateTime eastern = TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                //TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                //DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
                //var info = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                //DateTimeOffset localServerTime = DateTimeOffset.Now;

                //DateTimeOffset usersTime = TimeZoneInfo.ConvertTime(localServerTime, info);

                //DateTimeOffset utc = localServerTime.ToUniversalTime();

                //DateTime utcTime = DateTime.Now;

                //TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                //DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            }

        }

        protected void gridPurchase_RowCreated(object sender, GridViewRowEventArgs e)
        {

            #region 4
            if (rbdCtry.Checked == true)
            {

                {


                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "CategoryID") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "CategoryID").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "CategoryID") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "CategoryID") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Category : " + DataBinder.Eval(e.Row.DataItem, "category").ToString();
                        cell.ColumnSpan = 9;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                    #endregion
                    if (IsSubTotalRowNeedToAdd)
                    {
                        #region Adding Sub Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row          
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell          
                        TableCell cell = new TableCell();
                        cell.Text = "Sub Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 7;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column            
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblSubTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "SubTotalRowStyle";
                        //row.Cells.Add(cell);
                        //Adding Discount Column         
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "CategoryID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Category : " + DataBinder.Eval(e.Row.DataItem, "category").ToString();
                            cell.ColumnSpan = 9;
                            cell.CssClass = "GroupHeaderStyle";
                            row.Cells.Add(cell);
                            gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                            intSubTotalIndex++;
                        }
                        #endregion
                        #region Reseting the Sub Total Variables
                        dblSubTotalUnitPrice = 0;
                        dblSubTotalQuantity = 0;
                        dblSubTotalDiscount = 0;

                        #endregion
                    }
                    if (IsGrandTotalRowNeedtoAdd)
                    {
                        #region Grand Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row      
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell           
                        TableCell cell = new TableCell();
                        cell.Text = "Grand Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 7;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column           
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblGrandTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "GrandTotalRowStyle";
                        //row.Cells.Add(cell);
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid     
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
                        #endregion
                    }
                }

            }
            #endregion
            #region 5
            if (rbdProduct.Checked == true)
            {

                {


                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "SubCategoryID") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "SubCategoryID").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "SubCategoryID") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "SubCategoryID") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Definition").ToString();
                        cell.ColumnSpan = 9;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                    #endregion
                    if (IsSubTotalRowNeedToAdd)
                    {
                        #region Adding Sub Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row          
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell          
                        TableCell cell = new TableCell();
                        cell.Text = "Sub Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 7;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column            
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblSubTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "SubTotalRowStyle";
                        //row.Cells.Add(cell);
                        //Adding Discount Column         
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "SubCategoryID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Definition").ToString();
                            cell.ColumnSpan = 9;
                            cell.CssClass = "GroupHeaderStyle";
                            row.Cells.Add(cell);
                            gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                            intSubTotalIndex++;
                        }
                        #endregion
                        #region Reseting the Sub Total Variables
                        dblSubTotalUnitPrice = 0;
                        dblSubTotalQuantity = 0;
                        dblSubTotalDiscount = 0;

                        #endregion
                    }
                    if (IsGrandTotalRowNeedtoAdd)
                    {
                        #region Grand Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row      
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell           
                        TableCell cell = new TableCell();
                        cell.Text = "Grand Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 7;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column           
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblGrandTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "GrandTotalRowStyle";
                        //row.Cells.Add(cell);
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid     
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
                        #endregion
                    }
                }
            }
            #endregion

            #region Reasons
            if (rbdReasons.Checked == true)
            {

                {


                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Reasonsid") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "Reasonsid").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Reasonsid") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Reasonsid") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Reasons").ToString();
                        cell.ColumnSpan = 9;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                    #endregion
                    if (IsSubTotalRowNeedToAdd)
                    {
                        #region Adding Sub Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row          
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell          
                        TableCell cell = new TableCell();
                        cell.Text = "Sub Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 7;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column            
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblSubTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "SubTotalRowStyle";
                        //row.Cells.Add(cell);
                        //Adding Discount Column         
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "Reasonsid") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Reasons").ToString();
                            cell.ColumnSpan = 9;
                            cell.CssClass = "GroupHeaderStyle";
                            row.Cells.Add(cell);
                            gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                            intSubTotalIndex++;
                        }
                        #endregion
                        #region Reseting the Sub Total Variables
                        dblSubTotalUnitPrice = 0;
                        dblSubTotalQuantity = 0;
                        dblSubTotalDiscount = 0;

                        #endregion
                    }
                    if (IsGrandTotalRowNeedtoAdd)
                    {
                        #region Grand Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row      
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell           
                        TableCell cell = new TableCell();
                        cell.Text = "Grand Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 7;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column           
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblGrandTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "GrandTotalRowStyle";
                        //row.Cells.Add(cell);
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid     
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
                        #endregion
                    }
                }
            }
            #endregion

         

        }

        protected void gridPurchase_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (rdbCustomer.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "CustomerID").ToString();

                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());
                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }
            else if (rbdPayMode.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "PayMode").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());
                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }
            else if (rbdCtry.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "CategoryID").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());
                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }
            else if (rbdProduct.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "SubCategoryID").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());
                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }

            else if (rbdReasons.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "Reasonsid").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UnitPrice").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());
                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            //txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");


            if (sTableName == "CO1")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO2")
            {
                Label123 = "Blaack Forest Bakery Services";
            }
            else if (sTableName == "CO3")
            {
                Label123 = "Shiva Delights";
            }
            else if (sTableName == "CO4")
            {
                Label123 = "Fig and honey";
            }
            else if (sTableName == "CO5")
            {
                Label123 = "Blaack Forest Bakery Services";
            }

            else if (sTableName == "CO6")
            {
                Label123 = "Maduravayol";
            }

            else if (sTableName == "CO6")
            {
                Label123 = "purasavakkam";
            }



            else if (sTableName == "CO8")
            {
                Label123 = "Chennai Pothys";
            }

            else if (sTableName == "CO9")
            {
                Label123 = "Thirunelveli";
            }

            else if (sTableName == "CO10")
            {
                Label123 = "Periyar";
            }
            else if (sTableName == "CO11")
            {
                Label123 = "Palayam";
            }
            if (rbdCtry.Checked == true)
            {
                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                string ToDate = sTO.ToString("yyyy-MM-dd");
                GridView gvsales = new GridView();

                DataSet da = objBs.ordebyCategory2return(sTableName, FromDate, ToDate);
               

                //updated 22/10/21
                if (da.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < da.Tables[0].Rows.Count; i++)
                    {
                        da.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(da.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    }
                }
                 //end update
                gvsales.DataSource = da.Tables[0];
                gvsales.AutoGenerateColumns = false;
                BoundField test3 = new BoundField();

                test3.DataField = "category";
                test3.HeaderText = "Category";
                gvsales.Columns.Add(test3);
                BoundField test4 = new BoundField();


                BoundField test = new BoundField();

                test.DataField = "BillNo";
                test.HeaderText = "Bill NO";
                gvsales.Columns.Add(test);
                BoundField test1 = new BoundField();

                test1.DataField = "BillDate";
                test1.HeaderText = "Bill Date";
                gvsales.Columns.Add(test1);
                BoundField test2 = new BoundField();

                test2.DataField = "LedgerName";
                test2.HeaderText = "Customer Name";
                gvsales.Columns.Add(test2);


                test4.DataField = "Definition";
                test4.HeaderText = "Item";
                gvsales.Columns.Add(test4);
                BoundField test7 = new BoundField();

                test7.DataField = "BrandName";
                test7.HeaderText = "Brand Name";
                gvsales.Columns.Add(test7);
                BoundField test5 = new BoundField();

                test5.DataField = "Quantity";
                test5.HeaderText = "Quantity";
                gvsales.Columns.Add(test5);
                BoundField test6 = new BoundField();

                test6.DataField = "UnitPrice";
                test6.HeaderText = "Unit Price";
                gvsales.Columns.Add(test6);
                BoundField test8 = new BoundField();

                test8.DataField = "Payment_Mode";
                test8.HeaderText = "Payment Type";
                gvsales.Columns.Add(test8);

                BoundField test9 = new BoundField();

                test9.DataField = "NetAmount";
                test9.HeaderText = " Total Amount";
                gvsales.Columns.Add(test9);


                BoundField test10 = new BoundField();

                test10.DataField = "Reasons";
                test10.HeaderText = " Total Reasons";
                gvsales.Columns.Add(test10);

                gvsales.Caption = Label123 + " Sales Return Report  Generated on " + DateTime.Now.ToString();

                gvsales.RowHeaderColumn.ToUpper();
                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseCategoryReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();

            }
            else if (rbdProduct.Checked == true)
            {
                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                string ToDate = sTO.ToString("yyyy-MM-dd");
                GridView gvsales = new GridView();
                gvsales.DataSource = objBs.ordebyproduct2return(sTableName, FromDate, ToDate);
                gvsales.AutoGenerateColumns = false;
                BoundField test4 = new BoundField();

                test4.DataField = "Definition";
                test4.HeaderText = "Item";
                gvsales.Columns.Add(test4);
                BoundField test3 = new BoundField();

                test3.DataField = "category";
                test3.HeaderText = "Category";
                gvsales.Columns.Add(test3);



                BoundField test = new BoundField();

                test.DataField = "BillNo";
                test.HeaderText = "Bill NO";
                gvsales.Columns.Add(test);
                BoundField test1 = new BoundField();

                test1.DataField = "BillDate";
                test1.HeaderText = "Bill Date";
                gvsales.Columns.Add(test1);
                BoundField test2 = new BoundField();

                test2.DataField = "LedgerName";
                test2.HeaderText = "Customer Name";
                gvsales.Columns.Add(test2);

                BoundField test7 = new BoundField();

                test7.DataField = "BrandName";
                test7.HeaderText = "Brand Name";
                gvsales.Columns.Add(test7);
                BoundField test5 = new BoundField();

                test5.DataField = "Quantity";
                test5.HeaderText = "Quantity";
                gvsales.Columns.Add(test5);
                BoundField test6 = new BoundField();

                test6.DataField = "UnitPrice";
                test6.HeaderText = "Unit Price";
                gvsales.Columns.Add(test6);
                BoundField test8 = new BoundField();

                test8.DataField = "Payment_Mode";
                test8.HeaderText = "Payment Type";
                gvsales.Columns.Add(test8);

                BoundField test9 = new BoundField();

                test9.DataField = "NetAmount";
                test9.HeaderText = " Total Amount";
                gvsales.Columns.Add(test9);

                BoundField test10 = new BoundField();

                test10.DataField = "Reasons";
                test10.HeaderText = " Total Reasons";
                gvsales.Columns.Add(test10);

                gvsales.Caption = Label123 + " Sales Return Report  Generated on " + DateTime.Now.ToString();

                gvsales.RowHeaderColumn.ToUpper();
                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseProductReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
            }
            else if (rbdReasons.Checked == true)
            {
                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                string ToDate = sTO.ToString("yyyy-MM-dd");
                GridView gvsales = new GridView();
                gvsales.DataSource = objBs.ordebyReasons2return(sTableName, FromDate, ToDate);
                gvsales.AutoGenerateColumns = false;
                BoundField test4 = new BoundField();

                test4.DataField = "Definition";
                test4.HeaderText = "Item";
                gvsales.Columns.Add(test4);
                BoundField test3 = new BoundField();

                test3.DataField = "category";
                test3.HeaderText = "Category";
                gvsales.Columns.Add(test3);



                BoundField test = new BoundField();

                test.DataField = "BillNo";
                test.HeaderText = "Bill NO";
                gvsales.Columns.Add(test);
                BoundField test1 = new BoundField();

                test1.DataField = "BillDate";
                //updated 22/10/21
                test1.DataFormatString = "{0:dd/MMM/yyyy}";
                //end update
                test1.HeaderText = "Bill Date";
                gvsales.Columns.Add(test1);
                BoundField test2 = new BoundField();

                test2.DataField = "LedgerName";
                test2.HeaderText = "Customer Name";
                gvsales.Columns.Add(test2);

                BoundField test7 = new BoundField();

                test7.DataField = "BrandName";
                test7.HeaderText = "Brand Name";
                gvsales.Columns.Add(test7);
                BoundField test5 = new BoundField();

                test5.DataField = "Quantity";
                test5.HeaderText = "Quantity";
                gvsales.Columns.Add(test5);
                BoundField test6 = new BoundField();

                test6.DataField = "UnitPrice";
                test6.HeaderText = "Unit Price";
                gvsales.Columns.Add(test6);
                BoundField test8 = new BoundField();

                test8.DataField = "Payment_Mode";
                test8.HeaderText = "Payment Type";
                gvsales.Columns.Add(test8);

                BoundField test9 = new BoundField();

                test9.DataField = "NetAmount";
                test9.HeaderText = " Total Amount";
                gvsales.Columns.Add(test9);

                BoundField test10 = new BoundField();

                test10.DataField = "Reasons";
                test10.HeaderText = " Total Reasons";
                gvsales.Columns.Add(test10);

                gvsales.Caption = Label123 + " Sales Return Report  Generated on " + DateTime.Now.ToString();

                gvsales.RowHeaderColumn.ToUpper();
                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseProductReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
            }
            else if (rbproqty.Checked == true)
            {

                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                string ToDate = sTO.ToString("yyyy-MM-dd");
                DataSet ds1 = objBs.ordebyprodqty(sTableName, FromDate, ToDate);

                //  gvsales.RowHeaderColumn.ToUpper();
                //gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                //gvsales.DataBind();
                //Response.ClearContent();
                //Response.AddHeader("content-disposition",
                //    "attachment;filename=PurchaseProductReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                //Response.ContentType = "applicatio/excel";
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter htm = new HtmlTextWriter(sw);
                //gvsales.RenderControl(htm);
                //Response.Write(sw.ToString());
                ;


                GridView gridview = new GridView();



               // gridview.Caption = Label123 + " Sales Return Report  Generated on " + DateTime.Now.ToString();


                
                //updated 22/10/21  
                
                DataSet da= objBs.ordebyprodqty(sTableName, FromDate, ToDate);
              
                if (da.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < da.Tables[0].Rows.Count; i++)
                    {
                        da.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(da.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    }
                }

                gridview.DataSource = da.Tables[0];
                //end update

                //gridview.DataSource = objBs.ordebyprodqty(sTableName, FromDate, ToDate);--commented on 22/10/21
                gridview.DataBind();

                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=StockReport.xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gridview.AllowPaging = false;
                gridview.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
                gridview.AllowPaging = true;


            }


            else if (rbdcatqty.Checked == true)
            {
                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                string ToDate = sTO.ToString("yyyy-MM-dd");
                //  gridPurchase.Visible = false;


            



                DataSet ds1 = objBs.ordebycatqty(sTableName, FromDate, ToDate);
                DataGrid gvsales = new DataGrid();

                // gvsales.RowHeaderColumn.ToUpper();
                gvsales.Caption = Label123 + " Sales Return Report  Generated on " + DateTime.Now.ToString();
                gvsales.DataSource = objBs.ordebycatqty(sTableName, FromDate, ToDate);


                //updated 22/10/21  

                DataSet da = objBs.ordebycatqty(sTableName, FromDate, ToDate);

                if (da.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < da.Tables[0].Rows.Count; i++)
                    {
                        da.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(da.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    }
                }

                gvsales.DataSource = da.Tables[0];
                //end update



                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseProductReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
            }
            //else if (rbdBrnd.Checked == true)
            //{
            //    GridView gvsales = new GridView();
            //    gvsales.DataSource = objBs.ordebyBrand2(sTableName, txtFromDate.Text, txtToDate.Text);
            //    gvsales.AutoGenerateColumns = false;
            //    BoundField test7 = new BoundField();

            //    test7.DataField = "BrandName";
            //    test7.HeaderText = "Brand Name";
            //    gvsales.Columns.Add(test7);
            //    BoundField test4 = new BoundField();

            //    test4.DataField = "Definition";
            //    test4.HeaderText = "Item";
            //    gvsales.Columns.Add(test4);
            //    BoundField test3 = new BoundField();

            //    test3.DataField = "category";
            //    test3.HeaderText = "Category";
            //    gvsales.Columns.Add(test3);



            //    BoundField test = new BoundField();

            //    test.DataField = "BillNo";
            //    test.HeaderText = "Bill NO";
            //    gvsales.Columns.Add(test);
            //    BoundField test1 = new BoundField();

            //    test1.DataField = "BillDate";
            //    test1.HeaderText = "Bill Date";
            //    gvsales.Columns.Add(test1);
            //    BoundField test2 = new BoundField();

            //    test2.DataField = "LedgerName";
            //    test2.HeaderText = "Customer Name";
            //    gvsales.Columns.Add(test2);


            //    BoundField test5 = new BoundField();

            //    test5.DataField = "Quantity";
            //    test5.HeaderText = "Quantity";
            //    gvsales.Columns.Add(test5);
            //    BoundField test6 = new BoundField();

            //    test6.DataField = "UnitPrice";
            //    test6.HeaderText = "Unit Price";
            //    gvsales.Columns.Add(test6);
            //    BoundField test8 = new BoundField();

            //    test8.DataField = "Payment_Mode";
            //    test8.HeaderText = "Payment Type";
            //    gvsales.Columns.Add(test8);

            //    BoundField test9 = new BoundField();

            //    test9.DataField = "NetAmount";
            //    test9.HeaderText = " Total Amount";
            //    gvsales.Columns.Add(test9);

            //    gvsales.RowHeaderColumn.ToUpper();
            //    gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
            //    gvsales.DataBind();
            //    Response.ClearContent();
            //    Response.AddHeader("content-disposition",
            //        "attachment;filename=PurchaseBrnadReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
            //    Response.ContentType = "applicatio/excel";
            //    StringWriter sw = new StringWriter(); ;
            //    HtmlTextWriter htm = new HtmlTextWriter(sw);
            //    gvsales.RenderControl(htm);
            //    Response.Write(sw.ToString());
            //    Response.End();
            //}
        }

        protected void rdbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            //DataSet ds1 = objBs.sOrdebyVendor(sTableName, txtFromDate.Text, txtToDate.Text);
            //gridPurchase.DataSource = ds1;
            //gridPurchase.DataBind();

        }

        protected void rbdPayMode_CheckedChanged(object sender, EventArgs e)
        {
            //DataSet ds1 = objBs.sorderPay(sTableName, txtFromDate.Text, txtToDate.Text);
            //gridPurchase.DataSource = ds1;
            //gridPurchase.DataBind();

        }

        protected void rbdCtry_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyCategory2return(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyCategory2return(sTableName, FromDate, ToDate);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;

            btn.Visible = true;
        }




        protected void rbdReasons_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyReasons2return(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyReasons2return(sTableName, FromDate, ToDate);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;

            btn.Visible = true;
        }

        protected void rbdProduct_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyproduct2return(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyproduct2return(sTableName, FromDate, ToDate);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;


            btn.Visible = true;

        }

        protected void rbdBrnd_CheckedChanged(object sender, EventArgs e)
        {

            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.QtySummary(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.QtySummary(sTableName, FromDate, ToDate);
            }
            gridcatqty.DataSource = ds1;
            gridcatqty.DataBind();

            gridcatqty.Visible = true;
            Td1.Visible = false;

            btn.Visible = true;

        }

        protected void rbdcatqty_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            //  gridPurchase.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebycatqty(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebycatqty(sTableName, FromDate, ToDate);
            }
            gridcatqty.DataSource = ds1;
            gridcatqty.DataBind();

            //gridcatqty.Visible = true;

            decimal dtotal = 0;
            for (int i = 0; i < gridcatqty.Rows.Count; i++)
            {
                dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
            }
            decimal Total = dtotal;
            lblTotal.InnerText = Total.ToString();
            Td1.Visible = true;

            btn.Visible = true;

        }

        protected void rbproqty_CheckedChanged(object sender, EventArgs e)
        {
            //gridPurchase.Visible = false;
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyprodqty(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyprodqty(sTableName, FromDate, ToDate);
            }
            gridcatqty.DataSource = ds1;
            gridcatqty.DataBind();

            // gridcatqty.Visible = true;

            decimal dtotal = 0;
            for (int i = 0; i < gridcatqty.Rows.Count; i++)
            {
                dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
            }
            decimal Total = dtotal;
            lblTotal.InnerText = Total.ToString();
            Td1.Visible = true;

            btn.Visible = true;

        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            //    if (rdbCustomer.Checked == true)
            //    {
            //        DataSet ds1 = objBs.sOrdebyVendor(sTableName, txtFromDate.Text, txtToDate.Text);
            //        gridPurchase.DataSource = ds1;
            //        gridPurchase.DataBind();
            //    }
            //    if (rbdPayMode.Checked == true)
            //    {
            //        DataSet ds1 = objBs.sorderPay(sTableName, txtFromDate.Text, txtToDate.Text);
            //        gridPurchase.DataSource = ds1;
            //        gridPurchase.DataBind();
            //    }

            if (sTableName == "admin")
            {
                if (rbdCtry.Checked == true)
                {
                    gridcatqty.Visible = false;
                    DataSet ds1 = objBs.ordebyCategory2return(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;

                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    gridcatqty.Visible = false;
                    DataSet ds1 = objBs.ordebyproduct2return(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.Visible = true;

                    Td1.Visible = false;
                }
                if (rbproqty.Checked == true)
                {
                    gridPurchase.Visible = false;
                    DataSet ds1 = objBs.ordebyprodqty(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();

                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }
                if (rbdcatqty.Checked == true)
                {
                    gridPurchase.Visible = false;
                    DataSet ds1 = objBs.ordebycatqty(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();

                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }

            }
            else
            {
                if (rbdCtry.Checked == true)
                {
                    gridcatqty.Visible = false;
                    DataSet ds1 = objBs.ordebyCategory2return(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;

                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    gridcatqty.Visible = false;
                    DataSet ds1 = objBs.ordebyproduct2return(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.Visible = true;

                    Td1.Visible = false;
                }
                if (rbproqty.Checked == true)
                {
                    gridPurchase.Visible = false;
                    DataSet ds1 = objBs.ordebyprodqty(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();

                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }
                if (rbdcatqty.Checked == true)
                {
                    gridPurchase.Visible = false;
                    DataSet ds1 = objBs.ordebycatqty(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();

                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }

                //    if (rbdBrnd.Checked == true)
                //    {
                //        DataSet ds1 = objBs.sorderBrand(sTableName, txtFromDate.Text, txtToDate.Text);
                //        gridPurchase.DataSource = ds1;
                //        gridPurchase.DataBind();
                //    }

            }
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            //    if (rdbCustomer.Checked == true)
            //    {
            //        DataSet ds1 = objBs.sOrdebyVendor(sTableName, txtFromDate.Text, txtToDate.Text);

            //        gridPurchase.DataSource = ds1;
            //        gridPurchase.DataBind();

            //    }
            //    if (rbdPayMode.Checked == true)
            //    {
            //        DataSet ds1 = objBs.sorderPay(sTableName, txtFromDate.Text, txtToDate.Text);
            //        gridPurchase.DataSource = ds1;
            //        gridPurchase.DataBind();
            //    }

            if (sTableName == "admin")
            {
                if (rbdCtry.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyCategory2return(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;
                    gridcatqty.Visible = false;
                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyproduct2return(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;
                    gridcatqty.Visible = false;
                    Td1.Visible = false;
                }
                if (rbproqty.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyprodqty(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();
                    gridPurchase.Visible = false;
                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }
                if (rbdcatqty.Checked == true)
                {
                    DataSet ds1 = objBs.ordebycatqty(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();
                    gridPurchase.Visible = false;
                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }
            }
            else
            {
                if (rbdCtry.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyCategory2return(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;
                    gridcatqty.Visible = false;
                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyproduct2return(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;
                    gridcatqty.Visible = false;
                    Td1.Visible = false;
                }
                if (rbproqty.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyprodqty(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();
                    gridPurchase.Visible = false;
                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }
                if (rbdcatqty.Checked == true)
                {
                    DataSet ds1 = objBs.ordebycatqty(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridcatqty.DataSource = ds1;
                    gridcatqty.DataBind();
                    gridPurchase.Visible = false;
                    gridcatqty.Visible = true;
                    decimal dtotal = 0;
                    for (int i = 0; i < gridcatqty.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridcatqty.Rows[i].Cells[1].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                    Td1.Visible = true;
                }
                //    if (rbdBrnd.Checked == true)
                //    {
                //        DataSet ds1 = objBs.sorderBrand(sTableName, txtFromDate.Text, txtToDate.Text);
                //        gridPurchase.DataSource = ds1;
                //        gridPurchase.DataBind();
                //    }

            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            if (rbdCtry.Checked == true)
            {
                GridView gvsales = new GridView();
                if (sTableName == "admin")
                {
                    gvsales.DataSource = objBs.ordebyCategory2return(sTableName, txtFromDate.Text, txtToDate.Text);
                }
                else
                {
                    gvsales.DataSource = objBs.ordebyCategory2return(sTableName, txtFromDate.Text, txtToDate.Text);
                }
                gvsales.AutoGenerateColumns = false;
                BoundField test3 = new BoundField();

                test3.DataField = "category";
                test3.HeaderText = "Category";
                gvsales.Columns.Add(test3);
                BoundField test4 = new BoundField();


                BoundField test = new BoundField();

                test.DataField = "BillNo";
                test.HeaderText = "Bill NO";
                gvsales.Columns.Add(test);
                BoundField test1 = new BoundField();

                test1.DataField = "BillDate";
                test1.HeaderText = "Bill Date";
                gvsales.Columns.Add(test1);
                BoundField test2 = new BoundField();

                test2.DataField = "LedgerName";
                test2.HeaderText = "Customer Name";
                gvsales.Columns.Add(test2);


                test4.DataField = "Definition";
                test4.HeaderText = "Item";
                gvsales.Columns.Add(test4);
                BoundField test7 = new BoundField();

                test7.DataField = "BrandName";
                test7.HeaderText = "Brand Name";
                gvsales.Columns.Add(test7);
                BoundField test5 = new BoundField();

                test5.DataField = "Quantity";
                test5.HeaderText = "Quantity";
                gvsales.Columns.Add(test5);
                BoundField test6 = new BoundField();

                test6.DataField = "UnitPrice";
                test6.HeaderText = "Unit Price";
                gvsales.Columns.Add(test6);
                BoundField test8 = new BoundField();

                test8.DataField = "Payment_Mode";
                test8.HeaderText = "Payment Type";
                gvsales.Columns.Add(test8);

                BoundField test9 = new BoundField();

                test9.DataField = "NetAmount";
                test9.HeaderText = " Total Amount";
                gvsales.Columns.Add(test9);

                gvsales.RowHeaderColumn.ToUpper();
                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseCategoryReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();

            }
            else if (rbdProduct.Checked == true)
            {

                GridView gvsales = new GridView();
                gvsales.DataSource = objBs.ordebyproduct2return(sTableName, txtFromDate.Text, txtToDate.Text);
                gvsales.AutoGenerateColumns = false;
                BoundField test4 = new BoundField();

                test4.DataField = "Definition";
                test4.HeaderText = "Item";
                gvsales.Columns.Add(test4);
                BoundField test3 = new BoundField();

                test3.DataField = "category";
                test3.HeaderText = "Category";
                gvsales.Columns.Add(test3);



                BoundField test = new BoundField();

                test.DataField = "BillNo";
                test.HeaderText = "Bill NO";
                gvsales.Columns.Add(test);
                BoundField test1 = new BoundField();

                test1.DataField = "BillDate";
                test1.HeaderText = "Bill Date";
                gvsales.Columns.Add(test1);
                BoundField test2 = new BoundField();

                test2.DataField = "LedgerName";
                test2.HeaderText = "Customer Name";
                gvsales.Columns.Add(test2);

                BoundField test7 = new BoundField();

                test7.DataField = "BrandName";
                test7.HeaderText = "Brand Name";
                gvsales.Columns.Add(test7);
                BoundField test5 = new BoundField();

                test5.DataField = "Quantity";
                test5.HeaderText = "Quantity";
                gvsales.Columns.Add(test5);
                BoundField test6 = new BoundField();

                test6.DataField = "UnitPrice";
                test6.HeaderText = "Unit Price";
                gvsales.Columns.Add(test6);
                BoundField test8 = new BoundField();

                test8.DataField = "Payment_Mode";
                test8.HeaderText = "Payment Type";
                gvsales.Columns.Add(test8);

                BoundField test9 = new BoundField();

                test9.DataField = "NetAmount";
                test9.HeaderText = " Total Amount";
                gvsales.Columns.Add(test9);

                gvsales.RowHeaderColumn.ToUpper();
                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseProductReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
            }

        }
        protected void gridcatqty_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }
        protected void gridcatqty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gridcatqty_RowCreated1(object sender, GridViewRowEventArgs e)
        {

            #region 5
            if (rbdBrnd.Checked == true)
            {

                {


                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "category") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "category").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "category") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "category") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "category").ToString();
                        cell.ColumnSpan = 9;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                    #endregion
                    if (IsSubTotalRowNeedToAdd)
                    {
                        #region Adding Sub Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row          
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell          
                        TableCell cell = new TableCell();
                        cell.Text = "Sub Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 6;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column            
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblSubTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "SubTotalRowStyle";
                        //row.Cells.Add(cell);
                        //Adding Discount Column         
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "category") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "category").ToString();
                            cell.ColumnSpan = 9;
                            cell.CssClass = "GroupHeaderStyle";
                            row.Cells.Add(cell);
                            gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                            intSubTotalIndex++;
                        }
                        #endregion
                        #region Reseting the Sub Total Variables
                        dblSubTotalUnitPrice = 0;
                        dblSubTotalQuantity = 0;
                        dblSubTotalDiscount = 0;

                        #endregion
                    }
                    if (IsGrandTotalRowNeedtoAdd)
                    {
                        #region Grand Total Row
                        GridView gridPurchase = (GridView)sender;
                        // Creating a Row      
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell           
                        TableCell cell = new TableCell();
                        cell.Text = "Grand Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 6;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column           
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalQuantity);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);
                        //Adding Unit Price Column          
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblGrandTotalUnitPrice);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "GrandTotalRowStyle";
                        //row.Cells.Add(cell);
                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandTotalDiscount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid     
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
                        #endregion
                    }
                }
            }
            #endregion


        }

        protected void gridcatqty_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (rbdBrnd.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "category").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());


                    dblSubTotalQuantity += dblQuantity;

                    dblGrandTotalQuantity += dblQuantity;

                }
            }
        }


    }
}