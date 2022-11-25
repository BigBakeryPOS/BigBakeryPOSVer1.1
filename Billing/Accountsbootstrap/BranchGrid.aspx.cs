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
    public partial class BranchGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string Logintypeid = "";
        string IsSuperAdmin = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMessage.Visible = false;

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Logintypeid = Request.Cookies["userInfo"]["LoginTypeId"].ToString();
            IsSuperAdmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            if (!IsPostBack)
            {
                DataSet dacess1 = objBs.getuseraccessscreen(Session["EmpId"].ToString(), "Mbranch");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objBs.getuseraccessscreen(Session["EmpId"].ToString(), "Mbranch");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnadd.Visible = true;
                    }
                    else
                    {
                        btnadd.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gvcust.Columns[9].Visible = true;
                    }
                    else
                    {
                        gvcust.Columns[9].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gvcust.Columns[10].Visible = true;
                    }
                    else
                    {
                        gvcust.Columns[10].Visible = false;
                    }
                }

                if (IsSuperAdmin == "1")
                {
                    btnadd.Visible = true;

                }

                DataSet ds = objBs.getBranchDetails(Logintypeid,sTableName);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvcust.DataSource = ds;
                        gvcust.DataBind();
                    }
                    else
                    {
                        gvcust.DataSource = null;
                        gvcust.DataBind();
                    }
                }
                else
                {
                    gvcust.DataSource = null;
                    gvcust.DataBind();
                }
            }
        }

        protected void btnadd_Onclick(object sender, EventArgs e)
        {
            DataSet dsNoBranch = objBs.GetNoBranch();
            if (dsNoBranch.Tables[0].Rows.Count > 0)
            {
                string NoofBranch = dsNoBranch.Tables[0].Rows[0]["NoOfBranch"].ToString();

                DataSet dsBranchCount = objBs.GetBranchCount();

                if (dsBranchCount.Tables[0].Rows.Count > 0)
                {
                    string BrachCount = dsBranchCount.Tables[0].Rows[0]["TotalBranch"].ToString();

                    if (NoofBranch == BrachCount)
                    {
                        lbMessage.Visible = true;
                        return;
                    }

                    else
                    {
                        Response.Redirect("../Accountsbootstrap/BranchDetails.aspx");
                    }

                }
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //DataSet ds = objBs.searchfilteruser(txtsearch.Text, Convert.ToInt32(ddlfilter.SelectedValue));
            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvcust.DataSource = ds;
            //        gvcust.DataBind();
            //    }
            //    else
            //    {
            //        gvcust.DataSource = null;
            //        gvcust.DataBind();
            //    }
            //}
            //else
            //{
            //    gvcust.DataSource = null;
            //    gvcust.DataBind();
            //}
        }
        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("BranchDetails.aspx?iBranch=" + e.CommandArgument.ToString());
                }
            }

            //    else if (e.CommandName == "delete")
            //    {
            //        int iSucess = objBs.deleteBranch(Convert.ToInt32(e.CommandArgument.ToString()));
            //        Response.Redirect("UserGrid.aspx");
            //    }
        }


    }
}