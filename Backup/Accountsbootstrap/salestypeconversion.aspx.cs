using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;

namespace Billing.Accountsbootstrap
{
    public partial class salestypeconversion : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        DataSet ds = new DataSet();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
          
            if (!IsPostBack)
            {
                //txtdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //string datee = DateTime.Now.ToString("yyyy-MM-dd");
                //DataSet ds1 = objbs.salesconversionytpe(sTableName, Convert.ToDateTime(datee));
                //if (ds1.Tables[0].Rows.Count > 0)
                //{
                //    //txtentry.Text = ds1.Tables[0].Rows[0]["ledgerGen"].ToString();
                   
                //    ddlbillno.DataSource = ds1;
                //    ddlbillno.DataValueField = "Salesid";
                //    ddlbillno.DataTextField = "BillNo";
                //    ddlbillno.Items.Insert(0, "Select BillNo.");
                //    ddlbillno.DataBind();
                //}
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }


            if (txtdate.Text == "--Select Date--")
            {
                lbldateError.Text = "please select date";

                
            }
            else
            {
                txtdate.Text = DateTime.Now.ToShortDateString();
                int i = objbs.salesconversionchange(sTableName, ddlbillno.SelectedValue,checkconversion.SelectedValue);
               // int i = objbs.ledgerinsert(sTableName, txtdate.Text, Convert.ToString(ddlbillno.SelectedValue), txtdescrip.Text, Convert.ToDouble(txtamount.Text));
                Response.Redirect("salestypeconversion.aspx");
            }

        }
        protected void txtdate_textchanged(object sender, EventArgs e)
        {
            if (txtdate.Text == "")
            {
                lbldateError.Text = "please select date";
                
            }
            else
            {
                if (sTableName != "admin")
                {
                    DateTime date = Convert.ToDateTime(txtdate.Text);
                    DateTime Toady = DateTime.Now.Date; ;

                    var days = date.Day;
                    var toda = Toady.Day;

                    if ((toda - days) <= 2)
                    {
                        DataSet ds1 = objbs.salesconversionytpe(sTableName, Convert.ToDateTime(txtdate.Text));
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            //txtentry.Text = ds1.Tables[0].Rows[0]["ledgerGen"].ToString();
                            // ddlbillno.ClearSelection();

                            ddlbillno.DataSource = ds1.Tables[0];
                            ddlbillno.DataValueField = "Salesid";
                            ddlbillno.DataTextField = "BillNo";
                            ddlbillno.DataBind();
                            ddlbillno.Items.Insert(0, "Select BillNo.");

                        }
                        paylabel.Text = "";
                        txtamount.Text = "";
                    }

                    else
                    {
                        txtdate.Text = "";
                    }
                }

               
            }
        }

        protected void ddlbillno_selcted(object sender, EventArgs e)
        {
            string value = ddlbillno.SelectedValue;

            if (value == "Select BillNo.")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please select Valid Bill No.');", true);
                paylabel.Text = "";
                txtamount.Text = "";
                return;
            }
            else
            {

                DataSet dtt = objbs.salesnilltrteirve(sTableName, value);


                if (dtt.Tables[0].Rows.Count > 0)
                {
                    txtamount.Text = dtt.Tables[0].Rows[0]["total"].ToString();
                    int paymode = Convert.ToInt32(dtt.Tables[0].Rows[0]["ipaymode"]);

                    if (paymode == 1)
                    {
                        paylabel.Text = "Cash";
                        btnsave.Enabled = true;
                    }
                    else if (paymode == 2)
                    {
                        paylabel.Text = "Credit";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 3)
                    {
                        paylabel.Text = "Compliment";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 4)
                    {
                        paylabel.Text = "Card";
                        btnsave.Enabled = true;
                    }
                    else if (paymode == 5)
                    {
                        paylabel.Text = "Date Bared";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 6)
                    {
                        paylabel.Text = "Wastage";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 7)
                    {
                        paylabel.Text = "BB Kulam";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 8)
                    {
                        paylabel.Text = "Byepass";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 9)
                    {
                        paylabel.Text = "KkNagar";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 10)
                    {
                        paylabel.Text = "NP";
                        btnsave.Enabled = false;
                    }
                    else if (paymode == 11)
                    {
                        paylabel.Text = "Bank";
                        btnsave.Enabled = true;
                    }

                   
                }
            }

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect("salestypeconversion.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtorderdate.Text == "")
            {
                Label1.Text = "please select date";

            }
            else
            {
                if (sTableName != "admin")
                {
                    DateTime date = Convert.ToDateTime(txtorderdate.Text);
                    DateTime Toady = DateTime.Now.Date; ;

                    var days = date.Day;
                    var toda = Toady.Day;

                    if ((toda - days) <= 2)
                    {
                        DataSet ds1 = objbs.orderconversionytpe(sTableName, Convert.ToDateTime(txtorderdate.Text));
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            //txtentry.Text = ds1.Tables[0].Rows[0]["ledgerGen"].ToString();
                            // ddlbillno.ClearSelection();

                            ddlorderno.DataSource = ds1.Tables[0];
                            ddlorderno.DataValueField = "orderid";
                            ddlorderno.DataTextField = "orderno";
                            ddlorderno.DataBind();
                            ddlorderno.Items.Insert(0, "Select orderNo.");

                        }
                        orderpay.Text = "";
                        txtOrderAmt.Text = "";
                    }

                    else
                    {
                        txtorderdate.Text = "";
                    }
                }


              
            }
        }

        protected void ddlorderno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlorderno.SelectedValue;

            if (value == "Select orderNo.")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please select Valid order No.');", true);
                orderpay.Text = "";
                txtOrderAmt.Text = "";
                return;
            }
            else
            {

                DataSet dtt = objbs.ordernilltrteirve(sTableName, value);


                if (dtt.Tables[0].Rows.Count > 0)
                {
                    txtOrderAmt.Text = dtt.Tables[0].Rows[0]["Advance"].ToString();
                    int paymode = Convert.ToInt32(dtt.Tables[0].Rows[0]["ipaymode"]);

                    if (paymode == 1)
                    {
                        orderpay.Text = "Cash";
                        Button1.Enabled = true;
                    }
                    else if (paymode == 2)
                    {
                        orderpay.Text = "Credit";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 3)
                    {
                        orderpay.Text = "Compliment";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 4)
                    {
                        orderpay.Text = "Card";
                        Button1.Enabled = true;
                    }
                    else if (paymode == 5)
                    {
                        orderpay.Text = "Date Bared";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 6)
                    {
                        orderpay.Text = "Wastage";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 7)
                    {
                        orderpay.Text = "BB Kulam";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 8)
                    {
                        orderpay.Text = "Byepass";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 9)
                    {
                        orderpay.Text = "KkNagar";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 10)
                    {
                        orderpay.Text = "NP";
                        Button1.Enabled = false;
                    }
                    else if (paymode == 11)
                    {
                        orderpay.Text = "Bank";
                        Button1.Enabled = true;
                    }


                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("salestypeconversion.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // AFter Denomination Check Sales bill
            DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
            if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Branch Done Denomination.Not Allow To Make Any Bill.Please Contact Administrator.Thank You!!!');", true);
                return;
            }
            else
            {

            }

            if (txtorderdate.Text == "--Select Date--")
            {
                Label1.Text = "please select date";


            }
            else
            {
                txtorderdate.Text = DateTime.Now.ToShortDateString();
                int i = objbs.orderconversionchange(sTableName, ddlorderno.SelectedValue, RadioButtonList1.SelectedValue);
                // int i = objbs.ledgerinsert(sTableName, txtdate.Text, Convert.ToString(ddlbillno.SelectedValue), txtdescrip.Text, Convert.ToDouble(txtamount.Text));
                Response.Redirect("salestypeconversion.aspx");
            }
        }


    }
}