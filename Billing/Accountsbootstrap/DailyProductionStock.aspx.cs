﻿using System;
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

namespace Billing.Accountsbootstrap
{
    public partial class DailyProductionStock : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";

        string strPreviousRowID = string.Empty;

        int intSubTotalIndex = 1;
        string isbatchwise = "N";



        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            isbatchwise = Request.Cookies["userInfo"]["isbatchwise"].ToString();

            if (!IsPostBack)
            {

                goodsentrytype(sender, e);
                DataSet dDcNo = objbs.getDailyProdMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();
                txtDCDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                DataSet drpdpown = objbs.getfinishraw(sCode);
                if (drpdpown.Tables[0].Rows.Count > 0)
                {
                    ddlrequestno.DataSource = drpdpown;
                    ddlrequestno.DataTextField = "RequestNo";
                    ddlrequestno.DataValueField = "RequestNo";
                    ddlrequestno.DataBind();
                    ddlrequestno.Items.Insert(0, "Select ReceiveNo");
                }

                DataSet dscategory = objbs.selectcategorymasterforproductionentry();
                if (dscategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dscategory;
                    ddlcategory.DataTextField = "Category";
                    ddlcategory.DataValueField = "Categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select");
                }


                DataSet dsbatch  = objbs.getbatch();
                if (dsbatch.Tables[0].Rows.Count > 0)
                {
                    drpbatch.DataSource = dsbatch;
                    drpbatch.DataTextField = "FullBatchNo";
                    drpbatch.DataValueField = "batchid";
                    drpbatch.DataBind();
                    drpbatch.Items.Insert(0, "Select Batchno");
                }

                //DataSet dsitem = objbs.AllItems();
                //if (dsitem.Tables[0].Rows.Count > 0)
                //{
                //    drpitem.DataSource = dscategory;
                //    drpitem.DataTextField = "Definition";
                //    drpitem.DataValueField = "Categoryuserid";
                //    drpitem.DataBind();

