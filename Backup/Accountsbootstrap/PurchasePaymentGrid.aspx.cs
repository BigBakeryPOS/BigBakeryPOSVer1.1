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
    public partial class PurchasePaymentGrid : System.Web.UI.Page
    {
        BSClass oBjbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dVendor = oBjbs.VendorList();
                if (dVendor.Tables[0].Rows.Count > 0)
                {
                    ddlVendor.DataSource = dVendor.Tables[0];
                    ddlVendor.DataTextField = "CustomerName";
                    ddlVendor.DataValueField = "VendorID";
                    ddlVendor.DataBind();
                    ddlVendor.Items.Insert(0, "--Select Vendor--");
                }
            }
        }

       

        protected void ddlVendor_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DataSet dPurchse = oBjbs.PurchasePayment(Convert.ToInt32(ddlVendor.SelectedValue));
            if (dPurchse.Tables[0].Rows.Count > 0)
            {
                gvPurchasePayment.Visible = true;
                gvPurchasePayment.DataSource = dPurchse.Tables[0];
                gvPurchasePayment.DataBind();
            }
        }

        protected void gvPurchasePayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "pay")
            {
                Response.Redirect("PurchasePaymentEntry.aspx?BillNo="+e.CommandArgument.ToString());
            }
        }

        protected void ddlPaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaid.SelectedValue == "1")
            {
                DataSet dPaid = oBjbs.PaidPurchaseBills();
                gvPurchasePayment.Visible = true;
                gvPurchasePayment.DataSource = dPaid.Tables[0];
                gvPurchasePayment.DataBind();
            }
            else if (ddlPaid.SelectedValue == "2")
            {
                DataSet dPending = oBjbs.PendingPurchaseBills();
                gvPurchasePayment.Visible = true;
                gvPurchasePayment.DataSource = dPending.Tables[0];
                gvPurchasePayment.DataBind();
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Incorrect Selection');", true);
            }
        }
    }
}