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
namespace Billing.Accountsbootstrap
{
    public partial class ReceiptReport : System.Web.UI.Page
    {
          string sTablename = "";
        string Sort_Direction = "ReceiptDate ASC";
        string Sort_Direction1 = "CustomerName ASC";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
              lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                 sTablename = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                if (sTablename == "admin")
                {     
                 
                DataSet dAdmin = objBs.getReceiptDetAdmin();
                gvReceiptReport.DataSource = dAdmin;
                gvReceiptReport.DataBind();

              
                }
                else
                {

                  
                }

               
            }
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
           

        }

        

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            GridView gvReceipt = new GridView();
            gvReceipt.DataSource = objBs.Getreceiptreport_Dealer("tblReceipt_" + sTablename, "tblTransReceipt_" + sTablename);
            gvReceipt.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=Receiptreport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gvReceipt.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
          
        }

        protected void gvReceipt_Sorting(object sender, GridViewSortEventArgs e)
        {
          
        }

        protected void gvReceiptReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void ddselect_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationForm.aspx");
        }
    }
}