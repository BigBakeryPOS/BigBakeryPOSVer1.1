using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class Support : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();



        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            DataSet ds = objBs.checkmailID(Convert.ToInt32(lblUserID.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Scheck = ds.Tables[0].Rows[0]["username"].ToString();
                if (txtusermailid.Text == Scheck)
                {
                    //var fromAddress = "pratheepkumar@onlinehanger.com";
                    //var toAddress = "harishbabu@bigdbiz.com";
                    ////const string fromPassword = "online@123";
                    //const string fromPassword = "!@#$%6qaz";
                    //string subject = "test subject";
                    //string body = "From: Pratheep ";
                    //var smtp = new System.Net.Mail.SmtpClient();
                    //{
                    //    //smtp.Host = "mail.onlinehanger.com";
                    //    smtp.Host = "mail.onlinehanger.com";
                    //    //smtp.Port = 25;
                    //    smtp.Port = 465;
                    //    smtp.EnableSsl = false;
                    //    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    //    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    //    smtp.Timeout = 200000;


                    //}
                    //smtp.Send(fromAddress, toAddress, subject, body);
                    //email codes ends here
                    objBs.InsertSupport(txtusermailid.Text, txtmessage.Text);
                }
                else
                {
                    lblerror.InnerText = "Please Enter Valid Email";
                }
            }
        }
    }
}