<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monthwise_Leave.aspx.cs"
    Inherits="HRM.Monthwise_Leave" %>

<%@ Register Src="~/HeaderMaster/HRMheader.ascx" TagName="menu" TagPrefix="menu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function validate() {
            var From_date = document.getElementById("txtfromdate").value;
            var To_date = document.getElementById("txttodate").value;
            var Employee_id = document.getElementById("txtempid").value;

            if (From_date == "") 
            {
                alert("Enter FromDate");

                return false;
            }
            if (To_date == "") 
            {
                alert("Enter Todate");

                return false;
            }

            if (Employee_id == "") 
            {
                alert("Enter EmployeeID ");
                return false;
            }

        }  
    </script>
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <menu:menu ID="menu" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="Panel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          
            <div style="padding-top: 1px">
               <h2  style="text-align:center;color:#6600ff;font-weight:bold" >Monthwise Leave</h2> 
                <div class="row col-lg-12" style="margin-top:20px">
                    <div class="form-group col-lg-2">
                        <asp:DropDownList CssClass="form-control" ID="ddlMonth" runat="server" AutoPostBack="true">
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-lg-2">
                        <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                            <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                            <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                            <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                            <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                            <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                            <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                            <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                            <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                            <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                            <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                            <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                    <div class="form-group">
                        <asp:Button ID="btngo" Text="Search" Width="100px" CssClass="btn btn-group btn-success" runat="server"
                            OnClientClick="return validate()" OnClick="btngo_Click" />
                        <asp:Button ID="Btnreset" Text="Reset" Width="100px" CssClass="btn btn-danger" runat="server" />
                    </div>
                    </div>
                    <div class="col-lg-2" style="margin-left:-100px">
                        <asp:TextBox ID="txtleavedays" Placeholder="No.of Leaves" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                    <asp:GridView ID="gv_leave" runat="server" CssClass="myGridStyle" AllowPaging="true"
                        PageSize="7" OnPageIndexChanging="gv_leave_PageIndexChanging">
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
