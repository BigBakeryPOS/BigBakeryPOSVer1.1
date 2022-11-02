<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AUTOCOMPLETE.aspx.cs" Inherits="Billing.Accountsbootstrap.AUTOCOMPLETE" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background:#C9C9C9">
    <form id="form1" runat="server">   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager> 
    <div align="center" style="font-family:Calibri"><h2><b>AJAX AutoComplete</b></h2> </div>
    <br />
    <div align="center">    
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCity"
         MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="1000" 
         ServiceMethod="GetCity" >
    </asp:AutoCompleteExtender>
    </div> 
    <div align="center" style="font-family:Calibri"> <b>Demo by dotnetfox</b></div>
    </form>
</body>
</html>
