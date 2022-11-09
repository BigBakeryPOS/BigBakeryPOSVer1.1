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
    public partial class DealerStockView : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                //DataSet ds = new DataSet();
                ////  if (sTableName == "admin")
                //ds = objBs.getstockdetgrid();
                ////else
                ////    ds = objBs.getstockdetgrid_dealer("tblstock_" + sTableName);

                //gridview.DataSource = ds;
                //gridview.DataBind();
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (ddlfilter.SelectedValue == "1")
            {
                DataSet ds = objBs.searchstock(txtsearch.Text,sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "No Records Found for this SubCategory!";
                }
            }

            else
                if (ddlfilter.SelectedValue == "0")
                {
                    lblerror.Text = "Please select a valid SubCategory";
                }
        }


        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/stockgrid.aspx");
        }


        protected void gvstock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("DealerOrder.aspx?iStock=" + e.CommandArgument.ToString());
                }
            }

           
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objBs.getstockdetgrid(sTableName,"All","3");
            gridview.PageIndex = e.NewPageIndex;
            gridview.DataBind();


        }

    }
}