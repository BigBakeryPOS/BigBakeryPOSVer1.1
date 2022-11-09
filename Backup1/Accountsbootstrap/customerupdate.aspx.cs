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
    public partial class categoryupdate : System.Web.UI.Page
    {
        
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

          
                if (ViewState["PreviouPage"] != Request.UrlReferrer)
                {
                    
                
                    btnupdate.Enabled = false;
                }
                    else
                    {
                        btnupdate.Enabled=true;
                    }
                    DataSet ds = objBs.Billno(txtcuscode.Text);

                    txtcuscode.Text = ds.Tables[0].Rows[0][0].ToString();
                    lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
                    lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();

                    string iCusID = Request.QueryString.Get("iCusID");
                    if (iCusID != "" || iCusID != null)
                    {
                        DataSet ds1 = objBs.getselectcustomer(iCusID);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            txtcuscode.Text = ds1.Tables[0].Rows[0]["CustomerID"].ToString();
                            txtcustomername.Text = ds1.Tables[0].Rows[0]["CustomerName"].ToString();
                            txtmobileno.Text = ds1.Tables[0].Rows[0]["MobileNo"].ToString();
                            txtphoneno.Text = ds1.Tables[0].Rows[0]["PhoneNo"].ToString();
                            txtarea.Text = ds1.Tables[0].Rows[0]["Area"].ToString();
                            txtaddress.Text = ds1.Tables[0].Rows[0]["Address"].ToString();
                            txtcity.Text = ds1.Tables[0].Rows[0]["City"].ToString();
                            txtpincode.Text = ds1.Tables[0].Rows[0]["Pincode"].ToString();
                            txtemail.Text = ds1.Tables[0].Rows[0]["Email"].ToString();


                        }

                    }
                }

          
     
        
        protected void Update_Click(object sender, EventArgs e)
        {
            //if (txtemail.Text != "")
            //{
            //    DataSet ds = objBs.selectemailid(txtemail.Text);
            //    if (ds.Tables[0].Rows.Count != 0)
            //    {
            //        //Response.Write("email id already exists");
            //        lblerror.Text = "Email id already exists";

            //    }
            //    else
            //    {

                    //int iStatus = objBs.updatecustomer(txtcuscode.Text, txtcustomername.Text, txtmobileno.Text, txtphoneno.Text, txtarea.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtemail.Text,Convert.ToInt32();
                    Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
                    
                //} }
            }
            
          
        
    

        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Accountsbootstrap/viewcustomer.aspx");
        }
        }
}