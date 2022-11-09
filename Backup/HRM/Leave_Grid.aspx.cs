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
    public partial class Leave_Grid : System.Web.UI.Page
    {


        HRMclass objbs = new HRMclass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string emp_code = Session["empid"].ToString();

            if (Convert.ToInt32(emp_code) == 7)
            {
                ds = objbs.Get_Leave();
                GvLeave.DataSource = ds;
                GvLeave.DataBind();
            }
            else
            {
                ds = objbs.Get_empleave(emp_code);
                GvLeave.DataSource = ds;
                GvLeave.DataBind();
                GvLeave.Columns[7].Visible = false;
            }

            
        
        }

        protected void GvLeave_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Status")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("Leave_Form.aspx?Emp_code=" + e.CommandArgument.ToString());

                }
            }
        }

        protected void GvLeave_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string emp_code = Session["empid"].ToString();

            if (Convert.ToInt32(emp_code) == 7)
            {
                ds = objbs.Get_Leave();
                GvLeave.PageIndex = e.NewPageIndex;
                GvLeave.DataSource = ds;
                GvLeave.DataBind();
            }
            else
            {
                ds = objbs.Get_empleave(emp_code);
                GvLeave.PageIndex = e.NewPageIndex;
                GvLeave.DataSource = ds;
                GvLeave.DataBind();
                GvLeave.Columns[7].Visible = false;
            }
        
        }

        protected void GvLeave_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}