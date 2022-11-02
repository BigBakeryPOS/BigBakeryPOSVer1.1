using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
namespace Billing.Accountsbootstrap
{

    public partial class AddIP : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = objbs.iplist();
            gvip.DataSource = ds.Tables[0];
            gvip.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            objbs.Inserip(txtid.Text);
            txtid.Text = "";
            DataSet ds = objbs.iplist();
            gvip.DataSource = ds.Tables[0];
            gvip.DataBind();
        }
    }
}