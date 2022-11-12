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
using System.Globalization;
namespace Billing.Accountsbootstrap
{
    public partial class GoodsReceivedGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string scode = "";
        string UserVal = "";
        string Productioncode = "";
        string Icingcode = "";
        string qtysetting = "";

        int totrec_qty = 0;
        int totdmg_qty = 0;
        int totmis_qty = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            UserVal = Request.Cookies["userInfo"]["UserVal"].ToString();
            gvDetails.Visible = false;
            qtysetting = Request.Cookies["userInfo"]["Qtysetting"].ToString();

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

            #region Production Branch Load
            DataSet dss = objbs.checkrequestallowornot(scode);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                Icingcode = dss.Tables[0].Rows[0]["IcingCode"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            #endregion

            if (!IsPostBack)
            {


                if (Icingcode == Productioncode)
                {
                    DataSet dproducttypeload = objbs.GetProducttype();
                    if (dproducttypeload.Tables[0].Rows.Count > 0)
                    {
                        drpproductiontype.DataSource = dproducttypeload.Tables[0];
                        drpproductiontype.DataTextField = "productiontype";
                        drpproductiontype.DataValueField = "productiontype";
                        drpproductiontype.DataBind();
                        drpproductiontype.Items.Insert(0, "All");
                        drpproductiontype.Enabled = false;
                        LoadDcNo();
                    }

                }
                else
                {
                    DataSet dproducttypeload = objbs.GetProducttype();
                    if (dproducttypeload.Tables[0].Rows.Count > 0)
                    {
                        drpproductiontype.DataSource = dproducttypeload.Tables[0];
                        drpproductiontype.DataTextField = "productiontype";
                        drpproductiontype.DataValueField = "productiontype";
                        drpproductiontype.DataBind();
                        drpproductiontype.Enabled = true;
                        Producttype_chnaged(sender, e);
                        // drpproductiontype.Items.Insert(0, "Select ProductionType");
                    }
                }

                txtDate.Text = DateTime.Today.ToString("dd/MM/yyy");
                DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            }

        }

