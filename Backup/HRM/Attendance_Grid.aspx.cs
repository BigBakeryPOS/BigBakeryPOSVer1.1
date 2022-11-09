using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;

namespace HRM
{
    public partial class Attendance_Grid : System.Web.UI.Page
    {
        string getleave = DateTime.Now.ToString("dd-MM-yyyy");
        string dt = DateTime.Now.ToString("dd/MM/yyyy");
        string dda = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        HRMclass objbs = new HRMclass();
        string det = string.Empty;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            string emp_code = Session["empid"].ToString();
            if (Convert.ToInt32(emp_code) == 7)
            {
                DataSet dsLeave = objbs.Get_LeaveStatus_admin(getleave);
                if (dsLeave.Tables[0].Rows.Count > 0)
                {
                    GvLeave.DataSource = dsLeave;
                    GvLeave.DataBind();
                }
                else
                {
                    lblLeave.Visible = true;
                    lblLeave.Text = "No Leave Applied";
                }
            }
            else
            {
                DataSet dsLeave_emp = objbs.Get_LeaveStatus_Emp(emp_code, dt);
                if (dsLeave_emp.Tables[0].Rows.Count > 0)
                {
                    GvLeave.DataSource = dsLeave_emp;
                    GvLeave.DataBind();
                }
                else
                {
                    lblLeave.Visible = true;
                    lblLeave.Text = "No Leave Applied";
                }
            }
            if (Convert.ToInt32(emp_code) == 7)
            {

                ds = objbs.attendence(dda);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridviewhrm.DataSource = ds;
                    gridviewhrm.DataBind();

                    string login = ds.Tables[0].Rows[0]["LogIn_DateTime"].ToString();
                    string logout = ds.Tables[0].Rows[0]["LogOut_DateTime"].ToString();
                }
                else
                {
                    lblinfo1.Visible = true;
                    lblinfo1.Text = "No Records";

                }
            }

            else
            {

                ds = objbs.GetAttendance(dt, emp_code);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridviewhrm.DataSource = ds;
                    gridviewhrm.DataBind();

                    string login = ds.Tables[0].Rows[0]["LogIn_DateTime"].ToString();
                    string logout = ds.Tables[0].Rows[0]["LogOut_DateTime"].ToString();
                }
                else
                {
                    lblinfo1.Visible = true;
                    lblinfo1.Text = "No Records";

                }

            }

            if (Convert.ToInt32(emp_code) == 7)
            {
                DataSet ds1 = objbs.GetLateAttendance(dt);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    gvlogin.DataSource = ds1;
                    gvlogin.DataBind();
                }
                else
                {
                    lblinfo2.Visible = true;
                    lblinfo2.Text = "No Records";

                }
            }

            else
            {

                DataSet ds2 = objbs.latattendance(dt, emp_code);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    gvlogin.DataSource = ds2;
                    gvlogin.DataBind();
                }
                else
                {
                    lblinfo2.Visible = true;
                    lblinfo2.Text = "No Records";

                }

            }
            if (Convert.ToInt32(emp_code) == 7)
            {
                DataSet ds3 = objbs.GetLateAttendance1(dt);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    gvlogout.DataSource = ds3;
                    gvlogout.DataBind();
                }
                else
                {
                    lblinfo3.Visible = true;
                    lblinfo3.Text = "No Records";

                }
            }

            else
            {

                DataSet ds4 = objbs.lattattendance_soon(dt, emp_code);
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    gvlogout.DataSource = ds4;
                    gvlogout.DataBind();
                }
                else
                {
                    lblinfo3.Visible = true;
                    lblinfo3.Text = "No Records";

                }

            }
            string sdate = DateTime.Now.ToString("dd-MM-yyyy");

            DataSet todate1 = objbs.gettodate();
            if (todate1.Tables[0].Rows.Count > 0)
            {
                string todate = todate1.Tables[0].Rows[0]["Todate"].ToString();
            }
            if (sdate != "")
            {
                DataSet ds6 = objbs.getmessage(sdate);
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
                    {
                        txtmsg.Text += ds6.Tables[0].Rows[i]["Message"].ToString() + "*" + Environment.NewLine;
                        txtmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }

            else
            {
                ds = objbs.SelectMaxId();
            }

            string userId = Session["empid"].ToString();
            if (userId == "7")
            {
                txtmsg.Visible = false;
                lblmsg.Visible = false;
            }
            else
            {
                txtmsg.Visible = true;
                lblmsg.Visible = true;
            }
            DataSet dsb = objbs.getbirthday();


            if (dsb.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsb.Tables[0].Rows.Count; i++)
                {
                    string DOB = dsb.Tables[0].Rows[i]["DOB"].ToString();
                    string Name = dsb.Tables[0].Rows[i]["Name"].ToString();



                    if (DOB != "")
                    {
                        DateTime birthday = Convert.ToDateTime(DOB);
                        int years = DateTime.Now.Year - birthday.Year;
                        birthday = birthday.AddYears(years);
                        DateTime check = DateTime.Now.AddDays(3);

                        if ((birthday > DateTime.Now) && (birthday < check))
                        {
                            det = det + DOB + "  " + Name + "  " + years + ',' + Environment.NewLine;

                            lbbirthday.Text = ("This week " + det + " birthday !!!");
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
        }



        protected void gridviewhrm_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string duration = ds.Tables[0].Rows[0]["Time_Duration"].ToString();
            }
        }


        protected void gridviewhrm_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            ds = objbs.attendence(dt);
            gridviewhrm.DataSource = ds;
            gridviewhrm.DataBind();

            ds = objbs.attendence(dt);
            gridviewhrm.PageIndex = e.NewPageIndex;
            gridviewhrm.DataBind();

        }

        protected void gvlogin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ds = objbs.GetLateAttendance(dt);
            gvlogin.DataSource = ds;
            gvlogin.DataBind();


            ds = objbs.GetLateAttendance(dt);
            gvlogin.PageIndex = e.NewPageIndex;
            gvlogin.DataBind();
        }

        protected void GvLeave_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ds = objbs.Get_LeaveStatus_admin(dt);
            GvLeave.DataSource = ds;
            GvLeave.DataBind();


            ds = objbs.Get_LeaveStatus_admin(dt);
            GvLeave.PageIndex = e.NewPageIndex;
            GvLeave.DataBind();

        }

        protected void gvlogout_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ds = objbs.GetLateAttendance1(dt);
            gvlogout.DataSource = ds;
            gvlogout.DataBind();


            ds = objbs.GetLateAttendance1(dt);
            gvlogout.PageIndex = e.NewPageIndex;
            gvlogout.DataBind();
        }

        protected void txtmsg_TextChanged(object sender, EventArgs e)
        {

        }





    }
}