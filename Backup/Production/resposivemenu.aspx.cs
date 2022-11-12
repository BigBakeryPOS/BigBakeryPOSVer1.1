using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bakery
{
    public partial class resposivemenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int selDate = Calendar1.SelectedDate.Day;
            //DateTime dt = Calendar1.SelectedDate.AddDays(-selDate);
            //int numOfDays = DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month);

            //DataTable dtMonthDetails = new DataTable("month");
            //DataColumn dcDate = new DataColumn("date");
            //DataColumn dcDay = new DataColumn("day");
            //dtMonthDetails.Columns.Add(dcDate);
            //dtMonthDetails.Columns.Add(dcDay);

            //DataRow dr = null;

            //for (int i = 1; i <= numOfDays; i++)
            //{
            //    dr = dtMonthDetails.NewRow();
            //    dr["date"] = i;
            //    string str = Calendar1.SelectedDate.ToShortDateString();
            //    dr["day"] = dt.AddDays(i).DayOfWeek.ToString();
            //    dtMonthDetails.Rows.Add(dr);
            //        }

            //        GridView1.DataSource = dtMonthDetails;
            //        GridView1.DataBind();
            //    }
            //}
        }
    }
}