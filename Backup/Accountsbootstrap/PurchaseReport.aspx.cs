using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class PurchaseReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dVendorName = objBs.VendorName();
                ddlVendor.DataSource = dVendorName.Tables[0];
                ddlVendor.DataTextField = "CustomerName";
                ddlVendor.DataValueField = "VendorID";
                ddlVendor.DataBind();
                ddlVendor.Items.Insert(0, "Select Vendor");

                DataSet dPoEntryGrid = objBs.PurchaseEntryGrid();
               
                gvPurchaseEntry.DataSource = dPoEntryGrid;
                gvPurchaseEntry.DataBind();
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet dVendorName = objBs.VendorNameSearch(Convert.ToInt32(ddlVendor.SelectedValue));
            gvPurchaseEntry.DataSource = dVendorName;
            gvPurchaseEntry.DataBind();

        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            DataSet dPoEntryGrid = objBs.PurchaseEntryGrid();
            gvPurchaseEntry.DataSource = dPoEntryGrid;
            gvPurchaseEntry.DataBind();

        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                gvPurchaseDetails.Visible = true;
                DataSet dpurchaseDet=objBs.viewPurchaseDetails(e.CommandArgument.ToString());
                gvPurchaseDetails.DataSource = dpurchaseDet;
                gvPurchaseDetails.DataBind();
            }
        }

      
    }
}