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

namespace HRM
{
    public partial class Login : System.Web.UI.Page
    {

        DataSet dsLogin = new DataSet();
        HRMclass objbs = new HRMclass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Employee_Name"] != null && Request.Cookies["Password"] != null)
            {
                if (!IsPostBack)
                {
                    txtusername.Text = Request.Cookies["Employee_Name"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
           
                dsLogin = objbs.empLogin(txtusername.Text, txtpassword.Text);
                if (dsLogin.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Login Failed, Please try Again!');", true);

                }
                else
                {
                    Session["empid"] = dsLogin.Tables[0].Rows[0]["empid"].ToString();
                    lblempid.Text = Session["empid"].ToString();

                    int session_client = 0;
                    Session["Client_Id"]=Convert.ToString(session_client);
                 

                    Session["serviceID"] = dsLogin.Tables[0].Rows[0]["ServiceId"].ToString();
                    lblserviceid.Text = Session["serviceID"].ToString();

                    Session["UserName"] = dsLogin.Tables[0].Rows[0]["UserName"].ToString();
                    lblempname.Text = Session["UserName"].ToString();
                    if (Convert.ToInt32(lblempid.Text) == 7)
                    {
                        Response.Redirect("Emp_gird.aspx");
                    }
                    Response.Redirect("Attendence.aspx");

                }
            }

     



        }
    }
