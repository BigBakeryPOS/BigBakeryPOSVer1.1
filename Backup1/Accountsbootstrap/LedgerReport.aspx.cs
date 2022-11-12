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
    public partial class LedgerReport : System.Web.UI.Page
    {
        decimal totalDebit = 0;
        decimal totalCredit = 0;
        int totalItems = 0;
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                

                DataSet dLed = objBs.ledgeridretrive("0");
                ddLedger.DataSource = dLed.Tables[0];
                ddLedger.DataValueField = "LedgerId";
                ddLedger.DataTextField = "LedgerName";
                ddLedger.DataBind();
                ddLedger.Items.Insert(0, "All");

                DataSet dLedger = objBs.getAllLedger();
                gvdaybook.DataSource = dLedger;
                gvdaybook.DataBind();
            }
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            DataSet dfind = new DataSet();
            if (sTableName == "admin")
            {
                 dfind = objBs.AllLedger(Convert.ToInt32(ddLedger.SelectedValue));
                 from.Visible = true;
                 to.Visible = true;
            }
            else
            {
                 dfind = objBs.SeaechLedgerExpense(Convert.ToInt32(ddLedger.SelectedValue), sTableName);
                 from.Visible = true;
                 to.Visible = true;
            }
            gvdaybook.DataSource = dfind;
            gvdaybook.DataBind();
        }

        protected void gvdaybook_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDebitPrice = (Label)e.Row.FindControl("lblDebitPrice");
                Label lblCreditPrice = (Label)e.Row.FindControl("lblCreditPrice");
                if (lblDebitPrice.Text == "")
                    lblDebitPrice.Text = "0";
                else
                {
                    decimal dDebit = Decimal.Parse(lblDebitPrice.Text);
                    totalDebit += dDebit;
                }
                if (lblCreditPrice.Text == "")
                    lblCreditPrice.Text = "0";
                else
                {
                    decimal dCredit = Decimal.Parse(lblCreditPrice.Text);
                    totalCredit += dCredit;
                }
                //totalDebit += dDebit;
                // totalCredit += dCredit;

                totalItems += 1;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbldebit = (Label)e.Row.FindControl("lbldebit");
                Label lblcredit = (Label)e.Row.FindControl("lblcredit");

                lbldebit.Text = totalDebit.ToString();
                lblcredit.Text = totalCredit.ToString();

                //lblAveragePrice.Text = (totalPrice / totalItems).ToString("F");
            } 
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet dSeaarch = new DataSet();
            if (sTableName == "admin")
            {
                if (ddLedger.Text == "All")
                {
                    dSeaarch = objBs.LedgerDateWise(txtfrmdate.Text, txttodate.Text);
                    gvdaybook.DataSource = dSeaarch;
                    gvdaybook.DataBind();
                }
                else
                {
                    dSeaarch = objBs.AllLedgerDateWise(Convert.ToInt32(ddLedger.SelectedValue), txtfrmdate.Text, txttodate.Text);
                    gvdaybook.DataSource = dSeaarch;
                    gvdaybook.DataBind();
                }
            }

            else
            {
                if (ddLedger.Text == "All")
                {
                    dSeaarch = objBs.AllExpenseDateWise(sTableName, txtfrmdate.Text, txttodate.Text);
                    gvdaybook.DataSource = dSeaarch;
                    gvdaybook.DataBind();
                }
                else
                {
                    dSeaarch = objBs.SeaechLedgerExpenseDateWise(Convert.ToInt32(ddLedger.SelectedValue), sTableName, txtfrmdate.Text, txttodate.Text);
                    gvdaybook.DataSource = dSeaarch;
                    gvdaybook.DataBind();
                }
            }
        }

        protected void rbBranch1_CheckedChanged(object sender, EventArgs e)
        {
            if (ddLedger.Text == "All")
            {
                DataSet dSearch = objBs.LedgerDateWise_branch1(txtfrmdate.Text, txttodate.Text);
                if (dSearch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSearch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "No Records Found";
                }
            }
            else
            {
                DataSet dSearch = objBs.AllLedgerDateWise_branch1(Convert.ToInt32(ddLedger.SelectedValue), txtfrmdate.Text, txttodate.Text);
                if (dSearch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSearch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "No Records Found";
                }
            }
        }

        protected void rbBranch2_CheckedChanged(object sender, EventArgs e)
        {
            if (ddLedger.Text == "All")
            {
                DataSet dSearch = objBs.LedgerDateWise_branch2(txtfrmdate.Text, txttodate.Text);
                if (dSearch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSearch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "No Records Found";
                }
            }
            else
            {
                DataSet dSearch = objBs.AllLedgerDateWise_branch2(Convert.ToInt32(ddLedger.SelectedValue), txtfrmdate.Text, txttodate.Text);
                if (dSearch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSearch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "No Records Found";
                }
            }
        }

        protected void rbBranch3_CheckedChanged(object sender, EventArgs e)
        {
            if (ddLedger.Text == "All")
            {
                DataSet dSearch = objBs.LedgerDateWise_branch3(txtfrmdate.Text, txttodate.Text);
                if (dSearch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSearch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "No Records Found";
                }
            }
            else
            {
                DataSet dSearch = objBs.AllLedgerDateWise_branch3(Convert.ToInt32(ddLedger.SelectedValue), txtfrmdate.Text, txttodate.Text);
                if (dSearch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSearch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else 
                {
                    lblError.Text = "No Records Found";
                }
            }
        }

        protected void rbBranch4_CheckedChanged(object sender, EventArgs e)
        {
            if (ddLedger.Text == "All")
            {
                DataSet dSeaarch = objBs.LedgerDateWise(txtfrmdate.Text, txttodate.Text);
                if (dSeaarch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSeaarch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {
                    lblError.Text = "No Records Found";
                }
            }
            else
            {
                DataSet dSeaarch = objBs.AllLedgerDateWise(Convert.ToInt32(ddLedger.SelectedValue), txtfrmdate.Text, txttodate.Text);
                if (dSeaarch.Tables[0].Rows.Count > 0)
                {
                    gvdaybook.DataSource = dSeaarch;
                    gvdaybook.DataBind();
                    lblError.Text = "";
                }
                else
                {

                    lblError.Text = "No Records Found";
                }
            }
        }
    }
}