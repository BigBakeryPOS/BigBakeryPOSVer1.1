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
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net;


namespace Billing.Accountsbootstrap
{
    public partial class CustomerCeremoniesReminder : System.Web.UI.Page
    {
        string Sort_Direction1 = "CustomerName ASC";
        string sCode;
        BSClass objBs = new BSClass();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                ViewState["SortExpr"] = Sort_Direction1;
                sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
                //DataSet dContact = objBs.contactType();
                //ddsrchby.DataSource = dContact.Tables[0];
                //ddsrchby.DataTextField = "ContactType";
                //ddsrchby.DataValueField = "ContactID";

                //ddsrchby.DataBind();
                //ddsrchby.Items.Insert(0, "Select Contact");

                DataSet ds = objBs.GetCustomerCeremoniesReminder(sCode);
                gvcust.DataSource = ds;
                gvcust.DataBind();
            }
        }




        protected void btnSMS_Click(object sender, EventArgs e)
        {
            string strEmail = string.Empty;
            foreach (GridViewRow rw in gvcust.Rows)
            {
                CheckBox chkBx = (CheckBox)rw.FindControl("rdSend");
                if (chkBx != null && chkBx.Checked)
                {
                    if (rbSMS.Checked == true)
                    {
                        string Mobile = Convert.ToString(rw.Cells[2].Text);
                        SendSMS(Mobile);
                    }
                    else
                    {
                        string Email = Convert.ToString(rw.Cells[4].Text);
                        Response.Write(Email);
                    }

                }
            }
        }

        private void SendSMS(string sMobileNo)
        {
        //    string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=YourUserName:YourPassword&senderID=YourSenderID&    receipientno=1234567890&msgtxt=This is a test from mVaayoo API&state=4";
        //    // Create a request object  
        //    WebRequest request = HttpWebRequest.Create(strUrl);
        //    // Get the response back  
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream s = (Stream)response.GetResponseStream();
        //    StreamReader readStream = new StreamReader(s);
        //    string dataString = readStream.ReadToEnd();
        //    response.Close();
        //    s.Close();
        //    readStream.Close();
        //}
        StringBuilder sb = new StringBuilder();
            sb.Append("From Pranav Cards-");
            sb.Append(txtMessage.Text);
            //sb.Append("TotalAmount=Rs. " + txtgrandtotal.Text + "");


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.f9cs.com/sendsms.jsp?user=pratheep&password=demo1234&mobiles=9843566688&senderid=FINECS&sms=" + sb.ToString() + "");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            Response.Redirect("Successfull.aspx");

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //DataSet dSelect = objBs.CustomerReport(Convert.ToInt32(ddsrchby.SelectedValue));
            //gvcust.DataSource = dSelect;
            //gvcust.DataBind();
        }

        protected void gvcust_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objBs.selectcustomer();
            gvcust.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gvcust.DataSource = dvEmployee;
            gvcust.DataBind();
        }

        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvcust.HeaderRow.FindControl("chkboxSelectAll");
            foreach (GridViewRow row in gvcust.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("rdSend");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }

        protected void gvcust_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}