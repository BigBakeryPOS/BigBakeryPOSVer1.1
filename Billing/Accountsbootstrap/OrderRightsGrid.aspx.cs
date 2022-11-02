﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class OrderRightsGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {

                DataSet dsCustomer = objBs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "All");


                }

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet ds = objBs.getpurchaseOrderMaster(sTableName);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BankGrid.DataSource = ds;
                        BankGrid.DataBind();
                    }
                    else
                    {
                        BankGrid.DataSource = null;
                        BankGrid.DataBind();
                    }
                }
                else
                {
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
            }
        }

        protected void refresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderRightsGrid.aspx");
        }



        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrderRights.aspx");

        }
        //

        protected void BankGrid_SelectedIndexChanged(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = BankGrid.SelectedRow;

            string status = row.Cells[6].Text;

            if (status == "YES")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Not able to Delete. Purchase Invoice Generated for this Purchase Order!!!');", true);
                return;
            }
        }

        protected void BankGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("Purchase_Order.aspx?OrderNo=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "delete")
            {

                int iSucess = objBs.deletePURordermaster(e.CommandArgument.ToString(), sTableName);
                Response.Redirect("Purchase_OrderGrid.aspx");

            }
        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {


            getdate();
        }

        protected void ddlsuplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            getdate();
        }

        public void getdate()
        {
            //DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime ToDate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime FromDate = Convert.ToDateTime(txtfromdate.Text);
            DateTime ToDate = Convert.ToDateTime(txttodate.Text);

            DataSet pending = objBs.getpurchaseOrderMasterdate(sTableName, ddlsuplier.SelectedValue, FromDate, ToDate);
            if (pending.Tables[0].Rows.Count > 0)
            {
                BankGrid.DataSource = pending;
                BankGrid.DataBind();
            }
            else
            {
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
        }
    }
}