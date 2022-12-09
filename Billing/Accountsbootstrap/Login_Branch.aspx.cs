using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Management;
using DataLayer;
using System.Data.OleDb;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Billing.Accountsbootstrap
{
    public partial class Login_Branch : System.Web.UI.Page
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


            DataSet dsLogin = objBs.LoginImage();

            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                log.ImageUrl = dsLogin.Tables[0].Rows[0]["Imagepath"].ToString();
            }

            IDOtpEnter.Visible = false;
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
                Session["Billcode"] = "";
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

        protected void btnSeeting_OnClick(object sender, EventArgs e)
        {
            txtEmail.Visible = false;
            txtEmail.Text= "rajaram@bigdbiz.in";
            UserName_OnTextChanged(sender, e);
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
                   // Session["Billcode"] = dsLogin.Tables[0].Rows[0]["Billcode"].ToString();
                    

                    //Session["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                    //Session["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                    //Session["StoreNo"] = dsLogin.Tables[0].Rows[0]["StoreNo"].ToString();
                    //Session["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();

                    string code = dsLogin.Tables[0].Rows[0]["BranchCode"].ToString();
                    Session["BranchCode"] = dsLogin.Tables[0].Rows[0]["BranchCode"].ToString();

                    DataSet dsbranch = objBs.getbranchcode(code);
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {

                        Session["Store"] = dsbranch.Tables[0].Rows[0]["BranchName"].ToString();
                        Session["Address"] = dsbranch.Tables[0].Rows[0]["Address"].ToString();
                        Session["StoreNo"] = dsbranch.Tables[0].Rows[0]["MobileNo"].ToString();
                        Session["TIN"] = dsbranch.Tables[0].Rows[0]["GSTIN"].ToString();
                        Session["Country"] = dsbranch.Tables[0].Rows[0]["Country"].ToString();
                        //Session["NoOfBranch"] = dsbranch.Tables[0].Rows[0]["NoOfBranch"].ToString();
                    }

                    else
                    {
                        Session["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                        Session["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                        Session["StoreNo"] = dsLogin.Tables[0].Rows[0]["StoreNo"].ToString();
                        Session["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();
                        Session["Country"] = "Others";
                    }


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
                    Session["LBranch"] = "B";
                    Session["state"] = 0;
                    Session["statecode"] = 0;


                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserVal"] = dsLogin.Tables[0].Rows[0]["UserVal"].ToString();
                    userInfo["UserID"] = dsLogin.Tables[0].Rows[0]["UserID"].ToString();
                    userInfo["UserName"] = username.Text;
                    userInfo["Password"] = password.Text;
                    userInfo["IsSuperAdmin"] = dsLogin.Tables[0].Rows[0]["IsSuperAdmin"].ToString();
                    userInfo["BranchCode"] = dsLogin.Tables[0].Rows[0]["BranchCode"].ToString();
                    //userInfo["Billcode"] = dsLogin.Tables[0].Rows[0]["Billcode"].ToString();

                    //userInfo["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                    //userInfo["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                    //userInfo["StoreNo"] = dsLogin.Tables[0].Rows[0]["StoreNo"].ToString();
                    //userInfo["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();

                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        userInfo["Store"] = dsbranch.Tables[0].Rows[0]["BranchName"].ToString();
                        userInfo["Address"] = dsbranch.Tables[0].Rows[0]["Address"].ToString();
                        userInfo["StoreNo"] = dsbranch.Tables[0].Rows[0]["MobileNo"].ToString();
                        userInfo["TIN"] = dsbranch.Tables[0].Rows[0]["GSTIN"].ToString();
                        userInfo["Country"] = dsbranch.Tables[0].Rows[0]["Country"].ToString();

                         
                       
                    }

                    else
                    {
                        userInfo["Store"] = dsLogin.Tables[0].Rows[0]["StoreName"].ToString();
                        userInfo["Address"] = dsLogin.Tables[0].Rows[0]["Address"].ToString();
                        userInfo["StoreNo"] = dsLogin.Tables[0].Rows[0]["StoreNo"].ToString();
                        userInfo["TIN"] = dsLogin.Tables[0].Rows[0]["TIN"].ToString();
                        userInfo["Country"] = "";

                    }
                    userInfo["User"] = sUserDet[1].ToString();
                    userInfo["Mode"] = "";
                    userInfo["Rate"] = dsLogin.Tables[0].Rows[0]["Rate"].ToString();
                    userInfo["OP"] = dsLogin.Tables[0].Rows[0]["OPcash"].ToString();
                    userInfo["location"] = dsLogin.Tables[0].Rows[0]["Location"].ToString();
                    userInfo["LOnlSale"] = dsLogin.Tables[0].Rows[0]["LOnlSale"].ToString();
                    userInfo["MOnlSale"] = dsLogin.Tables[0].Rows[0]["MOnlSale"].ToString();
                    userInfo["ismasterlock"] = dsLogin.Tables[0].Rows[0]["ismasterlock"].ToString();
                    userInfo["LBranch"] = "B";

                    userInfo["state"] = dsLogin.Tables[0].Rows[0]["state"].ToString();
                    userInfo["statecode"] = dsLogin.Tables[0].Rows[0]["Statecode"].ToString();

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

                        userInfo["PrintOption"] = getbranch.Tables[0].Rows[0]["PrintOption"].ToString();
                        Session["PrintOption"] = getbranch.Tables[0].Rows[0]["PrintOption"].ToString();

                        userInfo["StockOption"] = getbranch.Tables[0].Rows[0]["StockOption"].ToString();
                        Session["StockOption"] = getbranch.Tables[0].Rows[0]["StockOption"].ToString();


                        userInfo["BillCode"] = getbranch.Tables[0].Rows[0]["BillCode"].ToString();
                        Session["BillCode"] = getbranch.Tables[0].Rows[0]["BillCode"].ToString();


                        userInfo["BillGenerateSetting"] = getbranch.Tables[0].Rows[0]["BillGenerateSetting"].ToString();
                        Session["BillGenerateSetting"] = getbranch.Tables[0].Rows[0]["BillGenerateSetting"].ToString();


                        userInfo["Billtaxsplitupshown"] = getbranch.Tables[0].Rows[0]["Billtaxsplitupshown"].ToString();
                        Session["Billtaxsplitupshown"] = getbranch.Tables[0].Rows[0]["Billtaxsplitupshown"].ToString();


                        userInfo["BillPrintLogo"] = getbranch.Tables[0].Rows[0]["BillPrintLogo"].ToString();
                        Session["BillPrintLogo"] = getbranch.Tables[0].Rows[0]["BillPrintLogo"].ToString();


                        userInfo["TaxSetting"] = getbranch.Tables[0].Rows[0]["TaxSetting"].ToString();
                        Session["TaxSetting"] = getbranch.Tables[0].Rows[0]["TaxSetting"].ToString();


                        userInfo["Ratesetting"] = getbranch.Tables[0].Rows[0]["Ratesetting"].ToString();
                        Session["Ratesetting"] = getbranch.Tables[0].Rows[0]["Ratesetting"].ToString();


                        userInfo["Qtysetting"] = getbranch.Tables[0].Rows[0]["Qtysetting"].ToString();
                        Session["Qtysetting"] = getbranch.Tables[0].Rows[0]["Qtysetting"].ToString();

                        userInfo["BigVersion"] = getbranch.Tables[0].Rows[0]["BigVersion"].ToString();
                        Session["BigVersion"] = getbranch.Tables[0].Rows[0]["BigVersion"].ToString();

                        userInfo["Currency"] = getbranch.Tables[0].Rows[0]["Currency"].ToString();
                        Session["Currency"] = getbranch.Tables[0].Rows[0]["Currency"].ToString();

                        userInfo["possalessetting"] = getbranch.Tables[0].Rows[0]["possalessetting"].ToString();
                        Session["possalessetting"] = getbranch.Tables[0].Rows[0]["possalessetting"].ToString();

                        userInfo["RoundoffSetting"] = getbranch.Tables[0].Rows[0]["RoundoffSetting"].ToString();
                        Session["RoundoffSetting"] = getbranch.Tables[0].Rows[0]["RoundoffSetting"].ToString();

                        userInfo["QtyFillSetting"] = getbranch.Tables[0].Rows[0]["QtyFillSetting"].ToString();
                        Session["QtyFillSetting"] = getbranch.Tables[0].Rows[0]["QtyFillSetting"].ToString();

                        userInfo["Posattendercheck"] = getbranch.Tables[0].Rows[0]["Posattendercheck"].ToString();
                        Session["Posattendercheck"] = getbranch.Tables[0].Rows[0]["Posattendercheck"].ToString();

                        userInfo["posPrintsetting"] = getbranch.Tables[0].Rows[0]["posPrintsetting"].ToString();
                        Session["posPrintsetting"] = getbranch.Tables[0].Rows[0]["posPrintsetting"].ToString();

                        userInfo["OrderBookcheck"] = getbranch.Tables[0].Rows[0]["OrderBookcheck"].ToString();
                        Session["OrderBookcheck"] = getbranch.Tables[0].Rows[0]["OrderBookcheck"].ToString();



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

                        userInfo["PrintOption"] = "Nil";
                        Session["PrintOption"] = "Nil";

                        userInfo["StockOption"] = "Nil";
                        Session["StockOption"] = "Nil";


                        userInfo["BillCode"] = "Big";
                        Session["BillCode"] = "Big";


                        userInfo["BillGenerateSetting"] = "2";
                        Session["BillGenerateSetting"] = "2";


                        userInfo["Billtaxsplitupshown"] = "Y";
                        Session["Billtaxsplitupshown"] = "Y";


                        userInfo["BillPrintLogo"] = "N";
                        Session["BillPrintLogo"] = "N";


                        userInfo["TaxSetting"] = "O";
                        Session["TaxSetting"] = "O";


                        userInfo["Ratesetting"] = "0.00";
                        Session["Ratesetting"] = "0.00";


                        userInfo["Qtysetting"] = "0.00";
                        Session["Qtysetting"] = "0.00";

                        userInfo["BigVersion"] = "1";
                        Session["BigVersion"] = "1";

                        userInfo["Currency"] ="INR(Rs.)";
                        Session["Currency"] = "INR(Rs.)";

                        userInfo["possalessetting"] = "D";
                        Session["possalessetting"] = "D";

                        userInfo["RoundoffSetting"] = "WG";
                        Session["RoundoffSetting"] = "WG";


                        userInfo["QtyFillSetting"] = "Y";
                        Session["QtyFillSetting"] = "Y";

                        userInfo["Posattendercheck"] = "N";
                        Session["Posattendercheck"] = "N";

                        userInfo["posPrintsetting"] = "1";
                        Session["posPrintsetting"] = "1";

                        userInfo["OrderBookcheck"] = "N";
                        Session["OrderBookcheck"] = "N";


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
                        Session["AllBranchAccess"] = bill.Tables[0].Rows[0]["AllBranchAccess"].ToString();


                        userInfo["ReportDay"] = bill.Tables[0].Rows[0]["Reportdays"].ToString();
                        userInfo["Biller"] = bill.Tables[0].Rows[0]["Name"].ToString();
                        userInfo["Empid"] = bill.Tables[0].Rows[0]["Empid"].ToString();
                        userInfo["empcode"] = txtemp.Text;
                        userInfo["BranchID"] = bill.Tables[0].Rows[0]["BranchID"].ToString();
                        userInfo["LoginType"] = bill.Tables[0].Rows[0]["LogintypeName"].ToString();
                        userInfo["LoginTypeId"] = logintypeid;
                        userInfo["AllBranchAccess"] = bill.Tables[0].Rows[0]["AllBranchAccess"].ToString();


                        if (txtEmail.Text != "rajaram@bigdbiz.in")
                        {
                            DataSet dsLogin1 = objBs.GetSetting();

                            if (dsLogin1.Tables[0].Rows.Count > 0)
                            {

                                // DateTime fromdate = DateTime.Parse(Convert.ToDateTime(dsLogin1.Tables[0].Rows[0]["ToDate"].ToString()).ToShortDateString());
                                // DateTime todate = DateTime.Parse(Convert.ToDateTime(DateTime.Now.ToString()).ToShortDateString());


                                string Fdate = dsLogin1.Tables[0].Rows[0]["ToDate"].ToString();
                                string Tdate = DateTime.Now.ToString("yyyy/MM/dd");


                                Fdate = Decrypt(Fdate);



                                if (Convert.ToDateTime(Fdate) < Convert.ToDateTime(Tdate))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Your Big POS Software License Expired, Please Contact Bigdbiz Solutions.');", true);
                                    return;
                                }

                                //Response.Cookies.Add(userInfo);

                                //Response.Redirect("../Accountsbootstrap/Homepage.aspx");
                            }
                        }


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

                        //if (txtEmail.Text == "rajaram@bigdbiz.in")
                        //{
                        //    Response.Redirect("../Accountsbootstrap/AdminSetting.aspx");
                        //}

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
                            Response.Redirect("../Accountsbootstrap/Home.aspx");
                        }
                        else if (logintypeid == "3")
                        {
                            Response.Redirect("../Accountsbootstrap/HomePage.aspx");
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
                            Response.Redirect("../Accountsbootstrap/Home_Page.aspx");
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

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void UserName_OnTextChanged(object sender, EventArgs e)
        {

            if (txtEmail.Text == "rajaram@bigdbiz.in")
            {
                IDOtpEnter.Visible = false;
                btnOTP.Visible = true;
                btnComplete.Visible = false;
                btn.Visible = false;
                password.Focus();


            }

            else
            {
                IDOtpEnter.Visible = false;
                btnOTP.Visible = false;
                btnComplete.Visible = false;
                btn.Visible = true;
                password.Focus();

            }

          
        }


        public string randomOTP = "";
        protected void btnOTPClick(object sender, EventArgs e)
        {



            btnOTP.Visible = false;
            txtOTP.Focus();
            btnComplete.Visible = true;
            IDOtpEnter.Visible = true;
            txtOTP.Visible = true;

            StringBuilder sbmail3 = new StringBuilder();
            randomOTP = CreateRandomPassword(4);

            #region EMailFormat-OTP
            string EmailOTP = "";

            EmailOTP = "rajaram@bigdbiz.in";
            sbmail3.Append("<div style='border='0' width='100%'>");
            sbmail3.Append("<table width='100%' border='0' style='padding:13px; border: 1px solid red;'><tr><td>");
            sbmail3.Append("<p align='center'><img align=\"center\" alt=\"\" src=\"cid:Pic1\" width=\"147\" style=\"max-width:147px; padding-bottom: 0; display: inline !important; vertical-align: bottom;\" class=\"mcnImage\"></p>");
            sbmail3.Append("<p>Dear <strong>" + "Sir/Madam" + "</strong>,</p>");
            sbmail3.Append("<br>");
            sbmail3.Append("<p>Proceed to confirm your Login with the OTP given.</p>");
            sbmail3.Append("<br>");
            sbmail3.Append("<h3>Your OTP is : " + randomOTP + "</h3>");
            sbmail3.Append("<br>");
            sbmail3.Append("<br>");

            sbmail3.Append("</td>");
            sbmail3.Append("</tr>");
            sbmail3.Append("</table>");
            sbmail3.Append("</div>");

            int isuces = objBs.InsertOTPDetails("rajaram@bigdbiz.in", randomOTP);

            sendpasswordemailOTPNew(EmailOTP, sbmail3.ToString());



            // updPnl.Update();
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('OTP Sent Your MailID. Please Enter your OTP.');", true);

            // upotp.Update();
            // return;
            #endregion


            btnOTP.Visible = false;
            txtOTP.Focus();
            btnComplete.Visible = true;
            IDOtpEnter.Visible = true;

        }
        public static void sendpasswordemailOTPNew(string UserEmail, string Message)
        {
            try
            {
                string StmpHost = ConfigurationManager.AppSettings["EmailHost"].ToString();
                string StmpUserName = ConfigurationManager.AppSettings["AdminEmailID"].ToString();
                string StmpPassword = ConfigurationManager.AppSettings["AdminPassword"].ToString();
                int StmpPort = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"]);


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(StmpHost);
                mail.From = new MailAddress(StmpUserName, "Bigdbiz");
                mail.To.Add(UserEmail);
                mail.To.Add(StmpUserName);
                mail.Subject = "BIGDBIZ : OTP Verification";

                //AlternateView avHtml = AlternateView.CreateAlternateViewFromString("<img alt='BrownieHeaven' src=\"cid:Pic1\" height='15%' width='50%' >", null, MediaTypeNames.Text.Html);
                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(Message, null, MediaTypeNames.Text.Html);

                LinkedResource img = new LinkedResource(HttpContext.Current.Server.MapPath("../img/footer/logo.png"), MediaTypeNames.Image.Jpeg);
                img.ContentId = "Pic1";
                avHtml.LinkedResources.Add(img);


                mail.AlternateViews.Add(avHtml);
                //mail.AlternateViews.Add(avHtml1);
                mail.IsBodyHtml = true;


                //mail.Body = Message;
                mail.IsBodyHtml = true;
                SmtpServer.Port = StmpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(StmpUserName, StmpPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                mail.Dispose();


            }
            catch (Exception ex)
            {

            }
        }

        public static string CreateRandomPassword(int PasswordLength)
        {
            //string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            string _allowedChars = "0123456789";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        string randomOTPCheck = "";

        protected void btnComplete_OnClick(object sender, EventArgs e)
        {
            if (txtOTP.Text != "")
            {
                DataSet dsOTPCheck = objBs.CheckOTP("rajaram@bigdbiz.in", txtOTP.Text);

                if (dsOTPCheck.Tables[0].Rows.Count > 0)
                {
                    randomOTPCheck = Convert.ToString(dsOTPCheck.Tables[0].Rows[0]["OTP"].ToString());
                }
                else
                {
                    randomOTPCheck = "";
                }

                if (randomOTPCheck == txtOTP.Text)
                {
                    DataSet dsOTPDelete = objBs.DeleteOTP();


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Your OTP Verfied Successfully.');", true);

                    /////////raja

                    

                    txtOTP.Text = "";
                    txtOTP.Visible = false;
                    btnComplete.Visible = false;
                    btnOTP.Visible = false;
                    btn.Visible = true;
                    IDOtpEnter.Visible = false;
                    txtEmail.Visible = false;
                    username.Focus();

                    Response.Redirect("../Accountsbootstrap/CompanyDetailGrid.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Valied OTP.');", true);
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Your OTP.');", true);
                return;
            }


        }
    }
}