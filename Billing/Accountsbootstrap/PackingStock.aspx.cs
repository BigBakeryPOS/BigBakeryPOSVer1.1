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

namespace Billing.Accountsbootstrap
{
    public partial class PackingStock : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";

        string strPreviousRowID = string.Empty;

        int intSubTotalIndex = 1;



        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();



            if (!IsPostBack)
            {

            //    goodsentrytype(sender, e);
                DataSet dDcNo = objbs.getPackingStockPackNo((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["PackNo"].ToString();
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

        protected void btnaddqueue_OnClick(object sender, EventArgs e) //Add queue items grid button
        {
            btngenerate_OnClick(sender, e);
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
            dct = new DataColumn("ReceiveQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("CurrentQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("FinalQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);

            dct = new DataColumn("batchno");
            dttt.Columns.Add(dct);

            dct = new DataColumn("expirydate");
            dttt.Columns.Add(dct);



            dstd.Tables.Add(dttt);


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

                    TextBox txtReceiveQty = (TextBox)gvitems.Rows[i].FindControl("txtReceiveQty");
                    TextBox txtCurrentQty = (TextBox)gvitems.Rows[i].FindControl("txtCurrentQty");
                    TextBox txtfinalQty = (TextBox)gvitems.Rows[i].FindControl("txtfinalQty");

                    Label lblbatchno = (Label)gvitems.Rows[i].FindControl("lblbatchno");
                    Label lblexpirydate = (Label)gvitems.Rows[i].FindControl("lblexpirydate");

                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (txtReceiveQty.Text == "")
                        txtReceiveQty.Text = "0";
                    if (txtCurrentQty.Text == "")
                        txtCurrentQty.Text = "0";
                    if (txtfinalQty.Text == "")
                        txtfinalQty.Text = "0";

                 //   txtfinalQty.Text = ( (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtReceiveQty.Text))).ToString();

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;
                        
                        drNew["Qty"] =Convert.ToDouble(txtQty.Text);
                        drNew["CurrentQty"] =Convert.ToDouble(txtCurrentQty.Text);
                        drNew["FinalQty"] = Convert.ToDouble(txtfinalQty.Text);
                        drNew["ReceiveQty"] =Convert.ToDouble(txtReceiveQty.Text);
                        drNew["UOM"] = lblom.Text;
                        drNew["batchno"] = lblbatchno.Text;
                        drNew["expirydate"] = lblexpirydate.Text;

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
                    TextBox txtReceiveQty = (TextBox)gvitems.Rows[i].FindControl("txtReceiveQty");
                    TextBox txtCurrentQty = (TextBox)gvitems.Rows[i].FindControl("txtCurrentQty");
                    TextBox txtfinalQty = (TextBox)gvitems.Rows[i].FindControl("txtfinalQty");

                    Label lblbatchno = (Label)gvitems.Rows[i].FindControl("lblbatchno");
                    Label lblexpirydate = (Label)gvitems.Rows[i].FindControl("lblexpirydate");


                    if (txtQty.Text == "")
                        txtQty.Text = "0";
                    if (txtReceiveQty.Text == "")
                        txtReceiveQty.Text = "0.0";
                    if (txtCurrentQty.Text == "")
                        txtCurrentQty.Text = "0.0";
                    if (txtfinalQty.Text == "")
                        txtfinalQty.Text = "0.0";

               //     txtfinalQty.Text = ( (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtReceiveQty.Text))).ToString();

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;

                        drNew["Qty"] = Convert.ToDouble(txtQty.Text);
                        drNew["CurrentQty"] =Convert.ToDouble(txtCurrentQty.Text);
                        drNew["FinalQty"] = Convert.ToDouble(txtfinalQty.Text);
                        drNew["ReceiveQty"] =Convert.ToDouble(txtReceiveQty.Text);

                        drNew["UOM"] = lblom.Text;

                        drNew["batchno"] = lblbatchno.Text;
                        drNew["expirydate"] = lblexpirydate.Text;

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

            dtraw.Columns.Add("ReceiveQty");
            dtraw.Columns.Add("CurrentQty");
            dtraw.Columns.Add("FinalQty");

            dtraw.Columns.Add("UOM");

            dtraw.Columns.Add("batchno");
            dtraw.Columns.Add("expirydate");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], UOM = r["UOM"], batchno = r["batchno"], expirydate = r["expirydate"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  ReceiveQty = raw.Sum(x => Convert.ToDouble(x["ReceiveQty"])),
                                  CurrentQty = raw.Sum(x => Convert.ToDouble(x["CurrentQty"])),
                                  FinalQty = raw.Sum(x => Convert.ToDouble(x["FinalQty"])),
                                  batchno = raw.Key.batchno,
                                  expirydate = raw.Key.expirydate,

                                  UOM = raw.Key.UOM,
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
                    drraw["UOM"] = g.UOM;
                    drraw["CurrentQty"] = Convert.ToDouble(g.CurrentQty);
                    drraw["FinalQty"] = Convert.ToDouble(g.FinalQty);
                    drraw["ReceiveQty"] = Convert.ToDouble(g.ReceiveQty);
                    drraw["batchno"] = g.batchno;
                    drraw["expirydate"] = g.expirydate;
                    dsraw.Tables[0].Rows.Add(drraw);
                }
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                #endregion
            }


            #endregion


            if (radentrytype.SelectedValue == "1")
            {
       //         btnexecuteraw_OnClick(sender, e);
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

                if (Convert.ToInt32(txtQty.Text) >=1)
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
            dct = new DataColumn("ReceiveQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("CurrentQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("FinalQty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);


            dct = new DataColumn("batchno");
            dttt.Columns.Add(dct);

            dct = new DataColumn("expirydate");
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

                TextBox txtQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtQty");
                TextBox txtReceiveQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtReceiveQty");
                TextBox txtCurrentQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtCurrentQty");
                TextBox txtfinalQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtfinalQty");

                Label lblbatchno = (Label)gvqueueitems.Rows[i].FindControl("lblbatchno");
                Label lblexpirydate = (Label)gvqueueitems.Rows[i].FindControl("lblexpirydate");


                if (txtQty.Text == "")
                    txtQty.Text = "0";
                if (txtReceiveQty.Text == "")
                    txtReceiveQty.Text = "0";
                if (txtCurrentQty.Text == "")
                    txtCurrentQty.Text = "0";
                if (txtfinalQty.Text == "")
                    txtfinalQty.Text = "0";

                if ((Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtReceiveQty.Text)) <= Convert.ToDouble(txtCurrentQty.Text))
                    txtfinalQty.Text = ((Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtReceiveQty.Text))).ToString();
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not able to pack the required stock "+lblDefinition.Text+" with the entered Qty!');", true);
                    return;
                }

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    drNew = dttt.NewRow();
                    drNew["CategoryID"] = hideCategoryID.Value;
                    drNew["CategoryUserID"] = hideCategoryUserID.Value;
                    drNew["UOMID"] = hideUOMID.Value;

                    drNew["Category"] = lblCategory.Text;
                    drNew["Definition"] = lblDefinition.Text;
                    
                    drNew["Qty"] = txtQty.Text;
                    drNew["ReceiveQty"] = txtReceiveQty.Text;
                    drNew["CurrentQty"] = txtCurrentQty.Text;
                    drNew["FinalQty"] = txtfinalQty.Text;
                    drNew["UOM"] = lblom.Text;

                    drNew["batchno"] = lblbatchno.Text;

                    drNew["expirydate"] = lblexpirydate.Text;

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

                        Label lblom =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblom");

                        TextBox txtReceiveQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtReceiveQty");
                        TextBox txtCurrentQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtCurrentQty");
                        TextBox txtfinalQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtfinalQty");

                        Label lblbatchno =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblbatchno");

                        Label lblexpirydate =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblexpirydate");

                        lblCategory.Text = dt.Rows[i]["Category"].ToString();
                        hideCategoryID.Value = dt.Rows[i]["CategoryID"].ToString();
                        hideCategoryUserID.Value = dt.Rows[i]["CategoryUserID"].ToString();
                        hideUOMID.Value = dt.Rows[i]["UOMID"].ToString();
                        lblDefinition.Text = dt.Rows[i]["Definition"].ToString();
                        
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();

                        txtReceiveQty.Text = dt.Rows[i]["ReceiveQty"].ToString();
                        txtfinalQty.Text = dt.Rows[i]["FinalQty"].ToString();
                        txtCurrentQty.Text = dt.Rows[i]["CurrentQty"].ToString();

                        lblom.Text = dt.Rows[i]["UOM"].ToString();

                        lblbatchno.Text = dt.Rows[i]["batchno"].ToString();

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

          
             if (radentrytype.SelectedValue == "3" || radentrytype.SelectedValue == "1")
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

                if ((ddlcategory.SelectedValue == "Select")||(ddlcategory.SelectedValue == ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Category.Thank You!!!');", true);
                    return;
                }
                else
                {

                    DataSet dsitems = objbs.getPackingStock((ddlcategory.SelectedValue), sTableName);
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


    


        protected void btngenerate_OnClick(object sender, EventArgs e)// Calculate
        {

            for (int vLoop = 0; vLoop < gvitems.Rows.Count; vLoop++)
            {
                Label lblDefinition = (Label)gvitems.Rows[vLoop].FindControl("lblDefinition");
                TextBox txtQty = (TextBox)gvitems.Rows[vLoop].FindControl("txtQty");
                TextBox txtCurrentQty = (TextBox)gvitems.Rows[vLoop].FindControl("txtCurrentQty");

                TextBox txtReceiveQty = (TextBox)gvitems.Rows[vLoop].FindControl("txtReceiveQty");
                TextBox txtfinalQty = (TextBox)gvitems.Rows[vLoop].FindControl("txtfinalQty");
                if (txtqty.Text == "")
                    txtqty.Text = "0.0";
                if (txtCurrentQty.Text == "")
                    txtCurrentQty.Text = "0.0";
                if (txtReceiveQty.Text == "")
                    txtReceiveQty.Text = "0.0";
                if ((Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtReceiveQty.Text)) <= Convert.ToDouble(txtCurrentQty.Text))
                    txtfinalQty.Text = ((Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtReceiveQty.Text))).ToString();
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not able to pack the required stock " + lblDefinition.Text + " with the entered Qty!');", true);
                    return;
                }

            }

            for (int vLoop = 0; vLoop < gvRawRequest.Rows.Count; vLoop++)
            {
                //#region

                //HiddenField HDProductid = (HiddenField)gvRawRequest.Rows[vLoop].FindControl("HDProductid");
                //Label lblProduct = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProduct");

                //Label txtfinalqty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblQty");

                //Label lblProd_Qty = (Label)gvRawRequest.Rows[vLoop].FindControl("lblProd_Qty");

                //TextBox txtreadyqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtreadyqty");
                //TextBox txtdamageqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtdamageqty");
                //TextBox txtfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfrozenqty");
                //TextBox txtPendingfrozenqty = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtPendingfrozenqty");
              
                //TextBox txtfinal = (TextBox)gvRawRequest.Rows[vLoop].FindControl("txtfinal");

             
                //if (txtreadyqty.Text == "")
                //    txtreadyqty.Text = "0";
                //if (txtdamageqty.Text == "")
                //    txtdamageqty.Text = "0";
                //if (txtfrozenqty.Text == "")
                //    txtfrozenqty.Text = "0";
                //if (txtPendingfrozenqty.Text == "")
                //    txtPendingfrozenqty.Text = "0";
                ////if (txtuncomplete.Text == "")
                ////    txtuncomplete.Text = "0";

              

                //txtfinal.Text = (Convert.ToDouble(lblProd_Qty.Text) + Convert.ToDouble(txtPendingfrozenqty.Text) + Convert.ToDouble(txtreadyqty.Text)).ToString("f2");
                //if (Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text) != 0)
                //{
                //    if ((Convert.ToDouble(txtreadyqty.Text) + Convert.ToDouble(txtdamageqty.Text) + Convert.ToDouble(txtfrozenqty.Text)) != Convert.ToDouble(txtfinalqty.Text))
                //    {
                //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty for " + lblProduct.Text + " No.Thank You!!!');", true);
                //        return;
                //    }
                //}
                //#endregion
            }

        }

      


        protected void btnPrev_Click(object sender, EventArgs e)
        {

                int cnt = gvqueueitems.Rows.Count;

                if (cnt == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item in Item Queue.Thank You!!!');", true);
                    return;
                }

                DataSet dDcNo = objbs.getPackingStockPackNo((sCode));
                txtDCNo.Text = dDcNo.Tables[0].Rows[0]["PackNo"].ToString();

                string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
                DateTime Date = Convert.ToDateTime(sDate);

                int PackId = objbs.InserPackingStock(sCode, txtDCNo.Text, Date, txtAccepted.Text, lblUserID.Text);

              
                for (int i = 0; i < gvqueueitems.Rows.Count; i++)
                {
                    HiddenField CategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                    Label Definition = (Label)gvqueueitems.Rows[i].FindControl("Definition");

                    TextBox txtQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtQty");
                    TextBox txtReceiveQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtReceiveQty");
                    TextBox txtCurrentQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtCurrentQty");
                    TextBox txtfinalQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtfinalQty");
                    Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");

                Label lblbatchno = (Label)gvqueueitems.Rows[i].FindControl("lblbatchno");

                Label lblexpirydate = (Label)gvqueueitems.Rows[i].FindControl("lblexpirydate");

                int productid = objbs.InserTransPackingStock(sCode, PackId, Convert.ToInt32(CategoryUserID.Value), Convert.ToDouble(txtQty.Text),Convert.ToDouble(txtCurrentQty.Text),Convert.ToDouble(txtReceiveQty.Text),Convert.ToDouble(txtfinalQty.Text),lblUserID.Text,lblom.Text,lblbatchno.Text,lblexpirydate.Text);
                }
               Response.Redirect("PackingStockGrid.aspx");
            }
        


    }
}
