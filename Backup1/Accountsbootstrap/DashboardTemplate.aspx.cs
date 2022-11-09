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
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;

namespace Billing.Accountsbootstrap
{
    public partial class DashboardTemplate : System.Web.UI.Page
    {
        AdminDashboard Abj = new AdminDashboard();
        BSClass objBs = new BSClass();
        string sTableName = "";
        string currency = "";
        string ratesetting = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string dt = DateTime.Today.ToString("yyyy-MM-dd");
            sTableName = Request.Cookies["userInfo"]["BranchCode"].ToString();
            currency = Request.Cookies["userInfo"]["Currency"].ToString();
            ratesetting = Request.Cookies["userInfo"]["Ratesetting"].ToString();
            currency = "";



            #region sales Amount

            DataSet dsalesAmt = Abj.SalesAmt(sTableName);
            if (dsalesAmt.Tables[0].Rows[0]["Total"].ToString() != "")
            {
                //lblsales1.Text = "" + currency + " " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");
                lbltotalamountt.Text = "" + currency + " " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");
            }
            else
            {
               // lblsales1.Text = "" + currency + " " + "0";
                lbltotalamountt.Text = "" + currency + " " + "0";
            }

            DataSet dtodaysCash = objBs.Getsalespaymode(sTableName, "1");
            DataSet dtodaysCard = objBs.Getsalespaymode(sTableName,"4,10,17");
            DataSet dtodaysonline = objBs.Getsalespaymode(sTableName, "15");
            DataSet dtodaysnotpaid = objBs.Getsalespaymode(sTableName, "16");
            if (dtodaysCash.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysCash.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysCash.Tables[0].Rows[i]["cash"]);

