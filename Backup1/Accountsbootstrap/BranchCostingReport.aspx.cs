using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class BranchCostingReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string Password = "";
        string BranchNAme = "";
        string StoreName = "";

        string ratesetting = "";

        double totopvalue = 0, totstockinvalue = 0, totsalesvalue = 0, totmarginvalue = 0, totreturnvalue = 0, totstockvalue =0, totexp = 0, totvarexp = 0, totprofit = 0, totpercentage = 0;

        double unitprice = 0, Qty = 0, subtotal = 0, gst0amount = 0, gst5amount = 0, gst12amount = 0, gst18amount = 0, gst28amount = 0, totalvalue = 0, commamount = 0, commgstamnt = 0, gatwaycharge = 0, grandtot = 0, discvalue = 0, gst0amount1 = 0, gst5amount1 = 0, gst12amount1 = 0, gst18amount1 = 0, gst28amount1 = 0;


        double GTax = 0;
        double GNetAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);
            Label123.Text = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();

            if (!IsPostBack)
            {

                
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString() ;
                txtfromdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                if (sadmin == "1")
                {
                    ddlBranch.Enabled = true;
                    DataSet dsbranchto = objbs.Branchto();
                    ddlBranch.DataSource = dsbranchto.Tables[0];
                    ddlBranch.DataTextField = "branchcode";
                    ddlBranch.DataValueField = "Userid";
                    ddlBranch.DataBind();
                    //  ddlBranch.Items.Insert(0, "All");
                }
                else
                {
                    DataSet dsbranch = new DataSet();
                    string stable = "tblSales_" + sTableName + "";
                    dsbranch = objbs.Branchfrom(lblUserID.Text);
                    ddlBranch.DataSource = dsbranch.Tables[0];
                    ddlBranch.DataTextField = "branchcode";
                    ddlBranch.DataValueField = "Userid";
                    ddlBranch.DataBind();
                    ddlBranch.Enabled = false;
                }

                if (sTableName == "admin")
                {
                    ddlBranch.Enabled = true;
                    txtfromdate.Enabled = true;
                    txttodate.Enabled = true;



                }
                else
                {


                }

            }
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            double Salesvalue = 0;
            double margin = 0;
            double expense = 0;
            double varexp = 0;
            double netprofit = 0;
            double netprofitpercentage = 0;



            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);


            DateTime scurdate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            DateTime sTo = Convert.ToDateTime(txttodate.Text);

            DataTable dtPOSSales = new DataTable();
            dtPOSSales.Columns.Add(new DataColumn("Date"));
            dtPOSSales.Columns.Add(new DataColumn("OpStockValue"));
            dtPOSSales.Columns.Add(new DataColumn("StockInValue"));
            dtPOSSales.Columns.Add(new DataColumn("SalesValue"));
            dtPOSSales.Columns.Add(new DataColumn("SalesReturnValue"));
            dtPOSSales.Columns.Add(new DataColumn("Stockvalue"));
            dtPOSSales.Columns.Add(new DataColumn("MarginValue"));
            dtPOSSales.Columns.Add(new DataColumn("Expense"));
            dtPOSSales.Columns.Add(new DataColumn("VariableExp"));
            dtPOSSales.Columns.Add(new DataColumn("Total"));
            dtPOSSales.Columns.Add(new DataColumn("percentage"));
            //dtPOSSales.TableName = "Sales";

            if (radbtnlist.SelectedValue == "1")
            {
                while (sFrom <= sTo)
                {

                    DataRow dr_export1 = dtPOSSales.NewRow();
                    dr_export1["Date"] = Convert.ToDateTime(sFrom).ToString("dd/MM/yyyy");


                    // Get opstockvalue


                    DataSet dsopvalue = objbs.opvalue(ddlBranch.SelectedItem.Text, sFrom);
                    if (dsopvalue != null)
                    {
                        if (dsopvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["OpStockValue"] = Convert.ToDouble(dsopvalue.Tables[0].Rows[0]["opvalue"]).ToString("" + ratesetting + "");
                        }
                        else
                        {
                            dr_export1["OpStockValue"] = "0";
                        }
                    }
                    else
                    {
                        dr_export1["OpStockValue"] = "0";
                    }


                    // stockvalue

                    if (sFrom == scurdate)
                    {

                        DataSet dsclosevalue = objbs.currentstockvalue(ddlBranch.SelectedItem.Text, sFrom);
                        if (dsclosevalue != null)
                        {
                            if (dsclosevalue.Tables[0].Rows.Count > 0)
                            {
                                dr_export1["StockValue"] = Convert.ToDouble(dsclosevalue.Tables[0].Rows[0]["closevalue"]).ToString("" + ratesetting + "");
                            }
                            else
                            {
                                dr_export1["StockValue"] = "0";
                            }
                        }
                        else
                        {
                            dr_export1["StockValue"] = "0";
                        }

                    }
                    else
                    {
                        DataSet dsclosevalue = objbs.closingvalue(ddlBranch.SelectedItem.Text, sFrom);
                        if (dsclosevalue != null)
                        {
                            if (dsclosevalue.Tables[0].Rows.Count > 0)
                            {
                                dr_export1["StockValue"] = Convert.ToDouble(dsclosevalue.Tables[0].Rows[0]["closevalue"]).ToString("" + ratesetting + "");
                            }
                            else
                            {
                                dr_export1["StockValue"] = "0";
                            }
                        }
                        else
                        {
                            dr_export1["StockValue"] = "0";
                        }
                    }
                    


                    // grn value
                    DataSet dsgrnvalue = objbs.grnvalue(ddlBranch.SelectedItem.Text, sFrom);
                    if (dsgrnvalue != null)
                    {
                        if (dsgrnvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["StockInValue"] = Convert.ToDouble(dsgrnvalue.Tables[0].Rows[0]["grnvalue"]).ToString("" + ratesetting + "");
                        }
                        else
                        {
                            dr_export1["StockInValue"] = "0";
                        }
                    }
                    else
                    {
                        dr_export1["StockInValue"] = "0";
                    }


                    // salesvalue
                    DataSet dssalesvalue = objbs.salesvalue(ddlBranch.SelectedItem.Text, sFrom);
                    if (dssalesvalue != null)
                    {
                        if (dssalesvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["SalesValue"] = Convert.ToDouble(dssalesvalue.Tables[0].Rows[0]["salevalue"]).ToString("" + ratesetting + "");
                            Salesvalue = Convert.ToDouble(dssalesvalue.Tables[0].Rows[0]["salevalue"]);
                        }
                        else
                        {
                            dr_export1["SalesValue"] = "0";
                            Salesvalue = 0;
                        }
                    }
                    else
                    {
                        dr_export1["SalesValue"] = "0";
                        Salesvalue = 0;
                    }

                    // marginvalue
                    DataSet dsmrginvalue = objbs.marginvalue(ddlBranch.SelectedItem.Text, sFrom);
                    if (dsmrginvalue != null)
                    {
                        if (dsmrginvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["MarginValue"] = Convert.ToDouble(dsmrginvalue.Tables[0].Rows[0]["MarginValue"]).ToString("" + ratesetting + "");
                            margin = Convert.ToDouble(dsmrginvalue.Tables[0].Rows[0]["MarginValue"]);
                        }
                        else
                        {
                            margin = 0;
                            dr_export1["MarginValue"] = "0";
                        }
                    }
                    else
                    {
                        dr_export1["MarginValue"] = "0";
                        margin = 0;
                    }

                    // expense
                    DataSet dsexpvalue = objbs.branchexpense(ddlBranch.SelectedItem.Text, sFrom);
                    if (dsexpvalue != null)
                    {
                        if (dsexpvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["Expense"] = Convert.ToDouble(dsexpvalue.Tables[0].Rows[0]["expamount"]).ToString("" + ratesetting + "");
                            expense = Convert.ToDouble(dsexpvalue.Tables[0].Rows[0]["expamount"]);
                        }
                        else
                        {
                            dr_export1["Expense"] = "0";
                            expense = 0;
                        }
                    }
                    else
                    {
                        dr_export1["Expense"] = "0";
                        expense = 0;
                    }

                    //stockreturtnvalue
                    DataSet dsretvalue = objbs.stockreturtnvalue(ddlBranch.SelectedItem.Text, sFrom);
                    if (dsretvalue != null)
                    {
                        if (dsretvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["SalesReturnValue"] = Convert.ToDouble(dsretvalue.Tables[0].Rows[0]["retvalue"]).ToString("" + ratesetting + "");
                        }
                        else
                        {
                            dr_export1["SalesReturnValue"] = "0";
                        }
                    }
                    else
                    {
                        dr_export1["SalesReturnValue"] = "0";
                    }


                    // variable expense
                    DataSet dsvarexpvalue = objbs.variableexpense(ddlBranch.SelectedItem.Text, sFrom);
                    if (dsvarexpvalue != null)
                    {
                        if (dsvarexpvalue.Tables[0].Rows.Count > 0)
                        {
                            dr_export1["VariableExp"] = Convert.ToDouble(dsvarexpvalue.Tables[0].Rows[0]["perdayamount"]).ToString("" + ratesetting + "");
                            varexp = Convert.ToDouble(dsvarexpvalue.Tables[0].Rows[0]["perdayamount"]);
                        }
                        else
                        {
                            dr_export1["VariableExp"] = "0";
                            varexp = 0;
                        }
                    }
                    else
                    {
                        dr_export1["VariableExp"] = "0";
                        varexp = 0;
                    }

                    if (margin != 0)
                    {

                        netprofit = margin - (expense + varexp);
                        netprofitpercentage = (netprofit * 100) / Salesvalue;
                    }
                    else
                    {
                        netprofit = 0;
                        netprofitpercentage = 0;
                    }

                    dr_export1["total"] = Convert.ToDouble(netprofit).ToString("" + ratesetting + "");
                    dr_export1["percentage"] = Convert.ToDouble(netprofitpercentage).ToString("" + ratesetting + "") + lblpercentage.Text;


                    dtPOSSales.Rows.Add(dr_export1);
                    sFrom = sFrom.AddDays(1);
                }

                if (dtPOSSales.Rows.Count > 0)
                {
                    gvdetailed.DataSource = dtPOSSales;
                    gvdetailed.DataBind();
                }
                else
                {
                    gvdetailed.DataSource = null;
                    gvdetailed.DataBind();
                }
            }

            // if (chkDiscout.Checked == true)
            if (radbtnlist.SelectedValue == "2")
            {
                //if (dsbranch1.Tables[0].Rows.Count > 0)
                //{
                //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //    string[] wordArray = sales.Split('_');

                //    brach = wordArray[1];
                //    string name = string.Empty;


                //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                //    //  string paymode = drpPayment.SelectedItem.Value;



                //    DataTable dtsum = new DataTable();
                //    DataSet dssum = new DataSet();
                //    DataRow drsum;

                //    dtsum.Columns.Add("paymode");
                //    dtsum.Columns.Add("No");
                //    dtsum.Columns.Add("paymenttype");
                //    dtsum.Columns.Add("billno");
                //    dtsum.Columns.Add("BillDate");
                //    dtsum.Columns.Add("Category");
                //    dtsum.Columns.Add("definition");
                //    dtsum.Columns.Add("unitprice");
                //    dtsum.Columns.Add("quantity");
                //    dtsum.Columns.Add("amount");
                //    //dtsum.Columns.Add("tax");
                //    dtsum.Columns.Add("disc");
                //    dtsum.Columns.Add("Z");
                //    dtsum.Columns.Add("F");
                //    dtsum.Columns.Add("TW");
                //    dtsum.Columns.Add("EG");
                //    dtsum.Columns.Add("TE");

                //    dtsum.Columns.Add("TotalValue");

                //    dssum.Tables.Add(dtsum);



                //    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Sales GST Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                 //   DataSet dcustbranch = objbs.New_TaxReport(brach, sFrom, sTo, "Y");
                //    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                //    if (dcustbranch.Tables[0].Rows.Count > 0)
                //    {




                //        if (dcustbranch.Tables[0].Rows.Count > 0)
                //        {
                //            #region

                //            DataTable dtraws = dcustbranch.Tables[0];

                //            var result1 = from r in dtraws.AsEnumerable()
                //                          group r by new
                //                          {
                //                              paymode = r["paymode"],
                //                              paymenttype = r["paymenttype"],
                //                              billno = r["billno"],
                //                              orderno = r["no"],
                //                              BillDate = r["BillDate"],
                //                              Category = r["Category"],
                //                              definition = r["definition"],
                //                              unitprice = r["unitprice"],
                //                              // quantity = r["quantity"],
                //                              // amount = r["amount"],
                //                              //  tax = r["tax"],
                //                              //  GST = r["GST"],
                //                              //disc = r["disc"],
                //                              //TotalValue = r["TotalValue"],
                //                          } into raw
                //                          select new
                //                          {
                //                              paymode = raw.Key.paymode,
                //                              paymenttype = raw.Key.paymenttype,
                //                              billno = raw.Key.billno,
                //                              BillDate = raw.Key.BillDate,
                //                              Category = raw.Key.Category,
                //                              definition = raw.Key.definition,
                //                              //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                //                              unitprice = raw.Key.unitprice,
                //                              quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                //                              amount = raw.Sum(x => Convert.ToDouble(x["amount"])),

                //                              Zero = raw.Sum(x => Convert.ToDouble(x["Z"])),
                //                              Five = raw.Sum(x => Convert.ToDouble(x["F"])),
                //                              twelve = raw.Sum(x => Convert.ToDouble(x["TW"])),
                //                              eghteen = raw.Sum(x => Convert.ToDouble(x["EG"])),
                //                              twentyeight = raw.Sum(x => Convert.ToDouble(x["TE"])),

                //                              disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                //                              TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),

                //                              orderno = raw.Key.orderno
                //                              //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                //                          };


                //            foreach (var g in result1)
                //            {
                //                drsum = dtsum.NewRow();

                //                drsum["paymode"] = g.paymode;
                //                drsum["No"] = g.orderno;
                //                drsum["paymenttype"] = g.paymenttype;
                //                drsum["billno"] = g.billno;
                //                drsum["BillDate"] = g.BillDate;
                //                drsum["Category"] = g.Category;
                //                drsum["definition"] = g.definition;
                //                drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                //                drsum["quantity"] = g.quantity;
                //                drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                //                //drsum["tax"] = g.tax;
                //                drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");

                //                drsum["Z"] = Convert.ToDouble(g.Zero).ToString("f2");
                //                drsum["F"] = Convert.ToDouble(g.Five).ToString("f2");
                //                drsum["TW"] = Convert.ToDouble(g.twelve).ToString("f2");
                //                drsum["EG"] = Convert.ToDouble(g.eghteen).ToString("f2");
                //                drsum["TE"] = Convert.ToDouble(g.twentyeight).ToString("f2");


                //                //drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                //                drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                //                dssum.Tables[0].Rows.Add(drsum);
                //            }
                //            #endregion
                //        }
                //        gvdetailed.Visible = true;
                //        gvsummary.Visible = false;
                //        Gst.Visible = false;
                //        gvdetailed.DataSource = dssum.Tables[0];
                //        gvdetailed.DataBind();


                //    }
                //    else
                //    {
                //        gvdetailed.DataSource = null;
                //        gvdetailed.DataBind();
                //    }
                //}

            }
           // else if (radbtnlist.SelectedValue == "1")
            {
                //{
                //    if (dsbranch1.Tables[0].Rows.Count > 0)
                //    {
                //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //        string[] wordArray = sales.Split('_');

                //        brach = wordArray[1];
                //        string name = string.Empty;


                //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                //        //  string paymode = drpPayment.SelectedItem.Value;



                //        DataTable dtsum = new DataTable();
                //        DataSet dssum = new DataSet();
                //        DataRow drsum;

                //        dtsum.Columns.Add("paymode");
                //        dtsum.Columns.Add("No");
                //        dtsum.Columns.Add("paymenttype");
                //        dtsum.Columns.Add("billno");
                //        dtsum.Columns.Add("BillDate");
                //        // dtsum.Columns.Add("Category");
                //        // dtsum.Columns.Add("definition");
                //        dtsum.Columns.Add("unitprice");
                //        dtsum.Columns.Add("quantity");
                //        dtsum.Columns.Add("amount");
                //        //dtsum.Columns.Add("tax");
                //        dtsum.Columns.Add("disc");
                //        dtsum.Columns.Add("Z");
                //        dtsum.Columns.Add("F");
                //        dtsum.Columns.Add("TW");
                //        dtsum.Columns.Add("EG");
                //        dtsum.Columns.Add("TE");

                //        dtsum.Columns.Add("TotalValue");

                //        dssum.Tables.Add(dtsum);



                //        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Sales GST Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                //        DataSet dcustbranch = objbs.New_TaxReport(brach, sFrom, sTo, "Y");
                //        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                //        if (dcustbranch.Tables[0].Rows.Count > 0)
                //        {




                //            if (dcustbranch.Tables[0].Rows.Count > 0)
                //            {
                //                #region

                //                DataTable dtraws = dcustbranch.Tables[0];

                //                var result1 = from r in dtraws.AsEnumerable()
                //                              group r by new
                //                              {
                //                                  paymode = r["paymode"],
                //                                  paymenttype = r["paymenttype"],
                //                                  billno = r["billno"],
                //                                  orderno = r["no"],
                //                                  BillDate = r["BillDate"],
                //                                  //  Category = r["Category"],
                //                                  //  definition = r["definition"],
                //                                  // unitprice = r["unitprice"],
                //                                  // quantity = r["quantity"],
                //                                  // amount = r["amount"],
                //                                  //  tax = r["tax"],
                //                                  //  GST = r["GST"],
                //                                  //disc = r["disc"],
                //                                  //TotalValue = r["TotalValue"],
                //                              } into raw
                //                              select new
                //                              {
                //                                  paymode = raw.Key.paymode,
                //                                  paymenttype = raw.Key.paymenttype,
                //                                  billno = raw.Key.billno,
                //                                  BillDate = raw.Key.BillDate,
                //                                  // Category = raw.Key.Category,
                //                                  //  definition = raw.Key.definition,
                //                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                //                                  unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
                //                                  quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                //                                  amount = raw.Sum(x => Convert.ToDouble(x["amount"])),

                //                                  Zero = raw.Sum(x => Convert.ToDouble(x["Z"])),
                //                                  Five = raw.Sum(x => Convert.ToDouble(x["F"])),
                //                                  twelve = raw.Sum(x => Convert.ToDouble(x["TW"])),
                //                                  eghteen = raw.Sum(x => Convert.ToDouble(x["EG"])),
                //                                  twentyeight = raw.Sum(x => Convert.ToDouble(x["TE"])),

                //                                  disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                //                                  TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),

                //                                  orderno = raw.Key.orderno
                //                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                //                              };


                //                foreach (var g in result1)
                //                {
                //                    drsum = dtsum.NewRow();

                //                    drsum["paymode"] = g.paymode;
                //                    drsum["No"] = g.orderno;
                //                    drsum["paymenttype"] = g.paymenttype;
                //                    drsum["billno"] = g.billno;
                //                    drsum["BillDate"] = g.BillDate;
                //                    //   drsum["Category"] = g.Category;
                //                    //   drsum["definition"] = g.definition;
                //                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                //                    drsum["quantity"] = g.quantity;
                //                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                //                    //drsum["tax"] = g.tax;
                //                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");

                //                    drsum["Z"] = Convert.ToDouble(g.Zero).ToString("f2");
                //                    drsum["F"] = Convert.ToDouble(g.Five).ToString("f2");
                //                    drsum["TW"] = Convert.ToDouble(g.twelve).ToString("f2");
                //                    drsum["EG"] = Convert.ToDouble(g.eghteen).ToString("f2");
                //                    drsum["TE"] = Convert.ToDouble(g.twentyeight).ToString("f2");


                //                    //drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                //                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                //                    dssum.Tables[0].Rows.Add(drsum);
                //                }
                //                #endregion
                //            }
                //            gvsummary.Visible = true;
                //            gvdetailed.Visible = false;
                //            Gst.Visible = false;
                //            gvsummary.DataSource = dssum.Tables[0];
                //            gvsummary.DataBind();


                //        }
                //        else
                //        {
                //            gvsummary.DataSource = null;
                //            gvsummary.DataBind();
                //        }
                //    }

                //}
            }
         //  else if (radbtnlist.SelectedValue == "3")
            {
                //if (dsbranch1.Tables[0].Rows.Count > 0)
                //{
                //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //    string[] wordArray = sales.Split('_');

                //    brach = wordArray[1];
                //    string name = string.Empty;


                //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                //    //  string paymode = drpPayment.SelectedItem.Value;



                //    DataTable dtsum = new DataTable();
                //    DataSet dssum = new DataSet();
                //    DataRow drsum;

                //    //dtsum.Columns.Add("paymode");
                //    //dtsum.Columns.Add("No");
                //    //dtsum.Columns.Add("paymenttype");
                //    dtsum.Columns.Add("Fbillno");
                //    dtsum.Columns.Add("Tbillno");
                //    dtsum.Columns.Add("cnt");

                //    dtsum.Columns.Add("BillDate");
                //    //dtsum.Columns.Add("Category");
                //    //dtsum.Columns.Add("definition");
                //    //dtsum.Columns.Add("unitprice");
                //    dtsum.Columns.Add("quantity");
                //    dtsum.Columns.Add("amount");
                //    //dtsum.Columns.Add("tax");
                //    dtsum.Columns.Add("disc");
                //    dtsum.Columns.Add("Z");
                //    dtsum.Columns.Add("Z1");
                //    dtsum.Columns.Add("F");
                //    dtsum.Columns.Add("F1");
                //    dtsum.Columns.Add("TW");
                //    dtsum.Columns.Add("TW1");
                //    dtsum.Columns.Add("EG");
                //    dtsum.Columns.Add("EG1");
                //    dtsum.Columns.Add("TE");
                //    dtsum.Columns.Add("TE1");

                //    dtsum.Columns.Add("TotalValue");

                //    dssum.Tables.Add(dtsum);



                //    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Sales GST Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                //    DataSet dcustbranch = objbs.New_TaxReport_gst(brach, sFrom, sTo, "Y");
                //    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                //    if (dcustbranch.Tables[0].Rows.Count > 0)
                //    {




                //        if (dcustbranch.Tables[0].Rows.Count > 0)
                //        {
                //            #region

                //            DataTable dtraws = dcustbranch.Tables[0];

                //            var result1 = from r in dtraws.AsEnumerable()
                //                          group r by new
                //                          {
                //                              // paymode = r["paymode"],
                //                              // paymenttype = r["paymenttype"],
                //                              // billno = r["billno"],
                //                              // orderno = r["no"],
                //                              BillDate = r["BillDate"],
                //                              // Category = r["Category"],
                //                              // definition = r["definition"],
                //                              // unitprice = r["unitprice"],
                //                              // quantity = r["quantity"],
                //                              // amount = r["amount"],
                //                              //  tax = r["tax"],
                //                              //  GST = r["GST"],
                //                              //disc = r["disc"],
                //                              //TotalValue = r["TotalValue"],
                //                          } into raw
                //                          select new
                //                          {
                //                              //   paymode = raw.Key.paymode,
                //                              //   paymenttype = raw.Key.paymenttype,
                //                              //  billno = raw.Key.billno,
                //                              BillDate = raw.Key.BillDate,
                //                              //  Category = raw.Key.Category,
                //                              //  definition = raw.Key.definition,
                //                              //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                //                              // unitprice = raw.Key.unitprice,
                //                              quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                //                              amount = raw.Sum(x => Convert.ToDouble(x["amount"])),

                //                              Zero = raw.Sum(x => Convert.ToDouble(x["Z"])),
                //                              Five = raw.Sum(x => Convert.ToDouble(x["F"])),
                //                              twelve = raw.Sum(x => Convert.ToDouble(x["TW"])),
                //                              eghteen = raw.Sum(x => Convert.ToDouble(x["EG"])),
                //                              twentyeight = raw.Sum(x => Convert.ToDouble(x["TE"])),


                //                              Zero1 = raw.Sum(x => Convert.ToDouble(x["Z1"])),
                //                              Five1 = raw.Sum(x => Convert.ToDouble(x["F1"])),
                //                              twelve1 = raw.Sum(x => Convert.ToDouble(x["TW1"])),
                //                              eghteen1 = raw.Sum(x => Convert.ToDouble(x["EG1"])),
                //                              twentyeight1 = raw.Sum(x => Convert.ToDouble(x["TE1"])),


                //                              disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                //                              TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),

                //                              //  orderno = raw.Key.orderno
                //                              //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                //                          };


                //            foreach (var g in result1)
                //            {
                //                drsum = dtsum.NewRow();

                //                //    drsum["paymode"] = g.paymode;
                //                //    drsum["No"] = g.orderno;
                //                //  drsum["paymenttype"] = g.paymenttype;
                //                // drsum["billno"] = g.billno;
                //                drsum["BillDate"] = g.BillDate;

                //                DateTime Fbilldate = Convert.ToDateTime(g.BillDate);
                //                DataSet dfromtobill = objbs.getSalesBillCount_firsttobill(sTableName, Fbilldate, Fbilldate, "Y");
                //                if (dfromtobill.Tables[0].Rows.Count > 0)
                //                {
                //                    drsum["Fbillno"] = dfromtobill.Tables[0].Rows[0]["StartBill"].ToString();
                //                    drsum["Tbillno"] = dfromtobill.Tables[0].Rows[0]["EndBill"].ToString();
                //                    drsum["cnt"] = dfromtobill.Tables[0].Rows[0]["BillCount"].ToString();
                //                }
                //                else
                //                {
                //                    drsum["Fbillno"] = "0 - something Went Wrong";
                //                    drsum["Tbillno"] = "0 - something Went Wrong";
                //                    drsum["cnt"] = "0";
                //                }
                //                //  drsum["Category"] = g.Category;
                //                // drsum["definition"] = g.definition;
                //                // drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                //                drsum["quantity"] = Convert.ToDouble(g.quantity).ToString("f2");
                //                drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                //                //drsum["tax"] = g.tax;
                //                drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");

                //                drsum["Z"] = Convert.ToDouble(g.Zero).ToString("f2");
                //                drsum["F"] = Convert.ToDouble(g.Five).ToString("f2");
                //                drsum["TW"] = Convert.ToDouble(g.twelve).ToString("f2");
                //                drsum["EG"] = Convert.ToDouble(g.eghteen).ToString("f2");
                //                drsum["TE"] = Convert.ToDouble(g.twentyeight).ToString("f2");


                //                drsum["Z1"] = Convert.ToDouble(g.Zero1).ToString("f2");
                //                drsum["F1"] = Convert.ToDouble(g.Five1).ToString("f2");
                //                drsum["TW1"] = Convert.ToDouble(g.twelve1).ToString("f2");
                //                drsum["EG1"] = Convert.ToDouble(g.eghteen1).ToString("f2");
                //                drsum["TE1"] = Convert.ToDouble(g.twentyeight1).ToString("f2");


                //                //drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                //                drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                //                dssum.Tables[0].Rows.Add(drsum);
                //            }
                //            #endregion
                //        }
                //        gvdetailed.Visible = false;
                //        gvsummary.Visible = false;
                //        Gst.Visible = true;
                //        Gst.DataSource = dssum.Tables[0];
                //        Gst.DataBind();


                //    }
                //    else
                //    {
                //        Gst.DataSource = null;
                //        Gst.DataBind();
                //    }
                //}

            }


        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            //DataSet dCustReport = objbs.CustomerSalesAdmin();
            //gvCustsales.DataSource = dCustReport.Tables[0];
            //gvCustsales.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            if (radbtnlist.SelectedValue == "2")
            {
                Response.AddHeader("content-disposition", "attachment;filename= GstDetailReport.xls");
            }
            else
            {
                Response.AddHeader("content-disposition", "attachment;filename= GstSummaryReport.xls");
            }
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            divPrint.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExport_ClickOld(object sender, EventArgs e)
        {
            //DataSet dt = new DataSet();
            //GridView gridview = new GridView();
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //string name = string.Empty;



            //gridview.Caption = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");



            //if (radbtnlist.SelectedValue == "2")
            //{
            //    if (dsbranch1.Tables[0].Rows.Count > 0)
            //    {
            //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //        string[] wordArray = sales.Split('_');

            //        brach = wordArray[1];
            //        //string name = string.Empty;


            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;



            //        DataTable dtsum = new DataTable();
            //        DataSet dssum = new DataSet();
            //        DataRow drsum;

            //        dtsum.Columns.Add("paymode");
            //        dtsum.Columns.Add("No");
            //        dtsum.Columns.Add("paymenttype");
            //        dtsum.Columns.Add("billno");
            //        dtsum.Columns.Add("BillDate");
            //        dtsum.Columns.Add("Category");
            //        dtsum.Columns.Add("definition");
            //        dtsum.Columns.Add("unitprice");
            //        dtsum.Columns.Add("quantity");
            //        dtsum.Columns.Add("amount");
            //        dtsum.Columns.Add("tax");
            //        dtsum.Columns.Add("GST");
            //        dtsum.Columns.Add("disc");
            //        dtsum.Columns.Add("TotalValue");
            //        dtsum.Columns.Add("name");
            //        //dtsum.Columns.Add("Saletypemargin");
            //        //dtsum.Columns.Add("commission");
            //        //dtsum.Columns.Add("gstmargin");
            //        //dtsum.Columns.Add("commisionfortax");
            //        //dtsum.Columns.Add("Gateway");
            //        //dtsum.Columns.Add("gateWayValue");
            //        //dtsum.Columns.Add("Total");

            //        dssum.Tables.Add(dtsum);



            //        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //        DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
            //        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
            //        if (dcustbranch.Tables[0].Rows.Count > 0)
            //        {




            //            if (dcustbranch.Tables[0].Rows.Count > 0)
            //            {
            //                #region

            //                DataTable dtraws = dcustbranch.Tables[0];

            //                var result1 = from r in dtraws.AsEnumerable()
            //                              group r by new
            //                              {
            //                                  paymode = r["paymode"],
            //                                  paymenttype = r["paymenttype"],
            //                                  billno = r["billno"],
            //                                  orderno = r["no"],
            //                                  BillDate = r["BillDate"],
            //                                  Category = r["Category"],
            //                                  definition = r["definition"],
            //                                  unitprice = r["unitprice"],
            //                                  quantity = r["quantity"],
            //                                  amount = r["amount"],
            //                                  tax = r["tax"],
            //                                  GST = r["GST"],
            //                                  disc = r["disc"],
            //                                  TotalValue = r["TotalValue"],
            //                                  name = r["name"],
            //                                  //Saletypemargin = r["Saletypemargin"],
            //                                  //commission = r["commission"],
            //                                  //gstmargin = r["gstmargin"],
            //                                  //commisionfortax = r["commisionfortax"],
            //                                  //Gateway = r["Gateway"]

            //                              } into raw
            //                              select new
            //                              {
            //                                  paymode = raw.Key.paymode,
            //                                  paymenttype = raw.Key.paymenttype,
            //                                  billno = raw.Key.billno,
            //                                  BillDate = raw.Key.BillDate,
            //                                  Category = raw.Key.Category,
            //                                  definition = raw.Key.definition,
            //                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
            //                                  unitprice = raw.Key.unitprice,
            //                                  quantity = raw.Key.quantity,
            //                                  amount = raw.Key.amount,
            //                                  tax = raw.Key.tax,
            //                                  GST = raw.Key.GST,
            //                                  disc = raw.Key.disc,
            //                                  TotalValue = raw.Key.TotalValue,
            //                                  name = raw.Key.name,
            //                                  //Saletypemargin = raw.Key.Saletypemargin,
            //                                  //commission = raw.Key.commission,
            //                                  //gstmargin = raw.Key.gstmargin,
            //                                  //commisionfortax = raw.Key.commisionfortax,
            //                                  //Gateway = raw.Key.Gateway,
            //                                  orderno = raw.Key.orderno
            //                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
            //                              };


            //                foreach (var g in result1)
            //                {
            //                    drsum = dtsum.NewRow();

            //                    drsum["paymode"] = g.paymode;
            //                    drsum["No"] = g.orderno;
            //                    drsum["paymenttype"] = g.paymenttype;
            //                    drsum["billno"] = g.billno;
            //                    drsum["BillDate"] = g.BillDate;
            //                    drsum["Category"] = g.Category;
            //                    drsum["name"] = g.name;
            //                    drsum["definition"] = g.definition;
            //                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
            //                    drsum["quantity"] = g.quantity;
            //                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
            //                    drsum["tax"] = g.tax;
            //                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
            //                    drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
            //                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
            //                    //drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
            //                    //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
            //                    //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
            //                    //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
            //                    //drsum["Gateway"] = g.Gateway;
            //                    //drsum["gateWayValue"] = "0";
            //                    //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
            //                    //drsum["Total"] = tot.ToString("f2");
            //                    dssum.Tables[0].Rows.Add(drsum);
            //                }
            //                #endregion
            //            }
            //            gvdetailed.Visible = true;
            //            gvsummary.Visible = false;
            //            gvdetailed.DataSource = dssum.Tables[0];
            //            gvdetailed.DataBind();


            //        }
            //        else
            //        {
            //            gvdetailed.DataSource = null;
            //            gvdetailed.DataBind();
            //        }
            //    }
            //    else
            //    {

            //        if (dsbranch1.Tables[0].Rows.Count > 0)
            //        {
            //            string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //            string[] wordArray = sales.Split('_');

            //            brach = wordArray[1];
            //            //  string name = string.Empty;


            //            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //            DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //            string paymode = drpPayment.SelectedItem.Value;



            //            DataTable dtsum = new DataTable();
            //            DataSet dssum = new DataSet();
            //            DataRow drsum;

            //            dtsum.Columns.Add("paymode");
            //            dtsum.Columns.Add("No");
            //            dtsum.Columns.Add("paymenttype");
            //            dtsum.Columns.Add("billno");
            //            dtsum.Columns.Add("BillDate");
            //            dtsum.Columns.Add("Category");
            //            dtsum.Columns.Add("definition");
            //            dtsum.Columns.Add("unitprice");
            //            dtsum.Columns.Add("quantity");
            //            dtsum.Columns.Add("amount");
            //            dtsum.Columns.Add("tax");
            //            dtsum.Columns.Add("GST");
            //            dtsum.Columns.Add("Disc");
            //            dtsum.Columns.Add("TotalValue");
            //            dtsum.Columns.Add("name");
            //            //dtsum.Columns.Add("Saletypemargin");
            //            //dtsum.Columns.Add("commission");
            //            //dtsum.Columns.Add("gstmargin");
            //            //dtsum.Columns.Add("commisionfortax");
            //            //dtsum.Columns.Add("Gateway");
            //            //dtsum.Columns.Add("gateWayValue");
            //            //dtsum.Columns.Add("Total");

            //            dssum.Tables.Add(dtsum);



            //            lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //            DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
            //            //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
            //            if (dcustbranch.Tables[0].Rows.Count > 0)
            //            {




            //                if (dcustbranch.Tables[0].Rows.Count > 0)
            //                {
            //                    #region

            //                    DataTable dtraws = dcustbranch.Tables[0];

            //                    var result1 = from r in dtraws.AsEnumerable()
            //                                  group r by new
            //                                  {
            //                                      paymode = r["paymode"],
            //                                      orderno = r["No"],
            //                                      paymenttype = r["paymenttype"],
            //                                      billno = r["billno"],
            //                                      BillDate = r["BillDate"],
            //                                      Category = r["Category"],
            //                                      definition = r["definition"],
            //                                      unitprice = r["unitprice"],
            //                                      quantity = r["quantity"],
            //                                      amount = r["amount"],
            //                                      tax = r["tax"],
            //                                      GST = r["GST"],
            //                                      disc = r["disc"],
            //                                      name = r["Name"],
            //                                      TotalValue = r["TotalValue"],
            //                                      //Saletypemargin = r["Saletypemargin"],
            //                                      //commission = r["commission"],
            //                                      //gstmargin = r["gstmargin"],
            //                                      //commisionfortax = r["commisionfortax"],
            //                                      //Gateway = r["Gateway"]

            //                                  } into raw
            //                                  select new
            //                                  {
            //                                      paymode = raw.Key.paymode,
            //                                      orderno = raw.Key.orderno,
            //                                      paymenttype = raw.Key.paymenttype,
            //                                      billno = raw.Key.billno,
            //                                      BillDate = raw.Key.BillDate,
            //                                      Category = raw.Key.Category,
            //                                      definition = raw.Key.definition,
            //                                      //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
            //                                      unitprice = raw.Key.unitprice,
            //                                      quantity = raw.Key.quantity,
            //                                      amount = raw.Key.amount,
            //                                      tax = raw.Key.tax,
            //                                      GST = raw.Key.GST,
            //                                      disc = raw.Key.disc,
            //                                      name = raw.Key.name,
            //                                      TotalValue = raw.Key.TotalValue,
            //                                      //Saletypemargin = raw.Key.Saletypemargin,
            //                                      //commission = raw.Key.commission,
            //                                      //gstmargin = raw.Key.gstmargin,
            //                                      //commisionfortax = raw.Key.commisionfortax,
            //                                      //Gateway = raw.Key.Gateway,
            //                                      //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
            //                                  };


            //                    foreach (var g in result1)
            //                    {
            //                        drsum = dtsum.NewRow();

            //                        drsum["paymode"] = g.paymode;
            //                        drsum["No"] = g.orderno;
            //                        drsum["paymenttype"] = g.paymenttype;
            //                        drsum["billno"] = g.billno;
            //                        drsum["BillDate"] = g.BillDate;
            //                        drsum["Category"] = g.Category;
            //                        drsum["Name"] = g.name;
            //                        drsum["definition"] = g.definition;
            //                        drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
            //                        drsum["quantity"] = g.quantity;
            //                        drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
            //                        drsum["tax"] = g.tax;
            //                        drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
            //                        drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
            //                        drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
            //                        //drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
            //                        //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
            //                        //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
            //                        //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
            //                        //drsum["Gateway"] = g.Gateway;
            //                        //drsum["gateWayValue"] = "0";
            //                        //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
            //                        //drsum["Total"] = tot.ToString("f2");
            //                        dssum.Tables[0].Rows.Add(drsum);
            //                    }
            //                    #endregion
            //                }
            //                gvdetailed.Visible = true;
            //                gvsummary.Visible = false;
            //                gvdetailed.DataSource = dssum.Tables[0];
            //                gvdetailed.DataBind();


            //            }
            //            else
            //            {
            //                gvdetailed.DataSource = null;
            //                gvdetailed.DataBind();
            //            }



            //        }


            //    }


            //}
            //else
            //{
            //    if (dsbranch1.Tables[0].Rows.Count > 0)
            //    {
            //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //        string[] wordArray = sales.Split('_');

            //        brach = wordArray[1];
            //        // string name = string.Empty;


            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;



            //        DataTable dtsum = new DataTable();
            //        DataSet dssum = new DataSet();
            //        DataRow drsum;

            //        dtsum.Columns.Add("paymode");
            //        dtsum.Columns.Add("No");
            //        dtsum.Columns.Add("paymenttype");
            //        dtsum.Columns.Add("billno");
            //        dtsum.Columns.Add("BillDate");
            //        //  dtsum.Columns.Add("Category");
            //        //  dtsum.Columns.Add("definition");
            //        dtsum.Columns.Add("unitprice");
            //        dtsum.Columns.Add("quantity");
            //        dtsum.Columns.Add("amount");
            //        //   dtsum.Columns.Add("tax");
            //        dtsum.Columns.Add("GST");
            //        dtsum.Columns.Add("disc");
            //        dtsum.Columns.Add("TotalValue");
            //        dtsum.Columns.Add("name");
            //        dtsum.Columns.Add("Saletypemargin");
            //        //dtsum.Columns.Add("commission");
            //        //dtsum.Columns.Add("gstmargin");
            //        //dtsum.Columns.Add("commisionfortax");
            //        //dtsum.Columns.Add("Gateway");
            //        //dtsum.Columns.Add("gateWayValue");
            //        //dtsum.Columns.Add("Total");

            //        dssum.Tables.Add(dtsum);



            //        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //        DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
            //        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
            //        if (dcustbranch.Tables[0].Rows.Count > 0)
            //        {




            //            if (dcustbranch.Tables[0].Rows.Count > 0)
            //            {
            //                #region

            //                DataTable dtraws = dcustbranch.Tables[0];

            //                var result1 = from r in dtraws.AsEnumerable()
            //                              group r by new
            //                              {
            //                                  paymode = r["paymode"],
            //                                  orderno = r["No"],
            //                                  paymenttype = r["paymenttype"],
            //                                  billno = r["billno"],
            //                                  BillDate = r["BillDate"],
            //                                  name = r["Name"],
            //                                  //  Category = r["Category"],
            //                                  //   definition = r["definition"],
            //                                  //     unitprice = r["unitprice"],
            //                                  //     quantity = r["quantity"],
            //                                  //     amount = r["amount"],
            //                                  //   tax = r["tax"],
            //                                  //     GST = r["GST"],
            //                                  //    TotalValue = r["TotalValue"],
            //                                  Saletypemargin = r["Saletypemargin"],
            //                                  ////    commission = r["commission"],
            //                                  //gstmargin = r["gstmargin"],
            //                                  ////   commisionfortax = r["commisionfortax"],
            //                                  //Gateway = r["Gateway"]

            //                              } into raw
            //                              select new
            //                              {
            //                                  paymode = raw.Key.paymode,
            //                                  orderno = raw.Key.orderno,
            //                                  paymenttype = raw.Key.paymenttype,
            //                                  billno = raw.Key.billno,
            //                                  BillDate = raw.Key.BillDate,
            //                                  name = raw.Key.name,
            //                                  //  Category = raw.Key.Category,
            //                                  //  definition = raw.Key.definition,
            //                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
            //                                  unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
            //                                  quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
            //                                  amount = raw.Sum(x => Convert.ToDouble(x["amount"])),
            //                                  //  tax = raw.Key.tax,
            //                                  GST = raw.Sum(x => Convert.ToDouble(x["GST"])),
            //                                  disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
            //                                  TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
            //                                  Saletypemargin = raw.Key.Saletypemargin,
            //                                  //commission = raw.Sum(x => Convert.ToDouble(x["commission"])),
            //                                  //gstmargin = raw.Key.gstmargin,
            //                                  //commisionfortax = raw.Sum(x => Convert.ToDouble(x["commisionfortax"])),
            //                                  //Gateway = raw.Key.Gateway,
            //                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
            //                              };


            //                foreach (var g in result1)
            //                {
            //                    drsum = dtsum.NewRow();

            //                    drsum["paymode"] = g.paymode;
            //                    drsum["No"] = g.orderno;
            //                    drsum["paymenttype"] = g.paymenttype;
            //                    drsum["billno"] = g.billno;
            //                    drsum["BillDate"] = g.BillDate;
            //                    drsum["Name"] = g.name;
            //                    //   drsum["Category"] = g.Category;
            //                    //  drsum["definition"] = g.definition;
            //                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
            //                    drsum["quantity"] = g.quantity;
            //                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
            //                    // drsum["tax"] = g.tax;
            //                    drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
            //                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
            //                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
            //                    drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
            //                    //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
            //                    //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
            //                    //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
            //                    //drsum["Gateway"] = g.Gateway;
            //                    //drsum["gateWayValue"] = "0";
            //                    //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
            //                    //drsum["Total"] = tot.ToString("f2");
            //                    dssum.Tables[0].Rows.Add(drsum);
            //                }
            //                #endregion
            //            }
            //            gvdetailed.Visible = false;
            //            gvsummary.Visible = true;
            //            gvsummary.DataSource = dssum.Tables[0];
            //            gvsummary.DataBind();
            //        }
            //        else
            //        {
            //            gvsummary.DataSource = null;
            //            gvsummary.DataBind();
            //        }
            //    }
            //    else
            //    {

            //        if (dsbranch1.Tables[0].Rows.Count > 0)
            //        {
            //            string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //            string[] wordArray = sales.Split('_');

            //            brach = wordArray[1];
            //            // string name = string.Empty;


            //            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //            DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //            string paymode = drpPayment.SelectedItem.Value;

            //            DataTable dtsum = new DataTable();
            //            DataSet dssum = new DataSet();
            //            DataRow drsum;

            //            dtsum.Columns.Add("paymode");
            //            dtsum.Columns.Add("No");
            //            dtsum.Columns.Add("paymenttype");
            //            dtsum.Columns.Add("billno");
            //            dtsum.Columns.Add("BillDate");
            //            //  dtsum.Columns.Add("Category");
            //            //  dtsum.Columns.Add("definition");
            //            dtsum.Columns.Add("unitprice");
            //            dtsum.Columns.Add("quantity");
            //            dtsum.Columns.Add("amount");
            //            //   dtsum.Columns.Add("tax");
            //            dtsum.Columns.Add("GST");
            //            dtsum.Columns.Add("disc");
            //            dtsum.Columns.Add("TotalValue");
            //            dtsum.Columns.Add("name");
            //            dtsum.Columns.Add("Saletypemargin");
            //            //dtsum.Columns.Add("commission");
            //            //dtsum.Columns.Add("gstmargin");
            //            //dtsum.Columns.Add("commisionfortax");
            //            //dtsum.Columns.Add("Gateway");
            //            //dtsum.Columns.Add("gateWayValue");
            //            //dtsum.Columns.Add("Total");

            //            dssum.Tables.Add(dtsum);



            //            lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //            DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
            //            //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
            //            if (dcustbranch.Tables[0].Rows.Count > 0)
            //            {




            //                if (dcustbranch.Tables[0].Rows.Count > 0)
            //                {
            //                    #region

            //                    DataTable dtraws = dcustbranch.Tables[0];

            //                    var result1 = from r in dtraws.AsEnumerable()
            //                                  group r by new
            //                                  {
            //                                      paymode = r["paymode"],
            //                                      orderno = r["No"],
            //                                      paymenttype = r["paymenttype"],
            //                                      billno = r["billno"],
            //                                      BillDate = r["BillDate"],
            //                                      name = r["name"],
            //                                      //  Category = r["Category"],
            //                                      //   definition = r["definition"],
            //                                      //     unitprice = r["unitprice"],
            //                                      //     quantity = r["quantity"],
            //                                      //     amount = r["amount"],
            //                                      //   tax = r["tax"],
            //                                      //     GST = r["GST"],
            //                                      //    TotalValue = r["TotalValue"],
            //                                      Saletypemargin = r["Saletypemargin"],
            //                                      ////    commission = r["commission"],
            //                                      //gstmargin = r["gstmargin"],
            //                                      ////   commisionfortax = r["commisionfortax"],
            //                                      //Gateway = r["Gateway"]

            //                                  } into raw
            //                                  select new
            //                                  {
            //                                      paymode = raw.Key.paymode,

            //                                      orderno = raw.Key.orderno,
            //                                      paymenttype = raw.Key.paymenttype,
            //                                      billno = raw.Key.billno,
            //                                      BillDate = raw.Key.BillDate,
            //                                      name = raw.Key.name,
            //                                      //  Category = raw.Key.Category,
            //                                      //  definition = raw.Key.definition,
            //                                      //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
            //                                      unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
            //                                      quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
            //                                      amount = raw.Sum(x => Convert.ToDouble(x["amount"])),
            //                                      //  tax = raw.Key.tax,
            //                                      GST = raw.Sum(x => Convert.ToDouble(x["GST"])),
            //                                      disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
            //                                      TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
            //                                      Saletypemargin = raw.Key.Saletypemargin,
            //                                      //commission = raw.Sum(x => Convert.ToDouble(x["commission"])),
            //                                      //gstmargin = raw.Key.gstmargin,
            //                                      //commisionfortax = raw.Sum(x => Convert.ToDouble(x["commisionfortax"])),
            //                                      //Gateway = raw.Key.Gateway,
            //                                      //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
            //                                  };


            //                    foreach (var g in result1)
            //                    {
            //                        drsum = dtsum.NewRow();

            //                        drsum["paymode"] = g.paymode;
            //                        drsum["No"] = g.orderno;
            //                        drsum["paymenttype"] = g.paymenttype;
            //                        drsum["billno"] = g.billno;
            //                        drsum["BillDate"] = g.BillDate;
            //                        drsum["name"] = g.name;
            //                        //   drsum["Category"] = g.Category;
            //                        //  drsum["definition"] = g.definition;
            //                        drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
            //                        drsum["quantity"] = g.quantity;
            //                        drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
            //                        // drsum["tax"] = g.tax;
            //                        drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
            //                        drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
            //                        drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
            //                        drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
            //                        //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
            //                        //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
            //                        //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
            //                        //drsum["Gateway"] = g.Gateway;
            //                        //drsum["gateWayValue"] = "0";
            //                        //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
            //                        //drsum["Total"] = tot.ToString("f2");
            //                        dssum.Tables[0].Rows.Add(drsum);
            //                    }
            //                    #endregion
            //                }
            //                gvdetailed.Visible = false;
            //                gvsummary.Visible = true;
            //                gvsummary.DataSource = dssum.Tables[0];
            //                gvsummary.DataBind();
            //            }
            //            else
            //            {
            //                gvsummary.DataSource = null;
            //                gvsummary.DataBind();
            //            }



            //        }


            //    }


            //}

            //string filename = "";
            //if (radbtnlist.SelectedValue == "1")
            //{
            //    filename = "salesreportSummary.xls";
            //}
            //else
            //{
            //    filename = "salesreportDetailed.xls";

            //}
            //System.IO.StringWriter tw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //DataGrid dgGrid = new DataGrid();
            //dgGrid.Caption = "Store :  " + BranchNAme + " " + StoreName + " Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            //dgGrid.DataSource = dt;
            //dgGrid.DataBind();
            //dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            //dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            //dgGrid.HeaderStyle.Font.Bold = true;
            ////Get the HTML for the control.
            //dgGrid.RenderControl(hw);
            ////Write the HTML back to the browser.
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            //this.EnableViewState = false;
            //Response.Write(tw.ToString());
            //Response.End();
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {



        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {

        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {




        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {

            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {


            lblCaption.Text = "Store :" + BranchNAme + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            if (radbtnlist.SelectedValue == "1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridSummary", "printGridSummary();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridDetails", "printGridDetails();", true);

            }
        }


        public void gvdetailed_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //unitprice += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "unitprice"));
                totopvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OpStockValue"));

                totstockinvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StockInValue"));
                totstockvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StockValue"));
                totsalesvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesValue"));

                totreturnvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalesReturnValue"));
                totmarginvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MarginValue"));
                totexp += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Expense"));
                totvarexp += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "VariableExp"));


                totprofit += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));

                //discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "percentage"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total : ";
                //  e.Row.Cells[7].Text = unitprice.ToString("f2");
                e.Row.Cells[2].Text = totopvalue.ToString(""+ratesetting+"");
                e.Row.Cells[3].Text = totstockinvalue.ToString("" + ratesetting + "");

                e.Row.Cells[4].Text = totsalesvalue.ToString("" + ratesetting + "");
                e.Row.Cells[5].Text = totreturnvalue.ToString("" + ratesetting + "");
                e.Row.Cells[6].Text = totstockvalue.ToString("" + ratesetting + "");
                e.Row.Cells[7].Text = totmarginvalue.ToString("" + ratesetting + "");
                e.Row.Cells[8].Text = totexp.ToString("" + ratesetting + "");
                e.Row.Cells[9].Text = totvarexp.ToString("" + ratesetting + "");



                e.Row.Cells[10].Text = totprofit.ToString("" + ratesetting + "");
                e.Row.Cells[11].Text = ((totprofit * 100) / totsalesvalue).ToString("" + ratesetting + "") + lblpercentage.Text; 


            }

        }
        public void gvsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                unitprice += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "unitprice"));
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "quantity"));

                subtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "amount"));
                gst0amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Z"));

                gst5amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "F"));
                gst12amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TW"));
                gst18amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "EG"));
                gst28amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TE"));


                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalValue"));

                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "disc"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = "Total :";
                e.Row.Cells[5].Text = unitprice.ToString("f2");
                e.Row.Cells[6].Text = Qty.ToString("f2");
                e.Row.Cells[7].Text = subtotal.ToString("f2");
                e.Row.Cells[8].Text = gst0amount.ToString("f2");
                e.Row.Cells[9].Text = gst5amount.ToString("f2");
                e.Row.Cells[10].Text = gst12amount.ToString("f2");
                e.Row.Cells[11].Text = gst18amount.ToString("f2");
                e.Row.Cells[12].Text = gst28amount.ToString("f2");



                // e.Row.Cells[8].Text = gstamount.ToString("f2");
                e.Row.Cells[13].Text = discvalue.ToString("f2");
                e.Row.Cells[14].Text = totalvalue.ToString("f2");


            }

        }

        public void Gst_onrowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //  unitprice += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "unitprice"));
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "quantity"));

                subtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "amount"));
                gst0amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Z"));
                gst0amount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Z1"));

                gst5amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "F"));
                gst5amount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "F1"));


                gst12amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TW"));
                gst12amount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TW1"));


                gst18amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "EG"));
                gst18amount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "EG1"));


                gst28amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TE"));
                gst28amount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TE1"));


                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalValue"));

                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "disc"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total :";
                // e.Row.Cells[5].Text = unitprice.ToString("f2");
                e.Row.Cells[5].Text = Qty.ToString("f2");
                e.Row.Cells[6].Text = subtotal.ToString("f2");
                e.Row.Cells[7].Text = gst0amount.ToString("f2");
                e.Row.Cells[8].Text = gst0amount1.ToString("f2");


                e.Row.Cells[9].Text = gst5amount.ToString("f2");
                e.Row.Cells[10].Text = gst5amount1.ToString("f2");

                e.Row.Cells[11].Text = gst12amount.ToString("f2");
                e.Row.Cells[12].Text = gst12amount1.ToString("f2");

                e.Row.Cells[13].Text = gst18amount.ToString("f2");
                e.Row.Cells[14].Text = gst18amount1.ToString("f2");

                e.Row.Cells[15].Text = gst28amount.ToString("f2");
                e.Row.Cells[16].Text = gst28amount1.ToString("f2");



                // e.Row.Cells[8].Text = gstamount.ToString("f2");
                e.Row.Cells[17].Text = discvalue.ToString("f2");
                e.Row.Cells[18].Text = totalvalue.ToString("f2");


            }

        }
    }
}