<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="onlineOrderPos.aspx.cs" Inherits="Billing.Accountsbootstrap.onlineOrderPos" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src="../js/jquery-2.1.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Home() {
            var test = document.getElementById("lblbilltype");

            test.innethtml = "Home Delivery";

        }
    </script>
    <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="../js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
    <script src="../js/jquery.responsiveTabs.min.js" type="text/javascript"></script>
    <link href="../css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/chosen.css" />
    <link href="../css/responsive-tabs.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link id="Link1" href="../css/bootstrap.min.css" runat="server" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link id="Link2" href="../css/plugins/metisMenu/metisMenu.min.css" runat="server"
        rel="stylesheet" />
    <!-- Custom CSS -->
    <link id="Link3" href="../css/sb-admin-2.css" runat="server" rel="stylesheet" />
    <script src="../js/jquery-2.1.0.min.js" type="text/javascript"></script>
    <!-- Custom Fonts -->
    <link href="../Styles/style1.css" rel="stylesheet" />
    <style type="text/css">
        .button
        {
            background-color: #785a39;
            border: 1px;
            color: white;
            padding: 1px 3px;
            width: 150px;
            height: 50px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            cursor: pointer;
            border-radius: 25px;
        }
        
        .labelTxt
        {
            color: Black;
            border: 1px;
            padding: 1px 3px;
            width: 150px;
            height: 20px;
            text-align: right;
            text-decoration: none;
            display: inline-block;
            font-family: Calibri;
            font-size: 12px;
            cursor: pointer;
        }
        
        
        .button1
        {
            background-color: #9e6d32;
            border: none;
            color: white;
            padding: 1px 10px;
            height: 50px;
            font-weight: bold;
            width: 125px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 12px;
            margin: 4px 2px;
            cursor: pointer;
        }
        
        
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #b4dbec;
            width: 800px;
            height: 600px;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .footer
        {
            padding: 6px;
        }
        .modalPopup .yes, .modalPopup .no
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            border-radius: 4px;
        }
        .modalPopup .yes
        {
            background-color: #2FBDF1;
            border: 1px solid #0DA9D0;
        }
        .modalPopup .no
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
        
        .myfont
        {
            font-family: Calibri;
            font-size: 17px;
            font-style: normal;
            font-variant: normal;
            font-weight: 400;
            line-height: 18.7px;
            background-color: #f9f9f9;
        }
    </style>
    <script language="Javascript" type="text/javascript">

        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }

    </script>
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .scroll {
   width: 200px;
   height: 700px;
    background: red;
   overflow: auto;
}
.scroll::-webkit-scrollbar {
   width: 1em;
   display:none;
}


}
​
    </style>
    <style>
        .chkChoice input
        {
            margin-left: -20px;
        }
        .chkChoice td
        {
            padding-left: 20px;
        }
    </style>
