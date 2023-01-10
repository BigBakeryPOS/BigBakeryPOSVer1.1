<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Billing.Accountsbootstrap.FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1"  >
    <tr align="center">
    <td >
    <label>Upload</label>
    </td>
    <td>
    <asp:FileUpload ID="fileupload" runat="server" />
    </td>
    </tr>
    <tr>
   <td>
   <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" />
   </td>
    </tr>
    <tr>
    <td>
    <asp:TextBox ID="txtpath" runat="server"></asp:TextBox>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
