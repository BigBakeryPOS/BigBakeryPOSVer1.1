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
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

namespace Billing.Accountsbootstrap
{
    public partial class SalesReport : System.Web.UI.Page
    {
        string sTablename = "";
        string Sort_Direction = "BillNo ASC";
        string Sort_Direction1 = "CustomerName ASC";
        BSClass objBs = new BSClass();
        string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTablename = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
               

                ViewState["SortExpr"] = Sort_Direction;
                ViewState["SortExpr"] = Sort_Direction1;
                DataSet ds=new DataSet();
                if (sTablename == "admin")
                {
                    ds = objBs.GenSalesReport();
                    
                    btnedit.Visible = true;
                    radio.Visible = true;

                }
                else
                {
                    radio.Visible = false;
                    ds = objBs.GenSalesReport_Dealer("tblsales_" + sTablename);
                 
                    btnedit.Visible = false;
                }
                gvsales.DataSource = ds;
                gvsales.DataBind();
                DataSet Dtotal = new DataSet();

                if (sTablename == "admin")
                {
                    Dtotal = objBs.GenSalesReport();
                    decimal dTotal = 0;
                    for (int i = 0; i < Dtotal.Tables[0].Rows.Count; i++)
                    {
                        if (Dtotal.Tables[0].Rows[i]["NetAmount"].ToString() != "")
                            if (Dtotal.Tables[0].Rows.Count > 0)
                            {
                                dTotal += Convert.ToDecimal(Dtotal.Tables[0].Rows[i]["NetAmount"].ToString());
                            }
                    }
                    lblsum.Text = string.Format("{0:N2}", dTotal);
                }
                else
                {
                    Dtotal = objBs.TotalSalesAmount_Dealer("tblsales_" + sTablename);
                    if (Dtotal.Tables[0].Rows.Count > 0)
                    {
                        if (Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString() != "")
                        {
                            decimal dsum = Convert.ToDecimal(Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString());
                            lblsum.Text = string.Format("{0:N2}", dsum);
                        }
                        else
                        {
                                                   }
                    }
                   
                }

            }
        }

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Redirect("cashsales.aspx?iSalesID=" + e.CommandArgument.ToString());
                }
            }
        }

        protected void Page_Change(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = new DataSet();
            if(sTablename=="admin")
                ds = objBs.GenSalesReport();
            else
                ds = objBs.GenSalesReport_Dealer("tblsales_" + sTablename);

            gvsales.PageIndex = e.NewPageIndex;
            DataView dvEmployee = ds.Tables[0].DefaultView;
            gvsales.DataSource = dvEmployee;
            gvsales.DataBind();
          
                //if (ddselect.SelectedValue == "1")
                //{
                //    DataSet Ddealer = objBs.DealerSalesRepForAdmin();
                //    gvsales.PageIndex = e.NewPageIndex;
                //    DataView dvEmployee1 = Ddealer.Tables[0].DefaultView;
                //    gvsales.DataSource = dvEmployee;
                //    gvsales.DataBind();
                //}
                //else if (ddselect.SelectedValue == "2")
                //{
                //    DataSet Dbranch = objBs.BranchSalesRepForAdmin();
                //    gvsales.PageIndex = e.NewPageIndex;
                //    DataView dvEmployee1 = Dbranch.Tables[0].DefaultView;
                //    gvsales.DataSource = dvEmployee;
                //    gvsales.DataBind();
                //}
            }


        protected void btnexcel_Click(object sender, EventArgs e)
        {
            if (sTablename == "admin")
            {
                GridView gvsales = new GridView();
                gvsales.DataSource = objBs.GenSalesReport();
                gvsales.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=SalesReport.xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw = new StringWriter(); ;
                HtmlTextWriter htm = new HtmlTextWriter(sw);
                gvsales.RenderControl(htm);
                Response.Write(sw.ToString());
                Response.End();
            }
            else
            {
                GridView gvsales2 = new GridView();
                gvsales2.DataSource = objBs.GenSalesReport_Dealer("tblsales_" + sTablename);
                gvsales2.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition",
                    "attachment;filename=SalesReport.xls");
                Response.ContentType = "applicatio/excel";
                StringWriter sw1 = new StringWriter(); ;
                HtmlTextWriter htm1 = new HtmlTextWriter(sw1);
                gvsales2.RenderControl(htm1);
                Response.Write(sw1.ToString());
                Response.End();
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            txtMode.Text = "Generate";
            //DateTime dtFrom = Convert.ToDateTime(txtfrmdate.Text);
            //DateTime dtTo = Convert.ToDateTime(txttodate.Text);
            string sFrom = txtfrmdate.Text;
            string sTo = txttodate.Text;
            DataSet ds = new DataSet();
            if (sTablename == "admin")
            {
                ds = objBs.GenSalesReport(sFrom, sTo);
            }
            else
            {
                ds = objBs.GenSalesReport_Dealer(sFrom, sTo, "tblsales_" + sTablename);
            }
            gvsales.DataSource = ds;
            gvsales.DataBind();

            DataSet Dtotal = new DataSet();
            if (sTablename == "admin")
            {
                 Dtotal = objBs.TotalSalesAmount(sFrom, sTo);
                 decimal dTotal = 0;
                 for (int i = 0; i < Dtotal.Tables[0].Rows.Count; i++)
                 {
                     if (Dtotal.Tables[0].Rows[i]["TotalAmount"].ToString() != "")
                         if (Dtotal.Tables[0].Rows.Count > 0)
                         {
                             dTotal += Convert.ToDecimal(Dtotal.Tables[0].Rows[i]["TotalAmount"].ToString());
                         }
                 }
                 lblsum.Text = string.Format("{0:N2}", dTotal);
            }
            else
            {
                 Dtotal = objBs.TotalSalesAmount_Dealer(sFrom, sTo, "tblsales_" + sTablename);
            }
            if (Dtotal.Tables[0].Rows.Count > 0)
            {
                if (Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString() != "")
                {
                    decimal dsum = Convert.ToDecimal(Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString());
                    lblsum.Text = string.Format("{0:N2}", dsum);
                }
            }
            
           // lblsum.Text = Dtotal2.Tables[0].Rows[0]["TotalAmount"].ToString();
           
                //if (ddselect.SelectedValue == "1")
                //{
                //    DataSet dsdeal = objBs.DealerTotalSalesAmount(sFrom, sTo);
                //    gvsales.DataSource = dsdeal;
                //    gvsales.DataBind();
                //    DataSet Dtotaldeal = objBs.DealerSum(sFrom, sTo);
                //    lblsum.Text = Dtotaldeal.Tables[0].Rows[0]["TotalAmount"].ToString();
                //}

                //else if (ddselect.SelectedValue == "2")
                //{
                //    DataSet dsbranch = objBs.BranchTotalSalesAmount(sFrom, sTo);
                //    gvsales.DataSource = dsbranch;
                //    gvsales.DataBind();
                //    DataSet Dtotalbran = objBs.BranchrSum(sFrom, sTo);
                //    lblsum.Text = Dtotalbran.Tables[0].Rows[0]["TotalAmount"].ToString();
                //}
            
            }
        

        protected void gvsales_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] SortOrder = ViewState["SortExpr"].ToString().Split(' ');
            if (SortOrder[0] == e.SortExpression)
            {
                if (SortOrder[1] == "ASC")
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
                }
            }
            else
            {
                ViewState["SortExpr"] = e.SortExpression + " " + "ASC";
            }
            DataSet ds = objBs.GenSalesReport();
            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gvsales.DataSource = dvEmp;
            gvsales.DataBind();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            txtMode.Text = "Edit";
            DataSet dViewEbill = objBs.viewEditedBill();
            gvsales.DataSource = dViewEbill;
            gvsales.DataBind();
            decimal dTotal = 0;
            for (int i = 0; i < dViewEbill.Tables[0].Rows.Count; i++)
            {
                if (dViewEbill.Tables[0].Rows[i]["NetAmount"].ToString() != "")

                    dTotal += Convert.ToDecimal(dViewEbill.Tables[0].Rows[i]["NetAmount"].ToString());
            }

            lblsum.Text = string.Format("{0:N2}", dTotal); //dTotal.ToString();

        }

        protected void btnall_Click(object sender, EventArgs e)
        {
            txtMode.Text = "All";
            DataSet dAll = objBs.GenSalesReport();
            gvsales.DataSource = dAll;
            gvsales.DataBind();
            decimal dTotal = 0;
            for (int i = 0; i < dAll.Tables[0].Rows.Count; i++)
            {
                if (dAll.Tables[0].Rows[i]["NetAmount"].ToString() != "")

                    dTotal += Convert.ToDecimal(dAll.Tables[0].Rows[i]["NetAmount"].ToString());
            }

            lblsum.Text = string.Format("{0:N2}", dTotal); //dTotal.ToString();
        }

        protected void rbBranch1_CheckedChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            string sFrom = txtfrmdate.Text;
            string sTo = txttodate.Text;
            DataSet ds = new DataSet();
            if (sFrom != "" && sTo != "")
            {
                if (txtMode.Text == "Generate")
                {
                    ds = objBs.GenSalesReport_Branch1(sFrom, sTo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = ds;
                        gvsales.DataBind();
                    }
                    DataSet Dtotal = new DataSet();
                    Dtotal = objBs.TotalSalesAmount_Branch1(sFrom, sTo);
                   decimal dSum=Convert.ToDecimal( Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString());
                   lblsum.Text = string.Format("{0:N2}", dSum);
                }
                else if (txtMode.Text == "Edit")
                {
                    DataSet dViewEbill = objBs.viewEditedBill_Branch1();
                    if (dViewEbill.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dViewEbill;
                        gvsales.DataBind();
                    }
                }
                else if (txtMode.Text == "All")
                {
                    DataSet dAll = objBs.GenSalesReport_Branch1();
                    if (dAll.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dAll;
                        gvsales.DataBind();
                    }
                }
            }
            else
            {
                ds = objBs.GenSalesReport_Branch1();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
            }
        }

        protected void rbBranch2_CheckedChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            string sFrom = txtfrmdate.Text;
            string sTo = txttodate.Text;
            DataSet ds = new DataSet();
            if (sFrom != "" && sTo != "")
            {
                if (txtMode.Text == "Generate")
                {
                    ds = objBs.GenSalesReport_Branch2(sFrom, sTo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = ds;
                        gvsales.DataBind();
                    }
                    DataSet Dtotal = new DataSet();
                    Dtotal = objBs.TotalSalesAmount_Branch2(sFrom, sTo);
                    decimal dsum = Convert.ToDecimal(Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString());
                    lblsum.Text = string.Format("{0:N2}", dsum);
                }
                else if (txtMode.Text == "Edit")
                { 
                    DataSet dViewEbill = objBs.viewEditedBill_Branch2();
                    if (dViewEbill.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dViewEbill;
                        gvsales.DataBind();
                    }
                }
                else if (txtMode.Text == "All")
                {
                    DataSet dAll = objBs.GenSalesReport_Branch2();
                    if (dAll.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dAll;
                        gvsales.DataBind();
                    }
                }
                
            }
            else
            {
                ds = objBs.GenSalesReport_Branch2();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
            }
        }

        protected void rbBranch3_CheckedChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            string sFrom = txtfrmdate.Text;
            string sTo = txttodate.Text;
            DataSet ds = new DataSet();
            if (sFrom != "" && sTo != "")
            {
                if (txtMode.Text == "Generate")
                {
                    ds = objBs.GenSalesReport_Branch3(sFrom, sTo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = ds;
                        gvsales.DataBind();
                    }
                    DataSet Dtotal = new DataSet();
                    Dtotal = objBs.TotalSalesAmount_Branch3(sFrom, sTo);
                    decimal dsum = Convert.ToDecimal(Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString());
                    lblsum.Text = string.Format("{0:N2}", dsum);
                }
                else if (txtMode.Text == "Edit")
                {
                    DataSet dViewEbill = objBs.viewEditedBill_Branch3();
                    if (dViewEbill.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dViewEbill;
                        gvsales.DataBind();
                    }
                }
                else if (txtMode.Text == "All")
                {
                    DataSet dAll = objBs.GenSalesReport_Branch3();
                    if (dAll.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dAll;
                        gvsales.DataBind();
                    }
                }
            }
            else
            {
                ds = objBs.GenSalesReport_Branch3();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }
            }
        }

        protected void rbBranch4_CheckedChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            string sFrom = txtfrmdate.Text;
            string sTo = txttodate.Text;
            DataSet ds = new DataSet();
            if (sFrom != "" && sTo != "")
            {
                if (txtMode.Text == "Generate")
                {
                    ds = objBs.GenSalesReport(sFrom, sTo);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = ds;
                        gvsales.DataBind();
                    }
                    DataSet Dtotal = new DataSet();
                    Dtotal = objBs.TotalSalesAmount(sFrom, sTo);
                    decimal dsum = Convert.ToDecimal(Dtotal.Tables[0].Rows[0]["TotalAmount"].ToString());
                    lblsum.Text = string.Format("{0:N2}", dsum);
                }
                else if (txtMode.Text == "Edit")
                {
                    DataSet dViewEbill = objBs.viewEditedBill();
                    if (dViewEbill.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dViewEbill;
                        gvsales.DataBind();
                    }
                }
                else if (txtMode.Text == "All")
                {
                    DataSet dAll = objBs.GenSalesReport();
                    if (dAll.Tables[0].Rows.Count > 0)
                    {
                        gvsales.DataSource = dAll;
                        gvsales.DataBind();
                    }
                }
            }
            else
            {
                ds = objBs.GenSalesReport();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvsales.DataSource = ds;
                    gvsales.DataBind();
                }

            }
        }
       
    }
}