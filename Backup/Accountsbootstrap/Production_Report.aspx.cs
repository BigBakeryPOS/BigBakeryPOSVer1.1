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
using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class Production_Report : System.Web.UI.Page
    { 
        BSClass objbs = new BSClass();
         string sCode = "";
         double PQty = 0,RqTy=0;
        protected void Page_Load(object sender, EventArgs e)
         {
             sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (!IsPostBack)
            {
                DataSet dsCategory = objbs.selectcategorymasterforproductionentry();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                }


                txtdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void gvprodstock_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

           
            double Qty = 0;
           
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "readyqty"));

                PQty = PQty + Qty;
                
                

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {


                e.Row.Cells[3].Text = "Total";
                e.Row.Cells[4].Text = PQty.ToString("f2");
               


            }
        }

        protected void gridraw_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            double Qty = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "qtyused"));

                RqTy = RqTy + Qty;



            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {


                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = RqTy.ToString("f2");



            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblhead.Text = "Production Report Details From " + Session["Store"].ToString() + " Date " + txtdate.Text + " and To Date " + txttodate.Text + "";
            DataSet d = objbs.PRoduction_Reports(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")), sCode, ddlcategory.SelectedValue, txttodate.Text);
            gvprodstock.DataSource = d;
            gvprodstock.DataBind();



            DataSet rawchk = objbs.PRoduction_Reportsbyraw(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")), sCode, ddlcategory.SelectedValue,txttodate.Text);
            gridraw.DataSource = rawchk;
            gridraw.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
           // if (sCode == "Production" || sCode == "Production2")
            lblhead.Text = "Production Report Details From " + Session["Store"].ToString() + " Date " + txtdate.Text + " and To Date " + txttodate.Text + "";
            {
                DataSet d = objbs.PRoduction_Reports(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")), sCode, ddlcategory.SelectedValue, txttodate.Text);
                gvprodstock.DataSource = d;
                gvprodstock.DataBind();
            }


            DataSet rawchk = objbs.PRoduction_Reportsbyraw(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")), sCode, ddlcategory.SelectedValue, txttodate.Text);
            gridraw.DataSource = rawchk;
            gridraw.DataBind();
            //else if (sCode == "Production4")
            //{
             //  DataTable d = objbs.ReportsChennai(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")));
            //    gvprodstock.DataSource = d;
            //    gvprodstock.DataBind();

            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            //}
            //else
            //{
            //    DataTable d = objbs.ReportsNellai(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")));
            //    gvprodstock.DataSource = d;
            //    gvprodstock.DataBind();
            //}
            //DataSet ds = objbs.PSDet();//objbs.ProductionDailyReport(txtdate.Text);
            //gvprodstock.DataSource = ds;
            //gvprodstock.DataBind();

            //DataSet dtime = objbs.gettime(txtdate.Text);
            //ddltime.DataSource = dtime.Tables[0];
            //ddltime.DataValueField = "Date";
            //ddltime.DataTextField = "Date";
            //ddltime.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {

            Response.Clear();

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            lblhead.Text = "Production Report Details From " + Session["Store"].ToString() +" Date " + txtdate.Text + " and To Date " + txttodate.Text + "";
                Response.AddHeader("content-disposition", "attachment;filename= Productionreport.xls");
                div1.RenderControl(htmlWrite);
           
            Response.Write(stringWrite.ToString());
            Response.End();
            
                //GridView gridview = new GridView();

                
                //{
                //    DataSet d = objbs.PRoduction_Reports(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")), sCode, ddlcategory.SelectedValue, txttodate.Text);
                //    gridview.DataSource = d;
                //    gridview.DataBind();
                //}

                //gridview.Caption = Convert.ToDateTime(txtdate.Text).ToString("dd/MM/yyyy") + "-" + "Production Report";

                //Response.ClearContent();
                //Response.AddHeader("content-disposition",
                //    "attachment;filename=Production Report.xls");
                //Response.ContentType = "applicatio/excel";
                //StringWriter sw = new StringWriter(); ;
                //HtmlTextWriter htm = new HtmlTextWriter(sw);
                //gridview.AllowPaging = false;
                //gridview.RenderControl(htm);
                //Response.Write(sw.ToString());
                //Response.End();
                //gridview.AllowPaging = true;
            
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
          //  if (sCode == "Production" || sCode == "Production2")
            {
                DataSet d = objbs.PRoduction_Reports(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")), sCode, ddlcategory.SelectedValue, txttodate.Text);
                gvprodstock.DataSource = d;
                gvprodstock.DataBind();
                gvprodstock.Caption = "Production Report Details From " + Session["Store"].ToString() + " Date " + txtdate.Text + " and To Date " + txttodate.Text + "";
                gridraw.Caption = "Raw Materials Report Details From " + Session["Store"].ToString() + " Date " + txtdate.Text + " and To Date " + txttodate.Text + "";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }
            //else if (sCode == "Production4")

            //{
            //    DataTable d = objbs.ReportsChennai(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")));
            //    gvprodstock.DataSource = d;
            //    gvprodstock.DataBind();
            //    gvprodstock.Caption = Convert.ToDateTime(txtdate.Text).ToString("dd/MM/yyyy") + "-" + "Production Transfer Report";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            //}

            //else
            //{
            //    DataTable d = objbs.ReportsNellai(Convert.ToDateTime(txtdate.Text).ToString(("yyyy-MM-dd")));
            //    gvprodstock.DataSource = d;
            //    gvprodstock.DataBind();
            //    gvprodstock.Caption = Convert.ToDateTime(txtdate.Text).ToString("dd/MM/yyyy") + "-" + "Production Transfer Report";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            //}
        }
    }
}