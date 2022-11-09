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
    public partial class SemiCategoryGrid : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "SemiCategory ASC";
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

                DataSet dsgrid = objBs.gridsemicategory();
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
            Response.Redirect("SemicategoryGrid.aspx");
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("SemicategoryGrid.aspx");
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

                    DataSet ds = objBs.getiCatvaluessemicat(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        txtsemicategoryId.Text = ds.Tables[0].Rows[0]["semiCatID"].ToString();
                        txtsemicategory.Text = ds.Tables[0].Rows[0]["SemiCategory"].ToString();
                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();

                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteSemicategorymaster(e.CommandArgument.ToString());
                    Response.Redirect("SemicategoryGrid.aspx");
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

            DataSet ds = objBs.gridsemicategory();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("SemicategoryGrid.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.DuplicateSemiCatcheck(txtsemicategory.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Semi Category has already Excided please enter a new one";

                }

                else
                {
                    int iStatus = objBs.InsertSemiCategory(txtsemicategory.Text, drpisactive.SelectedValue);
                    Response.Redirect("../Accountsbootstrap/SemicategoryGrid.aspx");
                }
            }
            else
            {
                DataSet dsCategory = objBs.DuplicateSemiCatcheckForUpdate(txtsemicategory.Text, txtsemicategoryId.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Semi Category has already Excided please enter a new one";

                }
                else
                {
                    objBs.updateSemicategory(Convert.ToInt32(txtsemicategoryId.Text), txtsemicategory.Text, drpisactive.SelectedValue);
                }
                Response.Redirect("SemicategoryGrid.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {

            //connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            //connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            //SqlConnection source = new SqlConnection(connnectionStringMain);

            //SqlConnection destination = new SqlConnection(connnectionString);


            //SqlCommand cmditem = new SqlCommand("truncate table tblCategory", destination);
            //SqlCommand cmdbranch = new SqlCommand("truncate table tblMargin", destination);



            //// Open source and destination connections.
            //source.Open();
            //destination.Open();
            //cmditem.ExecuteNonQuery();
            //cmdbranch.ExecuteNonQuery();




            //// Select data from Products table
            //cmditem = new SqlCommand("SELECT * FROM tblcategory", source);
            //cmdbranch = new SqlCommand("SELECT * FROM tblMargin", source);



            //// Create SqlBulkCopy
            //SqlBulkCopy bulkData = new SqlBulkCopy(destination);

            //// Execute reader
            //SqlDataReader reader = cmditem.ExecuteReader();
            //bulkData.DestinationTableName = "tblcategory";
            //bulkData.WriteToServer(reader);
            //reader.Close();




            //SqlDataReader readerbranch = cmdbranch.ExecuteReader();
            //bulkData.DestinationTableName = "tblMargin";
            //bulkData.WriteToServer(readerbranch);
            //readerbranch.Close();

            //// Close objects
            //bulkData.Close();
            //destination.Close();
            //source.Close();

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }
    }
}