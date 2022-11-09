using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class ProduuctionStockDetails : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {


                DataSet ds = objBs.StockDetailsforRawitems("tblRawMatlStockProduction_" + sTableName);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BankGrid.DataSource = ds;
                        BankGrid.DataBind();
                    }
                    else
                    {
                        BankGrid.DataSource = null;
                        BankGrid.DataBind();
                    }
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