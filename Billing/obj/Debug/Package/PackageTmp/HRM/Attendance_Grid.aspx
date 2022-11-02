<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance_Grid.aspx.cs"
    Inherits="HRM.Attendance_Grid" %>
    <%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
        .h2
        {
            padding-left: 50px;
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
    <link rel="stylesheet" href="../js/bootstrap.min.js" />
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
   
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <menu:menu ID="menu" runat="server" />
    <form id="Form2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body" style="margin-top: 55px;">
                    <div class="row">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <tr>
                                    <td rowspan="2" colspan="4" align="center">
                                        <h2>
                                            Today's Attendance</h2>
                                        <asp:Label ID="lblinfo1" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gridviewhrm" runat="server" Style="margin-left: 30px;" AllowPaging="true"
                                            PageSize="5" AutoGenerateColumns="false" CssClass="myGridStyle" OnRowDataBound="gridviewhrm_RowDataBound"
                                            OnPageIndexChanging="gridviewhrm_PageIndexChanging1">
                                            <HeaderStyle BackColor="#3366FF" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Employee Name" DataField="Employee_Name" />
                                                <asp:BoundField HeaderText="Login Time" DataField="LogIn_DateTime" />
                                                <asp:BoundField HeaderText="Logout time" DataField="LogOut_DateTime" />
                                                <asp:BoundField HeaderText="Total Hours" DataField="Time_Duration" />
                                            </Columns>
                                        </asp:GridView>
                                        <!-- LEAVE GRID-->
                                        <h2 class="h2">
                                            Leave Details</h2>
                                        <asp:Label ID="lblLeave" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                        <asp:GridView ID="GvLeave" runat="server" Style="margin-left: 30px;" AllowPaging="true"
                                            PageSize="5" AutoGenerateColumns="false" CssClass="myGridStyle" OnPageIndexChanging="GvLeave_PageIndexChanging">
                                            <HeaderStyle BackColor="#3366FF" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Employee Name" DataField="Emp_Name" />
                                                <asp:BoundField HeaderText="Applied Date" DataField="Date" />
                                                <asp:BoundField HeaderText="From Date" DataField="FromDate" />
                                                <asp:BoundField HeaderText="To Date" DataField="ToDate" />
                                                <asp:BoundField HeaderText="Reason" DataField="Leave_Reason" />
                                                <asp:BoundField HeaderText="Status" DataField="Leave_Status" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    <td align="center">
                                        <h2>
                                            Late Arrival</h2>
                                        <asp:Label ID="lblinfo2" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gvlogin" runat="server" Style="margin-left: 30px;" AllowPaging="true"
                                            PageSize="5" CssClass="myGridStyle" AutoGenerateColumns="false" OnPageIndexChanging="gvlogin_PageIndexChanging">
                                            <HeaderStyle BackColor="#3366FF" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Employee Name" DataField="Employee_Name" />
                                                <asp:BoundField HeaderText="Login Time" DataField="LogIn_DateTime" />
                                                <asp:BoundField HeaderText="Total Hours" DataField="Time_Duration" />
                                            </Columns>
                                        </asp:GridView>
                                        <h2>
                                            Leaved soon</h2>
                                        <asp:Label ID="lblinfo3" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gvlogout" runat="server" Style="margin-left: 30px;" AllowPaging="true"
                                            PageSize="5" CssClass="myGridStyle" AutoGenerateColumns="false" OnPageIndexChanging="gvlogout_PageIndexChanging">
                                            <HeaderStyle BackColor="#3366FF" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Employee Name" DataField="Employee_Name" />
                                                <asp:BoundField HeaderText="Logout Time" DataField="Logout_DateTime" />
                                                <asp:BoundField HeaderText="Total Hours" DataField="Time_Duration" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label ID="lblmsg" Text="Message from Admin" runat="server"></asp:Label>
                <%--<marquee direction="top"></marquee>--%>
                <asp:TextBox ID="txtmsg" Height="100px" CssClass="form-control" TextMode="MultiLine"
                    runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lbbirthday" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <%--<marquee direction="top"></marquee>--%>
            </div>
        </div>
    </div>
    </form>
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
    <asp:Label ID="lblempid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblempname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbllogintime" runat="server"></asp:Label>
    <asp:Label ID="lbllogtime" runat="server"></asp:Label>
    <asp:Label ID="id" runat="server"></asp:Label>
</body>
</html>
