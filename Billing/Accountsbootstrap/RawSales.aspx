<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RawSales.aspx.cs" Inherits="Billing.Accountsbootstrap.RawSales" %>

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
    <title>RAW SALES Invoice </title>
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
        <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">RAW SALES Entry</h1>
	    </div>
           
                    <div class="panel-body">
                        <div class="row">
                            <div runat="server" visible="false" class="col-lg-12">
                                <div class="col-lg-3">
                                    <label>Billing Type </label>

                                    <asp:RadioButtonList ID="rbtype" runat="server" RepeatColumns="2" AutoPostBack="true"
                                        OnSelectedIndexChanged="rbtype_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Direct Purchase" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="From Purchase Order" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>

                                    <div id="Div2" runat="server" visible="false" class="col-lg-3">
                                        <label>
                                            Select Purchase OrderNo</label>
                                    </div>

                                    <div id="Div3" runat="server" visible="false" class="col-lg-3">
                                        <asp:DropDownList ID="drpPO" runat="server" AutoPostBack="true" TabIndex="3" OnSelectedIndexChanged="drpPO_OnSelectedIndexChanged"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                <div class="col-lg-3">
                                    <label id="Label1" runat="server" visible="false">
                                    </label>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-3">
                                    <label>  Purchase Type</label>
                                    <asp:RadioButtonList ID="rbdpurchasetype" runat="server" RepeatColumns="2" AutoPostBack="true"
                                        OnSelectedIndexChanged="rbdpurchasetype_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Local Purchase" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Inter-State Purchase" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                
                                    <div id="shwedit" class="col-lg-3" runat="server" visible="false">
                                        <label>Edit Narrations :</label>
                                        <asp:TextBox CssClass="form-control" ID="txteditnarrations" runat="server"></asp:TextBox>
                                    </div>
                                   
                                    <label id="lblpurchase" runat="server" visible="false">
                                    </label>
                               
                                <div class="col-lg-3">
                                        <label>Invoice/DC No</label>
                                        <asp:TextBox Visible="true" CssClass="form-control" ID="txtbillno" placeholder="Enter Bill No"
                                            runat="server" Enabled="false"></asp:TextBox>
                                        <asp:TextBox CssClass="form-control" ID="txtdcno" Visible="false" placeholder="Enter Bill No" runat="server">0</asp:TextBox>
                                   </div>
                                    <div class="col-lg-3">
                                        <label>Bill Date</label>
                                        <asp:TextBox CssClass="form-control" ID="txtsdate1" Enabled="true" runat="server"
                                            TabIndex="1" placeholder="Select Date"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy hh:mm tt"
                                            TargetControlID="txtsdate1" runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                            </div>
                                <div runat="server" visible="false" class="col-lg-3">
                                     <div class="col-lg-3">
                                        <label>
                                            Supplier</label><asp:CheckBox ID="chksupplier" runat="server" Text="New Supplier"
                                                OnCheckedChanged="chk_chksupplier" AutoPostBack="true" />
                                        <asp:DropDownList ID="ddlsuplier" runat="server" TabIndex="2" CssClass="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtsupplier" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                    </div>
                                     <div class="col-lg-3">
                                        <label>
                                            Address</label>
                                        <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div runat="server" visible="false" class="col-lg-3">
                                    <div class="col-lg-3">
                                        <label>
                                            Mobile No</label>
                                        <asp:TextBox ID="txtmobileno" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                     <div class="col-lg-3">
                                        <label>
                                            City</label>
                                        <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div runat="server" visible="false" class="col-lg-3">
                                     <div class="col-lg-3">
                                        <label>
                                            GST NO</label>
                                        <asp:TextBox ID="txtgstno" runat="server" CssClass="form-control"></asp:TextBox>
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
                                </div>
                                <div runat="server" visible="false" class="col-lg-3">
                                     <div class="col-lg-3">
                                        <label>
                                            Item Load Type</label>
                                        <asp:DropDownList ID="drpitemchnage" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="IngredientName" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="BIngredientName" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                     <div class="col-lg-3">
                                        <label>
                                            Item Load</label>
                                        <asp:DropDownList ID="drpitemload" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Load All Item" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Load Supplier Item Only" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                 <div class="col-lg-3">
                                <asp:DropDownList ID="ddlbank" runat="server" AutoPostBack="true" CssClass="form-control"
                                    Visible="false">
                                </asp:DropDownList>
                                <asp:TextBox CssClass="form-control" ID="txtcheque" placeholder="Enter Bill No" runat="server"
                                    Visible="false"></asp:TextBox>
                            </div>
                        </div>
                        </div>
                    
                    <div class="col-lg-12">
                        <asp:Panel ID="Panel1" runat="server" >
                        <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="gvcustomerorder" runat="server" AutoGenerateColumns="False" OnRowDeleting="grvStudentDetails_RowDeleting" cssClass="table table-striped pos-table"
                                 OnRowDataBound="gvcustomerorder_RowDataBound" padding="0" spacing="0" border="0">
                                <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    Height="30px" Font-Names="arial" Font-Size="Medium" HorizontalAlign="Center" />--%>
                               <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />
                                <RowStyle Height="3px" />--%>
                                <%-- <RowStyle BorderColor="Gray" BorderStyle="Solid" BorderWidth="0.5px" />--%>
                                <Columns>
                                    <asp:TemplateField   HeaderText="S.No" >
                                        <ItemTemplate>
                                            <asp:TextBox Width="25px" class="form-control"  ID="txtsno" runat="server">1</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ingredients" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlDef" CssClass="form-control" runat="server" 
                                                 Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlDef_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Billing Name" Visible="false" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtbillingname"  runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Units" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlunits" Visible="false" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblunits"  runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HSN Code"  >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txthsncode" Width="100px" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock" Visible="true" >
                                        <ItemTemplate>
                                            <asp:Label Width="50px" Style="text-align: center" ID="lblpoqty" Visible="false" runat="server">0</asp:Label>
                                            <asp:Label Width="50px"  ID="lblstock" runat="server">0</asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Primary Unit" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlprimaryunits" Width="200px" Enabled="true" CssClass="form-control"
                                                runat="server" OnSelectedIndexChanged="drpprimary_unit" AutoPostBack="true" >
                                            </asp:DropDownList>
                                            <asp:Label ID="lblprimaryvalue" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubCatID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                        ItemStyle-Height="30px" HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescriptionID" runat="server" CssClass="LabelText"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Qty" >
                                        <ItemTemplate>
                                            <asp:TextBox class="form-control" Width="50px" OnTextChanged="txtdefQty_TextChanged"
                                                AutoPostBack="true" ID="txtQty" runat="server" MaxLength="10">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disc %" Visible="false" >
                                        <ItemTemplate>
                                            <asp:TextBox class="form-control" Width="50px" ID="txtDisCount" OnTextChanged="txtDisCount_TextChanged"
                                                AutoPostBack="true" runat="server" MaxLength="10">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disc.Amnt" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox class="form-control" Width="50px" ID="txtDisCountAmount" OnTextChanged="txtDisCountAmount_TextChanged"
                                                AutoPostBack="true" runat="server" MaxLength="10">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GST%" Visible="false" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" Width="50px" AutoPostBack="true"
                                                OnTextChanged="txtBillNo_TextChanged">0</asp:TextBox>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" Visible="false" >
                                        <ItemTemplate>
                                            <asp:TextBox Width="50px" Style="text-align: right" placeholder="Enter Rate" class="form-control"
                                                ID="txtRate" runat="server" OnTextChanged="txtdefCatID_TextChanged" AutoPostBack="true"
                                                MaxLength="10">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" Visible="false" >
                                        <ItemTemplate>
                                            <asp:TextBox Width="100px" Style="text-align: right" Enabled="false" class="form-control"
                                                ID="txtAmount" runat="server" MaxLength="50">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  Visible="false"  HeaderText="Exp.Date" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtexpireddate" runat="server" Enabled="true" Width="100px">0</asp:TextBox>
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
                                            <asp:TextBox Width="100px"  Enabled="false" class="form-control"
                                                ID="txtpqty" runat="server" MaxLength="50">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Narrations">
                                        <ItemTemplate>
                                            <asp:TextBox Width="200px" height="35px" class="form-control" TextMode="MultiLine"
                                                 ID="txtnarrations" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier"  Visible="false">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddSupplier" class="chzn-select" runat="server" AutoPostBack="true">
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
                                    <asp:TemplateField HeaderText="Add" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="add" runat="server" OnClick="btnnew_Click" cssclass="btn btn-primary pos-btn1" >
                                                <asp:Image ID="img" Width="20px" runat="server" ImageUrl="~/images/edit_add.png" Visible="false" />

				                                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> 
			                       
                                                </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="catid1" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/images/delete.png" />
                                </Columns>
                            </asp:GridView>
                            </div>
                        </asp:Panel>
                        </div>
                        <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-3">
                                <label>
                                    FreightCharge</label>
                                <asp:TextBox ID="txtFreightCharge" runat="server" AutoPostBack="true" OnTextChanged="txtFreightCharge_OnTextChanged"
                                    CssClass="form-control">0</asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                Tax
                                <asp:DropDownList ID="ddltax" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddltax_OnSelectedIndexChanged"
                                    CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Freight Tax</label>
                                <asp:TextBox ID="txtFreightChargeTax" runat="server" Enabled="false"
                                    CssClass="form-control">0</asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    SubTotal</label>
                                <asp:TextBox ID="txtSubTotal" Enabled="false" runat="server" 
                                     CssClass="form-control">0</asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Discount</label>
                                <asp:TextBox ID="txtDiscountAmount" Enabled="false" runat="server" 
                                     CssClass="form-control">0</asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    CGST</label>
                                <asp:TextBox ID="txtcgst" runat="server" CssClass="form-control" Enabled="false"
                                    AutoPostBack="true" Style="text-align: right">0</asp:TextBox></div>
                            <div class="col-lg-3">
                                <label>
                                    SGST</label>
                                <asp:TextBox ID="txtsgst" runat="server" CssClass="form-control" Enabled="false"
                                    AutoPostBack="true" Style="text-align: right">0</asp:TextBox></div>
                            <div class="col-lg-3">
                                <label>
                                    IGST</label>
                                <asp:TextBox ID="txtigst" runat="server" CssClass="form-control" Enabled="false"
                                    AutoPostBack="true" >0</asp:TextBox></div>
                            <div class="col-lg-3">
                                <label>
                                    Total</label>
                                <asp:TextBox ID="txttotal" runat="server" Enabled="false"  CssClass="form-control">0</asp:TextBox></div>
                            <div class="col-lg-3">
                                <label>
                                    Round Off</label>
                                <asp:TextBox ID="txtroundoff" runat="server" Enabled="false"  CssClass="form-control">0</asp:TextBox></div>
                            <div class="col-lg-3">
                                <br />
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-primary pos-btn1" Text="Save" Width="150px"
                                     OnClientClick="SetTarget();" OnClick="btnSave_Click" />
                      
                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg btn-link" Text="Clear"
                                     PostBackUrl="~/Accountsbootstrap/Purchase_invGrid.aspx" />
                                     </div>
                        </div>
                        </div>
                        <div class="row">
                        <table width="100%">
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
