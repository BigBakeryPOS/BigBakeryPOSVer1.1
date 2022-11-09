<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReportsforBoth.aspx.cs"
    Inherits="Billing.Accountsbootstrap.StockReportsforBoth" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Stock Master</title>
  
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
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
</head>
<body style="">
    <form runat="server" id="form1" method="post">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Stock Return and GRN(+)(-)</h1>
	    </div>
        <div class="panel-body">
         <div class="row">      
        <div class="col-lg-12">
           
            <div class="col-lg-3">
                
                    <label>
                        From Date</label>
                    <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" 
                         Text="--Select Date--"   AutoPostBack="true"  ontextchanged="txttodate_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please enter From Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfrmdate" Format="yyyy-MM-dd"
                        runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                
            </div>
            <div class="col-lg-3">
                
                    <label>
                        To Date</label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server"
                        Text="--Select Date--"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                        ControlToValidate="txttodate" ErrorMessage="Please enter To Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate" Format="yyyy-MM-dd"
                        runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                
            </div>
            <div class="col-lg-3">
               
                    <label>
                        Category</label>
                    <asp:DropDownList ID="ddlcat" runat="server" class="form-control" >
                    </asp:DropDownList>
               
            </div>
            <div class="col-lg-3">
                
                    <br />
                    <asp:Button ID="btnsearch" runat="server" ValidationGroup="val1" class="btn btn-success pos-btn1"
                        Text="Search" OnClick="Search_Click" Style="width: 100px" />
                
                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnexcel" runat="server" ValidationGroup="val1" class="btn btn-success"
                        Text="Excel" OnClick="btnexcel_Click" Style="width: 100px" />
               
            </div>
        </div>
  </div>
  <div class="row">   
    <div class="col-lg-12">
       
       <div class="col-lg-12">
            <asp:Label runat="server" ID="lblstkreturn" ForeColor="RoyalBlue" Visible="true"> </asp:Label>
       </div>
       
                    <div class="col-lg-6">
                    <br />
                        <label>
                            Stock Return</label>
                             <div class="table-responsive panel-grid-left">
                        <asp:GridView ID="gvreturn" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                            EmptyDataText="No Record found" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Date" DataField="RetDate"   DataFormatString="{0:dd-MMM-yyyy}"/>
                                <asp:BoundField HeaderText="Category" DataField="Category" />
                                <asp:BoundField HeaderText="Product" DataField="Definition" />
                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                <asp:BoundField HeaderText="TotalAmount" DataField="TotalAmount" />
                            </Columns>
                            <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                        </div>
                    </div>
                    <div class="col-lg-6">
                    <br />
                        <label>
                            GRN (+)(-)</label>
                             <div class="table-responsive panel-grid-left">
                        <asp:GridView ID="gvgrnmp" runat="server" AutoGenerateColumns="false" padding="0" spacing="0" border="0" cssClass="table table-striped pos-table"
                            EmptyDataText="No Record found" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Date" DataField="Date" />
                                <asp:BoundField HeaderText="Category" DataField="Category" />
                                <asp:BoundField HeaderText="Product" DataField="Definition" />
                                <asp:BoundField HeaderText="Quantity" DataField="GRN_Qty" />
                                <asp:BoundField HeaderText="TotalAmount" DataField="TotalAmount" />
                            </Columns>
                            <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                        </asp:GridView>
                        </div>
                    </div>

                </div>
            </div>
       </div>
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
