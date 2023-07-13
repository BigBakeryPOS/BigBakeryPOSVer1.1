using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class Purchase_Return : System.Web.UI.Page
    {
        string sTableName = "";
        string scode = "";
        BSClass kbs = new BSClass();
        string Rate = "";
        string Biller = "";
        string Billerid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();

            Biller = Request.Cookies["userInfo"]["Biller"].ToString();
            Billerid = Request.Cookies["userInfo"]["Empid"].ToString();


            lblbillername.Text = Biller;
            lblbillerid.Text = Billerid;


            if (!Page.IsPostBack)
            {
                rbdpurchasetype.SelectedValue = "1";

                DataSet dsCustomer = kbs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "Select Supplier");


                }

                DataSet Paymode = kbs.GetOthersPaymode();
                if (Paymode.Tables[0].Rows.Count > 0)
                {
                    ddlpaymode.DataSource = Paymode.Tables[0];
                    ddlpaymode.DataTextField = "Paymode";
                    ddlpaymode.DataValueField = "Value";
                    ddlpaymode.DataBind();
                    ddlpaymode.Items.Insert(0, "Select Paymode");

                    ddlbank.Enabled = false;
                    txtcheque.Enabled = false;

                    ddlbank.Visible = false;
                    txtcheque.Visible = false;

                    lblbank.Visible = false;
                    lblChq.Visible = false;
                }

                DataSet dssubcompany = kbs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    drpsubcompany.DataSource = dssubcompany.Tables[0];
                    drpsubcompany.DataTextField = "CustomerName1";
                    drpsubcompany.DataValueField = "subComapanyID";
                    drpsubcompany.DataBind();
                    // drpsubcompany.Items.Insert(0, "Select Company");


                }

                DataSet bank = kbs.Ledgerbank();
                if (bank.Tables[0].Rows.Count > 0)
                {
                    ddlbank.DataSource = bank.Tables[0];
                    ddlbank.DataTextField = "LedgerName";
                    ddlbank.DataValueField = "LedgerID";
                    ddlbank.DataBind();
                    ddlbank.Items.Insert(0, "Select Bank");
                }

                //DataSet dsPO = kbs.PurchaseInvoiceNoList(sTableName);
                //if (dsPO.Tables[0].Rows.Count > 0)
                //{
                //    drpPO.DataSource = dsPO.Tables[0];
                //    drpPO.DataTextField = "DCNO";
                //    drpPO.DataValueField = "PurchaseID";
                //    drpPO.DataBind();
                //    drpPO.Items.Insert(0, "Select Purchase InvoiceNo");
                //}

                rbtype_OnSelectedIndexChanged(sender, e);
                DataSet dNo = kbs.entryno(sTableName);
                txtbillno.Text = dNo.Tables[0].Rows[0]["billno"].ToString();

                txtsdate1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                Button1.Text = "Save";

                FirstGridViewRow();

                string iSalesID = Request.QueryString.Get("LedgerID");
                if (iSalesID != null)
                {
                    #region

                    DataSet dagent = kbs.getduplistrtn(iSalesID, sTableName);
                    if (dagent.Tables[0].Rows.Count > 0)
                    {
                        shwedit.Visible = true;
                        hdPurid.Value = dagent.Tables[0].Rows[0]["purchasertnid"].ToString();
                        txtbillno.Text = dagent.Tables[0].Rows[0]["BillNo"].ToString();
                        txtdcno.Text = dagent.Tables[0].Rows[0]["DCNo"].ToString();
                        lblpurchase.InnerText = dagent.Tables[0].Rows[0]["BillNo"].ToString();
                        drpsubcompany.SelectedValue = dagent.Tables[0].Rows[0]["subcompanyid"].ToString();
                        txtsdate1.Text = dagent.Tables[0].Rows[0]["PurchaseRtnDate"].ToString();

                        ddlsuplier.SelectedValue = dagent.Tables[0].Rows[0]["Supplier"].ToString();
                        ddlsuplier_OnSelectedIndexChanged(sender, e);
                        ddlpaymode.SelectedValue = dagent.Tables[0].Rows[0]["Paymode"].ToString();

                        if (dagent.Tables[0].Rows[0]["Paymode"].ToString() == "4" || dagent.Tables[0].Rows[0]["Paymode"].ToString() == "11" || dagent.Tables[0].Rows[0]["Paymode"].ToString() == "15" || dagent.Tables[0].Rows[0]["Paymode"].ToString() == "19")
                        {
                            ddlbank.Enabled = true;
                            txtcheque.Enabled = true;
                            ddlbank.Visible = true;
                            txtcheque.Visible = true;
                            lblbank.Visible = true;
                            lblChq.Visible = true;
                        }
                        else
                        {
                            ddlbank.Enabled = false;
                            txtcheque.Enabled = false;

                            ddlbank.Visible = false;
                            txtcheque.Visible = false;

                            lblbank.Visible = false;
                            lblChq.Visible = false;
                        }

                       

                        if (dagent.Tables[0].Rows[0]["BillingType"].ToString() == "Direct")
                        {
                            rbtype.SelectedValue = "1";
                            Div2.Visible = false;
                            Div4.Visible = false;
                            ddlsuplier.Enabled = false;
                            drpmingredents.Enabled = true;
                            btnSubmit.Enabled = true;
                            rbtype.Enabled = true;
                        }
                        else
                        {
                            
                            rbtype.SelectedValue = "2";
                            rbtype.Enabled = true;
                            Div2.Visible = true;
                            Div4.Visible = true;
                            ddlsuplier.Enabled = false;

                            DataSet dsPOup = kbs.PurchaseInvoiceNoList_update(sTableName);
                            if (dsPOup.Tables[0].Rows.Count > 0)
                            {
                                drpPO.DataSource = dsPOup.Tables[0];
                                drpPO.DataTextField = "DCNO";
                                drpPO.DataValueField = "PurchaseID";
                                drpPO.DataBind();
                                drpPO.Items.Insert(0, "Select Purchase InvoiceNo");


                            }

                            drpPO.SelectedValue = dagent.Tables[0].Rows[0]["PurInvNo"].ToString();
                            drpPO.Enabled = false;
                            drpmingredents.Enabled = false;
                            btnSubmit.Enabled = false;

                        }

                        int PONo1;
                        if (rbtype.SelectedValue == "1")
                        {
                            //BillingType = "Direct";
                            PONo1 = 0;
                        }
                        else
                        {
                           // BillingType = "Purchase";
                            PONo1 = Convert.ToInt32(drpPO.SelectedValue);
                        }

                        txtSubTotal.Text = dagent.Tables[0].Rows[0]["SubTotal"].ToString();
                        txttotal.Text = dagent.Tables[0].Rows[0]["Total"].ToString();
                        txtcgst.Text = dagent.Tables[0].Rows[0]["CGST"].ToString();
                        txtsgst.Text = dagent.Tables[0].Rows[0]["SGST"].ToString();
                        txtigst.Text = dagent.Tables[0].Rows[0]["IGST"].ToString();
                        txtroundoff.Text = dagent.Tables[0].Rows[0]["Roundoff"].ToString();
                        // txtDiscountAmount.Text = dagent.Tables[0].Rows[0]["DiscountAmount"].ToString();


                        ddlbank.SelectedValue = dagent.Tables[0].Rows[0]["Bank"].ToString();
                        txtcheque.Text = dagent.Tables[0].Rows[0]["ChequeNo"].ToString();
                        Button1.Text = "update";

                        DataSet transpur = kbs.getduplisttransrtn(iSalesID, sTableName);


                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;
                        DataSet dstd = new DataSet();
                        dttt = new DataTable();

                        dct = new DataColumn("sno");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Ingredient");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("IngredientID");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Qty");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Rate");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Amount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Units");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Unitsid");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("BillNo");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Supplier");
                        dttt.Columns.Add(dct);
                        dct = new DataColumn("Paymode");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("ExpDate");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("DisCount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("DisCountAmnt");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("PUnits");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("PUnitsvalue");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Pvalue");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("PQty");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Bname");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Hsncode");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Narrations");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("PoQty");
                        dttt.Columns.Add(dct);

                        dstd.Tables.Add(dttt);

                        foreach (DataRow dr in transpur.Tables[0].Rows)
                        {

                            drNew = dttt.NewRow();
                            drNew["sno"] = 0;
                            DataSet dsCategory = kbs.GetSupplierIngredient_PId("1", dr["IngredientID"].ToString());

                            if (dsCategory.Tables[0].Rows.Count > 0)
                            {
                                drNew["Ingredient"] = dsCategory.Tables[0].Rows[0]["IngredientName"].ToString();// itemname;                               
                            }
                            drNew["IngredientID"] = dr["IngredientID"];
                            drNew["Qty"] = dr["Qty"];
                            drNew["Rate"] = dr["Rate"];
                            drNew["Amount"] = dr["Amount"];
                            drNew["Units"] = dr["Units"];
                            drNew["BillNo"] = dr["Tax"];
                            drNew["Supplier"] = 0;
                            drNew["Paymode"] = 0;
                            drNew["ExpDate"] = Convert.ToDateTime(dr["ExpiryDate"]).ToString("dd/MM/yyyy");

                            drNew["DisCount"] = dr["Disc"];
                            drNew["DisCountAmnt"] = dr["DiscountAmnt"];

                            DataSet dspunits = kbs.GetPrimaryUOMName(Convert.ToInt32(dr["Punitsid"]));
                            if (dspunits.Tables[0].Rows.Count > 0)
                            {
                                drNew["PUnits"] = dspunits.Tables[0].Rows[0]["primaryname"].ToString();
                            }
                            drNew["PUnitsvalue"] = dr["PUnitsid"];
                            drNew["Pvalue"] = dr["Pvalue"];
                            drNew["PQty"] = dr["Qty"];
                            drNew["PoQty"] = 0;

                            drNew["Narrations"] = dr["Narrations"];

                            DataSet dss = kbs.getingreUnits(dr["IngredientID"].ToString(), ddlsuplier.SelectedValue, "1");
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                // Label lblunits = (Label)row.FindControl("lblunits");
                                drNew["Units"] = dss.Tables[0].Rows[0]["UOM"].ToString();
                                drNew["Unitsid"] = dss.Tables[0].Rows[0]["UOMid"].ToString();
                                //  TextBox txtBillNo = (TextBox)row.FindControl("txtBillNo");
                                // txtmBillNo.Text = dss.Tables[0].Rows[0]["TaxValue"].ToString();

                                drNew["Bname"] = dss.Tables[0].Rows[0]["BIngredientName"].ToString();

                                drNew["Hsncode"] = dss.Tables[0].Rows[0]["HsnCode"].ToString();

                            }
                            dstd.Tables[0].Rows.Add(drNew);
                        }
                        ViewState["CurrentTable"] = dttt;

                        gvcustomerorder.DataSource = dstd;
                        gvcustomerorder.DataBind();

                        for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
                        {
                            TextBox txtsno = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsno");
                            // DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");
                            Label txtdefname = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtdefname");
                            Label txtdefid = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtdefid");
                            TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtbillingname");
                            Label lblDescriptionID = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblDescriptionID");
                            Label lblunits = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunits");

                            TextBox txtQty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtQty");
                            TextBox txtRate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtRate");
                            TextBox txtAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtAmount");
                            // DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlunits");
                            // Label lblunits = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunits");
                            Label lblunitsid = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunitsid");
                            TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtBillNo");
                            TextBox txtsupplier = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsupplier");
                            DropDownList ddlPay = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlPay");
                            TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtexpireddate");
                            TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCount");
                            TextBox txthsncode = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txthsncode");
                            TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCountAmount");
                            TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtnarrations");

                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryvalue");
                            Label lblprimarynamevalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimarynamevalue");
                            Label lblprimaryname = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryname");
                            Label lblpoqty = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblpoqty");


                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtpqty");


                            txtsno.Text = (vLoop + 1).ToString();
                            txtdefname.Text = dstd.Tables[0].Rows[vLoop]["Ingredient"].ToString();
                            // ddlDef.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                            txtdefid.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                            lblDescriptionID.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                            txtbillingname.Text = dstd.Tables[0].Rows[vLoop]["BName"].ToString();
                            lblunits.Text = dstd.Tables[0].Rows[vLoop]["Units"].ToString();
                            lblunitsid.Text = dstd.Tables[0].Rows[vLoop]["Unitsid"].ToString();
                            txthsncode.Text = dstd.Tables[0].Rows[vLoop]["Hsncode"].ToString();
                            txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                            txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString();
                            txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString();
                            //ddlunits.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Units"]).ToString();
                            //lblunits.Text = ddlunits.SelectedItem.Text;

                            lblunits.Text = dstd.Tables[0].Rows[vLoop]["Units"].ToString();
                            lblunitsid.Text = dstd.Tables[0].Rows[vLoop]["Unitsid"].ToString();
                            //////  txtBillNo.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString();

                            txtBillNo.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString("f2");
                            txtsupplier.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Supplier"]).ToString();
                            ddlPay.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Paymode"]).ToString();
                            //txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");
                            txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");
                            if (txtexpireddate.Text == "01/01/1900")
                            {
                                txtexpireddate.Text = "";
                            }
                            txtDisCount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCount"]).ToString();
                            txtDisCountAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCountAmnt"]).ToString();
                            // ddlprimaryunits.SelectedValue = dstd.Tables[0].Rows[vLoop]["PUnits"].ToString();
                            lblprimaryvalue.Text = dstd.Tables[0].Rows[vLoop]["Pvalue"].ToString();
                            lblprimaryname.Text = dstd.Tables[0].Rows[vLoop]["PUnits"].ToString();
                            lblprimarynamevalue.Text = dstd.Tables[0].Rows[vLoop]["PUnitsvalue"].ToString();
                            txtpqty.Text = dstd.Tables[0].Rows[vLoop]["PQty"].ToString();
                            txtnarrations.Text = dstd.Tables[0].Rows[vLoop]["Narrations"].ToString();

                            if (PONo1 != 0)
                            {

                                DataSet transpurupd = kbs.getPurchaseInvoicetranslist_update(PONo1.ToString(), sTableName, txtdefid.Text, lblprimarynamevalue.Text);
                                if (transpurupd.Tables[0].Rows.Count > 0)
                                {
                                    lblpoqty.Text = transpurupd.Tables[0].Rows[0]["poqty"].ToString();

                                    if (lblpoqty.Text == "0")
                                    {
                                        lblpoqty.Text = txtQty.Text;
                                    }
                                }
                            }



                        }
                    }

                    #endregion
                }

            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$(document).ready(function() { $('#ddlsuplier').select2(); });", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$(document).ready(function() { $('#drpmingredents').select2(); });", true);
        }

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("sno", typeof(string)));
            dt.Columns.Add(new DataColumn("Ingredient", typeof(string)));
            dt.Columns.Add(new DataColumn("IngredientID", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Units", typeof(string)));
            dt.Columns.Add(new DataColumn("Unitsid", typeof(string)));
            dt.Columns.Add(new DataColumn("BillNo", typeof(string)));
            dt.Columns.Add(new DataColumn("Supplier", typeof(string)));
            dt.Columns.Add(new DataColumn("Paymode", typeof(string)));
            dt.Columns.Add(new DataColumn("ExpDate", typeof(string)));

            dt.Columns.Add(new DataColumn("PoQty", typeof(string)));
            dt.Columns.Add(new DataColumn("Narrations", typeof(string)));
            dt.Columns.Add(new DataColumn("DisCount", typeof(string)));
            dt.Columns.Add(new DataColumn("DisCountAmnt", typeof(string)));

            dt.Columns.Add(new DataColumn("Bname", typeof(string)));
            dt.Columns.Add(new DataColumn("Hsncode", typeof(string)));


            dt.Columns.Add(new DataColumn("PUnits", typeof(string)));
            dt.Columns.Add(new DataColumn("Pvalue", typeof(string)));
            dt.Columns.Add(new DataColumn("PUnitsvalue", typeof(string)));
            dt.Columns.Add(new DataColumn("PQty", typeof(string)));

            dr = dt.NewRow();
            dr["sno"] = 1;
            dr["Ingredient"] = string.Empty;
            dr["IngredientID"] = string.Empty;

            dr["Qty"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["Amount"] = string.Empty;
            dr["Units"] = string.Empty;
            dr["Unitsid"] = string.Empty;
            dr["BillNo"] = string.Empty;
            dr["Supplier"] = string.Empty;
            dr["Paymode"] = string.Empty;
            dr["ExpDate"] = string.Empty;

            dr["PoQty"] = string.Empty;
            dr["Narrations"] = string.Empty;
            dr["DisCount"] = string.Empty;
            dr["DisCountAmnt"] = string.Empty;

            dr["Bname"] = string.Empty;
            dr["Hsncode"] = string.Empty;


            dr["PUnits"] = string.Empty;
            dr["Pvalue"] = string.Empty;
            dr["PQty"] = string.Empty;
            dr["PUnitsvalue"] = string.Empty;
            dt.Rows.Add(dr);



            ViewState["CurrentTable"] = dt;
            gvcustomerorder.DataSource = dt;
            gvcustomerorder.DataBind();

        }
        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList ddlIngregients = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlDef");
                        TextBox txtsno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtsno");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");
                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlunits");
                        TextBox billno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtBillNo");
                        TextBox txtSupliername = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtsupplier");
                        DropDownList suppliet = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("ddSupplier");
                        DropDownList paymode = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[9].FindControl("ddlPay");
                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblDescriptionID");
                        Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtexpireddate");

                        Label lblpoqty = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblpoqty");
                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtnarrations");


                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;


                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;

                        dtCurrentTable.Rows[i - 1]["PoQty"] = lblpoqty.Text;
                        dtCurrentTable.Rows[i - 1]["Narrations"] = txtnarrations.Text;

                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;

                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;
                        //////if (suppliet.SelectedItem.Text == "New Supplier")
                        //////{


                        //////    int custid = kbs.insertSupplier(txtSupliername.Text);
                        //////    DataSet dsCustomer = kbs.SupplierList();
                        //////    if (dsCustomer.Tables[0].Rows.Count > 0)
                        //////    {
                        //////        suppliet.DataSource = dsCustomer.Tables[0];
                        //////        suppliet.DataTextField = "CustomerName";
                        //////        suppliet.DataValueField = "CustomerID";
                        //////        suppliet.DataBind();
                        //////        suppliet.Items.Insert(0, "Select Supplier");
                        //////        // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();

                        //////    }
                        //////    suppliet.SelectedValue = custid.ToString();

                        //////}
                        dtCurrentTable.Rows[i - 1]["Supplier"] = suppliet.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Paymode"] = paymode.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["ExpDate"] = txtexpireddate.Text;
                        rowIndex++;
                        txtsno.Focus();
                        ddlIngregients.Enabled = true;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvcustomerorder.DataSource = dtCurrentTable;
                    gvcustomerorder.DataBind();

                    //TextBox txn = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtName");
                    //txn.Focus();
                    //// txn.Focus;
                }



            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //DropDownList ddlIngregients = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlDef");
                        Label txtdefid = (Label)gvcustomerorder.Rows[i].FindControl("txtdefid");
                        Label txtdefname = (Label)gvcustomerorder.Rows[i].FindControl("txtdefname");
                        TextBox txtsno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtsno");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");
                        //DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlunits");
                        Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");
                        Label lblunitsid = (Label)gvcustomerorder.Rows[i].FindControl("lblunitsid");

                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblDescriptionID");
                        //  Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");
                        TextBox billno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtBillNo");
                        DropDownList suppliet = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("ddSupplier");
                        DropDownList paymode = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[9].FindControl("ddlPay");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtexpireddate");

                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtnarrations");
                        Label lblpoqty = (Label)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("lblpoqty");
                        // drCurrentRow["RowNumber"] = i + 1;
                        txtsno.Text = Convert.ToString(i + 1);
                        //gvcustomerorder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                        if (dt.Rows[i]["Qty"].ToString() != "")
                        {

                            //ddlIngregients.SelectedItem.Text = dt.Rows[i]["Ingredient"].ToString();
                            txtQty.Text = dt.Rows[i]["Qty"].ToString();
                            txtRate.Text = dt.Rows[i]["Rate"].ToString();
                            txtAmount.Text = dt.Rows[i]["Amount"].ToString();
                            lblunits.Text = dt.Rows[i]["Units"].ToString();
                            lblunitsid.Text = dt.Rows[i]["Unitsid"].ToString();
                            txtdefname.Text = dt.Rows[i]["Ingredient"].ToString();
                            txtdefid.Text = dt.Rows[i]["IngredientID"].ToString();
                            billno.Text = dt.Rows[i]["BillNo"].ToString();
                            suppliet.SelectedValue = dt.Rows[i]["Supplier"].ToString();
                            paymode.SelectedItem.Text = dt.Rows[i]["Paymode"].ToString();
                            txtexpireddate.Text = dt.Rows[i]["ExpDate"].ToString();

                            txtnarrations.Text = dt.Rows[i]["Narrations"].ToString();
                            lblpoqty.Text = dt.Rows[i]["PoQty"].ToString();

                            rowIndex++;
                        }
                        //ddlIngregients.Focus();
                        //ddlIngregients.Enabled = true;
                    }
                }
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {

        }
        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gvcustomerorder.DataSource = dt;
                    gvcustomerorder.DataBind();

                    for (int i = 0; i < gvcustomerorder.Rows.Count - 1; i++)
                    {
                        TextBox txtno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                        txtno.Text = Convert.ToString(i + 1);
                    }
                    SetPreviousData();
                }
                else
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    gvcustomerorder.DataSource = dt;
                    gvcustomerorder.DataBind();


                   // FirstGridViewRow();
                    SetPreviousData();
                }
            }


            #region

            decimal samt = 0;
            decimal dAmt = 0; decimal dTotal = 0;

            decimal ttltax = 0;
            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                decimal tax1 = 0;

                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");

                txtsno.Text = (i + 1).ToString();

                TextBox tAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                if (tAmount.Text != "")
                {
                    dAmt += Convert.ToDecimal(tAmount.Text);
                }

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");

                if (txtQty.Text == "")
                {
                    return;
                }
                if (txtRate.Text == "")
                {
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    return;
                }


                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                samt += Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                tax1 = ((dAmount1 * Convert.ToDecimal(txtBillNo.Text)) / 100);

                ttltax = ttltax + tax1;

            }
            dTotal = dAmt;
            txtSubTotal.Text = samt.ToString("f2");
            txttotal.Text = dTotal.ToString("f2");
            // txtTax.Text = ttltax.ToString("f2");
            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            #endregion

        }
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        // DropDownList ddlIngregients = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlDef");
                        Label txtdefname = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("txtdefname");
                        Label txtdefid = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("txtdefid");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");
                        //DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlunits");
                        Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");
                        Label lblunitsid = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunitsid");

                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblDescriptionID");

                        // Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");

                        TextBox billno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtBillNo");
                        DropDownList suppliet = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("ddSupplier");
                        DropDownList paymode = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[9].FindControl("ddlPay");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtexpireddate");



                        Label lblpoqty = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblpoqty");
                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtnarrations");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;



                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;

                        dtCurrentTable.Rows[i - 1]["PoQty"] = lblpoqty.Text;
                        dtCurrentTable.Rows[i - 1]["Narrations"] = txtnarrations.Text;


                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["IngredientID"] = txtdefid.Text;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;
                        dtCurrentTable.Rows[i - 1]["Supplier"] = suppliet.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Paymode"] = paymode.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["ExpDate"] = txtexpireddate.Text;
                        rowIndex++;
                        //ddlIngregients.Focus();
                        //ddlIngregients.Enabled = true;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                    //grvStudentDetails.DataSource = dtCurrentTable;
                    //grvStudentDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {

            //if (rbtype.SelectedValue=="2")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Can not Adding New Row');", true);
            //    return;
            //}

            #region
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
            {
                DropDownList txti = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");


                itemc = txti.Text;


                if ((itemc == null) || (itemc == ""))
                {
                }
                else
                {
                    for (int vLoop1 = 0; vLoop1 < gvcustomerorder.Rows.Count; vLoop1++)
                    {
                        DropDownList txt1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlDef");
                        if (txt1.Text == "")
                        {
                        }
                        else
                        {

                            if (ii == iq)
                            {
                            }
                            else
                            {
                                if (itemc == txt1.Text)
                                {
                                    itemcd = txti.SelectedItem.Text;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);

                                    txt1.Focus();

                                    return;

                                }
                            }
                            ii = ii + 1;
                        }
                    }
                }
                iq = iq + 1;
                ii = 1;

                txti.Focus();
            }


            #endregion

            LinkButton txt = (LinkButton)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            TextBox billno = (TextBox)row.FindControl("txtBillno");
            DropDownList supplier = (DropDownList)row.FindControl("ddSupplier");
            if (billno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter BillNo');", true);
            }
            else
            {
                AddNewRow();
            }
        }

        protected void rbtype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtype.SelectedValue == "1")
            {
                Div2.Visible = false;
                Div4.Visible = false;
                ddlsuplier.Enabled = true;
                drpmingredents.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                Div2.Visible = true;
                Div4.Visible = true;
                ddlsuplier.Enabled = true;
                drpmingredents.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }


        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (hdRowIndex.Value != "")
            {
                #region
                //{
                //    DataTable dt = (DataTable)ViewState["CurrentTable"];
                //    DataRow drCurrentRow = null;
                //    int rowIndex = Convert.ToInt32(hdRowIndex.Value);
                //    if (dt.Rows.Count > 1)
                //    {
                //        dt.Rows.Remove(dt.Rows[rowIndex]);
                //        drCurrentRow = dt.NewRow();
                //        ViewState["CurrentTable1"] = dt;
                //        gvcustomerorder.DataSource = dt;
                //        gvcustomerorder.DataBind();
                //    }
                //}
            }

            #region


            if (Convert.ToDouble(txtmpqty.Text) > Convert.ToDouble(txtavlqty.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Return Qty is greater Than Avl Qty For this Item " + drpmingredents.SelectedItem.Text + "');", true);
                return;
            }


            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
            {
                //  DropDownList txti = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");

                //  DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");

                Label txtdefname = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtdefname");
                Label txtdefid = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtdefid");

                Label lblprimaryname = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryname");
                Label lblprimarynamevalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimarynamevalue");


                string itemname = txtdefname.Text;
                itemc = txtdefid.Text;
                itemcd = lblprimaryname.Text;


                if ((itemc == null) || (itemc == "") && (itemcd == null) || (itemcd == ""))
                {
                }
                else
                {
                    //for (int vLoop1 = 0; vLoop1 < gvcustomerorder.Rows.Count; vLoop1++)
                    {
                        //DropDownList txt1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlDef");

                        //drpmingredents

                        //DropDownList ddlprimaryunits1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlprimaryunits");
                        if (drpmingredents.SelectedValue == "")
                        {
                        }
                        else if (ddlmprimaryunits.SelectedValue == "")
                        {
                        }
                        else
                        {

                            if (ii == iq)
                            {
                            }
                            else
                            {
                                if (itemc == drpmingredents.SelectedValue && itemcd == ddlmprimaryunits.SelectedItem.Text)
                                {
                                    itemcd = itemname;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);
                                    drpmingredents.Focus();
                                    return;

                                }
                            }
                            ii = ii + 1;
                        }
                    }
                }
                iq = iq + 1;
                ii = 1;

                drpmingredents.Focus();
            }

            #region Validation

            if (drpmingredents.SelectedValue == "Select IngredientName")
            {

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Ingredients Name.Thank You!!!.');", true);
                drpmingredents.Focus();
                return;
            }

            if (ddlmprimaryunits.SelectedValue == "Select PrimaryUom")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Primary Uom.Thank You!!!.');", true);
                ddlmprimaryunits.Focus();
                return;
            }

            if (txtmQty.Text == "0" || txtmQty.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter  Valid Qty.Thank You!!!.');", true);
                txtmQty.Focus();
                return;
            }

            if (txtmRate.Text == "0" || txtmRate.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Rate.Thank You!!!.');", true);
                txtmRate.Focus();
                return;
            }

            if (txtmAmount.Text == "0" || txtmAmount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Rate.Thank You!!!.');", true);
                txtmAmount.Focus();
                return;
            }

            if (txtmDisCount.Text == "")
                txtmDisCount.Text = "0";
            if (txtmDisCountAmount.Text == "")
                txtmDisCountAmount.Text = "0";
            if (txtmBillNo.Text == "")
                txtmBillNo.Text = "0";

            #endregion

            #endregion

            DataTable dttt;
            DataRow drNew;
            DataColumn dct;
            DataTable dtddd = new DataTable();
            DataSet dstd = new DataSet();
            dttt = new DataTable();

            dct = new DataColumn("sno");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Ingredient");
            dttt.Columns.Add(dct);

            dct = new DataColumn("IngredientID");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Rate");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Amount");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Units");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Unitsid");
            dttt.Columns.Add(dct);

            dct = new DataColumn("BillNo");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Supplier");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Paymode");
            dttt.Columns.Add(dct);

            dct = new DataColumn("ExpDate");
            dttt.Columns.Add(dct);

            dct = new DataColumn("DisCount");
            dttt.Columns.Add(dct);

            dct = new DataColumn("DisCountAmnt");
            dttt.Columns.Add(dct);

            dct = new DataColumn("PUnits");
            dttt.Columns.Add(dct);

            dct = new DataColumn("PUnitsvalue");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Pvalue");
            dttt.Columns.Add(dct);

            dct = new DataColumn("PQty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Bname");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Hsncode");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Narrations");
            dttt.Columns.Add(dct);

            dct = new DataColumn("PoQty");
            dttt.Columns.Add(dct);



            dstd.Tables.Add(dttt);

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];

                drNew = dttt.NewRow();

                drNew["sno"] = 0;
                drNew["Ingredient"] = drpmingredents.SelectedItem.Text;
                drNew["IngredientID"] = drpmingredents.SelectedValue;
                drNew["Qty"] = txtmQty.Text;
                drNew["Rate"] = txtmRate.Text;
                drNew["Amount"] = txtmAmount.Text;
                drNew["Units"] = lblmunits.Text;
                drNew["Unitsid"] = lblmunitsid.Text;
                drNew["BillNo"] = txtmBillNo.Text;
                drNew["Supplier"] = 0;
                drNew["Paymode"] = 0;
                if (txtmexpireddate.Text == "" || txtmexpireddate.Text == "0")
                {
                    drNew["ExpDate"] = "";
                }
                else
                {
                    drNew["ExpDate"] = Convert.ToDateTime(txtmexpireddate.Text).ToString("dd/MM/yyyy");
                }
                drNew["DisCount"] = txtmDisCount.Text;
                drNew["DisCountAmnt"] = txtmDisCountAmount.Text;

                drNew["PUnits"] = ddlmprimaryunits.SelectedItem.Text;
                drNew["PUnitsvalue"] = ddlmprimaryunits.SelectedValue;
                drNew["Pvalue"] = lblmprimaryvalue.Text;
                drNew["PQty"] = txtmpqty.Text;
                drNew["PoQty"] = 0;


                drNew["Bname"] = txtmbillingname.Text;
                drNew["Hsncode"] = txtmhsncode.Text;
                drNew["Narrations"] = txtmnarrations.Text;


                dstd.Tables[0].Rows.Add(drNew);
                dtddd = dstd.Tables[0];
                dtddd.Merge(dt);

            }
            else
            {

                drNew = dttt.NewRow();
                drNew["sno"] = 0;
                drNew["Ingredient"] = drpmingredents.SelectedItem.Text;
                drNew["IngredientID"] = drpmingredents.SelectedValue;
                drNew["Qty"] = txtmQty.Text;
                drNew["Rate"] = txtmRate.Text;
                drNew["Amount"] = txtmAmount.Text;
                drNew["Units"] = lblmunits.Text;
                drNew["Unitsid"] = lblmunitsid.Text;
                drNew["BillNo"] = txtmBillNo.Text;
                drNew["Supplier"] = 0;
                drNew["Paymode"] = 0;
                if (txtmexpireddate.Text == "" || txtmexpireddate.Text == "0")
                {
                    drNew["ExpDate"] = "";
                }
                else
                {
                    drNew["ExpDate"] = Convert.ToDateTime(txtmexpireddate.Text).ToString("dd/MM/yyyy");
                }

                drNew["DisCount"] = txtmDisCount.Text;
                drNew["DisCountAmnt"] = txtmDisCountAmount.Text;

                drNew["PUnits"] = ddlmprimaryunits.SelectedItem.Text;
                drNew["PUnitsvalue"] = ddlmprimaryunits.SelectedValue;
                drNew["Pvalue"] = lblmprimaryvalue.Text;
                drNew["PQty"] = txtmpqty.Text;

                drNew["Bname"] = txtmbillingname.Text;
                drNew["Hsncode"] = txtmhsncode.Text;
                drNew["Narrations"] = txtmnarrations.Text;

                dstd.Tables[0].Rows.Add(drNew);
                dtddd = dstd.Tables[0];
            }

            #endregion

            ViewState["CurrentTable"] = dtddd;

            gvcustomerorder.DataSource = dtddd;
            gvcustomerorder.DataBind();

            totcalculate();
        }

        public void totcalculate()
        {
            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                txtsno.Text = (i + 1).ToString();

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");

                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtRate.Text == "")
                    txtRate.Text = "0";
                if (txtBillNo.Text == "")
                    txtBillNo.Text = "0";
                if (txtDisCount.Text == "")
                    txtDisCount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                decimal disc1 = (dAmount1 * Convert.ToDecimal(txtDisCount.Text)) / 100;

                decimal tax1 = (((dAmount1 - disc1) * Convert.ToDecimal(txtBillNo.Text)) / 100);

                samt += (dAmount1 - disc1);
                sdisc += disc1;
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge


            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (rbtype.SelectedValue == "2")
            {

                if (txtdcno.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Bill No.Thank You!!!.');", true);
                    return;
                }
            }
            else
            {
                txtdcno.Text = "0";
            }

            if (ddlsuplier.SelectedValue == "Select Supplier")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Supplier');", true);
                return;
            }
            if (ddlpaymode.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Payment');", true);
                return;
            }

            SetRowData();
            DataTable table = ViewState["CurrentTable"] as DataTable;

            if (rbtype.SelectedValue == "2")
            {
                for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                {
                    TextBox rQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                    Label lblpoqty = (Label)gvcustomerorder.Rows[i].FindControl("lblpoqty");
                    Label txtdefname = (Label)gvcustomerorder.Rows[i].FindControl("txtdefname");




                    if (Convert.ToDouble(rQty.Text) > Convert.ToDouble(lblpoqty.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Return Qty is greater Than Purchase Qty For this Item " + txtdefname.Text + "');", true);
                        return;
                    }
                }
            }

            

            if (table != null)
            {
                int bank = 0;
                string chequeno = "";
                if (Button1.Text == "Save")
                {
                    #region

                    if (ddlpaymode.SelectedValue == "1" || ddlpaymode.SelectedValue == "2" || ddlpaymode.SelectedValue == "18")
                    {
                        bank = 0;
                        chequeno = "000000";
                    }
                    else
                    {
                        if (ddlbank.SelectedValue == "Select Bank")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Bank');", true);
                            return;
                        }

                        if (txtcheque.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Enter ChequeNo');", true);
                            return;
                        }

                        bank = Convert.ToInt32(ddlbank.SelectedValue);
                        chequeno = txtcheque.Text;
                    }

                    int CreditorID1 = 0;
                    if (ddlpaymode.SelectedValue == "2") //Credit
                    {
                        CreditorID1 = Convert.ToInt32(ddlsuplier.SelectedValue);
                    }
                    if (ddlpaymode.SelectedValue == "1") //Cash
                    {
                        DataSet dsledger = kbs.getCashledgerId123("Cash A/C _" + sTableName);
                        if (dsledger.Tables[0].Rows.Count > 0)
                        {
                            CreditorID1 = Convert.ToInt32(dsledger.Tables[0].Rows[0]["LedgerID"].ToString());
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Cash A/C Does not Exists in Table');", true);
                            return;
                        }
                    }

                    if (ddlpaymode.SelectedValue == "3") //cheque
                    {
                        CreditorID1 = Convert.ToInt32(ddlbank.SelectedValue);
                    }

                    string ledgerid = "";
                    DataSet dsledger1 = kbs.getCashledgerId123("PurchaseReturnA/C_" + sTableName);
                    if (dsledger1.Tables[0].Rows.Count > 0)
                    {
                        ledgerid = dsledger1.Tables[0].Rows[0]["LedgerID"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('PurchaseReturnA/C Does not Exists in Table');", true);
                        return;
                    }
                    string BillingType;
                    int PONo;
                    if (rbtype.SelectedValue == "1")
                    {
                        BillingType = "Direct";
                        PONo = 0;
                    }
                    else
                    {
                        BillingType = "Purchase";
                        PONo = Convert.ToInt32(drpPO.SelectedValue);
                    }

                    string Province;
                    if (rbdpurchasetype.SelectedValue == "1")
                    {
                        Province = "Inner";
                    }
                    else
                    {
                        Province = "Outer";
                    }

                    int insertPurchase = kbs.insertPurchaseReturn(sTableName, Convert.ToInt32(ledgerid), Convert.ToInt32(CreditorID1), txtbillno.Text, txtsdate1.Text, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), bank, chequeno, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), BillingType, PONo, Province, txtroundoff.Text, drpsubcompany.SelectedValue,lblbillername.Text,lblbillerid.Text);


                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox rQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                        if (Convert.ToInt32(rQty.Text) > 0)
                        {
                            Label txtdefid = (Label)gvcustomerorder.Rows[i].FindControl("txtdefid");
                            Label txtdefname = (Label)gvcustomerorder.Rows[i].FindControl("txtdefname");
                            //DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                            string ingre = txtdefname.Text;
                            int idef = Convert.ToInt32(txtdefid.Text);

                            TextBox Qty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            decimal dQty = Convert.ToDecimal(Qty.Text);

                            TextBox Rate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                            decimal DRate = Convert.ToDecimal(Rate.Text);
                            // DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlunits");
                            Label lblunitsid = (Label)gvcustomerorder.Rows[i].FindControl("lblunitsid");
                            TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                            decimal dAmount = Convert.ToDecimal(Amount.Text);

                            TextBox billno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");

                            DropDownList supplier = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddSupplier");

                            DropDownList paymode = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlPay");

                            TextBox txtSupliername = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsupplier");

                            TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtexpireddate");


                            TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[i].FindControl("txtnarrations");

                            TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");
                            if (txtDisCount.Text == "")
                                txtDisCount.Text = "0";

                            TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCountAmount");
                            if (txtDisCountAmount.Text == "")
                                txtDisCountAmount.Text = "0";

                            //DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlprimaryunits");
                            Label lblprimarynamevalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimarynamevalue");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");

                            if (txtdefid.Text == "0")
                            {

                            }
                            else
                            {
                                int Transpurchase = kbs.insertTransPurchaseReturn(sTableName, insertPurchase, idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), lblunitsid.Text, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, txtnarrations.Text, Convert.ToDouble(txtDisCount.Text), Convert.ToDouble(txtDisCountAmount.Text), lblprimarynamevalue.Text, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text), PONo);
                                //int Transpurchase = kbs.insertTransPurchase(sTableName, insertPurchase, idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, txtnarrations.Text, Convert.ToDouble(txtDisCount.Text), Convert.ToDouble(txtDisCountAmount.Text), lblprimarynamevalue.Text, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text));

                                if (BillingType == "Purchase")
                                {
                                    int iSucess = kbs.UpdatePurchaseInvoiceSTk(PONo, sTableName, dQty, idef, Convert.ToDecimal(txtpqty.Text));
                                }
                            }
                        }
                    }

                    if (BillingType == "Purchase")
                    {
                        int iSucess1 = kbs.UpdatePurchaseInvoiceSTkStatus(PONo, sTableName);
                    }

                    #endregion

                    Response.Redirect("Purchase_ReturnGrid.aspx");
                }
                else
                {
                    if (txteditnarrations.Text == "" || txteditnarrations.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Edit Narrations.Thank You!!!.');", true);
                        return;
                    }


                    #region

                    string iSalesID = Request.QueryString.Get("LedgerID");


                    int CreditorID1 = 0;
                    if (ddlpaymode.SelectedValue == "2") //Credit
                    {
                        CreditorID1 = Convert.ToInt32(ddlsuplier.SelectedValue);
                    }
                    if (ddlpaymode.SelectedValue == "1") //Cash
                    {
                        DataSet dsledger = kbs.getCashledgerId123("Cash A/C _" + sTableName);
                        CreditorID1 = Convert.ToInt32(dsledger.Tables[0].Rows[0]["LedgerID"].ToString());
                    }

                    if (ddlpaymode.SelectedValue == "3") //cheque
                    {
                        // DataSet dsledger = kbs.getCashledgerId("Cash A/C _" + sTableName);
                        CreditorID1 = Convert.ToInt32(ddlbank.SelectedValue);
                    }

                    DataSet dsledger1 = kbs.getCashledgerId123("PurchaseReturnA/C_" + sTableName);
                    string ledgerid = dsledger1.Tables[0].Rows[0]["LedgerID"].ToString();

                    string Province;
                    if (rbdpurchasetype.SelectedValue == "1")
                    {
                        Province = "Inner";
                    }
                    else
                    {
                        Province = "Outer";
                    }

                    string BillingType;
                    int PONo;
                    if (rbtype.SelectedValue == "1")
                    {
                        BillingType = "Direct";
                        PONo = 0;
                    }
                    else
                    {
                        BillingType = "Purchase";
                        PONo = Convert.ToInt32(drpPO.SelectedValue);
                    }

                    int insertPurchase = kbs.updatePurchaseReturn(sTableName, Convert.ToInt32(ledgerid), Convert.ToInt32(CreditorID1), txtbillno.Text, txtsdate1.Text, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), bank, chequeno, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), BillingType, PONo, Province, txtroundoff.Text, iSalesID, drpsubcompany.SelectedValue);

                    //int insertPurchase = kbs.updatePurchase(sTableName, txtbillno.Text, txtsdate1.Text, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), iSalesID, bank, chequeno, CreditorID1, ledgerid, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), txteditnarrations.Text, Province, 0, 0, 0, 0, 0, 0);
                    int trans1 = kbs.getduplisttrans123Rtn(iSalesID, sTableName, PONo.ToString(), BillingType);

                    int transdelete = kbs.getduplisttransdeleteRtn(iSalesID, sTableName);

                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox rQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                        if (Convert.ToDouble(rQty.Text) > 0)
                        {
                            Label txtdefid = (Label)gvcustomerorder.Rows[i].FindControl("txtdefid");
                            Label txtdefname = (Label)gvcustomerorder.Rows[i].FindControl("txtdefname");
                            //DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                            string ingre = txtdefname.Text;
                            int idef = Convert.ToInt32(txtdefid.Text);

                            TextBox Qty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            decimal dQty = Convert.ToDecimal(Qty.Text);

                            TextBox Rate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                            decimal DRate = Convert.ToDecimal(Rate.Text);
                            // DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlunits");
                            Label lblunitsid = (Label)gvcustomerorder.Rows[i].FindControl("lblunitsid");
                            TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                            decimal dAmount = Convert.ToDecimal(Amount.Text);

                            TextBox billno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");

                            DropDownList supplier = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddSupplier");

                            DropDownList paymode = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlPay");

                            TextBox txtSupliername = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsupplier");

                            TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtexpireddate");


                            TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[i].FindControl("txtnarrations");

                            TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");
                            if (txtDisCount.Text == "")
                                txtDisCount.Text = "0";

                            TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCountAmount");
                            if (txtDisCountAmount.Text == "")
                                txtDisCountAmount.Text = "0";

                            //DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlprimaryunits");
                            Label lblprimarynamevalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimarynamevalue");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");

                            if (txtdefid.Text == "0")
                            {

                            }
                            else
                            {
                                int Transpurchase = kbs.insertTransPurchaseReturn(sTableName, Convert.ToInt32(iSalesID), idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), lblunitsid.Text, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, txtnarrations.Text, Convert.ToDouble(txtDisCount.Text), Convert.ToDouble(txtDisCountAmount.Text), lblprimarynamevalue.Text, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text), PONo);
                                //int Transpurchase = kbs.insertTransPurchase(sTableName, insertPurchase, idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, txtnarrations.Text, Convert.ToDouble(txtDisCount.Text), Convert.ToDouble(txtDisCountAmount.Text), lblprimarynamevalue.Text, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text));

                                if (BillingType == "Purchase")
                                {
                                    int iSucess = kbs.UpdatePurchaseInvoiceSTk(PONo, sTableName, dQty, idef, Convert.ToDecimal(txtpqty.Text));
                                }

                            }
                        }
                    }

                    if (BillingType == "Purchase")
                    {
                        int iSucess1 = kbs.UpdatePurchaseInvoiceSTkStatus(PONo, sTableName);
                    }

                    #endregion

                    Response.Redirect("Purchase_ReturnGrid.aspx");
                }
            }




        }

        protected void txtdefQty_TextChanged2(object sender, EventArgs e)
        {
            //  TextBox txt = (TextBox)sender;
            // GridViewRow row = (GridViewRow)txt.NamingContainer;

            string Qty = txtmQty.Text;
            string Rate = txtmRate.Text;
            string Amount = txtmAmount.Text;
            string txttax = txtmBillNo.Text;
            string DisCount = txtmDisCount.Text;

            string ddlprimaryunits = ddlmprimaryunits.SelectedValue;

            string lblprimaryvalue = lblmprimaryvalue.Text;
            string PQty = txtmpqty.Text;

            if (ddlprimaryunits == "Select PrimaryUom")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Primary Uom.');", true);
                return;
            }

            if (Qty == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Qty');", true);
                return;
            }
            if (Rate == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
                return;
            }


            if (Qty == "")
                txtmQty.Text = "0";
            if (Rate == "")
                txtmRate.Text = "0";
            if (Amount == "")
                txtmAmount.Text = "0";
            if (txttax == "")
                txtmBillNo.Text = "0";
            if (DisCount == "")
                txtmDisCount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;
            decimal Pqty = 0;

            lblError.Visible = false;
            //Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(txtmQty.Text);
            decimal DRate = Convert.ToDecimal(txtmRate.Text);
            decimal DDisCount = Convert.ToDecimal(txtmDisCount.Text);

            dAmount = dQty * DRate;

            Pqty = dQty * Convert.ToDecimal(lblmprimaryvalue.Text);
            Disc = (dAmount * DDisCount) / 100;

            tax = ((dAmount - Disc) * Convert.ToDecimal(txttax) / 100);

            decimal amt = (dAmount - Disc) + tax;

            txtmAmount.Text = amt.ToString("f2");
            txtmpqty.Text = Pqty.ToString("f2");

            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            //for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                //  TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                //txtsno.Text = (i + 1).ToString();

                //TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                //TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                //TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                //TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");

                if (txtmQty.Text == "")
                    txtmQty.Text = "0";
                if (txtmRate.Text == "")
                    txtmRate.Text = "0";
                if (txtmBillNo.Text == "")
                    txtmBillNo.Text = "0";
                if (txtmDisCount.Text == "")
                    txtmDisCount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtmQty.Text) * Convert.ToDecimal(txtmRate.Text);

                decimal disc1 = (dAmount1 * Convert.ToDecimal(txtmDisCount.Text)) / 100;

                decimal tax1 = (((dAmount1 - disc1) * Convert.ToDecimal(txtmBillNo.Text)) / 100);

                samt += (dAmount1 - disc1);
                sdisc += disc1;
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge



            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            txtmDisCount.Focus();
        }


        protected void txtdefQty_TextChanged(object sender, EventArgs e)
        {

            decimal samt = 0;

            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");


            #region
            if (Qty.Text == "")
            {
                return;
            }
            if (Rate.Text == "")
            {
                return;
            }
            if (Amount.Text == "")
            {
                return;
            }
            if (txttax.Text == "")
            {
                return;
            }

            #endregion
            decimal dAmount = 0;


            decimal tax = 0;

            lblError.Visible = false;
            Button1.Enabled = true;
            if (Qty.Text.Trim() != "")
            {
                decimal dQty = Convert.ToDecimal(Qty.Text);
                decimal DRate = Convert.ToDecimal(Rate.Text);
                dAmount = dQty * DRate;

                tax = ((dAmount * Convert.ToDecimal(txttax.Text)) / 100);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
            }

            decimal amttax = dAmount + tax;


            Amount.Text = amttax.ToString("f2");
            decimal dAmt = 0; decimal dTotal = 0;

            decimal ttltax = 0;
            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                decimal tax1 = 0;

                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");

                txtsno.Text = (i + 1).ToString();

                TextBox tAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                if (tAmount.Text != "")
                {
                    dAmt += Convert.ToDecimal(tAmount.Text);
                }

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");
                TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");
                if (lblprimaryvalue.Text == "") lblprimaryvalue.Text = "1";
                txtpqty.Text = Convert.ToDouble(Convert.ToDouble(lblprimaryvalue.Text) * Convert.ToDouble(txtQty.Text)).ToString();
                if (txtQty.Text == "")
                {
                    return;
                }
                if (txtRate.Text == "")
                {
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    return;
                }


                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                samt += Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                tax1 = ((dAmount1 * Convert.ToDecimal(txtBillNo.Text)) / 100);

                ttltax = ttltax + tax1;

            }
            dTotal = dAmt;
            txtSubTotal.Text = samt.ToString("f2");
            txttotal.Text = dTotal.ToString("f2");
            // txtTax.Text = ttltax.ToString("f2");
            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            LinkButton Button = (LinkButton)txt.FindControl("add");

            txttax.Focus();
        }

        protected void txtDisCount_TextChanged(object sender, EventArgs e)
        {
            // TextBox txt = (TextBox)sender;
            // GridViewRow row = (GridViewRow)txt.NamingContainer;

            //TextBox Qty = (TextBox)row.FindControl("txtQty");
            //TextBox Rate = (TextBox)row.FindControl("txtRate");
            //TextBox Amount = (TextBox)row.FindControl("txtAmount");
            //TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            //TextBox DisCount = (TextBox)row.FindControl("txtDisCount");
            //TextBox DisCountAmount = (TextBox)row.FindControl("txtDisCountAmount");

            if (txtmQty.Text == "")
                txtmQty.Text = "0";
            if (txtmRate.Text == "")
                txtmRate.Text = "0";
            if (txtmAmount.Text == "")
                txtmAmount.Text = "0";
            if (txtmBillNo.Text == "")
                txtmBillNo.Text = "0";
            if (txtmDisCount.Text == "")
                txtmDisCount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(txtmQty.Text);
            decimal DRate = Convert.ToDecimal(txtmRate.Text);
            decimal DDisCount = Convert.ToDecimal(txtmDisCount.Text);

            dAmount = dQty * DRate;

            Disc = (dAmount * DDisCount) / 100;

            txtmDisCountAmount.Text = Disc.ToString("0.00");

            tax = ((dAmount - Disc) * Convert.ToDecimal(txtmBillNo.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            txtmAmount.Text = amt.ToString("f2");

            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                txtsno.Text = (i + 1).ToString();

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");
                TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCountAmount");

                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtRate.Text == "")
                    txtRate.Text = "0";
                if (txtBillNo.Text == "")
                    txtBillNo.Text = "0";
                if (txtDisCount.Text == "")
                    txtDisCount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                decimal disc1 = (dAmount1 * Convert.ToDecimal(txtDisCount.Text)) / 100;

                txtDisCountAmount.Text = disc1.ToString("0.00");

                decimal tax1 = (((dAmount1 - disc1) * Convert.ToDecimal(txtBillNo.Text)) / 100);

                samt += (dAmount1 - disc1);
                sdisc += disc1;
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge


            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            txtmBillNo.Focus();
            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);
        }


        protected void txtDisCountAmount_TextChanged(object sender, EventArgs e)
        {
            // TextBox txt = (TextBox)sender;
            // GridViewRow row = (GridViewRow)txt.NamingContainer;

            // TextBox Qty = (TextBox)row.FindControl("txtQty");
            // TextBox Rate = (TextBox)row.FindControl("txtRate");
            // TextBox Amount = (TextBox)row.FindControl("txtAmount");
            //TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            //TextBox DisCount = (TextBox)row.FindControl("txtDisCount");
            //TextBox DisCountAmount = (TextBox)row.FindControl("txtDisCountAmount");

            if (txtmQty.Text == "")
                txtmQty.Text = "0";
            if (txtmRate.Text == "")
                txtmRate.Text = "0";
            if (txtmAmount.Text == "")
                txtmAmount.Text = "0";
            if (txtmBillNo.Text == "")
                txtmBillNo.Text = "0";
            if (txtmDisCount.Text == "")
                txtmDisCount.Text = "0";

            if (txtmDisCountAmount.Text == "")
                txtmDisCountAmount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;
            decimal DiscB = 0;
            decimal DiscAmnt = 0;

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(txtmQty.Text);
            decimal DRate = Convert.ToDecimal(txtmRate.Text);

            decimal DDisCountAmnt = Convert.ToDecimal(txtmDisCountAmount.Text);

            dAmount = dQty * DRate;

            DiscAmnt = dAmount - DDisCountAmnt;

            DiscB = ((DDisCountAmnt * 100) / dAmount);

            txtmDisCount.Text = DiscB.ToString("0.00");
            decimal DDisCount = Convert.ToDecimal(txtmDisCount.Text);

            //  Disc = (dAmount * DDisCount) / 100;

            //DisCountAmount.Text = Disc.ToString("0.00");

            tax = ((DiscAmnt) * Convert.ToDecimal(txtmBillNo.Text) / 100);

            decimal amt = (DiscAmnt) + tax;

            txtmAmount.Text = amt.ToString("f2");

            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                txtsno.Text = (i + 1).ToString();

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");
                TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCountAmount");

                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtRate.Text == "")
                    txtRate.Text = "0";
                if (txtBillNo.Text == "")
                    txtBillNo.Text = "0";
                if (txtDisCount.Text == "")
                    txtDisCount.Text = "0";

                if (txtDisCountAmount.Text == "")
                    txtDisCountAmount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                decimal Damount = dAmount1 - Convert.ToDecimal(txtDisCountAmount.Text);



                decimal disc1 = (Convert.ToDecimal(txtDisCountAmount.Text) * 100) / dAmount1;

                txtDisCount.Text = disc1.ToString("0.00");

                decimal tax1 = (((Damount) * Convert.ToDecimal(txtBillNo.Text)) / 100);

                samt += (Damount);
                sdisc += Convert.ToDecimal(txtDisCountAmount.Text);
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            txtmBillNo.Focus();
        }

        protected void txtBillNo_TextChanged1(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //GridViewRow row = (GridViewRow)txt.NamingContainer;

            //TextBox Qty = (TextBox)row.FindControl("txtQty");
            //TextBox Rate = (TextBox)row.FindControl("txtRate");
            //TextBox Amount = (TextBox)row.FindControl("txtAmount");
            //TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            //TextBox DisCount = (TextBox)row.FindControl("txtDisCount");

            if (txtmQty.Text == "")
                txtmQty.Text = "0";
            if (txtmRate.Text == "")
                txtmRate.Text = "0";
            if (txtmAmount.Text == "")
                txtmAmount.Text = "0";
            if (txtmBillNo.Text == "")
                txtmBillNo.Text = "0";
            if (txtmDisCount.Text == "")
                txtmDisCount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(txtmQty.Text);
            decimal DRate = Convert.ToDecimal(txtmRate.Text);
            decimal DDisCount = Convert.ToDecimal(txtmDisCount.Text);

            dAmount = dQty * DRate;

            Disc = (dAmount * DDisCount) / 100;

            tax = ((dAmount - Disc) * Convert.ToDecimal(txtmBillNo.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            txtmAmount.Text = amt.ToString("f2");

            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                txtsno.Text = (i + 1).ToString();

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");

                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtRate.Text == "")
                    txtRate.Text = "0";
                if (txtBillNo.Text == "")
                    txtBillNo.Text = "0";
                if (txtDisCount.Text == "")
                    txtDisCount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                decimal disc1 = (dAmount1 * Convert.ToDecimal(txtDisCount.Text)) / 100;

                decimal tax1 = (((dAmount1 - disc1) * Convert.ToDecimal(txtBillNo.Text)) / 100);

                samt += (dAmount1 - disc1);
                sdisc += disc1;
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge


            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            txtmRate.Focus();
        }


        protected void txtBillNo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");


            #region
            if (Qty.Text == "")
            {
                return;
            }
            if (Rate.Text == "")
            {
                return;
            }
            if (Amount.Text == "")
            {
                return;
            }
            if (txttax.Text == "")
            {
                return;
            }

            #endregion

            decimal dAmount = 0;
            decimal samt = 0;

            decimal tax = 0;

            lblError.Visible = false;
            Button1.Enabled = true;
            if (Qty.Text.Trim() != "")
            {
                decimal dQty = Convert.ToDecimal(Qty.Text);
                decimal DRate = Convert.ToDecimal(Rate.Text);
                dAmount = dQty * DRate;

                tax = ((dAmount * Convert.ToDecimal(txttax.Text)) / 100);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
            }

            decimal amttax = dAmount + tax;


            Amount.Text = amttax.ToString("f2");
            decimal dAmt = 0; decimal dTotal = 0;

            decimal ttltax = 0;
            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                decimal tax1 = 0;

                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");

                txtsno.Text = (i + 1).ToString();

                TextBox tAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                if (tAmount.Text != "")
                {
                    dAmt += Convert.ToDecimal(tAmount.Text);
                }

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");

                #region
                if (txtQty.Text == "")
                {
                    return;
                }
                if (txtRate.Text == "")
                {
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    return;
                }

                #endregion

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);
                samt += Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);
                tax1 = ((dAmount1 * Convert.ToDecimal(txtBillNo.Text)) / 100);

                ttltax = ttltax + tax1;

            }
            dTotal = dAmt;
            txtSubTotal.Text = samt.ToString("f2");
            txttotal.Text = dTotal.ToString("f2");
            //   txtTax.Text = ttltax.ToString("f2");
            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }
            LinkButton Button = (LinkButton)txt.FindControl("add");
            Rate.Focus();

        }

        protected void txtdefCatID_TextChanged1(object sender, EventArgs e)
        {
            //  TextBox txt = (TextBox)sender;
            // GridViewRow row = (GridViewRow)txt.NamingContainer;

            // TextBox Qty = (TextBox)row.FindControl("txtQty");
            // TextBox Rate = (TextBox)row.FindControl("txtRate");
            // TextBox Amount = (TextBox)row.FindControl("txtAmount");
            // TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            // TextBox DisCount = (TextBox)row.FindControl("txtDisCount");

            if (txtmQty.Text == "")
                txtmQty.Text = "0";
            if (txtmRate.Text == "")
                txtmRate.Text = "0";
            if (txtmAmount.Text == "")
                txtmAmount.Text = "0";
            if (txtmBillNo.Text == "")
                txtmBillNo.Text = "0";
            if (txtmDisCount.Text == "")
                txtmDisCount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(txtmQty.Text);
            decimal DRate = Convert.ToDecimal(txtmRate.Text);
            decimal DDisCount = Convert.ToDecimal(txtmDisCount.Text);

            dAmount = dQty * DRate;

            Disc = (dAmount * DDisCount) / 100;

            tax = ((dAmount - Disc) * Convert.ToDecimal(txtmBillNo.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            txtmAmount.Text = amt.ToString("f2");

            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                txtsno.Text = (i + 1).ToString();

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");

                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtRate.Text == "")
                    txtRate.Text = "0";
                if (txtBillNo.Text == "")
                    txtBillNo.Text = "0";
                if (txtDisCount.Text == "")
                    txtDisCount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                decimal disc1 = (dAmount1 * Convert.ToDecimal(txtDisCount.Text)) / 100;

                decimal tax1 = (((dAmount1 - disc1) * Convert.ToDecimal(txtBillNo.Text)) / 100);

                samt += (dAmount1 - disc1);
                sdisc += disc1;
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge


            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            // TextBox txtexpireddate = (TextBox)txt.FindControl("txtexpireddate");
            txtmexpireddate.Focus();

        }


        protected void txtdefCatID_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;
            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");

            #region
            if (Qty.Text == "")
            {
                return;
            }
            if (Rate.Text == "")
            {
                return;
            }
            if (txttax.Text == "")
            {
                return;
            }
            if (Amount.Text == "")
            {
                return;
            }

            #endregion
            decimal dAmount = 0;
            decimal samt = 0;

            decimal tax = 0;

            lblError.Visible = false;
            Button1.Enabled = true;
            if (Qty.Text.Trim() != "")
            {
                decimal dQty = Convert.ToDecimal(Qty.Text);
                decimal DRate = Convert.ToDecimal(Rate.Text);
                dAmount = dQty * DRate;

                tax = ((dAmount * Convert.ToDecimal(txttax.Text)) / 100);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
            }

            decimal amttax = dAmount + tax;


            Amount.Text = amttax.ToString("f2");
            decimal dAmt = 0; decimal dTotal = 0;

            decimal ttltax = 0;
            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                decimal tax1 = 0;

                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");

                txtsno.Text = (i + 1).ToString();

                TextBox tAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                if (tAmount.Text != "")
                {
                    dAmt += Convert.ToDecimal(tAmount.Text);
                }

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                #region
                if (txtQty.Text == "")
                {
                    return;
                }
                if (txtRate.Text == "")
                {
                    return;
                }
                if (txtBillNo.Text == "")
                {
                    return;
                }

                #endregion

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);
                samt += (Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text));
                tax1 = ((dAmount1 * Convert.ToDecimal(txtBillNo.Text)) / 100);

                ttltax = ttltax + tax1;

            }
            dTotal = dAmt;
            txtSubTotal.Text = samt.ToString("f2");
            txttotal.Text = dTotal.ToString("f2");
            // txtTax.Text = ttltax.ToString("f2");
            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }
            //LinkButton Button = (LinkButton)txt.FindControl("add");
            //Button.Focus();

            TextBox txtexpireddate = (TextBox)txt.FindControl("txtexpireddate");
            txtexpireddate.Focus();

        }

        //protected void rbtype_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (rbtype.SelectedValue == "1")
        //    {
        //        Div2.Visible = false;
        //        Div3.Visible = false;
        //    }
        //    else
        //    {
        //        Div2.Visible = true;
        //        Div3.Visible = true;
        //    }
        //}





        protected void rbdpurchasetype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvcustomerorder.DataSource = null;
            gvcustomerorder.DataBind();

            txtcgst.Text = "0";
            txtsgst.Text = "0";
            txtigst.Text = "0";
            txtigst.Text = "0";

            FirstGridViewRow();
        }

        protected void gvcustomerorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //DataSet dsCategory = kbs.GetIngredient();
            //DataSet dunitsval = new DataSet();
            //DataSet dunits = kbs.UNITS();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    #region

            //    DropDownList ddlunits = (DropDownList)(e.Row.FindControl("ddlunits") as DropDownList);
            //    DropDownList ddIngredients = (DropDownList)(e.Row.FindControl("ddlDef") as DropDownList);
            //    Label lblunits = (Label)(e.Row.FindControl("lblunits") as Label);

            //    ddIngredients.Focus();
            //    ddIngredients.Enabled = true;

            //    if (dsCategory.Tables[0].Rows.Count > 0)
            //    {
            //        ddIngredients.DataSource = dsCategory.Tables[0];
            //        ddIngredients.DataTextField = "IngredientName";
            //        ddIngredients.DataValueField = "IngridID";
            //        ddIngredients.DataBind();
            //        ddIngredients.Items.Insert(0, "Select IngredientName");
            //    }
            //    if (dunits.Tables[0].Rows.Count > 0)
            //    {
            //        ddlunits.DataSource = dunits.Tables[0];
            //        ddlunits.DataTextField = "UOM";
            //        ddlunits.DataValueField = "UOMID";
            //        ddlunits.DataBind();
            //    }

            //    //////if (ddIngredients.SelectedValue != "Select IngredientName")
            //    //////{
            //    //////    dunitsval = kbs.GetIngredientVal(Convert.ToInt32(ddIngredients.SelectedValue));
            //    //////    if (dunits.Tables[0].Rows.Count > 0)
            //    //////    {
            //    //////        ddlunits.SelectedValue = dunitsval.Tables[0].Rows[0]["Units"].ToString();
            //    //////        lblunits.Text = ddlunits.SelectedItem.Text;

            //    //////    }
            //    //////}

            //    #endregion
            //}
        }

        protected void ddlsuplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvcustomerorder.DataSource = null;
            gvcustomerorder.DataBind();

            drpPO.ClearSelection();
            drpPO.Items.Clear();

            ViewState["CurrentTable"] = null;
            string itemname = "IngredientName";
            if (ddlsuplier.SelectedValue == "" || ddlsuplier.SelectedValue == "0" || ddlsuplier.SelectedValue == "Select Supplier")
            {
                int supplier = 0;

                supplier = Convert.ToInt32(ddlsuplier.SelectedValue);

                DataSet dsPO = kbs.PurchaseInvoiceNoList_supplierlist(sTableName, ddlsuplier.SelectedValue);
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    drpPO.DataSource = dsPO.Tables[0];
                    drpPO.DataTextField = "DCNO";
                    drpPO.DataValueField = "PurchaseID";
                    drpPO.DataBind();
                    drpPO.Items.Insert(0, "Select Purchase InvoiceNo");
                }
                else
                {
                    drpPO.Items.Insert(0, "Select Purchase InvoiceNo");
                }


                DataSet dsCategory = kbs.GetSupplierIngredient(Convert.ToInt32(supplier), "1");

                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    drpmingredents.DataSource = dsCategory.Tables[0];
                    drpmingredents.DataTextField = itemname;
                    drpmingredents.DataValueField = "IngridID";
                    drpmingredents.DataBind();
                    drpmingredents.Items.Insert(0, "Select IngredientName");
                }

                DataSet dunits = kbs.UNITS();
                if (dunits.Tables[0].Rows.Count > 0)
                {
                    ddlmunits.DataSource = dunits.Tables[0];
                    ddlmunits.DataTextField = "UOM";
                    ddlmunits.DataValueField = "UOMID";
                    ddlmunits.DataBind();
                }

                DataSet dprimary = kbs.PrimaryUNITS();
                if (dprimary.Tables[0].Rows.Count > 0)
                {
                    ddlmprimaryunits.DataSource = dprimary.Tables[0];
                    ddlmprimaryunits.DataTextField = "Primaryname";
                    ddlmprimaryunits.DataValueField = "PrimaryUOMID";
                    ddlmprimaryunits.DataBind();
                    ddlmprimaryunits.Items.Insert(0, "Select PrimaryUom");
                }
            }
            else
            {

                // GEtting Information
                //DataSet dsupplier = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
                //if (dsupplier.Tables[0].Rows.Count > 0)
                //{
                //    txtmobileno.Text = dsupplier.Tables[0].Rows[0]["mobileno"].ToString();
                //    txtaddress.Text = dsupplier.Tables[0].Rows[0]["address"].ToString();
                //    txtcity.Text = dsupplier.Tables[0].Rows[0]["city"].ToString();
                //    txtgstno.Text = dsupplier.Tables[0].Rows[0]["gstno"].ToString();
                //}



                DataSet dss = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    if (dss.Tables[0].Rows[0]["Province"].ToString() == "Inner" || dss.Tables[0].Rows[0]["Province"].ToString() == "")
                    {
                        rbdpurchasetype.SelectedValue = "1";
                    }
                    else
                    {
                        rbdpurchasetype.SelectedValue = "2";
                    }
                }
                else
                {
                    rbdpurchasetype.SelectedValue = "1";
                }
                int supplier = 0;
                supplier = Convert.ToInt32(ddlsuplier.SelectedValue);

                DataSet dsPO = kbs.PurchaseInvoiceNoList_supplierlist(sTableName, ddlsuplier.SelectedValue);
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    drpPO.DataSource = dsPO.Tables[0];
                    drpPO.DataTextField = "DCNO";
                    drpPO.DataValueField = "PurchaseID";
                    drpPO.DataBind();
                    drpPO.Items.Insert(0, "Select Purchase InvoiceNo");
                }
                else
                {
                    drpPO.Items.Insert(0, "Select Purchase InvoiceNo");
                }


                DataSet dsCategory = kbs.GetSupplierIngredient(Convert.ToInt32(supplier), "1");

                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    drpmingredents.DataSource = dsCategory.Tables[0];
                    drpmingredents.DataTextField = itemname;
                    drpmingredents.DataValueField = "IngridID";
                    drpmingredents.DataBind();
                    drpmingredents.Items.Insert(0, "Select IngredientName");
                }

                DataSet dunits = kbs.UNITS();
                if (dunits.Tables[0].Rows.Count > 0)
                {
                    ddlmunits.DataSource = dunits.Tables[0];
                    ddlmunits.DataTextField = "UOM";
                    ddlmunits.DataValueField = "UOMID";
                    ddlmunits.DataBind();
                }

                DataSet dprimary = kbs.PrimaryUNITS();
                if (dprimary.Tables[0].Rows.Count > 0)
                {
                    ddlmprimaryunits.DataSource = dprimary.Tables[0];
                    ddlmprimaryunits.DataTextField = "Primaryname";
                    ddlmprimaryunits.DataValueField = "PrimaryUOMID";
                    ddlmprimaryunits.DataBind();
                    ddlmprimaryunits.Items.Insert(0, "Select PrimaryUom");
                }

                // FirstGridViewRow();
            }
        }


        protected void ddlsuplier_OnSelectedIndexChanged1(object sender, EventArgs e)
        {
            DataSet dss = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
            if (dss.Tables[0].Rows.Count > 0)
            {
                if (dss.Tables[0].Rows[0]["Province"].ToString() == "Inner" || dss.Tables[0].Rows[0]["Province"].ToString() == "")
                {
                    rbdpurchasetype.SelectedValue = "1";
                }
                else
                {
                    rbdpurchasetype.SelectedValue = "2";
                }
            }
            else
            {
                rbdpurchasetype.SelectedValue = "1";
            }
        }

        protected void txtdefQty_TextChangedOLD(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox DisCount = (TextBox)row.FindControl("txtDisCount");

            //DropDownList ddlprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");
            Label lblprimaryname = (Label)row.FindControl("lblprimaryname");
            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            TextBox PQty = (TextBox)row.FindControl("txtPQty");

            //if (ddlprimaryunits.SelectedValue == "Select PrimaryUom")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Primary Uom.');", true);
            //    return;
            //}

            if (Qty.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Qty');", true);
                return;
            }
            if (Rate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
                return;
            }


            if (Qty.Text == "")
                Qty.Text = "0";
            if (Rate.Text == "")
                Rate.Text = "0";
            if (Amount.Text == "")
                Rate.Text = "0";
            if (txttax.Text == "")
                Rate.Text = "0";
            if (DisCount.Text == "")
                DisCount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;
            decimal Pqty = 0;

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(Qty.Text);
            decimal DRate = Convert.ToDecimal(Rate.Text);
            decimal DDisCount = Convert.ToDecimal(DisCount.Text);

            dAmount = dQty * DRate;

            Pqty = dQty * Convert.ToDecimal(lblprimaryvalue.Text);
            Disc = (dAmount * DDisCount) / 100;

            tax = ((dAmount - Disc) * Convert.ToDecimal(txttax.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            Amount.Text = amt.ToString("f2");
            PQty.Text = Pqty.ToString("f2");

            decimal samt = 0; decimal sdisc = 0; decimal ttltax = 0;

            for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
            {
                TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");
                txtsno.Text = (i + 1).ToString();

                TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");
                TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtDisCount");

                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtRate.Text == "")
                    txtRate.Text = "0";
                if (txtBillNo.Text == "")
                    txtBillNo.Text = "0";
                if (txtDisCount.Text == "")
                    txtDisCount.Text = "0";

                decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                decimal disc1 = (dAmount1 * Convert.ToDecimal(txtDisCount.Text)) / 100;

                decimal tax1 = (((dAmount1 - disc1) * Convert.ToDecimal(txtBillNo.Text)) / 100);

                samt += (dAmount1 - disc1);
                sdisc += disc1;
                ttltax += tax1;

            }

            txtSubTotal.Text = samt.ToString("f2");
            txtDiscountAmount.Text = sdisc.ToString("f2");
            txttotal.Text = (samt + ttltax).ToString("f2");

            if (rbdpurchasetype.SelectedValue == "1")
            {
                txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                txtigst.Text = "0.00";
            }
            else
            {
                txtcgst.Text = "0.00";
                txtsgst.Text = "0.00";
                txtigst.Text = ttltax.ToString("f2");
            }

            #region FreightCharge

            //if (txtFreightCharge.Text == "")
            //    txtFreightCharge.Text = "0";

            //decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            //txtFreightChargeTax.Text = Tax.ToString("f2");

            //decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text));
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            double r = 0;
            double roundoff = Convert.ToDouble(txttotal.Text) - Math.Floor(Convert.ToDouble(txttotal.Text));
            if (roundoff > 0.5)
            {
                r = Math.Round(Convert.ToDouble(txttotal.Text), MidpointRounding.AwayFromZero);
            }
            else
            {
                r = Math.Floor(Convert.ToDouble(txttotal.Text));
            }
            txtroundoff.Text = Convert.ToString(r);

            DisCount.Focus();
        }


        protected void drpPO_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpPO.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Purchase OrderNo');", true);
                return;
            }
            else
            {
                #region

                DataSet dagent = kbs.getPurchaseInvoicelist(drpPO.SelectedValue, sTableName);
                if (dagent.Tables[0].Rows.Count > 0)
                {
                    //shwedit.Visible = true;
                    txtbillno.Text = dagent.Tables[0].Rows[0]["Billno"].ToString();
                    txtdcno.Text = dagent.Tables[0].Rows[0]["DCNo"].ToString();
                    lblpurchase.InnerText = dagent.Tables[0].Rows[0]["Billno"].ToString();

                    txtsdate1.Text = Convert.ToDateTime(dagent.Tables[0].Rows[0]["BillDate"]).ToString("yyyy-MM-dd"); // dagent.Tables[0].Rows[0]["OrderDate"].ToString("yyyy-MM-dd");

                    ddlsuplier.SelectedValue = dagent.Tables[0].Rows[0]["Supplier"].ToString();
                    //ddlsuplier_OnSelectedIndexChanged(sender, e);

                    DataSet dss1 = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
                    if (dss1.Tables[0].Rows.Count > 0)
                    {
                        if (dss1.Tables[0].Rows[0]["Province"].ToString() == "Inner" || dss1.Tables[0].Rows[0]["Province"].ToString() == "")
                        {
                            rbdpurchasetype.SelectedValue = "1";
                        }
                        else
                        {
                            rbdpurchasetype.SelectedValue = "2";
                        }
                    }
                    else
                    {
                        rbdpurchasetype.SelectedValue = "1";
                    }
                    int supplier = 0;
                    supplier = Convert.ToInt32(ddlsuplier.SelectedValue);

                   


                    DataSet dsCategory = kbs.GetSupplierIngredient(Convert.ToInt32(supplier), "1");
                    string itemname = "IngredientName";
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        drpmingredents.DataSource = dsCategory.Tables[0];
                        drpmingredents.DataTextField = itemname;
                        drpmingredents.DataValueField = "IngridID";
                        drpmingredents.DataBind();
                        drpmingredents.Items.Insert(0, "Select IngredientName");
                    }

                    DataSet dunits = kbs.UNITS();
                    if (dunits.Tables[0].Rows.Count > 0)
                    {
                        ddlmunits.DataSource = dunits.Tables[0];
                        ddlmunits.DataTextField = "UOM";
                        ddlmunits.DataValueField = "UOMID";
                        ddlmunits.DataBind();
                    }

                    DataSet dprimary = kbs.PrimaryUNITS();
                    if (dprimary.Tables[0].Rows.Count > 0)
                    {
                        ddlmprimaryunits.DataSource = dprimary.Tables[0];
                        ddlmprimaryunits.DataTextField = "Primaryname";
                        ddlmprimaryunits.DataValueField = "PrimaryUOMID";
                        ddlmprimaryunits.DataBind();
                        ddlmprimaryunits.Items.Insert(0, "Select PrimaryUom");
                    }




                    ddlpaymode.SelectedValue = dagent.Tables[0].Rows[0]["Paymode"].ToString();

                    if (dagent.Tables[0].Rows[0]["Paymode"].ToString() == "4" || dagent.Tables[0].Rows[0]["Paymode"].ToString() == "11" || dagent.Tables[0].Rows[0]["Paymode"].ToString() == "15" || dagent.Tables[0].Rows[0]["Paymode"].ToString() == "19")
                    {
                        ddlbank.Enabled = true;
                        txtcheque.Enabled = true;
                        ddlbank.Visible = true;
                        txtcheque.Visible = true;
                        lblbank.Visible = true;
                        lblChq.Visible = true;
                    }
                    else
                    {
                        ddlbank.Enabled = false;
                        txtcheque.Enabled = false;

                        ddlbank.Visible = false;
                        txtcheque.Visible = false;

                        lblbank.Visible = false;
                        lblChq.Visible = false;
                    }

                    if (dagent.Tables[0].Rows[0]["Province"].ToString() == "Inner")
                    {
                        rbdpurchasetype.SelectedValue = "1";
                    }
                    else
                    {
                        rbdpurchasetype.SelectedValue = "2";
                    }
                    // ddlbank.SelectedValue = dagent.Tables[0].Rows[0]["Bank"].ToString();
                    //txtcheque.Text = dagent.Tables[0].Rows[0]["ChequeNo"].ToString();
                    txtSubTotal.Text = dagent.Tables[0].Rows[0]["SubTotal"].ToString();
                    txttotal.Text = dagent.Tables[0].Rows[0]["Total"].ToString();
                    txtcgst.Text = dagent.Tables[0].Rows[0]["CGST"].ToString();
                    txtsgst.Text = dagent.Tables[0].Rows[0]["SGST"].ToString();
                    txtigst.Text = dagent.Tables[0].Rows[0]["IGST"].ToString();
                    txtroundoff.Text = dagent.Tables[0].Rows[0]["Roundoff"].ToString();

                    // Button1.Text = "update";

                    DataSet transpur = kbs.getPurchaseInvoicetranslist(drpPO.SelectedValue, sTableName);


                    DataTable dttt;
                    DataRow drNew;
                    DataColumn dct;
                    DataSet dstd = new DataSet();
                    dttt = new DataTable();

                    dct = new DataColumn("sno");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Ingredient");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("IngredientID");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Qty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Rate");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Amount");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Units");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Unitsid");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("BillNo");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Supplier");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Paymode");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("ExpDate");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("DisCount");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("DisCountAmnt");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("PUnits");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("PUnitsvalue");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Pvalue");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Bname");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Hsncode");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("PQty");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("PoQty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Narrations");
                    dttt.Columns.Add(dct);

                    dstd.Tables.Add(dttt);

                    foreach (DataRow dr in transpur.Tables[0].Rows)
                    {

                        drNew = dttt.NewRow();
                        drNew["sno"] = 0;
                        DataSet dsGetIngName = kbs.GetIngredientsName(Convert.ToInt32(dr["IngredientID"]));
                        if (dsGetIngName.Tables[0].Rows.Count > 0)
                        {
                            drNew["Ingredient"] = dsGetIngName.Tables[0].Rows[0]["IngredientName"].ToString();
                        }
                        else
                        {
                            drNew["Ingredient"] = "";
                        }
                        drNew["IngredientID"] = dr["IngredientID"];
                        drNew["Qty"] = Convert.ToDouble(dr["Qty"]) - Convert.ToDouble(dr["RQty"]);
                        drNew["Rate"] = dr["Rate"];
                        drNew["Amount"] = dr["Amount"];
                        DataSet dsUOMName = kbs.GetUOMName(Convert.ToInt32(dr["IngredientID"]));
                        if (dsUOMName.Tables[0].Rows.Count > 0)
                        {
                            drNew["Units"] = dsUOMName.Tables[0].Rows[0]["UOM"].ToString();
                            drNew["Unitsid"] = dsUOMName.Tables[0].Rows[0]["UOMid"].ToString();
                        }
                        else
                        {
                            drNew["Units"] = "";
                            drNew["Unitsid"] = "";
                        }
                        drNew["BillNo"] = dr["Tax"];
                        drNew["Supplier"] = 0;
                        drNew["Paymode"] = 0;
                        drNew["ExpDate"] = dr["ExpiryDate"];
                        drNew["DisCount"] = dr["Disc"];
                        drNew["DisCountAmnt"] = dr["DiscountAmnt"];
                        drNew["PoQty"] = dr["Qty"];
                        DataSet dspunits = kbs.GetPrimaryUOMName(Convert.ToInt32(dr["Punitsid"]));
                        if (dspunits.Tables[0].Rows.Count > 0)
                        {
                            drNew["PUnits"] = dspunits.Tables[0].Rows[0]["primaryname"].ToString();
                        }
                        drNew["PUnitsvalue"] = dr["PUnitsid"];
                        drNew["Pvalue"] = dr["Pvalue"];
                        drNew["Narrations"] = dr["Narrations"];

                        drNew["ExpDate"] = dr["ExpiryDate"];
                        DataSet dsPUOMName = kbs.GetPrimaryUOMName(Convert.ToInt32(dr["Punitsid"]));
                        if (dsPUOMName.Tables[0].Rows.Count > 0)
                        {
                            drNew["PUnits"] = dsPUOMName.Tables[0].Rows[0]["PrimaryName"].ToString();
                            drNew["PUnitsvalue"] = dsPUOMName.Tables[0].Rows[0]["PrimaryUOMid"].ToString();
                            drNew["Pvalue"] = dsPUOMName.Tables[0].Rows[0]["PrimaryValue"].ToString();
                        }
                        else
                        {
                            drNew["PUnits"] = dr["Punitsid"];
                            drNew["PUnitsvalue"] = dr["Punitsid"];
                            drNew["Pvalue"] = dr["Pvalue"];
                        }

                        DataSet dss = kbs.getingreUnits(dr["IngredientID"].ToString(), ddlsuplier.SelectedValue, "1");
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            // Label lblunits = (Label)row.FindControl("lblunits");
                            //drNew["Units"] = dss.Tables[0].Rows[0]["UOM"].ToString();
                            //drNew["Unitsid"] = dss.Tables[0].Rows[0]["UOMid"].ToString();
                            //  TextBox txtBillNo = (TextBox)row.FindControl("txtBillNo");
                            // txtmBillNo.Text = dss.Tables[0].Rows[0]["TaxValue"].ToString();

                            drNew["Bname"] = dss.Tables[0].Rows[0]["BIngredientName"].ToString();

                            drNew["Hsncode"] = dss.Tables[0].Rows[0]["HsnCode"].ToString();

                        }
                        drNew["PQty"] = Convert.ToDouble(dr["PUqty"]) - Convert.ToDouble(dr["RPUqty"]);
                        drNew["Bname"] = "";
                        drNew["Hsncode"] = "";
                        drNew["Narrations"] = "";
                        dstd.Tables[0].Rows.Add(drNew);
                    }
                    ViewState["CurrentTable"] = dttt;

                    gvcustomerorder.DataSource = dstd;
                    gvcustomerorder.DataBind();

                    for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
                    {
                        TextBox txtsno = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsno");
                        //DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");
                        Label txtdefname = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtdefname");
                        Label txtdefid = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtdefid");
                        Label lblDescriptionID = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblDescriptionID");
                        //Label lblunits = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunits");
                        Label lblunits = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunits");
                        Label lblunitsid = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunitsid");
                        TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtbillingname");

                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtAmount");
                        // DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlunits");
                        TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtBillNo");
                        TextBox txtsupplier = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsupplier");
                        DropDownList ddlPay = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlPay");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtexpireddate");
                        TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCount");
                        TextBox txthsncode = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txthsncode");
                        TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCountAmount");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryvalue");
                        Label lblprimarynamevalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimarynamevalue");
                        Label lblprimaryname = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryname");

                        TextBox txtpqty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtpqty");

                        Label lblpoqty = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblpoqty");
                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtnarrations");

                        txtsno.Text = (vLoop + 1).ToString();

                        //lblpoqty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["PoQty"]).ToString();
                        lblpoqty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                        txtnarrations.Text = dstd.Tables[0].Rows[vLoop]["Narrations"].ToString();



                        //ddlDef.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();

                        lblDescriptionID.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();

                        txtbillingname.Text = dstd.Tables[0].Rows[vLoop]["BName"].ToString();
                        //lblunits.Text = dstd.Tables[0].Rows[vLoop]["Units"].ToString();
                        //lblunitsid.Text = dstd.Tables[0].Rows[vLoop]["Unitsid"].ToString();
                        txthsncode.Text = dstd.Tables[0].Rows[vLoop]["Hsncode"].ToString();
                        txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                        txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString();
                        txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString();
                        // ddlunits.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Units"]).ToString();
                        lblunits.Text = dstd.Tables[0].Rows[vLoop]["Units"].ToString();
                        lblunitsid.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Unitsid"]).ToString();
                        //lblunits.Text = ddlunits.SelectedItem.Text;
                        //////  txtBillNo.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString(); 

                        txtBillNo.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString("f2");
                        txtsupplier.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Supplier"]).ToString();
                        ddlPay.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Paymode"]).ToString();
                        txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");
                        if (txtexpireddate.Text == "01/01/1900")
                        {
                            txtexpireddate.Text = "";
                        }


                        txtDisCount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCount"]).ToString();
                        txtDisCountAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCountAmnt"]).ToString();
                        // ddlprimaryunits.SelectedValue = dstd.Tables[0].Rows[vLoop]["PUnits"].ToString();
                        lblprimaryvalue.Text = dstd.Tables[0].Rows[vLoop]["Pvalue"].ToString();
                        lblprimaryname.Text = dstd.Tables[0].Rows[vLoop]["PUnits"].ToString();
                        lblprimarynamevalue.Text = dstd.Tables[0].Rows[vLoop]["PUnitsvalue"].ToString();
                        txtpqty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["PQty"]).ToString();
                        //  ddlDef.Enabled = false;
                    }
                }


                #region

                decimal samt = 0;
                decimal dAmt = 0; decimal dTotal = 0;

                decimal ttltax = 0;
                for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                {
                    decimal tax1 = 0;

                    TextBox txtsno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsno");

                    txtsno.Text = (i + 1).ToString();

                    TextBox tAmount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");


                    TextBox txtQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                    TextBox txtRate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                    TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");




                    decimal dAmount1 = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                    samt += Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtRate.Text);

                    tax1 = ((dAmount1 * Convert.ToDecimal(txtBillNo.Text)) / 100);

                    ttltax = ttltax + tax1;

                    tAmount.Text = (dAmount1 + tax1).ToString("f2");

                    dAmt += (dAmount1 + tax1);

                }
                dTotal = dAmt;
                //txtSubTotal.Text = samt.ToString("f2");
                //txttotal.Text = dTotal.ToString("f2");
                //// txtTax.Text = ttltax.ToString("f2");
                //if (rbdpurchasetype.SelectedValue == "1")
                //{
                //    txtcgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                //    txtsgst.Text = string.Format("{0:N2}", Convert.ToDouble(ttltax) / 2);
                //    txtigst.Text = "0.00";
                //}
                //else
                //{
                //    txtcgst.Text = "0.00";
                //    txtsgst.Text = "0.00";
                //    txtigst.Text = ttltax.ToString("f2");
                //}



                #endregion
                #endregion
            }
        }

        protected void ddlpaymode_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpaymode.SelectedValue == "4" || ddlpaymode.SelectedValue == "11" || ddlpaymode.SelectedValue == "15" || ddlpaymode.SelectedValue == "19")
            {
                ddlbank.Enabled = true;
                txtcheque.Enabled = true;
                ddlbank.Visible = true;
                txtcheque.Visible = true;
                lblbank.Visible = true;
                lblChq.Visible = true;
            }
            else
            {
                ddlbank.Enabled = false;
                txtcheque.Enabled = false;

                ddlbank.Visible = false;
                txtcheque.Visible = false;

                lblbank.Visible = false;
                lblChq.Visible = false;
            }
            ddlpaymode.Focus();
        }

        protected void ddlDef_OnSelectedIndexChanged2(object sender, EventArgs e)
        {


            int supplier = 0;

            supplier = Convert.ToInt32(ddlsuplier.SelectedValue);

            DataSet dss = kbs.getingreUnits(drpmingredents.SelectedValue, supplier.ToString(), "1");
            if (dss.Tables[0].Rows.Count > 0)
            {
                // Label lblunits = (Label)row.FindControl("lblunits");
                lblmunits.Text = dss.Tables[0].Rows[0]["UOM"].ToString();
                lblmunitsid.Text = dss.Tables[0].Rows[0]["UOMid"].ToString();

                //  TextBox txtBillNo = (TextBox)row.FindControl("txtBillNo");
                txtmBillNo.Text = dss.Tables[0].Rows[0]["TaxValue"].ToString();


                txtmQty.Focus();


                //  TextBox txtbillingname = (TextBox)row.FindControl("txtbillingname");

                txtmbillingname.Text = dss.Tables[0].Rows[0]["BIngredientName"].ToString();

                //  TextBox txthsncode = (TextBox)row.FindControl("txthsncode");
                txtmhsncode.Text = dss.Tables[0].Rows[0]["HsnCode"].ToString();

            }

            // get total stock
            DataSet getavlstock = kbs.InserttransrawitemacceptCheck(sTableName, drpmingredents.SelectedValue);
                if (getavlstock.Tables[0].Rows.Count > 0)
            {
                txtavlqty.Text = getavlstock.Tables[0].Rows[0]["Qty"].ToString();
            }
            else
            {
                txtavlqty.Text = "0";
            }


            if (ddlmprimaryunits.SelectedValue == "Select PrimaryUom")
            {

            }
            else
            {
                if (txtmQty.Text == "0" || txtmQty.Text == "")
                {
                    txtmQty.Text = "0";
                }

                txtmpqty.Text = (Convert.ToDouble(txtmQty.Text) * Convert.ToDouble(lblmprimaryvalue.Text)).ToString("0.00");
            }
        }


        protected void drpprimary_unit(object sender, EventArgs e)
        {
            //  DropDownList ddl = (DropDownList)sender;
            //            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            //          DropDownList ddlprimaryunitss = (DropDownList)row.FindControl("ddlprimaryunits");
            //        Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            //      TextBox txtQty = (TextBox)row.FindControl("txtQty");
            //    TextBox PQty = (TextBox)row.FindControl("txtPQty");
            if (ddlmprimaryunits.SelectedValue != "Select PrimaryUom")
            {
                DataSet dss = kbs.getPrimaryUNITSvalue(ddlmprimaryunits.SelectedValue);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblmprimaryvalue.Text = Convert.ToDouble(dss.Tables[0].Rows[0]["Primaryvalue"]).ToString("0.00");
                }

                if (txtmQty.Text == "0" || txtmQty.Text == "")
                {
                    txtmQty.Text = "0";
                }
                else
                {
                    txtmpqty.Text = (Convert.ToDouble(txtmQty.Text) * Convert.ToDouble(lblmprimaryvalue.Text)).ToString("0.00");
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Valid Primary UOM.Thank You!!!.');", true);
                return;
            }
        }


        protected void ddlDef_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            #region
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
            {
                DropDownList txti = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");


                itemc = txti.Text;


                if ((itemc == null) || (itemc == ""))
                {
                }
                else
                {
                    for (int vLoop1 = 0; vLoop1 < gvcustomerorder.Rows.Count; vLoop1++)
                    {
                        DropDownList txt1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlDef");
                        if (txt1.Text == "")
                        {
                        }
                        else
                        {

                            if (ii == iq)
                            {
                            }
                            else
                            {
                                if (itemc == txt1.Text)
                                {
                                    itemcd = txti.SelectedItem.Text;
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + itemcd + "  already exists in the Grid.');", true);

                                    txt1.Focus();

                                    return;

                                }
                            }
                            ii = ii + 1;
                        }
                    }
                }
                iq = iq + 1;
                ii = 1;

                txti.Focus();
            }


            #endregion



            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            DropDownList ddlDef = (DropDownList)row.FindControl("ddlDef");

            DataSet dss = kbs.getingreUnits(ddlDef.SelectedValue, "0", "2");
            if (dss.Tables[0].Rows.Count > 0)
            {
                Label lblunits = (Label)row.FindControl("lblunits");
                lblunits.Text = dss.Tables[0].Rows[0]["UOM"].ToString();
                TextBox txtQty = (TextBox)row.FindControl("txtQty");
                txtQty.Focus();
            }
        }

    }
}