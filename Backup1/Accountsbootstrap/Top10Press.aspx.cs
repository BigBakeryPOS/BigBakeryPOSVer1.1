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
    public partial class Top10Press : System.Web.UI.Page
    {
        BSClass objBS = new BSClass();
        DataSet dsCustomer = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


               
                string tblPress = "CO1";
                DataSet dsPress = new DataSet();
                dsPress = objBS.GetTop10Press(tblPress);
                gvPress.DataSource = dsPress;
                gvPress.DataBind();
                lblError.InnerText = "";

            }
            else
            {
                lblError.InnerText = "Record Not Found";
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {





           

            DataSet dsPress = new DataSet();
            dsPress = objBS.GetTop10Press(ddlBranch.SelectedValue);
            gvPress.DataSource = dsPress;
            gvPress.DataBind();
            lblError.InnerText = "";



        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("TopCustomer.aspx");

        }
    }
}