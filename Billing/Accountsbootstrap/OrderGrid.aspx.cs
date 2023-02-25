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
using DataLayer;
using System.Net.Mail;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class OrderGrid : System.Web.UI.Page
    {
        BSClass objbs = new BSClass();
        string sTablename = "";
        string superadmin = "";
        string Password = "";
        string AllowToCancel = "";
        string Empid = "";
        string synccakeorder = "";
        string fssaino = "Nil";
        DBAccess DBAccess = new DBAccess();

        private string connnectionString;
        private string connnectionStringMain;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTablename = Request.Cookies["userInfo"]["User"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            superadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            lblcurrentuser.Text = Request.Cookies["userInfo"]["Biller"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
            synccakeorder = Request.Cookies["userInfo"]["OnlineCakeSync"].ToString();
            fssaino = Request.Cookies["userInfo"]["fssaino"].ToString();

            txtRef.Text = txtRef.Text.Replace(",", "");

            olddiv.Visible = false;
            Newdiv.Visible = false;

            if (!IsPostBack)
            {

                DataSet dacess1 = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "OrderForm");
                if (dacess1.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess1.Tables[0].Rows[0]["active"]) == false)
                    {
                        Response.Redirect("Login_branch.aspx");
                    }
                }

                DataSet dacess = new DataSet();
                dacess = objbs.getuseraccessscreen(Request.Cookies["userInfo"]["EmpId"].ToString(), "OrderForm");
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Save"]) == true)
                    {
                        btnadd.Visible = true;
                    }
                    else
                    {
                        btnadd.Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Edit"]) == true)
                    {
                        //gv.Columns[2].Visible = true;
                    }
                    else
                    {
                        //gv.Columns[2].Visible = false;
                    }

                    if (Convert.ToBoolean(dacess.Tables[0].Rows[0]["Delete"]) == true)
                    {
                       //gv.Columns[3].Visible = true;
                    }
                    else
                    {
                        //gv.Columns[3].Visible = false;
                    }
                }

                DataSet dgetbookcode = objbs.getbookcode(sTablename);
                if (dgetbookcode.Tables[0].Rows.Count > 0)
                {
                    lblbookcode.Text = dgetbookcode.Tables[0].Rows[0]["Bookcode"].ToString();
                }
                else
                {
                    string text2 = "Please Update Book Code For This Branch.Thank You!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                }

                DataSet paymode = objbs.Paymodevalues(sTablename);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drpPayment.DataSource = paymode.Tables[0];
                    drpPayment.DataTextField = "PayMode";
                    drpPayment.DataValueField = "Value";
                    drpPayment.DataBind();
                    drpPayment.SelectedValue = "1";
                }

                DataSet rest = objbs.RestOrder(sTablename);

                DataView dvrest = rest.Tables[0].DefaultView;
                dvrest.Sort = "ORderno DESC";
                gvrest.DataSource = dvrest;
                gvrest.DataBind();

                DataSet Pending = objbs.Pending(sTablename);
                DataView dvPending = Pending.Tables[0].DefaultView;
                dvPending.Sort = "ORderno DESC";
                GridView1.DataSource = dvPending;
                GridView1.DataBind();

                DataSet Todayrest = objbs.todaydeliveryorders(sTablename);

                DataView dvTodayrest = Todayrest.Tables[0].DefaultView;
                dvTodayrest.Sort = "ORderno DESC";
                gvorderToday.DataSource = dvTodayrest;
                gvorderToday.DataBind();


                for (int i = 0; i < gvrest.Rows.Count; i++)
                {
                    Label lblPaybill = (Label)gvrest.Rows[i].FindControl("lblorderno");
                    Label lblpaid = (Label)gvrest.Rows[i].FindControl("lblpaid");
                    Label lblRefamnt = (Label)gvrest.Rows[i].FindControl("lblRefamnt");

                    // GET REFUND AMOUNT
                    DataSet getrefund = objbs.getoverallrefundamount(sTablename, lblPaybill.Text);
                    if (getrefund.Tables[0].Rows.Count > 0)
                    {
                        lblRefamnt.Text = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                    }


                    //GETpaid amount

                    DataSet getpaid = objbs.getoverallpaidamount(sTablename, lblPaybill.Text);
                    if (getpaid.Tables[0].Rows.Count > 0)
                    {
                        lblpaid.Text = Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                    }
                    else
                    {
                        lblpaid.Text = "0";
                    }

                }

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    Label lblPaybill = (Label)GridView1.Rows[i].FindControl("lblorderno");
                    Label lblpaid = (Label)GridView1.Rows[i].FindControl("lblpaid");
                    Label lblRefamnt = (Label)GridView1.Rows[i].FindControl("lblRefamnt");

                    // GET REFUND AMOUNT
                    DataSet getrefund = objbs.getoverallrefundamount(sTablename, lblPaybill.Text);
                    if (getrefund.Tables[0].Rows.Count > 0)
                    {
                        lblRefamnt.Text = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                    }
                    //GETpaid amount

                    DataSet getpaid = objbs.getoverallpaidamount(sTablename, lblPaybill.Text);
                    if (getpaid.Tables[0].Rows.Count > 0)
                    {
                        lblpaid.Text = Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                    }
                    else
                    {
                        lblpaid.Text = "0";
                    }

                }

                for (int i = 0; i < gvorderToday.Rows.Count; i++)
                {
                    Label lblPaybill = (Label)gvorderToday.Rows[i].FindControl("lblorderno");
                    Label lblpaid = (Label)gvorderToday.Rows[i].FindControl("lblpaid");
                    Label lblRefamnt = (Label)gvorderToday.Rows[i].FindControl("lblRefamnt");

                    // GET REFUND AMOUNT
                    DataSet getrefund = objbs.getoverallrefundamount(sTablename, lblPaybill.Text);
                    if (getrefund.Tables[0].Rows.Count > 0)
                    {
                        lblRefamnt.Text = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                    }
                    //GETpaid amount



                    DataSet getpaid = objbs.getoverallpaidamount(sTablename, lblPaybill.Text);
                    if (getpaid.Tables[0].Rows.Count > 0)
                    {
                        lblpaid.Text = Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                    }
                    else
                    {
                        lblpaid.Text = "0";
                    }

                }


                //    LinkButton lblPaybill = (LinkButton)gvrest.Rows[i].FindControl("btnBill");
                //    LinkButton lblCancel = (LinkButton)gvrest.Rows[i].FindControl("btncancelnew");


                //    //if (gvrest.Rows[i].Cells[5].Text == "0.00")
                //    //{
                //    //    lblPaybill.Enabled = false;
                //    //    lblCancel.Enabled = false;

                //    //}
                //    //if (Convert.ToDateTime(gvrest.Rows[i].Cells[7].Text).ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                //    //{
                //    //    lblPaybill.Enabled = false;
                //    //}
                //}

                for (int i = 0; i < rest.Tables[0].Rows.Count; i++)
                {
                    int orderno = Convert.ToInt32(rest.Tables[0].Rows[i]["orderno"].ToString());

                    Label orderdate = (Label)gvrest.Rows[i].FindControl("lblOrderDate");

                    DataSet dts = objbs.getorderDate(sTablename, orderno);
                    if (dts.Tables[0].Rows.Count > 0)
                        orderdate.Text = dts.Tables[0].Rows[0]["OrderDate"].ToString();
                }

                for (int i = 0; i < Pending.Tables[0].Rows.Count; i++)
                {
                    int orderno = Convert.ToInt32(Pending.Tables[0].Rows[i]["orderno"].ToString());

                    Label orderdate = (Label)GridView1.Rows[i].FindControl("lblOrderDate");

                    DataSet dts = objbs.getorderDate(sTablename, orderno);
                    if (dts.Tables[0].Rows.Count > 0)
                        orderdate.Text = dts.Tables[0].Rows[0]["OrderDate"].ToString();
                }




                //for (int i = 0; i < GridView1.Rows.Count; i++)
                //{
                //    DateTime end = Convert.ToDateTime(GridView1.Rows[i].Cells[6].Text);

                //    string start1 = DateTime.Now.ToString("dd/MM/yyyy");

                //   // DateTime start = DateTime.Now.ToString();


                //    double diff = (Convert.ToDateTime(start1) - end).Days;


                //    Label lblpending = (Label)GridView1.Rows[i].FindControl("lblPending");
                //    lblpending.Text = diff.ToString("f0");

                //}
            }
        }

        protected void status_checked(object sender, EventArgs e)
        {
            DataSet Pending = objbs.Pendingchecknew(sTablename, radstatus.SelectedValue);
            DataView dvPending = Pending.Tables[0].DefaultView;
            dvPending.Sort = "ORderno DESC";
            GridView1.DataSource = dvPending;
            GridView1.DataBind();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lblPaybill = (Label)GridView1.Rows[i].FindControl("lblorderno");
                Label lblpaid = (Label)GridView1.Rows[i].FindControl("lblpaid");
                //GETpaid amount

                DataSet getpaid = objbs.getoverallpaidamount(sTablename, lblPaybill.Text);
                if (getpaid.Tables[0].Rows.Count > 0)
                {
                    lblpaid.Text = Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]).ToString("0.00");
                }
                else
                {
                    lblpaid.Text = "0";
                }

            }
        }
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            //GET DATA

            DataTable dt = new DataTable();
            dt.Columns.Add("Book No");
            dt.Columns.Add("Order No");
            dt.Columns.Add("Order Date");
            dt.Columns.Add("Delivery Date");
            dt.Columns.Add("Customer Name");
            dt.Columns.Add("Mobilno");
            dt.Columns.Add("NetTotal");
            dt.Columns.Add("Total");
            dt.Columns.Add("Advance");
            dt.Columns.Add("Item");
            //if (sTableName == "admin")
            //{
            //    DataSet dsp = objbs.Currentlist(DDlbranch.SelectedValue, txtFrom.Text, txtto.Text);

            //    for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
            //    {
            //dt.Rows.Add(dr);
            //        DataRow dr = dt.NewRow();

            // string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime sDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet getorderinfo = objbs.GetCakerOrderINFO("tblorder_" + sTablename + "", sDate);
            if (getorderinfo.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
                {

                    DataRow dr = dt.NewRow();
                    string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
                    dr["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
                    dr["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
                    dr["Order Date"] = getorderinfo.Tables[0].Rows[i]["orderdate"].ToString();
                    dr["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MM/yyyy");
                    dr["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
                    dr["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
                    dr["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
                    dr["Total"] = getorderinfo.Tables[0].Rows[i]["Total"].ToString();
                    dr["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();

                    DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + sTablename + "", billno);
                    if (getorderitem.Tables[0].Rows.Count > 0)
                    {
                        string itemqty = string.Empty;

                        for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
                        {
                            itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
                        }
                        itemqty = itemqty.TrimEnd(',');
                        // itemqty = itemqty.Replace(',', '\n');
                        //   itemqty = itemqty.Replace(",", System.Environment.NewLine);
                        dr["Item"] = itemqty;
                    }
                    dt.Rows.Add(dr);
                }
                gvorderinfo.DataSource = dt;
                gvorderinfo.DataBind();

                SendHTMLMail();
            }

        }

        public void SendHTMLMail()
        {
            MailMessage Msg = new MailMessage();
            MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress("jothikumar@bigdbiz.in"));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            // Subject of e-mail
            Msg.Subject = "Send Order Form Details For " + sTablename + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += GetGridviewData(gvorderinfo);
            Msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SmtpHostName"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = ConfigurationManager.AppSettings["FromAddress"];
            NetworkCred.Password = ConfigurationManager.AppSettings["FromPassword"];
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }
        // This Method is used to render gridview control
        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label status = (Label)GridView1.Rows[i].FindControl("lblstatus");
                Label lblpendingmsg = (Label)GridView1.Rows[i].FindControl("lblpendingmsg");

                if (status.Text == "Pending")
                {
                    if (lblpendingmsg.Text == "")
                    {
                        btnadd.Enabled = false;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Pending Order Occur.Please Enter Reason.else You Wont Allow to Thank You!!!.');", true);
                        return;
                    }
                    else
                    {
                        btnadd.Enabled = true;
                    }
                }
            }

            if (lblbooknocheck.Text == "N")
            {

                Response.Redirect("OrderForm.aspx?ABookno=" + txtbookNo.Text);
            }
            else
            {

                Newdiv.Visible = true;
                txtbookNo.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
            }


            //GridView1
        }



        protected void gvrest_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //if (((System.Web.UI.WebControls.Label)e.Row.FindControl("lblDeliveryStatus")).Text != null)
                {

                    string status = ((System.Web.UI.WebControls.Label)e.Row.FindControl("lblstatus")).Text;
                    Label lblstatus = (Label)e.Row.FindControl("lblstatus");

                    // string status = ((System.Web.UI.WebControls.Label)e.Row.FindControl("lblDeliveryStatus")).Text;

                    // Label lblstatus = (Label)e.Row.FindControl("lblDeliveryStatus");
                    if (synccakeorder == "Y")
                    {
                        if (objbs.IsConnectedToInternet())
                        {
                            object objTemp = gvrest.DataKeys[e.Row.RowIndex].Value as object;
                            if (objTemp != null)
                            {
                                string id = objTemp.ToString();
                                //Do your operations
                                // Get Status

                                DataSet getstatus = objbs.getCakeSummary(id, sTablename);
                                if (getstatus.Tables[0].Rows.Count > 0)
                                {
                                    lblstatus.Text = getstatus.Tables[0].Rows[0]["Deliverstatus"].ToString();
                                }
                                else
                                {
                                    //lblstatus.Text = "Error";
                                }
                            }
                        }
                        else
                        {
                            string text2 = "Please Check Your Internet Connection.Thank You!!!";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                            lblstatus.Text = "Nil- No internet";
                        }
                    }

                }

                //if (AllowToCancel == "YES")
                //{
                //    ((System.Web.UI.WebControls.Image)e.Row.FindControl("imgcancelnew")).Visible = true;
                //    ((ImageButton)e.Row.FindControl("imgdisablenew")).Visible = false;

                //    ((System.Web.UI.WebControls.Image)e.Row.FindControl("btnimgedit")).Visible = true;
                //    ((ImageButton)e.Row.FindControl("btnimgbtedit")).Visible = false;
                //}
                //else
                //{

                //    ((System.Web.UI.WebControls.Image)e.Row.FindControl("imgcancelnew")).Visible = false;
                //    ((ImageButton)e.Row.FindControl("imgdisablenew")).Visible = true;

                //    ((System.Web.UI.WebControls.Image)e.Row.FindControl("btnimgedit")).Visible = false;
                //    ((ImageButton)e.Row.FindControl("btnimgbtedit")).Visible = true;
                //}

            }
            //foreach (GridViewRow row in gvrest.Rows)
            //{
            //    LinkButton lblPaybill = (LinkButton)row.FindControl("btnBill");
            //    LinkButton lblCancel = (LinkButton)row.FindControl("btncancelnew");
            //    if (row.Cells[5].Text == "0.00")
            //    {

            //        row.BackColor = Color.LightGreen;
            //        row.ForeColor = Color.White;

            //    }
            //    else
            //    {
            //        row.BackColor = Color.LightYellow;

            //    }

            //    DateTime end = Convert.ToDateTime(row.Cells[7].Text);

            //    if (DateTime.Now.ToString("yyyy-MM-dd") == end.ToString("yyyy-MM-dd"))
            //    {
            //        row.BackColor = Color.CadetBlue;
            //    }



            //}
        }

        protected void CancelYes_click(object sender, EventArgs e)
        {
            if (txtRef.Text != "")
            {
                int update = objbs.CancelCakeOrder(Convert.ToInt32(ViewState["orderNo"].ToString()), sTablename, txtRef.Text, lblrefundamount.Text, drpPayment.SelectedValue);
                Response.Redirect("Ordergrid.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
            }
        }

        protected void btnok1_click(object sender, EventArgs e)
        {
            {
                if (txtbookNo.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Order No Please');", true);
                }
                else
                {

                    string FullBookCode = lblbookcode.Text + txtbookNo.Text;
                    DataSet dcheckbook = objbs.checkbookno("tblOrder_" + sTablename, FullBookCode);
                    if (dcheckbook.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Check Bill Book No.Already Exists.Thank You!!!.');", true);
                        txtbookNo.Focus();
                        return;
                    }
                    else
                    {

                    }

                    Response.Redirect("OrderForm.aspx?ABookno=" + txtbookNo.Text);
                }
            }
        }

        protected void btnok_click(object sender, EventArgs e)
        {


            if (ViewState["Cmd"].ToString() == "Bill")
            {
                string billtype = "Cbill";

                if (txtnam.Text != "")
                    Response.Redirect("OrderForm.aspx?OrderNo=" + ViewState["orderNo"].ToString() + "&Name=" + txtnam.Text + "&BillType=" + billtype);
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
            }
            else if (ViewState["Cmd"].ToString() == "Editt")
            {
                string billtype = "Ebill";

                if (txtnam.Text != "")
                    Response.Redirect("OrderForm.aspx?OrderNo=" + ViewState["orderNo"].ToString() + "&Name=" + txtnam.Text + "&BillType=" + billtype);
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
            }
            else if (ViewState["Cmd"].ToString() == "PAmount")
            {
                string billtype = "PAmount";

                if (txtnam.Text != "")
                    Response.Redirect("OrderForm.aspx?OrderNo=" + ViewState["orderNo"].ToString() + "&Name=" + txtnam.Text + "&BillType=" + billtype);
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
            }
            else if (ViewState["Cmd"].ToString() == "Status")
            {
                if (txtnam.Text != "")
                {

                    DataSet dBilling = objbs.PayBill(Convert.ToInt32(ViewState["orderNo"].ToString()), sTablename);
                    if (dBilling.Tables[0].Rows.Count > 0)
                    {
                        string bal = Convert.ToDouble(dBilling.Tables[0].Rows[0]["balancepaid"]).ToString("0.00");
                        if (bal == "0" || bal == "0.00")
                        {

                            int isucess = objbs.Updstatus(ViewState["orderNo"].ToString(), txtnam.Text, sTablename, "Delivered");
                            Response.Redirect("Ordergrid.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Make Balance Amount');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
                }
            }
            else if (ViewState["Cmd"].ToString() == "PendingMSG")
            {
                if (txtnam.Text != "")
                {
                    if (txtpendingmsg.Text != "")
                    {
                        DataSet dBilling = objbs.PayBill(Convert.ToInt32(ViewState["orderNo"].ToString()), sTablename);
                        if (dBilling.Tables[0].Rows.Count > 0)
                        {


                            int isucess = objbs.UpdMSG(ViewState["orderNo"].ToString(), txtnam.Text, sTablename, txtpendingmsg.Text);
                            Response.Redirect("Ordergrid.aspx");

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Pending Reason');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
                }
            }


        }

        protected void gvorderToday_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            olddiv.Visible = false;
            Newdiv.Visible = false;
            txtpendingmsg.Visible = false;
            ViewState["orderNo"] = e.CommandArgument.ToString();
            ViewState["Cmd"] = e.CommandName;
            if (e.CommandName == "Print")
            {
                Response.Redirect("Print.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "kitPrint")
            {
                Response.Redirect("kitPrint.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "InvPrint")
            {
                DataSet checkorderno = objbs.cakeorderbillalreadypaid("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                if (checkorderno.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Take Invoice Bill This Order.Balance Amount Pending.Thank you!!!.');", true);
                    return;
                }
                else
                {

                    // string yourUrl = "SalesPrint.aspx?Mode=Order&NewiSalesID=" + ViewState["orderNo"];
                    string yourUrl = "SalesPrint.aspx?Mode=Order&Type=DineIN&NewiSalesID=" + ViewState["orderNo"] + "&User=" + Request.Cookies["userInfo"]["User"].ToString() + "&Store=" + Request.Cookies["userInfo"]["Store"].ToString() + "&StoreNo=" + Request.Cookies["userInfo"]["StoreNo"].ToString() + "&Address=" + Request.Cookies["userInfo"]["Address"].ToString() + "&TIN=" + Request.Cookies["userInfo"]["TIN"].ToString() + "&fssaino=" + Request.Cookies["userInfo"]["fssaino"].ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + yourUrl + "');", true);
                }

            }
            if (e.CommandName == "Bill")
            {
                DataSet checkorderno = objbs.cakeorderbillalreadypaid("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                if (checkorderno.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Pay Bill This Order.Already Paid Full Amount.Thank you!!!.');", true);
                    return;

                }

                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
            }
            if (e.CommandName == "Cancell")
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit This Order.Thank you!!!.');", true);
                    return;
                }

                double refund = 0;

                DataSet getpaid = objbs.getoverallpaidamount(sTablename, e.CommandArgument.ToString());
                if (getpaid.Tables[0].Rows.Count > 0)
                {
                    DataSet getrefund = objbs.getoverallrefundamount(sTablename, e.CommandArgument.ToString());
                    if (getrefund.Tables[0].Rows.Count > 0)
                    {
                        refund = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]);
                    }

                    lblrefundamount.Text = (Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]) - refund).ToString("0.00");
                }
                else
                {
                    lblrefundamount.Text = "0";
                }

                //DataSet getrefundamount = objbs.RefundAmount("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                //if (getrefundamount.Tables[0].Rows.Count > 0)
                //{
                //    lblrefundamount.Text = Convert.ToDouble(getrefundamount.Tables[0].Rows[0]["refund"]).ToString("0.00");


                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Something went Wrong while Cancel This Order.Thank you!!!.');", true);
                //    return;
                //}

                mpe.Show();


            }
            if (e.CommandName == "Editt")
            {

                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit This Order.Thank you!!!.');", true);
                    return;
                }
                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);

            }

            if (e.CommandName == "Status")
            {
                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
            }
        }

        protected void gvrest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            olddiv.Visible = false;
            Newdiv.Visible = false;
            txtpendingmsg.Visible = false;
            ViewState["orderNo"] = e.CommandArgument.ToString();
            ViewState["Cmd"] = e.CommandName;
            if (e.CommandName == "Print")
            {
                Response.Redirect("Print.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "kitPrint")
            {
                Response.Redirect("kitPrint.aspx?OrderNo=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Bill")
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit Or Pay This Order.Thank you!!!.');", true);
                    return;
                }

                DataSet checkorderno = objbs.cakeorderbillalreadypaid("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                if (checkorderno.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Pay Bill This Order.Already Paid Full Amount.Thank you!!!.');", true);
                    return;

                }


                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);

                // Response.Redirect("OrderForm.aspx?OrderNo=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Cancell")
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit This Order.Thank you!!!.');", true);
                    return;
                }

                double refund = 0;

                DataSet getpaid = objbs.getoverallpaidamount(sTablename, e.CommandArgument.ToString());
                if (getpaid.Tables[0].Rows.Count > 0)
                {
                    DataSet getrefund = objbs.getoverallrefundamount(sTablename, e.CommandArgument.ToString());
                    if (getrefund.Tables[0].Rows.Count > 0)
                    {
                        refund = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]);
                    }

                    lblrefundamount.Text = (Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]) - refund).ToString("0.00");
                }
                else
                {
                    lblrefundamount.Text = "0";
                }

                //DataSet getrefundamount = objbs.RefundAmount("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                //if (getrefundamount.Tables[0].Rows.Count > 0)
                //{
                //    lblrefundamount.Text = Convert.ToDouble(getrefundamount.Tables[0].Rows[0]["refund"]).ToString("0.00");


                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Something went Wrong while Cancel This Order.Thank you!!!.');", true);
                //    return;
                //}

                mpe.Show();

                //if (txtRefnew.Text != "")
                //{
                //    int update = objbs.CancelCakeOrder(Convert.ToInt32(ViewState["orderNo"].ToString()), sTablename, txtRefnew.Text);
                //    Response.Redirect("Ordergrid.aspx");
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Enter Your Name');", true);
                //}

            }


            if (e.CommandName == "Amount")
            {
                Response.Redirect("Amount.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "PAmount")
            {
                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
                //// DataSet edit = objbs.getorderdata(sTablename, Convert.ToInt32(e.CommandArgument.ToString()));
                // Response.Redirect("OrderForm.aspx?OrderNoEdit=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Editt")
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit This Order.Thank you!!!.');", true);
                    return;
                }
                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
                //// DataSet edit = objbs.getorderdata(sTablename, Convert.ToInt32(e.CommandArgument.ToString()));
                // Response.Redirect("OrderForm.aspx?OrderNoEdit=" + e.CommandArgument.ToString());
            }


        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            olddiv.Visible = false;
            Newdiv.Visible = false;
            txtpendingmsg.Visible = false;
            ViewState["orderNo"] = e.CommandArgument.ToString();
            ViewState["Cmd"] = e.CommandName;
            if (e.CommandName == "Print")
            {
                Response.Redirect("Print.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "kitPrint")
            {
                Response.Redirect("kitPrint.aspx?OrderNo=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Bill")
            {

                DataSet checkorderno = objbs.cakeorderbillalreadypaid("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                if (checkorderno.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Pay Bill This Order.Already Paid Full Amount.Thank you!!!.');", true);
                    return;

                }

                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
                // Response.Redirect("OrderForm.aspx?OrderNo=" + e.CommandArgument.ToString());


            }

            if (e.CommandName == "Cancell")
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit This Order.Thank you!!!.');", true);
                    return;
                }


                //DataSet getrefundamount = objbs.RefundAmount("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                //if (getrefundamount.Tables[0].Rows.Count > 0)
                //{
                //    lblrefundamount.Text = Convert.ToDouble(getrefundamount.Tables[0].Rows[0]["refund"]).ToString("0.00");

                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Something went Wrong while Cancel This Order.Thank you!!!.');", true);
                //    return;
                //}
                double refund = 0;

                DataSet getpaid = objbs.getoverallpaidamount(sTablename, e.CommandArgument.ToString());
                if (getpaid.Tables[0].Rows.Count > 0)
                {
                    DataSet getrefund = objbs.getoverallrefundamount(sTablename, e.CommandArgument.ToString());
                    if (getrefund.Tables[0].Rows.Count > 0)
                    {
                        refund = Convert.ToDouble(getrefund.Tables[0].Rows[0]["Amt"]);
                    }

                    lblrefundamount.Text = (Convert.ToDouble(getpaid.Tables[0].Rows[0]["Amt"]) - refund).ToString("0.00");
                }
                else
                {
                    lblrefundamount.Text = "0";
                }

                mpe.Show();



            }

            if (e.CommandName == "Editt")
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "OrderFormedit");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Cancel OR Edit This Order.Thank you!!!.');", true);
                    return;
                }
                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
                //// DataSet edit = objbs.getorderdata(sTablename, Convert.ToInt32(e.CommandArgument.ToString()));
                // Response.Redirect("OrderForm.aspx?OrderNoEdit=" + e.CommandArgument.ToString());
            }


            if (e.CommandName == "Amount")
            {
                Response.Redirect("Amount.aspx?OrderNo=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Status")
            {
                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
            }
            if (e.CommandName == "PendingMSG")
            {
                olddiv.Visible = true;
                txtpendingmsg.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
            }
            if (e.CommandName == "PAmount")
            {
                DataSet checkorderno = objbs.cakeorderbillalreadypaid("tblorder_" + sTablename + "", e.CommandArgument.ToString());
                if (checkorderno.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Pay Bill This Order.Already Paid Full Amount.Thank you!!!.');", true);
                    return;

                }

                olddiv.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "shw();", true);
                //// DataSet edit = objbs.getorderdata(sTablename, Convert.ToInt32(e.CommandArgument.ToString()));
                // Response.Redirect("OrderForm.aspx?OrderNoEdit=" + e.CommandArgument.ToString());
            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = ((System.Web.UI.WebControls.Label)e.Row.FindControl("lblstatus")).Text;
                Label lblstatus = (Label)e.Row.FindControl("lblstatus");

                if (objbs.IsConnectedToInternet())
                {
                    object objTemp = gvorderToday.DataKeys[e.Row.RowIndex].Value as object;
                    if (objTemp != null)
                    {
                        string id = objTemp.ToString();
                        //Do your operations
                        // Get Status
                        if (synccakeorder == "Y")
                        {
                            DataSet getstatus = objbs.getCakeSummary(id, sTablename);
                            if (getstatus.Tables[0].Rows.Count > 0)
                            {
                                lblstatus.Text = getstatus.Tables[0].Rows[0]["Deliverstatus"].ToString();
                            }
                            else
                            {

                            }
                        }
                    }


                    if (status == "Pending")
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    }
                    else if (status == "Delivered")
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    string text2 = "Please Check Your Internet Connection.Thank You!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                }



                ////string deliverytime = ((System.Web.UI.WebControls.Label)e.Row.FindControl("deliverytime")).Text;
                //string deliverytime = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "deliverytime"));
                // string currenttime = DateTime.Now.ToString("HH mm tt", CultureInfo.InvariantCulture);

                // string t1 = DateTime.Parse(deliverytime).ToString("HH mm tt");
                // DateTime t2 = DateTime.Parse(currenttime);

                // //if (t1.TimeOfDay > t2.TimeOfDay)
                // //{
                // //    //something
                // //}
                // //else
                // //{
                // //    //something else
                // //}

            }

        }


        //protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //    foreach (GridViewRow row in GridView1.Rows)
        //    {

        //        Label lblCancel = (Label)row.FindControl("lblPending");

        //      //  string aaa = lblCancel.Text;

        //        string end = row.Cells[9].Text;

        //        if ((Convert.ToInt32(lblCancel.Text)) < Convert.ToInt32(2))
        //        {
        //            ((LinkButton)e.Row.FindControl("btnBill")).Enabled = true;
        //        }

        //        else
        //        {
        //            ((LinkButton)e.Row.FindControl("btnBill")).Enabled = false;
        //        }

        //    }
        //}

        protected void GVORderToday_Rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = ((System.Web.UI.WebControls.Label)e.Row.FindControl("lblstatus")).Text;
                Label lblstatus = (Label)e.Row.FindControl("lblstatus");

                if (objbs.IsConnectedToInternet())
                {
                    object objTemp = gvorderToday.DataKeys[e.Row.RowIndex].Value as object;
                    if (objTemp != null)
                    {
                        string id = objTemp.ToString();
                        //Do your operations
                        // Get Status
                        if (synccakeorder == "Y")
                        {
                            DataSet getstatus = objbs.getCakeSummary(id, sTablename);
                            if (getstatus.Tables[0].Rows.Count > 0)
                            {
                                lblstatus.Text = getstatus.Tables[0].Rows[0]["Deliverstatus"].ToString();
                            }
                            else
                            {

                            }
                        }
                    }

                    if (status == "Pending")
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    }
                    else if (status == "Delivered")
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    string text2 = "Please Check Your Internet Connection.Thank You!!!";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                }



                ////string deliverytime = ((System.Web.UI.WebControls.Label)e.Row.FindControl("deliverytime")).Text;
                //string deliverytime = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "deliverytime"));
                // string currenttime = DateTime.Now.ToString("HH mm tt", CultureInfo.InvariantCulture);

                // string t1 = DateTime.Parse(deliverytime).ToString("HH mm tt");
                // DateTime t2 = DateTime.Parse(currenttime);

                // //if (t1.TimeOfDay > t2.TimeOfDay)
                // //{
                // //    //something
                // //}
                // //else
                // //{
                // //    //something else
                // //}

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {


            }
        }

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //if (AllowToCancel == "YES")
                //{
                //    ((System.Web.UI.WebControls.Image)e.Row.FindControl("imgcancel")).Visible = true;
                //    ((ImageButton)e.Row.FindControl("imgdisable")).Visible = false;


                //}
                //else
                //{

                //    ((System.Web.UI.WebControls.Image)e.Row.FindControl("imgcancel")).Visible = false;
                //    ((ImageButton)e.Row.FindControl("imgdisable")).Visible = true;
                //}

                string date = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PendingDays"));

                string PendingMsg = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PendingMsg"));
                //  string PendingMsg = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PendingMsg"));
                string status = ((System.Web.UI.WebControls.Label)e.Row.FindControl("lblstatus")).Text;
                Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                //string Toady = DateTime.Now.ToString("dd/MM/yyyy"); ;

                //var dateDiff = Convert.ToDateTime(Toady) - Convert.ToDateTime(date);
                //   double totalDays = dateDiff.TotalDays;

                //   if ((totalDays) < Convert.ToDouble(2))

                if ((Convert.ToInt32(date)) < Convert.ToInt32(lblpendingdays.Text))
                {
                    ((LinkButton)e.Row.FindControl("btnBill")).Enabled = true;
                }

                else
                {
                    ((LinkButton)e.Row.FindControl("btnBill")).Enabled = false;
                }
                if (synccakeorder == "Y")
                {
                    if (objbs.IsConnectedToInternet())
                    {
                        object objTemp = GridView1.DataKeys[e.Row.RowIndex].Value as object;
                        if (objTemp != null)
                        {
                            string id = objTemp.ToString();
                            //Do your operations
                            // Get Status

                            DataSet getstatus = objbs.getCakeSummary(id, sTablename);
                            if (getstatus.Tables[0].Rows.Count > 0)
                            {
                                lblstatus.Text = getstatus.Tables[0].Rows[0]["Deliverstatus"].ToString();
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }
                }

                if (status == "Pending")
                {

                    if (PendingMsg == "")
                    {
                        btnadd.Enabled = false;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Pending Order Occur.Please Enter Reason.else You Wont Allow to Thank You!!!.');", true);
                        return;
                    }
                    else
                    {
                        btnadd.Enabled = true;
                    }
                }


            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                // e.Row.Cells[13].Text = damt.ToString("f2");

            }
        }


        protected void txtcancelpassword_OnTextChanged(object sender, EventArgs e)
        {

            DataSet adminpass = objbs.GetadminCode(lblUser.Text, Password, txtcancelpassword.Text);
            if (adminpass.Tables[0].Rows.Count > 0)
            {
                AllowToCancel = "YES";

                #region
                DataSet rest = objbs.RestOrder(sTablename);
                gvrest.DataSource = rest.Tables[0];
                gvrest.DataBind();

                DataSet Pending = objbs.Pending(sTablename);
                GridView1.DataSource = Pending.Tables[0];
                GridView1.DataBind();

                DataSet Todayrest = objbs.todaydeliveryorders(sTablename);
                gvorderToday.DataSource = Todayrest.Tables[0];
                gvorderToday.DataBind();

                for (int i = 0; i < gvrest.Rows.Count; i++)
                {


                    LinkButton lblPaybill = (LinkButton)gvrest.Rows[i].FindControl("btnBill");
                    LinkButton lblCancel = (LinkButton)gvrest.Rows[i].FindControl("btncancelnew");


                    if (gvrest.Rows[i].Cells[5].Text == "0.00")
                    {
                        lblPaybill.Enabled = false;
                        lblCancel.Enabled = false;

                    }
                    if (Convert.ToDateTime(gvrest.Rows[i].Cells[6].Text).ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        lblPaybill.Enabled = false;
                    }
                }

                for (int i = 0; i < rest.Tables[0].Rows.Count; i++)
                {
                    int orderno = Convert.ToInt32(rest.Tables[0].Rows[i]["orderno"].ToString());

                    Label orderdate = (Label)gvrest.Rows[i].FindControl("lblOrderDate");

                    DataSet dts = objbs.getorderDate(sTablename, orderno);
                    if (dts.Tables[0].Rows.Count > 0)
                        orderdate.Text = dts.Tables[0].Rows[0]["OrderDate"].ToString();
                }

                for (int i = 0; i < Pending.Tables[0].Rows.Count; i++)
                {
                    int orderno = Convert.ToInt32(Pending.Tables[0].Rows[i]["orderno"].ToString());

                    Label orderdate = (Label)GridView1.Rows[i].FindControl("lblOrderDate");

                    DataSet dts = objbs.getorderDate(sTablename, orderno);
                    if (dts.Tables[0].Rows.Count > 0)
                        orderdate.Text = dts.Tables[0].Rows[0]["OrderDate"].ToString();
                }
                #endregion
            }
            else
            {
                AllowToCancel = "NO";

                #region
                DataSet rest = objbs.RestOrder(sTablename);
                gvrest.DataSource = rest.Tables[0];
                gvrest.DataBind();

                DataSet Pending = objbs.Pending(sTablename);
                GridView1.DataSource = Pending.Tables[0];
                GridView1.DataBind();

                DataSet Todayrest = objbs.todaydeliveryorders(sTablename);
                gvorderToday.DataSource = Todayrest.Tables[0];
                gvorderToday.DataBind();

                for (int i = 0; i < gvrest.Rows.Count; i++)
                {


                    LinkButton lblPaybill = (LinkButton)gvrest.Rows[i].FindControl("btnBill");
                    LinkButton lblCancel = (LinkButton)gvrest.Rows[i].FindControl("btncancelnew");


                    if (gvrest.Rows[i].Cells[5].Text == "0.00")
                    {
                        lblPaybill.Enabled = false;
                        lblCancel.Enabled = false;

                    }
                    if (Convert.ToDateTime(gvrest.Rows[i].Cells[7].Text).ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        lblPaybill.Enabled = false;
                    }
                }

                for (int i = 0; i < rest.Tables[0].Rows.Count; i++)
                {
                    int orderno = Convert.ToInt32(rest.Tables[0].Rows[i]["orderno"].ToString());

                    Label orderdate = (Label)gvrest.Rows[i].FindControl("lblOrderDate");

                    DataSet dts = objbs.getorderDate(sTablename, orderno);
                    if (dts.Tables[0].Rows.Count > 0)
                        orderdate.Text = dts.Tables[0].Rows[0]["OrderDate"].ToString();
                }

                for (int i = 0; i < Pending.Tables[0].Rows.Count; i++)
                {
                    int orderno = Convert.ToInt32(Pending.Tables[0].Rows[i]["orderno"].ToString());

                    Label orderdate = (Label)GridView1.Rows[i].FindControl("lblOrderDate");

                    DataSet dts = objbs.getorderDate(sTablename, orderno);
                    if (dts.Tables[0].Rows.Count > 0)
                        orderdate.Text = dts.Tables[0].Rows[0]["OrderDate"].ToString();
                }
                #endregion

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Enter Correct Password...');", true);
                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
                return;

            }

        }

        protected void btnsyncclick_OnClick(object sender, EventArgs e)
        {

            connnectionString = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            connnectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;

            SqlConnection source = new SqlConnection(connnectionString);
            SqlConnection destination = new SqlConnection(connnectionStringMain);


            source.Open();
            destination.Open();

            SqlCommand cmdsales = new SqlCommand("Select * from tblOrder_" + sTablename + " where isnull(IsTransfer,0)=0", source);
            SqlCommand cmdtranssales = new SqlCommand("Select * from tblTransOrder_" + sTablename + " where isnull(IsTransfer,0)=0", source);


            SqlBulkCopy bulkData = new SqlBulkCopy(destination);
            SqlBulkCopy bulkDataUpdate = new SqlBulkCopy(source);

            SqlDataReader reader = cmdsales.ExecuteReader();
            bulkData.DestinationTableName = "tblOrder_" + sTablename + "";
            bulkData.WriteToServer(reader);
            reader.Close();


            int iSuccess = 0;
            string sQry = "Update tblOrder_" + sTablename + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);

            SqlDataReader reader1 = cmdtranssales.ExecuteReader();
            bulkData.DestinationTableName = "tblTransOrder_" + sTablename + "";
            bulkData.WriteToServer(reader1);
            reader1.Close();

            sQry = "Update tblTransOrder_" + sTablename + " set IsTransfer=1";
            iSuccess = DBAccess.InlineExecuteNonQuery(sQry);



            bulkData.Close();
            source.Close();
            destination.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Thank You!!!.');", true);


        }

    }
}