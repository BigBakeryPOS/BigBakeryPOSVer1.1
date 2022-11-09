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
    public partial class ProductSalesHistory : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTablename = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            sTablename = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                DataSet ds = objBs.ProductWRSales(sTablename);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvSales.DataSource = ds.Tables[0];
                    gvSales.DataBind();
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.SearchProductWRSales(txtProduct.Text, sTablename);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvSales.DataSource = ds.Tables[0];
                gvSales.DataBind();
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.ProductWRSales(sTablename);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvSales.DataSource = ds.Tables[0];
                gvSales.DataBind();
            }
        }
    }
}