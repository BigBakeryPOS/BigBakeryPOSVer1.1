<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddIP.aspx.cs" Inherits="Billing.Accountsbootstrap.AddIP" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>add</title>
</head>
<body>
<usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">

    <div align="center"  >
    <table>
    <tr>
    <td>
    <asp:GridView ID="gvip" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="RosyBrown" HeaderStyle-ForeColor="White" HeaderStyle-Height="30px" >
    <Columns>
     <asp:BoundField  DataField="Id" HeaderText ="ID" ItemStyle-Font-Size="Medium" ItemStyle-BackColor="AliceBlue" Visible="false" />
    <asp:BoundField  DataField="Ip" HeaderText ="IP Address" ItemStyle-Font-Size="Medium"  ItemStyle-BackColor="AliceBlue"/>
     <asp:BoundField  DataField="Location" HeaderText ="Location" ItemStyle-Font-Size="Medium" ItemStyle-BackColor="AliceBlue" Visible="false" />
     
     
    </Columns>
    </asp:GridView>
    </td>
    </tr>
    <tr  style="background-color:Yellow">
    <td>
    Ip Address
    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
    </td>
    
    <td>
    <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" />
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
