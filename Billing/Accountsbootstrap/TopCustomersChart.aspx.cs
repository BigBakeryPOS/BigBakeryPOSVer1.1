using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace Billing.Accountsbootstrap
{
    public partial class TopCustomersChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chart1.Series["series"].ChartType = SeriesChartType.Bar;
             chart1.Series["series"].Points.AddY(35000);
            chart1.Series["series"].Points.AddY(32000);
            chart1.Series["series"].Points.AddY(30000);
            chart1.Series["series"].Points.AddY(28000);
            chart1.Series["series"].Points.AddY(27500);
            
            chart1.Series["series"].Points[0].AxisLabel = "Customer 1";//.AddY(400);

            chart1.Series["series"].Points[1].AxisLabel = "Customer 2";//.AddY(400);

            chart1.Series["series"].Points[2].AxisLabel = "Customer 3";//.AddY(400);

            chart1.Series["series"].Points[3].AxisLabel = "Customer 4";//.AddY(400);

            chart1.Series["series"].Points[4].AxisLabel = "Customer 5";//.AddY(400);



            chart2.Series["series"].ChartType = SeriesChartType.Bar;
            chart2.Series["series"].Points.AddY(35000);
            chart2.Series["series"].Points.AddY(32000);
            chart2.Series["series"].Points.AddY(30000);
            chart2.Series["series"].Points.AddY(28000);
            chart2.Series["series"].Points.AddY(27500);

            chart2.Series["series"].Points[0].AxisLabel = "Customer 1";//.AddY(400);
        
            chart2.Series["series"].Points[1].AxisLabel = "Customer 2";//.AddY(400);

            chart2.Series["series"].Points[2].AxisLabel = "Customer 3";//.AddY(400);

            chart2.Series["series"].Points[3].AxisLabel = "Customer 4";//.AddY(400);

            chart2.Series["series"].Points[4].AxisLabel = "Customer 5";//.AddY(400);

            chart3.Series["series"].ChartType = SeriesChartType.Bar;
            chart3.Series["series"].Points.AddY(35000);
            chart3.Series["series"].Points.AddY(32000);
            chart3.Series["series"].Points.AddY(30000);
            chart3.Series["series"].Points.AddY(28000);
            chart3.Series["series"].Points.AddY(27500);

            chart3.Series["series"].Points[0].AxisLabel = "Customer 1";//.AddY(400);

            chart3.Series["series"].Points[1].AxisLabel = "Customer 2";//.AddY(400);

            chart3.Series["series"].Points[2].AxisLabel = "Customer 3";//.AddY(400);

            chart3.Series["series"].Points[3].AxisLabel = "Customer 4";//.AddY(400);

            chart3.Series["series"].Points[4].AxisLabel = "Customer 5";//.AddY(400);

            chart4.Series["series"].ChartType = SeriesChartType.Bar;
            chart4.Series["series"].Points.AddY(35000);
            chart4.Series["series"].Points.AddY(32000);
            chart4.Series["series"].Points.AddY(30000);
            chart4.Series["series"].Points.AddY(28000);
            chart4.Series["series"].Points.AddY(27500);

            chart4.Series["series"].Points[0].AxisLabel = "Customer 1";//.AddY(400);
        
            chart4.Series["series"].Points[1].AxisLabel = "Customer 2";//.AddY(400);

            chart4.Series["series"].Points[2].AxisLabel = "Customer 3";//.AddY(400);

            chart4.Series["series"].Points[3].AxisLabel = "Customer 4";//.AddY(400);

            chart4.Series["series"].Points[4].AxisLabel = "Customer 5";//.AddY(400);
        }
    }
}