using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string Empid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblusername.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Cookies["Password"].Value = txtoldpw.Text. Trim();

            DataSet ds = new DataSet();
            ds = objBs.checkpass_Toemployeecode(txtoldpw.Text,Empid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Password mismatch, Please try Again!');", true);
                return;
            }

            DataSet dsuserspass = objBs.updateuserspassword(txtrepw.Text, Empid);
            if (dsuserspass.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('This Password already Exists. Please enter a new one')", true);
                return;
            }

            if (txtnewpw.Text == txtrepw.Text)
            {
                int isucess = 0;
                isucess = objBs.updatepass_ToEmpCode(txtrepw.Text, lblusername.Text,Empid);
                Response.Redirect("../Accountsbootstrap/login1.aspx");
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('New Password and Confirm Password mismatch, Please try Again!');", true);
                
            }
            
        }

      

    }
}