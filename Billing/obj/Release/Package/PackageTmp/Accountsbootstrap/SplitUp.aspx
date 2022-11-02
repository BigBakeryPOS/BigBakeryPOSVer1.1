<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplitUp.aspx.cs" Inherits="Billing.Accountsbootstrap.SplitUp" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        .GridviewDiv
        {
            font-size: 100%;
            font-family: 'Lucida Grande' , 'Lucida Sans Unicode' , Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }
        .headerstyle
        {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
    <title>Stock Request</title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
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
        function printGrid() {
            var gridData = document.getElementById('<%= print.ClientID %>');
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
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

                <div class="row">
                <div class="col-lg-12" style="margin-top:6px">
                    <h1 class="page-header" style="text-align:center;font-size:20px; font-weight:bold">
                        Todays Advance & Balance Report</h1>
                </div>
            </div>



    
    
    <div>
        <div class="row">
            <div class="panel panel-body">
                <div class="col-lg-3">
                    <label style="display:none;">
                        Select Store</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" Visible="false"
                        Width="150px">
                        <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
                        <asp:ListItem Text=" Byepass" Value="co2"></asp:ListItem>
                        <asp:ListItem Text=" BB Kulam" Value="co3"></asp:ListItem>
                        <asp:ListItem Text="Narayanapuram" Value="co4"></asp:ListItem>
                        <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                        <asp:ListItem Text="Maduravayol" Value="co6"></asp:ListItem>
                        <asp:ListItem Text="Purasavakkam" Value="co7"></asp:ListItem>

                         <asp:ListItem Text="Chennai" Value="co8"></asp:ListItem>
                          <asp:ListItem Text="Thirunelveli" Value="co9"></asp:ListItem>
                           <asp:ListItem Text="Periyar" Value="co10"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-10">
                    <div class="col-lg-2">
                        From Date
                        <asp:TextBox ID="txtfrom" Width="175px" runat="server" CssClass="form-control" AutoPostBack="true"  ontextchanged="txttodate_TextChanged"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfrom" runat="server"
                            CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="col-lg-2">
                        To Date
                        <asp:TextBox ID="txtto" Width="175px" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtto" runat="server"
                            CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                           </div>
                           <div class="col-lg-2">
                        <asp:Button ID="btnser" runat="server" CssClass="btn-danger" Text="Search" style="margin-top: 25px;" OnClick="btnser_Click" />
                     
                    </div>
                    <div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="col-lg-4">
                        <asp:GridView ID="gvAvance" runat="server" CssClass="hidden" Caption="Advance Payment">
                        </asp:GridView>
                    </div>
                    <div class="col-lg-4">
                        <asp:GridView ID="gvBalance" runat="server" CssClass="hidden" Caption="Balance Payment">
                        </asp:GridView>
                    </div>
                    <div class="col-lg-4">
                        <asp:GridView ID="gvFull" runat="server" CssClass="hidden" Caption="Full Payment">
                        </asp:GridView>
                    </div>
                </div>
                <div align="center" id="print" runat="server" class="row">
                    <asp:GridView ID="gvsplit" CssClass="mGrid" runat="server" AutoGenerateColumns="false"
                        Width="60%">
                        <Columns>
                            <asp:BoundField SortExpression="NetAmount" HeaderText="OrderNo" DataField="OrderNo"
                                />
                            <asp:BoundField SortExpression="NetAmount" HeaderText="BookNo" DataField="BookNo"
                               />
                            <asp:BoundField SortExpression="NetAmount" HeaderText="Total Amount	" DataField="Total Amount" ItemStyle-HorizontalAlign="Right"
                                DataFormatString="{0:f}" />
                            <asp:BoundField SortExpression="NetAmount" HeaderText="Advance" DataField="Advance" ItemStyle-HorizontalAlign="Right"
                                DataFormatString="{0:f}" />
                                 <asp:BoundField SortExpression="NetAmount" HeaderText="Balance" DataField="Balance" ItemStyle-HorizontalAlign="Right"
                                DataFormatString="{0:f}" />
                            <asp:BoundField SortExpression="NetAmount" HeaderText="Remaining" DataField="Remaining" ItemStyle-HorizontalAlign="Right"
                                DataFormatString="{0:f}" />
                        </Columns>
                    </asp:GridView>
                    Advance Total:=<label id="lblAdv" runat="server"></label>
                    Balance Total:=<label id="lblBal" runat="server"></label>
                    FullPayment Total:=<label id="lblFull" runat="server"></label>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Print" OnClientClick="printGrid()" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
