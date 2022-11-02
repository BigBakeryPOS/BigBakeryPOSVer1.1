<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReturnReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.StockReturnReport" %>

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
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvReturns.ClientID %>');
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
    <div style="margin-top: 10px">
        <h2>
            Stock Return Report</h2>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body" style="">
                        <div class="col-lg-2">
                            <div id="admin" runat="server">
                                <label style=" color:#428bca">
                                    Select Branch</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                                    <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
                                    <asp:ListItem Text=" Byepass" Value="co2"></asp:ListItem>
                                    <asp:ListItem Text=" BB Kulam" Value="co3"></asp:ListItem>
                                    <asp:ListItem Text="Narayanapuram" Value="co4"></asp:ListItem>
                                    <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                    <asp:ListItem Text="Chennai Pothys" Value="co8"></asp:ListItem>
                                    <asp:ListItem Text="Thirunelveli" Value="co9"></asp:ListItem>
                                    <asp:ListItem Text="Periyar" Value="co10"></asp:ListItem>
                                    <asp:ListItem Text="Palayam" Value="co11"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <label style=" color:#428bca">
                                From Date</label>
                            <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" >
                            </asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                            </asp:RangeValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                        <div class="col-lg-2">
                            <label style=" color:#428bca">
                                To Date</label>
                            <asp:TextBox runat="server" ID="txttodate" CssClass="form-control" >
                            </asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                            </asp:RangeValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                        <div class="col-lg-2">
                            <label style=" color:#428bca">
                                Reasons</label>
                            <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-1">
                        <br />
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Generate Report" style="background-color: #428bca; border: 3px solid #428bca;"
                                OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-lg-1">
                            <br />
                            <asp:Button ID="btnPrint" runat="server" Text="Print" style="    height: 38px;    margin-left: 19px;" CssClass="btn btn-warning"
                                OnClick="btnPrint_Click" />
                        </div>
                        <div class="col-lg-1">
                            <br />
                            <asp:Button ID="btnExp" runat="server" Text="Export" CssClass="btn btn-danger"  style="    height: 38px; " OnClick="btnExp_Click1" />
                            <h3>
                                <asp:Label runat="server" ID="lblresult" ForeColor="Black" Visible="true" CssClass="label">Welcome: </asp:Label></h3>
                        </div>
                        <div class="col-lg-12">
                            <asp:GridView ID="gvReturns" Caption="Returned Goods" runat="server" CssClass="myGridStyle"
                                AutoGenerateColumns="false" BackColor="#99cc99" EmptyDataText="No Records Found"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Return No" DataField="RetNo" Visible="false" />
                                    <asp:BoundField HeaderText="Date" DataField="ReturnDate" DataFormatString="{0:dd/MMM/yy}" />
                                    <asp:BoundField HeaderText="Group" DataField="category" />
                                    <asp:BoundField HeaderText="Item" DataField="Definition" />
                                    <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N2}" />
                                    <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                    <asp:BoundField HeaderText="Sub Reason" DataField="SubReasons" />
                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                </Columns>
                                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                            <label style=" color:#428bca">
                                Total Amount:-Rs</label>
                            <label id="lblTotal" runat="server">
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="Div">
        <table id="Mytale" runat="server">
            <tr>
                <td id="Extra1" runat="server">
                    <asp:GridView ID="gvPrint" Caption="Returned Goods" Visible="false" runat="server"
                        CssClass="myGridStyle" AutoGenerateColumns="false" BackColor="#99cc99" EmptyDataText="No Records Found">
                        <Columns>
                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                            <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N2}" />
                            <asp:BoundField HeaderText="Reason" DataField="Reason" />
                        </Columns>
                        <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td id="Extra2" runat="server" visible="false">
                    <label id="Label1" runat="server" visible="false">
                    </label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
