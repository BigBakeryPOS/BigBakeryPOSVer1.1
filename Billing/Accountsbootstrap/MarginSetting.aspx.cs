using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class MarginSetting : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;
        int id = 0;
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"]["User"].ToString() != null)
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();


            if (!IsPostBack)
            {
                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Msetting");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Msetting");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gv.Columns[5].Visible = true;
                    }
                    else
                    {
                        gv.Columns[5].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        //gv.Columns[3].Visible = true;
                    }
                    else
                    {
                        //gv.Columns[3].Visible = false;
                    }
                }

                DataSet dsCategory = objbs.gridcategoryAll();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    drpcategory.DataSource = dsCategory.Tables[0];
                    drpcategory.DataTextField = "category";
                    drpcategory.DataValueField = "CategoryID";
                    drpcategory.DataBind();
                    drpcategory.Items.Insert(0, "Select Category");

                }


                txtOmargin.Text = "0";
                txtFmargin.Text = "0";
                ds = objbs.Catmergin();
                gv.DataSource = ds;
                gv.DataBind();

            }
        }

        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.Catmergin();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("MarginSetting.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (drpcategory.SelectedValue == "Select Category")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Category.Thank You!!!');", true);
                return;
            }
            if (btnSubmit.Text == "Save")
            {
                DataSet dsCategory = objbs.catmarginsearch(drpcategory.SelectedValue);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Category has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {
                        int iStatus = objbs.InsertCatMargin(drpcategory.SelectedValue,txtOmargin.Text,txtFmargin.Text,txtofmargin.Text);
                        Response.Redirect("../Accountsbootstrap/MarginSetting.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.InsertCatMargin(drpcategory.SelectedValue, txtOmargin.Text, txtFmargin.Text,txtofmargin.Text);
                    Response.Redirect("../Accountsbootstrap/MarginSetting.aspx");
                }
            }
            else
            {



                DataSet dsCategory = objbs.catmarginsearchforupdate(Convert.ToInt32(txtid.Text), drpcategory.SelectedValue);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Category Margin has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        objbs.updatecatmarginMaster(Convert.ToInt32(txtid.Text),txtOmargin.Text,txtFmargin.Text,txtofmargin.Text);
                        Response.Redirect("MarginSetting.aspx");
                    }
                }
                else
                {
                    objbs.updatecatmarginMaster(Convert.ToInt32(txtid.Text), txtOmargin.Text, txtFmargin.Text,txtofmargin.Text);
                    Response.Redirect("../Accountsbootstrap/MarginSetting.aspx");
                }

            }
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
            Response.Redirect("MarginSetting.aspx");
        }
        private void clearall()
        {
            txtFmargin.Text = "";
            txtOmargin.Text = "";
            DataSet dsCategory = objbs.gridcategoryAll();
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                drpcategory.DataSource = dsCategory.Tables[0];
                drpcategory.DataTextField = "category";
                drpcategory.DataValueField = "CategoryID";
                drpcategory.DataBind();
                drpcategory.Items.Insert(0, "Select Category");

            }
            btnSubmit.Text = "Save";
        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DataSet dedit = new DataSet();

                    dedit = objbs.editcatmargin(Convert.ToInt32(e.CommandArgument));
                    if (dedit.Tables[0].Rows.Count > 0)
                    {
                        drpcategory.SelectedValue = dedit.Tables[0].Rows[0]["CategoryId"].ToString();
                        drpcategory.Enabled = false;

                        txtOmargin.Text = dedit.Tables[0].Rows[0]["OwnBranch"].ToString();
                        txtFmargin.Text = dedit.Tables[0].Rows[0]["franchise"].ToString();
                        txtofmargin.Text = dedit.Tables[0].Rows[0]["Ownfranchise"].ToString();
                        txtid.Text = dedit.Tables[0].Rows[0]["Catmarginid"].ToString();
                        btnSubmit.Text = "Update";
                        btnSubmit.Visible = true;
                    }

                }
            }
        }


    }
}