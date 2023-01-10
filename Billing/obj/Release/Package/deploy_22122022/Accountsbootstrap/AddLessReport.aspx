<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLessReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.AddLessReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Add Less Report</h1>
	    </div>

            <div class="panel-body">
               <div class="row">
                    <div id="Div1" runat="server" class="col-lg-3">
                        <label>
                            Select Branch</label>
                        <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                        </asp:DropDownList>
                    </div>
               
                <div class="col-lg-3">
                    <label>From</label>
                    <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtFrom" CssClass="cal_Theme1"
                        Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                    <b>To</b>
                    <asp:TextBox ID="txtto" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtto" CssClass="cal_Theme1"
                        Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                <br />
                    <asp:Button ID="btnsave" runat="server" Text="Search" CssClass="btn btn-info pos-btn1"
                        OnClick="btnsave_Click" />
                </div>
            
      
            <div class="col-lg-12">
                        <div class="table-responsive panel-grid-left">
                <asp:GridView ID="gvResilt" runat="server" AutoGenerateColumns="false" EmptyDataText="No Records Found"
                    cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="BookNo" HeaderText="Order Book No" />
                        <asp:BoundField DataField="Amount" HeaderText="Bill Amount" />
                        <asp:BoundField DataField="Add" HeaderText="Add" />
                        <asp:BoundField DataField="Less" HeaderText="Less" />
                        <asp:BoundField DataField="Total" HeaderText="Total" />
                    </Columns>
                </asp:GridView>
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
