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
    public partial class PurchaseReqStoreGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "storerequest");
            if (dacess1.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                {
                    Response.Redirect("Login_branch.aspx");
                }
            }

            DataSet dacess = new DataSet();
            dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "storerequest");
            if (dacess.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                {
                    btnadd1.Visible = true;
                }
                else
                {
                    btnadd1.Visible = false;
                }

                if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                {
                    //gv.Columns[2].Visible = true;
                }
                else
                {
                    //gv.Columns[2].Visible = false;
                }

                if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                {
                    //gv.Columns[3].Visible = true;
                }
                else
                {
                    //gv.Columns[3].Visible = false;
                }
            }


            DataSet ds = objbs.PurchaseReqstoreGridBranch(lblUserID.Text, sCode);
            gvPurchaseEntry.DataSource = ds;
            gvPurchaseEntry.DataBind();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Make Any Store Stock Request.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion
           
            DataSet checkdayclose = objbs.checkinser_Previousday(sCode);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("ItemStockRequestStore.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
                return;
            }


        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                DataSet ds = objbs.RequestStoreDet(e.CommandArgument.ToString(), sCode);
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
                // string caption = "Request From " + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text ;
                //////string caption = "Store Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "Request No :" + gvPurchaseEntry.Rows[0].Cells[0].Text + "</br>" + "Request Date :" + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Request Entry Time :" + gvPurchaseEntry.Rows[0].Cells[5].Text;
                string RequestNo = ds.Tables[0].Rows[0]["RequestNo"].ToString();
                string RequestDate = ds.Tables[0].Rows[0]["RequestDate"].ToString();
                string RequestEntryTime = ds.Tables[0].Rows[0]["RequestEntryTime"].ToString();

                string caption = "Store Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "Request No :" + RequestNo + "</br>" + "Request Date :" + Convert.ToDateTime(RequestDate).ToString("dd/MM/yyyy") + "</br>" + "Request Entry Time :" + RequestEntryTime;
                gvPurchaseReqDetails.Caption = caption;
            }

            else if (e.CommandName == "Print")
            {
                gvPurchaseReqDetails.Columns[3].Visible = false;
                DataSet ds = objbs.RequestStoreDet(e.CommandArgument.ToString(), sCode);
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
                // string caption = "<h4><b> Request From" + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("MM/dd/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text + "</b></h4> "+ "</br>" + " Print Time " + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                //////string caption = "<h4><b>Store Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "Request No :" + gvPurchaseEntry.Rows[0].Cells[0].Text + "</br>" + "Request Date :" + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("MM/dd/yyyy hh:MM:tt") + "</br>" + "Request Entry Time :" + gvPurchaseEntry.Rows[0].Cells[5].Text + "</b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                string RequestNo = ds.Tables[0].Rows[0]["RequestNo"].ToString();
                string RequestDate = ds.Tables[0].Rows[0]["RequestDate"].ToString();
                string RequestEntryTime = ds.Tables[0].Rows[0]["RequestEntryTime"].ToString();
                string caption = "Store Request Details" + "</br>" + "Request From :" + sCode + "</br>" + "Request No :" + RequestNo + "</br>" + "Request Date :" + Convert.ToDateTime(RequestDate).ToString("dd/MM/yyyy") + "</br>" + "Request Entry Time :" + RequestEntryTime;
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

                    }
                }
            }
        }

        protected void gvPurchaseEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objbs.PurchaseReqstoreGridBranch(lblUserID.Text, sCode);
            gvPurchaseEntry.PageIndex = e.NewPageIndex;
            gvPurchaseEntry.DataSource = ds;
            gvPurchaseEntry.DataBind();
        }
    }
}