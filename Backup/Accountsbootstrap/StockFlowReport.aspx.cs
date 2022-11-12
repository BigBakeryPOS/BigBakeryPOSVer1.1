using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BusinessLayer;
namespace Billing.Accountsbootstrap
{
    public partial class StockFlowReport : System.Web.UI.Page
    {
        string sTableName = "";
        string sCode = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    ddlBranch.Visible = true;
                }
                else
                {
                    ddlBranch.Visible = false;
                }
            }
           
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txttodate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txttodate.Text = "";
                }
            }
        }
        protected void btnser_Click(object sender, EventArgs e)
        {DataTable dt=new DataTable();
        if (sTableName == "admin")
        {

            if (ddlBranch.SelectedValue == "co1")
            {
                lblUserID.Text = "5";
                sCode = "KK";
            }
            else if (ddlBranch.SelectedValue == "co2")
            {
                lblUserID.Text = "6";
                sCode = "BY";
            }
            else if (ddlBranch.SelectedValue == "co3")
            {
                lblUserID.Text = "7";
                sCode = "BB";
            }
            else if (ddlBranch.SelectedValue == "co4")
            {
                lblUserID.Text = "11";
                sCode = "NP";
            }
            else if (ddlBranch.SelectedValue == "co5")
            {
                lblUserID.Text = "14";
                sCode = "NE";
            }
            else if (ddlBranch.SelectedValue == "co6")
            {
                lblUserID.Text = "17";
                sCode = "MD";
            }
            else if (ddlBranch.SelectedValue == "co7")
            {
                lblUserID.Text = "19";
                sCode = "PU";
            }
            else if (ddlBranch.SelectedValue == "co8")
            {
                lblUserID.Text = "26";
                sCode = "CH";
            }

            else if (ddlBranch.SelectedValue == "co9")
            {
                lblUserID.Text = "27";
                sCode = "TH";
            }
            else if (ddlBranch.SelectedValue == "co10")
            {
                lblUserID.Text = "28";
                sCode = "PER";
            }
            else if (ddlBranch.SelectedValue == "co11")
            {
                lblUserID.Text = "29";
                sCode = "PAL1";
            } 

            dt = objbs.dElobratedGRN(ddlBranch.SelectedValue, Convert.ToInt32(lblUserID.Text), txttodate.Text, sCode);
        
        }
        else
        {
            dt = objbs.dElobratedGRN(sTableName, Convert.ToInt32(lblUserID.Text), txttodate.Text, sCode);
        }

            gvDetails.DataSource = dt;
            gvDetails.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Branch = "";
            if (sTableName == "CO1")
                Branch = "Kk nagar";
            else if (sTableName == "CO2")
                Branch = "Byepass";
            else if (sTableName == "CO3")
                Branch = "BB kulam";
            else if (sTableName == "CO4")
                Branch = "Narayanapuram";
            else if (sTableName == "CO5")
                Branch = "Palayankottal";
            else if (sTableName == "CO6")
                Branch = "Maduravayol";
            else if (sTableName == "CO7")
                Branch = "purasavakkam";

            else if (sTableName == "CO8")
                Branch = "Chennai Pothys";

            else if (sTableName == "CO9")
                Branch = "Thirunelveli";

            else if (sTableName == "CO10")
                Branch = "Periyar";
            else if (sTableName == "CO11")
                Branch = "Palayam";
            else
                Branch = ddlBranch.SelectedItem.Text;
        gvDetails.Caption = Branch + " GRN Report " + DateTime.Now.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }
    }
}