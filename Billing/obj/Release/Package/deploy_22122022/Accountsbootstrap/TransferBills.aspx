<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferBills.aspx.cs" Inherits="Billing.Accountsbootstrap.TransferBills" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Transfer Bill</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
   
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>
   
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
     <script type="text/javascript">
         function alertMessage() {
             alert('Data Transfer Success!');
         }
    </script>

    <style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>
</head>
<body background="../images/BlackForrestRe.png" style="text-align:center;background-position:center;  background-repeat: no-repeat;  background-attachment: fixed;background-color:White" > 
    <form id="form1" runat="server">
     <usc:Header ID="Header" runat="server" />
    <div>
    <div>
    <h1><label>Import      Bills</label></h1>
    </div>
    <asp:ScriptManager ID="script" runat="server" ></asp:ScriptManager>
    <table  >
    <tr>
    <td>
    <asp:GridView ID="gvBills" runat="server"  CaptionAlign="Top" Caption="IMPORTING BILLS" ></asp:GridView>
    </td>
    </tr>
    
    <tr align="center">
    <td align="center">
    <label >Select Date</label>
    <asp:TextBox ID="txtDate" runat="server"   ></asp:TextBox>
    <ajaxToolkit:CalendarExtender  ID="calander" TargetControlID="txtDate"  runat="server"></ajaxToolkit:CalendarExtender>
    </td>
    </tr>
    
    <tr>
    <td>
    <asp:Button ID="btnTransfer" runat="server" Text="Transfer" CssClass=" btn btn-warning "  
    onclick="btnTransfer_Click" />
    </td>
    </tr>
    </table>
    </div>
    <div class="loading" align="center">
    Data Transfer In Progress...<br />
    <br />
    <img src="../images/a_10mailput_e0.gif" alt="" />
</div>
    </form>
</body>
</html>
