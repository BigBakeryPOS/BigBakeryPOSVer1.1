using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class Invoice_print1 : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        decimal tax;
        string sTableName = "";
        decimal totalAmount = 0;  
       decimal TotalTaxAmount = 0;
        decimal CGSTAmount=0;
        decimal totaltax = 0;
        string scode="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"]["User"] != null)
            {
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
                scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            }
            else
                Response.Redirect("Login_Branch.aspx");

            if (!IsPostBack)
            {

                string ID = Request.QueryString.Get("SalesId");
                if (ID != null)
                {
                   
                   

                    DataSet ds = objBs.getwholeSaleprint(sTableName, (ID));
                    DataSet ds1 = objBs.getbranchdetails1(scode);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count>0)
                        {

                            lblbranch.Text = ds1.Tables[0].Rows[0]["branchname"].ToString();
                            lblbranch1.Text = ds1.Tables[0].Rows[0]["branchname"].ToString();
                            lblbranchaddress.Text = ds1.Tables[0].Rows[0]["address"].ToString();
                            lblcountry.Text = ds1.Tables[0].Rows[0]["Country"].ToString();
                            lblstate1.Text = ds1.Tables[0].Rows[0]["State"].ToString();
                            lblcity1.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                            lblMobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                            lblgstin.Text = ds1.Tables[0].Rows[0]["GSTIN"].ToString();
                            lblemail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();


                                }
                        lblDeliveryNoteNo.Text = ds.Tables[0].Rows[0]["FullBillNo"].ToString();
                        lblDated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BillDate"]).ToString("dd/MM/yyyy");

                      //  lblDespatchedThrough.Text = ds.Tables[0].Rows[0]["VehicleNo"].ToString();
                        lblAmountinwords.Text = objBs.changeToWords(ds.Tables[0].Rows[0]["GrandTotal"].ToString(), true);

                        // GETTING BRANCH
                        lblbuyer.Text = ds.Tables[0].Rows[0]["CustomerName1"].ToString();
                        lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        lblcity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        lblstate.Text = ds.Tables[0].Rows[0]["Area"].ToString();
                        lblgst.Text = ds.Tables[0].Rows[0]["GSTno"].ToString();
                        
                        #region Grid Bind

                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;
                        DataSet dstd = new DataSet();
                        dttt = new DataTable();

                        dct = new DataColumn("SNo");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("ItemName");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("HSNCode");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Quantity");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Rate");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Per");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dttt.Columns.Add(dct);

                        dstd.Tables.Add(dttt);

                        int iSNo = 1;
                        DataSet tds = objBs.getTranswholeSaleprint(sTableName, (ID));
                        
                        decimal total = 0;
                        foreach (DataRow Dr in tds.Tables[0].Rows)
                        {
                            drNew = dttt.NewRow();
                            drNew["SNo"] = iSNo;
                            drNew["ItemName"] = Dr["definition"];
                            drNew["HSNCode"] = Dr["hsncode"];
                            string quantity = Dr["qty"].ToString() + ' ' + Dr["UOM"].ToString();
                            drNew["Quantity"] = quantity;

                           
                            if ((Dr["tax"] == "") || (Dr["tax"] == null))
                                tax = 0;
                            else
                                tax = Convert.ToDecimal(Dr["tax"]);

                            drNew["Rate"] = Math.Round(Convert.ToDecimal(Dr["Rate"]), 2);
                            drNew["Per"] = Dr["Per"];
                            drNew["Amount"] = Math.Round((Convert.ToDecimal(Dr["qty"]) * Convert.ToDecimal(Dr["Rate"])), 2);
                            total = total + Math.Round(Convert.ToDecimal(drNew["Amount"]), 2);

                            dstd.Tables[0].Rows.Add(drNew);

                            iSNo++;
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            drNew = dttt.NewRow();
                            drNew["SNo"] = "";
                            drNew["HSNCode"] = "";
                            drNew["Quantity"] = "";
                            drNew["Rate"] = "";
                            drNew["Per"] = "";

                            if (i == 0)
                            {
                                drNew["ItemName"] = "";
                                drNew["Amount"] = "-------------";
                            }
                            if (i == 1)
                            {
                                drNew["ItemName"] = "";
                                drNew["Amount"] = total;
                            }
                            if (i == 2)
                            {
                                drNew["ItemName"] = "CGST @" + (tax / 2)+" %";
                                drNew["Amount"] = ds.Tables[0].Rows[0]["CGST"];
                                drNew["Rate"] = (tax / 2);
                                drNew["Per"] = "%";
                            }

                            if (i == 3)
                            {
                                drNew["ItemName"] = "SGST @" + (tax / 2)+" %";
                                drNew["Amount"] = ds.Tables[0].Rows[0]["SGST"];
                                drNew["Rate"] = (tax / 2);
                                drNew["Per"] = "%";
                            }


                            totalAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["SGST"]) + Convert.ToDecimal(ds.Tables[0].Rows[0]["CGST"]) + total;
                            dstd.Tables[0].Rows.Add(drNew);
                        }

                     

                        for (int i = 0; i < 5; i++)
                        {
                            drNew = dttt.NewRow();
                            drNew["SNo"] = "";
                            drNew["ItemName"] = "";
                            drNew["HSNCode"] = "";
                            drNew["Quantity"] = "";
                            drNew["Rate"] = "";
                            drNew["Per"] = "";
                            drNew["Amount"] = "";
                            dstd.Tables[0].Rows.Add(drNew);
                        }

                        #endregion

                        GVPrint.DataSource = dstd;
                        GVPrint.DataBind();

                        #region Grid Bind GST

                        DataTable dtttg;
                        DataRow drNewg;
                        DataColumn dctg;
                        DataSet dstdg = new DataSet();
                        dtttg = new DataTable();

                        dctg = new DataColumn("HSNCode");
                        dtttg.Columns.Add(dctg);

                        dctg = new DataColumn("TaxAmount");
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


                        dctg = new DataColumn("Tax");
                        dtttg.Columns.Add(dctg);

                        dstdg.Tables.Add(dtttg);


                        DataSet dsOrGSTHSN = null;
                        dsOrGSTHSN = objBs.getTranswholeSaleprint(sTableName, (ID));


                        if (dsOrGSTHSN.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dsOrGSTHSN.Tables[0].Rows.Count; j++)
                            {
                                drNewg = dtttg.NewRow();

                                drNewg["HSNCode"] = dsOrGSTHSN.Tables[0].Rows[j]["HSNCode"].ToString();
                                decimal taxamt;
                                taxamt = Convert.ToDecimal(dsOrGSTHSN.Tables[0].Rows[j]["Rate"]) * Convert.ToDecimal(dsOrGSTHSN.Tables[0].Rows[j]["Qty"]);

                                drNewg["TaxAmount"] = taxamt.ToString("f2");

                                tax = Convert.ToDecimal(dsOrGSTHSN.Tables[0].Rows[j]["GST"]) / 2;
                                drNewg["CGSTRate"] = tax.ToString() + " %";

                                decimal CGSTAmount;
                                CGSTAmount = Convert.ToDecimal(dsOrGSTHSN.Tables[0].Rows[j]["TaxAmount"]) / 2;
                                drNewg["CGSTAmount"] = CGSTAmount.ToString("f2");

                                drNewg["SGSTRate"] = tax.ToString() + " %";
                                drNewg["SGSTAmount"] = CGSTAmount.ToString("f2");

                                drNewg["Amount"] = Convert.ToDouble(dsOrGSTHSN.Tables[0].Rows[j]["TaxAmount"]).ToString("f2");
                                drNewg["Tax"] = Convert.ToDecimal(dsOrGSTHSN.Tables[0].Rows[j]["Tax"]).ToString("f2");

                                dstdg.Tables[0].Rows.Add(drNewg);

                                
                            }
                        }


                        var result = from r in dstdg.Tables[0].AsEnumerable()
                                     group r by new { taxvalue = r["Tax"], hsncode = r["HSNCode"] } into g
                                     select new
                                     {
                                         taxvalue = g.Key.taxvalue,
                                         hsncode = g.Key.hsncode,
                                        
                                         value = g.Sum(x => Convert.ToDouble(x["TaxAmount"])),
                                         Cgst = g.Sum(x => Convert.ToDouble(x["CGSTAmount"])),
                                         Sgst = g.Sum(x => Convert.ToDouble(x["SGSTAmount"])),
                                        Total = g.Sum(x => Convert.ToDouble(x["Amount"])),
                                         //  Igst = g.Sum(x => Convert.ToDouble(x["Igst"]))
                                     };




                        DataSet dsnew=new DataSet();
                            DataTable dtnew = dtttg.Clone();
                        foreach (var g in result)
                        {
                            drNewg = dtnew.NewRow();
                            drNewg["HSNCode"] = g.hsncode;
                            drNewg["TaxAmount"] = g.value.ToString("f2");

                            tax= Convert.ToDecimal( g.taxvalue)/2;
                            drNewg["CGSTRate"] = tax+" %";
                            drNewg["CGSTAmount"] = g.Cgst;

                            drNewg["SGSTRate"] =tax+" %";
                            drNewg["SGSTAmount"] = g.Sgst;


                            drNewg["Amount"] = g.Total;
                              drNewg["Tax"] = tax*2;
                              dtnew.Rows.Add(drNewg);
                             
                        }

                        dsnew.Tables.Add(dtnew);

                        #endregion

                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            gvGST.DataSource = dsnew;
                            gvGST.DataBind();
                        }

                 //       lblTaxAmountinwords.Text = objBs.changeToWords(lblTaxAmountinwords.Text, true);


                    }

                }
            }
        }

        protected void GVPrint_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[6].Text = totalAmount.ToString("f2");
            }
        }

        protected void gvGST_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totaltax += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
    
                 CGSTAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CGSTAmount"));
                TotalTaxAmount += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TaxAmount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total";
      
                e.Row.Cells[1].Text = TotalTaxAmount.ToString("f2");
               
                 e.Row.Cells[3].Text = CGSTAmount.ToString("f2");
                e.Row.Cells[5].Text = CGSTAmount.ToString("f2");
                decimal total= Convert.ToDecimal(TotalTaxAmount) + Convert.ToDecimal(CGSTAmount) + Convert.ToDecimal(CGSTAmount);
                e.Row.Cells[6].Text = totaltax.ToString("f2");
                lblTaxAmountinwords.Text = objBs.changeToWords(totaltax.ToString(), true);
           }

            
        }

        protected void btnexit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("wholesalesGrid.aspx");
        }


    }
}