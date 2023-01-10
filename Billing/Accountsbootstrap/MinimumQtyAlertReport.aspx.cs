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
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;
namespace Billing.Accountsbootstrap
{
    public partial class MinimumQtyAlertReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string Label123 = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";
        string logintype = "";
        double Available_QTY = 0; double TotalAmount = 0;
        string ratesetting = "";
        string qtysetting = "";

        private string connnectionString;
        private string connnectionStringMain;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            logintype = Request.Cookies["userInfo"]["LoginTypeId"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (!IsPostBack)
            {
                DataSet dsCategory = objBs.selectcategorymasterforproductionentry();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                }

                DataSet ds = new DataSet();
                //if (sTableName == "admin")
                //{
                //    ds = objBs.getstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);
                //    gvstock.DataSource = ds;
                //    gvstock.DataBind();

                //}
                //else
                //{
                admin.Visible = false;
                ds = objBs.getMinstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);

                string caption1 = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                gvstock.Caption = caption1;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["MinimumStock"]) > Convert.ToInt32(ds.Tables[0].Rows[0]["Available_Qty"]))
                {
                    gvstock.DataSource = ds;
                    gvstock.DataBind();
                }
                // rdbtype.Enabled = true;
                //}
            }

        }




        protected void page_change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = new DataSet();
            gvstock.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gvstock.DataSource = dvEmployee;
            gvstock.DataBind();
        }

        protected void gvstock_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string qtytype = "D";
            string Available = "0";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                qtytype = (DataBinder.Eval(e.Row.DataItem, "qtytype")).ToString();


                if (qtytype == "D")
                {
                    e.Row.Cells[4].Text = Convert.ToDouble(e.Row.Cells[4].Text).ToString("0");
                }
                else
                {
                    //DataBinder.Eval(e.Row.DataItem, "Available_QTY") = Convert.ToDouble(Available).ToString("" + qtysetting + "");
                    e.Row.Cells[4].Text = Convert.ToDouble(e.Row.Cells[4].Text).ToString("" + qtysetting + "");
                }



                }

                ////DataSet dlow = objBs.stockcolour();
                ////if (sTableName != "admin")
                ////{
                ////   //gvstock.Columns[4].Visible=false;
                ////   //gvstock.Columns[5].Visible = false;
                ////}
                ////if (dlow.Tables[0].Rows.Count > 0)
                ////{
                ////    for (int i = 0; i < dlow.Tables[0].Rows.Count; i++)
                ////    {
                ////        decimal iMinQty = Convert.ToDecimal(dlow.Tables[0].Rows[i]["MinQty"].ToString());
                ////        if (e.Row.RowType == DataControlRowType.DataRow)
                ////        {
                ////            int dStock = Convert.ToInt32(e.Row.Cells[3].Text);
                ////            foreach (TableCell cell in e.Row.Cells)
                ////            {
                ////                if (iMinQty > 0)
                ////                {
                ////                    if (dStock <= iMinQty)
                ////                    {
                ////                        cell.BackColor = Color.Yellow;
                ////                    }
                ////                }
                ////                if (dStock <= 0)
                ////                {
                ////                    cell.BackColor = Color.Red;
                ////                }
                ////            }
                ////        }
                ////    }

                //}//if condition

            }

        protected void ddlstock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objBs.getMinstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["MinimumStock"]) > Convert.ToInt32(ds.Tables[0].Rows[0]["Available_Qty"]))
            {
                gvstock.DataSource = ds;
                gvstock.DataBind();
            }

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //if (sTableName == "admin")
            //{
            //    ds = objBs.getstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);
            //    gvstock.DataSource = ds;
            //    gvstock.DataBind();

            //    //decimal dtotal = 0;
            //    //decimal Qty = 0;
            //    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    //{
            //    //    dtotal += Convert.ToDecimal(ds.Tables[0].Rows[i]["StockAmount"].ToString());
            //    //    Qty += Convert.ToDecimal(ds.Tables[0].Rows[i]["Available_QTY"].ToString());
            //    //}

            //}
            //else
            //{
            ds = objBs.getMinstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["MinimumStock"]) > Convert.ToInt32(ds.Tables[0].Rows[0]["Available_Qty"]))
            {


                gvstock.DataSource = ds;
                gvstock.DataBind();
            }
            //  }
        }

        protected void gvstock_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{


            //    e.Row.Attributes.Add("onMouseOver", "this.style.background='#eeff00'");

            //    e.Row.Attributes.Add("onMouseOut", "this.style.background='#ffffff'");


            //}


        }



        //protected void btnPrint_Click(object sender, EventArgs e)
        //{

        //}

        //protected void btnApp_Click(object sender, EventArgs e)
        //{
        //    //    Process p = new Process();
        //    //    p.StartInfo.FileName = @"E:\magil hotel\magilam\magilam\bin\Debug\magilam.exe";
        //    //    p.Start();
        //}

        //protected void btnsyncclick(object sender, EventArgs e)
        //{


        //    connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
        //    connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



        //    SqlConnection source = new SqlConnection(connnectionString);
        //    SqlConnection destination = new SqlConnection(connnectionStringMain);



        //    SqlCommand cmditem = new SqlCommand("truncate table tblStock_" + sTableName + "", destination);


        //    source.Open();
        //    destination.Open();
        //    cmditem.ExecuteNonQuery();

        //    cmditem = new SqlCommand("SELECT * FROM tblStock_" + sTableName + "", source);




        //    SqlBulkCopy bulkData = new SqlBulkCopy(destination);


        //    SqlDataReader reader = cmditem.ExecuteReader();
        //    bulkData.DestinationTableName = "tblStock_" + sTableName + "";
        //    bulkData.WriteToServer(reader);
        //    reader.Close();

        //    bulkData.Close();
        //    destination.Close();
        //    source.Close();

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        //}



        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdbtype.SelectedValue == "1")
            //{
            //    gvStockValue.DataSource = null;
            //    gvStockValue.DataBind();

            //    admin.Visible = false;
            DataSet ds = objBs.getMinstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);

            string caption1 = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvstock.Caption = caption1;
                gvstock.DataSource = ds;
                gvstock.DataBind();
            }
            else
            {
                gvstock.DataSource = null;
                gvstock.DataBind();
            }
        }
    }
            //else
            //{
            //    gvstock.DataSource = null;
            //    gvstock.DataBind();

                //string caption1 = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";

                //DataSet dsStockValue = objBs.getStockValueReport(sTableName, ddlcategory.SelectedValue, "All");
                //if (dsStockValue.Tables[0].Rows.Count > 0)
                //{
                //    gvStockValue.Caption = caption1;
                //    gvStockValue.DataSource = dsStockValue;
                //    gvStockValue.DataBind();
                //}
                //else
                //{
                //    gvStockValue.DataSource = null;
                //    gvStockValue.DataBind();
                //}
           // }
        }
        //protected void btnPrintFromCodeBehind_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdbtype.SelectedValue == "1")
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        //            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
        //            gvstock.Caption = caption;
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid1", "printGrid1();", true);
        //            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
        //            gvstock.Caption = caption;
        //        }
        //    }
        //    catch { }
        //}
        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    if (rdbtype.SelectedValue == "1")
        //    {
        //        #region
        //        GridView gridview = new GridView();
        //        DataSet ds = new DataSet();
        //        if (sTableName == "admin")
        //        {
        //            ds = objBs.getstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);
        //            gridview.Caption = Label123 + " Stock Report  Generated on " + DateTime.Now.ToString();
        //            gridview.DataSource = ds;
        //            gridview.DataBind();

        //        }
        //        else
        //        {
        //            ds = objBs.getstockdetgrid(sTableName, ddlcategory.SelectedValue, logintype);
        //            gridview.Caption = Label123 + " Stock Report  Generated on " + DateTime.Now.ToString();
        //            gridview.DataSource = ds;
        //            gridview.DataBind();
        //        }
        //        Response.ClearContent();
        //        Response.AddHeader("content-disposition",
        //            "attachment;filename=StockReport.xls");
        //        //Response.ContentType = "applicatio/excel";
        //        Response.ContentType = "application/vnd.ms-excel";
        //        StringWriter sw = new StringWriter(); ;
        //        HtmlTextWriter htm = new HtmlTextWriter(sw);
        //        gridview.AllowPaging = false;
        //        gridview.RenderControl(htm);
        //        Response.Write(sw.ToString());
        //        Response.End();
        //        gridview.AllowPaging = true;

        //        #endregion
        //    }
        //    else
        //    {
        //        gvStockValue.Caption = Label123 + " Stock Report  Generated on " + DateTime.Now.ToString();
        //        Response.Clear();
        //        Response.AddHeader("content-disposition", "attachment;filename=StockValueReport.xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.ms-excel";
        //        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //        div1.RenderControl(htmlWrite);
        //        Response.Write(stringWrite.ToString());
        //        Response.End();
        //    }
        //}

        // Admin PassWord
        //protected void txtpassword_OnTextChanged(object sender, EventArgs e)
        //{
        //    DataSet adminpass = objBs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
        //    if (adminpass.Tables[0].Rows.Count > 0)
        //    {
        //        rdbtype.Enabled = true;
        //        txtpassword.Attributes.Add("value", adminpass.Tables[0].Rows[0]["AdminPass"].ToString());
        //    }
        //    else
        //    {
        //        rdbtype.SelectedValue = "1";
        //        rdbtype.Enabled = false;
        //        //txtpassword.Attributes.Add("value", "");
        //        txtpassword.Attributes.Clear();

        //        gvStockValue.DataSource = null;
        //        gvStockValue.DataBind();

        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
        //        return;

        //    }
        //}

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
        //       server control at run time. */
        //}

        //protected void gvStockValue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Available_QTY += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Available_QTY"));
        //        TotalAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
        //    }
        //    else if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        e.Row.Cells[5].Text = "Total:-";
        //        e.Row.Cells[6].Text = Available_QTY.ToString("f2");
        //        e.Row.Cells[7].Text = TotalAmount.ToString("f2");
        //    }

        //    string qtytype = "D";
        //    string Available = "0";

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        qtytype = (DataBinder.Eval(e.Row.DataItem, "qtytype")).ToString();


        //        if (qtytype == "D")
        //        {
        //            e.Row.Cells[6].Text = Convert.ToDouble(e.Row.Cells[6].Text).ToString("0");
        //            e.Row.Cells[3].Text = Convert.ToDouble(e.Row.Cells[3].Text).ToString("" + ratesetting + "");
        //            //e.Row.Cells[4].Text = Convert.ToDouble(e.Row.Cells[4].Text).ToString("" + qtysetting + "");
        //            e.Row.Cells[5].Text = Convert.ToDouble(e.Row.Cells[5].Text).ToString("" + ratesetting + "");
        //            e.Row.Cells[7].Text = Convert.ToDouble(e.Row.Cells[7].Text).ToString("" + ratesetting + "");
        //        }
        //        else
        //        {
        //            //DataBinder.Eval(e.Row.DataItem, "Available_QTY") = Convert.ToDouble(Available).ToString("" + qtysetting + "");
        //            e.Row.Cells[6].Text = Convert.ToDouble(e.Row.Cells[6].Text).ToString("" + qtysetting + "");
        //            e.Row.Cells[3].Text = Convert.ToDouble(e.Row.Cells[3].Text).ToString("" + ratesetting + "");
        //            //e.Row.Cells[4].Text = Convert.ToDouble(e.Row.Cells[4].Text).ToString("" + qtysetting + "");
        //            e.Row.Cells[5].Text = Convert.ToDouble(e.Row.Cells[5].Text).ToString("" + ratesetting + "");
        //            e.Row.Cells[7].Text = Convert.ToDouble(e.Row.Cells[7].Text).ToString("" + ratesetting + "");
        //        }



        //    }

        //}


        //protected void btnpdf_Click(object sender, EventArgs e)
        //{
        //    ExportToPDF(sender, e);
        //}
        //protected void ExportToPDF(object sender, EventArgs e)
        //{
        //    if (rdbtype.SelectedValue == "1")
        //    {
        //        if (gvstock.Rows.Count > 0)
        //        {
        //            using (StringWriter sw = new StringWriter())
        //            {
        //                #region
        //                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //                {
        //                    gvstock.RenderControl(hw);

        //                    gvstock.HeaderRow.Style.Add("width", "6%");
        //                    gvstock.HeaderRow.Style.Add("font-size", "8px");
        //                    gvstock.Style.Add("text-decoration", "none");
        //                    gvstock.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //                    gvstock.Style.Add("font-size", "6px");

        //                    StringReader sr = new StringReader(sw.ToString());
        //                    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        //                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //                    pdfDoc.Open();
        //                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //                    pdfDoc.Close();
        //                    Response.ContentType = "application/pdf";
        //                    Response.AddHeader("content-disposition", "attachment;filename=StockReport.pdf");
        //                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //                    Response.Write(pdfDoc);
        //                    Response.End();
        //                }

        //                #endregion
        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Data.');", true);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (gvStockValue.Rows.Count > 0)
        //        {
        //            using (StringWriter sw = new StringWriter())
        //            {
        //                #region
        //                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //                {
        //                    gvStockValue.RenderControl(hw);

        //                    gvStockValue.HeaderRow.Style.Add("width", "6%");
        //                    gvStockValue.HeaderRow.Style.Add("font-size", "8px");
        //                    gvStockValue.Style.Add("text-decoration", "none");
        //                    gvStockValue.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //                    gvStockValue.Style.Add("font-size", "6px");

        //                    StringReader sr = new StringReader(sw.ToString());
        //                    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
        //                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //                    pdfDoc.Open();
        //                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //                    pdfDoc.Close();
        //                    Response.ContentType = "application/pdf";
        //                    Response.AddHeader("content-disposition", "attachment;filename=StockValueReport.pdf");
        //                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //                    Response.Write(pdfDoc);
        //                    Response.End();
        //                }

        //                #endregion
        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Data.');", true);
        //            return;
        //        }
        //    }


        //}
   // }

