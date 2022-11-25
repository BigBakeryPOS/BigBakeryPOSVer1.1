using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using DataLayer;
using System.Xml.Linq;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
namespace Billing.Accountsbootstrap
{
    public partial class SalesPrintType2 : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string sfssaino = "";
        string StoreNo = "";
        string State = "";
        string StateNo = "";
        double damt = 0;
        double totq = 0;

        string currency = "";
        string taxsplitupsetting = "";
        string taxsetting = "";
        string BillPrintLogo = "";
        string ratesetting = "";
        string qtysetting = "";
        string Billgenerate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //    lblUserID.Text = Session["UserID"].ToString();
            //    sTableName = Session["User"].ToString();
            //    sStore = Session["Store"].ToString();
            //    sAddress = Session["Address"].ToString();
            //    StoreNo = Session["StoreNo"].ToString();

            //    sTin = Session["TIN"].ToString();


            sTableName = Request.QueryString.Get("User").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sStore = Request.QueryString.Get("Store").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sAddress = Request.QueryString.Get("Address").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            StoreNo = Request.QueryString.Get("StoreNo").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sTin = Request.QueryString.Get("TIN").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            sfssaino = Request.QueryString.Get("fssaino").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");

            State = "TN" ;
            StateNo = "33";

            // need to change after  FOR APP NOT WORKING
            currency = Request.Cookies["userInfo"]["Currency"].ToString();
            taxsetting = Request.Cookies["userInfo"]["TaxSetting"].ToString();
            taxsplitupsetting = Request.Cookies["userInfo"]["Billtaxsplitupshown"].ToString();
            BillPrintLogo = Request.Cookies["userInfo"]["BillPrintLogo"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            Billgenerate = Request.Cookies["userInfo"]["BillGenerateSetting"].ToString();

            if (sTableName.ToLower() == "co6" || sTableName.ToLower() == "co7")
            {
                //tax.Visible = true;
                //total.Visible = true;

                tax.Visible = false;
                total.Visible = false;
            }

            else
            {
                tax.Visible = false;
                total.Visible = false;
            }

            //if(sTableName.ToLower()== "co8")
            //{
            //    lblpvtltd.Visible = true;
            //}
            //else
            //{
            //    lblpvtltd.Visible = false;
            //}



            if (sTableName.ToLower() == "co8")
            {

                lblstore.Text = "(" + sStore + ")";
                // idimglog.Visible = false;
                lblstore.Visible = true;
            }
            else
            {
                //  idimglog.Visible = true;
                lblstore.Text = sStore;
                lblstore.Visible = true;
            }

            if (sTableName.ToLower() == "co11")
            {
                home.Visible = true;
            }
            else
            {
                home.Visible = false;
            }

            if (sTableName.ToLower() == "co10")
            {

                lblstore.Text = sStore;
                // idimglog.Visible = false;
                lblstore.Visible = true;

                idFranchisee.Visible = true;
            }
            else
            {
                // idimglog.Visible = true;
                lblstore.Text = sStore;
                lblstore.Visible = true;

                idFranchisee.Visible = false;
            }

            DataSet getfranchisee = objBs.getfarnchiseename(sTableName);
            if (getfranchisee.Tables[0].Rows.Count > 0)
            {
                idFranchisee.Visible = true;
                lblfranchise.Text = getfranchisee.Tables[0].Rows[0]["FranchiseeName"].ToString();
            }
            else
            {
                idFranchisee.Visible = false;
            }

            DataSet dsLogin = objBs.LoginImage(sTableName);

            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                log.ImageUrl = dsLogin.Tables[0].Rows[0]["Imagepath"].ToString();
            }

            int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
            string type = (Request.QueryString.Get("Type")).ToString();
            int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string sMode = Request.QueryString.Get("Mode");
            lblStatecode.Text = State.ToString();
            lblstateno.Text = StateNo.ToString();

            if (sMode == "Order")
            {
                lblbillname.Text = "Invoice No";
                lblsalestype.Text = "Cake Order";
                // lblorderno.Visible = true;
                paydetails.Visible = true;
                DataSet getpaiddetails = objBs.getpaidorderdetails(Convert.ToInt32(NewiD), sTableName);
                if (getpaiddetails.Tables[0].Rows.Count > 0)
                {
                    lblbookno.Text = getpaiddetails.Tables[0].Rows[0]["Bookno"].ToString();
                    // lblorderno.Text = getpaiddetails.Tables[0].Rows[0]["Bookno"].ToString();
                    Gridpaymentdetails.DataSource = getpaiddetails;
                    Gridpaymentdetails.DataBind();
                }
                else
                {
                    Gridpaymentdetails.DataSource = null;
                    Gridpaymentdetails.DataBind();
                }
            }
            else
            {
                paydetails.Visible = false;
            }

