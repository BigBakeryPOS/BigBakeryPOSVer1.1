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
using System.Drawing;
using System.Diagnostics;

namespace Billing.Accountsbootstrap
{
    public partial class Newpos : System.Web.UI.Page
    {
        string DiscountVal = "2";
        DataSet dsLogin = new DataSet();
        BSClass objBs = new BSClass();
        DataTable dt = new DataTable();
        DataTable splitdt = new DataTable();
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
        string Rate = "Rate";
        string biller = "";
        string BranchID = "";
        string PrintOption = "Nil";
        string StockOption = "Nil";
        string Country = "Nil";

        protected int iCntt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {



            //if (Session["User"] != null)
            //    sTableName = Session["User"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");

            //if (Session["UserName"] != null)
            //    sTableName = Session["UserName"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");

            //if (Session["UserID"] != null)
            //    sTableName = Session["UserID"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");

            //if (Session["Store"] != null)
            //    sTableName = Session["Store"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");

            //if (Session["Address"] != null)
            //    sTableName = Session["Address"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");

            //if (Session["TIN"] != null)
            //    sTableName = Session["TIN"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");

            //if (Session["Rate"] != null)
            //    sTableName = Session["Rate"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");


            //sTableName = Session["User"].ToString();
            //sStore = Session["Store"].ToString();
            //sAddress = Session["Address"].ToString();
            //sTin = Session["TIN"].ToString();
            //Rate = Session["Rate"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            biller = Request.Cookies["userInfo"]["Biller"].ToString(); ;
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sStore = Request.Cookies["userInfo"]["Store"].ToString();
            sAddress = Request.Cookies["userInfo"]["Address"].ToString();
            sTin = Request.Cookies["userInfo"]["TIN"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();

            PrintOption = Request.Cookies["userInfo"]["PrintOption"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();
            Country = Request.Cookies["userInfo"]["Country"].ToString();

            if (Country != "India")
            {
                IDCgst.Visible = false;
                lblcgst.Visible = false;
                IDSgst.Visible = false;
                lblsgst.Visible = false;

            }


            else
            {
                IDCgst.Visible = true;
                lblcgst.Visible = true;
                IDSgst.Visible = true;
                lblsgst.Visible = true;
            }

            if (!IsPostBack)
            {
                txtdiscotpg.Enabled = false;
                lblbilltype.InnerText = "";
                if (Request.QueryString.Get("Ref") != null)
                    lbltable.InnerText = Request.QueryString.Get("Ref");

                if (Request.QueryString.Get("id") != null)
                    lbltableid.InnerText = Request.QueryString.Get("id");

                if (lbltable.InnerText == "PARCEL")
                {
                    lblbilltype.InnerText = "Take Away";
                }
                else
                {
                    lblbilltype.InnerText = "Dine IN";
                }

                DataSet paymodeFinal = new DataSet();
                DataSet paymode = objbs.Paymodevalues(sTableName);

                txtbilled.Text = biller;

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

                DataSet getsalestype = objbs.GetSalesTypeForSales();
                if (getsalestype.Tables[0].Rows.Count > 0)
                {
                    drpsalestype.DataSource = getsalestype.Tables[0];
                    drpsalestype.DataTextField = "PaymentType";
                    drpsalestype.DataValueField = "SalesTypeID";
                    drpsalestype.DataBind();
                }

                DataSet getAttender = objbs.GetAttender(BranchID);
                if (getAttender.Tables[0].Rows.Count > 0)
                {
                    drpAttender.DataSource = getAttender.Tables[0];
                    drpAttender.DataTextField = "AttenderName";
                    drpAttender.DataValueField = "AttenderID";
                    drpAttender.DataBind();

                    drpAttend.DataSource = getAttender.Tables[0];
                    drpAttend.DataTextField = "AttenderName";
                    drpAttend.DataValueField = "AttenderID";
                    drpAttend.DataBind();
                }

                drpsalestype_selectedindex(sender, e);

                //DataSet ddiscount = new DataSet();
                //ddiscount = objbs.getdiscount();
                //if (ddiscount.Tables[0].Rows.Count > 0)
                //{
                //    drpcomp.DataSource = ddiscount.Tables[0];
                //    drpcomp.DataTextField = "DiscountName";
                //    drpcomp.DataValueField = "discountid";
                //    drpcomp.DataBind();
                //    drpcomp.SelectedValue = "2";
                //}

                string hex = " #9e6d32";
                Color c = ColorTranslator.FromHtml(hex);
                if (lblbilltype.InnerText == "Home Delivery")
                {
                    cust.Visible = true;
                    Address.Visible = true;
                    billtypeid.Text = "3";

                    btnhome.BackColor = System.Drawing.Color.Green;
                    Button6.BackColor = c;
                    Button7.BackColor = c;

                }
                else if (lblbilltype.InnerText == "Take Away")
                {
                    cust.Visible = false;
                    Address.Visible = false;
                    billtypeid.Text = "1";
                    btnhome.BackColor = c;
                    Button6.BackColor = c;
                    Button7.BackColor = System.Drawing.Color.Green;

                }
                else
                {
                    cust.Visible = false;
                    Address.Visible = false;
                    billtypeid.Text = "2";
                    btnhome.BackColor = c;
                    Button6.BackColor = System.Drawing.Color.Green;
                    Button7.BackColor = c;

                }

                lblDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

                DataSet ds = objbs.NSalesBillno(sTableName, "BillDate");
                if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
                    lblOrdeNo.InnerText = "1";
                else
                    lblOrdeNo.InnerText = ds.Tables[0].Rows[0]["billno"].ToString();
                if (dt.Columns.Count > 0)
                {
                    gvlist.DataSource = dt;
                    gvlist.DataBind();
                }
                else
                {

                    dt.Columns.Add("CategoryID");
                    dt.Columns.Add("CategoryUserID");
                    dt.Columns.Add("Definition");
                    dt.Columns.Add("Qty");
                    dt.Columns.Add("BillQty");
                    dt.Columns.Add("gst");
                    dt.Columns.Add("Rate");
                    dt.Columns.Add("Amount");
                    dt.Columns.Add("KotNo");
                    dt.Columns.Add("KotID");
                    dt.Columns.Add("Print");
                    dt.Columns.Add("Available_QTY");
                    dt.Columns.Add("Tax");
                    dt.Columns.Add("StockID");

                    dtt.Columns.Add("CategoryID");
                    dtt.Columns.Add("CategoryUserID");
                    dtt.Columns.Add("Definition");
                    dtt.Columns.Add("Qty");
                    dtt.Columns.Add("BillQty");
                    dtt.Columns.Add("gst");
                    dtt.Columns.Add("Rate");
                    dtt.Columns.Add("Amount");
                    dtt.Columns.Add("KotNo");
                    dtt.Columns.Add("KotID");
                    dtt.Columns.Add("Print");
                    dtt.Columns.Add("Available_QTY");
                    dtt.Columns.Add("Tax");
                    dtt.Columns.Add("StockID");

                    ViewState["dt"] = dt;
                    ViewState["Newdt"] = dtt;
                    gvlist.DataSource = dt;
                    gvlist.DataBind();
                }

                DataSet dCat1 = objbs.selectCAT(Convert.ToInt32(0));
                datcat.DataSource = dCat1;
                datcat.DataBind();


                DataSet dCheck = new DataSet();

                dCheck = objbs.NHoldedKOT(int.Parse(Request.QueryString.Get("id")), sTableName, "");
                if (dCheck.Tables[0].Rows.Count > 0)
                {
                    //  salesid.InnerText = dCheck.Tables[0].Rows[0]["salesid"].ToString();
                    // lblOrdeNo.InnerText = dCheck.Tables[0].Rows[0]["KotNO"].ToString();
                    lblbilltype.InnerText = dCheck.Tables[0].Rows[0]["Billtype"].ToString();
                    drpAttend.SelectedValue = dCheck.Tables[0].Rows[0]["Attender"].ToString();
                    lblKOTTblno.Text = dCheck.Tables[0].Rows[0]["tableno"].ToString();


                    hex = " #9e6d32";
                    c = ColorTranslator.FromHtml(hex);
                    if (lblbilltype.InnerText == "Home Delivery")
                    {
                        cust.Visible = true;
                        Address.Visible = true;
                        billtypeid.Text = "3";

                        btnhome.BackColor = System.Drawing.Color.Green;
                        Button6.BackColor = c;
                        Button7.BackColor = c;

                    }
                    else if (lblbilltype.InnerText == "Take Away")
                    {
                        cust.Visible = false;
                        Address.Visible = false;
                        billtypeid.Text = "1";
                        btnhome.BackColor = c;
                        Button6.BackColor = c;
                        Button7.BackColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        cust.Visible = false;
                        Address.Visible = false;
                        billtypeid.Text = "2";
                        btnhome.BackColor = c;
                        Button6.BackColor = System.Drawing.Color.Green;
                        Button7.BackColor = c;

                    }

                    DataRow dr1 = null;
                    for (int i = 0; i < dCheck.Tables[0].Rows.Count; i++)
                    {
                        decimal dStock = 0;// Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                        string sTock = dStock.ToString("f1");


                        dr1 = dtt.NewRow();
                        dr1["Definition"] = dCheck.Tables[0].Rows[i]["Definition"].ToString(); //+ " (" + sTock + ")";
                        dr1["KotID"] = dCheck.Tables[0].Rows[i]["Kotid"].ToString();
                        dr1["Qty"] = dCheck.Tables[0].Rows[i]["Quantity"].ToString();
                        dr1["BillQty"] = dCheck.Tables[0].Rows[i]["Quantity"].ToString();
                        double qty = Convert.ToDouble(dCheck.Tables[0].Rows[i]["Quantity"]);
                        dr1["gst"] = dCheck.Tables[0].Rows[i]["GST"].ToString();
                        dr1["Rate"] = Convert.ToDouble(dCheck.Tables[0].Rows[i]["unitprice"]).ToString("0.00");
                        double rate = Convert.ToDouble(dCheck.Tables[0].Rows[i]["unitprice"]);
                        dr1["Amount"] = Convert.ToDouble(qty * rate).ToString("0.00");
                        dr1["KotNo"] = dCheck.Tables[0].Rows[i]["KotNo"].ToString();
                        dr1["CategoryUserID"] = dCheck.Tables[0].Rows[i]["CategoryUserID"].ToString();
                        dr1["CategoryID"] = dCheck.Tables[0].Rows[i]["categoryid"].ToString();
                        dr1["Print"] = dCheck.Tables[0].Rows[i]["Billprint"].ToString();
                        dr1["gst"] = dCheck.Tables[0].Rows[i]["gst"].ToString();
                        dr1["StockID"] = dCheck.Tables[0].Rows[i]["StockID"].ToString();
                        //dr1["Print"] = "1";
                        dtt.Rows.Add(dr1);




                    }

                    ViewState["chckdt"] = dtt;
                    //ViewState["dt"] = dtt;
                    ViewState["Newdt"] = dtt;
                    TotalNew();
                    GridView1all.DataSource = dtt;
                    GridView1all.DataBind();
                    Total1();


                    // Total();
                    //gvlist.DataSource = dt;
                    //gvlist.DataBind();
                    //Total();

                }
                else
                {


                }

            }
            //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }

        protected void drpsalestype_selectedindex(object sender, EventArgs e)
        {

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


            DataSet getsalestypeamargin = objbs.GetgsttaxForSalestype(drpsalestype.SelectedValue);
            if (getsalestypeamargin.Tables[0].Rows.Count > 0)
            {
                lblmargin.Text = getsalestypeamargin.Tables[0].Rows[0]["Margin"].ToString();
                lblmargintax.Text = getsalestypeamargin.Tables[0].Rows[0]["GST"].ToString();
                lblisnormal.Text = getsalestypeamargin.Tables[0].Rows[0]["Isnormal"].ToString();

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
                }

                txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
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
                }

            }



        }

        protected void drppayment_selectedindex(object sender, EventArgs e)
        {





        }
        protected void chkinclusive(object sender, EventArgs e)
        {
            TotalNew();
        }
        protected void txt_servicetaxpercent_TextChanged(object sender, EventArgs e)
        {
            Total();
        }

        protected void txt_ServiceTaxamount_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_VATPercent_TextChanged(object sender, EventArgs e)
        {
            TotalNew();
        }

        protected void txt_VATAmount_TextChanged(object sender, EventArgs e)
        {

        }

        void TotalNew()
        {

            decimal total = 0;
            decimal disco = 0;
            decimal gst = 0;
            decimal cgst = 0;
            decimal sgst = 0;
            decimal total1 = 0;
            decimal tcgst = 0;
            decimal tsgst = 0;
            decimal total123 = 0;

            decimal grandtotal = 0;
            decimal cgstot = 0;
            decimal sgstot = 0;

            decimal disTotal = 0;
            decimal distot = 0;
            decimal Tot = 0;
            decimal dis = 0;

            // dt = (DataTable)ViewState["dt"];

            dtt = (DataTable)ViewState["Newdt"];

            foreach (DataRow dr in dtt.Rows)
            {
                decimal Discamt = 0;
                gst = Convert.ToDecimal(dr["gst"]) / 2;
                total += Convert.ToDecimal(dr["Amount"]);
                decimal tooo = Convert.ToDecimal(dr["Amount"]);
                decimal tooo1 = Convert.ToDecimal(dr["Amount"]);

                disTotal += Convert.ToDecimal(dr["Amount"]);
                decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                Tot = Convert.ToDecimal(ttoo);
                // dis = Convert.ToDecimal(txtdiscou.Text) / 100;
                Discamt = Tot * dis;


                // lbldisco.Text = Convert.ToDecimal(Discamt).ToString("f2");
                distot += Convert.ToDecimal(Discamt);

                tooo = tooo1 - Discamt;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gst)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;

                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;

                //cgst = (gst * Convert.ToDecimal(dr["Amount"])) / 100;
                //sgst = (gst * Convert.ToDecimal(dr["Amount"])) / 100;
                //total1 = total1 + cgst + sgst + Convert.ToDecimal(dr["Amount"]);
                //total123 = total123 + Convert.ToDecimal(dr["Amount"]);
                //tcgst += cgst;
                //tsgst += sgst;

            }


            ////lblTotal.Text = total.ToString();
            //lblsubtotal.Text = total.ToString();
            ////Label1.Text = total.ToString();
            //lblGrandtotal.Text = grandtotal.ToString("0.00");
            // lbldisco.Text = distot.ToString("0.00");
            // lblDisTotal.Text = distot.ToString();


            ////txt_ServiceTaxamount.Text = (cgstot + sgstot).ToString("0.00");
            ////shwcgst.Text = txt_ServiceTaxamount.Text;



            //   decimal pkAmount = Convert.ToDecimal(TextBox1.Text);
            //   decimal otAmount = Convert.ToDecimal(TextBox2.Text);
            //   total123 = total123 + pkAmount + otAmount;
            //   total1 = total1 + pkAmount + otAmount;
            //  lblTotal.Text = total.ToString();


            //  if (chkradbuttonn.SelectedValue == "1")
            //  {
            //      Label1.Text = total123.ToString();

            //      lblTotalAmount.Text = total123.ToString();
            //      lblGrandtotal.Text = total123.ToString();
            //  }
            //  else if (chkradbuttonn.SelectedValue == "4")
            //  {
            //      Label1.Text = total1.ToString();

            //      lblTotalAmount.Text = total1.ToString();
            //      lblGrandtotal.Text = total1.ToString();
            //  }

            //  txt_VATAmount.Text = "0";
            //  shwcgst.Text = txt_ServiceTaxamount.Text;
            //  //shwsgst.Text = txt_VATAmount.Text;

            //  decimal Totl = Convert.ToDecimal(lblGrandtotal.Text);
            //  decimal Serive = Convert.ToDecimal(txtservicetax.Text);
            //  decimal dDisco = Convert.ToDecimal(txtdiscou.Text);
            //  decimal disamt = (total * dDisco) / 100;
            //  decimal Service_amt = (Totl * Serive) / 100;
            //  lblserviceamt.InnerText = Convert.ToString(Service_amt);
            //  lbldisamt.InnerText = Convert.ToString(disamt);
            ////  lbldisco.Text = Convert.ToString(disamt);

            //  decimal too = total - disamt;

            //  txt_ServiceTaxamount.Text = ((too * 5)/100 ).ToString();


            //  decimal Grand = Service_amt + Totl - disamt;
            //  decimal Grand1 = Math.Round(Grand, 0);
            //  //if (Grand > Grand1)
            //  //{
            //  //    lblRoundoff.Text = Convert.ToString(Grand - Grand1);
            //  //}
            //  //else
            //  //{
            //  //    lblRoundoff.Text = Convert.ToString(Grand1 - Grand);
            //  //}
            //  //lbltotal.Text = Convert.ToString(Grand1);
            //  lblGrandtotal.Text = Convert.ToString(Grand);



        }

