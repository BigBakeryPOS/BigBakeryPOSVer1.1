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
    public partial class TableMaster : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "tablename ASC";
        string sTableName = "";
        string superadmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Session["IsSuperAdmin"].ToString();
            sTableName = Session["User"].ToString();

            if (!IsPostBack)
            {
                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.GridTable();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Session["UserName"].ToString();
                lblUserID.Text = Session["UserID"].ToString();
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
            Response.Redirect("tablemaster.aspx");
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

                    DataSet ds = objBs.getupdatetablemaster(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";

                        txttableid.Text = ds.Tables[0].Rows[0]["tableid"].ToString();
                        txttablename.Text = ds.Tables[0].Rows[0]["tablename"].ToString();
                        txtnoofchair.Text = ds.Tables[0].Rows[0]["No_of_Chairs"].ToString();
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletetablemaster(e.CommandArgument.ToString());
                    Response.Redirect("tablemaster.aspx");
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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (superadmin == "1" || sTableName == "Pro")
                {
                    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
                    ((LinkButton)e.Row.FindControl("btndel")).Enabled = true;

                    ((Image)e.Row.FindControl("imdedit")).Enabled = true;
                    ((Image)e.Row.FindControl("Image1")).Enabled = true;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
                    ((LinkButton)e.Row.FindControl("btndel")).Visible = false;

                    ((Image)e.Row.FindControl("imdedit")).Enabled = false;
                    ((Image)e.Row.FindControl("Image1")).Visible = false;

                    ((Image)e.Row.FindControl("imgdisable1321")).Enabled = false;
                    ((Image)e.Row.FindControl("imgdisable1321")).Visible = true;
                }

            }
            else
            {

            }

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

            DataSet ds = objBs.GridTable();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("TableMaster.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                if (txttablename.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Table name.');", true);
                    return;
                }
            DataSet dsCategory = objBs.Duplicatetablecheck(txttablename.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Table Name has already Exists please enter a new one";

                }
                else
                {
                    int iStatus = objBs.InsertTableName(txttablename.Text, txtnoofchair.Text);
                    Response.Redirect("../Accountsbootstrap/TableMaster.aspx");
                }
            }

            else
            {


                objBs.updatetablemaster(Convert.ToInt32(txttableid.Text), txttablename.Text, txtnoofchair.Text);
                Response.Redirect("TableMaster.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}
