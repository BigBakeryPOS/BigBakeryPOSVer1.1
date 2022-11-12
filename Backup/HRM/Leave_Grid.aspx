<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leave_Grid.aspx.cs" Inherits="HRM.Leave_Grid" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>Leave Grid - bootsrap</title>
    <style type="text/css">
        .button-success, .button-error, .button-warning, .button-secondary
        {
            color: white;
            border-radius: 5px;
            text-shadow: 0 7px 5px rgba(0, 0, 0, 0.2);
        }
        .button-success1
        {
            background: rgb(28, 184, 65);
        }
        
        .button-error
        {
            background: rgb(202, 60, 60);
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
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../Accountsbootstrap/css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div>
        <form id="Form2" runat="server">
        <menu:menu ID="menu" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="row" style="margin-top: 10px;">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-default">
                       <h2  style="text-align:center;color:#6600ff;font-weight:bold" > Leave Report</h2> 
                       
                    </div>
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:GridView ID="GvLeave" runat="server" Style="margin-left: 140px;" AllowPaging="True"
                                        PageSize="5" AutoGenerateColumns="False" CssClass="mGrid" OnRowCommand="GvLeave_RowCommand"
                                        OnPageIndexChanging="GvLeave_PageIndexChanging" OnSelectedIndexChanged="GvLeave_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField HeaderText="Emp code" DataField="Emp_code" />
                                            <asp:BoundField HeaderText="Emp name" DataField="Emp_Name" />
                                            <asp:BoundField HeaderText="From Date" DataField="FromDate" />
                                            <asp:BoundField HeaderText="To Date" DataField="Todate" />
                                            <asp:BoundField HeaderText="Reason" DataField="Leave_Reason" />
                                            <asp:BoundField HeaderText="Status" DataField="Leave_Status" />
                                            <asp:BoundField HeaderText="Applied Date" DataField="Date" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("Emp_code") %>' CommandName="Status"
                                                        Text="Status" runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </form>
    </div>
</body>
</html>
