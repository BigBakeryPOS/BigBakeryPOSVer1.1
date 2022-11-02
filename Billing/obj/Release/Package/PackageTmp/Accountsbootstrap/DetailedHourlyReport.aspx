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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div align="center">
            <h2>
                Hourly Sales Report</h2>
        </div>
        <div align="center" class="col-lg-12">
            <div class="col-lg-2">
                <div id="Div1" align="center" runat="server">
                    <label>
                        Select Branch</label>
                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" Width="50%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-4">
                <label>
                    From</label>
                <asp:TextBox ID="txtFrom" runat="server" Width="150px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" runat="server"
                    TargetControlID="txtFrom" Format="yyyy-MM-dd">
                </ajaxToolkit:CalendarExtender>
                <label>
                    To</label>
                <asp:TextBox ID="txtTo" runat="server" Width="150px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme1" runat="server"
                    TargetControlID="txtTo" Format="yyyy-MM-dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-lg-6">
                <asp:RadioButtonList ID="radiomode" runat="server">
                    <asp:ListItem Value="Every Hour"></asp:ListItem>
                    <asp:ListItem Value="Every 30 min" Selected="True" ></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div align="center">
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-warning" Text="Search"
                OnClick="btnSearch_Click" />
            <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-danger"
                OnClick="btnexport_Click" />
        </div>
        <div align="center">
            <asp:GridView ID="gvReport" runat="server" CssClass="mGrid">
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
