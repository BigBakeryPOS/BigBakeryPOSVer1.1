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
    public partial class RateSettingMaster : System.Web.UI.Page
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

                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Ratesettingmaster");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "Ratesettingmaster");
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
                        gv.Columns[2].Visible = true;
                    }
                    else
                    {
                        gv.Columns[2].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gv.Columns[3].Visible = true;
                    }
                    else
                    {
                        gv.Columns[3].Visible = false;
                    }
                }


                txtratesetting.Text = "";
                btnSubmit.Text = "Update";

                ds = objbs.GetRateSetting();
                gv.DataSource = ds;
                gv.DataBind();

            }


            txtratesetting.Focus();

        }
        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.GetRateSetting();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("RateSettingMaster.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtratesetting.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Rate Type');", true);
                return;
            }
            if (btnSubmit.Text == "Update")
            
            {



                DataSet dsCategory = objbs.Ratesettingsearchforupdate(Convert.ToInt32(txtid.Text), txtratesetting.Text);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Rate Type has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        objbs.updateratesetting(Convert.ToInt32(txtid.Text), txtratesetting.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text, "");
                        Response.Redirect("RateSettingMaster.aspx");
                    }
                }
            }
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            txtratesetting.Text = "";
            lblname.Text = "";
            ddlIsActive.ClearSelection();
            btnSubmit.Text = "Update";
            txtratesetting.Focus();

        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DataSet dedit = new DataSet();

                    dedit = objbs.editratesetting(Convert.ToInt32(e.CommandArgument));
                    if (dedit.Tables[0].Rows.Count > 0)
                    {

                        lblname.Text = dedit.Tables[0].Rows[0]["Name"].ToString();
                        txtratesetting.Text = dedit.Tables[0].Rows[0]["CurrencyName"].ToString();
                        txtid.Text = dedit.Tables[0].Rows[0]["RateSettingid"].ToString();
                        btnSubmit.Text = "Update";
                        btnSubmit.Visible = true;
                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {

                    if (e.CommandArgument.ToString() == "1")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These Rate Type Not Allow To Delete. Thank You!!!');", true);
                        return;
                    }
                    else
                    {
                        objbs.deleteratesetting(e.CommandArgument.ToString());
                        Response.Redirect("RateSettingMaster.aspx");
                    }
                }
            }
        }


    }
}