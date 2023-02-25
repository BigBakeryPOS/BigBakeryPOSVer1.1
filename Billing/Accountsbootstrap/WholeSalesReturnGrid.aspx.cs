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
    public partial class WholeSalesReturnGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();


            if (!IsPostBack)
            {
                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "wholesaleReturn");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "wholesaleReturn");
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
                       // gvsales.Columns[16].Visible = true;
                    }
                    else
                    {
                        //gvsales.Columns[16].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        //  gvsales.Columns[16].Visible = true;
                    }
                    else
                    {
                        // gvsales.Columns[16].Visible = false;
                    }
                }

                DataSet ds = objBs.GetSalesallret(sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();


                DataSet dsCustomer = objBs.getgridforcustsale();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dsCustomer.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "LedgerID";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "Select Customer");


                }
                else
                {
                    ddlcustomer.Items.Insert(0, "Select Customer");
                }

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("WholeSalesReturn.aspx");
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
                                DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Session["UserID"].ToString()), "tblSales_" + sTableName);
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
                DataSet ds = new DataSet();

                ds = objBs.SelectedSales(sTableName, Convert.ToInt32(e.CommandArgument));
                gvCustsales.DataSource = ds.Tables[0];
                gvCustsales.DataBind();

            }

            else if (e.CommandName == "print")
            {

                string yourUrl = "WholeSalesReturnPrint.aspx?ISalesId=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);



                //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            }
        }









    }
}