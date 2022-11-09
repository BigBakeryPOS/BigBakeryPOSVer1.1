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
    public partial class BillSettingForOrder : System.Web.UI.Page
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

            DataSet checknotpaid = objBs.notpadiexisisorbnotefororder(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName);
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

                //if (isadmin == "1")
                //{
                //    txtFromDate.Enabled = true;
                //}
                //else
                //{
                //    txtFromDate.Enabled = false;
                //}

                txtFromDate.Enabled = false;


                DataSet ds = objBs.CustomerorderGirdNewordersetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, Notpaid, "'1','4','10','16','17'");
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

                DataSet dscash = objBs.CustomerorderGirdNewordersettingforcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'1'");
                gridcash.DataSource = dscash;
                gridcash.DataBind();


                DataSet dscard = objBs.CustomerorderGirdNewordersettingforcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'4','10','17'");
                gridcard.DataSource = dscard;
                gridcard.DataBind();

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

            DataSet dscash = objBs.CustomerorderGirdNewordersettingforcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'1'");
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerorderGirdNewordersettingforcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'4','10','17'");
            gridcard.DataSource = dscard;
            gridcard.DataBind();
        }

        protected void Add_Click(object sender, EventArgs e)
        {

        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
           
        }
        protected void refresh_Click(object sender, EventArgs e)
        {


            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet ds = objBs.CustomerorderGirdNewordersetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, Notpaid, "'1','4','10','16','17'");
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
                Label lbltransorderid = (Label)gvsales.Rows[i].FindControl("lbltransorderid");
                string transorderid = lbltransorderid.Text;
                if (radbtn.SelectedValue == "1")
                {
                    isucess = objBs.updatepaymodeForORder(transorderid, radbtn.SelectedValue, sTableName);

                }
                else if (radbtn.SelectedValue == "4")
                {
                    isucess = objBs.updatepaymodeForORder(transorderid, radbtn.SelectedValue, sTableName);
                }
                else if (radbtn.SelectedValue == "10")
                {
                    isucess = objBs.updatepaymodeForORder(transorderid, radbtn.SelectedValue, sTableName);
                }
                else if (radbtn.SelectedValue == "17")
                {
                    isucess = objBs.updatepaymodeForORder(transorderid, radbtn.SelectedValue, sTableName);
                }

            }

            DataSet checknotpaid = objBs.notpadiexisisorbnotefororder(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName);
            if (checknotpaid.Tables[0].Rows.Count > 0)
            {
                Notpaid = "Yes";
            }
            else
            {
                Notpaid = "No";
            }

            DataSet ds = objBs.CustomerorderGirdNewordersetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, Notpaid, "'1','4','10','16','17'");
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

            DataSet dscash = objBs.CustomerorderGirdNewordersettingforcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'1'");
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerorderGirdNewordersettingforcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'4','10','17'");
            gridcard.DataSource = dscard;
            gridcard.DataBind();

        }
        protected void Search_Click(object sender, EventArgs e)
        {

            DataSet ds = objBs.CustomerorderGirdNewordersetting(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, Notpaid, "'1','4','10','16','17'");
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

            DataSet dscash = objBs.CustomerorderGirdNewordersettingforcash(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'1'");
            gridcash.DataSource = dscash;
            gridcash.DataBind();


            DataSet dscard = objBs.CustomerorderGirdNewordersettingforcard(Convert.ToInt32(Request.Cookies["userInfo"]["UserID"].ToString()), sTableName, "'4','10','17'");
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


            

        }



    }
}