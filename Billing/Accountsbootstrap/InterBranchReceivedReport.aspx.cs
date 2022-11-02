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
    public partial class InterBranchReceivedReport : System.Web.UI.Page
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

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Session["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Session["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();


                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
                string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

                DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
                string sTodate = dtTodate.ToString("yyyy-MM-dd");

                //  if (scode == "Production")
                {
                    // DataSet dT = objbs.GetTrasfDet(gdate);
                    DataSet dT = objbs.interbranchReceivedReport_date(sFromdate, sTodate, scode);
                    if (dT.Tables[0].Rows.Count > 0)
                    {
                        gvreceived.DataSource = dT;
                        gvreceived.DataBind();
                    }
                }
                //if (scode == "Production2")
                //{
                //  //  DataSet dT = objbs.GetTrasfDet2(gdate);
                //    DataSet dT = objbs.GetTrasfDetChennai_ByDate(sFromdate, sTodate);
                //    if (dT.Tables[0].Rows.Count > 0)
                //    {
                //        gvTransfer.DataSource = dT;
                //        gvTransfer.DataBind();
                //    }
                //}
                //if (scode == "Production3")
                //{
                //    //DataSet dT = objbs.GetTrasfDetNellai(gdate);
                //    DataSet dT = objbs.GetTrasfDetChennai_ByDate(sFromdate, sTodate);
                //    if (dT.Tables[0].Rows.Count > 0)
                //    {
                //        gvTransfer.DataSource = dT;
                //        gvTransfer.DataBind();
                //    }
                //}

                //if (scode == "Production4")
                //{
                //   // DataSet dT = objbs.GetTrasfDetChennai(gdate);
                //    DataSet dT = objbs.GetTrasfDetChennai_ByDate(sFromdate, sTodate);
                //    if (dT.Tables[0].Rows.Count > 0)
                //    {
                //        gvTransfer.DataSource = dT;
                //        gvTransfer.DataBind();
                //    }
                //}
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            DataSet dT = objbs.interbranchReceivedReport_date(sFromdate, sTodate, scode);
            if (dT.Tables[0].Rows.Count > 0)
            {
                gvreceived.DataSource = dT;
                gvreceived.DataBind();
            }

            //if (scode == "Production")
            //{
            //   // DataSet dT = objbs.GetTrasfDet(txtDate.Text);
            //    DataSet dT = objbs.GetTrasfDet_ByDate(txtDate.Text,txtToDate.Text);
            //    if (dT.Tables[0].Rows.Count > 0)
            //    {
            //        gvTransfer.DataSource = dT;
            //        gvTransfer.DataBind();
            //    }
            //}
            //if (scode == "Production2")
            //{
            //    //DataSet dT = objbs.GetTrasfDet2(txtDate.Text);
            //    DataSet dT = objbs.GetTrasfDet2_ByDate(txtDate.Text, txtToDate.Text);
            //    if (dT.Tables[0].Rows.Count > 0)
            //    {
            //        gvTransfer.DataSource = dT;
            //        gvTransfer.DataBind();
            //    }
            //}
            //if (scode == "Production3")
            //{
            //    //DataSet dT = objbs.GetTrasfDetNellai(txtDate.Text);
            //    DataSet dT = objbs.GetTrasfDetNellai_ByDate(txtDate.Text,txtToDate.Text);
            //    if (dT.Tables[0].Rows.Count > 0)
            //    {
            //        gvTransfer.DataSource = dT;
            //        gvTransfer.DataBind();
            //    }
            //}

            //if (scode == "Production4")
            //{
            //    //DataSet dT = objbs.GetTrasfDetChennai(txtDate.Text);
            //    DataSet dT = objbs.GetTrasfDetChennai_ByDate(txtDate.Text,txtToDate.Text);
            //    if (dT.Tables[0].Rows.Count > 0)
            //    {
            //        gvTransfer.DataSource = dT;
            //        gvTransfer.DataBind();
            //    }
            //}
        }

        protected void gvGoodTransFer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Transfer")
            {

                Response.Redirect("GoodTransfer.aspx?ReqNo=" + e.CommandArgument.ToString());
            }




        }

        protected void gvreceivedr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Exp")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                string DcNo = arg[0];
                string Date = Convert.ToDateTime(arg[1]).ToString("dd/MM/yyyy h:mm tt");
                DataSet ds = new DataSet();
                //if (scode == "Production")
                //{
                ds = objbs.InterGoodReceivedListExp(DcNo, scode);
                //}
                //if (scode == "Production2")
                //{
                //    ds = objbs.GoodReceivedListExp2(DcNo, Branch);
                //}
                //if (scode == "Production3")
                //{
                //    ds = objbs.GoodReceivedListExpNellai(DcNo, Branch);
                //}

                //if (scode == "Production4")
                //{
                //    ds = objbs.GoodReceivedListExpChennai(DcNo, Branch);
                //}
                GridView gridview = new GridView();




                gridview.DataSource = ds.Tables[0];
                gridview.DataBind();


                // gridview.Caption = Branch + "-" + Date + "-Sent Items Details" + "-" + "DC.No" + DcNo;
                gridview.Caption = "Inter Goods Received Details for " + scode + "On " + Date + "-" + "DC.No" + DcNo;

                string filename = "Inter Goods Received Details for " + scode + "On " + Date + "-" + "DC.No" + DcNo;

                Response.ClearContent();
                //Response.AddHeader("content-disposition","attachment;filename=Sent Goods.xls");
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", filename));
                Response.ContentType = "applicatio/excel";
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
                try
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string DcNo = arg[0];
                    string Date = Convert.ToDateTime(arg[1]).ToString("dd/MM/yyyy h:mm tt");
                    DataSet ds = new DataSet();
                    //if (scode == "Production")
                    //{
                    ds = objbs.InterGoodReceivedListExp(DcNo, scode);
                    //}
                    //if (scode == "Production2")
                    //{
                    //    ds = objbs.GoodReceivedListExp2(DcNo, Branch);
                    //}
                    //if (scode == "Production3")
                    //{
                    //    ds = objbs.GoodReceivedListExpNellai(DcNo, Branch);
                    //}

                    //if (scode == "Production4")
                    //{
                    //    ds = objbs.GoodReceivedListExpChennai(DcNo, Branch);
                    //}




                    grid.DataSource = ds.Tables[0];
                    grid.DataBind();
                    string caption = "<h4><b>Inter Goods Received Details" + "</br>" + "Request From :" + scode + "</br>" + "DC No :" + DcNo + "</br>" + "DC Date :" + Convert.ToDateTime(Date).ToString("MM/dd/yyyy hh:MM:tt") + "</br></b></h4> " + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                    grid.Caption = caption;
                    //  grid.GridLines = GridLines.None;

                    //  grid.Caption = scode + "-" + Date + "-Received Items Details" + "-" + "DC.No" + DcNo;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

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
                    //if (scode == "Production")
                    //{
                    ds = objbs.InterGoodReceivedListExp(DcNo, scode);
                    //}
                    //if (scode == "Production2")
                    //{
                    //    ds = objbs.GoodReceivedListExp2(DcNo, Branch);
                    //}
                    //if (scode == "Production3")
                    //{
                    //    ds = objbs.GoodReceivedListExpNellai(DcNo, Branch);
                    //}

                    //if (scode == "Production4")
                    //{
                    //    ds = objbs.GoodReceivedListExpChennai(DcNo, Branch);
                    //}




                    grid.DataSource = ds.Tables[0];
                    grid.DataBind();
                    // grid.GridLines = GridLines.None;

                    //  grid.Caption = Branch + "-" + Date + "-Sent Items Details" + "-" + "DC.No" + DcNo;
                    //    grid.Caption = "Goods Received Details for " + scode + "On " + Date + "-" + "DC.No" + DcNo;
                    string caption = "Inter Goods Received Details" + "</br>" + "Request From :" + scode + "</br>" + "DC No :" + DcNo + "</br>" + "DC Date :" + Convert.ToDateTime(Date).ToString("dd/MM/yyyy hh:MM:tt") + "</br>";
                    grid.Caption = caption;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

                    //grid.Visible = false;

                }
                catch
                {

                }
            }
        }
    }
}