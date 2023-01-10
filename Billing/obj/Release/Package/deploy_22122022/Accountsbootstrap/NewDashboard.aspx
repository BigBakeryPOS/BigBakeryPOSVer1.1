<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDashboard.aspx.cs" Inherits="Billing.Accountsbootstrap.NewDashboard" %>

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
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
   
    <!-- ubi style -->
	<link href="../css/dashboard.css" rel="stylesheet">
	<!-- ubi style -->
	<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
	
</head>
<body>
    
    <form id="form1" runat="server">
     <!--ubi testing code - starts -->
	
    <nav class="navbar navbar-inverse navbar-fixed-top pos-navbar">
      <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">Project name</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav navbar-right">
            <li><a href="#">Dashboard</a></li>
            <li><a href="#">Settings</a></li>
            <li><a href="#">Profile</a></li>
            <li><a href="#">Help</a></li>
          </ul>
        </div>
      </div>
    </nav>
    <div class="container-fluid">
	<div class="row panel-custom1">
		<div class="col-sm-12">
		 
			<ul class="nav navbar-nav pos-nav">
				<li>
					<a href="#">
						<i class="posi"><img src="i-delivery.png" /></i><span>New Delivery</span>
					</a>
				</li>
				<li>
					<a href="#">
						<i class="posi"><img src="i-bill.png" /></i><span>New Bill</span>
					</a>
				</li>
				<li>
					<a href="#">
						<i class="posi"><img src="i-order.png" /></i><span>New Order</span>
					</a>
				</li>
				<li>
					<a href="#">
						<i class="posi"><img src="i-product.png" /></i><span>Add Product</span>
					</a>
				</li>
				<li>
					<a href="#">
						<i class="posi"><img src="i-report.png" /></i><span>Sales Report</span>
					</a>
				</li>
				<li>
					<a href="#">
						<i class="posi"><img src="i-stock.png" /></i><span>Check Stock</span>
					</a>
				</li>
			</ul>
		 
			
		</div>
	</div>
	<div class="row">
        <div class="col-sm-6">
          <div class="panel panel-custom1">
            <div class="panel-heading">
			<div class="row">
				<div class="col-xs-8">
					<h3 class="panel-title">Sales</h3>
				</div>
				<div class="col-xs-4 text-right form-inline">
				 <select class="form-control input-sm">
				  <option>1</option>
				  <option>2</option>
				  <option>3</option>
				  <option>4</option>
				  <option>5</option>
				</select>
				<input type="submit" name="test" value="Reset" id="test" class="btn btn-primary btn-sm pos-btn1">
				<button class="btn btn-primary btn-sm pos-btn1"><i class="fa fa-refresh"></i></button>
				</div>
			
			</div>
            </div>
            <div class="panel-body">
              <div class="row">
				<div class="col-sm-12 pos-pb-20">
					<span class="pos-currency1">₹</span>
					<span class="pos-money1">5000.00</span>
					<div class="pos-title1">Total Sales</div>
				</div>
				<div class="col-sm-4">
					<span class="pos-currency2">₹</span>
					<span class="pos-money2">5000.00</span>
					<div class="pos-title2">Dine in</div>
				</div>
				<div class="col-sm-4">
					<span class="pos-currency2">₹</span>
					<span class="pos-money2">5000.00</span>
					<div class="pos-title2">Pick up</div>
				</div>
				<div class="col-sm-4">
					<span class="pos-currency2">₹</span>
					<span class="pos-money2">5000.00</span>
					<div class="pos-title2">Delivery</div>
				</div>
				<div class="col-sm-12 pos-pb-20">
					<div class="pos-graph">
						GRAPH
					</div>
				</div>
			  </div>
            </div>
          </div>
		  <div class="panel panel-custom1">
            <div class="panel-heading">
			<div class="row">
				<div class="col-xs-8">
					<h3 class="panel-title">Sales</h3>
				</div>
				<div class="col-xs-4 text-right form-inline">
				 <select class="form-control input-sm">
				  <option>1</option>
				  <option>2</option>
				  <option>3</option>
				  <option>4</option>
				  <option>5</option>
				</select>
				<input type="submit" name="test" value="Reset" id="test" class="btn btn-primary btn-sm pos-btn1">
				<button class="btn btn-primary btn-sm pos-btn1"><i class="fa fa-refresh"></i></button>
				</div>
			
			</div>
            </div>
            <div class="panel-body">
              <div class="row">
				<div class="col-sm-12 pos-pb-20 pos-empty">
					 <img src="i-b-sales.png" /><br>
					 There are no sales. 
				</div> 
			  </div>
            </div>
          </div>
        </div> 
        <div class="col-sm-6">
           <div class="panel panel-custom1">
            <div class="panel-heading">
				<h3 class="panel-title">Orders</h3>
            </div>
            <div class="panel-body">
              <div class="row">
				<div class="col-sm-12 pos-pb-20">
					<span class="pos-money1">5</span>
					<div class="pos-title1">Total</div>
				</div>
				<div class="col-sm-4">
					<span class="pos-money2">20</span>
					<div class="pos-title2">Dine in</div>
				</div>
				<div class="col-sm-4">
					<span class="pos-money2">4</span>
					<div class="pos-title2">Pick up</div>
				</div>
				<div class="col-sm-4">
					<span class="pos-money2">1</span>
					<div class="pos-title2 text-red">Cancelled</div>
				</div>
			  </div>
            </div>
          </div>
        </div> 
		<div class="col-sm-6">
           <div class="panel panel-custom1">
            <div class="panel-heading">
				<h3 class="panel-title">Orders to delivery <span class="badge pos-bubble">3</span></h3>
            </div>
            <div class="panel-body">
              <div class="row">
				<div class="col-sm-12">
					 <ul class="pos-orders-list">
						<li class="pos-order-item">
							<div class="pos-order-cname">
								Priya <span class="pos-order-ctel">+91 12345 6789</span>
								<span class="pos-b-number pull-right">#1234</span>
							</div>
							<div class="pos-order-detail">
								<div class="pos-money3 pull-left">
									₹ 275.50
								</div>
								<div class="pos-dt-detail pull-right">
									<span>1 AUG 2022</span>
									<span>2 AUG 2022</span>
									<span>11:00 AM</span>
									<span class="label label-warning">PENDING</span>
								</div>
								<div class="clearfix"></div>
							</div>
						</li>
						<li class="pos-order-item">
						<div>
							<div class="pos-order-cname">
								Priya <span class="pos-order-ctel">+91 12345 6789</span>
								<span class="pos-b-number pull-right">#1234</span>
							</div>
							<div class="pos-order-detail">
								<div class="pos-money3 pull-left">
									₹ 275.50
								</div>
								<div class="pos-dt-detail pull-right">
									<span>1 AUG 2022</span>
									<span>2 AUG 2022</span>
									<span>11:00 AM</span>
									<span class="label label-warning">PENDING</span>
								</div>
								<div class="clearfix"></div>
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
	
      <div class="row panel-custom1">
        <div class="col-sm-12">
          <h1 class="page-header">Order Details
		  <span class="pull-right">
		  <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
			</span>
		  </h1>
          <h2 class="sub-header">Upcoming</h2>
          <div class="table-responsive">
            <table class="table table-striped pos-table">
              <thead>
                <tr>
                  <th>#</th>
                  <th>Header</th>
                  <th>Header</th>
                  <th>Header</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>1,001</td>
                  <td>Lorem</td>
                  <td>ipsum</td>
                  <td>dolor</td>
                  <td class="pull-right">
					<button type="button" class="btn btn-default btn-md">
						<span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					</button>
					<button type="button" class="btn btn-danger btn-md">
						<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
					</button>
					<button type="button" class="btn btn-warning btn-md">
						<span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
					</button>
					<button type="button" class="btn btn-success btn-md">
						<span class="glyphicon glyphicon-credit-card" aria-hidden="true"></span>
					</button>
				  </td>
                </tr>
                <tr>
                  <td>1,002</td>
                  <td>amet</td>
                  <td>consectetur</td>
                  <td>adipiscing</td>
                  <td>elit</td>
                </tr>
                <tr>
                  <td>1,003</td>
                  <td>Integer</td>
                  <td>nec</td>
                  <td>odio</td>
                  <td>Praesent</td>
                </tr>
                <tr>
                  <td>1,003</td>
                  <td>libero</td>
                  <td>Sed</td>
                  <td>cursus</td>
                  <td>ante</td>
                </tr>
                <tr>
                  <td>1,004</td>
                  <td>dapibus</td>
                  <td>diam</td>
                  <td>Sed</td>
                  <td>nisi</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
		<!--ubi teting code - ends -->
    </form>
   

</body>
</html>

