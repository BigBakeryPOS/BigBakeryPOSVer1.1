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
using System.Drawing;
namespace HRM
{
    
    public partial class Attendence : System.Web.UI.Page
    {
       

        private int counter = 60;
        HRMclass objbs = new HRMclass();
        DataSet hrm = new DataSet();
        DataSet ds1 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblempid.Text = Session["empid"].ToString();
            lblempname.Text = Session["UserName"].ToString();
            string location = Session["Location"].ToString();


            string shortDate = DateTime.Now.ToString("dd/MM/yyyy");

            if (!IsPostBack)
            {
                DataSet dgrid = objbs.emp_details(location);

                gvemp.DataSource = dgrid.Tables[0];
                gvemp.DataBind();
                //DataSet dsa = objbs.login1(shortDate, Convert.ToInt32(lblempid.Text));
                //if (dsa.Tables[0].Rows.Count > 0)
                //{
                //    DataSet dsb = objbs.logout1(shortDate, Convert.ToInt32(lblempid.Text));
                //    if (dsb.Tables[0].Rows.Count > 0)
                //    {
                //        Response.Redirect("Attendance_Grid.aspx");
                //    }
                //    else
                //    {
                     
                //        btnCheckin.Text = "CheckOut";
                //    }
                //}

                for (int i = 0; i < gvemp.Rows.Count; i++)
                {
                    int EmpId = Convert.ToInt32(gvemp.Rows[i].Cells[2].Text);
                    Button btn = (Button)gvemp.Rows[i].FindControl("btnlog");
                    Label status = (Label)gvemp.Rows[i].FindControl("lblststus");
                    DataSet dsa = objbs.login1(shortDate, EmpId);
                    if (dsa.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsb = objbs.logout1(shortDate, EmpId);
                        if (dsb.Tables[0].Rows.Count > 0)
                        {
                            Response.Redirect("Attendance_Grid.aspx");
                        }
                        else
                        {
                            DateTime a = Convert.ToDateTime(dsa.Tables[0].Rows[0]["LogIn_DateTime"].ToString());
                            string Da = a.ToString(" HH:mm:ss");
                            string b = DateTime.Now.ToString("hh:mm:ss tt");
                            TimeSpan Time_Duration = Convert.ToDateTime(b) - Convert.ToDateTime(Da);


                              status.Text ="Logged In at "+ Da;
                              btn.Text = "Out" ;
                              btn.BackColor = Color.Green;
                              btn.ForeColor = Color.White;
                        }
                    }
                }

                //shortDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                //dsa = objbs.login1(shortDate, Convert.ToInt32(lblempid.Text));
                //if (dsa.Tables[0].Rows.Count > 0)
                //{
                //    DateTime a = Convert.ToDateTime(dsa.Tables[0].Rows[0]["LogIn_DateTime"].ToString());
                //    string Da = a.ToString(" HH:mm:ss");
                //    string b = DateTime.Now.ToString("hh:mm:ss tt");
                //    TimeSpan Time_Duration = Convert.ToDateTime(b) - Convert.ToDateTime(Da);
                    
                //    lblTime.Text = (Convert.ToString(Time_Duration));

                    


                //}

              
               
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string shortDate = DateTime.Now.ToString("dd/MM/yyyy");
            DataSet dsa = objbs.login1(shortDate, Convert.ToInt32(lblempid.Text));
            if (dsa.Tables[0].Rows.Count > 0)
            {
                DateTime a = Convert.ToDateTime(dsa.Tables[0].Rows[0]["LogIn_DateTime"].ToString());
                string Da = a.ToString(" HH:mm:ss");
                string b = DateTime.Now.ToString("hh:mm:ss tt");
                TimeSpan Time_Duration = Convert.ToDateTime(b) - Convert.ToDateTime(Da);
                //lblTime.Text = DateTime.Now.ToString("hh:mm:ss ");
            }
            
        }
        //protected void btnCheckin_Click(object sender, EventArgs e)
        //{
        //    DataSet df = objbs.getempcode(Convert.ToInt32(lblempid.Text));
        //    string empid = df.Tables[0].Rows[0]["Emp_code"].ToString();
        //    string cdate = DateTime.Now.ToString("dd/MM/yyyy");
           
        //    string logindateinsert = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    string shortDate = DateTime.Now.ToString("dd/MM/yyyy");
        //    ds1 = objbs.login1(cdate, Convert.ToInt32(lblempid.Text));
        //    if (btnCheckin.Text == "CheckIn")
        //    {
        //        if (ds1.Tables[0].Rows.Count > 0)
        //        {
        //            btnCheckin.Text = "CheckOut";
        //        }
        //        else
        //        {
                    
        //            //commented now
        //            //int k = objbs.login_det(Convert.ToInt32(lblempid.Text), lblempname.Text,logindateinsert,empid);



        //            Response.Redirect("Attendance_Grid.aspx");
        //            btnCheckin.Text = "CheckOut";
        //        }
        //    }
        //    else
        //    {
        //        string date = ds1.Tables[0].Rows[0]["LogIn_DateTime"].ToString();
        //        DataSet ds2 = objbs.logout1(shortDate, Convert.ToInt32(lblempid.Text));
        //        string logoutUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        //       //DateTime dt = DateTime.ParseExact(logoutUpdate,"dd/MM/yyyy HH:mm:ss", null);
        //       //DateTime log = Convert.ToDateTime(logoutUpdate);                
        //       //DateTime DT = DateTime.ParseExact(logoutUpdate, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
        //        string logoutget = DateTime.Now.ToString();
        //        string logout = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        //        string login_date = DateTime.Now.ToString("dd/MM/yyyy");
        //        DateTime dd = Convert.ToDateTime(logoutget);
        //        string logoutTime = dd.ToString("hh:mm:ss tt");