                    lbltotaltodaycashamnt.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }


            }
            else
            {
                lbltotaltodaycashamnt.Text = "" + currency + " " + "0";
                //lbltotaltodaycardamnt.Text = "" + currency + " " + "0";
            }

            if (dtodaysCard.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysCard.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysCard.Tables[0].Rows[i]["cash"]);


                    lbltotaltodaycardamnt.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }
            }

            else
            {
              //  lbltotaltodaycashamnt.Text = "" + currency + " " + "0";
                lbltotaltodaycardamnt.Text = "" + currency + " " + "0";
            }

            if (dtodaysnotpaid.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysnotpaid.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysnotpaid.Tables[0].Rows[i]["cash"]);


                    lbltotaltodaynotpaidamnt.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }
            }

            else
            {
                //  lbltotaltodaycashamnt.Text = "" + currency + " " + "0";
                lbltotaltodaynotpaidamnt.Text = "" + currency + " " + "0";
            }


            if (dtodaysonline.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysonline.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysonline.Tables[0].Rows[i]["cash"]);


                    lbltotaltodayonlineamnt.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }
            }

            else
            {
                //  lbltotaltodaycashamnt.Text = "" + currency + " " + "0";
                lbltotaltodayonlineamnt.Text = "" + currency + " " + "0";
            }


            DataSet dtotbillcount = Abj.TotalBillToday(sTableName);
            if (dtotbillcount.Tables[0].Rows.Count > 0)
            {
                lbltotalsalescount.Text = dtotbillcount.Tables[0].Rows[0]["Cancel"].ToString();

            }

            //DataSet dorderAmt = Abj.OrderAmt(sTableName);
            //if (dorderAmt.Tables[0].Rows[0]["Total"].ToString() != "")
            //{
            //    lblorder.Text = "" + currency + " " + Convert.ToDecimal(dorderAmt.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");

            //}
            #endregion

            #region Canceled Bills
            DataSet dcancel = Abj.CanceledBill(sTableName);
            if (dcancel.Tables[0].Rows.Count > 0)
            {
                // lblTotalbillcancel.InnerText = dcancel.Tables[0].Rows[0]["Cancel"].ToString();
            }
            DataSet dcancelToday = Abj.CanceledBillToday(sTableName);
            if (dcancelToday.Tables[0].Rows.Count > 0)
            {
                lbltotalcancelscount.Text = dcancelToday.Tables[0].Rows[0]["Cancel"].ToString();
            }
            //By Jothi
            DataSet dcancelTodayamount = Abj.CanceledBillTodayAmount(sTableName);
            if (dcancelTodayamount.Tables[0].Rows.Count > 0)
            {
                lblcancelamount.Text = "" + currency + " " + Convert.ToDecimal(dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"]).ToString("" + ratesetting + "");
                //dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"].ToString();
            }

            #endregion





            //#region Sales
            //DataSet ds_Sales = objBs.Dashboard_SalesAll(dt, "tblSales_" + sTableName);
            //DataSet ds_SalesCount = objBs.Dashboard_SalesCountAll(dt, "tblSales_" + sTableName);
            //if (ds_Sales.Tables[0].Rows.Count > 0)
            //{

                
            //    double amount = 0;
            //    for (int i = 0; i < ds_Sales.Tables[0].Rows.Count; i++)
            //    {
            //        if (ds_Sales.Tables[0].Rows[i]["Sum"].ToString() != "")
            //        {
            //            amount += Convert.ToDouble(ds_Sales.Tables[0].Rows[i]["Sum"].ToString());
            //        }
            //    }

            //    if (amount > 0)
            //    {
            //        if (sTableName == "Admin")
            //        {
            //            lblSales.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");
            //            lblSalesCount.Text += ds_SalesCount.Tables[0].Rows[0]["Count"].ToString();

            //            IDTodaySales.Visible = true;
            //            IDTodaySalesCount.Visible = true;
            //        }

            //        else
            //        {
            //            lblSales.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");
            //            lblSalesCount.Text += ds_SalesCount.Tables[0].Rows[0]["Count"].ToString();

            //            IDTodaySales.Visible = false;
            //            IDTodaySalesCount.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        lblSales.Text = "" + currency + " 0";
            //        lblSalesCount.Text = "0";
            //    }
            //}
            //else
            //{
            //    lblSales.Text = "" + currency + " 0";
            //    lblSalesCount.Text = "0";

            //    if (sTableName == "Admin")
            //    {
            //        IDTodaySales.Visible = true;
            //        IDTodaySalesCount.Visible = true;
            //    }

            //    else
            //    {
            //        IDTodaySales.Visible = false;
            //        IDTodaySalesCount.Visible = true;
            //    }
            //}
            //#endregion

            //#region Customer

            //DataSet ds_Customer = objBs.Dashboard_Customerledgercount(1);
            //DataSet ds_Order = objBs.Dashboard_OrderBalance(dt, "tblOrder_" + sTableName);

            //if (sTableName == "Admin")
            //{
            //    IDOrderBalance.Visible = true;
            //    IDCustomer.Visible = true;

            //    if (ds_Customer.Tables[0].Rows.Count > 0)
            //    {
            //        lblCustomers.Text = (ds_Customer.Tables[0].Rows[0]["Count"].ToString());

            //        for (int i = 0; i < ds_Order.Tables[0].Rows.Count; i++)
            //        {
            //            if (ds_Order.Tables[0].Rows[i]["Sum"].ToString() != "")
            //            {
            //                lblCustomerOrderBalance.Text += (ds_Order.Tables[0].Rows[i]["Sum"].ToString());
            //            }
            //        }


            //    }

            //    else
            //    {
            //        lblCustomers.Text = "0";
            //        lblCustomerOrderBalance.Text = "0.00";
            //    }

            //}

            //else
            //{
            //    IDOrderBalance.Visible = false;
            //    IDCustomer.Visible = true;

            //    if (ds_Customer.Tables[0].Rows.Count > 0)
            //    {
            //        lblCustomers.Text = (ds_Customer.Tables[0].Rows[0]["Count"].ToString());

            //        for (int i = 0; i < ds_Order.Tables[0].Rows.Count; i++)
            //        {
            //            if (ds_Order.Tables[0].Rows[i]["Sum"].ToString() != "")
            //            {
            //                lblCustomerOrderBalance.Text += (ds_Order.Tables[0].Rows[i]["Sum"].ToString());
            //            }
            //        }
            //    }

            //    else
            //    {
            //        lblCustomers.Text = "0";
            //        lblCustomerOrderBalance.Text = "0.00";
            //    }
            //}


            //#endregion

            //#region Expeneses
            //DataSet ds_Expenses = objBs.Dashboard_Expenses(dt, "tblDayBook_" + sTableName);
            //if (ds_Expenses.Tables[0].Rows.Count > 0)
            //{
            //    if (ds_Expenses.Tables[0].Rows[0]["Sum"].ToString() != null)
            //    {
            //        string exp_amt = ds_Expenses.Tables[0].Rows[0]["Sum"].ToString();
            //        if (exp_amt != "")
            //        {
            //            exp_amt = Convert.ToString(Math.Round((Convert.ToDecimal(exp_amt)), 2));
            //            lblExpenses.Text = "" + currency + ". " + Convert.ToDouble(exp_amt).ToString("" + ratesetting + "");
            //        }
            //        else
            //        {
            //            lblExpenses.Text = "" + currency + ". 0";
            //        }
            //    }
            //}
            //else
            //{
            //    lblExpenses.Text = "" + currency + ". 0";
            //}
            //#endregion




            #region Order Amount

            DataSet dsalesAmtOrder = Abj.OrderAmt(sTableName);
            DataSet dsalesBalanceAmtOrder = Abj.OrderBalanceAmt(sTableName);
            if (dsalesAmtOrder.Tables[0].Rows[0]["Total"].ToString() != "")
            {
               // lblsales1.Text = "" + currency + " " + Convert.ToDecimal(dsalesAmtOrder.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");
                lblTotalOrderAmount.Text = "" + currency + " " + Convert.ToDecimal(dsalesAmtOrder.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");



            }
            else
            {
               // lblsales1.Text = "" + currency + " " + "0";
                lblTotalOrderAmount.Text = "" + currency + " " + "0";
            }

            if (dsalesBalanceAmtOrder.Tables[0].Rows[0]["TotalBalance"].ToString() != "")
            {
                lblOrderBalanceAmount.Text = Convert.ToDecimal(dsalesBalanceAmtOrder.Tables[0].Rows[0]["TotalBalance"]).ToString("" + ratesetting + "");
            }

            else
            {
                lblOrderBalanceAmount.Text =  "0";
            }


            DataSet dtodaysCashOrder = objBs.GetallOrderDashBoard(sTableName,"1");
            DataSet dtodaysCardOrder = objBs.GetallOrderDashBoard(sTableName, "4,10,17");
            DataSet dtodaysCnotpaidOrder = objBs.GetallOrderDashBoard(sTableName, "16");

            if (dtodaysCashOrder.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysCashOrder.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysCashOrder.Tables[0].Rows[i]["cash"]);

                    lblTotalOrderCash.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }


            }
            else
            {
                lblTotalOrderCash.Text = "" + currency + " " + "0";
               // lblTotalOrderCard.Text = "" + currency + " " + "0";
            }

            if (dtodaysCardOrder.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysCardOrder.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysCardOrder.Tables[0].Rows[i]["cash"]);


                    lblTotalOrderCard.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }
            }

            else
            {
              //  lblTotalOrderCash.Text = "" + currency + " " + "0";
                lblTotalOrderCard.Text = "" + currency + " " + "0";
            }

            if (dtodaysCnotpaidOrder.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dtodaysCnotpaidOrder.Tables[0].Rows.Count; i++)
                {
                    double amount = Convert.ToDouble(dtodaysCnotpaidOrder.Tables[0].Rows[i]["cash"]);


                    lblTotalOrdernotpaid.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                }
            }

            else
            {
                //  lblTotalOrderCash.Text = "" + currency + " " + "0";
                lblTotalOrdernotpaid.Text = "" + currency + " " + "0";
            }


            // GET SALESGRAPH
            #region Chart 2
            Chart2.Series["Series1"].ChartType = SeriesChartType.Column;
            Chart2.Series["Series1"].IsValueShownAsLabel = true;

            DataSet dsFinalqty = new DataSet();
            dsFinalqty = objBs.getlast7dayssales( sTableName);

            DataTable dt1 = new DataTable();
            DataColumn dc1;

            dc1 = new DataColumn();
            dc1.ColumnName = "bdate";
            dt1.Columns.Add(dc1);
            dc1 = new DataColumn();
            dc1.ColumnName = "sales";
            dt1.Columns.Add(dc1);

            if (dsFinalqty != null)
            {
                if (dsFinalqty.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsFinalqty.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr;
                        dr = dt1.NewRow();

                        if (dsFinalqty.Tables[0].Rows[i]["bdate"].ToString() == dsFinalqty.Tables[0].Rows[i]["bdate"].ToString())
                        {
                            dr["bdate"] = dsFinalqty.Tables[0].Rows[i]["bdate"].ToString();
                        }
                        dr["sales"] = dsFinalqty.Tables[0].Rows[i]["sales"].ToString();
                        dt1.Rows.Add(dr);
                    }
                }

                Chart2.DataSource = dt1;
                Chart2.Series["Series1"].XValueMember = "bdate";
                Chart2.Series["Series1"].YValueMembers = "sales";
                Chart2.DataBind();
            }

            #endregion

            //DataSet dtotbillcountOrder = Abj.TotalOrderBillToday(sTableName);
            //if (dtotbillcountOrder.Tables[0].Rows.Count > 0)
            //{
            //    lblOrderCount.Text = dtotbillcountOrder.Tables[0].Rows[0]["Cancel"].ToString();

            //}

            //DataSet dorderAmtOrder = Abj.OrderAmt(sTableName);
            //if (dorderAmt.Tables[0].Rows[0]["Total"].ToString() != "")
            //{
            //    lblorder.Text = "" + currency + " " + Convert.ToDecimal(dorderAmt.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");

            //}
            #endregion

            #region Order Canceled Bills
            //DataSet dcancelOrder = Abj.CanceledOrderBill(sTableName);
            //if (dcancel.Tables[0].Rows.Count > 0)
            //{
            //    // lblTotalbillcancel.InnerText = dcancel.Tables[0].Rows[0]["Cancel"].ToString();
            //}
            DataSet dcancelTodayOrder = Abj.CanceledOrderBillToday(sTableName);
            if (dcancelTodayOrder.Tables[0].Rows.Count > 0)
            {
                lbTodayOrderCancelledCount.Text = dcancelTodayOrder.Tables[0].Rows[0]["Cancel"].ToString();
            }
            //By Jothi
            DataSet dcancelTodayamountOrder = Abj.CanceledOrderBillTodayAmount(sTableName);
            if (dcancelTodayamountOrder.Tables[0].Rows.Count > 0)
            {
                lblOrderCancelAmount.Text = "" + currency + " " + Convert.ToDecimal(dcancelTodayamountOrder.Tables[0].Rows[0]["Cancelamount"]).ToString("" + ratesetting + "");
                //dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"].ToString();
            }

            #endregion

            #region Order Canceled Bills

            DataSet dsDeliveryOrder = objBs.GetDeliveryordersDetails(sTableName);
            if (dsDeliveryOrder.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsDeliveryOrder.Tables[0].Rows.Count; i++)
                {
                    lblDeliveryDetails.Text += dsDeliveryOrder.Tables[0].Rows[i]["OrderDetails"].ToString() + "<br/>";
                }
            }

            #endregion
        }

        protected void Delivery_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("TodaysDeliveryOrder.aspx");
        }
        protected void Order_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("OrderGrid.aspx");
        }
        protected void Product_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Descriptiongrid.aspx");
        }
        protected void Sales_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CustomerSalesReport.aspx");
        }
        protected void Stock_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("stockgrid.aspx");
        }
        protected void Bill_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("newbutton.aspx");
        }

    }
}