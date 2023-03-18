using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Web.UI.HtmlControls;
using System.Globalization;
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
using System.Globalization;
using System.Net.Mail;

namespace Billing.Accountsbootstrap
{
    public partial class InvoiceGenerate : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        string Place = "";
        string FirstEntry = "";
        string Label123 = "";
        string Password = "";
        string BranchType = "";

        string storename = "";

        string lblfranchise = "";

        double GQty = 0;
        double GRate = 0;
        double GTrate = 0;

        double GOCOST = 0;
        double GOGST = 0;
        double GOAmount = 0;


        double GMargin = 0;
        double GBasicValue = 0;
        double GGSTAmt = 0;
        double GNetAmount = 0;
        double SalesExempted = 0; double TaxableSales = 0;

        string AllBranchAccess = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            //Place = Session["Place"].ToString();
            sTableName =  Request.Cookies["userInfo"]["User"].ToString();
            Password = Request.Cookies["userInfo"]["Password"].ToString();

            BranchType= Request.Cookies["userInfo"]["BranchType"].ToString();
            storename = Request.Cookies["userInfo"]["Store"].ToString();
            AllBranchAccess = Request.Cookies["userInfo"]["AllBranchAccess"].ToString();

            
                

            DataSet dsPlaceName = objBs.GetPlacename(lblUser.Text, Password);

            // StoreName = dsPlaceName.Tables[0].Rows[0]["StoreName"].ToString();
            Place = dsPlaceName.Tables[0].Rows[0]["Place"].ToString();

            DataSet getfranchisee = objBs.getfarnchiseename(sTableName);
            if (getfranchisee.Tables[0].Rows.Count > 0)
            {

                lblfranchise = getfranchisee.Tables[0].Rows[0]["FranchiseeName"].ToString();
            }
            else
            {

            }

