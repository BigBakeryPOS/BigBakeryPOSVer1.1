using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class PrintSalesVat : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string branchcode = "";
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string cancelno1 = "";
        int cancelno = 0;
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            branchcode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sStore = Request.Cookies["userInfo"]["Store"].ToString();
            sAddress = Request.Cookies["userInfo"]["Address"].ToString();
            sTin = Request.Cookies["userInfo"]["TIN"].ToString();
            if (!IsPostBack)
            {

            string iSalesDate = Request.QueryString.Get("iSalesDate");
            if (iSalesDate != null)
            {

                DataSet ds1 = objbs.SalesVatReport1(Convert.ToInt32(lblUserID.Text), sTableName, iSalesDate);
                DataSet ds2 = objbs.SalesVatReport2(Convert.ToInt32(lblUserID.Text), sTableName, iSalesDate);
                DataSet ds3 = objbs.SalesVatReport3(Convert.ToInt32(lblUserID.Text), sTableName, iSalesDate);


                DataSet dsdisc = objbs.Salesdiscamt(Convert.ToInt32(lblUserID.Text), sTableName, iSalesDate);
                decimal disc = 0;

                for (int i = 0; i < dsdisc.Tables[0].Rows.Count; i++)
                {
                    disc = disc + Convert.ToDecimal(dsdisc.Tables[0].Rows[i]["discount"].ToString());
                }

                lbldiscsmt.Text = disc.ToString("f2");

                lbltotalamtzero.Text = ds1.Tables[0].Rows[0]["Amount"].ToString();
                lblvatamtzero.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();

                lbltotalamtfive.Text = ds2.Tables[0].Rows[0]["Amount"].ToString();
                lblvatamtfive.Text = ds2.Tables[0].Rows[0]["Vat"].ToString();

                lbltotalamteighteen.Text = ds3.Tables[0].Rows[0]["Amount"].ToString();
                lblvatamteighteen.Text = ds3.Tables[0].Rows[0]["Vat"].ToString();


                lbltotalamtzero.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Amount"]).ToString("f2");
                lblvatamtzero.Text = Convert.ToDecimal(ds1.Tables[0].Rows[0]["Vat"]).ToString("f2");

                lbltotalamtfive.Text = Convert.ToDecimal(ds2.Tables[0].Rows[0]["Amount"]).ToString("f2");
                lblvatamtfive.Text = Convert.ToDecimal(ds2.Tables[0].Rows[0]["Vat"]).ToString("f2");

                lbltotalamteighteen.Text = Convert.ToDecimal(ds3.Tables[0].Rows[0]["Amount"]).ToString("f2");
                lblvatamteighteen.Text = Convert.ToDecimal(ds3.Tables[0].Rows[0]["Vat"]).ToString("f2");

                lblfinaltotal.Text = ((Convert.ToDecimal(lbltotalamtzero.Text) + Convert.ToDecimal(lblvatamtzero.Text) + Convert.ToDecimal(lbltotalamtfive.Text) + Convert.ToDecimal(lblvatamtfive.Text) + Convert.ToDecimal(lbltotalamteighteen.Text) + Convert.ToDecimal(lblvatamteighteen.Text)) - Convert.ToDecimal(lbldiscsmt.Text)).ToString();
                //Roundoff
                double finaltot = 0;
                double roundoff1 = Convert.ToDouble(lblfinaltotal.Text) - Math.Floor(Convert.ToDouble(lblfinaltotal.Text));
                if (roundoff1 >= 0.5)
                {
                    finaltot = Math.Round(Convert.ToDouble(lblfinaltotal.Text), MidpointRounding.AwayFromZero);
                }
                else
                {
                    finaltot = Math.Floor(Convert.ToDouble(lblfinaltotal.Text));
                }

                lblfinaltotal.Text = string.Format("{0:N2}", finaltot);


                lblcanDate.Text = iSalesDate;
                lblAddres.Text = sAddress;
                lbltin.Text = sTin;
                if (sTableName.ToLower() == "co8")
                {
                    lblpvtltd.Visible = true;
                    lblstore.Text = "(" + sStore + ")";
                }
                else
                {
                    lblpvtltd.Visible = false;
                    lblstore.Text = sStore;
                }
            }
            }
        }
    }
}