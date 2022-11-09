using System;
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
    public partial class TwoReports : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        DataSet ds = new DataSet();
        string sTableName = "";
        double gnddtot = 0;
        string strPreviousRowID = string.Empty;
        string strPreviousRowID1 = string.Empty;
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
        decimal total_denomination = 0;

        Double total = 0.0;

        string UserID = "";
        string IsSuperAdmin = "";

        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string Phone = "";
        string Mobile = "";

        double gndqtytot = 0, gndacttot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Session["User"].ToString();
            lblUser.Text = Session["Username"].ToString();
            UserID = Session["UserID"].ToString();
            IsSuperAdmin = Session["IsSuperAdmin"].ToString();


            sStore = Session["Store"].ToString();
            sAddress = Session["Address"].ToString();
            sTin = Session["TIN"].ToString();
            //Phone = Session["PH"].ToString();
            //Mobile = Session["CELL"].ToString();


            if (!IsPostBack)
            {
               // if (IsSuperAdmin == "1")
               // {
                    txtFromDate.Enabled = true;
                    txtToDate.Enabled = true;
               // }
               // else
              //  {
                   // txtFromDate.Enabled = false;
                   // txtToDate.Enabled = false;
              //  }
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
                //txtFromDate.Text = new DateTime(today.Year, today.Month, 1).ToString("MM/dd/yyyy");
                txtToDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
                txtFromDate.Text = DateTime.Today.ToString("MM/dd/yyyy");
                DateTime utc = DateTime.UtcNow;
                // DateTimeOffset localServerTime = DateTimeOffset.Now;

                var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(utc, easternZone);


                TimeZone zone = TimeZone.CurrentTimeZone;
                DaylightTime time = zone.GetDaylightChanges(DateTime.Today.Year);
                //// DateTime eastern = TimeZoneInfo.ConvertTimeFromUtc(utc, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
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
                        cell.ColumnSpan = 8;
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
                        if (DataBinder.Eval(e.Row.DataItem, "CategoryID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Category : " + DataBinder.Eval(e.Row.DataItem, "category").ToString();
                            cell.ColumnSpan = 8;
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
                        cell.ColumnSpan = 8;
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
                        if (DataBinder.Eval(e.Row.DataItem, "SubCategoryID") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "Product Name : " + DataBinder.Eval(e.Row.DataItem, "Definition").ToString();
                            cell.ColumnSpan = 8;
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
            else if (rbdBrnd.Checked == true)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "BrandId").ToString();
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
            sTableName = Session["User"].ToString();
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
                DataSet ds1 = objBs.ordebycatqtyDay(sTableName, FromDate, ToDate);
                DataGrid gvsales = new DataGrid();

                // gvsales.RowHeaderColumn.ToUpper();
                gvsales.DataSource = objBs.ordebycatqtyDay(sTableName, FromDate, ToDate);
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
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            DataSet ds1 = objBs.ordebyCategory2(sTableName, FromDate, ToDate);
            gridPurchase.DataSource = ds1;
            gridPurchase.DataBind();

            gridPurchase.Visible = true;


            gridPurchase.Visible = true;
            gridcatqty.Visible = false;
            gvdepartment.Visible = false;
            gridcontribution.Visible = false;


            Td1.Visible = false;

            btn.Visible = true;
        }

        protected void rbdProduct_CheckedChanged(object sender, EventArgs e)
        {
            //DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            //string FromDate = sFrom.ToString("yyyy-MM-dd");
            //DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            //string ToDate = sTO.ToString("yyyy-MM-dd");
            //gridcatqty.Visible = false;
            //DataSet ds1 = objBs.ordebyproduct2(sTableName, FromDate, ToDate);
            //gridPurchase.DataSource = ds1;
            //gridPurchase.DataBind();

            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            // string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            //  string ToDate = sTO.ToString("yyyy-MM-dd");
            gridcatqty.Visible = false;
            DataSet ds1 = objBs.ordebyproduct2jj(sTableName, sFrom, sTO);


            gridcatqty.DataSource = ds1;
            gridcatqty.DataBind();
            gridcatqty.Visible = true;
            Td1.Visible = false;
            gridPurchase.Visible = false;

          //  gvsummary.Visible = false;

            gridPurchase.Visible = true;
            gridcatqty.Visible = true;
            gvdepartment.Visible = false;
            divDepartment.Visible = true;
            gridcontribution.Visible = true;
            Td1.Visible = true;


            btn.Visible = true;

        }

        protected void rbdBrnd_CheckedChanged(object sender, EventArgs e)
        {

            //DataSet ds1 = objBs.sorderBrand(sTableName, txtFromDate.Text, txtToDate.Text);
            //gridPurchase.DataSource = ds1;
            //gridPurchase.DataBind();

        }

        protected void rbdcatqty_CheckedChanged(object sender, EventArgs e)
        {
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");
            //  gridPurchase.Visible = false;
            DataSet ds1 = objBs.ordebycatqtyDay(sTableName, FromDate, ToDate);
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


            gridPurchase.Visible = false;
            gridcatqty.Visible = true;
            gvdepartment.Visible = false;
            gridcontribution.Visible = true;

            btn.Visible = true;

        }

        protected void rbproqty_CheckedChanged(object sender, EventArgs e)
        {
            //gridPurchase.Visible = false;

            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-dd-MM");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-dd-MM");
            DataSet ds1 = objBs.ordebyprodqty(sTableName, FromDate, ToDate);
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

            gridPurchase.Visible = false;
            gridcatqty.Visible = true;
            gvdepartment.Visible = false;
            gridcontribution.Visible = true;

        }


        protected void rbdepartment_CheckedChanged(object sender, EventArgs e)
        {
            //DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            //string FromDate = sFrom.ToString("yyyy-MM-dd");
            //DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            //string ToDate = sTO.ToString("yyyy-MM-dd");
            //gridcatqty.Visible = false;
            //gridPurchase.Visible = false;
            //DataSet ds1 = objBs.ordeby_Department(sTableName, FromDate, ToDate);
            //gvdepartment.DataSource = ds1;
            //gvdepartment.DataBind();

            //btn.Visible = true;
            //gvdepartment.Visible = true;
            //gridcontribution.Visible = true;
            //Td1.Visible = true;
            //lblTotal.Visible = true;

            //double overalltotal = 0;

            //DataSet dsalescont = objBs.ordeby_salescontribution(sTableName, FromDate, ToDate);
            //if (dsalescont.Tables[0].Rows.Count > 0)
            //{
            //    DataSet dtotalsales = objBs.ordeby_Totalsalescontribution(sTableName, FromDate, ToDate);
            //    if (dtotalsales.Tables[0].Rows.Count > 0)
            //    {
            //        overalltotal = Convert.ToDouble(dtotalsales.Tables[0].Rows[0]["Amount"]);
            //    }
            //    else
            //    {
            //        overalltotal = 0;
            //    }


            //    DataTable dt = new DataTable();
            //    DataRow dr;
            //    dt.Columns.Add("Department");
            //    dt.Columns.Add("Total");
            //    dt.Columns.Add("Perc");

            //    for (int i = 0; i < dsalescont.Tables[0].Rows.Count; i++)
            //    {
            //        double percc = 0;

            //        dr = dt.NewRow();
            //        dr["Department"] = dsalescont.Tables[0].Rows[i]["Department"].ToString();
            //        dr["Total"] = dsalescont.Tables[0].Rows[i]["Amount"].ToString();
            //        percc = ((Convert.ToDouble(dsalescont.Tables[0].Rows[i]["Amount"]) / overalltotal) * 100);

            //        dr["Perc"] = percc.ToString("f2");

            //        dt.Rows.Add(dr);
            //    }

            //    gridcontribution.DataSource = dt;
            //    gridcontribution.DataBind();


            //}

            //DataSet dsettotal = objBs.ordeby_DepartmentforTotal(sTableName, FromDate, ToDate);
            //if (dsettotal.Tables[0].Rows.Count > 0)
            //{
            //    lblTotal.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["nettot"]).ToString("f2");
            //    lblDiscount.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["disc"]).ToString("f2");
            //    lblTax.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["vatAmount"]).ToString("f2");
            //    lblserviceTax.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["serviceTax"]).ToString("f2");
            //    lblgndtot.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");
            //}





            //gridPurchase.Visible = false;
            //gridcatqty.Visible = false;
            //gvdepartment.Visible = true;
            //gridcontribution.Visible = true;

            //---- New----------------
            //if (IsSuperAdmin == "1" || IsSuperAdmin == "10")
            //{

                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                lblfromdt.Text = txtFromDate.Text;
                // string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                lbltodt.Text = txtToDate.Text;
                // string ToDate = sTO.ToString("yyyy-MM-dd");

                DataSet ds1 = objBs.ordeby_Department(sTableName, sFrom, sTO);
                gvdepartment.DataSource = ds1;
                gvdepartment.DataBind();


                readingreport.Visible = false;
                consilidated.Visible = false;
                divDepartment.Visible = true;

                double overalltotal = 0;

                DataSet dsalescont = objBs.ordeby_salescontribution(sTableName, sFrom, sTO);
                if (dsalescont.Tables[0].Rows.Count > 0)
                {
                    DataSet dtotalsales = objBs.ordeby_Totalsalescontribution(sTableName, sFrom, sTO);
                    if (dtotalsales.Tables[0].Rows.Count > 0)
                    {
                        overalltotal = Convert.ToDouble(dtotalsales.Tables[0].Rows[0]["Amount"]);
                    }
                    else
                    {
                        overalltotal = 0;
                    }


                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add("Department");
                    dt.Columns.Add("Total");
                    dt.Columns.Add("Perc");

                    for (int i = 0; i < dsalescont.Tables[0].Rows.Count; i++)
                    {
                        double percc = 0;

                        dr = dt.NewRow();
                        dr["Department"] = dsalescont.Tables[0].Rows[i]["Department"].ToString();
                        dr["Total"] = dsalescont.Tables[0].Rows[i]["Amount"].ToString();
                        percc = ((Convert.ToDouble(dsalescont.Tables[0].Rows[i]["Amount"]) / overalltotal) * 100);

                        dr["Perc"] = percc.ToString("f2");

                        dt.Rows.Add(dr);
                    }

                    gridcontribution.DataSource = dt;
                    gridcontribution.DataBind();


                }

                DataSet dsettotal = objBs.ordeby_DepartmentforTotal(sTableName, sFrom, sTO);
                if (dsettotal.Tables[0].Rows.Count > 0)
                {
                    lblTotal.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["nettot"]).ToString("f2");
                    lblDiscount.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["disc"]).ToString("f2");
                    lblTax.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["vatAmount"]).ToString("f2");
                    lblserviceTax.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["serviceTax"]).ToString("f2");
                    lblgndtot.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");
                }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('If You Need This.Please Contact Administrator.Thank You!!!.');", true);
            //    return;
            //}





        }


        protected void gridContri_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double tot = Convert.ToDouble(e.Row.Cells[1].Text);
                gnddtot = gnddtot + tot;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Sales";
                e.Row.Cells[2].Text = gnddtot.ToString("f2");
            }
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {

            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            llbfrmdt.Text = txtFromDate.Text;
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            llbtodt.Text = txtToDate.Text;
            string ToDate = sTO.ToString("yyyy-MM-dd");
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
            if (rbdCtry.Checked == true)
            {
                gridcatqty.Visible = false;
                DataSet ds1 = objBs.ordebyCategory2(sTableName, FromDate, ToDate);
                gridPurchase.DataSource = ds1;
                gridPurchase.DataBind();
                gridPurchase.Visible = true;

                Td1.Visible = false;


                gridPurchase.Visible = true;
                gridcatqty.Visible = false;
                gvdepartment.Visible = false;
                gridcontribution.Visible = false;

            }

            if (rbdProduct.Checked == true)
            {
                gridcatqty.Visible = false;
                DataSet ds1 = objBs.ordebyproduct2(sTableName, FromDate, ToDate);
                gridPurchase.DataSource = ds1;
                gridPurchase.Visible = true;

                gridPurchase.Visible = true;
                gridcatqty.Visible = false;
                gvdepartment.Visible = false;
                gridcontribution.Visible = false;

                Td1.Visible = false;
            }
            if (rbproqty.Checked == true)
            {
                gridPurchase.Visible = false;
                DataSet ds1 = objBs.ordebyprodqty(sTableName, FromDate, ToDate);
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

                gridPurchase.Visible = false;
                gridcatqty.Visible = true;
                gvdepartment.Visible = false;
                gridcontribution.Visible = true;

            }
            if (rbdcatqty.Checked == true)
            {
                gridPurchase.Visible = false;
                DataSet ds1 = objBs.ordebycatqtyDay(sTableName, FromDate, ToDate);
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

                gridPurchase.Visible = false;
                gridcatqty.Visible = true;
                gvdepartment.Visible = false;
                gridcontribution.Visible = true;
            }

            //    if (rbdBrnd.Checked == true)
            //    {
            //        DataSet ds1 = objBs.sorderBrand(sTableName, txtFromDate.Text, txtToDate.Text);
            //        gridPurchase.DataSource = ds1;
            //        gridPurchase.DataBind();
            //    }


        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            llbfrmdt.Text = txtFromDate.Text;
            string FromDate = sFrom.ToString("yyyy-MM-dd");
            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            llbtodt.Text = txtToDate.Text;
            string ToDate = sTO.ToString("yyyy-MM-dd");

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
            if (rbdCtry.Checked == true)
            {
                gridcatqty.Visible = false;
                DataSet ds1 = objBs.ordebyCategory2(sTableName, FromDate, ToDate);
                gridPurchase.DataSource = ds1;
                gridPurchase.DataBind();
                gridPurchase.Visible = true;

                Td1.Visible = false;


                gridPurchase.Visible = true;
                gridcatqty.Visible = false;
                gvdepartment.Visible = false;
                gridcontribution.Visible = false;

            }

            if (rbdProduct.Checked == true)
            {
                gridcatqty.Visible = false;
                DataSet ds1 = objBs.ordebyproduct2(sTableName, FromDate, ToDate);
                gridPurchase.DataSource = ds1;
                gridPurchase.Visible = true;

                gridPurchase.Visible = true;
                gridcatqty.Visible = false;
                gvdepartment.Visible = false;
                gridcontribution.Visible = false;

                Td1.Visible = false;
            }
            if (rbproqty.Checked == true)
            {
                gridPurchase.Visible = false;
                DataSet ds1 = objBs.ordebyprodqty(sTableName, FromDate, ToDate);
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

                gridPurchase.Visible = false;
                gridcatqty.Visible = true;
                gvdepartment.Visible = false;
                gridcontribution.Visible = true;

            }
            if (rbdcatqty.Checked == true)
            {
                gridPurchase.Visible = false;
                DataSet ds1 = objBs.ordebycatqtyDay(sTableName, FromDate, ToDate);
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

                gridPurchase.Visible = false;
                gridcatqty.Visible = true;
                gvdepartment.Visible = false;
                gridcontribution.Visible = true;
            }
            //    if (rbdBrnd.Checked == true)
            //    {
            //        DataSet ds1 = objBs.sorderBrand(sTableName, txtFromDate.Text, txtToDate.Text);
            //        gridPurchase.DataSource = ds1;
            //        gridPurchase.DataBind();
            //    }


        }

        protected void btn_Click(object sender, EventArgs e)
        {
            sTableName = Session["User"].ToString();
            txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            if (rbdCtry.Checked == true)
            {
                GridView gvsales = new GridView();
                gvsales.DataSource = objBs.ordebyCategory2(sTableName, txtFromDate.Text, txtToDate.Text);
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double totqty = Convert.ToDouble(e.Row.Cells[1].Text);
                double totactqty = Convert.ToDouble(e.Row.Cells[2].Text);
                gndqtytot = gndqtytot + totqty;
                gndacttot = gndacttot + totactqty;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = gndqtytot.ToString();
                e.Row.Cells[2].Text = gndacttot.ToString();
            }
        }



        protected void gvdepartment_RowCreated(object sender, GridViewRowEventArgs e)
        {


            #region 5
            if (rbdepartment.Checked == true)
            {

                {


                    //----------start----------//
                    bool IsSubTotalRowNeedToAdd = false;
                    bool IsGrandTotalRowNeedtoAdd = false;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "categoryid") != null))
                        if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "categoryid").ToString())
                            IsSubTotalRowNeedToAdd = true;
                    if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "categoryid") == null))
                    {
                        IsSubTotalRowNeedToAdd = true;
                        IsGrandTotalRowNeedtoAdd = true;
                        intSubTotalIndex = 0;
                    }
                    #region Inserting first Row and populating fist Group Header details
                    if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "categoryid") != null))
                    {
                        GridView gvdepartment = (GridView)sender;
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        TableCell cell = new TableCell();
                        cell.Text = "DEPARTMENT: " + DataBinder.Eval(e.Row.DataItem, "Department").ToString();
                        cell.ColumnSpan = 8;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gvdepartment.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }
                    #endregion
                    if (IsSubTotalRowNeedToAdd)
                    {
                        #region Adding Sub Total Row
                        GridView gvdepartment = (GridView)sender;
                        // Creating a Row          
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell          
                        TableCell cell = new TableCell();
                        cell.Text = "Sub Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 3;
                        cell.CssClass = "SubTotalRowStyle";
                        row.Cells.Add(cell);

                        ////Adding Quantity Column            
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblSubTotalQuantity);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "SubTotalRowStyle";
                        //row.Cells.Add(cell);
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
                        gvdepartment.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                        #endregion
                        #region Adding Next Group Header Details
                        if (DataBinder.Eval(e.Row.DataItem, "categoryid") != null)
                        {
                            row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                            cell = new TableCell();
                            cell.Text = "DEPARTMENT: " + DataBinder.Eval(e.Row.DataItem, "Department").ToString();
                            cell.ColumnSpan = 4;
                            cell.CssClass = "GroupHeaderStyle";
                            row.Cells.Add(cell);
                            gvdepartment.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
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
                        GridView gvdepartment = (GridView)sender;
                        // Creating a Row      
                        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        //Adding Total Cell           
                        TableCell cell = new TableCell();
                        cell.Text = "Grand Total";
                        cell.HorizontalAlign = HorizontalAlign.Left;
                        cell.ColumnSpan = 3;
                        cell.CssClass = "GrandTotalRowStyle";
                        row.Cells.Add(cell);

                        //Adding Quantity Column           
                        //cell = new TableCell();
                        //cell.Text = string.Format("{0:0.00}", dblGrandTotalQuantity);
                        //cell.HorizontalAlign = HorizontalAlign.Right;
                        //cell.CssClass = "GrandTotalRowStyle";
                        //row.Cells.Add(cell);
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
                        gvdepartment.Controls[0].Controls.AddAt(e.Row.RowIndex, row);
                        #endregion
                    }
                }
            }
            #endregion
        }
        protected void gvdepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "categoryid").ToString();
                double dblDiscount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());

                dblSubTotalDiscount += dblDiscount;

                dblGrandTotalDiscount += dblDiscount;
            }
        }


        #region READING REPORT
        protected void reading_checked(object sender, EventArgs e)
        {
            //if (IsSuperAdmin == "1" || IsSuperAdmin == "10")
            //{
                readingreport.Visible = true;
                consilidated.Visible = false;
                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                llbfrmdt.Text = txtFromDate.Text;
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                llbtodt.Text = txtToDate.Text;
                string ToDate = sTO.ToString("yyyy-MM-dd");

                lbluse.Text = lblUser.Text;
                // lblstart.Text = "1";


                // COMPANY DETAILS


                lblcompanyname.Text = sStore;
                lblcompanyarea.Text = sAddress;
                //    lblcompanyaddress.Text = sAddress;

                // SET MAX BILLNO
                DataSet dmaxfirstandsecond = objBs.getmaxbillno(sTableName, FromDate, ToDate);
                if (dmaxfirstandsecond.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dmaxfirstandsecond.Tables[0].Rows.Count; i++)
                    {

                        lblstart.Text = dmaxfirstandsecond.Tables[0].Rows[0]["Billno"].ToString();
                        lblend.Text = dmaxfirstandsecond.Tables[0].Rows[1]["Billno"].ToString();
                    }

                }
                double exp = 0;

                DataSet dexprense = objBs.AllExpensesumwise(sTableName, FromDate, ToDate);
                if (dexprense.Tables[0].Rows.Count > 0)
                {
                    exp = Convert.ToDouble(dexprense.Tables[0].Rows[0]["Amnt"]);
                    lblexpense.Text = exp.ToString("f2");
                }



                //GET ALL VALUE
                DataSet dsettotal = objBs.ordeby_DepartmentforTotal(sTableName, sFrom, sTO);
                if (dsettotal.Tables[0].Rows.Count > 0)
                {
                    lblamount.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["nettot"]).ToString("f2");
                    lblDiscount.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["disc"]).ToString("f2");
                    lblTax.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["vatAmount"]).ToString("f2");
                    lblserviceTax.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["serviceTax"]).ToString("f2");
                    lblbtotal.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");
                    lbltotalbal.Text = (Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]) - exp).ToString("f2");
                }

                //DENOMINATION
                #region Denomination
                int thou = 0, Fivehun = 0, hund = 0, fiftys = 0, twenty = 0, tens = 0, Fives = 0, twos = 0, ones = 0, coins = 0;
                decimal thou_t = 0, Fivehun_t = 0, hund_t = 0, fiftys_t = 0, twenty_t = 0, tens_t = 0, Fives_t = 0, twos_t = 0, ones_t = 0;
                double coins_t = 0;
                DataSet ds_denomination = objBs.check_denomination(sTableName, ToDate);
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
                    coins_t = (0.50) * coin_d;
                    coins_t = Math.Round(coins_t, 2);
                    lblcoinss.Text = Convert.ToString(coins_t);

                    total_denomination = Convert.ToDecimal(ds_denomination.Tables[0].Rows[0]["Total"].ToString());
                    total_denomination = Math.Round(total_denomination, 2);
                    lblTotal_Denominations.Text = Convert.ToString(total_denomination);
                    lbldenodeclared.Text = Convert.ToString(total_denomination);
                    lblclosingbal.Text = Convert.ToString(total_denomination);



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

                if (lbldenodeclared.Text == "")
                {
                    lbldenodeclared.Text = "0";
                }

                lblshortbal.Text = (Convert.ToDouble(lbldenodeclared.Text) - Convert.ToDouble(lbltotalbal.Text)).ToString("f2");

                DataSet dshiftsales = objBs.getshiftwisesales(sTableName, FromDate, ToDate);
                if (dshiftsales.Tables[0].Rows.Count > 0)
                {
                    gridpayment.DataSource = dshiftsales;
                    gridpayment.DataBind();

                    gridAllpayment.DataSource = dshiftsales;
                    gridAllpayment.DataBind();
                }

                //  gridPurchase.Visible = false;
                //   DataSet ds1 = objBs.ordebycatqtyDay(sTableName, FromDate, ToDate);
                //gridcatqty.DataSource = ds1;
                //gridcatqty.DataBind();
           // }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('If You Need This.Please Contact Administrator.Thank You!!!.');", true);
            //    return;
            //}

           

        }


        protected void consoildated_Checked(object sender, EventArgs e)
        {
            //if (IsSuperAdmin == "1" || IsSuperAdmin == "10")
            //{
                readingreport.Visible = false;
                consilidated.Visible = true;

                DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
                lblfromdt.Text = txtFromDate.Text;
                string FromDate = sFrom.ToString("yyyy-MM-dd");
                DateTime sTO = Convert.ToDateTime(txtToDate.Text);
                lbltodt.Text = txtToDate.Text;
                string ToDate = sTO.ToString("yyyy-MM-dd");

                lblcasherr.Text = lblUser.Text;
                lblUname1.Text = lblUser.Text;
                // lblstart.Text = "1";

                // COMPANY DETAILS


                lblcompanyname1.Text = sStore;
                lblcompanyarea1.Text = sAddress;
                // lblcompanyaddress1.Text = sAddress;



                // SET MAX BILLNO
                DataSet dmaxfirstandsecond = objBs.getmaxbillno(sTableName, FromDate, ToDate);
                if (dmaxfirstandsecond.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dmaxfirstandsecond.Tables[0].Rows.Count; i++)
                    {

                        lblstrt1.Text = dmaxfirstandsecond.Tables[0].Rows[0]["Billno"].ToString();
                        lbllast1.Text = dmaxfirstandsecond.Tables[0].Rows[1]["Billno"].ToString();
                        lblbillmade.Text = dmaxfirstandsecond.Tables[0].Rows[1]["Billno"].ToString();
                    }

                }

                double exp = 0;
                DataSet dexprense = objBs.AllExpensesumwise(sTableName, FromDate, ToDate);
                if (dexprense.Tables[0].Rows.Count > 0)
                {
                    exp = Convert.ToDouble(dexprense.Tables[0].Rows[0]["Amnt"]);
                    lblconsuldateexpense.Text = exp.ToString("f2");
                    lblexp.Text = exp.ToString("f2");
                }

                DataSet dmaxfirstandsecondtime = objBs.getmaxbillnowithtime(sTableName, FromDate, ToDate);
                if (dmaxfirstandsecondtime.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dmaxfirstandsecondtime.Tables[0].Rows.Count; i++)
                    {

                        lblstarttime.Text = dmaxfirstandsecondtime.Tables[0].Rows[0]["Billdate"].ToString();
                        lblendtime.Text = dmaxfirstandsecondtime.Tables[0].Rows[1]["Billdate"].ToString();

                    }

                }

                //GET ALL VALUE
                DataSet dsettotal = objBs.ordeby_DepartmentforTotal(sTableName, sFrom, sTO);
                if (dsettotal.Tables[0].Rows.Count > 0)
                {
                    lblbasic1.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["nettot"]).ToString("f2");
                    lblreturn1.InnerText = "0";
                    lbldiscount1.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["disc"]).ToString("f2");
                    lbltax1.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["vatAmount"]).ToString("f2");
                    lblservice1.InnerText = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["serviceTax"]).ToString("f2");
                    lblnet1.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");
                    lbltot1.Text = (Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]) - exp).ToString("f2");
                    lblclose1.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");
                    lbltotals1.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");
                    lblnett2.Text = Convert.ToDouble(dsettotal.Tables[0].Rows[0]["tot"]).ToString("f2");

                }


                // GET TOTAL ITEM SALES
                DataSet gettotitem = objBs.gettotalitem(sTableName, FromDate, ToDate);
                if (gettotitem.Tables[0].Rows.Count > 0)
                {
                    lblItemsold.Text = gettotitem.Tables[0].Rows[0]["cnt"].ToString();
                }

                //DENOMINATION
                #region Denomination

                DataSet ds_denomination = objBs.check_denomination(sTableName, ToDate);
                if (ds_denomination.Tables[0].Rows.Count > 0)
                {
                    total_denomination = Convert.ToDecimal(ds_denomination.Tables[0].Rows[0]["Total"].ToString());
                    total_denomination = Math.Round(total_denomination, 2);
                    lbldeclar.Text = (total_denomination).ToString("f2");
                    lblclos.Text = (total_denomination).ToString("f2");



                }
                if (lbldeclar.Text == "")
                {
                    lbldeclar.Text = "0";
                }

                lbldiff.Text = (Convert.ToDouble(lbldeclar.Text) - Convert.ToDouble(lbltot1.Text)).ToString("f2");

                #endregion



                DataSet dshiftsales = objBs.getshiftwisesales(sTableName, FromDate, ToDate);
                if (dshiftsales.Tables[0].Rows.Count > 0)
                {
                    gridlastpyament.DataSource = dshiftsales;
                    gridlastpyament.DataBind();
                }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('If You Need This.Please Contact Administrator.Thank You!!!.');", true);
            //    return;

            //}
        }
        #endregion




    }
}