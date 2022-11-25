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

                DataSet dacess1 = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "Ledger");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "Ledger");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnsave.Visible = true;
                    }
                    else
                    {
                        btnsave.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gvledgrid.Columns[1].Visible = true;
                    }
                    else
                    {
                        gvledgrid.Columns[1].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gvledgrid.Columns[2].Visible = true;
                    }
                    else
                    {
                        gvledgrid.Columns[2].Visible = false;
                    }
                }

                DataSet dLedger = objbs.LedgerGrid();
            gvledgrid.DataSource = dLedger;
            gvledgrid.DataBind();
            }

            #region LedgerMerging
            if (!IsPostBack)
            {
                string sLedID = Request.QueryString.Get("iLedID");
                if (sLedID != null)
                {
                    DataSet dsLedger = objbs.SelectLedger(sLedID);
                    if (dsLedger.Tables[0].Rows.Count > 0)
                    {
                        txtledger.Text = dsLedger.Tables[0].Rows[0]["LedgerName"].ToString();
                        btnsave.Visible = true;
                    }
                }

                DataSet dGroup = objbs.GetGroup();

                ddlGroup.DataTextField = "GroupName";
                ddlGroup.DataValueField = "GroupID";
                ddlGroup.DataSource = dGroup.Tables[0];
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, "Select group");
                ddlGroup.SelectedIndex = 3;
                ddlGroup.Enabled = false;
            }
            #endregion
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataSet dLedger = objbs.LedgerGrid();
            gvledgrid.DataSource = dLedger;
            gvledgrid.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            string sLedID = Request.QueryString.Get("iLedID");
            if (sLedID != null)
            {
                int i = objbs.ledgercr(txtledger.Text, sLedID);
            }
            else
            {
                int i = objbs.ledgercr(txtledger.Text, Convert.ToInt32(ddlGroup.SelectedValue));
            }
            Response.Redirect("LedgerMasterGrid.aspx");

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