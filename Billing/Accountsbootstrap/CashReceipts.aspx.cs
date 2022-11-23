using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class CashReceipts : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = ""; string IsSuperAdmin = "";

        double ttlNetAmount = 0; double ttlCloseDiscount = 0;
        double TtlBillamt = 0; double TtlPaidamt = 0; double TtlRetrnamt = 0; double Ttlbalanceamt = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            IsSuperAdmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            userid = Request.Cookies["userInfo"]["UserID"].ToString();

            if (!IsPostBack)
            {
                DataSet ds1 = objbs.getrecptnumber(sTableName);
              

                txtBillNo.Text = ds1.Tables[0].Rows[0]["ReceiptNo"].ToString();
                txtBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                txtchequedate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet dsbank = objbs.Bankactive();
                if (dsbank.Tables[0].Rows.Count > 0)
                {
                    ddlbank.DataSource = dsbank.Tables[0];
                    ddlbank.DataTextField = "BankName";
                    ddlbank.DataValueField = "BankId";
                    ddlbank.DataBind();
                    ddlbank.Items.Insert(0, "Select Bank");

                }

                DataSet dspaymode = objbs.getpaymoderecNew();
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlPayMode.DataSource = dspaymode.Tables[0];
                    ddlPayMode.DataTextField = "PayMode";
                    ddlPayMode.DataValueField = "PayModeId";
                    ddlPayMode.DataBind();
                    ddlPayMode.Items.Insert(0, "Payment");

                }
             
                DataSet dspay = objbs.getpaymoderecNew();
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlpay.DataSource = dspaymode.Tables[0];
                    ddlpay.DataTextField = "PayMode";
                    ddlpay.DataValueField = "PayModeId";
                    ddlpay.DataBind();
                    ddlpay.Items.Insert(0, "All");

                }
                DataSet dss = new DataSet();
                dss = objbs.getgridforcustsale();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dss.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "LedgerID";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "Select Customer");


                    ddlcustomerrep.DataSource = dss.Tables[0];
                    ddlcustomerrep.DataTextField = "CustomerName";
                    ddlcustomerrep.DataValueField = "LedgerID";
                    ddlcustomerrep.DataBind();
                    ddlcustomerrep.Items.Insert(0, "All");
                }
            }

        }

        protected void ddlPayMode_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPayMode.SelectedValue == "0" || ddlPayMode.SelectedValue == "Payment")
            {
                txtCheqeNo.Enabled = false;
                txtbank.Enabled = false;
                ddlbank.Enabled = false;
                txtchequedate.Enabled = false;
            }
            else if (ddlPayMode.SelectedValue == "7" || ddlPayMode.SelectedValue == "8")
            {
                txtCheqeNo.Enabled = true;
                txtbank.Enabled = true;
                ddlbank.Enabled = true;
                txtchequedate.Enabled = true;
            }
            else
            {
                txtCheqeNo.Enabled = false;
                txtbank.Enabled = false;
                ddlbank.Enabled = false;
                txtchequedate.Enabled = false;
            }
        }
        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {

            double adtotal = Convert.ToDouble(txtAmount.Text);

            for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
            {
                TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                Label lblTotal = (Label)gv.Rows[vLoop].FindControl("lblTotal");

                double Total = Convert.ToDouble(lblTotal.Text);

                if (adtotal > Convert.ToDouble(Total))
                {
                    txtpaid.Text = Total.ToString();
                    adtotal = adtotal - Convert.ToDouble(Total);
                }
                else if (adtotal < Convert.ToDouble(Total))
                {
                    txtpaid.Text = adtotal.ToString();
                    adtotal = 0;
                }
                else if (adtotal == Convert.ToDouble(Total))
                {
                    txtpaid.Text = adtotal.ToString();
                    adtotal = 0;
                }

            }
            lblledgerbalance.Text = adtotal.ToString("f2");
        }
        protected void ddlcustomer_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcustomer.SelectedValue == "" || ddlcustomer.SelectedValue == "" || ddlcustomer.SelectedValue == "Select Customer")
            {
                refund.Visible = false;
                gv.DataSource = null;
                gv.DataBind();
            }
            else
            {
                DataSet ds = objbs.GetCreditbills(sTableName, ddlcustomer.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv.DataSource = ds;
                    gv.DataBind();

                }
                else
                {
                    refund.Visible = false;
                    gv.DataSource = null;
                    gv.DataBind();
                }
            }

            txtAmount.Text = "0.00";
        }
        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TtlBillamt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                TtlPaidamt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Paidamt"));
                TtlRetrnamt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ReturnAmount"));
                Ttlbalanceamt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));

                //if (IsSuperAdmin == "1")
                //{
                //    e.Row.Cells[11].Enabled = true;
                //}
                //else
                //{
                //    e.Row.Cells[11].Enabled = false;
                //}

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = TtlBillamt.ToString("f2");
                e.Row.Cells[6].Text = TtlPaidamt.ToString("f2");
                e.Row.Cells[7].Text = TtlRetrnamt.ToString("f2");
                e.Row.Cells[8].Text = Ttlbalanceamt.ToString("f2");
            }
        }

        protected void btncalc_Click(object sender, EventArgs e)
        {
            #region Calculations

            double paid = 0; double closediscount = 0;
            for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
            {
                TextBox txtNarration = (TextBox)gv.Rows[vLoop].FindControl("txtNarration");
                Label lblSalesid = (Label)gv.Rows[vLoop].FindControl("lblSalesid");

                Label lblBillNo = (Label)gv.Rows[vLoop].FindControl("lblBillNo");
                Label lblTotal = (Label)gv.Rows[vLoop].FindControl("lblTotal");
                TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                TextBox txtclosediscount = (TextBox)gv.Rows[vLoop].FindControl("txtclosediscount");

                if (txtpaid.Text == "")
                    txtpaid.Text = "0";
                if (txtclosediscount.Text == "")
                    txtclosediscount.Text = "0";

                paid += Convert.ToDouble(txtpaid.Text);
                closediscount += Convert.ToDouble(txtclosediscount.Text);

                double TtlAmount = Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text);
                if (TtlAmount > 0)
                {

                    if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > Convert.ToDouble(lblTotal.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Received Amount is greater Than The Billbalance in BillNo " + lblBillNo.Text + ".');", true);
                        return;
                    }
                    if (Convert.ToDouble(txtclosediscount.Text) > 0)
                    {
                        if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) != Convert.ToDouble(lblTotal.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Close Full Amount in BillNo " + lblBillNo.Text + ".');", true);
                            return;
                        }
                    }
                    if (Convert.ToDouble(txtclosediscount.Text) != 0 && txtNarration.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter Narration in BillNo " + lblBillNo.Text + ".');", true);
                        return;
                    }

                    DataSet ds = objbs.CheckCustomerforCreditNoteEntry(sTableName, TtlAmount, Convert.ToInt32(lblSalesid.Text));
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Check Amount in BillNo " + lblBillNo.Text + ".');", true);
                        txtpaid.Focus();
                        return;
                    }
                }
            }

            #endregion

            txtAmount.Text = paid.ToString("0.00");
            txtCloseDiscount.Text = closediscount.ToString("0.00");

        }
        protected void Process_Click(object sender, EventArgs e)
        {
            string BankName = "0"; string ChequeNo = "0"; int Bank = 0;


            if (ddlPayMode.SelectedValue == "0" || ddlPayMode.SelectedValue == "Payment")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Select Payment.!!!');", true);
                return;
            }
            else if (ddlcustomer.SelectedValue == "Select Customer" || ddlcustomer.SelectedValue == "0" || ddlcustomer.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Select Your Customer.!!!');", true);
                return;
            }
            else if (txtAmount.Text == "" || txtAmount.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter Your Amount.!!!');", true);
                return;
            }
            else
            {
                if (ddlPayMode.SelectedValue == "7" || ddlPayMode.SelectedValue == "8")
                {
                    #region

                    if (txtCheqeNo.Text == "" || txtCheqeNo.Text == "0")
                    {
                        if (ddlPayMode.SelectedValue == "7")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter  Cheque No.!!!');", true);
                            return;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter UTR No.!!!');", true);
                            return;
                        }
                    }
                    else
                    {
                        ChequeNo = txtCheqeNo.Text;
                    }
                    if (ddlbank.SelectedValue == "" || ddlbank.SelectedValue == "" || ddlbank.SelectedValue == "Select Bank")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Select Bank Name.!!!');", true);
                        return;
                    }
                    else
                    {
                        BankName = ddlbank.SelectedItem.Text;
                        Bank = Convert.ToInt32(ddlbank.SelectedValue);
                    }

                    DataSet dschkbankdetails = objbs.chkbankdetails("tblReceipt_" + sTableName, Convert.ToInt32(ddlbank.SelectedValue), txtCheqeNo.Text, Convert.ToInt32(ddlPayMode.SelectedValue));
                    if (dschkbankdetails.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Cheque No./UTR No already inserted.!!!');", true);
                        return;
                    }

                    #endregion
                }

                #region Calculations

                double paid = 0; double closediscount = 0;
                for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
                {
                    Label lblSalesid = (Label)gv.Rows[vLoop].FindControl("lblSalesid");

                    TextBox txtNarration = (TextBox)gv.Rows[vLoop].FindControl("txtNarration");
                    Label lblBillNo = (Label)gv.Rows[vLoop].FindControl("lblBillNo");
                    Label lblTotal = (Label)gv.Rows[vLoop].FindControl("lblTotal");

                    Label lblCreditNoteAmount = (Label)gv.Rows[vLoop].FindControl("lblCreditNoteAmount");

                    TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                    TextBox txtclosediscount = (TextBox)gv.Rows[vLoop].FindControl("txtclosediscount");

                    if (txtpaid.Text == "")
                        txtpaid.Text = "0";
                    if (txtclosediscount.Text == "")
                        txtclosediscount.Text = "0";

                    paid += Convert.ToDouble(txtpaid.Text);
                    closediscount += Convert.ToDouble(txtclosediscount.Text);

                    double TtlAmount = Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text);
                    if (TtlAmount > 0)
                    {
                        if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > Convert.ToDouble(lblTotal.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Received Amount is greater Than The Billbalance in BillNo " + lblBillNo.Text + ".');", true);
                            return;
                        }
                        if (Convert.ToDouble(txtclosediscount.Text) > 0)
                        {
                            if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) != Convert.ToDouble(lblTotal.Text))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Close Full Amount in BillNo " + lblBillNo.Text + ".');", true);
                                return;
                            }
                        }
                        if (Convert.ToDouble(txtclosediscount.Text) != 0 && txtNarration.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter Narration in BillNo " + lblBillNo.Text + ".');", true);
                            return;
                        }

                        DataSet ds = objbs.CheckCustomerforCreditNoteEntry(sTableName, TtlAmount, Convert.ToInt32(lblSalesid.Text));
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Check Amount in BillNo " + lblBillNo.Text + ".');", true);
                            txtpaid.Focus();
                            return;
                        }
                    }

                }
                #endregion

                txtAmount.Text = paid.ToString("0.00");
                txtCloseDiscount.Text = closediscount.ToString("0.00");


                if ((Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtCloseDiscount.Text)) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Check Amount.');", true);
                    return;
                }

                DateTime billldate = DateTime.ParseExact(txtBillDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime chequedate = DateTime.ParseExact(txtchequedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

               int ReceiptID = objbs.insertreceipt(sTableName, billldate, chequedate, ddlcustomer.SelectedValue, Convert.ToDouble(txtAmount.Text), BankName, ChequeNo, Convert.ToInt32(ddlPayMode.SelectedValue), Bank, Convert.ToDouble(txtCloseDiscount.Text), Convert.ToInt32(userid));

                for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
                {
                    #region

                    Label lblSalesid = (Label)gv.Rows[vLoop].FindControl("lblSalesid");

                    Label lblTotal = (Label)gv.Rows[vLoop].FindControl("lblTotal");
                    TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                    TextBox txtNarration = (TextBox)gv.Rows[vLoop].FindControl("txtNarration");
                    TextBox txtclosediscount = (TextBox)gv.Rows[vLoop].FindControl("txtclosediscount");

                    int salesid = Convert.ToInt32(lblSalesid.Text);

                    if (txtpaid.Text == "")
                        txtpaid.Text = "0";
                    if (txtclosediscount.Text == "")
                        txtclosediscount.Text = "0";

                    if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > 0)
                    {
                      int UpPaid = objbs.UpPaidinsalesnew(ReceiptID, sTableName, salesid, Convert.ToDecimal(txtpaid.Text), txtNarration.Text, Convert.ToDecimal(txtclosediscount.Text));
                    }

                    #endregion
                }

                //////  int Upcash = objbs.UpUpcashsales(sTableName);

                Response.Redirect("CashReceipt.aspx?ReceiptID=" + ReceiptID);


            }

        }
        protected void btnExcel_Click1(object sender, EventArgs e)
        {
            if (ddlcustomer.SelectedValue == "Select Customer")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Customer!!!');", true);
                return;
            }
            else
            {
                GridView gridview = new GridView();

                DataSet ds = objbs.GetCreditbillsExcel(sTableName, ddlcustomer.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    gridview.DataSource = null;
                    gridview.DataBind();
                }


                gridview.Caption = "Receipt Report";

                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=CustomerBalanceReport.xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gridview.AllowPaging = false;
                gridview.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
                gridview.AllowPaging = true;
            }
        }


        protected void btnsearch_OnClick(object sender, EventArgs e)
        {
            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getreceiptrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlpay.SelectedValue);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvreceiptamt.DataSource = ds;
                gvreceiptamt.DataBind();
            }
            else
            {
                gvreceiptamt.DataSource = null;
                gvreceiptamt.DataBind();
            }
        }
        protected void gvreceiptamt_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ttlNetAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                ttlCloseDiscount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CloseDiscount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total :";
                e.Row.Cells[4].Text = ttlNetAmount.ToString("f2");
                e.Row.Cells[5].Text = ttlCloseDiscount.ToString("f2");
            }

        }
        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "print")
            {

                string yourUrl = "CashReceipt.aspx?ReceiptID=" + e.CommandArgument.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

            }
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();

            DateTime sFrom = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getreceiptrecord(sTableName, ddlcustomerrep.SelectedValue, sFrom, sTo, ddlpay.SelectedValue);
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = null;
                gridview.DataBind();
            }


            gridview.Caption = "Receipt Report";

            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=CashReceiptReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }

    }
}