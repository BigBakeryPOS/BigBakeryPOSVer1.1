using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class saleshourreport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string AllBranchAccess = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);
            txtfromdate.Enabled = true;
            txttodate.Enabled = true;
            if (!IsPostBack)
            {
                BindTime();
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString();
                txtfromdate.Text = DateTime.Today.ToShortDateString();

                //DataSet dsbranch = objbs.selectbranchmaster();
                //if (dsbranch.Tables[0].Rows.Count > 0)
                //{
                //    ddlBranch.DataSource = dsbranch.Tables[0];
                //    ddlBranch.DataTextField = "BranchCode";
                //    ddlBranch.DataValueField = "UserID";
                //    ddlBranch.DataBind();
                //   // ddlBranch.Items.Insert(0, "Select Branch");
                //    //ddlcategory.Items.Insert(0, "Select Category");

                //}
                //if (sadmin == "1")
                //{
                //    ddlBranch.Enabled = true;
                //    DataSet dsbranchto = objbs.Branchto();
                //    ddlBranch.DataSource = dsbranchto.Tables[0];
                //    ddlBranch.DataTextField = "branchcode";
                //    ddlBranch.DataValueField = "Userid";
                //    ddlBranch.DataBind();
                //    //  ddlBranch.Items.Insert(0, "All");
                //}
                //else
                //{
                //    DataSet dsbranch = new DataSet();
                //    string stable = "tblSales_" + sTableName + "";
                //    dsbranch = objbs.Branchfrom(lblUserID.Text);
                //    ddlBranch.DataSource = dsbranch.Tables[0];
                //    ddlBranch.DataTextField = "branchcode";
                //    ddlBranch.DataValueField = "Userid";
                //    ddlBranch.DataBind();
                //    ddlBranch.Enabled = false;
                //}

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objbs.GetBranch_New("All");
                else
                    dsbranch = objbs.GetBranch_New(sTableName);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "Select Branch");
                else
                    ddlBranch.Enabled = false;

               
                 //   int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                  //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    //if (dsbranch1.Tables[0].Rows.Count > 0)
                //    {
                //     //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //     //   string[] wordArray = sales.Split('_');

                //      //  brach = wordArray[1];
                //        if (brach == "CO1")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }
                //        else if (brach == "CO2")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }
                //        else if (brach == "CO3")
                //        {
                //            Label123.Text = "Shiva Delights";
                //        }
                //        else if (brach == "CO4")
                //        {
                //            Label123.Text = "Fig and honey";
                //        }
                //        else if (brach == "CO5")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }
                //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                //        #region comment code
                //        //    DateTime sTo = Convert.ToDateTime(txttodate.Text);


                //        //if (dcustbranch.Tables[0].Rows.Count > 0)
                //        //{
                //        //    gvCustsales.DataSource = dcustbranch.Tables[0];
                //        //    gvCustsales.DataBind();
                //        //}

                //        //  DataSet dcustbranch = objbs.CustomerSalesBranch(sTableName, txtfromdate.Text, txttodate.Text);
                //        //      DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //        //     DateTime sTo = Convert.ToDateTime(txttodate.Text);

                //        //     DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                //        //if (dcustbranch.Tables[0].Rows.Count > 0)
                //        //{
                //        //    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                //        //}

                //        //  gvCustsales.DataSource = dcustbranch.Tables[0];

                //        //  gvCustsales.DataBind();
                //        #endregion

                //        ///////////////////////Done All Chnages in one grid/////////////////////////

                //        #region
                //        DataTable dttt;
                //        DataRow drNew;
                //        DataColumn dct;
                //        DataSet dstd = new DataSet();
                //        dttt = new DataTable();

                //        dct = new DataColumn("Time");
                //        dttt.Columns.Add(dct);

                //        dct = new DataColumn("Sales-Total");
                //        dttt.Columns.Add(dct);

                //        dct = new DataColumn("Order-Total");
                //        dttt.Columns.Add(dct);
                //        dstd.Tables.Add(dttt);

                //        dct = new DataColumn("Total-Amount");
                //        dttt.Columns.Add(dct);
                //        string stime = string.Empty;
                //        string etime = string.Empty;

                //        // string sqryy = "select * from tbltimespan ";
                //        DataSet dtime = objbs.gettimespan();

                //        if (dtime.Tables[0].Rows.Count > 0)
                //        {
                //            for (int i = 0; i < dtime.Tables[0].Rows.Count; i++)
                //            {
                //                string stime1 = dtime.Tables[0].Rows[i]["starttime"].ToString();
                //                string etime1 = dtime.Tables[0].Rows[i]["endtime"].ToString();

                //                if (stime1 == "8.00 AM")
                //                {
                //                    stime = "08:00:00";
                //                }
                //                else if (stime1 == "9.00 AM")
                //                {
                //                    stime = "09:00:00";
                //                }
                //                else if (stime1 == "10.00 AM")
                //                {
                //                    stime = "10:00:00";
                //                }
                //                else if (stime1 == "11.00 AM")
                //                {
                //                    stime = "11:00:00";
                //                }
                //                else if (stime1 == "12.00 PM")
                //                {
                //                    stime = "12:00:00";
                //                }
                //                //else if (stime1 == "12.00 AM")
                //                //{
                //                //    stime = "12:00:00";
                //                //}
                //                else if (stime1 == "1.00 PM")
                //                {
                //                    stime = "13:00:00";
                //                }
                //                else if (stime1 == "2.00 PM")
                //                {
                //                    stime = "14:00:00";
                //                }
                //                else if (stime1 == "3.00 PM")
                //                {
                //                    stime = "15:00:00";
                //                }
                //                else if (stime1 == "4.00 PM")
                //                {
                //                    stime = "16:00:00";
                //                }
                //                else if (stime1 == "5.00 PM")
                //                {
                //                    stime = "17:00:00";
                //                }
                //                else if (stime1 == "6.00 PM")
                //                {
                //                    stime = "18:00:00";
                //                }
                //                else if (stime1 == "7.00 PM")
                //                {
                //                    stime = "19:00:00";
                //                }
                //                else if (stime1 == "8.00 PM")
                //                {
                //                    stime = "20:00:00";
                //                }
                //                else if (stime1 == "9.00 PM")
                //                {
                //                    stime = "21:00:00";
                //                }
                //                else if (stime1 == "10.00 PM")
                //                {
                //                    stime = "22:00:00";
                //                }



                //                //For end time
                //                if (etime1 == "9.00 AM")
                //                {
                //                    etime = "09:00:00";
                //                }

                //                else if (etime1 == "10.00 AM")
                //                {
                //                    etime = "10:00:00";
                //                }
                //                else if (etime1 == "11.00 AM")
                //                {
                //                    etime = "11:00:00";
                //                }
                //                else if (etime1 == "12.00 PM")
                //                {
                //                    etime = "12:00:00";
                //                }
                //                //else if (etime1 == "12.00 AM")
                //                //{
                //                //    etime = "12:00:00";
                //                //}
                //                else if (etime1 == "1.00 PM")
                //                {
                //                    etime = "13:00:00";
                //                }
                //                else if (etime1 == "2.00 PM")
                //                {
                //                    etime = "14:00:00";
                //                }
                //                else if (etime1 == "3.00 PM")
                //                {
                //                    etime = "15:00:00";
                //                }
                //                else if (etime1 == "4.00 PM")
                //                {
                //                    etime = "16:00:00";
                //                }
                //                else if (etime1 == "5.00 PM")
                //                {
                //                    etime = "17:00:00";
                //                }
                //                else if (etime1 == "6.00 PM")
                //                {
                //                    etime = "18:00:00";
                //                }
                //                else if (etime1 == "7.00 PM")
                //                {
                //                    etime = "19:00:00";
                //                }
                //                else if (etime1 == "8.00 PM")
                //                {
                //                    etime = "20:00:00";
                //                }
                //                else if (etime1 == "9.00 PM")
                //                {
                //                    etime = "21:00:00";
                //                }
                //                else if (etime1 == "10.00 PM")
                //                {
                //                    etime = "22:00:00";
                //                }
                //                else if (etime1 == "11.00 PM")
                //                {
                //                    etime = "23:00:00";
                //                }

                //                string dst = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                //                string[] myStrings = new string[] { dst, stime };
                //                String sfrmdatetime = String.Join(" ", myStrings);

                //                string dst1 = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                //                string[] myStrings1 = new string[] { dst1, etime };
                //                String senddatetime = String.Join(" ", myStrings1);

                                    
                //                   DataSet dcustbranch = objbs.CustomerSaleshourreportnew(ddlBranch.SelectedValue, sfrmdatetime,senddatetime);
                //                    drNew = dttt.NewRow();
                //                    drNew["Time"] =stime1 +"-"+ etime1;
                //                    drNew["Sales-Total"] = Convert.ToInt32(dcustbranch.Tables[0].Rows[0]["Amount"]);

                //                    DataSet dcustbranch1234 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                //                    drNew["Order-Total"] = Convert.ToDouble(dcustbranch1234.Tables[0].Rows[0]["amount"]);
                //                    DataSet dcustbranch123 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                //                    drNew["Total-Amount"] = Convert.ToDouble(dcustbranch123.Tables[0].Rows[0]["Totalamount"]);
                //                    dstd.Tables[0].Rows.Add(drNew);
                                
                //                gvCustsales.DataSource = dstd.Tables[0];
                //                gvCustsales.DataBind();
                            
                //}
                //        }
                //        #endregion

                      
                //        decimal dtotal = 0;
                //        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //        {
                //            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[3].Text);
                //        }
                //        decimal Total = dtotal;
                //        lblTotal.InnerText = Total.ToString();


                //        DataSet dcustbranch1 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sFrom);
                //        if (dcustbranch1.Tables[0].Rows.Count > 0)
                //        {
                //            grdorder.DataSource = dcustbranch1.Tables[0];
                //            grdorder.DataBind();
                //        }
                //        decimal dtotal1 = 0;
                //        for (int i = 0; i < grdorder.Rows.Count; i++)
                //        {
                //            dtotal1 += Convert.ToDecimal(grdorder.Rows[i].Cells[1].Text);
                //        }
                //        decimal Total1 = dtotal1;
                //        Label2.InnerText = Total1.ToString();
                //        //  btnall_Click( sender, Even e)CustomerSaleshourreportnewtotal

                //        DataSet dcustbranch12 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sFrom);
                //        if (dcustbranch12.Tables[0].Rows.Count > 0)
                //        {
                //            grdtotal.DataSource = dcustbranch12.Tables[0];
                //            grdtotal.DataBind();
                //        }
                //        decimal dtotal12 = 0;
                //        for (int i = 0; i < grdtotal.Rows.Count; i++)
                //        {
                //            dtotal12 += Convert.ToDecimal(grdtotal.Rows[i].Cells[1].Text);
                //        }
                //        decimal Total12 = dtotal12;
                //        Label5.InnerText = Total12.ToString();
                //    }



                }
            }
        

        private void BindTime()
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
            //Set 5 minutes interval
          //  TimeSpan Interval = new TimeSpan(0, 5, 0);
            //To set 1 hour interval
            TimeSpan Interval = new TimeSpan(1, 0, 0);           
            ddlTimeFrom.Items.Clear();
            ddlTimeTo.Items.Clear();
            while (StartTime <= EndTime)
            {
                ddlTimeFrom.Items.Add(StartTime.ToShortTimeString());
                ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }
            ddlTimeFrom.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlTimeTo.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void ddltime_selected(object sender, EventArgs e)
        {
            if (ddlTimeFrom.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Start Time.');", true);
                return;
            }
            DateTime StartTime = Convert.ToDateTime(ddlTimeFrom.SelectedItem.Text);
            TimeSpan Interval = new TimeSpan(1, 0, 0);
            StartTime = StartTime.Add(Interval);
            ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
            //ddlTimeTo.SelectedIndex = Convert.ToInt32(StartTime);
            ddlTimeTo.SelectedItem.Text = Convert.ToString(StartTime.ToString("hh:mm tt"));
           // ddlTimeTo.Items.FindByValue(StartTime).Attributes.Add;
          // ddlTimeTo.SelectedItem.Selected.ToString() = StartTime.ToString());
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
        //    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);


            if (ddlTimeFrom.SelectedItem.Text == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Start Time.');", true);
                return;
            }

            DateTime dtt = Convert.ToDateTime(ddlTimeFrom.SelectedItem.Text);
            DateTime dtt1 = Convert.ToDateTime(ddlTimeTo.SelectedItem.Text);


            string dstime = dtt.ToString("HH:mm:ss");

            string detime = dtt1.ToString("HH:mm:ss");
            //if (txtfromdate.Text > txttodate.Text)
            //{

            //}

         //   if (dsbranch1.Tables[0].Rows.Count > 0)
            {
           //     string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

             //   brach = wordArray[1];
                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text = ddlBranch.SelectedItem.Text + " Sales Hourly Report on " + txtfromdate.Text;

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //DataSet dcustbranch = objbs.CustomerSaleshourreportnew(brach, sFrom);
                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{
                //    gvCustsales.DataSource = dcustbranch.Tables[0];
                //    gvCustsales.DataBind();
                //}
                #region
                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
                DataSet dstd = new DataSet();
                dttt = new DataTable();

                dct = new DataColumn("Time");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Sales-Total");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Order-Total");
                dttt.Columns.Add(dct);
                dstd.Tables.Add(dttt);

                dct = new DataColumn("Total-Amount");
                dttt.Columns.Add(dct);
                string stime = string.Empty;
                string etime = string.Empty;

                // string sqryy = "select * from tbltimespan ";
                DataSet dtime = objbs.gettimespan();

                if (dtime.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtime.Tables[0].Rows.Count; i++)
                    {
                        string stime1 = dtime.Tables[0].Rows[i]["starttime"].ToString();
                        string etime1 = dtime.Tables[0].Rows[i]["endtime"].ToString();

                        if (stime1 == "8.00 AM")
                        {
                            stime = "08:00:00";
                        }
                        else if (stime1 == "9.00 AM")
                        {
                            stime = "09:00:00";
                        }
                        else if (stime1 == "10.00 AM")
                        {
                            stime = "10:00:00";
                        }
                        else if (stime1 == "11.00 AM")
                        {
                            stime = "11:00:00";
                        }
                        else if (stime1 == "12.00 PM")
                        {
                            stime = "12:00:00";
                        }
                        //else if (stime1 == "12.00 AM")
                        //{
                        //    stime = "12:00:00";
                        //}
                        else if (stime1 == "1.00 PM")
                        {
                            stime = "13:00:00";
                        }
                        else if (stime1 == "2.00 PM")
                        {
                            stime = "14:00:00";
                        }
                        else if (stime1 == "3.00 PM")
                        {
                            stime = "15:00:00";
                        }
                        else if (stime1 == "4.00 PM")
                        {
                            stime = "16:00:00";
                        }
                        else if (stime1 == "5.00 PM")
                        {
                            stime = "17:00:00";
                        }
                        else if (stime1 == "6.00 PM")
                        {
                            stime = "18:00:00";
                        }
                        else if (stime1 == "7.00 PM")
                        {
                            stime = "19:00:00";
                        }
                        else if (stime1 == "8.00 PM")
                        {
                            stime = "20:00:00";
                        }
                        else if (stime1 == "9.00 PM")
                        {
                            stime = "21:00:00";
                        }
                        else if (stime1 == "10.00 PM")
                        {
                            stime = "22:00:00";
                        }



                        //For end time
                        if (etime1 == "9.00 AM")
                        {
                            etime = "09:00:00";
                        }

                        else if (etime1 == "10.00 AM")
                        {
                            etime = "10:00:00";
                        }
                        else if (etime1 == "11.00 AM")
                        {
                            etime = "11:00:00";
                        }
                        else if (etime1 == "12.00 PM")
                        {
                            etime = "12:00:00";
                        }
                        //else if (etime1 == "12.00 AM")
                        //{
                        //    etime = "12:00:00";
                        //}
                        else if (etime1 == "1.00 PM")
                        {
                            etime = "13:00:00";
                        }
                        else if (etime1 == "2.00 PM")
                        {
                            etime = "14:00:00";
                        }
                        else if (etime1 == "3.00 PM")
                        {
                            etime = "15:00:00";
                        }
                        else if (etime1 == "4.00 PM")
                        {
                            etime = "16:00:00";
                        }
                        else if (etime1 == "5.00 PM")
                        {
                            etime = "17:00:00";
                        }
                        else if (etime1 == "6.00 PM")
                        {
                            etime = "18:00:00";
                        }
                        else if (etime1 == "7.00 PM")
                        {
                            etime = "19:00:00";
                        }
                        else if (etime1 == "8.00 PM")
                        {
                            etime = "20:00:00";
                        }
                        else if (etime1 == "9.00 PM")
                        {
                            etime = "21:00:00";
                        }
                        else if (etime1 == "10.00 PM")
                        {
                            etime = "22:00:00";
                        }
                        else if (etime1 == "11.00 PM")
                        {
                            etime = "23:00:00";
                        }

                        string dst = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                        string[] myStrings = new string[] { dst, stime };
                        String sfrmdatetime = String.Join(" ", myStrings);

                        string dst1 = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                        string[] myStrings1 = new string[] { dst1, etime };
                        String senddatetime = String.Join(" ", myStrings1);


                        DataSet dcustbranch = objbs.CustomerSaleshourreportnew(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew = dttt.NewRow();
                        drNew["Time"] = stime1 + "-" + etime1;
                        drNew["Sales-Total"] = Convert.ToInt32(dcustbranch.Tables[0].Rows[0]["Amount"]);

                        DataSet dcustbranch1234 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew["Order-Total"] = Convert.ToDouble(dcustbranch1234.Tables[0].Rows[0]["amount"]);
                        DataSet dcustbranch123 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew["Total-Amount"] = Convert.ToDouble(dcustbranch123.Tables[0].Rows[0]["Totalamount"]);
                        dstd.Tables[0].Rows.Add(drNew);

                        gvCustsales.DataSource = dstd.Tables[0];
                        gvCustsales.DataBind();

                    }
                }
                #endregion

                DataSet dcustbranch1 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sFrom);
                if (dcustbranch1.Tables[0].Rows.Count > 0)
                {
                    grdorder.DataSource = dcustbranch1.Tables[0];
                    grdorder.DataBind();
                }

                DataSet dcustbranch12 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sFrom);
                if (dcustbranch12.Tables[0].Rows.Count > 0)
                {
                    grdtotal.DataSource = dcustbranch12.Tables[0];
                    grdtotal.DataBind();
                }
                //decimal dtotal12 = 0;
                //for (int i = 0; i < grdtotal.Rows.Count; i++)
                //{
                //    dtotal12 += Convert.ToDecimal(grdtotal.Rows[i].Cells[1].Text);
                //}
                //decimal Total12 = dtotal12;
                //Label5.InnerText = Total12.ToString();
               
                // tot = Convert.ToDouble(Total);
            }
            //decimal dtotal = 0;
            //for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //{
            //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
            //}
            //decimal Total = dtotal;
            //lblTotal.InnerText = Total.ToString();
            //tot = Convert.ToDouble(Total);

            //DataSet dcustbranch = objbs.CustomerSalesBranch(ddlBranch.SelectedValue);
            //gvCustsales.DataSource = dcustbranch.Tables[0];
            //gvCustsales.DataBind();
        }

       

        protected void btnall_Click(object sender, EventArgs e)
        {
           // int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
          //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //if (ddlTimeFrom.SelectedItem.Text == "--Select--")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Start Time.');", true);
            //    return;
            //}

            //DateTime dtt = Convert.ToDateTime(ddlTimeFrom.SelectedItem.Text);
            //DateTime dtt1 = Convert.ToDateTime(ddlTimeTo.SelectedItem.Text);


            //string dstime = dtt.ToString("HH:mm:ss");

            //string detime = dtt1.ToString("HH:mm:ss");

           

          //  if (dsbranch1.Tables[0].Rows.Count > 0)
            {
             //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
             //   string[] wordArray = sales.Split('_');

             //   brach = wordArray[1];
            //    string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text = ddlBranch.SelectedItem.Text + " Sales Hourly Report on " + txtfromdate.Text;
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                //DataSet dcustbranch = objbs.CustomerSaleshourreportnew(brach, sFrom);
                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{
                //    gvCustsales.DataSource = dcustbranch.Tables[0];
                //    gvCustsales.DataBind();
                //}
                #region
                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
                DataSet dstd = new DataSet();
                dttt = new DataTable();

                dct = new DataColumn("Time");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Sales-Total");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Order-Total");
                dttt.Columns.Add(dct);
                dstd.Tables.Add(dttt);

                dct = new DataColumn("Total-Amount");
                dttt.Columns.Add(dct);
                string stime = string.Empty;
                string etime = string.Empty;

                // string sqryy = "select * from tbltimespan ";
                DataSet dtime = objbs.gettimespan();

                if (dtime.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtime.Tables[0].Rows.Count; i++)
                    {
                        string stime1 = dtime.Tables[0].Rows[i]["starttime"].ToString();
                        string etime1 = dtime.Tables[0].Rows[i]["endtime"].ToString();

                        if (stime1 == "8.00 AM")
                        {
                            stime = "08:00:00";
                        }
                        else if (stime1 == "9.00 AM")
                        {
                            stime = "09:00:00";
                        }
                        else if (stime1 == "10.00 AM")
                        {
                            stime = "10:00:00";
                        }
                        else if (stime1 == "11.00 AM")
                        {
                            stime = "11:00:00";
                        }
                        else if (stime1 == "12.00 PM")
                        {
                            stime = "12:00:00";
                        }
                        //else if (stime1 == "12.00 AM")
                        //{
                        //    stime = "12:00:00";
                        //}
                        else if (stime1 == "1.00 PM")
                        {
                            stime = "13:00:00";
                        }
                        else if (stime1 == "2.00 PM")
                        {
                            stime = "14:00:00";
                        }
                        else if (stime1 == "3.00 PM")
                        {
                            stime = "15:00:00";
                        }
                        else if (stime1 == "4.00 PM")
                        {
                            stime = "16:00:00";
                        }
                        else if (stime1 == "5.00 PM")
                        {
                            stime = "17:00:00";
                        }
                        else if (stime1 == "6.00 PM")
                        {
                            stime = "18:00:00";
                        }
                        else if (stime1 == "7.00 PM")
                        {
                            stime = "19:00:00";
                        }
                        else if (stime1 == "8.00 PM")
                        {
                            stime = "20:00:00";
                        }
                        else if (stime1 == "9.00 PM")
                        {
                            stime = "21:00:00";
                        }
                        else if (stime1 == "10.00 PM")
                        {
                            stime = "22:00:00";
                        }



                        //For end time
                        if (etime1 == "9.00 AM")
                        {
                            etime = "09:00:00";
                        }

                        else if (etime1 == "10.00 AM")
                        {
                            etime = "10:00:00";
                        }
                        else if (etime1 == "11.00 AM")
                        {
                            etime = "11:00:00";
                        }
                        else if (etime1 == "12.00 PM")
                        {
                            etime = "12:00:00";
                        }
                        //else if (etime1 == "12.00 AM")
                        //{
                        //    etime = "12:00:00";
                        //}
                        else if (etime1 == "1.00 PM")
                        {
                            etime = "13:00:00";
                        }
                        else if (etime1 == "2.00 PM")
                        {
                            etime = "14:00:00";
                        }
                        else if (etime1 == "3.00 PM")
                        {
                            etime = "15:00:00";
                        }
                        else if (etime1 == "4.00 PM")
                        {
                            etime = "16:00:00";
                        }
                        else if (etime1 == "5.00 PM")
                        {
                            etime = "17:00:00";
                        }
                        else if (etime1 == "6.00 PM")
                        {
                            etime = "18:00:00";
                        }
                        else if (etime1 == "7.00 PM")
                        {
                            etime = "19:00:00";
                        }
                        else if (etime1 == "8.00 PM")
                        {
                            etime = "20:00:00";
                        }
                        else if (etime1 == "9.00 PM")
                        {
                            etime = "21:00:00";
                        }
                        else if (etime1 == "10.00 PM")
                        {
                            etime = "22:00:00";
                        }
                        else if (etime1 == "11.00 PM")
                        {
                            etime = "23:00:00";
                        }

                        string dst = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                        string[] myStrings = new string[] { dst, stime };
                        String sfrmdatetime = String.Join(" ", myStrings);

                        string dst1 = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                        string[] myStrings1 = new string[] { dst1, etime };
                        String senddatetime = String.Join(" ", myStrings1);


                        DataSet dcustbranch = objbs.CustomerSaleshourreportnew(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew = dttt.NewRow();
                        drNew["Time"] = stime1 + "-" + etime1;
                        drNew["Sales-Total"] = Convert.ToInt32(dcustbranch.Tables[0].Rows[0]["Amount"]);

                        DataSet dcustbranch1234 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew["Order-Total"] = Convert.ToDouble(dcustbranch1234.Tables[0].Rows[0]["amount"]);
                        DataSet dcustbranch123 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew["Total-Amount"] = Convert.ToDouble(dcustbranch123.Tables[0].Rows[0]["Totalamount"]);
                        dstd.Tables[0].Rows.Add(drNew);

                        gvCustsales.DataSource = dstd.Tables[0];
                        gvCustsales.DataBind();

                    }
                }
                #endregion



                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[3].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                //tot = Convert.ToDouble(Total);
                DataSet dcustbranch1 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sFrom);
                if (dcustbranch1.Tables[0].Rows.Count > 0)
                {
                    grdorder.DataSource = dcustbranch1.Tables[0];
                    grdorder.DataBind();
                }
                decimal dtotal1 = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal1 += Convert.ToDecimal(grdorder.Rows[i].Cells[1].Text);
                }
                decimal Total1 = dtotal1;
                Label2.InnerText = Total1.ToString();

                DataSet dcustbranch12 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sFrom);
                if (dcustbranch12.Tables[0].Rows.Count > 0)
                {
                    grdtotal.DataSource = dcustbranch12.Tables[0];
                    grdtotal.DataBind();
                }
                decimal dtotal12 = 0;
                for (int i = 0; i < grdtotal.Rows.Count; i++)
                {
                    dtotal12 += Convert.ToDecimal(grdtotal.Rows[i].Cells[1].Text);
                }

                decimal Total12 = dtotal12;
                Label5.InnerText = Total12.ToString();


            }
        }


        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            DataSet dCustReport = objbs.CustomerSalesAdmin();
            gvCustsales.DataSource = dCustReport.Tables[0];
            gvCustsales.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
         //   int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
         //   DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //if (ddlTimeFrom.SelectedItem.Text == "--Select--")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Start Time.');", true);
            //    return;
            //}

            //DateTime dtt = Convert.ToDateTime(ddlTimeFrom.SelectedItem.Text);
            //DateTime dtt1 = Convert.ToDateTime(ddlTimeTo.SelectedItem.Text);


            //string dstime = dtt.ToString("HH:mm:ss");

            //string detime = dtt1.ToString("HH:mm:ss");



          //  if (dsbranch1.Tables[0].Rows.Count > 0)
            {
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

              //  brach = wordArray[1];
              //  string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text=ddlBranch.SelectedItem.Text + " Sales Hourly Report on " + txtfromdate.Text ;
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                //DataSet dcustbranch = objbs.CustomerSaleshourreportnew(brach, sFrom);
                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{
                //    gvCustsales.DataSource = dcustbranch.Tables[0];
                //    gvCustsales.DataBind();
                //}
                #region
                DataTable dttt;
                DataRow drNew;
                DataColumn dct;
                DataSet dstd = new DataSet();
                dttt = new DataTable();

                dct = new DataColumn("Time");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Sales-Total");
                dttt.Columns.Add(dct);

                dct = new DataColumn("Order-Total");
                dttt.Columns.Add(dct);
                dstd.Tables.Add(dttt);

                dct = new DataColumn("Total-Amount");
                dttt.Columns.Add(dct);
                string stime = string.Empty;
                string etime = string.Empty;

                // string sqryy = "select * from tbltimespan ";
                DataSet dtime = objbs.gettimespan();

                if (dtime.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtime.Tables[0].Rows.Count; i++)
                    {
                        string stime1 = dtime.Tables[0].Rows[i]["starttime"].ToString();
                        string etime1 = dtime.Tables[0].Rows[i]["endtime"].ToString();

                        if (stime1 == "8.00 AM")
                        {
                            stime = "08:00:00";
                        }
                        else if (stime1 == "9.00 AM")
                        {
                            stime = "09:00:00";
                        }
                        else if (stime1 == "10.00 AM")
                        {
                            stime = "10:00:00";
                        }
                        else if (stime1 == "11.00 AM")
                        {
                            stime = "11:00:00";
                        }
                        else if (stime1 == "12.00 PM")
                        {
                            stime = "12:00:00";
                        }
                        //else if (stime1 == "12.00 AM")
                        //{
                        //    stime = "12:00:00";
                        //}
                        else if (stime1 == "1.00 PM")
                        {
                            stime = "13:00:00";
                        }
                        else if (stime1 == "2.00 PM")
                        {
                            stime = "14:00:00";
                        }
                        else if (stime1 == "3.00 PM")
                        {
                            stime = "15:00:00";
                        }
                        else if (stime1 == "4.00 PM")
                        {
                            stime = "16:00:00";
                        }
                        else if (stime1 == "5.00 PM")
                        {
                            stime = "17:00:00";
                        }
                        else if (stime1 == "6.00 PM")
                        {
                            stime = "18:00:00";
                        }
                        else if (stime1 == "7.00 PM")
                        {
                            stime = "19:00:00";
                        }
                        else if (stime1 == "8.00 PM")
                        {
                            stime = "20:00:00";
                        }
                        else if (stime1 == "9.00 PM")
                        {
                            stime = "21:00:00";
                        }
                        else if (stime1 == "10.00 PM")
                        {
                            stime = "22:00:00";
                        }



                        //For end time
                        if (etime1 == "9.00 AM")
                        {
                            etime = "09:00:00";
                        }

                        else if (etime1 == "10.00 AM")
                        {
                            etime = "10:00:00";
                        }
                        else if (etime1 == "11.00 AM")
                        {
                            etime = "11:00:00";
                        }
                        else if (etime1 == "12.00 PM")
                        {
                            etime = "12:00:00";
                        }
                        //else if (etime1 == "12.00 AM")
                        //{
                        //    etime = "12:00:00";
                        //}
                        else if (etime1 == "1.00 PM")
                        {
                            etime = "13:00:00";
                        }
                        else if (etime1 == "2.00 PM")
                        {
                            etime = "14:00:00";
                        }
                        else if (etime1 == "3.00 PM")
                        {
                            etime = "15:00:00";
                        }
                        else if (etime1 == "4.00 PM")
                        {
                            etime = "16:00:00";
                        }
                        else if (etime1 == "5.00 PM")
                        {
                            etime = "17:00:00";
                        }
                        else if (etime1 == "6.00 PM")
                        {
                            etime = "18:00:00";
                        }
                        else if (etime1 == "7.00 PM")
                        {
                            etime = "19:00:00";
                        }
                        else if (etime1 == "8.00 PM")
                        {
                            etime = "20:00:00";
                        }
                        else if (etime1 == "9.00 PM")
                        {
                            etime = "21:00:00";
                        }
                        else if (etime1 == "10.00 PM")
                        {
                            etime = "22:00:00";
                        }
                        else if (etime1 == "11.00 PM")
                        {
                            etime = "23:00:00";
                        }

                        string dst = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                        string[] myStrings = new string[] { dst, stime };
                        String sfrmdatetime = String.Join(" ", myStrings);

                        string dst1 = Convert.ToDateTime(txtfromdate.Text).ToString("yyyy-MM-dd");
                        string[] myStrings1 = new string[] { dst1, etime };
                        String senddatetime = String.Join(" ", myStrings1);


                        DataSet dcustbranch = objbs.CustomerSaleshourreportnew(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew = dttt.NewRow();
                        drNew["Time"] = stime1 + "-" + etime1;
                        drNew["Sales-Total"] = Convert.ToInt32(dcustbranch.Tables[0].Rows[0]["Amount"]);

                        DataSet dcustbranch1234 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew["Order-Total"] = Convert.ToDouble(dcustbranch1234.Tables[0].Rows[0]["amount"]);
                        DataSet dcustbranch123 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sfrmdatetime, senddatetime);
                        drNew["Total-Amount"] = Convert.ToDouble(dcustbranch123.Tables[0].Rows[0]["Totalamount"]);
                        dstd.Tables[0].Rows.Add(drNew);

                        gvCustsales.DataSource = dstd.Tables[0];
                        gvCustsales.DataBind();

                    }
                }
                #endregion



                decimal dtotal = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[3].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                //tot = Convert.ToDouble(Total);
                DataSet dcustbranch1 = objbs.CustomerSaleshourreportneworderform(ddlBranch.SelectedValue, sFrom);
                if (dcustbranch1.Tables[0].Rows.Count > 0)
                {
                    grdorder.DataSource = dcustbranch1.Tables[0];
                    grdorder.DataBind();
                }
                decimal dtotal1 = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal1 += Convert.ToDecimal(grdorder.Rows[i].Cells[1].Text);
                }
                decimal Total1 = dtotal1;
                Label2.InnerText = Total1.ToString();

                DataSet dcustbranch12 = objbs.CustomerSaleshourreportnewtotal(ddlBranch.SelectedValue, sFrom);
                if (dcustbranch12.Tables[0].Rows.Count > 0)
                {
                    grdtotal.DataSource = dcustbranch12.Tables[0];
                    grdtotal.DataBind();
                }
                decimal dtotal12 = 0;
                for (int i = 0; i < grdtotal.Rows.Count; i++)
                {
                    dtotal12 += Convert.ToDecimal(grdtotal.Rows[i].Cells[1].Text);
                }
                decimal Total12 = dtotal12;
                Label5.InnerText = Total12.ToString();



                //DataSet dt = new DataSet();
                //GridView gridview = new GridView();
                //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
                //string name = string.Empty;



                //if (dsbranch1.Tables[0].Rows.Count > 0)
                //{
                //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //    string[] wordArray = sales.Split('_');

                //    brach = wordArray[1];


                //    if (brach == "CO1")
                //    {
                //        Label123.Text = "KKNagar";
                //        name = "KKNAGAR";

                //    }
                //    else if (brach == "CO2")
                //    {
                //        Label123.Text = "BYEPASS";
                //        name = "BYEPASS";
                //    }
                //    else if (brach == "CO3")
                //    {
                //        Label123.Text = "BBKULAM";
                //        name = "BBKULAM";
                //    }
                //    else if (brach == "CO4")
                //    {
                //        Label123.Text = "NARANAYAPURAM";
                //        name = "NARANAYAPURAM";
                //    }
                //}
                //if (sTableName == "admin")
                //{
                //    gridview.DataSource = objbs.CustomerSalesAdmin1();
                //    gridview.DataBind();
                //}

                //else
                //{
                //    dt = objbs.CustomerSalesBranchreport(sTableName, txtfromdate.Text, txttodate.Text, name);
                //    gridview.DataSource = objbs.CustomerSalesBranchreport(sTableName, txtfromdate.Text, txttodate.Text, name);
                //    gridview.DataBind();
                //}
                ////Response.ClearContent();
                ////Response.AddHeader("content-disposition",
                ////    "attachment;filename=CustomerSalesReport.xls");
                ////Response.ContentType = "applicatio/excel";
                ////StringWriter sw = new StringWriter(); ;
                ////HtmlTextWriter htm = new HtmlTextWriter(sw);
                ////gridview.AllowPaging = false;
                ////gridview.RenderControl(htm);
                ////Response.Write(sw.ToString());
                ////Response.End();
                ////gridview.AllowPaging = true;
                //string filename = "salesreport.xls";
                //System.IO.StringWriter tw = new System.IO.StringWriter();
                //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                //DataGrid dgGrid = new DataGrid();
                //dgGrid.DataSource = dt;
                //dgGrid.DataBind();
                //dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                //dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                //dgGrid.HeaderStyle.Font.Bold = true;
                ////Get the HTML for the control.
                //dgGrid.RenderControl(hw);
                ////Write the HTML back to the browser.
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                //this.EnableViewState = false;
                //Response.Write(tw.ToString());
                //Response.End();

                string filename = "Hour'ly Sales Report.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dstd.Tables[0];
                    ;
                dgGrid.DataBind();
                dgGrid.Caption = Label123.Text;
                dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                dgGrid.HeaderStyle.Font.Bold = true;
                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();

            }
        }

        protected void gvcust_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            //if (SortOrder[0] == e.SortExpression)
            //{
            //    if (SortOrder[1] == "ASC")
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            //    }
            //    else
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //    }
            //}
            //else
            //{
            //    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //}
            //DataSet ds = objBs.CustomerReport(Convert.ToInt32(1));
            //DataView dvEmp = ds.Tables[0].DefaultView;
            //dvEmp.Sort = ViewState["SortExpr"].ToString();
            //gvcust.DataSource = dvEmp;
            //gvcust.DataBind();
        }

        protected void grdorder_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            //if (SortOrder[0] == e.SortExpression)
            //{
            //    if (SortOrder[1] == "ASC")
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            //    }
            //    else
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //    }
            //}
            //else
            //{
            //    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //}
            //DataSet ds = objBs.CustomerReport(Convert.ToInt32(1));
            //DataView dvEmp = ds.Tables[0].DefaultView;
            //dvEmp.Sort = ViewState["SortExpr"].ToString();
            //gvcust.DataSource = dvEmp;
            //gvcust.DataBind();
        }

        protected void grdtotal_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            //if (SortOrder[0] == e.SortExpression)
            //{
            //    if (SortOrder[1] == "ASC")
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
            //    }
            //    else
            //    {
            //        ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //    }
            //}
            //else
            //{
            //    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            //}
            //DataSet ds = objBs.CustomerReport(Convert.ToInt32(1));
            //DataView dvEmp = ds.Tables[0].DefaultView;
            //dvEmp.Sort = ViewState["SortExpr"].ToString();
            //gvcust.DataSource = dvEmp;
            //gvcust.DataBind();
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
        }

        protected void Page1_Change(object sender, GridViewPageEventArgs e)
        {
        }
        protected void Page12_Change(object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvcust_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("customerupdate.aspx?iCusID=" + e.CommandArgument.ToString());

            //    }
            //}
        }
        protected void grdorder_RowCommand (object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("customerupdate.aspx?iCusID=" + e.CommandArgument.ToString());

            //    }
            //}
        }

        protected void grdtotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "edit")
            //{
            //    if (e.CommandArgument.ToString() != "")
            //    {
            //        Response.Redirect("customerupdate.aspx?iCusID=" + e.CommandArgument.ToString());

            //    }
            //}
        }


        //public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        //{


        //    //if (e.Row.RowType == DataControlRowType.DataRow)
        //    //{

        //    //}
        //    if (sadmin == "1")
        //    {

        //    }
        //    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
        //    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
        //    string name = string.Empty;



        //    if (dsbranch1.Tables[0].Rows.Count > 0)
        //    {
        //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
        //        string[] wordArray = sales.Split('_');

        //        brach = wordArray[1];


        //        if (brach == "CO1")
        //        {
        //            Label123.Text = "KKNagar";
        //            name = "KKNAGAR";

        //        }
        //        else if (brach == "CO2")
        //        {
        //            Label123.Text = "BYEPASS";
        //            name = "BYEPASS";
        //        }
        //        else if (brach == "CO3")
        //        {
        //            Label123.Text = "BBKULAM";
        //            name = "BBKULAM";
        //        }
        //        else if (brach == "CO4")
        //        {
        //            Label123.Text = "NARANAYAPURAM";
        //            name = "NARANAYAPURAM";
        //        }
        //    }


        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
        //        GridView gvGroup = (GridView)sender;
        //        if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
        //        {
        //            int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
        //            DataSet ds = objbs.CustomerSalesdetailedreport(groupID, brach);
        //            //if (ds.Tables[0].Rows.Count > 0)
        //            //{
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                gv.DataSource = ds;
        //                double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
        //                amount1 = amount1 + amount;
        //                gv.DataBind();
        //            }
        //            //}
        //        }

        //    }

        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
        //        e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //        e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

        //        //e.Row.Cells[0].Text = "Total";
        //        //e.Row.Cells[1].Text = HorizontalAlign.Right;
        //        // e.Row.Cells[7].Text = tot.ToString("N2");
        //        //  e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

        //    }

        //}
    }
}