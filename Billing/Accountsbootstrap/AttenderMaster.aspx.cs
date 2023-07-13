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
    public partial class AttenderMaster : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "AttenderName ASC";
        string sTableName = "";
        string superadmin = "";
        string sbranchname = "";
        string  sbranchid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
           sbranchid = Request.Cookies["userInfo"]["BranchID"].ToString();
            //sbranchid = Session["BranchID"].ToString();
          //  Session["Store"] = dsbranch.Tables[0].Rows[0]["BranchName"].ToString();

            if (!IsPostBack)
            {

                DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "attender");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }
                DataSet ds = new DataSet();
                ds = objBs.getbranchid(sbranchid);
                sbranchname = ds.Tables[0].Rows[0]["branchname"].ToString();
                lblbranch.Text = sbranchname;
                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "attender");
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
                        gridview.Columns[1].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[1].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gridview.Columns[2].Visible = true;
                    }
                    else
                    {
                        gridview.Columns[2].Visible = false;
                    }
                }

                ViewState["SortExpr"] = Sort_Direction;
                lblbranch.Text = sbranchname.ToString();

                //DataSet getbranch = objBs.getbranch();
                //if (getbranch.Tables[0].Rows.Count > 0)
                //{
                //    drpbranch.DataSource = getbranch.Tables[0];
                //    drpbranch.DataTextField = "brancharea";
                //    drpbranch.DataValueField = "branchID";
                //    drpbranch.DataBind();
                //}

                DataSet getAttender = objBs.getattendertype();
                if (getAttender.Tables[0].Rows.Count > 0)
                {
                    drpattendertype.DataSource = getAttender.Tables[0];
                    drpattendertype.DataTextField = "TypeName";
                    drpattendertype.DataValueField = "AttenderTypeid";
                    drpattendertype.DataBind();
                    //drpattendertype.Items.Insert(0, "Select Attender");

                }

                DataSet disc = objBs.chkdiscvalue();
                if (disc.Tables[0].Rows.Count > 0)
                {
                    {
                        chkdisc.DataSource = disc.Tables[0];
                        chkdisc.DataTextField = "discper";
                        chkdisc.DataValueField = "discid";
                        chkdisc.DataBind();

                    }
                }

                DataSet dsgrid = objBs.GridAttender();
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
            // Response.Redirect("categorymaster.aspx");
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("attendermaster.aspx");
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
                   
                    //DataSet getbranch = objBs.getbranch();
                    //if (getbranch.Tables[0].Rows.Count > 0)
                    //{
                    //    drpbranch.DataSource = getbranch.Tables[0];
                    //    drpbranch.DataTextField = "brancharea";
                    //    drpbranch.DataValueField = "branchID";
                    //    drpbranch.DataBind();
                    //}

                    DataSet disc = objBs.chkdiscvalue();
                    if (disc.Tables[0].Rows.Count > 0)
                    {
                        {
                            chkdisc.DataSource = disc.Tables[0];
                            chkdisc.DataTextField = "discper";
                            chkdisc.DataValueField = "discid";
                            chkdisc.DataBind();

                        }
                    }


                    DataSet getAttender = objBs.getattendertype();
                    if (getAttender.Tables[0].Rows.Count > 0)
                    {
                        drpattendertype.DataSource = getAttender.Tables[0];
                        drpattendertype.DataTextField = "TypeName";
                        drpattendertype.DataValueField = "AttenderTypeid";
                        drpattendertype.DataBind();
                        //drpattendertype.Items.Insert(0, "Select Attender");

                    }

                    DataSet ds = objBs.getupdateattendermaster(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        btnSave.Text = "Update";
                        if (ds.Tables[0].Rows[0]["type"].ToString() == "2")
                        {
                            lblattender.Visible = true;
                            txtpwd.Visible = true;
                            lblchk.Visible = true;
                            chkdisc.Visible = true;

                        }
                        else
                        {
                            lblattender.Visible = false;
                            txtpwd.Visible = false;
                            lblchk.Visible = false;
                            chkdisc.Visible = false;
                        }
                        DataSet dsbranch = new DataSet(); 
                        dsbranch = objBs.getbranchid(ds.Tables[0].Rows[0]["branch"].ToString());
                        sbranchname = dsbranch.Tables[0].Rows[0]["branchname"].ToString();
                       // lblbranch.Text = sbranchname;
                        lblbranch.Text = sbranchname.ToString();
                        txtattenderid.Text = ds.Tables[0].Rows[0]["attenderid"].ToString();
                        txtattendername.Text = ds.Tables[0].Rows[0]["attendername"].ToString();
                        //lblbranch.Text = ds.Tables[0].Rows[0]["branch"].ToString();
                        //drpbranch.SelectedValue = ds.Tables[0].Rows[0]["branch"].ToString();
                        drpattendertype.SelectedValue = ds.Tables[0].Rows[0]["type"].ToString();
                        txtpwd.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
                        txtdisc.Text = ds.Tables[0].Rows[0]["disc"].ToString();

                        DataSet dsize = objBs.Editdisctype(Convert.ToInt32(iCat));

                        if ((dsize.Tables[0].Rows.Count > 0))
                        {
                            //Select the checkboxlist items those values are true in database
                            //Loop through the DataTable
                            for (int i = 0; i <= dsize.Tables[0].Rows.Count - 1; i++)
                            {
                                //You need to change this as per your DB Design
                               // string size = dsize.Tables[0].Rows[i]["discid"].ToString();
                                {
                                    //Find the checkbox list items using FindByValue and select it.
                                    chkdisc.Items.FindByValue(dsize.Tables[0].Rows[i]["discid"].ToString()).Selected = true;
                                }

                            }
                        }
                    }

                }

            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteattendermaster(e.CommandArgument.ToString());
                    Response.Redirect("attendermaster.aspx");
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

            DataSet ds = objBs.GridAttender();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Attendermaster.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (drpattendertype.SelectedValue == "2")
            {
                if (txtpwd.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.Thank You!!!');", true);
                    return;
                }
                if (txtdisc.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter discount Percentage Else Make it as Zero.Thank You!!!');", true);
                    return;
                }
            }


            if (btnSave.Text == "Save")
            {
                DataSet dsCategory = objBs.duplicateattendercheck(txtattendername.Text);
                if (dsCategory.Tables[0].Rows.Count > 0)
                {

                    lblerror.Text = "This Attender Name has already Exists please enter a new one";

                }
                else
                {
                    int iStatus = objBs.InsertAttenderName(txtattendername.Text,sbranchid.ToString(), drpattendertype.SelectedValue, txtpwd.Text, txtdisc.Text);
                   // int iStatus = objBs.InsertAttenderName(txtattendername.Text, drpbranch.SelectedValue, drpattendertype.SelectedValue, txtpwd.Text,txtdisc.Text);

                    foreach (ListItem listItem in chkdisc.Items)
                    {
                        if (listItem.Text != "All")
                        {
                            if (listItem.Selected)
                            {
                                int idd = objBs.insert_TransdiscType(listItem.Value, listItem.Text);
                            }
                        }
                    }

                    Response.Redirect("../Accountsbootstrap/Attendermaster.aspx");
                }
            }

            else
            {

                int idelete = objBs.Ideletetransdisctype(txtattenderid.Text);
                objBs.updateattendername(Convert.ToInt32(txtattenderid.Text), txtattendername.Text, sbranchid.ToString(), drpattendertype.SelectedValue, txtpwd.Text, txtdisc.Text);
               // objBs.updateattendername(Convert.ToInt32(txtattenderid.Text), txtattendername.Text, drpbranch.SelectedValue, drpattendertype.SelectedValue, txtpwd.Text,txtdisc.Text);

                foreach (ListItem listItem in chkdisc.Items)
                {
                    if (listItem.Text != "All")
                    {
                        if (listItem.Selected)
                        {
                            int idd = objBs.insert_TransdiscTypeUpdate(listItem.Value, listItem.Text, txtattenderid.Text);
                        }
                    }
                }

                Response.Redirect("Attendermaster.aspx");
            }
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void drpattendertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpattendertype.SelectedItem.Text   == "Discount Authority")
            {
                lblattender.Visible = true;
                txtpwd.Visible = true;
                lblchk.Visible = true;
                chkdisc.Visible = true;
            }
            else
            {
                lblattender.Visible = false;
                txtpwd.Visible = false;
                lblchk.Visible = false;
                chkdisc.Visible = false;
            }
             
           
        }
        }
}
