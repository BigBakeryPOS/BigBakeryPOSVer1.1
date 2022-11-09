using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;


namespace Billing.Accountsbootstrap
{
    public partial class FullSalesReport2 : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string FirstEntry = "";
        string Label123 = "";
        string Password = "";

        double GMargin = 0;
        double GBasicValue = 0;
        double GGSTAmt = 0;
        double GNetAmount = 0;
        string AllBranchAccess = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                btnsearch.Enabled = false;
                btnexcel.Enabled = false;
               
                txtfrmdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objBs.GetBranch_New("All");
                else
                    dsbranch = objBs.GetBranch_New(sTableName);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "Select Branch");
                else
                    ddlBranch.Enabled = false;
               

            }
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txtfrmdate.Text);
                DateTime Toady = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txtfrmdate.Text = "";
                }
            }
        }

        protected void txtpassword_OnTextChanged(object sender, EventArgs e)
        {
            DataSet adminpass = objBs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
            if (adminpass.Tables[0].Rows.Count > 0)
            {
                btnsearch.Enabled = true;
                btnexcel.Enabled = true;
                btnpdf.Enabled = true;
                txtpassword.Text = adminpass.Tables[0].Rows[0]["AdminPass"].ToString();
            }
            else
            {
                btnsearch.Enabled = false;
                btnexcel.Enabled = false;
                btnpdf.Enabled = false;
                txtpassword.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
                return;

            }

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            // if (ddlcat.SelectedValue != "Select Category")
            {
                if (txtfrmdate.Text == "--Select Date--" || txtfrmdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Date!!!.');", true);
                    return;
                }

                if (ddlBranch.SelectedValue == "Select Branch")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Branch.');", true);
                    return;
                }

                //if (sTableName == "CO1")
                //{
                //    Label123 = "Blaack Forest Bakery Services";
                //}
                //else if (sTableName == "CO2")
                //{
                //    Label123 = "Blaack Forest Bakery Services";
                //}
                //else if (sTableName == "CO3")
                //{
                //    Label123 = "Shiva Delights";
                //}
                //else if (sTableName == "CO4")
                //{
                //    Label123 = "Fig and honey";
                //}
                //else if (sTableName == "CO5")
                //{
                //    Label123 = "Blaack Forest Bakery Services";
                //}

                //else if (sTableName == "CO6")
                //{
                //    Label123 = "Maduravayol";
                //}

                //else if (sTableName == "CO7")
                //{
                //    Label123 = "purasavakkam";
                //}

                //else if (sTableName == "CO8")
                //{
                //    Label123 = "Chennai Pothys";
                //}


                //else if (sTableName == "CO9")
                //{
                //    Label123 = "Thirunelveli";
                //}


                //else if (sTableName == "CO10")
                //{
                //    Label123 = "Periyar";
                //}

                //else if (sTableName == "CO11")
                //{
                //    Label123 = "Blaack Forest Bakery Services";
                //}
                Label123 = ddlBranch.SelectedItem.Text;
                //  lblstkreturn.Text = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");


                //////DataSet adminpass = objBs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
                //////if (adminpass.Tables[0].Rows.Count > 0)
                //////{
                //////    btnsearch.Enabled = true;
                //////    btnexcel.Enabled = true;
                //////    txtpassword.Text = adminpass.Tables[0].Rows[0]["AdminPass"].ToString();
                //////}
                //////else
                //////{
                //////    btnsearch.Enabled = false;
                //////    btnexcel.Enabled = false;
                //////    txtpassword.Text = "";
                //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
                //////    return;

                //////}
              
                {
                   
                   
                    DataSet dstd = new DataSet();

                    DataSet FullValues = objBs.GetfulltaxvalNew(ddlBranch.SelectedValue, txtfrmdate.Text, txttodate.Text);
                    gvSalesValue.Caption = "ORDER";

                    if (FullValues.Tables[0].Rows.Count > 0)
                    {
                        decimal Amount = 0;
                        decimal SubTotal = 0;
                        decimal CGST = 0;
                        decimal SGST = 0;

                        DataTable dttt;
                        DataRow drNew;
                        DataColumn dct;

                        dttt = new DataTable();


                        dct = new DataColumn("BillNo");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("OrderNo");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("BookNo");
                        dttt.Columns.Add(dct);


                        dct = new DataColumn("OrderDate");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("NetAmount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Amount");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("Paytype");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("SubTotal");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("CGST");
                        dttt.Columns.Add(dct);

                        dct = new DataColumn("SGST");
                        dttt.Columns.Add(dct);

                        dstd.Tables.Add(dttt);

                        foreach (DataRow dr in FullValues.Tables[0].Rows)
                        {
                            drNew = dttt.NewRow();
                            drNew["BillNo"] = dr["BillNo"];
                            drNew["OrderNo"] = dr["OrderNo"];
                            drNew["BookNo"] = dr["BookNo"];
                            drNew["OrderDate"] =Convert.ToDateTime(dr["OrderDate"]).ToString("dd/MMM/yyyy");

                            drNew["NetAmount"] = Convert.ToDecimal(dr["NetAmount"]).ToString("f2");
                            drNew["Amount"] = Convert.ToDecimal(dr["Amount"]).ToString("f2");
                            drNew["Paytype"] = dr["Paytype"];

                            drNew["SubTotal"] = Convert.ToDecimal(dr["SubTotal"]).ToString("f2");
                            drNew["CGST"] = Convert.ToDecimal(dr["CGST"]).ToString("f2");
                            drNew["SGST"] = Convert.ToDecimal(dr["SGST"]).ToString("f2");

                            //  drNew["NetAmount"] = Convert.ToDecimal(dr["NetAmount"]);
                            Amount = Amount + Convert.ToDecimal(dr["Amount"]);
                            SubTotal = SubTotal + Convert.ToDecimal(dr["SubTotal"]);
                            CGST = CGST + Convert.ToDecimal(dr["CGST"]);
                            SGST = SGST + Convert.ToDecimal(dr["SGST"]);

                            dstd.Tables[0].Rows.Add(drNew);
                        }

                        drNew = dttt.NewRow();
                        drNew["BillNo"] = "";
                        drNew["OrderNo"] = "";
                        drNew["BookNo"] = "";
                        drNew["OrderDate"] = "";

                        drNew["NetAmount"] = "Total";
                        drNew["Amount"] = Amount.ToString("f2");
                        drNew["Paytype"] = "";

                        drNew["SubTotal"] = SubTotal.ToString("f2");
                        drNew["CGST"] = CGST.ToString("f2");
                        drNew["SGST"] = SGST.ToString("f2");
                        dstd.Tables[0].Rows.Add(drNew);
                    }

                    gvSalesValue.DataSource = dstd;
                    gvSalesValue.DataBind();

                }

                ////ds = objBs.selectgrnmp111(ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);
                ////if (ds.Tables[0].Rows.Count > 0)
                ////{
                ////    gvgrnmp.DataSource = ds;
                ////    gvgrnmp.DataBind();
                ////}
                ////else
                ////{
                ////    gvgrnmp.DataSource = null;
                ////    gvgrnmp.DataBind();
                ////}

                ////ds1 = objBs.selectret111(sTableName, ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);

                ////if (ds1.Tables[0].Rows.Count > 0)
                ////{
                ////    gvreturn.DataSource = ds1;
                ////    gvreturn.DataBind();
                ////}
                ////else
                ////{
                ////    gvreturn.DataSource = null;
                ////    gvreturn.DataBind();
                ////}
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Category')", true);

            //    return;
            //}
        }




        protected void gvSalesValue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Margin"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BasicValue"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTAmt"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));


                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;
                GGSTAmt = GGSTAmt + GSTAmt;
                GNetAmount = GNetAmount + NetAmount;

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "GrandTotal";

                e.Row.Cells[6].Text = GMargin.ToString("f2");
                e.Row.Cells[7].Text = GBasicValue.ToString("f2");

                e.Row.Cells[9].Text = GGSTAmt.ToString("f2");
                e.Row.Cells[11].Text = GGSTAmt.ToString("f2");

                e.Row.Cells[12].Text = GNetAmount.ToString("f2");


            }
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            ExportToPDF(sender, e);
        }
        protected void ExportToPDF(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //gvSalesValue.HeaderRow.Cells[7].Visible = false;
                    //gvSalesValue.HeaderRow.Cells[12].Visible = false;
                    //gvSalesValue.HeaderRow.Cells[13].Visible = false;
                    ////GridViewm.HeaderRow.Cells[16].Visible = false;
                    //gvSalesValue.HeaderRow.Cells[17].Visible = false;

                    gvSalesValue.RenderControl(hw);

                    gvSalesValue.HeaderRow.Style.Add("width", "6%");
                    gvSalesValue.HeaderRow.Style.Add("font-size", "8px");
                    gvSalesValue.Style.Add("text-decoration", "none");
                    gvSalesValue.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                    gvSalesValue.Style.Add("font-size", "6px");

                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=MonthlyReport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

            //txtFrom.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
            //txtto.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //From = DateTime.Parse(txtFrom.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //To = DateTime.Parse(txtto.Text.Trim(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            //DataSet ds = objbs.GetMarketingEdit_Report(Convert.ToDateTime(From), Convert.ToDateTime(To));
            //GridViewm.DataSource = ds.Tables[0];
            //GridViewm.DataBind();
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {

            DataSet FullValues = new DataSet();
            HtmlForm form = new HtmlForm();
            Response.Clear();
            Response.Buffer = true;
            string filename = "Reports_" + DateTime.Now.ToString() + ".xls";
            DataSet dstd = new DataSet();

            //if (ddlsalestype.SelectedValue == "1")
            //{
            //    FullValues = objBs.GetFullValuesForSalesdate1(sTableName, txtfrmdate.Text, txttodate.Text);
            //    gvSalesValue.Caption = "SALES";
            //    gvSalesValue.DataSource = FullValues;
            //    gvSalesValue.DataBind();

            //}
            //else
            {
                FullValues = objBs.GetfulltaxvalNew(ddlBranch.SelectedValue, txtfrmdate.Text, txttodate.Text);
                //gvSalesValue.Caption = "ORDER";
                //gvSalesValue.DataSource = FullValues;
                //gvSalesValue.DataBind();

            }



            if (FullValues.Tables[0].Rows.Count > 0)
            {
                decimal Amount = 0;
                decimal SubTotal = 0;
                decimal CGST = 0;
                decimal SGST = 0;

                DataTable dttt;
                DataRow drNew;
                DataColumn dct;

                dttt = new DataTable();


                dct = new DataColumn("BillNo");
                dttt.Columns.Add(dct);

                dct = new DataColumn("OrderNo");
                dttt.Columns.Add(dct);

                dct = new DataColumn("BookNo");
                dttt.Columns.Add(dct);


                dct = new DataColumn("OrderDate");
                dttt.Columns.Add(dct);

                dct = new DataColumn("NetAmount");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Amount");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Paytype");
                dttt.Columns.Add(dct);

                dct = new DataColumn("SubTotal");
                dttt.Columns.Add(dct);

                dct = new DataColumn("CGST");
                dttt.Columns.Add(dct);

                dct = new DataColumn("SGST");
                dttt.Columns.Add(dct);

                dstd.Tables.Add(dttt);

                foreach (DataRow dr in FullValues.Tables[0].Rows)
                {
                    drNew = dttt.NewRow();
                    drNew["BillNo"] = dr["BillNo"];
                    drNew["OrderNo"] = dr["OrderNo"];
                    drNew["BookNo"] = dr["BookNo"];
                    drNew["OrderDate"] = Convert.ToDateTime(dr["OrderDate"]).ToString("dd/MMM/yyyy");

                    drNew["NetAmount"] = Convert.ToDecimal(dr["NetAmount"]).ToString("f2");
                    drNew["Amount"] = Convert.ToDecimal(dr["Amount"]).ToString("f2");
                    drNew["Paytype"] = dr["Paytype"];

                    drNew["SubTotal"] = Convert.ToDecimal(dr["SubTotal"]).ToString("f2");
                    drNew["CGST"] = Convert.ToDecimal(dr["CGST"]).ToString("f2");
                    drNew["SGST"] = Convert.ToDecimal(dr["SGST"]).ToString("f2");

                    //  drNew["NetAmount"] = Convert.ToDecimal(dr["NetAmount"]);
                    Amount = Amount + Convert.ToDecimal(dr["Amount"]);
                    SubTotal = SubTotal + Convert.ToDecimal(dr["SubTotal"]);
                    CGST = CGST + Convert.ToDecimal(dr["CGST"]);
                    SGST = SGST + Convert.ToDecimal(dr["SGST"]);

                    dstd.Tables[0].Rows.Add(drNew);
                }

                drNew = dttt.NewRow();
                drNew["BillNo"] = "";
                drNew["OrderNo"] = "";
                drNew["BookNo"] = "";
                drNew["OrderDate"] = "";

                drNew["NetAmount"] = "Total";
                drNew["Amount"] = Amount.ToString("f2");
                drNew["Paytype"] = "";

                drNew["SubTotal"] = SubTotal.ToString("f2");
                drNew["CGST"] = CGST.ToString("f2");
                drNew["SGST"] = SGST.ToString("f2");
                dstd.Tables[0].Rows.Add(drNew);
            }

            ExportToExcel(filename, dstd);
        }

        private void ExportToExcel(string filename, DataSet dt)
        {
            if (dt.Tables[0].Rows.Count > 0)
            {

                string StoreName = "";
                string Place = "";

                DataSet adminpass = objBs.getAddressDetails(lblUser.Text, Password);

                StoreName = adminpass.Tables[0].Rows[0]["StoreName"].ToString();
                Place = adminpass.Tables[0].Rows[0]["Place"].ToString();

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
               
                    dgGrid.Caption =Place + StoreName + " Order Report Generated From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

                
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                dgGrid.FooterStyle.ForeColor = System.Drawing.Color.Red;
                dgGrid.HeaderStyle.Font.Bold = true;
                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();


                //////DataGrid dgGridCaption = new DataGrid();
                //////dgGridCaption.Caption = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                //////dgGridCaption.DataBind();

                //////System.IO.StringWriter tw = new System.IO.StringWriter();
                //////System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                //////dgGridCaption.RenderControl(hw);


                //////GridViewRow gv2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                //////TableHeaderCell cell2 = new TableHeaderCell();
                //////cell2.Text = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                //////cell2.Height = 300;
                //////cell2.Width = 10000;
                //////gv2.Controls.Add(cell2);
                //////gv2.RenderControl(hw);

                //////dgGridCaption.RenderControl(hw);

                //////if (dt.Tables.Count > 0)
                //////{
                //////    if (dt != null)
                //////    {
                //////        if (dt.Tables[0].Rows.Count > 0)
                //////        {
                //////            DataGrid dgGrid = new DataGrid();
                //////            dgGrid.DataSource = dt;
                //////            dgGrid.DataBind();
                //////            dgGrid.Caption = "GRN (+)(-)";
                //////            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                //////            dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                //////            dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                //////            dgGrid.FooterStyle.ForeColor = System.Drawing.Color.Red;
                //////            dgGrid.HeaderStyle.Font.Bold = true;
                //////            //Get the HTML for the control.
                //////            dgGrid.RenderControl(hw);
                //////        }
                //////    }
                //////}

                ////////Write the HTML back to the browser.
                //////Response.ContentType = "application/vnd.ms-excel";
                //////Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                //////this.EnableViewState = false;
                //////Response.Write(tw.ToString());
                //////Response.End();
            }
        }
    }
}
