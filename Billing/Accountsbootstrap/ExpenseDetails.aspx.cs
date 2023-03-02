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
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;
using System.Globalization;


namespace Billing.Accountsbootstrap
{
    public partial class ExpenseDetails : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";

        double TotalAmount = 0;
        double GrandTotal = 0;
        double grandRecQty = 0;
        double GrandTotalmssing = 0;
        double GrandTotaldamage = 0;
        double GrandTotalAmount = 0;
        double GrandDamage = 0;
        double Discount = 0; double Receipt = 0;
        double EGrandTotal = 0; double EDiscount = 0; double EReceipt = 0;
        double EGrandDamageQty = 0;

        string brach = string.Empty;
        DateTime frmdate = new DateTime();
        DateTime todate = new DateTime();

        System.Globalization.CultureInfo Cul = new System.Globalization.CultureInfo("en-GB", true);
        protected void Page_Load(object sender, EventArgs e)
        {



            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            if (!IsPostBack)
            {
                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet ds1 = objBs.ledgerGen(sTableName);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //txtentry.Text = ds1.Tables[0].Rows[0]["ledgerGen"].ToString();
                    ds1 = objBs.ledgeridretrive("3");
                    ddlExpense.DataSource = ds1;
                    ddlExpense.DataValueField = "LedgerId";
                    ddlExpense.DataTextField = "LedgerName";
                 
                    ddlExpense.DataBind();
                    ddlExpense.Items.Insert(0, "All");
                }

                // DataSet ds = objBs.StockDetailsforRawitems("tblRawMatlStock_" + sTableName);

               
            }
            ddltype_SelectedIndexChanged(sender, e);

        }
            protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (ddltype.SelectedValue == "1")
                {
                    //entry.Visible = false;
                   // cat.Visible = false;
                   // ind.Visible = false;
                }
                else
                {
                   //// entry.Visible = false;
                    //cat.Visible = false;
                   // ind.Visible = true;
                }
            }



        protected void btnsearch_Click(object sender, EventArgs e)
        {
            search(sender, e);
        }

        protected void search(object sender, EventArgs e)
        {

            frmdate = DateTime.Parse(txtfromdate.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            todate = DateTime.Parse(txttodate.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


            //DataSet ds = objBs.getreportforkitchenusage(sTableName, ddltype.SelectedValue, ddldcno.SelectedValue, frmdate, todate, ddlCategory.SelectedValue, ddlIngridients.SelectedValue);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    gvsales.DataSource = ds;
            //    gvsales.DataBind();
            //}
            //else
            //{
            //    gvsales.DataSource = null;
            //    gvsales.DataBind();
            //}

            if (rdodetailed.Checked == true)
            {
                DataSet ds = objBs.getreportforExpenseDetails(sTableName, ddltype.SelectedValue,ddlExpense.SelectedValue, frmdate, todate);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }
                btnPrintDetails.Visible = true;
                btnPrintSummary.Visible = false;
                Details.Visible = true;
                gvsales.Visible = true;
                Summary.Visible = false;
                gvsummary.Visible = false;

                gvsales.Caption = "Expense Report From " + frmdate + " To " + todate;
            }
            else if (rdosummary.Checked == true)
            {
                //  DataSet ds = objBs.getreportforkitchenusage_Summary(sTableName, ddltype.SelectedValue, ddldcno.SelectedValue, frmdate, todate, ddlCategory.SelectedValue, ddlIngridients.SelectedValue, drpdept.SelectedValue);
                DataSet ds = objBs.getreportforExpenseSummary(sTableName, ddltype.SelectedValue,ddlExpense.SelectedValue, frmdate, todate);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsummary.DataSource = ds;
                    gvsummary.DataBind();

                }
                else
                {
                    gvsummary.DataSource = null;
                    gvsummary.DataBind();
                }
                gvsummary.Caption = "Expense Report From " + frmdate + " To " + todate;
                gvsummary.Visible = true;
                gvsales.Visible = false;
                Details.Visible = false;
                Summary.Visible = true;
                btnPrintDetails.Visible = false;
                btnPrintSummary.Visible = true;
            }
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            if (rdodetailed.Checked==true)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename= ExepenseDetailedReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                Details.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            if (rdosummary.Checked  ==true )
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename= ExpenseSummaryReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                Summary.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }

            //GridView gridview = new GridView();

            //DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DataSet ds1 = new DataSet();
            //if (ddltype.SelectedItem.Text == "Summary")
            //{
            //    ds1 = objBs.getreportforExpenseSummary(sTableName, ddltype.SelectedValue, ddlExpense.SelectedValue, frmdate, todate);
            //}
            //else if (ddltype.SelectedItem.Text == "Detailed")
            //{
            //    ds1 = objBs.getreportforExpenseDetails(sTableName, ddltype.SelectedValue, ddlExpense.SelectedValue, frmdate, todate);
            //}

            //if (ds1.Tables[0].Rows.Count > 0)
            //{
            //    gridview.DataSource = ds1;
            //    gridview.DataBind();
            //}
            //else
            //{
            //    gridview.DataSource = null;
            //    gridview.DataBind();
            //}


            //gridview.Caption = "Expense Report";

            //Response.ClearContent();
            //Response.AddHeader("content-disposition",
            //    "attachment;filename=KitchenUsageReport.xls");
            //Response.ContentType = "applicatio/excel";
            //StringWriter sw = new StringWriter(); ;
            //HtmlTextWriter htm = new HtmlTextWriter(sw);
            //gridview.AllowPaging = false;
            //gridview.RenderControl(htm);
            //Response.Write(sw.ToString());
            //Response.End();
            //gridview.AllowPaging = true;
        }
        private void ExportToExcel(string filename, DataSet dt)
        {
            if (dt.Tables[0].Rows.Count > 0)
            {
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();

                string caption = "From :" + txtfromdate.Text + "To" + txttodate.Text + "For:" + ddlExpense.SelectedItem.Text;
                dgGrid.Caption = caption;
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                dgGrid.FooterStyle.ForeColor = System.Drawing.Color.Red;
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
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GrandTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                //grandRecQty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Recqty"));
                //GrandTotalmssing += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MissingQty"));
                //GrandTotaldamage += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DamageQty"));
                //GrandTotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Total :";
                e.Row.Cells[4].Text = GrandTotal.ToString("f2");
                //e.Row.Cells[8].Text = grandRecQty.ToString("f2");
                //e.Row.Cells[9].Text = GrandTotalmssing.ToString("f2");
                //e.Row.Cells[10].Text = GrandTotaldamage.ToString("f2");
              //  e.Row.Cells[13].Text = GrandTotalAmount.ToString("f2");

            }
        }

        protected void gvs_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // GrandTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "acceptqty"));
                TotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
               // e.Row.Cells[3].Text = GrandTotal.ToString("f2");
                e.Row.Cells[2].Text = TotalAmount.ToString("f2");


            }
        }
       
    }
}