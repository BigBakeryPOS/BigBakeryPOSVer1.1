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
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Net.Mail;
using System.Configuration;

namespace Billing.Accountsbootstrap
{
    public partial class OrderAssign_old : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string sUserChk = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            lblUser.Text = Session["UserName"].ToString();
            lblUserID.Text = Session["UserID"].ToString();

            sTableName = Session["BranchCode"].ToString();
            sUserChk = Session["IsSuperAdmin"].ToString();

            if (!IsPostBack)
            {

                if (sUserChk == "0")
                {

                    DataSet dsCustomer = objBs.getbranchforhomepage();
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        drpbranch.DataSource = dsCustomer.Tables[0];
                        drpbranch.DataTextField = "brancharea";
                        drpbranch.DataValueField = "branchname";
                        drpbranch.DataBind();
                        drpbranch.Items.Insert(0, "All");

                        drpbranch.SelectedItem.Text = sTableName;
                        drpbranch.Enabled = false;

                        DataSet ds = objBs.getallempandsupp("17");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            drpemployeeassign.DataSource = ds.Tables[0];
                            drpemployeeassign.DataTextField = "CustomerName";
                            drpemployeeassign.DataValueField = "IDCust";
                            drpemployeeassign.DataBind();
                            drpemployeeassign.Items.Insert(0, "Select Employee");
                        }

                        DataSet dsnew = objBs.getSubStatusName("1");
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            ddlsubstatus.DataSource = dsnew.Tables[0];
                            ddlsubstatus.DataTextField = "CustomerName";
                            ddlsubstatus.DataValueField = "IDCust";
                            ddlsubstatus.DataBind();
                            ddlsubstatus.Items.Insert(0, "Select SubStatus");
                        }

                    }
                }
                else
                {
                    drpbranch.Enabled = true;

                    DataSet dsCustomer = objBs.getbranchforhomepage();
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        drpbranch.DataSource = dsCustomer.Tables[0];
                        drpbranch.DataTextField = "brancharea";
                        drpbranch.DataValueField = "branchname";
                        drpbranch.DataBind();
                        drpbranch.Items.Insert(0, "All");


                    }


                    DataSet ds = objBs.getallempandsupp("17");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        drpemployeeassign.DataSource = ds.Tables[0];
                        drpemployeeassign.DataTextField = "CustomerName";
                        drpemployeeassign.DataValueField = "IDCust";
                        drpemployeeassign.DataBind();
                        drpemployeeassign.Items.Insert(0, "Select Employee");
                    }

                    DataSet dsnew = objBs.getSubStatusName("1");
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        ddlsubstatus.DataSource = dsnew.Tables[0];
                        ddlsubstatus.DataTextField = "SubStatusName";
                        ddlsubstatus.DataValueField = "SubStatusId";
                        ddlsubstatus.DataBind();
                        //     ddlsubstatus.Items.Insert(0, "Select SubStatus");
                    }
                }


                // Get status
                DataSet dsstaus = objBs.getonlinesttus();
                if (dsstaus.Tables[0].Rows.Count > 0)
                {
                    drpstatus.DataSource = dsstaus.Tables[0];
                    drpstatus.DataTextField = "statusname";
                    drpstatus.DataValueField = "statusid";
                    drpstatus.DataBind();
                    drpstatus.Items.Insert(0, "All");
                }

                drpstatus.SelectedValue = "2";

                txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ToDate = FromDate.AddDays(1);
                txttodate.Text = ToDate.ToString("dd/MM/yyyy");

                Getcount();
                Getorderdetails();
            }


        }


        public void Getcount()
        {

            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime TooDate = FromDate.AddDays(1);
            txttodate.Text = TooDate.ToString("dd/MM/yyyy");

            DateTime ToDate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objBs.getordercount_summary(drpbranch.SelectedValue, FromDate.ToString(), raddatetype.SelectedValue, ToDate.ToString(), lbltime.Text);
            if (ds.Tables.Count > 0)
            {

                #region STATUs SHOWN

                DataTable dttNew = new DataTable();
                DataSet dsnew = new DataSet();
                DataRow drNew;
                dttNew.Columns.Add("status");
                dttNew.Columns.Add("cnt");
                dsnew.Tables.Add(dttNew);

                var result = from r in ds.Tables[0].AsEnumerable()
                             group r by new { status = r["Statusname"] } into g
                             select new
                             {
                                 statusname = g.Key.status,
                                 total = g.Sum(x => Convert.ToInt32(x["cnt"])),

                             };

                foreach (var g in result)
                {
                    drNew = dttNew.NewRow();

                    drNew["status"] = g.statusname;
                    drNew["cnt"] = g.total;

                    dsnew.Tables[0].Rows.Add(drNew);
                }

                gridstatus.DataSource = dsnew.Tables[0];
                gridstatus.DataBind();
            }

            //DataSet getallAcceptedstatus = objBs.getstatuscakes(drpbranch.SelectedValue, "Accepted");
            //if (getallAcceptedstatus.Tables[0].Rows.Count > 0)
            //{
            //    lblaccpeted.Text = "(" + getallAcceptedstatus.Tables[0].Rows.Count.ToString() + ")";
            //}
            //else
            //{
            //    lblaccpeted.Text = "(" + 0 + ")";
            //}

            //DataSet getallAssignedstatus = objBs.getstatuscakes(drpbranch.SelectedValue, "Assigned");
            //if (getallAssignedstatus.Tables[0].Rows.Count > 0)
            //{
            //    lblassign.Text = "(" + getallAssignedstatus.Tables[0].Rows.Count.ToString() + ")";
            //}
            //else
            //{
            //    lblassign.Text = "(" + 0 + ")";
            //}


            //DataSet getallCompletedstatus = objBs.getstatuscakes(drpbranch.SelectedValue, "Completed");
            //if (getallCompletedstatus.Tables[0].Rows.Count > 0)
            //{
            //    lblcompleted.Text = "(" + getallCompletedstatus.Tables[0].Rows.Count.ToString() + ")";
            //}
            //else
            //{
            //    lblcompleted.Text = "(" + 0 + ")";
            //}

            //DataSet getallTransitstatus = objBs.getstatuscakes(drpbranch.SelectedValue, "Transit");
            //if (getallTransitstatus.Tables[0].Rows.Count > 0)
            //{
            //    lbltransit.Text = "(" + getallTransitstatus.Tables[0].Rows.Count.ToString() + ")";
            //}
            //else
            //{
            //    lbltransit.Text = "(" + 0 + ")";
            //}



                #endregion
        }

        public void Getorderdetails()
        {

            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime TooDate = FromDate.AddDays(1);
            txttodate.Text = TooDate.ToString("dd/MM/yyyy");

            DateTime ToDate = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objBs.getordercount_summaryDetails(drpbranch.SelectedValue, FromDate.ToString(), raddatetype.SelectedValue, drpstatus.SelectedValue, sTableName, ToDate.ToString(), lbltime.Text);

            DataSet dssub = objBs.getSubOrdersummary();
            bool exists = false;

            DataTable dt = ds.Tables[0].Clone();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                exists = false;
                for (int j = 0; j < dssub.Tables[0].Rows.Count; j++)
                {
                    if ((ds.Tables[0].Rows[i]["OrderNo"].ToString().Trim() == dssub.Tables[0].Rows[j]["OrderNo"].ToString().Trim()) && (ds.Tables[0].Rows[i]["BookNo"].ToString().Trim() == dssub.Tables[0].Rows[j]["BookNo"].ToString().Trim()) && (ds.Tables[0].Rows[i]["BranchCode"].ToString().Trim() == dssub.Tables[0].Rows[j]["BranchCode"].ToString().Trim()) && (Convert.ToInt16(dssub.Tables[0].Rows[j]["SubStatusId"]) == Convert.ToInt16(ddlsubstatus.SelectedValue)))
                    {
                        exists = true;
                    }
                }
                if (exists == false)
                {
                    dt.ImportRow(ds.Tables[0].Rows[i]);
                }
            }

            if (dt.Rows.Count > 0)
            {
                if (drpbranch.SelectedValue != "All")
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "Branchcode='" + drpbranch.SelectedValue + "'";


                    BankGrid.DataSource = dv;
                    BankGrid.DataBind();
                }
                else
                {
                    BankGrid.DataSource = dt;
                    BankGrid.DataBind();
                }
            }

            else
            {
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }

        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {

            SendHTMLMail();
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
            // Msg.AlternateViews.Add(avHtml);

            // Address and send the message
            Msg.From = new MailAddress("jothics0792@gmail.com", "SRI RAM LALA");
            // MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
            // Sender e-mail address.
            //Msg.From = fromMail;

            // Subject of e-mail
            Msg.Subject = "Send Order Form Details For " + sTableName + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += GetGridviewData(BankGrid);
            Msg.IsBodyHtml = true;

            string mutltiemail = txtemail.Text;

            string[] Multi = mutltiemail.Split(',');
            foreach (string Multiemailid in Multi)
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

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            sTableName = Session["User"].ToString();



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList drpemployeeassign = (DropDownList)(e.Row.FindControl("drpemployeeassign") as DropDownList);
                CheckBox chitem = (CheckBox)(e.Row.FindControl("chkitem") as CheckBox);
               //   this.btnvalue.Click += new System.EventHandler(this.btnvalue_Click);
                  chitem.CheckedChanged += new System.EventHandler(this.chkitem_oncheckedchanged);
                //DataSet ds = objBs.getallempandsupp("17");
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    drpemployeeassign.DataSource = ds.Tables[0];
                //    drpemployeeassign.DataTextField = "CustomerName";
                //    drpemployeeassign.DataValueField = "IDCust";
                //    drpemployeeassign.DataBind();
                //    drpemployeeassign.Items.Insert(0, "Select Employee");
                //}

                GridView gv = e.Row.FindControl("GridView11") as GridView;
                GridView gvGroup = (GridView)sender;

                string id = (gvGroup.DataKeys[e.Row.RowIndex].Values[0]).ToString();
                string branchcode = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();

                if (gvGroup.DataKeys[e.Row.RowIndex].Values[0].ToString() != "")
                {
                    DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DataSet dst = objBs.getbranchordersummaryitem(id, branchcode, FromDate.ToString(), raddatetype.SelectedValue);

                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = dst;
                        gv.DataBind();
                    }
                    else
                    {
                        gv.DataSource = null;
                        gv.DataBind();
                    }

                }
            }
        }


        protected void refresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderSummaryNewGrid.aspx");
        }


        protected void Pending_click(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objBs.getbranchordersummary(drpbranch.SelectedValue, FromDate.ToString(), sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                    BankGrid.Columns[10].Visible = false;
                }
                else
                {
                    lblpending.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                    BankGrid.Columns[10].Visible = false;
                }
            }
            else
            {
                lblpending.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
                BankGrid.Columns[10].Visible = false;
            }

        }
        protected void Accept_chnaged(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objBs.getbranchordersummary_Status(drpbranch.SelectedValue, FromDate.ToString(), "Accepted", sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                    BankGrid.Columns[10].Visible = true;
                }
                else
                {
                    lblpending.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                    BankGrid.Columns[10].Visible = true;
                }
            }
            else
            {
                lblpending.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
                BankGrid.Columns[10].Visible = true;
            }
        }

        protected void Assign_chnaged(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objBs.getbranchordersummary_Status(drpbranch.SelectedValue, FromDate.ToString(), "Assigned", sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                    BankGrid.Columns[10].Visible = true;
                }
                else
                {
                    lblpending.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                    BankGrid.Columns[10].Visible = true;
                }
            }
            else
            {
                lblpending.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
        }

        protected void Completed_chnaged(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objBs.getbranchordersummary_Status(drpbranch.SelectedValue, FromDate.ToString(), "Completed", sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                }
                else
                {
                    lblpending.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
            }
            else
            {
                lblpending.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
        }


        //protected void Completed_chnaged(object sender, EventArgs e)
        //{
        //    DataSet ds = objBs.getbranchordersummary_Status(drpbranch.SelectedValue, txtfromdate.Text, "Transit");
        //    if (ds.Tables.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
        //            BankGrid.DataSource = ds;
        //            BankGrid.DataBind();
        //        }
        //        else
        //        {
        //            lblpending.Text = "(" + 0 + ")";
        //            BankGrid.DataSource = null;
        //            BankGrid.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        lblpending.Text = "(" + 0 + ")";
        //        BankGrid.DataSource = null;
        //        BankGrid.DataBind();
        //    }
        //}


        protected void Transit_chnaged(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objBs.getbranchordersummary_Status(drpbranch.SelectedValue, FromDate.ToString(), "Transit", sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                }
                else
                {
                    lblpending.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
            }
            else
            {
                lblpending.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
        }

        protected void Delivered_chnaged(object sender, EventArgs e)
        {
            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DataSet ds = objBs.getbranchordersummary_Status(drpbranch.SelectedValue, FromDate.ToString(), "Delivered", sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbldelivered.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                }
                else
                {
                    lbldelivered.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
            }
            else
            {
                lbldelivered.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderSummaryNewGrid.aspx");

        }
        //

        protected void bankgrid_rowcommand(object sender, GridViewCommandEventArgs e)
        {


            
            //if (e.CommandName == "Process")
            //{
            //    string[] arg = new string[3];
            //    arg = e.CommandArgument.ToString().Split(';');
            //    string billno = arg[0];
            //    string branccode = arg[1];
            //    string status = arg[2];

            //    if (status == "Pending")
            //    {
            //        int i = objBs.InsertStatus(billno, branccode, "2", "Accept & Assign", lblUser.Text);
            //        //Response.Redirect("orderassign.aspx");
            //        Getcount();
            //        Getorderdetails();
            //    }
            //    else if (status == "Accept & Assign")
            //    {
            //        int i = objBs.InsertStatus(billno, branccode, "4", "Completed", lblUser.Text);

            //        //Response.Redirect("OrderSummaryNewGrid.aspx");
            //        Getcount();
            //        Getorderdetails();
            //    }
            //    else if (status == "Completed")
            //    {
            //        Getcount();
            //        Getorderdetails();
            //        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Well Done!!!.Please Make Ready For Transit In Delivery Entry.Thank You!!!.');", true);
            //        return;
            //        // int i = objBs.InsertStatus(billno, branccode, "5", "Transit");
            //        //Response.Redirect("OrderSummaryNewGrid.aspx");


            //    }
             


            //}
         
            if (e.CommandName == "KotPrint")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string orderno = arg[0];
                    string branccode = arg[1];

                    // Response.Redirect("Kitprint.aspx?OrderNo=" + orderno + "&comefrom=Ordersummary&Bcode=" + branccode);
                    string yourUrl1 = "Kitprint.aspx?OrderNo=" + orderno + "&comefrom=Ordersummary&Bcode=" + branccode;

                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", " PrintPanel()", true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow2", "window.open('" + yourUrl1 + "');", true);
                }
            }
        }

        protected void ddlemployee_Chnaged(object sender, EventArgs e)
        {
            if (drpemployeeassign.SelectedValue == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Not able to Assign.Please Select Valid Employee!!!');", true);
                return;

            }
            else
            {
                //         int iupdatemployee = objBs.IUpdateEmployee(lblbillno.Text, lblbranchcode.Text, ddlcategory1.SelectedValue);
                Assign_chnaged(sender, e);
            }

            Getcount();
            Getorderdetails();
        }

        protected void BankGrid_SelectedIndexChanged(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = BankGrid.SelectedRow;

            string status = row.Cells[6].Text;

            if (status == "YES")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Not able to Delete. Purchase Invoice Generated for this Purchase Order!!!');", true);
                return;
            }
        }

        protected void BankGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "KotPrint")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("Kitprint.aspx?OrderNo=" + e.CommandArgument.ToString());
                }
            }

            //else if (e.CommandName == "delete")
            //{

            //    int iSucess = objBs.deletePURordermaster(e.CommandArgument.ToString(), sTableName);
            //    Response.Redirect("Purchase_OrderGrid.aspx");

            //}
        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {


            Getcount();
            Getorderdetails();


        }

        protected void Date_chnage(object sender, EventArgs e)
        {


            Getcount();
            Getorderdetails();
        }

        protected void ddlsuplier_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            //getdate();
            Getcount();
            Getorderdetails();
        }


        protected void ddlsubstatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            //getdate();
            Getcount();
            Getorderdetails();
        }


        protected void Status_chnaged(object sender, EventArgs e)
        {

            //getdate();
            Getcount();
            Getorderdetails();
        }

        public void getdate()
        {

            DateTime FromDate = DateTime.ParseExact(txtfromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DataSet ds = objBs.getbranchordersummary(drpbranch.SelectedValue, txtfromdate.Text, sTableName);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblpending.Text = "(" + ds.Tables[0].Rows.Count.ToString() + ")";
                    BankGrid.DataSource = ds;
                    BankGrid.DataBind();
                }
                else
                {
                    lblpending.Text = "(" + 0 + ")";
                    BankGrid.DataSource = null;
                    BankGrid.DataBind();
                }
            }
            else
            {
                lblpending.Text = "(" + 0 + ")";
                BankGrid.DataSource = null;
                BankGrid.DataBind();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {

            if (ddlsubstatus.SelectedValue == "Select SubStatus")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Select SubStatus!.');", true);
                return;
            }

            if (drpemployeeassign.SelectedValue == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Select Employee!.');", true);
                return;
            }
            int j = 0;
            for (int ii = 0; ii < BankGrid.Rows.Count; ii++)
            {
                CheckBox chkitem = (CheckBox)BankGrid.Rows[ii].FindControl("chkitem");
                if (chkitem.Checked == true)
                {
                    j++;
                }
            }
            if (j > 0)
            {
                for (int ii = 0; ii < BankGrid.Rows.Count; ii++)
                {
                    CheckBox chkitem = (CheckBox)BankGrid.Rows[ii].FindControl("chkitem");
                    if (chkitem.Checked == true)
                    {
                        string BillNo = BankGrid.DataKeys[ii].Values[0].ToString();
                        string Branchcode = BankGrid.DataKeys[ii].Values[1].ToString();
                        string BookNo = BankGrid.DataKeys[ii].Values[2].ToString();
                        int k = objBs.InsertSubOrderStatus(BillNo, Branchcode, BookNo, Convert.ToInt32(drpemployeeassign.SelectedValue), Convert.ToInt16(ddlsubstatus.SelectedValue));

                    }
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Select Item Details!.');", true);
                return;
            }


            lblcount.Text = j.ToString();
            Getorderdetails();
        }

        public void chkitem_oncheckedchanged(object sender, EventArgs e)
        {
            int j = 0;
            for (int ii = 0; ii < BankGrid.Rows.Count; ii++)
            {
                CheckBox chkitem = (CheckBox)BankGrid.Rows[ii].FindControl("chkitem");
                if (chkitem.Checked == true)
                {
                    j++;
                }
            }
            lblcount.Text = j.ToString();


        }



    }
}