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
    public partial class customerorderformreport : System.Web.UI.Page
    {
        string sTableName = "";
        BSClass objbs = new BSClass();
        double amount1 = 0;
        string brach = string.Empty;
        string sadmin = string.Empty;
        double tot = 0;
        string Empid = "";
        string AllBranchAccess = "0";

        double TotNetAmount = 0;
        double Tottaxamount = 0;
        double TotPayamount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sadmin = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
            Label123.Text = Request.Cookies["userInfo"]["Store"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExport);
            

            if (!IsPostBack)
            {
                RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(Request.Cookies["userInfo"]["ReportDay"])).ToShortDateString();
                RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();


                txtfromdate.Enabled = true;
                txttodate.Enabled = true;
                DateTime today = DateTime.Today;
                int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

                DateTime firstDay = new DateTime(today.Year, today.Month, 1);
                // txtfromdate.Text = firstDay.ToShortDateString();
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

                DataSet paymode = objbs.Paymodevalues(sTableName);
                if (paymode.Tables[0].Rows.Count > 0)
                {
                    drpPayment.DataSource = paymode.Tables[0];
                    drpPayment.DataTextField = "PayMode";
                    drpPayment.DataValueField = "Value";
                    drpPayment.DataBind();
                    drpPayment.Items.Insert(0, "All");
                }

                //  if (sTableName == "admin")
                {
                    txtfromdate.Enabled = true;
                    txttodate.Enabled = true;

                    //DataSet dCustReport = objbs.CustomerSalesAdmin();
                    //gvCustsales.DataSource = dCustReport.Tables[0];
                    //gvCustsales.DataBind();


                    //  int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                    //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                    // if (dsbranch1.Tables[0].Rows.Count > 0)
                    {
                        //string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                        //string[] wordArray = sales.Split('_');

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

                        //else if (brach == "CO7")
                        //{
                        //    Label123.Text = "Purasavakkam";
                        //}


                        //else if (brach == "CO8")
                        //{
                        //    Label123.Text = "Chennai Pothys";
                        //}
                        //else if (brach == "CO9")
                        //{
                        //    Label123.Text = "Thirunelveli";
                        //}
                        //else if (brach == "CO10")
                        //{
                        //    Label123.Text = "Periyar";
                        //}
                        //else if (brach == "CO11")
                        //{
                        //    Label123.Text = "Palayam";
                        //}
                        //  DataSet dcustbranch = objbs.CustomerSalesBranch(sTableName, txtfromdate.Text, txttodate.Text);
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        DataSet dsgrid = new DataSet();
                        DataSet dcustbranch = new DataSet();
                        Label123.Text = (ddlBranch.SelectedItem.Text);
                        if (ddlBranch.SelectedValue == "All")
                        {
                            DataSet ds = objbs.GetBranch_New("All");
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dcustbranch = objbs.CustomerSalesBranchorder(ds.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo);
                                dsgrid.Merge(dcustbranch);
                            }
                            if (dsgrid.Tables[0].Rows.Count > 0)
                            {
                                //Label123.Text = Convert.ToString(ddlBranch.SelectedItem.Text);
                                gvCustsales.DataSource = dsgrid.Tables[0];
                                gvCustsales.DataBind();
                            }
                            else
                            {
                                gvCustsales.DataSource = null;
                                gvCustsales.DataBind();
                            }



                        }
                        else
                        {
                            dcustbranch = objbs.CustomerSalesBranchorder(ddlBranch.SelectedValue, sFrom, sTo);
                            if (dcustbranch.Tables[0].Rows.Count > 0)
                            {
                                //Label123.Text = Convert.ToString(ddlBranch.SelectedItem.Text);
                                gvCustsales.DataSource = dcustbranch.Tables[0];
                                gvCustsales.DataBind();
                            }
                            else
                            {
                                gvCustsales.DataSource = null;
                                gvCustsales.DataBind();
                            }


                        }


                        //decimal dtotal = 0;
                        //for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                        //{
                        //    dtotal += Convert.ToDecimal(dcustbranch.Tables[0].Rows[i]["Netamount"]);
                        //}
                        //decimal Total = dtotal;
                        //lblTotal.InnerText = Total.ToString();
                        //tot = Convert.ToDouble(Total);

                        getsummaryorder();
                        gvCustsales.Caption = Label123.Text + " Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");
                        decimal dtotal = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();
                        //  btnall_Click( sender, Even e)
                    }
                }
                //else
                //{

                //    int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
                //    DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);

                //    if (dsbranch1.Tables[0].Rows.Count > 0)
                //    {
                //        string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
                //        string[] wordArray = sales.Split('_');

                //        brach = wordArray[1];
                //        if (brach == "CO1")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }
                //        else if (brach == "CO2")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }
                //        else if (brach == "CO3")
                //        {
                //            Label123.Text = "Shiva Delights";
                //        }
                //        else if (brach == "CO4")
                //        {
                //            Label123.Text = "Fig and honey";
                //        }
                //        else if (brach == "CO5")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }

                //        else if (brach == "CO6")
                //        {
                //            Label123.Text = "Maduravayol";
                //        }

                //        else if (brach == "CO7")
                //        {
                //            Label123.Text = "Purasavakkam";
                //        }


                //        else if (brach == "CO8")
                //        {
                //            Label123.Text = "Chennai Pothys";
                //        }
                //        else if (brach == "CO9")
                //        {
                //            Label123.Text = "Thirunelveli";
                //        }
                //        else if (brach == "CO10")
                //        {
                //            Label123.Text = "Periyar";
                //        }
                //        else if (brach == "CO11")
                //        {
                //            Label123.Text = "Blaack Forest Bakery Services";
                //        }

                //        //  DataSet dcustbranch = objbs.CustomerSalesBranch(sTableName, txtfromdate.Text, txttodate.Text);
                //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                //        DateTime sTo = Convert.ToDateTime(txttodate.Text);

                //        DataSet dcustbranch = objbs.CustomerSalesBranchorder(brach, sFrom, sTo);
                //        if (dcustbranch.Tables[0].Rows.Count > 0)
                //        {
                //            Label123.Text = Convert.ToString(dcustbranch.Tables[0].Rows[0]["Branch"]);
                //        }

                //        gvCustsales.DataSource = dcustbranch.Tables[0];
                //        //decimal dtotal = 0;
                //        //for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                //        //{
                //        //    dtotal += Convert.ToDecimal(dcustbranch.Tables[0].Rows[i]["Netamount"]);
                //        //}
                //        //decimal Total = dtotal;
                //        //lblTotal.InnerText = Total.ToString();
                //        //tot = Convert.ToDouble(Total);
                //        gvCustsales.DataBind();
                //        getsummaryorder();

                //        gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");
                //        decimal dtotal = 0;
                //        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                //        {
                //            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                //        }
                //        decimal Total = dtotal;
                //        lblTotal.InnerText = Total.ToString();
                //        //  btnall_Click( sender, Even e)
                //    }



                //}
            }
            if (AllBranchAccess == "True")
            {
               // DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "CustomerDetailed");
               // if (getaccess.Tables[0].Rows.Count > 0)
                {
                    divPrint.Visible = true;
                    btnExport.Visible = true;
                }
                //else
                {
                  //  btnExport.Visible = false;
                  // divPrint.Visible = false;
                    //  ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Delete This Session.Thank you!!!.');", true);
                    //  return;
                }
            }
            else
            {
                DataSet getaccess = objbs.getuseraccessforeditaccess(Empid, "CustomerDetailed");
                if (getaccess.Tables[0].Rows.Count > 0)
                {
                    divPrint.Visible = true;
                    btnExport.Visible = true;
                }
                else
                {
                    btnExport.Visible = false;
                    divPrint.Visible = false;
                    //  ScriptManager.RegisterStartupScript(this, typeof(Page), "alertMessage", "alert('Do Not Have Rights To Delete This Session.Thank you!!!.');", true);
                    //  return;
                }
            }
        }

        protected void chkdisc_clicked(object sender, EventArgs e)
        {

        }

        protected void rad_chaked(object sender, EventArgs e)
        {
            getsummaryorder();
        }

        public void getsummaryorder()
        {
            DataSet elosales = new DataSet();
            DataSet dsgrid = new DataSet();
            if (chkbutton.SelectedValue == "0")
            {
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        elosales = objbs.Order_distributionFromTodate(txtfromdate.Text, txttodate.Text, ds.Tables[0].Rows[i]["BranchCode"].ToString(), chkbutton.SelectedValue);
                        dsgrid.Merge(elosales);
                    }

                    gvOrder.DataSource = dsgrid.Tables[0];
                    gvOrder.DataBind();
                }
                else
                {
                    elosales = objbs.Order_distributionFromTodate(txtfromdate.Text, txttodate.Text, ddlBranch.SelectedValue, chkbutton.SelectedValue);
                    gvOrder.DataSource = elosales.Tables[0];
                    gvOrder.DataBind();
                }
            }
            else
            {
                if (ddlBranch.SelectedValue == "All")
                {
                    DataSet ds = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        elosales = objbs.Order_distributionFromTodate(txtfromdate.Text, txttodate.Text, ds.Tables[0].Rows[i]["BranchCode"].ToString(), chkbutton.SelectedValue);
                        dsgrid.Merge(elosales);
                    }
                    gvOrder.DataSource = dsgrid.Tables[0];
                    gvOrder.DataBind();
                }
                else
                {
                    elosales = objbs.Order_distributionFromTodate(txtfromdate.Text, txttodate.Text, ddlBranch.SelectedValue, chkbutton.SelectedValue);
                    gvOrder.DataSource = elosales.Tables[0];
                    gvOrder.DataBind();
                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            {
                if (ddlBranch.SelectedValue == "All")
                {
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet ds = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodenew(ds.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dsgrid.Merge(dcustbranch);
                    }

                    ////update 22/10/21
                    //if (dcustbranch.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                    //    {
                    //        dcustbranch.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dcustbranch.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    //    }
                    //}
                    ////end update

                    gvCustsales.DataSource = dsgrid.Tables[0];
                    gvCustsales.DataBind();
                    getsummaryorder();

                    gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                    decimal dtotal = 0;
                    for (int i = 0; i < gvCustsales.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                }
                else
                {
                    {
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;
                        DataSet dcustbranch = new DataSet();


                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dcustbranch = objbs.CustomerSalesBranchpaymodenew(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                            //  dsgrid.Merge(dcustbranch);
                        }



                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummaryorder();

                        gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                        decimal dtotal = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();
                    }
                }
                //tot = Convert.ToDouble(Total);
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            //DataSet dCustReport = objbs.CustomerSalesAdmin();
            //gvCustsales.DataSource = dCustReport.Tables[0];
            //gvCustsales.DataBind();
            //getsummaryorder();

            //gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            GridView gridview = new GridView();
            //int sbranch = Convert.ToInt32(ddlBranch.SelectedValue);
            //DataSet dsbranch1 = objbs.selectbranchmaster(sbranch);
            //string name = string.Empty;

            ////gridview.Caption = Label123.Text + " Order Form Report Generated on " + DateTime.Now.ToString();

            ////  gridview.Caption = "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

            //if (dsbranch1.Tables[0].Rows.Count > 0)
            //{
            //    string sales = dsbranch1.Tables[0].Rows[0]["sales"].ToString();
            //    string[] wordArray = sales.Split('_');

            //    brach = wordArray[1];


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
            //        Label123.Text = "Chennai Pothys";
            //    }
            //    else if (brach == "CO9")
            //    {
            //        Label123.Text = "Thirunelveli";
            //    }
            //    else if (brach == "CO10")
            //    {
            //        Label123.Text = "Periyar";
            //    }
            //    else if (brach == "CO11")
            //    {
            //        Label123.Text = "Blaack Forest Bakery Services";
            //    }
            //}
            //if (sTableName == "admin")
            //{
            //    gridview.DataSource = objbs.CustomerSalesAdmin1();
            //    gridview.DataBind();
            //}

            //else
            //{
            //    gridview.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

            //    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //    DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //    string paymode = drpPayment.SelectedItem.Value;
            //    dt = objbs.CustomerSalesBranchpaymodenew(brach, sFrom, sTo, paymode);
            //    //update 22/10/21
            //    if (dt.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
            //        {
            //            dt.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dt.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
            //        }
            //    }
            //    //end update
            //    gridview.DataSource = dt.Tables[0];
            //    gridview.DataBind();
            //}
            {
                if (ddlBranch.SelectedValue == "All")
                {
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet ds = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodenew(ds.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dt.Merge(dcustbranch);
                    }

                    ////update 22/10/21
                    //if (dcustbranch.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                    //    {
                    //        dcustbranch.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dcustbranch.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    //    }
                    //}
                    ////end update

                    gridview.DataSource = dt.Tables[0];
                    gridview.DataBind();
                   // getsummaryorder();

                    gridview.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                    decimal dtotal = 0;
                    for (int i = 0; i < gvCustsales.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                }
                else
                {
                    {
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;
                        DataSet dcustbranch = new DataSet();


                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dt = objbs.CustomerSalesBranchpaymodenew(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                            //  dsgrid.Merge(dcustbranch);
                        }



                        gridview.DataSource = dt.Tables[0];
                        gridview.DataBind();
                        //getsummaryorder();

                        gridview.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                        decimal dtotal = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();
                    }
                }
                //tot = Convert.ToDouble(Total);
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
            string filename = "OrderFormReport.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            //  dgGrid.Caption = Label123.Text + " Order Form Report Generated on " + DateTime.Now.ToString();
            dgGrid.Caption = Label123 +" Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");
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
            //        Label123.Text = "Chennai Pothys";
            //    }
            //    else if (brach == "CO9")
            //    {
            //        Label123.Text = "Thirunelveli";
            //    }
            //    else if (brach == "CO10")
            //    {
            //        Label123.Text = "Periyar";
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
            //        getsummaryorder();

            //        gvCustsales.Caption = "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");
            //    }
            //    else
            //    {
            //        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

            //        DateTime sTo = Convert.ToDateTime(txttodate.Text);
            //        string paymode = drpPayment.SelectedItem.Value;

            //        DataSet ds = objbs.CustomerSalesBranchpaymodenew(brach, sFrom, sTo, paymode);
            //        //   DataSet ds = objbs.CustomerSalesBranch(sTableName, sFrom, sTo);
            //        gvCustsales.PageIndex = e.NewPageIndex;

            //        gvCustsales.DataSource = ds.Tables[0];
            //        gvCustsales.DataBind();
            //        getsummaryorder();

            //        gvCustsales.Caption = "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

            //    }
            //    decimal dtotal = 0;
            //    for (int i = 0; i < gvCustsales.Rows.Count; i++)
            //    {
            //        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
            //    }
            //    decimal Total = dtotal;
            //    lblTotal.InnerText = Total.ToString();
            //    //  tot = Convert.ToDouble(Total);


            //}
            {
                if (ddlBranch.SelectedValue == "All")
                {
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet ds = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodenew(ds.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dsgrid.Merge(dcustbranch);
                    }

                    ////update 22/10/21
                    //if (dcustbranch.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                    //    {
                    //        dcustbranch.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dcustbranch.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    //    }
                    //}
                    ////end update

                    gvCustsales.DataSource = dsgrid.Tables[0];
                    gvCustsales.PageIndex = e.NewPageIndex;
                    gvCustsales.DataBind();
                    getsummaryorder();

                    gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                    decimal dtotal = 0;
                    for (int i = 0; i < gvCustsales.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                }
                else
                {
                    {
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;
                        DataSet dcustbranch = new DataSet();


                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dcustbranch = objbs.CustomerSalesBranchpaymodenew(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                            //  dsgrid.Merge(dcustbranch);
                        }



                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.PageIndex = e.NewPageIndex;
                        gvCustsales.DataBind();
                        getsummaryorder();

                        gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                        decimal dtotal = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();
                    }
                }
                //tot = Convert.ToDouble(Total);
            }


        }
        protected void drppayment_selectedindex(object sender, EventArgs e)
        {
            {
                if (ddlBranch.SelectedValue == "All")
                {
                    DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                    DateTime sTo = Convert.ToDateTime(txttodate.Text);
                    string paymode = drpPayment.SelectedItem.Value;
                    DataSet dcustbranch = new DataSet();
                    DataSet dsgrid = new DataSet();
                    DataSet ds = objbs.GetBranch_New("All");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dcustbranch = objbs.CustomerSalesBranchpaymodenew(ds.Tables[0].Rows[i]["BranchCode"].ToString(), sFrom, sTo, paymode);
                        dsgrid.Merge(dcustbranch);
                    }

                    ////update 22/10/21
                    //if (dcustbranch.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dcustbranch.Tables[0].Rows.Count; i++)
                    //    {
                    //        dcustbranch.Tables[0].Rows[i]["BillDate"] = Convert.ToDateTime(dcustbranch.Tables[0].Rows[i]["BillDate"]).ToString("dd/MMM/yyyy");
                    //    }
                    //}
                    ////end update

                    gvCustsales.DataSource = dsgrid.Tables[0];
                    gvCustsales.DataBind();
                    getsummaryorder();

                    gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                    decimal dtotal = 0;
                    for (int i = 0; i < gvCustsales.Rows.Count; i++)
                    {
                        dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                    }
                    decimal Total = dtotal;
                    lblTotal.InnerText = Total.ToString();
                }
                else
                {
                    {
                        DateTime sFrom = Convert.ToDateTime(txtfromdate.Text);

                        DateTime sTo = Convert.ToDateTime(txttodate.Text);
                        string paymode = drpPayment.SelectedItem.Value;
                        DataSet dcustbranch = new DataSet();


                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dcustbranch = objbs.CustomerSalesBranchpaymodenew(ddlBranch.SelectedValue, sFrom, sTo, paymode);
                            //  dsgrid.Merge(dcustbranch);
                        }



                        gvCustsales.DataSource = dcustbranch.Tables[0];
                        gvCustsales.DataBind();
                        getsummaryorder();

                        gvCustsales.Caption = Label123.Text + "Sales Order Report From " + txtfromdate.Text + " To " + txttodate.Text + " For payment Mode :" + drpPayment.SelectedItem + " as on " + System.DateTime.Now.ToString("dd/MM/yyyy");

                        decimal dtotal = 0;
                        for (int i = 0; i < gvCustsales.Rows.Count; i++)
                        {
                            dtotal += Convert.ToDecimal(gvCustsales.Rows[i].Cells[8].Text);
                        }
                        decimal Total = dtotal;
                        lblTotal.InnerText = Total.ToString();
                    }
                }
                //tot = Convert.ToDouble(Total);
            }
        }

        public void gvCustsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
            


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = e.Row.FindControl("gvLiaLedger") as GridView;
                GridView gvGroup = (GridView)sender;
                if (gvGroup.DataKeys[e.Row.RowIndex].Value != "")
                {
                   // int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Value);
                  //  string[] commandArgs = gvGroup.DataKeys[e.Row.RowIndex].Value.ToString().Split(new char[] { ',' });
                    //int groupID = Convert.ToInt32(commandArgs[0]);
                    //string bbrach = commandArgs[1];

                    int groupID = Convert.ToInt32(gvGroup.DataKeys[e.Row.RowIndex].Values[0]);
                    string bbrach = gvGroup.DataKeys[e.Row.RowIndex].Values[1].ToString();

                    DataSet ds = objbs.CustomerSalesdetailedreport(groupID, bbrach);
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
                //e.Row.Cells[1].Text = HorizontalAlign.Right;
                // e.Row.Cells[7].Text = tot.ToString("N2");
                //  e.Row.Cells[7].ForeColor = System.Drawing.Color.White;

            }

            double NetAmount = 0;
            double taxamount = 0;
            double Payamount = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));
                taxamount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "taxamount"));
                Payamount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Payamount"));


                TotNetAmount = TotNetAmount + NetAmount;
                Tottaxamount = Tottaxamount + taxamount;
                TotPayamount = TotPayamount + Payamount;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = "Total :-";
                e.Row.Cells[6].Text = TotNetAmount.ToString("f2");
                e.Row.Cells[7].Text = Tottaxamount.ToString("f2");
                e.Row.Cells[8].Text = TotPayamount.ToString("f2");

            }
        }

        protected void txtfromdate_TextChanged(object sender, EventArgs e)
        {


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
            ////    if(sTableName!="admin")
            ////{
            ////    DateTime date = Convert.ToDateTime(txtfromdate.Text);
            ////    DateTime Toady = DateTime.Now.Date; ;

            ////    var days = date.Day;
            ////    var toda = Toady.Day;

            ////    //if ((toda - days) <= 2)

            ////    if ((toda - days) <= 30)
            ////    {

            ////    }

            ////    else
            ////    {
            ////        txtfromdate.Text = "";
            ////    }
            ////}
        }
    }
}