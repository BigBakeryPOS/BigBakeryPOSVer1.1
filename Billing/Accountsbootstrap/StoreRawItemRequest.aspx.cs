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
    public partial class StoreRawItemRequest : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        string Categoryid = string.Empty;
        string Bnchid = string.Empty;
        int intSubTotalIndex = 1;
        double RowSubTotal = 0;
        double RowOrdSubTotal = 0;
        string UOM = "";

        string strPreviousRowID = string.Empty;

      //  int intSubTotalIndex = 1;



        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            txtAccepted.Text = Request.Cookies["userInfo"]["Biller"].ToString();

            if (!IsPostBack)
            {

                DataSet dDcNo = objbs.getAcceptRawMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();
                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtrequestdate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                DataSet dscategory = objbs.gridIngridentcategory();
                if (dscategory.Tables[0].Rows.Count > 0)
                {
                    drprawcat.DataSource = dscategory;
                    drprawcat.DataTextField = "IngreCategory";
                    drprawcat.DataValueField = "IngCatID";
                    drprawcat.DataBind();
                    drprawcat.Items.Insert(0, "All");
                }

              

                goodsentrytype(sender, e);


            }
        }
        protected void request_changed(object sender, EventArgs e)
        {
            btnaddqueue.Visible = false;

            DateTime sDate = DateTime.ParseExact(txtrequestdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (radbtnlist.SelectedValue == "1")
            {
                drprawcat.Enabled = false;
                ddlrequestno.Enabled = true;
                gvRawRequest.Visible = true;
                gvrawrequestqueue.Visible = false;
                ddlrequestno.ClearSelection();
                ddlrequestno.Items.Clear();

                DataSet drpdpown = objbs.getmaxrawmaterialrequestall(sCode, "'1','2'", sDate);
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlrequestno.DataSource = drpdpown;
                    ddlrequestno.DataTextField = "reqno";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
                else
                {
                    ddlrequestno.DataSource = null;
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }

            }
            else if (radbtnlist.SelectedValue == "2")
            {
                //drprawcat.Enabled = true;
                //gvrawrequestqueue.Visible = true;
                //gvRawRequest.Visible = false;
                //ddlrequestno.Enabled = false;
                //IngCate_indexed(sender, e);

                ddlrequestno.ClearSelection();
                ddlrequestno.Items.Clear();
                ddlrequestno.DataSource = null;
                ddlrequestno.DataBind();
                ddlrequestno.Items.Insert(0, "Select RequestNo");
                btnaddqueue.Visible = true;

                drprawcat.Enabled = true;
                gvrawrequestqueue.Visible = true;
                gvRawRequest.Visible = false;
                ddlrequestno.Enabled = false;
                IngCate_indexed(sender, e);

            }
            else if (radbtnlist.SelectedValue == "3")
            {

                drprawcat.Enabled = false;
                ddlrequestno.Enabled = true;
                gvRawRequest.Visible = true;
                gvrawrequestqueue.Visible = true;

                ddlrequestno.ClearSelection();
                ddlrequestno.Items.Clear();


                DataSet drpdpown = objbs.getmaxrawmaterialrequestall(sCode, "'3'", sDate);
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlrequestno.DataSource = drpdpown;
                    ddlrequestno.DataTextField = "reqno";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
                else
                {
                    ddlrequestno.DataSource = null;
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
            }
        }
        protected void goodsentrytype(object sender, EventArgs e)
        {
            btnaddqueue.Visible = false;
            DateTime sDate = DateTime.ParseExact(txtrequestdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (radbtnlist.SelectedValue == "1")
            {
                drprawcat.Enabled = false;
                ddlrequestno.Enabled = true;
                gvRawRequest.Visible = true;
                gvrawrequestqueue.Visible = false;
                ddlrequestno.ClearSelection();
                ddlrequestno.Items.Clear();

                DataSet drpdpown = objbs.getmaxrawmaterialrequestall(sCode, "'1','2'", sDate);
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlrequestno.DataSource = drpdpown;
                    ddlrequestno.DataTextField = "reqno";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
                else
                {
                    ddlrequestno.DataSource = null;
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
                
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                //drprawcat.Enabled = true;
                //gvrawrequestqueue.Visible = true;
                //gvRawRequest.Visible = false;
                //ddlrequestno.Enabled = false;
                //IngCate_indexed(sender, e);

                ddlrequestno.ClearSelection();
                ddlrequestno.Items.Clear();
                ddlrequestno.DataSource = null;
                ddlrequestno.DataBind();
                ddlrequestno.Items.Insert(0, "Select RequestNo");
                btnaddqueue.Visible = true;

                drprawcat.Enabled = true;
                gvrawrequestqueue.Visible = true;
                gvRawRequest.Visible = false;
                ddlrequestno.Enabled = false;
                IngCate_indexed(sender, e);

                DataSet getdeptshow = objbs.getDepartment(sTableName);
                if (getdeptshow.Tables[0].Rows.Count > 0)
                    if (getdeptshow.Tables[0].Rows.Count > 0)
                    {
                        drpdepartment.DataSource = getdeptshow;
                        drpdepartment.DataTextField = "Deptname";
                        drpdepartment.DataValueField = "DeptID";
                        drpdepartment.DataBind();
                        drpdepartment.Items.Insert(0, "Select Department");
                    }
                    else
                    {
                        drpdepartment.DataSource = null;
                        drpdepartment.DataBind();
                        drpdepartment.Items.Insert(0, "Select Department");
                    }

            }
            else if (radbtnlist.SelectedValue == "3")
            {

                drprawcat.Enabled = false;
                ddlrequestno.Enabled = true;
                gvRawRequest.Visible = true;
                gvrawrequestqueue.Visible = true;

                ddlrequestno.ClearSelection();
                ddlrequestno.Items.Clear();


                DataSet drpdpown = objbs.getmaxrawmaterialrequestall(sCode, "'3'", sDate);
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlrequestno.DataSource = drpdpown;
                    ddlrequestno.DataTextField = "reqno";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
                else
                {
                    ddlrequestno.DataSource = null;
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select RequestNo");
                }
            }
          
        }
        protected void IngCate_indexed(object sender, EventArgs e)
        {
            if (radbtnlist.SelectedValue == "2")
            {

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Semiitemid");
                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("WantedRaw");
                dtraw.Columns.Add("ActRaw");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("CurrStock");
                dtraw.Columns.Add("ProdQty");
                dtraw.Columns.Add("TQty");
                dsraw.Tables.Add(dtraw);
                DataSet ds = new DataSet();

                ds = objbs.getingraw(drprawcat.SelectedValue, sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string Semiitemid = ds.Tables[0].Rows[i]["IngridID"].ToString();
                        string IngredientName = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                        string UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                        string Qty = ds.Tables[0].Rows[i]["Qty"].ToString();

                        drraw = dtraw.NewRow();

                        drraw["Semiitemid"] = Semiitemid;
                        drraw["IngredientName"] = IngredientName;
                        drraw["ActRaw"] = "0";
                        drraw["WantedRaw"] = "0";
                        drraw["UOM"] = UOM;
                        drraw["CurrStock"] = Convert.ToDouble(Qty).ToString("f3");
                        DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(Semiitemid), sCode);
                        if (dsprdqty.Tables[0].Rows.Count > 0)
                        {
                            drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                        }
                        else
                        {
                            drraw["ProdQty"] = "0.00";
                        }
                        drraw["TQty"] = "";

                        dsraw.Tables[0].Rows.Add(drraw);


                    }
                    GridView2.DataSource = dsraw.Tables[0];
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                //DataTable dtraw = new DataTable();
                //DataSet dsraw = new DataSet();
                //DataRow drraw;

                //dtraw.Columns.Add("Semiitemid");
                //dtraw.Columns.Add("IngredientName");
                //dtraw.Columns.Add("WantedRaw");
                //dtraw.Columns.Add("ActRaw");
                //dtraw.Columns.Add("UOM");
                //dtraw.Columns.Add("CurrStock");
                //dtraw.Columns.Add("ProdQty");
                //dtraw.Columns.Add("TQty");
                //dsraw.Tables.Add(dtraw);

                //DataSet ds = new DataSet();

                //ds = objbs.getingraw(drprawcat.SelectedValue, sTableName);
                //if (ds.Tables[0].Rows.Count > 0)
                //{

                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {

                //        string Semiitemid = ds.Tables[0].Rows[i]["IngridID"].ToString();
                //        string IngredientName = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                //        string UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                //        string Qty = ds.Tables[0].Rows[i]["Qty"].ToString();

                //        drraw = dtraw.NewRow();

                //        drraw["Semiitemid"] = Semiitemid;
                //        drraw["IngredientName"] = IngredientName;
                //        drraw["ActRaw"] = "0";
                //        drraw["WantedRaw"] = "0";
                //        drraw["UOM"] = UOM;
                //        drraw["CurrStock"] = Convert.ToDouble(Qty).ToString("f3");
                //        DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(Semiitemid), sCode);
                //        if (dsprdqty.Tables[0].Rows.Count > 0)
                //        {
                //            drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                //        }
                //        else
                //        {
                //            drraw["ProdQty"] = "0.00";
                //        }
                //        drraw["TQty"] = "";

                //        dsraw.Tables[0].Rows.Add(drraw);


                //    }
                //    GridView2.DataSource = dsraw.Tables[0];
                //    GridView2.DataBind();

                //}
                //else
                //{
                //    GridView2.DataSource = null;
                //    GridView2.DataBind();
                //}


            }
            else if (radbtnlist.SelectedValue == "3")
            {
                
            }
        }
        protected void add_queue(object sender, EventArgs e)
        {

            if (radbtnlist.SelectedValue == "2")
            {

                DataSet dstd = new DataSet();
                DataTable dtddd = new DataTable();


                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
                dttt = new DataTable();

                dct = new DataColumn("Semiitemid");
                dttt.Columns.Add(dct);
                dct = new DataColumn("IngredientName");
                dttt.Columns.Add(dct);
                dct = new DataColumn("UOM");
                dttt.Columns.Add(dct);
                dct = new DataColumn("CQty");
                dttt.Columns.Add(dct);
                dct = new DataColumn("TQty");
                dttt.Columns.Add(dct);
                dct = new DataColumn("Nar");
                dttt.Columns.Add(dct);
                dstd.Tables.Add(dttt);



                if (ViewState["CurrentTable1"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable1"];


                    for (int i = 0; i < GridView2.Rows.Count; i++)
                    {
                        HiddenField Semiitemid = (HiddenField)GridView2.Rows[i].FindControl("Semiitemid");


                        Label lblIngredientName = (Label)GridView2.Rows[i].FindControl("lblIngredientName");
                        Label lbluom = (Label)GridView2.Rows[i].FindControl("lbluom");
                        TextBox txtuqty = (TextBox)GridView2.Rows[i].FindControl("txtuqty");
                        TextBox txtqtynarration = (TextBox)GridView2.Rows[i].FindControl("txtqtynarration");
                        Label lblStkQty = (Label)GridView2.Rows[i].FindControl("lblStkQty");

                        if (txtuqty.Text == "")
                            txtuqty.Text = "0";
                        if (Convert.ToDouble(lblStkQty.Text) >= Convert.ToDouble(txtuqty.Text))
                        {

                            if (Convert.ToDouble(txtuqty.Text) > 0)
                            {
                                drNew = dttt.NewRow();
                                drNew["Semiitemid"] = Semiitemid.Value;
                                drNew["IngredientName"] = lblIngredientName.Text;
                                drNew["UOM"] = lbluom.Text;
                                drNew["TQty"] = txtuqty.Text;
                                drNew["CQty"] = lblStkQty.Text;
                                drNew["Nar"] = txtqtynarration.Text;
                                dstd.Tables[0].Rows.Add(drNew);
                                dtddd = dstd.Tables[0];

                            }
                        }

                    }

                    dtddd.Merge(dt);
                    ViewState["CurrentTable1"] = dtddd;
                }
                else
                {
                    for (int i = 0; i < GridView2.Rows.Count; i++)
                    {
                        HiddenField Semiitemid = (HiddenField)GridView2.Rows[i].FindControl("Semiitemid");


                        Label lblIngredientName = (Label)GridView2.Rows[i].FindControl("lblIngredientName");
                        Label lbluom = (Label)GridView2.Rows[i].FindControl("lbluom");
                        TextBox txtuqty = (TextBox)GridView2.Rows[i].FindControl("txtuqty");
                        TextBox txtqtynarration = (TextBox)GridView2.Rows[i].FindControl("txtqtynarration");
                        Label lblStkQty = (Label)GridView2.Rows[i].FindControl("lblStkQty");
                        if (txtuqty.Text == "")
                            txtuqty.Text = "0";
                        if (Convert.ToDouble(lblStkQty.Text) >= Convert.ToDouble(txtuqty.Text))
                        {
                            if (Convert.ToDouble(txtuqty.Text) > 0)
                            {
                                drNew = dttt.NewRow();
                                drNew["Semiitemid"] = Semiitemid.Value;
                                drNew["IngredientName"] = lblIngredientName.Text;
                                drNew["UOM"] = lbluom.Text;
                                drNew["TQty"] = txtuqty.Text;
                                drNew["CQty"] = lblStkQty.Text;
                                drNew["Nar"] = txtqtynarration.Text;
                                dstd.Tables[0].Rows.Add(drNew);
                                dtddd = dstd.Tables[0];

                            }
                        }

                    }

                    ViewState["CurrentTable1"] = dtddd;
                }



                #region Summary

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Semiitemid");
                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("TQty");
                dtraw.Columns.Add("CQty");
                dtraw.Columns.Add("Nar");
                dsraw.Tables.Add(dtraw);

                if (dstd.Tables[0].Rows.Count > 0)
                {
                    #region

                    // DataTable dtraws = dsrawmerge.Tables[0];

                    var result1 = from r in dtddd.AsEnumerable()
                                  group r by new { Semiitemid = r["Semiitemid"], IngredientName = r["IngredientName"], UOM = r["UOM"], Nar = r["Nar"], CQTY = r["CQTY"] } into raw
                                  select new
                                  {
                                      Semiitemid = raw.Key.Semiitemid,
                                      IngredientName = raw.Key.IngredientName,
                                      UOM = raw.Key.UOM,
                                      Nar = raw.Key.Nar,
                                      CQTY = raw.Key.CQTY,
                                      Qty = raw.Sum(x => Convert.ToDouble(x["TQty"])),
                                  };


                    foreach (var g in result1)
                    {

                        if (Convert.ToDouble(g.CQTY) >= Convert.ToDouble(g.Qty))
                        {
                            drraw = dtraw.NewRow();
                            drraw["Semiitemid"] = g.Semiitemid;
                            drraw["IngredientName"] = g.IngredientName;
                            drraw["UOM"] = g.UOM;
                            drraw["CQty"] = Convert.ToDouble(g.CQTY).ToString("0.00");
                            drraw["TQty"] = g.Qty;
                            drraw["Nar"] = g.Nar;

                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                    }
                    gvrawrequestqueue.DataSource = dsraw;
                    gvrawrequestqueue.DataBind();

                    #endregion
                }
            }


            #endregion
        }
        protected void ddlrequestno_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvRawRequest.DataSource = null;
            gvRawRequest.DataBind();

               if (ddlrequestno.SelectedValue != "Select RequestNo" && ddlrequestno.SelectedValue != "0" && ddlrequestno.SelectedValue != "")
                {
                    DataSet dss = objbs.Get_Deptbyrequest(sCode, ddlrequestno.SelectedValue);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsbranch = objbs.getDepartment(sTableName);
                        if (dsbranch.Tables[0].Rows.Count > 0)
                        {
                            drpdepartment.DataSource = dsbranch.Tables[0];
                            drpdepartment.DataTextField = "Deptname";
                            drpdepartment.DataValueField = "DeptID";
                            drpdepartment.DataBind();
                            drpdepartment.Items.Insert(0, "Select Department");
                            drpdepartment.SelectedValue = dss.Tables[0].Rows[0]["deptid"].ToString();
                            drpdepartment.Enabled = false;
                        }
                    }
               }


            if (radbtnlist.SelectedValue == "1")
            {
                #region


                if (ddlrequestno.SelectedValue != "Select RequestNo" && ddlrequestno.SelectedValue != "0" && ddlrequestno.SelectedValue != "")
                {
                    DataSet dDcsreqNo = objbs.getAcceptRawMaterialdetails(sCode, ddlrequestno.SelectedValue, "IW");
                    if (dDcsreqNo.Tables[0].Rows.Count > 0)
                    {
                        gvRawRequest.DataSource = dDcsreqNo;
                        gvRawRequest.DataBind();

                        #region Summary

                        DataTable dtraw = new DataTable();
                        DataSet dsraw = new DataSet();
                        DataRow drraw;

                        dtraw.Columns.Add("Semiitemid");
                        dtraw.Columns.Add("IngredientName");
                        dtraw.Columns.Add("WantedRaw");
                        dtraw.Columns.Add("ActRaw");
                        dtraw.Columns.Add("UOM");
                        dtraw.Columns.Add("CurrStock");
                        dtraw.Columns.Add("ProdQty");
                        dtraw.Columns.Add("TQty");
                        dsraw.Tables.Add(dtraw);

                        DataSet dsrawmerge = new DataSet();

                        for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                        {
                            HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                            Label lblTotal = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");

                            DataSet dsrawitems = objbs.Getwantraw(Convert.ToInt32(productid.Value), Convert.ToDouble(lblTotal.Text), sCode);
                            if (dsrawitems.Tables[0].Rows.Count > 0)
                            {
                                dsrawmerge.Merge(dsrawitems);
                            }

                        }

                        if (dsrawmerge.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtraws = new DataTable();

                            dtraws = dsrawmerge.Tables[0];

                            var result1 = from r in dtraws.AsEnumerable()
                                          group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"], CurrStock = r["RawStock"] } into raw
                                          select new
                                          {
                                              IngredientName = raw.Key.IngredientName,
                                              Semiitemid = raw.Key.Semiitemid,
                                              total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                              UOM = raw.Key.UOM,
                                              CurrStock = raw.Key.CurrStock,
                                          };

                            double prdqty = 0;
                            foreach (var g in result1)
                            {
                                drraw = dtraw.NewRow();

                                drraw["Semiitemid"] = g.Semiitemid;
                                drraw["IngredientName"] = g.IngredientName;
                                drraw["ActRaw"] = Convert.ToDouble(g.total).ToString("f3");
                                double valuee = (g.total);
                                drraw["WantedRaw"] = Convert.ToDouble(valuee).ToString("f3");
                                drraw["UOM"] = g.UOM;
                                drraw["CurrStock"] = Convert.ToDouble(g.CurrStock).ToString("f3");
                                DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(g.Semiitemid), sCode);
                                if (dsprdqty.Tables[0].Rows.Count > 0)
                                {
                                    drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                                    prdqty = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]);
                                }
                                else
                                {
                                    drraw["ProdQty"] = "0.000";
                                    prdqty = 0;

                                }

                                if (g.total > prdqty)
                                {
                                    drraw["TQty"] = Convert.ToDouble(Convert.ToDouble(g.total) - Convert.ToDouble(prdqty)).ToString("f3");
                                }
                                else
                                {
                                    drraw["TQty"] = "0.000";
                                }
                                dsraw.Tables[0].Rows.Add(drraw);
                            }
                            GridView2.DataSource = dsraw.Tables[0];
                            GridView2.DataBind();
                        }


                        #endregion
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();

                        gvRawRequest.DataSource = null;
                        gvRawRequest.DataBind();
                    }

                }

                #endregion
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                //DataTable dtraw = new DataTable();
                //DataSet dsraw = new DataSet();
                //DataRow drraw;

                //dtraw.Columns.Add("Semiitemid");
                //dtraw.Columns.Add("IngredientName");
                //dtraw.Columns.Add("WantedRaw");
                //dtraw.Columns.Add("ActRaw");
                //dtraw.Columns.Add("UOM");
                //dtraw.Columns.Add("CurrStock");
                //dtraw.Columns.Add("ProdQty");
                //dtraw.Columns.Add("TQty");
                //dsraw.Tables.Add(dtraw);

                //DataSet ds = new DataSet();

                //ds = objbs.getingraw(drprawcat.SelectedValue,sTableName);
                //if (ds.Tables[0].Rows.Count > 0)
                //{

                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {

                //        string Semiitemid = ds.Tables[0].Rows[i]["IngridID"].ToString();
                //        string IngredientName = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                //        string UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                //        string Qty = ds.Tables[0].Rows[i]["Qty"].ToString();

                //        drraw = dtraw.NewRow();

                //        drraw["Semiitemid"] = Semiitemid;
                //        drraw["IngredientName"] = IngredientName;
                //        drraw["ActRaw"] = "0";
                //        drraw["WantedRaw"] = "0";
                //        drraw["UOM"] = UOM;
                //        drraw["CurrStock"] = Convert.ToDouble(Qty).ToString("f3");
                //        DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(Semiitemid), sCode);
                //        if (dsprdqty.Tables[0].Rows.Count > 0)
                //        {
                //            drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                //        }
                //        else
                //        {
                //            drraw["ProdQty"] = "0.00";
                //        }
                //        drraw["TQty"] = "0.000";

                //        dsraw.Tables[0].Rows.Add(drraw);


                //    }
                //    GridView2.DataSource = dsraw.Tables[0];
                //    GridView2.DataBind();

                //}
                //else
                //{
                //    GridView2.DataSource = null;
                //    GridView2.DataBind();
                //}

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Semiitemid");
                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("WantedRaw");
                dtraw.Columns.Add("ActRaw");
                dtraw.Columns.Add("UOM");
                dtraw.Columns.Add("CurrStock");
                dtraw.Columns.Add("ProdQty");
                dtraw.Columns.Add("TQty");
                dsraw.Tables.Add(dtraw);
                DataSet ds = new DataSet();

                ds = objbs.getingraw(drprawcat.SelectedValue, sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string Semiitemid = ds.Tables[0].Rows[i]["IngridID"].ToString();
                        string IngredientName = ds.Tables[0].Rows[i]["IngredientName"].ToString();
                        string UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                        string Qty = ds.Tables[0].Rows[i]["Qty"].ToString();

                        drraw = dtraw.NewRow();

                        drraw["Semiitemid"] = Semiitemid;
                        drraw["IngredientName"] = IngredientName;
                        drraw["ActRaw"] = "0";
                        drraw["WantedRaw"] = "0";
                        drraw["UOM"] = UOM;
                        drraw["CurrStock"] = Convert.ToDouble(Qty).ToString("f3");
                        DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(Semiitemid), sCode);
                        if (dsprdqty.Tables[0].Rows.Count > 0)
                        {
                            drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                        }
                        else
                        {
                            drraw["ProdQty"] = "0.00";
                        }
                        drraw["TQty"] = "0.000";

                        dsraw.Tables[0].Rows.Add(drraw);


                    }
                    GridView2.DataSource = dsraw.Tables[0];
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }


            }
            else if (radbtnlist.SelectedValue == "3")
            {

                if (ddlrequestno.SelectedValue != "Select RequestNo" && ddlrequestno.SelectedValue != "0" && ddlrequestno.SelectedValue != "")
                {
                    DataSet dDcsreqNo = objbs.getAcceptRawMaterialdetails(sCode, ddlrequestno.SelectedValue,"RW");
                    if (dDcsreqNo.Tables[0].Rows.Count > 0)
                    {
                        //gvRawRequest.DataSource = dDcsreqNo;
                        //gvRawRequest.DataBind();

                        #region Summary

                        DataTable dtraw = new DataTable();
                        DataSet dsraw = new DataSet();
                        DataRow drraw;

                        dtraw.Columns.Add("Semiitemid");
                        dtraw.Columns.Add("IngredientName");
                        dtraw.Columns.Add("WantedRaw");
                        dtraw.Columns.Add("ActRaw");
                        dtraw.Columns.Add("UOM");
                        dtraw.Columns.Add("CurrStock");
                        dtraw.Columns.Add("ProdQty");
                        dtraw.Columns.Add("TQty");
                        dsraw.Tables.Add(dtraw);

                        DataSet dsrawmerge = new DataSet();

                        for (int vLoop = 0; vLoop < dDcsreqNo.Tables[0].Rows.Count; vLoop++)
                        {
                            string Semiitemid = dDcsreqNo.Tables[0].Rows[vLoop]["ItemId"].ToString();
                            string IngredientName = dDcsreqNo.Tables[0].Rows[vLoop]["Definition"].ToString();
                            string UOM = dDcsreqNo.Tables[0].Rows[vLoop]["UOM"].ToString();
                            string wantQty = dDcsreqNo.Tables[0].Rows[vLoop]["Qty"].ToString();

                            drraw = dtraw.NewRow();

                            drraw["Semiitemid"] = Semiitemid;
                            drraw["IngredientName"] = IngredientName;
                            drraw["ActRaw"] = Convert.ToDouble(wantQty).ToString("f3");
                            drraw["WantedRaw"] = Convert.ToDouble(wantQty).ToString("f3");
                            drraw["UOM"] = UOM;
                            DataSet getingstock = objbs.InserttransrawitemacceptCheck(sCode, Semiitemid);
                            if (getingstock.Tables[0].Rows.Count > 0)
                            {
                                string qty = getingstock.Tables[0].Rows[0]["qty"].ToString();
                                drraw["CurrStock"] = Convert.ToDouble(qty).ToString("f3");
                            }
                            else
                            {
                                drraw["CurrStock"] = Convert.ToDouble(0).ToString("f3");
                            }
                            DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(Semiitemid), sCode);
                            if (dsprdqty.Tables[0].Rows.Count > 0)
                            {
                                drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f3");
                            }
                            else
                            {
                                drraw["ProdQty"] = "0.00";
                            }
                            drraw["TQty"] = "0.000";

                            dsraw.Tables[0].Rows.Add(drraw);

                        }

                        GridView2.DataSource = dsraw.Tables[0];
                        GridView2.DataBind();


                        #endregion
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();

                        gvRawRequest.DataSource = null;
                        gvRawRequest.DataBind();
                    }

                }
                
            }
        }


        protected void Excess_click(object sender, EventArgs e)
        {
            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                double totgnd = 0;

                Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
                TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");
                Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

                if (txtadjqty.Text == "")
                    txtadjqty.Text = "0";

                txtfinalqty.Text = (Convert.ToDouble(lblQty.Text) + Convert.ToDouble(txtadjqty.Text)).ToString();


            }

            btnexecuteraw_OnClick(sender, e);


        }

        protected void btnexecuteraw_OnClick(object sender, EventArgs e)
        {
            //////for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            //////{
            //////    Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");
            //////    Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
            //////    TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");

            //////    if (Convert.ToDouble(lblQty.Text) < Convert.ToDouble(txtadjqty.Text))
            //////    {
            //////        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Adj.Qty for " + lblProduct.Text + ".Thank You!!!');", true);
            //////        return;
            //////    }
            //////}

            #region Summary

            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;

            dtraw.Columns.Add("Semiitemid");
            dtraw.Columns.Add("IngredientName");
            dtraw.Columns.Add("WantedRaw");
            dtraw.Columns.Add("ActRaw");
            dtraw.Columns.Add("UOM");
            dtraw.Columns.Add("CurrStock");
            dtraw.Columns.Add("ProdQty");
            dsraw.Tables.Add(dtraw);

            DataSet dsrawmerge = new DataSet();

            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

                if (txtfinalqty.Text == "")
                    txtfinalqty.Text = "0";

                DataSet dsrawitems = objbs.Getwantraw(Convert.ToInt32(productid.Value), Convert.ToDouble(txtfinalqty.Text), sCode);
                if (dsrawitems.Tables[0].Rows.Count > 0)
                {
                    dsrawmerge.Merge(dsrawitems);
                }

            }

            if (dsrawmerge.Tables[0].Rows.Count > 0)
            {
                DataTable dtraws = new DataTable();

                dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtraws.AsEnumerable()
                              group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"], CurrStock = r["RawStock"] } into raw
                              select new
                              {
                                  Semiitemid = raw.Key.Semiitemid,
                                  IngredientName = raw.Key.IngredientName,
                                  total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                  UOM = raw.Key.UOM,
                                  CurrStock = raw.Key.CurrStock,
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["Semiitemid"] = g.Semiitemid;
                    drraw["IngredientName"] = g.IngredientName;
                    drraw["ActRaw"] = Convert.ToDouble(g.total).ToString("f3");
                    double valuee = Math.Ceiling(g.total);
                    drraw["WantedRaw"] = Convert.ToDouble(valuee).ToString("f3");
                    drraw["UOM"] = g.UOM;
                    drraw["CurrStock"] = Convert.ToDouble(g.CurrStock).ToString("f3");
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


            #endregion

        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {

            string deptid = "0";

            if (drpdepartment.SelectedValue == "Select Department")
            {

            }
            else
            {
                deptid = drpdepartment.SelectedValue;
            }

            if (radbtnlist.SelectedValue == "1")
            {

                if (ddlrequestno.SelectedValue == "Select RequestNo" && ddlrequestno.SelectedValue == "0" && ddlrequestno.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Request No.Thank You!!!');", true);
                    return;
                }
                #region commented region

                //////for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                //////{
                //////    Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");
                //////    Label lblQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
                //////    TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");

                //////    if (Convert.ToDouble(lblQty.Text) < Convert.ToDouble(txtadjqty.Text))
                //////    {
                //////        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Adj.Qty for " + lblProduct.Text + ".Thank You!!!');", true);
                //////        return;
                //////    }
                //////}
                #endregion

                #region Summary

                //DataTable dtraw = new DataTable();
                //DataSet dsraw = new DataSet();
                //DataRow drraw;

                //dtraw.Columns.Add("Semiitemid");
                //dtraw.Columns.Add("IngredientName");
                //dtraw.Columns.Add("WantedRaw");
                //dtraw.Columns.Add("ActRaw");
                //dtraw.Columns.Add("UOM");
                //dtraw.Columns.Add("CurrStock");
                //dtraw.Columns.Add("ProdQty");
                //dsraw.Tables.Add(dtraw);

                //DataSet dsrawmerge = new DataSet();

                //for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                //{
                //    HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                //    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

                //    if (txtfinalqty.Text == "")
                //        txtfinalqty.Text = "0";

                //    DataSet dsrawitems = objbs.Getwantraw(Convert.ToInt32(productid.Value), Convert.ToDouble(txtfinalqty.Text), sCode);
                //    if (dsrawitems.Tables[0].Rows.Count > 0)
                //    {
                //        dsrawmerge.Merge(dsrawitems);
                //    }

                //}

                //if (dsrawmerge.Tables[0].Rows.Count > 0)
                //{
                //    DataTable dtraws = new DataTable();

                //    dtraws = dsrawmerge.Tables[0];

                //    var result1 = from r in dtraws.AsEnumerable()
                //                  group r by new { IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"], CurrStock = r["RawStock"] } into raw
                //                  select new
                //                  {
                //                      Semiitemid = raw.Key.Semiitemid,
                //                      IngredientName = raw.Key.IngredientName,
                //                      total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                //                      UOM = raw.Key.UOM,
                //                      CurrStock = raw.Key.CurrStock,
                //                  };


                //    foreach (var g in result1)
                //    {
                //        drraw = dtraw.NewRow();

                //        drraw["Semiitemid"] = g.Semiitemid;
                //        drraw["IngredientName"] = g.IngredientName;
                //        drraw["ActRaw"] = Convert.ToDouble(g.total).ToString("f2");
                //        double valuee = Math.Ceiling(g.total);
                //        drraw["WantedRaw"] = Convert.ToDouble(valuee).ToString("f2");
                //        drraw["UOM"] = g.UOM;
                //        drraw["CurrStock"] = Convert.ToDouble(g.CurrStock).ToString("f2");
                //        DataSet dsprdqty = objbs.GetProductionQty(Convert.ToInt32(g.Semiitemid), sCode);
                //        if (dsprdqty.Tables[0].Rows.Count > 0)
                //        {
                //            drraw["ProdQty"] = Convert.ToDouble(dsprdqty.Tables[0].Rows[0]["Qty"]).ToString("f2");
                //        }
                //        else
                //        {
                //            drraw["ProdQty"] = "0.00";
                //        }

                //        dsraw.Tables[0].Rows.Add(drraw);
                //    }
                //    GridView2.DataSource = dsraw.Tables[0];
                //    GridView2.DataBind();
                //}


                #endregion

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");
                    Label lblActRaw = (Label)GridView2.Rows[vLoop].FindControl("lblActRaw");
                    Label lblIngredientName = (Label)GridView2.Rows[vLoop].FindControl("lblIngredientName");
                    TextBox txtuqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtuqty");

                    DataSet ds = objbs.InserttransrawitemacceptCheck(sCode, Semiitemid.Value);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //if (Convert.ToDouble(lblWantedRaw.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                        if (Convert.ToDouble(txtuqty.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + "(" + ds.Tables[0].Rows[0]["Qty"].ToString() + ")" + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                        return;
                    }
                    #endregion
                }


                DataSet dDcNo = objbs.getAcceptRawMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

                //string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                //DateTime Date = Convert.ToDateTime(sDate);

                DateTime Date = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int RequestID = objbs.Insertrawaccept(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(ddlrequestno.SelectedValue), "AGN.REQ", deptid);

                for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("txtfinalqty");

                    Label lblorgQty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblorgQty");
                    Label lblexcessqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblexcessqty");
                    TextBox txtadjqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtadjqty");

                    if (Convert.ToDouble(txtfinalqty.Text) > 0)
                    {
                        int MainRequestID = objbs.Inserttransrawaccept(sCode, RequestID, Convert.ToInt32(HDProductid.Value), Convert.ToDouble(txtfinalqty.Text), Convert.ToDouble(lblexcessqty.Text), Convert.ToInt32(ddlrequestno.SelectedValue), Convert.ToDouble(lblorgQty.Text), txtadjqty.Text);
                    }
                    #endregion
                }

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");
                    Label lblActRaw = (Label)GridView2.Rows[vLoop].FindControl("lblActRaw");
                    TextBox txtuqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtuqty");
                    TextBox txtqtynarration = (TextBox)GridView2.Rows[vLoop].FindControl("txtqtynarration");


                    int insertrawitems = objbs.Inserttransrawitemaccept(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(lblWantedRaw.Text), Convert.ToDouble(lblActRaw.Text), Convert.ToDouble(txtuqty.Text), txtqtynarration.Text);
                }

                int updateRawRequest = objbs.updateRawaccept(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
                Response.Redirect("StoreRawItemRequestGrid.aspx");
            }
            else if (radbtnlist.SelectedValue == "2")
            {

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");
                    Label lblActRaw = (Label)GridView2.Rows[vLoop].FindControl("lblActRaw");
                    Label lblIngredientName = (Label)GridView2.Rows[vLoop].FindControl("lblIngredientName");
                    TextBox txtuqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtuqty");
                    if (txtuqty.Text == "")
                        txtuqty.Text = "0";
                    if (Convert.ToDouble(txtuqty.Text) > 0)
                    {
                        DataSet ds = objbs.InserttransrawitemacceptCheck(sCode, Semiitemid.Value);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //if (Convert.ToDouble(lblWantedRaw.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                            if (Convert.ToDouble(txtuqty.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                            {
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + "(" + ds.Tables[0].Rows[0]["Qty"].ToString() + ")" + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                            return;
                        }
                    }
                    #endregion
                }

                DataSet dDcNo = objbs.getAcceptRawMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();


                DateTime Date = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int RequestID = objbs.Insertrawaccept(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(0), "DIR.REQ", deptid);

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    // Label lblWantedRaw = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblWantedRaw");
                    // Label lblActRaw = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblActRaw");
                    TextBox txtuqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtuqty");
                    TextBox txtqtynarration = (TextBox)GridView2.Rows[vLoop].FindControl("txtqtynarration");

                    if (txtuqty.Text == "")
                        txtuqty.Text = "0";

                    if (Convert.ToDouble(txtuqty.Text) > 0)
                    {


                        int insertrawitems = objbs.Inserttransrawitemaccept3(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(txtuqty.Text), txtqtynarration.Text);
                    }
                }
                Response.Redirect("StoreRawItemRequestGrid.aspx");
                //DataSet dDcNo = objbs.getAcceptRawMaterialsno((sCode));
                //txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

                //DateTime Date = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                //int RequestID = objbs.Insertrawaccept(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(0), "ACC.REQ");

                //for (int vLoop = 0; vLoop < gvrawrequestqueue.Rows.Count; vLoop++)
                //{
                //    HiddenField Semiitemid = (HiddenField)gvrawrequestqueue.Rows[vLoop].FindControl("Semiitemid");
                //   // Label lblWantedRaw = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblWantedRaw");
                //   // Label lblActRaw = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblActRaw");
                //    Label lbluqty = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lbluqty");
                //    Label lblqtynarration = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblqtynarration");


                //    int insertrawitems = objbs.Inserttransrawitemaccept(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(lbluqty.Text), lblqtynarration.Text);
                //}
                //Response.Redirect("StoreRawItemRequestGrid.aspx");

            }
            else if (radbtnlist.SelectedValue == "3")
            {

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");
                    Label lblActRaw = (Label)GridView2.Rows[vLoop].FindControl("lblActRaw");
                    Label lblIngredientName = (Label)GridView2.Rows[vLoop].FindControl("lblIngredientName");
                    TextBox txtuqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtuqty");
                    if (Convert.ToDouble(txtuqty.Text) > 0)
                    {
                        DataSet ds = objbs.InserttransrawitemacceptCheck(sCode, Semiitemid.Value);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //if (Convert.ToDouble(lblWantedRaw.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                            if (Convert.ToDouble(txtuqty.Text) > Convert.ToDouble(ds.Tables[0].Rows[0]["Qty"].ToString()))
                            {
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + "(" + ds.Tables[0].Rows[0]["Qty"].ToString() + ")" + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                                return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert(' " + lblIngredientName.Text + " was not in availabe Stock, plz Check.Thank You!!!');", true);
                            return;
                        }
                    }
                    #endregion
                }


                DataSet dDcNo = objbs.getAcceptRawMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();


                DateTime Date = DateTime.ParseExact(txtDCDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                int RequestID = objbs.Insertrawaccept(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(0), "DMND.REQ", deptid);

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    // Label lblWantedRaw = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblWantedRaw");
                    // Label lblActRaw = (Label)gvrawrequestqueue.Rows[vLoop].FindControl("lblActRaw");
                    TextBox txtuqty = (TextBox)GridView2.Rows[vLoop].FindControl("txtuqty");
                    TextBox txtqtynarration = (TextBox)GridView2.Rows[vLoop].FindControl("txtqtynarration");

                    if (Convert.ToDouble(txtuqty.Text) > 0)
                    {

                        int insertrawitems = objbs.Inserttransrawitemaccept4(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(0), Convert.ToInt32(ddlrequestno.SelectedValue), Convert.ToDouble(txtuqty.Text), txtqtynarration.Text);
                    }
                }
                Response.Redirect("StoreRawItemRequestGrid.aspx");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


        protected void btnsearchqty_OnClick(object sender, EventArgs e)
        {
            gvbranchqty.Visible = true;
            Griddc.Visible = false;
            gvDetails.Visible = false;
            DateTime sDate = DateTime.ParseExact(txtrequestdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getStockRequestFromBranchsQtyStore_kitchen(sCode, sDate, drpdcqtywise.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Caption = "";

                if (drpdcqtywise.SelectedValue == "0")
                {
                    Caption = "Branches Qty on :- " + sDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    Caption = "Summary Wise Qty on :- " + sDate.ToString("dd/MM/yyyy");
                }
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

        protected void gvbranchqty_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (drpdcqtywise.SelectedValue == "0")
            {

                bool IsSubTotalRowNeedToAdd = false;

                if ((Categoryid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "branchid") != null))
                    if (Categoryid != DataBinder.Eval(e.Row.DataItem, "branchid").ToString())
                        IsSubTotalRowNeedToAdd = true;
                if ((Categoryid != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "branchid") == null))
                {
                    IsSubTotalRowNeedToAdd = true;
                    intSubTotalIndex = 0;
                }
                #region Inserting first Row and populating fist Group Header details
                if ((Categoryid == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "branchid") != null))
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
                    cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "brancharea").ToString();
                    cell.ColumnSpan = 4;
                    cell.CssClass = "GroupHeaderStyle";
                    row.Cells.Add(cell);
                    gridPurchase.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;

                    RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                    UOM = DataBinder.Eval(e.Row.DataItem, "UOM").ToString();
                }
                else if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
                {
                    if (Categoryid == DataBinder.Eval(e.Row.DataItem, "branchid").ToString())
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

                    if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
                    {
                        RowSubTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                    }



                    #endregion

                    #region Adding Next Group Header Details
                    if (DataBinder.Eval(e.Row.DataItem, "branchid") != null)
                    {
                        row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                        cell = new TableCell();
                        cell.Text = "Branch Name : " + DataBinder.Eval(e.Row.DataItem, "brancharea").ToString();
                        cell.ColumnSpan = 4;
                        cell.CssClass = "GroupHeaderStyle";
                        row.Cells.Add(cell);
                        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                        intSubTotalIndex++;

                    }
                    #endregion


                }
            }
            else
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
        }

        protected void gvbranchqty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (drpdcqtywise.SelectedValue == "0")
                {
                    Categoryid = DataBinder.Eval(e.Row.DataItem, "branchid").ToString();
                }
                else
                {
                    Categoryid = DataBinder.Eval(e.Row.DataItem, "Categoryid").ToString();
                }
            }
        }

        protected void btnexport_click(object sender, EventArgs e)
        {
            gvbranchqty.Visible = true;
            Griddc.Visible = false;
            gvDetails.Visible = false;
            DateTime sDate = DateTime.ParseExact(txtrequestdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objbs.getStockRequestFromBranchsQtyStore_kitchen(sCode, sDate, drpdcqtywise.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string Caption = "";

                if (drpdcqtywise.SelectedValue == "0")
                {
                    Caption = "Branches Qty on :- " + sDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    Caption = "Summary Wise Qty on :- " + sDate.ToString("dd/MM/yyyy");
                }
                gvbranchqty.Caption = Caption;
                gvbranchqty.DataSource = ds;
                gvbranchqty.DataBind();

                string filename = "";
                if (drpdcqtywise.SelectedValue == "0")
                {
                    filename = "Branch_Wise_Qty.xls";
                }
                else
                {
                    filename = "SummaryQty.xls";
                }
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                gvbranchqty.Caption = "Stock Request from Kitchen Qty Store On " + sDate;
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

    }
}
