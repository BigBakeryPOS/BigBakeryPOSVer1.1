using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Globalization;
namespace Billing.Accountsbootstrap
{
    public partial class GeneralReports : System.Web.UI.Page
    {

        string sTableName = ""; string Password = "";
        BSClass objbs = new BSClass();

        string Btype = "";

        double ReturnQty = 0; double ReturnAmount = 0;
        double paymententryAmount = 0;
        double StaffCreditTotalValue = 0;
        double discountNetAmount = 0; double discountTax = 0; double discountDiscount = 0; double discountTotal = 0;

        double GQty = 0;
        double GRate = 0;
        double GTrate = 0;

        double GOCOST = 0;
        double GOGST = 0;
        double GOAmount = 0;


        double GMargin = 0;
        double GBasicValue = 0;
        double GGSTAmt = 0;
        double GNetAmount = 0;
        double SalesExempted = 0; double TaxableSales = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            Btype = Request.Cookies["userInfo"]["BType"].ToString();

            if (!IsPostBack)
            {
                //RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                //RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                //RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                //RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                //txtfromdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                //txttodate.Text = DateTime.Now.ToString("MM/dd/yyyy");

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");
            }
        }

        // Select Report Screen
        protected void ddltype_OnSelectedIndexChanged1(object sender, EventArgs e)
        {


            if (ddltype.SelectedValue == "1")
            {
                DataSet dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");

            }
            else if (ddltype.SelectedValue == "2")
            {

            }

        }

