using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Text;
using System.Data;


namespace HRM
{
    public partial class Emp_gird : System.Web.UI.Page
    {
        HRMclass objbs = new HRMclass();
        DataSet hrm = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblempid.Text = Session["empid"].ToString();
                lblempname.Text = Session["UserName"].ToString();

                hrm = objbs.hrmgridview();
                gridviewhrm.DataSource = hrm;
                gridviewhrm.DataBind();




            }
            string shortDate = DateTime.Now.ToString("dd/MM/yyyy");
            string time = DateTime.Now.ToString("hh:mm:ss");

            DataSet ds2 = objbs.login(Convert.ToInt32(lblempid.Text), time);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Session["Login_time"] = ds2.Tables[0].Rows[0]["Login_time"].ToString();
                lbllogintime.Text = Session["Login_time"].ToString();
            }


         

        }

        protected void gridviewhrm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("Employee_details.aspx?Employee_Id=" + e.CommandArgument.ToString());
                    Response.Redirect("logout.aspx?Employee_Id=" + e.CommandArgument.ToString());
                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {

                    int i = objbs.deletehrm(Convert.ToString(e.CommandArgument.ToString()));
                    Response.Redirect("Emp_gird.aspx");
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
             Response.Redirect("Employee_details.aspx");
        }

        protected void gridviewhrm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {




            hrm = objbs.hrmgridview();
            gridviewhrm.PageIndex = e.NewPageIndex;

            gridviewhrm.DataSource = hrm;
            gridviewhrm.DataBind();
            
        }

        protected void btnresret_Click1(object sender, EventArgs e)
        {
             Response.Redirect("Emp_gird.aspx");
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string s = txtsearch.Text.Trim();

            if (ddlfilter.SelectedValue == "1")
            {
                DataSet ds = objbs.searchempid(s);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridviewhrm.DataSource = ds;
                    gridviewhrm.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "No Records Found for emp name!";
                    //admin_gridview.Visible = false;
                }
            }

            else
                if (ddlfilter.SelectedValue == "0")
                {
                    lblerror.Text = "Please select a valid emp name";
                    //admin_gridview.Visible = false;
                }


            if (ddlfilter.SelectedValue == "2")
            {
                DataSet ds = objbs.searchempname(s);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridviewhrm.DataSource = ds;
                    gridviewhrm.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "No Records Found for emp name!";
                    //admin_gridview.Visible = false;
                }
            }

            else
                if (ddlfilter.SelectedValue == "0")
                {
                    lblerror.Text = "Please select a valid emp name";
                    //admin_gridview.Visible = false;
                }
        }

        private object Trim(bool p)
        {
            throw new NotImplementedException();
        }

        protected void gridviewhrm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        
       
}
 
}
