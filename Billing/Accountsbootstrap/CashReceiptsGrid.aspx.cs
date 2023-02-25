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
    public partial class CashReceiptsGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();


            if (!IsPostBack)
            {
                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "CusSalesReceipts");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "CusSalesReceipts");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnadd.Visible = true;
                    }
                    else
                    {
                        btnadd.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        // gridledger.Columns[8].Visible = true;
                    }
                    else
                    {
                        // gridledger.Columns[8].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        //gridledger.Columns[5].Visible = true;
                    }
                    else
                    {
                        //gridledger.Columns[5].Visible = false;
                    }
                }

                DataSet ds = objBs.GetReceipt(sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();

                DataSet dsCustomer = objBs.getcustomers();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dsCustomer.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "CustomerID";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "All");

                }

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("BCashReceipts.aspx");
        }
        protected void Add_Cldick(object sender, EventArgs e)
        {


        }
        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "print")
            {
                Response.Redirect("BCashReceipt.aspx?ReceiptID=" + e.CommandArgument.ToString());
            }
        }

    }
}