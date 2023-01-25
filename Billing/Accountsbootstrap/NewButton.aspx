<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewButton.aspx.cs" EnableEventValidation="true"
    Inherits="Billing.Accountsbootstrap.NewButton" %>

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
    <title>POS Sales </title>

    <link href="Style/chosen.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function DisableButton() {
            document.getElementById("<%=btnPrint .ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;
    </script>
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }

        function SelectGiven() {
            alert('Enter Customer Name!');
        }

        function Mobile() {
            alert('Enter Customer Mobile No!');
        }
        function Attender() {
            alert('Select Attender.');
        }



    </script>

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
    <style>
        .autocomplete_completionListElement {
            list-style: none;
            cursor: pointer;
            padding: 0;
            margin: 0;
            box-shadow: #37609180 0 5px 20px;
            max-height: 400px;
            overflow: auto;
        }

            .autocomplete_completionListElement li {
                padding: 10px !important;
            }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
        <div class="clearfix"></div>
        <div class="container-fluid">
            <div class="row panel panel-custom1">
                <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" EnableViewState="true">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lbltempsalesid" Visible="false"></asp:Label>
                        <asp:Label ID="lblmargin" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblmargintax" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblpaygate" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblpaymodesic" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblordercount" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblordertype" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblqtytype" Visible="false" runat="server" Text="Y"></asp:Label>
                        <asp:Label ID="lblattednercheck" Visible="false" runat="server" Text="N"></asp:Label>
                        <asp:CheckBox ID="chkkot" runat="server" Visible="false" Checked="false" CssClass="form-control"></asp:CheckBox>
                        <asp:Label ID="lblprintcount" runat="server" Text="2" Visible="false"></asp:Label>
                        <asp:Label ID="lblprintlayout" runat="server" Text="2" Visible="false" ></asp:Label>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>


                        <div class="col-sm-6">
                            <div class="row">

                                <div class="col-sm-3 pos-bill-left">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BorderWidth="0px" CssClass="table table-condensed table-borderless"
                                        ShowHeader="false" OnRowCommand="GridView1_RowCommand">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="Button1" runat="server"
                                                        Text='<%#Eval("PrintCategory")%>' CommandArgument='<%#Eval("CategoryID") %>'
                                                        CssClass="btn btn-link btn-main-cat" OnClick="Button1_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-sm-9 pos-bill-middle">

                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table width="100%" style="margin-top: 8px;">
                                                <tr style="color: steelblue;">
                                                    <td valign="top" style="width: 5%">
                                                        <label>
                                                            #</label>
                                                        <asp:TextBox ID="txtmanualslno" runat="server" Width="80%" CssClass="form-control" Text="1"></asp:TextBox>
                                                    </td>
                                                    <td valign="top" style="width: 30%">
                                                        <label>
                                                            Select Item</label><br />
                                                        <div runat="server" visible="false" id="divdrop">
                                                            <asp:DropDownList ID="drpitemsearch" runat="server" CssClass="chzn-select" Width="368px">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtbrcode" runat="server" CssClass="form-control" Width="368px"
                                                                placeholder="For Weight Machine Barcode Scan" OnTextChanged="barchnaged_text"
                                                                AutoPostBack="true"></asp:TextBox>
                                                        </div>
                                                        <div runat="server" visible="false" id="divscript">
                                                            <asp:UpdatePanel ID="upcus" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtCusName1" runat="server" Font-Bold="true" Font-Size="Larger" Style="width: 350px; text-transform: uppercase;"
                                                                        Height="33px" placeholder="Enter Item Name" AutoPostBack="true" OnTextChanged="LedgerIdbinding"></asp:TextBox>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server"
                                                                        CompletionListCssClass="autocomplete_completionListElement" DelimiterCharacters=""
                                                                        Enabled="True" ServiceMethod="GetListofCustomer" MinimumPrefixLength="1" EnableCaching="true"
                                                                        ServicePath="" TargetControlID="txtCusName1">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                    <%--<asp:Label ID="NlblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                            <asp:HiddenField ID="NhideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                            <asp:HiddenField ID="NhideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                            <asp:HiddenField ID="NhideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                            <asp:HiddenField ID="NhdRate" runat="server" Value='<%#Eval("Rate") %>' />
                                                            <asp:HiddenField ID="NhdGST" runat="server" Value='<%#Eval("GST") %>' />
                                                            <asp:Label ID="NlblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                            <asp:Label ID="Nlblrate" runat="server" Text='<%#Eval("MRP") %>'></asp:Label>
                                                            <asp:Label ID="Nlbqty" runat="server" Width="50px" Text='<%#Eval("Qty") %>'></asp:Label>
                                                            <asp:Label ID="Nlblom" runat="server" Width="50px" Text='<%#Eval("UOM") %>'></asp:Label>--%>
                                                                    <asp:Label ID="Nlblstockid" runat="server" Width="50px" Text='<%#Eval("stockid") %>'></asp:Label>
                                                                    <asp:Label ID="Nlblcattype" runat="server" Width="50px" Text='<%#Eval("cattype") %>'></asp:Label>
                                                                    <%--<asp:Label ID="NlblAvailable_QTY" runat="server" Width="50px" Text='<%#Eval("Available_QTY") %>'></asp:Label>
                                                            <asp:Label ID="Nlblcomboo" runat="server" Width="50px" Text='<%#Eval("comboo") %>'></asp:Label>
                                                                    --%>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="txtCusName1" EventName="TextChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </td>
                                                    <td valign="top" style="width: 15%">
                                                        <label>
                                                            Qty</label>
                                                        <asp:TextBox ID="txtmanualqty" runat="server" CssClass="form-control" OnTextChanged="Qty_chnaged"
                                                            AutoPostBack="true"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                            FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtmanualqty" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="margin-top: 10px;">
                                                <tr>
                                                    <td align="left" valign="top" style="width: 15%">
                                                        <asp:GridView ID="GridView2" runat="server" Width="100%" ShowHeader="false" GridLines="None"
                                                            BorderColor="White" AutoGenerateColumns="false"
                                                            OnRowDataBound="GridView2_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="Button2" Font-Bold="true" runat="server"
                                                                            Text='<%#Eval("Definition")%>' CommandArgument='<%#Eval("CategoryUserID") +","+ Eval("cattype")%>'
                                                                            CssClass="btn btn-link btn-bill-item"
                                                                            OnClick="Button2_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td valign="top" style="width: 15%">
                                                        <asp:GridView ID="GridView3" runat="server" Width="100%" ShowHeader="false" GridLines="None"
                                                            BorderColor="White" AutoGenerateColumns="false"
                                                            OnRowDataBound="GridView3_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-link btn-bill-item" Font-Bold="true"
                                                                            Text='<%#Eval("Definition")%>' CommandArgument='<%#Eval("CategoryUserID")+","+ Eval("cattype")%>'
                                                                            OnClick="Button2_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td valign="top" style="width: 15%">
                                                        <asp:GridView ID="GridView4" OnRowDataBound="GridView4_RowDataBound" GridLines="None"
                                                            runat="server" Width="100%" ShowHeader="false" BorderColor="White" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Wrap="true">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-link btn-bill-item" Font-Bold="true"
                                                                            Text='<%#Eval("Definition")%>' CommandArgument='<%#Eval("CategoryUserID") +","+ Eval("cattype")%>'
                                                                            OnClick="Button2_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>


                            </div>
                        </div>
                        <div class="col-sm-6 pos-bill-right">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table class="table table-condensed">
                                        <tr>
                                            <td>
                                                <label>
                                                    Bill/Kot No</label>
                                                <asp:TextBox ID="txtBillNo" CssClass="form-control" runat="server" Visible="false"
                                                    Enabled="false"></asp:TextBox>
                                                <asp:TextBox ID="txtfullbillno" CssClass="form-control" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                                                <asp:TextBox ID="txtbillcode" CssClass="form-control" runat="server" Enabled="false"
                                                    Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txtdailybillno" CssClass="form-control" runat="server" Enabled="false"
                                                    Visible="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <label>
                                                    Bill Date</label>
                                                <asp:TextBox ID="txtBillDate" CssClass="form-control" Text="-Select Date--" Enabled="false"
                                                    runat="server"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBillDate"
                                                    PopupButtonID="txtdate1" EnabledOnClient="true" runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <label>
                                                    Sales Type</label>
                                                <asp:DropDownList ID="drpsalestype" Width="100%" runat="server" OnSelectedIndexChanged="drpsalestype_selectedindex"
                                                    AutoPostBack="true" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblisnormal" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblisinclusiverate" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblattenderid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblattenderpassword" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lbldiscid" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <label>
                                                    Payment Mode</label>
                                                <asp:DropDownList Width="100%" ID="drpPayment" runat="server" OnSelectedIndexChanged="drppayment_selectedindex"
                                                    AutoPostBack="true" CssClass="form-control">
                                                    <%-- <asp:ListItem Text="Cash" Value="1" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Customer Credit" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Compliment" Value="3" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Card" Value="4" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Staff Credit" Value="5" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="BBKulam" Value="7" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="ByePass" Value="8" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="KKNagar" Value="9" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="NP" Value="10" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Bank" Value="11" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Staff Consumption" Value="12" Enabled="true"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label>
                                                    Mobile #</label>
                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    MaxLength="10" placeholder="Mobile No" OnTextChanged="txtmobile_TextChanged">    </asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtmobile" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Customer Name</label>
                                                <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                                            </td>
                                            <td>
                                                <label>
                                                    Attender Name</label>
                                                <asp:DropDownList ID="drpattendername" runat="server" MaxLength="10" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label>
                                                    Online Amount</label>
                                                <asp:TextBox ID="txtonlineamount" runat="server" CssClass="form-control" Enabled="false"
                                                    OnTextChanged="onlineamount_chnaged" AutoPostBack="true">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtonlineamount" />
                                            </td>
                                            <td>
                                                <label>
                                                    GST/Tax NO</label>
                                                <asp:TextBox ID="txtgstno" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td runat="server" id="chkgivenby" visible="false">
                                                <label>
                                                    Given By</label>
                                                <asp:TextBox ID="txtgiven" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td runat="server" id="Chkbills" visible="false">
                                                <label>
                                                    Order No</label>
                                                <asp:TextBox ID="txtorderno" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    FilterType="LowercaseLetters,uppercaseletters,Numbers" ValidChars="" TargetControlID="txtorderno" />
                                            </td>
                                            <td runat="server" visible="false">
                                                <label>
                                                    Approved</label>
                                                <asp:DropDownList ID="ddlApproved1" CssClass="form-control" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlApproved_OnSelectedIndexChanged">
                                                    <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="Mr Anand " Text="Mr Anand"></asp:ListItem>
                                                    <asp:ListItem Value="Mr Navaneethan " Selected="True" Text="Mr Navaneethan"></asp:ListItem>
                                                    <asp:ListItem Value="Mr Sudarshan " Text="Mr Sudarshan"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                        <tr style="display: none;">
                                            <td>
                                                <label>
                                                    Attender Name</label>
                                                <asp:DropDownList ID="ddattender" runat="server" MaxLength="10" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label>
                                                    Billed by</label>
                                                <asp:TextBox ID="txtbilled" runat="server" CssClass="form-control" AutoPostBack="true"
                                                    MaxLength="10" placeholder="Billed by">    </asp:TextBox>
                                            </td>
                                            <td>
                                                <label>
                                                    Cashier Name</label>
                                                <asp:DropDownList ID="ddlCashier" runat="server" MaxLength="10" CssClass="form-control">
                                                </asp:DropDownList>
                                                <label id="lblTax" runat="server" visible="false">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 100%; height: 300px; overflow: auto">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="gvlist" runat="server" CssClass="table table-condensed table-hover table-pos-bill" AutoGenerateColumns="false" Width="100%"
                                                    HeaderStyle-BackColor="#d8d8d8" HeaderStyle-ForeColor="Black" OnRowCommand="gvlist_RowCommand" BorderWidth="0"
                                                    OnRowDataBound="gvlist_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Cat.Type" ItemStyle-Width="10">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcattype" runat="server" Text='<%#Eval("cattype") %>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10">
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />--%>
                                                                <asp:Label ID="lblRowNumber" Text='<%#Convert.ToInt32(Eval("Sno")) %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:Label ID="categoryid" runat="server" Text='<%#Eval("categoryid") %>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblcombo" runat="server" Text='<%#Eval("combo") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:Label ID="CategoryUserid" runat="server" Text='<%#Eval("CategoryUserid") %>'
                                                                    Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:Label ID="StockID" runat="server" Text='<%#Eval("StockID") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Item" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="Definition" runat="server" Width="100%" Text='<%#Eval("Definition") %>'
                                                                    Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Stock" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Available_QTY" runat="server" Text='<%#Eval("Available_QTY") %>' Visible="true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Qty" ItemStyle-Width="10%" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblitemdiscount" runat="server" Text='<%#Eval("Disamt") %>' Style="display: none">0</asp:Label>
                                                                <asp:Label ID="txttax" Visible="false" runat="server" Text='<%#Eval("TAX") %>'></asp:Label>
                                                                <asp:TextBox ID="txtQty" AutoPostBack="true" Width="100%" Enabled="true" OnTextChanged="txtqty_chnaged"
                                                                    Text='<%#Eval("Qty") %>' runat="server"></asp:TextBox>
                                                                <asp:TextBox ID="txtshwqty" Visible="false" Width="100%" Enabled="false" Text='<%#Eval("ShwQty") %>'
                                                                    runat="server"></asp:TextBox>
                                                                <asp:TextBox ID="txtcqty" Visible="false" Width="100%" Enabled="false" Text='<%#Eval("CQty") %>'
                                                                    runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="12%" HeaderText="Rate" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmrp" runat="server" Text='<%#Eval("mrp") %>' Visible="true"></asp:Label>
                                                                <asp:TextBox ID="Rate" Width="100%" Text='<%#Eval("Rate") %>' Visible="false" Enabled="false"
                                                                    runat="server"></asp:TextBox>
                                                                <asp:TextBox ID="txtrate" Visible="false" Width="100%" Text='<%#Eval("OriRate") %>'
                                                                    Enabled="false" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Amount" ItemStyle-Font-Size="Smaller">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="Amount" Width="100%" Text='<%#Eval("Amount") %>' Visible="false"
                                                                    Style="text-align: right; font-weight: bold;" runat="server" Enabled="false"></asp:TextBox>
                                                                <asp:TextBox ID="mrpamount" Width="100%" Text='<%#Eval("mrpAmount") %>' Style="text-align: right; font-weight: bold;"
                                                                    runat="server" Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgminus" runat="server" ToolTip="Less Item" CommandName="minus"
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Height="21px" Width="42px"
                                                                    ImageUrl="~/images/Minusnew.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgdel" runat="server" ToolTip="Cancel Item" CommandName="remove"
                                                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Height="25px" Width="25px"
                                                                    ImageUrl="~/images/cancel-circle.png" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:GridView ID="gvlst" runat="server" AutoGenerateColumns="false" Visible="true"
                                                    Width="100%" GridLines="Both" HeaderStyle-BackColor="Black">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Cat.Type" ItemStyle-Width="10">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbbCategoryID" runat="server" Text='<%#Eval("CategoryID") %>' Visible="true"></asp:Label>
                                                                <asp:Label ID="lbbCategoryUserID" runat="server" Text='<%#Eval("CategoryUserID") %>'
                                                                    Visible="true"></asp:Label>
                                                                <asp:Label ID="lbbQty" runat="server" Text='<%#Eval("Sqty","{0:n}") %>' Visible="true"></asp:Label>
                                                                <asp:Label ID="lblaqty" runat="server" Text='<%#Eval("AQty","{0:n}") %>' Visible="true"></asp:Label>
                                                                <%--<asp:Label ID="lblcombocount" runat="server" Text='<%#Eval("combocount","{0:n}") %>' Visible="true"></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="row pos-total">
                                        <div class="col-md-6">
                                            <label style="color: #000;">
                                                Total Qty:
                                            </label>
                                            <asp:TextBox ID="txttotqty" Visible="true" Style="width: 100px; background: transparent; border: 0;"
                                                Enabled="false" Font-Size="20px" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 text-right">
                                            <label style="color: #000;">
                                                Amount:
                                            </label>
                                            <label id="lbldisplay" runat="server">
                                            </label>
                                            <asp:Label ID="lblcurrency" runat="server"></asp:Label>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" style="padding: 5px 20px; background-color: #f2f2f2;">

                                            <asp:Button ID="btnPrint" runat="server" CssClass="btn pos-btn1 btn-sm"
                                                UseSubmitBehavior="false" OnClientClick="this.disabled=true;" OnClick="btnPrint_Click"
                                                Text="Save & Print" />

                                            <asp:Button ID="btnsve" runat="server" CssClass="btn pos-btn1 btn-sm" Width="80px" UseSubmitBehavior="false"
                                                OnClientClick="this.disabled=true;" OnClick="btnsave_Click" Text="Save" />

                                            <asp:Button ID="btnkot" runat="server" CssClass="btn pos-btn1 btn-sm" Width="100px" UseSubmitBehavior="false"
                                                OnClientClick="this.disabled=true;" OnClick="btnkot_Click" Text="Print & Kot" />




                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger btn-sm" Width="80px"
                                                Text="Cancel" OnClick="btnCancel_Click" />

                                            <asp:Button ID="Button5" runat="server" CssClass="btn btn-warning btn-sm"
                                                Visible="true" Text="Hold Bill" OnClick="btnhold_check" />

                                            <asp:Button ID="Button4" runat="server" CssClass="btn pos-btn1 btn-sm" Text="Smry.Bills" Visible="false"
                                                PostBackUrl="~/Accountsbootstrap/Home_Page.aspx" />

                                            <asp:Button ID="btnView" runat="server" CssClass="btn btn-info btn-sm" OnClick="btnView_Onclick"
                                                Text="Tax Detail View" />

                                            <asp:Button ID="btnTaxClose" runat="server" CssClass="btn btn-info btn-sm" Visible="false"
                                                Width="120px" OnClick="btnTaxClose_Onclick" Text="Tax Detail Close" />

                                            <asp:Button ID="btnReset" runat="server" CssClass="btn btn-link btn-sm"
                                                Text="Reset" OnClick="btnReset_Click" />

                                        </div>
                                    </div>
                                    <table width="100%" align="right" id="TaxView" runat="server" class="table table-condensed"
                                        visible="false" style="background-color: White; color: steelblue;">
                                        <tr id="trsub" runat="server">
                                            <td width="50px">
                                                <label>
                                                    Item - Total</label>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                <asp:Label ID="lbloritot" Visible="false" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr17" runat="server">
                                            <td width="50px">
                                                <label id="IDCgst" runat="server">
                                                    CGST:</label>
                                                <asp:Label ID="lblcgst" runat="server" Width="50px">0</asp:Label>
                                            </td>
                                            <td width="50px">
                                                <label id="IDSgst" runat="server">
                                                    SGST:</label>
                                                <asp:Label ID="lblsgst" runat="server" Width="50px">0</asp:Label>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Tax</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtTax" runat="server" Width="50px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr18" runat="server">
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="30px"></td>
                                        </tr>
                                        <tr id="tr19" runat="server">
                                            <td width="50px">Disc.Value
                                            </td>
                                            <td width="50px">
                                                <asp:TextBox ID="txtDiscount" Visible="true" Enabled="false" runat="server" AutoPostBack="true"
                                                    Width="50px" OnTextChanged="txtDiscount_TextChanged">0</asp:TextBox>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    SubTotal</label>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lblsubttl" runat="server" Width="50px">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trdis" runat="server">
                                            <td colspan="2" width="70px">
                                                <asp:Label ID="lblNbilltype" runat="server" Visible="false" Text="'1'"></asp:Label>
                                                <asp:Label ID="lbldisctype" runat="server" Visible="false" Text="'2'"></asp:Label>
                                                <asp:DropDownList ID="attednertype" OnSelectedIndexChanged="attednerchk" AutoPostBack="true"
                                                    runat="server" Enabled="false">
                                                </asp:DropDownList>
                                                <label>
                                                    Disc.Chk</label>
                                                <asp:Label ID="isdiscchk" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="isdiscchkwithbill" runat="server" Visible="false"></asp:Label>
                                                <asp:CheckBox ID="chkdisc" runat="server" OnCheckedChanged="disc_checkedchanged"
                                                    AutoPostBack="true" />
                                                <asp:TextBox ID="txtdiscotp" runat="server" placeholder="Enter OTP" Enabled="false"
                                                    TextMode="Password" Width="95px" OnTextChanged="otp_chnaged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Disc %</label>
                                                <asp:DropDownList ID="drpdischk" runat="server" CssClass="form-control" OnSelectedIndexChanged="disc_selectedIndex"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lbldisco" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tradv" runat="server" style="display: none">
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="50px">
                                                <label>
                                                    Advance</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtAdvance" runat="server" AutoPostBack="true" Width="50px" OnTextChanged="txtAdvance_TextChanged">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="trTax" runat="server" visible="true">
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="30px"></td>
                                        </tr>
                                        <tr id="tr20" runat="server" visible="true">
                                            <td width="50px"></td>
                                            <td width="50px">
                                                <label>
                                                    Disc.Appl. Above</label>
                                                <asp:Label ID="lblmaxdiscount" Font-Bold="true" Font-Size="Larger" ForeColor="Red"
                                                    Text="0" Visible="true" runat="server"></asp:Label>
                                            </td>
                                            <td width="50px">Round Off:
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lblRound" runat="server">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trTot" runat="server">
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="50px">
                                                <label>
                                                    Total</label>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lblGrandTotal" runat="server" Width="50px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr15" runat="server" style="display: none">
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="50px">
                                                <label>
                                                    Cash Received</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtReceived" runat="server" AutoPostBack="true" AccessKey="c" OnTextChanged="txtReceived_TextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr16" runat="server" visible="false">
                                            <td width="50px"></td>
                                            <td width="50px"></td>
                                            <td width="50px">
                                                <label>
                                                    Balance</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtBal" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" class="hidden" style="background-color: White;"
                                        id="tblBill" runat="server">
                                        <tr style="background-color: #428bca; color: White">
                                            <th width="100px">Item
                                            </th>
                                            <th width="50px">Stock
                                            </th>
                                            <th width="50px">Qty
                                            </th>
                                            <th width="50px">Rate
                                            </th>
                                            <th width="30px">Amount
                                            </th>
                                            <th width="20px">Change
                                            </th>
                                        </tr>
                                        <tbody>
                                            <tr id="tr" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID1" runat="server"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID1" runat="server"></asp:Label>
                                                </td>
                                                <td id="td1" runat="server" width="20px">
                                                    <asp:Label ID="lblItem1" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty1" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty1" runat="server" AutoPostBack="true" OnTextChanged="txtQty1_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate1" runat="server"></asp:Label>
                                                    <asp:Label ID="lbltaxam1" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount1" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="btnmin" runat="server" OnClick="btnmin_Click">
                                                        <asp:Image ID="imgmin" runat="server" Width="35px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="btncal" runat="server" OnClick="btncal_Click">
                                                        <asp:Image ID="img1" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr id="tr1" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID2" runat="server"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID2" runat="server"></asp:Label>
                                                </td>
                                                <td id="td2" runat="server" width="100px">
                                                    <asp:Label ID="lblItem2" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty2" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty2" runat="server" AutoPostBack="true" OnTextChanged="txtQty2_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate2" runat="server"></asp:Label><asp:Label ID="lbltaxam2" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount2" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">
                                                        <asp:Image ID="Image10" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax1" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr2" runat="server">
                                                <td visible="false" width="20" class="style1">
                                                    <asp:Label ID="lblCatID3" runat="server"></asp:Label>
                                                </td>
                                                <td visible="false" width="20" class="style1">
                                                    <asp:Label ID="lblItemID3" runat="server"></asp:Label>
                                                </td>
                                                <td id="td3" runat="server" width="100px" class="style1">
                                                    <asp:Label ID="lblItem3" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px" class="style1">
                                                    <asp:Label ID="lblAQty3" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px" class="style1">
                                                    <asp:TextBox ID="txtQty3" runat="server" AutoPostBack="true" OnTextChanged="txtQty3_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px" class="style1">
                                                    <asp:Label ID="lblRate3" runat="server"></asp:Label><asp:Label ID="lbltaxam3" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px" class="style1">
                                                    <asp:Label ID="lblAmount3" runat="server"></asp:Label>
                                                </td>
                                                <td class="style1">
                                                    <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click">
                                                        <asp:Image ID="Image11" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax2" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr3" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID4" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID4" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td4" runat="server" width="100px">
                                                    <asp:Label ID="lblItem4" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty4" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty4" runat="server" AutoPostBack="true" OnTextChanged="txtQty4_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate4" runat="server"></asp:Label><asp:Label ID="lbltaxam4" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount4" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click">
                                                        <asp:Image ID="Image12" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax3" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr4" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID5" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID5" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td5" runat="server" width="100px">
                                                    <asp:Label ID="lblItem5" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty5" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty5" runat="server" AutoPostBack="true" OnTextChanged="txtQty5_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate5" runat="server"></asp:Label><asp:Label ID="lbltaxam5" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount5" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButton13_Click">
                                                        <asp:Image ID="Image13" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">
                                                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax4" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr5" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID6" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID6" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td6" runat="server" width="100px">
                                                    <asp:Label ID="lblItem6" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty6" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty6" runat="server" AutoPostBack="true" OnTextChanged="txtQty6_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate6" runat="server"></asp:Label>
                                                    <asp:Label ID="lbltaxam6" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount6" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton14_Click">
                                                        <asp:Image ID="Image14" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax5" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr6" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID7" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID7" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td7" runat="server" width="100px">
                                                    <asp:Label ID="lblItem7" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty7" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty7" runat="server" AutoPostBack="true" OnTextChanged="txtQty7_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate7" runat="server"></asp:Label><asp:Label ID="lbltaxam7" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount7" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButton15_Click">
                                                        <asp:Image ID="Image15" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax6" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr7" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID8" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID8" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td8" runat="server" width="100px">
                                                    <asp:Label ID="lblItem8" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty8" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty8" runat="server" AutoPostBack="true" OnTextChanged="txtQty8_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate8" runat="server"></asp:Label><asp:Label ID="lbltaxam8" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount8" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LinkButton16_Click">
                                                        <asp:Image ID="Image16" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">
                                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax7" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr8" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID9" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID9" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td9" runat="server" width="100px">
                                                    <asp:Label ID="lblItem9" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty9" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty9" runat="server" AutoPostBack="true" OnTextChanged="txtQty9_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate9" runat="server"></asp:Label><asp:Label ID="lbltaxam9" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount9" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton17" runat="server" OnClick="LinkButton17_Click">
                                                        <asp:Image ID="Image17" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">
                                                        <asp:Image ID="Image8" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax8" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr9" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID10" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID10" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td10" runat="server" width="100px">
                                                    <asp:Label ID="lblItem10" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty10" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty10" runat="server" AutoPostBack="true" OnTextChanged="txtQty10_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate10" runat="server"></asp:Label><asp:Label ID="lbltaxam10" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount10" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton18" runat="server" OnClick="LinkButton18_Click">
                                                        <asp:Image ID="Image18" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">
                                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax9" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr10" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID11" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID11" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td11" runat="server" width="100px">
                                                    <asp:Label ID="lblItem11" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty11" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty11" runat="server" AutoPostBack="true" OnTextChanged="txtQty11_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate11" runat="server"></asp:Label><asp:Label ID="lbltaxam11" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount11" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton19" runat="server" OnClick="LinkButton19_Click">
                                                        <asp:Image ID="Image19" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton20" runat="server" OnClick="LinkButton20_Click">
                                                        <asp:Image ID="Image20" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax10" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr11" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID12" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID12" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td12" runat="server" width="100px">
                                                    <asp:Label ID="lblItem12" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty12" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty12" runat="server" AutoPostBack="true" OnTextChanged="txtQty12_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate12" runat="server"></asp:Label><asp:Label ID="lbltaxam12" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount12" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton21" runat="server" OnClick="LinkButton21_Click">
                                                        <asp:Image ID="Image21" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton22" runat="server" OnClick="LinkButton22_Click">
                                                        <asp:Image ID="Image22" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax11" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr12" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID13" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID13" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td13" runat="server" width="100px">
                                                    <asp:Label ID="lblItem13" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty13" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty13" runat="server" AutoPostBack="true" OnTextChanged="txtQty13_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate13" runat="server"></asp:Label><asp:Label ID="lbltaxam13" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount13" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton23" runat="server" OnClick="LinkButton23_Click">
                                                        <asp:Image ID="Image23" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton24" runat="server" OnClick="LinkButton24_Click">
                                                        <asp:Image ID="Image24" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax12" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr13" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID14" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID14" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td14" runat="server" width="100px">
                                                    <asp:Label ID="lblItem14" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty14" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty14" runat="server" AutoPostBack="true" OnTextChanged="txtQty14_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate14" runat="server"></asp:Label><asp:Label ID="lbltaxam14" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount14" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButton25_Click">
                                                        <asp:Image ID="Image25" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton26" runat="server" OnClick="LinkButton26_Click">
                                                        <asp:Image ID="Image26" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax13" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="tr14" runat="server">
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblCatID15" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td visible="false" width="20">
                                                    <asp:Label ID="lblItemID15" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td id="td15" runat="server" width="100px">
                                                    <asp:Label ID="lblItem15" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblAQty15" runat="server"></asp:Label>
                                                </td>
                                                <td width="50px">
                                                    <asp:TextBox ID="txtQty15" runat="server" AutoPostBack="true" OnTextChanged="txtQty15_TextChanged"
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td width="50px">
                                                    <asp:Label ID="lblRate15" runat="server"></asp:Label><asp:Label ID="lbltaxam15" runat="server"
                                                        Visible="false"></asp:Label>
                                                </td>
                                                <td width="30px">
                                                    <asp:Label ID="lblAmount15" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton27_Click">
                                                        <asp:Image ID="Image27" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="LinkButton28" runat="server" OnClick="LinkButton28_Click">
                                                        <asp:Image ID="Image28" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                            Height="20px" />
                                                    </asp:LinkButton>
                                                    <label id="lblTax14" runat="server" visible="false">
                                                    </label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table>

                                        <tr>
                                            <td>
                                                <label>Delivery Address</label>
                                                <asp:CheckBox ID="chkdelivery" runat="server" OnCheckedChanged="Delivery_checked" AutoPostBack="true" />
                                                <br />
                                                <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td valign="top">
                                                <label>
                                                    Hold Bill's</label>
                                                <asp:DataList ID="Holdbill" runat="server" CssClass="SlidingBox"
                                                    ScrollBars="auto" RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Table"
                                                    Width="100%">
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button1" runat="server" Font-Bold="true"
                                                            Text='<%#Eval("BillNo")+"-"+ Eval("SalesTypeOrderNo")+"-"+ Eval("Attendername")%>'
                                                            CommandArgument='<%#Eval("TempSalesID") %>' CssClass="btn btn-warning btn-sm" ForeColor="White"
                                                            OnClick="Button1hold_Click" />

                                                        <asp:ImageButton ID="btndelete" runat="server" Font-Bold="true" Height="24px" Width="24px"
                                                            CommandArgument='<%#Eval("TempSalesID") %>' ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png"
                                                            OnClick="btncncl_click" />
                                                        <asp:Image ID="dlt" runat="server" ImageUrl="~/images/cancel-circle.png" Visible="false" />
                                                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel.png"
                                                            Visible="false" />
                                                        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                            CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                            PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                            TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>


                        <script src="Scripts/jquery.min.js" type="text/javascript"></script>
                        <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script src="Scripts/jquery.min.js" type="text/javascript"></script>
                        <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script type="text/javascript">                    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif"
                                AlternateText="Loading  Please wait..." ToolTip="Loading  Please wait..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>

        </div>

        <asp:Panel Width="30%" class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none; background: #fffbd6"
            runat="server">
            <div class="popup_Container">
                <div class="popup_Titlebar" id="PopupHeader">
                    <div align="center" style="color: Red" class="TitlebarLeft">
                        Warning Message!!!
                    </div>
                    <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                    </div>
                </div>
                <div align="center" style="color: Red" class="popup_Body">
                    <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Hold No"></asp:TextBox>
                    <asp:DropDownList ID="dlReason" runat="server">
                        <asp:ListItem Text="select"></asp:ListItem>
                        <asp:ListItem Text="Change Product"></asp:ListItem>
                        <asp:ListItem Text="Quantity Change"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="txtreasontext" runat="server" TextMode="MultiLine" placeholder="Enter Reason Please!!!"></asp:TextBox>
                    <p>
                        Are you sure want to Cancel this Bill?
                    </p>
                </div>
                <div align="center" class="popup_Buttons">
                    <input id="ButtonDeleleOkay" type="button" value="Yes" />
                    <input id="ButtonDeleteCancel" type="button" value="No" />
                </div>
            </div>
        </asp:Panel>
        <link href="../css/billingstyle.css" rel="stylesheet" />
    </form>
</body>
</html>
