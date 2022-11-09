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
    public partial class Dispatch_report : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string scode = "";

        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";

        string Categoryid = string.Empty;
        string Bnchid = string.Empty;
        int intSubTotalIndex = 1;
        double RowSubTotal = 0;
        double RowOrdSubTotal = 0;
        string UOM = "";
        string Mtype = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {

                //DataSet dsCustomer = objbs.getbranchforhomepage();
                //if (dsCustomer.Tables[0].Rows.Count > 0)
                //{
                //    ddlBranch.DataSource = dsCustomer.Tables[0];
                //    ddlBranch.DataTextField = "brancharea";
                //    ddlBranch.DataValueField = "branchname";
                //    ddlBranch.DataBind();
                //    ddlBranch.Items.Insert(0, "All");
                //}



                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
                string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

                DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
                string sTodate = dtTodate.ToString("yyyy-MM-dd");

                ////  if (scode == "Production")
                //{
                // DataSet dT = objbs.GetTrasfDet(gdate);
                DataSet dT = objbs.griddispatch_date(scode, sFromdate, sTodate);
                if (dT.Tables[0].Rows.Count > 0)
                {
                    drpdispatchno.DataSource = dT.Tables[0];
                    drpdispatchno.DataTextField = "DispatchNo";
                    drpdispatchno.DataValueField = "Dispatchid";
                    drpdispatchno.DataBind();
                    drpdispatchno.Items.Insert(0, "Select dispatch No");
                }
                else
                {
                    drpdispatchno.DataSource = null;
                    drpdispatchno.DataBind();
                    drpdispatchno.Items.Insert(0, "Select dispatch No");

                }
                //}
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

        protected void dispatch_checked(object sender, EventArgs e)
        {

            if (drpdispatchno.SelectedValue == "Select dispatch No")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Disptach No.Thank You!!!.');", true);
                return;
            }
            else
            {
                DataSet dT = objbs.griddispatch_branch(scode, drpdispatchno.SelectedValue);
                if (dT.Tables[0].Rows.Count > 0)
                {
                    drpbranch.DataSource = dT.Tables[0];
                    drpbranch.DataTextField = "brancharea";
                    drpbranch.DataValueField = "branchcode";
                    drpbranch.DataBind();
                    drpbranch.Items.Insert(0, "Select Branch");
                }
                else
                {
                    drpbranch.DataSource = null;
                    drpbranch.DataBind();
                    drpbranch.Items.Insert(0, "Select Branch");

                }
            }



        }

        protected void Branch_select(object sender, EventArgs e)
        {

            if (drpbranch.SelectedValue == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Branch.Thank You!!!.');", true);
                return;
            }
            else
            {

                DataSet dT = objbs.griddispatch_dispatchn(scode, drpdispatchno.SelectedValue, drpbranch.SelectedValue);
                if (dT.Tables[0].Rows.Count > 0)
                {
                    chkdclist.DataSource = dT.Tables[0];
                    chkdclist.DataTextField = "DC_NO";
                    chkdclist.DataValueField = "P_id";
                    chkdclist.DataBind();
                    //drpbranch.Items.Insert(0, "Select Branch");
                }
                else
                {
                    chkdclist.DataSource = null;
                    chkdclist.DataBind();
                    // drpbranch.Items.Insert(0, "Select Branch");

                }


            }
        }

        protected void dispatchload(object sender, EventArgs e)
        {
            // txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            // txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            string sTodate = dtTodate.ToString("yyyy-MM-dd");

            ////  if (scode == "Production")
            //{
            // DataSet dT = objbs.GetTrasfDet(gdate);
            DataSet dT = objbs.griddispatch_date(scode, sFromdate, sTodate);
            if (dT.Tables[0].Rows.Count > 0)
            {
                drpdispatchno.DataSource = dT.Tables[0];
                drpdispatchno.DataTextField = "DispatchNo";
                drpdispatchno.DataValueField = "Dispatchid";
                drpdispatchno.DataBind();
                drpdispatchno.Items.Insert(0, "Select dispatch No");
            }
            else
            {
                drpdispatchno.DataSource = null;
                drpdispatchno.DataBind();
                drpdispatchno.Items.Insert(0, "Select dispatch No");

            }
        }


        protected void Print_Click(object sender, EventArgs e)
        {

        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //DateTime dtFromdate = Convert.ToDateTime(txtDate.Text);
            //string sFromdate = dtFromdate.ToString("yyyy-MM-dd");

            //DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
            //string sTodate = dtTodate.ToString("yyyy-MM-dd");

            //DataSet dT = objbs.GetTransferReport_date(sFromdate, sTodate, scode, ddlBranch.SelectedValue);
            //if (dT.Tables[0].Rows.Count > 0)
            //{
            //    gvTransfer.DataSource = dT;
            //    gvTransfer.DataBind();
            //}
            //else
            //{
            //    gvTransfer.DataSource = null;
            //    gvTransfer.DataBind();
            //}

            string cond1 = "";

            foreach (ListItem listItem in chkdclist.Items)
            {
                if (listItem.Text != "All")
                {
                    if (listItem.Selected)
                    {
                        cond1 += " a.P_ID='" + listItem.Value + "' ,";
                    }
                }
            }
            cond1 = cond1.TrimEnd(',');
            cond1 = cond1.Replace(",", "or");

            DataSet ds = objbs.getdispatchprint_multipledc(scode, cond1);
            if (ds.Tables[0].Rows.Count > 0)
            {

                string dispatchno = ds.Tables[0].Rows[0]["dispatchno"].ToString();
                lbldispatchno.Text = dispatchno;
                lbldispatchdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dispatchdate"]).ToString("dd/MM/yyyy hh:mm:tt ");
                string iD = ds.Tables[0].Rows[0]["dispatchid"].ToString();

                DataSet getempvehicelno = objbs.grdidispatchentryload(scode, iD.ToString());
                if (getempvehicelno.Tables[0].Rows.Count > 0)
                {

                    lblvehicelno.Text = getempvehicelno.Tables[0].Rows[0]["VehicleNumber"].ToString();
                    lblempname.Text = getempvehicelno.Tables[0].Rows[0]["Employeename"].ToString();

                }

                // string Caption = "Branches Wise Dispatch DC on :" + dispatchno;
                // Griddc.Caption = Caption;
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


        protected void Griddc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Bnchid = DataBinder.Eval(e.Row.DataItem, "P_id").ToString();
            }
        }

        protected void Griddc_RowCreated(object sender, GridViewRowEventArgs e)
        {

            bool IsSubTotalRowNeedToAdd = false;

            if ((Bnchid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "P_id") != null))
                if (Bnchid != DataBinder.Eval(e.Row.DataItem, "P_id").ToString())
                    IsSubTotalRowNeedToAdd = true;
            if ((Bnchid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "P_id") == null))
            {
                IsSubTotalRowNeedToAdd = true;
                intSubTotalIndex = 0;
            }
            #region Inserting first Row and populating fist Group Header details
            if ((Bnchid == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "P_id") != null))
            {
                string adadad = DataBinder.Eval(e.Row.DataItem, "P_id").ToString();

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
                //cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "brancharea").ToString() + " - " + DataBinder.Eval(e.Row.DataItem, "heading").ToString();
                cell.Text = "Dc No - Branch Name : " + DataBinder.Eval(e.Row.DataItem, "heading").ToString();
                cell.ColumnSpan = 5;
                cell.CssClass = "GroupHeaderStyle";
                row.Cells.Add(cell);
                gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;

                RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                RowOrdSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OQty"));
                UOM = DataBinder.Eval(e.Row.DataItem, "UOM").ToString();
            }
            else if (DataBinder.Eval(e.Row.DataItem, "P_id") != null)
            {
                if (Bnchid == DataBinder.Eval(e.Row.DataItem, "P_id").ToString())
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

                if (DataBinder.Eval(e.Row.DataItem, "P_id") != null)
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

                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "--------------------------------------------------------------------------------------------------------";
                    cell.HorizontalAlign = HorizontalAlign.Left;
                    cell.ColumnSpan = 5;
                    cell.CssClass = "SubTotalRowStyle";
                    row.Cells.Add(cell);

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

                if (DataBinder.Eval(e.Row.DataItem, "P_id") != null)
                {
                    RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                    RowOrdSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OQty"));
                }



                #endregion

                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "P_id") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    //    cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "brancharea").ToString() + " - " + DataBinder.Eval(e.Row.DataItem, "heading").ToString();
                    cell.Text = "Dc No - Branch Name : " + DataBinder.Eval(e.Row.DataItem, "heading").ToString();
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