        void Total1()
        {


            //decimal total = 0;
            //decimal disco = 0;
            //decimal gst = 0;
            //decimal cgst = 0;
            //decimal sgst = 0;
            //decimal total1 = 0;
            //decimal tcgst = 0;
            //decimal tsgst = 0;
            //decimal total123 = 0;
            //dt = (DataTable)ViewState["dt"];
            //dtt = (DataTable)ViewState["Newdt"];

            //foreach (DataRow dr in dt.Rows)
            //{
            //    gst = Convert.ToDecimal(dr["gst"]) / 2;
            //    total += Convert.ToDecimal(dr["Amount"]);
            //    cgst = (gst * Convert.ToDecimal(dr["Amount"])) / 100;
            //    sgst = (gst * Convert.ToDecimal(dr["Amount"])) / 100;
            //    total1 = total1 + cgst + sgst + Convert.ToDecimal(dr["Amount"]);
            //    total123 = total123 + Convert.ToDecimal(dr["Amount"]);
            //    tcgst += cgst;
            //    tsgst += sgst;
            //}
            //decimal pkAmount = Convert.ToDecimal(TextBox1.Text);
            //decimal otAmount = Convert.ToDecimal(TextBox2.Text);

            //total123 = total123 + pkAmount + otAmount;
            //total1 = total1 + pkAmount + otAmount;
            //lblTotal.Text = total.ToString();
            //if (chkradbuttonn.SelectedValue == "1")
            //{
            //    Label1.Text = total123.ToString();

            //    lblTotalAmount.Text = total123.ToString();
            //    lblGrandtotal.Text = total123.ToString();
            //}
            //else if (chkradbuttonn.SelectedValue == "4")
            //{
            //    Label1.Text = total1.ToString();

            //    lblTotalAmount.Text = total1.ToString();
            //    lblGrandtotal.Text = total1.ToString();
            //}
            //txt_ServiceTaxamount.Text = (tcgst + tsgst).ToString();
            ////  txt_VATAmount.Text = tsgst.ToString();
            //shwcgst.Text = txt_ServiceTaxamount.Text;
            ////  shwsgst.Text = txt_VATAmount.Text;

            //decimal Totl = Convert.ToDecimal(lblGrandtotal.Text);
            //decimal Serive = Convert.ToDecimal(txtservicetax.Text);
            //decimal dDisco = Convert.ToDecimal(txtdiscount.Text);
            //decimal disamt = (Totl * dDisco) / 100;
            //decimal Service_amt = (Totl * Serive) / 100;
            //lblserviceamt.InnerText = Convert.ToString(Service_amt);
            //lbldisamt.InnerText = Convert.ToString(disamt);

            //decimal Grand = Service_amt + Totl - disamt;
            //decimal Grand1 = Math.Round(Grand, 0);
            ////if (Grand > Grand1)
            ////{
            ////    lblRoundoff.Text = Convert.ToString(Grand - Grand1);
            ////}
            ////else
            ////{
            ////    lblRoundoff.Text = Convert.ToString(Grand1 - Grand);
            ////}
            ////lbltotal.Text = Convert.ToString(Grand1);
            //lblGrandtotal.Text = Convert.ToString(Grand);

            if (ViewState["Total"] != null)
            {
                string a = ViewState["Total"].ToString();
                string b = ViewState["GTotal"].ToString();

            }

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



            dt = (DataTable)ViewState["Newdt"];

            foreach (DataRow dr in dt.Rows)
            {
                decimal Discamt = 0;
                //if (dr["Disamt"].ToString() != "")
                //{
                //    disco += Convert.ToDecimal(dr["Disamt"]);
                //}
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



                lbldisco1.Text = Convert.ToDecimal(Discamt).ToString("f2");
                distot += Convert.ToDecimal(Discamt);

                tooo = tooo1 - Discamt;

                string GSt = (dr["gst"]).ToString();
                string amountt = (dr["gst"]).ToString();
                decimal gsthaf1 = Convert.ToDecimal(GSt) / 2;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gsthaf1)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;
                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;
            }



            lbltotal1g.Text = total.ToString();
            lblGrandTotal1g.Text = grandtotal.ToString();



            lblcgstg.Text = (cgstot).ToString("0.00");
            lblsgstg.Text = (sgstot).ToString("0.00");
            // decimal Grand = grandtotal + Packing;
            decimal Packing = Convert.ToDecimal(0);
            decimal Delivery = Convert.ToDecimal(0);
            decimal Grand1 = (grandtotal + Packing + Delivery);

            lblGrandTotal1g.Text = (Grand1).ToString("0.00");
            decimal grandtot = Grand1;
            txtTax.Text = (cgstot + sgstot).ToString("0.00");



            //lbltotal.Text = Convert.ToString(Grand1);
            lblGrandTotal1g.Text = (Grand1).ToString("0.00");
            lblsubttlg.Text = (Grand1).ToString("0.00");
            lbldisplay.InnerText = Grand1.ToString("0.00");
            lbltotqtyg.Text = TQty.ToString("0.00");

        }

