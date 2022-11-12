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
    public partial class ProductPurchaseHistory : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = objBs.ProductWRPurchase();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvPurchase.DataSource = ds.Tables[0];
                    gvPurchase.DataBind();
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.SearchProductWRPurchase(txtProduct.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPurchase.DataSource = ds.Tables[0];
                gvPurchase.DataBind();
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.ProductWRPurchase();

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPurchase.DataSource = ds.Tables[0];
                gvPurchase.DataBind();
            }
        }
    }
}