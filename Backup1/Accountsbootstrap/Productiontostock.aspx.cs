using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class Productiontostock : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();


            DataSet dGateaux = objbs.getItems(6, sCode);
            gvGateaux.DataSource = dGateaux;
            gvGateaux.DataBind();

            //snacks
            DataSet dSnacks = objbs.getItems(10, sCode);
            gvSnacks.DataSource = dSnacks;
            gvSnacks.DataBind();

            DataSet dPuddings = objbs.getItems(9, sCode);
            gvPuddings.DataSource = dPuddings;
            gvPuddings.DataBind();

            //Beverages
            DataSet dBev = objbs.getItems(3, sCode);
            gvBeverages.DataSource = dBev;
            gvBeverages.DataBind();

            
        }
    }
}