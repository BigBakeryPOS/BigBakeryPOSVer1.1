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
    public partial class DealerRequest : System.Web.UI.Page
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
                DataSet ds = new DataSet();
                //  if (sTableName == "admin")
                ds = objBs.getDealerRequest();
                //else
                //    ds = objBs.getstockdetgrid_dealer("tblstock_" + sTableName);

                gridview.DataSource = ds;
                gridview.DataBind();
            }
        }

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("cashsales.aspx?iDealer="+e.CommandArgument.ToString());
                }
            }
        }

        protected void gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = new DataSet();
            //  if (sTableName == "admin")
            ds = objBs.getDealerRequest();
            //else
            //    ds = objBs.getstockdetgrid_dealer("tblstock_" + sTableName);

            gridview.DataSource = ds;
            gridview.DataBind();
        }
    }
}