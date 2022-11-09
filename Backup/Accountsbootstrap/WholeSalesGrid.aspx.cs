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
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class WholeSalesGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        string superadmin = "";


        double GrandTotal = 0;
        double Receipt = 0;
        double ReturnAmount = 0;
        double CloseDiscount = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();

            if (!IsPostBack)
            {
                txtFDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtTDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet ds = objBs.GetSalesall(sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();


                DataSet dsCustomer = objBs.getgridforcustsale();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlCus.DataSource = dsCustomer.Tables[0];
                    ddlCus.DataTextField = "CustomerName";
                    ddlCus.DataValueField = "LedgerID";
                    ddlCus.DataBind();
                    ddlCus.Items.Insert(0, "All");


                }
                else
                {
                    ddlCus.Items.Insert(0, "All");
                }

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("WholeSales.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("WholeSalesGrid.aspx");
        }


        protected void btnSearchNew_Click(object sender, EventArgs e)
        {
            DateTime frmdate = DateTime.ParseExact(txtFDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime todate = DateTime.ParseExact(txtTDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objBs.GetSalesall_Filter(sTableName, frmdate, todate, ddlCus.SelectedValue);
            gvsales.DataSource = ds;
            gvsales.DataBind();
        }

        protected void gridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GrandTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GrandTotal"));
                Receipt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Receipt"));
                ReturnAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount"));
                CloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));

                if (superadmin == "1")
                {
                    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
                    ((Image)e.Row.FindControl("imdedit")).Enabled = true;

                }
                else
                {

                    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
                    ((Image)e.Row.FindControl("imdedit")).Enabled = true;

                    //((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
                    //((Image)e.Row.FindControl("imdedit")).Enabled = false;

                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[6].Text = "Total :";
                e.Row.Cells[7].Text = GrandTotal.ToString("f2");
                e.Row.Cells[8].Text = Receipt.ToString("f2");
                e.Row.Cells[9].Text = ReturnAmount.ToString("f2");
                e.Row.Cells[10].Text = CloseDiscount.ToString("f2");

                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Right;

            }

        }

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editt")
            {
                string yourUrl = "WholeSales.aspx?iSalesID=" + e.CommandArgument.ToString();
                              ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                #region
                //if (e.CommandArgument.ToString() != "")
                //{
                //    //if (superadmin == "1")
                //    //{
                //        DataSet dch = objBs.checkingSalesRepORRtn(Convert.ToInt32(e.CommandArgument), sTableName);
                //        if (dch.Tables[0].Rows.Count > 0)
                //        {
                //            if (dch.Tables[0].Rows[0]["EditStatus"].ToString() == "1")
                //            {
                //                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Cannot be Edit,Some Process was Issued');", true);
                //                return;
                //            }
                //            else
                //            {
                //                string yourUrl = "WholeSales.aspx?iSalesID=" + e.CommandArgument.ToString();
                //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);
                //            }
                //        }
                //    //}
                //    //else
                //    //{
                //    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Contact Administrator.');", true);
                //    //    return;
                //    //}

                //}
                #endregion
            }
            if (e.CommandName == "CRNote")
            {
                #region
                if (e.CommandArgument.ToString() != "")
                {
                    //if (superadmin == "1")
                    //{
                        //DataSet dch = objBs.checkingSalesforCR(Convert.ToInt32(e.CommandArgument), sTableName);
                        //if (dch.Tables[0].Rows.Count > 0)
                        //{
                        //    if (dch.Tables[0].Rows[0]["CRStatus"].ToString() == "1")
                        //    {
                        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Already CRNote was Assigned.');", true);
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        string yourUrl = "CreditNote.aspx?iSalesID=" + e.CommandArgument.ToString();
                        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);
                        //    }
                        //}
                   // }
                    //else
                    //{
                       // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Contact Administrator.');", true);
                       // return;
                    //}

                }
                #endregion
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

                                int iscuss = objBs.normalsalescancel1(sTableName, (Convert.ToInt32(e.CommandArgument)), txtRef.Text, sTableName, dlReason.SelectedItem.Text);
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
                DataSet ds = new DataSet();

                ds = objBs.SelectedSales(sTableName, Convert.ToInt32(e.CommandArgument));
                gvCustsales.DataSource = ds.Tables[0];
                gvCustsales.DataBind();

            }

            else if (e.CommandName == "print")
            {

                string yourUrl = "Invoice_Print1.aspx?SalesId=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

         //       string yourUrl = "WholeSalesPrintnew.aspx?ISalesId=" + e.CommandArgument.ToString();
           //     ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);



                //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            }
            else if (e.CommandName == "dcprint")
            {

                string yourUrl = "WholeSalesQtyPrint.aspx?ISalesId=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

            }
        }


    }
}