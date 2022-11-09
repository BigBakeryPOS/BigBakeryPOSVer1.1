using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;

namespace Billing.Accountsbootstrap
{
    public partial class SemiPurchaseRequestGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            DataSet ds = objbs.PurchaseReqGridBranch_Semi(lblUserID.Text, sCode);
            gvPurchaseEntry.DataSource = ds;
            gvPurchaseEntry.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Make Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            //Response.Redirect("stockProduction.aspx");
            //Response.Redirect("DailyStockRequest.aspx");
            // Response.Redirect("DailyStockRequestForm.aspx");
          //  DataSet checkdayclose = objbs.checkinser_Previousday(sCode);
           // if (checkdayclose.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("SemiItemStockRequest.aspx");
            }
         //   else
         //   {
         //       ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
         //       return;
         //   }


        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {

                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(',');
                string ReqNo = arg[0];
                string ToBranch = arg[1];
                string ReqTime = arg[2];
                string RequestDate = arg[3];

                DataSet ds = objbs.RequestDet_Semi(ReqNo, sCode);
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
                // string caption = "Request From " + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text ;
                string caption = "Daily Semi Stock Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "Request No :" + ReqNo + "</br>" + "Request Date :" + Convert.ToDateTime(ReqTime).ToString("dd/MM/yyyy") + "</br>" + "Request Entry Time :" + RequestDate;
                gvPurchaseReqDetails.Caption = caption;
            }

            else if (e.CommandName == "Print")
            {

                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(',');
                string ReqNo = arg[0];
                string ToBranch = arg[1];
                string ReqTime = arg[2];
                string RequestDate = arg[3];

                gvPurchaseReqDetails.Columns[3].Visible = false;
                DataSet ds = objbs.RequestDet_Semi(ReqNo, sCode);
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
                // string caption = "<h4><b> Request From" + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("MM/dd/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text + "</b></h4> "+ "</br>" + " Print Time " + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                string caption = "<h4><b>Daily Semi Stock Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "Request No :" + ReqNo + "</br>" + "Request Date :" + Convert.ToDateTime(ReqTime).ToString("dd/MM/yyyy") + "</br>" + "Request Entry Time :" + RequestDate + "</b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                gvPurchaseReqDetails.Caption = caption;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

            }
        }

        protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell row in e.Row.Cells)
                {
                    if (e.Row.Cells[3].Text != "Requset Sent")
                    {

                        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Accepted by production')", true);
                    }
                }
            }
        }

        protected void gvPurchaseEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objbs.PurchaseReqGridBranch_Semi(lblUserID.Text, sCode);
            gvPurchaseEntry.PageIndex = e.NewPageIndex;
            gvPurchaseEntry.DataSource = ds;
            gvPurchaseEntry.DataBind();
        }
    }
}