using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

namespace Billing.Accountsbootstrap
{
    public partial class Stock : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string FirstEntry = "";
          string BranchNAme = "";
        string StoreName = "";
           string Password = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();

             DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);
      
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (sTableName == "admin")
            {
                admin.Visible = true;
            }

            if (!IsPostBack)
            {
                DataSet daygrn = objBs.daygrnVal();
                ddldaygrn.DataSource = daygrn.Tables[0];
                ddldaygrn.DataTextField = "DayGRN";
                ddldaygrn.DataValueField = "id";
                ddldaygrn.DataBind();
                ddldaygrn.Items.Insert(0, "Select GRN");

                DataSet dsCustomer = objBs.getbranchforhomepage();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlstore.DataSource = dsCustomer.Tables[0];
                    ddlstore.DataTextField = "brancharea";
                    ddlstore.DataValueField = "branchname";
                    ddlstore.DataBind();
                    ddlstore.SelectedValue = sTableName;
                    ddlstore.Enabled = false;
                    
                }


                FirstEntry = "yes";
                DataSet dNo = objBs.GRNNO(Convert.ToInt32(lblUserID.Text));
                {
                    if (dNo.Tables[0].Rows[0]["GRNNO"].ToString() != "")
                    {
                        txtgrnno.Text = dNo.Tables[0].Rows[0]["GRNNO"].ToString();
                    }
                    else
                    {
                        txtgrnno.Text = "1";

                    }
                }
                DataSet dsCategory = objBs.selectcategorymasterForGRN();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "printcategory";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select Category");
                    if (sTableName != "admin")
                    {
                        //for (int i = 0; i < ddlcategory.Items.Count; i++)
                        //{
                        //    if (ddlcategory.Items[i].Text.Contains("B'Day Cake"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;

                        //    }

                        //    if (ddlcategory.Items[i].Text.Contains("Spong"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;

                        //    }


                        //    if (ddlcategory.Items[i].Text.Contains("Store"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;

                        //    }
                        //}
                    }
                    if (lblUserID.Text == "5")
                    {
                        //for (int i = 0; i < ddlcategory.Items.Count; i++)
                        //{
                        //    if (ddlcategory.Items[i].Text.Contains("Bread"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;                               
                        //    }
                        //    if (ddlcategory.Items[i].Text.Contains("Cookies"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;
                        //    }
                        //    if (ddlcategory.Items[i].Text.Contains("Snacks"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;
                        //    }
                        //    if (ddlcategory.Items[i].Text.Contains("Sweets"))
                        //    {
                        //        ddlcategory.Items[i].Enabled = false;
                        //    } 
                        //}
                    }


                    //if (lblUserID.Text == "19")
                    //{
                    //    for (int i = 0; i < ddlcategory.Items.Count; i++)
                    //    {
                    //        if (ddlcategory.Items[i].Text.Contains("Bread"))
                    //        {
                    //            ddlcategory.Items[i].Enabled = true;
                    //        }
                    //        if (ddlcategory.Items[i].Text.Contains("Cookies"))
                    //        {
                    //            ddlcategory.Items[i].Enabled = true;
                    //        }
                    //        if (ddlcategory.Items[i].Text.Contains("Snacks"))
                    //        {
                    //            ddlcategory.Items[i].Enabled = true;
                    //        }
                    //        if (ddlcategory.Items[i].Text.Contains("Sweets"))
                    //        {
                    //            ddlcategory.Items[i].Enabled = true;
                    //        }
                    //    }
                    //}
                }

                ddlcategory.Enabled = true;
                ddlSubCategory.Enabled = true;

                string iStock = Request.QueryString.Get("iStock");
                if (iStock != "" && iStock != null)
                {


                    btnAdd.Text = "Update";
                    ddlcategory.Enabled = false;
                    ddlSubCategory.Enabled = false;
                    DataSet ds = new DataSet();
                    //if (sTableName == "admin")
                    ds = objBs.getstockdetedit(iStock, sTableName);
                    //else
                    //    ds = objBs.getstockdetedit_dealer(iStock, "tblStock_" + sTableName);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Decimal CusUnit = 0, DealUnit = 0, PressUnit = 0;
                        ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                        DataSet dsCategory1 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue), sTableName);
                        if (dsCategory1.Tables[0].Rows.Count > 0)
                        {
                            ddlSubCategory.DataSource = dsCategory1.Tables[0];
                            ddlSubCategory.DataTextField = "printitem";
                            ddlSubCategory.DataValueField = "categoryuserid";
                            ddlSubCategory.DataBind();
                            ddlSubCategory.Items.Insert(0, "Select Description");




                        }
                        //decimal iPurchase = Convert.ToDecimal(ds.Tables[0].Rows[0]["PurchaseRate"].ToString());
                        ddlSubCategory.SelectedValue = ds.Tables[0].Rows[0]["subcategoryID"].ToString();
                        txtQty.Text = ds.Tables[0].Rows[0]["Available_QTY"].ToString();
                        //CusUnit = Convert.ToDecimal(ds.Tables[0].Rows[0]["unitprice"].ToString());
                        //  DealUnit = Convert.ToDecimal(ds.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
                        // PressUnit = Convert.ToDecimal(ds.Tables[0].Rows[0]["PressUnitPrice"].ToString());
                        //txtminimum.Text = ds.Tables[0].Rows[0]["MinQty"].ToString();
                        txtCustUnitPrice.Text = Decimal.Round(CusUnit, 2).ToString("f2");
                        //  txtDealerUnitPrice.Text = Decimal.Round(DealUnit, 2).ToString("f2");
                        // txtPressUnitPrice.Text = Decimal.Round(PressUnit, 2).ToString("f2");
                        // txtPurchasePrice.Text = decimal.Round(iPurchase, 2).ToString("f2");
                    }
                }





            }
        }

        protected void ddldaygrn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddldaygrn.SelectedValue != "Select GRN")
            {
                DataSet ds = objBs.daygrnValid(Convert.ToInt32(ddldaygrn.SelectedValue));
                string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " </b></h4> ";
                gvdaygrn.Caption = caption;
                gvdaygrn.DataSource = ds;
                gvdaygrn.DataBind();
                //////GridView1.DataSource = ds;
                //////GridView1.DataBind();

            }
        }


        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // if (e.CommandName == "View")
            {

                //////gvPurchaseReqDetails.Columns[3].Visible = false;
                //////DataSet ds = objbs.RequestDet(e.CommandArgument.ToString(), sCode);
                //////gvPurchaseReqDetails.DataSource = ds;
                //////gvPurchaseReqDetails.DataBind();
                //////string caption = "<h4><b>Request From" + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Request Entry Time " + gvPurchaseEntry.Rows[0].Cells[5].Text + "</b></h4> ";
                //////gvPurchaseReqDetails.Caption = caption;

            
                string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " </b></h4> ";
                gvdaygrn.Caption = caption;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //string BranchNAme = "";
            //if (sTableName == "CO1")
            //    BranchNAme = "Kk nagar";
            //else if (sTableName == "CO2")
            //    BranchNAme = "Byepass";
            //else if (sTableName == "CO3")
            //    BranchNAme = "BB kulam";
            //else if (sTableName == "CO4")
            //    BranchNAme = "Narayanapuram";
            //else if (sTableName == "CO5")
            //    BranchNAme = "Palayankottal";
            //else if (sTableName == "CO6")
            //    BranchNAme = "Maduravayol";
            //else if (sTableName == "CO7")
            //    BranchNAme = "purasavakkam";
            //else if (sTableName == "CO8")
            //    BranchNAme = "Chennai Pothys";

            //else if (sTableName == "CO9")
            //    BranchNAme = "Thirunelveli";

            //else if (sTableName == "CO10")
            //    BranchNAme = "Periyar";
            //else if (sTableName == "CO11")
            //    BranchNAme = "palayam";

            DataSet ds = objBs.getgrndatetime(txttodate.Text);
           // string caption = "<h4><b> " + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " Branch : "+ BranchNAme + " </b></h4> ";
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " </b></h4> ";
            GridView1.Caption = caption;
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            //string BranchNAme = "";
            //if (sTableName == "CO1")
            //    BranchNAme = "Kk nagar";
            //else if (sTableName == "CO2")
            //    BranchNAme = "Byepass";
            //else if (sTableName == "CO3")
            //    BranchNAme = "BB kulam";
            //else if (sTableName == "CO4")
            //    BranchNAme = "Narayanapuram";
            //else if (sTableName == "CO5")
            //    BranchNAme = "Palayankottal";
            //else if (sTableName == "CO6")
            //    BranchNAme = "Maduravayol";
            //else if (sTableName == "CO7")
            //    BranchNAme = "purasavakkam";
            //else if (sTableName == "CO8")
            //    BranchNAme = "Chennai Pothys";

            //else if (sTableName == "CO9")
            //    BranchNAme = "Thirunelveli";

            //else if (sTableName == "CO10")
            //    BranchNAme = "Periyar";
            //else if (sTableName == "CO11")
            //    BranchNAme = "palayam";

          //  string caption = "<h4><b> " + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " Branch : " + BranchNAme + " </b></h4> ";
            if (ddldaygrn.SelectedValue != "Select GRN")
            {

                string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " </b></h4> ";
                gvdaygrn.Caption = caption;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
            else
            {
                string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy HH:mm tt") + " </b></h4> ";
                GridView1.Caption = caption;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGridNew();", true);
            }
        }
        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {
                DataSet ds = objBs.GetStockDetails1(Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToInt32(lblUserID.Text), sTableName);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Decimal IUnit = 0, DealUnit = 0, PressUnit = 0;
                    // lblsuberror.Text = "Sorry Selected Item was already having a Quantity";
                    // txtQty.Text = ds.Tables[0].Rows[0]["Available_Qty"].ToString();
                    // IUnit = Convert.ToDecimal(ds.Tables[0].Rows[0]["unitprice"].ToString());
                    decimal iPurchase = Convert.ToDecimal(ds.Tables[0].Rows[0]["PurchaseRate"].ToString());
                    DealUnit = Convert.ToDecimal(ds.Tables[0].Rows[0]["DealerUnitPrice"].ToString());
                    PressUnit = Convert.ToDecimal(ds.Tables[0].Rows[0]["PressUnitPrice"].ToString());
                    txtCustUnitPrice.Text = Decimal.Round(IUnit, 2).ToString("f2");
                    txtDealerUnitPrice.Text = Decimal.Round(DealUnit, 2).ToString("f2");
                    txtPressUnitPrice.Text = Decimal.Round(PressUnit, 2).ToString("f2");
                    txtPurchasePrice.Text = decimal.Round(iPurchase, 2).ToString("f2");
                    //txtQty.Enabled = false;
                    //txtCustUnitPrice.Enabled = false;
                    //txtDealerUnitPrice.Enabled = false;
                    //txtPressUnitPrice.Enabled = false;
                    //btnAdd.Enabled = false;
                }

                else
                {
                    DataSet dPurchaseRate = objBs.checkPurchaseRate(Convert.ToInt32(ddlSubCategory.SelectedValue), sTableName);
                    if (dPurchaseRate.Tables[0].Rows.Count <= 0)
                    {
                        DataSet dCheck = objBs.checkCheckBoxCondition(Convert.ToInt32(ddlSubCategory.SelectedValue));
                        if (dCheck.Tables[0].Rows.Count > 0)
                        {
                            CheckPurhcase();
                        }
                        else
                        {
                            lblsuberror.Text = "Purchase Rate not defined";
                            txtQty.Enabled = false;
                            txtCustUnitPrice.Enabled = false;
                            txtDealerUnitPrice.Enabled = false;
                            txtPressUnitPrice.Enabled = false;
                            btnAdd.Enabled = false;
                        }





                    }
                }
            }

            txtQty.Focus();
        }

        private void CheckPurhcase()
        {
            txtQty.Enabled = true;
            txtCustUnitPrice.Enabled = true;
            txtDealerUnitPrice.Enabled = true;
            txtPressUnitPrice.Enabled = true;
            btnAdd.Enabled = true;
            lblsuberror.Text = "";
        }
     
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            DataSet checkdayclose = objBs.checkinser_Previousday(sTableName);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any GRN.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (txtname.Text.Trim() != "")
            {
                //if (FirstEntry == "Yes")
                //{
                //    int isa = objBs.subgrn(Convert.ToInt32(txtgrnno.Text), DateTime.Now.ToShortDateString(), Convert.ToInt32(lblUserID.Text), txtname.Text);
                //}
                //string iStock = Request.QueryString.Get("iStock");
                //DataSet ds = objBs.getstockdetedit(iStock);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    int iQty = 0, iAvailQty = 0;
                //    iQty = Convert.ToInt32(txtQty.Text) + Convert.ToInt32(ds.Tables[0].Rows[0]["Available_Qty"].ToString());

                //    iAvailQty = Convert.ToInt32(txtQty.Text) - Convert.ToInt32(ds.Tables[0].Rows[0]["Available_Qty"].ToString());
                //    txtQty.Text = Convert.ToString(iAvailQty);
                //    txtQty.Text = ds.Tables[0].Rows[0]["Available_Qty"].ToString();
                //    iAdd = txtQty.Text + ds.Tables[0].Rows[0]["Available_Qty"].ToString();
                //    txtQty.Text = iAdd;
                Decimal dQty = 0, dAvbQty = 0;
                Decimal ichecked = 0;
                if (Convert.ToDecimal(txtQty.Text) <= Convert.ToDecimal(txtminimum.Text))
                {
                    lblerror.Text = "Your Quantity is become low";
                }
                else
                {
                    try
                    {
                        int iSuccess = 0;

                        if (btnAdd.Text == "Save")
                        {
                            if (sTableName == "admin")
                            {
                                string userid = "";
                                if (ddlstore.SelectedValue == "co1")
                                    userid = "5";
                                if (ddlstore.SelectedValue == "co2")
                                    userid = "6";
                                if (ddlstore.SelectedValue == "co3")
                                    userid = "7";
                                if (ddlstore.SelectedValue == "co4")
                                    userid = "11";
                                if (ddlstore.SelectedValue == "co5")
                                    userid = "14";
                                if (ddlstore.SelectedValue == "co6")
                                    userid = "17";
                                if (ddlstore.SelectedValue == "co7")
                                    userid = "19";

                                DataSet dsStock = objBs.GetStockAvailable(Convert.ToInt32(ddlSubCategory.SelectedValue), ddlstore.SelectedValue);
                                if (dsStock.Tables[0].Rows.Count > 0)
                                {
                                    int stockid = Convert.ToInt32(dsStock.Tables[0].Rows[0]["stockid"].ToString());
                                    dQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Quantity"].ToString());
                                    dAvbQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                                    dQty = dQty + Convert.ToDecimal(txtQty.Text);
                                    dAvbQty = dAvbQty + Convert.ToDecimal(txtQty.Text);
                                    iSuccess = objBs.updatePrintstockdet(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToDouble(dAvbQty), ddlstore.SelectedValue, Convert.ToDecimal(txtQty.Text), DateTime.Now.ToString("MM/dd/yyyy"), Convert.ToInt32(userid), stockid, Convert.ToInt32(txtgrnno.Text), txtname.Text);

                                   // Response.Redirect("../Accountsbootstrap/Stock.aspx");
                                }
                                else
                                {

                                    iSuccess = objBs.StockOnly(ddlstore.SelectedValue, Convert.ToInt32(userid), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtQty.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy")), 1, Convert.ToInt32(txtgrnno.Text), txtname.Text);
                                   // Response.Redirect("../Accountsbootstrap/Stock.aspx");

                                   
                                }

                                txtQty.Text = "";
                                lblerror.Text = "saved";
                            }
                            else
                            {
                                DataSet dsStock = objBs.GetStockAvailable(Convert.ToInt32(ddlSubCategory.SelectedValue), sTableName);
                                if (dsStock.Tables[0].Rows.Count > 0)
                                {
                                    int stockid = Convert.ToInt32(dsStock.Tables[0].Rows[0]["stockid"].ToString());
                                    dQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Quantity"].ToString());
                                    dAvbQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                                    dQty = dQty + Convert.ToDecimal(txtQty.Text);
                                    dAvbQty = dAvbQty + Convert.ToDecimal(txtQty.Text);
                                    iSuccess = objBs.updatePrintstockdet(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToDouble(dAvbQty), sTableName, Convert.ToDecimal(txtQty.Text), DateTime.Now.ToString("MM/dd/yyyy"), Convert.ToInt32(lblUserID.Text), stockid, Convert.ToInt32(txtgrnno.Text), txtname.Text);
                                  //  Response.Redirect("../Accountsbootstrap/Stock.aspx");
                                }
                                else
                                {

                                    iSuccess = objBs.StockOnly(sTableName, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtQty.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy")), 1, Convert.ToInt32(txtgrnno.Text), txtname.Text);
                                   // Response.Redirect("../Accountsbootstrap/Stock.aspx");
                                }
                            }
                            txtQty.Text = "";
                            lblerror.Text = "saved";


                            DataSet daygrn = objBs.daygrnVal();
                            ddldaygrn.DataSource = daygrn.Tables[0];
                            ddldaygrn.DataTextField = "DayGRN";
                            ddldaygrn.DataValueField = "id";
                            ddldaygrn.DataBind();
                            ddldaygrn.Items.Insert(0, "Select GRN");
                        }
                        else
                        {

                            //DataSet dsStock = objBs.GetStockAvailable(Convert.ToInt32(ddlSubCategory.SelectedValue), sTableName);
                            //if (dsStock.Tables[0].Rows.Count > 0)
                            //{
                            //    dQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Quantity"].ToString());
                            //    dAvbQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());
                            //    ichecked = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["isChecked"].ToString());
                            //    dQty = dQty + Convert.ToDecimal(txtQty.Text);
                            //    dAvbQty = dAvbQty + Convert.ToDecimal(txtQty.Text);
                            //}
                            //if (ichecked == 1)
                            //{
                            //    // iSuccess = objBs.updatePrintstockdet(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToDouble(txtCustUnitPrice.Text),Convert.ToDouble(txtDealerUnitPrice.Text),Convert.ToDouble(txtPressUnitPrice.Text),Convert.ToInt32(txtminimum.Text),Convert.ToDouble(dQty),Convert.ToDouble(dAvbQty),sTableName);
                            //}
                            //else
                            //{


                            // //   iSuccess = objBs.updatestockdet(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSubCategory.SelectedValue), Convert.ToDouble(txtCustUnitPrice.Text), Convert.ToDouble(txtDealerUnitPrice.Text), Convert.ToDouble(txtPressUnitPrice.Text), Convert.ToInt32(txtminimum.Text), sTableName);
                            //}
                            //  Response.Redirect("../Accountsbootstrap/Stockgrid.aspx");

                            DataSet daygrn = objBs.daygrnVal();
                            ddldaygrn.DataSource = daygrn.Tables[0];
                            ddldaygrn.DataTextField = "DayGRN";
                            ddldaygrn.DataValueField = "id";
                            ddldaygrn.DataBind();
                            ddldaygrn.Items.Insert(0, "Select GRN");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    }

                }

                ddlcategory.Focus();
                //}
            }
            else
            {
                lblerror.Text = "Enter Your Name";
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue), sTableName);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                ddlSubCategory.DataSource = dsCategory.Tables[0];
                ddlSubCategory.DataTextField = "printitem";
                ddlSubCategory.DataValueField = "categoryuserid";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, "Select Description");

            }
            lblerror.Text = "";

            ddlSubCategory.Focus();
        }
        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/Stockgrid.aspx");
        }

    }
}
