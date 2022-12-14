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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class SemiOrderFromBranch : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";

        string Categoryid = string.Empty;
        string Bnchid = string.Empty;
        int intSubTotalIndex = 1;
        double RowSubTotal = 0;
        double RowOrdSubTotal = 0;
        string UOM = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Today.ToString("dd/MM/yyy");
                BindTime();

                // Get Store Details From Production

                DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                DataSet daygrn = objbs.gettinground(sCode);
                drproundlist.DataSource = daygrn.Tables[0];
                drproundlist.DataTextField = "roundname";
                drproundlist.DataValueField = "roundid";
                drproundlist.DataBind();
                // drproundlist.Items.Insert(0, "Select Round");

                DataSet dsbranch = objbs.getbranchsettingFilling_Semi(sCode);
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpstorelist.DataSource = dsbranch.Tables[0];
                    drpstorelist.DataTextField = "BranchArea";
                    drpstorelist.DataValueField = "Branchcode";
                    drpstorelist.DataBind();
                    drpstorelist.Items.Insert(0, "All");
                }


                DataSet ds = objbs.getbranchbyproduction_Semi(sCode, sDate);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvPurchaseEntry.DataSource = ds;
                    gvPurchaseEntry.DataBind();
                }
                else
                {
                    gvPurchaseEntry.DataSource = null;
                    gvPurchaseEntry.DataBind();
                }

            }
        }

        private void BindTime()
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
            //Set 5 minutes interval
            TimeSpan Interval = new TimeSpan(0, 30, 0);
            //To set 1 hour interval
            //TimeSpan Interval = new TimeSpan(1, 0, 0);           
            ddlTimeFrom.Items.Clear();
            ddlTimeTo.Items.Clear();
            while (StartTime <= EndTime)
            {
                ddlTimeFrom.Items.Add(StartTime.ToShortTimeString());
                ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }
            ddlTimeFrom.Items.Insert(0, new ListItem("Select From Time", "0"));
            ddlTimeTo.Items.Insert(0, new ListItem("Select To Time", "0"));
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

        }

        protected void btnexport_click(object sender, EventArgs e)
        {
            gvbranchqty.Visible = true;
            Griddc.Visible = false;
            gvDetails.Visible = false;
            DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getStockRequestFromBranchsQty_Semi(sCode, sDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Caption = "All Production Qty on :- " + sDate.ToString("dd/MM/yyyy");
                gvbranchqty.Caption = Caption;
                gvbranchqty.DataSource = ds;
                gvbranchqty.DataBind();


                string filename = "SummaryQty.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                gvbranchqty.Caption = "Semi Stock Request   On " + sDate;
                // gridview.DataSource = ds;
                // gridview.DataBind();
                gvbranchqty.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                gvbranchqty.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                gvbranchqty.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                gvbranchqty.HeaderStyle.Font.Bold = true;
                //Get the HTML for the control.
                gvbranchqty.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();


            }
            else
            {
                gvbranchqty.Caption = "";
                gvbranchqty.DataSource = null;
                gvbranchqty.DataBind();
            }


        }

        protected void btnexportDC_click(object sender, EventArgs e)
        {
            if (drproundlist.SelectedValue == "Select Round")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Round.Thank You!!!.');", true);
                return;
            }

            gvbranchqty.Visible = false;
            Griddc.Visible = true;
            gvDetails.Visible = false;
            //if (ddlTimeFrom.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select From Time.Thank You!!!.');", true);
            //    return;
            //}
            //if (ddlTimeTo.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select To Time.Thank You!!!.');", true);
            //    return;
            //}

            DataSet dget = objbs.gettinground(sCode, drproundlist.SelectedValue);
            if (dget.Tables[0].Rows.Count > 0)
            {

                string fromtime = dget.Tables[0].Rows[0]["fromtime"].ToString();
                string Totime = dget.Tables[0].Rows[0]["Totime"].ToString();
                fulltime.Text = dget.Tables[0].Rows[0]["fulltime"].ToString();


                DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan Fromtime = Convert.ToDateTime(fromtime).TimeOfDay;
                TimeSpan totime = Convert.ToDateTime(Totime).TimeOfDay;

                DataSet ds = objbs.getStockRequestFromBranchsQtyDC_SEMI(sCode, sDate, Fromtime.ToString(), totime.ToString(), drpstorelist.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Caption = "Production Wise DC on :- " + sDate.ToString("dd/MM/yyyy");
                    Griddc.Caption = Caption;
                    Griddc.DataSource = ds;
                    Griddc.DataBind();

                    string filename = "Production-Wise-DCQty.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    // gvbranchqty.Caption = "Stock Request from Branch Qty Store On " + sDate;
                    // gridview.DataSource = ds;
                    // gridview.DataBind();
                    Griddc.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    Griddc.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    Griddc.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    Griddc.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    Griddc.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();


                }
                else
                {
                    Griddc.Caption = "";
                    Griddc.DataSource = null;
                    Griddc.DataBind();
                }
            }
            else
            {
                Griddc.Caption = "";
                Griddc.DataSource = null;
                Griddc.DataBind();
            }

        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Accept")
            {
                gvbranchqty.Visible = false;
                Griddc.Visible = false;
                gvDetails.Visible = true;
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                string ReqNo = arg[0];
                string Branch = arg[1];
                string Branchreqno = arg[2];

                Response.Redirect("SemiGoodTransfer.aspx?ReqNo=" + ReqNo + "&bcode=" + Branch + "&breqno=" + Branchreqno);
            }

            else if (e.CommandName == "view")
            {
                gvbranchqty.Visible = false;
                Griddc.Visible = false;
                gvDetails.Visible = true;
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                string ReqNo = arg[0];
                string Branch = arg[1];
                string ReportDate = arg[2];
                string Breqno = arg[3];
                DataSet ds = objbs.RequestDetprod_Semi(Breqno, Branch, sCode, ReqNo);
                gvDetails.DataSource = ds;
                gvDetails.DataBind();
                //  gvDetails.Caption = Branch+""+"Store"+"-"+"Order Details";
                gvDetails.Caption = "Semi Stock Request from " + Branch + " Store On " + Convert.ToDateTime(ReportDate).ToString("dd/MM/yyyy") + "-" + ds.Tables[0].Rows[0]["RequestEntryTime"].ToString();
            }

            else if (e.CommandName == "Export")
            {
                gvbranchqty.Visible = false;
                Griddc.Visible = false;
                gvDetails.Visible = true;
                try
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(';');
                    string ReqNo = arg[0];
                    string Branch = arg[1];
                    string Date = arg[2];
                    string Breqno = arg[3];
                    DataSet ds = objbs.RequestDetprod_Semi((Breqno), Branch, sCode, ReqNo);
                    gvDetails.DataSource = ds;
                    gvDetails.DataBind();
                    //GridView gridview = new GridView();

                    //gridview.DataSource = objbs.RequestDetExport((ReqNo), Branch);
                    //gridview.DataBind();

                    string filename = "Semi_Stock-ReqFrmProduction.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    gvDetails.Caption = "Semi Stock Request from " + Branch + " Store On " + Date;
                    // gridview.DataSource = ds;
                    // gridview.DataBind();
                    gvDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                    gvDetails.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                    gvDetails.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                    gvDetails.HeaderStyle.Font.Bold = true;
                    //Get the HTML for the control.
                    gvDetails.RenderControl(hw);
                    //Write the HTML back to the browser.
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();


                    //   gridview.Caption = Branch +"-"+Date+"-Request" ;

                    //gridview.Caption = "Stock Request from " + Branch + " Store On " + Date;
                    //gvDetails.Caption = "Stock Request from " + Branch + " Store On " + Date;
                    //Response.ClearContent();
                    //string filename = "Stock Request from " + Branch + " Store On " + Date;
                    //// Response.AddHeader("content-disposition","attachment;filename=Stock-ReqFrmBranch.xls");
                    //Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", filename));

                    //Response.ContentType = "applicatio/excel";
                    //StringWriter sw = new StringWriter(); ;
                    //HtmlTextWriter htm = new HtmlTextWriter(sw);
                    //gvDetails.AllowPaging = false;
                    //gvDetails.RenderControl(htm);
                    //Response.Write(sw.ToString());
                    //Response.End();
                    //gvDetails.AllowPaging = true;
                }
                catch { }
            }

            else if (e.CommandName == "Previous")
            {
                //DateTime datetime=Convert.ToDateTime(txtDate.Text);
                //string date=datetime.ToString("yyyy-MM-dd");
                //DataSet dset = objbs.getDetaiedTransfer(date, sCode);
                //gvGrid.DataSource = dset;
                //gvGrid.DataBind();
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

            }

            //  Response.Redirect("OrderFromBranch.aspx");
        }
        protected void gvdetails_bound(object sender, GridViewRowEventArgs e)
        {
            int OrderQty = 0;
            int RecQty = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrderQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Order_Qty"));
                RecQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Received_Qty"));

                if (OrderQty == RecQty)
                {
                }
                else
                {

                    e.Row.Attributes["style"] = "background-color: Red";
                    //foreach (TableCell cell in e.Row.Cells)
                    //{

                    //    {
                    //        cell.BackColor = Color.Red;
                    //    }

                    //}
                }

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[2].Text = "Total:";
                //e.Row.Cells[3].Text = dQtyamt.ToString("N");
                //e.Row.Cells[4].Text = crateamt.ToString("f2");
                //e.Row.Cells[5].Text = cratetotamt.ToString("f2");
            }

        }
        protected void btnadd_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < gvPurchaseEntry.Rows.Count; i++)
            {
                if (gvPurchaseEntry.Rows[i].Cells[4].Text.Trim() == "BB Kulam Branch")
                {
                    Response.Redirect("GoodTransfer.aspx?BB=" + gvPurchaseEntry.Rows[i].Cells[3].Text);
                }
            }
        }
        protected void gvPurchaseEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //for (int i = 0; i < gvPurchaseEntry.Rows.Count; i++)
            //{
            //    DateTime Date = Convert.ToDateTime(gvPurchaseEntry.Rows[i].Cells[1].Text.ToString());

            //    string sdate = Date.ToString("yyyy-MM-dd");
            //    DateTime Yesterday = DateTime.Today.AddDays(-1);

            //    string sTerday = Yesterday.ToString("yyyy-MM-dd");
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {

            //        foreach (TableCell cell in e.Row.Cells)
            //        {

            //            if (sdate == sTerday)
            //            {
            //                gvPurchaseEntry.Rows[i].BackColor = Color.Green;
            //                //txttransferQty.Enabled = true;
            //                //cell.BackColor = Color.Yellow;

            //            }
            //        }
            //    }
            //}

        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= RequestFromStores.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvGrid.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        //Search Summary
        protected void btnsearch_Click(object sender, EventArgs e)
        {

            gvbranchqty.Caption = "";
            gvbranchqty.DataSource = null;
            gvbranchqty.DataBind();

            DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objbs.getbranchbyproduction_Semi(sCode, sDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPurchaseEntry.DataSource = ds;
                gvPurchaseEntry.DataBind();
            }
            else
            {
                gvPurchaseEntry.DataSource = null;
                gvPurchaseEntry.DataBind();
            }

        }

        //Search Detailed
        protected void btnsearchqty_OnClick(object sender, EventArgs e)
        {
            gvbranchqty.Visible = true;
            Griddc.Visible = false;
            gvDetails.Visible = false;
            DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getStockRequestFromBranchsQty_Semi(sCode, sDate);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Caption = "All Branches Qty on :- " + sDate.ToString("dd/MM/yyyy");
                gvbranchqty.Caption = Caption;
                gvbranchqty.DataSource = ds;
                gvbranchqty.DataBind();
            }
            else
            {
                gvbranchqty.Caption = "";
                gvbranchqty.DataSource = null;
                gvbranchqty.DataBind();
            }

        }

        protected void gvbranchqty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Categoryid = DataBinder.Eval(e.Row.DataItem, "Categoryid").ToString();
            }
        }

        protected void gvbranchqty_RowCreated(object sender, GridViewRowEventArgs e)
        {

            bool IsSubTotalRowNeedToAdd = false;

            if ((Categoryid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Categoryid") != null))
                if (Categoryid != DataBinder.Eval(e.Row.DataItem, "Categoryid").ToString())
                    IsSubTotalRowNeedToAdd = true;
            if ((Categoryid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Categoryid") == null))
            {
                IsSubTotalRowNeedToAdd = true;
                intSubTotalIndex = 0;
            }
            #region Inserting first Row and populating fist Group Header details
            if ((Categoryid == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "Categoryid") != null))
            {
                string adadad = DataBinder.Eval(e.Row.DataItem, "Categoryid").ToString();

                GridView gridPurchase = (GridView)sender;
                //GridViewRow row = new GridViewRow(0, -1, DataControlRowType.DataRow, DataControlRowState.Insert);
                //TableCell cell = new TableCell();
                //cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "Category").ToString();
                //cell.ColumnSpan = 4;
                //cell.CssClass = "GroupHeaderStyle";
                //row.Cells.Add(cell);
                //gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                ////intSubTotalIndex++;


                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Category Name : " + DataBinder.Eval(e.Row.DataItem, "Category").ToString();
                cell.ColumnSpan = 4;
                cell.CssClass = "GroupHeaderStyle";
                row.Cells.Add(cell);
                gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;

                RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                UOM = DataBinder.Eval(e.Row.DataItem, "UOM").ToString();
            }
            else if (DataBinder.Eval(e.Row.DataItem, "Categoryid") != null)
            {
                if (Categoryid == DataBinder.Eval(e.Row.DataItem, "Categoryid").ToString())
                {
                    RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                    UOM = DataBinder.Eval(e.Row.DataItem, "UOM").ToString();
                }
            }


            #endregion
            if (IsSubTotalRowNeedToAdd)
            {
                #region Adding Sub Total Row

                GridView GridView1 = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();

                if (DataBinder.Eval(e.Row.DataItem, "Categoryid") != null)
                {
                    #region
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Total:-";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = RowSubTotal.ToString("f2");
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = UOM;
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);


                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    #endregion
                    RowSubTotal = 0;

                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "--------------------------------------------------------------------------------------------------------";
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.ColumnSpan = 4;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                else
                {
                    #region

                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    cell = new TableCell();
                    cell.Text = "";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "Total:-";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = RowSubTotal.ToString("f2");
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = UOM;
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);


                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    #endregion
                    RowSubTotal = 0;
                }

                if (DataBinder.Eval(e.Row.DataItem, "Categoryid") != null)
                {
                    RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                }



                #endregion

                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "Categoryid") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Category Name : " + DataBinder.Eval(e.Row.DataItem, "Category").ToString();
                    cell.ColumnSpan = 4;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                }
                #endregion


            }
        }


        //Search Detailed
        protected void btnsearchqtyDC_OnClick(object sender, EventArgs e)
        {

            if (drproundlist.SelectedValue == "Select Round")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Round.Thank You!!!.');", true);
                return;
            }

            gvbranchqty.Visible = false;
            Griddc.Visible = true;
            gvDetails.Visible = false;
            //if (ddlTimeFrom.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select From Time.Thank You!!!.');", true);
            //    return;
            //}
            //if (ddlTimeTo.SelectedValue == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select To Time.Thank You!!!.');", true);
            //    return;
            //}

            DataSet dget = objbs.gettinground(sCode, drproundlist.SelectedValue);
            if (dget.Tables[0].Rows.Count > 0)
            {

                string fromtime = dget.Tables[0].Rows[0]["fromtime"].ToString();
                string Totime = dget.Tables[0].Rows[0]["Totime"].ToString();
                fulltime.Text = dget.Tables[0].Rows[0]["fulltime"].ToString();


                DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan Fromtime = Convert.ToDateTime(fromtime).TimeOfDay;
                TimeSpan totime = Convert.ToDateTime(Totime).TimeOfDay;

                DataSet ds = objbs.getStockRequestFromBranchsQtyDC_SEMI(sCode, sDate, Fromtime.ToString(), totime.ToString(), drpstorelist.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Caption = "Branches Wise DC on :- " + sDate.ToString("dd/MM/yyyy");
                    Griddc.Caption = Caption;
                    Griddc.DataSource = ds;
                    Griddc.DataBind();
                }
                else
                {
                    Griddc.Caption = "";
                    Griddc.DataSource = null;
                    Griddc.DataBind();
                }
            }
            else
            {
                Griddc.Caption = "";
                Griddc.DataSource = null;
                Griddc.DataBind();
            }

        }


        protected void Griddc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Bnchid = DataBinder.Eval(e.Row.DataItem, "branchid").ToString();
            }
        }

        protected void Griddc_RowCreated(object sender, GridViewRowEventArgs e)
        {

            bool IsSubTotalRowNeedToAdd = false;

            if ((Bnchid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "branchid") != null))
                if (Bnchid != DataBinder.Eval(e.Row.DataItem, "branchid").ToString())
                    IsSubTotalRowNeedToAdd = true;
            if ((Bnchid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "branchid") == null))
            {
                IsSubTotalRowNeedToAdd = true;
                intSubTotalIndex = 0;
            }
            #region Inserting first Row and populating fist Group Header details
            if ((Bnchid == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "branchid") != null))
            {
                string adadad = DataBinder.Eval(e.Row.DataItem, "branchid").ToString();

                GridView gridPurchase = (GridView)sender;
                //GridViewRow row = new GridViewRow(0, -1, DataControlRowType.DataRow, DataControlRowState.Insert);
                //TableCell cell = new TableCell();
                //cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "Category").ToString();
                //cell.ColumnSpan = 4;
                //cell.CssClass = "GroupHeaderStyle";
                //row.Cells.Add(cell);
                //gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                ////intSubTotalIndex++;


                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "brancharea").ToString() + " - " + drproundlist.SelectedItem.Text;
                cell.ColumnSpan = 5;
                cell.CssClass = "GroupHeaderStyle";
                row.Cells.Add(cell);
                gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;

                RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                RowOrdSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OQty"));
                UOM = DataBinder.Eval(e.Row.DataItem, "UOM").ToString();
            }
            else if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
            {
                if (Bnchid == DataBinder.Eval(e.Row.DataItem, "branchid").ToString())
                {
                    RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                    RowOrdSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OQty"));
                    UOM = DataBinder.Eval(e.Row.DataItem, "UOM").ToString();
                }
            }


            #endregion
            if (IsSubTotalRowNeedToAdd)
            {
                #region Adding Sub Total Row

                GridView GridView1 = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();

                if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
                {
                    #region
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);



                    cell = new TableCell();
                    cell.Text = "Total:-";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = RowOrdSubTotal.ToString("f2");
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = RowSubTotal.ToString("f2");
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = UOM;
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);


                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    #endregion
                    RowSubTotal = 0;
                    RowOrdSubTotal = 0;
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "--------------------------------------------------------------------------------------------------------";
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.ColumnSpan = 5;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                else
                {
                    #region

                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);

                    cell = new TableCell();
                    cell.Text = "";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);



                    cell = new TableCell();
                    cell.Text = "Total:-";
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = RowOrdSubTotal.ToString("f2");
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = RowSubTotal.ToString("f2");
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = UOM;
                    cell.ColumnSpan = 1;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);


                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    #endregion
                    RowSubTotal = 0;
                    RowOrdSubTotal = 0;
                }

                if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
                {
                    RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                    RowOrdSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OQty"));
                }



                #endregion

                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "brancharea").ToString() + " - " + drproundlist.SelectedItem.Text;
                    cell.ColumnSpan = 5;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                }
                #endregion


            }
        }
    }
}