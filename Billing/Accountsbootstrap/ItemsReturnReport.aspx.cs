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
    public partial class ItemsReturnReport : System.Web.UI.Page
    {
        string scode = "";
        string sTableName = "";
        string Label123 = "";
        BSClass objbs = new BSClass();
        string Btype = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Btype = Request.Cookies["userInfo"]["BType"].ToString();
          

            if (!IsPostBack)
            {

                //RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                //RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                //RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                //RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet dsreason = new DataSet();
                dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");


                DataSet dsbranch = objbs.getbranchsettingFilling(scode);
                ddlBranch.DataTextField = "Brancharea";
                ddlBranch.DataValueField = "BranchCode";
                ddlBranch.DataSource = dsbranch.Tables[0];
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, "All");


                txtfromdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txttodate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            }
        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {
                DateTime date = Convert.ToDateTime(txttodate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var days = date.Day;
                var toda = Toady.Day;

                if ((toda - days) <= 2)
                {

                }

                else
                {
                    txttodate.Text = "";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime From = DateTime.ParseExact(txtfromdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime To = DateTime.ParseExact(txttodate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            DataSet dRet = objbs.getProductionAllReturnItems(sTableName, ddlBranch.SelectedValue, ddlreason.SelectedValue, From, To);
            //update 22/10/2021
            if (dRet.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dRet.Tables[0].Rows.Count; i++)
                {
                    dRet.Tables[0].Rows[i]["DatePart"] = Convert.ToDateTime(dRet.Tables[0].Rows[i]["DatePart"]).ToString("dd/MMM/yyyy");
                }
            }
            //end update
            if (dRet.Tables[0].Rows.Count > 0)
            {
                gvReturns.Caption = ddlBranch.SelectedItem.Text + " Branch Stock Return Report Generated From  " + txtfromdate.Text + " To " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                gvReturns.DataSource = dRet;
                gvReturns.DataBind();

            }

            else
            {
                gvReturns.Caption = "";
                gvReturns.DataSource = null;
                gvReturns.DataBind();
            }




        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                gvReturns.Caption = ddlBranch.SelectedItem.Text + " Branch Stock Return Report Generated From  " + txtfromdate.Text + " To " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
            catch
            {

            }
        }
        protected void btnExp_Click1(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= StockReturnReport.xls");
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