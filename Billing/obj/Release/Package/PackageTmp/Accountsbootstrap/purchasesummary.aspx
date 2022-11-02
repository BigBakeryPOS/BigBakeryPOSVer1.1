<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="purchasesummary.aspx.cs"
    Inherits="Billing.Accountsbootstrap.purchasesummary" %>

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
    <title>Sales Report </title>
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
    <!-- Start Styles. Move the 'style' tags and everything between them to between the 'head' tags -->
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!--<link href="../Styles/style1.css" rel="stylesheet"/>-->
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
        function Search_Gridview(strKey, strGV) {


            var strData = strKey.value.toLowerCase().split(" ");

            var tblData = document.getElementById(strGV);

            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)

                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }    
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gridPurchase.ClientID %>');
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
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header" style="text-align: center">
                Purchase Summary Report Grid</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <form id="form1" runat="server">
                            <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group" id="Admin" runat="server">
                                                <label>
                                                    Select Branch</label>
                                                <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                                                    <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
                                                    <asp:ListItem Text=" Byepass" Value="co2"></asp:ListItem>
                                                    <asp:ListItem Text=" BB Kulam" Value="co3"></asp:ListItem>
                                                    <asp:ListItem Text="Narayanapuram" Value="co4"></asp:ListItem>
                                                    <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <div class="form-group">
                                                <asp:Label ID="lblFromDate" runat="server">From Date</asp:Label>
                                                <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="true" CssClass="form-control center-block"
                                                    OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtFromDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <asp:Label ID="lblToDate" runat="server">To Date</asp:Label>
                                                <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control center-block"
                                                    OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Width="110px"
                                                    Text="Print" OnClick="btnPrintFromCodeBehind_Click" />
                                            </div>
                                        </div>
                                        
                                        <div class="col-lg-1">
                                            <br />
                                            <asp:Button ID="btnpdf" visible="false" runat="server" Text="PDF" CssClass="btn btn-info" OnClick="btnpdf_Click"
                                                Width="110px" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div runat="server" visible="false" class="col-lg-2">
                                            <div runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rdbCustomer" runat="server" Text="Customer" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rdbCustomer_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2" visible="false" runat="server">
                                            <div runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rbdPayMode" runat="server" Text="Payment Mode" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdPayMode_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2" visible="false" runat="server">
                                            <div class="form-group" visible="false">
                                                <asp:RadioButton ID="rbproqty" runat="server" Text="Product wise Qty" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbproqty_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2" visible="false" runat="server">
                                            <div class="form-group" visible="false">
                                                <asp:RadioButton ID="rbdcatqty" runat="server" Text="Category wise Qty" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdcatqty_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2" visible="false" runat="server">
                                            <div class="form-group" visible="false">
                                                <asp:RadioButton ID="rbdCtry" runat="server" Text="Category" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdCtry_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <asp:RadioButton ID="rbdSupp" runat="server" Text="Supplier" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdSupp_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <asp:RadioButton ID="rbdProduct" runat="server" Text="Product" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdProduct_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div runat="server" class="form-group">
                                                <asp:RadioButton ID="rbdExpDate" runat="server" Text="Expired Date" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdExpDate_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2" visible="false" runat="server">
                                            <div id="Div1" runat="server" class="form-group" visible="false">
                                                <asp:RadioButton ID="rbdBrnd" runat="server" Text="Expiry Date" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdExpDate_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-bordered table-striped">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gridPurchase" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                                CssClass="myGridStyle1" AutoGenerateColumns="false" OnRowCreated="gridPurchase_RowCreated"
                                                                OnRowDataBound="gridPurchase_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="BillNo" Visible="false" />
                                                                    <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="BillDate" HeaderText="Bill Date" ItemStyle-HorizontalAlign="Center"
                                                                        DataFormatString="{0:dd-MMM-yyyy}" />
                                                                    <asp:BoundField DataField="LedgerName" HeaderText="Supplier" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="Payment_Mode" HeaderText="Payment Mode" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="Ingredientname" HeaderText="Ingredient Name" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" ItemStyle-HorizontalAlign="Center"  DataFormatString="{0:dd-MMM-yyyy}"/>
                                                                    <%-- <asp:BoundField DataField="BrandName" HeaderText="Brand Name" ItemStyle-HorizontalAlign="Center" />--%>
                                                                    <asp:BoundField DataField="Qty" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="Rate" HeaderText="Unit Price" DataFormatString="{0:###,##0.00}"
                                                                        Visible="false" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="NetAmount" HeaderText="Amount" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="SalesAmount" HeaderText="Purchase Amount" ItemStyle-HorizontalAlign="Right" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                        <asp:GridView ID="gridcatqty" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                            CssClass="myGridStyle1" AutoGenerateColumns="true" OnRowCreated="gridcatqty_RowCreated1"
                                                            OnRowDataBound="gridcatqty_RowDataBound1">
                                                            <Columns>
                                                                <%--  <asp:BoundField DataField="category" HeaderText="Group" />--%>
                                                                <%-- <asp:BoundField DataField="Definition" HeaderText="ItemName" />
                                    
                                    <asp:BoundField DataField="qty" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" />--%>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </tr>
                                                    <tr>
                                                        <td visible="false" id="Td1" runat="server">
                                                            Total:<label id="lblTotal" runat="server"></label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-4">
                                                <asp:Button ID="btn" runat="server" Text="Export To Excel" Visible="false" CssClass="btn btn-success"
                                                    OnClick="btnExport_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridPurchase" EventName="RowDataBound" />
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound"></asp:AsyncPostBackTrigger>
                                    <asp:PostBackTrigger ControlID="btn"></asp:PostBackTrigger>
                                </Triggers>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound" />
                                </Triggers>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="update">
                                <%-- <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 100; margin-left: 50px; margin-top: 50px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="../images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>--%>
                                <%-- for text <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
        </div>
    </ProgressTemplate>--%>
                                <ProgressTemplate>
                                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                                        right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif"
                                            AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                                            top: 45%; left: 50%;" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
