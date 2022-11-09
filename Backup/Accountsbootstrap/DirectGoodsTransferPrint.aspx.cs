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
    public partial class DirectGoodsTransferPrint : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string TIN = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                sTableName = Request.Cookies["userInfo"]["User"].ToString();
                sStore = Request.Cookies["userInfo"]["Store"].ToString();
                sAddress = Request.Cookies["userInfo"]["Address"].ToString();
                TIN = Request.Cookies["userInfo"]["TIN"].ToString();


                string ISalesId = Request.QueryString.Get("ISalesId");

                if (ISalesId != null)
                {
                    lblAddres.Text = TIN;
                    lblstore.Text = sStore;



                    string[] arg = new string[2];
                    arg = ISalesId.ToString().Split(';');
                    string DcNo = arg[0];
                    string Branch = arg[1];
                    string Date = Convert.ToDateTime(arg[2]).ToString("dd/MM/yyyy h:mm tt");
                    DataSet ds = new DataSet();
                    //if (scode == "Production")
                    //{
                    ds = objbs.GoodTrasnferListExp_Report(DcNo, sTableName);
                    //}
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblBillNo.Text = ds.Tables[0].Rows[0]["Dc_NO"].ToString();
                        lblBillDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dc_date"]).ToString("dd/MMM/yyyy h:mm:tt");
                        lblPayMode.Text = ds.Tables[0].Rows[0]["sentby"].ToString();
                        lbltrip.Text = ds.Tables[0].Rows[0]["Tripno"].ToString();

                        lblCustomerName.Text = ds.Tables[0].Rows[0]["BranchArea"].ToString();
                        lblCustomerPhoneNo.Text = ds.Tables[0].Rows[0]["Mobileno"].ToString();

                        lblgrandtotal.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["totamnt"]).ToString("F2");

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



                        DataSet ditem = objbs.TransGoodTrasnferListExp_Report(DcNo, sTableName);
                        if (ditem.Tables[0].Rows.Count > 0)
                        {

                            if (ditem.Tables[0].Rows.Count > 0)
                            {
                                gridprint.DataSource = ditem;
                                gridprint.DataBind();

                            }
                        }



                    }



                    //  DataSet ds1 = objbs.GetSales(sTableName, Convert.ToInt32(ISalesId));





                    //lblCustomerAddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();

                    // lblSubtotal.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Amount"]).ToString("F2");
                    // lblTaxamount.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["Tax"]).ToString("F2");


                    // lbltotalitems.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["TotalItems"]).ToString("F2");
                    //if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscPer"]) > 0)
                    //{
                    //    discper.Visible = true;
                    //    discamt.Visible = false;

                    //    lbldiscper.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscPer"]).ToString("f2");
                    //}
                    //else if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]) > 0)
                    //if (Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]) > 0)
                    //{
                    //    discper.Visible = false;
                    //    discamt.Visible = true;

                    //    lbldiscamt.Text = Convert.ToDouble(ds1.Tables[0].Rows[0]["DiscAmount"]).ToString("f2");
                    //}
                    //else
                    //{
                    //    discper.Visible = false;
                    //    discamt.Visible = false;

                    //}






                }
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("DirectGoodsTransferGrid.aspx");

        }

        protected void gvregs_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridprint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}

