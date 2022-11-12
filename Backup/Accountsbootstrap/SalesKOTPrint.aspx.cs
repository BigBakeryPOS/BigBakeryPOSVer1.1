using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using DataLayer;
using System.Xml.Linq;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;

namespace Billing.Accountsbootstrap
{
    public partial class SalesKOTPrint : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sStore = "";
        string sAddress = "";
        string sTin = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUserID.Text = Session["UserID"].ToString();
            //lblUser.Text = Session["UserName"].ToString();
            //sTableName = Session["BranchCode"].ToString();
            //sStore = Session["Store"].ToString();

            sTableName = Request.QueryString.Get("BranchCode");
            sStore = Request.QueryString.Get("Store");

            int iD = Convert.ToInt32(Request.QueryString.Get("iSalesID"));
            int NewiD = Convert.ToInt32(Request.QueryString.Get("NewiSalesID"));
            string sMode = Request.QueryString.Get("Mode");
            
            lblstore.Text = sStore;
            if (iD > 0)
            {
                gvPrint.DataSource = null;
                gvPrint.DataBind();

                DataSet ds = new DataSet();

                ds = objBs.PrintKOtORder(iD, sTableName, sMode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblkot.Text = ds.Tables[0].Rows[0]["KotNo"].ToString();
                    lbluid.Text = lblUser.Text;
                    lblbillno.Text = ds.Tables[0].Rows[0]["KotNo"].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["KotDate"].ToString());
                    lbldate.Text = date.ToString("dd/MM/yyyy  hh:mm tt");
                    lbltable.Text = ds.Tables[0].Rows[0]["tablename"].ToString();
                    gvPrint.DataSource = ds;
                    gvPrint.DataBind();


                    
                }


            }

            else
            {
                

            }

        }
    }
}