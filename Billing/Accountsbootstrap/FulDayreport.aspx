<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FulDayreport.aspx.cs" Inherits="Billing.Accountsbootstrap.FulDayreport" %>

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
    <title>Over All Activity Reports</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById("div1");
            var windowUrl = 'about:blank';
            //set print document name for gridview
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
    <style type="text/css">
        .blink
        {
            text-decoration: blink;
        }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="Row">
        <div class="col-lg-12">
            <div class="col-lg-1">
            </div>
            <div runat="server" visible="false" class="col-lg-1">
                <div class="form-group">
                    <label>
                        Select Screen
                    </label>
                    <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control" AutoPostBack="true"
                        Width="125px" OnSelectedIndexChanged="ddltype_OnSelectedIndexChanged">
                        <asp:ListItem Text="Stock Return" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Payment Entry" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Staff Credit" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Sales Discount" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Sales Invoice" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Order Invoice" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div runat="server" visible="true" class="col-lg-2">
                <div class="form-group">
                    <label>
                        Select Paymode
                    </label>
                    <asp:DropDownList ID="drpPayment" runat="server" OnSelectedIndexChanged="drppayment_selectedindex"
                        AutoPostBack="true" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div runat="server" visible="false" class="form-group">
                    <label>
                        Reason
                    </label>
                    <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" Width="150px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label>
                        From Date</label>
                    <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" Width="150px">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label>
                        To Date</label>
                    <asp:TextBox runat="server" ID="txttodate" CssClass="form-control" Width="150px">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-1">
                <label>
                    Admin PassWord</label>
                <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" CssClass="form-control"
                    AutoPostBack="true" OnTextChanged="txtpassword_OnTextChanged" Width="140px" placeholder="Enter Password"></asp:TextBox>
                <asp:Label ID="lblpaymode" runat="server" Visible="false" Text="s.ipaymode <> ('15')"></asp:Label>
            </div>
            <div class="col-lg-1">
                <br />
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search"
                    Enabled="false" Width="120px" OnClick="btnSearch_Click" />
            </div>
            <div class="col-lg-1">
                <br />
                <asp:Button ID="btnExp" runat="server" Text="Export" CssClass="btn btn-danger" Width="120px"
                    Enabled="false" OnClick="btnexp_Click" />
            </div>
            <div class="col-lg-1">
                <br />
                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-warning"
                    Enabled="false" OnClientClick="printGrid()" Width="120px" />
            </div>
        </div>
    </div>
    <div id="div1" runat="server">
        <label>
            Detailed View</label>
        <div class="col-lg-12">
            <asp:GridView ID="gvCustsales" runat="server" AllowPaging="false" CssClass="" DataKeyNames="BillNo,typeid"
                Caption="Sales Report" ShowFooter="true" OnRowDataBound="gvCustsales_RowDataBound"
                AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="true" />
                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                    <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString='{0:dd/MM/yyyy}' />
                    <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Discount-Amount" DataField="Discount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Billed By" Visible="false" DataField="Provider" />
                    <asp:BoundField HeaderText="Approved by" Visible="false" DataField="Approved" />
                    <asp:BoundField HeaderText="Name" DataField="Customername" />
                    <asp:BoundField HeaderText="No" DataField="mobileno" />
                </Columns>
                <HeaderStyle BackColor="#428bca" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                    NextPageText="Next" PreviousPageText="Previous" />
            </asp:GridView>
            <asp:GridView ID="gvordersales" runat="server" AllowPaging="true" PageSize="100"
                Width="100%" CssClass="" Caption="Order Form Report" DataKeyNames="BillNo" ShowFooter="true"
                OnRowDataBound="gvordersales_RowDataBound" AutoGenerateColumns="false" EmptyDataText="No data found!"
                ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="true" />
                    <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString='{0:dd/MM/yyyy hh:mm:tt}' />
                    <asp:BoundField HeaderText="Tax" DataField="tax" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Tax-Amount" DataField="taxamount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Pay-Amount" DataField="Payamount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}'
                        Visible="false" />
                    <asp:BoundField HeaderText="Payment Type" DataField="PayType" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                    <asp:BoundField HeaderText="Order Entry Time" DataField="OrderTime" />
                </Columns>
                <HeaderStyle BackColor="#428bca" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                    NextPageText="Next" PreviousPageText="Previous" />
            </asp:GridView>
            <asp:GridView ID="gvsalescancel" runat="server" AllowPaging="true" PageSize="150"
                CssClass="mGrid" Caption="Sales Cancel report" DataKeyNames="BillNo" ShowFooter="true"
                 OnRowDataBound="gvsalescancel_RowDataBound"
                AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="true" />
                    <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
                    <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Discount-Amount" DataField="Discount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Cancelled By" DataField="Reference" />
                    <%--   <asp:BoundField HeaderText="Cancel Date" DataField="Canceltine"  />--%>
                </Columns>
                <HeaderStyle BackColor="#428bca" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                    NextPageText="Next" PreviousPageText="Previous" />
            </asp:GridView>
            <asp:GridView ID="gvOrderFormcancel" runat="server" PageSize="150" CssClass="mGrid" Caption="Order Form Cancel Report"
                AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                    <asp:BoundField HeaderText="Order No" DataField="Orderno" />
                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" />
                    <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate" />
                    <asp:BoundField HeaderText="Canceled Date" DataField="CancelDate" />
                    <asp:BoundField HeaderText="Mob No" DataField="MobileNo" />
                    <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="BookNo" DataField="BookNo" DataFormatString='{0:0}' />
                    <asp:BoundField HeaderText="Cancelled By" DataField="Cancelled" DataFormatString='{0:f}' />
                </Columns>
                <HeaderStyle BackColor="#990000" />
            </asp:GridView>
            <asp:GridView ID="GVSalesTaxReport" Caption="Sales Tax Details" runat="server" CssClass="mGrid"
                EmptyDataText="No Record Found!" OnRowDataBound="GVSalesTaxReport_OnRowDataBound"
                ShowFooter="true" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="SNo">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tax(%)" DataField="Tax" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="DisCount" DataField="DisCount" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="CGST" DataField="TaxValue" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="SGST" DataField="TaxValue" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="TotalAmont" DataField="Total" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                </Columns>
                <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            </asp:GridView>
            <asp:GridView ID="GVSalesQtyReport" Caption="Sales Item Qty Details" runat="server"
                AllowSorting="true" OnRowDataBound="GVSalesQtyReport_OnRowDataBound"
                EmptyDataText="No Record Found!" CssClass="mGrid" AutoGenerateColumns="false"
                ShowFooter="true" Width="100%">
                <HeaderStyle BackColor="#3366FF" />
                <PagerSettings FirstPageText="1" Mode="Numeric" />
                <Columns>
                    <asp:TemplateField HeaderText="SNo">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Category" DataField="Category" SortExpression="Category" />
                    <asp:BoundField HeaderText="Item" DataField="Definition" SortExpression="Definition" />
                    <asp:BoundField HeaderText="Quantity" DataField="Quantity" SortExpression="Quantity"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" SortExpression="Amount" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Discount" DataField="Disc" SortExpression="Disc" DataFormatString="{0:f2}"
                        ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="CGST" DataField="TaxAmount" SortExpression="TaxAmount"
                        DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="SGST" DataField="TaxAmount" SortExpression="TaxAmount"
                        DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" SortExpression="NetAmount"
                        DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                </Columns>
                <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            </asp:GridView>
            <asp:GridView ID="gvReturns" Caption="Stock Returned Report" runat="server" CssClass="mGrid"
                OnRowDataBound="gvReturns_OnRowDataBound" ShowFooter="true" AutoGenerateColumns="false"
                Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="Branch" DataField="Branch" />
                    <asp:BoundField HeaderText="DATEPART" DataField="DATEPART" DataFormatString="{0:dd/MMM/yy}" />
                    <asp:BoundField HeaderText="TIMEPART" DataField="TIMEPART" DataFormatString="{0:dd/MMM/yy}" />
                    <asp:BoundField HeaderText="ReturnDate" DataField="ReturnDate" DataFormatString="{0:dd/MMM/yy}" />
                    <asp:BoundField HeaderText="Group" DataField="category" />
                    <asp:BoundField HeaderText="Item" DataField="Definition" />
                    <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:f2}" />
                    <asp:BoundField HeaderText="RetNo" DataField="RetNo" />
                    <asp:BoundField HeaderText="Reason" DataField="Reason" />
                    <asp:BoundField HeaderText="Sub Reason" DataField="SubReasons" />
                    <asp:BoundField HeaderText="saveDateTime" DataField="saveDateTime" />
                    <asp:BoundField HeaderText="Notes" DataField="Notes" />
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
            <asp:GridView ID="gridledger" runat="server" AllowPaging="false" PageSize="50" AutoGenerateColumns="false"
                Width="100%" Caption="Payment Entry Report" OnRowDataBound="gridledger_OnRowDataBound"
                ShowFooter="true" CssClass="mGrid">
                <Columns>
                    <asp:BoundField HeaderText="Branch" DataField="Branch" />
                    <asp:BoundField HeaderText="Payment ID" DataField="PaymentEntryID" />
                    <asp:BoundField HeaderText="Payment Date" DataField="Date" DataFormatString="{0:dd/MMM/yy}" />
                    <asp:BoundField HeaderText="Ledger" DataField="LedgerName" />
                    <asp:BoundField HeaderText="Description" DataField="Description" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:f2}" />
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
            <asp:GridView ID="gvStaffcredit" runat="server" Caption="Staff Credit" OnRowDataBound="gvStaffcredit_OnRowDataBound"
                Width="100%" ShowFooter="true" CssClass="mGrid" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Branch" DataField="Branch" />
                    <asp:BoundField HeaderText="Type" DataField="Type" />
                    <asp:BoundField HeaderText="Name-Mobileno" DataField="name" />
                    <asp:BoundField HeaderText="Bill No" DataField="billno" />
                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString="{0:dd/MMM/yy}" />
                    <asp:BoundField HeaderText="Qty" DataField="quantity" />
                    <asp:BoundField HeaderText="SubTotal" DataField="amount" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="GST Amnt" DataField="GST" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="disc. Amnt" DataField="disc" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="Total Value" DataField="TotalValue" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="PayType" DataField="PayType" />
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
            <asp:GridView ID="gvdiscountsales" runat="server" Caption="Discount Sale" OnRowDataBound="gvdiscountsales_OnRowDataBound"
                Width="100%" ShowFooter="true" CssClass="mGrid" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Branch" DataField="Branch" />
                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString='{0:dd/MMM/yy}' />
                    <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="Net Amount" DataField="NetAmount" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                    <asp:BoundField HeaderText="Discount" DataField="Discount" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f2}' />
                    <asp:BoundField HeaderText="Approved by" DataField="Approved" />
                    <asp:BoundField HeaderText="Name" DataField="Customername" />
                    <asp:BoundField HeaderText="Mobile" DataField="mobileno" />
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
