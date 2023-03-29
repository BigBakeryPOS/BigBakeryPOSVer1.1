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
    public partial class StockAuditReport : System.Web.UI.Page
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

            if (sTableName != "admin")
            {
                admin.Visible = false;
            }
            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet dsCategory = objBs.GetCategoryDetails();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlSubCategory.DataSource = dsCategory.Tables[0];
                    ddlSubCategory.DataTextField = "Definition";
                    ddlSubCategory.DataValueField = "categoryuserid";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, "All");
                }
                txtFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //DateTime.Now.AddDays(7)
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void Btn_Search(object sender, EventArgs e)
        {
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            DataSet getitemlist = objBs.getstockauditreport(ddlSubCategory.SelectedValue, txtFrom.Text, txttodate.Text, sTableName);
            if (getitemlist.Tables[0].Rows.Count > 0)
            {
                GVStockAlert.DataSource = getitemlist.Tables[0];
                GVStockAlert.DataBind();
                caption.InnerText = StoreName + " " + BranchNAme + " Stock Audit Detailed Report from " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("dd/MM/yyyy");
            }
            else
            {
                GVStockAlert.DataSource = null;
                GVStockAlert.DataBind();

            }



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Branch = "";


            caption.InnerText  = StoreName+ " "+ BranchNAme + " Stock Audit Detailed Report from " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtFrom.Text).ToString("dd/MM/yyyy");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename= GRNReport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //div1.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {

            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txttodate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txttodate.Text = "";
                }
            }
        }
    }
}