        //        //commented now
        //        //int l = objbs.logout_det(Convert.ToInt32(lblempid.Text), logoutUpdate, login_date);

        //        ds2 = objbs.getLoginTime(Convert.ToInt32(lblempid.Text), shortDate, logout);
        //        if (ds2.Tables[0].Rows.Count > 0)
        //        {
        //            TimeSpan overtimehours;
        //            DateTime a = Convert.ToDateTime(ds2.Tables[0].Rows[0]["LogIn_DateTime"].ToString());
        //            string b = a.ToString("HH:mm:ss");
        //            string workinghours= " 08:00:00";
                   
        //            TimeSpan Time_Duration = Convert.ToDateTime(logoutTime) - Convert.ToDateTime(b);
        //            DateTime dt = Convert.ToDateTime(Time_Duration.ToString());
                     

        //            DateTime dt1= Convert.ToDateTime(workinghours.ToString());

        //            if (dt1 < dt)
        //            {
        //                overtimehours = Convert.ToDateTime(dt) - Convert.ToDateTime(workinghours);
        //            }
        //            else
        //            {
        //                TimeSpan span = new TimeSpan(0, 0, 0, 0, 0);

        //                overtimehours = span;
        //            }


        //            //int overtimehours = Convert.ToInt32(Time_Duration) - Convert.ToInt32(workinghours);

        //            //commented now
        //            //int result = objbs.timeDuration(Convert.ToString(Time_Duration),Convert.ToInt32(lblempid.Text), shortDate, Convert.ToString(overtimehours));
        //        }
        //              string worktime=Convert.ToString("07:00:00");
                
             
                 
               
        //        btnCheckin.Text = "CheckIn";
        //        Response.Redirect("Attendance_Grid.aspx");
        //    }
        //}

        protected void btnCheckTime_Click(object sender, EventArgs e)
        {
            
        }

        protected void gvemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
           
            
            


            

          

            {
                string[] sp = new string[2];
                sp = e.CommandArgument.ToString().Split(',');
                string Empcode = sp[2];
                string name = sp[1];
                int EmpID = Convert.ToInt32(sp[2]);
                DataSet df = objbs.getempcode(Convert.ToInt32(EmpID));

                string cdate = DateTime.Now.ToString("dd/MM/yyyy");

                string logindateinsert = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string shortDate = DateTime.Now.ToString("dd/MM/yyyy");

                ds1 = objbs.login1(cdate, Convert.ToInt32(EmpID));
                Button btn = (Button)row.FindControl("btnlog");
                
                if (btn.Text == "In")
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                       
                        btn.Text = "Out";
                        btn.BackColor = Color.Green;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {


                        int k = objbs.login_det(Convert.ToInt32(EmpID), name, logindateinsert, Empcode);



                       
                        btn.Text = "Out";
                        btn.BackColor = Color.Green;
                        btn.ForeColor = Color.White;
                        Page_Load(sender, e);
                    }
                }

                else
                {
                    string date = ds1.Tables[0].Rows[0]["LogIn_DateTime"].ToString();
                    DataSet ds2 = objbs.logout1(shortDate, Convert.ToInt32(lblempid.Text));
                    string logoutUpdate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    //DateTime dt = DateTime.ParseExact(logoutUpdate,"dd/MM/yyyy HH:mm:ss", null);
                    //DateTime log = Convert.ToDateTime(logoutUpdate);                
                    //DateTime DT = DateTime.ParseExact(logoutUpdate, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    string logoutget = DateTime.Now.ToString();
                    string logout = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    string login_date = DateTime.Now.ToString("dd/MM/yyyy");
                    DateTime dd = Convert.ToDateTime(logoutget);
                    string logoutTime = dd.ToString("hh:mm:ss tt");

                    //commented now
                    //int l = objbs.logout_det(Convert.ToInt32(lblempid.Text), logoutUpdate, login_date);

                    ds2 = objbs.getLoginTime(Convert.ToInt32(EmpID), shortDate, logout);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        TimeSpan overtimehours;
                        DateTime a = Convert.ToDateTime(ds2.Tables[0].Rows[0]["LogIn_DateTime"].ToString());
                        string b = a.ToString("HH:mm:ss");
                        string workinghours = " 08:00:00";

                        TimeSpan Time_Duration = Convert.ToDateTime(logoutTime) - Convert.ToDateTime(b);
                        DateTime dt = Convert.ToDateTime(Time_Duration.ToString());


                        DateTime dt1 = Convert.ToDateTime(workinghours.ToString());

                        if (dt1 < dt)
                        {
                            overtimehours = Convert.ToDateTime(dt) - Convert.ToDateTime(workinghours);
                        }
                        else
                        {
                            TimeSpan span = new TimeSpan(0, 0, 0, 0, 0);

                            overtimehours = span;
                        }


                        //int overtimehours = Convert.ToInt32(Time_Duration) - Convert.ToInt32(workinghours);

                        
                        int result = objbs.timeDuration(Convert.ToString(Time_Duration),Convert.ToInt32(EmpID), shortDate, Convert.ToString(overtimehours));
                    }
                    string worktime = Convert.ToString("07:00:00");




                    btn.Text = "In";
                    Response.Redirect("Attendance_Grid.aspx");
                }

            }

        }
    }
}