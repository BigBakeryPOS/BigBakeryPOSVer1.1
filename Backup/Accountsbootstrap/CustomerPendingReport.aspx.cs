using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class CustomerPendingReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblCurrent.Visible = false;
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    ddBranch.Visible = true;
                    lblCurrent.Visible = true;
                    DataSet ds = objBs.getAdminCustomerReceipt();
                    gvPending.DataSource = ds;
                    gvPending.DataBind();

                    decimal dPending = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dPending += Convert.ToDecimal(ds.Tables[0].Rows[i]["Balance"].ToString());
                    }
                    lblCustpending.InnerText = string.Format("{0:N2}", dPending);
                    //DateTime d1 = Convert.ToDateTime(ds.Tables[0].Rows[i]["BalanceAmount"].ToString());
                    //DateTime d2 = Convert.ToDateTime(closingdate.Text);

                    //string s = (d2 - d1).TotalDays.ToString();
                }
                else
                {
                    ddBranch.Visible = false;
                    DataSet ds = objBs.GetCustomerReceipt(Convert.ToInt32(lblUserID.Text),sTableName);
                    gvPending.DataSource = ds;
                    gvPending.DataBind();
                }
            }
        }

        protected void gvPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Pay")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("CustomerReceipt.aspx?iBillNo=" + e.CommandArgument.ToString());
                }
            }
        }

        protected void ddBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBranch.SelectedValue == "1")
            {
                DataSet ds = objBs.getBranch1CustomerReceipt();
                gvPending.DataSource = ds;
                gvPending.DataBind();
            }
            if (ddBranch.SelectedValue == "2")
            {
                DataSet ds = objBs.getBranch2CustomerReceipt();
                gvPending.DataSource = ds;
                gvPending.DataBind();
            }
            if (ddBranch.SelectedValue == "3")
            {
                DataSet ds = objBs.getBranch3CustomerReceipt();
                gvPending.DataSource = ds;
                gvPending.DataBind();
            }
        }
    }
}