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
namespace Billing.Accountsbootstrap
{
    public partial class DealerLoginSales : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

            if (!IsPostBack)
            {

                DataSet dDealer = objbs.dealerLoginSales(Convert.ToInt32(lblUserID.Text));
                gvDealersales.DataSource = dDealer.Tables[0];
                gvDealersales.DataBind();
            }
        }
    }
}