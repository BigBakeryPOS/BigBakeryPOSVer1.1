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

namespace Billing.Accountsbootstrap
{
    public partial class ReceiptGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = objBs.GetCustomerReceiptGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()),"tblReceipt_"+sTableName);
            gvReceipt.DataSource = ds;
            gvReceipt.DataBind();

            if (!IsPostBack)
            {
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();



                DataSet dsCategory1 = objBs.CustomerNameArea(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblReceipt_" + sTableName);
                if (dsCategory1.Tables[0].Rows.Count > 0)
                {
                    ddlcustomername.DataSource = dsCategory1.Tables[0];
                    ddlcustomername.DataTextField = "Area";

                    //ddlcustomername.DataValueField = "CustomerID";
                    ddlcustomername.DataBind();
                    ddlcustomername.Items.Insert(0, "Select Dealer Name and Area");


                }
                
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/receiptpage.aspx");

        }
        protected void refresh_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/ReceiptGrid.aspx");

        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string sCustomer = ddlcustomername.SelectedValue;
            string[] sFull = sCustomer.Split('-');
            string sCustomerName = sFull[0].ToString();
            string sArea = sFull[1].ToString();

            DataSet ds = objBs.SearchReceiptGird(sCustomerName.Trim(), sArea.Trim(), "tblReceipt_" + sTableName);
            //DataSet ds = objBs.CustomerSalesGirdbillNo(ddlbillno.SelectedValue);
            gvReceipt.DataSource = ds;
            gvReceipt.DataBind();
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

            DataSet ds = objBs.GetCustomerReceiptGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblReceipt_" + sTableName);
            gvReceipt.PageIndex = e.NewPageIndex;
            gvReceipt.DataBind();
            

        }

        protected void gvReceipt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("receiptpage.aspx?ReceiptID=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "print")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("ReceiptPrint.aspx?ReceiptID=" + e.CommandArgument.ToString());
                }
            }

            //else if (e.CommandName == "delete")
            //{
            //    int iSucess = objBs.deletesalesgrid(e.CommandArgument.ToString());
            //    Response.Redirect("salesgrid.aspx");
            //}
        }

        
    }
}