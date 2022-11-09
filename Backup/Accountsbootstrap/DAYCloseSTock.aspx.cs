using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BusinessLayer;

namespace Billing.Accountsbootstrap
{
    public partial class DAYCloseSTock : System.Web.UI.Page
    {
        string sTableName = "";
        string sCode = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);

            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();
            lblbranch.Text = StoreName;
            //Page.Header.DataBind();
            if (!IsPostBack)
            {

                DataSet checkdayclose = objbs.checkinser_Previousday(sTableName);
                if (checkdayclose.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    DateTime Toady = DateTime.Now.AddDays(-1);
                    txttodate.Text = Toady.ToString("yyyy-MM-dd");
                    
                  //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch Done day Close Or Not.Please Contact Administrator.Thank You!!!');", true);
//                    return;
                }
               
            }

        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void btnser_Click(object sender, EventArgs e)
        {


            DateTime date = Convert.ToDateTime(txttodate.Text);
            DateTime Toady = DateTime.Now.Date; ;

            if (Convert.ToDateTime(Toady) < Convert.ToDateTime(date))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Selected Date Not Greater Than current Date.Thank You!!!');", true);
                return;
            }

            var dateDiff = Toady - date;
            int totalDays = Convert.ToInt32(dateDiff.TotalDays);
            //////var days = date.Day;
            //////var toda = Toady.Day;

            // if ((toda - days) <= 30)
            if ((totalDays) < Convert.ToInt32(2))
            {
               
            }

            else
            {
                txttodate.Text = "";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Today Day Or Else yesterday Date.Thank You!!!');", true);
                return;
                
            }

           // return;

            if (txtnam.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Day Close Name.Thank You!!!');", true);
                return;
            }
            else
            {

                if (txttodate.Text != DateTime.Today.ToString("yyyy-MM-dd"))
                {


                    objbs.dayclosername_Previousday(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                    DataSet ch = objbs.checkinser_Previousday(sTableName);
                    if (ch.Tables[0].Rows.Count > 0)
                    {
                        objbs.delOpening_Previousday(sTableName);
                        int transfer = objbs.insertselect_Previousday(sTableName);
                    }
                    else
                    {
                        int transfer = objbs.insertselect_Previousday(sTableName);
                    }
                   // ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thank You.Day Closed Successfully!!!.You Redirected To Billing Page.Thank You!!!!.');window.location ='newButton.aspx';", true);

                    //  Response.Redirect("../Accountsbootstrap/newbutton.aspx");
                }

                else
                {

                    objbs.dayclosername(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                    DataSet ch = objbs.checkinser(sTableName);
                    if (ch.Tables[0].Rows.Count > 0)
                    {
                        objbs.delOpening(sTableName);
                        int transfer = objbs.insertselect(sTableName);
                    }
                    else
                    {
                        int transfer = objbs.insertselect(sTableName);
                    }
                    // int closr = objbs.updatedayclose(Convert.ToInt32(lblUserID.Text), DateTime.Now.ToShortDateString());
                  //  ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "Closed();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thank You.Day Closed Successfully!!!.You Redirected To Billing Page.Thank You!!!!.');window.location ='newButton.aspx';", true);

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}