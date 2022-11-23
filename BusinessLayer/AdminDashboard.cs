using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;
namespace BusinessLayer
{
   public class AdminDashboard
    {
          #region User Defined Objects
        DBAccess dbObj = null;
        #endregion

        #region Constructors
        public AdminDashboard()
        {
            dbObj = new DBAccess();
        }
        #endregion
        #region Customers
        public DataSet totalCustomers(string tbl,int User)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select count(customerid) as totalCustomers from tblcustomer ";
            }
            else
            {
                sQry = "	select sum (c) as Customers from ( select count( distinct customerid ) as c from tblsales_"+tbl+" where  customerid<>343  union all select count( distinct customerid ) as c 	from tblorder_"+tbl+" where  customerid<>343 ) as a";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet TodaysCustomers(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select  sum(NewCust) as NewCust from   (select count( distinct(customerid)) as NewCust from tblorder_co1 where convert(date,OrderDate)=convert(date,getdate()) union all select count( distinct(customerid)) as NewCust from tblorder_co2 where convert(date,OrderDate)=convert(date,getdate()) union all select count( distinct(customerid)) as NewCust from tblorder_co3 where convert(date,OrderDate)=convert(date,getdate()) union all select count( distinct(customerid)) as NewCust from tblorder_co4 where convert(date,OrderDate)=convert(date,getdate())) as A"; 
            }
            else
            {
                sQry = "	select sum (c) as Customers from ( select count( distinct customerid ) as c from tblsales_" + tbl + " where  customerid<>343 	and convert(date,billdate)=convert(date,getdate()) union all select count( distinct customerid ) as c 	from tblorder_" + tbl + " where  customerid<>343 and convert(date,orderdate)=convert(date,getdate())) as a";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        #endregion

        #region NormalBills
        public DataSet TotalsalesCount(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select sum(TotalBills) as TotalBills from (select count(*) as TotalBills from tblsales_co1  union all select count(*) as TotalBills from tblsales_co2 union all select count(*) as TotalBills from tblsales_co3  union all select count(*) as TotalBills from tblsales_co4) as a";
            }
            else
            {
                sQry = "select count(*) as TotalBills from tblsales_"+tbl+" ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet TodaysalesCount(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select sum(TotalBills) as TotalBills from (select count(*) as TotalBills from tblsales_co1 where  convert(date,BillDate)=convert(date,getdate()) union all select count(*) as TotalBills from tblsales_co2 where  convert(date,BillDate)=convert(date,getdate()) union all select count(*) as TotalBills from tblsales_co3 where  convert(date,BillDate)=convert(date,getdate()) union all select count(*) as TotalBills from tblsales_co4 where  convert(date,BillDate)=convert(date,getdate())) as a";
            }
            else
            {
                sQry = "select count(*) as TotalBills from tblsales_" + tbl + " where convert(date,BillDate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        
        #endregion

        #region CakeOrders
        public DataSet TotalCakeOrders(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = " select sum(TotalCakeOrders) as TotalCakeOrders from(select count(*) as TotalCakeOrders from tblorder_co1 union all select count(*) as TotalCakeOrders from tblorder_co2 union all select count(*) as TotalCakeOrders from tblorder_co3 union all select count(*) as TotalCakeOrders from tblorder_co4) as a";
            }
            else
            {
                sQry = "select count(*) as TotalCakeOrders from tblorder_" + tbl + "";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet TodayCakeOrders(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select sum(TotalCakeOrders) as TotalCakeOrders from(select count(*) as TotalCakeOrders from tblorder_co1 where convert(date,orderdate)=convert(date,getdate())) as a";
            }
            else
            {
                sQry = "select count(*) as TotalCakeOrders from tblorder_" + tbl + " where convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        #endregion

        #region Stock Value
        public DataSet StockValue(int UserID ,string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select sum (total) as total from (select sum(a.available_qty*b.rate) as total from tblstock_CO1 a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0  union all select sum(a.available_qty*b.rate) as total from tblstock_CO2 a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 union all select sum(a.available_qty*b.rate) as total from tblstock_CO3 a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0  union all select sum(a.available_qty*b.rate) as total from tblstock_CO4 a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 ) as a";
            }
            else
            {
                sQry = "select sum(a.available_qty*b.rate) as total from tblstock_"+tbl+" a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet StockwateValue(int UserID, string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
               // sQry = "select sum (total) as total from (select sum(a.available_qty*b.rate) as total from tblstock a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 and a.userId=5 union all select sum(a.available_qty*b.rate) as total from tblstock a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 and a.userId=5 union all select sum(a.available_qty*b.rate) as total from tblstock a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 and a.userId=7 union all select sum(a.available_qty*b.rate) as total from tblstock a,tblcategoryuser b where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 and a.userId=11) as a";
            }
            else
            {
                sQry = "	select sum(Total) as Total from tblReturn_"+tbl+" 	where CONVERT(date, RetDate ) =convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        #endregion

        #region cancelled
        public DataSet CanceledBill( string tbl)
        {
            string sQry = "";
            string Today="";
            DataSet dCust = new DataSet();
            //DataSet dCust1 = new DataSet();
            if (tbl == "admin")
            {
                sQry = "select count(*) as Cancel from tblsales_" + tbl + " where cancelstatus='yes'";
               // Today = "";
            }
            else
            {
                sQry = "select count(*) as Cancel from tblsales_"+tbl+" where cancelstatus='yes'";
              //  Today = " select count(*) as Cancel from tblsales_" + tbl + " where cancelstatus='yes' and convert(date,Billdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);


            
            return dCust;
        }

        public DataSet CanceledBillToday(string tbl)
        {
            
          string Today = "";
            DataSet dCust = new DataSet();
           
            if (tbl == "admin")
            {
               
                Today = "";
            }
            else
            {
            
                Today = " select count(*) as Cancel from tblsales_" + tbl + " where cancelstatus='yes' and convert(date,Billdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(Today);



            return dCust;
        }

        public DataSet CanceledOrder( string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";
            }
            else
            {
                sQry = "select count(*) as OrderCancel from tblorder_"+tbl+" where iscancel=1";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet CanceledOrderToday(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";
            }
            else
            {
                sQry = "select count(*) as OrderCancel from tblorder_" + tbl + " where iscancel=1 and convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        #endregion


        #region sales Amount
        public DataSet SalesAmt(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";
            }
            else
            {
                sQry = "select sum(total) as Total from tblsales_"+tbl+" where convert(date,billdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        public DataSet OrderAmt(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";
            }
            else
            {
                sQry = "select sum(Advance) as Total from tblorder_"+tbl+" where convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        public DataSet GoodTransferStatus(string scode)
        {
            DataSet ds = new DataSet();
            string sqry = "";
            if (scode == "KK" || scode == "BY")
            {
                sqry = " select * from tblGoodTransfer where isTransfer=0 and isReceived=0 and  BranchCode='" + scode + "'";
            }
            else if (scode == "NP" || scode == "BB")
            {
                sqry = " select * from tblGoodTransfer2 where isTransfer=0 and isReceived=0 and  BranchCode='" + scode + "'";
            }
            else
            {
                sqry = " select * from tblGoodTransfer3 where isTransfer=0 and isReceived=0 and  BranchCode='" + scode + "'";
            }
            ds = dbObj.InlineExecuteDataSet(sqry);

            return ds;
        }
        public DataSet CountGoodsSent(string tbl,int DC)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";
                return null;
            }
            else if(tbl=="CO1" || tbl=="CO2")
            {
                sQry = "select COUNT(*) as Items from tblTransGoodsTransfer where DC_No="+DC+"";
            }
            else if (tbl == "CO3" || tbl == "CO4")
            {
                sQry = "select COUNT(*) as Items from tblTransGoodsTransfer2 where DC_No=" + DC + "";
            }
            else
            {
                sQry = "select COUNT(*) as Items from tblTransGoodsTransfer3 where DC_No=" + DC + "";

            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
       #endregion

        #region

        public DataSet CanceledBillTodayAmount(string tbl)
        {

            string Today = "";
            DataSet dCust = new DataSet();

            if (tbl == "admin")
            {

                Today = "";
            }
            else
            {

                Today = " select isnull(sum(Total),0) as Cancelamount from tblsales_" + tbl + " where cancelstatus='yes' and convert(date,Billdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(Today);



            return dCust;
        }

        public DataSet CanceledOrderBillToday(string tbl)
        {

            string Today = "";
            DataSet dCust = new DataSet();

            if (tbl == "admin")
            {

                Today = "";
            }
            else
            {

                Today = " select count(*) as Cancel from tblorder_" + tbl + " where isCancel=1 and convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(Today);



            return dCust;
        }

        public DataSet CanceledOrderBillTodayAmount(string tbl)
        {

            string Today = "";
            DataSet dCust = new DataSet();

            if (tbl == "admin")
            {

                Today = "";
            }
            else
            {

                Today = " select isnull(sum(Total),0) as Cancelamount from tblorder_" + tbl + " where isCancel=1 and convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(Today);



            return dCust;
        }

        public DataSet OrderBalanceAmt(string tbl)
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";
            }
            else
            {
                sQry = "select sum(BalancePaid) as TotalBalance from tblorder_" + tbl + " where convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet TotalBillToday(string tbl)
        {

            string Today = "";
            DataSet dCust = new DataSet();

            if (tbl == "admin")
            {

                Today = "";
            }
            else
            {

                Today = " select count(*) as Cancel from tblsales_" + tbl + " where cancelstatus='No' and convert(date,Billdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(Today);



            return dCust;
        }

        public DataSet TotalOrderBillToday(string tbl)
        {

            string Today = "";
            DataSet dCust = new DataSet();

            if (tbl == "admin")
            {

                Today = "";
            }
            else
            {

                Today = " select count(*) as Cancel from tblorder_" + tbl + " where isCancel=0 and convert(date,orderdate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(Today);



            return dCust;
        }
        public DataSet CanceledOrderBill(string tbl)
        {
            string sQry = "";
            string Today = "";
            DataSet dCust = new DataSet();
            //DataSet dCust1 = new DataSet();
            if (tbl == "admin")
            {
                sQry = "";

            }
            else
            {
                sQry = "select count(*) as Cancel from tblorder_" + tbl + " where isCancel=0";

            }
            dCust = dbObj.InlineExecuteDataSet(sQry);



            return dCust;
        }
        #endregion
        #region Kitchen
        public DataSet TodayItemPurchase()
        {
            string sQry = "";
            DataSet dCust = new DataSet();
            
            {
                sQry = "select COUNT(*) as [Today Purchased ingredients] from tbltranskitchenPurchase a,tblkitchenPurchase b where a.PurchaseID=b.purchaseID and CONVERT(date,b.EntryDate)=CONVERT(date,getdate()) ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        public DataSet PurchaseValue()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select Total as Total  from tbltranskitchenPurchase a,tblkitchenPurchase b where a.PurchaseID=b.purchaseID and CONVERT(date,b.EntryDate)=CONVERT(date,getdate()) ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet usedWaste()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select SUM(Used) as Used,SUM(Wastage) as waste from tbldailyProduction where CONVERT(date,Date)=CONVERT(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet ProdStockVlaue()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select Rate*Prod_Qty as Value from tblCategoryUser a,tblTransProductionStock b where a.CategoryID=b.CategoryId and a.CategoryUserID=b.DescriptionId";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet Adminsalesgrid()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select distinct 'KK nagar' as Branch, (select sum(Advance)as Advance from tblorder_co1 where iscancel=0and convert(date,orderdate)=convert(date,getdate()))OrderAmt,(select sum(total)as Total from tblsales_co1 where cancelstatus='no' and convert(date,billdate)=convert(date,getdate()))Counter from tblsales_co1,tblorder_co1 union all select distinct 'Byepass' as Branch, (select sum(Advance)as Advance from tblorder_co2 where iscancel=0and convert(date,orderdate)=convert(date,getdate()))OrderAmt,(select sum(total)as Total from tblsales_co2 where cancelstatus='no' and convert(date,billdate)=convert(date,getdate()))Counter from tblsales_co1,tblorder_co1 union all select distinct 'BB Kulam' as Branch, (select sum(Advance)as Advance from tblorder_co3 where iscancel=0and convert(date,orderdate)=convert(date,getdate()))OrderAmt,(select sum(total)as Total from tblsales_co3 where cancelstatus='no' and convert(date,billdate)=convert(date,getdate()))Counter from tblsales_co1,tblorder_co1 union all select distinct 'Narayanapuram' as Branch, (select sum(Advance)as Advance from tblorder_co4 where iscancel=0and convert(date,orderdate)=convert(date,getdate()))OrderAmt,(select sum(total)as Total from tblsales_co4 where cancelstatus='no' and convert(date,billdate)=convert(date,getdate()))Counter from tblsales_co1,tblorder_co1 union all select distinct 'Nellai' as Branch, (select sum(Advance)as Advance from tblorder_co5 where iscancel=0and convert(date,orderdate)=convert(date,getdate()))OrderAmt,(select sum(total)as Total from tblsales_co5 where cancelstatus='no' and convert(date,billdate)=convert(date,getdate()))Counter from tblsales_co1,tblorder_co1  ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet Adminscancelgrid()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = " select  distinct 'Kk Nagar' as Branch, (select count(*) from tblsales_co1 where  convert(date,BillDate)=convert(date,getdate()) and cancelstatus='yes') CounterBills, (select count(*) from tblorder_co1 where  convert(date,orderdate)=convert(date,getdate())and iscancel=1) OrderForm from tblsales_co1,tblorder_co1 union all  select  distinct 'ByePass' as Branch, (select count(*) from tblsales_co2 where  convert(date,BillDate)=convert(date,getdate())and cancelstatus='yes') CounterBills, (select count(*) from tblorder_co2 where  convert(date,orderdate)=convert(date,getdate())and iscancel=1) OrderForm from tblsales_co1,tblorder_co1 union all        select  distinct 'BB Kulam' as Branch, (select count(*) from tblsales_co3 where  convert(date,BillDate)=convert(date,getdate())and cancelstatus='yes') CounterBills, (select count(*) from tblorder_co3 where  convert(date,orderdate)=convert(date,getdate())and iscancel=1) OrderForm from tblsales_co1,tblorder_co1 union all          select  distinct 'Narayanapuram' as Branch, (select count(*) from tblsales_co4 where  convert(date,BillDate)=convert(date,getdate())and cancelstatus='yes') CounterBills, (select count(*) from tblorder_co4 where  convert(date,orderdate)=convert(date,getdate())and iscancel=1) OrderForm from tblsales_co1,tblorder_co1 union all            select  distinct 'Nellai' as Branch, (select count(*) from tblsales_co5 where  convert(date,BillDate)=convert(date,getdate())and cancelstatus='yes') CounterBills, (select count(*) from tblorder_co5 where  convert(date,orderdate)=convert(date,getdate()) and iscancel=1) OrderForm from tblsales_co1,tblorder_co1";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        public DataSet Adminordergrid()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select 'KK Nagar' as Store,sum(Advance)as Advance from tblorder_co1 where iscancel=0and convert(date,orderdate)=convert(date,getdate()) union all select  'Byepass' as Store,sum(Advance)as Advance  from tblorder_co2 where iscancel=0and convert(date,orderdate)=convert(date,getdate()) union all select  'BB Kulam' as Store,sum(Advance)as Advance  from tblorder_co3 where iscancel=0and convert(date,orderdate)=convert(date,getdate()) union all select  'Narayanapuram' as Store,sum(Advance)as Advance  from tblorder_co4 where iscancel=0and convert(date,orderdate)=convert(date,getdate()) union all select  'Nellai' as Store,sum(Advance)as Advance  from tblorder_co5 where iscancel=0and convert(date,orderdate)=convert(date,getdate()) ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet AdminBillCountgrid()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "  select  distinct 'Kk Nagar' as Branch, (select count(*) from tblsales_co1 where  convert(date,BillDate)=convert(date,getdate())) CounterBills, (select count(*) from tblorder_co1 where  convert(date,orderdate)=convert(date,getdate())) OrderForm from tblsales_co1,tblorder_co1 union all     select  distinct 'ByePass' as Branch, (select count(*) from tblsales_co2 where  convert(date,BillDate)=convert(date,getdate())) CounterBills, (select count(*) from tblorder_co2 where  convert(date,orderdate)=convert(date,getdate())) OrderForm from tblsales_co1,tblorder_co1 union all       select  distinct 'BB Kulam' as Branch, (select count(*) from tblsales_co3 where  convert(date,BillDate)=convert(date,getdate())) CounterBills, (select count(*) from tblorder_co3 where  convert(date,orderdate)=convert(date,getdate())) OrderForm from tblsales_co1,tblorder_co1 union all         select  distinct 'Narayanapuram' as Branch, (select count(*) from tblsales_co4 where  convert(date,BillDate)=convert(date,getdate())) CounterBills, (select count(*) from tblorder_co4 where  convert(date,orderdate)=convert(date,getdate())) OrderForm from tblsales_co1,tblorder_co1 union all           select  distinct 'Nellai' as Branch, (select count(*) from tblsales_co5 where  convert(date,BillDate)=convert(date,getdate())) CounterBills, (select count(*) from tblorder_co5 where  convert(date,orderdate)=convert(date,getdate())) OrderForm from tblsales_co1,tblorder_co1"; 
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet Adminstockvaluetgrid()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select 'KK Nagar' as Branch, sum(a.available_qty*b.rate) as total from tblstock_CO1 a,tblcategoryuser b  where a.subcategoryid=b.categoryuserid and a.Available_Qty>0  union all select 'Byepass' as Branch, sum(a.available_qty*b.rate) as total from tblstock_CO2 a,tblcategoryuser b  where a.subcategoryid=b.categoryuserid and a.Available_Qty>0 union all select 'BB Kulam' as Branch, sum(a.available_qty*b.rate) as total from tblstock_CO2 a,tblcategoryuser b  where a.subcategoryid=b.categoryuserid and a.Available_Qty>0  union all select 'Narayanapuram' as Branch, sum(a.available_qty*b.rate) as total from tblstock_CO4 a,tblcategoryuser b  where a.subcategoryid=b.categoryuserid and a.Available_Qty>0  select 'Nellai' as Branch, sum(a.available_qty*b.rate) as total from tblstock_CO5 a,tblcategoryuser b  where a.subcategoryid=b.categoryuserid and a.Available_Qty>0  ";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet AdminCustcount()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "  select'KK Nagar' as Branch ,count( distinct(customerid)) as Customers from tblorder_co1 where convert(date,OrderDate)=convert(date,getdate()) union all   select 'Byepass' as Branch ,count( distinct(customerid)) as Customers from tblorder_co2 where convert(date,OrderDate)=convert(date,getdate()) union all   select 'BB kulam' as Branch , count( distinct(customerid)) as Customers from tblorder_co3 where convert(date,OrderDate)=convert(date,getdate()) union all   select 'Narayanapuram' as Branch , count( distinct(customerid)) as Customers from tblorder_co4 where convert(date,OrderDate)=convert(date,getdate()) union all  select 'Nellai' as Branch , count( distinct(customerid)) as Customers from tblorder_co5 where convert(date,OrderDate)=convert(date,getdate())";
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }

        public DataSet AdminDelivery()
        {
            string sQry = "";
            DataSet dCust = new DataSet();

            {
                sQry = "select distinct 'KK Nagar' as Branch, (select distinct count( orderno)   from tblorder_co1 where cast (orderdate as date)=convert(date,getdate()))Booked,(select distinct count( orderno)   from tblorder_co1 where cast (deliverydate as date)=convert(date,getdate()))Delivery from tblorder_co1 union all select distinct 'Byepass' as Branch, (select distinct count( orderno)   from tblorder_co2 where cast (orderdate as date)=convert(date,getdate()))Booked,(select distinct count( orderno)   from tblorder_co2 where cast (deliverydate as date)=convert(date,getdate()))Delivery from tblorder_co2 union all select distinct 'BB Kulam' as Branch, (select distinct count( orderno)   from tblorder_co3 where cast (orderdate as date)=convert(date,getdate()))Booked,(select distinct count( orderno)   from tblorder_co3 where cast (deliverydate as date)=convert(date,getdate()))Delivery from tblorder_co3 union all select distinct 'Narayanapuram' as Branch, (select distinct count( orderno)   from tblorder_co4 where cast (orderdate as date)=convert(date,getdate()))Booked,(select distinct count( orderno)   from tblorder_co4 where cast (deliverydate as date)=convert(date,getdate()))Delivery from tblorder_co4 union all select distinct 'Nellai' as Branch, (select distinct count( orderno)   from tblorder_co5 where cast (orderdate as date)=convert(date,getdate()))Booked,(select distinct count( orderno)   from tblorder_co5 where cast (deliverydate as date)=convert(date,getdate()))Delivery from tblorder_co5 "; 
            }
            dCust = dbObj.InlineExecuteDataSet(sQry);
            return dCust;
        }
        #endregion
    }
}
