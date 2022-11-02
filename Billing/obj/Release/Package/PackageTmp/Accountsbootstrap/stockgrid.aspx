<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stockgrid.aspx.cs" Inherits="Billing.Accountsbootstrap.stockgrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Stock Grid </title>
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="../css/sb-admin-2.css" rel="stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="../Styles/Gridstyle.css" rel="stylesheet" type="text/css" />
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
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="panel panel-primary">
        <div class="panel-heading ">
            <b>Stock Master</b></div>
        <div class="panel-body ">
            <div class="form-group">
                <div class="col-lg-12">
                    <div class="col-lg-2">
                        <asp:DropDownList CssClass="form-control" ID="ddlfilter" runat="server">
                            <asp:ListItem Text="Search By" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Item Name" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" OnClick="Search_Click" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Button ID="btnreset" runat="server" class="btn btn-warning" Text="Reset" OnClick="Reset_Click" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add Stock Details"
                            OnClick="btnadd_Click" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btnTransfer" runat="server" Visible="false" class="btn btn-danger" Text="New Transfer"
                            OnClick="btnTransfer_Click" />
                    </div>
                    <div class="col-lg-2"></div>
                    </div>
                      <div class="col-lg-12">
                    <table runat="server" width="100%" >
                        <tr>
                            <td  align="justify">
                                <asp:GridView ID="gridview" runat="server" AllowPaging="true" PageSize="30" OnPageIndexChanging="Page_Change" Width="100%" Font-Names="Calibri"
                                    AutoGenerateColumns="false" OnRowCommand="gvstock_RowCommand" OnRowDataBound="gridview_RowDataBound">
                                     <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                    <%-- <HeaderStyle BackColor="#990000" />--%>
                                    <PagerSettings FirstPageText="1" Mode="Numeric" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Group " DataField="Category" />
                                        <asp:BoundField HeaderText="Item" DataField="Definition" />
                                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" Visible="false" />
                                        <asp:BoundField HeaderText="Available Quantity" DataField="Available_QTY" DataFormatString="{0:f0}" />
                                        <asp:BoundField HeaderText="Customer Unit Price" DataFormatString="{0:f}" DataField="unitprice"
                                            Visible="false" />
                                        <asp:BoundField HeaderText="Dealer Unit Price" DataFormatString="{0:f}" DataField="DealerUnitPrice"
                                            Visible="false" />
                                        <asp:BoundField HeaderText="Press Unit Price" DataFormatString="{0:f}" DataField="PressUnitPrice"
                                            Visible="false" />
                                        <asp:BoundField HeaderText="Stock Total Amount" DataFormatString="{0:f}" DataField="StockAmount"
                                            Visible="false" />
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                    <%-- <HeaderStyle BackColor="#990000"  ForeColor="Black" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </div></div> </div>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Stock List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                </p>
            </div>
            <div class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" value="No" />
            </div>
        </div>
    </asp:Panel>
    </form>
    <!-- /.col-lg-6 (nested) -->
</body>
</html>
