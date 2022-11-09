<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Billing.Production.Home" %>

<%@ Register Src="~/Production/Header.ascx" TagName="Menu" TagPrefix="Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
<meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title></title>
    <link href="Styles/style2.css" rel="stylesheet" type="text/css" />
    <style>
        #dateBig {
    background: #fff;
    padding: 20px;
    text-align: center;
    display: inline-block;
    border: 1px solid #eae7da;
    width: 160px;
}
    </style>
</head>
<body style="background-color:#f7f3e6">
<Menu:Menu ID="Menu" runat="server" /> 

    <form id="form1" runat="server">
    <div >
    <div id="dateBig" style="margin-top:80px"></div>
 
    </div>
    </form>
</body>
</html>
