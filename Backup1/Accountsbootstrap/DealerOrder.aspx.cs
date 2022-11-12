using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Net;
using System.IO;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class DealerOrder : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["Dealer"].ToString();
           
          
            sCode = "Dealer";
            if (!IsPostBack)
            {
                DataSet dReqNo = objbs.ReqNo2(sCode);
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
                //else
                //{
                //     dReqNo = objbs.GetMaxProdNo2();
                //}
              
                txtpodate.Text = DateTime.Now.ToString();

                DataSet dsCustomer = objbs.GetVendorName();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlvendor.DataSource = dsCustomer.Tables[0];
                    ddlvendor.DataTextField = "CustomerName";
                    ddlvendor.DataValueField = "CustomerID";
                    ddlvendor.DataBind();
                    ddlvendor.SelectedValue = "308";
                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                }
                DataSet dsAddress = objbs.GetAddress(Convert.ToInt32(308));
                if (dsAddress.Tables[0].Rows.Count > 0)
                {
                    // txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
                }
                #region BindGrid
                //Gateaux
                DataSet dGateaux = objbs.getItemsList(6);
                gvGateaux.DataSource = dGateaux;
                gvGateaux.DataBind();

                //snacks
                DataSet dSnacks = objbs.getItemsList(10);
                gvSnacks.DataSource = dSnacks;
                gvSnacks.DataBind();
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

                DataSet dRmSponge = objbs.getItemsList(21);
                gvReadySp.DataSource = dRmSponge;
                gvReadySp.DataBind();


                DataSet dRmCakes = objbs.getItemsList(15);
                gvRmCake.DataSource = dRmCakes;
                gvRmCake.DataBind();

                DataSet DIce = objbs.getItemsList(23);
                gvIce.DataSource = DIce;
                gvIce.DataBind();

                #endregion
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "confitm('Request will Be sent');", true);
           

            string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            

            if (txtOrderBy.Text != "")
            {

                int isave = objbs.insertPurchaseReq(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, "Dealer", 0, Convert.ToInt32(0), txtOrderBy.Text, sCode);

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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");
                    }
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
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }


                }
                #endregion

                #region ReadymadeSponge
                for (int i = 0; i < gvReadySp.Rows.Count; i++)
                {

                    TextBox txtsponge = (TextBox)gvReadySp.Rows[i].FindControl("txtQty");

                    int iCatID = Convert.ToInt32(gvReadySp.Rows[i].Cells[2].Text);
                    int iSubCatID = Convert.ToInt32(gvReadySp.Rows[i].Cells[3].Text);
                    TextBox tt = (TextBox)gvReadySp.Rows[i].FindControl("txtQty");
                    if (tt.Text == "")
                        tt.Text = "0";
                    decimal dTextBox = Convert.ToDecimal(tt.Text);
                    DropDownList dd = (DropDownList)gvReadySp.Rows[i].FindControl("ddUnits");
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }


                }
                #endregion

                #region rmcakes
                for (int i = 0; i < gvRmCake.Rows.Count; i++)
                {

                    TextBox txtsponge = (TextBox)gvRmCake.Rows[i].FindControl("txtQty");

                    int iCatID = Convert.ToInt32(gvRmCake.Rows[i].Cells[2].Text);
                    int iSubCatID = Convert.ToInt32(gvRmCake.Rows[i].Cells[3].Text);
                    TextBox tt = (TextBox)gvRmCake.Rows[i].FindControl("txtQty");
                    if (tt.Text == "")
                        tt.Text = "0";
                    decimal dTextBox = Convert.ToDecimal(tt.Text);
                    DropDownList dd = (DropDownList)gvRmCake.Rows[i].FindControl("ddUnits");
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }


                }
                #endregion


                #region ice
                for (int i = 0; i < gvIce.Rows.Count; i++)
                {

                    TextBox txtsponge = (TextBox)gvIce.Rows[i].FindControl("txtQty");

                    int iCatID = Convert.ToInt32(gvIce.Rows[i].Cells[2].Text);
                    int iSubCatID = Convert.ToInt32(gvIce.Rows[i].Cells[3].Text);
                    TextBox tt = (TextBox)gvIce.Rows[i].FindControl("txtQty");
                    if (tt.Text == "")
                        tt.Text = "0";
                    decimal dTextBox = Convert.ToDecimal(tt.Text);
                    DropDownList dd = (DropDownList)gvIce.Rows[i].FindControl("ddUnits");
                    string sUnits = "Nos";
                    if (tt.Text != "0")
                    {
                        int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");

                    }


                }
                #endregion
                //#region Sponge
                //for (int i = 0; i < gvEggless.Rows.Count; i++)
                //{

                //    TextBox txtsponge = (TextBox)gvEggless.Rows[i].FindControl("txtQty");

                //    int iCatID = Convert.ToInt32(gvEggless.Rows[i].Cells[2].Text);
                //    int iSubCatID = Convert.ToInt32(gvEggless.Rows[i].Cells[3].Text);
                //    TextBox tt = (TextBox)gvEggless.Rows[i].FindControl("txtQty");
                //    if (tt.Text == "")
                //        tt.Text = "0";
                //    decimal dTextBox = Convert.ToDecimal(tt.Text);
                //    DropDownList dd = (DropDownList)gvEggless.Rows[i].FindControl("ddUnits");
                //    string sUnits = dd.SelectedItem.Text;

                //    int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(0), 0, sCode, sDate,"");




                //}

                //btnsave.Text = "Save";
                //btnsave.Enabled = true;
                //#endregion
                //System.Threading.Thread.Sleep(5000);
                Response.Redirect("Thankyou.htm");
            }


         
        }
    }
}