            if (!IsPostBack)
            {

                

                //RangeValidator1.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(repdays.Text)).ToShortDateString();
                //RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();

                //RangeValidator2.MinimumValue = System.DateTime.Now.AddDays(-Convert.ToDouble(repdays.Text)).ToShortDateString();
                //RangeValidator2.MaximumValue = System.DateTime.Now.ToShortDateString();


                btnsearch.Enabled = false;
                btnexcel.Enabled = false;
                btnsave.Enabled = false;

                txtfrmdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txttodate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //DataSet dsbranch;
                //if (AllBranchAccess == "true")
                //     dsbranch = objBs.GetBranch_New("All");
                //else
                  //  dsbranch = objBs.GetBranch_New(sTableName);

                //ddlbranch.DataSource = dsbranch;
                //ddlbranch.DataTextField = "BranchName";
                //ddlbranch.DataValueField = "Branchcode";
                //ddlbranch.DataBind();

                if (AllBranchAccess == "True")
                {
                    DataSet dsCustomer = objBs.GetBranch_New("All");
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        ddlbranch.DataSource = dsCustomer.Tables[0];
                        ddlbranch.DataTextField = "brancharea";
                        ddlbranch.DataValueField = "branchcode";
                        ddlbranch.DataBind();
                        ddlbranch.Items.Insert(0, "Select Branch");

                        
                    }
                }
                else
                {
                    DataSet dsCustomer = objBs.GetBranch_New(sTableName);
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        ddlbranch.DataSource = dsCustomer.Tables[0];
                        ddlbranch.DataTextField = "brancharea";
                        ddlbranch.DataValueField = "branchcode";
                        ddlbranch.DataBind();
                        ddlbranch.Items.Insert(0, "Select Branch");

                        ddlbranch.SelectedValue = sTableName;
                        ddlbranch.Enabled = false;


                    }

                }

                
                //DataSet dsinv = objBs.getinvviewonly(sTableName);
                //if (dsinv.Tables[0].Rows.Count > 0)
                //{
                //    gvinvoice.DataSource = dsinv;
                //    gvinvoice.DataBind();
                //}
                //else
                //{
                //    gvinvoice.DataSource = null;
                //    gvinvoice.DataBind();
                //}

              
            }
        }

        protected void txtpassword_OnTextChanged(object sender, EventArgs e)
        {
            DataSet adminpass = objBs.GetadminCode(lblUser.Text, Password, txtpassword.Text);
            if (adminpass.Tables[0].Rows.Count > 0)
            {
                btnsearch.Enabled = true;
                btnexcel.Enabled = true;
                btnsave.Enabled = true;
                txtpassword.Text = adminpass.Tables[0].Rows[0]["AdminPass"].ToString();
            }
            else
            {
                btnsearch.Enabled = false;
                btnexcel.Enabled = false;
                btnsave.Enabled = false;
                txtpassword.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Enter Correct Password.');", true);
                return;

            }

        }
        protected void Search_Click(object sender, EventArgs e)
        {
            if (txtfrmdate.Text == "--Select Date--" || txtfrmdate.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Date!!!.');", true);
                return;
            }
            Label123 = Place;
            DataSet dstd = new DataSet();

            
            if (radbtn.SelectedValue == "1")
            {
                div1.Visible = true;
                div4.Visible = false;
                DataSet FullValues = objBs.GetFullValuesForSalesinvoice(ddlbranch.SelectedValue, txtfrmdate.Text, txttodate.Text,lblpaymode.Text);
                //gvSalesValue.Caption = "SALES";
                //DataView view = FullValues.Tables[0].DefaultView;
                //view.Sort = " Date,Category ASC";

                DataTable dtraw = new DataTable();
                DataSet dsraw = new DataSet();
                DataRow drraw;

                dtraw.Columns.Add("Bcode");
                dtraw.Columns.Add("Date");
                dtraw.Columns.Add("grnsource");
                dtraw.Columns.Add("Category");
                dtraw.Columns.Add("Itemname");
                dtraw.Columns.Add("GST");
                dtraw.Columns.Add("Qty");
                dtraw.Columns.Add("rate");
                dtraw.Columns.Add("TotalRate");
                dtraw.Columns.Add("Margin");
                dtraw.Columns.Add("Marginvalue");
                dtraw.Columns.Add("BasicCostAfterMargin");
                dtraw.Columns.Add("GSTvalue");
                dtraw.Columns.Add("NetAmount");
                dsraw.Tables.Add(dtraw);

                if (FullValues.Tables[0].Rows.Count > 0)
                {
                    DataTable dtrawss = new DataTable();

                    dtrawss = FullValues.Tables[0];

                    var result1 = from r in dtrawss.AsEnumerable()
                                  group r by new { Bcode = r["Bcode"], Date = r["Date"], grnsource = r["grnsource"], Category = r["Category"], Itemname = r["Itemname"], GST = r["GST"],Rate=r["Rate"],margin=r["margin"] } into raw
                                  select new
                                  {
                                      Bcode = raw.Key.Bcode,
                                      Date = raw.Key.Date,
                                      grnsource = raw.Key.grnsource,
                                      Category = raw.Key.Category,
                                      Itemname = raw.Key.Itemname,
                                      GST = raw.Key.GST,
                                      Rate = raw.Key.Rate,
                                      margin = raw.Key.margin,
                                      Qty = raw.Sum(x => Convert.ToDouble(x["Qty"])),
                                      TotalRate = raw.Sum(x => Convert.ToDouble(x["TotalRate"])),
                                      Marginvalue = raw.Sum(x => Convert.ToDouble(x["Marginvalue"])),
                                      BasicCostAfterMargin = raw.Sum(x => Convert.ToDouble(x["BasicCostAfterMargin"])),
                                      GSTvalue = raw.Sum(x => Convert.ToDouble(x["GSTvalue"])),
                                      NetAmount = raw.Sum(x => Convert.ToDouble(x["NetAmount"])),
                                  };


                    foreach (var g in result1)
                    {
                        drraw = dtraw.NewRow();


                        drraw["Bcode"] = g.Bcode;
                        //
                        drraw["Date"] = Convert.ToDateTime(g.Date).ToString("dd/MMM/yyyy");
                        drraw["grnsource"] = g.grnsource;
                        drraw["Category"] = g.Category;
                        drraw["Itemname"] = g.Itemname;
                        drraw["GST"] = g.GST;
                        drraw["Qty"] = g.Qty;
                        drraw["rate"] = Convert.ToDouble(g.Rate).ToString("0.00");
                        drraw["TotalRate"] = Convert.ToDouble(g.TotalRate).ToString("0.00");;
                        drraw["Margin"] = g.margin;
                        drraw["Marginvalue"] = Convert.ToDouble(g.Marginvalue).ToString("0.00");
                        drraw["BasicCostAfterMargin"] = Convert.ToDouble(g.BasicCostAfterMargin).ToString("0.00");
                        drraw["GSTvalue"] = Convert.ToDouble(g.GSTvalue).ToString("0.00");
                        drraw["NetAmount"] = Convert.ToDouble(g.NetAmount).ToString("0.00"); 
                        dsraw.Tables[0].Rows.Add(drraw);
                    }
                   
                }
                gvSalesValue.Caption = storename + " Invoice Generated for Sales from " + Convert.ToDateTime(txtfrmdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                DataView view = dsraw.Tables[0].DefaultView;
                view.Sort = " Date,Category ASC";

                gvSalesValue.DataSource = view;
                gvSalesValue.DataBind();
            }
            else
            {
                div1.Visible = false;
                div4.Visible = true;
                DataSet FullValuesorder = objBs.GetFullValuesFororderinvoice(ddlbranch.SelectedValue, txtfrmdate.Text, txttodate.Text);
                gvorder.Caption = storename + " Invoice Generated for OrderForm from " + Convert.ToDateTime(txtfrmdate.Text).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(txttodate.Text).ToString("dd/MM/yyyy");
                DataView view = FullValuesorder.Tables[0].DefaultView;
                view.Sort = "Billdate ASC";
                gvorder.DataSource = view;
                gvorder.DataBind();

            }


        }

        protected void gvSalesValue_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double Qty = 0;
            double rate =0 ;
            double totalrate =0;
            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Qty = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Qty"));
                rate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "rate"));
                totalrate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalRate"));



                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Marginvalue"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BasicCostAfterMargin"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTvalue"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetAmount"));

                GQty = GQty + Qty;
                GRate = GRate + rate;
                GTrate = GTrate + totalrate;
                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;
                GGSTAmt = GGSTAmt + GSTAmt;
                GNetAmount = GNetAmount + NetAmount;


                double GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                if (GST == 0)
                {
                    SalesExempted += NetAmount;
                }
                else
                {
                    TaxableSales += NetAmount;
                }

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {


                e.Row.Cells[5].Text = "Total";

                e.Row.Cells[6].Text = GQty.ToString("f2");
                e.Row.Cells[7].Text = GRate.ToString("f2");
                e.Row.Cells[8].Text = GTrate.ToString("f2");



                e.Row.Cells[10].Text = GMargin.ToString("f2");
                e.Row.Cells[11].Text = GBasicValue.ToString("f2");

                e.Row.Cells[12].Text = GGSTAmt.ToString("f2");
                e.Row.Cells[13].Text = GNetAmount.ToString("f2");

               // e.Row.Cells[14].Text = GNetAmount.ToString("f2");


                lblsalesexempted.Text = SalesExempted.ToString("f2");
                lbltaxablesales.Text = TaxableSales.ToString("f2");
                lblcgst.Text = GGSTAmt.ToString("f2");
                //lblsgst.Text = GGSTAmt.ToString("f2");
                lblnetamount.Text = (GNetAmount + GGSTAmt).ToString("f2");





                double n = 0;

                double roundoff = Convert.ToDouble(lblnetamount.Text) - Math.Floor(Convert.ToDouble(lblnetamount.Text));
                if (roundoff >= 0.5)
                {
                    n = Math.Round(Convert.ToDouble(lblnetamount.Text), MidpointRounding.AwayFromZero);

                }
                else
                {
                    n = Math.Floor(Convert.ToDouble(lblnetamount.Text));

                }

                lblfinalamount.Text = string.Format("{0:N2}", n);

                double rndoff = Convert.ToDouble(lblfinalamount.Text) - Convert.ToDouble(lblnetamount.Text);

                lblroundoff.Text = string.Format("{0:N2}", Convert.ToDouble(rndoff));


            }
        }
        protected void gvorder_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            double Margin = 0;
            double BasicValue = 0;
            double GSTAmt = 0;
            double NetAmount = 0;


            double COST = 0;
            double GST = 0;
            double Amount = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {


                COST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "COST"));
                GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                Amount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
                
                Margin = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Margin"));
                BasicValue = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "castbeforemargin"));
                GSTAmt = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GSTV"));
                NetAmount = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "NetamountV"));

                GOCOST = GOCOST + COST;
                GOGST = GOGST + GST;
                GOAmount = GOAmount + Amount;

                GMargin = GMargin + Margin;
                GBasicValue = GBasicValue + BasicValue;
                GGSTAmt = GGSTAmt + GSTAmt;
                GNetAmount = GNetAmount + NetAmount;


                //double GST = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GST"));
                //if (GST == 0)
                //{
                //    SalesExempted += NetAmount;
                //}
                //else
                //{
                    TaxableSales += NetAmount;
                //}

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {


                e.Row.Cells[6].Text = "Total";
                e.Row.Cells[7].Text = GOCOST.ToString("f2");
                e.Row.Cells[8].Text = GOGST.ToString("f2");
                e.Row.Cells[10].Text = GOAmount.ToString("f2");


                e.Row.Cells[12].Text = GMargin.ToString("f2");
                e.Row.Cells[13].Text = GBasicValue.ToString("f2");

                e.Row.Cells[14].Text = GGSTAmt.ToString("f2");
                e.Row.Cells[15].Text = GNetAmount.ToString("f2");

                // e.Row.Cells[14].Text = GNetAmount.ToString("f2");


                //lblsalesexempted.Text = SalesExempted.ToString("f2");
                lbltaxablesalesorder.Text = TaxableSales.ToString("f2");
                lblcgstorder.Text = GGSTAmt.ToString("f2");
                //lblsgst.Text = GGSTAmt.ToString("f2");
                lblnetamountorder.Text = (GNetAmount).ToString("f2");





                double n = 0;

                double roundoff = Convert.ToDouble(lblnetamountorder.Text) - Math.Floor(Convert.ToDouble(lblnetamountorder.Text));
                if (roundoff >= 0.5)
                {
                    n = Math.Round(Convert.ToDouble(lblnetamountorder.Text), MidpointRounding.AwayFromZero);

                }
                else
                {
                    n = Math.Floor(Convert.ToDouble(lblnetamountorder.Text));

                }

                lblfinalamountorder.Text = string.Format("{0:N2}", n);

                double rndoff = Convert.ToDouble(lblfinalamountorder.Text) - Convert.ToDouble(lblnetamountorder.Text);

                lblroundofforder.Text = string.Format("{0:N2}", Convert.ToDouble(rndoff));


            }
        }

        protected void gvinvoice_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDate")
            {
                if (e.CommandArgument.ToString() != "")
                {

                    DataSet dsinv = objBs.getinvview(sTableName, e.CommandArgument.ToString());
                    if (dsinv.Tables[0].Rows.Count > 0)
                    {
                        lblinvoiceno.Text = dsinv.Tables[0].Rows[0]["InvoiceNo"].ToString();
                        lblinvoicedate.Text = Convert.ToDateTime(dsinv.Tables[0].Rows[0]["Date"]).ToString("yyyy-MM-dd");

                        gvSalesValue.Caption = "SALES";
                        gvSalesValue.DataSource = dsinv;
                        gvSalesValue.DataBind();
                    }
                    else
                    {
                        gvSalesValue.DataSource = null;
                        gvSalesValue.DataBind();
                    }
                }
            }

        }



        protected void btnsave_Click(object sender, EventArgs e)
        {

           // DateTime Date = DateTime.ParseExact(txtfrmdate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

           // DataSet dsgrninvoice = objBs.checkgrninvoice(sTableName, Date);
           // if (dsgrninvoice.Tables[0].Rows.Count > 0)
           // {
           //     ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Already Invoice Generate for This Date " + txtfrmdate.Text + ".');", true);
           //     return;

           // }
           // else if (gvSalesValue.Rows.Count == 0)
           // {
           //     ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Data Found.');", true);
           //     return;
           // }
           // else
           // {

           //     int InvoiceNo = objBs.insertgrninvoice(sTableName, Date, Convert.ToDouble(lblsalesexempted.Text), Convert.ToDouble(lbltaxablesales.Text), Convert.ToDouble(lblcgst.Text), Convert.ToDouble(lblsgst.Text), Convert.ToDouble(lblnetamount.Text), lblroundoff.Text, Convert.ToDouble(lblfinalamount.Text));

           //     foreach (GridViewRow row in gvSalesValue.Rows)
           //     {
           //         string hdcategoryid = ((HiddenField)row.FindControl("hdcategoryid")).Value;
           //         string hdcategoryuserid = ((HiddenField)row.FindControl("hdcategoryuserid")).Value;

           //         string Category = row.Cells[1].Text;
           //         string Item = row.Cells[2].Text;
           //         string GST = row.Cells[3].Text;
           //         string Qty = row.Cells[4].Text;
           //         string Rate = row.Cells[5].Text;
           //         string TotalRate = row.Cells[6].Text;
           //         string MarginValue = row.Cells[7].Text;
           //         string Margin = row.Cells[8].Text;
           //         string BasicValue = row.Cells[9].Text;
           //         string CGSTVal = row.Cells[10].Text;
           //         string CGST = row.Cells[11].Text;
           //         string SGSTVal = row.Cells[12].Text;
           //         string SGST = row.Cells[13].Text;
           //         string NetAmount = row.Cells[14].Text;

           //         int TransInvoiceNo = objBs.inserttransgrninvoice(sTableName, InvoiceNo, Convert.ToInt32(hdcategoryid), Convert.ToInt32(hdcategoryuserid),
           //Category, Item, Convert.ToDouble(GST), Convert.ToDouble(Qty),
           //Convert.ToDouble(Rate), Convert.ToDouble(TotalRate), Convert.ToDouble(MarginValue), Convert.ToDouble(Margin),
           //Convert.ToDouble(BasicValue), Convert.ToDouble(CGSTVal), Convert.ToDouble(CGST), Convert.ToDouble(SGSTVal),
           //Convert.ToDouble(SGST), Convert.ToDouble(NetAmount));


           //     }


           //     ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invoice Generate for this Date ');", true);
           //     return;

           //     Response.Redirect("InvoiceGenerate.aspx");
           // }

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            if (div1.Visible == true)
            {
                Response.AddHeader("content-disposition", "attachment;filename= SalesReport.xls");
                div1.RenderControl(htmlWrite);
            }
            else
            {
                Response.AddHeader("content-disposition", "attachment;filename= OrderReport.xls");
                div4.RenderControl(htmlWrite);
            }
            Response.Write(stringWrite.ToString());
            Response.End();

            //////DataSet FullValues = new DataSet();
            //////HtmlForm form = new HtmlForm();
            //////Response.Clear();
            //////Response.Buffer = true;
            //////string filename = "Reports_" + DateTime.Now.ToString() + ".xls";
            //////DataSet dstd = new DataSet();

            //////if (ddlsalestype.SelectedValue == "1")
            //////{
            //////    FullValues = objBs.GetFullValuesForSalesinvoice(sTableName, txtfrmdate.Text);
            //////    gvSalesValue.Caption = "SALES";
            //////    gvSalesValue.DataSource = FullValues;
            //////    gvSalesValue.DataBind();

            //////}
            //////else
            //////{
            //////    //FullValues = objBs.GetFullValuesFororderdate1(sTableName, txtfrmdate.Text, txttodate.Text);
            //////    //gvSalesValue.Caption = "ORDER";
            //////    //gvSalesValue.DataSource = FullValues;
            //////    //gvSalesValue.DataBind();

            //////}



            //////if (FullValues.Tables[0].Rows.Count > 0)
            //////{
            //////    decimal Margin = 0;
            //////    decimal BasicValue = 0;
            //////    decimal GST = 0;
            //////    decimal NetAmount = 0;

            //////    DataTable dttt;
            //////    DataRow drNew;
            //////    DataColumn dct;

            //////    dttt = new DataTable();


            //////    dct = new DataColumn("Category");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("Name Of Items");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("GST");
            //////    dttt.Columns.Add(dct);


            //////    dct = new DataColumn("Qty");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("Rate");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("TotalRate");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("Margin");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("BasicValue");
            //////    dttt.Columns.Add(dct);


            //////    dct = new DataColumn("CGST %");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("CGST");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("SGST %");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("SGST");
            //////    dttt.Columns.Add(dct);

            //////    dct = new DataColumn("NetAmount");
            //////    dttt.Columns.Add(dct);
            //////    dstd.Tables.Add(dttt);

            //////    foreach (DataRow dr in FullValues.Tables[0].Rows)
            //////    {
            //////        drNew = dttt.NewRow();
            //////        drNew["Category"] = dr["Category"];
            //////        drNew["Name Of Items"] = dr["Definition"];
            //////        drNew["GST"] = dr["GST"];
            //////        drNew["Qty"] = dr["Qty"];
            //////        drNew["Rate"] = dr["Rate"];
            //////        drNew["TotalRate"] = Convert.ToDecimal(dr["TotalRate"]).ToString("f2");

            //////        drNew["Margin"] = Convert.ToDecimal(dr["Margin"]).ToString("f2");
            //////        Margin = Margin + Convert.ToDecimal(dr["Margin"]);

            //////        drNew["BasicValue"] = Convert.ToDecimal(dr["BasicValue"]).ToString("f2");
            //////        BasicValue = BasicValue + Convert.ToDecimal(dr["BasicValue"]);

            //////        drNew["CGST %"] = Convert.ToDecimal(dr["CGST"]).ToString("f2");
            //////        drNew["CGST"] = Convert.ToDecimal(dr["GSTAmt"]).ToString("f2");
            //////        drNew["SGST %"] = Convert.ToDecimal(dr["CGST"]).ToString("f2");
            //////        drNew["SGST"] = Convert.ToDecimal(dr["GSTAmt"]).ToString("f2");

            //////        GST = GST + Convert.ToDecimal(dr["GSTAmt"]);

            //////        drNew["NetAmount"] = Convert.ToDecimal(dr["NetAmount"]).ToString("f2");
            //////        NetAmount = NetAmount + Convert.ToDecimal(dr["NetAmount"]);

            //////        dstd.Tables[0].Rows.Add(drNew);
            //////    }

            //////    drNew = dttt.NewRow();
            //////    drNew["Category"] = "";
            //////    drNew["Name Of Items"] = "";
            //////    drNew["GST"] = "";
            //////    drNew["Qty"] = "";
            //////    drNew["Rate"] = "";
            //////    drNew["TotalRate"] = "";
            //////    drNew["Margin"] = Convert.ToDecimal(Margin.ToString("f2"));
            //////    drNew["BasicValue"] = Convert.ToDecimal(BasicValue.ToString("f2"));
            //////    drNew["CGST %"] = "";
            //////    drNew["CGST"] = Convert.ToDecimal(GST.ToString("f2"));
            //////    drNew["SGST %"] = "";
            //////    drNew["SGST"] = Convert.ToDecimal(GST.ToString("f2"));
            //////    drNew["NetAmount"] = Convert.ToDecimal(NetAmount).ToString("f2");
            //////    dstd.Tables[0].Rows.Add(drNew);
            //////}

            //////ExportToExcel(filename, dstd);
        }

        private void ExportToExcel(string filename, DataSet dt)
        {
            if (dt.Tables[0].Rows.Count > 0)
            {

                if (sTableName == "CO1")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }
                else if (sTableName == "CO2")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }
                else if (sTableName == "CO3")
                {
                    Label123 = "Shiva Delights";
                }
                else if (sTableName == "CO4")
                {
                    Label123 = "Fig and honey";
                }
                else if (sTableName == "CO5")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }

                else if (sTableName == "CO6")
                {
                    Label123 = "Maduravayol";
                }

                else if (sTableName == "CO7")
                {
                    Label123 = "purasavakkam";
                }

                else if (sTableName == "CO8")
                {
                    Label123 = "Chennai Pothys";
                }


                else if (sTableName == "CO9")
                {
                    Label123 = "Thirunelveli";
                }


                else if (sTableName == "CO10")
                {
                    Label123 = "Periyar";
                }

                else if (sTableName == "CO11")
                {
                    Label123 = "Blaack Forest Bakery Services";
                }

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
               
                dgGrid.DataSource = dt;
                dgGrid.DataBind();
                dgGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSkyBlue;
                dgGrid.HeaderStyle.BorderColor = System.Drawing.Color.RoyalBlue;
                dgGrid.FooterStyle.ForeColor = System.Drawing.Color.Red;
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
        }

        // This Method is used to render gridview control
        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            //gv.RenderControl(htw);
            div1.RenderControl(htw);
            return strBuilder.ToString();
        }

        // This Method is used to render gridview control
        public string GetGridviewData_order(GridView gv)
        {
            div1.Visible = true;
            div4.Visible = true;
            DataSet FullValuesorder = objBs.GetFullValuesFororderinvoice(ddlbranch.SelectedValue, txtfrmdate.Text, txttodate.Text);
            gvorder.Caption = "Order Form";
            DataView view = FullValuesorder.Tables[0].DefaultView;
            view.Sort = "Billdate ASC";
            gvorder.DataSource = view;
            gvorder.DataBind();



            StringBuilder strBuilder = new StringBuilder();
            System.IO.StringWriter strWriter = new System.IO.StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            //gv.RenderControl(htw);
            div4.RenderControl(htw);
            return strBuilder.ToString();
        }

        protected void Email_Click(object sender, EventArgs e)
        {
            SendHTMLMail();
            SendHTMLMail_order();
        }

        public void SendHTMLMail_order()
        {

            MailMessage Msg = new MailMessage();
            //MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            Msg.From = new MailAddress("jothics0792@gmail.com", "Order Form Invoice Report " + lblfranchise + "");


            // Subject of e-mail
            Msg.Subject = "Order Form Report For " + storename + " in EMail";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "<br/> Order Form Flow Details <br/>";
            Msg.Body += GetGridviewData_order(gvSalesValue);



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
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }

        public void SendHTMLMail()
        {

            MailMessage Msg = new MailMessage();
            //MailAddress fromMail = new MailAddress("BlaackForest@bigdbiz.com");
            Msg.From = new MailAddress("jothics0792@gmail.com", "GRN source Report (" + BranchType + ") For " + lblfranchise + "");


            // Subject of e-mail
            Msg.Subject = "GRN source Report (" + BranchType + ") For " + storename + "";
            Msg.Body += "Please check below data <br/><br/>";
            Msg.Body += "<br/> Details Report <br/>";



            
            Msg.Body += GetGridviewData(gvSalesValue);

           

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
            smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]); ; ;
            smtp.Credentials = NetworkCred;
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPortNumber"]);
            smtp.Send(Msg);
        }


     
    }
}
