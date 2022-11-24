using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class NotificationPage : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string cust = "";
        string sTableName = "";
        string Rate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            //DataSet ds = objbs.iplist();
            //gvip.DataSource = ds.Tables[0];
            //gvip.DataBind();
            if (!IsPostBack)
            {
                DataSet dacess1 = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "notificationmsg");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Session["EmpId"].ToString(), "notificationmsg");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnadd.Visible = true;
                    }
                    else
                    {
                        btnadd.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gvip.Columns[5].Visible = true;
                    }
                    else
                    {
                        gvip.Columns[5].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                       // gv.Columns[3].Visible = true;
                    }
                    else
                    {
                        //gv.Columns[3].Visible = false;
                    }
                }

                BindTime();

                DataSet dsbranch = objbs.getbranch();
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    chkbranch.DataSource = dsbranch.Tables[0];
                    chkbranch.DataTextField = "BranchArea";
                    chkbranch.DataValueField = "BranchCode";
                    chkbranch.DataBind();

                }

                DataSet ds = objbs.gettoalmessgae();
                gvip.DataSource = ds.Tables[0];
                gvip.DataBind();
            }
        }

        protected void addclick(object sender, EventArgs e)
        {
            //objbs.Inserip(txtid.Text);
            //txtid.Text = "";
            //DataSet ds = objbs.iplist();
            //gvip.DataSource = ds.Tables[0];
            //gvip.DataBind();

            if (txtmsgtitle.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Message Title');", true);
                txtmsgtitle.Focus();
                return;
            }
            if (txtmessagecontent.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Message Content');", true);
                txtmsgtitle.Focus();
                return;
            }

            if (txtfromdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select From date');", true);
                txtfromdate.Focus();
                return;

            }
            if (txttodate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select To date');", true);
                txttodate.Focus();
                return;
            }

            DataSet ndstt = new DataSet();
            DataTable ndttt = new DataTable();

            DataColumn ndc = new DataColumn("Branchcode");
            ndttt.Columns.Add(ndc);

            ndc = new DataColumn("Branchname");
            ndttt.Columns.Add(ndc);

            ndstt.Tables.Add(ndttt);


            foreach (ListItem listItem in chkbranch.Items)
            {

                if (listItem.Selected)
                {
                    DataRow ndrd = ndstt.Tables[0].NewRow();
                    ndrd["Branchcode"] = listItem.Value;
                    ndrd["Branchname"] = listItem.Text;
                    ndstt.Tables[0].Rows.Add(ndrd);
                }
            }

            if (btnadd.Text == "Save")
            {

                DateTime billldate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan time = Convert.ToDateTime(ddlTimeFrom.SelectedValue).TimeOfDay;

                DateTime fromresult = billldate + time;


                DateTime toodate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan totime = Convert.ToDateTime(ddlTimeTo.SelectedValue).TimeOfDay;

                DateTime toresult = toodate + totime;


                int isc = objbs.insertmessgae(txtmsgtitle.Text, txtmessagecontent.Text, fromresult, toresult, drpisactive.SelectedValue);
                int ibrachinsert = objbs.inserttransmessgae(ndstt);
            }
            else
            {

                int issc = objbs.deletetransmessgae(lblmessgaeid.Text);

                DateTime billldate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan time = Convert.ToDateTime(ddlTimeFrom.SelectedValue).TimeOfDay;

                DateTime fromresult = billldate + time;


                DateTime toodate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan totime = Convert.ToDateTime(ddlTimeTo.SelectedValue).TimeOfDay;

                DateTime toresult = toodate + totime;

                int isc = objbs.Updatemessgae(txtmsgtitle.Text, txtmessagecontent.Text, fromresult, toresult, drpisactive.SelectedValue, lblmessgaeid.Text);
                int ibrachinsert = objbs.inserttransmessgaeForUpdate(ndstt,lblmessgaeid.Text);

            }


            Response.Redirect("NotificationPage.aspx");
        }

        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edits")
            {
                DataSet dsbranch = objbs.getbranch();
                if (dsbranch.Tables[0].Rows.Count > 0)
                {
                    chkbranch.DataSource = dsbranch.Tables[0];
                    chkbranch.DataTextField = "BranchArea";
                    chkbranch.DataValueField = "BranchCode";
                    chkbranch.DataBind();

                }
                string iCat = e.CommandArgument.ToString();
                DataSet ds = objbs.get_happyhoursforupdate(iCat);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    fromtime.Visible = true;
                    totime.Visible = true;
                    btnadd.Text = "Update";
                    btnadd.Visible = false;
                    lblmessgaeid.Text = ds.Tables[0].Rows[0]["MessageId"].ToString();
                    txtmsgtitle.Text = ds.Tables[0].Rows[0]["MessageTitle"].ToString();
                    txtmessagecontent.Text = ds.Tables[0].Rows[0]["MessageContent"].ToString();
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
                    drpisactive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();

                    DataSet dgetcategorybranch = objbs.gettransmeessage(iCat);
                    if (dgetcategorybranch.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dgetcategorybranch.Tables[0].Rows.Count - 1; i++)
                        {
                            {
                                //Find the checkbox list items using FindByValue and select it.
                                chkbranch.Items.FindByValue(dgetcategorybranch.Tables[0].Rows[i]["BranchCode"].ToString()).Selected = true;
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
    }
}