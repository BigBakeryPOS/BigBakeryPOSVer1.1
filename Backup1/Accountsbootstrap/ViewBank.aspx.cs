using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;


namespace Billing.Accountsbootstrap
{
    public partial class ViewBank : System.Web.UI.Page
    {
        string superadmin = "";
        BSClass objBs = new BSClass();
        string Empid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            superadmin = Session["IsSuperAdmin"].ToString();

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
            if (!IsPostBack)
            {

                DataSet ds = objBs.getbank("4");
                gvcust.DataSource = ds;
                gvcust.DataBind();
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/bankmaster.aspx");
            //  Response.Redirect("../Accountsbootstrap/customermaster.aspx?" + "MasterType=Supplier");

        }

        protected void refresh_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/viewbank.aspx");

        }

        protected void gvcust_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (superadmin == "1")
            //    {
            //        ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
            //        ((LinkButton)e.Row.FindControl("btndelete")).Enabled = true;

            //        ((Image)e.Row.FindControl("img")).Enabled = true;
            //        ((Image)e.Row.FindControl("dlt")).Enabled = true;
            //    }
            //    else
            //    {
            //        ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
            //        ((LinkButton)e.Row.FindControl("btndelete")).Enabled = false;

            //        ((Image)e.Row.FindControl("img")).Enabled = false;
            //        ((Image)e.Row.FindControl("dlt")).Visible = false;





            //        ((ImageButton)e.Row.FindControl("imgdisable1321")).Enabled = false;
            //        ((ImageButton)e.Row.FindControl("imgdisable1321")).Visible = true;
            //    }

            //}
            //else
            //{
            //    //((Image)e.Row.FindControl("imdedit")).Visible = false;
            //    //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;

            //    //((Image)e.Row.FindControl("Image1")).Visible = false;
            //    //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;
            //}

        }
        protected void Search_Click(object sender, EventArgs e)
        {


            //if ( ddlfilter.SelectedValue =="1")
            //{
            DataSet ds = objBs.getbank_search(txtsearch.Text, ddlfilter.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvcust.DataSource = ds;
                gvcust.DataBind();
            }
            else
            {
                gvcust.DataSource = null;
                gvcust.DataBind();
                lblerror.Text = "No Records Found for this Name!";
            }
            //}



            //else if ( ddlfilter.SelectedValue == "2")
            //{
            //    DataSet ds = objBs.searchmobile(txtsearch.Text);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvcust.DataSource = ds;
            //        gvcust.DataBind();
            //    }
            //    else
            //    {
            //        lblerror.Text = "No Records Found for this Mobile No!";
            //    }
            //}

            //else if ( ddlfilter.SelectedValue == "3")
            //{
            //    DataSet ds = objBs.searchemailid(txtsearch.Text);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvcust.DataSource = ds;
            //        gvcust.DataBind();
            //    }
            //    else
            //    {
            //        lblerror.Text = "No Records Found for this Mail ID!";
            //    }
            //}
            //else
            //{
            //    Response.Write("Error");
            //}

        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edite")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //       // Response.Redirect("customermaster.aspx?iCusID=" + e.CommandArgument.ToString());
            //        Response.Redirect("customermaster.aspx?iCusID=" + e.CommandArgument.ToString() + "&MasterType=Supplier");
            //    }
            //}
            if (e.CommandName == "edite")
            {
               // Response.Redirect("bankmaster.aspx?iCusID=" + e.CommandArgument.ToString());
                DataSet getaccess = objBs.getuseraccessforeditaccess(Empid, "contactedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                    if (e.CommandArgument.ToString() != "")
                    {
                        Response.Redirect("bankmaster.aspx?iCusID=" + e.CommandArgument.ToString());
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Edit This Contact Master.Thank you!!!.');", true);
                    return;
                }
            }
            else if (e.CommandName == "delete")
            {
                int iSucess = objBs.deletecontact(e.CommandArgument.ToString());
                Response.Redirect("viewbank.aspx");
            }
        }
    }
}