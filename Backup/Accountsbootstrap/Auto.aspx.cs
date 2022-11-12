using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLayer;
using System.Data;
namespace Billing.Accountsbootstrap
{
    public partial class Auto : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                DataSet ds = objBs.selectcategorymaster();
                cboCountry.DataSource = ds.Tables[0];
                cboCountry.DataTextField = "Category";
                cboCountry.DataValueField = "CatID";
                cboCountry.DataBind();
                cboCountry.Focus();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {


            lblSelectedValue.Text = cboCountry.SelectedValue;

        }

        protected void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet dsCategory = objBs.selectcategorydecription(Convert.ToInt32(cboCountry.SelectedValue), "");
            ddlItems.DataSource = dsCategory.Tables[0];
            ddlItems.DataTextField = "Definition";
            ddlItems.DataValueField = "categoryuserid";
            ddlItems.DataBind();

            ddlItems.Focus();
        }
    }
}