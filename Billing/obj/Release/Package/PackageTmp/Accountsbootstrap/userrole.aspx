<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userrole.aspx.cs" Inherits="Billing.Accountsbootstrap.userrole" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>User Registration</title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <!--script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtBrandname'), "Branch Name")
            {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
    </script-->
    <!-- Bootstrap Core CSS -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../css/bootstrap.min.css" runat="server" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link id="Link2" href="../css/plugins/metisMenu/metisMenu.min.css" runat="server"
        rel="stylesheet" />
    <!-- Custom CSS -->
    <link id="Link3" href="../css/sb-admin-2.css" runat="server" rel="stylesheet" />
    <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="../js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <script src="../js/jquery-2.1.0.min.js" type="text/javascript"></script>
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <style>
        .r-tabs .r-tabs-nav .r-tabs-tab {
            background-color: #007AFF;
        }

        .r-tabs {
            border: 0;
            padding: 2px;
            background: #007AFF;
        }

            .r-tabs .r-tabs-nav .r-tabs-state-active .r-tabs-anchor, .r-tabs .r-tabs-accordion-title.r-tabs-state-active .r-tabs-anchor {
                color: #243333;
            }

            .r-tabs .r-tabs-accordion-title .r-tabs-anchor {
                border: 0;
                background: #007AFF
            }
    </style>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="row panel-custom1">
            <div class="col-lg-12">
                <h1 class="page-header">User Role Master</h1>
            </div>
            <div class="panel-body">
                <div class="col-md-3" style="height: calc(100vh - 215px); overflow-y: auto;">
                    <!-- left -->
                    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                        ID="val1" ShowMessageBox="true" ShowSummary="false" />
                    <div class="form-group" id="divcode" runat="server">
                        <asp:TextBox CssClass="form-control" ID="txtUserid" runat="server" Enabled="false"></asp:TextBox>
                    </div>                   
                    <div class="form-group ">
                        <label>
                            Select LoginType</label>
                        <asp:DropDownList ID="drplogintype" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group ">
                        <label>
                            Enter Employee Role</label>
                        <asp:TextBox ID="txtemprole" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-9" style="height: calc(100vh - 215px); overflow-y: auto;">
                    <!-- right -->
                    <div id="horizontalTab">
                        <ul>
                            <li><a href="#tab-1">Master Menu</a></li>
                            <li><a href="#tab-2">Order Form Menu</a></li>
                            <li><a href="#tab-3">Inventory Menu</a></li>
                            <li><a href="#tab-4">Request Accept</a></li>
                            <li><a href="#tab-5">Reports</a></li>
                            <li><a href="#tab-6">Reports Detailed View</a></li>
                              <li><a href="#tab-7">User Menu</a></li>
                        </ul>
                        <div class="" id="tab-1">


                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdmaster" AutoGenerateColumns="False" BorderWidth="0px" BorderStyle="Solid"
                                        GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="table table-striped table-hover pos-table">
                                        <SelectedRowStyle CssClass="SelectdataRow" />
                                        <AlternatingRowStyle CssClass="altRow" />
                                        <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                        <%-- <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChangedadd1"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged1" Font-Size="11px"
                                                        Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged1"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged1"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged1"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>
                        <div class="" id="tab-2">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="OrderFormMenu" AutoGenerateColumns="False" BorderWidth="0px" BorderStyle="Solid"
                                        GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="table table-striped table-hover pos-table">
                                        <%-- <RowStyle CssClass="dataRow" />
                                                                <SelectedRowStyle CssClass="SelectdataRow" />
                                                                <AlternatingRowStyle CssClass="altRow" />
                                                                <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                                                <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChangedadd2"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged2" Font-Size="11px"
                                                        Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged2"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged2"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged2"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="" id="tab-3">

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdinventory" AutoGenerateColumns="False" BorderWidth="0px" BorderStyle="Solid"
                                        GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="table table-striped table-hover pos-table">
                                        <%--  <RowStyle CssClass="myGridStyle" />
                                                                <SelectedRowStyle CssClass="SelectdataRow" />
                                                                <AlternatingRowStyle CssClass="altRow" />
                                                                <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                                                <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChangedadd3"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged3" Font-Size="11px"
                                                        Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged3"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged3"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged3"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="" id="tab-4">

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grRequestAccept" AutoGenerateColumns="False" BorderWidth="0px"
                                        BorderStyle="Solid" GridLines="Both" SaveButtonID="SaveButton" runat="server"
                                        CssClass="table table-striped table-hover pos-table">
                                        <%--<RowStyle CssClass="dataRow" />
                                                                <SelectedRowStyle CssClass="SelectdataRow" />
                                                                <AlternatingRowStyle CssClass="altRow" />
                                                                <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                                                <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChangedadd4"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged4" Font-Size="11px"
                                                        Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged4"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged4"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged4"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="" id="tab-5">

                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdreport" AutoGenerateColumns="False" BorderWidth="0px" BorderStyle="Solid"
                                        GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="table table-striped table-hover pos-table">
                                        <%-- <RowStyle CssClass="dataRow" />
                                                                <SelectedRowStyle CssClass="SelectdataRow" />
                                                                <AlternatingRowStyle CssClass="altRow" />
                                                                <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                                                <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="" id="tab-6">

                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grddetailedreport" AutoGenerateColumns="False" BorderWidth="0px"
                                        BorderStyle="Solid" GridLines="Both" SaveButtonID="SaveButton" runat="server"
                                        CssClass="table table-striped table-hover pos-table">
                                        <%-- <RowStyle CssClass="dataRow" />
                                                                <SelectedRowStyle CssClass="SelectdataRow" />
                                                                <AlternatingRowStyle CssClass="altRow" />
                                                                <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                                                <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        Font-Size="11px" Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                         <div class="" id="tab-7">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:GridView ID="grdUser" AutoGenerateColumns="False" BorderWidth="0px" BorderStyle="Solid"
                                        GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="table table-striped table-hover pos-table">
                                        <%-- <RowStyle CssClass="dataRow" />
                                                                <SelectedRowStyle CssClass="SelectdataRow" />
                                                                <AlternatingRowStyle CssClass="altRow" />
                                                                <EmptyDataRowStyle CssClass="HeadataRow" Font-Bold="true" />
                                                                <HeaderStyle CssClass="HeadataRow" Wrap="false" />
                                                                <FooterStyle CssClass="dataRow" />--%>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebtorID" runat="server" Text='<%# Eval("roleid")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Area" HeaderText="Area" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screen" HeaderText="Section" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:BoundField DataField="Screenid" HeaderText="Screen" ReadOnly="true" ApplyFormatInEditMode="false"
                                                HeaderStyle-BorderColor="Gray" HeaderStyle-Wrap="false" />
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Screen Visible"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxAdd" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChangedadd7"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Visible") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Read"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRead" runat="server" Style="color: Black" Text="" Font-Names="arial"
                                                        AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged7" Font-Size="11px"
                                                        Checked='<%# Bind("Read") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Edit"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEdit" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged7"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Edit") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Delete"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDelete" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged7"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Delete") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-CssClass="command" HeaderStyle-Width="60px" HeaderText="Save"
                                                HeaderStyle-BorderColor="Gray">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSave" AutoPostBack="true" OnCheckedChanged="chkRead_OnCheckedChanged7"
                                                        runat="server" Style="color: Black" Text="" Font-Names="arial" Font-Size="11px"
                                                        Checked='<%# Bind("Save") %>'></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
                        <script type="text/javascript">
                                    $(document).ready(function () {
                                        var $tabs = $('#horizontalTab');
                                        $tabs.responsiveTabs({
                                            rotate: false,
                                            startCollapsed: 'accordion',
                                            collapsible: 'accordion',
                                            setHash: true,

                                            activate: function (e, tab) {
                                                $('.info').html('Tab <strong>' + tab.id + '</strong> activated!');
                                            },
                                            activateState: function (e, state) {
                                                //console.log(state);
                                                $('.info').html('Switched from <strong>' + state.oldState + '</strong> state to <strong>' + state.newState + '</strong> state!');
                                            }
                                        });

                                        /* $('#start-rotation').on('click', function () {
                                        $tabs.responsiveTabs('startRotation', 1000);
                                        });
                                        $('#stop-rotation').on('click', function () {
                                        $tabs.responsiveTabs('stopRotation');
                                        });
                                        $('#start-rotation').on('click', function () {
                                        $tabs.responsiveTabs('active');
                                        });
                                        $('#enable-tab').on('click', function () {
                                        $tabs.responsiveTabs('enable', 3);
                                        });
                                        $('#disable-tab').on('click', function () {
                                        $tabs.responsiveTabs('disable', 3);
                                        });
                                        $('.select-tab').on('click', function () {
                                        $tabs.responsiveTabs('activate', $(this).val()); */

                                    });
            
        
                        </script>
                    </div>
                </div>
                <div id="Div1" runat="server" class="col-md-12">
                    <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label><br>
                    <asp:Button ID="btnadd" runat="server" class="btn btn-primary pos-btn1" Text="Save" ValidationGroup="val1"
                        OnClick="Add_Click" />
                    <asp:Button ID="btnexit" runat="server" class="btn btn-link" Text="Exit"
                        PostBackUrl="~/Accountsbootstrap/UserRoleGrid.aspx" />
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-lg-12" style="display: none">
                            <div class="col-lg-2">
                                <div id="Div2" runat="server">
                                    <div class="form-group ">
                                        <label>
                                            Store Name</label>
                                        <asp:TextBox CssClass="form-control" ID="txtStoreName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div id="Div5" runat="server">
                                    <div class="form-group ">
                                        <label>
                                            Store Contect No</label>
                                        <asp:TextBox CssClass="form-control" ID="txtStoreNo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div id="Div3" runat="server">
                                    <div class="form-group ">
                                        <label>
                                            TIN No</label>
                                        <asp:TextBox CssClass="form-control" ID="txtTIN" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div id="Div4" runat="server">
                                    <div class="form-group ">
                                        <label>
                                            Place</label>
                                        <asp:TextBox CssClass="form-control" ID="txtPlace" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div id="Div6" runat="server">
                                    <div class="form-group ">
                                        <label>
                                            Address</label>
                                        <asp:TextBox CssClass="form-control" ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.col-md-12 -->
            </div>
        </div>
    </form>
    <!-- /.row -->
    <!-- /#page-wrapper -->
    <!-- jQuery -->
</body>
</html>
