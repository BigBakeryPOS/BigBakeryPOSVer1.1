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


namespace Billing.Accountsbootstrap
{

    public partial class HomePage : System.Web.UI.Page
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

            #region Sales
            DataSet ds_Sales = objBs.Dashboard_SalesAll(dt, "tblSales_" + sTableName);
            DataSet ds_SalesCount = objBs.Dashboard_SalesCountAll(dt, "tblSales_" + sTableName);
            if (ds_Sales.Tables[0].Rows.Count > 0)
            {

                if (sTableName == "Admin")
                {
                    IDTodaySales.Visible = true;
                    IDTodaySalesCount.Visible = true;
                }

                else
                {
                    IDTodaySales.Visible = false;
                    IDTodaySalesCount.Visible = true;
                }

                double amount = 0;
                for (int i = 0; i < ds_Sales.Tables[0].Rows.Count; i++)
                {
                    if (ds_Sales.Tables[0].Rows[i]["Sum"].ToString() != "")
                    {
                        amount += Convert.ToDouble(ds_Sales.Tables[0].Rows[i]["Sum"].ToString());
                    }
                }

                if (amount > 0)
                {
                    if (sTableName == "Admin")
                    {
                        lblSales.Text = ""+currency+" " + amount.ToString(""+ratesetting+"");
                        lblSalesCount.Text += ds_SalesCount.Tables[0].Rows[0]["Count"].ToString();

                        IDTodaySales.Visible = true;
                        IDTodaySalesCount.Visible = true;
                    }

                    else
                    {
                        lblSales.Text = "" + currency + " " + amount.ToString(""+ratesetting+"");
                        lblSalesCount.Text += ds_SalesCount.Tables[0].Rows[0]["Count"].ToString();

                        IDTodaySales.Visible = false;
                        IDTodaySalesCount.Visible = true;
                    }
                }
                else
                {
                    lblSales.Text = "" + currency + " 0";
                    lblSalesCount.Text = "0";
                }
            }
            else
            {
                lblSales.Text = ""+currency+" 0";
                lblSalesCount.Text = "0";

                if (sTableName == "Admin")
                {
                    IDTodaySales.Visible = true;
                    IDTodaySalesCount.Visible = true;
                }

                else
                {
                    IDTodaySales.Visible = false;
                    IDTodaySalesCount.Visible = true;
                }
            }
            #endregion

            #region Customer

            DataSet ds_Customer = objBs.Dashboard_Customerledgercount(1);
            DataSet ds_Order = objBs.Dashboard_OrderBalance(dt, "tblOrder_" + sTableName);

            if (sTableName == "Admin")
            {
                IDOrderBalance.Visible = true;
                IDCustomer.Visible = true;

                if (ds_Customer.Tables[0].Rows.Count > 0)
                {
                    lblCustomers.Text = (ds_Customer.Tables[0].Rows[0]["Count"].ToString());

                    for (int i = 0; i < ds_Order.Tables[0].Rows.Count; i++)
                    {
                        if (ds_Order.Tables[0].Rows[i]["Sum"].ToString() != "")
                        {
                            lblCustomerOrderBalance.Text += (ds_Order.Tables[0].Rows[i]["Sum"].ToString());
                        }
                    }


                }

                else
                {
                    lblCustomers.Text = "0";
                    lblCustomerOrderBalance.Text = "0.00";
                }

            }

            else
            {
                IDOrderBalance.Visible = false;
                IDCustomer.Visible = true;

                if (ds_Customer.Tables[0].Rows.Count > 0)
                {
                    lblCustomers.Text = (ds_Customer.Tables[0].Rows[0]["Count"].ToString());

                    for (int i = 0; i < ds_Order.Tables[0].Rows.Count; i++)
                    {
                        if (ds_Order.Tables[0].Rows[i]["Sum"].ToString() != "")
                        {
                            lblCustomerOrderBalance.Text += (ds_Order.Tables[0].Rows[i]["Sum"].ToString());
                        }
                    }
                }

                else
                {
                    lblCustomers.Text = "0";
                    lblCustomerOrderBalance.Text = "0.00";
                }
            }


            #endregion

            #region Expeneses
            DataSet ds_Expenses = objBs.Dashboard_Expenses(dt, "tblDayBook_" + sTableName);
            if (ds_Expenses.Tables[0].Rows.Count > 0)
            {
                if (ds_Expenses.Tables[0].Rows[0]["Sum"].ToString() != null)
                {
                    string exp_amt = ds_Expenses.Tables[0].Rows[0]["Sum"].ToString();
                    if (exp_amt != "")
                    {
                        exp_amt = Convert.ToString(Math.Round((Convert.ToDecimal(exp_amt)), 2));
                        lblExpenses.Text = ""+currency+". " + Convert.ToDouble(exp_amt).ToString(""+ratesetting+"");
                    }
                    else
                    {
                        lblExpenses.Text = ""+currency+". 0";
                    }
                }
            }
            else
            {
                lblExpenses.Text = ""+currency+". 0";
            }
            #endregion


            #region sales Amount

            DataSet dsalesAmt = Abj.SalesAmt(sTableName);
            if (dsalesAmt.Tables[0].Rows[0]["Total"].ToString() != "")
            {
                lblsales1.Text = ""+currency+" " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString(""+ratesetting+"");
                lbltotalamountt.Text = ""+currency+" " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString(""+ratesetting+"");
            }
            else
            {
                lblsales1.Text = ""+currency+" " + "0";
                lbltotalamountt.Text = ""+currency+" " + "0";
            }
           
