using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;


namespace Billing.Accountsbootstrap
{
    public partial class Pettygrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = objBs.selectprtty();
            gvpetty.DataSource = ds;
            gvpetty.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pettycash.aspx");
        }

        protected void gvdel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int iSucess = objBs.deletepettycash(e.CommandArgument.ToString());
                Response.Redirect("pettygrid.aspx");
            }

        }
    }
}