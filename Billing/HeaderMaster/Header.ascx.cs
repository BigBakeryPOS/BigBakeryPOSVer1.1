using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessLayer;
using DataLayer;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.ComponentModel;
using System.Globalization;




namespace Billing.HeaderMaster
{
    public partial class Header : System.Web.UI.UserControl
    {
        string sTableName = "";
        string branchtype = "";
        string IsmasterLock = "Y";
        protected void Page_Load(object sender, EventArgs e)
        {
            sTableName = Request.Cookies["userInfo"]["User"].ToString();
            BSClass objbs = new BSClass();
            string sMode = "";
            string branchtype = "";
            string logintypeid = "";
            string sCode = ""; string Empid = "";
            string sUserChk = Request.Cookies["userInfo"]["IsSuperAdmin"].ToString();
            if (Request.Cookies["userInfo"]["Mode"].ToString() != null)
                sMode = Request.Cookies["userInfo"]["Mode"].ToString();
            lblUser.Text = Request.Cookies["userInfo"]["Biller"].ToString();
            lblUserID.Text = Request.Cookies["userInfo"]["UserID"].ToString();
            sCode = Request.Cookies["userInfo"]["BranchCode"].ToString();
            Empid = Request.Cookies["userInfo"]["Empid"].ToString();
            lblstore.Text = Request.Cookies["userInfo"]["Store"].ToString();
            logintypeid = Request.Cookies["userInfo"]["LoginTypeId"].ToString();
            IsmasterLock = Request.Cookies["userInfo"]["ismasterlock"].ToString();

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


            if (sUserChk != "1")
            {
                branchtype = Request.Cookies["userInfo"]["Branchtype"].ToString();

                if (branchtype == "O")
                {
                    Label2.Text = "Branch :";
                }
                else if (branchtype == "F")
                {
                    Label2.Text = "Franchise :";
                }
                else if (branchtype == "P")
                {
                    Label2.Text = "Production :";
                }
                else
                {
                    Label2.Text = "Franchise :";
                }
            }
            else
            {
                Label2.Text = "Admin :";
            }


            if (sUserChk == "1")
            {
                LiveDashBoard.Visible = true;
                AddUsers.Visible = true;
                // Synchronization.Visible = false;
                dayclose.Visible = false;
                Mbranch.Visible = true;
                //  msg.Visible = false;
            }
            else if (sUserChk == "2")
            {
                //  Synchronization.Visible = false;
                dayclose.Visible = false;
                //  msg.Visible = false;
            }
            else
            {
                // Synchronization.Visible = true;

                //  msg.Visible = true;

                #region
                //string Productioncode = string.Empty;
                //DataSet dss = objbs.checkrequestallowornot(sCode);
                //if (dss.Tables[0].Rows.Count > 0)
                //{
                //    //ScriptManager.RegisterStartupScript(this.GetType(), "alert", "ShowPopup_card();", true);
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup_card();", true);
                //    Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Make Sure Your branch is allow to Receive Stock Or Not.Please Contact Administrator.Thank You!!!');", true);
                //    return;
                //}
                #endregion

                //DataSet ds = objbs.GetDCNONew(sCode, Productioncode);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    string mergetext = string.Empty;
                //    string lblmsg ="Request On Transit : Req.No-Dc.No-Dc.Date ->";
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        string dcno = " " + ds.Tables[0].Rows[i]["RequestNO"].ToString() + "--" +ds.Tables[0].Rows[i]["dc_no"].ToString() + "--" + Convert.ToDateTime(ds.Tables[0].Rows[i]["dc_date"]).ToString("dd/MM/yyyy hh:mm tt");
                //        mergetext += dcno + " ,";

                //    }
                //    mergetext = mergetext.TrimEnd(',');

                //    lblmsgtext.Text =lblmsg + mergetext;
                //}
                //else
                //{
                //    lblmsgtext.Text = "No Request Transit Found!!!.";
                //}

            }

            if (sUserChk != "1")
            {
                #region Check Internet Connection // Id =1

                if (objbs.getsettingid("1"))
                {
                    if (objbs.IsConnectedToInternet())
                    {

                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }
                }


                if (objbs.getsettingid("3"))
                {
                    if (objbs.IsConnectedToInternet())
                    {


                        string msg = "";
                        string head = "";
                        string Productioncode = "";
                        DataSet dss = objbs.checkrequestallowornot(sCode);
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            Productioncode = dss.Tables[0].Rows[0]["Productioncode"].ToString();
                        }
                        else
                        {

                        }


                        DataSet ds = objbs.GetDCNONew(sCode, Productioncode);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            head = "Stock on Transit From Production:";
                            msg = head;
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                string dc_NO = ds.Tables[0].Rows[i]["DC_NO"].ToString();
                                string date = Convert.ToDateTime(ds.Tables[0].Rows[i]["dc_date"]).ToString("dd/MM/yyyy");
                                msg += "<tr><td> DC .No :" + dc_NO + ", DC Date:" + date + "." + "</br> </td></td>";
                            }
                            string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Information", "<script>showpop6('" + msg + "','" + head + "')</script>", false);
                        }
                        else
                        {

                        }

                        DateTime sDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DataSet dinters = objbs.getrequestbranchfromanotherbranch(sCode, sDate);
                        if (dinters.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Inter Branch Stock Request:";
                            // msg = head;
                            for (int i = 0; i < dinters.Tables[0].Rows.Count; i++)
                            {

                                string from_NO = dinters.Tables[0].Rows[i]["FromBranchCode"].ToString();
                                string dc_NO = dinters.Tables[0].Rows[i]["RequestNO"].ToString();
                                string date = Convert.ToDateTime(dinters.Tables[0].Rows[i]["RequestDate"]).ToString("dd/MM/yyyy");
                                msg1 += "<tr><td>From Branch :" + from_NO + "</br> Req.No :" + dc_NO + "</br> Req.Date:" + date + ".<br/>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Info", "<script>showpop6('" + msg1 + "','" + head1 + "')</script>", false);
                        }


                        DataSet dsreceived = objbs.GetinterDCNONew(sCode);
                        if (dsreceived.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Stock Transit From Inter Branch:";
                            // msg = head;
                            for (int i = 0; i < dsreceived.Tables[0].Rows.Count; i++)
                            {

                                string from_NO = dsreceived.Tables[0].Rows[i]["tobranchcode"].ToString();
                                string dc_NO = dsreceived.Tables[0].Rows[i]["DC_NO"].ToString();
                                //string dc_NO = dsreceived.Tables[0].Rows[i]["DC_NO"].ToString();
                                string date = Convert.ToDateTime(dsreceived.Tables[0].Rows[i]["dc_date"]).ToString("dd/MM/yyyy");
                                msg1 += "<tr><td>To Branch :" + from_NO + "</br> DC.No :" + dc_NO + "</br> DC.Date:" + date + ".<br/>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Infoo", "<script>showpop6('" + msg1 + "','" + head1 + "')</script>", false);
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }

                }

                if (objbs.getsettingid("4"))
                {
                    if (objbs.IsConnectedToInternet())
                    {


                        DateTime sDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DataSet dsprod = objbs.getbranchbyproductionbyheader(sCode, sDate);
                        if (dsprod.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Stock Request From Branch:";
                            // msg = head;
                            for (int i = 0; i < dsprod.Tables[0].Rows.Count; i++)
                            {

                                string from_NO = dsprod.Tables[0].Rows[i]["branch"].ToString();
                                string requestNo = dsprod.Tables[0].Rows[i]["requestNo"].ToString();
                                //string dc_NO = dsreceived.Tables[0].Rows[i]["DC_NO"].ToString();
                                string date = Convert.ToDateTime(dsprod.Tables[0].Rows[i]["requestdate"]).ToString("dd/MM/yyyy");
                                string datewihttime = Convert.ToDateTime(dsprod.Tables[0].Rows[i]["RequestEntryTime"]).ToString("dd/MM/yyyy");
                                string mergee = date + '-' + datewihttime;
                                msg1 += "<tr><td>Request From :" + from_NO + "</br> Req.No :" + requestNo + "</br> Req.Date:" + mergee + ".<br/>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Infioo", "<script>showpop6('" + msg1 + "','" + head1 + "')</script>", false);

                        }

                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }
                }

