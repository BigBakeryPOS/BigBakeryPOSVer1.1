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
    public partial class CustomerHistory : System.Web.UI.Page
    {BSClass oBjbs=new BSClass();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblError.Text = "";
            DataSet dCustSalesDetails = oBjbs.CustomerSalesAdmin();
            gvCustsales.DataSource = dCustSalesDetails.Tables[0];
            gvCustsales.DataBind();

            DataSet ds = oBjbs.getAdminCustomerReceipt();
            gvPending.DataSource = ds;
            gvPending.DataBind();

            decimal dPending = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dPending += Convert.ToDecimal(ds.Tables[0].Rows[i]["Balance"].ToString());
            }
            lblCustpending.InnerText = string.Format("{0:N2}", dPending);
        }
    }

        protected void btnall_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text != "")
            {
                lblError.Text = "";
                DataSet dCustSales = oBjbs.CustomerSalesAdminSearch(txtCustomerName.Text);
                gvCustsales.DataSource = dCustSales.Tables[0];
                gvCustsales.DataBind();

                DataSet dsearch = oBjbs.searchCustomerReceipt(txtCustomerName.Text);
                gvPending.DataSource = dsearch.Tables[0];
                gvPending.DataBind();
            }
            else
            {
                lblError.Text = "Enter Customer Name";
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHistory.aspx");
        }
    }
}