        void Total()
        {


            //decimal total = 0;
            //decimal disco = 0;
            //decimal gst = 0;
            //decimal cgst = 0;
            //decimal sgst = 0;
            //decimal total1 = 0;
            //decimal tcgst = 0;
            //decimal tsgst = 0;
            //decimal total123 = 0;
            //dt = (DataTable)ViewState["dt"];
            //dtt = (DataTable)ViewState["Newdt"];

            //foreach (DataRow dr in dt.Rows)
            //{
            //    gst = Convert.ToDecimal(dr["gst"]) / 2;
            //    total += Convert.ToDecimal(dr["Amount"]);
            //    cgst = (gst * Convert.ToDecimal(dr["Amount"])) / 100;
            //    sgst = (gst * Convert.ToDecimal(dr["Amount"])) / 100;
            //    total1 = total1 + cgst + sgst + Convert.ToDecimal(dr["Amount"]);
            //    total123 = total123 + Convert.ToDecimal(dr["Amount"]);
            //    tcgst += cgst;
            //    tsgst += sgst;
            //}
            //decimal pkAmount = Convert.ToDecimal(TextBox1.Text);
            //decimal otAmount = Convert.ToDecimal(TextBox2.Text);

            //total123 = total123 + pkAmount + otAmount;
            //total1 = total1 + pkAmount + otAmount;
            //lblTotal.Text = total.ToString();
            //if (chkradbuttonn.SelectedValue == "1")
            //{
            //    Label1.Text = total123.ToString();

            //    lblTotalAmount.Text = total123.ToString();
            //    lblGrandtotal.Text = total123.ToString();
            //}
            //else if (chkradbuttonn.SelectedValue == "4")
            //{
            //    Label1.Text = total1.ToString();

            //    lblTotalAmount.Text = total1.ToString();
            //    lblGrandtotal.Text = total1.ToString();
            //}
            //txt_ServiceTaxamount.Text = (tcgst + tsgst).ToString();
            ////  txt_VATAmount.Text = tsgst.ToString();
            //shwcgst.Text = txt_ServiceTaxamount.Text;
            ////  shwsgst.Text = txt_VATAmount.Text;

            //decimal Totl = Convert.ToDecimal(lblGrandtotal.Text);
            //decimal Serive = Convert.ToDecimal(txtservicetax.Text);
            //decimal dDisco = Convert.ToDecimal(txtdiscount.Text);
            //decimal disamt = (Totl * dDisco) / 100;
            //decimal Service_amt = (Totl * Serive) / 100;
            //lblserviceamt.InnerText = Convert.ToString(Service_amt);
            //lbldisamt.InnerText = Convert.ToString(disamt);

            //decimal Grand = Service_amt + Totl - disamt;
            //decimal Grand1 = Math.Round(Grand, 0);
            ////if (Grand > Grand1)
            ////{
            ////    lblRoundoff.Text = Convert.ToString(Grand - Grand1);
            ////}
            ////else
            ////{
            ////    lblRoundoff.Text = Convert.ToString(Grand1 - Grand);
            ////}
            ////lbltotal.Text = Convert.ToString(Grand1);
            //lblGrandtotal.Text = Convert.ToString(Grand);

            if (ViewState["Total"] != null)
            {
                string a = ViewState["Total"].ToString();
                string b = ViewState["GTotal"].ToString();

            }

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
                //if (dr["Disamt"].ToString() != "")
                //{
                //    disco += Convert.ToDecimal(dr["Disamt"]);
                //}
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



                //lbldisco.Text = Convert.ToDecimal(Discamt).ToString("f2");
                distot += Convert.ToDecimal(Discamt);

                tooo = tooo1 - Discamt;

                string GSt = (dr["Tax"]).ToString();
                string amountt = (dr["Tax"]).ToString();
                decimal gsthaf1 = Convert.ToDecimal(GSt) / 2;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gsthaf1)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;
                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;
            }



            lbltotal1.Text = total.ToString();
            lblGrandTotal1.Text = grandtotal.ToString();



            lblcgst.Text = (cgstot).ToString("0.00");
            lblsgst.Text = (sgstot).ToString("0.00");
            // decimal Grand = grandtotal + Packing;
            decimal Packing = Convert.ToDecimal(0);
            decimal Delivery = Convert.ToDecimal(0);
            decimal Grand1 = (grandtotal + Packing + Delivery);

            lblGrandTotal1.Text = (Grand1).ToString("0.00");
            decimal grandtot = Grand1;
            txtTax.Text = (cgstot + sgstot).ToString("0.00");



            //lbltotal.Text = Convert.ToString(Grand1);
            lblGrandTotal1.Text = (Grand1).ToString("0.00");
            lblsubttl.Text = (Grand1).ToString("0.00");
            lbldisplay.InnerText = Grand1.ToString("0.00");
            lbltotqty.Text = TQty.ToString("0.00");

        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
        }


        protected void txtAdvance_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount1.Text != "")
            {
                decimal dDiscount = Convert.ToDecimal(txtDiscount1.Text);
                decimal dSubTotal = Convert.ToDecimal(lbltotal1.Text);
                decimal Advance = Convert.ToDecimal(txtAdvance.Text);
                decimal dDiscAmt = dSubTotal - ((dDiscount * dSubTotal) / 100);
                decimal dAmount = dDiscAmt - Advance;
                lblGrandTotal1.Text = dAmount.ToString("f2");
                lbldisplay.InnerText = dAmount.ToString("f2");
            }
        }


        protected void txtReceived_TextChanged(object sender, EventArgs e)
        {
            decimal dTot = Convert.ToDecimal(lblGrandTotal1.Text);
            decimal dCash = Convert.ToDecimal(txtReceived.Text);

            decimal dBal = dCash - dTot;
            txtBal.Text = dBal.ToString("f2");
        }

        protected void otp_chnaged(object sender, EventArgs e)
        {
            txtDiscount1.Enabled = true;
        }

        protected void disc_checkedchanged(object sender, EventArgs e)
        {
            if (chkdisc.Checked == true)
            {
                txtdiscotp.Enabled = true;
                //txtDiscount.Focus();
            }
            else
            {
                txtdiscotp.Enabled = false;
                txtdiscotp.Text = "";
                txtDiscount1.Text = "0";
            }
        }

        protected void Name(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            lblbilltype.InnerText = btn.Text;
            string hex = " #9e6d32";
            Color c = ColorTranslator.FromHtml(hex);
            if (btn.Text == "Home Delivery")
            {
                cust.Visible = true;
                Address.Visible = true;
                billtypeid.Text = "3";

                btnhome.BackColor = System.Drawing.Color.Green;
                Button6.BackColor = c;
                Button7.BackColor = c;

            }
            else if (btn.Text == "Take Away")
            {
                cust.Visible = false;
                Address.Visible = false;
                billtypeid.Text = "1";
                btnhome.BackColor = c;
                Button6.BackColor = c;
                Button7.BackColor = System.Drawing.Color.Green;

            }
            else
            {
                cust.Visible = false;
                Address.Visible = false;
                billtypeid.Text = "2";
                btnhome.BackColor = c;
                Button6.BackColor = System.Drawing.Color.Green;
                Button7.BackColor = c;

            }
        }

        protected void service(object sender, EventArgs e)
        {
            Total();
            mp1.Show();
        }
        protected void Qty_chnaged(object sender, EventArgs e)
        {
            decimal ShwQty = 0;
            decimal Qty = 0;
            decimal Reqty = 0;
            decimal recQty = 0;
            decimal iQty = 0;
            string sItem = "";
            // int iscombo = 0;
            string combo = "";
            decimal dCalTotal = 0;
            decimal dRate = 0, dAmount = 0, dAvlQty = 0, Orrate = 0;
            int iSubCatID = 0;
            int CatID = 0;
            int stockID = 0;
            string sTempViewState = "";

            dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];
            DataSet dCat = new DataSet();
            if (NtxtQty.Text == "0" || NtxtQty.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Qty.It cannot be Zero Or blank.');", true);
                NtxtQty.Focus();
                return;
            }

            {
                dCat = objbs.GetStockDetailsNeww(Convert.ToInt32(drpitemNew.SelectedValue), Convert.ToInt32(0), sTableName);
                //   iscombo = 0;
            }


            if (dCat.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                {


                    sItem = dCat.Tables[0].Rows[i]["definition"].ToString();
                    combo = dCat.Tables[0].Rows[i]["comboo"].ToString();
                    CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                    // iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString()); 7 dec harish
                    stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["categoryuserid"].ToString());
                    //   dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());  7 dec harish
                    Orrate = Convert.ToDecimal(dCat.Tables[0].Rows[i][Rate].ToString());
                    dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i][Rate].ToString());
                    //  }


                    //  DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[i]["Expirydate"].ToString()); 7dec harish

                    sItem = dCat.Tables[0].Rows[i]["definition"].ToString();





                    DataRow[] rows = dt.Select("Definition='" + sItem + "' ");
                    if (rows.Length > 0)
                    {
                        //////if (btn.CommandName == "16")
                        //////{
                        //////    ShwQty = Convert.ToInt32(rows[0]["Qty"].ToString());
                        //////    ShwQty = ShwQty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_Qty"].ToString())));
                        //////}
                        //////else
                        {
                            ShwQty = Convert.ToInt32(rows[0]["Qty"].ToString());
                            ShwQty = ShwQty + Convert.ToDecimal(NtxtQty.Text);
                        }

                        Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                        //  Qty = Qty + 1;
                        //////  recQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                        recQty = Convert.ToDecimal(0);
                        //  recQtyy = Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                        //////  Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                        Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(0)));
                        rows[0]["Qty"] = ShwQty.ToString();


                        //  decimal amt = Convert.ToDecimal(rows[0]["Qty"].ToString()) * dRate;
                        decimal amt = Convert.ToDecimal(ShwQty) * dRate;
                        rows[0]["Amount"] = amt.ToString("0.00");
                        // rows[0]["RecQty"] = recQty.ToString();
                    }
                    else
                    {
                        Qty = Convert.ToDecimal(NtxtQty.Text);
                        ShwQty = 0;
                        Reqty = 0;
                        DataRow dr = dt.NewRow();
                        Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(0)));
                        ////// Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                        //////if (btn.CommandName == "16")
                        //////{
                        //////    Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_Qty"].ToString())));
                        //////}
                        //////else if (btn.CommandName == "18")
                        //////{
                        //////    Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_Qty"].ToString())));

                        //////}
                        //////else
                        {
                            ////// Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                            Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(0)));
                        }
                        //Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                        // Qty = Qty + 1;
                        ShwQty = ShwQty + Convert.ToDecimal(NtxtQty.Text);
                        decimal amt = 0;
                        dr["gst"] = dCat.Tables[0].Rows[i]["gst"].ToString();
                        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["CategoryUserID"].ToString();
                        dr["definition"] = dCat.Tables[0].Rows[i]["definition"].ToString();
                        // dr["StockID"] = 0; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                        //dr["Available_QTY"] = 0;// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                        dr["Qty"] = ShwQty.ToString();
                        dr["Print"] = "0";
                        dr["kotno"] = lblOrdeNo.InnerText;
                        dr["Rate"] = Convert.ToDecimal(Orrate).ToString("0.00");
                        //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);
                        ////if (btn.CommandName == "16")
                        ////{
                        ////    amt = Convert.ToDecimal(Reqty) * dRate;
                        ////}
                        ////else if (btn.CommandName == "18")
                        ////{
                        ////    amt = Convert.ToDecimal(Reqty) * dRate;
                        ////}
                        ////else
                        {
                            amt = Convert.ToDecimal(ShwQty) * dRate;
                        }
                        dr["Amount"] = amt.ToString("f2");







                        dt.Rows.Add(dr);
                        ViewState["dt"] = dt;
                        ViewState["Newdt"] = dtt;
                    }

                    //  objbs.InsertKitchenDisplay(dCat.Tables[0].Rows[i]["Itemid"].ToString(), txtBillNo.Text, Qty.ToString(), "Dine", sTableName);
                    gvlist.DataSource = dt;
                    gvlist.DataBind();



                    Total();



                    // txtService_changed(sender, e);
                }
            }
            NtxtQty.Text = "";
            NtxtQty.Focus();
            drpitemNew.ClearSelection();
        }
        protected void btnback_click(object sender, EventArgs e)
        {
            //itemname.Visible = false;
            // categoryname.Visible = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (lblbilltype.InnerText != "")
            {

                Button btn = (Button)sender;


                ViewState["SubID"] = Convert.ToInt32(btn.CommandArgument);
                if (btn.Text != "All")
                {
                    item.Visible = true;
                    allitem.Visible = false;

                    DataSet dCat = objbs.SelectDistinctItems(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(0), sTableName, StockOption);
                    int icount = dCat.Tables[0].Rows.Count;
                    DataTable dt1 = new DataTable();
                    DataRow dr1 = null;
                    dt1.Columns.Add(new DataColumn("Definition", typeof(string)));
                    dt1.Columns.Add(new DataColumn("Item", typeof(string)));
                    dt1.Columns.Add(new DataColumn("CategoryUserID", typeof(string)));
                    dt1.Columns.Add(new DataColumn("CategoryID", typeof(string)));
                    dt1.Columns.Add(new DataColumn("Image", typeof(string)));
                    dt1.Columns.Add(new DataColumn("Rate", typeof(string)));



                    for (int i = 0; i < icount; i++)
                    {
                        decimal dStock = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString());
                        string sTock = dStock.ToString("f1");


                        dr1 = dt1.NewRow();
                        dr1["Definition"] = dCat.Tables[0].Rows[i]["Printitem"].ToString() + Environment.NewLine + " (" + sTock + ")";// dCat.Tables[0].Rows[i]["Definition"].ToString(); //+ " (" + sTock + ")";
                        //dr1["Item"] = dCat.Tables[0].Rows[i]["Item"].ToString();
                        dr1["Item"] = "";
                        dr1["CategoryUserID"] = dCat.Tables[0].Rows[i]["CategoryUserID"].ToString();
                        dr1["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                        dr1["Image"] = dCat.Tables[0].Rows[i]["imageupload"].ToString();
                        dr1["Rate"] = Convert.ToDouble(dCat.Tables[0].Rows[i]["Rate"]).ToString("0.00");
                        btn.ID = dCat.Tables[0].Rows[i]["CategoryUserID"].ToString();

                        dt1.Rows.Add(dr1);




                    }

                    datkot.DataSource = dt1;
                    datkot.DataBind();
                    // itemname.Visible = true;
                    //categoryname.Visible = false;
                    // UpdatePanel1.Update();

                }
                else
                {
                    DataSet dCat = objbs.SelectDistinctItems(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(0), "All", StockOption);
                    item.Visible = false;
                    allitem.Visible = true;

                    drpitemNew.DataSource = dCat.Tables[0];
                    drpitemNew.DataTextField = "Defi";
                    drpitemNew.DataValueField = "StockID";

                    drpitemNew.DataBind();
                    drpitemNew.Items.Insert(0, "Select Item");

                    NtxtQty.Focus();
                    //itemname.Visible = true;
                    //categoryname.Visible = false;
                    //  UpdatePanel1.Update();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Select Bill Type');", true);
            }





        }

        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = gvlist.Rows[index];
            dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];
            string Item = gvlist.Rows[index].Cells[0].Text;
            Label categoryuser = (Label)gvlist.Rows[index].FindControl("lblcategoryuserid");

            if (e.CommandName == "minus")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text)
                    {
                        int qty = Convert.ToInt32(dr["Qty"].ToString());


                        decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                        decimal amt = 0;
                        int final = qty - 1;

                        dr["Qty"] = final.ToString();

                        amt = final * rate;
                        dr["Amount"] = amt.ToString("f2");
                        if (dr["Qty"].ToString() == "0")
                        {
                            dt.Rows.Remove(dr);
                        }
                        ViewState["dt"] = dt;

                        ViewState["Newdt"] = dtt;

                        break;
                    }
                }


                // Total();

            }
            else
            {



                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text)
                    {
                        dt.Rows.Remove(dr);
                        ViewState["dt"] = dt;
                        break;
                    }
                }
            }
            Total();


            gvlist.DataSource = dt;
            gvlist.DataBind();

        }

        protected void gvlist_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = GridView1all.Rows[index];
            dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];
            string Item = GridView1all.Rows[index].Cells[0].Text;
            Label categoryuser = (Label)GridView1all.Rows[index].FindControl("lblcategoryuserid");
            Label lblkotid = (Label)GridView1all.Rows[index].FindControl("lblkotid");

            if (e.CommandName == "minus")
            {
                foreach (DataRow dr in dtt.Rows)
                {
                    //  if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text) //   18-4-2018
                    if (dr["kotid"].ToString().Trim() == lblkotid.Text)
                    {
                        int qty = Convert.ToInt32(dr["BillQty"].ToString());


                        decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                        decimal amt = 0;
                        int final = qty - 1;

                        if (final < 0)
                        {
                            final = 0;
                        }

                        dr["BillQty"] = final.ToString();

                        amt = final * rate;
                        dr["Amount"] = amt.ToString("f2");
                        //if (dr["Qty"].ToString() == "0")
                        //{
                        //    dt.Rows.Remove(dr);
                        //}
                        ViewState["dt"] = dtt;

                        ViewState["Newdt"] = dtt;

                        ViewState["chckdt"] = dtt;

                        break;
                    }
                }


                // Total();

            }
            else if (e.CommandName == "add")
            {
                foreach (DataRow dr in dtt.Rows)
                {
                    //   if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text) 18-4-2218
                    if (dr["kotid"].ToString().Trim() == lblkotid.Text)
                    {

                        int aqty = Convert.ToInt32(dr["Qty"].ToString());
                        int qty = Convert.ToInt32(dr["BillQty"].ToString());

                        if (aqty > qty)
                        {
                            decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                            decimal amt = 0;
                            int final = qty + 1;
                            if (final < 0)
                            {
                                final = 0;
                            }
                            dr["BillQty"] = final.ToString();
                            amt = final * rate;
                            dr["Amount"] = amt.ToString("f2");
                            //if (dr["Qty"].ToString() == "0")
                            //{
                            //    dt.Rows.Remove(dr);
                            //}
                            ViewState["dt"] = dtt;
                            ViewState["Newdt"] = dtt;
                            break;

                        }
                    }
                }


                // Total();

            }
            else
            {



                foreach (DataRow dr in dtt.Rows)
                {
                    // if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text) 18-4-2018
                    if (dr["kotid"].ToString().Trim() == lblkotid.Text)
                    {
                        dtt.Rows.Remove(dr);
                        ViewState["dt"] = dtt;
                        break;
                    }
                }
            }

            TotalNew();


            GridView1all.DataSource = dtt;
            GridView1all.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            decimal ShwQty = 0;
            decimal Qty = 0;
            decimal GST = 0;
            decimal Reqty = 0;
            decimal recQty = 0;
            decimal iQty = 0;
            string sItem = "";
            // int iscombo = 0;
            string combo = "";
            decimal dCalTotal = 0;
            decimal dRate = 0, dAmount = 0, dAvlQty = 0, Orrate = 0;
            int iSubCatID = 0;
            int CatID = 0;
            int stockID = 0;
            string sTempViewState = "";

            dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];
            DataSet dCat = new DataSet();
            //ImageButton btn = (ImageButton)sender;
            Button btn = (Button)sender;
            //////if (btn.CommandName == "16")
            //////{
            //////    dCat = objbs.GetStockDetailscombo(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(0), sTableName, Rate);
            //////    //  iscombo = 1;
            //////}
            //////else if (btn.CommandName == "18")
            //////{
            //////    //if (ddlBillType.SelectedValue == "D")
            //////    //{
            //////    dCat = objbs.GetStockDetailsOffer(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(0), sTableName);
            //////    // }
            //////    //  iscombo = 0;
            //////}
            //////else
            {
                dCat = objbs.GetStockDetailsNeww(Convert.ToInt32(btn.CommandArgument), Convert.ToInt32(0), sTableName);
                //   iscombo = 0;
            }


            if (dCat.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
                {


                    sItem = dCat.Tables[0].Rows[i]["definition"].ToString();
                    combo = dCat.Tables[0].Rows[i]["comboo"].ToString();
                    CatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["CategoryID"].ToString());
                    // iSubCatID = Convert.ToInt32(dCat.Tables[0].Rows[i]["StockID"].ToString()); 7 dec harish
                    stockID = Convert.ToInt32(dCat.Tables[0].Rows[i]["categoryuserid"].ToString());
                    dAvlQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_QTY"].ToString()); // 7 dec harish
                    Orrate = Convert.ToDecimal(dCat.Tables[0].Rows[i][Rate].ToString());
                    dRate = Convert.ToDecimal(dCat.Tables[0].Rows[i][Rate].ToString());
                    GST = Convert.ToDecimal(dCat.Tables[0].Rows[0]["GST"].ToString());
                    //  }


                    //  DateTime expDate = Convert.ToDateTime(dCat.Tables[0].Rows[i]["Expirydate"].ToString()); 7dec harish

                    sItem = dCat.Tables[0].Rows[i]["definition"].ToString();





                    DataRow[] rows = dt.Select("Definition='" + sItem + "' ");
                    if (rows.Length > 0)
                    {
                        //////if (btn.CommandName == "16")
                        //////{
                        //////    ShwQty = Convert.ToInt32(rows[0]["Qty"].ToString());
                        //////    ShwQty = ShwQty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_Qty"].ToString())));
                        //////}
                        //////else
                        {
                            ShwQty = Convert.ToInt32(rows[0]["Qty"].ToString());
                            ShwQty = ShwQty + 1;
                        }

                        //Qty = Convert.ToInt32(rows[0]["Qty"].ToString());
                        //  Qty = Qty + 1;
                        //////  recQty = Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                        // recQty = Convert.ToDecimal(0);
                        //  recQtyy = Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                        //////  Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                        //  Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(0)));
                        //  rows[0]["Qty"] = ShwQty.ToString();


                        //  decimal amt = Convert.ToDecimal(rows[0]["Qty"].ToString()) * dRate;

                        // rows[0]["RecQty"] = recQty.ToString();
                        if (StockOption == "2")
                        {

                            rows[0]["Qty"] = ShwQty.ToString();
                            decimal amt = Convert.ToDecimal(ShwQty) * dRate;
                            rows[0]["Amount"] = amt.ToString("f2");

                        }

                        if (StockOption == "1")
                        {
                            if (dAvlQty >= ShwQty)
                            {
                                rows[0]["Qty"] = ShwQty.ToString();


                                decimal amt = Convert.ToDecimal(ShwQty) * dRate;
                                rows[0]["Amount"] = amt.ToString("f2");
                            }
                        }
                    }
                    else
                    {
                        Qty = 0;
                        ShwQty = 0;
                        Reqty = 0;
                        DataRow dr = dt.NewRow();
                        Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(0)));
                        ////// Qty = Qty + Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                        //////if (btn.CommandName == "16")
                        //////{
                        //////    Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_Qty"].ToString())));
                        //////}
                        //////else if (btn.CommandName == "18")
                        //////{
                        //////    Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["Available_Qty"].ToString())));

                        //////}
                        //////else
                        {
                            ////// Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString())));
                            Reqty = Convert.ToDecimal(Math.Floor(Convert.ToDecimal(0)));
                        }
                        //Convert.ToDecimal(dCat.Tables[0].Rows[i]["RecQty"].ToString());
                        // Qty = Qty + 1;
                        ShwQty = ShwQty + 1;
                        decimal amt = 0;

                        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
                        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["CategoryUserID"].ToString();
                        dr["definition"] = dCat.Tables[0].Rows[i]["definition"].ToString();
                        // dr["StockID"] = 0; //dCat.Tables[0].Rows[i]["StockID"].ToString();
                        dr["Available_QTY"] = Convert.ToDecimal(dAvlQty).ToString("f0");// dCat.Tables[0].Rows[i]["Available_QTY"].ToString();
                        dr["Qty"] = ShwQty.ToString();
                        dr["Print"] = "0";
                        dr["gst"] = dCat.Tables[0].Rows[i]["gst"].ToString();
                        dr["kotno"] = lblOrdeNo.InnerText;
                        dr["Rate"] = Convert.ToDecimal(Orrate).ToString("0.00");
                        dr["Tax"] = Convert.ToDecimal(GST);
                        //decimal amt = Convert.ToDecimal(dr["qty"].ToString()) * Convert.ToDecimal(dRate);
                        ////if (btn.CommandName == "16")
                        ////{
                        ////    amt = Convert.ToDecimal(Reqty) * dRate;
                        ////}
                        ////else if (btn.CommandName == "18")
                        ////{
                        ////    amt = Convert.ToDecimal(Reqty) * dRate;
                        ////}
                        ////else
                        {
                            amt = Convert.ToDecimal(ShwQty) * dRate;
                        }
                        dr["Amount"] = amt.ToString("0.00");







                        dt.Rows.Add(dr);
                        ViewState["dt"] = dt;
                        ViewState["Newdt"] = dt;
                    }

                    //  objbs.InsertKitchenDisplay(dCat.Tables[0].Rows[i]["Itemid"].ToString(), txtBillNo.Text, Qty.ToString(), "Dine", sTableName);
                    gvlist.DataSource = dt;
                    gvlist.DataBind();

                    iCntt = gvlist.Rows.Count;


                    Total();


                    //itemname.Visible = false;
                    //categoryname.Visible = true;
                    // txtService_changed(sender, e);
                }
            }

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["dt"];
            int isprin = 0;
            if (dt.Rows.Count > 0)
            {

                //  int salkot = objbs.insertkotOrder("tblRestaurantkot_" + sTableName, lblOrdeNo.InnerText, lblDate.InnerText, Convert.ToDouble(lblTotal.Text), Convert.ToDouble(lblTotal.Text), lblbilltype.InnerText, Convert.ToInt32(lbltableid.InnerText), "1", salesid.InnerText,"tblTransrestaurantKot_"+sTableName);


                //   int isalesid1 = Convert.ToInt32(salkot);

                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dt);
                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
                DataSet dstd = new DataSet();
                dttt = new DataTable();

                dct = new DataColumn("CategoryID");
                dttt.Columns.Add(dct);

                dct = new DataColumn("CategoryUserID");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Qty");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Rate");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Amount");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Print");
                dttt.Columns.Add(dct);

                dct = new DataColumn("GST");
                dttt.Columns.Add(dct);

                dstd.Tables.Add(dttt);

                foreach (DataRow dr in ds1.Tables[0].Rows)
                {

                    drNew = dttt.NewRow();
                    drNew["CategoryID"] = dr["CategoryID"];
                    drNew["CategoryUserID"] = dr["Categoryuserid"];
                    drNew["Qty"] = dr["Qty"];
                    drNew["Rate"] = dr["Rate"];
                    drNew["Amount"] = dr["Amount"];
                    drNew["Print"] = dr["Print"];
                    drNew["GST"] = dr["GST"];
                    string prin = dr["Print"].ToString();
                    if (prin == "0")
                    {
                        dstd.Tables[0].Rows.Add(drNew);
                    }
                }
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    string catid = dt.Rows[i]["CategoryID"].ToString();
                //    string itemID = dt.Rows[i]["CategoryUserID"].ToString();
                //    string Qty = dt.Rows[i]["Qty"].ToString();
                //    string Rate = dt.Rows[i]["Rate"].ToString();
                //    string Amount = dt.Rows[i]["Amount"].ToString();
                //    string print = dt.Rows[i]["Print"].ToString();


                //     int iStatus1 = objbs.insertTransSales(" tblTransRestaurantsales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text),combo.Text,DateTime.Now.ToString("yyyy-MM-dd"));
                //  if (dt.Rows[i]["Print"].ToString() != "1")

                int newkot = objbs.insertnewkot(lblbilltype.InnerText, lbltableid.InnerText, lblDate.InnerText, dstd, lbltotal1.Text, lblTotalAmount.Text, sTableName, drpAttender.SelectedValue, Convert.ToInt32(lblUserID.Text), StockOption);



                isprin = newkot;
                //  int trndkot = objbs.insertTranskotorders("tblTransRestaurantkot_" + sTableName, Convert.ToInt32(isalesid1), Convert.ToInt32(catid), Convert.ToDouble(Qty), Convert.ToDouble(Rate), Convert.ToDouble(Amount), int.Parse(itemID), DateTime.Now.ToString("yyyy-MM-dd"),print);

                // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(catid.Text), Convert.ToInt32(ItemID.Text), Convert.ToDecimal(Qty.Text), date, Convert.ToString(stock.Text)); 7 dec
                // }
                // Response.Redirect("RestaurantSalesKot.aspx");
                Refersh();
                //check kot print
                //////////////DataSet dcheckitem = objbs.PrintKOtORder(newkot, sTableName, "");
                //////////////if (dcheckitem.Tables[0].Rows.Count > 0)
                //////////////{

                //////////////    string url = "SalesKOTPrint.aspx?BranchCode="+sTableName+"&Mode=Sales&Type=" + lblbilltype.InnerText + "&iSalesID=" + newkot+"&Store="+Session["Store"].ToString();
                //////////////    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + url + "');", true);
                //////////////}
                ////////////////   Process.Start("D:\\Debug\\Palm_Tree.exe");
                //////////////   int isprintt = objbs.updatenewkot(isprin.ToString(), sTableName);
                //  System.Threading.Thread.Sleep(2000);
                //  Response.Redirect("RestaurantsalesKot.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('No Items Addded');", true);
            }
        }

        void Refersh()
        {
            dt = (DataTable)ViewState["dt"];
            dt.Rows.Clear();
            dtt = (DataTable)ViewState["Newdt"];
            dtt.Rows.Clear();

            splitdt.Clear();

            ViewState["dt"] = null;

            gvlist.DataSource = null;
            gvlist.DataBind();

            datkot.DataSource = null;
            datkot.DataBind();

            GridView1all.DataSource = null;
            GridView1all.DataBind();


            if (Request.QueryString.Get("Ref") != null)
                lbltable.InnerText = Request.QueryString.Get("Ref");

            if (Request.QueryString.Get("id") != null)
                lbltableid.InnerText = Request.QueryString.Get("id");

            lblDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

            //DataSet ds = objbs.SalesBillno("tblRestaurantkot_" + sTableName, "BillDate");
            //if (ds.Tables[0].Rows[0]["billno"].ToString() == "")
            lblOrdeNo.InnerText = "1";
            //else
            //    lblOrdeNo.InnerText = ds.Tables[0].Rows[0]["billno"].ToString();
            ////lblTotal.Text = "0";
            lblTotalAmount.Text = "0";


            ////txt_VATAmount.Text = "0";
            ////txt_ServiceTaxamount.Text = "0";
            ////Label1.Text = "0";


            lblDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

            //lblsubtotal.Text = "0.00";
            //shwcgst.Text = "0.00";
            //lblGrandtotal.Text = "0.00";

            Response.Redirect("RestaurantSalesKot.aspx");


        }


        protected void btnnew_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {

                // int salkot = objbs.insertkotOrderHold("tblRestaurantkot_" + sTableName, lblOrdeNo.InnerText, lblDate.InnerText, Convert.ToDouble(lblTotal.Text), Convert.ToDouble(lblTotal.Text), lblbilltype.InnerText, Convert.ToInt32(lbltableid.InnerText), "0");


                //  int isalesid1 = Convert.ToInt32(salkot);
                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dt);
                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
                DataSet dstd = new DataSet();
                dttt = new DataTable();

                dct = new DataColumn("CategoryID");
                dttt.Columns.Add(dct);

                dct = new DataColumn("CategoryUserID");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Qty");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Rate");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Amount");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Print");
                dttt.Columns.Add(dct);

                dstd.Tables.Add(dttt);

                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    drNew = dttt.NewRow();
                    drNew["CategoryID"] = dr["CategoryID"];
                    drNew["CategoryUserID"] = dr["Categoryuserid"];
                    drNew["Qty"] = dr["Qty"];
                    drNew["Rate"] = dr["Rate"];
                    drNew["Amount"] = dr["Amount"];
                    drNew["Print"] = "0";
                    dstd.Tables[0].Rows.Add(drNew);
                }


                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    string catid = dt.Rows[i]["CategoryID"].ToString();
                //    string itemID = dt.Rows[i]["CategoryUserID"].ToString();
                //    string Qty = dt.Rows[i]["Qty"].ToString();
                //    string Rate = dt.Rows[i]["Rate"].ToString();
                //    string Amount = dt.Rows[i]["Amount"].ToString();
                //    string print = "0";



                //int trndkot = objbs.insertTranskotorders("tblTransRestaurantkot_" + sTableName, Convert.ToInt32(isalesid1), Convert.ToInt32(catid), Convert.ToDouble(Qty), Convert.ToDouble(Rate), Convert.ToDouble(Amount), int.Parse(itemID), DateTime.Now.ToString("yyyy-MM-dd"),print);

                int newkot = objbs.insertnewkot(lblbilltype.InnerText, lbltableid.InnerText, lblDate.InnerText, dstd, lbltotal1.Text, lblTotalAmount.Text, sTableName, drpAttender.SelectedValue, Convert.ToInt32(lblUserID.Text), StockOption);


                //}

                Response.Redirect("RestaurantsalesKot.aspx");

            }
            else
            {
                Response.Redirect("RestaurantsalesKot.aspx");
            }
        }
        void SAveBill()
        {
            //////string iCustid = "";
            //////if (txtmobile.Text != "")
            //////{
            //////    int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(0));
            //////}

            //////else
            //////{
            //////    txtmobile.Text = "0000000000";


            //////}
            //////DataSet dCustid = objbs.GerCustID(txtmobile.Text);
            //////if (dCustid.Tables[0].Rows[0]["IDCustID"].ToString() != "")
            //////{
            //////    iCustid = dCustid.Tables[0].Rows[0]["IDCustID"].ToString();
            //////}
            string iCustid = "";
            if (txtmobile.Text != "")
            {
                int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(0), "0");


            }

            else
            {
                txtmobile.Text = "0000000000";

                DataSet dCustid2 = objbs.GerCustID(txtmobile.Text);
                if (dCustid2.Tables[0].Rows[0]["IDCust"].ToString() != "")
                {
                    iCustid = dCustid2.Tables[0].Rows[0]["IDCust"].ToString();
                }
                else
                {

                    int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(0), "0");
                }


            }
            DataSet dCustid = objbs.GerCustID(txtmobile.Text);
            if (dCustid.Tables[0].Rows[0]["IDCust"].ToString() != "")
            {
                iCustid = dCustid.Tables[0].Rows[0]["IDCust"].ToString();
            }

            if (txtPaid.Text == "")
            {
                txtPaid.Text = "0.00";
            }
            if (lblBalance.Text == "")
            {
                lblBalance.Text = "0.00";
            }
            int OrderBill = 0;
            //objbs.insertOrdersalesnew1("tblTempSales_" + sTableName, Convert.ToInt32(0), "", DateTime.Now.ToString("yyyy-MM-dd hh:mm"), Convert.ToInt32(iCustid), Convert.ToDouble(lblTotal.Text), Convert.ToDouble(lblGrandtotal.Text), Convert.ToDouble(0), Convert.ToDouble(txtdiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(ddpaymode.SelectedValue), Convert.ToDecimal(txtPaid.Text), Convert.ToDecimal(lblBalance.Text), ddcardtype.SelectedValue, Convert.ToDecimal(txtservicetax.Text), Convert.ToDecimal(lblserviceamt.InnerText), Convert.ToDecimal(lblRoundoff.Text), lblbilltype.InnerText, "", txtcashAmount.Text, txtcardAmount.Text, lbltable.InnerText);


            dt = (DataTable)ViewState["dt"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string date = "";
                string extra = "";

                string catid = dt.Rows[i]["CategoryID"].ToString();
                string itemID = dt.Rows[i]["CategoryUserID"].ToString();
                string Qty = dt.Rows[i]["Qty"].ToString();
                string Rate = dt.Rows[i]["Rate"].ToString();
                string Amount = dt.Rows[i]["Amount"].ToString();


                int iStatus1 = 0;
                //objbs.insertTransSales("tblTempTransSales_" + sTableName, Convert.ToInt32(OrderBill), Convert.ToInt32(catid), Convert.ToDouble(Qty), Convert.ToDouble(Rate), Convert.ToDouble(0), Convert.ToDouble(Amount), Convert.ToInt32(itemID), Convert.ToInt32(itemID), extra, Convert.ToDouble(0), "", DateTime.Now.ToString("yyyy-MM-dd"));



            }

            // int kotupdate = objbs.updategettnameval(sTableName, lbltable.InnerText);


            //  DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
            //  if (ds.Tables[0].Rows.Count > 0)
            {
                DataSet dcheckitem = objbs.PrintKOtORder(OrderBill, sTableName, "");
                if (dcheckitem.Tables[0].Rows.Count > 0)
                {
                    string yourUrl = "SalesKOTPrint.aspx?Mode=Sales&Type=DineIN&iSalesID=" + OrderBill + "&BranchCode=" + Session["BranchCode"].ToString() + "&Store=" + Session["Store"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
                }

            }



            //string yourUrl = "SalesKotPrint.aspx?Mode=Sales&iSalesID=" + OrderBill + "&Type=" + lblbilltype.InnerText + "&Print=Temp";



            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);



        }

        protected void btnsettl_click(object sender, EventArgs e)
        {
            CompleteBill();
        }

        void CompleteBill()
        {
            //dt = (DataTable)ViewState["Newdt"];
            //if (dt.Rows.Count > 0)
            //{
            //    if (chkcard.Checked == true)
            //    {
            //        ddpaymode.SelectedValue = "4";
            //        txtPaid.Text = lblGrandtotal.Text;
            //        txtcardAmount.Text = lblGrandtotal.Text;
            //    }
            //    else
            //    {
            //        ddpaymode.SelectedValue = "14";
            //        txtPaid.Text = lblGrandtotal.Text;
            //    }


            //    if (ddpaymode.SelectedValue == "14")
            //    {
            //        if (lblGrandtotal.Text == txtPaid.Text)
            //        {

            //        }
            //        else
            //        {
            //            if (txtPaid.Text == "0")
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Please Enter Amount Received');", true);
            //                return;
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Enter Correct Amount');", true);
            //                return;
            //            }
            //        }
            //    }

            //    if (ddpaymode.SelectedValue == "4")
            //    {
            //        if (lblGrandtotal.Text == txtcardAmount.Text && lblGrandtotal.Text == txtPaid.Text)
            //        {

            //        }
            //        else
            //        {
            //            if (txtPaid.Text == "0")
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Please Enter Amount Received');", true);
            //                return;
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Enter Correct Amount');", true);
            //                return;
            //            }
            //        }
            //    }

            //    if (ddpaymode.SelectedValue == "12")
            //    {
            //        double TotAmt = Convert.ToDouble(txtcardAmount.Text) + Convert.ToDouble(txtcashAmount.Text);
            //        string amt = TotAmt.ToString();
            //        if (lblGrandtotal.Text == amt)
            //        {

            //        }
            //        else
            //        {
            //            if (txtPaid.Text == "0")
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Please Enter Amount Received');", true);
            //                return;
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Enter Correct Amount');", true);
            //                return;
            //            }
            //        }
            //    }
            //    //return;
            //    // lblbilltype.InnerText = btn.Text;

            //    if (lblbilltype.InnerText == "Home Delivery")
            //    {
            //        cust.Visible = true;
            //        Address.Visible = true;
            //        billtypeid.Text = "3";
            //    }
            //    else if (lblbilltype.InnerText == "Take Away")
            //    {
            //        cust.Visible = false;
            //        Address.Visible = false;
            //        billtypeid.Text = "1";
            //    }
            //    else
            //    {
            //        cust.Visible = false;
            //        Address.Visible = false;
            //        billtypeid.Text = "2";

            //    }

            //    string iCustid = "";
            //    if (txtmobile.Text != "")
            //    {
            //        int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1));


            //    }

            //    else
            //    {
            //        txtmobile.Text = "0000000000";

            //        DataSet dCustid2 = objbs.GerCustID(txtmobile.Text);
            //        if (dCustid2.Tables[0].Rows.Count > 0)
            //        {
            //            iCustid = dCustid2.Tables[0].Rows[0]["CustomerID"].ToString();
            //        }
            //        else
            //        {

            //            int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), "ABC", txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1));
            //        }


            //    }
            //    DataSet dCustid = objbs.GerCustID(txtmobile.Text);
            //    if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
            //    {
            //        iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
            //    }
            //    if (txtPaid.Text == "")
            //    {
            //        txtPaid.Text = "0.00";
            //    }
            //    if (lblBalance.Text == "")
            //    {
            //        lblBalance.Text = "0.00";
            //    }


            //    int CreditorID1 = 0;
            //    // DataSet dsledger = objbs.getCashledgerId123("Cash A/C _" + sTableName);
            //    //  CreditorID1 = Convert.ToInt32(dsledger.Tables[0].Rows[0]["LedgerID"].ToString());

            //    int AccID = 0;
            //    int AccIDCash = 0;
            //    int AccIDCard = 0;

            //    //if (drpPayment.SelectedValue == "1")
            //    //{
            //    //    DataSet dsledger1 = objbs.getCashledgerId123("Cash A/C _" + sTableName);
            //    //    AccID = Convert.ToInt32(dsledger1.Tables[0].Rows[0]["LedgerID"].ToString());
            //    //}
            //    //else if (drpPayment.SelectedValue == "4")
            //    //{
            //    //    DataSet dsledger1 = objbs.getCashledgerId123("CardA/C_" + sTableName);
            //    //    AccID = Convert.ToInt32(dsledger1.Tables[0].Rows[0]["LedgerID"].ToString());
            //    //}
            //    lblserviceamt.InnerText = "0";


            //    int OrderBill = 0;
            //    //objbs.CompleteBill(AccID, CreditorID1, "tblDayBook_" + sTableName, "tblsales_" + sTableName, Convert.ToInt32(0), "", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), Convert.ToInt32(iCustid), Convert.ToDouble(lblTotal.Text), Convert.ToDouble(lblGrandtotal.Text), Convert.ToDouble(0), Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(ddpaymode.SelectedValue), Convert.ToDecimal(txtPaid.Text), Convert.ToDecimal(lblBalance.Text), ddcardtype.SelectedValue, Convert.ToDecimal(txtservicetax.Text), Convert.ToDecimal(lblserviceamt.InnerText), Convert.ToDecimal(lblRoundoff.Text), billtypeid.Text, "", txtcashAmount.Text, txtcardAmount.Text, lbltableid.InnerText, txt_ServiceTaxamount.Text, txt_VATAmount.Text, Label1.Text, chkradbuttonn.SelectedValue, TextBox1.Text, TextBox2.Text, drpcomp.SelectedValue, drpcomp.SelectedItem.Text);



            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {

            //        string date = "";
            //        string extra = "";

            //        string catid = dt.Rows[i]["CategoryID"].ToString();
            //        string itemID = dt.Rows[i]["CategoryUserID"].ToString();
            //        string Qty = dt.Rows[i]["Qty"].ToString();
            //        string Rate = dt.Rows[i]["Rate"].ToString();
            //        string Amount = dt.Rows[i]["Amount"].ToString();


            //        int iStatus1 = 0; //objbs.insertTransSales(" tblTranssales_" + sTableName, Convert.ToInt32(OrderBill), Convert.ToInt32(catid), Convert.ToDouble(Qty), Convert.ToDouble(Rate), Convert.ToDouble(0), Convert.ToDouble(Amount), Convert.ToInt32(itemID), Convert.ToInt32(itemID), extra, Convert.ToDouble(0), "", DateTime.Now.ToString("yyyy-MM-dd"));



            //    }

            //    int kotupdate = objbs.Newupdategettnameval(sTableName, lbltableid.InnerText);


            //    //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;
            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
            //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);

            //    Refersh();

            //    Response.Redirect("RestaurantsalesKot.aspx");

            //}
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
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

            #region

            string Approved = "";
            if (ddlApproved.SelectedValue != "Select")
            {
                Approved = ddlApproved.SelectedValue;
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
                                    iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", "", "", "", Convert.ToInt32(drpPayment.SelectedValue), "0");
                                }
                            }
                            else
                            {
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", "", "", "", Convert.ToInt32(drpPayment.SelectedValue), "0");
                            }
                        }

                        if (txtReceived.Text == "")
                        {
                            txtReceived.Text = "0.00";
                        }
                        if (txtBal.Text == "")
                        {
                            txtBal.Text = "0.00";
                        }
                        if (txtDiscount1g.Text == "0")
                        {
                            //  int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text),Convert.ToDouble(lblsgst.Text),Convert.ToDouble(lblsubttl.Text));

                            int OrderBill = objbs.insertOrdersalesnewKot("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, 
                                txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal1g.Text), Convert.ToDouble(lblGrandTotal1g.Text), 
                                Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount1g.Text), Convert.ToInt32("0"), Convert.ToInt32(1), 
                                Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), 
                                Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue,
                                Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgstg.Text), 
                                Convert.ToDouble(lblsgstg.Text), Convert.ToDouble(lblsubttlg.Text), lblmargin.Text, lblmargintax.Text,
                                lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, drpAttend.SelectedValue, 
                                lblKOTTblno.Text, "tblTranssalesAmount_" + sTableName + "");


                            int isalesid = Convert.ToInt32(OrderBill);

                            dt = (DataTable)ViewState["Newdt"];
                            for (int i = 0; i < GridView1all.Rows.Count; i++)
                            {

                                Label catid = (Label)GridView1all.Rows[i].FindControl("categoryid");
                                Label CategoryUserid = (Label)GridView1all.Rows[i].FindControl("CategoryUserid");
                                Label StockID = (Label)GridView1all.Rows[i].FindControl("StockID");

                                TextBox Qty = (TextBox)GridView1all.Rows[i].FindControl("txtQty");
                                //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                TextBox rate = (TextBox)GridView1all.Rows[i].FindControl("Rate");
                                TextBox Amt = (TextBox)GridView1all.Rows[i].FindControl("Amount");
                                //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                Label tax = (Label)GridView1all.Rows[i].FindControl("txttax");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");
                                Label lblkotid = (Label)GridView1all.Rows[i].FindControl("lblkotid");



                                //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, lblkotid.Text, drpsalestype.SelectedValue, Convert.ToDouble(1), "N", "0", Convert.ToDouble(1));



                            }
                            int kotupdate = objbs.Newupdategettnameval(sTableName, lbltableid.InnerText);

                            ///  string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=3&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();

                            // string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                            ///   ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);




                            //////DataSet ds = objbs.PrintingSalesLiveKitchen(OrderBill, sTableName, "Sales");
                            //////if (ds.Tables[0].Rows.Count > 0)
                            //////{

                            //////    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

                            //////    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                            //////    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                            //////}
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
                                iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", "", "", "", Convert.ToInt32(drpPayment.SelectedValue), "0");
                            }
                        }
                        else
                        {
                            iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", "", "", "", Convert.ToInt32(drpPayment.SelectedValue), "0");
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
                            iCustid = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustomerName.Text, txtmobile.Text, "0", "", "", "", Convert.ToInt32(drpPayment.SelectedValue), "0");
                        }

                    }


                    if (txtReceived.Text == "")
                    {
                        txtReceived.Text = "0.00";
                    }
                    if (txtBal.Text == "")
                    {
                        txtBal.Text = "0.00";
                    }
                    if (txtDiscount1g.Text == "0")
                    {
                        //int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));

                        int OrderBill = objbs.insertOrdersalesnewKot("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal1g.Text), Convert.ToDouble(lblGrandTotal1g.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount1g.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgstg.Text), Convert.ToDouble(lblsgstg.Text), Convert.ToDouble(lblsubttlg.Text), lblmargin.Text, lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, drpAttend.SelectedValue, lblKOTTblno.Text, "tblTranssalesAmount_" + sTableName + "");

                        int isalesid = Convert.ToInt32(OrderBill);

                        dt = (DataTable)ViewState["dt"];
                        for (int i = 0; i < GridView1all.Rows.Count; i++)
                        {

                            Label catid = (Label)GridView1all.Rows[i].FindControl("categoryid");
                            Label CategoryUserid = (Label)GridView1all.Rows[i].FindControl("lblcategoryuserid");
                            Label StockID = (Label)GridView1all.Rows[i].FindControl("StockID");

                            TextBox Qty = (TextBox)GridView1all.Rows[i].FindControl("txtQty");
                            //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                            TextBox rate = (TextBox)GridView1all.Rows[i].FindControl("Rate");
                            TextBox Amt = (TextBox)GridView1all.Rows[i].FindControl("Amount");
                            //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                            Label tax = (Label)GridView1all.Rows[i].FindControl("txttax");
                            // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");
                            Label lblkotid = (Label)GridView1all.Rows[i].FindControl("lblkotid");


                            //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                            //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                            int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, lblkotid.Text, drpsalestype.SelectedValue, Convert.ToDouble(1), "N", "0", Convert.ToDouble(1));


                        }

                        int kotupdate = objbs.Newupdategettnameval(sTableName, lbltableid.InnerText);

                        ///  string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=3&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();

                        //   string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                        ///   ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);



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
                        if (txtgiven.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "SelectGiven();", true);
                        }


                        else
                        {
                            // int OrderBill = objbs.insertOrdersalesnew("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal.Text), Convert.ToDouble(lblGrandTotal.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, ddlApproved.SelectedValue, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblsubttl.Text));
                            int OrderBill = objbs.insertOrdersalesnewKot("tblSales_" + sTableName, Convert.ToInt32(lblUserID.Text), txtBillNo.Text, txtBillDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(lbltotal1g.Text), Convert.ToDouble(lblGrandTotal1g.Text), Convert.ToDouble(txtTax.Text), Convert.ToDouble(txtDiscount1g.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(drpPayment.SelectedValue), Convert.ToDecimal(txtReceived.Text), Convert.ToDecimal(txtBal.Text), txtgiven.Text, Approved, ddattender.SelectedValue, Session["empcode"].ToString(), ddlCashier.SelectedValue, Convert.ToDouble(lblcgstg.Text), Convert.ToDouble(lblsgstg.Text), Convert.ToDouble(lblsubttlg.Text), lblmargin.Text, lblmargintax.Text, lblpaygate.Text, drpsalestype.SelectedValue, txtorderno.Text, lblisnormal.Text, drpAttend.SelectedValue, lblKOTTblno.Text, "tblTranssalesAmount_" + sTableName + "");


                            int isalesid = Convert.ToInt32(OrderBill);

                            dt = (DataTable)ViewState["dt"];
                            for (int i = 0; i < gvlist.Rows.Count; i++)
                            {

                                Label catid = (Label)gvlist.Rows[i].FindControl("categoryid");
                                Label CategoryUserid = (Label)gvlist.Rows[i].FindControl("lblcategoryuserid");
                                Label StockID = (Label)gvlist.Rows[i].FindControl("StockID");

                                TextBox Qty = (TextBox)gvlist.Rows[i].FindControl("txtQty");
                                //TextBox SHWQty = (TextBox)gvlist.Rows[i].FindControl("ShwQty");
                                TextBox rate = (TextBox)gvlist.Rows[i].FindControl("Rate");
                                TextBox Amt = (TextBox)gvlist.Rows[i].FindControl("Amount");
                                //  TextBox combo = (TextBox)gvlist.Rows[i].FindControl("Combo");
                                Label tax = (Label)gvlist.Rows[i].FindControl("txttax");
                                // Label lblrecqty = (Label)gvlist.Rows[i].FindControl("lblrecqty");

                                Label lblkotid = (Label)GridView1all.Rows[i].FindControl("lblkotid");

                                //int iStatus1 = objbs.insertTransSales("tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"),tax.Text);
                                //   int iStatus1 = objbs.insertTransSales("tblSales_" + sTableName, "tblTransSales_" + sTableName, Convert.ToInt32(isalesid), Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(ItemID.Text), Convert.ToInt32(stock.Text), extra, Convert.ToDouble(SHWQty.Text), combo.Text, DateTime.Now.ToString("yyyy-MM-dd"), tax.Text, iSalesno, Convert.ToDouble(lblrecqty.Text));

                                int iStatus1 = objbs.insertTransSales(sTableName, isalesid, Convert.ToInt32(catid.Text), Convert.ToDouble(Qty.Text), Convert.ToDouble(rate.Text), Convert.ToDouble(0), Convert.ToDouble(Amt.Text), Convert.ToInt32(CategoryUserid.Text), Convert.ToInt32(StockID.Text), Convert.ToDouble(tax.Text), lblisnormal.Text, lblkotid.Text, drpsalestype.SelectedValue, Convert.ToDouble(1), "N", "0", Convert.ToDouble(1));

                            }

                            int kotupdate = objbs.Newupdategettnameval(sTableName, lbltableid.InnerText);
                            ///  string yourUrl = "SalesPrint.aspx?Mode=Sales&Type=3&iSalesID=" + OrderBill + "&User=" + Session["User"].ToString() + "&Store=" + Session["Store"].ToString() + "&StoreNo=" + Session["StoreNo"].ToString() + "&Address=" + Session["Address"].ToString() + "&TIN=" + Session["TIN"].ToString();

                            //                            string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;



                            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                            /// ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);




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

        protected void Button3_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["dt"];
            //DataSet dCat = objbs.gettnameval( sTableName, lblOrdeNo.InnerText);
            //if (dCat.Tables[0].Rows.Count > 0)
            //{

            //    lblOrdeNo.InnerText = dCat.Tables[0].Rows[0]["Billno"].ToString();
            //    lblbilltype.InnerText = dCat.Tables[0].Rows[0]["Billtype"].ToString();
            //    Button2.Enabled = false;
            //    btnnew.Enabled = false;
            //    for (int i = 0; i < dCat.Tables[0].Rows.Count; i++)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["CategoryID"] = dCat.Tables[0].Rows[i]["categoryid"].ToString();
            //        dr["CategoryUserID"] = dCat.Tables[0].Rows[i]["itemid"].ToString();
            //        dr["definition"] = dCat.Tables[0].Rows[i]["definition"].ToString();                  
            //        dr["Qty"] = dCat.Tables[0].Rows[i]["Quantity"].ToString();
            //        dr["Rate"] = dCat.Tables[0].Rows[i]["unitprice"].ToString();
            //        dr["Amount"] = dCat.Tables[0].Rows[i]["Amount"].ToString();

            //        dt.Rows.Add(dr);
            //    }

            //    ViewState["dt"] = dt;



            //    gvlist.DataSource = dt;
            //    gvlist.DataBind();


            //}
            if (dt.Rows.Count > 0)
            {
                Total();
                SAveBill();
            }
        }

        protected void CompleteBill(object sender, EventArgs e)
        {
            CompleteBill();
        }

        protected void change(object sender, EventArgs e)
        {
            txtcashAmount.Enabled = true;
            if (ddpaymode.SelectedValue == "4")
            {
                Cash.Visible = true;
                Card.Visible = true;
                txtcashAmount.Enabled = false;
            }
            else if (ddpaymode.SelectedValue == "12")
            {
                Cash.Visible = true;
                Card.Visible = true;
            }
            else
            {
                Cash.Visible = false;
                Card.Visible = false;

            }
            mp1.Show();

        }

        protected void Balance(object sender, EventArgs e)
        {
            lblBalance.Text = Convert.ToDecimal(decimal.Parse(lblGrandTotal1g.Text) - decimal.Parse(txtPaid.Text)).ToString("f2");

            mp1.Show();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("RestaurantSalesKot.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }


        protected void drppayment1_selectedindex(object sender, EventArgs e)
        {
            //drpcomp.SelectedValue = "2";
            //DiscountVal = drpcomp.SelectedValue.ToString();
            //Session["Discount"] = DiscountVal;
            //Password.Text = string.Empty;
            //ModalPopupExtender1.Show();
            Calc_GrandTotal();
        }



        protected void Calc_GrandTotal()
        {
            //decimal total = 0;
            //DataSet ddisc = new DataSet();
            //ddisc = objbs.getiCatvaluesdiscount(drpcomp.SelectedValue);
            //if (ddisc.Tables[0].Rows.Count > 0)
            //{

            //    txtdiscou.Text = Convert.ToDecimal(ddisc.Tables[0].Rows[0]["Discount"]).ToString("f0");
            //    if (txtdiscou.Text != "")
            //    {
            //        TotalNew();
            //        //decimal dDiscount = Convert.ToDecimal(txtdiscou.Text);
            //        //decimal dSubTotal = Convert.ToDecimal(lblsubtotal.Text);

            //        //decimal dDisc = ((dDiscount * dSubTotal) / 100);
            //        //decimal dDiscAmt = Convert.ToDecimal(lblsubtotal.Text) - ((dDiscount * dSubTotal) / 100);
            //        //lblGrandtotal.Text = Convert.ToDecimal(dDiscAmt + Convert.ToDecimal(shwcgst.Text)).ToString("f2");
            //        //lbldisco.Text = dDisc.ToString("f2");
            //    }
            //}
        }


        protected void GridView1all_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = GridView1all.Rows[index];
            dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];
            string kotno = GridView1all.Rows[index].Cells[0].Text;
            Label categoryuser = (Label)GridView1all.Rows[index].FindControl("lblcategoryuserid");
            CheckBox checkboxx = (CheckBox)GridView1all.Rows[index].FindControl("chkcancell");
            if (e.CommandName == "minus")
            {
                foreach (DataRow dr in dtt.Rows)
                {
                    if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text && dr["Kotno"].ToString().Trim() == kotno)
                    {
                        int qty = Convert.ToInt32(dr["Qty"].ToString());


                        decimal rate = Convert.ToDecimal(dr["Rate"].ToString());
                        decimal amt = 0;
                        int final = qty - 1;
                        bool negative = final < 0;
                        if (negative == true)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Qty Exceed.Not Allow To Minus Value');", true);
                            break;
                        }

                        dr["Qty"] = final.ToString();

                        amt = final * rate;
                        dr["Amount"] = amt.ToString("f2");
                        if (dr["Qty"].ToString() == "0")
                        {
                            // dtt.Rows.Remove(dr);
                            checkboxx.Checked = true;
                            dr["check"] = checkboxx.Checked;
                            // dr["check"] = true;
                        }


                        ViewState["dt"] = dt;

                        ViewState["Newdt"] = dtt;

                        break;
                    }
                }


                // Total();

            }
            //else
            //{



            //    foreach (DataRow dr in dtt.Rows)
            //    {
            //        if (dr["Categoryuserid"].ToString().Trim() == categoryuser.Text && dr["Kotno"].ToString().Trim() == kotno)
            //        {
            //           // dtt.Rows.Remove(dr);
            //            checkboxx.Checked = true;
            //            dr["check"] = checkboxx.Checked;
            //            ViewState["dt"] = dtt;
            //            break;
            //        }
            //    }
            //}
            // Totall();


            GridView1all.DataSource = dtt;
            GridView1all.DataBind();

        }


        protected void GridView1all_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //double tot = 0;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    tot = tot + Convert.ToDouble(e.Row.Cells[3].Text);
            //    lblsubtotal.Text = tot.ToString("0.00");
            //}
        }

        protected void btnsplit_click(object sender, EventArgs e)
        {
            if (!splitdt.Columns.Contains("CategoryID"))
            {
                splitdt.Columns.Add("CategoryID");
                splitdt.Columns.Add("CategoryUserID");
                splitdt.Columns.Add("Definition");
                splitdt.Columns.Add("Qty");
                splitdt.Columns.Add("BillQty");
                splitdt.Columns.Add("gst");
                splitdt.Columns.Add("Rate");
                splitdt.Columns.Add("Amount");
                splitdt.Columns.Add("KotNo");
                splitdt.Columns.Add("KotID");
                splitdt.Columns.Add("Print");
            }

            DataTable dtchck = (DataTable)ViewState["Newdt"];
            bool ischeck = false;

            if (dtchck.Rows.Count > 0)
            {

                for (int i = 0; i < dtchck.Rows.Count; i++)
                {
                    ischeck = false;

                    foreach (GridViewRow gvrow in GridView1all.Rows)
                    {
                        Label categoryuser = (Label)gvrow.FindControl("lblkotid");
                        var checkbox = gvrow.FindControl("BillQtyCheck") as CheckBox;

                        if (dtchck.Rows[i]["Kotid"].ToString().Trim() == categoryuser.Text && checkbox.Checked)
                        {
                            ischeck = true;
                        }
                    }

                    if (ischeck == true)
                    {
                        splitdt.ImportRow(dtchck.Rows[i]);
                    }
                }

                ViewState["Newdt"] = splitdt;
            }

            splitCompleteBill();
        }

        void splitCompleteBill()
        {
            //dt = (DataTable)ViewState["CNwdt"];

            //if (dt.Rows.Count > 0)
            //{
            //    for (int k = 0; k < dt.Rows.Count; k++)
            //    {
            //        string BillQty = dt.Rows[k]["BillQty"].ToString();
            //        if (BillQty == "0")
            //        {
            //            dt.Rows.RemoveAt(k);
            //        }

            //    }

            //}


            //if (dt.Rows.Count > 0)
            //{
            //    if (chkcard.Checked == true)
            //    {
            //        ddpaymode.SelectedValue = "4";
            //        txtPaid.Text = lblGrandtotal.Text;
            //        txtcardAmount.Text = lblGrandtotal.Text;
            //    }
            //    else
            //    {
            //        ddpaymode.SelectedValue = "14";
            //        txtPaid.Text = lblGrandtotal.Text;
            //    }


            //    if (ddpaymode.SelectedValue == "14")
            //    {
            //        if (lblGrandtotal.Text == txtPaid.Text)
            //        {

            //        }
            //        else
            //        {
            //            if (txtPaid.Text == "0")
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Please Enter Amount Received');", true);
            //                return;
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Enter Correct Amount');", true);
            //                return;
            //            }
            //        }
            //    }

            //    if (ddpaymode.SelectedValue == "4")
            //    {
            //        if (lblGrandtotal.Text == txtcardAmount.Text && lblGrandtotal.Text == txtPaid.Text)
            //        {

            //        }
            //        else
            //        {
            //            if (txtPaid.Text == "0")
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Please Enter Amount Received');", true);
            //                return;
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Enter Correct Amount');", true);
            //                return;
            //            }
            //        }
            //    }

            //    if (ddpaymode.SelectedValue == "12")
            //    {
            //        double TotAmt = Convert.ToDouble(txtcardAmount.Text) + Convert.ToDouble(txtcashAmount.Text);
            //        string amt = TotAmt.ToString();
            //        if (lblGrandtotal.Text == amt)
            //        {

            //        }
            //        else
            //        {
            //            if (txtPaid.Text == "0")
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Please Enter Amount Received');", true);
            //                return;
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "alert('Enter Correct Amount');", true);
            //                return;
            //            }
            //        }
            //    }
            //    //return;
            //    // lblbilltype.InnerText = btn.Text;

            //    if (lblbilltype.InnerText == "Home Delivery")
            //    {
            //        cust.Visible = true;
            //        Address.Visible = true;
            //        billtypeid.Text = "3";
            //    }
            //    else if (lblbilltype.InnerText == "Take Away")
            //    {
            //        cust.Visible = false;
            //        Address.Visible = false;
            //        billtypeid.Text = "1";
            //    }
            //    else
            //    {
            //        cust.Visible = false;
            //        Address.Visible = false;
            //        billtypeid.Text = "2";

            //    }

            //    string iCustid = "";
            //    if (txtmobile.Text != "")
            //    {
            //        int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), txtCustomerName.Text, txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1));


            //    }

            //    else
            //    {
            //        txtmobile.Text = "0000000000";

            //        DataSet dCustid2 = objbs.GerCustID(txtmobile.Text);
            //        if (dCustid2.Tables[0].Rows.Count > 0)
            //        {
            //            iCustid = dCustid2.Tables[0].Rows[0]["CustomerID"].ToString();
            //        }
            //        else
            //        {

            //            int iSuc = objbs.InsertCustBill(Convert.ToInt32(0), "ABC", txtmobile.Text, "0", txtaddress.Text, "", "", Convert.ToInt32(1));
            //        }


            //    }
            //    DataSet dCustid = objbs.GerCustID(txtmobile.Text);
            //    if (dCustid.Tables[0].Rows[0]["CustomerID"].ToString() != "")
            //    {
            //        iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
            //    }
            //    if (txtPaid.Text == "")
            //    {
            //        txtPaid.Text = "0.00";
            //    }
            //    if (lblBalance.Text == "")
            //    {
            //        lblBalance.Text = "0.00";
            //    }


            //    int CreditorID1 = 0;
            //    // DataSet dsledger = objbs.getCashledgerId123("Cash A/C _" + sTableName);
            //    //  CreditorID1 = Convert.ToInt32(dsledger.Tables[0].Rows[0]["LedgerID"].ToString());

            //    int AccID = 0;
            //    int AccIDCash = 0;
            //    int AccIDCard = 0;

            //    //if (drpPayment.SelectedValue == "1")
            //    //{
            //    //    DataSet dsledger1 = objbs.getCashledgerId123("Cash A/C _" + sTableName);
            //    //    AccID = Convert.ToInt32(dsledger1.Tables[0].Rows[0]["LedgerID"].ToString());
            //    //}
            //    //else if (drpPayment.SelectedValue == "4")
            //    //{
            //    //    DataSet dsledger1 = objbs.getCashledgerId123("CardA/C_" + sTableName);
            //    //    AccID = Convert.ToInt32(dsledger1.Tables[0].Rows[0]["LedgerID"].ToString());
            //    //}
            //    lblserviceamt.InnerText = "0";

            //    string KOTNO = "";

            //    List<string> li = new List<string>();
            //    li.Clear();

            //    for (int k = 0; k < dt.Rows.Count; k++)
            //    {

            //        if (!li.Contains(dt.Rows[k]["KOTNO"].ToString()))
            //        {
            //            li.Add(dt.Rows[k]["KOTNO"].ToString());
            //        }


            //    }

            //    if (li.Count > 0)
            //    {
            //        for (int l = 0; l < li.Count; l++)
            //        {
            //            if (l == 0)
            //            {
            //                KOTNO = li[l].ToString();
            //            }
            //            else
            //            {
            //                KOTNO = KOTNO + " , " + li[l].ToString();
            //            }
            //        }
            //    }

            //    int OrderBill = 0;//objbs.CompleteBill1(AccID, CreditorID1, "tblDayBook_" + sTableName, "tblsales_" + sTableName, Convert.ToInt32(0), "", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), Convert.ToInt32(iCustid), Convert.ToDouble(lblTotal.Text), Convert.ToDouble(lblGrandtotal.Text), Convert.ToDouble(0), Convert.ToDouble(lbldisco.Text), Convert.ToInt32("0"), Convert.ToInt32(1), Convert.ToDouble(0), Convert.ToInt32(0), "", "", "", "", "", Convert.ToInt16(ddpaymode.SelectedValue), Convert.ToDecimal(txtPaid.Text), Convert.ToDecimal(lblBalance.Text), ddcardtype.SelectedValue, Convert.ToDecimal(txtservicetax.Text), Convert.ToDecimal(lblserviceamt.InnerText), Convert.ToDecimal(lblRoundoff.Text), billtypeid.Text, "", txtcashAmount.Text, txtcardAmount.Text, lbltableid.InnerText, txt_ServiceTaxamount.Text, txt_VATAmount.Text, Label1.Text, chkradbuttonn.SelectedValue, TextBox1.Text, TextBox2.Text, drpcomp.SelectedValue, drpcomp.SelectedItem.Text, KOTNO);


            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {

            //        string date = "";
            //        string extra = "";

            //        string catid = dt.Rows[i]["CategoryID"].ToString();
            //        string itemID = dt.Rows[i]["CategoryUserID"].ToString();
            //        string Qty = dt.Rows[i]["Qty"].ToString();
            //        string BillQty = dt.Rows[i]["BillQty"].ToString();
            //        string KOTID = dt.Rows[i]["KOTID"].ToString();
            //        string Rate = dt.Rows[i]["Rate"].ToString();
            //        string Amount = dt.Rows[i]["Amount"].ToString();

            //        if (BillQty != "0")
            //        {
            //            double CQty = 0;

            //            CQty = Convert.ToDouble(Qty) - Convert.ToDouble(BillQty);

            //            int splitkotupdate = 0;//objbs.UpdateSplitBillQty(sTableName, CQty.ToString(), KOTID);

            //            int iStatus1 = 0;//objbs.insertTransSales(" tblTranssales_" + sTableName, Convert.ToInt32(OrderBill), Convert.ToInt32(catid), Convert.ToDouble(BillQty), Convert.ToDouble(Rate), Convert.ToDouble(0), Convert.ToDouble(Amount), Convert.ToInt32(itemID), Convert.ToInt32(itemID), extra, Convert.ToDouble(0), "", DateTime.Now.ToString("yyyy-MM-dd"));
            //        }
            //    }


            //    bool Iscomplete = false;
            //    Iscomplete = objbs.CheckSplitHoldedKOT(lbltableid.InnerText, sTableName, "");

            //    if (Iscomplete == true)
            //    {
            //        int kotupdate = objbs.Newupdategettnameval(sTableName, lbltableid.InnerText);
            //    }

            //    //string yourUrl = "SalesPrint.aspx?Mode=Sales&iSalesID=" + OrderBill;

            //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
            //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);

            //    //Refersh();

            //    Response.Redirect("RestaurantsalesKot.aspx");

            //}
        }

        public void chkLinked_CheckedChanged(Object sender, EventArgs args)
        {
            CheckBox linkedItem = sender as CheckBox;
            Boolean itemState = linkedItem.Checked;

            bool ischck = false;

            DataTable dtchck = (DataTable)ViewState["chckdt"];

            if (!splitdt.Columns.Contains("CategoryID"))
            {
                splitdt.Columns.Add("CategoryID");
                splitdt.Columns.Add("CategoryUserID");
                splitdt.Columns.Add("Definition");
                splitdt.Columns.Add("Qty");
                splitdt.Columns.Add("BillQty");
                splitdt.Columns.Add("gst");
                splitdt.Columns.Add("Rate");
                splitdt.Columns.Add("Amount");
                splitdt.Columns.Add("KotNo");
                splitdt.Columns.Add("KotID");
                splitdt.Columns.Add("Print");
            }

            bool ischeck = false;

            if (dtchck.Rows.Count > 0)
            {
                for (int i = 0; i < dtchck.Rows.Count; i++)
                {
                    ischeck = false;

                    foreach (GridViewRow gvrow in GridView1all.Rows)
                    {
                        Label categoryuser = (Label)gvrow.FindControl("lblkotid");
                        var checkbox = gvrow.FindControl("BillQtyCheck") as CheckBox;

                        if (dtchck.Rows[i]["Kotid"].ToString().Trim() == categoryuser.Text && checkbox.Checked)
                        {
                            ischeck = true;
                        }
                    }

                    if (ischeck == true)
                    {
                        splitdt.ImportRow(dtchck.Rows[i]);
                    }
                }

                if (splitdt.Rows.Count > 0)
                {
                    ViewState["CNwdt"] = splitdt;
                }

                if (GridView1all.Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in GridView1all.Rows)
                    {
                        var checkbox = gvrow.FindControl("BillQtyCheck") as CheckBox;
                        if (checkbox.Checked == true)
                        {
                            ischck = true;
                        }
                    }
                }

                if (ischck == true)
                {
                    TotalAfterCheckBoxChecked();
                }
                else
                {
                    TotalNew();
                }
            }


        }


        void TotalAfterCheckBoxChecked()
        {
            decimal total = 0;
            decimal disco = 0;
            decimal gst = 0;
            decimal cgst = 0;
            decimal sgst = 0;
            decimal total1 = 0;
            decimal tcgst = 0;
            decimal tsgst = 0;
            decimal total123 = 0;

            decimal grandtotal = 0;
            decimal cgstot = 0;
            decimal sgstot = 0;

            decimal disTotal = 0;
            decimal distot = 0;
            decimal Tot = 0;
            decimal dis = 0;

            dtt = (DataTable)ViewState["CNwdt"];

            foreach (DataRow dr in dtt.Rows)
            {
                decimal Discamt = 0;
                gst = Convert.ToDecimal(dr["gst"]) / 2;
                total += Convert.ToDecimal(dr["Amount"]);
                decimal tooo = Convert.ToDecimal(dr["Amount"]);
                decimal tooo1 = Convert.ToDecimal(dr["Amount"]);

                disTotal += Convert.ToDecimal(dr["Amount"]);
                decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                Tot = Convert.ToDecimal(ttoo);
                //dis = Convert.ToDecimal(txtdiscou.Text) / 100;
                Discamt = Tot * dis;


                lbldisco1.Text = Convert.ToDecimal(Discamt).ToString("f2");
                distot += Convert.ToDecimal(Discamt);

                tooo = tooo1 - Discamt;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gst)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;

                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;

            }


            ////lblTotal.Text = total.ToString();
            //lblsubtotal.Text = total.ToString();
            ////Label1.Text = total.ToString();
            //lblGrandtotal.Text = grandtotal.ToString("0.00");
            //lbldisco.Text = distot.ToString("0.00");
            //lblDisTotal.Text = distot.ToString();


            ////txt_ServiceTaxamount.Text = (cgstot + sgstot).ToString("0.00");
            ////shwcgst.Text = txt_ServiceTaxamount.Text;

        }

        protected void KotBIll(object sender, EventArgs e)
        {
            dsLogin = objBs.Login(username.Text, Password.Text);

            if (dsLogin.Tables[0].Rows.Count > 0 && username.Text.ToLower() == "admin")
            {
                //if (Session["Discount"] != null)
                //{
                //    drpcomp.SelectedValue = Session["Discount"].ToString();
                //}
                //else
                //{
                //    drpcomp.SelectedValue = "2";
                //}

                //txtdiscou.Enabled = true;

                //Calc_GrandTotal();
                ModalPopupExtender1.Hide();
            }
            else
            {
                //txtdiscou.Enabled = false;

                //drpcomp.SelectedValue = "2";
                //Calc_GrandTotal();
                ModalPopupExtender1.Hide();
            }


            Password.Text = string.Empty;
            //Label1.Text = "0.00";
            //lblTotal.Text = "0.00";
            //txt_ServiceTaxamount.Text = "0.00";

        }

        //public void chckdiscnt_CheckedChanged(Object sender, EventArgs args)
        //{
        //    if (chckdiscnt.Checked == true)
        //    {
        //        Response.Redirect(Request.RawUrl);
        //    }
        //    else
        //    {
        //        ModalPopupExtender1.Show();
        //    }
        //}

        protected void Calc_GrandTotal1()
        {
            TotalNew1();
        }

        void TotalNew1()
        {
            decimal total = 0;
            decimal disco = 0;
            decimal gst = 0;
            decimal cgst = 0;
            decimal sgst = 0;
            decimal total1 = 0;
            decimal tcgst = 0;
            decimal tsgst = 0;
            decimal total123 = 0;

            decimal grandtotal = 0;
            decimal cgstot = 0;
            decimal sgstot = 0;

            decimal disTotal = 0;
            decimal distot = 0;
            decimal Tot = 0;
            decimal dis = 0;

            // dt = (DataTable)ViewState["dt"];
            dtt = (DataTable)ViewState["Newdt"];

            foreach (DataRow dr in dtt.Rows)
            {
                decimal Discamt = 0;
                gst = Convert.ToDecimal(dr["gst"]) / 2;
                total += Convert.ToDecimal(dr["Amount"]);
                decimal tooo = Convert.ToDecimal(dr["Amount"]);
                decimal tooo1 = Convert.ToDecimal(dr["Amount"]);

                disTotal += Convert.ToDecimal(dr["Amount"]);
                decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                Tot = Convert.ToDecimal(ttoo);
                // dis = Convert.ToDecimal(txtdiscou.Text) / 100;
                Discamt = Tot * dis;


                lbldisco1g.Text = Convert.ToDecimal(Discamt).ToString("f2");
                distot += Convert.ToDecimal(Discamt);

                tooo = tooo1 - Discamt;

                decimal ngstamount1 = (Convert.ToDecimal(tooo) * Convert.ToDecimal(gst)) / 100;
                decimal dTotal1 = ngstamount1 + ngstamount1 + tooo;

                decimal gstamt1 = ngstamount1;
                decimal cgstamt1 = ngstamount1;
                cgstot = cgstot + cgstamt1;
                sgstot = sgstot + gstamt1;
                grandtotal = grandtotal + dTotal1;

            }


            ////lblTotal.Text = total.ToString();
            //lblsubtotal.Text = total.ToString();
            ////Label1.Text = total.ToString();
            //lblGrandtotal.Text = grandtotal.ToString("0.00");
            //lbldisco.Text = distot.ToString("0.00");
            //lblDisTotal.Text = distot.ToString();


            ////txt_ServiceTaxamount.Text = (cgstot + sgstot).ToString("0.00");
            ////shwcgst.Text = txt_ServiceTaxamount.Text;


        }


        public void txtdiscou_TextChanged(Object sender, EventArgs args)
        {
            Calc_GrandTotal1();
        }
    }
}