using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class DealetsalesGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet dd = objBs.Dealerbillgrid();
                gvsales.DataSource = dd.Tables[0];
                gvsales.DataBind();
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DealerBilling.aspx");
        }

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "print")
            {
                int billno = Convert.ToInt32(e.CommandArgument.ToString());

                string URL = "AmmaNana.aspx?BillNo=" + billno;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + URL + "');", true);
            }

            else

            {
                
                int billno = Convert.ToInt32(e.CommandArgument.ToString());

                string URL = "AmmaNana.aspx?BillNo=" + billno;
                System.Web.UI.AttributeCollection aCol = visit.Attributes;
                aCol.Add("src", URL);
            }
        }
    }
}