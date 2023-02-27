using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Billing.Accountsbootstrap
{
    public partial class CurrencyMaster : System.Web.UI.Page
    {

        BSClass objBs = new BSClass();

        string sTableName = "";
        string IsSuperAdmin = "";
        string defaultcurrency = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
                sTableName = Session["User"].ToString();
            else
                Response.Redirect("login.aspx");

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();

            IsSuperAdmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            defaultcurrency = Request.Cookies["userInfo"]["defaultcurrency"].ToString();

            


            if (!IsPostBack)
            {
                DataSet ds = objBs.gridCurrency();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                {
                    gridview.DataSource = null;
                    gridview.DataBind();
                }


                if(IsSuperAdmin != "0")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Currency Master.Thank You!!!.')", true);
                    Button1.Enabled = false;
                    return;
                }
                else
                {
                    DataSet getdefaultcur = objBs.getidefaultCurrencyvalues(defaultcurrency);
                    if (getdefaultcur.Tables[0].Rows.Count > 0)
                    {
                        string curname = getdefaultcur.Tables[0].Rows[0]["CurrencyName"].ToString();
                        string curvalue = getdefaultcur.Tables[0].Rows[0]["value"].ToString();


                        string fullvalu = curname + " - " + curvalue;
                        lbldefaultcurrencyname.Text = fullvalu;
                        lbldefaultcurrencyid.Text = getdefaultcur.Tables[0].Rows[0]["DefaultCurrencyid"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Add Currency Master.Kindly Set Default currency.Thank You!!!.')", true);
                        Button1.Enabled = false;
                        return;
                    }

                }


            }
        }

        protected void gvCurrencyDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CurrencyHistory")
            {
                mpecost.Show();
                DataSet dsView = objBs.getCurrencyHistory(e.CommandArgument.ToString());
                if (dsView.Tables[0].Rows.Count > 0)
                {
                    gvCurrencyDetails.DataSource = dsView;
                    gvCurrencyDetails.DataBind();
                }
                else
                {
                    gvCurrencyDetails.DataSource = null;
                    gvCurrencyDetails.DataBind();
                }
            }
        }

        protected void gridview_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            lblName.Text = "Update Currency";

            if (gridview.SelectedDataKey.Value != null && gridview.SelectedDataKey.Value.ToString() != "")
            {
                string id = gridview.SelectedDataKey.Value.ToString();

                DataSet ds = objBs.getiCurrencyvalues(id);
                if (ds.Tables[0].Rows.Count > 0)

                    txtCurrencyID.Text = ds.Tables[0].Rows[0]["CurrencyID"].ToString();

                txtCurrency.Text = ds.Tables[0].Rows[0]["CurrencyName"].ToString();
                txtCurrency.Enabled = false;
                txtValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();

                ddlIsActive.SelectedValue = ds.Tables[0].Rows[0]["IsActive"].ToString();

                lbldefaultcurrencyid.Text = ds.Tables[0].Rows[0]["defaultcurrencyid"].ToString();

                DataSet getdefaultcur = objBs.getidefaultCurrencyvalues(lbldefaultcurrencyid.Text);
                if (getdefaultcur.Tables[0].Rows.Count > 0)
                {
                    string curname = getdefaultcur.Tables[0].Rows[0]["CurrencyName"].ToString();
                    string curvalue = getdefaultcur.Tables[0].Rows[0]["value"].ToString();


                    string fullvalu = curname + " - " + curvalue;
                    lbldefaultcurrencyname.Text = fullvalu;
                    lbldefaultcurrencyid.Text = getdefaultcur.Tables[0].Rows[0]["DefaultCurrencyid"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Not Allow To Add Currency Master.Kindly Set Default currency.Thank You!!!.')", true);
                    Button1.Enabled = false;
                    return;
                }

                Button1.Text = "Update";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtValue.Text == "")
                txtValue.Text = "0";

            if(lbldefaultcurrencyid.Text == "0")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Default Currency Not Set.Please Check the Value.')", true);
                return;
            }

            if (Convert.ToDouble(txtValue.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Check the Value.')", true);
                txtValue.Focus();
                return;
            }

            if (Button1.Text == "Save")
            {
                DataSet dsCurrency = objBs.Currencysrchgrid(txtCurrency.Text, 0);
                if (dsCurrency.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('This CurrencyName was already Exists.')", true);
                    txtCurrency.Focus();
                    return;
                }
                else
                {
                    int iStatus = objBs.InsertCurrency(txtCurrency.Text, Convert.ToDouble(txtValue.Text), ddlIsActive.SelectedValue, Button1.Text,lbldefaultcurrencyid.Text);
                    Response.Redirect("CurrencyMaster.aspx");
                }
            }
            else
            {
                DataSet dsCurrency = objBs.Currencysrchgrid(txtCurrency.Text, Convert.ToInt32(txtCurrencyID.Text));
                if (dsCurrency.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('This CurrencyName was already Exists.')", true);
                    txtCurrency.Focus();
                    return;
                }
                else
                {
                    int iStatus = objBs.updateCurrencyMaster(txtCurrency.Text, Convert.ToDouble(txtValue.Text), ddlIsActive.SelectedValue, Button1.Text, Convert.ToInt32(txtCurrencyID.Text),lbldefaultcurrencyid.Text);
                    Response.Redirect("CurrencyMaster.aspx");
                }

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtCurrencyID.Text = "";

            txtCurrency.Text = "";
            txtValue.Text = "";

            ddlIsActive.ClearSelection();

            Button1.Text = "Save";
            lblName.Text = "Add Currency";
        }
        protected void btnresret_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CurrencyMaster.aspx");
        }

    }
}
