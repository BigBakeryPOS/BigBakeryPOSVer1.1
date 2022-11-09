using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using CommonLayer;
using System.Data.SqlClient;

namespace Billing.Accountsbootstrap
{
  
    public partial class AccPage : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string ID = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

            if (!IsPostBack)
            {

                DataSet dsIngridents = objBs.getIngridentsforsup();
                if (dsIngridents.Tables[0].Rows.Count > 0)
                {
                    griditem.DataSource = dsIngridents;
                    griditem.DataBind();
                    for (int vLoop = 0; vLoop < griditem.Rows.Count; vLoop++)
                    {
                        TextBox txtRate = (TextBox)griditem.Rows[vLoop].FindControl("txtRate");
                        txtRate.Enabled = false;
                    }
                }
                divcode.Visible = false;
                DataSet dsContact = objBs.GetCustomerType();
                if (dsContact.Tables[0].Rows.Count > 0)
                {
                    ddlCustomerType.DataSource = dsContact.Tables[0];
                    ddlCustomerType.DataTextField = "ContactType";
                    ddlCustomerType.DataValueField = "ContactID";
                    ddlCustomerType.DataBind();
                    ddlCustomerType.Items.Insert(0, "Select Contact Type");
                }
                string iCusID = Request.QueryString.Get("iCusID");
                
                srch.Text = Request.QueryString.Get("id");
                if (srch.Text != "")
                    ddlCustomerType.Enabled = false;
                else
                    ddlCustomerType.Enabled = true;
                if (srch.Text == "1")
                {
                    head1.InnerHtml = "Customer Master";
                    head2.InnerHtml = "Customer Master";
                    ddlCustomerType.SelectedValue = "1";
                }
                else if (srch.Text == "2")
                {
                    head1.InnerHtml = "Dealer Master";
                    head2.InnerHtml = "Dealer Master";
                    ddlCustomerType.SelectedValue = "2";
                }
                else if (srch.Text == "3")
                {
                    head1.InnerHtml = "Supplier Master";
                    head2.InnerHtml = "Supplier Master";
                    ddlCustomerType.SelectedValue = "6";
                }
                else if (srch.Text == "4")
                {
                    head1.InnerHtml = "icing Employee Master";
                    head2.InnerHtml = "icing Employee Master"; 
                    ddlCustomerType.SelectedValue = "17";
                }
                else if (srch.Text=="5")
                {
                    head1.InnerHtml = "dispatch Employee Master";
                    head2.InnerHtml = "dispatch Employee Master"; 
                    ddlCustomerType.SelectedValue = "1017";
                }
                    DataSet branch = objBs.getbranch_prod();
                ddlbranch.DataSource = branch.Tables[0];
                ddlbranch.DataValueField = "Branchid";
                ddlbranch.DataTextField = "BranchName";
                ddlbranch.DataBind();
                ddlbranch.Items.Insert(0, "Select Branch");

                divuser.Visible = false;
                divpwd.Visible = false;
                divbranch.Visible = false;
                txtusername.Text = "";
                txtpassword.Text = "";
                ddlbranch.SelectedValue = "Select Branch";


                DataSet ds = objBs.Billno(txtcuscode.Text);

                txtcuscode.Text = ds.Tables[0].Rows[0][0].ToString();

                Change_customer();

                if (iCusID != "" || iCusID != null)
                {
                    DataSet ds1 = objBs.getcontact(iCusID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Update";
                        txtcuscode.Text = ds1.Tables[0].Rows[0]["Ledgerid"].ToString();
                        txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtmobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtphoneno.Text = ds1.Tables[0].Rows[0]["PhoneNo"].ToString();
                        txtarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                        txtpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();
                        txtemail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();
                        ddlCustomerType.SelectedValue = ds1.Tables[0].Rows[0]["ContactTypeID"].ToString();
                        ddlCustomerType.Enabled = false;
                        txtdisc.Text = ds1.Tables[0].Rows[0]["Disc"].ToString();
                        txtgstno.Text = ds1.Tables[0].Rows[0]["Gstno"].ToString();
                        txtpaymentdays.Text = ds1.Tables[0].Rows[0]["paymentdays"].ToString();


                        txtusername.Text = ds1.Tables[0].Rows[0]["UserName"].ToString();
                        txtpassword.Text = ds1.Tables[0].Rows[0]["Password"].ToString();
                        ddlbranch.SelectedValue = ds1.Tables[0].Rows[0]["BranchId"].ToString();
                        ddlCDType.SelectedValue = ds1.Tables[0].Rows[0]["Type"].ToString();

                        if (ddlCDType.SelectedValue == "Credit Note")
                        {
                            txtOBalance.Text = ds1.Tables[0].Rows[0]["Open_Credit"].ToString();
                        }
                        else
                        {
                            txtOBalance.Text = ds1.Tables[0].Rows[0]["Open_Depit"].ToString();
                        }

                        if (ddlCustomerType.SelectedValue == "6")
                        {
                            DataSet dssup = objBs.getIngridentsforsup();
                            if (dssup.Tables[0].Rows.Count > 0)
                            {
                                griditem.DataSource = dssup;
                                griditem.DataBind();

                                for (int vLoop = 0; vLoop < griditem.Rows.Count; vLoop++)
                                {
                                    TextBox txtRate = (TextBox)griditem.Rows[vLoop].FindControl("txtRate");
                                    txtRate.Visible = false;

                                    //  TextBox txtitemprintname = (TextBox)griditem.Rows[j].FindControl("txtitemprintname");
                                }


                                Ingredient.Visible = true;
                                paymentdays.Visible = true;
                            }
                        }

                        else if (ddlCustomerType.SelectedValue == "1")
                        {
                            disc.Visible = true;
                            txtdisc.Focus();
                        }
                        else if (ddlCustomerType.SelectedValue == "2")
                        {
                            DataSet ds2 = objBs.getIngridentsfordealer();
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                griditem.DataSource = ds2;
                                griditem.DataBind();

                                Ingredient.Visible = true;
                                paymentdays.Visible = true;
                            }
                        }

                        else if (ddlCustomerType.SelectedValue == "17")
                        {
                            divuser.Visible = true;
                            divpwd.Visible = true;
                            divbranch.Visible = true;

                        }
                        else
                        {
                            Ingredient.Visible = false;
                            paymentdays.Visible = false;

                        }

                        DataSet dsLedgerIngredient = objBs.GetLedgerIngredient(Convert.ToInt32(ds1.Tables[0].Rows[0]["Ledgerid"].ToString()));
                        if (dsLedgerIngredient.Tables[0].Rows.Count > 0)
                        {
                            //for (int i = 0; i < dsLedgerIngredient.Tables[0].Rows.Count; i++)
                            //{
                            //    chkIngredient.Items.FindByValue(dsLedgerIngredient.Tables[0].Rows[i]["IngredientId"].ToString()).Selected = true;
                            //}
                            {
                                //Select the checkboxlist items those values are true in database
                                //Loop through the DataTable
                                //for (int i = 0; i <= dtranscat.Tables[0].Rows.Count - 1; i++)
                                {

                                    {
                                        //Find the checkbox list items using FindByValue and select it.
                                        // chkcategory.Items.FindByValue(dtranscat.Tables[0].Rows[i]["categoryid"].ToString()).Selected = true;
                                        for (int j = 0; j < griditem.Rows.Count; j++)
                                        {
                                            Label lblitemid = (Label)griditem.Rows[j].FindControl("lblitemid");
                                            for (int vLoop = 0; vLoop < dsLedgerIngredient.Tables[0].Rows.Count; vLoop++)
                                            {

                                                string itemid = dsLedgerIngredient.Tables[0].Rows[vLoop]["IngredientId"].ToString();
                                                string purchasename = dsLedgerIngredient.Tables[0].Rows[vLoop]["BIngredientName"].ToString();

                                                string rate = dsLedgerIngredient.Tables[0].Rows[vLoop]["Rate"].ToString();

                                                if (lblitemid.Text == itemid)
                                                {
                                                    //Label lblcatname = (Label)gridcat.Rows[vLoop].FindControl("lblcatname");
                                                    CheckBox chkitem = (CheckBox)griditem.Rows[j].FindControl("chkitem");
                                                    chkitem.Checked = true;
                                                    chkitem.Enabled = false;
                                                    TextBox txtitemprintname = (TextBox)griditem.Rows[j].FindControl("txtitemprintname");
                                                    txtitemprintname.Text = (purchasename).ToString();

                                                    TextBox txtrate = (TextBox)griditem.Rows[j].FindControl("txtRate");
                                                    txtrate.Text = (rate).ToString();

                                                }

                                            }
                                        }

                                    }

                                }
                            }
                        }

                    }

                }
            }

        }
        protected void customertype_chnaged(object sender, EventArgs e)
        {
            Change_customer();
        }


        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (ddlCustomerType.SelectedValue == "6")
            {
                griditem.Columns[3].Visible = false;
                griditem.Columns[2].Visible = true;
            }
            else if (ddlCustomerType.SelectedValue == "2")
            {
                griditem.Columns[2].Visible = false;
                griditem.Columns[3].Visible = true;
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {

            string Mode = Request.QueryString.Get("Mode");
            string MasterType = Request.QueryString.Get("MasterType");

            if (btnadd.Text == "Save")
            {

                #region CHEck GST Number

                if (txtgstno.Text == "Nil")
                {
                }
                else
                {
                    DataSet dgstcheck = objBs.duplicatecheckcustomercheck("Gstno", txtgstno.Text);
                    if (dgstcheck.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Gst No Already Exists.Thank you!!!.');", true);
                        return;
                    }
                }

                // CHECK CONTACT NAME
                string str = txtcustomername.Text.Replace(" ", String.Empty);
                DataSet dchkcontactname = objBs.chkconatctname(str);
                if (dchkcontactname.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Supplier Name Already Exists.Thank you!!!.');", true);
                    return;
                }

                if (ddlCustomerType.SelectedValue == "17")
                {
                    if (txtusername.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Enter Username.Thank you!!!.');", true);
                        return;
                    }
                    else if (txtpassword.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Enter Password.Thank you!!!.');", true);
                        return;
                    }
                    else if ((ddlbranch.SelectedValue == "0") || (ddlbranch.SelectedValue == "Select Branch"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Select Branch.Thank you!!!.');", true);
                        return;
                    }

                    // CHECK User NAME of icing
                    if (ddlCustomerType.SelectedValue == "17")
                    {
                        str = txtusername.Text.Replace(" ", String.Empty);
                        dchkcontactname = objBs.chkEmployeeUsername(str);
                        if (dchkcontactname.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('UserName Already Exists.Thank you!!!.');", true);
                            return;
                        }
                    }
                }
                #endregion

                DataSet ds = objBs.chkinsertcontact(txtemail.Text, txtmobileno.Text);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    lblerror.Text = "Email id or Mobile Number  already exists";
                    return;
                }
                else
                {
                    int GroupId = 0; string custype = "";

                    if (ddlCustomerType.SelectedValue == "1") // For Customer
                    {
                        GroupId = 1;
                        custype = "R";
                    }
                    else if (ddlCustomerType.SelectedValue == "2")//For Dealer
                    {
                        GroupId = 1;
                        custype = "F";
                    }
                    else if (ddlCustomerType.SelectedValue == "3")//For Manufacturer
                    {
                        GroupId = 1;
                        custype = "M";
                    }
                    else if (ddlCustomerType.SelectedValue == "5")//For Franchise
                    {
                        GroupId = 1;
                        custype = "Fr";
                    }
                    else if (ddlCustomerType.SelectedValue == "6") //For Supplier
                    {
                        GroupId = 2;
                        custype = "R";
                    }
                    else if (ddlCustomerType.SelectedValue == "16")//For Icing employee
                    {
                        GroupId = 1;
                        custype = "R";
                    }

                    else if (ddlCustomerType.SelectedValue == "17")//For Icing employee
                    {
                        GroupId = 1;
                        custype = "R";
                    }

                    else if (ddlCustomerType.SelectedValue == "1017")//For Icing employee
                    {
                        GroupId = 1;
                        custype = "R";
                    }

                    int branchid;
                    if (ddlbranch.SelectedValue == "Select Branch")
                        branchid = 0;
                    else
                        branchid = Convert.ToInt32(ddlbranch.SelectedValue);

                    int LedgerId;
                    if (ddlCDType.SelectedValue == "Credit Note")
                    {
                        string Credite = txtOBalance.Text;
                        LedgerId = objBs.insertcontact(Convert.ToInt32(lblUserID.Text), txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(ddlCustomerType.SelectedValue), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, txtusername.Text, txtpassword.Text, branchid, Convert.ToDouble(Credite), Convert.ToDouble("0"), ddlCDType.SelectedValue);
                    }
                    else
                    {
                        string Debit = txtOBalance.Text;
                        LedgerId = objBs.insertcontact(Convert.ToInt32(lblUserID.Text), txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(ddlCustomerType.SelectedValue), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, txtusername.Text, txtpassword.Text, branchid, Convert.ToDouble("0"), Convert.ToDouble(Debit), ddlCDType.SelectedValue);
                    }
                    for (int ii = 0; ii < griditem.Rows.Count; ii++)
                    {
                        Label lblitemid = (Label)griditem.Rows[ii].FindControl("lblitemid");
                        CheckBox chkitem = (CheckBox)griditem.Rows[ii].FindControl("chkitem");
                        if (chkitem.Checked == true)
                        {
                            Label lblitemname = (Label)griditem.Rows[ii].FindControl("lblitemname");

                            TextBox txtitemprintname = (TextBox)griditem.Rows[ii].FindControl("txtitemprintname");
                            if (txtitemprintname.Text == "")
                            {
                                txtitemprintname.Text = "----";
                            }

                            TextBox txtRate = (TextBox)griditem.Rows[ii].FindControl("txtRate");
                            if (txtRate.Text == "")
                            {
                                txtRate.Text = "0";
                            }

                            if (ddlCustomerType.SelectedValue == "6")
                            {
                                int LedgerIngredient = objBs.InsertLedgerIngredient1(LedgerId, Convert.ToInt32(lblitemid.Text), txtitemprintname.Text, custype, Convert.ToDecimal(txtRate.Text));
                            }
                            else
                            {
                                int LedgerIngredient1 = objBs.InsertLedgerIngredient1(LedgerId, Convert.ToInt32(lblitemid.Text), lblitemname.Text, custype, Convert.ToDecimal(txtRate.Text));
                            }
                        }
                    }





                }

            }
            else
            {
                DataSet dsmbl = objBs.chkupdatecustomer(txtemail.Text, txtmobileno.Text, txtcuscode.Text);
                if (dsmbl.Tables[0].Rows.Count != 0)
                {

                    lblerror.Text = "Email id or Mobile Number  already exists";

                    return;
                }
                else if (ddlCustomerType.SelectedValue == "17")
                {
                    if (txtusername.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Enter Username.Thank you!!!.');", true);
                        return;
                    }
                    else if (txtpassword.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Enter Password.Thank you!!!.');", true);
                        return;
                    }
                    else if ((ddlbranch.SelectedValue == "0") || (ddlbranch.SelectedValue == "Select Branch"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Select Branch.Thank you!!!.');", true);
                        return;
                    }




                }
                // CHECK User NAME
                string str = txtusername.Text.Replace(" ", String.Empty);
                if (ddlCustomerType.SelectedValue == "17")
                {
                    DataSet dchkcontactname = objBs.chkEmployeeUsername_Edit(str, txtcuscode.Text);
                    if (dchkcontactname.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('UserName Already Exists.Thank you!!!.');", true);
                        return;
                    }
                }
                int GroupId = 0; string custype = "";
                if (ddlCustomerType.SelectedValue == "1") // For Customer
                {
                    GroupId = 1;
                    custype = "R";
                }
                else if (ddlCustomerType.SelectedValue == "2")//For Dealer
                {
                    GroupId = 1;
                    custype = "F";
                }
                else if (ddlCustomerType.SelectedValue == "3")//For Manufacturer
                {
                    GroupId = 1;
                    custype = "M";
                }
                else if (ddlCustomerType.SelectedValue == "5")//For Franchise
                {
                    GroupId = 1;
                    custype = "Fr";
                }
                else if (ddlCustomerType.SelectedValue == "6") //For Supplier
                {
                    GroupId = 2;
                    custype = "R";
                }
                else if (ddlCustomerType.SelectedValue == "16")//For Icing employee
                {
                    GroupId = 1;
                    custype = "R";
                }
                else if (ddlCustomerType.SelectedValue == "17")//For Icing employee
                {
                    GroupId = 1;
                    custype = "R";
                }
                else if (ddlCustomerType.SelectedValue == "1017")//For Icing employee
                {
                    GroupId = 1;
                    custype = "R";
                }
                int branchid;
                if (ddlbranch.SelectedValue == "Select Branch")
                    branchid = 0;
                else
                    branchid = Convert.ToInt32(ddlbranch.SelectedValue);
                int iStatus = 0;
                if (ddlCDType.SelectedValue == "Credit Note")
                {
                    string Credite = txtOBalance.Text;
                    iStatus = objBs.updatecontact(txtcuscode.Text, txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(ddlCustomerType.SelectedValue), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, txtusername.Text, txtpassword.Text, branchid, Convert.ToDouble(Credite), Convert.ToDouble("0"), ddlCDType.SelectedValue);
                }
                else
                {
                    string Debit = txtOBalance.Text;
                    iStatus = objBs.updatecontact(txtcuscode.Text, txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(ddlCustomerType.SelectedValue), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, txtusername.Text, txtpassword.Text, branchid, Convert.ToDouble("0"), Convert.ToDouble(Debit), ddlCDType.SelectedValue);
                }

                for (int ii = 0; ii < griditem.Rows.Count; ii++)
                {
                    Label lblitemid = (Label)griditem.Rows[ii].FindControl("lblitemid");
                    CheckBox chkitem = (CheckBox)griditem.Rows[ii].FindControl("chkitem");
                    if (chkitem.Checked == true)
                    {
                        Label lblitemname = (Label)griditem.Rows[ii].FindControl("lblitemname");

                        TextBox txtitemprintname = (TextBox)griditem.Rows[ii].FindControl("txtitemprintname");
                        if (txtitemprintname.Text == "")
                        {
                            txtitemprintname.Text = "----";
                        }


                        TextBox txtrate = (TextBox)griditem.Rows[ii].FindControl("txtRate");
                        if (txtrate.Text == "")
                        {
                            txtrate.Text = "0";
                        }


                        if (ddlCustomerType.SelectedValue == "6")
                        {
                            int LedgerIngredient = objBs.InsertLedgerIngredient1(Convert.ToInt32(txtcuscode.Text), Convert.ToInt32(lblitemid.Text), txtitemprintname.Text, custype, Convert.ToDecimal(txtrate.Text));

                        }
                        else
                        {
                            int LedgerIngredient = objBs.InsertLedgerIngredient1(Convert.ToInt32(txtcuscode.Text), Convert.ToInt32(lblitemid.Text), lblitemname.Text, custype, Convert.ToDecimal(txtrate.Text));

                        }


                    }
                }

            }
            if (MasterType == "Employee")
                {
                    Response.Redirect("../Accountsbootstrap/EmployeeMaster.aspx");
                }
                else
                {
                    Response.Redirect("../Accountsbootstrap/viewcustomer.aspx?id=" + srch.Text);
                }
          
        }
            public void Change_customer()
        {
            disc.Visible = false;
            if (ddlCustomerType.SelectedValue == "1")  
            {
                disc.Visible = true;
                txtdisc.Focus();
            }
            //else
            //{
            //    disc.Visible = false;
            //    txtpincode.Focus();
            //}

            else if (ddlCustomerType.SelectedValue == "6")
            {
                DataSet dsIngridents = objBs.getIngridentsforsup();
                if (dsIngridents.Tables[0].Rows.Count > 0)
                {
                    griditem.DataSource = dsIngridents;
                    griditem.DataBind();
                }
                for (int vLoop = 0; vLoop < griditem.Rows.Count; vLoop++)
                {
                    TextBox txtRate = (TextBox)griditem.Rows[vLoop].FindControl("txtRate");
                    txtRate.Visible = false;

                    TextBox txtitemprintname = (TextBox)griditem.Rows[vLoop].FindControl("txtitemprintname");
                    txtitemprintname.Visible = true;
                }
                Ingredient.Visible = true;
                paymentdays.Visible = true;
                // chkIngredient.Focus();
            }
            //else
            //{
            //    Ingredient.Visible = false;
            //    paymentdays.Visible = false;
            //    txtpaymentdays.Text = "0";
            //  //  chkIngredient.Focus();
            //}

            else if (ddlCustomerType.SelectedValue == "2")
            {
                DataSet dsIngridents = objBs.getIngridentsfordealer();
                if (dsIngridents.Tables[0].Rows.Count > 0)
                {
                    griditem.DataSource = dsIngridents;
                    griditem.DataBind();
                }
                for (int vLoop = 0; vLoop < griditem.Rows.Count; vLoop++)
                {
                    TextBox txtitemprintname = (TextBox)griditem.Rows[vLoop].FindControl("txtitemprintname");
                    txtitemprintname.Visible = false;
                }
                Ingredient.Visible = true;
                paymentdays.Visible = true;
            }

            else
            {
                Ingredient.Visible = false;
                paymentdays.Visible = false;
                txtpaymentdays.Text = "0";
            }

            if (ddlCustomerType.SelectedValue == "17")
            {
                divuser.Visible = true;
                divpwd.Visible = true;
                divbranch.Visible = true;
            }
            else
            {
                divuser.Visible = false;
                divpwd.Visible = false;
                divbranch.Visible = false;
                txtusername.Text = "";
                txtpassword.Text = "";
                ddlbranch.SelectedValue = "Select Branch";
            }


        }
        protected void Exit_Click(object sender, EventArgs e)
        {
            string MasterType = Request.QueryString.Get("MasterType");
            if (MasterType == "Employee")
            {
                Response.Redirect("../Accountsbootstrap/EmployeeMaster.aspx");
            }
            else
            {
                Response.Redirect("../Accountsbootstrap/viewcustomer.aspx?id=" + srch.Text);
            }
        }
    }
}