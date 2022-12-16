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
using System.Diagnostics;

namespace Billing.Accountsbootstrap
{
    public partial class ReceiveProductionStockGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        string qtysetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();


            if (!IsPostBack)
            {
                DataSet dacess1 = objBs.getuseraccessscreen(Session["EmpId"].ToString(), "ReceiveProductionStock");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Session["EmpId"].ToString(), "ReceiveProductionStock");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        Button1.Visible = true;
                    }
                    else
                    {
                        Button1.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        //BankGrid.Columns[9].Visible = true;
                    }
                    else
                    {
                        // BankGrid.Columns[9].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        // BankGrid.Columns[10].Visible = true;
                    }
                    else
                    {
                        //  BankGrid.Columns[10].Visible = false;
                    }
                }

                DataSet ds = objBs.ShowFinishRaw(sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("WholeSales.aspx");
        }







        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("cashsales.aspx?iSalesID=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "cancel")
            {

                if (txtRef.Text != "")
                {
                    DataSet dch = objBs.checkingRights(txtRef.Text);
                    if (dch.Tables[0].Rows.Count > 0)
                    {
                        if (objBs.CheckIfnormalsales((Convert.ToInt32(e.CommandArgument)), sTableName))
                        {
                            if (dlReason.SelectedItem.Text == "select")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessagee();", true);
                                return;
                            }
                            else
                            {

                                int iscuss = objBs.normalsalescancel(sTableName, (Convert.ToInt32(e.CommandArgument)), txtRef.Text, sTableName, dlReason.SelectedItem.Text, "", "", "", "");
                                DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                                gvsales.DataSource = ds;
                                gvsales.DataBind();
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Thank You " + dch.Tables[0].Rows[0]["Name"].ToString() + ".');", true);

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);

                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter a valid MobileNo.');", true);

                        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill cannot be cancelled Without Ref No.');", true);

                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                }

                //int iSucess = objBs.deletesalesgrid(e.CommandArgument.ToString());

            }

            else if (e.CommandName == "view")
            {
                DataSet ds = objBs.ShowRequestRawDetails("tblFinishRawMaterials_" + sTableName, "tbltransFinishRawMaterials_" + sTableName, Convert.ToInt32(e.CommandArgument), "IW");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCustsales.DataSource = ds;
                    gvCustsales.DataBind();
                }
                else
                {
                    gvCustsales.DataSource = null;
                    gvCustsales.DataBind();
                }

            }

            else if (e.CommandName == "print")
            {

                string yourUrl = "WholeSalesPrint.aspx?ISalesId=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);



                //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            }
        }




        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {




            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtQty = ((TextBox)e.Row.FindControl("txtQty"));
                //Label lblreceived_Qty = ((Label)e.Row.FindControl("lblreceived_Qty"));
                txtQty.Text = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                //lblreceived_Qty.Text = Convert.ToDouble(lblreceived_Qty.Text).ToString("" + qtysetting + "");

            }
        }
        protected void onrowdatabound1(object sender, GridViewRowEventArgs e)
        {




            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblQty = ((Label)e.Row.FindControl("lblQty"));
                //Label lblreceived_Qty = ((Label)e.Row.FindControl("lblreceived_Qty"));
                lblQty.Text = Convert.ToDouble(lblQty.Text).ToString("" + qtysetting + "");
                //lblreceived_Qty.Text = Convert.ToDouble(lblreceived_Qty.Text).ToString("" + qtysetting + "");

            }
        }





    }
}