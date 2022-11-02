using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace Billing.Accountsbootstrap
{
    public partial class CategoryChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (rdCat.Checked == true)
            {
                cat.Visible = true;
                mon.Visible = false;
                //Set the chart type that you want the data to render
                // as in the chart.
                chart1.Series["series"].ChartType = SeriesChartType.Column;
                chart1.Series["series1"].ChartType = SeriesChartType.Column;
                chart1.Series["series2"].ChartType = SeriesChartType.Column;
                // Populate data into the series.
                chart1.Series["series"].Points.AddY(400);
                chart1.Series["series"].Points[0].AxisLabel = "Socks";//.AddY(400);

                chart1.Series["series"].Points.AddY(350);
                chart1.Series["series"].Points.AddY(375);

                chart1.Series["series1"].Points.AddY(300);
                chart1.Series["series1"].Points.AddY(200);
                chart1.Series["series1"].Points.AddY(300);

                chart1.Series["series1"].Points[1].AxisLabel = "Body Shape Cloth";//.AddY(400);


                chart1.Series["series2"].Points.AddY(250);
                chart1.Series["series2"].Points.AddY(225);
                chart1.Series["series2"].Points.AddY(350);
                chart1.Series["series2"].Points[2].AxisLabel = "Sanitory Napkin";//.AddY(400);
                if (!IsPostBack)
                {
                    chart2.Series["series"].ChartType = SeriesChartType.Pie;
                    chart2.Titles[0].Text = "Category by Sales - " + drpCategory.SelectedItem.Text + " (INR)";
                    // Populate data into the series.
                    chart2.Series["series"].Points.AddY(40000);
                    chart2.Series["series"].Points[0].AxisLabel = "Admin";//.AddY(400);

                    chart2.Series["series"].Points.AddY(34500);

                    chart2.Series["series"].Points[1].AxisLabel = "Branch";//.AddY(400);


                    chart2.Series["series"].Points.AddY(25000);
                    chart2.Series["series"].Points[2].AxisLabel = "Dealer";//.AddY(400);


                }

            }

            else
            {
                mon.Visible = true;
                cat.Visible = false;
                chart3.Series["series"].ChartType = SeriesChartType.Line;
                chart3.Series["series1"].ChartType = SeriesChartType.Line;
                chart3.Series["series2"].ChartType = SeriesChartType.Line;
                // Populate data into the series.
                chart3.Series["series"].Points.AddY(150);
                chart3.Series["series"].Points.AddY(175);
                chart3.Series["series"].Points.AddY(180);
                chart3.Series["series"].Points.AddY(190);
                chart3.Series["series"].Points.AddY(200);
                chart3.Series["series"].Points.AddY(225);
                chart3.Series["series"].Points.AddY(250);
                chart3.Series["series"].Points.AddY(275);
                chart3.Series["series"].Points.AddY(285);
                chart3.Series["series"].Points.AddY(300);
                chart3.Series["series"].Points.AddY(315);
                chart3.Series["series"].Points.AddY(329);

                chart3.Series["series1"].Points.AddY(100);
                chart3.Series["series1"].Points.AddY(115);
                chart3.Series["series1"].Points.AddY(120);
                chart3.Series["series1"].Points.AddY(120);
                chart3.Series["series1"].Points.AddY(130);
                chart3.Series["series1"].Points.AddY(145);
                chart3.Series["series1"].Points.AddY(150);
                chart3.Series["series1"].Points.AddY(175);
                chart3.Series["series1"].Points.AddY(185);
                chart3.Series["series1"].Points.AddY(190);
                chart3.Series["series1"].Points.AddY(205);
                chart3.Series["series1"].Points.AddY(209);

                chart3.Series["series2"].Points.AddY(80);
                chart3.Series["series2"].Points.AddY(95);
                chart3.Series["series2"].Points.AddY(100);
                chart3.Series["series2"].Points.AddY(100);
                chart3.Series["series2"].Points.AddY(105);
                chart3.Series["series2"].Points.AddY(110);
                chart3.Series["series2"].Points.AddY(115);
                chart3.Series["series2"].Points.AddY(120);
                chart3.Series["series2"].Points.AddY(125);
                chart3.Series["series2"].Points.AddY(130);
                chart3.Series["series2"].Points.AddY(145);
                chart3.Series["series2"].Points.AddY(150);

                chart3.Series["series"].Points[0].AxisLabel = "Jan";//.AddY(400);
                chart3.Series["series"].Points[1].AxisLabel = "Feb";//.AddY(400);
                chart3.Series["series"].Points[2].AxisLabel = "Mar";//.AddY(400);
                chart3.Series["series"].Points[3].AxisLabel = "Apr";//.AddY(400);

                chart3.Series["series"].Points[4].AxisLabel = "May";//.AddY(400);

                chart3.Series["series"].Points[5].AxisLabel = "Jun";//.AddY(400);

                chart3.Series["series"].Points[6].AxisLabel = "Jul";//.AddY(400);

                chart3.Series["series"].Points[7].AxisLabel = "Aug";//.AddY(400);

                chart3.Series["series"].Points[8].AxisLabel = "Sep";//.AddY(400);

                chart3.Series["series"].Points[9].AxisLabel = "Oct";//.AddY(400);

                chart3.Series["series"].Points[10].AxisLabel = "Nov";//.AddY(400);

                chart3.Series["series"].Points[11].AxisLabel = "Dec";//.AddY(400);

            }
            
        }

        protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCategory.SelectedValue == "1")
            {
                chart2.Series["series"].ChartType = SeriesChartType.Pie;
                chart2.Titles[0].Text = "Category by Sales - " + drpCategory.SelectedItem.Text + " (INR)";
             
                // Populate data into the series.
                chart2.Series["series"].Points.AddY(20000);
                chart2.Series["series"].Points[0].AxisLabel = "Admin";//.AddY(400);

                chart2.Series["series"].Points.AddY(14500);

                chart2.Series["series"].Points[1].AxisLabel = "Branch";//.AddY(400);


                chart2.Series["series"].Points.AddY(15000);
                chart2.Series["series"].Points[2].AxisLabel = "Dealer";//.AddY(400);
            }
            else if (drpCategory.SelectedValue == "2")
            {
                chart2.Series["series"].ChartType = SeriesChartType.Pie;
                chart2.Titles[0].Text = "Category by Sales - " + drpCategory.SelectedItem.Text + " (INR)";
             
                // Populate data into the series.
                chart2.Series["series"].Points.AddY(10000);
                chart2.Series["series"].Points[0].AxisLabel = "Admin";//.AddY(400);

                chart2.Series["series"].Points.AddY(12500);

                chart2.Series["series"].Points[1].AxisLabel = "Branch";//.AddY(400);


                chart2.Series["series"].Points.AddY(11000);
                chart2.Series["series"].Points[2].AxisLabel = "Dealer";//.AddY(400);
            }
            else
            {
                chart2.Series["series"].ChartType = SeriesChartType.Pie;
                // Populate data into the series.
                chart2.Series["series"].Points.AddY(40000);
                chart2.Series["series"].Points[0].AxisLabel = "Admin";//.AddY(400);

                chart2.Series["series"].Points.AddY(34500);

                chart2.Series["series"].Points[1].AxisLabel = "Branch";//.AddY(400);


                chart2.Series["series"].Points.AddY(25000);
                chart2.Series["series"].Points[2].AxisLabel = "Dealer";//.AddY(400);
            }
        }

     
    }
}