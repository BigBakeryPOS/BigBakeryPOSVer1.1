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
using System.Diagnostics;

namespace Billing.Accountsbootstrap
{
    public partial class PackingStockGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();


            if (!IsPostBack)
            {
                DataSet ds = objBs.getPackingStockGrid(sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("WholeSales.aspx");
        }







        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             if (e.CommandName == "view")
            {
                DataSet ds = objBs.viewPackingStockGrid(sTableName, (e.CommandArgument).ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCustsales.DataSource = ds;
                    gvCustsales.DataBind();
                }
                else
                {
                    gvCustsales.DataSource = null;
                    gvCustsales.DataBind();
                }

            }

            else if (e.CommandName == "print")
            {

                string yourUrl = "WholeSalesPrint.aspx?ISalesId=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);



                //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            }
        }









    }
}