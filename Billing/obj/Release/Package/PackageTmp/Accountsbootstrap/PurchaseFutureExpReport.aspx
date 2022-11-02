<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseFutureExpReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PurchaseFutureExpReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Sales Report</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Hide
        {
            display: none;
        }
        
        
        .myGridStyle
        {
            font-family: "Comic Sans MS";
            border-collapse: collapse;
            font-names: "Comic Sans MS";
            rowstyle-borderstyle: "Double";
            headerstyle-horizontalalign: "Center";
            font-weight: "bold";
        }
    </style>

     <style type="text/css">
        .GroupHeaderStyle
        {
            background-color: #afc3dd;
            color: Black;
            font-weight: bold;
            text-transform: uppercase;
        }
        .SubTotalRowStyle
        {
            background-color: #cccccc;
            color: Black;
            font-weight: bold;
        }
        .GrandTotalRowStyle
        {
            background-color: #000000;
            color: white;
            font-weight: bold;
        }
        .align1
        {
            text-align: right;
        }
        
        .myGridStyle1 tr th
        {
            padding: 8px;
            color: #afc3dd;
            background-color: #000000;
            border: 1px solid gray;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            text-transform: uppercase;
        }
        
        
        
        
        
        .myGridStyle1 tr:nth-child(even)
        {
            background-color: #ffffff;
        }
        
        
        
        .myGridStyle1 tr:nth-child(odd)
        {
            background-color: #ffffff;
        }
        
        
        
        .myGridStyle1 td
        {
            border: 1px solid gray;
            padding: 8px;
        }
    </style>
</head>
<body style="">
    <form runat="server" id="form1" method="post">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row" style="padding-top: 50px">
        <div class="row" style="padding-left: 25px">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Purchase Expiry Status Report</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="col-lg-12">
            <div class="col-lg-1">
                <div class="form-group">
                    <asp:Label runat="server" ID="Label1">No of Days </asp:Label>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <asp:TextBox ID="txtnoofdays" CssClass="form-control" runat="server" Text="10"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <asp:Button ID="btnsearch" runat="server" ValidationGroup="val1" class="btn btn-success"
                        Text="Generate Report" OnClick="Search_Click" Style="width: 150px" />
                </div>
            </div>
            <div class="col-lg-2" runat="server" visible="false">
                <div class="form-group">
                    <br />
                    <%-- <asp:Button ID="btnexcel" runat="server" ValidationGroup="val1" class="btn btn-warning"
                        Text="Excel" OnClick="btnexcel_Click" Style="width: 120px" />--%>
                    <asp:Button ID="btnexcel" runat="server" ValidationGroup="val1" class="btn btn-warning"
                        Text="Excel" Style="width: 120px" />
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-12">
        <div class="col-lg-3">
        </div>
        <div class="col-lg-7">
            <asp:Label runat="server" ID="lblstkreturn" ForeColor="RoyalBlue" Visible="true"> </asp:Label>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="row" style="padding-top: 30px">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="col-lg-12">
                    <div class="col-lg-12">
                        <label>
                            Purchase Expiry Status</label>
                        <asp:GridView ID="gvSalesValue" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle1"
                           EmptyDataText="No Record found"
                            Width="100%" ShowFooter="true">
                            <Columns>
                                <%-- <asp:BoundField HeaderText="Category" DataField="Category" />
                                <asp:BoundField HeaderText="Name Of Items" DataField="Definition" />
                                <asp:BoundField HeaderText="GST" DataField="GST" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="MRP" DataField="RateTax" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="TotalRate" DataField="TotalRate" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="TotalMRP" DataField="TotalValue" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Margin" DataField="Margin" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="BasicValue" DataField="BasicValue" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="CGST %" DataField="CGST" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="CGST Amount" DataField="CGSTAmt" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="SGST %" DataField="CGST" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="SGST Amount" DataField="CGSTAmt" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}'
                                    ItemStyle-HorizontalAlign="Right" />--%>
                                <asp:BoundField DataField="BillNo" Visible="false" />
                                <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="BillDate" HeaderText="Bill Date" ItemStyle-HorizontalAlign="Center"
                                    DataFormatString="{0:MM-dd-yyyy}" />
                                <asp:BoundField DataField="LedgerName" HeaderText="Supplier" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Payment_Mode" HeaderText="Payment Mode" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Ingredientname" HeaderText="Ingredient Name" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" ItemStyle-HorizontalAlign="Center" />
                                <%-- <asp:BoundField DataField="BrandName" HeaderText="Brand Name" ItemStyle-HorizontalAlign="Center" />--%>
                                <asp:BoundField DataField="Qty" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="Rate" HeaderText="Unit Price" DataFormatString="{0:###,##0.00}"
                                    Visible="false" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="NetAmount" HeaderText="Amount" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="SalesAmount" HeaderText="Purchase Amount" ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                           <%-- <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />--%>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