        public void LoadDcNo()
        {
            DataSet ds = objbs.GetDCNONew(scode, Productioncode);
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

        protected void Producttype_chnaged(object sender, EventArgs e)
        {

            gvGoodsReceived.DataSource = null;
            gvGoodsReceived.DataBind();

            gvDetails.DataSource = null;
            gvDetails.DataBind();

            gvsummary.DataSource = null;
            gvsummary.DataBind();

            gvdetailsall.DataSource = null;
            gvdetailsall.DataBind();



            if (drpproductiontype.SelectedValue == "I")
            {
                DataSet ds = objbs.GetDCNONew(scode, Icingcode);
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
            else if (drpproductiontype.SelectedValue == "P")
            {
                DataSet ds = objbs.GetDCNONew(scode, Productioncode);
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

        protected void onrowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblReceived_Qty = ((Label)e.Row.FindControl("lblReceived_Qty"));
                lblReceived_Qty.Text = Convert.ToDouble(lblReceived_Qty.Text).ToString("" + qtysetting + "");
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

                #region PBranch Setting
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    Icingcode = dss.Tables[0].Rows[0]["IcingCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                string PbranchSend = string.Empty;

                if (drpproductiontype.SelectedValue == "All")
                {
                    PbranchSend = Productioncode;
                }
                else if (drpproductiontype.SelectedValue == "I")
                {
                    PbranchSend = Icingcode;
                }
                else if (drpproductiontype.SelectedValue == "P")
                {
                    PbranchSend = Productioncode;
                }

                #endregion

                DataSet ds = objbs.GoodReceivedNew(ddlDC.SelectedValue, scode, PbranchSend);
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

        protected void Newprint_click(object sender, EventArgs e)
        {
            gvsummary.Visible = false; ;
            gvDetails.Visible = false;
            gvdetailsall.Visible = false;
            DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            lbldate.Text = sDate.ToString("dd/MM/yyyy");

            DataSet ds = new DataSet();
            ds = objbs.GetItemreceivedDetails(sDate, scode, btnlist.SelectedValue);
            if (btnlist.SelectedValue == "1")
            {
                gvsummary.Visible = true;
                gvdetailsall.Visible = false;
                gvsummary.DataSource = ds;
                gvsummary.DataBind();
            }
            else
            {
                gvsummary.Visible = false; ;
                gvdetailsall.Visible = true;
                gvdetailsall.DataSource = ds;
                gvdetailsall.DataBind();
            }

        }

        protected void btnexport_click(object sender, EventArgs e)
        {


            gvsummary.Visible = false; ;
            gvdetailsall.Visible = false;
            gvDetails.Visible = false;
            DataSet ds = new DataSet();
            DateTime sDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            lbldate.Text = sDate.ToString("dd/MM/yyyy");
            ds = objbs.GetItemreceivedDetails(sDate, scode, btnlist.SelectedValue);
            if (btnlist.SelectedValue == "1")
            {
                gvsummary.Visible = true;
                gvdetailsall.Visible = false;

                string Caption = "Summary wise Qty on :- " + sDate.ToString("dd/MM/yyyy");
                gvsummary.Caption = Caption;
                gvsummary.DataSource = ds;
                gvsummary.DataBind();


                string filename = "SummaryQty.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                // gvsummary.Caption = "Stock Request from Branch Qty Store On " + sDate;
                // gridview.DataSource = ds;
                // gridview.DataBind();
                gvsummary.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                gvsummary.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                gvsummary.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                gvsummary.HeaderStyle.Font.Bold = true;
                //Get the HTML for the control.
                gvsummary.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
            else
            {
                gvsummary.Visible = false; ;
                gvdetailsall.Visible = true;

                string Caption = "Detailed Received Qty on :- " + sDate;
                gvdetailsall.Caption = Caption;
                gvdetailsall.DataSource = ds;
                gvdetailsall.DataBind();


                string filename = "DetailedQty.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                //gvdetailsall.Caption = "Stock Request from Branch Qty Store On " + sDate;
                // gridview.DataSource = ds;
                // gridview.DataBind();
                gvdetailsall.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                gvdetailsall.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                gvdetailsall.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                gvdetailsall.HeaderStyle.Font.Bold = true;
                //Get the HTML for the control.
                gvdetailsall.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }





        }

        protected void gvsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            int rec_qty = 0;
            int dmg_qty = 0;
            int mis_qty = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblReceived_Qty = ((Label)e.Row.FindControl("lblReceived_Qty"));
                lblReceived_Qty.Text = Convert.ToDouble(lblReceived_Qty.Text).ToString("" + qtysetting + "");
                Label lblmissing_qty = ((Label)e.Row.FindControl("lblmissing_qty"));
                lblmissing_qty.Text = Convert.ToDouble(lblmissing_qty.Text).ToString("" + qtysetting + "");
                Label lbldamage_qty = ((Label)e.Row.FindControl("lbldamage_qty"));
                lbldamage_qty.Text = Convert.ToDouble(lbldamage_qty.Text).ToString("" + qtysetting + "");





                rec_qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "received_qty"));
                dmg_qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "damage_qty"));
                mis_qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "missing_qty"));

