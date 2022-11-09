using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Drawing;



namespace Billing.Accountsbootstrap
{
    public partial class TodaysDeliveryOrder : System.Web.UI.Page
    {

        
        BSClass objbs = new BSClass();
        string sTablename = "";

        protected void Page_Load(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTablename = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                DataSet Todayrest = objbs.todaydeliveryorders(sTablename);
                gvorderToday.DataSource = Todayrest.Tables[0];
                gvorderToday.DataBind();
            }

        }




        protected void gvrest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //ViewState["orderNo"] = e.CommandArgument.ToString();
            //ViewState["Cmd"] = e.CommandName;
            if (e.CommandName == "Print")
            {
                Response.Redirect("Print.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
          
        }
    }
}