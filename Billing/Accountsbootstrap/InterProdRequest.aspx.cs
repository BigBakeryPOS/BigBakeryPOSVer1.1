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
using System.Net.Mail;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class InterProdRequest : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        //  string sCodeProd = "";
        //  string sCodeBnch = "";
        string empid = "";
        string frombranchid = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            empid = Request.Cookies["userInfo"]["Empid"].ToString();
            frombranchid = Request.Cookies["userInfo"]["BranchID"].ToString();



            if (!IsPostBack)
            {
                DataSet dsCategory = objbs.selectcategorymasterforproductionentry();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "Printcategory";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "All");
                    ddlcategory_SelectedIndexChanged(sender, e);

                }

                DataSet dsbranch = objbs.getbranchFilling("2");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpfrombranch.DataSource = dsbranch.Tables[0];
                    drpfrombranch.DataTextField = "BranchArea";
                    drpfrombranch.DataValueField = "BranchId";
                    drpfrombranch.DataBind();
                    drpfrombranch.Items.Insert(0, "Select Store");
                    drpfrombranch.SelectedValue = frombranchid;
                }

                DataSet dsTobranch = objbs.gettoProd(drpfrombranch.SelectedValue);
                if (dsTobranch.Tables[0].Rows.Count > 0)
                {
                    drptobranch.DataSource = dsTobranch.Tables[0];
                    drptobranch.DataTextField = "BranchName";
                    drptobranch.DataValueField = "interBranchId";
                    drptobranch.DataBind();
                    drptobranch.Items.Insert(0, "Select Prod");
                }




                //txtOrderBy.Text = Session["Biller"].ToString();

                lblentrydatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                DataSet dss = objbs.checkinterProdrequestallowornot(sTableName);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    // sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    //  sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Production is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                DataSet dReqNo = objbs.ReqNoInter(Convert.ToInt32(lblUserID.Text), sTableName);

                txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();
                txtpodate.Text = DateTime.Now.ToString("dd/MM/yyyy");

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


            DataSet dsitems = objbs.itemforreqest_prod(catid, sTableName, "REQ");
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
                        drNew["Available_Qty"] = lblAvailable_Qty.Text;
                        drNew["Qty"] = txtQty.Text;
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

                        drNew["Category"] = lblCategory.Text;
                        drNew["Definition"] = lblDefinition.Text;
                        drNew["Available_Qty"] = lblAvailable_Qty.Text;
                        drNew["Qty"] = txtQty.Text;
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
            dtraw.Columns.Add("Available_Qty");
            dtraw.Columns.Add("Qty");
            dtraw.Columns.Add("UOM");

            dsraw.Tables.Add(dtraw);

            if (dstd.Tables[0].Rows.Count > 0)
            {
                #region

                // DataTable dtraws = dsrawmerge.Tables[0];

                var result1 = from r in dtddd.AsEnumerable()
                              group r by new { CategoryID = r["CategoryID"], CategoryUserID = r["CategoryUserID"], UOMID = r["UOMID"], Category = r["Category"], Definition = r["Definition"], Available_Qty = r["Available_Qty"], UOM = r["UOM"] } into raw
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
                              };


                foreach (var g in result1)
                {
                    drraw = dtraw.NewRow();

                    drraw["CategoryID"] = g.CategoryID;
                    drraw["CategoryUserID"] = g.CategoryUserID;
                    drraw["UOMID"] = g.UOMID;
                    drraw["Category"] = g.Category;
                    drraw["Definition"] = g.Definition;
                    drraw["Available_Qty"] = g.Available_Qty;
                    drraw["Qty"] = Convert.ToDouble(g.Qty).ToString("f2");
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


            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                //  radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Accept Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (drptobranch.SelectedValue == "Select Prod")
            {
                //  radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select To Prod.Thank You!!!');", true);
                return;
            }

            #endregion


            #region

            DataSet dss = objbs.checkinterProdrequestallowornot(sTableName);
            if (dss.Tables[0].Rows.Count > 0)
            {
                // sCodeProd = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                //  sCodeBnch = dss.Tables[0].Rows[0]["BranchCode"].ToString();
            }
            else
            {
                //  radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Prod is allow to Request Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            //Checking Local DB

            DataSet checktable = objbs.checktableexisitsornot("tblinterbranchrequest_" + sTableName + "");
            if (checktable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                //  radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            DataSet checktranstable = objbs.checktableexisitsornot("tblTransinterbranchrequest_" + sTableName + "");
            if (checktranstable.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                // radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            //Checking LIVE DB

            ////DataSet livechecktable = objbs.checktableexisitsornotlive("tblPurchaseRequestProd_" + sTableName + "");
            ////if (livechecktable.Tables[0].Rows.Count > 0)
            ////{
            ////}
            ////else
            ////{
            ////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
            ////    return;
            ////}

            ////DataSet livechecktranstable = objbs.checktableexisitsornotlive("tblTransPurchaseRequestProd_" + sCodeProd + "");
            ////if (livechecktranstable.Tables[0].Rows.Count > 0)
            ////{
            ////}
            ////else
            ////{
            ////    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch to Production Request Table Not created.Please Contact Administrator.Thank You!!!.');", true);
            ////    return;
            ////}

            if (gvqueueitems.Rows.Count == null || gvqueueitems.Rows.Count == 0)
            {
                // radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Items And Keep in queue.Thank You!!!.');", true);
                return;

            }
            #endregion




            string requestentrytime = System.DateTime.Now.ToString("hh:mm tt");

            DateTime sDate = DateTime.ParseExact(txtpodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime entrytime = DateTime.ParseExact(lblentrydatetime.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);


            if (txtOrderBy.Text == "")
            {
                // radsavebtn.Checked = false;
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "MyScript", "alert('Enter OrderBy');", true);
                return;
            }
            if (txtOrderBy.Text == "")
                txtOrderBy.Text = "No Name";

            if (txtOrderBy.Text != "")
            {

                DataSet dReqNo = objbs.ReqNoInter(Convert.ToInt32(lblUserID.Text), sTableName);
                txtpono.Text = dReqNo.Tables[0].Rows[0]["RequestNo"].ToString();

                int MainRequestID = objbs.insert_interstockrequest_prod(Convert.ToInt32(empid), txtpono.Text, sDate, "Requset Sent", 0, sTableName, 0, Convert.ToInt32(lblUserID.Text), txtOrderBy.Text, sTableName, requestentrytime, entrytime, drpfrombranch.SelectedValue, drptobranch.SelectedValue);
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
                        int iSAve = objbs.insertinterTransReqMain_prod(txtpono.Text, iCatID, iSubCatID, Convert.ToDecimal(dTextBox), sUnits, 0, Convert.ToInt32(lblUserID.Text), 0, sTableName, sDate, "", MainRequestID);

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

                Response.Redirect("InterProdGrid.aspx");
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
                txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) + 1).ToString("0.00");
            }

            if (e.CommandName == "minus")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvqueueitems.Rows[rowIndex];
                TextBox txtQty = (TextBox)gvqueueitems.Rows[rowIndex].Cells[4].FindControl("txtQty");

                if (Convert.ToDouble(txtQty.Text) > 0)
                {
                    txtQty.Text = Convert.ToDouble(Convert.ToDouble(txtQty.Text) - 1).ToString("0.00");
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
                    drNew["Available_Qty"] = lblAvailable_Qty.Text;
                    drNew["Qty"] = txtQty.Text;
                    drNew["UOM"] = lblom.Text;

                    dstd.Tables[0].Rows.Add(drNew);
                    dtddd = dstd.Tables[0];
                }
            }

            ViewState["CurrentTable1"] = dtddd;
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterProdGrid.aspx");

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
                        lblDefinition.Text = dt.Rows[i]["Definition"].ToString();
                        lblAvailable_Qty.Text = dt.Rows[i]["Available_Qty"].ToString();
                        txtQty.Text = dt.Rows[i]["Qty"].ToString();
                        lblom.Text = dt.Rows[i]["UOM"].ToString();

                        rowIndex++;

                    }
                }
            }
        }
    }
}