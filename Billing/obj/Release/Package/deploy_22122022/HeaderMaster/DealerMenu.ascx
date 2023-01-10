<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DealerMenu.ascx.cs" Inherits="Billing.HeaderMaster.DealerMenu" %>
<html lang="en">

<head id="Head1" >
<%--    <meta charset='utf-8'>
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="../js/jquery-latest.min.js" type="text/javascript"></script>
   <!--<script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>-->
    <link href="../css/test.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/test.js" type="text/javascript"></script>
     
    <link href="../css/New.css" rel="stylesheet" type="text/css" />
 <link rel="Stylesheet" type="text/css" href="../css/date.css" />--%>
  <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="../Menu/Styles/styles.css">
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../Menu/Scripts/script.js"></script>
      <link href="../Menu/css/bootstrap.css" rel="stylesheet" type="text/css" />
         <link href="../Menu/css/sb-admin-2.css" rel="stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../Menu/css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
     <link href="../Menu/css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../Menu/font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <title>BigbBiz Solutions</title>
</head> 

            
<body >



 
  
       
        <div id='cssmenu'>
          <ul>
         
          <li id="master" class='has-sub' runat="server"  style="color:White" >
            <a   style="color:White" href="../Accountsbootstrap/DealetsalesGrid.aspx" >     
                        
               Invoice <b></b>
            </a>
            
         </li>

         <li id="Li1" class='has-sub' runat="server"  style="color:White" >
            <a   style="color:White" href="../Accountsbootstrap/DealerSalesReport.aspx" >     
                        
               Report <b></b>
            </a>
            
         </li>
          <
            
			<li><a href="../Accountsbootstrap/login.aspx" style="color:White">Sign  Out</a></li>
         
                    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="true"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false  "> </asp:Label>
                
                    <asp:Label ID="lblscreenname" style="font-size:larger;color:White" runat="server" CssClass="label"></asp:Label>
                   <a href="../Accountsbootstrap/Home_Page.aspx"> <asp:Image ID="Image2" Width="100px" height="50px"  ImageUrl="~/images/BlackForrest.png" runat="server" /></a>
                 <asp:Label runat="server" ID="lblstore" ForeColor="White"  style="font-size:large;text-decoration:blink;border-color:Gray" Visible="true"> </asp:Label>
          </ul>
         
        </div>
    
    
</body>


</html>