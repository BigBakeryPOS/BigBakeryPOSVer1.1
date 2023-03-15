using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class SupplierOutStanding : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = "";
        double NetAmount = 0; double Receipt = 0; double ReturnAmount = 0; double CloseDiscount = 0;
        int intSubTotalIndex = 1;
        string PreviousRowID = string.Empty;

        double SubTotalQuantity = 0;
        double SubTotalAmount = 0;
        double SubTotalReceipt = 0;
        double SubTotalRAmount = 0;
        double SubTotalCAmount = 0;
        double SubTotalBalance = 0;

        double GrandTotalQuantity = 0;
        double GrandTotalAmount = 0;
        double GrandTotalReceipt = 0;
        double GrandTotalRAmount = 0;
        double GrandTotalCAmount = 0;
        double GrandTotalBalance = 0;



        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                DataSet dss = new DataSet();
                dss = objbs.SupplierList11();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlcustomerrep.DataSource = dss.Tables[0];
                    ddlcustomerrep.DataTextField = "LedgerName";
                    ddlcustomerrep.DataValueField = "LedgerID";
                    ddlcustomerrep.DataBind();
                    ddlcustomerrep.Items.Insert(0, "All");
                }

                DataSet dssubcompany = objbs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    ddlCompany.DataSource = dssubcompany.Tables[0];
                    ddlCompany.DataTextField = "CustomerName1";
                    ddlCompany.DataValueField = "subComapanyID";
                    ddlCompany.DataBind();
                    ddlCompany.Items.Insert(0, "All");
                }
            }

        }
        double Balance = 0;
        protected void gvreceiptamt_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (ddltype.SelectedValue == "2")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    PreviousRowID = DataBinder.Eval(e.Row.DataItem, "LedgerId").ToString();
                    NetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                    Receipt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Receipt"));
                    ReturnAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount"));
                    CloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));
                    Balance += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Balance"));


                    SubTotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());
                    GrandTotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount").ToString());

                    SubTotalReceipt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Receipt").ToString());
                    GrandTotalReceipt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Receipt").ToString());

                    SubTotalRAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount").ToString());
                    GrandTotalRAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount").ToString());

                    SubTotalCAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount").ToString());
                    GrandTotalCAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount").ToString());

                   // SubTotalBalance += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Balance").ToString());
                    GrandTotalBalance += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Balance").ToString());

                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //PreviousRowID = DataBinder.Eval(e.Row.DataItem, "LedgerId").ToString();
                    NetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                    Receipt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Receipt"));
                    ReturnAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount"));
                    CloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));
                    Balance += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Balance"));
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {

                    e.Row.Cells[5].Text = "Total :";
                    e.Row.Cells[6].Text = NetAmount.ToString("f2");
                    e.Row.Cells[7].Text = Receipt.ToString("f2");
                    e.Row.Cells[8].Text = ReturnAmount.ToString("f2");
                    e.Row.Cells[9].Text = CloseDiscount.ToString("f2");
                    e.Row.Cells[10].Text = Balance.ToString("f2");


                }

            }
        }

        protected void btnsearch_OnClick(object sender, EventArgs e)
        {

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //shanthi Comment for withcompanyName purpose   DataSet ds = objbs.getSupplierOutStanding(ddltype.SelectedValue, sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo);

            DataSet ds = objbs.getSupplierOutStandingwithCompany(ddltype.SelectedValue, sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlCompany.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvreceiptamt.DataSource = ds;
                gvreceiptamt.DataBind();
            }
            else
            {
                gvreceiptamt.DataSource = null;
                gvreceiptamt.DataBind();
            }
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= SupplierOutStandingReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            div1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void gvReport_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (ddltype.SelectedValue == "2")
            {
                #region

                bool IsSubTotalRowNeedToAdd = false;
                bool IsGrandTotalRowNeedtoAdd = false;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "LedgerId") != null))
                    if (PreviousRowID != DataBinder.Eval(e.Row.DataItem, "LedgerId").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((PreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "LedgerId") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    IsGrandTotalRowNeedtoAdd = true;
                    intSubTotalIndex = 0;
                }

                //Inserting first Row and populating fist Group Header details
                if ((PreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "LedgerId") != null))
                {
                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.Text = "Supplier Name : " + DataBinder.Eval(e.Row.DataItem, "CustomerName").ToString();
                    cell.ColumnSpan =13;
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
                    cell.ColumnSpan =3;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "SUB TOTAL";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 3;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                  

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalReceipt);
                    cell.HorizontalAlign = HorizontalAlign.Right ;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.ColumnSpan = 1;
                    //cell.CssClass = "SubTotalRowStyle";
                    //row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalRAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.ColumnSpan = 1;
                    //cell.CssClass = "SubTotalRowStyle";
                    //row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", SubTotalCAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.ColumnSpan = 1;
                    //cell.CssClass = "SubTotalRowStyle";
                    //row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.Text = string.Format("{0:0.00}", SubTotalBalance);
                    //cell.HorizontalAlign = HorizontalAlign.Left;
                    //cell.CssClass = "SubTotalRowStyle";
                    //row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 1;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    if (DataBinder.Eval(e.Row.DataItem, "LedgerId") != null)
                    {
                        row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        cell = new TableCell();
                        cell.Text = "Supplier Name : " + DataBinder.Eval(e.Row.DataItem, "CustomerName").ToString();
                        cell.ColumnSpan =13;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;
                    }

                    SubTotalAmount = 0;
                    SubTotalQuantity = 0;
                    SubTotalReceipt = 0;

                }
                if (IsGrandTotalRowNeedtoAdd)
                {

                    GridView gridPurchase = (GridView)sender;
                    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    TableCell cell = new TableCell();
                    cell.ColumnSpan =3;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Grand Total";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 3;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                  
                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalReceipt);
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.ColumnSpan = 1;
                    //cell.CssClass = "GrandTotalRowStyle";
                    //row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalRAmount);
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.ColumnSpan = 1;
                    //cell.CssClass = "GrandTotalRowStyle";
                    //row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalCAmount);
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    //cell = new TableCell();
                    //cell.ColumnSpan = 1;
                    //cell.CssClass = "GrandTotalRowStyle";
                    //row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = string.Format("{0:0.00}", GrandTotalBalance);
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GrandTotalRowStyle";
                    row.Cells.Add(cell);

                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex, row);

                }
            }

            #endregion
        }




    }
}