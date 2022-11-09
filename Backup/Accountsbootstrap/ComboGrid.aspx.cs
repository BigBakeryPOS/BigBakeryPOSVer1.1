using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class ComboGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataSet ds = objbs.getcomboproduct();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Combo.aspx");
        }

        protected void gridview_rowcommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("combo.aspx?icomboid=" + e.CommandArgument.ToString());
            }
        }

       
    }
}