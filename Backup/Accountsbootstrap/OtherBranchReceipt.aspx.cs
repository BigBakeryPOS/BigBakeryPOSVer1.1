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
    public partial class OtherBranchReceipt : System.Web.UI.Page
    {
        string sTablename = "";
        string Sort_Direction = "ReceiptDate ASC";
        string Sort_Direction1 = "CustomerName ASC";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTablename = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                if (sTablename == "admin")
                {
                    div.Visible = true;
                    DataSet dAdmin = objBs.getOtherReceiptDetAdmin();
                    gvReceiptReport.DataSource = dAdmin;
                    gvReceiptReport.DataBind();


                }
                else
                {


                    div.Visible = false;
                }

                //DataSet ds = objBs.Getreceiptreport_Dealer("tblReceipt_" + sTablename, "tblTransReceipt_" + sTablename);
                //gvReceipt.DataSource = ds;
                //gvReceipt.DataBind();
            }
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            //DataSet ds = objBs.Getreceiptreport_Dealer("tblReceipt_" + sTablename, "tblTransReceipt_" + sTablename);
            //gvReceipt.PageIndex = e.NewPageIndex;
            //DataView dvEmployee = ds.Tables[0].DefaultView;
            //gvReceipt.DataSource = dvEmployee;
            //gvReceipt.DataBind();


        }

        protected void gvReceipt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("receiptpage.aspx?ReceiptID=" + e.CommandArgument.ToString());
            //    }
            //}
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            //GridView gvReceipt = new GridView();
            //gvReceipt.DataSource = objBs.Getreceiptreport_Dealer("tblReceipt_" + sTablename, "tblTransReceipt_" + sTablename);
            //gvReceipt.DataBind();
            //Response.ClearContent();
            //Response.AddHeader("content-disposition",
            //    "attachment;filename=Receiptreport.xls");
            //Response.ContentType = "applicatio/excel";
            //StringWriter sw = new StringWriter(); ;
            //HtmlTextWriter htm = new HtmlTextWriter(sw);
            //gvReceipt.RenderControl(htm);
            //Response.Write(sw.ToString());
            //Response.End();
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            ////DateTime dtFrom = Convert.ToDateTime(txtfrmdate.Text);
            ////DateTime dtTo = Convert.ToDateTime(txttodate.Text);

            //string sFrom = txtfrmdate.Text;
            //string sTo = txttodate.Text;
            //if (sTablename == "admin")
            //{
            //}
            //else
            //{
            //    DataSet ds = objBs.GenReceiptReport_Dealer(sFrom, sTo, "tblReceipt_" + sTablename, "tblTransReceipt_" + sTablename);
            //    gvReceipt.DataSource = ds;
            //    gvReceipt.DataBind();
            //}
        }

        protected void gvReceipt_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            //if (SortOrder[0] == e.SortExpression)
            //{
            //    if (SortOrder[1] == "ASC")
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            //    }
            //    else
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //    }
            //}
            //else
            //{
            //    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //}
            //DataSet ds = objBs.Getreceiptreport_Dealer("tblReceipt_" + sTablename, "tblTransReceipt_" + sTablename);
            //DataView dvEmp = ds.Tables[0].DefaultView;
            //dvEmp.Sort = ViewState["SortExpr"].ToString();
            //gvReceipt.DataSource = dvEmp;
            //gvReceipt.DataBind();
        }

        protected void gvReceiptReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                DataSet ds = objBs.geReceiptReportAdmin(Convert.ToInt32(e.CommandArgument.ToString()));
                gvReceipt.DataSource = ds;
                gvReceipt.DataBind();
            }
        }

        protected void ddselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddselect.SelectedValue == "1")
            {
                DataSet dBranch1 = objBs.GetOtherBranchForBranch1();
                gvReceiptReport.DataSource = dBranch1;
                gvReceiptReport.DataBind();
            }
            if (ddselect.SelectedValue == "2")
            {
                DataSet dBranch2 = objBs.GetOtherBranchForBranch2();
                gvReceiptReport.DataSource = dBranch2;
                gvReceiptReport.DataBind();
            }
            if (ddselect.SelectedValue == "3")
            {
                DataSet dBranch3 = objBs.GetOtherBranchForBranch3();
                gvReceiptReport.DataSource = dBranch3;
                gvReceiptReport.DataBind();
            }
        }
    }
}