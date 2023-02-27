using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;


namespace Billing.Accountsbootstrap
{
    public partial class purchasesummary : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        DataSet ds = new DataSet();
        string sTableName = "";
        string strPreviousRowID = string.Empty;
        // To keep track the Index of Group Total    
        int intSubTotalIndex = 1;
        double dblSubTotalUnitPrice = 0;
        double dblSubTotalQuantity = 0;
        double dblSubTotalDiscount = 0;
        double dblSubTotalAmount = 0;
        double dblSubSalesAmount = 0;
        // To temporarily store Grand Total    
        double dblGrandTotalUnitPrice = 0;
        double dblGrandTotalQuantity = 0;
        double dblGrandTotalDiscount = 0;
        double dblGrandTotalAmount = 0;
        double dblGrandSalesAmount = 0;

        string BranchNAme = "";
        string StoreName = "";
        string Password = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();
          
            if (!IsPostBack)
            {
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

                DataSet dssubcompany = objBs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    drpsubcompany.DataSource = dssubcompany.Tables[0];
                    drpsubcompany.DataTextField = "CustomerName";
                    drpsubcompany.DataValueField = "subComapanyID";
                    drpsubcompany.DataBind();
                    drpsubcompany.Items.Insert(0, "All");
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
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngredientID") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "IngredientID").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngredientID") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngredientID") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Category : " + DataBinder.Eval(e.Row.DataItem, "Ingredientname").ToString();
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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubSalesAmount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "IngredientID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Category : " + DataBinder.Eval(e.Row.DataItem, "Ingredientname").ToString();
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
                        dblSubSalesAmount = 0;

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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandSalesAmount);
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
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngredientID") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "IngredientID").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngredientID") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngredientID") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Ingredientname").ToString();
                        cell.ColumnSpan = 10;
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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubSalesAmount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "IngredientID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Ingredientname").ToString();
                            cell.ColumnSpan = 10;
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
                        dblSubSalesAmount = 0;

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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandSalesAmount);
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
            #region 6
            if (rbdSupp.Checked == true)
            {

                {


                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Supplier") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "Supplier").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Supplier") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Supplier") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Supplier Name : " + DataBinder.Eval(e.Row.DataItem, "LedgerName").ToString();
                        cell.ColumnSpan = 10;
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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubSalesAmount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "Supplier") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Supplier Name : " + DataBinder.Eval(e.Row.DataItem, "LedgerName").ToString();
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
                        dblSubSalesAmount = 0;

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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandSalesAmount);
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
            #region 7
            if (rbdExpDate.Checked == true)
            {
                {
                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "ExpiryDate") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "ExpiryDate").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "ExpiryDate") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "ExpiryDate") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Expired Date : " + DataBinder.Eval(e.Row.DataItem, "ExpiryDate").ToString();
                        cell.ColumnSpan = 10;
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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubSalesAmount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "ExpiryDate") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Expired Date : " + DataBinder.Eval(e.Row.DataItem, "ExpiryDate").ToString();
                            cell.ColumnSpan = 10;
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
                        dblSubSalesAmount = 0;

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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandSalesAmount);
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
            #region 8
            if (rbdcompany.Checked == true)
            {
                {
                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "subComapanyID") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "subComapanyID").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "subComapanyID") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "subComapanyID") != null))
                    {
                        GridView gridPurchase = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "Company Name : " + DataBinder.Eval(e.Row.DataItem, "compname").ToString();
                        cell.ColumnSpan = 10;
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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblSubSalesAmount);
                        cell.HorizontalAlign = HorizontalAlign.Right;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding the Row at the RowIndex position in the Grid      
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "subComapanyID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Company Name : " + DataBinder.Eval(e.Row.DataItem, "compname").ToString();
                            cell.ColumnSpan = 10;
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
                        dblSubSalesAmount = 0;

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


                        cell = new TableCell();
                        cell.Text = string.Format("{0:0.00}", dblGrandSalesAmount);
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

                    double SalesAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesAmount").ToString());

                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblSubSalesAmount += SalesAmount;

                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;
                    dblGrandSalesAmount += SalesAmount;
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
                    double SalesAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesAmount").ToString());

                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;


                    dblGrandSalesAmount += SalesAmount;
                    dblSubSalesAmount += SalesAmount;

                }
            }
            else if (rbdProduct.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "IngredientID").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());

                    double SalesAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesAmount").ToString());
                    dblSubSalesAmount += SalesAmount;
                    dblGrandSalesAmount += SalesAmount;

                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }
            else if (rbdSupp.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "Supplier").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());

                    double SalesAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesAmount").ToString());
                    dblSubSalesAmount += SalesAmount;
                    dblGrandSalesAmount += SalesAmount;

                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }
            else if (rbdExpDate.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "ExpiryDate").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());

                    double SalesAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesAmount").ToString());
                    dblSubSalesAmount += SalesAmount;
                    dblGrandSalesAmount += SalesAmount;

                    dblSubTotalUnitPrice += dblUnitPrice;
                    dblSubTotalQuantity += dblQuantity;
                    dblSubTotalDiscount += dblDiscount;
                    dblGrandTotalUnitPrice += dblUnitPrice;
                    dblGrandTotalQuantity += dblQuantity;
                    dblGrandTotalDiscount += dblDiscount;

                }
            }
            else if (rbdcompany.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "subComapanyID").ToString();
                    double dblQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());
                    double dblUnitPrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate").ToString());
                    double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());

                    double SalesAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesAmount").ToString());
                    dblSubSalesAmount += SalesAmount;
                    dblGrandSalesAmount += SalesAmount;

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
           
            if (rbdCtry.Checked == true)
            {
                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                string ToDate = sTO.ToString("yyyy-MM-dd");
                GridView gvsales = new GridView();
                DataSet da = objBs.ordebyCategory2(sTableName, FromDate, ToDate);
                

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

                test10.DataField = "SalesAmount";
                test10.HeaderText = "SalesAmount";
                gvsales.Columns.Add(test10);

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
                gvsales.DataSource = objBs.ordebyproduct2(sTableName, FromDate, ToDate);
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

                test10.DataField = "SalesAmount";
                test10.HeaderText = "SalesAmount";
                gvsales.Columns.Add(test10);


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

            else if(rbproqty.Checked==true)
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




                gridview.DataSource = objBs.ordebyprodqty(sTableName, FromDate, ToDate);
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
                gvsales.DataSource = objBs.ordebycatqty(sTableName, FromDate, ToDate);
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
            else if (rbdBrnd.Checked == true)
            {
                GridView gvsales = new GridView();
               // gvsales.DataSource = objBs.ordebyBrand2(sTableName, txtFromDate.Text, txtToDate.Text);
                gvsales.DataSource = objBs.QtySummary(sTableName, txtFromDate.Text, txtToDate.Text);
                gvsales.AutoGenerateColumns = false;
                //BoundField test7 = new BoundField();

                //test7.DataField = "BrandName";
                //test7.HeaderText = "Brand Name";
                //gvsales.Columns.Add(test7);
                BoundField test3 = new BoundField();
                test3.DataField = "category";
                test3.HeaderText = "Category";
                gvsales.Columns.Add(test3);



                BoundField test4 = new BoundField();

                test4.DataField = "Definition";
                test4.HeaderText = "Item";
                gvsales.Columns.Add(test4);
             

                



                //BoundField test = new BoundField();

                //test.DataField = "BillNo";
                //test.HeaderText = "Bill NO";
                //gvsales.Columns.Add(test);
                //BoundField test1 = new BoundField();

                //test1.DataField = "BillDate";
                //test1.HeaderText = "Bill Date";
                //gvsales.Columns.Add(test1);
                //BoundField test2 = new BoundField();

                //test2.DataField = "LedgerName";
                //test2.HeaderText = "Customer Name";
                //gvsales.Columns.Add(test2);


                BoundField test5 = new BoundField();

                test5.DataField = "Qty";
                test5.HeaderText = "Qty";
                gvsales.Columns.Add(test5);
                //BoundField test6 = new BoundField();

                //test6.DataField = "UnitPrice";
                //test6.HeaderText = "Unit Price";
                //gvsales.Columns.Add(test6);
                //BoundField test8 = new BoundField();

                //test8.DataField = "Payment_Mode";
                //test8.HeaderText = "Payment Type";
                //gvsales.Columns.Add(test8);

                //BoundField test9 = new BoundField();

                //test9.DataField = "NetAmount";
                //test9.HeaderText = " Total Amount";
                //gvsales.Columns.Add(test9);

                gvsales.RowHeaderColumn.ToUpper();
                gvsales.HeaderStyle.BackColor = System.Drawing.Color.BurlyWood;
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=PurchaseBrnadReport" + "-" + DateTime.Now.ToString("dd/MM/yyyy") + ".xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
            }
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
                ds1 = objBs.ordebyCategory2(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyCategory2(sTableName, FromDate, ToDate);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;

            //btn.Visible = true;
            btn.Visible = false;
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
        }

        protected void rdbCompany_OnCheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyproduct2(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebycompany2PurReport(sTableName, FromDate, ToDate, drpsubcompany.SelectedValue);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;


            //btn.Visible = true;
            btn.Visible = false;
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
        }

        protected void rbdExpDate_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyproduct2(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyexpdate2PurReport(sTableName, FromDate, ToDate, drpsubcompany.SelectedValue);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;


            //btn.Visible = true;
            btn.Visible = false;
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
        }

        protected void rbdSupp_CheckedChanged(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            if (sTableName == "admin")
            {
                ds1 = objBs.ordebyproduct2(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebysupplier2PurReport(sTableName, FromDate, ToDate, drpsubcompany.SelectedValue);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;


            //btn.Visible = true;
            btn.Visible = false;
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;

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
                ds1 = objBs.ordebyproduct2(ddlBranch.SelectedValue, FromDate, ToDate);
            }
            else
            {
                ds1 = objBs.ordebyproduct2PurReport(sTableName, FromDate, ToDate, drpsubcompany.SelectedValue);
            }
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;
            Td1.Visible = false;


            //btn.Visible = true;
            btn.Visible = false;

            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
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

            //btn.Visible = true;
            btn.Visible = false;
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
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

            //btn.Visible = true;
            btn.Visible = false;

            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
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

            //btn.Visible = true;
            btn.Visible = false;

            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            gridPurchase.Caption = caption;
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
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txtFromDate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txtFromDate.Text = "";

                    return;
                }
            }

            if(sTableName=="admin")
            {
                if (rbdCtry.Checked == true)
                {
                    gridcatqty.Visible = false;
                    DataSet ds1 = objBs.ordebyCategory2(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;

                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    gridcatqty.Visible = false;
                    DataSet ds1 = objBs.ordebyproduct2(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
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
                DataSet ds1 = objBs.ordebyCategory2(sTableName, txtFromDate.Text, txtToDate.Text);
                gridPurchase.DataSource = ds1;
                gridPurchase.DataBind();
                gridPurchase.Visible = true;

                Td1.Visible = false;

            }

            if (rbdProduct.Checked == true)
            {
                gridcatqty.Visible = false;
                DataSet ds1 = objBs.ordebyproduct2(sTableName, txtFromDate.Text, txtToDate.Text);
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
                    DataSet ds1 = objBs.ordebyCategory2(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;
                    gridcatqty.Visible = false;
                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyproduct2(ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);
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
                    DataSet ds1 = objBs.ordebyCategory2(sTableName, txtFromDate.Text, txtToDate.Text);
                    gridPurchase.DataSource = ds1;
                    gridPurchase.DataBind();
                    gridPurchase.Visible = true;
                    gridcatqty.Visible = false;
                    Td1.Visible = false;

                }

                if (rbdProduct.Checked == true)
                {
                    DataSet ds1 = objBs.ordebyproduct2(sTableName, txtFromDate.Text, txtToDate.Text);
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
                    gvsales.DataSource = objBs.ordebyCategory2(sTableName, txtFromDate.Text, txtToDate.Text);
                }
                else
                {
                    gvsales.DataSource = objBs.ordebyCategory2(sTableName, txtFromDate.Text, txtToDate.Text);
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
                gvsales.DataSource = objBs.ordebyproduct2(sTableName, txtFromDate.Text, txtToDate.Text);
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
                        cell.ColumnSpan = 3;
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
                        cell.ColumnSpan = 2;
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
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblSubTotalDiscount);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "SubTotalRowStyle";
                        //row.Cells.Add(cell);

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
                            cell.ColumnSpan = 3;
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
                        cell.ColumnSpan = 2;
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
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblGrandTotalDiscount);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "GrandTotalRowStyle";
                        //row.Cells.Add(cell);

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

        protected void btnPrintFromCodeBehind_Click(object sender, EventArgs e)
        {
            try
            {
                //   if (rdbtype.SelectedValue == "1")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
                    string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                    gridPurchase.Caption = caption;
                }

            }
            catch { }
        }
        

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            ExportToPDF(sender, e);
        }
        protected void ExportToPDF(object sender, EventArgs e)
        {
            //if (rdbtype.SelectedValue == "1")
            {
                if (gridPurchase.Rows.Count > 0)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        #region
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            gridPurchase.RenderControl(hw);

                            gridPurchase.HeaderRow.Style.Add("width", "6%");
                            gridPurchase.HeaderRow.Style.Add("font-size", "8px");
                            gridPurchase.Style.Add("text-decoration", "none");
                            gridPurchase.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                            gridPurchase.Style.Add("font-size", "6px");

                            StringReader sr = new StringReader(sw.ToString());
                            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=StockReport.pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);

                            Response.Write(pdfDoc);
                            Response.End();
                        }

                        #endregion
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Data.');", true);
                    return;
                }
            }



        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

       
    }
}