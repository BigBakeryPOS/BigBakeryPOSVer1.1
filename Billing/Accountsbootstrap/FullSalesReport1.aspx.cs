using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Web.UI.HtmlControls;

namespace Billing.Accountsbootstrap
{
    public partial class FullSalesReport1 : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string Place = "";
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
            //Place = Request.Cookies["userInfo"]["Place"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);

           // StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            Place = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (!IsPostBack)
            {

                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Session["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Session["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                btnsearch.Enabled = false;
                btnexcel.Enabled = false;
                //////txtfrmdate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
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

                //////DataSet dsCategory = objBs.selectcategorymaster();
                //////if (dsCategory.Tables[0].Rows.Count > 0)
                //////{
                //////    ddlcat.DataSource = dsCategory.Tables[0];
                //////    ddlcat.DataTextField = "category";
                //////    ddlcat.DataValueField = "categoryid";
                //////    ddlcat.DataBind();
                //////    ddlcat.Items.Insert(0, "All");

                //////}

                //DataSet FullValues = objBs.GetFullValuesForSales(sTableName);
                //////DataSet FullValues = objBs.GetFullValuesForSalesdate1(sTableName, txtfrmdate.Text,txttodate.Text);
                //////gvSalesValue.Caption = "SALES";
                //////gvSalesValue.DataSource = FullValues;
                //////gvSalesValue.DataBind();



            }
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtpassword_OnTextChanged(object sender, EventArgs e)
        {
            DataSet adminpass = objBs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
            if (adminpass.Tables[0].Rows.Count > 0)
            {
                btnsearch.Enabled = true;
                btnexcel.Enabled = true;
                txtpassword.Text = adminpass.Tables[0].Rows[0]["AdminPass"].ToString();
            }
            else
            {
                btnsearch.Enabled = false;
                btnexcel.Enabled = false;
                txtpassword.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
                return;

            }

        }
        protected void Search_Click(object sender, EventArgs e)
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

            Label123 = ddlBranch.SelectedItem.Text;

            if (ddlsalestype.SelectedValue == "1")
            {
                DataSet FullValues = objBs.GetFullValuesForSalesdate1(ddlBranch.SelectedValue, txtfrmdate.Text, txttodate.Text);
                gvSalesValue.Caption = "SALES";
                gvSalesValue.DataSource = FullValues;
                gvSalesValue.DataBind();

            }
            else
            {
                //DataSet FullValues = objBs.GetFullValuesFororderdate1(sTableName, txtfrmdate.Text, txttodate.Text);
                //gvSalesValue.Caption = "ORDER";
                //gvSalesValue.DataSource = FullValues;
                //gvSalesValue.DataBind();

            }


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

        protected void btnexcel_Click(object sender, EventArgs e)
        {

            DataSet FullValues = new DataSet();
            HtmlForm form = new HtmlForm();
            Response.Clear();
            Response.Buffer = true;
            string filename = "Reports_" + DateTime.Now.ToString() + ".xls";
            DataSet dstd = new DataSet();

            if (ddlsalestype.SelectedValue == "1")
            {
                FullValues = objBs.GetFullValuesForSalesdate1(ddlBranch.SelectedValue, txtfrmdate.Text, txttodate.Text);
                gvSalesValue.Caption = "SALES";
                gvSalesValue.DataSource = FullValues;
                gvSalesValue.DataBind();

            }
            else
            {
                FullValues = objBs.GetFullValuesFororderdate1(sTableName, txtfrmdate.Text, txttodate.Text);
                gvSalesValue.Caption = "ORDER";
                gvSalesValue.DataSource = FullValues;
                gvSalesValue.DataBind();

            }



            if (FullValues.Tables[0].Rows.Count > 0)
            {
                decimal Margin = 0;
                decimal BasicValue = 0;
                decimal GST = 0;
                decimal NetAmount = 0;

                DataTable dttt;
                DataRow drNew;
                DataColumn dct;

                dttt = new DataTable();

                dct = new DataColumn("Branch");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Category");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Name Of Items");
                dttt.Columns.Add(dct);

                dct = new DataColumn("GST");
                dttt.Columns.Add(dct);


                dct = new DataColumn("Qty");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Rate");
                dttt.Columns.Add(dct);

                dct = new DataColumn("TotalRate");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Margin");
                dttt.Columns.Add(dct);

                dct = new DataColumn("BasicValue");
                dttt.Columns.Add(dct);


                dct = new DataColumn("CGST %");
                dttt.Columns.Add(dct);

                dct = new DataColumn("CGST");
                dttt.Columns.Add(dct);

                dct = new DataColumn("SGST %");
                dttt.Columns.Add(dct);

                dct = new DataColumn("SGST");
                dttt.Columns.Add(dct);

                dct = new DataColumn("NetAmount");
                dttt.Columns.Add(dct);
                dstd.Tables.Add(dttt);

                foreach (DataRow dr in FullValues.Tables[0].Rows)
                {
                    drNew = dttt.NewRow();
                    drNew["Category"] = dr["Category"];
                    drNew["Name Of Items"] = dr["Definition"];
                    drNew["GST"] = dr["TAX"];

                    decimal tax = Convert.ToDecimal(dr["TAX"]) / 2;

                    drNew["SGST %"] = tax.ToString("0.00");
                    drNew["CGST %"] = tax.ToString("0.00");

                    drNew["Qty"] = dr["Qty"];
                    drNew["Rate"] = dr["unitprice"];
                    drNew["TotalRate"] = Convert.ToDecimal(dr["TotalRate"]).ToString("f2");

                    drNew["Margin"] = Convert.ToDecimal(dr["Margin"]).ToString("f2");
                    Margin = Margin + Convert.ToDecimal(dr["Margin"]);

                    drNew["BasicValue"] = Convert.ToDecimal(dr["BasicValue"]).ToString("f2");
                    BasicValue = BasicValue + Convert.ToDecimal(dr["BasicValue"]);

                    //drNew["CGST %"] = Convert.ToDecimal(dr["CGST"]).ToString("f2");
                    //drNew["CGST"] = Convert.ToDecimal(dr["GSTAmt"]).ToString("f2");
                    //drNew["SGST %"] = Convert.ToDecimal(dr["CGST"]).ToString("f2");
                    //drNew["SGST"] = Convert.ToDecimal(dr["GSTAmt"]).ToString("f2");

                    GST =  Convert.ToDecimal(dr["GSTAmt"]) / 2;

                    drNew["CGST"] = GST.ToString("0.00");
                    drNew["SGST"] = GST.ToString("0.00");

                    drNew["NetAmount"] = Convert.ToDecimal(dr["NetAmount"]).ToString("f2");
                    NetAmount = NetAmount + Convert.ToDecimal(dr["NetAmount"]);

                    dstd.Tables[0].Rows.Add(drNew);
                }

                drNew = dttt.NewRow();
                drNew["Category"] = "";
                drNew["Name Of Items"] = "";
                drNew["GST"] = "";
                drNew["Qty"] = "";
                drNew["Rate"] = "";
                drNew["TotalRate"] = "";
                drNew["Margin"] = Convert.ToDecimal(Margin.ToString("f2"));
                drNew["BasicValue"] = Convert.ToDecimal(BasicValue.ToString("f2"));
                drNew["CGST %"] = "";
                drNew["CGST"] = Convert.ToDecimal(GST.ToString("f2"));
                drNew["SGST %"] = "";
                drNew["SGST"] = Convert.ToDecimal(GST.ToString("f2"));
                drNew["NetAmount"] = Convert.ToDecimal(NetAmount).ToString("f2");
                dstd.Tables[0].Rows.Add(drNew);
            }

            ExportToExcel(filename, dstd);
        }

        private void ExportToExcel(string filename, DataSet dt)
        {
            if (dt.Tables[0].Rows.Count > 0)
            {

                if (sTableName == "CO1")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }
                else if (sTableName == "CO2")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }
                else if (sTableName == "CO3")
                {
                    Label123 = "Shiva Delights";
                }
                else if (sTableName == "CO4")
                {
                    Label123 = "Fig and honey";
                }
                else if (sTableName == "CO5")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }

                else if (sTableName == "CO6")
                {
                    Label123 = "Maduravayol";
                }

                else if (sTableName == "CO7")
                {
                    Label123 = "purasavakkam";
                }

                else if (sTableName == "CO8")
                {
                    Label123 = "Chennai Pothys";
                }


                else if (sTableName == "CO9")
                {
                    Label123 = "Thirunelveli";
                }


                else if (sTableName == "CO10")
                {
                    Label123 = "Periyar";
                }

                else if (sTableName == "CO11")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                if (ddlsalestype.SelectedValue == "1")
                {
                    // dgGrid.Caption = "Sales Report";
                    dgGrid.Caption = Label123 + " Sales Report Generated From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
                }

                else
                {
                    dgGrid.Caption = Label123 + " Order Report Generated From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");

                }
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
