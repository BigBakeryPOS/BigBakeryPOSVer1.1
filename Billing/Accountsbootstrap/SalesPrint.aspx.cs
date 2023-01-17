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
    public partial class SalesPrint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string StoreNo = "";
        double damt = 0;
        string Printtype = "N";
        string fssaino = "Nil";

        string Country = "Nil";

        string currency = "";
        string taxsplitupsetting = "";
        string taxsetting = "";
        string BillPrintLogo = "";
        string ratesetting = "";
        string qtysetting = "";
        string BillGenerateSetting = "";

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
            





            //// need to change after  FOR APP NOT WORKING
            //Country = Request.Cookies["userInfo"]["Country"].ToString();
            //currency = Request.Cookies["userInfo"]["Currency"].ToString();
            //taxsetting = Request.Cookies["userInfo"]["TaxSetting"].ToString();
            //taxsplitupsetting = Request.Cookies["userInfo"]["Billtaxsplitupshown"].ToString();
            //BillPrintLogo = Request.Cookies["userInfo"]["BillPrintLogo"].ToString();
            //ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            //qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            //Billgenerate = Request.Cookies["userInfo"]["BillGenerateSetting"].ToString();

            // get below parameter from database 

            DataSet fillbranchdetails = objBs.getbranchcode(sTableName);
            if (fillbranchdetails.Tables[0].Rows.Count > 0)
            {

                fssaino = fillbranchdetails.Tables[0].Rows[0]["Fssaino"].ToString();
                Printtype = fillbranchdetails.Tables[0].Rows[0]["Printtype"].ToString();
                Country = fillbranchdetails.Tables[0].Rows[0]["Country"].ToString();
                currency = fillbranchdetails.Tables[0].Rows[0]["currency"].ToString();
                taxsetting = fillbranchdetails.Tables[0].Rows[0]["TaxSetting"].ToString();
                taxsplitupsetting = fillbranchdetails.Tables[0].Rows[0]["Billtaxsplitupshown"].ToString();
                BillPrintLogo = fillbranchdetails.Tables[0].Rows[0]["BillPrintLogo"].ToString();
                ratesetting = fillbranchdetails.Tables[0].Rows[0]["Ratesetting"].ToString();
                qtysetting = fillbranchdetails.Tables[0].Rows[0]["Qtysetting"].ToString();
                BillGenerateSetting = fillbranchdetails.Tables[0].Rows[0]["BillGenerateSetting"].ToString();
                fssaino = fillbranchdetails.Tables[0].Rows[0]["Fssaino"].ToString();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Something Went Wrong in Branch MAster.Thank You!!!');", true);
                return;
            }

            //Printtype = Request.QueryString.Get("Printtype").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //fssaino = Request.QueryString.Get("fssaino").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //Country = Request.QueryString.Get("Country").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //currency = Request.QueryString.Get("currency").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //taxsetting = Request.QueryString.Get("taxsetting").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //taxsplitupsetting = Request.QueryString.Get("Billtaxsplitupshown").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //BillPrintLogo = Request.QueryString.Get("BillPrintLogo").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //ratesetting = Request.QueryString.Get("Ratesetting").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //qtysetting = Request.QueryString.Get("Qtysetting").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
            //BillGenerateSetting = Request.QueryString.Get("BillGenerateSetting").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");

            lblcurrency.Text = currency;

            DataSet GetFooter = objBs.PrintFooter();

            if (GetFooter.Tables[0].Rows.Count > 0)
            {
                txtWebSiteName.InnerText = GetFooter.Tables[0].Rows[0]["WebSite"].ToString();
                txtCustomerNo.InnerText = GetFooter.Tables[0].Rows[0]["PhoneNo"].ToString();
                txtEmail.InnerText = GetFooter.Tables[0].Rows[0]["Email"].ToString();
                txtSocial.InnerText = GetFooter.Tables[0].Rows[0]["Social"].ToString();
            }

            if (taxsetting != "I")
            {
                GridTaxvalue.Columns[3].Visible = false;
                GridTaxvalue.Columns[4].Visible = false;
                GridTaxvalue.Columns[5].Visible = true;
                PCGST.Visible = false;
                // SGST.Visible = false;
                TAXID.Visible = true;
                lblmobilename.Visible = true;
                lblmobilename1.Visible = false;
                lblgstdetails.Visible = false;
                divroundoff.Visible = false;
            }

            else
            {
                GridTaxvalue.Columns[3].Visible = true;
                GridTaxvalue.Columns[4].Visible = true;
                GridTaxvalue.Columns[5].Visible = false;
                PCGST.Visible = true;
                // SGST.Visible = true;
                TAXID.Visible = false;
                //lblmobilename.Text = "Mobile No: ";
                lblmobilename.Visible = false;
                lblmobilename1.Visible = true;
                lblgstdetails.Visible = false;
                divroundoff.Visible = true;
            }


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

            if (sTableName.ToLower() == "co8")
            {
                lblpvtltd.Visible = true;
            }
            else
            {
                lblpvtltd.Visible = false;
            }


            if (BillPrintLogo == "Y")
            {
                // Temp changes by littlespoon

                idimglog.Visible = false;
            }
            else
            {
                idimglog.Visible = false;
            }


            if (sTableName.ToLower() == "co8")
            {

                lblstore.Text = "(" + sStore + ")";
                idimglog.Visible = false;
                lblstore.Visible = true;
            }
            else
            {
                idimglog.Visible = false;
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
                // temp purpose for littlespoon

                idFranchisee.Visible = false;
                lblfranchise.Text = getfranchisee.Tables[0].Rows[0]["FranchiseeName"].ToString();
            }
            else
            {
                idFranchisee.Visible = false;
            }

            if (lblownplusfrancheese.Text == "Y")
            {

                DataSet getfranchisee1 = objBs.getfarnchiseename_new(sTableName);
                if (getfranchisee1.Tables[0].Rows.Count > 0)
                {
                    // temp purpose for littlespoon
                    idFranchisee.Visible = false;
                    lblfranchise.Text = getfranchisee1.Tables[0].Rows[0]["FranchiseeName"].ToString();
                }
                else
                {
                    idFranchisee.Visible = false;
                }
            }



            int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
            string type = (Request.QueryString.Get("Type")).ToString();
            int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string sMode = Request.QueryString.Get("Mode");

            lblfssaino.Text = fssaino.ToString();

            DataSet dsLogin = objBs.LoginImage(sTableName);

            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                log.ImageUrl = dsLogin.Tables[0].Rows[0]["Imagepath"].ToString();
            }

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

            if (lblqtyneeded.Text == "Y")
            {
                divqtyneeded.Visible = true;
            }
            else
            {
                divqtyneeded.Visible = false;
            }

            if (lblPCGST.Text == "Y")
            {
                PCGST.Visible = true;
                Tr2.Visible = false;
            }
            else
            {
                PCGST.Visible = false;
                Tr2.Visible = true;
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
                        lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        lblgstno.Text = ds.Tables[0].Rows[0]["Gstno"].ToString();
                        lbladdress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                        if (lbladdress.Text == "")
                        {
                            traddress.Visible = false;
                        }
                        else
                        {
                            traddress.Visible = true;
                        }
                    }

                    if (BillGenerateSetting == "1")
                    {

                        lblbillno.Text = ds.Tables[0].Rows[0]["FullBill"].ToString();
                        lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    }
                    else if (BillGenerateSetting == "2")
                    {
                        lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    }
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"].ToString());
                    if (lblwithtime.Text == "Y")
                    {
                        lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                    }
                    else
                    {
                        lbldate.Text = date.ToString("dd/MM/yyyy");
                    }

                    if (lblpaymodeshown.Text == "Y")
                    {
                        lblpaymodebill.Visible = true;
                    }
                    else
                    {
                        lblpaymodebill.Visible = false;
                    }

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
                    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString());
                    lbltotal.Text = dTotal.ToString("" + ratesetting + "");
                    lblTax.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Tax"]).ToString("" + ratesetting + "");
                    lblsubttl.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"]).ToString("" + ratesetting + "");

                    if (ds.Tables[0].Rows[0]["Discount"].ToString() != "0.0000")
                    {
                        iddiscamt.Visible = true;
                        // decimal amt = (Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"].ToString()) * Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString()) / 100);
                        decimal amt = (Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"].ToString()));
                        lbldiscountamt.Text = amt.ToString("" + ratesetting + "");

                        lblsubttl.Text = (Convert.ToDecimal(lblsubttl.Text)).ToString("" + ratesetting + "");
                    }
                    else
                    {
                        iddiscamt.Visible = false;
                    }

                    lblGrand.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");

                    /////////////////////////Rajaram //////////////////////////////////

                    double RTax = Convert.ToDouble(ds.Tables[0].Rows[0]["Tax"]);
                    double RSub = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
                    double TRound = RTax + RSub;
                    double roundoff1 = Convert.ToDouble(TRound) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                    /////////////////////////////////////////////////////////////////////////

                    double n = 0;
                    // double roundoff = Convert.ToDouble(lblGrand.Text) - Math.Floor(Convert.ToDouble(lblGrand.Text));





                    //if (roundoff1 >= 0.5)
                    //{
                    //    n = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                    //}
                    //else
                    //{
                    //    n = Math.Floor(Convert.ToDouble(lblGrand.Text));
                    //}

                    //lblGrand.Text = string.Format("{0:N2}", n);

                    lblcgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]).ToString("" + ratesetting + "");
                    lblsgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]).ToString("" + ratesetting + "");

                    lblTotalTax.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Tax"]).ToString("" + ratesetting + "");

                    lblRound.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["roundoff"]).ToString("" + ratesetting + "");



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

                    staxdetails.Visible = false;
                    DataSet Itembinding = objBs.PrintingSalesNew(iD, sTableName, sMode, type.ToString());
                    if (Itembinding.Tables[0].Rows.Count > 0)
                    {


                        staxdetails.Visible = true;
                        gvPrint.DataSource = Itembinding;
                        gvPrint.DataBind();
                        int cntt = gvPrint.Rows.Count;
                        

                        Label4.Text = cntt.ToString("0");


                       


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

                            dct = new DataColumn("Tax");
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

                            dct1 = new DataColumn("Tax");
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

                                /////////////////////////Rajaram //////////////////////////////////


                                double TRound1 = taxx + itemvaluee;

                                double roundoff2 = Convert.ToDouble(TRound1) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                                /////////////////////////////////////////////////////////////////////////

                                if (roundoff2 >= 0.5)
                                {
                                    toto = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    toto = Math.Floor(Convert.ToDouble(lblGrand.Text));
                                }

                                drNew["value"] = itemvalu.ToString("0.00");
                                if (province == "1")
                                {
                                    double gst = taxx / 2;
                                    drNew["Cgst"] = gst.ToString("0.00");
                                    drNew["Sgst"] = gst.ToString("0.00");
                                    drNew["Tax"] = taxx.ToString("0.00");
                                    // drNew["Igst"] = "0";
                                }
                                else
                                {
                                    drNew["Cgst"] = "0";
                                    drNew["Sgst"] = "0";
                                    drNew["Tax"] = "0";
                                    //   drNew["Igst"] = taxx.ToString("0.00");
                                }
                                drNew["Total"] = toto.ToString("0.00");
                                dstd.Tables[0].Rows.Add(drNew);
                            }



                            var result = from r in dstd.Tables[0].AsEnumerable()
                                         group r by new { taxvalue = r["taxvalue"], hsncode = r["hsncode"], Total = r["Total"] } into g
                                         select new
                                         {
                                             taxvalue = g.Key.taxvalue,
                                             hsncode = g.Key.hsncode,
                                             value = g.Sum(x => Convert.ToDouble(x["value"])),
                                             Cgst = g.Sum(x => Convert.ToDouble(x["Cgst"])),
                                             Sgst = g.Sum(x => Convert.ToDouble(x["Sgst"])),
                                             Tax = g.Sum(x => Convert.ToDouble(x["Tax"])),
                                             // Total = g.Sum(x => Convert.ToDouble(x["Total"])),
                                             Total = g.Key.Total,
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
                                drNew1["Tax"] = g.Tax;
                                drNew1["Total"] = g.Total;
                                //  drNew1["IGST"] = g.Igst;
                                dstd1.Tables[0].Rows.Add(drNew1);
                            }



                            GridTaxvalue.DataSource = dstd1;
                            GridTaxvalue.DataBind();

                        }

                        #endregion


                    }


                    if (taxsplitupsetting == "Y")
                    {
                        staxdetails.Visible = true;
                    }
                    else
                    {
                        staxdetails.Visible = false;
                    }

                    string saletypeid = ds.Tables[0].Rows[0]["salestype"].ToString();
                    if (saletypeid == "3" || saletypeid == "4")
                    {
                        gvPrint.Columns[3].Visible = false;
                        gvPrint.Columns[5].Visible = false;
                        PCGST.Visible = false;
                        divsubtotal.Visible = false;
                        divroundoff.Visible = false;
                        staxdetails.Visible = false;
                        SGST1.Visible = false;
                    }

                    if (Printtype == "Y")
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

                // NEED TO SAVE AND FETCH VALUE FROM SALES 12.01.2023

                //string KOTPrint = Request.QueryString.Get("KOTPrint");
                //if (KOTPrint != null)
                //{
                //    KOTPrint = Request.QueryString.Get("KOTPrint").ToString().Replace("_Space_", " ").Replace("_Comma_", ",");
                //    if (KOTPrint == "True")
                //    {
                //        DataSet ds1 = objBs.PrintingSalesLiveKitchen1(iD, sTableName, type.ToString());
                //        if (ds1.Tables[0].Rows.Count > 0)
                //        {

                //            string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + iD + "&type=" + type.ToString() + "&Store=" + sStore;

                //            //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                //            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                //        }
                //    }
                //}

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
                        lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    }
                    lblbillno.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderdate"].ToString());
                    lbldate.Text = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
                    //     billedby.Text = ds.Tables[0].Rows[0]["Biller"].ToString();
                    //atender.Text = ds.Tables[0].Rows[0]["Attender"].ToString();
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
                    //     lblstorenew.Text = sStore;
                    //  lblstore.Text = sStore;
                    lblstoreno.Text = StoreNo;

                    lblAddres.Text = sAddress;
                    lbltin.Text = sTin;
                    decimal dTotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["gndtot"].ToString());
                    lblGrand.Text = dTotal.ToString("" + ratesetting + "");


                    double n = 0;
                    //double roundoff = Convert.ToDouble(lblGrand.Text) - Math.Floor(Convert.ToDouble(lblGrand.Text));
                    //if (roundoff >= 0.5)
                    //{
                    //    n = Math.Round(Convert.ToDouble(lblGrand.Text), MidpointRounding.AwayFromZero);
                    //}
                    //else
                    //{
                    //    n = Math.Floor(Convert.ToDouble(lblGrand.Text));
                    //}

                    //lblGrand.Text = string.Format("{0:N2}", n);
                    //lblRound.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["roundoff"]).ToString("" + ratesetting + "");
                    lblRound.Text = Convert.ToString(0);
                    lblcgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]).ToString("" + ratesetting + "");
                    lblsgst.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]).ToString("" + ratesetting + "");
                    lblTotalTax.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["Tax"]).ToString("" + ratesetting + "");
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
                    gvPrint.DataSource = ds;
                    gvPrint.DataBind();


                    //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
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

                    if (Printtype == "Y")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                    }
                }

            }

            if (sMode == "Sales")
            {
                DataSet ds = objBs.PrintingSalesLiveKitchen(iD, sTableName, "Sales", type.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string yourUrl1 = "SalesLiveKitchenPrint.aspx?Mode=Sales&iSalesID=" + iD + "&type=" + type.ToString() + "&Store=" + sStore;

                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);

                }
            }
        }
        //foreach (GridViewRow row in GridTaxvalue.Rows)
        //   {
        //       row.Cells[3].Visible = false;
        //       row.Cells[4].Visible = false;
        //   }

        protected void GridTaxvalue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //foreach (GridViewRow row in GridTaxvalue.Rows)
            //{

            //    row.Cells[3].Visible = false;
            //    row.Cells[4].Visible = false;
            //}
        }
        protected void gvPrint_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            double qty = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblQuantity = ((Label)e.Row.FindControl("lblQuantity"));
                Label lblAmount = ((Label)e.Row.FindControl("lblAmount"));
                Label lblrate = ((Label)e.Row.FindControl("lblrate"));

                lblAmount.Text = Convert.ToDouble(lblAmount.Text).ToString("" + ratesetting + "");
                lblrate.Text = Convert.ToDouble(lblrate.Text).ToString("" + ratesetting + "");
                lblQuantity.Text = Convert.ToDouble(lblQuantity.Text).ToString("" + qtysetting + "");


                qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                damt = damt + qty;


            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Qty: ";
                e.Row.Cells[1].Text = damt.ToString("" + qtysetting + "");
                Label1.Text = damt.ToString("" + qtysetting + "");

            }



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    // int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);

                    string id = (gvGroup.DataKeys[e.Row.RowIndex].Values[0]).ToString();
                    string branchcodee = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    string salesno = gvGroup.DataKeys[e.Row.RowIndex].Values[2].ToString();
                    if (id == "C")
                    {
                        DataSet ds = objBs.PrintingNEWSalesNew(id, branchcodee, salesno, sTableName);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gv.DataSource = ds;
                            gv.DataBind();
                        }
                    }
                    else if (id == "H")
                    {

                    }

                }

            }


        }


    }
}