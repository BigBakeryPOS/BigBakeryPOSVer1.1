using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class RequestStockSettings : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        string Sort_Direction = "Category ASC";
        string sTableName = "";
        string superadmin = "";

        private string connnectionString;
        private string connnectionStringMain;
        protected void Page_Load(object sender, EventArgs e)
        {

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
         
            if (!IsPostBack)
            {


                DataSet dsgvbranch = objBs.gridcategory();

                DataSet dsgrid = objBs.gridcategory();
                chkcategory.DataSource = dsgrid;
                chkcategory.DataTextField = "Category";
                chkcategory.DataValueField = "Categoryid";
                chkcategory.DataBind();



                fromtime.Visible = false;
                totime.Visible = false;
                BindTime();

                
                // btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();


                DataSet ds = objBs.GetRequestStockSettings();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                            //lblCatID.InnerText = dID.Tables[0].Rows[0]["CategoryID"].ToString();

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


        protected void Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    
     

     
        public SortDirection dir
        {

            get
            {

                if (ViewState["dirState"] == null)
                {

                    ViewState["dirState"] = SortDirection.Ascending;

                }

                return (SortDirection)ViewState["dirState"];

            }

            set
            {

                ViewState["dirState"] = value;

            }

        }





        protected void gridview_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }

            DataSet ds = objBs.gridcategory();

            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gridview.DataSource = dvEmp;
            gridview.DataBind();
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestStockSettings.aspx");
        }


        protected void gvcat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                string iCat = e.CommandArgument.ToString();
                
                if (iCat != "" || iCat != null)
                {
                    lblrequeststockid.InnerText=iCat;
                    DataSet ds = objBs.getRequestStockSettingsvalues(iCat);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnSave.Text = "Update";

                        
                        DateTime dateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fromtime"]);
                        string strMinFormat = dateTime.ToString("h:mm tt");//12 hours format
                        ddlTimeFrom.SelectedValue = strMinFormat;

                        DateTime dateTime1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["ToTime"]);
                        string strMinFormat1 = dateTime1.ToString("h:mm tt");//12 hours format
                        ddlTimeTo.SelectedValue = strMinFormat1;

                        txtdelayday.Text = ds.Tables[0].Rows[0]["Delaydays"].ToString();


                        DataSet dsdet = objBs.GretTransRequestStockSettings(iCat);

                        foreach (ListItem chk in chkcategory.Items)
                        {
                            chk.Selected = false;
                        }


                        for (int i = 0; i < dsdet.Tables[0].Rows.Count; i++)
                        {

                            chkcategory.Items.FindByValue(dsdet.Tables[0].Rows[i]["CategoryId"].ToString()).Selected = true;
                        }

                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objBs.deleteRequestStockSettings(e.CommandArgument.ToString());
                    Response.Redirect("../Accountsbootstrap/RequestStockSettings.aspx");
                }
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            string request = "0";
            string production = "0";
            string manualGRN = "0";

            bool check = false;

            foreach (ListItem chk in chkcategory.Items)
            {
                if (chk.Selected == true)
                {
                    check = true;
                }
            }

            string today = System.DateTime.Now.ToString("dd/MM/yyyy");

            DateTime billldate = DateTime.ParseExact(today, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan time = Convert.ToDateTime(ddlTimeFrom.SelectedValue).TimeOfDay;

            DateTime fromresult = billldate + time;

            TimeSpan totime = Convert.ToDateTime(ddlTimeTo.SelectedValue).TimeOfDay;

            DateTime toresult = billldate + totime;

          
             
                if (check==false)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please select the category!');", true);
                    return;

                }
                else if((ddlTimeFrom.SelectedValue=="0")||(ddlTimeFrom.SelectedValue=="Select From Time"))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please select From time!');", true);
                    return;
                }

                 else if((ddlTimeTo.SelectedValue=="0")||(ddlTimeTo.SelectedValue=="Select To Time"))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please select To time!');", true);
                    return;
                }

              
               

                       DataSet ds = new DataSet();
                    DataColumn dct;
                    DataSet dstd = new DataSet();
                 DataTable   dttt = new DataTable();
                 DataRow drNew ;//= new DataRow();
                    dct = new DataColumn("CategoryId");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Category");
                    dttt.Columns.Add(dct);

                    ds.Tables.Add(dttt);

                    foreach (ListItem chk in chkcategory.Items)
                    {
                        if (chk.Selected== true)
                        {
                            drNew = dttt.NewRow();
                            drNew["CategoryId"] = chk.Value;
                            drNew["Category"] = chk.Text;
                            ds.Tables[0].Rows.Add(drNew);
                             }

                    }

             if (btnSave.Text == "Save")
            {
                DataSet dsres = objBs.CheckRequestStockSettings(fromresult, toresult);

                 if(dsres.Tables[0].Rows.Count>0)
                 {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    for (int j = 0; j < dsres.Tables[0].Rows.Count; j++)
                    {
                        if (dsres.Tables[0].Rows[j]["categoryid"].ToString() == ds.Tables[0].Rows[i]["categoryid"].ToString())
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Category "+ds.Tables[0].Rows[i]["category"]+" is already in request settings!');", true);
                            return;
                        }
                    }
                }
                }
                    int iStatus = objBs.InsertRequestStockSettings(fromresult, toresult, txtdelayday.Text,ds);

                 //   Response.Redirect("../Accountsbootstrap/RequestStockSettings.aspx");
                }
            

             else   if (btnSave.Text == "Update")
            
            {
                DataSet dsres = objBs.CheckRequestStockSettings_edit(fromresult, toresult,lblrequeststockid.InnerText);

                if (dsres.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        for (int j = 0; j < dsres.Tables[0].Rows.Count; j++)
                        {
                            if (dsres.Tables[0].Rows[j]["categoryid"].ToString() == ds.Tables[0].Rows[i]["categoryid"].ToString())
                            {
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Selected Category " + ds.Tables[0].Rows[i]["category"] + " is already in request settings!');", true);
                                return;
                            }
                        }
                    }
                }
                     int iStatus = objBs.UpdateRequestStockSettings(lblrequeststockid.InnerText, fromresult, toresult, txtdelayday.Text,ds);

                     Response.Redirect("../Accountsbootstrap/RequestStockSettings.aspx");

          
            //    Response.Redirect("../Accountsbootstrap/RequestStockSettings.aspx");
            }
             lblrequeststockid.InnerText = "";
             Response.Redirect("../Accountsbootstrap/RequestStockSettings.aspx");

        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;



            SqlConnection source = new SqlConnection(connnectionStringMain);

            SqlConnection destination = new SqlConnection(connnectionString);


            SqlCommand cmditem = new SqlCommand("truncate table tblCategory", destination);
            SqlCommand cmdbranch = new SqlCommand("truncate table tblMargin", destination);



            // Open source and destination connections.
            source.Open();
            destination.Open();
            cmditem.ExecuteNonQuery();
            cmdbranch.ExecuteNonQuery();




            // Select data from Products table
            cmditem = new SqlCommand("SELECT * FROM tblcategory", source);
            cmdbranch = new SqlCommand("SELECT * FROM tblMargin", source);



            // Create SqlBulkCopy
            SqlBulkCopy bulkData = new SqlBulkCopy(destination);

            // Execute reader
            SqlDataReader reader = cmditem.ExecuteReader();
            bulkData.DestinationTableName = "tblcategory";
            bulkData.WriteToServer(reader);
            reader.Close();




            SqlDataReader readerbranch = cmdbranch.ExecuteReader();
            bulkData.DestinationTableName = "tblMargin";
            bulkData.WriteToServer(readerbranch);
            readerbranch.Close();

            // Close objects
            bulkData.Close();
            destination.Close();
            source.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }
    }
}
