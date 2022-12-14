<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseReportDetailed.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PurchaseReportDetailed" %>

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
    <title>Purchase Report </title>
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
            background-color: #0073e4;
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
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
      <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Purchase Report</h1>
	    </div>

                <div class="panel-body">
                    
                        <form id="form1" runat="server">
                        <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                               
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                                <label>
                                                    From Date</label>
                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control center-block"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtFromDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                       
                                        <div class="col-lg-3">
                                            
                                                <label>
                                                    To Date</label>
                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control center-block"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            
                                        </div>
                                        <div class="col-lg-3">
                                            <br />
                                            <asp:RadioButton ID="rdbSupplier" runat="server" Text="Supplier" CssClass="center-block"
                                                GroupName="a" AutoPostBack="true" OnCheckedChanged="rdbSupplier_OnCheckedChanged"  style="display:inline" />
                                            <asp:RadioButton ID="rdbCategory" runat="server" Text="Category" CssClass="center-block"
                                                GroupName="a" AutoPostBack="true" OnCheckedChanged="rdbCategory_OnCheckedChanged"  style="display:inline" />
                                    
                                            <asp:RadioButton ID="rdbIngredent" runat="server" Text="Ingredent" CssClass="center-block"
                                                GroupName="a" AutoPostBack="true" OnCheckedChanged="rdbIngredent_OnCheckedChanged"  style="display:inline"/>
                                        </div>

                                        <div class="col-lg-3">
                                        <br />
                                            <asp:DropDownList ID="ddl" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        </div>
                                        <div class="row">
                                        <div class="col-lg-3">
                                            <br />
                                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-success"
                                                OnClick="btnsearch_Click"  />
                                       
                                            <asp:Button ID="btnexcel" runat="server" Text="Export To Excel" CssClass="btn btn-warning"
                                                OnClick="btnexp_Click"  />
                                        </div>
                                    </div>
                               
                                <div id="Excel" runat="server">
                                <div class="table-responsive panel-grid-left">
                               
                               
                                    <asp:GridView ID="gvReport"  runat="server" EmptyDataText="Sorry Data Not Found!"
                                        OnRowDataBound="gvReport_OnRowDataBound" OnRowCreated="gvReport_OnRowCreated"
                                        cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="BillNo" HeaderText="Bill No"  />
                                            <asp:BoundField DataField="BillDate" HeaderText="Bill Date" 
                                                DataFormatString='{0:dd/MMM/yyyy}' />
                                            <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" 
                                                DataFormatString='{0:dd/MMM/yyyy}' />
                                            <asp:BoundField DataField="BillingType" HeaderText="BillType"  />
                                            <asp:BoundField DataField="LedgerName" HeaderText="Customer" />
                                            <asp:BoundField DataField="IngreCategory" HeaderText="Category" />
                                            <asp:BoundField DataField="IngredientName" HeaderText="Ingredient"  />
                                            <asp:BoundField DataField="Qty" HeaderText="Qty" DataFormatString="{0:f2}" />
                                            <asp:BoundField DataField="Rate" HeaderText="Rate" DataFormatString="{0:f2}"  />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:f2}"
                                              />
                                            <asp:BoundField DataField="Tax" HeaderText="Tax" DataFormatString="{0:f2}"  />
                                            <asp:BoundField DataField="Disc" HeaderText="Disc" DataFormatString="{0:f2}"  />
                                        </Columns>
                                    </asp:GridView>
                                    
                                </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="update">
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
