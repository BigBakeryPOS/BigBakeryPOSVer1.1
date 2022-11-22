using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class ItemUpdateScreen : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sCode = "";
        string sTableName = "";
        string superadmin = "";
        string ratesetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();

            if (!IsPostBack)
            {


                DataSet Category = objbs.getcatforstk();
                if (Category.Tables[0].Rows.Count > 0)
                {
                    ddlcategory.DataSource = Category.Tables[0];
                    ddlcategory.DataTextField = "Category";
                    ddlcategory.DataValueField = "Categoryid";
                    ddlcategory.DataBind();
                    ddlcategory.Items.Insert(0, "Select");
                }

            }



        }

        //protected void mrp_calculation(object sender, EventArgs e)
        //{
        //    double beforeamount = 0;
        //    double mrp = 0;
        //    double tax = 0;
        //    double bA = 0;
        //    txtMRPPrice.Enabled = false;
        //    txtRate.Enabled = false;
        //    if (txtMRPPrice.Text == "")
        //        txtMRPPrice.Text = "0";

        //    if (txtRate.Text == "")
        //        txtRate.Text = "0";

        //    if (drpratetype.SelectedValue == "1")
        //    {

        //        mrp = Convert.ToDouble(txtMRPPrice.Text);
        //        tax = Convert.ToDouble(ddltax.SelectedItem.Text);
        //        bA = (mrp / (100 + tax)) * 100;
        //        txtRate.Text = bA.ToString("0.00");
        //        txtMRPPrice.Enabled = true;
        //    }
        //    else if (drpratetype.SelectedValue == "2")
        //    {
        //        //  txtRate.Text = txtmrp.Text ;
        //        txtRate.Enabled = true;
        //        mrp = Convert.ToDouble(txtRate.Text);

        //        tax = Convert.ToDouble(ddltax.SelectedItem.Text);

        //        double totalrate = (mrp * tax) / 100;

        //        double total = mrp + totalrate;

        //        txtMRPPrice.Text = Convert.ToDouble(total).ToString("f2");
        //    }


        //}

        protected void Rate_changed(object sender, EventArgs e)
        {
            double beforeamount = 0;
            double mrp = 0;
            double tax = 0;
            double bA = 0;

            TextBox ddl = (TextBox)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            TextBox txtitemname = (TextBox)row.FindControl("txtitemname");

            TextBox txtprintitemname = (TextBox)row.FindControl("txtprintitemname");

            TextBox txtHSNcode = (TextBox)row.FindControl("txtHSNcode");

            Label lblitemid = (Label)row.FindControl("lblitemid");

            DropDownList ddltax = (DropDownList)row.FindControl("ddltax");
            TextBox txtrate = (TextBox)row.FindControl("txtrate");
            TextBox txtmrprate = (TextBox)row.FindControl("txtmrprate");
            DropDownList drpuom = (DropDownList)row.FindControl("drpuom");
            DropDownList drpisactivee = (DropDownList)row.FindControl("drpisactive");
            DropDownList drpdispalyonline = (DropDownList)row.FindControl("drpdispalyonline");


            txtrate.Enabled = true;
            mrp = Convert.ToDouble(txtrate.Text);

            tax = Convert.ToDouble(ddltax.SelectedItem.Text);

            double totalrate = (mrp * tax) / 100;

            double total = mrp + totalrate;

            txtmrprate.Text = Convert.ToDouble(total).ToString("" + ratesetting + "");

        }

        protected void MRP_changed(object sender, EventArgs e)
        {

            double beforeamount = 0;
            double mrp = 0;
            double tax = 0;
            double bA = 0;

            TextBox ddl = (TextBox)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            TextBox txtitemname = (TextBox)row.FindControl("txtitemname");

            TextBox txtprintitemname = (TextBox)row.FindControl("txtprintitemname");

            TextBox txtHSNcode = (TextBox)row.FindControl("txtHSNcode");

            Label lblitemid = (Label)row.FindControl("lblitemid");

            DropDownList ddltax = (DropDownList)row.FindControl("ddltax");
            TextBox txtrate = (TextBox)row.FindControl("txtrate");
            TextBox txtmrprate = (TextBox)row.FindControl("txtmrprate");
            DropDownList drpuom = (DropDownList)row.FindControl("drpuom");
            DropDownList drpisactivee = (DropDownList)row.FindControl("drpisactive");
            DropDownList drpdispalyonline = (DropDownList)row.FindControl("drpdispalyonline");

            mrp = Convert.ToDouble(txtmrprate.Text);
            tax = Convert.ToDouble(ddltax.SelectedItem.Text);
            bA = (mrp / (100 + tax)) * 100;
            txtrate.Text = bA.ToString("" + ratesetting + "");
        }


        protected void overall_itemsearch(object sender, EventArgs e)
        {
            DataSet dgetallitem = objbs.getitemss_newsearch(txtoverallitem.Text, drpisactive.SelectedValue);
            if (dgetallitem.Tables[0].Rows.Count > 0)
            {
                gvproatkDetails.DataSource = dgetallitem.Tables[0];
                gvproatkDetails.DataBind();
            }
            else
            {
                gvproatkDetails.DataSource = null;
                gvproatkDetails.DataBind();
            }

            for (int vLoop = 0; vLoop < gvproatkDetails.Rows.Count; vLoop++)
            {
                DropDownList ddltax = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("ddltax");
                DropDownList drpuom = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpuom");
                DropDownList drpisactivee = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpisactive");
                DropDownList drpdispalyonline = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpdispalyonline");
                Label lblitemid = (Label)gvproatkDetails.Rows[vLoop].FindControl("lblitemid");


                for (int j = 0; j < dgetallitem.Tables[0].Rows.Count; j++)
                {
                    string itemid = dgetallitem.Tables[0].Rows[j]["itemid"].ToString();
                    string taxval = dgetallitem.Tables[0].Rows[j]["taxval"].ToString();
                    string unit = dgetallitem.Tables[0].Rows[j]["unit"].ToString();
                    string isdelte = dgetallitem.Tables[0].Rows[j]["isdelete"].ToString();
                    string dispayitem = dgetallitem.Tables[0].Rows[j]["DisplayOnline"].ToString();

                    if (itemid == lblitemid.Text)
                    {
                        ddltax.SelectedValue = taxval;
                        drpuom.SelectedValue = unit;
                        drpisactivee.SelectedValue = isdelte;
                        drpdispalyonline.SelectedValue = dispayitem;
                        break;

                    }

                }


            }
        }

        protected void btnadd_OnClick(object sender, EventArgs e)
        {

            //gvproatkDetails.DataSource = null;
            //gvproatkDetails.DataBind();
            //DataSet ds = objbs.getaccepttransfer(sTableName, ddlcategory.SelectedValue, txtfrmdate.Text, txttodate.Text);
            //gvproatkDetails.DataSource = ds;
            //gvproatkDetails.DataBind();
        }


        protected void btnupdate_click(object sender, EventArgs e)
        {
            Button ddl = (Button)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;

            TextBox txtitemname = (TextBox)row.FindControl("txtitemname");

            TextBox txtprintitemname = (TextBox)row.FindControl("txtprintitemname");

            TextBox txtHSNcode = (TextBox)row.FindControl("txtHSNcode");

            Label lblitemid = (Label)row.FindControl("lblitemid");

            DropDownList ddltax = (DropDownList)row.FindControl("ddltax");
            TextBox txtrate = (TextBox)row.FindControl("txtrate");
            TextBox txtmrprate = (TextBox)row.FindControl("txtmrprate");
            DropDownList drpuom = (DropDownList)row.FindControl("drpuom");
            DropDownList drpisactivee = (DropDownList)row.FindControl("drpisactive");
            DropDownList drpdispalyonline = (DropDownList)row.FindControl("drpdispalyonline");
            string actuive = "Yes";
            if (drpisactivee.SelectedValue == "0")
            {
                actuive = "Yes";
            }
            else
            {
                actuive = "No";
            }

            int isucess = objbs.updatecategoryitemquick(txtitemname.Text, ddltax.SelectedValue, ddltax.SelectedItem.Text, txtrate.Text, drpuom.SelectedValue, lblitemid.Text, txtprintitemname.Text, txtHSNcode.Text, drpisactivee.SelectedValue, actuive, superadmin, drpuom.SelectedItem.Text, drpdispalyonline.SelectedValue,txtmrprate.Text);

            if (txtoverallitem.Text != "")
            {
              DataSet  dgetallitem = objbs.getitemss_newsearch(txtoverallitem.Text, drpisactive.SelectedValue);
                if (dgetallitem.Tables[0].Rows.Count > 0)
                {
                    gvproatkDetails.DataSource = dgetallitem.Tables[0];
                    gvproatkDetails.DataBind();
                }
                else
                {
                    gvproatkDetails.DataSource = null;
                    gvproatkDetails.DataBind();
                }
            }
            else
            {
                if (ddlcategory.SelectedValue == "Select")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Category');", true);
                    return;
                }
                DataSet dgetallitem = new DataSet();

                if (txtoverallitem.Text == "")
                {
                    dgetallitem = objbs.getitemss(ddlcategory.SelectedValue, drpisactive.SelectedValue);
                    if (dgetallitem.Tables[0].Rows.Count > 0)
                    {
                        gvproatkDetails.DataSource = dgetallitem.Tables[0];
                        gvproatkDetails.DataBind();
                    }

                }
                else
                {
                    dgetallitem = objbs.getitemss_newsearch(txtoverallitem.Text, drpisactive.SelectedValue);
                    if (dgetallitem.Tables[0].Rows.Count > 0)
                    {
                        gvproatkDetails.DataSource = dgetallitem.Tables[0];
                        gvproatkDetails.DataBind();
                    }
                    else
                    {
                        gvproatkDetails.DataSource = null;
                        gvproatkDetails.DataBind();
                    }
                }

                for (int vLoop = 0; vLoop < gvproatkDetails.Rows.Count; vLoop++)
                {
                    DropDownList ddltax1 = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("ddltax");
                    DropDownList drpuom1 = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpuom");
                    DropDownList drpisactivee1 = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpisactive");
                    DropDownList drpdispalyonline1 = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpdispalyonline");
                    Label lblitemid1 = (Label)gvproatkDetails.Rows[vLoop].FindControl("lblitemid");


                    for (int j = 0; j < dgetallitem.Tables[0].Rows.Count; j++)
                    {
                        string itemid = dgetallitem.Tables[0].Rows[j]["itemid"].ToString();
                        string taxval = dgetallitem.Tables[0].Rows[j]["taxval"].ToString();
                        string unit = dgetallitem.Tables[0].Rows[j]["unit"].ToString();
                        string isdelte = dgetallitem.Tables[0].Rows[j]["isdelete"].ToString();
                        string dispayitem = dgetallitem.Tables[0].Rows[j]["DisplayOnline"].ToString();

                        if (itemid == lblitemid1.Text)
                        {
                            ddltax1.SelectedValue = taxval;
                            drpuom1.SelectedValue = unit;
                            drpisactivee1.SelectedValue = isdelte;
                            drpdispalyonline1.SelectedValue = dispayitem;
                            break;

                        }

                    }


                }
            }
        }

        protected void active_indexchnaged(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue == "Select")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Category');", true);
                return;
            }
            else
            {
                DataSet dgetallitem = objbs.getitemss(ddlcategory.SelectedValue, drpisactive.SelectedValue);
                if (dgetallitem.Tables[0].Rows.Count > 0)
                {
                    gvproatkDetails.DataSource = dgetallitem.Tables[0];
                    gvproatkDetails.DataBind();
                }
                else
                {
                    gvproatkDetails.DataSource = null;
                    gvproatkDetails.DataBind();
                }

                for (int vLoop = 0; vLoop < gvproatkDetails.Rows.Count; vLoop++)
                {
                    DropDownList ddltax = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("ddltax");
                    DropDownList drpuom = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpuom");
                    DropDownList drpisactivee = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpisactive");
                    DropDownList drpdispalyonline = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpdispalyonline");
                    Label lblitemid = (Label)gvproatkDetails.Rows[vLoop].FindControl("lblitemid");


                    for (int j = 0; j < dgetallitem.Tables[0].Rows.Count; j++)
                    {
                        string itemid = dgetallitem.Tables[0].Rows[j]["itemid"].ToString();
                        string taxval = dgetallitem.Tables[0].Rows[j]["taxval"].ToString();
                        string unit = dgetallitem.Tables[0].Rows[j]["unit"].ToString();
                        string isdelte = dgetallitem.Tables[0].Rows[j]["isdelete"].ToString();
                        string dispayitem = dgetallitem.Tables[0].Rows[j]["DisplayOnline"].ToString();

                        if (itemid == lblitemid.Text)
                        {
                            ddltax.SelectedValue = taxval;
                            drpuom.SelectedValue = unit;
                            drpisactivee.SelectedValue = isdelte;
                            drpdispalyonline.SelectedValue = dispayitem;
                            break;

                        }

                    }


                }
            }
        }


        protected void catergory_changed(object sender, EventArgs e)
        {
            if (ddlcategory.SelectedValue == "Select")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please Select Category');", true);
                return;
            }
            else
            {
                DataSet dgetallitem = objbs.getitemss(ddlcategory.SelectedValue, drpisactive.SelectedValue);
                if (dgetallitem.Tables[0].Rows.Count > 0)
                {
                    gvproatkDetails.DataSource = dgetallitem.Tables[0];
                    gvproatkDetails.DataBind();
                }
                else
                {
                    gvproatkDetails.DataSource = null;
                    gvproatkDetails.DataBind();
                }
                for (int vLoop = 0; vLoop < gvproatkDetails.Rows.Count; vLoop++)
                {
                    DropDownList ddltax = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("ddltax");
                    DropDownList drpuom = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpuom");
                    DropDownList drpisactivee = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpisactive");
                    DropDownList drpdispalyonline = (DropDownList)gvproatkDetails.Rows[vLoop].FindControl("drpdispalyonline");
                    Label lblitemid = (Label)gvproatkDetails.Rows[vLoop].FindControl("lblitemid");


                    for (int j = 0; j < dgetallitem.Tables[0].Rows.Count; j++)
                    {
                        string itemid = dgetallitem.Tables[0].Rows[j]["itemid"].ToString();
                        string taxval = dgetallitem.Tables[0].Rows[j]["taxval"].ToString();
                        string unit = dgetallitem.Tables[0].Rows[j]["unit"].ToString();
                        string isdelte = dgetallitem.Tables[0].Rows[j]["isdelete"].ToString();
                        string dispayitem = dgetallitem.Tables[0].Rows[j]["DisplayOnline"].ToString();

                        if (itemid == lblitemid.Text)
                        {
                            ddltax.SelectedValue = taxval;
                            drpuom.SelectedValue = unit;
                            drpisactivee.SelectedValue = isdelte;
                            drpdispalyonline.SelectedValue = dispayitem;
                            break;

                        }

                    }


                }
            }
        }

        protected void gvcustomerorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DataSet dunits = objbs.getUOM();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList ddlunits = (DropDownList)(e.Row.FindControl("drpuom") as DropDownList);

                if (dunits.Tables[0].Rows.Count > 0)
                {
                    ddlunits.DataSource = dunits.Tables[0];
                    ddlunits.DataTextField = "UOM";
                    ddlunits.DataValueField = "UOMID";
                    ddlunits.DataBind();
                    // ddlunits.Items.Insert(0, "Select");
                }

                DropDownList ddltax = (DropDownList)(e.Row.FindControl("ddltax") as DropDownList);

                DataSet dstax = objbs.getTAX();

                if (dstax.Tables[0].Rows.Count > 0)
                {
                    ddltax.DataSource = dstax.Tables[0];
                    ddltax.DataTextField = "TaxName";
                    ddltax.DataValueField = "Taxid";
                    ddltax.DataBind();

                }



            }
        }
        protected void btnexp_Click(object sender, EventArgs e)
        {

        }
    }
}
