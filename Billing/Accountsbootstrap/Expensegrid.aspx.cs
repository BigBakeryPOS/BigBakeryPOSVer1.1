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
using System.Globalization;
using Microsoft.Office.Interop.Excel;

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
               DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "PaymentEntry");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "PaymentEntry");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnsave.Visible = true;
                    }
                    else
                    {
                        btnsave.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                       // gridledger.Columns[8].Visible = true;
                    }
                    else
                    {
                       // gridledger.Columns[8].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gridledger.Columns[5].Visible = true;
                    }
                    else
                    {
                        gridledger.Columns[5].Visible = false;
                    }
                }

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

                #region Add expense Page 
                
                DateTime sDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtdate.Text = sDate.ToString("dd/MM/yyyy");
                DataSet ds1 = objbs.ledgerGen(sTableName);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //txtentry.Text = ds1.Tables[0].Rows[0]["ledgerGen"].ToString();
                    ds1 = objbs.ledgeridretrive("3");
                    ddlLedger.DataSource = ds1;
                    ddlLedger.DataValueField = "LedgerId";
                    ddlLedger.DataTextField = "LedgerName";
                    ddlLedger.Items.Insert(0, "Select");
                    ddlLedger.DataBind();
                }
                #endregion

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

        #region Expense Add Page Data
        protected void btnsave_Click(object sender, EventArgs e)
        {

            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }

            if (txtdate.Text == "--Select Date--")
            {
                lbldateError.Text = "please select date";
            }
            else
            {
                /// txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                bool check;
                if (order.Checked == true)
                    check = true;
                else
                    check = false;
                DateTime Date = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int CreditorID1 = 0;

                DataSet dsledger = objbs.getCashledgerId123("Cash A/C _" + sTableName);
                if (dsledger.Tables[0].Rows.Count > 0)
                {
                    CreditorID1 = Convert.ToInt32(dsledger.Tables[0].Rows[0]["LedgerID"].ToString());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Cash A/C Does not Exists in Table');", true);
                    return;
                }


                int i = objbs.ledgerinsert(sTableName, Date.ToString(), Convert.ToString(ddlLedger.SelectedValue), txtdescrip.Text, Convert.ToDouble(txtamount.Text), check, txtNo.Text, ddPaymode.SelectedValue, Convert.ToString(CreditorID1));
                txtamount.Text = "";
                txtdescrip.Text = "";
                Response.Redirect("ExpenseGrid.aspx");
            }

        }

        protected void order_CheckedChanged(object sender, EventArgs e)
        {
            orderno.Visible = true;

        }
        #endregion
    }
}