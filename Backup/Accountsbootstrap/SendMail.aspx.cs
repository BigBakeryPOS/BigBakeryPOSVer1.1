using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows;
using System.Configuration;

namespace Billing.Accountsbootstrap
{
    public partial class SendMail : System.Web.UI.Page
    {
         BSClass objbs = new BSClass();
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();


            DataSet ds = objbs.RequestDetqqq();
            gvUserInfo.DataSource = ds;
            gvUserInfo.DataBind();
            
  


            BindGridview();
            //string caption = "Request From " + sCode + "</br>" + "Request No " + gvPurchaseEntry.Rows[0].Cells[4].Text + "</br>" + "Request Date " + Convert.ToDateTime(gvPurchaseEntry.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt");
           // gvPurchaseReqDetails.Caption = caption;
        }


        // This method is used to bind gridview from database
        protected void BindGridview()
        {
            //////SqlConnection con = new SqlConnection("Data Source=SureshDasari;Integrated Security=true;Initial Catalog=MySampleDB");
            //////con.Open();
            //////SqlCommand cmd = new SqlCommand("SELECT TOP 10 UserName,FirstName,LastName,Location FROM UserInformation", con);
            //////SqlDataAdapter da = new SqlDataAdapter(cmd);
            //////DataSet ds = new DataSet();
            //////da.Fill(ds);

            DataSet ds = objbs.RequestDetqqq();
            gvUserInfo.DataSource = ds;
            gvUserInfo.DataBind();
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            SendHTMLMail();
        }

        // Method Which is used to Get HTML File and replace HTML File values with dynamic values and send mail
        public void SendHTMLMail()
        {
            

            MailMessage Msg = new MailMessage();
           // MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
            MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress("rajar@bigdbiz.in"));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            // Subject of e-mail
            Msg.Subject = "Send Gridivew in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += GetGridviewData(gvUserInfo);
            Msg.Body += "Please check below data <br/><br/>";
            Msg.IsBodyHtml = true;
            //////string sSmtpServer = "";
            //////sSmtpServer = "587";
            //////SmtpClient a = new SmtpClient();
            //////a.Host = sSmtpServer;
            //////a.EnableSsl = true;
            //////a.Send(Msg);


            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }
        // This Method is used to render gridview control
        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}