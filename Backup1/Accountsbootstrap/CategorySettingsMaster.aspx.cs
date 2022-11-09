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
    public partial class CategorySettingsMaster : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;
        int id = 0;
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"].ToString() != null)
                sTableName = Session["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();


            if (!IsPostBack)
            {

                DataSet dsCategory = objbs.gridcategory();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "CategoryID";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select Category");
                }



                DataSet dsbranch = objbs.getbranch();
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    chkbranch.DataSource = dsbranch.Tables[0];
                    chkbranch.DataTextField = "BranchArea";
                    chkbranch.DataValueField = "BranchCode";
                    chkbranch.DataBind();

                }


                ds = objbs.CategorySettings();
                gv.DataSource = ds;
                gv.DataBind();

            }




        }
        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.CategorySettings();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("CategorySettingsMaster.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (txtTax.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Tax.Thank You!!!');", true);
            //    return;
            //}

            if (btnSubmit.Text == "Save")
            {
                DataSet dsCategory = objbs.CatsettingsSearch(ddlcategory.SelectedValue);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Cateegory Settings is already Exists. please enter a new one');", true);
                        return;


                    }
                }

                DataSet ndstt = new DataSet();
                DataTable ndttt = new DataTable();

                DataColumn ndc = new DataColumn("Branchcode");
                ndttt.Columns.Add(ndc);

                ndc = new DataColumn("Branchname");
                ndttt.Columns.Add(ndc);

                ndc = new DataColumn("IsActive");
                ndttt.Columns.Add(ndc);

                ndstt.Tables.Add(ndttt);


                foreach (ListItem listItem in chkbranch.Items)
                {

                    if (listItem.Selected)
                    {
                        DataRow ndrd = ndstt.Tables[0].NewRow();
                        ndrd["Branchcode"] = listItem.Value;
                        ndrd["Branchname"] = listItem.Text;
                        ndrd["IsActive"] = "Y";
                        ndstt.Tables[0].Rows.Add(ndrd);
                    }
                    else
                    {
                        DataRow ndrd = ndstt.Tables[0].NewRow();
                        ndrd["Branchcode"] = listItem.Value;
                        ndrd["Branchname"] = listItem.Text;
                        ndrd["IsActive"] = "N";
                        ndstt.Tables[0].Rows.Add(ndrd);
                    }
                }

                int iStatusi = objbs.InsertCategorySettings(ddlcategory.SelectedValue, ndstt);

                Response.Redirect("../Accountsbootstrap/CategorySettingsMaster.aspx");
            }

            else
            {



                DataSet dsCategory = objbs.CategorySettingssearchforupdate(lblcatid.Text, ddlcategory.SelectedValue);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Category Settings is already Exists. please enter a new one');", true);
                        return;
                    }
                }

                DataSet ndstt = new DataSet();
                DataTable ndttt = new DataTable();

                DataColumn ndc = new DataColumn("Branchcode");
                ndttt.Columns.Add(ndc);

                ndc = new DataColumn("Branchname");
                ndttt.Columns.Add(ndc);

                ndc = new DataColumn("IsActive");
                ndttt.Columns.Add(ndc);

                ndstt.Tables.Add(ndttt);


                foreach (ListItem listItem in chkbranch.Items)
                {

                    if (listItem.Selected)
                    {
                        DataRow ndrd = ndstt.Tables[0].NewRow();
                        ndrd["Branchcode"] = listItem.Value;
                        ndrd["Branchname"] = listItem.Text;
                        ndrd["IsActive"] = "Y";
                        ndstt.Tables[0].Rows.Add(ndrd);
                    }
                    else
                    {
                        DataRow ndrd = ndstt.Tables[0].NewRow();
                        ndrd["Branchcode"] = listItem.Value;
                        ndrd["Branchname"] = listItem.Text;
                        ndrd["IsActive"] = "N";
                        ndstt.Tables[0].Rows.Add(ndrd);
                    }
                }

                int iStatusi = objbs.updateCategorySettingsMaster(lblcatid.Text, ddlcategory.SelectedValue, ndstt);

                Response.Redirect("../Accountsbootstrap/CategorySettingsMaster.aspx");
            }


        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            lblcatid.Text = "";
            ddlcategory.ClearSelection();
            btnSubmit.Text = "Save";
            foreach (ListItem listItem in chkbranch.Items)
            {
                listItem.Selected = false;
            }

        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DataSet dedit = new DataSet();

                    dedit = objbs.editCatsettings(e.CommandArgument.ToString());
                    if (dedit.Tables[0].Rows.Count > 0)
                    {


                        lblcatid.Text = dedit.Tables[0].Rows[0]["CatSettingsId"].ToString();
                        ddlcategory.SelectedValue = dedit.Tables[0].Rows[0]["CategoryId"].ToString();

                        foreach (ListItem listItem in chkbranch.Items)
                        {
                            listItem.Selected = false;
                        }

                        DataSet dstrans = objbs.editTransCatsettings(e.CommandArgument.ToString());

                        if (dstrans.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i <= dstrans.Tables[0].Rows.Count - 1; i++)
                            {
                                if (dstrans.Tables[0].Rows[i]["IsActive"].ToString() == "Y")
                                {
                                    chkbranch.Items.FindByValue(dstrans.Tables[0].Rows[i]["BranchCode"].ToString()).Selected = true;
                                }
                                else
                                {
                                    chkbranch.Items.FindByValue(dstrans.Tables[0].Rows[i]["BranchCode"].ToString()).Selected = false;
                                }
                            }
                        }


                        btnSubmit.Text = "Update";
                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objbs.deleteCatsettings(e.CommandArgument.ToString());
                    Response.Redirect("CategorySettingsMaster.aspx");
                }
            }



        }


    }
}