using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLayer;
using System.Text;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Configuration;


namespace Billing.Accountsbootstrap
{
    public partial class Order_DayReport : System.Web.UI.Page
    {

        BSClass objbs = new BSClass();

        string sTableName = "";
        string AllBranchAccess = "0";
        string store = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();
            store = Request.Cookies["userInfo"]["Store"].ToString();
            if (!IsPostBack)
            {


                if (radbtnlist.SelectedValue != "0")
                {
                    RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                    RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();
                }

                DataSet dsbranch;
                if (AllBranchAccess == "True")
                    dsbranch = objbs.GetBranch_New("All");
                else
                    dsbranch = objbs.GetBranch_New(sTableName);

                ddlBranch.DataSource = dsbranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "Branchcode";
                ddlBranch.DataBind();
                if (AllBranchAccess == "True")
                    ddlBranch.Items.Insert(0, "All");
                else
                    ddlBranch.Enabled = false;
               

                //gvAdvance.DataSource = null;
                //gvAdvance.DataBind();
                //gvAdvance.Caption = "Todays Advance Paid";

                //gvorderedqty.DataSource = null;
                //gvorderedqty.DataBind();
                //gvorderedqty.Caption = "Todays Ordered Qty";




            }
        }

        protected void delivery_detailed(object sender, EventArgs e)
        {

            gvAdvance.Visible = false;
            gvorderedqty.Visible = false;
            gvorderinfo.Visible = true;
            //GET DATA

           

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



        public void SendHTMLMail()
        {
            MailMessage Msg = new MailMessage();
            MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
            // Sender e-mail address.
            Msg.From = fromMail;
           
            // Subject of e-mail
            Msg.Subject = "Send Order Form Details For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += GetGridviewData(gvorderinfo);
            Msg.IsBodyHtml = true;

            string mutltiemail = txtemail.Text;

            string[] Multi = mutltiemail.Split(',');
            foreach(string Multiemailid in Multi)
            {
            Msg.To.Add(new MailAddress(Multiemailid));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            }

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

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }



        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            idtodate.Visible = false;
            if (radbtnlist.SelectedValue == "0")
            {
                if (txtfromdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Select Date.Thank you!!!.');", true);
                    return;
                }

                {
                    RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(366)).ToShortDateString();
                    RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                    RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(366)).ToShortDateString();
                    RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();
                }


                idtodate.Visible = true;

                DataTable dt = new DataTable();
                dt.Columns.Add("Book No");
                dt.Columns.Add("Branch");
                dt.Columns.Add("Order No");
                dt.Columns.Add("Order Date");
                dt.Columns.Add("Delivery Date");
                dt.Columns.Add("Customer Name");
                dt.Columns.Add("Mobilno");
                dt.Columns.Add("NetTotal");
                dt.Columns.Add("Total");
                dt.Columns.Add("Advance");
                dt.Columns.Add("Item");
                dt.Columns.Add("Dstatus");

                //if (sTableName == "admin")
                //{
                //    DataSet dsp = objbs.Currentlist(DDlbranch.SelectedValue, txtFrom.Text, txtto.Text);

                //    for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
                //    {
                //dt.Rows.Add(dr);
                //        DataRow dr = dt.NewRow();

