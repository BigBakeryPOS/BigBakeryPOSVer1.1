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
    public partial class DepartmentSetting : System.Web.UI.Page
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
                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.griddeptsetting();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                DataSet dsbranch = objBs.getDepartment(sTableName);
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    drpdepartment.DataSource = dsbranch.Tables[0];
                    drpdepartment.DataTextField = "Deptname";
                    drpdepartment.DataValueField = "DeptID";
                    drpdepartment.DataBind();
                    drpdepartment.Items.Insert(0, "Select Department");

                }

                DataSet dsprod = objBs.getbranchFilling("2");
                if (dsprod.Tables[0].Rows.Count > 0)
                {
                    DrpProductionBranch.DataSource = dsprod.Tables[0];
                    DrpProductionBranch.DataTextField = "BranchArea";
                    DrpProductionBranch.DataValueField = "BranchId";
                    DrpProductionBranch.DataBind();
                    DrpProductionBranch.Items.Insert(0, "Select Production");

                }

                DataSet dID = objBs.getmaxnodeptsetting();
                if (dID.Tables[0].Rows.Count > 0)
                {
                    lblsettingID.InnerText = dID.Tables[0].Rows[0]["DeptNo"].ToString();

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
            Response.Redirect("DepartmentSetting.aspx");
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

                    DataSet dsbranch = objBs.getDepartment(sTableName);
                    if (dsbranch.Tables[0].Rows.Count > 0)
                    {
                        drpdepartment.DataSource = dsbranch.Tables[0];
                        drpdepartment.DataTextField = "Deptname";
                        drpdepartment.DataValueField = "DeptID";
                        drpdepartment.DataBind();
                        drpdepartment.Items.Insert(0, "Select Department");

                    }

                    DataSet dsprod = objBs.getbranchFilling("2");
                    if (dsprod.Tables[0].Rows.Count > 0)
                    {
                        DrpProductionBranch.DataSource = dsprod.Tables[0];
                        DrpProductionBranch.DataTextField = "BranchArea";
                        DrpProductionBranch.DataValueField = "BranchId";
                        DrpProductionBranch.DataBind();
                        DrpProductionBranch.Items.Insert(0, "Select Production");

                    }


                    DataSet ds = objBs.getupdatedeptsettingforid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";

                        drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["DeptId"].ToString();
                        DrpProductionBranch.SelectedValue = ds.Tables[0].Rows[0]["Prodid"].ToString();
                        txtsettingid.Text = ds.Tables[0].Rows[0]["DeptNo"].ToString();
                        drpdepartment.Enabled = false;
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletedeptsetting(e.CommandArgument.ToString());
                    Response.Redirect("DepartmentSetting.aspx");
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

            DataSet ds = objBs.griddeptsetting();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentSetting.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.duplicatedeptsettingcheck(drpdepartment.SelectedValue);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Department Setting has already Exists please enter a new one";

                }
                else
                {
                    int iStatus = objBs.InsertDeptSetting( drpdepartment.SelectedValue , DrpProductionBranch.SelectedValue, DrpProductionBranch.SelectedItem.Text);
                    Response.Redirect("../Accountsbootstrap/DepartmentSetting.aspx");
                }
            }

            else
            {


                objBs.updateDeptsetting(Convert.ToInt32(txtsettingid.Text), DrpProductionBranch.SelectedValue, DrpProductionBranch.SelectedItem.Text);
                Response.Redirect("DepartmentSetting.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}
