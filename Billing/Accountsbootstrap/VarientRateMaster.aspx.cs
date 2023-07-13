using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Billing.Accountsbootstrap
{
    public partial class VarientRateMaster : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "VarientRateName ASC";
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

                //DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Ingcategory");
                //if (dacess1.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                //    {
                //        Response.Redirect("Login_branch.aspx");
                //    }
                //}

                //DataSet dacess = new DataSet();
                //dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Ingcategory");
                //if (dacess.Tables[0].Rows.Count > 0)
                //{
                //    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                //    {
                //        btnSave.Visible = true;
                //    }
                //    else
                //    {
                //        btnSave.Visible = false;
                //    }

                //    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                //    {
                //        gridview.Columns[2].Visible = true;
                //    }
                //    else
                //    {
                //        gridview.Columns[2].Visible = false;
                //    }

                //    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                //    {
                //        gridview.Columns[3].Visible = true;
                //    }
                //    else
                //    {
                //        gridview.Columns[3].Visible = false;
                //    }
                //}


                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.gridvarientratemaster();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            }
        }

        protected void Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("VarientRateMaster.aspx");
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("VarientRateMaster.aspx");
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

                    DataSet ds = objBs.getvarientratemasterid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        btnSave.Visible = true;
                        txtvarientId.Text = ds.Tables[0].Rows[0]["Varientrateid"].ToString();
                        txtvarientname.Text = ds.Tables[0].Rows[0]["VarientRateName"].ToString();
                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();
                        drpisdefaultrate.SelectedValue = ds.Tables[0].Rows[0]["isdefault"].ToString();

                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletevarientratemaster(e.CommandArgument.ToString());
                    Response.Redirect("VarientRateMaster.aspx");
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

            DataSet ds = objBs.gridcategory();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("VarientRateMaster.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.Duplicatevarientmastercheck(txtvarientname.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Varient Rate Master  has already Excided please enter a new one";

                }

                else
                {
                    int iStatus = objBs.Insertvarientratemaster(txtvarientname.Text,drpisdefaultrate.SelectedValue, drpisactive.SelectedValue);
                    Response.Redirect("../Accountsbootstrap/VarientRateMaster.aspx");
                }
            }
            else
            {
                DataSet dsCategory = objBs.DuplicatevarientnamecheckForUpdate(txtvarientname.Text, txtvarientId.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Varient Rate Master has already Excided please enter a new one";

                }
                else
                {
                    objBs.updatevarientname(Convert.ToInt32(txtvarientId.Text), txtvarientname.Text, drpisactive.SelectedValue,drpisdefaultrate.SelectedValue);
                }
                Response.Redirect("VarientRateMaster.aspx");
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