            if (iD > 0)
            {
                DataSet ds = new DataSet();

                ds = objBs.PrintingSales(iD, sTableName, sMode, type.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblsalestype.Text = ds.Tables[0].Rows[0]["paymenttype"].ToString();

                    string isnormel = ds.Tables[0].Rows[0]["isnormal"].ToString();

                    if (isnormel == "Y")
                    {
                        lblbillname.Text = "Bill No";
                        lblorderno.Visible = false;
                    }
                    else
                    {
                        lblbillname.Text = "Kot No";
                        lblorderno.Visible = true;
                        lblorderno.Text = ds.Tables[0].Rows[0]["SalesOrder"].ToString();

                    }

                    if (ds.Tables[0].Rows[0]["ipaymode"].ToString() != "1" || ds.Tables[0].Rows[0]["ipaymode"].ToString() != "4")
                    {
                        lblcustname.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        // lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    }
                   // lblgstno.Text = ds.Tables[0].Rows[0]["gstno"].ToString();
                    //lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    if (Billgenerate == "1")
                    {

                        lblbillno.Text = ds.Tables[0].Rows[0]["FullBill"].ToString();
                    }
                    else if (Billgenerate == "2")
                    {
                        lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    }
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                    lbldate.Text = date.ToString("dd/MM/yyyy   hh:mm tt");
                    lblpaymenttype.Text = ds.Tables[0].Rows[0]["paymode"].ToString();

                    billedby.Text = ds.Tables[0].Rows[0]["Biller"].ToString();
                    atender.Text = ds.Tables[0].Rows[0]["Attender"].ToString();
                    decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lblAmount.Text = dAmt.ToString("" + ratesetting + "");
                    decimal dAvance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Advance"].ToString());
                    //string pay = ds.Tables[0].Rows[0]["ipaymode"].ToString();
                    //if (pay == "4")
                    //{
                    //    paymode1.Text = "Card";
                    //}
                    //else
                    //{
                    //    paymode1.Text = "Cash";
                    //}
                    if (sMode == "Order")
                    {
                        tradv.Visible = true;
                        lbladvance.Text = dAvance.ToString("" + ratesetting + "");
                        trCash.Visible = false;
                        trPaid.Visible = false;
                    }

                    if (sMode == "Sales")
                    {
                        DataSet adattender = objBs.GetAttender_name(iD, sTableName, sMode, type.ToString());
                        if (adattender.Tables[0].Rows.Count > 0)
                        {
                            lblattender.Text = adattender.Tables[0].Rows[0]["Aname"].ToString();
                        }
                    }

                    //    lblstorenew.Text = sStore;
                    //  lblstore.Text = sStore;
                    lblstoreno.Text = StoreNo;

                    lblAddres.Text = sAddress;
                    lbltin.Text = sTin;
                    lblfssaino.Text = sfssaino;
                    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lbltotal.Text = dTotal.ToString("f2");
                    lblTax.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Tax"]).ToString("" + ratesetting + "");
                    lblsubttl.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"]).ToString("" + ratesetting + "");

                    if (ds.Tables[0].Rows[0]["Discount"].ToString() != "0.0000")
                    {
                        iddiscamt.Visible = true;
                        // decimal amt = (Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString()) / 100);
                        decimal amt = (Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString()));
                        lbldiscountamt.Text = amt.ToString("f2");

                        lblsubttl.Text = (Convert.ToDecimal(lblsubttl.Text)).ToString("" + ratesetting + "");
                    }
                    else
                    {
                        iddiscamt.Visible = false;
                    }

                    lblGrand.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");

                    double n = 0;
                    double roundoff = Convert.ToDouble(lblGrand.Text) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                    if (roundoff >= 0.5)
                    {
                        n = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        n = Math.Floor(Convert.ToDouble(lblGrand.Text));
                    }

                    lblGrand.Text = string.Format("{0:N2}", n);

                    lblcgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]).ToString("" + ratesetting + "");
                    lblsgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]).ToString("" + ratesetting + "");



                    if (ds.Tables[0].Rows[0]["CashPaid"].ToString() != "")
                    {
                        decimal dRev = Convert.ToDecimal(ds.Tables[0].Rows[0]["CashPaid"].ToString());

                        lblReceived.Text = dRev.ToString("" + ratesetting + "");
                    }
                    if (ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                    {
                        decimal dBal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());

                        lblBal.Text = dBal.ToString("" + ratesetting + "");
                    }

                    DataTable dt = new DataTable();
                    DataColumn dc;

                    dc = new DataColumn();
                    dc.ColumnName = "col1";
                    dt.Columns.Add(dc);
                    dc = new DataColumn();
                    dc.ColumnName = "col2";
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "col3";
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "col4";
                    dt.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "col5";
                    dt.Columns.Add(dc);

                    double totqty = 0;

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            Label1.Text = ds.Tables[0].Rows.Count.ToString();
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr;
                                dr = dt.NewRow();
                                //  string string1 = "Rose" + new string(' ', 10);
                                string hsncode = ds.Tables[0].Rows[i]["hsncode"].ToString() + new string(' ', 30) + ds.Tables[0].Rows[i]["Definition"].ToString();
                                //string Definition = ds.Tables[0].Rows[i]["Definition"].ToString();
                                dr["col1"] = hsncode;
                                dr["col2"] = ds.Tables[0].Rows[i]["subcategoryid"].ToString();
                                //dr["col2"] = ds.Tables[0].Rows[i]["Definition"].ToString();
                                dt.Rows.Add(dr);

                                // dr = dt.NewRow();
                                // string[] arg = ds.Tables[0].Rows[i]["PackingUnitText"].ToString().Split('-');
                                // string units = arg[0].ToString();
                                // string uom = arg[1].ToString();

                                // string GetQty = ds.Tables[0].Rows[i]["Quantity"].ToString();
                                // string uomname = ds.Tables[0].Rows[i]["Uomname"].ToString();

                                // //dr["col2"] = ;
                                // System.Text.StringBuilder sb = new System.Text.StringBuilder();

                                // //Response.Write(sb.ToString());
                                // decimal qty = Convert.ToDecimal(units) * Convert.ToDecimal(GetQty);
                                // totqty = totqty + Convert.ToDouble(qty);
                                // string col3 = ds.Tables[0].Rows[i]["gst"].ToString();

                                // //sb.Append(qty.ToString());
                                // //sb.Append("".PadLeft(5, ' ').Replace(" ", &nbsp));
                                // //sb.Append(uom);
                                // //sb.Append("".PadLeft(5, ' ').Replace(" ", " "));
                                // //sb.Append(col3);
                                // dr["col1"] = Convert.ToDecimal(qty).ToString("0.00") + new string(' ', 10) + uomname + new string(' ', 10) + col3.ToString();
                                //// dr["col1"] = sb.ToString();
                                // //string col2 = ds.Tables[0].Rows[i]["Quantity"].ToString();
                                // //dr["col2"] = col3.ToString();
                                // //dr["col2"] = qty;

                                // //dr["col2"] = col3;

                                // string col4 = ds.Tables[0].Rows[i]["RATE1"].ToString();
                                // dr["col2"] = Convert.ToDecimal(col4).ToString("0.00");
                                // string col5 = ds.Tables[0].Rows[i]["Amount"].ToString();
                                // decimal tottax = (Convert.ToDecimal(col5) * Convert.ToDecimal(col3)) / 100;
                                // dr["col3"] = (Convert.ToDecimal(col5) + tottax).ToString("0.00");
                                // dt.Rows.Add(dr);


                            }
                        }
                    }



                    
                    gvPrint.Visible = true;
                    gvprint_ORder.Visible = false;
                    gvPrint.DataSource = dt;
                    gvPrint.DataBind();

                    lblamtinwords.InnerText = objBs.changeToWords( Convert.ToDouble(lblGrand.Text).ToString(), true);
                    #region GROUP WISE GST
                    DataSet dgetdetailed = objBs.gettaxdetailedgrid(iD.ToString(), sTableName, type.ToString());
                    if (dgetdetailed.Tables[0].Rows.Count > 0)
                    {

                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;
                        DataSet dstd = new DataSet();
                        dttt = new DataTable();

                        dct = new DataColumn("taxvalue");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("hsncode");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("value");
                        dttt.Columns.Add(dct);


                        //dct = new DataColumn("province");
                        //dttt.Columns.Add(dct);

                        dct = new DataColumn("disc");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Cgst");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Sgst");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Total");
                        dttt.Columns.Add(dct);

                        //dct = new DataColumn("Igst");
                        //dttt.Columns.Add(dct);



                        dstd.Tables.Add(dttt);

                        DataTable dttt1;
                        DataRow drNew1;
                        DataColumn dct1;
                        DataSet dstd1 = new DataSet();
                        dttt1 = new DataTable();

                        dct1 = new DataColumn("taxvalue");
                        dttt1.Columns.Add(dct1);

                        dct1 = new DataColumn("hsncode");
                        dttt1.Columns.Add(dct1);

                        dct1 = new DataColumn("value");
                        dttt1.Columns.Add(dct1);

                        dct1 = new DataColumn("Cgst");
                        dttt1.Columns.Add(dct1);

                        dct1 = new DataColumn("Sgst");
                        dttt1.Columns.Add(dct1);

                        dct1 = new DataColumn("Total");
                        dttt1.Columns.Add(dct1);

                        //dct1 = new DataColumn("Igst");
                        //dttt1.Columns.Add(dct1);



                        dstd1.Tables.Add(dttt1);

                        foreach (DataRow dr in dgetdetailed.Tables[0].Rows)
                        {


                            drNew = dttt.NewRow();
                            drNew["taxvalue"] = dr["taxtype"];
                            //drNew["hsncode"] = dr["hsncode"];
                            drNew["hsncode"] = "0";
                            //  drNew["province"] = dr["province"];
                            drNew["disc"] = dr["disc"];
                            string province = "1";
                            double itemvaluee = Convert.ToDouble(dr["itemvalue"]);
                            double taxtype = Convert.ToDouble(dr["taxtype"]);
                            double discc = Convert.ToDouble(dr["disc"]);

                            //double getdiscount = (itemvaluee * discc) / 100;
                            double getdiscount = (discc);
                            double itemvalu = itemvaluee - getdiscount;

                            double taxx = (itemvalu * taxtype) / 100;

                            double toto = itemvalu + taxx;

                            drNew["value"] = itemvalu.ToString("" + ratesetting + "");
                            if (province == "1")
                            {
                                double gst = taxx / 2;
                                drNew["Cgst"] = gst.ToString("" + ratesetting + "");
                                drNew["Sgst"] = gst.ToString("" + ratesetting + "");
                                // drNew["Igst"] = "0";
                            }
                            else
                            {
                                drNew["Cgst"] = "0";
                                drNew["Sgst"] = "0";
                                //   drNew["Igst"] = taxx.ToString("0.00");
                            }
                            drNew["Total"] = toto.ToString("" + ratesetting + "");
                            dstd.Tables[0].Rows.Add(drNew);
                        }



                        var result = from r in dstd.Tables[0].AsEnumerable()
                                     group r by new { taxvalue = r["taxvalue"], hsncode = r["hsncode"] } into g
                                     select new
                                     {
                                         taxvalue = g.Key.taxvalue,
                                         hsncode = g.Key.hsncode,
                                         value = g.Sum(x => Convert.ToDouble(x["value"])),
                                         Cgst = g.Sum(x => Convert.ToDouble(x["Cgst"])),
                                         Sgst = g.Sum(x => Convert.ToDouble(x["Sgst"])),
                                         Total = g.Sum(x => Convert.ToDouble(x["Total"])),
                                         //  Igst = g.Sum(x => Convert.ToDouble(x["Igst"]))
                                     };

                        foreach (var g in result)
                        {
                            drNew1 = dttt1.NewRow();
                            drNew1["taxvalue"] = g.taxvalue;
                            drNew1["hsncode"] = g.hsncode;
                            drNew1["value"] = g.value;
                            drNew1["CGST"] = g.Cgst;
                            drNew1["SGST"] = g.Sgst;
                            drNew1["Total"] = g.Total;
                            //  drNew1["IGST"] = g.Igst;
                            dstd1.Tables[0].Rows.Add(drNew1);
                        }

                        GridTaxvalue.DataSource = dstd1;
                        GridTaxvalue.DataBind();

                    }

                    #endregion


                    if (lblautomastic.Text == "Y")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                    }
                    //PrintDocument doc = new PrintDocument();
                    ////doc.PrintPage += this.Doc_PrintPage;
                    //doc.Print();
                    //try
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "PrintPanel", "PrintPanel();", true);
                    //}
                    //catch
                    //{

                    //}
                }

                //Session["ctrl"] = pnlContents;
                //Control ctrl = (Control)Session["ctrl"];
                //PrintWebControl(ctrl);

                string KOTPrint = Request.QueryString.Get("KOTPrint");
                if (KOTPrint != null)
                {
                    KOTPrint = Request.QueryString.Get("KOTPrint").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
                    if (KOTPrint == "True")
                    {
                        DataSet ds1 = objBs.PrintingSalesLiveKitchen1(iD, sTableName, type.ToString());
                        if (ds1.Tables[0].Rows.Count > 0)
                        {

                            string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + iD + "&type=" + type.ToString() + "&Store=" + sStore;

                            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                        }
                    }
                }

            }

            else
            {
                if (sTableName.ToLower() == "co6" || sTableName.ToLower() == "co7")
                {
                    tax.Visible = false;
                    total.Visible = false;
                }
                DataSet ds = new DataSet();

                ds = objBs.PrintingOrderSales(NewiD, sTableName, sMode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ipaymode"].ToString() != "1" || ds.Tables[0].Rows[0]["ipaymode"].ToString() != "4")
                    {
                        lblcustname.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        //lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    }
                    lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderdate"].ToString());
                    lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
                    //     billedby.Text = ds.Tables[0].Rows[0]["Biller"].ToString();
                    //atender.Text = ds.Tables[0].Rows[0]["Attender"].ToString();
                    decimal dAmt = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lblAmount.Text = dAmt.ToString("f2");
                    decimal dAvance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Advance"].ToString());
                    //string pay = ds.Tables[0].Rows[0]["ipaymode"].ToString();
                    //if (pay == "4")
                    //{
                    //    paymode1.Text = "Card";
                    //}
                    //else
                    //{
                    //    paymode1.Text = "Cash";
                    //}
                    if (sMode == "Order")
                    {
                        tradv.Visible = true;
                        lbladvance.Text = dAvance.ToString("" + ratesetting + "");
                        trCash.Visible = false;
                        trPaid.Visible = false;
                    }
                    //     lblstorenew.Text = sStore;
                    //  lblstore.Text = sStore;
                    lblstoreno.Text = StoreNo;

                    lblAddres.Text = sAddress;
                    lbltin.Text = sTin;
                    lblfssaino.Text = sfssaino;
                    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["gndtot"].ToString());
                    lblGrand.Text = dTotal.ToString("" + ratesetting + "");


                    double n = 0;
                    double roundoff = Convert.ToDouble(lblGrand.Text) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                    if (roundoff >= 0.5)
                    {
                        n = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        n = Math.Floor(Convert.ToDouble(lblGrand.Text));
                    }

                    lblGrand.Text = string.Format("{0:N2}", n);

                    lblcgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]).ToString("" + ratesetting + "");
                    lblsgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]).ToString("" + ratesetting + "");
                    lblsubttl.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["STotal"]).ToString("" + ratesetting + "");
                    //if (ds.Tables[0].Rows[0]["CashPaid"].ToString() != "")
                    //{
                    //    decimal dRev = Convert.ToDecimal(ds.Tables[0].Rows[0]["CashPaid"].ToString());

                    //    lblReceived.Text = dRev.ToString("f2");
                    //}
                    //if (ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                    //{
                    //    decimal dBal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());

                    //    lblBal.Text = dBal.ToString("f2");
                    //}

                    gvPrint.Visible = false;
                    gvprint_ORder.Visible = true;
                    gvprint_ORder.DataSource = ds;
                    gvprint_ORder.DataBind();

                    if (lblautomastic.Text == "Y")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                    }
                    //PrintDocument doc = new PrintDocument();
                    ////doc.PrintPage += this.Doc_PrintPage;
                    //doc.Print();
                    //try
                    //{
                    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "PrintPanel", "PrintPanel();", true);
                    //}
                    //catch
                    //{

                    //}
                }

            }
        }



        protected void gvPrint_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


           


            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double qty = 0;

                DataTable dt = new DataTable();
                DataColumn dc;

                dc = new DataColumn();
                dc.ColumnName = "col1";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "col2";
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "col3";
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "col4";
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "col5";
                dt.Columns.Add(dc);

                double totqty = 0;

                int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
                string type = (Request.QueryString.Get("Type")).ToString();
                int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
                string sMode = Request.QueryString.Get("Mode");
                double Tax = 0;
                double NetAmount = 0;

             //   Tax = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
            //    NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

              //  GTax = GTax + Tax;
              //  GNetAmount = GNetAmount + NetAmount;

                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Values[0]);
                   
                    DataSet ds = objBs.PrintingSales_Subgrid(iD, sTableName, sMode, type.ToString(),groupID.ToString());
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //gv.DataSource = ds;
                        //gv.DataBind();

                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                             //   Label1.Text = ds.Tables[0].Rows.Count.ToString();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    DataRow dr;
                                    //dr = dt.NewRow();
                                    ////  string string1 = "Rose" + new string(' ', 10);
                                    //string hsncode = ds.Tables[0].Rows[i]["hsncode"].ToString() + new string(' ', 30) + ds.Tables[0].Rows[i]["Definition"].ToString();
                                    ////string Definition = ds.Tables[0].Rows[i]["Definition"].ToString();
                                    //dr["col1"] = hsncode;
                                    ////dr["col2"] = ds.Tables[0].Rows[i]["Definition"].ToString();
                                    //dt.Rows.Add(dr);

                                    dr = dt.NewRow();
                                   // string[] arg = ds.Tables[0].Rows[i]["PackingUnitText"].ToString().Split('-');
                                  //  string units = arg[0].ToString();
                                   // string uom = arg[1].ToString();

                                    string GetQty = ds.Tables[0].Rows[i]["Quantity"].ToString();
                                    string uomname = ds.Tables[0].Rows[i]["Muom"].ToString();

                                    //dr["col2"] = ;
                                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                                    //Response.Write(sb.ToString());
                                    //decimal qty1 = Convert.ToDecimal(units) * Convert.ToDecimal(GetQty);

                                    decimal qty1 =   Convert.ToDecimal(GetQty);
                                    
                                    totq = totq + Convert.ToDouble(qty1);
                                    dr["col1"] = Convert.ToDecimal(qty1).ToString("" + qtysetting + "");
                                    totqty = totqty + Convert.ToDouble(qty1);
                                    dr["col2"] = uomname;
                                    string col3 = ds.Tables[0].Rows[i]["gst"].ToString();
                                    dr["col3"] = col3;

                                    string col4 = "";
                                    if (ds.Tables[0].Rows[i]["mrp"].ToString() == "")
                                    {
                                          col4 = "0";
                                    }
                                    else
                                    {
                                          col4 = ds.Tables[0].Rows[i]["mrp"].ToString();
                                    }
                                    dr["col4"] = Convert.ToDecimal(col4).ToString("" + ratesetting + "");
                                    string col5 = ds.Tables[0].Rows[i]["Amount"].ToString();
                                    decimal tottax = (Convert.ToDecimal(col5) * Convert.ToDecimal(col3)) / 100;
                                   // dr["col5"] = (Convert.ToDecimal(col5) + tottax).ToString("0.00");
                                    decimal Grand1 = 0;
                                    string TOTGrand1 = "0";
                                    {


                                        Grand1 = (Convert.ToDecimal(col5) + tottax);
                                    }

                                    //lblGrandTotal.Text = (Grand1).ToString("0.00");
                                    decimal grandtot = Grand1;
                                    Grand1 = Math.Round(grandtot, 0);
                                    if (grandtot > Grand1)
                                    {
                                        TOTGrand1 = (grandtot - Grand1).ToString("" + ratesetting + "");
                                    }
                                    else
                                    {
                                        TOTGrand1 = (Grand1 - grandtot).ToString("" + ratesetting + "");
                                    }
                                    dr["col5"] = Grand1.ToString("" + ratesetting + "");
                                    dt.Rows.Add(dr);


                                }
                            }
                        }
                        gv.DataSource = dt;
                        gv.DataBind();

                    }
                }
                Label7.Text = totq.ToString("" + qtysetting + "");

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Text = "Total Qty: ";
                //e.Row.Cells[1].Text = damt.ToString();
                //Label1.Text = damt.ToString();

            }
        }




    }
}