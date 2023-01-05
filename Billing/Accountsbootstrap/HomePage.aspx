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
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
	<link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
	
	
	<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.2/font/bootstrap-icons.css">
	
	<style>
	.item-card-row {
		padding: 10px;
	}
	.item-card-row .item-card-col{
		padding-right: 6px;
		padding-left: 6px;
	}

	.item-card{
		text-align: center;
		border: 1px solid #376091;
		border-radius: 3px;
		background-color: #37609110;
		padding: 10px 4px;
		margin-bottom:12px;
		transition: .5s;
	}
	.item-card:hover {
		background-color: #fff;
		text-color: #fff;
		box-shadow: 0px 0px 20px 0px #ccc;
	}

	.item-card p{
		font-size: 13px;
		line-height: 24px;
		margin-bottom: 0px;
		color: #000;
	}

	.item-card-col a{
		text-decoration:none;
	}
	.icon-default-color {
		color: #376091;
	}
	
	</style>
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
        
<%--<div class="container-fluid">
    <div class="row panel-custom1">
		<div class="col-sm-12">
		 
			<ul class="nav navbar-nav pos-nav">
				<li>
                    
					<a href="TodaysDeliveryOrder.aspx">
						<i class="posi bi-calendar-check icon-default-color"></i><span>New Delivery</span>
					</a>
				</li>
				<li>
					<a href="newbutton.aspx">
						<i class="posi bi-receipt-cutoff icon-default-color"></i><span>New Bill</span>
					</a>
				</li>
				<li>
					<a href="OrderGrid.aspx">
						<i class="posi bi-cart3 icon-default-color"></i><span>New Order</span>
					</a>
				</li>
				<li>
					<a href="Descriptiongrid.aspx">
						<i class="posi bi-cup-hot icon-default-color"></i><span>Add Product</span>
					</a>
				</li>
				<li>
					<a href="CustomerSalesReport.aspx">
						<i class="posi bi-graph-up-arrow icon-default-color"></i><span>Sales Report</span>
					</a>
				</li>
				<li>
					<a href="stockgrid.aspx">
						<i class="posi bi-ui-checks-grid icon-default-color"></i><span>Check Stock</span>
					</a>
				</li>
			</ul>
		 
			
		</div>
	</div>




