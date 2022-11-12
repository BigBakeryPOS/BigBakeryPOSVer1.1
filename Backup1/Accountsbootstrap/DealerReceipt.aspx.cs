using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;
namespace Billing.Accountsbootstrap
{
    public partial class DealerReceipt : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            if (!IsPostBack)
            {


                DataSet dAdmin = objbs.getReceiptDetDealerLogin(Convert.ToInt32(lblUserID.Text));
                gvReceiptReport.DataSource = dAdmin;
                gvReceiptReport.DataBind();
            }
        }

        protected void gvReceiptReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                DataSet ds = objbs.geReceiptReportAdmin(Convert.ToInt32(e.CommandArgument.ToString()));
                gvReceipt.DataSource = ds;
                gvReceipt.DataBind();
            }
        }
    }
}