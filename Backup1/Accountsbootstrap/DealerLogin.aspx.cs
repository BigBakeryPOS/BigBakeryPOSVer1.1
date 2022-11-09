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
    public partial class DealerLogin : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


       

        protected void btnsave_Click(object sender, EventArgs e)
        {
            DataSet ds = objbs.DealerLoginCheck(txtUsername.Text, txtpass.Text);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["Dealer"] = txtUsername.Text;
                Response.Redirect("DealerOrder.aspx");
            }
            else
            {
                Response.Write("<script>  alert('Login Failed') </script>");
            }
        }
    }
}