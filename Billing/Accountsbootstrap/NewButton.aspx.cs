using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace Billing.Accountsbootstrap
{
    public partial class NewButton : System.Web.UI.Page
    {

        string Sort_Direction = "Sno DESC";

        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        string sTableName = "";
        BSClass objbs = new BSClass();
        private Button BtnServices;
        private Button btnItems;
        static int count = 0;
        int a;
        int[] iItemID = new int[5];
        decimal dTotal = 0;
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string Rate = "";
        string biller = "";
        decimal gstamt = 0;
        decimal subtotal = 0;
        string BranchID = "";

        string OnliOrder = "N";
        string MOnliOrder = "N";
        string fssaino = "Nil";
        string onllinepos = "N";

        string PrintOption = "Nil";
        string StockOption = "Nil";
        string Country = "Nil";

        string taxsetting = "";
        string ratesetting = "";
        string qtysetting = "";
        string currency = "";
        string possetting = "";
        string Billgenerate = "";
        string roundoffsetting = "";
        string Isprint = "Y";
        string Billerid = "0";



        protected void Page_Load(object sender, EventArgs e)
        {

            //Request.Cookies["userInfo"]

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            biller = Request.Cookies["userInfo"]["Biller"].ToString(); ;
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sStore = Request.Cookies["userInfo"]["Store"].ToString();
            sAddress = Request.Cookies["userInfo"]["Address"].ToString();
            sTin = Request.Cookies["userInfo"]["TIN"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();
            OnliOrder = Request.Cookies["userInfo"]["LOnlSale"].ToString();
            MOnliOrder = Request.Cookies["userInfo"]["MOnlSale"].ToString();
            fssaino = Request.Cookies["userInfo"]["fssaino"].ToString();
            onllinepos = Request.Cookies["userInfo"]["onlinepos"].ToString();
            Country = Request.Cookies["userInfo"]["Country"].ToString();
            Billerid = Request.Cookies["userInfo"]["Empid"].ToString(); ;

            PrintOption = Request.Cookies["userInfo"]["PrintOption"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();
            txtbillcode.Text = Request.Cookies["userInfo"]["BillCode"].ToString();


            taxsetting = Request.Cookies["userInfo"]["TaxSetting"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            currency = Request.Cookies["userInfo"]["Currency"].ToString();

            possetting = Request.Cookies["userInfo"]["possalessetting"].ToString();
            Billgenerate = Request.Cookies["userInfo"]["BillGenerateSetting"].ToString();
            roundoffsetting = Request.Cookies["userInfo"]["RoundoffSetting"].ToString();

            lblqtytype.Text = Request.Cookies["userInfo"]["QtyFillSetting"].ToString();
            lblattednercheck.Text = Request.Cookies["userInfo"]["Posattendercheck"].ToString();
            lblprintcount.Text = Request.Cookies["userInfo"]["posPrintsetting"].ToString();
            //if (Country != "India")
            //{
            //    IDCgst.Visible = false;
            //    lblcgst.Visible = false;
            //    IDSgst.Visible = false;
            //    lblsgst.Visible = false;

            //}


            //else
            //{
            //    IDCgst.Visible = true;
            //    lblcgst.Visible = true;
            //    IDSgst.Visible = true;
            //    lblsgst.Visible = true;
            //}

            if (taxsetting == "I")
            {
                IDCgst.Visible = true;
                lblcgst.Visible = true;
                IDSgst.Visible = true;
                lblsgst.Visible = true;
            }
            else if (taxsetting == "O")
            {
                IDCgst.Visible = false;
                lblcgst.Visible = false;
                IDSgst.Visible = false;
                lblsgst.Visible = false;
            }


            if (sTableName.ToString().ToLower() == "co6" || sTableName.ToString().ToLower() == "co7")
            {

            }

            else
            {
                trTax.Visible = false;
            }




            if (!IsPostBack)
            {
                lblcurrency.Text = currency;
                ViewState["SortExpr"] = Sort_Direction;

                DataSet dshold = objbs.TempCustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblTempSales_" + sTableName);
                if (dshold.Tables[0].Rows.Count > 0)
                {
                    Holdbill.DataSource = dshold;
                    Holdbill.DataBind();
                }
                else
                {
                    Holdbill.DataSource = null;
                    Holdbill.DataBind();
                }

                if (possetting == "S" || possetting == "S1")
                {
                    txtCusName1.Focus();
                    divdrop.Visible = false;
                    divscript.Visible = true;
                }
                else if (possetting == "D")
                {
                    txtmanualslno.Focus();
                    divdrop.Visible = true;
                    divscript.Visible = false;
                }



                if (dt.Columns.Count > 0)
                {
                    gvlist.DataSource = dt;
                    gvlist.DataBind();
                }
                else
                {
                    DataColumn col = new DataColumn("Sno", typeof(int));
                    dt.Columns.Add(col);
                    //dt.Columns.Add("Sno");
                    dt.Columns.Add("CategoryID");
                    dt.Columns.Add("CategoryUserID");
                    dt.Columns.Add("Stockid");
                    dt.Columns.Add("Definition");
                    dt.Columns.Add("Available_QTY");
                    dt.Columns.Add("TAX");
                    dt.Columns.Add("margin");
                    dt.Columns.Add("paygate");
                    dt.Columns.Add("margintax");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("Rate");
                    dt.Columns.Add("OriRate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("Disamt");
                    dt.Columns.Add("cattype");
                    dt.Columns.Add("combo");
                    dt.Columns.Add("ShwQty");
                    dt.Columns.Add("CQty");
                    dt.Columns.Add("HQty");
                    dt.Columns.Add("mrp");
                    dt.Columns.Add("mrpamount");
                    ViewState["dt"] = dt;
                    gvlist.DataSource = dt;
                    gvlist.DataBind();

                    //dtt.Columns.Add("CategoryID");
                    //dtt.Columns.Add("CategoryUserID");
                    //dtt.Columns.Add("Qty");
                    //dtt.Columns.Add("AQty");

                    //ViewState["dtt"] = dtt;
                    //gvlst.DataSource = dtt;
                    //gvlst.DataBind();
                }




                DataSet paymodeFinal = new DataSet();
                DataSet paymode = objbs.Paymodevalues(sTableName);


                if (paymode.Tables[0].Rows.Count > 0)
                {


                    DataSet paymode1 = objbs.Paymodevalues123(sTableName);
                    if (paymode1.Tables[0].Rows.Count > 0)
                    {
                        DataSet paymode2 = objbs.Paymodevalues1231(sTableName);

                        paymodeFinal.Merge(paymode);
                        paymodeFinal.Merge(paymode2);

                        drpPayment.DataSource = paymodeFinal.Tables[0];
                        drpPayment.DataTextField = "PayMode";
                        drpPayment.DataValueField = "Value";
                        drpPayment.DataBind();
                        //  drpPayment.Items.Insert(0, "Select");
                    }
                    else
                    {
                        drpPayment.DataSource = paymode.Tables[0];
                        drpPayment.DataTextField = "PayMode";
                        drpPayment.DataValueField = "Value";
                        drpPayment.DataBind();

                    }
                }

                DataSet getsalestype = objbs.GetSalesTypeForSales_pos(onllinepos);
                if (getsalestype.Tables[0].Rows.Count > 0)
                {
                    drpsalestype.DataSource = getsalestype.Tables[0];
                    drpsalestype.DataTextField = "PaymentType";
                    drpsalestype.DataValueField = "SalesTypeID";
                    drpsalestype.DataBind();
                }


                DataSet getallitembind = objbs.GetNewSelectDistinctItems("N", Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.DataSource = getallitembind.Tables[0];
                    drpitemsearch.DataTextField = "Definition";
                    drpitemsearch.DataValueField = "valuee";
                    drpitemsearch.DataBind();
                    drpitemsearch.Items.Insert(0, "Select Item");

                }

                DataSet getAttender = objbs.GetAttenderdisc(BranchID, lblNbilltype.Text);
                if (getAttender.Tables[0].Rows.Count > 0)
                {
                    drpattendername.DataSource = getAttender.Tables[0];
                    drpattendername.DataTextField = "AttenderName";
                    drpattendername.DataValueField = "AttenderID";
                    drpattendername.DataBind();
                    drpattendername.Items.Insert(0, "Select Attender");

                }
               else
                {
                    drpattendername.Items.Insert(0, "Select Attender");
                }

                DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                if (getAttenderdisc.Tables[0].Rows.Count > 0)
                {
                    attednertype.DataSource = getAttenderdisc.Tables[0];
                    attednertype.DataTextField = "AttenderName";
                    attednertype.DataValueField = "AttenderID";
                    attednertype.DataBind();
                    attednertype.Items.Insert(0, "Select Disc-Att");

                }
                else
                {
                    attednertype.Items.Insert(0, "Select Disc-Att");
                }


                DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
                if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
                {
                    // lblmaxdiscount.Text = getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"].ToString();
                    lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
                }

                drpsalestype_selectedindex(sender, e);

                txtDiscount.Enabled = false;

                if (lblisnormal.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill No Not Generated.Please Try Again Later!!!');", true);
                    return;
                }
                else
                {

                    DataSet ds = objbs.SalesBillno("tblSales_" + sTableName, lblisnormal.Text);
                    if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtBillNo.Text = "1";
                    else
                        txtBillNo.Text = ds.Tables[0].Rows[0]["billno"].ToString();


                    DataSet dss = objbs.dailybillseries("tblSales_" + sTableName, "BillDate");
                    if (dss.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtdailybillno.Text = "1";
                    else
                        txtdailybillno.Text = dss.Tables[0].Rows[0]["billno"].ToString();

                    txtfullbillno.Text = txtbillcode.Text + '-' + txtdailybillno.Text;

                    if (Billgenerate == "1")
                    {
                        txtBillNo.Visible = false;
                        txtfullbillno.Visible = true;

                    }
                    else if (Billgenerate == "2")
                    {
                        txtBillNo.Visible = true;
                        txtfullbillno.Visible = false;
                    }

                }
                txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                DataSet dCat1 = objbs.SalesCategory();
                GridView1.DataSource = dCat1;
                GridView1.DataBind();
                DataSet waiter = objbs.Waite(sTableName);
                DataSet Cash = objbs.Cashier(sTableName);
                if (waiter.Tables[0].Rows.Count > 0)
                {
                    ddattender.DataTextField = "Name";
                    ddattender.DataValueField = "code";
                    ddattender.DataSource = waiter.Tables[0];
                    ddattender.DataBind();
                    ddattender.Items.Insert(0, "Select");
                }

                if (Cash.Tables[0].Rows.Count > 0)
                {
                    ddlCashier.DataTextField = "Name";
                    ddlCashier.DataValueField = "code";
                    ddlCashier.DataSource = Cash.Tables[0];
                    ddlCashier.DataBind();
                    ddlCashier.Items.Insert(0, "Select");
                }

                Session["Icount"] = 1;
                tr.Visible = false;
                tr1.Visible = false;
                tr2.Visible = false;
                tr3.Visible = false;
                tr4.Visible = false;
                tr5.Visible = false;
                tr6.Visible = false;
                tr7.Visible = false;
                tr8.Visible = false;
                tr9.Visible = false;
                tr10.Visible = false;
                tr11.Visible = false;
                tr12.Visible = false;
                tr13.Visible = false;
                tr14.Visible = false;
                tblBill.Visible = false;
                if (sTableName.ToString().ToLower() == "co6" || sTableName.ToString().ToLower() == "co7")
                {
                    trTax.Visible = false;
                }

                else
                {
                    trTax.Visible = false;
                }
                string[] user = lblUser.Text.Split('@');
                string Branch = user[0];
                for (int i = 0; i < drpPayment.Items.Count; i++)
                {
                    if (drpPayment.Items[i].Text.ToLower().Contains(Branch))
                    {
                        drpPayment.Items[i].Enabled = false;
                        break;
                    }
                }

                txtbilled.Text = biller;

                if (lblUserID.Text == "17" || lblUserID.Text == "19")
                {
                    for (int i = 0; i < drpPayment.Items.Count; i++)
                    {
                        if (drpPayment.Items[i].Text.Contains("BBKulam"))
                        {
                            drpPayment.Items[i].Enabled = false;

                        }
                        if (drpPayment.Items[i].Text.Contains("ByePass"))
                        {
                            drpPayment.Items[i].Enabled = false;

                        }
                        if (drpPayment.Items[i].Text.Contains("NP"))
                        {
                            drpPayment.Items[i].Enabled = false;

                        }
                        if (drpPayment.Items[i].Text.Contains("KKNagar"))
                        {
                            drpPayment.Items[i].Enabled = false;

                        }
                    }
                }

                if (Session["SubID"] != null)
                {
                    //DataSet dCat = objbs.SelectItems(Convert.ToInt16(Session["SubID"].ToString()), Convert.ToInt32(lblUserID.Text), sTableName);

                    //int icount = dCat.Tables[0].Rows.Count;
                    //GridView2.DataSource = dCat;
                    //GridView2.DataBind();
                    //int icount = dCat.Tables[0].Rows.Count;

                    //for (int i = 0; i < icount; i++)
                    //{
                    //    string sName = dCat.Tables[0].Rows[i]["Definition"].ToString();
                    //    string id = dCat.Tables[0].Rows[i]["Categoryuserid"].ToString();
                    //    BtnServices = new Button();
                    //    BtnServices.ID = id;
                    //    BtnServices.Text = sName;
                    //    BtnServices.BackColor = System.Drawing.Color.Yellow;
                    //    BtnServices.ForeColor = System.Drawing.Color.Black;
                    //    BtnServices.Click += new EventHandler(BtnServices_Click1);
                    //    //   BtnServices.Command += new CommandEventHandler(BtnServices_Command);
                    //    td1.Controls.Add(BtnServices);


                    //}
                }
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }


        protected void item_search(object sender, EventArgs e)
        {

            if (drpitemsearch.SelectedValue == "Select Item")
            {
                drpitemsearch.Focus();
            }
            else
            {
                txtmanualqty.Focus();
            }

        }

        protected void barchnaged_text(object sender, EventArgs e)
        {
            string str = txtbrcode.Text;
            string b1 = str.Substring(0, 2);
            string b2 = str.Substring(2, 6);
            string b3 = str.Substring(9, 4);
            string b4 = str.Substring(8, 1);

            if (b1 == "#w" || b1 == "#W")
            {
                DataSet getallitembind = objbs.GetNewSelectDistinctItems_barcode("N", Convert.ToInt32(lblUserID.Text), sTableName, b2);
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.SelectedValue = getallitembind.Tables[0].Rows[0]["valuee"].ToString();
                    string qty = b4 + '.' + b3;
                    txtmanualqty.Text = qty.ToString();
                    Qty_chnaged(sender, e);
                }
                else
                {
                    txtbrcode.Focus();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Scan Valid Barcode Item not exists.Thank You!!!');", true);
                    return;
                }
            }
            else
            {
                DataSet getallitembind = objbs.GetNewSelectDistinctItems_barcode("N", Convert.ToInt32(lblUserID.Text), sTableName, txtbrcode.Text);
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.SelectedValue = getallitembind.Tables[0].Rows[0]["valuee"].ToString();
                    txtmanualqty.Focus();

                }
                else
                {
                    txtbrcode.Focus();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Scan Valid Barcode Item not exists.Thank You!!!');", true);
                    return;
                }
            }
        }

        void BtnServices_Click1(object sender, EventArgs e)
        {
            Response.Write("hi");
            Button Button = sender as Button;
            DataSet dsCategory = objbs.SelectItems(Convert.ToInt32(Button.ID), Convert.ToInt32(lblUserID.Text), sTableName);


        }


        private void GSTVal()
        {
            double tgsttax = 0;
            double tgsttaxamt = 0;
            // lblGrandTotal
            //////if (txtDiscount.Text == "0" || txtDiscount.Text == "")
            //////{

            //////}
            //////else
            {

                double gsttax = (((Convert.ToDouble(lblGrandTotal.Text)) * (Convert.ToDouble(9))) / 100);
                tgsttax = tgsttax + gsttax;

                double gsttaxamt = Convert.ToDouble(gsttax) + Convert.ToDouble(lblGrandTotal.Text);
                tgsttaxamt = tgsttaxamt + gsttaxamt;

                //double Discount1 = Convert.ToDouble(DiscountAmount) * Convert.ToDouble(txtTax.Text) / 100;
                //gtax5p = gtax5p + Discount1;
                //double DiscountAmount2 = Convert.ToDouble(DiscountAmount) + Discount1;
                //amttax5p = amttax5p + DiscountAmount2;

                //double iNetAmount = ((Convert.ToDouble(lblGrandTotal.Text)) * (Convert.ToDouble(txtRate.Text)));
                //double Discount = Convert.ToDouble(iNetAmount) * Convert.ToDouble(txtdiscount.Text) / 100;
                //double DiscountAmount = Convert.ToDouble(iNetAmount) - Discount;

                //double Discount1 = Convert.ToDouble(DiscountAmount) * Convert.ToDouble(txtTax.Text) / 100;
                //gtax5p = gtax5p + Discount1;
                //double DiscountAmount2 = Convert.ToDouble(DiscountAmount) + Discount1;
                //amttax5p = amttax5p + DiscountAmount2;

            }

            lblcgst.Text = tgsttax.ToString("" + ratesetting + "");
            lblsgst.Text = tgsttax.ToString("" + ratesetting + "");
            lblsubttl.Text = tgsttaxamt.ToString("" + ratesetting + "");
        }




        private void GSTValGrand()
        {
            if (lblAmount1.Text == "")
                lblAmount1.Text = "0";
            if (lblAmount2.Text == "")
                lblAmount2.Text = "0";
            if (lblAmount3.Text == "")
                lblAmount3.Text = "0";
            if (lblAmount4.Text == "")
                lblAmount4.Text = "0";
            if (lblAmount5.Text == "")
                lblAmount5.Text = "0";
            if (lblAmount6.Text == "")
                lblAmount6.Text = "0";
            if (lblAmount7.Text == "")
                lblAmount7.Text = "0";
            if (lblAmount8.Text == "")
                lblAmount8.Text = "0";
            if (lblAmount9.Text == "")
                lblAmount9.Text = "0";
            if (lblAmount10.Text == "")
                lblAmount10.Text = "0";
            if (lblAmount11.Text == "")
                lblAmount11.Text = "0";
            if (lblAmount12.Text == "")
                lblAmount12.Text = "0";
            if (lblAmount13.Text == "")
                lblAmount13.Text = "0";
            if (lblAmount14.Text == "")
                lblAmount14.Text = "0";
            if (lblAmount15.Text == "")
                lblAmount15.Text = "0";


            if (txtQty1.Text == "")
                txtQty1.Text = "0";
            if (txtQty2.Text == "")
                txtQty2.Text = "0";
            if (txtQty3.Text == "")
                txtQty3.Text = "0";
            if (txtQty4.Text == "")
                txtQty4.Text = "0";
            if (txtQty5.Text == "")
                txtQty5.Text = "0";
            if (txtQty6.Text == "")
                txtQty6.Text = "0";
            if (txtQty7.Text == "")
                txtQty7.Text = "0";
            if (txtQty8.Text == "")
                txtQty8.Text = "0";
            if (txtQty9.Text == "")
                txtQty9.Text = "0";
            if (txtQty10.Text == "")
                txtQty10.Text = "0";
            if (txtQty11.Text == "")
                txtQty11.Text = "0";
            if (txtQty12.Text == "")
                txtQty12.Text = "0";
            if (txtQty13.Text == "")
                txtQty13.Text = "0";
            if (txtQty14.Text == "")
                txtQty14.Text = "0";
            if (txtQty15.Text == "")
                txtQty15.Text = "0";

            if (lblRate1.Text == "")
                lblRate1.Text = "0";
            if (lblRate2.Text == "")
                lblRate2.Text = "0";
            if (lblRate3.Text == "")
                lblRate3.Text = "0";
            if (lblRate4.Text == "")
                lblRate4.Text = "0";
            if (lblRate5.Text == "")
                lblRate5.Text = "0";
            if (lblRate6.Text == "")
                lblRate6.Text = "0";
            if (lblRate7.Text == "")
                lblRate7.Text = "0";
            if (lblRate8.Text == "")
                lblRate8.Text = "0";
            if (lblRate9.Text == "")
                lblRate9.Text = "0";
            if (lblRate10.Text == "")
                lblRate10.Text = "0";
            if (lblRate11.Text == "")
                lblRate11.Text = "0";
            if (lblRate12.Text == "")
                lblRate12.Text = "0";
            if (lblRate13.Text == "")
                lblRate13.Text = "0";
            if (lblRate14.Text == "")
                lblRate14.Text = "0";
            if (lblRate15.Text == "")
                lblRate15.Text = "0";


            if (lbltaxam1.Text == "")
                lbltaxam1.Text = "0";
            if (lbltaxam2.Text == "")
                lbltaxam2.Text = "0";
            if (lbltaxam3.Text == "")
                lbltaxam3.Text = "0";
            if (lbltaxam4.Text == "")
                lbltaxam4.Text = "0";
            if (lbltaxam5.Text == "")
                lbltaxam5.Text = "0";
            if (lbltaxam6.Text == "")
                lbltaxam6.Text = "0";
            if (lbltaxam7.Text == "")
                lbltaxam7.Text = "0";
            if (lbltaxam8.Text == "")
                lbltaxam8.Text = "0";
            if (lbltaxam9.Text == "")
                lbltaxam9.Text = "0";
            if (lbltaxam10.Text == "")
                lbltaxam10.Text = "0";
            if (lbltaxam11.Text == "")
                lbltaxam11.Text = "0";
            if (lbltaxam12.Text == "")
                lbltaxam12.Text = "0";
            if (lbltaxam13.Text == "")
                lbltaxam13.Text = "0";
            if (lbltaxam14.Text == "")
                lbltaxam14.Text = "0";
            if (lbltaxam15.Text == "")
                lbltaxam15.Text = "0";


            decimal ngst1 = Convert.ToDecimal(txtQty1.Text) * Convert.ToDecimal(lblRate1.Text);
            decimal gsthaf1 = Convert.ToDecimal(lbltaxam1.Text) / 2;
            decimal ngstamount1 = (Convert.ToDecimal(ngst1) * Convert.ToDecimal(gsthaf1)) / 100;
            decimal dTotal1 = ngstamount1 + ngstamount1 + ngst1;
            decimal gstamt1 = ngstamount1 + ngstamount1;

            decimal ngst2 = Convert.ToDecimal(txtQty2.Text) * Convert.ToDecimal(lblRate2.Text);
            decimal gsthaf2 = Convert.ToDecimal(lbltaxam2.Text) / 2;
            decimal ngstamount2 = (Convert.ToDecimal(ngst2) * Convert.ToDecimal(gsthaf2)) / 100;
            decimal dTotal2 = ngstamount2 + ngstamount2 + ngst2;
            decimal gstamt2 = ngstamount2 + ngstamount2;

            decimal ngst3 = Convert.ToDecimal(txtQty3.Text) * Convert.ToDecimal(lblRate3.Text);
            decimal gsthaf3 = Convert.ToDecimal(lbltaxam3.Text) / 2;
            decimal ngstamount3 = (Convert.ToDecimal(ngst3) * Convert.ToDecimal(gsthaf3)) / 100;
            decimal dTotal3 = ngstamount3 + ngstamount3 + ngst3;
            decimal gstamt3 = ngstamount3 + ngstamount3;

            decimal ngst4 = Convert.ToDecimal(txtQty4.Text) * Convert.ToDecimal(lblRate4.Text);
            decimal gsthaf4 = Convert.ToDecimal(lbltaxam4.Text) / 2;
            decimal ngstamount4 = (Convert.ToDecimal(ngst4) * Convert.ToDecimal(gsthaf4)) / 100;
            decimal dTotal4 = ngstamount4 + ngstamount4 + ngst4;
            decimal gstamt4 = ngstamount4 + ngstamount4;

            decimal ngst5 = Convert.ToDecimal(txtQty5.Text) * Convert.ToDecimal(lblRate5.Text);
            decimal gsthaf5 = Convert.ToDecimal(lbltaxam5.Text) / 2;
            decimal ngstamount5 = (Convert.ToDecimal(ngst5) * Convert.ToDecimal(gsthaf5)) / 100;
            decimal dTotal5 = ngstamount5 + ngstamount5 + ngst5;
            decimal gstamt5 = ngstamount5 + ngstamount5;

            decimal ngst6 = Convert.ToDecimal(txtQty6.Text) * Convert.ToDecimal(lblRate6.Text);
            decimal gsthaf6 = Convert.ToDecimal(lbltaxam6.Text) / 2;
            decimal ngstamount6 = (Convert.ToDecimal(ngst6) * Convert.ToDecimal(gsthaf6)) / 100;
            decimal dTotal6 = ngstamount6 + ngstamount6 + ngst6;
            decimal gstamt6 = ngstamount6 + ngstamount6;

            decimal ngst7 = Convert.ToDecimal(txtQty7.Text) * Convert.ToDecimal(lblRate7.Text);
            decimal gsthaf7 = Convert.ToDecimal(lbltaxam7.Text) / 2;
            decimal ngstamount7 = (Convert.ToDecimal(ngst7) * Convert.ToDecimal(gsthaf7)) / 100;
            decimal dTotal7 = ngstamount7 + ngstamount7 + ngst7;
            decimal gstamt7 = ngstamount7 + ngstamount7;

            decimal ngst8 = Convert.ToDecimal(txtQty8.Text) * Convert.ToDecimal(lblRate8.Text);
            decimal gsthaf8 = Convert.ToDecimal(lbltaxam8.Text) / 2;
            decimal ngstamount8 = (Convert.ToDecimal(ngst8) * Convert.ToDecimal(gsthaf8)) / 100;
            decimal dTotal8 = ngstamount8 + ngstamount8 + ngst8;
            decimal gstamt8 = ngstamount8 + ngstamount8;

            decimal ngst9 = Convert.ToDecimal(txtQty9.Text) * Convert.ToDecimal(lblRate9.Text);
            decimal gsthaf9 = Convert.ToDecimal(lbltaxam9.Text) / 2;
            decimal ngstamount9 = (Convert.ToDecimal(ngst9) * Convert.ToDecimal(gsthaf9)) / 100;
            decimal dTotal9 = ngstamount9 + ngstamount9 + ngst9;
            decimal gstamt9 = ngstamount9 + ngstamount9;

            decimal ngst10 = Convert.ToDecimal(txtQty10.Text) * Convert.ToDecimal(lblRate10.Text);
            decimal gsthaf10 = Convert.ToDecimal(lbltaxam10.Text) / 2;
            decimal ngstamount10 = (Convert.ToDecimal(ngst10) * Convert.ToDecimal(gsthaf10)) / 100;
            decimal dTotal10 = ngstamount10 + ngstamount10 + ngst10;
            decimal gstamt10 = ngstamount10 + ngstamount10;

            decimal ngst11 = Convert.ToDecimal(txtQty11.Text) * Convert.ToDecimal(lblRate11.Text);
            decimal gsthaf11 = Convert.ToDecimal(lbltaxam11.Text) / 2;
            decimal ngstamount11 = (Convert.ToDecimal(ngst11) * Convert.ToDecimal(gsthaf11)) / 100;
            decimal dTotal11 = ngstamount11 + ngstamount11 + ngst11;
            decimal gstamt11 = ngstamount11 + ngstamount11;

            decimal ngst12 = Convert.ToDecimal(txtQty12.Text) * Convert.ToDecimal(lblRate12.Text);
            decimal gsthaf12 = Convert.ToDecimal(lbltaxam12.Text) / 2;
            decimal ngstamount12 = (Convert.ToDecimal(ngst12) * Convert.ToDecimal(gsthaf12)) / 100;
            decimal dTotal12 = ngstamount12 + ngstamount12 + ngst12;
            decimal gstamt12 = ngstamount12 + ngstamount12;

            decimal ngst13 = Convert.ToDecimal(txtQty13.Text) * Convert.ToDecimal(lblRate13.Text);
            decimal gsthaf13 = Convert.ToDecimal(lbltaxam13.Text) / 2;
            decimal ngstamount13 = (Convert.ToDecimal(ngst13) * Convert.ToDecimal(gsthaf13)) / 100;
            decimal dTotal13 = ngstamount13 + ngstamount13 + ngst13;
            decimal gstamt13 = ngstamount13 + ngstamount13;

            decimal ngst14 = Convert.ToDecimal(txtQty14.Text) * Convert.ToDecimal(lblRate14.Text);
            decimal gsthaf14 = Convert.ToDecimal(lbltaxam14.Text) / 2;
            decimal ngstamount14 = (Convert.ToDecimal(ngst14) * Convert.ToDecimal(gsthaf14)) / 100;
            decimal dTotal14 = ngstamount14 + ngstamount14 + ngst14;
            decimal gstamt14 = ngstamount14 + ngstamount14;

            decimal ngst15 = Convert.ToDecimal(txtQty15.Text) * Convert.ToDecimal(lblRate15.Text);
            decimal gsthaf15 = Convert.ToDecimal(lbltaxam15.Text) / 2;
            decimal ngstamount15 = (Convert.ToDecimal(ngst15) * Convert.ToDecimal(gsthaf15)) / 100;
            decimal dTotal15 = ngstamount15 + ngstamount15 + ngst15;
            decimal gstamt15 = ngstamount15 + ngstamount15;

            decimal cgsttotal = Convert.ToDecimal(ngstamount1) + Convert.ToDecimal(ngstamount2) + Convert.ToDecimal(ngstamount3) + Convert.ToDecimal(ngstamount4) + Convert.ToDecimal(ngstamount5) + Convert.ToDecimal(ngstamount6) + Convert.ToDecimal(ngstamount7) + Convert.ToDecimal(ngstamount8) + Convert.ToDecimal(ngstamount9) + Convert.ToDecimal(ngstamount10) + Convert.ToDecimal(ngstamount11) + Convert.ToDecimal(ngstamount12) + Convert.ToDecimal(ngstamount13) + Convert.ToDecimal(ngstamount14) + Convert.ToDecimal(ngstamount15);

            decimal Sgsttotal = Convert.ToDecimal(ngstamount1) + Convert.ToDecimal(ngstamount2) + Convert.ToDecimal(ngstamount3) + Convert.ToDecimal(ngstamount4) + Convert.ToDecimal(ngstamount5) + Convert.ToDecimal(ngstamount6) + Convert.ToDecimal(ngstamount7) + Convert.ToDecimal(ngstamount8) + Convert.ToDecimal(ngstamount9) + Convert.ToDecimal(ngstamount10) + Convert.ToDecimal(ngstamount11) + Convert.ToDecimal(ngstamount12) + Convert.ToDecimal(ngstamount13) + Convert.ToDecimal(ngstamount14) + Convert.ToDecimal(ngstamount15);

            decimal sstortal = Convert.ToDecimal(dTotal1) + Convert.ToDecimal(dTotal2) + Convert.ToDecimal(dTotal3) + Convert.ToDecimal(dTotal4) + Convert.ToDecimal(dTotal5) + Convert.ToDecimal(dTotal6) + Convert.ToDecimal(dTotal7) + Convert.ToDecimal(dTotal8) + Convert.ToDecimal(dTotal9) + Convert.ToDecimal(dTotal10) + Convert.ToDecimal(dTotal11) + Convert.ToDecimal(dTotal12) + Convert.ToDecimal(dTotal13) + Convert.ToDecimal(dTotal14) + Convert.ToDecimal(dTotal15);

            lblcgst.Text = cgsttotal.ToString("" + ratesetting + "");
            lblsgst.Text = Sgsttotal.ToString("" + ratesetting + "");
            lblsubttl.Text = (sstortal).ToString("" + ratesetting + "");

            decimal dTotal1old = Convert.ToDecimal(lblAmount1.Text) + Convert.ToDecimal(lblAmount2.Text) + Convert.ToDecimal(lblAmount3.Text) + Convert.ToDecimal(lblAmount4.Text) + Convert.ToDecimal(lblAmount5.Text) + Convert.ToDecimal(lblAmount6.Text) + Convert.ToDecimal(lblAmount7.Text) + Convert.ToDecimal(lblAmount8.Text) + Convert.ToDecimal(lblAmount9.Text) + Convert.ToDecimal(lblAmount10.Text) + Convert.ToDecimal(lblAmount11.Text) + Convert.ToDecimal(lblAmount12.Text) + Convert.ToDecimal(lblAmount13.Text) + Convert.ToDecimal(lblAmount14.Text) + Convert.ToDecimal(lblAmount15.Text);
            lbltotal.Text = dTotal1old.ToString("" + ratesetting + "");

            lblGrandTotal.Text = (sstortal).ToString("" + ratesetting + "");
            lbldisplay.InnerText = (sstortal).ToString("" + ratesetting + "");
            decimal dis = 0;
            if (txtDiscount.Text != "0" || txtDiscount.Text != "")
            {
                dis = ((Convert.ToDecimal(lbltotal.Text) * Convert.ToDecimal(txtDiscount.Text)) / 100);
            }

            lblGrandTotal.Text = (sstortal - dis).ToString("" + ratesetting + "");
            lbldisplay.InnerText = (sstortal - dis).ToString("" + ratesetting + "");
        }

        protected void Qty_chnaged(object sender, EventArgs e)
        {
            if (possetting == "D")
            {

                #region

                if (drpitemsearch.SelectedValue == "Select Item")
                {
                    drpitemsearch.Focus();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Item.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                else
                {
                    if (txtmanualqty.Text == "0" || txtmanualqty.Text == "")
                    {
                        txtmanualqty.Focus();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Qty.Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }
                    else
                    {
                        UpdatePanel3.Update();
                        decimal Shwqty = 0;
                        int comboo = 0;
                        decimal Qty = 0;
                        decimal HQty = 0;
                        decimal GST = 0;
                        decimal iQty = 0;
                        decimal SQty = 0;
                        string sItem = "";
                        decimal dCalTotal = 0;
                        decimal dRate = 0, dAmount = 0, dAvlQty = 0;
                        int iSubCatID = 0;
                        int CatID = 0;
                        int stockID = 0;
                        string sTempSession = "";
                        decimal mrpamnt = 0;

                        string margin = "0";
                        string margingst = "0";
                        string paymsntgateway = "0";

                        tblBill.Visible = true;
                        dt = (DataTable)ViewState["dt"];
                        //dtt = (DataTable)ViewState["dtt"];
                        DataSet dCat = new DataSet();
                        //  Button btn = (Button)sender;

                        string[] commandArgs = drpitemsearch.SelectedValue.Split(new char[] { ',' });
                        string categoryuserid = commandArgs[0];
                        string cattype = commandArgs[1];


                        // dCat = objbs.GetStockDetails(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName);
                        if (cattype == "N")
                        {
                            dCat = objbs.GetStockDetails(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                        }
                        else if (cattype == "C")
                        {
                            dCat = objbs.GetStockDetailscombo(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                        }

                        if (dCat.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                            {

                                sItem = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                comboo = Convert.ToInt32(dCat.Tables[0].Rows[i]["comboo"]);
                                dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate"].ToString());
                                CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                                iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString());
                                stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryUserid"].ToString());
                                dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                                GST = Convert.ToDecimal(dCat.Tables[0].Rows[i]["GST"].ToString());
                                Shwqty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["QTY"].ToString());
                                mrpamnt = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate1"]);
                                DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[0]["Expirydate"].ToString());
                                if (lblisinclusiverate.Text == "Y")
                                {
                                    DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "' AND combo='" + comboo + "'");
                                    if (rows.Length > 0)
                                    {



                                        decimal Dtax = (dRate * GST) / 100;

                                        decimal drateee = dRate + Dtax;

                                        decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                                        decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                                        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                        {
                                            Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                            HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                            Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        }
                                        if ((dAvlQty + HQty) >= Qty)
                                        {
                                            rows[0]["Qty"] = Qty.ToString();


                                            decimal amt = Convert.ToDecimal(Qty) * DRATE;
                                            decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                            rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                            rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                        }
                                        // rows[0]["RecQty"] = recQty.ToString();
                                    }
                                    else
                                    {
                                        Qty = 0; int totcnt = 0;
                                        int countt = dt.Rows.Count;
                                        totcnt = countt + 1;
                                        DataRow dr = dt.NewRow();
                                        //Qty = Qty + 1;
                                        Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        decimal amt = 0;
                                        decimal mrpamt = 0;

                                        decimal Dtax = (dRate * GST) / 100;

                                        decimal drateee = dRate + Dtax;

                                        decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                                        decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                                        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                        dr["Sno"] = totcnt;
                                        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                        dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                        dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                        dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                        dr["Qty"] = Convert.ToDecimal(Qty).ToString();//Qty.ToString("0");
                                        dr["Rate"] = Convert.ToDecimal(DRATE).ToString("" + ratesetting + "");
                                        dr["Tax"] = Convert.ToDecimal(0);
                                        //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);

                                        {
                                            amt = Convert.ToDecimal(Qty) * DRATE;
                                            mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                        }
                                        dr["Amount"] = amt.ToString("" + ratesetting + "");
                                        dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                        dr["mrp"] = Convert.ToDouble(dCat.Tables[0].Rows[i]["Rate1"]).ToString("" + ratesetting + "");
                                        //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                                        // dr["RecQty"] = Reqty.ToString();
                                        dr["Orirate"] = dRate.ToString();
                                        if (dAvlQty >= Qty)
                                        {

                                            dt.Rows.Add(dr);
                                        }

                                        ViewState["dt"] = dt;
                                        txtmanualslno.Text = (totcnt + 1).ToString();
                                    }
                                }
                                else
                                {




                                    decimal Sqtyy = 0;

                                    {

                                        DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'  AND combo='" + comboo + "'");
                                        if (rows.Length > 0)
                                        {

                                            {
                                                Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                                HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                                Sqtyy = Convert.ToDecimal(rows[0]["ShwQty"].ToString());
                                                if (cattype == "N")
                                                {
                                                    //  Qty = Qty + 1;
                                                    Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                    Sqtyy = Sqtyy + Shwqty;
                                                }
                                                else if (cattype == "C")
                                                {
                                                    //Qty = Qty + 1;
                                                    Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                    Sqtyy = Sqtyy + Shwqty;
                                                }
                                            }
                                            if (StockOption == "1")
                                            {
                                                if ((dAvlQty + HQty) >= Qty)
                                                {
                                                    rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                                    rows[0]["ShwQty"] = Sqtyy.ToString("" + qtysetting + "");
                                                    decimal amt = Convert.ToDecimal(Qty) * dRate;

                                                    rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                                    decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                                    rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                                }
                                            }
                                            else
                                            {
                                                if ((dAvlQty + HQty) >= Qty)
                                                {
                                                    rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                                    rows[0]["ShwQty"] = Sqtyy.ToString("" + qtysetting + "");
                                                    decimal amt = Convert.ToDecimal(Qty) * dRate;
                                                    rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                                    decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                                    rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                                }
                                            }
                                            //else
                                            //{
                                            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Item Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                            //    txtmanualqty.Focus();
                                            //    return;
                                            //}


                                        }
                                        else
                                        {
                                            Qty = 0; int totcnt = 0;
                                            int countt = dt.Rows.Count;
                                            totcnt = countt + 1;
                                            DataRow dr = dt.NewRow();
                                            //  Qty = Qty + 1;
                                            Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                            decimal amt = 0;
                                            decimal mrpamt = 0;

                                            dr["Sno"] = totcnt;
                                            dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                            dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                            dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                            dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                            dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                            dr["Qty"] = Convert.ToDecimal(Qty).ToString();//Qty.ToString("0");
                                            dr["ShwQty"] = Shwqty.ToString("" + qtysetting + "");
                                            dr["Rate"] = Convert.ToDecimal(dRate).ToString("" + ratesetting + "");
                                            dr["Tax"] = Convert.ToDecimal(GST);
                                            dr["mrp"] = Convert.ToDouble(dCat.Tables[0].Rows[i]["Rate1"]).ToString("" + ratesetting + "");
                                            dr["cattype"] = cattype;
                                            dr["combo"] = comboo;
                                            dr["Cqty"] = Shwqty.ToString("" + qtysetting + "");
                                            if (dr["Hqty"].ToString() == "0" || dr["Hqty"].ToString() == "")
                                            {
                                                dr["Hqty"] = "0";
                                            }
                                            else
                                            {

                                            }
                                            //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);

                                            {
                                                amt = Convert.ToDecimal(Qty) * dRate;
                                                mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                            }
                                            dr["Amount"] = amt.ToString("" + ratesetting + "");
                                            dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                            //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                                            // dr["RecQty"] = Reqty.ToString();
                                            dr["Orirate"] = dRate.ToString();
                                            if (dAvlQty >= Qty)
                                            {

                                                dt.Rows.Add(dr);
                                            }
                                            else
                                            {
                                                dt.Rows.Add(dr);
                                                //ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Item Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                                //txtmanualqty.Focus();
                                                //return;
                                            }

                                            ViewState["dt"] = dt;
                                            txtmanualslno.Text = (totcnt + 1).ToString();
                                        }
                                    }

                                    DataView dvEmp = dt.DefaultView;
                                    dvEmp.Sort = "Sno Desc";
                                    gvlist.DataSource = dvEmp;
                                    gvlist.DataBind();
                                    getdisablecolumn();
                                }
                                txtdiscou_TextChanged(sender, e);
                            }
                        }

                        UpdatePanel1.Update();
                        UpdatePanel4.Update();
                        drpitemsearch.Focus();
                        txtmanualqty.Text = "";



                    }

                }
                txtmanualslno.Focus();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
                txtmanualqty.Text = "";
                DataSet getallitembind = objbs.GetNewSelectDistinctItems("N", Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.DataSource = getallitembind.Tables[0];
                    drpitemsearch.DataTextField = "Definition";
                    drpitemsearch.DataValueField = "valuee";
                    drpitemsearch.DataBind();
                    drpitemsearch.Items.Insert(0, "Select Item");

                }

                txtbrcode.Text = "";

                #endregion
            }
            else if (possetting == "S" || possetting == "S1")
            {

                if (Nlblstockid.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Item.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                else
                {

                }

                //if (drpitemsearch.SelectedValue == "Select Item")
                //{
                //    drpitemsearch.Focus();
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Item.Please Contact Administrator.Thank You!!!');", true);
                //    return;
                //}
                //else
                {
                    if (txtmanualqty.Text == "0" || txtmanualqty.Text == "")
                    {
                        txtmanualqty.Focus();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Qty.Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }
                    else
                    {
                        UpdatePanel3.Update();
                        decimal Shwqty = 0;
                        int comboo = 0;
                        decimal mrpamnt = 0;
                        decimal Qty = 0;
                        decimal HQty = 0;
                        decimal GST = 0;
                        decimal iQty = 0;
                        decimal SQty = 0;
                        string sItem = "";
                        decimal dCalTotal = 0;
                        decimal dRate = 0, dAmount = 0, dAvlQty = 0;
                        int iSubCatID = 0;
                        int CatID = 0;
                        int stockID = 0;
                        string sTempSession = "";

                        string margin = "0";
                        string margingst = "0";
                        string paymsntgateway = "0";

                        tblBill.Visible = true;
                        dt = (DataTable)ViewState["dt"];
                        //dtt = (DataTable)ViewState["dtt"];
                        DataSet dCat = new DataSet();
                        //  Button btn = (Button)sender;

                        // string[] commandArgs = drpitemsearch.SelectedValue.Split(new char[] { ',' });



                        string categoryuserid = Nlblstockid.Text;
                        string cattype = Nlblcattype.Text;


                        // dCat = objbs.GetStockDetails(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName);
                        // if (cattype == "N")
                        {
                            dCat = objbs.GetStockDetails(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                        }
                        //else if (cattype == "C")
                        //{
                        //    dCat = objbs.GetStockDetailscombo(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                        //}

                        if (dCat.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                            {

                                sItem = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                comboo = Convert.ToInt32(dCat.Tables[0].Rows[i]["comboo"]);
                                dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate"].ToString());
                                CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                                iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString());
                                stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryUserid"].ToString());
                                dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                                GST = Convert.ToDecimal(dCat.Tables[0].Rows[i]["GST"].ToString());
                                mrpamnt = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate1"]);
                                Shwqty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["QTY"].ToString());
                                DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[0]["Expirydate"].ToString());
                                if (lblisinclusiverate.Text == "Y")
                                {
                                    DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "' AND combo='" + comboo + "'");
                                    if (rows.Length > 0)
                                    {



                                        decimal Dtax = (dRate * GST) / 100;

                                        decimal drateee = dRate + Dtax;

                                        decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                                        decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                                        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                        {
                                            Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                            HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                            Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        }
                                        if ((dAvlQty + HQty) >= Qty)
                                        {
                                            rows[0]["Qty"] = Qty.ToString();


                                            decimal amt = Convert.ToDecimal(Qty) * DRATE;
                                            decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                            rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                            rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                        }
                                        // rows[0]["RecQty"] = recQty.ToString();
                                    }
                                    else
                                    {
                                        Qty = 0; int totcnt = 0;
                                        int countt = dt.Rows.Count;
                                        totcnt = countt + 1;
                                        DataRow dr = dt.NewRow();
                                        //Qty = Qty + 1;
                                        Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                        decimal amt = 0;
                                        decimal mrpamt = 0;

                                        decimal Dtax = (dRate * GST) / 100;

                                        decimal drateee = dRate + Dtax;

                                        decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                                        decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                                        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                                        dr["Sno"] = totcnt;
                                        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                        dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                        dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                        dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                        dr["Qty"] = Convert.ToDecimal(Qty).ToString();//Qty.ToString("0");
                                        dr["Rate"] = Convert.ToDecimal(DRATE).ToString("" + ratesetting + "");
                                        dr["Tax"] = Convert.ToDecimal(0);
                                        dr["mrp"] = Convert.ToDouble(dCat.Tables[0].Rows[i]["Rate1"]).ToString("" + ratesetting + "");
                                        //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);

                                        {
                                            amt = Convert.ToDecimal(Qty) * DRATE;
                                            mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                        }
                                        dr["Amount"] = amt.ToString("" + ratesetting + "");
                                        dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                        //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                                        // dr["RecQty"] = Reqty.ToString();
                                        dr["Orirate"] = dRate.ToString();
                                        if (dAvlQty >= Qty)
                                        {

                                            dt.Rows.Add(dr);
                                        }

                                        ViewState["dt"] = dt;
                                        txtmanualslno.Text = (totcnt + 1).ToString();
                                    }
                                }
                                else
                                {
                                    decimal Sqtyy = 0;

                                    {

                                        DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'  AND combo='" + comboo + "'");
                                        if (rows.Length > 0)
                                        {

                                            {
                                                Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                                HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                                Sqtyy = Convert.ToDecimal(rows[0]["ShwQty"].ToString());
                                                if (cattype == "N")
                                                {
                                                    //  Qty = Qty + 1;
                                                    Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                    Sqtyy = Sqtyy + Shwqty;
                                                }
                                                else if (cattype == "C")
                                                {
                                                    //Qty = Qty + 1;
                                                    Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                                    Sqtyy = Sqtyy + Shwqty;
                                                }
                                            }
                                            if (StockOption == "1")
                                            {
                                                if ((dAvlQty + HQty) >= Qty)
                                                {
                                                    rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                                    rows[0]["ShwQty"] = Sqtyy.ToString("" + qtysetting + "");
                                                    decimal amt = Convert.ToDecimal(Qty) * dRate;

                                                    rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                                    decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                                    rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                                }
                                            }
                                            else
                                            {
                                                if ((dAvlQty + HQty) >= Qty)
                                                {
                                                    rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                                    rows[0]["ShwQty"] = Sqtyy.ToString("" + qtysetting + "");
                                                    decimal amt = Convert.ToDecimal(Qty) * dRate;
                                                    rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                                    decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                                    rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Qty = 0; int totcnt = 0;
                                            int countt = dt.Rows.Count;
                                            totcnt = countt + 1;
                                            DataRow dr = dt.NewRow();
                                            //  Qty = Qty + 1;
                                            Qty = Qty + Convert.ToDecimal(txtmanualqty.Text);
                                            decimal amt = 0;
                                            decimal mrpamt = 0;

                                            dr["Sno"] = totcnt;
                                            dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                            dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                            dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                            dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                            dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                            dr["Qty"] = Convert.ToDecimal(Qty).ToString();//Qty.ToString("0");
                                            dr["ShwQty"] = Shwqty.ToString("" + qtysetting + "");
                                            dr["Rate"] = Convert.ToDecimal(dRate).ToString("" + ratesetting + "");
                                            dr["Tax"] = Convert.ToDecimal(GST);
                                            dr["mrp"] = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate1"]).ToString("" + ratesetting + "");
                                            dr["cattype"] = cattype;
                                            dr["combo"] = comboo;
                                            dr["Cqty"] = Shwqty.ToString("" + qtysetting + "");
                                            if (dr["Hqty"].ToString() == "0" || dr["Hqty"].ToString() == "")
                                            {
                                                dr["Hqty"] = "0";
                                            }
                                            else
                                            {

                                            }
                                            //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);

                                            {
                                                amt = Convert.ToDecimal(Qty) * dRate;
                                                mrpamt = Convert.ToDecimal(Qty) * mrpamnt;

                                            }
                                            dr["Amount"] = amt.ToString("" + ratesetting + "");
                                            dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                            //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                                            // dr["RecQty"] = Reqty.ToString();
                                            dr["Orirate"] = dRate.ToString();
                                            if (dAvlQty >= Qty)
                                            {

                                                dt.Rows.Add(dr);
                                            }
                                            else
                                            {
                                                dt.Rows.Add(dr);
                                                //ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Item Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                                //txtmanualqty.Focus();
                                                //return;
                                            }

                                            ViewState["dt"] = dt;
                                            txtmanualslno.Text = (totcnt + 1).ToString();
                                        }
                                    }

                                    DataView dvEmp = dt.DefaultView;
                                    dvEmp.Sort = "Sno Desc";
                                    gvlist.DataSource = dvEmp;
                                    gvlist.DataBind();
                                    getdisablecolumn();
                                }
                                txtdiscou_TextChanged(sender, e);
                            }
                        }

                        UpdatePanel1.Update();
                        UpdatePanel4.Update();
                        upcus.Update();
                        drpitemsearch.Focus();
                        txtmanualqty.Text = "";



                    }

                }
                //txtmanualslno.Focus();

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
                txtmanualqty.Text = "";
                DataSet getallitembind = objbs.GetNewSelectDistinctItems("N", Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.DataSource = getallitembind.Tables[0];
                    drpitemsearch.DataTextField = "Definition";
                    drpitemsearch.DataValueField = "valuee";
                    drpitemsearch.DataBind();
                    drpitemsearch.Items.Insert(0, "Select Item");

                }

                //txtbrcode.Text = "";
                txtCusName1.Text = "";
                Nlblstockid.Text = "0";
                Nlblcattype.Text = "N";
                txtCusName1.Focus();

            }
        }


        protected void disc_selectedIndex(object sender, EventArgs e)
        {
            if (drpdischk.SelectedValue == "Select disc")
            {
                drpdischk.Focus();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Discount.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {
                if (lblattenderid.Text != "0")
                {
                    drpdischk.SelectedValue = lbldiscid.Text;
                    txtDiscount.Text = drpdischk.SelectedItem.Text;
                    txtDiscount_TextChanged(sender, e);
                }
                else
                {

                    txtDiscount.Text = drpdischk.SelectedItem.Text;
                    txtDiscount_TextChanged(sender, e);
                }

            }
        }

        protected void attednerchk(object sender, EventArgs e)
        {

            txtdiscotp.Text = "";
            txtdiscotp.Attributes.Clear();
            drpdischk.Items.Clear();
            drpdischk.ClearSelection();
            lblmaxdiscount.Text = "0";
            DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
            if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
            {
                // lblmaxdiscount.Text = getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"].ToString();
                lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
            }
            txtDiscount.Text = "0";
            txtDiscount.Enabled = false;
            txtdiscou_TextChanged(sender, e);
        }

        protected void otp_chnaged(object sender, EventArgs e)
        {


            if (lblattenderid.Text == "0")
            {

                if (lblpaymodesic.Text == "Y")
                {
                    chkdisc.Enabled = true;
                }
                else
                {
                    DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                    if (getAttenderdisc.Tables[0].Rows.Count > 0)
                    {
                        attednertype.DataSource = getAttenderdisc.Tables[0];
                        attednertype.DataTextField = "AttenderName";
                        attednertype.DataValueField = "AttenderID";
                        attednertype.DataBind();
                        attednertype.Items.Insert(0, "Select Disc-Att");

                    }
                    chkdisc.Checked = false;
                    chkdisc.Enabled = false;
                    txtdiscotp.Enabled = false;
                    txtdiscotp.Text = "";
                    txtDiscount.Text = "0";
                    attednertype.Enabled = false;
                    txtDiscount.Enabled = false;
                    chkdisc.Enabled = false;
                    chkdisc.Checked = false;
                    txtdiscotp.Text = "";
                    txtdiscotp.Enabled = false;
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                    txtdiscotp.Attributes.Clear();
                    txtdiscou_TextChanged(sender, e);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                    return;
                }
            }


            DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
            if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
            {
                //lblmaxdiscount.Text = getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"].ToString();
                lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
            }

            if (lblattenderid.Text == "0")
            {
                if (txtdiscotp.Text == "")
                {
                    txtdiscou_TextChanged(sender, e);
                }
                else
                {
                    if (Convert.ToDouble(lbloritot.Text) < Convert.ToDouble(lblmaxdiscount.Text))
                    {
                        txtDiscount.Text = "0";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Discount Applicable Above " + Convert.ToDouble(lblmaxdiscount.Text).ToString("" + ratesetting + "") + ".Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }
                }
            }


            if (lblattenderid.Text != "0")
            {
                txtdiscotp.Text = lblattenderpassword.Text;
            }

            if (attednertype.SelectedValue == "Select Disc-Att")
            {
                txtdiscotp.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Approval Attender.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {
                if (txtdiscotp.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Password is Incorrect.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                //check otp for valid attedner
                DataSet dcheckotp = objbs.GetAttenderotpcheck(BranchID, attednertype.SelectedValue, txtdiscotp.Text);
                if (dcheckotp.Tables[0].Rows.Count > 0)
                {
                    if (drpdischk.SelectedValue == "Select disc" || drpdischk.SelectedValue == "")
                    {
                        DataSet disc = objbs.getdiscvalue(attednertype.SelectedValue);
                        if (disc.Tables[0].Rows.Count > 0)
                        {
                            {
                                drpdischk.DataSource = disc.Tables[0];
                                drpdischk.DataTextField = "discper";
                                drpdischk.DataValueField = "discid";
                                drpdischk.DataBind();
                                drpdischk.Items.Insert(0, "Select disc");
                                drpdischk.Enabled = true;

                            }
                        }
                        else
                        {
                            drpdischk.Items.Insert(0, "Select disc");
                        }
                    }

                    //lblmaxdiscount.Text = Convert.ToDouble(dcheckotp.Tables[0].Rows[0]["disc"]).ToString("0.00");
                    txtDiscount.Enabled = false;
                    //txtDiscount.Focus();
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Maximum Discount Upto " + Convert.ToDouble(lblmaxdiscount.Text).ToString(""+ratesetting+"") + "%.Thank You!!!');", true);
                    txtdiscou_TextChanged(sender, e);

                    string Password = txtdiscotp.Text;
                    txtdiscotp.Attributes.Add("value", Password);
                    if (isdiscchk.Text == "Y")
                    {


                        if (lblattenderid.Text != "0")
                        {
                            drpdischk.SelectedValue = lbldiscid.Text;
                            drpdischk.Enabled = false;
                            disc_selectedIndex(sender, e);
                        }
                    }
                    else
                    {

                        drpdischk.Enabled = true;
                        disc_selectedIndex(sender, e);
                    }

                }
                else
                {
                    //lblmaxdiscount.Text = "0";
                    drpdischk.ClearSelection();
                    txtDiscount.Enabled = false;
                    txtDiscount.Text = "0";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password Else Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

            }


        }

        protected void disc_checkedchanged(object sender, EventArgs e)
        {
            if (chkdisc.Checked == true)
            {

                //txtDiscount.Enabled = true;
                //txtDiscount.Focus();
                DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
                if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
                {
                    lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
                }

                if (Convert.ToDouble(lbloritot.Text) < Convert.ToDouble(lblmaxdiscount.Text))
                {
                    chkdisc.Checked = false;
                    txtDiscount.Text = "0";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Discount Applicable Above " + Convert.ToDouble(lblmaxdiscount.Text).ToString("" + ratesetting + "") + ".Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                txtdiscotp.Enabled = true;
                attednertype.Enabled = true;
            }
            else
            {
                DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                if (getAttenderdisc.Tables[0].Rows.Count > 0)
                {
                    attednertype.DataSource = getAttenderdisc.Tables[0];
                    attednertype.DataTextField = "AttenderName";
                    attednertype.DataValueField = "AttenderID";
                    attednertype.DataBind();
                    attednertype.Items.Insert(0, "Select Disc-Att");

                }
                txtdiscotp.Enabled = false;
                txtdiscotp.Text = "";
                txtDiscount.Text = "0";
                attednertype.Enabled = false;
                txtDiscount.Enabled = false;
                txtdiscotp.Attributes.Clear();
                drpdischk.Items.Clear();
                drpdischk.ClearSelection();
            }

            txtdiscou_TextChanged(sender, e);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            // Checking category

            DataSet dcatchk = objbs.gettingcategorybyid(btn.CommandArgument);
            if (dcatchk.Tables[0].Rows.Count > 0)
            {
                String cattype = dcatchk.Tables[0].Rows[0]["cattype"].ToString();


                DataSet dCat = objbs.SelectDistinctItems(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName, cattype, StockOption);
                Session["SubID"] = Convert.ToInt32(btn.CommandArgument);
                int icount = dCat.Tables[0].Rows.Count;

                //var d = dCat.Tables[0];// here ds is your dataset.
                //int count = d.Rows.Count;
                //var x = new DataTable();
                //for (int i = 0; i <= count; i++)
                //{
                //    var dr = d.Rows[i];
                //    x.Rows.Add(dr.ItemArray);
                //    d.Rows.RemoveAt(i);
                //}
                //var ret = new DataSet();
                //ret.Tables.Add(x);
                //ret.Tables.Add(d);

                DataTable dt1 = new DataTable();
                DataRow dr1 = null;
                dt1.Columns.Add(new DataColumn("Definition", typeof(string)));
                dt1.Columns.Add(new DataColumn("CategoryUserID", typeof(string)));
                dt1.Columns.Add(new DataColumn("Cattype", typeof(string)));

                DataTable dt2 = new DataTable();
                DataRow dr2 = null;
                dt2.Columns.Add(new DataColumn("Definition", typeof(string)));
                dt2.Columns.Add(new DataColumn("CategoryUserID", typeof(string)));
                dt2.Columns.Add(new DataColumn("Cattype", typeof(string)));


                DataTable dt3 = new DataTable();
                DataRow dr3 = null;
                dt3.Columns.Add(new DataColumn("Definition", typeof(string)));
                dt3.Columns.Add(new DataColumn("CategoryUserID", typeof(string)));
                dt3.Columns.Add(new DataColumn("Cattype", typeof(string)));

                int iChk = icount / 3;
                for (int i = 0; i < icount; i++)
                {
                    decimal dStock = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                    string sTock = dStock.ToString("" + qtysetting + "");
                    DateTime Date1 = Convert.ToDateTime(dCat.Tables[0].Rows[i]["Expirydate"].ToString());
                    //string sDate1 = Date1.ToString("dd/MM/yy");

                    dr1 = dt1.NewRow();
                    dr1["Definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString() + Environment.NewLine + " (" + sTock + ")" + " - " + Convert.ToDouble(dCat.Tables[0].Rows[i]["mrp"]).ToString("" + ratesetting + "");
                    dr1["CategoryUserID"] = dCat.Tables[0].Rows[i]["StockID"].ToString();
                    dr1["Cattype"] = cattype;
                    btn.ID = dCat.Tables[0].Rows[i]["StockID"].ToString();

                    dt1.Rows.Add(dr1);



                    i = i + 1;
                    if (i < icount)
                    {
                        decimal dStock1 = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());


                        string sTock1 = dStock1.ToString("" + qtysetting + "");
                        DateTime Date2 = Convert.ToDateTime(dCat.Tables[0].Rows[i]["Expirydate"].ToString());
                        // string sDate2 = Date2.ToString("dd/MM/yy");

                        dr2 = dt2.NewRow();
                        dr2["Definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString() + Environment.NewLine + " (" + sTock1 + ")" + " - " + Convert.ToDouble(dCat.Tables[0].Rows[i]["mrp"]).ToString("" + ratesetting + "");
                        dr2["CategoryUserID"] = dCat.Tables[0].Rows[i]["StockID"].ToString();
                        dr2["Cattype"] = cattype;
                        btn.ID = dCat.Tables[0].Rows[i]["StockID"].ToString();
                        dt2.Rows.Add(dr2);


                    }

                    i = i + 1;
                    if (i < icount)
                    {

                        decimal dStock2 = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                        string sTock2 = dStock2.ToString("" + qtysetting + "");

                        DateTime Date3 = Convert.ToDateTime(dCat.Tables[0].Rows[i]["Expirydate"].ToString());


                        // string sDate3 = Date3.ToString("dd/MM/yy");

                        dr3 = dt3.NewRow();
                        dr3["Definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString() + Environment.NewLine + " (" + sTock2 + ")" + " - " + Convert.ToDouble(dCat.Tables[0].Rows[i]["mrp"]).ToString("" + ratesetting + "");
                        dr3["CategoryUserID"] = dCat.Tables[0].Rows[i]["StockID"].ToString();
                        dr3["Cattype"] = cattype;
                        btn.ID = dCat.Tables[0].Rows[i]["StockID"].ToString();

                        dt3.Rows.Add(dr3);

                    }






                }

                GridView2.DataSource = dt1;
                GridView2.DataBind();
                GridView3.DataSource = dt2;
                GridView3.DataBind();
                GridView4.DataSource = dt3;
                GridView4.DataBind();
                UpdatePanel3.Update();
                //int icount = dCat.Tables[0].Rows.Count;

                //for (int i = 0; i < icount; i++)
                //{
                //    string sName = dCat.Tables[0].Rows[i]["Definition"].ToString();
                //    string id = dCat.Tables[0].Rows[i]["Categoryuserid"].ToString();
                //    BtnServices = new Button();
                //    BtnServices.ID = id;
                //    BtnServices.Text = sName;
                //    BtnServices.BackColor = System.Drawing.Color.Yellow;
                //    BtnServices.ForeColor = System.Drawing.Color.Black;
                //    BtnServices.Click += new EventHandler(BtnServices_Click1);
                //    //   BtnServices.Command += new CommandEventHandler(BtnServices_Command);
                //    td1.Controls.Add(BtnServices);


                //}



                //}

                // GridView2.Rows[0].Cells[0].Controls.Add(GridView2);
            }


        }
        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = gvlist.Rows[index];
            dt = (DataTable)ViewState["dt"];
            //   dtt = (DataTable)ViewState["dtt"];
            //  TableCell Item = gvlist.Rows[index].Cells[3];
            Label Item = (Label)gvRow.FindControl("CategoryUserid");
            Label lblcattype = (Label)gvRow.FindControl("lblcattype");
            Label lblcombo = (Label)gvRow.FindControl("lblcombo");
            TextBox ShwQty = (TextBox)gvRow.FindControl("txtshwqty");
            TextBox txtcqty = (TextBox)gvRow.FindControl("txtcqty");
            //  TextBox Rate = (TextBox)gvRow.FindControl("Rate");
            // TextBox Amount = (TextBox)gvRow.FindControl("Amount");
            //TableCell Quantity = gvlist.Rows[index].Cells[5];
            //TableCell Rate = gvlist.Rows[index].Cells[6];
            //TableCell Amount = gvlist.Rows[index].Cells[8];
            if (e.CommandName == "minus")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (lblcattype.Text == "N")
                    {
                        if (dr["CategoryUserid"].ToString() == Item.Text && lblcattype.Text == dr["cattype"].ToString())
                        {
                            decimal qty = Convert.ToDecimal(dr["Qty"].ToString());
                            decimal shwqty = Convert.ToDecimal(dr["ShwQty"].ToString());
                            //  int minQty = Convert.ToInt32(dr["recQty"].ToString());
                            decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                            decimal cqty = Convert.ToDecimal(dr["cQty"].ToString());
                            decimal amt = 0;
                            //  int final = qty - minQty;
                            decimal shwfinal = qty - 1;
                            decimal shwqtyy = shwqty - cqty;
                            dr["Qty"] = shwfinal.ToString();
                            dr["ShwQty"] = shwqtyy.ToString();

                            amt = shwfinal * rate;
                            dr["Amount"] = amt.ToString("" + ratesetting + "");
                            if (dr["Qty"].ToString() == "0" && lblcattype.Text == dr["cattype"].ToString())
                            {
                                dt.Rows.Remove(dr);
                            }
                            if(shwfinal < 0)
                            {
                                dt.Rows.Remove(dr);
                            }
                            ViewState["dt"] = dt;

                            break;
                        }
                    }
                    else if (lblcattype.Text == "C")
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (lblcombo.Text == dt.Rows[i]["combo"].ToString())
                            {
                                //dt.Rows.RemoveAt(i);
                                decimal qty = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                                decimal shwqty = Convert.ToDecimal(dt.Rows[i]["ShwQty"].ToString());
                                decimal cqty = Convert.ToDecimal(dt.Rows[i]["Cqty"].ToString());
                                decimal rate = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                                decimal amt = 0;
                                //  int final = qty - minQty;
                                decimal shwfinal = qty - 1;
                                decimal shqtyy = cqty * 1;

                                decimal shqtyy1 = shwqty - shqtyy;

                                dt.Rows[i]["Qty"] = shwfinal.ToString();
                                dt.Rows[i]["ShwQty"] = shqtyy1.ToString();
                                amt = shwfinal * rate;
                                dt.Rows[i]["Amount"] = amt.ToString("" + ratesetting + "");
                                if (dt.Rows[i]["Qty"].ToString() == "0" || dt.Rows[i]["Qty"].ToString() == "0.0000")
                                {
                                    //dt.Rows.Remove(dt[i]);
                                    //  dt.Rows.Remove(dt.Rows[i]);
                                }

                            }
                        }
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                            if (dt.Rows[i]["Qty"].ToString() == "0" || dt.Rows[i]["Qty"].ToString() == "0.0000")
                                dt.Rows.RemoveAt(i);

                        ViewState["dt"] = dt;
                        break;
                    }
                }


                // Total();
                //int dtcount = dt.Rows.Count;



                //if (lblcattype.Text == "N")
                //{
                //    for (int ii = dtt.Rows.Count - 1; ii >= 0; ii--)
                //        if (Item.Text == dtt.Rows[ii]["CategoryUserid"].ToString())
                //        {
                //            decimal qty = Convert.ToDecimal(dtt.Rows[ii]["Qty"].ToString());
                //            //decimal shwqty = Convert.ToDecimal(dtt.Rows[ii]["ShwQty"].ToString());


                //            decimal amt = 0;
                //            //  int final = qty - minQty;
                //            decimal shwfinal = qty - Convert.ToDecimal(ShwQty.Text);
                //            dtt.Rows[ii]["Qty"] = shwfinal.ToString();
                //            if (dtt.Rows[ii]["Qty"].ToString() == "0" || dtt.Rows[ii]["Qty"].ToString() == "0.0000")
                //            {
                //                //dt.Rows.Remove(dt[i]);
                //                //  dt.Rows.Remove(dt.Rows[i]);
                //                dtt.Rows.RemoveAt(ii);
                //            }

                //        }
                //}
                //else if (lblcattype.Text == "C")
                //{
                //    DataSet dCat = objbs.GetStockDetailscombo(Convert.ToInt32(lblcombo.Text), Convert.ToInt32(lblUserID.Text), sTableName);
                //    if (dCat.Tables[0].Rows.Count > 0)
                //    {
                //        for (int kk = 0; kk < dCat.Tables[0].Rows.Count; kk++)
                //        {

                //            string categoryuserid = dCat.Tables[0].Rows[kk]["icatid"].ToString();
                //            double showwqty = Convert.ToDouble(dCat.Tables[0].Rows[kk]["QTY"]);

                //            for (int ii = dtt.Rows.Count - 1; ii >= 0; ii--)
                //            {
                //                if (categoryuserid == dtt.Rows[ii]["CategoryUserid"].ToString())
                //                {
                //                    decimal qty = Convert.ToDecimal(dtt.Rows[ii]["Qty"].ToString());
                //                    //decimal shwqty = Convert.ToDecimal(dtt.Rows[ii]["ShwQty"].ToString());


                //                    decimal amt = 0;
                //                    //  int final = qty - minQty;
                //                    decimal shwfinal = qty - Convert.ToDecimal(showwqty);
                //                    dtt.Rows[ii]["Qty"] = shwfinal.ToString();
                //                    if (dtt.Rows[ii]["Qty"].ToString() == "0" || dtt.Rows[ii]["Qty"].ToString() == "0.0000")
                //                    {
                //                        //dt.Rows.Remove(dt[i]);
                //                        //  dt.Rows.Remove(dt.Rows[i]);
                //                        dtt.Rows.RemoveAt(ii);
                //                    }

                //                }
                //            }
                //        }
                //    }
                //}

                //ViewState["dtt"] = dtt;

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (lblcattype.Text == "N")
                    {
                        if (dr["CategoryUserid"].ToString() == Item.Text && lblcattype.Text == dr["cattype"].ToString())
                        {
                            dt.Rows.Remove(dr);
                            ViewState["dt"] = dt;
                            break;
                        }
                    }
                    else if (lblcattype.Text == "C")
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {


                            for (int ii = dt.Rows.Count - 1; ii >= 0; ii--)
                                if (lblcombo.Text == dt.Rows[ii]["combo"].ToString())
                                    dt.Rows.RemoveAt(ii);

                        }
                        ViewState["dt"] = dt;
                        break;
                    }
                }

                //if (lblcattype.Text == "N")
                //{
                //    for (int ii = dtt.Rows.Count - 1; ii >= 0; ii--)
                //        if (Item.Text == dtt.Rows[ii]["CategoryUserid"].ToString())
                //            dtt.Rows.RemoveAt(ii);
                //}
                //else if (lblcattype.Text == "C")
                //{
                //    DataSet dCat = objbs.GetStockDetailscombo(Convert.ToInt32(lblcombo.Text), Convert.ToInt32(lblUserID.Text), sTableName);
                //    if (dCat.Tables[0].Rows.Count > 0)
                //    {
                //        for (int kk = 0; kk < dCat.Tables[0].Rows.Count; kk++)
                //        {

                //            string categoryuserid = dCat.Tables[0].Rows[kk]["icatid"].ToString();
                //            double showwqty = Convert.ToDouble(dCat.Tables[0].Rows[kk]["QTY"]);

                //            for (int ii = dtt.Rows.Count - 1; ii >= 0; ii--)
                //            {
                //                if (categoryuserid == dtt.Rows[ii]["CategoryUserid"].ToString())
                //                {
                //                    decimal qty = Convert.ToDecimal(dtt.Rows[ii]["Qty"].ToString());
                //                    //decimal shwqty = Convert.ToDecimal(dtt.Rows[ii]["ShwQty"].ToString());


                //                    decimal amt = 0;
                //                    //  int final = qty - minQty;
                //                    decimal shwfinal = qty - Convert.ToDecimal(showwqty);
                //                    dtt.Rows[ii]["Qty"] = shwfinal.ToString();
                //                    if (dtt.Rows[ii]["Qty"].ToString() == "0" || dtt.Rows[ii]["Qty"].ToString() == "0.0000")
                //                    {
                //                        dtt.Rows.RemoveAt(ii);
                //                    }

                //                }
                //            }
                //        }
                //    }
                //}

                //ViewState["dtt"] = dtt;

            }

            UpdatePanel.Update();

            DataView dvEmp = dt.DefaultView;
            dvEmp.Sort = "Sno Desc";
            gvlist.DataSource = dvEmp;
            gvlist.DataBind();
            getdisablecolumn();


            //DataView dvEmp1 = dtt.DefaultView;
            //gvlst.DataSource = dvEmp1;
            //gvlst.DataBind();

            // Total();
            txtdiscou_TextChanged(sender, e);
            if (Convert.ToDouble(lbloritot.Text) < Convert.ToDouble(lblmaxdiscount.Text))
            {
                chkdisc.Checked = false;
                disc_checkedchanged(sender, e);

            }
        }
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void txtqty_chnaged(object sender, EventArgs e)
        {
            decimal Qty = 0; decimal QtyT = 0;
            decimal GST = 0;
            decimal iQty = 0;
            string sItem = "";
            decimal dCalTotal = 0;
            decimal dRate = 0, dAmount = 0, dAvlQty = 0, mrpRate = 0; ;
            int iSubCatID = 0;
            int CatID = 0;
            int stockID = 0;
            string sTempSession = "";

            string margin = "0";
            string margingst = "0";
            string paymsntgateway = "0";

            tblBill.Visible = true;

            TextBox ddl = (TextBox)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            Label ddlcategory1 = (Label)row.FindControl("CategoryUserid");
            Label StockID = (Label)row.FindControl("StockID");
            TextBox defini = (TextBox)row.FindControl("Definition");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            if (txtQty.Text == "")
                txtQty.Text = "0";

            // decimal PackingUnitValue = 0;
            //  DropDownList ddlunit = (DropDownList)row.FindControl("ddlunit");
            // string[] arg = ddlunit.SelectedItem.Text.Split('-');


            //if (arg.Length > 1)
            //{
            //    PackingUnitValue = Convert.ToDecimal(arg[0].ToString());
            //}
            //else
            //{
            //    PackingUnitValue = Convert.ToDecimal(ddlunit.SelectedItem.Text);
            //}

            dt = (DataTable)ViewState["dt"];
            DataSet dCat = new DataSet();
            dCat = objbs.GetStockDetails(Convert.ToInt32(StockID.Text), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);

            if (dCat.Tables[0].Rows.Count > 0)
            {
                sItem = dCat.Tables[0].Rows[0]["Definition"].ToString();

                dRate = Convert.ToDecimal(dCat.Tables[0].Rows[0]["Rate"].ToString());
                mrpRate = Convert.ToDecimal(dCat.Tables[0].Rows[0]["mrp"].ToString());
                CatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryID"].ToString());
                iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["StockID"].ToString());
                stockID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryUserid"].ToString());
                dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[0]["Available_QTY"].ToString());

                // if (lblisinclusiverate.Text == "Y")
                //{
                //    DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'");
                //    if (rows.Length > 0)
                //    {

                //        //isnull((((((ts.UnitPrice * ts.Quantity) - (((ts.UnitPrice * ts.Quantity) * s.discper)/100)) * cu.gst) / 100)  
                //        //((ts.UnitPrice * ts.Quantity) - (((ts.UnitPrice * ts.Quantity) * s.discper)/100))),0) as TotalValue

                //        // decimal Dratee = ((((((dRate * 1)-(((dRate * 1) * 0)/100)) * GST) / 100)((dRate * 1) - (((dRate * 1) * 0)/100))));

                //        decimal Dtax = (dRate * GST) / 100;

                //        decimal drateee = dRate + Dtax;

                //        decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                //        decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                //        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                //        {
                //            Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                //            Qty = Convert.ToDecimal(txtQty.Text);
                //        }
                //        if (dAvlQty >= Qty)
                //        {
                //            rows[0]["Qty"] = Qty.ToString();


                //            decimal amt = Convert.ToDecimal(Qty) * DRATE;
                //            rows[0]["Amount"] = amt.ToString("f2");
                //        }
                //    }
                //}
                //else
                {

                    DataRow[] rows = dt.Select("Definition='" + defini.Text + "' AND CategoryUserid='" + ddlcategory1.Text + "'");
                    if (rows.Length > 0)
                    {


                        Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                        Qty = Convert.ToDecimal(txtQty.Text);
                        // QtyT = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(arg[0].ToString());

                        if (StockOption == "1")
                        {

                            if (dAvlQty >= Qty)
                            {
                                rows[0]["Qty"] = Qty.ToString();


                                decimal amt = Convert.ToDecimal(Qty) * dRate;
                                //decimal amt = Convert.ToDecimal(Qty) * Convert.ToDecimal(Qty) * dRate;
                                decimal mrpamt = Convert.ToDecimal(Qty) * mrpRate;
                                //rows[0]["Amount"] = amt.ToString("f2");
                                rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                            }
                        }
                        else
                        {
                            {
                                rows[0]["Qty"] = Qty.ToString();


                                decimal amt = Convert.ToDecimal(Qty) * dRate;
                                rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                decimal mrpamt = Convert.ToDecimal(Qty) * mrpRate;
                                rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                            }
                        }
                        // rows[0]["RecQty"] = recQty.ToString();
                    }
                }

                gvlist.DataSource = dt;
                gvlist.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Something Went Wrong Please Process Button Type Billing.Thank You!!!');", true);
                return;
            }


            txtdiscou_TextChanged(sender, e);



            UpdatePanel1.Update();
            UpdatePanel4.Update();

        }


        //protected void txtqty_chnaged(object sender, EventArgs e)
        //{
        //    decimal Qty = 0;
        //    decimal GST = 0;
        //    decimal iQty = 0;
        //    string sItem = "";
        //    decimal dCalTotal = 0;
        //    decimal dRate = 0, dAmount = 0, dAvlQty = 0;
        //    int iSubCatID = 0;
        //    int CatID = 0;
        //    int stockID = 0;
        //    string sTempSession = "";

        //    string margin = "0";
        //    string margingst = "0";
        //    string paymsntgateway = "0";

        //    tblBill.Visible = true;

        //    TextBox ddl = (TextBox)sender;
        //    GridViewRow row = (GridViewRow)ddl.NamingContainer;
        //    Label ddlcategory1 = (Label)row.FindControl("CategoryUserid");
        //    Label StockID = (Label)row.FindControl("StockID");
        //    TextBox defini = (TextBox)row.FindControl("Definition");
        //    Label lblcattype = (Label)row.FindControl("lblcattype");
        //    TextBox txtQty = (TextBox)row.FindControl("txtQty");
        //    if (txtQty.Text == "")
        //        txtQty.Text = "0.00";


        //    dt = (DataTable)ViewState["dt"];
        //    DataSet dCat = new DataSet();
        //    dCat = objbs.GetStockDetails(Convert.ToInt32(StockID.Text), Convert.ToInt32(lblUserID.Text), sTableName);

        //    if (dCat.Tables[0].Rows.Count > 0)
        //    {
        //        sItem = dCat.Tables[0].Rows[0]["Definition"].ToString();

        //        dRate = Convert.ToDecimal(dCat.Tables[0].Rows[0]["Rate"].ToString());
        //        CatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryID"].ToString());
        //        iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["StockID"].ToString());
        //        stockID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryUserid"].ToString());
        //        dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[0]["Available_QTY"].ToString());

        //        // if (lblisinclusiverate.Text == "Y")
        //        //{
        //        //    DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'");
        //        //    if (rows.Length > 0)
        //        //    {

        //        //        //isnull((((((ts.UnitPrice * ts.Quantity) - (((ts.UnitPrice * ts.Quantity) * s.discper)/100)) * cu.gst) / 100)  
        //        //        //((ts.UnitPrice * ts.Quantity) - (((ts.UnitPrice * ts.Quantity) * s.discper)/100))),0) as TotalValue

        //        //        // decimal Dratee = ((((((dRate * 1)-(((dRate * 1) * 0)/100)) * GST) / 100)((dRate * 1) - (((dRate * 1) * 0)/100))));

        //        //        decimal Dtax = (dRate * GST) / 100;

        //        //        decimal drateee = dRate + Dtax;

        //        //        decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

        //        //        decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

        //        //        decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

        //        //        {
        //        //            Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
        //        //            Qty = Convert.ToDecimal(txtQty.Text);
        //        //        }
        //        //        if (dAvlQty >= Qty)
        //        //        {
        //        //            rows[0]["Qty"] = Qty.ToString();


        //        //            decimal amt = Convert.ToDecimal(Qty) * DRATE;
        //        //            rows[0]["Amount"] = amt.ToString("f2");
        //        //        }
        //        //    }
        //        //}
        //        //else
        //        {

        //            DataRow[] rows = dt.Select("Definition='" + defini.Text + "' AND CategoryUserid='" + ddlcategory1.Text + "' and cattype='" + lblcattype.Text + "'");

        //            if (rows.Length > 0)
        //            {


        //                Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
        //                Qty = Convert.ToDecimal(txtQty.Text);
        //                //QtyT = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(arg[0].ToString());

        //                if (dAvlQty >= Qty)
        //                {

        //                    rows[0]["Qty"] = Qty.ToString("0");
        //                    rows[0]["ShwQty"] = Qty.ToString("0");

        //                    decimal amt = Convert.ToDecimal(Qty) * dRate;
        //                    rows[0]["Amount"] = amt.ToString("f2");
        //                }
        //                // rows[0]["RecQty"] = recQty.ToString();
        //            }

        //            //if (rows.Length > 0)
        //            //{

        //            //    {
        //            //        Qty = Convert.ToString(rows[0]["Qty"]).ToString("0.00");
        //            //        if (lblcattype.Text == "N")
        //            //        {
        //            //            Qty = Convert.ToDecimal(txtQty.Text);

        //            //        }
        //            //    }
        //            //    if (dAvlQty >= Qty)
        //            //    {
        //            //        //rows[0]["Qty"] = Qty.ToString("0");
        //            //        rows[0]["Qty"] = Qty.ToString("0");
        //            //        rows[0]["ShwQty"] = Qty.ToString("0");

        //            //        decimal amt = Convert.ToDecimal(Qty) * dRate;
        //            //        rows[0]["Amount"] = amt.ToString("f2");
        //            //    }
        //            //    // rows[0]["RecQty"] = recQty.ToString();
        //            //}
        //        }

        //        gvlist.DataSource = dt;
        //        gvlist.DataBind();
        //        getdisablecolumn();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Something Went Wrong Please Process Button Type Billing.Thank You!!!');", true);
        //        return;
        //    }


        //    txtdiscou_TextChanged(sender, e);

        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            UpdatePanel3.Update();
            decimal Shwqty = 0;
            int comboo = 0;
            decimal Qty = 0;
            decimal HQty = 0;
            decimal GST = 0;
            decimal mrpamnt = 0;
            decimal iQty = 0;
            decimal SQty = 0;
            string sItem = "";
            decimal dCalTotal = 0;
            decimal dRate = 0, dAmount = 0, dAvlQty = 0;
            int iSubCatID = 0;
            int CatID = 0;
            int stockID = 0;
            string sTempSession = "";

            string margin = "0";
            string margingst = "0";
            string paymsntgateway = "0";

            tblBill.Visible = true;
            dt = (DataTable)ViewState["dt"];
            //dtt = (DataTable)ViewState["dtt"];
            DataSet dCat = new DataSet();
            Button btn = (Button)sender;

            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
            string categoryuserid = commandArgs[0];
            string cattype = commandArgs[1];


            // dCat = objbs.GetStockDetails(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName);
            if (cattype == "N")
            {
                dCat = objbs.GetStockDetails(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            }
            else if (cattype == "C")
            {
                dCat = objbs.GetStockDetailscombo(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            }

            else if (cattype == "H")
            {
                dCat = objbs.GetStockDetailsOffer(Convert.ToInt32(categoryuserid), Convert.ToInt32(lblUserID.Text), sTableName, Rate, StockOption);
            }
            if (dCat.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                {

                    sItem = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                    comboo = Convert.ToInt32(dCat.Tables[0].Rows[i]["comboo"]);
                    dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate"].ToString());
                    CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                    iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString());
                    stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryUserid"].ToString());
                    dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                    GST = Convert.ToDecimal(dCat.Tables[0].Rows[i]["GST"].ToString());
                    mrpamnt = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate1"]);
                    Shwqty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["QTY"].ToString());
                    //if (dAvlQty < Shwqty)
                    //{
                    //    Shwqty = dAvlQty;
                    //}
                    DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[0]["Expirydate"].ToString());
                    if (lblisinclusiverate.Text == "Y")
                    {
                        DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "' AND combo='" + comboo + "'");
                        if (rows.Length > 0)
                        {

                            //isnull((((((ts.UnitPrice * ts.Quantity) - (((ts.UnitPrice * ts.Quantity) * s.discper)/100)) * cu.gst) / 100)  
                            //((ts.UnitPrice * ts.Quantity) - (((ts.UnitPrice * ts.Quantity) * s.discper)/100))),0) as TotalValue

                            // decimal Dratee = ((((((dRate * 1)-(((dRate * 1) * 0)/100)) * GST) / 100)((dRate * 1) - (((dRate * 1) * 0)/100))));

                            decimal Dtax = (dRate * GST) / 100;

                            decimal drateee = dRate + Dtax;

                            decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                            decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                            decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                            {
                                Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                                HQty = Convert.ToInt32(rows[0]["HQty"].ToString());
                                Qty = Qty + 1;
                            }
                            if ((dAvlQty + HQty) >= Qty)
                            {
                                rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                decimal amt = Convert.ToDecimal(Qty) * DRATE;
                                rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                            }
                            // rows[0]["RecQty"] = recQty.ToString();
                        }
                        else
                        {
                            Qty = 0; int totcnt = 0;
                            int countt = dt.Rows.Count;
                            totcnt = countt + 1;
                            DataRow dr = dt.NewRow();

                            if (dAvlQty > 1)
                            {
                                Qty = Qty + 1;
                            }
                            else
                            {
                                Qty = dAvlQty;
                            }
                            decimal amt = 0;
                            decimal mrpamt = 0;

                            decimal Dtax = (dRate * GST) / 100;

                            decimal drateee = dRate + Dtax;

                            decimal commamnt = (drateee * Convert.ToDecimal(lblmargin.Text)) / 100;

                            decimal commperamnt = (commamnt * Convert.ToDecimal(lblmargintax.Text)) / 100;

                            decimal DRATE = Math.Round(drateee + commamnt + commperamnt, 0);

                            dr["Sno"] = totcnt;
                            dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                            dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                            dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                            dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                            dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                            dr["Qty"] = Qty.ToString("" + qtysetting + "");
                            dr["Rate"] = Convert.ToDecimal(DRATE).ToString("" + ratesetting + "");
                            dr["Tax"] = Convert.ToDecimal(0);
                            dr["mrp"] = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate1"]).ToString("" + ratesetting + "");
                            //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);

                            {
                                amt = Convert.ToDecimal(Qty) * DRATE;
                                mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                            }
                            dr["Amount"] = amt.ToString("" + ratesetting + "");
                            dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                            //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                            // dr["RecQty"] = Reqty.ToString();
                            dr["Orirate"] = dRate.ToString();
                            if (dAvlQty >= Qty)
                            {

                                dt.Rows.Add(dr);
                            }

                            ViewState["dt"] = dt;
                        }
                    }
                    else
                    {




                        decimal Sqtyy = 0;

                        {

                            DataRow[] rows = dt.Select("Definition='" + sItem + "' AND CategoryUserid='" + stockID + "'  AND combo='" + comboo + "'");
                            if (rows.Length > 0)
                            {

                                {
                                    Qty = Convert.ToDecimal(rows[0]["Qty"].ToString());
                                    HQty = Convert.ToDecimal(rows[0]["HQty"].ToString());
                                    Sqtyy = Convert.ToDecimal(rows[0]["ShwQty"].ToString());
                                    if (cattype == "N")
                                    {
                                        if (lblqtytype.Text == "Y")
                                        {
                                            Qty = Qty + 1;
                                            Sqtyy = Sqtyy + Shwqty;
                                        }
                                        else
                                        {
                                            Qty = Qty;
                                            Sqtyy = Sqtyy + Shwqty;
                                        }
                                    }
                                    else if (cattype == "C")
                                    {
                                        //if (lblqtytype.Text == "Y")
                                        {
                                            Qty = Qty + 1;
                                            Sqtyy = Sqtyy + Shwqty;
                                        }
                                    }
                                }

                                if (StockOption == "2")
                                {
                                    rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                    rows[0]["ShwQty"] = Sqtyy.ToString("" + qtysetting + "");
                                    decimal amt = Convert.ToDecimal(Qty) * dRate;
                                    rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                    decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                    rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                }

                                if (StockOption == "1")
                                {
                                    if ((dAvlQty + HQty) >= Qty)
                                    {
                                        rows[0]["Qty"] = Qty.ToString("" + qtysetting + "");
                                        rows[0]["ShwQty"] = Sqtyy.ToString("" + qtysetting + "");
                                        decimal amt = Convert.ToDecimal(Qty) * dRate;
                                        rows[0]["Amount"] = amt.ToString("" + ratesetting + "");
                                        decimal mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                        rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Categoryid and Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                        return;
                                    }
                                }
                                ////{
                                ////    Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                                ////    Qty = Qty + 1;
                                ////}


                                //////  Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                                //////  Qty = Qty + 1;
                                ////// recQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                                //////  recQtyy = Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                                ////// Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                                ////if (dAvlQty >= Qty)
                                ////{
                                ////    rows[0]["Qty"] = Qty.ToString();


                                ////    decimal amt = Convert.ToDecimal(Qty) * dRate;
                                ////    rows[0]["Amount"] = amt.ToString("f2");
                                ////}
                                ////// rows[0]["RecQty"] = recQty.ToString();
                            }
                            else
                            {
                                Qty = 0; int totcnt = 0;
                                int countt = dt.Rows.Count;
                                totcnt = countt + 1;
                                DataRow dr = dt.NewRow();
                                if (StockOption == "1")
                                {
                                    if (lblqtytype.Text == "Y")
                                    {
                                        if (dAvlQty > 1)
                                        {
                                            Qty = Qty + 1;
                                        }
                                        else
                                        {
                                            Qty = dAvlQty;
                                        }
                                    }
                                    else
                                    {
                                        if (dAvlQty > 1)
                                        {
                                            Qty = 0;
                                        }
                                        else
                                        {
                                            Qty = dAvlQty;
                                        }
                                    }
                                }
                                else
                                {
                                    if (lblqtytype.Text == "Y")
                                    {
                                        Qty = Qty + 1;
                                    }
                                    else
                                    {
                                        Qty = 0;
                                    }


                                }
                                decimal amt = 0;
                                decimal mrpamt = 0;

                                dr["Sno"] = totcnt;
                                dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                                dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["categoryuserid"].ToString();
                                dr["definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString();
                                dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                                dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                                dr["Qty"] = Qty.ToString("" + qtysetting + "");
                                dr["ShwQty"] = Shwqty.ToString("" + qtysetting + "");
                                dr["Rate"] = Convert.ToDecimal(dRate).ToString("" + ratesetting + "");
                                dr["Tax"] = Convert.ToDecimal(GST);
                                dr["mrp"] = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate1"]).ToString("" + ratesetting + "");
                                dr["cattype"] = cattype;
                                dr["combo"] = comboo;
                                dr["Cqty"] = Shwqty.ToString("" + qtysetting + "");
                                if (dr["Hqty"].ToString() == "0" || dr["Hqty"].ToString() == "")
                                {
                                    dr["Hqty"] = "0";
                                }
                                else
                                {

                                }
                                //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);

                                if (StockOption == "2")
                                {
                                    {
                                        amt = Convert.ToDecimal(Qty) * dRate;
                                        mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                    }
                                    dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                    dr["Amount"] = amt.ToString("" + ratesetting + "");
                                    //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                                    // dr["RecQty"] = Reqty.ToString();
                                    dr["Orirate"] = dRate.ToString();

                                    dt.Rows.Add(dr);

                                }


                                if (StockOption == "1")
                                {
                                    {
                                        amt = Convert.ToDecimal(Qty) * dRate;
                                        mrpamt = Convert.ToDecimal(Qty) * mrpamnt;
                                    }
                                    dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                                    dr["Amount"] = amt.ToString("" + ratesetting + "");
                                    //  dr["Itemid"] = dCat.Tables[0].Rows[i]["Itemid"].ToString();
                                    // dr["RecQty"] = Reqty.ToString();
                                    dr["Orirate"] = dRate.ToString();
                                    if (dAvlQty >= Qty)
                                    {

                                        dt.Rows.Add(dr);
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Chk Categoryid and Name Wise-Qty Not Enough For this Item " + sItem + ".Thank You!!!');", true);
                                        return;
                                    }
                                }
                                ViewState["dt"] = dt;
                            }
                        }

                        DataView dvEmp = dt.DefaultView;
                        dvEmp.Sort = "Sno Desc";
                        gvlist.DataSource = dvEmp;
                        gvlist.DataBind();
                        getdisablecolumn();
                    }
                    txtdiscou_TextChanged(sender, e);
                }
            }

            #region Item Shown Static
            //iQty++;
            // var lblItemID = new[] { lblItemID1, lblItemID2, lblItemID3};
            //for (int i = 0; i < Convert.ToInt32(Session["Icount"].ToString()); i++)
            //{
            //    lblItemID[i].Text =Convert.ToString(iSubCatID);
            //}

            //if (Session["Icount"].ToString() != "1")
            //{

            //    if (lblItemID1.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "1";
            //    }
            //    else if (lblItemID2.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "2";
            //    }
            //    else if (lblItemID3.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "3";
            //    }

            //    else if (lblItemID4.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "4";
            //    }
            //    else if (lblItemID5.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "5";
            //    }
            //    else if (lblItemID6.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "6";
            //    }
            //    else if (lblItemID7.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "7";
            //    }
            //    else if (lblItemID8.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "8";
            //    }
            //    else if (lblItemID9.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "9";
            //    }
            //    else if (lblItemID10.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "10";
            //    }
            //    else if (lblItemID11.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "11";
            //    }

            //    else if (lblItemID12.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "12";
            //    }
            //    else if (lblItemID13.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "13";
            //    }
            //    else if (lblItemID14.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "14";
            //    }
            //    else if (lblItemID15.Text == Convert.ToString(iSubCatID))
            //    {
            //        sTempSession = Session["Icount"].ToString();
            //        Session["Icount"] = "15";
            //    }
            //}
            //if (Session["Icount"].ToString() == "1")
            //{



            //    tr.Visible = true;
            //    lblAQty1.Text = dAvlQty.ToString("f0");
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToDecimal(txtQty1.Text);
            //        if (Convert.ToInt32(lblAQty1.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;

            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "2";
            //    }
            //    iItemID[0] = Convert.ToInt32(iSubCatID);
            //    lblItemID1.Text = Convert.ToString(iSubCatID);
            //    lblCatID1.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString("dd/MM/yy");


            //    lblItem1.Text = sItem;

            //    lblRate1.Text = dRate.ToString("f2");

            //    txtQty1.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty1.Text) * Convert.ToDecimal(lblRate1.Text);
            //    lblAmount1.Text = dCalTotal.ToString("f2");
            //    lblTax.InnerText = (Convert.ToDecimal(lblAmount1.Text) * Convert.ToDecimal(0.05)).ToString("f2");



            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        DataSet getsaletype = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam1.Text = Gsttx.ToString();
            //    }

            //    GSTValGrand();


            //    //Calcuate();
            //}
            //else if (Session["Icount"].ToString() == "2")
            //{
            //    tr1.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        //iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty2.Text);
            //        if (Convert.ToInt32(lblAQty2.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "3";
            //    }
            //    lblItemID2.Text = Convert.ToString(iSubCatID);
            //    lblCatID2.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString("dd/MM/yy");
            //    lblItem2.Text = sItem;
            //    lblAQty2.Text = dAvlQty.ToString("f0");
            //    lblRate2.Text = dRate.ToString("f2");
            //    //lblTax1.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    //iQty =  1;
            //    txtQty2.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty2.Text) * Convert.ToDecimal(lblRate2.Text);
            //    lblAmount2.Text = dCalTotal.ToString("f2");
            //    lblTax1.InnerText = (Convert.ToDecimal(lblAmount2.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    //Calcuate();


            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam2.Text = Gsttx.ToString();
            //    }

            //    GSTValGrand();

            //}
            //else if (Session["Icount"].ToString() == "3")
            //{
            //    tr2.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty3.Text);
            //        if (Convert.ToInt32(lblAQty3.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "4";
            //    }
            //    lblItemID3.Text = Convert.ToString(iSubCatID);
            //    lblCatID3.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString("dd/MM/yy");
            //    lblItem3.Text = sItem;
            //    lblAQty3.Text = dAvlQty.ToString("f0");
            //    lblRate3.Text = dRate.ToString("f2");
            //    // iQty =  1;
            //    lblTax2.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty3.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty3.Text) * Convert.ToDecimal(lblRate3.Text);
            //    lblAmount3.Text = dCalTotal.ToString("f2");
            //    lblTax2.InnerText = (Convert.ToDecimal(lblAmount3.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    //Calcuate();



            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam3.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();

            //}
            //else if (Session["Icount"].ToString() == "4")
            //{
            //    tr3.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty4.Text);
            //        if (Convert.ToInt32(lblAQty4.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "5";
            //    }
            //    lblCatID4.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID4.Text = Convert.ToString(iSubCatID);
            //    lblItem4.Text = sItem;
            //    lblAQty4.Text = dAvlQty.ToString("f0");
            //    lblRate4.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax3.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty4.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty4.Text) * Convert.ToDecimal(lblRate4.Text);
            //    lblAmount4.Text = dCalTotal.ToString("f2");
            //    // lblTax3.InnerText = (Convert.ToDecimal(lblAmount4.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    //Calcuate();
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam4.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "5")
            //{
            //    tr4.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty5.Text);
            //        if (Convert.ToInt32(lblAQty5.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "6";
            //    }

            //    lblCatID5.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID5.Text = Convert.ToString(iSubCatID);
            //    lblItem5.Text = sItem;
            //    lblAQty5.Text = dAvlQty.ToString("f0");
            //    lblRate5.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax4.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty5.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty5.Text) * Convert.ToDecimal(lblRate5.Text);
            //    lblAmount5.Text = dCalTotal.ToString("f2");
            //    //lblTax4.InnerText = (Convert.ToDecimal(lblAmount4.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    //Calcuate();
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam5.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "6")
            //{
            //    tr5.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty6.Text);
            //        if (Convert.ToInt32(lblAQty6.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "7";
            //    }
            //    lblCatID6.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID6.Text = Convert.ToString(iSubCatID);
            //    lblItem6.Text = sItem;
            //    lblAQty6.Text = dAvlQty.ToString("f0");
            //    lblRate6.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax5.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty6.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty6.Text) * Convert.ToDecimal(lblRate6.Text);
            //    lblAmount6.Text = dCalTotal.ToString("f2");
            //    // lblTax5.InnerText = (Convert.ToDecimal(lblAmount6.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam6.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "7")
            //{
            //    tr6.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty7.Text);
            //        if (Convert.ToInt32(lblAQty7.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "8";
            //    }
            //    lblCatID7.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID7.Text = Convert.ToString(iSubCatID);
            //    lblItem7.Text = sItem;
            //    lblAQty7.Text = dAvlQty.ToString("f0");
            //    lblRate7.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax6.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty7.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty7.Text) * Convert.ToDecimal(lblRate7.Text);
            //    lblAmount7.Text = dCalTotal.ToString("f2");
            //    // lblTax6.InnerText = (Convert.ToDecimal(lblAmount7.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam7.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "8")
            //{
            //    tr7.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty8.Text);
            //        if (Convert.ToInt32(lblAQty8.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "9";
            //    }
            //    lblCatID8.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID8.Text = Convert.ToString(iSubCatID);
            //    lblItem8.Text = sItem;
            //    lblAQty8.Text = dAvlQty.ToString("f0");
            //    lblRate8.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax7.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty8.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty8.Text) * Convert.ToDecimal(lblRate8.Text);
            //    lblAmount8.Text = dCalTotal.ToString("f2");
            //    // lblTax7.InnerText = (Convert.ToDecimal(lblAmount8.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam8.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "9")
            //{
            //    tr8.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty9.Text);
            //        if (Convert.ToInt32(lblAQty9.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "10";
            //    }
            //    lblCatID9.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID9.Text = Convert.ToString(iSubCatID);
            //    lblItem9.Text = sItem;
            //    lblAQty9.Text = dAvlQty.ToString("f0");
            //    lblRate9.Text = dRate.ToString("f2");
            //    //iQty = 1;

            //    lblTax8.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty9.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty9.Text) * Convert.ToDecimal(lblRate9.Text);
            //    lblAmount9.Text = dCalTotal.ToString("f2");
            //    //    lblTax8.InnerText = (Convert.ToDecimal(lblAmount9.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam9.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "10")
            //{
            //    tr9.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty10.Text);
            //        if (Convert.ToInt32(lblAQty10.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "11";
            //    }
            //    lblCatID10.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID10.Text = Convert.ToString(iSubCatID);
            //    lblItem10.Text = sItem;
            //    lblAQty10.Text = dAvlQty.ToString("f0");
            //    lblRate10.Text = dRate.ToString("f2");
            //    lblTax9.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    //iQty = 1;
            //    txtQty10.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty10.Text) * Convert.ToDecimal(lblRate10.Text);
            //    lblAmount10.Text = dCalTotal.ToString("f2");
            //    //  lblTax9.InnerText = (Convert.ToDecimal(lblAmount10.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam10.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "11")
            //{
            //    tr10.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty11.Text);
            //        if (Convert.ToInt32(lblAQty11.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "12";
            //    }
            //    lblCatID11.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID11.Text = Convert.ToString(iSubCatID);
            //    lblItem11.Text = sItem;
            //    lblAQty11.Text = dAvlQty.ToString("f0");
            //    lblRate11.Text = dRate.ToString("f2");
            //    lblTax10.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    //iQty = 1;
            //    txtQty11.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty11.Text) * Convert.ToDecimal(lblRate11.Text);
            //    lblAmount11.Text = dCalTotal.ToString("f2");
            //    //  lblTax10.InnerText = (Convert.ToDecimal(lblAmount11.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam11.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "12")
            //{
            //    tr11.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty12.Text);
            //        if (Convert.ToInt32(lblAQty12.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "13";
            //    }
            //    lblCatID12.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID12.Text = Convert.ToString(iSubCatID);
            //    lblItem12.Text = sItem;
            //    lblAQty12.Text = dAvlQty.ToString("f0");
            //    lblRate12.Text = dRate.ToString("f2");
            //    lblTax11.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    //iQty = 1;
            //    txtQty12.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty12.Text) * Convert.ToDecimal(lblRate12.Text);
            //    lblAmount12.Text = dCalTotal.ToString("f2");
            //    //  lblTax11.InnerText = (Convert.ToDecimal(lblAmount12.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam12.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}

            //else if (Session["Icount"].ToString() == "13")
            //{
            //    tr12.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty13.Text);
            //        if (Convert.ToInt32(lblAQty13.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "14";
            //    }
            //    lblCatID13.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID13.Text = Convert.ToString(iSubCatID);
            //    lblItem13.Text = sItem;
            //    lblAQty13.Text = dAvlQty.ToString("f0");
            //    lblRate13.Text = dRate.ToString("f2");
            //    lblTax12.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    //iQty = 1;
            //    txtQty13.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty13.Text) * Convert.ToDecimal(lblRate13.Text);
            //    lblAmount13.Text = dCalTotal.ToString("f2");
            //    //  lblTax12.InnerText = (Convert.ToDecimal(lblAmount13.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam13.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}

            //else if (Session["Icount"].ToString() == "14")
            //{
            //    tr13.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty14.Text);
            //        if (Convert.ToInt32(lblAQty14.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "15";
            //    }
            //    lblCatID14.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID14.Text = Convert.ToString(iSubCatID);
            //    lblItem14.Text = sItem;
            //    lblAQty14.Text = dAvlQty.ToString("f0");
            //    lblRate14.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax12.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty14.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty14.Text) * Convert.ToDecimal(lblRate14.Text);
            //    lblAmount14.Text = dCalTotal.ToString("f2");
            //    //  lblTax13.InnerText = (Convert.ToDecimal(lblAmount14.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam14.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            //else if (Session["Icount"].ToString() == "15")
            //{
            //    tr14.Visible = true;
            //    if (sTempSession != "")
            //    {
            //        int iTemp = Convert.ToInt16(sTempSession);
            //        // iTemp++;
            //        Session["Icount"] = Convert.ToString(iTemp);

            //        iQty = Convert.ToInt16(txtQty15.Text);
            //        if (Convert.ToInt32(lblAQty15.Text) <= iQty)
            //            iQty = iQty;
            //        else
            //            iQty++;
            //    }
            //    else
            //    {
            //        iQty = 1;
            //        Session["Icount"] = "16";
            //    }
            //    lblCatID15.Text = Convert.ToString(CatID) + "-" + Convert.ToString(stockID) + "-" + expDate.ToString();
            //    lblItemID15.Text = Convert.ToString(iSubCatID);
            //    lblItem15.Text = sItem;
            //    lblAQty15.Text = dAvlQty.ToString("f0");
            //    lblRate15.Text = dRate.ToString("f2");
            //    //iQty = 1;
            //    lblTax14.InnerText = (dRate * Convert.ToDecimal(0.05)).ToString("f2");
            //    txtQty15.Text = Convert.ToString(iQty);
            //    dCalTotal = Convert.ToDecimal(txtQty15.Text) * Convert.ToDecimal(lblRate15.Text);
            //    lblAmount15.Text = dCalTotal.ToString("f2");
            //    //   lblTax14.InnerText = (Convert.ToDecimal(lblAmount15.Text) * Convert.ToDecimal(0.05)).ToString("f2");
            //    DataSet gstcal = new DataSet();
            //    int Gsttx = 0;
            //    gstcal = objbs.Getgsttax(Convert.ToInt32(stockID));
            //    if (gstcal.Tables[0].Rows.Count > 0)
            //    {

            //        Gsttx = Convert.ToInt32(gstcal.Tables[0].Rows[0]["GST"].ToString());
            //        lbltaxam15.Text = Gsttx.ToString();
            //    }
            //    GSTValGrand();
            //}
            #endregion

            #region code commentted
            //DataTable dTable = new DataTable();
            //DataRow row = null;

            //dTable.Columns.Add(new DataColumn("Item", typeof(string)));
            //dTable.Columns.Add(new DataColumn("AvlQty", typeof(string)));
            //dTable.Columns.Add(new DataColumn("Rate", typeof(string)));
            //dTable.Columns.Add(new DataColumn("EntQty", typeof(string)));
            //dTable.Columns.Add(new DataColumn("ItemID", typeof(string)));
            //dTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));




            //    row = dTable.NewRow();
            //    dCat = objbs.SelectItemsQty(Convert.ToInt32(btn.CommandArgument));
            //    sItem = dCat.Tables[0].Rows[0]["Definition"].ToString();
            //    dRate = Convert.ToDecimal(dCat.Tables[0].Rows[0]["Rate"].ToString());
            //    iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryID"].ToString());

            //    row["ItemID"] = dCat.Tables[0].Rows[0]["CategoryUserID"].ToString();
            //    row["Item"] = dCat.Tables[0].Rows[0]["Definition"].ToString();
            //    row["AvlQty"] = dCat.Tables[0].Rows[0]["Available_Qty"].ToString();
            //    row["EntQty"] = "1";// dCat.Tables[0].Rows[0]["Available_Qty"].ToString();

            //    row["Rate"] = dRate.ToString("f0");
            //     dCalTotal = Convert.ToDecimal(row["EntQty"]) * Convert.ToDecimal(row["Rate"]);
            //    row["Amount"] = dCalTotal;

            //    dTable.Rows.Add(row);


            //    for (int i = 0; i < gvBill.Rows.Count; i++)
            //    {
            //        Label lblItemID = (Label)gvBill.Rows[i].FindControl("lblItemID");
            //        TextBox txtQty = (TextBox)gvBill.Rows[i].FindControl("txtQty");
            //        txtQty.Text = count.ToString();

            //        //count++;
            //        dCat = objbs.SelectItemsQty(Convert.ToInt32(lblItemID.Text));
            //        sItem = dCat.Tables[0].Rows[0]["Definition"].ToString();
            //        dRate = Convert.ToDecimal(dCat.Tables[0].Rows[0]["Rate"].ToString());
            //        iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[0]["CategoryID"].ToString());
            //        row = dTable.NewRow();
            //        row["ItemID"] = dCat.Tables[0].Rows[0]["CategoryUserID"].ToString();
            //        row["Item"] = dCat.Tables[0].Rows[0]["Definition"].ToString();
            //        row["AvlQty"] = dCat.Tables[0].Rows[0]["Available_Qty"].ToString();

            //        row["Rate"] = dRate.ToString("f0");
            //        row["EntQty"] = txtQty.Text;// dCat.Tables[0].Rows[0]["ble_Qty"].ToString();

            //        row["Rate"] = dRate.ToString("f0");
            //        dCalTotal = Convert.ToDecimal(row["EntQty"]) * Convert.ToDecimal(row["Rate"]);
            //        row["Amount"] = dCalTotal;

            //        dTable.Rows.Add(row);


            //    }
            //    DataSet dsFinal = new DataSet();
            //    dsFinal.Tables.Add(dTable);
            //    dsFinal.Tables[0].DefaultView.ToTable(true, "ItemID");

            ////    int RowCount = dsFinal.Tables[0].Rows.Count;
            ////   for(int i=0;i<RowCount;i++)
            ////{
            ////    string CatID = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();

            ////    for (int c = 0; c < RowCount; c++)
            ////    {
            ////        string ID = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();

            ////        if (CatID == ID)
            ////        {
            ////            decimal EntQty = Convert.ToDecimal(dsFinal.Tables[0].Rows[i]["EntQty"].ToString());
            ////            EntQty++;
            ////        }

            ////    }

            ////}
            //    DataTable dFinalTable = new DataTable();
            //     row = null;

            //     dFinalTable.Columns.Add(new DataColumn("Item", typeof(string)));
            //     dFinalTable.Columns.Add(new DataColumn("AvlQty", typeof(string)));
            //     dFinalTable.Columns.Add(new DataColumn("Rate", typeof(string)));
            //     dFinalTable.Columns.Add(new DataColumn("EntQty", typeof(string)));
            //     dFinalTable.Columns.Add(new DataColumn("ItemID", typeof(string)));
            //     dFinalTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));


            //   for (int i = 0; i < dsFinal.Tables[0].Rows.Count; i++)
            //   {
            //       string id = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();

            //       for (int j = 0; j < dsFinal.Tables[0].Rows.Count; j++)
            //       {
            //           string sExt = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();
            //           if (sExt == id)
            //           {
            //               row = dFinalTable.NewRow();
            //               row["ItemID"] = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();
            //               row["Item"] = dsFinal.Tables[0].Rows[i]["Item"].ToString();
            //               row["AvlQty"] = dsFinal.Tables[0].Rows[i]["AvlQty"].ToString();
            //               row["Rate"] = dsFinal.Tables[0].Rows[i]["Rate"].ToString();
            //               decimal EntQty = Convert.ToDecimal(dsFinal.Tables[0].Rows[i]["EntQty"].ToString());

            //                        row["EntQty"] =Convert.ToString( EntQty++);// dCat.Tables[0].Rows[0]["Available_Qty"].ToString();

            //               row["Rate"] = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();
            //               dCalTotal = Convert.ToDecimal(row["EntQty"]) * Convert.ToDecimal(row["Rate"]);
            //               row["Amount"] = dCalTotal;

            //               dFinalTable.Rows.Add(row);
            //           }
            //           else
            //           {
            //               row = dFinalTable.NewRow();
            //               row["ItemID"] = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();
            //               row["Item"] = dsFinal.Tables[0].Rows[i]["Item"].ToString();
            //               row["AvlQty"] = dsFinal.Tables[0].Rows[i]["AvlQty"].ToString();
            //               row["Rate"] = dsFinal.Tables[0].Rows[i]["Rate"].ToString();
            //               row["EntQty"] = dsFinal.Tables[0].Rows[i]["EntQty"].ToString();// dCat.Tables[0].Rows[0]["Available_Qty"].ToString();

            //               row["Rate"] = dsFinal.Tables[0].Rows[i]["ItemID"].ToString();
            //               dCalTotal = Convert.ToDecimal(row["EntQty"]) * Convert.ToDecimal(row["Rate"]);
            //               row["Amount"] = dCalTotal;

            //               dFinalTable.Rows.Add(row);
            //           }
            //       }
            //   }

            //   gvBill.DataSource = dFinalTable;
            //gvBill.DataBind();
            #endregion

            //int i = 0;
            //int j = 0;
            //if (i == 0)
            //{
            //    //i = i + temp_i;

            //    //gvBill.Rows.new.Add();
            //    // dgBill.Rows[i].Cells[j].Value = i;
            //    gvBill.Rows[i].Cells[j].Value = sItem;
            //    gvBill.Rows[i].Cells[j + 1].Value = iQty;
            //    dAmount = dRate * iQty;
            //    gvBill.Rows[i].Cells[j + 2].Value = Math.Round(dAmount, 2);
            //    //dgBill.Rows[i].Cells[j + 4].Value = img;
            //    temp_amt = dAmount;
            //    amt_total = amt_total + temp_amt;
            //   // txtTotal.Text = Convert.ToString((Math.Round(amt_total, 2)));
            //}


            #region commented code

            //row["Item"] = dCat.Tables[0].Rows[0]["Definition"].ToString();
            //row["AvlQty"] = dCat.Tables[0].Rows[0]["Available_Qty"].ToString();
            //row["Rate"] = dCat.Tables[0].Rows[0]["Rate"].ToString();

            //    dTable.Rows.Add(row);

            //    gvBill.DataSource = dTable;
            //    gvBill.DataBind();



            //    for (int i = 0; i < gvBill.Rows.Count; i++)
            //    {
            //        count++;
            //        TextBox txtQty = (TextBox)gvBill.Rows[i].FindControl("txtQty");
            //        txtQty.Text = count.ToString();

            //        Label lblAmt = (Label)gvBill.Rows[i].FindControl("lblAmt");



            //    }
            #endregion

            UpdatePanel1.Update();
            UpdatePanel4.Update();
            upcus.Update();

            //GSTVal();
            for (int vLoop1 = 0; vLoop1 < gvlist.Rows.Count; vLoop1++)
            {
                Label CategoryUserid = (Label)gvlist.Rows[vLoop1].FindControl("CategoryUserid");
                Label StockID = (Label)gvlist.Rows[vLoop1].FindControl("StockID");

                TextBox txtQty = (TextBox)gvlist.Rows[vLoop1].FindControl("txtQty");
                if (StockOption == "1")
                {

                    if (categoryuserid == StockID.Text)
                    {
                        if (txtQty.Text == "0" || txtQty.Text == "" + qtysetting + "")
                        {
                            txtQty.Text = "";
                            txtQty.Focus();
                        }
                        else
                        {
                            txtQty.Focus();
                        }
                    }
                }
                else
                {

                    if (categoryuserid == CategoryUserid.Text)
                    {
                        if (txtQty.Text == "0" || txtQty.Text == "" + qtysetting + "")
                        {
                            txtQty.Text = "";
                            txtQty.Focus();
                        }
                        else
                        {
                            txtQty.Focus();
                        }
                    }
                }
            }


        }

        public void getdisablecolumn()
        {
            for (int vLoop1 = 0; vLoop1 < gvlist.Rows.Count; vLoop1++)
            {
                Label lblcattype = (Label)gvlist.Rows[vLoop1].FindControl("lblcattype");
                TextBox txtQty = (TextBox)gvlist.Rows[vLoop1].FindControl("txtQty");

                if (lblcattype.Text == "C")
                {
                    txtQty.Enabled = false;
                }
            }
        }


        protected void txtdiscou_TextChanged(object sender, EventArgs e)
        {

            if (ViewState["Total"] != null)
            {
                string a = ViewState["Total"].ToString();
                string b = ViewState["GTotal"].ToString();

            }
            decimal Oritotal = 0;
            decimal total = 0;
            decimal total1 = 0;
            decimal getGST = 0;
            decimal disco = 0;
            decimal disTotal = 0;
            double r = 0;
            decimal grandtotal = 0;
            decimal cgstot = 0;
            decimal sgstot = 0;
            decimal distot = 0;
            decimal Tot = 0;
            decimal dis = 0;
            decimal TQty = 0;
            // decimal Discamt = 0;



            dt = (DataTable)ViewState["dt"];

            foreach (DataRow dr in dt.Rows)
            {
                decimal Discamt = 0;
                if (dr["Disamt"].ToString() != "")
                {
                    disco += Convert.ToDecimal(dr["Disamt"]);
                }
                decimal tooo = Convert.ToDecimal(dr["Amount"]);
                decimal tooo1 = Convert.ToDecimal(dr["Amount"]);
                decimal tQty1 = Convert.ToDecimal(dr["Qty"]);

                total += Convert.ToDecimal(dr["Amount"]);
                total1 += Convert.ToDecimal(dr["Amount"]);
                TQty += tQty1;

                //if (dr["Discount"].ToString() == "True")
                //{
                //    disTotal += Convert.ToDecimal(dr["Amount"]);
                //    decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                //    Tot = Convert.ToDecimal(ttoo);
                //    dis = Convert.ToDecimal(txtDiscount.Text) / 100;
                //    Discamt = Tot * dis;
                //}

                disTotal += Convert.ToDecimal(dr["Amount"]);
                decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                Tot = Convert.ToDecimal(ttoo);
                dis = Convert.ToDecimal(txtDiscount.Text) / 100;

                Discamt = Tot * dis;
                dr["Disamt"] = Discamt;



                // if (lblisinclusiverate.Text == "N")
                {
                    lbldisco.Text = Convert.ToDecimal(Discamt).ToString("f2");
                    distot += Convert.ToDecimal(Discamt);
                }
                // else
                {
                    //     distot = Convert.ToDecimal(lbldisco.Text);
                }

                tooo = tooo1 - Discamt;

                string GSt = (dr["Tax"]).ToString();
                string amountt = (dr["Tax"]).ToString();
                decimal gsthaf1 = Convert.ToDecimal(GSt) / 2;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gsthaf1)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;


                decimal oringstamount1 = (Convert.ToDecimal(tooo1) * Convert.ToDecimal(gsthaf1)) / 100;
                decimal Oritot = oringstamount1 + oringstamount1 + tooo1;


                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;
                Oritotal = Oritotal + Oritot;
            }



            lbltotal.Text = total.ToString();
            lbloritot.Text = Oritotal.ToString();
            lblGrandTotal.Text = grandtotal.ToString();
            lbldisco.Text = distot.ToString("" + ratesetting + "");



            lblcgst.Text = (cgstot).ToString("" + ratesetting + "");
            lblsgst.Text = (sgstot).ToString("" + ratesetting + "");
            // decimal Grand = grandtotal + Packing;
            decimal Packing = Convert.ToDecimal(0);
            decimal Delivery = Convert.ToDecimal(0);
            decimal Grand1 = 0;
            //if (lblisinclusiverate.Text == "Y")
            //{
            //    Grand1 = (grandtotal + Packing + Delivery - Convert.ToDecimal(lbldisco.Text));
            //}
            //else
            {


                Grand1 = (grandtotal + Packing + Delivery);
            }
            lblsubttl.Text = (Grand1).ToString("" + ratesetting + "");
            lblGrandTotal.Text = (Grand1).ToString("" + ratesetting + "");
            decimal grandtot = Grand1;
            if (roundoffsetting == "NR")
            {
                //  lblRound.Text = "0".ToString("" + ratesetting + "");
            }
            else if (roundoffsetting == "WG")
            {


                Grand1 = Math.Round(grandtot, 0);
                if (grandtot > Grand1)
                {
                    lblRound.Text = (grandtot - Grand1).ToString("" + ratesetting + "");
                }
                else
                {
                    lblRound.Text = (Grand1 - grandtot).ToString("" + ratesetting + "");
                }
            }
            else if (roundoffsetting == "WE")
            {


                Grand1 = Math.Round(grandtot, 0);
                if (grandtot >= Grand1)
                {
                    lblRound.Text = (grandtot - Grand1).ToString("" + ratesetting + "");
                }
                else
                {
                    lblRound.Text = (Grand1 - grandtot).ToString("" + ratesetting + "");
                }
            }

            lblGrandTotal.Text = (Grand1).ToString("" + ratesetting + "");



            txtTax.Text = (cgstot + sgstot).ToString("" + ratesetting + "");



            //lbltotal.Text = Convert.ToString(Grand1);
            lblGrandTotal.Text = (Grand1).ToString("" + ratesetting + "");

            lbldisplay.InnerText = Grand1.ToString("" + ratesetting + "");
            txttotqty.Text = TQty.ToString("" + qtysetting + "");

            for (int i = 0; i < gvlist.Rows.Count; i++)
            {
                Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");
                dt = (DataTable)ViewState["dt"];

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CategoryUserID"].ToString() == CategoryUserid.Text)
                    {

                        lblitemdiscount.Text = dr["Disamt"].ToString();
                    }
                }

            }
        }





        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "")
            {
                DataSet dsCategory = objbs.SelectItems(Convert.ToInt32(e.CommandName), Convert.ToInt32(lblUserID.Text), sTableName);
                int icount = dsCategory.Tables[0].Rows.Count;

                for (int i = 0; i < icount; i++)
                {
                    string sName = dsCategory.Tables[0].Rows[i]["Definition"].ToString();
                    string sStock = dsCategory.Tables[0].Rows[i]["Available_QTY"].ToString();
                    string id = dsCategory.Tables[0].Rows[i]["SubCategoryID"].ToString();
                    double DRate = Convert.ToDouble(dsCategory.Tables[0].Rows[i][Rate].ToString());

                    string sDate = dsCategory.Tables[0].Rows[i]["Expirydate"].ToString();
                    btnItems = new Button();
                    btnItems.ID = id;
                    btnItems.Text = sName + "--" + sStock + "--" + sDate;
                    btnItems.BackColor = System.Drawing.Color.Yellow;
                    btnItems.ForeColor = System.Drawing.Color.Black;

                    decimal val = Convert.ToDecimal(sStock);

                    if (val > 0)
                    {
                    }
                    else
                    {
                        btnItems.Enabled = false;
                    }


                }
            }
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Write("1");
        }

        protected void btnView_Onclick(object sender, EventArgs e)
        {
            TaxView.Visible = true;
            btnView.Visible = false;
            btnTaxClose.Visible = true;
        }

        protected void btnTaxClose_Onclick(object sender, EventArgs e)
        {
            TaxView.Visible = false;
            btnView.Visible = true;
            btnTaxClose.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("1");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Write("1");
        }

        //protected void txtQty_TextChanged(object sender, EventArgs e)
        //{ 


        //    TextBox txt = (TextBox)sender;
        //    GridViewRow row = (GridViewRow)txt.NamingContainer;

        //    TextBox txtQty=(TextBox)row.FindControl("txtQty");
        //    Label lblAmt = (Label)row.FindControl("lblAmt");

        //    int cnt = gvBill.Rows.Count;
        //    decimal rate = 0;
        //    for (int i = 0; i < cnt; i++)
        //    {
        //         rate = Convert.ToDecimal(gvBill.Rows[i].Cells[4].Text.ToString());


        //    }

        //    decimal dAmt = Convert.ToDecimal(txtQty.Text) * rate;

        //    lblAmt.Text = dAmt.ToString("f2");





        //    }

        #region Multipiicatiom
        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            if (txtQty1.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be left blank.');", true);
                return;
            }

            if (Convert.ToDecimal(txtQty1.Text) <= Convert.ToDecimal(lblAQty1.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty1.Text) * Convert.ToDecimal(lblRate1.Text);
                lblAmount1.Text = dCalTotal.ToString("" + ratesetting + "");
                lblTax.InnerText = (Convert.ToDecimal(lblAmount1.Text) * Convert.ToDecimal(0.05)).ToString("" + ratesetting + "");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax.InnerText = (Convert.ToDecimal(lblRate1.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty1.Text = "0";
            }

            GSTValGrand();

        }
        protected void txtQty2_TextChanged(object sender, EventArgs e)
        {
            if (txtQty2.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be left blank.');", true);
                return;
            }
            if (Convert.ToDecimal(txtQty2.Text) <= Convert.ToDecimal(lblAQty2.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty2.Text) * Convert.ToDecimal(lblRate2.Text);
                lblAmount2.Text = dCalTotal.ToString("" + ratesetting + "");
                lblTax1.InnerText = (Convert.ToDecimal(lblAmount2.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax1.InnerText = (Convert.ToDecimal(lblRate2.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty2.Text = "0";
            }
            GSTValGrand();
        }
        protected void txtQty3_TextChanged(object sender, EventArgs e)
        {
            if (txtQty3.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be left blank.');", true);
                return;
            }
            if (Convert.ToDecimal(txtQty3.Text) <= Convert.ToDecimal(lblAQty3.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty3.Text) * Convert.ToDecimal(lblRate3.Text);
                lblAmount3.Text = dCalTotal.ToString("f2");
                lblTax2.InnerText = (Convert.ToDecimal(lblAmount3.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax2.InnerText = (Convert.ToDecimal(lblRate3.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty3.Text = "0";
            }

            GSTValGrand();
        }

        protected void txtQty4_TextChanged(object sender, EventArgs e)
        {

            if (txtQty4.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be left blank.');", true);
                return;
            }
            if (Convert.ToDecimal(txtQty4.Text) <= Convert.ToDecimal(lblAQty4.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty4.Text) * Convert.ToDecimal(lblRate4.Text);
                lblAmount4.Text = dCalTotal.ToString("f2");
                lblTax3.InnerText = (Convert.ToDecimal(lblAmount4.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax3.InnerText = (Convert.ToDecimal(lblRate4.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty4.Text = "0";
            }

            GSTValGrand();
        }

        protected void txtQty5_TextChanged(object sender, EventArgs e)
        {
            if (txtQty5.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be left blank.');", true);
                return;
            }
            if (Convert.ToDecimal(txtQty5.Text) <= Convert.ToDecimal(lblAQty5.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty5.Text) * Convert.ToDecimal(lblRate5.Text);
                lblAmount5.Text = dCalTotal.ToString("f2");
                lblTax4.InnerText = (Convert.ToDecimal(lblAmount5.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax4.InnerText = (Convert.ToDecimal(lblRate5.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty5.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty6_TextChanged(object sender, EventArgs e)
        {
            if (txtQty6.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be left blank.');", true);
                return;
            }
            if (Convert.ToDecimal(txtQty6.Text) <= Convert.ToDecimal(lblAQty6.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty6.Text) * Convert.ToDecimal(lblRate6.Text);
                lblAmount6.Text = dCalTotal.ToString("f2");
                lblTax5.InnerText = (Convert.ToDecimal(lblAmount6.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax5.InnerText = (Convert.ToDecimal(lblRate6.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty6.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty7_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty7.Text) <= Convert.ToDecimal(lblAQty7.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty7.Text) * Convert.ToDecimal(lblRate7.Text);
                lblAmount7.Text = dCalTotal.ToString("f2");
                lblTax6.InnerText = (Convert.ToDecimal(lblAmount7.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax6.InnerText = (Convert.ToDecimal(lblRate7.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty7.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty8_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty8.Text) <= Convert.ToDecimal(lblAQty8.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty8.Text) * Convert.ToDecimal(lblRate8.Text);
                lblAmount8.Text = dCalTotal.ToString("f2");
                lblTax7.InnerText = (Convert.ToDecimal(lblAmount8.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax7.InnerText = (Convert.ToDecimal(lblRate8.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty8.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty9_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty9.Text) <= Convert.ToDecimal(lblAQty9.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty9.Text) * Convert.ToDecimal(lblRate9.Text);
                lblAmount9.Text = dCalTotal.ToString("f2");
                lblTax8.InnerText = (Convert.ToDecimal(lblAmount9.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax8.InnerText = (Convert.ToDecimal(lblRate9.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty9.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty10_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty10.Text) <= Convert.ToDecimal(lblAQty10.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty10.Text) * Convert.ToDecimal(lblRate10.Text);
                lblAmount10.Text = dCalTotal.ToString("f2");
                lblTax9.InnerText = (Convert.ToDecimal(lblAmount10.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax9.InnerText = (Convert.ToDecimal(lblRate10.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty10.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty11_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty11.Text) <= Convert.ToDecimal(lblAQty11.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty11.Text) * Convert.ToDecimal(lblRate11.Text);
                lblAmount11.Text = dCalTotal.ToString("f2");
                lblTax10.InnerText = (Convert.ToDecimal(lblAmount11.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax10.InnerText = (Convert.ToDecimal(lblRate11.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty11.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty12_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty12.Text) <= Convert.ToDecimal(lblAQty12.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty12.Text) * Convert.ToDecimal(lblRate12.Text);
                lblAmount12.Text = dCalTotal.ToString("f2");
                lblTax11.InnerText = (Convert.ToDecimal(lblAmount12.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax11.InnerText = (Convert.ToDecimal(lblRate12.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty12.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty13_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty13.Text) <= Convert.ToDecimal(lblAQty13.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty13.Text) * Convert.ToDecimal(lblRate13.Text);
                lblAmount13.Text = dCalTotal.ToString("f2");
                lblTax12.InnerText = (Convert.ToDecimal(lblAmount13.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax12.InnerText = (Convert.ToDecimal(lblRate13.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty13.Text = "0";
            }

            GSTValGrand();
        }

        protected void txtQty14_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty14.Text) <= Convert.ToDecimal(lblAQty14.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty14.Text) * Convert.ToDecimal(lblRate14.Text);
                lblAmount14.Text = dCalTotal.ToString("f2");
                lblTax13.InnerText = (Convert.ToDecimal(lblAmount14.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax13.InnerText = (Convert.ToDecimal(lblRate14.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty14.Text = "0";
            }

            GSTValGrand();
        }
        protected void txtQty15_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQty15.Text) <= Convert.ToDecimal(lblAQty15.Text))
            {
                decimal dCalTotal = Convert.ToDecimal(txtQty15.Text) * Convert.ToDecimal(lblRate15.Text);
                lblAmount15.Text = dCalTotal.ToString("f2");
                lblTax14.InnerText = (Convert.ToDecimal(lblAmount15.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //if (sTableName.ToString().ToLower() == "co5")
                //{
                //    lblTax13.InnerText = (Convert.ToDecimal(lblRate14.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                //}
                //Calcuate();
            }
            else
            {
                txtQty15.Text = "0";
            }

            GSTValGrand();
        }
        #endregion
        #region cancel
        protected void btncal_Click(object sender, EventArgs e)
        {
            tr.Visible = false;
            lblAmount1.Text = "0";
            //Calcuate();
            lblAmount1.Text = "0";
            Session["Icount"] = "1";
            txtQty1.Text = "0";
            lblRate1.Text = "0";
            GSTValGrand();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            tr1.Visible = false;
            lblAmount2.Text = "";
            //Calcuate();
            lblAmount2.Text = "0";

            txtQty2.Text = "0";
            lblRate2.Text = "0";
            GSTValGrand();
            //Session["Icount"] = "1";
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            tr2.Visible = false;
            lblAmount3.Text = "0";
            //Calcuate();
            lblAmount3.Text = "0";

            txtQty3.Text = "0";
            lblRate3.Text = "0";
            GSTValGrand();
            //  Session["Icount"] = "1";
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            tr3.Visible = false;
            lblAmount4.Text = "0";
            //Calcuate();
            lblAmount4.Text = "0";

            txtQty4.Text = "0";
            lblRate4.Text = "0";
            GSTValGrand();
            //  Session["Icount"] = "1";
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            tr4.Visible = false;
            lblAmount5.Text = "0";
            //Calcuate();


            lblAmount5.Text = "0";
            txtQty5.Text = "0";
            lblRate5.Text = "0";
            GSTValGrand();
            // Session["Icount"] = "1";
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            tr5.Visible = false;

            lblAmount6.Text = "0";
            //Calcuate();
            lblAmount6.Text = "0";
            txtQty6.Text = "0";
            lblRate6.Text = "0";
            GSTValGrand();
            // Session["Icount"] = "1";
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            tr6.Visible = false;
            lblAmount7.Text = "0";
            //Calcuate();

            txtQty7.Text = "0";
            lblRate7.Text = "0";
            lblAmount7.Text = "0";

            GSTValGrand();
            //  Session["Icount"] = "";
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            tr7.Visible = false;
            lblAmount8.Text = "0";
            //Calcuate();

            txtQty8.Text = "0";
            lblRate8.Text = "0";
            lblAmount8.Text = "0";

            GSTValGrand();
            //  Session["Icount"] = "1";
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            tr8.Visible = false;
            lblAmount9.Text = "0";
            //Calcuate();

            txtQty9.Text = "0";
            lblRate9.Text = "0";
            lblAmount9.Text = "0";

            GSTValGrand();
            //  Session["Icount"] = "1";
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            tr9.Visible = false;
            lblAmount10.Text = "0";
            //Calcuate();
            lblAmount10.Text = "0";
            txtQty10.Text = "0";
            lblRate10.Text = "0";
            GSTValGrand();
            // Session["Icount"] = "1";
        }
        protected void LinkButton20_Click(object sender, EventArgs e)
        {
            tr10.Visible = false;
            lblAmount11.Text = "0";
            //Calcuate();
            lblAmount11.Text = "0";
            txtQty11.Text = "0";
            lblRate11.Text = "0";
            GSTValGrand();
            //  Session["Icount"] = "1";
        }

        protected void LinkButton22_Click(object sender, EventArgs e)
        {
            tr11.Visible = false;
            lblAmount12.Text = "0";
            //Calcuate();
            lblAmount12.Text = "0";
            txtQty12.Text = "0";
            lblRate12.Text = "0";
            GSTValGrand();
            // Session["Icount"] = "1";
        }

        protected void LinkButton24_Click(object sender, EventArgs e)
        {
            tr12.Visible = false;
            lblAmount13.Text = "0";
            //Calcuate();
            lblAmount13.Text = "0";
            txtQty13.Text = "0";
            lblRate13.Text = "0";
            GSTValGrand();
            // Session["Icount"] = "1";
        }

        protected void LinkButton26_Click(object sender, EventArgs e)
        {
            tr13.Visible = false;
            lblAmount14.Text = "0";
            //Calcuate();
            lblAmount14.Text = "0";
            txtQty14.Text = "0";
            lblRate14.Text = "0";
            GSTValGrand();
            //  Session["Icount"] = "1";
        }

        protected void LinkButton28_Click(object sender, EventArgs e)
        {
            tr14.Visible = false;
            lblAmount15.Text = "0";
            //Calcuate();
            lblAmount15.Text = "0";
            txtQty15.Text = "0";
            lblRate15.Text = "0";

            GSTValGrand();
            // Session["Icount"] = "1";
        }
        #endregion
        void Calcuate()
        {
            if (lblAmount1.Text == "")
                lblAmount1.Text = "0";
            if (lblAmount2.Text == "")
                lblAmount2.Text = "0";
            if (lblAmount3.Text == "")
                lblAmount3.Text = "0";
            if (lblAmount4.Text == "")
                lblAmount4.Text = "0";
            if (lblAmount5.Text == "")
                lblAmount5.Text = "0";
            if (lblAmount6.Text == "")
                lblAmount6.Text = "0";
            if (lblAmount7.Text == "")
                lblAmount7.Text = "0";
            if (lblAmount8.Text == "")
                lblAmount8.Text = "0";
            if (lblAmount9.Text == "")
                lblAmount9.Text = "0";
            if (lblAmount10.Text == "")
                lblAmount10.Text = "0";
            if (lblAmount11.Text == "")
                lblAmount11.Text = "0";
            if (lblAmount12.Text == "")
                lblAmount12.Text = "0";
            if (lblAmount13.Text == "")
                lblAmount13.Text = "0";
            if (lblAmount14.Text == "")
                lblAmount14.Text = "0";
            if (lblAmount15.Text == "")
                lblAmount15.Text = "0";



            //  txtDiscount_TextChanged();

            dTotal = Convert.ToDecimal(lblAmount1.Text) + Convert.ToDecimal(lblAmount2.Text) + Convert.ToDecimal(lblAmount3.Text) + Convert.ToDecimal(lblAmount4.Text) + Convert.ToDecimal(lblAmount5.Text) + Convert.ToDecimal(lblAmount6.Text) + Convert.ToDecimal(lblAmount7.Text) + Convert.ToDecimal(lblAmount8.Text) + Convert.ToDecimal(lblAmount9.Text) + Convert.ToDecimal(lblAmount10.Text) + Convert.ToDecimal(lblAmount11.Text) + Convert.ToDecimal(lblAmount12.Text) + Convert.ToDecimal(lblAmount13.Text) + Convert.ToDecimal(lblAmount14.Text) + Convert.ToDecimal(lblAmount15.Text);
            lbltotal.Text = dTotal.ToString("" + ratesetting + "");
            lblGrandTotal.Text = lbltotal.Text;
            lbldisplay.InnerText = lbltotal.Text;
            cal();
        }
        private void cal()
        {
            if (txtDiscount.Text != "" && lbltotal.Text != "")
            {
                decimal dDiscount = Convert.ToDecimal(txtDiscount.Text);
                decimal dSubTotal = Convert.ToDecimal(lbltotal.Text);

                decimal dDiscAmt = dSubTotal - ((dDiscount * dSubTotal) / 100);
                lblGrandTotal.Text = dDiscAmt.ToString("" + ratesetting + "");
                lbldisplay.InnerText = lblGrandTotal.Text;
            }

            if (sTableName.ToString().ToLower() == "co6" || sTableName.ToString().ToLower() == "co7")
            {

                var Tax = new[] { lblTax, lblTax1, lblTax2, lblTax3, lblTax4, lblTax5, lblTax6, lblTax7, lblTax8, lblTax9, lblTax10, lblTax11, lblTax12, lblTax13, lblTax14 };

                var Item = new[] { lblItem1, lblItem2, lblItem3, lblItem4, lblItem5, lblItem6, lblItem7, lblItem8, lblItem9, lblItem10, lblItem11, lblItem12, lblItem13, lblItem14, lblItem15 };
                decimal dtaxAmt = 0;

                for (int i = 0; i < 15; i++)
                {
                    if (Item[i].Text.Contains("BR") == true)
                    {
                        Tax[i].InnerText = "0";
                        dtaxAmt += Convert.ToDecimal(Tax[i].InnerText);
                    }

                    else
                    {
                        if (Tax[i].InnerText.Trim() != "")
                        {
                            dtaxAmt += Convert.ToDecimal(Tax[i].InnerText);

                        }
                    }
                }

                txtTax.Text = dtaxAmt.ToString("" + ratesetting + "");

                if (txtDiscount.Text != "" && lbltotal.Text != "")
                {
                    decimal dDiscount = Convert.ToDecimal(txtDiscount.Text);
                    decimal dSubTotal = Convert.ToDecimal(lbltotal.Text);
                    decimal dtax = Convert.ToDecimal(txtTax.Text);

                    decimal dDiscAmt = dtax + dSubTotal - ((dDiscount * dSubTotal) / 100);
                    decimal round = Math.Round(dDiscAmt, 1);
                    lblGrandTotal.Text = round.ToString("" + ratesetting + "");
                    lbldisplay.InnerText = lblGrandTotal.Text;
                }
                else if (txtTax.Text != "0")
                {

                    decimal sub = Convert.ToDecimal(lbltotal.Text);
                    decimal tax = Convert.ToDecimal(txtTax.Text);



                    decimal round = Math.Round((sub + tax), 1);
                    lblGrandTotal.Text = round.ToString("" + ratesetting + "");
                    lbldisplay.InnerText = lblGrandTotal.Text;
                }
            }

        }

        protected void drppayment_selectedindex(object sender, EventArgs e)
        {

            DataSet getpaymodediscount = objbs.chkpaymodedisc(drpPayment.SelectedValue);
            if (getpaymodediscount.Tables[0].Rows.Count > 0)
            {
                lblpaymodesic.Text = getpaymodediscount.Tables[0].Rows[0]["Discount"].ToString();
            }
            else
            {
                lblpaymodesic.Text = "N";
                chkdisc.Checked = false;
                chkdisc.Enabled = false;

            }

            DataSet getsalestypeamargin = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);
            if (getsalestypeamargin.Tables[0].Rows.Count > 0)
            {
                lblmargin.Text = getsalestypeamargin.Tables[0].Rows[0]["Margin"].ToString();
                lblmargintax.Text = getsalestypeamargin.Tables[0].Rows[0]["GST"].ToString();
                if (drpPayment.SelectedValue == "15")
                {
                    lblpaygate.Text = getsalestypeamargin.Tables[0].Rows[0]["PaymentGatway"].ToString();
                }
                else
                {
                    lblpaygate.Text = "0";
                }

                //if (drpsalestype.SelectedValue == "1")
                //{
                //    if (drpPayment.SelectedValue == "1" || drpPayment.SelectedValue == "4" || drpPayment.SelectedValue == "16")
                //    {

                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                //        return;
                //    }
                //}
                //else
                //{
                //    if (drpPayment.SelectedValue == "1" || drpPayment.SelectedValue == "4" || drpPayment.SelectedValue == "16")
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                //        return;
                //    }


                //}
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add item's.Please Contact Administrator!!!.Thank you!!!');", true);
                return;
            }

            if (lblpaymodesic.Text == "Y")
            {
                chkdisc.Enabled = true;
            }
            else
            {
                DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                if (getAttenderdisc.Tables[0].Rows.Count > 0)
                {
                    attednertype.DataSource = getAttenderdisc.Tables[0];
                    attednertype.DataTextField = "AttenderName";
                    attednertype.DataValueField = "AttenderID";
                    attednertype.DataBind();
                    attednertype.Items.Insert(0, "Select Disc-Att");

                }
                chkdisc.Checked = false;
                chkdisc.Enabled = false;
                txtdiscotp.Enabled = false;
                txtdiscotp.Text = "";
                txtDiscount.Text = "0";
                attednertype.Enabled = false;
                txtDiscount.Enabled = false;
                chkdisc.Enabled = false;
                chkdisc.Checked = false;
                txtdiscotp.Text = "";
                txtdiscotp.Enabled = false;
                drpdischk.Items.Clear();
                drpdischk.ClearSelection();
                txtdiscotp.Attributes.Clear();
                txtdiscou_TextChanged(sender, e);
                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                //  return;
            }

            //if (drpPayment.SelectedValue == "7" || drpPayment.SelectedValue == "8" || drpPayment.SelectedValue == "9" || drpPayment.SelectedValue == "10")
            //{
            //    txtDiscount.Text = "25";
            //    txtDiscount_TextChanged(sender, e);
            //}
            //else
            //{
            //    txtDiscount.Text = "0";
            //    txtDiscount_TextChanged(sender, e);
            //}
        }


        protected void onlineamount_chnaged(object sender, EventArgs e)
        {
            txtonlineamount.Text = "0";
            //double oriamount = Convert.ToDouble(lbldisplay.InnerText);
            //double onlineamount = Convert.ToDouble(txtonlineamount.Text);


            //double diff = oriamount - onlineamount;

            //lbldisco.Text = diff.ToString("0.00");

            //txtdiscou_TextChanged(sender, e);




        }

        protected void drpsalestype_selectedindex(object sender, EventArgs e)
        {

            txtonlineamount.Enabled = false;
            txtonlineamount.Text = "0";

            DataSet paymode = objbs.PaymodevaluesNew(drpsalestype.SelectedValue);
            if (paymode.Tables[0].Rows.Count > 0)
            {
                drpPayment.DataSource = paymode.Tables[0];
                drpPayment.DataTextField = "PayMode";
                drpPayment.DataValueField = "Value";
                drpPayment.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                return;
            }


            DataSet getpaymodediscount = objbs.chkpaymodedisc(drpPayment.SelectedValue);
            if (getpaymodediscount.Tables[0].Rows.Count > 0)
            {
                lblpaymodesic.Text = getpaymodediscount.Tables[0].Rows[0]["Discount"].ToString();
            }
            else
            {
                lblpaymodesic.Text = "N";
                chkdisc.Checked = false;
                chkdisc.Enabled = false;

            }

            if (lblpaymodesic.Text == "Y")
            {
                chkdisc.Enabled = true;
            }
            else
            {
                DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                if (getAttenderdisc.Tables[0].Rows.Count > 0)
                {
                    attednertype.DataSource = getAttenderdisc.Tables[0];
                    attednertype.DataTextField = "AttenderName";
                    attednertype.DataValueField = "AttenderID";
                    attednertype.DataBind();
                    attednertype.Items.Insert(0, "Select Disc-Att");

                }
                chkdisc.Checked = false;
                chkdisc.Enabled = false;
                txtdiscotp.Enabled = false;
                txtdiscotp.Text = "";
                txtDiscount.Text = "0";
                attednertype.Enabled = false;
                txtDiscount.Enabled = false;
                chkdisc.Enabled = false;
                chkdisc.Checked = false;
                txtdiscotp.Text = "";
                txtdiscotp.Enabled = false;
                drpdischk.Items.Clear();
                drpdischk.ClearSelection();
                txtdiscotp.Attributes.Clear();
                txtdiscou_TextChanged(sender, e);
                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                //  return;
            }

            DataSet getsalestypeamargin = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);
            if (getsalestypeamargin.Tables[0].Rows.Count > 0)
            {
                lblmargin.Text = getsalestypeamargin.Tables[0].Rows[0]["Margin"].ToString();
                lblmargintax.Text = getsalestypeamargin.Tables[0].Rows[0]["GST"].ToString();
                lblisnormal.Text = getsalestypeamargin.Tables[0].Rows[0]["Isnormal"].ToString();
                isdiscchk.Text = getsalestypeamargin.Tables[0].Rows[0]["Isdiscount"].ToString();
                isdiscchkwithbill.Text = getsalestypeamargin.Tables[0].Rows[0]["Isbillwisedisc"].ToString();
                lblisinclusiverate.Text = getsalestypeamargin.Tables[0].Rows[0]["IsInclusiveRate"].ToString();
                lblordercount.Text = getsalestypeamargin.Tables[0].Rows[0]["OrderCount"].ToString();
                lblordertype.Text = getsalestypeamargin.Tables[0].Rows[0]["OrderType"].ToString();


                lblattenderid.Text = getsalestypeamargin.Tables[0].Rows[0]["Attenderid"].ToString();
                lblattenderpassword.Text = getsalestypeamargin.Tables[0].Rows[0]["attenderpwd"].ToString();
                lbldiscid.Text = getsalestypeamargin.Tables[0].Rows[0]["Discid"].ToString();

                //if(lblisinclusiverate.Text=="Y")
                //{
                //    txtonlineamount.Enabled = true;
                //    txtonlineamount.Text = "0";
                //}
                //else
                //{
                //    txtonlineamount.Enabled = false;
                //    txtonlineamount.Text = "0";
                //}

                if (isdiscchk.Text == "Y")
                {
                    chkdisc.Enabled = true;
                    txtDiscount.Text = "0";

                    if (lblattenderid.Text != "0")
                    {
                        chkdisc.Checked = true;
                        chkdisc.Enabled = false;
                        attednertype.SelectedValue = lblattenderid.Text;

                        if (lblattenderid.Text != "0")
                        {
                            otp_chnaged(sender, e);
                        }
                        //txtdiscotp.Text = lblattenderpassword.Text;
                        //drpdischk.SelectedValue = lbldiscid.Text;

                    }
                    else
                    {
                        chkdisc.Checked = false;
                        drpdischk.Items.Clear();
                        drpdischk.ClearSelection();
                        txtdiscotp.Attributes.Clear();
                        txtdiscotp.Text = "";
                        DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                        if (getAttenderdisc.Tables[0].Rows.Count > 0)
                        {
                            attednertype.DataSource = getAttenderdisc.Tables[0];
                            attednertype.DataTextField = "AttenderName";
                            attednertype.DataValueField = "AttenderID";
                            attednertype.DataBind();
                            attednertype.Items.Insert(0, "Select Disc-Att");

                        }

                    }


                }
                else if (isdiscchkwithbill.Text == "Y")
                {
                    DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                    if (getAttenderdisc.Tables[0].Rows.Count > 0)
                    {
                        attednertype.DataSource = getAttenderdisc.Tables[0];
                        attednertype.DataTextField = "AttenderName";
                        attednertype.DataValueField = "AttenderID";
                        attednertype.DataBind();
                        attednertype.Items.Insert(0, "Select Disc-Att");

                    }
                    txtdiscotp.Enabled = false;
                    txtdiscotp.Text = "";
                    txtDiscount.Text = "0";
                    attednertype.Enabled = false;
                    txtDiscount.Enabled = false;
                    chkdisc.Enabled = false;
                    chkdisc.Checked = false;
                    txtdiscotp.Text = "";
                    txtdiscotp.Enabled = false;
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                    txtdiscotp.Attributes.Clear();
                    txtdiscou_TextChanged(sender, e);
                }

                if (isdiscchk.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill No Not Generated.Please LogOut and Login Again!!!');", true);
                    return;
                }

                if (lblisnormal.Text == "Y")
                {
                    Chkbills.Visible = false;
                    chkgivenby.Visible = true;
                }
                else
                {
                    Chkbills.Visible = true;
                    chkgivenby.Visible = false;
                }




                if (lblisnormal.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill No Not Generated.Please Try Again Later!!!');", true);
                    return;
                }
                else
                {

                    DataSet ds = objbs.SalesBillno("tblSales_" + sTableName, lblisnormal.Text);
                    if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtBillNo.Text = "1";
                    else
                        txtBillNo.Text = ds.Tables[0].Rows[0]["billno"].ToString();

                    DataSet dss = objbs.dailybillseries("tblSales_" + sTableName, "BillDate");
                    if (dss.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtdailybillno.Text = "1";
                    else
                        txtdailybillno.Text = dss.Tables[0].Rows[0]["billno"].ToString();

                    txtfullbillno.Text = txtbillcode.Text + '-' + txtdailybillno.Text;

                    if (Billgenerate == "1")
                    {
                        txtBillNo.Visible = false;
                        txtfullbillno.Visible = true;

                    }
                    else if (Billgenerate == "2")
                    {
                        txtBillNo.Visible = true;
                        txtfullbillno.Visible = false;
                    }
                }

                if (drpPayment.SelectedValue == "17")
                {
                    lblpaygate.Text = getsalestypeamargin.Tables[0].Rows[0]["PaymentGatway"].ToString();
                }
                else
                {
                    lblpaygate.Text = "0";
                }

                //if (drpsalestype.SelectedValue == "1")
                //{
                //    if (drpPayment.SelectedValue == "1" || drpPayment.SelectedValue == "4" || drpPayment.SelectedValue == "16")
                //    {

                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                //        return;
                //    }
                //}
                //else
                //{
                //    if (drpPayment.SelectedValue == "1" || drpPayment.SelectedValue == "4" || drpPayment.SelectedValue == "16")
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                //        return;
                //    }


                //}




            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add item's.Please Contact Administrator!!!.Thank you!!!');", true);
                return;
            }
        }



        protected void ddlApproved_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlApproved.SelectedValue == "Select")
            //{
            //    txtDiscount.Enabled = false;
            //}
            //else
            //{
            //    txtDiscount.Enabled = true;
            //}
            //GSTVal();

        }
        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (lblattenderid.Text == "0")
            {
                if (lblpaymodesic.Text == "Y")
                {
                    chkdisc.Enabled = true;
                }
                else
                {
                    DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                    if (getAttenderdisc.Tables[0].Rows.Count > 0)
                    {
                        attednertype.DataSource = getAttenderdisc.Tables[0];
                        attednertype.DataTextField = "AttenderName";
                        attednertype.DataValueField = "AttenderID";
                        attednertype.DataBind();
                        attednertype.Items.Insert(0, "Select Disc-Att");

                    }
                    chkdisc.Checked = false;
                    chkdisc.Enabled = false;
                    txtdiscotp.Enabled = false;
                    txtdiscotp.Text = "";
                    txtDiscount.Text = "0";
                    attednertype.Enabled = false;
                    txtDiscount.Enabled = false;
                    chkdisc.Enabled = false;
                    chkdisc.Checked = false;
                    txtdiscotp.Text = "";
                    txtdiscotp.Enabled = false;
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                    txtdiscotp.Attributes.Clear();
                    txtdiscou_TextChanged(sender, e);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                    return;
                }
            }

            if (chkdisc.Checked == true)
            {

                if (attednertype.SelectedValue == "Select Disc-Att")
                {
                    txtdiscotp.Text = "";
                    txtDiscount.Enabled = false;
                    txtDiscount.Text = "0";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Approval Attender.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                if (txtdiscotp.Text == "")
                {
                    txtDiscount.Enabled = false;
                    txtDiscount.Text = "0";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Password is Incorrect.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                if (txtDiscount.Text != "" && lbltotal.Text != "")
                {
                    // if (Convert.ToDouble(txtDiscount.Text) <= Convert.ToDouble(lblmaxdiscount.Text))
                    {
                        txtDiscount.Enabled = false;
                        txtdiscou_TextChanged(sender, e);
                    }
                    //else
                    //{
                    //    txtDiscount.Text = "0";
                    //    txtDiscount.Enabled = true;
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Maximum Discount Exists.Please Contact Administrator!!!.Thank you!!!');", true);
                    //    return;
                    //}

                }
            }
            //{
            //    decimal sub = Convert.ToDecimal(lbltotal.Text);
            //    decimal tax = Convert.ToDecimal(txtTax.Text);



            //    decimal round = Math.Round((sub + tax), 1);
            //    lblGrandTotal.Text = round.ToString(""+ratesetting+"");
            //    decimal dDiscount = Convert.ToDecimal(txtDiscount.Text);
            //    decimal dSubTotal = Convert.ToDecimal(lblGrandTotal.Text);

            //    decimal dDiscAmt = dSubTotal - ((dDiscount * dSubTotal) / 100);
            //    lblGrandTotal.Text = dDiscAmt.ToString(""+ratesetting+"");
            //    lbldisplay.InnerText = dDiscAmt.ToString("f2");


            //    if (lblAmount1.Text == "")
            //        lblAmount1.Text = "0";
            //    if (lblAmount2.Text == "")
            //        lblAmount2.Text = "0";
            //    if (lblAmount3.Text == "")
            //        lblAmount3.Text = "0";
            //    if (lblAmount4.Text == "")
            //        lblAmount4.Text = "0";
            //    if (lblAmount5.Text == "")
            //        lblAmount5.Text = "0";
            //    if (lblAmount6.Text == "")
            //        lblAmount6.Text = "0";
            //    if (lblAmount7.Text == "")
            //        lblAmount7.Text = "0";
            //    if (lblAmount8.Text == "")
            //        lblAmount8.Text = "0";
            //    if (lblAmount9.Text == "")
            //        lblAmount9.Text = "0";
            //    if (lblAmount10.Text == "")
            //        lblAmount10.Text = "0";
            //    if (lblAmount11.Text == "")
            //        lblAmount11.Text = "0";
            //    if (lblAmount12.Text == "")
            //        lblAmount12.Text = "0";
            //    if (lblAmount13.Text == "")
            //        lblAmount13.Text = "0";
            //    if (lblAmount14.Text == "")
            //        lblAmount14.Text = "0";
            //    if (lblAmount15.Text == "")
            //        lblAmount15.Text = "0";


            //    if (txtQty1.Text == "")
            //        txtQty1.Text = "0";
            //    if (txtQty2.Text == "")
            //        txtQty2.Text = "0";
            //    if (txtQty3.Text == "")
            //        txtQty3.Text = "0";
            //    if (txtQty4.Text == "")
            //        txtQty4.Text = "0";
            //    if (txtQty5.Text == "")
            //        txtQty5.Text = "0";
            //    if (txtQty6.Text == "")
            //        txtQty6.Text = "0";
            //    if (txtQty7.Text == "")
            //        txtQty7.Text = "0";
            //    if (txtQty8.Text == "")
            //        txtQty8.Text = "0";
            //    if (txtQty9.Text == "")
            //        txtQty9.Text = "0";
            //    if (txtQty10.Text == "")
            //        txtQty10.Text = "0";
            //    if (txtQty11.Text == "")
            //        txtQty11.Text = "0";
            //    if (txtQty12.Text == "")
            //        txtQty12.Text = "0";
            //    if (txtQty13.Text == "")
            //        txtQty13.Text = "0";
            //    if (txtQty14.Text == "")
            //        txtQty14.Text = "0";
            //    if (txtQty15.Text == "")
            //        txtQty15.Text = "0";

            //    if (lblRate1.Text == "")
            //        lblRate1.Text = "0";
            //    if (lblRate2.Text == "")
            //        lblRate2.Text = "0";
            //    if (lblRate3.Text == "")
            //        lblRate3.Text = "0";
            //    if (lblRate4.Text == "")
            //        lblRate4.Text = "0";
            //    if (lblRate5.Text == "")
            //        lblRate5.Text = "0";
            //    if (lblRate6.Text == "")
            //        lblRate6.Text = "0";
            //    if (lblRate7.Text == "")
            //        lblRate7.Text = "0";
            //    if (lblRate8.Text == "")
            //        lblRate8.Text = "0";
            //    if (lblRate9.Text == "")
            //        lblRate9.Text = "0";
            //    if (lblRate10.Text == "")
            //        lblRate10.Text = "0";
            //    if (lblRate11.Text == "")
            //        lblRate11.Text = "0";
            //    if (lblRate12.Text == "")
            //        lblRate12.Text = "0";
            //    if (lblRate13.Text == "")
            //        lblRate13.Text = "0";
            //    if (lblRate14.Text == "")
            //        lblRate14.Text = "0";
            //    if (lblRate15.Text == "")
            //        lblRate15.Text = "0";


            //    if (lbltaxam1.Text == "")
            //        lbltaxam1.Text = "0";
            //    if (lbltaxam2.Text == "")
            //        lbltaxam2.Text = "0";
            //    if (lbltaxam3.Text == "")
            //        lbltaxam3.Text = "0";
            //    if (lbltaxam4.Text == "")
            //        lbltaxam4.Text = "0";
            //    if (lbltaxam5.Text == "")
            //        lbltaxam5.Text = "0";
            //    if (lbltaxam6.Text == "")
            //        lbltaxam6.Text = "0";
            //    if (lbltaxam7.Text == "")
            //        lbltaxam7.Text = "0";
            //    if (lbltaxam8.Text == "")
            //        lbltaxam8.Text = "0";
            //    if (lbltaxam9.Text == "")
            //        lbltaxam9.Text = "0";
            //    if (lbltaxam10.Text == "")
            //        lbltaxam10.Text = "0";
            //    if (lbltaxam11.Text == "")
            //        lbltaxam11.Text = "0";
            //    if (lbltaxam12.Text == "")
            //        lbltaxam12.Text = "0";
            //    if (lbltaxam13.Text == "")
            //        lbltaxam13.Text = "0";
            //    if (lbltaxam14.Text == "")
            //        lbltaxam14.Text = "0";
            //    if (lbltaxam15.Text == "")
            //        lbltaxam15.Text = "0";


            //    decimal ngst1 = Convert.ToDecimal(txtQty1.Text) * Convert.ToDecimal(lblRate1.Text);
            //    decimal gsthaf1 = Convert.ToDecimal(lbltaxam1.Text) / 2;
            //    decimal ngstamount1 = (Convert.ToDecimal(ngst1) * Convert.ToDecimal(gsthaf1)) / 100;
            //    decimal dTotal1 = ngstamount1 + ngstamount1 + ngst1;
            //    decimal gstamt1 = ngstamount1 + ngstamount1;

            //    decimal ngst2 = Convert.ToDecimal(txtQty2.Text) * Convert.ToDecimal(lblRate2.Text);
            //    decimal gsthaf2 = Convert.ToDecimal(lbltaxam2.Text) / 2;
            //    decimal ngstamount2 = (Convert.ToDecimal(ngst2) * Convert.ToDecimal(gsthaf2)) / 100;
            //    decimal dTotal2 = ngstamount2 + ngstamount2 + ngst2;
            //    decimal gstamt2 = ngstamount2 + ngstamount2;

            //    decimal ngst3 = Convert.ToDecimal(txtQty3.Text) * Convert.ToDecimal(lblRate3.Text);
            //    decimal gsthaf3 = Convert.ToDecimal(lbltaxam3.Text) / 2;
            //    decimal ngstamount3 = (Convert.ToDecimal(ngst3) * Convert.ToDecimal(gsthaf3)) / 100;
            //    decimal dTotal3 = ngstamount3 + ngstamount3 + ngst3;
            //    decimal gstamt3 = ngstamount3 + ngstamount3;

            //    decimal ngst4 = Convert.ToDecimal(txtQty4.Text) * Convert.ToDecimal(lblRate4.Text);
            //    decimal gsthaf4 = Convert.ToDecimal(lbltaxam4.Text) / 2;
            //    decimal ngstamount4 = (Convert.ToDecimal(ngst4) * Convert.ToDecimal(gsthaf4)) / 100;
            //    decimal dTotal4 = ngstamount4 + ngstamount4 + ngst4;
            //    decimal gstamt4 = ngstamount4 + ngstamount4;

            //    decimal ngst5 = Convert.ToDecimal(txtQty5.Text) * Convert.ToDecimal(lblRate5.Text);
            //    decimal gsthaf5 = Convert.ToDecimal(lbltaxam5.Text) / 2;
            //    decimal ngstamount5 = (Convert.ToDecimal(ngst5) * Convert.ToDecimal(gsthaf5)) / 100;
            //    decimal dTotal5 = ngstamount5 + ngstamount5 + ngst5;
            //    decimal gstamt5 = ngstamount5 + ngstamount5;

            //    decimal ngst6 = Convert.ToDecimal(txtQty6.Text) * Convert.ToDecimal(lblRate6.Text);
            //    decimal gsthaf6 = Convert.ToDecimal(lbltaxam6.Text) / 2;
            //    decimal ngstamount6 = (Convert.ToDecimal(ngst6) * Convert.ToDecimal(gsthaf6)) / 100;
            //    decimal dTotal6 = ngstamount6 + ngstamount6 + ngst6;
            //    decimal gstamt6 = ngstamount6 + ngstamount6;

            //    decimal ngst7 = Convert.ToDecimal(txtQty7.Text) * Convert.ToDecimal(lblRate7.Text);
            //    decimal gsthaf7 = Convert.ToDecimal(lbltaxam7.Text) / 2;
            //    decimal ngstamount7 = (Convert.ToDecimal(ngst7) * Convert.ToDecimal(gsthaf7)) / 100;
            //    decimal dTotal7 = ngstamount7 + ngstamount7 + ngst7;
            //    decimal gstamt7 = ngstamount7 + ngstamount7;

            //    decimal ngst8 = Convert.ToDecimal(txtQty8.Text) * Convert.ToDecimal(lblRate8.Text);
            //    decimal gsthaf8 = Convert.ToDecimal(lbltaxam8.Text) / 2;
            //    decimal ngstamount8 = (Convert.ToDecimal(ngst8) * Convert.ToDecimal(gsthaf8)) / 100;
            //    decimal dTotal8 = ngstamount8 + ngstamount8 + ngst8;
            //    decimal gstamt8 = ngstamount8 + ngstamount8;

            //    decimal ngst9 = Convert.ToDecimal(txtQty9.Text) * Convert.ToDecimal(lblRate9.Text);
            //    decimal gsthaf9 = Convert.ToDecimal(lbltaxam9.Text) / 2;
            //    decimal ngstamount9 = (Convert.ToDecimal(ngst9) * Convert.ToDecimal(gsthaf9)) / 100;
            //    decimal dTotal9 = ngstamount9 + ngstamount9 + ngst9;
            //    decimal gstamt9 = ngstamount9 + ngstamount9;

            //    decimal ngst10 = Convert.ToDecimal(txtQty10.Text) * Convert.ToDecimal(lblRate10.Text);
            //    decimal gsthaf10 = Convert.ToDecimal(lbltaxam10.Text) / 2;
            //    decimal ngstamount10 = (Convert.ToDecimal(ngst10) * Convert.ToDecimal(gsthaf10)) / 100;
            //    decimal dTotal10 = ngstamount10 + ngstamount10 + ngst10;
            //    decimal gstamt10 = ngstamount10 + ngstamount10;

            //    decimal ngst11 = Convert.ToDecimal(txtQty11.Text) * Convert.ToDecimal(lblRate11.Text);
            //    decimal gsthaf11 = Convert.ToDecimal(lbltaxam11.Text) / 2;
            //    decimal ngstamount11 = (Convert.ToDecimal(ngst11) * Convert.ToDecimal(gsthaf11)) / 100;
            //    decimal dTotal11 = ngstamount11 + ngstamount11 + ngst11;
            //    decimal gstamt11 = ngstamount11 + ngstamount11;

            //    decimal ngst12 = Convert.ToDecimal(txtQty12.Text) * Convert.ToDecimal(lblRate12.Text);
            //    decimal gsthaf12 = Convert.ToDecimal(lbltaxam12.Text) / 2;
            //    decimal ngstamount12 = (Convert.ToDecimal(ngst12) * Convert.ToDecimal(gsthaf12)) / 100;
            //    decimal dTotal12 = ngstamount12 + ngstamount12 + ngst12;
            //    decimal gstamt12 = ngstamount12 + ngstamount12;

            //    decimal ngst13 = Convert.ToDecimal(txtQty13.Text) * Convert.ToDecimal(lblRate13.Text);
            //    decimal gsthaf13 = Convert.ToDecimal(lbltaxam13.Text) / 2;
            //    decimal ngstamount13 = (Convert.ToDecimal(ngst13) * Convert.ToDecimal(gsthaf13)) / 100;
            //    decimal dTotal13 = ngstamount13 + ngstamount13 + ngst13;
            //    decimal gstamt13 = ngstamount13 + ngstamount13;

            //    decimal ngst14 = Convert.ToDecimal(txtQty14.Text) * Convert.ToDecimal(lblRate14.Text);
            //    decimal gsthaf14 = Convert.ToDecimal(lbltaxam14.Text) / 2;
            //    decimal ngstamount14 = (Convert.ToDecimal(ngst14) * Convert.ToDecimal(gsthaf14)) / 100;
            //    decimal dTotal14 = ngstamount14 + ngstamount14 + ngst14;
            //    decimal gstamt14 = ngstamount14 + ngstamount14;

            //    decimal ngst15 = Convert.ToDecimal(txtQty15.Text) * Convert.ToDecimal(lblRate15.Text);
            //    decimal gsthaf15 = Convert.ToDecimal(lbltaxam15.Text) / 2;
            //    decimal ngstamount15 = (Convert.ToDecimal(ngst15) * Convert.ToDecimal(gsthaf15)) / 100;
            //    decimal dTotal15 = ngstamount15 + ngstamount15 + ngst15;
            //    decimal gstamt15 = ngstamount15 + ngstamount15;

            //    decimal cgsttotal = Convert.ToDecimal(ngstamount1) + Convert.ToDecimal(ngstamount2) + Convert.ToDecimal(ngstamount3) + Convert.ToDecimal(ngstamount4) + Convert.ToDecimal(ngstamount5) + Convert.ToDecimal(ngstamount6) + Convert.ToDecimal(ngstamount7) + Convert.ToDecimal(ngstamount8) + Convert.ToDecimal(ngstamount9) + Convert.ToDecimal(ngstamount10) + Convert.ToDecimal(ngstamount11) + Convert.ToDecimal(ngstamount12) + Convert.ToDecimal(ngstamount13) + Convert.ToDecimal(ngstamount14) + Convert.ToDecimal(ngstamount15);

            //    decimal Sgsttotal = Convert.ToDecimal(ngstamount1) + Convert.ToDecimal(ngstamount2) + Convert.ToDecimal(ngstamount3) + Convert.ToDecimal(ngstamount4) + Convert.ToDecimal(ngstamount5) + Convert.ToDecimal(ngstamount6) + Convert.ToDecimal(ngstamount7) + Convert.ToDecimal(ngstamount8) + Convert.ToDecimal(ngstamount9) + Convert.ToDecimal(ngstamount10) + Convert.ToDecimal(ngstamount11) + Convert.ToDecimal(ngstamount12) + Convert.ToDecimal(ngstamount13) + Convert.ToDecimal(ngstamount14) + Convert.ToDecimal(ngstamount15);

            //    decimal sstortal = Convert.ToDecimal(dTotal1) + Convert.ToDecimal(dTotal2) + Convert.ToDecimal(dTotal3) + Convert.ToDecimal(dTotal4) + Convert.ToDecimal(dTotal5) + Convert.ToDecimal(dTotal6) + Convert.ToDecimal(dTotal7) + Convert.ToDecimal(dTotal8) + Convert.ToDecimal(dTotal9) + Convert.ToDecimal(dTotal10) + Convert.ToDecimal(dTotal11) + Convert.ToDecimal(dTotal12) + Convert.ToDecimal(dTotal13) + Convert.ToDecimal(dTotal14) + Convert.ToDecimal(dTotal15);

            //    lblcgst.Text = cgsttotal.ToString("0.00");
            //    lblsgst.Text = Sgsttotal.ToString("0.00");
            //    lblsubttl.Text = (sstortal).ToString("0.00");

            //    decimal dTotal1old = Convert.ToDecimal(lblAmount1.Text) + Convert.ToDecimal(lblAmount2.Text) + Convert.ToDecimal(lblAmount3.Text) + Convert.ToDecimal(lblAmount4.Text) + Convert.ToDecimal(lblAmount5.Text) + Convert.ToDecimal(lblAmount6.Text) + Convert.ToDecimal(lblAmount7.Text) + Convert.ToDecimal(lblAmount8.Text) + Convert.ToDecimal(lblAmount9.Text) + Convert.ToDecimal(lblAmount10.Text) + Convert.ToDecimal(lblAmount11.Text) + Convert.ToDecimal(lblAmount12.Text) + Convert.ToDecimal(lblAmount13.Text) + Convert.ToDecimal(lblAmount14.Text) + Convert.ToDecimal(lblAmount15.Text);
            //    lbltotal.Text = dTotal1old.ToString("f2");

            //    lblGrandTotal.Text = (sstortal).ToString("f2");
            //    lbldisplay.InnerText = (sstortal).ToString("f2");
            //    decimal dis = 0;

            //    decimal disamt = 0;

            //    decimal granddisamt = 0;
            //    if (txtDiscount.Text != "0" || txtDiscount.Text != "")
            //    {
            //        dis = ((Convert.ToDecimal(lbltotal.Text) * Convert.ToDecimal(txtDiscount.Text)) / 100);

            //        disamt = Convert.ToDecimal(lbltotal.Text) - dis;

            //        granddisamt = disamt + cgsttotal + Sgsttotal;

            //        lblGrandTotal.Text = (granddisamt).ToString("f2");
            //        lbldisplay.InnerText = (granddisamt).ToString("f2");
            //    }
            //    else
            //    {
            //        lblGrandTotal.Text = (sstortal - dis).ToString("f2");
            //        lbldisplay.InnerText = (sstortal - dis).ToString("f2");
            //    }


            //}
            //else
            //{
            //    GSTValGrand();
            //}


        }

        protected void txtAdvance_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                decimal dDiscount = Convert.ToDecimal(txtDiscount.Text);
                decimal dSubTotal = Convert.ToDecimal(lbltotal.Text);
                decimal Advance = Convert.ToDecimal(txtAdvance.Text);
                decimal dDiscAmt = dSubTotal - ((dDiscount * dSubTotal) / 100);
                decimal dAmount = dDiscAmt - Advance;
                lblGrandTotal.Text = dAmount.ToString("" + ratesetting + "");
                lbldisplay.InnerText = dAmount.ToString("" + ratesetting + "");
            }
        }



        protected void Delivery_checked(object sender, EventArgs e)
        {
            if (chkdelivery.Checked == true)
            {
                txtaddress.Visible = true;
            }
            else
            {
                txtaddress.Visible = false;
            }

        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string OnlineOrderId = "0";

            #region CHECK QTY

            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;
            dtraw.Columns.Add("Categoryid");
            dtraw.Columns.Add("Categoryuserid");
            dtraw.Columns.Add("Item");
            dtraw.Columns.Add("Aqty");
            dtraw.Columns.Add("Sqty");
            dtraw.Columns.Add("Hqty");
            dsraw.Tables.Add(dtraw);

            dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {

                var result1 = from r in dt.AsEnumerable()
                              group r by new { Categoryuserid = r["CategoryUserid"], Categoryid = r["Categoryid"], item = r["Definition"] } into raw
                              select new
                              {
                                  Categoryuserid = raw.Key.Categoryuserid,
                                  Categoryid = raw.Key.Categoryid,
                                  item = raw.Key.item,
                                  total = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  Htotal = raw.Sum(x => Convert.ToDouble(x["HQty"])),
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();
                    double avlqty = 0;
                    double sqty = 0;
                    double hqty = 0;
                    drraw["Categoryuserid"] = g.Categoryuserid;
                    drraw["Categoryid"] = g.Categoryid;
                    drraw["item"] = g.item;
                    DataSet getstock = objbs.GetStockAvailable(Convert.ToInt32(g.Categoryuserid), sTableName);
                    if (getstock.Tables[0].Rows.Count > 0)
                    {
                        drraw["Aqty"] = Convert.ToDouble(getstock.Tables[0].Rows[0]["Available_QTY"]).ToString();
                        avlqty = Convert.ToDouble(drraw["Aqty"]);
                    }
                    else
                    {
                        drraw["Aqty"] = Convert.ToDouble(0).ToString("" + qtysetting + "");
                        avlqty = Convert.ToDouble(0);
                    }
                    drraw["Sqty"] = Convert.ToDouble(g.total).ToString("" + qtysetting + "");
                    drraw["Hqty"] = Convert.ToDouble(g.Htotal).ToString("" + qtysetting + "");
                    sqty = Convert.ToDouble(drraw["Sqty"]);
                    hqty = Convert.ToDouble(drraw["Hqty"]);
                    // if (lbltempsalesid.Text == "0" || lbltempsalesid.Text == "")
                    {
                        if (StockOption == "2")
                        {
                            dsraw.Tables[0].Rows.Add(drraw);
                        }

                        if (StockOption == "1")
                        {
                            if ((avlqty + hqty) >= sqty)
                            {
                                dsraw.Tables[0].Rows.Add(drraw);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Insuffient Avaliable Qty For this item Name " + g.item + " .Thank you!!!');", true);
                                return;
                            }
                        }

                    }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Sales Invoice Not Generated For this hold/Invoice.Thank you!!!');", true);
                return;
            }

            #endregion

            string narration = string.Empty;
            // int totqtyy = 0;
            for (int i = 0; i < gvlist.Rows.Count; i++)
            {
                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                TextBox Definition = (TextBox)gvlist.Rows[i].FindControl("Definition");

                if (narration == "")
                {
                    // narration = "Sales Bill No :" + txtbillno.Text;
                    //narration = narration + "(Category: " + inara.ToString();
                    narration = narration + "Product: " + Definition.Text.ToString();
                    narration = narration + "-Qty: " + Qty.Text + ",";
                }
                else
                {
                    narration = narration + " " + Definition.Text.ToString();
                    narration = narration + "-Qty: " + Qty.Text + ",";
                }
            }
            narration = narration.TrimEnd(',');
            narration = "(" + narration.ToString() + ")";


            string Approved = string.Empty;
            string ApprovedID = string.Empty;

            if (lblisnormal.Text == "N")
            {
                int lnght = txtorderno.Text.Length;

                if (lnght.ToString() == lblordercount.Text)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Order No Count.Thank You!!!');", true);
                    txtorderno.Focus();
                    return;
                }


                Regex r = new Regex("[ ^ 0-9]");

                if (lblordertype.Text == "1")
                {

                    bool containsInt = txtorderno.Text.All(char.IsDigit);
                    if (containsInt == true)
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check and Type Order No.Thank You!!!');", true);
                        txtorderno.Focus();
                        return;
                    }


                    //if (r.IsMatch(txtorderno.Text))
                    //{
                    //    return;
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check and Type Order No.Thank You!!!');", true);
                    //    txtorderno.Focus();
                    //    return;

                    //}
                }


            }



            //if(lblisinclusiverate.Text=="Y")
            //{
            //    if(txtonlineamount.Text=="" || txtonlineamount.Text=="0")
            //    {
            //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Online Amount.Thank You!!!');", true);
            //        return;
            //    }
            //}

            int cntt = gvlist.Rows.Count;

            if (cntt == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item.Thank You!!!');", true);
                return;
            }

            txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }

            DataSet checkdayclose = objbs.checkinser_Previousday(sTableName);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (lblpaymodesic.Text == "Y")
            {
                chkdisc.Enabled = true;
            }
            else
            {
                DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
                if (getAttenderdisc.Tables[0].Rows.Count > 0)
                {
                    attednertype.DataSource = getAttenderdisc.Tables[0];
                    attednertype.DataTextField = "AttenderName";
                    attednertype.DataValueField = "AttenderID";
                    attednertype.DataBind();
                    attednertype.Items.Insert(0, "Select Disc-Att");

                }
                chkdisc.Checked = false;
                chkdisc.Enabled = false;
                txtdiscotp.Enabled = false;
                txtdiscotp.Text = "";
                txtDiscount.Text = "0";
                attednertype.Enabled = false;
                txtDiscount.Enabled = false;
                chkdisc.Enabled = false;
                chkdisc.Checked = false;
                txtdiscotp.Text = "";
                txtdiscotp.Enabled = false;
                drpdischk.Items.Clear();
                drpdischk.ClearSelection();
                txtdiscotp.Attributes.Clear();
                txtdiscou_TextChanged(sender, e);
                if (chkdisc.Checked == true)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                    return;
                }
            }

            if (chkdisc.Checked == true)
            {
                if (txtCustomerName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                    return;
                }
                else if (txtmobile.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "Mobile();", true);
                    return;
                }


                if (attednertype.SelectedValue == "Select Disc-Att")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Approval Attender.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                else
                {
                    Approved = attednertype.SelectedItem.Text;
                    ApprovedID = attednertype.SelectedValue;

                }
            }
            else
            {
                Approved = "Nil";
                ApprovedID = "0";
            }



            if (lblisnormal.Text == "Y")
            {
                txtorderno.Text = "No";
            }
            else
            {
                if (txtorderno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Order No.Thank You!!!');", true);
                    return;
                }
                else
                {

                    if (OnliOrder == "Y")
                    {
                        // Check With Live SERVER
                        if (objbs.IsConnectedToInternet())
                        {
                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                            if (dcheck.Tables[0].Rows.Count > 0)
                            {
                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Check Online Order no Mismatched/Duplicate Occur.Plaese Check it Again.Thank You!!!');", true);
                                return;
                            }
                        }
                    }
                    else
                    {

                    }


                    //CHeck  Order Number Already Exists
                    DataSet dchekk = objbs.checkordernumber(drpsalestype.SelectedValue, txtorderno.Text, "tblsales_" + sTableName + "", "SalesOrder", "S");
                    if (dchekk.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Entered Order No is Duplicate.Plaese Check it Again.Thank You!!!');", true);
                        return;

                    }
                    else
                    {

                    }
                }
            }

            if (drpPayment.SelectedValue == "18")
            {
                if (txtmobile.Text == "" && txtCustomerName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Mobile Number and Customer Name.');", true);
                    txtmobile.Focus();
                    return;
                }
                else
                {
                    if (txtmobile.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Mobile Number.');", true);
                        txtmobile.Focus();
                        return;
                    }
                    if (txtCustomerName.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Customer Name.');", true);
                        txtCustomerName.Focus();
                        return;
                    }
                }
            }

            if (lbltempsalesid.Text == "0" || lbltempsalesid.Text == "")
            {
                #region

                //string Approved = "";
                //if (ddlApproved.SelectedValue != "Select")
                //{
                //    Approved = ddlApproved.SelectedValue;
                //}


                string Attenderid = "0";
                if (drpattendername.SelectedValue == "Select Attender")
                {
                    if (lblattednercheck.Text == "Y")
                    {

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Attender Name.Thank You!!!');", true);
                        return;

                    }
                    else
                    {
                        Attenderid = "0";
                    }
                }
                else
                {
                    Attenderid = drpattendername.SelectedValue;
                }

                int iStockSuccess = 0;

                int iCustid = 0;

                if (txtbilled.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Enter Billed by Name');", true);
                }
                else if (drpPayment.SelectedItem.Text.Trim() == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Choose Cash/Credit');", true);
                }
                else
                {

                    #region Start
                    if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "5")
                    {
                        if (txtCustomerName.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                        }
                        else if (drpattendername.SelectedValue == "Select Attender")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Attender", "Attender();", true);
                        }
                        else if (txtmobile.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "Mobile();", true);
                        }
                        else
                        {
                            if (txtmobile.Text != "")
                            {
                                DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                                if (dCustid.Tables[0].Rows.Count > 0)
                                {
                                    if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                    {
                                        iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                    }
                                    else
                                    {
                                        iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(drpPayment.SelectedValue), txtgstno.Text);
                                    }
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(drpPayment.SelectedValue), txtgstno.Text);
                                }
                            }

                            if (txtReceived.Text == "")
                            {
                                txtReceived.Text = "" + ratesetting + "";
                            }
                            if (txtBal.Text == "")
                            {
                                txtBal.Text = "" + ratesetting + "";
                            }
                            //if (txtDiscount.Text == "0")
                            {
                                //  int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text),Convert.ToDouble(lblsgst.Text),Convert.ToDouble(lblsubttl.Text));

                                int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text,
                                    Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text),
                                    Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text),
                                    Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text),
                                    Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(),
                                    ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text),
                                    lblmargin.Text, lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, Attenderid, "0",
                                    txtDiscount.Text, ApprovedID, txtonlineamount.Text, txtbillcode.Text, Billgenerate, taxsetting, currency, lblRound.Text,"tblTranssalesAmount_"+sTableName+"", Billerid);


                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                                    Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");


                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    if (lblitemdiscount.Text == "")
                                    {
                                        lblitemdiscount.Text = "0";
                                    }

                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, Attenderid, drpsalestype.SelectedValue, Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    // if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                    }
                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", "0", "Y", OrderBill.ToString(), "DIR ORD", "Sale", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }

                                string yourUrl = "";

                                if (Isprint == "Y")
                                {

                                    if (PrintOption == "1")
                                    {

                                        yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }

                                    if (PrintOption == "2")
                                    {
                                        yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }
                                    //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                                    if (lblprintcount.Text == "2")
                                    {
                                        if (PrintOption == "1")
                                        {

                                            yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                        }

                                        if (PrintOption == "2")
                                        {
                                            yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                        }
                                        //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl + "');", true);
                                    }


                                }

                                //DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                                //if (ds.Tables[0].Rows.Count > 0)
                                //{

                                //    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                                //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                                //}
                                Refersh();

                            }

                        }
                    }
                    else
                    {


                        if (txtmobile.Text != "")
                        {
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows.Count > 0)
                            {
                                if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                {
                                    iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(drpPayment.SelectedValue), txtgstno.Text);
                                }
                            }
                            else
                            {
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(drpPayment.SelectedValue), txtgstno.Text);
                            }
                        }

                        else
                        {
                            txtmobile.Text = "0000000000";
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            //if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                            if (dCustid.Tables[0].Rows.Count > 0)
                            {
                                iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                            }
                            else
                            {
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(drpPayment.SelectedValue), txtgstno.Text);
                            }

                        }


                        if (txtReceived.Text == "")
                        {
                            txtReceived.Text = "" + ratesetting + "";
                        }
                        if (txtBal.Text == "")
                        {
                            txtBal.Text = "" + ratesetting + "";
                        }
                        if (txtDiscount.Text == "0")
                        {
                            //int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));

                            int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), lblmargin.Text, lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, Attenderid, "0", txtDiscount.Text, ApprovedID, txtonlineamount.Text, txtbillcode.Text, Billgenerate, taxsetting, currency, lblRound.Text, "tblTranssalesAmount_" + sTableName + "", Billerid);

                            int isalesid = Convert.ToInt32(OrderBill);

                            dt = (DataTable)ViewState["dt"];
                            for (int i = 0; i < gvlist.Rows.Count; i++)
                            {

                                Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");
                                Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");

                                Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                if (lblitemdiscount.Text == "")
                                {
                                    lblitemdiscount.Text = "0";
                                }


                                //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                //int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, "0", drpsalestype.SelectedValue);

                                //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");

                                int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, Attenderid, drpsalestype.SelectedValue, Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                //  if (StockOption == "1")
                                {
                                    double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                }


                                // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                //7 dec
                            }

                            // Update OnlineOrder Fresh
                            if (objbs.IsConnectedToInternet())
                            {
                                if (OnliOrder == "Y")
                                {
                                    int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                }

                                if (OnliOrder == "N")
                                {
                                    if (MOnliOrder == "Y")
                                    {
                                        // Check With Live SERVER
                                        DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                                        if (dcheck.Tables[0].Rows.Count > 0)
                                        {
                                            OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                            int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                        }
                                        else
                                        {
                                            //  int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD","Sale");
                                            int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", "0", "Y", OrderBill.ToString(), "DIR ORD", "Sale", txtBillDate.Text, narration);
                                        }
                                    }
                                }
                            }


                            // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=DineIN&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();
                            // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();

                            string yourUrl = "";
                            if (Isprint == "Y")
                            {

                                if (PrintOption == "1")
                                {

                                    yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                }

                                if (PrintOption == "2")
                                {
                                    yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                }


                                //                            string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                                if (lblprintcount.Text == "2")
                                {
                                    if (PrintOption == "1")
                                    {

                                        yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                    }

                                    if (PrintOption == "2")
                                    {
                                        yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                    }
                                    //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl + "');", true);
                                }


                            }
                            //DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                            //if (ds.Tables[0].Rows.Count > 0)
                            //{

                            //    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                            //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                            //}

                            Refersh();
                        }

                        else
                        {
                            //if (txtgiven.Text == "")
                            //{
                            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                            //}


                            //else
                            {
                                // int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));
                                int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), lblmargin.Text, lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, Attenderid, "0", txtDiscount.Text, ApprovedID, txtonlineamount.Text, txtbillcode.Text, Billgenerate, taxsetting, currency, lblRound.Text, "tblTranssalesAmount_" + sTableName + "", Billerid);

                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");

                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    if (lblitemdiscount.Text == "")
                                    {
                                        lblitemdiscount.Text = "0";
                                    }

                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    //int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, "0", drpsalestype.SelectedValue);

                                    //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");

                                    int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, Attenderid, drpsalestype.SelectedValue, Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    //  if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                    }
                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                // int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD","Sale");
                                                int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", "0", "Y", OrderBill.ToString(), "DIR ORD", "Sale", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }


                                //   string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=DineIN&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();
                                //string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();

                                string yourUrl = "";

                                if (Isprint == "Y")
                                {

                                    if (PrintOption == "1")
                                    {

                                        yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }

                                    if (PrintOption == "2")
                                    {
                                        yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }


                                    //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                                    if (lblprintcount.Text == "2")
                                    {
                                        if (PrintOption == "1")
                                        {

                                            yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                        }

                                        if (PrintOption == "2")
                                        {
                                            yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                        }
                                        //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl + "');", true);
                                    }


                                }

                                //DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                                //if (ds.Tables[0].Rows.Count > 0)
                                //{

                                //    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                                //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                                //}


                                Refersh();
                            }

                        }
                    }

                    #endregion
                }

                #endregion
            }
            else
            {
                #region

                // STOCK UPDATED AS NORMAL ONE
                int iss = objbs.Tempnormalsalescancel(sTableName, Convert.ToInt32(lbltempsalesid.Text), "N", "", "", "", "Kot/Sales");


                //string Approved = "";
                //if (ddlApproved.SelectedValue != "Select")
                //{
                //    Approved = ddlApproved.SelectedValue;
                //}

                string Attenderid = "0";
                if (drpattendername.SelectedValue == "Select Attender")
                {
                    if (lblattednercheck.Text == "Y")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Attender Name.Thank You!!!');", true);
                        return;
                    }
                    else
                    {
                        Attenderid = "0";
                    }
                }
                else
                {
                    Attenderid = drpattendername.SelectedValue;
                }
                int iStockSuccess = 0;

                int iCustid = 0;

                if (txtbilled.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Enter Billed by Name');", true);
                }
                else if (drpPayment.SelectedItem.Text.Trim() == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Choose Cash/Credit');", true);
                }
                else
                {

                    #region Start
                    if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "5")
                    {
                        #region

                        if (txtCustomerName.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                        }
                        else if (drpattendername.SelectedValue == "Select Attender")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Attender", "Attender();", true);
                        }
                        else if (txtmobile.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "Mobile();", true);
                        }
                        else
                        {
                            if (txtmobile.Text != "")
                            {
                                DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                                if (dCustid.Tables[0].Rows.Count > 0)
                                {
                                    if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                    {
                                        iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                    }
                                    else
                                    {
                                        iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), txtgstno.Text);
                                    }
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), txtgstno.Text);
                                }
                            }

                            if (txtReceived.Text == "")
                            {
                                txtReceived.Text = "" + ratesetting + "";
                            }
                            if (txtBal.Text == "")
                            {
                                txtBal.Text = "" + ratesetting + "";
                            }
                            //if (txtDiscount.Text == "0")
                            {
                                #region

                                int OrderBill = objbs.insertOrdersalesnew123("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(lbldisco.Text),
                                    Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "",
                                    Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text),
                                    txtgiven.Text, Approved, "0", Request.Cookies["userInfo"]["empcode"].ToString(), ddlCashier.SelectedValue,
                                    Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, lblRound.Text, lblmargin.Text,
                                    lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, Attenderid, "1",
                                    txtDiscount.Text, ApprovedID, txtonlineamount.Text, txtbillcode.Text, Billgenerate, taxsetting, currency, "tblTranssalesAmount_" + sTableName + "", Billerid);


                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");

                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    if (lblitemdiscount.Text == "")
                                    {
                                        lblitemdiscount.Text = "0";
                                    }

                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    //int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, "0", drpsalestype.SelectedValue);

                                    //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");

                                    int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, Attenderid, drpsalestype.SelectedValue, Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));
                                    // if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                    }


                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                //var catid = new[] { lblCatID1, lblCatID2, lblCatID3, lblCatID4, lblCatID5, lblCatID6, lblCatID7, lblCatID8, lblCatID9, lblCatID10, lblCatID11, lblCatID12, lblCatID13, lblCatID14, lblCatID15 };
                                //var ItemID = new[] { lblItemID1, lblItemID2, lblItemID3, lblItemID4, lblItemID5, lblItemID6, lblItemID7, lblItemID8, lblItemID9, lblItemID10, lblItemID11, lblItemID12, lblItemID13, lblItemID14, lblItemID15 };
                                //var Qty = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8, txtQty9, txtQty10, txtQty11, txtQty12, txtQty13, txtQty14, txtQty15 };
                                //var rate = new[] { lblRate1, lblRate2, lblRate3, lblRate4, lblRate5, lblRate6, lblRate7, lblRate8, lblRate9, lblRate10, lblRate11, lblRate12, lblRate13, lblRate14, lblRate15 };
                                //var Amt = new[] { lblAmount1, lblAmount2, lblAmount3, lblAmount4, lblAmount5, lblAmount6, lblAmount7, lblAmount8, lblAmount9, lblAmount10, lblAmount11, lblAmount12, lblAmount13, lblAmount14, lblAmount15 };
                                //var tAX = new[] { lbltaxam1, lbltaxam2, lbltaxam3, lbltaxam4, lbltaxam5, lbltaxam6, lbltaxam7, lbltaxam8, lbltaxam9, lbltaxam10, lbltaxam11, lbltaxam12, lbltaxam13, lbltaxam14, lbltaxam15 };

                                //for (int i = 0; i < 15; i++)
                                //{
                                //    if (Amt[i].Text != "0")
                                //    {

                                //        string[] data = catid[i].Text.Split('-');
                                //        int catID = Convert.ToInt32(data[0]);
                                //        int StockID = Convert.ToInt32(data[1]);
                                //        string date = data[2];
                                //        int iStatus1 = objbs.insertTransSales(sTableName, isalesid, (catID), Convert.ToDouble(Qty[i].Text), Convert.ToDouble(rate[i].Text), Convert.ToDouble(0), Convert.ToDouble(Amt[i].Text), (StockID), Convert.ToInt32(ItemID[i].Text), Convert.ToInt32(tAX[i].Text));
                                //        DataSet dcheck = objbs.checkCheckBoxCondition(Convert.ToInt32(ItemID[i].Text));
                                //        //if (dcheck.Tables[0].Rows.Count > 0)
                                //        //{

                                //        //to check printing
                                //        iStockSuccess = UpdateStockAvailable(catID, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));

                                //        // STOCK UPDATE FOR EXPIRY DATE WISE
                                //        int iexpdate = objbs.Expirydateprocess(isalesid, catID, Convert.ToString(ItemID[i].Text), Convert.ToDecimal(Qty[i].Text), sTableName);
                                //        //}
                                //        //else
                                //        //{
                                //        //    iStockSuccess = UpdateStockAvailable(catID, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));
                                //        //}
                                //    }
                                //}


                                int jk = objbs.Tempnormalsalescompletestatus(sTableName, Convert.ToInt32(lbltempsalesid.Text), OrderBill.ToString());

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                //  int iss1 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", OrderBill.ToString(), "Y", OrderBill.ToString(), "DIR ORD", "Sale");
                                                int iss1 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", "0", "Y", OrderBill.ToString(), "DIR ORD", "Sale", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }


                                // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=DineIN&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();
                                // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();

                                string yourUrl = "";
                                if (Isprint == "Y")
                                {

                                    if (PrintOption == "1")
                                    {

                                        yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }

                                    if (PrintOption == "2")
                                    {
                                        yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }


                                    //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                                    if (lblprintcount.Text == "2")
                                    {
                                        if (PrintOption == "1")
                                        {

                                            yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                        }

                                        if (PrintOption == "2")
                                        {
                                            yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                        }
                                        //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl + "');", true);
                                    }

                                }


                                //DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                                //if (ds.Tables[0].Rows.Count > 0)
                                //{

                                //    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                                //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                                //}
                                Refersh();

                                #endregion
                            }

                        }
                        #endregion
                    }
                    else
                    {

                        #region

                        if (txtmobile.Text != "")
                        {
                            #region

                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows.Count > 0)
                            {
                                if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                {
                                    iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), txtgstno.Text);
                                }
                            }
                            else
                            {
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), txtgstno.Text);
                            }

                            #endregion
                        }
                        else
                        {
                            txtmobile.Text = "0000000000";
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                            {
                                iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                            }

                        }


                        if (txtReceived.Text == "")
                        {
                            txtReceived.Text = "" + ratesetting + "";
                        }
                        if (txtBal.Text == "")
                        {
                            txtBal.Text = "" + ratesetting + "";
                        }
                        if (txtDiscount.Text == "0")
                        {
                            #region

                            int OrderBill = objbs.insertOrdersalesnew123("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text,
                                Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text),
                                Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0),
                                "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text),
                                txtgiven.Text, Approved, Attenderid, Request.Cookies["userInfo"]["empcode"].ToString(), ddlCashier.SelectedValue,
                                Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, lblRound.Text, lblmargin.Text, 
                                lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, "0", "1", txtDiscount.Text, 
                                ApprovedID, txtonlineamount.Text, txtbillcode.Text, Billgenerate, taxsetting, currency, "tblTranssalesAmount_" + sTableName + "", Billerid);

                            int isalesid = Convert.ToInt32(OrderBill);

                            dt = (DataTable)ViewState["dt"];
                            for (int i = 0; i < gvlist.Rows.Count; i++)
                            {

                                Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");


                                Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");

                                TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");

                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                if (lblitemdiscount.Text == "")
                                {
                                    lblitemdiscount.Text = "0";
                                }

                                //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                //int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, "0", drpsalestype.SelectedValue);

                                //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");

                                int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, Attenderid, drpsalestype.SelectedValue, Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                //  if (StockOption == "1")
                                {
                                    double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                }


                                // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                //7 dec
                            }

                            //var catid = new[] { lblCatID1, lblCatID2, lblCatID3, lblCatID4, lblCatID5, lblCatID6, lblCatID7, lblCatID8, lblCatID9, lblCatID10, lblCatID11, lblCatID12, lblCatID13, lblCatID14, lblCatID15 };
                            //var ItemID = new[] { lblItemID1, lblItemID2, lblItemID3, lblItemID4, lblItemID5, lblItemID6, lblItemID7, lblItemID8, lblItemID9, lblItemID10, lblItemID11, lblItemID12, lblItemID13, lblItemID14, lblItemID15 };
                            //var Qty = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8, txtQty9, txtQty10, txtQty11, txtQty12, txtQty13, txtQty14, txtQty15 };
                            //var rate = new[] { lblRate1, lblRate2, lblRate3, lblRate4, lblRate5, lblRate6, lblRate7, lblRate8, lblRate9, lblRate10, lblRate11, lblRate12, lblRate13, lblRate14, lblRate15 };
                            //var Amt = new[] { lblAmount1, lblAmount2, lblAmount3, lblAmount4, lblAmount5, lblAmount6, lblAmount7, lblAmount8, lblAmount9, lblAmount10, lblAmount11, lblAmount12, lblAmount13, lblAmount14, lblAmount15 };
                            //var tAX = new[] { lbltaxam1, lbltaxam2, lbltaxam3, lbltaxam4, lbltaxam5, lbltaxam6, lbltaxam7, lbltaxam8, lbltaxam9, lbltaxam10, lbltaxam11, lbltaxam12, lbltaxam13, lbltaxam14, lbltaxam15 };

                            //for (int i = 0; i < 15; i++)
                            //{
                            //    if (Amt[i].Text != "0")
                            //    {

                            //        string[] data = catid[i].Text.Split('-');
                            //        int catID = Convert.ToInt32(data[0]);
                            //        int StockID = Convert.ToInt32(data[1]);
                            //        string date = data[2];
                            //        int iStatus1 = objbs.insertTransSales(sTableName, isalesid, (catID), Convert.ToDouble(Qty[i].Text), Convert.ToDouble(rate[i].Text), Convert.ToDouble(0), Convert.ToDouble(Amt[i].Text), (StockID), Convert.ToInt32(ItemID[i].Text), Convert.ToInt32(tAX[i].Text));
                            //        DataSet dcheck = objbs.checkCheckBoxCondition(Convert.ToInt32(ItemID[i].Text));
                            //        //if (dcheck.Tables[0].Rows.Count > 0)
                            //        //{

                            //        //to check printing
                            //        iStockSuccess = UpdateStockAvailable(catID, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));

                            //        // STOCK UPDATE FOR EXPIRY DATE WISE
                            //        int iexpdate = objbs.Expirydateprocess(isalesid, catID, Convert.ToString(ItemID[i].Text), Convert.ToDecimal(Qty[i].Text), sTableName);
                            //        //}
                            //        //else
                            //        //{
                            //        //    iStockSuccess = UpdateStockAvailable(catID, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));
                            //        //}
                            //    }
                            //}

                            int jk = objbs.Tempnormalsalescompletestatus(sTableName, Convert.ToInt32(lbltempsalesid.Text), (OrderBill).ToString());

                            // Update OnlineOrder Fresh
                            if (objbs.IsConnectedToInternet())
                            {
                                if (OnliOrder == "Y")
                                {
                                    int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                }

                                if (OnliOrder == "N")
                                {
                                    if (MOnliOrder == "Y")
                                    {
                                        // Check With Live SERVER
                                        DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                                        if (dcheck.Tables[0].Rows.Count > 0)
                                        {
                                            OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                            int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                        }
                                        else
                                        {
                                            // int iss2 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD","Sale");
                                            int iss2 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", "0", "Y", OrderBill.ToString(), "DIR ORD", "Sale", txtBillDate.Text, narration);
                                        }
                                    }
                                }
                            }


                            // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=DineIN&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();
                            // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();

                            string yourUrl = "";
                            if (Isprint == "Y")
                            {

                                if (PrintOption == "1")
                                {

                                    yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                }

                                if (PrintOption == "2")
                                {
                                    yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                }


                                // string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                                if (lblprintcount.Text == "2")
                                {
                                    if (PrintOption == "1")
                                    {

                                        yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                    }

                                    if (PrintOption == "2")
                                    {
                                        yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                    }
                                    //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl + "');", true);
                                }

                            }

                            //DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                            //if (ds.Tables[0].Rows.Count > 0)
                            //{

                            //    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                            //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                            //}

                            Refersh();

                            #endregion
                        }

                        else
                        {
                            #region

                            //if (txtgiven.Text == "")
                            //{
                            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                            //}


                            //else
                            {
                                // int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));
                                int OrderBill = objbs.insertOrdersalesnew123("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text,
                                    Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text),
                                    Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0),
                                    "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text),
                                    txtgiven.Text, Approved, "0", Request.Cookies["userInfo"]["empcode"].ToString(), ddlCashier.SelectedValue,
                                    Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, lblRound.Text, lblmargin.Text, 
                                    lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, Attenderid, "1", txtDiscount.Text,
                                    ApprovedID, txtonlineamount.Text, txtbillcode.Text, Billgenerate, taxsetting, currency, "tblTranssalesAmount_" + sTableName + "", Billerid);

                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    Label lblitemdiscount = (Label)gvlist.Rows[i].FindControl("lblitemdiscount");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                    if (lblitemdiscount.Text == "")
                                    {
                                        lblitemdiscount.Text = "0";
                                    }


                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    //int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, "0", drpsalestype.SelectedValue);

                                    //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");


                                    int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(lblitemdiscount.Text), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, Attenderid, drpsalestype.SelectedValue, Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    // if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                    }
                                    //else
                                    //{
                                    //    double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);
                                    //    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Sales Entry");
                                    //}

                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                //var catid = new[] { lblCatID1, lblCatID2, lblCatID3, lblCatID4, lblCatID5, lblCatID6, lblCatID7, lblCatID8, lblCatID9, lblCatID10, lblCatID11, lblCatID12, lblCatID13, lblCatID14, lblCatID15 };
                                //var ItemID = new[] { lblItemID1, lblItemID2, lblItemID3, lblItemID4, lblItemID5, lblItemID6, lblItemID7, lblItemID8, lblItemID9, lblItemID10, lblItemID11, lblItemID12, lblItemID13, lblItemID14, lblItemID15 };
                                //var Qty = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8, txtQty9, txtQty10, txtQty11, txtQty12, txtQty13, txtQty14, txtQty15 };
                                //var rate = new[] { lblRate1, lblRate2, lblRate3, lblRate4, lblRate5, lblRate6, lblRate7, lblRate8, lblRate9, lblRate10, lblRate11, lblRate12, lblRate13, lblRate14, lblRate15 };
                                //var Amt = new[] { lblAmount1, lblAmount2, lblAmount3, lblAmount4, lblAmount5, lblAmount6, lblAmount7, lblAmount8, lblAmount9, lblAmount10, lblAmount11, lblAmount12, lblAmount13, lblAmount14, lblAmount15 };
                                //var tAX = new[] { lbltaxam1, lbltaxam2, lbltaxam3, lbltaxam4, lbltaxam5, lbltaxam6, lbltaxam7, lbltaxam8, lbltaxam9, lbltaxam10, lbltaxam11, lbltaxam12, lbltaxam13, lbltaxam14, lbltaxam15 };

                                //for (int i = 0; i < 15; i++)
                                //{
                                //    if (Amt[i].Text != "0")
                                //    {

                                //        string[] data = catid[i].Text.Split('-');
                                //        int catID = Convert.ToInt32(data[0]);
                                //        int StockID = Convert.ToInt32(data[1]);
                                //        string date = data[2];
                                //        int iStatus1 = objbs.insertTransSales(sTableName, isalesid, (catID), Convert.ToDouble(Qty[i].Text), Convert.ToDouble(rate[i].Text), Convert.ToDouble(0), Convert.ToDouble(Amt[i].Text), (StockID), Convert.ToInt32(ItemID[i].Text), Convert.ToInt32(tAX[i].Text));
                                //        DataSet dcheck = objbs.checkCheckBoxCondition(Convert.ToInt32(ItemID[i].Text));
                                //        //if (dcheck.Tables[0].Rows.Count > 0)
                                //        //{

                                //        //to check printing
                                //        iStockSuccess = UpdateStockAvailable(catID, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));

                                //        // STOCK UPDATE FOR EXPIRY DATE WISE
                                //        int iexpdate = objbs.Expirydateprocess(isalesid, catID, Convert.ToString(ItemID[i].Text), Convert.ToDecimal(Qty[i].Text), sTableName);

                                //        //}
                                //        //else
                                //        //{
                                //        //    iStockSuccess = UpdateStockAvailable(catID, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));
                                //        //}
                                //    }
                                //}

                                int jk = objbs.Tempnormalsalescompletestatus(sTableName, Convert.ToInt32(lbltempsalesid.Text), OrderBill.ToString());

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "status", "kotNo", OrderBill.ToString(), "kotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                // int iss3 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD","Sale");
                                                int iss3 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "N", "0", "Y", OrderBill.ToString(), "DIR ORD", "Sale", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                }

                                //  string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=DineIN&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();
                                // string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();

                                string yourUrl = "";
                                if (Isprint == "Y")
                                {

                                    if (PrintOption == "1")
                                    {

                                        yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }

                                    if (PrintOption == "2")
                                    {
                                        yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=" + chkkot.Checked;
                                    }



                                    // string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

                                    if (lblprintcount.Text == "2")
                                    {
                                        if (PrintOption == "1")
                                        {

                                            yourUrl = "SalesPrint.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                        }

                                        if (PrintOption == "2")
                                        {
                                            yourUrl = "SalesPrintType2.aspx?Mode=Sales&Type=" + drpsalestype.SelectedValue + "&iSalesID=" + OrderBill + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&state=" + Request.Cookies["userInfo"]["state"].ToString() + "&statecode=" + Request.Cookies["userInfo"]["statecode"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString() + "&KOTPrint=false";
                                        }
                                        //  string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
                                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl + "');", true);
                                    }

                                }


                                //DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                                //if (ds.Tables[0].Rows.Count > 0)
                                //{

                                //    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                                //    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                                //}


                                Refersh();
                            }
                            #endregion
                        }

                        #endregion
                    }

                    #endregion
                }


                #endregion
            }
        }

        private int UpdateStockAvailable(int iCat, int iSubCat, decimal iQty, string sDate, string iStockID, string isalesid, string Screen)
        {
            decimal iAQty = 0;
            decimal iRemQty = 0;
            int iSuccess = 0;

            DataSet dsStock = objbs.GetStockDetails(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

            }
            if (StockOption == "1")
            {
                iRemQty = iAQty - iQty;
            }
            iSuccess = objbs.updateSalesStock(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, "-", Screen, iQty.ToString(), isalesid, StockOption);


            return iSuccess;
        }



        void Refersh()
        {
            txtmanualslno.Text = "1";
            DataSet dshold = objbs.TempCustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblTempSales_" + sTableName);
            if (dshold.Tables[0].Rows.Count > 0)
            {
                Holdbill.DataSource = dshold;
                Holdbill.DataBind();
            }
            else
            {
                Holdbill.DataSource = null;
                Holdbill.DataBind();
            }

            gvlist.DataSource = null;
            gvlist.DataBind();
            GridView2.DataSource = null;
            GridView3.DataSource = null;
            GridView4.DataSource = null;
            GridView2.DataBind();
            GridView3.DataBind();
            GridView4.DataBind();
            UpdatePanel3.Update();

            var catid = new[] { lblCatID1, lblCatID2, lblCatID3, lblCatID4, lblCatID5, lblCatID6, lblCatID7, lblCatID8, lblCatID9, lblCatID10, lblCatID11, lblCatID12, lblCatID13, lblCatID14, lblCatID15 };
            var ItemID = new[] { lblItemID1, lblItemID2, lblItemID3, lblItemID4, lblItemID5, lblItemID6, lblItemID7, lblItemID8, lblItemID9, lblItemID10, lblItemID11, lblItemID12, lblItemID13, lblItemID14, lblItemID15 };
            var Qty = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5, txtQty6, txtQty7, txtQty8, txtQty9, txtQty10, txtQty11, txtQty12, txtQty13, txtQty14, txtQty15 };
            var rate = new[] { lblRate1, lblRate2, lblRate3, lblRate4, lblRate5, lblRate6, lblRate7, lblRate8, lblRate9, lblRate10, lblRate11, lblRate12, lblRate13, lblRate14, lblRate15 };
            var Amt = new[] { lblAmount1, lblAmount2, lblAmount3, lblAmount4, lblAmount5, lblAmount6, lblAmount7, lblAmount8, lblAmount9, lblAmount10, lblAmount11, lblAmount12, lblAmount13, lblAmount14, lblAmount15 };
            var Item = new[] { lblItem1, lblItem2, lblItem3, lblItem4, lblItem5, lblItem6, lblItem7, lblItem8, lblItem9, lblItem10, lblItem11, lblItem12, lblItem13, lblItem14, lblItem15 };
            var Avl = new[] { lblAQty1, lblAQty2, lblAQty3, lblAQty4, lblAQty5, lblAQty6, lblAQty7, lblAQty8, lblAQty9, lblAQty10, lblAQty11, lblAQty12, lblAQty13, lblAQty14, lblAQty15 };
            var Tax = new[] { lblTax, lblTax1, lblTax2, lblTax3, lblTax4, lblTax5, lblTax6, lblTax7, lblTax8, lblTax9, lblTax10, lblTax11, lblTax12, lblTax13, lblTax14 };
            for (int i = 0; i < 15; i++)
            {
                catid[i].Text = "";
                ItemID[i].Text = "";
                Qty[i].Text = "";
                rate[i].Text = "";
                Amt[i].Text = "";
                Item[i].Text = "";
                Avl[i].Text = "";
                Tax[i].InnerText = "";
            }
            txtBillNo.Text = "";
            txttotqty.Text = "";
            lbltempsalesid.Text = "";
            lbltotal.Text = "0";
            lblGrandTotal.Text = "0";
            lbldisplay.InnerText = "0";
            txtAdvance.Text = "0";
            txtDiscount.Text = "0";
            txtCustomerName.Text = "";
            txtmobile.Text = "";
            txtTax.Text = "0";
            drpPayment.ClearSelection();
            drpsalestype.ClearSelection();
            drpattendername.ClearSelection();
            drpitemsearch.ClearSelection();
            lblcgst.Text = "0";
            lblsgst.Text = "0";
            lblsubttl.Text = "0";
            lblisnormal.Text = "Y";
            txtorderno.Text = "";
            //DataSet ds = objbs.SalesBillno("tblSales_" + sTableName, lblisnormal.Text);
            //if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
            //    txtBillNo.Text = "1";
            //else
            //    txtBillNo.Text = ds.Tables[0].Rows[0]["billno"].ToString();
            //txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            DataSet getAttender = objbs.GetAttenderdisc(BranchID, lblNbilltype.Text);
            if (getAttender.Tables[0].Rows.Count > 0)
            {
                drpattendername.DataSource = getAttender.Tables[0];
                drpattendername.DataTextField = "AttenderName";
                drpattendername.DataValueField = "AttenderID";
                drpattendername.DataBind();
                drpattendername.Items.Insert(0, "Select Attender");

            }



            DataSet getAttenderdisc = objbs.GetAttenderdisc(BranchID, lbldisctype.Text);
            if (getAttenderdisc.Tables[0].Rows.Count > 0)
            {
                attednertype.DataSource = getAttenderdisc.Tables[0];
                attednertype.DataTextField = "AttenderName";
                attednertype.DataValueField = "AttenderID";
                attednertype.DataBind();
                attednertype.Items.Insert(0, "Select Disc-Att");


            }

            attednertype.Enabled = false;
            txtdiscotp.Text = "";
            txtdiscotp.Enabled = false;
            txtdiscotp.Attributes.Clear();
            drpdischk.Items.Clear();
            drpdischk.ClearSelection();
            chkdisc.Checked = false;
            lbldisco.Text = "";
            txtonlineamount.Text = "0";

            DataSet paymode = objbs.PaymodevaluesNew(drpsalestype.SelectedValue);
            if (paymode.Tables[0].Rows.Count > 0)
            {
                drpPayment.DataSource = paymode.Tables[0];
                drpPayment.DataTextField = "PayMode";
                drpPayment.DataValueField = "Value";
                drpPayment.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add this Payment Mode.For This Sales Type.Please Contact Administrator!!!.Thank you!!!');", true);
                return;
            }

            DataSet getallitembind = objbs.GetNewSelectDistinctItems("N", Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            if (getallitembind.Tables[0].Rows.Count > 0)
            {
                drpitemsearch.DataSource = getallitembind.Tables[0];
                drpitemsearch.DataTextField = "Definition";
                drpitemsearch.DataValueField = "valuee";
                drpitemsearch.DataBind();
                drpitemsearch.Items.Insert(0, "Select Item");

            }

            txtDiscount.Text = "0";
            lbldisco.Text = "0";

            DataSet getpaymodediscount = objbs.chkpaymodedisc(drpPayment.SelectedValue);
            if (getpaymodediscount.Tables[0].Rows.Count > 0)
            {
                lblpaymodesic.Text = getpaymodediscount.Tables[0].Rows[0]["Discount"].ToString();
            }
            else
            {
                lblpaymodesic.Text = "N";
                chkdisc.Checked = false;
                chkdisc.Enabled = false;

            }

            DataSet getsalestypeamargin = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);
            if (getsalestypeamargin.Tables[0].Rows.Count > 0)
            {
                lblmargin.Text = getsalestypeamargin.Tables[0].Rows[0]["Margin"].ToString();
                lblmargintax.Text = getsalestypeamargin.Tables[0].Rows[0]["GST"].ToString();
                lblisnormal.Text = getsalestypeamargin.Tables[0].Rows[0]["Isnormal"].ToString();
                isdiscchk.Text = getsalestypeamargin.Tables[0].Rows[0]["Isdiscount"].ToString();
                lblisinclusiverate.Text = getsalestypeamargin.Tables[0].Rows[0]["isinclusiverate"].ToString();
                //if (lblisinclusiverate.Text == "Y")
                //{
                //    txtonlineamount.Enabled = true;
                //    txtonlineamount.Text = "0";
                //}
                //else
                //{
                //    txtonlineamount.Enabled = false;
                //    txtonlineamount.Text = "0";
                //}

                if (isdiscchk.Text == "Y")
                {
                    chkdisc.Enabled = true;
                    txtDiscount.Text = "0";
                }
                else
                {
                    txtDiscount.Text = "0";
                    chkdisc.Enabled = false;
                    chkdisc.Checked = false;
                    txtdiscotp.Text = "";
                    txtdiscotp.Enabled = false;
                }

                if (isdiscchk.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill No Not Generated.Please LogOut and Login Again!!!');", true);
                    return;
                }

                if (lblisnormal.Text == "Y")
                {
                    Chkbills.Visible = false;
                    chkgivenby.Visible = true;
                }
                else
                {
                    Chkbills.Visible = true;
                    chkgivenby.Visible = false;
                }


                if (lblisnormal.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill No Not Generated.Please Try Again Later!!!');", true);
                    return;
                }
                else
                {

                    DataSet ds = objbs.SalesBillno("tblSales_" + sTableName, lblisnormal.Text);
                    if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtBillNo.Text = "1";
                    else
                        txtBillNo.Text = ds.Tables[0].Rows[0]["billno"].ToString();

                    DataSet dss = objbs.dailybillseries("tblSales_" + sTableName, "BillDate");
                    if (dss.Tables[0].Rows[0]["billno"].ToString() == "")
                        txtdailybillno.Text = "1";
                    else
                        txtdailybillno.Text = dss.Tables[0].Rows[0]["billno"].ToString();

                    txtfullbillno.Text = txtbillcode.Text + '-' + txtdailybillno.Text;
                }

                if (drpPayment.SelectedValue == "15")
                {
                    lblpaygate.Text = getsalestypeamargin.Tables[0].Rows[0]["PaymentGatway"].ToString();
                }
                else
                {
                    lblpaygate.Text = "0";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Not Allow To Add item's.Please Contact Administrator!!!.Thank you!!!');", true);
                return;
            }


            Session["Icount"] = 1;
            tr.Visible = false;
            tr1.Visible = false;
            tr2.Visible = false;
            tr3.Visible = false;
            tr4.Visible = false;
            tr5.Visible = false;
            tr6.Visible = false;
            tr7.Visible = false;
            tr8.Visible = false;
            tr9.Visible = false;
            tr10.Visible = false;
            tr11.Visible = false;
            tr12.Visible = false;
            tr13.Visible = false;
            tr14.Visible = false;
            tblBill.Visible = false;
            btnPrint.Enabled = true;

            dt.Rows.Clear();
            ViewState["dt"] = dt;
            if (dt.Columns.Count > 0)
            {
            }
            else
            {
                DataColumn col = new DataColumn("Sno", typeof(int));
                dt.Columns.Add(col);
                //dt.Columns.Add("Sno");
                dt.Columns.Add("CategoryID");
                dt.Columns.Add("CategoryUserID");
                dt.Columns.Add("Stockid");
                dt.Columns.Add("Definition");
                dt.Columns.Add("Available_QTY");
                dt.Columns.Add("TAX");
                dt.Columns.Add("margin");
                dt.Columns.Add("paygate");
                dt.Columns.Add("margintax");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Rate");
                dt.Columns.Add("OriRate");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Disamt");
                dt.Columns.Add("cattype");
                dt.Columns.Add("combo");
                dt.Columns.Add("ShwQty");
                dt.Columns.Add("cQty");
                dt.Columns.Add("HQty");
                dt.Columns.Add("mrp");
                dt.Columns.Add("mrpamount");
                ViewState["dt"] = dt;
            }

            if (possetting == "S" || possetting == "S1")
            {
                txtCusName1.Focus();
                divdrop.Visible = false;
                divscript.Visible = true;
            }
            else if (possetting == "D")
            {
                txtmanualslno.Focus();
                divdrop.Visible = true;
                divscript.Visible = false;
            }
            TaxView.Visible = false;
            btnView.Visible = true;
            btnTaxClose.Visible = false;

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewButton.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesGrid.aspx");


        }
        #region Minus
        protected void btnmin_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty1.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty1.Text);
                dQty--;
                txtQty1.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty1.Text) <= Convert.ToDecimal(lblAQty1.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty1.Text) * Convert.ToDecimal(lblRate1.Text);
                    lblAmount1.Text = dCalTotal.ToString("" + ratesetting + "");
                    lblTax.InnerText = (Convert.ToDecimal(lblAmount1.Text) * Convert.ToDecimal(0.05)).ToString("" + ratesetting + "");
                    //Calcuate();
                }
                else
                {
                    txtQty1.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty2.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty2.Text);
                dQty--;
                txtQty2.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty2.Text) <= Convert.ToDecimal(lblAQty2.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty2.Text) * Convert.ToDecimal(lblRate2.Text);
                    lblAmount2.Text = dCalTotal.ToString("f2");
                    lblTax1.InnerText = (Convert.ToDecimal(lblAmount2.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty2.Text = "0";
                }
            }
            GSTValGrand();
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty3.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty3.Text);
                dQty--;
                txtQty3.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty3.Text) <= Convert.ToDecimal(lblAQty3.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty3.Text) * Convert.ToDecimal(lblRate3.Text);
                    lblAmount3.Text = dCalTotal.ToString("f2");
                    lblTax2.InnerText = (Convert.ToDecimal(lblAmount3.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty3.Text = "0";
                }
            }
            GSTValGrand();
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty4.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty4.Text);
                dQty--;
                txtQty4.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty4.Text) <= Convert.ToDecimal(lblAQty4.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty4.Text) * Convert.ToDecimal(lblRate4.Text);
                    lblAmount4.Text = dCalTotal.ToString("f2");
                    lblTax3.InnerText = (Convert.ToDecimal(lblAmount4.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty4.Text = "0";
                }
            }
            GSTValGrand();
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty5.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty5.Text);
                dQty--;
                txtQty5.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty5.Text) <= Convert.ToDecimal(lblAQty5.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty5.Text) * Convert.ToDecimal(lblRate5.Text);
                    lblAmount5.Text = dCalTotal.ToString("f2");
                    lblTax4.InnerText = (Convert.ToDecimal(lblAmount5.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty5.Text = "0";
                }
            }
            GSTValGrand();
        }

        protected void LinkButton14_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty6.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty6.Text);
                dQty--;
                txtQty6.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty6.Text) <= Convert.ToDecimal(lblAQty6.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty6.Text) * Convert.ToDecimal(lblRate6.Text);
                    lblAmount6.Text = dCalTotal.ToString("f2");
                    lblTax5.InnerText = (Convert.ToDecimal(lblAmount6.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty6.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton15_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty7.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty7.Text);
                dQty--;
                txtQty7.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty7.Text) <= Convert.ToDecimal(lblAQty7.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty7.Text) * Convert.ToDecimal(lblRate7.Text);
                    lblAmount7.Text = dCalTotal.ToString("f2");
                    lblTax6.InnerText = (Convert.ToDecimal(lblAmount7.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty7.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton16_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty8.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty8.Text);
                dQty--;
                txtQty8.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty8.Text) <= Convert.ToDecimal(lblAQty8.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty8.Text) * Convert.ToDecimal(lblRate8.Text);
                    lblAmount8.Text = dCalTotal.ToString("f2");
                    lblTax7.InnerText = (Convert.ToDecimal(lblAmount8.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty8.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton17_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty9.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty9.Text);
                dQty--;
                txtQty9.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty9.Text) <= Convert.ToDecimal(lblAQty9.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty9.Text) * Convert.ToDecimal(lblRate9.Text);
                    lblAmount9.Text = dCalTotal.ToString("f2");
                    lblTax8.InnerText = (Convert.ToDecimal(lblAmount9.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty9.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton18_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty10.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty10.Text);
                dQty--;
                txtQty10.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty10.Text) <= Convert.ToDecimal(lblAQty10.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty10.Text) * Convert.ToDecimal(lblRate10.Text);
                    lblAmount10.Text = dCalTotal.ToString("f2");
                    lblTax9.InnerText = (Convert.ToDecimal(lblAmount10.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty10.Text = "0";
                }
            }

            GSTValGrand();
        }


        protected void LinkButton19_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty11.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty11.Text);
                dQty--;
                txtQty11.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty11.Text) <= Convert.ToDecimal(lblAQty11.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty11.Text) * Convert.ToDecimal(lblRate11.Text);
                    lblAmount11.Text = dCalTotal.ToString("f2");
                    lblTax10.InnerText = (Convert.ToDecimal(lblAmount11.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty11.Text = "0";
                }
            }
            GSTValGrand();
        }

        protected void LinkButton21_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty12.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty12.Text);
                dQty--;
                txtQty12.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty12.Text) <= Convert.ToDecimal(lblAQty12.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty12.Text) * Convert.ToDecimal(lblRate12.Text);
                    lblAmount12.Text = dCalTotal.ToString("f2");
                    lblTax11.InnerText = (Convert.ToDecimal(lblAmount12.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty12.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton23_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty13.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty13.Text);
                dQty--;
                txtQty13.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty13.Text) <= Convert.ToDecimal(lblAQty13.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty13.Text) * Convert.ToDecimal(lblRate13.Text);
                    lblAmount13.Text = dCalTotal.ToString("f2");
                    lblTax12.InnerText = (Convert.ToDecimal(lblAmount13.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty13.Text = "0";
                }
            }

            GSTValGrand();
        }

        protected void LinkButton25_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty14.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty14.Text);
                dQty--;
                txtQty14.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty14.Text) <= Convert.ToDecimal(lblAQty14.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty14.Text) * Convert.ToDecimal(lblRate14.Text);
                    lblAmount14.Text = dCalTotal.ToString("f2");
                    lblTax13.InnerText = (Convert.ToDecimal(lblAmount14.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty14.Text = "0";
                }
            }
            GSTValGrand();
        }

        protected void LinkButton27_Click(object sender, EventArgs e)
        {
            decimal dQty = 0;
            if (txtQty15.Text != "")
            {
                dQty = Convert.ToDecimal(txtQty15.Text);
                dQty--;
                txtQty15.Text = dQty.ToString();
                if (Convert.ToDecimal(txtQty15.Text) <= Convert.ToDecimal(lblAQty15.Text))
                {
                    decimal dCalTotal = Convert.ToDecimal(txtQty15.Text) * Convert.ToDecimal(lblRate15.Text);
                    lblAmount15.Text = dCalTotal.ToString("f2");
                    lblTax14.InnerText = (Convert.ToDecimal(lblAmount15.Text) * Convert.ToDecimal(0.05)).ToString("f2");
                    //Calcuate();
                }
                else
                {
                    txtQty15.Text = "0";
                }
            }

            GSTValGrand();
        }
        #endregion

        protected void txtReceived_TextChanged(object sender, EventArgs e)
        {
            decimal dTot = Convert.ToDecimal(lblGrandTotal.Text);
            decimal dCash = Convert.ToDecimal(txtReceived.Text);

            decimal dBal = dCash - dTot;
            txtBal.Text = dBal.ToString("" + ratesetting + "");
        }

        protected void txtmobile_TextChanged(object sender, EventArgs e)
        {
            if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "5")
            {
                DataSet dch = objbs.checkingRights(txtmobile.Text);
                if (dch.Tables[0].Rows.Count > 0)
                {
                    txtCustomerName.Text = dch.Tables[0].Rows[0]["Name"].ToString();
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = objbs.custNAME(txtmobile.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCustomerName.Text = ds.Tables[0].Rows[0]["customername"].ToString();
                        txtgstno.Text = ds.Tables[0].Rows[0]["Gstno"].ToString();
                        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        chkdelivery.Checked = true;
                        Delivery_checked(sender, e);
                    }
                }
            }
            else
            {

                DataSet ds = new DataSet();

                ds = objbs.custNAME(txtmobile.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomerName.Text = ds.Tables[0].Rows[0]["customername"].ToString();
                    txtgstno.Text = ds.Tables[0].Rows[0]["Gstno"].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    chkdelivery.Checked = true;
                    Delivery_checked(sender, e);
                }

            }



        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //Button buttonId = (Button)e.Row.FindControl("Button2");
                //buttonId.CommandArgument = e.Row.RowIndex.ToString();
                //string[] commandArgs = buttonId.CommandArgument.ToString().Split(new char[] { ',' });
                //string categoryuserid = commandArgs[0];
                //if (categoryuserid != "0")
                //{
                //    string cattype = commandArgs[1];


                //    if (cattype != "C")
                //    {
                //        if (buttonId.Text.Contains("(0.0)"))
                //        {
                //            buttonId.Enabled = false;
                //            buttonId.BackColor = System.Drawing.Color.Gray;
                //        }
                //    }
                //}
            }

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Button buttonId = (Button)e.Row.FindControl("Button2");
                //if (buttonId.Text.Contains("(0.0)"))
                //{
                //    buttonId.BackColor = System.Drawing.Color.Gray;
                //    buttonId.Enabled = false;
                //}


                //Button buttonId = (Button)e.Row.FindControl("Button2");
                //buttonId.CommandArgument = e.Row.RowIndex.ToString();
                //string[] commandArgs = buttonId.CommandArgument.ToString().Split(new char[] { ',' });
                //string categoryuserid = commandArgs[0];
                //string cattype = commandArgs[1];


                //if (cattype != "C")
                //{
                //    if (buttonId.Text.Contains("(0.0)"))
                //    {
                //        buttonId.Enabled = false;
                //        buttonId.BackColor = System.Drawing.Color.Gray;
                //    }
                //}
            }



        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Button buttonId = (Button)e.Row.FindControl("Button2");
                //if (buttonId.Text.Contains("(0.0)"))
                //{
                //    buttonId.BackColor = System.Drawing.Color.Gray;
                //    buttonId.Enabled = false;
                //}

                //Button buttonId = (Button)e.Row.FindControl("Button2");
                //buttonId.CommandArgument = e.Row.RowIndex.ToString();
                //string[] commandArgs = buttonId.CommandArgument.ToString().Split(new char[] { ',' });
                //string categoryuserid = commandArgs[0];
                //string cattype = commandArgs[1];


                //if (cattype != "C")
                //{
                //    if (buttonId.Text.Contains("(0.0)"))
                //    {
                //        buttonId.Enabled = false;
                //        buttonId.BackColor = System.Drawing.Color.Gray;
                //    }
                //}
            }


        }



        protected void Button1hold_Click(object sender, EventArgs e)
        {

            Refersh();


            //dt.Columns.Add("Sno");
            //dt.Columns.Add("CategoryID");
            //dt.Columns.Add("CategoryUserID");
            //dt.Columns.Add("Stockid");
            //dt.Columns.Add("Definition");
            //dt.Columns.Add("Available_QTY");
            //dt.Columns.Add("TAX");
            //dt.Columns.Add("margin");
            //dt.Columns.Add("paygate");
            //dt.Columns.Add("margintax");
            //dt.Columns.Add("Qty");
            //dt.Columns.Add("Rate");
            //dt.Columns.Add("OriRate");
            //dt.Columns.Add("Amount");
            //ViewState["dt"] = dt;


            Button btn = (Button)sender;

            lbltempsalesid.Text = btn.CommandArgument;
            string[] commandArguments = btn.Text.Split('-');

            string billno = commandArguments[0].ToString();
            string no = commandArguments[1].ToString();
            txtorderno.Text = no;
            if (no == "No")
            {
                chkgivenby.Visible = true;
                Chkbills.Visible = false;
            }
            else
            {
                chkgivenby.Visible = false;
                Chkbills.Visible = true;


            }

            DataSet dCat = new DataSet();
            decimal iQty = 0;
            string sItem = "";
            decimal dCalTotal = 0;
            decimal dRate = 0, dAmount = 0, dAvlQty = 0;
            int iSubCatID = 0;
            int CatID = 0;
            int stockID = 0;
            decimal GST = 0;

            string iscombo = "0";
            string ShwQty = "0";
            string cattype = "0";
            decimal CQty = 0;

            decimal mrpamnt = 0;


            string sTempSession = "";
            tblBill.Visible = true;
            dt = (DataTable)ViewState["dt"];


            dCat = objbs.TempGetStockDetails(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(lblUserID.Text), sTableName, billno, StockOption);
            if (dCat.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                {

                    sItem = dCat.Tables[0].Rows[i]["Printitem"].ToString();

                    DataSet getsalestype = objbs.GetSalesTypeForSales_pos(onllinepos);
                    if (getsalestype.Tables[0].Rows.Count > 0)
                    {
                        drpsalestype.DataSource = getsalestype.Tables[0];
                        drpsalestype.DataTextField = "PaymentType";
                        drpsalestype.DataValueField = "SalesTypeID";
                        drpsalestype.DataBind();
                    }

                    drpsalestype.SelectedValue = dCat.Tables[0].Rows[0]["Salestype"].ToString();
                    drpsalestype_selectedindex(sender, e);
                    drpPayment.SelectedValue = dCat.Tables[0].Rows[0]["iPayMode"].ToString();

                    drpattendername.SelectedValue = dCat.Tables[0].Rows[0]["attender"].ToString();

                    dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Rate"].ToString());

                    CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                    iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString());
                    stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryUserid"].ToString());
                    dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                    iQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["oriqty"].ToString());
                    GST = Convert.ToDecimal(dCat.Tables[0].Rows[i]["GST"].ToString());

                    iscombo = (dCat.Tables[0].Rows[i]["iscombo"].ToString());
                    ShwQty = (dCat.Tables[0].Rows[i]["Shwqty"].ToString());
                    cattype = (dCat.Tables[0].Rows[i]["Cattype"].ToString());
                    CQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Cqty"].ToString());
                    mrpamnt = Convert.ToDecimal(dCat.Tables[0].Rows[i]["mrp"].ToString());

                    DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[i]["Expirydate"].ToString());
                    {
                        int totcnt = 0;
                        int countt = dt.Rows.Count;
                        totcnt = countt + 1;
                        DataRow dr = dt.NewRow();

                        decimal amt = 0;
                        dr["Sno"] = totcnt;
                        dr["CategoryID"] = CatID;
                        dr["CategoryUserID"] = stockID;
                        dr["definition"] = sItem;
                        dr["StockID"] = iSubCatID; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                        dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("" + qtysetting + "");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                        dr["Qty"] = iQty.ToString("" + qtysetting + "");
                        dr["Rate"] = Convert.ToDecimal(dRate).ToString("" + ratesetting + "");
                        dr["mrp"] = Convert.ToDecimal(mrpamnt).ToString("" + ratesetting + "");
                        dr["Tax"] = Convert.ToDecimal(GST);

                        amt = Convert.ToDecimal(iQty) * dRate;
                        decimal mrpamt = Convert.ToDecimal(iQty) * mrpamnt;
                        //rows[0]["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");

                        dr["Amount"] = amt.ToString("" + ratesetting + "");
                        dr["mrpAmount"] = mrpamt.ToString("" + ratesetting + "");
                        dr["Orirate"] = dRate.ToString();
                        dr["Disamt"] = "0";
                        dr["cattype"] = cattype;
                        dr["combo"] = iscombo;
                        dr["ShwQty"] = ShwQty;
                        dr["CQty"] = CQty;
                        dr["HQty"] = (iQty * CQty);
                        dt.Rows.Add(dr);
                        ViewState["dt"] = dt;
                    }





                }
                DataView dvEmp = dt.DefaultView;
                dvEmp.Sort = "Sno Desc";
                gvlist.DataSource = dvEmp;
                gvlist.DataBind();
                getdisablecolumn();
                //gvlist.DataSource = dt;
                //gvlist.DataBind();
                // ViewState["dirState"] = dt;
                //  ViewState["sortdr"] = "Sno Desc";  

                txtdiscou_TextChanged(sender, e);
            }
            else
            {
                Refersh();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Sales Invoice Generated For this hold Bill No:" + billno + ".Thank you!!!');", true);
                return;
            }

        }
        protected void btncncl_click(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int iss = objbs.Tempnormalsalescancel(sTableName, Convert.ToInt32(btn.CommandArgument), "Y", txtRef.Text, dlReason.SelectedItem.Text, txtreasontext.Text, "Kot/Cancel");
            Refersh();
        }

        public void CheckQty()
        {


            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;
            dtraw.Columns.Add("Categoryid");
            dtraw.Columns.Add("Categoryuserid");
            dtraw.Columns.Add("Item");
            dtraw.Columns.Add("Aqty");
            dtraw.Columns.Add("Sqty");
            dsraw.Tables.Add(dtraw);

            dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {

                var result1 = from r in dt.AsEnumerable()
                              group r by new { Categoryuserid = r["CategoryUserid"], Categoryid = r["Categoryid"], item = r["Definition"] } into raw
                              select new
                              {
                                  Categoryuserid = raw.Key.Categoryuserid,
                                  Categoryid = raw.Key.Categoryid,
                                  item = raw.Key.item,
                                  total = raw.Sum(x => Convert.ToDouble(x["ShwQty"])),
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();
                    double avlqty = 0;
                    double sqty = 0;
                    drraw["Categoryuserid"] = g.Categoryuserid;
                    drraw["Categoryid"] = g.Categoryid;
                    drraw["item"] = g.item;
                    DataSet getstock = objbs.GetStockAvailable(Convert.ToInt32(g.Categoryuserid), sTableName);
                    if (getstock.Tables[0].Rows.Count > 0)
                    {
                        drraw["Aqty"] = Convert.ToDouble(getstock.Tables[0].Rows[0]["Available_QTY"]).ToString("0");
                        avlqty = Convert.ToDouble(drraw["Aqty"]);
                    }
                    else
                    {
                        drraw["Aqty"] = Convert.ToDouble(0).ToString("0");
                        avlqty = Convert.ToDouble(0);
                    }
                    drraw["Sqty"] = Convert.ToDouble(g.total).ToString("0");
                    sqty = Convert.ToDouble(drraw["Sqty"]);

                    if (StockOption == "2")
                    {
                        dsraw.Tables[0].Rows.Add(drraw);
                    }

                    if (StockOption == "1")
                    {
                        if (avlqty >= sqty)
                        {
                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Insuffient Avaliable Qty For this item Name " + g.item + " .Thank you!!!');", true);
                            return;
                        }
                    }


                }
                gvlst.DataSource = dsraw.Tables[0];
                gvlst.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Sales Invoice Not Generated For this hold/Invoice.Thank you!!!');", true);
                return;
            }
        }



        protected void btnhold_check(object sender, EventArgs e)
        {
            // ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('This Process is in Development Stage.Thank You!!!');", true);
            //  return;

            string OnlineOrderId = "0";



            //#region CHECK QTY

            //DataTable dtraw = new DataTable();
            //DataSet dsraw = new DataSet();
            //DataRow drraw;
            //dtraw.Columns.Add("Categoryid");
            //dtraw.Columns.Add("Categoryuserid");
            //dtraw.Columns.Add("Item");
            //dtraw.Columns.Add("Aqty");
            //dtraw.Columns.Add("Sqty");
            //dsraw.Tables.Add(dtraw);

            //dt = (DataTable)ViewState["dt"];
            //if (dt.Rows.Count > 0)
            //{

            //    var result1 = from r in dt.AsEnumerable()
            //                  group r by new { Categoryuserid = r["CategoryUserid"], Categoryid = r["Categoryid"], item = r["Definition"] } into raw
            //                  select new
            //                  {
            //                      Categoryuserid = raw.Key.Categoryuserid,
            //                      Categoryid = raw.Key.Categoryid,
            //                      item = raw.Key.item,
            //                      total = raw.Sum(x => Convert.ToDouble(x["ShwQty"])),
            //                  };


            //    foreach (var g in result1)
            //    {
            //        drraw = dtraw.NewRow();
            //        double avlqty = 0;
            //        double sqty = 0;
            //        drraw["Categoryuserid"] = g.Categoryuserid;
            //        drraw["Categoryid"] = g.Categoryid;
            //        drraw["item"] = g.item;
            //        DataSet getstock = objbs.GetStockAvailable(Convert.ToInt32(g.Categoryuserid), sTableName);
            //        if (getstock.Tables[0].Rows.Count > 0)
            //        {
            //            drraw["Aqty"] = Convert.ToDouble(getstock.Tables[0].Rows[0]["Available_QTY"]).ToString("0");
            //            avlqty = Convert.ToDouble(drraw["Aqty"]);
            //        }
            //        else
            //        {
            //            drraw["Aqty"] = Convert.ToDouble(0).ToString("0");
            //            avlqty = Convert.ToDouble(0);
            //        }
            //        drraw["Sqty"] = Convert.ToDouble(g.total).ToString("0");
            //        drraw["Hqty"] = Convert.ToDouble(g.Htotal).ToString("0");
            //        sqty = Convert.ToDouble(drraw["Sqty"]);
            //        hqty = Convert.ToDouble(drraw["Hqty"]);
            //        if (avlqty >= sqty)
            //        {
            //            dsraw.Tables[0].Rows.Add(drraw);
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Insuffient Avaliable Qty For this item Name " + g.item + " .Thank you!!!');", true);
            //            return;
            //        }
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Sales Invoice Not Generated For this hold/Invoice.Thank you!!!');", true);
            //    return;
            //}

            //#endregion

            #region CHECK QTY

            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;
            dtraw.Columns.Add("Categoryid");
            dtraw.Columns.Add("Categoryuserid");
            dtraw.Columns.Add("Item");
            dtraw.Columns.Add("Aqty");
            dtraw.Columns.Add("Sqty");
            dtraw.Columns.Add("Hqty");
            dsraw.Tables.Add(dtraw);

            dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {

                var result1 = from r in dt.AsEnumerable()
                              group r by new { Categoryuserid = r["CategoryUserid"], Categoryid = r["Categoryid"], item = r["Definition"] } into raw
                              select new
                              {
                                  Categoryuserid = raw.Key.Categoryuserid,
                                  Categoryid = raw.Key.Categoryid,
                                  item = raw.Key.item,
                                  total = raw.Sum(x => Convert.ToDouble(x["ShwQty"])),
                                  Htotal = raw.Sum(x => Convert.ToDouble(x["HQty"])),
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();
                    double avlqty = 0;
                    double sqty = 0;
                    double hqty = 0;
                    drraw["Categoryuserid"] = g.Categoryuserid;
                    drraw["Categoryid"] = g.Categoryid;
                    drraw["item"] = g.item;
                    DataSet getstock = objbs.GetStockAvailable(Convert.ToInt32(g.Categoryuserid), sTableName);
                    if (getstock.Tables[0].Rows.Count > 0)
                    {
                        drraw["Aqty"] = Convert.ToDouble(getstock.Tables[0].Rows[0]["Available_QTY"]).ToString("0");
                        avlqty = Convert.ToDouble(drraw["Aqty"]);
                    }
                    else
                    {
                        drraw["Aqty"] = Convert.ToDouble(0).ToString("0");
                        avlqty = Convert.ToDouble(0);
                    }
                    drraw["Sqty"] = Convert.ToDouble(g.total).ToString("0");
                    drraw["Hqty"] = Convert.ToDouble(g.Htotal).ToString("0");
                    sqty = Convert.ToDouble(drraw["Sqty"]);
                    hqty = Convert.ToDouble(drraw["Hqty"]);
                    // if (lbltempsalesid.Text == "0" || lbltempsalesid.Text == "")
                    {
                        if (StockOption == "2")
                        {
                            dsraw.Tables[0].Rows.Add(drraw);
                        }

                        if (StockOption == "1")
                        {
                            if ((avlqty + hqty) >= sqty)
                            {
                                dsraw.Tables[0].Rows.Add(drraw);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Insuffient Avaliable Qty For this item Name " + g.item + " .Thank you!!!');", true);
                                return;
                            }
                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Sales Invoice Not Generated For this hold/Invoice.Thank you!!!');", true);
                return;
            }

            #endregion


            string narration = string.Empty;
            // int totqtyy = 0;
            for (int i = 0; i < gvlist.Rows.Count; i++)
            {
                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                TextBox Definition = (TextBox)gvlist.Rows[i].FindControl("Definition");

                if (narration == "")
                {
                    // narration = "Sales Bill No :" + txtbillno.Text;
                    //narration = narration + "(Category: " + inara.ToString();
                    narration = narration + "Product: " + Definition.Text.ToString();
                    narration = narration + "-Qty: " + Qty.Text + ",";
                }
                else
                {
                    narration = narration + " " + Definition.Text.ToString();
                    narration = narration + "-Qty: " + Qty.Text + ",";
                }
            }
            narration = narration.TrimEnd(',');
            narration = "(" + narration.ToString() + ")";

            int cntt = gvlist.Rows.Count;

            if (cntt == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item.Thank You!!!');", true);
                return;
            }


            if (chkdisc.Checked == true)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please UnCheck Discount.For Hold Process.Not Allow To Make Disount.Thank You!!!');", true);
                return;
            }

            if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "5")
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('For This Sales paymode.Not Allow To Make Any Hold Bill.Please Contact Administrator.Thank You!!!');", true);
                return;

            }

            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }

            DataSet checkdayclose = objbs.checkinser_Previousday(sTableName);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (drpattendername.SelectedValue == "Select Attender")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Attender Name.Thank You!!!');", true);
                return;
            }

            if (lblisnormal.Text == "Y")
            {
                txtorderno.Text = "No";
            }
            else
            {
                if (txtorderno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Order No.Thank You!!!');", true);
                    return;
                }
                else
                {

                    if (OnliOrder == "Y")
                    {
                        if (objbs.IsConnectedToInternet())
                        {
                            // Check With Live SERVER
                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                            if (dcheck.Tables[0].Rows.Count > 0)
                            {
                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Check Online Order no Mismatched/Duplicate Occur.Plaese Check it Again.Thank You!!!');", true);
                                return;
                            }
                        }
                    }
                    else
                    {

                    }



                    //CHeck  Order Number Already Exists
                    DataSet dchekk = objbs.checkordernumber(drpsalestype.SelectedValue, txtorderno.Text, "tbltempsales_" + sTableName + "", "SalesTypeOrderNo", lbltempsalesid.Text);
                    if (dchekk.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Entered Order No is Duplicate.Plaese Check it Again.Thank You!!!');", true);
                        return;

                    }
                    else
                    {

                    }
                }
            }


            //  ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Hold Bill Is In Process.Please Contact Administartor.');", true);
            //   return;

            if (lbltempsalesid.Text == "0" || lbltempsalesid.Text == "")
            {

                string Approved = "";
                //if (ddlApproved.SelectedValue != "Select")
                //{
                //    Approved = ddlApproved.SelectedValue;
                //}
                int iStockSuccess = 0;

                int iCustid = 0;

                if (txtbilled.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Enter Billed by Name');", true);
                }
                else if (drpPayment.SelectedItem.Text.Trim() == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Choose Cash/Credit');", true);
                }
                else
                {

                    #region Start
                    if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "5")
                    {
                        if (txtCustomerName.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                        }
                        else if (txtmobile.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "Mobile();", true);
                        }
                        else
                        {
                            if (txtmobile.Text != "")
                            {
                                DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                                if (dCustid.Tables[0].Rows.Count > 0)
                                {
                                    if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                    {
                                        iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                    }
                                    else
                                    {
                                        iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                                    }
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                                }
                            }

                            if (txtReceived.Text == "")
                            {
                                txtReceived.Text = "" + ratesetting + "";
                            }
                            if (txtBal.Text == "")
                            {
                                txtBal.Text = "" + ratesetting + "";
                            }
                            if (txtDiscount.Text == "0")
                            {


                                int OrderBill = objbs.tempinsertOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, drpattendername.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", txtorderno.Text, drpsalestype.SelectedValue);


                                int isalesid = Convert.ToInt32(OrderBill);


                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");



                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    // int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text));
                                    int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    //  if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);

                                        //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                    }
                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }

                                Refersh();

                            }

                        }
                    }
                    else
                    {


                        if (txtmobile.Text != "")
                        {
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows.Count > 0)
                            {
                                if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                {
                                    iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                                }
                            }
                            else
                            {
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                            }
                        }

                        else
                        {
                            txtmobile.Text = "0000000000";
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                            {
                                iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                            }

                        }


                        if (txtReceived.Text == "")
                        {
                            txtReceived.Text = "" + ratesetting + "";
                        }
                        if (txtBal.Text == "")
                        {
                            txtBal.Text = "" + ratesetting + "";
                        }
                        if (txtDiscount.Text == "0")
                        {
                            #region

                            //int OrderBill = objbs.tempinsertOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0");
                            int OrderBill = objbs.tempinsertOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, drpattendername.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), "0", Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", txtorderno.Text, drpsalestype.SelectedValue);

                            int isalesid = Convert.ToInt32(OrderBill);

                            dt = (DataTable)ViewState["dt"];
                            for (int i = 0; i < gvlist.Rows.Count; i++)
                            {

                                Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                                Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");



                                //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                // int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text));
                                int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                //  if (StockOption == "1")
                                {
                                    double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);

                                    //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                }
                                // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                //7 dec
                            }

                            // Update OnlineOrder Fresh
                            if (objbs.IsConnectedToInternet())
                            {
                                if (OnliOrder == "Y")
                                {
                                    int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                }

                                if (OnliOrder == "N")
                                {
                                    if (MOnliOrder == "Y")
                                    {
                                        // Check With Live SERVER
                                        DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                        if (dcheck.Tables[0].Rows.Count > 0)
                                        {
                                            OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                            int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                        }
                                        else
                                        {
                                            int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                        }
                                    }
                                }
                            }

                            // Update OnlineOrder Fresh
                            if (objbs.IsConnectedToInternet())
                            {
                                if (OnliOrder == "Y")
                                {
                                    int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                }

                                if (OnliOrder == "N")
                                {
                                    if (MOnliOrder == "Y")
                                    {
                                        // Check With Live SERVER
                                        DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                        if (dcheck.Tables[0].Rows.Count > 0)
                                        {
                                            OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                            int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                        }
                                        else
                                        {
                                            int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                        }
                                    }
                                }
                            }


                            // Update OnlineOrder Fresh
                            if (objbs.IsConnectedToInternet())
                            {
                                if (OnliOrder == "Y")
                                {
                                    int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                }

                                if (OnliOrder == "N")
                                {
                                    if (MOnliOrder == "Y")
                                    {
                                        // Check With Live SERVER
                                        DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                        if (dcheck.Tables[0].Rows.Count > 0)
                                        {
                                            OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                            int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                        }
                                        else
                                        {
                                            int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                        }
                                    }
                                }
                            }

                            Refersh();

                            #endregion
                        }
                        else
                        {
                            #region

                            if (txtgiven.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                            }


                            else
                            {
                                // int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));
                                int OrderBill = objbs.tempinsertOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, drpattendername.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), "0", Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", txtorderno.Text, drpsalestype.SelectedValue);

                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");



                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    // int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text));
                                    int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    //  if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);

                                        //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                    }
                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                int iss = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }


                                Refersh();
                            }
                            #endregion
                        }
                    }

                    #endregion
                }
            }
            else
            {
                // STOCK UPDATED AS NORMAL ONE
                int iss = objbs.Tempnormalsalescancel(sTableName, Convert.ToInt32(lbltempsalesid.Text), "N", "", "", "", "Kot/Sales");


                // DELETE  OLD TEMP SALES
                int iii = objbs.Tempnormalsalesdelete(sTableName, Convert.ToInt32(lbltempsalesid.Text));


                // ADD NEW BILL NO
                string Approved = "";
                //if (ddlApproved.SelectedValue != "Select")
                //{
                //    Approved = ddlApproved.SelectedValue;
                //}
                int iStockSuccess = 0;

                int iCustid = 0;

                if (txtbilled.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Enter Billed by Name');", true);
                }
                else if (drpPayment.SelectedItem.Text.Trim() == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Choose Cash/Credit');", true);
                }
                else
                {

                    #region Start
                    if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "5")
                    {
                        if (txtCustomerName.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                        }
                        else if (txtmobile.Text == "")
                        {

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "Mobile();", true);
                        }
                        else
                        {
                            if (txtmobile.Text != "")
                            {
                                DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                                if (dCustid.Tables[0].Rows.Count > 0)
                                {
                                    if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                    {
                                        iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                    }
                                    else
                                    {
                                        iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                                    }
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                                }
                            }

                            if (txtReceived.Text == "")
                            {
                                txtReceived.Text = "" + ratesetting + "";
                            }
                            if (txtBal.Text == "")
                            {
                                txtBal.Text = "" + ratesetting + "";
                            }
                            if (txtDiscount.Text == "0")
                            {


                                int OrderBill = objbs.tempUpdateOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, drpattendername.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), "0", Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", lbltempsalesid.Text, txtorderno.Text, drpsalestype.SelectedValue);


                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");



                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    // int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text));
                                    int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    // if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);

                                        //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                    }
                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                int iss1 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }

                                Refersh();

                            }

                        }
                    }
                    else
                    {


                        if (txtmobile.Text != "")
                        {
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows.Count > 0)
                            {
                                if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                                {
                                    iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                                }
                                else
                                {
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                                }
                            }
                            else
                            {
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1), "0");
                            }
                        }

                        else
                        {
                            txtmobile.Text = "0000000000";
                            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
                            if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
                            {
                                iCustid = Convert.ToInt32(dCustid.Tables[0].Rows[0]["CustomerID"].ToString());
                            }

                        }


                        if (txtReceived.Text == "")
                        {
                            txtReceived.Text = "" + ratesetting + "";
                        }
                        if (txtBal.Text == "")
                        {
                            txtBal.Text = "" + ratesetting + "";
                        }
                        if (txtDiscount.Text == "0")
                        {
                            //int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));

                            int OrderBill = objbs.tempUpdateOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, drpattendername.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), "0", Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", lbltempsalesid.Text, txtorderno.Text, drpsalestype.SelectedValue);

                            int isalesid = Convert.ToInt32(OrderBill);

                            dt = (DataTable)ViewState["dt"];
                            for (int i = 0; i < gvlist.Rows.Count; i++)
                            {

                                Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");



                                //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                // int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text));
                                //int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text));

                                //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");

                                int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                // if (StockOption == "1")
                                {
                                    double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);

                                    //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                    iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                }
                                // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                //7 dec
                            }

                            // Update OnlineOrder Fresh
                            if (objbs.IsConnectedToInternet())
                            {
                                if (OnliOrder == "Y")
                                {
                                    int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                }

                                if (OnliOrder == "N")
                                {
                                    if (MOnliOrder == "Y")
                                    {
                                        // Check With Live SERVER
                                        DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                        if (dcheck.Tables[0].Rows.Count > 0)
                                        {
                                            OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                            int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                        }
                                        else
                                        {
                                            int iss2 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                        }
                                    }
                                }
                            }

                            Refersh();
                        }
                        else
                        {
                            if (txtgiven.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                            }


                            else
                            {
                                // int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));
                                //  int OrderBill = objbs.tempinsertOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, "0", Session["empcode"].ToString(), "0", Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", txtorderno.Text);
                                int OrderBill = objbs.tempUpdateOrdersalesnew("tblTempSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, drpattendername.SelectedValue, Request.Cookies["userInfo"]["empcode"].ToString(), "0", Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text), 0, "0", lbltempsalesid.Text, txtorderno.Text, drpsalestype.SelectedValue);

                                int isalesid = Convert.ToInt32(OrderBill);

                                dt = (DataTable)ViewState["dt"];
                                for (int i = 0; i < gvlist.Rows.Count; i++)
                                {

                                    Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                    Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("CategoryUserid");
                                    Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                    TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                    //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                    TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                    TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                    //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                    Label tax = (Label)gvlist.Rows[i].FindControl("txttax");

                                    Label lblcattype = (Label)gvlist.Rows[i].FindControl("lblcattype");
                                    Label lblcombo = (Label)gvlist.Rows[i].FindControl("lblcombo");
                                    TextBox txtshwqty = (TextBox)gvlist.Rows[i].FindControl("txtshwqty");
                                    TextBox txtcqty = (TextBox)gvlist.Rows[i].FindControl("txtcqty");
                                    // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");



                                    //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                    //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                    // int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text));
                                    //int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text));

                                    //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");

                                    int iStatus1 = objbs.TempinsertTransSales("tblTempTransSales_" + sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(txtshwqty.Text), lblcattype.Text, lblcombo.Text, Convert.ToDouble(txtcqty.Text));

                                    // if (StockOption == "1")
                                    {
                                        double Istock = Convert.ToDouble(Qty.Text) * Convert.ToDouble(txtcqty.Text);

                                        //iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                        iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Istock), "", Convert.ToString(StockID.Text), isalesid.ToString(), "Kot/HOLD");
                                    }
                                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToDecimal(Qty.Text), "", Convert.ToString(stock.Text)); 
                                    //7 dec
                                }

                                // Update OnlineOrder Fresh
                                if (objbs.IsConnectedToInternet())
                                {
                                    if (OnliOrder == "Y")
                                    {
                                        int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                    }

                                    if (OnliOrder == "N")
                                    {
                                        if (MOnliOrder == "Y")
                                        {
                                            // Check With Live SERVER
                                            DataSet dcheck = objbs.checkLiveordernumber(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus");
                                            if (dcheck.Tables[0].Rows.Count > 0)
                                            {
                                                OnlineOrderId = dcheck.Tables[0].Rows[0]["OnlineID"].ToString();
                                                int onineupdare = objbs.onlineupdate(drpsalestype.SelectedValue, txtorderno.Text, sTableName, "Hstatus", "HkotNo", OrderBill.ToString(), "HkotDate", txtBillDate.Text, narration);
                                            }
                                            else
                                            {
                                                int iss3 = objbs.insertonlineorder(drpsalestype.SelectedValue, txtorderno.Text, sTableName, BranchID, lblUser.Text, "Y", OrderBill.ToString(), "N", "0", "DIR ORD", "Kot", txtBillDate.Text, narration);
                                            }
                                        }
                                    }
                                }

                                Refersh();
                            }
                        }

                        #endregion
                    }

                }
            }
            // GET HOLD BILL DETAILS
            DataSet ds = objbs.TempCustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblTempSales_" + sTableName);
            Holdbill.DataSource = ds;
            Holdbill.DataBind();
            btnReset_Click(sender, e);
        }

        #region SCRIPOT SERACH
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetListofCustomer(string prefixText)
        {
            DataTable dt = new DataTable();
            try
            {
                // string branchid = HttpContext.Current.Session["BranchID"].ToString();
                string stablecde = HttpContext.Current.Session["BranchCode"].ToString();
                string stockoption = HttpContext.Current.Session["StockOption"].ToString();
                string possalessetting = HttpContext.Current.Session["possalessetting"].ToString();

                if (possalessetting == "S")
                {

                    using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["server"].ConnectionString))
                    {
                        sqlconn.Open();

                        //SqlCommand cmd = new SqlCommand("select serial_NO as definition from tblCategoryUser a where  a.serial_NO like '%" + prefixText + "%'", sqlconn);
                        //SqlCommand cmd = new SqlCommand("select a.categoryuserid,a.Serial_no as definition from tblCategoryUser a inner join tblstock_" + sGodownCode + " b on a.categoryuserid= b.subcategoryid where a.serial_NO like '%" + prefixText + "%' and b.available_qty > 0", sqlconn);




                        if (stockoption == "1")
                        {

                            SqlCommand cmd = new SqlCommand("select serial+' / '+Definition+' / '+cast(Available_QTY as nvarchar)+' / '+cast(StockID as nvarchar)+' / '+a.mrp as definition,cast(StockID as nvarchar)+','+ cattype as valuee " +
                                " from tblCategoryUser a,tblStock_" + stablecde + " b,tblCategoryuserBranch c  ,tblcategory d  where d.categoryid=a.categoryid " +
                                " and c.Itemid=a.CategoryUserID and  a.CategoryUserID=b.SubCategoryID   and isdelete=0  and b.Available_QTY>0 and a.IsActive='Yes' " +
                                " and c.IsActive='Yes' and c.BranchCode='" + stablecde + "'  and ( serial like '%" + prefixText + "%' or definition like '%" + prefixText + "%')   order by a.serial asc", sqlconn);

                            cmd.Parameters.AddWithValue("@definition", prefixText);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);



                            da1.Fill(dt);
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("select serial+' / '+Definition+' / '+cast('0' as nvarchar)+' / '+cast(a.CategoryUserID as nvarchar)+' / '+a.mrp as definition,cast(a.CategoryUserID as nvarchar)+','+ cattype as valuee " +
                                " from tblCategoryUser a,tblCategoryuserBranch c  ,tblcategory d  where d.categoryid=a.categoryid " +
                                " and c.Itemid=a.CategoryUserID    and isdelete=0  and  a.IsActive='Yes' and c.IsActive='Yes' " +
                                " and c.BranchCode='" + stablecde + "'  and  ( serial like '%" + prefixText + "%' or definition like '%" + prefixText + "%')   order by a.serial asc ", sqlconn);

                            cmd.Parameters.AddWithValue("@definition", prefixText);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);



                            da1.Fill(dt);
                        }
                    }
                }
                else if (possalessetting == "S1")
                {

                    using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["server"].ConnectionString))
                    {
                        sqlconn.Open();

                        //SqlCommand cmd = new SqlCommand("select serial_NO as definition from tblCategoryUser a where  a.serial_NO like '%" + prefixText + "%'", sqlconn);
                        //SqlCommand cmd = new SqlCommand("select a.categoryuserid,a.Serial_no as definition from tblCategoryUser a inner join tblstock_" + sGodownCode + " b on a.categoryuserid= b.subcategoryid where a.serial_NO like '%" + prefixText + "%' and b.available_qty > 0", sqlconn);




                        if (stockoption == "1")
                        {

                            SqlCommand cmd = new SqlCommand("select serial+' / '+Definition+' / '+cast(Available_QTY as nvarchar)+' / '+cast(StockID as nvarchar)+' / '+a.mrp as definition,cast(StockID as nvarchar)+','+ cattype as valuee " +
                                " from tblCategoryUser a,tblStock_" + stablecde + " b,tblCategoryuserBranch c  ,tblcategory d  where d.categoryid=a.categoryid " +
                                " and c.Itemid=a.CategoryUserID and  a.CategoryUserID=b.SubCategoryID   and isdelete=0  and b.Available_QTY>0 and a.IsActive='Yes' " +
                                " and c.IsActive='Yes' and c.BranchCode='" + stablecde + "'  and ( serial='" + prefixText + "' or  definition like '%" + prefixText + "%')   order by a.serial asc", sqlconn);

                            cmd.Parameters.AddWithValue("@definition", prefixText);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);



                            da1.Fill(dt);
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("select serial+' / '+Definition+' / '+cast('0' as nvarchar)+' / '+cast(a.CategoryUserID as nvarchar)+' / '+a.mrp as definition,cast(a.CategoryUserID as nvarchar)+','+ cattype as valuee " +
                                " from tblCategoryUser a,tblCategoryuserBranch c  ,tblcategory d  where d.categoryid=a.categoryid " +
                                " and c.Itemid=a.CategoryUserID    and isdelete=0  and  a.IsActive='Yes' and c.IsActive='Yes' " +
                                " and c.BranchCode='" + stablecde + "'  and  ( serial='" + prefixText + "' or definition like '%" + prefixText + "%')   order by a.serial asc ", sqlconn);

                            cmd.Parameters.AddWithValue("@definition", prefixText);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd);



                            da1.Fill(dt);
                        }
                    }
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine("Checking Status", ex.Message);
            }

            List<string> CustomerNames = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerNames.Add(dt.Rows[i]["definition"].ToString());
            }
            return CustomerNames;
            //return null;
        }

        public static string authors;
        protected void LedgerIdbinding(object sender, EventArgs e)
        {
            LedgeridSeries(txtCusName1.Text);
        }

        private void LedgeridSeries(string LedgerName)
        {

            try
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;
                SqlDataReader reader = null;

                string[] wordArray = LedgerName.Split('/');

                string itemname = wordArray[3];

                string procedurename = "";
                if (StockOption == "1")
                {
                    procedurename = "sp_GetLedgerPOS1Istockcheck";
                }
                else
                {
                    procedurename = "sp_GetLedgerPOS1I";
                }

                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["server"].ConnectionString))
                {


                    cmd = conn.CreateCommand();
                    using (cmd = new SqlCommand(procedurename, conn))
                    {
                        //conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@LedgerName", itemname.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@GodownCode", Request.Cookies["userInfo"]["BranchCode"].ToString()));
                        conn.Open();
                        reader = cmd.ExecuteReader();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        conn.Close();
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            //  NlblDefinition.Text = ds.Tables[0].Rows[0]["Printitem"].ToString();
                            //  Nlblcomboo.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["comboo"]).ToString();
                            //   NhdRate.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["Rate"]).ToString();
                            //   NhideCategoryID.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryID"]).ToString();
                            Nlblstockid.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["StockID"]).ToString();
                            //   NhideCategoryUserID.Value = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryUserid"]).ToString();
                            //   NlblAvailable_QTY.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Available_QTY"]).ToString();
                            //   NhdGST.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["GST"]).ToString();
                            //   Nlbqty.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["QTY"]).ToString();
                            Nlblcattype.Text = ds.Tables[0].Rows[0]["cattype"].ToString();

                            //NhideCategoryID.Value = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                            //NhideCategoryUserID.Value = ds.Tables[0].Rows[0]["CategoryUserID"].ToString();
                            //NhideUOMID.Value = ds.Tables[0].Rows[0]["UOMID"].ToString();
                            //NhdRate.Value = ds.Tables[0].Rows[0]["Rate"].ToString();
                            //NhdGST.Value = ds.Tables[0].Rows[0]["GST"].ToString();

                            //NlblCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                            //NlblDefinition.Text = ds.Tables[0].Rows[0]["Definition"].ToString();
                            //Nlblrate.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                            //Nlbqty.Text = ds.Tables[0].Rows[0]["Qty"].ToString();
                            //Nlblom.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                            txtmanualqty.Focus();
                        }
                        else
                        {

                            Nlblstockid.Text = "0";
                            Nlblcattype.Text = "N";
                            txtmanualqty.Focus();
                            //txtCusName1.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtCusName1.Text = "";
                txtCusName1.Focus();
            }
        }

        #endregion

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Isprint = "N";
            btnPrint_Click(sender, e);
        }

        protected void btnkot_Click(object sender, EventArgs e)
        {
            chkkot.Checked = true;
            btnPrint_Click(sender, e);
        }


    }
}


