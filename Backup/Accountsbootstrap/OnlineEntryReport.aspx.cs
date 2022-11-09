using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class OnlineEntryReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string Password = "";
        string BranchNAme = "";
        string StoreName = "";

        double unitprice = 0, Qty = 0, subtotal = 0, gstamount = 0, totalvalue = 0, commamount = 0, commgstamnt = 0, gatwaycharge = 0, grandtot = 0, discvalue = 0;


        double GTax = 0;
        double GNetAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);
            Label123.Text = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet getsalestype = objbs.GetSalesTypeForSales_normal("N");
                if (getsalestype.Tables[0].Rows.Count > 0)
                {
                    drpsalestype.DataSource = getsalestype.Tables[0];
                    drpsalestype.DataTextField = "PaymentType";
                    drpsalestype.DataValueField = "SalesTypeID";
                    drpsalestype.DataBind();
                    drpsalestype.Items.Insert(0, "All");
                }


                txtfromdate.Enabled = true;
                txttodate.Enabled = true;
               
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString() ;
                txtfromdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                DataSet dsbranch = objbs.getbranchFilling_New("0", "Y");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpbranch.DataSource = dsbranch.Tables[0];
                    drpbranch.DataTextField = "BranchArea";
                    drpbranch.DataValueField = "BranchCode";
                    drpbranch.DataBind();
                    drpbranch.Items.Insert(0, "All");
                }
            }
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            gvdetailed.Visible = false;
            gvsummary.Visible = false;

            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
            DateTime sTo = Convert.ToDateTime(txttodate.Text);
            if (radbtn.SelectedValue == "1")
            {
                gvdetailed.Visible = true;
                lblCaption.Text = "Online Sales Report For :  " + drpbranch.SelectedItem.Text + "  from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                DataSet dcustbranch = objbs.OnlineReport(drpbranch.SelectedValue, sFrom, sTo, drpsalestype.SelectedValue);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    gvdetailed.DataSource = dcustbranch;
                    gvdetailed.DataBind();
                }
                else
                {
                    gvdetailed.DataSource = null;
                    gvdetailed.DataBind();

                }
            }
            else if (radbtn.SelectedValue == "2")
            {
                gvsummary.Visible = true;

                lblCaption.Text = "Online Sales Summary Report For :  " + drpbranch.SelectedItem.Text + "  from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                DataSet dcustbranch = objbs.OnlineReport_summary(drpbranch.SelectedValue, sFrom, sTo, drpsalestype.SelectedValue);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    gvsummary.DataSource = dcustbranch;
                    gvsummary.DataBind();
                }
                else
                {
                    gvsummary.DataSource = null;
                    gvsummary.DataBind();

                }
            }


        }

        

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            //DataSet dCustReport = objbs.CustomerSalesAdmin();
            //gvCustsales.DataSource = dCustReport.Tables[0];
            //gvCustsales.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= OnlineSalesReport"+drpbranch.SelectedItem+".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            divPrint.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnExport_ClickOld(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            GridView gridview = new GridView();
            int sbranch = Convert.ToInt32(drpbranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            string name = string.Empty;



            gridview.Caption = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");


            string filename = "";
          
            {
                filename = "OnlineSalesReport.xls";

            }
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.Caption = "Store :  " + BranchNAme + " " + StoreName + " Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            dgGrid.HeaderStyle.Font.Bold = true;
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
           


        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {

        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


           

        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {
               
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
           

            lblCaption.Text = "Store :" + BranchNAme + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //if (radbtnlist.SelectedValue == "1")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridSummary", "printGridSummary();", true);
            //}
            //else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridDetails", "printGridDetails();", true);

            }
        }


        public void gvdetailed_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            

        }
        public void gvsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {

           

        }
    }
}