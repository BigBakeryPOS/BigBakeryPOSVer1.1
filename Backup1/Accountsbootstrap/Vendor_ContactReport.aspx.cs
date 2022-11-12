using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class Vendor_ContactReport : System.Web.UI.Page
    {
        string Sort_Direction1 = "CustomerName ASC";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                lblUser.Text = Session["UserName"].ToString();
                lblUserID.Text = Session["UserID"].ToString();
                ViewState["SortExpr"] = Sort_Direction1;
                DataSet dSelect = objBs.CustomerReport(Convert.ToInt32(4));
                gvcust.DataSource = dSelect;
                gvcust.DataBind();
            }

        }
        protected void gvcust_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
            DataSet ds = objBs.CustomerReport(Convert.ToInt32(4));
            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gvcust.DataSource = dvEmp;
            gvcust.DataBind();
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

            DataSet ds = objBs.CustomerReport(Convert.ToInt32(4));
            gvcust.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gvcust.DataSource = dvEmployee;
            gvcust.DataBind();

        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("customerupdate.aspx?iCusID=" + e.CommandArgument.ToString());

                }
            }
        }
        protected void btnexcel_Click(object sender, EventArgs e)
        {
            GridView gvcust = new GridView();
            gvcust.DataSource = objBs.CustomerReport(Convert.ToInt32(4));
            gvcust.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=VendorReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gvcust.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet dSelect = objBs.Vendor_Search(txtser.Text);
            gvcust.DataSource = dSelect;
            gvcust.DataBind();
        }

        protected void btn_Reset_Click(object sender, EventArgs e)
        {
            txtser.Text = "";
            DataSet dSelect = objBs.CustomerReport(Convert.ToInt32(4));
            gvcust.DataSource = dSelect;
            gvcust.DataBind();

        }
    }
}