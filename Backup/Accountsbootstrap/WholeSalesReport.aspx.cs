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
using System.Diagnostics;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class WholeSalesReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;

         double Qty = 0;
        string brach = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();


            if (!IsPostBack)
            {

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet ds = objBs.GetSalesallrep(sTableName);
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
                #region

                DataSet dsCustomer = objBs.getgridforcustsale();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlcustomer.DataSource = dsCustomer.Tables[0];
                    ddlcustomer.DataTextField = "CustomerName";
                    ddlcustomer.DataValueField = "LedgerID";
                    ddlcustomer.DataBind();
                    ddlcustomer.Items.Insert(0, "All");
                }
                else
                {
                    ddlcustomer.Items.Insert(0, "All");
                }

                DataSet dsCat = objBs.AllCategory();
                if (dsCat.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCat.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                }

                DataSet dsItem = objBs.AllItems();
                if (dsItem.Tables[0].Rows.Count > 0)
                {
                    ddlitem.DataSource = dsItem.Tables[0];
                    ddlitem.DataTextField = "Definition";
                    ddlitem.DataValueField = "CategoryUserID";
                    ddlitem.DataBind();
                    ddlitem.Items.Insert(0, "All");
                }
                #endregion
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }

        protected void search1(object sender, EventArgs e)
        {
            search(sender,e);
        }
        protected void search2(object sender, EventArgs e)
        {
            search(sender, e);
        }
        protected void search(object sender, EventArgs e)
        {
            DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objBs.GetSalesallrep(sTableName, ddlcustomer.SelectedValue, ddlcategory.SelectedValue, ddlitem.SelectedValue, frmdate, todate);
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
        }
        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = Qty.ToString("f2");

            }
        }
    }
}