<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emp_gird.aspx.cs" Inherits="HRM.Emp_gird" %>


<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>Emp_gird - bootsrap</title>
    <style type="text/css">
        .button-success, .button-error, .button-warning, .button-secondary
        {
            color: white;
            border-radius: 5px;
            text-shadow: 0 7px 5px rgba(0, 0, 0, 0.2);
        }
        
        .button-success1
        {
            background: rgb(28, 184, 65); /* this is a green */
        }
        
        .button-error
        {
            background: rgb(202, 60, 60); /* this is a maroon */
        }
        
        .button-warning
        {
            background: rgb(223, 117, 20); /* this is an orange */
        }
        
        .button-secondary
        {
            background: rgb(66, 184, 221); /* this is a light blue */
        }
        
        .index1
        {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            background-color: orange;
            padding-top: 10px;
            padding-bottom: 10px;
            margin-left: 525px;
            margin-right: 525px;
            font-family: Californian FB;
        }
        .buttonhrm
        {
            margin-top: 25px;
        }
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
            $find('modalpopup').show();
            //$get('Button1').click();
        }

        function HidePopup() {
            $find('modalpopup').hide();
            //$get('btnCancel').click();
        }
    </script>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <script type="text/javascript" src="../js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form2" runat="server">
    
   <menu:menu ID="menu1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-body">
               <%--     <h2>
                    <legnd style="text-align:center;color:#6600ff;font-weight:bold">Employee Details</legnd></h2>--%>
                     <h2  style="text-align:center;color:#6600ff;font-weight:bold" >Employee Details</h2> 
                        <div class="row" style="margin-top:50px">
                            <div class="col-lg-2">
                                <asp:DropDownList CssClass="form-control form-inline" ID="ddlfilter" runat="server">
                                    <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Employee Id" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Name" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label><br />
                               
                            </div>
                              <div class="col-lg-2">
                            <div>
                                <asp:TextBox CssClass="form-control form-inline" ID="txtsearch" runat="server"></asp:TextBox>
                            </div>
                            </div>
                            <div class="col-lg-5">
                             <asp:Button ID="btnsearch" Width="100px" runat="server" CssClass="btn btn-info" Text="Search"
                         OnClick="btnsearch_Click" />
                        <asp:Button ID="btnresret" runat="server" Width="100px" CssClass="btn btn-danger" Text="Reset"
                     OnClick="btnresret_Click1" />
                        <asp:Button ID="btnadd" runat="server" Width="100px" CssClass="btn btn-success" Text="Add" 
                            OnClick="btnadd_Click" />
                            </div>
                            
                        </div>
                    </div>
                    <div class="form-group">
                       <%-- <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-success" Text="Search"
                            Style="margin-top: 10px;" OnClick="btnsearch_Click" />
                        <asp:Button ID="btnresret" runat="server" CssClass="btn btn-warning" Text="Reset"
                            Style="margin-top: 10px;" OnClick="btnresret_Click1" />
                        <asp:Button ID="btnadd" runat="server" CssClass="btn btn-success" Text="Add" Style="margin-top: 10px;"
                            OnClick="btnadd_Click" />--%>
                    </div>
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped">
                            <tr>
                                <td align="left">
                                    <asp:GridView ID="gridviewhrm" runat="server" Style="margin-left: 140px;" AllowPaging="true"
                                        PageSize="8" AutoGenerateColumns="false" CssClass="myGridStyle" OnPageIndexChanging="gridviewhrm_PageIndexChanging"
                                        OnRowCommand="gridviewhrm_RowCommand" OnRowDataBound="gridviewhrm_RowDataBound">
                                        <HeaderStyle BackColor="#3366FF" />
                                        <PagerSettings Mode="Numeric" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Employee Codes" DataField="Employee_Id" />
                                            <asp:BoundField HeaderText="Name" DataField="name" />
                                           
                                            <asp:BoundField HeaderText="Address" DataField="address" />
                                            <asp:BoundField HeaderText="Email_Id" DataField="Email_Id" />
                                            <asp:BoundField HeaderText="Pssword" DataField="Pssword" />
                                            <asp:BoundField HeaderText="Phno_No" DataField="Phno_No" />
                                            <asp:BoundField HeaderText="Jobtype" DataField="JobType1" />
                                            <asp:BoundField HeaderText="Contractperiod" DataField="ContractPeriod" />
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("Employee_Id") %>' CommandName="edit"
                                                        runat="server">
                                                        <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" width="55px" runat="server" /></asp:LinkButton>
                                                    <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("Employee_Id") %>' CommandName="Del"
                                                        runat="server">
                                                        <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
                                                    <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                        CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndel"
                                                        PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                    </ajaxToolkit:ModalPopupExtender>
                                                    <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                        TargetControlID="btndel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                    <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel CssClass="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
                        runat="server">
                        <div class="popup_Container">
                            <div class="popup_Titlebar" id="PopupHeader">
                                <div class="TitlebarLeft">
                                    Category List</div>
                                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                </div>
                            </div>
                            <div class="popup_Body">
                                <p>
                                    Are you sure want to delete?
                                </p>
                            </div>
                            <div class="popup_Buttons">
                                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                                <input id="ButtonDeleteCancel" type="button" value="No" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    </form>
    <asp:Label ID="lblempid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblempname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbllogintime" runat="server"></asp:Label>
    <asp:Label ID="lbllogtime" runat="server"></asp:Label>
    <asp:Label ID="id" runat="server"></asp:Label>
</body>
</html>
