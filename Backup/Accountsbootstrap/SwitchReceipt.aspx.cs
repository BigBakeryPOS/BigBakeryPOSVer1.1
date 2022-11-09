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
    public partial class SwitchReceipt : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Branch(object sender, EventArgs e)
        {
            
        }

        protected void btnswitch_Click(object sender, EventArgs e)
        {
            string sMode = Session["User"].ToString();
            if (ddlBranch.SelectedValue == "1")
            {
                DataSet dsLogin = objBs.Login("Branch1@gmail.com", "Branch1");
                Session["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                Session["UserName"] = "Branch1@gmail.com";
                string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                string[] sUserDet = sUser.Split('_');
                Session["User"] = sUserDet[1].ToString();
            }
            else if (ddlBranch.SelectedValue == "2")
            {
                DataSet dsLogin = objBs.Login("Branch2@gmail.com", "Branch2");
                Session["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                Session["UserName"] = "Branch2@gmail.com";
                string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                string[] sUserDet = sUser.Split('_');
                Session["User"] = sUserDet[1].ToString();
            }

            else
            {
                DataSet dsLogin = objBs.Login("Branch3@gmail.com", "Branch3");
                Session["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                Session["UserName"] = "Branch3@gmail.com";
                string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                string[] sUserDet = sUser.Split('_');
                Session["User"] = sUserDet[1].ToString();
            }
            Session["Mode"] = "Switch";
            Response.Redirect("../Accountsbootstrap/receiptpage.aspx?From=" + sMode + "");
        }
    }
}