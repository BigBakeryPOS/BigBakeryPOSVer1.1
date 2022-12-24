<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Support.aspx.cs" Inherits="Billing.Accountsbootstrap.Support" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
   

     <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Technical Support</title>
     <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
 <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
 <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <div>
      <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Technical Support</h3>
                        
                    </div>
                    <div class="panel-heading"> 
                    <%--<h5 class="panel-title">Welcome</h5>--%>
                     <h5 class="panel-title"><asp:Label ID="lblusername" runat="server" style=""></asp:Label></h5>
                    </div>
                    <div class="panel-body">
                    <div class="form-group">
                    Enter Your Registered E-mail ID
                    <asp:TextBox ID="txtusermailid" runat="server" CssClass="form-control"></asp:TextBox>
                    <label id="lblerror" runat="server"></label>
                    </div>
                    <div class="form-group">
                    Message
                    <asp:TextBox ID="txtmessage" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    </div>
                     <div class="form-group">
                  <asp:Button ID="btnsend" runat="server" CssClass="btn bg-success" Text="Send" 
                             onclick="btnsend_Click" />
                    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    <</div>
    
    </form>
</body>
</html>
