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
    public partial class FulDayreport : System.Web.UI.Page
    {
        string sTableName = ""; string Password = "";
        BSClass objbs = new BSClass();

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

        double TotNetAmount = 0;
        double Tottaxamount = 0;
        double TotPayamount = 0;


        double GMargin = 0;
        double GBasicValue = 0;
        double GGSTAmt = 0;
        double GNetAmount = 0;
        double SalesExempted = 0; double TaxableSales = 0;
        double NetAmount = 0; double DisCount = 0; double TaxValue = 0; double TotalAmount = 0;

        int Quantity = 0; double Amount = 0; double Disc = 0; double TaxAmount = 0; double NetAmountItem = 0;

        string Btype = "";

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

                DataSet paymode = objbs.Paymodevalues(sTableName);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drpPayment.DataSource = paymode.Tables[0];
                    drpPayment.DataTextField = "PayMode";
                    drpPayment.DataValueField = "Value";
                    drpPayment.DataBind();
                    drpPayment.Items.Insert(0, "All");
                }
            }
        }

        protected void drppayment_selectedindex(object sender, EventArgs e)
        {

            //if (dsbranch1.Tables[0].Rows.Count > 0)
            {


                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drpPayment.SelectedItem.Value;

                DataSet dcustbranch = objbs.CustomerSalesBranchpaymode(sTableName, sFrom, sTo, paymode);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {

                }

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();
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

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        public void gvsalescancel_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }



        public void gvordersales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double NetAmount = 0;
            double taxamount = 0;
            double Payamount = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                taxamount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "taxamount"));
                Payamount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Payamount"));


                TotNetAmount = TotNetAmount + NetAmount;
                Tottaxamount = Tottaxamount + taxamount;
                TotPayamount = TotPayamount + Payamount;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total :-";
                e.Row.Cells[6].Text = TotNetAmount.ToString("f2");
                e.Row.Cells[7].Text = Tottaxamount.ToString("f2");
                e.Row.Cells[8].Text = TotPayamount.ToString("f2");

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


            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            string paymode = drpPayment.SelectedItem.Value;

            DataSet dcustbranch = objbs.CustomerSalesBranchpaymode(sTableName, sFrom, sTo, paymode);
            if (dcustbranch.Tables[0].Rows.Count > 0)
            {
                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();
            }
            else
            {
                gvCustsales.DataSource = null;
                gvCustsales.DataBind();
            }



            DataSet dcustbranch1 = objbs.CustomerSalesBranchpaymodenew(sTableName, sFrom, sTo, paymode);
            if (dcustbranch1.Tables[0].Rows.Count > 0)
            {
                gvordersales.DataSource = dcustbranch1.Tables[0];
                gvordersales.DataBind();
                // gvordersales.Caption = "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                gvordersales.DataSource = null;
                gvordersales.DataBind();
            }


            DataSet dcustbranch2 = objbs.CustomerSalesBranchbillcancel(sTableName, sFrom, sTo, paymode);
            if (dcustbranch2.Tables[0].Rows.Count > 0)
            {
                gvsalescancel.DataSource = dcustbranch2.Tables[0];
                gvsalescancel.DataBind();
            }
            else
            {
                gvsalescancel.DataSource = null;
                gvsalescancel.DataBind();
            }

            DataSet dsordercancel = objbs.OrderFormCancel(sTableName, sFrom.ToString("yyyy-MM-dd"), sTo.ToString("yyyy-MM-dd")); ;
            if (dsordercancel.Tables[0].Rows.Count > 0)
            {
                gvOrderFormcancel.DataSource = dsordercancel.Tables[0];
                gvOrderFormcancel.DataBind();
            }
            else
            {
                gvOrderFormcancel.DataSource = null;
                gvOrderFormcancel.DataBind();
            }




            // if (ddltype.SelectedValue == "1")
            {
                DataSet dRet = objbs.getReturnreports(sTableName, sFrom, sTo, ddlreason.SelectedValue);
                if (dRet.Tables[0].Rows.Count > 0)
                {
                    gvReturns.DataSource = dRet;
                    gvReturns.DataBind();
                }
            }
            // else if (ddltype.SelectedValue == "2")
            {
                DataSet dspaymententry = objbs.getpaymententryreports(sFrom, sTo, sTableName);
                if (dspaymententry.Tables[0].Rows.Count > 0)
                {
                    gridledger.DataSource = dspaymententry;
                    gridledger.DataBind();
                }
            }
            //   else if (ddltype.SelectedValue == "3")
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
                ds = objbs.getstaffcreditsalesreports(sTableName, sFrom, sTo, "9");
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
            //  else if (ddltype.SelectedValue == "4")
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

            // 3,Sales Tax Details
            DataSet dsSalesBillItemCouunt = objbs.getSalesTaxDetails(sTableName, sFrom, sTo);
            if (dsSalesBillItemCouunt.Tables[0].Rows.Count > 0)
            {
                GVSalesTaxReport.DataSource = dsSalesBillItemCouunt;
                GVSalesTaxReport.DataBind();
            }
            else
            {
                GVSalesTaxReport.DataSource = null;
                GVSalesTaxReport.DataBind();
            }

            DataSet dsGVSalesBillItemDetails = objbs.getSalesItemQtyDetails(sTableName, sFrom, sTo);
            if (dsGVSalesBillItemDetails.Tables[0].Rows.Count > 0)
            {
                GVSalesQtyReport.DataSource = dsGVSalesBillItemDetails;
                GVSalesQtyReport.DataBind();

                ViewState["SalesQtyReport"] = dsGVSalesBillItemDetails.Tables[0];
                ViewState["SalesQtyReportSort"] = "Asc";
            }
            else
            {
                GVSalesQtyReport.DataSource = null;
                GVSalesQtyReport.DataBind();
            }

        }

        protected void GVSalesTaxReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                DisCount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DisCount"));
                TaxValue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TaxValue"));
                TotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total:-";
                e.Row.Cells[2].Text = NetAmount.ToString("f2");
                e.Row.Cells[3].Text = DisCount.ToString("f2");
                e.Row.Cells[4].Text = TaxValue.ToString("f2");
                e.Row.Cells[5].Text = TaxValue.ToString("f2");
                e.Row.Cells[6].Text = TotalAmount.ToString("f2");
            }
        }

        protected void GVSalesQtyReport_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Quantity += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                Amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                Disc += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Disc"));
                TaxAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TaxAmount"));
                NetAmountItem += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total:-";
                e.Row.Cells[3].Text = Quantity.ToString();
                e.Row.Cells[4].Text = Amount.ToString("f2");
                e.Row.Cells[5].Text = Disc.ToString("f2");
                e.Row.Cells[6].Text = TaxAmount.ToString("f2");
                e.Row.Cells[7].Text = TaxAmount.ToString("f2");
                e.Row.Cells[8].Text = NetAmountItem.ToString("f2");
            }

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
    }
}