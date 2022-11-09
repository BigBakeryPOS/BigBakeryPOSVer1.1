<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lowdurations.aspx.cs" Inherits="HRM.Lowdurations" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <script language="javascript" type="text/javascript">
        function validate() {
            var From_date = document.getElementById("txtfromdate").value;
            var To_date = document.getElementById("txttodate").value;
            var Employee_id = document.getElementById("txtempid").value;

            if (From_date == "") {
                alert("Enter FromDate");

                return false;
            }
            if (To_date == "") {
                alert("Enter Todate");

                return false;
            }

          

        }  
    </script>
    <link href="../Accountsbootstrap/css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../Accountsbootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Accountsbootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <menu:menu ID="menu" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
           
            <h2  style="text-align:center;color:#6600ff;font-weight:bold" >Attendance Report</h2> 
            <div style="padding-top: 36px">
                <div class="row col-lg-12">
                    <div class="form-group col-lg-2">
                        <asp:TextBox ID="txtfromdate" Placeholder="From Date" CssClass="form-control" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                            runat="server" Format="yyyy-MM-dd" CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="form-group col-lg-2">
                        <asp:TextBox ID="txttodate" Placeholder="To Date" CssClass="form-control" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                            runat="server" Format="yyyy-MM-dd" CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="form-group col-lg-2" style="display:none">
                        <asp:Label ID="lblempid" runat="server"></asp:Label>
                        <asp:TextBox ID="txtempid" Placeholder="EmployeeID" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-2"  style="display:none">
                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                         
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2" style="margin-left:0px">
                        <asp:Button ID="btngo" Text="Search" CssClass="btn btn-group btn-success" Width="80px" runat="server"
                            OnClientClick="return validate()" OnClick="btngo_Click" />
                        <asp:Button ID="Btnreset" Text="Reset" Width="80px" CssClass="btn btn-danger" runat="server"
                            OnClick="Btnreset_Click" />
                    </div>
                    <div class="col-lg-2" style="margin-left:-33px">
                        <asp:Label ID="lblleavedays" runat="server"></asp:Label>
                        <asp:TextBox ID="txtleavedays" Placeholder="LeaveDays" Width="137px" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:GridView ID="lesshoursgrid" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        PageSize="200" CssClass="mGrid" OnPageIndexChanging="lesshoursgrid_PageIndexChanging">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Employee_Id" HeaderText="EmployeeId" />
                            <asp:BoundField DataField="Employee_Name" HeaderText="Employename" />
                            <asp:BoundField DataField="LogIn_DateTime" HeaderText="LoginTime" />
                            <asp:BoundField DataField="Logout_DateTime" HeaderText="LogoutTime" />
                            <asp:BoundField DataField="Time_Duration" HeaderText="TimeDurations" />
                            <asp:BoundField DataField="Emp_code" HeaderText="Empcode" />
                            <asp:BoundField DataField="overtimeHours" HeaderText="Overtime" />
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </div>
            </div>
        
    </form>
</body>
</html>
