<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionStockDetails.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ProductionStockDetails" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Production Stock Details </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }
    </script>
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
<body style="">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <h1 class="page-header">
                Production Stock Details</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <div class="panel panel-default" style="">
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div style="">
                            <form runat="server" id="form1" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="form-group" align="center">
                                <%--<asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" Visible="false"
                                    Style="margin-top: 10px;" />
                                <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset" Visible="false"
                                    Style="margin-top: 10px;" />
                                <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add" Style="margin-top: 10px;"
                                    PostBackUrl="~/Accountsbootstrap/productionstock.aspx" />
                                <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Export to Excel" Visible="false"
                                    Style="margin-top: 10px;" OnClick="btnexp_Click" />--%>
                            </div>
                            <div class="table-responsive" align="center">
                                <table class="table table-bordered table-striped" align="center">
                                    <tr>
                                        <td style="">
                                            <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gvitemsdetails')"
                                                CssClass="form-control" Width="200px"></asp:TextBox><br />
                                            <asp:GridView Caption="Production Stock Details" ID="gvitemsdetails" runat="server"
                                                ShowFooter="true" AutoGenerateColumns="false" CssClass="mGrid" Width="50%" OnRowDataBound="gvitemsdetails_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Category" DataField="Category" />
                                                    <asp:BoundField HeaderText="Product" DataField="Definition" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                                     <asp:BoundField HeaderText="UOM" DataField="UOM" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            </form>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</body>
</html>
