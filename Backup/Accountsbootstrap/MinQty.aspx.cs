using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
namespace Billing.Accountsbootstrap
{
    public partial class MinQty : System.Web.UI.Page
    {
        string superadmin = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

           

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            if (!IsPostBack)
            {
                DataSet dsCategory = objbs.selectcategorymaster();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = dsCategory.Tables[0];
                    ddlcategory.DataTextField = "category";
                    ddlcategory.DataValueField = "categoryid";
                    ddlcategory.DataBind();



                }


                DataSet dGrid = objbs.setQtyGrid(Convert.ToInt32(lblUserID.Text));
                if (dGrid.Tables[0].Rows.Count > 0)
                {
                    gvSet.DataSource = dGrid.Tables[0];
                    gvSet.DataBind();
                }
            }
        }

        protected void gvSet_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (superadmin == "1")
                {
                    ((LinkButton)e.Row.FindControl("btn")).Enabled = true;
                    //((LinkButton)e.Row.FindControl("img")).Enabled = true;

                    ((Image)e.Row.FindControl("img")).Enabled = true;
                    //((Image)e.Row.FindControl("Image1")).Enabled = true;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("btn")).Enabled = false;
                    //((LinkButton)e.Row.FindControl("img")).Enabled = false;

                    ((Image)e.Row.FindControl("img")).Enabled = false;
                    //((Image)e.Row.FindControl("Image1")).Enabled = false;
                }

            }
            else
            {
                //((Image)e.Row.FindControl("imdedit")).Visible = false;
                //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;

                //((Image)e.Row.FindControl("Image1")).Visible = false;
                //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                 DataSet ds=objbs.setQty(Convert.ToInt32(ddlItems.SelectedValue),Convert.ToInt32(lblUserID.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Already Set');", true);
                }
                else
                {
                objbs.MinQtySet(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlItems.SelectedValue), Convert.ToDecimal(txtminqty.Text), Convert.ToDecimal(txtSet.Text),Convert.ToInt32(lblUserID.Text));
            }}
            else
            {
                objbs.updatesetQty(Convert.ToInt32(ddlItems.SelectedValue), Convert.ToDecimal(txtminqty.Text), Convert.ToDecimal(txtSet.Text),Convert.ToInt32(lblUserID.Text));
            }
            txtminqty.Text = "";
            txtSet.Text = "";

            btnsave.Text = "Save";
            DataSet dGrid = objbs.setQtyGrid(Convert.ToInt32(lblUserID.Text));
            if (dGrid.Tables[0].Rows.Count > 0)
            {
                gvSet.DataSource = dGrid.Tables[0];
                gvSet.DataBind();
            }
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsCategory = objbs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue), "");
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                ddlItems.DataSource = dsCategory.Tables[0];
                ddlItems.DataTextField = "Definition";
                ddlItems.DataValueField = "categoryuserid";
                ddlItems.DataBind();
               

            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "")
            {
                DataSet ds = objbs.setQty(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(lblUserID.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.SelectedValue = ds.Tables[0].Rows[0]["categoryid"].ToString();
                    DataSet dsCategory = objbs.selectcategorydecription(Convert.ToInt32(ddlcategory.SelectedValue), "");
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        ddlItems.DataSource = dsCategory.Tables[0];
                        ddlItems.DataTextField = "Definition";
                        ddlItems.DataValueField = "categoryuserid";
                        ddlItems.DataBind();


                    }
                    ddlItems.SelectedValue = ds.Tables[0].Rows[0]["categoryuserid"].ToString();
                    txtminqty.Text = ds.Tables[0].Rows[0]["MinQty"].ToString();
                    txtSet.Text = ds.Tables[0].Rows[0]["FixQty"].ToString();

                    btnsave.Text = "Update";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MinQty.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_Page.aspx");
        }
    }
}