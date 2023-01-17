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
    public partial class InterStoreGoodsReceivedGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string scode = "";
        string UserVal = "";
        // string Productioncode = "";
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your Internet Connection Active Or Not.If Its InActive Not Allow To Make Any Stock Received.Please Contact Administrator.Thank You!!!');", true);
                return;
            }

            #endregion


            if (!IsPostBack)
            {
                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "ISGRG");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "ISGRG");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                       // Button1.Visible = true;
                    }
                    else
                    {
                      //  Button1.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        // gridledger.Columns[8].Visible = true;
                    }
                    else
                    {
                        // gridledger.Columns[8].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        //gridledger.Columns[5].Visible = true;
                    }
                    else
                    {
                        //gridledger.Columns[5].Visible = false;
                    }
                }

                #region
                DataSet dss = objbs.checkinterProdrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    // Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                DataSet ds = objbs.GetinterDCNONew_store(scode);
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

            //DataSet checkdayclose = objbs.checkinser_Previousday(scode);
            //if (checkdayclose.Tables[0].Rows.Count > 0)
            //{
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not Else Not Allow To Make Any Stock Request.Please Contact Administrator.Thank You!!!');", true);
            //    return;
            //}

            if (ddlDC.SelectedValue != "" && ddlDC.SelectedValue != "0" && ddlDC.SelectedValue != "Select DC No" && ddlDC.SelectedValue != "No Goods Available")
            {

                #region
                DataSet dss = objbs.checkinterProdrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    // Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                DataSet ds = objbs.interGoodReceivedNew_Store(ddlDC.SelectedValue, scode);
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
                DataSet dss = objbs.checkinterProdrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
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
                string REQCode = commandArgs[3];

                Response.Redirect("InterStoreGoodReceivedNote.aspx?PReqNo=" + PRoreqno + "&DCNo=" + Dcno + "&ToCode=" + REQCode + "&BReqNo=" + Breqno);
            }

            if (e.CommandName == "print")
            {

                #region
                DataSet dss = objbs.checkinterProdrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //  Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion

                gvDetails.Visible = true;
                DataSet ds = objbs.ineterGoodReceivedListNew_Store(ddlDC.SelectedValue, scode);
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
                string caption = "Inter Store Goods Received Details:" + "</br>" + "DC No " + gvGoodsReceived.Rows[0].Cells[0].Text + "</br>" + "DC Date " + Convert.ToDateTime(gvGoodsReceived.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Branch Request No:" + gvGoodsReceived.Rows[0].Cells[2].Text + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                gvDetails.Caption = caption;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }

            if (e.CommandName == "view")
            {
                #region
                DataSet dss = objbs.checkinterProdrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //  Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }
                #endregion
                gvDetails.Visible = true;
                DataSet ds = objbs.ineterGoodReceivedListNew_Store(ddlDC.SelectedValue, scode);
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

                string caption = "Inter Store Goods Received Details:" + "</br>" + "DC No " + gvGoodsReceived.Rows[0].Cells[0].Text + "</br>" + "DC Date " + Convert.ToDateTime(gvGoodsReceived.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Branch Request No:" + gvGoodsReceived.Rows[0].Cells[2].Text;
                gvDetails.Caption = caption;


            }
        }
    }
}