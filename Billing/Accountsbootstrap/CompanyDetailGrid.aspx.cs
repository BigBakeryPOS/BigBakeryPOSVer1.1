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
    public partial class CompanyDetailGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string Logintypeid = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            //lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            //lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            //sTableName = Request.Cookies["userInfo"]["User"].ToString();
            //Logintypeid = Request.Cookies["userInfo"]["LoginTypeId"].ToString();
            if (!IsPostBack)
            {

                DataSet ds = objBs.GetCompanyDetails();
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvcust.DataSource = ds;
                        gvcust.DataBind();
                    }
                    else
                    {
                        gvcust.DataSource = null;
                        gvcust.DataBind();
                    }
                }
                else
                {
                    gvcust.DataSource = null;
                    gvcust.DataBind();
                }
            }
        }


        protected void Search_Click(object sender, EventArgs e)
        {
            //DataSet ds = objBs.searchfilteruser(txtsearch.Text, Convert.ToInt32(ddlfilter.SelectedValue));
            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvcust.DataSource = ds;
            //        gvcust.DataBind();
            //    }
            //    else
            //    {
            //        gvcust.DataSource = null;
            //        gvcust.DataBind();
            //    }
            //}
            //else
            //{
            //    gvcust.DataSource = null;
            //    gvcust.DataBind();
            //}
        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("Company_Details.aspx?iCompanyID=" + e.CommandArgument.ToString());
                }
            }

            //    else if (e.CommandName == "delete")
            //    {
            //        int iSucess = objBs.deleteBranch(Convert.ToInt32(e.CommandArgument.ToString()));
            //        Response.Redirect("UserGrid.aspx");
            //    }
        }


    }
}