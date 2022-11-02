<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderGrid.aspx.cs" EnableEventValidation="true"
    Inherits="Billing.Accountsbootstrap.OrderGrid" %>

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
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">  </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <div class="panel panel-default" style="">
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Order Details</b></div>
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div class="col-lg-12" style="">
                            <form runat="server" id="form1" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <asp:Label ID="lblpendingdays" runat="server" Text="60" Visible="false" ></asp:Label>
                            <asp:UpdatePanel ID="Update" runat="server" EnableViewState="true" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-lg-12" style="">
                                        <div class="col-lg-3" runat="server" visible="false" style="">
                                            <label>
                                                Enter Order Cancel Password</label>
                                            <asp:TextBox ID="txtcancelpassword" runat="server" Width="200px" CssClass="form-control"
                                                TextMode="Password" AutoPostBack="false" OnTextChanged="txtcancelpassword_OnTextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3" style="">
                                            <br />
                                            <asp:Button ID="btnadd" runat="server" style="background-color: #428bca; border: 3px solid #428bca;    margin-left: 1294px;" class="btn btn-success" Text="Add New Order"
                                                OnClick="btnadd_Click" /></div>
                                        <div class="col-lg-3" style="">
                                            <asp:Button ID="btnemail" runat="server" Visible="false" CssClass="btn btn-default" Text="Email"
                                                OnClick="btnSendMail_Click" />
                                            <div runat="server" visible="false">
                                                <asp:GridView ID="gvorderinfo" runat="server">
                                                    
                                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                                </asp:GridView>
                                            </div>
                                            <div class="form-group" style="">
                                                <asp:TextBox ID="txtser" runat="server" Visible="false" Style="width: 250px;" placeholder="Search Custer Name"
                                                    onkeyup="Search_Gridview(this, 'gvOrder')"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group" style="">
                                            <asp:DropDownList ID="ddlsearch" CssClass="form-control" Visible="false" runat="server"
                                                Width="237px">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" Style="margin-top: 0px;"
                                                Visible="false" />
                                            <asp:Button ID="btnsyncclick" runat="server" class="btn btn-warning" Text="Sync. to Production"
                                                Visible="false" OnClick="btnsyncclick_OnClick" Width="170px" />
                                            <br />
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="">
                                        <div class="table-responsive" style="">
                                            <asp:GridView ID="gvorderToday" runat="server"  Width="100%" HeaderStyle-Height="40px" AutoGenerateColumns="false"
                                                Font-Names="Calibri" DataKeyNames="orderno" Caption="Today Delivery Orders" OnRowCommand="gvorderToday_RowCommand"
                                                OnRowDataBound="GVORderToday_Rowdatabound" Font-Bold="true" CellPadding="20"
                                                Visible="true">
                                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                    <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                                                    <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                                    <asp:BoundField HeaderText="TotalAmount" DataField="NetAmount" DataFormatString="{0:###,##0.00}" />
                                                    <asp:TemplateField HeaderText="Paid Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpaid" runat="server"></asp:Label>
                                                            <asp:Label ID="lblorderno" runat="server" Visible="false" Text='<%#Eval("OrderNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString="{0:###,##0.00}" />--%>
                                                    <asp:BoundField HeaderText="Balance" DataField="balancepaid" DataFormatString="{0:###,##0.00}" />
                                                    <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                    <asp:BoundField HeaderText="Time" DataField="deliverytime" />
                                                    <asp:BoundField HeaderText="Order Date" DataField="orderdate" DataFormatString="{0:dd/MM/yyyy hh:mm:ss tt}" />
                                                    <%--<asp:BoundField HeaderText="Ref.Amnt" DataField="RefundAmount" DataFormatString="{0:###,##0.00}" />--%>
                                                    <asp:TemplateField HeaderText="Ref.Amnt">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRefamnt" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delivery Status">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnstst" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Status"
                                                                runat="server">
                                                                <asp:Label ID="lblstatus" ForeColor="White" runat="server" Text='<%#Eval("DeliveryStatus") %>'></asp:Label>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Print"
                                                                runat="server">
                                                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" width="55px" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay Bill">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnBill" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Bill"
                                                                runat="server">
                                                                <asp:Image ID="imgBill" runat="server" ImageUrl="~/images/Billing.png" width="45px"  />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Invoice Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btninvprint" CommandArgument='<%#Eval("OrderNo") %>' CommandName="InvPrint"
                                                                runat="server">
                                                                <asp:Image ID="imginvprint" runat="server" ImageUrl="~/images/print (1).png" width="55px" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cancel Order">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btncancelnew" runat="server" CommandArgument='<%#Eval("OrderNo") %>'
                                                                CommandName="Cancell">
                                                                <asp:Image ID="imgcancelnew" runat="server" ImageUrl="~/images/cancel-circle.png" width="37px"  /></asp:LinkButton>
                                                            <%-- <asp:ImageButton ID="imgdisablenew" ImageUrl="~/images/delete.png" runat="server"
                                                                        Visible="false" Enabled="false" ToolTip="Not Allow To Delete" />--%>
                                                            <%-- <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtendernew" runat="server"
                                                                        CancelControlID="ButtonDeleteCancelnew" OkControlID="ButtonDeleleOkaynew" TargetControlID="btncancelnew"
                                                                        PopupControlID="DivDeleteConfirmationnew" BackgroundCssClass="ModalPopupBG">
                                                                    </ajaxToolkit:ModalPopupExtender>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtendernew" runat="server"
                                                                        TargetControlID="btncancelnew" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtendernew">
                                                                    </ajaxToolkit:ConfirmButtonExtender>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit Order">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btneditBill" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Editt"
                                                                runat="server">
                                                                <asp:Image ID="imgBilledit" runat="server" ImageUrl="~/images/edit.png" width="55px" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="gvrest" runat="server" AllowPaging="false" Width="100%"  HeaderStyle-Height="40px" AutoGenerateColumns="false"
                                                Font-Names="Calibri" DataKeyNames="orderno" Caption="Upcoming Orders" Font-Bold="true" OnRowCommand="gvrest_RowCommand"
                                                OnRowDataBound="gvrest_RowDataBound">
                                                <%-- <HeaderStyle BackColor="#990000" />--%>
                                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />
                                                <PagerSettings FirstPageText="1" Mode="Numeric" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                    <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                                                    <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                                    <asp:BoundField HeaderText="TotalAmount" DataField="NetAmount" DataFormatString="{0:###,##0.00}" />
                                                    <asp:TemplateField HeaderText="Paid Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpaid" runat="server"></asp:Label>
                                                            <asp:Label ID="lblorderno" runat="server" Visible="false" Text='<%#Eval("OrderNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString="{0:###,##0.00}" />--%>
                                                    <asp:BoundField HeaderText="Balance" DataField="balancepaid" DataFormatString="{0:###,##0.00}" />
                                                    <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                    <asp:TemplateField Visible="true" HeaderText="OrderDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="Refund Amount" DataField="RefundAmount" DataFormatString="{0:###,##0.00}" />--%>
                                                    <asp:TemplateField HeaderText="Refund Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRefamnt" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delivery Status">
                                                        <ItemTemplate>
                                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("DeliveryStatus") %>'></asp:Label>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Print"
                                                                runat="server">
                                                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" width="55px"/>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay Bill" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnBill" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Bill"
                                                                runat="server">
                                                                <asp:Image ID="imgBill" runat="server" ImageUrl="~/images/Billing.png" width="45px"  />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--  <asp:TemplateField HeaderText="Cancel Order" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btncancel" runat="server" CommandArgument='<%#Eval("OrderNo") %>'
                                                                        CommandName="Cancel">
                                                                        <asp:Image ID="imgecancel" runat="server" ImageUrl="~/images/cancel-circle.png" /></asp:LinkButton>

                                                                          <asp:ImageButton ID="imgdisable1" ImageUrl="~/images/delete.png" runat="server" Visible="false"
                                                                                Enabled="false" ToolTip="Not Allow To Delete" />

                                                                    <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                                        CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btncancel"
                                                                        PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                                    </ajaxToolkit:ModalPopupExtender>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                                        TargetControlID="btncancel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Cancel Order">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btncancelnew" runat="server" CommandArgument='<%#Eval("OrderNo") %>'
                                                                CommandName="Cancell">
                                                                <asp:Image ID="imgcancelnew" runat="server" ImageUrl="~/images/cancel-circle.png" width="37px"  /></asp:LinkButton>
                                                            <%--  <asp:ImageButton ID="imgdisablenew" ImageUrl="~/images/delete.png" runat="server"
                                                                        Visible="false" Enabled="false" ToolTip="Not Allow To Delete" />--%>
                                                            <%-- <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtendernew" runat="server"
                                                                        CancelControlID="ButtonDeleteCancelnew" OkControlID="ButtonDeleleOkaynew" TargetControlID="btncancelnew"
                                                                        PopupControlID="DivDeleteConfirmationnew" BackgroundCssClass="ModalPopupBG">
                                                                    </ajaxToolkit:ModalPopupExtender>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtendernew" runat="server"
                                                                        TargetControlID="btncancelnew" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtendernew">
                                                                    </ajaxToolkit:ConfirmButtonExtender>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit Order" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnlinkedit" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Editt"
                                                                runat="server">
                                                                <asp:Image ID="btnimgedit" runat="server" ImageUrl="~/images/edit.png" width="55px" />
                                                            </asp:LinkButton>
                                                            <%-- <asp:ImageButton ID="btnimgbtedit" ImageUrl="~/images/edit.png" runat="server" Visible="false"
                                                                        Enabled="false" ToolTip="Not Allow To Edit" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Add/Less Amount" Visible="false" HeaderStyle-CssClass="hidden">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnamt" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Amount"
                                                                runat="server">
                                                                <asp:Image ID="imgamt" runat="server" ImageUrl="~/images/transfer.jpg" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Payment" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnpayment" CommandArgument='<%#Eval("OrderNo") %>' CommandName="PAmount"
                                                                runat="server">
                                                                <asp:Image ID="payamt" runat="server" ImageUrl="~/images/edit_add.png" width="55px" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <%-- <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                                <%-- <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                            </asp:GridView>
                                            <asp:RadioButtonList ID="radstatus" runat="server" OnSelectedIndexChanged="status_checked"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="Pending" Value="Pending" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Delivered" Value="Delivered"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:GridView ID="GridView1" HeaderStyle-Height="40px" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                                Width="100%" DataKeyNames="orderno" Caption="Pending Orders" Font-Bold="true" OnRowCommand="GridView1_RowCommand"
                                                Font-Names="Calibri" OnRowDataBound="GridView1_OnRowDataBound">
                                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />
                                                <RowStyle ForeColor="Red" Font-Bold="true" />
                                                <%--<HeaderStyle BackColor="#990000" />--%>
                                                <PagerSettings FirstPageText="1" Mode="Numeric" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                                    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                    <asp:BoundField HeaderText="Mobile" DataField="MobileNo" />
                                                    <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                                    <asp:BoundField HeaderText="TotalAmount" DataField="NetAmount" DataFormatString="{0:###,##0.00}" />
                                                    <asp:TemplateField HeaderText="Paid Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpaid" runat="server"></asp:Label>
                                                            <asp:Label ID="lblorderno" runat="server" Visible="false" Text='<%#Eval("OrderNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField HeaderText="PaidAmount" DataField="PaidAmount" DataFormatString="{0:###,##0.00}" />--%>
                                                    <asp:BoundField HeaderText="Balance" DataField="balancepaid" DataFormatString="{0:###,##0.00}" />
                                                    <asp:BoundField HeaderText="DeliveryDate" DataField="DeliveryDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                                    <asp:TemplateField Visible="false" HeaderText="OrderDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="PendingDays" DataField="PendingDays" />
                                                    <%--<asp:BoundField HeaderText="Refund Amount" DataField="RefundAmount" DataFormatString="{0:###,##0.00}" />--%>
                                                    <asp:TemplateField HeaderText="Refund Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRefamnt" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delivery Status">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnstst" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Status"
                                                                runat="server">
                                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("DeliveryStatus") %>'></asp:Label>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Pending Reason">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnpenstst" CommandArgument='<%#Eval("OrderNo") %>' CommandName="PendingMSG"
                                                                runat="server">
                                                                <img src="../images/add.jpg" width="70px" />
                                                            </asp:LinkButton>
                                                            <asp:Label ID="lblpendingmsg" runat="server" Text='<%#Eval("PendingMsg") %>' ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--   <asp:TemplateField HeaderText="PendingDays">
                                                        <ItemTemplate>
                                                        <asp:Label ID="lblPending" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Print">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Print"
                                                                runat="server">
                                                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png"  width="55px" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay Bill" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnBill" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Bill"
                                                                runat="server">
                                                                <asp:Image ID="imgBill" runat="server" ImageUrl="~/images/Billing.png" width="45px"  />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cancel Order">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btncancel" runat="server" CommandArgument='<%#Eval("OrderNo") %>'
                                                                CommandName="Cancell">
                                                                <asp:Image ID="imgcancel" runat="server" ImageUrl="~/images/cancel-circle.png" width="37px"  /></asp:LinkButton>
                                                            <%--<ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                                        CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btncancel"
                                                                        PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                                    </ajaxToolkit:ModalPopupExtender>
                                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                                        TargetControlID="btncancel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                                    </ajaxToolkit:ConfirmButtonExtender>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit Order" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnlinkedit" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Editt"
                                                                runat="server">
                                                                <asp:Image ID="btnimgedit" runat="server" ImageUrl="~/images/edit.png" width="55px"/>
                                                            </asp:LinkButton>
                                                            <%-- <asp:ImageButton ID="btnimgbtedit" ImageUrl="~/images/edit.png" runat="server" Visible="false"
                                                                        Enabled="false" ToolTip="Not Allow To Edit" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Payment" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnpayment" CommandArgument='<%#Eval("OrderNo") %>' CommandName="PAmount"
                                                                runat="server">
                                                                <asp:Image ID="payamt" runat="server" ImageUrl="~/images/edit_add.png" width="55px" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Add/Less Amount" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnamt" CommandArgument='<%#Eval("OrderNo") %>' CommandName="Amount"
                                                                runat="server">
                                                                <asp:Image ID="imgamt" runat="server" ImageUrl="~/images/transfer.jpg" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <%--<HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div title="What's Your Name" id="popup" class="messagepop">
                                       
                                        <div id="olddiv" runat="server" visible="false" >
                                         Current Login Details:<asp:Label ID="lblcurrentuser" Font-Bold="true" BackColor="Black"
                                            runat="server"></asp:Label>
                                        <br />
                                        Enter Your Name
                                        <asp:TextBox ID="txtnam" runat="server" Style="background-color: White; color: #e84c3d"></asp:TextBox>
                                        <asp:TextBox ID="txtpendingmsg" runat="server" TextMode="MultiLine" Visible="false" Style="background-color: White; color: #e84c3d" ></asp:TextBox>
                                        <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_click" ForeColor="Black" />
                                         <a onclick="klose();" style="color: White; background-color:Black" class="ui-btn ui-corner-all ui-shadow ui-btn ui-icon-delete ui-btn-icon-notext ui-btn-right">
                                            Close</a>
                                        </div>
                                        <div id="Newdiv" runat="server" visible="false" >
                                       <asp:Label Font-Bold="true" Font-Size="16px" runat="server" Text="Enter Your Book No" > </asp:Label><br />
                                        <asp:label id="lblbookcode" Font-Bold="true" Font-Size="16px" runat="server"></asp:label>
                                        
                                        <asp:TextBox ID="txtbookNo" MaxLength="4" Width="30%" Font-Bold="true" Font-Size="20px" runat="server" Style="background-color: White; color: #191717"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterType="Numbers" ValidChars="" TargetControlID="txtbookNo" />
                                        <asp:Button ID="btok1" runat="server" Text="Order Now" OnClick="btnok1_click" class="btn btn-success" ForeColor="Black" />
                                         <a onclick="klose();"  class="btn btn-warning" >
                                            Close</a>
                                        </div>
                                        
                                       
                                    </div>
                                    <asp:LinkButton Text="" ID="lnkFake" runat="server"></asp:LinkButton>
                                    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup"
                                        TargetControlID="lnkFake" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                    </ajaxToolkit:ModalPopupExtender>
                                    <asp:Panel Width="30%" class="popupConfirmation" ID="pnlPopup" Style="display: none;
                                        background: #fffbd6" runat="server">
                                        <div class="popup_Container">
                                            <div class="popup_Titlebar" id="PopupHeader">
                                                <div>
                                                    <asp:TextBox ID="txtcancelpassword1" runat="server" Width="200px" CssClass="form-control"
                                                        TextMode="Password" Visible="false"></asp:TextBox>
                                                </div>
                                                <div align="center" style="color: Red" class="TitlebarLeft">
                                                    Warning Message!!!</div>
                                                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                                </div>
                                            </div>
                                            <div align="center" style="color: Red" class="popup_Body">
                                                <b>Refund Amount :
                                                    <asp:Label ID="lblrefundamount" runat="server" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                                                </b>
                                                <br />
                                                <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Name "></asp:TextBox>
                                                <br />
                                                <asp:DropDownList ID="drpPayment" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <p>
                                                    Are you sure want to Cancel this Order?
                                                </p>
                                                <asp:Button ID="btnyes" OnClick="CancelYes_click" runat="server" Text="Yes" CssClass="button" />
                                                <asp:Button ID="btnClose" runat="server" Text="No" CssClass="button" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvrest" />
                                    <asp:AsyncPostBackTrigger ControlID="gvorderToday" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%-- <asp:Panel Width="30%" class="popupConfirmationnew" ID="DivDeleteConfirmationnew"
                                Style="display: none; background: #fffbd6" runat="server">
                                <div class="popup_Container">
                                    <div class="popup_Titlebar" id="Div1">
                                        <div>
                                        </div>
                                        <div align="center" style="color: Red" class="TitlebarLeft">
                                            Warning Message!!!</div>
                                        <div class="TitlebarRight" onclick="$get('ButtonDeleteCancelnew').click();">
                                        </div>
                                    </div>
                                    <div align="center" style="color: Red" class="popup_Body">
                                        <asp:TextBox ID="txtRefnew" runat="server" placeholder="Enter Name "></asp:TextBox>
                                        <p>
                                            Are you sure want to Cancel this Order?
                                        </p>
                                    </div>
                                    <div align="center" class="popup_Buttons">
                                        <input id="ButtonDeleleOkaynew" type="button" value="Yes" />
                                        <input id="ButtonDeleteCancelnew" type="button" value="No" />
                                    </div>
                                </div>
                            </asp:Panel>--%>
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
