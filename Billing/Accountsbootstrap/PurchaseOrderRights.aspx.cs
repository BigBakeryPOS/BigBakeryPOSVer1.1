using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class PurchaseOrderRights : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";

        string strPreviousRowID = string.Empty;





        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {

                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                if (!IsPostBack)
                {
                    DataSet dsPO = objbs.PurchaseOrderList("tblkitchenPurchaseorder_" + sTableName);
                    if (dsPO.Tables[0].Rows.Count > 0)
                    {
                        drpPO.DataSource = dsPO.Tables[0];
                        drpPO.DataTextField = "OrderNo";
                        drpPO.DataValueField = "OrderNo";
                        drpPO.DataBind();
                        drpPO.Items.Insert(0, "OrderNo");

                    }

                    DataSet dsCustomer = objbs.SupplierList11();
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        ddlsuplier.DataSource = dsCustomer.Tables[0];
                        ddlsuplier.DataTextField = "LedgerName";
                        ddlsuplier.DataValueField = "LedgerID";
                        ddlsuplier.DataBind();
                        ddlsuplier.Items.Insert(0, "Supplier");


                    }


                    DataSet bank = objbs.Ledgerbank();
                    if (bank.Tables[0].Rows.Count > 0)
                    {
                        ddlbank.DataSource = bank.Tables[0];
                        ddlbank.DataTextField = "LedgerName";
                        ddlbank.DataValueField = "LedgerID";
                        ddlbank.DataBind();
                        ddlbank.Items.Insert(0, "Select Bank");
                    }

                    DataSet Paymode = objbs.GetOthersPaymode();
                    if (Paymode.Tables[0].Rows.Count > 0)
                    {
                        ddlpaymode.DataSource = Paymode.Tables[0];
                        ddlpaymode.DataTextField = "Paymode";
                        ddlpaymode.DataValueField = "Value";
                        ddlpaymode.DataBind();
                        ddlpaymode.Items.Insert(0, "Select Paymode");
                    }
                }



            }
        }

        protected void drpprimary_unit(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            DropDownList ddlprimaryunits = (DropDownList)row.FindControl("ddlprimaryunits");
            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            if (ddlprimaryunits.SelectedValue != "Select PrimaryUom")
            {
                DataSet dss = objbs.getPrimaryUNITSvalue(ddlprimaryunits.SelectedValue);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblprimaryvalue.Text = Convert.ToDouble(dss.Tables[0].Rows[0]["Primaryvalue"]).ToString("0.00");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Valid Primary UOM.Thank You!!!.');", true);
                return;
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

                DataSet dagent = objbs.getPOlist(drpPO.SelectedValue, sTableName);
                if (dagent.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.SelectedValue = dagent.Tables[0].Rows[0]["Supplier"].ToString();

                    ddlpaymode.SelectedValue = dagent.Tables[0].Rows[0]["Paymode"].ToString();

                    if (ddlpaymode.SelectedValue == "4" || ddlpaymode.SelectedValue == "11" || ddlpaymode.SelectedValue == "15" || ddlpaymode.SelectedValue == "19")
                    {
                        ddlbank.Enabled = true;
                        txtcheque.Enabled = true;
                        ddlbank.Visible = true;
                        txtcheque.Visible = true;
                        // lblbank.Visible = true;
                        // lblChq.Visible = true;
                        ddlbank.SelectedValue = dagent.Tables[0].Rows[0]["Bank"].ToString();
                        txtcheque.Text = dagent.Tables[0].Rows[0]["ChequeNo"].ToString();
                    }
                    else
                    {
                        ddlbank.Enabled = false;
                        txtcheque.Enabled = false;

                        ddlbank.Visible = false;
                        txtcheque.Visible = false;

                       // lblbank.Visible = false;
                      //  lblChq.Visible = false;
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

                    


                    DataSet transpur = objbs.getpotranslist(drpPO.SelectedValue, sTableName);


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

                    dct = new DataColumn("TransID");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("AQty");
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
                        drNew["ExpDate"] = dr["ExpiryDate"];
                        drNew["TransID"] = dr["TransID"];

                        drNew["PUnits"] = dr["Punitsid"];
                        drNew["Pvalue"] = dr["Pvalue"];
                        drNew["PQty"] = dr["PUqty"];

                        drNew["Aqty"] = Convert.ToInt32(dr["Qty"]) - Convert.ToInt32(dr["PQty"]);

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

                        Label txtaQty = (Label)gvcustomerorder.Rows[vLoop].FindControl("txtaQty");
                        HiddenField TransID = (HiddenField)gvcustomerorder.Rows[vLoop].FindControl("TransID");

                        DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[vLoop].FindControl("ddlprimaryunits");
                        Label lblprimaryvalue = (Label)gvcustomerorder.Rows[vLoop].FindControl("lblprimaryvalue");

                        TextBox txtpqty = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtpqty");


                        txtsno.Text = (vLoop + 1).ToString();
                        ddlDef.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                        lblDescriptionID.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["IngredientID"]).ToString();
                        txtQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Qty"]).ToString();
                        txtaQty.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["AQty"]).ToString();
                        txtRate.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Rate"]).ToString();
                        txtAmount.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["Amount"]).ToString();
                        ddlunits.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Units"]).ToString();
                        lblunits.Text = ddlunits.SelectedItem.Text;
                        //////  txtBillNo.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString(); 

                        txtBillNo.Text = Convert.ToDouble(dstd.Tables[0].Rows[vLoop]["BillNo"]).ToString("f2");
                        txtsupplier.Text = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Supplier"]).ToString();
                        ddlPay.SelectedValue = Convert.ToInt32(dstd.Tables[0].Rows[vLoop]["Paymode"]).ToString();
                        txtexpireddate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ExpDate"]).ToString("dd/MM/yyyy");

                        TransID.Value = dstd.Tables[0].Rows[vLoop]["TransID"].ToString();

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

                    Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                    TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");




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
            }
        }

        protected void ddlDef_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            DropDownList ddlDef = (DropDownList)row.FindControl("ddlDef");

            DataSet dss = objbs.getingreUnits(ddlDef.SelectedValue,"0","2");
            if (dss.Tables[0].Rows.Count > 0)
            {
                Label lblunits = (Label)row.FindControl("lblunits");
                lblunits.Text = dss.Tables[0].Rows[0]["UOM"].ToString();
                TextBox txtQty = (TextBox)row.FindControl("txtQty");
                txtQty.Focus();
            }
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
           

        }

        

        protected void gvcustomerorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DataSet dsCategory = objbs.GetIngredient();
            DataSet dunitsval = new DataSet();
            DataSet dunits = objbs.UNITS();
            DataSet dprimary = objbs.PrimaryUNITS();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region

                DropDownList ddlunits = (DropDownList)(e.Row.FindControl("ddlunits") as DropDownList);
                DropDownList ddIngredients = (DropDownList)(e.Row.FindControl("ddlDef") as DropDownList);
                Label lblunits = (Label)(e.Row.FindControl("lblunits") as Label);
                DropDownList ddlprimaryunits = (DropDownList)(e.Row.FindControl("ddlprimaryunits") as DropDownList);

                ddIngredients.Focus();
                ddIngredients.Enabled = true;

                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddIngredients.DataSource = dsCategory.Tables[0];
                    ddIngredients.DataTextField = "IngredientName";
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



                #endregion
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


            Label lblprimaryvalue = (Label)row.FindControl("lblprimaryvalue");
            TextBox txtpqty = (TextBox)row.FindControl("txtpqty");

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


            Button1.Enabled = true;
            if (Qty.Text.Trim() != "")
            {
                decimal dQty = Convert.ToDecimal(Qty.Text);
                decimal DRate = Convert.ToDecimal(Rate.Text);
                dAmount = dQty * DRate;
                txtpqty.Text = (Convert.ToDouble(Qty.Text) * Convert.ToDouble(lblprimaryvalue.Text)).ToString("0.00");

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
        protected void btnnew_Click(object sender, EventArgs e)
        {
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

                        Label txtaQty = (Label)gvcustomerorder.Rows[rowIndex].Cells[7].FindControl("txtaQty");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;


                        HiddenField TransID = (HiddenField)gvcustomerorder.Rows[rowIndex].Cells[9].FindControl("TransID");
                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["TransID"] = TransID.Value;

                        dtCurrentTable.Rows[i - 1]["AQty"] = txtaQty.Text;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;
                        dtCurrentTable.Rows[i - 1]["Supplier"] = suppliet.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Paymode"] = paymode.SelectedItem.Text;
                        dtCurrentTable.Rows[i - 1]["ExpDate"] = txtexpireddate.Text;
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
                        Label txtaQty = (Label)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("txtaQty");
                        // drCurrentRow["RowNumber"] = i + 1;
                        txtsno.Text = Convert.ToString(i + 1);
                        //gvcustomerorder.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                        HiddenField TransID = (HiddenField)gvcustomerorder.Rows[rowIndex].Cells[5].FindControl("TransID");

                        if (dt.Rows[i]["Qty"].ToString() != "")
                        {


                            if (TransID.Value == "")
                                TransID.Value = "0";

                            TransID.Value = dt.Rows[i]["TransID"].ToString();
                            txtQty.Text = dt.Rows[i]["Qty"].ToString();

                            if (txtaQty.Text == "")
                                txtaQty.Text = "0";
                            txtaQty.Text = dt.Rows[i]["AQty"].ToString();

                            txtRate.Text = dt.Rows[i]["Rate"].ToString();
                            txtAmount.Text = dt.Rows[i]["Amount"].ToString();
                            lblunits.Text = dt.Rows[i]["Units"].ToString();
                            ddlIngregients.SelectedValue = dt.Rows[i]["IngredientID"].ToString();
                            billno.Text = dt.Rows[i]["BillNo"].ToString();
                            suppliet.SelectedValue = dt.Rows[i]["Supplier"].ToString();
                            paymode.SelectedItem.Text = dt.Rows[i]["Paymode"].ToString();
                            txtexpireddate.Text = dt.Rows[i]["ExpDate"].ToString();
                            rowIndex++;
                        }
                        //ddlIngregients.Focus();
                        ddlIngregients.Enabled = true;
                    }
                }
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
            dt.Columns.Add(new DataColumn("TransID", typeof(string)));
            dt.Columns.Add(new DataColumn("AQty", typeof(string)));

            dr = dt.NewRow();
            dr["sno"] = 1;
            dr["Ingredient"] = string.Empty;
            dr["IngredientID"] = string.Empty;

            dr["AQty"] = string.Empty;
            dr["Qty"] = string.Empty;
            dr["Rate"] = string.Empty;
            dr["Amount"] = string.Empty;
            dr["Units"] = string.Empty;
            dr["BillNo"] = string.Empty;
            dr["Supplier"] = string.Empty;
            dr["Paymode"] = string.Empty;
            dr["ExpDate"] = string.Empty;
            dr["TransID"] = string.Empty;
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
                        HiddenField TransID = (HiddenField)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("TransID");
                        Label txtaQty = (Label)gvcustomerorder.Rows[rowIndex].Cells[6].FindControl("txtaQty");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["sno"] = i + 1;


                        //dtCurrentTable.Rows[i - 1]["Ingredient"] = ddlIngregients.SelectedItem.Text;

                        if (TransID.Value == "")
                            TransID.Value = "0";

                        dtCurrentTable.Rows[i - 1]["TransID"] = TransID.Value;
                        dtCurrentTable.Rows[i - 1]["Qty"] = txtQty.Text;

                        if (txtaQty.Text == "")
                            txtaQty.Text = "0";
                        dtCurrentTable.Rows[i - 1]["AQty"] = txtaQty.Text;

                        dtCurrentTable.Rows[i - 1]["Rate"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;

                        dtCurrentTable.Rows[i - 1]["IngredientID"] = ddlIngregients.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Units"] = lblunits.Text;
                        dtCurrentTable.Rows[i - 1]["BillNo"] = billno.Text;
                        //////if (suppliet.SelectedItem.Text == "New Supplier")
                        //////{


                        //////    int custid = objbs.insertSupplier(txtSupliername.Text);
                        //////    DataSet dsCustomer = objbs.SupplierList();
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


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (drpPO.SelectedValue == "OrderNo")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select OrderNo');", true);
                return;
            }
            if (ddlsuplier.SelectedValue == "Supplier")
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
                        DataSet dsledger = objbs.getCashledgerId123("Cash A/C _" + sTableName);
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
                    DataSet dsledger1 = objbs.getCashledgerId123("PurchaseA/C_" + sTableName);
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


                    DateTime Date = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                    int insertPurchase = objbs.insertPurchaseRights(sTableName, Convert.ToInt32(ledgerid), Convert.ToInt32(CreditorID1), "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), bank, chequeno, txtcgst.Text, txtsgst.Text, txtigst.Text, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(drpPO.SelectedValue), Province, Date);

                    DataSet dspurchaseorderID = objbs.GettransPpurchaseid(sTableName, Convert.ToInt32(drpPO.SelectedValue));

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

                            Label txtaQty = (Label)gvcustomerorder.Rows[i].FindControl("txtaQty");
                            decimal adQty = Convert.ToDecimal(txtaQty.Text);

                            HiddenField TransID = (HiddenField)gvcustomerorder.Rows[i].FindControl("TransID");

                            DropDownList ddlprimaryunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlprimaryunits");
                            Label lblprimaryvalue = (Label)gvcustomerorder.Rows[i].FindControl("lblprimaryvalue");

                            TextBox txtpqty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtpqty");

                            if (TransID.Value == "")
                                TransID.Value = "0";

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
                                int Transpurchase = objbs.insertTransPurchaserights(sTableName, Convert.ToInt32(dspurchaseorderID.Tables[0].Rows[0]["purchaseorderID"].ToString()), idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text, adQty, Convert.ToInt32(TransID.Value), ddlprimaryunits.SelectedValue, Convert.ToDouble(lblprimaryvalue.Text), Convert.ToDouble(txtpqty.Text));


                            }
                        }
                    }



                    int uprignts = objbs.upRights(sTableName, Convert.ToInt32(drpPO.SelectedValue));
                    #endregion

                    Response.Redirect("OrderRightsGrid.aspx");
                }
                else
                {
                    #region
                    //////if (txteditnarrations.Text == "" || txteditnarrations.Text == "0")
                    //////{
                    //////    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Enter Edit Narrations.Thank You!!!.');", true);
                    //////    return;
                    //////}


                    //////#region

                    //////string iSalesID = Request.QueryString.Get("LedgerID");


                    //////int CreditorID1 = 0;
                    //////if (ddlpaymode.SelectedValue == "2") //Credit
                    //////{
                    //////    CreditorID1 = Convert.ToInt32(ddlsuplier.SelectedValue);
                    //////}
                    //////if (ddlpaymode.SelectedValue == "1") //Cash
                    //////{
                    //////    DataSet dsledger = objbs.getCashledgerId123("Cash A/C _" + sTableName);
                    //////    CreditorID1 = Convert.ToInt32(dsledger.Tables[0].Rows[0]["LedgerID"].ToString());
                    //////}

                    //////if (ddlpaymode.SelectedValue == "3") //cheque
                    //////{
                    //////    // DataSet dsledger = objbs.getCashledgerId("Cash A/C _" + sTableName);
                    //////    CreditorID1 = Convert.ToInt32(ddlbank.SelectedValue);
                    //////}

                    //////DataSet dsledger1 = objbs.getCashledgerId123("PurchaseA/C_" + sTableName);
                    //////string ledgerid = dsledger1.Tables[0].Rows[0]["LedgerID"].ToString();

                    //////string Province;
                    //////if (rbdpurchasetype.SelectedValue == "1")
                    //////{
                    //////    Province = "Inner";
                    //////}
                    //////else
                    //////{
                    //////    Province = "Outer";
                    //////}

                    //////string BillingType;
                    //////int PONo;
                    //////if (rbtype.SelectedValue == "1")
                    //////{
                    //////    BillingType = "Direct";
                    //////    PONo = 0;
                    //////}
                    //////else
                    //////{
                    //////    BillingType = "Purchase Order";
                    //////    PONo = Convert.ToInt32(drpPO.SelectedValue);
                    //////}

                    //////int insertPurchase = objbs.updatePurchase(sTableName, txtbillno.Text, txtsdate1.Text, "", Convert.ToDecimal(txtSubTotal.Text), Convert.ToDecimal(0), Convert.ToDecimal(txttotal.Text), Convert.ToInt32(ddlsuplier.SelectedValue), Convert.ToInt32(ddlpaymode.SelectedValue), iSalesID, bank, chequeno, CreditorID1, ledgerid, txtcgst.Text, txtsgst.Text, txtigst.Text, txtdcno.Text, Convert.ToInt32(lblUserID.Text), txteditnarrations.Text, Province);
                    //////int trans1 = objbs.getduplisttrans123(iSalesID, sTableName);

                    //////int transdelete = objbs.getduplisttransdelete(iSalesID, sTableName);

                    //////for (int i = 0; i < gvcustomerorder.Rows.Count; i++)
                    //////{
                    //////    TextBox Amount = (TextBox)gvcustomerorder.Rows[i].FindControl("txtAmount");
                    //////    if (Amount.Text != "")
                    //////    {

                    //////        DropDownList ddldef = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlDef");
                    //////        string ingre = ddldef.SelectedItem.Text;
                    //////        int idef = Convert.ToInt32(ddldef.SelectedValue);

                    //////        TextBox Qty = (TextBox)gvcustomerorder.Rows[i].FindControl("txtQty");
                    //////        decimal dQty = Convert.ToDecimal(Qty.Text);

                    //////        TextBox Rate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtRate");
                    //////        decimal DRate = Convert.ToDecimal(Rate.Text);
                    //////        DropDownList ddlunits = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlunits");

                    //////        decimal dAmount = Convert.ToDecimal(Amount.Text);

                    //////        TextBox billno = (TextBox)gvcustomerorder.Rows[i].FindControl("txtBillNo");

                    //////        DropDownList supplier = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddSupplier");

                    //////        DropDownList paymode = (DropDownList)gvcustomerorder.Rows[i].FindControl("ddlPay");

                    //////        TextBox txtSupliername = (TextBox)gvcustomerorder.Rows[i].FindControl("txtsupplier");

                    //////        TextBox txtexpireddate = (TextBox)gvcustomerorder.Rows[i].FindControl("txtexpireddate");

                    //////        if (ddldef.SelectedValue == "Select")
                    //////        {

                    //////        }
                    //////        else
                    //////        {
                    //////            int Transpurchase = objbs.insertTransPurchase(sTableName, Convert.ToInt32(iSalesID), idef, dQty, DRate, dAmount, Convert.ToDecimal(billno.Text), Convert.ToInt32(lblUserID.Text), ddlunits.SelectedValue, Convert.ToDecimal(billno.Text), Convert.ToInt32(0), "", txtexpireddate.Text);
                    //////        }
                    //////    }


                    //////}

                    //////#endregion

                    //////Response.Redirect("Purchase_invGrid.aspx");
                    #endregion
                }
            }




        }

    }
}

