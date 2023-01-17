using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace Billing.Accountsbootstrap
{
    public partial class VariableExpenseMaster : System.Web.UI.Page
    {
        BSClass kbs = new BSClass();
        BSClass objBs = new BSClass();
        string idEdit = "";
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            idEdit = Request.QueryString.Get("ID");
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            DataSet dacess1 = objBs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "tablemaster");
            if (dacess1.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                {
                   // Response.Redirect("Login_branch.aspx"); This is alway auto log out
                }
            }
            if (!IsPostBack)
            {


                DataSet dsbranchCode = objBs.getbranch();
                if (dsbranchCode.Tables[0].Rows.Count > 0)
                {
                    drpbranch.DataSource = dsbranchCode;
                    drpbranch.DataTextField = "BranchName";
                    drpbranch.DataValueField = "branchid";
                    drpbranch.DataBind();
                    drpbranch.Items.Insert(0, "Select Branch");
                }

                if (idEdit != "")
                {
                    DataSet dget = kbs.getvaribleexpenseid(Convert.ToInt32(idEdit));
                    if (dget.Tables[0].Rows.Count > 0)
                    {

                        txtvariablename.Text = dget.Tables[0].Rows[0]["VariableName"].ToString();
                        txttotalamount.Text = dget.Tables[0].Rows[0]["TotalExpense"].ToString();
                        txtday.Text = dget.Tables[0].Rows[0]["Day"].ToString();
                        txtperdayamount.Text = dget.Tables[0].Rows[0]["PerDayExpense"].ToString();
                       // txtvariablename.Text = dget.Tables[0].Rows[0][""].ToString();
                        drpbranch.SelectedValue = dget.Tables[0].Rows[0]["Branchid"].ToString();


                       



                        btnSubmit.Text = "Update";

                       


                    }
                }
                DataSet ingrid = kbs.getvariableexpense();
                Ingredientdrid.DataSource = ingrid;
                Ingredientdrid.DataBind();

            }

        }

        protected void attender_discChnaged(object sender, EventArgs e)
        {

        }

        protected void chk_discountcnaged(object sender, EventArgs e)
        {
            
        }

        protected void Totcalcmar(object sender, EventArgs e)
        {
           
        }

        protected void Totcalc(object sender, EventArgs e)
        {
            double totalamount = 0;
            double day = 0;
            double perdayamount = 0;

            if (txttotalamount.Text == "")
            {
                txttotalamount.Text = "0";
                totalamount = 0;
            }
            else
            {
                totalamount = Convert.ToDouble(txttotalamount.Text);

            }

            if (txtday.Text == "")
            {
                txtday.Text = "0";
                day = 0;
            }
            else
            {
                day = Convert.ToDouble(txtday.Text);
            }



            txtperdayamount.Text = Convert.ToDouble(totalamount / day).ToString("F2");
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {


            if (drpbranch.SelectedValue == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Select Valid Branch Name');", true);
                return;
            }


            if (txtvariablename.Text.Trim() == "" || txtvariablename.Text.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Variable Expense Name');", true);
                return;
            }
            else if (txttotalamount.Text.Trim() == "" || txttotalamount.Text.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Amount');", true);
                return;
            }
            else if (txtday.Text.Trim() == "" || txtday.Text.Trim() == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Enter Day');", true);
                return;
            }


            string branchcode = string.Empty;

            DataSet dsbranch = objBs.getbranchid(drpbranch.SelectedValue);
            if (dsbranch.Tables[0].Rows.Count > 0)
            {
                branchcode = dsbranch.Tables[0].Rows[0]["BranchCode"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Selected Branch Not a valid Branch Please Check Active state.');", true);
                return;
            }

            if (btnSubmit.Text == "Save")
            {
                #region

                DataSet dsSalesType = kbs.searchvariableexpense(txtvariablename.Text);
                if (dsSalesType != null)
                {
                    if (dsSalesType.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Variable Expense name has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                        int insert = kbs.insert_variabelexpense(drpbranch.SelectedValue,branchcode,txtvariablename.Text,txttotalamount.Text,txtday.Text,txtperdayamount.Text);


                        Response.Redirect("../Accountsbootstrap/VariableExpenseMaster.aspx");
                    }
                }
                else
                {



                    int insert = kbs.insert_variabelexpense(drpbranch.SelectedValue, branchcode, txtvariablename.Text, txttotalamount.Text, txtday.Text, txtperdayamount.Text);


                    Response.Redirect("../Accountsbootstrap/VariableExpenseMaster.aspx");
                }
                #endregion
            }
            else
            {

             
                #region
                //DataSet dsCategory = kbs.searchIngredientforupdate(txtingre.Text, Convert.ToInt32(idEdit));
                DataSet dsCategory = kbs.searchvariableexpenseforupdate(txtvariablename.Text, Convert.ToInt32(idEdit));
                if (dsCategory != null)
                {
                    if (dsCategory.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('This Variable Expense has already Exists. please enter a new one');", true);
                        return;
                    }
                    else
                    {

                       // int idelete = objBs.Ideletetranssalestype(idEdit);


                        int update = kbs.update_varibleexpense(idEdit, drpbranch.SelectedValue, branchcode, txtvariablename.Text, txttotalamount.Text, txtday.Text, txtperdayamount.Text);


                        Response.Redirect("../Accountsbootstrap/VariableExpenseMaster.aspx");
                    }
                }
             

                #endregion
            }

        }

        protected void Ingredientdrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            idEdit = e.CommandArgument.ToString();
            Session["ID"] = e.CommandArgument.ToString();
            if (e.CommandName == "et")
            {

                Response.Redirect("VariableExpenseMaster.aspx?ID=" + e.CommandArgument.ToString());

            }
            else
            {

                int delete = kbs.deletesalestype(Convert.ToInt32(idEdit));
                Response.Redirect("VariableExpenseMaster.aspx");
            }


        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            clearall();
        }
        private void clearall()
        {

            txtvariablename.Text = "";
            txttotalamount.Text = "0";
            txtday.Text = "0";
            txtperdayamount.Text = "0";
            btnSubmit.Text = "Save";
        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataSet ingrid = kbs.getvariableexpense();
            Ingredientdrid.DataSource = ingrid;
            Ingredientdrid.DataBind();
        }

    }
}