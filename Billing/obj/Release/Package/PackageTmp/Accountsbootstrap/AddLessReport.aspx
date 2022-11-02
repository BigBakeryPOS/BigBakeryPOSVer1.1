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
    <div class="panel-danger">
        <div class="row">
            <div class="col-lg-10">
                <div class="col-lg-3">
                    <div id="Div1" runat="server">
                        <label>
                            Select Branch</label>
                        <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <b>From</b>
                    <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtFrom"
                        Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                    <b>To</b>
                    <asp:TextBox ID="txtto" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtto"
                        Format="yyyy-MM-dd">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                    <asp:Button ID="btnsave" runat="server" Text="Search" CssClass="btn btn-success"
                        OnClick="btnsave_Click" />
                </div>
            </div>
        </div>
        <div class="row" align="center">
            <div class="col-lg-10">
                <asp:GridView ID="gvResilt" runat="server" AutoGenerateColumns="false" EmptyDataText="No Records Found"
                    CssClass="mGrid">
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
    </form>
</body>
</html>
