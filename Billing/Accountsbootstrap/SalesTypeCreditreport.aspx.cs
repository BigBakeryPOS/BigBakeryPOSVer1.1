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

namespace Billing.Accountsbootstrap
{
    public partial class SalesTypeCreditreport : System.Web.UI.Page
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

        string AllBranchAccess = "0";

        double unitprice = 0, Qty = 0, subtotal = 0, gstamount = 0, totalvalue = 0, commamount = 0, commgstamnt = 0, gatwaycharge = 0, grandtot = 0, discvalue = 0;


        double GTax = 0;
        double GNetAmount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Password = Request.Cookies["userInfo"]["Password"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
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

                DataSet paymode = objbs.getlogindetails("3");
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drplogin.DataSource = paymode.Tables[0];
                    drplogin.DataTextField = "Name";
                    drplogin.DataValueField = "code";
                    drplogin.DataBind();
                    drplogin.Items.Insert(0, "All");
                }
                else
                {
                    drplogin.Items.Insert(0, "All");

                }




                txtfromdate.Enabled = true;
                txttodate.Enabled = true;
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString() ;
                txtfromdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Today.ToString("yyyy-MM-dd");

                //if (sadmin == "1")
                //{
                //    ddlBranch.Enabled = true;
                //    DataSet dsbranchto = objbs.Branchto();
                //    ddlBranch.DataSource = dsbranchto.Tables[0];
                //    ddlBranch.DataTextField = "branchcode";
                //    ddlBranch.DataValueField = "Userid";
                //    ddlBranch.DataBind();
                //    //  ddlBranch.Items.Insert(0, "All");
                //}
                //else
                //{
                //    DataSet dsbranch = new DataSet();
                //    string stable = "tblSales_" + sTableName + "";
                //    dsbranch = objbs.Branchfrom(lblUserID.Text);
                //    ddlBranch.DataSource = dsbranch.Tables[0];
                //    ddlBranch.DataTextField = "branchcode";
                //    ddlBranch.DataValueField = "Userid";
                //    ddlBranch.DataBind();
                //    ddlBranch.Enabled = false;
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

                //if (sTableName == "admin")
                //{
                //    ddlBranch.Enabled = true;
                //    txtfromdate.Enabled = true;
                //    txttodate.Enabled = true;



                //}
                //else
                //{


