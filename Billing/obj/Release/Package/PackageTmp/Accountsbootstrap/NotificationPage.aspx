<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotificationPage.aspx.cs"
    Inherits="Billing.Accountsbootstrap.NotificationPage" %>

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
    <title>Notification Alert</title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div runat="server" class="col-lg-12">
            <div id="Div1" runat="server" class="col-lg-4">
                <table runat="server" width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvip" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="RosyBrown" OnRowCommand="gvcat_RowCommand"
                                HeaderStyle-ForeColor="White" HeaderStyle-Height="30px">
                                <Columns>
                                <asp:BoundField DataField="MessageTitle" HeaderText="Messgae Title" />
                                <asp:BoundField DataField="MessageContent" HeaderText="Messgae Content" />
                                <asp:BoundField DataField="Fromdate" HeaderText="From date" />
                                <asp:BoundField DataField="Todate" HeaderText="To date" />
                                <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                                 <asp:TemplateField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("messageid") %>' CommandName="Edits"
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" /></asp:LinkButton>
                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("messageid") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div3" runat="server" class="col-lg-2">
                <div class="form-group">
                    <label>
                        Select Branch(MultiSelect)
                    </label>
                    <asp:TextBox ID="txtbranch" runat="server" onkeyup="SearchEmployees(this,'#chkbranch');"
                        CssClass="form-control"></asp:TextBox>
                    <asp:CheckBoxList ID="chkbranch" runat="server">
                    </asp:CheckBoxList>
                    <%--<asp:CustomValidator ID="CustomValidator1" ErrorMessage="Please select at least one item."
                        ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />--%>
                </div>
            </div>
            <div id="Div2" runat="server" class="col-lg-6">
                <div class="form-group">
                <asp:Label ID="lblmessgaeid" runat="server" Visible="false" ></asp:Label>
                    <label style="margin-top: -10px">
                        Message Title</label>
                    <asp:TextBox CssClass="form-control" ID="txtmsgtitle" runat="server" MaxLength="150"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label style="margin-top: -10px">
                        Message Content</label>
                    <asp:TextBox CssClass="form-control" ID="txtmessagecontent" TextMode="MultiLine"
                        runat="server" MaxLength="150"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>
                        From Date</label>
                    <asp:TextBox CssClass="form-control" ID="txtfromdate" runat="server" MaxLength="150"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                        PopupButtonID="txtfromdate" EnabledOnClient="true" runat="server" Format="dd/MM/yyyy"
                        CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                    <asp:Label ID="Label1" runat="server" Style="color: Red"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        To Date</label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" MaxLength="150"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                        Format="dd/MM/yyyy" PopupButtonID="txttodate" EnabledOnClient="true" runat="server"
                        CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="form-group">
                    <label>
                        From Time
                    </label>
                    <asp:DropDownList ID="ddlTimeFrom" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="fromtime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                        Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        TO Time</label>
                    <asp:DropDownList ID="ddlTimeTo" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="totime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                        Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        Is Active</label>
                    <asp:DropDownList ID="drpisactive" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"> </asp:ListItem>
                        <asp:ListItem Text="No" Value="No"> </asp:ListItem>
                    </asp:DropDownList>
                </div>
                   <asp:Button ID="btnadd" runat="server" class="btn btn-info" ValidationGroup="val1"
                                    Text="Save" Style="width: 120px; margin-top: 15px" OnClick="addclick" />
                                <asp:Button ID="btnexit" runat="server" class="btn  btn-warning" Style="width: 120px;
                                    margin-top: 15px" Text="Reset" PostBackUrl="~/Accountsbootstrap/NotificationPage.aspx"  />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
