using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using BusinessLayer;
using DataLayer;
using CommonLayer;

namespace HRM
{
    public partial class Header : System.Web.UI.UserControl
    {

        HRMclass objbs = new HRMclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lblUserID.Text = Session["empid"].ToString();
            lblUser.Text = Session["UserName"].ToString();            
            lblServiceID.Text = Session["serviceID"].ToString();
           
            if (Convert.ToInt32(lblServiceID.Text) == 2)
            {
                Li7.Visible = true;
                DdMenu1.Visible = false;
                
                m1.Visible = false;
                m2.Visible = false;
                m3.Visible = false;
                m4.Visible = false;
           
                c1.Visible = false;
                c2.Visible = false;
                //c3.Visible = false;
                c4.Visible = true;
              //  Li1.Visible = true;
                Li3.Visible = true;
                DdMenu1.Visible = false;
                Li2.Visible = false;
                Li4.Visible = true;
                
                T2.Visible = false;
                //T5.Visible = true;
                //T4.Visible = false;
                Li3.Visible = true;
                Li5.Visible = false;
                Li6.Visible = false;
                Li8.Visible = true;
                Li1.Visible = false;
                Li9.Visible = false;
              //  Li11.Visible = false;
                T11.Visible = false;
                Li15.Visible = false;
                Li17.Visible = false;
                salslip.Visible = false;
                Li11.Visible = true;
                 ddhrm.Visible = true;
                //Li19.Visible = true;
               //  Li13.Visible = false;
                 ddmmenu.Visible = false;
                 Li15.Visible = true;
                 ddmenupay.Visible = true;
                 config.Visible = false;
                 Li18.Visible = false;
                 Li21.Visible = false;
                 Li23.Visible = false;
                 Li24.Visible = true;
                 Li50.Visible = false;
              //   Li13.Visible = false;
               
               
            }
            

         else   if (Convert.ToInt32(lblUserID.Text) == 7)
            {
                Li22.Visible = false;
                m1.Visible = true;
                m2.Visible = true;
                m3.Visible = true;
                m4.Visible = true;
                m5.Visible = false;
                Li7.Visible = false;
                c1.Visible = true;
                c2.Visible = true;
                //c3.Visible = true;
                c4.Visible = true;
                DdMenu1.Visible = true;
              //  Li1.Visible = true;
                Li2.Visible = true;
                Li4.Visible = true;
                Li3.Visible = true;
                Li2.Visible = true;
                //T5.Visible = false;
                //T4.Visible = true;
                Li3.Visible = false;
                Li5.Visible = false;
                Li6.Visible = true;
                Li8.Visible = true;
                Li9.Visible = true;
                Li12.Visible = true;
                Li1.Visible = true;
                //Li11.Visible = true;
                Task.Visible = false;
                T2.Visible = true;
                T11.Visible = true;
                Li15.Visible = true;
                salslip.Visible = false;
                Li17.Visible = true;
                 Li11.Visible = false;
                 ddhrm.Visible = false;
                //Li19.Visible = true;
                 //Li13.Visible = true;
                 ddmmenu.Visible = true;
                 Li15.Visible = false;
                 ddmenupay.Visible = false;
                 config.Visible = true;
                 Li18.Visible = false;
                 Li21.Visible = true;
                 Li23.Visible = true;
                 Li24.Visible = false;
                 Li50.Visible = true;
                 //Li13.Visible = true;          

            }
            else
            {

                m1.Visible = false;
                m2.Visible = false;
                m3.Visible = false;
                m4.Visible = false;
                Li7.Visible = false;
                c1.Visible = false;
                c2.Visible = false;
                //c3.Visible = false;
                c4.Visible = true;
             //   Li1.Visible = true;
                //Li3.Visible = false;
                DdMenu1.Visible = false;
                Li2.Visible = false;
                Li4.Visible = true;
               
                T2.Visible = false;
                //T5.Visible = true;
                //T4.Visible = false;
                Li3.Visible = true;
                Li5.Visible = false;
                Li6.Visible = false;
                Li8.Visible = false;
                Li9.Visible = false;
                Li12.Visible = false;
                Li1.Visible = false;
                T11.Visible = false;
                //Li11.Visible = false;
                salslip.Visible = false;
                Li15.Visible = false;
                salslip.Visible = false;
                Li11.Visible = true;
               ddhrm.Visible = true;
                //Li19.Visible = true;
               //Li13.Visible = false;
               ddmmenu.Visible = false;
               Li15.Visible = true;
               ddmenupay.Visible = true;
               config.Visible = false;
               Li18.Visible = true;
               Li21.Visible = false;
               Li22.Visible = true;
               Li23.Visible = true;
               Li24.Visible = true;
               Li50.Visible = true;
               //Li13.Visible = true;        
            }
            #region Logo
            DataSet ds = objbs.getimage();
            string logo = ds.Tables[0].Rows[0]["Data"].ToString();
            Image1.ImageUrl = logo;
            #endregion
            #region Menu color
            DataSet ds1 = objbs.Menucolor1();
            string color = ds1.Tables[0].Rows[0]["Menucolor"].ToString();
            string bkcolor = ds1.Tables[0].Rows[0]["backgroundcolor"].ToString();
            //bgmenu.Style.Add(HtmlTextWriterStyle.Color, color);
            bgmenu.Style.Add("background-color",color.ToString());
           // backcolor.Style.Add("background-color", bkcolor.ToString());
            #endregion


        }

        }
    }
