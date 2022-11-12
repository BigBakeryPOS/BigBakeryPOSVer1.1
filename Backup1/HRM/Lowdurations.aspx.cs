using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using CommonLayer;
using DataLayer;
using System.Text;
using System.Data;
namespace HRM
{
    public partial class Lowdurations : System.Web.UI.Page
    {
        HRMclass objbs = new HRMclass();
        DataSet ds = new DataSet();

        protected void lesshoursgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
           
                //ds = objbs.getdurationbydate(txtfromdate.Text, txttodate.Text, Convert.ToInt32(txtempid.Text));
                ds = objbs.getdurationdetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
               // ds = objbs.totalleavedays(txtfromdate.Text, txttodate.Text, Convert.ToInt32(txtempid.Text));
                lesshoursgrid.PageIndex = e.NewPageIndex;
                lesshoursgrid.DataSource = ds;
                lesshoursgrid.DataBind();
            }
            //ds = objbs.getdurationbydate(txtfromdate.Text, txttodate.Text, Convert.ToInt32(txtempid.Text));
            //lesshoursgrid.PageIndex = e.NewPageIndex;
            //lesshoursgrid.DataSource = ds;
            //lesshoursgrid.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ds = objbs.getdurationdetails();
                lesshoursgrid.DataSource = ds;
                lesshoursgrid.DataBind();
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            ds = objbs.getdurationbydate(txtfromdate.Text,txttodate.Text);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lesshoursgrid.DataSource = ds;
                    lesshoursgrid.DataBind();
                }
            }
            else
            {
                lesshoursgrid.DataSource = null;
                lesshoursgrid.DataBind();
            }
            ds = objbs.totalleavedays(txtfromdate.Text, txttodate.Text);
            int count =ds.Tables[0].Rows.Count;

            int total = objbs.getsearchcount(txtfromdate.Text, txttodate.Text);

            int days = (total+1) - count;
            txtleavedays.Text = "No.Of.Leavedays:"+Convert.ToString(days);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] str = DropDownList1.SelectedItem.ToString().Split('-');

            string empiname=str[0].Trim();
            string empID=str[1].Trim();
            txtempid.Text = empID;
        }

        protected void Btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lowdurations.aspx");
        }
    }
}