</head>
<body class="myfont" style="background-color: #f9f9f9">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-lg-12" style="padding-top: 3px;">
        <asp:Label ID="billtypeid" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblordercount" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblordertype" Visible="false" runat="server"></asp:Label>
                <asp:DropDownList ID="attednertype" 
                                                        runat="server" Enabled="false">
                                                    </asp:DropDownList>
        <div id="Div1" runat="server" visible="false" class="col-lg-1">
            <table border="5">
                <tr>
                    <td>
                        <asp:Button ID="btnnew" runat="server" Text="HOLD" Visible="false" CssClass="btn-info"
                            Width="100px" Height="50px" OnClick="btnnew_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Change Table" CssClass="btn" Visible="false"
                            Width="100px" Height="50px" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Bill Print" CssClass="btn" BackColor="Wheat"
                            Width="100px" Height="50px" OnClick="Button3_Click" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="Settlement" CssClass="btn-success"
                            Width="100px" Height="50px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button8" runat="server" Text="New Kot" PostBackUrl="~/Accountsbootstrap/SalesGrid.aspx"
                            CssClass="btn" BackColor="LightBlue" Width="100px" Height="50px" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="View Table" CssClass="btn-danger" Width="100px"
                            Height="50px" OnClick="Button5_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-lg-12">
            
            <div class="col-lg-8">
                <div  style="background-color: #D0D3D6;">
                    <ul>
                        
                        <label id="lblbilltype" visible="false" runat="server"></label>
                        <asp:Label ID="lblonlineid" runat="server" Visible="false"  ></asp:Label>
                        <asp:Label ID="lblonlinenumber" runat="server" Font-Bold="true" Font-Size="Large"  ></asp:Label>
                        <asp:Label ID="lblptype" runat="server"  Font-Bold="true" Font-Size="Large"  ></asp:Label>
                    </ul>
                    
                    <div class="row"  style="background-color: #D0D3D6; padding-top: 30px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <asp:Label ID="lblmargin" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblmargintax" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblpaygate" Visible="false" runat="server"></asp:Label>
                                <table>
                                    <tr>
                                        <td width="20%">
                                            <label>
                                                Bill/Kot No</label>
                                            <asp:TextBox ID="txtBillNo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
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
                                        </td>
                                        <td width="25%">
                                            <label>
                                                Payment Mode</label>
                                            <asp:DropDownList Width="100%" ID="drpPayment" runat="server" OnSelectedIndexChanged="drppayment_selectedindex"
                                                AutoPostBack="false" CssClass="form-control">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Mobile Number</label>
                                            <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" AutoPostBack="true"
                                                MaxLength="10" placeholder="Mobile No" OnTextChanged="txtmobile_TextChanged">    </asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtmobile" />
                                        </td>
                                        <td>
                                            <label>
                                                Customer Name</label>
                                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                                        </td>
                                        <td runat="server" id="Chkbills" visible="false">
                                            <label>
                                                Order No</label>
                                            <asp:TextBox ID="txtorderno" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
                                            <asp:Label ID="lblorderno" runat="server" Visible="false" ></asp:Label>
                                        </td>
                                        <td runat="server" id="chkgivenby" visible="false">
                                            <label>
                                                Given By</label>
                                            <asp:TextBox ID="txtgiven" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td id="Td1" runat="server" visible="false">
                                            <label>
                                                Approved</label>
                                            <asp:DropDownList ID="ddlApproved" CssClass="form-control" runat="server" AutoPostBack="true">
                                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="Mr Anand " Text="Mr Anand"></asp:ListItem>
                                                <asp:ListItem Value="Mr Navaneethan " Selected="True" Text="Mr Navaneethan"></asp:ListItem>
                                                <asp:ListItem Value="Mr Sudarshan " Text="Mr Sudarshan"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <label>
                                                Amount</label><br />
                                            <label id="lbldisplay" runat="server" style="font-size: x-large; color: Blue">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
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
                                    <tr>
                                    <td colspan="2">
                                    <label>
                                        Attender Name</label>
                                    <asp:DropDownList Width="100%" ID="drpAttend" runat="server" AutoPostBack="false"
                                        Enabled="true" CssClass="form-control">
                                    </asp:DropDownList>
                                    </td>
                                    <td>
                                    <asp:Button ID="btnnsettlement" runat="server" OnClick="btnPrint_Click" Text="Settlement"
                                        class="btn btn-danger" Style="background-color: #993333" />
                                    </td>
                                    </tr>
                                </table>
                                <div>
                                    <asp:Label ID="lblKOTTblno" runat="server" Visible="false"></asp:Label>
                                    
                                    <asp:Button ID="btnsplit" runat="server" OnClick="btnsplit_click" Text="Split Bill"
                                        Visible="false" class="btn btn-danger" Style="background-color: #993333" />
                                    
                                    <asp:DropDownList ID="drpcomp" runat="server" CssClass="form-control" OnSelectedIndexChanged="drppayment1_selectedindex"
                                        Visible="false" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:CheckBox ID="chkcard" Visible="false" runat="server" Text="Card" />
                                    
                                    <div style="display: none">
                                        <asp:RadioButtonList ID="chkradbuttonn" CssClass="chkChoice" Enabled="true" RepeatColumns="2"
                                            RepeatDirection="Horizontal" runat="server" OnSelectedIndexChanged="chkinclusive"
                                            AutoPostBack="true">
                                            <asp:ListItem Text="Inclusive" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Enclusive" Value="4" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <asp:GridView ID="GridView1all" runat="server" Width="100%" HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="Wheat" CssClass="table table-hover" OnRowCommand="gvlist_RowCommand1"
                                        AutoGenerateColumns="false" GridLines="None" ShowHeader="true" OnRowDataBound="GridView1all_RowDataBound">
                                        
                                        <Columns>
                                            <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="categoryid" runat="server" Text='<%#Eval("categoryid") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="categoryuserid" runat="server" Text='<%#Eval("categoryuserid")%>'
                                                        Style="display: none"></asp:Label>
                                                    <asp:Label ID="lblkotid" runat="server" Text='<%#Eval("kotid")%>' Style="display: none"></asp:Label>
                                                    <asp:Label ID="lblkotNo" runat="server" Text='<%#Eval("KotNo")%>' Style="display: none"></asp:Label>
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
                                           
                                           <asp:TemplateField HeaderText="Avl.Qty" Visible="true" ItemStyle-Width="10%" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                    <asp:Label ID="Available_QTY" runat="server" Text='<%#Eval("Available_QTY") %>' Visible="true"></asp:Label>
                                                        <asp:Label ID="txttax" Visible="false" runat="server" Text='<%#Eval("gst") %>'></asp:Label>
                                                        <asp:TextBox ID="txtQty" AutoPostBack="true" Width="100%" Enabled="false" Text='<%#Eval("Qty") %>'
                                                            runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:BoundField DataField="BillQty" HeaderText="Bill Qty" />
                                           
                                             <asp:TemplateField HeaderStyle-Width="12%" HeaderText="Rate" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Rate" Width="100%" Text='<%#Eval("Rate") %>' Enabled="false" runat="server"></asp:TextBox>                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                          
                                          <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Amount" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Amount" Width="100%" Text='<%#Eval("Amount") %>' Style="text-align: right"
                                                            runat="server" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:BoundField DataField="gst" DataFormatString="{0:f}" Visible="false" />
                                            <asp:TemplateField Visible="false" HeaderText="Add">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgadd" runat="server" CommandName="add" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                        Height="20px" Width="20px" ImageUrl="~/images/add.jpg" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false" HeaderText="Minus">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgminus" runat="server" CommandName="minus" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                        Height="20px" Width="20px" ImageUrl="~/images/Minus.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="" Visible="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="BillQtyCheck" runat="server" OnCheckedChanged="chkLinked_CheckedChanged"
                                                        AutoPostBack="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div align="right">
                                       
                                    </div>
                                    <table id="Table3" width="100%" align="right" runat="server" class="table-bordered"
                                        style="background-color: White;">
                                        <tr id="tr3" runat="server">
                                            <td width="50px">
                                                <label>
                                                    Total Qty</label>
                                            </td>
                                            <td width="50px">
                                                <asp:Label ID="lbltotqtyg" Font-Bold="true" ForeColor="Red" Font-Size="20px" runat="server"></asp:Label>
                                                <asp:Label ID="lbltotqty" Visible="false" Font-Bold="true" ForeColor="Red" Font-Size="20px" runat="server"></asp:Label>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Item - Total</label>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lbltotal1g" runat="server"></asp:Label>
                                                <asp:Label ID="lbltotal1" Visible="false" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr4" runat="server">
                                            <td width="50px">
                                                <label>
                                                    CGST:</label>
                                                <asp:Label ID="lblcgstg" runat="server" Width="50px">0</asp:Label>
                                                <asp:Label ID="lblcgst" Visible="false" runat="server" Width="50px">0</asp:Label>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    SGST:</label>
                                                <asp:Label ID="lblsgstg" runat="server" Width="50px">0</asp:Label>
                                                <asp:Label ID="lblsgst" Visible="false" runat="server" Width="50px">0</asp:Label>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Tax</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtTaxg" Visible="false" runat="server" Width="50px">0</asp:TextBox>
                                                <asp:TextBox ID="txtTax"  runat="server" Width="50px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr5" runat="server">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="30px">
                                            </td>
                                        </tr>
                                        <tr id="tr6" runat="server">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    SubTotal</label>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lblsubttlg" runat="server" Width="50px">0</asp:Label>
                                                <asp:Label ID="lblsubttl" Visible="false" runat="server" Width="50px">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr7" runat="server">
                                            <td colspan="2" width="50px">
                                                <label>
                                                    Disc. Check</label>
                                                <asp:CheckBox ID="chkdiscg" Enabled="false" runat="server" OnCheckedChanged="disc_checkedchanged"
                                                    AutoPostBack="true" />
                                                    <asp:CheckBox ID="chkdisc" Visible="false" runat="server" OnCheckedChanged="disc_checkedchanged"
                                                    AutoPostBack="true" />
                                                <asp:TextBox ID="txtdiscotpg" runat="server" placeholder="Enter OTP" Enabled="false"
                                                    OnTextChanged="otp_chnaged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:TextBox ID="txtdiscotp" Visible="false" runat="server" placeholder="Enter OTP" Enabled="false"
                                                    OnTextChanged="otp_chnaged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Disc %</label>
                                                <asp:TextBox ID="txtDiscount1g" runat="server" AutoPostBack="false" Width="50px"
                                                    OnTextChanged="txtDiscount_TextChanged">0</asp:TextBox>
                                                    <asp:TextBox ID="txtDiscount1" Visible="false" runat="server" AutoPostBack="false" Width="50px"
                                                    OnTextChanged="txtDiscount_TextChanged">0</asp:TextBox>
                                                    <asp:TextBox ID="txtonlineamount" runat="server" CssClass="form-control" Visible="false" Enabled="false"
                                                        >0</asp:TextBox>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lbldisco1g" runat="server"></asp:Label>
                                                <asp:Label ID="lbldisco1" Visible="false" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr8" runat="server" style="display: none">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Advance</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtAdvanceg" runat="server" AutoPostBack="true" Width="50px" OnTextChanged="txtAdvance_TextChanged">0</asp:TextBox>
                                                <asp:TextBox ID="txtAdvance" runat="server" AutoPostBack="true" Width="50px" OnTextChanged="txtAdvance_TextChanged">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr9" runat="server" visible="false">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="30px">
                                            </td>
                                        </tr>
                                        <tr id="tr10" runat="server">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Total</label>
                                            </td>
                                            <td width="30px">
                                                <asp:Label ID="lblGrandTotal1g" runat="server" Width="50px"></asp:Label>
                                                <asp:Label ID="lblGrandTotal1" Visible="false" runat="server" Width="50px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr11" runat="server" style="display: none">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Cash Received</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtReceivedg" runat="server" AutoPostBack="true" AccessKey="c" OnTextChanged="txtReceived_TextChanged"></asp:TextBox>
                                                <asp:TextBox ID="txtReceived" Visible="false" runat="server" AutoPostBack="true" AccessKey="c" OnTextChanged="txtReceived_TextChanged"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr12" runat="server" visible="false">
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                            </td>
                                            <td width="50px">
                                                <label>
                                                    Balance</label>
                                            </td>
                                            <td width="30px">
                                                <asp:TextBox ID="txtBalg" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtBal" Visible="false" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divextra" runat="server" visible="false" >
                                <asp:TextBox ID="NtxtQty" onkeypress="return onlyNos(event,this);" placeholder="Enter Qty"
                                                        runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                                        <asp:DropDownList ID="drpitemNew" runat="server" OnSelectedIndexChanged="Qty_chnaged"
                                                        AutoPostBack="true" Width="150%" CssClass="chzn-select">
                                                    </asp:DropDownList>
                                                    <label id="lblOrdeNo" runat="server">
                                                        </label>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>
                                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                                    right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                                    <asp:Image ID="imgUpdateProgress1" runat="server" ImageUrl="../images/01-progress.gif"
                                        AlternateText="Loading ..." ToolTip="Loading ..." Style="width: 150px; padding: 10px;
                                        position: fixed; top: 50%; left: 40%;" />
                                    <%--<asp:Image ID="imgUpdateProgress1" runat="server" ImageUrl="../images/loading.gif" />--%>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                    <script src="../js/jquery.responsiveTabs.js" type="text/javascript"></script>
                    <script type="text/javascript">

                        $(document).ready(function () {
                            var $tabs = $('#horizontalTab');
                            $tabs.responsiveTabs({
                                rotate: false,
                                startCollapsed: 'accordion',
                                collapsible: 'accordion',
                                setHash: true,

                                activate: function (e, tab) {

                                    $('.info').html('Tab <strong>' + tab.id + '</strong> activated!');
                                },
                                activateState: function (e, state) {
                                    //console.log(state);
                                    $('.info').html('Switched from <strong>' + state.oldState + '</strong> state to <strong>' + state.newState + '</strong> state!');
                                }
                            });

                        });


                    </script>
                </div>
            </div>
        </div>
        <%--<ul>
                                   <li><a href="#tab-1">Item</a></li>
                                    <li><a href="#tab-2">Order Summary <%=iCntt %><asp:Label id="count1" runat="server" style="color:Yellow"></asp:Label></a></li>
                                    <li><a href="#tab-3">Total Item</a></li>
                                   
                                </ul>--%>
        <div class="row" style="background-color: #D0D3D6; padding-top: 30px">
            <asp:Button ID="btnback" runat="server" OnClick="btnback_click" Text="<<" />
        </div>
    </div>
    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="Button4"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div class="header">
            SETTLEMENT
        </div>
        <div class="body" align="center">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table style="font-style: normal; background-color: ButtonHighlight" border="0" width="100%">
                        <tr style="font-weight: bold; background-color: #83b5fe; color; white">
                            <td>
                                Total Amount
                            </td>
                            <td>
                                CGST
                            </td>
                            <td>
                                SGST
                            </td>
                            <td>
                                Round Off
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTotalAmount" runat="server">0</asp:Label>
                            </td>
                            <td id="Td2" runat="server">
                                <asp:TextBox ID="txtservicetax" Visible="false" AutoPostBack="true" CssClass="form-control"
                                    OnTextChanged="service" runat="server">0</asp:TextBox>
                                <label id="lblserviceamt" visible="false" runat="server">
                                </label>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblRoundoff" runat="server">0</asp:Label>
                            </td>
                        </tr>
                        <tr style="font-weight: bold; background-color: #83b5fe; color; white">
                            <td>
                                Payment Mode
                            </td>
                            <td>
                                Discount
                            </td>
                            <td>
                                Amount received
                            </td>
                            <td>
                                Grand Total
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddpaymode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="change">
                                    <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Card" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Card/Cash" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="Not Paid" Value="14"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblBalance" Visible="false" runat="server">0</asp:Label>
                                <asp:TextBox ID="txtdiscount" AutoPostBack="true" CssClass="form-control" OnTextChanged="service"
                                    runat="server">0</asp:TextBox>
                                <label id="lbldisamt" runat="server">
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPaid" runat="server" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="Balance">0</asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr id="Cash" runat="server" visible="false" style="font-weight: bold; background-color: #83b5fe;
                            color; white">
                            <td>
                                Card Type
                            </td>
                            <td>
                                Card Number
                            </td>
                            <td>
                                Card Amount
                            </td>
                            <td>
                                Cash Amount
                            </td>
                        </tr>
                        <tr id="Card" runat="server" visible="false">
                            <td>
                                <asp:DropDownList ID="ddcardtype" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Master" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Visa" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Maestro" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcardNo" runat="server" CssClass="form-control">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcardAmount" runat="server" CssClass="form-control">0</asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcashAmount" runat="server">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Address" runat="server" visible="false" style="font-weight: bold; background-color: #83b5fe;
                            color; white">
                            <td>
                                Customer Name
                            </td>
                            <td>
                                Mobile No
                            </td>
                            <td>
                                Address
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr id="cust" runat="server" visible="false">
                            <td>
                                <asp:TextBox ID="txtCustomerName1" CssClass="form-control" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtmobile1" CssClass="form-control" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div style="overflow: scroll; height: 250px">
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <div class="footer" align="right">
                <asp:Button ID="btnsettle" runat="server" CssClass="yes" Text="Save Bill" OnClick="CompleteBill" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="no" />
            </div>
        </div>
    </asp:Panel>
    <div style="display: none">
        <asp:Button ID="btnDummy" runat="server" Text="Button" />
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2"
        TargetControlID="btnDummy" CancelControlID="Button10" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div class="header">
            Please Verify Here to Use Discount
        </div>
        <div class="body" align="center">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <table style="font-style: normal; background-color: ButtonHighlight" border="0" width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lbl" Style="display: none">User Name</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="username" runat="server" Text="admin" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label>Password</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <div class="footer" align="right">
                <asp:Button ID="Button9" runat="server" CssClass="yes" Text="Login" OnClick="KotBIll" />
                <asp:Button ID="Button10" runat="server" Text="Close" CssClass="no" />
            </div>
        </div>
    </asp:Panel>
    
    </form>
</body>
</html>
