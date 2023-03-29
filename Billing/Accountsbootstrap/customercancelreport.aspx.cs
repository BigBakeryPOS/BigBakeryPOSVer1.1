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
    public partial class customercancelreport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string AllBranchAccess = "0";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);

            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            if (!IsPostBack)
            {
                txtfromdate.Enabled = true;
                txttodate.Enabled = true;
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                //txtfromdate.Text = firstDay.ToShortDateString();

                txtfromdate.Text = DateTime.Today.ToShortDateString();
                txttodate.Text = DateTime.Today.ToShortDateString();

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

                DataSet paymode = objbs.Paymodevalues(sTableName);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drpPayment.DataSource = paymode.Tables[0];
                    drpPayment.DataTextField = "PayMode";
                    drpPayment.DataValueField = "Value";
                    drpPayment.DataBind();
                    drpPayment.Items.Insert(0, "All");
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

                //  if (sTableName == "admin")
                // {
                //    txtfromdate.Enabled = true;
                //    txttodate.Enabled = true;
                //DataSet dCustReport = objbs.CustomerSalesAdmin();
                //gvCustsales.DataSource = dCustReport.Tables[0];
                //gvCustsales.DataBind();
                // }
                // else
                {

                    //   int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                    //   DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    // if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        //  string[] wordArray = sales.Split('_');

                        //brach = wordArray[1];
                        //if (brach == "CO1")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}
                        //else if (brach == "CO2")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}
                        //else if (brach == "CO3")
                        //{
                        //    Label123.Text = "Shiva Delights";
                        //}
                        //else if (brach == "CO4")
                        //{
                        //    Label123.Text = "Fig and honey";
                        //}
                        //else if (brach == "CO5")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}

                        //else if (brach == "CO6")
                        //{
                        //    Label123.Text = "Maduravayol";
                        //}

                        //else if (brach == "CO6")
                        //{
                        //    Label123.Text = "purasavakkam";
                        //}


                        //else if (brach == "CO8")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}
                        //else if (brach == "CO9")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}
                        //else if (brach == "CO10")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}
                        //else if (brach == "CO11")
                        //{
                        //    Label123.Text = "Blaack Forest Bakery Services";
                        //}
                        ////  DataSet dcustbranch = objbs.CustomerSalesBranch(sTableName, txtfromdate.Text, txttodate.Text);
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);
                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        DataSet dsgrid = new DataSet();
                        DataSet ds1 = new DataSet();
                        DataSet dcustbranch = new DataSet();
                        if (ddlBranch.SelectedValue == "All")
                        {
                            DataSet dss1 = objbs.GetBranch_New("All");
                            for (int i = 0; i < dss1.Tables[0].Rows.Count; i++)
                            {
                                ds1 = objbs.CustomerSalescacnelbill(dss1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo);
                                dcustbranch.Merge(ds1);
                            }
                        }
                        else
                        {
                            dcustbranch = objbs.CustomerSalescacnelbill(ddlBranch.SelectedValue, sFrom, sTo);
                        }

                        //if (dcustbranch.Tables[0].Rows.Count > 0)
                        //{
                        //    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                        //}

                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        //decimal dtotal = 0;
                        //for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                        //{
                        //    dtotal += Convert.ToDecimal(dcustbranch.Tables[0].Rows[i]["Netamount"]);
                        //}
                        //decimal Total = dtotal;
                        //lblTotal.InnerText = Total.ToString();
                        //tot = Convert.ToDouble(Total);
                        gvCustsales.DataBind();
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
                        gndtotal.InnerText = gndtot.ToString();
                        //  btnall_Click( sender, Even e)
                    }



                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

            //if (txtfromdate.Text > txttodate.Text)
            //{

            //}

            // if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //    string[] wordArray = sales.Split('_');

                //  brach = wordArray[1];
                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "purasavakkam";
                }

                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text  = ddlBranch.SelectedItem.Text + " Customer Cancelled Sales Report for " + drpPayment.SelectedItem.Text + " Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString();
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drpPayment.SelectedItem.Value;

                //DataSet dcustbranch = objbs.CustomerSalesBranchbillcancel(brach, sFrom, sTo, paymode);
                // DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);

                DataSet dsgrid = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet dcustbranch = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet dss1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < dss1.Tables[0].Rows.Count; i++)
                    {
                        ds1 = objbs.CustomerSalesBranchbillcancel(dss1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dcustbranch.Merge(ds1);
                    }
                }
                else
                {
                    dcustbranch = objbs.CustomerSalesBranchbillcancel(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                }


                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{
                //    Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                //}

                gvCustsales.DataSource = dcustbranch.Tables[0];
                gvCustsales.DataBind();
                //decimal dtotal = 0;
                //for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //{
                //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                //}
                //decimal Total = dtotal;
                //lblTotal.InnerText = Total.ToString();
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
                gndtotal.InnerText = gndtot.ToString();
                //  btnall_Click( sender, Even e)

                // tot = Convert.ToDouble(Total);
            }
            //decimal dtotal = 0;
            //for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //{
            //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[6].Text);
            //}
            //decimal Total = dtotal;
            //lblTotal.InnerText = Total.ToString();
            //tot = Convert.ToDouble(Total);

            //DataSet dcustbranch = objbs.CustomerSalesBranch(ddlBranch.SelectedValue);
            //gvCustsales.DataSource = dcustbranch.Tables[0];
            //gvCustsales.DataBind();
        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            //   int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //   DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            //  if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //    string[] wordArray = sales.Split('_');

                //   brach = wordArray[1];
                //  string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "purasavakkam";
                }

                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text = ddlBranch.SelectedItem.Text + " Customer Cancelled Sales Report for " + drpPayment.SelectedItem.Text + " Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString();
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drpPayment.SelectedItem.Value;

                //DataSet dcustbranch = objbs.CustomerSalesBranchbillcancel(brach, sFrom, sTo, paymode);
                //  DataSet dcustbranch = objbs.CustomerSalesBranch(brach, sFrom, sTo);
                DataSet dsgrid = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet dcustbranch = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet dss1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < dss1.Tables[0].Rows.Count; i++)
                    {
                        ds1 = objbs.CustomerSalesBranchbillcancel(dss1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dcustbranch.Merge(ds1);
                    }
                }
                else
                {
                    dcustbranch = objbs.CustomerSalesBranchbillcancel(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                }
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();
                }



                //decimal dtotal = 0;
                //for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //{
                //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                //}
                //decimal Total = dtotal;
                //lblTotal.InnerText = Total.ToString();
                //tot = Convert.ToDouble(Total);
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
                gndtotal.InnerText = gndtot.ToString();
                //  btnall_Click( sender, Even e)




            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            //  DataSet dCustReport = objbs.CustomerSalesAdmin();
            //  gvCustsales.DataSource = dCustReport.Tables[0];
            //  gvCustsales.DataBind();
        }

        protected void btnExport_ClickOld(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            GridView gridview = new GridView();
            //  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //  string name = string.Empty;
            gridview.Caption = Label123.Text + " Customer Cancelled Sales Report for " + drpPayment.SelectedItem.Text +" Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString() +  " Generated on " + DateTime.Now.ToString();


            // if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //   string[] wordArray = sales.Split('_');

                // brach = wordArray[1];


                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "purasavakkam";
                }
                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
            }
            Label123.Text = ddlBranch.SelectedItem.Text + " Customer Cancelled Sales Report for " + drpPayment.SelectedItem.Text + " Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString();
            //if (sTableName == "admin")
            //{
            //    gridview.DataSource = objbs.CustomerSalesAdmin1();
            //    gridview.DataBind();
            //}

            //else
            //{
            DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            DateTime sTo = Convert.ToDateTime(txttodate.Text);
            string paymode = drpPayment.SelectedItem.Value;

            //    dt = objbs.CustomerSalesBranchbillcancel(brach, sFrom, sTo, paymode);
            //    gridview.DataSource = dt.Tables[0];
            //    gridview.DataBind();
            //}

            DataSet dsgrid = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet dcustbranch = new DataSet();
            if (ddlBranch.SelectedValue == "All")
            {
                DataSet dss1 = objbs.GetBranch_New("All");
                for (int i = 0; i < dss1.Tables[0].Rows.Count; i++)
                {
                    ds1 = objbs.CustomerSalesBranchbillcancel(dss1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                    dt.Merge(ds1);
                }
            }
            else
            {
                dt = objbs.CustomerSalesBranchbillcancel(ddlBranch.SelectedValue, sFrom, sTo, paymode);
            }
            if (dcustbranch.Tables[0].Rows.Count > 0)
            {
                gridview.DataSource = dt.Tables[0];
                gridview.DataBind();
            }

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
            string filename = "Canceledsalesreport.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.Caption = Label123.Text;
            //+ " Customer Cancelled Sales Report Generated on " + DateTime.Now.ToString();
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


        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= CustomerCancelSalesReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            div1.RenderControl(htmlWrite);
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
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



            //  if (dsbranch1.Tables[0].Rows.Count > 0)
            {
                //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //    string[] wordArray = sales.Split('_');

                //   brach = wordArray[1];
                //   string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "purasavakkam";
                }


                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text = ddlBranch.SelectedItem.Text + " Customer Cancelled Report for " + drpPayment.SelectedItem.Text + " Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString();
                //if (sTableName == "admin")
                //{
                //    DataSet dCustReport = objbs.CustomerSalesAdmin();
                //    gvCustsales.PageIndex = e.NewPageIndex;
                //    gvCustsales.DataSource = dCustReport.Tables[0];
                //    gvCustsales.DataBind();
                //}
                //else
                //{
                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drpPayment.SelectedItem.Value;

                //    DataSet ds = objbs.CustomerSalesBranchbillcancel(brach, sFrom, sTo, paymode);
                //    //   DataSet ds = objbs.CustomerSalesBranch(sTableName, sFrom, sTo);
                //    gvCustsales.PageIndex = e.NewPageIndex;

                //    gvCustsales.DataSource = ds.Tables[0];
                //    gvCustsales.DataBind();
                //}

                DataSet dsgrid = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet dcustbranch = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet dss1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < dss1.Tables[0].Rows.Count; i++)
                    {
                        ds1 = objbs.CustomerSalesBranchbillcancel(dss1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dcustbranch.Merge(ds1);
                    }
                }
                else
                {
                    dcustbranch = objbs.CustomerSalesBranchbillcancel(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                }
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    gvCustsales.PageIndex = e.NewPageIndex;
                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();
                }

                //decimal dtotal = 0;
                //for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //{
                //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                //}
                //decimal Total = dtotal;
                //lblTotal.InnerText = Total.ToString();
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
                gndtotal.InnerText = gndtot.ToString();
                //  btnall_Click( sender, Even e)

                //  tot = Convert.ToDouble(Total);


            }


        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {
          //  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
          //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);



           // if (dsbranch1.Tables[0].Rows.Count > 0)
            {
             //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
             //   string[] wordArray = sales.Split('_');

              //  brach = wordArray[1];
              //  string name = string.Empty;

                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "purasavakkam";
                }


                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                Label123.Text = ddlBranch.SelectedItem.Text + " Customer Cancelled Report for " + drpPayment.SelectedItem.Text + " Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString();
                //DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //DateTime sTo = Convert.ToDateTime(txttodate.Text);
                //string paymode = drpPayment.SelectedItem.Value;

                //DataSet dcustbranch = objbs.CustomerSalesBranchbillcancel(brach, sFrom, sTo, paymode);
                //if (dcustbranch.Tables[0].Rows.Count > 0)
                //{

                //}

                //gvCustsales.DataSource = dcustbranch.Tables[0];
                //gvCustsales.DataBind();

                DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                DateTime sTo = Convert.ToDateTime(txttodate.Text);
                string paymode = drpPayment.SelectedItem.Value;

                //    DataSet ds = objbs.CustomerSalesBranchbillcancel(brach, sFrom, sTo, paymode);
                //    //   DataSet ds = objbs.CustomerSalesBranch(sTableName, sFrom, sTo);
                //    gvCustsales.PageIndex = e.NewPageIndex;

                //    gvCustsales.DataSource = ds.Tables[0];
                //    gvCustsales.DataBind();
                //}

                DataSet dsgrid = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet dcustbranch = new DataSet();
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet dss1 = objbs.GetBranch_New("All");
                    for (int i = 0; i < dss1.Tables[0].Rows.Count; i++)
                    {
                        ds1 = objbs.CustomerSalesBranchbillcancel(dss1.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dcustbranch.Merge(ds1);
                    }
                }
                else
                {
                    dcustbranch = objbs.CustomerSalesBranchbillcancel(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                }
                if (dcustbranch.Tables[0].Rows.Count > 0)
                {
                    gvCustsales.DataSource = dcustbranch.Tables[0];
                    gvCustsales.DataBind();
                }

                //decimal dtotal = 0;
                //for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //{
                //    dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                //}
                //decimal Total = dtotal;
                //lblTotal.InnerText = Total.ToString();
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
                gndtotal.InnerText = gndtot.ToString();
                //  btnall_Click( sender, Even e)

                //tot = Convert.ToDouble(Total);



            }
        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
            if (sadmin == "1")
            {

            }
           // int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
          //  DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
          //  string name = string.Empty;



           // if (dsbranch1.Tables[0].Rows.Count > 0)
            {
             //   string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
             //   string[] wordArray = sales.Split('_');

             //   brach = wordArray[1];


                if (brach == "CO1")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO2")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO3")
                {
                    Label123.Text = "Shiva Delights";
                }
                else if (brach == "CO4")
                {
                    Label123.Text = "Fig and honey";
                }
                else if (brach == "CO5")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "Maduravayol";
                }

                else if (brach == "CO6")
                {
                    Label123.Text = "purasavakkam";
                }


                else if (brach == "CO8")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO9")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO10")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
                else if (brach == "CO11")
                {
                    Label123.Text = "Blaack Forest Bakery Services";
                }
            }
            Label123.Text = ddlBranch.SelectedItem.Text + " Customer Cancelled Report for " + drpPayment.SelectedItem.Text + " Paymode from " + txtfromdate.Text.ToString() + " to " + txttodate.Text.ToString();


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
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

            }

        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {
            //if (sTableName != "admin")
            //{
            //    DateTime date = Convert.ToDateTime(txtfromdate.Text);
            //    DateTime Toady = DateTime.Now.Date; ;

            //    var days = date.Day;
            //    var toda = Toady.Day;

            //    if ((toda - days) <= 2)
            //    {

            //    }

            //    else
            //    {
            //       // txtfromdate.Text = "";
            //    }
            //}


            if (sTableName == "admin")
            {
                //DateTime date = Convert.ToDateTime(txttodate.Text);
                //DateTime Toady = DateTime.Now.Date; ;

                //var dateDiff = Toady - date;
                //double totalDays = dateDiff.TotalDays;
                ////////var days = date.Day;
                ////////var toda = Toady.Day;

                //// if ((toda - days) <= 30)
                //if ((totalDays) <= Convert.ToDouble(30))
                //{

                //}

                //else
                //{
                //    txttodate.Text = "";
                //}
            }
            else if (sTableName == "CO10")
            {
                DateTime date = Convert.ToDateTime(txtfromdate.Text);
                DateTime Toady = DateTime.Now.Date; ;

                var dateDiff = Toady - date;
                double totalDays = dateDiff.TotalDays;
                //////var days = date.Day;
                //////var toda = Toady.Day;

                // if ((toda - days) <= 30)
                if ((totalDays) < Convert.ToDouble(2))
                {

                }

                else
                {
                    txtfromdate.Text = "";
                }
            }
        }
    }
}