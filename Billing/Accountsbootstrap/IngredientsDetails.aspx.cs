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
    public partial class IngredientsDetails : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";

        double Qty = 0;
        double Qtyitems = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["BranchCode"].ToString();


            if (!IsPostBack)
            {
                DataSet ds = objbs.getingredientsStocks(sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvitemsdetails.DataSource = ds;
                    gvitemsdetails.DataBind();
                }
                else
                {
                    gvitemsdetails.DataSource = null;
                    gvitemsdetails.DataBind();
                }
            }
        }



        protected void gvprod_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                DataSet ds = objbs.getProductionStockDetailsselect(sTableName, Convert.ToInt32(e.CommandArgument.ToString()));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvitemsdetails.DataSource = ds;
                    gvitemsdetails.DataBind();
                }
                else
                {
                    gvitemsdetails.DataSource = null;
                    gvitemsdetails.DataBind();
                }
            }
        }


        protected void gvitemsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Qtyitems += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total :";
                e.Row.Cells[1].Text = Qtyitems.ToString("f2");
            }
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
