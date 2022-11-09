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
using System.Data.OleDb;
using System.Configuration;

namespace Billing.Accountsbootstrap
{
    public partial class Login_Prod : System.Web.UI.Page
    {
        DBAccess db = new DBAccess();
        DataSet dsLogin = new DataSet();
        BSClass objBs = new BSClass();
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        private string connnectionString2;
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (var mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            //{
            //    foreach (ManagementObject mo in mc.GetInstances())
            //    {
            //        Console.WriteLine(mo["MacAddress"].ToString());
            //    }
            //}


            //  string externalip = new WebClient().DownloadString("http://icanhazip.com");

            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            {
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];

                macaddress.Text = ipaddress;
            }

            // GetMACAddress();
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



                Session["UserID"] = "";
                Session["UserName"] = "";
                Session["Password"] = "";
                Session["IsSuperAdmin"] = "";
                //string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                //string[] sUserDet = sUser.Split('_');
                Session["User"] = "";
                Session["Mode"] = "";
                Session["BranchCode"] = "";
                Session["Location"] = "";
                Session["UserVal"] = "";
                Session["Empid"] = "";
                Session["LoginType"] = "";
                Session["LoginTypeId"] = "";
                Session["ReportDay"] = "";
                Session["LOnlSale"] = "";
                Session["ismasterlock"] = "";
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
                //////if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                //////{

