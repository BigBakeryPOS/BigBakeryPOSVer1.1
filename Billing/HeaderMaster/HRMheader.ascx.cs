using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billing.HeaderMaster
{
    public partial class HRMheader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserID.Text = Request.Cookies["userInfo"]["empid"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblServiceID.Text = Request.Cookies["userInfo"]["serviceID"].ToString();

            if (Convert.ToInt32(lblUserID.Text) == 7)
            {
                master.Visible = true;
                leaveform.Visible = false;
                Attendence.Visible = true;
            }

            else
            {
                master.Visible = false;
                leaveform.Visible = true;
                Attendence.Visible = false;
                Dash.Visible = false;
            }
        }
    }
}