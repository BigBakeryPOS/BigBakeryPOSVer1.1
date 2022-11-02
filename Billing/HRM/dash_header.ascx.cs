using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
namespace HRM
{
    public partial class dash_header : System.Web.UI.UserControl
    {

        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUserID.Text = Session["empid"].ToString();
            lblUser.Text = Session["UserName"].ToString();

            lblServiceID.Text = Session["serviceID"].ToString();

            if (Convert.ToInt32(lblServiceID.Text) == 2)
            {
              
               
                DdMenu2.Visible = false;
                m1.Visible = false;
                m2.Visible = false;
               // m3.Visible = false;
             

           
                //c3.Visible = false;
              
                //  Li1.Visible = true;
                Li3.Visible = true;
                DdMenu1.Visible = false;
            

             
                Li3.Visible = true;
               
             
              
                //  Li11.Visible = false;
                leavereport.Visible = true;
               
              
               
                
               
                
                Li21.Visible = true;


            }


            else if (Convert.ToInt32(lblUserID.Text) == 7)
            {
                leavereport.Visible = false;
                m1.Visible = true;
                m2.Visible = true;
                //m3.Visible = true;
               
                m5.Visible = false;
              
              
                //c3.Visible = true;
             
                DdMenu1.Visible = true;
                //  Li1.Visible = true;
              
                Li3.Visible = true;
               
                //T5.Visible = false;
                //T4.Visible = true;
                Li3.Visible = false;
              
              
              
                Li12.Visible = true;
                
              
                //Li11.Visible = true;
               
               
              
               
              
                
                Li21.Visible = true;


            }
            else
            {
                leavereport.Visible = true;
                DdMenu2.Visible = false;
                m1.Visible = false;
                m2.Visible = false;
                //m3.Visible = false;
               
               
                //c3.Visible = false;
               
                //   Li1.Visible = true;
                Li3.Visible = true;
                DdMenu1.Visible = false;
              

               
                //T5.Visible = true;
                //T4.Visible = false;
                Li3.Visible = true;
              
             
              
                Li12.Visible = false;
                
              
                //Li11.Visible = false;
              
              
               
              
                
                Li21.Visible = false;
            }
            #region Logo
            DataSet ds = objbs.getimage();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string logo = ds.Tables[0].Rows[0]["Data"].ToString();
                Image1.ImageUrl = logo;

            }
            else
            {
                Image1.ImageUrl = "~/IMAGES1/Fibretuff_logo.png";
                
            }
            #endregion
            //#region Menu color
            //DataSet ds1 = objbs.Menucolor1();
            //string color = ds1.Tables[0].Rows[0]["Menucolor"].ToString();
            //string bkcolor = ds1.Tables[0].Rows[0]["backgroundcolor"].ToString();
            ////bgmenu.Style.Add(HtmlTextWriterStyle.Color, color);
            //bgmenu.Style.Add("background-color", color.ToString());
            //// backcolor.Style.Add("background-color", bkcolor.ToString());
            //#endregion


        }
    }
}