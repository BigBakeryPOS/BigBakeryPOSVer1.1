using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using CommonLayer;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class ItemReport : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Description ASC";
        string Sort_Direction1 = "category ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                DataSet ds = objBs.viewCategory();
                gvcategory.DataSource = ds;
                gvcategory.DataBind();
               
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue == "1")
            {
                DataSet ds = objBs.categorysrch(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Category!";
                }
            }
            else if (ddlcategory.SelectedValue == "2")
            {
                DataSet ds = objBs.srchbydef(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Description!";
                }


            }
            else
            {
                DataSet ds = objBs.SearchSerial(txtdescription.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Description!";
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ItemReport.aspx");
        }

        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            //if (SortOrder[0] == e.SortExpression)
            //{
            //    if (SortOrder[1] == "ASC")
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            //    }
            //    else
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //    }
            //}
            //else
            //{
            //    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //}
            //DataSet ds1 = objBs.gridcustomer();
            //DataView dvEmp = ds1.Tables[0].DefaultView;
            //dvEmp.Sort = ViewState["SortExpr"].ToString();
            //gridview.DataSource = dvEmp;
            //gridview.DataBind();
        }

        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //DataSet ds1 = objBs.gridcustomer();
            //gridview.DataSource = ds1;
            //gridview.DataBind();

            //DataSet ds = objBs.gridcustomer();
            //gridview.PageIndex = e.NewPageIndex;
            //DataView dvEmployee = ds.Tables[0].DefaultView;
            //gridview.DataSource = dvEmployee;
            //gridview.DataBind();
        }

        protected void gvcategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                gridview.Visible = true;
                DataSet ds1 = objBs.gridcustomer(e.CommandArgument.ToString());
                gridview.DataSource = ds1;
                gridview.DataBind();
            }
        }
    }
}