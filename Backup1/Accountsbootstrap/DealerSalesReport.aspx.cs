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
    public partial class DealerSalesReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    DataSet dd = objbs.Dealerbillgrid();
                    gvDealersales.DataSource = dd.Tables[0];
                    gvDealersales.DataBind();
                }
                else
                {
                    DataSet dd = objbs.Dealerbillgrid();
                    gvDealersales.DataSource = dd.Tables[0];
                    gvDealersales.DataBind();

                }

                DataSet dealet = objbs.DealerList();
                ddlBranch.DataSource = dealet.Tables[0];
                ddlBranch.DataTextField = "VendorName";
                ddlBranch.DataValueField = "VendorCode";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, "Select Dealer");
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dcustbranch = objbs.Dealerbillgridsearch(Convert.ToInt32( ddlBranch.SelectedValue));
            gvDealersales.DataSource = dcustbranch.Tables[0];
            gvDealersales.DataBind();
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            DataSet dcustbranch = objbs.DealerbillgridsearchDate(Convert.ToInt32(ddlBranch.SelectedValue),txtfrom.Text,txtto.Text);
            gvDealersales.DataSource = dcustbranch.Tables[0];
            gvDealersales.DataBind();
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            DataSet dd = objbs.Dealerbillgrid();
            gvDealersales.DataSource = dd.Tables[0];
            gvDealersales.DataBind();

        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= DealerSalesReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvDealersales.RenderControl(htmlWrite);
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