        // Select Report Screen
        protected void ddltype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnSearch.Enabled == true)
            {
                btnSearch_Click(sender, e);
            }
        }

        // Admin PassWord
        protected void txtpassword_OnTextChanged(object sender, EventArgs e)
        {
            DataSet adminpass = objbs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
            if (adminpass.Tables[0].Rows.Count > 0)
            {
                btnSearch.Enabled = true;
                btnExp.Enabled = true;
                btnPrint.Enabled = true;
                // txtpassword.Text = adminpass.Tables[0].Rows[0]["AdminPass"].ToString();
                txtpassword.Attributes.Add("value", adminpass.Tables[0].Rows[0]["AdminPass"].ToString());
            }
            else
            {
                btnSearch.Enabled = false;
                btnExp.Enabled = false;
                btnPrint.Enabled = false;
                txtpassword.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
                return;

            }
        }

        // Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvReturns.DataSource = null;
            gvReturns.DataBind();
            gridledger.DataSource = null;
            gridledger.DataBind();
            gvStaffcredit.DataSource = null;
            gvStaffcredit.DataBind();
            gvdiscountsales.DataSource = null;
            gvdiscountsales.DataBind();
            gvSalesValue.DataSource = null;
            gvSalesValue.DataBind();
            gvorder.DataSource = null;
            gvorder.DataBind();

            Sales.Visible = false;
            Order.Visible = false;

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            if (ddltype.SelectedValue == "1")
            {
                DataSet dRet = objbs.getReturnreports(sTableName, sFrom, sTo, ddlreason.SelectedValue);
                if (dRet.Tables[0].Rows.Count > 0)
                {
                    gvReturns.DataSource = dRet;
                    gvReturns.DataBind();
                }
            }
            else if (ddltype.SelectedValue == "2")
            {
                DataSet dspaymententry = objbs.getpaymententryreports(sFrom, sTo, sTableName);
                if (dspaymententry.Tables[0].Rows.Count > 0)
                {
                    gridledger.DataSource = dspaymententry;
                    gridledger.DataBind();
                }
            }
            else if (ddltype.SelectedValue == "3")
            {
                DataSet ds = new DataSet();

                #region

                DataTable dtsum = new DataTable();
                DataSet dssum = new DataSet();
                DataRow drsum;

                dtsum.Columns.Add("Branch");
                dtsum.Columns.Add("Type");
                dtsum.Columns.Add("name");
                dtsum.Columns.Add("billno");
                dtsum.Columns.Add("BillDate");
                dtsum.Columns.Add("quantity");
                dtsum.Columns.Add("amount");
                dtsum.Columns.Add("GST");
                dtsum.Columns.Add("disc");
                dtsum.Columns.Add("TotalValue");

                dtsum.Columns.Add("PayType");

                dssum.Tables.Add(dtsum);

                // Sales
                ds = objbs.getstaffcreditsalesreports(sTableName, sFrom, sTo, "5");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Dr in ds.Tables[0].Rows)
                    {
                        drsum = dtsum.NewRow();

                        drsum["Branch"] = Dr["Branch"];
                        drsum["Type"] = Dr["Type"];
                        drsum["name"] = Dr["name"];
                        drsum["billno"] = Dr["billno"];
                        drsum["BillDate"] =Dr["BillDate"];
                        drsum["quantity"] = Dr["quantity"];
                        drsum["amount"] = Dr["amount"];
                        drsum["GST"] = Dr["GST"];
                        drsum["disc"] = Dr["disc"];
                        drsum["TotalValue"] = Dr["TotalValue"];
                        drsum["PayType"] = "-";

                        dssum.Tables[0].Rows.Add(drsum);

                    }
                }


                ds = objbs.getstaffcreditorderreports(sTableName, sFrom, sTo, "5");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Dr in ds.Tables[0].Rows)
                    {
                        drsum = dtsum.NewRow();

                        drsum["Branch"] = Dr["Branch"];
                        drsum["Type"] = Dr["Type"];
                        drsum["name"] = Dr["name"];
                        drsum["billno"] = Dr["billno"];
                        drsum["BillDate"] = Dr["BillDate"];
                        drsum["quantity"] = Dr["quantity"];
                        drsum["amount"] = Dr["amount"];
                        drsum["GST"] = Dr["GST"];
                        drsum["disc"] = Dr["disc"];
                        drsum["TotalValue"] = Dr["TotalValue"];
                        drsum["PayType"] = Dr["Paytype"];

                        dssum.Tables[0].Rows.Add(drsum);


                    }
                }

                if (dssum.Tables.Count > 0)
                {
                    if (dssum.Tables[0].Rows.Count > 0)
                    {
                        gvStaffcredit.DataSource = dssum;
                        gvStaffcredit.DataBind();
                    }
                    else
                    {
                        gvStaffcredit.DataSource = null;
                        gvStaffcredit.DataBind();
                    }
                }
                else
                {
                    gvStaffcredit.DataSource = null;
                    gvStaffcredit.DataBind();
                }

                #endregion
            }
            else if (ddltype.SelectedValue == "4")
            {
                DataSet dsdiscountsalesreports = objbs.getdiscountsalesreports(sTableName, sFrom, sTo);
                if (dsdiscountsalesreports.Tables[0].Rows.Count > 0)
                {
                    gvdiscountsales.DataSource = dsdiscountsalesreports;
                    gvdiscountsales.DataBind();
                }
                else
                {
                    gvdiscountsales.DataSource = null;
                    gvdiscountsales.DataBind();
                }

            }
            else if (ddltype.SelectedValue == "5")
            {
                Sales.Visible = true;

                #region

                DataSet FullValues = objbs.GetFullValuesForSalesinvoice(sTableName, sFrom.ToString("yyyy/MM/dd"), sTo.ToString("yyyy/MM/dd"), lblpaymode.Text);


                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Bcode");
                dtraw.Columns.Add("Date");
                dtraw.Columns.Add("grnsource");
                dtraw.Columns.Add("Category");
                dtraw.Columns.Add("Itemname");
                dtraw.Columns.Add("GST");
                dtraw.Columns.Add("Qty");
                dtraw.Columns.Add("rate");
                dtraw.Columns.Add("TotalRate");
                dtraw.Columns.Add("Margin");
                dtraw.Columns.Add("Marginvalue");
                dtraw.Columns.Add("BasicCostAfterMargin");
                dtraw.Columns.Add("GSTvalue");
                dtraw.Columns.Add("NetAmount");
                dsraw.Tables.Add(dtraw);

                if (FullValues.Tables[0].Rows.Count > 0)
                {
                    DataTable dtrawss = new DataTable();

                    dtrawss = FullValues.Tables[0];

                    var result1 = from r in dtrawss.AsEnumerable()
                                  group r by new { Bcode = r["Bcode"], Date = r["Date"], grnsource = r["grnsource"], Category = r["Category"], Itemname = r["Itemname"], GST = r["GST"], Rate = r["Rate"], margin = r["margin"] } into raw
                                  select new
                                  {
                                      Bcode = raw.Key.Bcode,
                                      Date = raw.Key.Date,
                                      grnsource = raw.Key.grnsource,
                                      Category = raw.Key.Category,
                                      Itemname = raw.Key.Itemname,
                                      GST = raw.Key.GST,
                                      Rate = raw.Key.Rate,
                                      margin = raw.Key.margin,
                                      Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                      TotalRate = raw.Sum(x => Convert.ToDouble(x["TotalRate"])),
                                      Marginvalue = raw.Sum(x => Convert.ToDouble(x["Marginvalue"])),
                                      BasicCostAfterMargin = raw.Sum(x => Convert.ToDouble(x["BasicCostAfterMargin"])),
                                      GSTvalue = raw.Sum(x => Convert.ToDouble(x["GSTvalue"])),
                                      NetAmount = raw.Sum(x => Convert.ToDouble(x["NetAmount"])),
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();


                        drraw["Bcode"] = g.Bcode;
                        //drraw["Date"] = Convert.ToDateTime(g.Date).ToString("dd/MM/yyyy");
                        drraw["Date"] = g.Date;
                        drraw["grnsource"] = g.grnsource;
                        drraw["Category"] = g.Category;
                        drraw["Itemname"] = g.Itemname;
                        drraw["GST"] = g.GST;
                        drraw["Qty"] = g.Qty;
                        drraw["rate"] = Convert.ToDouble(g.Rate).ToString("0.00");
                        drraw["TotalRate"] = Convert.ToDouble(g.TotalRate).ToString("0.00"); ;
                        drraw["Margin"] = g.margin;
                        drraw["Marginvalue"] = Convert.ToDouble(g.Marginvalue).ToString("0.00");
                        drraw["BasicCostAfterMargin"] = Convert.ToDouble(g.BasicCostAfterMargin).ToString("0.00");
                        drraw["GSTvalue"] = Convert.ToDouble(g.GSTvalue).ToString("0.00");
                        drraw["NetAmount"] = Convert.ToDouble(g.NetAmount).ToString("0.00");
                        dsraw.Tables[0].Rows.Add(drraw);
                    }

                }
                gvSalesValue.Caption = "SALES";
                DataView view = dsraw.Tables[0].DefaultView;
                view.Sort = " Date,Category ASC";

                gvSalesValue.DataSource = view;
                gvSalesValue.DataBind();

                #endregion
            }

            else if (ddltype.SelectedValue == "6")
            {
                Order.Visible = true;

                #region

                DataSet FullValuesorder = objbs.GetFullValuesFororderinvoice(sTableName, sFrom.ToString("yyyy/MM/dd"), sTo.ToString("yyyy/MM/dd"));
                gvorder.Caption = "Order";
                DataView view = FullValuesorder.Tables[0].DefaultView;
                view.Sort = "Billdate ASC";
                gvorder.DataSource = view;
                gvorder.DataBind();

                #endregion
            }

            #region

            //////else if (ddltype.SelectedValue == "5" || ddltype.SelectedValue == "6")
            //////{

            //////    DateTime From = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //////    DateTime To = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //////    if (txtpassword.Text == "")
            //////    {
            //////        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Password.');", true);
            //////        txtpassword.Focus();
            //////        return;
            //////    }

            //////    DataSet adminpass = objbs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
            //////    if (adminpass.Tables[0].Rows.Count > 0)
            //////    {
            //////        btnSearch.Enabled = true;
            //////        btnExp.Enabled = true;
            //////        btnPrint.Enabled = true;
            //////        txtpassword.Text = adminpass.Tables[0].Rows[0]["AdminPass"].ToString();
            //////    }
            //////    else
            //////    {
            //////        btnSearch.Enabled = false;
            //////        btnExp.Enabled = false;
            //////        btnPrint.Enabled = false;
            //////        txtpassword.Text = "";
            //////        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
            //////        return;

            //////    }

            //////    if (ddltype.SelectedValue == "5")
            //////    {
            //////        Sales.Visible = true;
            //////        Order.Visible = false;

            //////        #region

            //////        DataSet FullValues = objbs.GetFullValuesForSalesinvoice(sTableName, From.ToString("yyyy/MM/dd"), To.ToString("yyyy/MM/dd"), lblpaymode.Text);


            //////        DataTable dtraw = new DataTable();
            //////        DataSet dsraw = new DataSet();
            //////        DataRow drraw;

            //////        dtraw.Columns.Add("Bcode");
            //////        dtraw.Columns.Add("Date");
            //////        dtraw.Columns.Add("grnsource");
            //////        dtraw.Columns.Add("Category");
            //////        dtraw.Columns.Add("Itemname");
            //////        dtraw.Columns.Add("GST");
            //////        dtraw.Columns.Add("Qty");
            //////        dtraw.Columns.Add("rate");
            //////        dtraw.Columns.Add("TotalRate");
            //////        dtraw.Columns.Add("Margin");
            //////        dtraw.Columns.Add("Marginvalue");
            //////        dtraw.Columns.Add("BasicCostAfterMargin");
            //////        dtraw.Columns.Add("GSTvalue");
            //////        dtraw.Columns.Add("NetAmount");
            //////        dsraw.Tables.Add(dtraw);

            //////        if (FullValues.Tables[0].Rows.Count > 0)
            //////        {
            //////            DataTable dtrawss = new DataTable();

            //////            dtrawss = FullValues.Tables[0];

            //////            var result1 = from r in dtrawss.AsEnumerable()
            //////                          group r by new { Bcode = r["Bcode"], Date = r["Date"], grnsource = r["grnsource"], Category = r["Category"], Itemname = r["Itemname"], GST = r["GST"], Rate = r["Rate"], margin = r["margin"] } into raw
            //////                          select new
            //////                          {
            //////                              Bcode = raw.Key.Bcode,
            //////                              Date = raw.Key.Date,
            //////                              grnsource = raw.Key.grnsource,
            //////                              Category = raw.Key.Category,
            //////                              Itemname = raw.Key.Itemname,
            //////                              GST = raw.Key.GST,
            //////                              Rate = raw.Key.Rate,
            //////                              margin = raw.Key.margin,
            //////                              Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
            //////                              TotalRate = raw.Sum(x => Convert.ToDouble(x["TotalRate"])),
            //////                              Marginvalue = raw.Sum(x => Convert.ToDouble(x["Marginvalue"])),
            //////                              BasicCostAfterMargin = raw.Sum(x => Convert.ToDouble(x["BasicCostAfterMargin"])),
            //////                              GSTvalue = raw.Sum(x => Convert.ToDouble(x["GSTvalue"])),
            //////                              NetAmount = raw.Sum(x => Convert.ToDouble(x["NetAmount"])),
            //////                          };


            //////            foreach (var g in result1)
            //////            {
            //////                drraw = dtraw.NewRow();


            //////                drraw["Bcode"] = g.Bcode;
            //////                drraw["Date"] = Convert.ToDateTime(g.Date).ToString("dd/MM/yyyy");
            //////                drraw["grnsource"] = g.grnsource;
            //////                drraw["Category"] = g.Category;
            //////                drraw["Itemname"] = g.Itemname;
            //////                drraw["GST"] = g.GST;
            //////                drraw["Qty"] = g.Qty;
            //////                drraw["rate"] = Convert.ToDouble(g.Rate).ToString("0.00");
            //////                drraw["TotalRate"] = Convert.ToDouble(g.TotalRate).ToString("0.00"); ;
            //////                drraw["Margin"] = g.margin;
            //////                drraw["Marginvalue"] = Convert.ToDouble(g.Marginvalue).ToString("0.00");
            //////                drraw["BasicCostAfterMargin"] = Convert.ToDouble(g.BasicCostAfterMargin).ToString("0.00");
            //////                drraw["GSTvalue"] = Convert.ToDouble(g.GSTvalue).ToString("0.00");
            //////                drraw["NetAmount"] = Convert.ToDouble(g.NetAmount).ToString("0.00");
            //////                dsraw.Tables[0].Rows.Add(drraw);
            //////            }

            //////        }
            //////        gvSalesValue.Caption = "SALES";
            //////        DataView view = dsraw.Tables[0].DefaultView;
            //////        view.Sort = " Date,Category ASC";

            //////        gvSalesValue.DataSource = view;
            //////        gvSalesValue.DataBind();

            //////        #endregion

            //////    }
            //////    else
            //////    {
            //////        Sales.Visible = false;
            //////        Order.Visible = true;

            //////        #region

            //////        DataSet FullValuesorder = objbs.GetFullValuesFororderinvoice(sTableName, From.ToString("yyyy/MM/dd"), To.ToString("yyyy/MM/dd"));
            //////        gvorder.Caption = "Order";
            //////        DataView view = FullValuesorder.Tables[0].DefaultView;
            //////        view.Sort = "Billdate ASC";
            //////        gvorder.DataSource = view;
            //////        gvorder.DataBind();

            //////        #endregion

            //////    }
            //////}
            #endregion
        }

        //Export to Excel
        protected void btnexp_Click(object sender, EventArgs e)
        {
            string Name = "";
            if (ddltype.SelectedValue == "1")
            {
                Name = "StockReturn";
            }
            else if (ddltype.SelectedValue == "2")
            {
                Name = "PaymentEntry";
            }
            else if (ddltype.SelectedValue == "3")
            {
                Name = "StaffCredit";
            }
            else if (ddltype.SelectedValue == "4")
            {
                Name = "SalesDiscount";
            }
            else if (ddltype.SelectedValue == "5")
            {
                Name = "SalesInvoice";
            }
            else if (ddltype.SelectedValue == "6")
            {
                Name = "OrderInvoice";
            }


            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= " + Name + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            div1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        // Returns Report 
        protected void gvReturns_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ReturnQty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                ReturnAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total:-";
                e.Row.Cells[6].Text = ReturnQty.ToString("f2");
                e.Row.Cells[7].Text = ReturnAmount.ToString("f2");
            }

        }

        // Payment Entry  Report 
        protected void gridledger_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                paymententryAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total:-";
                e.Row.Cells[5].Text = paymententryAmount.ToString("f2");

            }

        }

        // StaffCredit  Report 
        protected void gvStaffcredit_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                StaffCreditTotalValue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalValue"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[8].Text = "Total:-";
                e.Row.Cells[9].Text = StaffCreditTotalValue.ToString("f2");

            }

        }

        // Sales Discont Report 
        protected void gvdiscountsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                discountNetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                discountTax += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
                discountDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Discount"));
                discountTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Total:-";
                e.Row.Cells[4].Text = discountNetAmount.ToString("f2");
                e.Row.Cells[5].Text = discountTax.ToString("f2");
                e.Row.Cells[6].Text = discountDiscount.ToString("f2");
                e.Row.Cells[7].Text = discountTotal.ToString("f2");

            }

        }

        //Sales Invoice
        protected void gvSalesValue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            double Qty = 0;
            double rate = 0;
            double totalrate = 0;
            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                rate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "rate"));
                totalrate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalRate"));
                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Marginvalue"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BasicCostAfterMargin"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTvalue"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GQty = GQty + Qty;
                GRate = GRate + rate;
                GTrate = GTrate + totalrate;
                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;
                GGSTAmt = GGSTAmt + GSTAmt;
                GNetAmount = GNetAmount + NetAmount;


                double GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                if (GST == 0)
                {
                    SalesExempted += NetAmount;
                }
                else
                {
                    TaxableSales += NetAmount;
                }

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total";
                e.Row.Cells[6].Text = GQty.ToString("f2");
                e.Row.Cells[7].Text = GRate.ToString("f2");
                e.Row.Cells[8].Text = GTrate.ToString("f2");
                e.Row.Cells[10].Text = GMargin.ToString("f2");
                e.Row.Cells[11].Text = GBasicValue.ToString("f2");
                e.Row.Cells[12].Text = GGSTAmt.ToString("f2");
                e.Row.Cells[13].Text = GNetAmount.ToString("f2");

                lblsalesexempted.Text = SalesExempted.ToString("f2");
                lbltaxablesales.Text = TaxableSales.ToString("f2");
                lblcgst.Text = GGSTAmt.ToString("f2");
                lblnetamount.Text = (GNetAmount + GGSTAmt).ToString("f2");

                double n = 0;

                double roundoff = Convert.ToDouble(lblnetamount.Text) - Math.Floor(Convert.ToDouble(lblnetamount.Text));
                if (roundoff >= 0.5)
                {
                    n = Math.Round(Convert.ToDouble(lblnetamount.Text), MidpointRounding.AwayFromZero);
                }
                else
                {
                    n = Math.Floor(Convert.ToDouble(lblnetamount.Text));
                }

                lblfinalamount.Text = string.Format("{0:N2}", n);
                double rndoff = Convert.ToDouble(lblfinalamount.Text) - Convert.ToDouble(lblnetamount.Text);
                lblroundoff.Text = string.Format("{0:N2}", Convert.ToDouble(rndoff));


            }
        }

        //Order Invocie
        protected void gvorder_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;
            double COST = 0;
            double GST = 0;
            double Amount = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                COST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "COST"));
                GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                Amount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Margin"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "castbeforemargin"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTV"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetamountV"));

                GOCOST = GOCOST + COST;
                GOGST = GOGST + GST;
                GOAmount = GOAmount + Amount;
                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;
                GGSTAmt = GGSTAmt + GSTAmt;
                GNetAmount = GNetAmount + NetAmount;
                TaxableSales += NetAmount;


            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[6].Text = "Total";
                e.Row.Cells[7].Text = GOCOST.ToString("f2");
                e.Row.Cells[8].Text = GOGST.ToString("f2");
                e.Row.Cells[10].Text = GOAmount.ToString("f2");
                e.Row.Cells[12].Text = GMargin.ToString("f2");
                e.Row.Cells[13].Text = GBasicValue.ToString("f2");
                e.Row.Cells[14].Text = GGSTAmt.ToString("f2");
                e.Row.Cells[15].Text = GNetAmount.ToString("f2");


                lbltaxablesalesorder.Text = TaxableSales.ToString("f2");
                lblcgstorder.Text = GGSTAmt.ToString("f2");
                lblnetamountorder.Text = (GNetAmount).ToString("f2");

                double n = 0;

                double roundoff = Convert.ToDouble(lblnetamountorder.Text) - Math.Floor(Convert.ToDouble(lblnetamountorder.Text));
                if (roundoff >= 0.5)
                {
                    n = Math.Round(Convert.ToDouble(lblnetamountorder.Text), MidpointRounding.AwayFromZero);
                }
                else
                {
                    n = Math.Floor(Convert.ToDouble(lblnetamountorder.Text));
                }

                lblfinalamountorder.Text = string.Format("{0:N2}", n);
                double rndoff = Convert.ToDouble(lblfinalamountorder.Text) - Convert.ToDouble(lblnetamountorder.Text);
                lblroundofforder.Text = string.Format("{0:N2}", Convert.ToDouble(rndoff));

            }
        }

    }
}