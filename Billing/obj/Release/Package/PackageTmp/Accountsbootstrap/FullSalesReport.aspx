<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullSalesReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.FullSalesReport" %>

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
                    Sales Report</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div class="col-lg-12">
            <div class="col-lg-2">
                <div id="Div1" align="center" runat="server">
                    <label>
                        Select Branch</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <label>
                        Select Date</label>
                    <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Style="width: 130px;
                        margin-left: 9px" Text="--Select Date--" AutoPostBack="true" OnTextChanged="txttodate_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please enter From Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfrmdate"
                        Format="yyyy-MM-dd" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-2" runat="server" visible="false">
                <div class="form-group">
                    <label>
                        To Date</label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Style="width: 130px"
                        Text="--Select Date--"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                        ControlToValidate="txttodate" ErrorMessage="Please enter To Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                        Format="yyyy-MM-dd" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div class="col-lg-2" runat="server" visible="false">
                <div class="form-group">
                    <label>
                        Category</label>
                    <asp:DropDownList ID="ddlcat" runat="server" class="form-control" Width="150px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group">
                    <br />
                    <asp:Button ID="btnsearch" runat="server" ValidationGroup="val1" class="btn btn-success"
                        Text="Search" OnClick="Search_Click" Style="width: 120px" />
                </div>
            </div>
            <div class="col-lg-2" runat="server" visible="false">
                <div class="form-group">
                    <br />
                    <asp:Button ID="btnexcel" runat="server" ValidationGroup="val1" class="btn btn-warning"
                        Text="Excel" OnClick="btnexcel_Click" Style="width: 120px" />
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
                            Sales</label>
                        <asp:GridView ID="gvSalesValue" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                            OnRowDataBound="gvSalesValue_OnRowDataBound" EmptyDataText="No Record found"
                            Width="100%" ShowFooter="true">
                            <Columns>
                                <asp:BoundField HeaderText="Category" DataField="Category" />
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
                                    ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                            <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
