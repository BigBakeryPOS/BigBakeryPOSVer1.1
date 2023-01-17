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
using DocumentFormat.OpenXml.Office2010.Excel;


namespace Billing.Accountsbootstrap
{
    public partial class ViewCustomer : System.Web.UI.Page
    {
        string superadmin = "";
        BSClass objBs = new BSClass();
        string Empid = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
            ID = Request.QueryString.Get("id");
            srch.Text = ID;
            if (!IsPostBack)
            {
                if (srch.Text == "1")
                {
                    head1.InnerHtml = "Customer Master";
                    title1.InnerText = "Customer Details";
                    //Page.Title=
                    DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "CustMast");
                    if (dacess1.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                        {
                            Response.Redirect("Login_branch.aspx");
                        }
                    }

                    DataSet dacess = new DataSet();
                    dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "CustMast");
                    if (dacess.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                        {
                            Button1.Visible = true;
                        }
                        else
                        {
                             Button1.Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                        {
                            gvcust.Columns[5].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[5].Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                        {
                            gvcust.Columns[6].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[6].Visible = false;
                        }
                    }
                }
                else if (srch.Text == "2")
                {
                    head1.InnerHtml = "Dealer Master";
                    title1.InnerText = "Dealer Details";
                    DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "DealMast");
                    if (dacess1.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                        {
                            Response.Redirect("Login_branch.aspx");
                        }
                    }

                    DataSet dacess = new DataSet();
                    dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "DealMast");
                    if (dacess.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                        {
                            Button1.Visible = true;
                        }
                        else
                        {
                            Button1.Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                        {
                            gvcust.Columns[5].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[5].Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                        {
                            gvcust.Columns[6].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[6].Visible = false;
                        }
                    }
                }
                else if (srch.Text == "3")
                {
                    head1.InnerHtml = "Supplier Master";
                    title1.InnerText = "Supplier Details";
                    DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "SupMast");
                    if (dacess1.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                        {
                            Response.Redirect("Login_branch.aspx");
                        }
                    }

                    DataSet dacess = new DataSet();
                    dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "SupMast");
                    if (dacess.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                        {
                            Button1.Visible = true;
                        }
                        else
                        {
                            Button1.Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                        {
                            gvcust.Columns[5].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[5].Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                        {
                            gvcust.Columns[6].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[6].Visible = false;
                        }
                    }
                }
                else if (srch.Text == "4")
                {
                    head1.InnerHtml = "icing Employee Master";
                    title1.InnerText = "icing Employee Details";
                    DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "EmpMast");
                    if (dacess1.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                        {
                            Response.Redirect("Login_branch.aspx");
                        }
                    }

                    DataSet dacess = new DataSet();
                    dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "EmpMast");
                    if (dacess.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                        {
                            Button1.Visible = true;
                        }
                        else
                        {
                            Button1.Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                        {
                            gvcust.Columns[5].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[5].Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                        {
                            gvcust.Columns[6].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[6].Visible = false;
                        }
                    }
                }
                else
                {
                    head1.InnerHtml = "dispatch Employee Master";
                    title1.InnerText = "dispatch Employee Details";
                    DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "DisMast");
                    if (dacess1.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                        {
                            Response.Redirect("Login_branch.aspx");
                        }
                    }

                    DataSet dacess = new DataSet();
                    dacess = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "DisMast");
                    if (dacess.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                        {
                            Button1.Visible = true;
                        }
                        else
                        {
                            Button1.Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                        {
                            gvcust.Columns[5].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[5].Visible = false;
                        }

                        if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                        {
                            gvcust.Columns[6].Visible = true;
                        }
                        else
                        {
                            gvcust.Columns[6].Visible = false;
                        }
                    }
                }
                DataSet ds = objBs.getcustomer(srch.Text);
                gvcust.DataSource = ds;
                gvcust.DataBind();
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/customermaster.aspx?id="+ srch.Text);

        }

        protected void refresh_Click(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/viewcustomer.aspx?id="+ srch.Text);

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


            if ( ddlfilter.SelectedValue =="1")
            {
                DataSet ds = objBs.searchfiltername(txtsearch.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Name!";
                }
            }



            else if ( ddlfilter.SelectedValue == "2")
            {
                DataSet ds = objBs.searchmobile(txtsearch.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Mobile No!";
                }
            }

            else if ( ddlfilter.SelectedValue == "3")
            {
                DataSet ds = objBs.searchemailid(txtsearch.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcust.DataSource = ds;
                    gvcust.DataBind();
                }
                else
                {
                    lblerror.Text = "No Records Found for this Mail ID!";
                }
            }
            else
            {
                Response.Write("Error");
            }

        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edite")
            {
                Response.Redirect("customermaster.aspx?iCusID=" + e.CommandArgument.ToString()+"&id="+ ID);
                DataSet getaccess = objBs.getuseraccessforeditaccess(Empid, "contactedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                    if (e.CommandArgument.ToString() != "")
                    {
                        Response.Redirect("customermaster.aspx?iCusID=" + e.CommandArgument.ToString());
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
                Response.Redirect("viewcustomer.aspx");
            }
        }
    }
}