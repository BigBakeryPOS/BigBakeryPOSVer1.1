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
    public partial class updatecategory : System.Web.UI.Page
    {
        DataSet tbllogin = new DataSet();
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnadd.Attributes.Add("onclick", "return valchk();"); // Validation Check lines
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();

            if (!IsPostBack)
            {
                string cust = Request.QueryString.Get("cust");
                if (cust != "" || cust != null)
                {
                    DataSet ds = objBs.getvalues(cust);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlcategory.Text = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                        txtdescription.Text = ds.Tables[0].Rows[0]["Definition"].ToString();
                    }
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DescriptionGrid.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //objBs.updatedefinition(txtdescription.Text, ddlcategory.Text);
            Response.Redirect("DescriptionGrid.aspx");
        }
    }
}