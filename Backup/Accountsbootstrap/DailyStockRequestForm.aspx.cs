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
using System.Globalization;



namespace Billing.Accountsbootstrap
{
    public partial class DailyStockRequestForm : System.Web.UI.Page
    {


        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCodeProd = "";
        string sCodeBnch = "";
        string empid = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            empid = Request.Cookies["userInfo"]["Empid"].ToString();
            // sCode = Session["BranchCode"].ToString();



            if (!IsPostBack)
            {

                DataSet dss = objbs.checkrequestallowornot(sTableName);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                DataSet dReqNo = objbs.ReqNo(Convert.ToInt32(lblUserID.Text), sCodeBnch);

                txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();
                txtpodate.Text = DateTime.Now.ToString("dd/MM/yyyy");




                var tab = new[] { tab0, tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab15, tab15 };
                var itm = new[] { lblitem, lblitem1, lblitem2, lblitem3, lblitem4, lblitem5, lblitem6, lblitem7, lblitem8, lblitem9, lblitem10, lblitem11, lblitem12, lblitem13, lblitem14, lblitem15, lblitem15, lblitem15 };
                var Grid = new[] { gvGateaux, gvSnacks, gvPuddings, gvBeverages, gvSweets, gvcandles, gvMousse, gvCookies, gvcheese, gvStores, gvBday, gvbread, gvSponges, gvReadySp, gvRmCake, gvIce, gvIce, gvIce };
                DataSet dcat = objbs.selectCATneworder();
               // for (int i = 0; i < dcat.Tables[0].Rows.Count; i++)
                for (int i = 0; i < 15; i++)
                {
                    tab[i].Style.Add("visibility", "visible");
                    itm[i].InnerText = dcat.Tables[0].Rows[i]["category"].ToString();


                    //   DataSet dGateaux = objbs.getItems(int.Parse(dcat.Tables[0].Rows[i]["categoryid"].ToString()), sCode);
                    DataSet dGateaux = objbs.DalilystockRequest(int.Parse(dcat.Tables[0].Rows[i]["categoryid"].ToString()), sTableName);
                    Grid[i].DataSource = dGateaux;
                    Grid[i].DataBind();


                    foreach (GridViewRow gr in Grid[i].Rows)
                    {

                        DataSet dCategory = objbs.getUOM();


                        int itemid = Convert.ToInt32(gr.Cells[3].Text);

                        DataSet dsUnit = objbs.GetCategoryDetails_ById(itemid);
                        TextBox txtqty = (TextBox)gr.FindControl("txtQty");

                        DropDownList Units = (DropDownList)gr.FindControl("ddUnits");
                        if (dCategory.Tables[0].Rows.Count > 0)
                        {
                            Units.DataSource = dCategory.Tables[0];
                            Units.DataTextField = "UOM";
                            Units.DataValueField = "UOMID";
                            Units.DataBind();
                            Units.Items.Insert(0, "Select");
                            if (dsUnit.Tables[0].Rows.Count > 0)
                            {
                                Units.SelectedValue = dsUnit.Tables[0].Rows[0]["Unit"].ToString();
                            }

                        }

                        Units.SelectedValue = gr.Cells[5].Text;

                        decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                        DataSet ds = objbs.setQty(itemid, Convert.ToInt32(lblUserID.Text));
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            decimal dmin = Convert.ToDecimal(ds.Tables[0].Rows[0]["MinQty"].ToString());
                            decimal set = Convert.ToDecimal(ds.Tables[0].Rows[0]["FixQty"].ToString());


                            //if (avl <= dmin)
                            //{
                            //    gr.BackColor = System.Drawing.Color.Yellow;
                            //    txtqty.Text = set.ToString("f0");
                            //}
                        }
                    }
                }
            }
        }


        protected void btnvalue_Click(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            DataSet dss = objbs.checkrequestallowornot(sTableName);
            if (dss.Tables[0].Rows.Count > 0)
            {
                //sCode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            //Checking Local DB

            DataSet checktable = objbs.checktableexisitsornot("tblPurchaseRequest_" + sCodeBnch + "");
            if (checktable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            DataSet checktranstable = objbs.checktableexisitsornot("tblTransPurchaseRequest_" + sCodeBnch + "");
            if (checktranstable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }


            //Checking LIVE DB

            DataSet livechecktable = objbs.checktableexisitsornotlive("tblPurchaseRequestProd_" + sCodeProd + "");
            if (livechecktable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            DataSet livechecktranstable = objbs.checktableexisitsornotlive("tblTransPurchaseRequestProd_" + sCodeProd + "");
            if (livechecktranstable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }





            //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "confitm('Request will Be sent');", true);
            btnsave.Text = "Wait";
            btnsave.Enabled = false;
            string requestentrytime = System.DateTime.Now.ToString("hh:mm tt");
           // DateTime delaydate = System.DateTime.Now.ToString();
          //  string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");

            DateTime sDate = DateTime.ParseExact(txtpodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
           

            if (txtOrderBy.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('Enter OrderBy');", true);
                return;
            }
            if (txtOrderBy.Text == "")
                txtOrderBy.Text = "No Name";

            if (txtOrderBy.Text != "")
            {

                DataSet dReqNo = objbs.ReqNo(Convert.ToInt32(lblUserID.Text), sCodeBnch);
                txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();

                int MainRequestID = objbs.insert_stockrequest(Convert.ToInt32(empid), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sCodeBnch, requestentrytime, sCodeProd, sDate, sDate);

               
              

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);
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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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
                        int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID, sDate);

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

                //    int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate,sCodeProd);




                //}

                //btnsave.Text = "Save";
                //btnsave.Enabled = true;
                //#endregion
                //System.Threading.Thread.Sleep(5000);


                // Response.Redirect("SalesPrintNormal.aspx?iSalesID=" + e.CommandArgument.ToString() + "&frmdate=" + frmdate + "&todate=" + todate + "&ddl=" + ddlbillno.SelectedValue + "&textbox=" + txtAutoName.Text + "");

                #region SendMail
                //string aaa = DateTime.Now.ToString("dd/MM/yyyy");
                //DataSet ds = objbs.RequestDetqqqorg(txtpono.Text, sCode, aaa);
                //gvUserInfo.DataSource = ds;
                //gvUserInfo.DataBind();

                //SendHTMLMail();
                #endregion

                Response.Redirect("PurchaseRequestGrid.aspx");
            }


            else
            {
                //lbl.Text = "Enter Your name";
            }
        }


        #region SendMail Attachment

        public void SendHTMLMail()
        {
            MailMessage Msg = new MailMessage();
            MailAddress fromMail = new MailAddress("bigdbiz@gmail.com");//("administrator@aspdotnet-suresh.com");
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress("rajar@bigdbiz.in"));
            // Subject of e-mail
            Msg.Subject = "Send Gridivew in EMail";
            Msg.Body += "Please check below data <br/><br/>";

            Msg.Body += "Request From <br/><br/>";
            Msg.Body += "Request No  below data <br/><br/>";
            Msg.Body += "Request Date <br/><br/>";
            Msg.Body += "Request Entry <br/><br/>";

            Msg.Body += GetGridviewData(gvUserInfo);
            Msg.IsBodyHtml = true;
            //////string sSmtpServer = "";
            //////sSmtpServer = "587";
            //////SmtpClient a = new SmtpClient();
            //////a.Host = sSmtpServer;
            //////a.EnableSsl = true;
            //////a.Send(Msg);


            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }
        // This Method is used to render gridview control
        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

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
                int itemid = Convert.ToInt32(gr.Cells[3].Text);

                decimal avl = Convert.ToDecimal(gr.Cells[4].Text);
                DataSet ds = objbs.setQty(itemid, Convert.ToInt32(lblUserID.Text));

                decimal dmin = Convert.ToDecimal(ds.Tables[0].Rows[0]["MinQty"].ToString());
                decimal set = Convert.ToDecimal(ds.Tables[0].Rows[0]["FixQty"].ToString());


                if (avl <= dmin)
                {
                    txtqty.Text = set.ToString("f0");
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
                DataSet ds = objbs.setQty(itemid, Convert.ToInt32(lblUserID.Text));

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
                DataSet ds = objbs.setQty(itemid, Convert.ToInt32(lblUserID.Text));

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

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseRequestGrid.aspx");
        }
    }
}