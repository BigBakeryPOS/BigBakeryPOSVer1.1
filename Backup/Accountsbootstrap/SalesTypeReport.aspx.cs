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
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class SalesTypeReport : System.Web.UI.Page
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

        double unitprice = 0, Qty = 0, subtotal = 0, gstamount = 0, totalvalue = 0, commamount = 0, commgstamnt = 0, gatwaycharge = 0, grandtot = 0, discvalue = 0;


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

            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet paymode = objbs.Paymodevalues(sTableName);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drpPayment.DataSource = paymode.Tables[0];
                    drpPayment.DataTextField = "PayMode";
                    drpPayment.DataValueField = "Value";
                    drpPayment.DataBind();
                    drpPayment.Items.Insert(0, "All");
                }

                DataSet getsalestype = objbs.GetSalesTypeForSales();
                if (getsalestype.Tables[0].Rows.Count > 0)
                {
                    drpsalestype.DataSource = getsalestype.Tables[0];
                    drpsalestype.DataTextField = "PaymentType";
                    drpsalestype.DataValueField = "SalesTypeID";
                    drpsalestype.DataBind();
                    drpsalestype.Items.Insert(0, "All");
                }


                txtfromdate.Enabled = true;
                txttodate.Enabled = true;
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
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            // if (chkDiscout.Checked == true)
            if (radbtnlist.SelectedValue == "2")
            {
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;



                    DataTable dtsum = new DataTable();
                    DataSet dssum = new DataSet();
                    DataRow drsum;

                    dtsum.Columns.Add("paymode");
                    dtsum.Columns.Add("No");
                    dtsum.Columns.Add("paymenttype");
                    dtsum.Columns.Add("billno");
                    dtsum.Columns.Add("BillDate");
                    dtsum.Columns.Add("Category");
                    dtsum.Columns.Add("definition");
                    dtsum.Columns.Add("unitprice");
                    dtsum.Columns.Add("quantity");
                    dtsum.Columns.Add("amount");
                    dtsum.Columns.Add("tax");
                    dtsum.Columns.Add("GST");
                    dtsum.Columns.Add("TotalValue");
                    dtsum.Columns.Add("Saletypemargin");
                    dtsum.Columns.Add("commission");
                    dtsum.Columns.Add("gstmargin");
                    dtsum.Columns.Add("commisionfortax");
                    dtsum.Columns.Add("Gateway");
                    dtsum.Columns.Add("gateWayValue");
                    dtsum.Columns.Add("Total");
                    dtsum.Columns.Add("disc");

                    dssum.Tables.Add(dtsum);



                    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {




                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {
                            #region

                            DataTable dtraws = dcustbranch.Tables[0];

                            var result1 = from r in dtraws.AsEnumerable()
                                          group r by new
                                          {
                                              paymode = r["paymode"],
                                              paymenttype = r["paymenttype"],
                                              billno = r["billno"],
                                              orderno = r["no"],
                                              BillDate = r["BillDate"],
                                              Category = r["Category"],
                                              definition = r["definition"],
                                              unitprice = r["unitprice"],
                                              quantity = r["quantity"],
                                              amount = r["amount"],
                                              tax = r["tax"],
                                              GST = r["GST"],
                                              disc = r["disc"],
                                              TotalValue = r["TotalValue"],
                                              Saletypemargin = r["Saletypemargin"],
                                              commission = r["commission"],
                                              gstmargin = r["gstmargin"],
                                              commisionfortax = r["commisionfortax"],
                                              Gateway = r["Gateway"]

                                          } into raw
                                          select new
                                          {
                                              paymode = raw.Key.paymode,
                                              paymenttype = raw.Key.paymenttype,
                                              billno = raw.Key.billno,
                                              BillDate = raw.Key.BillDate,
                                              Category = raw.Key.Category,
                                              definition = raw.Key.definition,
                                              //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                              unitprice = raw.Key.unitprice,
                                              quantity = raw.Key.quantity,
                                              amount = raw.Key.amount,
                                              tax = raw.Key.tax,
                                              GST = raw.Key.GST,
                                              disc = raw.Key.disc,
                                              TotalValue = raw.Key.TotalValue,
                                              Saletypemargin = raw.Key.Saletypemargin,
                                              commission = raw.Key.commission,
                                              gstmargin = raw.Key.gstmargin,
                                              commisionfortax = raw.Key.commisionfortax,
                                              Gateway = raw.Key.Gateway,
                                              orderno = raw.Key.orderno
                                              //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                          };


                            foreach (var g in result1)
                            {
                                drsum = dtsum.NewRow();

                                drsum["paymode"] = g.paymode;
                                drsum["No"] = g.orderno;
                                drsum["paymenttype"] = g.paymenttype;
                                drsum["billno"] = g.billno;
                             //   drsum["BillDate"] = g.BillDate;
                                //updated
                                drsum["BillDate"] = Convert.ToDateTime(g.BillDate).ToString("dd/MMM/yyyy hh:mm:ss tt");

                                drsum["Category"] = g.Category;
                                drsum["definition"] = g.definition;
                                drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                drsum["quantity"] = g.quantity;
                                drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                drsum["tax"] = g.tax;
                                drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                drsum["Gateway"] = g.Gateway;
                                drsum["gateWayValue"] = "0";
                                double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                drsum["Total"] = tot.ToString("f2");
                                dssum.Tables[0].Rows.Add(drsum);
                            }
                            #endregion
                        }
                        gvdetailed.Visible = true;
                        gvsummary.Visible = false;
                        gvdetailed.DataSource = dssum.Tables[0];
                        gvdetailed.DataBind();


                    }
                    else
                    {
                        gvdetailed.DataSource = null;
                        gvdetailed.DataBind();
                    }
                }
                else
                {

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];
                        string name = string.Empty;


                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;

                        //lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                        //DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                        ////  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                        //if (dcustbranch.Tables[0].Rows.Count > 0)
                        //{
                        //    gvdetailed.DataSource = dcustbranch.Tables[0];
                        //    gvdetailed.DataBind();
                        //}

                        DataTable dtsum = new DataTable();
                        DataSet dssum = new DataSet();
                        DataRow drsum;

                        dtsum.Columns.Add("paymode");
                        dtsum.Columns.Add("No");
                        dtsum.Columns.Add("paymenttype");
                        dtsum.Columns.Add("billno");
                        dtsum.Columns.Add("BillDate");
                        dtsum.Columns.Add("Category");
                        dtsum.Columns.Add("definition");
                        dtsum.Columns.Add("unitprice");
                        dtsum.Columns.Add("quantity");
                        dtsum.Columns.Add("amount");
                        dtsum.Columns.Add("tax");
                        dtsum.Columns.Add("GST");
                        dtsum.Columns.Add("TotalValue");
                        dtsum.Columns.Add("Saletypemargin");
                        dtsum.Columns.Add("commission");
                        dtsum.Columns.Add("gstmargin");
                        dtsum.Columns.Add("commisionfortax");
                        dtsum.Columns.Add("Gateway");
                        dtsum.Columns.Add("gateWayValue");
                        dtsum.Columns.Add("Total");
                        dtsum.Columns.Add("Disc");

                        dssum.Tables.Add(dtsum);



                        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                        DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {




                            if (dcustbranch.Tables[0].Rows.Count > 0)
                            {
                                #region

                                DataTable dtraws = dcustbranch.Tables[0];

                                var result1 = from r in dtraws.AsEnumerable()
                                              group r by new
                                              {
                                                  paymode = r["paymode"],
                                                  orderno = r["No"],
                                                  paymenttype = r["paymenttype"],
                                                  billno = r["billno"],
                                                  BillDate = r["BillDate"],
                                                  Category = r["Category"],
                                                  definition = r["definition"],
                                                  unitprice = r["unitprice"],
                                                  quantity = r["quantity"],
                                                  amount = r["amount"],
                                                  tax = r["tax"],
                                                  GST = r["GST"],
                                                  disc = r["disc"],
                                                  TotalValue = r["TotalValue"],
                                                  Saletypemargin = r["Saletypemargin"],
                                                  commission = r["commission"],
                                                  gstmargin = r["gstmargin"],
                                                  commisionfortax = r["commisionfortax"],
                                                  Gateway = r["Gateway"]

                                              } into raw
                                              select new
                                              {
                                                  paymode = raw.Key.paymode,
                                                  orderno = raw.Key.orderno,
                                                  paymenttype = raw.Key.paymenttype,
                                                  billno = raw.Key.billno,
                                                  BillDate = raw.Key.BillDate,
                                                  Category = raw.Key.Category,
                                                  definition = raw.Key.definition,
                                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                                  unitprice = raw.Key.unitprice,
                                                  quantity = raw.Key.quantity,
                                                  amount = raw.Key.amount,
                                                  tax = raw.Key.tax,
                                                  GST = raw.Key.GST,
                                                  disc = raw.Key.disc,
                                                  TotalValue = raw.Key.TotalValue,
                                                  Saletypemargin = raw.Key.Saletypemargin,
                                                  commission = raw.Key.commission,
                                                  gstmargin = raw.Key.gstmargin,
                                                  commisionfortax = raw.Key.commisionfortax,
                                                  Gateway = raw.Key.Gateway,
                                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                              };


                                foreach (var g in result1)
                                {
                                    drsum = dtsum.NewRow();

                                    drsum["paymode"] = g.paymode;
                                    drsum["No"] = g.orderno;
                                    drsum["paymenttype"] = g.paymenttype;
                                    drsum["billno"] = g.billno;
                                    //updated
                                    drsum["BillDate"] = Convert.ToDateTime(g.BillDate).ToString("dd/MMM/yyyy hh:mm:ss tt");;
                                    drsum["Category"] = g.Category;
                                    drsum["definition"] = g.definition;
                                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                    drsum["quantity"] = g.quantity;
                                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                    drsum["tax"] = g.tax;
                                    drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                    drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                    drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                    drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                    drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                    drsum["Gateway"] = g.Gateway;
                                    drsum["gateWayValue"] = "0";
                                    double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                    drsum["Total"] = tot.ToString("f2");
                                    dssum.Tables[0].Rows.Add(drsum);
                                }
                                #endregion
                            }
                            gvdetailed.Visible = true;
                            gvsummary.Visible = false;
                            gvdetailed.DataSource = dssum.Tables[0];
                            gvdetailed.DataBind();


                        }
                        else
                        {
                            gvdetailed.DataSource = null;
                            gvdetailed.DataBind();
                        }



                    }


                }


            }
            else
            {
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;



                    DataTable dtsum = new DataTable();
                    DataSet dssum = new DataSet();
                    DataRow drsum;

                    dtsum.Columns.Add("paymode");
                    dtsum.Columns.Add("No");
                    dtsum.Columns.Add("paymenttype");
                    dtsum.Columns.Add("billno");
                    dtsum.Columns.Add("BillDate");
                    //  dtsum.Columns.Add("Category");
                    //  dtsum.Columns.Add("definition");
                    dtsum.Columns.Add("unitprice");
                    dtsum.Columns.Add("quantity");
                    dtsum.Columns.Add("amount");
                    //   dtsum.Columns.Add("tax");
                    dtsum.Columns.Add("GST");
                    dtsum.Columns.Add("disc");
                    dtsum.Columns.Add("TotalValue");
                    dtsum.Columns.Add("Saletypemargin");
                    dtsum.Columns.Add("commission");
                    dtsum.Columns.Add("gstmargin");
                    dtsum.Columns.Add("commisionfortax");
                    dtsum.Columns.Add("Gateway");
                    dtsum.Columns.Add("gateWayValue");
                    dtsum.Columns.Add("Total");

                    dssum.Tables.Add(dtsum);



                    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {




                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {
                            #region

                            DataTable dtraws = dcustbranch.Tables[0];

                            var result1 = from r in dtraws.AsEnumerable()
                                          group r by new
                                          {
                                              paymode = r["paymode"],
                                              orderno = r["No"],
                                              paymenttype = r["paymenttype"],
                                              billno = r["billno"],
                                              BillDate = r["BillDate"],
                                              //  Category = r["Category"],
                                              //   definition = r["definition"],
                                              //     unitprice = r["unitprice"],
                                              //     quantity = r["quantity"],
                                              //     amount = r["amount"],
                                              //   tax = r["tax"],
                                              //     GST = r["GST"],
                                              //    TotalValue = r["TotalValue"],
                                              Saletypemargin = r["Saletypemargin"],
                                              //    commission = r["commission"],
                                              gstmargin = r["gstmargin"],
                                              //   commisionfortax = r["commisionfortax"],
                                              Gateway = r["Gateway"]

                                          } into raw
                                          select new
                                          {
                                              paymode = raw.Key.paymode,
                                              orderno = raw.Key.orderno,
                                              paymenttype = raw.Key.paymenttype,
                                              billno = raw.Key.billno,
                                              BillDate = raw.Key.BillDate,
                                              //  Category = raw.Key.Category,
                                              //  definition = raw.Key.definition,
                                              //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                              unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
                                              quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                                              amount = raw.Sum(x => Convert.ToDouble(x["amount"])),
                                              //  tax = raw.Key.tax,
                                              GST = raw.Sum(x => Convert.ToDouble(x["GST"])),
                                              disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                                              TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                              Saletypemargin = raw.Key.Saletypemargin,
                                              commission = raw.Sum(x => Convert.ToDouble(x["commission"])),
                                              gstmargin = raw.Key.gstmargin,
                                              commisionfortax = raw.Sum(x => Convert.ToDouble(x["commisionfortax"])),
                                              Gateway = raw.Key.Gateway,
                                              //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                          };


                            foreach (var g in result1)
                            {
                                drsum = dtsum.NewRow();

                                drsum["paymode"] = g.paymode;
                                drsum["No"] = g.orderno;
                                drsum["paymenttype"] = g.paymenttype;
                                drsum["billno"] = g.billno;
                                //updated
                                drsum["BillDate"] = Convert.ToDateTime(g.BillDate).ToString("dd/MMM/yyyy hh:mm:ss tt");
                                //   drsum["Category"] = g.Category;
                                //  drsum["definition"] = g.definition;
                                drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                drsum["quantity"] = g.quantity;
                                drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                // drsum["tax"] = g.tax;
                                drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                drsum["Gateway"] = g.Gateway;
                                drsum["gateWayValue"] = "0";
                                double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                drsum["Total"] = tot.ToString("f2");
                                dssum.Tables[0].Rows.Add(drsum);
                            }
                            #endregion
                        }
                        gvdetailed.Visible = false;
                        gvsummary.Visible = true;
                        gvsummary.DataSource = dssum.Tables[0];
                        gvsummary.DataBind();
                    }
                    else
                    {
                        gvsummary.DataSource = null;
                        gvsummary.DataBind();
                    }
                }
                else
                {

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];
                        string name = string.Empty;


                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;

                        DataTable dtsum = new DataTable();
                        DataSet dssum = new DataSet();
                        DataRow drsum;

                        dtsum.Columns.Add("paymode");
                        dtsum.Columns.Add("No");
                        dtsum.Columns.Add("paymenttype");
                        dtsum.Columns.Add("billno");
                        dtsum.Columns.Add("BillDate");
                        //  dtsum.Columns.Add("Category");
                        //  dtsum.Columns.Add("definition");
                        dtsum.Columns.Add("unitprice");
                        dtsum.Columns.Add("quantity");
                        dtsum.Columns.Add("amount");
                        //   dtsum.Columns.Add("tax");
                        dtsum.Columns.Add("GST");
                        dtsum.Columns.Add("disc");
                        dtsum.Columns.Add("TotalValue");
                        dtsum.Columns.Add("Saletypemargin");
                        dtsum.Columns.Add("commission");
                        dtsum.Columns.Add("gstmargin");
                        dtsum.Columns.Add("commisionfortax");
                        dtsum.Columns.Add("Gateway");
                        dtsum.Columns.Add("gateWayValue");
                        dtsum.Columns.Add("Total");

                        dssum.Tables.Add(dtsum);



                        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                        DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {




                            if (dcustbranch.Tables[0].Rows.Count > 0)
                            {
                                #region

                                DataTable dtraws = dcustbranch.Tables[0];

                                var result1 = from r in dtraws.AsEnumerable()
                                              group r by new
                                              {
                                                  paymode = r["paymode"],
                                                  orderno = r["No"],
                                                  paymenttype = r["paymenttype"],
                                                  billno = r["billno"],
                                                  BillDate = r["BillDate"],
                                                  //  Category = r["Category"],
                                                  //   definition = r["definition"],
                                                  //     unitprice = r["unitprice"],
                                                  //     quantity = r["quantity"],
                                                  //     amount = r["amount"],
                                                  //   tax = r["tax"],
                                                  //     GST = r["GST"],
                                                  //    TotalValue = r["TotalValue"],
                                                  Saletypemargin = r["Saletypemargin"],
                                                  //    commission = r["commission"],
                                                  gstmargin = r["gstmargin"],
                                                  //   commisionfortax = r["commisionfortax"],
                                                  Gateway = r["Gateway"]

                                              } into raw
                                              select new
                                              {
                                                  paymode = raw.Key.paymode,

                                                  orderno = raw.Key.orderno,
                                                  paymenttype = raw.Key.paymenttype,
                                                  billno = raw.Key.billno,
                                                  BillDate = raw.Key.BillDate,
                                                  //  Category = raw.Key.Category,
                                                  //  definition = raw.Key.definition,
                                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                                  unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
                                                  quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                                                  amount = raw.Sum(x => Convert.ToDouble(x["amount"])),
                                                  //  tax = raw.Key.tax,
                                                  GST = raw.Sum(x => Convert.ToDouble(x["GST"])),
                                                  disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                                                  TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                                  Saletypemargin = raw.Key.Saletypemargin,
                                                  commission = raw.Sum(x => Convert.ToDouble(x["commission"])),
                                                  gstmargin = raw.Key.gstmargin,
                                                  commisionfortax = raw.Sum(x => Convert.ToDouble(x["commisionfortax"])),
                                                  Gateway = raw.Key.Gateway,
                                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                              };


                                foreach (var g in result1)
                                {
                                    drsum = dtsum.NewRow();

                                    drsum["paymode"] = g.paymode;
                                    drsum["No"] = g.orderno;
                                    drsum["paymenttype"] = g.paymenttype;
                                    drsum["billno"] = g.billno;
                                    drsum["BillDate"] = g.BillDate;
                                    //   drsum["Category"] = g.Category;
                                    //  drsum["definition"] = g.definition;
                                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                    drsum["quantity"] = g.quantity;
                                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                    // drsum["tax"] = g.tax;
                                    drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                    drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                    drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                    drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                    drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                    drsum["Gateway"] = g.Gateway;
                                    drsum["gateWayValue"] = "0";
                                    double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                    drsum["Total"] = tot.ToString("f2");
                                    dssum.Tables[0].Rows.Add(drsum);
                                }
                                #endregion
                            }
                            gvdetailed.Visible = false;
                            gvsummary.Visible = true;
                            gvsummary.DataSource = dssum.Tables[0];
                            gvsummary.DataBind();
                        }
                        else
                        {
                            gvsummary.DataSource = null;
                            gvsummary.DataBind();
                        }



                    }


                }


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
            Response.AddHeader("content-disposition", "attachment;filename= SalesTypeReport.xls");
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
            DataSet dt = new DataSet();
            GridView gridview = new GridView();
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            string name = string.Empty;



            gridview.Caption = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");



            if (radbtnlist.SelectedValue == "2")
            {
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                    //string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;



                    DataTable dtsum = new DataTable();
                    DataSet dssum = new DataSet();
                    DataRow drsum;

                    dtsum.Columns.Add("paymode");
                    dtsum.Columns.Add("No");
                    dtsum.Columns.Add("paymenttype");
                    dtsum.Columns.Add("billno");
                    dtsum.Columns.Add("BillDate");
                    dtsum.Columns.Add("Category");
                    dtsum.Columns.Add("definition");
                    dtsum.Columns.Add("unitprice");
                    dtsum.Columns.Add("quantity");
                    dtsum.Columns.Add("amount");
                    dtsum.Columns.Add("tax");
                    dtsum.Columns.Add("GST");
                    dtsum.Columns.Add("disc");
                    dtsum.Columns.Add("TotalValue");
                    dtsum.Columns.Add("name");
                    //dtsum.Columns.Add("Saletypemargin");
                    //dtsum.Columns.Add("commission");
                    //dtsum.Columns.Add("gstmargin");
                    //dtsum.Columns.Add("commisionfortax");
                    //dtsum.Columns.Add("Gateway");
                    //dtsum.Columns.Add("gateWayValue");
                    //dtsum.Columns.Add("Total");

                    dssum.Tables.Add(dtsum);



                    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {




                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {
                            #region

                            DataTable dtraws = dcustbranch.Tables[0];

                            var result1 = from r in dtraws.AsEnumerable()
                                          group r by new
                                          {
                                              paymode = r["paymode"],
                                              paymenttype = r["paymenttype"],
                                              billno = r["billno"],
                                              orderno = r["no"],
                                              BillDate = r["BillDate"],
                                              Category = r["Category"],
                                              definition = r["definition"],
                                              unitprice = r["unitprice"],
                                              quantity = r["quantity"],
                                              amount = r["amount"],
                                              tax = r["tax"],
                                              GST = r["GST"],
                                              disc = r["disc"],
                                              TotalValue = r["TotalValue"],
                                              name = r["name"],
                                              //Saletypemargin = r["Saletypemargin"],
                                              //commission = r["commission"],
                                              //gstmargin = r["gstmargin"],
                                              //commisionfortax = r["commisionfortax"],
                                              //Gateway = r["Gateway"]

                                          } into raw
                                          select new
                                          {
                                              paymode = raw.Key.paymode,
                                              paymenttype = raw.Key.paymenttype,
                                              billno = raw.Key.billno,
                                              BillDate = raw.Key.BillDate,
                                              Category = raw.Key.Category,
                                              definition = raw.Key.definition,
                                              //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                              unitprice = raw.Key.unitprice,
                                              quantity = raw.Key.quantity,
                                              amount = raw.Key.amount,
                                              tax = raw.Key.tax,
                                              GST = raw.Key.GST,
                                              disc = raw.Key.disc,
                                              TotalValue = raw.Key.TotalValue,
                                              name = raw.Key.name,
                                              //Saletypemargin = raw.Key.Saletypemargin,
                                              //commission = raw.Key.commission,
                                              //gstmargin = raw.Key.gstmargin,
                                              //commisionfortax = raw.Key.commisionfortax,
                                              //Gateway = raw.Key.Gateway,
                                              orderno = raw.Key.orderno
                                              //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                          };


                            foreach (var g in result1)
                            {
                                drsum = dtsum.NewRow();

                                drsum["paymode"] = g.paymode;
                                drsum["No"] = g.orderno;
                                drsum["paymenttype"] = g.paymenttype;
                                drsum["billno"] = g.billno;
                                drsum["BillDate"] = g.BillDate;
                                drsum["Category"] = g.Category;
                                drsum["name"] = g.name;
                                drsum["definition"] = g.definition;
                                drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                drsum["quantity"] = g.quantity;
                                drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                drsum["tax"] = g.tax;
                                drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                //drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                //drsum["Gateway"] = g.Gateway;
                                //drsum["gateWayValue"] = "0";
                                //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                //drsum["Total"] = tot.ToString("f2");
                                dssum.Tables[0].Rows.Add(drsum);
                            }
                            #endregion
                        }
                        gvdetailed.Visible = true;
                        gvsummary.Visible = false;
                        gvdetailed.DataSource = dssum.Tables[0];
                        gvdetailed.DataBind();


                    }
                    else
                    {
                        gvdetailed.DataSource = null;
                        gvdetailed.DataBind();
                    }
                }
                else
                {

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];
                      //  string name = string.Empty;


                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;



                        DataTable dtsum = new DataTable();
                        DataSet dssum = new DataSet();
                        DataRow drsum;

                        dtsum.Columns.Add("paymode");
                        dtsum.Columns.Add("No");
                        dtsum.Columns.Add("paymenttype");
                        dtsum.Columns.Add("billno");
                        dtsum.Columns.Add("BillDate");
                        dtsum.Columns.Add("Category");
                        dtsum.Columns.Add("definition");
                        dtsum.Columns.Add("unitprice");
                        dtsum.Columns.Add("quantity");
                        dtsum.Columns.Add("amount");
                        dtsum.Columns.Add("tax");
                        dtsum.Columns.Add("GST");
                        dtsum.Columns.Add("Disc");
                        dtsum.Columns.Add("TotalValue");
                        dtsum.Columns.Add("name");
                        //dtsum.Columns.Add("Saletypemargin");
                        //dtsum.Columns.Add("commission");
                        //dtsum.Columns.Add("gstmargin");
                        //dtsum.Columns.Add("commisionfortax");
                        //dtsum.Columns.Add("Gateway");
                        //dtsum.Columns.Add("gateWayValue");
                        //dtsum.Columns.Add("Total");

                        dssum.Tables.Add(dtsum);



                        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                        DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {




                            if (dcustbranch.Tables[0].Rows.Count > 0)
                            {
                                #region

                                DataTable dtraws = dcustbranch.Tables[0];

                                var result1 = from r in dtraws.AsEnumerable()
                                              group r by new
                                              {
                                                  paymode = r["paymode"],
                                                  orderno = r["No"],
                                                  paymenttype = r["paymenttype"],
                                                  billno = r["billno"],
                                                  BillDate = r["BillDate"],
                                                  Category = r["Category"],
                                                  definition = r["definition"],
                                                  unitprice = r["unitprice"],
                                                  quantity = r["quantity"],
                                                  amount = r["amount"],
                                                  tax = r["tax"],
                                                  GST = r["GST"],
                                                  disc = r["disc"],
                                                  name = r["Name"],
                                                  TotalValue = r["TotalValue"],
                                                  //Saletypemargin = r["Saletypemargin"],
                                                  //commission = r["commission"],
                                                  //gstmargin = r["gstmargin"],
                                                  //commisionfortax = r["commisionfortax"],
                                                  //Gateway = r["Gateway"]

                                              } into raw
                                              select new
                                              {
                                                  paymode = raw.Key.paymode,
                                                  orderno = raw.Key.orderno,
                                                  paymenttype = raw.Key.paymenttype,
                                                  billno = raw.Key.billno,
                                                  BillDate = raw.Key.BillDate,
                                                  Category = raw.Key.Category,
                                                  definition = raw.Key.definition,
                                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                                  unitprice = raw.Key.unitprice,
                                                  quantity = raw.Key.quantity,
                                                  amount = raw.Key.amount,
                                                  tax = raw.Key.tax,
                                                  GST = raw.Key.GST,
                                                  disc = raw.Key.disc,
                                                  name = raw.Key.name,
                                                  TotalValue = raw.Key.TotalValue,
                                                  //Saletypemargin = raw.Key.Saletypemargin,
                                                  //commission = raw.Key.commission,
                                                  //gstmargin = raw.Key.gstmargin,
                                                  //commisionfortax = raw.Key.commisionfortax,
                                                  //Gateway = raw.Key.Gateway,
                                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                              };


                                foreach (var g in result1)
                                {
                                    drsum = dtsum.NewRow();

                                    drsum["paymode"] = g.paymode;
                                    drsum["No"] = g.orderno;
                                    drsum["paymenttype"] = g.paymenttype;
                                    drsum["billno"] = g.billno;
                                    drsum["BillDate"] = g.BillDate;
                                    drsum["Category"] = g.Category;
                                    drsum["Name"] = g.name;
                                    drsum["definition"] = g.definition;
                                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                    drsum["quantity"] = g.quantity;
                                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                    drsum["tax"] = g.tax;
                                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                    drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                    //drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                    //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                    //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                    //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                    //drsum["Gateway"] = g.Gateway;
                                    //drsum["gateWayValue"] = "0";
                                    //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                    //drsum["Total"] = tot.ToString("f2");
                                    dssum.Tables[0].Rows.Add(drsum);
                                }
                                #endregion
                            }
                            gvdetailed.Visible = true;
                            gvsummary.Visible = false;
                            gvdetailed.DataSource = dssum.Tables[0];
                            gvdetailed.DataBind();


                        }
                        else
                        {
                            gvdetailed.DataSource = null;
                            gvdetailed.DataBind();
                        }



                    }


                }


            }
            else
            {
                if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    string[] wordArray = sales.Split('_');

                    brach = wordArray[1];
                   // string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;



                    DataTable dtsum = new DataTable();
                    DataSet dssum = new DataSet();
                    DataRow drsum;

                    dtsum.Columns.Add("paymode");
                    dtsum.Columns.Add("No");
                    dtsum.Columns.Add("paymenttype");
                    dtsum.Columns.Add("billno");
                    dtsum.Columns.Add("BillDate");
                    //  dtsum.Columns.Add("Category");
                    //  dtsum.Columns.Add("definition");
                    dtsum.Columns.Add("unitprice");
                    dtsum.Columns.Add("quantity");
                    dtsum.Columns.Add("amount");
                    //   dtsum.Columns.Add("tax");
                    dtsum.Columns.Add("GST");
                    dtsum.Columns.Add("disc");
                    dtsum.Columns.Add("TotalValue");
                    dtsum.Columns.Add("name");
                    dtsum.Columns.Add("Saletypemargin");
                    //dtsum.Columns.Add("commission");
                    //dtsum.Columns.Add("gstmargin");
                    //dtsum.Columns.Add("commisionfortax");
                    //dtsum.Columns.Add("Gateway");
                    //dtsum.Columns.Add("gateWayValue");
                    //dtsum.Columns.Add("Total");

                    dssum.Tables.Add(dtsum);



                    lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {




                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {
                            #region

                            DataTable dtraws = dcustbranch.Tables[0];

                            var result1 = from r in dtraws.AsEnumerable()
                                          group r by new
                                          {
                                              paymode = r["paymode"],
                                              orderno = r["No"],
                                              paymenttype = r["paymenttype"],
                                              billno = r["billno"],
                                              BillDate = r["BillDate"],
                                              name = r["Name"],
                                              //  Category = r["Category"],
                                              //   definition = r["definition"],
                                              //     unitprice = r["unitprice"],
                                              //     quantity = r["quantity"],
                                              //     amount = r["amount"],
                                              //   tax = r["tax"],
                                              //     GST = r["GST"],
                                              //    TotalValue = r["TotalValue"],
                                              Saletypemargin = r["Saletypemargin"],
                                              ////    commission = r["commission"],
                                              //gstmargin = r["gstmargin"],
                                              ////   commisionfortax = r["commisionfortax"],
                                              //Gateway = r["Gateway"]

                                          } into raw
                                          select new
                                          {
                                              paymode = raw.Key.paymode,
                                              orderno = raw.Key.orderno,
                                              paymenttype = raw.Key.paymenttype,
                                              billno = raw.Key.billno,
                                              BillDate = raw.Key.BillDate,
                                              name = raw.Key.name,
                                              //  Category = raw.Key.Category,
                                              //  definition = raw.Key.definition,
                                              //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                              unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
                                              quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                                              amount = raw.Sum(x => Convert.ToDouble(x["amount"])),
                                              //  tax = raw.Key.tax,
                                              GST = raw.Sum(x => Convert.ToDouble(x["GST"])),
                                              disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                                              TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                              Saletypemargin = raw.Key.Saletypemargin,
                                              //commission = raw.Sum(x => Convert.ToDouble(x["commission"])),
                                              //gstmargin = raw.Key.gstmargin,
                                              //commisionfortax = raw.Sum(x => Convert.ToDouble(x["commisionfortax"])),
                                              //Gateway = raw.Key.Gateway,
                                              //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                          };


                            foreach (var g in result1)
                            {
                                drsum = dtsum.NewRow();

                                drsum["paymode"] = g.paymode;
                                drsum["No"] = g.orderno;
                                drsum["paymenttype"] = g.paymenttype;
                                drsum["billno"] = g.billno;
                                drsum["BillDate"] = g.BillDate;
                                drsum["Name"] = g.name;
                                //   drsum["Category"] = g.Category;
                                //  drsum["definition"] = g.definition;
                                drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                drsum["quantity"] = g.quantity;
                                drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                // drsum["tax"] = g.tax;
                                drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                //drsum["Gateway"] = g.Gateway;
                                //drsum["gateWayValue"] = "0";
                                //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                //drsum["Total"] = tot.ToString("f2");
                                dssum.Tables[0].Rows.Add(drsum);
                            }
                            #endregion
                        }
                        gvdetailed.Visible = false;
                        gvsummary.Visible = true;
                        gvsummary.DataSource = dssum.Tables[0];
                        gvsummary.DataBind();
                    }
                    else
                    {
                        gvsummary.DataSource = null;
                        gvsummary.DataBind();
                    }
                }
                else
                {

                    if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        string[] wordArray = sales.Split('_');

                        brach = wordArray[1];
                       // string name = string.Empty;


                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;

                        DataTable dtsum = new DataTable();
                        DataSet dssum = new DataSet();
                        DataRow drsum;

                        dtsum.Columns.Add("paymode");
                        dtsum.Columns.Add("No");
                        dtsum.Columns.Add("paymenttype");
                        dtsum.Columns.Add("billno");
                        dtsum.Columns.Add("BillDate");
                        //  dtsum.Columns.Add("Category");
                        //  dtsum.Columns.Add("definition");
                        dtsum.Columns.Add("unitprice");
                        dtsum.Columns.Add("quantity");
                        dtsum.Columns.Add("amount");
                        //   dtsum.Columns.Add("tax");
                        dtsum.Columns.Add("GST");
                        dtsum.Columns.Add("disc");
                        dtsum.Columns.Add("TotalValue");
                        dtsum.Columns.Add("name");
                        dtsum.Columns.Add("Saletypemargin");
                        //dtsum.Columns.Add("commission");
                        //dtsum.Columns.Add("gstmargin");
                        //dtsum.Columns.Add("commisionfortax");
                        //dtsum.Columns.Add("Gateway");
                        //dtsum.Columns.Add("gateWayValue");
                        //dtsum.Columns.Add("Total");

                        dssum.Tables.Add(dtsum);



                        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                        DataSet dcustbranch = objbs.salestypereports(brach, sFrom, sTo, drpPayment.SelectedValue, drpsalestype.SelectedValue);
                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {




                            if (dcustbranch.Tables[0].Rows.Count > 0)
                            {
                                #region

                                DataTable dtraws = dcustbranch.Tables[0];

                                var result1 = from r in dtraws.AsEnumerable()
                                              group r by new
                                              {
                                                  paymode = r["paymode"],
                                                  orderno = r["No"],
                                                  paymenttype = r["paymenttype"],
                                                  billno = r["billno"],
                                                  BillDate = r["BillDate"],
                                                  name = r["name"],
                                                  //  Category = r["Category"],
                                                  //   definition = r["definition"],
                                                  //     unitprice = r["unitprice"],
                                                  //     quantity = r["quantity"],
                                                  //     amount = r["amount"],
                                                  //   tax = r["tax"],
                                                  //     GST = r["GST"],
                                                  //    TotalValue = r["TotalValue"],
                                                  Saletypemargin = r["Saletypemargin"],
                                                  ////    commission = r["commission"],
                                                  //gstmargin = r["gstmargin"],
                                                  ////   commisionfortax = r["commisionfortax"],
                                                  //Gateway = r["Gateway"]

                                              } into raw
                                              select new
                                              {
                                                  paymode = raw.Key.paymode,

                                                  orderno = raw.Key.orderno,
                                                  paymenttype = raw.Key.paymenttype,
                                                  billno = raw.Key.billno,
                                                  BillDate = raw.Key.BillDate,
                                                  name = raw.Key.name,
                                                  //  Category = raw.Key.Category,
                                                  //  definition = raw.Key.definition,
                                                  //Qty = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                                  unitprice = raw.Sum(x => Convert.ToDouble(x["unitprice"])),
                                                  quantity = raw.Sum(x => Convert.ToDouble(x["quantity"])),
                                                  amount = raw.Sum(x => Convert.ToDouble(x["amount"])),
                                                  //  tax = raw.Key.tax,
                                                  GST = raw.Sum(x => Convert.ToDouble(x["GST"])),
                                                  disc = raw.Sum(x => Convert.ToDouble(x["disc"])),
                                                  TotalValue = raw.Sum(x => Convert.ToDouble(x["TotalValue"])),
                                                  Saletypemargin = raw.Key.Saletypemargin,
                                                  //commission = raw.Sum(x => Convert.ToDouble(x["commission"])),
                                                  //gstmargin = raw.Key.gstmargin,
                                                  //commisionfortax = raw.Sum(x => Convert.ToDouble(x["commisionfortax"])),
                                                  //Gateway = raw.Key.Gateway,
                                                  //UOM = raw.Sum(x => Convert.ToDouble(x["TotalValue"]),
                                              };


                                foreach (var g in result1)
                                {
                                    drsum = dtsum.NewRow();

                                    drsum["paymode"] = g.paymode;
                                    drsum["No"] = g.orderno;
                                    drsum["paymenttype"] = g.paymenttype;
                                    drsum["billno"] = g.billno;
                                    drsum["BillDate"] = g.BillDate;
                                    drsum["name"] = g.name;
                                    //   drsum["Category"] = g.Category;
                                    //  drsum["definition"] = g.definition;
                                    drsum["unitprice"] = Convert.ToDouble(g.unitprice).ToString("f2");
                                    drsum["quantity"] = g.quantity;
                                    drsum["amount"] = Convert.ToDouble(g.amount).ToString("f2");
                                    // drsum["tax"] = g.tax;
                                    drsum["GST"] = Convert.ToDouble(g.GST).ToString("f2");
                                    drsum["disc"] = Convert.ToDouble(g.disc).ToString("f2");
                                    drsum["TotalValue"] = Convert.ToDouble(g.TotalValue).ToString("f2");
                                    drsum["Saletypemargin"] = Convert.ToDouble(g.Saletypemargin).ToString("f2");
                                    //drsum["commission"] = Convert.ToDouble(g.commission).ToString("f2");
                                    //drsum["gstmargin"] = Convert.ToDouble(g.gstmargin).ToString("f2");
                                    //drsum["commisionfortax"] = Convert.ToDouble(g.commisionfortax).ToString("f2");
                                    //drsum["Gateway"] = g.Gateway;
                                    //drsum["gateWayValue"] = "0";
                                    //double tot = Convert.ToDouble(g.TotalValue) + Convert.ToDouble(g.commission);
                                    //drsum["Total"] = tot.ToString("f2");
                                    dssum.Tables[0].Rows.Add(drsum);
                                }
                                #endregion
                            }
                            gvdetailed.Visible = false;
                            gvsummary.Visible = true;
                            gvsummary.DataSource = dssum.Tables[0];
                            gvsummary.DataBind();
                        }
                        else
                        {
                            gvsummary.DataSource = null;
                            gvsummary.DataBind();
                        }



                    }


                }


            }

            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];



            //}
            //if (sTableName == "admin")
            //{
            //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //    string paymode = drpPayment.SelectedItem.Value;
            //    dt = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
            //    gridview.DataSource = dt;
            //    gridview.DataBind();
            //}

            //else
            //{
            //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //    string paymode = drpPayment.SelectedItem.Value;
            //    dt = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
            //    gridview.DataSource = dt;
            //    gridview.DataBind();
            //}
            //Response.ClearContent();
            //Response.AddHeader("content-disposition",
            //    "attachment;filename=CustomerSalesReport.xls");
            //Response.ContentType = "applicatio/excel";
            //StringWriter sw = new StringWriter(); ;
            //HtmlTextWriter htm = new HtmlTextWriter(sw);
            //gridview.AllowPaging = false;
            //gridview.RenderControl(htm);
            //Response.Write(sw.ToString());
            //Response.End();
            //gridview.AllowPaging = true;
            string filename = "";
            if (radbtnlist.SelectedValue == "1")
            {
                filename = "salesreportSummary.xls";
            }
            else
            {
                filename = "salesreportDetailed.xls";

            }
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.Caption = "Store :  " + BranchNAme + " " + StoreName + " Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            dgGrid.HeaderStyle.Font.Bold = true;
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];
            //    string name = string.Empty;

            //    if (brach == "CO1")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO2")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO3")
            //    {
            //        Label123.Text = "Shiva Delights";
            //    }
            //    else if (brach == "CO4")
            //    {
            //        Label123.Text = "Fig and honey";
            //    }
            //    else if (brach == "CO5")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }

            //    else if (brach == "CO6")
            //    {
            //        Label123.Text = "Maduravayol";
            //    }

            //    else if (brach == "CO7")
            //    {
            //        Label123.Text = "Purasavakkam";
            //    }
            //    else if (brach == "CO8")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }

            //    else if (brach == "CO9")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO10")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO11")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    if (sTableName == "admin")
            //    {
            //        DataSet dCustReport = objbs.CustomerSalesAdmin();
            //        gvCustsales.PageIndex = e.NewPageIndex;
            //        gvCustsales.DataSource = dCustReport.Tables[0];
            //        gvCustsales.DataBind();
            //    }
            //    else
            //    {
            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;

            //        DataSet ds = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
            //        //   DataSet ds = objbs.CustomerSalesBranch(sTableName, sFrom, sTo);
            //        gvCustsales.PageIndex = e.NewPageIndex;

            //        gvCustsales.DataSource = ds.Tables[0];
            //        gvCustsales.DataBind();
            //    }
            //    //decimal dtotal = 0;
            //    //for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    //{
            //    //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //    //}
            //    //decimal Total = dtotal;
            //    //lblTotal.InnerText = Total.ToString();
            //    decimal dtotal = 0;
            //    decimal ddiscamnt = 0;
            //    decimal dtotalamt = 0;
            //    for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    {
            //        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //        ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
            //        dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
            //    }
            //    decimal Total = dtotal;
            //    lblTotal.InnerText = Total.ToString();
            //    decimal dtotalamntt = ddiscamnt;
            //    disc.InnerText = dtotalamntt.ToString();
            //    decimal gndtot = dtotalamt;
            //    gndtotal.InnerText = gndtot.ToString();
            //    //  btnall_Click( sender, Even e)

            //    //  tot = Convert.ToDouble(Total);


            //}


        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {

        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            ////if (e.Row.RowType == DataControlRowType.DataRow)
            ////{

            ////}
            //if (sadmin == "1")
            //{

            //}
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //string name = string.Empty;



            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];


            //    //////if (brach == "CO1")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO2")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO3")
            //    //////{
            //    //////    Label123.Text = "Shiva Delights";
            //    //////}
            //    //////else if (brach == "CO4")
            //    //////{
            //    //////    Label123.Text = "Fig and honey";
            //    //////}
            //    //////else if (brach == "CO5")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}

            //    //////else if (brach == "CO6")
            //    //////{
            //    //////    Label123.Text = "Maduravayol";
            //    //////}

            //    //////else if (brach == "CO7")
            //    //////{
            //    //////    Label123.Text = "Purasavakkam";
            //    //////}
            //    //////else if (brach == "CO8")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}

            //    //////else if (brach == "CO9")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO10")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO11")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //}


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    double Tax = 0;
            //    double NetAmount = 0;

            //    Tax = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
            //    NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

            //    GTax = GTax + Tax;
            //    GNetAmount = GNetAmount + NetAmount;

            //    GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
            //    GridView gvGroup = (GridView)sender;
            //    if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
            //    {
            //        int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
            //        DataSet ds = objbs.CustomerSalesdetailed(groupID, brach);
            //        //if (ds.Tables[0].Rows.Count > 0)
            //        //{
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            gv.DataSource = ds;
            //            double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
            //            amount1 = amount1 + amount;
            //            gv.DataBind();


            //        }
            //        //}
            //    }

            //}

            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

            //    //e.Row.Cells[0].Text = "Total";

            //    //e.Row.Cells[7].Text = amount1.ToString("N2");
            //    //e.Row.Cells[7].ForeColor = System.Drawing.Color.White;


            //    //////GTax = GTax + Tax;
            //    //////GNetAmount = GNetAmount + NetAmount;


            //    decimal dtotal = 0;
            //    decimal ddiscamnt = 0;
            //    decimal dtotalamt = 0;
            //    for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    {
            //        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //        ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
            //        dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
            //    }
            //    decimal Total = dtotal;
            //    lblTotal.InnerText = Total.ToString();
            //    decimal dtotalamntt = ddiscamnt;
            //    disc.InnerText = dtotalamntt.ToString();
            //    decimal gndtot = dtotalamt;

            //    gndtotal.InnerText = ((GTax + GNetAmount) - Convert.ToDouble(dtotalamntt)).ToString("f2");

            //    double finaltot = 0;
            //    double roundoff1 = Convert.ToDouble(gndtotal.InnerText) - Math.Floor(Convert.ToDouble(gndtotal.InnerText));
            //    if (roundoff1 >= 0.5)
            //    {
            //        finaltot = Math.Round(Convert.ToDouble(gndtotal.InnerText), MidpointRounding.AwayFromZero);
            //    }
            //    else
            //    {
            //        finaltot = Math.Floor(Convert.ToDouble(gndtotal.InnerText));
            //    }

            //    gndtotal.InnerText = string.Format("{0:N2}", finaltot);
            //}

        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {
                //DateTime date = Convert.ToDateTime(txtfromdate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var days = date.Day;
                //var toda = Toady.Day;

                //if ((toda - days) <= 2)
                //{

                //}

                //else
                //{
                //    txtfromdate.Text = "";
                //}
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            //////string Branch = "";
            //////if (sTableName == "CO1")
            //////    Branch = "Kk nagar";
            //////else if (sTableName == "CO2")
            //////    Branch = "Byepass";
            //////else if (sTableName == "CO3")
            //////    Branch = "BB kulam";
            //////else if (sTableName == "CO4")
            //////    Branch = "Narayanapuram";
            //////else if (sTableName == "CO5")
            //////    Branch = "Palayankottal";
            //////else if (sTableName == "CO6")
            //////    Branch = "Maduravayol";
            //////else if (sTableName == "CO7")
            //////    Branch = "purasavakkam";
            //////else if (sTableName == "CO8")
            //////    Branch = "Chennai Pothys";

            //////else if (sTableName == "CO9")
            //////    Branch = "Thirunelveli";
            //////else if (sTableName == "CO10")
            //////    Branch = "Periyar";
            //////else if (sTableName == "CO11")
            //////    Branch = "Palayam";

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
                unitprice += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "unitprice"));
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "quantity"));

                subtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "amount"));
                gstamount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));

                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalValue"));
                commamount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "commission"));

                commgstamnt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "commisionfortax"));
                gatwaycharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "gateWayValue"));
                grandtot += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "disc"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = "Total :-";
                e.Row.Cells[7].Text = unitprice.ToString("f2");
                e.Row.Cells[8].Text = Qty.ToString("f2");
                e.Row.Cells[9].Text = subtotal.ToString("f2");
                e.Row.Cells[11].Text = gstamount.ToString("f2");
                e.Row.Cells[12].Text = discvalue.ToString("f2");
                e.Row.Cells[13].Text = totalvalue.ToString("f2");
                e.Row.Cells[15].Text = commamount.ToString("f2");
                e.Row.Cells[17].Text = commgstamnt.ToString("f2");
                e.Row.Cells[19].Text = gatwaycharge.ToString("f2");
                e.Row.Cells[20].Text = grandtot.ToString("f2");
                
            }

        }
        public void gvsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                unitprice += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "unitprice"));
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "quantity"));

                subtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "amount"));
                gstamount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));

                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalValue"));
                commamount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "commission"));

                commgstamnt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "commisionfortax"));
                gatwaycharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "gateWayValue"));
                grandtot += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "disc"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = "Total :";
                e.Row.Cells[5].Text = unitprice.ToString("f2");
                e.Row.Cells[6].Text = Qty.ToString("f2");
                e.Row.Cells[7].Text = subtotal.ToString("f2");
                e.Row.Cells[8].Text = gstamount.ToString("f2");
                e.Row.Cells[9].Text = discvalue.ToString("f2");
                e.Row.Cells[10].Text = totalvalue.ToString("f2");
                e.Row.Cells[12].Text = commamount.ToString("f2");
                e.Row.Cells[14].Text = commgstamnt.ToString("f2");
                e.Row.Cells[16].Text = gatwaycharge.ToString("f2");
                e.Row.Cells[17].Text = grandtot.ToString("f2");
                
            }

        }
    }
}