<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReport.aspx.cs" Inherits="Billing.Accountsbootstrap.StockReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Stock Report Grid </title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvstock.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
    <script type="text/javascript">
        function printGrid1() {
            var gridData = document.getElementById('<%= gvStockValue.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-lg-12">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Stock Report</div>
            <div class="panel-body">
                <div class="row">
                    <div class="table-responsive">
                        <div class="col-lg-12">
                            <div class="col-lg-1">
                            </div>
                            <div class="col-lg-2">
                                <label>
                                    Admin PassWord</label>
                                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" Width="158px"
                                    TextMode="Password" placeholder="Enter your Password" AutoPostBack="true" OnTextChanged="txtpassword_OnTextChanged"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>
                                        Type</label>
                                    <asp:RadioButtonList ID="rdbtype" runat="server" Enabled="false" RepeatColumns="2"
                                        Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                        <asp:ListItem Text="Qty Details" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Qty Value Details" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label>
                                        Category</label>
                                    <asp:DropDownList ID="ddlcategory" AutoPostBack="true" runat="server" class="form-control"
                                        Width="150px" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-1">
                                <div class="form-group">
                                    <br />
                                    <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Width="110px"
                                        Text="Print" OnClick="btnPrintFromCodeBehind_Click" />
                                </div>
                            </div>
                            <div class="col-lg-1" runat="server" visible="false">
                                <div class="form-group">
                                    <br />
                                    <asp:Button ID="btnExport" Text="Export to Excel" runat="server" Width="110px" CssClass="btn btn-success"
                                        OnClick="btnExport_Click" />
                                </div>
                            </div>
                            <div class="col-lg-1">
                                <br />
                                <asp:Button ID="btnpdf" runat="server" Text="PDF" CssClass="btn btn-info" OnClick="btnpdf_Click"
                                    Width="110px" />
                            </div>
                            <div class="col-lg-1">
                                <asp:Button ID="btnsearch" runat="server" Text="Filter" CssClass="btn btn-success"
                                    Visible="false" OnClick="btnsearch_Click" />
                                <asp:Button ID="Button1" runat="server" Text="Print From Client-side" Visible="false"
                                    OnClientClick="printGrid()" />&nbsp;&nbsp;
                                <asp:Button ID="btnitemsync" runat="server" class="btn btn-warning" Text="Sync. to Production"
                                    Visible="false" OnClick="btnsyncclick" Width="170px" />
                                <asp:Button ID="btnreset" runat="server" Visible="false" Text="Reset" CssClass="btn btn-success"
                                    OnClick="btnreset_Click" />
                                <asp:Button ID="btnApp" runat="server" Text="exe" OnClick="btnApp_Click" Visible="false" />
                            </div>
                        </div>
                        <table class="table table-bordered table-striped" border="0">
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:GridView ID="gvstock" runat="server" AutoGenerateColumns="false" AllowPaging="false"
                                        CssClass="mGrid" PageSize="50" OnPageIndexChanging="page_change" OnRowDataBound="gvstock_RowDataBound" Caption="Store Stock Details"
                                        OnRowCreated="gvstock_RowCreated">
                                        <HeaderStyle BackColor="#3366FF" />
                                        <PagerSettings FirstPageText="1" Mode="Numeric" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Category " DataField="Category" Visible="true" />
                                            <asp:BoundField HeaderText="Sub Category" DataField="Definition" />
                                            <asp:BoundField HeaderText="Quantity" Visible="false" DataField="Quantity" DataFormatString='{0:N0}' />
                                            <asp:BoundField HeaderText="Available Quantity" DataField="Available_QTY" DataFormatString='{0:N0}' />
                                            <asp:BoundField HeaderText="Purchase Price" Visible="false" DataFormatString="{0:f}"
                                                DataField="Rate" />
                                            <asp:BoundField HeaderText="Stock Total Price" Visible="false" DataFormatString="{0:f}"
                                                DataField="StockAmount" />
                                            <asp:BoundField HeaderText="Min Stock" Visible="false" DataFormatString="{0:f}" DataField="MinQty" />
                                        </Columns>
                                        <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    </asp:GridView>
                                    <div id="div1" runat="server">
                                        <asp:GridView ID="gvStockValue" Caption="Stock Value Report" runat="server" CssClass="mGrid"
                                            OnRowDataBound="gvStockValue_OnRowDataBound" ShowFooter="true" AutoGenerateColumns="false"
                                            Width="100%">
                                            <HeaderStyle BackColor="#3366FF" />
                                            <PagerSettings FirstPageText="1" Mode="Numeric" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SNo">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Category" DataField="Category" />
                                                <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="MRP" DataField="MRP" DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="QTY" DataField="Available_QTY" DataFormatString="{0:f2}"
                                                    ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="TotalAmount" DataField="TotalAmount" DataFormatString="{0:f2}"
                                                    ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                            </Columns>
                                            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="left">
                                    <asp:GridView Visible="false" ID="gvlowstock" runat="server" AutoGenerateColumns="false"
                                        AllowPaging="true" BackColor="Red" ForeColor="WhiteSmoke">
                                        <Columns>
                                            <asp:BoundField HeaderText="Category " DataField="Category" />
                                            <asp:BoundField HeaderText="Sub Category" DataField="Definition" />
                                            <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                            <asp:BoundField HeaderText="Available Quantity" DataField="Available_QTY" />
                                            <asp:BoundField HeaderText="Unit Price" DataFormatString="{0:f}" DataField="unitprice" />
                                        </Columns>
                                        <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    </asp:GridView>
                                    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                                </td>
                            </tr>
                            <tr id="admin" runat="server">
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
