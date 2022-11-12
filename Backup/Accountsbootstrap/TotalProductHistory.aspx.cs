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
    public partial class TotalProductHistory : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Session["User"].ToString();
            if (!IsPostBack)
            {
                Report.Visible = false;

                DataSet dSasles = objBs.ProductWRSales(sTableName);

                if (dSasles.Tables[0].Rows.Count > 0)
                {
                    gvSales.DataSource = dSasles.Tables[0];
                    gvSales.DataBind();
                }

                DataSet dpurchase = objBs.ProductWRPurchase();

                if (dpurchase.Tables[0].Rows.Count > 0)
                {
                    gvPurchase.DataSource = dpurchase.Tables[0];
                    gvPurchase.DataBind();
                }

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
            Report.Visible = true;
            DataSet dSasles = objBs.SearchProductWRSales(txtProduct.Text,sTableName);

            if (dSasles.Tables[0].Rows.Count > 0)
            {
                decimal dTotal = 0;
                for (int i = 0; i < dSasles.Tables[0].Rows.Count; i++)
                {
                    dTotal += Convert.ToDecimal(dSasles.Tables[0].Rows[i]["Amount"].ToString());
                }
                lblSales.InnerText = decimal.Round(dTotal, 2).ToString("f2");
                gvSales.DataSource = dSasles.Tables[0];
                gvSales.DataBind();
            }

            DataSet dpurchase = objBs.SearchProductWRPurchase(txtProduct.Text);

            if (dpurchase.Tables[0].Rows.Count > 0)
            {
                decimal dTotal = 0;
                for (int i = 0; i < dpurchase.Tables[0].Rows.Count; i++)
                {
                    dTotal += Convert.ToDecimal(dpurchase.Tables[0].Rows[i]["Amount"].ToString());
                }
                lblPurchase.InnerText = decimal.Round(dTotal, 2).ToString("f2");
                gvPurchase.DataSource = dpurchase.Tables[0];
                gvPurchase.DataBind();
            }

            DataSet ds = objBs.SearchProductWRstock(txtProduct.Text,sTableName);
            if (ds.Tables[0].Rows.Count > 0)
            {
                decimal dTotal = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dTotal += Convert.ToDecimal(ds.Tables[0].Rows[i]["Available_QTY"].ToString());
                }
                lblStock.InnerText = decimal.Round(dTotal, 2).ToString("f2");
                gvstock.DataSource = ds.Tables[0];
                gvstock.DataBind();
            }

           
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            Report.Visible = true;

            DataSet dSasles = objBs.ProductWRSales(sTableName);

            if (dSasles.Tables[0].Rows.Count > 0)
            {
                gvSales.DataSource = dSasles.Tables[0];
                gvSales.DataBind();
            }

            DataSet dpurchase = objBs.ProductWRPurchase();

            if (dpurchase.Tables[0].Rows.Count > 0)
            {
                gvPurchase.DataSource = dpurchase.Tables[0];
                gvPurchase.DataBind();
            }

            DataSet ds = objBs.ProductWRstock(sTableName);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvstock.DataSource = ds.Tables[0];
                gvstock.DataBind();
            }
        }
    }
}