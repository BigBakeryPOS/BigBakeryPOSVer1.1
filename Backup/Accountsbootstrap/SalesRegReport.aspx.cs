using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;

namespace Billing.Accountsbootstrap
{
    public partial class SalesRegReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string FirstEntry = "";
        string Label123 = "";
        string AllBranchAccess = "0";


        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();


            if (!IsPostBack)
            {

                txtfrmdate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy/MM/dd");
                txttodate.Text = DateTime.Now.ToString("yyyy/MM/dd");

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objBs.GetBranch_New("All");
                else
                    dsbranch = objBs.GetBranch_New(sTableName);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "Select Branch");
                else
                    ddlBranch.Enabled = false;

                DataSet dsCategory = objBs.selectcategorymaster();
                if (dsCategory.Tables[0].Rows.Count > 0)
                {


                }

                //////gvgrnmp.DataSource = null;
                //////gvgrnmp.DataBind();
                //////gvreturn.DataSource = null;
                //////gvreturn.DataBind();


            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {

            if (ddlBranch.SelectedValue == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Select Branch.');", true);
                return;
            }

            //if (sTableName == "CO1")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO2")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO3")
            //{
            //    Label123 = "Shiva Delights";
            //}
            //else if (sTableName == "CO4")
            //{
            //    Label123 = "Fig and honey";
            //}
            //else if (sTableName == "CO5")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}

            //else if (sTableName == "CO6")
            //{
            //    Label123 = "Maduravayol";
            //}

            //else if (sTableName == "CO6")
            //{
            //    Label123 = "purasavakkam";
            //}


            //else if (sTableName == "CO8")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO9")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO10")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            //else if (sTableName == "CO11")
            //{
            //    Label123 = "Blaack Forest Bakery Services";
            //}
            lblstkreturn.Text = Label123 + " Sales Register Report Generated For "+ddlBranch.SelectedValue+"   From " + txtfrmdate.Text + " To " + txttodate.Text + " On " + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");



            DataSet ds = new DataSet();
            ds = objBs.selectsalearegrep(ddlBranch.SelectedValue,txtfrmdate.Text, txttodate.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCustsales.DataSource = ds;
                gvCustsales.DataBind();
            }

            else
            {
                gvCustsales.DataSource = null;
                gvCustsales.DataBind();
            }

        }

        protected void gvCustsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Change")
            {
                // div.Visible = true;
                ViewState["ID"] = e.CommandArgument.ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), "Display", "Diaplay();", true);

                //////DataSet ds = objbs.getNo(sTableName, Convert.ToInt32(ViewState["ID"].ToString()));
                //////drpPayment.SelectedValue = ds.Tables[0].Rows[0]["iPaymode"].ToString();


            }
        }


        protected void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    DataSet ds = objBs.selectsalearegrepitems(txtfrmdate.Text, txttodate.Text, ddlBranch.SelectedValue, groupID);
                   
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]);
                      //////  amount1 = amount1 + amount;
                        gv.DataBind();
                    }
                    
                }

            }



        }
    }
}
