using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Management;
using DataLayer;
namespace Billing.Accountsbootstrap
{
    public partial class Index : System.Web.UI.Page
    {
        DBAccess dbObj = new DBAccess();
        DataSet dsLogin = new DataSet();
        BSClass objBs = new BSClass();
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        

        protected void Page_Load(object sender, EventArgs e)
        {
         
            GetMACAddress();
            try
            {
                string userip = Request.UserHostAddress;
                string strClientIP = Request.UserHostAddress.ToString().Trim();
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");
                if (mac_src == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                    }
                    //   Response.Write("visited Localhost!");
                    else
                    {
                    }
                    //  Response.Write("the IP from" + userip + "" + "<br>");
                    // return;
                }

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                string mac_dest = "";

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }

                //Response.Write("welcome" + userip + "<br>" + ",the mac address is" + mac_dest + "."

                // + "<br>");

            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }



            if (!IsPostBack)
            {
                dbObj.whre("Chennai");

                Session["UserID"] = "";
                Session["UserName"] = "";
                Session["IsSuperAdmin"] = "";
                //string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                //string[] sUserDet = sUser.Split('_');
                Session["User"] = "";
                Session["Mode"] = "";
                Session["BranchCode"] = "";
                Session["Location"] = "";
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
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {

                    username.Text = Request.Cookies["UserName"].Value;
                    password.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }


        protected void Registration_Form(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/RegistrationForm.aspx");
        }


        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }

            }
            macaddress.Text = sMacAddress;
            return sMacAddress;


        }




        protected void LoginButton_Click(object sender, EventArgs e)
        {
            dbObj.whre("Chennai");
            Response.Cookies["UserName"].Value = username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();




            //Dealer
            DataSet GetDealerid = objBs.GetDealerID(username.Text);
            if (GetDealerid.Tables[0].Rows.Count > 0)
            {
                Session["UserID"] = GetDealerid.Tables[0].Rows[0]["CustomerID"].ToString();
                Session["UserName"] = GetDealerid.Tables[0].Rows[0]["CustomerName"].ToString();
                Session["IsSuperAdmin"] = "2";//dealer
                Session["Mode"] = "";
                Server.Transfer("DealerStockView.aspx");

            }

            else
            {
                dsLogin = objBs.Login(username.Text, password.Text);

                if (dsLogin.Tables[0].Rows.Count == 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Login Failed');", true);

                }
                else
                {
                    if (dsLogin.Tables[0].Rows[0]["Status"].ToString() == "Web")
                    {
                        Session["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                        Session["UserName"] = username.Text;
                        Session["IsSuperAdmin"] = dsLogin.Tables[0].Rows[0]["IsSuperAdmin"].ToString();
                        Session["BranchCode"] = dsLogin.Tables[0].Rows[0]["BranchCode"].ToString();
                        Session["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                        Session["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                        Session["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();
                        string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                        string[] sUserDet = sUser.Split('_');
                        Session["User"] = sUserDet[1].ToString();
                        Session["Mode"] = "";
                        Session["Rate"] = dsLogin.Tables[0].Rows[0]["Rate"].ToString();
                        Session["OP"] = dsLogin.Tables[0].Rows[0]["OPcash"].ToString();
                        Session["location"] = dsLogin.Tables[0].Rows[0]["Location"].ToString();

                        // Response.Redirect("../AccountsPage/categorygrid.aspx");
                        Response.Redirect("../Accountsbootstrap/Home_Page.aspx");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('You are logged with windows please transfer to web to Login');", true);

                    }
                }
            }


        }
    }
}