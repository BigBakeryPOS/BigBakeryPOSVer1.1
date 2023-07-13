using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class PurchaseRequest : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string scode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
           

            if (!IsPostBack)
            {
               
                txtpodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                 //string script = "$(document).ready(function () { $('[id*=btnadd]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

                

                DataSet dReqNo = objbs.ReqNo(Convert.ToInt32(lblUserID.Text),scode);
                if (dReqNo.Tables[0].Rows.Count > 0)
                {
                    if (dReqNo.Tables[0].Rows[0]["RequestNo"].ToString() != "")
                    {
                        txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();
                    }
                    else
                    {
                        txtpono.Text = "1";
                    }
                }
                else
                {
                    txtpono.Text = "1";
                }
                

                DataSet dsCustomer = objbs.GetVendorName();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlvendor.DataSource = dsCustomer.Tables[0];
                    ddlvendor.DataTextField = "CustomerName";
                    ddlvendor.DataValueField = "CustomerID";
                    ddlvendor.DataBind();
                    ddlvendor.Items.Insert(0, "Select Vendor");
                    ddlvendor.SelectedValue = "308";
                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                }

                #region BindGrid
                //Gateaux
                DataSet dGateaux = objbs.getItemsList(6);
                gvGateaux.DataSource = dGateaux;
                gvGateaux.DataBind();

                //Snacks
                DataSet dSnacks = objbs.getItemsList(10);
                gvSnacks.DataSource = dSnacks;
                gvSnacks.DataBind();

                //Puddings

                DataSet dPuddings = objbs.getItemsList(9);
                gvPuddings.DataSource = dPuddings;
                gvPuddings.DataBind();

                //Beverages
                DataSet dBev = objbs.getItemsList(3);
                gvBeverages.DataSource = dBev;
                gvBeverages.DataBind();

                //Sweets

                DataSet dsweet = objbs.getItemsList(13);
                gvSweets.DataSource = dsweet;
                gvSweets.DataBind();

                //Party
                DataSet dCandles = objbs.getItemsList(8);
                gvcandles.DataSource = dCandles;
                gvcandles.DataBind();

                //Mousse
                DataSet dmouse = objbs.getItemsList(7);
                gvMousse.DataSource = dmouse;
                gvMousse.DataBind();

                //Cookies
                DataSet dCookies = objbs.getItemsList(5);
                gvCookies.DataSource = dCookies;
                gvCookies.DataBind();

                //CheeseCake
                DataSet dCheeese = objbs.getItemsList(4);
                gvcheese.DataSource = dCheeese;
                gvcheese.DataBind();

                //Stores
                DataSet dstores = objbs.getItemsList(12);
                gvStores.DataSource = dstores;
                gvStores.DataBind();

                //B'Day Cakes
                DataSet dBday = objbs.getItemsList(2);
                gvBday.DataSource = dBday;
                gvBday.DataBind();

                //Breads
                DataSet dBr = objbs.getItemsList(1);
                gvbread.DataSource = dBr;
                gvbread.DataBind();

                //sponges
                DataSet dSponge = objbs.getItemsList(11);
                gvSponges.DataSource = dSponge;
                gvSponges.DataBind();
                
                //sponges
                DataSet dEggless = objbs.getItemsList(16);
                gvEggless.DataSource = dEggless;
                gvEggless.DataBind();

                #endregion
            }
        }
        protected void btnvalue_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            btnadd.Text = "Wait";
            btnadd.Enabled = false;

            string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            if (txtOrderBy.Text == "")
                txtOrderBy.Text = "No Name";

            if (txtOrderBy.Text != "")
            {
                
                    int isave = objbs.insertPurchaseReq(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, scode);
              
                        #region Geautex
                        for (int i = 0; i < gvGateaux.Rows.Count; i++)
                        {
                            TextBox txtfuffQty = (TextBox)gvGateaux.Rows[i].FindControl("txtQty");


                            int iCatID = Convert.ToInt32(gvGateaux.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvGateaux.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvGateaux.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvGateaux.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Snacks
                        for (int i = 0; i < gvSnacks.Rows.Count; i++)
                        {
                            TextBox txbunt = (TextBox)gvSnacks.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvSnacks.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvSnacks.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvSnacks.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvSnacks.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Beverages
                        for (int i = 0; i < gvBeverages.Rows.Count; i++)
                        {
                            TextBox txtcake = (TextBox)gvBeverages.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvBeverages.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvBeverages.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvBeverages.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvBeverages.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");


                        }
                        #endregion
                        #region Puddings

                        for (int i = 0; i < gvPuddings.Rows.Count; i++)
                        {
                            TextBox txtbread = (TextBox)gvPuddings.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvPuddings.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvPuddings.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvPuddings.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvPuddings.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");


                        }
                        #endregion
                        #region Sweets
                        for (int i = 0; i < gvSweets.Rows.Count; i++)
                        {
                            TextBox txtcookies = (TextBox)gvSweets.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvSweets.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvSweets.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvSweets.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvSweets.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion

                        #region Party
                        for (int i = 0; i < gvcandles.Rows.Count; i++)
                        {
                            TextBox txtcandels = (TextBox)gvcandles.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvcandles.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvcandles.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvcandles.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvcandles.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Mouse
                        for (int i = 0; i < gvMousse.Rows.Count; i++)
                        {
                            TextBox txtmouse = (TextBox)gvMousse.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvMousse.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvMousse.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvMousse.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvMousse.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Cookies
                        for (int i = 0; i < gvCookies.Rows.Count; i++)
                        {
                            TextBox txtGV1 = (TextBox)gvCookies.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvCookies.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvCookies.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvCookies.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvCookies.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }

                        #endregion
                        #region Cheese
                        for (int i = 0; i < gvcheese.Rows.Count; i++)
                        {
                            TextBox txtgv2 = (TextBox)gvcheese.Rows[i].FindControl("txtQty");


                            int iCatID = Convert.ToInt32(gvcheese.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvcheese.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvcheese.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvcheese.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Stores
                        for (int i = 0; i < gvStores.Rows.Count; i++)
                        {
                            TextBox txtgv3 = (TextBox)gvStores.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvStores.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvStores.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvStores.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvStores.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Birthday
                        for (int i = 0; i < gvBday.Rows.Count; i++)
                        {
                            TextBox txtbday = (TextBox)gvBday.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvBday.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvBday.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvBday.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvBday.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Bread
                        for (int i = 0; i < gvbread.Rows.Count; i++)
                        {

                            TextBox txtbr = (TextBox)gvbread.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvbread.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvbread.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvbread.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvbread.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");

                        }
                        #endregion
                        #region Sponge
                        for (int i = 0; i < gvSponges.Rows.Count; i++)
                        {

                            TextBox txtsponge = (TextBox)gvSponges.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvSponges.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvSponges.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvSponges.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvSponges.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");




                        }
                        #endregion
                        #region Sponge
                        for (int i = 0; i < gvEggless.Rows.Count; i++)
                        {

                            TextBox txtsponge = (TextBox)gvEggless.Rows[i].FindControl("txtQty");

                            int iCatID = Convert.ToInt32(gvEggless.Rows[i].Cells[2].Text);
                            int iSubCatID = Convert.ToInt32(gvEggless.Rows[i].Cells[3].Text);
                            TextBox tt = (TextBox)gvEggless.Rows[i].FindControl("txtQty");
                            if (tt.Text == "")
                                tt.Text = "0";
                            decimal dTextBox = Convert.ToDecimal(tt.Text);
                            DropDownList dd = (DropDownList)gvEggless.Rows[i].FindControl("ddUnits");
                            string sUnits = dd.SelectedItem.Text;

                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, scode, sDate,"");




                        }

                        btnadd.Text = "Save";
                        btnadd.Enabled = true;
                        #endregion
                        //System.Threading.Thread.Sleep(5000);
                        Response.Redirect("PurchaseRequestGrid.aspx");
                    }
                
            
            else
            {
                lblNameerror.Text = "Enter Your name";
            }
        }
        protected void ddlvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsAddress = objbs.GetAddress(Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsAddress.Tables[0].Rows.Count > 0)
            {
                txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
            }
        }

        protected void gvGateaux_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvSnacks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvPuddings_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvBeverages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvSweets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvcandles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvMousse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvCookies_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvcheese_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvStores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvBday_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "2";
            }
        }

        protected void gvbread_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void gvSponges_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "2";
            }
        }

        protected void gvEggless_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.getUOM();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddUnits = (DropDownList)(e.Row.FindControl("ddUnits") as DropDownList);
                ddUnits.Focus();
                ddUnits.Enabled = true;
                ddUnits.DataSource = dsCategory.Tables[0];
                ddUnits.DataTextField = "UOM";
                ddUnits.DataValueField = "UOMID";
                ddUnits.DataBind();
                ddUnits.Items.Insert(0, "Select");

                ddUnits.SelectedValue = "3";
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked == true)
            {
                btnadd.Enabled = true;
            }
        }

        protected void chk_CheckedChanged1(object sender, EventArgs e)
        {

        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable dTfinal = new DataTable();

            DataTable dtSnacks = new DataTable();
            dtSnacks.Columns.Add("Item");
            dtSnacks.Columns.Add("Qty");

           

            foreach (GridViewRow ROw in gvSnacks .Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txtQty");

                if (txtQty.Text != "0")
                {
                    DataRow dr = dtSnacks.NewRow();
                    dr["Item"] = ROw.Cells[1].Text;
                    dr["Qty"] = txtQty.Text;
                    dtSnacks.Rows.Add(dr);

                }

            }
            DataTable dtcookies = new DataTable();
            dtcookies.Columns.Add("Item");
            dtcookies.Columns.Add("Qty");
            foreach (GridViewRow ROw in gvCookies.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txtQty");

                if (txtQty.Text!="0")
                {
                    DataRow dr = dtcookies.NewRow();
                    dr["Item"] = ROw.Cells[1].Text;
                    dr["Qty"] = txtQty.Text;
                    dtcookies.Rows.Add(dr);

                }

            }
            DataTable dtsweets = new DataTable();
            dtsweets.Columns.Add("Item");
            dtsweets.Columns.Add("Qty");
            foreach (GridViewRow ROw in gvSweets.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txtQty");

                if (txtQty.Text != "0")
                {
                    DataRow dr = dtsweets.NewRow();
                    dr["Item"] = ROw.Cells[1].Text;
                    dr["Qty"] = txtQty.Text;
                    dtsweets.Rows.Add(dr);

                }

            }

            DataTable dtcheese = new DataTable();
            dtcheese.Columns.Add("Item");
            dtcheese.Columns.Add("Qty");
            foreach (GridViewRow ROw in gvcheese.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txtQty");

                if (txtQty.Text != "0")
                {
                    DataRow dr = dtcheese.NewRow();
                    dr["Item"] = ROw.Cells[1].Text;
                    dr["Qty"] = txtQty.Text;
                    dtcheese.Rows.Add(dr);

                }

            }

            DataTable dtBread = new DataTable();
            dtBread.Columns.Add("Item");
            dtBread.Columns.Add("Qty");
            foreach (GridViewRow ROw in gvbread.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txtQty");

                if (txtQty.Text != "0")
                {
                    DataRow dr = dtBread.NewRow();
                    dr["Item"] = ROw.Cells[1].Text;
                    dr["Qty"] = txtQty.Text;
                    dtBread.Rows.Add(dr);

                }

            }

            DataTable dtsponge = new DataTable();
            dtsponge.Columns.Add("Item");
            dtsponge.Columns.Add("Qty");
            foreach (GridViewRow ROw in gvSponges.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txtQty");

                if (txtQty.Text != "0")
                {
                    DataRow dr = dtsponge.NewRow();
                    dr["Item"] = ROw.Cells[1].Text;
                    dr["Qty"] = txtQty.Text;
                    dtsponge.Rows.Add(dr);

                }

            }

            dTfinal.Merge(dtSnacks);
            dTfinal.Merge(dtsweets);
            dTfinal.Merge(dtcookies);
            dTfinal.Merge(dtcheese);
            dTfinal.Merge(dtBread);
            dTfinal.Merge(dtsponge);
            GridView1.Caption = "To be Orderderd";
            GridView1.DataSource = dTfinal;
            GridView1.DataBind();

     ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }

        
    }

}
        
          

            
           

