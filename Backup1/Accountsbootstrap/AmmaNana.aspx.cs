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
    public partial class AmmaNana : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            int billno=Convert.ToInt32(Request.QueryString.Get("BillNo"));
            DataSet ds = objbs.DealerPrint(billno);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblInvNo.Text = ds.Tables[0].Rows[0]["BillNo"].ToString();
                lblBillDate.Text = ds.Tables[0].Rows[0]["BillDate"].ToString();
                string Dealerid = ds.Tables[0].Rows[0]["DealerID"].ToString();

                DataSet dDealer = objbs.DealerDetails(Convert.ToInt32(Dealerid));

                lbldealername.Text = dDealer.Tables[0].Rows[0]["VendorName"].ToString() + "," + dDealer.Tables[0].Rows[0]["Address"].ToString() + "," + dDealer.Tables[0].Rows[0]["Area"].ToString() + "," + dDealer.Tables[0].Rows[0]["City"].ToString() + "-" + dDealer.Tables[0].Rows[0]["Pincode"].ToString() + ","+Environment.NewLine+"<br>" + "MobileNo-" + dDealer.Tables[0].Rows[0]["MobileNo"].ToString() + "," +"Tin No -"+ dDealer.Tables[0].Rows[0]["TinNo"].ToString();


                lblExepTotal.Text = ds.Tables[0].Rows[0]["ExemptedTotal"].ToString();
                lblNet.Text = ds.Tables[0].Rows[0]["NetAmount"].ToString();
                lblVatTotal.Text = ds.Tables[0].Rows[0]["VatTotal"].ToString();
                LblGrandTotal.Text = ds.Tables[0].Rows[0]["GrandTotal"].ToString();
                lblGrand.Text = ds.Tables[0].Rows[0]["GrandTotal"].ToString();


                DataSet grid = objbs.itemlist(billno);
                gvDetails.DataSource = grid.Tables[0];
                gvDetails.DataBind();


                string words = objbs.changeToWords(lblGrand.Text, true);
                lblwords.Text = words;

            }

        }
    }
}