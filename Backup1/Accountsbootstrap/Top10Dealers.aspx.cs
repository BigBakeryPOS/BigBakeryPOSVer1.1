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
    public partial class Top10Dealers : System.Web.UI.Page
    {
        BSClass objBS = new BSClass();
        DataSet dsCustomer = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

             
                //Top 10 Dealer
                string tblDealer = "CO1";
                DataSet dsDealer = new DataSet();
                dsDealer = objBS.GetTop10Dealer(tblDealer);
                gvDealer.DataSource = dsDealer;
                gvDealer.DataBind();
                lblError.InnerText = "";
                //Top 10 Dealer
               

            }
            else
            {
                lblError.InnerText = "Record Not Found";
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {



         

            DataSet dsDealer = new DataSet();
            dsDealer = objBS.GetTop10Dealer(ddlBranch.SelectedValue);
            gvDealer.DataSource = dsDealer;
            gvDealer.DataBind();
            lblError.InnerText = "";

           



        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("TopCustomer.aspx");

        }
    }
}