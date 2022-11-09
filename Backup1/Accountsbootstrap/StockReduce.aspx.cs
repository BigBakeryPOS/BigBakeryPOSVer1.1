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
    public partial class StockReduce : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {
                DataSet dReqNo = new DataSet();
                if (sCode == "Production")
                {
                    dReqNo = objbs.GetMaxProdNo();
                }
                if (sCode == "Production2")
                {
                    dReqNo = objbs.GetMaxProdNo();
                }
                if (sCode == "Production3")
                {
                    dReqNo = objbs.GetMaxProdNoNellai();
                }
                if (sCode == "Production4")
                {
                    dReqNo = objbs.GetMaxProdNoChennai();
                }
                //else
                //{
                //     dReqNo = objbs.GetMaxProdNo2();
                //}
                if (dReqNo.Tables[0].Rows.Count > 0)
                {
                    if (dReqNo.Tables[0].Rows[0]["ProdNO"].ToString() != "")
                    {
                        txtpono.Text = dReqNo.Tables[0].Rows[0]["ProdNO"].ToString();
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
                txtpodate.Text = DateTime.Now.ToString();

                DataSet dsCustomer = objbs.GetVendorName_new();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlvendor.DataSource = dsCustomer.Tables[0];
                    ddlvendor.DataTextField = "CustomerName";
                    ddlvendor.DataValueField = "UserID";
                    ddlvendor.DataBind();
                    //ddlvendor.SelectedValue = "308";
                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                }
                DataSet dsAddress = objbs.GetAddress(Convert.ToInt32(308));
                if (dsAddress.Tables[0].Rows.Count > 0)
                {
                    txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
                }




                var tab = new[] { tab0, tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab15, tab15 };
                var itm = new[] { lblitem, lblitem1, lblitem2, lblitem3, lblitem4, lblitem5, lblitem6, lblitem7, lblitem8, lblitem9, lblitem10, lblitem11, lblitem12, lblitem13, lblitem14, lblitem15, lblitem15, lblitem15 };
                var Grid = new[] { gvGateaux, gvSnacks, gvPuddings, gvBeverages, gvSweets, gvcandles, gvMousse, gvCookies, gvcheese, gvStores, gvBday, gvbread, gvSponges, gvReadySp, gvRmCake, gvIce, gvIce, gvIce };
                DataSet dcat = objbs.selectCAT();
                //for (int i = 0; i < dcat.Tables[0].Rows.Count; i++)
                for (int i = 0; i < 15; i++)
                {
                    tab[i].Style.Add("visibility", "visible");
                    itm[i].InnerText = dcat.Tables[0].Rows[i]["category"].ToString();


                    //   DataSet dGateaux = objbs.getItems(int.Parse(dcat.Tables[0].Rows[i]["categoryid"].ToString()), sCode);
                    //DataSet dGateaux = objbs.getItems(int.Parse(dcat.Tables[0].Rows[i]["categoryid"].ToString()), sTableName);

                    DataSet dGateaux = objbs.getItemsnew(int.Parse(dcat.Tables[0].Rows[i]["categoryid"].ToString()), sCode);
                    Grid[i].DataSource = dGateaux;
                    Grid[i].DataBind();


                    foreach (GridViewRow gr in Grid[i].Rows)
                    {

                        DataSet dCategory = objbs.getUOM();




                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        DropDownList Units = (DropDownList)gr.FindControl("ddUnits");
                        if (dCategory.Tables[0].Rows.Count > 0)
                        {
                            Units.DataSource = dCategory.Tables[0];
                            Units.DataTextField = "UOM";
                            Units.DataValueField = "UOMID";
                            Units.DataBind();
                            Units.Items.Insert(0, "uom");
                        }

                        Units.SelectedValue = gr.Cells[5].Text;

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid, Convert.ToInt32(lblUserID.Text));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            decimal dmin = Convert.ToDecimal(ds.Tables[0].Rows[0]["MinQty"].ToString());
                            decimal set = Convert.ToDecimal(ds.Tables[0].Rows[0]["FixQty"].ToString());


                            if (avl <= dmin)
                            {
                                gr.BackColor = System.Drawing.Color.Yellow;
                                txtqty.Text = set.ToString("f0");
                            }
                        }
                    }
                }

                //#region BindGrid
                ////Gateaux
                //DataSet dGateaux = objbs.getItems(6,sCode);
                //gvGateaux.DataSource = dGateaux;
                //gvGateaux.DataBind();

                ////Snacks
                //DataSet dSnacks = objbs.getItems(10, sCode);
                //gvSnacks.DataSource = dSnacks;
                //gvSnacks.DataBind();

                ////Puddings

                //DataSet dPuddings = objbs.getItems(9, sCode);
                //gvPuddings.DataSource = dPuddings;
                //gvPuddings.DataBind();

                ////Beverages
                //DataSet dBev = objbs.getItems(3, sCode);
                //gvBeverages.DataSource = dBev;
                //gvBeverages.DataBind();

                ////Sweets

                //DataSet dsweet = objbs.getItems(13, sCode);
                //gvSweets.DataSource = dsweet;
                //gvSweets.DataBind();

                ////Party
                //DataSet dCandles = objbs.getItems(8, sCode);
                //gvcandles.DataSource = dCandles;
                //gvcandles.DataBind();

                ////Mousse
                //DataSet dmouse = objbs.getItems(7, sCode);
                //gvMousse.DataSource = dmouse;
                //gvMousse.DataBind();

                ////Cookies
                //DataSet dCookies = objbs.getItems(5, sCode);
                //gvCookies.DataSource = dCookies;
                //gvCookies.DataBind();

                ////CheeseCake
                //DataSet dCheeese = objbs.getItems(4, sCode);
                //gvcheese.DataSource = dCheeese;
                //gvcheese.DataBind();

                ////Stores
                //DataSet dstores = objbs.getItems(12, sCode);
                //gvStores.DataSource = dstores;
                //gvStores.DataBind();

                ////B'Day Cakes
                //DataSet dBday = objbs.getItems(2, sCode);
                //gvBday.DataSource = dBday;
                //gvBday.DataBind();

                ////Breads
                //DataSet dBr = objbs.getItems(1, sCode);
                //gvbread.DataSource = dBr;
                //gvbread.DataBind();

                ////sponges
                //DataSet dSponge = objbs.getItems(11, sCode);
                //gvSponges.DataSource = dSponge;
                //gvSponges.DataBind();

                ////sponges
                //DataSet dEggless = objbs.getItems(16, sCode);
                // gvEggless.DataSource = dEggless;
                //gvEggless.DataBind();
                //#endregion

            }
        }
        protected void btnvalue_Click(object sender, EventArgs e)
        {

        }

        protected void btsAVE_Click(object sender, EventArgs e)
        {

            DateTime Date = Convert.ToDateTime(txtpodate.Text);
            string sDate = Date.ToString("yyyy-MM-dd h:mm tt");
            if (txtOrderBy.Text == "")
                txtOrderBy.Text = "No Name";
            string sUnits = "Nos";
            if (txtOrderBy.Text != "")
            {
                if (sCode == "Production")
                {
                    int isave = objbs.insertPStock(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text);
                }
                if (sCode == "Production2")
                {
                    int isave = objbs.insertPStock(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text);
                }
                if (sCode == "Production3")
                {
                    int isave = objbs.insertPStockNellai(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text);
                }
                #region Geautex
                for (int i = 0; i < gvGateaux.Rows.Count; i++)
                {
                    TextBox txtfuffQty = (TextBox)gvGateaux.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvGateaux.Rows[i].Cells[4].Text);
                    if (txtfuffQty.Text != "0" || dExtQty != 0)
                    {

                        int iCatID = Convert.ToInt32(gvGateaux.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvGateaux.Rows[i].Cells[3].Text);

                        TextBox tt = (TextBox)gvGateaux.Rows[i].FindControl("txtQty");

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //DropDownList dd = (DropDownList)gvGateaux.Rows[i].FindControl("ddUnits");

                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Snacks
                for (int i = 0; i < gvSnacks.Rows.Count; i++)
                {
                    TextBox txbunt = (TextBox)gvSnacks.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvSnacks.Rows[i].Cells[4].Text);
                    if (txbunt.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvSnacks.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvSnacks.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvSnacks.Rows[i].FindControl("txtQty");

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //DropDownList dd = (DropDownList)gvSnacks.Rows[i].FindControl("ddUnits");
                        //string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Beverages
                for (int i = 0; i < gvBeverages.Rows.Count; i++)
                {
                    TextBox txtcake = (TextBox)gvBeverages.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvBeverages.Rows[i].Cells[4].Text);
                    if (txtcake.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvBeverages.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvBeverages.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvBeverages.Rows[i].FindControl("txtQty");

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //  DropDownList dd = (DropDownList)gvBeverages.Rows[i].FindControl("ddUnits");
                        //  string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }

                }
                #endregion
                #region Puddings

                for (int i = 0; i < gvPuddings.Rows.Count; i++)
                {
                    TextBox txtbread = (TextBox)gvPuddings.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvPuddings.Rows[i].Cells[4].Text);
                    if (txtbread.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvPuddings.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvPuddings.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvPuddings.Rows[i].FindControl("txtQty");

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //   DropDownList dd = (DropDownList)gvPuddings.Rows[i].FindControl("ddUnits");
                        //  string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }

                }
                #endregion
                #region Sweets
                for (int i = 0; i < gvSweets.Rows.Count; i++)
                {
                    TextBox txtcookies = (TextBox)gvSweets.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvSweets.Rows[i].Cells[4].Text);
                    if (txtcookies.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvSweets.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvSweets.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvSweets.Rows[i].FindControl("txtQty");
                        // decimal dTextBox = Convert.ToDecimal(tt.Text);

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //  DropDownList dd = (DropDownList)gvSweets.Rows[i].FindControl("ddUnits");
                        //   string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion

                #region Party
                for (int i = 0; i < gvcandles.Rows.Count; i++)
                {
                    TextBox txtcandels = (TextBox)gvcandles.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvcandles.Rows[i].Cells[4].Text);
                    if (txtcandels.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvcandles.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvcandles.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvcandles.Rows[i].FindControl("txtQty");

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //   DropDownList dd = (DropDownList)gvcandles.Rows[i].FindControl("ddUnits");
                        //  string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Mouse
                for (int i = 0; i < gvMousse.Rows.Count; i++)
                {
                    TextBox txtmouse = (TextBox)gvMousse.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvMousse.Rows[i].Cells[4].Text);
                    if (txtmouse.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvMousse.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvMousse.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvMousse.Rows[i].FindControl("txtQty");

                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //    DropDownList dd = (DropDownList)gvMousse.Rows[i].FindControl("ddUnits");
                        //   string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Cookies
                for (int i = 0; i < gvCookies.Rows.Count; i++)
                {
                    TextBox txtGV1 = (TextBox)gvCookies.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvCookies.Rows[i].Cells[4].Text);

                    if (txtGV1.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvCookies.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvCookies.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvCookies.Rows[i].FindControl("txtQty");
                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //  DropDownList dd = (DropDownList)gvCookies.Rows[i].FindControl("ddUnits");
                        // string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }

                #endregion
                #region Cheese
                for (int i = 0; i < gvcheese.Rows.Count; i++)
                {
                    TextBox txtgv2 = (TextBox)gvcheese.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvcheese.Rows[i].Cells[4].Text);

                    if (txtgv2.Text != "0" || dExtQty != 0)
                    {

                        int iCatID = Convert.ToInt32(gvcheese.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvcheese.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvcheese.Rows[i].FindControl("txtQty");
                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        // DropDownList dd = (DropDownList)gvcheese.Rows[i].FindControl("ddUnits");
                        //  string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Stores
                for (int i = 0; i < gvStores.Rows.Count; i++)
                {
                    TextBox txtgv3 = (TextBox)gvStores.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvStores.Rows[i].Cells[4].Text);

                    if (txtgv3.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvStores.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvStores.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvStores.Rows[i].FindControl("txtQty");
                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //  DropDownList dd = (DropDownList)gvStores.Rows[i].FindControl("ddUnits");
                        // string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }


                }
                #endregion
                #region Birthday
                for (int i = 0; i < gvBday.Rows.Count; i++)
                {
                    TextBox txtbday = (TextBox)gvBday.Rows[i].FindControl("txtQty");
                    decimal dExtQty = Convert.ToDecimal(gvBday.Rows[i].Cells[4].Text);

                    if (txtbday.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvBday.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvBday.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvBday.Rows[i].FindControl("txtQty");
                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        //  DropDownList dd = (DropDownList)gvBday.Rows[i].FindControl("ddUnits");
                        // string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Bread
                for (int i = 0; i < gvbread.Rows.Count; i++)
                {
                    decimal dExtQty = Convert.ToDecimal(gvbread.Rows[i].Cells[4].Text);

                    TextBox txtbr = (TextBox)gvbread.Rows[i].FindControl("txtQty");
                    if (txtbr.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvbread.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvbread.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvbread.Rows[i].FindControl("txtQty");
                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        // DropDownList dd = (DropDownList)gvbread.Rows[i].FindControl("ddUnits");
                        // string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }
                }
                #endregion
                #region Sponge
                for (int i = 0; i < gvSponges.Rows.Count; i++)
                {
                    decimal dExtQty = Convert.ToDecimal(gvSponges.Rows[i].Cells[4].Text);

                    TextBox txtsponge = (TextBox)gvSponges.Rows[i].FindControl("txtQty");
                    if (txtsponge.Text != "0" || dExtQty != 0)
                    {
                        int iCatID = Convert.ToInt32(gvSponges.Rows[i].Cells[2].Text);
                        int iSubCatID = Convert.ToInt32(gvSponges.Rows[i].Cells[3].Text);
                        TextBox tt = (TextBox)gvSponges.Rows[i].FindControl("txtQty");
                        decimal dCurrQty = Convert.ToDecimal(tt.Text);
                        decimal TotQty = dExtQty - dCurrQty;
                        // DropDownList dd = (DropDownList)gvSponges.Rows[i].FindControl("ddUnits");
                        // string sUnits = dd.SelectedItem.Text;
                        if (sCode == "Production")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production2")
                        {
                            int iSAve = objbs.insertTransPStock(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                        if (sCode == "Production3")
                        {
                            int iSAve = objbs.insertTransPStockNellai(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(TotQty), sUnits, Convert.ToInt32(lblUserID.Text), 0, dCurrQty, dExtQty);
                        }
                    }



                }
                #endregion
                Response.Redirect("ProductionStockGrid.aspx");
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
    }
}