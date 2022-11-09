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
    public partial class LedgerMasterGrid : System.Web.UI.Page
    {
        string superadmin = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
             if (!IsPostBack)
            {
            DataSet dLedger = objbs.LedgerGrid();
            gvledgrid.DataSource = dLedger;
            gvledgrid.DataBind();
            }
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("LedgerMaster.aspx");
        }

        protected void gvledgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("LedgerMaster.aspx?iLedID=" + e.CommandArgument.ToString());
                }
            }

            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objbs.DeleteLedger(e.CommandArgument.ToString());
                    Response.Redirect("LedgerMasterGrid.aspx");
                }
            }
        }


        protected void gvledgrid_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (superadmin == "1")
                {
                    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = true;
                    ((LinkButton)e.Row.FindControl("btndel")).Enabled = true;

                    ((Image)e.Row.FindControl("imdedit")).Enabled = true;
                    ((Image)e.Row.FindControl("Image1")).Enabled = true;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("btnedit")).Enabled = false;
                    ((LinkButton)e.Row.FindControl("btndel")).Enabled = false;

                    ((Image)e.Row.FindControl("imdedit")).Enabled = false;
                    ((Image)e.Row.FindControl("Image1")).Enabled = false;
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
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet dLedger = objbs.LedgerGrid();
            gvledgrid.PageIndex = e.NewPageIndex;
            DataView dvEmployee = dLedger.Tables[0].DefaultView;
            gvledgrid.DataSource = dvEmployee;
            gvledgrid.DataBind();
        }
    }
}