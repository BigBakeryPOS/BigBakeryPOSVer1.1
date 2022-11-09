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
using System.Net;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class OrderForm : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sBranchCode = "";
        string Rate = "";
        string iBillNo = "";
        DataTable dt = new DataTable();
        string BranchID = "";
        string sCodeProd = "";
        string sCodeIcing = "";
        string sCodeBnch = "";
        string synccakeorder = "";
        string fssaino = "Nil";
        string StockOption = "Nil";

        string taxsetting = "";
        string ratesetting = "";
        string qtysetting = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sBranchCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();
            synccakeorder = Request.Cookies["userInfo"]["OnlineCakeSync"].ToString();
            fssaino = Request.Cookies["userInfo"]["fssaino"].ToString();
            StockOption = Request.Cookies["userInfo"]["StockOption"].ToString();

            taxsetting = Request.Cookies["userInfo"]["TaxSetting"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();

            CalendarExtender1.SelectedDate = DateTime.Today;
            //CalendarExtender1.EndDate = DateTime.Today.AddMonths(1);
            //CalendarExtender2.StartDate = DateTime.Today;

            if (synccakeorder == "Y")
            {
                chkchecklist.Checked = true;
            }
            else
            {
                chkchecklist.Checked = false;
            }


            if (!IsPostBack)
            {


                DataSet dss = objbs.checkrequestallowornot(sTableName);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    sCodeIcing = dss.Tables[0].Rows[0]["IcingCode"].ToString();

                    sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }


                txtdiscotp.Attributes.Add("autocomplete", "off");
                iBillNo = Request.QueryString.Get("OrderNo");

                DataSet paymodeFinal = new DataSet();

                DataSet paymode = objbs.Paymodevalues(sTableName);

                Epaymode.Visible = false;

                DataSet dsCeremo = objbs.getCeremonies();
                if (dsCeremo.Tables[0].Rows.Count > 0)
                {
                    ddlfunctions.DataSource = dsCeremo.Tables[0];
                    ddlfunctions.DataTextField = "OnlineMaster";
                    ddlfunctions.DataValueField = "OnlineId";
                    ddlfunctions.DataBind();
                    ddlfunctions.Items.Insert(0, "Select Functions");
                    ddlfunctions.SelectedValue = "7";
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


                if (sCodeIcing == sCodeProd)
                {
                    DataSet dproducttypeload = objbs.GetProducttype();
                    if (dproducttypeload.Tables[0].Rows.Count > 0)
                    {
                        drpproductiontype.DataSource = dproducttypeload.Tables[0];
                        drpproductiontype.DataTextField = "productiontype";
                        drpproductiontype.DataValueField = "productiontype";
                        drpproductiontype.DataBind();
                        drpproductiontype.Items.Insert(0, "All");
                        drpproductiontype.Enabled = false;
                    }

                }
                else
                {
                    DataSet dproducttypeload = objbs.GetProducttype();
                    if (dproducttypeload.Tables[0].Rows.Count > 0)
                    {
                        drpproductiontype.DataSource = dproducttypeload.Tables[0];
                        drpproductiontype.DataTextField = "productiontype";
                        drpproductiontype.DataValueField = "productiontype";
                        drpproductiontype.DataBind();
                        drpproductiontype.Enabled = true;
                        // drpproductiontype.Items.Insert(0, "Select ProductionType");
                    }
                }

                //getting Book code
                DataSet dgetbookcode = objbs.getbookcode(sTableName);
                if (dgetbookcode.Tables[0].Rows.Count > 0)
                {
                    lblbookcode.Text = dgetbookcode.Tables[0].Rows[0]["Bookcode"].ToString();
                }
                else
                {
                    string text2 = "Please Update Book Code For This Branch.Thank You!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                }


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
                        drpPayment1.DataSource = paymodeFinal.Tables[0];
                        drpPayment1.DataTextField = "PayMode";
                        drpPayment1.DataValueField = "Value";
                        drpPayment1.DataBind();
                        //  drpPayment.Items.Insert(0, "Select");
                    }
                    else
                    {
                        drpPayment.DataSource = paymode.Tables[0];
                        drpPayment.DataTextField = "PayMode";
                        drpPayment.DataValueField = "Value";
                        drpPayment.DataBind();
                        drpPayment.SelectedValue = "1";

                        drpPayment1.DataSource = paymode.Tables[0];
                        drpPayment1.DataTextField = "PayMode";
                        drpPayment1.DataValueField = "Value";
                        drpPayment1.DataBind();
                        drpPayment1.SelectedValue = "1";

                    }
                }

                DataSet dsonlinemaster = objbs.gridonlinemaster_New();
                if (dsonlinemaster.Tables[0].Rows.Count > 0)
                {
                    drporderlist.DataSource = dsonlinemaster.Tables[0];
                    drporderlist.DataTextField = "OnlineMaster";
                    drporderlist.DataValueField = "OnlineNo";
                    drporderlist.DataBind();
                    drporderlist.Items.Insert(0, "Select Order Option");
                    drporderlist.SelectedValue = "2";
                }
                else
                {
                    drporderlist.DataSource = null;
                    drporderlist.DataBind();
                    drporderlist.Items.Insert(0, "Select Order Option");
                }

                DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
                if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
                {
                    lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
                }

                DataSet dsbranch = objbs.getbranch();
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drppickup.DataSource = dsbranch.Tables[0];
                    drppickup.DataTextField = "BranchArea";
                    drppickup.DataValueField = "BranchId";
                    drppickup.DataBind();
                    drppickup.Items.Insert(0, "Select Pickup Location");

                    drppickup.SelectedValue = BranchID;

                    //if (sTableName == "KK" || sTableName == "kk")
                    //{
                    //    drppickup.SelectedValue = "2";
                    //}
                    //else if (sTableName == "BY" || sTableName == "by")
                    //{
                    //    drppickup.SelectedValue = "4";
                    //}
                    //else if (sTableName == "BB" || sTableName == "bb")
                    //{
                    //    drppickup.SelectedValue = "3";
                    //}
                    //else if (sTableName == "NP" || sTableName == "np")
                    //{
                    //    drppickup.SelectedValue = "1";
                    //}
                    //else if (sTableName == "GORI" || sTableName == "gori")
                    //{
                    //    drppickup.SelectedValue = "7";
                    //}
                    //else if (sTableName == "TOWN" || sTableName == "town")
                    //{
                    //    drppickup.SelectedValue = "8";
                    //}
                    //else if (sTableName == "CHEMD" || sTableName == "chemd")
                    //{
                    //    drppickup.SelectedValue = "9";
                    //}
                    //else if (sTableName == "TBY" || sTableName == "tby")
                    //{
                    //    drppickup.SelectedValue = "10";
                    //}
                    //else if (sTableName == "TPOT" || sTableName == "tpot")
                    //{
                    //    drppickup.SelectedValue = "11";
                    //}
                    //else if (sTableName == "TPAL" || sTableName == "tpal")
                    //{
                    //    drppickup.SelectedValue = "12";
                    //}
                    //else if (sTableName == "TPJPOT" || sTableName == "tpjpot")
                    //{
                    //    drppickup.SelectedValue = "13";
                    //}
                    //else if (sTableName == "TPJKTUR" || sTableName == "tpjktur")
                    //{
                    //    drppickup.SelectedValue = "15";
                    //}
                    //else if (sTableName == "KVL" || sTableName == "kvl")
                    //{
                    //    drppickup.SelectedValue = "16";
                    //}
                    //else if (sTableName == "BNRI" || sTableName == "bnri")
                    //{
                    //    drppickup.SelectedValue = "19";
                    //}

                }
                else
                {
                    drppickup.DataSource = null;
                    drppickup.DataBind();
                    drppickup.Items.Insert(0, "Select Pickup Location");
                }



                if (lblUserID.Text == "10")
                {
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
                txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt"); ;

                DataSet dOrderNo = objbs.GetCakerOrderNo(sTableName);
                if (dOrderNo.Tables[0].Rows.Count > 0)
                {
                    if (dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                    {
                        //string sUser = lblUser.Text;
                        //string[] sUserDet = sUser.Split('@');
                        lblBranch.InnerText = sBranchCode;
                        lblOrderNo.InnerText = dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString();
                    }
                    else
                    {
                        //string sUser = lblUser.Text;
                        //string[] sUserDet = sUser.Split('@');
                        lblBranch.InnerText = sBranchCode;

                        lblOrderNo.InnerText = "1";
                    }
                }

                else
                {
                    //string sUser = lblUser.Text;
                    //string[] sUserDet = sUser.Split('@');
                    lblBranch.InnerText = sBranchCode;
                    lblOrderNo.InnerText = "1";
                }
                var DDLFLAVOUR = new[] { ddlFlavour1, ddlFlavour2, ddlFlavour3, ddlFlavour4, ddlFlavour5 };
                var ddCat = new[] { ddCategory1, ddCategory2, ddCategory3, ddCategory4, ddCategory5, ddCategory5 };
                var QTY = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5 };
                var RATE = new[] { txtrate1, txtrate2, txtrate3, txtrate4, txtrate5 };
                var AMt = new[] { txtamount1, txtamount2, txtamount3, txtamount4, txtamount5 };

                var TAX = new[] { lbltax1, lbltax2, lbltax3, lbltax4, lbltax5 };
                for (int i = 0; i <= 5; i++)
                {
                    DataSet dCategory = objbs.selectcategorymaster();
                    ddCat[i].DataSource = dCategory.Tables[0];
                    ddCat[i].DataTextField = "Category";
                    ddCat[i].DataValueField = "CategoryID";
                    ddCat[i].DataBind();
                    ddCat[i].Items.Insert(0, "Select Category");


                    //DataSet dCategory = objbs.selectcategorydecription(Convert.ToInt32(dBilling.Tables[0].Rows[i]["CategoryID"].ToString()));

                    //DDLFLAVOUR[i].DataTextField = "Definition";
                    //DDLFLAVOUR[i].DataValueField = "categoryuserid";
                    //DDLFLAVOUR[i].DataSource = dCategory.Tables[0];
                    //DDLFLAVOUR[i].DataBind();



                }
                if (btnSave.Text == "Save & Print")
                {
                    paymodeclick(sender, e);
                    FirstGridViewRow();
                    if (lblbooknocheck.Text == "Y")
                    {
                        string ABookno = Request.QueryString.Get("ABookno");
                        txtabookno.Text = ABookno;
                        txtbookNo.Enabled = true;
                    }
                    else
                    {
                        txtabookno.Text = lblOrderNo.InnerText;
                        txtbookNo.Text = lblOrderNo.InnerText;
                        txtbookNo.Enabled = false;
                    }
                }

                string OrderNo = Request.QueryString.Get("OrderNo");
                editbill.Visible = false;

                string billtype = Request.QueryString.Get("BillType");

                string OldOrderNo = Request.QueryString.Get("OldOrderNo");
                #region New
                if (OrderNo != null)
                {
                    #region



                    radiomode.Visible = false;
                    DataSet dBilling = objbs.PayBill(Convert.ToInt32(OrderNo), sTableName);
                    if (dBilling.Tables[0].Rows.Count > 0)
                    {

                        DataSet getpaiddetails = objbs.getpaidorderdetails(Convert.ToInt32(OrderNo), sTableName);
                        if (getpaiddetails.Tables[0].Rows.Count > 0)
                        {
                            Gridpaymentdetails.DataSource = getpaiddetails;
                            Gridpaymentdetails.DataBind();
                        }
                        else
                        {
                            Gridpaymentdetails.DataSource = null;
                            Gridpaymentdetails.DataBind();
                        }

                        if (billtype != null)
                        {
                            if (billtype == "Cbill")
                            {
                                btnSave.Text = "Pay Bill";
                                Epaymode.Visible = true;
                                Pamount.Visible = false;
                                Tpaid.Visible = true;
                                chkdelv.Visible = true;
                                drpproductiontype.Enabled = false;
                            }
                            else if (billtype == "Ebill")
                            {
                                btnSave.Text = "Update Bill";
                                Epaymode.Visible = true;
                                Pamount.Visible = false;
                                Tpaid.Visible = true;
                                chkdelv.Visible = false;
                                drpproductiontype.Enabled = true;
                            }
                            else if (billtype == "PAmount")
                            {
                                btnSave.Text = "Pay Amount";
                                Epaymode.Visible = true;
                                Pamount.Visible = true;
                                Tpaid.Visible = true;
                                chkdelv.Visible = false;
                                drpproductiontype.Enabled = false;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Try Again else Try Again Later.Thank You!!!.');", true);
                            return;
                        }

                        DataSet getpaid = objbs.getoverallpaidamount(sTableName, OrderNo);
                        if (getpaid.Tables[0].Rows.Count > 0)
                        {
                            double refund = 0;

                            DataSet getrefund = objbs.getoverallrefundamount(sTableName, OrderNo);
                            if (getrefund.Tables[0].Rows.Count > 0)
                            {
                                refund = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]);
                            }
                            totpaid.Text = (Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]) - refund).ToString("" + ratesetting + "");
                        }
                        else
                        {
                            totpaid.Text = "0";
                        }

                        txtsubtotal.Text = dBilling.Tables[0].Rows[0]["STotal"].ToString();
                        txtsgst.Text = dBilling.Tables[0].Rows[0]["SGST"].ToString();
                        txtcgst.Text = dBilling.Tables[0].Rows[0]["CGST"].ToString();
                        txtbookNo.Text = dBilling.Tables[0].Rows[0]["BookNo"].ToString();
                        lblbillno.Text = dBilling.Tables[0].Rows[0]["Billno"].ToString();
                        txtCustname.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtPhineNo.Text = dBilling.Tables[0].Rows[0]["MobileNo"].ToString();
                        txttotal.Text = dBilling.Tables[0].Rows[0]["Total"].ToString();
                        radiomode.SelectedValue = dBilling.Tables[0].Rows[0]["Paytype"].ToString();
                        radiomode.Visible = true;
                        radiomode.Enabled = false;

                        txtdiscper.Text = dBilling.Tables[0].Rows[0]["DiscountPer"].ToString();
                        txtdiscamount.Text = dBilling.Tables[0].Rows[0]["DiscountAmount"].ToString();
                        attednertype.SelectedValue = dBilling.Tables[0].Rows[0]["DiscEmp"].ToString();

                        if (txtdiscper.Text != "0.0000")
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
                                    drpdischk.SelectedItem.Text = txtdiscper.Text;

                                }
                            }
                            else
                            {
                                drpdischk.Items.Insert(0, "Select disc");
                            }
                        }

                        txtBalance.Text = dBilling.Tables[0].Rows[0]["balancepaid"].ToString();

                        string status = dBilling.Tables[0].Rows[0]["Status"].ToString();
                        lblstatus.Text = status;
                        if (status == "Y")
                        {
                            balpaid.Visible = true;
                            lblbalpaid.Text = Convert.ToDouble(dBilling.Tables[0].Rows[0]["balance"]).ToString("" + ratesetting + "");
                            //  txtAdvance.Text = (Convert.ToDouble(dBilling.Tables[0].Rows[0]["Advance"]) + Convert.ToDouble(dBilling.Tables[0].Rows[0]["balance"]) - Convert.ToDouble(dBilling.Tables[0].Rows[0]["refundamount"])).ToString("0.00"); 
                            txtAdvance.Text = Convert.ToDouble(totpaid.Text).ToString("" + ratesetting + "");
                        }
                        else
                        {
                            balpaid.Visible = false;
                            // txtAdvance.Text = (Convert.ToDouble(dBilling.Tables[0].Rows[0]["Advance"]) - Convert.ToDouble(dBilling.Tables[0].Rows[0]["refundamount"])).ToString("0.00"); 
                            txtAdvance.Text = Convert.ToDouble(totpaid.Text).ToString("" + ratesetting + "");
                        }


                        ddlfunctions.SelectedValue = dBilling.Tables[0].Rows[0]["Ceremonies"].ToString();
                        ddlfunctions.Enabled = false;

                        drporderlist.SelectedValue = dBilling.Tables[0].Rows[0]["OrderType"].ToString();
                        drporderlist.Enabled = false;

                        drppickup.SelectedValue = dBilling.Tables[0].Rows[0]["PickUpLocation"].ToString();
                        drppickup.Enabled = false;

                        int iCount = dBilling.Tables[0].Rows.Count;
                        txtMessege.Text = dBilling.Tables[0].Rows[0]["Messege"].ToString();
                        //txtNotes.Text = dBilling.Tables[0].Rows[0]["Notes"].ToString();
                        //  txtOrderDate.Text = dBilling.Tables[0].Rows[0]["Billdate"].ToString();
                        //   txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                        //  txtDeliveryDate.Text = dBilling.Tables[0].Rows[0]["deliverydate"].ToString();

                        txtOrderDate.Text = Convert.ToDateTime(dBilling.Tables[0].Rows[0]["OrderDate"]).ToString("yyyy-MM-dd hh:mm tt");
                        txtDeliveryDate.Text = Convert.ToDateTime(dBilling.Tables[0].Rows[0]["deliverydate"]).ToString("dd/MM/yyyy");

                        txtOrdetBy.Text = dBilling.Tables[0].Rows[0]["ordertakenby"].ToString();
                        drpPayment.SelectedValue = dBilling.Tables[0].Rows[0]["ipaymode"].ToString();
                        txtPlace.Text = dBilling.Tables[0].Rows[0]["place"].ToString();
                        txtdeliverycharge.Text = dBilling.Tables[0].Rows[0]["DeliveryCharge"].ToString();
                        // ddlHours.SelectedValue=

                        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        DataRow drCurrentRow = null;


                        //for (int i = 0; i < iCount; i++)
                        {
                            //DataSet dCat = objbs.selectcategorymaster();

                            //ddCat[i].DataTextField = "Category";
                            //ddCat[i].DataValueField = "CategoryID";
                            //ddCat[i].DataSource = dCat.Tables[0];
                            //ddCat[i].DataBind();


                            //DataSet dCategory = objbs.selectcategorydecription(Convert.ToInt32(dBilling.Tables[0].Rows[i]["CategoryID"].ToString()), sTableName);

                            //DDLFLAVOUR[i].DataTextField = "Definition";
                            //DDLFLAVOUR[i].DataValueField = "categoryuserid";
                            //DDLFLAVOUR[i].DataSource = dCategory.Tables[0];
                            //DDLFLAVOUR[i].DataBind();



                            //QTY[i].Text = dBilling.Tables[0].Rows[i]["Qty"].ToString();

                            //decimal Irate = Convert.ToDecimal(dBilling.Tables[0].Rows[i]["Rate"].ToString());
                            //RATE[i].Text = Decimal.Round(Irate, 2).ToString(""+ratesetting+"");
                            //Decimal ical1 = Convert.ToDecimal(QTY[i].Text) * Irate;
                            //AMt[i].Text = Decimal.Round(ical1, 2).ToString(""+ratesetting+"");

                            //TAX[i].Text = Convert.ToDecimal(dBilling.Tables[0].Rows[i]["gst"]).ToString("0.00");

                            //ddCat[i].SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString().Trim();


                            //DDLFLAVOUR[i].SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString().Trim();



                            //int rowIndex = 0;

                            DataTable dttt;
                            DataRow drNew;
                            DataColumn dct;
                            DataSet dstd = new DataSet();
                            dttt = new DataTable();

                            dct = new DataColumn("Category");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Item");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Qty");
                            dttt.Columns.Add(dct);


                            dct = new DataColumn("Rate");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Amount");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Tax");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Disc");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Unit");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Unitid");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Modelid");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Modelimg");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Modelimgpath");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("notes");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("packtype");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Noofpack");
                            dttt.Columns.Add(dct);


                            dstd.Tables.Add(dttt);

                            foreach (DataRow dr in dBilling.Tables[0].Rows)
                            {

                                drNew = dttt.NewRow();
                                drNew["Category"] = dr["CategoryID"];
                                drNew["Item"] = dr["SubCategoryID"];
                                drNew["Qty"] = dr["Qty"];
                                drNew["Rate"] = dr["Rate"];
                                drNew["Amount"] = dr["Amount"];
                                drNew["Tax"] = dr["gst"];
                                drNew["Disc"] = dr["disc"];

                                drNew["Modelid"] = dr["modelno"];
                                drNew["Modelimg"] = dr["Modelimgpath"];
                                drNew["Modelimgpath"] = dr["Modelimgpath"];

                                drNew["notes"] = dr["Packingnotes"];

                                drNew["packtype"] = dr["packingtype"];
                                drNew["Noofpack"] = dr["noofpack"];


                                dstd.Tables[0].Rows.Add(drNew);
                            }

                            ViewState["CurrentTable"] = dttt;

                            gridorder.DataSource = dstd;
                            gridorder.DataBind();

                            for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                            {
                                DropDownList drpcategory = (DropDownList)gridorder.Rows[vLoop].FindControl("drpcategory");
                                DropDownList drpitem = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");
                                TextBox txtQty = (TextBox)gridorder.Rows[vLoop].FindControl("txtQty");
                                TextBox txtRate = (TextBox)gridorder.Rows[vLoop].FindControl("txtRate");
                                Label lbltax = (Label)gridorder.Rows[vLoop].FindControl("lbltax");
                                Label lblitemdiscount = (Label)gridorder.Rows[vLoop].FindControl("lblitemdiscount");
                                TextBox txtAmount = (TextBox)gridorder.Rows[vLoop].FindControl("txtAmount");
                                DropDownList ddUnits = (DropDownList)gridorder.Rows[vLoop].FindControl("ddUnits");

                                DropDownList drpmodelno = (DropDownList)gridorder.Rows[vLoop].FindControl("drpmodelno");
                                Image lblimg = (Image)gridorder.Rows[vLoop].FindControl("lblimg");
                                Label lblimgpath = (Label)gridorder.Rows[vLoop].FindControl("lblimgpath");

                                TextBox txtpackingnotes = (TextBox)gridorder.Rows[vLoop].FindControl("txtpackingnotes");

                                DropDownList drppackingtype = (DropDownList)gridorder.Rows[vLoop].FindControl("drppackingtype");
                                TextBox txtnoofpack = (TextBox)gridorder.Rows[vLoop].FindControl("txtnoofpack");


                                drpcategory.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Category"]).ToString();
                                drpitem.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["item"]).ToString();

                                txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString("N");
                                txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString("N");


                                lbltax.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["tax"]).ToString("N");
                                lblitemdiscount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["disc"]).ToString("N");
                                txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString("N");

                                drpmodelno.SelectedValue = dstd.Tables[0].Rows[vLoop]["Modelid"].ToString();
                                lblimg.ImageUrl = dstd.Tables[0].Rows[vLoop]["Modelimg"].ToString();
                                lblimgpath.Text = dstd.Tables[0].Rows[vLoop]["Modelimgpath"].ToString();
                                txtpackingnotes.Text = dstd.Tables[0].Rows[vLoop]["notes"].ToString();

                                drppackingtype.SelectedValue = dstd.Tables[0].Rows[vLoop]["packtype"].ToString();
                                txtnoofpack.Text = dstd.Tables[0].Rows[vLoop]["noofpack"].ToString();


                            }


                        }

                        if (txtBalance.Text == "0.0000")
                        {
                            editbill.Visible = true;
                            lbleditbill.InnerText = "Warning !!!! This Order Made Full Payment.";
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('sorry " + lblUser.Text + " Amount Paid Already .');", true);
                            //btnSave.Enabled = false;
                        }
                        else
                        {
                            editbill.Visible = true;
                            lbleditbill.InnerText = "Warning !!!! This Order Made Partial Payment.";
                        }

                        if (btnSave.Text == "Update Bill")
                        {
                            // get status of order form
                            DataSet getstatus = objbs.getCakeSummary(OrderNo, sTableName);
                            if (getstatus.Tables[0].Rows.Count > 0)
                            {
                                string deliveryid = getstatus.Tables[0].Rows[0]["deliveryid"].ToString();
                                string Deliverstatus = getstatus.Tables[0].Rows[0]["Deliverstatus"].ToString();

                                if (deliveryid == "4" || deliveryid == "5")
                                {
                                    string text2 = "This Order Status is " + Deliverstatus + ".So Not Allow to Edit.Thank You!!!.";

                                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('');", true);
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "info", "<script>showpop2('" + text2 + "')</script>", false);
                                    //return;
                                }

                            }
                        }

                    }

                    #endregion
                }
                #endregion
                #region Old
                //if (OldOrderNo != null)
                //{
                //    DataSet dBilling = objbs.CustomerOrderBilling(Convert.ToInt32(OldOrderNo), sTableName);
                //    if (dBilling.Tables[0].Rows.Count > 0)
                //    {






                //        txtCustname.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                //        txtPhineNo.Text = dBilling.Tables[0].Rows[0]["MobileNo"].ToString();
                //        txttotal.Text = dBilling.Tables[0].Rows[0]["NetAmount"].ToString();
                //        txtAdvance.Text = dBilling.Tables[0].Rows[0]["Advance"].ToString();
                //        txtBalance.Text = dBilling.Tables[0].Rows[0]["Total"].ToString();
                //        int iCount = dBilling.Tables[0].Rows.Count;
                //        txtMessege.Text = dBilling.Tables[0].Rows[0]["Messege"].ToString();
                //        //txtNotes.Text = dBilling.Tables[0].Rows[0]["Notes"].ToString();
                //        //  txtOrderDate.Text = dBilling.Tables[0].Rows[0]["Billdate"].ToString();
                //        txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                //        txtDeliveryDate.Text = dBilling.Tables[0].Rows[0]["deliverydate"].ToString();
                //        txtOrdetBy.Text = dBilling.Tables[0].Rows[0]["ordertakenby"].ToString();
                //        drpPayment.SelectedValue = dBilling.Tables[0].Rows[0]["ipaymode"].ToString();
                //        txtPlace.Text = dBilling.Tables[0].Rows[0]["place"].ToString();
                //        // ddlHours.SelectedValue=
                //        txtsubtotal.Text = dBilling.Tables[0].Rows[0]["STotal"].ToString();
                //        txtsgst.Text = dBilling.Tables[0].Rows[0]["SGST"].ToString();
                //        txtcgst.Text = dBilling.Tables[0].Rows[0]["CGST"].ToString();
                //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                //        DataRow drCurrentRow = null;


                //        for (int i = 0; i < iCount; i++)
                //        {
                //            DataSet dCat = objbs.selectcategorymaster();

                //            ddCat[i].DataTextField = "Category";
                //            ddCat[i].DataValueField = "CategoryID";
                //            ddCat[i].DataSource = dCat.Tables[0];
                //            ddCat[i].DataBind();


                //            DataSet dCategory = objbs.selectcategorydecription(Convert.ToInt32(dBilling.Tables[0].Rows[i]["CategoryID"].ToString()), sTableName);

                //            DDLFLAVOUR[i].DataTextField = "Definition";
                //            DDLFLAVOUR[i].DataValueField = "categoryuserid";
                //            DDLFLAVOUR[i].DataSource = dCategory.Tables[0];
                //            DDLFLAVOUR[i].DataBind();


                //            //DataSet dFlavour = objbs.selectcategorydecription(Convert.ToInt32(ddCat[i].SelectedValue));
                //            //DDLFLAVOUR[i].DataSource = dFlavour.Tables[0];
                //            //DDLFLAVOUR[i].DataTextField = "Definition";
                //            //DDLFLAVOUR[i].DataValueField = "CategoryUserID";
                //            //DDLFLAVOUR[i].DataBind();
                //            //DDLFLAVOUR[i].Items.Insert(0, "Select Flavour");


                //            QTY[i].Text = dBilling.Tables[0].Rows[i]["Quantity"].ToString();

                //            decimal Irate = Convert.ToDecimal(dBilling.Tables[0].Rows[i]["UnitPrice"].ToString());
                //            RATE[i].Text = Decimal.Round(Irate, 2).ToString(""+ratesetting+"");
                //            Decimal ical1 = Convert.ToDecimal(QTY[i].Text) * Irate;
                //            AMt[i].Text = Decimal.Round(ical1, 2).ToString(""+ratesetting+"");



                //            ddCat[i].SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString().Trim();


                //            DDLFLAVOUR[i].SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString().Trim();



                //            int rowIndex = 0;


                //        }



                //    }
                //}
                #endregion
                #region

                //string OrderNoEdit = Request.QueryString.Get("OrderNoEdit");

                //if (OrderNoEdit != null)
                //{
                //    #region

                //    // radiomode.Visible = false;
                //    DataSet dBilling = objbs.PayBill(Convert.ToInt32(OrderNoEdit), sTableName);
                //    if (dBilling.Tables[0].Rows.Count > 0)
                //    {

                //        lblOrderNo.InnerText = dBilling.Tables[0].Rows[0]["OrderNo"].ToString();

                //        txtsubtotal.Text = dBilling.Tables[0].Rows[0]["STotal"].ToString();
                //        txtsgst.Text = dBilling.Tables[0].Rows[0]["SGST"].ToString();
                //        txtcgst.Text = dBilling.Tables[0].Rows[0]["CGST"].ToString();
                //        txtbookNo.Text = dBilling.Tables[0].Rows[0]["BookNo"].ToString();
                //        txtCustname.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                //        txtPhineNo.Text = dBilling.Tables[0].Rows[0]["MobileNo"].ToString();
                //        txttotal.Text = dBilling.Tables[0].Rows[0]["NetAmount"].ToString();
                //        txtAdvance.Text = dBilling.Tables[0].Rows[0]["Advance"].ToString();
                //        txtBalance.Text = dBilling.Tables[0].Rows[0]["Total"].ToString();

                //        int iCount = dBilling.Tables[0].Rows.Count;
                //        txtMessege.Text = dBilling.Tables[0].Rows[0]["Messege"].ToString();
                //        //txtNotes.Text = dBilling.Tables[0].Rows[0]["Notes"].ToString();
                //        //  txtOrderDate.Text = dBilling.Tables[0].Rows[0]["Billdate"].ToString();

                //        //  txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                //        txtOrderDate.Text = Convert.ToDateTime(dBilling.Tables[0].Rows[0]["OrderDate"]).ToString("yyyy-MM-dd hh:mm tt");
                //        txtDeliveryDate.Text = Convert.ToDateTime(dBilling.Tables[0].Rows[0]["deliverydate"]).ToString("MM/dd/yyyy");

                //        radiomode.SelectedValue = dBilling.Tables[0].Rows[0]["PayType"].ToString();

                //        txtOrdetBy.Text = dBilling.Tables[0].Rows[0]["ordertakenby"].ToString();
                //        drpPayment.SelectedValue = dBilling.Tables[0].Rows[0]["ipaymode"].ToString();
                //        txtPlace.Text = dBilling.Tables[0].Rows[0]["place"].ToString();
                //        // ddlHours.SelectedValue=

                //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                //        DataRow drCurrentRow = null;


                //        for (int i = 0; i < iCount; i++)
                //        {
                //            DataSet dCat = objbs.selectcategorymaster();

                //            ddCat[i].DataTextField = "Category";
                //            ddCat[i].DataValueField = "CategoryID";
                //            ddCat[i].DataSource = dCat.Tables[0];
                //            ddCat[i].DataBind();


                //            DataSet dCategory = objbs.selectcategorydecription(Convert.ToInt32(dBilling.Tables[0].Rows[i]["CategoryID"].ToString()), sTableName);

                //            DDLFLAVOUR[i].DataTextField = "Definition";
                //            DDLFLAVOUR[i].DataValueField = "categoryuserid";
                //            DDLFLAVOUR[i].DataSource = dCategory.Tables[0];
                //            DDLFLAVOUR[i].DataBind();



                //            QTY[i].Text = dBilling.Tables[0].Rows[i]["Qty"].ToString();

                //            decimal Irate = Convert.ToDecimal(dBilling.Tables[0].Rows[i]["Rate"].ToString());
                //            RATE[i].Text = Decimal.Round(Irate, 2).ToString(""+ratesetting+"");
                //            Decimal ical1 = Convert.ToDecimal(QTY[i].Text) * Irate;
                //            AMt[i].Text = Decimal.Round(ical1, 2).ToString(""+ratesetting+"");

                //            TAX[i].Text = dCategory.Tables[0].Rows[i]["GST"].ToString();


                //            ddCat[i].SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString().Trim();


                //            DDLFLAVOUR[i].SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString().Trim();



                //            int rowIndex = 0;


                //        }



                //    }

                //    #endregion
                //}
                #endregion



                //if (iOrderNo != null)
                {
                    //DataSet dsedit = objbs.getorderdata(sTableName, Convert.ToInt32(iOrderNo));
                    //if (dsedit.Tables[0].Rows.Count > 0)
                    //{
                    //    txtbookNo.Text = dsedit.Tables[0].Rows[0]["BookNo"].ToString();
                    //    txtCustname.Text = dsedit.Tables[0].Rows[0]["CustomerName"].ToString();
                    //    txtOrderDate.Text = dsedit.Tables[0].Rows[0]["OrderDate"].ToString();
                    //    txtPhineNo.Text = dsedit.Tables[0].Rows[0]["CategoryID"].ToString();
                    //    drpPayment.Text = dsedit.Tables[0].Rows[0]["ipaymode"].ToString();
                    //    txtDeliveryDate.Text =Convert.ToDateTime(dsedit.Tables[0].Rows[0]["DeliveryDate"]).ToString("yyyy-MM-dd hh:mm tt");

                    //    txtOrdetBy.Text = dsedit.Tables[0].Rows[0]["OrdertakenBy"].ToString();

                    //    radiomode.SelectedValue = dsedit.Tables[0].Rows[0]["PayType"].ToString();
                    //    //if (dsedit.Tables[0].Rows[0]["CategoryID"].ToString() == "Adv")
                    //    //{
                    //    //    radiomode.SelectedValue = dsedit.Tables[0].Rows[0]["CategoryID"].ToString();
                    //    //}
                    //    //else
                    //    //{
                    //    //    radiomode.SelectedValue = dsedit.Tables[0].Rows[0]["CategoryID"].ToString();
                    //    //}

                    //    txtsubtotal.Text = dsedit.Tables[0].Rows[0]["stotal"].ToString();
                    //    txtcgst.Text = dsedit.Tables[0].Rows[0]["cgst"].ToString();
                    //    txtsgst.Text = dsedit.Tables[0].Rows[0]["sgst"].ToString();
                    //    txttotal.Text = dsedit.Tables[0].Rows[0]["NetAmount"].ToString();

                    //    txtAdvance.Text = dsedit.Tables[0].Rows[0]["Advance"].ToString();
                    //    txtBalance.Text = (Convert.ToDouble(dsedit.Tables[0].Rows[0]["NetAmount"]) - Convert.ToDouble(dsedit.Tables[0].Rows[0]["Advance"])).ToString(""+ratesetting+"");

                    //}
                }

            }

        }

        protected void Producttype_chnaged(object sender, EventArgs e)
        {
            gridorder.DataSource = null;
            gridorder.DataBind();

            FirstGridViewRow();
        }


        #region DYNAMIC GRID

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Category", typeof(string)));
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Tax", typeof(string)));
            dt.Columns.Add(new DataColumn("disc", typeof(string)));

            dt.Columns.Add(new DataColumn("Unit", typeof(string)));
            dt.Columns.Add(new DataColumn("Unitid", typeof(string)));


            dt.Columns.Add(new DataColumn("Modelid", typeof(string)));
            dt.Columns.Add(new DataColumn("Modelimg", typeof(string)));
            dt.Columns.Add(new DataColumn("Modelimgpath", typeof(string)));

            dt.Columns.Add(new DataColumn("Notes", typeof(string)));

            dt.Columns.Add(new DataColumn("packtype", typeof(string)));
            dt.Columns.Add(new DataColumn("Noofpack", typeof(string)));



            dr = dt.NewRow();

            dr["Category"] = string.Empty;
            dr["Item"] = string.Empty;
            dr["Qty"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["Amount"] = string.Empty;
            dr["Tax"] = string.Empty;
            dr["disc"] = string.Empty;

            dr["unit"] = string.Empty;
            dr["unitid"] = string.Empty;

            dr["modelid"] = string.Empty;
            dr["modelimg"] = string.Empty;
            dr["modelimgpath"] = string.Empty;

            dr["Notes"] = string.Empty;

            dr["packtype"] = string.Empty;
            dr["noofpack"] = string.Empty;

            dt.Rows.Add(dr);



            ViewState["CurrentTable"] = dt;
            gridorder.DataSource = dt;
            gridorder.DataBind();

        }


        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                        DropDownList drpcategory = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpcategory");
                        DropDownList drpitem = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpitem");
                        TextBox txtQty = (TextBox)gridorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gridorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gridorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");

                        Label lblitemdiscount = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblitemdiscount");
                        Label lbltax = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lbltax");

                        Label lblunits = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblunits");
                        Label lblunitid = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblunitid");
                        DropDownList ddUnits = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("ddUnits");

                        DropDownList drpmodelno = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpmodelno");
                        Image lblimg = (Image)gridorder.Rows[rowIndex].Cells[1].FindControl("lblimg");
                        Label lblimgpath = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblimgpath");

                        TextBox txtpackingnotes = (TextBox)gridorder.Rows[rowIndex].Cells[5].FindControl("txtpackingnotes");

                        DropDownList drppackingtype = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drppackingtype");
                        TextBox txtnoofpack = (TextBox)gridorder.Rows[rowIndex].Cells[3].FindControl("txtnoofpack");



                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["Category"] = drpcategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Item"] = drpitem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;

                        dtCurrentTable.Rows[i - 1]["Tax"] = lbltax.Text;
                        dtCurrentTable.Rows[i - 1]["disc"] = lblitemdiscount.Text;

                        dtCurrentTable.Rows[i - 1]["Unit"] = ddUnits.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["Unitid"] = ddUnits.SelectedItem.Text;

                        dtCurrentTable.Rows[i - 1]["modelid"] = drpmodelno.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["modelimg"] = lblimg.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["modelimgpath"] = lblimgpath.Text;

                        dtCurrentTable.Rows[i - 1]["notes"] = txtpackingnotes.Text;

                        dtCurrentTable.Rows[i - 1]["packtype"] = drppackingtype.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["noofpack"] = txtnoofpack.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gridorder.DataSource = dtCurrentTable;
                    gridorder.DataBind();


                }



            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList drpcategory = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpcategory");
                        DropDownList drpitem = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpitem");
                        TextBox txtQty = (TextBox)gridorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gridorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gridorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");

                        Label lblitemdiscount = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblitemdiscount");
                        Label lbltax = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lbltax");

                        Label lblunits = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblunits");
                        Label lblunitid = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblunitid");

                        DropDownList ddUnits = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("ddUnits");


                        DropDownList drpmodelno = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpmodelno");
                        Image lblimg = (Image)gridorder.Rows[rowIndex].Cells[1].FindControl("lblimg");
                        Label lblimgpath = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblimgpath");

                        TextBox txtpackingnotes = (TextBox)gridorder.Rows[rowIndex].Cells[5].FindControl("txtpackingnotes");

                        DropDownList drppackingtype = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drppackingtype");
                        TextBox txtnoofpack = (TextBox)gridorder.Rows[rowIndex].Cells[3].FindControl("txtnoofpack");

                        if (dt.Rows[i]["Qty"].ToString() != "")
                        {

                            drpcategory.SelectedValue = dt.Rows[i]["Category"].ToString();
                            drpitem.SelectedValue = dt.Rows[i]["Item"].ToString();

                            txtQty.Text = dt.Rows[i]["Qty"].ToString();
                            txtRate.Text = dt.Rows[i]["Rate"].ToString();
                            txtAmount.Text = dt.Rows[i]["Amount"].ToString();

                            lblitemdiscount.Text = dt.Rows[i]["disc"].ToString();
                            lbltax.Text = dt.Rows[i]["tax"].ToString();

                            ddUnits.SelectedItem.Text = dt.Rows[i]["unit"].ToString();
                            ddUnits.SelectedItem.Text = dt.Rows[i]["unitid"].ToString();


                            drpmodelno.SelectedValue = dt.Rows[i]["modelid"].ToString();
                            lblimg.ImageUrl = dt.Rows[i]["modelimg"].ToString();
                            lblimgpath.Text = dt.Rows[i]["modelimgpath"].ToString();

                            txtpackingnotes.Text = dt.Rows[i]["notes"].ToString();

                            drppackingtype.SelectedValue = dt.Rows[i]["packtype"].ToString();
                            txtnoofpack.Text = dt.Rows[i]["noofpack"].ToString();

                            rowIndex++;
                        }

                    }
                }
            }
        }

        protected void gridorder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gridorder.DataSource = dt;
                    gridorder.DataBind();

                    SetPreviousData();
                    GSTVAlNew();
                }
                else
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gridorder.DataSource = dt;
                    gridorder.DataBind();

                    FirstGridViewRow();
                    SetPreviousData();
                    GSTVAlNew();
                }
            }
        }
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList drpcategory = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpcategory");
                        DropDownList drpitem = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpitem");
                        TextBox txtQty = (TextBox)gridorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gridorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gridorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");

                        Label lblitemdiscount = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblitemdiscount");
                        Label lbltax = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lbltax");

                        Label lblunits = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblunits");
                        Label lblunitid = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblunitid");

                        DropDownList ddUnits = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("ddUnits");

                        DropDownList drpmodelno = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drpmodelno");
                        Image lblimg = (Image)gridorder.Rows[rowIndex].Cells[1].FindControl("lblimg");

                        Label lblimgpath = (Label)gridorder.Rows[rowIndex].Cells[5].FindControl("lblimgpath");

                        TextBox txtpackingnotes = (TextBox)gridorder.Rows[rowIndex].Cells[5].FindControl("txtpackingnotes");

                        DropDownList drppackingtype = (DropDownList)gridorder.Rows[rowIndex].Cells[1].FindControl("drppackingtype");
                        TextBox txtnoofpack = (TextBox)gridorder.Rows[rowIndex].Cells[3].FindControl("txtnoofpack");

                        drCurrentRow = dtCurrentTable.NewRow();


                        dtCurrentTable.Rows[i - 1]["Category"] = drpcategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["item"] = drpitem.SelectedValue;


                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["tax"] = lbltax.Text;
                        dtCurrentTable.Rows[i - 1]["disc"] = lblitemdiscount.Text;

                        dtCurrentTable.Rows[i - 1]["unit"] = ddUnits.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["unitid"] = ddUnits.SelectedItem.Text;

                        dtCurrentTable.Rows[i - 1]["modelid"] = drpmodelno.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["modelimg"] = lblimg.ImageUrl;

                        dtCurrentTable.Rows[i - 1]["modelimgpath"] = lblimgpath.Text;

                        dtCurrentTable.Rows[i - 1]["notes"] = txtpackingnotes.Text;

                        dtCurrentTable.Rows[i - 1]["packtype"] = drppackingtype.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["noofpack"] = txtnoofpack.Text;

                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;

                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {


            #region
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
            {
                DropDownList txti = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");


                itemc = txti.Text;


                if ((itemc == null) || (itemc == ""))
                {
                }
                else
                {
                    for (int vLoop1 = 0; vLoop1 < gridorder.Rows.Count; vLoop1++)
                    {
                        DropDownList txt1 = (DropDownList)gridorder.Rows[vLoop1].FindControl("drpitem");
                        if (txt1.Text == "")
                        {
                        }
                        else
                        {

                            if (ii == iq)
                            {
                            }
                            else
                            {
                                if (itemc == txt1.Text)
                                {
                                    itemcd = txti.SelectedItem.Text;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);

                                    txt1.Focus();

                                    return;

                                }
                            }
                            ii = ii + 1;
                        }
                    }
                }
                iq = iq + 1;
                ii = 1;

                txti.Focus();
            }


            #endregion

            {
                AddNewRow();
            }
        }

        protected void gridorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dCategory = objbs.selectcategorymasterforitemrequest_Order(drpproductiontype.SelectedValue);

            DataSet dst = objbs.selectallcategorydecription_new(sTableName, drpproductiontype.SelectedValue);

            DataSet dsmadel = objbs.Get_model();

            DataSet dsorderuom = objbs.Get_orderuom();

            //  DataSet dunitsval = new DataSet();
            // DataSet dunits = kbs.UNITS();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region

                DropDownList drpcategory = (DropDownList)(e.Row.FindControl("drpcategory") as DropDownList);
                DropDownList drpitem = (DropDownList)(e.Row.FindControl("drpitem") as DropDownList);
                DropDownList drpmodelno = (DropDownList)(e.Row.FindControl("drpmodelno") as DropDownList);
                DropDownList drppackingtype = (DropDownList)(e.Row.FindControl("drppackingtype") as DropDownList);

                // Label lblunits = (Label)(e.Row.FindControl("lblunits") as Label);

                drpcategory.Focus();
                if (dCategory.Tables[0].Rows.Count > 0)
                {
                    drpcategory.DataSource = dCategory.Tables[0];
                    drpcategory.DataTextField = "Category";
                    drpcategory.DataValueField = "CategoryID";
                    drpcategory.DataBind();
                    drpcategory.Items.Insert(0, "Select Category");
                }

                if (dst.Tables[0].Rows.Count > 0)
                {
                    drpitem.DataSource = dst.Tables[0];
                    drpitem.DataTextField = "definition";
                    drpitem.DataValueField = "CategoryuserID";
                    drpitem.DataBind();
                    drpitem.Items.Insert(0, "Select Product");
                }

                if (dsmadel.Tables[0].Rows.Count > 0)
                {
                    drpmodelno.DataSource = dsmadel.Tables[0];
                    drpmodelno.DataTextField = "ModelCode";
                    drpmodelno.DataValueField = "Modelid";
                    drpmodelno.DataBind();
                    drpmodelno.Items.Insert(0, "Select Model");
                }

                if (dsorderuom.Tables[0].Rows.Count > 0)
                {
                    drppackingtype.DataSource = dsorderuom.Tables[0];
                    drppackingtype.DataTextField = "Orderuomname";
                    drppackingtype.DataValueField = "OrderUomvalue";
                    drppackingtype.DataBind();
                    //drppackingtype.Items.Insert(0, "Select OrderUom");
                }




                #endregion
            }
        }

        protected void ModelNo_chnaged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            DropDownList drpmodelno = (DropDownList)row.FindControl("drpmodelno");

            Image lblimg = (Image)row.FindControl("lblimg");

            Label lblimgpath = (Label)row.FindControl("lblimgpath");


            if (drpmodelno.SelectedValue == "Select Model")
            {

            }

            else
            {
                DataSet dsmodel = objbs.EDIT_Model(Convert.ToInt32(drpmodelno.SelectedValue));
                if (dsmodel.Tables[0].Rows.Count > 0)
                {
                    lblimg.ImageUrl = dsmodel.Tables[0].Rows[0]["ModelImage"].ToString();
                    lblimgpath.Text = dsmodel.Tables[0].Rows[0]["ModelImage"].ToString();
                }
                else
                {

                }
            }

        }


        protected void category_chnaged(object sender, EventArgs e)
        {

            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.NamingContainer;

                DropDownList drpCategory = (DropDownList)row.FindControl("drpcategory");

                DropDownList drpItem = (DropDownList)row.FindControl("drpitem");

                if (drpCategory.SelectedItem.Text != "Select Category")
                {

                    DataSet dsCategory1 = objbs.selectcategorydecription(Convert.ToInt32(drpCategory.SelectedValue), sTableName);
                    if (dsCategory1.Tables[0].Rows.Count > 0)
                    {
                        drpItem.Items.Clear();
                        drpItem.DataSource = dsCategory1.Tables[0];
                        drpItem.DataTextField = "Definition";
                        drpItem.DataValueField = "categoryuserid";
                        drpItem.DataBind();
                        drpItem.Items.Insert(0, "Select Product");

                    }
                    else
                    {
                        drpItem.Items.Clear();
                        drpItem.Items.Insert(0, "Select Product");
                    }
                }
                else
                {
                    drpItem.Items.Clear();
                    drpItem.Items.Insert(0, "Select Product");
                }
            }
        }



        protected void packing_type(object sender, EventArgs e)
        {
            GSTVAlNew();
        }
        protected void pack_chnaged(object sender, EventArgs e)
        {

            //TextBox ddl = (TextBox)sender;
            //GridViewRow row = (GridViewRow)ddl.NamingContainer;
            GSTVAlNew();

        }

        protected void productCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable"];
                for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                {
                    DropDownList txti = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");


                    itemc = txti.Text;


                    if ((itemc == null) || (itemc == ""))
                    {
                    }
                    else
                    {
                        for (int vLoop1 = 0; vLoop1 < gridorder.Rows.Count; vLoop1++)
                        {
                            DropDownList txt1 = (DropDownList)gridorder.Rows[vLoop1].FindControl("drpitem");
                            if (txt1.Text == "")
                            {
                            }
                            else
                            {

                                if (ii == iq)
                                {
                                }
                                else
                                {
                                    if (itemc == txt1.Text)
                                    {
                                        itemcd = txti.SelectedItem.Text;
                                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);
                                        txt1.Focus();
                                        return;

                                    }
                                }
                                ii = ii + 1;
                            }
                        }
                    }
                    iq = iq + 1;
                    ii = 1;


                }
            }


            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable"];
                for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                {
                    DropDownList drpcategory = (DropDownList)row.FindControl("drpcategory");

                    DropDownList drpitem = (DropDownList)row.FindControl("drpitem");

                    if (drpitem.SelectedItem.Text != "Select Product")
                    {

                        DataSet dsCategory1 = objbs.selectProduct(Convert.ToInt32(drpitem.SelectedValue), sTableName);
                        if (dsCategory1.Tables[0].Rows.Count > 0)
                        {
                            drpcategory.Items.Clear();

                            DataSet dCategory = objbs.selectcategorymaster();
                            if (dCategory.Tables[0].Rows.Count > 0)
                            {

                                drpcategory.DataSource = dCategory.Tables[0];
                                drpcategory.DataTextField = "category";
                                drpcategory.DataValueField = "categoryid";
                                drpcategory.DataBind();
                                drpcategory.Items.Insert(0, "Select Category");
                            }

                            drpcategory.SelectedValue = dsCategory1.Tables[0].Rows[0]["categoryid"].ToString();

                        }
                        else
                        {
                            drpcategory.Items.Clear();
                            drpcategory.Items.Insert(0, "Select Category");
                        }
                    }
                    else
                    {
                    }


                }
            }


            TextBox txtRate = (TextBox)row.FindControl("txtRate");
            Label lblitemdiscount = (Label)row.FindControl("lblitemdiscount");
            Label lbltax = (Label)row.FindControl("lbltax");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            DropDownList drpitemm = (DropDownList)row.FindControl("drpitem");

            DropDownList drppackingtype = (DropDownList)row.FindControl("drppackingtype");
            TextBox txtnoofpack = (TextBox)row.FindControl("txtnoofpack");


            DataSet DflavAmt = objbs.getCakeRate(Convert.ToInt32(drpitemm.SelectedValue));

            txtAmount.Text = DflavAmt.Tables[0].Rows[0]["Rate"].ToString();
            decimal dAmt = Convert.ToDecimal(DflavAmt.Tables[0].Rows[0]["Rate"].ToString());
            txtRate.Text = dAmt.ToString("" + ratesetting + "");
            // = DflavAmt.Tables[0].Rows[0][Rate].ToString(""+ratesetting+"");
            lbltax.Text = (DflavAmt.Tables[0].Rows[0]["GST"].ToString());

            if (txtnoofpack.Text == "0" || txtnoofpack.Text == "")
            {
            }
            else
            {


                txtQty.Text = Convert.ToDouble(Convert.ToDouble(drppackingtype.SelectedValue) * Convert.ToDouble(txtnoofpack.Text)).ToString("" + qtysetting + "");

                if (txtQty.Text == "0" || txtQty.Text == "")
                {
                }
                else
                {

                    GSTVAlNew();
                }
            }
        }

        protected void txtqty_chnaged(object sender, EventArgs e)
        {


            GSTVAlNew();

        }

        void GSTVAlNew()
        {
            decimal oritot = 0;


            if (btnSave.Text == "Pay Bill")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('WARNING: Not Allow To Edit Item,Rate,Qty.Thank You!!!.');", true);
                return;
            }
            else if (btnSave.Text == "Pay Amount")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('WARNING: Not Allow To Edit Item,Rate,Qty.Thank You!!!.');", true);
                return;
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



            for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
            {
                DropDownList drpcategory = (DropDownList)gridorder.Rows[vLoop].FindControl("drpcategory");
                DropDownList drpitem = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");
                TextBox txtQty = (TextBox)gridorder.Rows[vLoop].FindControl("txtQty");
                TextBox txtRate = (TextBox)gridorder.Rows[vLoop].FindControl("txtRate");
                Label lbltax = (Label)gridorder.Rows[vLoop].FindControl("lbltax");
                Label lblitemdiscount = (Label)gridorder.Rows[vLoop].FindControl("lblitemdiscount");
                TextBox txtAmount = (TextBox)gridorder.Rows[vLoop].FindControl("txtAmount");

                DropDownList drppackingtype = (DropDownList)gridorder.Rows[vLoop].FindControl("drppackingtype");
                TextBox txtnoofpack = (TextBox)gridorder.Rows[vLoop].FindControl("txtnoofpack");

                //DropDownList drppackingtype = (DropDownList)row.FindControl("drppackingtype");
                //TextBox txtnoofpack = (TextBox)row.FindControl("txtnoofpack");
                if (txtnoofpack.Text == "")
                    txtnoofpack.Text = "0";

                if (txtQty.Text == "")
                    txtQty.Text = "0";

                if (txtRate.Text == "")
                    txtRate.Text = "0";

                if (lbltax.Text == "")
                    lbltax.Text = "0";

                if (lblitemdiscount.Text == "")
                    lblitemdiscount.Text = "0";

                // txtQty.Text = (Math.Round(Convert.ToDecimal(txtQty.Text) * 2) / 2).ToString();

                txtQty.Text = Convert.ToDouble(Convert.ToDouble(drppackingtype.SelectedValue) * Convert.ToDouble(txtnoofpack.Text)).ToString("" + qtysetting + "");


                txtAmount.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text)).ToString("" + ratesetting + "");

                {
                    decimal Discamt = 0;
                    if (lblitemdiscount.Text != "")
                    {
                        disco += Convert.ToDecimal(lblitemdiscount.Text);
                    }
                    decimal tooo = Convert.ToDecimal(txtAmount.Text);
                    decimal tooo1 = Convert.ToDecimal(txtAmount.Text);
                    decimal tQty1 = Convert.ToDecimal(txtQty.Text);

                    total += Convert.ToDecimal(txtAmount.Text);
                    total1 += Convert.ToDecimal(txtAmount.Text);
                    TQty += tQty1;

                    //if (dr["Discount"].ToString() == "True")
                    //{
                    //    disTotal += Convert.ToDecimal(dr["Amount"]);
                    //    decimal ttoo = Convert.ToDecimal(dr["Amount"]);
                    //    Tot = Convert.ToDecimal(ttoo);
                    //    dis = Convert.ToDecimal(txtDiscount.Text) / 100;
                    //    Discamt = Tot * dis;
                    //}

                    disTotal += Convert.ToDecimal(txtAmount.Text);
                    decimal ttoo = Convert.ToDecimal(txtAmount.Text);
                    Tot = Convert.ToDecimal(ttoo);
                    dis = Convert.ToDecimal(txtdiscper.Text) / 100;

                    Discamt = Tot * dis;
                    lblitemdiscount.Text = Discamt.ToString("" + ratesetting + "");


                    txtdiscamount.Text = Convert.ToDecimal(Discamt).ToString("" + ratesetting + "");
                    distot += Convert.ToDecimal(Discamt);

                    tooo = tooo1 - Discamt;

                    string GSt = (lbltax.Text).ToString();
                    string amountt = (lbltax.Text).ToString();
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
            }



            txtsubtotal.Text = total.ToString();
            lbloritot.Text = Oritotal.ToString();
            txttotal.Text = grandtotal.ToString();
            txtdiscamount.Text = distot.ToString("" + ratesetting + "");



            txtcgst.Text = (cgstot).ToString("" + ratesetting + "");
            txtsgst.Text = (sgstot).ToString("" + ratesetting + "");
            // decimal Grand = grandtotal + Packing;
            decimal Packing = Convert.ToDecimal(0);
            decimal Delivery = Convert.ToDecimal(0);
            decimal Grand1 = (grandtotal + Packing + Delivery);

            txttotal.Text = (Grand1).ToString("" + ratesetting + "");
            decimal grandtot = Grand1;
            Grand1 = Math.Round(grandtot, 0);
            //if (grandtot > Grand1)
            //{
            //    lblRound.Text = (grandtot - Grand1).ToString("0.00");
            //}
            //else
            //{
            //    lblRound.Text = (Grand1 - grandtot).ToString("0.00");
            //}

            txttotal.Text = (Grand1).ToString("" + ratesetting + "");



            // txtTax.Text = (cgstot + sgstot).ToString("0.00");



            //lbltotal.Text = Convert.ToString(Grand1);
            txttotal.Text = (Grand1).ToString("" + ratesetting + "");
            //txtsubtotal.Text = (Grand1).ToString("0.00");
            //lbldisplay.InnerText = Grand1.ToString("0.00");
            //lbltotqty.Text = TQty.ToString("0.00");

            //for (int i = 0; i < gridorder.Rows.Count; i++)
            //{
            //    DropDownList drpitem = (DropDownList)gridorder.Rows[i].FindControl("drpitem");
            //    Label lblitemdiscount = (Label)gridorder.Rows[i].FindControl("lblitemdiscount");
            //    dt = (DataTable)ViewState["CurrentTable"];

            //    if (drpitem.SelectedValue != "Select Product")
            //    {

            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            if (dr["item"].ToString() == drpitem.SelectedValue)
            //            {

            //                lblitemdiscount.Text = dr["Disamt"].ToString();
            //            }
            //        }
            //    }
            //}

            //if (txtQty1.Text == "")
            //    txtQty1.Text = "0";
            //if (txtQty2.Text == "")
            //    txtQty2.Text = "0";
            //if (txtQty3.Text == "")
            //    txtQty3.Text = "0";
            //if (txtQty4.Text == "")
            //    txtQty4.Text = "0";
            //if (txtQty5.Text == "")
            //    txtQty5.Text = "0";

            //if (txtamount1.Text == "")
            //    txtamount1.Text = "0";
            //if (txtamount2.Text == "")
            //    txtamount2.Text = "0";
            //if (txtamount3.Text == "")
            //    txtamount3.Text = "0";
            //if (txtamount4.Text == "")
            //    txtamount4.Text = "0";
            //if (txtamount5.Text == "")
            //    txtamount5.Text = "0";

            //if (txtrate1.Text == "")
            //    txtrate1.Text = "0";
            //if (txtrate2.Text == "")
            //    txtrate2.Text = "0";
            //if (txtrate3.Text == "")
            //    txtrate3.Text = "0";
            //if (txtrate4.Text == "")
            //    txtrate4.Text = "0";
            //if (txtrate5.Text == "")
            //    txtrate5.Text = "0";
            //if (lbltax1.Text == "")
            //    lbltax1.Text = "0";
            //if (lbltax2.Text == "")
            //    lbltax2.Text = "0";
            //if (lbltax3.Text == "")
            //    lbltax3.Text = "0";
            //if (lbltax4.Text == "")
            //    lbltax4.Text = "0";
            //if (lbltax5.Text == "")
            //    lbltax5.Text = "0";

            //txtQty1.Text = (Math.Round(Convert.ToDecimal(txtQty1.Text) * 2) / 2).ToString();
            //txtQty2.Text = (Math.Round(Convert.ToDecimal(txtQty2.Text) * 2) / 2).ToString();
            //txtQty3.Text = (Math.Round(Convert.ToDecimal(txtQty3.Text) * 2) / 2).ToString();
            //txtQty4.Text = (Math.Round(Convert.ToDecimal(txtQty4.Text) * 2) / 2).ToString();
            //txtQty5.Text = (Math.Round(Convert.ToDecimal(txtQty5.Text) * 2) / 2).ToString();

            //decimal dFlav1 = Convert.ToDecimal(txtrate1.Text) * Convert.ToDecimal(txtQty1.Text);
            //decimal dRate1 = dFlav1;
            //decimal ddisc1 = (dFlav1 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            //lbldisc1.Text = ddisc1.ToString();
            //decimal Dtot1 = dFlav1 - ddisc1;
            //decimal gsttax1 = Convert.ToDecimal(lbltax1.Text);
            //decimal tax1 = (gsttax1 / 2);
            //decimal taxamt1 = (Dtot1 * tax1) / 100;
            //oritot = oritot + (dRate1 + ((dRate1 * gsttax1) / 100));
            //txtamount1.Text = dRate1.ToString(""+ratesetting+"");

            //decimal dFlav2 = Convert.ToDecimal(txtrate2.Text) * Convert.ToDecimal(txtQty2.Text);
            //decimal dRate2 = dFlav2;
            //decimal ddisc2 = (dFlav2 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            //lbldisc2.Text = ddisc2.ToString();
            //decimal Dtot2 = dFlav2 - ddisc2;
            //decimal gsttax2 = Convert.ToDecimal(lbltax2.Text);
            //decimal tax2 = (gsttax2 / 2);
            //decimal taxamt2 = (Dtot2 * tax2) / 100;
            //oritot = oritot + (dRate2 + ((dRate2 * gsttax2) / 100));
            //txtamount2.Text = dRate2.ToString(""+ratesetting+"");


            //decimal dFlav3 = Convert.ToDecimal(txtrate3.Text) * Convert.ToDecimal(txtQty3.Text);
            //decimal dRate3 = dFlav3;
            //decimal ddisc3 = (dFlav3 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            //lbldisc3.Text = ddisc3.ToString();
            //decimal Dtot3 = dFlav3 - ddisc3;
            //decimal gsttax3 = Convert.ToDecimal(lbltax3.Text);
            //decimal tax3 = (gsttax3 / 2);
            //decimal taxamt3 = (Dtot3 * tax3) / 100;
            //oritot = oritot + (dRate3 + ((dRate3 * gsttax3) / 100));
            //txtamount3.Text = dRate3.ToString(""+ratesetting+"");

            //decimal dFlav4 = Convert.ToDecimal(txtrate4.Text) * Convert.ToDecimal(txtQty4.Text);
            //decimal dRate4 = dFlav4;
            //decimal ddisc4 = (dFlav4 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            //lbldisc4.Text = ddisc4.ToString();
            //decimal Dtot4 = dFlav4 - ddisc4;
            //decimal gsttax4 = Convert.ToDecimal(lbltax4.Text);
            //decimal tax4 = (gsttax4 / 2);
            //decimal taxamt4 = (Dtot4 * tax4) / 100;
            //oritot = oritot + (dRate4 + ((dRate4 * gsttax4) / 100));
            //txtamount4.Text = dRate4.ToString(""+ratesetting+"");

            //decimal dFlav5 = Convert.ToDecimal(txtrate5.Text) * Convert.ToDecimal(txtQty5.Text);
            //decimal dRate5 = dFlav5;

            //decimal ddisc5 = (dFlav5 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            //lbldisc5.Text = ddisc5.ToString();
            //decimal Dtot5 = dFlav5 - ddisc5;

            //decimal gsttax5 = Convert.ToDecimal(lbltax5.Text);
            //decimal tax5 = (gsttax5 / 2);
            //decimal taxamt5 = (Dtot5 * tax5) / 100;
            //oritot = oritot + (dRate5 + ((dRate5 * gsttax5) / 100));
            //txtamount5.Text = dRate5.ToString(""+ratesetting+"");

            //decimal dTotal = Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
            //txtsubtotal.Text = dTotal.ToString(""+ratesetting+"");

            //lbloritot.Text = oritot.ToString(""+ratesetting+"");

            //decimal dDisc = Convert.ToDecimal(lbldisc1.Text) + Convert.ToDecimal(lbldisc2.Text) + Convert.ToDecimal(lbldisc3.Text) + Convert.ToDecimal(lbldisc4.Text) + Convert.ToDecimal(lbldisc5.Text);
            //txtdiscamount.Text = dDisc.ToString(""+ratesetting+"");

            //txtsgst.Text = (taxamt1 + taxamt2 + taxamt3 + taxamt4 + taxamt5).ToString(""+ratesetting+"");
            //txtcgst.Text = (taxamt1 + taxamt2 + taxamt3 + taxamt4 + taxamt5).ToString(""+ratesetting+"");

            //txttotal.Text = (dTotal + (Convert.ToDecimal(txtsgst.Text)) + (Convert.ToDecimal(txtcgst.Text)) - dDisc).ToString(""+ratesetting+"");

            if (btnSave.Text == "Save & Print")
            {

                if (txtAdvance.Text != "" && txtAdvance.Text != null)
                {

                    decimal dBal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtAdvance.Text);
                    txtBalance.Text = dBal.ToString("" + ratesetting + "");

                    bool negative = dBal < 0;

                    if (negative == true)
                    {
                        Ramount.Visible = true;
                        // lblrefundamount.Text = (Convert.ToDouble(-(txtBalance.Text))).ToString();
                        lblrefundamount.Text = (-(dBal)).ToString();
                    }
                    else
                    {
                        Ramount.Visible = true;
                        lblrefundamount.Text = "0";
                    }


                }
            }
            else
            {
                if (txtAdvance.Text != "" && txtAdvance.Text != null)
                {
                    if (totpaid.Text == "")
                        totpaid.Text = "0";

                    decimal dBal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(totpaid.Text);
                    txtBalance.Text = dBal.ToString("" + ratesetting + "");

                    bool negative = dBal < 0;

                    if (negative == true)
                    {
                        Ramount.Visible = true;
                        // lblrefundamount.Text = (Convert.ToDouble(-(txtBalance.Text))).ToString();
                        lblrefundamount.Text = (-(dBal)).ToString();
                    }
                    else
                    {
                        Ramount.Visible = true;
                        lblrefundamount.Text = "0";
                    }


                }
            }

        }


        #endregion

        protected void disc_selectedindex(object sender, EventArgs e)
        {
            if (drpdischk.SelectedValue == "Select disc")
            {
                drpdischk.Focus();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Discount.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {
                txtdiscper.Text = drpdischk.SelectedItem.Text;
                txtDiscount_TextChanged(sender, e);

            }
        }

        protected void disc_checkedchanged(object sender, EventArgs e)
        {
            txtdiscotp.Attributes["value"] = "";
            if (btnSave.Text == "Save & Print" || btnSave.Text == "Update Bill")
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
                    txtdiscotp.Enabled = false;
                    txtdiscotp.Text = "";
                    txtdiscper.Text = "0";
                    attednertype.Enabled = false;
                    txtdiscper.Enabled = false;
                    txtdiscotp.Attributes.Clear();
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                    GSTVAlNew();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                    return;
                }

                if (chkdisc.Checked == true)
                {

                    DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
                    if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
                    {
                        lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
                    }

                    if (Convert.ToDouble(lbloritot.Text) < Convert.ToDouble(lblmaxdiscount.Text))
                    {
                        chkdisc.Checked = false;
                        txtdiscper.Text = "0";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Discount Applicable Above " + Convert.ToDouble(lblmaxdiscount.Text).ToString("" + ratesetting + "") + ".Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }

                    txtdiscotp.Enabled = true;
                    attednertype.Enabled = true;
                    //txtdiscper.Enabled = true;
                    //txtDiscount.Focus();
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
                    txtdiscper.Text = "0";
                    attednertype.Enabled = false;
                    txtdiscper.Enabled = false;
                    txtdiscotp.Attributes.Clear();
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Enter Discount.Please Uncheck Disc.Chk.Thank You!!!');", true);
                return;
            }

            GSTVAlNew();
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            if (attednertype.SelectedValue == "Select Disc-Att")
            {
                txtdiscotp.Text = "";
                txtdiscper.Enabled = false;
                txtdiscper.Text = "0";
                GSTVAlNew();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Approval Attender.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            if (txtdiscotp.Text == "")
            {
                txtdiscper.Enabled = false;
                GSTVAlNew();
                txtdiscper.Text = "0";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Password is Incorrect.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (txtdiscper.Text != "" && txtsubtotal.Text != "")
            {
                if (Convert.ToDouble(txtdiscper.Text) <= Convert.ToDouble(lblmaxdiscount.Text))
                {
                    txtdiscper.Enabled = true;
                    GSTVAlNew();
                }
                else
                {
                    GSTVAlNew();
                    txtdiscper.Text = "0";
                    txtdiscper.Enabled = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Maximum Discount Exists.Please Contact Administrator!!!.Thank you!!!');", true);
                    return;
                }

            }
        }

        protected void attednerchk(object sender, EventArgs e)
        {
            txtdiscotp.Text = "";
            txtdiscotp.Attributes.Clear();
            drpdischk.ClearSelection();
            drpdischk.Items.Clear();
            lblmaxdiscount.Text = "0";
            txtdiscper.Text = "0";
            DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
            if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
            {
                lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
            }
            txtdiscper.Enabled = false;
            GSTVAlNew();
        }

        protected void otp_chnaged(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save & Print" || btnSave.Text == "Update Bill")
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
                    txtdiscper.Text = "0";
                    attednertype.Enabled = false;
                    txtdiscper.Enabled = false;
                    txtdiscotp.Attributes.Clear();
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                    GSTVAlNew();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                    return;
                }


                DataSet getmaxdiscamnt = objbs.getmaxdiscamnt();
                if (getmaxdiscamnt.Tables[0].Rows.Count > 0)
                {
                    lblmaxdiscount.Text = Convert.ToDouble(getmaxdiscamnt.Tables[0].Rows[0]["maxdisc"]).ToString("" + ratesetting + "");
                }

                if (Convert.ToDouble(lbloritot.Text) < Convert.ToDouble(lblmaxdiscount.Text))
                {
                    txtdiscper.Text = "0";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Discount Applicable Above " + Convert.ToDouble(lblmaxdiscount.Text).ToString("" + ratesetting + "") + ".Please Contact Administrator.Thank You!!!');", true);
                    return;
                }



                if (attednertype.SelectedValue == "Select Disc-Att")
                {
                    txtdiscotp.Text = "";
                    txtdiscotp.Attributes["value"] = "";
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

                                }
                            }
                            else
                            {
                                drpdischk.Items.Insert(0, "Select disc");
                            }
                        }


                        // lblmaxdiscount.Text = Convert.ToDouble(dcheckotp.Tables[0].Rows[0]["disc"]).ToString("0.00");
                        txtdiscper.Enabled = true;
                        txtdiscper.Focus();
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Maximum Discount Upto " + lblmaxdiscount.Text + ".Thank You!!!');", true);
                        GSTVAlNew();

                        string Password = txtdiscotp.Text;
                        txtdiscotp.Attributes.Add("value", Password);

                    }
                    else
                    {
                        drpdischk.ClearSelection();
                        drpdischk.Items.Clear();
                        //lblmaxdiscount.Text = "0";
                        txtdiscper.Text = "0";
                        txtdiscper.Enabled = false;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password Else Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Enter Discount.Please Uncheck Disc.Chk.Thank You!!!');", true);
                return;
            }


        }



        protected void partial_amount(object sender, EventArgs e)
        {
            string OrderNo = Request.QueryString.Get("OrderNo");
            DataSet dBilling = objbs.PayBill(Convert.ToInt32(OrderNo), sTableName);
            if (dBilling.Tables[0].Rows.Count > 0)
            {
                txtBalance.Text = Convert.ToDouble(dBilling.Tables[0].Rows[0]["balancepaid"]).ToString("" + ratesetting + "");

                if (Convert.ToDouble(txtBalance.Text) < Convert.ToDouble(txtpartialamount.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correct Amount.Thank You!!!.');", true);
                    return;
                }
                else
                {
                    double ball = (Convert.ToDouble(txtBalance.Text) - Convert.ToDouble(txtpartialamount.Text));
                    if (ball == 0 || ball == 0.00)
                    {
                    }
                    else
                    {

                    }

                    txtBalance.Text = ball.ToString("" + ratesetting + "");
                }
            }

        }
        protected void paymodeclick(object sender, EventArgs e)
        {


            {
                if (btnSave.Text == "Save & Print")
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

                    if (lblpaymodesic.Text == "N")
                    {
                        chkdisc.Checked = false;
                        chkdisc.Enabled = false;
                    }

                    //if (chkdisc.Checked == true)
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
                            txtdiscper.Text = "0";
                            attednertype.Enabled = false;
                            txtdiscper.Enabled = false;
                            txtdiscotp.Attributes.Clear();
                            drpdischk.Items.Clear();
                            drpdischk.ClearSelection();
                            GSTVAlNew();
                            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                            //return;
                        }
                    }
                    string confirmValue = hfResponse.Value;
                    if (confirmValue == "Yes")
                    {

                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Change Your PayMode.Thank You!!!');", true);
                        // return;
                    }
                }
                else
                {

                    DataSet getpaymodediscount = objbs.chkpaymodedisc(drpPayment1.SelectedValue);
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

                    if (lblpaymodesic.Text == "N")
                    {
                        chkdisc.Checked = false;
                        chkdisc.Enabled = false;
                    }

                    // if (chkdisc.Checked == true)
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
                            txtdiscper.Text = "0";
                            attednertype.Enabled = false;
                            txtdiscper.Enabled = false;
                            txtdiscotp.Attributes.Clear();
                            drpdischk.Items.Clear();
                            drpdischk.ClearSelection();
                            GSTVAlNew();
                            //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                            //  return;
                        }
                    }

                    string confirmValue = HiddenField1.Value;
                    if (confirmValue == "Yes")
                    {

                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Change Your PayMode.Thank You!!!');", true);
                        // return;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataSet dss = objbs.checkrequestallowornot(sTableName);
            if (dss.Tables[0].Rows.Count > 0)
            {
                sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                sCodeIcing = dss.Tables[0].Rows[0]["IcingCode"].ToString();

                sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (lbltaxchecking.Text == "Y")
            {

                #region Tax checking
                for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                {

                    Label lbltax = (Label)gridorder.Rows[vLoop].FindControl("lbltax");

                    for (int vLoop1 = 0; vLoop1 < gridorder.Rows.Count; vLoop1++)
                    {

                        Label lbltax1 = (Label)gridorder.Rows[vLoop1].FindControl("lbltax");
                        if (lbltax.Text == lbltax1.Text)
                        {

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Different Tax Occured.Thank You!!!');", true);
                            return;
                        }
                    }
                }

                #endregion
            }

            if (btnSave.Text == "Save & Print")
            {
                paymodeclick(sender, e);

                if (lblbooknocheck.Text == "Y")
                {

                    string OFullBookCode = lblbookcode.Text + txtbookNo.Text;
                    string AFullBookCode = lblbookcode.Text + txtabookno.Text;

                    if (OFullBookCode == AFullBookCode)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Given Book No And Now You Entered Book No Mismatched " + AFullBookCode + ".Thank You!!!');", true);
                        txtbookNo.Focus();
                        return;
                    }
                }
            }
            else
            {
                paymodeclick(sender, e);
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


            string OrderNo = Request.QueryString.Get("OrderNo");
            string OldOrderNo = Request.QueryString.Get("OldOrderNo");
            string OrderNoEdit = Request.QueryString.Get("OrderNoEdit");
            string Name = Request.QueryString.Get("Name");
            string discemp = string.Empty;
            if (btnSave.Text == "Save & Print" || btnSave.Text == "Update Bill")
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
                    txtdiscotp.Enabled = false;
                    txtdiscotp.Text = "";
                    txtdiscper.Text = "0";
                    attednertype.Enabled = false;
                    txtdiscper.Enabled = false;
                    txtdiscotp.Attributes.Clear();
                    drpdischk.Items.Clear();
                    drpdischk.ClearSelection();
                    GSTVAlNew();
                    if (chkdisc.Checked == true)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Paymode Not Allow To Enter Discount.Thank You!!!');", true);
                        return;
                    }
                    //chkdisc.Checked = false;
                    //chkdisc.Enabled = false;
                    //txtdiscotp.Text = "";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('For this Paymode Not Allow To Make discount.Please Contact Administrator.Thank You!!!');", true);
                    //return;
                }
                if (chkdisc.Checked == true)
                {

                    if (attednertype.SelectedValue == "Select Disc-Att")
                    {
                        txtdiscotp.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Approval Attender.Please Contact Administrator.Thank You!!!');", true);
                        return;
                    }
                    else
                    {
                        discemp = attednertype.SelectedValue;
                    }
                }
                //else
                //{
                //    discemp = "0";
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Enter Discount.Please Uncheck Disc.Chk.Thank You!!!');", true);
                //    return;

                //}
            }
            else
            {
                if (chkdisc.Checked == true)
                {
                    discemp = "0";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Enter Discount.Please Uncheck Disc.Chk.Thank You!!!');", true);
                    return;
                }
                else
                {


                }
            }
            #region


            if (txtOrdetBy.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Order Taken By.Thank You!!!');", true);
                return;
            }

            if (ddlfunctions.SelectedValue == "Select Functions" || ddlfunctions.SelectedValue == "0" || ddlfunctions.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Function Types.');", true);
                return;
            }
            if (txtPhineNo.Text == "" || txtPhineNo.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Phone No.');", true);
                return;
            }
            if (txtCustname.Text == "" || txtCustname.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Customer Name.');", true);
                return;
            }

            if (OrderNo == null && OldOrderNo == null)
            {

                if (radiomode.SelectedValue == "Full" || radiomode.SelectedValue == "Adv")
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Full payment or Advance .');", true);
                    return;
                }

            }
            if (drporderlist.SelectedValue == "Select Order Option")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Order Type.Thank You!!!.');", true);
                return;
            }
            if (drppickup.SelectedValue == "Select Pickup Location")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Pickup Location.thank You!!!.');", true);
                return;
            }


            if (txtPhineNo.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter 10 Digits Numbers.');", true);
                return;
            }


            #endregion

            string iCustid = "";

            #region
            DataSet dCustid = objbs.GerCustID(txtPhineNo.Text);
            if (dCustid.Tables[0].Rows.Count > 0)
            {
                iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();
            }
            else
            {
                int iStatus = objbs.Insertcust(txtCustname.Text, txtPhineNo.Text, txtaddress.Text, "Yes", lblUserID.Text);

                dCustid = objbs.GerCustID(txtPhineNo.Text);
                iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();

            }
            #endregion

            decimal dBal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtAdvance.Text);
            txtBalance.Text = dBal.ToString("" + ratesetting + "");

            string paytype = "";


            //////int iSuc = objbs.InsertCustBill(Convert.ToInt32(lblUserID.Text), txtCustname.Text, txtPhineNo.Text, "0", "", "", "", Convert.ToInt32(1));
            //////DataSet dCustid = objbs.GerCustID(txtPhineNo.Text);
            //////string iCustid = dCustid.Tables[0].Rows[0]["CustomerID"].ToString();


            int iStockSuccess = 0;

            string FullBookCode = lblbookcode.Text + txtbookNo.Text;


            if (btnSave.Text == "Save & Print")
            {
                int cnt = gridorder.Rows.Count;

                if (cnt == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Add Atleast One Items.Thank You!!!.');", true);
                    return;
                }
                for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                {
                    DropDownList drpcategory = (DropDownList)gridorder.Rows[vLoop].FindControl("drpcategory");
                    DropDownList drpitem = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");
                    TextBox txtQty = (TextBox)gridorder.Rows[vLoop].FindControl("txtQty");
                    TextBox txtRate = (TextBox)gridorder.Rows[vLoop].FindControl("txtRate");
                    Label lbltax = (Label)gridorder.Rows[vLoop].FindControl("lbltax");
                    Label lblitemdiscount = (Label)gridorder.Rows[vLoop].FindControl("lblitemdiscount");
                    TextBox txtAmount = (TextBox)gridorder.Rows[vLoop].FindControl("txtAmount");
                    DropDownList ddUnits = (DropDownList)gridorder.Rows[vLoop].FindControl("ddUnits");

                    DropDownList drpmodelno = (DropDownList)gridorder.Rows[vLoop].FindControl("drpmodelno");
                    Label lblimgpath = (Label)gridorder.Rows[vLoop].FindControl("lblimgpath");

                    if (drpcategory.SelectedValue != "Select Category" && drpitem.SelectedValue != "Select Product" && (txtQty.Text != "" && txtQty.Text != "0"))
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Item in Row Else Delete That " + vLoop + " Row.Thank You!!!.');", true);
                        return;
                    }
                }



                #region
                if (txtbookNo.Text != "")
                {
                    if (txtDeliveryDate.Text != "")
                    {
                        if (radiomode.Text != "")
                        {
                            if (txtPhineNo.Text.Length == 10)
                            {
                                string BillNo = txtbookNo.Text;

                                DataSet dcheckbook = objbs.checkbookno("tblOrder_" + sTableName, FullBookCode);
                                if (dcheckbook.Tables[0].Rows.Count > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Bill Book No.Already Exists.Thank You!!!.');", true);
                                    txtbookNo.Focus();
                                    return;
                                }
                                else
                                {

                                }

                                DataSet ds = objbs.SalesBillnoForOrder("tblOrder_" + sTableName);
                                if (ds.Tables[0].Rows[0]["BillNo"].ToString() == "")
                                    BillNo = "1";
                                else
                                    BillNo = ds.Tables[0].Rows[0]["BillNo"].ToString();

                                DataSet dOrderNo = objbs.GetCakerOrderNo(sTableName);
                                if (dOrderNo.Tables[0].Rows.Count > 0)
                                {
                                    if (dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                                    {

                                        lblOrderNo.InnerText = dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString();
                                    }

                                }
                                string status = "N";

                                string sTime = ddlHours.SelectedValue + " " + ddlMinutes.SelectedValue + " " + ddlMeridian.SelectedValue;// TimeSelector5.Hour.ToString() + TimeSelector5.Minute.ToString(); 
                                if (radiomode.SelectedValue == "Full")
                                {
                                    paytype = "Full";
                                    if (txtBalance.Text == "" + ratesetting + "")
                                    {
                                        status = "Y";
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Payment Type.Something Went Wrong.Please Contact Administrator.');", true);
                                        return;
                                    }
                                }
                                else
                                {
                                    if (txtBalance.Text == "" + ratesetting + "")
                                    {
                                        status = "Y";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Payment Type As Full Payment.');", true);
                                        return;
                                    }
                                    else
                                    {

                                    }

                                    status = "N";
                                    paytype = "Adv";
                                }

                                string Msg = txtMessege.Text + "--" + txtNotes.Text;
                                string Pbranch = "";
                                if (sCodeProd == sCodeIcing)
                                {
                                    Pbranch = sCodeProd;
                                }
                                else
                                {
                                    if (drpproductiontype.SelectedValue == "P")
                                    {
                                        Pbranch = sCodeProd;
                                    }
                                    else if (drpproductiontype.SelectedValue == "I")
                                    {
                                        Pbranch = sCodeIcing;
                                    }
                                }

                                // check internet for sync process
                                string onlinemsg = "";
                                if (synccakeorder == "Y")
                                {
                                    if (objbs.IsConnectedToInternet())
                                    {

                                        chkchecklist.Checked = true;
                                        onlinemsg = "Sync. Successfully";
                                    }
                                    else
                                    {
                                        chkchecklist.Checked = false;
                                        onlinemsg = "No internet Connectivity";
                                    }
                                }
                                else
                                {
                                    chkchecklist.Checked = false;
                                    onlinemsg = "No internet Connectivity";
                                }


                                // int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(lblOrderNo.InnerText), Msg, txtOrdetBy.Text, txtDeliveryDate.Text, Convert.ToString(sTime), Convert.ToInt32(drpPayment.SelectedValue), Convert.ToInt32(txtbookNo.Text), paytype, txtPlace.Text, "", "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text), drporderlist.SelectedValue, drppickup.SelectedValue, txtdeliverycharge.Text, Convert.ToInt32(ddlfunctions.SelectedValue), chkchecklist.Checked, sTableName);
                                int OrderBill = objbs.insertCakeOrderNew("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtsubtotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(lblOrderNo.InnerText), Msg, txtOrdetBy.Text, txtDeliveryDate.Text, Convert.ToString(sTime), Convert.ToInt32(drpPayment.SelectedValue), Convert.ToString(txtbookNo.Text), paytype, txtPlace.Text, "", "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text), drporderlist.SelectedValue, drppickup.SelectedValue, txtdeliverycharge.Text, Convert.ToInt32(ddlfunctions.SelectedValue), chkchecklist.Checked, sTableName, Convert.ToDouble(txtBalance.Text), status, txtdiscper.Text, txtdiscamount.Text, "tbltransOrderAmount_" + sTableName, discemp, FullBookCode, Pbranch, onlinemsg);

                                for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                                {
                                    DropDownList drpcategory = (DropDownList)gridorder.Rows[vLoop].FindControl("drpcategory");
                                    DropDownList drpitem = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");
                                    TextBox txtQty = (TextBox)gridorder.Rows[vLoop].FindControl("txtQty");
                                    TextBox txtRate = (TextBox)gridorder.Rows[vLoop].FindControl("txtRate");
                                    Label lbltax = (Label)gridorder.Rows[vLoop].FindControl("lbltax");
                                    Label lblitemdiscount = (Label)gridorder.Rows[vLoop].FindControl("lblitemdiscount");
                                    TextBox txtAmount = (TextBox)gridorder.Rows[vLoop].FindControl("txtAmount");
                                    DropDownList ddUnits = (DropDownList)gridorder.Rows[vLoop].FindControl("ddUnits");

                                    DropDownList drpmodelno = (DropDownList)gridorder.Rows[vLoop].FindControl("drpmodelno");
                                    Label lblimgpath = (Label)gridorder.Rows[vLoop].FindControl("lblimgpath");

                                    TextBox txtpackingnotes = (TextBox)gridorder.Rows[vLoop].FindControl("txtpackingnotes");

                                    DropDownList drppackingtype = (DropDownList)gridorder.Rows[vLoop].FindControl("drppackingtype");
                                    TextBox txtnoofpack = (TextBox)gridorder.Rows[vLoop].FindControl("txtnoofpack");

                                    string packtypee = "Packing Type Details :" + drppackingtype.SelectedItem.Text + "/" + txtnoofpack.Text + "(" + lblpackingnamenew.Text + ")";

                                    txtpackingnotes.Text = packtypee + " - " + txtpackingnotes.Text;

                                    string modelno = "";
                                    string modelImg = "";

                                    if (drpmodelno.SelectedValue == "Select Model")
                                    {
                                        modelno = "0";
                                        modelImg = "";
                                    }
                                    else
                                    {
                                        modelno = drpmodelno.SelectedValue;
                                        modelImg = lblimgpath.Text;

                                    }


                                    if (drpcategory.SelectedValue != "Select Category" && drpitem.SelectedValue != "Select Product" && (txtQty.Text != "" || txtQty.Text != "0"))
                                    {
                                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(drpcategory.SelectedValue), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtAmount.Text), Convert.ToInt32(drpitem.SelectedValue), chkchecklist.Checked, sTableName, lbltax.Text, lblitemdiscount.Text, modelno, modelImg, onlinemsg, txtpackingnotes.Text,drppackingtype.SelectedValue,txtnoofpack.Text);
                                    }

                                }
                                //if (txtQty1.Text != "" && txtQty1.Text != "0")
                                //{
                                //    int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory1.SelectedValue), Convert.ToDouble(txtQty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToInt32(ddlFlavour1.SelectedValue), chkchecklist.Checked, sTableName, lbltax1.Text,lbldisc1.Text);
                                //}
                                //if (txtQty2.Text != "" && txtQty2.Text != "0")
                                //{
                                //    int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory2.SelectedValue), Convert.ToDouble(txtQty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtamount2.Text), Convert.ToInt32(ddlFlavour2.SelectedValue), chkchecklist.Checked, sTableName, lbltax2.Text, lbldisc2.Text);
                                //}
                                //if (txtQty3.Text != "" && txtQty3.Text != "0")
                                //{
                                //    int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory3.SelectedValue), Convert.ToDouble(txtQty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtamount3.Text), Convert.ToInt32(ddlFlavour3.SelectedValue), chkchecklist.Checked, sTableName, lbltax3.Text, lbldisc3.Text);
                                //}
                                //if (txtQty4.Text != "" && txtQty4.Text != "0")
                                //{
                                //    int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory4.SelectedValue), Convert.ToDouble(txtQty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtamount4.Text), Convert.ToInt32(ddlFlavour4.SelectedValue), chkchecklist.Checked, sTableName, lbltax4.Text, lbldisc4.Text);
                                //}
                                //if (txtQty5.Text != "" && txtQty5.Text != "0")
                                //{
                                //    int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory4.SelectedValue), Convert.ToDouble(txtQty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtamount5.Text), Convert.ToInt32(ddlFlavour5.SelectedValue), chkchecklist.Checked, sTableName, lbltax5.Text, lbldisc5.Text);
                                //}


                                string cancelnum = ddlcancelorder.SelectedValue;

                                if (cancelnum == "")
                                {
                                    cancelnum = "0";
                                }

                                string yourUrl = "Print.aspx?OrderNo=" + lblOrderNo.InnerText + " &&cancelno=" + cancelnum + "";
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);


                                if (chk.Checked)
                                {
                                    #region

                                    if (radiomode.SelectedValue == "Full")
                                    {
                                        smsSendFullMessage();
                                    }
                                    else
                                    {
                                        if (txtAdvance.Text == "0")
                                        {
                                            smsSendZeroAdvanceMessage();
                                        }
                                        else
                                        {
                                            smsSendAdvanceMessage();
                                        }
                                    }
                                    #endregion
                                }
                                ClearALL();

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check The Mobile no .');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('select Paymment method .');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Delivery Date.');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Order Form Book Number.');", true);
                    return;

                }

                #endregion
            }
            else if (btnSave.Text == "Pay Amount")
            {

                DataSet dBilling = objbs.PayBill(Convert.ToInt32(OrderNo), sTableName);
                if (dBilling.Tables[0].Rows.Count > 0)
                {
                    txtBalance.Text = Convert.ToDouble(dBilling.Tables[0].Rows[0]["balancepaid"]).ToString("" + ratesetting + "");

                    if (Convert.ToDouble(txtBalance.Text) < Convert.ToDouble(txtpartialamount.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Correct Amount.Thank You!!!.');", true);
                        return;
                    }
                    else
                    {
                        double ball = (Convert.ToDouble(txtBalance.Text) - Convert.ToDouble(txtpartialamount.Text));
                        if (ball == 0 || ball == 0.00)
                        {
                        }
                        else
                        {

                        }
                        string cancelnum = ddlcancelorder.SelectedValue;

                        if (cancelnum == "")
                        {
                            cancelnum = "0";
                        }

                        txtBalance.Text = ball.ToString("" + ratesetting + "");
                        int iorderpay = objbs.Updatepaymentnew("tblOrder_" + sTableName, OrderNo, txtpartialamount.Text, lblstatus.Text, "tbltransOrderAmount_" + sTableName, "Partial Amount", lblbillno.Text, txtbookNo.Text, drpPayment1.SelectedValue, txtBalance.Text, Name);
                        string yourUrl = "Print.aspx?OrderNo=" + OrderNo + " &&cancelno=" + cancelnum + "";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
                    }

                }




            }
            else if (btnSave.Text == "Pay Bill")
            {
                string delvry = string.Empty;

                if (chkdelivery.Checked == true)
                {
                    delvry = "Delivered";
                    if (txtdeliveryby.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Delivery Name.Thank You!!!.');", true);
                        return;

                    }
                }
                else
                {
                    delvry = "Pending";
                }



                int iorderpay = objbs.UpdateCakeOrderNew("tblOrder_" + sTableName, OrderNo, txtBalance.Text, "Y", lblstatus.Text, "tbltransOrderAmount_" + sTableName, "Bal", lblbillno.Text, txtbookNo.Text, drpPayment1.SelectedValue, Name, delvry, txtdeliveryby.Text, chkdelivery.Checked);

                string yourUrl = "SalesPrint.aspx?Mode=Order&Type=DineIN&NewiSalesID=" + OrderNo + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();

                //   string yourUrl = "SalesPrint.aspx?Mode=Order&NewiSalesID=" + OrderNo;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
                ClearALL();
            }
            else if (btnSave.Text == "Update Bill")
            {
                #region
                if (txtbookNo.Text != "")
                {
                    if (txtDeliveryDate.Text != "")
                    {
                        if (radiomode.Text != "")
                        {
                            if (txtPhineNo.Text.Length == 10)
                            {
                                string BillNo = lblbillno.Text;

                                DataSet dcheckbook = objbs.checkbooknoforupdate("tblOrder_" + sTableName, FullBookCode, OrderNo);
                                if (dcheckbook.Tables[0].Rows.Count > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Bill Book No.Already Exists.Thank You!!!.');", true);
                                    txtbookNo.Focus();
                                    return;
                                }
                                else
                                {

                                }

                                //DataSet ds = objbs.SalesBillno("tblOrder_" + sTableName);
                                //if (ds.Tables[0].Rows[0]["BillNo"].ToString() == "")
                                //    BillNo = "1";
                                //else
                                //    BillNo = ds.Tables[0].Rows[0]["BillNo"].ToString();

                                //DataSet dOrderNo = objbs.GetCakerOrderNo(sTableName);
                                //if (dOrderNo.Tables[0].Rows.Count > 0)
                                //{
                                //    if (dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                                //    {

                                //        lblOrderNo.InnerText = dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString();
                                //    }

                                //}
                                string status = "N";

                                string sTime = ddlHours.SelectedValue + " " + ddlMinutes.SelectedValue + " " + ddlMeridian.SelectedValue;// TimeSelector5.Hour.ToString() + TimeSelector5.Minute.ToString(); 
                                //if (radiomode.SelectedValue == "Full")
                                //{
                                //    paytype = "Full";
                                //    if (txtBalance.Text == "0.00")
                                //    {
                                //        status = "Y";
                                //    }
                                //    else
                                //    {
                                //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Payment Type.Something Went Wrong.Please Contact Administrator.');", true);
                                //        return;
                                //    }
                                //}
                                //else
                                //{
                                //    if (txtBalance.Text == "0.00")
                                //    {
                                //        status = "Y";
                                //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Payment Type As Full Payment.');", true);
                                //        return;
                                //    }
                                //    else
                                //    {

                                //    }

                                //    status = "N";
                                //    paytype = "Adv";
                                //}


                                decimal dBall = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(totpaid.Text);
                                txtBalance.Text = dBall.ToString("" + ratesetting + "");

                                bool negative = dBall < 0;

                                if (negative == true)
                                {
                                    Ramount.Visible = true;
                                    // lblrefundamount.Text = (Convert.ToDouble(-(txtBalance.Text))).ToString();
                                    lblrefundamount.Text = (-(dBall)).ToString();
                                    txtBalance.Text = "0";
                                }
                                else
                                {
                                    Ramount.Visible = true;
                                    lblrefundamount.Text = "0";
                                }


                                // get status of order form
                                DataSet getstatus = objbs.getCakeSummary(OrderNo, sTableName);
                                if (getstatus.Tables[0].Rows.Count > 0)
                                {
                                    string deliveryid = getstatus.Tables[0].Rows[0]["deliveryid"].ToString();

                                    if (deliveryid == "4" || deliveryid == "5")
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This Order Completed.So Not Allow to Edit.Thank You!!!.');", true);
                                        return;
                                    }

                                }

                                //Delete Trans Order
                                int idelete = objbs.Deletetransorder(sTableName, lblbillno.Text, chkchecklist.Checked);


                                string Msg = txtMessege.Text + "--" + txtNotes.Text;

                                // check internet for sync process
                                string onlinemsg = "";
                                if (synccakeorder == "Y")
                                {
                                    if (objbs.IsConnectedToInternet())
                                    {

                                        chkchecklist.Checked = true;
                                        onlinemsg = "Sync. Successfully";
                                    }
                                    else
                                    {
                                        chkchecklist.Checked = false;
                                        onlinemsg = "No internet Connectivity";
                                    }
                                }
                                else
                                {
                                    chkchecklist.Checked = false;
                                    onlinemsg = "No internet Connectivity";
                                }

                                // int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(lblOrderNo.InnerText), Msg, txtOrdetBy.Text, txtDeliveryDate.Text, Convert.ToString(sTime), Convert.ToInt32(drpPayment.SelectedValue), Convert.ToInt32(txtbookNo.Text), paytype, txtPlace.Text, "", "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text), drporderlist.SelectedValue, drppickup.SelectedValue, txtdeliverycharge.Text, Convert.ToInt32(ddlfunctions.SelectedValue), chkchecklist.Checked, sTableName);
                                int OrderBill = objbs.EditCakeOrderNew("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txtsubtotal.Text), Convert.ToDouble(txttotal.Text), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(OrderNo), Msg, txtOrdetBy.Text, txtDeliveryDate.Text, Convert.ToString(sTime), Convert.ToInt32(drpPayment.SelectedValue), Convert.ToString(txtbookNo.Text), paytype, txtPlace.Text, "", "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text), drporderlist.SelectedValue, drppickup.SelectedValue, txtdeliverycharge.Text, Convert.ToInt32(ddlfunctions.SelectedValue), chkchecklist.Checked, sTableName, Convert.ToDouble(txtBalance.Text), status, txtdiscper.Text, txtdiscamount.Text, lblrefundamount.Text, "tbltransorderamount_" + sTableName, drpPayment1.SelectedValue, Name, discemp);

                                for (int vLoop = 0; vLoop < gridorder.Rows.Count; vLoop++)
                                {
                                    DropDownList drpcategory = (DropDownList)gridorder.Rows[vLoop].FindControl("drpcategory");
                                    DropDownList drpitem = (DropDownList)gridorder.Rows[vLoop].FindControl("drpitem");
                                    TextBox txtQty = (TextBox)gridorder.Rows[vLoop].FindControl("txtQty");
                                    TextBox txtRate = (TextBox)gridorder.Rows[vLoop].FindControl("txtRate");
                                    Label lbltax = (Label)gridorder.Rows[vLoop].FindControl("lbltax");
                                    Label lblitemdiscount = (Label)gridorder.Rows[vLoop].FindControl("lblitemdiscount");
                                    TextBox txtAmount = (TextBox)gridorder.Rows[vLoop].FindControl("txtAmount");
                                    DropDownList ddUnits = (DropDownList)gridorder.Rows[vLoop].FindControl("ddUnits");

                                    DropDownList drpmodelno = (DropDownList)gridorder.Rows[vLoop].FindControl("drpmodelno");
                                    Label lblimgpath = (Label)gridorder.Rows[vLoop].FindControl("lblimgpath");

                                    TextBox txtpackingnotes = (TextBox)gridorder.Rows[vLoop].FindControl("txtpackingnotes");

                                    DropDownList drppackingtype = (DropDownList)gridorder.Rows[vLoop].FindControl("drppackingtype");
                                    TextBox txtnoofpack = (TextBox)gridorder.Rows[vLoop].FindControl("txtnoofpack");

                                    string packtypee = "Packing Type Details :" + drppackingtype.SelectedItem.Text + "/" + txtnoofpack.Text + "("+lblpackingnamenew.Text+")";

                                    txtpackingnotes.Text = packtypee +"-"+ txtpackingnotes.Text;


                                    string modelno = "";
                                    string modelImg = "";

                                    if (drpmodelno.SelectedValue == "Select Model")
                                    {
                                        modelno = "0";
                                        modelImg = "";
                                    }
                                    else
                                    {
                                        modelno = drpmodelno.SelectedValue;
                                        modelImg = lblimgpath.Text;

                                    }


                                    if (drpcategory.SelectedValue != "Select Category" && drpitem.SelectedValue != "Select Product" && (txtQty.Text != "" || txtQty.Text != "0"))
                                    {
                                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(drpcategory.SelectedValue), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtRate.Text), Convert.ToDouble(txtAmount.Text), Convert.ToInt32(drpitem.SelectedValue), chkchecklist.Checked, sTableName, lbltax.Text, lblitemdiscount.Text, modelno, modelImg, onlinemsg, txtpackingnotes.Text, drppackingtype.SelectedValue,txtnoofpack.Text);
                                    }

                                }




                                string cancelnum = ddlcancelorder.SelectedValue;

                                if (cancelnum == "")
                                {
                                    cancelnum = "0";
                                }
                                ClearALL();

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check The Mobile no .');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('select Paymment method .');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Delivery Date.');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Order Form Book Number.');", true);
                    return;

                }

                Response.Redirect("OrderGrid.aspx");

                #endregion

            }


            #region OLD CODE

            //if (OrderNo != null)
            //{
            //    #region

            //    string BillNo = "";
            //    DataSet ds = objbs.SalesBillno("tblOrder_" + sTableName);
            //    if (ds.Tables[0].Rows[0]["BillNo"].ToString() == "")
            //        BillNo = "1";
            //    else
            //        BillNo = ds.Tables[0].Rows[0]["BillNo"].ToString();

            //    DataSet dBilling = objbs.PayBill(Convert.ToInt32(OrderNo), sTableName);
            //    if (dBilling.Tables[0].Rows.Count > 0)
            //    {
            //        string Msg = dBilling.Tables[0].Rows[0]["Messege"].ToString();
            //        string Taken = dBilling.Tables[0].Rows[0]["OrderTakenby"].ToString();
            //        DateTime DeliveryDate = Convert.ToDateTime(dBilling.Tables[0].Rows[0]["DeliveryDate"].ToString());
            //        string delDt = DeliveryDate.ToString("yyyy-MM-dd");
            //        string delTime = dBilling.Tables[0].Rows[0]["DeliveryTime"].ToString();
            //        //   string Note = dBilling.Tables[0].Rows[0]["Notes"].ToString();

            //        string Name = Request.QueryString.Get("Name");

            //        //int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), 0, Convert.ToDouble(txtBalance.Text), Convert.ToInt32(OrderNo), Msg, Taken, delDt, delTime, Convert.ToInt32(drpPayment.SelectedValue),Convert.ToInt32(txtbookNo.Text),"Balance",txtPlace.Text,Name);
            //        int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), 0, Convert.ToDouble(txtBalance.Text), Convert.ToInt32(OrderNo), Msg, Taken, delDt, delTime, Convert.ToInt32(drpPayment.SelectedValue), Convert.ToInt32(txtbookNo.Text), "Balance", txtPlace.Text, Name, "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text), drporderlist.SelectedValue, drppickup.SelectedValue, txtdeliverycharge.Text, Convert.ToInt32(ddlfunctions.SelectedValue), chkchecklist.Checked,sTableName);



            //        var DDLFLAVOUR = new[] { ddlFlavour1, ddlFlavour2, ddlFlavour3, ddlFlavour4, ddlFlavour5 };
            //        var ddCat = new[] { ddCategory1, ddCategory1, ddCategory2, ddCategory3, ddCategory4, ddCategory5 };
            //        var QTY = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5 };
            //        var RATE = new[] { txtrate1, txtrate2, txtrate3, txtrate4, txtrate5 };
            //        var AMt = new[] { txtamount1, txtamount2, txtamount3, txtamount4, txtamount5 };
            //        for (int i = 0; i <= 4; i++)
            //        {
            //            if (DDLFLAVOUR[i].SelectedValue != "")
            //            {
            //                DataSet dsGetStockID = objbs.checkPurchaseRate(Convert.ToInt32(DDLFLAVOUR[i].SelectedValue), sTableName);
            //                if (dsGetStockID.Tables[0].Rows.Count > 0)
            //                {
            //                    string sStockID = dsGetStockID.Tables[0].Rows[0]["stockID"].ToString();
            //                    string sDate = dsGetStockID.Tables[0].Rows[0]["ExpiryDate"].ToString();

            //                    //to check printing
            //                    // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddCat[i].SelectedValue), Convert.ToInt32(DDLFLAVOUR[i].SelectedValue), Convert.ToDecimal(QTY[i].Text), sDate, Convert.ToString(sStockID));
            //                }
            //            }
            //            // int iStockSuccess = UpdateStockAvailable(DDLFLAVOUR[i].SelectedValue, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));
            //        }
            //        // Response.Redirect("SalesPrint.aspx?Mode=Order&iSalesID=" + OrderNo);

            //        string yourUrl = "SalesPrint.aspx?Mode=Order&NewiSalesID=" + OrderNo;
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            //        //Response.Redirect("OrderGrid.aspx");

            //        if (chk.Checked)
            //        {
            //            if (Convert.ToDouble(txtAdvance.Text) > 0)
            //            {
            //                smsSendDeliveredMessage();

            //            }
            //            else
            //            {
            //                smsSendZeroDeliveredMessage();
            //            }
            //        }
            //        ClearALL(); //For message, value need so clear all paste in above function - Kishore
            //        // Response.Redirect("OrderGrid.aspx");
            //    }

            //    #endregion
            //}
            //else if (OrderNoEdit != null)
            //{
            //    #region

            //    if (radiomode.SelectedValue == "Full" || radiomode.SelectedValue == "Adv")
            //    {

            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Full payment or Advance .');", true);
            //        return;
            //    }

            //    if (txtbookNo.Text != "")
            //    {
            //        if (txtDeliveryDate.Text != "")
            //        {
            //            if (radiomode.Text != "")
            //            {
            //                if (txtPhineNo.Text.Length == 10)
            //                {
            //                    string BillNo = txtbookNo.Text;
            //                    DataSet ds = objbs.SalesBillno("tblOrder_" + sTableName);
            //                    if (ds.Tables[0].Rows[0]["BillNo"].ToString() == "")
            //                        BillNo = "1";
            //                    else
            //                        BillNo = ds.Tables[0].Rows[0]["BillNo"].ToString();

            //                    //DataSet dOrderNo = objbs.GetCakerOrderNo(sTableName);
            //                    //if (dOrderNo.Tables[0].Rows.Count > 0)
            //                    //{
            //                    //    if (dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString() != "")
            //                    //    {

            //                    //        lblOrderNo.InnerText = dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString();
            //                    //    }

            //                    //}


            //                   int idel = objbs.deleteorder(sTableName, Convert.ToInt32(OrderNoEdit));

            //                    string sTime = ddlHours.SelectedValue + " " + ddlMinutes.SelectedValue + " " + ddlMeridian.SelectedValue;// TimeSelector5.Hour.ToString() + TimeSelector5.Minute.ToString(); 
            //                    if (radiomode.SelectedValue == "Full")
            //                    {
            //                        paytype = "Full";
            //                    }
            //                    else
            //                    {
            //                        paytype = "Adv";
            //                    }

            //                    string Msg = txtMessege.Text + "--" + txtNotes.Text;
            //                    //int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(lblOrderNo.InnerText), Msg, txtOrdetBy.Text, txtDeliveryDate.Text, Convert.ToString(sTime), Convert.ToInt32(drpPayment.SelectedValue), Convert.ToInt32(txtbookNo.Text), paytype, txtPlace.Text,"");
            //                    int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), Convert.ToInt32(1), Convert.ToDouble(txtAdvance.Text), Convert.ToInt32(lblOrderNo.InnerText), Msg, txtOrdetBy.Text, txtDeliveryDate.Text, Convert.ToString(sTime), Convert.ToInt32(drpPayment.SelectedValue), Convert.ToInt32(txtbookNo.Text), paytype, txtPlace.Text, "", "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text), drporderlist.SelectedValue, drppickup.SelectedValue, txtdeliverycharge.Text, Convert.ToInt32(ddlfunctions.SelectedValue),chkchecklist.Checked,sTableName);


            //                    //  int isave = objbs.CustomerOrder(Convert.ToInt32(lblOrderNo.InnerText), Convert.ToDateTime(txtOrderDate.Text), txtCustname.Text, txtaddress.Text, txtPhineNo.Text, Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtAdvance.Text), Convert.ToDouble(txtBalance.Text), Convert.ToDateTime(txtDeliveryDate.Text),Convert.ToString( TimeSelector5.Hour+":"+TimeSelector5.Minute+TimeSelector5.AmPm), txtOrdetBy.Text, Convert.ToInt32(lblUserID.Text), sBranchCode,0);

            //                    if (txtQty1.Text != "" && txtQty1.Text != "0")
            //                    {
            //                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory1.SelectedValue), Convert.ToDouble(txtQty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToInt32(ddlFlavour1.SelectedValue),chkchecklist.Checked,sTableName);
            //                        // int iTrans = objbs.TransCustomerOrder(Convert.ToInt32(lblOrderNo.InnerText), Convert.ToInt32(ddCategory1.SelectedValue), Convert.ToInt32(ddlFlavour1.SelectedValue), Convert.ToDouble(txtQty1.Text), Convert.ToDouble(txtrate1.Text), Convert.ToDouble(txtamount1.Text),ddUnits1.SelectedItem.Text);
            //                    }
            //                    if (txtQty2.Text != "" && txtQty2.Text != "0")
            //                    {
            //                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory2.SelectedValue), Convert.ToDouble(txtQty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtamount2.Text), Convert.ToInt32(ddlFlavour2.SelectedValue), chkchecklist.Checked, sTableName);
            //                        // int iTrans = objbs.TransCustomerOrder(Convert.ToInt32(lblOrderNo.InnerText), Convert.ToInt32(ddCategory2.SelectedValue), Convert.ToInt32(ddlFlavour2.SelectedValue), Convert.ToDouble(txtQty2.Text), Convert.ToDouble(txtrate2.Text), Convert.ToDouble(txtamount2.Text), ddUnits2.SelectedItem.Text);
            //                    }
            //                    if (txtQty3.Text != "" && txtQty3.Text != "0")
            //                    {
            //                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory3.SelectedValue), Convert.ToDouble(txtQty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtamount3.Text), Convert.ToInt32(ddlFlavour3.SelectedValue), chkchecklist.Checked, sTableName);
            //                        // int iTrans = objbs.TransCustomerOrder(Convert.ToInt32(lblOrderNo.InnerText), Convert.ToInt32(ddCategory3.SelectedValue), Convert.ToInt32(ddlFlavour3.SelectedValue), Convert.ToDouble(txtQty3.Text), Convert.ToDouble(txtrate3.Text), Convert.ToDouble(txtamount3.Text), ddUnits3.SelectedItem.Text);
            //                    }
            //                    if (txtQty4.Text != "" && txtQty4.Text != "0")
            //                    {
            //                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory4.SelectedValue), Convert.ToDouble(txtQty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtamount4.Text), Convert.ToInt32(ddlFlavour4.SelectedValue), chkchecklist.Checked, sTableName);
            //                        //int iTrans = objbs.TransCustomerOrder(Convert.ToInt32(lblOrderNo.InnerText), Convert.ToInt32(ddCategory4.SelectedValue), Convert.ToInt32(ddlFlavour4.SelectedValue), Convert.ToDouble(txtQty4.Text), Convert.ToDouble(txtrate4.Text), Convert.ToDouble(txtamount4.Text), ddUnits4.SelectedItem.Text);
            //                    }
            //                    if (txtQty5.Text != "" && txtQty5.Text != "0")
            //                    {
            //                        int iStatus1 = objbs.InsertTransCakeorder("tbltransorder_" + sTableName, Convert.ToInt32(BillNo), Convert.ToInt32(ddCategory4.SelectedValue), Convert.ToDouble(txtQty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtamount5.Text), Convert.ToInt32(ddlFlavour5.SelectedValue), chkchecklist.Checked, sTableName);
            //                        // int iTrans = objbs.TransCustomerOrder(Convert.ToInt32(lblOrderNo.InnerText), Convert.ToInt32(ddCategory5.SelectedValue), Convert.ToInt32(ddlFlavour5.SelectedValue), Convert.ToDouble(txtQty5.Text), Convert.ToDouble(txtrate5.Text), Convert.ToDouble(txtamount5.Text), ddUnits4.SelectedItem.Text);
            //                    }

            //                    //Response.Redirect("Print.aspx?OrderNo=" + lblOrderNo.InnerText);
            //                    string cancelnum = ddlcancelorder.SelectedValue;

            //                    if (cancelnum == "")
            //                    {
            //                        cancelnum = "0";
            //                    }

            //                    string yourUrl = "Print.aspx?OrderNo=" + lblOrderNo.InnerText + " &&cancelno=" + cancelnum + "";
            //                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            //                    //  Response.Redirect("OrderGrid.aspx");

            //                    if (chk.Checked)
            //                    {
            //                        if (radiomode.SelectedValue == "Full")
            //                        {
            //                            smsSendFullMessage();
            //                        }
            //                        else
            //                        {
            //                            if (txtAdvance.Text == "0")
            //                            {
            //                                smsSendZeroAdvanceMessage();
            //                            }
            //                            else
            //                            {
            //                                smsSendAdvanceMessage();
            //                            }
            //                        }
            //                    }
            //                    ClearALL(); //For message, value need so clear all paste in above function - Kishore
            //                    // Response.Redirect("OrderGrid.aspx");
            //                }
            //                else
            //                {
            //                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check The Mobile no .');", true);
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('select Paymode.');", true);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Delivery Date.');", true);
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Order Form Book Number.');", true);
            //        return;

            //    }

            //    #endregion

            //    #region

            //    //string BillNo = "";
            //    //DataSet ds = objbs.SalesBillno("tblOrder_" + sTableName);
            //    //if (ds.Tables[0].Rows[0]["BillNo"].ToString() == "")
            //    //    BillNo = "1";
            //    //else
            //    //    BillNo = ds.Tables[0].Rows[0]["BillNo"].ToString();

            //    //DataSet dBilling = objbs.PayBill(Convert.ToInt32(OrderNo), sTableName);
            //    //if (dBilling.Tables[0].Rows.Count > 0)
            //    //{
            //    //    string Msg = dBilling.Tables[0].Rows[0]["Messege"].ToString();
            //    //    string Taken = dBilling.Tables[0].Rows[0]["OrderTakenby"].ToString();
            //    //    DateTime DeliveryDate = Convert.ToDateTime(dBilling.Tables[0].Rows[0]["DeliveryDate"].ToString());
            //    //    string delDt = DeliveryDate.ToString("yyyy-MM-dd");
            //    //    string delTime = dBilling.Tables[0].Rows[0]["DeliveryTime"].ToString();
            //    //    //   string Note = dBilling.Tables[0].Rows[0]["Notes"].ToString();

            //    //    string Name = Request.QueryString.Get("Name");

            //    //    //int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), 0, Convert.ToDouble(txtBalance.Text), Convert.ToInt32(OrderNo), Msg, Taken, delDt, delTime, Convert.ToInt32(drpPayment.SelectedValue),Convert.ToInt32(txtbookNo.Text),"Balance",txtPlace.Text,Name);
            //    //    int OrderBill = objbs.insertCakeOrder("tblOrder_" + sTableName, BillNo, txtOrderDate.Text, Convert.ToInt32(iCustid), Convert.ToDouble(txttotal.Text), Convert.ToDouble(txtBalance.Text), 0, Convert.ToDouble(txtBalance.Text), Convert.ToInt32(OrderNo), Msg, Taken, delDt, delTime, Convert.ToInt32(drpPayment.SelectedValue), Convert.ToInt32(txtbookNo.Text), "Balance", txtPlace.Text, Name, "", Convert.ToDouble(txtcgst.Text), Convert.ToDouble(txtsgst.Text), Convert.ToDouble(txtsubtotal.Text));



            //    //    var DDLFLAVOUR = new[] { ddlFlavour1, ddlFlavour2, ddlFlavour3, ddlFlavour4, ddlFlavour5 };
            //    //    var ddCat = new[] { ddCategory1, ddCategory1, ddCategory2, ddCategory3, ddCategory4, ddCategory5 };
            //    //    var QTY = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5 };
            //    //    var RATE = new[] { txtrate1, txtrate2, txtrate3, txtrate4, txtrate5 };
            //    //    var AMt = new[] { txtamount1, txtamount2, txtamount3, txtamount4, txtamount5 };
            //    //    for (int i = 0; i <= 4; i++)
            //    //    {
            //    //        if (DDLFLAVOUR[i].SelectedValue != "")
            //    //        {
            //    //            DataSet dsGetStockID = objbs.checkPurchaseRate(Convert.ToInt32(DDLFLAVOUR[i].SelectedValue), sTableName);
            //    //            if (dsGetStockID.Tables[0].Rows.Count > 0)
            //    //            {
            //    //                string sStockID = dsGetStockID.Tables[0].Rows[0]["stockID"].ToString();
            //    //                string sDate = dsGetStockID.Tables[0].Rows[0]["ExpiryDate"].ToString();

            //    //                //to check printing
            //    //                // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddCat[i].SelectedValue), Convert.ToInt32(DDLFLAVOUR[i].SelectedValue), Convert.ToDecimal(QTY[i].Text), sDate, Convert.ToString(sStockID));
            //    //            }
            //    //        }
            //    //        // int iStockSuccess = UpdateStockAvailable(DDLFLAVOUR[i].SelectedValue, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));
            //    //    }
            //    //    // Response.Redirect("SalesPrint.aspx?Mode=Order&iSalesID=" + OrderNo);

            //    //    string yourUrl = "SalesPrint.aspx?Mode=Order&NewiSalesID=" + OrderNo;
            //    //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            //    //    //Response.Redirect("OrderGrid.aspx");

            //    //    if (chk.Checked)
            //    //    {
            //    //        if (Convert.ToDouble(txtAdvance.Text) > 0)
            //    //        {
            //    //            smsSendDeliveredMessage();

            //    //        }
            //    //        else
            //    //        {
            //    //            smsSendZeroDeliveredMessage();
            //    //        }
            //    //    }
            //    //    //ClearALL(); For message, value need so clear all paste in above function - Kishore
            //    //}


            //    #endregion
            //}
            //else if (OrderNo == null || OldOrderNo == null)
            //{

            //}

            #endregion

        }
        void GSTVAl()
        {
            decimal oritot = 0;


            if (btnSave.Text == "Pay Bill")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('WARNING: Not Allow To Edit Item,Rate,Qty.Thank You!!!.');", true);
                return;
            }
            else if (btnSave.Text == "Pay Amount")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('WARNING: Not Allow To Edit Item,Rate,Qty.Thank You!!!.');", true);
                return;
            }

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

            if (txtamount1.Text == "")
                txtamount1.Text = "0";
            if (txtamount2.Text == "")
                txtamount2.Text = "0";
            if (txtamount3.Text == "")
                txtamount3.Text = "0";
            if (txtamount4.Text == "")
                txtamount4.Text = "0";
            if (txtamount5.Text == "")
                txtamount5.Text = "0";

            if (txtrate1.Text == "")
                txtrate1.Text = "0";
            if (txtrate2.Text == "")
                txtrate2.Text = "0";
            if (txtrate3.Text == "")
                txtrate3.Text = "0";
            if (txtrate4.Text == "")
                txtrate4.Text = "0";
            if (txtrate5.Text == "")
                txtrate5.Text = "0";
            if (lbltax1.Text == "")
                lbltax1.Text = "0";
            if (lbltax2.Text == "")
                lbltax2.Text = "0";
            if (lbltax3.Text == "")
                lbltax3.Text = "0";
            if (lbltax4.Text == "")
                lbltax4.Text = "0";
            if (lbltax5.Text == "")
                lbltax5.Text = "0";

            txtQty1.Text = (Math.Round(Convert.ToDecimal(txtQty1.Text) * 2) / 2).ToString();
            txtQty2.Text = (Math.Round(Convert.ToDecimal(txtQty2.Text) * 2) / 2).ToString();
            txtQty3.Text = (Math.Round(Convert.ToDecimal(txtQty3.Text) * 2) / 2).ToString();
            txtQty4.Text = (Math.Round(Convert.ToDecimal(txtQty4.Text) * 2) / 2).ToString();
            txtQty5.Text = (Math.Round(Convert.ToDecimal(txtQty5.Text) * 2) / 2).ToString();

            decimal dFlav1 = Convert.ToDecimal(txtrate1.Text) * Convert.ToDecimal(txtQty1.Text);
            decimal dRate1 = dFlav1;
            decimal ddisc1 = (dFlav1 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            lbldisc1.Text = ddisc1.ToString();
            decimal Dtot1 = dFlav1 - ddisc1;
            decimal gsttax1 = Convert.ToDecimal(lbltax1.Text);
            decimal tax1 = (gsttax1 / 2);
            decimal taxamt1 = (Dtot1 * tax1) / 100;
            oritot = oritot + (dRate1 + ((dRate1 * gsttax1) / 100));
            txtamount1.Text = dRate1.ToString("" + ratesetting + "");

            decimal dFlav2 = Convert.ToDecimal(txtrate2.Text) * Convert.ToDecimal(txtQty2.Text);
            decimal dRate2 = dFlav2;
            decimal ddisc2 = (dFlav2 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            lbldisc2.Text = ddisc2.ToString();
            decimal Dtot2 = dFlav2 - ddisc2;
            decimal gsttax2 = Convert.ToDecimal(lbltax2.Text);
            decimal tax2 = (gsttax2 / 2);
            decimal taxamt2 = (Dtot2 * tax2) / 100;
            oritot = oritot + (dRate2 + ((dRate2 * gsttax2) / 100));
            txtamount2.Text = dRate2.ToString("" + ratesetting + "");


            decimal dFlav3 = Convert.ToDecimal(txtrate3.Text) * Convert.ToDecimal(txtQty3.Text);
            decimal dRate3 = dFlav3;
            decimal ddisc3 = (dFlav3 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            lbldisc3.Text = ddisc3.ToString();
            decimal Dtot3 = dFlav3 - ddisc3;
            decimal gsttax3 = Convert.ToDecimal(lbltax3.Text);
            decimal tax3 = (gsttax3 / 2);
            decimal taxamt3 = (Dtot3 * tax3) / 100;
            oritot = oritot + (dRate3 + ((dRate3 * gsttax3) / 100));
            txtamount3.Text = dRate3.ToString("" + ratesetting + "");

            decimal dFlav4 = Convert.ToDecimal(txtrate4.Text) * Convert.ToDecimal(txtQty4.Text);
            decimal dRate4 = dFlav4;
            decimal ddisc4 = (dFlav4 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            lbldisc4.Text = ddisc4.ToString();
            decimal Dtot4 = dFlav4 - ddisc4;
            decimal gsttax4 = Convert.ToDecimal(lbltax4.Text);
            decimal tax4 = (gsttax4 / 2);
            decimal taxamt4 = (Dtot4 * tax4) / 100;
            oritot = oritot + (dRate4 + ((dRate4 * gsttax4) / 100));
            txtamount4.Text = dRate4.ToString("" + ratesetting + "");

            decimal dFlav5 = Convert.ToDecimal(txtrate5.Text) * Convert.ToDecimal(txtQty5.Text);
            decimal dRate5 = dFlav5;

            decimal ddisc5 = (dFlav5 * Convert.ToDecimal(txtdiscper.Text)) / 100;
            lbldisc5.Text = ddisc5.ToString();
            decimal Dtot5 = dFlav5 - ddisc5;

            decimal gsttax5 = Convert.ToDecimal(lbltax5.Text);
            decimal tax5 = (gsttax5 / 2);
            decimal taxamt5 = (Dtot5 * tax5) / 100;
            oritot = oritot + (dRate5 + ((dRate5 * gsttax5) / 100));
            txtamount5.Text = dRate5.ToString("" + ratesetting + "");

            decimal dTotal = Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
            txtsubtotal.Text = dTotal.ToString("" + ratesetting + "");

            lbloritot.Text = oritot.ToString("" + ratesetting + "");

            decimal dDisc = Convert.ToDecimal(lbldisc1.Text) + Convert.ToDecimal(lbldisc2.Text) + Convert.ToDecimal(lbldisc3.Text) + Convert.ToDecimal(lbldisc4.Text) + Convert.ToDecimal(lbldisc5.Text);
            txtdiscamount.Text = dDisc.ToString("" + ratesetting + "");

            txtsgst.Text = (taxamt1 + taxamt2 + taxamt3 + taxamt4 + taxamt5).ToString("" + ratesetting + "");
            txtcgst.Text = (taxamt1 + taxamt2 + taxamt3 + taxamt4 + taxamt5).ToString("" + ratesetting + "");

            txttotal.Text = (dTotal + (Convert.ToDecimal(txtsgst.Text)) + (Convert.ToDecimal(txtcgst.Text)) - dDisc).ToString("" + ratesetting + "");

            if (btnSave.Text == "Save & Print")
            {

                if (txtAdvance.Text != "" && txtAdvance.Text != null)
                {

                    decimal dBal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtAdvance.Text);
                    txtBalance.Text = dBal.ToString("" + ratesetting + "");

                    bool negative = dBal < 0;

                    if (negative == true)
                    {
                        Ramount.Visible = true;
                        // lblrefundamount.Text = (Convert.ToDouble(-(txtBalance.Text))).ToString();
                        lblrefundamount.Text = (-(dBal)).ToString();
                    }
                    else
                    {
                        Ramount.Visible = true;
                        lblrefundamount.Text = "0";
                    }


                }
            }
            else
            {
                if (txtAdvance.Text != "" && txtAdvance.Text != null)
                {
                    if (totpaid.Text == "")
                        totpaid.Text = "0";

                    decimal dBal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(totpaid.Text);
                    txtBalance.Text = dBal.ToString("" + ratesetting + "");

                    bool negative = dBal < 0;

                    if (negative == true)
                    {
                        Ramount.Visible = true;
                        // lblrefundamount.Text = (Convert.ToDouble(-(txtBalance.Text))).ToString();
                        lblrefundamount.Text = (-(dBal)).ToString();
                    }
                    else
                    {
                        Ramount.Visible = true;
                        lblrefundamount.Text = "0";
                    }


                }
            }

        }
        void ClearALL()
        {
            var DDLFLAVOUR = new[] { ddlFlavour1, ddlFlavour2, ddlFlavour3, ddlFlavour4, ddlFlavour5 };
            var ddCat = new[] { ddCategory1, ddCategory1, ddCategory2, ddCategory3, ddCategory4, ddCategory5 };
            var QTY = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5 };
            var RATE = new[] { txtrate1, txtrate2, txtrate3, txtrate4, txtrate5 };
            var AMt = new[] { txtamount1, txtamount2, txtamount3, txtamount4, txtamount5 };
            for (int i = 0; i <= 4; i++)
            {
                DDLFLAVOUR[i].ClearSelection();
                ddCat[i].ClearSelection();
                QTY[i].Text = "";
                RATE[i].Text = "";
                AMt[i].Text = "0";
            }

            txttotal.Text = "";
            txtAdvance.Text = "";
            txtBalance.Text = "";
            txtMessege.Text = "";
            txtNotes.Text = "";
            txtOrdetBy.Text = "";
            txtCustname.Text = "";
            txtaddress.Text = "";
            txtPhineNo.Text = "";
            txtDeliveryDate.Text = "";

            txtsubtotal.Text = "0";
            txtcgst.Text = "0";
            txtsgst.Text = "0";

            ddlcancelorder.ClearSelection();
            DataSet dOrderNo = objbs.GetCakerOrderNo(sTableName);
            if (dOrderNo.Tables[0].Rows.Count > 0)
            {
                if (dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                {
                    //string sUser = lblUser.Text;
                    //string[] sUserDet = sUser.Split('@');
                    lblBranch.InnerText = sBranchCode;
                    lblOrderNo.InnerText = dOrderNo.Tables[0].Rows[0]["OrderNo"].ToString();
                }
                else
                {
                    //string sUser = lblUser.Text;
                    //string[] sUserDet = sUser.Split('@');
                    lblBranch.InnerText = sBranchCode;

                    lblOrderNo.InnerText = "1";
                }
            }

            else
            {
                //string sUser = lblUser.Text;
                //string[] sUserDet = sUser.Split('@');
                lblBranch.InnerText = sBranchCode;
                lblOrderNo.InnerText = "1";
            }

            gridorder.DataSource = null;
            gridorder.DataBind();
            ViewState["CurrentTable"] = null;

            // Response.Redirect("OrderGrid.aspx");
        }
        private int UpdateStockAvailable(int iCat, int iSubCat, decimal iQty, string sDate, string iStockID)
        {
            decimal iAQty = 0;

            int iSuccess = 0;

            DataSet dsStock = objbs.GetStockDetails(Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, StockOption);
            if (dsStock.Tables[0].Rows.Count > 0)
            {
                iAQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

            }
            decimal iRemQty = iAQty - iQty;
            iSuccess = objbs.updateSalesStock(iRemQty, iCat, iSubCat, sDate, Convert.ToInt32(iStockID), Convert.ToInt32(lblUserID.Text), sTableName, "-", "Order Entry", iQty.ToString(), "0", "");


            return iSuccess;
        }
        protected void ddlFlavour_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DflavAmt = objbs.getCakeRate(Convert.ToInt32(ddlFlavour5.SelectedValue));

            txtFalvAmount5.Text = DflavAmt.Tables[0].Rows[0][Rate].ToString();
            decimal dAmt = Convert.ToDecimal(DflavAmt.Tables[0].Rows[0][Rate].ToString());
            txtrate5.Text = dAmt.ToString("" + ratesetting + "");

            lbltax5.Text = (DflavAmt.Tables[0].Rows[0]["GST"].ToString());

            GSTVAlNew();
        }


        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            //decimal dFlav = Convert.ToDecimal(txtrate5.Text) * Convert.ToDecimal(txtQty5.Text);

            //decimal dRate = dFlav;
            //txtamount5.Text = dRate.ToString(""+ratesetting+"");
            //decimal dTotal = Convert.ToDecimal(txtamount1.Text) + Convert.ToDecimal(txtamount2.Text) + Convert.ToDecimal(txtamount3.Text) + Convert.ToDecimal(txtamount4.Text) + Convert.ToDecimal(txtamount5.Text);
            //txttotal.Text = dTotal.ToString(""+ratesetting+"");
            GSTVAlNew();
        }

        protected void txtAdvance_TextChanged(object sender, EventArgs e)
        {
            decimal dBal = Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtAdvance.Text);
            txtBalance.Text = dBal.ToString("" + ratesetting + "");
        }

        protected void ddCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dFlavour = objbs.selectcategorydecription(Convert.ToInt32(ddCategory1.SelectedValue), sTableName);
            ddlFlavour1.DataSource = dFlavour.Tables[0];
            ddlFlavour1.DataTextField = "Definition";
            ddlFlavour1.DataValueField = "CategoryUserID";
            ddlFlavour1.DataBind();
            ddlFlavour1.Items.Insert(0, "Select Category");
        }

        protected void ddCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dFlavour = objbs.selectcategorydecription(Convert.ToInt32(ddCategory2.SelectedValue), sTableName);
            ddlFlavour2.DataSource = dFlavour.Tables[0];
            ddlFlavour2.DataTextField = "Definition";
            ddlFlavour2.DataValueField = "CategoryUserID";
            ddlFlavour2.DataBind();
            ddlFlavour2.Items.Insert(0, "Select Category");

        }

        protected void ddCategory3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dFlavour = objbs.selectcategorydecription(Convert.ToInt32(ddCategory3.SelectedValue), sTableName);
            ddlFlavour3.DataSource = dFlavour.Tables[0];
            ddlFlavour3.DataTextField = "Definition";
            ddlFlavour3.DataValueField = "CategoryUserID";
            ddlFlavour3.DataBind();
            ddlFlavour3.Items.Insert(0, "Select Category");
        }

        protected void ddCategory4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dFlavour = objbs.selectcategorydecription(Convert.ToInt32(ddCategory4.SelectedValue), sTableName);
            ddlFlavour4.DataSource = dFlavour.Tables[0];
            ddlFlavour4.DataTextField = "Definition";
            ddlFlavour4.DataValueField = "CategoryUserID";
            ddlFlavour4.DataBind();
            ddlFlavour4.Items.Insert(0, "Select Category");

        }

        protected void ddCategory5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dFlavour = objbs.selectcategorydecription(Convert.ToInt32(ddCategory5.SelectedValue), sTableName);
            ddlFlavour5.DataSource = dFlavour.Tables[0];
            ddlFlavour5.DataTextField = "Definition";
            ddlFlavour5.DataValueField = "CategoryUserID";
            ddlFlavour5.DataBind();
            ddlFlavour5.Items.Insert(0, "Select Category");
        }

        protected void ddlFlavour1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DflavAmt = objbs.getCakeRate(Convert.ToInt32(ddlFlavour1.SelectedValue));

            txtFalvAmount5.Text = DflavAmt.Tables[0].Rows[0]["Rate"].ToString();
            decimal dAmt = Convert.ToDecimal(DflavAmt.Tables[0].Rows[0]["Rate"].ToString());
            txtrate1.Text = dAmt.ToString("" + ratesetting + "");
            // = DflavAmt.Tables[0].Rows[0][Rate].ToString(""+ratesetting+"");

            lbltax1.Text = (DflavAmt.Tables[0].Rows[0]["GST"].ToString());

            GSTVAl();
        }

        protected void ddlFlavour2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DflavAmt = objbs.getCakeRate(Convert.ToInt32(ddlFlavour2.SelectedValue));

            txtFalvAmount2.Text = DflavAmt.Tables[0].Rows[0]["Rate"].ToString();
            decimal dAmt = Convert.ToDecimal(DflavAmt.Tables[0].Rows[0]["Rate"].ToString());
            txtrate2.Text = dAmt.ToString("" + ratesetting + "");
            lbltax2.Text = (DflavAmt.Tables[0].Rows[0]["GST"].ToString());
            GSTVAl();
        }

        protected void ddlFlavour3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DflavAmt = objbs.getCakeRate(Convert.ToInt32(ddlFlavour3.SelectedValue));

            txtFalvAmount3.Text = DflavAmt.Tables[0].Rows[0]["Rate"].ToString();
            decimal dAmt = Convert.ToDecimal(DflavAmt.Tables[0].Rows[0]["Rate"].ToString());
            txtrate3.Text = dAmt.ToString("" + ratesetting + "");
            lbltax3.Text = (DflavAmt.Tables[0].Rows[0]["GST"].ToString());
            GSTVAl();
        }

        protected void ddlFlavour4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DflavAmt = objbs.getCakeRate(Convert.ToInt32(ddlFlavour4.SelectedValue));

            txtFalvAmount4.Text = DflavAmt.Tables[0].Rows[0]["Rate"].ToString();
            decimal dAmt = Convert.ToDecimal(DflavAmt.Tables[0].Rows[0]["Rate"].ToString());
            txtrate4.Text = dAmt.ToString("" + ratesetting + "");
            lbltax4.Text = (DflavAmt.Tables[0].Rows[0]["GST"].ToString());
            GSTVAl();
        }

        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            GSTVAl();
        }

        protected void txtQty2_TextChanged(object sender, EventArgs e)
        {
            GSTVAl();
        }

        protected void txtQty3_TextChanged(object sender, EventArgs e)
        {
            GSTVAl();
        }

        protected void txtQty4_TextChanged(object sender, EventArgs e)
        {
            GSTVAl();
        }

        protected void ddlHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtDeliveryTime.Text = ddlHours.SelectedValue;
        }

        protected void ddlMinutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMeridian_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtphone_TextChanged(object sender, EventArgs e)
        {
            //////DataSet dFlavour = objbs.selectmobilecancelorder(sTableName, txtPhineNo.Text);
            //////if (dFlavour != null)
            //////{
            //////    if (dFlavour.Tables.Count > 0)
            //////    {
            //////        ddlcancelorder.DataSource = dFlavour.Tables[0];
            //////        ddlcancelorder.DataTextField = "OrderNo";
            //////        ddlcancelorder.DataValueField = "orderid";
            //////        ddlcancelorder.DataBind();
            //////        ddlcancelorder.Items.Insert(0, "Select order no.");
            //////    }
            //////}

            DataSet ds = new DataSet();
            if (txtPhineNo.Text.Length < 10)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter 10 Digits Numbers.');", true);
                return;
            }
            ds = objbs.custNAME(txtPhineNo.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustname.Text = ds.Tables[0].Rows[0]["customername"].ToString();
            }
            else
            {
                txtCustname.Text = "";
            }
        }

        protected void ddlcancelorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DDLFLAVOUR = new[] { ddlFlavour1, ddlFlavour2, ddlFlavour3, ddlFlavour4, ddlFlavour5 };
            var ddCat = new[] { ddCategory1, ddCategory1, ddCategory2, ddCategory3, ddCategory4, ddCategory5 };
            var QTY = new[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5 };
            var RATE = new[] { txtrate1, txtrate2, txtrate3, txtrate4, txtrate5 };
            var AMt = new[] { txtamount1, txtamount2, txtamount3, txtamount4, txtamount5 };
            for (int i = 0; i <= 4; i++)
            {
                if (DDLFLAVOUR[i].SelectedValue != "")
                {
                    DataSet dsGetStockID = objbs.checkPurchaseRate(Convert.ToInt32(DDLFLAVOUR[i].SelectedValue), sTableName);
                    if (dsGetStockID.Tables[0].Rows.Count > 0)
                    {
                        string sStockID = dsGetStockID.Tables[0].Rows[0]["stockID"].ToString();
                        string sDate = dsGetStockID.Tables[0].Rows[0]["ExpiryDate"].ToString();

                        //to check printing
                        // iStockSuccess = UpdateStockAvailable(Convert.ToInt32(ddCat[i].SelectedValue), Convert.ToInt32(DDLFLAVOUR[i].SelectedValue), Convert.ToDecimal(QTY[i].Text), sDate, Convert.ToString(sStockID));
                    }
                }
                // int iStockSuccess = UpdateStockAvailable(DDLFLAVOUR[i].SelectedValue, Convert.ToInt32(StockID), Convert.ToDecimal(Qty[i].Text), date, Convert.ToString(ItemID[i].Text));
            }
            string OrderNo = ddlcancelorder.SelectedItem.Text;
            if (OrderNo != null)
            {


                DataSet dBilling = objbs.getcancelBill(Convert.ToInt32(OrderNo), sTableName);
                if (dBilling.Tables[0].Rows.Count > 0)
                {

                    txtbookNo.Text = dBilling.Tables[0].Rows[0]["BookNo"].ToString();
                    txtCustname.Text = dBilling.Tables[0].Rows[0]["CustomerName"].ToString();
                    txtPhineNo.Text = dBilling.Tables[0].Rows[0]["MobileNo"].ToString();
                    txttotal.Text = dBilling.Tables[0].Rows[0]["NetAmount"].ToString();
                    txtAdvance.Text = dBilling.Tables[0].Rows[0]["Advance"].ToString();
                    txtBalance.Text = dBilling.Tables[0].Rows[0]["Total"].ToString();
                    int iCount = dBilling.Tables[0].Rows.Count;
                    txtMessege.Text = dBilling.Tables[0].Rows[0]["Messege"].ToString();
                    //txtNotes.Text = dBilling.Tables[0].Rows[0]["Notes"].ToString();
                    //  txtOrderDate.Text = dBilling.Tables[0].Rows[0]["Billdate"].ToString();
                    txtOrderDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                    txtDeliveryDate.Text = dBilling.Tables[0].Rows[0]["deliverydate"].ToString();
                    txtOrdetBy.Text = dBilling.Tables[0].Rows[0]["ordertakenby"].ToString();
                    drpPayment.SelectedValue = dBilling.Tables[0].Rows[0]["ipaymode"].ToString();
                    txtPlace.Text = dBilling.Tables[0].Rows[0]["place"].ToString();
                    // ddlHours.SelectedValue=

                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;


                    for (int i = 0; i < iCount; i++)
                    {
                        DataSet dCat = objbs.selectcategorymaster();

                        ddCat[i].DataTextField = "Category";
                        ddCat[i].DataValueField = "CategoryID";
                        ddCat[i].DataSource = dCat.Tables[0];
                        ddCat[i].DataBind();


                        DataSet dCategory = objbs.selectcategorydecription(Convert.ToInt32(dBilling.Tables[0].Rows[i]["CategoryID"].ToString()), sTableName);

                        DDLFLAVOUR[i].DataTextField = "Definition";
                        DDLFLAVOUR[i].DataValueField = "categoryuserid";
                        DDLFLAVOUR[i].DataSource = dCategory.Tables[0];
                        DDLFLAVOUR[i].DataBind();



                        QTY[i].Text = dBilling.Tables[0].Rows[i]["Qty"].ToString();

                        decimal Irate = Convert.ToDecimal(dBilling.Tables[0].Rows[i]["Rate"].ToString());
                        RATE[i].Text = Decimal.Round(Irate, 2).ToString("" + ratesetting + "");
                        Decimal ical1 = Convert.ToDecimal(QTY[i].Text) * Irate;
                        AMt[i].Text = Decimal.Round(ical1, 2).ToString("" + ratesetting + "");



                        ddCat[i].SelectedValue = dBilling.Tables[0].Rows[i]["CategoryID"].ToString().Trim();


                        DDLFLAVOUR[i].SelectedValue = dBilling.Tables[0].Rows[i]["SubCategoryID"].ToString().Trim();



                        int rowIndex = 0;


                    }



                }
            }
        }

        protected void radiomode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radiomode.SelectedValue == "Full")
            {
                txtAdvance.Text = txttotal.Text;
                txtBalance.Text = "0";
            }
            else
            {
                txtAdvance.Enabled = true;
            }
        }



        protected void txtDeliveryDtae_textChanged(object sender, EventArgs e)
        {

        }

        protected void smsSendAdvanceMessage()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("From -");
            string SMS = txtPhineNo.Text;
            string message = "Dear Customer, Thank you for booking cake with Blaack Forest!" + Convert.ToDateTime(txtOrderDate.Text).ToString("dd/MM/yyyy") + " for Rs." + Convert.ToDecimal(txtAdvance.Text).ToString("" + ratesetting + "") + " /-. Your Order no. is " + lblOrderNo.InnerText + ". www.blaackforestcakes.com";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://198.15.98.50/API/pushsms.aspx?loginID=api1&password=demo&mobile=" + SMS + "&text=" + message + "&senderid=BFCAKE&route_id=1&Unicode=0");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            ClearALL();
            //sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtsdate1.Text + ",");
            //sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");
        }

        protected void smsSendZeroAdvanceMessage()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("From -");
            string SMS = txtPhineNo.Text;
            string message = "Dear Customer, Thank you for booking cake with Blaack Forest!" + Convert.ToDateTime(txtOrderDate.Text).ToString("dd/MM/yyyy") + " for Rs." + Convert.ToDecimal(txtAdvance.Text).ToString("" + ratesetting + "") + " /-. At the time of delivery, kindly settle the full order amount.Thank You. www.blaackforestcakes.com";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://198.15.98.50/API/pushsms.aspx?loginID=api1&password=demo&mobile=" + SMS + "&text=" + message + "&senderid=BFCAKE&route_id=1&Unicode=0");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            ClearALL();
            //sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtsdate1.Text + ",");
            //sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");
        }

        protected void smsSendFullMessage()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("From -");
            string SMS = txtPhineNo.Text;
            string message = "Dear Customer, Thank you for booking cake with Blaack Forest!" + Convert.ToDateTime(txtOrderDate.Text).ToString("dd/MM/yyyy") + " for Rs." + Convert.ToDecimal(txtAdvance.Text).ToString("" + ratesetting + "") + " /-. Full Amount received against your order no. " + lblOrderNo.InnerText + ". Thank You. www.blaackforestcakes.com";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://198.15.98.50/API/pushsms.aspx?loginID=api1&password=demo&mobile=" + SMS + "&text=" + message + "&senderid=BFCAKE&route_id=1&Unicode=0");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            ClearALL();
            //sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtsdate1.Text + ",");
            //sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");
        }

        protected void smsSendDeliveredMessage()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("From -");
            string SMS = txtPhineNo.Text;
            string message = "Dear Customer, Your Order no." + lblOrderNo.InnerText + " is completed." + Convert.ToDateTime(txtDeliveryDate.Text).ToString("dd/MM/yyyy") + " for Rs." + Convert.ToDecimal(txtBalance.Text).ToString("" + ratesetting + "") + " /-. Thank You. Celebrate Your Special Day with Blaack Forest. www.blaackforestcakes.com";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://198.15.98.50/API/pushsms.aspx?loginID=api1&password=demo&mobile=" + SMS + "&text=" + message + "&senderid=BFCAKE&route_id=1&Unicode=0");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            ClearALL();
            //sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtsdate1.Text + ",");
            //sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");
        }
        protected void smsSendZeroDeliveredMessage()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("From -");
            string SMS = txtPhineNo.Text;
            string message = "Dear Customer, Your Order no." + lblOrderNo.InnerText + " is completed.Thank You for Full Payment " + Convert.ToDateTime(txtDeliveryDate.Text).ToString("dd/MM/yyyy") + " for Rs." + Convert.ToDecimal(txtBalance.Text).ToString("" + ratesetting + "") + " /-. Celebrate Your Special Day with Blaack Forest. www.blaackforestcakes.com";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://198.15.98.50/API/pushsms.aspx?loginID=api1&password=demo&mobile=" + SMS + "&text=" + message + "&senderid=BFCAKE&route_id=1&Unicode=0");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            ClearALL();
            //sb.Append("BillNO=" + txtbillno.Text + ",BillDate=" + txtsdate1.Text + ",");
            //sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");
        }
    }
}