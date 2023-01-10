<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardTemplate.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DashboardTemplate" %>
    <%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
    <%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Home</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- ubi style -->
    <link href="../css/Pos_style.css" rel="stylesheet" />    
    <link href="dashboard.css" rel="stylesheet">
    <!-- ubi style -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap"
        rel="stylesheet">
    
</head>
<body>
<usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
   <div class="clearfix"></div>
    <div id="wrapper">
    <div class="container-fluid">
        <div id="Div1" runat="server" visible="true" class="row panel-custom1">
            <div runat="server" class="col-lg-12">
                <div id="Div2" runat="server" class="col-lg-4">
                </div>
                <div id="Div3" runat="server" align="center" class="col-lg-4">
                    <asp:Label runat="server" Text="BIG POS" Font-Bold="true" Font-Size="XX-Large" ForeColor="#007aff"></asp:Label>
                </div>
                <div id="Div4" runat="server" class="col-lg-4">
                </div>
            </div>
        </div>
        <div runat="server" visible="true" class="row panel-custom1">
            <div class="col-sm-12">
                <ul class="nav navbar-nav pos-nav">
                    <li><a href="TodaysDeliveryOrder.aspx"><i class="posi">
                        <img src="../images/i-delivery.png" /></i><span>New Delivery</span> </a></li>
                    <li><a href="newbutton.aspx"><i class="posi">
                        <img src="../images/i-bill.png" /></i><span>New Bill</span> </a></li>
                    <li><a href="OrderGrid.aspx"><i class="posi">
                        <img src="../images/i-order.png" /></i><span>New Order</span> </a></li>
                    <li><a href="Descriptiongrid.aspx"><i class="posi">
                        <img src="../images/i-product.png" /></i><span>Add Product</span> </a></li>
                    <li><a href="CustomerSalesReport.aspx"><i class="posi">
                        <img src="../images/i-report.png" /></i><span>Sales Report</span> </a></li>
                    <li><a href="stockgrid.aspx"><i class="posi">
                        <img src="../images/i-stock.png" /></i><span>Check Stock</span> </a></li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="panel panel-custom1">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-8">
                                <h3 class="panel-title">
                                    Sales</h3>
                            </div>
                            <div class="col-xs-4 text-right form-inline">
                                <select class="form-control input-sm">
                                    <option>Today</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-6 pos-pb-20">
                                <span class="pos-currency1">₹</span>
                                <span class="pos-money1"><asp:Label ID="lbltotalamountt" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title1">Total Sales
                                    <asp:Label ID="lbltotalsalescount" Text="0.00" runat="server" cssClass="badge pos-bubble"></asp:Label>
                                </div>
                            </div>
                            <div class="col-sm-6 pos-pb-20">
                                <span class="pos-currency1">₹</span>
                                <span class="pos-money1"><asp:Label ID="lblcancelamount" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title1">Cancelled
                                    <asp:Label ID="lbltotalcancelscount" Text="0.00" runat="server" cssClass="badge pos-bubble"></asp:Label>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lbltotaltodaycashamnt" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    CASH</div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lbltotaltodaycardamnt" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    CARD</div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lbltotaltodayonlineamnt" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    ONLINE</div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lbltotaltodaynotpaidamnt" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    NOT PAID</div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-custom1">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-8">
                                <h3 class="panel-title">
                                   Weekly Sales</h3>
                            </div>
                            <div class="col-xs-4 text-right form-inline">
                                
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-12 pos-pb-20">
                                <asp:Chart ID="Chart2"  runat="server" Width="600px" Height="250px">
                                    <titles>
                                        <asp:Title  Font="Arial, 16pt, style=Bold, Italic" Name=""
                                            Text="">
                                        </asp:Title>
                                    </titles>
                                    <series>
                                        <asp:Series  Name="Series1" Color="green" Font="Arial, 14pt, style=Bold"
                                            IsValueShownAsLabel="true"  IsVisibleInLegend="false" LegendText="Overall">
                                        </asp:Series>
                                    </series>
                                    <legends>
                                        <asp:Legend  Name="Admin">
                                        </asp:Legend>
                                    </legends>
                                    <chartareas>
                                        <asp:ChartArea  Name="ChartArea1">
                                            <AxisX Interval="1" IntervalType="Number" ArrowStyle="none" >
                                                <MajorGrid LineWidth="0" LineColor="gray" />
                                                <MinorGrid />
                                            </AxisX>
                                            <AxisY IsStartedFromZero="true" interval="2000" IsLabelAutoFit="true" ArrowStyle="none">
                                                <MajorGrid LineWidth="0" LineColor="gray" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </chartareas>
                                </asp:Chart>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-custom1">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-8">
                                <h3 class="panel-title">
                                    Orders</h3>
                            </div>
                            <div class="col-xs-4 text-right form-inline">
                                <select class="form-control input-sm">
                                    <option>Today</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-6 pos-pb-20">
                                <span class="pos-currency1">₹</span> <span class="pos-money1">
                                    <asp:Label ID="lblTotalOrderAmount" Text="0.00" runat="server"></asp:Label>
                                    /
                                    <asp:Label ID="lblOrderBalanceAmount" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title1">
                                    Total Orders
                                    <asp:Label ID="lbltodayOrderCount" Text="0" runat="server" cssClass="badge pos-bubble"></asp:Label>
                                </div>
                            </div>
                            
                            <div class="col-sm-6 pos-pb-20">
                                <span class="pos-currency1">₹</span> <span class="pos-money1">
                                    <asp:Label ID="lblOrderCancelAmount" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title1">
                                    Cancelled <asp:Label ID="lbTodayOrderCancelledCount" Text="0.00" runat="server" cssClass="badge pos-bubble"></asp:Label>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lblTotalOrderCash" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    CASH</div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lblTotalOrderCard" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    CARD</div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="Label7" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    ONLINE</div>
                            </div>
                            <div class="col-sm-3">
                                <span class="pos-currency2">₹</span> <span class="pos-money2">
                                    <asp:Label ID="lblTotalOrdernotpaid" Text="0.00" runat="server"></asp:Label></span>
                                <div class="pos-title2">
                                    NOT PAID</div>
                            </div>
                             
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="panel panel-custom1">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Orders to delivery <span class="badge pos-bubble">3</span></h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <a href="../Accountsbootstrap/TodaysDeliveryOrder.aspx" >
                                    <asp:Label ID="lblDeliveryDetails"  runat="server"></asp:Label>
                                </a> 
                                <ul class="pos-orders-list">
                                    <li class="pos-order-item">
                                        <div class="pos-order-cname">
                                            Priya <span class="pos-order-ctel">+91 12345 6789</span> <span class="pos-b-number pull-right">
                                                #1234</span>
                                        </div>
                                        <div class="pos-order-detail">
                                            <div class="pos-money3 pull-left">
                                                ₹ 275.50
                                            </div>
                                            <div class="pos-dt-detail pull-right">
                                                <span>1 AUG 2022</span> <span>2 AUG 2022</span> <span>11:00 AM</span> <span class="label label-warning">
                                                    PENDING</span>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                        </div>
                                    </li>
                                    <li class="pos-order-item">
                                        <div>
                                            <div class="pos-order-cname">
                                                Priya <span class="pos-order-ctel">+91 12345 6789</span> <span class="pos-b-number pull-right">
                                                    #1234</span>
                                            </div>
                                            <div class="pos-order-detail">
                                                <div class="pos-money3 pull-left">
                                                    ₹ 275.50
                                                </div>
                                                <div class="pos-dt-detail pull-right">
                                                    <span>1 AUG 2022</span> <span>2 AUG 2022</span> <span>11:00 AM</span> <span class="label label-warning">
                                                        PENDING</span>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
 </div>
    </form>
</body>
</html>
