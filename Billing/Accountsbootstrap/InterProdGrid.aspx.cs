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
    public partial class InterProdGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (!IsPostBack)
            {
                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "IPSR");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "IPSR");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        Button1.Visible = true;
                    }
                    else
                    {
                        Button1.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        //BankGrid.Columns[9].Visible = true;
                    }
                    else
                    {
                        // BankGrid.Columns[9].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        // BankGrid.Columns[10].Visible = true;
                    }
                    else
                    {
                        //  BankGrid.Columns[10].Visible = false;
                    }
                }


                DataSet ds = objbs.interReqGridprod(lblUserID.Text, sCode);
                gvPurchaseEntry.DataSource = ds;
                gvPurchaseEntry.DataBind();
            }
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

            // temp closed by jothi 03/08/2021 

            //////DataSet checkdayclose = objbs.checkinser_Previousday(sCode);
            //////if (checkdayclose.Tables[0].Rows.Count > 0)
            //////{
            //////    Response.Redirect("InterProdRequest.aspx");
            //////}
            //////else
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
            //////    return;
            //////}

            Response.Redirect("InterProdRequest.aspx");

        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                // int rowIndex = Convert.ToInt32(e.CommandArgument);
                //GridViewRow row = gvPurchaseEntry.Rows[rowIndex];

                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(',');
                string ReqNo = arg[0];
                string ToBranch = arg[1];
                string ReqTime = arg[2];
                string RequestDate = arg[3];


                DataSet ds = objbs.interRequestDet(ReqNo, sCode);
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();

                // string caption = "Request From " + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text ;
                string caption = "Inter Production  Stock Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "To Branch : " + ToBranch + "</br>" + "Request No :" + ReqNo + "</br>" + "Request Date :" + Convert.ToDateTime(ReqTime).ToString("dd/MM/yyyy") + "</br>" + "Request Entry Time :" + RequestDate;
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
                DataSet ds = objbs.interRequestDet(ReqNo, sCode);
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
                // string caption = "<h4><b> Request From" + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("MM/dd/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text + "</b></h4> "+ "</br>" + " Print Time " + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                string caption = "<h4><b>Inter Production Stock Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "To Branch : " + ToBranch + "</br>" + "Request No :" + ReqNo + "</br>" + "Request Date :" + Convert.ToDateTime(ReqTime).ToString("dd/MM/yyyy") + "</br>" + "Request Entry Time :" + RequestDate + "</b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                //string caption = "Inter Branch  Stock Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "To Branch : " + ToBranch + "</br>" + "Request No :" + ReqNo + "</br>" + "Request Date :" + Convert.ToDateTime(ReqTime).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Request Entry Time :" + RequestDate " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ;
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
            DataSet ds = objbs.interReqGridBranch(lblUserID.Text, sCode);
            gvPurchaseEntry.PageIndex = e.NewPageIndex;
            gvPurchaseEntry.DataSource = ds;
            gvPurchaseEntry.DataBind();
        }
    }
}