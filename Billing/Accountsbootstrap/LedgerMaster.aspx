<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LedgerMaster.aspx.cs" Inherits="Billing.Accountsbootstrap.LedgerMaster" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>ledger creation</title>
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../Styles/metisMenu.min.css" rel="stylesheet" />

     <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>
    <link href="../css/Pos_style.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <!-- Custom CSS -->
    <link href="../Styles/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../Styles/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
       <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {


            var strData = strKey.value.toLowerCase().split(" ");

            var tblData = document.getElementById(strGV);

            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)

                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }    
       </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <div class="container-fluid">
        <div class="row">
        <div class="col-md-12">
            <div class="col-md-4 col-md-offset-4 ">
                <div class="row panel-custom1">
                    <%--<div class="panel-heading">
                            <h2 class="panel-title" style="text-align: center">
                            Ledger Creation</h2>
                    </div>--%>
                     <div class="panel-header">
                      <h1 class="page-header">Add Ledger Master</h1>
	                </div>
                    <div class="panel-body">

                        <form id="Form1" action="" runat="server">
                        <fieldset id="f1" runat="server">
                            <div class="list-group">
                                <label>
                                    Group Head</label>
                                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                           <br />
                                <label>
                                    Name</label>
                                <asp:TextBox CssClass="form-control" ID="txtledger" runat="server" placeholder="Name"></asp:TextBox>
                            
                            <br />
                                
                                    <asp:Button class="btn btn-lg btn-primary pos-btn1" ID="btnsave" Width="150px" runat="server"
                                        Text="Save" OnClick="btnsave_Click" />
                                
                                
                                    <asp:Button class="btn btn-lg btn-link" ID="btnexit" Width="100px" runat="server"
                                        Text="Clear" OnClick="btnexit_Click" />
                                </div>
                            
                        </fieldset>
                        <div class="form-group" style="text-align: center">
                        </div>
                        <!-- jQuery -->
                        <script type="text/javascript" src="../js/jquery.js"></script>
                        <!-- Bootstrap Core JavaScript -->
                        <script type="text/javascript" src="../js/bootstrap.min.js"></script>
                        <!-- Metis Menu Plugin JavaScript -->
                        <script type="text/javascript" src="../Styles/metisMenu.min.css"></script>
                        <!-- Custom Theme JavaScript -->
                        <script type="text/javascript" src="../js/sb-admin-2.js"></script>
                        </form>
                    </div>
                </div>
                </div>
            </div>
        </div>
        </div>
     
</body>
</html>