                // string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime sDate = Convert.ToDateTime(txtfromdate.Text);
                DateTime tdate = Convert.ToDateTime(txttodate.Text);
                 DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.GetCakerOrderINFONew("tblorder_" + ds1.Tables[0].Rows[i]["BranchCode"].ToString() + "", sDate, tdate, ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        getorderinfo.Merge(dsgrid);
                    }
                }
                else
                {
                    getorderinfo = objbs.GetCakerOrderINFONew("tblorder_" + ddlBranch.SelectedValue + "", sDate, tdate,ddlBranch.SelectedValue);
                }
                if (getorderinfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
                    {

                        DataRow dr = dt.NewRow();
                        string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
                        dr["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
                        dr["Branch"] = getorderinfo.Tables[0].Rows[i]["bname"].ToString();
                        dr["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
                      //  dr["Order Date"] = getorderinfo.Tables[0].Rows[i]["orderdate"].ToString();
                        dr["Order Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["orderdate"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                        dr["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MM/yyyy");
                        dr["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
                        dr["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
                        dr["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
                        dr["Total"] = Convert.ToDouble(getorderinfo.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dr["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();
                        dr["Dstatus"] = getorderinfo.Tables[0].Rows[i]["DeliveryStatus"].ToString();


                        DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + getorderinfo.Tables[0].Rows[i]["bname"].ToString() + "", billno);
                        if (getorderitem.Tables[0].Rows.Count > 0)
                        {
                            string itemqty = string.Empty;

                            for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
                            {
                                itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
                            }
                            
                            // itemqty = itemqty.Replace(',', '\n');
                            // itemqty = itemqty.Replace(",", System.Environment.NewLine);
                            itemqty = itemqty.TrimEnd(',');
                            dr["Item"] = itemqty;
                        }
                        dt.Rows.Add(dr);
                    }
                    gvorderinfo.Caption = store +" Cake Order Remainder Report ";
                    gvorderinfo.DataSource = dt;
                    gvorderinfo.DataBind();


                }

                gvAdvance.Visible = false;
                gvorderedqty.Visible = false;
                gvorderinfo.Visible = true;


                SendHTMLMail();
            }
            
        }
        protected void Radbtn_chnaged(object sender, EventArgs e)
        {
            idtodate.Visible = false;
            if (radbtnlist.SelectedValue == "0")
            {

                //if (radbtnlist.SelectedValue != "0")
                {
                    RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(366)).ToShortDateString();
                    RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                    RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(366)).ToShortDateString();
                    RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();
                }


                idtodate.Visible = true;

                if (txtfromdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Select Date.Thank you!!!.');", true);
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Book No");
                dt.Columns.Add("Branch");
                dt.Columns.Add("Order No");
                dt.Columns.Add("Order Date");
                dt.Columns.Add("Delivery Date");
                dt.Columns.Add("Customer Name");
                dt.Columns.Add("Mobilno");
                dt.Columns.Add("NetTotal");
                dt.Columns.Add("Total");
                dt.Columns.Add("Advance");
                dt.Columns.Add("Item");
                dt.Columns.Add("Dstatus");

                //if (sTableName == "admin")
                //{
                //    DataSet dsp = objbs.Currentlist(DDlbranch.SelectedValue, txtFrom.Text, txtto.Text);

                //    for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
                //    {
                //dt.Rows.Add(dr);
                //        DataRow dr = dt.NewRow();

                // string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime sDate = Convert.ToDateTime(txtfromdate.Text);
                DateTime tdate = Convert.ToDateTime(txttodate.Text);
                DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.GetCakerOrderINFONew("tblorder_" + ds1.Tables[0].Rows[i]["BranchCode"].ToString() + "", sDate, tdate, ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        getorderinfo.Merge(dsgrid);
                    }
                }
                else
                {
                    getorderinfo = objbs.GetCakerOrderINFONew("tblorder_" + ddlBranch.SelectedValue + "", sDate, tdate, ddlBranch.SelectedValue);
                }
                
                if (getorderinfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
                    {

                        DataRow dr = dt.NewRow();
                        string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
                        dr["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
                        dr["Branch"] = getorderinfo.Tables[0].Rows[i]["bname"].ToString();
                        dr["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
                        dr["Order Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["orderdate"]).ToString("dd/MMM/yyyy hh:mm:ss tt");
                        dr["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MMM/yyyy");
                        dr["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
                        dr["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
                        dr["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
                        dr["Total"] = Convert.ToDouble(getorderinfo.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dr["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();
                        dr["Dstatus"] = getorderinfo.Tables[0].Rows[i]["DeliveryStatus"].ToString();


                        DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + getorderinfo.Tables[0].Rows[i]["bname"].ToString() + "", billno);
                        if (getorderitem.Tables[0].Rows.Count > 0)
                        {
                            string itemqty = string.Empty;

                            for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
                            {
                                itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
                            }
                            itemqty = itemqty.TrimEnd(',');
                            // itemqty = itemqty.Replace(',', '\n');
                            // itemqty = itemqty.Replace(",", System.Environment.NewLine);
                            dr["Item"] = itemqty;
                        }
                        dt.Rows.Add(dr);
                    }
                    gvorderinfo.Caption = "Cake Order Remainder Report";
                    gvorderinfo.DataSource = dt;
                    gvorderinfo.DataBind();


                }

                gvAdvance.Visible = false;
                gvorderedqty.Visible = false;
                gvorderinfo.Visible = true;

            }
            else if (radbtnlist.SelectedValue == "1")
            {
                 DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                DataSet ds = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.Report_TodaysAdvancePaid(ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        ds.Merge(dsgrid);
                    }
                }
                else
                {
                     ds = objbs.Report_TodaysAdvancePaid(ddlBranch.SelectedValue);
                }
                
                gvAdvance.DataSource = ds;
                gvAdvance.DataBind();
                gvAdvance.Caption = "Todays Advance Paid";

                gvAdvance.Visible = true;
                gvorderedqty.Visible = false;
                gvorderinfo.Visible = false;
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                 DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                DataSet dss1 = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.Report_TodaysTotalQty(ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        dss1.Merge(dsgrid);
                    }
                }
                else
                {
                     dss1 = objbs.Report_TodaysTotalQty(ddlBranch.SelectedValue);
                }

                gvorderedqty.DataSource = dss1;
                gvorderedqty.DataBind();
                gvorderedqty.Caption = "Todays Ordered Qty";

                gvAdvance.Visible = false;
                gvorderedqty.Visible = true;
                gvorderinfo.Visible = false;
            }

        }
        protected void rbadvance_CheckedChanged(object sender, EventArgs e)
        {
            //  rborderqty.Checked = false;
           

        }
        protected void rborderqty_CheckedChanged(object sender, EventArgs e)
        {
            //  rbadvance.Checked = false;
            gvAdvance.Visible = false;
            gvorderedqty.Visible = true;
            gvorderinfo.Visible = false; ;
        }


        protected void btnser_Click(object sender, EventArgs e)
        {

            //if (radbtnlist.SelectedValue == "0")
            //{
            //    if (txtfromdate.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Select Date.Thank you!!!.');", true);
            //        return;
            //    }


            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("Book No");
            //    dt.Columns.Add("Order No");
            //    dt.Columns.Add("Order Date");
            //    dt.Columns.Add("Delivery Date");
            //    dt.Columns.Add("Customer Name");
            //    dt.Columns.Add("Mobilno");
            //    dt.Columns.Add("NetTotal");
            //    dt.Columns.Add("Total");
            //    dt.Columns.Add("Advance");
            //    dt.Columns.Add("Item");
            //    dt.Columns.Add("Dstatus");

            //    //if (sTableName == "admin")
            //    //{
            //    //    DataSet dsp = objbs.Currentlist(DDlbranch.SelectedValue, txtFrom.Text, txtto.Text);

            //    //    for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
            //    //    {
            //    //dt.Rows.Add(dr);
            //    //        DataRow dr = dt.NewRow();

            //    // string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
            //    DateTime sDate = Convert.ToDateTime(txtfromdate.Text);
            //    DateTime tdate = Convert.ToDateTime(txttodate.Text);

            //    DataSet getorderinfo = objbs.GetCakerOrderINFONew("tblorder_" + sTableName + "", sDate,tdate);
            //    if (getorderinfo.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
            //        {

            //            DataRow dr = dt.NewRow();
            //            string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
            //            dr["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
            //            dr["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
            //       //     dr["Order Date"] = getorderinfo.Tables[0].Rows[i]["orderdate"].ToString();
            //            dr["Order Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["orderdate"]).ToString("dd/MMM/yyyy  hh:mm:ss tt", CultureInfo.InvariantCulture);
                    
            //            dr["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MMM/yyyy");
            //            dr["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
            //            dr["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
            //            dr["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
            //            dr["Total"] = Convert.ToDouble(getorderinfo.Tables[0].Rows[i]["Total"]).ToString("0.00");
            //            dr["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();
            //            dr["Dstatus"] = getorderinfo.Tables[0].Rows[i]["DeliveryStatus"].ToString();


            //            DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + sTableName + "", billno);
            //            if (getorderitem.Tables[0].Rows.Count > 0)
            //            {
            //                string itemqty = string.Empty;

            //                for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
            //                {
            //                    itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
            //                }
            //                itemqty = itemqty.TrimEnd(',');
            //                // itemqty = itemqty.Replace(',', '\n');
            //                // itemqty = itemqty.Replace(",", System.Environment.NewLine);
            //                dr["Item"] = itemqty;
            //            }
            //            dt.Rows.Add(dr);
            //        }
            //        gvorderinfo.Caption = "Cake Order Remainder Report";
            //        gvorderinfo.DataSource = dt;
            //        gvorderinfo.DataBind();


            //    }

            //    gvAdvance.Visible = false;
            //    gvorderedqty.Visible = false;
            //    gvorderinfo.Visible = true;

            //}
            //else if (radbtnlist.SelectedValue == "1")
            //{

            //    DataSet ds = objbs.Report_TodaysAdvancePaid(sTableName);
            //    gvAdvance.DataSource = ds;
            //    gvAdvance.DataBind();
            //    gvAdvance.Caption = "Todays Advance Paid";

            //    gvAdvance.Visible = true;
            //    gvorderedqty.Visible = false;
            //    gvorderinfo.Visible = false;
            //}
            //else if (radbtnlist.SelectedValue == "2")
            //{
            //    DataSet ds1 = objbs.Report_TodaysTotalQty(sTableName);
            //    gvorderedqty.DataSource = ds1;
            //    gvorderedqty.DataBind();
            //    gvorderedqty.Caption = "Todays Ordered Qty";

            //    gvAdvance.Visible = false;
            //    gvorderedqty.Visible = true;
            //    gvorderinfo.Visible = false;
            //}

            idtodate.Visible = false;
            if (radbtnlist.SelectedValue == "0")
            {

                //if (radbtnlist.SelectedValue != "0")
                {
                    RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(366)).ToShortDateString();
                    RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                    RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(366)).ToShortDateString();
                    RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();
                }


                idtodate.Visible = true;

                if (txtfromdate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Please Select Date.Thank you!!!.');", true);
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Book No");
                dt.Columns.Add("Branch");
                dt.Columns.Add("Order No");
                dt.Columns.Add("Order Date");
                dt.Columns.Add("Delivery Date");
                dt.Columns.Add("Customer Name");
                dt.Columns.Add("Mobilno");
                dt.Columns.Add("NetTotal");
                dt.Columns.Add("Total");
                dt.Columns.Add("Advance");
                dt.Columns.Add("Item");
                dt.Columns.Add("Dstatus");

                //if (sTableName == "admin")
                //{
                //    DataSet dsp = objbs.Currentlist(DDlbranch.SelectedValue, txtFrom.Text, txtto.Text);

                //    for (int i = 0; i < dsp.Tables[0].Rows.Count; i++)
                //    {
                //dt.Rows.Add(dr);
                //        DataRow dr = dt.NewRow();

                // string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime sDate = Convert.ToDateTime(txtfromdate.Text);
                DateTime tdate = Convert.ToDateTime(txttodate.Text);
                DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.GetCakerOrderINFONew("tblorder_" + ds1.Tables[0].Rows[i]["BranchCode"].ToString() + "", sDate, tdate, ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        getorderinfo.Merge(dsgrid);
                    }
                }
                else
                {
                    getorderinfo = objbs.GetCakerOrderINFONew("tblorder_" + ddlBranch.SelectedValue + "", sDate, tdate,ddlBranch.SelectedValue);
                }

                if (getorderinfo.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < getorderinfo.Tables[0].Rows.Count; i++)
                    {

                        DataRow dr = dt.NewRow();
                        string billno = getorderinfo.Tables[0].Rows[i]["Billno"].ToString();
                        dr["Book No"] = getorderinfo.Tables[0].Rows[i]["Bookno"].ToString();
                        dr["Branch"] = getorderinfo.Tables[0].Rows[i]["bname"].ToString();
                        dr["Order No"] = getorderinfo.Tables[0].Rows[i]["orderno"].ToString();
                        dr["Order Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["orderdate"]).ToString("dd/MMM/yyyy hh:mm:ss tt");
                        dr["Delivery Date"] = Convert.ToDateTime(getorderinfo.Tables[0].Rows[i]["Deliverydate"]).ToString("dd/MMM/yyyy");
                        dr["Customer Name"] = getorderinfo.Tables[0].Rows[i]["customername"].ToString();
                        dr["Mobilno"] = getorderinfo.Tables[0].Rows[i]["mobileno"].ToString();
                        dr["NetTotal"] = getorderinfo.Tables[0].Rows[i]["netamount"].ToString();
                        dr["Total"] = Convert.ToDouble(getorderinfo.Tables[0].Rows[i]["Total"]).ToString("0.00");
                        dr["Advance"] = getorderinfo.Tables[0].Rows[i]["Advance"].ToString();
                        dr["Dstatus"] = getorderinfo.Tables[0].Rows[i]["DeliveryStatus"].ToString();


                        DataSet getorderitem = objbs.GetCakerOrderItemINFO("tbltransorder_" + getorderinfo.Tables[0].Rows[i]["bname"].ToString() + "", billno);
                        if (getorderitem.Tables[0].Rows.Count > 0)
                        {
                            string itemqty = string.Empty;

                            for (int j = 0; j < getorderitem.Tables[0].Rows.Count; j++)
                            {
                                itemqty += getorderitem.Tables[0].Rows[j]["itemna"].ToString() + ",";
                            }
                            itemqty = itemqty.TrimEnd(',');
                            // itemqty = itemqty.Replace(',', '\n');
                            // itemqty = itemqty.Replace(",", System.Environment.NewLine);
                            dr["Item"] = itemqty;
                        }
                        dt.Rows.Add(dr);
                    }
                    gvorderinfo.Caption = "Cake Order Remainder Report";
                    gvorderinfo.DataSource = dt;
                    gvorderinfo.DataBind();


                }

                gvAdvance.Visible = false;
                gvorderedqty.Visible = false;
                gvorderinfo.Visible = true;

            }
            else if (radbtnlist.SelectedValue == "1")
            {
                DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                DataSet ds = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.Report_TodaysAdvancePaid(ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        ds.Merge(dsgrid);
                    }
                }
                else
                {
                    ds = objbs.Report_TodaysAdvancePaid(ddlBranch.SelectedValue);
                }

                gvAdvance.DataSource = ds;
                gvAdvance.DataBind();
                gvAdvance.Caption = "Todays Advance Paid";

                gvAdvance.Visible = true;
                gvorderedqty.Visible = false;
                gvorderinfo.Visible = false;
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                DataSet dsgrid = new DataSet();
                DataSet getorderinfo = new DataSet();
                DataSet dss1 = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dsgrid = objbs.Report_TodaysTotalQty(ds1.Tables[0].Rows[i]["BranchCode"].ToString());
                        dss1.Merge(dsgrid);
                    }
                }
                else
                {
                    dss1 = objbs.Report_TodaysTotalQty(ddlBranch.SelectedValue);
                }

                gvorderedqty.DataSource = dss1;
                gvorderedqty.DataBind();
                gvorderedqty.Caption = "Todays Ordered Qty";

                gvAdvance.Visible = false;
                gvorderedqty.Visible = true;
                gvorderinfo.Visible = false;
            }



        }





    }
}