using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class RawSales : System.Web.UI.Page
    {
        string sTableName = "";
        string scode = "";
        BSClass kbs = new BSClass();
        string Rate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"]["BranchCode"] != null)
                sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            else
                Response.Redirect("login1.aspx");



            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();


            if (!Page.IsPostBack)
            {

                DataSet dstax = kbs.Tax();
                if (dstax.Tables[0].Rows.Count > 0)
                {
                    ddltax.DataSource = dstax.Tables[0];
                    ddltax.DataTextField = "TaxName";
                    ddltax.DataValueField = "Taxid";
                    ddltax.DataBind();

                }

                rbdpurchasetype.SelectedValue = "1";

                //DataSet dsCustomer = kbs.SupplierList11();
                //if (dsCustomer.Tables[0].Rows.Count > 0)
                //{
                //    ddlsuplier.DataSource = dsCustomer.Tables[0];
                //    ddlsuplier.DataTextField = "LedgerName";
                //    ddlsuplier.DataValueField = "LedgerID";
                //    ddlsuplier.DataBind();
                //    ddlsuplier.Items.Insert(0, "Select Supplier");


                //}

                DataSet bank = kbs.Ledgerbank();
                if (bank.Tables[0].Rows.Count > 0)
                {
                    ddlbank.DataSource = bank.Tables[0];
                    ddlbank.DataTextField = "LedgerName";
                    ddlbank.DataValueField = "LedgerID";
                    ddlbank.DataBind();
                    ddlbank.Items.Insert(0, "Select Bank");
                }

                //DataSet dsPO = kbs.PurchaseOrderList2(sTableName);
                //if (dsPO.Tables[0].Rows.Count > 0)
                //{
                //    drpPO.DataSource = dsPO.Tables[0];
                //    drpPO.DataTextField = "OrderNo";
                //    drpPO.DataValueField = "OrderNo";
                //    drpPO.DataBind();
                //    drpPO.Items.Insert(0, "Select Purchase OrderNo");


                //}

                DataSet dNo = kbs.entrysalesno(sTableName);
                txtbillno.Text = dNo.Tables[0].Rows[0]["billno"].ToString();

                txtsdate1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                Button1.Text = "Save";
                FirstGridViewRow();

                // FirstGridViewRow();

                string iSalesID = Request.QueryString.Get("LedgerID");
                if (iSalesID != null)
                {
                    //#region

                    //DataSet dagent = kbs.getduplist(iSalesID, sTableName);
                    //if (dagent.Tables[0].Rows.Count > 0)
                    //{
                    //    shwedit.Visible = true;
                    //    txtbillno.Text = dagent.Tables[0].Rows[0]["BillNo"].ToString();
                    //    txtdcno.Text = dagent.Tables[0].Rows[0]["DCNo"].ToString();
                    //    lblpurchase.InnerText = dagent.Tables[0].Rows[0]["BillNo"].ToString();

                    //    txtsdate1.Text = dagent.Tables[0].Rows[0]["BillDate"].ToString();

                    //    ddlsuplier.SelectedValue = dagent.Tables[0].Rows[0]["Supplier"].ToString();

                    //    ddlpaymode.SelectedValue = dagent.Tables[0].Rows[0]["Paymode"].ToString();

                    //    if (dagent.Tables[0].Rows[0]["Paymode"].ToString() == "1")
                    //    {
                    //        ddlbank.Enabled = false;
                    //        txtcheque.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        ddlbank.Enabled = true;
                    //        txtcheque.Enabled = true;
                    //    }

                    //    if (dagent.Tables[0].Rows[0]["Province"].ToString() == "1")
                    //    {
                    //        rbdpurchasetype.SelectedValue = "1";
                    //    }
                    //    else
                    //    {
                    //        rbdpurchasetype.SelectedValue = "2";
                    //    }

                    //    txtFreightCharge.Text = dagent.Tables[0].Rows[0]["FreightCharge"].ToString();
                    //    txtFreightChargeTax.Text = dagent.Tables[0].Rows[0]["FreightChargeTax"].ToString();
                    //    ddltax.SelectedValue = dagent.Tables[0].Rows[0]["FreightChargeTaxId"].ToString();

                    //    txtSubTotal.Text = dagent.Tables[0].Rows[0]["SubTotal"].ToString();
                    //    txttotal.Text = dagent.Tables[0].Rows[0]["Total"].ToString();
                    //    txtcgst.Text = dagent.Tables[0].Rows[0]["CGST"].ToString();
                    //    txtsgst.Text = dagent.Tables[0].Rows[0]["SGST"].ToString();
                    //    txtigst.Text = dagent.Tables[0].Rows[0]["IGST"].ToString();
                    //    txtDiscountAmount.Text = dagent.Tables[0].Rows[0]["DiscountAmount"].ToString();

                    //    ddlbank.SelectedValue = dagent.Tables[0].Rows[0]["Bank"].ToString();
                    //    txtcheque.Text = dagent.Tables[0].Rows[0]["ChequeNo"].ToString();
                    //    Button1.Text = "update";

                    //    DataSet transpur = kbs.getduplisttrans(iSalesID, sTableName);


                    //    DataTable dttt;
                    //    DataRow drNew;
                    //    DataColumn dct;
                    //    DataSet dstd = new DataSet();
                    //    dttt = new DataTable();

                    //    dct = new DataColumn("sno");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("Ingredient");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("IngredientID");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("Qty");
                    //    dttt.Columns.Add(dct);
                    //    dct = new DataColumn("Rate");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("Amount");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("Units");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("BillNo");
                    //    dttt.Columns.Add(dct);
                    //    dct = new DataColumn("Supplier");
                    //    dttt.Columns.Add(dct);
                    //    dct = new DataColumn("Paymode");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("ExpDate");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("DisCount");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("PUnits");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("Pvalue");
                    //    dttt.Columns.Add(dct);

                    //    dct = new DataColumn("PQty");
                    //    dttt.Columns.Add(dct);

                    //    dstd.Tables.Add(dttt);

                    //    foreach (DataRow dr in transpur.Tables[0].Rows)
                    //    {

                    //        drNew = dttt.NewRow();
                    //        drNew["sno"] = 0;
                    //        drNew["Ingredient"] = dr["IngredientID"];
                    //        drNew["IngredientID"] = dr["IngredientID"];
                    //        drNew["Qty"] = dr["Qty"];
                    //        drNew["Rate"] = dr["Rate"];
                    //        drNew["Amount"] = dr["Amount"];
                    //        drNew["Units"] = dr["Units"];
                    //        drNew["BillNo"] = dr["Tax"];
                    //        drNew["Supplier"] = 0;
                    //        drNew["Paymode"] = 0;
                    //        drNew["ExpDate"] = dr["ExpiryDate"];

                    //        drNew["DisCount"] = dr["Disc"];

                    //        drNew["PUnits"] = dr["Punitsid"];
                    //        drNew["Pvalue"] = dr["Pvalue"];
                    //        drNew["PQty"] = dr["PUqty"];

                    //        dstd.Tables[0].Rows.Add(drNew);
                    //    }
                    //    ViewState["CurrentTable"] = dttt;

                    //    gvcustomerorder.DataSource = dstd;
                    //    gvcustomerorder.DataBind();

                    //    for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
                    //    {
                    //        TextBox txtsno = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsno");
                    //        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");
                    //        Label lblDescriptionID = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblDescriptionID");
                    //        Label lblunits = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunits");

                    //        TextBox txtQty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtQty");
                    //        TextBox txtRate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtRate");
                    //        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtAmount");
                    //        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlunits");
                    //        TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtBillNo");
                    //        TextBox txtsupplier = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsupplier");
                    //        DropDownList ddlPay = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlPay");
                    //        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtexpireddate");
                    //        TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCount");

                    //        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");
                    //        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryvalue");

                    //        TextBox txtpqty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtpqty");

                    //        txtsno.Text = (vLoop + 1).ToString();
                    //        ddlDef.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                    //        lblDescriptionID.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                    //        txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                    //        txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString();
                    //        txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString();
                    //        ddlunits.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Units"]).ToString();
                    //        lblunits.Text = ddlunits.SelectedItem.Text;
                    //        //////  txtBillNo.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString();

                    //        txtBillNo.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString("f2");
                    //        txtsupplier.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Supplier"]).ToString();
                    //        ddlPay.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Paymode"]).ToString();
                    //        //txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");
                    //        txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");
                    //        if (txtexpireddate.Text == "01/01/1900")
                    //        {
                    //            txtexpireddate.Text = "";
                    //        }

                    //        txtDisCount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCount"]).ToString();

                    //        ddlprimaryunits.SelectedValue = dstd.Tables[0].Rows[vLoop]["PUnits"].ToString();
                    //        lblprimaryvalue.Text = dstd.Tables[0].Rows[vLoop]["Pvalue"].ToString();
                    //        txtpqty.Text = dstd.Tables[0].Rows[vLoop]["PQty"].ToString();

                    //    }
                    //}

                    //#endregion
                }

            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }


        protected void chk_chksupplier(object sender, EventArgs e)
        {

            if (chksupplier.Checked == true)
            {
                ddlsuplier.Visible = false;
                txtsupplier.Visible = true;

                txtmobileno.Text = "";
                txtaddress.Text = "";
                txtcity.Text = "";
                txtgstno.Text = "";

                FirstGridViewRow();
            }
            else
            {
                ddlsuplier.Visible = true;
                txtsupplier.Visible = false;

                //DataSet dsCustomer = kbs.SupplierList11();
                //if (dsCustomer.Tables[0].Rows.Count > 0)
                //{
                //    ddlsuplier.DataSource = dsCustomer.Tables[0];
                //    ddlsuplier.DataTextField = "LedgerName";
                //    ddlsuplier.DataValueField = "LedgerID";
                //    ddlsuplier.DataBind();
                //    ddlsuplier.Items.Insert(0, "Select Supplier");


                //}
            }

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
            dt.Columns.Add(new DataColumn("PQty", typeof(string)));

            dt.Columns.Add(new DataColumn("stock", typeof(string)));

            dr = dt.NewRow();
            dr["sno"] = 1;
            dr["Ingredient"] = string.Empty;
            dr["IngredientID"] = string.Empty;

            dr["Qty"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["Amount"] = string.Empty;
            dr["Units"] = string.Empty;
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

            dr["stock"] = string.Empty;

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
                        Label lblstock = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblstock");
                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtnarrations");

                        TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtDisCount");
                        TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtDisCountAmount");

                        TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtbillingname");
                        TextBox txthsncode = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txthsncode");

                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblprimaryvalue");
                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtPQty");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;


                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;

                        dtCurrentTable.Rows[i - 1]["PoQty"] = lblpoqty.Text;
                        dtCurrentTable.Rows[i - 1]["stock"] = lblstock.Text;

                        dtCurrentTable.Rows[i - 1]["Narrations"] = txtnarrations.Text;

                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;

                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;

                        dtCurrentTable.Rows[i - 1]["DisCount"] = txtDisCount.Text;
                        dtCurrentTable.Rows[i - 1]["DisCountAmnt"] = txtDisCountAmount.Text;

                        dtCurrentTable.Rows[i - 1]["Bname"] = txtbillingname.Text;
                        dtCurrentTable.Rows[i - 1]["Hsncode"] = txthsncode.Text;

                        dtCurrentTable.Rows[i - 1]["PUnits"] = ddlprimaryunits.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Pvalue"] = lblprimaryvalue.Text;
                        dtCurrentTable.Rows[i - 1]["PQty"] = txtPQty.Text;

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
                        DropDownList ddlIngregients = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlDef");

                        TextBox txtsno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtsno");
                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");
                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlunits");
                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblDescriptionID");
                        Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");
                        TextBox billno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtBillNo");
                        DropDownList suppliet = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("ddSupplier");
                        DropDownList paymode = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[9].FindControl("ddlPay");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtexpireddate");

                        TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtDisCount");
                        TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtDisCountAmount");

                        TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtbillingname");
                        TextBox txthsncode = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txthsncode");

                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtnarrations");
                        Label lblpoqty = (Label)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("lblpoqty");

                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblprimaryvalue");

                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtPQty");

                        Label lblstock = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblstock");


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
                            ddlIngregients.SelectedValue = dt.Rows[i]["IngredientID"].ToString();
                            billno.Text = dt.Rows[i]["BillNo"].ToString();
                            suppliet.SelectedValue = dt.Rows[i]["Supplier"].ToString();
                            paymode.SelectedItem.Text = dt.Rows[i]["Paymode"].ToString();
                            txtexpireddate.Text = dt.Rows[i]["ExpDate"].ToString();

                            txtnarrations.Text = dt.Rows[i]["Narrations"].ToString();
                            lblpoqty.Text = dt.Rows[i]["PoQty"].ToString();

                            txtDisCount.Text = dt.Rows[i]["DisCount"].ToString();
                            txtDisCountAmount.Text = dt.Rows[i]["DisCountAmnt"].ToString();

                            txtbillingname.Text = dt.Rows[i]["Bname"].ToString();
                            txthsncode.Text = dt.Rows[i]["HsnCode"].ToString();

                            ddlprimaryunits.SelectedValue = dt.Rows[i]["PUnits"].ToString();
                            lblprimaryvalue.Text = dt.Rows[i]["Pvalue"].ToString();
                            txtPQty.Text = dt.Rows[i]["PQty"].ToString();
                            lblstock.Text = dt.Rows[i]["stock"].ToString();

                            rowIndex++;
                        }
                        //ddlIngregients.Focus();
                        ddlIngregients.Enabled = true;
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


                    FirstGridViewRow();
                    SetPreviousData();
                }
            }


            #region

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
                        DropDownList ddlIngregients = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[1].FindControl("ddlDef");

                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtAmount");
                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlunits");
                        Label lblSubCat = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblDescriptionID");

                        Label lblunits = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblunits");

                        TextBox billno = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtBillNo");
                        DropDownList suppliet = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[8].FindControl("ddSupplier");
                        DropDownList paymode = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[9].FindControl("ddlPay");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtexpireddate");

                        TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtDisCount");
                        TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtDisCountAmount");

                        TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtbillingname");
                        TextBox txthsncode = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txthsncode");

                        Label lblpoqty = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblpoqty");
                        Label lblstock = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblstock");
                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtnarrations");

                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblprimaryvalue");

                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtPQty");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;



                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;

                        dtCurrentTable.Rows[i - 1]["PoQty"] = lblpoqty.Text;

                        dtCurrentTable.Rows[i - 1]["stock"] = lblstock.Text;

                        dtCurrentTable.Rows[i - 1]["Narrations"] = txtnarrations.Text;


                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;
                        dtCurrentTable.Rows[i - 1]["Supplier"] = suppliet.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Paymode"] = paymode.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["ExpDate"] = txtexpireddate.Text;

                        dtCurrentTable.Rows[i - 1]["DisCount"] = txtDisCount.Text;
                        dtCurrentTable.Rows[i - 1]["DisCountAmnt"] = txtDisCountAmount.Text;


                        dtCurrentTable.Rows[i - 1]["Bname"] = txtbillingname.Text;
                        dtCurrentTable.Rows[i - 1]["HsnCode"] = txthsncode.Text;

                        dtCurrentTable.Rows[i - 1]["PUnits"] = ddlprimaryunits.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Pvalue"] = lblprimaryvalue.Text;
                        dtCurrentTable.Rows[i - 1]["PQty"] = txtPQty.Text;

                        rowIndex++;
                        ddlIngregients.Focus();
                        ddlIngregients.Enabled = true;
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


        protected void btnSave_Click(object sender, EventArgs e)
        {


            #region
            int iq = 1;
            int ii = 1;
            string itemc = string.Empty;
            string itemcd = string.Empty;


            for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
            {
                DropDownList txti = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");

                DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");




                itemc = txti.Text;
                itemcd = ddlprimaryunits.Text;


                if ((itemc == null) || (itemc == "") && (itemcd == null) || (itemcd == ""))
                {
                }
                else
                {
                    for (int vLoop1 = 0; vLoop1 < gvcustomerorder.Rows.Count; vLoop1++)
                    {
                        DropDownList txt1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlDef");
                        DropDownList ddlprimaryunits1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlprimaryunits");
                        if (txt1.Text == "")
                        {
                        }
                        else if (ddlprimaryunits1.Text == "")
                        {
                        }
                        else
                        {

                            if (ii == iq)
                            {
                            }
                            else
                            {
                                if (itemc == txt1.Text && itemcd == ddlprimaryunits1.Text)
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
            //if (txtdcno.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Bill No.Thank You!!!.');", true);
            //    return;
            //}
            //if (chksupplier.Checked == false)
            //{
            //    if (ddlsuplier.SelectedValue == "Select Supplier")
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Supplier');", true);
            //        return;
            //    }
            //}
            //if (ddlpaymode.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Payment');", true);
            //    return;
            //}


            SetRowData();
            DataTable table = ViewState["CurrentTable"] as DataTable;

            if (table != null)
            {
                int bank = 0;
                string chequeno = "";
                int Supplier = 0;

                if (chksupplier.Checked == true)
                {
                    #region SUPPLIERDUPLICATE CHECK

                    DataSet dchk = kbs.duplicatecheckcustomercheck("MobileNo", txtmobileno.Text);
                    if (dchk.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Check Mobile no Already exists');", true);
                        return;
                    }
                    else
                    {
                        //DataSet dchk1 = kbs.duplicatecheckcustomercheck("LedgerName", txtsupplier.Text);
                        //if (dchk1.Tables[0].Rows.Count > 0)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Check Supplier Name Already exists');", true);
                        //    return;
                        //}
                        // CHECK CONTACT NAME
                        string str = txtsupplier.Text.Replace(" ", String.Empty);
                        DataSet dchkcontactname = kbs.chkconatctname(str);
                        if (dchkcontactname.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Supplier Name Already Exists.Thank you!!!.');", true);
                            return;
                        }
                    }

                    if (txtgstno.Text == "Nil")
                    {
                    }
                    else
                    {
                        DataSet dgstcheck = kbs.duplicatecheckcustomercheck("Gstno", txtgstno.Text);
                        if (dgstcheck.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Gst No Already Exists.Thank you!!!.');", true);
                            return;
                        }
                    }

                    #endregion


                    #region INSERT NEW SUPPLIER
                    int GroupId = 0;
                    {
                        GroupId = 6;
                    }

                    int LedgerId = kbs.insertcontact(Convert.ToInt32(lblUserID.Text), txtsupplier.Text, txtmobileno.Text, "0", "", txtaddress.Text, txtcity.Text, "0", "test@gmail.com", Convert.ToInt32(6), GroupId, "0", txtgstno.Text,"0","","",0,0,0,"Credit Note", "Inner");

                    Supplier = LedgerId;

                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                        DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                        if (ddldef.SelectedValue != "Select IngredientName")
                        {


                            TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[i].FindControl("txtbillingname");
                            TextBox txthsncode = (TextBox)gvcustomerorder.Rows[i].FindControl("txthsncode");
                            TextBox txttax = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");


                            int LedgerIngredient = kbs.InsertLedgerIngredient(Supplier, Convert.ToInt32(ddldef.SelectedValue), txtbillingname.Text);
                            #region Tax

                            int TaxID = 0;
                            DataSet dsTax = kbs.getTAXupload(txttax.Text.Replace(" ", ""));
                            if (dsTax.Tables[0].Rows.Count > 0)
                            {
                                TaxID = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                            }
                            else
                            {
                                int iStatus = kbs.InsertTax(txttax.Text.Replace(" ", ""), "Yes", "", "");
                                DataSet dsTax1 = kbs.getTAXupload(txttax.Text.Replace(" ", ""));
                                TaxID = Convert.ToInt32(dsTax1.Tables[0].Rows[0]["Taxid"].ToString());
                            }
                            #endregion
                            //Update hsncode in Ingredent

                            int uingre = kbs.updatehsncode(ddldef.SelectedValue, txthsncode.Text, txttax.Text, TaxID.ToString());

                        }
                    }

                    #endregion
                }
                else
                {
                    Supplier = Convert.ToInt32(0);


                    //for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    //{
                    //    TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                    //    DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                    //    if (ddldef.SelectedValue != "Select IngredientName")
                    //    {


                    //        TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[i].FindControl("txtbillingname");
                    //        TextBox txthsncode = (TextBox)gvcustomerorder.Rows[i].FindControl("txthsncode");
                    //        TextBox txttax = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");


                    //        int LedgerIngredient = kbs.InsertLedgerIngredient(Supplier, Convert.ToInt32(ddldef.SelectedValue), txtbillingname.Text);
                    //        #region Tax

                    //        int TaxID = 0;
                    //        DataSet dsTax = kbs.getTAXupload(txttax.Text.Replace(" ", ""));
                    //        if (dsTax.Tables[0].Rows.Count > 0)
                    //        {
                    //            TaxID = Convert.ToInt32(dsTax.Tables[0].Rows[0]["Taxid"].ToString());
                    //        }
                    //        else
                    //        {
                    //            int iStatus = kbs.InsertTax(txttax.Text.Replace(" ", ""), "Yes", "", "");
                    //            DataSet dsTax1 = kbs.getTAXupload(txttax.Text.Replace(" ", ""));
                    //            TaxID = Convert.ToInt32(dsTax1.Tables[0].Rows[0]["Taxid"].ToString());
                    //        }
                    //        #endregion
                    //        //Update hsncode in Ingredent

                    //        int uingre = kbs.updatehsncode(ddldef.SelectedValue, txthsncode.Text, txttax.Text, TaxID.ToString());

                    //    }
                    //}

                }





                if (Button1.Text == "Save")
                {
                    #region

                    if (ddlpaymode.SelectedValue == "1" || ddlpaymode.SelectedValue == "2")
                    {
                        bank = 0;
                        chequeno = "000000";
                    }
                    else
                    {
                        //if (ddlbank.SelectedValue == "Select Bank")
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Bank');", true);
                        //    return;
                        //}

                        //if (txtcheque.Text == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Enter ChequeNo');", true);
                        //    return;
                        //}

                        bank = Convert.ToInt32(0);
                        chequeno = txtcheque.Text;
                    }

                    int CreditorID1 = 0;
                    if (ddlpaymode.SelectedValue == "2") //Credit
                    {
                        CreditorID1 = Convert.ToInt32(Supplier);
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
                    DataSet dsledger1 = kbs.getCashledgerId123("PurchaseA/C_" + sTableName);
                    if (dsledger1.Tables[0].Rows.Count > 0)
                    {

                        ledgerid = dsledger1.Tables[0].Rows[0]["LedgerID"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('PurchaseA/C Does not Exists in Table');", true);
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
                        BillingType = "Purchase Order";
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


                    DateTime Date = DateTime.ParseExact(txtsdate1.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);


                    int insertPurchase = kbs.insertSales(sTableName, Convert.ToInt32(ledgerid), Convert.ToInt32(CreditorID1), txtbillno.Text, Date, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(Supplier), Convert.ToInt32(ddlpaymode.SelectedValue), bank, chequeno, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), BillingType, PONo, Province, Convert.ToDouble(txtDiscountAmount.Text), Convert.ToDouble(txtFreightCharge.Text), Convert.ToDouble(txtFreightChargeTax.Text), Convert.ToInt32(ddltax.SelectedValue), Convert.ToDouble(ddltax.SelectedItem.Text), Convert.ToDouble(txtroundoff.Text), drpitemchnage.SelectedValue, drpitemload.SelectedValue);


                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                        DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                        if (ddldef.SelectedValue != "Select IngredientName")
                        {

                            string ingre = ddldef.SelectedItem.Text;
                            int idef = Convert.ToInt32(ddldef.SelectedValue);

                            TextBox Qty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            decimal dQty = Convert.ToDecimal(Qty.Text);

                            TextBox Rate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                            decimal DRate = Convert.ToDecimal(Rate.Text);
                            DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlunits");

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

                            DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlprimaryunits");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");

                            if (ddldef.SelectedValue == "Select IngredientName")
                            {

                            }
                            if (ddlunits.SelectedValue == "Select")
                            {

                            }
                            if (ddlprimaryunits.SelectedValue == "Select PrimaryUom")
                            {

                            }
                            else
                            {
                                int Transpurchase = kbs.insertTransSales(sTableName, insertPurchase, idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, txtnarrations.Text, Convert.ToDouble(txtDisCount.Text), Convert.ToDouble(txtDisCountAmount.Text), ddlprimaryunits.SelectedValue, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text));

                                //if (BillingType == "Purchase Order")
                                //{
                                //    int iSucess = kbs.UpdatePOSTk(PONo, sTableName, dQty, idef);
                                //}
                            }
                        }
                    }

                    //if (BillingType == "Purchase Order")
                    //{
                    //    int iSucess = kbs.UpdatePOSTkStatus(PONo, sTableName);
                    //}

                    #endregion

                    Response.Redirect("Sales_grid.aspx");
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

                    DataSet dsledger1 = kbs.getCashledgerId123("PurchaseA/C_" + sTableName);
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
                        BillingType = "Purchase Order";
                        PONo = Convert.ToInt32(drpPO.SelectedValue);
                    }

                    int insertPurchase = kbs.updatePurchase(sTableName, txtbillno.Text, txtsdate1.Text, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), iSalesID, bank, chequeno, CreditorID1, ledgerid, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), txteditnarrations.Text, Province, Convert.ToDouble(txtDiscountAmount.Text), Convert.ToDouble(txtFreightCharge.Text), Convert.ToDouble(txtFreightChargeTax.Text), Convert.ToInt32(ddltax.SelectedValue), Convert.ToDouble(ddltax.SelectedItem.Text), Convert.ToDouble(txtroundoff.Text));
                    int trans1 = kbs.getduplisttrans123(iSalesID, sTableName);

                    int transdelete = kbs.getduplisttransdelete(iSalesID, sTableName);

                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                        DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                        if (ddldef.SelectedValue != "Select IngredientName")
                        {


                            string ingre = ddldef.SelectedItem.Text;
                            int idef = Convert.ToInt32(ddldef.SelectedValue);

                            TextBox Qty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                            decimal dQty = Convert.ToDecimal(Qty.Text);

                            TextBox Rate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                            decimal DRate = Convert.ToDecimal(Rate.Text);
                            DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlunits");

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

                            DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlprimaryunits");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");

                            if (ddldef.SelectedValue == "Select IngredientName")
                            {

                            }
                            if (ddlunits.SelectedValue == "Select")
                            {

                            }
                            if (ddlprimaryunits.SelectedValue == "Select PrimaryUom")
                            {

                            }
                            else
                            {
                                int Transpurchase = kbs.insertTransPurchase(sTableName, Convert.ToInt32(iSalesID), idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, txtnarrations.Text, Convert.ToDouble(txtDisCount.Text), Convert.ToDouble(txtDisCountAmount.Text), ddlprimaryunits.SelectedValue, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text));
                            }
                        }


                    }

                    #endregion

                    Response.Redirect("Purchase_invGrid.aspx");
                }
            }




        }

        protected void txtFreightCharge_OnTextChanged(object sender, EventArgs e)
        {
            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
            txttotal.Text = GrndTotal.ToString("f2");

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

            ddltax.Focus();
        }
        protected void ddltax_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
            txttotal.Text = GrndTotal.ToString("f2");

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

        protected void txtdefQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox DisCount = (TextBox)row.FindControl("txtDisCount");

            DropDownList ddlprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");

            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            TextBox PQty = (TextBox)row.FindControl("txtPQty");

            if (ddlprimaryunits.SelectedValue == "Select PrimaryUom")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Primary Uom.');", true);
                return;
            }

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

            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
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
        protected void txtDisCountAmount_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox DisCount = (TextBox)row.FindControl("txtDisCount");
            TextBox DisCountAmount = (TextBox)row.FindControl("txtDisCountAmount");

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

            if (DisCountAmount.Text == "")
                DisCountAmount.Text = "0";

            decimal dAmount = 0;
            decimal tax = 0;
            decimal Disc = 0;
            decimal DiscB = 0;
            decimal DiscAmnt = 0;

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(Qty.Text);
            decimal DRate = Convert.ToDecimal(Rate.Text);

            decimal DDisCountAmnt = Convert.ToDecimal(DisCountAmount.Text);

            dAmount = dQty * DRate;

            DiscAmnt = dAmount - DDisCountAmnt;

            DiscB = ((DDisCountAmnt * 100) / dAmount);

            DisCount.Text = DiscB.ToString("0.00");
            decimal DDisCount = Convert.ToDecimal(DisCount.Text);

            //  Disc = (dAmount * DDisCount) / 100;

            //DisCountAmount.Text = Disc.ToString("0.00");

            tax = ((DiscAmnt) * Convert.ToDecimal(txttax.Text) / 100);

            decimal amt = (DiscAmnt) + tax;

            Amount.Text = amt.ToString("f2");

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

            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
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

            txttax.Focus();
        }
        protected void txtDisCount_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox DisCount = (TextBox)row.FindControl("txtDisCount");
            TextBox DisCountAmount = (TextBox)row.FindControl("txtDisCountAmount");

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

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(Qty.Text);
            decimal DRate = Convert.ToDecimal(Rate.Text);
            decimal DDisCount = Convert.ToDecimal(DisCount.Text);

            dAmount = dQty * DRate;

            Disc = (dAmount * DDisCount) / 100;

            DisCountAmount.Text = Disc.ToString("0.00");

            tax = ((dAmount - Disc) * Convert.ToDecimal(txttax.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            Amount.Text = amt.ToString("f2");

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

            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
            txttotal.Text = GrndTotal.ToString("f2");

            #endregion

            txttax.Focus();
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
        protected void txtBillNo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox DisCount = (TextBox)row.FindControl("txtDisCount");

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

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(Qty.Text);
            decimal DRate = Convert.ToDecimal(Rate.Text);
            decimal DDisCount = Convert.ToDecimal(DisCount.Text);

            dAmount = dQty * DRate;

            Disc = (dAmount * DDisCount) / 100;

            tax = ((dAmount - Disc) * Convert.ToDecimal(txttax.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            Amount.Text = amt.ToString("f2");

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

            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
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

            Rate.Focus();
        }
        protected void txtdefCatID_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow row = (GridViewRow)txt.NamingContainer;

            TextBox Qty = (TextBox)row.FindControl("txtQty");
            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");
            TextBox DisCount = (TextBox)row.FindControl("txtDisCount");

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

            lblError.Visible = false;
            Button1.Enabled = true;


            decimal dQty = Convert.ToDecimal(Qty.Text);
            decimal DRate = Convert.ToDecimal(Rate.Text);
            decimal DDisCount = Convert.ToDecimal(DisCount.Text);

            dAmount = dQty * DRate;

            Disc = (dAmount * DDisCount) / 100;

            tax = ((dAmount - Disc) * Convert.ToDecimal(txttax.Text) / 100);

            decimal amt = (dAmount - Disc) + tax;

            Amount.Text = amt.ToString("f2");

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

            if (txtFreightCharge.Text == "")
                txtFreightCharge.Text = "0";

            decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
            txtFreightChargeTax.Text = Tax.ToString("f2");

            decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
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

            TextBox txtexpireddate = (TextBox)txt.FindControl("txtexpireddate");
            txtexpireddate.Focus();

        }

        protected void rbtype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtype.SelectedValue == "1")
            {
                Div2.Visible = false;
                Div3.Visible = false;
                chksupplier.Enabled = true;
                chksupplier.Checked = false;
                chk_chksupplier(sender, e);
                ddlsuplier.Enabled = true;
            }
            else
            {
                Div2.Visible = true;
                Div3.Visible = true;
                chksupplier.Checked = false;
                chk_chksupplier(sender, e);
                chksupplier.Enabled = false;
                ddlsuplier.Enabled = false;


            }
        }





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
            string itemname = drpitemchnage.SelectedItem.Text;
            int supplier = 0;
            if (chksupplier.Checked == true)
            {
                supplier = 0;
            }
            else
            {
                supplier = Convert.ToInt32(0);
            }


            DataSet dsCategory = kbs.GetSupplierIngredient(Convert.ToInt32(supplier), drpitemload.SelectedValue);
            DataSet dunitsval = new DataSet();
            DataSet dunits = kbs.UNITS();
            DataSet dprimary = kbs.PrimaryUNITS();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region

                DropDownList ddlunits = (DropDownList)(e.Row.FindControl("ddlunits") as DropDownList);
                DropDownList ddlprimaryunits = (DropDownList)(e.Row.FindControl("ddlprimaryunits") as DropDownList);
                DropDownList ddIngredients = (DropDownList)(e.Row.FindControl("ddlDef") as DropDownList);
                Label lblunits = (Label)(e.Row.FindControl("lblunits") as Label);

                ddIngredients.Focus();
                ddIngredients.Enabled = true;

                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddIngredients.DataSource = dsCategory.Tables[0];
                    ddIngredients.DataTextField = itemname;
                    ddIngredients.DataValueField = "IngridID";
                    ddIngredients.DataBind();
                    ddIngredients.Items.Insert(0, "Select IngredientName");
                }
                if (dunits.Tables[0].Rows.Count > 0)
                {
                    ddlunits.DataSource = dunits.Tables[0];
                    ddlunits.DataTextField = "UOM";
                    ddlunits.DataValueField = "UOMID";
                    ddlunits.DataBind();
                }

                if (dprimary.Tables[0].Rows.Count > 0)
                {
                    ddlprimaryunits.DataSource = dprimary.Tables[0];
                    ddlprimaryunits.DataTextField = "Primaryname";
                    ddlprimaryunits.DataValueField = "PrimaryUOMID";
                    ddlprimaryunits.DataBind();
                    ddlprimaryunits.Items.Insert(0, "Select PrimaryUom");
                }

                //////if (ddIngredients.SelectedValue != "Select IngredientName")
                //////{
                //////    dunitsval = kbs.GetIngredientVal(Convert.ToInt32(ddIngredients.SelectedValue));
                //////    if (dunits.Tables[0].Rows.Count > 0)
                //////    {
                //////        ddlunits.SelectedValue = dunitsval.Tables[0].Rows[0]["Units"].ToString();
                //////        lblunits.Text = ddlunits.SelectedItem.Text;

                //////    }
                //////}

                #endregion
            }
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

                DataSet dagent = kbs.getPOlist(drpPO.SelectedValue, sTableName);
                if (dagent.Tables[0].Rows.Count > 0)
                {
                    //shwedit.Visible = true;
                    //   txtbillno.Text = dagent.Tables[0].Rows[0]["Orderno"].ToString();
                    // txtdcno.Text = dagent.Tables[0].Rows[0]["DCNo"].ToString();
                    lblpurchase.InnerText = dagent.Tables[0].Rows[0]["Orderno"].ToString();

                    //  txtsdate1.Text = Convert.ToDateTime(dagent.Tables[0].Rows[0]["OrderDate"]).ToString("dd/MM/yyyy"); // dagent.Tables[0].Rows[0]["OrderDate"].ToString("yyyy-MM-dd");

                    ddlsuplier.SelectedValue = dagent.Tables[0].Rows[0]["Supplier"].ToString();

                    ddlpaymode.SelectedValue = dagent.Tables[0].Rows[0]["Paymode"].ToString();

                    if (dagent.Tables[0].Rows[0]["Paymode"].ToString() == "1")
                    {
                        ddlbank.Enabled = false;
                        txtcheque.Enabled = false;
                    }
                    else
                    {
                        ddlbank.Enabled = true;
                        txtcheque.Enabled = true;
                    }

                    if (dagent.Tables[0].Rows[0]["Province"].ToString() == "Inner")
                    {
                        rbdpurchasetype.SelectedValue = "1";
                    }
                    else
                    {
                        rbdpurchasetype.SelectedValue = "2";
                    }
                    txtSubTotal.Text = dagent.Tables[0].Rows[0]["SubTotal"].ToString();
                    txttotal.Text = dagent.Tables[0].Rows[0]["Total"].ToString();
                    txtcgst.Text = dagent.Tables[0].Rows[0]["CGST"].ToString();
                    txtsgst.Text = dagent.Tables[0].Rows[0]["SGST"].ToString();
                    txtigst.Text = dagent.Tables[0].Rows[0]["IGST"].ToString();

                    ddlbank.SelectedValue = dagent.Tables[0].Rows[0]["Bank"].ToString();
                    txtcheque.Text = dagent.Tables[0].Rows[0]["ChequeNo"].ToString();
                    // Button1.Text = "update";

                    DataSet transpur = kbs.getpotranslist(drpPO.SelectedValue, sTableName);


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

                    dct = new DataColumn("BillNo");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Supplier");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Paymode");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("ExpDate");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("PoQty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Narrations");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("DisCount");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("DisCountAmnt");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Bname");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Hsncode");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("PUnits");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Pvalue");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("PQty");
                    dttt.Columns.Add(dct);


                    dstd.Tables.Add(dttt);

                    foreach (DataRow dr in transpur.Tables[0].Rows)
                    {

                        drNew = dttt.NewRow();
                        drNew["sno"] = 0;
                        drNew["Ingredient"] = dr["IngredientID"];
                        drNew["IngredientID"] = dr["IngredientID"];
                        drNew["Qty"] = Convert.ToInt32(dr["Qty"]) - Convert.ToInt32(dr["PQty"]);
                        drNew["Rate"] = dr["Rate"];
                        drNew["Amount"] = dr["Amount"];
                        drNew["Units"] = dr["Units"];
                        drNew["BillNo"] = dr["BillNo"];
                        drNew["Supplier"] = 0;
                        drNew["Paymode"] = 0;

                        drNew["PoQty"] = dr["Qty"];
                        drNew["Narrations"] = "";

                        drNew["ExpDate"] = dr["ExpiryDate"];

                        drNew["DisCount"] = "0";
                        drNew["DisCountAmnt"] = "0";

                        drNew["Bname"] = "0";
                        drNew["Hsncode"] = "0";

                        drNew["PUnits"] = dr["Punitsid"];
                        drNew["Pvalue"] = dr["Pvalue"];
                        drNew["PQty"] = dr["PUqty"];

                        dstd.Tables[0].Rows.Add(drNew);
                    }
                    ViewState["CurrentTable"] = dttt;

                    gvcustomerorder.DataSource = dstd;
                    gvcustomerorder.DataBind();

                    for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
                    {
                        TextBox txtsno = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsno");
                        DropDownList ddlDef = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlDef");
                        Label lblDescriptionID = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblDescriptionID");
                        Label lblunits = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblunits");

                        TextBox txtQty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtQty");
                        TextBox txtRate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtRate");
                        TextBox txtAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtAmount");
                        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlunits");
                        TextBox txtBillNo = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtBillNo");
                        TextBox txtsupplier = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtsupplier");
                        DropDownList ddlPay = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlPay");
                        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtexpireddate");

                        TextBox txtDisCount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCount");
                        TextBox txtDisCountAmount = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtDisCountAmount");

                        Label lblpoqty = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblpoqty");
                        TextBox txtnarrations = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtnarrations");

                        TextBox txtbillingname = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtbillingname");
                        TextBox txthsncode = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txthsncode");


                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryvalue");

                        TextBox txtpqty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtpqty");

                        txtsno.Text = (vLoop + 1).ToString();

                        lblpoqty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                        txtnarrations.Text = dstd.Tables[0].Rows[vLoop]["Narrations"].ToString();

                        ddlDef.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                        lblDescriptionID.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                        txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                        txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString();
                        txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString();
                        ddlunits.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Units"]).ToString();
                        lblunits.Text = ddlunits.SelectedItem.Text;
                        //////  txtBillNo.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString(); 

                        txtDisCount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCount"]).ToString("f2");
                        txtDisCountAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["DisCountAmnt"]).ToString("f2");

                        txtBillNo.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString("f2");
                        txtsupplier.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Supplier"]).ToString();
                        ddlPay.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Paymode"]).ToString();
                        txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");
                        if (txtexpireddate.Text == "01/01/1900")
                        {
                            txtexpireddate.Text = "";
                        }

                        ddlprimaryunits.SelectedValue = dstd.Tables[0].Rows[vLoop]["PUnits"].ToString();
                        lblprimaryvalue.Text = dstd.Tables[0].Rows[vLoop]["Pvalue"].ToString();
                        txtpqty.Text = dstd.Tables[0].Rows[vLoop]["PQty"].ToString();


                        DataSet dss = kbs.getingreUnits(ddlDef.SelectedValue, ddlsuplier.SelectedValue, drpitemload.SelectedValue);
                        if (dss.Tables[0].Rows.Count > 0)
                        {

                            if (drpitemchnage.SelectedValue == "1")
                            {
                                txtbillingname.Text = dss.Tables[0].Rows[0]["BIngredientName"].ToString();
                            }
                            else
                            {
                                txtbillingname.Text = dss.Tables[0].Rows[0]["IngredientName"].ToString();
                            }
                            txthsncode.Text = dss.Tables[0].Rows[0]["HsnCode"].ToString();
                        }
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



                #endregion

                #region FreightCharge

                if (txtFreightCharge.Text == "")
                    txtFreightCharge.Text = "0";

                decimal Tax = (Convert.ToDecimal(txtFreightCharge.Text) * Convert.ToDecimal(ddltax.SelectedItem.Text)) / 100;
                txtFreightChargeTax.Text = Tax.ToString("f2");

                decimal GrndTotal = (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtcgst.Text) + Convert.ToDecimal(txtsgst.Text) + Convert.ToDecimal(txtigst.Text) + Convert.ToDecimal(txtFreightCharge.Text) + Tax);
                txttotal.Text = GrndTotal.ToString("f2");

                #endregion

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
        }

        protected void ddlpaymode_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpaymode.SelectedValue == "1" || ddlpaymode.SelectedValue == "2")
            {
                ddlbank.Enabled = false;
                txtcheque.Enabled = false;
            }
            else
            {
                ddlbank.Enabled = true;
                txtcheque.Enabled = true;
            }
            ddlpaymode.Focus();
        }

        protected void drpprimary_unit(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");
            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            TextBox PQty = (TextBox)row.FindControl("txtPQty");
            if (ddlprimaryunits.SelectedValue != "Select PrimaryUom")
            {
                DataSet dss = kbs.getPrimaryUNITSvalue(ddlprimaryunits.SelectedValue);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblprimaryvalue.Text = Convert.ToDouble(dss.Tables[0].Rows[0]["Primaryvalue"]).ToString("0.00");
                }

                if (txtQty.Text == "0" || txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }
                else
                {
                    PQty.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(lblprimaryvalue.Text)).ToString("0.00");
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

                DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");




                itemc = txti.Text;
                itemcd = ddlprimaryunits.Text;


                if ((itemc == null) || (itemc == "") && (itemcd == null) || (itemcd == ""))
                {
                }
                else
                {
                    for (int vLoop1 = 0; vLoop1 < gvcustomerorder.Rows.Count; vLoop1++)
                    {
                        DropDownList txt1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlDef");
                        DropDownList ddlprimaryunits1 = (DropDownList)gvcustomerorder.Rows[vLoop1].FindControl("ddlprimaryunits");
                        if (txt1.Text == "")
                        {
                        }
                        else if (ddlprimaryunits1.Text == "")
                        {
                        }
                        else
                        {

                            if (ii == iq)
                            {
                            }
                            else
                            {
                                if (itemc == txt1.Text && itemcd == ddlprimaryunits1.Text)
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


            int supplier = 0;
            if (chksupplier.Checked == true)
            {
                supplier = 0;
            }
            else
            {
                supplier = Convert.ToInt32(0);
            }


            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            DropDownList ddlDef = (DropDownList)row.FindControl("ddlDef");
            DropDownList ddlprimaryunitss = (DropDownList)row.FindControl("ddlprimaryunits");

            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");

            Label lblstock = (Label)row.FindControl("lblstock");

            TextBox PQty = (TextBox)row.FindControl("txtPQty");

            TextBox txtQty = (TextBox)row.FindControl("txtQty");

            DataSet dss = kbs.getingreUnits(ddlDef.SelectedValue, supplier.ToString(), drpitemload.SelectedValue);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Label lblunits = (Label)row.FindControl("lblunits");
                lblunits.Text = dss.Tables[0].Rows[0]["UOM"].ToString();

                TextBox txtBillNo = (TextBox)row.FindControl("txtBillNo");
                txtBillNo.Text = dss.Tables[0].Rows[0]["TaxValue"].ToString();


                txtQty.Focus();

                DataSet dstock = kbs.InserttransrawitemacceptCheck(sTableName, ddlDef.SelectedValue);
                if (dstock.Tables[0].Rows.Count > 0)
                {
                    lblstock.Text = Convert.ToDouble(dstock.Tables[0].Rows[0]["Qty"]).ToString("0.00");
                }
                else
                {
                    lblstock.Text = "0";
                }


                TextBox txtbillingname = (TextBox)row.FindControl("txtbillingname");
                if (drpitemchnage.SelectedValue == "1")
                {
                    txtbillingname.Text = dss.Tables[0].Rows[0]["BIngredientName"].ToString();
                }
                else
                {
                    txtbillingname.Text = dss.Tables[0].Rows[0]["IngredientName"].ToString();
                }
                TextBox txthsncode = (TextBox)row.FindControl("txthsncode");
                txthsncode.Text = dss.Tables[0].Rows[0]["HsnCode"].ToString();

            }

            if (ddlprimaryunitss.SelectedValue == "Select PrimaryUom")
            {

            }
            else
            {
                if (txtQty.Text == "0" || txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }

                PQty.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(lblprimaryvalue.Text)).ToString("0.00");
            }
        }

        protected void ddlsuplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvcustomerorder.DataSource = null;
            gvcustomerorder.DataBind();
            ViewState["CurrentTable"] = null;



            if (ddlsuplier.SelectedValue == "" || ddlsuplier.SelectedValue == "0" || ddlsuplier.SelectedValue == "Select Supplier")
            {

            }
            else
            {

                // GEtting Information
                DataSet dsupplier = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
                if (dsupplier.Tables[0].Rows.Count > 0)
                {

                    txtmobileno.Text = dsupplier.Tables[0].Rows[0]["mobileno"].ToString();
                    txtaddress.Text = dsupplier.Tables[0].Rows[0]["address"].ToString();
                    txtcity.Text = dsupplier.Tables[0].Rows[0]["city"].ToString();
                    txtgstno.Text = dsupplier.Tables[0].Rows[0]["gstno"].ToString();

                }


                FirstGridViewRow();
            }
        }

    }
}