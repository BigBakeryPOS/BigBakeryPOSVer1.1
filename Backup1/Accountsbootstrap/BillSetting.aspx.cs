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
    public partial class BillSetting : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        double amount1 = 0;
        string brach = string.Empty;
        string isadmin = string.Empty;
        string Notpaid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            isadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();

            DataSet checknotpaid = objBs.NotpadiBillexisitsOrNot(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            if (checknotpaid.Tables[0].Rows.Count > 0)
            {
                Notpaid = "Yes";
            }
            else
            {
                Notpaid = "No";
            }
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                if (isadmin == "1")
                {
                    txtFromDate.Enabled = true;
                }
                else
                {
                    txtFromDate.Enabled = false;
                }




                DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
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

                DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gridcash.DataSource = dscash;
                gridcash.DataBind();


                DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
                gridcard.DataSource = dscard;
                gridcard.DataBind();

            }
        }

        protected void Bill_chnage(object sender, EventArgs e)
        {
            DataSet ds = objBs.CustomerSalesGirdNewbillsetting_search(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, "No", txtAutoName.Text);
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

        protected void radselect_All(object sender, EventArgs e)
        {
            for (int i = 0; i < gvsales.Rows.Count; i++)
            {
                RadioButtonList radbtn = (RadioButtonList)gvsales.Rows[i].FindControl("lblradtype");

                if (allradselect.SelectedValue == "1")
                {
                    radbtn.SelectedValue = "1";
                }
                else
                {
                    radbtn.SelectedValue = "4";
                }
            }

            DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcard.DataSource = dscard;
            gridcard.DataBind();
        }

        protected void Add_Click(object sender, EventArgs e)
        {

            Response.Redirect("newbutton.aspx");
            //System.Diagnostics.ProcessStartInfo startInfo;

            //Process p = new Process();

            //startInfo = new System.Diagnostics.ProcessStartInfo(@"E:\magil hotel\magilam\magilam\bin\Debug\magilam.exe");
            //p.StartInfo = startInfo;

            //p.Start();


        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.PageIndex = e.NewPageIndex;
            gvsales.DataSource = ds;
            gvsales.DataBind();


        }
        protected void refresh_Click(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = objBs.CustomerSalesGird(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gvsales.DataSource = ds;
            gvsales.DataBind();
            //gvCustsales.Visible = false;

        }
        protected void process_Click(object sender, EventArgs e)
        {

            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objBs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }

            int isucess = 0;
            for (int i = 0; i < gvsales.Rows.Count; i++)
            {
                RadioButtonList radbtn = (RadioButtonList)gvsales.Rows[i].FindControl("lblradtype");
                Label lblsalesid = (Label)gvsales.Rows[i].FindControl("lblsalesid");
                string salesid = lblsalesid.Text;
                if (radbtn.SelectedValue == "1")
                {
                    isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);

                }
                else if (radbtn.SelectedValue == "4")
                {
                    isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                }
                else if (radbtn.SelectedValue == "10")
                {
                    isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                }
                else if (radbtn.SelectedValue == "17")
                {
                    isucess = objBs.updatepaymode(salesid, radbtn.SelectedValue, sTableName);
                }

            }

            DataSet checknotpaid = objBs.NotpadiBillexisitsOrNot(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            if (checknotpaid.Tables[0].Rows.Count > 0)
            {
                Notpaid = "Yes";
            }
            else
            {
                Notpaid = "No";
            }

            DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
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

            DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcard.DataSource = dscard;
            gridcard.DataBind();

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            DataSet ds = objBs.CustomerSalesGirdNewbillsetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName, Notpaid);
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

            DataSet dscash = objBs.CustomerSalesGirdNewbillsettingcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerSalesGirdNewbillsettingcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), "tblSales_" + sTableName);
            gridcard.DataSource = dscard;
            gridcard.DataBind();



        }




        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void txtAutoName_TextChanged(object sender, EventArgs e)
        {

        }



        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
            //    GridView gvGroup = (GridView)sender;
            //    if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
            //    {
            //        int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
            //        DataSet ds = objBs.CustomerSalesdetailed(groupID, sTableName);
            //        //if (ds.Tables[0].Rows.Count > 0)
            //        //{
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            gv.DataSource = ds;
            //            double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
            //            amount1 = amount1 + amount;
            //            gv.DataBind();
            //        }
            //        //}
            //    }

            //}

            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

            //    //e.Row.Cells[0].Text = "Total";

            //    //e.Row.Cells[7].Text = amount1.ToString("N2");
            //    //e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

            //}

        }



    }
}