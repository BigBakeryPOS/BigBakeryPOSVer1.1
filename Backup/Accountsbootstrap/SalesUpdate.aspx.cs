using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using CommonLayer;

namespace Billing.Accountsbootstrap
{
    public partial class SalesUpdate : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            string iSalesID = Request.QueryString.Get("iSalesID");
            if (iSalesID != "" || iSalesID != null)
            {
                DataSet ds1 = objBs.CustomerSalesGirdget(iSalesID, "tblSales_" + sTableName);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //txtcuscode.Text = ds1.Tables[0].Rows[0]["CustomerID"].ToString();
                    txtbillno.Text = ds1.Tables[0].Rows[0]["BillNo"].ToString();
                    txtdate.Text = ds1.Tables[0].Rows[0]["BillDate"].ToString();
                    txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                    txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                    txtarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                    txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                    txtpincode.Text = ds1.Tables[0].Rows[0]["pincode"].ToString();
                    //ddlcategory.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();

                }

            }

        }
        protected void Update_Click(object sender, EventArgs e)
        {
        }
        protected void txtrate_TextChanged1(object sender, EventArgs e)
        {
            int iNetAmount = ((Convert.ToInt32(txtqty.Text)) * (Convert.ToInt32(txtrate.Text)));
            txtamount.Text = Convert.ToString(iNetAmount);

            int iGross1 = 0; int iGross2 = 0; int iGross3 = 0; int iGross4 = 0; int iGross5 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToInt32(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToInt32(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToInt32(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToInt32(txtamount3.Text);
            int iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5;
            txttotal.Text = Convert.ToString(iTotalAmount);

        }
        protected void txtrate_TextChanged2(object sender, EventArgs e)
        {
            int iNetAmount1 = ((Convert.ToInt32(txtqty1.Text)) * (Convert.ToInt32(txtrate1.Text)));
            txtamount1.Text = Convert.ToString(iNetAmount1);
            int iGross1 = 0; int iGross2 = 0; int iGross3 = 0; int iGross4 = 0; int iGross5 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToInt32(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToInt32(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToInt32(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToInt32(txtamount3.Text);
            int iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5;
            txttotal.Text = Convert.ToString(iTotalAmount);
        }
        protected void txtrate_TextChanged3(object sender, EventArgs e)
        {
            int iNetAmount2 = ((Convert.ToInt32(txtqty2.Text)) * (Convert.ToInt32(txtrate2.Text)));
            txtamount2.Text = Convert.ToString(iNetAmount2);
            int iGross1 = 0; int iGross2 = 0; int iGross3 = 0; int iGross4 = 0; int iGross5 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToInt32(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToInt32(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToInt32(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToInt32(txtamount3.Text);
            int iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5;
            txttotal.Text = Convert.ToString(iTotalAmount);
        }
        protected void txtrate_TextChanged4(object sender, EventArgs e)
        {
            int iNetAmount3 = ((Convert.ToInt32(txtqty3.Text)) * (Convert.ToInt32(txtrate3.Text)));
            txtamount3.Text = Convert.ToString(iNetAmount3);
            int iGross1 = 0; int iGross2 = 0; int iGross3 = 0; int iGross4 = 0; int iGross5 = 0;
            if (txtamount.Text != "")
                iGross1 = Convert.ToInt32(txtamount.Text);
            if (txtamount1.Text != "")
                iGross2 = Convert.ToInt32(txtamount1.Text);
            if (txtamount2.Text != "")
                iGross3 = Convert.ToInt32(txtamount2.Text);
            if (txtamount3.Text != "")
                iGross4 = Convert.ToInt32(txtamount3.Text);
            int iTotalAmount = iGross1 + iGross2 + iGross3 + iGross4 + iGross5;
            txttotal.Text = Convert.ToString(iTotalAmount);
        }

    }
}