                totrec_qty = totrec_qty + rec_qty;
                totdmg_qty = totdmg_qty + dmg_qty;
                totmis_qty = totmis_qty + mis_qty;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[1].Text = "Total :";
                e.Row.Cells[2].Text = totrec_qty.ToString();
                e.Row.Cells[3].Text = totmis_qty.ToString();
                e.Row.Cells[4].Text = totdmg_qty.ToString();

            }
        }


        protected void gvdetailsall_rowdatabound(object sender, GridViewRowEventArgs e)
        {

            int rec_qty = 0;
            int dmg_qty = 0;
            int mis_qty = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label lblReceived_Qty = ((Label)e.Row.FindControl("lblReceived_Qty"));
                lblReceived_Qty.Text = Convert.ToDouble(lblReceived_Qty.Text).ToString("" + qtysetting + "");
                Label lblmissing_qty = ((Label)e.Row.FindControl("lblmissing_qty"));
                lblmissing_qty.Text = Convert.ToDouble(lblmissing_qty.Text).ToString("" + qtysetting + "");
                Label lbldamage_qty = ((Label)e.Row.FindControl("lbldamage_qty"));
                lbldamage_qty.Text = Convert.ToDouble(lbldamage_qty.Text).ToString("" + qtysetting + "");


                rec_qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "received_qty"));
                dmg_qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "damage_qty"));
                mis_qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "missing_qty"));

                totrec_qty = totrec_qty + rec_qty;
                totdmg_qty = totdmg_qty + dmg_qty;
                totmis_qty = totmis_qty + mis_qty;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[3].Text = "Total :";
                e.Row.Cells[4].Text = totrec_qty.ToString();
                e.Row.Cells[5].Text = totmis_qty.ToString();
                e.Row.Cells[6].Text = totdmg_qty.ToString();

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


        protected void gvGoodTransFer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvsummary.Visible = false; ;
            gvdetailsall.Visible = false;
            if (e.CommandName == "Receive")
            {
                #region PBranch Setting
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    Icingcode = dss.Tables[0].Rows[0]["IcingCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                string PbranchSend = string.Empty;

                if (drpproductiontype.SelectedValue == "All")
                {
                    PbranchSend = Productioncode;
                }
                else if (drpproductiontype.SelectedValue == "I")
                {
                    PbranchSend = Icingcode;
                }
                else if (drpproductiontype.SelectedValue == "P")
                {
                    PbranchSend = Productioncode;
                }

                #endregion

                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string Dcno = commandArgs[0];
                string PRoreqno = commandArgs[1];
                string Breqno = commandArgs[2];

                Response.Redirect("GoodsReceivedNote.aspx?PReqNo=" + PRoreqno + "&DCNo=" + Dcno + "&Productioncode=" + PbranchSend + "&BReqNo=" + Breqno);
            }

            if (e.CommandName == "print")
            {

                #region PBranch Setting
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    Icingcode = dss.Tables[0].Rows[0]["IcingCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                string PbranchSend = string.Empty;

                if (drpproductiontype.SelectedValue == "All")
                {
                    PbranchSend = Productioncode;
                }
                else if (drpproductiontype.SelectedValue == "I")
                {
                    PbranchSend = Icingcode;
                }
                else if (drpproductiontype.SelectedValue == "P")
                {
                    PbranchSend = Productioncode;
                }

                #endregion

                gvDetails.Visible = true;
                DataSet ds = objbs.GoodReceivedListNew(ddlDC.SelectedValue, scode, PbranchSend);
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
                string caption = "Goods Received Details:" + "</br>" + "DC No " + gvGoodsReceived.Rows[0].Cells[0].Text + "</br>" + "DC Date " + Convert.ToDateTime(gvGoodsReceived.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Branch Request No:" + gvGoodsReceived.Rows[0].Cells[2].Text + "</br>" + " Print Time :" + DateTime.Now.ToString("MM/dd/yyyy hh:MM:tt") + " ";
                gvDetails.Caption = caption;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
            }

            if (e.CommandName == "view")
            {
                #region PBranch Setting
                DataSet dss = objbs.checkrequestallowornot(scode);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                    Icingcode = dss.Tables[0].Rows[0]["IcingCode"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                    return;
                }

                string PbranchSend = string.Empty;

                if (drpproductiontype.SelectedValue == "All")
                {
                    PbranchSend = Productioncode;
                }
                else if (drpproductiontype.SelectedValue == "I")
                {
                    PbranchSend = Icingcode;
                }
                else if (drpproductiontype.SelectedValue == "P")
                {
                    PbranchSend = Productioncode;
                }

                #endregion
                gvDetails.Visible = true;
                DataSet ds = objbs.GoodReceivedListNew(ddlDC.SelectedValue, scode, PbranchSend);
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

                string caption = "Goods Received Details:" + "</br>" + "DC No " + gvGoodsReceived.Rows[0].Cells[0].Text + "</br>" + "DC Date " + Convert.ToDateTime(gvGoodsReceived.Rows[0].Cells[1].Text).ToString("dd/MM/yyyy hh:MM:tt") + "</br>" + "Branch Request No:" + gvGoodsReceived.Rows[0].Cells[2].Text;
                gvDetails.Caption = caption;


            }
        }
    }
}