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
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class InvoicePrint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();

        double dtotalamt = 0; string state = "";

        double UnitPrice = 0; double TaxAmount = 0;
        double taxcgst18 = 0; double taxcgst28 = 0;
        string cgst18 = ""; string cgst28 = "";
        double Amount = 0;
        double SubTotal = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string iInvoiceID = Request.QueryString.Get("InvoiceID");
                if (iInvoiceID != null)
                {
                    DataSet dsOrders = null;
                   
                    //if (hdPickup.Value == "on")
                    //{
                    //    dsOrders = objBs.GetOrder_fullPickupon(Convert.ToInt32(iInvoiceID));
                    //}
                    //else
                    //{
                    /////nov
                    //dsOrders = objBs.GetInvoice_fullPickupOff(Convert.ToInt32(iInvoiceID));
                    //}

                    if ((dsOrders.Tables[0].Rows.Count > 0)&&(dsOrders!=null))
                    {
                        lblCustomerName1.Text = dsOrders.Tables[0].Rows[0]["Firstname"].ToString() + dsOrders.Tables[0].Rows[0]["MiddleName"].ToString() + dsOrders.Tables[0].Rows[0]["LastName"].ToString();
                        lblAddr1.Text = dsOrders.Tables[0].Rows[0]["AddressLine1"].ToString() + "," + dsOrders.Tables[0].Rows[0]["AddressLine2"].ToString();
                        lblAddress1.Text = dsOrders.Tables[0].Rows[0]["billcity"].ToString() + "-" + dsOrders.Tables[0].Rows[0]["pincode"].ToString();
                        //lblCity1.Text = dsOrders.Tables[0].Rows[0]["billcountry"].ToString();
                        lblCountry1.Text = dsOrders.Tables[0].Rows[0]["EMail"].ToString();
                        lblEMail1.Text = dsOrders.Tables[0].Rows[0]["Mobileno"].ToString();
                        lblState1.Text = dsOrders.Tables[0].Rows[0]["billstate"].ToString();
                        lblPlaceofSupply.Text = dsOrders.Tables[0].Rows[0]["billcountry"].ToString();

                        lblInvoiceNo.Text = dsOrders.Tables[0].Rows[0]["FullBillNo"].ToString();
                        lblInvoiceDate.Text = Convert.ToDateTime(dsOrders.Tables[0].Rows[0]["Invoicedate"]).ToString("dd/MM/yyyy");
                        lbltermspayment.Text = dsOrders.Tables[0].Rows[0]["PaymentMethod"].ToString();
                        lblbuyerorderno.Text = dsOrders.Tables[0].Rows[0]["OrderNo"].ToString();
                        lblOrderdate.Text = Convert.ToDateTime(dsOrders.Tables[0].Rows[0]["Orderdate"]).ToString("dd/MM/yyyy");
                        lbldestination.Text = dsOrders.Tables[0].Rows[0]["RegionName"].ToString();
                        lblcustgstin.Text = dsOrders.Tables[0].Rows[0]["GSTNo"].ToString();

                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;
                        DataSet dstd = new DataSet();
                        dttt = new DataTable();

                        dct = new DataColumn("Sno");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Product");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("HSNCode");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("GST");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Qty");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Rate");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Per");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Amount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("TotAmount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Flavour");
                        dttt.Columns.Add(dct);


                        dstd.Tables.Add(dttt);

                        DataSet dsOr = null;
                     //   dsOr = objBs.GetInvoiceDetailsPickupOff(Convert.ToInt32(iInvoiceID));

                        if (dsOr.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dsOr.Tables[0].Rows.Count; j++)
                            {
                                drNew = dttt.NewRow();
                                drNew["Sno"] = j + 1;

                                DataSet dsAvailableProductPhotoCake = null;
                               // DataSet dsAvailableProductPhotoCake = objBs.AvailableProductPhotoCake(Convert.ToInt32(dsOr.Tables[0].Rows[j]["ProductID"].ToString()));
                                if (dsAvailableProductPhotoCake.Tables[0].Rows.Count > 0)
                                {
                                    if (dsAvailableProductPhotoCake.Tables[0].Rows[0]["RateName"].ToString() == "Egg/Eggless")
                                    {                                        
                                        //drNew["Product"] = "<p><b>" + dsOr.Tables[0].Rows[j]["Productname"].ToString() + "</b><b><br>Weight: </b>" + dsOr.Tables[0].Rows[j]["SizeID"].ToString() + "<br><b>Egg/Eggless:</b>" + dsOr.Tables[0].Rows[j]["ColorID"].ToString() + "<br><b>Msg on Cake:</b>" + dsOr.Tables[0].Rows[j]["Message2"].ToString() + "</p>";
                                        drNew["Product"] = "<p><b>" + dsOr.Tables[0].Rows[j]["Printname"].ToString() + "</b><b><br>Flavour: </b>" + dsOr.Tables[0].Rows[j]["flavourname"].ToString() + "<br>Weight: </b>" + dsOr.Tables[0].Rows[j]["SizeID"].ToString() + "<br><b>Egg/Eggless:</b>" + dsOr.Tables[0].Rows[j]["ColorID"].ToString() + "</p>";
                                    }
                                    else if (dsAvailableProductPhotoCake.Tables[0].Rows[0]["RateName"].ToString() == "Veg/NonVeg")
                                    {
                                        //drNew["Product"] = "<p><b>" + dsOr.Tables[0].Rows[j]["Productname"].ToString() + "</b><b><br>Weight: </b>" + dsOr.Tables[0].Rows[j]["SizeID"].ToString() + "<br><b>Veg/NonVeg:</b>" + dsOr.Tables[0].Rows[j]["ColorID"].ToString() + "<br><b>Msg on Cake:</b>" + dsOr.Tables[0].Rows[j]["Message2"].ToString() + "</p>";
                                        drNew["Product"] = "<p><b>" + dsOr.Tables[0].Rows[j]["Printname"].ToString() + "</b><b><br>Flavour: </b>" + dsOr.Tables[0].Rows[j]["flavourname"].ToString() + "<br>Weight: </b>" + dsOr.Tables[0].Rows[j]["SizeID"].ToString() + "<br><b>Veg/NonVeg:</b>" + dsOr.Tables[0].Rows[j]["ColorID"].ToString() + "</p>";
                                    }
                                    else
                                    {
                                        //drNew["Product"] = "<p><b>" + dsOr.Tables[0].Rows[j]["Productname"].ToString() + "</b><b><br>Weight: </b>" + dsOr.Tables[0].Rows[j]["SizeID"].ToString() + "<br><b>Egg/Eggless:</b>" + dsOr.Tables[0].Rows[j]["ColorID"].ToString() + "<br><b>Msg on Cake:</b>" + dsOr.Tables[0].Rows[j]["Message2"].ToString() + "</p>";
                                        drNew["Product"] = "<p><b>" + dsOr.Tables[0].Rows[j]["Printname"].ToString() + "</b><b><br>Flavour: </b>" + dsOr.Tables[0].Rows[j]["flavourname"].ToString() + "<br>Weight: </b>" + dsOr.Tables[0].Rows[j]["SizeID"].ToString() + "<br><b>Egg/Eggless:</b>" + dsOr.Tables[0].Rows[j]["ColorID"].ToString() + "</p>";
                                    }
                                }

                                
                                drNew["HSNCode"] = "<p style='text-align: left'>" + dsOr.Tables[0].Rows[j]["HSNSAC"].ToString() + "</p>";
                                drNew["GST"] = "<p>" + dsOr.Tables[0].Rows[j]["TaxPercent"].ToString() + "%</p>";

                                //drNew["Qty"] = "<p style='text-align: right'>" + dsOr.Tables[0].Rows[j]["Qty"].ToString() + " </p>";
                                drNew["Qty"] =  dsOr.Tables[0].Rows[j]["Qty"].ToString();
                                //drNew["Rate"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(dsOr.Tables[0].Rows[j]["BeforeTax"]).ToString("N2") + " </p>";
                                drNew["Rate"] =  Convert.ToDouble(dsOr.Tables[0].Rows[j]["BeforeTax"]).ToString("N2");
                                //drNew["Per"] = "<p style='text-align: right'>" + "Kgs" + "</p>";
                                drNew["Per"] = dsOr.Tables[0].Rows[j]["SizeID"].ToString().Substring(dsOr.Tables[0].Rows[j]["SizeID"].ToString().IndexOf(' ') + 1);// "Kgs";
                                //drNew["Amount"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(dsOr.Tables[0].Rows[j]["Total"]).ToString("N2") + "</p>";
                                drNew["Amount"] = Convert.ToDouble(dsOr.Tables[0].Rows[j]["BeforeTax"]).ToString("N2");
                                drNew["TotAmount"] = Convert.ToDouble(dsOr.Tables[0].Rows[j]["BeforeTax"]).ToString("N2");
                                SubTotal = SubTotal + Convert.ToDouble(dsOr.Tables[0].Rows[j]["BeforeTax"]);                       
                                dstd.Tables[0].Rows.Add(drNew);
                            }
                        }

                        DataSet dsShippingCost = null;
                   //     dsShippingCost = objBs.GetInvoiceDetailsShippingCost(Convert.ToInt32(iInvoiceID));

                        foreach (DataRow DrShip in dsShippingCost.Tables[0].Rows)
                        {
                            if (Convert.ToDouble(DrShip["shipping"]) > 0)
                            {
                                drNew = dttt.NewRow();
                                drNew["SNo"] = "";
                                //drNew["Product"] = "<p>" + "Shipping Cost" + "</p>";
                                drNew["Product"] = "Shipping Cost";
                                //drNew["HSNCode"] = "<p style='text-align: left'>" + "996519" + "</p>";
                                drNew["HSNCode"] = "996519";
                                //drNew["GST"] = "<p>" + "18%" + "</p>";
                                drNew["GST"] = "18%";
                                //drNew["Qty"] = "<p style='text-align: right'>" + "-" + "</p>";
                                drNew["Qty"] = "-";
                                //drNew["Rate"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(DrShip["shipping"]).ToString("f2") + " </p>";
                                drNew["Rate"] = Convert.ToDouble(DrShip["shipping"]).ToString("f2");
                                //drNew["Per"] = "<p style='text-align: right'>" + "-" + "</p>";
                                drNew["Per"] =  "-";
                                //drNew["Amount"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(DrShip["shippingcost"]).ToString("f2") + " </p>";
                                drNew["Amount"] = Convert.ToDouble(DrShip["shipping"]).ToString("f2");
                                drNew["TotAmount"] = Convert.ToDouble(DrShip["shipping"]).ToString("f2");
                                SubTotal = SubTotal + Convert.ToDouble(DrShip["shipping"]);
                                dstd.Tables[0].Rows.Add(drNew);
                            }
                        }

                        drNew = dttt.NewRow();
                        drNew["SNo"] = "";
                        drNew["Product"] = "";
                        drNew["HSNCode"] = "";
                        drNew["GST"] = "";
                        drNew["Qty"] = "";
                        drNew["Rate"] = "";
                        drNew["Per"] = "";
                        drNew["Amount"] = "----------------";
                        drNew["TotAmount"] = "0";
                        dstd.Tables[0].Rows.Add(drNew);

                        drNew = dttt.NewRow();
                        drNew["SNo"] = "";
                        drNew["Product"] = "";
                        drNew["HSNCode"] = "";
                        drNew["GST"] = "";
                        drNew["Qty"] = "";
                        drNew["Rate"] = "";
                        drNew["Per"] = "";
                        drNew["Amount"] = Convert.ToDouble(SubTotal).ToString("f2");
                        drNew["TotAmount"] = "0";
                        dstd.Tables[0].Rows.Add(drNew);

                        drNew = dttt.NewRow();
                        drNew["SNo"] = "";
                        drNew["Product"] = "";
                        drNew["HSNCode"] = "";
                        drNew["GST"] = "";
                        drNew["Qty"] = "";
                        drNew["Rate"] = "";
                        drNew["Per"] = "";
                        drNew["Amount"] = "";
                        drNew["TotAmount"] = "0";
                        dstd.Tables[0].Rows.Add(drNew);

                        DataSet dsGST = null;
                    //    dsGST = objBs.GetInvoiceDetailsGST(Convert.ToInt32(iInvoiceID));

                        foreach (DataRow Dr in dsGST.Tables[0].Rows)
                        {
                            drNew = dttt.NewRow();
                            //drNew["SNo"] = "";
                            //drNew["Product"] = "<p style='text-align: right'>" + Dr["ItemName"] + "</p>";
                            //drNew["HSNCode"] = "";
                            //drNew["GST"] = "";
                            //drNew["Qty"] = "";
                            //drNew["Rate"] = "<p style='text-align: right'>" + Dr["Rate"] + "</p>";
                            //drNew["Per"] = "<p style='text-align: center'>" + Dr["Per"] + "</p>";
                            //drNew["Amount"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(Dr["Amount"]).ToString("f2") + " </p>";
                            //drNew["TotAmount"] = Convert.ToDouble(Dr["Amount"]).ToString("f2");
                            drNew["SNo"] = "";
                            drNew["Product"] = Dr["ItemName"] ;
                            drNew["HSNCode"] = "";
                            drNew["GST"] = "";
                            drNew["Qty"] = "";
                            drNew["Rate"] =Dr["Rate"];
                            drNew["Per"] =  Dr["Per"];
                            //drNew["Amount"] = "INR " + Convert.ToDouble(Dr["Amount"]).ToString("f2") + " </p>";
                            drNew["Amount"] =  Convert.ToDouble(Dr["Amount"]).ToString("f2");
                            drNew["TotAmount"] = Convert.ToDouble(Dr["Amount"]).ToString("f2");
                            dstd.Tables[0].Rows.Add(drNew);
                        }


                       

                        DataSet dsShippingCostGST = null;
                       // dsShippingCostGST = objBs.GetInvoiceDetailsShippingCost(Convert.ToInt32(iInvoiceID));

                        foreach (DataRow DrShip in dsShippingCostGST.Tables[0].Rows)
                        {
                            if (Convert.ToDouble(DrShip["shipingCGST"]) > 0)
                            {
                                drNew = dttt.NewRow();
                                //drNew["SNo"] = "";
                                //drNew["Product"] = "<p style='text-align: right'>" + "Output Shipping CGST @ " + DrShip["Rate"] + " " + DrShip["Per"] + "</p>";
                                //drNew["HSNCode"] = "";
                                //drNew["GST"] = "";
                                //drNew["Qty"] = "";                             
                                //drNew["Rate"] = "<p style='text-align: right'>" + DrShip["Rate"] + "</p>";
                                //drNew["Per"] = "<p style='text-align: center'>" + DrShip["Per"] + "</p>";
                                //drNew["Amount"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(DrShip["shipingCGST"]).ToString("f2") + " </p>";
                                //drNew["TotAmount"] = Convert.ToDouble(DrShip["shipingCGST"]).ToString("f2");
                                drNew["SNo"] = "";
                                drNew["Product"] = "Output Shipping CGST @ " + DrShip["Rate"] + " " + DrShip["Per"];
                                drNew["HSNCode"] = "";
                                drNew["GST"] = "";
                                drNew["Qty"] = "";
                                drNew["Rate"] =  DrShip["Rate"];
                                drNew["Per"] =  DrShip["Per"];
                                //drNew["Amount"] = "INR " + Convert.ToDouble(DrShip["shipingCGST"]).ToString("f2");
                                drNew["Amount"] = Convert.ToDouble(DrShip["shipingCGST"]).ToString("f2");
                                drNew["TotAmount"] = Convert.ToDouble(DrShip["shipingCGST"]).ToString("f2");
                                dstd.Tables[0].Rows.Add(drNew);

                                drNew = dttt.NewRow();
                                //drNew["SNo"] = "";
                                //drNew["Product"] = "<p style='text-align: right'>" + "Output Shipping SGST @ " + DrShip["Rate"] + " " + DrShip["Per"] + "</p>";
                                //drNew["HSNCode"] = "";
                                //drNew["GST"] = "";
                                //drNew["Qty"] = "";
                                //drNew["Rate"] = "<p style='text-align: right'>" + DrShip["Rate"] + "</p>";
                                //drNew["Per"] = "<p style='text-align: center'>" + DrShip["Per"] + "</p>";
                                //drNew["Amount"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(DrShip["shipingSGST"]).ToString("f2") + " </p>";
                                //drNew["TotAmount"] = Convert.ToDouble(DrShip["shipingSGST"]).ToString("f2");
                                drNew["SNo"] = "";
                                drNew["Product"] = "Output Shipping SGST @ " + DrShip["Rate"] + " " + DrShip["Per"];
                                drNew["HSNCode"] = "";
                                drNew["GST"] = "";
                                drNew["Qty"] = "";
                                drNew["Rate"] = DrShip["Rate"];
                                drNew["Per"] =  DrShip["Per"];
                                //drNew["Amount"] = "INR " + Convert.ToDouble(DrShip["shipingSGST"]).ToString("f2");
                                drNew["Amount"] = Convert.ToDouble(DrShip["shipingSGST"]).ToString("f2");
                                drNew["TotAmount"] = Convert.ToDouble(DrShip["shipingSGST"]).ToString("f2");
                                dstd.Tables[0].Rows.Add(drNew);
                            }
                            //drNew = dttt.NewRow();
                            //drNew["SNo"] = "";
                            //drNew["Product"] = "<p style='text-align: right'>" + "Total" + "</p>";
                            //drNew["HSNCode"] = "";
                            //drNew["GST"] = "";
                            //drNew["Qty"] = "";
                            //drNew["Rate"] = "";
                            //drNew["Per"] = "";
                            //drNew["Amount"] = "<p style='text-align: right'>" + "INR " + Convert.ToDouble(DrShip["Roundoff"]).ToString("f2") + " </p>";
                            lblAmountinwords.Text = "INR " + objBs.changeToWords(Convert.ToDouble(DrShip["Roundoff"]).ToString("f2"), true);
                           
                            //dstd.Tables[0].Rows.Add(drNew);
                        }

                        DataRow dr;
                        DataTable dt;
                        dt = dstd.Tables[0];
                        gvProduct.DataSource = dt;
                        gvProduct.DataBind();
                        gvProduct.Visible = true;

                        #region GSTGrid
                        double cgsttot = 0;
                        double sgsttot = 0;
                        double gsttot = 0;
                        double ratetot = 0;

                        DataTable dtttg;
                        DataRow drNewg;
                        DataColumn dctg;
                        DataSet dstdg = new DataSet();
                        dtttg = new DataTable();                     

                        dctg = new DataColumn("HSNCode");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("Rate");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("CGSTRate");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("CGSTAmount");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("SGSTRate");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("SGSTAmount");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("Amount");
                        dtttg.Columns.Add(dctg);

                        dstdg.Tables.Add(dtttg);


                        DataSet dsOrGSTHSN = null;
                      //  dsOrGSTHSN = objBs.GetInvoiceDetailsGSTHSNCode(Convert.ToInt32(iInvoiceID));

                        if (dsOrGSTHSN.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dsOrGSTHSN.Tables[0].Rows.Count; j++)
                            {
                                drNewg = dtttg.NewRow();
                                //drNewg["HSNCode"] = "<p>" + dsOrGSTHSN.Tables[0].Rows[j]["HSNSAC"].ToString() + "</p>";
                                //drNewg["Rate"] = "<p>" + "INR " + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["Pricewithouttax"]).ToString("N2") + "</p>";
                                //ratetot = ratetot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["Pricewithouttax"]);
                                //drNewg["CGSTRate"] = "<p>" + dsOrGSTHSN.Tables[0].Rows[j]["CGSTPer"].ToString() + "</p>";
                                //drNewg["CGSTAmount"] = "<p>" + "INR " + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["CGSTAmount"]).ToString("N2") + "</p>";
                                //cgsttot = cgsttot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["CGSTAmount"]);
                                //drNewg["SGSTRate"] = "<p>" + dsOrGSTHSN.Tables[0].Rows[j]["SGSTPer"].ToString() + "</p>";
                                //drNewg["SGSTAmount"] = "<p>" + "INR " + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["SGSTAmount"]).ToString("N2") + "</p>";
                                //sgsttot = sgsttot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["SGSTAmount"]);
                                //drNewg["Amount"] = "<p>" + "INR " + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["TotalAmount"]).ToString("N2") + "</p>";
                                //gsttot = gsttot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["TotalAmount"]);
                                drNewg["HSNCode"] =  dsOrGSTHSN.Tables[0].Rows[j]["HSNSAC"].ToString() ;
                                drNewg["Rate"] = Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["Pricewithouttax"]).ToString("N2");
                                ratetot = ratetot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["Pricewithouttax"]);
                                drNewg["CGSTRate"] =  dsOrGSTHSN.Tables[0].Rows[j]["CGSTPer"].ToString();
                                drNewg["CGSTAmount"] =  Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["CGSTAmount"]).ToString("N2");
                                cgsttot = cgsttot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["CGSTAmount"]);
                                drNewg["SGSTRate"] = dsOrGSTHSN.Tables[0].Rows[j]["SGSTPer"].ToString();
                                drNewg["SGSTAmount"] = Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["SGSTAmount"]).ToString("N2");
                                sgsttot = sgsttot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["SGSTAmount"]);
                                drNewg["Amount"] =  Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["TotalAmount"]).ToString("N2");
                                gsttot = gsttot + Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["TotalAmount"]);
                                dstdg.Tables[0].Rows.Add(drNewg);
                            }
                        }

                        DataSet dsShippingCostGSTHSN = null;
                     //   dsShippingCostGSTHSN = objBs.GetInvoiceDetailsShippingCost(Convert.ToInt32(iInvoiceID));

                        foreach (DataRow DrShipGSTHSN in dsShippingCostGSTHSN.Tables[0].Rows)
                        {
                            if (Convert.ToDouble(DrShipGSTHSN["shipping"]) > 0)
                            {
                                drNewg = dtttg.NewRow();
                                //drNewg["HSNCode"] = "<p>" + "996519" + "</p>";
                                //drNewg["Rate"] = "<p>" + "INR " + Convert.ToDouble(DrShipGSTHSN["shipping"]).ToString("f2") + " </p>";
                                //ratetot = ratetot + Convert.ToDouble(DrShipGSTHSN["shipping"]);
                                //drNewg["CGSTRate"] = "<p>" + DrShipGSTHSN["Rate"] + " " + DrShipGSTHSN["Per"] + "</p>";
                                //drNewg["CGSTAmount"] = "<p>" + "INR " + Convert.ToDouble(DrShipGSTHSN["shipingCGST"]).ToString("f2") + " </p>";
                                //cgsttot = cgsttot + Convert.ToDouble(DrShipGSTHSN["shipingCGST"]);
                                //drNewg["SGSTRate"] = "<p>" + DrShipGSTHSN["Rate"] + " " + DrShipGSTHSN["Per"] + "</p>";
                                //drNewg["SGSTAmount"] = "<p>" + "INR " + Convert.ToDouble(DrShipGSTHSN["shipingSGST"]).ToString("f2") + " </p>";
                                //sgsttot = sgsttot + Convert.ToDouble(DrShipGSTHSN["shipingSGST"]);
                                //drNewg["Amount"] = "<p>" + "INR " + Convert.ToDouble(DrShipGSTHSN["TotalAmount"]).ToString("f2") + " </p>";
                                //gsttot = gsttot + Convert.ToDouble(DrShipGSTHSN["TotalAmount"]);
                                drNewg["HSNCode"] = "996519";
                                drNewg["Rate"] = Convert.ToDouble(DrShipGSTHSN["shipping"]).ToString("f2");
                                ratetot = ratetot + Convert.ToDouble(DrShipGSTHSN["shipping"]);
                                drNewg["CGSTRate"] = DrShipGSTHSN["Rate"] + " " + DrShipGSTHSN["Per"];
                                drNewg["CGSTAmount"] = Convert.ToDouble(DrShipGSTHSN["shipingCGST"]).ToString("f2");
                                cgsttot = cgsttot + Convert.ToDouble(DrShipGSTHSN["shipingCGST"]);
                                drNewg["SGSTRate"] = DrShipGSTHSN["Rate"] + " " + DrShipGSTHSN["Per"];
                                drNewg["SGSTAmount"] = Convert.ToDouble(DrShipGSTHSN["shipingSGST"]).ToString("f2");
                                sgsttot = sgsttot + Convert.ToDouble(DrShipGSTHSN["shipingSGST"]);
                                drNewg["Amount"] =  Convert.ToDouble(DrShipGSTHSN["TotalAmount"]).ToString("f2");
                                gsttot = gsttot + Convert.ToDouble(DrShipGSTHSN["TotalAmount"]);
                                dstdg.Tables[0].Rows.Add(drNewg);
                            }
                        }

                        drNewg = dtttg.NewRow();
                        //drNewg["HSNCode"] = "<p>" + "Total" + "</p>";
                        //drNewg["Rate"] = "<p>" + "INR " + Convert.ToDouble(ratetot).ToString("f2") + " </p>";
                        //drNewg["CGSTRate"] = "";
                        //drNewg["CGSTAmount"] = "<p>" + "INR " + Convert.ToDouble(cgsttot).ToString("f2") + " </p>";
                        //drNewg["SGSTRate"] = "";
                        //drNewg["SGSTAmount"] = "<p>" + "INR " + Convert.ToDouble(sgsttot).ToString("f2") + " </p>";
                        //drNewg["Amount"] = "<p>" + "INR " + Convert.ToDouble(gsttot).ToString("f2") + " </p>";
                        //drNewg["Rate"] =  Convert.ToDouble(ratetot).ToString("f2");
                        //drNewg["CGSTRate"] = "";
                        //drNewg["CGSTAmount"] =  Convert.ToDouble(cgsttot).ToString("f2");
                        //drNewg["SGSTRate"] = "";
                        //drNewg["SGSTAmount"] = Convert.ToDouble(sgsttot).ToString("f2");
                        //drNewg["Amount"] =  Convert.ToDouble(gsttot).ToString("f2");
                        lblTaxAmountinwords.Text = "INR " + objBs.changeToWords(Convert.ToDouble(gsttot).ToString("f2"), true);
                        dstdg.Tables[0].Rows.Add(drNewg);

                        DataRow drg;
                        DataTable dtg;
                        dtg = dstdg.Tables[0];
                        gvGST.DataSource = dtg;
                        gvGST.DataBind();
                        gvGST.Visible = true;
                        #endregion
                    }
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        private void Export_to_Word()
        {
            //ExportPanel1.ExportType = ExportPanel.AppType.Word;
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderDetails.aspx");
        }

        protected void gvProduct_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((DataBinder.Eval(e.Row.DataItem, "TotAmount")).ToString() != "")
                {
                    Amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotAmount"));
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";                   
                e.Row.Cells[7].Text = Amount.ToString("f2");
            }
        }

        double HSNRate = 0;
        double HSNCGSTAmount = 0;
        double HSNSGSTAmount = 0;
        double HSNAmount = 0;

        protected void gvGST_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((DataBinder.Eval(e.Row.DataItem, "Rate")).ToString() != "")
                {
                    HSNRate += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Rate"));
                }

                if ((DataBinder.Eval(e.Row.DataItem, "CGSTAmount")).ToString() != "")
                {
                    HSNCGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CGSTAmount"));
                }

                if ((DataBinder.Eval(e.Row.DataItem, "SGSTAmount")).ToString() != "")
                {
                    HSNSGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SGSTAmount"));
                }

                if ((DataBinder.Eval(e.Row.DataItem, "Amount")).ToString() != "")
                {
                    HSNAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = HSNRate.ToString("f2");
                e.Row.Cells[3].Text = HSNCGSTAmount.ToString("f2");
                e.Row.Cells[5].Text = HSNSGSTAmount.ToString("f2");
                e.Row.Cells[6].Text = HSNAmount.ToString("f2");
            }
        }
    }
}