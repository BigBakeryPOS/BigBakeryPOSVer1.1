using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;


namespace Billing.Accountsbootstrap
{
    public partial class OutstandingPayment : System.Web.UI.Page
    { 
        BSClass objBs = new BSClass();
        string sTableName = "";
        string Sort_Direction1 = "CustomerName ASC";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            lbltotal.Visible = false;
            if (!IsPostBack)
            {
              
                ViewState["SortExpr"] = Sort_Direction1;
                if (sTableName == "admin")
                {
                    lbltotal.Visible = true;
                    DataSet dsCustomer = objBs.AdminCustomerID();
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        ddcustomer.DataSource = dsCustomer.Tables[0];
                        ddcustomer.DataTextField = "CustomerName";
                        ddcustomer.DataValueField = "CustomerID";
                        ddcustomer.DataBind();
                        ddcustomer.Items.Insert(0, "Select Contact");

                        // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();
                    }
                }
                else
                {
                DataSet dsCustomer = objBs.CustomerID(Convert.ToInt32(lblUserID.Text), "tblSales_" + sTableName);
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddcustomer.DataSource = dsCustomer.Tables[0];
                    ddcustomer.DataTextField = "CustomerName";
                    ddcustomer.DataValueField = "CustomerID";
                    ddcustomer.DataBind();
                    ddcustomer.Items.Insert(0, "Select Contact");

                    // ddlcustomerID.Text = dsCustomer.Tables[0].Rows[0]["CustomerID"].ToString();
                }
                }
                DataSet dsAllOutstanding = new DataSet();
                if (sTableName == "admin")
                {
                    lbltotal.Visible = true;
                     dsAllOutstanding = objBs.GetAllOutstandingAmount();
                     if (dsAllOutstanding.Tables[0].Rows.Count> 0)
                     {
                       
                            
                         decimal dBillAmt=0 ,dPaid=0,dPending=0;
                         for (int i = 0; i < dsAllOutstanding.Tables[0].Rows.Count; i++)
                         {
                            // dBillAmt += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["BillAmount"].ToString());
                             dPaid += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["PaidAmount"].ToString());
                             dPending += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["Balance"].ToString());

                         }

                         lblBillAmt.InnerText = string.Format("{0:N2}", dBillAmt);
                         lblPaid.InnerText = string.Format("{0:N2}", dPaid);
                         lblPending.InnerText = string.Format("{0:N2}", dPending);
                         DataRow dr = dsAllOutstanding.Tables[0].NewRow();
                         dr["CustomerName"] = "Total";
                         
                         dr["BillAmount"] = lblBillAmt.InnerText;
                         dr["PaidAmount"] = lblPaid.InnerText;
                         dr["Balance"] = lblPending.InnerText;

                        
                         dsAllOutstanding.Tables[0].Rows.Add(dr);
                     

