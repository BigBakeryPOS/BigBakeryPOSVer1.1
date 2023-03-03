<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Billing.HeaderMaster.Header" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head runat="server">
    <meta charset='utf-8' />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="../Menu/Styles/styles.css" rel="stylesheet" type="text/css" />
    <!-- Custom Fonts -->
    <link href="../Menu/font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <title>POS Billing BigbBiz Solutions</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css">
    <script src="../js/toastrmin.js" type="text/javascript"></script>
    <script src="../js/toastr.js" type="text/javascript"></script>
    <link href="../css/toastr.css" rel="stylesheet" type="text/css" />
    <!-- jQuery -->
    <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showpop1(msg, title) {

            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            $(document).ready(function onDocumentReady() {
                setInterval(function doThisEveryTwoSeconds() {
                    //        toastr.success("Hello World!");
                    toastr.warning(msg, title);
                }, 5000);   // 2000 is 2 seconds  
            });
            return false;
        }
    </script>
    <script type="text/javascript">
        function showpop7(msg, title) {

            toastr.options = {
                "closeButton": false,
                "debug": true,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            return false;
        }
    </script>
    <script type="text/javascript">
        function showpop6(msg, title) {

            toastr.options = {
                "closeButton": false,
                "debug": true,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-left",
                "preventDuplicates": false,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.info(msg, title);
            return false;
        }
    </script>
    <script type="text/javascript">
        function SHOWNOTI(msg, title) {

            toastr.options = {
                "closeButton": false,
                "debug": true,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.error(msg, title);
            $(document).ready(function onDocumentReady() {
                setInterval(function doThisEveryTwoSeconds() {
                    //        toastr.success("Hello World!");
                    toastr.error(msg, title);
                }, 2000);   // 2000 is 2 seconds  
            });
            return false;


        }
    </script>
    <script type="text/javascript">
        function NOTIFICA(msg, title) {

            toastr.options = {
                "closeButton": false,
                "debug": true,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": false,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }

            // toastr['success'](msg, title);
            var d = Date();
            toastr.success(msg, title);
            return false;
        }

    </script>
    <style>
        .modal-header, h4, .close {
            color: black !important;
            text-align: center;
            font-size: 30px;
            <%-- background-color: #5cb85c;
            --%>
        }

        .modal-footer {
            background-color: #f9f9f9;
        }
    </style>
    <style>
        marquee {
            background-color: lightblue;
        }
    </style>
    <style>
        .footer {
            position: fixed;
            bottom: 0;
            width: 200px;
            right: 0;
            cursor: Hand;
        }
    </style>
    <style type="text/css">
        blink, .blink {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
    <link href="../css/pos_style.css" rel="stylesheet" />
</head>
<div>
    <%-- <asp:Panel ID="Panel1" runat="server">
        <div id="myModal" class="modal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">
                            Notification Popup</h4>
                    </div>
                    <div  style="text-align: center">
                        <asp:Label ID="lblMessage" runat="server" />
                        <asp:Panel ID="PL_CardSelect" runat="server">
                        <label>Select Freeze Time</label>
                        <select class="form-control" name="cars">
  <option value="5">5</option>
  <option value="10">10</option>
  <option value="15">15</option>
  <option value="30">30</option>
</select>
                            <br />
                            <div id="msg" runat="server" visible="false">
                <marquee direction="scroll"><asp:Label ID="lblmsgtext"  runat="server" ></asp:Label></marquee></div>
                        </asp:Panel>
                    </div>
                    <div class="modal-footer">
                            <input type="submit" runat="server" id="Btn_CardSelection" class="btn btn-primary"  />
                           <blink> <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> </blink>
                    </div>
                </div>
               
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </asp:Panel>--%>
    <%-- Hidden Button for Card Selection --%>
    <%-- <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#myModal">
        Launch demo modal</button>--%>
    <table style="width: 100%; display: none">
        <tr>
            <td style="width: 30%; background-color: #6c7079;">
                <div id="Div1" runat="server" class="container-fluid">
                    <%-- <a href="../Accountsbootstrap/Home_Page.aspx"><img src="../images/logo11.png" alt="logo"/></a>--%>
                    <a href="../Accountsbootstrap/Home_Page.aspx">
                        <img src="../images/BlackForrestRe.png" backcolor="White" alt="logo" style="width: 70px; background: white;" /></a><br />
                    <font size="-5" color="white"><b></b></font>
                </div>
            </td>
            <td style="width: 40%" align="center">
                <label style="font-size: 30px; color: White;">
                    Biz POS Management System</label>
            </td>
            <td style="width: 30%" align="right">
                <div align="right">
                </div>
            </td>
        </tr>
    </table>
</div>
<div id='cssmenu'>
    <ul>
        <marquee direction="right">
            <asp:Label ID="lblmessege" runat="server" ForeColor="White" Font-Bold="false"></asp:Label></marquee>
        <li><a href="../Accountsbootstrap/HomePage.aspx">
            <img src="../images/logo11.png" backcolor="White" alt="logo" style="width: 40px; margin-top: -10px; background: white;" /></a> </li>
        <%-- <li id="LiveDashBoard" runat="server" visible="true"><a href="../Accountsbootstrap/HomePage.aspx">
                <i class="fa fa-home" aria-hidden="true" style="color: White;font-size: 19px;"></i><label>DashBoard</label> 
            </a></li>--%>
        <li id="LiveDashBoard" runat="server" visible="false" style="margin-top: -6px;"><a
            href="../Accountsbootstrap/Homepage.aspx" style="color: White"><i class="fa fa-home"
                aria-hidden="true" style="color: White; font-size: 19px;"></i>Dashboard</a></li>
        <li id="dashboard" runat="server" visible="false"><a href="../Accountsbootstrap/dashchart.aspx"
            style="color: White">New Dash board</a></li>
        <li id="OPStockMaster1" runat="server" visible="false"><a href="../Accountsbootstrap/stockgrid.aspx"
            style="color: White">GRN Master</a></li>
        <li id="OPExpenseGrid" runat="server" visible="false"><a href="../Accountsbootstrap/ExpenseGrid.aspx"
            style="color: White">Expense Entry</a></li>
        <li id="OPsessionreport" runat="server" visible="false"><a href="../Accountsbootstrap/sessionreport.aspx"
            style="color: White">Session Report</a></li>
        <li id="OPDenomination" runat="server" visible="false"><a href="../Accountsbootstrap/Denomination.aspx"
            style="color: White">Denomination</a></li>
        <li id="menusync" runat="server" visible="false"><a href="../Accountsbootstrap/Menusync.aspx">Menu Sync</a></li>
        <li id="MasterMenu" visible="false" class='has-sub' runat="server" style="color: White">
            <a href="javascript:;" style="color: White">Master <b></b></a>
            <ul>
                <li id="notificationmsg" runat="server" visible="false"><a href="../Accountsbootstrap/NotificationPage.aspx">Notification Alert</a></li>
                <li id="tablemaster" runat="server" visible="false"><a href="../Accountsbootstrap/TableMaster.aspx">Table Master</a></li>
                <li id="attender" runat="server" visible="false"><a href="../Accountsbootstrap/AttenderMaster.aspx">Attender Master</a></li>
                <li id="IBSM" runat="server" visible="false"><a href="../Accountsbootstrap/InterBranchSetting.aspx">Intet Branch Setting Master</a></li>
                <li id="IPS" runat="server" visible="false"><a href="../Accountsbootstrap/InterProdSetting.aspx">Intet Prod/Store Setting Master</a></li>
                <li id="STSIS" runat="server" visible="false"><a href="../Accountsbootstrap/StoreItemSetting.aspx">Store To Shop Item Setting Master</a></li>
                <li id="UOM" runat="server" visible="false"><a href="../Accountsbootstrap/Uom.aspx">Uom Master</a></li>
                <li id="vehiclemaster" runat="server" visible="false"><a href="../Accountsbootstrap/VehicleMaster.aspx">Vehicle Master</a></li>
                <li id="TAX" runat="server" visible="false"><a href="../Accountsbootstrap/Tax.aspx">Tax Master</a></li>
                <li id="Category" runat="server" visible="false"><a href="../Accountsbootstrap/categorygrid.aspx">Group Master</a></li>
                <li id="Msetting" runat="server" visible="false"><a href="../Accountsbootstrap/MarginSetting.aspx">Margin Setting</a></li>
                <li id="subcategory" runat="server" visible="false"><a href="../Accountsbootstrap/SubCategory.aspx">Sub Category Master</a></li>
                <li id="Item" runat="server" visible="false"><a href="../Accountsbootstrap/Descriptiongrid.aspx">Item Master</a></li>
                <li id="combo" runat="server" visible="false"><a href="../Accountsbootstrap/ComboGrid.aspx">Combo Master</a></li>
                <li id="itemupdate" runat="server" visible="false"><a href="../Accountsbootstrap/itemupdatescreen.aspx">Quick Item Update</a></li>
                <li id="saletypemaster" runat="server" visible="false"><a href="../Accountsbootstrap/SalesType.aspx">Sales Type Master</a></li>
                <li id="Ingcategory" runat="server" visible="false"><a href="../Accountsbootstrap/ProdCategoryGrid.aspx">Ingridients Category Master</a></li>
                <li id="Online" runat="server" visible="false"><a href="../Accountsbootstrap/OnlineMaster.aspx">Online Master</a></li>
                <li id="BranchSetting" runat="server" visible="false"><a href="../Accountsbootstrap/BranchSetting.aspx">Branch-Production Setting</a></li>
                <li id="Ingridients" runat="server" visible="false"><a href="../Accountsbootstrap/Ingridients.aspx">Ingridients Master</a></li>
                <li id="Customer" runat="server" class='has-sub' visible="false"><a id="A50" runat="server" href="javascript:;">Contact Master</a>
                    <ul>
                        <li id="CustMast" runat="server" visible="false"><a runat="server" href="../Accountsbootstrap/viewcustomer.aspx?id=1">Customer Master</a></li>
                        <li id="DealMast" runat="server" visible="false"><a runat="server" href="../Accountsbootstrap/viewcustomer.aspx?id=2">Dealer Master</a></li>
                        <li id="SupMast" runat="server" visible="false"><a runat="server" href="../Accountsbootstrap/viewcustomer.aspx?id=3">Supplier Master</a></li>
                        <li id="EmpMast" runat="server" visible="false"><a runat="server" href="../Accountsbootstrap/viewcustomer.aspx?id=4">Icing Employee Master</a></li>
                        <li id="DisMast" runat="server" visible="false"><a runat="server" href="../Accountsbootstrap/viewcustomer.aspx?id=5">Dispatch Employee Master</a></li>

                    </ul>
                </li>
                <!-- <li id="Customer1" runat="server" visible="false"><a href="../Accountsbootstrap/viewcustomer.aspx">
                        Contact Master</a></li>-->
                <li id="Bank" runat="server" visible="false"><a href="../Accountsbootstrap/viewbank.aspx">Bank Master</a></li>
                <li id="employee" runat="server" visible="false"><a href="../Accountsbootstrap/EmployeeMaster.aspx">Employee Master</a></li>
                <li id="SemiRaw" runat="server" visible="false"><a href="../Accountsbootstrap/SemiRawSetting.aspx">Recepie Settings</a></li>
                <li id="Ledger" runat="server" visible="false"><a href="../Accountsbootstrap/LedgerMasterGrid.aspx">Ledger Master</a></li>
                <li id="Dealer" visible="false" runat="server"><a href="../Accountsbootstrap/ReceiptReport.aspx">Dealer Creation</a></li>
                <li id="MinimumQty" runat="server" visible="false"><a href="../Accountsbootstrap/MinQty.aspx">Minimum Qty Set </a></li>
                <li id="ChangeRate" visible="false" runat="server"><a href="../Accountsbootstrap/ChangeRate.aspx">Change Rate</a></li>
                <li id="Waiter" runat="server" visible="false"><a href="../Accountsbootstrap/Waiter.aspx">Waiter</a></li>
                <li id="RequestStockSettings" runat="server" visible="false"><a href="../Accountsbootstrap/RequestStockSettings.aspx">Request Stock Settings</a></li>
                <li id="CategorySettingsMaster" runat="server" visible="false"><a href="../Accountsbootstrap/CategorySettingsMaster.aspx">Category Settings Master</a></li>
                <li id="DepartmentSetting" runat="server" visible="false"><a href="../Accountsbootstrap/DepartmentSetting.aspx">Department Setting</a></li>
                <li id="Mbranch" runat="server" visible="false"><a href="../Accountsbootstrap/BranchGrid.aspx">Branch Master</a></li>
                <li id="ModelMaster" runat="server" visible="false"><a href="../Accountsbootstrap/ModelScreen.aspx">Model Master</a></li>
                <li id="HappyHours" runat="server" visible="false"><a href="../Accountsbootstrap/Offer.aspx">Happy Hours Master</a></li>
                <li id="subcompany" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseCompanyDetailsGrid.aspx">Sub Company Master</a></li>
                <li id="currencymaster" runat="server" visible="false"><a href="../Accountsbootstrap/CurrencyMaster.aspx">Currency Master</a></li>
                <li id="Ratesettingmaster" runat="server" visible="false"><a href="../Accountsbootstrap/RateSettingMaster.aspx">Rate Setting Master</a></li>
                



            </ul>
        </li>
        <li id="OrderFormMenu" runat="server" visible="false" class='has-sub'><a id="A10"
            runat="server" style="color: White" href="javascript:;">Order</a>
            <ul>
                <li id="OrderForm" runat="server" visible="false"><a href="../Accountsbootstrap/OrderGrid.aspx">Order Form</a></li>
                <li id="TodaysDelivery" runat="server" visible="false"><a href="../Accountsbootstrap/TodaysDeliveryOrder.aspx">Todays Delivery Orders </a></li>
            </ul>
        </li>
        <li id="InventoryMenu" visible="false" runat="server" class='has-sub'><a href="javascript:;"
            style="color: White">Sales/Inventory <b></b>
            <br />
            <label id="good" runat="server" style="color: ThreeDLighShadow; margin-left: 10px; text-decoration: blink">
            </label>
        </a>
            <ul>
                <li id="rawsales" runat="server" visible="false"><a href="../Accountsbootstrap/sales_grid.aspx">Raw Sales</a></li>
                <li id="PO" runat="server" visible="false"><a href="../Accountsbootstrap/Purchase_OrderGrid.aspx">Purchase Order</a></li>
                <li id="RawPurchase" runat="server" visible="false"><a href="../Accountsbootstrap/Purchase_invGrid.aspx">Raw Purchase</a></li>
                <li id="PurRtn" runat="server" visible="false"><a href="../Accountsbootstrap/Purchase_ReturnGrid.aspx">Purchase Return</a></li>
                <li id="restkotsales" runat="server" visible="false"><a href="../Accountsbootstrap/RestaurantSalesKot.aspx">Kot Sales</a></li>
                <li id="KitchenOrders" runat="server" visible="false"><a href="../Accountsbootstrap/KitchenOrders.aspx">Kitchen Orders</a></li>
                <li id="oprawentry" runat="server" visible="false"><a href="../Accountsbootstrap/PhysicalStockEntry.aspx">Store Opening Stock Entry</a></li>
                <li id="Sales" runat="server" visible="false"><a href="../Accountsbootstrap/SalesGrid.aspx">Sales</a></li>
                <li id="wholesalequotation" runat="server" visible="false"><a href="../Accountsbootstrap/WholeSalesQuotationGrid.aspx">Whole Sales Quotation Entry</a></li>
                <li id="wholesale" runat="server" visible="false"><a href="../Accountsbootstrap/WholeSalesGrid.aspx">Whole Sales Entry</a></li>
                <li id="wholesaleReturn" runat="server" visible="false"><a href="../Accountsbootstrap/WholeSalesReturnGrid.aspx">Whole Sales Return Entry</a></li>
                <li id="StockReturn" runat="server" visible="false"><a href="../Accountsbootstrap/ItemReturngrid.aspx">Stock Return</a></li>
                <li id="StockReturnReasonChange" runat="server" visible="false"><a href="../Accountsbootstrap/ReasonChanaging.aspx">Stock Return Reason Change</a></li>
                <li id="PaymentEntry" runat="server" visible="false"><a href="../Accountsbootstrap/Expensegrid.aspx">Expense Payment Entry </a></li>
                <li id="SalesTypeConversion" runat="server" visible="false"><a href="../Accountsbootstrap/salestypeconversion.aspx">Sales Type Conversion</a></li>
                <li id="SupplierPaymentEntry" runat="server" visible="false"><a href="../Accountsbootstrap/PaymentEntryGrid.aspx">Supplier Payment Entry</a></li>
                <li id="billset" runat="server" visible="false"><a href="../Accountsbootstrap/billsetting.aspx"
                    style="color: White">Bill Settlement</a></li>
                <li id="orderset" runat="server" visible="false"><a href="../Accountsbootstrap/BillSettingForOrder.aspx"
                    style="color: White">Order Settlement</a></li>
            </ul>
        </li>
        <li id="OrderRights" runat="server" visible="false"><a href="../Accountsbootstrap/OrderRightsGrid.aspx">Order Rights</a></li>
        <li id="Cakeordersummary" runat="server" visible="false"><a href="../Accountsbootstrap/orderassign.aspx">Cake Order Assign</a></li>
        <li id="Cakeorderprocess" runat="server" visible="false"><a href="../Accountsbootstrap/orderassign_old.aspx">Cake Order Process Assign</a></li>
        <li id="RequestAccept" visible="false" runat="server" class='has-sub'><a href="javascript:;"
            style="color: White">Stock Entry <b></b>
            <br />
            <label id="Label1" runat="server" style="color: ThreeDLighShadow; margin-left: 10px; text-decoration: blink">
            </label>
        </a>
            <ul>
                <li id="StockMaster" runat="server" visible="false"><a href="../Accountsbootstrap/stockgrid.aspx">GRN Master</a></li>
                <li id="StockRequest" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseRequestGrid.aspx">Daily Stock Request</a> </li>
                <li id="GoodsReceived" runat="server" visible="false"><a href="../Accountsbootstrap/GoodsReceivedGrid.aspx">Goods Received</a> </li>
                <li id="storerequest" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseReqStoreGrid.aspx">Store Stock Request</a> </li>
                <li id="storegoodsreceived" runat="server" visible="false"><a href="../Accountsbootstrap/GoodsReceivedStoreGrid.aspx">Store Goods Received</a> </li>
                <li id="IBSR" runat="server" visible="false"><a href="../Accountsbootstrap/InterBranchStockRequestGrid.aspx">Inter Branch Stock Request</a> </li>
                <li id="IBSRFB" runat="server" visible="false"><a href="../Accountsbootstrap/RequestFromBranchGrid.aspx">Inter Branch Stock Request From Branch</a> </li>
                <li id="IGRG" runat="server" visible="false"><a href="../Accountsbootstrap/InterGoodsReceivedGrid.aspx">Inter Branch Stock Received</a> </li>
                <li id="StockReceive" runat="server" visible="false"><a href="../Accountsbootstrap/OrderFromBranch.aspx"
                    runat="server">Stock request from Branch</a></li>
                <li id="DirectStockReceive" runat="server" visible="false"><a id="A32" href="../Accountsbootstrap/DirectGoodsTransferGrid.aspx"
                    runat="server">Direct Transfer To Branch</a></li>
                <li id="storestockreceive" runat="server" visible="false"><a id="A1" href="../Accountsbootstrap/OrderFromBranchStore.aspx"
                    runat="server">Store Stock request from Branch</a></li>
                <li id="directstorestock" runat="server" visible="false"><a id="A40" href="../Accountsbootstrap/DirectstoreGoodsTransferGrid.aspx"
                    runat="server">Direct Store Stock Transfer To Branch</a></li>
                <li id="GRNPM" runat="server" visible="false"><a href="../Accountsbootstrap/GRNPMgrid.aspx">GRN (+)(-)</a></li>
                <li id="RequestRawItem" runat="server" visible="false"><a href="../Accountsbootstrap/GoodsTransferNewGrid.aspx">Request Raw Item to Store</a></li>
                <li id="demandstoreitem" runat="server" visible="false"><a href="../Accountsbootstrap/DemandReqStoreGrid.aspx">Demand to Store Request</a></li>
                <li id="AcceptRawItem" runat="server" visible="false"><a href="../Accountsbootstrap/StoreRawItemRequestGrid.aspx">Accept/Direct Raw Item Transfer </a></li>
                <li id="ReceiveRawItem" runat="server" visible="false"><a href="../Accountsbootstrap/ReceiveStoreItemGrid.aspx">Receive Raw Item from Store</a></li>
                <li id="ReceiveProductionStock" runat="server" visible="false"><a href="../Accountsbootstrap/ReceiveProductionStockGrid.aspx">Add Production Stock </a></li>
                <li id="ReturnReceiving" runat="server" visible="false"><a href="../Accountsbootstrap/ReturnReceiving.aspx">Return Receiving From Branch </a></li>
                <li id="IcingRequest" runat="server" visible="false"><a href="../Accountsbootstrap/home_page.aspx">Icing Request </a></li>
                <li id="IcingReceive" runat="server" visible="false"><a href="../Accountsbootstrap/home_page.aspx">Icing Received </a></li>
                <li id="IPSR" runat="server" visible="false"><a href="../Accountsbootstrap/InterProdGrid.aspx">Inter Production Stock Request</a> </li>
                <li id="IPSRFP" runat="server" visible="false"><a href="../Accountsbootstrap/RequestFromProdGrid.aspx">Inter Production Stock Request From Production</a> </li>
                <li id="IPGRG" runat="server" visible="false"><a href="../Accountsbootstrap/InterProdGoodsReceivedGrid.aspx">Inter Production Stock Received</a> </li>
                <li id="DISENT" runat="server" visible="false"><a href="../Accountsbootstrap/dispatchentry.aspx">Dispatch Entry</a></li>
                <li id="ISSR" runat="server" visible="false"><a href="../Accountsbootstrap/InterStoreGrid.aspx">Inter Store Stock Request</a> </li>
                <li id="ISSRFS" runat="server" visible="false"><a href="../Accountsbootstrap/RequestFromStoreGrid.aspx">Inter Store Stock Request From Store</a> </li>
                <li id="ISGRG" runat="server" visible="false"><a href="../Accountsbootstrap/InterstoreGoodsReceivedGrid.aspx">Inter Production Stock Received</a> </li>
            </ul>
        </li>
        <li id="Payments" visible="false" runat="server" class='has-sub'><a href="javascript:;" style="color: White">Receipts </a>
            <ul>
                <li id="CustomerSalesReceipts" runat="server" visible="false"><a href="../Accountsbootstrap/CashReceipts.aspx">Dealer Sales Receipts</a></li>
                <li id="CusSalesReceipts" runat="server" visible="false"><a href="../Accountsbootstrap/CashReceiptsGrid.aspx">Customer Sales Receipts</a></li>
            </ul>
        </li>
        <li id="semiprodmenu" visible="false" runat="server" class='has-sub'><a href="javascript:;" style="color: White">Semi Production <b></b>
            <br />
            <label id="Label3" runat="server" style="color: ThreeDLighShadow; margin-left: 10px; text-decoration: blink">
            </label>
        </a>
            <ul>
                <li id="semimaster" class='has-sub' runat="server" visible="false"><a id="A13" runat="server" href="javascript:;">Master Menu</a>
                    <ul>
                        <li id="semicategory" runat="server" visible="false"><a id="A17" href="../Accountsbootstrap/SemiCategoryGrid.aspx"
                            runat="server">Semi Category</a></li>
                        <li id="SemiItemMaster" runat="server" visible="false"><a id="A20" href="../Accountsbootstrap/SemiItemMaster.aspx"
                            runat="server">Semi Item Master</a></li>
                        <li id="PrimaryUOMmaster" runat="server" visible="false"><a id="A21" href="../Accountsbootstrap/PrimaryUOM.aspx"
                            runat="server">Primary Uom</a></li>
                    </ul>
                </li>
                <li id="semirequestMenu" class='has-sub' runat="server" visible="false"><a id="A22" href="javascript:;"
                    runat="server">Request Menu</a>
                    <ul>
                        <li id="semistockadd" runat="server" visible="false"><a id="A27" href="../Accountsbootstrap/SemiReceiveProductionStockGrid.aspx"
                            runat="server">Add Semi Production Stock</a></li>
                        <li id="semirequest" runat="server" visible="false"><a id="A23" href="../Accountsbootstrap/SemiPurchaseRequestGrid.aspx"
                            runat="server">Semi Product Request Entry</a></li>
                        <li id="semiaccept" runat="server" visible="false"><a id="A26" href="../Accountsbootstrap/SemiOrderFromBranch.aspx"
                            runat="server">Accept Semi Product Request</a></li>
                        <li id="Semireceive" runat="server" visible="false"><a id="A28" href="../Accountsbootstrap/SemiGoodsReceivedGrid.aspx"
                            runat="server">Receive Semi Product Request</a></li>
                    </ul>
                </li>
            </ul>
        </li>
        <li id="Reports" runat="server" visible="false" class='has-sub'><a href="javascript:;" style="color: White">Reports <b></b></a>
            <ul>
                <li id="DayCloseReport" class='has-sub' runat="server" visible="false"><a id="A25" href="javascript:;"
                    runat="server">day Close Report</a>
                    <ul>
                        <li id="SessionClosingReport" runat="server" visible="false"><a href="../Accountsbootstrap/sessionreport.aspx"
                            runat="server">session closing Report</a></li>
                        <li id="DailyReport" runat="server" visible="false"><a href="../Accountsbootstrap/closing_report.aspx"
                            runat="server">Daily Report</a></li>
                        <li id="InvoiceGenerate" runat="server" visible="false"><a id="A2" href="../Accountsbootstrap/InvoiceGenerate.aspx"
                            runat="server">Invoice Generate</a></li>
                        <li id="DenominationReport" runat="server" visible="false"><a href="../Accountsbootstrap/Denomination.aspx"
                            runat="server">Denomination Report</a></li>
                        <li id="SessioncloseReport" runat="server" visible="false"><a href="../Accountsbootstrap/Sessionclose.aspx"
                            runat="server">Session Close</a></li>

                        <li id="NewTaxReport" runat="server" visible="false"><a id="A38" href="../Accountsbootstrap/NewTaxReport.aspx"
                            runat="server">Tax Report</a></li>
                        <li id="SalesSummaryReport" runat="server" visible="false"><a href="../Accountsbootstrap/SalesSummaryReport.aspx"
                            runat="server">Daily Summary Report</a></li>
                    </ul>
                </li>
                <li id="OrderFormReport" class='has-sub' runat="server" visible="false"><a id="A24" href="javascript:;"
                    runat="server">Order Form Report</a>
                    <ul>
                        <li id="CustomersCeremonies" runat="server" visible="false"><a href="../Accountsbootstrap/CustomersCeremonies.aspx"
                            runat="server">Customers Ceremonies </a></li>
                        <li id="OrderFormRep" runat="server" visible="false"><a href="../Accountsbootstrap/customerorderformreport.aspx">Order Form Report</a></li>
                        <li id="OrderFormCancel" runat="server" visible="false"><a href="../Accountsbootstrap/OrderFormCancelledReport.aspx">OrderForm Cancel Report</a></li>
                        <li id="TodaysOrder" runat="server" visible="false"><a id="TdayOrderreport" href="../Accountsbootstrap/Order_DayReport.aspx"
                            runat="server">Todays Order Report</a></li>
                        <li id="TodaysAdvance" runat="server" visible="false"><a href="../Accountsbootstrap/SplitUp.aspx">Today's Advance and Balance</a></li>
                        <li id="OrderBalance" runat="server" visible="false"><a href="../Accountsbootstrap/OrderBalanceAmount_Report.aspx"
                            runat="server">Order Balance Report</a></li>
                        <li id="AddLess" runat="server" visible="false"><a id="A14" href="../Accountsbootstrap/AddLessReport.aspx"
                            runat="server" style="color: White">Add Less Reports</a></li>
                    </ul>
                </li>
                <li id="RawPurchaseReport" class='has-sub' runat="server" visible="false"><a id="A29" href="javascript:;"
                    runat="server">Raw - Purchase Report</a>
                    <ul>
                        <li id="StoreStockDetails" runat="server" visible="false"><a href="../Accountsbootstrap/StoreStockDetails.aspx">StoreStockDetails </a></li>
                        <li id="storestockdetailedreport" runat="server" visible="false"><a href="../Accountsbootstrap/storeStockDeatailedReport.aspx">Store Stock Detailed Report </a></li>
                        <li id="KitchenUsageReport" runat="server" visible="false"><a href="../Accountsbootstrap/KitchenUsageReport.aspx">KitchenUsageReport </a></li>
                        <li id="KitchenrawreceivedReport" runat="server" visible="false"><a href="../Accountsbootstrap/RawReceivedReport.aspx">Kitchen Raw Received Report </a></li>
                        <li id="PurchaseReport" runat="server" visible="false"><a href="../Accountsbootstrap/KitchenPurchaseReport.aspx">Purchase Report</a></li>
                        <li id="PurchaseReturnReport" runat="server" visible="false"><a href="../Accountsbootstrap/KitchenPurchaseReturnReport.aspx">Purchase Return Report</a></li>
                        <li id="storepurchasedetailed" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseReportDetailed.aspx">Store Purchase Detailed Report</a></li>
                        <li id="pursum" runat="server" visible="false"><a href="../Accountsbootstrap/purchasesummary.aspx">Purchase Summary </a></li>
                        <li id="purexp" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseFutureExpReport.aspx">Purchase Future Expiry Details </a></li>
                        <li id="minstorealert" runat="server" visible="false"><a href="../Accountsbootstrap/ReportRawMaterialDecAlert.aspx">Min.Store Stck Altert Report </a></li>

                    </ul>
                </li>
                <li id="SalesReport" class='has-sub' runat="server" visible="false"><a id="ASalesReport" href="javascript:;"
                    runat="server">Sales Report</a>
                    <ul>
                        <li id="CustomerSalesRep" runat="server" visible="false"><a href="../Accountsbootstrap/CustomerSalesReport.aspx">Customer Sales Report</a></li>
                        <li id="CustomerSalesKotRep" runat="server" visible="false"><a href="../Accountsbootstrap/customerKotReport.aspx">Customer Sales Kot Report</a></li>
                        <li id="Scredit" runat="server" visible="false"><a href="../Accountsbootstrap/SalesTypeCreditreport.aspx">Sales employee Wise Report</a></li>
                        <li id="SType" runat="server" visible="false"><a href="../Accountsbootstrap/SalesTypeReport.aspx">Sales Type Report</a></li>
                        <li id="SalesSummary" runat="server" visible="false"><a href="../Accountsbootstrap/salessummary.aspx">Sales Summary Report</a></li>
                        <li id="NormalSalesCancelRep" runat="server" visible="false"><a href="../Accountsbootstrap/customercancelreport.aspx">Normal Sales Cancel Report</a></li>
                        <li id="SalesHoursReport" runat="server" visible="false"><a href="../Accountsbootstrap/saleshourreport.aspx">Sales Hour's Report</a></li>
                        <li id="HourlysalesReport" runat="server" visible="false"><a href="../Accountsbootstrap/DetailedHourlyReport.aspx">Hourly sales Report- Detailed </a></li>
                        <li id="SalesandVat" runat="server" visible="false"><a id="A19" href="../Accountsbootstrap/SalesVatReport.aspx"
                            runat="server">Sales and Vat Report</a></li>
                        <li id="SalesRegisterReport" runat="server" visible="false"><a id="A18" href="../Accountsbootstrap/SalesRegReport.aspx"
                            runat="server">Sales Register Report</a></li>
                        <li id="FullSalesReport" runat="server" visible="false"><a href="../Accountsbootstrap/FullSalesReport.aspx"
                            runat="server">Full Sales Report</a></li>
                        <li id="SalesRep" runat="server" visible="false"><a href="../Accountsbootstrap/FullSalesReport1.aspx"
                            runat="server">Sales Margin Report</a></li>
                        <li id="TaxWiseOrder" runat="server" visible="false"><a href="../Accountsbootstrap/FullSalesReport2.aspx">Tax Wise Order Report</a></li>
                        <li id="DayEndReport" runat="server" visible="false"><a href="../Accountsbootstrap/TwoReports.aspx">DayEnd Report</a></li>
                    </ul>
                </li>
                <li id="StockReport" class='has-sub' runat="server" visible="false"><a runat="server" href="javascript:;">Stock Report</a>
                    <ul>
                        <li id="Productionrep" runat="server" visible="false"><a href="../Accountsbootstrap/Production_Report.aspx">Production GRN Report</a></li>
                        <li id="Stockrep" runat="server" visible="false"><a href="../Accountsbootstrap/StockReport.aspx">Avaliable Stock Report</a></li>
                        <li id="ReturnReceivingReport" runat="server" visible="false"><a id="A5" href="../Accountsbootstrap/ReturnReceivingReport.aspx"
                            runat="server">Return Receiving Report</a></li>
                        <li id="GRNReport" runat="server" visible="false"><a href="../Accountsbootstrap/GRNReport.aspx">GRN Report</a></li>
                        <li id="GRNPMRPT" runat="server" visible="false"><a href="../Accountsbootstrap/GRNPMREPORT.aspx">GRN-P/M Report</a></li>
                        <li id="FULLGRNReport" runat="server" visible="false"><a href="../Accountsbootstrap/StockFlowReport.aspx">FULL GRN Report </a></li>
                        <li id="SlotGRNReport" runat="server" visible="false"><a href="../Accountsbootstrap/VendorHistory.aspx">Slot GRN Report </a></li>
                        <li id="StockDeatailedReport" runat="server" visible="false"><a href="../Accountsbootstrap/StockDeatailedReport.aspx">Stock Detailed Report </a></li>
                        <li id="StockAuditReport" runat="server" visible="false"><a href="../Accountsbootstrap/StockAuditReport.aspx">Stock Audit Report </a></li>
                        <li id="StockReturned" class='has-sub' runat="server" visible="false"><a href="javascript:;">Stock Returned </a>
                            <ul>
                                <li id="StockReturnedRep" runat="server" visible="false"><a href="../Accountsbootstrap/StockReturnReport.aspx">Stock Returned Report </a></li>
                                <li id="StockReturnChart" runat="server" visible="false"><a href="../Accountsbootstrap/CRMReturns.aspx">Stock Return Chart </a></li>
                                <li id="StockReturnRepo" runat="server" visible="false"><a id="A8" href="../Accountsbootstrap/Webform4.aspx"
                                    runat="server">Stock Return Report</a></li>
                                <li id="ItemsReturnReport" runat="server" visible="false"><a id="A6" href="../Accountsbootstrap/ItemsReturnReport.aspx"
                                    runat="server">Branch Stock Return Report</a></li>
                            </ul>
                        </li>
                        <li id="Li1" runat="server" visible="false"><a href="../Accountsbootstrap/DatabaseBackUp.aspx">DB Backup </a></li>
                        <li id="DailyStockRequestRep" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseRequestReports.aspx">Daily Stock Request Report</a></li>
                        <li id="DailyStockReceivedRep" runat="server" visible="false"><a href="../Accountsbootstrap/StockREceivedFromBranch.aspx">Daily Stock Received Report</a></li>
                        <li id="StockReturnandGRN" runat="server" visible="false"><a href="../Accountsbootstrap/StockReportsforBoth.aspx">Stock Return and GRN</a></li>
                        <li id="IBSRR" runat="server" visible="false"><a href="../Accountsbootstrap/InterBranchStockRequestReport.aspx">Inter-Branch Stock Request Report</a></li>
                        <li id="IBSRECR" runat="server" visible="false"><a href="../Accountsbootstrap/InterBranchReceivedReport.aspx">Inter-Branch Stock Received Report</a></li>
                        <li id="IBSTR" runat="server" visible="false"><a href="../Accountsbootstrap/InterGoodsTransferReport.aspx">Inter-Branch Stock Transfer Report</a></li>
                        <li id="IPSRR" runat="server" visible="false"><a href="../Accountsbootstrap/InterProdStockRequestReport.aspx">Inter-Production Stock Request Report</a></li>
                        <li id="IPRECR" runat="server" visible="false"><a href="../Accountsbootstrap/InterProdReceivedReport.aspx">Inter-Production Stock Received Report</a></li>
                        <li id="IPSTR" runat="server" visible="false"><a href="../Accountsbootstrap/InterProdGoodsTransferReport.aspx">Inter-Production Stock Transfer Report</a></li>
                        <li id="ISSRR" runat="server" visible="false"><a href="../Accountsbootstrap/InterstoreStockRequestReport.aspx">Inter-Store Stock Request Report</a></li>
                        <li id="ISRECR" runat="server" visible="false"><a href="../Accountsbootstrap/InterStoreReceivedReport.aspx">Inter-Store Stock Received Report</a></li>
                        <li id="ISSTR" runat="server" visible="false"><a href="../Accountsbootstrap/InterStoreGoodsTransferReport.aspx">Inter-Store Stock Transfer Report</a></li>
                    </ul>
                </li>
                <li id="ProductionReport" runat="server" visible="false" style="color: White" class='has-sub'>
                    <a id="A3" runat="server" href="javascript:;">Goods Transfer Report</a>
                    <ul>
                        <li id="ProductionStockDetails" runat="server" visible="false"><a href="../Accountsbootstrap/ProduuctionStockDetails.aspx">KitchenStockDetails </a></li>
                        <li id="GoodsTransfer" runat="server" visible="false"><a href="../Accountsbootstrap/GoodsTransferGrid.aspx"
                            style="color: White" runat="server">Goods Transfer</a></li>
                        <li id="ReturnedItems" runat="server" visible="false"><a href="../Accountsbootstrap/Return_ItemsGrid.aspx"
                            runat="server" style="color: White">Returned Items</a></li>
                        <li id="TransferReports" runat="server" visible="false"><a href="../Accountsbootstrap/GoodsTransferReport.aspx"
                            runat="server" style="color: White">Goods Transfer Detailed Reports</a></li>
                        <li id="goodstransferstore" runat="server" visible="false"><a id="A11" href="../Accountsbootstrap/GoodsTransferGridstore.aspx"
                            style="color: White" runat="server">Goods Transfer Store</a></li>
                        <li id="transferreportsstore" runat="server" visible="false"><a id="A12" href="../Accountsbootstrap/GoodsTransferReportStore.aspx"
                            runat="server" style="color: White">Goods Transfer Store Detailed Reports</a></li>
                        <li id="dispatchreport" runat="server" visible="false"><a id="A30" href="../Accountsbootstrap/DispatchPrint.aspx"
                            runat="server" style="color: White">Goods Dispatch Reports</a></li>
                    </ul>
                </li>
                <li id="supplierhead" class='has-sub' runat="server" visible="false"><a id="supplierreport"
                    runat="server" href="javascript:;">Supplier Outstanding/Payment Report</a>
                    <ul>
                        <li id="supplieroutstandingstore" runat="server" visible="false"><a href="../Accountsbootstrap/SupplierOustanding_report.aspx">Supplier Outstanding Wise Report </a></li>
                        <li id="SupplierPaymentReport" runat="server" visible="false"><a href="../Accountsbootstrap/PaymentEntryReport.aspx">Supplier Payment Report </a></li>
                        <li id="SupplierOutStanding" runat="server" visible="false"><a href="../Accountsbootstrap/SupplierOutStanding.aspx">Supplier Summary/Detailed OutStanding </a></li>
                    </ul>
                </li>
                 <li id="ExpenseDetails" runat="server" visible="false"><a  href="../Accountsbootstrap/ExpenseDetails.aspx"
                            runat="server">Expense Summary/Detailed Report</a></li>
                <li id="ChartReport" runat="server" visible="false" class='has-sub'><a id="A9" runat="server" href="javascript:;">Chart Report</a>
                    <ul>
                        <li id="AnalysisReport" runat="server" visible="true"><a id="A15" href="../Accountsbootstrap/SalesandReturn_Report.aspx"
                            runat="server">Analysis Report</a></li>
                        <li id="TodaysSalesStockReturn" runat="server" visible="true"><a id="A16" href="../Accountsbootstrap/SalesandReturn_DayReport.aspx"
                            runat="server">Todays Sales & Stock Return Report</a></li>
                        <li id="OverAllSales" runat="server" visible="true"><a id="A7" href="../Accountsbootstrap/CRM.aspx"
                            runat="server">OverAll Sales</a></li>
                    </ul>
                </li>
                <li id="GeneralReports" runat="server" visible="false"><a id="A4" href="../Accountsbootstrap/GeneralReports.aspx"
                    runat="server">General Reports</a></li>
                <li id="OtherReport" runat="server" visible="false" class='has-sub'><a runat="server" href="javascript:;">Other Report</a>
                    <ul>
                        <li id="CustomerReport" runat="server" visible="false"><a href="../Accountsbootstrap/Customer_ContactReport.aspx"
                            runat="server">Customer Report</a></li>
                        <li id="GroupReport" runat="server" visible="false"><a href="../Accountsbootstrap/ItemReport.aspx">Group Report</a></li>
                        <li id="ItemReport" runat="server" visible="false"><a href="../Accountsbootstrap/ItemDetReport.aspx">Item Report</a></li>
                        <li id="SendMessage" runat="server" visible="false"><a href="../Accountsbootstrap/Send_Message.aspx">Send Message</a></li>
                    </ul>
                </li>
                <li id="PaymentReport" class='has-sub' runat="server" visible="false"><a id="A31" href="javascript:;"
                    runat="server">Payment Report</a>
                    <ul>
                        <li id="CustomerReceiptReport" runat="server" visible="true"><a href="../Accountsbootstrap/CashReceiptsReport.aspx">Customer Receipt Report</a></li>
                        <li id="CustomerOutStandingReport" runat="server" visible="true"><a href="../Accountsbootstrap/CustomerOutStanding.aspx">Customer OutStanding Report</a></li>
                        <li id="SalesandReceiptReport" runat="server" visible="true"><a href="../Accountsbootstrap/SalesandReceiptReport.aspx">Sales and Receipt Report</a></li>
                    </ul>
                </li>
                <li id="billfrom" runat="server" visible="false"><a href="javascript:;" style="color: Silver"></a>
                </li>
                <li id="AccountsReport" class='has-sub' runat="server" visible="false"><a id="A33" runat="server" href="javascript:;">Accounts Report</a>
                    <ul>
                        <li id="LedgerReportNEW" runat="server" visible="false"><a id="A34" href="../Accountsbootstrap/LedgerReportNEW.aspx"
                            runat="server">Ledger Report</a></li>
                        <li id="DaybookNEW" runat="server" visible="false"><a id="A20222" href="../Accountsbootstrap/DaybookNEW.aspx"
                            runat="server">Daybook Report</a></li>
                        <li id="CashAccount" runat="server" visible="false"><a id="A35" href="../Accountsbootstrap/CashAccount.aspx"
                            runat="server">Cash Account Report</a></li>
                        <%--    <li id="Li7" runat="server" visible="true"><a id="A22" href=""
                                runat="server">Receipt Report</a></li>--%>
                        <li id="BankStatementReport" runat="server" visible="false"><a id="A36" href="../Accountsbootstrap/Statement.aspx"
                            runat="server">Bank Statement Report</a></li>
                        <li id="TrialBalance" runat="server" visible="false"><a id="A37" href="../Accountsbootstrap/traildatewise.aspx"
                            runat="server">Trial Balance Report</a></li>
                    </ul>
                </li>
            </ul>
        </li>
        <li id="UserMenu" runat="server" visible="false" class='has-sub'><a id="A39"
            runat="server" style="color: White" href="javascript:;">User</a>
            <ul>
                <li id="UserRole" runat="server" visible="false"><a href="../Accountsbootstrap/UserroleGrid.aspx">User Role</a></li>
                <li id="User" runat="server" visible="false"><a href="../Accountsbootstrap/Usergrid.aspx">User Create </a></li>
            </ul>
        </li>
        <li id="onlineorderentry" runat="server" visible="false"><a href="../Accountsbootstrap/OnlineBillEntry.aspx"
            style="color: White" href="javascript:;">Add Online Bill Entry</a></li>
        <li id="onlineentryreport" runat="server" visible="false"><a href="../Accountsbootstrap/OnlineEntryReport.aspx"
            style="color: White">Online Entry Report</a></li>
        <li id="AddUsers" runat="server" visible="false"><a href="../Accountsbootstrap/UserGrid.aspx"
            style="color: White">Add Users</a></li>
        <li id="Synchronization" runat="server" visible="false"><a href="../Accountsbootstrap/Synchronization.aspx"
            style="color: White">Sync.</a></li>
        <li id="Li2" runat="server" visible="false"><a href="../Accountsbootstrap/OnlineOrderScreen.aspx"
            style="color: White">Online Order</a></li>
        <li id="tallyinvoice" runat="server" visible="false"><a href="../Accountsbootstrap/BillInvoiceGrid.aspx"
            style="color: White">Invoice Generate.</a></li>
        <li id="storetallyinvoice" runat="server" visible="false"><a href="../Accountsbootstrap/StoreBillInvoiceGrid.aspx"
            style="color: White">Invoice Generate.</a></li>
        <li id="PurchaseReqDeptGrid" runat="server" visible="false"><a href="../Accountsbootstrap/PurchaseReqDeptGrid.aspx"
            style="color: White">Dept.Invoice Generate.</a></li>
        <li id="BillInvoiceDeptGrid" runat="server" visible="false"><a href="../Accountsbootstrap/BillInvoiceDeptGrid.aspx"
            style="color: White">Store Invoice Generate.</a></li>
        <li id="storebillupload" runat="server" visible="false"><a href="../Accountsbootstrap/InvoiceUpload.aspx"
            style="color: White">Invoice Upload.</a></li>
        <li id="dayclose" runat="server" visible="false"><a href="../Accountsbootstrap/DAYCloseSTock.aspx"
            style="color: White">Stock Day Close</a></li>
        <li id="storedayclose" runat="server" visible="false"><a href="../Accountsbootstrap/DayCloseStockStore.aspx"
            style="color: White">Store Stock Day Close</a></li>
        <li id="chnagepassword" runat="server" visible="false"><a href="../Accountsbootstrap/ChangePassword.aspx"
            style="color: White">Change Password</a></li>
        <!--li><a href="../Accountsbootstrap/login1.aspx" style="color: White">Sign Out</a></li-->
        <li><a href="javascript:;" style="padding: 15px 0; display: none;">
            <asp:Label runat="server" ID="lblWelcome" CssClass="label">Welcome : </asp:Label>

            <asp:Label runat="server" ID="Label2" CssClass="label">: </asp:Label>
        </a>
        </li>
        <li>
            <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false  "> </asp:Label><br />
            <asp:Label ID="lblscreenname" Style="font-size: larger; color: White" runat="server"
                CssClass="label"></asp:Label></li>
    </ul>
</div>
<div class="usr dropdown">
    <button class="btn btn-primary pos-btn1 dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <i class="bi bi-person-circle"></i>
    </button>
    <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenu1">
        <h6 class="dropdown-header">
            <asp:Label runat="server" ID="lblUser" Visible="true"> </asp:Label><br>
            <asp:Label runat="server" ID="lblstore" Visible="true"> </asp:Label></h6>
        <li role="separator" class="divider"></li>
        <li><a href="../Accountsbootstrap/login1.aspx">Sign Out</a></li>
    </ul>
</div>
<div class="footer" visible="false">
    <%--<div id="show" style="background-color: Black; font-size: large; color: White">
            Messege
        </div>
        <div id="hide" style="display: none; background-color: Black; font-size: large; color: White">
            Messege</div>--%>
    <div id="divv1" style="width: auto; display: none; background-color: Green; color: Black; height: 100px">
        <div>
            <a href="../Accountsbootstrap/GoodsReceivedGrid.aspx" id="grnlabel" runat="server"
                style="font-size: medium; color: White"></a>
        </div>
        <div>
            <a href="../Accountsbootstrap/StockTransferGrid.aspx" id="branchreq" runat="server"
                style="font-size: medium; color: White"></a>
        </div>
    </div>
</div>

</html>
