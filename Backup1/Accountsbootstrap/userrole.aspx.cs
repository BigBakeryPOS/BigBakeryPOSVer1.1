using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using CommonLayer;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace Billing.Accountsbootstrap
{
    public partial class userrole : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        int superadmin = 0;
        string empid = "";
        string sTableName = "";
        string BranchType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            empid = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();

            if (!IsPostBack)
            {
                #region GetAllroles
                DataSet dsmsater = new DataSet();
                dsmsater = objBs.GetAllrolls("MasterMenu", "No", 0);
                grdmaster.DataSource = dsmsater;
                grdmaster.DataBind();

                DataSet dsOrderFormMenu = new DataSet();
                dsOrderFormMenu = objBs.GetAllrolls("OrderFormMenu", "No", 0);
                OrderFormMenu.DataSource = dsOrderFormMenu;
                OrderFormMenu.DataBind();

                DataSet dsinventory = new DataSet();
                dsinventory = objBs.GetAllrolls("InventoryMenu", "No", 0);
                grdinventory.DataSource = dsinventory;
                grdinventory.DataBind();

                DataSet RequestAccept = new DataSet();
                RequestAccept = objBs.GetAllrolls("RequestAccept", "No", 0);
                grRequestAccept.DataSource = RequestAccept;
                grRequestAccept.DataBind();


                DataSet dsreport = new DataSet();
                dsreport = objBs.GetAllrolls("Reports", "No", 0);
                grdreport.DataSource = dsreport;
                grdreport.DataBind();


                DataSet dsdetailedreport = new DataSet();
                dsdetailedreport = objBs.GetAllrolls("ReportsAccess", "No", 0);
                grddetailedreport.DataSource = dsdetailedreport;
                grddetailedreport.DataBind();
                #endregion

                DataSet dslogintype = objBs.getlogintype();
                if (dslogintype.Tables[0].Rows.Count > 0)
                {
                    drplogintype.DataSource = dslogintype;
                    drplogintype.DataTextField = "LoginTypeName";
                    drplogintype.DataValueField = "LoginType";
                    drplogintype.DataBind();
                    drplogintype.Items.Insert(0, "Select LoginType");
                }


                //drplogintype getlogintype

                divcode.Visible = false;

                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();


                int iCusID = Convert.ToInt32(Request.QueryString.Get("iCusID"));
                if (Convert.ToString(iCusID) != "" && iCusID != null && iCusID != 0)
                {
                    DataSet ds1 = objBs.getselectuserRoles(iCusID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Update";

                        txtUserid.Text = ds1.Tables[0].Rows[0]["RoleID"].ToString();
                        drplogintype.Enabled = false;
                        drplogintype.SelectedValue = ds1.Tables[0].Rows[0]["LogintypeID"].ToString();

                        #region Rights Set

                        int idd = Convert.ToInt32(txtUserid.Text);

                        DataSet dsmsater1 = new DataSet();
                        dsmsater1 = objBs.grtroll_View("MasterMenu", "Yes", idd);
                        for (int vLoop = 0; vLoop < grdmaster.Rows.Count; vLoop++)
                        {
                            Label txtsno = (Label)grdmaster.Rows[vLoop].FindControl("lblDebtorID");
                            for (int j = 0; j < dsmsater1.Tables[0].Rows.Count; j++)
                            {
                                string roleid = dsmsater1.Tables[0].Rows[j]["roleid"].ToString();

                                bool Add = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Visible"]);
                                bool Read = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Read"]);
                                bool Edit = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Edit"]);
                                bool Delete = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Delete"]);
                                bool Save = Convert.ToBoolean(dsmsater1.Tables[0].Rows[j]["Save"]);

                                if (roleid == txtsno.Text)
                                {

                                    CheckBox chkboxAdd = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkboxAdd");

                                    CheckBox chkRead = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkRead");
                                    CheckBox chkEdit = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkEdit");
                                    CheckBox chkDelete = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkDelete");
                                    CheckBox chkSave = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkSave");

                                    chkboxAdd.Checked = Add;
                                    chkRead.Checked = Read;
                                    chkEdit.Checked = Edit;
                                    chkDelete.Checked = Delete;
                                    chkSave.Checked = Save;
                                }
                            }
                        }
                        //  grdmaster.DataSource = dsmsater1;
                        //  grdmaster.DataBind();

                        DataSet dsOrderFormMenu1 = new DataSet();
                        dsOrderFormMenu1 = objBs.grtroll_View("OrderFormMenu", "Yes", idd);
                        // OrderFormMenu.DataSource = dsOrderFormMenu1;
                        //  OrderFormMenu.DataBind();
                        for (int vLoop = 0; vLoop < OrderFormMenu.Rows.Count; vLoop++)
                        {
                            Label txtsno = (Label)OrderFormMenu.Rows[vLoop].FindControl("lblDebtorID");
                            for (int j = 0; j < dsOrderFormMenu1.Tables[0].Rows.Count; j++)
                            {
                                string roleid = dsOrderFormMenu1.Tables[0].Rows[j]["roleid"].ToString();

                                bool Add = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Visible"]);
                                bool Read = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Read"]);
                                bool Edit = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Edit"]);
                                bool Delete = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Delete"]);
                                bool Save = Convert.ToBoolean(dsOrderFormMenu1.Tables[0].Rows[j]["Save"]);

                                if (roleid == txtsno.Text)
                                {

                                    CheckBox chkboxAdd = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkboxAdd");

                                    CheckBox chkRead = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkRead");
                                    CheckBox chkEdit = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkEdit");
                                    CheckBox chkDelete = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkDelete");
                                    CheckBox chkSave = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkSave");

                                    chkboxAdd.Checked = Add;
                                    chkRead.Checked = Read;
                                    chkEdit.Checked = Edit;
                                    chkDelete.Checked = Delete;
                                    chkSave.Checked = Save;
                                }
                            }
                        }

                        DataSet dsinventory1 = new DataSet();
                        dsinventory1 = objBs.grtroll_View("InventoryMenu", "Yes", idd);
                        for (int vLoop = 0; vLoop < grdinventory.Rows.Count; vLoop++)
                        {
                            Label txtsno = (Label)grdinventory.Rows[vLoop].FindControl("lblDebtorID");
                            for (int j = 0; j < dsinventory1.Tables[0].Rows.Count; j++)
                            {
                                string roleid = dsinventory1.Tables[0].Rows[j]["roleid"].ToString();

                                bool Add = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Visible"]);
                                bool Read = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Read"]);
                                bool Edit = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Edit"]);
                                bool Delete = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Delete"]);
                                bool Save = Convert.ToBoolean(dsinventory1.Tables[0].Rows[j]["Save"]);

                                if (roleid == txtsno.Text)
                                {

                                    CheckBox chkboxAdd = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkboxAdd");

                                    CheckBox chkRead = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkRead");
                                    CheckBox chkEdit = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkEdit");
                                    CheckBox chkDelete = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkDelete");
                                    CheckBox chkSave = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkSave");

                                    chkboxAdd.Checked = Add;
                                    chkRead.Checked = Read;
                                    chkEdit.Checked = Edit;
                                    chkDelete.Checked = Delete;
                                    chkSave.Checked = Save;
                                }
                            }
                        }
                        // grdinventory.DataSource = dsinventory1;
                        //grdinventory.DataBind();

                        DataSet RequestAccept1 = new DataSet();
                        RequestAccept1 = objBs.grtroll_View("RequestAccept", "Yes", idd);
                        // grRequestAccept.DataSource = RequestAccept1;
                        //  grRequestAccept.DataBind();
                        for (int vLoop = 0; vLoop < grRequestAccept.Rows.Count; vLoop++)
                        {
                            Label txtsno = (Label)grRequestAccept.Rows[vLoop].FindControl("lblDebtorID");
                            for (int j = 0; j < RequestAccept1.Tables[0].Rows.Count; j++)
                            {
                                string roleid = RequestAccept1.Tables[0].Rows[j]["roleid"].ToString();

                                bool Add = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Visible"]);
                                bool Read = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Read"]);
                                bool Edit = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Edit"]);
                                bool Delete = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Delete"]);
                                bool Save = Convert.ToBoolean(RequestAccept1.Tables[0].Rows[j]["Save"]);

                                if (roleid == txtsno.Text)
                                {

                                    CheckBox chkboxAdd = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkboxAdd");

                                    CheckBox chkRead = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkRead");
                                    CheckBox chkEdit = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkEdit");
                                    CheckBox chkDelete = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkDelete");
                                    CheckBox chkSave = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkSave");

                                    chkboxAdd.Checked = Add;
                                    chkRead.Checked = Read;
                                    chkEdit.Checked = Edit;
                                    chkDelete.Checked = Delete;
                                    chkSave.Checked = Save;
                                }
                            }
                        }


                        DataSet dsreport1 = new DataSet();
                        dsreport1 = objBs.grtroll_View("Reports", "Yes", idd);
                        //  grdreport.DataSource = dsreport1;
                        //  grdreport.DataBind();
                        for (int vLoop = 0; vLoop < grdreport.Rows.Count; vLoop++)
                        {
                            Label txtsno = (Label)grdreport.Rows[vLoop].FindControl("lblDebtorID");
                            for (int j = 0; j < dsreport1.Tables[0].Rows.Count; j++)
                            {
                                string roleid = dsreport1.Tables[0].Rows[j]["roleid"].ToString();

                                bool Add = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Visible"]);
                                bool Read = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Read"]);
                                bool Edit = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Edit"]);
                                bool Delete = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Delete"]);
                                bool Save = Convert.ToBoolean(dsreport1.Tables[0].Rows[j]["Save"]);

                                if (roleid == txtsno.Text)
                                {

                                    CheckBox chkboxAdd = (CheckBox)grdreport.Rows[vLoop].FindControl("chkboxAdd");

                                    CheckBox chkRead = (CheckBox)grdreport.Rows[vLoop].FindControl("chkRead");
                                    CheckBox chkEdit = (CheckBox)grdreport.Rows[vLoop].FindControl("chkEdit");
                                    CheckBox chkDelete = (CheckBox)grdreport.Rows[vLoop].FindControl("chkDelete");
                                    CheckBox chkSave = (CheckBox)grdreport.Rows[vLoop].FindControl("chkSave");

                                    chkboxAdd.Checked = Add;
                                    chkRead.Checked = Read;
                                    chkEdit.Checked = Edit;
                                    chkDelete.Checked = Delete;
                                    chkSave.Checked = Save;
                                }
                            }
                        }

                        DataSet dsdetailedreport1 = new DataSet();
                        dsdetailedreport1 = objBs.grtroll_View("ReportsAccess", "Yes", idd);
                        //  grdreport.DataSource = dsreport1;
                        //  grdreport.DataBind();
                        for (int vLoop = 0; vLoop < grddetailedreport.Rows.Count; vLoop++)
                        {
                            Label txtsno = (Label)grddetailedreport.Rows[vLoop].FindControl("lblDebtorID");
                            for (int j = 0; j < dsdetailedreport1.Tables[0].Rows.Count; j++)
                            {
                                string roleid = dsdetailedreport1.Tables[0].Rows[j]["roleid"].ToString();

                                bool Add = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Visible"]);
                                bool Read = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Read"]);
                                bool Edit = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Edit"]);
                                bool Delete = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Delete"]);
                                bool Save = Convert.ToBoolean(dsdetailedreport1.Tables[0].Rows[j]["Save"]);

                                if (roleid == txtsno.Text)
                                {

                                    CheckBox chkboxAdd = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkboxAdd");

                                    CheckBox chkRead = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkRead");
                                    CheckBox chkEdit = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkEdit");
                                    CheckBox chkDelete = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkDelete");
                                    CheckBox chkSave = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkSave");

                                    chkboxAdd.Checked = Add;
                                    chkRead.Checked = Read;
                                    chkEdit.Checked = Edit;
                                    chkDelete.Checked = Delete;
                                    chkSave.Checked = Save;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (drplogintype.SelectedValue == "Select LoginType")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Login-Type.Thank You!!!.')", true);
                return;
            }
            string Mode = Request.QueryString.Get("Mode");

            DataSet ds;
            DataTable dt;
            DataRow drNew;
            DataSet dsBranch;
            DataTable dtBranch;
            DataColumn dc;

            ds = new DataSet();

            dt = new DataTable();

            dc = new DataColumn("UserName");
            dt.Columns.Add(dc);

            dc = new DataColumn("Screen");
            dt.Columns.Add(dc);

            dc = new DataColumn("screenid");
            dt.Columns.Add(dc);

            dc = new DataColumn("screencode");
            dt.Columns.Add(dc);

            dc = new DataColumn("Active");
            dt.Columns.Add(dc);

            dc = new DataColumn("Read");
            dt.Columns.Add(dc);
            dc = new DataColumn("Edit");
            dt.Columns.Add(dc);
            dc = new DataColumn("Delete");
            dt.Columns.Add(dc);
            dc = new DataColumn("Save");
            dt.Columns.Add(dc);

            ds.Tables.Add(dt);
            bool Add = false;

            bool Read = false;
            bool Edit = false;
            bool Delete = false;
            bool Save = false;


            DataSet dsroles = new DataSet();
            DataTable dtt = new DataTable();
            DataRow drNewt;
            DataColumn dcc;
            dcc = new DataColumn("UserName");
            dtt.Columns.Add(dcc);

            dcc = new DataColumn("Screen");
            dtt.Columns.Add(dcc);
            dsroles.Tables.Add(dtt);

            bool Views = false;
            Label lblDebtorID = null;

            for (int vLoop = 0; vLoop < grdmaster.Rows.Count; vLoop++)
            {
                #region
                #region

                CheckBox txt = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkboxAdd");
                if (txt.Checked)
                {
                    Add = txt.Checked;
                }
                else
                {
                    Add = false;
                }
                CheckBox chkRead = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkRead");
                if (chkRead.Checked)
                {
                    Read = chkRead.Checked;
                }
                else
                {
                    Read = false;
                }
                CheckBox chkEdit = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkEdit");
                if (chkEdit.Checked)
                {
                    Edit = chkEdit.Checked;
                }
                else
                {
                    Edit = false;
                }
                CheckBox chkDelete = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkDelete");
                if (chkDelete.Checked)
                {
                    Delete = chkDelete.Checked;
                }
                else
                {
                    Delete = false;
                }
                CheckBox chkSave = (CheckBox)grdmaster.Rows[vLoop].FindControl("chkSave");
                if (chkSave.Checked)
                {
                    Save = chkSave.Checked;
                }
                else
                {
                    Save = false;
                }




                #endregion

                if ((txt.Checked == true))
                {
                    drNewt = dtt.NewRow();
                    drNewt["UserName"] = drplogintype.SelectedItem.Text;
                    drNewt["Screen"] = grdmaster.Rows[vLoop].Cells[3].Text;
                    dsroles.Tables[0].Rows.Add(drNewt);
                }

                #region

                drNew = dt.NewRow();
                drNew["UserName"] = drplogintype.SelectedItem.Text;
                drNew["screencode"] = grdmaster.Rows[vLoop].Cells[3].Text;
                drNew["Screen"] = grdmaster.Rows[vLoop].Cells[1].Text;

                lblDebtorID = (Label)grdmaster.Rows[vLoop].FindControl("lblDebtorID");
                drNew["screenid"] = lblDebtorID.Text;

                drNew["Active"] = Add;

                drNew["Read"] = Read;
                drNew["Edit"] = Edit;
                drNew["Delete"] = Delete;
                drNew["Save"] = Save;

                #endregion

                ds.Tables[0].Rows.Add(drNew);
                #endregion
            }

            for (int vLoop = 0; vLoop < OrderFormMenu.Rows.Count; vLoop++)
            {
                #region

                #region

                CheckBox txt = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkboxAdd");
                if (txt.Checked)
                {
                    Add = txt.Checked;
                }
                else
                {
                    Add = false;
                }
                CheckBox chkRead = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkRead");
                if (chkRead.Checked)
                {
                    Read = chkRead.Checked;
                }
                else
                {
                    Read = false;
                }
                CheckBox chkEdit = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkEdit");
                if (chkEdit.Checked)
                {
                    Edit = chkEdit.Checked;
                }
                else
                {
                    Edit = false;
                }
                CheckBox chkDelete = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkDelete");
                if (chkDelete.Checked)
                {
                    Delete = chkDelete.Checked;
                }
                else
                {
                    Delete = false;
                }
                CheckBox chkSave = (CheckBox)OrderFormMenu.Rows[vLoop].FindControl("chkSave");
                if (chkSave.Checked)
                {
                    Save = chkSave.Checked;
                }
                else
                {
                    Save = false;
                }




                #endregion

                if ((txt.Checked == true))
                {
                    drNewt = dtt.NewRow();
                    drNewt["UserName"] = drplogintype.SelectedItem.Text;
                    drNewt["Screen"] = OrderFormMenu.Rows[vLoop].Cells[3].Text;
                    dsroles.Tables[0].Rows.Add(drNewt);
                }

                #region

                drNew = dt.NewRow();
                drNew["UserName"] = drplogintype.SelectedItem.Text;
                drNew["screencode"] = OrderFormMenu.Rows[vLoop].Cells[3].Text;
                drNew["Screen"] = OrderFormMenu.Rows[vLoop].Cells[1].Text;

                lblDebtorID = (Label)OrderFormMenu.Rows[vLoop].FindControl("lblDebtorID");
                drNew["screenid"] = lblDebtorID.Text;

                drNew["Active"] = Add;
                drNew["Read"] = Read;
                drNew["Edit"] = Edit;
                drNew["Delete"] = Delete;
                drNew["Save"] = Save;
                #endregion
                ds.Tables[0].Rows.Add(drNew);
                #endregion
            }

            for (int vLoop = 0; vLoop < grdinventory.Rows.Count; vLoop++)
            {
                #region

                #region

                CheckBox txt = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkboxAdd");
                if (txt.Checked)
                {
                    Add = txt.Checked;
                }
                else
                {
                    Add = false;
                }
                CheckBox chkRead = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkRead");
                if (chkRead.Checked)
                {
                    Read = chkRead.Checked;
                }
                else
                {
                    Read = false;
                }
                CheckBox chkEdit = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkEdit");
                if (chkEdit.Checked)
                {
                    Edit = chkEdit.Checked;
                }
                else
                {
                    Edit = false;
                }
                CheckBox chkDelete = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkDelete");
                if (chkDelete.Checked)
                {
                    Delete = chkDelete.Checked;
                }
                else
                {
                    Delete = false;
                }
                CheckBox chkSave = (CheckBox)grdinventory.Rows[vLoop].FindControl("chkSave");
                if (chkSave.Checked)
                {
                    Save = chkSave.Checked;
                }
                else
                {
                    Save = false;
                }




                #endregion

                if ((txt.Checked == true))
                {
                    drNewt = dtt.NewRow();
                    drNewt["UserName"] = drplogintype.SelectedItem.Text;
                    drNewt["Screen"] = grdinventory.Rows[vLoop].Cells[3].Text;
                    dsroles.Tables[0].Rows.Add(drNewt);
                }

                #region

                drNew = dt.NewRow();
                drNew["UserName"] = drplogintype.SelectedItem.Text;
                drNew["screencode"] = grdinventory.Rows[vLoop].Cells[3].Text;
                drNew["Screen"] = grdinventory.Rows[vLoop].Cells[1].Text;

                lblDebtorID = (Label)grdinventory.Rows[vLoop].FindControl("lblDebtorID");
                drNew["screenid"] = lblDebtorID.Text;

                drNew["Active"] = Add;
                drNew["Read"] = Read;
                drNew["Edit"] = Edit;
                drNew["Delete"] = Delete;
                drNew["Save"] = Save;
                #endregion
                ds.Tables[0].Rows.Add(drNew);
                #endregion
            }

            for (int vLoop = 0; vLoop < grRequestAccept.Rows.Count; vLoop++)
            {
                #region

                #region

                CheckBox txt = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkboxAdd");
                if (txt.Checked)
                {
                    Add = txt.Checked;
                }
                else
                {
                    Add = false;
                }
                CheckBox chkRead = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkRead");
                if (chkRead.Checked)
                {
                    Read = chkRead.Checked;
                }
                else
                {
                    Read = false;
                }
                CheckBox chkEdit = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkEdit");
                if (chkEdit.Checked)
                {
                    Edit = chkEdit.Checked;
                }
                else
                {
                    Edit = false;
                }
                CheckBox chkDelete = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkDelete");
                if (chkDelete.Checked)
                {
                    Delete = chkDelete.Checked;
                }
                else
                {
                    Delete = false;
                }
                CheckBox chkSave = (CheckBox)grRequestAccept.Rows[vLoop].FindControl("chkSave");
                if (chkSave.Checked)
                {
                    Save = chkSave.Checked;
                }
                else
                {
                    Save = false;
                }




                #endregion

                if ((txt.Checked == true))
                {
                    drNewt = dtt.NewRow();
                    drNewt["UserName"] = drplogintype.SelectedItem.Text;
                    drNewt["Screen"] = grRequestAccept.Rows[vLoop].Cells[3].Text;
                    dsroles.Tables[0].Rows.Add(drNewt);
                }

                #region

                drNew = dt.NewRow();
                drNew["UserName"] = drplogintype.SelectedItem.Text;
                drNew["screencode"] = grRequestAccept.Rows[vLoop].Cells[3].Text;
                drNew["Screen"] = grRequestAccept.Rows[vLoop].Cells[1].Text;

                lblDebtorID = (Label)grRequestAccept.Rows[vLoop].FindControl("lblDebtorID");
                drNew["screenid"] = lblDebtorID.Text;

                drNew["Active"] = Add;
                drNew["Read"] = Read;
                drNew["Edit"] = Edit;
                drNew["Delete"] = Delete;
                drNew["Save"] = Save;
                #endregion
                ds.Tables[0].Rows.Add(drNew);
                #endregion
            }

            for (int vLoop = 0; vLoop < grdreport.Rows.Count; vLoop++)
            {
                #region

                #region

                CheckBox txt = (CheckBox)grdreport.Rows[vLoop].FindControl("chkboxAdd");
                if (txt.Checked)
                {
                    Add = txt.Checked;
                }
                else
                {
                    Add = false;
                }
                CheckBox chkRead = (CheckBox)grdreport.Rows[vLoop].FindControl("chkRead");
                if (chkRead.Checked)
                {
                    Read = chkRead.Checked;
                }
                else
                {
                    Read = false;
                }
                CheckBox chkEdit = (CheckBox)grdreport.Rows[vLoop].FindControl("chkEdit");
                if (chkEdit.Checked)
                {
                    Edit = chkEdit.Checked;
                }
                else
                {
                    Edit = false;
                }
                CheckBox chkDelete = (CheckBox)grdreport.Rows[vLoop].FindControl("chkDelete");
                if (chkDelete.Checked)
                {
                    Delete = chkDelete.Checked;
                }
                else
                {
                    Delete = false;
                }
                CheckBox chkSave = (CheckBox)grdreport.Rows[vLoop].FindControl("chkSave");
                if (chkSave.Checked)
                {
                    Save = chkSave.Checked;
                }
                else
                {
                    Save = false;
                }




                #endregion

                if ((txt.Checked == true))
                {
                    drNewt = dtt.NewRow();
                    drNewt["UserName"] = drplogintype.SelectedItem.Text;
                    drNewt["Screen"] = grdreport.Rows[vLoop].Cells[3].Text;
                    dsroles.Tables[0].Rows.Add(drNewt);
                }

                #region

                drNew = dt.NewRow();
                drNew["UserName"] = drplogintype.SelectedItem.Text;
                drNew["screencode"] = grdreport.Rows[vLoop].Cells[3].Text;
                drNew["Screen"] = grdreport.Rows[vLoop].Cells[1].Text;

                lblDebtorID = (Label)grdreport.Rows[vLoop].FindControl("lblDebtorID");
                drNew["screenid"] = lblDebtorID.Text;

                drNew["Active"] = Add;
                drNew["Read"] = Read;
                drNew["Edit"] = Edit;
                drNew["Delete"] = Delete;
                drNew["Save"] = Save;
                #endregion
                ds.Tables[0].Rows.Add(drNew);
                #endregion
            }

            for (int vLoop = 0; vLoop < grddetailedreport.Rows.Count; vLoop++)
            {
                #region

                #region

                CheckBox txt = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkboxAdd");
                if (txt.Checked)
                {
                    Add = txt.Checked;
                }
                else
                {
                    Add = false;
                }
                CheckBox chkRead = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkRead");
                if (chkRead.Checked)
                {
                    Read = chkRead.Checked;
                }
                else
                {
                    Read = false;
                }
                CheckBox chkEdit = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkEdit");
                if (chkEdit.Checked)
                {
                    Edit = chkEdit.Checked;
                }
                else
                {
                    Edit = false;
                }
                CheckBox chkDelete = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkDelete");
                if (chkDelete.Checked)
                {
                    Delete = chkDelete.Checked;
                }
                else
                {
                    Delete = false;
                }
                CheckBox chkSave = (CheckBox)grddetailedreport.Rows[vLoop].FindControl("chkSave");
                if (chkSave.Checked)
                {
                    Save = chkSave.Checked;
                }
                else
                {
                    Save = false;
                }




                #endregion

                if ((txt.Checked == true))
                {
                    drNewt = dtt.NewRow();
                    drNewt["UserName"] = drplogintype.SelectedItem.Text;
                    drNewt["Screen"] = grddetailedreport.Rows[vLoop].Cells[3].Text;
                    dsroles.Tables[0].Rows.Add(drNewt);
                }

                #region

                drNew = dt.NewRow();
                drNew["UserName"] = drplogintype.SelectedItem.Text;
                drNew["screencode"] = grddetailedreport.Rows[vLoop].Cells[3].Text;
                drNew["Screen"] = grddetailedreport.Rows[vLoop].Cells[1].Text;

                lblDebtorID = (Label)grddetailedreport.Rows[vLoop].FindControl("lblDebtorID");
                drNew["screenid"] = lblDebtorID.Text;

                drNew["Active"] = Add;
                drNew["Read"] = Read;
                drNew["Edit"] = Edit;
                drNew["Delete"] = Delete;
                drNew["Save"] = Save;
                #endregion
                ds.Tables[0].Rows.Add(drNew);
                #endregion
            }

            if (btnadd.Text == "Save")
            {
                if (drplogintype.SelectedValue != "Select LoginType")
                {
                    //DataSet ds = objBs.dsCheckRole_LoginType(drplogintype.SelectedValue);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Login-Type.Thank You!!!.')", true);
                    //    return;
                    //}
                }
                #region                                   
                int iStatus = objBs.insertRolewithaccess(drplogintype.SelectedValue, ds, Convert.ToInt32(empid));
                Response.Redirect("../Accountsbootstrap/UserRoleGrid.aspx");
                #endregion
            }
            else
            {
                #region               
                int iStatus = objBs.updateRolewithaccess(Convert.ToInt32(txtUserid.Text), drplogintype.SelectedValue, ds, Convert.ToInt32(empid));
                Response.Redirect("../Accountsbootstrap/UserRoleGrid.aspx");
            }
            #endregion
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

                if (chkboxAdd.Checked == true)
                {
                    chkRead.Checked = true;
                }
                else
                {
                    chkRead.Checked = false;
                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
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

                if (chkRead.Checked == true)
                {
                    chkboxAdd.Checked = true;

                    chkEdit.Enabled = false;
                    chkDelete.Enabled = false;
                    chkSave.Enabled = false;

                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
                else
                {
                    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                    {
                        chkboxAdd.Checked = false;
                    }
                    else
                    {
                        if (chkEdit.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkDelete.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkSave.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }

                    }

                    chkEdit.Enabled = true;
                    chkDelete.Enabled = true;
                    chkSave.Enabled = true;
                }
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

                if (chkboxAdd.Checked == true)
                {
                    chkRead.Checked = true;
                }
                else
                {
                    chkRead.Checked = false;
                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
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

                if (chkRead.Checked == true)
                {
                    chkboxAdd.Checked = true;

                    chkEdit.Enabled = false;
                    chkDelete.Enabled = false;
                    chkSave.Enabled = false;

                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
                else
                {
                    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                    {
                        chkboxAdd.Checked = false;
                    }
                    else
                    {
                        if (chkEdit.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkDelete.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkSave.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }

                    }

                    chkEdit.Enabled = true;
                    chkDelete.Enabled = true;
                    chkSave.Enabled = true;
                }
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

                if (chkboxAdd.Checked == true)
                {
                    chkRead.Checked = true;
                }
                else
                {
                    chkRead.Checked = false;
                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
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

                if (chkRead.Checked == true)
                {
                    chkboxAdd.Checked = true;

                    chkEdit.Enabled = false;
                    chkDelete.Enabled = false;
                    chkSave.Enabled = false;

                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
                else
                {
                    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                    {
                        chkboxAdd.Checked = false;
                    }
                    else
                    {
                        if (chkEdit.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkDelete.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkSave.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }

                    }

                    chkEdit.Enabled = true;
                    chkDelete.Enabled = true;
                    chkSave.Enabled = true;
                }
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

                if (chkboxAdd.Checked == true)
                {
                    chkRead.Checked = true;
                }
                else
                {
                    chkRead.Checked = false;
                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
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

                if (chkRead.Checked == true)
                {
                    chkboxAdd.Checked = true;

                    chkEdit.Enabled = false;
                    chkDelete.Enabled = false;
                    chkSave.Enabled = false;

                    chkEdit.Checked = false;
                    chkDelete.Checked = false;
                    chkSave.Checked = false;
                }
                else
                {
                    if (chkEdit.Checked == false && chkDelete.Checked == false && chkSave.Checked == false)
                    {
                        chkboxAdd.Checked = false;
                    }
                    else
                    {
                        if (chkEdit.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkDelete.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }
                        if (chkSave.Checked == true)
                        {
                            chkboxAdd.Checked = true;
                        }

                    }

                    chkEdit.Enabled = true;
                    chkDelete.Enabled = true;
                    chkSave.Enabled = true;
                }
            }

        }

    }
}
