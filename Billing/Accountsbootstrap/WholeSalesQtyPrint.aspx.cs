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
    public partial class WholeSalesQtyPrint : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string sfssaino = "";
        string StoreNo = "";
        string State = "";
        string StateNo = "";
        string Rate = "";
        string BranchID = "";
        string Statecode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                sTableName = Request.Cookies["userInfo"]["User"].ToString();
                //sStore = Request.Cookies["userInfo"]["Store"].ToString();
                //StoreNo = Request.Cookies["userInfo"]["StoreNo"].ToString();
                //sAddress = Request.Cookies["userInfo"]["Address"].ToString();
                //sTin = Request.Cookies["userInfo"]["TIN"].ToString();
                //sfssaino = Request.Cookies["userInfo"]["fssaino"].ToString();
                //Rate = Request.Cookies["userInfo"]["Rate"].ToString();
                //BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();
                //State = Request.Cookies["userInfo"]["state"].ToString();
                //Statecode = Request.Cookies["userInfo"]["statecode"].ToString();

                string ISalesId = Request.QueryString.Get("ISalesId");

                if (ISalesId != null)
                {
                    lblstore1.Text = sStore;
                    //lblcompany.Text = sStore;
                    //lblstoreno.Text = StoreNo;
                    //lblAddres.Text = sAddress;
                    //lbltin.Text = sTin;
                    //lblfssaino.Text = sfssaino;
                    //lblStatecode.Text = State;
                    //lblstateno.Text = Statecode;

                    DataSet ds1 = objbs.GetSales(sTableName, Convert.ToInt32(ISalesId));

                    lblBillNo.Text = ds1.Tables[0].Rows[0]["FullBillNo"].ToString();
                    lblBillDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["BillDate"]).ToString();
                    lblPayMode.Text = ds1.Tables[0].Rows[0]["Paymode1"].ToString();
                    lblCustomerName.Text = ds1.Tables[0].Rows[0]["CustomerName1"].ToString();
                    lblCustomerPhoneNo.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();

                    lblVehicleNo.Text = ds1.Tables[0].Rows[0]["VehicleNo"].ToString();

                    lblCustomerAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                    lbldcno.Text = ds1.Tables[0].Rows[0]["DCNo"].ToString();
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



    }
}

