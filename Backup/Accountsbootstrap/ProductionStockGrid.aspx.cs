using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class ProductionStockGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            //DataSet ds = objbs.PSGridBranch(Convert.ToInt32(lblUserID.Text));
            //gvPurchaseEntry.DataSource = ds;
            //gvPurchaseEntry.DataBind();
            if (sCode == "Production")
            {
                DataSet ds = objbs.PSDet();
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
            }
            if (sCode == "Production2")
            {
                DataSet ds = objbs.PSDet();
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
            }
            if (sCode == "Production3")
            {
                DataSet ds = objbs.PSDetNellai();
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
            }

            if (sCode == "Production4")
            {
                DataSet ds = objbs.PSDetChennai();
                gvPurchaseReqDetails.DataSource = ds;
                gvPurchaseReqDetails.DataBind();
            }

            //else
            //{
            //    DataSet ds = objbs.PSDet2();
            //    gvPurchaseReqDetails.DataSource = ds;
            //    gvPurchaseReqDetails.DataBind();
            //}
        

        
    }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResponisveTabs.aspx");
        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //DataSet ds = objbs.PSDet(e.CommandArgument.ToString());
                //gvPurchaseReqDetails.DataSource = ds;
                //gvPurchaseReqDetails.DataBind();
            }
        }

        protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell row in e.Row.Cells)
                {
                    if (e.Row.Cells[3].Text != "Requset Sent")
                    {

                        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Accepted by production')", true);
                    }
                }
            }
        }

        protected void gvPurchaseEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //if (sCode == "Production")
            //{
                DataSet ds = objbs.PSGridBranch(Convert.ToInt32(lblUserID.Text));
                
            //}

            //else
            //{

            //    DataSet ds = objbs.PSGridBranch2(Convert.ToInt32(lblUserID.Text));
            //    gvPurchaseEntry.PageIndex = e.NewPageIndex;
            //    gvPurchaseEntry.DataSource = ds;
            //    gvPurchaseEntry.DataBind();
            //}
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();


            //if (sCode == "Production")
            //{

            DataSet ds = objbs.PSDet();
            gridview.DataSource = ds;
            gridview.DataBind();
            //}
            //else
            //{
            //    gridview.DataSource = objbs.PSDet2();
            //    gridview.DataBind();
            //}

            gridview.Caption = "Production Stock Details";

            string FileName = "Production Stock Details";

            Response.ClearContent();
            //Response.AddHeader("content-disposition","attachment;filename=Sent Goods.xls");
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", FileName));

            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }
    }
}
