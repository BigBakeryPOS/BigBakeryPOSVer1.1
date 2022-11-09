using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Globalization;

namespace Billing.Accountsbootstrap
{
    public partial class CustomerSalesReport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string Password = "";
        string BranchNAme = "";
        string StoreName = "";
        string Empid = "";
        string AllBranchAccess = "0";
        double GTax = 0;
        double GNetAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            Password = Request.Cookies["userInfo"]["Password"].ToString();

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            DataSet dsPlaceName = objbs.GetPlacename(lblUser.Text, Password);
            Label123.Text = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            BranchNAme = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();

                DataSet paymode = objbs.Paymodevalues(sTableName);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drpPayment.DataSource = paymode.Tables[0];
                    drpPayment.DataTextField = "PayMode";
                    drpPayment.DataValueField = "Value";
                    drpPayment.DataBind();
                    drpPayment.Items.Insert(0, "All");
                }


                txtfromdate.Enabled = true;
                txttodate.Enabled = true;
                string[] user = lblUser.Text.Split('@');
                string Branch = user[0];
                for (int i = 0; i < drpPayment.Items.Count; i++)
                {
                    if (drpPayment.Items[i].Text.ToLower().Contains(Branch))
                    {
                        drpPayment.Items[i].Enabled = false;
                        break;
                    }
                }
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString() ;
                txtfromdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                //DataSet dsbranch = objbs.selectbranchmaster();
                //if (dsbranch.Tables[0].Rows.Count > 0)
                //{
                //    ddlBranch.DataSource = dsbranch.Tables[0];
                //    ddlBranch.DataTextField = "BranchCode";
                //    ddlBranch.DataValueField = "UserID";
                //    ddlBranch.DataBind();
                //   // ddlBranch.Items.Insert(0, "Select Branch");
                //    //ddlcategory.Items.Insert(0, "Select Category");

                //}
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

                //   if (sTableName == "admin")
                {
                    //ddlBranch.Enabled = true;
                    //txtfromdate.Enabled = true;
                    //txttodate.Enabled = true;



                }
                //  else
                {
                    //  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                    //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    // if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        //string[] wordArray = sales.Split('_');

                        //brach = wordArray[1];

                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        DataSet dcustbranch = new DataSet();
                        DataSet dsgrid = new DataSet();
                        DataSet ds = new DataSet();
                       // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                        if (ddlBranch.SelectedValue == "All")
                        {
                            DataSet ds1 = objbs.GetBranch_New("All");
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                ds = objbs.CustomerSalesBranch(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo);
                                dcustbranch.Merge(ds);

                            }
                        }
                        else
                        {
                            dcustbranch = objbs.CustomerSalesBranch(ddlBranch.SelectedValue, sFrom, sTo);
                        }

                        if (dcustbranch.Tables[0].Rows.Count > 0)
                        {

                            gvCustsales.DataSource = dcustbranch.Tables[0];
                            gvCustsales.DataBind();
                            getsummarysales();
                        }
                        else
                        {
                            gvCustsales.DataSource = null;
                            gvCustsales.DataBind();
                            getsummarysales();
                        }



                    }



                }

                lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            }
            DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "CustomerDetailed");
            if (getaccess.Tables[0].Rows.Count > 0)
            {
                divPrint.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                divPrint.Visible = true;
                btnExport.Visible = true;
                //  ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Delete This Session.Thank you!!!.');", true);
                //  return;
            }


        }
        protected void rad_chaked(object sender, EventArgs e)
        {
            getsummarysales();
        }
        public void getsummarysales()
        {
            DataSet elosales = new DataSet();
            if (chkbutton.SelectedValue == "0")
            {
                DataSet dsgrid = new DataSet();
                DataSet ds = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {

                        ds = objbs.sales_distributionFromTodate(txtfromdate.Text, txttodate.Text, ds1.Tables[0].Rows[i]["BranchCode"].ToString(), chkbutton.SelectedValue);
                        elosales.Merge(ds);
                    }
                }
                else
                {
                    elosales = objbs.sales_distributionFromTodate(txtfromdate.Text, txttodate.Text, ddlBranch.SelectedValue, chkbutton.SelectedValue);
                }
                if (elosales.Tables[0].Rows.Count > 0)
                {
                    gvnormalsales.DataSource = elosales.Tables[0];
                    gvnormalsales.DataBind();
                }
                else
                {
                    gvnormalsales.DataSource = null;
                    gvnormalsales.DataBind();
                }
            }
            else
            {
                DataSet dsgrid = new DataSet();
                DataSet ds = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        ds = objbs.sales_distributionFromTodate(txtfromdate.Text, txttodate.Text, ds1.Tables[0].Rows[i]["BranchCode"].ToString(), chkbutton.SelectedValue);
                        elosales.Merge(ds);
                    }
                }
                else
                {
                    elosales = objbs.sales_distributionFromTodate(txtfromdate.Text, txttodate.Text, ddlBranch.SelectedValue, chkbutton.SelectedValue);
                }

                if (elosales.Tables[0].Rows.Count > 0)
                {
                    gvnormalsales.DataSource = elosales.Tables[0];
                    gvnormalsales.DataBind();
                }
                else
                {
                    gvnormalsales.DataSource = null;
                    gvnormalsales.DataBind();
                }
            }
        }
        protected void txttodate_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);


            if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                string[] wordArray = sales.Split('_');

                brach = wordArray[1];

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drpPayment.SelectedItem.Value;

                DataSet dcustbranch = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
                // DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                }
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();
                }
                else
                {
                    gvCustsales.DataSource = null;
                    gvCustsales.DataBind();
                }

            }




        }
        protected void btnall_Click(object sender, EventArgs e)
        {
            //   int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            // DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            if (chkDiscout.Checked == true)
            {
                //  if (dsbranch1.Tables[0].Rows.Count > 0)

                {
                    //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    //   string[] wordArray = sales.Split('_');

                    //   brach = wordArray[1];
                    //   string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymodeDiscount(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dcustbranch.Merge(ds);
                        }
                    }
                    else
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodeDiscount(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }






                }
            }
            else
            {

                //   if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    //    string[] wordArray = sales.Split('_');

                    //    brach = wordArray[1];
                    //    string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;

                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymode(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dcustbranch.Merge(ds);
                        }
                    }
                    else
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymode(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }

                    //lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    //DataSet dcustbranch = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
                    ////  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                    //if (dcustbranch.Tables[0].Rows.Count > 0)
                    //{

                    //}

                    //gvCustsales.DataSource = dcustbranch.Tables[0];
                    //gvCustsales.DataBind();

                    //getsummarysales();



                }


            }


        }
        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            //DataSet dCustReport = objbs.CustomerSalesAdmin();
            //gvCustsales.DataSource = dCustReport.Tables[0];
            //gvCustsales.DataBind();
            //getsummarysales();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            GridView gridview = new GridView();
            //  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //  string name = string.Empty;



            gridview.Caption = "Store :  " + ddlBranch.SelectedValue  + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");

            if (chkDiscout.Checked == true)
            {
                {

                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymodeDiscount(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dt.Merge(ds);
                        }
                    }
                    else
                    {
                        dt = objbs.CustomerSalesBranchpaymodeDiscount(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");


                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.DataSource = dt.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }






                }
            }
            else
            {
                {



                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;

                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymode(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dt.Merge(ds);
                        }
                    }
                    else
                    {
                        dt = objbs.CustomerSalesBranchpaymode(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.DataSource = dt.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                }


            }

            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];
            //}

            //if (chkDiscout.Checked == true)
            //{
            //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //    string paymode = drpPayment.SelectedItem.Value;
            //    dt = objbs.CustomerSalesBranchpaymodeDiscount(brach, sFrom, sTo, paymode);
            //    //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
            //    if (dt.Tables[0].Rows.Count > 0)
            //    {
            //        //updated 22/10/21
            //        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            //        {
            //            dt.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //            dt.Tables[0].Rows[i]["DatePart"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["DatePart"]).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //        }
            //        //end update
            //        gvCustsales.DataSource = dt;
            //        gvCustsales.DataBind();

            //    }


            //}
            //else
            //{

            //    if (sTableName == "admin")
            //    {
            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;
            //        dt = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);

            //        //updated 22/10/21
            //        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            //        {
            //            dt.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //            dt.Tables[0].Rows[i]["DatePart"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["DatePart"]).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //        }
            //        //end update


            //        gridview.DataSource = dt;
            //        gridview.DataBind();
            //    }

            //    else
            //    {
            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;
            //        dt = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
            //        //updated 22/10/21
            //        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            //        {
            //            dt.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //            dt.Tables[0].Rows[i]["DatePart"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["DatePart"]).ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //        }
            //        //end update
            //        gridview.DataSource = dt;
            //        gridview.DataBind();
            //    }
            //}
            //Response.ClearContent();
            //Response.AddHeader("content-disposition",
            //    "attachment;filename=CustomerSalesReport.xls");
            //Response.ContentType = "applicatio/excel";
            //StringWriter sw = new StringWriter(); ;
            //HtmlTextWriter htm = new HtmlTextWriter(sw);
            //gridview.AllowPaging = false;
            //gridview.RenderControl(htm);
            //Response.Write(sw.ToString());
            //Response.End();
            //gridview.AllowPaging = true;
            string filename = "salesreport.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.Caption = "Store :  " + BranchNAme + " " + StoreName + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
            dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
            dgGrid.HeaderStyle.Font.Bold = true;
            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
        protected void btnExport_Clickold(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= CustomerSalesReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            divPrint.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
        //       server control at run time. */
        //}
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];
            //    string name = string.Empty;

            //    if (brach == "CO1")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO2")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO3")
            //    {
            //        Label123.Text = "Shiva Delights";
            //    }
            //    else if (brach == "CO4")
            //    {
            //        Label123.Text = "Fig and honey";
            //    }
            //    else if (brach == "CO5")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }

            //    else if (brach == "CO6")
            //    {
            //        Label123.Text = "Maduravayol";
            //    }

            //    else if (brach == "CO7")
            //    {
            //        Label123.Text = "Purasavakkam";
            //    }
            //    else if (brach == "CO8")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }

            //    else if (brach == "CO9")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO10")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    else if (brach == "CO11")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //    if (sTableName == "admin")
            //    {
            //        DataSet dCustReport = objbs.CustomerSalesAdmin();
            //        gvCustsales.PageIndex = e.NewPageIndex;
            //        gvCustsales.DataSource = dCustReport.Tables[0];
            //        gvCustsales.DataBind();
            //    }
            //    else
            //    {
            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;

            //        DataSet ds = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
            //        //   DataSet ds = objbs.CustomerSalesBranch(sTableName, sFrom, sTo);
            //        gvCustsales.PageIndex = e.NewPageIndex;

            //        gvCustsales.DataSource = ds.Tables[0];
            //        gvCustsales.DataBind();
            //    }
            //    //decimal dtotal = 0;
            //    //for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    //{
            //    //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //    //}
            //    //decimal Total = dtotal;
            //    //lblTotal.InnerText = Total.ToString();
            //    //decimal dtotal = 0;
            //    //       decimal ddiscamnt = 0;
            //    //       decimal dtotalamt = 0;
            //    //       for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    //       {
            //    //           dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //    //           ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
            //    //             dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
            //    //       }
            //    //       decimal Total = dtotal;
            //    //       lblTotal.InnerText = Total.ToString();
            //    //       decimal dtotalamntt = ddiscamnt;
            //    //       disc.InnerText = dtotalamntt.ToString();
            //    //       decimal gndtot = dtotalamt;
            //    //       gndtotal.InnerText = gndtot.ToString();
            //    //  btnall_Click( sender, Even e)

            //    //  tot = Convert.ToDouble(Total);


            //}

          //  gridview.Caption = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");

            if (chkDiscout.Checked == true)
            {
                {

                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymodeDiscount(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dcustbranch.Merge(ds);
                        }
                    }
                    else
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodeDiscount(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");


                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.PageIndex = e.NewPageIndex;
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }






                }
            }
            else
            {
                {



                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;

                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymode(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dcustbranch.Merge(ds);
                        }
                    }
                    else
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymode(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                        gvCustsales.PageIndex = e.NewPageIndex;
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                }


            }


        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];
            //    string name = string.Empty;

            //    //////if (brach == "CO1")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO2")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO3")
            //    //////{
            //    //////    Label123.Text = "Shiva Delights";
            //    //////}
            //    //////else if (brach == "CO4")
            //    //////{
            //    //////    Label123.Text = "Fig and honey";
            //    //////}
            //    //////else if (brach == "CO5")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}

            //    //////else if (brach == "CO6")
            //    //////{
            //    //////    Label123.Text = "Maduravayol";
            //    //////}

            //    //////else if (brach == "CO7")
            //    //////{
            //    //////    Label123.Text = "Purasavakkam";
            //    //////}
            //    //////else if (brach == "CO8")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}

            //    //////else if (brach == "CO9")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO10")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    //////else if (brach == "CO11")
            //    //////{
            //    //////    Label123.Text = "Blaack Forest Bakery Services";
            //    //////}
            //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //    string paymode = drpPayment.SelectedItem.Value;

            //    DataSet dcustbranch = objbs.CustomerSalesBranchpaymode(brach, sFrom, sTo, paymode);
            //    if (dcustbranch.Tables[0].Rows.Count > 0)
            //    {

            //    }

            //    gvCustsales.DataSource = dcustbranch.Tables[0];
            //    gvCustsales.DataBind();

            //    getsummarysales();

            //    //decimal dtotal = 0;
            //    //for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    //{
            //    //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //    //}
            //    //decimal Total = dtotal;
            //    //lblTotal.InnerText = Total.ToString();
            //    //decimal dtotal = 0;
            //    //       decimal ddiscamnt = 0;
            //    //       decimal dtotalamt = 0;
            //    //       for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    //       {
            //    //           dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //    //           ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
            //    //             dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
            //    //       }
            //    //       decimal Total = dtotal;
            //    //       lblTotal.InnerText = Total.ToString();
            //    //       decimal dtotalamntt = ddiscamnt;
            //    //       disc.InnerText = dtotalamntt.ToString();
            //    //       decimal gndtot = dtotalamt;
            //    //       gndtotal.InnerText = gndtot.ToString();
            //    //  btnall_Click( sender, Even e)

            //    //tot = Convert.ToDouble(Total);

            if (chkDiscout.Checked == true)
            {
                {

                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymodeDiscount(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dcustbranch.Merge(ds);
                        }
                    }
                    else
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodeDiscount(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");


                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                      //  gvCustsales.PageIndex = e.NewPageIndex;
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }






                }
            }
            else
            {
                {



                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;

                    DataSet dsgrid = new DataSet();
                    DataSet ds = new DataSet();
                    DataSet dcustbranch = new DataSet();
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            ds = objbs.CustomerSalesBranchpaymode(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                            dcustbranch.Merge(ds);
                        }
                    }
                    else
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymode(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                    }

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    if (dcustbranch.Tables[0].Rows.Count > 0)
                    {
                        //gvCustsales.PageIndex = e.NewPageIndex;
                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                    else
                    {
                        gvCustsales.DataSource = null;
                        gvCustsales.DataBind();
                        getsummarysales();
                    }
                }


            }

            //}
        }
        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
            //if (sadmin == "1")
            //{

            //}
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //string name = string.Empty;



            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];


               
            //}


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double Tax = 0;
                double NetAmount = 0;

                Tax = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Tax"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GTax = GTax + Tax;
                GNetAmount = GNetAmount + NetAmount;

                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                    //int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Values[0]);
                    string salestype = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    string branch = gvGroup.DataKeys[e.Row.RowIndex].Values[2].ToString();
                    DataSet ds = objbs.CustomerSalesdetailed(groupID, branch, salestype);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv.DataSource = ds;
                        double amount = Convert.ToDouble(ds.Tables[0].Rows[0]["NetAmount"]);
                        amount1 = amount1 + amount;
                        gv.DataBind();


                    }
                    //}
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                //e.Row.Cells[0].Text = "Total";

                //e.Row.Cells[7].Text = amount1.ToString("N2");
                //e.Row.Cells[7].ForeColor = System.Drawing.Color.White;


                //////GTax = GTax + Tax;
                //////GNetAmount = GNetAmount + NetAmount;


                decimal dtotal = 0;
                decimal ddiscamnt = 0;
                decimal dtotalamt = 0;
                for (int i = 0; i < gvCustsales.Rows.Count; i++)
                {
                    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    ddiscamnt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[9].Text);
                    dtotalamt += Convert.ToDecimal(gvCustsales.Rows[i].Cells[10].Text);
                }
                decimal Total = dtotal;
                lblTotal.InnerText = Total.ToString();
                decimal dtotalamntt = ddiscamnt;
                disc.InnerText = dtotalamntt.ToString();
                decimal gndtot = dtotalamt;

                // gndtotal.InnerText = ((Convert.ToDouble(gndtot)) - Convert.ToDouble(dtotalamntt)).ToString("f2");
                gndtotal.InnerText = ((Convert.ToDouble(gndtot))).ToString("f2");

                double finaltot = 0;
                double roundoff1 = Convert.ToDouble(gndtotal.InnerText) - Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                if (roundoff1 >= 0.5)
                {
                    finaltot = Math.Round(Convert.ToDouble(gndtotal.InnerText), MidpointRounding.AwayFromZero);
                }
                else
                {
                    finaltot = Math.Floor(Convert.ToDouble(gndtotal.InnerText));
                }

                gndtotal.InnerText = string.Format("{0:N2}", finaltot);
            }

        }
        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {
                //DateTime date = Convert.ToDateTime(txtfromdate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var days = date.Day;
                //var toda = Toady.Day;

                //if ((toda - days) <= 2)
                //{

                //}

                //else
                //{
                //    txtfromdate.Text = "";
                //}
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //////string Branch = "";
            //////if (sTableName == "CO1")
            //////    Branch = "Kk nagar";
            //////else if (sTableName == "CO2")
            //////    Branch = "Byepass";
            //////else if (sTableName == "CO3")
            //////    Branch = "BB kulam";
            //////else if (sTableName == "CO4")
            //////    Branch = "Narayanapuram";
            //////else if (sTableName == "CO5")
            //////    Branch = "Palayankottal";
            //////else if (sTableName == "CO6")
            //////    Branch = "Maduravayol";
            //////else if (sTableName == "CO7")
            //////    Branch = "purasavakkam";
            //////else if (sTableName == "CO8")
            //////    Branch = "Chennai Pothys";

            //////else if (sTableName == "CO9")
            //////    Branch = "Thirunelveli";
            //////else if (sTableName == "CO10")
            //////    Branch = "Periyar";
            //////else if (sTableName == "CO11")
            //////    Branch = "Palayam";

            lblCaption.Text = "Store :" + BranchNAme + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "printGrid", "printGrid();", true);
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            SendHTMLMail();
        }


        public void SendHTMLMail()
        {


            MailMessage Msg = new MailMessage();
            // MailAddress fromMail = new MailAddress("administrator@aspdotnet-suresh.com");
            MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            // Sender e-mail address.
            Msg.From = fromMail;
            // Recipient e-mail address.
            Msg.To.Add(new MailAddress("rajar@bigdbiz.in"));//Msg.To.Add(new MailAddress("suresh@gmail.com"));
            // Subject of e-mail
            Msg.Subject = "Send Gridivew in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += GetGridviewData(gvCustsales);
            Msg.Body += "Please check below data <br/><br/>";
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
    }
}