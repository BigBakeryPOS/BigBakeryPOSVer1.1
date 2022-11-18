<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WholeSales.aspx.cs" Inherits="Billing.Accountsbootstrap.WholeSales" %>

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
    <title>Whole Sales </title>
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
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Confirm(myButton) {

            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // disable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "processing...";
            }
            return true;


        }
    </script>
     <style>
        .chzn-single {
            height: 34px !important;
            padding: 4px 0 0 10px !important;
        }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">
    </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label">
    </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false">
    </asp:Label>
    <form runat="server" id="form1" method="post" style="margin-top: 10px">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Whole Sales Invoice</h1>
	    </div>
                    <div class="panel-body">
                                    <div class="row">
                                       
                                            <div class="col-lg-3">
                                                <label>
                                                    Sales Type</label>
                                                <asp:RadioButtonList ID="rbdsalestype" runat="server" RepeatColumns="2" AutoPostBack="true"
                                                    OnSelectedIndexChanged="rbdsalestype_OnSelectedIndexChanged">
                                                    <asp:ListItem Text="Local Sales" Value="1" Selected="true"></asp:ListItem>
                                                    <asp:ListItem Text="Inter-State Sales" Value="2"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                       
                         
                                        <div class="col-lg-3 form-inline">
                                            
                                                <label>
                                                    Bill No</label><br>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator4"
                                                    Text="*" ControlToValidate="txtbillno" ErrorMessage="Please enter Bill NO!" Style="color: Red" />
                                                <asp:Label ID="lblPrefix" runat="server" Font-Bold="true" Font-Size="Larger" Text="BF / "></asp:Label>
                                                <asp:TextBox Width="100px" ID="txtbillno" class="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                <%--  <asp:Label ID="yearss" runat="server" Font-Bold="true" Font-Size="Larger" Text="/2020"></asp:Label>--%>
                                                <asp:Label ID="yearss" runat="server" Font-Bold="true" Font-Size="Larger" Text=" / 21-22"></asp:Label>

                                                
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    TargetControlID="txtbillno" ValidChars="" FilterType="Numbers" />

                                            </div>
                                            <%--<br />--%>
                                        
                                        <div id="Div3" class="form-group" runat="server" visible="false">
                                            <asp:Button ID="btnrefresh" runat="server" Text="Refresh Items" OnClick="btnrefresh_OnClick" />
                                        </div>
                                        <div class="col-lg-3">
                                                <asp:Label runat="server" ID="Label4" Style="font-weight: bold;">Bill Date</asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1"
                                                    Text="*" ControlToValidate="txtdate" Style="color: Red" ErrorMessage="Enter Bill Date"></asp:RequiredFieldValidator><br />
                                                <asp:TextBox CssClass="form-control" ID="txtdate" runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy hh:mm tt"
                                                    TargetControlID="txtdate" runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>

                                            <div class="form-group" runat="server" visible="false">
                                                <label>
                                                    Discount Type</label>
                                                <asp:RadioButtonList ID="rdbtype" runat="server" RepeatColumns="2">
                                                    <%--  <asp:ListItem Text="ItemWise" Value="1" ></asp:ListItem>--%>
                                                    <asp:ListItem Text="OverAll" Value="2" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        
                                        <div class="col-lg-3">
                                            
                                                <asp:Label runat="server" ID="Label155" Style="font-weight: bold">DC.No. </asp:Label>
                                                <asp:TextBox ID="txtdcno" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                    TargetControlID="txtdcno" ValidChars="" FilterType="Numbers" />
                                            
                                        </div>
                                    </div>
                                        <br />
                                        <div class="row">
                                        <div class="col-lg-3">
                                            
                                                <asp:Label runat="server" ID="Label5" Style="font-weight: bold">Order No. </asp:Label>
                                                <asp:TextBox ID="txtorderno" CssClass="form-control" MaxLength="50" runat="server"
                                                    Enabled="false" Text="0"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                                    TargetControlID="txtorderno" ValidChars="" FilterType="Numbers" />
                                            
                                        </div>
                                        <div class="col-lg-3">
                                         
                                                <label>
                                                    Dealer Name</label><br />
                                                <asp:DropDownList runat="server" ID="ddlcustomer"
                                                    CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcustomer_OnSelectedIndexChanged">
                                                </asp:DropDownList>
                                           
                                        </div>
                                        <div class="col-lg-3">
                                           
                                                <label id="Label3" runat="server">
                                                    Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server"  class="form-control" Enabled="false"></asp:TextBox>
                                           
                                        </div>
                                        <div class="col-lg-3">
                                           
                                                <label>
                                                    Payment</label>
                                                <asp:DropDownList ID="ddlPayMode" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            
                                        </div>
                                        </div>
                                        <br />
                                         <div class="row">
                                        <div class="col-lg-3">
                                           
                                                <label id="Label7" runat="server">
                                                    Mobile No</label>
                                                <asp:TextBox ID="txtmbl" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                           
                                        </div>
                                        <div class="col-lg-3">
                                           
                                                <label id="Label1" runat="server">
                                                    Vehicle No.</label>
                                                <asp:TextBox ID="txtVehicleNo" runat="server" class="form-control" Enabled="true"></asp:TextBox>
                                            
                                        </div>
                                        </div>
                               
                    <div class="row">
                       
                        <div class="col-lg-10" style="margin-top: 10px;">
                            <table id="Table11" border="0" class="table table-hover table-striped pos-table1">
                                <tr>
                                    <td style="width: 5%">
                                        <label>
                                            S.No</label><br />
                                        <asp:TextBox ID="txtsno" runat="server" Enabled="false" cssClass="form-control" Style="width: 50px">1</asp:TextBox>
                                    </td>
                                    <td style="width: 20%">
                                        <label>
                                            Item Name</label><br />
                                        <asp:DropDownList runat="server" ID="ddlitem"  CssClass="chzn-select" Style="width: 250px"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 10%">
                                        <label>
                                            Stock</label><br />
                                        <asp:TextBox ID="txtstock" runat="server" Enabled="false" CssClass="form-control">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            TargetControlID="txtstock" FilterType="Numbers, Custom" ValidChars="." />
                                    </td>
                                      <td style="width: 10%">
                                        <label>
                                            MRP</label><br />
                                        <asp:TextBox ID="txtMRP" runat="server" Enabled="false" CssClass="form-control">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                            TargetControlID="txtMRP" FilterType="Numbers, Custom" ValidChars="." />
                                    </td>
                                    <td style="width: 10%">
                                        <label>
                                            Rate</label><br />
                                        <asp:TextBox ID="txtrate" runat="server" CssClass="form-control" Enabled="false">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            TargetControlID="txtrate" ValidChars="." FilterType="Numbers, Custom" />
                                    </td>
                                    <td style="width: 10%">
                                        <label>
                                            Qty</label><br />
                                        <asp:TextBox ID="txtqty" runat="server" CssClass="form-control" OnTextChanged="txtqty_OnTextChanged">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender41" runat="server"
                                            TargetControlID="txtqty" ValidChars="." FilterType="Numbers, Custom" />
                                    </td>
                                    <td style="width: 10%">
                                        <label>
                                            GST%</label><br />
                                        <asp:TextBox ID="txttax" runat="server" CssClass="form-control" Enabled="false">0</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender85" runat="server"
                                            TargetControlID="txttax" ValidChars="." FilterType="Numbers, Custom" />
                                    </td>

                                         <td style="width: 10%">
                                        <label>
                                            Packing Type</label><br />
                                        <asp:DropDownList runat="server" ID="drppacktype" Style="width: 250px" CssClass="chzn-select"
                                            AutoPostBack="true" OnSelectedIndexChanged="drppacktype_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td style="width: 4%">
                                        <br />
                                        <asp:Button ID="btncalc" Text="Add" runat="server" OnClick="btngvadd_Click" cssClass="btn btn-primary pos-btn1" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-lg-1">
                            <div class="form-group">
                                <label id="Label10" runat="server" style="font-size: large;">
                                    Amount</label>
                                <br />
                                <label id="lbldisplay" runat="server" style="font-size: large; color: Blue">
                                    0.00
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-1">
                            <div class="form-group">
                                <label id="Label2" runat="server" style="font-size: large;">
                                    Counts</label>
                                <br />
                                <label id="lbltotalitems" runat="server" style="font-size: large; color: Blue">
                                    0
                                </label>
                            </div>
                        </div>
                    </div>
                <div class="row">
                    <div class="col-lg-10">
                        <div style="height: 230px; overflow: auto; margin-bottom: 10px;">
                            <asp:GridView ID="GridView2" AutoGenerateColumns="False" ShowFooter="false" OnRowDataBound="GridView2_OnRowDataBound"
                                OnRowDeleting="GridView2_RowDeleting" GridLines="None" runat="server"  cssClass="table table-hover table-striped pos-table1">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="1%" ItemStyle-Width="1%">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="hdtype" runat="server" Value='<%# Eval("Type")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ItemStyle-Width="1%" />
                                    <asp:TemplateField HeaderText=" Items " HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="drpItem" runat="server" Height="26px" Width="200px" AutoPostBack="true"
                                                Enabled="false" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtStock" Text="0" Width="80px" runat="server" Height="26px" AutoPostBack="true"
                                                Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Qty" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQty" Text='<%# Eval("OQty")%>' Width="85px" runat="server" Height="26px"
                                                AutoPostBack="true" Enabled="false"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender312" runat="server"
                                                TargetControlID="txtQty" ValidChars="." FilterType="Numbers, Custom" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Billed Qty" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBQty" Text='<%# Eval("BQty")%>' Width="85px" runat="server" Height="26px"
                                                Enabled="false"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                TargetControlID="txtBQty" ValidChars="." FilterType="Numbers, Custom" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Qty" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSQty" Text='<%# Eval("SQty")%>' Width="85px" runat="server" Height="26px"
                                                OnTextChanged="txtSQty_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender312s" runat="server"
                                                TargetControlID="txtSQty" ValidChars="." FilterType="Numbers, Custom" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                       <asp:TemplateField HeaderText="PackType " HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="drpPackType" runat="server" Height="26px" Width="200px" AutoPostBack="true"
                                                Enabled="false" AppendDataBoundItems="true">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MRP" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMRP" Text='<%# Eval("MRP")%>' Width="80px" runat="server" Height="26px" AutoPostBack="true"
                                                Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Rate" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRate" Text='<%# Eval("Rate")%>' Width="70px" runat="server" Enabled="false"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtRate"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GST" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTax" Text='<%# Eval("Tax")%>' Enabled="false" Width="50px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TaxAmount" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTaxamount" Text='<%# Eval("TaxAmount")%>' Enabled="false" Width="85px"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount" Text='<%# Eval("Amount")%>' Width="70px" runat="server"
                                                Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="col-lg-12 row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label id="Label6" runat="server">
                                    Delivery Charge</label>
                                <asp:TextBox ID="txtDeliverCharge" runat="server" AutoPostBack="true" OnTextChanged="txttdiscper_OnTextChanged" cssClass="form-control">0</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    TargetControlID="txtDeliverCharge" FilterType="Numbers,Custom" ValidChars="." />
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    Disc %</label><br />
                                <asp:TextBox ID="txttdiscper" runat="server" Style="text-align: right" AutoPostBack="true"
                                    OnTextChanged="txttdiscper_OnTextChanged" cssClass="form-control">0</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                    TargetControlID="txttdiscper" FilterType="Numbers, Custom" ValidChars="." />
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label id="Label9" runat="server">
                                    Disc.Amt</label><br />
                                <asp:TextBox ID="txtdiscamt" runat="server" Enabled="false" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    Sub.Total</label><br />
                                <asp:TextBox ID="txtgrandamount" runat="server" Enabled="false" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div id="Div2" class="form-group" runat="server" visible="false">
                                <label>
                                    Delivery
                                </label>
                                <asp:TextBox ID="txtDlCharge" runat="server" Enabled="false"  cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div id="Div1" class="form-group" runat="server" visible="false">
                                <label>
                                    Disc amt</label>
                                <asp:TextBox ID="txttdiscamt" runat="server" Enabled="false" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                    TargetControlID="txttdiscamt" FilterType="Numbers, Custom" ValidChars="." />
                            </div>
                        </div>
                    </div>
                <div class="col-lg-12 row">
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    CGST</label><br />
                                <asp:TextBox ID="txtcgst" runat="server" Enabled="false" AutoPostBack="true" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    SGST</label><br />
                                <asp:TextBox ID="txtsgst" runat="server" Enabled="false" AutoPostBack="true" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    IGST</label><br />
                                <asp:TextBox ID="txtigst" runat="server" Enabled="false" AutoPostBack="true" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    Total GST
                                </label>
                                <br />
                                <asp:TextBox ID="txtTaxamt" runat="server" Enabled="false" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <label>
                                    Grand Total</label><br />
                                <asp:TextBox ID="txtgrandtotal" runat="server" Enabled="false" Style="text-align: right" cssClass="form-control">0</asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                        
                            <div class="form-group">
                                <label>
                                    Narrations</label>
                                <asp:TextBox ID="txtNarrations" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                         
                         
                    </div>
                    <div class="col-lg-12">
                        <asp:Button ID="btnadd" Text="Save" runat="server" class="btn btn-primary pos-btn1" ValidationGroup="val1" 
                                Width="110px" OnClick="btnadd_Click" />
                         <asp:Button ID="btnExit" Text="Exit" runat="server" class="btn btn-link" Width="110px" 
                                PostBackUrl="~/Accountsbootstrap/WholeSalesGrid.aspx" />
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
   
    <asp:TextBox ID="stockoption" runat="server" class="form-control" Visible="false" Enabled="true"></asp:TextBox>
                                            
    </form>
</body>
</html>
