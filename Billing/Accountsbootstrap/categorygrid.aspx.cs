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
using System.IO;
using System.Data.OleDb;

namespace Billing.Accountsbootstrap
{
    public partial class categorygrid : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Category ASC";
        string sTableName = "";
        string superadmin = "";

        private string connnectionString;
        private string connnectionStringMain;
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            //if (superadmin == "1")
            //{
            //    ((LinkButton)e.Row.FindControl("imdedit")).Enabled = false;
            //}
            //  Label myLabel = this.FindControl("lblscreenname") as Label;
            
            if (!IsPostBack)
            {

                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Category");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Category");
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
                DataSet dsgvbranch = objBs.getallbranch();
                gvbranch.DataSource = dsgvbranch;
                gvbranch.DataBind();

                ViewState["SortExpr"] = Sort_Direction;

                DataSet dsgrid = objBs.gridcategory();
                gridview.DataSource = dsgrid;
                gridview.DataBind();


                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();


                DataSet dID = objBs.getmaxcatid();
                if (dID.Tables[0].Rows.Count > 0)
                {
                    lblCatID.InnerText = dID.Tables[0].Rows[0]["CategoryID"].ToString();

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

        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {
            if (fp_Upload.HasFile)
            {
                string fileName = Path.GetFileName(fp_Upload.PostedFile.FileName);
                fp_Upload.PostedFile.SaveAs(Server.MapPath("~/Files/") + fileName);
                lblFile_Path.Text = "Files/" + fp_Upload.PostedFile.FileName;
                img_Photo.ImageUrl = "Files/" + fp_Upload.PostedFile.FileName;
            }

           
        }

        protected void Margin_Click(object sender, EventArgs e)
        {
            // Fetching All Category
            //if (drptype.SelectedValue == "1")
            //{
            //}
            DataSet dsgrid = objBs.gridcategoryAll();
            if (dsgrid.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsgrid.Tables[0].Rows.Count; i++)
                {
                    string catid = dsgrid.Tables[0].Rows[i]["catid"].ToString();
                    string Categoryid = dsgrid.Tables[0].Rows[i]["Categoryid"].ToString();

                   // get margin
                    DataSet dss = objBs.editcatmarginN(Convert.ToInt32(Categoryid));
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        string Omargin = dss.Tables[0].Rows[0]["OwnBranch"].ToString();
                        string franchise = dss.Tables[0].Rows[0]["franchise"].ToString();
                        string OFmargin = dss.Tables[0].Rows[0]["Ownfranchise"].ToString();
                        string CategoryId = dss.Tables[0].Rows[0]["CategoryId"].ToString();

                        if (Categoryid == CategoryId)
                        {
                            int iss = objBs.insertmarginsettingNew(Categoryid, Omargin, franchise, OFmargin);
                        }

                    }
                }
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Margin Fetching Completed.Thank You!!!.');", true);

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("categorymaster.aspx");
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("categorygrid.aspx");
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

                    DataSet ds = objBs.getiCatvalues(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";
                        listcategory.Enabled = false;
                        txtcategoryId.Text = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                        txtcategory.Text = ds.Tables[0].Rows[0]["category"].ToString();
                        txtcatcode.Text = ds.Tables[0].Rows[0]["Categorycode"].ToString();
                        rdbtype.SelectedValue = ds.Tables[0].Rows[0]["ProductionType"].ToString();
                        txtprintcat.Text = ds.Tables[0].Rows[0]["Printcategory"].ToString();
                        drpcattype.SelectedValue = ds.Tables[0].Rows[0]["CatType"].ToString();

                        lblFile_Path.Text = (ds.Tables[0].Rows[0]["ImagePath"].ToString()).Remove(0,2);
                        img_Photo.ImageUrl = (ds.Tables[0].Rows[0]["ImagePath"].ToString());

                        drpcattype.Enabled = false;

                        if (ds.Tables[0].Rows[0]["Request"].ToString() == "1")
                        {
                            chkrequestcateory.Checked = true;
                        }
                        else
                        {
                            chkrequestcateory.Checked = false;
                        }

                        if (ds.Tables[0].Rows[0]["poduction"].ToString() == "1")
                        {
                            chkproductioncategory.Checked = true;
                        }
                        else
                        {
                            chkproductioncategory.Checked = false;
                        }

                        if (ds.Tables[0].Rows[0]["ManualGrn"].ToString() == "1")
                        {
                            chkmanualgrn.Checked = true;
                        }
                        else
                        {
                            chkmanualgrn.Checked = false;
                        }

                        DataSet dsgvbranch = objBs.getallbranch();
                        gvbranch.DataSource = dsgvbranch;
                        gvbranch.DataBind();

                        for (int i = 0; i < gvbranch.Rows.Count; i++)
                        {
                            HiddenField hidBranchId = (HiddenField)gvbranch.Rows[i].FindControl("hidBranchId");
                            TextBox txtmargin = (TextBox)gvbranch.Rows[i].FindControl("txtmargin");
                            Label lblBranch = (Label)gvbranch.Rows[i].FindControl("lblBranch");
                            DataSet dsgvbranch1 = objBs.getbranchlMargin(Convert.ToInt32(iCat),hidBranchId.Value);
                            if (dsgvbranch1.Tables[0].Rows.Count > 0)
                            {
                                txtmargin.Text = dsgvbranch1.Tables[0].Rows[0]["Margin"].ToString();
                            }
                            else
                            {
                                txtmargin.Text = "0";
                            }
                        }



                        
                        //if (dsgvbranch.Tables[0].Rows.Count > 0)
                        //{
                        //    gvbranch.DataSource = dsgvbranch;
                        //    gvbranch.DataBind();
                        //}
                        //else
                        //{
                        //    dsgvbranch = objBs.getallbranch();
                        //    gvbranch.DataSource = dsgvbranch;
                        //    gvbranch.DataBind();
                        //}
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deletecategorymaster(e.CommandArgument.ToString());
                    Response.Redirect("categorygrid.aspx");
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
            //    if (superadmin == "1" || sTableName == "Pro" || superadmin=="2")
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

            DataSet ds = objBs.gridcategory();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoryGrid.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblFile_Path.Text == "")
                lblFile_Path.Text = "Files/BlackForrest.png";

            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                                Request.ApplicationPath.TrimEnd('/') + "/";
            string Pagepath = baseUrl + lblFile_Path.Text;


            //string Pagepath =  lblFile_Path.Text;
            string request = "0";
            string production = "0";
            string manualGRN = "0";


            if (chkrequestcateory.Checked == true)
            {
                request = "1";
                chkproductioncategory.Checked = true;
            }
            else
            {
                chkproductioncategory.Checked = false;
            }

            if (chkproductioncategory.Checked == true)
                production = "1";
            if (chkmanualgrn.Checked == true)
                manualGRN = "1";

            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.DuplicateCatcheck(txtcategory.Text);

                DataSet dsCategorycode = objBs.DuplicateCatCodeCheck(txtcatcode.Text);

                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Category has already Excided please enter a new one";

                }
                else if (dsCategorycode.Tables[0].Rows.Count > 0)
                {
                    lblerror.Text = "This Category code has already Excided please enter a new one";
                }
                else
                {
                    int iStatus = objBs.InsertCategory(txtcategory.Text, txtcatcode.Text, Convert.ToInt32(lblCatID.InnerText), rdbtype.SelectedValue, request, production, txtprintcat.Text, manualGRN, drpcattype.SelectedValue, lblFile_Path.Text, Pagepath);

                    for (int i = 0; i < gvbranch.Rows.Count; i++)
                    {
                        HiddenField hidBranchId = (HiddenField)gvbranch.Rows[i].FindControl("hidBranchId");
                        TextBox txtmargin = (TextBox)gvbranch.Rows[i].FindControl("txtmargin");
                        Label lblBranch = (Label)gvbranch.Rows[i].FindControl("lblBranch");


                        if (txtmargin.Text == "")
                            txtmargin.Text = "0";

                        int isv = objBs.Insertmargin(iStatus, Convert.ToInt32(hidBranchId.Value), Convert.ToDouble(txtmargin.Text), lblBranch.Text,superadmin);
                    }
                    Response.Redirect("../Accountsbootstrap/categorygrid.aspx");
                }
            }

            else
            {


                objBs.updatecategory(Convert.ToInt32(txtcategoryId.Text), txtcategory.Text, txtcatcode.Text, rdbtype.SelectedValue, request, production, txtprintcat.Text, manualGRN, superadmin, drpcattype.SelectedValue, lblFile_Path.Text, Pagepath);

                objBs.deletemargin(Convert.ToInt32(txtcategoryId.Text));
                for (int i = 0; i < gvbranch.Rows.Count; i++)
                {
                    HiddenField hidBranchId = (HiddenField)gvbranch.Rows[i].FindControl("hidBranchId");
                    TextBox txtmargin = (TextBox)gvbranch.Rows[i].FindControl("txtmargin");
                    Label lblBranch = (Label)gvbranch.Rows[i].FindControl("lblBranch");

                    if (txtmargin.Text == "")
                        txtmargin.Text = "0";

                    int isv = objBs.Insertmargin(Convert.ToInt32(txtcategoryId.Text), Convert.ToInt32(hidBranchId.Value), Convert.ToDouble(txtmargin.Text), lblBranch.Text,superadmin);
                }

                Response.Redirect("categoryGrid.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tblCategory", destination);
            SqlCommand cmdbranch = new SqlCommand("truncate table tblMargin", destination);



            // Open source and destination connections.
            source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();
            cmdbranch.ExecuteNonQuery();




            // Select data from Products table
            cmditem = new SqlCommand("SELECT * FROM tblcategory", source);
            cmdbranch = new SqlCommand("SELECT * FROM tblMargin", source);



            // Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);

            // Execute reader
            SqlDataReader reader = cmditem.ExecuteReader();
            bulkData.DestinationTableName = "tblcategory";
            bulkData.WriteToServer(reader);
            reader.Close();




            SqlDataReader readerbranch = cmdbranch.ExecuteReader();
            bulkData.DestinationTableName = "tblMargin";
            bulkData.WriteToServer(readerbranch);
            readerbranch.Close();

            // Close objects
            bulkData.Close();
            destination.Close();
            source.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }
    }
}
