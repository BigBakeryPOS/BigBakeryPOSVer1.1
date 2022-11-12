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
    public partial class Waiter : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string cust = "";
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();
            sTableName = Session["User"].ToString();

            if (!IsPostBack)
            {
                DataSet ds = objBs.ListofWaiters();
                gvs.DataSource = ds.Tables[0];
                gvs.DataBind     ();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                objBs.Insertworker(txtname.Text, ddlRole.SelectedItem.Text, ddlLocation.SelectedValue, txtcode.Text);
            }
            else
            {
                int id = Convert.ToInt32(Session["employeeid"].ToString());
                objBs.updateworker(txtname.Text, ddlRole.SelectedItem.Text, ddlLocation.SelectedValue, txtcode.Text, id);
            }
            txtname.Text = "";
            txtcode.Text = "";
           
            DataSet ds = objBs.ListofWaiters();
            gvs.DataSource = ds.Tables[0];
            gvs.DataBind();
        }

        protected void gvs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RM")
            {
                objBs.Deleteworker(Convert.ToInt32(e.CommandArgument.ToString()));
                DataSet ds = objBs.ListofWaiters();
                gvs.DataSource = ds.Tables[0];
                gvs.DataBind();
            }
            else
            {
                DataSet ds = objBs.SelectBiller(Convert.ToInt32(e.CommandArgument.ToString()));

                Session["employeeid"] = e.CommandArgument.ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtcode.Text = ds.Tables[0].Rows[0]["code"].ToString();
                    ddlRole.Text = ds.Tables[0].Rows[0]["Role"].ToString();
                    ddlLocation.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                    btnsave.Text = "Update";
                }
            }
        }
    }
}