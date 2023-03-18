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
                    ddlBranch.DataValueField = "branchcode";
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
                    DataSet dT = objbs.getstocktransferreport( ddlBranch.SelectedValue ,ddlcategory.SelectedValue, sFromdate, sTodate, scode);
                    if (dT.Tables[0].Rows.Count > 0)
                    {
                        gvTransfer.DataSource = dT;
                        gvTransfer.DataBind();
                        gvTransfer.Caption = "Goods Transfer/Damage/Missing Details Report for" + ddlBranch.SelectedItem.Text + "Branch and " + ddlcategory.SelectedItem.Text + "Group from " + Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
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

                DataSet dT = objbs.getstocktransferreport (ddlBranch.SelectedValue ,  ddlcategory.SelectedValue, sFromdate, sTodate, scode);
                if (dT.Tables[0].Rows.Count > 0)
                {
                    gvTransfer.DataSource = dT;
                    gvTransfer.DataBind();
                    // lblcaption.Visible = true;
                    // lblcaption.Text = " Goods Transfer/Damage/Missing Details Report for" + ddlBranch.SelectedItem.Text + ddlcategory.SelectedItem.Text +Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + "to" + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
                    gvTransfer.Caption = "Goods Transfer/Damage/Missing Details Report for " + ddlBranch.SelectedItem.Text + " Branch and " + ddlcategory.SelectedItem.Text + " Group from " + Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
                }
                else
                {
                    gvTransfer.DataSource = null;
                    gvTransfer.DataBind();
                }
               
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            DataSet dT = objbs.getstocktransferreport(ddlBranch.SelectedValue , ddlcategory.SelectedValue, sFromdate, sTodate, scode);
            if (dT.Tables[0].Rows.Count > 0)
            {
                gvTransfer.DataSource = dT;
                gvTransfer.DataBind();
               // lblcaption.Visible = true;
                gvTransfer.Caption = "Goods Transfer/Damage/Missing Details Report for " + ddlBranch.SelectedItem.Text + " Branch and " + ddlcategory.SelectedItem.Text + " Group from " + Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
                // lblcaption.Text = " Goods Transfer/Damage/Missing Details Report for" + ddlBranch.SelectedItem.Text+" Branch" + ddlcategory.SelectedItem.Text+ " Group" +Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + "to" + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
            }
            else
            {
                gvTransfer.DataSource = null;
                gvTransfer.DataBind();
                lblcaption.Visible = false;
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            DataSet dT = objbs.getstocktransferreport(ddlBranch.SelectedValue , ddlcategory.SelectedValue, sFromdate, sTodate, scode);
            if (dT.Tables[0].Rows.Count > 0)
            {
                gvTransfer.DataSource = dT;
                gvTransfer.DataBind();
                //lblcaption.Visible = true;
                gvTransfer.Caption = "Goods Transfer/Damage/Missing Details Report for " + ddlBranch.SelectedItem.Text + " Branch and " + ddlcategory.SelectedItem.Text + " Group from " + Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
                //lblcaption.Text = " Goods Transfer/Damage/Missing Details Report for" + ddlBranch.SelectedItem.Text +" Branch" + ddlcategory.SelectedItem.Text +" Group" +Convert.ToDateTime(txtDate.Text).ToString("dd/MM/yyyy") + "to" + Convert.ToDateTime(txtToDate.Text).ToString("dd/MM/yyyy");
            }
            else
            {
                gvTransfer.DataSource = null;
                gvTransfer.DataBind();
            }

           
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= GoodsTransferReport.xls");
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


        protected void gvGoodTransFer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           

        }

        protected void gvTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}