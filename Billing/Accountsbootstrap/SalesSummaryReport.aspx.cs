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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
namespace Billing.Accountsbootstrap
{
    public partial class SalesSummaryReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();

        string sTableName = "";
        int BillCount = 0;
        double NetAmount = 0; double DisCount = 0; double TaxValue = 0; double TotalAmount = 0;
        double NetAmount1 = 0; double DisCount1 = 0; double TaxValue1 = 0; double TotalAmount1 = 0;

        int Quantity = 0; double Amount = 0; double Disc = 0; double TaxAmount = 0; double NetAmountItem = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            }
        }

        // Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime From = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime To = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            lblheading.Text = "Daily Summary Report From " + From.ToString("dd/MM/yyyy") + " To " + To.ToString("dd/MM/yyyy");

            #region

            // 1,Bill Count Details
            DataSet dsBillCount = objbs.getSalesBillCount(sTableName, From, To);
            if (dsBillCount.Tables[0].Rows.Count > 0)
            {
                GVBillCount.DataSource = dsBillCount;
                GVBillCount.DataBind();
            }
            else
            {
                GVBillCount.DataSource = null;
                GVBillCount.DataBind();
            }

            // 2,Cancel Bill Count Details
            DataSet dsCancelSalesBillCount = objbs.getCancelSalesBillCount(sTableName, From, To);
            if (dsBillCount.Tables[0].Rows.Count > 0)
            {
                GVCancelBill.DataSource = dsCancelSalesBillCount;
                GVCancelBill.DataBind();
            }
            else
            {
                GVCancelBill.DataSource = null;
                GVCancelBill.DataBind();
            }

            // 3,Sales Tax Details
            DataSet dsSalesBillItemCouunt = objbs.getSalesTaxDetails(sTableName, From, To);
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

            // 4, category wise report
            DataSet dssalescategorywise = objbs.getSalesTaxDetails_Categorywise(sTableName, From, To);
            if(dssalescategorywise.Tables[0].Rows.Count >0)
            {
                gvcategorywise.DataSource = dssalescategorywise;
                gvcategorywise.DataBind();
            }
            else
            {
                gvcategorywise.DataSource = null;
                gvcategorywise.DataBind();
            }

            // 5, overall details report
            #region SUMMARY VIEW
            DataTable dsumview = new DataTable();
            DataRow drsum = dsumview.NewRow();

            dsumview.Columns.Add("Name");
            dsumview.Columns.Add("Value");


            // DATE

            drsum["Name"] = "Date";
            drsum["Value"] = Convert.ToDateTime(From).ToString("dd/MM/yyyy") + '-' + Convert.ToDateTime(To).ToString("dd/MM/yyyy");
            dsumview.Rows.Add(drsum);


            // Counter Sales


            DataSet getcountersales = objbs.getcountersales_summarydatewise(sTableName, "1", "'adv','Bal','Full','Partial Amount'",From,To);

            for (int i = 0; i < getcountersales.Tables[0].Rows.Count; i++)
            {

                string name = getcountersales.Tables[0].Rows[i]["name"].ToString();

                if (name == "Sales")
                {
                    if (getcountersales.Tables[0].Rows.Count > 0)
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Counter Sales (CASH)";
                        drsum["Value"] = Convert.ToDouble(getcountersales.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dsumview.Rows.Add(drsum);
                    }
                    else
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Counter Sales (CASH)";
                        drsum["Value"] = "0";
                        dsumview.Rows.Add(drsum);
                    }

                }
                else if (name == "Order")
                {
                    if (getcountersales.Tables[0].Rows.Count > 0)
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Order Form Sales (CASH)";
                        drsum["Value"] = Convert.ToDouble(getcountersales.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dsumview.Rows.Add(drsum);
                    }
                    else
                    {
                        drsum = dsumview.NewRow();
                        drsum["Name"] = "Order Form Sales (CASH)";
                        drsum["Value"] = "0";
                        dsumview.Rows.Add(drsum);
                    }

                }
            }

            // get opnline  sales
            double summaryonlie = 0;
            DataSet summaryonlinesales = objbs.Onlinesales_distribution_datewise(sTableName, "'1','9'",From,To);
            if (summaryonlinesales.Tables[0].Rows.Count > 0)
            {
                for (int ii = 0; ii < summaryonlinesales.Tables[0].Rows.Count; ii++)
                {
                    double ONtot = Convert.ToDouble(summaryonlinesales.Tables[0].Rows[ii]["Total"]);
                    summaryonlie += ONtot;
                }
                drsum = dsumview.NewRow();
                drsum["Name"] = "Online Sales";
                drsum["Value"] = Convert.ToDouble(summaryonlie).ToString("0.00");
                dsumview.Rows.Add(drsum);
            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Online Sales";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }


            // GET ALL CARD
            DataSet getsummarycardetailss = objbs.getcarddetails_datewise(sTableName, "4",From,To);
            if (getsummarycardetailss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double cardordertot = 0;
                for (int co = 0; co < getsummarycardetailss.Tables[0].Rows.Count; co++)
                {
                    modename = getsummarycardetailss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsummarycardetailss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    cardordertot += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = "Card Sales";
                drsum["Value"] = cardordertot.ToString("0.00");
                dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Actual Card Amount";
                //drsum["Value"] = Convert.ToDouble(lbloverallcard.Text).ToString("0.00");
                //dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Difference in Card Amount +/-";
                //drsum["Value"] = (Convert.ToDouble(lbloverallcard.Text) - Convert.ToDouble(cardordertot)).ToString("0.00");
                //dsumview.Rows.Add(drsum);

            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Card Sales";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }

            // GET PAYTM
            DataSet getsumcardetailsss = objbs.getcarddetails_datewise(sTableName, "10",From,To);
            if (getsumcardetailsss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double paytmordertot = 0;
                for (int co = 0; co < getsumcardetailsss.Tables[0].Rows.Count; co++)
                {
                    modename = getsumcardetailsss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsumcardetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    paytmordertot += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = modename;
                drsum["Value"] = paytmordertot;
                dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Actual Paytm Amount";
                //drsum["Value"] = Convert.ToDouble(lbloverallpaytm.Text).ToString("0.00");
                //dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Difference in Paytm Amount +/-";
                //drsum["Value"] = (Convert.ToDouble(lbloverallpaytm.Text) - Convert.ToDouble(paytmordertot)).ToString("0.00");
                //dsumview.Rows.Add(drsum);


            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Paytm";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }

            // GET PhonePe
            DataSet getsumcardetailssss = objbs.getcarddetails_datewise(sTableName, "17",From,To);
            if (getsumcardetailssss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double phonepeordertot = 0;
                for (int co = 0; co < getsumcardetailssss.Tables[0].Rows.Count; co++)
                {
                    modename = getsumcardetailssss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsumcardetailssss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    phonepeordertot += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = modename;
                drsum["Value"] = phonepeordertot;
                dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Actual PhonePe Amount";
                //drsum["Value"] = Convert.ToDouble(lbloverallphonepe.Text).ToString("0.00");
                //dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Difference in PhonePe Amount +/-";
                //drsum["Value"] = (Convert.ToDouble(lbloverallphonepe.Text) - Convert.ToDouble(phonepeordertot)).ToString("0.00");
                //dsumview.Rows.Add(drsum);


            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "PhonePe";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }
            


            // GET ALL EXPENSE
            DataSet getsumtotalexpense = objbs.gettotalexpense_Datewise(sTableName, From,To);
            if (getsumtotalexpense.Tables[0].Rows.Count > 0)
            {
                drsum = dsumview.NewRow();
                drsum["name"] = "Total Expense";
                drsum["Value"] = Convert.ToDouble(getsumtotalexpense.Tables[0].Rows[0]["Amount"]).ToString("0.00");
                dsumview.Rows.Add(drsum);
            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["name"] = "Total Expense";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }

            

            // GET Credit Sales
            DataSet getsumcreditetailsss = objbs.getcarddetails_datewise(sTableName, "5",From,To);
            if (getsumcreditetailsss.Tables[0].Rows.Count > 0)
            {
                string modename = string.Empty;
                double totsumcreditsales = 0;
                for (int co = 0; co < getsumcreditetailsss.Tables[0].Rows.Count; co++)
                {
                    modename = getsumcreditetailsss.Tables[0].Rows[co]["paymode"].ToString();
                    string Total = Convert.ToDouble(getsumcreditetailsss.Tables[0].Rows[co]["Total"]).ToString("0.00");

                    totsumcreditsales += Convert.ToDouble(Total);
                }

                drsum = dsumview.NewRow();
                drsum["Name"] = modename;
                drsum["Value"] = totsumcreditsales;
                dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Actual Credit Amount";
                //drsum["Value"] = Convert.ToDouble(lblcreditamount.Text).ToString("0.00");
                //dsumview.Rows.Add(drsum);


                //drsum = dsumview.NewRow();
                //drsum["Name"] = "Difference in Credit Amount +/-";
                //drsum["Value"] = (Convert.ToDouble(lblcreditamount.Text) - Convert.ToDouble(totsumcreditsales)).ToString("0.00");
                //dsumview.Rows.Add(drsum);


            }
            else
            {
                drsum = dsumview.NewRow();
                drsum["Name"] = "Credit Amount";
                drsum["Value"] = "0";
                dsumview.Rows.Add(drsum);
            }


            // Discount sales

            DataSet getdiscountsalesandorder = objbs.getcountersalesandorderdiscount_datewise( sTableName,From,To);
            if (getdiscountsalesandorder.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < getdiscountsalesandorder.Tables[0].Rows.Count; i++)
                {
                    string name = getdiscountsalesandorder.Tables[0].Rows[i]["name"].ToString();
                    string money = getdiscountsalesandorder.Tables[0].Rows[i]["Total"].ToString();
                    if (money != "0.0000")
                    {

                        drsum = dsumview.NewRow();
                        drsum["Name"] = name;
                        drsum["Value"] = Convert.ToDouble(money).ToString("0.00");
                        dsumview.Rows.Add(drsum);
                    }
                }
            }



            //// + OR -
            //drsum = dsumview.NewRow();
            //drsum["name"] = "Difference in Cash Amount +/-";
            //drsum["Value"] = lbldifferencevaluecolumn1.Text;
            //dsumview.Rows.Add(drsum);

            GridsummaryView.DataSource = dsumview;
            GridsummaryView.DataBind();

            #endregion
                
            // 6, item wise details
            DataSet dsGVSalesBillItemDetails = objbs.getSalesItemQtyDetails(sTableName, From, To);
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


            #endregion

        }

        protected void gridsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {
        }

        //Export to Excel
        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=SalesandStockSummary.xls");
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


        protected void btnpdf_Click(object sender, EventArgs e)
        {
            ExportToPDF(sender, e);
        }
        protected void ExportToPDF(object sender, EventArgs e)
        {
            if (GVBillCount.Rows.Count > 0)
            {
                using (StringWriter sw = new StringWriter())
                {
                    #region
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {

                        lblheading.RenderControl(hw);
                        GVBillCount.RenderControl(hw);
                        GVCancelBill.RenderControl(hw);
                        GVSalesTaxReport.RenderControl(hw);
                        GVSalesQtyReport.RenderControl(hw);

                        GVSalesQtyReport.HeaderRow.Style.Add("width", "6%");
                        GVSalesQtyReport.HeaderRow.Style.Add("font-size", "8px");
                        GVSalesQtyReport.Style.Add("text-decoration", "none");
                        GVSalesQtyReport.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                        GVSalesQtyReport.Style.Add("font-size", "6px");

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=SalesSummaryReport.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);

                        Response.Write(pdfDoc);
                        Response.End();
                    }

                    #endregion
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Data.');", true);
                return;
            }
        }


        protected void GVBillCount_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BillCount += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BillCount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total:-";
                e.Row.Cells[3].Text = BillCount.ToString();
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

        protected void GVcategorywise_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NetAmount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                DisCount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DisCount"));
                TaxValue1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TaxValue"));
                TotalAmount1 += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total:-";
                e.Row.Cells[3].Text = NetAmount1.ToString("f2");
                e.Row.Cells[4].Text = DisCount1.ToString("f2");
                e.Row.Cells[5].Text = TaxValue1.ToString("f2");
                e.Row.Cells[6].Text = TaxValue1.ToString("f2");
                e.Row.Cells[7].Text = TotalAmount1.ToString("f2");
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
        protected void GVSalesQtyReport_OnSorting(object sender, GridViewSortEventArgs e)
        {
            DataTable SalesQtyReport = (DataTable)ViewState["SalesQtyReport"];
            if (SalesQtyReport.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["SalesQtyReportSort"]) == "Asc")
                {
                    SalesQtyReport.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["SalesQtyReportSort"] = "Desc";
                }
                else
                {
                    SalesQtyReport.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["SalesQtyReportSort"] = "Asc";
                }

                GVSalesQtyReport.DataSource = SalesQtyReport;
                GVSalesQtyReport.DataBind();
            }

        }
    }
}