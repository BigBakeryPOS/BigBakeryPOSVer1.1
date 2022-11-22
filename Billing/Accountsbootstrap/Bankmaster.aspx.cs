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


namespace Billing.Accountsbootstrap
{
    public partial class Bankmaster : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
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
                }


                divcode.Visible = false;
                //DataSet dsContact = objBs.GetCustomerType();
                //if (dsContact.Tables[0].Rows.Count > 0)
                //{
                //    ddlCustomerType.DataSource = dsContact.Tables[0];
                //    ddlCustomerType.DataTextField = "ContactType";
                //    ddlCustomerType.DataValueField = "ContactID";
                //    ddlCustomerType.DataBind();
                //    ddlCustomerType.Items.Insert(0, "Select Contact Type");
                //}

                //DataSet ds = objBs.Billno(txtcuscode.Text);

                //txtcuscode.Text = ds.Tables[0].Rows[0][0].ToString();


                string iCusID = Request.QueryString.Get("iCusID");
                if (iCusID != "" || iCusID != null)
                {
                    DataSet ds1 = objBs.getBank(iCusID);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        btnadd.Text = "Update";
                        txtcuscode.Text = ds1.Tables[0].Rows[0]["Ledgerid"].ToString();
                        txtcustomername.Text = ds1.Tables[0].Rows[0]["LedgerName"].ToString();
                        txtmobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtphoneno.Text = ds1.Tables[0].Rows[0]["PhoneNo"].ToString();
                        txtarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                        txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                        txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                        txtpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();
                        txtemail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();
                        //ddlCustomerType.SelectedValue = ds1.Tables[0].Rows[0]["ContactTypeID"].ToString();
                        txtdisc.Text = ds1.Tables[0].Rows[0]["Disc"].ToString();
                        txtgstno.Text = ds1.Tables[0].Rows[0]["Gstno"].ToString();
                        txtpaymentdays.Text = ds1.Tables[0].Rows[0]["paymentdays"].ToString();
                        ddlCDType.SelectedValue = ds1.Tables[0].Rows[0]["Type"].ToString();

                        if (ddlCDType.SelectedValue == "Credit Note")
                        {
                            txtOBalance.Text = ds1.Tables[0].Rows[0]["Open_Credit"].ToString();
                        }
                        else
                        {
                            txtOBalance.Text = ds1.Tables[0].Rows[0]["Open_Depit"].ToString();
                        }

                        //if (ddlCustomerType.SelectedValue == "6")
                        //{
                        //    Ingredient.Visible = true;
                        //    paymentdays.Visible = true;
                        //}
                        //else
                        //{
                        //    Ingredient.Visible = false;
                        //    paymentdays.Visible = false;
                        //    txtpaymentdays.Text = "0";
                        //}

                        //DataSet dsLedgerIngredient = objBs.GetLedgerIngredient(Convert.ToInt32(ds1.Tables[0].Rows[0]["Ledgerid"].ToString()));
                        //if (dsLedgerIngredient.Tables[0].Rows.Count > 0)
                        //{
                        //    //for (int i = 0; i < dsLedgerIngredient.Tables[0].Rows.Count; i++)
                        //    //{
                        //    //    chkIngredient.Items.FindByValue(dsLedgerIngredient.Tables[0].Rows[i]["IngredientId"].ToString()).Selected = true;
                        //    //}
                        //    {
                        //        //Select the checkboxlist items those values are true in database
                        //        //Loop through the DataTable
                        //        //for (int i = 0; i <= dtranscat.Tables[0].Rows.Count - 1; i++)
                        //        {

                        //            {
                        //                //Find the checkbox list items using FindByValue and select it.
                        //                // chkcategory.Items.FindByValue(dtranscat.Tables[0].Rows[i]["categoryid"].ToString()).Selected = true;
                        //                for (int j = 0; j < griditem.Rows.Count; j++)
                        //                {
                        //                    Label lblitemid = (Label)griditem.Rows[j].FindControl("lblitemid");
                        //                    for (int vLoop = 0; vLoop < dsLedgerIngredient.Tables[0].Rows.Count; vLoop++)
                        //                    {

                        //                        string itemid = dsLedgerIngredient.Tables[0].Rows[vLoop]["IngredientId"].ToString();
                        //                        string purchasename = dsLedgerIngredient.Tables[0].Rows[vLoop]["BIngredientName"].ToString();

                        //                        if (lblitemid.Text == itemid)
                        //                        {
                        //                            //Label lblcatname = (Label)gridcat.Rows[vLoop].FindControl("lblcatname");
                        //                            CheckBox chkitem = (CheckBox)griditem.Rows[j].FindControl("chkitem");
                        //                            chkitem.Checked = true;
                        //                            chkitem.Enabled = false;
                        //                            TextBox txtitemprintname = (TextBox)griditem.Rows[j].FindControl("txtitemprintname");
                        //                            txtitemprintname.Text = (purchasename).ToString();
                        //                        }

                        //                    }
                        //                }

                        //            }

                        //        }
                        //    }
                        //}

                    }

                }
            }

        }
        protected void customertype_chnaged(object sender, EventArgs e)
        {

            //if (ddlCustomerType.SelectedValue == "1")
            //{
            //    disc.Visible = true;
            //    txtdisc.Focus();
            //}
            //else
            //{
            //    disc.Visible = false;
            //    txtpincode.Focus();
            //}

            //if (ddlCustomerType.SelectedValue == "6")
            //{
            //    Ingredient.Visible = true;
            //    paymentdays.Visible = true;
            //   // chkIngredient.Focus();
            //}
            //else
            //{
            //    Ingredient.Visible = false;
            //    paymentdays.Visible = false;
            //    txtpaymentdays.Text = "0";
            //  //  chkIngredient.Focus();
            //}

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
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Bank Name Already Exists.Thank you!!!.');", true);
                    return;
                }

                #endregion

                DataSet ds = objBs.chkinsertcontact(txtemail.Text, txtmobileno.Text);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    lblerror.Text = "Email id or Mobile Number  already exists";
                }
                else
                {
                    int GroupId = 0;
                    //if (ddlCustomerType.SelectedValue == "1")
                    //{
                    //    GroupId = 5;
                    //}
                    //else if (ddlCustomerType.SelectedValue == "6")
                    //{
                    //    GroupId = 2;
                    //}
                    //if (ddlCustomerType.SelectedValue == "6")
                    //{
                    //    GroupId = 2;
                    //}
                    //else
                    //{
                    GroupId = 4;
                    //}

                     int LedgerId;
                     if (ddlCDType.SelectedValue == "Credit Note")
                     {
                         string Credite = txtOBalance.Text;
                         LedgerId = objBs.insertbank(Convert.ToInt32(lblUserID.Text), txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(0), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, "", Convert.ToDouble(Credite), Convert.ToDouble("0"), ddlCDType.SelectedValue);
                     }
                     else
                     {
                         string Debit = txtOBalance.Text;
                         LedgerId = objBs.insertbank(Convert.ToInt32(lblUserID.Text), txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(0), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, "", Convert.ToDouble("0"), Convert.ToDouble(Debit), ddlCDType.SelectedValue);
                     }

                    //for (int ii = 0; ii < griditem.Rows.Count; ii++)
                    //{
                    //    Label lblitemid = (Label)griditem.Rows[ii].FindControl("lblitemid");
                    //    CheckBox chkitem = (CheckBox)griditem.Rows[ii].FindControl("chkitem");
                    //    if (chkitem.Checked == true)
                    //    {
                    //        TextBox txtitemprintname = (TextBox)griditem.Rows[ii].FindControl("txtitemprintname");
                    //        if (txtitemprintname.Text == "")
                    //        {
                    //            txtitemprintname.Text = "----";
                    //        }
                    //        int LedgerIngredient = objBs.InsertLedgerIngredient(LedgerId, Convert.ToInt32(lblitemid.Text), txtitemprintname.Text);
                    //    }
                    //}

                    //  Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
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
                else
                {
                    int GroupId = 0;
                    //if (ddlCustomerType.SelectedValue == "1")
                    //{
                    //    GroupId = 5;
                    //}
                    //else if (ddlCustomerType.SelectedValue == "6")
                    //{
                    //    GroupId = 6;
                    //}
                    //if (ddlCustomerType.SelectedValue == "6")
                    //{
                    //    GroupId = 2;
                    //}
                    //else
                    //{
                    GroupId = 4;
                    //}
                     int iStatus = 0;
                     if (ddlCDType.SelectedValue == "Credit Note")
                     {
                         string Credite = txtOBalance.Text;
                         iStatus = objBs.updatecontact(txtcuscode.Text, txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(0), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, "", "", 0, Convert.ToDouble(Credite), Convert.ToDouble("0"), ddlCDType.SelectedValue,"Inner");
                     }
                     else
                     {
                         string Debit = txtOBalance.Text;
                         iStatus = objBs.updatecontact(txtcuscode.Text, txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text, Convert.ToInt32(0), GroupId, txtdisc.Text, txtgstno.Text, txtpaymentdays.Text, "", "", 0, Convert.ToDouble("0"), Convert.ToDouble(Debit), ddlCDType.SelectedValue,"Inner");
                     }
                                        
                    //foreach (ListItem item in chkIngredient.Items)
                    //{
                    //    if (item.Selected)
                    //    {
                    //        int LedgerIngredient = objBs.InsertLedgerIngredient(Convert.ToInt32(txtcuscode.Text), Convert.ToInt32(item.Value),"Bitemname");
                    //    }
                    //}

                    //for (int ii = 0; ii < griditem.Rows.Count; ii++)
                    //{
                    //    Label lblitemid = (Label)griditem.Rows[ii].FindControl("lblitemid");
                    //    CheckBox chkitem = (CheckBox)griditem.Rows[ii].FindControl("chkitem");
                    //    if (chkitem.Checked == true)
                    //    {
                    //        TextBox txtitemprintname = (TextBox)griditem.Rows[ii].FindControl("txtitemprintname");
                    //        if (txtitemprintname.Text == "")
                    //        {
                    //            txtitemprintname.Text = "----";
                    //        }
                    //        int LedgerIngredient = objBs.InsertLedgerIngredient(Convert.ToInt32(txtcuscode.Text), Convert.ToInt32(lblitemid.Text), txtitemprintname.Text);
                    //    }
                    //}

                    // Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
                }
            }


            if (MasterType == "Employee")
            {
                Response.Redirect("../Accountsbootstrap/viewbank.aspx");
            }
            else
            {
                Response.Redirect("../Accountsbootstrap/viewbank.aspx");
            }
        }


        protected void Exit_Click(object sender, EventArgs e)
        {
            string MasterType = Request.QueryString.Get("MasterType");
            //  Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
            if (MasterType == "Employee")
            {
                Response.Redirect("../Accountsbootstrap/viewbank.aspx");
            }
            else
            {
                Response.Redirect("../Accountsbootstrap/viewbank.aspx");
            }
        }
    }
}