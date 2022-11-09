using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billing.Accountsbootstrap
{
    public partial class Successfull : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblReport.Text = "Your Message Sent Successfully! ";
        }

        protected void btnDivert_Click(object sender, EventArgs e)
        {
            Response.Redirect("Send_Message.aspx");
        }
    }
}