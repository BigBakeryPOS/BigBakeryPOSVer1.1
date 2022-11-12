using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class GoodsTransferNew : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";

        string strPreviousRowID = string.Empty;
        // To keep track the Index of Group Total    
        int intSubTotalIndex = 1;



        protected void Page_Load(object sender, EventArgs e)
        {
            // this.btnvalue.Click += new System.EventHandler(this.btnvalue_Click);
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {


                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                txtreqdate.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                //  reqdate_chnaged(sender, e);
                entryType_Chnaged(sender, e);
                DataSet dDcNo = objbs.getmaxrawmaterialrequest((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

            }
        }





        protected void gvPurchase_Sorting(object sender, GridViewSortEventArgs e)
        {


        }
        protected void entryType_Chnaged(object sender, EventArgs e)
        {
            if (drpentrytype.SelectedValue == "1")
            {
                txtreqdate.Enabled = false;
                reqdate_chnaged(sender, e);

            }
            else if (drpentrytype.SelectedValue == "2")
            {
                txtreqdate.Enabled = true;
                reqdate_chnaged(sender, e);

            }
        }

        protected void reqdate_chnaged(object sender, EventArgs e)
        {
            DataSet ds = objbs.getproductionbranch(sCode);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Category", typeof(string)));
                dt.Columns.Add(new DataColumn("Categoryid", typeof(string)));
                dt.Columns.Add(new DataColumn("Product", typeof(string)));
                dt.Columns.Add(new DataColumn("Productid", typeof(string)));
                dt.Columns.Add(new DataColumn("ProdQty", typeof(string)));


                dt.Columns.Add(new DataColumn("Qty1", typeof(string)));
                dt.Columns.Add(new DataColumn("Qty2", typeof(string)));
                dt.Columns.Add(new DataColumn("Qty3", typeof(string)));
                dt.Columns.Add(new DataColumn("Qty4", typeof(string)));
                dt.Columns.Add(new DataColumn("Qty5", typeof(string)));

                dt.Columns.Add(new DataColumn("Total", typeof(string)));




                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string branchcode = ds.Tables[0].Rows[i]["Branchcode"].ToString();

                        if (i == 0)
                        {
                            dr = dt.NewRow();
                        }
                        #region

                        dr["Category"] = "";
                        dr["Categoryid"] = "";
                        dr["Product"] = "";
                        dr["Productid"] = "";
                        dr["ProdQty"] = "";
                        if (i == 0)
                        {
                            dr["Qty1"] = branchcode;
                        }
                        else if (i == 1)
                        {
                            dr["Qty2"] = branchcode;
                        }
                        else if (i == 2)
                        {
                            dr["Qty3"] = branchcode;
                        }
                        else if (i == 3)
                        {
                            dr["Qty4"] = branchcode;
                        }
                        else if (i == 4)
                        {
                            dr["Qty5"] = branchcode;
                        }


                        dr["Total"] = "0";

                        #endregion
                        if (i == 0)
                        {
                            dt.Rows.Add(dr);
                        }

                    }

                    int numberOfRecords = dt.Rows.Count;

                    if (numberOfRecords >= 1)
                    {
                        #region

                        DataSet getalalitem = new DataSet();
                        if (drpentrytype.SelectedValue == "2")
                        {
                            getalalitem = objbs.viewDescp("Rate");
                        }
                        else
                        {
                            getalalitem = objbs.viewDescpNwew("Rate");
                        }
                        if (getalalitem.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < getalalitem.Tables[0].Rows.Count; i++)
                            {

                                double Qty1 = 0, Qty2 = 0, Qty3 = 0, Qty4 = 0, Qty5 = 0;

                                string CategoryID = getalalitem.Tables[0].Rows[i]["CategoryID"].ToString();
                                string category = getalalitem.Tables[0].Rows[i]["category"].ToString();
                                string CategoryuserID = getalalitem.Tables[0].Rows[i]["CategoryuserID"].ToString();
                                string Definition = getalalitem.Tables[0].Rows[i]["Definition"].ToString();

                                DataRow row = dt.Rows[0];

                                string bnch1 = row["Qty1"].ToString();
                                string bnch2 = row["Qty2"].ToString();
                                string bnch3 = row["Qty3"].ToString();
                                string bnch4 = row["Qty4"].ToString();
                                string bnch5 = row["Qty5"].ToString();

                                dr = dt.NewRow();
                                dr["Category"] = category;
                                dr["Categoryid"] = CategoryID;
                                dr["Product"] = Definition;
                                dr["Productid"] = CategoryuserID;
                                dr["ProdQty"] = "0";

                                if (drpentrytype.SelectedValue == "2")
                                {

                                    DateTime sDate = DateTime.ParseExact(txtreqdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                                    DataSet bch1 = objbs.getstockfromproduction(sCode, CategoryuserID, sDate, bnch1);
                                    if (bch1.Tables[0].Rows.Count > 0)
                                    {
                                        Qty1 = Convert.ToDouble(bch1.Tables[0].Rows[0]["qty"]);
                                        dr["Qty1"] = bch1.Tables[0].Rows[0]["qty"].ToString();
                                    }
                                    else
                                    {
                                        Qty1 = 0;
                                        dr["Qty1"] = "0";
                                    }

                                    DataSet bch2 = objbs.getstockfromproduction(sCode, CategoryuserID, sDate, bnch2);
                                    if (bch2.Tables[0].Rows.Count > 0)
                                    {
                                        Qty2 = Convert.ToDouble(bch2.Tables[0].Rows[0]["qty"]);
                                        dr["Qty2"] = bch2.Tables[0].Rows[0]["qty"].ToString();
                                    }
                                    else
                                    {
                                        Qty2 = 0;
                                        dr["Qty2"] = "0";
                                    }

                                    DataSet bch3 = objbs.getstockfromproduction(sCode, CategoryuserID, sDate, bnch3);
                                    if (bch3.Tables[0].Rows.Count > 0)
                                    {
                                        Qty3 = Convert.ToDouble(bch3.Tables[0].Rows[0]["qty"]);
                                        dr["Qty3"] = bch3.Tables[0].Rows[0]["qty"].ToString();
                                    }
                                    else
                                    {
                                        Qty3 = 0;
                                        dr["Qty3"] = "0";
                                    }

                                    DataSet bch4 = objbs.getstockfromproduction(sCode, CategoryuserID, sDate, bnch4);
                                    if (bch4.Tables[0].Rows.Count > 0)
                                    {
                                        Qty4 = Convert.ToDouble(bch4.Tables[0].Rows[0]["qty"]);
                                        dr["Qty4"] = bch4.Tables[0].Rows[0]["qty"].ToString();
                                    }
                                    else
                                    {
                                        Qty4 = 0;
                                        dr["Qty4"] = "0";
                                    }

                                    DataSet bch5 = objbs.getstockfromproduction(sCode, CategoryuserID, sDate, bnch5);
                                    if (bch5.Tables[0].Rows.Count > 0)
                                    {
                                        Qty5 = Convert.ToDouble(bch5.Tables[0].Rows[0]["qty"]);
                                        dr["Qty5"] = bch5.Tables[0].Rows[0]["qty"].ToString();
                                    }
                                    else
                                    {
                                        Qty5 = 0;
                                        dr["Qty5"] = "0";
                                    }

                                    double toto = Qty1 + Qty2 + Qty3 + Qty4 + Qty5;

                                    if (toto == 0 || toto == 0.00)
                                    {
                                        dr["Total"] = "0";
                                    }
                                    else
                                    {
                                        dr["Total"] = toto;
                                        dt.Rows.Add(dr);
                                    }
                                }
                                else if (drpentrytype.SelectedValue == "1")
                                {

                                    Qty1 = 0;
                                    dr["Qty1"] = "0";

                                    Qty2 = 0;
                                    dr["Qty2"] = "0";

                                    Qty3 = 0;
                                    dr["Qty3"] = "0";


                                    Qty4 = 0;
                                    dr["Qty4"] = "0";

                                    Qty5 = 0;
                                    dr["Qty5"] = "0";



                                    dr["Total"] = "0";

                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                    }

                        #endregion
                }


                gvPurchase.DataSource = dt;
                gvPurchase.DataBind();
                rawgrid(sender, e);
            }

        }



        protected void radchnaged(object sender, EventArgs e)
        {

            if (idtype.SelectedValue == "1")
            {
                btnsummary.Visible = true;
                btndetails.Visible = false;
            }
            else
            {
                btnsummary.Visible = false;
                btndetails.Visible = true;

            }

            rawgrid(sender, e);

        }

        protected void fillexcess(object sender, EventArgs e)
        {
            for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
            {
                double totgnd = 0;
                Label lblQty1 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty1");
                Label lblQty2 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty2");
                Label lblQty3 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty3");
                Label lblQty4 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty4");



                Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");
                lblTotal.Text = (Convert.ToDouble(lblQty1.Text) + Convert.ToDouble(lblQty2.Text) + Convert.ToDouble(lblQty3.Text) + Convert.ToDouble(lblQty4.Text)).ToString();


                TextBox txtexcess = (TextBox)gvPurchase.Rows[vLoop].FindControl("txtexcess");
                if (txtexcess.Text == "")
                {
                    txtexcess.Text = "0";
                }
                txtexcess.Text = txtexcessqtyfill.Text;
                totgnd = Convert.ToDouble(lblTotal.Text) + Convert.ToDouble(txtexcess.Text);

                lblTotal.Text = totgnd.ToString();
                txtexcess.Focus();
            }

            rawgrid(sender, e);
        }

        protected void Excess_click(object sender, EventArgs e)
        {
            for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
            {
                double totgnd = 0;
                Label lblQty1 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty1");
                Label lblQty2 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty2");
                Label lblQty3 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty3");
                Label lblQty4 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty4");
                Label lblQty5 = (Label)gvPurchase.Rows[vLoop].FindControl("lblQty5");


                Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");
                lblTotal.Text = (Convert.ToDouble(lblQty1.Text) + Convert.ToDouble(lblQty2.Text) + Convert.ToDouble(lblQty3.Text) + Convert.ToDouble(lblQty4.Text) + Convert.ToDouble(lblQty5.Text)).ToString();

                TextBox txtexcess = (TextBox)gvPurchase.Rows[vLoop].FindControl("txtexcess");
                if (txtexcess.Text == "")
                    txtexcess.Text = "0";
                totgnd = Convert.ToDouble(lblTotal.Text) + Convert.ToDouble(txtexcess.Text);

                lblTotal.Text = totgnd.ToString();
                //txtexcess.Focus();
                txtSearch.Focus();
            }
            rawgrid(sender, e);

        }
        protected void RawMaterial_generate(object sender, EventArgs e)
        {
            ////// rawgrid(sender, e);
            GridView1.DataSource = null;
            GridView1.DataBind();

            GridView2.DataSource = null;
            GridView2.DataBind();

            if (idtype.SelectedValue == "1")
            {
                #region
                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    #region Check Receipe

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvPurchase.Rows[vLoop].FindControl("lblProduct");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Set Receipe for " + lblProduct.Text + ".Thank You!!!');", true);
                        //return;
                    }
                    #endregion
                }

                #region Summary

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("WantedRaw");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("ActualRaw");
                dsraw.Tables.Add(dtraw);

                DataSet dsrawmerge = new DataSet();

                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");

                    DataSet dsrawitems = objbs.Getwantraw1(Convert.ToInt32(productid.Value), Convert.ToDouble(lblTotal.Text), sCode);
                    if (dsrawitems.Tables[0].Rows.Count > 0)
                    {
                        dsrawmerge.Merge(dsrawitems);
                    }

                }

                if (dsrawmerge.Tables.Count > 0)
                {

                    if (dsrawmerge.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtraws = new DataTable();

                        dtraws = dsrawmerge.Tables[0];

                        var result1 = from r in dtraws.AsEnumerable()
                                      group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"] } into raw
                                      select new
                                      {
                                          IngredientName = raw.Key.IngredientName,
                                          total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                          UOM = raw.Key.UOM,
                                      };


                        foreach (var g in result1)
                        {
                            drraw = dtraw.NewRow();


                            drraw["IngredientName"] = g.IngredientName;
                            drraw["ActualRaw"] = Convert.ToDouble(g.total).ToString("f2");
                            double valuee = Math.Ceiling(g.total);
                            drraw["WantedRaw"] = Convert.ToDouble(valuee).ToString("f2");
                            drraw["UOM"] = g.UOM;

                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                        GridView2.DataSource = dsraw.Tables[0];
                        GridView2.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('No Request Shown.Thank You!!!!.');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('No Request Shown.Thank You!!!!.');", true);
                    return;
                }


                #endregion

                #endregion
            }
            else
            {
                #region
                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    #region Check Receipe

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvPurchase.Rows[vLoop].FindControl("lblProduct");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Set Receipe for " + lblProduct.Text + ".Thank You!!!');", true);
                        return;
                    }
                    #endregion
                }

                #region Detailed
                DataTable dtt = new DataTable();
                dtt.Columns.Add("Catid");
                dtt.Columns.Add("Catname");
                dtt.Columns.Add("ID");
                dtt.Columns.Add("IngredientName");
                dtt.Columns.Add("Qty");
                dtt.Columns.Add("UOM");
                dtt.Columns.Add("UOMid");


                DataTable dttNew = new DataTable();
                DataSet dsnew = new DataSet();
                DataRow drNew;
                dttNew.Columns.Add("Catid");
                dttNew.Columns.Add("Catname");
                dttNew.Columns.Add("ID");
                dttNew.Columns.Add("IngredientName");
                dttNew.Columns.Add("Qty");
                dttNew.Columns.Add("ActQty");
                dttNew.Columns.Add("Uomid");
                dttNew.Columns.Add("Uom");
                dsnew.Tables.Add(dttNew);



                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    ////// double totgnd = 0;

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");

                    Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);



                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            DataRow dr = dtt.NewRow();
                            double recqty = 0;
                            dr = dtt.NewRow();

                            dr["catID"] = ds.Tables[0].Rows[j]["categoryid"].ToString();
                            dr["catname"] = ds.Tables[0].Rows[j]["Category"].ToString();


                            dr["ID"] = ds.Tables[0].Rows[j]["IngridID"].ToString();
                            dr["IngredientName"] = ds.Tables[0].Rows[j]["ingredientname"].ToString();

                            dr["uomid"] = ds.Tables[0].Rows[j]["uomID"].ToString();
                            dr["uom"] = ds.Tables[0].Rows[j]["uom"].ToString();



                            decimal Num = Convert.ToDecimal(ds.Tables[0].Rows[j]["TotalQty"]);
                            decimal dAct = Convert.ToDecimal(lblTotal.Text) / Convert.ToDecimal(Num);
                            decimal act = Convert.ToDecimal(ds.Tables[0].Rows[j]["recqty"]) * dAct;
                            dr["Qty"] = Convert.ToDouble(act.ToString("0.000")).ToString();
                            dtt.Rows.Add(dr);
                        }
                    }
                }
                var result = from r in dtt.AsEnumerable()
                             group r by new { fabcode = r["IngredientName"], code = r["ID"], catid = r["catid"], catname = r["catname"], uomid = r["uomid"], uom = r["uom"] } into g
                             select new
                             {
                                 Ledgername = g.Key.fabcode,
                                 type = g.Key.code,
                                 cattid = g.Key.catid,
                                 cattname = g.Key.catname,
                                 uomid = g.Key.uomid,
                                 uom = g.Key.uom,


                                 total = g.Sum(x => Convert.ToDouble(x["Qty"])),

                             };

                foreach (var g in result)
                {
                    drNew = dttNew.NewRow();

                    drNew["uomid"] = g.uomid;
                    drNew["uom"] = g.uom;
                    drNew["catid"] = g.cattid;
                    drNew["catName"] = g.cattname;
                    drNew["IngredientName"] = g.Ledgername;
                    drNew["ID"] = g.type;
                    double valuee = Math.Ceiling(g.total);
                    drNew["Qty"] = valuee;
                    drNew["ActQty"] = g.total;

                    dsnew.Tables[0].Rows.Add(drNew);
                }

                GridView1.DataSource = dsnew.Tables[0];
                GridView1.DataBind();
                #endregion
                #endregion
            }

        }

        protected void gridraw_RowCreated(object sender, GridViewRowEventArgs e)
        {


            bool IsSubTotalRowNeedToAdd = false;
            bool IsGrandTotalRowNeedtoAdd = false;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "catid") != null))
                if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "catid").ToString())
                    IsSubTotalRowNeedToAdd = true;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "catid") == null))
            {
                IsSubTotalRowNeedToAdd = true;
                IsGrandTotalRowNeedtoAdd = true;
                intSubTotalIndex = 0;
            }
            #region Inserting first Row and populating fist Group Header details
            if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "catid") != null))
            {
                GridView gridPurchase = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Category Name : " + DataBinder.Eval(e.Row.DataItem, "catName").ToString();
                cell.ColumnSpan = 3;
                cell.CssClass = "GroupHeaderStyle";
                row.Cells.Add(cell);
                gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
            }
            #endregion
            if (IsSubTotalRowNeedToAdd)
            {
                #region Adding Sub Total Row
                GridView GridView1 = (GridView)sender;
                // Creating a Row          
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                //Adding Total Cell          
                TableCell cell = new TableCell();
                cell.Text = "--------------------------------------------------------------------------------";
                cell.HorizontalAlign = HorizontalAlign.Left;
                cell.ColumnSpan = 3;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "--------------------";
                cell.HorizontalAlign = HorizontalAlign.Right;
                cell.CssClass = "SubTotalRowStyle";
                row.Cells.Add(cell);



                //Adding the Row at the RowIndex position in the Grid      
                GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
                #endregion
                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "catid") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Category Name : " + DataBinder.Eval(e.Row.DataItem, "catname").ToString();
                    cell.ColumnSpan = 3;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                #endregion
            }
        }
        protected void gridraw_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "catid").ToString();
            }
        }

        protected void gvPurchase_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // int quantity = int.Parse(e.Row.Cells[1].Text);
                //HiddenField productid = (HiddenField)gvPurchase.FindControl("HDProductid");
                HiddenField productid = (HiddenField)e.Row.FindControl("HDProductid");
                if (!string.IsNullOrEmpty(productid.Value))
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            cell.BackColor = Color.Red;
                        }

                    }
                }

            }
        }


        public void rawgrid(object sender, EventArgs e)
        {

            GridView1.DataSource = null;
            GridView1.DataBind();

            GridView2.DataSource = null;
            GridView2.DataBind();

            if (idtype.SelectedValue == "1")
            {
                #region
                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    #region Check Receipe

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvPurchase.Rows[vLoop].FindControl("lblProduct");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Set Receipe for " + lblProduct.Text + ".Thank You!!!');", true);
                        //  return;
                    }
                    #endregion
                }

                #region Summary

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Semiitemid");
                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("WantedRaw");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("ActualRaw");
                dtraw.Columns.Add("ProdQty");
                dsraw.Tables.Add(dtraw);

                DataSet dsrawmerge = new DataSet();

                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");
                    if (lblTotal.Text != "0")
                    {
                        DataSet dsrawitems = objbs.Getwantraw1(Convert.ToInt32(productid.Value), Convert.ToDouble(lblTotal.Text), sCode);
                        if (dsrawitems.Tables[0].Rows.Count > 0)
                        {
                            dsrawmerge.Merge(dsrawitems);
                        }
                    }

                }

                if (dsrawmerge.Tables.Count > 0)
                {

                    if (dsrawmerge.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtraws = new DataTable();

                        dtraws = dsrawmerge.Tables[0];

                        var result1 = from r in dtraws.AsEnumerable()
                                      group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                      select new
                                      {
                                          IngredientName = raw.Key.IngredientName,
                                          Semiitemid = raw.Key.Semiitemid,
                                          total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                          UOM = raw.Key.UOM,
                                      };


                        foreach (var g in result1)
                        {
                            drraw = dtraw.NewRow();

                            drraw["Semiitemid"] = g.Semiitemid;
                            drraw["IngredientName"] = g.IngredientName;
                            drraw["ActualRaw"] = Convert.ToDouble(g.total).ToString("f3");
                            double valuee = Math.Ceiling(g.total);
                            drraw["WantedRaw"] = Convert.ToDouble(valuee).ToString("f3");
                            drraw["UOM"] = g.UOM;
                            DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(g.Semiitemid), sCode);
                            if (dsprdqty.Tables[0].Rows.Count > 0)
                            {
                                drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                            }
                            else
                            {
                                drraw["ProdQty"] = "0.000";
                            }
                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                        GridView2.DataSource = dsraw.Tables[0];
                        GridView2.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('No Qty Shown.Thank You!!!!.');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('No Request Shown.Thank You!!!!.');", true);
                    return;
                }


                #endregion

                #endregion
            }
            else
            {
                #region
                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    #region Check Receipe

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvPurchase.Rows[vLoop].FindControl("lblProduct");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Set Receipe for " + lblProduct.Text + ".Thank You!!!');", true);
                        //  return;
                    }
                    #endregion
                }

                #region Detailed
                DataTable dtt = new DataTable();
                dtt.Columns.Add("Catid");
                dtt.Columns.Add("Catname");
                dtt.Columns.Add("ID");
                dtt.Columns.Add("IngredientName");
                dtt.Columns.Add("Qty");
                dtt.Columns.Add("UOM");
                dtt.Columns.Add("UOMid");
                dtt.Columns.Add("ProdQty");

                DataTable dttNew = new DataTable();
                DataSet dsnew = new DataSet();
                DataRow drNew;
                dttNew.Columns.Add("Catid");
                dttNew.Columns.Add("Catname");
                dttNew.Columns.Add("ID");
                dttNew.Columns.Add("IngredientName");
                dttNew.Columns.Add("Qty");
                dttNew.Columns.Add("ActQty");
                dttNew.Columns.Add("Uomid");
                dttNew.Columns.Add("Uom");
                dttNew.Columns.Add("ProdQty");
                dsnew.Tables.Add(dttNew);



                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    ////// double totgnd = 0;

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");

                    Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);


                    if (lblTotal.Text != "0")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                DataRow dr = dtt.NewRow();
                                double recqty = 0;
                                dr = dtt.NewRow();

                                dr["catID"] = ds.Tables[0].Rows[j]["categoryid"].ToString();
                                dr["catname"] = ds.Tables[0].Rows[j]["Category"].ToString();


                                dr["ID"] = ds.Tables[0].Rows[j]["IngridID"].ToString();
                                dr["IngredientName"] = ds.Tables[0].Rows[j]["ingredientname"].ToString();

                                dr["uomid"] = ds.Tables[0].Rows[j]["uomID"].ToString();
                                dr["uom"] = ds.Tables[0].Rows[j]["uom"].ToString();



                                decimal Num = Convert.ToDecimal(ds.Tables[0].Rows[j]["TotalQty"]);
                                decimal dAct = Convert.ToDecimal(lblTotal.Text) / Convert.ToDecimal(Num);
                                decimal act = Convert.ToDecimal(ds.Tables[0].Rows[j]["recqty"]) * dAct;
                                dr["Qty"] = Convert.ToDouble(act.ToString("0.000")).ToString();
                                dr["ProdQty"] = Convert.ToDouble(ds.Tables[0].Rows[j]["RawStock"]).ToString("0.000");
                                dtt.Rows.Add(dr);
                            }
                        }
                    }
                }
                var result = from r in dtt.AsEnumerable()
                             group r by new { fabcode = r["IngredientName"], code = r["ID"], catid = r["catid"], catname = r["catname"], uomid = r["uomid"], uom = r["uom"], prodqty = r["ProdQty"] } into g
                             select new
                             {
                                 Ledgername = g.Key.fabcode,
                                 type = g.Key.code,
                                 cattid = g.Key.catid,
                                 cattname = g.Key.catname,
                                 uomid = g.Key.uomid,
                                 uom = g.Key.uom,
                                 prodqty = g.Key.prodqty,

                                 total = g.Sum(x => Convert.ToDouble(x["Qty"])),

                             };

                foreach (var g in result)
                {
                    drNew = dttNew.NewRow();

                    drNew["uomid"] = g.uomid;
                    drNew["uom"] = g.uom;
                    drNew["catid"] = g.cattid;
                    drNew["catName"] = g.cattname;
                    drNew["IngredientName"] = g.Ledgername;
                    drNew["ID"] = g.type;
                    double valuee = Math.Ceiling(g.total);
                    drNew["Qty"] = valuee;
                    drNew["ActQty"] = Convert.ToDouble(g.total).ToString("0.000");
                    drNew["ProdQty"] = Convert.ToDouble(g.prodqty).ToString("0.000");
                    dsnew.Tables[0].Rows.Add(drNew);
                }

                GridView1.DataSource = dsnew.Tables[0];
                GridView1.DataBind();
                #endregion
                #endregion
            }

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

            ////// rawgrid(sender, e);
            GridView1.DataSource = null;
            GridView1.DataBind();

            GridView2.DataSource = null;
            GridView2.DataBind();

            if (idtype.SelectedValue == "1")
            {
                #region
                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    #region Check Receipe

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvPurchase.Rows[vLoop].FindControl("lblProduct");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Set Receipe for " + lblProduct.Text + ".Thank You!!!');", true);
                        //return;
                    }
                    #endregion
                }

                #region Summary

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Semiitemid");
                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("WantedRaw");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("ActualRaw");
                dtraw.Columns.Add("ProdQty");
                dsraw.Tables.Add(dtraw);

                DataSet dsrawmerge = new DataSet();

                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");

                    if (lblTotal.Text != "0")
                    {
                        DataSet dsrawitems = objbs.Getwantraw1(Convert.ToInt32(productid.Value), Convert.ToDouble(lblTotal.Text), sCode);
                        if (dsrawitems.Tables[0].Rows.Count > 0)
                        {
                            dsrawmerge.Merge(dsrawitems);
                        }
                    }

                }

                if (dsrawmerge.Tables.Count > 0)
                {

                    if (dsrawmerge.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtraws = new DataTable();

                        dtraws = dsrawmerge.Tables[0];

                        var result1 = from r in dtraws.AsEnumerable()
                                      group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                      select new
                                      {
                                          IngredientName = raw.Key.IngredientName,
                                          Semiitemid = raw.Key.Semiitemid,
                                          total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                          UOM = raw.Key.UOM,
                                      };


                        foreach (var g in result1)
                        {
                            drraw = dtraw.NewRow();


                            drraw["IngredientName"] = g.IngredientName;
                            drraw["ActualRaw"] = Convert.ToDouble(g.total).ToString("f3");
                            double valuee = Math.Ceiling(g.total);
                            drraw["WantedRaw"] = Convert.ToDouble(valuee).ToString("f3");
                            drraw["UOM"] = g.UOM;
                            DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(g.Semiitemid), sCode);
                            if (dsprdqty.Tables[0].Rows.Count > 0)
                            {
                                drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                            }
                            else
                            {
                                drraw["ProdQty"] = "0.000";
                            }

                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                        GridView2.DataSource = dsraw.Tables[0];
                        GridView2.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('No Request Shown.Thank You!!!!.');", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('No Request Shown.Thank You!!!!.');", true);
                    return;
                }


                #endregion

                #endregion
            }
            else
            {
                #region
                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    #region Check Receipe

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvPurchase.Rows[vLoop].FindControl("lblProduct");

                    DataSet ds = objbs.getreceiptsettingforitem(productid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Set Receipe for " + lblProduct.Text + ".Thank You!!!');", true);
                        //return;
                    }
                    #endregion
                }

                #region Detailed
                DataTable dtt = new DataTable();
                dtt.Columns.Add("Catid");
                dtt.Columns.Add("Catname");
                dtt.Columns.Add("ID");
                dtt.Columns.Add("IngredientName");
                dtt.Columns.Add("Qty");
                dtt.Columns.Add("UOM");
                dtt.Columns.Add("UOMid");
                dtt.Columns.Add("ProdQty");


                DataTable dttNew = new DataTable();
                DataSet dsnew = new DataSet();
                DataRow drNew;
                dttNew.Columns.Add("Catid");
                dttNew.Columns.Add("Catname");
                dttNew.Columns.Add("ID");
                dttNew.Columns.Add("IngredientName");
                dttNew.Columns.Add("Qty");
                dttNew.Columns.Add("ActQty");
                dttNew.Columns.Add("Uomid");
                dttNew.Columns.Add("Uom");
                dttNew.Columns.Add("ProdQty");
                dsnew.Tables.Add(dttNew);



                for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
                {
                    ////// double totgnd = 0;

                    HiddenField productid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");

                    Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");
                    if (lblTotal.Text != "0")
                    {
                        DataSet ds = objbs.getreceiptsettingforitem(productid.Value);




                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                DataRow dr = dtt.NewRow();
                                double recqty = 0;
                                dr = dtt.NewRow();

                                dr["catID"] = ds.Tables[0].Rows[j]["categoryid"].ToString();
                                dr["catname"] = ds.Tables[0].Rows[j]["Category"].ToString();


                                dr["ID"] = ds.Tables[0].Rows[j]["IngridID"].ToString();
                                dr["IngredientName"] = ds.Tables[0].Rows[j]["ingredientname"].ToString();

                                dr["uomid"] = ds.Tables[0].Rows[j]["uomID"].ToString();
                                dr["uom"] = ds.Tables[0].Rows[j]["uom"].ToString();



                                decimal Num = Convert.ToDecimal(ds.Tables[0].Rows[j]["TotalQty"]);
                                decimal dAct = Convert.ToDecimal(lblTotal.Text) / Convert.ToDecimal(Num);
                                decimal act = Convert.ToDecimal(ds.Tables[0].Rows[j]["recqty"]) * dAct;
                                dr["Qty"] = Convert.ToDouble(act.ToString("0.000")).ToString();
                                dr["ProdQty"] = Convert.ToDouble(ds.Tables[0].Rows[j]["RawStock"]).ToString("0.000");
                                dtt.Rows.Add(dr);
                            }
                        }
                    }
                }
                var result = from r in dtt.AsEnumerable()
                             group r by new { fabcode = r["IngredientName"], code = r["ID"], catid = r["catid"], catname = r["catname"], uomid = r["uomid"], uom = r["uom"], prodqty = r["ProdQty"] } into g
                             select new
                             {
                                 Ledgername = g.Key.fabcode,
                                 type = g.Key.code,
                                 cattid = g.Key.catid,
                                 cattname = g.Key.catname,
                                 uomid = g.Key.uomid,
                                 uom = g.Key.uom,
                                 prodqty = g.Key.prodqty,
                                 total = g.Sum(x => Convert.ToDouble(x["Qty"])),

                             };

                foreach (var g in result)
                {
                    drNew = dttNew.NewRow();

                    drNew["uomid"] = g.uomid;
                    drNew["uom"] = g.uom;
                    drNew["catid"] = g.cattid;
                    drNew["catName"] = g.cattname;
                    drNew["IngredientName"] = g.Ledgername;
                    drNew["ID"] = g.type;
                    double valuee = Math.Ceiling(g.total);
                    drNew["Qty"] = valuee;
                    drNew["ActQty"] =  Convert.ToDouble(g.total).ToString("0.000");
                    drNew["ProdQty"] = Convert.ToDouble(g.prodqty).ToString("0.000");
                    dsnew.Tables[0].Rows.Add(drNew);
                }

                GridView1.DataSource = dsnew.Tables[0];
                GridView1.DataBind();
                #endregion
                #endregion
            }

            DataSet dDcNo = objbs.getmaxrawmaterialrequest((sCode));
            txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();
            //string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            //DateTime Date = Convert.ToDateTime(sDate);

            DateTime Date = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);

            int RequestID = objbs.Insertrawrequest(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, drpentrytype.SelectedValue,"4");

            for (int vLoop = 1; vLoop < gvPurchase.Rows.Count; vLoop++)
            {


                HiddenField HDProductid = (HiddenField)gvPurchase.Rows[vLoop].FindControl("HDProductid");
                Label lblTotal = (Label)gvPurchase.Rows[vLoop].FindControl("lblTotal");
                TextBox txtexcess = (TextBox)gvPurchase.Rows[vLoop].FindControl("txtexcess");
                if (txtexcess.Text == "")
                    txtexcess.Text = "0";
                if (Convert.ToDouble(lblTotal.Text) > 0)
                {
                    int MainRequestID = objbs.Inserttransrawrequest(sCode, RequestID, Convert.ToInt32(HDProductid.Value), Convert.ToDouble(lblTotal.Text), Convert.ToDouble(txtexcess.Text),"IW");
                }

            }
            if (drpentrytype.SelectedValue == "2")
            {

                DateTime reqDate = DateTime.ParseExact(txtreqdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int updateRawRequest = objbs.updateRawRequest(sCode, reqDate, Convert.ToInt32(txtDCNo.Text));
            }


            Response.Redirect("GoodsTransferNewGrid.aspx");
        }








        protected void btnvalue_Click(object sender, EventArgs e)
        {


            DataTable dtSnacks = new DataTable();
            dtSnacks.Columns.Add("Item");
            dtSnacks.Columns.Add("Qty");


            foreach (GridViewRow ROw in gvPurchase.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txttransferQty");
                Label lblProduct = (Label)ROw.FindControl("lblProduct");

                if (txtQty.Text != "")
                {
                    DataRow dr = dtSnacks.NewRow();
                    //  dr["Item"] = ROw.Cells[3].Text;
                    dr["Item"] = lblProduct.Text;
                    dr["Qty"] = txtQty.Text;
                    dtSnacks.Rows.Add(dr);

                }

            }


            GridView1.Caption = "To be Sent";
            GridView1.DataSource = dtSnacks;
            GridView1.DataBind();

            lnkDelete_ModalPopupExtender.Show();
            //UpdatePanel1.Update();
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

            // ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "ShowPopup();", true);
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {


            DataTable dtSnacks = new DataTable();
            dtSnacks.Columns.Add("Item");
            dtSnacks.Columns.Add("Qty");


            foreach (GridViewRow ROw in gvPurchase.Rows)
            {

                TextBox txtQty = (TextBox)ROw.FindControl("txttransferQty");
                Label lblProduct = (Label)ROw.FindControl("lblProduct");
                if (txtQty.Text != "")
                {
                    DataRow dr = dtSnacks.NewRow();
                    //dr["Item"] = ROw.Cells[3].Text;
                    dr["Item"] = lblProduct.Text;
                    dr["Qty"] = txtQty.Text;
                    dtSnacks.Rows.Add(dr);

                }

            }


            GridView1.Caption = "To be Sent";
            GridView1.DataSource = dtSnacks;
            GridView1.DataBind();

            lnkDelete_ModalPopupExtender.Show();

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

            // ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "ShowPopup();", true);
        }
    }
}
