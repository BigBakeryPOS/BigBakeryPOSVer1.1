using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;

namespace Billing.Accountsbootstrap
{
    public partial class PurchaseCompanyDetails : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string iCompanyID = Request.QueryString.Get("iCompanyID");
                if (iCompanyID != "" || iCompanyID != null)
                {
                    DataSet ds1 = objBs.GetSubCompanyDetails(Convert.ToInt32(iCompanyID));

                    //DataSet ds01 = objBs.GetSetting();
                    //DataSet ds02 = objBs.GetLoginID();


                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        txtcompanyID.Text = ds1.Tables[0].Rows[0]["SubComapanyID"].ToString();
                        txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtmobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtphoneno.Text = ds1.Tables[0].Rows[0]["PhoneNo"].ToString();
                        txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        txtarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        txtpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();
                        txtemail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();
                        txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();

                        txtGstNo.Text = ds1.Tables[0].Rows[0]["GSTNo"].ToString();
                        txtWebSite.Text = ds1.Tables[0].Rows[0]["WebSite"].ToString();
                        txtSocial.Text = ds1.Tables[0].Rows[0]["Social"].ToString();
                        txtAboutUs.Text = ds1.Tables[0].Rows[0]["AboutUs"].ToString();

                        lblFile_Path.Text = ds1.Tables[0].Rows[0]["Imagepath"].ToString();
                        img_Photo.ImageUrl = ds1.Tables[0].Rows[0]["Imagepath"].ToString();

                        //lblFile_Path2.Text = ds1.Tables[0].Rows[0]["Banner1"].ToString();
                        //img_Photo2.ImageUrl = ds1.Tables[0].Rows[0]["Banner1"].ToString();

                        //lblFile_Path3.Text = ds1.Tables[0].Rows[0]["Banner2"].ToString();
                        //img_Photo3.ImageUrl = ds1.Tables[0].Rows[0]["Banner2"].ToString();

                        //lblFile_Path4.Text = ds1.Tables[0].Rows[0]["Banner3"].ToString();
                        //img_Photo4.ImageUrl = ds1.Tables[0].Rows[0]["Banner3"].ToString();


                        //DataSet dsize = objBs.EditTypeSetting(Convert.ToInt32(iCompanyID));

                        //if ((dsize.Tables[0].Rows.Count > 0))
                        //{

                        //    for (int i = 0; i <= dsize.Tables[0].Rows.Count - 1; i++)
                        //    {

                        //        chkType.Items.FindByValue(dsize.Tables[0].Rows[i]["TypeSettingID"].ToString()).Selected = true;

                        //    }
                        //}


                        //string Fdate = ds01.Tables[0].Rows[0]["ToDate"].ToString();

                        //Fdate = Decrypt(Fdate);

                        //txtToDate.Text = Fdate;

                        //txtUsername.Text = ds1.Tables[0].Rows[0]["Username"].ToString();
                        //txtPasswprd.Text = ds1.Tables[0].Rows[0]["Password"].ToString();
                        //txtEmpCode.Text = ds1.Tables[0].Rows[0]["EmpCode"].ToString();
                        //txtNoOfBranch.Text = ds1.Tables[0].Rows[0]["NoOfBranch"].ToString();

                        //txtcompanyID.Enabled = false;
                        //txtcustomername.Enabled = false;
                        //txtmobileno.Enabled = false;
                        //txtphoneno.Enabled = false;
                        //txtaddress.Enabled = false;
                        //txtarea.Enabled = false;
                        //txtpincode.Enabled = false;
                        //txtemail.Enabled = false;
                        //txtcity.Enabled = false;

                        btnadd.Text = "Update";
                        // btnadd.Visible = false;
                    }

                }

            }
        }


        protected void Add_Click(object sender, EventArgs e)
        {
            string Mode = Request.QueryString.Get("Mode");

            string Imagepath = string.Empty;
            string Imagepath2 = string.Empty;
            string Imagepath3 = string.Empty;
            string Imagepath4 = string.Empty;

            string DigitalMenu = "";
            string Ecommerce = "";

            if (lblFile_Path.Text == "" || lblFile_Path.Text == null)
            {
                Imagepath = "../images/NoImage.png";
            }
            else
            {
                Imagepath = lblFile_Path.Text;
            }

            //if (lblFile_Path2.Text == "" || lblFile_Path2.Text == null)
            //{
            //    Imagepath2 = "../images/NoImage.png";
            //}
            //else
            //{
            //    Imagepath2 = lblFile_Path2.Text;
            //}

            //if (lblFile_Path3.Text == "" || lblFile_Path3.Text == null)
            //{
            //    Imagepath3 = "../images/NoImage.png";
            //}
            //else
            //{
            //    Imagepath3 = lblFile_Path3.Text;
            //}
            //if (lblFile_Path4.Text == "" || lblFile_Path4.Text == null)
            //{
            //    Imagepath4 = "../images/NoImage.png";
            //}
            //else
            //{
            //    Imagepath4 = lblFile_Path4.Text;
            //}


            //DataSet dsDeletesetting = objBs.DeleteSetting();

            //string iCompanyID = Request.QueryString.Get("iCompanyID");
            //if (iCompanyID != null)
            //{
            //    DateTime EndDate = DateTime.ParseExact(txtToDate.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            //    txtToDate.Text = Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd");
            //}

            //else
            //{
            //    DateTime EndDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    txtToDate.Text = Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd");
            //}





            //string constr = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("INSERT INTO tblSettingotp(FromDate,ToDate) VALUES(getdate(), @ToDate)"))
            //    {
            //        cmd.CommandType = CommandType.Text;

            //        cmd.Parameters.AddWithValue("@ToDate", Encrypt(txtToDate.Text.Trim()));
            //        //cmd.Parameters.AddWithValue("@CreatedDate", "getdate()");
            //        cmd.Connection = con;
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //}

            if (btnadd.Text == "Save")
            {


                if (txtemail.Text != "")
                {
                    DataSet ds2 = objBs.EmailID_SubCompanyDetails(txtemail.Text, txtmobileno.Text);
                    if (ds2.Tables[0].Rows.Count != 0)
                    {
                        //Response.Write("email id already exists");
                        lblerror.Text = "Email or Mobile Number id already exists";
                    }
                    else
                    {

                        //foreach (ListItem listItem in chkType.Items)
                        //{
                        //    if (listItem.Text != "All")
                        //    {
                        //        if (listItem.Selected)
                        //        {
                        //            int iddd = objBs.insert_TransAdminSetting(listItem.Value, listItem.Text, iCompanyID);
                        //        }
                        //    }
                        //}

                        int iStatus = objBs.SubCompanyDetails(txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, txtGstNo.Text, txtWebSite.Text, txtSocial.Text, Imagepath, Imagepath2, Imagepath3, Imagepath4, txtUsername.Text, txtPasswprd.Text, txtEmpCode.Text, txtNoOfBranch.Text, drpbranchtype.SelectedValue, txtAboutUs.Text, DigitalMenu, Ecommerce);

                        #region Rightes
                        //DataSet dsmsater = new DataSet();
                        //dsmsater = objBs.GetAdminRights("MasterMenu", "No");
                        //grdmaster.DataSource = dsmsater;
                        //grdmaster.DataBind();


                        //DataSet dsOrderFormMenu = new DataSet();
                        //dsOrderFormMenu = objBs.grtroll("OrderFormMenu", "No", 0);
                        //OrderFormMenu.DataSource = dsOrderFormMenu;
                        //OrderFormMenu.DataBind();

                        //DataSet dsinventory = new DataSet();
                        //dsinventory = objBs.grtroll("InventoryMenu", "No", 0);
                        //grdinventory.DataSource = dsinventory;
                        //grdinventory.DataBind();

                        //DataSet RequestAccept = new DataSet();
                        //RequestAccept = objBs.grtroll("RequestAccept", "No", 0);
                        //grRequestAccept.DataSource = RequestAccept;
                        //grRequestAccept.DataBind();


                        //DataSet dsreport = new DataSet();
                        //dsreport = objBs.grtroll("Reports", "No", 0);
                        //grdreport.DataSource = dsreport;
                        //grdreport.DataBind();


                        //DataSet dsdetailedreport = new DataSet();
                        //dsdetailedreport = objBs.grtroll("ReportsAccess", "No", 0);
                        //grddetailedreport.DataSource = dsdetailedreport;
                        //grddetailedreport.DataBind();

                        //#region Rights Set

                        //int idd = 0;

                        //DataSet dsrights = objBs.GiveRightsToAdmin();

                        //if (dsrights.Tables[0].Rows.Count > 0)
                        //{
                        //    idd = Convert.ToInt32(dsrights.Tables[0].Rows[0]["EmpID"].ToString());
                        //}

                        //DataSet dsmsater1 = new DataSet();
                        //dsmsater1 = objBs.GetAdminRights("MasterMenu", "Yes");
                        //for (int vLoop = 0; vLoop < grdmaster.Rows.Count; vLoop++)
                        //{
                        //    Label txtsno = (Label)grdmaster.Rows[vLoop].FindControl("lblDebtorID");

                        //    for (int j = 0; j < dsmsater1.Tables[0].Rows.Count; j++)
                        //    {
                        //        string roleid = dsmsater1.Tables[0].Rows[j]["roleid"].ToString();

                        //        bool Add = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Visible"]);
                        //        bool Read = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Read"]);
                        //        bool Edit = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Edit"]);
                        //        bool Delete = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Delete"]);
                        //        bool Save = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Save"]);

                        //        if (roleid == txtsno.Text)
                        //        {

                        //            CheckBox chkboxAdd = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkboxAdd");

                        //            CheckBox chkRead = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkRead");
                        //            CheckBox chkEdit = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkEdit");
                        //            CheckBox chkDelete = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkDelete");
                        //            CheckBox chkSave = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkSave");

                        //            chkboxAdd.Checked = Add;
                        //            chkRead.Checked = Read;
                        //            chkEdit.Checked = Edit;
                        //            chkDelete.Checked = Delete;
                        //            chkSave.Checked = Save;
                        //        }
                        //    }


                        //}
                        //  grdmaster.DataSource = dsmsater1;
                        //  grdmaster.DataBind();

                        //DataSet dsOrderFormMenu1 = new DataSet();
                        //dsOrderFormMenu1 = objBs.GetAdminRights("OrderFormMenu", "Yes");
                        //// OrderFormMenu.DataSource = dsOrderFormMenu1;
                        ////  OrderFormMenu.DataBind();
                        //for (int vLoop = 0; vLoop < OrderFormMenu.Rows.Count; vLoop++)
                        //{
                        //    Label txtsno = (Label)OrderFormMenu.Rows[vLoop].FindControl("lblDebtorID");

                        //    for (int j = 0; j < dsOrderFormMenu1.Tables[0].Rows.Count; j++)
                        //    {
                        //        string roleid = dsOrderFormMenu1.Tables[0].Rows[j]["roleid"].ToString();

                        //        bool Add = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Visible"]);
                        //        bool Read = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Read"]);
                        //        bool Edit = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Edit"]);
                        //        bool Delete = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Delete"]);
                        //        bool Save = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Save"]);

                        //        if (roleid == txtsno.Text)
                        //        {

                        //            CheckBox chkboxAdd = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkboxAdd");

                        //            CheckBox chkRead = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkRead");
                        //            CheckBox chkEdit = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkEdit");
                        //            CheckBox chkDelete = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkDelete");
                        //            CheckBox chkSave = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkSave");

                        //            chkboxAdd.Checked = Add;
                        //            chkRead.Checked = Read;
                        //            chkEdit.Checked = Edit;
                        //            chkDelete.Checked = Delete;
                        //            chkSave.Checked = Save;
                        //        }
                        //    }


                        //}

                        //DataSet dsinventory1 = new DataSet();
                        //dsinventory1 = objBs.GetAdminRights("InventoryMenu", "Yes");
                        //for (int vLoop = 0; vLoop < grdinventory.Rows.Count; vLoop++)
                        //{
                        //    Label txtsno = (Label)grdinventory.Rows[vLoop].FindControl("lblDebtorID");

                        //    for (int j = 0; j < dsinventory1.Tables[0].Rows.Count; j++)
                        //    {
                        //        string roleid = dsinventory1.Tables[0].Rows[j]["roleid"].ToString();

                        //        bool Add = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Visible"]);
                        //        bool Read = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Read"]);
                        //        bool Edit = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Edit"]);
                        //        bool Delete = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Delete"]);
                        //        bool Save = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Save"]);

                        //        if (roleid == txtsno.Text)
                        //        {

                        //            CheckBox chkboxAdd = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkboxAdd");

                        //            CheckBox chkRead = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkRead");
                        //            CheckBox chkEdit = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkEdit");
                        //            CheckBox chkDelete = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkDelete");
                        //            CheckBox chkSave = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkSave");

                        //            chkboxAdd.Checked = Add;
                        //            chkRead.Checked = Read;
                        //            chkEdit.Checked = Edit;
                        //            chkDelete.Checked = Delete;
                        //            chkSave.Checked = Save;
                        //        }
                        //    }


                        //}
                        //// grdinventory.DataSource = dsinventory1;
                        ////grdinventory.DataBind();

                        ////DataSet RequestAccept1 = new DataSet();
                        ////RequestAccept1 = objBs.GetAdminRights("RequestAccept", "Yes");
                        ////// grRequestAccept.DataSource = RequestAccept1;
                        //////  grRequestAccept.DataBind();
                        ////for (int vLoop = 0; vLoop < grRequestAccept.Rows.Count; vLoop++)
                        ////{
                        ////    Label txtsno = (Label)grRequestAccept.Rows[vLoop].FindControl("lblDebtorID");

                        ////    for (int j = 0; j < RequestAccept1.Tables[0].Rows.Count; j++)
                        ////    {
                        ////        string roleid = RequestAccept1.Tables[0].Rows[j]["roleid"].ToString();

                        ////        bool Add = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Visible"]);
                        ////        bool Read = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Read"]);
                        ////        bool Edit = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Edit"]);
                        ////        bool Delete = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Delete"]);
                        ////        bool Save = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Save"]);

                        ////        if (roleid == txtsno.Text)
                        ////        {

                        ////            CheckBox chkboxAdd = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkboxAdd");

                        ////            CheckBox chkRead = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkRead");
                        ////            CheckBox chkEdit = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkEdit");
                        ////            CheckBox chkDelete = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkDelete");
                        ////            CheckBox chkSave = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkSave");

                        ////            chkboxAdd.Checked = Add;
                        ////            chkRead.Checked = Read;
                        ////            chkEdit.Checked = Edit;
                        ////            chkDelete.Checked = Delete;
                        ////            chkSave.Checked = Save;
                        ////        }
                        ////    }


                        ////}


                        //DataSet dsreport1 = new DataSet();
                        //dsreport1 = objBs.GetAdminRights("Reports", "Yes");
                        ////  grdreport.DataSource = dsreport1;
                        ////  grdreport.DataBind();
                        //for (int vLoop = 0; vLoop < grdreport.Rows.Count; vLoop++)
                        //{
                        //    Label txtsno = (Label)grdreport.Rows[vLoop].FindControl("lblDebtorID");

                        //    for (int j = 0; j < dsreport1.Tables[0].Rows.Count; j++)
                        //    {
                        //        string roleid = dsreport1.Tables[0].Rows[j]["roleid"].ToString();

                        //        bool Add = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Visible"]);
                        //        bool Read = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Read"]);
                        //        bool Edit = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Edit"]);
                        //        bool Delete = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Delete"]);
                        //        bool Save = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Save"]);

                        //        if (roleid == txtsno.Text)
                        //        {

                        //            CheckBox chkboxAdd = (CheckBox)grdreport.Rows[vLoop].FindControl("chkboxAdd");

                        //            CheckBox chkRead = (CheckBox)grdreport.Rows[vLoop].FindControl("chkRead");
                        //            CheckBox chkEdit = (CheckBox)grdreport.Rows[vLoop].FindControl("chkEdit");
                        //            CheckBox chkDelete = (CheckBox)grdreport.Rows[vLoop].FindControl("chkDelete");
                        //            CheckBox chkSave = (CheckBox)grdreport.Rows[vLoop].FindControl("chkSave");

                        //            chkboxAdd.Checked = Add;
                        //            chkRead.Checked = Read;
                        //            chkEdit.Checked = Edit;
                        //            chkDelete.Checked = Delete;
                        //            chkSave.Checked = Save;
                        //        }
                        //    }


                        //}

                        ////DataSet dsdetailedreport1 = new DataSet();
                        ////dsdetailedreport1 = objBs.GetAdminRights("ReportsAccess", "Yes");
                        //////  grdreport.DataSource = dsreport1;
                        //////  grdreport.DataBind();
                        ////for (int vLoop = 0; vLoop < grddetailedreport.Rows.Count; vLoop++)
                        ////{
                        ////    Label txtsno = (Label)grddetailedreport.Rows[vLoop].FindControl("lblDebtorID");

                        ////    for (int j = 0; j < dsdetailedreport1.Tables[0].Rows.Count; j++)
                        ////    {
                        ////        string roleid = dsdetailedreport1.Tables[0].Rows[j]["roleid"].ToString();

                        ////        bool Add = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Visible"]);
                        ////        bool Read = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Read"]);
                        ////        bool Edit = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Edit"]);
                        ////        bool Delete = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Delete"]);
                        ////        bool Save = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Save"]);

                        ////        if (roleid == txtsno.Text)
                        ////        {

                        ////            CheckBox chkboxAdd = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkboxAdd");

                        ////            CheckBox chkRead = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkRead");
                        ////            CheckBox chkEdit = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkEdit");
                        ////            CheckBox chkDelete = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkDelete");
                        ////            CheckBox chkSave = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkSave");

                        ////            chkboxAdd.Checked = Add;
                        ////            chkRead.Checked = Read;
                        ////            chkEdit.Checked = Edit;
                        ////            chkDelete.Checked = Delete;
                        ////            chkSave.Checked = Save;
                        ////        }
                        ////    }


                        ////}

                        //#endregion


                        //if (idd != 0)
                        //{


                        //    DataSet ds;
                        //    DataTable dt;
                        //    DataRow drNew;
                        //    DataSet dsBranch;
                        //    DataTable dtBranch;
                        //    DataColumn dc;

                        //    ds = new DataSet();

                        //    dt = new DataTable();

                        //    dc = new DataColumn("UserName");
                        //    dt.Columns.Add(dc);

                        //    dc = new DataColumn("Screen");
                        //    dt.Columns.Add(dc);

                        //    dc = new DataColumn("screenid");
                        //    dt.Columns.Add(dc);

                        //    dc = new DataColumn("screencode");
                        //    dt.Columns.Add(dc);

                        //    dc = new DataColumn("Active");
                        //    dt.Columns.Add(dc);

                        //    dc = new DataColumn("Read");
                        //    dt.Columns.Add(dc);
                        //    dc = new DataColumn("Edit");
                        //    dt.Columns.Add(dc);
                        //    dc = new DataColumn("Delete");
                        //    dt.Columns.Add(dc);
                        //    dc = new DataColumn("Save");
                        //    dt.Columns.Add(dc);

                        //    ds.Tables.Add(dt);
                        //    bool Add = false;

                        //    bool Read = false;
                        //    bool Edit = false;
                        //    bool Delete = false;
                        //    bool Save = false;


                        //    DataSet dsroles = new DataSet();
                        //    DataTable dtt = new DataTable();
                        //    DataRow drNewt;
                        //    DataColumn dcc;
                        //    dcc = new DataColumn("UserName");
                        //    dtt.Columns.Add(dcc);

                        //    dcc = new DataColumn("Screen");
                        //    dtt.Columns.Add(dcc);
                        //    dsroles.Tables.Add(dtt);

                        //    bool Views = false;
                        //    Label lblDebtorID = null;




                        //    for (int vLoop = 0; vLoop < grdmaster.Rows.Count; vLoop++)
                        //    {
                        //        #region
                        //        #region

                        //        CheckBox txt = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkboxAdd");
                        //        if (txt.Checked)
                        //        {
                        //            Add = txt.Checked;
                        //        }
                        //        else
                        //        {
                        //            Add = false;
                        //        }
                        //        CheckBox chkRead = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkRead");
                        //        if (chkRead.Checked)
                        //        {
                        //            Read = chkRead.Checked;
                        //        }
                        //        else
                        //        {
                        //            Read = false;
                        //        }
                        //        CheckBox chkEdit = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkEdit");
                        //        if (chkEdit.Checked)
                        //        {
                        //            Edit = chkEdit.Checked;
                        //        }
                        //        else
                        //        {
                        //            Edit = false;
                        //        }
                        //        CheckBox chkDelete = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkDelete");
                        //        if (chkDelete.Checked)
                        //        {
                        //            Delete = chkDelete.Checked;
                        //        }
                        //        else
                        //        {
                        //            Delete = false;
                        //        }
                        //        CheckBox chkSave = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkSave");
                        //        if (chkSave.Checked)
                        //        {
                        //            Save = chkSave.Checked;
                        //        }
                        //        else
                        //        {
                        //            Save = false;
                        //        }




                        //        #endregion

                        //        if ((txt.Checked == true))
                        //        {
                        //            drNewt = dtt.NewRow();
                        //            drNewt["UserName"] = txtUsername.Text;
                        //            drNewt["Screen"] = grdmaster.Rows[vLoop].Cells[3].Text;
                        //            dsroles.Tables[0].Rows.Add(drNewt);
                        //        }

                        //        #region

                        //        drNew = dt.NewRow();
                        //        drNew["UserName"] = txtUsername.Text;
                        //        drNew["screencode"] = grdmaster.Rows[vLoop].Cells[3].Text;
                        //        drNew["Screen"] = grdmaster.Rows[vLoop].Cells[1].Text;

                        //        lblDebtorID = (Label)grdmaster.Rows[vLoop].FindControl("lblDebtorID");
                        //        drNew["screenid"] = lblDebtorID.Text;

                        //        drNew["Active"] = Add;

                        //        drNew["Read"] = Read;
                        //        drNew["Edit"] = Edit;
                        //        drNew["Delete"] = Delete;
                        //        drNew["Save"] = Save;

                        //        #endregion

                        //        ds.Tables[0].Rows.Add(drNew);
                        //        #endregion
                        //    }



                        //    //    for (int vLoop = 0; vLoop < OrderFormMenu.Rows.Count; vLoop++)
                        //    //    {
                        //    //        #region

                        //    //        #region

                        //    //        CheckBox txt = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkboxAdd");
                        //    //        if (txt.Checked)
                        //    //        {
                        //    //            Add = txt.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Add = false;
                        //    //        }
                        //    //        CheckBox chkRead = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkRead");
                        //    //        if (chkRead.Checked)
                        //    //        {
                        //    //            Read = chkRead.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Read = false;
                        //    //        }
                        //    //        CheckBox chkEdit = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkEdit");
                        //    //        if (chkEdit.Checked)
                        //    //        {
                        //    //            Edit = chkEdit.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Edit = false;
                        //    //        }
                        //    //        CheckBox chkDelete = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkDelete");
                        //    //        if (chkDelete.Checked)
                        //    //        {
                        //    //            Delete = chkDelete.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Delete = false;
                        //    //        }
                        //    //        CheckBox chkSave = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkSave");
                        //    //        if (chkSave.Checked)
                        //    //        {
                        //    //            Save = chkSave.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Save = false;
                        //    //        }




                        //    //        #endregion

                        //    //        if ((txt.Checked == true))
                        //    //        {
                        //    //            drNewt = dtt.NewRow();
                        //    //            drNewt["UserName"] = txtUsername.Text;
                        //    //            drNewt["Screen"] = OrderFormMenu.Rows[vLoop].Cells[3].Text;
                        //    //            dsroles.Tables[0].Rows.Add(drNewt);
                        //    //        }

                        //    //        #region

                        //    //        drNew = dt.NewRow();
                        //    //        drNew["UserName"] = txtUsername.Text;
                        //    //        drNew["screencode"] = OrderFormMenu.Rows[vLoop].Cells[3].Text;
                        //    //        drNew["Screen"] = OrderFormMenu.Rows[vLoop].Cells[1].Text;

                        //    //        lblDebtorID = (Label)OrderFormMenu.Rows[vLoop].FindControl("lblDebtorID");
                        //    //        drNew["screenid"] = lblDebtorID.Text;

                        //    //        drNew["Active"] = Add;
                        //    //        drNew["Read"] = Read;
                        //    //        drNew["Edit"] = Edit;
                        //    //        drNew["Delete"] = Delete;
                        //    //        drNew["Save"] = Save;
                        //    //        #endregion
                        //    //        ds.Tables[0].Rows.Add(drNew);
                        //    //        #endregion
                        //    //    }

                        //    //    for (int vLoop = 0; vLoop < grdinventory.Rows.Count; vLoop++)
                        //    //    {
                        //    //        #region

                        //    //        #region

                        //    //        CheckBox txt = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkboxAdd");
                        //    //        if (txt.Checked)
                        //    //        {
                        //    //            Add = txt.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Add = false;
                        //    //        }
                        //    //        CheckBox chkRead = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkRead");
                        //    //        if (chkRead.Checked)
                        //    //        {
                        //    //            Read = chkRead.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Read = false;
                        //    //        }
                        //    //        CheckBox chkEdit = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkEdit");
                        //    //        if (chkEdit.Checked)
                        //    //        {
                        //    //            Edit = chkEdit.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Edit = false;
                        //    //        }
                        //    //        CheckBox chkDelete = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkDelete");
                        //    //        if (chkDelete.Checked)
                        //    //        {
                        //    //            Delete = chkDelete.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Delete = false;
                        //    //        }
                        //    //        CheckBox chkSave = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkSave");
                        //    //        if (chkSave.Checked)
                        //    //        {
                        //    //            Save = chkSave.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Save = false;
                        //    //        }




                        //    //        #endregion

                        //    //        if ((txt.Checked == true))
                        //    //        {
                        //    //            drNewt = dtt.NewRow();
                        //    //            drNewt["UserName"] = txtUsername.Text;
                        //    //            drNewt["Screen"] = grdinventory.Rows[vLoop].Cells[3].Text;
                        //    //            dsroles.Tables[0].Rows.Add(drNewt);
                        //    //        }

                        //    //        #region

                        //    //        drNew = dt.NewRow();
                        //    //        drNew["UserName"] = txtUsername.Text;
                        //    //        drNew["screencode"] = grdinventory.Rows[vLoop].Cells[3].Text;
                        //    //        drNew["Screen"] = grdinventory.Rows[vLoop].Cells[1].Text;

                        //    //        lblDebtorID = (Label)grdinventory.Rows[vLoop].FindControl("lblDebtorID");
                        //    //        drNew["screenid"] = lblDebtorID.Text;

                        //    //        drNew["Active"] = Add;
                        //    //        drNew["Read"] = Read;
                        //    //        drNew["Edit"] = Edit;
                        //    //        drNew["Delete"] = Delete;
                        //    //        drNew["Save"] = Save;
                        //    //        #endregion
                        //    //        ds.Tables[0].Rows.Add(drNew);
                        //    //        #endregion
                        //    //    }

                        //    //    for (int vLoop = 0; vLoop < grRequestAccept.Rows.Count; vLoop++)
                        //    //    {
                        //    //        #region

                        //    //        #region

                        //    //        CheckBox txt = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkboxAdd");
                        //    //        if (txt.Checked)
                        //    //        {
                        //    //            Add = txt.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Add = false;
                        //    //        }
                        //    //        CheckBox chkRead = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkRead");
                        //    //        if (chkRead.Checked)
                        //    //        {
                        //    //            Read = chkRead.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Read = false;
                        //    //        }
                        //    //        CheckBox chkEdit = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkEdit");
                        //    //        if (chkEdit.Checked)
                        //    //        {
                        //    //            Edit = chkEdit.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Edit = false;
                        //    //        }
                        //    //        CheckBox chkDelete = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkDelete");
                        //    //        if (chkDelete.Checked)
                        //    //        {
                        //    //            Delete = chkDelete.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Delete = false;
                        //    //        }
                        //    //        CheckBox chkSave = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkSave");
                        //    //        if (chkSave.Checked)
                        //    //        {
                        //    //            Save = chkSave.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Save = false;
                        //    //        }




                        //    //        #endregion

                        //    //        if ((txt.Checked == true))
                        //    //        {
                        //    //            drNewt = dtt.NewRow();
                        //    //            drNewt["UserName"] = txtUsername.Text;
                        //    //            drNewt["Screen"] = grRequestAccept.Rows[vLoop].Cells[3].Text;
                        //    //            dsroles.Tables[0].Rows.Add(drNewt);
                        //    //        }

                        //    //        #region

                        //    //        drNew = dt.NewRow();
                        //    //        drNew["UserName"] = txtUsername.Text;
                        //    //        drNew["screencode"] = grRequestAccept.Rows[vLoop].Cells[3].Text;
                        //    //        drNew["Screen"] = grRequestAccept.Rows[vLoop].Cells[1].Text;

                        //    //        lblDebtorID = (Label)grRequestAccept.Rows[vLoop].FindControl("lblDebtorID");
                        //    //        drNew["screenid"] = lblDebtorID.Text;

                        //    //        drNew["Active"] = Add;
                        //    //        drNew["Read"] = Read;
                        //    //        drNew["Edit"] = Edit;
                        //    //        drNew["Delete"] = Delete;
                        //    //        drNew["Save"] = Save;
                        //    //        #endregion
                        //    //        ds.Tables[0].Rows.Add(drNew);
                        //    //        #endregion
                        //    //    }

                        //    //    for (int vLoop = 0; vLoop < grdreport.Rows.Count; vLoop++)
                        //    //    {
                        //    //        #region

                        //    //        #region

                        //    //        CheckBox txt = (CheckBox)grdreport.Rows[vLoop].FindControl("chkboxAdd");
                        //    //        if (txt.Checked)
                        //    //        {
                        //    //            Add = txt.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Add = false;
                        //    //        }
                        //    //        CheckBox chkRead = (CheckBox)grdreport.Rows[vLoop].FindControl("chkRead");
                        //    //        if (chkRead.Checked)
                        //    //        {
                        //    //            Read = chkRead.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Read = false;
                        //    //        }
                        //    //        CheckBox chkEdit = (CheckBox)grdreport.Rows[vLoop].FindControl("chkEdit");
                        //    //        if (chkEdit.Checked)
                        //    //        {
                        //    //            Edit = chkEdit.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Edit = false;
                        //    //        }
                        //    //        CheckBox chkDelete = (CheckBox)grdreport.Rows[vLoop].FindControl("chkDelete");
                        //    //        if (chkDelete.Checked)
                        //    //        {
                        //    //            Delete = chkDelete.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Delete = false;
                        //    //        }
                        //    //        CheckBox chkSave = (CheckBox)grdreport.Rows[vLoop].FindControl("chkSave");
                        //    //        if (chkSave.Checked)
                        //    //        {
                        //    //            Save = chkSave.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Save = false;
                        //    //        }




                        //    //        #endregion

                        //    //        if ((txt.Checked == true))
                        //    //        {
                        //    //            drNewt = dtt.NewRow();
                        //    //            drNewt["UserName"] = txtUsername.Text;
                        //    //            drNewt["Screen"] = grdreport.Rows[vLoop].Cells[3].Text;
                        //    //            dsroles.Tables[0].Rows.Add(drNewt);
                        //    //        }

                        //    //        #region

                        //    //        drNew = dt.NewRow();
                        //    //        drNew["UserName"] = txtUsername.Text;
                        //    //        drNew["screencode"] = grdreport.Rows[vLoop].Cells[3].Text;
                        //    //        drNew["Screen"] = grdreport.Rows[vLoop].Cells[1].Text;

                        //    //        lblDebtorID = (Label)grdreport.Rows[vLoop].FindControl("lblDebtorID");
                        //    //        drNew["screenid"] = lblDebtorID.Text;

                        //    //        drNew["Active"] = Add;
                        //    //        drNew["Read"] = Read;
                        //    //        drNew["Edit"] = Edit;
                        //    //        drNew["Delete"] = Delete;
                        //    //        drNew["Save"] = Save;
                        //    //        #endregion
                        //    //        ds.Tables[0].Rows.Add(drNew);
                        //    //        #endregion
                        //    //    }

                        //    //    for (int vLoop = 0; vLoop < grddetailedreport.Rows.Count; vLoop++)
                        //    //    {
                        //    //        #region

                        //    //        #region

                        //    //        CheckBox txt = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkboxAdd");
                        //    //        if (txt.Checked)
                        //    //        {
                        //    //            Add = txt.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Add = false;
                        //    //        }
                        //    //        CheckBox chkRead = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkRead");
                        //    //        if (chkRead.Checked)
                        //    //        {
                        //    //            Read = chkRead.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Read = false;
                        //    //        }
                        //    //        CheckBox chkEdit = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkEdit");
                        //    //        if (chkEdit.Checked)
                        //    //        {
                        //    //            Edit = chkEdit.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Edit = false;
                        //    //        }
                        //    //        CheckBox chkDelete = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkDelete");
                        //    //        if (chkDelete.Checked)
                        //    //        {
                        //    //            Delete = chkDelete.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Delete = false;
                        //    //        }
                        //    //        CheckBox chkSave = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkSave");
                        //    //        if (chkSave.Checked)
                        //    //        {
                        //    //            Save = chkSave.Checked;
                        //    //        }
                        //    //        else
                        //    //        {
                        //    //            Save = false;
                        //    //        }




                        //    //        #endregion

                        //    //        if ((txt.Checked == true))
                        //    //        {
                        //    //            drNewt = dtt.NewRow();
                        //    //            drNewt["UserName"] = txtUsername.Text;
                        //    //            drNewt["Screen"] = grddetailedreport.Rows[vLoop].Cells[3].Text;
                        //    //            dsroles.Tables[0].Rows.Add(drNewt);
                        //    //        }

                        //    //        #region

                        //    //        drNew = dt.NewRow();
                        //    //        drNew["UserName"] = txtUsername.Text;
                        //    //        drNew["screencode"] = grddetailedreport.Rows[vLoop].Cells[3].Text;
                        //    //        drNew["Screen"] = grddetailedreport.Rows[vLoop].Cells[1].Text;

                        //    //        lblDebtorID = (Label)grddetailedreport.Rows[vLoop].FindControl("lblDebtorID");
                        //    //        drNew["screenid"] = lblDebtorID.Text;

                        //    //        drNew["Active"] = Add;
                        //    //        drNew["Read"] = Read;
                        //    //        drNew["Edit"] = Edit;
                        //    //        drNew["Delete"] = Delete;
                        //    //        drNew["Save"] = Save;
                        //    //        #endregion
                        //    //        ds.Tables[0].Rows.Add(drNew);
                        //    //        #endregion
                        //    //    }

                        //    #endregion

                        //    int iStatus1 = objBs.InserAdminUserAccess(ds);
                        //}





                        //foreach (ListItem listItem in chkType.Items)
                        //{
                        //    if (listItem.Text != "All")
                        //    {
                        //        if (listItem.Selected)
                        //        {
                        //            int idd1 = objBs.insert_TransdiscType(listItem.Value, listItem.Text);
                        //        }
                        //    }
                        //}
                        #endregion

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Saved Sucessfully');", true);
                        Response.Redirect("../Accountsbootstrap/PurchaseCompanyDetailsGrid.aspx");
                    }

                }
                else
                {
                    lblerror.Text = "Email  id Mandatory .Thank You!!!";
                }
            }

            else
            {

                //int Transdelete = objBs.Delete_TransAdminSetting(iCompanyID);

                //foreach (ListItem listItem in chkType.Items)
                //{
                //    if (listItem.Text != "All")
                //    {
                //        if (listItem.Selected)
                //        {
                //            int iddd = objBs.insert_TransAdminSetting(listItem.Value, listItem.Text, iCompanyID);
                //        }
                //    }
                //}

                string iCompanyID = Request.QueryString.Get("iCompanyID");

                int iStatus = objBs.SubEditCompanyDetails(txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, txtGstNo.Text, txtWebSite.Text, txtSocial.Text, Convert.ToInt32(0), Imagepath, Imagepath2, Imagepath3, Imagepath4, txtUsername.Text, txtPasswprd.Text, txtEmpCode.Text, txtNoOfBranch.Text, drpbranchtype.SelectedValue, txtAboutUs.Text, DigitalMenu, Ecommerce, iCompanyID);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Updated Sucessfully');", true);
                Response.Redirect("../Accountsbootstrap/PurchaseCompanyDetailsGrid.aspx");
            }

           
        }


        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("../Images/") + fileName);
                lblFile_Path.Text = "../Images/" + FileUpload1.PostedFile.FileName;
                img_Photo.ImageUrl = "../Images/" + FileUpload1.PostedFile.FileName;
            }
        }

        protected void btnUpload2_Clickimg(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                FileUpload2.PostedFile.SaveAs(Server.MapPath("../Images/") + fileName);
                lblFile_Path2.Text = "../Images/" + FileUpload2.PostedFile.FileName;
                img_Photo2.ImageUrl = "../Images/" + FileUpload2.PostedFile.FileName;
            }
        }
        protected void btnUpload3_Clickimg(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
                FileUpload3.PostedFile.SaveAs(Server.MapPath("../Images/") + fileName);
                lblFile_Path3.Text = "../Images/" + FileUpload3.PostedFile.FileName;
                img_Photo3.ImageUrl = "../Images/" + FileUpload3.PostedFile.FileName;
            }
        }
        protected void btnUpload4_Clickimg(object sender, EventArgs e)
        {
            if (FileUpload4.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
                FileUpload4.PostedFile.SaveAs(Server.MapPath("../Images/") + fileName);
                lblFile_Path4.Text = "../Images/" + FileUpload4.PostedFile.FileName;
                img_Photo4.ImageUrl = "../Images/" + FileUpload4.PostedFile.FileName;
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnadd.Text = "Update";
            txtcompanyID.Enabled = true;
            txtcustomername.Enabled = true;
            txtmobileno.Enabled = true;
            txtphoneno.Enabled = true;
            txtaddress.Enabled = true;
            txtarea.Enabled = true;
            txtpincode.Enabled = true;
            txtemail.Enabled = true;
            txtcity.Enabled = true;
        }


        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        protected void chkRead_OnCheckedChangedadd1(object sender, EventArgs e)
        {
            for (int i = 0; i < grdmaster.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)grdmaster.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)grdmaster.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)grdmaster.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)grdmaster.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)grdmaster.Rows[i].FindControl("chkboxAdd");


                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkboxAdd.Checked == true)
                //{
                //    chkRead.Checked = true;
                //}
                //else
                //{
                //    chkRead.Checked = false;
                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
            }
        }
        protected void chkRead_OnCheckedChanged1(object sender, EventArgs e)
        {
            for (int i = 0; i < grdmaster.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)grdmaster.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)grdmaster.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)grdmaster.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)grdmaster.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)grdmaster.Rows[i].FindControl("chkboxAdd");

                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkRead.Checked == true)
                //{
                //    chkboxAdd.Checked = true;

                //    chkEdit.Enabled = false;
                //    chkDelete.Enabled = false;
                //    chkSave.Enabled = false;

                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
                //else
                //{
                //    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                //    {
                //        chkboxAdd.Checked = false;
                //    }
                //    else
                //    {
                //        if (chkEdit.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkDelete.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkSave.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }

                //    }

                //    chkEdit.Enabled = true;
                //    chkDelete.Enabled = true;
                //    chkSave.Enabled = true;
                //}
            }

        }

        protected void chkRead_OnCheckedChangedadd2(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderFormMenu.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkboxAdd");

                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkboxAdd.Checked == true)
                //{
                //    chkRead.Checked = true;
                //}
                //else
                //{
                //    chkRead.Checked = false;
                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
            }
        }
        protected void chkRead_OnCheckedChanged2(object sender, EventArgs e)
        {
            for (int i = 0; i < OrderFormMenu.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)OrderFormMenu.Rows[i].FindControl("chkboxAdd");

                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkRead.Checked == true)
                //{
                //    chkboxAdd.Checked = true;

                //    chkEdit.Enabled = false;
                //    chkDelete.Enabled = false;
                //    chkSave.Enabled = false;

                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
                //else
                //{
                //    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                //    {
                //        chkboxAdd.Checked = false;
                //    }
                //    else
                //    {
                //        if (chkEdit.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkDelete.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkSave.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }

                //    }

                //    chkEdit.Enabled = true;
                //    chkDelete.Enabled = true;
                //    chkSave.Enabled = true;
                //}
            }

        }

        protected void chkRead_OnCheckedChangedadd3(object sender, EventArgs e)
        {
            for (int i = 0; i < grdinventory.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)grdinventory.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)grdinventory.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)grdinventory.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)grdinventory.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)grdinventory.Rows[i].FindControl("chkboxAdd");


                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkboxAdd.Checked == true)
                //{
                //    chkRead.Checked = true;
                //}
                //else
                //{
                //    chkRead.Checked = false;
                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
            }
        }
        protected void chkRead_OnCheckedChanged3(object sender, EventArgs e)
        {
            for (int i = 0; i < grdinventory.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)grdinventory.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)grdinventory.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)grdinventory.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)grdinventory.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)grdinventory.Rows[i].FindControl("chkboxAdd");


                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkRead.Checked == true)
                //{
                //    chkboxAdd.Checked = true;

                //    chkEdit.Enabled = false;
                //    chkDelete.Enabled = false;
                //    chkSave.Enabled = false;

                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
                //else
                //{
                //    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                //    {
                //        chkboxAdd.Checked = false;
                //    }
                //    else
                //    {
                //        if (chkEdit.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkDelete.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkSave.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }

                //    }

                //    chkEdit.Enabled = true;
                //    chkDelete.Enabled = true;
                //    chkSave.Enabled = true;
                //}
            }

        }

        protected void chkRead_OnCheckedChangedadd4(object sender, EventArgs e)
        {
            for (int i = 0; i < grRequestAccept.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)grRequestAccept.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)grRequestAccept.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)grRequestAccept.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)grRequestAccept.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)grRequestAccept.Rows[i].FindControl("chkboxAdd");

                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;
                //if (chkboxAdd.Checked == true)
                //{
                //    chkRead.Checked = true;
                //}
                //else
                //{
                //    chkRead.Checked = false;
                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
            }
        }
        protected void chkRead_OnCheckedChanged4(object sender, EventArgs e)
        {
            for (int i = 0; i < grRequestAccept.Rows.Count; i++)
            {
                CheckBox chkRead = (CheckBox)grRequestAccept.Rows[i].FindControl("chkRead");
                CheckBox chkEdit = (CheckBox)grRequestAccept.Rows[i].FindControl("chkEdit");
                CheckBox chkDelete = (CheckBox)grRequestAccept.Rows[i].FindControl("chkDelete");
                CheckBox chkSave = (CheckBox)grRequestAccept.Rows[i].FindControl("chkSave");

                CheckBox chkboxAdd = (CheckBox)grRequestAccept.Rows[i].FindControl("chkboxAdd");

                chkRead.Checked = true;
                chkEdit.Checked = true;
                chkDelete.Checked = true;
                chkSave.Checked = true;
                chkboxAdd.Checked = true;

                //if (chkRead.Checked == true)
                //{
                //    chkboxAdd.Checked = true;

                //    chkEdit.Enabled = false;
                //    chkDelete.Enabled = false;
                //    chkSave.Enabled = false;

                //    chkEdit.Checked = false;
                //    chkDelete.Checked = false;
                //    chkSave.Checked = false;
                //}
                //else
                //{
                //    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                //    {
                //        chkboxAdd.Checked = false;
                //    }
                //    else
                //    {
                //        if (chkEdit.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkDelete.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }
                //        if (chkSave.Checked == true)
                //        {
                //            chkboxAdd.Checked = true;
                //        }

                //    }

                //    chkEdit.Enabled = true;
                //    chkDelete.Enabled = true;
                //    chkSave.Enabled = true;
                //}
            }

        }


    }
}