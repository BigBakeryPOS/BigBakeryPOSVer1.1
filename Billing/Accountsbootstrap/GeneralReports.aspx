<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralReports.aspx.cs"
    Inherits="Billing.Accountsbootstrap.GeneralReports" %>

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
    <title>General Reports</title>
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
            <div class="col-lg-1">
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
            <div class="col-lg-2">
                <div class="form-group">
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
                    <%--  <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>--%>
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
                    <%-- <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>--%>
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
        <div class="col-lg-12">
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
            <table id="Sales" border="1" runat="server" visible="false">
                <tr id="Tr1" runat="server">
                    <td>
                    </td>
                    <td>
                        Blaack Forest
                        <br />
                        No.12, Lake View Road,
                        <br />
                        KK Nagar, Madurai - 625020
                        <br />
                        Phone No. 99433 63525
                        <br />
                        GSTIN: 33AWBPR0957L1ZA
                        <br />
                    </td>
                    <td>
                        <b>Details of Buyer: </b>
                        <br />
                        Keestu Mithai
                        <br />
                        No.E 29 & 30, Bharathiyar Shopping Complex
                        <br />
                        Periyar Bus Stand, Madurai - 625001
                        <br />
                        GSTIN: 33AASFK2747C1ZD
                        <br />
                    </td>
                    <td>
                        Inv.No.<asp:Label ID="lblinvoiceno" runat="server"></asp:Label>
                        <br />
                        Date :<asp:Label ID="lblinvoicedate" runat="server"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvSalesValue" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                            OnRowDataBound="gvSalesValue_OnRowDataBound" Width="100%" ShowFooter="true">
                            <Columns>
                                <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:dd/MMM/yy}"  />
                                <asp:BoundField HeaderText="GRN Source" DataField="grnsource" />
                                <asp:BoundField HeaderText="Category" DataField="Category" />
                                <asp:BoundField HeaderText="Item Name" DataField="Itemname" />
                                <asp:BoundField HeaderText="GST%" DataField="GST" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:f}" />
                                <asp:BoundField HeaderText="Rate" DataField="rate" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Total Rate" DataField="TotalRate" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Margin%" DataField="Margin" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Margin Value" DataField="Marginvalue" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Basic Cost After Margin" DataField="BasicCostAfterMargin"
                                    DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="GST Value" DataField="GSTvalue" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Net Amount" DataField="NetAmount" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        Sales Exempted :
                        <asp:Label ID="lblsalesexempted" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        Taxable Sales :
                        <asp:Label ID="lbltaxablesales" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        GST :
                        <asp:Label ID="lblcgst" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr id="Tr2" runat="server" visible="false">
                    <td colspan="4" align="right">
                        SGST :
                        <asp:Label ID="lblsgst" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        NET AMOUNT :
                        <asp:Label ID="lblnetamount" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        Round Off :
                        <asp:Label ID="lblroundoff" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        FINAL AMOUNT :
                        <asp:Label ID="lblfinalamount" runat="server">0.00</asp:Label>
                    </td>
                </tr>
            </table>
            <table id="Order" border="1" runat="server" visible="false">
                <tr id="Tr3" runat="server">
                    <td>
                    </td>
                    <td>
                        Blaack Forest
                        <br />
                        No.12, Lake View Road,
                        <br />
                        KK Nagar, Madurai - 625020
                        <br />
                        Phone No. 99433 63525
                        <br />
                        GSTIN: 33AWBPR0957L1ZA
                        <br />
                    </td>
                    <td>
                        <b>Details of Buyer: </b>
                        <br />
                        Keestu Mithai
                        <br />
                        No.E 29 & 30, Bharathiyar Shopping Complex
                        <br />
                        Periyar Bus Stand, Madurai - 625001
                        <br />
                        GSTIN: 33AASFK2747C1ZD
                        <br />
                    </td>
                    <td>
                        Inv.No.<asp:Label ID="Label1" runat="server"></asp:Label>
                        <br />
                        Date :<asp:Label ID="Label2" runat="server"></asp:Label>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvorder" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                            OnRowDataBound="gvorder_OnRowDataBound" Width="100%" ShowFooter="true">
                            <Columns>
                                <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
                                <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                <asp:BoundField HeaderText="Order Date" DataField="OrderDate" DataFormatString="{0:dd/MMM/yy}"  />
                                <asp:BoundField HeaderText="Payment Date" DataField="Billdate" DataFormatString="{0:dd/MMM/yy}"  />
                                <asp:BoundField HeaderText="Order AMOUNT" DataField="NetAmount" DataFormatString="{0:f}" />
                                <asp:BoundField HeaderText="COST" DataField="COST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="GST %" DataField="GST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Pay Type" DataField="paytype" />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Margin%" DataField="marginvalue" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Margin Value" DataField="Margin" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Basic Cost After Margin" DataField="castbeforemargin"
                                    DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="GST Value" DataField="GSTV" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Net Amount" DataField="NetamountV" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        Taxable Sales :
                        <asp:Label ID="lbltaxablesalesorder" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        GST :
                        <asp:Label ID="lblcgstorder" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr id="Tr4" runat="server" visible="false">
                    <td colspan="4" align="right">
                        SGST :
                        <asp:Label ID="Label6" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        NET AMOUNT :
                        <asp:Label ID="lblnetamountorder" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        Round Off :
                        <asp:Label ID="lblroundofforder" runat="server">0.00</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        FINAL AMOUNT :
                        <asp:Label ID="lblfinalamountorder" runat="server">0.00</asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
