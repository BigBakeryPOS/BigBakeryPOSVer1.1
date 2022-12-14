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
    public partial class PurchaseFutureExpReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string FirstEntry = "";
        string Label123 = "";

        double GTotalRate = 0;

        double GTotalValue = 0;
        double GMargin = 0;
        double GBasicValue = 0;

        double GCGST = 0;
        double GNetAmount = 0;
        System.Globalization.CultureInfo Cul = new System.Globalization.CultureInfo("en-GB", true);

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();


            if (!IsPostBack)
            {
                DataSet dssubcompany = objBs.GetsubCompanyDetails();
                if (dssubcompany.Tables[0].Rows.Count > 0)
                {
                    drpsubcompany.DataSource = dssubcompany.Tables[0];
                    drpsubcompany.DataTextField = "CustomerName";
                    drpsubcompany.DataValueField = "subComapanyID";
                    drpsubcompany.DataBind();
                    drpsubcompany.Items.Insert(0, "All");
                }

            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            DataSet ds1;
            DateTime sFrom = Convert.ToDateTime(DateTime.Now.ToString());
            int adddate = Convert.ToInt32(txtnoofdays.Text);
            DateTime Expdate = sFrom.AddDays(adddate);

            string FromDate = Expdate.ToString("dd/MM/yyyy");

            DateTime From1 = new DateTime();

            From1 = DateTime.Parse(FromDate.ToString(), Cul, System.Globalization.DateTimeStyles.NoCurrentDateDefault);

            ds1 = objBs.PurExpirydateReport(sTableName, From1, drpsubcompany.SelectedValue);

            gvSalesValue.DataSource = ds1;
            gvSalesValue.DataBind();          
        }




        protected void gvSalesValue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double TotalRate = 0;

            double TotalValue = 0;
            double Margin = 0;
            double BasicValue = 0;

            double CGST = 0;
            double NetAmount = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalRate"));

                TotalValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalValue"));
                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Margin"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BasicValue"));

                CGST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CGST"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GTotalRate = GTotalRate + TotalRate;

                GTotalValue = GTotalValue + TotalValue;
                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;

                GCGST = GCGST + CGST;
                GNetAmount = GNetAmount + NetAmount;


            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "GrandTotal";
                e.Row.Cells[6].Text = GTotalRate.ToString("f2");

                e.Row.Cells[7].Text = GTotalValue.ToString("f2");
                e.Row.Cells[8].Text = GMargin.ToString("f2");
                e.Row.Cells[9].Text = GBasicValue.ToString("f2");

                e.Row.Cells[11].Text = GCGST.ToString("f2");
                e.Row.Cells[13].Text = GCGST.ToString("f2");
                e.Row.Cells[14].Text = GNetAmount.ToString("f2");

            }
        }

        //protected void btnexcel_Click(object sender, EventArgs e)
        //{
        //    HtmlForm form = new HtmlForm();
        //    Response.Clear();
        //    Response.Buffer = true;

        //    string filename = "Stock Return and GRN(+)(-)_" + DateTime.Now.ToString() + ".xls";


        //    DataSet ds = new DataSet();
        //    DataSet ds1 = new DataSet();

        //    DataSet dstd1 = new DataSet();
        //    DataSet dstd2 = new DataSet();

        //    ds = objBs.selectgrnmp111(ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        //gvgrnmp.DataSource = ds;
        //        //gvgrnmp.DataBind();


        //        DataTable dttt;
        //        DataRow drNew;
        //        DataColumn dct;

        //        dttt = new DataTable();


        //        dct = new DataColumn("Date");
        //        dttt.Columns.Add(dct);

        //        dct = new DataColumn("Category");
        //        dttt.Columns.Add(dct);

        //        dct = new DataColumn("Product");
        //        dttt.Columns.Add(dct);


        //        dct = new DataColumn("Quantity");
        //        dttt.Columns.Add(dct);

        //        dct = new DataColumn("TotalAmount");
        //        dttt.Columns.Add(dct);


        //        dstd1.Tables.Add(dttt);

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            drNew = dttt.NewRow();

        //            drNew["Date"] = dr["Date"];
        //            drNew["Category"] = dr["Category"];
        //            drNew["Product"] = dr["Definition"];
        //            drNew["Quantity"] = dr["GRN_Qty"];
        //            drNew["TotalAmount"] = dr["TotalAmount"];

        //            dstd1.Tables[0].Rows.Add(drNew);
        //        }

        //        // ExportToExcel(filename, dstd1, dstd2);

        //    }
        //    else
        //    {
        //        //gvgrnmp.DataSource = null;
        //        //gvgrnmp.DataBind();
        //    }

        //    ds1 = objBs.selectret111(sTableName, ddlcat.SelectedValue, txtfrmdate.Text, txttodate.Text);

        //    if (ds1.Tables[0].Rows.Count > 0)
        //    {
        //        //gvreturn.DataSource = ds1;
        //        //gvreturn.DataBind();



        //        DataTable dttt;
        //        DataRow drNew;
        //        DataColumn dct;

        //        dttt = new DataTable();


        //        dct = new DataColumn("Date");
        //        dttt.Columns.Add(dct);

        //        dct = new DataColumn("Category");
        //        dttt.Columns.Add(dct);

        //        dct = new DataColumn("Product");
        //        dttt.Columns.Add(dct);


        //        dct = new DataColumn("Quantity");
        //        dttt.Columns.Add(dct);

        //        dct = new DataColumn("TotalAmount");
        //        dttt.Columns.Add(dct);


        //        dstd2.Tables.Add(dttt);

        //        foreach (DataRow dr in ds1.Tables[0].Rows)
        //        {
        //            drNew = dttt.NewRow();

        //            drNew["Date"] = dr["RetDate"];
        //            drNew["Category"] = dr["Category"];
        //            drNew["Product"] = dr["Definition"];
        //            drNew["Quantity"] = dr["Quantity"];
        //            drNew["TotalAmount"] = dr["TotalAmount"];

        //            dstd2.Tables[0].Rows.Add(drNew);
        //        }

        //        // ExportToExcel(filename, dstd1, dstd2);
        //    }
        //    else
        //    {
        //    //    gvreturn.DataSource = null;
        //    //    gvreturn.DataBind();
        //    }


        //    ExportToExcel(filename, dstd1, dstd2);
        //}

        //private void ExportToExcel(string filename, DataSet dt, DataSet dt1)
        //{
        //    //	throw new NotImplementedException();

        //    //   if (dt.Tables[0].Rows.Count > 0)
        //    {

        //        DataGrid dgGridCaption = new DataGrid();
        //        dgGridCaption.Caption = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
        //        dgGridCaption.DataBind();

        //        System.IO.StringWriter tw = new System.IO.StringWriter();
        //        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        //        dgGridCaption.RenderControl(hw);


        //        GridViewRow gv2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //        TableHeaderCell cell2 = new TableHeaderCell();
        //        cell2.Text = Label123 + " Stock Return and GRN(+)(-) Generated on From Date " + txtfrmdate.Text + " To Date " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
        //        cell2.Height = 300;
        //        cell2.Width = 10000;
        //        gv2.Controls.Add(cell2);
        //        gv2.RenderControl(hw);

        //        dgGridCaption.RenderControl(hw);

        //        if (dt.Tables.Count > 0)
        //        {
        //            if (dt != null)
        //            {
        //                if (dt.Tables[0].Rows.Count > 0)
        //                {
        //                    DataGrid dgGrid = new DataGrid();
        //                    dgGrid.DataSource = dt;
        //                    dgGrid.DataBind();
        //                    dgGrid.Caption = "GRN (+)(-)";
        //                    dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        //                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
        //                    dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
        //                    dgGrid.FooterStyle.ForeColor = System.Drawing.Color.Red;
        //                    dgGrid.HeaderStyle.Font.Bold = true;
        //                    //Get the HTML for the control.
        //                    dgGrid.RenderControl(hw);
        //                }
        //            }
        //        }

        //        if (dt1.Tables.Count > 0)
        //        {
        //            if (dt1 != null)
        //            {
        //                if (dt1.Tables[0].Rows.Count > 0)
        //                {
        //                    DataGrid dgGrid1 = new DataGrid();
        //                    dgGrid1.DataSource = dt1;
        //                    dgGrid1.Caption = "Stock Return";
        //                    dgGrid1.DataBind();
        //                    dgGrid1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        //                    dgGrid1.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
        //                    dgGrid1.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
        //                    dgGrid1.FooterStyle.ForeColor = System.Drawing.Color.Red;
        //                    dgGrid1.HeaderStyle.Font.Bold = true;
        //                    //Get the HTML for the control.
        //                    dgGrid1.RenderControl(hw);
        //                }
        //            }
        //        }
        //        //Write the HTML back to the browser.
        //        Response.ContentType = "application/vnd.ms-excel";
        //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
        //        this.EnableViewState = false;
        //        Response.Write(tw.ToString());
        //        Response.End();
        //    }
        //}
    }
}
