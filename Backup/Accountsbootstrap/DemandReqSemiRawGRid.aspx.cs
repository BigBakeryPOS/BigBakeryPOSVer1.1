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
using System.Diagnostics;

namespace Billing.Accountsbootstrap
{
    public partial class DemandReqSemiRawGRid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();


            if (!IsPostBack)
            {
                DataSet ds = objBs.ShowRequest_SemiRaw(sTableName, "RW");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {

        }

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("cashsales.aspx?iSalesID=" + e.CommandArgument.ToString());
                }
            }
            else if (e.CommandName == "view")
            {

                DataSet ds = objBs.ShowRequestRawDetails("tblRequestSemiRawMaterials_" + sTableName, "tbltransRequestsemiRawMaterials_" + sTableName, Convert.ToInt32(e.CommandArgument), "RW");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    lbldcno.Text = ds.Tables[0].Rows[0]["RequestNo"].ToString();
                    lbldcdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RequestDate"]).ToString("dd/MM/yyyy");
                    lblPrepared.Text = ds.Tables[0].Rows[0]["Prepared"].ToString();

                    string caption = "Semi Item Request Details:" + "</br>" + "REQ.No " + lbldcno.Text + "</br>" + "REQ.Date " + lbldcdate.Text + "</br>" + "Sent By:" + lblPrepared.Text + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                    gvCustsales.Caption = caption;

                    gvCustsales.DataSource = ds;
                    gvCustsales.DataBind();
                }
                else
                {
                    gvCustsales.DataSource = null;
                    gvCustsales.DataBind();
                }

            }

            else if (e.CommandName == "print")
            {

                DataSet ds = objBs.ShowRequestRawDetails("tblRequestSemiRawMaterials_" + sTableName, "tbltransRequestSemiRawMaterials_" + sTableName, Convert.ToInt32(e.CommandArgument), "RW");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    lbldcno.Text = ds.Tables[0].Rows[0]["RequestNo"].ToString();
                    lbldcdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RequestDate"]).ToString("dd/MM/yyyy");
                    lblPrepared.Text = ds.Tables[0].Rows[0]["Prepared"].ToString();

                    string caption = "Semi Item Request Details:" + "</br>" + "REQ.No " + lbldcno.Text + "</br>" + "REQ.Date " + lbldcdate.Text + "</br>" + "Sent By:" + lblPrepared.Text + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                    gvCustsales.Caption = caption;

                    gvCustsales.DataSource = ds;
                    gvCustsales.DataBind();
                }
                else
                {
                    gvCustsales.DataSource = null;
                    gvCustsales.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);

                //string yourUrl = "WholeSalesPrint.aspx?ISalesId=" + e.CommandArgument.ToString();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow1", "window.open('" + yourUrl + "');", true);

            }
        }

    }
}