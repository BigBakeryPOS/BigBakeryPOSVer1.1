using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Net;
using System.IO;

namespace Billing
{
    public partial class PurchaseReturn : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        decimal dTax = 0, dTax1 = 0, dTax2 = 0, dTax3 = 0, dTax4 = 0, dTax5 = 0;
        decimal dTaxAmt = 0, dTaxAmt1 = 0, dTaxAmt2 = 0, dTaxAmt3 = 0, dTaxAmt4 = 0, dTaxAmt5 = 0;
        string sTableName = "";
        string iDealer = "";
        string scode = "";
        string StockOption = "Nil";
        protected void Page_Load(object sender, EventArgs e)
        {

            //btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();

            if (!IsPostBack)
            {
                advance.Visible = false;
                row.Visible = false;
                txtsdate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
              
                DataSet dsCategory = new DataSet();

                //  if (sTableName == "admin")
                dsCategory = objBs.selectcategorymaster();
                //else
                //    dsCategory = objBs.selectcategorymaster_Dealer("tblStock_" + sTableName);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory1 = objBs.selectcategorymaster();
                if (dsCategory1.Tables[0].Rows.Count > 0)
                {
                    ddlcategory1.DataSource = dsCategory.Tables[0];
                    ddlcategory1.DataTextField = "category";
                    ddlcategory1.DataValueField = "categoryid";
                    ddlcategory1.DataBind();
                    ddlcategory1.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory2 = objBs.selectcategorymaster();
                if (dsCategory2.Tables[0].Rows.Count > 0)
                {
                    ddlcategory2.DataSource = dsCategory.Tables[0];
                    ddlcategory2.DataTextField = "category";
                    ddlcategory2.DataValueField = "categoryid";
                    ddlcategory2.DataBind();
                    ddlcategory2.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory3 = objBs.selectcategorymaster();
                if (dsCategory3.Tables[0].Rows.Count > 0)
                {
                    ddlcategory3.DataSource = dsCategory.Tables[0];
                    ddlcategory3.DataTextField = "category";
                    ddlcategory3.DataValueField = "categoryid";
                    ddlcategory3.DataBind();
                    ddlcategory3.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory4 = objBs.selectcategorymaster();
                if (dsCategory4.Tables[0].Rows.Count > 0)
                {
                    ddlcategory4.DataSource = dsCategory.Tables[0];
                    ddlcategory4.DataTextField = "category";
                    ddlcategory4.DataValueField = "categoryid";
                    ddlcategory4.DataBind();
                    ddlcategory4.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory5 = objBs.selectcategorymaster();
                if (dsCategory5.Tables[0].Rows.Count > 0)
                {
                    ddlcategory5.DataSource = dsCategory.Tables[0];
                    ddlcategory5.DataTextField = "category";
                    ddlcategory5.DataValueField = "categoryid";
                    ddlcategory5.DataBind();
                    ddlcategory5.Items.Insert(0, "Select Category");


                }

               

                string iSalesID = Request.QueryString.Get("iSalesID");
               string sReturn = Request.QueryString.Get("Return");

               if (sReturn != null)
                {


                    DataSet dDealer = objBs.GoodReceivedList((iDealer),scode);
                    if (dDealer.Tables[0].Rows.Count > 0)
                    {
                        //int iCustid = Convert.ToInt32(dDealer.Tables[0].Rows[0]["DealerID"].ToString());
                        //DataSet dsCustomer = objBs.GetCustNamenA(Convert.ToInt32(iCustid));
                        //if (dsCustomer.Tables[0].Rows.Count > 0)
                        //{
                        //    //ddlcustomerID.DataSource = dsCustomer.Tables[0];
                        //    //ddlcustomerID.DataTextField = "CustomerName";
                        //    //ddlcustomerID.DataValueField = "CustomerID";
                        //    //ddlcustomerID.DataBind();
                        //    //ddlcustomerID.Items.Insert(0, "Select Customer");



                        //    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                        //}

                        ////ddlcustomerID.SelectedValue = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();
                        ////txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                        //txtaddress.Text = dsCustomer.Tables[0].Rows[0]["Address"].ToString();
                        //// txtarea.Text = dsCustomer.Tables[0].Rows[0]["Area"].ToString();
                        //txtcity.Text = dsCustomer.Tables[0].Rows[0]["City"].ToString();
                        //txtpincode.Text = dsCustomer.Tables[0].Rows[0]["pincode"].ToString();
                    }



                    DataSet dsCategorydef = objBs.selectcategoryalldecription();
                    if (dsCategorydef.Tables[0].Rows.Count > 0)
                    {

                        ddldef.DataSource = dsCategorydef.Tables[0];
                        ddldef.DataTextField = "Definition";
                        ddldef.DataValueField = "categoryuserid";
                        ddldef.DataBind();
                        ddldef.Items.Insert(0, "Select Description");

                    }
                    ddlcategory.SelectedValue = dDealer.Tables[0].Rows[0]["CategoryID"].ToString();
                    ddldef.SelectedValue = dDealer.Tables[0].Rows[0]["SubCategoryID"].ToString();
                    txtqty.Text = dDealer.Tables[0].Rows[0]["Quantity"].ToString();
                    txtDate.Text = dDealer.Tables[0].Rows[0]["ExpiryDate"].ToString();
                   
                  
                   
                    
                    int iCount = dDealer.Tables[0].Rows.Count;
                    var DDLDEF = new[] { ddldef1, ddldef2, ddldef3, ddldef4, ddldef5 };
                    var DDLCAT = new[] { ddlcategory1, ddlcategory2, ddlcategory3, ddlcategory4, ddlcategory5 };
                    var QTY = new[] { txtqty1, txtqty2, txtqty3, txtqty4, txtqty5 };
                    var Date = new[] { txtDate1, txtDate2, txtDate3, txtDate4,txtDate5 };

                    for (int i = 0; i < iCount - 1; i++)
                    {
                        DDLDEF[i].DataSource = dsCategorydef.Tables[0];
                        DDLDEF[i].DataTextField = "Definition";
                        DDLDEF[i].DataValueField = "categoryuserid";
                        DDLDEF[i].DataBind();
                        DDLDEF[i].Items.Insert(0, "Select Description");

                        DDLCAT[i].SelectedValue = dDealer.Tables[0].Rows[i + 1]["CategoryID"].ToString();
                        DDLDEF[i].SelectedValue = dDealer.Tables[0].Rows[i + 1]["SubCategoryID"].ToString();
                        QTY[i].Text = dDealer.Tables[0].Rows[i + 1]["Quantity"].ToString();
                        Date[i].Text = dDealer.Tables[0].Rows[i + 1]["ExpiryDate"].ToString();
                       
                       
                        //Decimal dSub1 = Convert.ToDecimal(txtamount.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
                        //txttotal.Text = Decimal.Round(dSub1, 2).ToString("f2");
                  
                    }
                    Decimal dSub1 = Convert.ToDecimal(txtqty.Text) + Convert.ToDecimal(txtqty1.Text) + Convert.ToDecimal(txtqty2.Text) + Convert.ToDecimal(txtqty3.Text) + Convert.ToDecimal(txtqty4.Text) + Convert.ToDecimal(txtqty5.Text);
                    txtgrandtotal.Text = Decimal.Round(dSub1, 2).ToString("f2");

                }
                else
                {

                    DataSet ds = objBs.SalesBillno("tblSales_" + sTableName,"");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // int iBillNo = ds.Tables[0].Rows[0]["billno"].ToString();
                        if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                            txtbillno.Text = "1";
                        else
                            txtbillno.Text = ds.Tables[0].Rows[0]["billno"].ToString();

                        //  txtdate1.Text = DateTime.Today.ToString("dd/MM/yyyy");

                        btnadd.Text = "Save";
                    }

                }
            }

        }
        //ddlcustomerID.Text = objBs.CustomerID().ToString();




        protected void ddlcustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataSet dsCustDet = objBs.GetCustomerDetails(Convert.ToInt32(ddlcustomerID.SelectedValue));

            //if (dsCustDet.Tables[0].Rows.Count > 0)
            //{
            //    txtcustomername.Text = dsCustDet.Tables[0].Rows[0]["CustomerName"].ToString();
            //    txtaddress.Text = dsCustDet.Tables[0].Rows[0]["Address"].ToString();
            //    txtcity.Text = dsCustDet.Tables[0].Rows[0]["City"].ToString();
            //    //txtarea.Text = dsCustDet.Tables[0].Rows[0]["Area"].ToString();
            //    txtpincode.Text = dsCustDet.Tables[0].Rows[0]["Pincode"].ToString();
            //    txtcuscode.Text = dsCustDet.Tables[0].Rows[0]["CustomerID"].ToString();
            //    txtmobileno.Text = dsCustDet.Tables[0].Rows[0]["MobileNo"].ToString();

            //}

        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue), sTableName);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                ddldef.Enabled = true;
                ddldef.DataSource = dsCategory.Tables[0];
                ddldef.DataTextField = "Definition";
                ddldef.DataValueField = "categoryuserid";
                ddldef.DataBind();
                ddldef.Items.Insert(0, "Select Description");

            }

