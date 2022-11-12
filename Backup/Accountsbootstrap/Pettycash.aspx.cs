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
namespace Billing.Accountsbootstrap
{
    public partial class Pettycash : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            string Recipi_Id = Request.QueryString.Get("Recipi_Id");
            if (Recipi_Id != "" || Recipi_Id != null)
            {
                DataSet ds = objBs.getreciptid(Recipi_Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtreciptno.Text = ds.Tables[0].Rows[0]["ReceiptID"].ToString();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            objBs.insertpettycash( txtamtfrom.Text, txtdate.Text, txtamount.Text, txtdescp.Text,txtreciptno.Text, txtname.Text);
            StringBuilder sb = new StringBuilder();
            sb.Append("From Bigdbiz-");
            sb.Append("Amount Received From =" + txtamtfrom.Text + ",");
            sb.Append("TotalAmount=Rs. " + txtamount.Text + "");


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://sms.f9cs.com/sendsms.jsp?user=pratheep&password=demo1234&mobiles=&senderid=FINECS&sms=" + sb.ToString() + "");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            Response.Redirect("pettygrid.aspx");
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("pettygrid.aspx");
        }
    }
}