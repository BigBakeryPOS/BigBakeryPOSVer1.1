﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyProductionStockRequestReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DailyProductionStockRequestReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Daily Production Stock Request </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function alertMessage() {
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= grid.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,width=100,height=100');
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
        function printGrid1() {
            var gridData = document.getElementById('<%= grid1.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,width=100,height=100');
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
</head>
<body style="">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <div class="panel panel-default" style="">
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Daily Production Stock Request Details</b></div>
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div class="col-lg-12" style="">
                            <form runat="server" id="form1" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="form-group" style="display:none">
                                <label>
                                    Filter By</label>
                                <asp:DropDownList ID="ddlBranch" CssClass="form-control" Style="width: 150px;" runat="server">
                                    <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>
                                </asp:DropDownList>
                                </div>
                                 <div class="form-group">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" Style="margin-top: 10px;"
                                    OnClick="btnsearch_Click" />
                                <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" Style="margin-top: 10px;" />
                            </div>
                            <div class="row">
                                <label class="form-control-label">
                                    From Date</label>
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtDate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                                <label class="form-control-label">
                                    To Date</label>
                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-bordered table-striped">
                                    <tr>
                                        <td style="">
                                            <asp:GridView ID="gvGoodTransFer" runat="server" AllowPaging="true" PageSize="5"
                                                AutoGenerateColumns="false" CssClass="" OnRowCommand="gvGoodTransFer_RowCommand">
                                                <PagerSettings Mode="Numeric" />
                                                <Columns>
                                                    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                                    <asp:BoundField HeaderText="DC NO" DataField="DC_NO" />
                                                    <asp:BoundField HeaderText="DC Date" DataField="Dc_Date" />
                                                    <asp:BoundField HeaderText="Production Request No" DataField="requestNo" />
                                                    <asp:BoundField HeaderText="Branch Request No" DataField="BranchReqNo" />
                                                    <asp:BoundField HeaderText="Request From" DataField="BranchCode" />
                                                    <asp:BoundField HeaderText="Transfer By" DataField="SentBy" />
                                                    <asp:TemplateField HeaderText="Transfer">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("Dc_No") %>'
                                                                CommandName="Transfer" OnClientClick="alertMessage()">
                                                                <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/transfer.jpg"
                                                                    Width="30px" Height="30px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View Detail" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("Dc_No") %>'
                                                                CommandName="view">
                                                                <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </td>
                                        <td style="">
                                            <asp:GridView ID="gvDetails" runat="server" CssClass="myGridStyle" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Item" DataField="Category" />
                                                    <asp:BoundField HeaderText="Category" DataField="Definition" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                                    <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" />
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <label>
                                                <h3>
                                                    Daily Production Stock Request Details
                                                </h3>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvTransfer" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="false"
                                                CssClass="" OnRowCommand="gvTransfer_RowCommand">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Request No" DataField="RequestNo" />
                                                    <asp:BoundField HeaderText="Request Date" DataField="RequestDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                    <asp:BoundField HeaderText="Prepared" DataField="Prepared" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:f}" />
                                                    <asp:TemplateField HeaderText="Export">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnexp" runat="server" CommandName="Exp" CommandArgument='<%#Eval("RequestNo")+";"+Eval("RequestDate") %>'>
                                                                <asp:Image ID="imgexp" runat="server" ImageUrl="~/images/xcel.png" Width="50px" Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print Receive">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("RequestNo")+";"+Eval("RequestDate") %>'>
                                                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print DC">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint1" runat="server" CommandName="Print1" CommandArgument='<%#Eval("RequestNo")+";"+Eval("RequestDate") %>'>
                                                                <asp:Image ID="imgprint11" runat="server" ImageUrl="~/images/print (1).png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%#Eval("RequestNo")+";"+Eval("RequestDate") %>'>
                                                                <asp:Image ID="imgprint1" runat="server" ImageUrl="~/images/info_button.png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#428bca" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                        <td width="10%" valign="top">
                                        </td>
                                        <td valign="top">
                                            <asp:GridView ID="grid" runat="server" CssClass="mGrid" GridLines="Both"  AutoGenerateColumns="false">
                                            <Columns>
                                               <asp:BoundField HeaderText="Request No" DataField="RequestNo" Visible="true" />
                                                        <asp:BoundField HeaderText="Request Date" DataField="RequestDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                        <asp:BoundField HeaderText="Prepared" DataField="Prepared" Visible="true" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" Visible="true" />
                                                        <asp:BoundField HeaderText="Item" DataField="Definition" Visible="true" />
                                                        <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' /> 
                                                           <asp:BoundField HeaderText="Missing Qty" DataField="MissingQty" DataFormatString='{0:f}' />
                                                              <asp:BoundField HeaderText="Receive Qty" DataField="ReceiveQty" DataFormatString='{0:f}' />
                                                                 <asp:BoundField HeaderText="Damage Qty" DataField="DamageQty" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Unit" DataField="Unit" />
                                                        </Columns>
                                            </asp:GridView>

                                        </td>
                                        <td valign="top">
                                            <asp:GridView ID="grid1" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                                                GridLines="Both">
                                                <Columns>
                                                   <asp:BoundField HeaderText="Request No" DataField="RequestNo" Visible="true" />
                                                        <asp:BoundField HeaderText="Request Date" DataField="RequestDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                        <asp:BoundField HeaderText="Prepared" DataField="Prepared" Visible="true" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" Visible="true" />
                                                        <asp:BoundField HeaderText="Item" DataField="Definition" Visible="true" />
                                                        <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Unit" DataField="Unit" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            </form>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</body>
</html>