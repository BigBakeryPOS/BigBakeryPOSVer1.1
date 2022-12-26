<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPosbill.aspx.cs" Inherits="Billing.Accountsbootstrap.NewPosbill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<!-- Fonts -->
    <link href="./vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
	<link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
	<!-- Style -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    
	<link href="css/custom-style.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav sidebar accordion toggled" id="accordionSidebar">
			<!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.html"> Billing
				<!-- <button class="rounded-circle border-0 bg-transparent d-none d-md-inline-block" id="sidebarToggle"></button> -->
             </a> 

            <!-- Nav Item - Dashboard -->
            <li class="nav-item active">
                <a class="nav-link" href="index.html"><i class="fas fa-fw fa-receipt"></i><span>Billing</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#"><i class="fas fa-fw fa-wrench"></i><span>Settings</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="#"><i class="fas fa-fw fa-chart-bar"></i><span>Reports</span></a>
            </li>
        </ul>
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">
		
            <!-- Main Content -->
            <div id="content">
				
                <!-- Topbar -->
                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-3 static-top">

                    <!-- Sidebar Toggle (Topbar) -->
                    <button id="sidebarToggleTop" class="btn btn-link bg-transparent rounded-circle mr-3"><i class="fa fa-bars"></i></button>

                    <!-- Topbar Navbar -->
                    <ul class="navbar-nav ml-auto">

                        <!-- Nav Item - User Information -->
                        <li class="nav-item dropdown no-arrow">
                            <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img class="img-profile rounded-circle mr-2" src="images/undraw_profile.png">
                            </a>
                            <!-- Dropdown - User Information -->
                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                                <a class="dropdown-item" href="#">My Account</a>
                                <a class="dropdown-item" href="#">Logout</a>
                            </div>
                        </li>

                    </ul>

                </nav>
                <!-- End of Topbar -->

                <!-- Begin Page Content -->
                <div class="container-fluid px-4 py-2 main_area">
                    <div class="row row-eq-height">
                        <div class="col-lg-6 h-100">
                            <div class="card shadow mb-3 mb-md-0 p-3 h-100">
								<div class="row items-tab">
									<div class="col-sm-12 col-md-4 col-lg-3 items-tab-left">
										<div class="nav flex-column nav-pills" id="pillstab" runat="server"  role="tablist" aria-orientation="vertical">
										  <a class="nav-link active" id="pills-1-tab" data-toggle="pill" href="#pills-1" role="tab" aria-controls="pills-1" aria-selected="true">Ice-creams</a>
										  <a class="nav-link" id="pills-2-tab" data-toggle="pill" href="#pills-2" role="tab" aria-controls="pills-2" aria-selected="false">Bread & Bu...</a>
										  <a class="nav-link" id="pills-3-tab" data-toggle="pill" href="#pills-3" role="tab" aria-controls="pills-3" aria-selected="false">Sandwiches</a>
										  <a class="nav-link" id="pills-4-tab" data-toggle="pill" href="#pills-4" role="tab" aria-controls="pills-4" aria-selected="false">Cakes</a>
										  <a class="nav-link" id="pills-5-tab" data-toggle="pill" href="#pills-5" role="tab" aria-controls="pills-5" aria-selected="false">Sweets</a>
										  <a class="nav-link" id="pills-6-tab" data-toggle="pill" href="#pills-6" role="tab" aria-controls="pills-6" aria-selected="false">Bread & Bun</a>
										  <a class="nav-link" id="pills-7-tab" data-toggle="pill" href="#pills-7" role="tab" aria-controls="pills-7" aria-selected="false">Sandwiches</a>
										</div>
									</div>
									<div class="col">
										<div class="tab-content" id="pills-tabContent">
											<div class="row">
												<div class="col px-2">
												  <div class="form-group">
													<input type="text" class="form-control" id="item-search" placeholder="Search Items" />
												  </div>
												</div>
											</div>
										  <div class="tab-pane fade show active" id="pills-1" role="tabpanel" aria-labelledby="pills-1-tab">
											<div class="row item-card-row">
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Butterscotch</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Vanilla</p><p class="text-muted">₹ 200</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Black current</p><p class="text-muted">₹ 50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Chocolate</p><p class="text-muted">₹ 250.50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Pistha</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Butterscotch</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Vanilla</p><p class="text-muted">₹ 200</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Black current</p><p class="text-muted">₹ 50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Chocolate</p><p class="text-muted">₹ 250.50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Pistha</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Butterscotch</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Vanilla</p><p class="text-muted">₹ 200</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Black current</p><p class="text-muted">₹ 50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Chocolate</p><p class="text-muted">₹ 250.50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Pistha</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Butterscotch</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Vanilla</p><p class="text-muted">₹ 200</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Black current</p><p class="text-muted">₹ 50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Chocolate</p><p class="text-muted">₹ 250.50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Pistha</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Butterscotch</p><p class="text-muted">₹ 100</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Vanilla</p><p class="text-muted">₹ 200</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Black current</p><p class="text-muted">₹ 50</p></a></div></div>
												<div class="col-sm-3 item-card-col"><div class="card item-card"><a href="#"><p>Chocolate</p><p class="text-muted">₹ 250.50</p></a></div></div>
											</div>
										  </div>
										  <div class="tab-pane fade" id="pills-2" role="tabpanel" aria-labelledby="pills-2-tab">
											<div class="text-center py-5 item-card-row">
												<h5 class="card-title"><img src="images/add-items-img.png" alt="Icon" width="53" /></h5><p class="card-text">Empty</p>
											</div>
										  </div>
										  <div class="tab-pane fade" id="pills-3" role="tabpanel" aria-labelledby="pills-3-tab">
											<div class="text-center py-5">
												<h5 class="card-title"><img src="images/add-items-img.png" alt="Icon" width="53" /></h5><p class="card-text">Empty</p>
											</div>
										  </div>
										  <div class="tab-pane fade" id="pills-4" role="tabpanel" aria-labelledby="pills-4-tab">
											<div class="text-center py-5">
												<h5 class="card-title"><img src="images/add-items-img.png" alt="Icon" width="53" /></h5><p class="card-text">Empty</p>
											</div>
										  </div>
										  <div class="tab-pane fade" id="pills-5" role="tabpanel" aria-labelledby="pills-5-tab">
											<div class="text-center py-5">
												<h5 class="card-title"><img src="images/add-items-img.png" alt="Icon" width="53" /></h5><p class="card-text">Empty</p>
											</div>
										  </div>
										  <div class="tab-pane fade" id="pills-6" role="tabpanel" aria-labelledby="pills-6-tab">
											<div class="text-center py-5">
												<h5 class="card-title"><img src="images/add-items-img.png" alt="Icon" width="53" /></h5><p class="card-text">Empty</p>
											</div>
										  </div>
										  <div class="tab-pane fade" id="pills-7" role="tabpanel" aria-labelledby="pills-7-tab">
											<div class="text-center py-5">
												<h5 class="card-title"><img src="images/add-items-img.png" alt="Icon" width="53" /></h5><p class="card-text">Empty</p>
											</div>
										  </div>
										</div>
									</div>
								</div>
							</div>
                        </div>
                        <div class="col-lg-6 h-100">
                            <div class="card shadow mb-4 h-100">
								<div class="card billing-card">
								  <div class="card-header">
									<div class="d-flex justify-content-between align-items-center">
										<div class="d-flex align-items-center">
											<h3 class="mb-0 h6 font-weight-bold mx-1">Current Bill Detail</h3>
											<span class="badge badge-light mx-1">AN-2</span>
											<span class="badge badge-light mx-1">27 Oct 22 1:20 PM</span>
											<span class="badge badge-dark mx-1">Table 1</span>
										</div>
										<a href="#" class="btn btn-sm btn-outline-primary">Pick Table</a>
									</div>
								  </div>
								  <div class="card-body">
									<ul class="nav nav-tabs">
										<li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#bill">Bill</a></li>
										<li class="nav-item"><a class="nav-link" data-toggle="tab" href="#customer">Customer</a></li>
										<li class="nav-item"><a class="nav-link" data-toggle="tab" href="#KOT">KOT</a></li>
									</ul>
									<div class="tab-content mt-3 tab-body">
										<div class="tab-pane show active" id="bill" role="tabpanel">
											<table class="table table-sm table-v-middle">
											  <thead>
												<tr>
												  <th>Items</th>
												  <th class="text-center">Stock</th>
												  <th class="text-center">Qty.</th>
												  <th class="text-right">Price(₹)</th>
												  <th></th>
												</tr>
											  </thead>
											  <tbody>
												<tr>
												  <td>
													<b>Pistha Ice-cream</b>
													<a href="#" class="text-sm d-block text-primary">Add Notes</a>
												  </td>
												  <td class="text-center"><span class="text-muted">44</span></td>
												  <td class="qty">
													<div class="input-group mb-0">
													  <div class="input-group-prepend cursor-pointer">
														<span class="input-group-text" id="qty-minus">-</span>
													  </div>
													  <input type="text" class="form-control form-control-sm" id="inputqty" value="2">
													  <div class="input-group-append cursor-pointer">
														<span class="input-group-text" id="qty-add">+</span>
													  </div>
													</div>
												  </td>
												  <td class="text-right">
													<b>100.00</b>
													<span class="text-sm d-block text-muted">4400.00</span>
												  </td>
												  <td class="text-right">
													<a href="#" class="btn btn-outline-danger btn-sm text-sm"><i class="fa fa-times"></i></a>
												  </td>
												</tr>
												<tr>
												  <td>
													<b>Chocolate Ice-cream</b>
													<a href="#" class="text-sm d-block text-primary">Add Notes</a>
												  </td>
												  <td class="text-center"><span class="text-muted">20</span></td>
												  <td class="qty">
													<div class="input-group mb-0">
													  <div class="input-group-prepend cursor-pointer">
														<span class="input-group-text" id="qty-minus">-</span>
													  </div>
													  <input type="text" class="form-control form-control-sm" id="inputqty" value="2">
													  <div class="input-group-append cursor-pointer">
														<span class="input-group-text" id="qty-add">+</span>
													  </div>
													</div>
												  </td>
												  <td class="text-right">
													<b>1200.00</b>
													<span class="text-sm d-block text-muted">60.00</span>
												  </td>
												  <td class="text-right">
													<a href="#" class="btn btn-outline-danger btn-sm text-sm"><i class="fa fa-times"></i></a>
												  </td>
												</tr>
												<tr>
												  <td>
													<b>Vanila</b>
													<a href="#" class="text-sm d-block text-primary">Add Notes</a>
												  </td>
												  <td class="text-center"><span class="text-muted">15</span></td>
												  <td class="qty">
													<div class="input-group mb-0">
													  <div class="input-group-prepend cursor-pointer">
														<span class="input-group-text" id="qty-minus">-</span>
													  </div>
													  <input type="text" class="form-control form-control-sm" id="inputqty" value="2">
													  <div class="input-group-append cursor-pointer">
														<span class="input-group-text" id="qty-add">+</span>
													  </div>
													</div>
												  </td>
												  <td class="text-right">
													<b>1500.00</b>
													<span class="text-sm d-block text-muted">100.00</span>
												  </td>
												  <td class="text-right">
													<a href="#" class="btn btn-outline-danger btn-sm text-sm"><i class="fa fa-times"></i></a>
												  </td>
												</tr>
												<tr>
												  <td>
													<b>Butterscotch</b>
													<a href="#" class="text-sm d-block text-primary">Add Notes</a>
												  </td>
												  <td class="text-center"><span class="text-muted">10</span></td>
												  <td class="qty">
													<div class="input-group mb-0">
													  <div class="input-group-prepend cursor-pointer">
														<span class="input-group-text" id="qty-minus">-</span>
													  </div>
													  <input type="text" class="form-control form-control-sm" id="inputqty" value="2">
													  <div class="input-group-append cursor-pointer">
														<span class="input-group-text" id="qty-add">+</span>
													  </div>
													</div>
												  </td>
												  <td class="text-right">
													<b>1500.00</b>
													<span class="text-sm d-block text-muted">150.00</span>
												  </td>
												  <td class="text-right">
													<a href="#" class="btn btn-outline-danger btn-sm text-sm"><i class="fa fa-times"></i></a>
												  </td>
												</tr>
												<tr>
												   <td colspan="5">
													<div class="d-flex justify-content-between">
														<div><p class="font-weight-bold mb-0"><span class="text-muted">Total Items</span> 4</p></div>
														<div><p class="font-weight-bold mb-0"><span class="text-muted">Total Qty.</span> 8</p></div>
														<div><p class="font-weight-bold mb-0">Grand Total</p></div>
														<div><p class="font-weight-bold mb-0">₹ 4,720.00</p></div>
													</div>
												   </td>
												</tr>
												<tr>
												   <td colspan="5">
													<div class="d-flex justify-content-between">
														<div></div>
														<div></div>
														<div>
															<p class="font-weight-bold text-sm mb-0">Item Total</p>
															<p class="font-weight-bold text-sm mb-0">Taxes</p>
															<p class="font-weight-bold text-sm mb-0">Discount</p>
															<p class="font-weight-bold text-sm mb-0">Round Off</p>
														</div>
														<div class="text-right">
															<p class="font-weight-bold text-sm mb-0">₹ 4,000.00</p>
															<p class="font-weight-bold text-sm mb-0">₹ 720.00</p>
															<p class="font-weight-bold text-sm mb-0">₹ -0.00</p>
															<p class="font-weight-bold text-sm mb-0">₹ -0.00</p>
														</div>
													</div>
												   </td>
												</tr>
											  </tbody>
											</table> 
											<hr />
											<div class="d-flex align-items-center mb-3">
												<div>
													<div class="form-check form-check-inline">
													  <input class="form-check-input" type="radio" name="cash" id="cash" value="Cash">
													  <label class="form-check-label" for="cash">Cash</label>
													</div>
													<div class="form-check form-check-inline">
													  <input class="form-check-input" type="radio" name="card" id="card" value="Card">
													  <label class="form-check-label" for="card">Card</label>
													</div>
													<div class="form-check form-check-inline">
													  <input class="form-check-input" type="radio" name="other" id="other" value="Other">
													  <label class="form-check-label" for="other">Other</label>
													</div>
												</div>
												<div>
													<div class="form-group mb-0 mx-2">
														<select class="form-control form-control-sm">
														  <option>Paytm</option>
														  <option>Gpay</option>
														  <option>PhonePay</option>
														</select>
													</div>
												</div>
												<div>
													<a href="#" class="btn btn-sm btn-outline-primary py-1 mx-2">Part</a>
												</div>
											</div>
											<hr />
											<div class="row">
												<div class="col-sm-6">
													<div class="form-group">
														<select class="form-control">
														  <option>Select Type</option>
														</select>
													</div>
												</div>
												<div class="col-sm-6">
													<div class="form-group">
														<select class="form-control">
														  <option>Attender Name</option>
														</select>
													</div>
												</div>
												<div class="col-sm-6">
												  <div class="form-group mb-0">
													<input type="text" class="form-control" placeholder="Given By">
												  </div>
												</div>
											</div>
										</div>
										<div class="tab-pane" id="customer" role="tabpanel">
											<form>
												<div class="row">
													<div class="col-sm-6">
													  <div class="form-group">
														<input type="text" class="form-control" placeholder="Customer Mobile #">
													  </div>
													</div>
													<div class="col-sm-6">
													  <div class="form-group">
														<input type="text" class="form-control" placeholder="Customer Name">
													  </div>
													</div>
													<div class="col-sm-12">
													  <div class="form-group">
														<textarea class="form-control" placeholder="Delivery Address" rows="2"></textarea>
													  </div>
													</div>
													<div class="col-sm-6">
													  <div class="form-group">
														<input type="text" class="form-control" placeholder="GST/TAX No.">
													  </div>
													</div>
													<div class="col-sm-12">
														<h5 class="h6 font-weight-bold text-secondary">Discount</h5>
														<div class="alert alert-warning py-1 px-3 text-sm my-3" role="alert">
														  * Discount is available only if the grand total is above ₹ 100.
														</div>
													</div>
													<div class="col-sm-8">
														<div class="form-group">
															<select class="form-control">
															  <option>Select Discount Attender</option>
															</select>
														</div>
													</div>
													<div class="col-sm-4">
													  <div class="input-group">
														<input type="text" class="form-control" placeholder="...." >
														<div class="input-group-append">
														  <span class="input-group-text">✓</span>
														</div>
													  </div>
													</div>
												</div>
											</form>
											<div class="d-flex align-items-center justify-content-between px-2">
												<div>
												  <p class="mb-0 font-weight-bold">Discount %</p>
												</div>
												<div>
												  <p class="mb-0 font-weight-bold">Discount Value: 0</p>
												</div>
												<div>
												  <p class="mb-0 font-weight-bold">Discount 0.00 %</p>
												</div>
											</div>
										</div>
										<div class="tab-pane" id="KOT" role="tabpanel">
											 <table class="table table-sm table-v-middle">
											  <thead>
												<tr>
												  <th>Items</th>
												  <th class="text-center">Qty.</th>
												  <th class="text-right">Price(₹)</th>
												   
												</tr>
											  </thead>
											  <tbody>
												<tr>
												  <td>
													<b>Pistha Ice-cream</b>
													<a href="#" class="text-sm d-block text-primary">Add Notes</a>
												  </td>
												  <td class="text-center"><span class="text-muted">2</span></td>
												  <td class="text-right">
													<b>100.00</b>
													<span class="text-sm d-block text-muted">4400.00</span>
												  </td>
												  
												</tr>
												 <tr>
												  <td>
													<b>Chocolate Ice-cream</b>
													<a href="#" class="text-sm d-block text-primary">Add Notes</a>
												  </td>
												  <td class="text-center"><span class="text-muted">2</span></td>
												  <td class="text-right">
													<b>120.00</b>
													<span class="text-sm d-block text-muted">60.00</span>
												  </td>
												  
												</tr>
												<tr>
												   <td colspan="5">
													<div class="d-flex justify-content-between">
														<div><p class="font-weight-bold mb-0"><span class="text-muted">Total Items</span> 4</p></div>
														<div><p class="font-weight-bold mb-0"><span class="text-muted">Total Qty.</span> 8</p></div>
														<div><p class="font-weight-bold mb-0">Grand Total</p></div>
														<div><p class="font-weight-bold mb-0">₹ 4,720.00</p></div>
													</div>
												   </td>
												</tr>
												<tr>
												   <td colspan="5">
													<div class="d-flex justify-content-between">
														<div></div>
														<div></div>
														<div>
															<p class="font-weight-bold text-sm mb-0">Item Total</p>
															<p class="font-weight-bold text-sm mb-0">Taxes</p>
														</div>
														<div class="text-right">
															<p class="font-weight-bold text-sm mb-0">₹ 4,000.00</p>
															<p class="font-weight-bold text-sm mb-0">₹ 720.00</p>
														</div>
													</div>
												   </td>
												</tr>
											  </tbody>
											</table> 
										</div>
									</div>
								  </div>
								  <div class="card-footer bg-white py-2 hold-items">
									<button type="button" class="btn btn-sm btn-outline-warning">1 - Arun <span class="float-right text-md ml-3">×</span></button>
								  </div>
								  <div class="card-footer">
									  <div class="d-flex align-items-center justify-content-between px-2">
										<div>
										  <button type="button" class="btn btn-sm btn-outline-warning">Hold Bill</button>
										  <button type="button" class="btn btn-sm btn-link">Clear</button>
										</div>
										<div>
										  <button type="button" class="btn btn-sm btn-primary">Split</button>
										  <button type="button" class="btn btn-sm btn-primary">KOT</button>
										  <button type="button" class="btn btn-sm btn-primary">Print</button>
										  <button type="button" class="btn btn-sm btn-primary">Save</button>
										</div>
									  </div>
								  </div>
								</div>
							</div>
                        </div>
                    </div>
				</div>
                <!-- /.container-fluid -->

            </div>
            <!-- End of Main Content -->
		
		</div>
        <!-- End of Content Wrapper -->
    </div>
    <!-- End of Page Wrapper -->

    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
        <i class="fas fa-angle-up"></i>
    </a>
	
    <!-- Script-->
    <script type="text/javascript" src="./vendor/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="./vendor/jquery-easing/jquery.easing.min.js"></script>
    <script type="text/javascript" src="./vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="./js/script.js"></script>

    </form>
</body>

</html>
