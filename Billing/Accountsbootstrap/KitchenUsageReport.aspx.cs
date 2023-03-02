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
using System.Web.UI.HtmlControls;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class KitchenUsageReport : System.Web.UI.Page
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


                #region

                DataSet dsCat = objBs.getkuasge(sTableName);
                if (dsCat.Tables[0].Rows.Count > 0)
                {
                    ddldcno.DataSource = dsCat.Tables[0];
                    ddldcno.DataTextField = "requestno";
                    ddldcno.DataValueField = "ID";
                    ddldcno.DataBind();
                    ddldcno.Items.Insert(0, "All");
                }
                DataSet dsCategory = objBs.selectcategorymaster();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlCategory.DataSource = dsCategory.Tables[0];
                    ddlCategory.DataTextField = "category";
                    ddlCategory.DataValueField = "categoryid";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, "All");
                }
                DataSet dsIngridients = objBs.getIngridentsforsup();
                if (dsIngridients.Tables[0].Rows.Count > 0)
                {
                    ddlIngridients.DataSource = dsIngridients.Tables[0];
                    ddlIngridients.DataTextField = "IngredientName";
                    ddlIngridients.DataValueField = "IngridID";
                    ddlIngridients.DataBind();
                    ddlIngridients.Items.Insert(0, "All");
                }

                DataSet getdeptshow = objBs.getDepartment(sTableName);
                //if (getdeptshow.Tables[0].Rows.Count > 0)
                    if (getdeptshow.Tables[0].Rows.Count > 0)
                    {
                        drpdept.DataSource = getdeptshow;
                        drpdept.DataTextField = "Deptname";
                        drpdept.DataValueField = "DeptID";
                        drpdept.DataBind();
                        drpdept.Items.Insert(0, "All");
                    }
                    else
                    {
                        drpdept.DataSource = null;
                        drpdept.DataBind();
                        drpdept.Items.Insert(0, "All");
                    }

                #endregion
                ddltype_SelectedIndexChanged(sender, e);
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedValue == "1")
            {
                entry.Visible = false;
                cat.Visible = false;
                ind.Visible = false;
            }
            else
            {
                entry.Visible = false;
                cat.Visible = false;
                ind.Visible = true;
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
                DataSet ds = objBs.getreportforkitchenusage(sTableName, ddltype.SelectedValue, ddldcno.SelectedValue, frmdate, todate, ddlCategory.SelectedValue, ddlIngridients.SelectedValue, drpdept.SelectedValue);
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

                gvsales.Visible = true;
                gvsummary.Visible = false;

                gvsales.Caption = "Kitchen Transfer Report From " + frmdate + " To " + todate;
            }
            else if (rdosummary.Checked == true)
            {
                DataSet ds = objBs.getreportforkitchenusage_Summary(sTableName, ddltype.SelectedValue, ddldcno.SelectedValue, frmdate, todate, ddlCategory.SelectedValue, ddlIngridients.SelectedValue, drpdept.SelectedValue);
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
                gvsummary.Caption = "Kitchen Transfer Report From " + frmdate + " To " + todate;
                gvsummary.Visible = true;
                gvsales.Visible = false;
            }
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();

            DateTime frmdate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime todate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds1 = objBs.getreportforkitchenusage(sTableName, ddltype.SelectedValue, ddldcno.SelectedValue, frmdate, todate, ddlCategory.SelectedValue, ddlIngridients.SelectedValue,drpdept.SelectedValue);
            //update 22/10/21
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    ds1.Tables[0].Rows[i]["RequestDate"] = Convert.ToDateTime(ds1.Tables[0].Rows[i]["RequestDate"]).ToString("dd/MMM/yyyy");
                }
            }
            //end update
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds1;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = null;
                gridview.DataBind();
            }


            gridview.Caption = "Kitchen Usage Report";

            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=KitchenUsageReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }
        private void ExportToExcel(string filename, DataSet dt)
        {
            if (dt.Tables[0].Rows.Count > 0)
            {
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();

                string caption = "From :" + txtfromdate.Text + "To" + txttodate.Text + "EntryNo:" + ddldcno.SelectedItem.Text;
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

        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GrandTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "acceptqty"));
                grandRecQty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Recqty"));
                GrandTotalmssing += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "MissingQty"));
                GrandTotaldamage += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DamageQty"));
                GrandTotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = "Total :";
                e.Row.Cells[7].Text = GrandTotal.ToString("f2");
                e.Row.Cells[8].Text = grandRecQty.ToString("f2");
                e.Row.Cells[9].Text = GrandTotalmssing.ToString("f2");
                e.Row.Cells[10].Text = GrandTotaldamage.ToString("f2");
                e.Row.Cells[13].Text = GrandTotalAmount.ToString("f2");

            }
        }

        protected void gvs_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            DataSet dst = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GrandTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "acceptqty"));
                TotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = GrandTotal.ToString("f2");
                e.Row.Cells[6].Text = TotalAmount.ToString("f2");


            }
        }
    }
}