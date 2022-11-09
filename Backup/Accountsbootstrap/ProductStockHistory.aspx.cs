using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Drawing;
namespace Billing.Accountsbootstrap
{
    public partial class ProductStockHistory : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                DataSet ds = objBs.ProductWRstock(sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvstock.DataSource = ds.Tables[0];
                    gvstock.DataBind();
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.SearchProductWRstock(txtProduct.Text,sTableName);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvstock.DataSource = ds.Tables[0];
                gvstock.DataBind();
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.ProductWRstock(sTableName);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvstock.DataSource = ds.Tables[0];
                gvstock.DataBind();
            }
        }
    }
}