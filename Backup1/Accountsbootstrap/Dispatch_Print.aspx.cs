using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using DataLayer;
using System.Xml.Linq;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;

namespace Billing.Accountsbootstrap
{
    public partial class Dispatch_Print : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
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
            lblUserID.Text = Session["UserID"].ToString();
            lblUser.Text = Session["UserName"].ToString();
            sTableName = Session["BranchCode"].ToString();
            sStore = Session["Store"].ToString();

            //sTableName = Request.QueryString.Get("BranchCode");
            //sStore = Request.QueryString.Get("Store");

            int iD = Convert.ToInt32(Request.QueryString.Get("id"));
            //int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string goodstype = Request.QueryString.Get("goodstype");

            lblstore.Text = sStore;
            if (iD > 0)
            {
                //gvPrint.DataSource = null;
                //gvPrint.DataBind();

                //DataSet ds = new DataSet();

                //ds = objBs.PrintKOtORder(iD, sTableName, sMode);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    lblkot.Text = ds.Tables[0].Rows[0]["KotNo"].ToString();
                //    lbluid.Text = lblUser.Text;
                //    lblbillno.Text = ds.Tables[0].Rows[0]["KotNo"].ToString();
                //    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["KotDate"].ToString());
                //    lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                //    lbltable.Text = ds.Tables[0].Rows[0]["tablename"].ToString();
                //    gvPrint.DataSource = ds;
                //    gvPrint.DataBind();



                //}


                if (goodstype == "B")
                {

                    DataSet ds = objBs.getdispatchprint(sTableName, iD.ToString(), goodstype);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        string dispatchno = ds.Tables[0].Rows[0]["dispatchno"].ToString();
                        lbldispatchno.Text = dispatchno;
                        lbldispatchdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dispatchdate"]).ToString("dd/MM/yyyy hh:mm:tt ");


                        DataSet getempvehicelno = objBs.grdidispatchentryload(sTableName, iD.ToString());
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
                else if (goodstype == "O")
                {
                    {

                        DataSet ds = objBs.getdispatchprint(sTableName, iD.ToString(), goodstype);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            string dispatchno = ds.Tables[0].Rows[0]["dispatchno"].ToString();
                            lbldispatchno.Text = dispatchno;
                            lbldispatchdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dispatchdate"]).ToString("dd/MM/yyyy hh:mm:tt ");


                            DataSet getempvehicelno = objBs.grdidispatchentryload(sTableName, iD.ToString());
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