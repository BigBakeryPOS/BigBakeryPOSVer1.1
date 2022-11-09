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
namespace Billing.Accountsbootstrap
{
    public partial class Expense : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            
            if (!IsPostBack)
            {
                txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expensegrid.aspx");
        }

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


    }
}