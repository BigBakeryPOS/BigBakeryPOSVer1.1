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
    public partial class PaymentEntryGrid : System.Web.UI.Page
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
                DataSet ds = objBs.GetPayment(sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();

                DataSet dsCustomer = objBs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "All");
                }

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentEntryNEW.aspx");
        }
        protected void Add_Cldick(object sender, EventArgs e)
        {


        }
        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "print")
            {
                Response.Redirect("PaymentEntryPrint.aspx?PaymentID=" + e.CommandArgument.ToString());
            }
        }

    }
}