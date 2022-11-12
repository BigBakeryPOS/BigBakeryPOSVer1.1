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
    public partial class PaymentEntryPrint : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        double TtlBillamt = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                sTableName = Request.Cookies["userInfo"]["User"].ToString();

                string ISalesId = Request.QueryString.Get("PaymentID");

                if (ISalesId != null)
                {
                    DataSet ds1 = objbs.GetPayment(sTableName, Convert.ToInt32(ISalesId));

                    lblBillNo.Text = ds1.Tables[0].Rows[0]["PaymentNo"].ToString();
                    lblBillDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["PaymentDate"]).ToString("dd/MM/yyyy");
                    lblCustomerName.Text = ds1.Tables[0].Rows[0]["LedgerName"].ToString();
                    lblPayMode.Text = ds1.Tables[0].Rows[0]["PayMode"].ToString();
                    lblCustomerPhoneNo.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                    lblCustomerAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();

                    DataSet dsname = objbs.getsupplierdetais(ds1.Tables[0].Rows[0]["BankName"].ToString());
                    if (dsname.Tables[0].Rows.Count > 0)
                    {
                        lblbankname.Text = dsname.Tables[0].Rows[0]["LedgerName"].ToString();
                    }
                    else
                    {
                        lblbankname.Text ="";
                    }
                    lblchequeno.Text = ds1.Tables[0].Rows[0]["ChequeNo"].ToString();

                    lblgrandtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["NetAmount"]).ToString("f2");

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        gridprint.DataSource = ds1;
                        gridprint.DataBind();
                    }


                }
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentEntryGrid.aspx");
        }

        protected void gridprint_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TtlBillamt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total:-";
                e.Row.Cells[3].Text = TtlBillamt.ToString("f2");
            }
        }
    }
}

