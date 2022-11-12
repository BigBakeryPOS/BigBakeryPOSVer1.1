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
    public partial class RegistrationForm : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            //btnadd.Attributes.Add("onclick", "return valchk();");
            DataSet ds = objBs.SelectMaxVenCode(txtvendorcode.Text);
            if (ds.Tables[0].Rows[0]["Vendorcode"].ToString() != "")
                txtvendorcode.Text = ds.Tables[0].Rows[0]["Vendorcode"].ToString();
            else
                txtvendorcode.Text = "1";
            //txtfrmdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //txttodate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            int iStatus = objBs.InsertRegistration(Convert.ToInt32(lblUserID.Text), txtvendorcode.Text, txtvendorname.Text, txtvendorname.Text, txtarea.Text, txtrateQty.Text, txtcity.Text, txtpincode.Text, txttinno.Text,  txtmobileno.Text, txtUserName.Text, txtPassword.Text);
            Response.Redirect("../Accountsbootstrap/ReceiptReport.aspx");
        }
        protected void Exit_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/ReceiptReport.aspx");
        }
    }
}