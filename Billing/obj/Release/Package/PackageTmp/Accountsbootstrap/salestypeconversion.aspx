<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="salestypeconversion.aspx.cs"
    Inherits="Billing.Accountsbootstrap.salestypeconversion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Expense</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
   
    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    <!-- Bootstrap Core CSS -->
   
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Sales Conversion Entry</h1>
	    </div>

                        <form id="Form1" runat="server">
                        <asp:UpdatePanel ID="Updatepanel1" runat="server">
                        <ContentTemplate>
                        <asp:ScriptManager ID="scriptmanager" runat="server">
                        </asp:ScriptManager>

                        <div class="col-lg-12">
                         
                        <div class="col-lg-3">
                            <div class="list-group">
                                <label>
                                   Order Date</label>
                                <asp:TextBox CssClass="form-control" ID="txtorderdate" 
                                    AutoPostBack="true" Text="--Select Date--" runat="server" 
                                    ontextchanged="TextBox1_TextChanged"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtorderdate" runat="server" Format="dd/MM/yyyy"
                                    CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            <br />
                                <label>
                                    Order.No</label>
                                <asp:DropDownList ID="ddlorderno"  AutoPostBack="true" CssClass="form-control" 
                                    Width="100%" runat="server" 
                                    onselectedindexchanged="ddlorderno_SelectedIndexChanged">
                                
                                </asp:DropDownList>
                            <br />
                            <label>Paymode Type:</label>
                            <br />
                            <asp:Label ID="orderpay" runat="server" ></asp:Label>
                           <br />
                                <label>
                                    Amount</label>
                                <asp:TextBox CssClass="form-control" Enabled="false" ID="txtOrderAmt" 
                                    runat="server"></asp:TextBox>
                            <br />
                                <label>
                                    Conversion type</label>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatColumns="3">
                                   
                                      <asp:ListItem Text="Card" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Bank" Value="11"></asp:ListItem>
                               
                                </asp:RadioButtonList>
                            <br />
                            <asp:Button ID="Button1" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" 
                                onclick="Button1_Click" />
                            <asp:Button ID="Button2" class="btn btn-lg btn-link" runat="server" Text="Reset" 
                                onclick="Button2_Click" />
                        </div>
                        </div>
                        <div class="col-lg-3" >
                            <div class="list-group">
                                <label>
                                    Date</label>
                                <asp:TextBox CssClass="form-control" ID="txtdate" OnTextChanged="txtdate_textchanged"
                                    AutoPostBack="true" Text="--Select Date--" runat="server"></asp:TextBox>
                                <asp:Label ID="lbldateError" runat="server" ForeColor="Red"></asp:Label>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdate" runat="server" Format="dd/MM/yyyy"
                                    CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                           <br />
                                <label>
                                    Bill.No</label>
                                <asp:DropDownList ID="ddlbillno" OnSelectedIndexChanged="ddlbillno_selcted" AutoPostBack="true" CssClass="form-control" Width="100%" runat="server">
                                
                                </asp:DropDownList>
                            <br />
                            <label>Paymode Type:</label><br />
                            <asp:Label ID="paylabel" runat="server" ></asp:Label>
                           <br />
                                <label>
                                    Amount</label>
                                <asp:TextBox CssClass="form-control" Enabled="false" ID="txtamount" runat="server">
                                </asp:TextBox>
                            <br />
                                <label>
                                    Conversion type</label>
                                <asp:RadioButtonList ID="checkconversion" runat="server" RepeatColumns="3">
                                   
                                      <asp:ListItem Text="Card" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Bank" Value="11"></asp:ListItem>
                               
                                </asp:RadioButtonList>
                            <br />
                            <asp:Button ID="btnsave" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnsave_Click" />
                            <asp:Button ID="btnreset" class="btn btn-lg btn-link" runat="server" Text="Reset" OnClick="btnreset_Click"/>
                        </div>
                        </div>
                        </div>
                        
                        <!-- /.col-lg-6 (nested) -->
                         </ContentTemplate>
                        </asp:UpdatePanel>
                        </form>
        
     </div>
     </div>
     </div>
     </div>  
</body>
</html>
