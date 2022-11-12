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
    public partial class SalesandReceiptReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = "";
        double GrandTotal = 0; double Amount = 0; double CloseDiscount = 0;

        DataRow[] rows;

        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                DataSet ds1 = objbs.getrecptnumber(sTableName);

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                DataSet dspaymode = objbs.getpaymoderecNew();
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlpay.DataSource = dspaymode.Tables[0];
                    ddlpay.DataTextField = "PayMode";
                    ddlpay.DataValueField = "PayModeId";
                    ddlpay.DataBind();
                    ddlpay.Items.Insert(0, "All");

                }
                DataSet dss = new DataSet();
                dss = objbs.getcustomer();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlcustomerrep.DataSource = dss.Tables[0];
                    ddlcustomerrep.DataTextField = "CustomerName";
                    ddlcustomerrep.DataValueField = "LedgerID";
                    ddlcustomerrep.DataBind();
                    ddlcustomerrep.Items.Insert(0, "All");
                }
            }

        }

        protected void gvreceiptamt_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
             
                GrandTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GrandTotal"));
                Amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                CloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[5].Text = "Total :";
                e.Row.Cells[6].Text = GrandTotal.ToString("f2");
                e.Row.Cells[7].Text = Amount.ToString("f2");
                e.Row.Cells[8].Text = CloseDiscount.ToString("f2");
            }

        }


        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "print")
            {
                string yourUrl = "CashReceipt.aspx?ReceiptID=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= SalesandReceiptReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            IDValues.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnsearch_OnClick(object sender, EventArgs e)
        {
            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

           DataSet dsSalesReceipt = objbs.getSalesandReceiptReport(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddltype.SelectedValue);
           DataView aa = dsSalesReceipt.Tables[0].DefaultView;
            aa.Sort = "CustomerName,Type ASC";

            if (dsSalesReceipt.Tables[0].Rows.Count > 0)
            {
                gvreceiptamt.DataSource = aa;
                gvreceiptamt.DataBind();
            }
            else
            {
                gvreceiptamt.DataSource = null;
                gvreceiptamt.DataBind();
            }


            string aaa = "";
            if (aaa != "")
            {
                #region

                DataSet dsSales = new DataSet();
                DataSet dsReceipt = new DataSet();
                DataSet dstd = new DataSet();

                if (ddltype.SelectedValue == "1")
                {
                    dsSales = objbs.getsalesrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddltype.SelectedValue);
                    dsReceipt = objbs.getreceiptsrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddltype.SelectedValue);

                    if (dsSales.Tables[0].Rows.Count > 0)
                    {
                        #region NewColumn Table


                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;

                        dttt = new DataTable();

                        dct = new DataColumn("Customer");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillNo");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillDate");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillAmount");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ReceiptNo");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ReceiptDate");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ReceiptAmount");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("CloseDiscount");
                        dttt.Columns.Add(dct);



                        dstd.Tables.Add(dttt);

                        foreach (DataRow Dr in dsSales.Tables[0].Rows)
                        {
                            int rowsLength = 0;
                            drNew = dttt.NewRow();

                            drNew["Customer"] = Dr["LedgerName"];
                            drNew["BillNo"] = "All";
                            drNew["BillDate"] = "All";
                            drNew["BillAmount"] = Dr["GrandTotal"];



                            if (dsReceipt.Tables[0].Rows.Count > 0)
                            {
                                rows = dsReceipt.Tables[0].Select("LedgerName='" + Dr["LedgerName"] + "'");
                                rowsLength = rows.Length;

                                if (rows.Length > 1)
                                {
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Something Went Wrong.');", true);
                                    return;
                                }
                            }

                            if (rowsLength > 0)
                            {
                                drNew["ReceiptNo"] = "All";
                                drNew["ReceiptDate"] = "All";
                                drNew["ReceiptAmount"] = rows[0]["Amount"];
                                drNew["CloseDiscount"] = rows[0]["CloseDiscount"];
                            }
                            else
                            {
                                drNew["ReceiptNo"] = "-";
                                drNew["ReceiptDate"] = "-";
                                drNew["ReceiptAmount"] = "0";
                                drNew["CloseDiscount"] = "0";
                            }



                            dstd.Tables[0].Rows.Add(drNew);
                        }

                        gvreceiptamt.DataSource = dstd;
                        gvreceiptamt.DataBind();

                        #endregion

                    }
                }
                else
                {
                    dsSales = objbs.getsalesrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddltype.SelectedValue);
                    dsReceipt = objbs.getreceiptsrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddltype.SelectedValue);

                    if (dsSales.Tables[0].Rows.Count > 0)
                    {
                        #region NewColumn Table


                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;
                        dttt = new DataTable();

                        dct = new DataColumn("Customer");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillNo");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillDate");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillAmount");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ReceiptNo");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ReceiptDate");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ReceiptAmount");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("CloseDiscount");
                        dttt.Columns.Add(dct);



                        dstd.Tables.Add(dttt);

                        foreach (DataRow Dr in dsSales.Tables[0].Rows)
                        {
                            int rowsLength = 0;
                            drNew = dttt.NewRow();

                            drNew["Customer"] = Dr["LedgerName"];
                            drNew["BillNo"] = Dr["DCNo"];
                            drNew["BillDate"] = Dr["BillDate1"];
                            drNew["BillAmount"] = Dr["GrandTotal"];



                            if (dsReceipt.Tables[0].Rows.Count > 0)
                            {
                                rows = dsReceipt.Tables[0].Select("LedgerName='" + Dr["LedgerName"] + "' and ReceiptDate='" + Dr["BillDate"] + "'");
                                rowsLength = rows.Length;

                                if (rows.Length > 1)
                                {
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Something Went Wrong.');", true);
                                    return;
                                }
                            }

                            if (rowsLength > 0)
                            {
                                drNew["ReceiptNo"] = "All";
                                drNew["ReceiptDate"] = "All";
                                drNew["ReceiptAmount"] = rows[0]["Amount"];
                                drNew["CloseDiscount"] = rows[0]["CloseDiscount"];
                            }
                            else
                            {
                                drNew["ReceiptAmount"] = "0";
                                drNew["CloseDiscount"] = "0";
                            }



                            dstd.Tables[0].Rows.Add(drNew);
                        }

                        gvreceiptamt.DataSource = dstd;
                        gvreceiptamt.DataBind();

                        #endregion

                    }
                }

                #endregion
            }



        }

    }
}