                //////    username.Text = Request.Cookies["UserName"].Value;
                //////    password.Attributes["value"] = Request.Cookies["Password"].Value;
                //////}
            }
        }




        //private string GetPublicIpAddress()
        //{
        //    string url = "http://checkip.dyndns.org";
        //    System.Net.WebRequest req = System.Net.WebRequest.Create(url);
        //    System.Net.WebResponse resp = req.GetResponse();
        //    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        //    string response = sr.ReadToEnd().Trim();
        //    string[] a = response.Split(':');
        //    string a2 = a[1].Substring(1);
        //    string[] a3 = a2.Split('<');
        //    string a4 = a3[0];
        //    return a4;
        //}
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

            Response.Cookies["UserName"].Value = username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();



            if (username.Text == "")
            {
                //  ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter Username');", true);
            }
            else if (password.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter Password');", true);
            }
            else if (txtemp.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter your Name');", true);
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

                    Session["UserVal"] = dsLogin.Tables[0].Rows[0]["UserVal"].ToString();
                    Session["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                    Session["UserName"] = username.Text;
                    Session["Password"] = password.Text;
                    Session["IsSuperAdmin"] = dsLogin.Tables[0].Rows[0]["IsSuperAdmin"].ToString();
                    Session["BranchCode"] = dsLogin.Tables[0].Rows[0]["BranchCode"].ToString();
                    Session["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                    Session["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                    Session["StoreNo"] = dsLogin.Tables[0].Rows[0]["StoreNo"].ToString();
                    Session["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();
                    string sUser = dsLogin.Tables[0].Rows[0]["Sales"].ToString();
                    string[] sUserDet = sUser.Split('_');
                    Session["User"] = sUserDet[1].ToString();
                    Session["Mode"] = "";
                    Session["Rate"] = dsLogin.Tables[0].Rows[0]["Rate"].ToString();
                    Session["OP"] = dsLogin.Tables[0].Rows[0]["OPcash"].ToString();
                    Session["location"] = dsLogin.Tables[0].Rows[0]["Location"].ToString();
                    Session["LOnlSale"] = dsLogin.Tables[0].Rows[0]["LOnlSale"].ToString();
                    Session["MOnlSale"] = dsLogin.Tables[0].Rows[0]["MOnlSale"].ToString();
                    Session["ismasterlock"] = dsLogin.Tables[0].Rows[0]["ismasterlock"].ToString();
                    Session["LBranch"] = "P";


                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserVal"] = dsLogin.Tables[0].Rows[0]["UserVal"].ToString();
                    userInfo["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                    userInfo["UserName"] = username.Text;
                    userInfo["Password"] = password.Text;
                    userInfo["IsSuperAdmin"] = dsLogin.Tables[0].Rows[0]["IsSuperAdmin"].ToString();
                    userInfo["BranchCode"] = dsLogin.Tables[0].Rows[0]["BranchCode"].ToString();
                    userInfo["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                    userInfo["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                    userInfo["StoreNo"] = dsLogin.Tables[0].Rows[0]["StoreNo"].ToString();
                    userInfo["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();
                    userInfo["User"] = sUserDet[1].ToString();
                    userInfo["Mode"] = "";
                    userInfo["Rate"] = dsLogin.Tables[0].Rows[0]["Rate"].ToString();
                    userInfo["OP"] = dsLogin.Tables[0].Rows[0]["OPcash"].ToString();
                    userInfo["location"] = dsLogin.Tables[0].Rows[0]["Location"].ToString();
                    userInfo["LOnlSale"] = dsLogin.Tables[0].Rows[0]["LOnlSale"].ToString();
                    userInfo["MOnlSale"] = dsLogin.Tables[0].Rows[0]["MOnlSale"].ToString();
                    userInfo["ismasterlock"] = dsLogin.Tables[0].Rows[0]["ismasterlock"].ToString();
                    userInfo["LBranch"] = "P";
                    //userInfo["Mtype"] = = dsLogin.Tables[0].Rows[0]["ismasterlock"].ToString();

                    // Get Branch 
                    DataSet getbranch = objBs.getbranchcode(dsLogin.Tables[0].Rows[0]["BranchCode"].ToString());
                    if (getbranch.Tables[0].Rows.Count > 0)
                    {
                        userInfo["Mtype"] = getbranch.Tables[0].Rows[0]["Mtype"].ToString();
                        Session["Mtype"] = getbranch.Tables[0].Rows[0]["Mtype"].ToString();


                        userInfo["Printtype"] = getbranch.Tables[0].Rows[0]["Printtype"].ToString();
                        Session["Printtype"] = getbranch.Tables[0].Rows[0]["Printtype"].ToString();


                        userInfo["OnlineCakeSync"] = getbranch.Tables[0].Rows[0]["OnlineCakeSync"].ToString();
                        Session["OnlineCakeSync"] = getbranch.Tables[0].Rows[0]["OnlineCakeSync"].ToString();

                        userInfo["dispatchdirect"] = getbranch.Tables[0].Rows[0]["dipatchDirectly"].ToString();
                        Session["dispatchdirect"] = getbranch.Tables[0].Rows[0]["dipatchDirectly"].ToString();

                        userInfo["fssaino"] = getbranch.Tables[0].Rows[0]["fssaino"].ToString();
                        Session["fssaino"] = getbranch.Tables[0].Rows[0]["fssaino"].ToString();

                        userInfo["onlinepos"] = getbranch.Tables[0].Rows[0]["onlinepos"].ToString();
                        Session["onlinepos"] = getbranch.Tables[0].Rows[0]["onlinepos"].ToString();


                    }
                    else
                    {
                        userInfo["Mtype"] = "Nil";
                        Session["Mtype"] = "Nil";

                        userInfo["Printtype"] = "N";
                        Session["Printtype"] = "N";

                        userInfo["OnlineCakeSync"] = "N";
                        Session["OnlineCakeSync"] = "N";

                        userInfo["dispatchdirect"] = "N";
                        Session["dispatchdirect"] = "N";

                        userInfo["fssaino"] = "Nil";
                        Session["fssaino"] = "Nil";

                        userInfo["onlinepos"] = "N";
                        Session["onlinepos"] = "N";

                    }

                    DataSet bill = objBs.Biller(Session["User"].ToString(), txtemp.Text);
                    if (bill.Tables[0].Rows.Count > 0)
                    {
                        Session["ReportDay"] = bill.Tables[0].Rows[0]["Reportdays"].ToString();
                        Session["Biller"] = bill.Tables[0].Rows[0]["Name"].ToString();
                        Session["Empid"] = bill.Tables[0].Rows[0]["Empid"].ToString();
                        Session["empcode"] = txtemp.Text;
                        Session["BranchID"] = bill.Tables[0].Rows[0]["BranchID"].ToString();
                        Session["LoginType"] = bill.Tables[0].Rows[0]["LogintypeName"].ToString();
                        string logintypeid = bill.Tables[0].Rows[0]["Logintype"].ToString();
                        Session["LoginTypeId"] = logintypeid;


                        userInfo["ReportDay"] = bill.Tables[0].Rows[0]["Reportdays"].ToString();
                        userInfo["Biller"] = bill.Tables[0].Rows[0]["Name"].ToString();
                        userInfo["Empid"] = bill.Tables[0].Rows[0]["Empid"].ToString();
                        userInfo["empcode"] = txtemp.Text;
                        userInfo["BranchID"] = bill.Tables[0].Rows[0]["BranchID"].ToString();
                        userInfo["LoginType"] = bill.Tables[0].Rows[0]["LogintypeName"].ToString();
                        userInfo["LoginTypeId"] = logintypeid;

                        DataSet getbranchid = objBs.getbranchid(bill.Tables[0].Rows[0]["BranchID"].ToString());
                        if (getbranchid.Tables[0].Rows.Count > 0)
                        {
                            Session["BranchType"] = getbranchid.Tables[0].Rows[0]["BranchOwnType"].ToString();
                            userInfo["BranchType"] = getbranchid.Tables[0].Rows[0]["BranchOwnType"].ToString();

                            Session["BType"] = getbranchid.Tables[0].Rows[0]["BranchType"].ToString();
                            userInfo["BType"] = getbranchid.Tables[0].Rows[0]["BranchType"].ToString();

                        }

                        userInfo.Expires.AddYears(4);
                        Response.Cookies.Add(userInfo);

                        if (logintypeid == null || logintypeid == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Login Type Not Set For This Employeecode.Thank You!!!.');", true);
                            return;
                        }
                        else if (logintypeid == "1" || logintypeid == "1")
                        {
                            Response.Redirect("../Accountsbootstrap/Home_Page.aspx");
                        }
                        else if (logintypeid == "2")
                        {
                            Response.Redirect("../Accountsbootstrap/Home_Page.aspx");
                        }
                        else if (logintypeid == "3")
                        {
                            Response.Redirect("../Accountsbootstrap/newbutton.aspx");
                        }
                        else if (logintypeid == "4")
                        {
                            Response.Redirect("../Accountsbootstrap/Home_Page.aspx");
                        }
                        else if (logintypeid == "5")
                        {
                            Response.Redirect("../Accountsbootstrap/Home_Page.aspx");
                        }
                        else if (logintypeid == "6" || logintypeid == "7" || logintypeid == "8" || logintypeid == "1007")
                        {
                            Response.Redirect("../Accountsbootstrap/HomePage.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Invalid Employee Code Or Else Login Type Invalid');", true);
                        return;
                    }

                }

            }

        }

        protected void Registration_Form(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/RegistrationForm.aspx");
        }
    }
}