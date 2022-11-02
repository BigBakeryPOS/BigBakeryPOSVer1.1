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
    public partial class DealerHistory : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dDealer = objbs.DealerSalesAdmin();
                gvDealersales.DataSource = dDealer.Tables[0];
                gvDealersales.DataBind();

                DataSet dAdmin = objbs.getReceiptDetAdmin();
                gvReceiptReport.DataSource = dAdmin;
                gvReceiptReport.DataBind();
            }
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            DataSet dDealerSales = objbs.DealerSalesSearch(txtCustomerName.Text);
            gvDealersales.DataSource = dDealerSales.Tables[0];
            gvDealersales.DataBind();

            DataSet dAdmin = objbs.searchReceiptDetAdmin(txtCustomerName.Text);
            gvReceiptReport.DataSource = dAdmin;
            gvReceiptReport.DataBind();
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("DealerHistory.aspx");
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