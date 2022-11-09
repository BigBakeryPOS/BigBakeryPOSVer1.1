using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net.Mail;
namespace Billing.Accountsbootstrap
{
    public partial class Home_Page : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        decimal total, tmp = 0, cash = 0, credit = 0, card = 0, compli = 0, sales, gross, cash_handover = 0, Closing_cash = 0, net_sales = 0, tot_grosssales = 0, OP_cash = 0, gross_main = 0;
        string sTablename = "";
        string scode="";

        public static Label lbl;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTablename = Request.Cookies["userInfo"]["BranchCode"].ToString();
            scode = Request.Cookies["userInfo"]["BranchCode"].ToString();


            DataSet dmovivation = objbs.getmotivation();
            if (dmovivation.Tables[0].Rows.Count > 0)
            {
                lblmotivation.Text = dmovivation.Tables[0].Rows[0]["words"].ToString();
            }
            else
            {
                lblmotivation.Text = "Keep Going - Jothi Kumar";
            }

            DataSet dsNoBranch = objbs.GetNoBranch();
              if (dsNoBranch.Tables[0].Rows.Count > 0)
              {
                  Company.InnerText = dsNoBranch.Tables[0].Rows[0]["CustomerName"].ToString();
              }
            if (scode == "Admin")
            {

                //#region Sales

                //DataSet dstd = new DataSet();
                //DataTable dtraw = new DataTable();
                //DataRow drraw;

                //dtraw.Columns.Add("Branch");
                //dtraw.Columns.Add("TotalCount");
                //dtraw.Columns.Add("Total");

                //dstd.Tables.Add(dtraw);


                //DataSet ds = objbs.getbranchforhomepage();



                //foreach (DataRow tr in ds.Tables[0].Rows)
                //{
                //    DataSet ds2 = objbs.OrderGridTomm(tr["BranchCode"].ToString());
                //    if (ds2.Tables[0].Rows.Count > 0)
                //    {
                //        if (ds2.Tables[0].Rows[0]["TotalCount"].ToString() != "0")
                //        {
                //            drraw = dtraw.NewRow();
                //            drraw["Branch"] = tr["BranchArea"];
                //            drraw["TotalCount"] = ds2.Tables[0].Rows[0]["TotalCount"].ToString();
                //            drraw["Total"] = Convert.ToDouble(ds2.Tables[0].Rows[0]["Total"]).ToString("f2");

                //            dstd.Tables[0].Rows.Add(drraw);
                //        }
                //    }
                //}
                //gvsalesAll.DataSource = dstd;
                //gvsalesAll.DataBind();
                //#endregion

                //#region Order

                //DataSet dstd1 = new DataSet();
                //DataTable dtraw1 = new DataTable();
                //DataRow drraw1;

                //dtraw1.Columns.Add("Branch");
                //dtraw1.Columns.Add("CustomerName");
                //dtraw1.Columns.Add("MobileNo");
                //dtraw1.Columns.Add("OrderNo");
                //dtraw1.Columns.Add("DeliveryDate");
                //dtraw1.Columns.Add("Total");
                //dtraw1.Columns.Add("NetAmount");
                //dtraw1.Columns.Add("PaidAmount");
                //dtraw1.Columns.Add("Balance");


                //dstd1.Tables.Add(dtraw1);


                //DataSet ds1 = objbs.getbranchforhomepage();



                //foreach (DataRow tr in ds1.Tables[0].Rows)
                //{
                //    DataSet ds21 = objbs.OrderGridhome(tr["BranchCode"].ToString());
                //    if (ds21.Tables[0].Rows.Count > 0)
                //    {

                //        drraw1 = dtraw1.NewRow();
                //        drraw1["Branch"] = tr["BranchArea"];
                //        drraw1["CustomerName"] = ds21.Tables[0].Rows[0]["CustomerName"].ToString();
                //        drraw1["MobileNo"] = ds21.Tables[0].Rows[0]["MobileNo"].ToString();
                //        drraw1["OrderNo"] = ds21.Tables[0].Rows[0]["OrderNo"].ToString();
                //        drraw1["DeliveryDate"] = ds21.Tables[0].Rows[0]["DeliveryDate"].ToString();
                //        drraw1["Total"] = Convert.ToDouble(ds21.Tables[0].Rows[0]["Total"]).ToString("f2");
                //        drraw1["NetAmount"] = Convert.ToDouble(ds21.Tables[0].Rows[0]["NetAmount"]).ToString("f2");
                //        drraw1["PaidAmount"] = Convert.ToDouble(ds21.Tables[0].Rows[0]["PaidAmount"]).ToString("f2");
                //        drraw1["Balance"] = Convert.ToDouble(ds21.Tables[0].Rows[0]["Balance"]).ToString("f2");
                //        dstd1.Tables[0].Rows.Add(drraw1);

                //    }
                //}
                //gvOrder.DataSource = dstd1;
                //gvOrder.DataBind();
                //#endregion
            }
            else
            {
                #region

                //////DataSet ds = objbs.SentMessege(scode);
                //////gvmsg.DataSource = ds.Tables[0];
                //////gvmsg.DataBind();
                //////string dt = DateTime.Today.ToString("yyyy-MM-dd");



                if (lblUser.Text.ToLower().Contains("pro") == true)
                {
                //////    tdmsg.Visible = true;

                //////    ddlBranch.Visible = true;
                //////    DataSet ds2 = objbs.OrderdAdmin();
                //////    GridView1.DataSource = ds2;
                //////    GridView1.DataBind();
                }
                else
                {
                    #region

                    //////ddProduction.Visible = true;
                    //////tdmsg.Visible = true;

                    //////if (sTablename == "admin")
                    //////{
                    //////    DataSet ds1 = objbs.OrderGridAdmin();
                    //////    gvOrder.DataSource = ds1;
                    //////    gvOrder.DataBind();


                    //////    DataSet ds2 = objbs.OrderdAdmin();
                    //////    gvOrder.DataSource = ds2;
                    //////    gvOrder.DataBind();

                    //////    DataSet dCustReport = objbs.CustomerSalesAdmin();
                    //////    gvSales.DataSource = dCustReport.Tables[0];
                    //////    gvSales.DataBind();
                    //////}
                    //////else
                    //////{

                    //////    DataSet ds2 = objbs.OrderGridhome(sTablename);
                    //////    gvOrder.DataSource = ds2;
                    //////    gvOrder.DataBind();

                    //////    DataSet dsTom = objbs.OrderGridTomm(sTablename);
                    //////    gvsalesAll.DataSource = dsTom;
                    //////    gvsalesAll.DataBind();

                    //////    //////gvTomcustomer.DataSource = dsTom;
                    //////    //////gvTomcustomer.DataBind();


                    //////    //date.Text = dt;
                    //////    DataSet ds_cash = objbs.GetCash_sales(dt, sTablename);

                    //////    if (ds_cash.Tables[0].Rows[0]["Sum"].ToString() == "")
                    //////    {
                    //////        lblCash_sales_Amt.Text = "0.00";
                    //////    }
                    //////    else
                    //////    {
                    //////        cash = Convert.ToDecimal(ds_cash.Tables[0].Rows[0]["Sum"].ToString());
                    //////        cash = Math.Round(cash, 2);
                    //////        lblCash_sales_Amt.Text = cash.ToString();

                    //////    }



                    //////    DataSet dRet = objbs.ReturnGridHomePage(sTablename);
                    //////    gvReturns.DataSource = dRet;
                    //////    gvReturns.DataBind();

                    //////}
                    //////if (lblUser.Text == "production")
                    //////{

                    //////    DataSet ds2 = objbs.OrderdAdmin();
                    //////    gvTomcustomer.DataSource = ds2;
                    //////    gvTomcustomer.DataBind();
                    //////}
                    //////#region Sales Flow
                    ////////  string dt = DateTime.Today.ToString("dd/MM/yyyy");






                    //////DataSet ds_order = objbs.GetOrder_sales(dt, sTablename);
                    //////DataSet dordercard = objbs.orderCard(dt, sTablename);
                    //////if (dordercard.Tables[0].Rows[0]["Total"].ToString() == "")
                    //////{
                    //////}
                    //////else
                    //////{
                    //////    decimal amt = Convert.ToDecimal(dordercard.Tables[0].Rows[0]["Total"].ToString());
                    //////    lblordercard.Text = amt.ToString("f2");
                    //////}
                    //////if (ds_order.Tables[0].Rows[0]["Sum"].ToString() == "")
                    //////{
                    //////    lblOrder_sales_amt.Text = "0.00";

                    //////}
                    //////else
                    //////{
                    //////    compli = Convert.ToDecimal(ds_order.Tables[0].Rows[0]["Sum"].ToString());
                    //////    compli = Math.Round(compli, 2);
                    //////    lblOrder_sales_amt.Text = compli.ToString();

                    //////}


                    #endregion

                    #region NEW SALES FLOW

                    //////// GETTING  BILL COUNT AND AMOUNT

                    //////DataSet dtotbillcount = objbs.TotalBillToday(sTablename);
                    //////if (dtotbillcount.Tables[0].Rows.Count > 0)
                    //////{
                    //////    lbltotalsalescount.Text = dtotbillcount.Tables[0].Rows[0]["Cancel"].ToString();

                    //////}

                    //////DataSet dsalesAmt = objbs.SalesAmt(sTablename);
                    //////if (dsalesAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                    //////{
                    //////    lblsales.Text = "Rs " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString("f2");
                    //////    lbltotalamountt.Text = "Rs " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString("f2");
                    //////}
                    //////else
                    //////{
                    //////    lblsales.Text = "Rs " + "0";
                    //////    lbltotalamountt.Text = "Rs " + "0";
                    //////}


                    //////// GETTING CAKE AMOUNT TODAY
                    //////DataSet dtotcakebillcount = objbs.TotalCakeBillToday(sTablename);
                    //////if (dtotcakebillcount.Tables[0].Rows.Count > 0)
                    //////{
                    //////    lbltodaycakeorder.Text = dtotcakebillcount.Tables[0].Rows[0]["cakeorder"].ToString();

                    //////}

                    //////DataSet dcakeAmt = objbs.CakeAmt(sTablename);
                    //////if (dcakeAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                    //////{
                    //////    lbltodaycakeamount.Text = "Rs " + Convert.ToDecimal(dcakeAmt.Tables[0].Rows[0]["Total"]).ToString("f2");
                    //////    // lbltotalamountt.Text = "Rs " + Convert.ToDecimal(dcakeAmt.Tables[0].Rows[0]["Total"]).ToString("f2");
                    //////}
                    //////else
                    //////{
                    //////    lbltodaycakeamount.Text = "Rs " + "0";
                    //////    // lbltotalamountt.Text = "Rs " + "0";
                    //////}



                    //////// FOR CANCEL BILL AND AMOUNT
                    //////DataSet dcancelToday = objbs.CanceledBillToday(sTablename);
                    //////if (dcancelToday.Tables[0].Rows.Count > 0)
                    //////{
                    //////    lbltodaycancelbillcount.Text = dcancelToday.Tables[0].Rows[0]["Cancel"].ToString();
                    //////}
                    ////////By Jothi
                    //////DataSet dcancelTodayamount = objbs.CanceledBillTodayAmount(sTablename);
                    //////if (dcancelTodayamount.Tables[0].Rows.Count > 0)
                    //////{
                    //////    lblcancelamount.Text = "Rs " + Convert.ToDecimal(dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"]).ToString("f2");
                    //////    //dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"].ToString();
                    //////}

                    //////// GET ALL CASH AND CARD AMOUNT
                    //////DataSet dgetcashamountn = objbs.getsalesandordercashamount(sTablename);
                    //////if (dgetcashamountn.Tables[0].Rows.Count > 0)
                    //////{
                    //////    double totalamout = 0;

                    //////    for (int i = 0; i < dgetcashamountn.Tables[0].Rows.Count; i++)
                    //////    {

                    //////        totalamout = totalamout + Convert.ToDouble(dgetcashamountn.Tables[0].Rows[i]["amnt"]);
                    //////    }


                    //////    lbltotaltodaycashamnt.Text = totalamout.ToString("0.00");
                    //////}


                    //////// GET ALL CARD AMOUNT

                    //////DataSet dgetcardamountn = objbs.getsalesandordercardamount(sTablename);
                    //////if (dgetcardamountn.Tables[0].Rows.Count > 0)
                    //////{
                    //////    double totalcardamout = 0;

                    //////    for (int i = 0; i < dgetcardamountn.Tables[0].Rows.Count; i++)
                    //////    {

                    //////        totalcardamout = totalcardamout + Convert.ToDouble(dgetcardamountn.Tables[0].Rows[i]["amnt"]);
                    //////    }

                    //////    lbltotaltodaycardamnt.Text = totalcardamout.ToString("0.00");
                    //////}


                    #endregion

                    
                }
                #endregion
            }
        }



        protected void btnMail_Click(object sender, EventArgs e)
        {
            SendEmail(sender, e);
        }


        protected void SendEmail(object sender, EventArgs e)
        {
            string body = this.PopulateBody(" ",
        "  ",
        "",
        " ");

            string Branch = string.Empty;

            if (sTablename == "CO4")
            {
                Branch = "GN MILLS";
            }

           ////// this.SendHtmlFormattedEmail("callforcakemail@gmail.com ", "callforcakemail@gmail.com ", "Summary Bill And Amount Report (" + Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy HH:mm:ss") + ") - Store: " + Branch + " ", body, "msasit01@gmail.com","prathisasi05@gmail.com","prathi05sasi@yahoo.com");

            this.SendHtmlFormattedEmail("rajar@bigdbiz.in ", "rajar@bigdbiz.in", "Summary Bill And Amount Report (" + Convert.ToDateTime(DateTime.Now).ToString("dd-MM-yyyy HH:mm:ss") + ") - Store: " + Branch + " ", body, "rajar@bigdbiz.in", "rajar@bigdbiz.in", "rajar@bigdbiz.in");


            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);
        }

        private string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Accountsbootstrap/HTMLTODAY.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{lbltodaybillcount}", lbltotalsalescount.Text);
            body = body.Replace("{lbltodayamount}", lbltotalamountt.Text);


            body = body.Replace("{lbltodaycakeorderbillcount}", lbltodaycakeorder.Text);
            body = body.Replace("{lbltodaycakeorderamount}", lbltodaycakeamount.Text);


            body = body.Replace("{lbltodaycancelbillcount}", lbltodaycancelbillcount.Text);
            body = body.Replace("{lbltodaycancelamount}", lblcancelamount.Text);


            body = body.Replace("{lbltotalcashamount}", lbltotaltodaycashamnt.Text);
            body = body.Replace("{lbltotalcardamount}", lbltotaltodaycardamnt.Text);

            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string cc, string subject, string body, string a,string b,string c)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));

                //mailMessage.CC.Add(new MailAddress(cc));
                mailMessage.CC.Add(new MailAddress(a));
                mailMessage.CC.Add(new MailAddress(b));
                mailMessage.CC.Add(new MailAddress(c));
                //mailMessage.CC.Add(new MailAddress(d));
                //mailMessage.CC.Add(new MailAddress(e));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
                NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
                smtp.Send(mailMessage);
            }
        }


        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "view")
            //{
            //    DataSet dSplit = objbs.getcustPendingDet(Convert.ToInt16(e.CommandArgument.ToString()));
            //    gvSplitUp.DataSource = dSplit;
            //    gvSplitUp.DataBind();
            //}
        }

       

      


        public static bool TcpSocketTest()
        {
            try
            {
                System.Net.Sockets.TcpClient client =
                    new System.Net.Sockets.TcpClient("www.google.com", 80);
                client.Close();
              
                return true;

               
            }
            catch (System.Exception ex)
            {
                return false;

            }
        }
        protected void gvTomcustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string[] Arg = new string[2];
                Arg = e.CommandArgument.ToString().Split(';');
                int OrdeNo = Convert.ToInt32(Arg[0]);
                int UserId = Convert.ToInt32(Arg[1]);
                DataSet ds2 = objbs.OrderdAdmin();
                if (ds2.Tables[0].Rows.Count > 0)
                {


                    DataSet ds = objbs.OrderGridDet(OrdeNo, UserId);
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();


                }
            }
        }

        protected void btnStock_Click(object sender, EventArgs e)
        {

        }

        protected void btnStock_PreRender(object sender, EventArgs e)
        {

        }

        protected void btnStock_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=server;Database=BlackForestProd;uid=sa;password=P@ss123");
            string query = "delete from tblLocalStock where UserID=" + lblUserID.Text + "";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();


            DataSet ds = objbs.chkstock(Convert.ToInt32(lblUserID.Text),sTablename);
            int ToolId = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int iCatID = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryID"].ToString());
                    int iSubCat = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategoryID"].ToString());
                    double AvlQty = Convert.ToDouble(ds.Tables[0].Rows[i]["Available_QTY"].ToString());
                    double Qty = Convert.ToDouble(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    int iuserID = Convert.ToInt32(ds.Tables[0].Rows[i]["UserID"].ToString());
                    if (ds.Tables[0].Rows[i]["ToolID"].ToString() == "")
                    {
                        ToolId = 0;
                    }
                    else
                    {
                        ToolId = Convert.ToInt32(ds.Tables[0].Rows[i]["ToolID"].ToString());
                    }
                    string sDate = (ds.Tables[0].Rows[i]["ExpiryDate"].ToString());



                    string Insertquery = "insert into tblLocalStock (CategoryID,UserID,SubCategoryID,Quantity,Available_QTY,ToolID,Expirydate) values('" + iCatID + "','" + iuserID + "','" + iSubCat + "'," + Qty + " , '" + AvlQty + "','" + ToolId + "','" + sDate + "')";

                    SqlCommand cmd1 = new SqlCommand(Insertquery, con);

                    cmd1.ExecuteNonQuery();
                }
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alertMessage();", true);
        }

        protected void btnmsg_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt");
            string to = "";

            if (ddlMeridian.SelectedValue == "PM")
            {
                int hours = Convert.ToInt32(ddlHours.SelectedValue);
                to = Convert.ToDateTime(txtEndDate.Text).ToShortDateString()+ " " + hours.ToString() + ":" + ddlMinutes.SelectedValue + ":" + "00";
            }
            else
            {
                to = Convert.ToDateTime(txtEndDate.Text).ToShortDateString() + " " + ddlHours.SelectedValue + ":" + ddlMinutes.SelectedValue + ":" + "00";
            }
            if (lblUser.Text.ToLower().Contains("pro") == true)
            {
                int isave = objbs.Messege(date,  txtMsg.Text, to, Convert.ToInt32(ddlBranch.SelectedValue),(scode));
            }
            else
            {
                int isave = objbs.Messege(date, txtMsg.Text, to, Convert.ToInt32(ddProduction.SelectedValue), (scode));
            }
            txtMsg.Text = string.Empty;
            lblsucess.Text = "Messege sent sucessfully";

            DataSet ds = objbs.SentMessege(scode);

            gvmsg.DataSource = ds.Tables[0];
            gvmsg.DataBind();

        }

        protected void gvmsg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int del=objbs.deletemessege(Convert.ToInt32(e.CommandArgument.ToString()));
                //DataSet ds = objbs.SentMessege(scode);

                //gvmsg.DataSource = ds.Tables[0];
                //gvmsg.DataBind();
                Response .Redirect
                    ("Home_Page.aspx");
                
            }
        }

        

    }
}