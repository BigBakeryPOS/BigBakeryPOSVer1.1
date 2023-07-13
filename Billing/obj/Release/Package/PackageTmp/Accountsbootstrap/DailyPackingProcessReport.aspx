<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyPackingProcessReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DailyPackingProcessReport" %>

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
    <title>Daily Packing Process Report </title>
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
                    <b>Daily Packing Process Details</b></div>
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
                                  <div class="form-group" >
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
                              
                                <table>
                                    <tr>
                                        <td>
                                            <label>
                                                <h3>
                                                    Daily Packing Process Details
                                                </h3>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvTransfer" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="false"
                                                CssClass="" OnRowCommand="gvTransfer_RowCommand">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Pack No" DataField="PackNo" />
                                                    <asp:BoundField HeaderText="Pack Date" DataField="PackDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                    <asp:BoundField HeaderText="Prepared" DataField="Prepared" />
                                                      <asp:BoundField HeaderText="Pack Qty" DataField="PackingQty" DataFormatString="{0:f}" />
                                                        <asp:BoundField HeaderText="CurrentQty" DataField="CurrentQty" DataFormatString="{0:f}" />
                                                          <asp:BoundField HeaderText="ReceiveQty" DataField="ReceiveQty" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="FinalQty" DataField="FinalQty" DataFormatString="{0:f}" />
                                                    <asp:TemplateField HeaderText="Export">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnexp" runat="server" CommandName="Exp" CommandArgument='<%#Eval("PackNo")+";"+Eval("PackDate") %>'>
                                                                <asp:Image ID="imgexp" runat="server" ImageUrl="~/images/xcel.png" Width="50px" Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print Receive">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("PackNo")+";"+Eval("PackDate") %>'>
                                                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print DC">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint1" runat="server" CommandName="Print1" CommandArgument='<%#Eval("PackNo")+";"+Eval("PackDate") %>'>
                                                                <asp:Image ID="imgprint11" runat="server" ImageUrl="~/images/print (1).png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%#Eval("PackNo")+";"+Eval("PackDate") %>'>
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
                                               <asp:BoundField HeaderText="Pack No" DataField="PackNo" Visible="true" />
                                                        <asp:BoundField HeaderText="Pack Date" DataField="PackDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                        <asp:BoundField HeaderText="Prepared" DataField="Prepared" Visible="true" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" Visible="true" />
                                                        <asp:BoundField HeaderText="Item" DataField="Definition" Visible="true" />
                                                          <asp:BoundField HeaderText="Pack Qty" DataField="PackingQty" DataFormatString="{0:f}" />
                                                        <asp:BoundField HeaderText="CurrentQty" DataField="CurrentQty" DataFormatString="{0:f}" />
                                                          <asp:BoundField HeaderText="ReceiveQty" DataField="ReceiveQty" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="FinalQty" DataField="FinalQty" DataFormatString="{0:f}" />
                                                        <asp:BoundField HeaderText="Unit" DataField="uom" />
                                                        </Columns>
                                            </asp:GridView>

                                        </td>
                                        <td valign="top">
                                            <asp:GridView ID="grid1" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                                                GridLines="Both">
                                                <Columns>
                                                   <asp:BoundField HeaderText="Pack No" DataField="PackNo" Visible="true" />
                                                        <asp:BoundField HeaderText="Pack Date" DataField="PackDate" DataFormatString='{0:dd/MM/yyyy}' />
                                                        <asp:BoundField HeaderText="Prepared" DataField="Prepared" Visible="true" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" Visible="true" />
                                                        <asp:BoundField HeaderText="Item" DataField="Definition" Visible="true" />
                                                        <asp:BoundField HeaderText="Pack Qty" DataField="PackingQty" DataFormatString="{0:f}" />
                                                        <asp:BoundField HeaderText="CurrentQty" DataField="CurrentQty" DataFormatString="{0:f}" />
                                                          <asp:BoundField HeaderText="ReceiveQty" DataField="ReceiveQty" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="FinalQty" DataField="FinalQty" DataFormatString="{0:f}" />
                                                        <asp:BoundField HeaderText="Unit" DataField="uom" />
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
