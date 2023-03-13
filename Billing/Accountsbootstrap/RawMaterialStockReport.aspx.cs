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
    public partial class RawMaterialStockReport: System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sCode = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);

            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

           
            if (!IsPostBack)
            {

                DataSet dsCustomer = objBs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "All");
                }

                DataSet dsIngredien = objBs.GetIngredientall();
                if (dsIngredien.Tables[0].Rows.Count > 0)
                {
                    ddlraw.DataSource = dsIngredien.Tables[0];
                    ddlraw.DataTextField = "IngredientName";
                    ddlraw.DataValueField = "IngridID";
                    ddlraw.DataBind();
                    ddlraw.Items.Insert(0, "All");
                }

                DataSet dssubcompany = objBs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    drpsubcompany.DataSource = dssubcompany.Tables[0];
                    drpsubcompany.DataTextField = "CustomerName1";
                    drpsubcompany.DataValueField = "subComapanyID";
                    drpsubcompany.DataBind();
                    drpsubcompany.Items.Insert(0, "All");
                }

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

           


                DataTable dt = objBs.getreportforRawmaterialstock(ddlsuplier.SelectedValue,ddlraw.SelectedValue ,drpsubcompany.SelectedValue , Convert.ToDateTime(txtfromdate.Text), sCode);
                if (dt.Rows.Count > 0)
                {
                    BankGrid.DataSource = dt;
                BankGrid.DataBind();

                   
                }
                else
                {
                BankGrid.DataSource = null;
                BankGrid.DataBind();
                }
            
          
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string caption = BranchNAme + " Stock Detailed Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") ;
            BankGrid.Caption = caption;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= RawMaterialStockReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Div1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    }
}