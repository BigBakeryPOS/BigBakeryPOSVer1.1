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
    public partial class PendingPurchaseBillReport : System.Web.UI.Page
    {
        BSClass oBjbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dPending = oBjbs.PendingPurchaseBills();
                gvPurchasePayment.Visible = true;
                gvPurchasePayment.DataSource = dPending.Tables[0];
                gvPurchasePayment.DataBind();
            }
        }



        protected void ddlVendor_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }

        protected void gvPurchasePayment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void ddlPaid_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}