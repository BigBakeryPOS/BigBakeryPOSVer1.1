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
    public partial class PressHistory : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dCustReport = objbs.PressSalesAdmin();
                gvDealersales.DataSource = dCustReport.Tables[0];
                gvDealersales.DataBind();
            }
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            DataSet dCustReport = objbs.PressSalesAdminSearch(txtCustomerName.Text);
            gvDealersales.DataSource = dCustReport.Tables[0];
            gvDealersales.DataBind();
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("PressHistory.aspx");
        }
    }
}