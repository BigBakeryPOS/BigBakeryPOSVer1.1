<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestFromProdGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.RequestFromProdGrid" %>

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
    <title>Inter Store Request Details Grid </title>
    <link href="css/mGrid.css" rel="Stylesheet" />
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
        function alertMessage() {
            alert('You Have accepted this Order!');
        }
    </script>
    <style type="text/css">
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvGrid.ClientID %>');
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
<body style="">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Inter Stock Request From Store Details</h1>
	    </div>

                <div class="panel-body">
                    <form runat="server" id="form1" method="post">
                    
                        <%--<blink> <label  style="color:Green; font-size:12px">Screen Show Detail as Per Your daily Stock Request From Your Stock!!!.Please Be Carefull While Accepting order.Thank You!!!</label></blink>--%>
                        <asp:ScriptManager ID="scriptmanager" runat="server">
                        </asp:ScriptManager>
                        <div class="row">
                            <div id="Div1" runat="server" visible="false" class="col-lg-3" style="">
                                <label>
                                    Filter By</label>
                                <asp:DropDownList ID="ddlbillno" CssClass="form-control" Visible="false" Style="width: 150px;"
                                    runat="server">
                                    <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlVendor" CssClass="form-control" runat="server" Width="200px">
                                </asp:DropDownList>
                            </div>
                          
                      
                                <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Transfer To kitchen Stock" PostBackUrl="~/Accountsbootstrap/GoodsTransferNew.aspx"  Visible="false" />
                           
                            <div class="col-lg-3">
                             <%--  <label>Select Date:</label> --%><asp:TextBox ID="txtDate" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="calanderextendert" runat="server" Animated="true"
                                    Format="dd/MM/yyyy" TargetControlID="txtDate" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                              <div class="col-lg-3">
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" Visible="false" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="true" PageSize="20" cssClass="table table-striped pos-table"
                                    AutoGenerateColumns="false" EmptyDataText="Sorry No request Found!!!" padding="0" spacing="0" border="0"
                                    OnRowCommand="gvPurchaseEntry_RowCommand" OnRowDataBound="gvPurchaseEntry_RowDataBound">
                                    <%--<HeaderStyle BackColor="#3366FF" />--%>
                                   <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                    <PagerSettings Mode="Numeric" />--%>
                                     <PagerStyle CssClass="pos-paging" />
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                        <asp:BoundField HeaderText="Branch Name" DataField="tobranchcode" />
                                        <asp:BoundField HeaderText="Request Date" DataField="RequestDate" ItemStyle-Width="250px"/>
                                        <asp:BoundField HeaderText="Request Time" DataField="RequestEntryTime" ItemStyle-Width="250px"/>
                                        <asp:BoundField HeaderText="Status " Visible="false" DataField="Status" />
                                        <asp:BoundField HeaderText="Request NO" DataField="RequestNO" />
                                        <asp:BoundField HeaderText="Request From" DataField="FromBranchCode" />
                                        <asp:BoundField HeaderText="Inter - Branch Request No" DataField="branchreqno" />
                                        <asp:BoundField HeaderText="Request By" DataField="RequestBy" />
                                        <asp:TemplateField HeaderText="Accept & Transfer">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("RequestNO")+";"+Eval("tobranchcode")+";"+Eval("branchreqno")+";"+Eval("FromBranchCode") %>'
                                                    CommandName="Accept" OnClientClick="alertMessage()">
                                                    <asp:Image ID="dlt" runat="server" Width="20px" Height="20px" ImageAlign="Middle" Visible="false"
                                                        ImageUrl="~/images/yes.png" />
                                                        <button type="button" class="btn btn-success btn-md">
						                                    <span class="glyphicon glyphicon-ok-circle" aria-hidden="true"></span>
					                                    </button></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View Detail">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("RequestNO")+";"+Eval("tobranchcode")+";"+Eval("RequestDate")+";"+Eval("branchreqno") %>'
                                                    CommandName="view">
                                                    <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" Visible="false"/>
                                                    <button type="button" class="btn btn-primary btn-md">
						                                <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                </button></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Export">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngridPrint" runat="server" CommandArgument='<%#Eval("RequestNO")+";"+Eval("tobranchcode")+";"+Eval("RequestDate")+";"+Eval("branchreqno") %>'
                                                    CommandName="Export">
                                                    <asp:Image ID="print1" runat="server" ImageAlign="Middle" ImageUrl="../images/xcel.png" Visible="false"
                                                        Width="50px" Height="50px" />
                                                        <button type="button" class="btn btn-success btn-md">
						                                    <span class="glyphicon glyphicon-export" aria-hidden="true"></span>
					                                    </button></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Previous Transfer" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnPrevious" runat="server" Text="P" Font-Bold="true" Font-Size="Larger" Visible="false"
                                                    CommandName="Previous">
                                                     <button type="button" class="btn btn-info btn-md">
						                                    <span class="glyphicon glyphicon-transfer" aria-hidden="true"></span>
					                                    </button></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                   <%-- <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                            </div>
                            </div>
                            <div class="col-lg-6">
                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                 <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Category" DataField="Category" />
                                        <asp:BoundField HeaderText="Item" DataField="Definition" />
                                        <asp:BoundField HeaderText="Order Qty" DataField="Order_Qty" />
                                        <asp:BoundField HeaderText="Received Qty" DataField="received_Qty" />
                                    </Columns>
                                    <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                   <%-- <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                                </div>
                            </div>
                        </div>
                    
                    <div>
                        <asp:LinkButton ID="link" runat="server" Text="Print" OnClientClick=" printGrid()" Visible="false"></asp:LinkButton>
                        &nbsp &nbsp
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Export" OnClick="LinkButton1_Click" Visible="false"></asp:LinkButton>
                        <asp:GridView ID="gvGrid" runat="server" Width="100%" CssClass="mGrid">
                        </asp:GridView>
                    </div>
                    </form>
                </div>

    </div>
    </div>
    </div>
    
    
</body>
</html>