                DataSet dtodaysCash = objBs.GetCashDashBoard(sTableName);
                DataSet dtodaysCard = objBs.GetCardDashBoard(sTableName);
                if (dtodaysCash.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtodaysCash.Tables[0].Rows.Count; i++)
                    {
                        double amount = Convert.ToDouble(dtodaysCash.Tables[0].Rows[i]["cash"]);

                        lbltotaltodaycashamnt.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                    }


                }

                if (dtodaysCard.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtodaysCard.Tables[0].Rows.Count; i++)
                    {
                        double amount = Convert.ToDouble(dtodaysCard.Tables[0].Rows[i]["card"]);


                        lbltotaltodaycardamnt.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                    }
                }

                else
                {
                    lbltotaltodaycashamnt.Text = "" + currency + " " + "0";
                    lbltotaltodaycardamnt.Text = "" + currency + " " + "0";
                }


                DataSet dtotbillcount = Abj.TotalBillToday(sTableName);
                if (dtotbillcount.Tables[0].Rows.Count > 0)
                {
                    lbltotalsalescount.Text = dtotbillcount.Tables[0].Rows[0]["Cancel"].ToString();

                }

                DataSet dorderAmt = Abj.OrderAmt(sTableName);
                if (dorderAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                {
                    lblorder.Text = "" + currency + " " + Convert.ToDecimal(dorderAmt.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");

                }
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
                    LlblTodaybillcancel.Text = dcancelToday.Tables[0].Rows[0]["Cancel"].ToString();
                }
                //By Jothi
                DataSet dcancelTodayamount = Abj.CanceledBillTodayAmount(sTableName);
                if (dcancelTodayamount.Tables[0].Rows.Count > 0)
                {
                    lblcancelamount.Text = "" + currency + " " + Convert.ToDecimal(dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"]).ToString("" + ratesetting + "");
                    //dcancelTodayamount.Tables[0].Rows[0]["Cancelamount"].ToString();
                }

                #endregion

                #region Order Amount

                DataSet dsalesAmtOrder = Abj.OrderAmt(sTableName);
                DataSet dsalesBalanceAmtOrder = Abj.OrderBalanceAmt(sTableName);
                if (dsalesAmtOrder.Tables[0].Rows[0]["Total"].ToString() != "")
                {
                    lblsales1.Text = "" + currency + " " + Convert.ToDecimal(dsalesAmtOrder.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");
                    lblTotalOrderAmount.Text = "" + currency + " " + Convert.ToDecimal(dsalesAmtOrder.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");



                }
                else
                {
                    lblsales1.Text = "" + currency + " " + "0";
                    lblTotalOrderAmount.Text = "" + currency + " " + "0";
                }

                if (dsalesBalanceAmtOrder.Tables[0].Rows[0]["TotalBalance"].ToString() != "")
                {
                    lblOrderBalanceAmount.Text = "" + currency + " " + Convert.ToDecimal(dsalesBalanceAmtOrder.Tables[0].Rows[0]["TotalBalance"]).ToString("" + ratesetting + "");
                }

                else
                {
                    lblOrderBalanceAmount.Text = "" + currency + " " + "0";
                }


                DataSet dtodaysCashOrder = objBs.GetOrderCashDashBoard(sTableName);
                DataSet dtodaysCardOrder = objBs.GetOrderCardDashBoard(sTableName);

                if (dtodaysCashOrder.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtodaysCashOrder.Tables[0].Rows.Count; i++)
                    {
                        double amount = Convert.ToDouble(dtodaysCashOrder.Tables[0].Rows[i]["cash"]);

                        lblTotalOrderCash.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                    }


                }

                if (dtodaysCardOrder.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dtodaysCardOrder.Tables[0].Rows.Count; i++)
                    {
                        double amount = Convert.ToDouble(dtodaysCardOrder.Tables[0].Rows[i]["card"]);


                        lblTotalOrderCard.Text = "" + currency + " " + amount.ToString("" + ratesetting + "");

                    }
                }

                else
                {
                    lblTotalOrderCash.Text = "" + currency + " " + "0";
                    lblTotalOrderCard.Text = "" + currency + " " + "0";
                }


                DataSet dtotbillcountOrder = Abj.TotalOrderBillToday(sTableName);
                if (dtotbillcountOrder.Tables[0].Rows.Count > 0)
                {
                    lblOrderCount.Text = dtotbillcountOrder.Tables[0].Rows[0]["Cancel"].ToString();

                }

                DataSet dorderAmtOrder = Abj.OrderAmt(sTableName);
                if (dorderAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                {
                    lblorder.Text = "" + currency + " " + Convert.ToDecimal(dorderAmt.Tables[0].Rows[0]["Total"]).ToString("" + ratesetting + "");

                }
                #endregion

                #region Order Canceled Bills
                DataSet dcancelOrder = Abj.CanceledOrderBill(sTableName);
                if (dcancel.Tables[0].Rows.Count > 0)
                {
                    // lblTotalbillcancel.InnerText = dcancel.Tables[0].Rows[0]["Cancel"].ToString();
                }
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