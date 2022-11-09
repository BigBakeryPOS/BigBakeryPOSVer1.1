using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class KitPrint : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string branchcode = "";
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";
        string cancelno1 = "";
        int cancelno = 0;
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            //branchcode = Session["BranchCode"].ToString();
            //sStore = Request.Cookies["userInfo"]["Store"].ToString();
            //sAddress = Session["Address"].ToString();
            //sTin = Session["TIN"].ToString();
            if (!IsPostBack)
            {
                int OrderNo = Convert.ToInt32(Request.QueryString.Get("OrderNo"));


                int Orderid = Convert.ToInt32(Request.QueryString.Get("OrderNo"));
                string branchcode = Convert.ToString(Request.QueryString.Get("Bcode"));
                string Ordersummary = Convert.ToString(Request.QueryString.Get("comefrom"));


                cancelno1 = Convert.ToString(Request.QueryString.Get("cancelno"));
                if (cancelno1 == "Select order no.")
                {
                }
                else
                {
                    cancelno = Convert.ToInt32(Request.QueryString.Get("cancelno"));
                }
                tremp.Visible = false;
                

                if (Ordersummary == "Ordersummary")
                {
                    tremp.Visible = true;
                    ds = objbs.PrintCakeOrder_summary(branchcode, OrderNo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblBookno.Text = ds.Tables[0].Rows[0]["BookNo"].ToString();
                        lblOrderNo.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                        DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"]);
                        lblDate.Text = dt.ToString("dd/MM/yyyy hh:mm tt");

                        DataSet getbranch = objbs.getbranchcode(branchcode);
                        if (getbranch.Tables[0].Rows.Count > 0)
                        {
                            lblbnch.Text = getbranch.Tables[0].Rows[0]["BranchArea"].ToString();
                        }
                        else
                        {
                            lblbnch.Text = "Nil-Went Wrong!!!";
                        }

                        DateTime deltime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DeliveryDate"]);
                        lblDeliveryDate.Text = deltime.ToShortDateString();
                        lblTime.Text = ds.Tables[0].Rows[0]["DeliveryTime"].ToString();
                        lblemp.Text = ds.Tables[0].Rows[0]["Empname"].ToString();

                        //lblMessage.Text = ds.Tables[0].Rows[0]["Messege"].ToString();

                        gvPrint.DataSource = ds;
                        gvPrint.DataBind();
                    }
                }
                else
                {

                    ds = objbs.PrintCakeOrder(sTableName, OrderNo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblBookno.Text = ds.Tables[0].Rows[0]["BookNo"].ToString();
                        lblOrderNo.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                        DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"]);
                        lblDate.Text = dt.ToString("dd/MM/yyyy hh:mm tt");

                        DataSet getbranch = objbs.getbranchcode(sTableName);
                        if (getbranch.Tables[0].Rows.Count > 0)
                        {
                            lblbnch.Text = getbranch.Tables[0].Rows[0]["BranchArea"].ToString();
                        }
                        else
                        {
                            lblbnch.Text = "Nil-Went Wrong!!!";
                        }

                        DateTime deltime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DeliveryDate"]);
                        lblDeliveryDate.Text = deltime.ToShortDateString();
                        lblTime.Text = ds.Tables[0].Rows[0]["DeliveryTime"].ToString();

                        lblMessage.Text = ds.Tables[0].Rows[0]["Messege"].ToString();

                        gvPrint.DataSource = ds;
                        gvPrint.DataBind();
                    }
                }
               

            }
        }
    }
}