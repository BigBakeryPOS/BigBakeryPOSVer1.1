using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class Purchase : System.Web.UI.Page
    { 
        BSClass objbs = new BSClass();
        decimal dTax = 0 ,dTax1=0 ,dTax2=0 ,dTax3=0 ,dTax4=0 ,dTax5=0;
        decimal dTaxAmt = 0, dTaxAmt1 = 0, dTaxAmt2 = 0, dTaxAmt3 = 0, dTaxAmt4 = 0, dTaxAmt5 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();




            if (!IsPostBack)
            {
               tax14.Visible = false;

               
                DataSet dsCustomer = objbs.GetVendorName();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlvendor.DataSource = dsCustomer.Tables[0];
                    ddlvendor.DataTextField = "CustomerName";
                    ddlvendor.DataValueField = "CustomerID";
                    ddlvendor.DataBind();
                    ddlvendor.Items.Insert(0, "Select Vendor");
                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                }
                DataSet dsCategory = objbs.selectcategorymaster();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory1 = objbs.selectcategorymaster();
                if (dsCategory1.Tables[0].Rows.Count > 0)
                {
                    ddlcategory1.DataSource = dsCategory.Tables[0];
                    ddlcategory1.DataTextField = "category";
                    ddlcategory1.DataValueField = "categoryid";
                    ddlcategory1.DataBind();
                    ddlcategory1.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory2 = objbs.selectcategorymaster();
                if (dsCategory2.Tables[0].Rows.Count > 0)
                {
                    ddlcategory2.DataSource = dsCategory.Tables[0];
                    ddlcategory2.DataTextField = "category";
                    ddlcategory2.DataValueField = "categoryid";
                    ddlcategory2.DataBind();
                    ddlcategory2.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory3 = objbs.selectcategorymaster();
                if (dsCategory3.Tables[0].Rows.Count > 0)
                {
                    ddlcategory3.DataSource = dsCategory.Tables[0];
                    ddlcategory3.DataTextField = "category";
                    ddlcategory3.DataValueField = "categoryid";
                    ddlcategory3.DataBind();
                    ddlcategory3.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory4 = objbs.selectcategorymaster();
                if (dsCategory4.Tables[0].Rows.Count > 0)
                {
                    ddlcategory4.DataSource = dsCategory.Tables[0];
                    ddlcategory4.DataTextField = "category";
                    ddlcategory4.DataValueField = "categoryid";
                    ddlcategory4.DataBind();
                    ddlcategory4.Items.Insert(0, "Select Category");


                }
                DataSet dsCategory5 = objbs.selectcategorymaster();
                if (dsCategory5.Tables[0].Rows.Count > 0)
                {
                    ddlcategory5.DataSource = dsCategory.Tables[0];
                    ddlcategory5.DataTextField = "category";
                    ddlcategory5.DataValueField = "categoryid";
                    ddlcategory5.DataBind();
                    ddlcategory5.Items.Insert(0, "Select Category");


                }

                //DataSet dunits = objbs.UNITS();
                //ddlunits.DataSource = dunits;
                //ddlunits.DataTextField = "Units";
                //ddlunits.DataValueField = "UOM_ID";
                //ddlunits.DataBind();
                //ddlunits.Items.Insert(0, "select");

                //DataSet dunits1 = objbs.UNITS();
                //ddlunits1.DataSource = dunits1;
                //ddlunits1.DataTextField = "Units";
                //ddlunits1.DataValueField = "UOM_ID";
                //ddlunits1.DataBind();
                //ddlunits1.Items.Insert(0, "select");

                //DataSet dunits2 = objbs.UNITS();
                //ddlunits2.DataSource = dunits2;
                //ddlunits2.DataTextField = "Units";
                //ddlunits2.DataValueField = "UOM_ID";
                //ddlunits2.DataBind();
                //ddlunits2.Items.Insert(0, "select");

                //DataSet dunits3 = objbs.UNITS();
                //ddlunits3.DataSource = dunits3;
                //ddlunits3.DataTextField = "Units";
                //ddlunits3.DataValueField = "UOM_ID";
                //ddlunits3.DataBind();
                //ddlunits3.Items.Insert(0, "select");

                //DataSet dunits4 = objbs.UNITS();
                //ddlunits4.DataSource = dunits4;
                //ddlunits4.DataTextField = "Units";
                //ddlunits4.DataValueField = "UOM_ID";
                //ddlunits4.DataBind();
                //ddlunits4.Items.Insert(0, "select");

                //DataSet dunits5 = objbs.UNITS();
                //ddlunits5.DataSource = dunits5;
                //ddlunits5.DataTextField = "Units";
                //ddlunits5.DataValueField = "UOM_ID";
                //ddlunits5.DataBind();
                //ddlunits5.Items.Insert(0, "select");

                //DataSet dtax = objbs.SelectTax();
                //ddTax.DataSource = dtax;
                //ddTax.DataTextField = "Tax";
                //ddTax.DataValueField = "TaxID";
                //ddTax.DataBind();
                //ddTax.Items.Insert(0, "select");


                //DataSet dtax1 = objbs.SelectTax();
                //ddTax1.DataSource = dtax1;
                //ddTax1.DataTextField = "Tax";
                //ddTax1.DataValueField = "TaxID";
                //ddTax1.DataBind();
                //ddTax1.Items.Insert(0, "select");

                //DataSet dtax2 = objbs.SelectTax();
                //ddTax2.DataSource = dtax2;
                //ddTax2.DataTextField = "Tax";
                //ddTax2.DataValueField = "TaxID";
                //ddTax2.DataBind();
                //ddTax2.Items.Insert(0, "select");

                //DataSet dtax3 = objbs.SelectTax();
                //ddTax3.DataSource = dtax3;
                //ddTax3.DataTextField = "Tax";
                //ddTax3.DataValueField = "TaxID";
                //ddTax3.DataBind();
                //ddTax3.Items.Insert(0, "select");

                //DataSet dtax4 = objbs.SelectTax();
                //ddTax4.DataSource = dtax4;
                //ddTax4.DataTextField = "Tax";
                //ddTax4.DataValueField = "TaxID";
                //ddTax4.DataBind();
                //ddTax4.Items.Insert(0, "select");

                //DataSet dtax5 = objbs.SelectTax();
                //ddTax5.DataSource = dtax5;
                //ddTax5.DataTextField = "Tax";
                //ddTax5.DataValueField = "TaxID";
                //ddTax5.DataBind();
                //ddTax5.Items.Insert(0, "select");
                //grvPODetails.Visible = true;
                //gvEditPODet.Visible = false;
                //DataSet ds = objbs.pono();
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    // int iBillNo = ds.Tables[0].Rows[0]["billno"].ToString();
                //    if (ds.Tables[0].Rows[0]["pono"].ToString() == "")
                //        txtpono.Text = "1";
                //    else
                //        txtpono.Text = ds.Tables[0].Rows[0]["pono"].ToString();

                txtpodate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                txtDCDate.Text = DateTime.Today.ToString("dd/MM/yyyy");





                DataSet dsRegistration = objbs.selectregformdet(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]));
                //lblcompanyname.Text = dsRegistration.Tables[0].Rows[0]["CompanyName"].ToString();
                //lbltinno.Text = dsRegistration.Tables[0].Rows[0]["TinNo"].ToString();



                string iPo = Request.QueryString.Get("iPo");

                if (iPo != null)
                {
                    DataSet ds1 = objbs.GetPOUpdateQry(iPo);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                      
                    }

                }

            }
        }
        protected void ddlcustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCustDet = objbs.GetCustomerDetails(Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCustDet.Tables[0].Rows.Count > 0)
            {
                txtSupplied.Text = dsCustDet.Tables[0].Rows[0]["Address"].ToString() + "," + dsCustDet.Tables[0].Rows[0]["City"].ToString() + "," + dsCustDet.Tables[0].Rows[0]["Area"].ToString() + "," + dsCustDet.Tables[0].Rows[0]["Pincode"].ToString();

            }
        }
        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {

                ddldef.DataSource = dsCategory.Tables[0];
                ddldef.DataTextField = "Definition";
                ddldef.DataValueField = "categoryuserid";
                ddldef.DataBind();
                ddldef.Items.Insert(0, "Select Description");
                dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }
        }
        protected void ddlcategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory1 = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCategory1.Tables[0].Rows.Count > 0)
            {

                ddldef1.DataSource = dsCategory1.Tables[0];
                ddldef1.DataTextField = "Definition";
                ddldef1.DataValueField = "categoryuserid";
                ddldef1.DataBind();
                ddldef1.Items.Insert(0, "Select Description");
                dTax1 = Convert.ToDecimal(dsCategory1.Tables[0].Rows[0]["Tax"].ToString());
            }
        }
        protected void ddlcategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory2 = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCategory2.Tables[0].Rows.Count > 0)
            {

                ddldef2.DataSource = dsCategory2.Tables[0];
                ddldef2.DataTextField = "Definition";
                ddldef2.DataValueField = "categoryuserid";
                ddldef2.DataBind();
                ddldef2.Items.Insert(0, "Select Description");

                dTax2 = Convert.ToDecimal(dsCategory2.Tables[0].Rows[0]["Tax"].ToString());

            }
        }
        protected void ddlcategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory3 = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCategory3.Tables[0].Rows.Count > 0)
            {

                ddldef3.DataSource = dsCategory3.Tables[0];
                ddldef3.DataTextField = "Definition";
                ddldef3.DataValueField = "categoryuserid";
                ddldef3.DataBind();
                ddldef3.Items.Insert(0, "Select Description");

                dTax3 = Convert.ToDecimal(dsCategory3.Tables[0].Rows[0]["Tax"].ToString());
            }
        }

        protected void ddlcategory4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory4 = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCategory4.Tables[0].Rows.Count > 0)
            {

                ddldef4.DataSource = dsCategory4.Tables[0];
                ddldef4.DataTextField = "Definition";
                ddldef4.DataValueField = "categoryuserid";
                ddldef4.DataBind();
                ddldef4.Items.Insert(0, "Select Description");

                dTax4 = Convert.ToDecimal(dsCategory4.Tables[0].Rows[0]["Tax"].ToString());
            }
        }

        protected void ddlcategory5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory5 = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue));
            if (dsCategory5.Tables[0].Rows.Count > 0)
            {

                ddldef5.DataSource = dsCategory5.Tables[0];
                ddldef5.DataTextField = "Definition";
                ddldef5.DataValueField = "categoryuserid";
                ddldef5.DataBind();
                ddldef5.Items.Insert(0, "Select Description");

                dTax5 = Convert.ToDecimal(dsCategory5.Tables[0].Rows[0]["Tax"].ToString());
            }
        }
        protected void txtrate_TextChanged1(object sender, EventArgs e)
        {
            Decimal iNetAmount = ((Convert.ToDecimal(txtqty.Text)) * (Convert.ToDecimal(txtrate.Text)));
            txtamount.Text = string.Format("{0:N2}", iNetAmount);
            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue), Convert.ToInt32(ddldef.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                dTax = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }
            //dTaxAmt = (dTax / 100) * iNetAmount;
            Decimal damt = Convert.ToDecimal(dTax / 100) * Convert.ToDecimal(txtamount.Text);
            txtTamt.Text = Convert.ToString(damt);
            //txtTaxamt5.Text
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
           // decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
            //txtTaxamt5.Text =   Decimal.Round(dTaxAmt, 2).ToString("f2");
            GrossCalc();
        }
        protected void txtrate_TextChanged2(object sender, EventArgs e)
        {
            Decimal iNetAmount1 = ((Convert.ToDecimal(txtqty1.Text)) * (Convert.ToDecimal(txtrate1.Text)));
            txtamount1.Text = string.Format("{0:N2}", iNetAmount1);

            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue),Convert.ToInt32(ddldef1.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                dTax1 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }

            Decimal damt = Convert.ToDecimal(dTax1 / 100) * Convert.ToDecimal(txtamount1.Text);
            txtTamt1.Text = Convert.ToString(damt);
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
            //decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
           // decimal d1 =Convert.ToDecimal(txtTaxamt5.Text)+ dTotalTax1;
           // txtTaxamt5.Text = Decimal.Round(dTaxAmt1, 2).ToString("f2");
            GrossCalc();
        }
        protected void txtrate_TextChanged3(object sender, EventArgs e)
        {
            Decimal iNetAmount2 = ((Convert.ToDecimal(txtqty2.Text)) * (Convert.ToDecimal(txtrate2.Text)));
            txtamount2.Text = string.Format("{0:N2}", iNetAmount2);
            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue), Convert.ToInt32(ddldef.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                dTax2 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }

            Decimal damt = Convert.ToDecimal(dTax2 / 100) * Convert.ToDecimal(txtamount2.Text);
            txtTamt2.Text = Convert.ToString(damt);
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
            //decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
            decimal d2 = Convert.ToDecimal(txtTaxamt5.Text) +dTaxAmt2;
           // txtTaxamt5.Text = Decimal.Round(d2, 2).ToString("f2");
            GrossCalc();
        }
        protected void txtrate_TextChanged4(object sender, EventArgs e)
        {
            Decimal iNetAmount3 = ((Convert.ToDecimal(txtqty3.Text)) * (Convert.ToDecimal(txtrate3.Text)));
            txtamount3.Text = string.Format("{0:N2}", iNetAmount3);

            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                dTax3 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }

            Decimal damt = Convert.ToDecimal(dTax3 / 100) * Convert.ToDecimal(txtamount3.Text);
            txtTamt3.Text = Convert.ToString(damt);
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
            //decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
            decimal d3 = Convert.ToDecimal(txtTaxamt5.Text) + dTaxAmt3;
            txtTaxamt5.Text = Decimal.Round(d3, 2).ToString("f2");
            GrossCalc();
        }

        protected void txtrate_TextChanged5(object sender, EventArgs e)
        {
            Decimal iNetAmount4 = ((Convert.ToDecimal(txtqty4.Text)) * (Convert.ToDecimal(txtrate4.Text)));
            txtamount4.Text = string.Format("{0:N2}", iNetAmount4);

            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue));
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                dTax4 = Convert.ToDecimal(dsCategory.Tables[0].Rows[0]["Tax"].ToString());
            }

            Decimal damt = Convert.ToDecimal(dTax4 / 100) * Convert.ToDecimal(txtamount4.Text);
            txtTamt4.Text = Convert.ToString(damt);
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
           // decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
            decimal d4 = Convert.ToDecimal(txtTaxamt5.Text) + dTaxAmt4;
            txtTaxamt5.Text = Decimal.Round(d4, 2).ToString("f2");
            GrossCalc();
        }
        protected void txtrate_TextChanged6(object sender, EventArgs e)
        {
            Decimal iNetAmount5 = ((Convert.ToDecimal(txtqty5.Text)) * (Convert.ToDecimal(txtrate5.Text)));
            txtamount5.Text = string.Format("{0:N2}", iNetAmount5);

            DataSet dsCategory = objbs.selectcategorydecriptionforDealer(Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddlvendor.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue));
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
         
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
           // decimal DtotalTaxAmount = dTotalTax + dTotalTax1 + dTotalTax2 + dTotalTax3 + dTotalTax4 + dTotalTax5;
            txttotal.Text = Decimal.Round(iTotalAmount, 2).ToString("f2");
            decimal d5 = Convert.ToDecimal(txtTaxamt5.Text) + dTaxAmt5;
            txtTaxamt5.Text = Decimal.Round(d5, 2).ToString("f2");
            GrossCalc();
        }
        protected void btncalc_Click(object sender, EventArgs e)
        {
            decimal dTaxValue = Convert.ToDecimal(txtTamt.Text) + Convert.ToDecimal(txtTamt1.Text) + Convert.ToDecimal(txtTamt2.Text) + Convert.ToDecimal(txtTamt3.Text) + Convert.ToDecimal(txtTamt4.Text) + Convert.ToDecimal(txtTamt5.Text);
            txtTaxamt5.Text = decimal.Round( dTaxValue,2).ToString("f2");
            Decimal dGrandTotal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtdiscount.Text) + Convert.ToDecimal(txtTaxamt5.Text) + Convert.ToDecimal(txtTaxamt14.Text) + Convert.ToDecimal(txtCst.Text) + Convert.ToDecimal(txtExcisr.Text);
            txtgrandtotal.Text = decimal.Round(dGrandTotal,2).ToString("f2");
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
            Decimal iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5 + iGross6;
            txttotal.Text = Convert.ToString(iTotalAmount);
        }


        //protected void Add_Click(object sender, EventArgs e)
        //{
        //    int isucess = 0;
        //    int iSucess = 0;
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns.Add(new DataColumn("CatID", typeof(int)));
        //    dr = dt.NewRow();
        //    dr["CatID"] = ddldef.SelectedValue;
        //    dt.Rows.Add(dr);
        //    if (ddldef1.SelectedValue != "")
        //    {
        //        dr = dt.NewRow();
        //        dr["CatID"] = ddldef1.SelectedValue;
        //        dt.Rows.Add(dr);
        //    }
        //    if (ddldef2.SelectedValue != "")
        //    {
        //        dr = dt.NewRow();
        //        dr["CatID"] = ddldef2.SelectedValue;
        //        dt.Rows.Add(dr);
        //    }
        //    if (ddldef3.SelectedValue != "")
        //    {
        //        dr = dt.NewRow();
        //        dr["CatID"] = ddldef3.SelectedValue;
        //        dt.Rows.Add(dr);
        //    }
        //    if (ddldef4.SelectedValue != "")
        //    {
        //        dr = dt.NewRow();
        //        dr["CatID"] = ddldef4.SelectedValue;
        //        dt.Rows.Add(dr);
        //    }
        //    if (ddldef5.SelectedValue != "")
        //    {
        //        dr = dt.NewRow();
        //        dr["CatID"] = ddldef5.SelectedValue;
        //        dt.Rows.Add(dr);
        //    }
        //    DataTable ds = dt.DefaultView.ToTable(true, "CatID");//Columns.
        //    if (ds.Rows.Count != dt.Rows.Count)
        //        lblError.Text = "Same Description Exist";
        //    else
        //    {

        //        isucess = objbs.insertpurchase(Convert.ToInt32(ddlvendor.SelectedValue), Convert.ToInt32(txtDCNo.Text), txtDCDate.Text, txtpono.Text, txtpodate.Text, txttotal.Text, txtdiscount.Text, txtTaxamt5.Text, txtTaxamt14.Text, txtgrandtotal.Text, Convert.ToDouble(txtCst.Text), Convert.ToDouble(txtExcisr.Text));
        //        int iRtn = 0;
        //        //DataSet dPid = objbs.getpid();
        //        //string Ipid = (dPid.Tables[0].Rows[0]["P_ID"].ToString());

        //        DataSet dsStockDet = new DataSet();
        //        if (txtamount.Text != "")
        //        {
        //            //DataSet dsPurDet = objbs.GetTransExistPurchase(Convert.ToInt32(ddldef.SelectedValue));
        //            //if (dsPurDet.Tables[0].Rows.Count > 0)
        //            //{
        //            //    int iqty = Convert.ToInt32(dsPurDet.Tables[0].Rows[0]["Quantity"].ToString());
        //            //    int iAvlqty = Convert.ToInt32(dsPurDet.Tables[0].Rows[0]["Available_QTY"].ToString());
        //            //}
        //            objbs.inserttranspurchase(txtpono.Text, Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), txtqty.Text, txtrate.Text, Convert.ToInt32(0), Convert.ToInt32(txtdisc.Text), Convert.ToInt32(0), txtamount.Text);

        //            DataSet dQty = objbs.GetPurchaseStok(Convert.ToInt32(ddldef.SelectedValue),Convert.ToInt32(lblUserID.Text));
        //            if (dQty.Tables[0].Rows.Count > 0)
        //            {
        //                int iqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Quantity"].ToString());
        //                int iAvlqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Available_QTY"].ToString());

        //                decimal dExistPurRate = Convert.ToDecimal(dQty.Tables[0].Rows[0]["PurchaseRate"].ToString());
        //                decimal dCurrPurRate = Convert.ToDecimal(txtrate.Text);
        //                decimal dExistPurAmt = iAvlqty * dExistPurRate;

        //                int iTotalStock = iqty + Convert.ToInt32(txtqty.Text);
        //                int iAvlStock = iAvlqty + Convert.ToInt32(txtqty.Text);
        //                decimal dCurrPurAmt = Convert.ToInt32(txtqty.Text) * dCurrPurRate;

        //                decimal dTotPurRate = dExistPurAmt + dCurrPurAmt;
        //                decimal dFinal = dTotPurRate / iAvlStock;
        //                objbs.UpdatePurchaseStok(iTotalStock, iAvlStock, Convert.ToInt32(ddldef.SelectedValue), dFinal);
        //            }
        //            else
        //            {
        //                iRtn = objbs.InsertStock(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddldef.SelectedValue), Convert.ToInt32(txtqty.Text), Convert.ToDouble(0), Convert.ToInt32(txtqty.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtrate.Text),Convert.ToDateTime(0));
        //            }

        //        }
        //        if (txtamount1.Text != "")
        //        {
        //            objbs.inserttranspurchase(txtpono.Text, Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), txtqty1.Text, txtrate1.Text, 0, Convert.ToInt32(txtdisc1.Text), 0, txtamount1.Text);
        //            DataSet dQty = objbs.GetPurchaseStok(Convert.ToInt32(ddldef1.SelectedValue));
        //            if (dQty.Tables[0].Rows.Count > 0)
        //            {
        //                int iqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Quantity"].ToString());
        //                int iAvlqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Available_QTY"].ToString());
        //                int iTotalStock = iqty + Convert.ToInt32(txtqty1.Text);
        //                int iAvlStock = iAvlqty + Convert.ToInt32(txtqty1.Text);
        //                // objbs.UpdatePurchaseStok(iTotalStock, iAvlStock, Convert.ToInt32(ddldef1.SelectedValue));
        //            }

        //            else
        //            {
        //                iRtn = objbs.InsertStock(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]), Convert.ToInt32(ddlcategory1.SelectedValue), Convert.ToInt32(ddldef1.SelectedValue), Convert.ToInt32(txtqty1.Text), Convert.ToDouble(0), Convert.ToInt32(txtqty1.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtrate1.Text), Convert.ToDateTime(0));
        //            }

        //        }
        //        if (txtamount2.Text != "")
        //        {
        //            objbs.inserttranspurchase(txtpono.Text, Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), txtqty2.Text, txtrate2.Text, 0, Convert.ToInt32(txtdisc2.Text), 0, txtamount2.Text);
        //            DataSet dQty = objbs.GetPurchaseStok(Convert.ToInt32(ddldef2.SelectedValue));
        //            if (dQty.Tables[0].Rows.Count > 0)
        //            {
        //                int iqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Quantity"].ToString());
        //                int iAvlqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Available_QTY"].ToString());
        //                int iTotalStock = iqty + Convert.ToInt32(txtqty2.Text);
        //                int iAvlStock = iAvlqty + Convert.ToInt32(txtqty2.Text);
        //                // objbs.UpdatePurchaseStok(iTotalStock, iAvlStock, Convert.ToInt32(ddldef2.SelectedValue));
        //            }
        //            else
        //            {
        //                iRtn = objbs.InsertStock(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]), Convert.ToInt32(ddlcategory2.SelectedValue), Convert.ToInt32(ddldef2.SelectedValue), Convert.ToInt32(txtqty2.Text), Convert.ToDouble(0), Convert.ToInt32(txtqty2.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtrate2.Text), Convert.ToDateTime(0));
        //            }

        //        }
        //        if (txtamount3.Text != "")
        //        {
        //            objbs.inserttranspurchase(txtpono.Text, Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), txtqty3.Text, txtrate3.Text, 0, Convert.ToInt32(txtdisc3.Text), 0, txtamount3.Text);
        //            DataSet dQty = objbs.GetPurchaseStok(Convert.ToInt32(ddldef3.SelectedValue));
        //            if (dQty.Tables[0].Rows.Count > 0)
        //            {
        //                int iqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Quantity"].ToString());
        //                int iAvlqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Available_QTY"].ToString());
        //                int iTotalStock = iqty + Convert.ToInt32(txtqty3.Text);
        //                int iAvlStock = iAvlqty + Convert.ToInt32(txtqty3.Text);
        //                // objbs.UpdatePurchaseStok(iTotalStock, iAvlStock, Convert.ToInt32(ddldef3.SelectedValue));
        //            }
        //            else
        //            {
        //                iRtn = objbs.InsertStock(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]), Convert.ToInt32(ddlcategory3.SelectedValue), Convert.ToInt32(ddldef3.SelectedValue), Convert.ToInt32(txtqty3.Text), Convert.ToDouble(0), Convert.ToInt32(txtqty3.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtrate3.Text), Convert.ToDateTime(0));
        //            }

        //        }
        //        if (txtamount4.Text != "")
        //        {
        //            objbs.inserttranspurchase(txtpono.Text, Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), txtqty4.Text, txtrate4.Text, 0, Convert.ToInt32(txtdisc4.Text), 0, txtamount4.Text);
        //            DataSet dQty = objbs.GetPurchaseStok(Convert.ToInt32(ddldef4.SelectedValue));
        //            if (dQty.Tables[0].Rows.Count > 0)
        //            {
        //                int iqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Quantity"].ToString());
        //                int iAvlqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Available_QTY"].ToString());
        //                int iTotalStock = iqty + Convert.ToInt32(txtqty4.Text);
        //                int iAvlStock = iAvlqty + Convert.ToInt32(txtqty4.Text);
        //                // objbs.UpdatePurchaseStok(iTotalStock, iAvlStock, Convert.ToInt32(ddldef4.SelectedValue));
        //            }
        //            else
        //            {
        //                iRtn = objbs.InsertStock(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]), Convert.ToInt32(ddlcategory4.SelectedValue), Convert.ToInt32(ddldef4.SelectedValue), Convert.ToInt32(txtqty4.Text), Convert.ToDouble(0), Convert.ToInt32(txtqty4.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtrate4.Text), Convert.ToDateTime(0));
        //            }

        //        }
        //        if (txtamount5.Text != "")
        //        {
        //            objbs.inserttranspurchase(txtpono.Text, Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), txtqty5.Text, txtrate5.Text, 0, Convert.ToInt32(txtdisc5.Text), 0, txtamount5.Text);
        //            DataSet dQty = objbs.GetPurchaseStok(Convert.ToInt32(ddldef5.SelectedValue));
        //            if (dQty.Tables[0].Rows.Count > 0)
        //            {
        //                int iqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Quantity"].ToString());
        //                int iAvlqty = Convert.ToInt32(dQty.Tables[0].Rows[0]["Available_QTY"].ToString());
        //                int iTotalStock = iqty + Convert.ToInt32(txtqty5.Text);
        //                int iAvlStock = iAvlqty + Convert.ToInt32(txtqty5.Text);
        //                //objbs.UpdatePurchaseStok(iTotalStock, iAvlStock, Convert.ToInt32(ddldef5.SelectedValue));
        //            }
        //            else
        //            {
        //                iRtn = objbs.InsertStock(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"]), Convert.ToInt32(ddlcategory5.SelectedValue), Convert.ToInt32(ddldef5.SelectedValue), Convert.ToInt32(txtqty5.Text), Convert.ToDouble(0), Convert.ToInt32(txtqty5.Text), Convert.ToInt32(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtrate5.Text), Convert.ToDateTime(0));
        //            }

        //        }

        //        Response.Redirect("PurchaseEntryGrid.aspx");
        //    }
        //}

        protected void txtdisc_TextChanged(object sender, EventArgs e)
        {
            Decimal disc = Convert.ToDecimal(txtdisc.Text);
            Decimal damt = Convert.ToDecimal(disc / 100) * Convert.ToDecimal(txtamount.Text);
            txtdamt.Text = Convert.ToString(damt);
            GrossDiscount();
        }

        protected void ddtax_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal Dtax = Convert.ToDecimal(ddTax.SelectedItem.Text);
            Decimal damt = Convert.ToDecimal(Dtax / 100) * Convert.ToDecimal(txtamount.Text);
            txtTamt.Text = Convert.ToString(damt);
        }

        protected void txtdisc1_TextChanged(object sender, EventArgs e)
        {
            Decimal disc1 = Convert.ToDecimal(txtdisc1.Text);
            Decimal damt1 = Convert.ToDecimal(disc1 / 100) * Convert.ToDecimal(txtamount1.Text);
            txtdamt1.Text = Convert.ToString(damt1);
            GrossDiscount();
        }

        protected void ddTax1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal Dtax1 = Convert.ToDecimal(ddTax1.SelectedItem.Text);
            Decimal damt1 = Convert.ToDecimal(Dtax1 / 100) * Convert.ToDecimal(txtamount1.Text);
            txtTamt1.Text = Convert.ToString(damt1);
        }

        protected void txtdisc2_TextChanged(object sender, EventArgs e)
        {
            Decimal disc2 = Convert.ToDecimal(txtdisc2.Text);
            Decimal damt2 = Convert.ToDecimal(disc2 / 100) * Convert.ToDecimal(txtamount2.Text);
            txtdamt2.Text = Convert.ToString(damt2);
            GrossDiscount();
        }

        protected void ddTax2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal Dtax2 = Convert.ToDecimal(ddTax2.SelectedItem.Text);
            Decimal damt2 = Convert.ToDecimal(Dtax2 / 100) * Convert.ToDecimal(txtamount2.Text);
            txtTamt2.Text = Convert.ToString(damt2);
        }

        protected void txtdisc3_TextChanged(object sender, EventArgs e)
        {
            Decimal disc3 = Convert.ToDecimal(txtdisc3.Text);
            Decimal damt3 = Convert.ToDecimal(disc3 / 100) * Convert.ToDecimal(txtamount3.Text);
            txtdamt3.Text = Convert.ToString(damt3);
            GrossDiscount();
        }

        protected void ddTax3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal Dtax3 = Convert.ToDecimal(ddTax3.SelectedItem.Text);
            Decimal damt3 = Convert.ToDecimal(Dtax3 / 100) * Convert.ToDecimal(txtamount3.Text);
            txtTamt3.Text = Convert.ToString(damt3);
        }

        protected void txtdisc4_TextChanged(object sender, EventArgs e)
        {
            Decimal disc4 = Convert.ToDecimal(txtdisc4.Text);
            Decimal damt4 = Convert.ToDecimal(disc4 / 100) * Convert.ToDecimal(txtamount4.Text);
            txtdamt4.Text = Convert.ToString(damt4);
            GrossDiscount();
        }

        protected void ddTax4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal Dtax4 = Convert.ToDecimal(ddTax4.SelectedItem.Text);
            Decimal damt4 = Convert.ToDecimal(Dtax4 / 100) * Convert.ToDecimal(txtamount4.Text);
            txtTamt4.Text = Convert.ToString(damt4);
        }

        protected void txtdisc5_TextChanged(object sender, EventArgs e)
        {
            Decimal disc5 = Convert.ToDecimal(txtdisc5.Text);
            Decimal damt5 = Convert.ToDecimal(disc5 / 100) * Convert.ToDecimal(txtamount5.Text);
            txtdamt5.Text = Convert.ToString(damt5);
            GrossDiscount();
        }

        protected void ddTax5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Decimal Dtax5 = Convert.ToDecimal(ddTax5.SelectedItem.Text);
            Decimal damt5 = Convert.ToDecimal(Dtax5 / 100) * Convert.ToDecimal(txtamount5.Text);
            txtTamt5.Text = Convert.ToString(damt5);
        }

        private void GrossDiscount()
        {
            Decimal idiscount1 = 0; Decimal idiscount2 = 0; Decimal idiscount3 = 0; Decimal idiscount4 = 0; Decimal idiscount5 = 0; Decimal idiscount6 = 0;
            if (txtdamt.Text != "")
                idiscount1 = Convert.ToDecimal(txtdamt.Text);
            if (txtdamt1.Text != "")
                idiscount2 = Convert.ToDecimal(txtdamt1.Text);
            if (txtdamt2.Text != "")
                idiscount3 = Convert.ToDecimal(txtdamt2.Text);
            if (txtdamt3.Text != "")
                idiscount4 = Convert.ToDecimal(txtdamt3.Text);
            if (txtdamt4.Text != "")
                idiscount5 = Convert.ToDecimal(txtdamt4.Text);
            if (txtdamt5.Text != "")
                idiscount6 = Convert.ToDecimal(txtdamt5.Text);

            Decimal iDisctotal = idiscount1 + idiscount2 + idiscount3 + idiscount4 + idiscount5 + idiscount6;
            txtdiscount.Text = Decimal.Round(iDisctotal).ToString("f2");

        }

        protected void New_Click(object sender, EventArgs e)
        {
            string url = "itempage.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void ddldef_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dSerial = objbs.selectSerial(Convert.ToString( ddldef.SelectedItem));
            ddlSno.DataSource = dSerial.Tables[0];
            ddlSno.DataTextField = "Serial_No";
            ddlSno.DataBind();
        }

        protected void ddldef1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dSerial = objbs.selectSerial(Convert.ToString(ddldef1.SelectedItem));
            ddlSNo1.DataSource = dSerial.Tables[0];
            ddlSNo1.DataTextField = "Serial_No";
            ddlSNo1.DataBind();
        }

        protected void ddldef2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dSerial = objbs.selectSerial(Convert.ToString(ddldef2.SelectedItem));
            ddlSno2.DataSource = dSerial.Tables[0];
            ddlSno2.DataTextField = "Serial_No";
            ddlSno2.DataBind();
        }

        protected void ddldef3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dSerial = objbs.selectSerial(Convert.ToString(ddldef3.SelectedItem));
            ddlSno3.DataSource = dSerial.Tables[0];
            ddlSno3.DataTextField = "Serial_No";
            ddlSno3.DataBind();
        }

        protected void ddldef4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dSerial = objbs.selectSerial(Convert.ToString(ddldef4.SelectedItem));
            ddlSno4.DataSource = dSerial.Tables[0];
            ddlSno4.DataTextField = "Serial_No";
            ddlSno4.DataBind();
        }

        protected void ddldef5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dSerial = objbs.selectSerial(Convert.ToString(ddldef5.SelectedItem));
            ddlSno5.DataSource = dSerial.Tables[0];
            ddlSno5.DataTextField = "Serial_No";
            ddlSno5.DataBind();
        }

      
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory1.ClearSelection();
            ddldef1.SelectedItem.Text = "";
            txtqty1.Text = "";
            txtrate1.Text = "0";
            ddlSNo1.SelectedItem.Text = "";
            txtamount1.Text = "";
            txtTamt1.Text = "0";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory2.ClearSelection();
            ddldef2.SelectedItem.Text = "";
            txtqty2.Text = "";
            txtrate2.Text = "0";
            ddlSno2.SelectedItem.Text = "";
            txtamount2.Text = "";
            txtTamt2.Text = "0";
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory4.ClearSelection();
            ddldef4.SelectedItem.Text = "";
            txtqty4.Text = "";
            txtrate4.Text = "0";
            ddlSno4.SelectedItem.Text = "";
            txtamount4.Text = "";
            txtTamt4.Text = "0";
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory5.ClearSelection();
            ddldef5.SelectedItem.Text = "";
            txtqty5.Text = "";
            txtrate5.Text = "0";
            ddlSno5.SelectedItem.Text = "";
            txtamount5.Text = "";
            txtTamt5.Text = "0";
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ddlcategory3.ClearSelection();
            ddldef3.SelectedItem.Text = "";
            txtqty3.Text = "";
            txtrate3.Text = "0";
            ddlSno3.SelectedItem.Text = "";
            txtamount3.Text = "";
            txtTamt3.Text = "0";
        }
    }
}