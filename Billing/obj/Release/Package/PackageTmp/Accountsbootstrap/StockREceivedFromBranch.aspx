﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockREceivedFromBranch.aspx.cs"
    Inherits="Billing.Accountsbootstrap.StockREceivedFromBranch" %>

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
    <title>Goods Received Grid </title>
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
                    <b>Goods Transfer Details</b></div>
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div class="col-lg-12" style="">
                            <form runat="server" id="form1" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                           
                            <div class="row">
                             <div class="col-lg-4">
                                <label class="form-control-label">
                                    From Date</label>
                                <asp:TextBox ID="txtDate" CssClass="form-control" Enabled="true" runat="server"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDate"
                                    ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                </asp:RangeValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtDate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="col-lg-4">
                                <label class="form-control-label">
                                    To Date</label>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Enabled="true" runat="server"></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtToDate"
                                    ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                </asp:RangeValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                             <div class="col-lg-4">
                             <br />
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-primary" Text="Generate Report" 
                                    OnClick="btnsearch_Click" />
                                <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  />
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table table-bordered table-striped">
                                    <tr>
                                        <td style="">
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
                                                    Goods Received Details
                                                </h3>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvreceived" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle"
                                                OnRowCommand="gvreceivedr_RowCommand">
                                                <Columns>
                                                    <asp:BoundField HeaderText="REC.No" DataField="Recid" />
                                                    <asp:BoundField HeaderText="REC.Date" DataField="RecDate" />
                                                    <asp:BoundField HeaderText="DC No" DataField="DC_NO" />
                                                    <asp:BoundField HeaderText="Branch Request No" DataField="Branchreqno" />
                                                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
                                                    <asp:TemplateField HeaderText="Export">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnexp" runat="server" CommandName="Exp" CommandArgument='<%#Eval("Recid")+";"+Eval("RecDate") %>'>
                                                                <asp:Image ID="imgexp" runat="server" ImageUrl="~/images/xcel.png" Width="50px" Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("Recid")+";"+Eval("RecDate") %>'>
                                                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnView" runat="server" CommandName="View" CommandArgument='<%#Eval("Recid")+";"+Eval("RecDate") %>'>
                                                                <asp:Image ID="imgprint1" runat="server" ImageUrl="~/images/info_button.png" Width="50px"
                                                                    Height="50px" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                        <td valign="top">
                                            <asp:GridView ID="grid" runat="server" CssClass="mGrid">
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
