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
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Globalization;


namespace Billing.Accountsbootstrap
{
    public partial class RequestFromBranchGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        string qtysetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Today.ToString("dd/MM/yyy");

                // Get Store Details From Production

                DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                DataSet ds = objbs.getrequestbranchfromanotherbranch(sCode, sDate);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvPurchaseEntry.DataSource = ds;
                    gvPurchaseEntry.DataBind();
                }
                else
                {
                    gvPurchaseEntry.DataSource = null;
                    gvPurchaseEntry.DataBind();
                }

                
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

        }

        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label txtOrderQty = ((Label)e.Row.FindControl("lblorder_qty"));
                txtOrderQty.Text = Convert.ToDouble(txtOrderQty.Text).ToString("" + qtysetting + "");

                Label txtSentQty = ((Label)e.Row.FindControl("lblreceived_Qty"));
                txtSentQty.Text = Convert.ToDouble(txtSentQty.Text).ToString("" + qtysetting + "");

                
            }
        }


        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Accept")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                string ReqNo = arg[0];
                string Branch = arg[1];
                string Branchreqno = arg[2];
                string reqcode = arg[3];

                Response.Redirect("InterBranchStockTransfer.aspx?ReqNo=" + ReqNo + "&bcode=" + Branch + "&breqno=" + Branchreqno + "&REQCode=" + reqcode);
            }

            else if (e.CommandName == "view")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                string ReqNo = arg[0];
                string Branch = arg[1];
                string ReportDate = arg[2];
                string Breqno = arg[3];
                DataSet ds = objbs.interrequestdetails(Breqno, Branch, sCode,ReqNo);
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                //  gvDetails.Caption = Branch+""+"Store"+"-"+"Order Details";
                gvDetails.Caption = "Inter Stock Request NO "+ ReqNo +" For " + Branch + " Store On " + Convert.ToDateTime(ReportDate).ToString("dd/MM/yyyy") + "-" + ds.Tables[0].Rows[0]["RequestEntryTime"].ToString();
            }

            else if (e.CommandName == "Export")
            {
                try
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(';');
                    string ReqNo = arg[0];
                    string Branch = arg[1];
                    string Date = arg[2];
                    string Breqno = arg[3];
                    DataSet ds = objbs.interrequestdetails((Breqno), Branch, sCode, ReqNo);
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                    GridView gridview = new GridView();

                    gridview.DataSource = objbs.RequestDetExport((ReqNo), Branch);
                    gridview.DataBind();


                    //   gridview.Caption = Branch +"-"+Date+"-Request" ;

                    gridview.Caption = "Inter Stock Request For " + Branch + " Store On " + Date;
                    gvDetails.Caption = "Inter Stock Request For " + Branch + " Store On " + Date;
                    Response.ClearContent();
                    string filename = "Inter Stock Request For " + Branch + " Store On " + Date;
                    // Response.AddHeader("content-disposition","attachment;filename=Stock-ReqFrmBranch.xls");
                    Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", filename));

                    Response.ContentType = "applicatio/excel";
                    StringWriter sw = new StringWriter(); ;
                    HtmlTextWriter htm = new HtmlTextWriter(sw);
                    gvDetails.AllowPaging = false;
                    gvDetails.RenderControl(htm);
                    Response.Write(sw.ToString());
                    Response.End();
                    gvDetails.AllowPaging = true;
                }
                catch { }
            }

            else if (e.CommandName == "Previous")
            {
                //DateTime datetime=Convert.ToDateTime(txtDate.Text);
                //string date=datetime.ToString("yyyy-MM-dd");
                //DataSet dset = objbs.getDetaiedTransfer(date, sCode);
                //gvGrid.DataSource = dset;
                //gvGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

            }

            //  Response.Redirect("OrderFromBranch.aspx");
        }

        protected void btnadd_Click1(object sender, EventArgs e)
        {
            //for (int i = 0; i < gvPurchaseEntry.Rows.Count; i++)
            //{
            //    if (gvPurchaseEntry.Rows[i].Cells[4].Text.Trim() == "BB Kulam Branch")
            //    {
            //        Response.Redirect("GoodTransfer.aspx?BB=" + gvPurchaseEntry.Rows[i].Cells[3].Text);
            //    }
            //}
        }

        protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            for (int i = 0; i < gvPurchaseEntry.Rows.Count; i++)
            {
                DateTime Date = Convert.ToDateTime(gvPurchaseEntry.Rows[i].Cells[1].Text.ToString());

                string sdate = Date.ToString("yyyy-MM-dd");
                DateTime Yesterday = DateTime.Today.AddDays(-1);

                string sTerday = Yesterday.ToString("yyyy-MM-dd");
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    foreach (TableCell cell in e.Row.Cells)
                    {

                        if (sdate == sTerday)
                        {
                            gvPurchaseEntry.Rows[i].BackColor = Color.Green;
                            //txttransferQty.Enabled = true;
                            //cell.BackColor = Color.Yellow;

                        }
                    }
                }
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            // Get Store Details From Production

            DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getrequestbranchfromanotherbranchdate(sCode, sDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPurchaseEntry.DataSource = ds;
                gvPurchaseEntry.DataBind();
            }
            else
            {
                gvPurchaseEntry.DataSource = null;
                gvPurchaseEntry.DataBind();
            }

            //DataTable dsp = objbs.RequestReport(Convert.ToDateTime(txtDate.Text).ToString(("yyyy-MM-dd")));
            //dsp.Columns.Remove("CatID");
            //dsp.Columns.Remove("ItemID");
            //gvGrid.DataSource = dsp;
            //gvGrid.DataBind();



            //gvGrid.Caption = sCode+" "+DateTime.Now.ToString();


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= RequestFromStores.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvGrid.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}