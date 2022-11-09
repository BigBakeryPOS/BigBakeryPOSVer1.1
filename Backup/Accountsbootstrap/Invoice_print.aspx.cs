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
    public partial class Invoice_print : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double Amount = 0; double WeightorKg = 0;
        double TaxableValue = 0; double CentralAmount = 0; double StateAmount = 0; double TotalTaxAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"]["User"] != null)
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            if (!IsPostBack)
            {

                string ID = Request.QueryString.Get("iinvoiceID");
                if (ID != null)
                {
                    DataSet ds = new DataSet();
                  //  DataSet dsGST = new DataSet();
                    DataSet dsOnlyGST = new DataSet();

                    string T = Request.QueryString.Get("T");
                   // if (T == "Request")
                    {
                        ds = objBs.getprintforinvoice(sTableName,(ID));
                      //  dsGST = objBs.GetInternalTransferPrintGST(Convert.ToInt32(ID));
                       dsOnlyGST = objBs.GetInternalTransferPrintOnlyGST(sTableName,(ID));
                    }
                   
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblDeliveryNoteNo.Text = ds.Tables[0].Rows[0]["FullInvoiceNo"].ToString();
                        lblDated.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InvoiceDate"]).ToString("dd/MM/yyyy");

                        lblDespatchedThrough.Text = ds.Tables[0].Rows[0]["VehicleNo"].ToString();
                       // lblDestination.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();

                        lblAmountinwords.Text = objBs.changeToWords(ds.Tables[0].Rows[0]["RoundOff"].ToString(), true);

                        // GETTING BRANCH
                        lblbuyer.Text = ds.Tables[0].Rows[0]["FranchiseeName"].ToString();
                        lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        lblcity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        lblstate.Text = ds.Tables[0].Rows[0]["State"].ToString();
                        lblcode.Text = "33"; //ds.Tables[0].Rows[0][""].ToString();

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
                        dct = new DataColumn("WeightorKg");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Rate");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Per");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("nos");
                        dttt.Columns.Add(dct);

                        dstd.Tables.Add(dttt);

                        int iSNo = 1;
                        foreach (DataRow Dr in ds.Tables[0].Rows)
                        {
                            drNew = dttt.NewRow();
                            drNew["SNo"] = iSNo;
                            drNew["ItemName"] = Dr["definition"];
                            drNew["HSNCode"] = Dr["hsncode"];
                            drNew["WeightorKg"] = Dr["qty"];
                            drNew["Rate"] = "0";
                            drNew["Per"] = "0";
                            drNew["Amount"] = "0";
                            drNew["nos"] = Dr["uom"];

                            dstd.Tables[0].Rows.Add(drNew);

                            iSNo++;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            drNew = dttt.NewRow();
                            drNew["SNo"] = "";
                            drNew["ItemName"] = "";
                            drNew["HSNCode"] = "";
                            drNew["WeightorKg"] = "";
                            drNew["Rate"] = "";
                            drNew["Per"] = "";
                            drNew["Amount"] = "";
                            drNew["nos"] = "";

                            dstd.Tables[0].Rows.Add(drNew);
                        }

                        //foreach (DataRow Dr in dsGST.Tables[0].Rows)
                        //{
                        //    drNew = dttt.NewRow();
                        //    drNew["SNo"] = "";
                        //    drNew["ItemName"] = Dr["ItemName"];
                        //    drNew["HSNCode"] = "";
                        //    drNew["WeightorKg"] = "";
                        //    drNew["Rate"] = Dr["Rate"];
                        //    drNew["Per"] = Dr["Per"];
                        //    drNew["Amount"] = Convert.ToDouble(Dr["Amount"]).ToString("f2");

                        //    dstd.Tables[0].Rows.Add(drNew);
                        //}

                        //for (int i = 0; i < 5; i++)
                        //{
                        //    drNew = dttt.NewRow();
                        //    drNew["SNo"] = "";
                        //    drNew["ItemName"] = "";
                        //    drNew["HSNCode"] = "";
                        //    drNew["WeightorKg"] = "";
                        //    drNew["Rate"] = "";
                        //    drNew["Per"] = "";
                        //    drNew["Amount"] = "";

                        //    dstd.Tables[0].Rows.Add(drNew);
                        //}

                        #endregion

                        GVPrint.DataSource = dstd;
                        GVPrint.DataBind();

                        #region Grid Bind GST

                        

                        #endregion

                        if (dsOnlyGST.Tables[0].Rows.Count > 0)
                        {
                            GVPrintGST.DataSource = dsOnlyGST;
                            GVPrintGST.DataBind();
                        }

                        lblTaxAmountinwords.Text = objBs.changeToWords(lblTaxAmountinwords.Text, true);

                        
                    }

                }
            }
        }

        protected void GVPrint_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((DataBinder.Eval(e.Row.DataItem, "WeightorKg")).ToString() != "")
                {
                    WeightorKg += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WeightorKg"));
                }
                //if ((DataBinder.Eval(e.Row.DataItem, "Amount")).ToString() != "")
                //{
                //    Amount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                //}
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[4].Text = WeightorKg.ToString("f2");
                //e.Row.Cells[6].Text = Amount.ToString("f2");
            }
        }

        protected void GVPrintGST_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // TaxableValue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TaxableValue"));
               // CentralAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CentralAmount"));
               // StateAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StateAmount"));
                TotalTaxAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "netamount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
             //   e.Row.Cells[2].Text = TaxableValue.ToString("f2");
             //   e.Row.Cells[4].Text = CentralAmount.ToString("f2");
             //   e.Row.Cells[6].Text = StateAmount.ToString("f2");
                e.Row.Cells[2].Text = TotalTaxAmount.ToString("f2");

                lblTaxAmountinwords.Text = TotalTaxAmount.ToString("f2");
            }
        }

        protected void btnexit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("billinvoicegrid.aspx");
        }


    }
}