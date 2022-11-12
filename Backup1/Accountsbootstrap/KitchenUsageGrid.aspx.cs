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
using System.Web.UI.HtmlControls;

namespace Billing.Accountsbootstrap
{
    public partial class KitchenUsageGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["User"] != null)
            //    sTableName = Session["User"].ToString();
            //else
            //    Response.Redirect("Login_Branch.aspx");
            //lblUser.Text = Session["UserName"].ToString();
            //lblUserID.Text = Session["UserID"].ToString();
            //if (!IsPostBack)
            //{

            //    DataSet ds = objBs.getpurchaseMaster1();
            //    if (ds != null)
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            BankGrid.DataSource = ds;
            //            BankGrid.DataBind();
            //        }
            //        else
            //        {
            //            BankGrid.DataSource = null;
            //            BankGrid.DataBind();
            //        }
            //    }
            //    else
            //    {
            //        BankGrid.DataSource = null;
            //        BankGrid.DataBind();
            //    }
            //}
        }

        protected void refresh_Click(object sender, EventArgs e)
        {
           // Response.Redirect("webform5.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //DataSet ds = objBs.searchBankmaster(txtsearch.Text, Convert.ToInt32(ddlfilter.SelectedValue), sTableName);

            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        BankGrid.DataSource = ds;
            //        BankGrid.DataBind();
            //    }
            //    else
            //    {
            //        BankGrid.DataSource = null;
            //        BankGrid.DataBind();
            //    }

            //}
            //else
            //{
            //    BankGrid.DataSource = null;
            //    BankGrid.DataBind();
            //}
        }

        protected void Add_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("webform3.aspx");

        }


        protected void BankGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("webform3.aspx?LedgerID=" + e.CommandArgument.ToString());
            //    }
            //}

            //else if (e.CommandName == "delete")
            //{
            //    // int iSucess = objBs.deleteBankmaster(e.CommandArgument.ToString(), "tblAuditMaster_" + sTableName, lblUser.Text, sTableName);
            //    int iSucess = objBs.deletePURmaster1(e.CommandArgument.ToString());
            //    Response.Redirect("webform5.aspx");
            //}
        }

        protected void BankGrid_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            //DataSet ds = new DataSet();
            //if (ddlfilter.SelectedValue == "0")
            //{
            //    ds = objBs.selectBankMaster("4", sTableName);
            //}
            //else
            //{

            //    ds = objBs.searchBankmaster(txtsearch.Text, Convert.ToInt32(ddlfilter.SelectedValue), sTableName);
            //}


            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        BankGrid.DataSource = ds;
            //        BankGrid.PageIndex = e.NewPageIndex;
            //        BankGrid.DataBind();
            //    }
            //    else
            //    {
            //        BankGrid.DataSource = null;
            //        BankGrid.DataBind();
            //    }

            //}
            //else
            //{
            //    BankGrid.DataSource = null;
            //    BankGrid.DataBind();
            //}
        }

        protected void BankGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{


            //}
        }


        protected void btnFormat_Click(object sender, EventArgs e)
        {
            //string button = string.Empty;
            //button = Button3.Text;
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('If You Need This.Please Contact Administrator.Thank You!!!.');", true);
            //    return;
            //    //button = Button3.Text;
            //    ////Response.Redirect("categorymaster.aspx");
            //    //Response.Redirect("bankmaster.aspx?name=" + button.ToString());
            //}

        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            //HtmlForm form = new HtmlForm();
            //Response.Clear();
            //Response.Buffer = true;
            //string filename = "BankMaster_" + DateTime.Now.ToString() + ".xls";

            //DataSet ds = new DataSet();

            //ds = objBs.selectBankMaster("4", sTableName);

            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        DataTable dt = new DataTable();
            //        dt.Columns.Add(new DataColumn("BankName"));
            //        dt.Columns.Add(new DataColumn("MobileNo"));
            //        dt.Columns.Add(new DataColumn("Email"));
            //        dt.Columns.Add(new DataColumn("GroupName"));
            //        dt.Columns.Add(new DataColumn("Address"));
            //        dt.Columns.Add(new DataColumn("Area"));
            //        dt.Columns.Add(new DataColumn("City"));
            //        dt.Columns.Add(new DataColumn("IsActive"));
            //        dt.Columns.Add(new DataColumn("Open-Credit"));
            //        dt.Columns.Add(new DataColumn("Open-Debit"));



            //        //DataRow dr_export1 = dt.NewRow();
            //        //dt.Rows.Add(dr_export1);

            //        foreach (DataRow dr in ds.Tables[0].Rows)
            //        {
            //            DataRow dr_export = dt.NewRow();
            //            dr_export["BankName"] = dr["LedgerName"];
            //            dr_export["MobileNo"] = dr["MobileNo"];
            //            dr_export["Email"] = dr["Email"];
            //            dr_export["GroupName"] = dr["GName"];
            //            dr_export["Address"] = dr["Address"];
            //            dr_export["Area"] = dr["Area"];
            //            dr_export["City"] = dr["City"];
            //            dr_export["IsActive"] = dr["IsActive"];
            //            dr_export["Open-Credit"] = dr["Open_Credit"];
            //            dr_export["Open-Debit"] = dr["Open_Depit"];


            //            dt.Rows.Add(dr_export);
            //        }

            //        ExportToExcel(filename, dt);
            //    }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('No Data Found');", true);
            //}
        }


        public void ExportToExcel(string filename, DataTable dt)
        {

            //if (dt.Rows.Count > 0)
            //{
            //    System.IO.StringWriter tw = new System.IO.StringWriter();
            //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            //    DataGrid dgGrid = new DataGrid();
            //    dgGrid.DataSource = dt;
            //    dgGrid.DataBind();
            //    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            //    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            //    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            //    dgGrid.HeaderStyle.Font.Bold = true;
            //    //Get the HTML for the control.
            //    dgGrid.RenderControl(hw);
            //    //Write the HTML back to the browser.
            //    Response.ContentType = "application/vnd.ms-excel";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            //    this.EnableViewState = false;
            //    Response.Write(tw.ToString());
            //    Response.End();
            //}
        }

    }
}