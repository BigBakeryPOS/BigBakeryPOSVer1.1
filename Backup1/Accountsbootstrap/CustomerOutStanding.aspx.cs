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
    public partial class CustomerOutStanding : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = "";
        double NetAmount = 0; double Receipt = 0; double Balance = 0; double ReturnAmount = 0; double CloseDiscount = 0; double CreditNoteAmount = 0;



        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                DataSet ds1 = objbs.getrecptnumber(sTableName);

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");


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
                NetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                Receipt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Receipt"));
                ReturnAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount"));
                CloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));
                CreditNoteAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditNoteAmount"));
                Balance += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Balance"));


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[5].Text = "Total :";
                e.Row.Cells[6].Text = NetAmount.ToString("f2");
                e.Row.Cells[7].Text = Receipt.ToString("f2");
                e.Row.Cells[8].Text = ReturnAmount.ToString("f2");
                e.Row.Cells[9].Text = CloseDiscount.ToString("f2");
                e.Row.Cells[10].Text = CreditNoteAmount.ToString("f2");
                e.Row.Cells[11].Text = Balance.ToString("f2");


            }

        }





        protected void btnsearch_OnClick(object sender, EventArgs e)
        {

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getCustomerOutStanding(ddltype.SelectedValue, sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo);


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
            Response.AddHeader("content-disposition", "attachment;filename= CustomerOutStandingReport.xls");
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






    }
}