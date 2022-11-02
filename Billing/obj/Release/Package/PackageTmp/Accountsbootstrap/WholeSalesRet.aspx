<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WholeSalesRet.aspx.cs"
    Inherits="Billing.Accountsbootstrap.WholeSalesRet" %>

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
    <title>Whole Sales Return Invoice</title>
    <link rel="stylesheet" href="../Styles/chosen.css" />
    
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
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
    <style>
        .chkChoice input
        {
            margin-left: -1pc;
        }
        .chkChoice td
        {
            padding-left: 2pc;
        }
        
        .chkChoice1 input
        {
            margin-left: -20px;
        }
        .chkChoice1 td
        {
            padding-left: 20px;
        }
    </style>
    <script type="text/javascript">
        function SearchEmployees(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount').html((count) + ' match');
            }
            else {
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount').html('');
            }
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background-color: #428bca; color: #333333; border-color: #06090c;
                        color: White">
                        Whole Sales Return Invoice
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <%-- <h1 class="page-header" style="text-align: center; font-size: 20px; font-weight: bold;
                    color: #fe0002; margin-top: 10px">
                    Sales Invoice</h1>--%>
                        <asp:ScriptManager ID="ScriptManager2" runat="server">
                        </asp:ScriptManager>
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-1">
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="Label3" Style="font-weight: bold">Return No. </asp:Label>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator4"
                                                    Text="*" ControlToValidate="txtbillno" ErrorMessage="Please enter Bill NO!" Style="color: Red" />
                                                <asp:TextBox ID="txtbillno" CssClass="form-control" MaxLength="50" runat="server"
                                                    Width="100" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="Label4" Style="font-weight: bold;">Return Date</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1"
                                                    Text="*" ControlToValidate="txtdate" Style="color: Red" ErrorMessage="Enter Bill Date"></asp:RequiredFieldValidator><br />
                                                <asp:TextBox CssClass="form-control" ID="txtdate" runat="server" Width="180"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy hh:mm tt"
                                                    TargetControlID="txtdate" runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>
                                                    Customer Name</label><br />
                                                <asp:DropDownList runat="server" ID="ddlcustomer" CssClass="chzn-select" AutoPostBack="true"
                                                    Width="150px" OnSelectedIndexChanged="ddlcustomer_OnSelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label id="Label7" runat="server">
                                                    Mobile No.</label>
                                                <asp:TextBox CssClass="form-control" ID="txtmbl" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                        <div style="overflow-y: scroll; width: 13pc; height: 10pc">
                                                    <asp:TextBox ID="txtreturnserach" runat="server" onkeyup="SearchEmployees(this,'#chkbillno');"
                                                        CssClass="form-control"></asp:TextBox>
                                            <div class="form-group">
                                                <label>
                                                    WholeSales Nos.</label>
                                                <asp:CheckBoxList ID="chkbillno" CssClass="chkChoice" AutoPostBack="true" Width="100px" OnSelectedIndexChanged="chkinvnochanged"
                                                    RepeatColumns="5" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <div class="form-group">
                                                <label>
                                                    Sub.Total</label>
                                                <asp:TextBox ID="txtgrandamount" runat="server" Enabled="false" Style="width: 100px;
                                                    text-align: right">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <div class="form-group">
                                                <label>
                                                    GST
                                                </label>
                                                <asp:TextBox ID="txtTaxamt" runat="server" Enabled="false" Style="width: 100px; text-align: right">0</asp:TextBox>
                                                <asp:TextBox ID="txtdiscamt" runat="server" Enabled="false" Visible="false">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <div class="form-group">
                                                <label>
                                                    Grand Total</label>
                                                <asp:TextBox ID="txtgrandtotal" runat="server" Enabled="false" Style="width: 80px;
                                                    text-align: right">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="Div1" class="col-lg-12" runat="server" visible="false">
                            <div>
                                <div class="col-lg-1">
                                </div>
                                <div class="col-lg-8">
                                    <table id="Table11" border="3" style="width: 300px">
                                        <tr>
                                            <td style="width: 70px">
                                                <label>
                                                    S.No</label><br />
                                                <asp:TextBox ID="txtsno" runat="server" Height="30px" Enabled="true" Style="width: 70px">1</asp:TextBox>
                                            </td>
                                            <td>
                                                <label>
                                                    ItemName</label><br />
                                                <asp:DropDownList runat="server" ID="ddlitem" CssClass="chzn-select" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 70px">
                                                <label>
                                                    Stock</label><br />
                                                <asp:TextBox ID="txtstock" runat="server" Height="30px" Enabled="false" Style="width: 70px">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    TargetControlID="txtstock" FilterType="Numbers, Custom" ValidChars="." />
                                            </td>
                                            <td style="width: 70px">
                                                <label>
                                                    Rate</label><br />
                                                <asp:TextBox ID="txtrate" runat="server" Width="80px" Enabled="false">0</asp:TextBox>
                                            </td>
                                            <td style="width: 70px">
                                                <label>
                                                    Qty</label><br />
                                                <asp:TextBox ID="txtqty" runat="server" Height="30px" Style="width: 70px" Enabled="true"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" runat="server"
                                                    TargetControlID="txtqty" ValidChars="." FilterType="Numbers, Custom" />
                                            </td>
                                            <td style="width: 70px">
                                                <label>
                                                    GST%</label><br />
                                                <asp:TextBox ID="txttax" Height="30px" runat="server" Style="width: 70px" Enabled="false">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender85" runat="server"
                                                    TargetControlID="txttax" ValidChars="." FilterType="Numbers, Custom" />
                                            </td>
                                            <td style="width: 70px">
                                                <label>
                                                    GST.Amount</label><br />
                                                <asp:TextBox ID="txttaxamount" Height="30px" runat="server" Style="width: 70px" Enabled="false">0.00</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    TargetControlID="txttaxamount" ValidChars="." FilterType="Numbers, Custom" />
                                            </td>
                                            <td style="width: 70px">
                                                <label>
                                                    Amount</label><br />
                                                <asp:TextBox ID="txtamount" Height="30px" runat="server" Style="width: 70px" Enabled="false">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender86" runat="server"
                                                    TargetControlID="txtamount" ValidChars="." FilterType="Numbers, Custom" />
                                            </td>
                                            <td id="Td1" style="width: 60px" runat="server" visible="false">
                                                <asp:Button ID="btngvadd" runat="server" Style="width: 60px" class="btn btn-info"
                                                    Height="40px" Text="Add" Visible="true"  />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-lg-2">
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                                            <div class="table-responsive">
                                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="height: 200px; overflow: scroll">
                                                                <asp:GridView ID="GridView2" AutoGenerateColumns="False" Width="100%" ShowFooter="True" OnRowDataBound="GridView2_OnRowDataBound"
                                                                    OnRowDeleting="GridView2_RowDeleting" GridLines="Both" runat="server">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="1%" ItemStyle-Width="1%">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BillNo">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtbillno" Text='<%# Eval("BillNo")%>' Width="50px" runat="server"
                                                                                    Height="26px" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BillDate">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtbilldate" Text='<%# Eval("BillDate")%>' Width="150px" runat="server"
                                                                                    Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Items">
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="drpItem" Width="150px" runat="server" Height="26px" Enabled="false">
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rate">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtRate" Text='<%# Eval("Rate")%>' Width="50px" runat="server" Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tax">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txttax" Text='<%# Eval("Tax")%>' Width="50px" runat="server" Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Qty">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtQty" Text='<%# Eval("Qty")%>' Width="50px" runat="server" Height="26px"
                                                                                    AutoPostBack="true" Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Ret.Qty">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtreturnqty" Width="50px" runat="server" Enabled="true">0</asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                                    FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtreturnqty" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                      <%--  <asp:TemplateField HeaderText="UOM">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtuom" Text='<%# Eval("UOM")%>' Width="150px" runat="server" Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Ret.Tax">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtrettax" Width="50px" runat="server" Enabled="false">0</asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Ret.Amount">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtretamount" Width="50px" runat="server" Enabled="false">0</asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtid" Text='<%# Eval("ID")%>' Width="50px" runat="server" Enabled="false"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="form-group">
                                                                <label id="Label10" runat="server" style="font-size: large; color: Maroon">
                                                                    Amount</label>
                                                                <br />
                                                                <label id="lbldisplay" runat="server" style="font-size: x-large; color: Blue">
                                                                    0.00
                                                                </label>
                                                            </div>
                                                            <br />
                                                            <div class="form-group">
                                                                <label id="Label2" runat="server" style="font-size: large; color: Maroon">
                                                                    Counts</label>
                                                                <br />
                                                                <label id="lbltotalitems" runat="server" style="font-size: large; color: Blue">
                                                                    0
                                                                </label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr1" class="odd gradeX" runat="server" visible="false">
                                                        <td align="right">
                                                            <label style="margin-top: 11px;">
                                                                Discount Amount</label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <asp:TextBox ID="txtdiscount" runat="server" Enabled="false" CssClass="form-control"
                                                                Style="width: 250px; text-align: right">0</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr2" class="odd gradeX" runat="server" visible="false">
                                                        <td align="right">
                                                            <label style="margin-top: 11px;">
                                                                Amount
                                                            </label>
                                                        </td>
                                                        <td style="width: 250px">
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr3" class="odd gradeX" runat="server" visible="false">
                                                        <td align="right">
                                                            <label style="margin-top: 11px;">
                                                                GST Amount</label>
                                                        </td>
                                                        <td style="width: 250px">
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr4" class="odd gradeX" runat="server" visible="false">
                                                        <td align="right">
                                                            <label style="margin-top: 11px;">
                                                                Discount</label>
                                                        </td>
                                                        <td style="width: 250px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <label>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr5" class="odd gradeX" runat="server" visible="false">
                                                        <td align="right">
                                                            <label style="margin-top: 11px;">
                                                                Grand Total</label>
                                                        </td>
                                                        <td style="width: 250px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div style="text-align: right">
                                            <asp:TextBox ID="txtnarrations" runat="server" placeholder="Please Enter Narrations"
                                                CssClass="form-control" TextMode="MultiLine" Width="200px"></asp:TextBox>
                                            <asp:Button ID="btncalc" Text="Calc" runat="server" Width="120px" OnClick="btncalc_OnClick" />
                                            <asp:Button ID="btnadd" Text="Save" runat="server" class="btn btn-success" ValidationGroup="val1"
                                                Width="120px" OnClick="btnadd_Click" />
                                            <asp:Button ID="btnExit" Text="Exit" runat="server" class="btn btn-warning" Width="120px"
                                                PostBackUrl="~/Accountsbootstrap/WholeSalesReturnGrid.aspx" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    </form>
</body>
</html>
