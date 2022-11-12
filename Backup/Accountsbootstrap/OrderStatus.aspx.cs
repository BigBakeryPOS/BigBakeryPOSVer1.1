using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;
namespace Billing.Accountsbootstrap
{
    public partial class OrderStatus : System.Web.UI.Page
    {BSClass objbs=new BSClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
        lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
        if (!IsPostBack)
        {
            DataSet ds = objbs.orderStatus(Convert.ToInt32(lblUserID.Text));
            gvStatus.DataSource = ds.Tables[0];
            gvStatus.DataBind();
        }
    }
    }
}