                //}

            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }
        protected void radchk_checked(object sender, EventArgs e)
        {
            if (radentrytype.SelectedValue == "3")
            {
                ddlrequestno.Enabled = false;
                ddlrequestno_OnSelectedIndexChanged(sender, e);

                if (radchk.SelectedValue == "0")
                {
                    gvitems.Visible = false;
                    single.Visible = true;
                }
                else
                {
                    gvitems.Visible = true;
                    single.Visible = false;

                }
                //lblgridheading.Text = "Production Stock Queue Details";
                //GridView2.Visible = false;
                //gvqueueitems.Visible = true;
            }
            else
            {
                ddlrequestno.Enabled = true;
                gvitems.Visible = false;
                single.Visible = false;
                //lblgridheading.Text = "Raw Materials Details";
                //GridView2.Visible = true;
                //gvqueueitems.Visible = false;
            }
        }

        protected void btnaddqueue_OnClick(object sender, EventArgs e)
        {

            if (isbatchwise == "Y")
            {

                if (drpbatch.SelectedValue == "Select Batchno")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Batch No.Thank You!!!');", true);
                    return;
                }
            }


            DataSet dstd = new DataSet();
            DataTable dtddd = new DataTable();


            DataTable dttt;
            DataRow drNew;
            DataColumn dct;
            dttt = new DataTable();

            dct = new DataColumn("CategoryID");
            dttt.Columns.Add(dct);
            dct = new DataColumn("CategoryUserID");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOMID");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Category");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Definition");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("DmgQty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);

            dct = new DataColumn("BatchWise");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Expday");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Expirydate");
            dttt.Columns.Add(dct);

            dstd.Tables.Add(dttt);
          //  dct = new DataColumn("ProductionUOMID");
            //dttt.Columns.Add(dct);
            //dct = new DataColumn("ProductionUOM");
            //dttt.Columns.Add(dct);


            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];


                for (int i = 0; i < gvitems.Rows.Count; i++)
                {
                    HiddenField hideCategoryID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryID");
                    HiddenField hideCategoryUserID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryUserID");
                    HiddenField hideUOMID = (HiddenField)gvitems.Rows[i].FindControl("hideUOMID");

                    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");
                    
                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    TextBox txtdmgQty = (TextBox)gvitems.Rows[i].FindControl("txtdmgQty");

                    if (txtdmgQty.Text == "")
                        txtdmgQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;
                        
                        drNew["Qty"] = txtQty.Text;
                        drNew["dmgQty"] = txtdmgQty.Text;
                        drNew["UOM"] = lblom.Text;
                        // get itemcode 

                        DataSet getitemcode = objbs.SelectDefinition(Convert.ToInt32(hideCategoryUserID.Value));
                        if (getitemcode.Tables[0].Rows.Count > 0)
                        {

                            string serial = getitemcode.Tables[0].Rows[0]["serial"].ToString();
                            string expday = getitemcode.Tables[0].Rows[0]["expday"].ToString();

                            if (serial == "")
                                serial = "0";

                            if (expday == "")
                                expday = "0";


                            int value = Convert.ToInt32(serial);
                            string serial1 = String.Format("{0:0000}", value);

                            //string CurrentYear = DateTime.Now.Year.ToString("yy");

                            //string Currentmonth = DateTime.Now.Month.ToString("mm");
                            //string Currentdate = DateTime.Now.Date.ToString("dd");

                            var CurrentYear = DateTime.Now.ToString("yy");
                            var Currentmonth = DateTime.Now.ToString("MM");
                            var Currentdate = DateTime.Now.ToString("dd");

                            var expirydate = DateTime.Now.AddDays( Convert.ToDouble(expday));



                            drNew["BatchWise"] = serial1 + Currentdate + Currentmonth + CurrentYear + drpbatch.SelectedItem.Text;

                            drNew["Expday"] = expday;
                            drNew["Expirydate"] = expirydate;

                            
                                


                        }
                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];


                    }
                }

                dtddd.Merge(dt);
                ViewState["CurrentTable1"] = dtddd;
            }
            else
            {
                for (int i = 0; i < gvitems.Rows.Count; i++)
                {
                    HiddenField hideCategoryID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryID");
                    HiddenField hideCategoryUserID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryUserID");
                    HiddenField hideUOMID = (HiddenField)gvitems.Rows[i].FindControl("hideUOMID");

                    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");
                    
                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");
                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    TextBox txtdmgQty = (TextBox)gvitems.Rows[i].FindControl("txtdmgQty");

                    if (txtdmgQty.Text == "")
                        txtdmgQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;
                        
                        drNew["Qty"] = txtQty.Text;
                        drNew["dmgQty"] = txtdmgQty.Text;
                        drNew["UOM"] = lblom.Text;

                        DataSet getitemcode = objbs.SelectDefinition(Convert.ToInt32(hideCategoryUserID.Value));
                        if (getitemcode.Tables[0].Rows.Count > 0)
                        {

                             string serial = getitemcode.Tables[0].Rows[0]["serial"].ToString();
                            string expday = getitemcode.Tables[0].Rows[0]["expday"].ToString();

                            if (serial == "")
                                serial = "0";

                            if (expday == "")
                                expday = "0";


                            int value = Convert.ToInt32(serial);
                            string serial1 = String.Format("{0:0000}", value);

                           // string CurrentYear = DateTime.Now.Year.ToString("yy");

                            var CurrentYear = DateTime.Now.ToString("yy");
                            var Currentmonth = DateTime.Now.ToString("MM");
                            var Currentdate = DateTime.Now.ToString("dd");


                            // string  = DateTime.Now.Month.ToString("mm");
                            // string  = DateTime.Now.Day.ToString("dd");

                            var expirydate = DateTime.Now.AddDays(Convert.ToDouble(expday));



                            drNew["BatchWise"] = serial1 + Currentdate + Currentmonth + CurrentYear + drpbatch.SelectedItem.Text;

                            drNew["Expday"] = expday;
                            drNew["Expirydate"] = expirydate;



                            // drNew["BatchWise"] = serial1 + Currentdate + Currentmonth + CurrentYear + drpbatch.SelectedItem.Text;

                        }





                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];

                    }

                }

                ViewState["CurrentTable1"] = dtddd;
            }

            //DataSet dsrawmerge = new DataSet();
            //dsrawmerge.Tables.Add(dtddd);

            #region Summary

            DataTable dtraw = new DataTable();
            DataSet dsraw = new DataSet();
            DataRow drraw;

            dtraw.Columns.Add("CategoryID");
            dtraw.Columns.Add("CategoryUserID");
            dtraw.Columns.Add("UOMID");

            dtraw.Columns.Add("Category");
            dtraw.Columns.Add("Definition");
            
            dtraw.Columns.Add("Qty");
            dtraw.Columns.Add("dmgQty");
            dtraw.Columns.Add("UOM");
            dtraw.Columns.Add("BatchWise");
            dtraw.Columns.Add("expday");
            dtraw.Columns.Add("expirydate");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], UOM = r["UOM"], Batchwise = r["Batchwise"], expday = r["expday"], expirydate = r["expirydate"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  dmgQty = raw.Sum(x => Convert.ToDouble(x["dmgQty"])),
                                  UOM = raw.Key.UOM,
                                  Batchwise = raw.Key.Batchwise,
                                  expday = raw.Key.expday,
                                  expirydate = raw.Key.expirydate,
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Definition"] = g.Definition;
                    
                    drraw["Qty"] = Convert.ToDouble(g.Qty);
                    drraw["dmgQty"] = Convert.ToDouble(g.dmgQty);
                    drraw["UOM"] = g.UOM;
                    drraw["BatchWise"] = g.Batchwise;
                    drraw["expday"] = g.expday;
                    drraw["expirydate"] = Convert.ToDateTime(g.expirydate).ToString("dd/MM/yyyy");

                    dsraw.Tables[0].Rows.Add(drraw);
                }
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                #endregion
            }


            #endregion


            if (radentrytype.SelectedValue == "1")
            {
                btnexecuteraw_OnClick(sender, e);
            }

            gvitems.DataSource = null;
            gvitems.DataBind();

        }

        protected void gvqueueitems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "plus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");
                txtQty.Text = Convert.ToInt32(Convert.ToDouble(txtQty.Text) + 1).ToString();
            }

            if (e.CommandName == "minus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                if (Convert.ToInt32(txtQty.Text) > 0)
                {
                    txtQty.Text = Convert.ToInt32(Convert.ToDouble(txtQty.Text) - 1).ToString();
                }
                else
                {
                    txtQty.Text = "0";
                }
            }

            DataSet dstd = new DataSet();
            DataTable dtddd = new DataTable();

            DataTable dttt;
            DataRow drNew;
            DataColumn dct;
            dttt = new DataTable();

            dct = new DataColumn("CategoryID");
            dttt.Columns.Add(dct);
            dct = new DataColumn("CategoryUserID");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOMID");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Category");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Definition");
            dttt.Columns.Add(dct);
            
            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("dmgQty");
            dttt.Columns.Add(dct);

            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);
            dct = new DataColumn("BatchWise");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Expday");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Expirydate");
            dttt.Columns.Add(dct);



            dstd.Tables.Add(dttt);

            for (int i = 0; i < gvqueueitems.Rows.Count; i++)
            {
                HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryID");
                HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                HiddenField hideUOMID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideUOMID");

                Label lblCategory = (Label)gvqueueitems.Rows[i].FindControl("lblCategory");
                Label lblDefinition = (Label)gvqueueitems.Rows[i].FindControl("lblDefinition");
                
                Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");

                Label lbBatchWise = (Label)gvqueueitems.Rows[i].FindControl("lbBatchWise");
                Label lbexpday = (Label)gvqueueitems.Rows[i].FindControl("lbexpday");
                Label lblexpirydate = (Label)gvqueueitems.Rows[i].FindControl("lblexpirydate");

                TextBox txtQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtQty");
                if (txtQty.Text == "")
                    txtQty.Text = "0";

                TextBox txtdmgQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtdmgQty");
                if (txtdmgQty.Text == "")
                    txtdmgQty.Text = "0";

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    drNew = dttt.NewRow();
                    drNew["CategoryID"] = hideCategoryID.Value;
                    drNew["CategoryUserID"] = hideCategoryUserID.Value;
                    drNew["UOMID"] = hideUOMID.Value;

                    drNew["Category"] = lblCategory.Text;
                    drNew["Definition"] = lblDefinition.Text;
                    
                    drNew["Qty"] = txtQty.Text;
                    drNew["dmgQty"] = txtdmgQty.Text;
                    drNew["UOM"] = lblom.Text;

                    drNew["BatchWise"] = lbBatchWise.Text;
                    drNew["Expday"] = lbexpday.Text;
                    drNew["Expirydate"] = lblexpirydate.Text;

                    dstd.Tables[0].Rows.Add(drNew);
                    dtddd = dstd.Tables[0];
                }
            }

            ViewState["CurrentTable1"] = dtddd;
        }

        protected void gvqueueitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    gvqueueitems.DataSource = dt;
                    gvqueueitems.DataBind();

                    SetPreviousData1();


                }

                else if (dt.Rows.Count == 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    gvqueueitems.DataSource = dt;
                    gvqueueitems.DataBind();

                    SetPreviousData1();

                    gvqueueitems.DataSource = null;
                    gvqueueitems.DataBind();
                    ViewState["CurrentTable1"] = null;
                }

            }
        }

        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Label lblCategory =
                          (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblCategory");

                        HiddenField hideCategoryID =
                          (HiddenField)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("hideCategoryID");
                        HiddenField hideCategoryUserID =
                          (HiddenField)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("hideCategoryUserID");
                        HiddenField hideUOMID =
                          (HiddenField)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("hideUOMID");

                        Label lblDefinition =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblDefinition");
                        

                        TextBox txtQty =
                          (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                        TextBox txtdmgQty =
                          (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtdmgQty");

                        Label lblom =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblom");

                        Label lbBatchWise =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lbBatchWise");

                        Label lbexpday =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lbexpday");

                        Label lblexpirydate =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblexpirydate");



                        lblCategory.Text = dt.Rows[i]["Category"].ToString();
                        hideCategoryID.Value = dt.Rows[i]["CategoryID"].ToString();
                        hideCategoryUserID.Value = dt.Rows[i]["CategoryUserID"].ToString();
                        hideUOMID.Value = dt.Rows[i]["UOMID"].ToString();
                        lblDefinition.Text = dt.Rows[i]["Definition"].ToString();
                        
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        txtdmgQty.Text = dt.Rows[i]["dmgQty"].ToString();
                        lblom.Text = dt.Rows[i]["UOM"].ToString();

                        lbBatchWise.Text = dt.Rows[i]["BatchWise"].ToString();
                        lbexpday.Text = dt.Rows[i]["expday"].ToString();
                        lblexpirydate.Text = dt.Rows[i]["expirydate"].ToString();

                        rowIndex++;

                    }
                }
            }
        }
        protected void goodsentrytype(object sender, EventArgs e)
        {
            if (radentrytype.SelectedValue == "1")
            {
                GridView2.Visible = true;
                gvqueueitems.Visible = true;
                lblgridheading.Text = "Production Stock Queue Details/Raw Materials Details";
                ddlrequestno_OnSelectedIndexChanged(sender, e);
                ddlrequestno.Enabled = false;
              //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('This Type is in Process.Please Select Another Type.Thank You!!!');", true);
              //  return;
            }
            else if (radentrytype.SelectedValue == "2")
            {
                ddlrequestno.Enabled = true;

                lblgridheading.Text = "Raw Materials Details";
                GridView2.Visible = true;
                gvqueueitems.Visible = false;

            }
            else if (radentrytype.SelectedValue == "3")
            {
                ddlrequestno.Enabled = false;
                ddlrequestno_OnSelectedIndexChanged(sender, e);
                lblgridheading.Text = "Production Stock Queue Details";
                GridView2.Visible = false;
                gvqueueitems.Visible = true;
            }

        }
        protected void ddlrequestno_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvRawRequest.DataSource = null;
            gvRawRequest.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();

            if (radentrytype.SelectedValue == "2")
            {

                GridView2.Visible = true;
                gvRawRequest.Visible = true;
                gvitems.Visible = false;

                if (ddlrequestno.SelectedValue != "Select ReceiveNo" && ddlrequestno.SelectedValue != "0" && ddlrequestno.SelectedValue != "")
                {
                    DataSet dDcsreqNo = objbs.getFinishRawMaterialdetails(sCode, ddlrequestno.SelectedValue, ddlcategory.SelectedValue);
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
                        dtraw.Columns.Add("RawStock");
                        dtraw.Columns.Add("WantedRaw");
                        dtraw.Columns.Add("UOM");
                        dsraw.Tables.Add(dtraw);




                        DataSet dsrawmerge = objbs.GetFinishrawitems(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
                        if (dsrawmerge.Tables[0].Rows.Count > 0)
                        {
                            #region

                            DataTable dtraws = dsrawmerge.Tables[0];

                            var result1 = from r in dtraws.AsEnumerable()
                                          group r by new { RawStock = r["RawStock"], IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                          select new
                                          {
                                              IngredientName = raw.Key.IngredientName,
                                              Semiitemid = raw.Key.Semiitemid,
                                              RawStock = raw.Key.RawStock,
                                              total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                              UOM = raw.Key.UOM,
                                          };


                            foreach (var g in result1)
                            {
                                drraw = dtraw.NewRow();

                                drraw["Semiitemid"] = g.Semiitemid;
                                drraw["IngredientName"] = g.IngredientName;
                                drraw["RawStock"] = Convert.ToDouble(g.RawStock).ToString("f3");

                                //  string RoundofWantedRaw = Math.Round(g.total).ToString("f3");

                                drraw["WantedRaw"] = (g.total).ToString("f3");
                                drraw["UOM"] = g.UOM;

                                dsraw.Tables[0].Rows.Add(drraw);
                            }
                            GridView2.DataSource = dsraw.Tables[0];
                            GridView2.DataBind();

                            #endregion
                        }


                        #endregion
                    }
                    else
                    {
                        gvRawRequest.DataSource = null;
                        gvRawRequest.DataBind();
                    }

                }
            }
            else if (radentrytype.SelectedValue == "3" || radentrytype.SelectedValue == "1")
            {
                if (radentrytype.SelectedValue == "1")
                {
                    GridView2.Visible = true; ;
                }
                else
                {
                    GridView2.Visible = false;
                }
                gvRawRequest.Visible = false;
                gvitems.Visible = true;

                if (ddlcategory.SelectedValue == "Select")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Category.Thank You!!!');", true);
                    return;
                }
                else
                {

                    DataSet dsitems = objbs.itemforreqestNew_DailyProd((ddlcategory.SelectedValue), sTableName);
                    if (dsitems.Tables[0].Rows.Count > 0)
                    {
                        gvitems.DataSource = dsitems;
                        gvitems.DataBind();

                    }
                    else
                    {
                        gvitems.DataSource = null;
                        gvitems.DataBind();
                    }
                }

            }
            else if (radentrytype.SelectedValue == "1")
            {
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

                txtfinalqty.Text = (Convert.ToDouble(lblQty.Text) - Convert.ToDouble(txtadjqty.Text)).ToString();


            }


        }


        protected void btngenerate_OnClick(object sender, EventArgs e)
        {
            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                #region

                HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");

                Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");

                Label lblProd_Qty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProd_Qty");

                TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");
                TextBox txtPendingfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtPendingfrozenqty");
                //TextBox txtuncomplete = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtuncomplete");
                TextBox txtfinal = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfinal");

                // TextBox txttakefrozen = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txttakefrozen");

                //if (Convert.ToDouble(txtPendingfrozenqty.Text)<Convert.ToDouble(txttakefrozen.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Take Frozen for " + lblProduct.Text + " No.Thank You!!!');", true);
                //    return;
                //}

                if (txtreadyqty.Text == "")
                    txtreadyqty.Text = "0";
                if (txtdamageqty.Text == "")
                    txtdamageqty.Text = "0";
                if (txtfrozenqty.Text == "")
                    txtfrozenqty.Text = "0";
                if (txtPendingfrozenqty.Text == "")
                    txtPendingfrozenqty.Text = "0";
                //if (txtuncomplete.Text == "")
                //    txtuncomplete.Text = "0";

                if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != Convert.ToDouble(txtfinalqty.Text))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Requested Qty Equal To (Production Output + damage + Frozen)  for " + lblProduct.Text + ".Thank You!!!');", true);
                    return;
                }


                txtfinal.Text = (Convert.ToDouble(lblProd_Qty.Text) + Convert.ToDouble(txtPendingfrozenqty.Text) + Convert.ToDouble(txtreadyqty.Text)).ToString("f2");
                if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != 0)
                {
                    if ((Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text)) != Convert.ToDouble(txtfinalqty.Text))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty for " + lblProduct.Text + " No.Thank You!!!');", true);
                        return;
                    }
                }
                #endregion
            }

        }

        protected void btnexecuteraw_OnClick(object sender, EventArgs e)
        {
            if (radentrytype.SelectedValue == "2")
            {

                for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");

                    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");

                    Label lblProd_Qty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProd_Qty");

                    TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                    TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                    TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");
                    TextBox txtPendingfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtPendingfrozenqty");
                    //TextBox txtuncomplete = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtuncomplete");
                    TextBox txtfinal = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfinal");

                    //   TextBox txttakefrozen = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txttakefrozen");

                    //if (Convert.ToDouble(txtPendingfrozenqty.Text)<Convert.ToDouble(txttakefrozen.Text))
                    //{
                    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Take Frozen for " + lblProduct.Text + " No.Thank You!!!');", true);
                    //    return;
                    //}

                    if (txtreadyqty.Text == "")
                        txtreadyqty.Text = "0";
                    if (txtdamageqty.Text == "")
                        txtdamageqty.Text = "0";
                    if (txtfrozenqty.Text == "")
                        txtfrozenqty.Text = "0";
                    if (txtPendingfrozenqty.Text == "")
                        txtPendingfrozenqty.Text = "0";
                    //if (txtuncomplete.Text == "")
                    //    txtuncomplete.Text = "0";


                    if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != Convert.ToDouble(txtfinalqty.Text))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Requested Qty Equal To (Production Output + damage + Frozen)  for " + lblProduct.Text + " No.Thank You!!!');", true);
                        return;
                    }

                    txtfinal.Text = (Convert.ToDouble(lblProd_Qty.Text) + Convert.ToDouble(txtPendingfrozenqty.Text) + Convert.ToDouble(txtreadyqty.Text)).ToString("f2");
                    if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != 0)
                    {
                        if ((Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text)) != Convert.ToDouble(txtfinalqty.Text))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty for " + lblProduct.Text + " No.Thank You!!!');", true);
                            return;
                        }
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
                dtraw.Columns.Add("RawStock");
                dtraw.Columns.Add("UOM");
                dsraw.Tables.Add(dtraw);

                DataSet dsrawmerge = new DataSet();

                for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                {
                    HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");

                    TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                    TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                    TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");


                    if (txtreadyqty.Text == "")
                        txtreadyqty.Text = "0";
                    if (txtdamageqty.Text == "")
                        txtdamageqty.Text = "0";
                    if (txtfrozenqty.Text == "")
                        txtfrozenqty.Text = "0";

                    double ttlqty = (Convert.ToInt32(txtreadyqty.Text) + Convert.ToInt32(txtdamageqty.Text) + Convert.ToInt32(txtfrozenqty.Text));

                    DataSet dsrawitems = objbs.Getwantrawnewbyjothi(Convert.ToInt32(productid.Value), Convert.ToDouble(ttlqty), sCode);
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
                                  group r by new { RawStock = r["RawStock"], IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                  select new
                                  {
                                      Semiitemid = raw.Key.Semiitemid,
                                      IngredientName = raw.Key.IngredientName,
                                      RawStock = raw.Key.RawStock,
                                      total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                      UOM = raw.Key.UOM,
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();

                        drraw["Semiitemid"] = g.Semiitemid;
                        drraw["IngredientName"] = g.IngredientName;
                        drraw["RawStock"] = Convert.ToDouble(g.RawStock).ToString("f3");

                        //  string RoundofWantedRaw = Math.Round(g.total).ToString("f2");

                        drraw["WantedRaw"] = (g.total).ToString("f3");
                        drraw["UOM"] = g.UOM;

                        dsraw.Tables[0].Rows.Add(drraw);
                    }
                    GridView2.DataSource = dsraw.Tables[0];
                    GridView2.DataBind();
                }


                #endregion
            }
            else if (radentrytype.SelectedValue == "1")
            {
                //for (int i = 0; i < gvitems.Rows.Count; i++)
                //{
                //    HiddenField hideCategoryID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryID");
                //    HiddenField hideCategoryUserID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryUserID");
                //    HiddenField hideUOMID = (HiddenField)gvitems.Rows[i].FindControl("hideUOMID");

                //    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                //    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");

                //    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                //    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                //    if (txtQty.Text == "")
                //        txtQty.Text = "0";
                //}

                #region Summary

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Semiitemid");
                dtraw.Columns.Add("IngredientName");
                dtraw.Columns.Add("WantedRaw");
                dtraw.Columns.Add("RawStock");
                dtraw.Columns.Add("UOM");
                dsraw.Tables.Add(dtraw);

                DataSet dsrawmerge = new DataSet();

                for (int vLoop = 0; vLoop < gvqueueitems.Rows.Count; vLoop++)
                {
                    HiddenField productid = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryUserID");

                    TextBox txtreadyqty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtQty");
                  //  TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                   // TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");


                    if (txtreadyqty.Text == "")
                        txtreadyqty.Text = "0";
                    //if (txtdamageqty.Text == "")
                    //    txtdamageqty.Text = "0";
                    //if (txtfrozenqty.Text == "")
                    //    txtfrozenqty.Text = "0";

                    double ttlqty = (Convert.ToInt32(txtreadyqty.Text));

                    DataSet dsrawitems = objbs.Getwantrawnewbyjothi(Convert.ToInt32(productid.Value), Convert.ToDouble(ttlqty), sCode);
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
                                      group r by new { RawStock = r["RawStock"], IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                      select new
                                      {
                                          Semiitemid = raw.Key.Semiitemid,
                                          IngredientName = raw.Key.IngredientName,
                                          RawStock = raw.Key.RawStock,
                                          total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                          UOM = raw.Key.UOM,
                                      };


                        foreach (var g in result1)
                        {
                            drraw = dtraw.NewRow();

                            drraw["Semiitemid"] = g.Semiitemid;
                            drraw["IngredientName"] = g.IngredientName;
                            drraw["RawStock"] = Convert.ToDouble(g.RawStock).ToString("f3");

                            //  string RoundofWantedRaw = Math.Round(g.total).ToString("f2");

                            drraw["WantedRaw"] = (g.total).ToString("f3");
                            drraw["UOM"] = g.UOM;

                            dsraw.Tables[0].Rows.Add(drraw);
                        }
                        GridView2.DataSource = dsraw.Tables[0];
                        GridView2.DataBind();
                    }
                }


                #endregion
            }
        }


        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (isbatchwise == "Y")
            {

                if (drpbatch.SelectedValue == "Select Batchno")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Batch No.Thank You!!!');", true);
                    return;
                }
            }

            if (radentrytype.SelectedValue == "2")
            {

                if (ddlrequestno.SelectedValue == "Select ReceiveNo" || ddlrequestno.SelectedValue == "0" || ddlrequestno.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check ReceiveNo No.Thank You!!!');", true);
                    return;
                }

                for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                    Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");

                    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");

                    Label lblProd_Qty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProd_Qty");

                    TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                    TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                    TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");
                    TextBox txtPendingfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtPendingfrozenqty");
                    //TextBox txtuncomplete = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtuncomplete");
                    TextBox txtfinal = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfinal");

                    // TextBox txttakefrozen = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txttakefrozen");

                    //if (Convert.ToDouble(txtPendingfrozenqty.Text)<Convert.ToDouble(txttakefrozen.Text))
                    //{
                    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Take Frozen for " + lblProduct.Text + " No.Thank You!!!');", true);
                    //    return;
                    //}

                    if (txtreadyqty.Text == "")
                        txtreadyqty.Text = "0";
                    if (txtdamageqty.Text == "")
                        txtdamageqty.Text = "0";
                    if (txtfrozenqty.Text == "")
                        txtfrozenqty.Text = "0";
                    if (txtPendingfrozenqty.Text == "")
                        txtPendingfrozenqty.Text = "0";
                    //if (txtuncomplete.Text == "")
                    //    txtuncomplete.Text = "0";

                    if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != Convert.ToDouble(txtfinalqty.Text))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Requested Qty Equal To (Production Output + damage + Frozen)  for " + lblProduct.Text + " No.Thank You!!!');", true);
                        return;
                    }

                    txtfinal.Text = (Convert.ToDouble(lblProd_Qty.Text) + Convert.ToDouble(txtPendingfrozenqty.Text) + Convert.ToDouble(txtreadyqty.Text)).ToString("f2");
                    if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != 0)
                    {
                        if ((Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text)) != Convert.ToDouble(txtfinalqty.Text))
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty for " + lblProduct.Text + " No.Thank You!!!');", true);
                            return;
                        }
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
                dtraw.Columns.Add("RawStock");
                dtraw.Columns.Add("UOM");
                dsraw.Tables.Add(dtraw);

                DataSet dsrawmerge = new DataSet();

                for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                {
                    HiddenField productid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");

                    TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                    TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                    TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");


                    if (txtreadyqty.Text == "")
                        txtreadyqty.Text = "0";
                    if (txtdamageqty.Text == "")
                        txtdamageqty.Text = "0";
                    if (txtfrozenqty.Text == "")
                        txtfrozenqty.Text = "0";

                    double ttlqty = (Convert.ToInt32(txtreadyqty.Text) + Convert.ToInt32(txtdamageqty.Text) + Convert.ToInt32(txtfrozenqty.Text));

                    DataSet dsrawitems = objbs.Getwantrawnewbyjothi(Convert.ToInt32(productid.Value), Convert.ToDouble(ttlqty), sCode);
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
                                  group r by new { RawStock = r["RawStock"], IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                  select new
                                  {
                                      Semiitemid = raw.Key.Semiitemid,
                                      IngredientName = raw.Key.IngredientName,
                                      RawStock = raw.Key.RawStock,
                                      total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                      UOM = raw.Key.UOM,
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();

                        drraw["Semiitemid"] = g.Semiitemid;
                        drraw["IngredientName"] = g.IngredientName;
                        drraw["RawStock"] = Convert.ToDouble(g.RawStock).ToString("f3");

                        // string RoundofWantedRaw = Math.Round(g.total).ToString("f2");

                        drraw["WantedRaw"] = (g.total).ToString("f3");
                        drraw["UOM"] = g.UOM;

                        dsraw.Tables[0].Rows.Add(drraw);
                    }
                    GridView2.DataSource = dsraw.Tables[0];
                    GridView2.DataBind();
                }


                #endregion




                DataSet dDcNo = objbs.getDailyProdMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

                string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                DateTime Date = Convert.ToDateTime(sDate);

                int RequestID = objbs.Insertrawfinish_DailyProd(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(ddlrequestno.SelectedValue), radentrytype.SelectedValue,drpbatch.SelectedValue);

                for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                    Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");
                    // TextBox txtuncomplete = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtuncomplete");


                    TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                    TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                    TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");
                    // TextBox txttakefrozen = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txttakefrozen");
                    TextBox txtPendingfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtPendingfrozenqty");

                    double ttlqty = (Convert.ToInt32(txtreadyqty.Text) + Convert.ToInt32(txtdamageqty.Text) + Convert.ToInt32(txtfrozenqty.Text));

                    if ((Convert.ToInt32(txtreadyqty.Text) + Convert.ToInt32(txtdamageqty.Text) + Convert.ToInt32(txtfrozenqty.Text)) > 0)
                    {
                        int MainRequestID = objbs.Inserttransrawfinish(sCode, RequestID, Convert.ToInt32(HDProductid.Value), Convert.ToDouble(ttlqty), Convert.ToDouble(txtfrozenqty.Text), Convert.ToInt32(ddlrequestno.SelectedValue), Convert.ToInt32(txtreadyqty.Text), Convert.ToInt32(txtdamageqty.Text), Convert.ToInt32(txtfrozenqty.Text), Convert.ToInt32(txtPendingfrozenqty.Text), Convert.ToInt32(0), Convert.ToInt32(txtPendingfrozenqty.Text), radentrytype.SelectedValue);
                    }
                    #endregion
                }

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");

                    int insertrawitems = objbs.Inserttransrawitemfinish_DailyProd(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(lblWantedRaw.Text));
                }

                ////// int updateRawRequest = objbs.updateRawreceive(sCode, Convert.ToInt32(ddlrequestno.SelectedValue));
                Response.Redirect("DailyProductionStockGrid.aspx");
            }
            else if (radentrytype.SelectedValue == "3")
            {

                int cnt = gvqueueitems.Rows.Count;

                if (cnt == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item in Item Queue.Thank You!!!');", true);
                    return;
                }

                DataSet dDcNo = objbs.getDailyProdMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

                string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                DateTime Date = Convert.ToDateTime(sDate);

                int RequestID = objbs.Insertrawfinish_DailyProd(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(0), radentrytype.SelectedValue,drpbatch.SelectedValue);

                for (int vLoop = 0; vLoop < gvqueueitems.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField hideitemID = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryUserID");


                    Label lbBatchWise = (Label)gvqueueitems.Rows[vLoop].FindControl("lbBatchWise");
                    Label lbexpday = (Label)gvqueueitems.Rows[vLoop].FindControl("lbexpday");
                    Label lblexpirydate = (Label)gvqueueitems.Rows[vLoop].FindControl("lblexpirydate");

                    TextBox txtQty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtQty");
                    TextBox txtdmgQty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtdmgQty");
                    if (txtdmgQty.Text == "")
                        txtdmgQty.Text = "0";
                    if (txtQty.Text == "" || txtQty.Text == "0")
                    {

                    }
                    else
                    {
                        int MainRequestID = objbs.Inserttransrawfinish_DailyStock(sCode, RequestID, Convert.ToInt32(hideitemID.Value), Convert.ToDouble(txtQty.Text), Convert.ToDouble(0), Convert.ToInt32(0), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtdmgQty.Text), Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0), radentrytype.SelectedValue,lbBatchWise.Text,lbexpday.Text,lblexpirydate.Text);
                    }
                    #endregion
                }
                Response.Redirect("DailyProductionStockGrid.aspx");
            }

            else if (radentrytype.SelectedValue == "1")
            {

                {
                   
                    #region Summary

                    DataTable dtraw = new DataTable();
                    DataSet dsraw = new DataSet();
                    DataRow drraw;

                    dtraw.Columns.Add("Semiitemid");
                    dtraw.Columns.Add("IngredientName");
                    dtraw.Columns.Add("WantedRaw");
                    dtraw.Columns.Add("RawStock");
                    dtraw.Columns.Add("UOM");
                    dsraw.Tables.Add(dtraw);

                    DataSet dsrawmerge = new DataSet();

                    for (int vLoop = 0; vLoop < gvqueueitems.Rows.Count; vLoop++)
                    {
                        HiddenField productid = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryUserID");

                        TextBox txtreadyqty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtQty");
                        //  TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                        // TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");


                        if (txtreadyqty.Text == "")
                            txtreadyqty.Text = "0";
                        //if (txtdamageqty.Text == "")
                        //    txtdamageqty.Text = "0";
                        //if (txtfrozenqty.Text == "")
                        //    txtfrozenqty.Text = "0";

                        double ttlqty = (Convert.ToInt32(txtreadyqty.Text));

                        DataSet dsrawitems = objbs.Getwantrawnewbyjothi(Convert.ToInt32(productid.Value), Convert.ToDouble(ttlqty), sCode);
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
                                          group r by new { RawStock = r["RawStock"], IngredientName = r["IngredientName"], UOM = r["UOM"], Semiitemid = r["Semiitemid"] } into raw
                                          select new
                                          {
                                              Semiitemid = raw.Key.Semiitemid,
                                              IngredientName = raw.Key.IngredientName,
                                              RawStock = raw.Key.RawStock,
                                              total = raw.Sum(x => Convert.ToDouble(x["WantedRaw"])),
                                              UOM = raw.Key.UOM,
                                          };


                            foreach (var g in result1)
                            {
                                drraw = dtraw.NewRow();

                                drraw["Semiitemid"] = g.Semiitemid;
                                drraw["IngredientName"] = g.IngredientName;
                                drraw["RawStock"] = Convert.ToDouble(g.RawStock).ToString("f3");

                                //  string RoundofWantedRaw = Math.Round(g.total).ToString("f2");

                                drraw["WantedRaw"] = (g.total).ToString("f3");
                                drraw["UOM"] = g.UOM;

                                dsraw.Tables[0].Rows.Add(drraw);
                            }
                            GridView2.DataSource = dsraw.Tables[0];
                            GridView2.DataBind();
                        }
                    }


                    #endregion
                }

                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('This Type is in Process.Thank You!!!');", true);
                //return;
                int cnt = gvqueueitems.Rows.Count;

                if (cnt == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item in Item Queue.Thank You!!!');", true);
                    return;
                }

                DataSet dDcNo = objbs.getDailyProdMaterialsno((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["RequestNo"].ToString();

                string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                DateTime Date = Convert.ToDateTime(sDate);

                int RequestID = objbs.Insertrawfinish_DailyProd(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text, Convert.ToInt32(0), radentrytype.SelectedValue,drpbatch.SelectedValue);

                for (int vLoop = 0; vLoop < gvqueueitems.Rows.Count; vLoop++)
                {
                    #region

                    HiddenField hideitemID = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryUserID");

                    Label lbBatchWise = (Label)gvqueueitems.Rows[vLoop].FindControl("lbBatchWise");
                    Label lbexpday = (Label)gvqueueitems.Rows[vLoop].FindControl("lbexpday");
                    Label lblexpirydate = (Label)gvqueueitems.Rows[vLoop].FindControl("lblexpirydate");

                    TextBox txtQty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtQty");
                    TextBox txtdmgQty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtdmgQty");
                    if (txtdmgQty.Text == "")
                        txtdmgQty.Text = "0";

                    if (txtQty.Text == "" || txtQty.Text == "0")
                    {

                    }
                    else
                    {
                        int MainRequestID = objbs.Inserttransrawfinish_DailyStock(sCode, RequestID, Convert.ToInt32(hideitemID.Value), Convert.ToDouble(txtQty.Text), Convert.ToDouble(0), Convert.ToInt32(0), Convert.ToDouble(txtQty.Text), Convert.ToDouble(txtdmgQty.Text), Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0), Convert.ToInt32(0), radentrytype.SelectedValue,lbBatchWise.Text,lbexpday.Text,lblexpirydate.Text);
                    }
                    #endregion
                }

                for (int vLoop = 0; vLoop < GridView2.Rows.Count; vLoop++)
                {
                    HiddenField Semiitemid = (HiddenField)GridView2.Rows[vLoop].FindControl("Semiitemid");
                    Label lblWantedRaw = (Label)GridView2.Rows[vLoop].FindControl("lblWantedRaw");

                    int insertrawitems = objbs.Inserttransrawitemfinish_DailyProd(sCode, RequestID, Convert.ToInt32(Semiitemid.Value), Convert.ToDouble(lblWantedRaw.Text));
                }
                Response.Redirect("DailyProductionStockGrid.aspx");
            }
        }


    }
}