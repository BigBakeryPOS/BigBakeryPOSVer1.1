using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Globalization;
namespace Billing.Accountsbootstrap
{
    public partial class ReturnReceiving : System.Web.UI.Page
    {

        string sTableName = ""; string Password = "";
        BSClass objbs = new BSClass();


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();



            if (!IsPostBack)
            {
                //DataSet dsret = objbs.getreturnreceiving(sTableName);
                //if (dsret.Tables[0].Rows.Count > 0)
                //{
                //    ddlretno.DataSource = dsret.Tables[0];
                //    ddlretno.DataTextField = "No";
                //    ddlretno.DataValueField = "Id";
                //    ddlretno.DataBind();
                //    ddlretno.Items.Insert(0, "Select RetNo");
                //}

                DataSet dsret = objbs.getreturnreceivingqty(sTableName);
                if (dsret.Tables[0].Rows.Count > 0)
                {
                    gvallReturns.DataSource = dsret;
                    gvallReturns.DataBind();
                }
                else
                {
                    gvallReturns.DataSource = null;
                    gvallReturns.DataBind();
                }

            }
        }

        protected void gvPurchaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "view")
            {
                DataSet ds = objbs.getreturnreceivingqtyall(sTableName, e.CommandArgument.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvReturns.DataSource = ds;
                    gvReturns.DataBind();
                }
                else
                {
                    gvReturns.DataSource = null;
                    gvReturns.DataBind();
                }

            }

        }

        protected void ddlretno_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlretno.SelectedValue == "" || ddlretno.SelectedValue == "0" || ddlretno.SelectedValue == "Select RetNo")
            {
                gvReturns.DataSource = null;
                gvReturns.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select RetNo.');", true);
                ddlretno.Focus();
                return;

            }
            else
            {
                DataSet dsret = objbs.getreturnreceivingqty(sTableName);
                if (dsret.Tables[0].Rows.Count > 0)
                {
                    gvReturns.DataSource = dsret;
                    gvReturns.DataBind();
                }
                else
                {
                    gvReturns.DataSource = null;
                    gvReturns.DataBind();
                }
            }

        }


        protected void btnsave_OnClick(object sender, EventArgs e)
        {

            for (int i = 0; i < gvReturns.Rows.Count; i++)
            {
                string Row = (i + 1).ToString();

                HiddenField hdTransRetID = (HiddenField)gvReturns.Rows[i].FindControl("hdTransRetID");
                TextBox txtqty = (TextBox)gvReturns.Rows[i].FindControl("txtqty");
                 TextBox txtmissingqty = (TextBox)gvReturns.Rows[i].FindControl("txtmissingqty");

                if (txtqty.Text == "")
                    txtqty.Text = "0";
                if (txtmissingqty.Text == "")
                    txtmissingqty.Text = "0";
                
                double AllQty=Convert.ToDouble(txtqty.Text) + Convert.ToDouble(txtmissingqty.Text);

                DataSet dsret = objbs.getreturnreceivingqtycheck(sTableName, hdTransRetID.Value, AllQty);
                if (dsret.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Qty in Row " + Row + " ');", true);
                    txtqty.Focus();
                    return;
                }
            }

            string ReceivingStatus = "Y";
            for (int i = 0; i < gvReturns.Rows.Count; i++)
            {
                HiddenField hdTransRetID = (HiddenField)gvReturns.Rows[i].FindControl("hdTransRetID");
                TextBox txtqty = (TextBox)gvReturns.Rows[i].FindControl("txtqty");
                TextBox txtmissingqty = (TextBox)gvReturns.Rows[i].FindControl("txtmissingqty");

                if (txtqty.Text == "")
                    txtqty.Text = "0";
                if (txtmissingqty.Text == "")
                    txtmissingqty.Text = "0";

                double AllQty = Convert.ToDouble(txtqty.Text) + Convert.ToDouble(txtmissingqty.Text);

                if (Convert.ToDouble(AllQty) > 0)
                {
                    int dsret = objbs.insertreturnreceivingqty(sTableName, hdTransRetID.Value, Convert.ToDouble(txtqty.Text), Convert.ToDouble(txtmissingqty.Text), ReceivingStatus);

                    if (ReceivingStatus == "Y")
                    {
                        ReceivingStatus = "N";
                    }

                }
            }

            

            Response.Redirect("ReturnReceiving.aspx");
        }




    }
}