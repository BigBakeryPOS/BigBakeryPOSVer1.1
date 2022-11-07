<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailedHourlyReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DetailedHourlyReport" %>

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
    <title>Sales </title>
    <!-- Bootstrap Core CSS -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/TableCSSCode.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <title>Hourly Report Expanded</title>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
   
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Hourly Sales Report</h1>
	    </div>
        <div class="panel-body">
        <div class="row">
            
                <div id="Div1" class="col-lg-3" runat="server">
                    <label>
                        Select Branch</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                    </asp:DropDownList>
                </div>
            
            <div class="col-lg-3">
                <label>
                    From</label>
                <asp:TextBox ID="txtFrom" runat="server" class="form-control" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" runat="server"
                    TargetControlID="txtFrom" Format="yyyy-MM-dd">
                </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                <label>
                    To</label>
                <asp:TextBox ID="txtTo" runat="server" class="form-control" ></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme1" runat="server"
                    TargetControlID="txtTo" Format="yyyy-MM-dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-lg-3">
            <br />
                <asp:RadioButtonList ID="radiomode" runat="server" RepeatColumns="2">
                    <asp:ListItem Value="Every Hour"></asp:ListItem>
                    <asp:ListItem Value="Every 30 min" Selected="True" ></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="row">
         <div class="col-lg-3">
         <br />
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary pos-btn1" Text="Search"
                OnClick="btnSearch_Click" />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnexport" runat="server" Text="Export to Excel" CssClass="btn btn-success"
                OnClick="btnexport_Click" />
        </div>
        </div>
        <div align="center">
        <div class="table-responsive panel-grid-left">
            <asp:GridView ID="gvReport" runat="server" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                <%--<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
            </asp:GridView>
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
