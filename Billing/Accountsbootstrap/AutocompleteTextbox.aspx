<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutocompleteTextbox.aspx.cs" Inherits="Billing.Accountsbootstrap.AutocompleteTextbox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />

	<script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css"/>
<link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

</head>
<body>

    <form id="form1" runat="server">
    <div class="row">
    <div class="col-lg-12">
    <div class="panel-panel-default">
    <div class="panel-body">
    <div class="form-group">
    <label>Enter Names</label>
    <asp:ScriptManager ID="ceriptmanager" runat="server"></asp:ScriptManager>
    <asp:TextBox ID="txtnames" runat="server"></asp:TextBox>
    <ajaxToolkit:AutoCompleteExtender ID="autocompleteextender" runat="server" ServiceMethod="AutoCompleteAjaxRequest"  MinimumPrefixLength="2"
                    CompletionInterval="100"
                    EnableCaching="false"
                    CompletionSetCount="10"
                    TargetControlID="txtnames" 
                    FirstRowSelected="false" ServicePath="WebService1.asmx" ></ajaxToolkit:AutoCompleteExtender>
    </div>
    
    </div>
    
    </div>
    
    </div>
    
    </div>
    </form>
</body>
</html>
