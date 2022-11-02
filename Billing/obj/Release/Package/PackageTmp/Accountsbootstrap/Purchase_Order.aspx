<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_Order.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Purchase_Order" %>

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
    <title>Invoice </title>
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <link href="../Accountsbootstrap/css/chosen.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <%-- <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />--%>
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
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="update" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Purchase Order Entry
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-2">
                                    <label>
                                        Purchase Order Type :</label>
                                </div>
                                <div class="col-lg-4">
                                    <asp:RadioButtonList ID="rbdpurchasetype" runat="server" RepeatColumns="2" AutoPostBack="true"
                                        OnSelectedIndexChanged="rbdpurchasetype_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Local Purchase" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Inter-State Purchase" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-lg-2">
                                    <div id="shwedit" runat="server" visible="false">
                                        <label>
                                            Edit Narrations :</label>
                                        <asp:TextBox CssClass="form-control" ID="txteditnarrations" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                </div>
                                <div class="col-lg-2">
                                    <label>
                                    </label>
                                    <label id="lblpurchase" runat="server" visible="false">
                                    </label>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-3">
                                    <label>
                                        Order No</label>
                                    <asp:TextBox Visible="false" CssClass="form-control" ID="txtbillno" placeholder="Enter Order No"
                                        runat="server" Enabled="false"></asp:TextBox>
                                    <asp:TextBox CssClass="form-control" ID="txtdcno" placeholder="Enter Order No" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        Order Date</label>
                                    <asp:TextBox CssClass="form-control" ID="txtsdate1" Enabled="true" runat="server"
                                        TabIndex="1" placeholder="Select Date"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtsdate1"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        Supplier</label>
                                    <asp:DropDownList ID="ddlsuplier" runat="server" TabIndex="2" CssClass="form-control"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        Paymode</label>
                                    <asp:DropDownList ID="ddlpaymode" runat="server" AutoPostBack="true" TabIndex="3"
                                        CssClass="form-control" OnSelectedIndexChanged="ddlpaymode_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Select Payment" Value="0" Enabled="true"></asp:ListItem>
                                        <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Credit" Value="2" Enabled="true"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:DropDownList ID="ddlbank" runat="server" AutoPostBack="true" CssClass="form-control"
                                    Visible="false">
                                </asp:DropDownList>
                                <asp:TextBox CssClass="form-control" ID="txtcheque" placeholder="Enter Bill No" runat="server"
                                    Visible="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <%--  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="chzn-container"
                                                        GridLines="None" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting"
                                                        ShowFooter="True" Width="100%">--%>
                        <asp:Panel ID="Panel1" runat="server" Height="360" ScrollBars="Both" Width="100%">
                            <asp:GridView ID="gvcustomerorder" runat="server" AutoGenerateColumns="False" OnRowDeleting="grvStudentDetails_RowDeleting"
                                Font-Names="Calibri" OnRowDataBound="gvcustomerorder_RowDataBound">
                                <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    Height="30px" Font-Names="arial" Font-Size="Medium" HorizontalAlign="Center" />       --%>
                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />
                                <RowStyle Height="3px" />
                                <Columns>
                                    <%--   <asp:TemplateField HeaderText="SNo" ItemStyle-HorizontalAlign="Center">--%>
                                    <asp:TemplateField ControlStyle-Width="100%" HeaderStyle-ForeColor="white" HeaderStyle-Width="5%"
                                        ItemStyle-HorizontalAlign="Center" HeaderText="S.No" ItemStyle-Width="6%">
                                        <ItemTemplate>
                                            <asp:TextBox Width="50px" Style="text-align: left" class="form-control" TabIndex="4"
                                                Height="25px" ID="txtsno" runat="server">1</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ingredients" HeaderStyle-Width="450px" HeaderStyle-ForeColor="white"
                                        ItemStyle-Height="30px">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlDef" CssClass="chzn-select" runat="server" TabIndex="5"
                                                Height="25px" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlDef_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Units" ControlStyle-Width="10%" HeaderStyle-Width="100px"
                                        HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlunits" Visible="false" CssClass="form-control" runat="server"
                                                Height="25px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblunits" Width="130px" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Primary Unit" 
                                        HeaderStyle-ForeColor="white" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlprimaryunits" Width="100%"  CssClass="chzn-select" runat="server" OnSelectedIndexChanged="drpprimary_unit" AutoPostBack="true"
                                                Height="25px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblprimaryvalue" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubCatID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescriptionID" runat="server" CssClass="LabelText" Height="25px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="50px" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:TextBox class="form-control" Width="121px" OnTextChanged="txtdefQty_TextChanged"
                                                Height="25px" AutoPostBack="true" ID="txtQty" runat="server" MaxLength="10">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GST%" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" Width="81px" AutoPostBack="true"
                                                Height="25px" OnTextChanged="txtBillNo_TextChanged">0</asp:TextBox>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:TextBox Width="121px" Style="text-align: right" placeholder="Enter Rate" class="form-control"
                                                Height="25px" ID="txtRate" runat="server" OnTextChanged="txtdefCatID_TextChanged"
                                                AutoPostBack="true" MaxLength="10">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="150px"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:TextBox Width="150px" Style="text-align: right" Enabled="false" class="form-control"
                                                Height="25px" ID="txtAmount" runat="server" MaxLength="50">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Purchase Qty" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="150px"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:TextBox Width="150px" Style="text-align: right" Enabled="false" class="form-control"
                                                Height="25px" ID="txtpqty" runat="server" MaxLength="50">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ControlStyle-Width="100%" HeaderStyle-ForeColor="white" HeaderText="Expired Date"
                                        Visible="false" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtexpireddate" runat="server" Enabled="true" Height="25px" Width="250px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtexpireddate"
                                                PopupButtonID="txtexpireddate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                                                CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier" ItemStyle-HorizontalAlign="Left" Visible="false"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddSupplier" class="chzn-select" runat="server" AutoPostBack="true"
                                                Height="25px">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtsupplier" runat="server" placeholder="Enter SupplierName" CssClass="form-control"
                                                Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="payMode" ItemStyle-HorizontalAlign="Left" Visible="false"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlPay" CssClass="form-control" runat="server" Height="25px">
                                                <asp:ListItem Value="Select Payment Mode">Select Payment Mode</asp:ListItem>
                                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                                <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="add" runat="server" OnClick="btnnew_Click">
                                                <asp:Image ID="img" Width="20px" runat="server" ImageUrl="~/images/edit_add.png" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="catid1" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" ShowDeleteButton="true" HeaderStyle-Width="60px"
                                        DeleteImageUrl="~/images/delete.png" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <div class="col-lg-12">
                            <div class="col-lg-2">
                                <label>
                                    SubTotal</label>
                                <asp:TextBox ID="txtSubTotal" Enabled="false" runat="server" Style="text-align: right"
                                    Width="130px" CssClass="form-control">0</asp:TextBox></div>
                            <div class="col-lg-2">
                                <label>
                                    CGST</label>
                                <asp:TextBox ID="txtcgst" runat="server" CssClass="form-control" Width="130px" Enabled="false"
                                    AutoPostBack="true" Style="text-align: right">0</asp:TextBox></div>
                            <div class="col-lg-2">
                                <label>
                                    SGST</label>
                                <asp:TextBox ID="txtsgst" runat="server" CssClass="form-control" Width="130px" Enabled="false"
                                    AutoPostBack="true" Style="text-align: right">0</asp:TextBox></div>
                            <div class="col-lg-2">
                                <label>
                                    IGST</label>
                                <asp:TextBox ID="txtigst" runat="server" CssClass="form-control" Width="130px" Enabled="false"
                                    AutoPostBack="true" Style="text-align: right">0</asp:TextBox></div>
                            <div class="col-lg-2">
                                <label>
                                    Total</label>
                                <asp:TextBox ID="txttotal" runat="server" Enabled="false" Style="text-align: right"
                                    Width="130px" CssClass="form-control">0</asp:TextBox></div>
                            <div class="col-lg-2">
                                <br />
                                <asp:Button ID="Button1" runat="server" CssClass=" btn btn btn-success" Text="Save"
                                    OnClientClick="SetTarget();" OnClick="btnSave_Click" />
                                <asp:Button ID="Button2" runat="server" CssClass=" btn btn btn-danger" Text="Exit"
                                    PostBackUrl="~/Accountsbootstrap/Purchase_OrderGrid.aspx" /></div>
                        </div>
                        <table width="45%">
                            <tr runat="server" visible="false">
                                <td align="right">
                                </td>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="right">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlContents" runat="server">
                            <div id="div1" style="background-color: ">
                                <table width="265px" id="tblPrint" runat="server" visible="false">
                                    <tr>
                                        <td align="center" style="font-size: small">
                                            <label>
                                                Customer Name:-</label>
                                            <asp:Label ID="lblcustname" runat="server">Raja</asp:Label>
                                            <label>
                                                Mobile:-</label>
                                            <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="font-size: small">
                                        <td align="center">
                                            <label>
                                                Bill No</label>
                                            <asp:Label ID="lblbillno" runat="server"></asp:Label>
                                            <label>
                                                Bill Date:</label>
                                            <asp:Label ID="lbldate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gvPrint" runat="server" Width="265px" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField HeaderText="item" DataField="Definition" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Rate" DataField="UnitPrice" DataFormatString="{0:N2}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N2}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <label>
                                                Advance:-
                                            </label>
                                            <asp:Label ID="lbladvance" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <label>
                                                Total:-
                                            </label>
                                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            </div>
            <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
            <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
            <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
            <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
            <script type="text/javascript">
                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); 
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvcustomerorder" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
