<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentEntryNEW.aspx.cs" Inherits="Billing.Accountsbootstrap.PaymentEntryNEW" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Payment Entry</title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/TableCSSCode.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/chosen.css" />
    <script type="text/javascript">
        function Denomination123() {


            var gridData = document.getElementById('IDValues');


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
        $(function () {
            $("[id*=btnShowPopup]").click(function () {
                ShowPopup();
                return false;
            });
        });
        function ShowPopup() {
            $("#dialog").dialog({
                title: "GridView",
                width: 450,
                buttons: {
                    Ok: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
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
</head>
<style type="text/css">
    body {
        font-family: Arial;
        font-size: 10pt;
    }

    .GridPager a, .GridPager span {
        display: block;
        height: 20px;
        width: 20px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }

    .GridPager a {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }

    .GridPager span {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }


    .mGrid {
        border-collapse: collapse;
        width: 100%;
        border: 1px solid gray;
        overflow: hidden;
        font-family: Calibri;
        font-size: medium;
        text-align: center;
    }
</style>
<script type="text/javascript">
    function alertMessage() {
        alert('Are You Sure, You want to delete This Customer!');
    }

    function switchViews(obj, imG) {
        var div = document.getElementById(obj);
        var img = document.getElementById(imG);
        if (div.style.display == "none") {
            div.style.display = "inline";


            img.src = "../images/minus.gif";

        }
        else {
            div.style.display = "none";
            img.src = "../images/plus.gif";

        }
    }


    function Diaplay() {
        var div = document.getElementById("div");

        if (div.style.display == "none") {
            div.style.display = "inline";




        }
        else {
            div.style.display = "none";


        }
    }
</script>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="f1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row panel-custom1">
                        <div class="panel-header">
                            <h1 class="page-header">Add payment Entry</h1>
                        </div>
                        <div class="panel-body">
                            <div class="row">

                                <div class="col-lg-3">
                                    <label>Payment No</label>
                                    <asp:TextBox ID="txtBillNo" CssClass="form-control" runat="server"
                                        Enabled="false"></asp:TextBox>
                                    <asp:DropDownList runat="server" ID="ddltype" CssClass="form-control"
                                        Visible="false">
                                        <asp:ListItem Text="Payment" Value="Payment" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        PaymentDate</label>
                                    <asp:TextBox ID="txtBillDate" CssClass="form-control" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBillDate"
                                        Format="dd/MM/yyyy" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server"
                                        CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="col-lg-3">
                                    <label>
                                        Supplier
                                    </label>
                                    <asp:DropDownList runat="server" ID="ddlsuplier" CssClass="form-control" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-lg-3">
                                    <label>
                                        PaidAmount
                                    </label>
                                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" AutoPostBack="true"
                                        Enabled="false" OnTextChanged="txtAmount_TextChanged">0.00</asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-lg-2">
                                    <label>
                                        PayMode</label>
                                    <asp:DropDownList ID="ddlPayMode" runat="server" CssClass="form-control"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlPayMode_OnSelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <label>
                                        Bank Name</label>
                                    <asp:TextBox ID="txtbank" CssClass="form-control" runat="server" Enabled="false" Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-control" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <label>
                                        CHQ/UTR</label>
                                    <asp:TextBox ID="txtCheqeNo" CssClass="form-control" runat="server"
                                        Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <label>
                                        Entry by</label>
                                    <asp:TextBox ID="txtEntryBy" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <br />


                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary pos-btn1" Text="Process"
                                        OnClientClick="Confirm(this)" UseSubmitBehavior="false" OnClick="Process_Click" />
                                    <%--<asp:DropDownList ID="ddlbank" runat="server" Width="100px" Visible="false" CssClass="form-control">
                    </asp:DropDownList>--%>
                                    <asp:TextBox ID="txtCloseDiscount" CssClass="form-control" runat="server"
                                        Enabled="false" Visible="false">0.00</asp:TextBox>
                                    &nbsp;&nbsp;<asp:Button ID="btncalc" runat="server" class="btn btn-warning" Text="Calculate" OnClick="btncalc_Click" />
                                    &nbsp; &nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="Export To Excel" Visible="true" Class="btn btn-success"
                                        OnClick="btnExcel_Click" />
                                    <%--<asp:Button ID="btnexit" runat="server" class="btn btn-danger" Text="Exit" 
                        OnClick="btnexit_OnClick" />--%>
                                    <asp:TextBox ID="txtchequedate" CssClass="form-control" runat="server"
                                        Visible="false" Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" TargetControlID="txtchequedate"
                                        Format="dd/MM/yyyy" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server"
                                        CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>

                                </div>
                            </div>
                            <div class="row">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-lg-2">
                                                <asp:TextBox placeholder="Search Text" ID="txtsearchmobile" Style="height: 28px;"
                                                    runat="server" CssClass="form-control" MaxLength="25" Visible="false" onkeyup="Search_Gridview(this, 'gv')"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                                    FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" ._/-"
                                                    TargetControlID="txtsearchmobile" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="IDValues" runat="server">

                                    <div class="col-lg-12">
                                        <div id="Div5" runat="server" class="table-responsive panel-grid-left">
                                            <asp:GridView ID="gv" EmptyDataText="Oops! No Activity Performed." ShowFooter="true"
                                                Caption="Customer Cash Receive" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                runat="server" AutoGenerateColumns="false">
                                                <%-- <PagerStyle HorizontalAlign="Left" CssClass="GridPager" />--%>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                            <asp:Label ID="lblSalesid" runat="server" Text='<%# Eval("salesid")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BillNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BillDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBillDate" runat="server" Text='<%# Eval("BillDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Bill Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBillAmt" runat="server" Text='<%# Eval("Total","{0:f2}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Return Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReturnAmount" runat="server" Text='<%# Eval("ReturnAmount","{0:f2}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Paid Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPaidamt" runat="server" Text='<%# Eval("ReceiptAmount","{0:f2}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Balance Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Balance","{0:f2}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Payment Amount">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtpaid" runat="server" MaxLength="10" Enabled="true">0</asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderpaid" runat="server"
                                                                FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtpaid" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Close Discount"
                                                        Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtclosediscount" runat="server" MaxLength="4">0</asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderpaid1" runat="server"
                                                                FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtclosediscount" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Entry By" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtNarration" runat="server" Text=""></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Tick to Calc Amount">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkamount" runat="server" AutoPostBack="true" OnCheckedChanged="Chkamount_click"
                                                                Checked="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <div id="refund" runat="server" visible="false">
                                            <asp:Label ID="Label1" runat="server" Style="font-size: larger; font-weight: bold">Refund Amont:</asp:Label>
                                            <asp:Label ID="lblledgerbalance" runat="server" Style="font-size: larger; font-weight: bold">0</asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--  <div class="panel-body">
        <div class="row">
            <div class="col-lg-12">
                <div class="col-lg-1">
                    <label style="color: Black">
                        Payment No</label>
                    <asp:TextBox ID="txtBillNo" CssClass="form-control" runat="server" Width="100px"
                        Enabled="false"></asp:TextBox>
                    <asp:DropDownList runat="server" ID="ddltype" CssClass="form-control" Width="110px"
                        Visible="false">
                        <asp:ListItem Text="Payment" Value="Payment" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1">
                    <label style="color: Black">
                        Payment Date</label>
                    <asp:TextBox ID="txtBillDate" CssClass="form-control" Width="100px" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBillDate"
                        Format="dd/MM/yyyy" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server"
                        CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-2">
                    <label style="color: Black">
                        Supplier
                    </label>
                    <asp:DropDownList runat="server" ID="ddlsuplier" CssClass="form-control" AutoPostBack="true"
                        Width="200px" OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1">
                    <label style="color: Black">
                        Paid Amount
                    </label>
                    <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" AutoPostBack="true"
                        Width="100px" Enabled="false" OnTextChanged="txtAmount_TextChanged">0.00</asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <label>
                        PayMode</label>
                    <asp:DropDownList ID="ddlPayMode" runat="server" CssClass="form-control" Width="100px"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlPayMode_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1">
                    <label>
                        Bank Name</label>
                    <asp:TextBox ID="txtbank" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <label>
                        CHQ/UTR</label>
                    <asp:TextBox ID="txtCheqeNo" CssClass="form-control" runat="server" Width="100px"
                        Enabled="false"></asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <br />
                    <asp:Button ID="btncalc" runat="server" class="btn btn-warning" Text="Calc" OnClick="btncalc_Click"
                        Width="100px" />
                </div>
                <div class="col-lg-1">
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="Process"
                        OnClientClick="Confirm(this)" UseSubmitBehavior="false" Width="100px" OnClick="Process_Click" />
                    <asp:DropDownList ID="ddlbank" runat="server" Width="100px" Visible="false" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCloseDiscount" CssClass="form-control" runat="server" Width="100px"
                        Enabled="false" Visible="false">0.00</asp:TextBox>
                </div>
                <div class="col-lg-1">
                    <br />
                    <asp:Button ID="btnexit" runat="server" class="btn btn-danger" Text="Exit" Width="100px"
                        OnClick="btnexit_OnClick" />
                    <asp:TextBox ID="txtchequedate" CssClass="form-control" Style="width: 100px;" runat="server"
                        Visible="false" Enabled="false"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" TargetControlID="txtchequedate"
                        Format="dd/MM/yyyy" PopupButtonID="txtdate1" EnabledOnClient="true" runat="server"
                        CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-1">
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Export To Excel" Visible="true" CssClass="btn btn-info"
                        OnClick="btnExcel_Click" Style="width: 100px;" />
                </div>
                <div class="col-lg-1">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-2">
                            <asp:TextBox placeholder="Search Text" ID="txtsearchmobile" Style="height: 28px;"
                                runat="server" CssClass="form-control" MaxLength="25" Visible="false" onkeyup="Search_Gridview(this, 'gv')"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" ._/-"
                                TargetControlID="txtsearchmobile" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="IDValues" runat="server">
                <div class="col-lg-12">
                    <div class="col-lg-2">
                    </div>
                    <div class="col-lg-8">
                        <div id="Div5" runat="server" style="height: 600px; overflow: scroll;">
                            <asp:GridView ID="gv" EmptyDataText="Oops! No Activity Performed." ShowFooter="true"
                                Caption="Customer Cash Receive" CssClass="mGrid" EmptyDataRowStyle-BackColor="#F4F4F4"
                                HeaderStyle-BackColor="#F4F4F4" runat="server" AutoGenerateColumns="false">
                                <PagerStyle HorizontalAlign="Left" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblSalesid" runat="server" Text='<%# Eval("salesid")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BillNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillNo" runat="server" Text='<%# Eval("BillNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BillDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillDate" runat="server" Text='<%# Eval("BillDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillAmt" runat="server" Text='<%# Eval("Total","{0:f2}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Return Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReturnAmount" runat="server" Text='<%# Eval("ReturnAmount","{0:f2}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paid Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaidamt" runat="server" Text='<%# Eval("ReceiptAmount","{0:f2}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Balance","{0:f2}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Amount Received">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpaid" runat="server" MaxLength="10" Enabled="true">0</asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderpaid" runat="server"
                                                FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtpaid" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Close Discount"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtclosediscount" runat="server" MaxLength="4">0</asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderpaid1" runat="server"
                                                FilterType="Custom,Numbers" ValidChars="." TargetControlID="txtclosediscount" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Entry By">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNarration" runat="server" Text=""></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <br />
                        <div id="refund" runat="server" visible="false">
                            <asp:Label ID="Label1" runat="server" Style="font-size: larger; font-weight: bold">Refund Amont:</asp:Label>
                            <asp:Label ID="lblledgerbalance" runat="server" Style="font-size: larger; font-weight: bold">0</asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-2">
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

        <script src="../bower_components/jquery/dist/jquery.min.js"></script>
        <script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <script src="../bower_components/metisMenu/dist/metisMenu.min.js"></script>
        <script src="../bower_components/raphael/raphael-min.js"></script>
        <script src="../bower_components/morrisjs/morris.min.js"></script>
        <script src="../js/morris-data.js"></script>
        <script src="../dist/js/sb-admin-2.js"></script>
    </form>
</body>
</html>
