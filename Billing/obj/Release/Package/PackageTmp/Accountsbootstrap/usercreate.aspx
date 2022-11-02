<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usercreate.aspx.cs" Inherits="Billing.Accountsbootstrap.usercreate" %>

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
    <script type="text/javascript" language="javascript">
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
    </script>
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
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header" style="text-align: center; color: #fe0002;">
                User Master</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <form id="Form1" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <div class="col-lg-12">
                            <div class="col-lg-3">
                                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                    ID="val1" ShowMessageBox="true" ShowSummary="false" />
                                <div class="form-group" id="divcode" runat="server">
                                    <asp:TextBox CssClass="form-control" ID="txtUserid" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group " style="padding-left: 110px">
                                    <label>
                                        User Name</label>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" Text="*" ID="RequiredFieldValidator1"
                                        ControlToValidate="txtusername" ErrorMessage="Please enter User name!" Style="color: Red" />
                                    <asp:TextBox CssClass="form-control" ID="txtusername" Width="240px" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group " style="padding-left: 110px">
                                    <label>
                                        Mobile No.</label>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" Text="*" ID="RequiredFieldValidator3"
                                        ControlToValidate="txtmobile" ErrorMessage="Please enter Mobile No.!" Style="color: Red" />
                                    <asp:TextBox CssClass="form-control" ID="txtmobile" Width="240px" runat="server"
                                        MaxLength="10"></asp:TextBox>
                                </div>
                                <div class="form-group " style="padding-left: 110px" runat="server" visible="false">
                                    <label>
                                        IsAdmin</label>
                                    <asp:CheckBox ID="chkadminrights" runat="server" Width="240px" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group " style="padding-left: 110px">
                                    <label>
                                        Password</label>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" Text="*" ID="reqName"
                                        ControlToValidate="txtpassword" ErrorMessage="Please enter Password!" Style="color: Red" />
                                    <asp:TextBox CssClass="form-control" ID="txtpassword" TextMode="Password" Width="240px"
                                        runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group " style="padding-left: 110px">
                                    <label>
                                        Confirm Password</label>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" Text="*" ID="RequiredFieldValidator2"
                                        ControlToValidate="txtconfirmpasswprd" ErrorMessage="Please enter Confirm passowrd!"
                                        Style="color: Red" />
                                    <asp:TextBox CssClass="form-control" ID="txtconfirmpasswprd" TextMode="Password"
                                        Width="240px" runat="server"></asp:TextBox>
                                </div>
                                <div runat="server" visible="false">
                                    <div class="form-group " style="padding-left: 120px">
                                        <label>
                                            Email</label>
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" Width="240px" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group " style="padding-left: 120px">
                                        <label>
                                            Select Employee</label>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="val1"
                                            Text="*" Style="color: Red" InitialValue="0" ControlToValidate="ddlemployee"
                                            ValueToCompare="Select Employee" Operator="NotEqual" Type="String" ErrorMessage="Please Select Employee"></asp:CompareValidator>
                                        <asp:DropDownList CssClass="form-control" ID="ddlemployee" Width="240px" runat="server">
                                        </asp:DropDownList>
                                        <div runat="server" visible="false" class="checkbox">
                                            All Branch:<asp:CheckBox Style="margin-left: 20px;" ID="chkRememberMe" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3" style="">
                                <div class="form-group " style="padding-left: 120px">
                                    <label>
                                        Select Branch</label>
                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="chkAllbranch" Text="" runat="server" />
                                    </asp:CheckBox>
                                    <label>
                                        All Branch Access</label>
                                </div>
                                <div class="form-group " style="padding-left: 120px">
                                    <label>
                                        Select LoginType</label>
                                    <asp:DropDownList ID="drplogintype" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group " style="padding-left: 120px">
                                    <label>
                                        Report Processing Days</label>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterType="Numbers" ValidChars="" TargetControlID="txtreportdays" />
                                    <asp:TextBox CssClass="form-control" ID="txtreportdays" MaxLength="4" 
                                        runat="server">7</asp:TextBox>
                                </div>
                                <div class="form-group " style="padding-left: 120px">
                                    <label>
                                        Select Login Bill</label>
                                    <asp:DropDownList ID="drpbilltype" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="System" Value="S" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Android App." Value="A"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" style="padding-left: 120px">
                                    <label>
                                        Access Rights Type
                                    </label>
                                    <asp:DropDownList ID="drpRighttype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpRighttype_OnSelectedIndexChanged" CssClass="form-control">
                                      
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12" style="display:none">
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
                        <div class="col-lg-12">
                            <div id="horizontalTab" style="background-color: #D0D3D6; padding-left: 30px">
                                <ul>
                                    <li><a href="#tab-1">MasterMenu</a></li>
                                    <li><a href="#tab-2">OrderFormMenu</a></li>
                                    <li><a href="#tab-3">InventoryMenu</a></li>
                                    <li><a href="#tab-4">RequestAccept</a></li>
                                    <li><a href="#tab-5">Reports</a></li>
                                    <li><a href="#tab-6">Reports Detailed View</a></li>
                                </ul>
                                <div class="row" id="tab-1" style="background-color: #D0D3D6; padding-top: 50px">
                                    <div style="background-color: #D0D3D6;">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdmaster" AutoGenerateColumns="False" BorderWidth="1px" BorderStyle="Solid"
                                                                GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="mGrid" Width="900px">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="tab-2" style="background-color: #D0D3D6; padding-top: 50px">
                                    <div style="background-color: #D0D3D6;">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="OrderFormMenu" AutoGenerateColumns="False" BorderWidth="1px" BorderStyle="Solid"
                                                                GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="mGrid" Width="900px">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="tab-3" style="background-color: #D0D3D6; padding-top: 50px">
                                    <div style="background-color: #D0D3D6;">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdinventory" AutoGenerateColumns="False" BorderWidth="1px" BorderStyle="Solid"
                                                                GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="mGrid" Width="900px">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="tab-4" style="background-color: #D0D3D6; padding-top: 50px">
                                    <div style="background-color: #D0D3D6;">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grRequestAccept" AutoGenerateColumns="False" BorderWidth="1px"
                                                                BorderStyle="Solid" GridLines="Both" SaveButtonID="SaveButton" runat="server"
                                                                CssClass="mGrid" Width="900px">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="tab-5" style="background-color: #D0D3D6; padding-top: 30px">
                                    <div style="background-color: #D0D3D6;">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdreport" AutoGenerateColumns="False" BorderWidth="1px" BorderStyle="Solid"
                                                                GridLines="Both" SaveButtonID="SaveButton" runat="server" CssClass="mGrid" Width="900px">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="row" id="tab-6" style="background-color: #D0D3D6; padding-top: 30px">
                                    <div style="background-color: #D0D3D6;">
                                        <table class="table table-bordered table-striped">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grddetailedreport" AutoGenerateColumns="False" BorderWidth="1px"
                                                                BorderStyle="Solid" GridLines="Both" SaveButtonID="SaveButton" runat="server"
                                                                CssClass="mGrid" Width="900px">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
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
                        <div id="Div1" runat="server" align="center" class="col-lg-12">
                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                            <asp:Button ID="btnadd" runat="server" class="btn btn-info" Text="Save" ValidationGroup="val1"
                                OnClick="Add_Click" Style="width: 117px; margin-left: 65PX" />
                            <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" Style="width: 120px;"
                                PostBackUrl="~/Accountsbootstrap/UserGrid.aspx" />
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        </form>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <!-- /#page-wrapper -->
    <!-- jQuery -->
</body>
</html>
