<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseBackUp.aspx.cs" Inherits="Billing.Accountsbootstrap.DatabaseBackUp" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Database Backup
                        </h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <table cellpadding="10" cellspacing="10" style="border: solid 10px red; background-color: Skyblue;"
                                width="100%" align="center" runat="server" visible="false" id="tblmessage">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="row">
                            <asp:Button ID="btnBackup" runat="server" Text="Get DataBase Backup" Style="width: 200px;
                                margin-left: 6px;" OnClick="btnBackup_Click" class="btn btn-primary" />
                            <asp:Button class="btn btn-success" ID="btnCancel" runat="server" Text="Refresh"
                                Style="width: 100px; margin-left: 6px;" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