                if (objbs.getsettingid("5"))
                {
                    if (objbs.IsConnectedToInternet())
                    {


                        DateTime sDate = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DataSet ds = objbs.getbranchbyproductionStorebyheader(sCode, sDate);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Store Stock Request From Branch:";
                            // msg = head;
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                string from_NO = ds.Tables[0].Rows[i]["branch"].ToString();
                                string requestNo = ds.Tables[0].Rows[i]["requestNo"].ToString();
                                //string dc_NO = dsreceived.Tables[0].Rows[i]["DC_NO"].ToString();
                                string date = Convert.ToDateTime(ds.Tables[0].Rows[i]["requestdate"]).ToString("dd/MM/yyyy");
                                // string datewihttime = Convert.ToDateTime(ds.Tables[0].Rows[i]["RequestEntryTime"]).ToString("dd/MM/yyyy");
                                string mergee = date;
                                msg1 += "<tr><td>Request From :" + from_NO + "</br> Req.No :" + requestNo + "</br> Req.Date:" + mergee + ".<br/>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Infooo", "<script>showpop6('" + msg1 + "','" + head1 + "')</script>", false);

                        }
                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }
                }

                if (objbs.getsettingid("6"))
                {
                    if (objbs.IsConnectedToInternet())
                    {
                        DataSet ds = objbs.GetDCNONewForNotification(sCode);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Warning MSG:";

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                string Status = ds.Tables[0].Rows[i]["Status"].ToString();
                                string Branchcode = ds.Tables[0].Rows[i]["Branchcode"].ToString();
                                //  string requestNo = ds.Tables[0].Rows[i]["requestNo"].ToString();
                                string dc_NO = ds.Tables[0].Rows[i]["DC_NO"].ToString();
                                string date = Convert.ToDateTime(ds.Tables[0].Rows[i]["DC_Date"]).ToString("dd/MM/yyyy");
                                // string datewihttime = Convert.ToDateTime(ds.Tables[0].Rows[i]["RequestEntryTime"]).ToString("dd/MM/yyyy");
                                string mergee = date;
                                msg1 += "<tr><td>Status:" + Status + "</br>Request From :" + Branchcode + "</br> DC.No :" + dc_NO + "</br> DC.Date:" + mergee + ".<br/>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SHOWNOTI", "<script>SHOWNOTI('" + msg1 + "','" + head1 + "')</script>", false);
                        }
                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }
                }

                if (objbs.getsettingid("7"))
                {
                    if (objbs.IsConnectedToInternet())
                    {
                        DataSet ds = objbs.GetinterDCNONew(sCode);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Warning MSG:";

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                string Status = ds.Tables[0].Rows[i]["Status"].ToString();
                                string Branchcode = ds.Tables[0].Rows[i]["toBranchcode"].ToString();
                                //  string requestNo = ds.Tables[0].Rows[i]["requestNo"].ToString();
                                string dc_NO = ds.Tables[0].Rows[i]["DC_NO"].ToString();
                                string date = Convert.ToDateTime(ds.Tables[0].Rows[i]["DC_Date"]).ToString("dd/MM/yyyy");
                                // string datewihttime = Convert.ToDateTime(ds.Tables[0].Rows[i]["RequestEntryTime"]).ToString("dd/MM/yyyy");
                                string mergee = date;
                                msg1 += "<tr><td>Status:" + Status + "</br>Request From :" + Branchcode + "</br> DC.No :" + dc_NO + "</br> DC.Date:" + mergee + ".<br/>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "SHOWNOTIi", "<script>SHOWNOTI('" + msg1 + "','" + head1 + "')</script>", false);
                        }
                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }

                }

                if (objbs.getsettingid("2"))
                {
                    if (objbs.IsConnectedToInternet())
                    {
                        DataSet ds = objbs.getallnotificationmsg(sCode);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string head1 = "";
                            string msg1 = "";

                            head1 = "Admin MSG:";

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                string Status = ds.Tables[0].Rows[i]["MessageTitle"].ToString();


                                string MessageContent = ds.Tables[0].Rows[i]["MessageContent"].ToString();

                                msg1 += "<tr><td>Message Title:" + Status + "</br>Message Content :" + MessageContent + ".</br>---------->" + "</br> </td></td>";
                            }
                            // string text2 = msg;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "NOTIFICA", "<script>NOTIFICA('" + msg1 + "','" + head1 + "')</script>", false);
                        }
                    }
                    else
                    {
                        string text2 = "Please Check Your Internet Connection.Thank You!!!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text2 + "')</script>", false);
                    }
                }


                #endregion
            }



            if (!IsPostBack)
            {
                DataSet dacess = objbs.getuseraccess(Empid);
                if (dacess.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dacess.Tables[0].Rows.Count; i++)
                    {
                        string screen = dacess.Tables[0].Rows[i]["screencode"].ToString();

                        if (sUserChk != "1")
                        {
                            if (objbs.getsettingid("8"))
                            {
                                DataSet checkdenomaiantiondone = objbs.checkdenomination_Previousday(sTableName);
                                if (checkdenomaiantiondone.Tables[0].Rows.Count > 0)
                                {
                                    #region Reports
                                    if (screen == "CashReceiptsReport")
                                    {
                                        Reports.Visible = true;
                                        PaymentReport.Visible = true;
                                        CustomerReceiptReport.Visible = true;
                                    }

                                    if (screen == "CustomerOutStanding")
                                    {
                                        Reports.Visible = true;
                                        PaymentReport.Visible = true;
                                        CustomerOutStandingReport.Visible = true;
                                    }

                                    if (screen == "SalesandReceiptReport")
                                    {
                                        Reports.Visible = true;
                                        PaymentReport.Visible = true;
                                        SalesandReceiptReport.Visible = true;
                                    }



                                    if (screen == "GeneralReports")
                                    {
                                        GeneralReports.Visible = true;
                                    }
                                    if (screen == "ReturnReceivingReport")
                                    {
                                        ReturnReceivingReport.Visible = true;
                                        StockReport.Visible = true;
                                    }

                                    if (screen == "SessionClosingReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        SessionClosingReport.Visible = true;
                                    }
                                    if (screen == "SalesSummaryReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        SalesSummaryReport.Visible = true;
                                    }
                                    if (screen == "dashboard")
                                    {
                                        dashboard.Visible = true;
                                    }
                                    //if (screen == "SessionClosingReportDel")
                                    //{
                                    //    Reports.Visible = true;
                                    //    DayCloseReport.Visible = true;
                                    //    SessionClosingReportDel.Visible = true;
                                    //}
                                    if (screen == "InvoiceGenerate")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        InvoiceGenerate.Visible = true;
                                    }
                                    if (screen == "DailyReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        DailyReport.Visible = true;
                                    }
                                    if (screen == "DenominationReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        DenominationReport.Visible = true;
                                    }
                                    if (screen == "SessioncloseReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        SessioncloseReport.Visible = true;
                                    }
                                    ////////////////////////////////////////////////////
                                    if (screen == "CustomersCeremonies")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        CustomersCeremonies.Visible = true;
                                    }
                                    if (screen == "OrderFormRep")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        OrderFormRep.Visible = true;
                                    }
                                    if (screen == "OrderFormCancel")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        OrderFormCancel.Visible = true;
                                    }
                                    if (screen == "TodaysOrder")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        TodaysOrder.Visible = true;
                                    }
                                    if (screen == "TodaysAdvance")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        TodaysAdvance.Visible = true;
                                    }
                                    if (screen == "OrderBalance")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        OrderBalance.Visible = true;
                                    }
                                    if (screen == "AddLess")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        AddLess.Visible = true;
                                    }

                                    ////////////////////////////////////////////////
                                    if (screen == "StoreStockDetails")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        StoreStockDetails.Visible = true;
                                    }
                                    if (screen == "storestockdetailedreport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        storestockdetailedreport.Visible = true;
                                    }


                                    if (screen == "PurchaseReport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        PurchaseReport.Visible = true;
                                    }
                                    if (screen == "storepurchasedetailed")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        storepurchasedetailed.Visible = true;
                                    }

                                    if (screen == "KitchenUsageReport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        KitchenUsageReport.Visible = true;
                                    }

                                    if (screen == "KitchenrawreceivedReport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        KitchenrawreceivedReport.Visible = true;
                                    }

                                    //////////////////////////////////////////////////

                                    if (screen == "CustomerSalesRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        CustomerSalesRep.Visible = true;
                                    }
                                    if (screen == "SType")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SType.Visible = true;
                                    }
                                    if (screen == "Scredit")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        Scredit.Visible = true;
                                    }
                                    if (screen == "CustomerSalesKotRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        CustomerSalesKotRep.Visible = true;
                                    }
                                    if (screen == "SalesSummary")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesSummary.Visible = true;
                                    }
                                    if (screen == "NormalSalesCancelRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        NormalSalesCancelRep.Visible = true;
                                    }
                                    if (screen == "SalesHoursReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesHoursReport.Visible = true;
                                    }
                                    if (screen == "HourlysalesReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        HourlysalesReport.Visible = true;
                                    }
                                    if (screen == "SalesandVat")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesandVat.Visible = true;
                                    }
                                    if (screen == "SalesRegisterReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesRegisterReport.Visible = true;
                                    }
                                    if (screen == "FullSalesReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        FullSalesReport.Visible = true;
                                    }
                                    if (screen == "SalesRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesRep.Visible = true;
                                    }
                                    if (screen == "TaxWiseOrder")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        TaxWiseOrder.Visible = true;
                                    }
                                    if (screen == "DayEndReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        DayEndReport.Visible = true;
                                    }
                                    ////////////////////////////////////////////////////
                                    if (screen == "Productionrep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        Productionrep.Visible = true;
                                    }
                                    if (screen == "Stockrep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        Stockrep.Visible = true;
                                    }
                                    if (screen == "GRNReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        GRNReport.Visible = true;
                                    }
                                    if (screen == "GRNPMRPT")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        GRNPMRPT.Visible = true;
                                    }
                                    if (screen == "FULLGRNReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        FULLGRNReport.Visible = true;
                                    }
                                    if (screen == "SlotGRNReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        SlotGRNReport.Visible = true;
                                    }
                                    if (screen == "StockDeatailedReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockDeatailedReport.Visible = true;
                                    }
                                    if (screen == "StockAuditReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockAuditReport.Visible = true;
                                    }
                                    /////////////////////////////////////////////

                                    if (screen == "StockReturnedRep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        StockReturnedRep.Visible = true;
                                    }
                                    if (screen == "ItemsReturnReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        ItemsReturnReport.Visible = true;
                                    }
                                    if (screen == "StockReturnChart")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        StockReturnChart.Visible = true;
                                    }
                                    if (screen == "StockReturnRepo")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        StockReturnRepo.Visible = true;
                                    }
                                    //////////////////////////////////////////
                                    if (screen == "DailyStockRequestRep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        DailyStockRequestRep.Visible = true;

                                    }
                                    if (screen == "IBSRR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IBSRR.Visible = true;

                                    }
                                    if (screen == "IBSRECR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IBSRECR.Visible = true;

                                    }
                                    if (screen == "IBSTR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IBSTR.Visible = true;
                                    }

                                    if (screen == "IPSRR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IPSRR.Visible = true;

                                    }
                                    if (screen == "IPRECR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IPRECR.Visible = true;

                                    }
                                    if (screen == "IPSTR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IPSTR.Visible = true;
                                    }

                                    if (screen == "ISSRR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        ISSRR.Visible = true;

                                    }
                                    if (screen == "ISRECR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        ISRECR.Visible = true;

                                    }
                                    if (screen == "ISSTR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        ISSTR.Visible = true;
                                    }







                                    if (screen == "DailyStockReceivedRep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        DailyStockReceivedRep.Visible = true;

                                    }

                                    if (screen == "StockReturnandGRN")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturnandGRN.Visible = true;

                                    }
                                    /////////////////////////////////////////////////
                                    if (screen == "ProductionStockDetails")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        ProductionStockDetails.Visible = true;

                                    }
                                    if (screen == "GoodsTransfer")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        GoodsTransfer.Visible = true;

                                    }


                                    if (screen == "goodstransferstore")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        goodstransferstore.Visible = true;

                                    }

                                    if (screen == "LedgerReportNEW")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        LedgerReportNEW.Visible = true;
                                    }
                                    if (screen == "DaybookNEW")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        DaybookNEW.Visible = true;
                                    }
                                    if (screen == "CashAccount")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        CashAccount.Visible = true;
                                    }
                                    if (screen == "BankStatementReport")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        BankStatementReport.Visible = true;
                                    }
                                    if (screen == "TrialBalance")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        TrialBalance.Visible = true;
                                    }
                                    if (screen == "transferreportsstore")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        transferreportsstore.Visible = true;

                                    }

                                    if (screen == "dispatchreport")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        dispatchreport.Visible = true;

                                    }



                                    if (screen == "ReturnedItems")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        ReturnedItems.Visible = true;

                                    }
                                    if (screen == "TransferReports")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        TransferReports.Visible = true;

                                    }


                                    if (screen == "supplieroutstandingstore")
                                    {
                                        Reports.Visible = true;
                                        supplierhead.Visible = true;
                                        supplieroutstandingstore.Visible = true;

                                    }
                                    if (screen == "SupplierPaymentReport")
                                    {
                                        Reports.Visible = true;
                                        supplierhead.Visible = true;
                                        SupplierPaymentReport.Visible = true;

                                    }
                                    if (screen == "SupplierOutStanding")
                                    {
                                        Reports.Visible = true;
                                        supplierhead.Visible = true;
                                        SupplierOutStanding.Visible = true;

                                    }


                                    /////////////////////////////////////////////
                                    if (screen == "ChartReport")
                                    {

                                        ChartReport.Visible = true;


                                    }
                                    if (screen == "AnalysisReport")
                                    {
                                        Reports.Visible = true;
                                        // ChartReport.Visible = true;
                                        AnalysisReport.Visible = true;

                                    }
                                    if (screen == "TodaysSalesStockReturn")
                                    {
                                        Reports.Visible = true;
                                        // ChartReport.Visible = true;
                                        TodaysSalesStockReturn.Visible = true;

                                    }
                                    if (screen == "OverAllSales")
                                    {
                                        Reports.Visible = true;
                                        //  ChartReport.Visible = true;
                                        OverAllSales.Visible = true;

                                    }
                                    /////////////////////////////////////////////////

                                    if (screen == "CustomerReport")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        CustomerReport.Visible = true;

                                    }
                                    if (screen == "GroupReport")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        GroupReport.Visible = true;

                                    }
                                    if (screen == "ItemReport")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        ItemReport.Visible = true;

                                    }
                                    if (screen == "SendMessage")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        SendMessage.Visible = true;

                                    }

                                    if (screen == "pursum")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        pursum.Visible = true;

                                    }

                                    if (screen == "purexp")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        purexp.Visible = true;

                                    }
                                    if (screen == "minstorealert")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        minstorealert.Visible = true;

                                    }
                                    if (screen == "dayclose")
                                    {
                                        dayclose.Visible = true;


                                    }

                                    if (screen == "storedayclose")
                                    {
                                        storedayclose.Visible = true;
                                    }
                                    if (screen == "chnagepassword")
                                    {
                                        chnagepassword.Visible = true;
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region SYNC
                                    if (screen == "Synchronization")
                                    {
                                        Synchronization.Visible = true;
                                    }
                                    #endregion

                                    if (screen == "onlineorderentry")
                                    {
                                        onlineorderentry.Visible = true;
                                    }
                                    if (screen == "onlineentryreport")
                                    {
                                        onlineentryreport.Visible = true;
                                    }


                                    if (screen == "PurchaseReqDeptGrid")
                                    {
                                        PurchaseReqDeptGrid.Visible = true;
                                    }

                                    if (screen == "BillInvoiceDeptGrid")
                                    {
                                        BillInvoiceDeptGrid.Visible = true;
                                    }

                                    if (screen == "storetallyinvoice")
                                    {
                                        storetallyinvoice.Visible = true;
                                    }




                                    #region INVOICe/UPLOAd
                                    if (screen == "tallyinvoice")
                                    {
                                        tallyinvoice.Visible = true;
                                    }
                                    if (screen == "storebillupload")
                                    {
                                        storebillupload.Visible = true;
                                    }

                                    #endregion

                                    #region Semi Process
                                    if (screen == "semicategory")
                                    {
                                        semiprodmenu.Visible = true;
                                        semimaster.Visible = true;
                                        semicategory.Visible = true;
                                    }

                                    if (screen == "SemiItemMaster")
                                    {
                                        semiprodmenu.Visible = true;
                                        semimaster.Visible = true;
                                        SemiItemMaster.Visible = true;
                                    }

                                    if (screen == "PrimaryUOMmaster")
                                    {
                                        semiprodmenu.Visible = true;
                                        semimaster.Visible = true;
                                        PrimaryUOMmaster.Visible = true;
                                    }

                                    // Request Menu

                                    if (screen == "semistockadd")
                                    {
                                        semiprodmenu.Visible = true;
                                        semirequestMenu.Visible = true;
                                        semistockadd.Visible = true;
                                    }

                                    if (screen == "semirequest")
                                    {
                                        semiprodmenu.Visible = true;
                                        semirequestMenu.Visible = true;
                                        semirequest.Visible = true;
                                    }
                                    if (screen == "semiaccept")
                                    {
                                        semiprodmenu.Visible = true;
                                        semirequestMenu.Visible = true;
                                        semiaccept.Visible = true;
                                    }
                                    if (screen == "Semireceive")
                                    {
                                        semiprodmenu.Visible = true;
                                        semirequestMenu.Visible = true;
                                        Semireceive.Visible = true;
                                    }


                                    #endregion

                                    #region Master

                                    if (screen == "STSIS")
                                    {
                                        MasterMenu.Visible = true;
                                        STSIS.Visible = true;
                                    }
                                    if (screen == "combo")
                                    {
                                        MasterMenu.Visible = true;
                                        combo.Visible = true;
                                    }

                                    if (screen == "UOM")
                                    {
                                        MasterMenu.Visible = true;
                                        UOM.Visible = true;
                                    }
                                    if (screen == "vehiclemaster")
                                    {
                                        MasterMenu.Visible = true;
                                        vehiclemaster.Visible = true;
                                    }
                                    if (screen == "TAX")
                                    {
                                        MasterMenu.Visible = true;
                                        TAX.Visible = true;
                                    }

                                    if (screen == "Ratesettingmaster")
                                    {
                                        MasterMenu.Visible = true;
                                        Ratesettingmaster.Visible = true;
                                    }

                                    
                                    if (screen == "IBSM")
                                    {
                                        MasterMenu.Visible = true;
                                        IBSM.Visible = true;
                                    }
                                    if (screen == "IPS")
                                    {
                                        MasterMenu.Visible = true;
                                        IPS.Visible = true;
                                    }
                                    if (screen == "notificationmsg")
                                    {
                                        MasterMenu.Visible = true;
                                        notificationmsg.Visible = true;
                                    }
                                    if (screen == "tablemaster")
                                    {
                                        MasterMenu.Visible = true;
                                        tablemaster.Visible = true;
                                    }
                                    if (screen == "attender")
                                    {
                                        MasterMenu.Visible = true;
                                        attender.Visible = true;
                                    }

                                    if (screen == "Msetting")
                                    {
                                        MasterMenu.Visible = true;
                                        Msetting.Visible = true;
                                    }
                                    if (screen == "Category")
                                    {
                                        MasterMenu.Visible = true;
                                        Category.Visible = true;
                                    }
                                    if (screen == "RequestStockSettings")
                                    {
                                        MasterMenu.Visible = true;
                                        RequestStockSettings.Visible = true;
                                    }

                                    if (screen == "CategorySettingsMaster")
                                    {
                                        MasterMenu.Visible = true;
                                        CategorySettingsMaster.Visible = true;
                                    }
                                    if (screen == "subcategory")
                                    {
                                        MasterMenu.Visible = true;
                                        subcategory.Visible = true;
                                    }
                                    if (screen == "Item")
                                    {
                                        MasterMenu.Visible = true;
                                        Item.Visible = true;
                                    }


                                    if (screen == "DepartmentSetting")
                                    {
                                        MasterMenu.Visible = true;
                                        DepartmentSetting.Visible = true;
                                    }
                                    if (screen == "Mbranch")
                                    {
                                        MasterMenu.Visible = true;
                                        Mbranch.Visible = true;
                                    }

                                    if (screen == "HappyHours")
                                    {
                                        MasterMenu.Visible = true;
                                        HappyHours.Visible = true;
                                    }

                                    if (screen == "ModelMaster")
                                    {
                                        MasterMenu.Visible = true;
                                        ModelMaster.Visible = true;
                                    }

                                    if (screen == "combo")
                                    {
                                        MasterMenu.Visible = true;
                                        combo.Visible = true;
                                    }

                                    if (screen == "itemupdate")
                                    {
                                        MasterMenu.Visible = true;
                                        itemupdate.Visible = true;
                                    }

                                    if (screen == "saletypemaster")
                                    {
                                        MasterMenu.Visible = true;
                                        saletypemaster.Visible = true;
                                    }
                                    if (screen == "Ingcategory")
                                    {
                                        MasterMenu.Visible = true;
                                        Ingcategory.Visible = true;
                                    }

                                    if (screen == "Online")
                                    {
                                        MasterMenu.Visible = true;
                                        Online.Visible = true;
                                    }
                                    if (screen == "BranchSetting")
                                    {
                                        MasterMenu.Visible = true;
                                        BranchSetting.Visible = true;
                                    }
                                    if (screen == "Ingridients")
                                    {
                                        MasterMenu.Visible = true;
                                        Ingridients.Visible = true;
                                    }
                                    if (screen == "subcompany")
                                    {
                                        MasterMenu.Visible = true;                                      
                                        subcompany.Visible = true;
                                    }

                                    if (screen == "currencymaster")
                                    {
                                        MasterMenu.Visible = true;
                                        currencymaster.Visible = true;
                                    }

                                    

                                    if (screen == "CustMast")
                                    {
                                        MasterMenu.Visible = true;
                                        Customer.Visible = true;
                                        CustMast.Visible = true;                                       
                                    }
                                    if (screen == "DealMast")
                                    {
                                        MasterMenu.Visible = true;
                                        Customer.Visible = true;
                                        DealMast.Visible = true;                                       
                                    }
                                    if(screen == "SupMast")
                                    {
                                        MasterMenu.Visible = true;
                                        Customer.Visible = true;
                                        SupMast.Visible = true;                                       
                                    }
                                    if(screen == "EmpMast")
                                    {
                                        MasterMenu.Visible = true;
                                        Customer.Visible = true;
                                        EmpMast.Visible = true;                                        
                                    }
                                    if(screen == "DisMast")
                                    {
                                        MasterMenu.Visible = true;
                                        Customer.Visible = true;
                                        DisMast.Visible = true;
                                    }
                                    if (screen == "employee")
                                    {
                                        MasterMenu.Visible = true;
                                        employee.Visible = true;
                                    }
                                    if (screen == "SemiRaw")
                                    {
                                        MasterMenu.Visible = true;
                                        SemiRaw.Visible = true;
                                    }
                                    if (screen == "Ledger")
                                    {
                                        MasterMenu.Visible = true;
                                        Ledger.Visible = true;
                                    }
                                    if (screen == "Bank")
                                    {
                                        MasterMenu.Visible = true;
                                        Bank.Visible = true;
                                    }
                                    if (screen == "Dealer")
                                    {
                                        MasterMenu.Visible = true;
                                        Dealer.Visible = true;
                                    }
                                    if (screen == "MinimumQty")
                                    {
                                        MasterMenu.Visible = true;
                                        MinimumQty.Visible = true;
                                    }
                                    if (screen == "ChangeRate")
                                    {
                                        MasterMenu.Visible = true;
                                        ChangeRate.Visible = true;
                                    }
                                    if (screen == "Waiter")
                                    {
                                        MasterMenu.Visible = true;
                                        Waiter.Visible = true;
                                    }
                                    #endregion
                                    #region UserMenu
                                    if (screen == "UserRole")
                                    {
                                        UserMenu.Visible = true;
                                        UserRole.Visible = true;
                                    }
                                    if (screen == "User")
                                    {
                                        UserMenu.Visible = true;
                                        User.Visible = true;
                                    }
                                    #endregion
                                   
                                    #region OrderFormMenu
                                    if (screen == "OrderForm")
                                    {
                                        OrderFormMenu.Visible = true;
                                        OrderForm.Visible = true;
                                    }
                                    if (screen == "TodaysDelivery")
                                    {
                                        OrderFormMenu.Visible = true;
                                        TodaysDelivery.Visible = true;
                                    }
                                    if (screen == "OrderRights")
                                    {
                                        // OrderFormMenu.Visible = true;
                                        OrderRights.Visible = true;
                                    }
                                    if (screen == "Cakeordersummary")
                                    {
                                        // OrderFormMenu.Visible = true;
                                        Cakeordersummary.Visible = true;
                                    }

                                    if (screen == "Cakeorderprocess")
                                    {
                                        // OrderFormMenu.Visible = true;
                                        Cakeorderprocess.Visible = true;
                                    }
                                    #endregion

                                    #region PaymentMenu

                                    if (screen == "CustomerSalesReceipts")
                                    {
                                        CustomerSalesReceipts.Visible = true;
                                        Payments.Visible = true;
                                    }

                                    if (screen == "CusSalesReceipts")
                                    {
                                        CusSalesReceipts.Visible = true;
                                        Payments.Visible = true;
                                    }

                                    #endregion

                                    #region InventoryMenu
                                    if (screen == "rawsales")
                                    {
                                        InventoryMenu.Visible = true;
                                        rawsales.Visible = true;
                                        PurRtn.Visible = true;
                                    }
                                    if (screen == "PaymentEntry")
                                    {
                                        InventoryMenu.Visible = true;
                                        PaymentEntry.Visible = true;

                                    }
                                    if (screen == "SupplierPaymentEntry")
                                    {
                                        InventoryMenu.Visible = true;
                                        SupplierPaymentEntry.Visible = true;

                                    }
                                    if (screen == "RawPurchase")
                                    {
                                        InventoryMenu.Visible = true;
                                        RawPurchase.Visible = true;
                                        PurRtn.Visible = true;
                                    }
                                    if (screen == "restkotsales")
                                    {
                                        InventoryMenu.Visible = true;
                                        restkotsales.Visible = true;

                                    }
                                    if (screen == "oprawentry")
                                    {
                                        InventoryMenu.Visible = true;
                                        oprawentry.Visible = true;
                                        PurRtn.Visible = true;
                                    }
                                    if (screen == "Sales")
                                    {
                                        InventoryMenu.Visible = true;
                                        Sales.Visible = true;
                                    }
                                    if (screen == "KitchenOrders")
                                    {
                                        InventoryMenu.Visible = true;
                                        KitchenOrders.Visible = true;
                                    }
                                    if (screen == "wholesale")
                                    {
                                        InventoryMenu.Visible = true;
                                        wholesale.Visible = true;
                                    }
                                    if (screen == "wholesalequotation")
                                    {
                                        InventoryMenu.Visible = true;
                                        wholesalequotation.Visible = true;
                                    }
                                    if (screen == "wholesaleReturn")
                                    {
                                        InventoryMenu.Visible = true;
                                        wholesaleReturn.Visible = true;
                                    }

                                    if (screen == "PO")
                                    {
                                        InventoryMenu.Visible = true;
                                        PO.Visible = true;
                                    }


                                    if (screen == "StockReturn")
                                    {
                                        InventoryMenu.Visible = true;
                                        StockReturn.Visible = true;
                                    }
                                    if (screen == "StockReturnReasonChange")
                                    {
                                        InventoryMenu.Visible = true;
                                        StockReturnReasonChange.Visible = true;
                                    }
                                    if (screen == "PaymentEntry")
                                    {
                                        InventoryMenu.Visible = true;
                                        PaymentEntry.Visible = true;
                                    }
                                    if (screen == "SalesTypeConversion")
                                    {
                                        InventoryMenu.Visible = true;
                                        SalesTypeConversion.Visible = true;
                                    }

                                    if (screen == "SupplierPaymentEntry")
                                    {
                                        InventoryMenu.Visible = true;
                                        SupplierPaymentEntry.Visible = true;
                                    }

                                    if (screen == "billset")
                                    {
                                        // InventoryMenu.Visible = true;
                                        billset.Visible = true;
                                    }
                                    if (screen == "orderset")
                                    {
                                        // InventoryMenu.Visible = true;
                                        orderset.Visible = true;
                                    }
                                    #endregion

                                    #region OPSCREEN
                                    if (screen == "OPStockMaster1")
                                    {
                                        OPStockMaster1.Visible = true;
                                    }
                                    if (screen == "OPExpenseGrid")
                                    {
                                        OPExpenseGrid.Visible = true;
                                    }
                                    if (screen == "OPsessionreport")
                                    {
                                        OPsessionreport.Visible = true;
                                    }
                                    if (screen == "OPDenomination")
                                    {
                                        OPDenomination.Visible = true;
                                    }
                                    #endregion

                                    #region RequestAccept

                                    if (screen == "ReturnReceiving")
                                    {
                                        RequestAccept.Visible = true;
                                        ReturnReceiving.Visible = true;
                                    }

                                    if (screen == "StockMaster")
                                    {
                                        RequestAccept.Visible = true;
                                        StockMaster.Visible = true;

                                    }

                                    if (screen == "IBSR")
                                    {
                                        RequestAccept.Visible = true;
                                        IBSR.Visible = true;

                                    }
                                    if (screen == "IBSRFB")
                                    {
                                        RequestAccept.Visible = true;
                                        IBSRFB.Visible = true;

                                    }
                                    if (screen == "IGRG")
                                    {
                                        RequestAccept.Visible = true;
                                        IGRG.Visible = true;

                                    }



                                    if (screen == "StockRequest")
                                    {
                                        RequestAccept.Visible = true;
                                        StockRequest.Visible = true;
                                    }
                                    if (screen == "storerequest")
                                    {
                                        RequestAccept.Visible = true;
                                        storerequest.Visible = true;
                                    }

                                    if (screen == "storestockreceive")
                                    {
                                        RequestAccept.Visible = true;
                                        storestockreceive.Visible = true;
                                    }
                                    if (screen == "storegoodsreceived")
                                    {
                                        RequestAccept.Visible = true;
                                        storegoodsreceived.Visible = true;
                                    }


                                    if (screen == "directstorestock")
                                    {
                                        RequestAccept.Visible = true;
                                        directstorestock.Visible = true;
                                    }


                                    if (screen == "GoodsReceived")
                                    {
                                        RequestAccept.Visible = true;
                                        GoodsReceived.Visible = true;
                                    }
                                    if (screen == "StockReceive")
                                    {
                                        RequestAccept.Visible = true;
                                        StockReceive.Visible = true;
                                    }

                                    if (screen == "DirectStockReceive")
                                    {
                                        RequestAccept.Visible = true;
                                        DirectStockReceive.Visible = true;
                                    }
                                    if (screen == "GRNPM")
                                    {
                                        RequestAccept.Visible = true;
                                        GRNPM.Visible = true;
                                    }
                                    if (screen == "RequestRawItem")
                                    {
                                        RequestAccept.Visible = true;
                                        RequestRawItem.Visible = true;
                                    }
                                    if (screen == "demandstoreitem")
                                    {
                                        RequestAccept.Visible = true;
                                        demandstoreitem.Visible = true;
                                    }
                                    if (screen == "AcceptRawItem")
                                    {
                                        RequestAccept.Visible = true;
                                        AcceptRawItem.Visible = true;
                                    }
                                    if (screen == "ReceiveRawItem")
                                    {
                                        RequestAccept.Visible = true;
                                        ReceiveRawItem.Visible = true;
                                    }
                                    if (screen == "ReceiveProductionStock")
                                    {
                                        RequestAccept.Visible = true;
                                        ReceiveProductionStock.Visible = true;
                                    }
                                    if (screen == "ReturnReceiving")
                                    {
                                        RequestAccept.Visible = true;
                                        ReturnReceiving.Visible = true;
                                    }
                                    if (screen == "IcingRequest")
                                    {
                                        RequestAccept.Visible = true;
                                        IcingRequest.Visible = true;
                                    }
                                    if (screen == "IcingReceive")
                                    {
                                        RequestAccept.Visible = true;
                                        IcingReceive.Visible = true;
                                    }

                                    if (screen == "IPSR")
                                    {
                                        RequestAccept.Visible = true;
                                        IPSR.Visible = true;
                                    }
                                    if (screen == "IPSRFP")
                                    {
                                        RequestAccept.Visible = true;
                                        IPSRFP.Visible = true;
                                    }
                                    if (screen == "IPGRG")
                                    {
                                        RequestAccept.Visible = true;
                                        IPGRG.Visible = true;
                                    }
                                    if (screen == "DISENT")
                                    {
                                        RequestAccept.Visible = true;
                                        DISENT.Visible = true;
                                    }


                                    if (screen == "ISSR")
                                    {
                                        RequestAccept.Visible = true;
                                        ISSR.Visible = true;
                                    }
                                    if (screen == "ISSRFS")
                                    {
                                        RequestAccept.Visible = true;
                                        ISSRFS.Visible = true;
                                    }
                                    if (screen == "ISGRG")
                                    {
                                        RequestAccept.Visible = true;
                                        ISGRG.Visible = true;
                                    }




                                    #endregion

                                    #region Reports
                                    if (screen == "GeneralReports")
                                    {
                                        GeneralReports.Visible = true;
                                    }
                                    if (screen == "ReturnReceivingReport")
                                    {
                                        ReturnReceivingReport.Visible = true;
                                        StockReport.Visible = true;
                                    }
                                    if (screen == "SessionClosingReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        SessionClosingReport.Visible = true;
                                    }
                                    if (screen == "SalesSummaryReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        SalesSummaryReport.Visible = true;
                                    }
                                    if (screen == "dashboard")
                                    {
                                        dashboard.Visible = true;
                                    }
                                    //if (screen == "SessionClosingReportDel")
                                    //{
                                    //    Reports.Visible = true;
                                    //    DayCloseReport.Visible = true;
                                    //    SessionClosingReportDel.Visible = true;
                                    //}
                                    if (screen == "InvoiceGenerate")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        InvoiceGenerate.Visible = true;
                                    }
                                    if (screen == "DailyReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        DailyReport.Visible = true;
                                    }
                                    if (screen == "DenominationReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        DenominationReport.Visible = true;
                                    }
                                    if (screen == "SessioncloseReport")
                                    {
                                        Reports.Visible = true;
                                        DayCloseReport.Visible = true;
                                        SessioncloseReport.Visible = true;
                                    }
                                    ////////////////////////////////////////////////////
                                    if (screen == "CustomersCeremonies")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        CustomersCeremonies.Visible = true;
                                    }
                                    if (screen == "OrderFormRep")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        OrderFormRep.Visible = true;
                                    }
                                    if (screen == "OrderFormCancel")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        OrderFormCancel.Visible = true;
                                    }
                                    if (screen == "TodaysOrder")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        TodaysOrder.Visible = true;
                                    }
                                    if (screen == "TodaysAdvance")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        TodaysAdvance.Visible = true;
                                    }
                                    if (screen == "OrderBalance")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        OrderBalance.Visible = true;
                                    }
                                    if (screen == "AddLess")
                                    {
                                        Reports.Visible = true;
                                        OrderFormReport.Visible = true;
                                        AddLess.Visible = true;
                                    }

                                    ////////////////////////////////////////////////
                                    if (screen == "StoreStockDetails")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        StoreStockDetails.Visible = true;
                                    }
                                    if (screen == "storestockdetailedreport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        storestockdetailedreport.Visible = true;
                                    }
                                    if (screen == "PurchaseReport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        PurchaseReport.Visible = true;
                                    }
                                    if (screen == "storepurchasedetailed")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        storepurchasedetailed.Visible = true;
                                    }

                                    if (screen == "KitchenUsageReport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        KitchenUsageReport.Visible = true;
                                    }

                                    if (screen == "KitchenrawreceivedReport")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        KitchenrawreceivedReport.Visible = true;
                                    }

                                    //////////////////////////////////////////////////

                                    if (screen == "CustomerSalesRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        CustomerSalesRep.Visible = true;
                                    }
                                    if (screen == "SType")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SType.Visible = true;
                                    }
                                    if (screen == "Scredit")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        Scredit.Visible = true;
                                    }
                                    if (screen == "CustomerSalesKotRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        CustomerSalesKotRep.Visible = true;
                                    }
                                    if (screen == "SalesSummary")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesSummary.Visible = true;
                                    }
                                    if (screen == "NormalSalesCancelRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        NormalSalesCancelRep.Visible = true;
                                    }
                                    if (screen == "SalesHoursReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesHoursReport.Visible = true;
                                    }
                                    if (screen == "HourlysalesReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        HourlysalesReport.Visible = true;
                                    }
                                    if (screen == "SalesandVat")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesandVat.Visible = true;
                                    }
                                    if (screen == "SalesRegisterReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesRegisterReport.Visible = true;
                                    }
                                    if (screen == "FullSalesReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        FullSalesReport.Visible = true;
                                    }
                                    if (screen == "SalesRep")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        SalesRep.Visible = true;
                                    }
                                    if (screen == "TaxWiseOrder")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        TaxWiseOrder.Visible = true;
                                    }
                                    if (screen == "DayEndReport")
                                    {
                                        Reports.Visible = true;
                                        SalesReport.Visible = true;
                                        DayEndReport.Visible = true;
                                    }
                                    ////////////////////////////////////////////////////
                                    if (screen == "Productionrep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        Productionrep.Visible = true;
                                    }
                                    if (screen == "Stockrep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        Stockrep.Visible = true;
                                    }
                                    if (screen == "GRNReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        GRNReport.Visible = true;
                                    }
                                    if (screen == "GRNPMRPT")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        GRNPMRPT.Visible = true;
                                    }
                                    if (screen == "FULLGRNReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        FULLGRNReport.Visible = true;
                                    }
                                    if (screen == "SlotGRNReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        SlotGRNReport.Visible = true;
                                    }
                                    if (screen == "StockDeatailedReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockDeatailedReport.Visible = true;
                                    }
                                    if (screen == "StockAuditReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockAuditReport.Visible = true;
                                    }
                                    /////////////////////////////////////////////

                                    if (screen == "StockReturnedRep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        StockReturnedRep.Visible = true;
                                    }
                                    if (screen == "ItemsReturnReport")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        ItemsReturnReport.Visible = true;
                                    }
                                    if (screen == "StockReturnChart")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        StockReturnChart.Visible = true;
                                    }
                                    if (screen == "StockReturnRepo")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturned.Visible = true;
                                        StockReturnRepo.Visible = true;
                                    }
                                    //////////////////////////////////////////
                                    if (screen == "DailyStockRequestRep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        DailyStockRequestRep.Visible = true;

                                    }
                                    if (screen == "IBSRR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IBSRR.Visible = true;

                                    }
                                    if (screen == "IBSRECR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IBSRECR.Visible = true;

                                    }

                                    if (screen == "IBSTR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IBSTR.Visible = true;
                                    }

                                    if (screen == "IPSRR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IPSRR.Visible = true;

                                    }
                                    if (screen == "IPRECR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IPRECR.Visible = true;

                                    }
                                    if (screen == "IPSTR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        IPSTR.Visible = true;
                                    }

                                    if (screen == "ISSRR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        ISSRR.Visible = true;

                                    }
                                    if (screen == "ISRECR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        ISRECR.Visible = true;

                                    }
                                    if (screen == "ISSTR")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        ISSTR.Visible = true;
                                    }

                                    if (screen == "DailyStockReceivedRep")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        DailyStockReceivedRep.Visible = true;

                                    }

                                    if (screen == "StockReturnandGRN")
                                    {
                                        Reports.Visible = true;
                                        StockReport.Visible = true;
                                        StockReturnandGRN.Visible = true;

                                    }
                                    /////////////////////////////////////////////////
                                    if (screen == "ProductionStockDetails")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        ProductionStockDetails.Visible = true;

                                    }
                                    if (screen == "GoodsTransfer")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        GoodsTransfer.Visible = true;

                                    }

                                    if (screen == "goodstransferstore")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        goodstransferstore.Visible = true;

                                    }
                                    if (screen == "LedgerReportNEW")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        LedgerReportNEW.Visible = true;
                                    }
                                    if (screen == "DaybookNEW")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        DaybookNEW.Visible = true;
                                    }
                                    if (screen == "CashAccount")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        CashAccount.Visible = true;
                                    }
                                    if (screen == "BankStatementReport")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        BankStatementReport.Visible = true;
                                    }
                                    if (screen == "TrialBalance")
                                    {
                                        Reports.Visible = true;
                                        AccountsReport.Visible = true;
                                        TrialBalance.Visible = true;
                                    }

                                    if (screen == "transferreportsstore")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        transferreportsstore.Visible = true;

                                    }

                                    if (screen == "dispatchreport")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        dispatchreport.Visible = true;

                                    }



                                    if (screen == "ReturnedItems")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        ReturnedItems.Visible = true;

                                    }
                                    if (screen == "TransferReports")
                                    {
                                        Reports.Visible = true;
                                        ProductionReport.Visible = true;
                                        TransferReports.Visible = true;

                                    }


                                    if (screen == "supplieroutstandingstore")
                                    {
                                        Reports.Visible = true;
                                        supplierhead.Visible = true;
                                        supplieroutstandingstore.Visible = true;

                                    }
                                    if (screen == "SupplierPaymentReport")
                                    {
                                        Reports.Visible = true;
                                        supplierhead.Visible = true;
                                        SupplierPaymentReport.Visible = true;

                                    }
                                    if (screen == "SupplierOutStanding")
                                    {
                                        Reports.Visible = true;
                                        supplierhead.Visible = true;
                                        SupplierOutStanding.Visible = true;

                                    }


                                    /////////////////////////////////////////////
                                    if (screen == "ChartReport")
                                    {

                                        ChartReport.Visible = true;


                                    }
                                    if (screen == "AnalysisReport")
                                    {
                                        Reports.Visible = true;
                                        // ChartReport.Visible = true;
                                        AnalysisReport.Visible = true;

                                    }
                                    if (screen == "TodaysSalesStockReturn")
                                    {
                                        Reports.Visible = true;
                                        // ChartReport.Visible = true;
                                        TodaysSalesStockReturn.Visible = true;

                                    }
                                    if (screen == "OverAllSales")
                                    {
                                        Reports.Visible = true;
                                        //  ChartReport.Visible = true;
                                        OverAllSales.Visible = true;

                                    }
                                    /////////////////////////////////////////////////

                                    if (screen == "CustomerReport")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        CustomerReport.Visible = true;

                                    }
                                    if (screen == "GroupReport")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        GroupReport.Visible = true;

                                    }
                                    if (screen == "ItemReport")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        ItemReport.Visible = true;

                                    }
                                    if (screen == "SendMessage")
                                    {
                                        Reports.Visible = true;
                                        OtherReport.Visible = true;
                                        SendMessage.Visible = true;

                                    }

                                    if (screen == "pursum")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        pursum.Visible = true;

                                    }

                                    if (screen == "purexp")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        purexp.Visible = true;

                                    }

                                    if (screen == "minstorealert")
                                    {
                                        Reports.Visible = true;
                                        RawPurchaseReport.Visible = true;
                                        minstorealert.Visible = true;

                                    }


                                    if (screen == "dayclose")
                                    {
                                        dayclose.Visible = true;


                                    }
                                    if (screen == "storedayclose")
                                    {
                                        storedayclose.Visible = true;
                                    }
                                    if (screen == "chnagepassword")
                                    {
                                        chnagepassword.Visible = true;
                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                #region SYNC
                                if (screen == "Synchronization")
                                {
                                    Synchronization.Visible = true;
                                }
                                #endregion
                                if (screen == "onlineorderentry")
                                {
                                    onlineorderentry.Visible = true;
                                }
                                if (screen == "onlineentryreport")
                                {
                                    onlineentryreport.Visible = true;
                                }

                                if (screen == "PurchaseReqDeptGrid")
                                {
                                    PurchaseReqDeptGrid.Visible = true;
                                }

                                if (screen == "BillInvoiceDeptGrid")
                                {
                                    BillInvoiceDeptGrid.Visible = true;
                                }

                                if (screen == "storetallyinvoice")
                                {
                                    storetallyinvoice.Visible = true;
                                }

                                #region INVOICe/UPLOAd
                                if (screen == "tallyinvoice")
                                {
                                    tallyinvoice.Visible = true;
                                }
                                if (screen == "storebillupload")
                                {
                                    storebillupload.Visible = true;
                                }

                                #endregion

                                #region Semi Process
                                if (screen == "semicategory")
                                {
                                    semiprodmenu.Visible = true;
                                    semimaster.Visible = true;
                                    semicategory.Visible = true;
                                }

                                if (screen == "SemiItemMaster")
                                {
                                    semiprodmenu.Visible = true;
                                    semimaster.Visible = true;
                                    SemiItemMaster.Visible = true;
                                }

                                if (screen == "PrimaryUOMmaster")
                                {
                                    semiprodmenu.Visible = true;
                                    semimaster.Visible = true;
                                    PrimaryUOMmaster.Visible = true;
                                }

                                // Request Menu

                                if (screen == "semistockadd")
                                {
                                    semiprodmenu.Visible = true;
                                    semirequestMenu.Visible = true;
                                    semistockadd.Visible = true;
                                }

                                if (screen == "semirequest")
                                {
                                    semiprodmenu.Visible = true;
                                    semirequestMenu.Visible = true;
                                    semirequest.Visible = true;
                                }
                                if (screen == "semiaccept")
                                {
                                    semiprodmenu.Visible = true;
                                    semirequestMenu.Visible = true;
                                    semiaccept.Visible = true;
                                }
                                if (screen == "Semireceive")
                                {
                                    semiprodmenu.Visible = true;
                                    semirequestMenu.Visible = true;
                                    Semireceive.Visible = true;
                                }


                                #endregion

                                #region Master
                                if (screen == "STSIS")
                                {
                                    MasterMenu.Visible = true;
                                    STSIS.Visible = true;
                                }
                                if (screen == "combo")
                                {
                                    MasterMenu.Visible = true;
                                    combo.Visible = true;
                                }
                                if (screen == "UOM")
                                {
                                    MasterMenu.Visible = true;
                                    UOM.Visible = true;
                                }
                                if (screen == "vehiclemaster")
                                {
                                    MasterMenu.Visible = true;
                                    vehiclemaster.Visible = true;
                                }
                                if (screen == "TAX")
                                {
                                    MasterMenu.Visible = true;
                                    TAX.Visible = true;
                                }
                                if (screen == "Ratesettingmaster")
                                {
                                    MasterMenu.Visible = true;
                                    Ratesettingmaster.Visible = true;
                                }

                                if (screen == "IBSM")
                                {
                                    MasterMenu.Visible = true;
                                    IBSM.Visible = true;
                                }
                                if (screen == "IPS")
                                {
                                    MasterMenu.Visible = true;
                                    IPS.Visible = true;
                                }
                                if (screen == "notificationmsg")
                                {
                                    MasterMenu.Visible = true;
                                    notificationmsg.Visible = true;
                                }
                                if (screen == "tablemaster")
                                {
                                    MasterMenu.Visible = true;
                                    tablemaster.Visible = true;
                                }
                                if (screen == "attender")
                                {
                                    MasterMenu.Visible = true;
                                    attender.Visible = true;
                                }

                                if (screen == "Msetting")
                                {
                                    MasterMenu.Visible = true;
                                    Msetting.Visible = true;
                                }
                                if (screen == "Category")
                                {
                                    MasterMenu.Visible = true;
                                    Category.Visible = true;
                                }
                                if (screen == "RequestStockSettings")
                                {
                                    MasterMenu.Visible = true;
                                    RequestStockSettings.Visible = true;
                                }

                                if (screen == "CategorySettingsMaster")
                                {
                                    MasterMenu.Visible = true;
                                    CategorySettingsMaster.Visible = true;
                                }

                                if (screen == "subcategory")
                                {
                                    MasterMenu.Visible = true;
                                    subcategory.Visible = true;
                                }
                                if (screen == "Item")
                                {
                                    MasterMenu.Visible = true;
                                    Item.Visible = true;
                                }
                                if (screen == "DepartmentSetting")
                                {
                                    MasterMenu.Visible = true;
                                    DepartmentSetting.Visible = true;
                                }
                                if (screen == "Mbranch")
                                {
                                    MasterMenu.Visible = true;
                                    Mbranch.Visible = true;
                                }

                                if (screen == "HappyHours")
                                {
                                    MasterMenu.Visible = true;
                                    HappyHours.Visible = true;
                                }
                                if (screen == "ModelMaster")
                                {
                                    MasterMenu.Visible = true;
                                    ModelMaster.Visible = true;
                                }

                                if (screen == "combo")
                                {
                                    MasterMenu.Visible = true;
                                    combo.Visible = true;
                                }
                                if (screen == "itemupdate")
                                {
                                    MasterMenu.Visible = true;
                                    itemupdate.Visible = true;
                                }

                                if (screen == "saletypemaster")
                                {
                                    MasterMenu.Visible = true;
                                    saletypemaster.Visible = true;
                                }
                                if (screen == "Ingcategory")
                                {
                                    MasterMenu.Visible = true;
                                    Ingcategory.Visible = true;
                                }

                                if (screen == "Online")
                                {
                                    MasterMenu.Visible = true;
                                    Online.Visible = true;
                                }
                                if (screen == "BranchSetting")
                                {
                                    MasterMenu.Visible = true;
                                    BranchSetting.Visible = true;
                                }
                                if (screen == "Ingridients")
                                {
                                    MasterMenu.Visible = true;
                                    Ingridients.Visible = true;
                                }
                                if (screen == "CustMast")
                                {
                                    MasterMenu.Visible = true;
                                    Customer.Visible = true;
                                    CustMast.Visible = true;
                                }
                                if (screen == "subcompany")
                                {
                                    MasterMenu.Visible = true;
                                    subcompany.Visible = true;
                                }

                                if (screen == "currencymaster")
                                {
                                    MasterMenu.Visible = true;
                                    currencymaster.Visible = true;
                                }

                                if (screen == "DealMast")
                                {
                                    MasterMenu.Visible = true;
                                    Customer.Visible = true;
                                    DealMast.Visible = true;
                                }
                                if (screen == "SupMast")
                                {
                                    MasterMenu.Visible = true;
                                    Customer.Visible = true;
                                    SupMast.Visible = true;
                                }
                                if (screen == "EmpMast")
                                {
                                    MasterMenu.Visible = true;
                                    Customer.Visible = true;
                                    EmpMast.Visible = true;
                                }
                                if (screen == "DisMast")
                                {
                                    MasterMenu.Visible = true;
                                    Customer.Visible = true;
                                    DisMast.Visible = true;
                                }
                                if (screen == "employee")
                                {
                                    MasterMenu.Visible = true;
                                    employee.Visible = true;
                                }
                                if (screen == "SemiRaw")
                                {
                                    MasterMenu.Visible = true;
                                    SemiRaw.Visible = true;
                                }
                                if (screen == "Ledger")
                                {
                                    MasterMenu.Visible = true;
                                    Ledger.Visible = true;
                                }
                                if (screen == "Bank")
                                {
                                    MasterMenu.Visible = true;
                                    Bank.Visible = true;
                                }
                                if (screen == "Dealer")
                                {
                                    MasterMenu.Visible = true;
                                    Dealer.Visible = true;
                                }
                                if (screen == "MinimumQty")
                                {
                                    MasterMenu.Visible = true;
                                    MinimumQty.Visible = true;
                                }
                                if (screen == "ChangeRate")
                                {
                                    MasterMenu.Visible = true;
                                    ChangeRate.Visible = true;
                                }
                                if (screen == "Waiter")
                                {
                                    MasterMenu.Visible = true;
                                    Waiter.Visible = true;
                                }
                                #endregion

                                #region UserMenu
                                if (screen == "UserRole")
                                {
                                    UserMenu.Visible = true;
                                    UserRole.Visible = true;
                                }
                                if (screen == "User")
                                {
                                    UserMenu.Visible = true;
                                    User.Visible = true;
                                }
                                #endregion

                                #region OrderFormMenu
                                if (screen == "OrderForm")
                                {
                                    OrderFormMenu.Visible = true;
                                    OrderForm.Visible = true;
                                }
                                if (screen == "TodaysDelivery")
                                {
                                    OrderFormMenu.Visible = true;
                                    TodaysDelivery.Visible = true;
                                }
                                if (screen == "OrderRights")
                                {
                                    // OrderFormMenu.Visible = true;
                                    OrderRights.Visible = true;
                                }
                                if (screen == "Cakeordersummary")
                                {
                                    // OrderFormMenu.Visible = true;
                                    Cakeordersummary.Visible = true;
                                }
                                if (screen == "Cakeorderprocess")
                                {
                                    // OrderFormMenu.Visible = true;
                                    Cakeorderprocess.Visible = true;
                                }
                                #endregion

                                #region PaymentMenu

                                if (screen == "CustomerSalesReceipts")
                                {
                                    CustomerSalesReceipts.Visible = true;
                                    Payments.Visible = true;
                                }

                                if (screen == "CusSalesReceipts")
                                {
                                    CusSalesReceipts.Visible = true;
                                    Payments.Visible = true;
                                }

                                #endregion

                                #region InventoryMenu
                                if (screen == "rawsales")
                                {
                                    InventoryMenu.Visible = true;
                                    rawsales.Visible = true;
                                    PurRtn.Visible = true;
                                }
                                if (screen == "PaymentEntry")
                                {
                                    InventoryMenu.Visible = true;
                                    PaymentEntry.Visible = true;

                                }
                                if (screen == "SupplierPaymentEntry")
                                {
                                    InventoryMenu.Visible = true;
                                    SupplierPaymentEntry.Visible = true;

                                }
                                if (screen == "RawPurchase")
                                {
                                    InventoryMenu.Visible = true;
                                    RawPurchase.Visible = true;
                                    PurRtn.Visible = true;
                                }
                                if (screen == "restkotsales")
                                {
                                    InventoryMenu.Visible = true;
                                    restkotsales.Visible = true;

                                }
                                if (screen == "oprawentry")
                                {
                                    InventoryMenu.Visible = true;
                                    oprawentry.Visible = true;
                                    PurRtn.Visible = true;
                                }
                                if (screen == "Sales")
                                {
                                    InventoryMenu.Visible = true;
                                    Sales.Visible = true;
                                }
                                if (screen == "KitchenOrders")
                                {
                                    InventoryMenu.Visible = true;
                                    KitchenOrders.Visible = true;
                                }
                                if (screen == "wholesale")
                                {
                                    InventoryMenu.Visible = true;
                                    wholesale.Visible = true;
                                }
                                if (screen == "wholesalequotation")
                                {
                                    InventoryMenu.Visible = true;
                                    wholesalequotation.Visible = true;
                                }
                                if (screen == "wholesaleReturn")
                                {
                                    InventoryMenu.Visible = true;
                                    wholesaleReturn.Visible = true;
                                }

                                if (screen == "PO")
                                {
                                    InventoryMenu.Visible = true;
                                    PO.Visible = true;
                                }


                                if (screen == "StockReturn")
                                {
                                    InventoryMenu.Visible = true;
                                    StockReturn.Visible = true;
                                }
                                if (screen == "StockReturnReasonChange")
                                {
                                    InventoryMenu.Visible = true;
                                    StockReturnReasonChange.Visible = true;
                                }
                                if (screen == "PaymentEntry")
                                {
                                    InventoryMenu.Visible = true;
                                    PaymentEntry.Visible = true;
                                }
                                if (screen == "SalesTypeConversion")
                                {
                                    InventoryMenu.Visible = true;
                                    SalesTypeConversion.Visible = true;
                                }
                                if (screen == "SupplierPaymentEntry")
                                {
                                    InventoryMenu.Visible = true;
                                    SupplierPaymentEntry.Visible = true;
                                }
                                if (screen == "billset")
                                {
                                    // InventoryMenu.Visible = true;
                                    billset.Visible = true;
                                }
                                if (screen == "orderset")
                                {
                                    // InventoryMenu.Visible = true;
                                    orderset.Visible = true;
                                }
                                #endregion

                                #region OPSCREEN
                                if (screen == "OPStockMaster1")
                                {
                                    OPStockMaster1.Visible = true;
                                }
                                if (screen == "OPExpenseGrid")
                                {
                                    OPExpenseGrid.Visible = true;
                                }
                                if (screen == "OPsessionreport")
                                {
                                    OPsessionreport.Visible = true;
                                }
                                if (screen == "OPDenomination")
                                {
                                    OPDenomination.Visible = true;
                                }
                                #endregion

                                #region RequestAccept

                                if (screen == "ReturnReceiving")
                                {
                                    RequestAccept.Visible = true;
                                    ReturnReceiving.Visible = true;
                                }

                                if (screen == "StockMaster")
                                {
                                    RequestAccept.Visible = true;
                                    StockMaster.Visible = true;

                                }

                                if (screen == "IBSR")
                                {
                                    RequestAccept.Visible = true;
                                    IBSR.Visible = true;

                                }
                                if (screen == "IBSRFB")
                                {
                                    RequestAccept.Visible = true;
                                    IBSRFB.Visible = true;

                                }
                                if (screen == "IGRG")
                                {
                                    RequestAccept.Visible = true;
                                    IGRG.Visible = true;

                                }



                                if (screen == "StockRequest")
                                {
                                    RequestAccept.Visible = true;
                                    StockRequest.Visible = true;
                                }
                                if (screen == "storerequest")
                                {
                                    RequestAccept.Visible = true;
                                    storerequest.Visible = true;
                                }

                                if (screen == "storestockreceive")
                                {
                                    RequestAccept.Visible = true;
                                    storestockreceive.Visible = true;
                                }

                                if (screen == "directstorestock")
                                {
                                    RequestAccept.Visible = true;
                                    directstorestock.Visible = true;
                                }


                                if (screen == "storegoodsreceived")
                                {
                                    RequestAccept.Visible = true;
                                    storegoodsreceived.Visible = true;
                                }


                                if (screen == "GoodsReceived")
                                {
                                    RequestAccept.Visible = true;
                                    GoodsReceived.Visible = true;
                                }
                                if (screen == "StockReceive")
                                {
                                    RequestAccept.Visible = true;
                                    StockReceive.Visible = true;
                                }

                                if (screen == "DirectStockReceive")
                                {
                                    RequestAccept.Visible = true;
                                    DirectStockReceive.Visible = true;
                                }
                                if (screen == "GRNPM")
                                {
                                    RequestAccept.Visible = true;
                                    GRNPM.Visible = true;
                                }
                                if (screen == "RequestRawItem")
                                {
                                    RequestAccept.Visible = true;
                                    RequestRawItem.Visible = true;
                                }
                                if (screen == "demandstoreitem")
                                {
                                    RequestAccept.Visible = true;
                                    demandstoreitem.Visible = true;
                                }
                                if (screen == "AcceptRawItem")
                                {
                                    RequestAccept.Visible = true;
                                    AcceptRawItem.Visible = true;
                                }
                                if (screen == "ReceiveRawItem")
                                {
                                    RequestAccept.Visible = true;
                                    ReceiveRawItem.Visible = true;
                                }
                                if (screen == "ReceiveProductionStock")
                                {
                                    RequestAccept.Visible = true;
                                    ReceiveProductionStock.Visible = true;
                                }
                                if (screen == "ReturnReceiving")
                                {
                                    RequestAccept.Visible = true;
                                    ReturnReceiving.Visible = true;
                                }
                                if (screen == "IcingRequest")
                                {
                                    RequestAccept.Visible = true;
                                    IcingRequest.Visible = true;
                                }
                                if (screen == "IcingReceive")
                                {
                                    RequestAccept.Visible = true;
                                    IcingReceive.Visible = true;
                                }

                                if (screen == "IPSR")
                                {
                                    RequestAccept.Visible = true;
                                    IPSR.Visible = true;
                                }
                                if (screen == "IPSRFP")
                                {
                                    RequestAccept.Visible = true;
                                    IPSRFP.Visible = true;
                                }
                                if (screen == "IPGRG")
                                {
                                    RequestAccept.Visible = true;
                                    IPGRG.Visible = true;
                                }
                                if (screen == "DISENT")
                                {
                                    RequestAccept.Visible = true;
                                    DISENT.Visible = true;
                                }

                                if (screen == "ISSR")
                                {
                                    RequestAccept.Visible = true;
                                    ISSR.Visible = true;
                                }
                                if (screen == "ISSRFS")
                                {
                                    RequestAccept.Visible = true;
                                    ISSRFS.Visible = true;
                                }
                                if (screen == "ISGRG")
                                {
                                    RequestAccept.Visible = true;
                                    ISGRG.Visible = true;
                                }
                                #endregion

                                #region Reports

                                if (screen == "GeneralReports")
                                {
                                    GeneralReports.Visible = true;
                                }
                                if (screen == "ReturnReceivingReport")
                                {
                                    ReturnReceivingReport.Visible = true;
                                    StockReport.Visible = true;
                                }
                                if (screen == "SessionClosingReport")
                                {
                                    Reports.Visible = true;
                                    DayCloseReport.Visible = true;
                                    SessionClosingReport.Visible = true;
                                }
                                if (screen == "SalesSummaryReport")
                                {
                                    Reports.Visible = true;
                                    DayCloseReport.Visible = true;
                                    SalesSummaryReport.Visible = true;
                                }
                                if (screen == "dashboard")
                                {
                                    dashboard.Visible = true;
                                }
                                //if (screen == "SessionClosingReportDel")
                                //{
                                //    Reports.Visible = true;
                                //    DayCloseReport.Visible = true;
                                //    SessionClosingReportDel.Visible = true;
                                //}
                                if (screen == "InvoiceGenerate")
                                {
                                    Reports.Visible = true;
                                    DayCloseReport.Visible = true;
                                    InvoiceGenerate.Visible = true;
                                }
                                if (screen == "DailyReport")
                                {
                                    Reports.Visible = true;
                                    DayCloseReport.Visible = true;
                                    DailyReport.Visible = true;
                                }
                                if (screen == "DenominationReport")
                                {
                                    Reports.Visible = true;
                                    DayCloseReport.Visible = true;
                                    DenominationReport.Visible = true;
                                }
                                if (screen == "SessioncloseReport")
                                {
                                    Reports.Visible = true;
                                    DayCloseReport.Visible = true;
                                    SessioncloseReport.Visible = true;
                                }
                                ////////////////////////////////////////////////////
                                if (screen == "CustomersCeremonies")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    CustomersCeremonies.Visible = true;
                                }
                                if (screen == "OrderFormRep")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    OrderFormRep.Visible = true;
                                }
                                if (screen == "OrderFormCancel")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    OrderFormCancel.Visible = true;
                                }
                                if (screen == "TodaysOrder")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    TodaysOrder.Visible = true;
                                }
                                if (screen == "TodaysAdvance")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    TodaysAdvance.Visible = true;
                                }
                                if (screen == "OrderBalance")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    OrderBalance.Visible = true;
                                }
                                if (screen == "AddLess")
                                {
                                    Reports.Visible = true;
                                    OrderFormReport.Visible = true;
                                    AddLess.Visible = true;
                                }

                                ////////////////////////////////////////////////
                                if (screen == "StoreStockDetails")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    StoreStockDetails.Visible = true;
                                }
                                if (screen == "storestockdetailedreport")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    storestockdetailedreport.Visible = true;
                                }
                                if (screen == "storepurchasedetailed")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    storepurchasedetailed.Visible = true;
                                }

                                if (screen == "KitchenUsageReport")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    KitchenUsageReport.Visible = true;
                                }

                                if (screen == "KitchenrawreceivedReport")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    KitchenrawreceivedReport.Visible = true;
                                }

                                if (screen == "PurchaseReport")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    PurchaseReport.Visible = true;
                                }
                                if (screen == "storepurchasedetailed")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    storepurchasedetailed.Visible = true;
                                }

                                if (screen == "KitchenUsageReport")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    KitchenUsageReport.Visible = true;
                                }

                                if (screen == "KitchenrawreceivedReport")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    KitchenrawreceivedReport.Visible = true;
                                }

                                //////////////////////////////////////////////////

                                if (screen == "CustomerSalesRep")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    CustomerSalesRep.Visible = true;
                                }
                                if (screen == "SType")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    SType.Visible = true;
                                }
                                if (screen == "Scredit")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    Scredit.Visible = true;
                                }
                                if (screen == "CustomerSalesKotRep")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    CustomerSalesKotRep.Visible = true;
                                }
                                if (screen == "SalesSummary")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    SalesSummary.Visible = true;
                                }
                                if (screen == "NormalSalesCancelRep")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    NormalSalesCancelRep.Visible = true;
                                }
                                if (screen == "SalesHoursReport")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    SalesHoursReport.Visible = true;
                                }
                                if (screen == "HourlysalesReport")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    HourlysalesReport.Visible = true;
                                }
                                if (screen == "SalesandVat")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    SalesandVat.Visible = true;
                                }
                                if (screen == "SalesRegisterReport")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    SalesRegisterReport.Visible = true;
                                }
                                if (screen == "FullSalesReport")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    FullSalesReport.Visible = true;
                                }
                                if (screen == "SalesRep")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    SalesRep.Visible = true;
                                }
                                if (screen == "TaxWiseOrder")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    TaxWiseOrder.Visible = true;
                                }
                                if (screen == "DayEndReport")
                                {
                                    Reports.Visible = true;
                                    SalesReport.Visible = true;
                                    DayEndReport.Visible = true;
                                }
                                ////////////////////////////////////////////////////
                                if (screen == "Productionrep")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    Productionrep.Visible = true;
                                }
                                if (screen == "Stockrep")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    Stockrep.Visible = true;
                                }
                                if (screen == "GRNReport")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    GRNReport.Visible = true;
                                }
                                if (screen == "GRNPMRPT")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    GRNPMRPT.Visible = true;
                                }
                                if (screen == "FULLGRNReport")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    FULLGRNReport.Visible = true;
                                }
                                if (screen == "SlotGRNReport")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    SlotGRNReport.Visible = true;
                                }
                                if (screen == "StockDeatailedReport")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockDeatailedReport.Visible = true;
                                }
                                if (screen == "StockAuditReport")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockAuditReport.Visible = true;
                                }
                                /////////////////////////////////////////////

                                if (screen == "StockReturnedRep")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockReturned.Visible = true;
                                    StockReturnedRep.Visible = true;
                                }

                                if (screen == "ItemsReturnReport")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockReturned.Visible = true;
                                    ItemsReturnReport.Visible = true;
                                }


                                if (screen == "StockReturnChart")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockReturned.Visible = true;
                                    StockReturnChart.Visible = true;
                                }
                                if (screen == "StockReturnRepo")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockReturned.Visible = true;
                                    StockReturnRepo.Visible = true;
                                }
                                //////////////////////////////////////////
                                if (screen == "DailyStockRequestRep")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    DailyStockRequestRep.Visible = true;

                                }
                                if (screen == "IBSRR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    IBSRR.Visible = true;

                                }
                                if (screen == "IBSRECR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    IBSRECR.Visible = true;

                                }

                                if (screen == "IBSTR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    IBSTR.Visible = true;
                                }

                                if (screen == "IPSRR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    IPSRR.Visible = true;

                                }
                                if (screen == "IPRECR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    IPRECR.Visible = true;

                                }
                                if (screen == "IPSTR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    IPSTR.Visible = true;
                                }

                                if (screen == "ISSRR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    ISSRR.Visible = true;

                                }
                                if (screen == "ISRECR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    ISRECR.Visible = true;

                                }
                                if (screen == "ISSTR")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    ISSTR.Visible = true;
                                }

                                if (screen == "DailyStockReceivedRep")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    DailyStockReceivedRep.Visible = true;

                                }

                                if (screen == "StockReturnandGRN")
                                {
                                    Reports.Visible = true;
                                    StockReport.Visible = true;
                                    StockReturnandGRN.Visible = true;

                                }
                                /////////////////////////////////////////////////
                                if (screen == "ProductionStockDetails")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    ProductionStockDetails.Visible = true;

                                }
                                if (screen == "GoodsTransfer")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    GoodsTransfer.Visible = true;

                                }


                                if (screen == "goodstransferstore")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    goodstransferstore.Visible = true;

                                }
                                if (screen == "LedgerReportNEW")
                                {
                                    Reports.Visible = true;
                                    AccountsReport.Visible = true;
                                    LedgerReportNEW.Visible = true;
                                }
                                if (screen == "DaybookNEW")
                                {
                                    Reports.Visible = true;
                                    AccountsReport.Visible = true;
                                    DaybookNEW.Visible = true;
                                }
                                if (screen == "CashAccount")
                                {
                                    Reports.Visible = true;
                                    AccountsReport.Visible = true;
                                    CashAccount.Visible = true;
                                }
                                if (screen == "BankStatementReport")
                                {
                                    Reports.Visible = true;
                                    AccountsReport.Visible = true;
                                    BankStatementReport.Visible = true;
                                }
                                if (screen == "TrialBalance")
                                {
                                    Reports.Visible = true;
                                    AccountsReport.Visible = true;
                                    TrialBalance.Visible = true;
                                }

                                if (screen == "transferreportsstore")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    transferreportsstore.Visible = true;

                                }

                                if (screen == "dispatchreport")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    dispatchreport.Visible = true;

                                }


                                if (screen == "ReturnedItems")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    ReturnedItems.Visible = true;

                                }
                                if (screen == "TransferReports")
                                {
                                    Reports.Visible = true;
                                    ProductionReport.Visible = true;
                                    TransferReports.Visible = true;

                                }



                                if (screen == "supplieroutstandingstore")
                                {
                                    Reports.Visible = true;
                                    supplierhead.Visible = true;
                                    supplieroutstandingstore.Visible = true;

                                }
                                if (screen == "SupplierPaymentReport")
                                {
                                    Reports.Visible = true;
                                    supplierhead.Visible = true;
                                    SupplierPaymentReport.Visible = true;

                                }
                                if (screen == "SupplierOutStanding")
                                {
                                    Reports.Visible = true;
                                    supplierhead.Visible = true;
                                    SupplierOutStanding.Visible = true;

                                }

                                /////////////////////////////////////////////
                                if (screen == "ChartReport")
                                {

                                    ChartReport.Visible = true;


                                }
                                if (screen == "AnalysisReport")
                                {
                                    Reports.Visible = true;
                                    //  ChartReport.Visible = true;
                                    AnalysisReport.Visible = true;

                                }
                                if (screen == "TodaysSalesStockReturn")
                                {
                                    Reports.Visible = true;
                                    // ChartReport.Visible = true;
                                    TodaysSalesStockReturn.Visible = true;

                                }
                                if (screen == "OverAllSales")
                                {
                                    Reports.Visible = true;
                                    // ChartReport.Visible = true;
                                    OverAllSales.Visible = true;

                                }
                                /////////////////////////////////////////////////

                                if (screen == "CustomerReport")
                                {
                                    Reports.Visible = true;
                                    OtherReport.Visible = true;
                                    CustomerReport.Visible = true;

                                }
                                if (screen == "GroupReport")
                                {
                                    Reports.Visible = true;
                                    OtherReport.Visible = true;
                                    GroupReport.Visible = true;

                                }
                                if (screen == "ItemReport")
                                {
                                    Reports.Visible = true;
                                    OtherReport.Visible = true;
                                    ItemReport.Visible = true;

                                }
                                if (screen == "SendMessage")
                                {
                                    Reports.Visible = true;
                                    OtherReport.Visible = true;
                                    SendMessage.Visible = true;

                                }

                                if (screen == "pursum")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    pursum.Visible = true;

                                }

                                if (screen == "purexp")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    purexp.Visible = true;

                                }
                                if (screen == "minstorealert")
                                {
                                    Reports.Visible = true;
                                    RawPurchaseReport.Visible = true;
                                    minstorealert.Visible = true;

                                }

                                if (screen == "dayclose")
                                {
                                    dayclose.Visible = true;


                                }
                                if (screen == "storedayclose")
                                {
                                    storedayclose.Visible = true;
                                }
                                if (screen == "chnagepassword")
                                {
                                    chnagepassword.Visible = true;
                                }

                                #endregion
                            }
                        }
                        else
                        {
                            #region SYNC
                            if (screen == "Synchronization")
                            {
                                Synchronization.Visible = true;
                            }
                            if (screen == "onlineorderentry")
                            {
                                onlineorderentry.Visible = true;
                            }
                            if (screen == "onlineentryreport")
                            {
                                onlineentryreport.Visible = true;
                            }

                            if (screen == "PurchaseReqDeptGrid")
                            {
                                PurchaseReqDeptGrid.Visible = true;
                            }

                            if (screen == "BillInvoiceDeptGrid")
                            {
                                BillInvoiceDeptGrid.Visible = true;
                            }

                            if (screen == "storetallyinvoice")
                            {
                                storetallyinvoice.Visible = true;
                            }
                            #endregion
                            #region INVOICe/UPLOAd
                            if (screen == "tallyinvoice")
                            {
                                tallyinvoice.Visible = true;
                            }
                            if (screen == "storebillupload")
                            {
                                storebillupload.Visible = true;
                            }

                            #endregion

                            #region Semi Process
                            if (screen == "semicategory")
                            {
                                semiprodmenu.Visible = true;
                                semimaster.Visible = true;
                                semicategory.Visible = true;
                            }

                            if (screen == "SemiItemMaster")
                            {
                                semiprodmenu.Visible = true;
                                semimaster.Visible = true;
                                SemiItemMaster.Visible = true;
                            }

                            if (screen == "PrimaryUOMmaster")
                            {
                                semiprodmenu.Visible = true;
                                semimaster.Visible = true;
                                PrimaryUOMmaster.Visible = true;
                            }

                            // Request Menu

                            if (screen == "semistockadd")
                            {
                                semiprodmenu.Visible = true;
                                semirequestMenu.Visible = true;
                                semistockadd.Visible = true;
                            }

                            if (screen == "semirequest")
                            {
                                semiprodmenu.Visible = true;
                                semirequestMenu.Visible = true;
                                semirequest.Visible = true;
                            }
                            if (screen == "semiaccept")
                            {
                                semiprodmenu.Visible = true;
                                semirequestMenu.Visible = true;
                                semiaccept.Visible = true;
                            }
                            if (screen == "Semireceive")
                            {
                                semiprodmenu.Visible = true;
                                semirequestMenu.Visible = true;
                                Semireceive.Visible = true;
                            }


                            #endregion

                            #region Master
                            if (screen == "STSIS")
                            {
                                MasterMenu.Visible = true;
                                STSIS.Visible = true;
                            }
                            if (screen == "combo")
                            {
                                MasterMenu.Visible = true;
                                combo.Visible = true;
                            }
                            if (screen == "UOM")
                            {
                                MasterMenu.Visible = true;
                                UOM.Visible = true;
                            }
                            if (screen == "vehiclemaster")
                            {
                                MasterMenu.Visible = true;
                                vehiclemaster.Visible = true;
                            }

                            if (screen == "TAX")
                            {
                                MasterMenu.Visible = true;
                                TAX.Visible = true;
                            }
                            if (screen == "Ratesettingmaster")
                            {
                                MasterMenu.Visible = true;
                                Ratesettingmaster.Visible = true;
                            }

                            if (screen == "IBSM")
                            {
                                MasterMenu.Visible = true;
                                IBSM.Visible = true;
                            }
                            if (screen == "IPS")
                            {
                                MasterMenu.Visible = true;
                                IPS.Visible = true;
                            }
                            if (screen == "notificationmsg")
                            {
                                MasterMenu.Visible = true;
                                notificationmsg.Visible = true;
                            }
                            if (screen == "tablemaster")
                            {
                                MasterMenu.Visible = true;
                                tablemaster.Visible = true;
                            }
                            if (screen == "attender")
                            {
                                MasterMenu.Visible = true;
                                attender.Visible = true;
                            }

                            if (screen == "Msetting")
                            {
                                MasterMenu.Visible = true;
                                Msetting.Visible = true;
                            }
                            if (screen == "Category")
                            {
                                MasterMenu.Visible = true;
                                Category.Visible = true;
                            }
                            if (screen == "RequestStockSettings")
                            {
                                MasterMenu.Visible = true;
                                RequestStockSettings.Visible = true;
                            }

                            if (screen == "CategorySettingsMaster")
                            {
                                MasterMenu.Visible = true;
                                CategorySettingsMaster.Visible = true;
                            }
                            if (screen == "subcategory")
                            {
                                MasterMenu.Visible = true;
                                subcategory.Visible = true;
                            }
                            if (screen == "Item")
                            {
                                MasterMenu.Visible = true;
                                Item.Visible = true;
                            }
                            if (screen == "DepartmentSetting")
                            {
                                MasterMenu.Visible = true;
                                DepartmentSetting.Visible = true;
                            }
                            if (screen == "Mbranch")
                            {
                                MasterMenu.Visible = true;
                                Mbranch.Visible = true;
                            }
                            if (screen == "HappyHours")
                            {
                                MasterMenu.Visible = true;
                                HappyHours.Visible = true;
                            }
                            if (screen == "ModelMaster")
                            {
                                MasterMenu.Visible = true;
                                ModelMaster.Visible = true;
                            }
                            if (screen == "combo")
                            {
                                MasterMenu.Visible = true;
                                combo.Visible = true;
                            }
                            if (screen == "itemupdate")
                            {
                                MasterMenu.Visible = true;
                                itemupdate.Visible = true;
                            }

                            if (screen == "saletypemaster")
                            {
                                MasterMenu.Visible = true;
                                saletypemaster.Visible = true;
                            }
                            if (screen == "Ingcategory")
                            {
                                MasterMenu.Visible = true;
                                Ingcategory.Visible = true;
                            }

                            if (screen == "Online")
                            {
                                MasterMenu.Visible = true;
                                Online.Visible = true;
                            }
                            if (screen == "BranchSetting")
                            {
                                MasterMenu.Visible = true;
                                BranchSetting.Visible = true;
                            }
                            if (screen == "Ingridients")
                            {
                                MasterMenu.Visible = true;
                                Ingridients.Visible = true;
                            }
                            if (screen == "CustMast")
                            {
                                MasterMenu.Visible = true;
                                Customer.Visible = true;
                                CustMast.Visible = true;
                            }
                            if (screen == "subcompany")
                            {
                                MasterMenu.Visible = true;
                                subcompany.Visible = true;
                            }

                            if (screen == "currencymaster")
                            {
                                MasterMenu.Visible = true;
                                currencymaster.Visible = true;
                            }
                            if (screen == "DealMast")
                            {
                                MasterMenu.Visible = true;
                                Customer.Visible = true;
                                DealMast.Visible = true;
                            }
                            if (screen == "SupMast")
                            {
                                MasterMenu.Visible = true;
                                Customer.Visible = true;
                                SupMast.Visible = true;
                            }
                            if (screen == "EmpMast")
                            {
                                MasterMenu.Visible = true;
                                Customer.Visible = true;
                                EmpMast.Visible = true;
                            }
                            if (screen == "DisMast")
                            {
                                MasterMenu.Visible = true;
                                Customer.Visible = true;
                                DisMast.Visible = true;
                            }
                            if (screen == "employee")
                            {
                                MasterMenu.Visible = true;
                                employee.Visible = true;
                            }
                            if (screen == "SemiRaw")
                            {
                                MasterMenu.Visible = true;
                                SemiRaw.Visible = true;
                            }
                            if (screen == "Ledger")
                            {
                                MasterMenu.Visible = true;
                                Ledger.Visible = true;
                            }
                            if (screen == "Bank")
                            {
                                MasterMenu.Visible = true;
                                Bank.Visible = true;
                            }
                            if (screen == "Dealer")
                            {
                                MasterMenu.Visible = true;
                                Dealer.Visible = true;
                            }
                            if (screen == "MinimumQty")
                            {
                                MasterMenu.Visible = true;
                                MinimumQty.Visible = true;
                            }
                            if (screen == "ChangeRate")
                            {
                                MasterMenu.Visible = true;
                                ChangeRate.Visible = true;
                            }
                            if (screen == "Waiter")
                            {
                                MasterMenu.Visible = true;
                                Waiter.Visible = true;
                            }
                            #endregion

                            #region UserMenu
                            if (screen == "UserRole")
                            {
                                UserMenu.Visible = true;
                                UserRole.Visible = true;
                            }
                            if (screen == "User")
                            {
                                UserMenu.Visible = true;
                                User.Visible = true;
                            }
                            #endregion

                            #region OrderFormMenu
                            if (screen == "OrderForm")
                            {
                                OrderFormMenu.Visible = true;
                                OrderForm.Visible = true;
                            }
                            if (screen == "TodaysDelivery")
                            {
                                OrderFormMenu.Visible = true;
                                TodaysDelivery.Visible = true;
                            }
                            if (screen == "OrderRights")
                            {
                                // OrderFormMenu.Visible = true;
                                OrderRights.Visible = true;
                            }
                            if (screen == "Cakeordersummary")
                            {
                                // OrderFormMenu.Visible = true;
                                Cakeordersummary.Visible = true;
                            }
                            if (screen == "Cakeorderprocess")
                            {
                                // OrderFormMenu.Visible = true;
                                Cakeorderprocess.Visible = true;
                            }
                            #endregion

                            #region PaymentMenu

                            if (screen == "CustomerSalesReceipts")
                            {
                                CustomerSalesReceipts.Visible = true;
                                Payments.Visible = true;
                            }

                            if (screen == "CusSalesReceipts")
                            {
                                CusSalesReceipts.Visible = true;
                                Payments.Visible = true;
                            }
                            #endregion

                            #region InventoryMenu
                            if (screen == "rawsales")
                            {
                                InventoryMenu.Visible = true;
                                rawsales.Visible = true;
                                PurRtn.Visible = true;
                            }

                            if (screen == "PaymentEntry")
                            {
                                InventoryMenu.Visible = true;
                                PaymentEntry.Visible = true;

                            }
                            if (screen == "SupplierPaymentEntry")
                            {
                                InventoryMenu.Visible = true;
                                SupplierPaymentEntry.Visible = true;

                            }
                            if (screen == "RawPurchase")
                            {
                                InventoryMenu.Visible = true;
                                RawPurchase.Visible = true;
                                PurRtn.Visible = true;
                            }
                            if (screen == "restkotsales")
                            {
                                InventoryMenu.Visible = true;
                                restkotsales.Visible = true;

                            }
                            if (screen == "oprawentry")
                            {
                                InventoryMenu.Visible = true;
                                oprawentry.Visible = true;
                                PurRtn.Visible = true;
                            }
                            if (screen == "Sales")
                            {
                                InventoryMenu.Visible = true;
                                Sales.Visible = true;
                            }
                            if (screen == "KitchenOrders")
                            {
                                InventoryMenu.Visible = true;
                                KitchenOrders.Visible = true;
                            }
                            if (screen == "wholesale")
                            {
                                InventoryMenu.Visible = true;
                                wholesale.Visible = true;
                            }
                            if (screen == "wholesalequotation")
                            {
                                InventoryMenu.Visible = true;
                                wholesalequotation.Visible = true;
                            }
                            if (screen == "wholesaleReturn")
                            {
                                InventoryMenu.Visible = true;
                                wholesaleReturn.Visible = true;
                            }

                            if (screen == "PO")
                            {
                                InventoryMenu.Visible = true;
                                PO.Visible = true;
                            }


                            if (screen == "StockReturn")
                            {
                                InventoryMenu.Visible = true;
                                StockReturn.Visible = true;
                            }
                            if (screen == "StockReturnReasonChange")
                            {
                                InventoryMenu.Visible = true;
                                StockReturnReasonChange.Visible = true;
                            }
                            if (screen == "PaymentEntry")
                            {
                                InventoryMenu.Visible = true;
                                PaymentEntry.Visible = true;
                            }
                            if (screen == "SalesTypeConversion")
                            {
                                InventoryMenu.Visible = true;
                                SalesTypeConversion.Visible = true;
                            }
                            if (screen == "SupplierPaymentEntry")
                            {
                                InventoryMenu.Visible = true;
                                SupplierPaymentEntry.Visible = true;
                            }
                            if (screen == "billset")
                            {
                                // InventoryMenu.Visible = true;
                                billset.Visible = true;
                            }
                            if (screen == "orderset")
                            {
                                // InventoryMenu.Visible = true;
                                orderset.Visible = true;
                            }
                            #endregion

                            #region OPSCREEN
                            if (screen == "OPStockMaster1")
                            {
                                OPStockMaster1.Visible = true;
                            }
                            if (screen == "OPExpenseGrid")
                            {
                                OPExpenseGrid.Visible = true;
                            }
                            if (screen == "OPsessionreport")
                            {
                                OPsessionreport.Visible = true;
                            }
                            if (screen == "OPDenomination")
                            {
                                OPDenomination.Visible = true;
                            }
                            #endregion

                            #region RequestAccept

                            if (screen == "ReturnReceiving")
                            {
                                RequestAccept.Visible = true;
                                ReturnReceiving.Visible = true;
                            }

                            if (screen == "StockMaster")
                            {
                                RequestAccept.Visible = true;
                                StockMaster.Visible = true;

                            }

                            if (screen == "IBSR")
                            {
                                RequestAccept.Visible = true;
                                IBSR.Visible = true;

                            }
                            if (screen == "IBSRFB")
                            {
                                RequestAccept.Visible = true;
                                IBSRFB.Visible = true;

                            }
                            if (screen == "IGRG")
                            {
                                RequestAccept.Visible = true;
                                IGRG.Visible = true;

                            }



                            if (screen == "StockRequest")
                            {
                                RequestAccept.Visible = true;
                                StockRequest.Visible = true;
                            }
                            if (screen == "storerequest")
                            {
                                RequestAccept.Visible = true;
                                storerequest.Visible = true;
                            }

                            if (screen == "storestockreceive")
                            {
                                RequestAccept.Visible = true;
                                storestockreceive.Visible = true;
                            }

                            if (screen == "directstorestock")
                            {
                                RequestAccept.Visible = true;
                                directstorestock.Visible = true;
                            }

                            if (screen == "storegoodsreceived")
                            {
                                RequestAccept.Visible = true;
                                storegoodsreceived.Visible = true;
                            }


                            if (screen == "GoodsReceived")
                            {
                                RequestAccept.Visible = true;
                                GoodsReceived.Visible = true;
                            }
                            if (screen == "StockReceive")
                            {
                                RequestAccept.Visible = true;
                                StockReceive.Visible = true;
                            }

                            if (screen == "DirectStockReceive")
                            {
                                RequestAccept.Visible = true;
                                DirectStockReceive.Visible = true;
                            }
                            if (screen == "GRNPM")
                            {
                                RequestAccept.Visible = true;
                                GRNPM.Visible = true;
                            }
                            if (screen == "RequestRawItem")
                            {
                                RequestAccept.Visible = true;
                                RequestRawItem.Visible = true;
                            }
                            if (screen == "demandstoreitem")
                            {
                                RequestAccept.Visible = true;
                                demandstoreitem.Visible = true;
                            }

                            if (screen == "AcceptRawItem")
                            {
                                RequestAccept.Visible = true;
                                AcceptRawItem.Visible = true;
                            }
                            if (screen == "ReceiveRawItem")
                            {
                                RequestAccept.Visible = true;
                                ReceiveRawItem.Visible = true;
                            }
                            if (screen == "ReceiveProductionStock")
                            {
                                RequestAccept.Visible = true;
                                ReceiveProductionStock.Visible = true;
                            }
                            if (screen == "ReturnReceiving")
                            {
                                RequestAccept.Visible = true;
                                ReturnReceiving.Visible = true;
                            }
                            if (screen == "IcingRequest")
                            {
                                RequestAccept.Visible = true;
                                IcingRequest.Visible = true;
                            }
                            if (screen == "IcingReceive")
                            {
                                RequestAccept.Visible = true;
                                IcingReceive.Visible = true;
                            }


                            if (screen == "IPSR")
                            {
                                RequestAccept.Visible = true;
                                IPSR.Visible = true;
                            }
                            if (screen == "IPSRFP")
                            {
                                RequestAccept.Visible = true;
                                IPSRFP.Visible = true;
                            }
                            if (screen == "IPGRG")
                            {
                                RequestAccept.Visible = true;
                                IPGRG.Visible = true;
                            }
                            if (screen == "DISENT")
                            {
                                RequestAccept.Visible = true;
                                DISENT.Visible = true;
                            }

                            if (screen == "ISSR")
                            {
                                RequestAccept.Visible = true;
                                ISSR.Visible = true;
                            }
                            if (screen == "ISSRFS")
                            {
                                RequestAccept.Visible = true;
                                ISSRFS.Visible = true;
                            }
                            if (screen == "ISGRG")
                            {
                                RequestAccept.Visible = true;
                                ISGRG.Visible = true;
                            }


                            #endregion

                            #region Reports

                            if (screen == "GeneralReports")
                            {
                                GeneralReports.Visible = true;
                            }
                            if (screen == "ReturnReceivingReport")
                            {
                                ReturnReceivingReport.Visible = true;
                                StockReport.Visible = true;
                            }
                            if (screen == "SessionClosingReport")
                            {
                                Reports.Visible = true;
                                DayCloseReport.Visible = true;
                                SessionClosingReport.Visible = true;
                            }
                            if (screen == "SalesSummaryReport")
                            {
                                Reports.Visible = true;
                                DayCloseReport.Visible = true;
                                SalesSummaryReport.Visible = true;
                            }
                            if (screen == "dashboard")
                            {
                                dashboard.Visible = true;
                            }
                            //if (screen == "SessionClosingReportDel")
                            //{
                            //    Reports.Visible = true;
                            //    DayCloseReport.Visible = true;
                            //    SessionClosingReportDel.Visible = true;
                            //}
                            if (screen == "InvoiceGenerate")
                            {
                                Reports.Visible = true;
                                DayCloseReport.Visible = true;
                                InvoiceGenerate.Visible = true;
                            }
                            if (screen == "DailyReport")
                            {
                                Reports.Visible = true;
                                DayCloseReport.Visible = true;
                                DailyReport.Visible = true;
                            }
                            if (screen == "DenominationReport")
                            {
                                Reports.Visible = true;
                                DayCloseReport.Visible = true;
                                DenominationReport.Visible = true;
                            }
                            if (screen == "SessioncloseReport")
                            {
                                Reports.Visible = true;
                                DayCloseReport.Visible = true;
                                SessioncloseReport.Visible = true;
                            }
                            ////////////////////////////////////////////////////
                            if (screen == "CustomersCeremonies")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                CustomersCeremonies.Visible = true;
                            }
                            if (screen == "OrderFormRep")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                OrderFormRep.Visible = true;
                            }
                            if (screen == "OrderFormCancel")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                OrderFormCancel.Visible = true;
                            }
                            if (screen == "TodaysOrder")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                TodaysOrder.Visible = true;
                            }
                            if (screen == "TodaysAdvance")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                TodaysAdvance.Visible = true;
                            }
                            if (screen == "OrderBalance")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                OrderBalance.Visible = true;
                            }
                            if (screen == "AddLess")
                            {
                                Reports.Visible = true;
                                OrderFormReport.Visible = true;
                                AddLess.Visible = true;
                            }

                            ////////////////////////////////////////////////
                            if (screen == "StoreStockDetails")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                StoreStockDetails.Visible = true;
                            }
                            if (screen == "storestockdetailedreport")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                storestockdetailedreport.Visible = true;
                            }
                            if (screen == "storepurchasedetailed")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                storepurchasedetailed.Visible = true;
                            }

                            if (screen == "KitchenUsageReport")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                KitchenUsageReport.Visible = true;
                            }

                            if (screen == "KitchenrawreceivedReport")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                KitchenrawreceivedReport.Visible = true;
                            }
                            if (screen == "PurchaseReport")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                PurchaseReport.Visible = true;
                            }
                            if (screen == "storepurchasedetailed")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                storepurchasedetailed.Visible = true;
                            }

                            if (screen == "KitchenUsageReport")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                KitchenUsageReport.Visible = true;
                            }

                            if (screen == "KitchenrawreceivedReport")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                KitchenrawreceivedReport.Visible = true;
                            }


                            //////////////////////////////////////////////////

                            if (screen == "CustomerSalesRep")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                CustomerSalesRep.Visible = true;
                            }
                            if (screen == "SType")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                SType.Visible = true;
                            }
                            if (screen == "Scredit")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                Scredit.Visible = true;
                            }
                            if (screen == "CustomerSalesKotRep")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                CustomerSalesKotRep.Visible = true;
                            }
                            if (screen == "SalesSummary")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                SalesSummary.Visible = true;
                            }
                            if (screen == "NormalSalesCancelRep")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                NormalSalesCancelRep.Visible = true;
                            }
                            if (screen == "SalesHoursReport")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                SalesHoursReport.Visible = true;
                            }
                            if (screen == "HourlysalesReport")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                HourlysalesReport.Visible = true;
                            }
                            if (screen == "SalesandVat")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                SalesandVat.Visible = true;
                            }
                            if (screen == "SalesRegisterReport")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                SalesRegisterReport.Visible = true;
                            }
                            if (screen == "FullSalesReport")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                FullSalesReport.Visible = true;
                            }
                            if (screen == "SalesRep")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                SalesRep.Visible = true;
                            }
                            if (screen == "TaxWiseOrder")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                TaxWiseOrder.Visible = true;
                            }
                            if (screen == "DayEndReport")
                            {
                                Reports.Visible = true;
                                SalesReport.Visible = true;
                                DayEndReport.Visible = true;
                            }
                            ////////////////////////////////////////////////////
                            if (screen == "Productionrep")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                Productionrep.Visible = true;
                            }
                            if (screen == "Stockrep")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                Stockrep.Visible = true;
                            }
                            if (screen == "GRNReport")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                GRNReport.Visible = true;
                            }
                            if (screen == "GRNPMRPT")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                GRNPMRPT.Visible = true;
                            }
                            if (screen == "FULLGRNReport")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                FULLGRNReport.Visible = true;
                            }
                            if (screen == "SlotGRNReport")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                SlotGRNReport.Visible = true;
                            }
                            if (screen == "StockDeatailedReport")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockDeatailedReport.Visible = true;
                            }
                            if (screen == "StockAuditReport")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockAuditReport.Visible = true;
                            }
                            /////////////////////////////////////////////

                            if (screen == "StockReturnedRep")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockReturned.Visible = true;
                                StockReturnedRep.Visible = true;
                            }
                            if (screen == "ItemsReturnReport")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockReturned.Visible = true;
                                ItemsReturnReport.Visible = true;
                            }
                            if (screen == "StockReturnChart")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockReturned.Visible = true;
                                StockReturnChart.Visible = true;
                            }
                            if (screen == "StockReturnRepo")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockReturned.Visible = true;
                                StockReturnRepo.Visible = true;
                            }
                            //////////////////////////////////////////
                            if (screen == "DailyStockRequestRep")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                DailyStockRequestRep.Visible = true;

                            }
                            if (screen == "IBSRR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                IBSRR.Visible = true;

                            }
                            if (screen == "IBSRECR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                IBSRECR.Visible = true;

                            }

                            if (screen == "IBSTR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                IBSTR.Visible = true;
                            }

                            if (screen == "IPSRR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                IPSRR.Visible = true;

                            }
                            if (screen == "IPRECR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                IPRECR.Visible = true;

                            }
                            if (screen == "IPSTR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                IPSTR.Visible = true;
                            }

                            if (screen == "ISSRR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                ISSRR.Visible = true;

                            }
                            if (screen == "ISRECR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                ISRECR.Visible = true;

                            }
                            if (screen == "ISSTR")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                ISSTR.Visible = true;
                            }

                            if (screen == "DailyStockReceivedRep")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                DailyStockReceivedRep.Visible = true;

                            }

                            if (screen == "StockReturnandGRN")
                            {
                                Reports.Visible = true;
                                StockReport.Visible = true;
                                StockReturnandGRN.Visible = true;

                            }
                            /////////////////////////////////////////////////
                            if (screen == "ProductionStockDetails")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                ProductionStockDetails.Visible = true;

                            }
                            if (screen == "GoodsTransfer")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                GoodsTransfer.Visible = true;

                            }


                            if (screen == "goodstransferstore")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                goodstransferstore.Visible = true;

                            }
                            if (screen == "LedgerReportNEW")
                            {
                                Reports.Visible = true;
                                AccountsReport.Visible = true;
                                LedgerReportNEW.Visible = true;
                            }
                            if (screen == "DaybookNEW")
                            {
                                Reports.Visible = true;
                                AccountsReport.Visible = true;
                                DaybookNEW.Visible = true;
                            }
                            if (screen == "CashAccount")
                            {
                                Reports.Visible = true;
                                AccountsReport.Visible = true;
                                CashAccount.Visible = true;
                            }
                            if (screen == "BankStatementReport")
                            {
                                Reports.Visible = true;
                                AccountsReport.Visible = true;
                                BankStatementReport.Visible = true;
                            }
                            if (screen == "TrialBalance")
                            {
                                Reports.Visible = true;
                                AccountsReport.Visible = true;
                                TrialBalance.Visible = true;
                            }


                            if (screen == "transferreportsstore")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                transferreportsstore.Visible = true;

                            }

                            if (screen == "dispatchreport")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                dispatchreport.Visible = true;

                            }


                            if (screen == "ReturnedItems")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                ReturnedItems.Visible = true;

                            }
                            if (screen == "TransferReports")
                            {
                                Reports.Visible = true;
                                ProductionReport.Visible = true;
                                TransferReports.Visible = true;

                            }


                            if (screen == "supplieroutstandingstore")
                            {
                                Reports.Visible = true;
                                supplierhead.Visible = true;
                                supplieroutstandingstore.Visible = true;

                            }
                            if (screen == "SupplierPaymentReport")
                            {
                                Reports.Visible = true;
                                supplierhead.Visible = true;
                                SupplierPaymentReport.Visible = true;

                            }
                            if (screen == "SupplierOutStanding")
                            {
                                Reports.Visible = true;
                                supplierhead.Visible = true;
                                SupplierOutStanding.Visible = true;

                            }





                            /////////////////////////////////////////////
                            if (screen == "ChartReport")
                            {

                                ChartReport.Visible = true;


                            }
                            if (screen == "AnalysisReport")
                            {
                                Reports.Visible = true;
                                //  ChartReport.Visible = true;
                                AnalysisReport.Visible = true;

                            }
                            if (screen == "TodaysSalesStockReturn")
                            {
                                Reports.Visible = true;
                                // ChartReport.Visible = true;
                                TodaysSalesStockReturn.Visible = true;

                            }
                            if (screen == "OverAllSales")
                            {
                                Reports.Visible = true;
                                // ChartReport.Visible = true;
                                OverAllSales.Visible = true;

                            }
                            /////////////////////////////////////////////////

                            if (screen == "CustomerReport")
                            {
                                Reports.Visible = true;
                                OtherReport.Visible = true;
                                CustomerReport.Visible = true;

                            }
                            if (screen == "GroupReport")
                            {
                                Reports.Visible = true;
                                OtherReport.Visible = true;
                                GroupReport.Visible = true;

                            }
                            if (screen == "ItemReport")
                            {
                                Reports.Visible = true;
                                OtherReport.Visible = true;
                                ItemReport.Visible = true;

                            }
                            if (screen == "SendMessage")
                            {
                                Reports.Visible = true;
                                OtherReport.Visible = true;
                                SendMessage.Visible = true;

                            }

                            if (screen == "pursum")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                pursum.Visible = true;

                            }

                            if (screen == "purexp")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                purexp.Visible = true;

                            }
                            if (screen == "minstorealert")
                            {
                                Reports.Visible = true;
                                RawPurchaseReport.Visible = true;
                                minstorealert.Visible = true;

                            }

                            if (screen == "dayclose")
                            {
                                dayclose.Visible = true;


                            }
                            if (screen == "storedayclose")
                            {
                                storedayclose.Visible = true;
                            }
                            if (screen == "chnagepassword")
                            {
                                chnagepassword.Visible = true;
                            }

                            #endregion
                        }
                    }
                }

                if (sUserChk == "1")
                { 
                        Mbranch.Visible = true;
               
                }

                else if (sUserChk == "2")
                {

                }
                else
                {
                    DataSet checkdayclose = objbs.checkinser_Previousday(sTableName);
                    if (checkdayclose.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Make Sure Your Stock day Close and You Redirect To Stock Day Close Page.Thank You!!!!.');window.location ='DaycloseStock.aspx';", true);
                    }


                }

                if (logintypeid == "4")
                {
                    DataSet checkdayclose = objbs.StoreDayPreviousdayCheckInser(sTableName);
                    if (checkdayclose.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Make Sure Your Store day Close.');window.location ='DaycloseStockStore.aspx';", true);
                    }
                    string msg1;

                    DataSet getpendingbills = objbs.getnotoficationshow(sTableName);
                    if (getpendingbills.Tables[0].Rows.Count > 0)
                    {
                        string head1 = "Purchase Pending Bill Occur:";
                        msg1 = head1;
                        for (int i = 0; i < getpendingbills.Tables[0].Rows.Count; i++)
                        {

                            string dc_NO = getpendingbills.Tables[0].Rows[i]["invoiceno"].ToString();
                            string date = Convert.ToDateTime(getpendingbills.Tables[0].Rows[i]["uploadDate"]).ToString("dd/MM/yyyy");
                            string DueDays = getpendingbills.Tables[0].Rows[i]["ledgername"].ToString();
                            msg1 += "<tr><td> Invoice.No :" + dc_NO + ", Invoice Date:" + date + ", Supplier Name: " + DueDays + "." + "</br> </td></td>";
                        }
                        string text2 = msg1;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Information", "<script>SHOWNOTI('" + msg1 + "','" + head1 + "')</script>", false);
                    }
                    else
                    {

                    }



                }
                if (logintypeid == "7")
                {
                    //DataSet checkdayclose = objbs.StoreDayPreviousdayCheckInser(sTableName);
                    //if (checkdayclose.Tables[0].Rows.Count > 0)
                    //{
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Make Sure Your Store day Close.');window.location ='DaycloseStockStore.aspx';", true);
                    //}
                    DateTime sFrom = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //  DateTime sTo = DateTime.ParseExact(txttodate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    string msg;
                    DataSet ds = objbs.getSupplierOutStanding_report("2", sTableName, "All", sFrom);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string head1 = "Purchase Payment Pending Bills Occur:";
                        msg = head1;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            string dc_NO = ds.Tables[0].Rows[i]["DCNo"].ToString();
                            string date = Convert.ToDateTime(ds.Tables[0].Rows[i]["BillDate"]).ToString("dd/MM/yyyy");
                            string DueDays = ds.Tables[0].Rows[i]["DateDiff"].ToString();
                            msg += "<tr><td> DC .No :" + dc_NO + ", DC Date:" + date + ", Due Days: " + DueDays + "." + "</br> </td></td>";
                        }
                        string text2 = msg;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Information", "<script>SHOWNOTI('" + msg + "','" + head1 + "')</script>", false);
                    }
                    else
                    {

                    }
                }
            }

            if (IsmasterLock == "Y")
            {
                MasterMenu.Visible = false;
                menusync.Visible = true;
            }
            else
            {
                menusync.Visible = false;
            }
        }

        protected void Event(object sender, EventArgs e)
        {

            Response.Redirect("../Accountsbootstrap/Login.aspx");

        }

    }
}