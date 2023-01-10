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
    public partial class PurchaseReportDetailed : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();

        string sTableName = "";

        int intSubTotalIndex = 1;
        string PreviousRowID = string.Empty;

        double SubTotalQuantity = 0;
        double SubTotalAmount = 0;

        double GrandTotalQuantity = 0;
        double GrandTotalAmont = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                txtToDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txtFromDate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                DataSet dssubcompany = objBs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    drpsubcompany.DataSource = dssubcompany.Tables[0];
                    drpsubcompany.DataTextField = "CustomerName";
                    drpsubcompany.DataValueField = "subComapanyID";
                    drpsubcompany.DataBind();
                    drpsubcompany.Items.Insert(0, "All");
                }
            }
        }

        protected void rdbSupplier_OnCheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = objBs.SupplierList11();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "LedgerName";
                ddl.DataValueField = "LedgerID";
                ddl.DataBind();
                ddl.Items.Insert(0, "All");
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, "All");
            }

        }
        protected void rdbCategory_OnCheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = objBs.gridIngridentcategory();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "IngreCategory";
                ddl.DataValueField = "IngCatID";
                ddl.DataBind();
                ddl.Items.Insert(0, "All");
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, "All");
            }

        }

        protected void rdbCompany_OnCheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = objBs.GetsubCompanyDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "CustomerName";
                ddl.DataValueField = "subComapanyID";
                ddl.DataBind();
                ddl.Items.Insert(0, "All");
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, "All");
            }
        }

        protected void rdbIngredent_OnCheckedChanged(object sender, EventArgs e)
        {
            DataSet ds = objBs.GetIngredientall();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "IngredientName";
                ddl.DataValueField = "IngridID";
                ddl.DataBind();
                ddl.Items.Insert(0, "All");
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, "All");
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (rdbSupplier.Checked == false && rdbCategory.Checked == false && rdbIngredent.Checked == false && rdbCompany.Checked == false)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Plz Select Any One Group');", true);
                return;
            }

            DateTime sFrom = Convert.ToDateTime(txtFromDate.Text);
            string FromDate = sFrom.ToString("yyyy-MM-dd");

            DateTime sTO = Convert.ToDateTime(txtToDate.Text);
            string ToDate = sTO.ToString("yyyy-MM-dd");

            DataSet ds = new DataSet();

            if (rdbSupplier.Checked == true)
            {
                ds = objBs.GetPurchaseReport(sTableName, FromDate, ToDate, "Supplier", ddl.SelectedValue, drpsubcompany.SelectedValue);
            }
            else if (rdbCategory.Checked == true)
            {
                ds = objBs.GetPurchaseReport(sTableName, FromDate, ToDate, "Category", ddl.SelectedValue, drpsubcompany.SelectedValue);
            }
            else if (rdbIngredent.Checked == true)
            {
                ds = objBs.GetPurchaseReport(sTableName, FromDate, ToDate, "Ingredent", ddl.SelectedValue, drpsubcompany.SelectedValue);
            }
            else if (rdbCompany.Checked == true)
            {
                ds = objBs.GetPurchaseReport(sTableName, FromDate, ToDate, "Company", ddl.SelectedValue, drpsubcompany.SelectedValue);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvReport.DataSource = ds;
                gvReport.DataBind();
            }
            else
            {
                gvReport.DataSource = null;
                gvReport.DataBind();
            }
        }

        protected void gvReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (rdbSupplier.Checked == true )
                {
                    PreviousRowID = DataBinder.Eval(e.Row.DataItem, "LedgerID").ToString();
                }
                if (rdbCategory.Checked == true)
                {
                    PreviousRowID = DataBinder.Eval(e.Row.DataItem, "IngCatID").ToString();
                }
                if (rdbIngredent.Checked == true)
                {
                    PreviousRowID = DataBinder.Eval(e.Row.DataItem, "IngridID").ToString();
                }
                if (rdbCompany.Checked == true)
                {
                    PreviousRowID = DataBinder.Eval(e.Row.DataItem, "subComapanyID").ToString();
                }

                
                SubTotalQuantity += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());
                SubTotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());

                GrandTotalQuantity += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty").ToString());
                GrandTotalAmont += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());

            }

        }

        protected void gvReport_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (rdbSupplier.Checked == true)
            {
                #region

                bool IsSubTotalRowNeedToAdd = false;
                bool IsGrandTotalRowNeedtoAdd = false;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "LedgerID") != null))
                    if (PreviousRowID != DataBinder.Eval(e.Row.DataItem, "LedgerID").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "LedgerID") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    IsGrandTotalRowNeedtoAdd = true;
                    intSubTotalIndex = 0;
                }

                //Inserting first Row and populating fist Group Header details
                if ((PreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "LedgerID") != null))
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Supplier Name : " + DataBinder.Eval(e.Row.DataItem, "LedgerName").ToString();
                    cell.ColumnSpan = 13;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }


                if (IsSubTotalRowNeedToAdd)
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "SUB TOTAL";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "LedgerID") != null)
                    {
                        row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        cell = new TableCell();
                        cell.Text = "Supplier Name : " + DataBinder.Eval(e.Row.DataItem, "LedgerName").ToString();
                        cell.ColumnSpan = 13;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }

                    SubTotalAmount = 0;
                    SubTotalQuantity = 0;

                }
                if (IsGrandTotalRowNeedtoAdd)
                {

                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Grand Total";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalAmont);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);

                }

                #endregion
            }
            else if (rdbCategory.Checked == true)
            {
                #region

                bool IsSubTotalRowNeedToAdd = false;
                bool IsGrandTotalRowNeedtoAdd = false;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngCatID") != null))
                    if (PreviousRowID != DataBinder.Eval(e.Row.DataItem, "IngCatID").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngCatID") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    IsGrandTotalRowNeedtoAdd = true;
                    intSubTotalIndex = 0;
                }

                //Inserting first Row and populating fist Group Header details
                if ((PreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngCatID") != null))
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Category Name : " + DataBinder.Eval(e.Row.DataItem, "IngreCategory").ToString();
                    cell.ColumnSpan = 13;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }


                if (IsSubTotalRowNeedToAdd)
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "SUB TOTAL";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "IngCatID") != null)
                    {
                        row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        cell = new TableCell();
                        cell.Text = "Category Name : " + DataBinder.Eval(e.Row.DataItem, "IngreCategory").ToString();
                        cell.ColumnSpan = 13;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }

                    SubTotalAmount = 0;
                    SubTotalQuantity = 0;

                }
                if (IsGrandTotalRowNeedtoAdd)
                {

                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Grand Total";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalAmont);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);

                }

                #endregion
            }
            else if (rdbIngredent.Checked == true)
            {
                #region

                bool IsSubTotalRowNeedToAdd = false;
                bool IsGrandTotalRowNeedtoAdd = false;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngridID") != null))
                    if (PreviousRowID != DataBinder.Eval(e.Row.DataItem, "IngridID").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngridID") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    IsGrandTotalRowNeedtoAdd = true;
                    intSubTotalIndex = 0;
                }

                //Inserting first Row and populating fist Group Header details
                if ((PreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "IngridID") != null))
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Ingredient Name : " + DataBinder.Eval(e.Row.DataItem, "IngredientName").ToString();
                    cell.ColumnSpan = 13;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }


                if (IsSubTotalRowNeedToAdd)
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "SUB TOTAL";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "IngridID") != null)
                    {
                        row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        cell = new TableCell();
                        cell.Text = "Ingredient Name : " + DataBinder.Eval(e.Row.DataItem, "IngredientName").ToString();
                        cell.ColumnSpan = 13;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }

                    SubTotalAmount = 0;
                    SubTotalQuantity = 0;

                }
                if (IsGrandTotalRowNeedtoAdd)
                {

                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Grand Total";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalAmont);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);

                }

                #endregion
            }
            else if (rdbCompany.Checked == true)
            {
                #region

                bool IsSubTotalRowNeedToAdd = false;
                bool IsGrandTotalRowNeedtoAdd = false;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "subComapanyID") != null))
                    if (PreviousRowID != DataBinder.Eval(e.Row.DataItem, "subComapanyID").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "subComapanyID") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    IsGrandTotalRowNeedtoAdd = true;
                    intSubTotalIndex = 0;
                }

                //Inserting first Row and populating fist Group Header details
                if ((PreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "subComapanyID") != null))
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Company Name : " + DataBinder.Eval(e.Row.DataItem, "compname").ToString();
                    cell.ColumnSpan = 13;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }


                if (IsSubTotalRowNeedToAdd)
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "SUB TOTAL";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "subComapanyID") != null)
                    {
                        row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        cell = new TableCell();
                        cell.Text = "Company Name : " + DataBinder.Eval(e.Row.DataItem, "compname").ToString();
                        cell.ColumnSpan = 13;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }

                    SubTotalAmount = 0;
                    SubTotalQuantity = 0;

                }
                if (IsGrandTotalRowNeedtoAdd)
                {

                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan = 7;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Grand Total";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalQuantity);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalAmont);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 2;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);

                }

                #endregion
            }
        }


        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= StorePurchaseReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Excel.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    }
}