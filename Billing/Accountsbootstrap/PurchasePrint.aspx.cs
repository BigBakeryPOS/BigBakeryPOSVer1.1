using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Text;


namespace Billing.Accountsbootstrap
{
    public partial class PurchasePrint : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();


            if (!IsPostBack)
            {
                string iPo = Request.QueryString.Get("OrderNo");
                string Type = Request.QueryString.Get("Type");

                if (iPo != null)
                {

                    DataSet ds1 = objbs.GetPoprint(sTableName, Convert.ToInt32(iPo));
                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        lblDc_No.Text = ds1.Tables[0].Rows[0]["OrderNo"].ToString();
                        lblDc_Date.Text = ds1.Tables[0].Rows[0]["OrderDate"].ToString();
                        lblcustname.Text = ds1.Tables[0].Rows[0]["ledgername"].ToString();
                        lblbillno.Text = ds1.Tables[0].Rows[0]["Bill_NO"].ToString();
                        lblarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        lblcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                        lblpin.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();
                        lblph.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                        lblMail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();


                    }
                    DataSet ds2 = objbs.GettransPoprint(sTableName, Convert.ToInt32(iPo));
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            BankGrid.DataSource = ds2;
                            BankGrid.DataBind();
                        }
                        else
                        {
                            BankGrid.DataSource = null;
                            BankGrid.DataBind();
                        }

                    }
                }

            }

        }
    }
}