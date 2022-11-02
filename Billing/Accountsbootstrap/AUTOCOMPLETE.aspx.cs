using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Billing.Accountsbootstrap
{
    public partial class AUTOCOMPLETE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
        public static List<string> GetCity(string prefixText)
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["Server"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from [tblcustomer] where [customername] like @City+'%'", con);
            cmd.Parameters.AddWithValue("@City", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> CityNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CityNames.Add(dt.Rows[i]["customername"].ToString());
            }
            return CityNames;
        }
    }
}