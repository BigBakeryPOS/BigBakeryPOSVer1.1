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
//using Microsoft.Office.Interop.Excel;

namespace Billing.Accountsbootstrap
{
    public partial class DirectStoreGoodsTransfer : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        string qtysetting = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();



            if (!IsPostBack)
            {
                // goodsentrytype(sender, e);

                DataSet dacess1 = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "directstorestock");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "directstorestock");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnaddqueue.Visible = true;
                    }
                    else
                    {
                        btnaddqueue.Visible = false;
                    }
                }

                DataSet dDcNo = objbs.getMAXNOformProductionStore(sCode);
                txtTransferNo.Text = dDcNo.Tables[0].Rows[0]["DC_No"].ToString();

                txtTransferDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                DataSet dscategory = objbs.selectcategorymasterforproductionentryStore();
                if (dscategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dscategory;
                    ddlcategory.DataTextField = "IngreCategory";
                    ddlcategory.DataValueField = "IngCatID";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                    ddlrequestno_OnSelectedIndexChanged(sender, e);
                }

                DataSet dsbranch = objbs.getbranchFilling("0");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    ddlBranch.DataSource = dsbranch.Tables[0];
                    ddlBranch.DataTextField = "BranchArea";
                    ddlBranch.DataValueField = "Branchcode";
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, "Select Branch");
                }

            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$('.chzn-select').chosen(); $('.chzn-select-deselect').chosen({ allow_single_deselect: true });", true);
        }

        protected void goodsentrytype(object sender, EventArgs e)
        {
            if (radentrytype.SelectedValue == "1")
            {
                GridView2.Visible = true;
                gvqueueitems.Visible = true;
                ddlrequestno_OnSelectedIndexChanged(sender, e);
            }
            else if (radentrytype.SelectedValue == "2")
            {
                GridView2.Visible = true;
                gvqueueitems.Visible = false;

            }
            else if (radentrytype.SelectedValue == "3")
            {
                ddlrequestno_OnSelectedIndexChanged(sender, e);
                GridView2.Visible = false;
                gvqueueitems.Visible = true;
            }

        }

        protected void gvqueueitems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "plus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");
                txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) + 1).ToString();
            }

            if (e.CommandName == "minus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) - 1).ToString();
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
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);

            dct = new DataColumn("serial");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Rate");
            dttt.Columns.Add(dct);
            dct = new DataColumn("GST");
            dttt.Columns.Add(dct);

            dstd.Tables.Add(dttt);

            for (int i = 0; i < gvqueueitems.Rows.Count; i++)
            {
                HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryID");
                HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                HiddenField hideUOMID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideUOMID");

                HiddenField hdRate = (HiddenField)gvqueueitems.Rows[i].FindControl("hdRate");
                HiddenField hdGST = (HiddenField)gvqueueitems.Rows[i].FindControl("hdGST");

                Label lblCategory = (Label)gvqueueitems.Rows[i].FindControl("lblCategory");
                Label lblDefinition = (Label)gvqueueitems.Rows[i].FindControl("lblDefinition");

                Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");

                Label lblserial = (Label)gvqueueitems.Rows[i].FindControl("lblserial");

                TextBox txtQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtQty");
                if (txtQty.Text == "")
                    txtQty.Text = "0";

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    drNew = dttt.NewRow();
                    drNew["CategoryID"] = hideCategoryID.Value;
                    drNew["CategoryUserID"] = hideCategoryUserID.Value;
                    drNew["UOMID"] = hideUOMID.Value;

                    drNew["Category"] = lblCategory.Text;
                    drNew["Definition"] = lblDefinition.Text;

                    drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                    drNew["UOM"] = lblom.Text;
                    drNew["serial"] = lblserial.Text;

                    drNew["Rate"] = hdRate.Value;
                    drNew["GST"] = hdGST.Value;

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

                        Label lblserial =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblserial");
                        HiddenField hdRate = (HiddenField)gvqueueitems.Rows[i].FindControl("hdRate");
                        HiddenField hdGST = (HiddenField)gvqueueitems.Rows[i].FindControl("hdGST");

                        lblCategory.Text = dt.Rows[i]["Category"].ToString();
                        hideCategoryID.Value = dt.Rows[i]["CategoryID"].ToString();
                        hideCategoryUserID.Value = dt.Rows[i]["CategoryUserID"].ToString();
                        hideUOMID.Value = dt.Rows[i]["UOMID"].ToString();
                        lblDefinition.Text = dt.Rows[i]["Definition"].ToString();

                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        lblom.Text = dt.Rows[i]["UOM"].ToString();
                        lblserial.Text = dt.Rows[i]["serial"].ToString();

                        hdRate.Value = dt.Rows[i]["Rate"].ToString();
                        hdGST.Value = dt.Rows[i]["GST"].ToString();

                        //  drNew["Rate"] = hdRate.Value;
                        // drNew["GST"] = hdGST.Value;

                        rowIndex++;

                    }
                }
            }
        }


        protected void serach_text(object sender, EventArgs e)
        {

            if (txtserch.Text == "")
            {
                searchitemlist_OnClick(Server, e);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Valid Category.Thank You!!!');", true);
                //return;
                DataSet dsitems = objbs.itemforreqestNew_DirectTransfer((ddlcategory.SelectedValue), sTableName, lblcatid.Text);
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

                txtserch.Focus();
            }
            else
            {

                searchitemlist_OnClick(Server, e);

                DataSet dsitems = objbs.itemforreqestNew_DirectTransfer_search((ddlcategory.SelectedValue), sTableName, txtserch.Text);
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
                txtserch.Focus();
            }
            txtserch.Focus();
        }
        protected void ddlrequestno_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvRawRequest.DataSource = null;
            gvRawRequest.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();

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

            if (ddlcategory.SelectedValue == "Select Category")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Valid Category.Thank You!!!');", true);
                return;
            }
            else
            {

                DataSet dsitems = objbs.itemforreqestNew_DirectTransferStore((ddlcategory.SelectedValue), sTableName, lblcatid.Text);
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

        protected void searchitemlist_OnClick(object sender, EventArgs e)
        {

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
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);

            dct = new DataColumn("serial");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Rate");
            dttt.Columns.Add(dct);
            dct = new DataColumn("GST");
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

                    HiddenField hdRate = (HiddenField)gvitems.Rows[i].FindControl("hdRate");
                    HiddenField hdGST = (HiddenField)gvitems.Rows[i].FindControl("hdGST");

                    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");

                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");
                    Label lblserial = (Label)gvitems.Rows[i].FindControl("lblserial");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Rate"] = hdRate.Value;
                        drNew["GST"] = hdGST.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;

                        drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                        drNew["UOM"] = lblom.Text;
                        drNew["serial"] = lblserial.Text;

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

                    HiddenField hdRate = (HiddenField)gvitems.Rows[i].FindControl("hdRate");
                    HiddenField hdGST = (HiddenField)gvitems.Rows[i].FindControl("hdGST");

                    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");

                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");
                    Label lblserial = (Label)gvitems.Rows[i].FindControl("lblserial");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");
                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Rate"] = hdRate.Value;
                        drNew["GST"] = hdGST.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;

                        drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                        drNew["UOM"] = lblom.Text;
                        drNew["serial"] = lblserial.Text;

                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];

                    }

                }

                ViewState["CurrentTable1"] = dtddd;
            }


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
            dtraw.Columns.Add("UOM");

            dtraw.Columns.Add("serial");

            dtraw.Columns.Add("Rate");
            dtraw.Columns.Add("GST");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], UOM = r["UOM"], Rate = r["Rate"], GST = r["GST"], serial = r["serial"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  UOM = raw.Key.UOM,
                                  serial = raw.Key.serial,
                                  Rate = raw.Key.Rate,
                                  GST = raw.Key.GST,

                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Definition"] = g.Definition;

                    drraw["Qty"] = Convert.ToDouble(g.Qty).ToString("" + qtysetting + "");
                    drraw["UOM"] = g.UOM;
                    drraw["serial"] = g.serial;

                    drraw["Rate"] = g.Rate;
                    drraw["GST"] = g.GST;

                    dsraw.Tables[0].Rows.Add(drraw);
                }
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                #endregion
            }


            #endregion
        }

        protected void btnaddqueue_OnClick(object sender, EventArgs e)
        {

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
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);

            dct = new DataColumn("serial");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Rate");
            dttt.Columns.Add(dct);
            dct = new DataColumn("GST");
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

                    HiddenField hdRate = (HiddenField)gvitems.Rows[i].FindControl("hdRate");
                    HiddenField hdGST = (HiddenField)gvitems.Rows[i].FindControl("hdGST");

                    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");

                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    Label lblserial = (Label)gvitems.Rows[i].FindControl("lblserial");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Rate"] = hdRate.Value;
                        drNew["GST"] = hdGST.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;

                        drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                        drNew["UOM"] = lblom.Text;

                        drNew["serial"] = lblserial.Text;

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

                    HiddenField hdRate = (HiddenField)gvitems.Rows[i].FindControl("hdRate");
                    HiddenField hdGST = (HiddenField)gvitems.Rows[i].FindControl("hdGST");

                    Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");

                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    Label lblserial = (Label)gvitems.Rows[i].FindControl("lblserial");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");
                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Rate"] = hdRate.Value;
                        drNew["GST"] = hdGST.Value;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;

                        drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                        drNew["UOM"] = lblom.Text;

                        drNew["serial"] = lblserial.Text;

                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];

                    }

                }

                ViewState["CurrentTable1"] = dtddd;
            }


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
            dtraw.Columns.Add("UOM");

            dtraw.Columns.Add("serial");

            dtraw.Columns.Add("Rate");
            dtraw.Columns.Add("GST");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], UOM = r["UOM"], Rate = r["Rate"], GST = r["GST"], serial = r["serial"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  UOM = raw.Key.UOM,
                                  serial = raw.Key.serial,
                                  Rate = raw.Key.Rate,
                                  GST = raw.Key.GST,

                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Definition"] = g.Definition;

                    drraw["Qty"] = Convert.ToDouble(g.Qty).ToString("" + qtysetting + "");
                    drraw["UOM"] = g.UOM;
                    drraw["serial"] = g.serial;

                    drraw["Rate"] = g.Rate;
                    drraw["GST"] = g.GST;

                    dsraw.Tables[0].Rows.Add(drraw);
                }
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                #endregion
            }


            #endregion



            gvitems.DataSource = null;
            gvitems.DataBind();
            //ddlrequestno_OnSelectedIndexChanged(sender, e);

        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {

            if (ddlBranch.SelectedValue == "" || ddlBranch.SelectedValue == "" || ddlBranch.SelectedValue == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Branch Branch.');", true);
                return;
            }

            int cnt = gvqueueitems.Rows.Count;
            if (cnt == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Add Item in Item Queue.Thank You!!!');", true);
                return;
            }


            for (int vLoop = 0; vLoop < gvqueueitems.Rows.Count; vLoop++)
            {
                #region
                HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryUserID");
                Label lblDefinition = (Label)gvqueueitems.Rows[vLoop].FindControl("lblDefinition");
                TextBox txtQty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtQty");

                if (txtQty.Text == "")
                    txtQty.Text = "0";

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    DataSet ds = objbs.CheckDirectGoodTrasnferstore(sCode, Convert.ToInt32(hideCategoryUserID.Value), Convert.ToDouble(txtQty.Text));
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check Qty in  Item " + lblDefinition.Text + "');", true);
                        return;
                    }

                }

                #endregion
            }

            //string sDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            //DateTime Date = Convert.ToDateTime(sDate);
            txtTransferDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

            DateTime Date = DateTime.ParseExact(txtTransferDate.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);

            int DC_No = objbs.InsertDirectGoodTrasnferStore(sCode, ddlBranch.SelectedValue, Date, txtEntryBy.Text, lblUserID.Text);

            for (int vLoop = 0; vLoop < gvqueueitems.Rows.Count; vLoop++)
            {
                #region

                HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryID");
                HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hideCategoryUserID");

                HiddenField hdRate = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hdRate");
                HiddenField hdGST = (HiddenField)gvqueueitems.Rows[vLoop].FindControl("hdGST");

                TextBox txtQty = (TextBox)gvqueueitems.Rows[vLoop].FindControl("txtQty");

                if (txtQty.Text == "")
                    txtQty.Text = "0";

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    int MainRequestID = objbs.InsertDirectTransGoodTrasnferstore(sCode, DC_No, ddlBranch.SelectedValue, Convert.ToInt32(hideCategoryID.Value), Convert.ToInt32(hideCategoryUserID.Value), Convert.ToDouble(txtQty.Text), Convert.ToDouble(hdRate.Value), Convert.ToDouble(hdGST.Value));
                }

                #endregion
            }

            Response.Redirect("DirectstoreGoodsTransferGrid.aspx");

        }

        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {




            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //TextBox txtQty = ((TextBox)e.Row.FindControl("txtQty"));
                Label lbqty = ((Label)e.Row.FindControl("lbqty"));
                lbqty.Text = Convert.ToDouble(lbqty.Text).ToString("" + qtysetting + "");
                //lblreceived_Qty.Text = Convert.ToDouble(lblreceived_Qty.Text).ToString("" + qtysetting + "");

            }
        }

        protected void search_barcode(object sender, EventArgs e)
        {

            if (txtbarcode.Text == "")
            {
                searchitemlist_OnClick(Server, e);

                DataSet dsitems = objbs.itemforreqestNew_DirectTransferStore((ddlcategory.SelectedValue), sTableName, lblcatid.Text);
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

                txtserch.Focus();
            }
            else
            {

                searchitemlist_OnClick(Server, e);

                DataSet dsitems = objbs.itemforreqestNew_DirectTransfer_Barcodesearchstore((ddlcategory.SelectedValue), sTableName, txtbarcode.Text);
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
                txtserch.Focus();
            }
            txtserch.Focus();
        }

    }
}
