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
    public partial class KitchenPurchaseReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";
        System.Globalization.CultureInfo Cul = new System.Globalization.CultureInfo("en-GB", true);
        protected void Page_Load(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (!IsPostBack)
            {

                DataSet dsCustomer = objBs.SupplierList11();
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlsuplier.DataSource = dsCustomer.Tables[0];
                    ddlsuplier.DataTextField = "LedgerName";
                    ddlsuplier.DataValueField = "LedgerID";
                    ddlsuplier.DataBind();
                    ddlsuplier.Items.Insert(0, "All");
                }

                DataSet dsIngredien = objBs.GetIngredientall();
                if (dsIngredien.Tables[0].Rows.Count > 0)
                {
                    ddlraw.DataSource = dsIngredien.Tables[0];
                    ddlraw.DataTextField = "IngredientName";
                    ddlraw.DataValueField = "IngridID";
                    ddlraw.DataBind();
                    ddlraw.Items.Insert(0, "All");
                }

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy");



             //   string FromDate = txtfromdate.ToString("dd/MM/yyyy");

                DateTime From1 = new DateTime();
                DateTime To1 = new DateTime();

                From1 = DateTime.Parse(Convert.ToDateTime(txtfromdate.Text).ToString("yyyy/MM/dd"), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                To1 = DateTime.Parse(Convert.ToDateTime(txttodate.Text).ToString("yyyy/MM/dd"), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);


                //DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                //string FromDate = sFrom.ToString("yyyy-MM-dd");
                //DateTime sTO = Convert.ToDateTime(txttodate.Text);
                //string ToDate = sTO.ToString("yyyy-MM-dd");


                DataSet pending = objBs.getpurchasedetails(sTableName, ddlsuplier.SelectedValue, Convert.ToDateTime(From1).ToString("yyyy/MM/dd hh:mm tt"), Convert.ToDateTime(To1).ToString("yyyy/MM/dd hh:mm tt"), ddlraw.SelectedValue);
                if (pending.Tables[0].Rows.Count > 0)
                {
                    BankGrid.DataSource = pending;
                    BankGrid.DataBind();
                }
                else
                {
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
                string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                BankGrid.Caption = caption;

                //DataSet ds = objBs.getpurchasedetailsall(sTableName);
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
        }

       
        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            getdate();
        }

        protected void ddlsuplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            getdate();
        }

        public void getdate()
        {
            

            //DateTime FromDate = Convert.ToDateTime(txtfromdate.Text);
            //DateTime ToDate = Convert.ToDateTime(txttodate.Text);


            //DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
            //string FromDate = sFrom.ToString("yyyy-MM-dd");
            //DateTime sTO = Convert.ToDateTime(txttodate.Text);
            //string ToDate = sTO.ToString("yyyy-MM-dd");

            DateTime From1 = new DateTime();
            DateTime To1 = new DateTime();

            From1 = DateTime.Parse(Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy"), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            To1 = DateTime.Parse(Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy"), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            DataSet pending = objBs.getpurchasedetails(sTableName, ddlsuplier.SelectedValue, Convert.ToDateTime(From1).ToString("yyyy/MM/dd"), Convert.ToDateTime(To1).ToString("yyyy/MM/dd"), ddlraw.SelectedValue);
            if (pending.Tables[0].Rows.Count > 0)
            {
                BankGrid.DataSource = pending;
                BankGrid.DataBind();
            }
            else
            {
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
            string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
            BankGrid.Caption = caption;
        }

        protected void btnPrintFromCodeBehind_Click(object sender, EventArgs e)
        {
            try
            {
                //   if (rdbtype.SelectedValue == "1")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
                    string caption = " <h4><b>" + " Store :  " + BranchNAme + " " + StoreName + " Generate On " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + " </b></h4> ";
                    BankGrid.Caption = caption;
                }

            }
            catch { }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            // if (rdbtype.SelectedValue == "1")
            {
                #region
                GridView gridview = new GridView();
                DataSet ds = new DataSet();
               
                {
                    DateTime From1 = new DateTime();
                    DateTime To1 = new DateTime();

                    From1 = DateTime.Parse(Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy"), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    To1 = DateTime.Parse(Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy"), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                    ds = objBs.getpurchasedetails(sTableName, ddlsuplier.SelectedValue, Convert.ToDateTime(From1).ToString("yyyy/MM/dd"), Convert.ToDateTime(To1).ToString("yyyy/MM/dd"), ddlraw.SelectedValue);
                    gridview.Caption = " Store Stock Report  Generated on " + DateTime.Now.ToString();
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=StockReport.xls");
                //Response.ContentType = "applicatio/excel";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gridview.AllowPaging = false;
                gridview.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
                gridview.AllowPaging = true;

                #endregion
            }

        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            ExportToPDF(sender, e);
        }
        protected void ExportToPDF(object sender, EventArgs e)
        {
            //if (rdbtype.SelectedValue == "1")
            {
                if (BankGrid.Rows.Count > 0)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        #region
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            BankGrid.RenderControl(hw);

                            BankGrid.HeaderRow.Style.Add("width", "6%");
                            BankGrid.HeaderRow.Style.Add("font-size", "8px");
                            BankGrid.Style.Add("text-decoration", "none");
                            BankGrid.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                            BankGrid.Style.Add("font-size", "6px");

                            StringReader sr = new StringReader(sw.ToString());
                            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=StockReport.pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);

                            Response.Write(pdfDoc);
                            Response.End();
                        }

                        #endregion
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Data.');", true);
                    return;
                }
            }



        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}