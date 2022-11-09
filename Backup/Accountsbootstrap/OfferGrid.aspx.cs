using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class OfferGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        double GETVALUE = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["userInfo"]["User"] != null)
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            if (!IsPostBack)
            {

                DataSet dss = objbs.getalloffer();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = dss;
                    gridview.DataBind();
                }

                fromtime.Visible = false;
                totime.Visible = false;
                BindTime();

                DataSet dsCategory = objbs.gridcategory();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    chklistcategory.DataSource = dsCategory.Tables[0];
                    chklistcategory.DataTextField = "category";
                    chklistcategory.DataValueField = "CategoryID";
                    chklistcategory.DataBind();
                }
                {
                    
                    btnadd.Text = "Save";
                   
                }
            }
        }

        protected void gridview_rowcommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editt")
            {
                string offerid = e.CommandArgument.ToString();

                DataSet dsCategory = objbs.gridcategory();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {
                    chklistcategory.DataSource = dsCategory.Tables[0];
                    chklistcategory.DataTextField = "category";
                    chklistcategory.DataValueField = "CategoryID";
                    chklistcategory.DataBind();
                }

                
                if (offerid != null)
                {
                    //drpCategory.Enabled = false;

                    DataSet ds = objbs.get_offerforupdate(offerid);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        fromtime.Visible = true;
                        totime.Visible = true;
                        btnadd.Text = "Update";
                        txtcombiid.Text = ds.Tables[0].Rows[0]["offerid"].ToString();
                        txtcomboname.Text = ds.Tables[0].Rows[0]["offerName"].ToString();
                        txtdiscper.Text = ds.Tables[0].Rows[0]["offervalue"].ToString();
                        txtfromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fromdate"]).ToString("dd/MM/yyyy");
                        txttodate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Todate"]).ToString("dd/MM/yyyy");

                        DateTime dateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fromdate"]);
                        string strMinFormat = dateTime.ToString("h:mm tt");//12 hours format
                        ddlTimeFrom.SelectedValue = strMinFormat;

                        DateTime dateTime1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Todate"]);
                        string strMinFormat1 = dateTime1.ToString("h:mm tt");//12 hours format
                        ddlTimeTo.SelectedValue = strMinFormat1;
                        fromtime.Text = ds.Tables[0].Rows[0]["fromtt"].ToString();
                        totime.Text = ds.Tables[0].Rows[0]["tott"].ToString();
                        //  getttal.Text = ds.Tables[0].Rows[0]["TotalRate"].ToString();
                        drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();
                        drpisdiscount.SelectedValue = ds.Tables[0].Rows[0]["IsDiscount"].ToString();


                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            {
                                //Find the checkbox list items using FindByValue and select it.
                                chklistcategory.Items.FindByValue(ds.Tables[0].Rows[i]["Categoryid"].ToString()).Selected = true;
                            }
                        }

                    }
                }
            }
        }

        private void BindTime()
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
            //Set 5 minutes interval
            TimeSpan Interval = new TimeSpan(0, 30, 0);
            //To set 1 hour interval
            //TimeSpan Interval = new TimeSpan(1, 0, 0);           
            ddlTimeFrom.Items.Clear();
            ddlTimeTo.Items.Clear();
            while (StartTime <= EndTime)
            {
                ddlTimeFrom.Items.Add(StartTime.ToShortTimeString());
                ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }
            ddlTimeFrom.Items.Insert(0, new ListItem("Select From Time", "0"));
            ddlTimeTo.Items.Insert(0, new ListItem("Select To Time", "0"));
        }
        protected void addclick(object sender, EventArgs e)
        {
            double grandtotal = 0.00;
            DataSet duplicate = new DataSet();

            DateTime billldate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan time = Convert.ToDateTime(ddlTimeFrom.SelectedValue).TimeOfDay;

            DateTime fromresult = billldate + time;


            DateTime toodate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan totime = Convert.ToDateTime(ddlTimeTo.SelectedValue).TimeOfDay;

            DateTime toresult = toodate + totime;

            DataSet ndstt1 = new DataSet();
            DataTable ndttt1 = new DataTable();

            DataColumn ndc1 = new DataColumn("Catid");
            ndttt1.Columns.Add(ndc1);
            ndstt1.Tables.Add(ndttt1);

            if (chklistcategory.SelectedIndex > -1)
            {
                foreach (ListItem listItem in chklistcategory.Items)
                {

                    if (listItem.Selected)
                    {
                        DataRow ndrd1 = ndstt1.Tables[0].NewRow();
                        ndrd1["Catid"] = listItem.Value;
                        ndstt1.Tables[0].Rows.Add(ndrd1);
                    }
                }
            }
            else
            {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select any one Category.Thanks You!!!')", true);
                    return;
            }
           
            //if (drpCategory.SelectedValue == "Select Category")
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Category.Thanks You!!!')", true);
            //    return;
            //}
            if (btnadd.Text == "Save")
            {


                int isc = objbs.insertoffer(txtcomboname.Text, txtdiscper.Text, fromresult, toresult, drpisactive.SelectedValue,drpisdiscount.Text,ndstt1);


               
                Response.Redirect("OfferGrid.aspx");
            }
            else if (btnadd.Text == "Update")
            {

                int idelete = objbs.deleteoffer(txtcombiid.Text);


                int isc = objbs.Updateoffer(txtcombiid.Text,txtcomboname.Text, txtdiscper.Text, fromresult, toresult, drpisactive.SelectedValue, drpisdiscount.Text, ndstt1);
                //int isc = objbs.updateoffer(txtcomboname.Text, txt1.Text, drpCategory.SelectedValue, fromresult, toresult, offerid, Convert.ToInt32(drpisdiscount.Text), drpisactive.SelectedValue);

                Response.Redirect("OfferGrid.aspx");
            }

        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfferGrid.aspx");
        }



        private void FirstGridViewRow()
        {
           

        }

        protected void ButtonAdd1_Click(object sender, EventArgs e)
        {
           


        }



        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

        }

        private void AddNewRow()
        {
           
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           

        }


        private void SetRowData()
        {
            
        }


        private void SetPreviousData()
        {
           
        }
        protected void drpitem_changed(object sender, EventArgs e)
        {
           

        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
           


        }

    }
}