using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;

namespace Billing.Accountsbootstrap
{
    public partial class Dashchart : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string Btype = "";

        double ItemQty = 0; double ItemAmount = 0;
        double OrderTotal = 0; double OrderPaid = 0; double OrderBalancePaid = 0;

        StringBuilder str = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lblsTableName.Text = Request.Cookies["userInfo"]["User"].ToString();
            Btype = Request.Cookies["userInfo"]["BType"].ToString();
            if (!IsPostBack)
            {

                DataSet dsreason = new DataSet();
                dsreason = objbs.GetReturnResaon(Btype);
                ddlreason.DataTextField = "Reason";
                ddlreason.DataValueField = "reasonid";
                ddlreason.DataSource = dsreason.Tables[0];
                ddlreason.DataBind();
                ddlreason.Items.Insert(0, "All");

                txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime baseDate = Convert.ToDateTime(txtdate.Text);
                var today = baseDate;

                string day = (baseDate).ToString("dddd");
                string month = (baseDate).ToString("MMM");
                string date = (baseDate).ToString("dd");
                string year = (baseDate).ToString("yyyy");

                var WeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                var WeekEnd = WeekStart.AddDays(7).AddSeconds(-1);

                string fromsalesday = (WeekStart).ToString("dddd");
                string fromsalesmonth = (WeekStart).ToString("MMM");
                string fromsalesdate = (WeekStart).ToString("dd");
                string fromsalesyear = (WeekStart).ToString("yyyy");

                string tosalesday = (WeekEnd).ToString("dddd");
                string tosalesmonth = (WeekEnd).ToString("MMM");
                string tosalesdate = (WeekEnd).ToString("dd");
                string tosalesyear = (WeekEnd).ToString("yyyy");

                string fromorderday = (WeekStart).ToString("dddd");
                string fromordermonth = (WeekStart).ToString("MMM");
                string fromorderdate = (WeekStart).ToString("dd");
                string fromorderyear = (WeekStart).ToString("yyyy");

                string toorderday = (WeekEnd).ToString("dddd");
                string toordermonth = (WeekEnd).ToString("MMM");
                string toorderdate = (WeekEnd).ToString("dd");
                string toorderyear = (WeekEnd).ToString("yyyy");

                chart_bind();

                string Allow = "No";
                if (Allow == "No")
                {
                    #region Old

                    // Getting Today Sales
                    DataSet gettodaysales = objbs.getSalesRevenue(sTableName, txtdate.Text, txtdate.Text);
                    if (gettodaysales.Tables[0].Rows.Count > 0)
                    {
                        lblSales.Text = Convert.ToDouble(gettodaysales.Tables[0].Rows[0]["cnt"]).ToString("0.00") + '/' + gettodaysales.Tables[0].Rows[0]["cvv"].ToString();


                    }
                    lblday.Text = day + " " + month + " " + date + "," + year;

                    // Getting Order
                    DataSet gettodayorder = objbs.getorderRevenue(sTableName, txtdate.Text, txtdate.Text);
                    DataSet gettodayordercount = objbs.getorderRevenuecount(sTableName, txtdate.Text, txtdate.Text);
                    if (gettodayorder.Tables[0].Rows.Count > 0)
                    {
                        lblorder.Text = Convert.ToDouble(gettodayorder.Tables[0].Rows[0]["cnt"]).ToString("0.00") + '/' + gettodayordercount.Tables[0].Rows[0]["cvv"].ToString();

                    }
                    lblorderday.Text = day + " " + month + " " + date + "," + year;

                    // Sales Revenue
                    DataSet dsSalesRevenue = objbs.getSalesRevenue(sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));
                    if (dsSalesRevenue.Tables[0].Rows.Count > 0)
                    {
                        lblsalesrevenue.Text = Convert.ToDouble(dsSalesRevenue.Tables[0].Rows[0]["cnt"]).ToString("0.00") + '/' + dsSalesRevenue.Tables[0].Rows[0]["cvv"].ToString();


                    }
                    lblsalesrevenuefrom.Text = fromsalesday + " " + fromsalesmonth + " " + fromsalesdate + "," + fromsalesyear;
                    lblsalesrevenueto.Text = tosalesday + " " + tosalesmonth + " " + tosalesdate + "," + tosalesyear;

                    // Order Revenue
                    DataSet dsorderRevenue = objbs.getorderRevenue(sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));
                    DataSet dsorderRevenuecount = objbs.getorderRevenuecount(sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));
                    if (gettodayorder.Tables[0].Rows.Count > 0)
                    {
                        lblorderrevenue.Text = Convert.ToDouble(dsorderRevenue.Tables[0].Rows[0]["cnt"]).ToString("0.00") + '/' + dsorderRevenuecount.Tables[0].Rows[0]["cvv"].ToString();

                    }
                    lblorderrevenuefrom.Text = fromorderday + " " + fromordermonth + " " + fromorderdate + "," + fromorderyear;
                    lblorderrevenueto.Text = toorderday + " " + toordermonth + " " + toorderdate + "," + toorderyear;


                    #region Sales Chsrt
                    Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                    Chart1.Series["Series1"].IsValueShownAsLabel = true;

                    DataSet dsSalesChart = objbs.getSalesChart(sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

                    DataTable dtsales = new DataTable();
                    DataColumn dcsales;

                    dcsales = new DataColumn();
                    dcsales.ColumnName = "WeekDays";
                    dtsales.Columns.Add(dcsales);
                    dcsales = new DataColumn();
                    dcsales.ColumnName = "SalesCount";
                    dtsales.Columns.Add(dcsales);

                    if (dsSalesChart.Tables.Count > 0)
                    {
                        if (dsSalesChart.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsSalesChart.Tables[0].Rows.Count; i++)
                            {
                                DataRow dr = dtsales.NewRow();

                                dr["WeekDays"] = dsSalesChart.Tables[0].Rows[i]["WeekDays"].ToString();
                                dr["SalesCount"] = dsSalesChart.Tables[0].Rows[i]["cvv"].ToString();

                                dtsales.Rows.Add(dr);
                            }

                            Chart1.DataSource = dtsales;
                            Chart1.Series["Series1"].XValueMember = "WeekDays";
                            Chart1.Series["Series1"].YValueMembers = "SalesCount";
                            Chart1.DataBind();

                        }
                    }

                    #endregion

                    #region Top Sales
                    //Top Sales
                    DataSet ds = objbs.topandlastsalesitem("DESC", sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvitems.DataSource = ds;
                        gvitems.DataBind();
                    }
                    else
                    {
                        gvitems.DataSource = null;
                        gvitems.DataBind();
                    }

                    #endregion

                    #region Up Going  Orders
                    //Up Going  Orders
                    DataSet dsupgoingorders = objbs.upgoingorders(sTableName, txtdate.Text, txtdate.Text);
                    if (dsupgoingorders.Tables[0].Rows.Count > 0)
                    {
                        gvupgoingorders.DataSource = dsupgoingorders;
                        gvupgoingorders.DataBind();
                    }
                    else
                    {
                        gvupgoingorders.DataSource = null;
                        gvupgoingorders.DataBind();
                    }

                    #endregion


                    #endregion
                }

            }


        }

        private void chart_bind()
        {
            lt.Text = "";

            DateTime baseDate = Convert.ToDateTime(txtdate.Text);
            var today = baseDate;
            var WeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var WeekEnd = WeekStart.AddDays(7).AddSeconds(-1);


            DataTable dt = new DataTable();

            DataTable dtsum = new DataTable();
            DataSet dssum = new DataSet();
            DataRow drsum;

            dtsum.Columns.Add("Day");

            //Return Column Create 
            DataSet Dsreasons = objbs.getReturnreports2(sTableName, WeekStart, WeekEnd, ddlreason.SelectedValue);
            if (Dsreasons.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Dr in Dsreasons.Tables[0].Rows)
                {
                    dtsum.Columns.Add(Dr["Reason"].ToString());
                }

            }
            //Sales Column Create
            DataSet dssaleschart = objbs.SalesCharts(sTableName, WeekStart, WeekEnd);
            if (dssaleschart.Tables[0].Rows.Count > 0)
            {
                dtsum.Columns.Add("Sales");
            }

            //Payment Column Create
            DataSet dspaymententry = objbs.PaymentCharts(WeekStart, WeekEnd, sTableName);
            if (dspaymententry.Tables[0].Rows.Count > 0)
            {
                dtsum.Columns.Add("Payments");
            }

            //Sales Staff Credit
            DataSet dsSalesStaffCredit = objbs.SalesStaffCreditCharts(sTableName, WeekStart, WeekEnd, "9");
            if (dsSalesStaffCredit.Tables[0].Rows.Count > 0)
            {
                dtsum.Columns.Add("SalesStaffCredit");
            }

            //Order Staff Credit
            DataSet dsOrderStaffCredit = objbs.OrderStaffCreditCharts(sTableName, WeekStart, WeekEnd, "5");
            if (dsOrderStaffCredit.Tables[0].Rows.Count > 0)
            {
                dtsum.Columns.Add("OrderStaffCredit");
            }

            //Sales Discount
            DataSet dsSalesDiscountCharts = objbs.SalesDiscountCharts(sTableName, WeekStart, WeekEnd);
            if (dsSalesDiscountCharts.Tables[0].Rows.Count > 0)
             {
                 dtsum.Columns.Add("SalesDiscount");
             }

            dssum.Tables.Add(dtsum);

            string[] WeekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            //Assign Values
            DataSet DsreasonsData = objbs.getReturnreports1(sTableName, WeekStart, WeekEnd, ddlreason.SelectedValue);
            if (DsreasonsData.Tables[0].Rows.Count > 0)
            {
                #region


                for (int D = 0; D < 7; D++)
                {
                    string DAYS = WeekDays[D];

                    drsum = dtsum.NewRow();

                    drsum["Day"] = DAYS;

                    foreach (DataColumn Dc in dtsum.Columns)
                    {
                        string DataClmn = Dc.ToString();

                        if (DataClmn.ToString() != "Day" && DataClmn.ToString() != "Sales" && DataClmn.ToString() != "Payments" && DataClmn.ToString() != "SalesStaffCredit" && DataClmn.ToString() != "OrderStaffCredit" && DataClmn.ToString() != "SalesDiscount")
                        {
                            DataRow[] rows = DsreasonsData.Tables[0].Select("Reason='" + DataClmn + "' and Day='" + DAYS + "'");
                            if (rows.Length > 0)
                            {
                                drsum[Dc.ToString()] = rows[0]["Amount"];
                            }
                            else
                            {
                                drsum[Dc.ToString()] = 0;
                            }
                        }
                        else if (DataClmn.ToString() == "Sales")
                        {
                            DataRow[] rows = dssaleschart.Tables[0].Select("Day='" + DAYS + "'");
                            if (rows.Length > 0)
                            {
                                drsum[Dc.ToString()] = rows[0]["Amount"];
                            }
                            else
                            {
                                drsum[Dc.ToString()] = 0;
                            }
                        }
                        else if (DataClmn.ToString() == "Payments")
                        {
                            DataRow[] rows = dspaymententry.Tables[0].Select("Day='" + DAYS + "'");
                            if (rows.Length > 0)
                            {
                                drsum[Dc.ToString()] = rows[0]["Amount"];
                            }
                            else
                            {
                                drsum[Dc.ToString()] = 0;
                            }
                        }
                        else if (DataClmn.ToString() == "SalesStaffCredit")
                        {
                            DataRow[] rows = dsSalesStaffCredit.Tables[0].Select("Day='" + DAYS + "'");
                            if (rows.Length > 0)
                            {
                                drsum[Dc.ToString()] = rows[0]["Amount"];
                            }
                            else
                            {
                                drsum[Dc.ToString()] = 0;
                            }
                        }
                        else if (DataClmn.ToString() == "OrderStaffCredit")
                        {
                            DataRow[] rows = dsOrderStaffCredit.Tables[0].Select("Day='" + DAYS + "'");
                            if (rows.Length > 0)
                            {
                                drsum[Dc.ToString()] = rows[0]["Amount"];
                            }
                            else
                            {
                                drsum[Dc.ToString()] = 0;
                            }
                        }
                        else if (DataClmn.ToString() == "SalesDiscount")
                        {
                            DataRow[] rows = dsSalesDiscountCharts.Tables[0].Select("Day='" + DAYS + "'");
                            if (rows.Length > 0)
                            {
                                drsum[Dc.ToString()] = rows[0]["Amount"];
                            }
                            else
                            {
                                drsum[Dc.ToString()] = 0;
                            }
                        }

                    }

                    dssum.Tables[0].Rows.Add(drsum);

                }

                dt = dssum.Tables[0];

                string addColumn = "";

                string A = "F";
                foreach (DataColumn Dc in dtsum.Columns)
                {
                    string DataClmn = Dc.ToString();
                    if (A == "F")
                    {
                        addColumn = "data.addColumn('string', '" + DataClmn + "');";
                        A = "S";
                    }
                    else
                    {
                        addColumn = addColumn + "data.addColumn('number', '" + DataClmn + "');";
                    }
                }



                str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
      google.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = new google.visualization.DataTable();
      " + addColumn + " data.addRows(" + dt.Rows.Count + ");");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int XYZ = 0;
                    foreach (DataColumn Dc in dtsum.Columns)
                    {
                        string DataClmn = Dc.ToString();
                        str.Append("data.setValue(" + i + "," + XYZ + "," + "'" + dt.Rows[i][DataClmn].ToString() + "');");
                        XYZ++;
                    }

                }

                str.Append("var chart = new google.visualization.LineChart(document.getElementById('chart_div'));");
                str.Append("chart.draw(data, {width: 1200, height: 350, title: 'Stock Return',");

                //str.Append("legend: {position: 'top', maxLines: 3},");


                str.Append("vAxis: {title: 'Amount', titleTextStyle: {color: 'black'}},hAxis: {title: 'WeekDays', titleTextStyle: {color: 'black'}}");


                str.Append("}); }");
                str.Append("</script>");

                lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');

                #endregion
            }

            //else
            //{
            //    lt.Text = "";
            //}
        }

        protected void txtdate_OnTextChanged(object sender, EventArgs e)
        {
            chart_bind();
        }
        protected void ddlreason_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            chart_bind();
        }

        [System.Web.Services.WebMethod]
        public static List<object> GetChartData()
        {
            string lblsTableName = "kvl"; string txtdate = "2019-09-16";

            // string aadf = aaa;

            DateTime baseDate = Convert.ToDateTime(txtdate);
            var today = baseDate;

            var WeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var WeekEnd = WeekStart.AddDays(7).AddSeconds(-1);

            string query = "select sum(b.Amount) as Amount,f.Reason from tblReturn_" + lblsTableName + " a,tblTransReturn_" + lblsTableName + " b,tblCategoryUser c,tblcategory d,tblSubReasons e,tblreason f,tbllogin l where f.reasonid=a.ipaymode and a.RetNo=b.RetNo and c.categoryid=d.categoryid and b.SubCategoryID=c.CategoryUserID and e.id=a.Reasonsid and l.userid=a.Userid and CONVERT(date, a.RetDate )>= '" + Convert.ToDateTime(WeekStart).ToString("yyyy-MM-dd") + "' and CONVERT(date, a.RetDate ) <= '" + Convert.ToDateTime(WeekEnd).ToString("yyyy-MM-dd") + "' group by Reason order by Reason asc";
            string constr = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;

            List<object> chartData = new List<object>();
            chartData.Add(new object[]
    {
        "Reason", "Amount"
    });
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (System.Data.SqlClient.SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                    {
                        sdr["Reason"], sdr["Amount"]
                    });
                        }
                    }
                    con.Close();
                    return chartData;
                }
            }
        }

        protected void ddlchart_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime baseDate = Convert.ToDateTime(txtdate.Text);
            var today = baseDate;
            var WeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var WeekEnd = WeekStart.AddDays(7).AddSeconds(-1);

            if (ddlchart.SelectedValue == "1")
            {
                #region Sales
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsSalesChart = objbs.getSalesChart(sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

                DataTable dtsales = new DataTable();
                DataColumn dcsales;

                dcsales = new DataColumn();
                dcsales.ColumnName = "WeekDays";
                dtsales.Columns.Add(dcsales);
                dcsales = new DataColumn();
                dcsales.ColumnName = "SalesCount";
                dtsales.Columns.Add(dcsales);

                if (dsSalesChart.Tables.Count > 0)
                {
                    if (dsSalesChart.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsSalesChart.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = dtsales.NewRow();

                            dr["WeekDays"] = dsSalesChart.Tables[0].Rows[i]["WeekDays"].ToString();
                            dr["SalesCount"] = dsSalesChart.Tables[0].Rows[i]["cvv"].ToString();

                            dtsales.Rows.Add(dr);
                        }

                        Chart1.DataSource = dtsales;
                        Chart1.Series["Series1"].XValueMember = "WeekDays";
                        Chart1.Series["Series1"].YValueMembers = "SalesCount";
                        Chart1.DataBind();

                    }
                }

                #endregion
            }
            else
            {
                #region Order
                Chart1.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart1.Series["Series1"].IsValueShownAsLabel = true;

                DataSet dsSalesChart = objbs.getorderChart(sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

                DataTable dtsales = new DataTable();
                DataColumn dcsales;

                dcsales = new DataColumn();
                dcsales.ColumnName = "WeekDays";
                dtsales.Columns.Add(dcsales);
                dcsales = new DataColumn();
                dcsales.ColumnName = "SalesCount";
                dtsales.Columns.Add(dcsales);

                if (dsSalesChart.Tables.Count > 0)
                {
                    if (dsSalesChart.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsSalesChart.Tables[0].Rows.Count; i++)
                        {
                            DataRow dr = dtsales.NewRow();

                            dr["WeekDays"] = dsSalesChart.Tables[0].Rows[i]["WeekDays"].ToString();
                            dr["SalesCount"] = dsSalesChart.Tables[0].Rows[i]["cvv"].ToString();

                            dtsales.Rows.Add(dr);
                        }

                        Chart1.DataSource = dtsales;
                        Chart1.Series["Series1"].XValueMember = "WeekDays";
                        Chart1.Series["Series1"].YValueMembers = "SalesCount";
                        Chart1.DataBind();

                    }
                }

                #endregion
            }

        }
        protected void ddlitems_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime baseDate = Convert.ToDateTime(txtdate.Text);
            var today = baseDate;
            var WeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
            var WeekEnd = WeekStart.AddDays(7).AddSeconds(-1);

            DataSet ds = new DataSet();
            if (ddlitems.SelectedValue == "1")
            {
                //Top Sales
                ds = objbs.topandlastsalesitem("DESC", sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

            }
            else if (ddlitems.SelectedValue == "2")
            {
                //Last Sales
                ds = objbs.topandlastsalesitem("ASC", sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

            }
            else if (ddlitems.SelectedValue == "3")
            {
                //Top Order
                ds = objbs.topandlastorderitem("DESC", sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

            }
            else
            {
                //Last Order
                ds = objbs.topandlastorderitem("ASC", sTableName, WeekStart.ToString("yyyy-MM-dd"), WeekEnd.ToString("yyyy-MM-dd"));

            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvitems.DataSource = ds;
                gvitems.DataBind();
            }
            else
            {
                gvitems.DataSource = null;
                gvitems.DataBind();
            }

            ddlchart_OnSelectedIndexChanged(sender, e);

        }
        protected void gvupgoingorders_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrderTotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
                OrderPaid += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Paid"));
                OrderBalancePaid += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BalancePaid"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total:-";
                e.Row.Cells[6].Text = OrderTotal.ToString("f2");
                e.Row.Cells[7].Text = OrderPaid.ToString("f2");
                e.Row.Cells[8].Text = OrderBalancePaid.ToString("f2");
            }

        }
        protected void gvitems_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ItemQty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalQty"));
                ItemAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total:-";
                e.Row.Cells[2].Text = ItemQty.ToString("f2");
                e.Row.Cells[3].Text = ItemAmount.ToString("f2");
            }

        }



    }
}