            else
            {
                ddldef.Text = "Select Description";
                ddldef.Enabled = false;
            }
        }
        protected void ddlcategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory1 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory1.SelectedValue), sTableName);
            if (dsCategory1.Tables[0].Rows.Count > 0)
            {
                ddldef1.Enabled = true;
                ddldef1.DataSource = dsCategory1.Tables[0];
                ddldef1.DataTextField = "Definition";
                ddldef1.DataValueField = "categoryuserid";
                ddldef1.DataBind();
                ddldef1.Items.Insert(0, "Select Description");

            }
            else
            {
                ddldef1.Text = "Select Description";
                ddldef1.Enabled = false;
            }
        }
        protected void ddlcategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory2 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory2.SelectedValue), sTableName);
            if (dsCategory2.Tables[0].Rows.Count > 0)
            {
                ddldef2.Enabled = true;
                ddldef2.DataSource = dsCategory2.Tables[0];
                ddldef2.DataTextField = "Definition";
                ddldef2.DataValueField = "categoryuserid";
                ddldef2.DataBind();
                ddldef2.Items.Insert(0, "Select Description");

            }
            else
            {
                ddldef2.Text = "Select Description";
                ddldef2.Enabled = false;
            }
        }
        protected void ddlcategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory3 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory3.SelectedValue), sTableName);
            if (dsCategory3.Tables[0].Rows.Count > 0)
            {
                ddldef3.Enabled = true;
                ddldef3.DataSource = dsCategory3.Tables[0];
                ddldef3.DataTextField = "Definition";
                ddldef3.DataValueField = "categoryuserid";
                ddldef3.DataBind();
                ddldef3.Items.Insert(0, "Select Description");

            }
            else
            {
                ddldef3.Text = "Select Description";
                ddldef3.Enabled = false;
            }
        }

        protected void ddlcategory4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory4 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory4.SelectedValue), sTableName);
            if (dsCategory4.Tables[0].Rows.Count > 0)
            {
                ddldef4.Enabled = true;
                ddldef4.DataSource = dsCategory4.Tables[0];
                ddldef4.DataTextField = "Definition";
                ddldef4.DataValueField = "categoryuserid";
                ddldef4.DataBind();
                ddldef4.Items.Insert(0, "Select Description");

            }
            else
            {
                ddldef4.Text = "Select Description";
                ddldef4.Enabled = false;
            }
        }

        protected void ddlcategory5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory5 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory5.SelectedValue), sTableName);
            if (dsCategory5.Tables[0].Rows.Count > 0)
            {
                ddldef5.Enabled = true;
                ddldef5.DataSource = dsCategory5.Tables[0];
                ddldef5.DataTextField = "Definition";
                ddldef5.DataValueField = "categoryuserid";
                ddldef5.DataBind();
                ddldef5.Items.Insert(0, "Select Description");

            }
            else
            {
                ddldef5.Text = "Select Description";
                ddldef5.Enabled = false;
            }
        }
          private int UpdateStockAvailable(int iCat, int iSubCat, int iQty,string Date)
        {
            decimal iAQty = 0;
                
                int iSuccess = 0;
            //if (sTableName == "admin")
            //{

            
            
                DataSet dsStock = objBs.GetStockDetailsReturn(iSubCat,Date,sTableName);
                if (dsStock.Tables[0].Rows.Count > 0)
                {
                    iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                }
                decimal iRemQty = iAQty - iQty;
                iSuccess = objBs.updatePurchaseSalesStock(iRemQty, iCat, iSubCat, txtDate.Text,sTableName);
            
            //}
            //else
            //{
            //    DataSet dsStock = objBs.GetStockDetails_Dealer(iSubCat, "tblStock_" + sTableName);
            //    if (dsStock.Tables[0].Rows.Count > 0)
            //    {
            //        iAQty = Convert.ToInt32(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

            //    }
            //    int iRemQty = iAQty - iQty;
            //    iSuccess = objBs.updateSalesStock_dealer(iRemQty, iCat, iSubCat,"tblStock_"+sTableName);
            //}
            return iSuccess;
        }

        //private int UpdateEditStock(int iCat, int iSubCat, int iQty)
        //{
        //    Decimal iAQty = 0; 
        //        int iSuccess = 0;
        //    //if (sTableName == "admin")
        //    //{
        //    DataSet dsStock = objBs.GetStockDetails(iSubCat);
        //    if (dsStock.Tables[0].Rows.Count > 0)
        //    {
        //        iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

        //    }
        //    Decimal iInsQty = iAQty + iQty;
        //    iSuccess = objBs.updateSalesStock(iInsQty, iCat, iSubCat, txtDate.Text);

        //    return iSuccess;
        //}
        protected void Add_Click(object sender, EventArgs e)
        {

            if (btnadd.Text == "Save")
            {


                //if (ddlcustomerID.SelectedValue == "Select Customer")
                //{

                //    lblerrorname.Text = "Please Select Customer Name";
                //}

                
                   

                        //DataTable dt = new DataTable();
                        //DataRow dr = null;
                        //dt.Columns.Add(new DataColumn("CatID", typeof(int)));
                        //string iDealer = Request.QueryString.Get("iDealer");
                        //if (iDealer != "" || iDealer != null)
                        //{
                        //    dr = dt.NewRow();
                        //    dr["CatID"] = ddldef.SelectedValue;
                        //    dt.Rows.Add(dr);
                        //}
                        //else
                        //{
                        //    dr = dt.NewRow();
                        //    dr["CatID"] = ddldef.SelectedValue;
                        //    dt.Rows.Add(dr);
                        //    if (ddldef1.SelectedValue != "Select Description")
                        //    {
                        //        dr = dt.NewRow();
                        //        dr["CatID"] = ddldef1.SelectedValue;
                        //        dt.Rows.Add(dr);
                        //    }
                        //    if (ddldef2.SelectedValue != "Select Description")
                        //    {
                        //        dr = dt.NewRow();
                        //        dr["CatID"] = ddldef2.SelectedValue;
                        //        dt.Rows.Add(dr);
                        //    }
                        //    if (ddldef3.SelectedValue != "Select Description")
                        //    {
                        //        dr = dt.NewRow();
                        //        dr["CatID"] = ddldef3.SelectedValue;
                        //        dt.Rows.Add(dr);
                        //    }
                        //    if (ddldef4.SelectedValue != "Select Description")
                        //    {
                        //        dr = dt.NewRow();
                        //        dr["CatID"] = ddldef4.SelectedValue;
                        //        dt.Rows.Add(dr);
                        //    }
                        //    if (ddldef5.SelectedValue != "Select Description")
                        //    {
                        //        dr = dt.NewRow();
                        //        dr["CatID"] = ddldef5.SelectedValue;
                        //        dt.Rows.Add(dr);
                        //    }
                        //}
                        //DataTable ds = dt.DefaultView.ToTable(true, "CatID");//Columns.
                        //if (ds.Rows.Count != dt.Rows.Count)
                        //    lblError.Text = "Same Description Exist";
                        //else
                        
                            // Response.Write("same value exist");

                            int iStatus2 = 0, iStatus3 = 0, iStatus4 = 0, iStatus5 = 0, iStockSuccess = 0;
                            //string Idealer = Request.QueryString.Get("iDealer");
                            //string iQrySalesID = Request.QueryString.Get("iSalesID");

                            int isave = objBs.insertPurchaseReturn("Branch" + sTableName, txtCustname.Text, txtbillno.Text, txtsdate1.Text, txtRequestNo.Text, txtgrandtotal.Text, "", 0, txtProduction.Text, 0, Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()));
                            
                            {
                                if (txtqty.Text != "0")
                                {
                                    //int isalesid = Convert.ToInt32(txtbillno.Text);// objBs.SalesId("tblSales_" + sTableName);
                                    // int iStatus1 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(txtqty.Text), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtDiscItem.Text), Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddldef.SelectedValue));

                                    int iTrans = objBs.insertTransPurchaseReturn(txtbillno.Text, Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), txtqty.Text, ddlUnits.SelectedItem.Text, ddlReasons.SelectedItem.Text);
                                    DataSet dcheck = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef.SelectedValue));
                                    if (dcheck.Tables[0].Rows.Count > 0)
                                    {
                                        //to check printing
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(txtqty.Text),txtDate.Text);
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(txtqty.Text), txtDate.Text);
                                    }
                                }
                                if (txtqty1.Text != "0")
                                {
                                    //iStatus2 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(txtqty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtDiscItem1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToInt32(ddldef1.SelectedValue));
                                    int iTrans = objBs.insertTransPurchaseReturn(txtbillno.Text, Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), txtqty1.Text, ddlUnits1.SelectedItem.Text, ddlReasons1.SelectedItem.Text);
                                    DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef1.SelectedValue));
                                    if (dcheck1.Tables[0].Rows.Count > 0)
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(txtqty1.Text), txtDate1.Text);
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(txtqty1.Text), txtDate1.Text);
                                    }
                                }
                                if (txtqty2.Text != "0")
                                {
                                   // iStatus2 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(txtqty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtDiscItem2.Text), Convert.ToDouble(txtamount2.Text), Convert.ToInt32(ddldef2.SelectedValue));
                                    int iTrans = objBs.insertTransPurchaseReturn(txtbillno.Text, Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), txtqty2.Text, ddlUnits2.SelectedItem.Text, ddlReasons2.SelectedItem.Text);
                                    DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef2.SelectedValue));
                                    if (dcheck1.Tables[0].Rows.Count > 0)
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(txtqty2.Text), txtDate2.Text);
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(txtqty2.Text), txtDate2.Text);
                                    }
                                }

                                if (txtqty3.Text != "0")
                                {
                                    //iStatus3 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(txtqty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtDiscItem3.Text), Convert.ToDouble(txtamount3.Text), Convert.ToInt32(ddldef3.SelectedValue));
                                    int iTrans = objBs.insertTransPurchaseReturn(txtbillno.Text, Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), txtqty3.Text, ddlUnits3.SelectedItem.Text, ddlReasons3.SelectedItem.Text);
                                    DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef3.SelectedValue));
                                    if (dcheck1.Tables[0].Rows.Count > 0)
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(txtqty2.Text),txtDate3.Text);
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(txtqty3.Text),txtDate3.Text);
                                    }
                                }
                                if (txtqty4.Text != "0")
                                {
                                   //iStatus4 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(txtqty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtDiscItem4.Text), Convert.ToDouble(txtamount4.Text), Convert.ToInt32(ddldef4.SelectedValue));
                                    int iTrans = objBs.insertTransPurchaseReturn(txtbillno.Text, Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), txtqty4.Text, ddlUnits4.SelectedItem.Text, ddlReasons4.SelectedItem.Text);
                                    DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef4.SelectedValue));
                                    if (dcheck1.Tables[0].Rows.Count > 0)
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(txtqty2.Text),txtDate4.Text);
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(txtqty4.Text),txtDate4.Text);
                                    }
                                }

                                if (txtqty5.Text != "0")
                                {
                                    //iStatus5 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(txtqty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtDiscItem5.Text), Convert.ToDouble(txtamount5.Text), Convert.ToInt32(ddldef5.SelectedValue));
                                    int iTrans = objBs.insertTransPurchaseReturn(txtbillno.Text, Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), txtqty5.Text, ddlUnits5.SelectedItem.Text, ddlReasons5.SelectedItem.Text);
                                    DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef5.SelectedValue));
                                    if (dcheck1.Tables[0].Rows.Count > 0)
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(txtqty2.Text),txtDate5.Text);
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(txtqty5.Text),txtDate5.Text);
                                    }
                                }

                                StringBuilder sb = new StringBuilder();
                                sb.Append("From Bigdbiz-");
                                sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtsdate1.Text + ",");
                                sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");


                                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.f9cs.com/sendsms.jsp?user=pratheep&password=demo1234&mobiles=&senderid=FINECS&sms="+sb.ToString()+"");
                                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                //StreamReader reader = new StreamReader(response.GetResponseStream());
                                //string result = reader.ReadToEnd();
                            }
                        }
                        Response.Redirect("../Accountsbootstrap/Home_Page.aspx");
                    }
            





          

       

       

        //private int InsertStockAvailable(int iCat, int iSubCat, int iQty)
        //{
        //    Decimal iAQty = 0;
        //    int iSuccess = 0;
        //    //if (sTableName == "admin")
        //    //{

        //    string iQrySalesID = Request.QueryString.Get("iSalesID");
        //    if (iQrySalesID != null)
        //    {
        //        DataSet dsStock = objBs.GetStockDetails(iSubCat);
        //        if (dsStock.Tables[0].Rows.Count > 0)
        //        {
        //            iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

        //        }
        //        Decimal iRemQty = iAQty + iQty;
        //        iSuccess = objBs.updateSalesStock(iRemQty, iCat, iSubCat);
        //    }

        //    //}
        //    //else
        //    //{
        //    //    DataSet dsStock = objBs.GetStockDetails_Dealer(iSubCat, "tblStock_" + sTableName);
        //    //    if (dsStock.Tables[0].Rows.Count > 0)
        //    //    {
        //    //        iAQty = Convert.ToInt32(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

        //    //    }
        //    //    int iRemQty = iAQty - iQty;
        //    //    iSuccess = objBs.updateSalesStock_dealer(iRemQty, iCat, iSubCat,"tblStock_"+sTableName);
        //    //}
        //    return iSuccess;
        //}




  
        protected void btncalc_Click(object sender, EventArgs e)
        {


            decimal dGrand = Convert.ToDecimal(txtqty.Text) + Convert.ToDecimal(txtqty1.Text) + Convert.ToDecimal(txtqty2.Text) + Convert.ToDecimal(txtqty3.Text) + Convert.ToDecimal(txtqty4.Text) + Convert.ToDecimal(txtqty5.Text);
            txtgrandtotal.Text = dGrand.ToString("f2");
            


        }
     
        protected void ddldef_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dsStock = new DataSet();
            //if(sTableName=="admin")
            dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            //else
            //    dsStock = objBs.GetStockDetails_Dealer(Convert.ToInt32(ddldef.SelectedValue),"tblStock_"+sTableName);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                string sQty = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
                txtqty.ToolTip = "AvailableQty" + sQty;
                Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
               
                DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef.SelectedValue));
                dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());

                //if (bblbillto.SelectedValue == "1")
                //{
                //    Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
                //    txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                //    txtOrgRate.Text = Decimal.Round(Irate, 2).ToString("f2");
                //}
                //else if (bblbillto.SelectedValue == "2")
                //{

                //    Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
                //    txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                //    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef.SelectedValue));
                //    dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                //}

                //else
                //{
                //    Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["PressUnitPrice"].ToString());
                //    txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                //}
                ////Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty.Text)) * (Convert.ToDecimal(txtrate.Text)));
                //txtamount.Text = Convert.ToString(iNetAmount1);
            

            }
        }

        protected void ddldef1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                string sQty1 = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
                txtqty1.ToolTip = "AvailableQty" + sQty1;
                Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
               
                DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef1.SelectedValue));
                dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                //if (bblbillto.SelectedValue == "1")
                //{
                //    Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
                //    txtrate1.Text = Decimal.Round(Irate, 2).ToString("f2");
                //}
                //else if (bblbillto.SelectedValue == "2")
                //{
                //    Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
                //    txtrate1.Text = Decimal.Round(Irate, 2).ToString("f2");
                //    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef1.SelectedValue));
                //    dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                //}

                //else
                //{
                //    Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["PressUnitPrice"].ToString());
                //    txtrate1.Text = Decimal.Round(Irate, 2).ToString("f2");
                //}
                ////Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty1.Text)) * (Convert.ToDecimal(txtrate1.Text)));
                //txtamount1.Text = Convert.ToString(iNetAmount1);
             
            }
        }

        protected void ddldef2_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            
            DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef2.SelectedValue));
            dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());

            //if (dsStock.Tables[0].Rows.Count > 0)
            //{
            //   string sqty2 = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
            //   txtqty2.ToolTip = "Availableqty" + sqty2;
            //    if (bblbillto.SelectedValue == "1")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            //        txtrate2.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //    else if (bblbillto.SelectedValue == "2")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
            //        txtrate2.Text = Decimal.Round(Irate, 2).ToString("f2");
            //        DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef2.SelectedValue));
            //        dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //    }

            //    else
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["PressUnitPrice"].ToString());
            //        txtrate2.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //  Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty2.Text)) * (Convert.ToDecimal(txtrate2.Text)));
            //txtamount2.Text = Convert.ToString(iNetAmount1);
          
        }

        protected void ddldef3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
           
            DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef3.SelectedValue));
            dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{
            //   string sqty3 = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
            //   txtqty3.ToolTip = "AvailableQty" + sqty3;
            //    if (bblbillto.SelectedValue == "1")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            //        txtrate3.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //    else if (bblbillto.SelectedValue == "2")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
            //        txtrate3.Text = Decimal.Round(Irate, 2).ToString("f2");
            //        DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef3.SelectedValue));
            //        dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //    }

            //    else
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["PressUnitPrice"].ToString());
            //        txtrate3.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //   // Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty3.Text)) * (Convert.ToDecimal(txtrate3.Text)));
            // txtamount3.Text = Convert.ToString(iNetAmount1);
         

        }

        protected void ddldef4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
           
            DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef4.SelectedValue));
            dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{
            //  string sqty4 = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
            //  txtqty4.ToolTip = "availableQty" + sqty4;
            //    if (bblbillto.SelectedValue == "1")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            //        txtrate4.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //    else if (bblbillto.SelectedValue == "2")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
            //        txtrate4.Text = Decimal.Round(Irate, 2).ToString("f2");
            //        DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef4.SelectedValue));
            //        dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //    }

            //    else
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["PressUnitPrice"].ToString());
            //        txtrate4.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty4.Text)) * (Convert.ToDecimal(txtrate4.Text)));
            // txtamount4.Text = Convert.ToString(iNetAmount1);
        

        }
        protected void ddldef5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
        
            DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef5.SelectedValue));
            dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{
            //    string sqty5 = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
            //    txtqty5.ToolTip = "AvailableQty" + sqty5;
            //    if (bblbillto.SelectedValue == "1")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            //        txtrate5.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //    else if (bblbillto.SelectedValue == "2")
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
            //        txtrate5.Text = Decimal.Round(Irate, 2).ToString("f2");
            //        DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef5.SelectedValue));
            //        dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            //    }

            //    else
            //    {
            //        Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["PressUnitPrice"].ToString());
            //        txtrate5.Text = Decimal.Round(Irate, 2).ToString("f2");
            //    }
            //  //  Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty5.Text)) * (Convert.ToDecimal(txtrate5.Text)));
            //  //  txtamount5.Text = Convert.ToString(iNetAmount1);
          

        }

       


       
      
        

        protected void btnsales_Click(object sender, EventArgs e)
        {
            string url = "itempage.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }



        protected void imgClear1_Click1(object sender, ImageClickEventArgs e)
        {
            ddlcategory1.ClearSelection();
            ddldef1.ClearSelection();
            txtqty1.Text = "0";
          
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory2.ClearSelection();
            ddldef2.ClearSelection();
            txtqty2.Text = "0";
          
        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory3.ClearSelection();
            ddldef3.ClearSelection();
            txtqty3.Text = "0";
          
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory4.ClearSelection();
            ddldef4.ClearSelection();
            txtqty4.Text = "0";
          
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory5.ClearSelection();
            ddldef5.ClearSelection();
            txtqty5.Text = "0";
        }

        protected void btncheck_Click(object sender, EventArgs e)
        {
            
        }

        protected void btncheck_Click1(object sender, EventArgs e)
        {
            row.Visible = true;
            DataSet dDealer = objBs.GoodReceivedListReturn((txtCustname.Text), Convert.ToInt32(lblUserID.Text));
            if (dDealer.Tables[0].Rows.Count > 0)
            {
                //int iCustid = Convert.ToInt32(dDealer.Tables[0].Rows[0]["DealerID"].ToString());
                //DataSet dsCustomer = objBs.GetCustNamenA(Convert.ToInt32(iCustid));
                //if (dsCustomer.Tables[0].Rows.Count > 0)
                //{
                //    //ddlcustomerID.DataSource = dsCustomer.Tables[0];
                //    //ddlcustomerID.DataTextField = "CustomerName";
                //    //ddlcustomerID.DataValueField = "CustomerID";
                //    //ddlcustomerID.DataBind();
                //    //ddlcustomerID.Items.Insert(0, "Select Customer");



                //    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                //}

                ////ddlcustomerID.SelectedValue = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();
                ////txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                //txtaddress.Text = dsCustomer.Tables[0].Rows[0]["Address"].ToString();
                //// txtarea.Text = dsCustomer.Tables[0].Rows[0]["Area"].ToString();
                //txtcity.Text = dsCustomer.Tables[0].Rows[0]["City"].ToString();
                //txtpincode.Text = dsCustomer.Tables[0].Rows[0]["pincode"].ToString();
            }



            DataSet dsCategorydef = objBs.selectcategoryalldecription();
            if (dsCategorydef.Tables[0].Rows.Count > 0)
            {

                ddldef.DataSource = dsCategorydef.Tables[0];
                ddldef.DataTextField = "Definition";
                ddldef.DataValueField = "categoryuserid";
                ddldef.DataBind();
                ddldef.Items.Insert(0, "Select Description");

            }
            ddlcategory.SelectedValue = dDealer.Tables[0].Rows[0]["CategoryID"].ToString();
            ddldef.SelectedValue = dDealer.Tables[0].Rows[0]["DescriptionID"].ToString();
            txtqty.Text = dDealer.Tables[0].Rows[0]["Received_Qty"].ToString();
            txtProduction.Text = dDealer.Tables[0].Rows[0]["ProductionName"].ToString();
            txtRequestNo.Text = dDealer.Tables[0].Rows[0]["RequestNo"].ToString();
            DateTime sDate =Convert.ToDateTime( dDealer.Tables[0].Rows[0]["ExpiryDate"].ToString());
            txtDate.Text = sDate.ToString("yyyy-MM-dd");





            int iCount = dDealer.Tables[0].Rows.Count;
            var DDLDEF = new[] { ddldef1, ddldef2, ddldef3, ddldef4, ddldef5 };
            var DDLCAT = new[] { ddlcategory1, ddlcategory2, ddlcategory3, ddlcategory4, ddlcategory5 };
            var QTY = new[] { txtqty1, txtqty2, txtqty3, txtqty4, txtqty5 };
            var Date = new[] { txtDate1, txtDate2, txtDate3, txtDate4, txtDate5 };

            for (int i = 0; i < iCount - 1; i++)
            {
                DDLDEF[i].DataSource = dsCategorydef.Tables[0];
                DDLDEF[i].DataTextField = "Definition";
                DDLDEF[i].DataValueField = "categoryuserid";
                DDLDEF[i].DataBind();
                DDLDEF[i].Items.Insert(0, "Select Description");

                DDLCAT[i].SelectedValue = dDealer.Tables[0].Rows[i + 1]["CategoryID"].ToString();
                DDLDEF[i].SelectedValue = dDealer.Tables[0].Rows[i + 1]["DescriptionID"].ToString();
                QTY[i].Text = dDealer.Tables[0].Rows[i + 1]["Received_Qty"].ToString();
                DateTime dDate =Convert.ToDateTime( dDealer.Tables[0].Rows[i + 1]["ExpiryDate"].ToString());
                Date[i].Text = dDate.ToString("yyyy-MM-dd");




                //Decimal dSub1 = Convert.ToDecimal(txtamount.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
                //txttotal.Text = Decimal.Round(dSub1, 2).ToString("f2");

            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory.ClearSelection();
            ddldef.ClearSelection();
            txtqty.Text = "0";
        }
        

        
    }
}