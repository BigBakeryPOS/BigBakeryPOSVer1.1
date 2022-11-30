<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home_Page.aspx.cs" Inherits="Billing.Accountsbootstrap.Home_Page" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    <link href="../css/dashboard.css" rel="stylesheet">
    <!-- ubi style -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
    <script type="text/javascript">
        function printGrid() {

            var gridData = document.getElementById('saless');
            var windowUrl = 'about:blank';

            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
    <script type="text/javascript">
        function alertMessage() {
            alert('Mail Sent Successfully!');
        }
    </script>
    <style type="text/css">
        .blink {
            text-decoration: blink;
        }
    </style>
    <style type="text/css">
        blink, .blink {
            animation: blinker 3s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label">Welcome : </asp:Label>
        <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
        <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <div style="margin-top: 0px">
            <div align="center">
                <h2>
                    <label style="color: Red">
                        Welcome To
                        <label id="Company" runat="server"></label>
                    </label>
                </h2>
                <div style="margin-top: 0px">
                    <h2>
                        <asp:Label ID="lblmotivation" Visible="false" runat="server" Font-Bold="true" Font-Names="Calibri"></asp:Label>
                    </h2>
                </div>
            </div>
        </div>
        <div id="wrapper">
            <!-- /.row -->
            <div class="col-lg-12 col-md-12">
                
                <div class="col-lg-4">
                    <div class="panel panel-custom1">
                        <div class="panel panel-header">
                            <span style="font-palette: light; font-family: Calibri; font-size: medium; color: grey">
                                <b>Supplier Outstanding :</b> <b>
                                    <asp:Label ID="lblSuppOS" runat="server" Text="0"></asp:Label>
                                </b></span>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gvSupplier" runat="server" OnRowDataBound="gvSupplier_OnRowDataBound" AutoGenerateColumns="false" CssClass="table table-pos-bill table-bordered table-responsive table-striped">
                                <Columns>
                                    <asp:BoundField HeaderText="Supplier Name" DataField="CustomerName" />
                                    <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                    <asp:BoundField HeaderText="Outstanding" DataField="Balance" />
                                    <asp:BoundField HeaderText="Pay Mode" DataField="PayType" Visible="false" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-custom1">
                        <div class="panel panel-header">
                            <span style="font-palette: light; font-family: Calibri; font-size: medium; color: grey">
                                <b>Today Rawmaterial transfer Amount to production :</b> </span>
                        </div>
                        <div class="panel-body">
                            <b>
                                <asp:Label ID="lblRawTransAmount" runat="server" Text="0"></asp:Label>
                            </b>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="panel panel-custom1">
                        <div class="panel panel-header">
                            <span style="font-palette: light; font-family: Calibri; font-size: medium; color: grey">
                                <b>Today Rawmaterial transfer Amount to Branch :</b> </span>
                        </div>
                        <div class="panel-body">
                            <b>
                                <asp:Label ID="lblRawTransAmountBranch" runat="server" Text="0"></asp:Label>
                            </b>
                        </div>
                    </div>
                </div>
                         <div class="col-lg-4">
                    <div class="panel panel-custom1">
                        <div class="panel panel-header">
                            <span style="font-palette: light; font-family: Calibri; font-size: medium; color: grey">
                                <b>Current Stock Value :</b> </span>
                        </div>
                        <div class="panel-body">
                            <b>
                                <asp:Label ID="lblStockValue" runat="server" Text="0"></asp:Label>
                            </b>
                        </div>
                    </div>
                </div>
                 <div class="col-lg-4">
                    <div class="panel panel-custom1">
                        <div class="panel panel-header">
                            <span style="font-palette: light; font-family: Calibri; font-size: medium; color: grey">
                                <b>Today Expense :</b> </span>
                        </div>
                        <div class="panel-body">
                            <b>
                                <asp:Label ID="lblExpAmount" runat="server" Text="0"></asp:Label>
                            </b>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="padding-left: 20px; padding: 20px; display: none">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-line-chart" style="font-size: 100px"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div id="IDTodaySales" runat="server">
                                        <h3>Rs.500000 Today's Sales:
                                            <asp:Label ID="Label35" runat="server" Text="0"></asp:Label>
                                        </h3>
                                    </div>
                                    <div id="IDTodaySalesCount" runat="server">
                                        <h3>Today's Sales:
                                            <asp:Label ID="lblSalesCount" runat="server" Text="0"></asp:Label>
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="CustomerSalesReport.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Details</span> <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix">
                                </div>
                            </div>
                        </a>
                    </div>
                </div>



            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

                    <div runat="server" visible="false" style="margin-top: 10px">
                        <div>
                            <div>
                                <div>
                                    <div>
                                        <div align="center">
                                            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                <ProgressTemplate>
                                                    <div class="overlay">
                                                        <div style="z-index: 1000; margin-left: 350px; margin-top: 200px; opacity: 1; -moz-opacity: 1;">
                                                            <img alt="" src="../images/Preloader_10.gif" />
                                                        </div>
                                                    </div>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <div align="center">
                                                <blink>
                                                    <label style="color: Red">Every 5 min Screen Will Refresh. Thank YOU!!!</label></blink>
                                            </div>
                                            <hr />
                                            <blink>
                                                <label style="color: Red">Billing Level</label></blink>
                                            <table style="margin-top: 8px; padding-top: 10px">
                                                <tr align="center" visible="true">
                                                    <td style="display: none">
                                                        <label>
                                                            <h2>HOME</h2>
                                                        </label>
                                                        <asp:Label ID="lbl_Total_Sales_Amt" runat="server">0.00</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="tdmsg" runat="server" visible="true" valign="top">
                                                        <table style="background-color: #f9ee9e" align="center">
                                                            <tr>
                                                                <td valign="top" visible="true" style="display: none">
                                                                    <label cssclass="form-control">
                                                                        Send Messege</label>
                                                                    <asp:TextBox TextMode="MultiLine" ID="txtMsg" runat="server" CssClass="form-control"
                                                                        Height="100px"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control" Visible="true">
                                                                        <asp:ListItem Text="KK Nagar" Value="5">  </asp:ListItem>
                                                                        <asp:ListItem Text="Bye Pass" Value="6">  </asp:ListItem>
                                                                        <asp:ListItem Text="BB Kulam" Value="7">  </asp:ListItem>
                                                                        <asp:ListItem Text="GN MILLS" Value="11">  </asp:ListItem>
                                                                        <asp:ListItem Text="Nellai" Value="14">  </asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddProduction" runat="server" CssClass="form-control" Visible="true">
                                                                        <asp:ListItem Text="MDu Production" Value="10">  </asp:ListItem>
                                                                        <asp:ListItem Text="Nellai Production" Value="15">  </asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="top" visible="true" style="display: none">
                                                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" placeholder="Messege End Date"></asp:TextBox>
                                                                    <asp:DropDownList ID="ddlHours" runat="server" Width="70px">
                                                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlMinutes" runat="server" Width="70px">
                                                                        <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                        <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                                        <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlMeridian" runat="server" Width="70px">
                                                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <ajaxToolkit:CalendarExtender ID="calender" Format="yyyy-MM-dd" runat="server" PopupPosition="BottomLeft"
                                                                        CssClass="cal_Theme1" TargetControlID="txtEndDate">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                </td>
                                                                <td>
                                                                    <tr style="display: none">
                                                                        <td colspan="2" style="background-color: Green; color: White">
                                                                            <label style="font-weight: bolder">
                                                                                Normal sales</label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none">
                                                                        <td>
                                                                            <asp:Label ID="lblCash_sales" runat="server">Cash Sales</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCash_sales_Amt" runat="server">0.00</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none">
                                                                        <td style="background-color: Red; color: White" colspan="2">
                                                                            <label style="font-weight: bolder">
                                                                                Order Form sales</label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none">
                                                                        <td>
                                                                            <asp:Label ID="lblOrder_sales" runat="server">Order Form Sales</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblOrder_sales_amt" runat="server">0.00</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none">
                                                                        <td>
                                                                            <asp:Label ID="Label4" runat="server">Order Form Card Sales</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblordercard" runat="server">0.00</asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none">
                                                                <td>
                                                                    <asp:Button ID="btnmsg" runat="server" Text="Send" CssClass="btn-danger" OnClick="btnmsg_Click"
                                                                        nClientClick="showProgress()" />
                                                                    <asp:Label ID="lblsucess" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnStock" runat="server" Text="Stock Transfer" OnClick="btnStock_Click1"
                                                            Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvmsg" runat="server" AllowPaging="true" PageSize="5" Caption="Sent Messege"
                                                            CssClass="mGrid" AutoGenerateColumns="false" OnRowCommand="gvmsg_RowCommand">
                                                            <HeaderStyle BackColor="#3366FF" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="ID" DataField="Id" Visible="false" />
                                                                <asp:BoundField HeaderText="Date" DataField="Date" />
                                                                <asp:BoundField HeaderText="Messege" DataField="Messege" />
                                                                <asp:BoundField HeaderText="To" DataField="Branchcode" />
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                                            CommandName="delete">
                                                                            <asp:Image ID="img" runat="server" ImageUrl="~/images/delete.png" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:GridView ID="gvSales" runat="server" Caption="Sales Details" Visible="true"
                                                            AutoGenerateColumns="false" CssClass="mGrid" Font-Names="Comic Sans MS" RowStyle-BorderStyle="Double"
                                                            HeaderStyle-HorizontalAlign="Center">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Store" DataField="Branch" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Bill No" DataField="BillNo" ItemStyle-HorizontalAlign="Center"
                                                                    HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Bill Date" DataField="BillDate" ItemStyle-HorizontalAlign="Center"
                                                                    DataFormatString="{0:dd/mm/yyyy}" HtmlEncode="false" />
                                                                <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Center"
                                                                    Visible="false" />
                                                                <asp:BoundField HeaderText="Advance Amount" DataField="Advance" DataFormatString='{0:f}'
                                                                    Visible="false" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Net Amount" DataField="NetAmount" DataFormatString='{0:f}'
                                                                    ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}'
                                                                    Visible="false" ItemStyle-HorizontalAlign="Right" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr align="center" valign="top">
                                                    <td>
                                                        <asp:GridView CssClass="mGrid" ID="gvPending" Caption="Customer Pending Amount" runat="server"
                                                            AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Bill No" DataField="billno" />
                                                                <asp:BoundField HeaderText="Customer Name" DataField="Customername" />
                                                                <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" DataFormatString='{0:f}' />
                                                                <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount" DataFormatString='{0:f}' />
                                                                <asp:BoundField HeaderText="Balance Amount" DataField="Balance" DataFormatString='{0:f}' />
                                                                <asp:TemplateField HeaderText="Pay" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="ntnpay" runat="server" CommandName="Pay" CommandArgument='<%#Eval("billno") %>'
                                                                            Text="PAY"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="gvReturns" Caption="Today's Returned Items" runat="server" CssClass="mGrid"
                                                            AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                                <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                                                <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <label id="lblCustpending" runat="server" style="margin-left: 150px" visible="false">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="gvOrder" Caption="Today Booked Orders" runat="server" AllowPaging="true"
                                                            PageSize="15" CssClass="mGrid" AutoGenerateColumns="false">
                                                            <HeaderStyle BackColor="#990100" />
                                                            <PagerSettings FirstPageText="1" Mode="Numeric" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="CustomerOrderNo" DataField="OrderNO" />
                                                                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                                <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                                                                <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                                                <asp:BoundField HeaderText="TotalAmount" DataField="NetAmount" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString="{0:###,##0.00}"
                                                                    Visible="false" />
                                                                <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                                <asp:TemplateField HeaderText="Print" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNO") %>' CommandName="Print"
                                                                            runat="server">
                                                                            <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="55px" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <label id="Label1" runat="server" style="margin-left: 150px" visible="false">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="gvsalesAll" Caption="Today Sales" runat="server" CssClass="mGrid"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle BackColor="#990100" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Branch" DataField="Branch" />
                                                                <asp:BoundField HeaderText="BillCount" DataField="TotalCount" />
                                                                <asp:BoundField HeaderText="TotalAmont" DataField="Total" DataFormatString="{0:###,##0.00}" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="gvTomcustomer" Caption="To be deliver tomorrow - Customer Orders"
                                                            Visible="false" runat="server" AllowPaging="true" PageSize="10" CssClass="mGrid"
                                                            AutoGenerateColumns="false" OnRowCommand="gvTomcustomer_RowCommand">
                                                            <PagerSettings FirstPageText="1" Mode="Numeric" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="userID" DataField="UserID" Visible="false" />
                                                                <asp:BoundField HeaderText="CustomerOrderNo" DataField="OrderNO" />
                                                                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                                <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                                                                <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                                                <asp:BoundField HeaderText="TotalAmount" DataField="NetAmount" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                                <asp:TemplateField HeaderText="Print" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNO") %>' CommandName="Print"
                                                                            runat="server">
                                                                            <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="55px" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnView" CommandArgument='<%#Eval("OrderNO")+";"+Eval("UserID") %>'
                                                                            CommandName="View" runat="server">
                                                                            <asp:Image ID="imgView" runat="server" ImageUrl="~/images/info_button.png" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="gvOrderDet" Style="font-weight: bold" runat="server" AutoGenerateColumns="false"
                                                            Caption="Order Details" CssClass="mGrid">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Store" DataField="Store" />
                                                                <asp:BoundField HeaderText="Group" DataField="Category" />
                                                                <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                                <asp:BoundField HeaderText="Qty(Kgs)" DataField="Quantity" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <label id="Label2" runat="server" style="margin-left: 150px" visible="false">
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView1" Caption="To be deliver tomorrow - Customer Orders" runat="server"
                                                            AllowPaging="true" PageSize="10" CssClass="mGrid" AutoGenerateColumns="false"
                                                            OnRowCommand="gvTomcustomer_RowCommand">
                                                            <PagerSettings FirstPageText="1" Mode="Numeric" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="userID" DataField="UserID" Visible="false" />
                                                                <asp:BoundField HeaderText="CustomerOrderNo" DataField="OrderNO" />
                                                                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                                <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                                                                <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                                                <asp:BoundField HeaderText="TotalAmount" DataField="NetAmount" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString="{0:###,##0.00}" />
                                                                <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                                <asp:TemplateField HeaderText="Print" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNO") %>' CommandName="Print"
                                                                            runat="server">
                                                                            <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="55px" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnView" CommandArgument='<%#Eval("OrderNO")+";"+Eval("UserID") %>'
                                                                            CommandName="View" runat="server">
                                                                            <asp:Image ID="imgView" runat="server" ImageUrl="~/images/info_button.png" />
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                    <td>
                                                        <asp:GridView ID="GridView2" Style="font-weight: bold" runat="server" AutoGenerateColumns="false"
                                                            Caption="Order Details" CssClass="mGrid">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Store" DataField="Store" />
                                                                <asp:BoundField HeaderText="Group" DataField="Category" />
                                                                <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                                <asp:BoundField HeaderText="Qty(Kgs)" DataField="Quantity" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr style="font-size: larger">
                                                    <td>
                                                        <label id="lblAmount" visible="false" runat="server">
                                                        </label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <hr />
                                            <blink>
                                                <label style="color: Red">Store Level</label></blink>
                                            <br />
                                            <hr />
                                            <blink>
                                                <label style="color: Red">Production Level</label></blink>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div runat="server" visible="false" class="col-lg-12">
                        <div class="col-lg-12 col-md-6">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class=" text-center glyphicon glyphicon-shopping-cart" style="font-size: 80px"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="hidden">
                                                <asp:Label ID="Label7" Text="Counter sales:" runat="server"></asp:Label>
                                                <b>
                                                    <asp:Label ID="lblsales" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                <asp:Label ID="Label9" Text="Cake Orders Sales:" runat="server"></asp:Label>
                                                <b>
                                                    <asp:Label ID="lblorder" ForeColor="White" Text="Rs 0.00" runat="server"></asp:Label></b>
                                            </div>
                                            <div runat="server" id="saless" class="huge">
                                                <asp:GridView Visible="false" ID="GridView3" runat="server">
                                                </asp:GridView>
                                                <div align="left">
                                                    <label style="font-size: large">
                                                        Total Sale's:</label><br />
                                                    <%--//BILL COUNT--%>
                                                    <asp:Label ID="Label6" Text="Today's Total Bill Count:" runat="server"></asp:Label>
                                                    <b>
                                                        <asp:Label ID="lbltotalsalescount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                    <asp:Label ID="Label17" Text="Today's Total Amount:" runat="server"></asp:Label>
                                                    <b>
                                                        <asp:Label ID="lbltotalamountt" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                    <%--//ORDER COUNT--%>
                                                    <asp:Label ID="Label3" Text="Today's Cake Order Bills: " runat="server"></asp:Label>
                                                    <b>
                                                        <%--<asp:Label ID="lblTodaybillcancel"  runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lbltodaycakeorder" runat="server"></asp:Label></b>
                                                    <br />
                                                    <asp:Label ID="Label5" Text="Today's Cake Order Amount:" runat="server"></asp:Label>
                                                    <b>
                                                        <asp:Label ID="lbltodaycakeamount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                    <%--//CANCEL COUNT--%>
                                                    <asp:Label ID="Label11" Text="Today's Cancelled Bills: " runat="server"></asp:Label>
                                                    <b>
                                                        <%--<asp:Label ID="lblTodaybillcancel"  runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lbltodaycancelbillcount" runat="server"></asp:Label></b>
                                                    <br />
                                                    <asp:Label ID="Label30" Text="Today's Cancel Amount:" runat="server"></asp:Label>
                                                    <b>
                                                        <asp:Label ID="lblcancelamount" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                </div>
                                                <div align="left">
                                                    <label style="font-size: large">
                                                        Amount Details:</label><br />
                                                    <asp:Label ID="Label13" Text="Today's Total Cash Amount:" runat="server"></asp:Label>
                                                    <b>
                                                        <asp:Label ID="lbltotaltodaycashamnt" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                    <asp:Label ID="Label28" Text="Today's Total Card Amount:" runat="server"></asp:Label>
                                                    <b>
                                                        <asp:Label ID="lbltotaltodaycardamnt" Text="Rs 0.00" runat="server"></asp:Label></b><br />
                                                </div>
                                            </div>
                                            <div class="">
                                                <h3>Sales</h3>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnprint" runat="server" Text="print" OnClientClick="printGrid()"
                                            ForeColor="Black" />
                                        <asp:Button ID="btnemail" runat="server" Text="E-Mail" OnClick="btnMail_Click" ForeColor="Black" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>


</body>
</html>
