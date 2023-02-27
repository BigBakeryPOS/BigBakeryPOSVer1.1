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
    public partial class BranchSetting : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "BranchId ASC";
        string sTableName = "";
        string superadmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
           

            if (!IsPostBack)
            {
                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "BranchSetting");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "BranchSetting");
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
                        gridview.Columns[4].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[4].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gridview.Columns[5].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[5].Visible = false;
                    }
                }

                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.gridbranchsetting();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                DataSet dsbranch = objBs.getbranchFilling("0");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpstorebranch.DataSource = dsbranch.Tables[0];
                    drpstorebranch.DataTextField = "BranchArea";
                    drpstorebranch.DataValueField = "BranchId";
                    drpstorebranch.DataBind();
                    drpstorebranch.Items.Insert(0, "Select Store");

                }

                DataSet dsprod = objBs.getbranchFilling("2");
                if (dsprod.Tables[0].Rows.Count > 0)
                {
                    DrpProductionBranch.DataSource = dsprod.Tables[0];
                    DrpProductionBranch.DataTextField = "BranchArea";
                    DrpProductionBranch.DataValueField = "BranchId";
                    DrpProductionBranch.DataBind();
                    DrpProductionBranch.Items.Insert(0, "Select Production");


                    Drpicingbranch.DataSource = dsprod.Tables[0];
                    Drpicingbranch.DataTextField = "BranchArea";
                    Drpicingbranch.DataValueField = "BranchId";
                    Drpicingbranch.DataBind();
                    Drpicingbranch.Items.Insert(0, "Select Icing");


                }

                DataSet dID = objBs.getmaxnobranchsetting();
                if (dID.Tables[0].Rows.Count > 0)
                {
                    lblsettingID.InnerText = dID.Tables[0].Rows[0]["BranchNo"].ToString();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('SomeThing Went Wrong.Please Contact Administrator.Thank You!!!.');", true);
                    return;
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
            Response.Redirect("BranchSetting.aspx");
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

                    DataSet dsbranch = objBs.getbranchFilling("0");
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        drpstorebranch.DataSource = dsbranch.Tables[0];
                        drpstorebranch.DataTextField = "BranchArea";
                        drpstorebranch.DataValueField = "BranchId";
                        drpstorebranch.DataBind();
                        drpstorebranch.Items.Insert(0, "Select Store");

                    }

                    DataSet dsprod = objBs.getbranchFilling("2");
                    if (dsprod.Tables[0].Rows.Count > 0)
                    {
                        DrpProductionBranch.DataSource = dsprod.Tables[0];
                        DrpProductionBranch.DataTextField = "BranchArea";
                        DrpProductionBranch.DataValueField = "BranchId";
                        DrpProductionBranch.DataBind();
                        DrpProductionBranch.Items.Insert(0, "Select Production");



                        Drpicingbranch.DataSource = dsprod.Tables[0];
                        Drpicingbranch.DataTextField = "BranchArea";
                        Drpicingbranch.DataValueField = "BranchId";
                        Drpicingbranch.DataBind();
                        Drpicingbranch.Items.Insert(0, "Select Icing");

                    }


                    DataSet ds = objBs.getupdatebranchsettingforid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        btnSave.Visible = true;
                        drpstorebranch.SelectedValue = ds.Tables[0].Rows[0]["Branchid"].ToString();
                        DrpProductionBranch.SelectedValue = ds.Tables[0].Rows[0]["ProductionId"].ToString();
                        Drpicingbranch.SelectedValue = ds.Tables[0].Rows[0]["IcingId"].ToString();
                        txtsettingid.Text = ds.Tables[0].Rows[0]["BranchNo"].ToString();
                        drpstorebranch.Enabled = false;
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletebranchsetting(e.CommandArgument.ToString());
                    Response.Redirect("BranchSetting.aspx");
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

            DataSet ds = objBs.gridbranchsetting();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("BranchSetting.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (DrpProductionBranch.SelectedValue == "Select Production")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Production.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            if (Drpicingbranch.SelectedValue == "Select Icing")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select ICING Branch.Please Contact Administrator.Thank You!!!.');", true);
                return;
            }

            if (drpstorebranch.SelectedValue == "Select Store")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Store.Thank You!!!.');", true);
                return;
            }


            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.duplicatebranchsettingcheck(drpstorebranch.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Branch Setting has already Exists please enter a new one";

                }
                else
                {
                    int iStatus = objBs.InsertBranchSetting(drpstorebranch.SelectedValue, drpstorebranch.SelectedItem.Text, DrpProductionBranch.SelectedValue, DrpProductionBranch.SelectedItem.Text, Drpicingbranch.SelectedValue);
                    Response.Redirect("../Accountsbootstrap/BranchSetting.aspx");
                }
            }

            else
            {


                objBs.updatebrnchsetting(Convert.ToInt32(txtsettingid.Text),DrpProductionBranch.SelectedValue,DrpProductionBranch.SelectedItem.Text,Drpicingbranch.SelectedValue);
                Response.Redirect("BranchSetting.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}
