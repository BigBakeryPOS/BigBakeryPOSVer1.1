using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Billing.Accountsbootstrap
{
    public partial class PieChart : System.Web.UI.Page
    {
        string sTableName = "";
        string scode = "";
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();
          //  lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
           // lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            DataTable dt = new DataTable();
            DataSet ds = objBs.PIECHART(sTableName);
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    //PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                    //{
                    //    Category = row["ShipCity"].ToString(),
                    //    Data = Convert.ToDecimal(row["TotalOrders"])
                    //});
                }
            }


        }
    }
}