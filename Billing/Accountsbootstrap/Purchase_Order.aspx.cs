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
    public partial class Purchase_Order : System.Web.UI.Page
    {
        string sTableName = "";
        string scode = "";
        BSClass kbs = new BSClass();
        string Rate = "";
        string porights = "";
        string Biller = "";
        string Billerid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Rate = Request.Cookies["userInfo"]["Rate"].ToString();
            porights = Request.Cookies["userinfo"]["poorderrights"].ToString();

            Biller = Request.Cookies["userInfo"]["Biller"].ToString();
            Billerid = Request.Cookies["userInfo"]["Empid"].ToString();


            lblbillername.Text = Biller;
            lblbillerid.Text = Billerid;

            if (!Page.IsPostBack)
            {
                DataSet ds = kbs.getPO_NO("tblkitchenPurchaseorder_" + sTableName);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Orderno"].ToString() == "")
                        {
                            txtdcno.Text = "1";
                        }
                        else
                        {
                            txtdcno.Text = ds.Tables[0].Rows[0]["Orderno"].ToString();
                        }
                    }
                }

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

                DataSet dssubcompany = kbs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    drpsubcompany.DataSource = dssubcompany.Tables[0];
                    drpsubcompany.DataTextField = "CustomerName1";
                    drpsubcompany.DataValueField = "subComapanyID";
                    drpsubcompany.DataBind();
                    drpsubcompany.Items.Insert(0, "Select Company");


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
                DataSet Paymode = kbs.GetOthersPaymode();
                if (Paymode.Tables[0].Rows.Count > 0)
                {
                    ddlpaymode.DataSource = Paymode.Tables[0];
                    ddlpaymode.DataTextField = "Paymode";
                    ddlpaymode.DataValueField = "Value";
                    ddlpaymode.DataBind();
                    ddlpaymode.Items.Insert(0, "Select Paymode");
                }

                DataSet dNo = kbs.orderentryno(sTableName);
                txtbillno.Text = dNo.Tables[0].Rows[0]["billno"].ToString();

                txtsdate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Button1.Text = "Save";

                // FirstGridViewRow();

                string iSalesID = Request.QueryString.Get("OrderNo");
                if (iSalesID != null)
                {
                    #region

                    DataSet dagent = kbs.getPOlist(iSalesID, sTableName);
                    if (dagent.Tables[0].Rows.Count > 0)
                    {
                        shwedit.Visible = true;
                        txtbillno.Text = dagent.Tables[0].Rows[0]["Orderno"].ToString();
                        txtdcno.Text = dagent.Tables[0].Rows[0]["DCNo"].ToString();
                        lblpurchase.InnerText = dagent.Tables[0].Rows[0]["Orderno"].ToString();

                        txtsdate1.Text = Convert.ToDateTime(dagent.Tables[0].Rows[0]["OrderDate"]).ToString("dd/MM/yyyy");

                        ddlsuplier.SelectedValue = dagent.Tables[0].Rows[0]["Supplier"].ToString();
                        drpsubcompany.SelectedValue = dagent.Tables[0].Rows[0]["Companyid"].ToString();

                        DataSet dsupplier = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
                        if (dsupplier.Tables[0].Rows.Count > 0)
                        {
                            txtaddress.Text = dsupplier.Tables[0].Rows[0]["address"].ToString() + "," + dsupplier.Tables[0].Rows[0]["area"].ToString() + "," + dsupplier.Tables[0].Rows[0]["city"].ToString() + "," + dsupplier.Tables[0].Rows[0]["pincode"].ToString();
                        }

                        ddlpaymode.SelectedValue = dagent.Tables[0].Rows[0]["Paymode"].ToString();
                        ddlpaymode_OnSelectedIndexChanged(sender, e);
                        //if (dagent.Tables[0].Rows[0]["Paymode"].ToString() == "1")
                        //{
                        //    ddlbank.Enabled = false;
                        //    txtcheque.Enabled = false;
                        //}
                        //else
                        //{
                        //    ddlbank.Enabled = true;
                        //    txtcheque.Enabled = true;
                        //}
                        txtdcno.Enabled = false;

                        txtSubTotal.Text = dagent.Tables[0].Rows[0]["SubTotal"].ToString();
                        txttotal.Text = dagent.Tables[0].Rows[0]["Total"].ToString();
                        txtcgst.Text = dagent.Tables[0].Rows[0]["CGST"].ToString();
                        txtsgst.Text = dagent.Tables[0].Rows[0]["SGST"].ToString();
                        txtigst.Text = dagent.Tables[0].Rows[0]["IGST"].ToString();

                        ddlbank.SelectedValue = dagent.Tables[0].Rows[0]["Bank"].ToString();
                        txtcheque.Text = dagent.Tables[0].Rows[0]["ChequeNo"].ToString();
                        Button1.Text = "update";

                        DataSet transpur = kbs.getpotranslist(iSalesID, sTableName);


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
                            drNew["Qty"] = dr["Qty"];
                            drNew["Rate"] = dr["Rate"];
                            drNew["Amount"] = dr["Amount"];
                            drNew["Units"] = dr["Units"];
                            drNew["BillNo"] = dr["BillNo"];
                            drNew["Supplier"] = 0;
                            drNew["Paymode"] = 0;
                            drNew["ExpDate"] = dr["ExpiryDate"];

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

                            DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtpqty");


                            txtsno.Text = (vLoop + 1).ToString();
                            ddlDef.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                            lblDescriptionID.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                            txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                            txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString();
                            txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString();
                            ddlunits.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Units"]).ToString();
                            lblunits.Text = ddlunits.SelectedItem.Text;
                            //////  txtBillNo.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString(); Convert.ToDateTime(ds1.Tables[0].Rows[0]["Bill_date"]).ToString("dd/MM/yyyy");

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
                        }
                    }

                    #endregion
                }

            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
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

            dt.Columns.Add(new DataColumn("PUnits", typeof(string)));
            dt.Columns.Add(new DataColumn("Pvalue", typeof(string)));
            dt.Columns.Add(new DataColumn("PQty", typeof(string)));


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

            dr["PUnits"] = string.Empty;
            dr["Pvalue"] = string.Empty;
            dr["PQty"] = string.Empty;

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


                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblprimaryvalue");
                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtPQty");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;


                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;
                        

                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;

                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;


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

                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblprimaryvalue");

                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtPQty");
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


                            ddlprimaryunits.SelectedValue = dt.Rows[i]["PUnits"].ToString();
                            lblprimaryvalue.Text = dt.Rows[i]["Pvalue"].ToString();
                            txtPQty.Text = dt.Rows[i]["PQty"].ToString();

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

                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[rowIndex].Cells[2].FindControl("lblprimaryvalue");

                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[rowIndex].Cells[3].FindControl("txtPQty");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;



                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;

                        

                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;
                        dtCurrentTable.Rows[i - 1]["Supplier"] = suppliet.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Paymode"] = paymode.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["ExpDate"] = txtexpireddate.Text;

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
            string POStatus = "";

            if(porights == "Y")
            {
                POStatus = "YES";
            }
            else
            {
                POStatus = "NO";
            }

            if(drpsubcompany.SelectedValue == "Select Company")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Company Name.Thank You!!!.');", true);
                return;
            }

            if (txtdcno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Order No.Thank You!!!.');", true);
                return;
            }

            if (ddlsuplier.SelectedValue == "Select Supplier")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Supplier');", true);
                return;
            }
            if (ddlpaymode.SelectedValue == "Select Paymode")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Payment');", true);
                return;
            }


            SetRowData();
            DataTable table = ViewState["CurrentTable"] as DataTable;

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
                    if (ddlpaymode.SelectedValue == "2" || ddlpaymode.SelectedValue == "18") //Credit
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
                    string Province;
                    if (rbdpurchasetype.SelectedValue == "1")
                    {
                        Province = "Inner";
                    }
                    else
                    {
                        Province = "Outer";
                    }

                    DateTime Date = DateTime.ParseExact(txtsdate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    int insertPurchase = kbs.insertPurchaseOrder(sTableName, Convert.ToInt32(ledgerid), Convert.ToInt32(CreditorID1), txtdcno.Text, Date, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), bank, chequeno, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), Province,drpsubcompany.SelectedValue, POStatus, lblbillername.Text,lblbillerid.Text);





                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                        if (Amount.Text != "")
                        {

                            DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
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
                                int Transpurchase = kbs.insertTransPurchaseorder(sTableName, insertPurchase, idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text,ddlprimaryunits.SelectedValue,Convert.ToDouble(lblprimaryvalue.Text),Convert.ToDouble(txtpqty.Text));
                            }
                        }


                    }


                    #endregion

                    Response.Redirect("Purchase_OrderGrid.aspx");
                }
                else
                {
                    if (txteditnarrations.Text == "" || txteditnarrations.Text == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Edit Narrations.Thank You!!!.');", true);
                        return;
                    }


                    #region

                    string iSalesID = Request.QueryString.Get("OrderNo");


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


                    DateTime Date = DateTime.ParseExact(txtsdate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    int insertPurchase = kbs.UpdatePurchaseOrder(sTableName, Convert.ToInt32(ledgerid), Convert.ToInt32(CreditorID1), txtdcno.Text, Date, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), bank, chequeno, txtcgst.Text, txtsgst.Text, txtigst.Text, iSalesID, Convert.ToInt32(lblUserID.Text), Province,drpsubcompany.SelectedValue);

                    DataSet dspurchaseorderID = kbs.GettransPpurchaseid(sTableName, Convert.ToInt32(iSalesID));


                    int transdelete = kbs.getduplisttransdelete(dspurchaseorderID.Tables[0].Rows[0]["purchaseorderID"].ToString(), sTableName);

                    for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    {
                        TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                        if (Amount.Text != "")
                        {

                            DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
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

                            DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlprimaryunits");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");

                            if (ddldef.SelectedValue == "Select")
                            {

                            }
                            else
                            {
                                //int Transpurchase = kbs.insertTransPurchase(sTableName, Convert.ToInt32(iSalesID), idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "");
                                int Transpurchase = kbs.insertTransPurchaseorder(sTableName, Convert.ToInt32(insertPurchase), idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, ddlprimaryunits.SelectedValue, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text));
                            }
                        }


                    }

                    #endregion

                    Response.Redirect("Purchase_OrderGrid.aspx");
                }
            }




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

            DropDownList ddlprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");

            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            TextBox PQty = (TextBox)row.FindControl("txtPQty");

            #region

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

            decimal Pqty = 0;


            decimal tax = 0;

            lblError.Visible = false;
            Button1.Enabled = true;
            if (Qty.Text.Trim() != "")
            {
                decimal dQty = Convert.ToDecimal(Qty.Text);
                decimal DRate = Convert.ToDecimal(Rate.Text);
                dAmount = dQty * DRate;

                Pqty = dQty * Convert.ToDecimal(lblprimaryvalue.Text);

                tax = ((dAmount * Convert.ToDecimal(txttax.Text)) / 100);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
            }

            decimal amttax = dAmount + tax;

            PQty.Text = Pqty.ToString("f2");
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


                Label lblprimaryvaluep = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");
                TextBox txtPQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtPQty");

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
            LinkButton Button = (LinkButton)txt.FindControl("add");

            txttax.Focus();
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
            string itemname = "IngredientName";
            DataSet dsCategory = kbs.GetSupplierIngredient(Convert.ToInt32(ddlsuplier.SelectedValue), "2");
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

        protected void drpprimary_unit(object sender, EventArgs e)
        {
            decimal samt = 0;
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");
            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");

            TextBox Qty = (TextBox)row.FindControl("txtQty");

            TextBox Rate = (TextBox)row.FindControl("txtRate");
            TextBox Amount = (TextBox)row.FindControl("txtAmount");
            TextBox txttax = (TextBox)row.FindControl("txtBillNo");           
            TextBox PQty = (TextBox)row.FindControl("txtPQty");

            if (ddlprimaryunits.SelectedValue != "Select PrimaryUom")
            {
                DataSet dss = kbs.getPrimaryUNITSvalue(ddlprimaryunits.SelectedValue);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblprimaryvalue.Text = Convert.ToDouble(dss.Tables[0].Rows[0]["Primaryvalue"]).ToString("0.00");

                    decimal dAmount = 0;

                    decimal Pqty = 0;


                    decimal tax = 0;

                    lblError.Visible = false;
                    Button1.Enabled = true;
                    if (Qty.Text.Trim() != "")
                    {
                        decimal dQty = Convert.ToDecimal(Qty.Text);
                        decimal DRate = Convert.ToDecimal(Rate.Text);
                        dAmount = dQty * DRate;

                        Pqty = dQty * Convert.ToDecimal(lblprimaryvalue.Text);

                        tax = ((dAmount * Convert.ToDecimal(txttax.Text)) / 100);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Rate');", true);
                    }

                    decimal amttax = dAmount + tax;

                    PQty.Text = Pqty.ToString("f2");
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


                        Label lblprimaryvaluep = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");
                        TextBox txtPQty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtPQty");

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
            DropDownList ddlmprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");

            DataSet dss = kbs.getingreUnits(ddlDef.SelectedValue, "0", "2");
            if (dss.Tables[0].Rows.Count > 0)
            {
                Label lblunits = (Label)row.FindControl("lblunits");
                lblunits.Text = dss.Tables[0].Rows[0]["UOM"].ToString();

                TextBox txtBillNo = (TextBox)row.FindControl("txtBillNo");
                txtBillNo.Text = dss.Tables[0].Rows[0]["TaxValue"].ToString();

                TextBox txtQty = (TextBox)row.FindControl("txtQty");
                txtQty.Focus();

                DataSet dprimary = kbs.PrimaryUNITS_ingridentcheck(ddlDef.SelectedValue);
                if (dprimary.Tables[0].Rows.Count > 0)
                {
                    ddlmprimaryunits.DataSource = dprimary.Tables[0];
                    ddlmprimaryunits.DataTextField = "Primaryname";
                    ddlmprimaryunits.DataValueField = "PrimaryUOMID";
                    ddlmprimaryunits.DataBind();
                    ddlmprimaryunits.Items.Insert(0, "Select PrimaryUom");
                }
                else
                {
                    DataSet dprimaryy = kbs.PrimaryUNITS();
                    if (dprimaryy.Tables[0].Rows.Count > 0)
                    {
                        ddlmprimaryunits.DataSource = dprimaryy.Tables[0];
                        ddlmprimaryunits.DataTextField = "Primaryname";
                        ddlmprimaryunits.DataValueField = "PrimaryUOMID";
                        ddlmprimaryunits.DataBind();
                        ddlmprimaryunits.Items.Insert(0, "Select PrimaryUom");
                    }
                }
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
                DataSet dsupplier = kbs.getsupplierdetais(ddlsuplier.SelectedValue);
                if (dsupplier.Tables[0].Rows.Count > 0)
                {
                    txtaddress.Text = dsupplier.Tables[0].Rows[0]["address"].ToString() + "," + dsupplier.Tables[0].Rows[0]["area"].ToString() + "," + dsupplier.Tables[0].Rows[0]["city"].ToString() + "," + dsupplier.Tables[0].Rows[0]["pincode"].ToString();
                }


                FirstGridViewRow();

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
        }

    }
}