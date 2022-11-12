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
    public partial class PressSalesReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    DataSet dCustReport = objbs.PressSalesAdmin();
                    gvDealersales.DataSource = dCustReport.Tables[0];
                    gvDealersales.DataBind();
                }
                else
                {
                    DataSet dcustbranch = objbs.PressSalesBranch(sTableName);
                    gvDealersales.DataSource = dcustbranch.Tables[0];
                    gvDealersales.DataBind();

                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dcustbranch = objbs.PressSalesBranch(ddlBranch.SelectedValue);
            gvDealersales.DataSource = dcustbranch.Tables[0];
            gvDealersales.DataBind();
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            DataSet dCustReport = objbs.SearchPressSalesAdmin(ddlBranch.SelectedValue, txtCustomerName.Text);
            if (dCustReport.Tables[0].Rows.Count > 0)
            {
                gvDealersales.DataSource = dCustReport.Tables[0];
                gvDealersales.DataBind();
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            DataSet dCustReport = objbs.PressSalesAdmin();
            gvDealersales.DataSource = dCustReport.Tables[0];
            gvDealersales.DataBind();

        }
    }
}