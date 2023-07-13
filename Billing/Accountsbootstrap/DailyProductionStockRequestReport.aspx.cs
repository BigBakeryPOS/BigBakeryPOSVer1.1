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


namespace Billing.Accountsbootstrap
{
    public partial class DailyProductionStockRequestReport : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string scode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {
             
                DataSet dsCustomer = objbs.getbranchforhomepage();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlBranch.DataSource = dsCustomer.Tables[0];
                    ddlBranch.DataTextField = "brancharea";
                    ddlBranch.DataValueField = "branchname";
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, "All");
                }



                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
                string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

                DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
                string sTodate = dtTodate.ToString("yyyy-MM-dd");
               
          
                    DataSet dT = objbs.GetDailyProductionStockRequestReport(sFromdate, sTodate,scode);
                    if (dT.Tables[0].Rows.Count > 0)
                    {
                        gvTransfer.DataSource = dT;
                        gvTransfer.DataBind();
                    }
                    else
                    {
                        gvTransfer.DataSource = null;
                        gvTransfer.DataBind();
                    }
                }
             
            }
        

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            DataSet dT = objbs.GetDailyProductionStockRequestReport(sFromdate, sTodate, scode);
            if (dT.Tables[0].Rows.Count > 0)
            {
                gvTransfer.DataSource = dT;
                gvTransfer.DataBind();
            }
            else
            {
                gvTransfer.DataSource = null;
                gvTransfer.DataBind();
            }

           
        }

        protected void gvGoodTransFer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Transfer")
            {

                Response.Redirect("GoodTransfer.aspx?ReqNo=" + e.CommandArgument.ToString());
            }

          

           
        }

        protected void gvTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            grid.Visible = false;
            grid1.Visible = false;

            if (e.CommandName == "Exp")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                string DcNo = arg[0];
              
                string Date = Convert.ToDateTime(arg[1]).ToString("dd/MM/yyyy");
                DataSet ds = new DataSet();

                ds = objbs.ShowRequestRawDetails_DailyProd("tbldailyproduction_" + scode, "tbltransdailyproduction_" + scode, Convert.ToInt32(DcNo), "");
              
                GridView gridview = new GridView();




                gridview.DataSource = ds.Tables[0];
                gridview.DataBind();



                gridview.Caption = "Daily Production Stock Request Details " + "On " + Date + "-" + "Request NO" + DcNo;
                string filename = "Daily Production Stock Request Details On " + Date + "-" + "Request NO" + DcNo;

                Response.ClearContent();
                //Response.AddHeader("content-disposition","attachment;filename=Sent Goods.xls");
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", filename));
                //Response.ContentType = "applicatio/excel";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gridview.AllowPaging = false;
                gridview.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
                gridview.AllowPaging = true;

            }

            else if (e.CommandName == "Print")
            {
                grid.Visible = true;
                try
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string DcNo = arg[0];
                    
                    string Date =Convert.ToDateTime( arg[1]).ToString("dd/MM/yyyy h:mm tt");
                    DataSet ds = new DataSet();

                    ds = objbs.GetDailyProductionStockRequestDetailsReport("tbldailyproduction_" + scode, "tbltransdailyproduction_" + scode, Convert.ToInt32(DcNo), "");
                  
                    grid.DataSource = ds.Tables[0];
                    grid.DataBind();


                    grid.Caption = "Daily Production Stock Request Details " + "On " + Date + "-" + "Request NO" + DcNo;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

                    //grid.Visible = false;
                   
                }
                catch
                {

                }
            }
            else if (e.CommandName == "Print1")
            {
                grid1.Visible = true;
                try
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string DcNo = arg[0];
                 
                    string Date = Convert.ToDateTime(arg[1]).ToString("dd/MM/yyyy h:mm tt");
                    DataSet ds = new DataSet();

                    ds = objbs.ShowRequestRawDetails_DailyProd("tbldailyproduction_" + scode, "tbltransdailyproduction_" + scode, Convert.ToInt32(DcNo), "");
                  
                    grid1.DataSource = ds.Tables[0];
                    grid1.DataBind();

                    grid.Caption = "Daily Production Stock Request Details " + "On " + Date + "-" + "Request NO" + DcNo;
                 //   grid1.Caption = "Branch Code -" + Branch + "-" + Date + "-Sent Items Details" + "-" + "DC.No" + DcNo;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid1();", true);

                    //grid.Visible = false;

                }
                catch
                {

                }
            }
            else if (e.CommandName == "View")
            {
                try
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string DcNo = arg[0];
                   
                    string Date = Convert.ToDateTime(arg[1]).ToString("dd/MM/yyyy h:mm tt");
                    DataSet ds = new DataSet();

                    ds = objbs.GetDailyProductionStockRequestDetailsReport("tbldailyproduction_" + scode, "tbltransdailyproduction_" + scode, Convert.ToInt32(DcNo), "");
                  


                    grid.DataSource = ds.Tables[0];
                    grid.DataBind();
                    grid.Visible = true;

             
                    grid.Caption = "Daily Production Stock Request Details "  + "On " + Date + "-" + "Request NO" + DcNo;
                  
                }
                catch
                {

                }
            }
        }
    }
}