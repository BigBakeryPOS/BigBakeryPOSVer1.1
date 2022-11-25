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
using System.IO;


namespace Billing.Accountsbootstrap
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        string superadmin = "";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();

                DataSet dacess1 = objBs.getuseraccessscreen(Session["EmpId"].ToString(), "employee");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Session["EmpId"].ToString(), "employee");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        button.Visible = true;
                    }
                    else
                    {
                        button.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gvcust.Columns[7].Visible = true;
                    }
                    else
                    {
                        gvcust.Columns[7].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gvcust.Columns[8].Visible = true;
                    }
                    else
                    {
                        gvcust.Columns[8].Visible = false;
                    }
                }

                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                if (!IsPostBack)
                {
                    DataSet ds = objBs.getallempandsupp("1017,17");
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                }
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/customermaster.aspx?" + "MasterType=Employee");
        }


        protected void refresh_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/EmployeeMaster.aspx");

        }

        protected void gvcust_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (superadmin == "1")
                //{
                //    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
                //    ((LinkButton)e.Row.FindControl("btndelete")).Enabled = true;

                //    ((Image)e.Row.FindControl("img")).Enabled = true;
                //    ((Image)e.Row.FindControl("dlt")).Enabled = true;
                //    ((Image)e.Row.FindControl("imgdisable1321")).Visible = false;
                //}
                //else
                //{
                //    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
                //    ((LinkButton)e.Row.FindControl("btndelete")).Enabled = false;

                //    ((Image)e.Row.FindControl("img")).Enabled = false;
                //    ((Image)e.Row.FindControl("dlt")).Enabled = false;

                //    //((Image)e.Row.FindControl("imgdisable1321")).Enabled = false;
                //    ((Image)e.Row.FindControl("dlt")).Visible = false;
                //    ((Image)e.Row.FindControl("imgdisable1321")).Visible = true;
                //}

            }
            else
            {
                //((Image)e.Row.FindControl("imdedit")).Visible = false;
                //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;

                //((Image)e.Row.FindControl("Image1")).Visible = false;
                //((ImageButton)e.Row.FindControl("imgdisable11m")).Visible = true;
            }

        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            GridView gridview = new GridView();
            DataSet ds1;

            if (ddlfilter.SelectedValue == "1")
            {
                ds1 = objBs.getallempandsuppsearch1(txtsearch.Text,"8");
            }
            else if (ddlfilter.SelectedValue == "2")
            {
                ds1 = objBs.getallempandsuppsearch2(txtsearch.Text, "8");
            }
            else
            {
                ds1 = objBs.getallempandsuppsearch3(txtsearch.Text, "8");
            }

            if (ds1.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = ds1;
                gridview.DataBind();
            }
            else
            {
                gridview.DataSource = null;
                gridview.DataBind();
            }


            gridview.Caption = "Employee Report";

            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=CustomerReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw = new StringWriter(); ;
            HtmlTextWriter htm = new HtmlTextWriter(sw);
            gridview.AllowPaging = false;
            gridview.RenderControl(htm);
            Response.Write(sw.ToString());
            Response.End();
            gridview.AllowPaging = true;
        }


        protected void Search_Click(object sender, EventArgs e)
        {


            if (ddlfilter.SelectedValue == "1")
            {
                DataSet ds = objBs.getallempandsuppsearch1(txtsearch.Text,"8");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    gvcust.DataSource = null;
                    gvcust.DataBind();
                    lblerror.Text = "No Records Found for this Name!";
                }
            }
            else if (ddlfilter.SelectedValue == "2")
            {
                DataSet ds = objBs.getallempandsuppsearch2(txtsearch.Text,"8");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    gvcust.DataSource = null;
                    gvcust.DataBind();
                    lblerror.Text = "No Records Found for this Mobile No!";
                }
            }

            else if (ddlfilter.SelectedValue == "3")
            {
                DataSet ds = objBs.getallempandsuppsearch3(txtsearch.Text, "8");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    gvcust.DataSource = null;
                    gvcust.DataBind();
                    lblerror.Text = "No Records Found for this Mail ID!";
                }
            }
            else
            {
                gvcust.DataSource = null;
                gvcust.DataBind();
                Response.Write("Error");
            }

        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editt")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("customermaster.aspx?iCusID=" + e.CommandArgument.ToString() + "&MasterType=Employee");
                }
            }

            else if (e.CommandName == "deleteee")
            {
                int iSucess = objBs.deletecustomer(e.CommandArgument.ToString());
                if (iSucess == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Not Allow To Delete.Please try Again!');", true);
                    return;
                }
                else
                {
                    Response.Redirect("EmployeeMaster.aspx");
                }
            }
        }
    }
}