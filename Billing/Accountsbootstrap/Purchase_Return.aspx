<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_Return.aspx.cs" Inherits="Billing.Accountsbootstrap.Purchase_Return" %>

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
        .Hide {
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
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row panel-custom1">
                                <div class="panel-header">
                                    <h1 class="page-header">Purchase Return Entry</h1>
                                </div>

                                <div class="panel-body">
                                    <div class="row">


                                        <div id="Div3" runat="server" visible="true" class="col-lg-3">

                                            <div id="Div2" runat="server" visible="true">
                                                <label>
                                                    Select Purchase InvoiceNo</label>
                                            </div>

                                            <asp:DropDownList ID="drpPO" runat="server" AutoPostBack="true" TabIndex="3" OnSelectedIndexChanged="drpPO_OnSelectedIndexChanged"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>


                                        <%--  <label>
                                        Billing Type :</label>--%>


                                        <asp:RadioButtonList ID="rbtype" runat="server" RepeatColumns="2" AutoPostBack="true" Visible="false"
                                            OnSelectedIndexChanged="rbtype_OnSelectedIndexChanged">
                                            <asp:ListItem Text="Direct Purchase" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="From Purchase Order" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>




                                        <label id="Label1" runat="server" visible="false">
                                        </label>


                                        <div class="col-lg-3">
                                            <label>Purchase Type</label>
                                            <asp:RadioButtonList ID="rbdpurchasetype" runat="server" Enabled="false" RepeatColumns="2" AutoPostBack="true"
                                                OnSelectedIndexChanged="rbdpurchasetype_OnSelectedIndexChanged">
                                                <asp:ListItem Text="Local Purchase" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Inter-State Purchase" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>

                                        <div id="shwedit" runat="server" visible="false">
                                            <label>
                                                Edit Narrations :</label>
                                            <asp:TextBox CssClass="form-control" ID="txteditnarrations" runat="server"></asp:TextBox>
                                        </div>


                                        <label id="lblpurchase" runat="server" visible="false">
                                        </label>

                                        <div class="col-lg-3">
                                            <label>Bill No</label>
                                            <asp:TextBox Visible="false" CssClass="form-control" ID="txtbillno" placeholder="Enter Bill No"
                                                runat="server" Enabled="false"></asp:TextBox>
                                            <asp:TextBox CssClass="form-control" ID="txtdcno" placeholder="Enter Bill No" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>Bill Date</label>
                                            <asp:TextBox CssClass="form-control" ID="txtsdate1" runat="server" Enabled="false"
                                                TabIndex="1" placeholder="Select Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="MM/dd/yyyy" TargetControlID="txtsdate1"
                                                runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>Supplier</label>
                                            <asp:DropDownList ID="ddlsuplier" runat="server" TabIndex="2" CssClass="form-control" Enabled="false"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                Paymode</label>
                                            <asp:DropDownList ID="ddlpaymode" runat="server" AutoPostBack="true" TabIndex="3"
                                                CssClass="form-control" OnSelectedIndexChanged="ddlpaymode_OnSelectedIndexChanged">
                                                <%--  <asp:ListItem Text="Select Payment" Value="0" Enabled="true"></asp:ListItem>
                                                <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Credit" Value="2" Enabled="true"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <label id="lblbank" runat="server">Select Bank</label>
                                            <asp:DropDownList ID="ddlbank" runat="server" AutoPostBack="true" CssClass="form-control"
                                                Visible="false">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-2">
                                            <label id="lblChq" runat="server">Enter Cheque/Card no</label>
                                            <asp:TextBox CssClass="form-control" ID="txtcheque" placeholder="Enter Cheque/Card no" runat="server"
                                                Visible="false"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-12">
                                            <asp:Panel ID="Panel1" runat="server">
                                                <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gvcustomerorder" runat="server" AutoGenerateColumns="False" OnRowDeleting="grvStudentDetails_RowDeleting" CssClass="table table-striped pos-table"
                                                        OnRowDataBound="gvcustomerorder_RowDataBound" padding="0" spacing="0" border="0">
                                                        <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                                        <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    Height="40px" Font-Names="arial" Font-Size="Medium" HorizontalAlign="Center" />--%>
                                                        <%--<RowStyle BorderColor="Gray" BorderStyle="Solid" BorderWidth="0.5px" />--%>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <asp:TextBox Width="50px" class="form-control" TabIndex="4"
                                                                        ID="txtsno" runat="server">1</asp:TextBox>
                                                                    <asp:Label ID="lbluomid" Visible="true" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblprimaryuntiid" Visible="true" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ingredients">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlDef" CssClass="form-control" runat="server" TabIndex="5" Enabled="false"
                                                                        Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlDef_OnSelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Billing Name">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtbillingname" Enabled="false" Width="100px" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Units">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlunits" Visible="true" CssClass="form-control" runat="server" Enabled="false">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblunits" Width="85px" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle HorizontalAlign="Right" />
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="HSN Code">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txthsncode" Width="100px" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Primary Unit">
                                                                <ItemTemplate>
                                                                    <%--   <asp:DropDownList ID="ddlprimaryunits" Width="100px" Enabled="true" CssClass="form-control"
                                                                runat="server" OnSelectedIndexChanged="drpprimary_unit" AutoPostBack="true">
                                                            </asp:DropDownList>--%>
                                                                    <%--<asp:Label ID="lblprimaryvalue" runat="server"></asp:Label>--%>

                                                                    <asp:Label ID="lblprimaryname" Width="100px" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblprimarynamevalue" Visible="false" Width="100px" runat="server"></asp:Label>
                                                                    <asp:Label ID="lblprimaryvalue" Visible="true" runat="server"></asp:Label>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SubCatID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescriptionID" runat="server" CssClass="LabelText"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Purchase.Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label Width="50px" Style="text-align: center"
                                                                        ID="lblpoqty" runat="server">0</asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Return Quantity">
                                                                <ItemTemplate>
                                                                    <asp:TextBox class="form-control" Width="100px" OnTextChanged="txtdefQty_TextChanged"
                                                                        AutoPostBack="true" ID="txtQty" runat="server" MaxLength="10">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Disc %">
                                                                <ItemTemplate>
                                                                    <asp:TextBox class="form-control" Width="50px" ID="txtDisCount" Enabled="false" OnTextChanged="txtDisCount_TextChanged" 
                                                                        AutoPostBack="true" runat="server" MaxLength="10">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Disc.Amnt">
                                                                <ItemTemplate>
                                                                    <asp:TextBox class="form-control" Width="50px" ID="txtDisCountAmount" Enabled="false" OnTextChanged="txtDisCountAmount_TextChanged" 
                                                                        AutoPostBack="true" runat="server" MaxLength="10">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GST%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBillNo" runat="server" Enabled="false" CssClass="form-control" Width="100px" AutoPostBack="true"
                                                                        OnTextChanged="txtBillNo_TextChanged">0</asp:TextBox>
                                                                </ItemTemplate>
                                                                <%--<FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate">
                                                                <ItemTemplate>
                                                                    <asp:TextBox Width="100px" Style="text-align: right" placeholder="Enter Rate" class="form-control"
                                                                        ID="txtRate" runat="server" Enabled="false" OnTextChanged="txtdefCatID_TextChanged" AutoPostBack="true"
                                                                        MaxLength="10">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:TextBox Width="100px" Enabled="false" class="form-control"
                                                                        ID="txtAmount" runat="server" MaxLength="50">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Exp.Date">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtexpireddate" Enabled="false" runat="server" CssClass="form-control" Width="150px">0</asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtexpireddate"
                                                                        PopupButtonID="txtexpireddate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                                                                        CssClass="cal_Theme1">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                </ItemTemplate>
                                                                <%-- <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Purchase Qty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox Width="100px" Enabled="false" class="form-control" 
                                                                        ID="txtpqty" runat="server" MaxLength="50">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Narrations">
                                                                <ItemTemplate>
                                                                    <asp:TextBox Width="200px" Height="35px" class="form-control" TextMode="MultiLine"
                                                                        ID="txtnarrations" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Supplier" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddSupplier" class="form-control" runat="server" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtsupplier" runat="server" placeholder="Enter SupplierName" CssClass="form-control"
                                                                        Visible="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <%-- <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="payMode" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlPay" CssClass="form-control" runat="server">
                                                                        <asp:ListItem Value="Select Payment Mode">Select Payment Mode</asp:ListItem>
                                                                        <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                                        <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                                                        <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                                <%--<FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>--%>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="add" runat="server" OnClick="btnnew_Click">
                                                                        <asp:Image ID="img" Width="20px" runat="server" ImageUrl="~/images/edit_add.png" Visible="false" />


                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="catid1" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/images/delete.png" Visible="false" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-lg-3">
                                            <label>
                                                SubTotal</label>
                                            <asp:TextBox ID="txtSubTotal" Enabled="false" runat="server"
                                                CssClass="form-control">0</asp:TextBox>
                                        </div>
                                         <div class="col-lg-2">
                                            <label>
                                                Discount</label>
                                            <asp:TextBox ID="txtDiscountAmount" Enabled="false" runat="server" CssClass="form-control">0</asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                CGST</label>
                                            <asp:TextBox ID="txtcgst" runat="server" CssClass="form-control" Enabled="false"
                                                AutoPostBack="true">0</asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                SGST</label>
                                            <asp:TextBox ID="txtsgst" runat="server" CssClass="form-control" Enabled="false"
                                                AutoPostBack="true">0</asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                IGST</label>
                                            <asp:TextBox ID="txtigst" runat="server" CssClass="form-control" Enabled="false"
                                                AutoPostBack="true">0</asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                Total</label>
                                            <asp:TextBox ID="txttotal" runat="server" Enabled="false"
                                                CssClass="form-control">0</asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                Round Off</label>
                                            <asp:TextBox ID="txtroundoff" runat="server" Enabled="false" CssClass="form-control">0</asp:TextBox>
                                        </div>
                                        <div class="col-lg-3">
                                            <br />
                                            <asp:Button ID="Button1" runat="server" CssClass=" btn btn-lg btn-primary pos-btn1" Width="150px" Text="Save"
                                                OnClientClick="SetTarget();" OnClick="btnSave_Click" />
                                            <asp:Button ID="Button2" runat="server" CssClass=" btn btn-lg btn-link" Text="Exit"
                                                PostBackUrl="~/Accountsbootstrap/Purchase_invGrid.aspx" />
                                        </div>
                                    </div>
                                    <table width="45%">
                                        <tr runat="server" visible="false">
                                            <td align="right"></td>
                                            <td align="right"></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="right"></td>
                                            <td align="right"></td>
                                        </tr>
                                        <tr>
                                            <td align="center"></td>
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
