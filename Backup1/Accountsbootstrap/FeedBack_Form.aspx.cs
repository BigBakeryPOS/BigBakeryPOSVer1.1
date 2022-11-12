using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Windows;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
using System.Globalization;
namespace Billing.Accountsbootstrap
{
    public partial class FeedBack_Form : System.Web.UI.Page
    {
        string store, lobbies, FB, Amb, Service, Exp;
            int DDlbranch;
        string sTableName = "";
        BSClass objbs = new BSClass();
        string branchcode = string.Empty;
        string dt = DateTime.Today.ToString("yyyy-MM-dd");      
        protected void Page_Load(object sender, EventArgs e)
        {
            branchcode = Request.Cookies["userInfo"]["BranchCode"].ToString();
           
              

                if (branchcode == "KK")
                {
                    DDlbranch = 1;
                   
                }
                else if (branchcode == "BY")
                {
                    DDlbranch = 2;
                  
                }
                else if (branchcode == "BB")
                {
                    DDlbranch = 3;
                   
                }
                else if (branchcode == "NP")
                {
                    DDlbranch = 4;
                  
                }
                else
                {
                    //DDlbranch.Enabled = true;

                }
       

                lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
                // sTableName = Request.Cookies["userInfo"]["User"].ToString();
                     
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Store
            if (rb_Store_Exec.Checked == true)
            {
                store = "Excellent";
            }
            else if (rb_Store_VG.Checked == true)
            {
                store = "Very Good";
            }
            else if (rb_Store_Good.Checked == true)
            {
                store = "Good";
            }
            else if (rb_Store_Bad.Checked == true)
            {
                store = "Bad";
            }
            else
            {
                store = "Very Bad";
            }
            #endregion

            #region Lobbies
            if (rb_Lobbies_Exec.Checked == true)
            {
                lobbies = "Excellent";
            }
            else if (rb_Lobbies_VG.Checked == true)
            {
                lobbies = "Very Good";
            }
            else if (rb_Lobbies_Good.Checked == true)
            {
                lobbies = "Good";
            }
            else if (rb_Lobbies_Bad.Checked == true)
            {
                lobbies = "Bad";
            }
            else
            {
                lobbies = "Very Bad";
            }
            #endregion

            #region F&B
            if (rb_FB_Exec.Checked == true)
            {
                FB = "Excellent";
            }
            else if (rb_FB_VG.Checked == true)
            {
                FB = "Very Good";
            }
            else if (rb_FB_Good.Checked == true)
            {
                FB = "Good";
            }
            else if (rb_FB_Bad.Checked == true)
            {
                FB = "Bad";
            }
            else
            {
                FB = "Very Bad";
            }
            #endregion

            #region Ambition
            if (rb_Amb_Exec.Checked == true)
            {
                Amb = "Excellent";
            }
            else if (rb_Amb_VG.Checked == true)
            {
                Amb = "Very Good";
            }
            else if (rb_Amb_Good.Checked == true)
            {
                Amb = "Good";
            }
            else if (rb_Amb_Bad.Checked == true)
            {
                Amb = "Bad";
            }
            else
            {
                Amb = "Very Bad";
            }
            #endregion

            #region Service
            if (rb_Service_Exec.Checked == true)
            {
                Service = "Excellent";
            }
            else if (rb_Service_VG.Checked == true)
            {
                Service = "Very Good";
            }
            else if (rb_Service_Good.Checked == true)
            {
                Service = "Good";
            }
            else if (rb_Service_Bad.Checked == true)
            {
                Service = "Bad";
            }
            else
            {
                Service = "Very Bad";
            }
            #endregion


            #region Experience

            if (rb_Experience_Exec.Checked == true)
            {
                Exp = "Excellent";
            }
            else if (rb_Experience_VG.Checked == true)
            {
                Exp = "Very Good";
            }
            else if (rb_Experience_Good.Checked == true)
            {
                Exp = "Good";
            }
            else if (rb_Experience_Bad.Checked == true)
            {
                Exp = "Bad";
            }
            else
            {
                Exp = "Very Bad";
            }
            #endregion

            int i = objbs.FeedBack(store, lobbies, FB, Amb, Service, Exp, txtname.Text, txtEmail.Text, txtMobile.Text, DDlbranch,Convert.ToDateTime( dt));
           
            Response.Redirect("FeedBack_Reply.aspx");
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedBack_Form.aspx");
        }
    }
}