using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class GoodsTransferReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string scode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {

                DataSet dsCategory = objbs.selectcategorymasterforproductionentry();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                }

                DataSet dsCustomer = objbs.getbranchforhomepage();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlBranch.DataSource = dsCustomer.Tables[0];
                    ddlBranch.DataTextField = "brancharea";
                    ddlBranch.DataValueField = "branchname";
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, "All");
                }



                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
                string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

                DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
                string sTodate = dtTodate.ToString("yyyy-MM-dd");

                //  if (scode == "Production")
                {
                    // DataSet dT = objbs.GetTrasfDet(gdate);
                    DataSet dT = objbs.getstocktransferreport( ddlcategory.SelectedValue, sFromdate, sTodate, scode);
                    if (dT.Tables[0].Rows.Count > 0)
                    {
                        gvTransfer.DataSource = dT;
                        gvTransfer.DataBind();
                    }
                    else
                    {
                        gvTransfer.DataSource = null;
                        gvTransfer.DataBind();
                    }
                }
               
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //  if (sCode == "Production" || sCode == "Production2")
            {
                DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
                string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

                DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
                string sTodate = dtTodate.ToString("yyyy-MM-dd");

                DataSet dT = objbs.getstocktransferreport(ddlcategory.SelectedValue, sFromdate, sTodate, scode);
                if (dT.Tables[0].Rows.Count > 0)
                {
                    gvTransfer.DataSource = dT;
                    gvTransfer.DataBind();
                }
                else
                {
                    gvTransfer.DataSource = null;
                    gvTransfer.DataBind();
                }
                gvTransfer.Caption = "From :" + Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + "To :" + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy") + "-" + "Goods Transfer Detailed  Report";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            DataSet dT = objbs.getstocktransferreport(ddlcategory.SelectedValue, sFromdate, sTodate, scode);
            if (dT.Tables[0].Rows.Count > 0)
            {
                gvTransfer.DataSource = dT;
                gvTransfer.DataBind();
            }
            else
            {
                gvTransfer.DataSource = null;
                gvTransfer.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            DataSet dT = objbs.getstocktransferreport(ddlcategory.SelectedValue, sFromdate, sTodate, scode);
            if (dT.Tables[0].Rows.Count > 0)
            {
                gvTransfer.DataSource = dT;
                gvTransfer.DataBind();
            }
            else
            {
                gvTransfer.DataSource = null;
                gvTransfer.DataBind();
            }

           
        }

        protected void gvGoodTransFer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           

        }

        protected void gvTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}