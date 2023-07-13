using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Billing.Accountsbootstrap
{
    public partial class DepartmentMaster : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Deptname ASC";
        string sTableName = "";
        string superadmin = "";

        private string connnectionString;
        private string connnectionStringMain;
        protected void Page_Load(object sender, EventArgs e)
        {
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.gridDepartmentmaster();
                gridview.DataSource = dsgrid;
                gridview.DataBind();

                #region Branch Code
                DataSet dsbranch = objBs.getBranchCodeDepart("2");
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    ddlBranch.DataSource = dsbranch;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchCode";
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, "Select Branch Code");
                }

                #endregion

                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentMaster.aspx");
        }
        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentMaster.aspx");
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

                    DataSet ds = objBs.getDepartmentmastermasterid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        btnSave.Visible = true;
                        txtdepartid.Text = ds.Tables[0].Rows[0]["DeptID"].ToString();
                        txtdepartname.Text = ds.Tables[0].Rows[0]["Deptname"].ToString();
                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();
                        ddlisrequest.SelectedValue= ds.Tables[0].Rows[0]["IsrequestShow"].ToString();
                        //ddlBranch.SelectedValue = ds.Tables[0].Rows[0]["Pbranch"].ToString();

                    }
                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteDepartmentmaster(e.CommandArgument.ToString());
                    Response.Redirect("DepartmentMaster.aspx");
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

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentMaster.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.DuplicateDepartmentmastercheck(txtdepartname.Text,ddlBranch.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Department Name    has already Exists. please enter a new one";

                }

                else
                {
                    int iStatus = objBs.InsertDepartmentmaster(txtdepartname.Text, drpisactive.SelectedValue,ddlisrequest.SelectedValue,ddlBranch.SelectedValue);
                    Response.Redirect("../Accountsbootstrap/DepartmentMaster.aspx");
                }
            }
            else
            {
                DataSet dsCategory = objBs.DuplicateDepartmentmastercheckForUpdate(txtdepartname.Text, txtdepartid.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Department Master has already Exists. please enter a new one";

                }
                else
                {
                    objBs.updateDepartmentname(Convert.ToInt32(txtdepartid.Text), txtdepartname.Text, drpisactive.SelectedValue, ddlisrequest.SelectedValue,ddlBranch.SelectedValue);
                    Response.Redirect("DepartmentMaster.aspx");
                }

            }
        }
        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {




        }
    }
}