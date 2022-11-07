<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Billing.Accountsbootstrap.HomePage" %>


<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
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
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
        <div class="clearfix"></div>
    <div id="wrapper">
        <!--div class="row">
            <div class="col-xs-2">
               
            </div>
            <div class="col-xs-2">
                <asp:ImageButton ID="ImageButton1" src="../images/Bill.png" OnClick="Bill_OnClick"
                    runat="server" ValidationGroup="Val1" />
            </div>
            <div class="col-xs-2">
                <asp:ImageButton ID="ImageButton2" src="../images/Order.png" OnClick="Order_OnClick"
                    runat="server" ValidationGroup="Val1" />
            </div>
            <div class="col-xs-2">
                <asp:ImageButton ID="ImageButton3" src="../images/Product.png" OnClick="Product_OnClick"
                    runat="server" ValidationGroup="Val1" />
            </div>
            <div class="col-xs-2">
                <asp:ImageButton ID="ImageButton4" src="../images/Sales.png" OnClick="Sales_OnClick"
                    runat="server" ValidationGroup="Val1" />
            </div>
            <div class="col-xs-2">
                <asp:ImageButton ID="ImageButton5" src="../images/Stock.png" OnClick="Stock_OnClick"
                    runat="server" ValidationGroup="Val1" />
            </div>
        </div-->
        
<div class="container-fluid">
    <div class="row panel-custom1">
		<div class="col-sm-12">
		 
			<ul class="nav navbar-nav pos-nav">
				<li>
                    
					<a href="TodaysDeliveryOrder.aspx">
						<i class="posi"><img src="i-delivery.png" /></i><span>New Delivery</span>
					</a>
				</li>
				<li>
					<a href="newbutton.aspx">
						<i class="posi"><img src="i-bill.png" /></i><span>New Bill</span>
					</a>
				</li>
				<li>
					<a href="OrderGrid.aspx">
						<i class="posi"><img src="i-order.png" /></i><span>New Order</span>
					</a>
				</li>
				<li>
					<a href="Descriptiongrid.aspx">
						<i class="posi"><img src="i-product.png" /></i><span>Add Product</span>
					</a>
				</li>
				<li>
					<a href="CustomerSalesReport.aspx">
						<i class="posi"><img src="i-report.png" /></i><span>Sales Report</span>
					</a>
				</li>
				<li>
					<a href="stockgrid.aspx">
						<i class="posi"><img src="i-stock.png" /></i><span>Check Stock</span>
					</a>
				</li>
			</ul>
		 
			
		</div>
	</div>




