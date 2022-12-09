<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseCompanyDetails.aspx.cs" Inherits="Billing.Accountsbootstrap.PurchaseCompanyDetails" %>

<%--<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1" runat="server" />
<meta content="" charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta name="description" content="" />
<meta name="author" content="" />
<style type="text/css">
    blink, .blink {
        animation: blinker 4s linear infinite;
    }

    @keyframes blinker {
        50% {
            opacity: 0;
        }
    }
</style>
<link rel="Stylesheet" type="text/css" href="../css/date.css" />
<script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
<script src="../js/Extension.min.js" type="text/javascript"></script>
<link href="../css/CSS_date.css" rel="stylesheet" type="text/css" />
<!-- Bootstrap Core CSS -->
<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
<link href="../css/bootstrap.min.css" rel="stylesheet" />
<link href="../Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
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
<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="../Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="../Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
<script src="../js/toastrmin.js" type="text/javascript"></script>
<script src="../js/toastr.js" type="text/javascript"></script>
<link href="../css/toastr.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <%-- <usc:Header ID="Header" runat="server" />--%>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="panel-body">
            <!-- /.row -->
            <div class="panel panel-default">
                <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: left">
                    Sub Company Details
                </div>
                <div class="row">
                    <div class="panel-body">
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Sub Company Name</label>
                                    <asp:TextBox CssClass="form-control" ID="txtcustomername" MaxLength="50" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="reqName" ControlToValidate="txtcustomername"
                                        ErrorMessage="Please enter your name!" Style="color: Red" />
                                    <asp:TextBox CssClass="form-control" ID="txtcompanyID" MaxLength="50" runat="server"
                                        Visible="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Mobile No</label>
                                    <asp:TextBox CssClass="form-control" ID="txtmobileno" MaxLength="10" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="mobno" ControlToValidate="txtmobileno"
                                        ErrorMessage="Please enter your Mobile No!" Style="color: Red" /><br />
                                    <asp:RegularExpressionValidator runat="server" ID="rexNumber" ValidationGroup="val1"
                                        ControlToValidate="txtmobileno" ValidationExpression="^[0-9]{10}$" ErrorMessage="Please enter a 10 digit number!"
                                        Style="color: Red" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtmobileno" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Customer Care No</label>
                                    <asp:TextBox CssClass="form-control" ID="txtphoneno" MaxLength="15" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtphoneno"
                                        ErrorMessage="Please Enter Customer Care No!" Style="color: Red" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtphoneno" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        GSTIN No</label>
                                    <asp:TextBox CssClass="form-control" ID="txtGstNo" MaxLength="150" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                                        ControlToValidate="txtaddress" ErrorMessage="Please enter Gst No!" Style="color: Red" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        City</label>
                                    <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="30" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="city" ControlToValidate="txtcity"
                                        ErrorMessage="Please enter your City!" Style="color: Red" />
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" ValidationGroup="val1"
                                        ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6}$" ErrorMessage="Please enter a 6 digit pin code!"
                                        Style="color: Red" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        E-mail</label>
                                    <asp:TextBox CssClass="form-control" ID="txtemail" placeholder="For Ex: test@gmail.com"
                                        runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="email" ControlToValidate="txtemail"
                                        ErrorMessage="Please enter your Email!" Style="color: Red" />
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="val1"
                                        ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="Please enter a correct Email Id!" Style="color: Red" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Web Site</label>
                                    <asp:TextBox CssClass="form-control" ID="txtWebSite" MaxLength="150" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator4"
                                        ControlToValidate="txtaddress" ErrorMessage="Please enter your Address!" Style="color: Red" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Social Media</label>
                                    <asp:TextBox CssClass="form-control" ID="txtSocial" MaxLength="150" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator5"
                                        ControlToValidate="txtaddress" ErrorMessage="Please enter your Address!" Style="color: Red" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Area</label>
                                    <asp:TextBox CssClass="form-control" ID="txtarea" MaxLength="30" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="area" ControlToValidate="txtarea"
                                        ErrorMessage="Please enter your Area!" Style="color: Red" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Address</label>
                                    <asp:TextBox CssClass="form-control" ID="txtaddress" MaxLength="150" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="address" ControlToValidate="txtaddress"
                                        ErrorMessage="Please enter your Address!" Style="color: Red" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        Pincode</label>
                                    <asp:TextBox CssClass="form-control" ID="txtpincode" MaxLength="6" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="pincode" ControlToValidate="txtpincode"
                                        ErrorMessage="Please enter your Pin Code!" Style="color: Red" />
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ValidationGroup="val1"
                                        ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6}$" ErrorMessage="Please enter a 6 digit pin code!"
                                        Style="color: Red" />
                                </div>
                            </div>

                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label>
                                        About Us</label>
                                    <asp:TextBox CssClass="form-control" ID="txtAboutUs" TextMode="MultiLine" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div runat="server" visible="false" class="col-lg-3">
                                <div class="panel panel-default" style="height: 350px;">
                                    <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: center">
                                        <i class="fa fa-cogs" aria-hidden="true"></i>Admin Login Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>
                                                    UserName</label>
                                                <asp:TextBox CssClass="form-control" ID="txtUsername" Width="250px" AutoCompleteType="Disabled"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label>
                                                    Password</label>
                                                <asp:TextBox CssClass="form-control" ID="txtPasswprd" Width="250px" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label>
                                                    EmpCode</label>
                                                <asp:TextBox CssClass="form-control" ID="txtEmpCode" Width="250px" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div runat="server" visible="false" class="col-lg-3">
                                <div class="panel panel-default" style="height: 350px;">
                                    <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: center">
                                        <i class="fa fa-cogs" aria-hidden="true"></i>Admin Setting Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-lg-5">
                                            <div class="form-group">
                                                <label>
                                                    End Date</label>
                                                <asp:TextBox ID="txtToDate" CssClass="form-control" AutoCompleteType="Disabled" Width="250px"
                                                    Enabled="true" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtToDate"
                                                    Format="dd/MM/yyyy" PopupButtonID="txtToDate" EnabledOnClient="true" runat="server"
                                                    CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                            <div class="form-group">
                                                <label>
                                                    No.Of.Branch</label>
                                                <asp:TextBox ID="txtNoOfBranch" CssClass="form-control" Width="250px" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label>
                                                    Branch Type</label>
                                                <asp:DropDownList ID="drpbranchtype" runat="server" Width="250px" CssClass="form-control">
                                                    <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Billing" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Production" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group" style="width: 200px;">
                                                <label>
                                                    Software Type</label>
                                                <asp:CheckBoxList ID="chkType" runat="server" RepeatDirection="Horizontal" Width="350px">
                                                    <asp:ListItem Text="Digital Menu" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Ecommerce Site" Value="2"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="panel panel-default" style="height: 350px;">
                                    <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: center">
                                        <i class="fa fa-cogs" aria-hidden="true"></i>Image Upload
                                    </div>
                                    <div class="panel-body">
                                        <label>
                                            Company Logo
                                        </label>
                                        <div class="col-lg-4">
                                            <asp:Image ID="img_Photo" runat="server" class="img-fluid" Height="50px" Width="50px" />
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <label>
                                                        Image Upload</label>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <br />
                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary"
                                                        OnClick="btnUpload_Clickimg" Width="100px" />
                                                    <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div runat="server" visible="false" class="col-lg-3">
                                <div class="panel panel-default" style="height: 350px;">
                                    <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: center">
                                        <i class="fa fa-cogs" aria-hidden="true"></i>App Banner Image Upload
                                    </div>
                                    <div class="panel-body">

                                        <div class="col-lg-4">

                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>

                                                    <asp:FileUpload ID="FileUpload2" runat="server" Style="margin-top: 7px;" />
                                                    <asp:Image ID="img_Photo2" runat="server" class="img-fluid" Height="50px" Width="50px" Style="margin-left: 230px; margin-top: -40px;" />

                                                    <asp:Button ID="btnUpload2" runat="server" Text="Upload Banner 1" Style="margin-top: 5px;" CssClass="btn btn-primary"
                                                        OnClick="btnUpload2_Clickimg" Width="120px" />
                                                    <asp:Label ID="lblFile_Path2" runat="server" Visible="false"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUpload2" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>

                                                    <asp:FileUpload ID="FileUpload3" runat="server" Style="margin-top: 7px;" /><asp:Image ID="img_Photo3" runat="server" class="img-fluid" Height="50px" Width="50px" Style="margin-left: 230px; margin-top: -40px;" />

                                                    <asp:Button ID="btnUpload3" runat="server" Text="Upload Banner 2" Style="margin-top: 5px;" CssClass="btn btn-primary"
                                                        OnClick="btnUpload3_Clickimg" Width="120px" />
                                                    <asp:Label ID="lblFile_Path3" runat="server" Visible="false"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUpload3" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>

                                                    <asp:FileUpload ID="FileUpload4" runat="server" Style="margin-top: 7px;" />
                                                    <asp:Image ID="img_Photo4" runat="server" class="img-fluid" Height="50px" Width="50px" Style="margin-left: 230px; margin-top: -40px;" />

                                                    <asp:Button ID="btnUpload4" runat="server" Text="Upload Banner 3" Style="margin-top: 5px;" CssClass="btn btn-primary"
                                                        OnClick="btnUpload4_Clickimg" Width="120px" />
                                                    <asp:Label ID="lblFile_Path4" runat="server" Visible="false"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUpload4" />
                                                </Triggers>
                                            </asp:UpdatePanel>


                                        </div>

                                    </div>
                                    <br />



                                </div>
                            </div>
                            <div style="float: right; margin-top: 20px;">
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" OnClick="Add_Click"
                                    ValidationGroup="val1" />&nbsp
                                    <asp:Button ID="Button1" runat="server" class="btn btn-danger" Text="Exit" PostBackUrl="~/Accountsbootstrap/CompanyDetailGrid.aspx" />
                            </div>
                            <div class="col-lg-12" style="display: none">
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
                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
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
                                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
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
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row (nested) -->
        </div>
        <!-- /.panel-body -->
        <!-- /.panel -->
    </form>
    <!-- /.col-lg-6 (nested) -->
    <!-- /.col-lg-6 (nested) -->
    <!-- /.row -->
    <!-- /#page-wrapper -->
    <!-- jQuery -->
</body>
</html>
