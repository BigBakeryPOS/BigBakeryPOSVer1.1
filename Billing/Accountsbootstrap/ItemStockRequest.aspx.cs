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
    public partial class ItemStockRequest : System.Web.UI.Page
    {


        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCodeProd = "";
        string sCodeIcing = "";
        string sCodeBnch = "";
        string empid = "";
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


                //txtOrderBy.Text = Session["Biller"].ToString();

                lblentrydatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                DataSet dss = objbs.checkrequestallowornot(sTableName);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    sCodeIcing = dss.Tables[0].Rows[0]["IcingCode"].ToString();

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

                if (sCodeIcing == sCodeProd)
                {
                    DataSet dproducttypeload = objbs.GetProducttype();
                    if (dproducttypeload.Tables[0].Rows.Count > 0)
                    {
                        drpproductiontype.DataSource = dproducttypeload.Tables[0];
                        drpproductiontype.DataTextField = "productiontype";
                        drpproductiontype.DataValueField = "productiontype";
                        drpproductiontype.DataBind();
                        drpproductiontype.Items.Insert(0, "All");
                        drpproductiontype.Enabled = false;
                    }

                }
                else
                {
                    DataSet dproducttypeload = objbs.GetProducttype();
                    if (dproducttypeload.Tables[0].Rows.Count > 0)
                    {
                        drpproductiontype.DataSource = dproducttypeload.Tables[0];
                        drpproductiontype.DataTextField = "productiontype";
                        drpproductiontype.DataValueField = "productiontype";
                        drpproductiontype.DataBind();
                        drpproductiontype.Enabled = true;
                        // drpproductiontype.Items.Insert(0, "Select ProductionType");
                    }
                }

                DataSet dsCategory = objbs.selectcategorymasterforitemrequest_New(drpproductiontype.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "Printcategory";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                    ddlcategory_SelectedIndexChanged(sender, e);

                }
                else
                {

                    ddlcategory.Items.Insert(0, "No Category");
                }


            }
        }


        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {




            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblAvailable_Qty = ((Label)e.Row.FindControl("lblAvailable_Qty"));
                Label lblqtytype = (Label)e.Row.FindControl("lblqtytype");
                if(lblqtytype.Text=="E")
                {
                    lblAvailable_Qty.Text = Convert.ToInt32(lblAvailable_Qty.Text).ToString();
                }
               else if(lblqtytype.Text=="D")
                {
                    lblAvailable_Qty.Text = Convert.ToDouble(lblAvailable_Qty.Text).ToString("" + qtysetting + "");
                }

            }
        }

        protected void Producttype_chnaged(object sender, EventArgs e)
        {
            gvqueueitems.DataSource = null;
            gvqueueitems.DataBind();

            gvUserInfo.DataSource = null;
            gvUserInfo.DataBind();

            DataSet dsCategory = objbs.selectcategorymasterforitemrequest_New(drpproductiontype.SelectedValue);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                ddlcategory.DataSource = dsCategory.Tables[0];
                ddlcategory.DataTextField = "Printcategory";
                ddlcategory.DataValueField = "categoryid";
                ddlcategory.DataBind();
                ddlcategory.Items.Insert(0, "All");
                ddlcategory_SelectedIndexChanged(sender, e);

            }
            else
            {

                ddlcategory.Items.Insert(0, "No Category");
            }



            int catid = 0;

            if (ddlcategory.SelectedValue == "All")
            {
                catid = 0;
            }
            else if (ddlcategory.SelectedValue == "No Category")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('No Category Found');", true);
                return;

            }
            else
            {

                catid = Convert.ToInt32(ddlcategory.SelectedValue);
            }

            DataSet dsitems = objbs.itemforreqest_New(catid, sTableName, "REQ", drpproductiontype.SelectedValue);
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

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {



            //int catid = 0;

            //if (ddlcategory.SelectedValue == "All")
            //{
            //    catid = 0;
            //}
            //else
            //{

            //    catid = Convert.ToInt32(ddlcategory.SelectedValue);
            //}



            //DataSet dsitems = objbs.itemforreqest(catid, sTableName, "REQ");
            //if (dsitems.Tables[0].Rows.Count > 0)
            //{
            //    gvitems.DataSource = dsitems;
            //    gvitems.DataBind();

            //}
            //else
            //{
            //    gvitems.DataSource = null;
            //    gvitems.DataBind();
            //}

            int catid = 0;

            if (ddlcategory.SelectedValue == "All")
            {
                catid = 0;
            }
            else if (ddlcategory.SelectedValue == "No Category")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('No Category Found');", true);
                return;

            }
            else
            {

                catid = Convert.ToInt32(ddlcategory.SelectedValue);
            }

            DataSet dsitems = objbs.itemforreqest_New(catid, sTableName, "REQ", drpproductiontype.SelectedValue);
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

            dct = new DataColumn("Delaydays");
            dttt.Columns.Add(dct);
            dct = new DataColumn("qtytype");
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
                    Label lblAvailable_Qty = (Label)gvitems.Rows[i].FindControl("lblAvailable_Qty");
                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");

                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");

                    Label lbldelaydays = (Label)gvitems.Rows[i].FindControl("lbldelaydays");
                    Label lblqtytype = (Label)gvitems.Rows[i].FindControl("lblqtytype");

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
                        if (lblqtytype.Text == "E")
                        {
                            drNew["Available_Qty"] = Convert.ToInt32(lblAvailable_Qty.Text).ToString();
                            drNew["Qty"] = Convert.ToInt32(txtQty.Text).ToString();

                        }
                        else if(lblqtytype.Text=="D")
                        {
                            drNew["Available_Qty"] = Convert.ToDouble(lblAvailable_Qty.Text).ToString("" + qtysetting + "");
                            drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");
                        }
                        
                        drNew["UOM"] = lblom.Text;
                        drNew["delaydays"] = lbldelaydays.Text;
                        drNew["qtytype"] = lblqtytype.Text;

                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];


                    }
                }

               
                

                dtddd.Merge(dt);

                //for newly added  entries checking
                bool exists = false;
                for (int i = 0; i < dtddd.Rows.Count; i++)
                {
                    for (int j = i + 1; j < dtddd.Rows.Count; j++)
                    {
                        if (dtddd.Rows[j]["delaydays"].ToString() != dtddd.Rows[i]["delaydays"].ToString())
                        { exists = true; break; }
                    }
                }
                if (exists == true)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Different Delay days stock requests are not possible!!');", true);
                    return;
                }


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
                    Label lblAvailable_Qty = (Label)gvitems.Rows[i].FindControl("lblAvailable_Qty");
                    Label lblom = (Label)gvitems.Rows[i].FindControl("lblom");
                    Label lbldelaydays = (Label)gvitems.Rows[i].FindControl("lbldelaydays");
                    Label lblqtytype = (Label)gvitems.Rows[i].FindControl("lblqtytype");
                    TextBox txtQty = (TextBox)gvitems.Rows[i].FindControl("txtQty");
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
                        if(lblqtytype.Text=="E")
                        {
                            drNew["Available_Qty"] = Convert.ToInt32(lblAvailable_Qty.Text).ToString();
                            drNew["Qty"] = Convert.ToInt32(txtQty.Text).ToString();
                        }
                        else if(lblqtytype.Text=="D")
                        {
                            drNew["Available_Qty"] = Convert.ToDouble(lblAvailable_Qty.Text).ToString("" + qtysetting + "");
                            drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString("" + qtysetting + "");

                        }
                      
                        drNew["UOM"] = lblom.Text;
                        drNew["delaydays"] = lbldelaydays.Text;
                        drNew["qtytype"] = lblqtytype.Text;

                        dstd.Tables[0].Rows.Add(drNew);
                        dtddd = dstd.Tables[0];

                    }

                }



                bool exists = false;
                for (int i = 0; i < dtddd.Rows.Count; i++)
                {
                    for (int j = i + 1; j < dtddd.Rows.Count; j++)
                    {
                        if (dtddd.Rows[j]["delaydays"].ToString() != dtddd.Rows[i]["delaydays"].ToString())
                        { exists = true; break; }
                    }
                }
                if (exists == true)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Different Delay days stock requests are not possible!!');", true);
                    return;
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
            dtraw.Columns.Add("Available_Qty");
            dtraw.Columns.Add("Qty");
            dtraw.Columns.Add("UOM");
            dtraw.Columns.Add("delaydays");
            dtraw.Columns.Add("qtytype");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], Available_Qty = r["Available_Qty"], UOM = r["UOM"], delaydays = r["delaydays"], qtytype = r["qtytype"] } into raw
                              select new
                              {
                                  CategoryID = raw.Key.CategoryID,
                                  CategoryUserID = raw.Key.CategoryUserID,
                                  UOMID = raw.Key.UOMID,
                                  Category = raw.Key.Category,
                                  Definition = raw.Key.Definition,
                                  Available_Qty = raw.Key.Available_Qty,
                                  Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                  UOM = raw.Key.UOM,
                                  delaydays = raw.Key.delaydays,
                                  qtytype=raw.Key.qtytype,
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Definition"] = g.Definition;
                    if(g.qtytype.ToString()=="E")
                    {
                        drraw["Available_Qty"] = Convert.ToInt32(g.Available_Qty).ToString();
                        drraw["Qty"] = Convert.ToInt32(g.Qty).ToString();
                    }
                    else if(g.qtytype.ToString()=="D")
                    {

                        drraw["Available_Qty"] = Convert.ToDouble(g.Available_Qty).ToString("" + qtysetting + "");
                        drraw["Qty"] = Convert.ToDouble(g.Qty).ToString("" + qtysetting + "");
                    }
                   
                    drraw["UOM"] = g.UOM;
                    drraw["delaydays"] = g.delaydays;
                    drraw["qtytype"]=g.qtytype;

                    dsraw.Tables[0].Rows.Add(drraw);
                }

                //bool exists=false;
                //for (int i = 0; i < dsraw.Tables[0].Rows.Count; i++)
                //{
                //    for (int j = i + 1; j < dsraw.Tables[0].Rows.Count; j++)
                //    {
                //        if (dsraw.Tables[0].Rows[j]["delaydays"].ToString() != dsraw.Tables[0].Rows[i]["delaydays"].ToString())
                //        { exists = true;break; }
                //    }
                //}
                //if (exists == true)
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Different Delay days stock requests are not possible!!');", true);
                //    return;
                //}
                
                
                gvqueueitems.DataSource = dsraw;
                gvqueueitems.DataBind();

                gvUserInfo.DataSource = dsraw;
                gvUserInfo.DataBind();

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

            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Accept Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion


            #region

            DataSet dss = objbs.checkrequestallowornot(sTableName);
            if (dss.Tables[0].Rows.Count > 0)
            {
                sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                sCodeIcing = dss.Tables[0].Rows[0]["Icingcode"].ToString();
                sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            //Checking Local DB

            DataSet checktable = objbs.checktableexisitsornot("tblPurchaseRequest_" + sCodeBnch + "");
            if (checktable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            DataSet checktranstable = objbs.checktableexisitsornot("tblTransPurchaseRequest_" + sCodeBnch + "");
            if (checktranstable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            //Checking LIVE DB

            DataSet livechecktable = objbs.checktableexisitsornotlive("tblPurchaseRequestProd_" + sCodeProd + "");
            if (livechecktable.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            DataSet livechecktranstable = objbs.checktableexisitsornotlive("tblTransPurchaseRequestProd_" + sCodeProd + "");
            if (livechecktranstable.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            if (gvqueueitems.Rows.Count == null || gvqueueitems.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Items And Keep in queue.Thank You!!!.');", true);
                return;

            }
            #endregion




            string requestentrytime = System.DateTime.Now.ToString("hh:mm tt");

            DateTime sDate = DateTime.ParseExact(txtpodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime entrytime = DateTime.ParseExact(lblentrydatetime.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);


            if (txtOrderBy.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('Enter OrderBy');", true);
                return;
            }
            if (txtOrderBy.Text == "")
                txtOrderBy.Text = "No Name";

            if (txtOrderBy.Text != "")
            {

                DataSet dReqNo = objbs.ReqNo(Convert.ToInt32(lblUserID.Text), sCodeBnch);
                txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();
                int MainRequestID = 0;

                Label lbldelaydays1 = (Label)gvqueueitems.Rows[0].Cells[4].FindControl("lbldelaydays");
                string delaydays = lbldelaydays1.Text;

                DateTime delaydate = sDate.AddDays(Convert.ToDouble(delaydays));

                if (sCodeProd == sCodeIcing)
                {
                    MainRequestID = objbs.insert_stockrequest(Convert.ToInt32(empid), txtpono.Text, delaydate, "Requset Sent", 0, sTableName, 0, 
                        Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sCodeBnch, requestentrytime, sCodeProd, entrytime,delaydate);
                    lblmainrequestid.Text = MainRequestID.ToString();
                }
                else
                {
                    if (drpproductiontype.SelectedValue == "P")
                    {
                        MainRequestID = objbs.insert_stockrequest(Convert.ToInt32(empid), txtpono.Text, delaydate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sCodeBnch, requestentrytime, sCodeProd, entrytime, delaydate);
                        lblmainrequestid.Text = MainRequestID.ToString();
                    }
                    else if (drpproductiontype.SelectedValue == "I")
                    {
                        MainRequestID = objbs.insert_stockrequest(Convert.ToInt32(empid), txtpono.Text, delaydate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sCodeBnch, requestentrytime, sCodeIcing, entrytime, delaydate);
                        lblmainrequestid.Text = MainRequestID.ToString();
                    }
                }
                #region Trans table
                for (int i = 0; i < gvqueueitems.Rows.Count; i++)
                {

                    HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryID");
                    HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                    HiddenField hideUOMID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideUOMID");

                    Label lblCategory = (Label)gvqueueitems.Rows[i].FindControl("lblCategory");
                    Label lblDefinition = (Label)gvqueueitems.Rows[i].FindControl("lblDefinition");
                    Label lblAvailable_Qty = (Label)gvqueueitems.Rows[i].FindControl("lblAvailable_Qty");
                    Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");
                    Label lbldelaydays = (Label)gvqueueitems.Rows[i].FindControl("lbldelaydays");

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
                        int iSAve = 0;
                        if (sCodeProd == sCodeIcing)
                        {
                             iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID,delaydate);
                        }
                        else
                        {

                            if (drpproductiontype.SelectedValue == "P")
                            {
                                iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeProd, MainRequestID,delaydate);
                            }
                            else if (drpproductiontype.SelectedValue == "I")
                            {
                                iSAve = objbs.insertTransPurchaseReqMain(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sCodeBnch, sDate, sCodeIcing, MainRequestID,delaydate);
                            }

                        }

                    }
                }
                #endregion


                #region SendMail
                //string aaa = DateTime.Now.ToString("dd/MM/yyyy");
                //DataSet ds = objbs.RequestDetqqqorg(txtpono.Text, sCode, aaa);
                //gvqueueitems.DataSource = ds;
                // gvqueueitems.DataBind();

              //  SendHTMLMail();
                #endregion

                Response.Redirect("PurchaseRequestGrid.aspx");
            }
        }


        #region SendMail Attachment

        public void SendHTMLMail()
        {

            MailMessage Msg = new MailMessage();
            //MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            Msg.From = new MailAddress("jothics0792@gmail.com", "Daily Stock Request For " + sTableName + "");
            // Sender e-mail address.
            //Msg.From = fromMail;

            // Subject of e-mail
            Msg.Subject = "Daily Stock Request  For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            //Msg.Body += "<br/> Summary Flow Details <br/>";
            Msg.Body += GetGridviewData(gvUserInfo);



            Msg.IsBodyHtml = true;

            string mutltiemail = "";

            // Get Branch EMAIL ID
            DataSet demail = objbs.GetBranchEmail(sTableName,drpproductiontype.SelectedValue);
            if (demail.Tables[0].Rows.Count > 0)
            {
                mutltiemail = demail.Tables[0].Rows[0]["email"].ToString();
            }

            string[] Multi = mutltiemail.Split(',');
            try
            {
                foreach (string Multiemailid in Multi)
                {
                    Msg.To.Add(new MailAddress(Multiemailid));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
                }
            }
            catch (Exception ex)
            {
                int Emaisttsus = objbs.EmailStatus(sTableName, "Daily Stock Request:" + lblmainrequestid.Text + "", ConfigurationManager.AppSettings["FromAddress"], mutltiemail, ex.ToString(), "Failure");
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
           // smtp.Send(Msg);
           // Msg.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnSuccess;
            try
            {
                smtp.Send(Msg);

                // Insert Email Status
                int Emaisttsus = objbs.EmailStatus(sTableName, "Daily Stock Request:" + lblmainrequestid.Text + "", NetworkCred.UserName.ToString(), mutltiemail, Msg.ToString(), "Success");

            }
            catch (SmtpFailedRecipientsException ex)
            {
                for (int i = 0; i < ex.InnerExceptions.Length; i++)
                {
                    SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Console.WriteLine("Delivery failed - retrying in 5 seconds.");
                        int Emaisttsus = objbs.EmailStatus(sTableName, "Daily Stock Request:" + lblmainrequestid.Text + "", NetworkCred.UserName.ToString(), mutltiemail, ex.ToString(), "Failed");
                        System.Threading.Thread.Sleep(5000);
                        smtp.Send(Msg);
                    }
                    else
                    {
                        Console.WriteLine("Failed to deliver message to {0}",
                            ex.InnerExceptions[i].FailedRecipient);
                    }
                }
            }
            catch (Exception ex)
            {
                int Emaisttsus = objbs.EmailStatus(sTableName, "Daily Stock Request:" + lblmainrequestid.Text + "", NetworkCred.UserName.ToString(), mutltiemail, ex.ToString(), "Failure");
                Console.WriteLine("Exception caught in RetryIfBusy(): {0}",
                        ex.ToString());

            }  
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        #endregion


        protected void gvqueueitems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "plus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");
                Label lblqtytype = (Label)gvqueueitems.Rows[rowIndex].Cells[6].FindControl("lblqtytype");
                if (lblqtytype.Text == "E")
                {
                    txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) + 1).ToString();
                }
                else if (lblqtytype.Text == "D")
                {
                    txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) + 1).ToString("" + qtysetting + "");
                }
                //txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) + 1).ToString("0.00");
            }

            if (e.CommandName == "minus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");
                Label lblqtytype = (Label)gvqueueitems.Rows[rowIndex].Cells[6].FindControl("lblqtytype");
                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                   
                    if (lblqtytype.Text == "E")
                    {
                        txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) - 1).ToString();
                    }
                    else if (lblqtytype.Text == "D")
                    {
                        txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) - 1).ToString("" + qtysetting + "");
                    }
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
            dct = new DataColumn("Definition");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Available_Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("Qty");
            dttt.Columns.Add(dct);
            dct = new DataColumn("UOM");
            dttt.Columns.Add(dct);

            dct = new DataColumn("delaydays");
            dttt.Columns.Add(dct);
           

            dstd.Tables.Add(dttt);

            for (int i = 0; i < gvqueueitems.Rows.Count; i++)
            {
                HiddenField hideCategoryID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryID");
                HiddenField hideCategoryUserID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideCategoryUserID");
                HiddenField hideUOMID = (HiddenField)gvqueueitems.Rows[i].FindControl("hideUOMID");

                Label lblCategory = (Label)gvqueueitems.Rows[i].FindControl("lblCategory");
                Label lblDefinition = (Label)gvqueueitems.Rows[i].FindControl("lblDefinition");
                Label lblAvailable_Qty = (Label)gvqueueitems.Rows[i].FindControl("lblAvailable_Qty");
                Label lblom = (Label)gvqueueitems.Rows[i].FindControl("lblom");
                Label lbldelaydays = (Label)gvqueueitems.Rows[i].FindControl("lbldelaydays");

                TextBox txtQty = (TextBox)gvqueueitems.Rows[i].FindControl("txtQty");
                Label lblqtytype = (Label)gvqueueitems.Rows[i].FindControl("lblqtytype");
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
                    if(lblqtytype.Text=="E")
                    {
                        drNew["Available_Qty"] =Convert.ToInt32(lblAvailable_Qty.Text).ToString(); ;
                        drNew["Qty"] = Convert.ToInt32(txtQty.Text).ToString();
                    }
                    else if(lblqtytype.Text=="D")
                    {
                        drNew["Available_Qty"]=Convert.ToDouble(lblAvailable_Qty.Text).ToString("" + qtysetting + "");
                        drNew["Qty"] = Convert.ToDouble(txtQty.Text).ToString(""+ qtysetting+"");
                    }
                  
                    drNew["UOM"] = lblom.Text;
                    drNew["delaydays"] = lbldelaydays.Text;
                   

                    dstd.Tables[0].Rows.Add(drNew);
                    dtddd = dstd.Tables[0];
                }
            }

            ViewState["CurrentTable1"] = dtddd;
            gvUserInfo.DataSource = dtddd;
            gvUserInfo.DataBind();
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseRequestGrid.aspx");

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

                    gvUserInfo.DataSource = dt;
                    gvUserInfo.DataBind();

                    SetPreviousData1();


                }

                else if (dt.Rows.Count == 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    gvqueueitems.DataSource = dt;
                    gvqueueitems.DataBind();

                    gvUserInfo.DataSource = dt;
                    gvUserInfo.DataBind();

                    SetPreviousData1();

                    gvqueueitems.DataSource = null;
                    gvqueueitems.DataBind();

                    gvUserInfo.DataSource = null;
                    gvUserInfo.DataBind();


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
                        Label lblAvailable_Qty =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblAvailable_Qty");

                        TextBox txtQty =
                          (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                        Label lblom =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lblom");

                        Label lbldelaydays =
                        (Label)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("lbldelaydays");


                        lblCategory.Text = dt.Rows[i]["Category"].ToString();
                        hideCategoryID.Value = dt.Rows[i]["CategoryID"].ToString();
                        hideCategoryUserID.Value = dt.Rows[i]["CategoryUserID"].ToString();
                        hideUOMID.Value = dt.Rows[i]["UOMID"].ToString();
                        lblDefinition.Text = dt.Rows[i]["Definition"].ToString();
                        lblAvailable_Qty.Text = dt.Rows[i]["Available_Qty"].ToString();
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        lblom.Text = dt.Rows[i]["UOM"].ToString();
                        lbldelaydays.Text = dt.Rows[i]["delaydays"].ToString();

                        rowIndex++;

                    }
                }
            }
        }
    }
}