</div>


		 
    <%-- Dashboard starts--%>
        <div id="wrapper">
            <!-- /.row -->
            <div class="col-lg-12 col-md-12">
                <div class="col-lg-4 col-md-4">
                    <div class="panel panel-custom1">
                        <div class="panel-body">
                            <div>
                                <div>
                                    <div class="hidden">
                                        <b>
                                            <asp:Label ID="lblsales1" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                        <b>
                                            <asp:Label ID="lblorder" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b>
                                    </div>
                                    <h3 class="panel-title" >
                                        Total Sale's:</h3>
                                    <asp:Label ID="Label6" Text="Today's Total Bill Count:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lbltotalsalescount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label17" Text="Today's Total Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lbltotalamountt" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label11" Text="Today's Cancelled Bills: " runat="server"></asp:Label>
                                    <b>
                                        <%--<asp:Label ID="lblTodaybillcancel"  runat="server"></asp:Label>--%>
                                        <asp:LinkButton ID="LlblTodaybillcancel" PostBackUrl="~/Accountsbootstrap/Admin_CustomerSalesReport.aspx"
                                            runat="server"></asp:LinkButton></b>
                                    <br />
                                    <asp:Label ID="Label30" Text="Today's Cancel Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblcancelamount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                </div>
                                <div>
                                    <h3 class="panel-title" >
                                        Amount Details:</h3>
                                    <asp:Label ID="Label13" Text="Today's Total Cash Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lbltotaltodaycashamnt" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label28" Text="Today's Total Card Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lbltotaltodaycardamnt" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4">
                    <div class="panel panel-custom1">
                        <div class="panel-body">
                            
                                <div>
                                    <div class="hidden">
                                        <b>
                                            <asp:Label ID="Label1" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                        <b>
                                            <asp:Label ID="Label2" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b>
                                    </div>
                                    <h3 class="panel-title" >
                                        Total Orders's:</h3>
                                    <asp:Label ID="Label3" Text="Today's Order Total  Bill Count:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblOrderCount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label5" Text="Today's Order Total Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblTotalOrderAmount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label7" Text="Today's Order Balance Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblOrderBalanceAmount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label8" Text="Today's Order Cancelled Bills: " runat="server"></asp:Label>
                                    <b>
                                        <%--<asp:Label ID="lblTodaybillcancel"  runat="server"></asp:Label>--%>
                                        <asp:LinkButton ID="lbTodayOrderCancelledCount" PostBackUrl="~/Accountsbootstrap/Admin_CustomerSalesReport.aspx"
                                            runat="server"></asp:LinkButton></b>
                                    <br />
                                    <asp:Label ID="Label9" Text="Today's Order Cancel Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblOrderCancelAmount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                </div>
                                <div>
                                    <h3 class="panel-title" >
                                        Amount Details:</h3>
                                    <asp:Label ID="Label12" Text="Today's Order Total Cash Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblTotalOrderCash" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                    <asp:Label ID="Label15" Text="Today's Order Total Card Amount:" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblTotalOrderCard" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                </div>
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4">
                    <div class="panel panel-custom1">
                        <div class="panel-body">
                            <div>
                                
                                    <h3 class="panel-title" >
                                        Order Delivery's Details:</h3>
                                    <marquee direction="up" scrollamount="2" style="background: #fff; min-height: 200px" >
                       <a href="../Accountsbootstrap/TodaysDeliveryOrder.aspx" ><asp:Label ID="lblDeliveryDetails"  runat="server"></asp:Label></a> </b><br /> 

                          <%--<asp:LinkButton ID="LinkButton1" PostBackUrl="../Accountsbootstrap/TodaysDeliveryOrder.aspx" runat="server"></asp:LinkButton></b><br />--%>
                        
                         </marquee>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="padding-left: 20px; padding: 20px; display: none">
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-line-chart" style="font-size: 100px"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div id="IDTodaySales" runat="server">
                                        <h3>
                                            Today's Sales:
                                            <asp:Label ID="lblSales" runat="server" Text="0"></asp:Label>
                                        </h3>
                                    </div>
                                    <div id="IDTodaySalesCount" runat="server">
                                        <h3>
                                            Today's Sales:
                                            <asp:Label ID="lblSalesCount" runat="server" Text="0"></asp:Label>
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="CustomerSalesReport.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                                </i></span>
                                <div class="clearfix">
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div>
                                <div class="col-xs-3">
                                    <i class="fa fa-users" style="font-size: 100px"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div id="IDOrderBalance" runat="server">
                                        <h3>
                                            Total Order Balance:
                                            <asp:Label ID="lblCustomerOrderBalance" runat="server" Text="0"></asp:Label>
                                        </h3>
                                    </div>
                                    <div id="IDCustomer" runat="server">
                                        <h3>
                                            Total Customers:
                                            <asp:Label ID="lblCustomers" runat="server" Text="0"></asp:Label>
                                        </h3>
                                    </div>
                                </div>
                                <div>
                                </div>
                            </div>
                        </div>
                        <a href="viewcustomer.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                                </i></span>
                                <div class="clearfix">
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-inr" style="font-size: 100px"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <asp:Label ID="lblExpenses" runat="server" Text="0"></asp:Label>
                                    <div>
                                        <h3>
                                            Today's Expenses!</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="Expensegrid.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right">
                                </i></span>
                                <div class="clearfix">
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            
        </div>
		
		
		
    </div>
    <!-- /#page-wrapper -->
    </div>
    <!-- /#wrapper -->
    <!-- jQuery -->
    <script src="../Dashboard_settings/bower_components/jquery/dist/jquery.min.js" type="text/javascript"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../Dashboard_settings/bower_components/bootstrap/dist/js/bootstrap.min.js"
        type="text/javascript"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="../Dashboard_settings/bower_components/metisMenu/dist/metisMenu.min.js"
        type="text/javascript"></script>
    <!-- Morris Charts JavaScript -->
    <script src="../Dashboard_settings/bower_components/raphael/raphael-min.js" type="text/javascript"></script>
    <script src="../Dashboard_settings/bower_components/morrisjs/morris.min.js" type="text/javascript"></script>
    <!-- Custom Theme JavaScript -->
    <script src="../Dashboard_settings/dist/js/sb-admin-2.js" type="text/javascript"></script>
    </form>
</body>
</html>