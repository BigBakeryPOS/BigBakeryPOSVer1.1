using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
namespace Billing.Accountsbootstrap
{
    public partial class Return_ItemsGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        { 
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
             lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            if (!IsPostBack)
            {
                string selectvalues = "";
                txtfromdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txttodate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                
                if (sCode == "Production")
                {
                    ProductionChennai.Visible = false;
                    ProductionNellai.Visible = false;
                    Production2.Visible = false;
                    selectvalues = ddlBranch.SelectedValue;
                }
                if (sCode == "Production2")
                {
                    ProductionChennai.Visible = false;
                    ProductionNellai.Visible = false;
                    Production.Visible = false;
                    selectvalues = ddbr.SelectedValue;
                }

                if (sCode == "Production3")
                {
                    ProductionChennai.Visible = false;
                    Production2.Visible = false;
                    Production.Visible = false;
                    selectvalues = ddnellai.SelectedValue;
                }

                if (sCode == "Production4")
                {
                    ProductionNellai.Visible = false;
                    Production2.Visible = false;
                    Production.Visible = false;
                    selectvalues = dChennai.SelectedValue;
                }

                if (selectvalues == "")
                {
                    selectvalues = sCode;
                }
                DataSet dRet = objbs.ReturnGridSearch(selectvalues, txtfromdate.Text, txttodate.Text);
                grid.DataSource = dRet;
                grid.DataBind();
            }
        }
        protected void drpPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (drpPayment.SelectedValue == "13")
            {
                ds = objbs.GetEubReasons(13);
            }
            else if (drpPayment.SelectedValue == "2" || drpPayment.SelectedValue == "4")
            {
                ds = objbs.GetEubReasons(111);
            }
            else if (drpPayment.SelectedValue == "14")
            {
                ds = objbs.GetEubReasons(14);
            }
            else if (drpPayment.SelectedValue == "5")
            {
                ds = objbs.GetEubReasons(5);
            }
            else if (drpPayment.SelectedValue == "15")
            {
                ds = objbs.GetEubReasons(15);
            }
            ddlsubreasons.Items.Clear();
            ddlsubreasons.DataSource = ds.Tables[0];
            ddlsubreasons.DataTextField = "SubReasons";
            ddlsubreasons.DataValueField = "id";
            ddlsubreasons.DataBind();
            ddlsubreasons.Items.Insert(0, "Select SubReasons");
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
            catch
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string selectvalues = "";
            if (sCode == "Production")
            {
                ProductionNellai.Visible = false;
                Production2.Visible = false;
                selectvalues = ddlBranch.SelectedValue;
            }
            if (sCode == "Production2")
            {
                ProductionNellai.Visible = false;
                Production.Visible = false;
                selectvalues = ddbr.SelectedValue;
            }

            if (sCode == "Production3")
            {
                Production2.Visible = false;
                Production.Visible = false;
                selectvalues = ddnellai.SelectedValue;
            }
            if (sCode == "Production4")
            {
                Production2.Visible = false;
                Production.Visible = false;
                selectvalues = dChennai.SelectedValue;
            }
            DataSet dRet = objbs.ReturnGridSearch(selectvalues, txtfromdate.Text, txttodate.Text);
            if (sCode == "Production")
            {
                grid.Caption = "Returned Items From " + txtfromdate.Text + "  To " + txttodate.Text + "-" + ddlBranch.SelectedItem.Text + "";
            }
            if (sCode == "Production2")
            {
                grid.Caption = "Returned Items From " + txtfromdate.Text + "  To " + txttodate.Text + "-" + ddbr.SelectedItem.Text + "";
            }
            if (sCode == "Production3")
            {
                grid.Caption = "Returned Items From " + txtfromdate.Text + "  To " + txttodate.Text + "-" + ddnellai.SelectedItem.Text + "";
            }

