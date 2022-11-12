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
    public partial class WholeSalesPrintnew : System.Web.UI.Page
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
                sStore = Request.Cookies["userInfo"]["Store"].ToString();
                StoreNo = Request.Cookies["userInfo"]["StoreNo"].ToString();
                sAddress = Request.Cookies["userInfo"]["Address"].ToString();
                sTin = Request.Cookies["userInfo"]["TIN"].ToString();
                sfssaino = Request.Cookies["userInfo"]["fssaino"].ToString();
                Rate = Request.Cookies["userInfo"]["Rate"].ToString();
                BranchID = Request.Cookies["userInfo"]["BranchID"].ToString();
                State = "";// Request.Cookies["userInfo"]["state"].ToString();
                Statecode = "";// Request.Cookies["userInfo"]["statecode"].ToString();

                string ISalesId = Request.QueryString.Get("ISalesId");

                if (ISalesId != null)
                {
                    lblstore1.Text = sStore;
                    lblcompany.Text = sStore;
                    lblstoreno.Text = StoreNo;
                    lblAddres.Text = sAddress;
                    lbltin.Text = sTin;
                    lblfssaino.Text = sfssaino;
                    lblStatecode.Text = State;
                    lblstateno.Text = Statecode;


                    DataSet ds1 = objbs.GetSales(sTableName, Convert.ToInt32(ISalesId));

                    lblBillNo.Text = ds1.Tables[0].Rows[0]["FullBillNo"].ToString();
                    lblBillDate.Text = Convert.ToDateTime(ds1.Tables[0].Rows[0]["BillDate"]).ToString();
                    lblPayMode.Text = ds1.Tables[0].Rows[0]["Paymode1"].ToString();
                    lblCustomerName.Text = ds1.Tables[0].Rows[0]["CustomerName1"].ToString();
                    lblCustomerPhoneNo.Text = ds1.Tables[0].Rows[0]["Mobile"].ToString();
                    lblVehicleNo.Text = ds1.Tables[0].Rows[0]["VehicleNo"].ToString();
                    lblCusGSTNo.Text = ds1.Tables[0].Rows[0]["GSTNo"].ToString();

                    lblCustomerAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                    lbldcno.Text = ds1.Tables[0].Rows[0]["DCNo"].ToString();

                    lbltotalitems.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["TotalItems"]).ToString("F2");
                    double sttl = Convert.ToDouble(ds1.Tables[0].Rows[0]["Amount"].ToString());
                    lblSubtotal.Text = string.Format("{0:N2}", sttl);

                    if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscPer"]) > 0)
                    {
                        Disc.Visible = true;
                        lbldiscper.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscPer"]).ToString("f2");
                        lbldiscamt.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]).ToString("f2");
                    }
                    if (Convert.ToDouble(ds1.Tables[0].Rows[0]["Tax"]) > 0)
                    {
                        Tax.Visible = true;
                        lblTaxamount.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Tax"]).ToString("F2");
                    }
                    if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DeliveryCharge"]) > 0)
                    {
                        DeliveryCharge.Visible = true;
                        lblDeliveryCharge.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DeliveryCharge"]).ToString("f2");
                    }

                    lblgrandtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["GrandTotal"]).ToString("F2");
                    lblNarration.Text = ds1.Tables[0].Rows[0]["Narration"].ToString();

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

                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    gridprint.DataSource = ds1;
                    //    gridprint.DataBind();
                    //}
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        gridprint.DataSource = ds1;

                        DataRow dr;
                        DataTable dt;
                        dt = ds1.Tables[0];
                        for (int ii = dt.Rows.Count; ii < 14; ii++)
                        {
                            dr = dt.NewRow();
                            dt.Rows.Add(dr);
                        }
                        dt.AcceptChanges();
                        gridprint.DataSource = dt;
                        gridprint.DataBind();
                    }


                    DataSet dsGST = objbs.GetSalesGSTSummary(sTableName, Convert.ToInt32(ISalesId), ds1.Tables[0].Rows[0]["SalesType"].ToString());
                    if (dsGST.Tables[0].Rows.Count > 0)
                    {
                        gvGST.DataSource = dsGST;
                        gvGST.DataBind();
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

