<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseBackUp.aspx.cs" Inherits="Billing.Accountsbootstrap.DatabaseBackUp" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Database Backup</h1>
	    </div>
                    <div class="panel-body">
                    
                            <table cellpadding="10" cellspacing="10" style="border: solid 10px red; background-color: Skyblue;"
                                width="100%" align="center" runat="server" visible="false" id="tblmessage">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                      
                        <br />
                            <asp:Button ID="btnBackup" runat="server" Text="Get DataBase Backup"  OnClick="btnBackup_Click" cssClass="btn btn-primary pos-btn1" />
                            &nbsp; &nbsp; &nbsp; <asp:Button cssClass="btn btn-secondary" ID="btnCancel" runat="server" Text="Refresh"
                                 OnClick="btnCancel_Click" />
                        
                    </div>
               </div>
               </div>
               </div>
               </div>
    </form>
</body>
</html>
