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
    public partial class StockConversion : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string StockOption = "Nil";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();

            horizontalTab.Visible = false;
            if (!IsPostBack)
            {
                DataSet dSemistock = objbs.convertStock(Convert.ToInt32(lblUserID.Text));
                gvGoodsReceived.DataSource = dSemistock.Tables[0];
                gvGoodsReceived.DataBind();


                ////Puffs
                //DataSet dPuffs = objbs.getItems(1);
                //gvPuffs.DataSource = dPuffs;
                //gvPuffs.DataBind();

                ////Buns
                //DataSet dbuns = objbs.getItems(2);
                //gvBuns.DataSource = dbuns;
                //gvBuns.DataBind();

                ////Cakes

                //DataSet dCake = objbs.getItems(3);
                //gvCakes.DataSource = dCake;
                //gvCakes.DataBind();

                ////Breads
                //DataSet dBread = objbs.getItems(4);
                //gvBread.DataSource = dBread;
                //gvBread.DataBind();

                ////Cookies

                //DataSet dCookies = objbs.getItems(5);
                //gvCookies.DataSource = dCookies;
                //gvCookies.DataBind();

                //DataSet dCandles = objbs.getItems(6);
                //gvcandles.DataSource = dCandles;
                //gvcandles.DataBind();

                //DataSet dmouse = objbs.getItems(7);
                //gvMousse.DataSource = dmouse;
                //gvMousse.DataBind();
                //DataSet d1 = objbs.getItems(8);
                //GridView1.DataSource = d1;
                //GridView1.DataBind();
                //DataSet d2 = objbs.getItems(9);
                //GridView2.DataSource = d2;
                //GridView2.DataBind();
                //DataSet d3 = objbs.getItems(10);
                //GridView3.DataSource = d3;
                //GridView3.DataBind();
                //DataSet d4 = objbs.getItems(11);
                //gvBday.DataSource = d4;
                //gvBday.DataBind();
                //DataSet d5 = objbs.getItems(12);
                //gvbr.DataSource = d5;
                //gvbr.DataBind();

            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            double dWeight = 0;
            double dQty = 0;
            for (int i = 0; i < gvGoodsReceived.Rows.Count; i++)
            {
                TextBox txtConversionQty = (TextBox)gvGoodsReceived.Rows[i].FindControl("txtQty");
                if (txtConversionQty.Text != "")
                {

                    int SubCategoryID = Convert.ToInt32(gvGoodsReceived.Rows[i].Cells[2].Text);
                    int stockid = Convert.ToInt32(gvGoodsReceived.Rows[i].Cells[3].Text);

                    double dAQty = Convert.ToDouble(gvGoodsReceived.Rows[i].Cells[4].Text);

                    double dAvailableQty = Convert.ToDouble(gvGoodsReceived.Rows[i].Cells[5].Text);

                    TextBox txtUsingQty = (TextBox)gvGoodsReceived.Rows[i].FindControl("txtUsing");
                    double dUsingQty = Convert.ToDouble(txtUsingQty.Text);

                    TextBox txtSubCatID = (TextBox)gvGoodsReceived.Rows[i].FindControl("txtItem");
                    int iSubCatID = Convert.ToInt32(txtSubCatID.Text);

                    TextBox txtCatID = (TextBox)gvGoodsReceived.Rows[i].FindControl("txtCatID");
                    int iCatID = Convert.ToInt32(txtCatID.Text);

                    TextBox date = (TextBox)gvGoodsReceived.Rows[i].FindControl("txtDate");
                    if (date.Text == "")
                        date.Text = DateTime.Today.ToShortDateString();
                    else
                    {
                        DateTime ExpiryDate = Convert.ToDateTime(date.Text);
                        string Date = ExpiryDate.ToString("yyyy-MM-dd");
                    }
                    if (gvGoodsReceived.Rows[i].Cells[1].Text.ToLower().Contains("tray") == true)
                    {
                        //TextBox txtConversionQty = (TextBox)gvGoodsReceived.Rows[i].FindControl("txtQty");
                         dQty = Convert.ToDouble(txtConversionQty.Text);

                        double DbalQty = dAvailableQty - dUsingQty;

                        double dBalance = dAQty - (dUsingQty / 3);
                        objbs.UpdateSemiFinishedStok(DbalQty, stockid, Convert.ToInt32(lblUserID.Text), dBalance);
                    }
                    else if (gvGoodsReceived.Rows[i].Cells[1].Text.ToLower().Contains("1kg") == true)
                    {
                         dQty = Convert.ToDouble(txtConversionQty.Text);

                        double DbalQty = dAvailableQty - 1;

                        double dBalance = dAQty - (dUsingQty/1);
                        objbs.UpdateSemiFinishedStok(DbalQty, stockid, Convert.ToInt32(lblUserID.Text), dBalance);
                    }

                    else if (gvGoodsReceived.Rows[i].Cells[1].Text.ToLower().Contains("1/2kg") == true)
                    {
                         dQty = Convert.ToDouble(txtConversionQty.Text);

                        double DbalQty = dAvailableQty - 1;

                        double dBalance = dAQty - (dUsingQty /1);
                        objbs.UpdateSemiFinishedStok(DbalQty, stockid, Convert.ToInt32(lblUserID.Text), dBalance);
                    }
                    //if (iSubCatID == 206)
                    //{
                    //    dWeight = 3;
                    //}
                    //else if (iSubCatID == 213)
                    //{
                    //    dWeight = 3;
                    //}
                    //else if (iSubCatID == 214)
                    //{
                    //    dWeight = 3;
                    //}
                    //else if (iSubCatID == 220)
                    //{
                    //    dWeight = 3;
                    //}
                    //else if (iSubCatID == 223)
                    //{
                    //    dWeight = 3;
                    //}
                    //else
                    //{
                    //    dWeight = 1;
                    //}
                   
                    //double dCla = dQty * dWeight;
                    

                    DataSet dCheck = objbs.GetPurchaseStok(iSubCatID, Convert.ToInt32(lblUserID.Text),sTableName);
                    if (dCheck.Tables[0].Rows.Count > 0)
                    {
                        int stockID =Convert.ToInt32(dCheck.Tables[0].Rows[0]["stockid"].ToString());
                        //objbs.UpdatePurchaseStok(dAvailableQty, DbalQty, iSubCatID, Convert.ToInt32(lblUserID.Text), Date);
                        if (date.Text == "")
                            date.Text = DateTime.Today.ToShortDateString();
                        else
                        {
                            DateTime ExpiryDate = Convert.ToDateTime(date.Text);
                            date.Text = ExpiryDate.ToString("yyyy-MM-dd");
                        }
                        int iStockSuccess = UpdateStockAvailable(iCatID, Convert.ToInt32(iSubCatID), Convert.ToDecimal(txtConversionQty.Text), date.Text, Convert.ToString(stockID));
                    }
                    else
                    {
                        if (date.Text == "")
                            date.Text = DateTime.Today.ToShortDateString();
                        else
                        {
                            DateTime ExpiryDate = Convert.ToDateTime(date.Text);
                            date.Text = ExpiryDate.ToString("yyyy-MM-dd");
                        }
                        int iRtn = objbs.InsertStock(sTableName,Convert.ToInt32(lblUserID.Text), iCatID, iSubCatID, dQty, dQty, Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), date.Text, 0);
                    }
                }
            }
            Response.Redirect("Home_Page.aspx");
        }
        private int UpdateStockAvailable(int iCat, int iSubCat, decimal iQty, string sDate, string iStockID)
        {
            decimal iAQty = 0;

            int iSuccess = 0;

            DataSet dsStock = objbs.GetStockDetails(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text),sTableName,"1");
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

            }
            decimal iRemQty = iAQty + iQty;
            iSuccess = objbs.updateSalesStock(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text),sTableName,"+","Stock Conversion",iQty.ToString(),"0","");


            return iSuccess;
        }
        protected void gvGoodsReceived_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsCategory = objbs.selectConversionCategory();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCategory = (DropDownList)(e.Row.FindControl("ddlcategory") as DropDownList);
                ddlCategory.DataSource = dsCategory.Tables[0];
                ddlCategory.DataTextField = "category";
                ddlCategory.DataValueField = "categoryid";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select category");

                //DataSet dDef = objbs.selectcategoryalldecription();
                //DropDownList Def = (DropDownList)e.Row.FindControl("ddlItems");

                //Def.DataSource = dDef.Tables[0];
                //Def.DataTextField = "Definition";
                //Def.DataValueField = "categoryuserid";
                //Def.DataBind();
                //Def.Items.Insert(0, "Select Item");
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlCategory = (DropDownList)row.FindControl("ddlCategory");
            if (ddlCategory.Text != "Select category")
            {
                TextBox txtCatID = (TextBox)row.FindControl("txtCatID");
                txtCatID.Text = ddlCategory.SelectedValue;

                DataSet dsCategory = objbs.selectcategorydecription(Convert.ToInt32(ddlCategory.SelectedValue), sTableName);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    DropDownList Def = (DropDownList)row.FindControl("ddlItems");
                    
                    Def.DataSource = dsCategory.Tables[0];
                    Def.DataTextField = "Definition";
                    Def.DataValueField = "categoryuserid";
                    Def.DataBind();
                    Def.Items.Insert(0, "Select Item");


                }
            }

           
                    
                
            }
        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {  
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlItem = (DropDownList)row.FindControl("ddlItems");
          

               
                if (ddlItem.Text != "Select Item")
                {
                    TextBox txtCatID = (TextBox)row.FindControl("txtItem");
                    txtCatID.Text = ddlItem.SelectedValue;
                }
                //int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, Convert.ToInt32(iCatID), Convert.ToInt32(iSubCatID), Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text));
            }

        protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlUnits = (DropDownList)row.FindControl("ddlUnits");
            TextBox txtUnits = (TextBox)row.FindControl("txtUnits");
            TextBox txtUsing = (TextBox)row.FindControl("txtUsing");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            DropDownList ddlItem = (DropDownList)row.FindControl("ddlItems");


            if (ddlUnits.SelectedValue == "3")
            {
                
                int iFirstVal = 0, iSecondVal = 0, iPiece = 0;
                txtUnits.Text = ddlUnits.SelectedValue;
                string[] sUnitsArr = txtUsing.Text.Split('.');
                if (sUnitsArr.Length > 1)
                {
                    iFirstVal = Convert.ToInt16(sUnitsArr[0]);
                    iSecondVal = Convert.ToInt16(sUnitsArr[1]);
                    iPiece = 0;
                    iPiece += iFirstVal * 8;
                    iPiece += 4;
                }
                else
                {
                    iFirstVal = Convert.ToInt16(sUnitsArr[0]);
                    iPiece = 0;
                    iPiece += iFirstVal * 8;
                    // iPiece +=  4;
                }

                txtQty.Text = Convert.ToString(iPiece);
            }
            else
            {
                if ((ddlItem.SelectedItem.Text.ToLower().Contains("1/2kg") == true))
                {
                decimal usingQty=(Convert.ToDecimal(txtUsing.Text));
                decimal cal = Convert.ToDecimal(1);
               
                    decimal dtotal= usingQty/cal;
                    txtQty.Text = dtotal.ToString("f0");
                }
                else
                {
                    txtQty.Text =txtUsing.Text;
                }

            }
            //int iSAve = objbs.insertTransPurchaseReq(txtpono.Text, Convert.ToInt32(iCatID), Convert.ToInt32(iSubCatID), Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text));
        }

        protected void gvGoodsReceived_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet dSemistock = objbs.convertStock(Convert.ToInt32(lblUserID.Text));
           
            
            gvGoodsReceived.PageIndex = e.NewPageIndex;
            gvGoodsReceived.DataSource = dSemistock.Tables[0];
            gvGoodsReceived.DataBind();
        }

        protected void gvGoodsReceived_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
        }
    
