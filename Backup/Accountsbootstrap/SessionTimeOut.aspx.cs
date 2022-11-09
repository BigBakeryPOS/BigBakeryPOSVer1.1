using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billing.Accountsbootstrap
{
    public partial class SessionTimeOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void link_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_Branch.aspx");
        }
    }
}