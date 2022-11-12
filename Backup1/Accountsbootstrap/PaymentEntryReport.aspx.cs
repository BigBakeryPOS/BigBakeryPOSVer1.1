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
    public partial class PaymentEntryReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = "";
        double ttlNetAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                DataSet dspaymode = objbs.tblsalespaymode();
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlpay.DataSource = dspaymode.Tables[0];
                    ddlpay.DataTextField = "PayMode";
                    ddlpay.DataValueField = "PayModeId";
                    ddlpay.DataBind();
                    ddlpay.Items.Insert(0, "All");

                }


                DataSet dsCustomer = objbs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsupplier.DataSource = dsCustomer.Tables[0];
                    ddlsupplier.DataTextField = "LedgerName";
                    ddlsupplier.DataValueField = "LedgerID";
                    ddlsupplier.DataBind();
                    ddlsupplier.Items.Insert(0, "All");
                }


            }

        }

        protected void gvreceiptamt_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ttlNetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[6].Text = "Total :";
                e.Row.Cells[7].Text = ttlNetAmount.ToString("f2");

            }

        }




        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= PaymentEntryReport.xls");
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

            DataSet ds = new DataSet();
            if (ddltype.SelectedValue == "1")
            {
                ds = objbs.getPaymentrecord(sTableName, ddlsupplier.SelectedValue, sFrom, sTo, ddlpay.SelectedValue);
            }
            else
            {
                ds = objbs.getPaymentrecorddetail(sTableName, ddlsupplier.SelectedValue, sFrom, sTo, ddlpay.SelectedValue);
            }
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

    }
}