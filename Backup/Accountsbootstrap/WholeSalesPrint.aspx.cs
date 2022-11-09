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
    public partial class WholeSalesPrint : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                sTableName = Session["User"].ToString();
                sStore = Session["Store"].ToString();
                sAddress = Session["Address"].ToString();

                string ISalesId = Request.QueryString.Get("ISalesId");

                if (ISalesId != null)
                {
                    lblAddres.Text = sAddress;
                    lblstore.Text = sStore;

                    DataSet ds1 = objbs.GetSales(sTableName, Convert.ToInt32(ISalesId));

                    lblBillNo.Text = ds1.Tables[0].Rows[0]["BillNo"].ToString();
                    lblBillDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["BillDate"]).ToString();
                    lblPayMode.Text = ds1.Tables[0].Rows[0]["Paymode1"].ToString();
                    lblCustomerName.Text = ds1.Tables[0].Rows[0]["CustomerName1"].ToString();
                    lblCustomerPhoneNo.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();

                    lblCustomerAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();

                    lblSubtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Amount"]).ToString("F2");
                    lblTaxamount.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Tax"]).ToString("F2");
                    lblgrandtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["GrandTotal"]).ToString("F2");

                    lbltotalitems.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["TotalItems"]).ToString("F2");
                    //if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscPer"]) > 0)
                    //{
                    //    discper.Visible = true;
                    //    discamt.Visible = false;

                    //    lbldiscper.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscPer"]).ToString("f2");
                    //}
                    //else if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]) > 0)
                    if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]) > 0)
                    {
                        discper.Visible = false;
                        discamt.Visible = true;

                        lbldiscamt.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]).ToString("f2");
                    }
                    else
                    {
                        discper.Visible = false;
                        discamt.Visible = false;

                    }

                    double r;
                    double roundoff = Convert.ToDouble(lblgrandtotal.Text) - Math.Floor(Convert.ToDouble(lblgrandtotal.Text));
                    if (roundoff >= 0.5)
                    {
                        r = Math.Round(Convert.ToDouble(lblgrandtotal.Text), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        r = Math.Floor(Convert.ToDouble(lblgrandtotal.Text));
                    }
                    lblgrandtotal.Text = string.Format("{0:N2}", r);

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
            Response.Redirect("Salesgrid.aspx");

        }

        protected void gvregs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridprint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}

