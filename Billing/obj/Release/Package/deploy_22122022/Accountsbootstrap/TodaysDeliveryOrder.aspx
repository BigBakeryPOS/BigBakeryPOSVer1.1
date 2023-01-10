<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodaysDeliveryOrder.aspx.cs"
    Inherits="Billing.Accountsbootstrap.TodaysDeliveryOrder" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Customer Order </title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    <%--<script type="text/javascript" src="../jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar.css"/>--%>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <script type="text/javascript">
        function myFunction() {
            confirm("Do You Want to Cancel this Order!");
        }
    </script>
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
    <style>
        .messagepop
        {
            border: 1px solid #999999;
            cursor: default;
            display: none;
            position: fixed;
            text-align: left;
            width: 394px;
            height: 100px;
            z-index: 80;
            padding: 25px 25px 20px;
            border-radius: 7px;
            background: #e84c3d;
            margin: 30px auto 0;
            padding: 6px;
            color: White;
            top: 50%;
            left: 50%;
            margin-left: -400px;
            margin-top: -40px;
        }
    </style>
    <script language="javascript">
        function shw() {
            var sub = document.getElementById("popup");
            sub.style.display = 'block';
        }

       
    </script>
    <script language="javascript">


        function hide() {
            var sub = document.getElementById("popup");
            if (document.getElementById("txtnam").value == "") {
                alert('Pleae enter your name');
            }
            else {

                sub.style.display = 'none';
            }
        }


     
    </script>
    <script language="javascript">


        function Check() {

            if (document.getElementById("txtRef").value == "") {
                alert('Pleae enter your name');
            }

        }


     
    </script>
    <script>
        function klose() {
            var sub = document.getElementById("popup");

            sub.style.display = 'none';

        }
    </script>
    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <style type="text/css">
        .dangerFailed
        {
            background-color: #add5fe;
            border-color: Orange;
        }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <div class="row">
        
    </div>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">  </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
            <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Todays Delivery Orders</h1>
	    </div>
           
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12" >
                            <form id="form1" runat="server">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            
                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvorderToday" runat="server" AutoGenerateColumns="false" Width="100%" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                     OnRowCommand="gvrest_RowCommand">
                                  <%--  <HeaderStyle Font-Names="Comic Sans MS" />--%>
                                  <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                        <asp:BoundField HeaderText="OrderNo" DataField="BookNo" />
                                         <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                          <asp:BoundField HeaderText="BillNo" DataField="BillNo" />
                                             <asp:BoundField HeaderText="Time" DataField="deliverytime" />
                                              <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                        <asp:BoundField HeaderText="TotalQty" DataField="TotalQty" />
                                         <asp:BoundField HeaderText="NetAmount" Visible="false" DataField="NetAmount" />
                                       

                                    
                                        <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Print"
                                                    runat="server">
                                                    <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" width="55px" Visible="false" />
                                                    <button type="button" class="btn btn-default btn-md">
						                                <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                </button>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                            
                            </form>
                        </div>
                    </div>
                </div>
            </div>
       
    </div>
    </div>
    </div>
</body>
</html>
