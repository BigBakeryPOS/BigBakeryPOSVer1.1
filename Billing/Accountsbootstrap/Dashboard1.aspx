<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard1.aspx.cs" Inherits="Billing.Accountsbootstrap.Dashboard1" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>

     <%--<%@ Register TagPrefix="usc" TagName="Header" Src="Header.ascx" %>--%>
<%--<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/HeaderTop.ascx" %>
--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Dashboard</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for statistics, charts, recent events and reports"
        name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
        rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
        rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="style_components"
        type="text/css" />
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css"
        id="style_color" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <script type="text/javascript">
        function goBack() {
            window.history.back();
        }
    </script>
    <style>
        .button
        {
            background-color: #217EBD; /* Green */
            border: none;
            color: white;
            padding: 5px 12px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 17px;
            font-weight: bolder;
            margin: 4px 2px;
            cursor: pointer;
        }
    </style>
</head>
<!-- END HEAD -->
<%--<body class="page-container-bg-solid page-header-fixed page-sidebar-closed-hide-logo page-md page-sidebar-closed">--%>
<%--<body class="page-sidebar-closed-hide-logo page-container-bg-solid page-md">--%>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
  <usc:Header ID="Header1" runat="server" />
<%--    <usc2:Header2 ID="Header2" runat="server" />--%>
    <div class="clearfix">
    </div>
    <!-- BEGIN HEADER -->
    <!-- END HEADER -->
    <!-- BEGIN HEADER & CONTENT DIVIDER -->
    <div class="clearfix">
    </div>
    <!-- END HEADER & CONTENT DIVIDER -->
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
        <%--<usc:Header ID="Header" runat="server" />--%>
        <form id="f1" runat="server">
        <asp:ScriptManager ID="SM" runat="server">
        </asp:ScriptManager>
        <!-- BEGIN SIDEBAR -->
        <!-- END SIDEBAR -->
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <!-- BEGIN PAGE HEADER-->
                <!-- BEGIN THEME PANEL -->
                <!-- END THEME PANEL -->
                <h1 class="page-title">
                    Admin Dashboard <small>statistics, charts, recent events and reports</small>
                </h1>
                <!-- END PAGE HEADER-->
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <a class="dashboard-stat dashboard-stat-v2 blue" href="#">
                            <div class="visual">
                                <i class="fa fa-comments"></i>
                            </div>
                            <div class="details">
                                <div class="number">
                                    <asp:Label ID="txtTodaysOrder" runat="server"></asp:Label>
                                </div>
                                <div class="desc">
                                    Todays Order
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <a class="dashboard-stat dashboard-stat-v2 red" href="#">
                            <div class="visual">
                                <i class="fa fa-bar-chart-o"></i>
                            </div>
                            <div class="details">
                                <div class="number">
                                    <asp:Label ID="txtSalesAmount" runat="server"></asp:Label>
                                </div>
                                <div class="desc">
                                    Total Sales Amount
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <a class="dashboard-stat dashboard-stat-v2 green" href="#">
                            <div class="visual">
                                <i class="fa fa-shopping-cart"></i>
                            </div>
                            <div class="details">
                                <div class="number">
                                    <asp:Label ID="txtLastOrderNo" runat="server"></asp:Label>
                                </div>
                                <div class="desc">
                                    Last Order No
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                        <a class="dashboard-stat dashboard-stat-v2 purple" href="#">
                            <div class="visual">
                                <i class="fa fa-globe"></i>
                            </div>
                            <div class="details">
                                <div class="number">
                                    +
                                    <asp:Label ID="txtNewCustomer" runat="server"></asp:Label>
                                </div>
                                <div class="desc">
                                    Today New Customers
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <!-- END DASHBOARD STATS 1-->
                <div class="row">
                    <div class="col-md-6">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-dark">
                                    <div class="row">
                                    
                                        <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                            Top 10 Customers</span> <span class="label label-sm label-info"><a href="BuyerOrderReport.aspx"
                                                style="color: White; font-weight: bold">View Reports</a></span>
                                                <br />

                                                  <div class="col-lg-2">
                                                <label style="color: #428bca">
                                                    Filter By Branch</label>
                                                <asp:DropDownList Class="form-control select2" data-filter="true" ID="ddlBranch"
                                                    runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-lg-2">
                                                <label style="color: #428bca">
                                                    Payment Mode</label>
                                                <asp:DropDownList ID="drpPayment" runat="server"
                                                    AutoPostBack="true" Class="form-control select2" data-filter="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label for="form_control_1" style="color: #428bca">
                                                        From Date</label>
                                                    <div class="input-group  date date-picker" data-date-format="yyyy-mm-dd 
                                                    data-date-viewmode="years">
                                                        <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="TextBox1">
                                                </asp:TextBox>
                                                  <span class="input-group-btn">
                                                            <button class="btn default" type="button" style="height: 33px; margin-top: -2px;">
                                                                <i class="fa fa-calendar"></i>
                                                            </button>
                                                        </span>
                                                        <asp:TextBox CssClass="form-control" ID="txtfromdate" runat="server"  
                                                            autocomplete="off"></asp:TextBox>
                                                      
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-2">
                                                 
                                                  <div class="form-group">
                                                    <label for="form_control_1" style="color: #428bca">
                                                        To Date</label>
                                                    <div class="input-group  date date-picker" data-date-format="yyyy-mm-dd"
                                                        data-date-viewmode="years">
                                                        <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="TextBox2">
                                                </asp:TextBox>
                                                 <span class="input-group-btn">
                                                            <button class="btn default" type="button" style="height: 33px; margin-top: -2px;">
                                                                <i class="fa fa-calendar"></i>
                                                            </button>
                                                        </span>
                                                        <asp:TextBox CssClass="form-control" ID="txttodate" runat="server"  
                                                            autocomplete="off"></asp:TextBox>
                                                       
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group" style="    margin-top: 15px;">
                                                <label for="form_control_1" style="margin-left: 88px;">
                                                    Year Code</label>
                                                <asp:DropDownList ID="drpYearCode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpState_SelectedIndexChanged" Class="form-control select2" >
                                                    <asp:ListItem Text="2021-2022" Value="21-22"> </asp:ListItem>
                                                    <asp:ListItem Text="2020-2021" Value="20-21"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="table-toolbar">
                                </div>
                                <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                    id="sample_3">
                                    <thead style="background: #0F3C5F; color: white;">
                                        <tr>
                                            <th style="display: none">
                                                <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                    <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                    <span></span>
                                                </label>
                                            </th>
                                            <th>
                                                Buyer Code
                                            </th>
                                            <th>
                                                Code
                                            </th>
                                            <th>
                                                Company Name
                                            </th>
                                            <th>
                                                Currency
                                            </th>
                                            <th>
                                                Amount
                                            </th>
                                            <th>
                                                Mobile No
                                            </th>
                                            <th>
                                                Phone No
                                            </th>
                                            <th>
                                                Area
                                            </th>
                                            <th>
                                                Email
                                            </th>
                                            <th>
                                                Contact Person
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Label ID="txtVillageSplitUp" runat="server"></asp:Label>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                    <div class="col-lg-6 col-xs-12 col-sm-12" style="display: none">
                        <!-- BEGIN PORTLET-->
                        <div class="portlet light " style="height: 390px;">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="icon-share font-red-sunglo hide"></i><span class="caption-subject font-dark bold uppercase">
                                        Revenue</span> <span class="caption-helper">monthly stats...</span>
                                </div>
                                <div class="actions">
                                    <div class="btn-group">
                                        <a href="" class="btn dark btn-outline btn-circle btn-sm dropdown-toggle" data-toggle="dropdown"
                                            data-hover="dropdown" data-close-others="true">Filter Range <span class="fa fa-angle-down">
                                            </span></a>
                                        <ul class="dropdown-menu pull-right">
                                            <li><a href="javascript:;">Q1 2020 <span class="label label-sm label-default">past </span>
                                            </a></li>
                                            <li><a href="javascript:;">Q2 2020 <span class="label label-sm label-default">past </span>
                                            </a></li>
                                            <li class="active"><a href="javascript:;">Q3 2020 <span class="label label-sm label-success">
                                                current </span></a></li>
                                            <li><a href="javascript:;">Q4 2020 <span class="label label-sm label-warning">upcoming
                                            </span></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div id="site_activities_loading">
                                    <img src="../assets/global/img/loading.gif" alt="loading" />
                                </div>
                                <div id="site_activities_content" class="display-none">
                                    <div id="site_activities" style="height: 228px;">
                                    </div>
                                </div>
                                <div style="margin: 20px 0 10px 30px">
                                    <div class="row">
                                        <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                            <span class="label label-sm label-success">Revenue: </span>
                                            <h3>
                                                Rs.13,234</h3>
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                            <span class="label label-sm label-info">Tax: </span>
                                            <h3>
                                                Rs.1,340</h3>
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                            <span class="label label-sm label-danger">Shipment: </span>
                                            <h3>
                                                Rs. 2,500</h3>
                                        </div>
                                        <div class="col-md-3 col-sm-3 col-xs-6 text-stat">
                                            <span class="label label-sm label-warning">Orders: </span>
                                            <h3>
                                                235</h3>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END PORTLET-->
                    </div>
                    <div class="col-md-6">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-dark">
                                    <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                        Top 10 Requirement </span><span class="label label-sm label-info"><a href="RequirementSheetDetails.aspx"
                                            style="color: White; font-weight: bold">View Reports</a></span>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="table-toolbar">
                                </div>
                                <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                    id="sample_5">
                                    <thead style="background: #0F3C5F; color: white;">
                                        <tr>
                                            <th style="display: none">
                                                <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                    <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                    <span></span>
                                                </label>
                                            </th>
                                            <th>
                                                Requirement Id
                                            </th>
                                            <th>
                                                Item Code
                                            </th>
                                            <th>
                                                Item Group Name
                                            </th>
                                            <th>
                                                Color
                                            </th>
                                            <th>
                                                Sample Qty
                                            </th>
                                            <th>
                                                Production Qty
                                            </th>
                                            <th>
                                                Units
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Label ID="lblRequirement" runat="server"></asp:Label>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-dark">
                                    <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                        Top 10 Item Stock</span> <span class="label label-sm label-info"><a href="StockStatementReport.aspx"
                                            style="color: White; font-weight: bold">View Reports</a></span>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="table-toolbar">
                                </div>
                                <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                    id="sample_1">
                                    <thead style="background: #0F3C5F; color: white;">
                                        <tr>
                                            <th style="display: none">
                                                <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                    <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                    <span></span>
                                                </label>
                                            </th>
                                            <th>
                                                Item Code
                                            </th>
                                            <th>
                                                Item Name
                                            </th>
                                            <th>
                                                Qty
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Label ID="lblStockDetails" runat="server"></asp:Label>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                    <div class="row">
                        <div class="col-lg-3" style="display: none">
                            <div class="stat-right">
                                <div class="stat-number">
                                    <div class="title">
                                        Find PO No:</div>
                                    <div class="form-group" id="ExcNo" runat="server" visible="true">
                                        <asp:TextBox ID="txtfabcontrast" CssClass="form-control" runat="server" Width="265px"
                                            placeholder="Find PONo" onkeyup="SearchEmployees(this,'#chkPONo');"></asp:TextBox>
                                        <div style="overflow-y: scroll; height: 100px">
                                            <div class="panel panel-default" style="width: 250px">
                                                <asp:CheckBoxList ID="chkPONo" CssClass="chkChoice1" runat="server" RepeatLayout="Table"
                                                    Style="overflow: auto">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                            Top 10 Pending Po</span> <span class="label label-sm label-info"><a href="PurchaseOrderPendingReport.aspx"
                                                style="color: White; font-weight: bold">View Reports</a></span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-toolbar">
                                    </div>
                                    <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                        id="sample_1_2">
                                        <thead style="background: #0F3C5F; color: white;">
                                            <tr>
                                                <th style="display: none">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                        <span></span>
                                                    </label>
                                                </th>
                                                <th>
                                                    Order Date
                                                </th>
                                                <th>
                                                    Po Number
                                                </th>
                                                <th>
                                                    Company Name
                                                </th>
                                                <th>
                                                    Purchase Type
                                                </th>
                                                <th>
                                                    QTY
                                                </th>
                                                <th>
                                                    Rec Qty
                                                </th>
                                                <th>
                                                    Bal Qty
                                                </th>
                                                <th>
                                                    Units
                                                </th>
                                                <th>
                                                    Code
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Label ID="lblPoPending" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="row">
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                            Top 10 Costing Details</span> <span class="label label-sm label-info"><a href="Homepage.aspx"
                                                style="color: White; font-weight: bold">View Reports</a></span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-toolbar">
                                    </div>
                                    <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                        id="sample_4">
                                        <thead style="background: #0F3C5F; color: white;">
                                            <tr>
                                                <th style="display: none">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                        <span></span>
                                                    </label>
                                                </th>
                                                <th>
                                                    Style No
                                                </th>
                                                <th>
                                                    Buyer Code
                                                </th>
                                                <th>
                                                    Description
                                                </th>
                                                <th>
                                                    Fabrication Cost
                                                </th>
                                                <th>
                                                    FinishingandPackingCost
                                                </th>
                                                <th>
                                                    ItemPrd Cost
                                                </th>
                                                <th>
                                                    Currency Name
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Label ID="lblCosting" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                            Top 10 Buyer Summery</span> <span class="label label-sm label-info"><a href="BuyerOrderSummaryReport.aspx"
                                                style="color: White; font-weight: bold">View Reports</a></span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-toolbar">
                                    </div>
                                    <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                        id="sample_2">
                                        <thead style="background: #0F3C5F; color: white;">
                                            <tr>
                                                <th style="display: none">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                        <span></span>
                                                    </label>
                                                </th>
                                                <th>
                                                    Buyer Name
                                                </th>
                                                <th>
                                                    Exc No
                                                </th>
                                                <th>
                                                    Style No
                                                </th>
                                                <th>
                                                    Description
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Label ID="lblBuyerSummary" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                            Top 10 Current Fabric</span> <span class="label label-sm label-info"><a href="CurrentFabricStatusReport.aspx"
                                                style="color: White; font-weight: bold">View Reports</a></span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-toolbar">
                                    </div>
                                    <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                        id="sample_10">
                                        <thead style="background: #0F3C5F; color: white;">
                                            <tr>
                                                <th style="display: none">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                        <span></span>
                                                    </label>
                                                </th>
                                                <th>
                                                    Exc.No
                                                </th>
                                                <th>
                                                    Item
                                                </th>
                                                <th>
                                                    Shipment Date
                                                </th>
                                                <th>
                                                    PO Date
                                                </th>
                                                <th>
                                                    Delivery Date
                                                </th>
                                                <th>
                                                    Qty
                                                </th>
                                                <th>
                                                    Rec Qty
                                                </th>
                                                <th>
                                                    Bal Qty
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Label ID="lblCurrentFabric" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                            Top 10 Shipment Details</span> <span class="label label-sm label-info"><a href="BuyerOrderWiseShipmentDetails.aspx"
                                                style="color: White; font-weight: bold">View Reports</a></span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-toolbar">
                                    </div>
                                    <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                        id="sample_11">
                                        <thead style="background: #0F3C5F; color: white;">
                                            <tr>
                                                <th style="display: none">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                        <span></span>
                                                    </label>
                                                </th>
                                                <th>
                                                    Exc.No
                                                </th>
                                                <th>
                                                    Style No
                                                </th>
                                                <th>
                                                    Item
                                                </th>
                                                <th>
                                                    Shipment Date
                                                </th>
                                                <th>
                                                    Color
                                                </th>
                                                <th>
                                                    Qty
                                                </th>
                                                <th>
                                                    size
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Label ID="lblBuyerOrder" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                        <div class="row">
                            <div class="col-lg-6 col-xs-12 col-sm-12" style="display: none">
                                <!-- BEGIN PORTLET-->
                                <div class="portlet light " style="height: 390px;">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="icon-share font-red-sunglo hide"></i><span class="caption-subject font-dark bold uppercase">
                                                Revenue</span> <span class="caption-helper">monthly stats...</span>
                                        </div>
                                    </div>
                                </div>
                                <!-- END PORTLET-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>
        <!-- END CONTENT -->
        <!-- BEGIN QUICK SIDEBAR -->
        <!-- END QUICK SIDEBAR -->
        </form>
    </div>
    <!-- END CONTAINER -->
    <!-- BEGIN FOOTER -->
    <div class="page-footer">
        <div class="page-footer-inner">
            2021 &copy; Bigdbiz Solutions Pvt Ltd
            <div class="scroll-to-top">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <!-- END FOOTER -->
        <!-- BEGIN QUICK NAV -->
        <!-- END QUICK NAV -->
        <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<script src="../assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <!-- END CONTAINER -->
        <!-- BEGIN FOOTER -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js"
            type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
            type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"
            type="text/javascript"></script>
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <%--<script src="../assets/pages/scripts/table-datatables-managedNew.min.js" type="text/javascript"></script>--%>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/profile.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/timeline.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
</body>
</html>
