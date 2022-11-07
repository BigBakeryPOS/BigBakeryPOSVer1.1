<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullSalesReport2.aspx.cs"
    Inherits="Billing.Accountsbootstrap.FullSalesReport2" %>

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
    <title>Tax Wise Order Report</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
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
        
        
        .myGridStyle
        {
            font-family: "Comic Sans MS";
            border-collapse: collapse;
            font-names: "Comic Sans MS";
            rowstyle-borderstyle: "Double";
            headerstyle-horizontalalign: "Center";
            font-weight: "bold";
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
          <h1 class="page-header">Tax Wise Order Report</h1>
	    </div>
   
         <div class="panel-body">
           <div class="row">
            <div class="col-lg-3">
                
                    <label>
                        Select Branch</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                    </asp:DropDownList>
               
            </div>
            <div class="col-lg-3">
                
                    <label>
                        From Date</label>
                    <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" 
                         Text="--Select Date--"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtfrmdate"
                        ErrorMessage="Please enter From Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfrmdate"
                        Format="yyyy-MM-dd" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
               
            </div>
            <div id="Div1" class="col-lg-3" runat="server" visible="true">
               
                    <label>
                        To Date</label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" 
                        Text="--Select Date--"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                        ControlToValidate="txttodate" ErrorMessage="Please enter To Date!" Text="" Style="color: White" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                        Format="yyyy-MM-dd" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
               
            </div>
            <div id="Div2" class="col-lg-3" runat="server" visible="false">
                <div class="form-group">
                    <label>
                        Category</label>
                    <asp:DropDownList ID="ddlsalestype" runat="server" class="form-control" 
                        Visible="true">
                        <asp:ListItem Text="Sales" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Order" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlcat" runat="server" class="form-control"  Visible="false">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <label>
                    Admin PassWord</label>
                <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" CssClass="form-control"
                    placeholder="Enter your Password" AutoPostBack="true" OnTextChanged="txtpassword_OnTextChanged"></asp:TextBox>
            </div>
            </div>
            <div class="row">
            <div class="col-lg-1">
                    <asp:Button ID="btnsearch" runat="server" ValidationGroup="val1" class="btn btn-primary pos-btn1"
                        Text="Search" OnClick="Search_Click" width="100px" />
            </div>
            <div id="Div3" class="col-lg-1" runat="server" visible="true">
                    <asp:Button ID="btnexcel" runat="server" ValidationGroup="val1" class="btn btn-success"
                        Text="Excel" OnClick="btnexcel_Click" width="100px" />
            </div>
            <div id="Div5" class="col-lg-1" runat="server" visible="true">
                    <asp:Button ID="btnpdf" runat="server" ValidationGroup="val1" class="btn btn-info"
                        Text="PDF" OnClick="btnpdf_Click" width="100px"  />
                </div>
            <div id="Div4" class="col-lg-3" runat="server" visible="false">
               
                    <label>
                        Category</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" 
                        Visible="true">
                        <asp:ListItem Text="Sales" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Order" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" 
                        Visible="false">
                    </asp:DropDownList>
               
            </div>
          </div>
    <div class="col-lg-12">
        <div class="col-lg-3">
        </div>
        <div class="col-lg-7">
            <asp:Label runat="server" ID="lblstkreturn" ForeColor="RoyalBlue" Visible="true"> </asp:Label>
        </div>
        <div class="col-lg-2">
        </div>
    </div>

                        <div class="table-responsive panel-grid-left">
                        <asp:GridView ID="gvSalesValue" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                            EmptyDataText="No Record found" Width="100%" ShowFooter="true" padding="0" spacing="0" border="0">
                            <Columns>
                                <asp:BoundField HeaderText="BillNo" DataField="BillNo" />
                                <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                <asp:BoundField HeaderText="BookNo" DataField="BookNo" />
                                <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString='{0:dd/MMM/yyyy}'
                                    />
                                <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}'
                                     />
                                <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:d}'  />
                                <asp:BoundField HeaderText="Paytype" DataField="Paytype" />
                                <asp:BoundField HeaderText="SubTotal" DataField="SubTotal" DataFormatString='{0:d}'
                                     />
                                <asp:BoundField HeaderText="CGST" DataField="CGST" DataFormatString='{0:f}'  />
                                <asp:BoundField HeaderText="SGST" DataField="SGST" DataFormatString='{0:f}'  />
                                <%--
                                <asp:BoundField HeaderText="Margin" DataField="Margin" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right"/>
                                     <asp:BoundField HeaderText="BasicValue" DataField="BasicValue" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right"/>
                                 <asp:BoundField HeaderText="CGST %" DataField="CGST" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="CGST" DataField="GSTAmt" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right"/>
                                 <asp:BoundField HeaderText="SGST %" DataField="CGST" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="SGST" DataField="GSTAmt" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right"/>
                                <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />--%>
                            </Columns>
                            <%--<FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />--%>
                        </asp:GridView>
                        </div>

    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