                         gvpending.DataSource = dsAllOutstanding;
                         gvpending.DataBind();
                     }
                 
                }
                else
                {
                     dsAllOutstanding = objBs.GetOutstandingAmount("tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName,"tblSales_"+sTableName);
                     if (dsAllOutstanding.Tables[0].Rows.Count > 0)
                     {
                         
                             gvpending.DataSource = dsAllOutstanding;
                             gvpending.DataBind();
                         
                     }
                }
                
            }
        }

        protected void search(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                lbltotal.Visible = true;
                DataSet ds = objBs.AdminOutstandingAmount(ddcustomer.SelectedValue);
                
                decimal dBillAmt = 0, dPaid = 0, dPending = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   // dBillAmt += Convert.ToDecimal(ds.Tables[0].Rows[i]["BillAmount"].ToString());
                    dPaid += Convert.ToDecimal(ds.Tables[0].Rows[i]["PaidAmount"].ToString());
                    dPending += Convert.ToDecimal(ds.Tables[0].Rows[i]["Balance"].ToString());

                }

                lblBillAmt.InnerText = string.Format("{0:N2}", dBillAmt);
                lblPaid.InnerText = string.Format("{0:N2}", dPaid);
                lblPending.InnerText = string.Format("{0:N2}", dPending);
                DataRow dr = ds.Tables[0].NewRow();
                dr["CustomerName"] = "";
                dr["BillNo"] = Convert.ToInt32(0);
                dr["BillAmount"] = lblBillAmt.InnerText;
                dr["PaidAmount"] = lblPaid.InnerText;
                dr["Balance"] = lblPending.InnerText;
                ds.Tables[0].Rows.Add(dr);
                gvpending.DataSource = ds;
                gvpending.DataBind();
            }
            else
            {
                DataSet ds = objBs.GetOutstandingAmounts(ddcustomer.SelectedValue, "tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName, "tblSales_" + sTableName);
                gvpending.DataSource = ds;
                gvpending.DataBind();
            }
            
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            DataSet dsAllOutstanding = new DataSet();
            if (sTableName == "admin")
            {
                lbltotal.Visible = true;
                dsAllOutstanding = objBs.GetAllOutstandingAmount();


            }
            else
            {
                dsAllOutstanding = objBs.GetOutstandingAmount("tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName, "tblSales_" + sTableName);

            }


            GridView gvpending = new GridView();
          
            decimal dBillAmt = 0, dPaid = 0, dPending = 0;
            for (int i = 0; i < dsAllOutstanding.Tables[0].Rows.Count; i++)
            {
                //dBillAmt += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["BillAmount"].ToString());
                dPaid += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["PaidAmount"].ToString());
                dPending += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["Balance"].ToString());

            }

            lblBillAmt.InnerText = string.Format("{0:N2}", dBillAmt);
            lblPaid.InnerText = string.Format("{0:N2}", dPaid);
            lblPending.InnerText = string.Format("{0:N2}", dPending);
            DataRow dr = dsAllOutstanding.Tables[0].NewRow();
            dr["CustomerName"] = "";
            dr["BillNo"] = Convert.ToInt32(0);
            dr["BillAmount"] = lblBillAmt.InnerText;
            dr["PaidAmount"] = lblPaid.InnerText;
            dr["Balance"] = lblPending.InnerText;
            dsAllOutstanding.Tables[0].Rows.Add(dr);
            gvpending.DataSource = dsAllOutstanding;
            gvpending.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                "attachment;filename=OutstandingReport.xls");
            Response.ContentType = "applicatio/excel";
            StringWriter sw1 = new StringWriter(); ;
            HtmlTextWriter htm1 = new HtmlTextWriter(sw1);
            gvpending.RenderControl(htm1);
            Response.Write(sw1.ToString());
            Response.End();
        }

        protected void gvpending_Sorting(object sender, GridViewSortEventArgs e)
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
            DataSet ds = objBs.GetOutstandingAmount("tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName, "tblSales_" + sTableName);
            DataView dvEmp = ds.Tables[0].DefaultView;
            dvEmp.Sort = ViewState["SortExpr"].ToString();
            gvpending.DataSource = dvEmp;
            gvpending.DataBind();
        }

        protected void gvpending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet dsAllOutstanding = new DataSet();
            if (sTableName == "admin")
            {
                lbltotal.Visible = true;
                dsAllOutstanding = objBs.GetAllOutstandingAmount();
                decimal dBillAmt = 0, dPaid = 0, dPending = 0;
                for (int i = 0; i < dsAllOutstanding.Tables[0].Rows.Count; i++)
                {
                    //dBillAmt += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["BillAmount"].ToString());
                    dPaid += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["PaidAmount"].ToString());
                    dPending += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["Balance"].ToString());

                }

                lblBillAmt.InnerText = string.Format("{0:N2}", dBillAmt);
                lblPaid.InnerText = string.Format("{0:N2}", dPaid);
                lblPending.InnerText = string.Format("{0:N2}", dPending);
                DataRow dr = dsAllOutstanding.Tables[0].NewRow();
                dr["CustomerName"] = "";
                dr["BillNo"] = Convert.ToInt32(0);
                dr["BillAmount"] = lblBillAmt.InnerText;
                dr["PaidAmount"] = lblPaid.InnerText;
                dr["Balance"] = lblPending.InnerText;
                dsAllOutstanding.Tables[0].Rows.Add(dr);
                gvpending.PageIndex = e.NewPageIndex;
                gvpending.DataBind();
            }
            else
            {
                dsAllOutstanding = objBs.GetOutstandingAmount("tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName, "tblSales_" + sTableName);

            }
            gvpending.DataSource = dsAllOutstanding;
            
            gvpending.PageIndex = e.NewPageIndex;
            gvpending.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataSet dsAllOutstanding = new DataSet();
            if (sTableName == "admin")
            {
                lbltotal.Visible = true;
                dsAllOutstanding = objBs.GetAllOutstandingAmount();
                if (dsAllOutstanding.Tables[0].Rows.Count > 0)
                {

                    
                    decimal dBillAmt = 0, dPaid = 0, dPending = 0;
                    for (int i = 0; i < dsAllOutstanding.Tables[0].Rows.Count; i++)
                    {
                        //dBillAmt += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["BillAmount"].ToString());
                        dPaid += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["PaidAmount"].ToString());
                        dPending += Convert.ToDecimal(dsAllOutstanding.Tables[0].Rows[i]["Balance"].ToString());

                    }

                    lblBillAmt.InnerText = string.Format("{0:N2}", dBillAmt);
                    lblPaid.InnerText = string.Format("{0:N2}", dPaid);
                    lblPending.InnerText = string.Format("{0:N2}", dPending);
                    DataRow dr = dsAllOutstanding.Tables[0].NewRow();
                    dr["CustomerName"] = "";
                    dr["BillNo"] = Convert.ToInt32(0);
                    dr["BillAmount"] = lblBillAmt.InnerText;
                    dr["PaidAmount"] = lblPaid.InnerText;
                    dr["Balance"] = lblPending.InnerText;
                    dsAllOutstanding.Tables[0].Rows.Add(dr);
                    gvpending.DataSource = dsAllOutstanding;
                    gvpending.DataBind();
                }

            }
            else
            {
                dsAllOutstanding = objBs.GetOutstandingAmount("tblTransReceipt_" + sTableName, "tblReceipt_" + sTableName, "tblSales_" + sTableName);
                if (dsAllOutstanding.Tables[0].Rows.Count > 0)
                {

                    gvpending.DataSource = dsAllOutstanding;
                    gvpending.DataBind();

                }
            }
                
        }

        protected void gvpending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sName = e.Row.Cells[1].Text;
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (sName == "Total")
                    {
                        cell.BackColor = Color.SkyBlue;
                        
                    }
                }
            }
            if (sTableName !="admin")
            {
                gvpending.Columns[6].Visible=false;
            }
        }

        protected void gvpending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (sTableName == "admin")
            {
                if (e.CommandName == "view")
                {
                  DataSet dOutDet = objBs.getAllOutstandingAmountDetails(Convert.ToInt32(e.CommandArgument.ToString()));                                            
                  gvDetails.DataSource = dOutDet;
                  gvDetails.DataBind();
                }
            }
        }
    }
}