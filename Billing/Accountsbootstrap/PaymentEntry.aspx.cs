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
    public partial class PaymentEntry : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;

        string sTableName = ""; string IsSuperAdmin = "";
        double TtlBillamt = 0; double TtlPaidamt = 0; double TtlRetrnamt = 0; double Ttlbalanceamt = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            IsSuperAdmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            userid = Request.Cookies["userInfo"]["UserID"].ToString();

            if (!IsPostBack)
            {
                DataSet ds1 = objbs.getPaymentnumber(sTableName);
                txtBillNo.Text = ds1.Tables[0].Rows[0]["PaymentNo"].ToString();
                txtBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                txtchequedate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                #region

                DataSet dsCustomer = objbs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "Select Supplier");
                }


                //DataSet dsbank = objbs.Bankactive();
                //if (dsbank.Tables[0].Rows.Count > 0)
                //{
                //    ddlbank.DataSource = dsbank.Tables[0];
                //    ddlbank.DataTextField = "BankName";
                //    ddlbank.DataValueField = "BankId";
                //    ddlbank.DataBind();
                //    ddlbank.Items.Insert(0, "Select Bank");

                //}
                ddlbank.Items.Insert(0, "Select Bank");
                DataSet dspaymode = objbs.tblsalespaymode();
                if (dspaymode.Tables[0].Rows.Count > 0)
                {
                    ddlPayMode.DataSource = dspaymode.Tables[0];
                    ddlPayMode.DataTextField = "PayMode";
                    ddlPayMode.DataValueField = "PayModeId";
                    ddlPayMode.DataBind();
                    ddlPayMode.Items.Insert(0, "Payment");

                }

                #endregion

            }

        }

        protected void ddlPayMode_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPayMode.SelectedValue == "0" || ddlPayMode.SelectedValue == "Payment" || ddlPayMode.SelectedValue == "1")
            {
                txtbank.Enabled = false;
                txtCheqeNo.Enabled = false;
            }
            else if (ddlPayMode.SelectedValue == "7" || ddlPayMode.SelectedValue == "8")
            {
                txtbank.Enabled = true;
                txtCheqeNo.Enabled = true;
            }
        }
        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {

            double adtotal = Convert.ToDouble(txtAmount.Text);

            for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
            {
                TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                Label lblBillAmt = (Label)gv.Rows[vLoop].FindControl("lblBillAmt");

                double Total = Convert.ToDouble(lblBillAmt.Text);

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

        protected void ddlsuplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlsuplier.SelectedValue == "" || ddlsuplier.SelectedValue == "0" || ddlsuplier.SelectedValue == "Select Supplier")
            {
                refund.Visible = false;
                gv.DataSource = null;
                gv.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Supplier.');", true);
                ddlsuplier.Focus();
                return;
            }
            else
            {
                DataSet ds = objbs.GetCreditPurchasebills(sTableName, ddlsuplier.SelectedValue, ddltype.SelectedValue);
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

                if (IsSuperAdmin == "1")
                {
                    e.Row.Cells[11].Enabled = true;
                }
                else
                {
                    e.Row.Cells[11].Enabled = false;
                }

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

                Label lblBillNo = (Label)gv.Rows[vLoop].FindControl("lblBillNo");
                Label lblBalance = (Label)gv.Rows[vLoop].FindControl("lblBalance");
                TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                TextBox txtclosediscount = (TextBox)gv.Rows[vLoop].FindControl("txtclosediscount");

                if (txtpaid.Text == "")
                    txtpaid.Text = "0";
                if (txtclosediscount.Text == "")
                    txtclosediscount.Text = "0";

                paid += Convert.ToDouble(txtpaid.Text);

                if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > Convert.ToDouble(lblBalance.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Received Amount is greater Than The Balance Amount in BillNo " + lblBillNo.Text + ".');", true);
                    return;
                }
                if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > 0 && txtNarration.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter Entry By in BillNo " + lblBillNo.Text + ".');", true);
                    return;
                }
            }
            txtAmount.Text = paid.ToString("0.00");
            txtCloseDiscount.Text = closediscount.ToString("0.00");

            #endregion
        }
        protected void Process_Click(object sender, EventArgs e)
        {
            string BankName = "0"; string ChequeNo = "0"; int Bank = 0;

            if (ddlPayMode.SelectedValue == "7" || ddlPayMode.SelectedValue == "8")
            {
                BankName = txtbank.Text;
                ChequeNo = txtCheqeNo.Text;
            }

            if (ddlsuplier.SelectedValue == "" || ddlsuplier.SelectedValue == "0" || ddlsuplier.SelectedValue == "Select Supplier")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Select Your Supplier.');", true);
                ddlsuplier.Focus();
                return;
            }
            else if (ddlPayMode.SelectedValue == "0" || ddlPayMode.SelectedValue == "Payment")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Select Payment.');", true);
                ddlPayMode.Focus();
                return;
            }
            else if (txtAmount.Text == "" || txtAmount.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter Your Amount.');", true);
                txtAmount.Focus();
                return;
            }
            else
            {

                #region Calculations

                double paid = 0; double closediscount = 0;
                for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
                {
                    TextBox txtNarration = (TextBox)gv.Rows[vLoop].FindControl("txtNarration");

                    Label lblBillNo = (Label)gv.Rows[vLoop].FindControl("lblBillNo");
                    Label lblBalance = (Label)gv.Rows[vLoop].FindControl("lblBalance");
                    TextBox txtpaid = (TextBox)gv.Rows[vLoop].FindControl("txtpaid");
                    TextBox txtclosediscount = (TextBox)gv.Rows[vLoop].FindControl("txtclosediscount");

                    if (txtpaid.Text == "")
                        txtpaid.Text = "0";
                    if (txtclosediscount.Text == "")
                        txtclosediscount.Text = "0";

                    paid += Convert.ToDouble(txtpaid.Text);

                    if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > Convert.ToDouble(lblBalance.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Received Amount is greater Than The Balance Amount in BillNo " + lblBillNo.Text + ".');", true);
                        return;
                    }

                    if ((Convert.ToDouble(txtpaid.Text) + Convert.ToDouble(txtclosediscount.Text)) > 0 && txtNarration.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Enter Entry By in BillNo " + lblBillNo.Text + ".');", true);
                        return;
                    }
                }
                txtAmount.Text = paid.ToString("0.00");
                txtCloseDiscount.Text = closediscount.ToString("0.00");

                #endregion

                if ((Convert.ToDouble(txtAmount.Text) + Convert.ToDouble(txtCloseDiscount.Text)) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Plz Check Amount.');", true);
                    return;
                }

                DateTime billldate = DateTime.ParseExact(txtBillDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime chequedate = DateTime.ParseExact(txtchequedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int PaymentID = objbs.insertPayment(sTableName, billldate, chequedate, ddlsuplier.SelectedValue, Convert.ToDouble(txtAmount.Text), BankName, ChequeNo, Convert.ToInt32(ddlPayMode.SelectedValue), Bank, Convert.ToDouble(txtCloseDiscount.Text), Convert.ToInt32(userid), ddltype.SelectedValue);

                for (int vLoop = 0; vLoop < gv.Rows.Count; vLoop++)
                {
                    #region

                    Label lblBillNo = (Label)gv.Rows[vLoop].FindControl("lblBillNo");
                    Label lblBalance = (Label)gv.Rows[vLoop].FindControl("lblBalance");

                    Label lblSalesid = (Label)gv.Rows[vLoop].FindControl("lblSalesid");


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
                        int UpPaid = objbs.UpPaidinPurchase(PaymentID, sTableName, salesid, Convert.ToDecimal(txtpaid.Text), txtNarration.Text, Convert.ToDecimal(txtclosediscount.Text), ddltype.SelectedValue);
                    }

                    #endregion
                }


                Response.Redirect("PaymentEntryPrint.aspx?PaymentID=" + PaymentID);


            }

        }
        protected void btnexit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("PaymentEntryGrid.aspx");
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            if (ddlsuplier.SelectedValue == "Select Supplier")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Supplier.');", true);
                ddlsuplier.Focus();
                return;
            }
            else
            {
                GridView gridview = new GridView();

                DataSet ds = objbs.GetCreditPurchasebills(sTableName, ddlsuplier.SelectedValue, ddltype.SelectedValue);
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


                gridview.Caption = "Balance Payment Report";

                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=SupplierBalancePayment.xls");
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
}