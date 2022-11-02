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


namespace Billing.Accountsbootstrap
{
    public partial class cashsales : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        decimal dTax = 0, dTax1 = 0, dTax2 = 0, dTax3 = 0, dTax4 = 0, dTax5 = 0;
        decimal dTaxAmt = 0, dTaxAmt1 = 0, dTaxAmt2 = 0, dTaxAmt3 = 0, dTaxAmt4 = 0, dTaxAmt5 = 0;
        string sTableName = "";
        string iDealer = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();
            if (!IsPostBack)
            {
                DataSet ds = objBs.SalesBillno("tblSales_" + sTableName);
                if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                    txtbillno.Text = "1";
                else
                    txtbillno.Text = ds.Tables[0].Rows[0]["billno"].ToString();
                txtdate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                btnlink1.Visible = false;
                btnlink2.Visible = false;
                btnlink3.Visible = false;
                btnlink4.Visible = false;
                btnlink5.Visible = false;
                btnlink6.Visible = false;
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

                DataSet dCnt = objBs.GetContact();
                bblbillto.DataSource = dCnt.Tables[0];
                bblbillto.DataTextField = "ContactType";
                bblbillto.DataValueField = "ContactID";
                bblbillto.DataBind();
                bblbillto.Items.Insert(0, "select Contact");

               bblbillto.SelectedValue = "1";
                    
                Decimal Itot = 0, Itax = 0, Idisc = 0, Igrandtot = 0,iAdvance=0;
                Decimal Irate = 0, Iamt = 0;
                Decimal Irate1 = 0, Iamt1 = 0;
                Decimal Irate2 = 0, Iamt2 = 0;
                Decimal Irate3 = 0, Iamt3 = 0;
                Decimal Irate4 = 0, Iamt4 = 0;
                Decimal Irate5 = 0, Iamt5 = 0;

                string iSalesID = Request.QueryString.Get("iSalesID");
                 iDealer = Request.QueryString.Get("iDealer");
                if (iSalesID != null)
                {
                   
                    DataSet dContact = objBs.checkContack(Convert.ToInt32(iSalesID), Convert.ToInt32(lblUserID.Text), "tblsales_" + sTableName);

                    //int icusttype = Convert.ToInt32(dContact.Tables[0].Rows[0]["ContactID"].ToString());

                    ////if (icusttype == 2)
                    //btnadd.Visible = false;

                    DataSet ds1 = objBs.CustomerSalesGirdget(iSalesID, "tblSales_" + sTableName);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        bblbillto.SelectedValue = ds1.Tables[0].Rows[0]["ContactTypeID"].ToString();
                        DataSet dsCustomer = objBs.GetCustName(Convert.ToInt32(bblbillto.SelectedValue));
                        if (dsCustomer.Tables[0].Rows.Count > 0)
                        {
                            //ddlcustomerID.DataSource = dsCustomer.Tables[0];
                            //ddlcustomerID.DataTextField = "CustomerName";
                            //ddlcustomerID.DataValueField = "CustomerID";
                            //ddlcustomerID.DataBind();
                            //ddlcustomerID.Items.Insert(0, "Select Customer");

                            // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                        }
                        btnadd.Text = "Save";
                        //txtcuscode.Text = ds1.Tables[0].Rows[0]["CustomerID"].ToString();
                        txtbillno.Text = ds1.Tables[0].Rows[0]["BillNo"].ToString();
                        txtdate1.Text = ds1.Tables[0].Rows[0]["BillDate"].ToString();
                        //ddlcustomerID.SelectedItem.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                       // ddlcustomerID.SelectedValue = ds1.Tables[0].Rows[0]["CustomerID"].ToString();
                        //txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        //txtarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                        txtpincode.Text = ds1.Tables[0].Rows[0]["pincode"].ToString();
                        txtmobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                        Itot = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Total"].ToString());
                        txttotal.Text = Decimal.Round(Itot, 2).ToString("f2");

                        Itax = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Tax"].ToString());
                        txttax.Text = Decimal.Round(Itax, 2).ToString("f2");

                        Idisc = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Discount"].ToString());
                        txtdiscount.Text = Decimal.Round(Idisc, 2).ToString("f2");

                        Igrandtot = Convert.ToDecimal(ds1.Tables[0].Rows[0]["NetAmount"].ToString());
                        txtgrandtotal.Text = Decimal.Round(Igrandtot, 2).ToString("f2");

                        Igrandtot = Convert.ToDecimal(ds1.Tables[0].Rows[0]["NetAmount"].ToString());
                        txtgrandtotal.Text = Decimal.Round(Igrandtot, 2).ToString("f2");

                        iAdvance = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Advance"].ToString());
                        txtadvance.Text = Decimal.Round(iAdvance, 2).ToString("f2");
                        //ddlcategory.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();

                    }

                    //Retreive Sales Trans Details
                    DataSet dsSalesTrans = objBs.GetUpdateSalesTrans(iSalesID, "tblTransSales_" + sTableName);
                    if (dsSalesTrans.Tables[0].Rows.Count > 0)
                    {

                        int iCnt = dsSalesTrans.Tables[0].Rows.Count;
                        if (iCnt <= 1)
                        {

                            DataSet dsCategorydef = objBs.selectcategoryalldecription();
                            if (dsCategorydef.Tables[0].Rows.Count > 0)
                            {

                                ddldef.DataSource = dsCategorydef.Tables[0];
                                ddldef.DataTextField = "Definition";
                                ddldef.DataValueField = "categoryuserid";
                                ddldef.DataBind();
                                ddldef.Items.Insert(0, "Select Description");

                            }
                            ddlcategory.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddldef.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["SubCategoryID"].ToString();
                            txtqty.Text = dsSalesTrans.Tables[0].Rows[0]["Quantity"].ToString();

                            Irate = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");

                            Iamt = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["Amount"].ToString());
                            txtamount.Text = Decimal.Round(Iamt, 2).ToString("f2");

                        }
                        else if (iCnt <= 2)
                        {

                            DataSet dsCategorydef = objBs.selectcategoryalldecription();
                            if (dsCategorydef.Tables[0].Rows.Count > 0)
                            {
                                ddldef.DataSource = dsCategorydef.Tables[0];
                                ddldef.DataTextField = "Definition";
                                ddldef.DataValueField = "categoryuserid";
                                ddldef.DataBind();
                                ddldef.Items.Insert(0, "Select Description");

                                ddldef1.DataSource = dsCategorydef.Tables[0];
                                ddldef1.DataTextField = "Definition";
                                ddldef1.DataValueField = "categoryuserid";
                                ddldef1.DataBind();
                                ddldef1.Items.Insert(0, "Select Description");

                            }
                            ddlcategory.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddldef.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["SubCategoryID"].ToString();
                            txtqty.Text = dsSalesTrans.Tables[0].Rows[0]["Quantity"].ToString();
                            Irate = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                            Iamt = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["Amount"].ToString());
                            txtamount.Text = Decimal.Round(Iamt, 2).ToString("f2");

                            ddlcategory1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["CategoryID"].ToString();
                            ddldef1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["SubCategoryID"].ToString();
                            txtqty1.Text = dsSalesTrans.Tables[0].Rows[1]["Quantity"].ToString();
                            Irate1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["UnitPrice"].ToString());
                            txtrate1.Text = Decimal.Round(Irate1, 2).ToString("f2");
                            Iamt1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["Amount"].ToString());
                            txtamount1.Text = Decimal.Round(Iamt1, 2).ToString("f2");

