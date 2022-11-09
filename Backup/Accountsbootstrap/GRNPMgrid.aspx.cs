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
    public partial class GRNPMgrid : System.Web.UI.Page
    {


        BSClass objBs = new BSClass();
        string sTableName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            ddlfilter.SelectedValue = "1";
            ddlfilter.Enabled = false;
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                //  if (sTableName == "admin")
                //  ds = objBs.getstockdetgrid(sTableName);
                //else
                //    ds = objBs.getstockdetgrid_dealer("tblstock_" + sTableName);
                if (lblUser.Text.ToLower() == "admin")
                {
                    //  gridview.DataSource = ds;
                    // gridview.DataBind();
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/GRNPM.aspx");

        }


        protected void Search_Click(object sender, EventArgs e)
        {
            if (ddlfilter.SelectedValue == "1")
            {
                DataSet ds = objBs.searchstocknew(txtsearch.Text, sTableName);
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
            Response.Redirect("../Accountsbootstrap/GRNPMgrid.aspx");
        }


        protected void gvstock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("stock.aspx?iStock=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletestockgrid(e.CommandArgument.ToString(), sTableName);
                    Response.Redirect("../Accountsbootstrap/GRNPMgrid.aspx");
                }
            }
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objBs.getstockdetgrid(sTableName,"All","3");
            gridview.PageIndex = e.NewPageIndex;
            gridview.DataSource = ds.Tables[0];
            gridview.DataBind();


        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (sTableName != "admin")
            {
                gridview.Columns[7].Visible = false;
            }

        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {

            int Delete = objBs.DeleteOpeningStock(Convert.ToInt32(lblUserID.Text));

            DataSet ds = objBs.chkstock(Convert.ToInt32(lblUserID.Text), sTableName);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int iCatID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                    int iSubCat = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"].ToString());
                    double Qty = Convert.ToDouble(ds.Tables[0].Rows[i]["Available_QTY"].ToString());
                    int iuserID = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"].ToString());

                    int isave = objBs.InsertOpeningStock(iCatID, iSubCat, Qty, iuserID);
                }

                Response.Redirect("../Accountsbootstrap/GRNPMgrid.aspx");
            }


        }



    }
}