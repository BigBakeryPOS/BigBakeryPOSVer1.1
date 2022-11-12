using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
namespace Billing.Accountsbootstrap
{
    public partial class DashBoard : System.Web.UI.Page
    {

        AdminDashboard Abj = new AdminDashboard();
        BSClass objbs = new BSClass();
        string sTableName = "";
        string sCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Request.Cookies["userInfo"]["UserName"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sTableName = Request.Cookies["userInfo"]["User"].ToString();

            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            if (lblUser.Text.ToLower().Contains("pro") == true)
            {
                admin.Visible = false;
                visible.Visible = false;
                Production.Visible = true;
                #region Kitchen
                DataSet dNoofitems = Abj.TodayItemPurchase();
                if (dNoofitems.Tables[0].Rows.Count > 0)
                {
                    lblNoofItems.Text = dNoofitems.Tables[0].Rows[0]["Today Purchased ingredients"].ToString();
                }

                DataSet dPurVal = Abj.PurchaseValue();
                    if(dPurVal.Tables[0].Rows.Count>0)
                    {
                        lblvalues.Text="Rs  "+  Convert.ToDecimal( dPurVal.Tables[0].Rows[0]["Total"]).ToString("f2");
                    }

                    DataSet dUW = Abj.usedWaste();
                    if (dUW.Tables[0].Rows.Count > 0)
                    {
                    lblused.Text=dUW.Tables[0].Rows[0]["Used"].ToString();
                    lblwaste.Text = dUW.Tables[0].Rows[0]["waste"].ToString();
                    }


                    DataSet dproVal = Abj.ProdStockVlaue();
                    if (dproVal.Tables[0].Rows.Count > 0)
                    {
                        lblStock.Text = "Rs  "+Convert.ToDecimal( dproVal.Tables[0].Rows[0]["Value"]).ToString("f2");
                       
                    }
                    DataSet dmsg = objbs.ViewMessege(Convert.ToInt32(lblUserID.Text));
                    string Messege = "";
                    if (dmsg.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dmsg.Tables[0].Rows.Count; i++)
                        {
                            Messege += dmsg.Tables[0].Rows[i]["Messege"].ToString() + "-";
                        }

                        lblpromsg.Text = "From  -" + dmsg.Tables[0].Rows[0]["from"].ToString() + " " + Messege;
                    }
                #endregion
                //container.Visible = false;
            }
            else if (sTableName == "admin")
            {
                adminsalesAmount.Visible = true;
                storesalesAmt.Visible = false;
                adminorderAmt.Visible = true;
                storeorderAmt.Visible = false;
                storevalue.Visible = false;
                adminvalue.Visible = true;
                storecancel.Visible = false;
                admincancel.Visible = true;
                storecust.Visible = false;
                admincust.Visible = true;
                storedelivery.Visible = false;
                admindelivery.Visible = true;
                int userid = 0;
                if (ddlBranch.SelectedValue.ToLower() == "co1")
                {
                    userid = 5;
                }
                else if (ddlBranch.SelectedValue.ToLower() == "co2")
                {
                    userid = 6;
                }
                else if (ddlBranch.SelectedValue.ToLower() == "co3")
                {
                    userid = 7;
                }
                else if (ddlBranch.SelectedValue.ToLower() == "co4")
                {
                    userid = 11;

                }
                else if (ddlBranch.SelectedValue.ToLower() == "co5")
                {
                    userid = 14;
                }

                Production.Visible = false;
                DataSet dmsg = objbs.ViewMessege(userid);
                string Messege = "";
                if (dmsg.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dmsg.Tables[0].Rows.Count; i++)
                    {
                        Messege += dmsg.Tables[0].Rows[i]["Messege"].ToString() + "-";
                    }

                    lblmessege.Text = "From  -" + dmsg.Tables[0].Rows[0]["from"].ToString() + " " + Messege;
                }
                if (lblUser.Text.ToLower().Contains("pro") == false)
                {
                    //    #region Customers Count

                    DataSet dCustCount = Abj.totalCustomers(ddlBranch.SelectedValue, userid);
                    if (dCustCount.Tables[0].Rows.Count > 0)
                    {
                        lblCustCount.Text = dCustCount.Tables[0].Rows[0]["Customers"].ToString();
                    }

                    DataSet dtodayCustCount = Abj.TodaysCustomers(ddlBranch.SelectedValue);
                    if (dtodayCustCount.Tables[0].Rows.Count > 0)
                    {
                        lbltodayCust.Text = dtodayCustCount.Tables[0].Rows[0]["Customers"].ToString();
                    }
                    //    #endregion
                    //    #region Sales Count
                    //    DataSet dSale = Abj.TotalsalesCount(sTableName);
                    //    if (dSale.Tables[0].Rows.Count > 0)
                    //    {
                    //        lbllTotalSales.InnerText = dSale.Tables[0].Rows[0]["TotalBills"].ToString();
                    //    }
                    DataSet dSaleToday = Abj.TodaysalesCount(ddlBranch.SelectedValue);
                    if (dSaleToday.Tables[0].Rows.Count > 0)
                    {
                        lblsalescount.Text = dSaleToday.Tables[0].Rows[0]["TotalBills"].ToString();
                    }
                    //    #endregion

                    #region cake Order
                    DataSet dTotalcake = Abj.TotalCakeOrders(ddlBranch.SelectedValue);
                    if (dTotalcake.Tables[0].Rows.Count > 0)
                    {
                        lbltotalcake.Text = dTotalcake.Tables[0].Rows[0]["TotalCakeOrders"].ToString();
                    }
                    DataSet dTodaycake = Abj.TodayCakeOrders(ddlBranch.SelectedValue);
                    if (dTodaycake.Tables[0].Rows.Count > 0)
                    {
                        lblordersToday.Text = dTodaycake.Tables[0].Rows[0]["TotalCakeOrders"].ToString();
                        lblOrdercount.Text = dTodaycake.Tables[0].Rows[0]["TotalCakeOrders"].ToString();
                    }
                    #endregion

                    //    #region stockvalue
                    DataSet dStock = Abj.StockValue(userid, ddlBranch.SelectedValue);
                    if (dStock.Tables[0].Rows[0]["total"].ToString() != "")
                    {
                        lblStockValue.Text = "Rs " + Convert.ToDecimal(dStock.Tables[0].Rows[0]["total"].ToString()).ToString("f2");
                    }

                    DataSet dStockwaste = Abj.StockwateValue(userid, ddlBranch.SelectedValue);
                    if (dStockwaste.Tables[0].Rows[0]["total"].ToString() != "")
                    {
                        lblRet.Text = "Rs " + Convert.ToDecimal(dStockwaste.Tables[0].Rows[0]["Total"].ToString()).ToString("f2");
                    }


                    #region Canceled Bills
                    DataSet dcancel = Abj.CanceledBill(ddlBranch.SelectedValue);
                    if (dcancel.Tables[0].Rows.Count > 0)
                    {
                        // lblTotalbillcancel.InnerText = dcancel.Tables[0].Rows[0]["Cancel"].ToString();
                    }
                    DataSet dcancelToday = Abj.CanceledBillToday(ddlBranch.SelectedValue);
                    if (dcancelToday.Tables[0].Rows.Count > 0)
                    {
                        lblTodaybillcancel.Text = dcancelToday.Tables[0].Rows[0]["Cancel"].ToString();
                    }
                    #endregion

                    #region Canceled orders
                    DataSet dcancelorders = Abj.CanceledOrder(ddlBranch.SelectedValue);
                    if (dcancelorders.Tables[0].Rows.Count > 0)
                    {
                        // lblOrdercancel.InnerText = dcancelorders.Tables[0].Rows[0]["OrderCancel"].ToString();
                    }
                    DataSet dcancelTodayOrders = Abj.CanceledOrderToday(ddlBranch.SelectedValue);
                    if (dcancelTodayOrders.Tables[0].Rows.Count > 0)
                    {
                        lblOrdercancelToday.Text = dcancelTodayOrders.Tables[0].Rows[0]["OrderCancel"].ToString();
                    }
                    #endregion


                    #region sales Amount

                    DataSet dsalesAmt = Abj.SalesAmt(ddlBranch.SelectedValue);
                    if (dsalesAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        lblsales.Text = "Rs " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString("f2");
                    }

                    DataSet dorderAmt = Abj.OrderAmt(ddlBranch.SelectedValue);
                    if (dorderAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        lblorder.Text = "Rs " + Convert.ToDecimal(dorderAmt.Tables[0].Rows[0]["Total"]).ToString("f2");

                    }

                    DataSet dsaleAmtGrid = Abj.Adminsalesgrid();
                    gvsalesAmt.DataSource = dsaleAmtGrid.Tables[0];
                    gvsalesAmt.DataBind();

                   


                    DataSet dbillcount = Abj.AdminBillCountgrid();
                    gvbillCount.DataSource = dbillcount.Tables[0];
                    gvbillCount.DataBind();


                    DataSet dstockvalue = Abj.Adminstockvaluetgrid();
                    gvstock.DataSource = dstockvalue.Tables[0];
                    gvstock.DataBind();


                    DataSet dcancelgrid = Abj.Adminscancelgrid();
                    gvcancel.DataSource = dcancelgrid.Tables[0];
                    gvcancel.DataBind();


                    DataSet dAdmincustcount = Abj.AdminCustcount();
                    gvcustcunt.DataSource = dAdmincustcount.Tables[0];
                    gvcustcunt.DataBind();

                    DataSet dadmindelivery = Abj.AdminDelivery();
                    gvcakesorders.DataSource = dadmindelivery.Tables[0];
                    gvcakesorders.DataBind();

                    #endregion
                }


