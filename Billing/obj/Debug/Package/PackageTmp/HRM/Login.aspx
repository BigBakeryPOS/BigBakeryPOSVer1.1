﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRM.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
</head>
<body>
    <div class="container" >
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default" style="width: 350px">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Image ID="img" runat="server" ImageUrl="~/images/blackforestlogo.png" Style="width: 300px;height:150px"  /></h3>
                    </div>
                    <div class="panel-body">
                        <form id="Form1" action="" runat="server">
                        <fieldset>
                            <div class="form-group">
                               Employee Code
                                <asp:TextBox CssClass="form-control" ID="txtusername" runat="server" placeholder="Enter your Employee Code"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Password
                                <asp:TextBox CssClass="form-control" ID="txtpassword" TextMode="Password" runat="server"
                                    placeholder="Enter your Password"></asp:TextBox>
                            </div>
                            <div class="checkbox">
                                Remember me:<asp:CheckBox Style="margin-left: 20px;" ID="chkRememberMe" runat="server" />
                            </div>
                            <div class="form-group">
                                <!-- Change this to a button or input when using this as a form -->
                                <asp:Button class="btn btn-lg btn-success btn-block " ID="LoginButton" runat="server"
                                    CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                                    OnClick="LoginButton_Click" Width="318px" />
                            </div>
                            <%--<asp:Button class="btn btn-lg btn-success btn-block" ID="regform" runat="server" 
                            CommandName="RegForm" Text="Registration Form" Width="332px" 
                                    onclick="regform_Click" />--%>
                            <asp:Label ID="lblempid" runat="server"></asp:Label>
                        </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblempname" runat="server"></asp:Label>
    <asp:Label ID="lblserviceid" runat="server"></asp:Label>
    <div class="form-group" style="text-align: center">
        Copyright@2015 Bigdbiz Solutions
    </div>
    <!-- jQuery -->
    <script type="text/javascript" src="../js/jquery.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script type="text/javascript" src="../js/plugins/metisMenu/metisMenu.min.js"></script>
    <!-- Custom Theme JavaScript -->
    <script type="text/javascript" src="../js/sb-admin-2.js"></script>
</body>
</html>
