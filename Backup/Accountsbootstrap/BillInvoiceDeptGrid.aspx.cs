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
using System.Configuration;
using System.Data.SqlClient;

namespace Billing.Accountsbootstrap
{
    public partial class BillInvoiceDeptGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        string superadmin = "";
        DBAccess DBAccess = new DBAccess();
        private string connnectionString;
        private string connnectionStringMain;
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            DataSet dchk = objBs.checkmailID(Convert.ToInt32(lblUserID.Text));
            if (dchk.Tables[0].Rows[0]["status"].ToString() == "Windows")
            {
                Response.Redirect("Home_Page.aspx");
            }

            if (!IsPostBack)
            {
                DataSet ds = objBs.GwtinvoiceBillDeptgrid(sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();

            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("BillInvoiceDeptEntry.aspx");



        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objBs.GwtinvoiceBillDeptgrid(sTableName);
            gvsales.PageIndex = e.NewPageIndex;
            gvsales.DataSource = ds;
            gvsales.DataBind();


        }
        protected void refresh_Click(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = objBs.GwtinvoiceBillDeptgrid(sTableName);
            gvsales.DataSource = ds;
            gvsales.DataBind();
            gvCustsales.Visible = false;


        }
        protected void Search_Click(object sender, EventArgs e)
        {


            DataSet ds = objBs.GwtinvoiceBillgridsearch_Dept(sTableName, ddlbillno.SelectedValue, txtAutoName.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //DataSet ds = objBs.CustomerSalesGirdbillNo(ddlbillno.SelectedValue);
                gvsales.DataSource = ds;
                gvsales.DataBind();
            }
            else
            {
                gvsales.DataSource = null;
                gvsales.DataBind();
            }




        }


        protected void gvsales_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

           

        }
        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "cancel")
            {

                refre.Visible = true;
                if (txtRef.Text != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill cannot be cancelled Without Ref No.Is in Process');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill cannot be cancelled Without Ref No.Is in Process');", true);


                }



            }

            else if (e.CommandName == "view")
            {
                DataSet ds = new DataSet();



                ds = objBs.GwtinvoiceBillgridbyid_Dept(sTableName, (e.CommandArgument.ToString()));
                gvCustsales.DataSource = ds.Tables[0];
                gvCustsales.DataBind();

            }

            else if (e.CommandName == "print")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Bill cannot be Print Is in Process');", true);

                //string billno = e.CommandArgument.ToString();


                //string yourUrl = "invoice_print.aspx?&iinvoiceID=" + billno;


                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void txtAutoName_TextChanged(object sender, EventArgs e)
        {
            if (txtAutoName.Text == "")
            {
                DataSet ds = objBs.GwtinvoiceBillDeptgrid(sTableName);
                gvsales.DataSource = ds;
                gvsales.DataBind();
                gvCustsales.Visible = false;

            }
            else
            {
                DataSet ds = objBs.GwtinvoiceBillgridsearch_Dept(sTableName, ddlbillno.SelectedValue, txtAutoName.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                    gvCustsales.Visible = true;


                }
                else
                {
                    gvsales.DataSource = null;
                    gvsales.DataBind();
                }
            }
        }

        protected void generate(object sender, EventArgs e)
        {
        }


        protected void cancel(object sender, EventArgs e)
        {
        }
        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    //  int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Values[0]);
                    //  string salestype = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    DataSet ds = objBs.gettransitemforid_Dept(sTableName, groupID.ToString());
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        //double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
                        //amount1 = amount1 + amount;
                        gv.DataBind();
                    }
                    //}
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;




            }

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {




        }

    }
}