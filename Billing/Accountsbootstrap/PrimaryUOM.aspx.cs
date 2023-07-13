using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;

namespace Billing.Accountsbootstrap
{
    public partial class PrimaryUOM : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;
        int id = 0;
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userInfo"]["User"].ToString() != null)
                sTableName = Request.Cookies["userInfo"]["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();


            if (!IsPostBack)
            {

                txtuom.Text = "";

                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "PrimaryUOMmaster");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "PrimaryUOMmaster");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        gv.Columns[3].Visible = true;
                    }
                    else
                    {
                        gv.Columns[3].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gv.Columns[4].Visible = true;
                    }
                    else
                    {
                        gv.Columns[4].Visible = false;
                    }
                }


                ds = objbs.GridPrimaryUNITS();
                gv.DataSource = ds;
                gv.DataBind();

            }


            txtuom.Focus();

        }
        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.GridPrimaryUNITS();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("PrimaryUom.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtuom.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Unit Of Measure.Thank You!!!');", true);
                return;
            }
            if (txtvalue.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Value.Thank You!!!');", true);
                return;
            }
            if (btnSubmit.Text == "Save")
            {
                DataSet dsCategory = objbs.PrimaryUomsrchgrid(txtuom.Text, 1);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These UOM has already Exists. please enter a new one');", true);
                        return;


                    }
                    else
                    {
                        int iStatus = objbs.Insert_PrimaryUOM(txtuom.Text,txtvalue.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);
                        Response.Redirect("../Accountsbootstrap/PrimaryUom.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.Insert_PrimaryUOM(txtuom.Text,txtvalue.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);


                    //string aa = txtuom.Text.ToString().ToUpper().Substring(1);
                    //string aas = txtuom.Text.ToString().ToUpper();
                    //string asa = txtuom.Text.ToString().ToUpper();
                    //int iStatus = objbs.InsertUOM(txtuom.Text.ToString().ToUpper(), ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);

                    Response.Redirect("../Accountsbootstrap/PrimaryUom.aspx");
                }
            }
            else
            {



                DataSet dsCategory = objbs.Primary_UOMsrchgridforupdate(Convert.ToInt32(txtid.Text), txtuom.Text);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These UOM has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        objbs.updatePrimary_UOMMaster(Convert.ToInt32(txtid.Text), txtvalue.Text, txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text, txtnarration.Text);
                        Response.Redirect("PrimaryUom.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.Insert_PrimaryUOM(txtuom.Text, txtvalue.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);
                    Response.Redirect("../Accountsbootstrap/PrimaryUom.aspx");
                }

            }





        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {
            txtuom.Text = "";
            txtvalue.Text = "0";
            ddlIsActive.ClearSelection();
            btnSubmit.Text = "Save";
            txtuom.Focus();

        }

        protected void edit(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    DataSet dedit = new DataSet();

                    dedit = objbs.editPrimaryumo(Convert.ToInt32(e.CommandArgument));
                    if (dedit.Tables[0].Rows.Count > 0)
                    {

                        txtvalue.Text = dedit.Tables[0].Rows[0]["PrimaryValue"].ToString();
                        txtuom.Text = dedit.Tables[0].Rows[0]["PrimaryName"].ToString();
                        txtid.Text = dedit.Tables[0].Rows[0]["PrimaryUomid"].ToString();
                        btnSubmit.Text = "Update";
                        btnSubmit.Visible = true;
                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objbs.delete_primaryuom(e.CommandArgument.ToString());
                    Response.Redirect("PrimaryUom.aspx");
                }
            }



        }


    }
}