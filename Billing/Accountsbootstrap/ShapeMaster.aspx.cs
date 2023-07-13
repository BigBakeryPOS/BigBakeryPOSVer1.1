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
    public partial class ShapeMaster : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "ShapeName ASC";
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

                DataSet dsgrid = objBs.gridShapemaster();
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
            Response.Redirect("ShapeMaster.aspx");
        }
        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("ShapeMaster.aspx");
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

                    DataSet ds = objBs.getShapemastermasterid(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        btnSave.Visible = true;
                        txtshapeId.Text = ds.Tables[0].Rows[0]["Shapeid"].ToString();
                        txtshapename.Text = ds.Tables[0].Rows[0]["ShapeName"].ToString();
                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();


                    }
                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteshapemastermaster(e.CommandArgument.ToString());
                    Response.Redirect("ShapeMaster.aspx");
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
            Response.Redirect("ShapeMaster.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.DuplicateShapemastercheck(txtshapename.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Shape Name   has already Exists. please enter a new one";

                }

                else
                {
                    int iStatus = objBs.InsertShapemaster(txtshapename.Text, drpisactive.SelectedValue);
                    Response.Redirect("../Accountsbootstrap/ShapeMaster.aspx");
                }
            }
            else
            {
                DataSet dsCategory = objBs.DuplicateShapemastercheckForUpdate(txtshapename.Text, txtshapeId.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Shape  Master has already Exists. please enter a new one";

                }
                else
                {
                    objBs.updateShapename(Convert.ToInt32(txtshapeId.Text), txtshapename.Text, drpisactive.SelectedValue);
                    Response.Redirect("ShapeMaster.aspx");
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