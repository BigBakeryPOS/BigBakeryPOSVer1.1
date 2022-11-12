using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Globalization;
namespace Billing.Accountsbootstrap
{
    public partial class ReturnReceivingReport : System.Web.UI.Page
    {

        string sTableName = ""; string Password = "";
        BSClass objbs = new BSClass();

        double Quantity = 0; double qty = 0; double MissingQty = 0;

        string Btype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();
            Btype = Request.Cookies["userInfo"]["BType"].ToString();


            if (!IsPostBack)
            {
                //RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                //RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                //RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                //RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                //txtfromdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                //txttodate.Text = DateTime.Now.ToString("MM/dd/yyyy");

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");
            }
        }

        // Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet dRet = objbs.getretrnrecevingreports(sTableName, sFrom, sTo, "All");
            if (dRet.Tables[0].Rows.Count > 0)
            {
                gvReturns.DataSource = dRet;
                gvReturns.DataBind();
            }
            else
            {
                gvReturns.DataSource = null;
                gvReturns.DataBind();
            }

        }

        //Export to Excel
        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= ReturnReceivingQtyReport.xls");
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

        // Returns Report 
        protected void gvReturns_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Quantity += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "qty"));
                MissingQty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MissingQty"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[7].Text = "Total:-";
                e.Row.Cells[8].Text = Quantity.ToString("f2");
                e.Row.Cells[9].Text = qty.ToString("f2");
                e.Row.Cells[10].Text = MissingQty.ToString("f2");
            }

        }


    }
}