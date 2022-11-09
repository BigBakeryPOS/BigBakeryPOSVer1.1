using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
namespace Billing.Accountsbootstrap
{
    public partial class CustomerBillReport : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        string sTableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            if (!IsPostBack)
            {
                if (sTableName == "admin")
                {
                    DataSet dCustBill = objBs.AdminCustomerBillReport();
                    decimal dBillAmt = 0, dPaid = 0, dBalance = 0;
                    for (int i = 0; i < dCustBill.Tables[0].Rows.Count; i++)
                    {
                        dBillAmt += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["BillAmount"].ToString());
                        dPaid += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["PaidAmount"].ToString());
                        dBalance += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["Balance"].ToString());
                    }

                    DataRow dr = dCustBill.Tables[0].NewRow();
                    dr["CustomerName"] = "Total Paid Amount";

                    dr["BillAmount"] = dBillAmt;
                    dr["PaidAmount"] = dPaid;
                    dr["Balance"] = dBalance;
                    dCustBill.Tables[0].Rows.Add(dr);
                    gvsales.DataSource = dCustBill;
                    gvsales.DataBind();

                }
                else
                {
                    txtfrmdate.Enabled = false;
                    txttodate.Enabled = false;
                    DataSet dCustBill = objBs.CustomerBillReport(sTableName);
                    gvsales.DataSource = dCustBill;
                    gvsales.DataBind();
                }

            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (sTableName == "admin")
            {
                if (ddBranch.SelectedValue == "1")
                {
                    DataSet dCustBill = objBs.getbranch1BillReportsearch(txtfrmdate.Text, txttodate.Text);
                    decimal dBillAmt = 0, dPaid = 0, dBalance = 0;
                    for (int i = 0; i < dCustBill.Tables[0].Rows.Count; i++)
                    {
                        dBillAmt += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["BillAmount"].ToString());
                        dPaid += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["PaidAmount"].ToString());
                        dBalance += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["Balance"].ToString());
                    }

                    DataRow dr = dCustBill.Tables[0].NewRow();
                    dr["CustomerName"] = "Total Paid Amount";

                    dr["BillAmount"] = dBillAmt;
                    dr["PaidAmount"] = dPaid;
                    dr["Balance"] = dBalance;
                    dCustBill.Tables[0].Rows.Add(dr);
                    gvsales.DataSource = dCustBill;
                    gvsales.DataBind();
                }
                if (ddBranch.SelectedValue == "2")
                {
                    DataSet dCustBill = objBs.getbranch2BillReportsearch(txtfrmdate.Text, txttodate.Text);
                    decimal dBillAmt = 0, dPaid = 0, dBalance = 0;
                    for (int i = 0; i < dCustBill.Tables[0].Rows.Count; i++)
                    {
                        dBillAmt += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["BillAmount"].ToString());
                        dPaid += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["PaidAmount"].ToString());
                        dBalance += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["Balance"].ToString());
                    }

                    DataRow dr = dCustBill.Tables[0].NewRow();
                    dr["CustomerName"] = "Total Paid Amount";

                    dr["BillAmount"] = dBillAmt;
                    dr["PaidAmount"] = dPaid;
                    dr["Balance"] = dBalance;
                    dCustBill.Tables[0].Rows.Add(dr);
                    gvsales.DataSource = dCustBill;
                    gvsales.DataBind();
                }
                if (ddBranch.SelectedValue == "3")
                {
                    DataSet dCustBill = objBs.getbranch3BillReportsearch(txtfrmdate.Text, txttodate.Text);
                    decimal dBillAmt = 0, dPaid = 0, dBalance = 0;
                    for (int i = 0; i < dCustBill.Tables[0].Rows.Count; i++)
                    {
                        dBillAmt += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["BillAmount"].ToString());
                        dPaid += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["PaidAmount"].ToString());
                        dBalance += Convert.ToDecimal(dCustBill.Tables[0].Rows[i]["Balance"].ToString());
                    }

                    DataRow dr = dCustBill.Tables[0].NewRow();
                    dr["CustomerName"] = "Total Paid Amount";

                    dr["BillAmount"] = dBillAmt;
                    dr["PaidAmount"] = dPaid;
                    dr["Balance"] = dBalance;
                    dCustBill.Tables[0].Rows.Add(dr);
                    gvsales.DataSource = dCustBill;
                    gvsales.DataBind();
                }
            }
            else
            {
                DataSet dCustBill = objBs.CustomerBillReportSearch(sTableName, txtfrmdate.Text, txttodate.Text);
                gvsales.DataSource = dCustBill;
                gvsales.DataBind();
            }
        }

        protected void gvsales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sName = e.Row.Cells[1].Text;
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (sName == "Total Paid Amount")
                    {
                        cell.BackColor = Color.SkyBlue;
                    }
                }
            }
        }

        protected void gvsales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                DataSet dSplit = objBs.getcustPendingDet(Convert.ToInt16(e.CommandArgument.ToString()));
                gvSplitUp.DataSource = dSplit;
                gvSplitUp.DataBind();
            }
                      
                    
                  
                           
                                              
                    
               
            }
        }
    }