                #region Notification
                if (ddlBranch.SelectedValue.ToLower() == "co1")
                {
                    sCode = "KK";
                }
                else if (ddlBranch.SelectedValue.ToLower() == "co2")
                {
                    sCode = "BY";
                }
                else if (ddlBranch.SelectedValue.ToLower() == "co3")
                {
                    sCode ="BB";
                }
                else if (ddlBranch.SelectedValue.ToLower() == "co4")
                {
                    sCode = "NP";

                }
                else if (ddlBranch.SelectedValue.ToLower() == "co5")
                {
                    sCode = "NE";
                }
                DataSet ds = Abj.GoodTransferStatus(sCode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int dc = Convert.ToInt32(ds.Tables[0].Rows[0]["DC_NO"].ToString());
                    DataSet dcn = Abj.CountGoodsSent(ddlBranch.SelectedValue, dc);
                    Labelmsg.Text = dcn.Tables[0].Rows[0]["items"].ToString() + " Items Sent to you Please Receive it  ";
                }
                #endregion


            }
            else
            {
                admin.Visible = false;
                Production.Visible = false;
                DataSet dmsg = objbs.ViewMessege(Convert.ToInt32(lblUserID.Text));
                string Messege = "";
                if (dmsg.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dmsg.Tables[0].Rows.Count; i++)
                    {
                        Messege += dmsg.Tables[0].Rows[i]["Messege"].ToString() + "-";
                    }

                    lblmessege.Text = "From  -" + dmsg.Tables[0].Rows[0]["from"].ToString() + " " + Messege;
                }
                if (lblUser.Text.ToLower().Contains("pro") == false)
                {
                    //    #region Customers Count

                    DataSet dCustCount = Abj.totalCustomers(sTableName, Convert.ToInt32(lblUserID.Text));
                    if (dCustCount.Tables[0].Rows.Count > 0)
                    {
                        lblCustCount.Text = dCustCount.Tables[0].Rows[0]["Customers"].ToString();
                    }

                    DataSet dtodayCustCount = Abj.TodaysCustomers(sTableName);
                    if (dtodayCustCount.Tables[0].Rows.Count > 0)
                    {
                        lbltodayCust.Text = dtodayCustCount.Tables[0].Rows[0]["Customers"].ToString();
                    }
                    //    #endregion
                    //    #region Sales Count
                    //    DataSet dSale = Abj.TotalsalesCount(sTableName);
                    //    if (dSale.Tables[0].Rows.Count > 0)
                    //    {
                    //        lbllTotalSales.InnerText = dSale.Tables[0].Rows[0]["TotalBills"].ToString();
                    //    }
                    DataSet dSaleToday = Abj.TodaysalesCount(sTableName);
                    if (dSaleToday.Tables[0].Rows.Count > 0)
                    {
                        lblsalescount.Text = dSaleToday.Tables[0].Rows[0]["TotalBills"].ToString();
                    }
                    //    #endregion

                    #region cake Order
                    DataSet dTotalcake = Abj.TotalCakeOrders(sTableName);
                    if (dTotalcake.Tables[0].Rows.Count > 0)
                    {
                        lbltotalcake.Text = dTotalcake.Tables[0].Rows[0]["TotalCakeOrders"].ToString();
                    }
                    DataSet dTodaycake = Abj.TodayCakeOrders(sTableName);
                    if (dTodaycake.Tables[0].Rows.Count > 0)
                    {
                        lblordersToday.Text = dTodaycake.Tables[0].Rows[0]["TotalCakeOrders"].ToString();
                        lblOrdercount.Text = dTodaycake.Tables[0].Rows[0]["TotalCakeOrders"].ToString();
                    }
                    #endregion

                    //    #region stockvalue
                    DataSet dStock = Abj.StockValue(Convert.ToInt32(lblUserID.Text), sTableName);
                    if (dStock.Tables[0].Rows[0]["total"].ToString() != "")
                    {
                        lblStockValue.Text = "Rs " + Convert.ToDecimal(dStock.Tables[0].Rows[0]["total"].ToString()).ToString("f2");
                    }

                    DataSet dStockwaste = Abj.StockwateValue(Convert.ToInt32(lblUserID.Text), sTableName);
                    if (dStockwaste.Tables[0].Rows[0]["total"].ToString() != "")
                    {
                        lblRet.Text = "Rs " + Convert.ToDecimal(dStockwaste.Tables[0].Rows[0]["Total"].ToString()).ToString("f2");
                    }


                    #region Canceled Bills
                    DataSet dcancel = Abj.CanceledBill(sTableName);
                    if (dcancel.Tables[0].Rows.Count > 0)
                    {
                        // lblTotalbillcancel.InnerText = dcancel.Tables[0].Rows[0]["Cancel"].ToString();
                    }
                    DataSet dcancelToday = Abj.CanceledBillToday(sTableName);
                    if (dcancelToday.Tables[0].Rows.Count > 0)
                    {
                        lblTodaybillcancel.Text = dcancelToday.Tables[0].Rows[0]["Cancel"].ToString();
                    }
                    #endregion

                    #region Canceled orders
                    DataSet dcancelorders = Abj.CanceledOrder(sTableName);
                    if (dcancelorders.Tables[0].Rows.Count > 0)
                    {
                        // lblOrdercancel.InnerText = dcancelorders.Tables[0].Rows[0]["OrderCancel"].ToString();
                    }
                    DataSet dcancelTodayOrders = Abj.CanceledOrderToday(sTableName);
                    if (dcancelTodayOrders.Tables[0].Rows.Count > 0)
                    {
                        lblOrdercancelToday.Text = dcancelTodayOrders.Tables[0].Rows[0]["OrderCancel"].ToString();
                    }
                    #endregion


                    #region sales Amount

                    DataSet dsalesAmt = Abj.SalesAmt(sTableName);
                    if (dsalesAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        lblsales.Text = "Rs " + Convert.ToDecimal(dsalesAmt.Tables[0].Rows[0]["Total"]).ToString("f2");
                    }

                    DataSet dorderAmt = Abj.OrderAmt(sTableName);
                    if (dorderAmt.Tables[0].Rows[0]["Total"].ToString() != "")
                    {
                        lblorder.Text = "Rs " + Convert.ToDecimal(dorderAmt.Tables[0].Rows[0]["Total"]).ToString("f2");

                    }
                    #endregion
                }


                #region Notification

                //DataSet ds = Abj.GoodTransferStatus(sCode);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    int dc = Convert.ToInt32(ds.Tables[0].Rows[0]["DC_NO"].ToString());
                //    DataSet dcn = Abj.CountGoodsSent(sTableName, dc);
                //    Labelmsg.Text = dcn.Tables[0].Rows[0]["items"].ToString() + " Items Sent to you Please Receive it  ";
                //}
                #endregion


            }
        }
    }
}