                            //txtrate1.Text = dsSalesTrans.Tables[0].Rows[1]["UnitPrice"].ToString();
                            //txtamount1.Text = dsSalesTrans.Tables[0].Rows[1]["Amount"].ToString();
                        }
                        else if (iCnt <= 3)
                        {

                            DataSet dsCategorydef = objBs.selectcategoryalldecription();
                            if (dsCategorydef.Tables[0].Rows.Count > 0)
                            {
                                ddldef.DataSource = dsCategorydef.Tables[0];
                                ddldef.DataTextField = "Definition";
                                ddldef.DataValueField = "categoryuserid";
                                ddldef.DataBind();
                                ddldef.Items.Insert(0, "Select Description");

                                ddldef1.DataSource = dsCategorydef.Tables[0];
                                ddldef1.DataTextField = "Definition";
                                ddldef1.DataValueField = "categoryuserid";
                                ddldef1.DataBind();
                                ddldef1.Items.Insert(0, "Select Description");

                                ddldef2.DataSource = dsCategorydef.Tables[0];
                                ddldef2.DataTextField = "Definition";
                                ddldef2.DataValueField = "categoryuserid";
                                ddldef2.DataBind();
                                ddldef2.Items.Insert(0, "Select Description");

                            }
                            ddlcategory.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddldef.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["SubCategoryID"].ToString();
                            txtqty.Text = dsSalesTrans.Tables[0].Rows[0]["Quantity"].ToString();
                            Irate = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                            Iamt = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["Amount"].ToString());
                            txtamount.Text = Decimal.Round(Iamt, 2).ToString("f2");

                            ddlcategory1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["CategoryID"].ToString();
                            ddldef1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["SubCategoryID"].ToString();
                            txtqty1.Text = dsSalesTrans.Tables[0].Rows[1]["Quantity"].ToString();
                            Irate1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["UnitPrice"].ToString());
                            txtrate1.Text = Decimal.Round(Irate1, 2).ToString("f2");
                            Iamt1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["Amount"].ToString());
                            txtamount1.Text = Decimal.Round(Iamt1, 2).ToString("f2");

                            ddlcategory2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["CategoryID"].ToString();
                            ddldef2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["SubCategoryID"].ToString();
                            txtqty2.Text = dsSalesTrans.Tables[0].Rows[2]["Quantity"].ToString();

                            Irate2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["UnitPrice"].ToString());
                            txtrate2.Text = Decimal.Round(Irate2, 2).ToString("f2");

                            Iamt2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["Amount"].ToString());
                            txtamount2.Text = Decimal.Round(Iamt2, 2).ToString("f2");
                        }

                        else if (iCnt <= 4)
                        {
                            DataSet dsCategorydef = objBs.selectcategoryalldecription();
                            if (dsCategorydef.Tables[0].Rows.Count > 0)
                            {
                                ddldef.DataSource = dsCategorydef.Tables[0];
                                ddldef.DataTextField = "Definition";
                                ddldef.DataValueField = "categoryuserid";
                                ddldef.DataBind();
                                ddldef.Items.Insert(0, "Select Description");

                                ddldef1.DataSource = dsCategorydef.Tables[0];
                                ddldef1.DataTextField = "Definition";
                                ddldef1.DataValueField = "categoryuserid";
                                ddldef1.DataBind();
                                ddldef1.Items.Insert(0, "Select Description");

                                ddldef2.DataSource = dsCategorydef.Tables[0];
                                ddldef2.DataTextField = "Definition";
                                ddldef2.DataValueField = "categoryuserid";
                                ddldef2.DataBind();
                                ddldef2.Items.Insert(0, "Select Description");

                                ddldef3.DataSource = dsCategorydef.Tables[0];
                                ddldef3.DataTextField = "Definition";
                                ddldef3.DataValueField = "categoryuserid";
                                ddldef3.DataBind();
                                ddldef3.Items.Insert(0, "Select Description");

                            }
                            ddlcategory.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddldef.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["SubCategoryID"].ToString();
                            txtqty.Text = dsSalesTrans.Tables[0].Rows[0]["Quantity"].ToString();
                            Irate = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                            Iamt = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["Amount"].ToString());
                            txtamount.Text = Decimal.Round(Iamt, 2).ToString("f2");

                            ddlcategory1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["CategoryID"].ToString();
                            ddldef1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["SubCategoryID"].ToString();
                            txtqty1.Text = dsSalesTrans.Tables[0].Rows[1]["Quantity"].ToString();
                            Irate1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["UnitPrice"].ToString());
                            txtrate1.Text = Decimal.Round(Irate1, 2).ToString("f2");
                            Iamt1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["Amount"].ToString());
                            txtamount1.Text = Decimal.Round(Iamt1, 2).ToString("f2");

                            ddlcategory2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["CategoryID"].ToString();
                            ddldef2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["SubCategoryID"].ToString();
                            txtqty2.Text = dsSalesTrans.Tables[0].Rows[2]["Quantity"].ToString();
                            Irate2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["UnitPrice"].ToString());
                            txtrate2.Text = Decimal.Round(Irate2, 2).ToString("f2");
                            Iamt2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["Amount"].ToString());
                            txtamount2.Text = Decimal.Round(Iamt2, 2).ToString("f2");

                            ddlcategory3.SelectedValue = dsSalesTrans.Tables[0].Rows[3]["CategoryID"].ToString();
                            ddldef3.SelectedValue = dsSalesTrans.Tables[0].Rows[3]["SubCategoryID"].ToString();
                            txtqty3.Text = dsSalesTrans.Tables[0].Rows[3]["Quantity"].ToString();

                            Irate3 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[3]["UnitPrice"].ToString());
                            txtrate3.Text = Decimal.Round(Irate3, 2).ToString("f2");
                            Iamt3 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[3]["Amount"].ToString());
                            txtamount3.Text = Decimal.Round(Iamt3, 2).ToString("f2");
                        }

                        else if (iCnt <= 5)
                        {
                            DataSet dsCategorydef = objBs.selectcategoryalldecription();
                            if (dsCategorydef.Tables[0].Rows.Count > 0)
                            {
                                ddldef.DataSource = dsCategorydef.Tables[0];
                                ddldef.DataTextField = "Definition";
                                ddldef.DataValueField = "categoryuserid";
                                ddldef.DataBind();
                                ddldef.Items.Insert(0, "Select Description");

                                ddldef1.DataSource = dsCategorydef.Tables[0];
                                ddldef1.DataTextField = "Definition";
                                ddldef1.DataValueField = "categoryuserid";
                                ddldef1.DataBind();
                                ddldef1.Items.Insert(0, "Select Description");

                                ddldef2.DataSource = dsCategorydef.Tables[0];
                                ddldef2.DataTextField = "Definition";
                                ddldef2.DataValueField = "categoryuserid";
                                ddldef2.DataBind();
                                ddldef2.Items.Insert(0, "Select Description");

                                ddldef3.DataSource = dsCategorydef.Tables[0];
                                ddldef3.DataTextField = "Definition";
                                ddldef3.DataValueField = "categoryuserid";
                                ddldef3.DataBind();
                                ddldef3.Items.Insert(0, "Select Description");

                                ddldef4.DataSource = dsCategorydef.Tables[0];
                                ddldef4.DataTextField = "Definition";
                                ddldef4.DataValueField = "categoryuserid";
                                ddldef4.DataBind();
                                ddldef4.Items.Insert(0, "Select Description");

                            }
                            ddlcategory.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddldef.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["SubCategoryID"].ToString();
                            txtqty.Text = dsSalesTrans.Tables[0].Rows[0]["Quantity"].ToString();
                            Irate = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                            Iamt = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["Amount"].ToString());
                            txtamount.Text = Decimal.Round(Iamt, 2).ToString("f2");

                            ddlcategory1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["CategoryID"].ToString();
                            ddldef1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["SubCategoryID"].ToString();
                            txtqty1.Text = dsSalesTrans.Tables[0].Rows[1]["Quantity"].ToString();
                            Irate1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["UnitPrice"].ToString());
                            txtrate1.Text = Decimal.Round(Irate1, 2).ToString("f2");
                            Iamt1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["Amount"].ToString());
                            txtamount1.Text = Decimal.Round(Iamt1, 2).ToString("f2");

                            ddlcategory2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["CategoryID"].ToString();
                            ddldef2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["SubCategoryID"].ToString();
                            txtqty2.Text = dsSalesTrans.Tables[0].Rows[2]["Quantity"].ToString();
                            Irate2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["UnitPrice"].ToString());
                            txtrate2.Text = Decimal.Round(Irate2, 2).ToString("f2");
                            Iamt2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["Amount"].ToString());
                            txtamount2.Text = Decimal.Round(Iamt2, 2).ToString("f2");

                            ddlcategory3.SelectedValue = dsSalesTrans.Tables[0].Rows[3]["CategoryID"].ToString();
                            ddldef3.SelectedValue = dsSalesTrans.Tables[0].Rows[3]["SubCategoryID"].ToString();
                            txtqty3.Text = dsSalesTrans.Tables[0].Rows[3]["Quantity"].ToString();
                            Irate3 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[3]["UnitPrice"].ToString());
                            txtrate3.Text = Decimal.Round(Irate3, 2).ToString("f2");
                            Iamt3 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[3]["Amount"].ToString());
                            txtamount3.Text = Decimal.Round(Iamt3, 2).ToString("f2");

                            ddlcategory4.SelectedValue = dsSalesTrans.Tables[0].Rows[4]["CategoryID"].ToString();
                            ddldef4.SelectedValue = dsSalesTrans.Tables[0].Rows[4]["SubCategoryID"].ToString();
                            txtqty4.Text = dsSalesTrans.Tables[0].Rows[4]["Quantity"].ToString();
                            Irate4 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[4]["UnitPrice"].ToString());
                            txtrate4.Text = Decimal.Round(Irate4, 2).ToString("f2");
                            Iamt4 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[4]["Amount"].ToString());
                            txtamount4.Text = Decimal.Round(Iamt4, 2).ToString("f2");
                        }

                        else if (iCnt <= 6)
                        {
                            DataSet dsCategorydef = objBs.selectcategoryalldecription();
                            if (dsCategorydef.Tables[0].Rows.Count > 0)
                            {
                                ddldef.DataSource = dsCategorydef.Tables[0];
                                ddldef.DataTextField = "Definition";
                                ddldef.DataValueField = "categoryuserid";
                                ddldef.DataBind();
                                ddldef.Items.Insert(0, "Select Description");

                                ddldef1.DataSource = dsCategorydef.Tables[0];
                                ddldef1.DataTextField = "Definition";
                                ddldef1.DataValueField = "categoryuserid";
                                ddldef1.DataBind();
                                ddldef1.Items.Insert(0, "Select Description");

                                ddldef2.DataSource = dsCategorydef.Tables[0];
                                ddldef2.DataTextField = "Definition";
                                ddldef2.DataValueField = "categoryuserid";
                                ddldef2.DataBind();
                                ddldef2.Items.Insert(0, "Select Description");

                                ddldef3.DataSource = dsCategorydef.Tables[0];
                                ddldef3.DataTextField = "Definition";
                                ddldef3.DataValueField = "categoryuserid";
                                ddldef3.DataBind();
                                ddldef3.Items.Insert(0, "Select Description");

                                ddldef4.DataSource = dsCategorydef.Tables[0];
                                ddldef4.DataTextField = "Definition";
                                ddldef4.DataValueField = "categoryuserid";
                                ddldef4.DataBind();
                                ddldef4.Items.Insert(0, "Select Description");

                                ddldef5.DataSource = dsCategorydef.Tables[0];
                                ddldef5.DataTextField = "Definition";
                                ddldef5.DataValueField = "categoryuserid";
                                ddldef5.DataBind();
                                ddldef5.Items.Insert(0, "Select Description");

                            }
                            ddlcategory.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["CategoryID"].ToString();
                            ddldef.SelectedValue = dsSalesTrans.Tables[0].Rows[0]["SubCategoryID"].ToString();
                            txtqty.Text = dsSalesTrans.Tables[0].Rows[0]["Quantity"].ToString();
                            Irate = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                            Iamt = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[0]["Amount"].ToString());
                            txtamount.Text = Decimal.Round(Iamt, 2).ToString("f2");



                            ddlcategory1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["CategoryID"].ToString();
                            ddldef1.SelectedValue = dsSalesTrans.Tables[0].Rows[1]["SubCategoryID"].ToString();
                            txtqty1.Text = dsSalesTrans.Tables[0].Rows[1]["Quantity"].ToString();
                            Irate1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["UnitPrice"].ToString());
                            txtrate1.Text = Decimal.Round(Irate1, 2).ToString("f2");
                            Iamt1 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[1]["Amount"].ToString());
                            txtamount1.Text = Decimal.Round(Iamt1, 2).ToString("f2");

                            ddlcategory2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["CategoryID"].ToString();
                            ddldef2.SelectedValue = dsSalesTrans.Tables[0].Rows[2]["SubCategoryID"].ToString();
                            txtqty2.Text = dsSalesTrans.Tables[0].Rows[2]["Quantity"].ToString();
                            Irate2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["UnitPrice"].ToString());
                            txtrate2.Text = Decimal.Round(Irate2, 2).ToString("f2");
                            Iamt2 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[2]["Amount"].ToString());
                            txtamount2.Text = Decimal.Round(Iamt2, 2).ToString("f2");

                            ddlcategory3.SelectedValue = dsSalesTrans.Tables[0].Rows[3]["CategoryID"].ToString();
                            ddldef3.SelectedValue = dsSalesTrans.Tables[0].Rows[3]["SubCategoryID"].ToString();
                            txtqty3.Text = dsSalesTrans.Tables[0].Rows[3]["Quantity"].ToString();
                            Irate3 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[3]["UnitPrice"].ToString());
                            txtrate3.Text = Decimal.Round(Irate3, 2).ToString("f2");
                            Iamt3 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[3]["Amount"].ToString());
                            txtamount3.Text = Decimal.Round(Iamt3, 2).ToString("f2");

                            ddlcategory4.SelectedValue = dsSalesTrans.Tables[0].Rows[4]["CategoryID"].ToString();
                            ddldef4.SelectedValue = dsSalesTrans.Tables[0].Rows[4]["SubCategoryID"].ToString();
                            txtqty4.Text = dsSalesTrans.Tables[0].Rows[4]["Quantity"].ToString();
                            Irate4 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[4]["UnitPrice"].ToString());
                            txtrate4.Text = Decimal.Round(Irate4, 2).ToString("f2");
                            Iamt4 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[4]["Amount"].ToString());
                            txtamount4.Text = Decimal.Round(Iamt4, 2).ToString("f2");

                            ddlcategory5.SelectedValue = dsSalesTrans.Tables[0].Rows[5]["CategoryID"].ToString();
                            ddldef5.SelectedValue = dsSalesTrans.Tables[0].Rows[5]["SubCategoryID"].ToString();
                            txtqty5.Text = dsSalesTrans.Tables[0].Rows[5]["Quantity"].ToString();
                            Irate5 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[5]["UnitPrice"].ToString());
                            txtrate5.Text = Decimal.Round(Irate5, 2).ToString("f2");
                            Iamt5 = Convert.ToDecimal(dsSalesTrans.Tables[0].Rows[5]["Amount"].ToString());
                            txtamount5.Text = Decimal.Round(Iamt5, 2).ToString("f2");
                        }
                    }


                }
                else if (iDealer != null)
                {
                    advance.Visible = false;
                    bblbillto.SelectedValue = "2";
                    txtamount.Enabled = true;
                    DataSet dbill = objBs.SalesBillno("tblSales_" + sTableName);
                    if (dbill.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtbillno.Text = "1";
                    else
                        txtbillno.Text = dbill.Tables[0].Rows[0]["billno"].ToString();

                    //  txtdate1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue));
                    //if (dsCategory.Tables[0].Rows.Count > 0)
                    //{
                    //    ddldef.Enabled = true;
                    //    ddldef.DataSource = dsCategory.Tables[0];
                    //    ddldef.DataTextField = "Definition";
                    //    ddldef.DataValueField = "categoryuserid";
                    //    ddldef.DataBind();
                    //    ddldef.Items.Insert(0, "Select Description");

                    //}
                    btnadd.Text = "Save";
                    DataSet dDealer = objBs.stockTransfer(Convert.ToInt32(iDealer));
                    if (dDealer.Tables[0].Rows.Count > 0)
                    {
                        int iCustid=Convert.ToInt32( dDealer.Tables[0].Rows[0]["DealerID"].ToString());
                        DataSet dsCustomer = objBs.GetCustNamenA(Convert.ToInt32(iCustid));
                        if (dsCustomer.Tables[0].Rows.Count > 0)
                        {
                            //ddlcustomerID.DataSource = dsCustomer.Tables[0];
                            //ddlcustomerID.DataTextField = "CustomerName";
                            //ddlcustomerID.DataValueField = "CustomerID";
                            //ddlcustomerID.DataBind();
                            //ddlcustomerID.Items.Insert(0, "Select Customer");



                            // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                        }

                        //ddlcustomerID.SelectedValue = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();
                        //txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtaddress.Text = dsCustomer.Tables[0].Rows[0]["Address"].ToString();
                       // txtarea.Text = dsCustomer.Tables[0].Rows[0]["Area"].ToString();
                        txtcity.Text = dsCustomer.Tables[0].Rows[0]["City"].ToString();
                        txtpincode.Text = dsCustomer.Tables[0].Rows[0]["pincode"].ToString();
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

                            Irate = Convert.ToDecimal(dDealer.Tables[0].Rows[0]["UnitPrice"].ToString());
                            txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
                            Decimal ical = Convert.ToDecimal(txtqty.Text) * Irate;
                            txtamount.Text = Decimal.Round(ical, 2).ToString("f2");
                            Decimal dSub = Convert.ToDecimal(txtamount.Text);
                            txttotal.Text = Decimal.Round(dSub, 2).ToString("f2");
                            btnlink1.Visible = true;
                            btnlink1.HRef = "~/images/" + ddldef.SelectedItem + ".jpg";
                            int iCount = dDealer.Tables[0].Rows.Count;
                            var DDLDEF = new[] { ddldef1, ddldef2, ddldef3, ddldef4, ddldef5 };
                            var DDLCAT = new[] { ddlcategory1, ddlcategory2, ddlcategory3, ddlcategory4, ddlcategory5 };
                            var QTY = new[] {txtqty1,txtqty2,txtqty3,txtqty4,txtqty5 };
                            var RATE = new[] { txtrate1, txtrate2, txtrate3, txtrate4, txtrate5 };
                            var AMt = new[] { txtamount1, txtamount2, txtamount3, txtamount4, txtamount5 };
                            var link = new[] { btnlink2, btnlink3, btnlink4, btnlink5, btnlink6 };

                            for (int i = 0; i < iCount - 1; i++)
                            {
                                DDLDEF[i].DataSource = dsCategorydef.Tables[0];
                                DDLDEF[i].DataTextField = "Definition";
                                DDLDEF[i].DataValueField = "categoryuserid";
                                DDLDEF[i].DataBind();
                                DDLDEF[i].Items.Insert(0, "Select Description");

                                DDLCAT[i].SelectedValue = dDealer.Tables[0].Rows[i+1]["CategoryID"].ToString();
                                DDLDEF[i].SelectedValue = dDealer.Tables[0].Rows[i+1]["SubCategoryID"].ToString();
                                QTY[i].Text = dDealer.Tables[0].Rows[i+1]["Quantity"].ToString();

                                Irate = Convert.ToDecimal(dDealer.Tables[0].Rows[i+1]["UnitPrice"].ToString());
                                RATE[i].Text = Decimal.Round(Irate, 2).ToString("f2");
                                Decimal ical1 = Convert.ToDecimal(QTY[i].Text) * Irate;
                               AMt[i].Text = Decimal.Round(ical1, 2).ToString("f2");
                               //Decimal dSub1 = Convert.ToDecimal(txtamount.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
                               //txttotal.Text = Decimal.Round(dSub1, 2).ToString("f2");
                                link[i].Visible = true;
                                link[1].HRef = "~/images/" + ddldef.SelectedItem + ".jpg";
                            }
                            Decimal dSub1 =Convert.ToDecimal(txtamount.Text)+  Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
                                txttotal.Text = Decimal.Round(dSub1, 2).ToString("f2");
                            
                }
                else
                {

                     ds = objBs.SalesBillno("tblSales_" + sTableName);
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
            DataSet dsCategory=objBs.selectcategorydecription(Convert.ToInt32( ddlcategory.SelectedValue));
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
            DataSet dsCategory1 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory1.SelectedValue));
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
            DataSet dsCategory2 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory2.SelectedValue));
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
            DataSet dsCategory3 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory3.SelectedValue));
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
            DataSet dsCategory4 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory4.SelectedValue));
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
            DataSet dsCategory5 = objBs.selectcategorydecription(Convert.ToInt32(ddlcategory5.SelectedValue));
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
        protected void Add_Click(object sender, EventArgs e)
        {

            if (btnadd.Text == "Save")
            {


                //if (ddlcustomerID.SelectedValue == "Select Customer")
                //{

                //    lblerrorname.Text = "Please Select Customer Name";
                //}

                if (ddlcategory.SelectedValue == "Select Category")
                {
                    lblError.Text = "Please Select Category";
                }

                else
                    if (ddldef.SelectedValue == "Select Description")
                    {
                        lblError.Text = "Please Select Description";
                    }
                    else
                    {

                        DataTable dt = new DataTable();
                        DataRow dr = null;
                        dt.Columns.Add(new DataColumn("CatID", typeof(int)));
                        string iDealer = Request.QueryString.Get("iDealer");
                        if (iDealer != "" || iDealer != null)
                        {
                            dr = dt.NewRow();
                            dr["CatID"] = ddldef.SelectedValue;
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            dr = dt.NewRow();
                            dr["CatID"] = ddldef.SelectedValue;
                            dt.Rows.Add(dr);
                            if (ddldef1.SelectedValue != "Select Description")
                            {
                                dr = dt.NewRow();
                                dr["CatID"] = ddldef1.SelectedValue;
                                dt.Rows.Add(dr);
                            }
                            if (ddldef2.SelectedValue != "Select Description")
                            {
                                dr = dt.NewRow();
                                dr["CatID"] = ddldef2.SelectedValue;
                                dt.Rows.Add(dr);
                            }
                            if (ddldef3.SelectedValue != "Select Description")
                            {
                                dr = dt.NewRow();
                                dr["CatID"] = ddldef3.SelectedValue;
                                dt.Rows.Add(dr);
                            }
                            if (ddldef4.SelectedValue != "Select Description")
                            {
                                dr = dt.NewRow();
                                dr["CatID"] = ddldef4.SelectedValue;
                                dt.Rows.Add(dr);
                            }
                            if (ddldef5.SelectedValue != "Select Description")
                            {
                                dr = dt.NewRow();
                                dr["CatID"] = ddldef5.SelectedValue;
                                dt.Rows.Add(dr);
                            }
                        }
                        DataTable ds = dt.DefaultView.ToTable(true, "CatID");//Columns.
                        if (ds.Rows.Count != dt.Rows.Count)
                            lblError.Text = "Same Description Exist";
                        else
                        {
                            // Response.Write("same value exist");

                            int iStatus2 = 0, iStatus3 = 0, iStatus4 = 0, iStatus5 = 0, iStockSuccess = 0;
                            string Idealer = Request.QueryString.Get("iDealer");
                            string iQrySalesID = Request.QueryString.Get("iSalesID");
                            if (iQrySalesID != null)
                            {
                                #region edit button
                                if (txtamount.Text != "")
                                {
                                    int iDelete = objBs.DeleteSales("tblSales_" + sTableName, txtbillno.Text);

                                    int isalesid = Convert.ToInt32(txtbillno.Text);

                                    DataSet dsTransSales = objBs.GetTransSales("tblTransSales_" + sTableName, txtbillno.Text);
                                    if (dsTransSales.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dsTransSales.Tables[0].Rows.Count; i++)
                                        {
                                            string sddlCat = dsTransSales.Tables[0].Rows[i]["CategoryID"].ToString();
                                            string sddlDef = dsTransSales.Tables[0].Rows[i]["SubCategoryID"].ToString();
                                            string sQty = dsTransSales.Tables[0].Rows[i]["Quantity"].ToString();
                                            int iSuccs = UpdateEditStock(Convert.ToInt32(sddlCat), Convert.ToInt32(sddlDef), Convert.ToInt32(sQty));

                                        }
                                    }

                                    int iTransDelete = objBs.DeleteTransSales("tblTransSales_" + sTableName, txtbillno.Text);
                                    if (bblbillto.SelectedValue == "1")
                                    {

                                        try
                                        {
                                           // int iSuc = objBs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustname.Text, txtmobileno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, Convert.ToInt32(bblbillto.SelectedValue));


                                            DataSet dCustid = objBs.GerCustID(txtmobileno.Text);
                                            string iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
                                            decimal dBal = Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(txtadvance.Text);
                                            int iCustReceipt = objBs.DeleteCustomerReceipt(Convert.ToInt32(lblUserID.Text),Convert.ToInt32(isalesid));
                                            int iStat = objBs.insertsales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtdate1.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txttax.Text), Convert.ToDouble(txtdiscount.Text), Convert.ToInt32("1"), Convert.ToInt32(bblbillto.SelectedValue), Convert.ToDouble(txtadvance.Text));
                                            
                                            int iStatus = objBs.InsertCustomerReceipt(Convert.ToInt32(lblUserID.Text), txtbillno.Text, Convert.ToInt32(iCustid), txtdate1.Text, Convert.ToDouble(txtadvance.Text), Convert.ToDouble(dBal), Convert.ToDouble(txtgrandtotal.Text));
                                          
                                        }
                                        catch (Exception ex)
                                        {
                                            Response.Write(ex.ToString());
                                        }

                                    }

                                    int iStatus1 = objBs.insertTransSalesOrder("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(txtqty.Text), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtDiscItem.Text), Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddldef.SelectedValue));
                                        //iStockSuccess = InsertStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(txtqty.Text));
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(txtqty.Text));

                                    if (ddldef1.SelectedValue != "")
                                    {
                                        iStatus2 = objBs.insertTransSalesOrder("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(txtqty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtDiscItem1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToInt32(ddldef1.SelectedValue));
                                      //  iStockSuccess = InsertStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(txtqty1.Text));
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(txtqty1.Text));
                                    }
                                    if (ddldef2.SelectedValue != "")
                                    {
                                        iStatus2 = objBs.insertTransSalesOrder("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(txtqty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtDiscItem2.Text), Convert.ToDouble(txtamount2.Text), Convert.ToInt32(ddldef2.SelectedValue));
                                       // iStockSuccess = InsertStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(txtqty2.Text));
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(txtqty2.Text));
                                    }

                                    if (ddldef3.SelectedValue != "")
                                    {
                                        iStatus3 = objBs.insertTransSalesOrder("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(txtqty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtDiscItem3.Text), Convert.ToDouble(txtamount3.Text), Convert.ToInt32(ddldef3.SelectedValue));
                                      //  iStockSuccess = InsertStockAvailable(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(txtqty3.Text));
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(txtqty3.Text));
                                    }
                                    if (ddldef4.SelectedValue != "")
                                    {
                                        iStatus4 = objBs.insertTransSalesOrder("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(txtqty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtDiscItem4.Text), Convert.ToDouble(txtamount4.Text), Convert.ToInt32(ddldef4.SelectedValue));
                                       // iStockSuccess = InsertStockAvailable(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(txtqty4.Text));
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(txtqty4.Text));
                                    }

                                    if (ddldef5.SelectedValue != "")
                                    {
                                        iStatus5 = objBs.insertTransSalesOrder("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(txtqty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtDiscItem5.Text), Convert.ToDouble(txtamount5.Text), Convert.ToInt32(ddldef5.SelectedValue));
                                      //  iStockSuccess = InsertStockAvailable(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(txtqty5.Text));
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(txtqty5.Text));
                                    }
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append("From Bigdbiz-");
                                    sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtdate1.Text + ",");
                                    sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");


                                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.f9cs.com/sendsms.jsp?user=pratheep&password=demo1234&mobiles=9843566688&senderid=FINECS&sms=" + sb.ToString() + "");
                                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                    StreamReader reader = new StreamReader(response.GetResponseStream());
                                    string result = reader.ReadToEnd();

                                }
                                #endregion
                            }
                            
                           
                            else if (Idealer != null )
                            {
                                #region dealer condition
                                //int iStatus = objBs.insertsales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtdate1.Text, Convert.ToInt32(ddlcustomerID.SelectedValue), Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txttax.Text), Convert.ToDouble(txtdiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(bblbillto.SelectedValue), Convert.ToDouble(txtadvance.Text));
                                int isalesid = Convert.ToInt32(txtbillno.Text);// objBs.SalesId("tblSales_" + sTableName);


                                int iStatus1 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(txtqty.Text), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtDiscItem.Text), Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddldef.SelectedValue));
                                iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(txtqty.Text));
                                int iupdate = objBs.UpdateDealerStock(Convert.ToInt32(Idealer), Convert.ToInt32(ddldef.SelectedValue),txtbillno.Text,txtdate1.Text);

                                if (ddldef1.SelectedValue != "")
                                {
                                    iStatus2 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(txtqty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtDiscItem1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToInt32(ddldef1.SelectedValue));
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(txtqty1.Text));
                                    int iupdate1 = objBs.UpdateDealerStock(Convert.ToInt32(Idealer), Convert.ToInt32(ddldef1.SelectedValue),txtbillno.Text,txtdate1.Text);
                                }
                                if (ddldef2.SelectedValue != "")
                                {
                                    iStatus2 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(txtqty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtDiscItem2.Text), Convert.ToDouble(txtamount2.Text), Convert.ToInt32(ddldef2.SelectedValue));
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(txtqty2.Text));
                                    int iupdate2 = objBs.UpdateDealerStock(Convert.ToInt32(Idealer), Convert.ToInt32(ddldef2.SelectedValue), txtbillno.Text, txtdate1.Text);
                                }

                                if (ddldef3.SelectedValue != "")
                                {
                                    iStatus3 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(txtqty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtDiscItem3.Text), Convert.ToDouble(txtamount3.Text), Convert.ToInt32(ddldef3.SelectedValue));
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(txtqty3.Text));
                                    int iupdate3 = objBs.UpdateDealerStock(Convert.ToInt32(Idealer), Convert.ToInt32(ddldef3.SelectedValue), txtbillno.Text, txtdate1.Text);
                                }
                                if (ddldef4.SelectedValue != "")
                                {
                                    iStatus4 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(txtqty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtDiscItem4.Text), Convert.ToDouble(txtamount4.Text), Convert.ToInt32(ddldef4.SelectedValue));
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(txtqty4.Text));
                                    int iupdate4 = objBs.UpdateDealerStock(Convert.ToInt32(Idealer), Convert.ToInt32(ddldef4.SelectedValue), txtbillno.Text, txtdate1.Text);
                                }

                                if (ddldef5.SelectedValue != "")
                                {
                                    iStatus5 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(txtqty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtDiscItem5.Text), Convert.ToDouble(txtamount5.Text), Convert.ToInt32(ddldef5.SelectedValue));
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(txtqty5.Text));
                                    int iupdate5 = objBs.UpdateDealerStock(Convert.ToInt32(Idealer), Convert.ToInt32(ddldef5.SelectedValue), txtbillno.Text, txtdate1.Text);
                                }
                                #endregion
                            }
                            else
                            {
                                if (txtqty.Text != "")
                                {
                                    

                                        try
                                        {
                                            int iSuc = objBs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustname.Text, txtmobileno.Text, "0", txtaddress.Text, txtcity.Text, txtpincode.Text, Convert.ToInt32(bblbillto.SelectedValue));


                                            DataSet dCustid = objBs.GerCustID(txtmobileno.Text);
                                            string iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
                                            decimal dBal = Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(txtadvance.Text);

                                            int iStatus = objBs.InsertCustomerReceipt(Convert.ToInt32(lblUserID.Text), txtbillno.Text, Convert.ToInt32(iCustid), txtdate1.Text, Convert.ToDouble(txtadvance.Text), Convert.ToDouble(dBal), Convert.ToDouble(txtgrandtotal.Text));
                                            int iStat = objBs.insertsales("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtbillno.Text, txtdate1.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtgrandtotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txttax.Text), Convert.ToDouble(txtdiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(bblbillto.SelectedValue), Convert.ToDouble(txtadvance.Text));
                                        }
                                        catch (Exception ex)
                                        {
                                            Response.Write(ex.ToString());
                                        }
                                        
                                    
                                    
                                }
                                    int isalesid = Convert.ToInt32(txtbillno.Text);// objBs.SalesId("tblSales_" + sTableName);
                                    int iStatus1 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToDouble(txtqty.Text), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtDiscItem.Text), Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddldef.SelectedValue));
                                DataSet dcheck=objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef.SelectedValue));
                                    if(dcheck.Tables[0].Rows.Count>0)
                                    {
                                        //to check printing
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToDecimal(txtqty.Text));
                                    }
                                    else
                                    {
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToDecimal(txtqty.Text));
                                    }
                                    if (txtqty1.Text != "")
                                    {
                                        iStatus2 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToDouble(txtqty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtDiscItem1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToInt32(ddldef1.SelectedValue));

                                        DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef1.SelectedValue));
                                        if (dcheck1.Tables[0].Rows.Count > 0)
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToDecimal(txtqty1.Text));
                                        }
                                        else
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToDecimal(txtqty1.Text));
                                        }
                                    }
                                    if (txtqty2.Text != "")
                                    {
                                        iStatus2 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToDouble(txtqty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtDiscItem2.Text), Convert.ToDouble(txtamount2.Text), Convert.ToInt32(ddldef2.SelectedValue));

                                        DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef2.SelectedValue));
                                        if (dcheck1.Tables[0].Rows.Count > 0)
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToDecimal(txtqty2.Text));
                                        }
                                        else
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToDecimal(txtqty2.Text));
                                        }
                                    }

                                    if (txtqty3.Text != "")
                                    {
                                        iStatus3 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToDouble(txtqty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtDiscItem3.Text), Convert.ToDouble(txtamount3.Text), Convert.ToInt32(ddldef3.SelectedValue));

                                        DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef3.SelectedValue));
                                        if (dcheck1.Tables[0].Rows.Count > 0)
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToDecimal(txtqty2.Text));
                                        }
                                        else
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToDecimal(txtqty3.Text));
                                        }
                                    }
                                    if (txtqty4.Text != "")
                                    {
                                        iStatus4 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToDouble(txtqty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtDiscItem4.Text), Convert.ToDouble(txtamount4.Text), Convert.ToInt32(ddldef4.SelectedValue));

                                        DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef4.SelectedValue));
                                        if (dcheck1.Tables[0].Rows.Count > 0)
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToDecimal(txtqty2.Text));
                                        }
                                        else
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToDecimal(txtqty4.Text));
                                        }
                                    }

                                    if (txtqty5.Text != "")
                                    {
                                        iStatus5 = objBs.insertTransSales("tblTransSales_" + sTableName, isalesid, Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToDouble(txtqty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtDiscItem5.Text), Convert.ToDouble(txtamount5.Text), Convert.ToInt32(ddldef5.SelectedValue));

                                        DataSet dcheck1 = objBs.checkCheckBoxCondition(Convert.ToInt32(ddldef5.SelectedValue));
                                        if (dcheck1.Tables[0].Rows.Count > 0)
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToDecimal(txtqty2.Text));
                                        }
                                        else
                                        {
                                            iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToDecimal(txtqty5.Text));
                                        }
                                    }

                                    StringBuilder sb = new StringBuilder();
                                    sb.Append("From Bigdbiz-");
                                    sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtdate1.Text + ",");
                                    sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");


                                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.f9cs.com/sendsms.jsp?user=pratheep&password=demo1234&mobiles=&senderid=FINECS&sms="+sb.ToString()+"");
                                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                //StreamReader reader = new StreamReader(response.GetResponseStream());
                                //string result = reader.ReadToEnd();
                                }
                            }
                            Response.Redirect("../Accountsbootstrap/salesgrid.aspx");
                        }
                    }
            

    


            else
            {
                Response.Redirect("../Accountsbootstrap/salesgrid.aspx");
            }
        }
        private int UpdateStockAvailable(int iCat, int iSubCat, decimal iQty)
        {
            decimal iAQty = 0;
                
                int iSuccess = 0;
            //if (sTableName == "admin")
            //{

            
            
                DataSet dsStock = objBs.GetStockDetails(iSubCat);
                if (dsStock.Tables[0].Rows.Count > 0)
                {
                    iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                }
                decimal iRemQty = iAQty - iQty;
              //  iSuccess = objBs.updateSalesStock(iRemQty, iCat, iSubCat);
            
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

        private int UpdateEditStock(int iCat, int iSubCat, int iQty)
        {
            Decimal iAQty = 0; 
                int iSuccess = 0;
            //if (sTableName == "admin")
            //{
            DataSet dsStock = objBs.GetStockDetails(iSubCat);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

            }
            Decimal iInsQty = iAQty + iQty;
        //    iSuccess = objBs.updateSalesStock(iInsQty, iCat, iSubCat);

            return iSuccess;
        }

        private int InsertStockAvailable(int iCat, int iSubCat, int iQty)
        {
            Decimal iAQty = 0;
            int iSuccess = 0;
            //if (sTableName == "admin")
            //{

            string iQrySalesID = Request.QueryString.Get("iSalesID");
            if (iQrySalesID != null)
            {
                DataSet dsStock = objBs.GetStockDetails(iSubCat);
                if (dsStock.Tables[0].Rows.Count > 0)
                {
                    iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                }
                Decimal iRemQty = iAQty + iQty;
              //  iSuccess = objBs.updateSalesStock(iRemQty, iCat, iSubCat);
            }
           
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

        
        

        protected void txtrate_TextChanged1(object sender, EventArgs e)
        {
            Decimal iNetAmount = ((Convert.ToDecimal(txtqty.Text)) * (Convert.ToDecimal(txtrate.Text)));
            txtamount.Text = string.Format("{0:N2}", iNetAmount);
            
            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);

            Decimal dTotalTax = 0, dTotalTax1 = 0, dTotalTax2 = 0, dTotalTax3 = 0, dTotalTax4 = 0, dTotalTax5 = 0;
            if (dTaxAmt != 0)

                dTotalTax = dTaxAmt;

            if (dTaxAmt1 != 0)

                dTotalTax1 = dTaxAmt1;

            if (dTaxAmt2 != 0)

                dTotalTax2 = dTaxAmt2;

            if (dTaxAmt3 != 0)

                dTotalTax3 = dTaxAmt3;

            if (dTaxAmt4 != 0)

                dTotalTax4 = dTaxAmt4;

            if (dTaxAmt5 != 0)

                dTotalTax5 = dTaxAmt5;
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
            txtTaxamt.Text = Decimal.Round(DtotalTaxAmount, 2).ToString("f2");

        }
        protected void txtrate_TextChanged2(object sender, EventArgs e)
        {
            Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty1.Text)) * (Convert.ToDecimal(txtrate1.Text)));
            txtamount1.Text = string.Format("{0:N2}", iNetAmount1);

            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0; 
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
        }
        protected void txtrate_TextChanged3(object sender, EventArgs e)
        {
            Decimal iNetAmount2 = ((Convert.ToDecimal(txtqty2.Text)) * (Convert.ToDecimal(txtrate2.Text)));
            txtamount2.Text = string.Format("{0:N2}", iNetAmount2);

            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
    }
        protected void txtrate_TextChanged4(object sender, EventArgs e)
        {
            Decimal iNetAmount3 = ((Convert.ToDecimal(txtqty3.Text)) * (Convert.ToDecimal(txtrate3.Text)));
            txtamount3.Text = string.Format("{0:N2}", iNetAmount3);

            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
        }

        protected void txtrate_TextChanged5(object sender, EventArgs e)
        {
            Decimal iNetAmount4 = ((Convert.ToDecimal(txtqty4.Text)) * (Convert.ToDecimal(txtrate4.Text)));
            txtamount4.Text = string.Format("{0:N2}", iNetAmount4);

            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");

        }
        protected void txtrate_TextChanged6(object sender, EventArgs e)
        {
            Decimal iNetAmount5 = ((Convert.ToDecimal(txtqty5.Text)) * (Convert.ToDecimal(txtrate5.Text)));
            txtamount5.Text = string.Format("{0:N2}", iNetAmount5);

            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");

        }
        protected void btncalc_Click(object sender, EventArgs e)
        {
            iDealer = Request.QueryString.Get("iDealer");
            Decimal dDisc = 0, dTax = 0;
            Decimal UnitTax = 0, UnitTax1 = 0, UnitTax2 = 0, UnitTax3 = 0, UnitTax4 = 0, UnitTax5 = 0;
            Decimal Ttax = 0, Ttax1 = 0, Ttax2 = 0, Ttax3 = 0, Ttax4 = 0, Ttax5 = 0;
            Decimal cal = 0, cal1 = 0, cal2 = 0, cal3 = 0, cal4 = 0, cal5 = 0;
            Decimal Orgcal = 0, Orgcal1 = 0, Orgcal2 = 0, Orgcal3 = 0, Orgcal4 = 0, Orgcal5 = 0;
          

           
                if (bblbillto.SelectedValue == "2")
                {
                    if (iDealer!=null)
                    {
                        dTax = Convert.ToDecimal(txttax.Text);
                        decimal Dtotal = Convert.ToDecimal(txttotal.Text);
                        decimal dGrandTotal =Dtotal+( Dtotal * (dTax / 100));
                        txtgrandtotal.Text = Decimal.Round(dGrandTotal, 2).ToString("f2");
                    }
                    else
                    {

                        dTax = Convert.ToDecimal(txttax.Text);
                        decimal Dtotal = Convert.ToDecimal(txttotal.Text);
                        decimal dGrandTotal = Dtotal + (Dtotal * (dTax / 100));
                        txtgrandtotal.Text = Decimal.Round(dGrandTotal, 2).ToString("f2");
                        //txtTaxamt.Text = decimal.Round(dTax, 2).ToString("f2");

                        //Decimal iTotal = Convert.ToDecimal(txtamount.Text) + Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
                        //txttotal.Text = decimal.Round(iTotal, 2).ToString("f2");
                        //dDisc = Convert.ToDecimal(txttotal.Text) * (Convert.ToDecimal(txtdiscount.Text) / 100);
                        ////dTax = (Convert.ToDecimal(txttotal.Text) - dDisc) * (dTax / 100);
                        //Decimal txtgrandtotalvalue = Convert.ToDecimal(txttotal.Text) - dDisc +Convert.ToDecimal( txtTaxamt.Text);
                        ////txtdiscount.Text = Convert.ToString( dDisc);
                        //// txtdiscount.Text=string.Format("{0:N2}",dDisc);
                        //txtDiscamt.Text = string.Format("{0:N2}", dDisc);
                        ////txtTaxamt.Text = string.Format("{0:N2}", dTax);
                        ////txtgrandtotal.Text = Convert.ToString(txtgrandtotalvalue);
                        //txtgrandtotal.Text = string.Format("{0:N2}", txtgrandtotalvalue);
                    }
                }
              
                     
                else
                {
                    //dTax = Convert.ToDecimal(txttax.Text);
                    //decimal Dtotal = Convert.ToDecimal(txttotal.Text);
                    //decimal dGrandTotal = Dtotal + (Dtotal * (dTax / 100));
                    //txtgrandtotal.Text = Decimal.Round(dGrandTotal, 2).ToString("f2");

                    dTax = Convert.ToDecimal(txtTaxAmount.Text) + Convert.ToDecimal(txtTaxAmt1.Text) + Convert.ToDecimal(txtTaxAmt2.Text) + Convert.ToDecimal(txtTaxAmt3.Text) + Convert.ToDecimal(txtTaxAmt4.Text) + Convert.ToDecimal(txtTaxAmt5.Text);
                    Decimal iTotal = Convert.ToDecimal(txtamount.Text) + Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
                    //Decimal iOrgTotal = Convert.ToDecimal(txtOrgAmount.Text) + Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);

                    txttotal.Text = string.Format("{0:N2}", iTotal);
                    //  txtOrgTotal.Text = string.Format("{0:N2}", iOrgTotal);
                    // dDisc = Convert.ToDecimal(txttotal.Text) * (Convert.ToDecimal(txtdiscount.Text) / 100);
                    // dTax = (Convert.ToDecimal(txttotal.Text) - dDisc) + (dTax );
                    Decimal txtgrandtotalvalue = Convert.ToDecimal(txttotal.Text) + dTax; ;
                    //txtdiscount.Text = Convert.ToString( dDisc);
                    // txtdiscount.Text=string.Format("{0:N2}",dDisc);
                    //txtDiscamt.Text = string.Format("{0:N2}", dDisc);
                    //txtTaxamt.Text = string.Format("{0:N2}", dTax);
                    //txtgrandtotal.Text = Convert.ToString(txtgrandtotalvalue);
                    txtgrandtotal.Text = string.Format("{0:N2}", txtgrandtotalvalue);
                }
               
            
          
        }
        private void TotalAmount()
    {
        Decimal iTotal = Convert.ToDecimal(txtamount.Text) + Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
    }
        protected void ddldef_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DataSet dsStock = new DataSet();
            //if(sTableName=="admin")
                dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef.SelectedValue));
            //else
            //    dsStock = objBs.GetStockDetails_Dealer(Convert.ToInt32(ddldef.SelectedValue),"tblStock_"+sTableName);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                string sQty= dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
                txtqty.ToolTip="AvailableQty"+sQty;
                Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
                txtrate.Text = Decimal.Round(Irate, 2).ToString("f2");
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
                btnlink1.Visible = true;
                btnlink1.HRef = "~/images/"+ddldef.SelectedItem + ".jpg";


            }
        }

        protected void ddldef1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef1.SelectedValue));
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                string sQty1 = dsStock.Tables[0].Rows[0]["Available_Qty"].ToString();
                txtqty1.ToolTip = "AvailableQty" + sQty1;
                Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
                txtrate1.Text = Decimal.Round(Irate, 2).ToString("f2");
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
                btnlink2.Visible = true;
                btnlink2.HRef = "~/images/" + ddldef1.SelectedItem + ".jpg";
            }
        }

        protected void ddldef2_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef2.SelectedValue));
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            txtrate2.Text = Decimal.Round(Irate, 2).ToString("f2");
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
                btnlink3.Visible = true;
                btnlink3.HRef = "~/images/" + ddldef2.SelectedItem + ".jpg";
            
        }

        protected void ddldef3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef3.SelectedValue));
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            txtrate3.Text = Decimal.Round(Irate, 2).ToString("f2");
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
                btnlink4.Visible = true;
                btnlink4.HRef = "~/images/" + ddldef3.SelectedItem + ".jpg";
            
        }

        protected void ddldef4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef4.SelectedValue));
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            txtrate4.Text = Decimal.Round(Irate, 2).ToString("f2");
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
                btnlink5.Visible = true;
                btnlink5.HRef = "~/images/" + ddldef4.SelectedItem + ".jpg";
            
        }
        protected void ddldef5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef5.SelectedValue));
            Decimal Irate = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["UnitPrice"].ToString());
            txtrate5.Text = Decimal.Round(Irate, 2).ToString("f2");
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
                btnlink6.Visible = true;
                btnlink6.HRef = "~/images/" + ddldef5.SelectedItem + ".jpg";
            
        }

        protected void txtqty_TextChanged(object sender, EventArgs e)
        {
            //DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef.SelectedValue));
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{

            //    Decimal dAlreadyQty = (Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString()));
            //if(dAlreadyQty<(Convert.ToDecimal(txtqty.Text)))
            //{
            //   lblError.Text="Entered Quantity not available";
            //   txtrate.Enabled = false;
            //}
            //else
            //{

            Decimal iNetAmount = ((Convert.ToDecimal(txtqty.Text)) * (Convert.ToDecimal(txtrate.Text)));
            txtamount.Text = Convert.ToString(iNetAmount);
            DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }
            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);

            Decimal damt = Convert.ToDecimal(dTax / 100) * Convert.ToDecimal(txtamount.Text);
            txtTaxAmount.Text = Convert.ToString(damt);
            //Decimal dTotalTax = 0, dTotalTax1 = 0, dTotalTax2 = 0, dTotalTax3 = 0, dTotalTax4 = 0, dTotalTax5 = 0;
            //if (dTaxAmt != 0)

            //    dTotalTax = dTaxAmt;

            //if (dTaxAmt1 != 0)

            //    dTotalTax1 = dTaxAmt1;

            //if (dTaxAmt2 != 0)

            //    dTotalTax2 = dTaxAmt2;

            //if (dTaxAmt3 != 0)

            //    dTotalTax3 = dTaxAmt3;

            //if (dTaxAmt4 != 0)

            //    dTotalTax4 = dTaxAmt4;

            //if (dTaxAmt5 != 0)

            //    dTotalTax5 = dTaxAmt5;
            lblError.Text = "";
            txtrate.Enabled = true;
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            decimal DtotalTaxAmount = dTaxAmt ;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
           // txtTaxamt.Text = Decimal.Round(DtotalTaxAmount, 2).ToString("f2");
            GrossCalc();
            //}
                
        
            //}
            //else
            //{
            //    lblError.Text = "Stock not Available";
            //    txtrate.Enabled = false;
            //}
        }

        protected void txtqty1_TextChanged(object sender, EventArgs e)
        {
            //DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef1.SelectedValue));
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{

            //    Decimal dAlreadyQty = (Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString()));
            //    if (dAlreadyQty < (Convert.ToDecimal(txtqty1.Text)))
            //    {
            //        lblError.Text = "Entered Quantity not available";
            //    }
            //    else
            //    {
                    Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty1.Text)) * (Convert.ToDecimal(txtrate1.Text)));
                    txtamount1.Text = Convert.ToString(iNetAmount1);
                    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef1.SelectedValue));
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        dTax1 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                    }
                    Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
                    if (txtamount.Text != "")
                        iGross1 = Convert.ToDecimal(txtamount.Text);
                    if (txtamount1.Text != "")
                        iGross2 = Convert.ToDecimal(txtamount1.Text);
                    if (txtamount2.Text != "")
                        iGross3 = Convert.ToDecimal(txtamount2.Text);
                    if (txtamount3.Text != "")
                        iGross4 = Convert.ToDecimal(txtamount3.Text);
                    if (txtamount4.Text != "")
                        iGross5 = Convert.ToDecimal(txtamount4.Text);
                    if (txtamount5.Text != "")
                        iGross6 = Convert.ToDecimal(txtamount5.Text);

                    Decimal damt = Convert.ToDecimal(dTax1 / 100) * Convert.ToDecimal(txtamount1.Text);
                    txtTaxAmt1.Text = Convert.ToString(damt);
                    //Decimal dTotalTax = 0, dTotalTax1 = 0, dTotalTax2 = 0, dTotalTax3 = 0, dTotalTax4 = 0, dTotalTax5 = 0;
                    //if (dTaxAmt != 0)

                    //    dTotalTax = dTaxAmt;

                    //if (dTaxAmt1 != 0)

                    //    dTotalTax1 = dTaxAmt1;

                    //if (dTaxAmt2 != 0)

                    //    dTotalTax2 = dTaxAmt2;

                    //if (dTaxAmt3 != 0)

                    //    dTotalTax3 = dTaxAmt3;

                    //if (dTaxAmt4 != 0)

                    //    dTotalTax4 = dTaxAmt4;

                    //if (dTaxAmt5 != 0)

                    //    dTotalTax5 = dTaxAmt5;
                    lblError.Text = "";
                    txtrate.Enabled = true;
                    Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
                   
                    txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
                    decimal d2 = Convert.ToDecimal(txtTaxamt.Text) + dTaxAmt1;
                    //txtTaxamt.Text = Decimal.Round(d2, 2).ToString("f2");
                  
                    GrossCalc();
            //    }
            //}
        }
        protected void txtqty2_TextChanged(object sender, EventArgs e)
        {
            //DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef2.SelectedValue));
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{

            //    Decimal dAlreadyQty = (Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString()));
            //    if (dAlreadyQty < (Convert.ToDecimal(txtqty2.Text)))
            //    {
            //        lblError.Text = "Entered Quantity not available";
            //    }
            //    else
            //    {
                    Decimal iNetAmount2 = ((Convert.ToDecimal(txtqty2.Text)) * (Convert.ToDecimal(txtrate2.Text)));
                    txtamount2.Text = Convert.ToString(iNetAmount2);
                    lblError.Text = "";
                    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef2.SelectedValue));
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        dTax2 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                    }
                    Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
                    if (txtamount.Text != "")
                        iGross1 = Convert.ToDecimal(txtamount.Text);
                    if (txtamount1.Text != "")
                        iGross2 = Convert.ToDecimal(txtamount1.Text);
                    if (txtamount2.Text != "")
                        iGross3 = Convert.ToDecimal(txtamount2.Text);
                    if (txtamount3.Text != "")
                        iGross4 = Convert.ToDecimal(txtamount3.Text);
                    if (txtamount4.Text != "")
                        iGross5 = Convert.ToDecimal(txtamount4.Text);
                    if (txtamount5.Text != "")
                        iGross6 = Convert.ToDecimal(txtamount5.Text);

                    Decimal damt = Convert.ToDecimal(dTax2 / 100) * Convert.ToDecimal(txtamount2.Text);
                    txtTaxAmt2.Text = Convert.ToString(damt);
                    
                    lblError.Text = "";
                    txtrate.Enabled = true;
                    Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
                    //decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
                    txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
                    decimal d2 = Convert.ToDecimal(txtTaxamt.Text) + dTaxAmt2;
                    txtTaxamt.Text = Decimal.Round(d2, 2).ToString("f2");
                    GrossCalc();
            //    }
            //}
        }
        protected void txtqty3_TextChanged(object sender, EventArgs e)
        {
            //DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef3.SelectedValue));
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{

            //    Decimal dAlreadyQty = (Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString()));
            //    if (dAlreadyQty < (Convert.ToDecimal(txtqty3.Text)))
            //    {
            //        lblError.Text = "Entered Quantity not available";
            //    }
            //    else
            //    {
                    Decimal iNetAmount3 = ((Convert.ToDecimal(txtqty3.Text)) * (Convert.ToDecimal(txtrate3.Text)));
                    txtamount3.Text = Convert.ToString(iNetAmount3);
                    lblError.Text = "";
                    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef3.SelectedValue));
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        dTax3 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                    }
                    Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
                    if (txtamount.Text != "")
                        iGross1 = Convert.ToDecimal(txtamount.Text);
                    if (txtamount1.Text != "")
                        iGross2 = Convert.ToDecimal(txtamount1.Text);
                    if (txtamount2.Text != "")
                        iGross3 = Convert.ToDecimal(txtamount2.Text);
                    if (txtamount3.Text != "")
                        iGross4 = Convert.ToDecimal(txtamount3.Text);
                    if (txtamount4.Text != "")
                        iGross5 = Convert.ToDecimal(txtamount4.Text);
                    if (txtamount5.Text != "")
                        iGross6 = Convert.ToDecimal(txtamount5.Text);

                    Decimal damt = Convert.ToDecimal(dTax3 / 100) * Convert.ToDecimal(txtamount3.Text);
                    txtTaxAmt3.Text = Convert.ToString(damt);
                    //Decimal dTotalTax = 0, dTotalTax1 = 0, dTotalTax2 = 0, dTotalTax3 = 0, dTotalTax4 = 0, dTotalTax5 = 0;
                    //if (dTaxAmt != 0)

                    //    dTotalTax = dTaxAmt;

                    //if (dTaxAmt1 != 0)

                    //    dTotalTax1 = dTaxAmt1;

                    //if (dTaxAmt2 != 0)

                    //    dTotalTax2 = dTaxAmt2;

                    //if (dTaxAmt3 != 0)

                    //    dTotalTax3 = dTaxAmt3;

                    //if (dTaxAmt4 != 0)

                    //    dTotalTax4 = dTaxAmt4;

                    //if (dTaxAmt5 != 0)

                    //    dTotalTax5 = dTaxAmt5;
                    lblError.Text = "";
                    txtrate.Enabled = true;
                    Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
                    //decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
                    txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
                    decimal d2 = Convert.ToDecimal(txtTaxamt.Text) + dTaxAmt3;
                   // txtTaxamt.Text = Decimal.Round(d2, 2).ToString("f2");
                    GrossCalc();
            //    }
            //}
        }

        protected void txtqty4_TextChanged(object sender, EventArgs e)
        {
            //DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef4.SelectedValue));
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{

            //    Decimal dAlreadyQty = (Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString()));
            //    if (dAlreadyQty < (Convert.ToDecimal(txtqty4.Text)))
            //    {
            //        lblError.Text = "Entered Quantity not available";
            //    }
            //    else
            //    {
                    Decimal iNetAmount4 = ((Convert.ToDecimal(txtqty4.Text)) * (Convert.ToDecimal(txtrate4.Text)));
                    txtamount4.Text = Convert.ToString(iNetAmount4);
                    lblError.Text = "";
                    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef4.SelectedValue));
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        dTax4 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                    }
                    Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
                    if (txtamount.Text != "")
                        iGross1 = Convert.ToDecimal(txtamount.Text);
                    if (txtamount1.Text != "")
                        iGross2 = Convert.ToDecimal(txtamount1.Text);
                    if (txtamount2.Text != "")
                        iGross3 = Convert.ToDecimal(txtamount2.Text);
                    if (txtamount3.Text != "")
                        iGross4 = Convert.ToDecimal(txtamount3.Text);
                    if (txtamount4.Text != "")
                        iGross5 = Convert.ToDecimal(txtamount4.Text);
                    if (txtamount5.Text != "")
                        iGross6 = Convert.ToDecimal(txtamount5.Text);

                    Decimal damt = Convert.ToDecimal(dTax4 / 100) * Convert.ToDecimal(txtamount4.Text);
                    txtTaxAmt4.Text = Convert.ToString(damt);
                    //Decimal dTotalTax = 0, dTotalTax1 = 0, dTotalTax2 = 0, dTotalTax3 = 0, dTotalTax4 = 0, dTotalTax5 = 0;
                    //if (dTaxAmt != 0)

                    //    dTotalTax = dTaxAmt;

                    //if (dTaxAmt1 != 0)

                    //    dTotalTax1 = dTaxAmt1;

                    //if (dTaxAmt2 != 0)

                    //    dTotalTax2 = dTaxAmt2;

                    //if (dTaxAmt3 != 0)

                    //    dTotalTax3 = dTaxAmt3;

                    //if (dTaxAmt4 != 0)

                    //    dTotalTax4 = dTaxAmt4;

                    //if (dTaxAmt5 != 0)

                    //    dTotalTax5 = dTaxAmt5;
                    lblError.Text = "";
                    txtrate.Enabled = true;
                    Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
                   // decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
                    txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
                    decimal d2 = Convert.ToDecimal(txtTaxamt.Text) + dTaxAmt4;
                   // txtTaxamt.Text = Decimal.Round(d2, 2).ToString("f2");
                    GrossCalc();
            //    }
            //}
        }

        protected void txtqty5_TextChanged(object sender, EventArgs e)
        {
            //DataSet dsStock = objBs.GetStockDetails(Convert.ToInt32(ddldef5.SelectedValue));
            //if (dsStock.Tables[0].Rows.Count > 0)
            //{

            //    Decimal dAlreadyQty = (Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString()));
            //    if (dAlreadyQty < (Convert.ToDecimal(txtqty5.Text)))
            //    {
            //        lblError.Text = "Entered Quantity not available";
            //    }
            //    else
            //    {
                    Decimal iNetAmount5 = ((Convert.ToDecimal(txtqty5.Text)) * (Convert.ToDecimal(txtrate5.Text)));
                    txtamount5.Text = Convert.ToString(iNetAmount5);
                    lblError.Text = "";
                    DataSet dsCategory = objBs.GetTax(Convert.ToInt32(ddldef5.SelectedValue));
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        dTax5 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
                    }
                    Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
                    if (txtamount.Text != "")
                        iGross1 = Convert.ToDecimal(txtamount.Text);
                    if (txtamount1.Text != "")
                        iGross2 = Convert.ToDecimal(txtamount1.Text);
                    if (txtamount2.Text != "")
                        iGross3 = Convert.ToDecimal(txtamount2.Text);
                    if (txtamount3.Text != "")
                        iGross4 = Convert.ToDecimal(txtamount3.Text);
                    if (txtamount4.Text != "")
                        iGross5 = Convert.ToDecimal(txtamount4.Text);
                    if (txtamount5.Text != "")
                        iGross6 = Convert.ToDecimal(txtamount5.Text);

                    Decimal damt = Convert.ToDecimal(dTax5 / 100) * Convert.ToDecimal(txtamount5.Text);
                    txtTaxAmt5.Text = Convert.ToString(damt);
                    //Decimal dTotalTax = 0, dTotalTax1 = 0, dTotalTax2 = 0, dTotalTax3 = 0, dTotalTax4 = 0, dTotalTax5 = 0;
                    //if (dTaxAmt != 0)

                    //    dTotalTax = dTaxAmt;

                    //if (dTaxAmt1 != 0)

                    //    dTotalTax1 = dTaxAmt1;

                    //if (dTaxAmt2 != 0)

                    //    dTotalTax2 = dTaxAmt2;

                    //if (dTaxAmt3 != 0)

                    //    dTotalTax3 = dTaxAmt3;

                    //if (dTaxAmt4 != 0)

                    //    dTotalTax4 = dTaxAmt4;

                    //if (dTaxAmt5 != 0)

                    //    dTotalTax5 = dTaxAmt5;
                    lblError.Text = "";
                    txtrate.Enabled = true;
                    Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
                   // decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
                    txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
                    decimal d2 = Convert.ToDecimal(txtTaxamt.Text) + dTaxAmt5;
                    txtTaxamt.Text = Decimal.Round(d2, 2).ToString("f2");
                    GrossCalc();
            //    }
            //}
        }
        private void GrossCalc()
        {
            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5+iGross6;
            txttotal.Text = Convert.ToString(iTotalAmount);
        }

        protected void bblbillto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataSet dsCustomer = objBs.GetCustName(Convert.ToInt32( 1));
            //if (bblbillto.SelectedValue == "1")
            //{
                txtCustname.Visible = true;
                //ddlcustomerID.Visible = false;
                txtcustomername.Text = "";
                txtaddress.Text = "";
                txtcity.Text = "";
                //txtarea.Text = "";
                txtpincode.Text = "";
                txtcuscode.Text = "";
                advance.Visible = true;
                tax.Visible = false;
            //}
            //else if (bblbillto.SelectedValue == "3")
            //{
            //    txtCustname.Visible = false;
            //    ddlcustomerID.Visible = true;
            //    advance.Visible = false;
            //    tax.Visible = false;
            //    if (dsCustomer.Tables[0].Rows.Count > 0)
            //    {
            //        ddlcustomerID.DataSource = dsCustomer.Tables[0];
            //        ddlcustomerID.DataTextField = "CustomerName";
            //        ddlcustomerID.DataValueField = "CustomerID";
            //        ddlcustomerID.DataBind();
            //        ddlcustomerID.Items.Insert(0, "Select Press");

            //        // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

            //    }
            //}
            //else
            //{
            //    txtCustname.Visible = false;
              //ddlcustomerID.Visible = false;
            //    advance.Visible = false;
            //    tax.Visible = true;
            //    if (dsCustomer.Tables[0].Rows.Count > 0)
            //    {
            //        ddlcustomerID.DataSource = dsCustomer.Tables[0];
            //        ddlcustomerID.DataTextField = "CustomerName";
            //        ddlcustomerID.DataValueField = "CustomerID";
            //        ddlcustomerID.DataBind();
            //        ddlcustomerID.Items.Insert(0, "Select Dealer");

            //        // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

            //    }
            //}
           
        }

        

        protected void txtaddress_TextChanged(object sender, EventArgs e)
        {
            DataSet dCheck = objBs.CheckMobileNo(txtmobileno.Text);
            if (dCheck.Tables[0].Rows.Count > 0)
            {
                lblerrorname.Text = "Mobile Number Already Exists" + "Please Enter Another Number";
                btnadd.Visible = false;
            }
            else
            {
                lblerrorname.Text = "";
                btnadd.Visible = true;
            }
        }

        protected void txtmobileno_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtmobileno_TextChanged1(object sender, EventArgs e)
        {
           
        }

        protected void txtmobileno_TextChanged2(object sender, EventArgs e)
        {
            DataSet dCustid = objBs.GerCustID(txtmobileno.Text);
            if (dCustid.Tables[0].Rows.Count > 0)
            {
                txtCustname.Text = dCustid.Tables[0].Rows[0]["CustomerName"].ToString();
                txtaddress.Text = dCustid.Tables[0].Rows[0]["Address"].ToString();
                txtcity.Text = dCustid.Tables[0].Rows[0]["City"].ToString();
                //txtarea.Text = dCustid.Tables[0].Rows[0]["Area"].ToString();
                txtpincode.Text = dCustid.Tables[0].Rows[0]["Pincode"].ToString();
                txtcuscode.Text = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
                txtmobileno.Text = dCustid.Tables[0].Rows[0]["MobileNo"].ToString();
                lblmoberror.InnerText = "Reapeated Customer";
                //btnadd.Visible = false;
            }
            else
            {
                lblmoberror.InnerText = "";
                btnadd.Visible = true;
            }
        }

       

        protected void txtDiscItem_TextChanged1(object sender, EventArgs e)
        {
            Decimal iNetAmount = ((Convert.ToDecimal(txtqty.Text)) * (Convert.ToDecimal(txtrate.Text)));
            txtamount.Text = string.Format("{0:N2}", iNetAmount);
            txtamount.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));

            Decimal iOrgNetAmount = ((Convert.ToDecimal(txtqty.Text)) * (Convert.ToDecimal(txtOrgRate.Text)));
            txtOrgAmount.Text = string.Format("{0:N2}", iNetAmount);
            txtOrgAmount.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtOrgAmount.Text), Convert.ToString(txtDiscItem.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));
            CalcAmount();
        }
        protected void txtDiscItem1_TextChanged1(object sender, EventArgs e)
        {
            txtamount1.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtamount1.Text), Convert.ToString(txtDiscItem1.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));
            CalcAmount();
        }
        protected void txtDiscItem2_TextChanged1(object sender, EventArgs e)
        {
            txtamount2.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtamount1.Text), Convert.ToString(txtDiscItem1.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));
            CalcAmount();
        }
        protected void txtDiscItem3_TextChanged1(object sender, EventArgs e)
        {
            txtamount3.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtamount1.Text), Convert.ToString(txtDiscItem1.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));
            CalcAmount();
        }
        protected void txtDiscItem4_TextChanged1(object sender, EventArgs e)
        {
            txtamount4.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtamount1.Text), Convert.ToString(txtDiscItem1.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));
            CalcAmount();
        }
        protected void txtDiscItem5_TextChanged1(object sender, EventArgs e)
        {
            txtamount5.Text = string.Format("{0:N2}", dCalcDisc(Convert.ToString(txtamount1.Text), Convert.ToString(txtDiscItem1.Text))); //Convert.ToString(dCalcDisc(Convert.ToString(txtamount.Text), Convert.ToString(txtDiscItem.Text)));
            CalcAmount();
        }

        private decimal dCalcDisc(string sAmount,string sDiscAmt)
        {
            decimal UnitTax = (Convert.ToDecimal(sDiscAmt) / 100) * Convert.ToDecimal(sAmount);
            decimal Ttax = Convert.ToDecimal(sAmount) - UnitTax;
          

            return Ttax;
        }
        private void CalcAmount()
        {
            Decimal iGross1 = 0; Decimal iGross2 = 0; Decimal iGross3 = 0; Decimal iGross4 = 0; Decimal iGross5 = 0; Decimal iGross6 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToDecimal(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToDecimal(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToDecimal(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToDecimal(txtamount3.Text);
            if (txtamount4.Text != "")
                iGross5 = Convert.ToDecimal(txtamount4.Text);
            if (txtamount5.Text != "")
                iGross6 = Convert.ToDecimal(txtamount5.Text);
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
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
            ddldef1.SelectedItem.Text="";
            txtqty1.Text = "";
            txtrate1.Text = "0";
            txtDiscItem1.Text = "0";
            txtamount1.Text = "0";
            txtTaxAmt1.Text = "0";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory2.ClearSelection();
            ddldef2.SelectedItem.Text = "";
            txtqty2.Text = "";
            txtrate2.Text = "0";
            txtDiscItem2.Text = "0";
            txtamount2.Text = "0";
             txtTaxAmt2.Text = "0";
        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory3.ClearSelection();
            ddldef3.SelectedItem.Text = "";
            txtqty3.Text = "";
            txtrate3.Text = "0";
            txtDiscItem3.Text = "0";
            txtamount3.Text = "0";
            txtTaxAmt3.Text = "0";
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory4.ClearSelection();
            ddldef4.SelectedItem.Text = "";
            txtqty4.Text = "";
            txtrate4.Text = "0";
            txtDiscItem4.Text = "0";
            txtamount4.Text = "0";
            txtTaxAmt4.Text = "0";
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory5.ClearSelection();
            ddldef5.SelectedItem.Text = "";
            txtqty5.Text = "";
            txtrate5.Text = "0";
            txtDiscItem5.Text = "0";
            txtamount5.Text = "0";
            txtTaxAmt5.Text = "0";
        }
        

        

        

        

    }
}