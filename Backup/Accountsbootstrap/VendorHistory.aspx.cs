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
namespace Billing.Accountsbootstrap
{ 
    public partial class VendorHistory : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    ddlBranch.Visible = true;

              

            if (ddlBranch.SelectedValue == "co1")
            {
                lblUserID.Text = "5";
               
            }
            else if (ddlBranch.SelectedValue == "co2")
            {
                lblUserID.Text = "6";
                
            }
            else if (ddlBranch.SelectedValue == "co3")
            {
                lblUserID.Text = "7";
                
            }
            else if (ddlBranch.SelectedValue == "co4")
            {
                lblUserID.Text = "11";
                
            }
            else if (ddlBranch.SelectedValue == "co5")
            {
                lblUserID.Text = "14";
                
            }
            else if (ddlBranch.SelectedValue == "co6")
            {
                lblUserID.Text = "17";
              
            }
            else if (ddlBranch.SelectedValue == "co7")
            {
                lblUserID.Text = "19";
                
            }
            else if (ddlBranch.SelectedValue == "co8")
            {
                lblUserID.Text = "26";

            }


            else if (ddlBranch.SelectedValue == "co9")
            {
                lblUserID.Text = "27";

            }

            else if (ddlBranch.SelectedValue == "co10")
            {
                lblUserID.Text = "28";

            }

            else if (ddlBranch.SelectedValue == "co11")
            {
                lblUserID.Text = "28";

            } 
                    DataSet dPoEntryGrid = objbs.GRNSession(Convert.ToInt32(lblUserID.Text));
                    gvPurchaseEntry.DataSource = dPoEntryGrid.Tables[0];
                    gvPurchaseEntry.DataBind();
                }
                else
                {
                    ddlBranch.Visible = false;
                    DataSet dPoEntryGrid = objbs.GRNSession(Convert.ToInt32(lblUserID.Text));
                    gvPurchaseEntry.DataSource = dPoEntryGrid.Tables[0];
                    gvPurchaseEntry.DataBind();
                }
                





            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //DataSet dPoEntryGrid = objbs.searchPurchaseEntryGrid(txtCustomerName.Text);
            //gvPurchaseEntry.DataSource = dPoEntryGrid;
            //gvPurchaseEntry.DataBind();

            //DataSet dPurchse = objbs.PurchasePaymentAdminsearch(txtCustomerName.Text);
            //if (dPurchse.Tables[0].Rows.Count > 0)
            //{

            //}
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorHistory.aspx");
        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {

            }
        }
     
        protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string[] rowValues = new string[gvPurchaseEntry.Rows.Count];

            for (int i = 0; i < gvPurchaseEntry.Rows.Count; i++)
            {
                rowValues[i] = gvPurchaseEntry.Rows[i].Cells[3].Text;
            }

            var distinctRows = (from r in rowValues
                                select r).Distinct();
        }

        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                if (ddlBranch.SelectedValue == "co1")
                {
                    lblUserID.Text = "5";

                }
                else if (ddlBranch.SelectedValue == "co2")
                {
                    lblUserID.Text = "6";

                }
                else if (ddlBranch.SelectedValue == "co3")
                {
                    lblUserID.Text = "7";

                }
                else if (ddlBranch.SelectedValue == "co4")
                {
                    lblUserID.Text = "11";

                }
                else if (ddlBranch.SelectedValue == "co5")
                {
                    lblUserID.Text = "14";

                }
                else if (ddlBranch.SelectedValue == "co6")
                {
                    lblUserID.Text = "17";

                }
                else if (ddlBranch.SelectedValue == "co7")
                {
                    lblUserID.Text = "19";

                }

                else if (ddlBranch.SelectedValue == "co8")
                {
                    lblUserID.Text = "26";

                }

                else if (ddlBranch.SelectedValue == "co9")
                {
                    lblUserID.Text = "27";

                }

                else if (ddlBranch.SelectedValue == "co10")
                {
                    lblUserID.Text = "28";

                }
                else if (ddlBranch.SelectedValue == "co11")
                {
                    lblUserID.Text = "30";

                }
                DataSet dPoEntryGrid = new DataSet();
                if (txtCustomerName.Text.Trim() == "")
                {
                  dPoEntryGrid=  objbs.GRNSession(Convert.ToInt32(lblUserID.Text));
                }
                else
                {
                     dPoEntryGrid = objbs.srchGRNSession(Convert.ToInt32(lblUserID.Text), Convert.ToInt32(txtCustomerName.Text));
                }
                gvPurchaseEntry.DataSource = dPoEntryGrid.Tables[0];
                gvPurchaseEntry.DataBind();
            }
            else
            {
                DataSet dPoEntryGrid = objbs.srchGRNSession(Convert.ToInt32(lblUserID.Text), Convert.ToInt32(txtCustomerName.Text));
                gvPurchaseEntry.DataSource = dPoEntryGrid.Tables[0];
                gvPurchaseEntry.DataBind();
            }
           
        }

        protected void btnrefresh_Click1(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                ddlBranch.Visible = true;



                if (ddlBranch.SelectedValue == "co1")
                {
                    lblUserID.Text = "5";

                }
                else if (ddlBranch.SelectedValue == "co2")
                {
                    lblUserID.Text = "6";

                }
                else if (ddlBranch.SelectedValue == "co3")
                {
                    lblUserID.Text = "7";

                }
                else if (ddlBranch.SelectedValue == "co4")
                {
                    lblUserID.Text = "11";

                }
                else if (ddlBranch.SelectedValue == "co5")
                {
                    lblUserID.Text = "14";

                }
                else if (ddlBranch.SelectedValue == "co6")
                {
                    lblUserID.Text = "17";

                }
                else if (ddlBranch.SelectedValue == "co7")
                {
                    lblUserID.Text = "19";

                }

                else if (ddlBranch.SelectedValue == "co8")
                {
                    lblUserID.Text = "26";

                }
                else if (ddlBranch.SelectedValue == "co9")
                {
                    lblUserID.Text = "27";

                }
                else if (ddlBranch.SelectedValue == "co10")
                {
                    lblUserID.Text = "28";

                }
                else if (ddlBranch.SelectedValue == "co11")
                {
                    lblUserID.Text = "29";

                }
                DataSet dPoEntryGrid = objbs.GRNSession(Convert.ToInt32(lblUserID.Text));
                gvPurchaseEntry.DataSource = dPoEntryGrid.Tables[0];
                gvPurchaseEntry.DataBind();
            }
            else
            {
                ddlBranch.Visible = false;
                DataSet dPoEntryGrid = objbs.GRNSession(Convert.ToInt32(lblUserID.Text));
                gvPurchaseEntry.DataSource = dPoEntryGrid.Tables[0];
                gvPurchaseEntry.DataBind();
            }
        }
    }
}
