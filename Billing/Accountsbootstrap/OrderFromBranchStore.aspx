﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderFromBranchStore.aspx.cs" EnableEventValidation="false"
    Inherits="Billing.Accountsbootstrap.OrderFromBranchStore" %>

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
    <title>Store Stock Request Details Grid </title>
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
    <script type="text/javascript">
        function printdata() {
            var gridData = document.getElementById("PRINTID");
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
    <script type="text/javascript">
        function printdataDC() {
            var gridData = document.getElementById("PRINTIDRec");
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
          <h1 class="page-header">Store Stock Request From Branch Details</h1>
	    </div>
                <div class="panel-body">
                    <form runat="server" id="form1" method="post">
                    <div class="row">
                        <%--<blink> <label  style="color:Green; font-size:12px">Screen Show Detail as Per Your daily Stock Request From Your Stock!!!.Please Be Carefull While Accepting order.Thank You!!!</label></blink>--%>
                        <asp:ScriptManager ID="scriptmanager" runat="server">
                        </asp:ScriptManager>

                       <div class="col-lg-6">
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
                            <div class="col-lg-2" runat="server" visible="false" style="">
                                <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Transfer To kitchen Stock"
                                    Visible="false" />
                            </div>
                            <div class="col-lg-6">
                            <label>Select Date</label>
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="calanderextendert" runat="server" Animated="true"
                                    Format="dd/MM/yyyy" TargetControlID="txtDate" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-6">
                               
                                    <label>
                                        Select Branch</label>
                                    <asp:DropDownList ID="drpstorelist" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                               
                            </div>
                        </div>
                         <div class="row">    
                             <div class="col-lg-6"><br />
                            <asp:DropDownList ID="drpdcqtywise" runat="server" CssClass="form-control" >
                            <asp:ListItem Text="Branch Wise" Value="0" Selected="True" ></asp:ListItem>
                            <asp:ListItem Text="Overall Wise" Value="1" ></asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <div class="col-lg-6">
                            <br />
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search" OnClick="btnsearch_Click" />
                                <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" Visible="false" />
                            </div>
                        <div class="col-lg-12" >
                         <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="true" PageSize="20" cssClass="table table-striped pos-table"
                                    Font-Names="Calibri" AutoGenerateColumns="false" EmptyDataText="Sorry No request Found!!!"
                                    OnRowCommand="gvPurchaseEntry_RowCommand" OnRowDataBound="gvPurchaseEntry_RowDataBound" padding="0" spacing="0" border="0">
                                    <PagerStyle CssClass="pos-paging" />
                                    <%--<HeaderStyle BackColor="#3366FF" />--%>
                                    <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />
                                    <PagerSettings Mode="Numeric" />--%>
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                        <asp:BoundField HeaderText="Production Name" DataField="Production_To" />
                                        <asp:BoundField HeaderText="Request Date" DataField="RequestDate" DataFormatString="{0:d}" />
                                        <asp:BoundField HeaderText="Request Time" DataField="requestentrytime" ItemStyle-Width="250px" />
                                        <asp:BoundField HeaderText="Status " Visible="false" DataField="Status" />
                                        <asp:BoundField HeaderText="Prod.RequestNO" DataField="RequestNO" />
                                        <asp:BoundField HeaderText="Request From" DataField="Branch" />
                                        <asp:BoundField HeaderText="Branch Request No" DataField="branchno" />
                                        <asp:BoundField HeaderText="Request By" DataField="RequestBy" />
                                        <asp:TemplateField HeaderText="Accept & Transfer">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("RequestNO")+";"+Eval("Branch")+";"+Eval("branchno") %>'
                                                    CommandName="Accept" OnClientClick="alertMessage()">
                                                    <asp:Image ID="dlt" runat="server" Width="20px" Height="20px" ImageAlign="Middle"
                                                        ImageUrl="~/images/yes.png" visible="false" />
                                                         <button type="button" class="btn btn-success btn-md">
						                                    <span class="glyphicon glyphicon-ok-circle" aria-hidden="true"></span>
					                                    </button>
                                                        </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View Detail">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("RequestNO")+";"+Eval("Branch")+";"+Eval("RequestDate")+";"+Eval("branchno") %>'
                                                    CommandName="view">
                                                    <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" visible="false"/>
                                                     <button type="button" class="btn btn-primary btn-md">
						                                <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                </button>
                                                    </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Export">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngridPrint" runat="server" CommandArgument='<%#Eval("RequestNO")+";"+Eval("Branch")+";"+Eval("RequestDate")+";"+Eval("branchno") %>'
                                                    CommandName="Export">
                                                    <asp:Image ID="print1" runat="server" ImageAlign="Middle" ImageUrl="../images/xcel.png"
                                                        Width="50px" Height="50px" visible="false" />
                                                         <button type="button" class="btn btn-success btn-md">
						                                    <span class="glyphicon glyphicon-export" aria-hidden="true"></span>
					                                    </button>
                                                        </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Previous Transfer" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnPrevious" runat="server" Text="P" Font-Bold="true" Font-Size="Larger"
                                                    CommandName="Previous" visible="false" >
                                                     <button type="button" class="btn btn-info btn-md">
						                                    <span class="glyphicon glyphicon-transfer" aria-hidden="true"></span>
					                                    </button>
                                                        </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                    <%-- <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                            </div>
                            </div>
                       </div>
                       </div>
                        <div class="col-lg-6">
                       <div class="row">
                            <div class="col-lg-6">
                            <br />
                                <asp:Button ID="btnsearchqty" runat="server" class="btn btn-info pos-btn1" Text="Get All Branches Qty"
                                    OnClick="btnsearchqty_OnClick" />
                                <br />
                                <br />
                                 <asp:Button ID="Button1" runat="server" class="btn btn-secondary" Text="Print" OnClientClick="printdata()" />
                                 &nbsp; &nbsp; &nbsp;<asp:Button ID="Button4" runat="server" class="btn btn-success" Text="Export-Excel"
                                    OnClick="btnexport_click" />
                            </div>
                            
                            <div class="col-lg-6">
                            <br />
                                <asp:Button ID="Button2" runat="server" class="btn btn-info pos-btn1" Text="Get All Branches Qty DC"
                                    OnClick="btnsearchqtyDC_OnClick" />
                                <br />
                                <br />
                               <asp:Button ID="Button3" runat="server" class="btn btn-secondary" Text="Print" OnClientClick="printdataDC()" />
                                &nbsp; &nbsp; &nbsp; <asp:Button ID="Button5" runat="server" class="btn btn-success" Text="Export-Excel DC"
                                    OnClick="btnexportDC_click" />
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-lg-12">
                              <div class="table-responsive panel-grid-left">
                             <div id="PRINTID" runat="server">
                                    <asp:GridView ID="gvbranchqty" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                        OnRowCreated="gvbranchqty_RowCreated" OnRowDataBound="gvbranchqty_RowDataBound"
                                        padding="0" spacing="0" border="0">
                                       <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                        <Columns>
                                            <asp:BoundField HeaderText="Category" DataField="Category" />
                                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUOM" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdCategoryid" runat="server" Value='<%# Eval("Categoryid")%>' />
                                                    <asp:HiddenField ID="hdCategoryUserID" runat="server" Value='<%# Eval("CategoryUserID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                      <%--  <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                    </asp:GridView>
                                 <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" Font-Names="Calibri"  cssClass="table table-striped pos-table">
                                    <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />--%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Item" DataField="IngreCategory" />
                                        <asp:BoundField HeaderText="Category" DataField="IngredientName" />
                                        <asp:BoundField HeaderText="Qty" DataField="Order_Qty" />
                                    </Columns>
                                  <%--   <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                    <%-- <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                                </div>
                                <div id="PRINTIDRec" runat="server">
                                    <asp:GridView ID="Griddc" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                        OnRowCreated="Griddc_RowCreated" OnRowDataBound="Griddc_RowDataBound" padding="0" spacing="0" border="0">
                                        <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                        <Columns>
                                            <asp:BoundField HeaderText="Category" DataField="Category" />
                                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                                            <asp:BoundField HeaderText="Order Qty" DataField="Oqty" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUOM" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdCategoryid" runat="server" Value='<%# Eval("Categoryid")%>' />
                                                    <asp:HiddenField ID="hdCategoryUserID" runat="server" Value='<%# Eval("CategoryUserID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                    </asp:GridView>
                                </div>
                                </div>
                             </div>
                             <div class="col-lg-12">
                                
                        </div>
                        </div>
                        </div>
                        
                   </div>
                    <div>
                        <asp:LinkButton ID="link" runat="server" Text="Print" OnClientClick=" printGrid()"
                            Visible="false"></asp:LinkButton>
                        &nbsp &nbsp
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Export" OnClick="LinkButton1_Click"
                            Visible="false"></asp:LinkButton>
                        <asp:GridView ID="gvGrid" runat="server" Width="100%" CssClass="mGrid">
                        </asp:GridView>
                    </div>
                    </form>
                </div>

    </div>
    </div>
    </div>
    </div>
</body>
</html>
