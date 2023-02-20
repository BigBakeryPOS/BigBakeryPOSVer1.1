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
using System.Net.Mail;
using System.Globalization;



namespace Billing.Accountsbootstrap
{
    public partial class BulkStockEntry : System.Web.UI.Page
    {


        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCodeProd = "";
        string sCodeBnch = "";
        string empid = "";
        //string ratesetting = "";
        string qtysetting = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            empid = Request.Cookies["userInfo"]["Empid"].ToString();

            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();


            if (!IsPostBack)
            {
                DataSet dsCategory = objbs.selectcategorymasterForGRN();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "Printcategory";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                    ddlcategory_SelectedIndexChanged(sender, e);

                }

                txtOrderBy.Text = Request.Cookies["userInfo"]["Biller"].ToString();

                lblentrydatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                DataSet dss = objbs.checkrequestallowornot(sTableName);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                DataSet dReqNo = objbs.ReqNo(Convert.ToInt32(lblUserID.Text), sCodeBnch);

                txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();
                txtpodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "$(document).ready(function() { $('#drpitemsearch').select2(); });", true);
        }

        protected void radbtn_clicked(object sender, EventArgs e)
        {

            if (radbtntype.SelectedValue == "1")
            {
                DataSet dscategory = objbs.selectcategorymasterForGRN();
                if (dscategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dscategory;
                    ddlcategory.DataTextField = "Printcategory";
                    ddlcategory.DataValueField = "Categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                    ddlrequestno_OnSelectedIndexChanged(sender, e);
                }
            }
            else if (radbtntype.SelectedValue == "2")
            {
                ddlrequestno_OnSelectedIndexChanged(sender, e);
                txtCusName1.Focus();
            }
            else if (radbtntype.SelectedValue == "3")
            {
                ddlrequestno_OnSelectedIndexChanged(sender, e);
                txtCusName1.Focus();
            }



        }

        protected void ddlrequestno_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            gvitems.Visible = true;
            posdropdown.Visible = false;
            upcus.Visible = false;
            drpitemsearch.Visible = false; ;
            sno.Visible = false;

            if (radbtntype.SelectedValue == "1")
            {

                int catid = 0;

                if (ddlcategory.SelectedValue == "All")
                {
                    catid = 0;
                }
                else
                {

                    catid = Convert.ToInt32(ddlcategory.SelectedValue);
                }

                DataSet dsitems = objbs.itemforreqest(catid, sTableName, "BLK");
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
            else if (radbtntype.SelectedValue == "2")
            {
                gvitems.DataSource = null;
                gvitems.DataBind();
                gvitems.Visible = false;
                posdropdown.Visible = true;
                upcus.Visible = true;
                drpitemsearch.Visible = false; ;
                drpitemsearch.ClearSelection();
                drpitemsearch.Items.Clear();
                sno.Visible = false;

            }
            else if (radbtntype.SelectedValue == "3")
            {
                upcus.Visible = false;
                gvitems.DataSource = null;
                gvitems.DataBind();
                gvitems.Visible = false;
                posdropdown.Visible = true;
                drpitemsearch.Visible = true;
                sno.Visible = true;
                int catid = 0;

                // bind itemname from dropdown
                DataSet getallitembind = objbs.itemforreqest(catid, sTableName, "BLK");
                if (getallitembind.Tables[0].Rows.Count > 0)
                {
                    drpitemsearch.DataSource = getallitembind.Tables[0];
                    drpitemsearch.DataTextField = "defi";
                    drpitemsearch.DataValueField = "categoryuserid";
                    drpitemsearch.DataBind();
                    drpitemsearch.Items.Insert(0, "Select Item");

                }

                txtmanualslno.Focus();
                UpdatePanel1.Update();
            }



        }


        protected void serach_text(object sender, EventArgs e)
        {

            if (txtserch.Text == "")
            {
                int catid = 0;

                if (ddlcategory.SelectedValue == "All")
                {
                    catid = 0;
                }
                else
                {

                    catid = Convert.ToInt32(ddlcategory.SelectedValue);
                }

                DataSet dsitems = objbs.itemforreqest(catid, sTableName, "BLK");
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
            else
            {

                //  searchitemlist_OnClick(Server, e);

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

        protected void search_barcode(object sender, EventArgs e)
        {

            if (txtbarcode.Text == "")
            {
                // searchitemlist_OnClick(Server, e);

                int catid = 0;

                if (ddlcategory.SelectedValue == "All")
                {
                    catid = 0;
                }
                else
                {

                    catid = Convert.ToInt32(ddlcategory.SelectedValue);
                }

                DataSet dsitems = objbs.itemforreqest(catid, sTableName, "BLK");
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
            else
            {

                // searchitemlist_OnClick(Server, e);

                DataSet dsitems = objbs.itemforreqestNew_DirectTransfer_Barcodesearch((ddlcategory.SelectedValue), sTableName, txtbarcode.Text);
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
            //  UpdatePanel1.Update();
            // upcus.Update();
        }

        protected void txtqty_changed(object sender, EventArgs e)
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
            dct = new DataColumn("Available_Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Barcode");
            dttt.Columns.Add(dct);

            dstd.Tables.Add(dttt);


            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];

                // for (int i = 0; i < gvitems.Rows.Count; i++)
                {
                    //HiddenField hideCategoryID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryID");
                    //HiddenField hideCategoryUserID = (HiddenField)gvitems.Rows[i].FindControl("hideCategoryUserID");
                    //HiddenField hideUOMID = (HiddenField)gvitems.Rows[i].FindControl("hideUOMID");

                    //HiddenField hdRate = (HiddenField)gvitems.Rows[i].FindControl("hdRate");
                    //HiddenField hdGST = (HiddenField)gvitems.Rows[i].FindControl("hdGST");

                    //Label lblCategory = (Label)gvitems.Rows[i].FindControl("lblCategory");
                    //Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");

                    //Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    //TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                    if (txtqty.Text == "")
                        txtqty.Text = "0";

                    if (Convert.ToDouble(txtqty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = NhideCategoryID.Value;
                        drNew["CategoryUserID"] = NhideCategoryUserID.Value;
                        drNew["UOMID"] = NhideUOMID.Value;

                        //  drNew["Rate"] = NhdRate.Value;
                        drNew["Available_Qty"] = Nlbqty.Text;

                        drNew["Category"] = NlblCategory.Text;
                        drNew["Definition"] = NlblDefinition.Text;

                        drNew["Qty"] = txtqty.Text;
                        drNew["UOM"] = Nlblom.Text;
                        drNew["Barcode"] = Nlblbarcode.Text;

                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];


                    }
                }

                dtddd.Merge(dt);
                ViewState["CurrentTable1"] = dtddd;
            }
            else
            {
                //  for (int i = 0; i < gvitems.Rows.Count; i++)
                {
                    if (txtqty.Text == "")
                        txtqty.Text = "0";

                    if (Convert.ToDouble(txtqty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = NhideCategoryID.Value;
                        drNew["CategoryUserID"] = NhideCategoryUserID.Value;
                        drNew["UOMID"] = NhideUOMID.Value;

                        //  drNew["Rate"] = NhdRate.Value;
                        drNew["Available_Qty"] = Nlbqty.Text;

                        drNew["Category"] = NlblCategory.Text;
                        drNew["Definition"] = NlblDefinition.Text;

                        drNew["Qty"] = txtqty.Text;
                        drNew["UOM"] = Nlblom.Text;
                        drNew["Barcode"] = Nlblbarcode.Text;

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
            dtraw.Columns.Add("Barcode");
            dtraw.Columns.Add("Available_Qty");
            dtraw.Columns.Add("Qty");
            dtraw.Columns.Add("UOM");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], Available_Qty = r["Available_Qty"], UOM = r["UOM"], Barcode = r["Barcode"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Barcode = raw.Key.Barcode,
                                  Available_Qty = raw.Key.Available_Qty,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  UOM = raw.Key.UOM,
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Barcode"] = g.Barcode;
                    drraw["Definition"] = g.Definition;
                    drraw["Available_Qty"] = Convert.ToDouble(g.Available_Qty).ToString("" + qtysetting + "");
                    drraw["Qty"] = Convert.ToDouble(g.Qty).ToString("" + qtysetting + "");
                    drraw["UOM"] = g.UOM;

                    dsraw.Tables[0].Rows.Add(drraw);
                }
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                #endregion
            }


            #endregion


            gvitems.DataSource = null;
            gvitems.DataBind();

            // ddlcategory_SelectedIndexChanged(sender, e);
            // TextBox10.Text = "";

            txtqty.Text = "";
            drpitemsearch.Focus();
             UpdatePanel1.Update();
            upcus.Update();

        }

        protected void item_click(object sender, EventArgs e)
        {
            if (drpitemsearch.SelectedValue == "Select Item")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Item.Thank You!!!');", true);
                return;
            }
            else
            {
                DataSet ds = objbs.getitembyid(drpitemsearch.SelectedValue, sTableName);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    NhideCategoryID.Value = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                    NhideCategoryUserID.Value = ds.Tables[0].Rows[0]["CategoryUserID"].ToString();
                    NhideUOMID.Value = ds.Tables[0].Rows[0]["UOMID"].ToString();
                    NhdRate.Value = ds.Tables[0].Rows[0]["Rate"].ToString();
                    NhdGST.Value = ds.Tables[0].Rows[0]["GST"].ToString();

                    NlblCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    NlblDefinition.Text = ds.Tables[0].Rows[0]["Definition"].ToString();
                    Nlblrate.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                    Nlbqty.Text = ds.Tables[0].Rows[0]["Available_qty"].ToString();
                    Nlblom.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                    Nlblbarcode.Text = ds.Tables[0].Rows[0]["barcode"].ToString();
                    txtqty.Focus();
                }
                else
                {
                    NhideCategoryID.Value = "0";
                    NhideCategoryUserID.Value = "0";
                    NhideUOMID.Value = "0";
                    NhdRate.Value = "0";
                    NhdGST.Value = "0";

                    NlblCategory.Text = "0";
                    NlblDefinition.Text = "0";
                    Nlblrate.Text = "0";
                    Nlbqty.Text = "0";
                    Nlblom.Text = "0";
                    txtqty.Text = "0";
                    Nlblbarcode.Text = "0";
                    //txtCusName1.Text = "";
                }

            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            int catid = 0;

            if (ddlcategory.SelectedValue == "All")
            {
                catid = 0;
            }
            else
            {

                catid = Convert.ToInt32(ddlcategory.SelectedValue);
            }

            DataSet dsitems = objbs.itemforreqest(catid, sTableName,"BLK");
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

        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {


           

             if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblAvailable_Qty = ((Label)e.Row.FindControl("lblAvailable_Qty"));
                

                lblAvailable_Qty.Text = Convert.ToDouble(lblAvailable_Qty.Text).ToString("" + qtysetting + "");

            }
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
            dct = new DataColumn("Available_Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Barcode");
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
                    Label lblbarcode = (Label)gvitems.Rows[i].FindControl("lblbarcode");
                    Label lblDefinition = (Label)gvitems.Rows[i].FindControl("lblDefinition");
                    Label lblAvailable_Qty = (Label)gvitems.Rows[i].FindControl("lblAvailable_Qty");
                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;

                        drNew["Barcode"] = lblbarcode.Text;

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;
                        drNew["Available_Qty"] = Convert.ToDouble(lblAvailable_Qty.Text).ToString(""+qtysetting+"");
                        drNew["Qty"] =  Convert.ToDouble(txtQty.Text).ToString(""+qtysetting+"");
                        drNew["UOM"] = lblom.Text;

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

                    Label lblbarcode = (Label)gvitems.Rows[i].FindControl("lblbarcode");

                    Label lblAvailable_Qty = (Label)gvitems.Rows[i].FindControl("lblAvailable_Qty");
                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");
                    if (txtQty.Text == "")
                        txtQty.Text = "0";

                    if (Convert.ToDouble(txtQty.Text) > 0)
                    {
                        drNew = dttt.NewRow();
                        drNew["CategoryID"] = hideCategoryID.Value;
                        drNew["CategoryUserID"] = hideCategoryUserID.Value;
                        drNew["UOMID"] = hideUOMID.Value;
                        drNew["Barcode"] = lblbarcode.Text;
                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;
                        drNew["Available_Qty"] = Convert.ToDouble(lblAvailable_Qty.Text).ToString(""+qtysetting+"");
                        drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString(""+qtysetting+"");
                        drNew["UOM"] = lblom.Text;

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
            dtraw.Columns.Add("Barcode");
            dtraw.Columns.Add("Available_Qty");
            dtraw.Columns.Add("Qty");
            dtraw.Columns.Add("UOM");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], Available_Qty = r["Available_Qty"], UOM = r["UOM"], Barcode = r["Barcode"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Barcode = raw.Key.Barcode,
                                  Available_Qty = raw.Key.Available_Qty,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  UOM = raw.Key.UOM,
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Barcode"] = g.Barcode;
                    drraw["Definition"] = g.Definition;
                    drraw["Available_Qty"] = Convert.ToDouble(g.Available_Qty).ToString(""+qtysetting+"");
                    drraw["Qty"] = Convert.ToDouble(g.Qty).ToString(""+qtysetting+"");
                    drraw["UOM"] = g.UOM;

                    dsraw.Tables[0].Rows.Add(drraw);
                }
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                #endregion
            }


            #endregion


            gvitems.DataSource = null;
            gvitems.DataBind();

            ddlcategory_SelectedIndexChanged(sender, e);
            TextBox10.Text = "";

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {


            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }


            DataSet checkdayclose = objbs.checkinser_Previousday(sTableName);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any GRN.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            #region

            //////DataSet dss = objbs.checkrequestallowornot(sTableName);
            //////if (dss.Tables[0].Rows.Count > 0)
            //////{
            //////    sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
            //////    sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
            //////}
            //////else
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
            //////    return;
            //////}

            ////////Checking Local DB

            //////DataSet checktable = objbs.checktableexisitsornot("tblPurchaseRequest_" + sCodeBnch + "");
            //////if (checktable.Tables[0].Rows.Count > 0)
            //////{
            //////}
            //////else
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
            //////    return;
            //////}

            //////DataSet checktranstable = objbs.checktableexisitsornot("tblTransPurchaseRequest_" + sCodeBnch + "");
            //////if (checktranstable.Tables[0].Rows.Count > 0)
            //////{
            //////}
            //////else
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
            //////    return;
            //////}

            ////////Checking LIVE DB

            //////DataSet livechecktable = objbs.checktableexisitsornotlive("tblPurchaseRequestProd_" + sCodeProd + "");
            //////if (livechecktable.Tables[0].Rows.Count > 0)
            //////{
            //////}
            //////else
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
            //////    return;
            //////}

            //////DataSet livechecktranstable = objbs.checktableexisitsornotlive("tblTransPurchaseRequestProd_" + sCodeProd + "");
            //////if (livechecktranstable.Tables[0].Rows.Count > 0)
            //////{
            //////}
            //////else
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
            //////    return;
            //////}

            //////if (gvqueueitems.Rows.Count == null || gvqueueitems.Rows.Count == 0)
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Items And Keep in queue.Thank You!!!.');", true);
            //////    return;

            //////}
            //////#endregion




            //////string requestentrytime = System.DateTime.Now.ToString("hh:mm tt");

            DateTime sDate = DateTime.ParseExact(txtpodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //////DateTime entrytime = DateTime.ParseExact(lblentrydatetime.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);


            //////if (txtOrderBy.Text == "")
            //////{
            //////    ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('Enter OrderBy');", true);
            //////    return;
            //////}
            //////if (txtOrderBy.Text == "")
            //////    txtOrderBy.Text = "No Name";


            #endregion

            if (txtOrderBy.Text.Trim() != "")
            {

                DataSet dReqNo = objbs.GRNNONew();
                txtpono.Text = dReqNo.Tables[0].Rows[0]["GRNNO"].ToString();

               
                #region Geautex
                for (int i = 0; i < gvqueueitems.Rows.Count; i++)
                {

                    HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryID");
                    HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                    HiddenField hideUOMID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideUOMID");

                    Label lblCategory = (Label)gvqueueitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvqueueitems.Rows[i].FindControl("lblDefinition");
                    Label lblAvailable_Qty = (Label)gvqueueitems.Rows[i].FindControl("lblAvailable_Qty");
                    Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");

                    //  TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");



                    int iCatID = Convert.ToInt32(hideCategoryID.Value);
                    int iSubCatID = Convert.ToInt32(hideCategoryUserID.Value);

                    TextBox tt = (TextBox)gvqueueitems.Rows[i].FindControl("txtQty");
                    if (tt.Text == "")
                        tt.Text = "0";
                    decimal dTextBox = Convert.ToDecimal(tt.Text);
                    // DropDownList dd = (DropDownList)gvqueueitems.Rows[i].FindControl("ddUnits");
                    string sUnits = lblom.Text;

                    if (tt.Text != "0")
                    {
                       ////// int iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID);

                    }




                    decimal dQty = 0; decimal dAvbQty = 0;
                    DataSet dsStock = objbs.GetStockAvailable(Convert.ToInt32(iSubCatID), sTableName);
                    if (dsStock.Tables[0].Rows.Count > 0)
                    {
                        int stockid = Convert.ToInt32(dsStock.Tables[0].Rows[0]["stockid"].ToString());
                        dQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Quantity"].ToString());
                        dAvbQty = Convert.ToDecimal(dsStock.Tables[0].Rows[0]["Available_Qty"].ToString());

                        dQty = dQty + Convert.ToDecimal(tt.Text);
                        dAvbQty = dAvbQty + Convert.ToDecimal(tt.Text);

                        int iSuccess = objbs.updatePrintstockdet1(Convert.ToInt32(iCatID), Convert.ToInt32(iSubCatID), Convert.ToDouble(dAvbQty), sTableName, Convert.ToDecimal(tt.Text), Convert.ToInt32(lblUserID.Text), stockid, Convert.ToInt32(txtpono.Text), txtOrderBy.Text);

                    }
                    else
                    {

                        int iSuccess = objbs.StockOnly(sTableName, Convert.ToInt32(lblUserID.Text), Convert.ToInt32(iCatID), Convert.ToInt32(iSubCatID), Convert.ToDouble(tt.Text), Convert.ToDouble(tt.Text), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToDouble(0), Convert.ToString(DateTime.Now.ToString("MM/dd/yyyy")), 1, Convert.ToInt32(txtpono.Text), txtOrderBy.Text);

                    }


                }
                #endregion


                #region SendMail
                //string aaa = DateTime.Now.ToString("dd/MM/yyyy");
                //DataSet ds = objbs.RequestDetqqqorg(txtpono.Text, sCode, aaa);
                //gvUserInfo.DataSource = ds;
                //gvUserInfo.DataBind();

                //SendHTMLMail();
                #endregion

                Response.Redirect("Stock.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Employee Name.Thank You!!!.');", true);
                return;
            }

        }


        #region SendMail Attachment

        public void SendHTMLMail()
        {
            MailMessage Msg = new MailMessage();
            MailAddress fromMail = new MailAddress("bigdbiz@gmail.com");//("administrator@aspdotnet-suresh.com");
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress("rajar@bigdbiz.in"));
            // Subject of e-mail
            Msg.Subject = "Send Gridivew in EMail";
            Msg.Body += "Please check below data <br/><br/>";

            Msg.Body += "Request From <br/><br/>";
            Msg.Body += "Request No  below data <br/><br/>";
            Msg.Body += "Request Date <br/><br/>";
            Msg.Body += "Request Entry <br/><br/>";

            Msg.Body += GetGridviewData(gvUserInfo);
            Msg.IsBodyHtml = true;
            //////string sSmtpServer = "";
            //////sSmtpServer = "587";
            //////SmtpClient a = new SmtpClient();
            //////a.Host = sSmtpServer;
            //////a.EnableSsl = true;
            //////a.Send(Msg);


            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }
        // This Method is used to render gridview control
        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        #endregion


        protected void gvqueueitems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "plus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");
                txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) + 1).ToString(""+qtysetting+"");
            }

            if (e.CommandName == "minus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) - 1).ToString(""+qtysetting+"");
                }
                else
                {
                    txtQty.Text = "0.00";
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
            dct = new DataColumn("Barcode");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Definition");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Available_Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);
            dstd.Tables.Add(dttt);

            for (int i = 0; i < gvqueueitems.Rows.Count; i++)
            {
                HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryID");
                HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                HiddenField hideUOMID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideUOMID");

                Label lblCategory = (Label)gvqueueitems.Rows[i].FindControl("lblCategory");
                Label lblbarcode = (Label)gvqueueitems.Rows[i].FindControl("lblBarcode");
                Label lblDefinition = (Label)gvqueueitems.Rows[i].FindControl("lblDefinition");
                Label lblAvailable_Qty = (Label)gvqueueitems.Rows[i].FindControl("lblAvailable_Qty");
                Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");

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
                    drNew["Barcode"] = lblbarcode.Text;
                    drNew["Definition"] = lblDefinition.Text;
                    drNew["Available_Qty"] = Convert.ToDouble(lblAvailable_Qty.Text).ToString(""+qtysetting+"");
                    drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString(""+qtysetting+"");
                    drNew["UOM"] = lblom.Text;

                    dstd.Tables[0].Rows.Add(drNew);
                    dtddd = dstd.Tables[0];
                }
            }

            ViewState["CurrentTable1"] = dtddd;
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stock.aspx");

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
                        Label lblbarcode =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblbarcode");
                        HiddenField hideUOMID =
                          (HiddenField)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("hideUOMID");

                        Label lblDefinition =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblDefinition");
                        Label lblAvailable_Qty =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblAvailable_Qty");

                        TextBox txtQty =
                          (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                        Label lblom =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblom");

                        lblCategory.Text = dt.Rows[i]["Category"].ToString();
                        hideCategoryID.Value = dt.Rows[i]["CategoryID"].ToString();
                        hideCategoryUserID.Value = dt.Rows[i]["CategoryUserID"].ToString();
                        hideUOMID.Value = dt.Rows[i]["UOMID"].ToString();
                        lblbarcode.Text = dt.Rows[i]["Barcode"].ToString();
                        lblDefinition.Text = dt.Rows[i]["Definition"].ToString();
                        lblAvailable_Qty.Text = Convert.ToDouble(dt.Rows[i]["Available_Qty"]).ToString(""+qtysetting+"");
                        txtQty.Text = Convert.ToDouble(dt.Rows[i]["Qty"]).ToString(""+qtysetting+"");
                        lblom.Text = dt.Rows[i]["UOM"].ToString();

                        rowIndex++;

                    }
                }
            }
        }
    }
}