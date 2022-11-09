using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class CustomerReceipt : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            if (!IsPostBack)
            {

                string sBillNo = Request.QueryString.Get("iBillNo");

                if (sBillNo != null)
                {

                    DataSet ds = objBs.GetCustDetails(sBillNo, Convert.ToInt32(lblUserID.Text));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtreceiptdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtcustomer.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtCustomerID.Text = ds.Tables[0].Rows[0]["CustomerID"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtarea.Text = ds.Tables[0].Rows[0]["Area"].ToString();
                        txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        txtcity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        DataSet dsBill = objBs.GetCustomerReceiptDet(sBillNo, Convert.ToInt32(lblUserID.Text));
                        if (dsBill.Tables[0].Rows.Count > 0)
                        {
                            txtBillNo.Text = dsBill.Tables[0].Rows[0]["BillNo"].ToString();
                            txtbillamount1.Text = dsBill.Tables[0].Rows[0]["BillAmount"].ToString();
                            txtbalance1.Text = dsBill.Tables[0].Rows[0]["Balance"].ToString();
                            txtAdvAmount.Text = dsBill.Tables[0].Rows[0]["Balance"].ToString();
                            //double dPending = Convert.ToDouble(txtbillamount1.Text) - Convert.ToDouble(txtbalance1.Text);


                            txtamount1.Text = dsBill.Tables[0].Rows[0]["Balance"].ToString();
                        }
                    }

                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

           // decimal dBal = (Convert.ToDecimal(txtbillamount1.Text)) - (Convert.ToDecimal(txtbalance1.Text) + Convert.ToDecimal(txtAdvAmount.Text));
            int iStatus = objBs.InsertCustomerReceipt(Convert.ToInt32(lblUserID.Text), txtBillNo.Text, Convert.ToInt32(txtCustomerID.Text), txtreceiptdate.Text, Convert.ToDouble(txtamount1.Text), Convert.ToDouble(txtamount1.Text), Convert.ToDouble(txtbillamount1.Text));
            Response.Redirect("CustomerPendingReport.aspx");
        }
    }
}