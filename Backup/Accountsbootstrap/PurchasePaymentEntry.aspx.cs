using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class PurchasePaymentEntry : System.Web.UI.Page
    {
        BSClass oBjbs = new BSClass();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnsave.Enabled = true;
                txtDate.Text = DateTime.Now.ToShortDateString();            
                string  iBillNo =( Request.QueryString.Get("BillNo"));
                DataSet ds = oBjbs.PurchaseEntry(iBillNo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtVendorName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                    txtBillNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                    txtBillAmt.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    decimal dBalance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());
                    if (Convert.ToInt32(dBalance) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Payment Completed Please pay For another Bill!');", true);
                        PurchaseEntry.Visible = false;
                    }
                    else
                    {
                        txtBalance.Text = decimal.Round(dBalance, 2).ToString("f2");
                    }
                    txtVendorID.Text = ds.Tables[0].Rows[0]["VendorID"].ToString();
                }
                else
                {
                    DataSet dNew = oBjbs.NewPurchaseEntry(iBillNo);
                    if (dNew.Tables[0].Rows.Count > 0)
                    {
                        txtVendorName.Text = dNew.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtBillNo.Text = dNew.Tables[0].Rows[0]["Bill_NO"].ToString();
                        txtBillAmt.Text = dNew.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtBalance.Text = dNew.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtVendorID.Text = dNew.Tables[0].Rows[0]["VendorID"].ToString();
                    }
                }
              
            }
        }

        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentMode.SelectedValue == "1")
            {
                btnsave.Enabled = true;
                txtbankName.Enabled = false;
                txtRefNo.Enabled = false;
            }
            else
            {
                btnsave.Enabled = true;
                txtbankName.Enabled = true;
                txtRefNo.Enabled = true;
            }
        }

        protected void txtPayingAmt_TextChanged(object sender, EventArgs e)
        {
            //decimal dTotalAmount =Convert.ToDecimal( txtBillAmt.Text);
            //decimal dpaid = Convert.ToDecimal(txtPayingAmt.Text);

            //decimal dBalance = dTotalAmount - dpaid;

            //txtBalance.Text = dBalance.ToString();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            decimal dTotalAmount = Convert.ToDecimal(txtBillAmt.Text);
            decimal dpaid = Convert.ToDecimal(txtPayingAmt.Text);
            decimal dBalance = dTotalAmount - dpaid;

            if (ddlPaymentMode.SelectedValue == "0")
            {
                lblerror.InnerText = "Select Payment Mode";
                btnsave.Enabled = false;
            }
            else
            {
                int iSave = oBjbs.InsertPurchasepayment(txtDate.Text, Convert.ToInt32(txtVendorID.Text), ddlPaymentMode.SelectedItem.Text, txtbankName.Text, txtRefNo.Text, txtBillNo.Text, Convert.ToDecimal(txtBillAmt.Text), Convert.ToDecimal(txtPayingAmt.Text));
                Response.Redirect("../Accountsbootstrap/PurchasePaymentGrid.aspx");
            }
        }
    }
}