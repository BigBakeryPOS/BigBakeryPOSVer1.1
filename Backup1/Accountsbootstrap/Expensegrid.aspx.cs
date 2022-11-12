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
    public partial class Expensegrid : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        DateTime TodayDate = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                txtFrom.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txtTo.Text = DateTime.Today.ToString("yyyy-MM-dd");
                  

                   ds = objbs.paymentgrid(sTableName, TodayDate);
                    gridledger.DataSource = ds;
                    gridledger.DataBind();
                    decimal dtotal = 0;
                    for (int i = 0; i < gridledger.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gridledger.Rows[i].Cells[4].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
               
            }

        }

        protected void Add_Click(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expense.aspx");
        }

       

        protected void btnExport_Click(object sender, EventArgs e)
        {

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= ExpenseGrid.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            div2.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            //DataSet dt = new DataSet();
            //GridView gridview = new GridView();

            //dt = objbs.SearchLedgerByDate(txtFrom.Text, txtTo.Text, sTableName);
            //gridledger.DataSource = dt;
            //gridledger.DataBind();
            //decimal dtotal = 0;
            //for (int i = 0; i < gridledger.Rows.Count; i++)
            //{
            //    dtotal += Convert.ToDecimal(gridledger.Rows[i].Cells[4].Text);
            //}
            //decimal Total = dtotal;
            //lblTotal.InnerText = Total.ToString();
            //gridview.Caption = "Expense Details Branch :  " + sTableName + " From " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy");

            
           
            //string filename = "ExpenseReport.xls";
            //System.IO.StringWriter tw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //DataGrid dgGrid = new DataGrid();
            //dgGrid.Caption = "Expense Details Branch :  " + sTableName + " From " + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy");
            //dgGrid.DataSource = dt;
            //dgGrid.DataBind();
            //dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            //dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            //dgGrid.HeaderStyle.Font.Bold = true;
            ////Get the HTML for the control.
            //dgGrid.RenderControl(hw);
            ////Write the HTML back to the browser.
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            //this.EnableViewState = false;
            //Response.Write(tw.ToString());
            //Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet dser = objbs.SearchLedgerByDate(txtFrom.Text, txtTo.Text, sTableName);
            gridledger.DataSource = dser;
            gridledger.DataBind();
            decimal dtotal = 0;
            for (int i = 0; i < gridledger.Rows.Count; i++)
            {
                dtotal += Convert.ToDecimal(gridledger.Rows[i].Cells[4].Text);
            }
            decimal Total = dtotal;
            lblTotal.InnerText = Total.ToString();
        }

        protected void gridledger_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            DataSet ds  = objbs.paymentgrid(sTableName, TodayDate);
            gridledger.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gridledger.DataSource = dvEmployee;
            gridledger.DataBind();
            decimal dtotal = 0;
            for (int i = 0; i < gridledger.Rows.Count; i++)
            {
                dtotal += Convert.ToDecimal(gridledger.Rows[i].Cells[4].Text);
            }
            decimal Total = dtotal;
            lblTotal.InnerText = Total.ToString();
        }

        protected void gridledger_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int iDelete=objbs.DelPayment(sTableName,Convert.ToInt32(e.CommandArgument.ToString()));
                Response.Redirect("Expensegrid.aspx");
            }
        }
    }
}