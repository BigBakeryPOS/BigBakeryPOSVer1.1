using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class GoodsReceivedStoreGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string scode = "";
        string UserVal = "";
        string Productioncode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            UserVal = Request.Cookies["userInfo"]["UserVal"].ToString();
            gvDetails.Visible = false;

            #region Check Internet Connection
            if (objbs.IsConnectedToInternet())
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Accept Any Store Stock Received.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion


            if (!IsPostBack)
            {
                #region
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                DataSet ds = objbs.GetDCNONewStore(scode, Productioncode);
                if (ds.Tables.Count > 0)
                {
                    ddlDC.DataSource = ds.Tables[0];
                    ddlDC.DataTextField = "DC_NO";
                    ddlDC.DataValueField = "DC_NO";
                    ddlDC.DataBind();
                    ddlDC.Items.Insert(0, "Select DC No");
                }
                else
                {
                    ddlDC.Items.Insert(0, "No Goods Available");
                }
            }

        }

        protected void ddlDC_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet checkdayclose = objbs.checkinser_Previousday(scode);
            if (checkdayclose.Tables[0].Rows.Count > 0)
            {
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            if (ddlDC.SelectedValue != "" && ddlDC.SelectedValue != "0" && ddlDC.SelectedValue != "Select DC No" && ddlDC.SelectedValue != "No Goods Available")
            {

                #region
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                DataSet ds = objbs.GoodReceivedNewStore(ddlDC.SelectedValue, scode, Productioncode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvGoodsReceived.DataSource = ds;
                    gvGoodsReceived.DataBind();
                    gvDetails.Visible = false;
                }
                else
                {
                    gvGoodsReceived.DataSource = null;
                    gvGoodsReceived.DataBind();
                }
            }
        }


        protected void gvGoodTransFer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Receive")
            {
                #region
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string Dcno = commandArgs[0];
                string PRoreqno = commandArgs[1];
                string Breqno = commandArgs[2];

                Response.Redirect("GoodsReceivedNoteStore.aspx?PReqNo=" + PRoreqno + "&DCNo=" + Dcno + "&Productioncode=" + Productioncode + "&BReqNo=" + Breqno);
            }

            if (e.CommandName == "print")
            {

                #region
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                gvDetails.Visible = true;
                DataSet ds = objbs.GoodReceivedListNewStore(ddlDC.SelectedValue, scode, Productioncode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = ds.Tables[0];
                    gvDetails.DataBind();
                }
                else
                {
                    gvDetails.DataSource = null;
                    gvDetails.DataBind();
                }
                //string caption = "Goods Received" + "</br>" + "DC No " + gvGoodsReceived.Rows[0].Cells[0].Text + "</br>" + "DC Date " + Convert.ToDateTime(gvGoodsReceived.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt");
                //gvDetails.Caption = caption;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }

            if (e.CommandName == "view")
            {
                #region
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion
                gvDetails.Visible = true;
                DataSet ds = objbs.GoodReceivedListNewStore(ddlDC.SelectedValue, scode, Productioncode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = ds.Tables[0];
                    gvDetails.DataBind();
                }
                else
                {
                    gvDetails.DataSource = null;
                    gvDetails.DataBind();
                }

                //string caption = "Goods Received" + "</br>" + "DC No " + gvGoodsReceived.Rows[0].Cells[0].Text + "</br>" + "DC Date " + Convert.ToDateTime(gvGoodsReceived.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt");
                //gvDetails.Caption = caption;


            }
        }
    }
}