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
using System.Net.Mail;
namespace Billing.Accountsbootstrap
{
    public partial class DailyStockRequest : System.Web.UI.Page
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
                   
                   
                    //else
                    //{
                    //     dReqNo = objbs.GetMaxProdNo2();
                    //}
                   DataSet  dReqNo = objbs.ReqNo(Convert.ToInt32(lblUserID.Text), sCode);
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
                        //txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
                    }
                    #region BindGrid
                    //Gateaux
                    DataSet dGateaux = objbs.DalilystockRequest(6,sTableName);
                    gvGateaux.DataSource = dGateaux;
                    gvGateaux.DataBind();


                    foreach (GridViewRow gr in gvGateaux.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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

                    //Snacks
                    DataSet dSnacks = objbs.DalilystockRequest(10, sTableName);
                    gvSnacks.DataSource = dSnacks;
                    gvSnacks.DataBind();


                    foreach (GridViewRow gr in gvSnacks.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Puddings

                    DataSet dPuddings = objbs.DalilystockRequest(9, sTableName);
                    gvPuddings.DataSource = dPuddings;
                    gvPuddings.DataBind();
                    foreach (GridViewRow gr in gvPuddings.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Beverages
                    DataSet dBev = objbs.DalilystockRequest(3, sTableName);
                    gvBeverages.DataSource = dBev;
                    gvBeverages.DataBind();
                    foreach (GridViewRow gr in gvBeverages.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Sweets

                    DataSet dsweet = objbs.DalilystockRequest(13, sTableName);
                    gvSweets.DataSource = dsweet;
                    gvSweets.DataBind();
                    foreach (GridViewRow gr in gvSweets.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Party
                    DataSet dCandles = objbs.DalilystockRequest(8, sTableName);
                    gvcandles.DataSource = dCandles;
                    gvcandles.DataBind();
                    foreach (GridViewRow gr in gvcandles.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Mousse
                    DataSet dmouse = objbs.DalilystockRequest(7, sTableName);
                    gvMousse.DataSource = dmouse;
                    gvMousse.DataBind();
                    foreach (GridViewRow gr in gvMousse.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Cookies
                    DataSet dCookies = objbs.DalilystockRequest(5, sTableName);
                    gvCookies.DataSource = dCookies;
                    gvCookies.DataBind();
                    foreach (GridViewRow gr in gvCookies.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //CheeseCake
                    DataSet dCheeese = objbs.DalilystockRequest(4, sTableName);
                    gvcheese.DataSource = dCheeese;
                    gvcheese.DataBind();
                    foreach (GridViewRow gr in gvcheese.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Stores
                    DataSet dstores = objbs.DalilystockRequest(12, sTableName);
                    gvStores.DataSource = dstores;
                    gvStores.DataBind();
                    foreach (GridViewRow gr in gvStores.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //B'Day Cakes
                    DataSet dBday = objbs.DalilystockRequest(2, sTableName);
                    gvBday.DataSource = dBday;
                    gvBday.DataBind();
                    foreach (GridViewRow gr in gvBday.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //Breads
                    DataSet dBr = objbs.DalilystockRequest(1, sTableName);
                    gvbread.DataSource = dBr;
                    gvbread.DataBind();
                    foreach (GridViewRow gr in gvbread.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //sponges
                    DataSet dSponge = objbs.DalilystockRequest(11, sTableName);
                    gvSponges.DataSource = dSponge;
                    gvSponges.DataBind();
                    foreach (GridViewRow gr in gvSponges.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    //sponges
                    DataSet dreadySP = objbs.DalilystockRequest(21, sTableName);
                    gvReadySp.DataSource = dreadySP;
                    gvReadySp.DataBind();
                    foreach (GridViewRow gr in gvReadySp.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    DataSet dreadycake = objbs.DalilystockRequest(15, sTableName);
                    gvRmCake.DataSource = dreadycake;
                    gvRmCake.DataBind();
                    foreach (GridViewRow gr in gvRmCake.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    DataSet dIce = objbs.DalilystockRequest(23, sTableName);
                    gvIce.DataSource = dIce;
                    gvIce.DataBind();
                    foreach (GridViewRow gr in gvIce.Rows)
                    {
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));
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
                    #endregion
                }
            }
            protected void btnvalue_Click(object sender, EventArgs e)
            {

            }

            protected void btnexit_Click(object sender, EventArgs e)
            {
                Response.Redirect("PurchaseRequestGrid.aspx");
            }
            protected void btnsave_Click(object sender, EventArgs e)
            {
              //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "confitm('Request will Be sent');", true);
                btnsave.Text = "Wait";
                btnsave.Enabled = false;

                string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                if (txtOrderBy.Text == "")
                    txtOrderBy.Text = "No Name";

                if (txtOrderBy.Text != "")
                {

                    int isave = objbs.insertPurchaseReq(Convert.ToInt32(308), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sCode);

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");
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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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
                            int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");

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

                    //    int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCode, sDate,"");




                    //}

                    //btnsave.Text = "Save";
                    //btnsave.Enabled = true;
                    //#endregion
                    //System.Threading.Thread.Sleep(5000);


                    // Response.Redirect("SalesPrintNormal.aspx?iSalesID=" + e.CommandArgument.ToString() + "&frmdate=" + frmdate + "&todate=" + todate + "&ddl=" + ddlbillno.SelectedValue + "&textbox=" + txtAutoName.Text + "");


                  


                    Response.Redirect("PurchaseRequestGrid.aspx");
                }


                else
                {
                    //lbl.Text = "Enter Your name";
                }
            }

          

            protected void ddlvendor_SelectedIndexChanged(object sender, EventArgs e)
            {
                DataSet dsAddress = objbs.GetAddress(Convert.ToInt32(ddlvendor.SelectedValue));
                if (dsAddress.Tables[0].Rows.Count > 0)
                {
                    //txtSupplied.Text = dsAddress.Tables[0].Rows[0]["Address"].ToString();
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


                foreach (GridViewRow gr in gvGateaux.Rows)
                {
                    TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                    int itemid =Convert.ToInt32( gr.Cells[3].Text);

                    decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                    DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));

                    decimal dmin = Convert.ToDecimal(ds.Tables[0].Rows[0]["MinQty"].ToString());
                    decimal set = Convert.ToDecimal(ds.Tables[0].Rows[0]["FixQty"].ToString());


                    if (avl <= dmin)
                    {
                        txtqty.Text=set.ToString("f0");
                    }
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

                foreach (GridViewRow gr in gvSnacks.Rows)
                {
                    TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                    int itemid = Convert.ToInt32(gr.Cells[3].Text);

                    decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                    DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));

                    decimal dmin = Convert.ToDecimal(ds.Tables[0].Rows[0]["MinQty"].ToString());
                    decimal set = Convert.ToDecimal(ds.Tables[0].Rows[0]["FixQty"].ToString());


                    if (avl <= dmin)
                    {
                        txtqty.Text = set.ToString("f0");
                    }
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


                foreach (GridViewRow gr in gvPuddings.Rows)
                {
                    TextBox txtqty = (TextBox)gr.FindControl("txtQty");
                    int itemid = Convert.ToInt32(gr.Cells[3].Text);

                    decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                    DataSet ds = objbs.setQty(itemid,Convert.ToInt32(lblUserID.Text));

                    decimal dmin = Convert.ToDecimal(ds.Tables[0].Rows[0]["MinQty"].ToString());
                    decimal set = Convert.ToDecimal(ds.Tables[0].Rows[0]["FixQty"].ToString());


                    if (avl <= dmin)
                    {
                        txtqty.Text = set.ToString("f0");
                    }
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
