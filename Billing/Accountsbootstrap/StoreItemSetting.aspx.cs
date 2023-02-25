using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class StoreItemSetting : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "StoreSettingId ASC";
        string sTableName = "";
        string superadmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblempname.Text = Request.Cookies["userInfo"]["Biller"].ToString();

            if (!IsPostBack)
            {
                UPD.Visible = false;
                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.gridstoresetting();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "STSIS");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "STSIS");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnSave.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gridview.Columns[3].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[3].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gridview.Columns[4].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[4].Visible = false;
                    }
                }

                DataSet dsbranch = objBs.gridloadingingitem();
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpstoreitem.DataSource = dsbranch.Tables[0];
                    drpstoreitem.DataTextField = "IngredientName";
                    drpstoreitem.DataValueField = "IngridID";
                    drpstoreitem.DataBind();
                    drpstoreitem.Items.Insert(0, "Select Store");

                }

                DataSet dsitem = objBs.gridloadingbranchitem();
                if (dsitem.Tables[0].Rows.Count > 0)
                {
                    drpbranchitem.DataSource = dsitem.Tables[0];
                    drpbranchitem.DataTextField = "Printitem";
                    drpbranchitem.DataValueField = "CategoryUserID";
                    drpbranchitem.DataBind();
                    drpbranchitem.Items.Insert(0, "Select Item");

                }
            }
        }

        protected void Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            // Response.Redirect("categorymaster.aspx");
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("StoreItemSetting.aspx");
        }
        protected void Btn_Search(object sender, EventArgs e)
        {

        }

        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                

                string iCat = e.CommandArgument.ToString();

                if (iCat != "" || iCat != null)
                {

                    DataSet dsbranch = objBs.gridloadingingitem();
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        drpstoreitem.DataSource = dsbranch.Tables[0];
                        drpstoreitem.DataTextField = "IngredientName";
                        drpstoreitem.DataValueField = "IngridID";
                        drpstoreitem.DataBind();
                        drpstoreitem.Items.Insert(0, "Select Store");

                    }

                    DataSet dsitem = objBs.gridloadingbranchitem();
                    if (dsitem.Tables[0].Rows.Count > 0)
                    {
                        drpbranchitem.DataSource = dsitem.Tables[0];
                        drpbranchitem.DataTextField = "Printitem";
                        drpbranchitem.DataValueField = "CategoryUserID";
                        drpbranchitem.DataBind();
                        drpbranchitem.Items.Insert(0, "Select Item");

                    }


                    DataSet ds = objBs.getupdateitemsettingforid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        UPD.Visible = true;
                        btnSave.Visible = true;
                        drpstoreitem.SelectedValue = ds.Tables[0].Rows[0]["Ingid"].ToString();
                        drpbranchitem.SelectedValue = ds.Tables[0].Rows[0]["Categoryuserid"].ToString();
                        txtstoresettingid.Text = ds.Tables[0].Rows[0]["StoreSettingId"].ToString();
                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["Isactive"].ToString();
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteitemsetting(e.CommandArgument.ToString());
                    Response.Redirect("StoreItemSetting.aspx");
                }
            }

        }


        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GVStockAlert_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }



        protected void GVStockAlert_RowDataBound()
        {

        }
        public SortDirection dir
        {

            get
            {

                if (ViewState["dirState"] == null)
                {

                    ViewState["dirState"] = SortDirection.Ascending;

                }

                return (SortDirection)ViewState["dirState"];

            }

            set
            {

                ViewState["dirState"] = value;

            }

        }

        protected void gridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (superadmin == "1" || sTableName == "Pro")
            //    {
            //        ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
            //        ((LinkButton)e.Row.FindControl("btndel")).Enabled = true;

            //        ((Image)e.Row.FindControl("imdedit")).Enabled = true;
            //        ((Image)e.Row.FindControl("Image1")).Enabled = true;
            //    }
            //    else
            //    {
            //        ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
            //        ((LinkButton)e.Row.FindControl("btndel")).Visible = false;

            //        ((Image)e.Row.FindControl("imdedit")).Enabled = false;
            //        ((Image)e.Row.FindControl("Image1")).Visible = false;

            //        ((Image)e.Row.FindControl("imgdisable1321")).Enabled = false;
            //        ((Image)e.Row.FindControl("imgdisable1321")).Visible = true;
            //    }

            //}
            //else
            //{

            //}

        }



        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }

            DataSet ds = objBs.gridstoresetting();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreItemSetting.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            if (drpstoreitem.SelectedValue == "Select Store")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Store Item.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            if (drpbranchitem.SelectedValue == "Select Item")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Seelct Branch Item.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.duplicateitemsettingcheck(drpstoreitem.SelectedValue,drpbranchitem.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Store/Branch Item has already Exists please Select new one";

                }
                else
                {
                    int iStatus = objBs.InsertstoritemSetting(drpstoreitem.SelectedValue, drpbranchitem.SelectedValue,lblempname.Text);
                    Response.Redirect("../Accountsbootstrap/StoreItemSetting.aspx");
                }
            }
            else
            {
                objBs.updatestoreitemsetting(drpstoreitem.SelectedValue,drpbranchitem.SelectedValue,drpisactive.SelectedValue,txtstoresettingid.Text,lblempname.Text);
                Response.Redirect("StoreItemSetting.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}
