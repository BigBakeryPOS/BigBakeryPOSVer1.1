using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BusinessLayer;
using CommonLayer;
using DataLayer;
using System.Windows.Forms;
namespace HRM
{
    public partial class Monthwise_Leave : System.Web.UI.Page
    {

        HRMclass objbs = new HRMclass();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("MyTable");
        int iTotalDays = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void btngo_Click(object sender, EventArgs e)
        {
            string emp_code = Session["empid"].ToString();
            if (emp_code == "7")
            {
                int sunday = CountSundays(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
                DataSet ds1 = objbs.emp_name();
                int count = ds1.Tables[0].Rows.Count;
                int[] sAttendence = new int[count];
                int[] iAbsent = new int[count];
                dt.Columns.Add("Employee Name");
                dt.Columns.Add("Total Days");
                dt.Columns.Add("No.of Days Attended");
                dt.Columns.Add("Absent Days");
                dt.Columns.Add("Leave Days");
                dt.Columns.Add("Holidays");
                //ds1 = objbs.DaysinMonth();
                if (ddlMonth.SelectedValue == "1" || ddlMonth.SelectedValue == "3" || ddlMonth.SelectedValue == "5" || ddlMonth.SelectedValue == "7" || ddlMonth.SelectedValue == "8" ||ddlMonth.SelectedValue=="10" || ddlMonth.SelectedValue == "11")
                {

                    iTotalDays = 31;
                }
                else if(ddlMonth.SelectedValue=="2")
                {
                    iTotalDays = 29;
                }
                else if(ddlMonth.SelectedValue=="4"||ddlMonth.SelectedValue=="6"||ddlMonth.SelectedValue == "9" ||ddlMonth.SelectedValue=="12")
                {
                    iTotalDays = 30;
                }

                // Convert.ToInt32(ds1.Tables[0].Rows.ToString());
                for (int i = 1; i < count; i++)
                {
                    string name = (ds1.Tables[0].Rows[i]["Name"].ToString());
                    ds = objbs.Leave_details(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));
                    //casual leave
                    DataSet ds2 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 1);
                    int casual = Convert.ToInt32(ds2.Tables[0].Rows[0]["leave"].ToString());
                    //sick leave
                    DataSet ds3 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 2);
                    int sick = Convert.ToInt32(ds3.Tables[0].Rows[0]["leave"].ToString());
                    //Maternity leave
                    DataSet ds4 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 3);
                    int maternity = Convert.ToInt32(ds4.Tables[0].Rows[0]["leave"].ToString());
                    //Short leave
                    DataSet ds5 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 4);
                    int short_leave = Convert.ToInt32(ds5.Tables[0].Rows[0]["leave"].ToString());
                    int iTotalLeave = casual + sick + maternity + short_leave;
                    sAttendence[i] = Convert.ToInt32(ds.Tables[0].Rows[0]["Att_Days"].ToString());
                    iAbsent[i] = ((iTotalDays - sAttendence[i]) - sunday) - iTotalLeave;
                    dt.Rows.Add(name, iTotalDays, sAttendence[i], iAbsent[i], iTotalLeave, sunday);

                }
                gv_leave.DataSource = dt;
                gv_leave.DataBind();
            }
            else
            {
                int sunday = CountSundays(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
                DataSet ds1 = objbs.getindividualpay(Convert.ToInt32(emp_code));
                int count = ds1.Tables[0].Rows.Count;
                int[] sAttendence = new int[count];
                int[] iAbsent = new int[count];
                dt.Columns.Add("Employee Name");
                dt.Columns.Add("Total Days");
                dt.Columns.Add("No.of Days Attended");
                dt.Columns.Add("Absent Days");
                dt.Columns.Add("Leave Days");
                dt.Columns.Add("Holidays");
                //ds1 = objbs.DaysinMonth();
               // Convert.ToInt32(ds1.Tables[0].Rows.ToString());
                if (ddlMonth.SelectedValue == "1" || ddlMonth.SelectedValue == "3" || ddlMonth.SelectedValue == "5" || ddlMonth.SelectedValue == "7" || ddlMonth.SelectedValue == "8" || ddlMonth.SelectedValue == "10" || ddlMonth.SelectedValue == "11")
                {

                    iTotalDays = 31;
                }
                else if (ddlMonth.SelectedValue == "2")
                {
                    iTotalDays = 29;
                }
                else if (ddlMonth.SelectedValue == "4" || ddlMonth.SelectedValue == "6" || ddlMonth.SelectedValue == "9" || ddlMonth.SelectedValue == "12")
                {
                    iTotalDays = 30;
                }

                string name = (ds1.Tables[0].Rows[0]["Name"].ToString());
                ds = objbs.Leave_details(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));
                //casual leave
                DataSet ds2 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 1);
                int casual = Convert.ToInt32(ds2.Tables[0].Rows[0]["leave"].ToString());
                //sick leave
                DataSet ds3 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 2);
                int sick = Convert.ToInt32(ds3.Tables[0].Rows[0]["leave"].ToString());
                //Maternity leave
                DataSet ds4 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 3);
                int maternity = Convert.ToInt32(ds4.Tables[0].Rows[0]["leave"].ToString());
                //Short leave
                DataSet ds5 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 4);
                int short_leave = Convert.ToInt32(ds5.Tables[0].Rows[0]["leave"].ToString());
                int iTotalLeave = casual + sick + maternity + short_leave;
                sAttendence[0] = Convert.ToInt32(ds.Tables[0].Rows[0]["Att_Days"].ToString());
                iAbsent[0] = ((iTotalDays - sAttendence[0]) - sunday) - iTotalLeave;
                dt.Rows.Add(name, iTotalDays, sAttendence[0], iAbsent[0], iTotalLeave, sunday);

            }
            gv_leave.DataSource = dt;
            gv_leave.DataBind();

        }





        protected void gv_leave_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            int sunday = CountSundays(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
            DataSet ds1 = objbs.emp_name();
            int count = ds1.Tables[0].Rows.Count;
            int[] sAttendence = new int[count];
            int[] iAbsent = new int[count];
            dt.Columns.Add("Employee Name");
            dt.Columns.Add("Total Days");
            dt.Columns.Add("No.of Days Attended");
            dt.Columns.Add("Absent Days");
            dt.Columns.Add("Leave Days");
            dt.Columns.Add("Holidays");
            //ds1 = objbs.DaysinMonth();
            int iTotalDays = 31;// Convert.ToInt32(ds1.Tables[0].Rows.ToString());
            for (int i = 1; i < count; i++)
            {
                string name = (ds1.Tables[0].Rows[i]["Name"].ToString());
                ds = objbs.Leave_details(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue));
                //casual leave
                DataSet ds2 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 1);
                int casual = Convert.ToInt32(ds2.Tables[0].Rows[0]["leave"].ToString());
                //sick leave
                DataSet ds3 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 2);
                int sick = Convert.ToInt32(ds3.Tables[0].Rows[0]["leave"].ToString());
                //Maternity leave
                DataSet ds4 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 3);
                int maternity = Convert.ToInt32(ds4.Tables[0].Rows[0]["leave"].ToString());
                //Short leave
                DataSet ds5 = objbs.Leave_Applied(name, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), 4);
                int short_leave = Convert.ToInt32(ds5.Tables[0].Rows[0]["leave"].ToString());
                int iTotalLeave = casual + sick + maternity + short_leave;
                sAttendence[i] = Convert.ToInt32(ds.Tables[0].Rows[0]["Att_Days"].ToString());
                iAbsent[i] = ((iTotalDays - sAttendence[i]) - sunday) - iTotalLeave;
                dt.Rows.Add(name, iTotalDays, sAttendence[i], iAbsent[i], iTotalLeave, sunday);


            }
            gv_leave.PageIndex = e.NewPageIndex;
            gv_leave.DataSource = dt;
            gv_leave.DataBind();

        }


        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
