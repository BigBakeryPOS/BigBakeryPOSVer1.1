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
    public partial class TopCustomer : System.Web.UI.Page
    {
        BSClass objBS = new BSClass();
        DataSet dsCustomer = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string tblCustomer = "CO1";
                //Top 10 Customer
                dsCustomer = objBS.GetTop10Customer(tblCustomer);
                gvCustomer.DataSource = dsCustomer;
                gvCustomer.DataBind();
                lblError.InnerText = "";
              

            }
            else
            {
                lblError.InnerText = "Record Not Found";
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            
                
               
                dsCustomer = objBS.GetTop10Customer(ddlBranch.SelectedValue);
                gvCustomer.DataSource = dsCustomer;
                gvCustomer.DataBind();
                lblError.InnerText = "";
                
              
            
           
           
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("TopCustomer.aspx");

        }
    }
}