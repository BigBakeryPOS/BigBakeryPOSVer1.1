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
    public partial class Amount : System.Web.UI.Page
    {
        string sStore = "";
        string sAddress = "";
        string sTableName = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sStore = Request.Cookies["userInfo"]["Store"].ToString();
            sAddress = Request.Cookies["userInfo"]["Address"].ToString();
           
            if (!IsPostBack)
            {
                int OrderNo = Convert.ToInt32(Request.QueryString.Get("OrderNo"));


                DataSet ds = objbs.orderDetails(sTableName, OrderNo);
                ViewState["custid"] = ds.Tables[0].Rows[0]["customerid"].ToString();
                custname.Text = ds.Tables[0].Rows[0]["customername"].ToString();
                ViewState["bookno"] = ds.Tables[0].Rows[0]["bookno"].ToString();
                lblBokno.Text = ds.Tables[0].Rows[0]["bookno"].ToString();




            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            Print.Visible = true;
            int OrderNo = Convert.ToInt32(Request.QueryString.Get("OrderNo"));
            if (ddlopt.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('select a Option');", true);
            }
            else if (txtamt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Amount');", true);
            }
            else if (DropDownList1.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Select Payment Mode');", true);
            }
            else
            {

                decimal cr = 0;
                decimal dr = 0;
                int custi = Convert.ToInt32(ViewState["custid"].ToString());
                string bookno = ViewState["bookno"].ToString(); 
                if (ddlopt.SelectedItem.Text == "Add +")
                    cr = Convert.ToDecimal(txtamt.Text);
                else
                    dr = Convert.ToDecimal(txtamt.Text);
               int no= objbs.CrDr(cr, dr, DateTime.Now.ToString("yyyy-MM-dd"), custi, bookno, DropDownList1.SelectedValue, sTableName,OrderNo);

                lblstore.Text = sStore;
                lblAddres.Text = sAddress;
                lblName.Text = custname.Text;
                Receiptno.InnerText = no.ToString();
                lblDate.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
                lblord.Text = lblBokno.Text;
                lblrupees.InnerText = txtamt.Text;
                if (ddlopt.SelectedItem.Text == "Add +")
                    reson.InnerText = "Received";
                else
                    reson.InnerText = "Refund";

                paymode.InnerText = DropDownList1.SelectedItem.Text;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "Denomination();", true);
                  
            }
            
        }
    }
}