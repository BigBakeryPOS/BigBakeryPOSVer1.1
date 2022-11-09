using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using CommonLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace HRM
{
    public partial class Dashboard : System.Web.UI.Page
    {

        HRMclass objbs = new HRMclass();
        DataTable dt = new DataTable("MyTable");
       
        protected void Page_Load(object sender, EventArgs e)
        {


            int month = 0;
            string emp_code = Session["empid"].ToString();
            #region message from admin
            string sdate = DateTime.Now.ToString("dd-MM-yyyy");

            DataSet todate1 = objbs.gettodate();
            if (todate1.Tables[0].Rows.Count > 0)
            {
                //string todate = todate1.Tables[0].Rows[0]["Todate"].ToString();
            }
            if (sdate != "")
            {
                DataSet ds6 = objbs.getmessage(sdate);
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                    {
                        Label6.Text += ds6.Tables[0].Rows[i]["Message"].ToString() + "." + "<br/>";
                        Label6.ForeColor = System.Drawing.Color.White;
                    }
                }
            }

            else
            {
              
            }
           
            #endregion

            #region birthday notification
            DataSet dsb = objbs.getbirthday();

            string det1 = string.Empty;
            if (dsb.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsb.Tables[0].Rows.Count; i++)
                {
                    string DOB = dsb.Tables[0].Rows[i]["DOB"].ToString();
                    string Name = dsb.Tables[0].Rows[i]["Name"].ToString();

                    if (DOB != "")
                    {
                        DateTime birthday = Convert.ToDateTime(DOB);
                        string birthdAY1 = birthday.ToString("dd/MM");
                        string today0 = DateTime.Now.ToString("dd/MM");

                        int years = DateTime.Now.Year - birthday.Year;
                        birthday = birthday.AddYears(years);
                        DateTime check = DateTime.Now.AddDays(3);

                        if ((birthdAY1 == today0))
                        {
                            det1 = det1 + DOB + "  " + Name + "  " + years + ',' + Environment.NewLine;

                            lbbirthday.Text = ("This week " + det1 + " birthday !!!");
                            Label2.Visible = false;
                            lbbirthday.ForeColor = System.Drawing.Color.DeepPink;
                        }
                        else
                        {
                            //Label2.Text = ("This week no birthday");

                        }
                    }
                }
            }
            #endregion

            #region declaration
            string emp_code1 = Session["empid"].ToString();
            DateTime dt1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            int sunday = CountSundays(Convert.ToInt32(dt1.Year), Convert.ToInt32(dt1.Month));
            #endregion
            #region Checkin/out
            lblempid.Text = Session["empid"].ToString();
            lblempname.Text = Session["UserName"].ToString();
            string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            DataSet ds = objbs.dashboard(Convert.ToInt32(lblempid.Text), today);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = ds.Tables[0].Rows[0]["time"].ToString();
                string Da = Label1.Text;
                string b = DateTime.Now.ToString("hh:mm:ss tt");
                TimeSpan Time_Duration = Convert.ToDateTime(b) - Convert.ToDateTime(Da);
                Label2.Text = (Convert.ToString(Time_Duration));
            }
            else
            {
                Label1.Text = "Not Logged In";
            }


            #endregion
        

            string today1 = DateTime.Now.ToString("dd-MM-yyyy");
            DataSet dsissue = objbs.Get_Issuefromclient_opened(lblempname.Text);
            int count1 = Convert.ToInt32(dsissue.Tables[0].Rows.Count);
            Label17.Text = Convert.ToString(count1);//dsissue.Tables[0].Rows[0]["issue"].ToString();
            DataSet issue =objbs.todaygetissue(today1);
            Label18.Text = issue.Tables[0].Rows[0]["issue"].ToString();
          

           

            string today2 = DateTime.Now.ToString("dd/MM/yyyy");
            DataSet dsm = objbs.getempmsg(today2);
            if (dsm.Tables[0].Rows.Count > 0)
            {

                Labelmsg.Text = dsm.Tables[0].Rows[0]["total"].ToString() + "-New Messages";
            }
            else
            {
                Labelmsg.Text = "NO MESSAGES";
            }
      

            DataSet hol = objbs.get_holiday(today2);
            Label3.Text = hol.Tables[0].Rows[0]["Total"].ToString() + "-Holidays upcoming";


            #region emp_details
            DataSet ds1 = objbs.dash_empdetails(Convert.ToInt32(lblempid.Text));
            Email_ID.Text = ds1.Tables[0].Rows[0]["Email_Id"].ToString();
            Contact_No.Text = ds1.Tables[0].Rows[0]["Phno_No"].ToString();
            #endregion
            #region Payslip
            DataSet dsa = objbs.gridviewhrm_emp(Convert.ToInt32(emp_code));
            int count = dsa.Tables[0].Rows.Count;
            int[] sAttendence = new int[count];
            int[] iAbsent = new int[count];
            dt.Columns.Add("Employee Code");
            dt.Columns.Add("Employee Name");
            dt.Columns.Add("Salary");
            //dt.Columns.Add("Woring Days");
            //dt.Columns.Add("Absent Days");
            //dt.Columns.Add("Salary per Day");
            //dt.Columns.Add("Leave Taken");
            dt.Columns.Add("Salary Payable");
            dt.Columns.Add("salarydays");
            dt.Columns.Add("Overtimehours");
            dt.Columns.Add("overtimesalary");
            //dt.Columns.Add("Month");

            //dt.Columns.Add("Holidays");
            //ds1 = objbs.DaysinMonth();
            int iTotalDays = 31;// Convert.ToInt32(ds1.Tables[0].Rows.ToString());
            int iWorkingDays = iTotalDays - sunday;
            int iOverTime = 0;
            string e_code = ds1.Tables[0].Rows[0]["Emp_code"].ToString();
            string name = ds1.Tables[0].Rows[0]["Name"].ToString();
            // double salary = Convert.ToDouble(ds1.Tables[0].Rows[i]["Salary"].ToString());
            double salary = Convert.ToDouble(ds1.Tables[0].Rows[0]["Salary"].ToString());
            double dSalaryperDay = salary / iTotalDays;

            //DataSet dss = objbs.getovertime();
            ds = objbs.Leave_details(name, Convert.ToInt32(dt1.Month), Convert.ToInt32(dt1.Year));
            //casual leave
            DataSet ds2 = objbs.Leave_Applied(name, Convert.ToInt32(dt1.Month), Convert.ToInt32(dt1.Year), 1);
            int casual = Convert.ToInt32(ds2.Tables[0].Rows[0]["leave"].ToString());
            //sick leave
            DataSet ds3 = objbs.Leave_Applied(name, Convert.ToInt32(dt1.Month), Convert.ToInt32(dt1.Year), 2);
            int sick = Convert.ToInt32(ds3.Tables[0].Rows[0]["leave"].ToString());
            //Maternity leave
            DataSet ds4 = objbs.Leave_Applied(name, Convert.ToInt32(dt1.Month), Convert.ToInt32(dt1.Year), 3);
            int maternity = Convert.ToInt32(ds4.Tables[0].Rows[0]["leave"].ToString());
            //Short leave
            DataSet ds5 = objbs.Leave_Applied(name, Convert.ToInt32(dt1.Month), Convert.ToInt32(dt1.Year), 4);
            int short_leave = Convert.ToInt32(ds5.Tables[0].Rows[0]["leave"].ToString());
            int iTotalLeave = casual + sick + maternity + short_leave;
            sAttendence[0] = Convert.ToInt32(ds.Tables[0].Rows[0]["Att_Days"].ToString());
            DataSet ds61 = objbs.GetOverTeime(name, Convert.ToInt32(dt1.Month));
            if (ds61.Tables[0].Rows.Count > 0)
            {
                string sCheck = ds61.Tables[0].Rows[0]["Total"].ToString();

                if (sCheck == null || sCheck == "")
                {
                    iOverTime = 0;
                }
                else
                {
                    iOverTime = Convert.ToInt32(ds61.Tables[0].Rows[0]["total"].ToString());
                }

            }
            // string sOveriytime = iOverTime.ToString();


            if (iTotalLeave <= 2)
            {
                iAbsent[0] = ((iTotalDays - sAttendence[0]) - sunday) - iTotalLeave;
            }
            else
            {
                iAbsent[0] = ((iTotalDays - sAttendence[0]) - sunday) - 2;
            }
            int iNonSalaryDays = iAbsent[0];
            int salarydays = (iTotalDays - iNonSalaryDays);
            double dSalary_NonPayable = iNonSalaryDays * dSalaryperDay;
            double dSalary_Payable = salary - dSalary_NonPayable;
            double salaryperhour = dSalaryperDay / 8;
            double overtimeAmount = iOverTime * salaryperhour;

            dt.Rows.Add(e_code, name, salary, dSalary_Payable, salarydays, iOverTime, overtimeAmount);
            lblsalary.Text = Convert.ToString(dSalary_Payable);
            #endregion
            #region Task
            DataSet task = objbs.TaskPending_emp(lblempid.Text);
            lblTask.Text =  task.Tables[0].Rows[0]["count"].ToString();
            #endregion

            DataSet dsleave = objbs.getEmpLeaveid(emp_code);
            string leaveid = dsleave.Tables[0].Rows[0]["Leave_Id"].ToString();

            DataSet empleave = objbs.getEmpLeave(emp_code, leaveid);
            if (empleave.Tables[0].Rows.Count > 0)
            {
                Label10.Text = "Applied Date:" + empleave.Tables[0].Rows[0]["Date"].ToString();
                lbllvappdate.Text ="Leave Applied Date:" + empleave.Tables[0].Rows[0]["Fromdate"].ToString();
                lbllvstatus.Text ="Leave Status:" + empleave.Tables[0].Rows[0]["Leave_Status"].ToString();
            }


        }
        static int CountSundays(int year, int month)
        {
            var firstDay = new DateTime(year, month, 1);

            var day29 = firstDay.AddDays(28);
            var day30 = firstDay.AddDays(29);
            var day31 = firstDay.AddDays(30);

            if ((day29.Month == month && day29.DayOfWeek == DayOfWeek.Sunday)
            || (day30.Month == month && day30.DayOfWeek == DayOfWeek.Sunday)
            || (day31.Month == month && day31.DayOfWeek == DayOfWeek.Sunday))
            {
                return 5;
            }
            else
            {
                return 4;
            }

           

        }
         
    
    }
}