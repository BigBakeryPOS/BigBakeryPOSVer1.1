using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;
namespace Billing.Accountsbootstrap
{
    public partial class ReasonChanaging : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string Btype="";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Btype = Request.Cookies["userInfo"]["BType"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            if (!IsPostBack)
            {

                DataSet dsreason = new DataSet();
                dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "Select Reason");

                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DataSet ds = objbs.RetList(sTableName, txtDate.Text);
                gvCustsales.DataSource = ds.Tables[0];
                gvCustsales.DataBind();
            }

        }

        protected void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objbs.RetListItems(sTableName, groupID);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]);
                        amount1 = amount1 + amount;
                        gv.DataBind();
                    }
                    //}
                }

            }


          
        }

        protected void gvCustsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Change")
            
            {
               // div.Visible = true;
                ViewState["ID"] = e.CommandArgument.ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), "Display", "Diaplay();", true);

                DataSet ds=objbs.getNo(sTableName,Convert.ToInt32(ViewState["ID"].ToString()));
                ddlreason.SelectedValue = ds.Tables[0].Rows[0]["iPaymode"].ToString();
                drpPayment_OnSelectedIndexChanged(sender, e);
              
             
            }
        }
        protected void drpPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Display", "Diaplay();", true);
           // div.Visible = true;
            DataSet ds = new DataSet();

            ds = objbs.GetEubReasons(Convert.ToInt32(ddlreason.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsubreasons.DataSource = ds.Tables[0];
                ddlsubreasons.DataTextField = "SubReasons";
                ddlsubreasons.DataValueField = "id";
                ddlsubreasons.DataBind();
                ddlsubreasons.Items.Insert(0, "Select SubReasons");
            }
            else
            {
                ddlsubreasons.DataSource = null;
                ddlsubreasons.DataBind();
                ddlsubreasons.Items.Insert(0, "Select SubReasons");
            }

        }
        protected void btnch_Click(object sender, EventArgs e)
        {
            if (ddlsubreasons.SelectedValue == "Select Reason")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Reasons .');", true);
                return;
            }
            if (ddlsubreasons.SelectedValue == "Select SubReasons" || ddlsubreasons.SelectedValue == "")  
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select SubReasons .');", true);
                return;
            }
            objbs.UpdateReason(sTableName, Convert.ToInt32(ViewState["ID"].ToString()), Convert.ToInt32(ddlreason.SelectedValue), Convert.ToInt32(ddlsubreasons.SelectedValue));
            Response.Redirect("ReasonChanaging.aspx");
          
        }
    }
}