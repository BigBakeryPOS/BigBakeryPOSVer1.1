<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SwitchReceipt.aspx.cs" Inherits="Billing.Accountsbootstrap.SwitchReceipt" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Switch  Receipt</title>

   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
     <link href="../Styles/style1.css" rel="stylesheet"/>

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
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }
    </script>
    


</head>
<body>
    <form id="form1" runat="server">
     <usc:Header ID="Header" runat="server" />
     <div class="col-lg-4">
     
     <div class="form-group" style="margin-top:100px" >
                                 <label>Switch Branch</label>
                                 <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server"    >
                                 <asp:ListItem Text="Select Branch" Value="0"></asp:ListItem>
                                 <asp:ListItem Text=" Branch1" Value="1"></asp:ListItem>
                                 <asp:ListItem Text=" Branch2" Value="2"></asp:ListItem>
                                 <asp:ListItem Text=" Branch3" Value="3"></asp:ListItem>

                                 </asp:DropDownList>
                                 </div>
                                 <div class="form-control">
                                 <asp:Button ID="btnswitch" runat="server" CssClass="btn btn-success" Text="Switch" 
                                         onclick="btnswitch_Click" />

                                 </div>
                                 </div>
    </form>
</body>
</html>
