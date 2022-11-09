using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Text;
using System.Data;


namespace HRM
{
    public partial class Admin_dashboard : System.Web.UI.Page
    {


        HRMclass objbs = new HRMclass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            string sdate = DateTime.Now.ToString("dd-MM-yyyy");
            
            //DataSet dstask = objbs.TaskPending();

            //lblTask.Text =dstask.Tables[0].Rows[0]["count"].ToString();

            //DataSet dstaskcomp = objbs.TaskPendingcomp();
            //ibltaskcomp.Text = dstaskcomp.Tables[0].Rows[0]["count"].ToString();

            DataSet todate1 = objbs.getleaveall();
            if (todate1.Tables[0].Rows.Count > 0)
            {
                string todate = todate1.Tables[0].Rows[0]["Todate"].ToString();
            }
            if (sdate != "")
            {
                string status = "Request";
                DataSet ds6 = objbs.getLeaves(status);
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                    {
                        string dtDate = ds6.Tables[0].Rows[i]["Date"].ToString();
                        lblleave.Text += ds6.Tables[0].Rows[i]["Emp_Name"].ToString() + "  is applied leave on " + dtDate + "  For " + ds6.Tables[0].Rows[i]["Leave_Reason"].ToString() + "." + "<br/>";
                        //txtmsg.Text += ds6.Tables[0].Rows[i]["Emp_Name"].ToString() + "  is applied leave on" + ds6.Tables[0].Rows[i]["Date"].ToString() + "  For" + ds6.Tables[0].Rows[i]["Leave_Reason"].ToString() + "*"+Environment.NewLine;

                    }





                }
                else
                {
                    lblleave.Text += "No Pending Leave Request!!";
                }
            }

            else
            {

                ds = objbs.SelectMaxId();
            }
            #region
            //if (sdate != "")
            //{
            //    DataSet dstask1 = objbs.gettaskststsus();

            //    if (dstask1.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dstask1.Tables[0].Rows.Count; i++)
            //        {

            //            lbltaskstatus.Text += dstask1.Tables[0].Rows[i]["Name"].ToString() + " - Task Details:  " + dstask1.Tables[0].Rows[i]["Task"].ToString() + "  - Priority: " + dstask1.Tables[0].Rows[i]["status"].ToString() + "." + "<br/>";
            //        }
            //    }
            //}


            if (sdate != "")
            {

                DataSet ds6 = objbs.getlogintime();
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                    {

                        lbllogin.Text += ds6.Tables[0].Rows[i]["Employee_Name"].ToString() + "  is Logged in on" + ds6.Tables[0].Rows[i]["LogIn_DateTime"].ToString() + " and logged out on" + ds6.Tables[0].Rows[i]["LogOut_DateTime"].ToString() + "." + "<br/>";
                        //txtmsg.Text += ds6.Tables[0].Rows[i]["Emp_Name"].ToString() + "  is applied leave on" + ds6.Tables[0].Rows[i]["Date"].ToString() + "  For" + ds6.Tables[0].Rows[i]["Leave_Reason"].ToString() + "*"+Environment.NewLine;

                    }



                }
                else
                {
                }