            if (sCode == "Production4")
            {
                grid.Caption = "Returned Items From " + txtfromdate.Text + "  To " + txttodate.Text + "-" + dChennai.SelectedItem.Text + "";
            }
            grid.DataSource = dRet;
            grid.DataBind();
            decimal dCount = 0;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                dCount += Convert.ToDecimal(grid.Rows[i].Cells[6].Text);
            }

            lblTotal.InnerText = dCount.ToString("f2");


        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string strFileName = "Returns";
            if (grid.Rows.Count > 0)
            {


                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                grid.Caption = "Returned Items From " + txtfromdate.Text + "  To " + txttodate.Text + "";
                //Get the HTML for the control.
                grid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName);
                EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }
        protected void BindGridview()
        {
            DataSet dRet = objbs.ReturnGridSearch(ddlBranch.SelectedValue, txtfromdate.Text, txttodate.Text);
            grid.DataSource = dRet;
            grid.DataBind();
        }
        protected void ExportToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
            return;
        }

        private void creatExcel()
        {
            if (Int32.Parse(grid.Rows.Count.ToString()) < 65536)
            {
                grid.AllowPaging = true;
                //grvProdReport.DataBind()
                StringWriter tw = new StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                HtmlForm frm = new HtmlForm();
                string strTmpTime = (System.DateTime.Today).ToString();
                if (strTmpTime.IndexOf("/") != -1)
                {
                    strTmpTime = strTmpTime.Replace("/", "-").ToString().Trim();
                }
                if (strTmpTime.IndexOf(":") != -1)
                {
                    strTmpTime = strTmpTime.Replace(":", "-").ToString().Trim();
                }
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=sheet.xls");
                Response.Charset = "UTF-8";
                EnableViewState = false;
                Controls.Add(frm);
                frm.Controls.Add(grid);
                frm.RenderControl(hw);
                hw.WriteLine("<b> <u> <font-size:'5'> Student Report </font> </u> </b>");
                Response.Write(tw.ToString());
                Response.End();
            }
            else
            {
                //lblError.Visible = true;
                //lblError.Text = "Export to Excel not possible";
            }
        }

        protected void btnExport_Click1(object sender, EventArgs e)
        {
            HtmlForm form = new HtmlForm();

    Response.Clear();

    Response.Buffer = true;

    string filename="GridViewExport_"+DateTime.Now.ToString()+".xls";

 

    Response.AddHeader("content-disposition",

    "attachment;filename="+filename);

    Response.Charset = "";

    Response.ContentType = "application/vnd.ms-excel";

    StringWriter sw = new StringWriter();

    HtmlTextWriter hw = new HtmlTextWriter(sw);

    grid.AllowPaging = false;

    grid.DataBind();

    form.Controls.Add(grid);

    this.Controls.Add(form);

    form.RenderControl(hw);



    //style to format numbers to string

    string style = @"<style> .textmode { mso-number-format:\@; } </style>";

    Response.Write(style);

    Response.Output.Write(sw.ToString());

    Response.Flush();

    Response.End();


        }

        protected void btnExport_Click2(object sender, EventArgs e)
        {
            GridView gridview = new GridView();
            string selectvalues = "";
            if (sCode == "Production")
            {
                ProductionNellai.Visible = false;
                Production2.Visible = false;
                selectvalues = ddlBranch.SelectedValue;
            }
            if (sCode == "Production2")
            {
                ProductionNellai.Visible = false;
                Production.Visible = false;
                selectvalues = ddbr.SelectedValue;
            }

            if (sCode == "Production3")
            {
                Production2.Visible = false;
                Production.Visible = false;
                selectvalues = ddnellai.SelectedValue;
            }

            if (sCode == "Production4")
            {
                Production2.Visible = false;
                Production.Visible = false;
                selectvalues = dChennai.SelectedValue;
            }



           
            gridview.DataSource = objbs.ReturnGridSearchExport(selectvalues, txtfromdate.Text, txttodate.Text);
            gridview.DataBind();
            
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=StockReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }

    //     public void ExportToExcel(DataTable dt)
    //{

    //    if (dt.Rows.Count > 0)
    //    {
    //        using (XLWorkbook wb = new XLWorkbook())
    //        {
    //            string filename = "LedgerExcelReport.xlsx";
    //            wb.Worksheets.Add(dt);
    //            Response.Clear();
    //            Response.Buffer = true;
    //            Response.Charset = "";
    //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //            Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
    //            using (MemoryStream MyMemoryStream = new MemoryStream())
    //            {
    //                wb.SaveAs(MyMemoryStream);
    //                MyMemoryStream.WriteTo(Response.OutputStream);
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //    }
    //}

      

    }
}