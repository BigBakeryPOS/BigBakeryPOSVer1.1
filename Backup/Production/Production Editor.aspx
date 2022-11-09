<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Production Editor.aspx.cs" Inherits="Billing.Production.Production_Editor" %>
<%--<%@ Register Src="~/Header.ascx" TagName="menu" TagPrefix="menu" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        a:hover { 
    background-color: Black;
}
    </style>
</head>
<body style="background-color:#f7f3e6">
<%--<menu1:menu1 ID="menu" runat="server" />--%>
 
<form id="form" runat="server">
  
  
    
    <div class="row" style="margin-top:200px;margin-left:50px" >
    <legend>Production Editor</legend>
 <div> 

 
   <div class="panel panel-body  " style="background-color:White;">
                           <label>Ingredients</label><br />
                         <asp:LinkButton ID="lnkenter1" Text="Enter Section" runat="server"></asp:LinkButton>
                        </div>
                         <div class="panel panel-body" style="background-color:White">
                           <label>Recipe Book</label><br />
                         <asp:LinkButton ID="LinkButton1" Text="Enter Section" runat="server"></asp:LinkButton>
                        </div>
                         <div class="panel panel-body" style="background-color:White">
                           <label>Products</label><br />
                         <asp:LinkButton ID="LinkButton2" Text="Enter Section" runat="server"></asp:LinkButton>
                        </div>
                        <div class="panel panel-body" style="background-color:White">
                           <label>Clients and Shops</label><br />
                         <asp:LinkButton ID="LinkButton3" Text="Enter Section" runat="server"></asp:LinkButton>
                        </div>

   
    
   </div>
    </div>
   </form>
</body>
</html>