            #endregion
                DataSet leave = objbs.lvapptoday(sdate);
                if (leave.Tables[0].Rows.Count > 0)
                {

                    lvtoday.Text = leave.Tables[0].Rows[0]["total"].ToString();
                }
                else
                {
                    lvtoday.Text = "NO Leave applied today";
                }

            }
              #region
            if (sdate != "")
            {
                //DataSet dstask1 = objbs.gettaskststsus();

                //if (dstask1.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < dstask1.Tables[0].Rows.Count; i++)
                //    {

                //        lbltaskstatus.Text += dstask1.Tables[0].Rows[i]["Name"].ToString() + " - Task Details:  " + dstask1.Tables[0].Rows[i]["Task"].ToString() + "  - Priority: " + dstask1.Tables[0].Rows[i]["status"].ToString() + "." + "<br/>";
                //    }
                //}
            }


            if (sdate != "")
            {

                DataSet ds6 = objbs.getlogintime();
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                    {

                        lbllogin.Text += ds6.Tables[0].Rows[i]["Employee_Name"].ToString() + "  is Logged in on " + ds6.Tables[0].Rows[i]["LogIn_DateTime"].ToString() + " and logged out on " + ds6.Tables[0].Rows[i]["LogOut_DateTime"].ToString() + "." + "<br/>";
                        //txtmsg.Text += ds6.Tables[0].Rows[i]["Emp_Name"].ToString() + "  is applied leave on" + ds6.Tables[0].Rows[i]["Date"].ToString() + "  For" + ds6.Tables[0].Rows[i]["Leave_Reason"].ToString() + "*"+Environment.NewLine;

                    }



                }
                else
                {
                    lbllogin.Text += "No One Has Logined Yet!!";
                }

            #endregion
                DataSet leave = objbs.lvapptoday(sdate);
                if (leave.Tables[0].Rows.Count > 0)
                {

                    lvtoday.Text = leave.Tables[0].Rows[0]["total"].ToString(); 
                }
                else
                {
                    lvtoday.Text = "No Leave Applied Today";
                }

            }
            string today1 = DateTime.Now.ToString("dd/MM/yyyy");
            //DataSet dsissue = objbs.getissue();

            //Label8.Text = dsissue.Tables[0].Rows[0]["issue"].ToString();
            //DataSet issue = objbs.todaygetissue(today1);
            //Label12.Text = issue.Tables[0].Rows[0]["issue"].ToString();
          

        }
           // chart_bind();

        }
        //private void chart_bind()
        //{
        //    #region
        //    //string dta = DateTime.Today.ToString("yyyy");
        //    //Chart1.Series["Series1"].ChartType = SeriesChartType.Bar;
        //    ////Chart1.Series["Series1"]["DrawingStyle"] = "Emboss";
        //    ////Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        //    //Chart1.Series["Series1"].IsValueShownAsLabel = true;

        //    //DataSet lvall = objbs.Leaveform();



        //    //DataTable dt = new DataTable();
        //    //DataColumn dc;
        //    //int count = lvall.Tables[0].Rows.Count;


        //    //dc = new DataColumn();
        //    //dc.ColumnName = "LeaveTaken";
        //    //dt.Columns.Add(dc);
        //    //dc = new DataColumn();
        //    //dc.ColumnName = "Employees";
        //    //dt.Columns.Add(dc);
        //    //for (int i = 0; i < count; i++)
        //    //{
        //    //    string empcode = lvall.Tables[0].Rows[i]["Emp_code"].ToString();
        //    //    DataSet chart = objbs.Chart_Leaves(empcode, Convert.ToInt32(dta));


        //    //    DataRow dr;
        //    //    dr = dt.NewRow();
        //    //    dr["LeaveTaken"] = chart.Tables[0].Rows[0]["datediff"];
        //    //    dr["Employees"] = chart.Tables[0].Rows[0]["Emp_Name"];

        //    //    dt.Rows.Add(dr);


        //    //}

        //    //Chart1.DataSource = dt;
        //    //Chart1.Series["Series1"].XValueMember = "Employees";
        //    //Chart1.Series["Series1"].YValueMembers = "LeaveTaken";
        //    //Chart1.DataBind();
        //    #endregion
        //    string dta1 = DateTime.Today.ToString("MM");
        ////    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
        //    //Chart1.Series["Series1"]["DrawingStyle"] = "Emboss";
        //    //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        //   // Chart1.Series["Series1"].IsValueShownAsLabel = true;

        //    DataSet lvall = objbs.attall();



        //    DataTable dt = new DataTable();
        //    DataColumn dc;
        //    int count1 = lvall.Tables[0].Rows.Count;


        //    dc = new DataColumn();
        //    dc.ColumnName = "LeaveTaken";
        //    dt.Columns.Add(dc);
        //    dc = new DataColumn();
        //    dc.ColumnName = "Employees";
        //    dt.Columns.Add(dc);
        //    for (int i = 0; i < count1; i++)
        //    {
        //        string date = DateTime.Now.ToString("yyyy-MM-dd");
        //        string[] arrDate = date.Split('-');

        //        int day = Convert.ToInt32(date.Split('-')[2]);
        //        int month = Convert.ToInt32(date.Split('-')[1]);
        //        int year = Convert.ToInt32(date.Split('-')[0]);

        //        int day1 = 01;
        //        int month1 = 01;


        //        string fromdate = Convert.ToDateTime(year + "-" + +month1 + "-" + +day1).ToString("yyyy-MM-dd");

        //        string todate = DateTime.Now.ToString("yyyy-MM-dd");
        //        string empcode = lvall.Tables[0].Rows[i]["Emp_code"].ToString();
        //        ds = objbs.totalleavedaysdash(fromdate, todate, empcode);
        //        int count2 = ds.Tables[0].Rows.Count;

        //        int total = objbs.getsearchcountdash1(fromdate, todate, empcode);

        //        int days = (total + 1) - count2;
        //        string leavestaken = "No.Of.Leavedays:" + Convert.ToString(days);
        //        //string empcode1 = lvall.Tables[0].Rows[i]["Emp_code"].ToString();
        //        //DataSet chart1 = objbs.Chart_employees(empcode);


        //        DataRow dr;
        //        dr = dt.NewRow();
        //        dr["LeaveTaken"] = Convert.ToString(days);
        //        dr["Employees"] = lvall.Tables[0].Rows[i]["Employee_Name"].ToString();

        //        dt.Rows.Add(dr);


        //    }

        //    ViewState["dt"] = dt;
        //    DataTable dtable1 = (DataTable)ViewState["dt"];
        //    dtable1 = dt.DefaultView.ToTable(true, "Employees", "LeaveTaken");
        //  //  Chart1.DataSource = dtable1;
        //   // Chart1.Series["Series1"].XValueMember = "Employees";
        //   // Chart1.Series["Series1"].YValueMembers = "LeaveTaken";
        // //   Chart1.DataBind();



        //    //---------------for Month--------------
        //    //string dta1 = DateTime.Today.ToString("MM");
        // //   Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
        //    //Chart1.Series["Series1"]["DrawingStyle"] = "Emboss";
        //    //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        // //   Chart2.Series["Series1"].IsValueShownAsLabel = true;

        //    DataSet lvall1 = objbs.attall();



        //    DataTable dt1 = new DataTable();
        //    DataColumn dc1;
        //    int count4 = lvall1.Tables[0].Rows.Count;


        //    dc1 = new DataColumn();
        //    dc1.ColumnName = "LeaveTaken";
        //    dt1.Columns.Add(dc1);
        //    dc1 = new DataColumn();
        //    dc1.ColumnName = "Employees";
        //    dt1.Columns.Add(dc1);
        //    for (int i = 0; i < count4; i++)
        //    {
        //        string date = DateTime.Now.ToString("yyyy-MM-dd");
        //        string[] arrDate = date.Split('-');

        //        int day = Convert.ToInt32(date.Split('-')[2]);
        //        int month = Convert.ToInt32(date.Split('-')[1]);
        //        int year = Convert.ToInt32(date.Split('-')[0]);

        //        int day1 = 01;


        //        string fromdate = Convert.ToDateTime(year + "-" + +month + "-" + +day1).ToString("yyyy-MM-dd");

        //        string todate = DateTime.Now.ToString("yyyy-MM-dd");
        //        string empcode = lvall1.Tables[0].Rows[i]["Emp_code"].ToString();
        //        ds = objbs.totalleavedaysdash(fromdate, todate, empcode);
        //        int count2 = ds.Tables[0].Rows.Count;

        //        int total = objbs.getsearchcountdash1(fromdate, todate, empcode);

        //        int days = (total + 1) - count2;
        //        string leavestaken = "No.Of.Leavedays:" + Convert.ToString(days);
        //        //string empcode1 = lvall.Tables[0].Rows[i]["Emp_code"].ToString();
        //        //DataSet chart1 = objbs.Chart_employees(empcode);


        //        DataRow dr1;
        //        dr1 = dt1.NewRow();
        //        dr1["LeaveTaken"] = Convert.ToString(days);
        //        dr1["Employees"] = lvall1.Tables[0].Rows[i]["Employee_Name"].ToString();

        //        dt1.Rows.Add(dr1);


        //    }

        //    ViewState["dt"] = dt1;
        //    DataTable dtable = (DataTable)ViewState["dt"];
        //    dtable = dt1.DefaultView.ToTable(true, "Employees", "LeaveTaken");
        //   // Chart2.DataSource = dtable;
        //  //  Chart2.Series["Series1"].XValueMember = "Employees";
        //  //  Chart2.Series["Series1"].YValueMembers = "LeaveTaken";
        //   // Chart2.DataBind();



        //}

    }


