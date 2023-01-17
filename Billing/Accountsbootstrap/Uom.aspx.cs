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
    public partial class Uom : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string userid = string.Empty;
        int id = 0;
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"].ToString() != null)
                sTableName = Session["User"].ToString();
            else
                Response.Redirect("Login_Branch.aspx");

            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();

           
            if (!IsPostBack)
            {
                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "UOM");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "UOM");
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
                        gv.Columns[2].Visible = true;
                    }
                    else
                    {
                        gv.Columns[2].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                        gv.Columns[3].Visible = true;
                    }
                    else
                    {
                        gv.Columns[3].Visible = false;
                    }
                }


                txtuom.Text = "";
                ds = objbs.UNITS();
                gv.DataSource = ds;
                gv.DataBind();
            }


            txtuom.Focus();

        }
        protected void reset(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            ds = objbs.UNITS();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = ds;
                gv.DataBind();
            }
        }

        protected void Btn_Reset(object sender, EventArgs e)
        {
            Response.Redirect("Uom.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtuom.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Unit Of Measure');", true);
                return;
            }
            if (btnSubmit.Text == "Save")
            {
                DataSet dsCategory = objbs.Uomsrchgrid(txtuom.Text, 1);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('UOM Entered Already Exist. Create Another');", true);
                        return;


                    }
                    else
                    {
                        int iStatus = objbs.InsertUOM(txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);
                        Response.Redirect("../Accountsbootstrap/Uom.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.InsertUOM(txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);


                    //string aa = txtuom.Text.ToString().ToUpper().Substring(1);
                    //string aas = txtuom.Text.ToString().ToUpper();
                    //string asa = txtuom.Text.ToString().ToUpper();
                    //int iStatus = objbs.InsertUOM(txtuom.Text.ToString().ToUpper(), ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);

                    Response.Redirect("../Accountsbootstrap/Uom.aspx");
                }
            }
            else
            {



                DataSet dsCategory = objbs.UOMsrchgridforupdate(Convert.ToInt32(txtid.Text), txtuom.Text);
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('These UOM has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        objbs.updateUOMMaster(Convert.ToInt32(txtid.Text), txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text, txtnarration.Text);
                        Response.Redirect("Uom.aspx");
                    }
                }
                else
                {
                    int iStatus = objbs.InsertUOM(txtuom.Text, ddlIsActive.SelectedValue, "tblAuditMaster_" + sTableName, lblUserID.Text);
                    Response.Redirect("../Accountsbootstrap/Uom.aspx");
                }

            }
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
            Response.Redirect("Uom.aspx");
        }
        private void clearall()
        {
            txtuom.Text = "";
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

                    dedit = objbs.editumo(Convert.ToInt32(e.CommandArgument));
                    if (dedit.Tables[0].Rows.Count > 0)
                    {
                        txtuom.Text = dedit.Tables[0].Rows[0]["UOM"].ToString();
                        txtid.Text = dedit.Tables[0].Rows[0]["Uomid"].ToString();
                        btnSubmit.Text = "Update";
                        btnSubmit.Visible = true;
                    }

                }
            }
            else if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    objbs.deleteuom(e.CommandArgument.ToString());
                    Response.Redirect("Uom.aspx");
                }
            }



        }


    }
}