                //}

            }
        }



        protected void txttodate_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        protected void btnall_Click(object sender, EventArgs e)
        {

            gvdetailed.Visible = false;
            gvsummary.Visible = false;
            gvdatewise.Visible = false;

            //   int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //   DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            // if (chkDiscout.Checked == true)
            if (radbtnlist.SelectedValue == "2")
            {
                gvdetailed.Visible = true;
                //  if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    //    string[] wordArray = sales.Split('_');

                    //   brach = wordArray[1];
                    //   string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet dss = new DataSet();
                    // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            dsgrid = objbs.salesempItemwisereports(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, drplogin.SelectedValue);
                            dss.Merge(dsgrid);
                        }
                    }
                    else
                    {
                        dss = objbs.salesempItemwisereports(ddlBranch.SelectedValue, sFrom, sTo, drplogin.SelectedValue);
                    }


                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdetailed.DataSource = dss.Tables[0];
                        gvdetailed.DataBind();

                    }
                    else
                    {
                        gvdetailed.DataSource = null;
                        gvdetailed.DataBind();
                    }
                }

            }
            else if (radbtnlist.SelectedValue == "1")
            {
                gvsummary.Visible = true;
                //  if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    // string[] wordArray = sales.Split('_');

                    //   brach = wordArray[1];
                    //   string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet dss = new DataSet();
                    // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            dsgrid = objbs.salesempsummaryreports(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, drplogin.SelectedValue);
                            dss.Merge(dsgrid);
                        }
                    }
                    else
                    {
                        dss = objbs.salesempsummaryreports(ddlBranch.SelectedValue, sFrom, sTo, drplogin.SelectedValue);
                    }

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvsummary.DataSource = dss.Tables[0];
                        gvsummary.DataBind();

                    }
                    else
                    {
                        gvsummary.DataSource = null;
                        gvsummary.DataBind();
                    }
                }
            }
            else if (radbtnlist.SelectedValue == "3")
            {
                gvdatewise.Visible = true;
                //  if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    //    string[] wordArray = sales.Split('_');

                    //    brach = wordArray[1];
                    //    string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet dss = new DataSet();
                    // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            dsgrid = objbs.salesempsummarydatereports(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, drplogin.SelectedValue);
                            dss.Merge(dsgrid);
                        }
                    }
                    else
                    {
                        dss = objbs.salesempsummarydatereports(ddlBranch.SelectedValue, sFrom, sTo, drplogin.SelectedValue);

                    }

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdatewise.DataSource = dss.Tables[0];
                        gvdatewise.DataBind();

                    }
                    else
                    {
                        gvdatewise.DataSource = null;
                        gvdatewise.DataBind();
                    }
                }
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            //DataSet dCustReport = objbs.CustomerSalesAdmin();
            //gvCustsales.DataSource = dCustReport.Tables[0];
            //gvCustsales.DataBind();
        }

        protected void btnExport_ClickOld(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            GridView gridview = new GridView();

            // gridview.Caption = "Store :  " + BranchNAme + " " + StoreName + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");

            gvdetailed.Visible = false;
            gvsummary.Visible = false;
            gvdatewise.Visible = false;

            int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            // if (chkDiscout.Checked == true)
            //if (radbtnlist.SelectedValue == "2")
            //{
            //    gvdetailed.Visible = true;
            //    if (dsbranch1.Tables[0].Rows.Count > 0)
            //    {
            //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //        string[] wordArray = sales.Split('_');

            //        brach = wordArray[1];
            //        string name = string.Empty;


            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);

            //        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Employee Item Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //        dt = objbs.salesempItemwisereports(brach, sFrom, sTo, drplogin.SelectedValue);
            //        if (dt.Tables[0].Rows.Count > 0)
            //        {
            //            gvdetailed.DataSource = dt.Tables[0];
            //            gvdetailed.DataBind();

            //        }
            //        else
            //        {
            //            gvdetailed.DataSource = null;
            //            gvdetailed.DataBind();
            //        }
            //    }

            //}
            //else if (radbtnlist.SelectedValue == "1")
            //{
            //    gvsummary.Visible = true;
            //    if (dsbranch1.Tables[0].Rows.Count > 0)
            //    {
            //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //        string[] wordArray = sales.Split('_');

            //        brach = wordArray[1];
            //        string name = string.Empty;


            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);

            //        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //        dt = objbs.salesempsummaryreports(brach, sFrom, sTo, drplogin.SelectedValue);
            //        if (dt.Tables[0].Rows.Count > 0)
            //        {
            //            gvsummary.DataSource = dt.Tables[0];
            //            gvsummary.DataBind();

            //        }
            //        else
            //        {
            //            gvsummary.DataSource = null;
            //            gvsummary.DataBind();
            //        }
            //    }
            //}
            //else if (radbtnlist.SelectedValue == "3")
            //{
            //    gvdatewise.Visible = true;
            //    if (dsbranch1.Tables[0].Rows.Count > 0)
            //    {
            //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //        string[] wordArray = sales.Split('_');

            //        brach = wordArray[1];
            //        string name = string.Empty;


            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);

            //        lblCaption.Text = "Store :  " + BranchNAme + " " + StoreName + " Employee Date Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            //        dt = objbs.salesempsummarydatereports(brach, sFrom, sTo, drplogin.SelectedValue);
            //        if (dt.Tables[0].Rows.Count > 0)
            //        {
            //            gvdatewise.DataSource = dt.Tables[0];
            //            gvdatewise.DataBind();

            //        }
            //        else
            //        {
            //            gvdatewise.DataSource = null;
            //            gvdatewise.DataBind();
            //        }
            //    }
            //}

            if (radbtnlist.SelectedValue == "2")
            {
                gvdetailed.Visible = true;
                //  if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    //    string[] wordArray = sales.Split('_');

                    //   brach = wordArray[1];
                    //   string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");

                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet dss = new DataSet();
                    // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            dsgrid = objbs.salesempItemwisereports(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, drplogin.SelectedValue);
                            dss.Merge(dsgrid);
                        }
                    }
                    else
                    {
                        dsgrid = objbs.salesempItemwisereports(ddlBranch.SelectedValue, sFrom, sTo, drplogin.SelectedValue);
                    }


                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdetailed.DataSource = dss.Tables[0];
                        gvdetailed.DataBind();

                    }
                    else
                    {
                        gvdetailed.DataSource = null;
                        gvdetailed.DataBind();
                    }
                }

            }
            else if (radbtnlist.SelectedValue == "1")
            {
                gvsummary.Visible = true;
                //  if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    // string[] wordArray = sales.Split('_');

                    //   brach = wordArray[1];
                    //   string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet dss = new DataSet();
                    // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            dsgrid = objbs.salesempsummaryreports(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, drplogin.SelectedValue);
                            dss.Merge(dsgrid);
                        }
                    }
                    else
                    {
                        dss = objbs.salesempsummaryreports(ddlBranch.SelectedValue, sFrom, sTo, drplogin.SelectedValue);
                    }

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvsummary.DataSource = dss.Tables[0];
                        gvsummary.DataBind();

                    }
                    else
                    {
                        gvsummary.DataSource = null;
                        gvsummary.DataBind();
                    }
                }
            }
            else if (radbtnlist.SelectedValue == "3")
            {
                gvdatewise.Visible = true;
                //  if (dsbranch1.Tables[0].Rows.Count > 0)
                {
                    //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                    //    string[] wordArray = sales.Split('_');

                    //    brach = wordArray[1];
                    //    string name = string.Empty;


                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);

                    lblCaption.Text = "Store :  " + ddlBranch.SelectedValue + " Employee Wise Sales Summary Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet dss = new DataSet();
                    // Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                    if (ddlBranch.SelectedValue == "All")
                    {
                        DataSet ds1 = objbs.GetBranch_New("All");
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            dsgrid = objbs.salesempsummarydatereports(ds1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, drplogin.SelectedValue);
                            dss.Merge(dsgrid);
                        }
                    }
                    else
                    {
                        dss = objbs.salesempsummarydatereports(ddlBranch.SelectedValue, sFrom, sTo, drplogin.SelectedValue);

                    }

                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        gvdatewise.DataSource = dss.Tables[0];
                        gvdatewise.DataBind();

                    }
                    else
                    {
                        gvdatewise.DataSource = null;
                        gvdatewise.DataBind();
                    }
                }
            }

            string filename = "";
            if (radbtnlist.SelectedValue == "1")
            {
                filename = "EmpployeeWisesalesSummary.xls";
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                filename = "EmployeeItemWisesalesreport.xls";

            }
            else if (radbtnlist.SelectedValue == "3")
            {
                filename = "EmployeeDateWise.xls";

            }
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.Caption = "Store :  " + ddlBranch.SelectedValue + " Sales Type Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.White;
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename= SalesTypeReport.xls");
            if (radbtnlist.SelectedValue == "1")
            {
                //filename = "EmpployeeWisesalesSummary.xls";
                Response.AddHeader("content-disposition", "attachment;filename= EmpployeeWisesalesSummary.xls");
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                //filename = "EmployeeItemWisesalesreport.xls";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeItemWisesalesreport.xls");

            }
            else if (radbtnlist.SelectedValue == "3")
            {
                //filename = "EmployeeDateWise.xls";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeDateWise.xls");

            }
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            divPrint.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {



        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {

        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {



        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            if (sTableName != "admin")
            {

            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {


            lblCaption.Text = "Store :" + ddlBranch.SelectedValue + " Customer Sales Report from " + Convert.ToDateTime(txtfromdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
            if (radbtnlist.SelectedValue == "1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridSummary", "printGridSummary();", true);
            }
            else if (radbtnlist.SelectedValue == "2")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridDetails", "printGridDetails();", true);

            }
            else if (radbtnlist.SelectedValue == "3")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "printGridDetailsdate", "printGridDetailsdate();", true);

            }
        }


        public void gvdetailed_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //unitprice += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "unitprice"));
                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "qty"));

                //subtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "amount"));
                //gstamount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));

                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "tot"));
                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "dic"));
                //commamount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "commission"));

                //commgstamnt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "commisionfortax"));
                //gatwaycharge += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "gateWayValue"));
                //grandtot += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total :-";

                e.Row.Cells[7].Text = Qty.ToString("f3");
                e.Row.Cells[6].Text = discvalue.ToString("f2");
                e.Row.Cells[5].Text = totalvalue.ToString("f2");

            }

        }
        public void gvsummary_rowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "qty"));
                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "tot"));
                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "dic"));

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total :";
                e.Row.Cells[3].Text = totalvalue.ToString("f2");
                e.Row.Cells[4].Text = discvalue.ToString("f2");
                e.Row.Cells[5].Text = Qty.ToString("f3");
                //e.Row.Cells[11].Text = commamount.ToString("f2");
                //e.Row.Cells[13].Text = commgstamnt.ToString("f2");
                //e.Row.Cells[15].Text = gatwaycharge.ToString("f2");
                //e.Row.Cells[16].Text = grandtot.ToString("f2");
            }

        }

        public void gvdatewise_rowdatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Qty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "qty"));
                totalvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "tot"));
                discvalue += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "dic"));

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = "Total :";
                e.Row.Cells[4].Text = totalvalue.ToString("f2");
                e.Row.Cells[5].Text = discvalue.ToString("f2");
                e.Row.Cells[6].Text = Qty.ToString("f3");
                //e.Row.Cells[11].Text = commamount.ToString("f2");
                //e.Row.Cells[13].Text = commgstamnt.ToString("f2");
                //e.Row.Cells[15].Text = gatwaycharge.ToString("f2");
                //e.Row.Cells[16].Text = grandtot.ToString("f2");
            }

        }
    }
}