</div>--%>


		 
    <%-- Dashboard starts--%>
        <div id="wrapper">
			
            <!-- /.row -->
            <div class="col-lg-12 col-md-12">
				<div class="panel panel-custom1">
				<div class="panel-body">
					<div class="row item-card-row">
						<div class="col-sm-3 item-card-col"><a href="newbutton.aspx"><div class="card item-card"><i class="bi-receipt-cutoff icon-default-color" style="font-size: 2em;"></i>
							<p>New Bill</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="OrderGrid.aspx"><div class="card item-card"><i class="bi-cart3 icon-default-color" style="font-size: 2em;"></i>
							<p>New Order</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="Descriptiongrid.aspx"><div class="card item-card"><i class="bi-cup-hot icon-default-color" style="font-size: 2em;"></i>
							<p>Products</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="stockgrid.aspx"><div class="card item-card"><i class="bi-ui-checks-grid icon-default-color" style="font-size: 2em;"></i>
							<p>Check Stock</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="TodaysDeliveryOrder.aspx"><div class="card item-card"><i class="bi-calendar-check icon-default-color" style="font-size: 2em;"></i>
							<p>Today Delivery</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="#"><div class="card item-card"><i class="bi-people icon-default-color" style="font-size: 2em;"></i>
							<p>Customers</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="#"><div class="card item-card"><i class="bi-grid-3x2-gap icon-default-color" style="font-size: 2em;"></i>
							<p>Running Table</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="#"><div class="card item-card"><i class="bi-repeat icon-default-color" style="font-size: 2em;"></i>
							<p>Synchronise</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="#"><div class="card item-card"><i class="bi-printer icon-default-color" style="font-size: 2em;"></i>
							<p>Bill Reprint</p></div></a> 
						</div>
						<div class="col-sm-3 item-card-col"><a href="billsetting.aspx"><div class="card item-card"><i class="bi-receipt icon-default-color" style="font-size: 2em;"></i>
							<p>Bill Settlement</p></div></a> 
						</div>
					</div> 	
						 
				</div>
				</div>
                <div class="row">
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
                                        Total Sales</h3>
									<ul class="list-group">
										<li class="list-group-item">
											<h3 class="list-group-item-heading"><asp:Label ID="lbltotalsalescount" Text="0" runat="server"></asp:Label></h3>
											<p class="list-group-item-text">Today's Total Bill Count</p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"> <asp:Label ID="lbltotalamountt" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text">Today's Total Amount</p>
										</li>
										<li class="list-group-item">
											<h3 class="list-group-item-heading"><asp:LinkButton ID="LlblTodaybillcancel" PostBackUrl="~/Accountsbootstrap/Admin_CustomerSalesReport.aspx"
                                            runat="server"></asp:LinkButton></h3>
											<p class="list-group-item-text">Today's Cancelled Bills</p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"><asp:Label ID="lblcancelamount" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text">Today's Cancel Amount</p>
										</li>
									</ul>
                                     
                                </div>
                                <div>
                                    <h3 class="panel-title" >
                                        Amount Details</h3>
									<ul class="list-group">
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"><asp:Label ID="lbltotaltodaycashamnt" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"><asp:Label ID="Label13" Text="Today's Total Cash Amount" runat="server"></asp:Label></p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"><asp:Label ID="lbltotaltodaycardamnt" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"><asp:Label ID="Label28" Text="Today's Total Card Amount" runat="server"></asp:Label></p>
										</li>
										 
									</ul> 
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
                                        Total Orders</h3>
									<ul class="list-group">
										<li class="list-group-item">
											<h3 class="list-group-item-heading"><asp:Label ID="lblOrderCount" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"><asp:Label ID="Label3" Text="Today's Order Total  Bill Count" runat="server"></asp:Label></p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"> <asp:Label ID="lblTotalOrderAmount" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"> <asp:Label ID="Label5" Text="Today's Order Total Amount" runat="server"></asp:Label></p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading">  <asp:Label ID="lblOrderBalanceAmount" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"> <asp:Label ID="Label7" Text="Today's Order Balance Amount" runat="server"></asp:Label></p>
										</li>
										<li class="list-group-item">
											<h3 class="list-group-item-heading"> <asp:LinkButton ID="lbTodayOrderCancelledCount" PostBackUrl="~/Accountsbootstrap/Admin_CustomerSalesReport.aspx"
                                            runat="server"></asp:LinkButton></h3>
											<p class="list-group-item-text"><asp:Label ID="Label8" Text="Today's Order Cancelled Bills" runat="server"></asp:Label></p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"><asp:Label ID="lblOrderCancelAmount" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"> <asp:Label ID="Label9" Text="Today's Order Cancel Amount" runat="server"></asp:Label></p>
										</li>
									</ul>		
								 
                                </div>
                                <div>
                                    <h3 class="panel-title" >
                                        Amount Details</h3>
									<ul class="list-group">
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"><asp:Label ID="lblTotalOrderCash" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"><asp:Label ID="Label12" Text="Today's Order Total Cash Amount" runat="server"></asp:Label></p>
										</li>
										<li class="list-group-item list-group-item-success">
											<h3 class="list-group-item-heading"><asp:Label ID="lblTotalOrderCard" Text="Rs 0.00" runat="server"></asp:Label></h3>
											<p class="list-group-item-text"><asp:Label ID="Label15" Text="Today's Order Total Card Amount" runat="server"></asp:Label></p>
										</li>
									</ul>  
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
				
				<div class="col-lg-12">
				<div class="panel panel-custom1">
					<div class="panel-body">
					<h3 class="panel-title" >Amount Details</h3>
						<ul class="list-group">
							<li class="list-group-item">
								<h3 class="list-group-item-heading"><a href="#">Report Name</a></h3>
								<p class="list-group-item-text">Report description goes here..Report description goes here..</p>
							</li>
							<li class="list-group-item">
								<h3 class="list-group-item-heading"><a href="#">Report Name</a></h3>
								<p class="list-group-item-text">Report description goes here..Report description goes here..</p>
							</li>
							<li class="list-group-item">
								<h3 class="list-group-item-heading"><a href="#">Report Name</a></h3>
								<p class="list-group-item-text">Report description goes here..Report description goes here..</p>
							</li>			
						</ul>  
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
    <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="/js/bootstrap.min.js" type="text/javascript"></script>
	
	<script>
    // Make Dropdown Submenus possible
$('.dropdown-submenu a.dropdown-submenu-toggle').on("click", function(e){
    $('.dropdown-submenu ul').removeAttr('style');
    $(this).next('ul').toggle();
    e.stopPropagation();
    e.preventDefault();
});
// Clear Submenu Dropdowns on hidden event
$('#bs-navbar-collapse-1').on('hidden.bs.dropdown', function () {
  	$('.navbar-nav .dropdown-submenu ul.dropdown-menu').removeAttr('style');
});
    // Make Dropdown Submenus possible
$( document ).ready(function() { 

// Make Secondary Dropdown on Click
$('.dropdown-submenu a.dropdown-submenu-toggle').on("click", function(e){
   $('.dropdown-submenu ul').removeAttr('style');
   $(this).next('ul').toggle();
   e.stopPropagation();
   e.preventDefault();
});

// Make Secondary Dropdown on Hover
$('.dropdown-submenu a.dropdown-submenu-toggle').hover(function(){
   $('.dropdown-submenu ul').removeAttr('style');
   $(this).next('ul').toggle();
});

// Make Regular Dropdowns work on Hover too
$('.dropdown a.dropdown-toggle').hover(function(){
   $('.navbar-nav .dropdown').removeClass('open');
   $(this).parent().addClass('open');
});

// Clear secondary dropdowns on.Hidden
$('#bs-navbar-collapse-1').on('hidden.bs.dropdown', function () {
   $('.navbar-nav .dropdown-submenu ul.dropdown-menu').removeAttr('style');
});


$('.btn-main-cat a').click(function(){
	//alert('clicked');
	$(this).parent().siblings().removeClass('active');
	$(this).parent().addClass('active');
});
 

});
</script>

    </form>
</body>
</html>