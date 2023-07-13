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
    public partial class DayCloseStockStore : System.Web.UI.Page
    {
        string sTableName = "";
        string sCode = "";
        string BranchNAme = "";
        string StoreName = "";
        string Password = "";
        BSClass objbs = new BSClass();
        string Biller = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            Biller = Request.Cookies["userInfo"]["Biller"].ToString();

            txtnam.Text = Biller;

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);

            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();
            lblbranch.Text = StoreName;

            if (!IsPostBack)
            {
                DataSet checkdayclose = objbs.StoreDayPreviousdayCheckInser(sTableName);
                if (checkdayclose.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    DateTime Toady = DateTime.Now.AddDays(-1);
                    txtdate.Text = Toady.ToString("yyyy-MM-dd");
                }

            }

        }


        protected void btnCloseDay_OnClick(object sender, EventArgs e)
        {


            DateTime date = Convert.ToDateTime(txtdate.Text);
            DateTime Toady = DateTime.Now.Date; ;

            if (Convert.ToDateTime(Toady) < Convert.ToDateTime(date))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Selected Date Not Greater Than current Date.');", true);
                return;
            }

            var dateDiff = Toady - date;
            int totalDays = Convert.ToInt32(dateDiff.TotalDays);
            if ((totalDays) < Convert.ToInt32(2))
            {
            }
            else
            {
                txtdate.Text = "";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Select Today Day Or Else yesterday Date.');", true);
                return;

            }

            if (txtnam.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "SelectGiven", "alert('Please Enter Day Close Name.');", true);
                return;
            }
            else
            {

                if (txtdate.Text != DateTime.Today.ToString("yyyy-MM-dd"))
                {
                    objbs.dayclosername_Previousday(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                    DataSet ch = objbs.StoreDayPreviousdayCheckInser(sTableName);
                    if (ch.Tables[0].Rows.Count > 0)
                    {
                        objbs.StoreDaydelOpening_Previousday(sTableName);
                        int transfer = objbs.StoreDayCloseinsert(sTableName);
                    }
                    else
                    {
                        int transfer = objbs.StoreDayCloseinsert(sTableName);
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thank You.Day Closed Successfully.');window.location ='StoreRawItemRequest.aspx';", true);

                }
                else
                {
                    objbs.dayclosername(txtnam.Text, Convert.ToInt32(lblUserID.Text));
                    DataSet ch = objbs.checkinserStore(sTableName);
                    if (ch.Tables[0].Rows.Count > 0)
                    {
                        objbs.delOpeningStore(sTableName);
                        int transfer = objbs.insertselectStore(sTableName);
                    }
                    else
                    {
                        int transfer = objbs.insertselectStore(sTableName);
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thank You.Day Closed Successfully.');window.location ='StoreRawItemRequest.aspx';", true);

                }
            }

        }


    }
}